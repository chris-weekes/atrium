using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.Data;
using lmDatasets;
using atLogic;
using atriumBE.Properties;


namespace atriumBE
{
    //Task Types
    // I - Issue
    // P - prompt
    // N - new record 
    // D - delete record
    // F - Related field
    // T - include
    // Q - queried record must return one record
    // S - select records can return 0 or more
    // L - load a record will load from db if record not already loaded
    // G - gets all records no criteria required
    // O - special object
    // R - repeat for block
    // U - one or more records must be returned
    // C - Query or new
    // M - most recent matching criteria
    // Z - conditional block

    public class ACEngine //: atLogic.BusinessProcess
    {

        public bool HasPrompt = false;
        public bool HasBFs = false;
        public bool HasDisbursement = false;
        public bool HasBilling = false;
        public bool HasDoc = false;
        public bool HasRel0 = false;
        public bool HasRel1 = false;
        public bool HasRel2 = false;
        public bool HasRel3 = false;
        public bool HasRel4 = false;
        public bool HasRel5 = false;
        public bool HasRel6 = false;
        public bool HasRel7 = false;
        public bool HasRel8 = false;
        public bool HasRel9 = false;
        public bool HasAnyRel = false;
        public bool HasTimeline = false;
        public string TemplateList = null;

        public Dictionary<string, DataView> relTables = new Dictionary<string, DataView>();

        internal atriumDB.ActivityRow prevAcRow;
        private atriumDB.ActivityRow prevComAcRow;
        atriumDB.ProcessRow myProcess;
        Stack<ParentChildStep> flowQ;
        FileManager myFM;
        public ActivityConfig.ActivityCodeRow myActivityCode;
        public ActivityConfig.ACSeriesRow myAcSeries;
        private atriumDB.ActivityRow myActivity;
        ACEngine.RevType revType;

        ConnectorType prevComAction = ConnectorType.NextStep;

        public Dictionary<string, object> ctx;

        public atriumDB.ActivityRow NewActivity
        {
            get { return myActivity; }
        }

        public ACEngine(FileManager fm, DateTime acDate, ActivityConfig.ACSeriesRow _acSeries, atriumDB.ProcessRow process, bool adHoc, string conversationIndex, atriumDB.ActivityRow prevAc, ConnectorType action, Stack<ParentChildStep> _flowQ, int revId, ACEngine.RevType _revType, DataRow contextRow)
        // : base(fm.AtMng)
        {

            try
            {

                if (_flowQ != null)
                    flowQ = _flowQ;

                myFM = fm;
                prevAcRow = prevAc;
                MailAction = action;
                revType = _revType;

                if (action == ConnectorType.Reply | action == ConnectorType.ReplyAll | action == ConnectorType.Forward)
                {
                    PrevComAcRow = prevAc;
                }
                else
                {
                    PrevComAcRow = null;
                }

                myAcSeries = _acSeries;
                myActivity = (atriumDB.ActivityRow)FM.GetActivity().Add(FM.CurrentFile);
                myActivity.ACSeriesId = myAcSeries.ACSeriesId;

                myActivity.ActivityDate = acDate;
                if (prevAcRow != null)
                    myActivity.PreviousActivityId = prevAcRow.ActivityId;

                AddToRelTables(myActivity, "Activity0");


                myActivityCode = myAcSeries.ActivityCodeRow;

                if (revId != 0 | contextRow != null)
                {
                    switch (revType)
                    {
                        case RevType.OutOfOffice:
                            officeDB.OfficerRow officerRow = myFM.AtMng.OfficeMng.GetOfficer().FindLoad(revId);

                            AddToRelTables(officerRow, "OutOfOffice");
                            //myActivity.OfficerId = revId;  //makes activity clearer but could have other impacts
                            break;
                        case RevType.Convert:
                        case RevType.Document:
                            if (FM.GetDocMng().DB.Document.FindByDocId(revId) == null)
                                FM.GetDocMng().GetDocument().Load(revId);

                            FM.GetDocMng().DB.Document.FindByDocId(revId).updateDate = DateTime.Now;
                            AddToRelTables(FM.GetDocMng().DB.Document.FindByDocId(revId), "Document0");
                            break;
                        case RevType.Appointment:
                            atriumDB.AppointmentRow apptr = FM.DB.Appointment.FindByApptId(revId);
                            apptr.updateDate = DateTime.Now;
                            DataView dvappt = new DataView(fm.DB.Appointment, "ApptId=" + apptr.ApptId + "", "", DataViewRowState.OriginalRows);
                            relTables.Add("AppointmentR", dvappt);
                            //AddToRelTables(FM.DB.Appointment.FindByApptId(revId), "AppointmentR");

                            break;
                        case RevType.CashBlotter:
                            CLAS.CashBlotterRow cbr = FM.GetCLASMng().DB.CashBlotter.FindByCashBlotterID(revId);
                            DataView dvcb = new DataView(FM.GetCLASMng().DB.CashBlotter, "CashBlotterID=" + cbr.CashBlotterID + "", "", DataViewRowState.OriginalRows);
                            relTables.Add("CashBlotterR", dvcb);
                            break;
                        case RevType.Context:
                            if (contextRow != null)
                                AddToRelTables(contextRow, "CONTEXT");
                            break;
                    }
                }



                if (process == null)//& acSeries.Start
                {
                    //if new process then add processrow
                    myProcess = (atriumDB.ProcessRow)FM.GetProcess().Add(FM.CurrentFile);
                    //if (thread != null)
                    //    myProcess.ThreadIndex = thread.Substring(0,44);
                    //

                    myProcess.NameE = myAcSeries.SeriesRow.SeriesDescEng;
                    myProcess.NameF = myAcSeries.SeriesRow.SeriesDescFre;
                    myProcess.SeriesId = myAcSeries.SeriesId;


                }
                else if (_acSeries.ACSeriesId == FM.AtMng.GetSetting(AppIntSetting.ImportedMailCodeAcId) || MailAction == ConnectorType.Reply || MailAction == ConnectorType.ReplyAll || MailAction == ConnectorType.Forward)
                {
                    //put replies, etc in the original process
                    //and imported mail
                    myProcess = process;
                }
                else if (!process.Active | (process != null && process.SeriesId != myAcSeries.SeriesId) | (flowQ != null && flowQ.Count > 0))//&& acSeries.Start
                {
                    //look for an existing process
                    //no longer check for active process ' and active=1'
                    //if we are popping out use an ex

                    atriumDB.ProcessRow[] prs = (atriumDB.ProcessRow[])FM.DB.Process.Select("'" + process.Thread + "' like Thread+'%'  and seriesid=" + myAcSeries.SeriesId.ToString());
                    if (prs.Length == 1 & (flowQ == null || flowQ != null && flowQ.Peek().ParentStep.StepType != 1))
                        myProcess = prs[0];
                    //else if (prs.Length == 0)
                    //    myProcess = process;
                    else
                    {
                        //check for gaps in the process chain
                        //create process records to bridge gap
                        if (flowQ == null)
                        {
                            flowQ = new Stack<ParentChildStep>();
                            ParentChildStep pcs = new ParentChildStep();
                            pcs.ChildStep = myAcSeries.SeriesRow;
                            if (prevAcRow != null)
                            {
                                ActivityConfig.ACSeriesRow acsTarget = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(prevAcRow.ACSeriesId);
                                //this will work for transfer
                                //find the acseries for the subprocess we are transferring to on the prev acs' process
                                ActivityConfig.ACSeriesRow[] acs1 = (ActivityConfig.ACSeriesRow[])FM.AtMng.acMng.DB.ACSeries.Select("Seriesid=" + acsTarget.SeriesId.ToString() + " and SubSeriesId=" + myAcSeries.SeriesId.ToString());
                                foreach (ActivityConfig.ACSeriesRow acsSS in acs1)
                                {
                                    foreach (ActivityConfig.ACDependencyRow acdrT in acsSS.GetACDependencyRowsByPreviousSteps())
                                    {

                                        if ((acdrT.LinkType == (int)ConnectorType.Transfer) && acdrT.CurrentStepId == prevAcRow.ACSeriesId)
                                        {
                                            pcs.ParentStep = acsSS;
                                        }
                                    }
                                }

                                //this is the original code 
                                //it will run if the new transfer logic didn't work
                                if (pcs.ParentStep == null)
                                {
                                    foreach (ActivityConfig.ACDependencyRow acdrT in acsTarget.GetACDependencyRowsByNextSteps())
                                    {
                                        if (acdrT.ACSeriesRowByPreviousSteps.StepType == (int)StepType.Subseries)
                                        {
                                            flowXMax = 0;

                                            pcs.ParentStep = acdrT.ACSeriesRowByPreviousSteps;
                                            GetFlowX(myAcSeries, acdrT.ACSeriesRowByPreviousSteps.ACSeriesId);
                                            break;
                                        }
                                    }
                                }
                            }
                            if (flowQ.Count == 0)
                            {

                                flowQ.Push(pcs);
                            }
                        }
                        //chain the process, making sure it is not part of an existing process
                        atriumDB.ProcessRow prevProc = process;
                        myProcess = process;
                        Queue<ParentChildStep> tempQ = new Queue<ParentChildStep>();
                        while (flowQ.Count > 0)
                        {

                            ParentChildStep pcsf = flowQ.Pop();
                            tempQ.Enqueue(pcsf);
                        }
                        int parentStepId = 0;
                        while (tempQ.Count > 0)
                        {

                            ParentChildStep pcsf = tempQ.Dequeue();
                            myProcess = (atriumDB.ProcessRow)FM.GetProcess().Add(FM.CurrentFile);
                            myProcess.Thread = prevProc.Thread + "-" + myProcess.Thread;
                            myProcess.NameE = pcsf.ChildStep.SeriesDescEng;
                            myProcess.NameF = pcsf.ChildStep.SeriesDescFre;
                            myProcess.SeriesId = pcsf.ChildStep.SeriesId;


                            if (pcsf.ParentStep != null)
                            {
                                myProcess.FirstActivityId = pcsf.ParentStep.ACSeriesId;
                                if (parentStepId == 0)
                                    parentStepId = pcsf.ParentStep.ACSeriesId;
                                myProcess.TriggerACSeriesId = parentStepId;
                            }
                            //if we came from a subseries step record it as the first activity
                            //if (prevAcRow != null)
                            //    myProcess.FirstActivityId = prevAcRow.ActivityId;
                            prevProc = myProcess;
                        }
                    }

                }

                else
                {
                    myProcess = process;
                }


                //if (myAcSeries.Finish)
                //    myProcess.Active = false;

                myActivity.ProcessId = myProcess.ProcessId;
                //myActivity.ActivityCode = myActivityCode.ActivityCode;
                myActivity.StepCode = myAcSeries.StepCode;
                myActivity.ActivityCodeID = myActivityCode.ActivityCodeID;

                atriumDB.ProcessRow parentProc = fm.GetProcess().ParentProcess(myProcess, false);
                if (myAcSeries.PauseParent | myAcSeries.StartParent)
                {
                    atriumDB.ProcessRow[] parentProcs = FM.GetProcess().FindAllProcess(parentProc, myProcess.ProcessId);
                    foreach (atriumDB.ProcessRow ppr in parentProcs)
                    {
                        if (myAcSeries.PauseParent)
                            ppr.Paused = true;

                        if (myAcSeries.StartParent)
                            ppr.Paused = false;
                    }
                }
                if (myAcSeries.StopParent)
                    fm.GetActivityBF().CompleteAllOnProcess(parentProc, myProcess.ProcessId);

                string cidx = "";
                if (conversationIndex != null)
                {
                    //incoming mail
                    cidx = conversationIndex;
                }
                else
                {
                    try
                    {
                        Redemption.MAPIUtils mapiUtil = DocumentBE.MAPIUtils();

                        if (prevAcRow != null && !prevAcRow.IsConvIndexBaseNull())
                            cidx = mapiUtil.ScCreateConversationIndex(prevAcRow.ConvIndexBase + prevAcRow.ConversationIndex);
                        else
                            cidx = mapiUtil.ScCreateConversationIndex("");
                    }
                    catch (Exception xRDO)
                    {
                        //this causes real email to fail
                        //it is not a valid conv index
                        //cidx = "ATRIUM-" + myActivity.ActivityId + "-1234567890123456789012345678901234567890";

                        //this is the correct way
                        string g = Guid.NewGuid().ToString("N");  //32 char guid
                        string t = "CF4E8797C7"; //10 char representing FILETIME - faked for now
                        cidx = "01" + t + g;

                    }
                }
                myActivity.ConvIndexBase = cidx.Substring(0, 44);
                myActivity.ConversationIndex = cidx.Remove(0, 44);

                if (PrevComAcRow == null)
                {
                    //trace back to orig message
                    //find acdep row for acseries that is either reply,replyall or forward
                    ActivityConfig.ACDependencyRow[] acdeps = (ActivityConfig.ACDependencyRow[])FM.AtMng.acMng.DB.ACDependency.Select("NextStepId=" + myAcSeries.ACSeriesId.ToString() + " and LinkType in (5,6,7)");
                    foreach (ActivityConfig.ACDependencyRow acdep in acdeps)
                    {
                        //                    atriumDB.ActivityRow[] arsCom = (atriumDB.ActivityRow[])FM.DB.Activity.Select("ProcessID=" + myProcess.ProcessId.ToString() + " and ACSeriesID=" + acdep.CurrentStepId.ToString(), "ActivityId");
                        atriumDB.ActivityRow[] arsCom = (atriumDB.ActivityRow[])FM.DB.Activity.Select("'" + myProcess.Thread + "' like ISNULL(Parent(Process_Activity).Thread,'zzxx99')+'%' and ACSeriesID=" + acdep.CurrentStepId.ToString(), "ActivityId");
                        if (arsCom.Length > 0)
                        {
                            //get last ac in case it is a loop
                            if (PrevComAcRow == null || PrevComAcRow.ActivityId < arsCom[arsCom.Length - 1].ActivityId)
                            {
                                PrevComAcRow = arsCom[arsCom.Length - 1];
                                MailAction = (ConnectorType)acdep.LinkType;
                            }
                            //break;
                        }
                    }
                }


                DoRelFields();

                //JLL 2010-11-19: Doesn't work - UseBilling refers to MyNewRows which has not been created until DoRelFields, below.
                if (FM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.TimeslipForEveryActivity, false))
                    UseBilling();

                //if (HasDoc )
                //{
                //    docDB.DocumentRow ddr = (docDB.DocumentRow)relTables["Document0"][0].Row;
                //    if(ddr.RowState!= DataRowState.Added)
                //        fm.GetDocMng().GetDocContent().Checkout(ddr.DocContentRow);
                //}
            }
            catch (Exception x)
            {
                Cancel();
                throw x;
            }
        }

        public bool isBlockHasGrid(ActivityConfig.ACSeriesRow acsr, int step)
        {
            bool hasGrid = false;
            foreach (ActivityConfig.ActivityFieldRow arf in FM.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + acsr.ACSeriesId.ToString() + " and TaskType in ('F','P') and step=" + step.ToString(), "seq"))
            {
                if (arf.FieldType == "M")
                {
                    hasGrid = true;
                    break;
                }

            }
            return hasGrid;
        }

        public atriumDB.ActivityRow PrevComAcRow
        {
            get { return prevComAcRow; }
            set { prevComAcRow = value; }
        }

        public FileManager FM
        {
            get { return myFM; }
        }
        public ConnectorType MailAction
        {
            get { return prevComAction; }
            set { prevComAction = value; }
        }

        public void UseBilling()
        {
            if (HasBilling)
            {
                //HasBilling = true;
                //always add new rows in the following tables

                //2017-08-11 JLL IUTIR - 9113: Add only if file allows it: New isBillable flag on metadata
                //Is filemetatype row always loaded into FM dataset?
                if (FM.CurrentFile.FileMetaTypeRow.isBillable)
                {
                    atriumDB.ActivityTimeRow actr = (atriumDB.ActivityTimeRow)FM.GetActivityTime().Add(NewActivity);
                    AddToRelTables(actr, "ActivityTime0");
                }

            }

        }

        public DataView AddToRelTables(DataRow dr, string alias)
        {
            if (!relTables.ContainsKey(alias))
            {
                DataView dv = new DataView(dr.Table, dr.Table.PrimaryKey[0].ColumnName + "=" + dr[dr.Table.PrimaryKey[0].ColumnName].ToString(), "", DataViewRowState.CurrentRows);
                relTables.Add(alias, dv);
            }

            return relTables[alias];

        }

        public void DoRelFields()
        {
            //this clears the prompt records out
            myFM.AtMng.acMng.DB.ActivityField.RejectChanges();


            LoadDataForStep(-10, myAcSeries.ACSeriesId);

            //load associated data
            //LoadAssocData();

            TestForSteps();

        }

        public void TestForSteps(int ACSeriesId)
        {
            //HasPrompt = false;
            HasBFs = false;
            HasDisbursement = false;
            HasBilling = false;
            HasDoc = false;
            HasRel0 = false;
            HasRel1 = false;
            HasRel2 = false;
            HasRel3 = false;
            HasRel4 = false;
            HasRel5 = false;
            HasRel6 = false;
            HasRel7 = false;
            HasRel8 = false;
            HasRel9 = false;
            HasAnyRel = false;
            HasTimeline = false;
            TemplateList = null;

            ActivityConfig.ACSeriesRow acs = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(ACSeriesId);

            HasDisbursement = myFM.AtMng.WorkingAsOfficer.OfficeRow.UsesBilling;
            if (HasDisbursement)
                HasDisbursement = acs.ShowDisb;

            HasBilling = myFM.AtMng.WorkingAsOfficer.UsesBilling;
            if (HasBilling)
                HasBilling = acs.HasBilling;

            if (acs.ShowBF)
                HasBFs = true;

            foreach (ActivityConfig.ActivityFieldRow arf in FM.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + ACSeriesId.ToString(), "seq"))
            {
                switch (arf.Step)
                {
                    case 0:
                        HasRel0 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 1:
                        HasRel1 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 2:
                        HasRel2 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 3:
                        HasRel3 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 4:
                        HasRel4 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 5:
                        HasRel5 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 6:
                        HasRel6 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 7:
                        HasRel7 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 8:
                        HasRel8 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                    case 9:
                        HasRel9 = true;
                        if (arf.Visible && arf.TaskType == "F")
                            HasAnyRel = true;
                        break;
                }
                if (arf.ObjectName == "ActivityTime")
                    HasBilling = true;

                if (arf.TaskType == "F" && arf.Step == 10 && arf.ObjectName == "Document")
                    HasDoc = true;

                if (arf.TaskType == "F" && arf.Step == 12 && arf.ObjectName == "Appointment")
                    HasTimeline = true;

                //get template list
                if (arf.Visible && !arf.ReadOnly && arf.FieldName == "TemplateCode" && arf.IsDefaultValueNull() && !arf.IsLookUpNull())
                    TemplateList = arf.LookUp;
            }
        }

        public void TestForSteps()
        {
            TestForSteps(myAcSeries.ACSeriesId);
        }
        public void DoStep(Step aceStep, bool firstTime)
        {
            int step;

            //   skipBlock = false;

            switch (aceStep)
            {
                case Step.Timeline:
                    step = 12;
                    break;
                case Step.Document:
                    step = 10;
                    break;
                case Step.Billing:
                    step = 11;
                    break;
                case Step.RelatedFields0:
                    step = 0;
                    break;
                case Step.RelatedFields1:
                    step = 1;
                    break;
                case Step.RelatedFields2:
                    step = 2;
                    break;
                case Step.RelatedFields3:
                    step = 3;
                    break;
                case Step.RelatedFields4:
                    step = 4;
                    break;
                case Step.RelatedFields5:
                    step = 5;
                    break;
                case Step.RelatedFields6:
                    step = 6;
                    break;
                case Step.RelatedFields7:
                    step = 7;
                    break;
                case Step.RelatedFields8:
                    step = 8;
                    break;
                case Step.RelatedFields9:
                    step = 9;
                    break;
                case Step.Prompt:
                    step = -1;
                    break;
                default:
                    throw new AtriumException(Properties.Resources.MisconfiguredStep + Properties.Resources.InvalidStep); //JLL 2013-09-27: Translation for 2013/10 Build, string moved to resource.

            }

            LoadDataForStep(step, myAcSeries.ACSeriesId);

            if (step >= 0 && asscRow == null)
                LoadAssocData();

            if (!skipBlock)
                SetDefaultValuesForStep(step, firstTime);


        }

        private DataView LoadSpecialObject(ActivityConfig.ActivityFieldRow arf)
        {
            DataView dv;
            switch (arf.DefaultValue)
            {
                case "GDAppellant":
                    if (!FM.CurrentFile.IsSourceFileIdNull())
                    {
                        FileManager fmGD = FM.AtMng.GetFile(FM.CurrentFile.SourceFileId);
                        fmGD.GetSSTMng();

                        SST.FilePartyRow[] fpr = (SST.FilePartyRow[])fmGD.GetSSTMng().DB.FileParty.Select("IsAppellant=1");
                        if (fpr.Length == 1)
                        {
                            atriumDB.FileContactRow fcr = fmGD.DB.FileContact.FindByFileContactid(fpr[0].FileContactId);

                            //use the contact row from current Filemanager
                            atriumDB.ContactRow cr = FM.DB.Contact.FindByContactId(fcr.ContactId);

                            dv = AddToRelTables(cr, arf.ObjectAlias);
                        }
                        else
                        {
                            dv = new DataView();

                            if (!relTables.ContainsKey(arf.ObjectAlias))
                            {

                                relTables.Add(arf.ObjectAlias, dv);
                            }
                        }
                    }
                    else
                    {
                        //add an empty row?  or do nothing
                        dv = new DataView();

                        if (!relTables.ContainsKey(arf.ObjectAlias))
                        {

                            relTables.Add(arf.ObjectAlias, dv);
                        }
                    }
                    break;
                case "SSTManager":
                    officeDB.OfficerRow orr = FM.LeadOfficeMng.GetOfficer().LoadByRoleCode("GM" + FM.CurrentFile.FileType);
                    if (orr == null)
                    {
                        dv = new DataView();

                        if (!relTables.ContainsKey(arf.ObjectAlias))
                        {

                            relTables.Add(arf.ObjectAlias, dv);
                        }
                    }
                    else
                        dv = AddToRelTables(orr, arf.ObjectAlias);
                    break;

                case "SourceFile":
                    if (FM.SourceFile != null)
                    {
                        dv = AddToRelTables(FM.SourceFile.CurrentFile, "SourceFile0");
                    }
                    else
                    {
                        if (!FM.CurrentFile.IsSourceFileIdNull())
                        {
                            FM.SourceFile = FM.AtMng.GetFile(FM.CurrentFile.SourceFileId);
                            dv = AddToRelTables(FM.SourceFile.CurrentFile, "SourceFile0");

                        }
                        else
                        {
                            dv = new DataView();

                            if (!relTables.ContainsKey(arf.ObjectAlias))
                            {

                                relTables.Add(arf.ObjectAlias, dv);
                            }
                            //   throw new AtriumException(String.Format(Properties.Resources.DataInaccessible + Properties.Resources.NoRecordsFound, arf.DefaultValue));
                        }
                    }


                    break;
                case "PreviousProcess":
                    atriumDB.ProcessRow procR = myFM.GetProcess().ParentProcess(myProcess, false);
                    if (procR != null)
                    {
                        dv = AddToRelTables(procR, arf.ObjectAlias);
                    }
                    else
                    {
                        dv = new DataView();

                        if (!relTables.ContainsKey(arf.ObjectAlias))
                        {

                            relTables.Add(arf.ObjectAlias, dv);
                        }
                    }
                    break;
                case "PreviousActivity":
                    if (prevAcRow != null)
                    {
                        dv = AddToRelTables(prevAcRow, "PreviousActivity0");

                    }
                    else
                        throw new AtriumException(String.Format(Properties.Resources.DataInaccessible + Properties.Resources.NoRecordsFound, arf.DefaultValue));
                    break;
                case "PreviousDocument":
                    if (prevAcRow != null)
                    {

                        if (!prevAcRow.IsDocIdNull())
                        {
                            if (FM.GetDocMng().DB.Document.FindByDocId(prevAcRow.DocId) == null)
                                FM.GetDocMng().GetDocument().Load(prevAcRow.DocId);

                            dv = AddToRelTables(FM.GetDocMng().DB.Document.FindByDocId(prevAcRow.DocId), "PreviousDocument0");

                        }
                        else
                            throw new AtriumException(String.Format(Properties.Resources.DataInaccessible + Properties.Resources.NoRecordsFound, arf.DefaultValue));

                    }
                    else
                        throw new AtriumException(String.Format(Properties.Resources.DataInaccessible + Properties.Resources.NoRecordsFound, arf.DefaultValue));

                    break;
                case "FirstActivity":
                    //create initial ac and doc on process special objects
                    atriumDB.ActivityRow firstAc1 = (atriumDB.ActivityRow)FM.DB.Activity.Select("Processid=" + myProcess.ProcessId.ToString(), "ActivityId")[0];
                    dv = AddToRelTables(firstAc1, "FirstActivity0");

                    break;
                case "FirstDocument":
                    atriumDB.ActivityRow firstAc = (atriumDB.ActivityRow)FM.DB.Activity.Select("Processid=" + myProcess.ProcessId.ToString(), "ActivityId")[0];


                    if (!firstAc.IsDocIdNull())
                    {
                        if (FM.GetDocMng().DB.Document.FindByDocId(firstAc.DocId) == null)
                            FM.GetDocMng().GetDocument().Load(firstAc.DocId);

                        dv = AddToRelTables(FM.GetDocMng().DB.Document.FindByDocId(firstAc.DocId), "FirstDocument0");

                    }
                    else
                        throw new AtriumException(String.Format(Properties.Resources.DataInaccessible + Properties.Resources.NoRecordsFound, arf.DefaultValue));

                    break;
                default:
                    throw new AtriumException(Properties.Resources.MisconfiguredStep + Properties.Resources.InvalidSpecialObject);

            }
            return dv;
        }

        private DataView LoadDataFromContext(ObjectBE obe, ActivityConfig.ActivityFieldRow arf)
        {
            //look in processcontext to see  if we have a link
            //then select it

            foreach (atriumDB.ProcessContextRow pcr in myProcess.GetProcessContextRows())
            {
                if (arf.ObjectName == pcr.LinkTable)
                {
                    DataView dv = new DataView(obe.myDT, obe.myDT.PrimaryKey[0].ColumnName + "=" + pcr.LinkId.ToString(), "", DataViewRowState.CurrentRows);
                    if (dv.Count > 0)
                        return dv;
                    else
                        throw new AtriumException("Could not find data referenced in process context. {0}-{1}", pcr.LinkTable, pcr.LinkId.ToString());
                }
            }

            //look in parent processes
            atriumDB.ProcessRow[] prs = (atriumDB.ProcessRow[])FM.DB.Process.Select("'" + myProcess.Thread + "' like Thread+'%' ", "Thread desc");

            foreach (atriumDB.ProcessRow pr in prs)
            {
                foreach (atriumDB.ProcessContextRow pcr in pr.GetProcessContextRows())
                {
                    if (arf.ObjectName == pcr.LinkTable)
                    {
                        DataView dv = new DataView(obe.myDT, obe.myDT.PrimaryKey[0].ColumnName + "=" + pcr.LinkId.ToString(), "", DataViewRowState.CurrentRows);
                        if (dv.Count > 0)
                            return dv;
                        else
                            throw new AtriumException("Could not find data referenced in process context. {0}-{1}", pcr.LinkTable, pcr.LinkId.ToString());
                    }
                }
            }
            return null;
        }

        int iRepeatMax = 0;

        public int RepeatMax
        {
            get { return iRepeatMax; }
            set { iRepeatMax = value; }
        }
        int iRepeatCurrent = 0;

        public int RepeatCurrent
        {
            get { return iRepeatCurrent; }
            set { iRepeatCurrent = value; }
        }
        bool isRepeating = false;

        public bool IsRepeating
        {
            get { return isRepeating; }
            set { isRepeating = value; }
        }

        public bool skipBlock = false;
        public void LoadDataForStep(int step, int acseriesId)
        {
            //this method loads the data required by the step into reltables
            // N - new record 
            // D - delete record?
            // Q - queried record must return one record
            // S - select records can return 0 or more
            // L - load a record will load from db if record not already loaded
            // G - gets all records no criteria required
            // O - special object
            // T - include other fields
            // R - repeat for block
            // U - one or more records must be returned
            // C - Query or new
            // M - most recent matching criteria
            // Z - conditional block

            skipBlock = false;
            isRepeating = false;
            bool fmSwitch = false;

            //hack to see if endedit fixes a problem - what problem???
            //we need to endedit on the current record so that it can be evaluated by datatable.select operations
            if (NewActivity != null)
            {
                foreach (DataView dv in relTables.Values)
                {
                    if (dv.Count > 0)
                        dv[0].EndEdit();
                }
            }
            DataTable dt = null;
            atLogic.ObjectBE oBE = null;
            foreach (ActivityConfig.ActivityFieldRow arf in FM.AtMng.acMng.DB.ActivityField.Select("Step=" + step.ToString() + " and ACSeriesId=" + acseriesId.ToString() + " and TaskType in ('FL','Z','Z1','M','C','U','R','N','L','Q','S','D','G','O','T','SN')", "seq"))
            {


                if (arf.TaskType == "R")
                    isRepeating = true;

                if (arf.TaskType == "T")
                {
                    //include rel fields from other ac
                    LoadDataForStep(step, System.Convert.ToInt32(arf.DefaultValue));
                }
                else
                {
                    if (!relTables.ContainsKey(arf.ObjectAlias) || isRepeating)
                    {
                        if (!fmSwitch)
                        {
                            dt = GetDt(arf.ObjectName);
                            oBE = FM.GetBEFromTable(dt);
                        }
                        fmSwitch = false;
                        DataRow dr = null;
                        DataRow[] drRecords;

                        DataView dv = null;
                        switch (arf.TaskType)
                        {
                            case "FL":
                                //switch to other filemanager must be followed by another use record statmenet that refers to same objectalias
                                string pkL = GetDefault(arf, false).ToString(); //this must be a fileid
                                int fileid = System.Convert.ToInt32(pkL);
                                FileManager otherFM = FM.AtMng.GetFile(fileid);
                                BEManager othermngr = otherFM.GetBEMngrForTable(arf.ObjectName);
                                dt = othermngr.MyDS.Tables[arf.ObjectName];
                                oBE = otherFM.GetBEFromTable(dt);
                                fmSwitch = true;


                                break;
                            case "O":
                                //load special object by default value
                                dv = LoadSpecialObject(arf);
                                break;
                            case "G":
                                drRecords = oBE.GetCurrentRow();
                                if (drRecords.Length == 1)
                                {
                                    dr = drRecords[0];
                                    dv = new DataView(dt, dt.PrimaryKey[0].ColumnName + "=" + dr[dt.PrimaryKey[0].ColumnName].ToString(), "", DataViewRowState.CurrentRows);
                                }
                                else
                                {
                                    dv = LoadDataFromContext(oBE, arf);
                                    if (dv == null)
                                        throw new AtriumException(String.Format(Properties.Resources.DataInaccessible + Properties.Resources.NoRecordsFound, dt.TableName));
                                }
                                break;
                            case "Z":
                            case "Z1":
                                //conditional block
                                WhereClause wcI = new WhereClause();
                                drRecords = QueryRecord(arf, oBE, wcI);

                                if (drRecords.Length == 0 && arf.TaskType == "Z")
                                {
                                    skipBlock = true;
                                    return;
                                }
                                else if (drRecords.Length > 0 && arf.TaskType == "Z1")
                                {
                                    skipBlock = true;
                                    return;
                                }

                                else
                                {
                                    dv = new DataView(dt, wcI.Filter(), "", DataViewRowState.CurrentRows);
                                }
                                break;
                            case "D":
                            case "Q":
                            case "S":
                            case "R":
                            case "U":
                            case "M":
                                //queried record
                                WhereClause wc = new WhereClause();
                                drRecords = QueryRecord(arf, oBE, wc);

                                if (arf.TaskType != "S" && arf.TaskType != "R" && arf.TaskType != "U" && drRecords.Length != 1)
                                {
                                    if (drRecords.Length == 0)
                                    {
                                        dv = null;
                                        NoDataError(arf, dt);
                                    }
                                    else if (arf.TaskType == "M")
                                    {
                                        string order = SortBy(arf);
                                        if (order == "")
                                            order = "entrydate desc," + dt.PrimaryKey[0].ColumnName + " desc";
                                        else
                                            order += ",entrydate desc," + dt.PrimaryKey[0].ColumnName + " desc";

                                        DataRow[] recent = dt.Select(wc.Filter(), order);
                                        dr = recent[0];
                                        dv = new DataView(dt, dt.PrimaryKey[0].ColumnName + "=" + dr[dt.PrimaryKey[0].ColumnName].ToString(), "", DataViewRowState.CurrentRows);
                                    }
                                    else
                                    {
                                        MakePrompt(oBE.myDT, arf.ObjectAlias);

                                        dv = new DataView(dt, wc.Filter(), "", DataViewRowState.CurrentRows);
                                    }


                                }
                                else
                                {
                                    if (arf.TaskType == "R")
                                    {
                                        iRepeatMax = drRecords.Length - 1;
                                        if (drRecords.Length == 0)
                                        {
                                            dv = new DataView(dt, wc.Filter(), "", DataViewRowState.CurrentRows);
                                            //NoDataError(arf, dt);
                                        }
                                        else
                                        {
                                            dr = drRecords[iRepeatCurrent];
                                            dv = new DataView(dt, dt.PrimaryKey[0].ColumnName + "=" + dr[dt.PrimaryKey[0].ColumnName].ToString(), "", DataViewRowState.CurrentRows);
                                        }
                                    }
                                    else
                                    {
                                        dv = new DataView(dt, wc.Filter(), SortBy(arf), DataViewRowState.CurrentRows);
                                        if (arf.TaskType == "U" && dv.Count == 0)
                                        {
                                            NoDataError(arf, dt);
                                        }
                                    }
                                }
                                //delete right away
                                if (arf.TaskType == "D" && drRecords.Length == 1)
                                {
                                    drRecords[0].Delete();
                                }
                                break;
                            case "C":
                            case "SN":
                                if (!arf.IsDefaultObjectNameNull() && relTables.ContainsKey(arf.DefaultObjectName) && relTables[arf.DefaultObjectName].Count == 0)
                                {
                                    //don't add a new record but create the view
                                    dv = new DataView(dt, "1=0", "", DataViewRowState.CurrentRows);

                                }
                                else
                                {
                                    WhereClause wc1 = new WhereClause();
                                    drRecords = QueryRecord(arf, oBE, wc1);
                                    if (drRecords.Length > 0)
                                    {
                                        if (arf.TaskType == "SN" | drRecords.Length == 1)
                                            dv = new DataView(dt, wc1.Filter(), "", DataViewRowState.CurrentRows);
                                        else
                                        {
                                            dv = null;
                                            NoDataError(arf, dt);
                                        }
                                    }
                                    else if (drRecords.Length == 0)
                                    {
                                        dr = oBE.Add(null);
                                        if (arf.TaskType == "C")
                                            dv = new DataView(dt, dt.PrimaryKey[0].ColumnName + "=" + dr[dt.PrimaryKey[0].ColumnName].ToString(), "", DataViewRowState.CurrentRows);
                                        else
                                            dv = new DataView(dt, wc1.Filter(), "", DataViewRowState.CurrentRows);

                                        if (!relTables.ContainsKey(arf.ObjectAlias))
                                        {
                                            relTables.Add(arf.ObjectAlias, dv);
                                        }

                                        //how to set defaults?
                                        string crit = "TaskType='" + arf.TaskType + "' and Acseriesid=" + arf.ACSeriesId.ToString() + " and ObjectAlias='" + arf.ObjectAlias + "'";
                                        ActivityConfig.ActivityFieldRow[] filter = (ActivityConfig.ActivityFieldRow[])myFM.AtMng.acMng.DB.ActivityField.Select(crit, "Seq");
                                        foreach (ActivityConfig.ActivityFieldRow arf1 in filter)
                                        {
                                            SetDefaultValueSingle(arf1);
                                        }
                                        if (NewActivity != null)
                                        {
                                            atriumDB.ProcessContextRow pcr1 = (atriumDB.ProcessContextRow)FM.GetProcessContext().Add(NewActivity.ProcessRow);
                                            pcr1.LinkTable = dt.TableName;
                                            pcr1.LinkId = (int)dr[dt.PrimaryKey[0].ColumnName];
                                        }
                                    }
                                }
                                break;
                            case "L":
                                //load record
                                //TFS#53498,53589 CJW 2013-08-28 created load task type to allow arbritray loading of single records by integer primary key
                                Type ty = oBE.GetType();
                                System.Reflection.MethodInfo mi = ty.GetMethod("Load", new Type[] { typeof(int) });
                                if (mi == null)
                                    throw new AtriumException(Properties.Resources.MisconfiguredStep + Properties.Resources.LoadTaskTypeNeedsInt);

                                string pk = GetDefault(arf, false).ToString();
                                DataRow drL = (DataRow)mi.Invoke(oBE, new object[] { System.Convert.ToInt32(pk) });
                                //   drRecords = new DataRow[] { drL };
                                //  dr = drRecords[0];

                                dv = new DataView(dt, dt.PrimaryKey[0].ColumnName + "=" + pk, "", DataViewRowState.CurrentRows);

                                break;
                            case "N":
                                //need to have parent loaded to an objectalias
                                //use default object to hold ref to parent
                                if (arf.IsDefaultObjectNameNull())
                                {
                                    throw new AtriumException(Properties.Resources.MisconfiguredStep + Properties.Resources.MustSpecifyDefaultObject);
                                }
                                else if (!relTables.ContainsKey(arf.DefaultObjectName))
                                {
                                    //top level object
                                    throw new AtriumException(Properties.Resources.MisconfiguredStep + Properties.Resources.ParentRecordNotLoaded);
                                }
                                else if (relTables.ContainsKey(arf.DefaultObjectName) && relTables[arf.DefaultObjectName].Count == 1)
                                {
                                    dr = oBE.Add(relTables[arf.DefaultObjectName][0].Row);
                                    dv = new DataView(dt, dt.PrimaryKey[0].ColumnName + "=" + dr[dt.PrimaryKey[0].ColumnName].ToString(), "", DataViewRowState.CurrentRows);

                                    if (NewActivity != null)
                                    {
                                        atriumDB.ProcessContextRow pcr = (atriumDB.ProcessContextRow)FM.GetProcessContext().Add(NewActivity.ProcessRow);
                                        pcr.LinkTable = dt.TableName;
                                        pcr.LinkId = (int)dr[dt.PrimaryKey[0].ColumnName];
                                    }
                                }
                                else if (relTables.ContainsKey(arf.DefaultObjectName) && relTables[arf.DefaultObjectName].Count == 0)
                                {
                                    //don't add a new record but create the view
                                    dv = new DataView(dt, "1=0", "", DataViewRowState.CurrentRows);

                                }
                                else
                                {
                                    throw new Exception(Properties.Resources.MisconfiguredStep + Properties.Resources.NoParentRecordFound);
                                }


                                break;

                            default:
                                throw new AtriumException(Properties.Resources.MisconfiguredStep + Properties.Resources.UnsupportedTaskType);

                        }

                        if (!relTables.ContainsKey(arf.ObjectAlias) && dv != null)
                        {
                            relTables.Add(arf.ObjectAlias, dv);
                        }
                        else if (isRepeating)
                        {
                            //the endedit is required or the pending edits disappear 
                            // relTables[arf.ObjectAlias][0].EndEdit();
                            relTables.Remove(arf.ObjectAlias);
                            relTables.Add(arf.ObjectAlias, dv);
                        }
                    }
                }
            }

            if (!isRepeating)
            {
                iRepeatCurrent = 0;
                iRepeatMax = 0;
            }

        }

        private void NoDataError(ActivityConfig.ActivityFieldRow arf, DataTable dt)
        {

            string crit = "TaskType='" + arf.TaskType + "' and Acseriesid=" + arf.ACSeriesId.ToString() + " and ObjectAlias='" + arf.ObjectAlias + "'";
            ActivityConfig.ActivityFieldRow[] filter = (ActivityConfig.ActivityFieldRow[])myFM.AtMng.acMng.DB.ActivityField.Select(crit, "Seq");
            foreach (ActivityConfig.ActivityFieldRow arf1 in filter)
            {
                if (!arf1.IsNull("Help" + FM.AppMan.Language.Substring(0, 1)))
                    throw new AtriumException(arf1["Help" + FM.AppMan.Language.Substring(0, 1)].ToString());
            }

            throw new AtriumException(Properties.Resources.DataInaccessible + Properties.Resources.NoRecordsMatchingCriteriaFound, dt.TableName);

        }

        private void SetDefaultValuesForStep(int step, bool firstTime)
        {
            //do not set values for visible, non read-only fields when firstTime is false

            // F - Related field
            // T - timekeeping

            //DataRow relRow;

            foreach (ActivityConfig.ActivityFieldRow arf in FM.AtMng.acMng.DB.ActivityField.Select("Step=" + step.ToString() + " and ACSeriesId=" + myAcSeries.ACSeriesId.ToString() + " and TaskType in ('F','T')", "seq"))
            {
                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "once")
                {
                    if (firstTime)
                        SetDefaultValueSingle(arf);
                }
                else if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "filter")
                {
                    //skip
                }
                else if (firstTime || !arf.Visible || arf.ReadOnly)
                {
                    SetDefaultValueSingle(arf);
                }
            }
        }

        private void SetDefaultValueSingle(ActivityConfig.ActivityFieldRow arf)
        {
            //defaults get set for the same for every record in the data view
            foreach (DataRowView drv in relTables[arf.ObjectAlias])
            {

                DataRow relRow = drv.Row;
                if (!arf.IsDefaultObjectNameNull())
                {
                    DataRow defRow = relTables[arf.DefaultObjectName][0].Row;
                    if (defRow == null && arf.Step == 10 && arf.ObjectName == "Recipient")
                    {
                        //???only happens when the default object doesn't get resolved and we are adding a new record
                        if (relRow.RowState == DataRowState.Added)
                            relRow.Delete();

                    }
                }
                //set defaults
                object temp = CalcDefaultValue(relRow.Table.Columns[arf.DBFieldName].DataType, arf);
                if (temp != null)
                    relRow[arf.DBFieldName] = temp;

            }
        }
        private string GetDBDefaultFieldName(ActivityConfig.ActivityFieldRow arf)
        {
            string tblName = relTables[arf.DefaultObjectName].Table.TableName;
            appDB.ddFieldRow[] dfrs = (appDB.ddFieldRow[])myFM.AtMng.DB.ddField.Select("TableName='" + tblName + "' and FieldName='" + arf.DefaultFieldName + "'");

            if (dfrs.Length > 0)
                return dfrs[0].DBFieldName;
            else
                throw new AtriumException("Default field name not found in ddField, " + tblName + ", " + arf.DBFieldName);


        }
        public object CalcDefaultValue(Type columnType, ActivityConfig.ActivityFieldRow arf)
        {
            object tempVal = null;
            if (!arf.IsDefaultObjectNameNull())
            {
                //get row for default values
                DataRow defRow = relTables[arf.DefaultObjectName][0].Row;
                string defaultFieldName = GetDBDefaultFieldName(arf);
                if (columnType == null)
                {
                    columnType = relTables[arf.DefaultObjectName].Table.Columns[defaultFieldName].DataType;

                }
                tempVal = GetDefaultValue(defRow, defaultFieldName);


                //check to see if defaultvalue is also present
                //if it is we add the values together (or use the parameter as an operator)
                if (!arf.IsDefaultValueNull())
                {

                    string defVal = GetDefaultValue(arf).ToString();
                    //currently we only support date and integer addition
                    if (columnType == System.Type.GetType("System.DateTime"))
                    {
                        tempVal = ActivityBE.AtriumDateAdd((DateTime)tempVal, defVal);

                    }
                    else if (columnType == typeof(int))
                    {

                        tempVal = (int)tempVal + System.Convert.ToInt32(defVal);

                    }
                    else if (columnType == typeof(string))
                    {

                        tempVal = tempVal.ToString() + defVal;

                    }
                    else
                    {
                        throw new AtriumException("Adding defaultvalue is not allowed on this data type!!");
                    }

                }

            }
            else if (ctx != null && arf.FieldType != "LB")
            {
                //check supplied context if it is present
                //only happens if we are doing certain mass activities
                if (ctx.ContainsKey(arf.ObjectAlias + arf.FieldName))
                    tempVal = ctx[arf.ObjectAlias + arf.FieldName];
            }
            else if (!arf.IsDefaultValueNull())
            {
                if (columnType == typeof(byte[]))
                {
                    tempVal = System.Text.Encoding.Default.GetBytes(arf.DefaultValue);
                }
                else
                {
                    tempVal = GetDefaultValue(arf);
                }
            }

            return tempVal;
        }



        public ACEngine(FileManager fm)
        // : base(fm.AtMng)
        {

            myFM = fm;



        }

        public bool SillyQuestion(ActivityConfig.ACSeriesRow sillyQuestion)
        {

            List<string> objAliasUsed = new List<string>();
            //we need to handle querying multiple tables
            //get the result (True or False) for each table
            //since we will be anding then together we can return false as soon as we get one false set
            ActivityConfig.ActivityFieldRow[] filter = (ActivityConfig.ActivityFieldRow[])myFM.AtMng.acMng.DB.ActivityField.Select("ACseriesId=" + sillyQuestion.ACSeriesId.ToString(), "Seq");

            foreach (ActivityConfig.ActivityFieldRow afr in filter)
            {
                if (!objAliasUsed.Contains(afr.ObjectAlias))
                {
                    WhereClause wc = new WhereClause();
                    DataRow[] drs = null;
                    objAliasUsed.Add(afr.ObjectAlias);

                    //ActivityConfig.ActivityFieldRow afr = sillyQuestion.GetActivityFieldRows()[0];
                    DataTable dt = GetDt(afr.ObjectName);
                    atLogic.ObjectBE oBE = FM.GetBEFromTable(dt);


                    drs = QueryRecord(afr, oBE, wc);

                    if (drs == null || drs.Length == 0)
                        return false;
                    //else
                    //    return drs.Length > 0;

                    if (!relTables.ContainsKey(afr.ObjectAlias))
                    {
                        DataView dv = new DataView(dt, wc.Filter(), "", DataViewRowState.CurrentRows);
                        relTables.Add(afr.ObjectAlias, dv);
                    }
                }
            }
            return true;
        }



        private DataRow[] QueryRecord(ActivityConfig.ActivityFieldRow arf1, atLogic.ObjectBE oBE, WhereClause wc)
        {
            DataRow[] drCurrent;

            //loop to build where clause
            //objectalias and acseriesid must match
            string crit = "TaskType='" + arf1.TaskType + "' and Acseriesid=" + arf1.ACSeriesId.ToString() + " and ObjectAlias='" + arf1.ObjectAlias + "'";
            ActivityConfig.ActivityFieldRow[] filter = (ActivityConfig.ActivityFieldRow[])myFM.AtMng.acMng.DB.ActivityField.Select(crit, "Seq");
            foreach (ActivityConfig.ActivityFieldRow arf in filter)
            {
                string op = "=";
                if (!arf.IsSpecialParameterNull())
                    op = arf.SpecialParameter;


                object df;
                df = GetDefault(arf, op == "=");
                if (df != null && df.ToString().Contains(",") && (arf.IsSpecialParameterNull() || arf.SpecialParameter == "="))
                {

                    op = "In";
                }
                if (df == null || df == System.DBNull.Value)
                {
                    wc.Add(arf.DBFieldName, op);
                }
                else
                {
                    if (op.ToLower() == "in" || op.ToLower() == "not in")
                    {
                        wc.Add(arf.DBFieldName, op, df.ToString());
                    }
                    else
                    {
                        // need to convert default value from string to appropriate type
                        switch (oBE.myDT.Columns[arf.DBFieldName].DataType.FullName)
                        {
                            case "System.Boolean":
                                wc.Add(arf.DBFieldName, op, Convert.ToBoolean(df));
                                break;
                            case "System.String":
                                wc.Add(arf.DBFieldName, op, df.ToString());
                                break;
                            case "System.DateTime":
                            case "System.DateTimeOffset":
                                if (df.GetType() == typeof(System.DBNull))
                                    wc.Add(arf.DBFieldName, op);
                                else
                                    wc.Add(arf.DBFieldName, op, Convert.ToDateTime(df));
                                break;
                            case "System.Int32":
                                wc.Add(arf.DBFieldName, op, Convert.ToInt32(df));
                                break;
                            default:
                                wc.Add(arf.DBFieldName, op, df.ToString());
                                break;
                        }
                    }

                }

            }


            string order = SortBy(arf1);
            drCurrent = oBE.myDT.Select(wc.Filter(), order);
            return drCurrent;
        }

        private string SortBy(ActivityConfig.ActivityFieldRow arf1)
        {
            string crit1 = "TaskType='SB' and Acseriesid=" + arf1.ACSeriesId.ToString() + " and ObjectAlias='" + arf1.ObjectAlias + "'";
            ActivityConfig.ActivityFieldRow[] filter1 = (ActivityConfig.ActivityFieldRow[])myFM.AtMng.acMng.DB.ActivityField.Select(crit1, "Seq");
            string order = "";
            string comma = "";

            foreach (ActivityConfig.ActivityFieldRow arf in filter1)
            {
                string dir = "";
                if (!arf.IsSpecialParameterNull())
                    dir = arf.SpecialParameter;
                order += comma + arf.DBFieldName + " " + dir;
                comma = ",";
            }
            return order;
        }

        private object GetDefault(ActivityConfig.ActivityFieldRow arf, bool useIn)
        {
            object df = null;
            if (!arf.IsDefaultValueNull())
            {
                df = CalcDefaultValue(null, arf);

                //allow for calculated values the same the setdefaults does

            }
            else
            {

                if (!relTables.ContainsKey(arf.DefaultObjectName))
                {
                    throw new AtriumException(Properties.Resources.MisconfiguredStep + Properties.Resources.RelatedDataNotLoaded);
                }



                foreach (DataRowView drV in relTables[arf.DefaultObjectName])
                {
                    DataRow drQ = drV.Row;
                    object temp = GetDefaultValue(drQ, GetDBDefaultFieldName(arf));
                    if (temp != null)
                    {
                        if (useIn && df != null)
                        {
                            //TODO:  put quotes if it is not numeric
                            df += "," + temp.ToString();

                        }
                        else
                        {
                            df = temp.ToString();
                        }
                    }
                }
            }

            if (df == null)
                return 0;
            else
                return df;
        }


        private DataTable GetDt(string tblName)
        {
            BEManager mngr;

            mngr = FM.GetBEMngrForTable(tblName);

            return mngr.MyDS.Tables[tblName];

        }

        static public string Truncate(string input, int length)
        {
            if (input.Length > length)
            {
                return input.Substring(0, length);
            }
            else
            {
                return input;
            }
        }

        public void Cancel()
        {
            try
            {
                foreach (BEManager be in FM.MyMngrs.Values)
                {
                    be.MyDS.RejectChanges();
                }

                FM.AtMng.CodeDB.RejectChanges();

                FM.GetActivity().Cancel();
                FM.GetDocMng().GetDocument().Cancel();

                foreach (DataView dv in relTables.Values)
                {
                    dv.Dispose();
                }
            }
            catch (Exception x)
            {
                //ignore

            }
        }

        /// <summary>
        /// Save all data enter via related fields
        /// </summary>
        public void Save(bool recalcRecipBFs, bool forImport)
        {

            //TFS#52162 CJW 2013-8-26
            //added recalcRecipBFs param to make it explicit when you want to force RecipBF creation
            //fixes bug with importing for filing
            if (myActivityCode.Communication & recalcRecipBFs)
                FM.GetActivity().CalculateRecipBF(myActivity, forImport);


            if (asscRow == null)
                LoadAssocData();

            //update process name
            if (!NewActivity.IsLinkTableNull())
            {
                string friendly = GetPromptText(asscRow);
                myProcess.NameE = Truncate(String.Format(myAcSeries.SeriesRow.NameFormatE, friendly), 256);
                myProcess.NameF = Truncate(String.Format(myAcSeries.SeriesRow.NameFormatF, friendly), 256);
            }

            FM.SaveAll();

            //CJW unecessary as order of saving document and doccontent has changed 2014-09-19
            //if (HasDoc)
            //    myFM.GetDocMng().GetDocument().LoadByFileId(myFM.CurrentFileId);
        }

        //private DataRow GetContextFromProcess(DataTable dt, DataRow[] drs)
        //{
        //    foreach (atriumDB.ActivityRow ar in FM.DB.Activity.Select("Processid=" + NewActivity.ProcessId.ToString(), "ActivityID"))
        //    {
        //        if (dt.TableName == "Document" && !ar.IsDocIdNull())
        //        {
        //            DataRow[] rs1 = dt.Select(dt.PrimaryKey[0].ColumnName + "=" + ar.DocId.ToString());
        //            if (rs1.Length == 1)
        //                return rs1[0];

        //        }
        //        else if (!ar.IsLinkTableNull() && ar.LinkTable == dt.TableName)
        //        {
        //            DataRow[] rs = dt.Select(dt.PrimaryKey[0].ColumnName + "=" + ar.LinkID.ToString());
        //            if (rs.Length == 1)
        //                return rs[0];
        //        }
        //    }
        //    if (drs == null)
        //        return null;

        //    foreach (DataRow dr in drs)
        //    {
        //        foreach (DataRelation rel in dt.ParentRelations)
        //        {
        //            DataRow drp = dr.GetParentRow(rel);
        //            if (drp != null && drp.Table.TableName != "EFile" && drp.Table.TableName != "Activity")
        //            {
        //                DataRow drContext = GetContextFromProcess(drp.Table, new DataRow[] { drp });
        //                if (drContext != null)
        //                    return drContext;
        //            }
        //        }
        //    }
        //    return null;
        //}

        private void MakePrompt(DataTable dt, string objectAlias)
        {
            if (dt.Rows.Count == 0)
            {
                throw new AtriumException(Resources.YouCannotEnterThisActivityAtThisTime + dt.TableName + "]");
            }

            //if prompt already exists remove it
            DataRow[] oldPrompts = FM.AtMng.acMng.DB.ActivityField.Select("TaskType='P' and ACSeriesId=" + myAcSeries.ACSeriesId.ToString());
            int i = 0;
            while (oldPrompts.Length > i)
            {
                i++;
                oldPrompts[0].Delete();
                oldPrompts[0].AcceptChanges();
            }


            atLogic.ObjectBE be = (atLogic.ObjectBE)dt.ExtendedProperties["BE"];

            ActivityConfig.ActivityFieldRow prompt = (ActivityConfig.ActivityFieldRow)FM.AtMng.acMng.GetActivityField().Add(myActivityCode);
            prompt.BeginEdit();
            prompt.ACSeriesId = myAcSeries.ACSeriesId;
            prompt.FieldName = be.PromptColumnName();
            prompt.DBFieldName = be.PromptColumnName();
            prompt.ObjectName = dt.TableName;
            prompt.TaskType = "P";
            prompt.FieldType = "M";

            prompt.ObjectAlias = objectAlias;
            string n = " ";
            if (startsWithVowel(be.FriendlyName()))
                n = "n ";
            prompt.LabelEng = "Select a" + n + be.FriendlyName();
            prompt.LabelFre = "Choisissez un enregistrement: " + be.FriendlyName();
            prompt.Seq = 0;
            prompt.Step = -1;
            prompt.EndEdit();

            prompt.AcceptChanges();
            HasPrompt = true;

        }

        public static bool startsWithVowel(string value)
        {
            if ("aeiouAEIOU".IndexOf(value.Substring(0, 1)) >= 0)
            {
                return true;
            }
            return false;
        }


        static public string GetPromptText(DataRow drList)
        {
            atLogic.ObjectBE be = (atLogic.ObjectBE)drList.Table.ExtendedProperties["BE"];

            string[] promptFields = be.PromptColumnName().Split(",".ToCharArray());
            string display = "";
            if (be.PromptFormat() == null)
            {
                foreach (string column in promptFields)
                {
                    if (drList.Table.Columns[column].DataType == System.Type.GetType("System.DateTime"))
                        display += Convert.ToDateTime(drList[column]).ToString("yyyy/MM/dd") + " - ";
                    else
                        display += drList[column].ToString() + " - ";
                }
                return display.Substring(0, display.Length - 3);
            }
            else
            {
                string[] promptData = new string[promptFields.Length];
                int i = 0;
                foreach (string column in promptFields)
                {
                    if (!drList.IsNull(column))
                    {
                        if (drList.Table.Columns[column].DataType == System.Type.GetType("System.DateTime"))
                            promptData[i] = Convert.ToDateTime(drList[column]).ToString("yyyy/MM/dd");
                        else
                            promptData[i] = drList[column].ToString();
                    }
                    else
                        promptData[i] = "";

                    i++;
                }

                return String.Format(be.PromptFormat(), promptData);
            }

        }


        DataRow asscRow;
        private void LoadAssocData()
        {
            if (myActivityCode.AssociatedObject != "")
            {
                asscRow = relTables[myActivityCode.AssociatedObject][0].Row;

                //try to set related field
                asscRow[myActivityCode.AssociatedField] = NewActivity.ActivityDate;
                //this gives us early validation of activitydate

                //set linktable and linkid
                NewActivity.LinkTable = asscRow.Table.TableName;
                NewActivity.LinkID = (int)asscRow[asscRow.Table.PrimaryKey[0].ColumnName];

                //update process name
                //this happens on save now
                //string friendly = GetPromptText(asscRow);
                //myProcess.NameE = Truncate(String.Format(myAcSeries.SeriesRow.NameFormatE, friendly), 256);
                //myProcess.NameF = Truncate(String.Format(myAcSeries.SeriesRow.NameFormatF, friendly), 256);

            }
        }

        int flowXMax = 0;
        private bool GetFlowX(ActivityConfig.ACSeriesRow currentAcs, int targetSeriesId)
        {
            if (flowXMax > 10)
                return false;

            flowXMax++;
            //find a path from the parent process to the child process
            ActivityConfig.ACSeriesRow[] acss = (ActivityConfig.ACSeriesRow[])FM.AtMng.acMng.DB.ACSeries.Select("SubseriesId=" + currentAcs.SeriesId.ToString());
            //look for direct links first
            foreach (ActivityConfig.ACSeriesRow acs in acss)
            {
                if (acs.ACSeriesId == targetSeriesId)
                {
                    //make sure we add the subseries record
                    ParentChildStep pcs = new ParentChildStep();
                    pcs.ChildStep = currentAcs.SeriesRow;
                    pcs.ParentStep = acs;
                    flowQ.Push(pcs);
                    flowXMax--;
                    return true;
                }
            }
            //look for recursive links second
            foreach (ActivityConfig.ACSeriesRow acs in acss)
            {
                if (GetFlowX(acs, targetSeriesId))
                {
                    if (currentAcs.SeriesId != acs.SeriesId)
                    {
                        //make sure we add the subseries record
                        ParentChildStep pcs1 = new ParentChildStep();
                        pcs1.ChildStep = currentAcs.SeriesRow;
                        pcs1.ParentStep = acs;
                        flowQ.Push(pcs1);
                        flowXMax--;
                        return true;
                    }
                }

            }
            //foreach (ActivityConfig.ACDependencyRow acdr in currentAcs.GetACDependencyRowsByPreviousSteps())
            //{
            //    ActivityConfig.ACSeriesRow acs = acdr.ACSeriesRowByNextSteps;
            //    if (acs.SeriesId == targetSeriesId)
            //    {
            //        return true;
            //    }
            //    if (GetFlowX(acs, targetSeriesId))
            //    {
            //        if (currentAcs.SeriesId != acs.SeriesId)
            //        {
            //            flowQ.Enqueue(acs.SeriesRow);
            //            return true;
            //        }
            //    }
            //}

            flowXMax--;
            return false;
        }


        private object GetDefaultValue(ActivityConfig.ActivityFieldRow arf)
        {
            object val = null;
            if (arf.DefaultValue.Contains("["))
            {
                val = FM.AtMng.GetTemplate().Parse(FM, relTables, arf.DefaultValue, ".txt");
            }
            else
            {
                val = FM.GetDefaultValue(arf.DefaultValue);
            }

            return val;
        }

        private object GetDefaultValue(DataRow dr, string columnName)
        {
            //use reflection to call column property on typed datarow
            try
            {
                System.Reflection.PropertyInfo pi;
                pi = dr.GetType().GetProperty(columnName);
                return pi.GetValue(dr, null);
            }
            catch (System.Data.StrongTypingException stx)
            {
                return null;
            }
            catch (Exception x)
            {
                return null;
            }
        }


        public void DocumentDefaults(bool noFromRecip)
        {
            if (HasDoc)
            {
                List<string> docs = new List<string>();

                LoadDataForStep(10, myAcSeries.ACSeriesId);

                docDB.DocumentRow newComDoc = (docDB.DocumentRow)relTables["Document0"][0].Row;


                //if (newComDoc.GetDocContentRows().Length == 0 && newComDoc.isElectronic && newComDoc.RowState != DataRowState.Added)
                FM.GetDocMng().GetDocContent().Load(newComDoc.DocRefId, newComDoc.CurrentVersion);

                if (newComDoc.GetDocContentRows().Length == 0 && newComDoc.isElectronic && newComDoc.RowState == DataRowState.Added)
                    FM.GetDocMng().GetDocContent().Add(newComDoc);

                if (newComDoc.RowState != DataRowState.Added)
                {
                    //added on 2010/4/26 to handle revising emails over multiple sessions
                    //FM.GetDocMng().GetRecipient().LoadByDocId(newComDoc.DocId);
                }


                NewActivity.DocId = newComDoc.DocId;
                if (newComDoc.RowState == DataRowState.Added & myActivityCode.Communication)
                    newComDoc.isLawmail = true;

                //this sets the defaults for all related documents
                SetDefaultValuesForStep(10, true); //doccontrol

                //check to see if there is already a from recipient record
                bool hasFrom = false;

                foreach (docDB.RecipientRow fromDR in newComDoc.GetRecipientRows())
                {
                    if (fromDR.Type == "0")
                        hasFrom = true;



                }
                //TODO:  don't add workingas as from if it is an outofofficereply 
                if (myAcSeries.ACSeriesId == myFM.AtMng.GetSetting(AppIntSetting.OutOfOfficeNotification))
                {
                    if (!hasFrom)
                    {
                        docDB.RecipientRow rrf = (docDB.RecipientRow)FM.GetDocMng().GetRecipient().Add(newComDoc);
                        officeDB.OfficerRow ff = (officeDB.OfficerRow)relTables["OutOfOffice"][0].Row;
                        rrf.OfficerId = ff.OfficerId;
                        rrf.Type = "0";
                    }
                    //set to recip as officerloggedon
                    docDB.RecipientRow rr = (docDB.RecipientRow)FM.GetDocMng().GetRecipient().Add(newComDoc);
                    officeDB.OfficerRow workingas = FM.AtMng.WorkingAsOfficer;
                    rr.OfficerId = workingas.OfficerId;
                    rr.Type = "1";
                }
                else
                {
                    if (newComDoc.RowState == DataRowState.Added & !noFromRecip)
                    {
                        if (!hasFrom)
                        {
                            //add from
                            docDB.RecipientRow rr = (docDB.RecipientRow)FM.GetDocMng().GetRecipient().Add(newComDoc);
                            officeDB.OfficerRow workingas = FM.AtMng.WorkingAsOfficer;
                            //rr.Address = workingas.EmailAddress;
                            //rr.OfficeId = workingas.OfficeId;
                            rr.OfficerId = workingas.OfficerId;
                            //rr.Name = workingas.LastName + ", " + workingas.FirstName + " (" + workingas.OfficerCode + ")";
                            rr.Type = "0";

                            // newComDoc.efFrom = rr.Name;
                        }
                    }
                }



                bool hasSubject = false;
                if (!newComDoc.IsefSubjectNull() && newComDoc.efSubject != "New Document")
                    hasSubject = true;

                docs.Add("Document0");
                if (revType != RevType.Convert & revType != RevType.Document)
                    GenTemplate("Document0");

                if (PrevComAcRow != null)
                {
                    //mark prev ac mail bf as read
                    foreach (atriumDB.ActivityBFRow abfr in PrevComAcRow.GetActivityBFRows())
                    {
                        if (!abfr.IsBFOfficerIDNull() && abfr.BFCode == "NEML" && abfr.BFOfficerID == myFM.AtMng.WorkingAsOfficer.OfficerId)//and it is yours! cjw feb 18 2010
                        {
                            abfr.isRead = true;
                            abfr.Completed = true;
                        }
                    }
                    docDB.DocumentRow prevComDoc = FM.GetDocMng().GetDocument().Load(PrevComAcRow.DocId);

                    FM.GetDocMng().GetDocContent().Load(prevComDoc.DocRefId, prevComDoc.CurrentVersion);
                    if (newComDoc.RowState == DataRowState.Added)  //this part of the test is not needed anymore: prevComAcRow.Communication &&
                    {

                        if (!prevComDoc.DocContentRow.IsContentsNull())
                        {
                            //newComDoc.DocContentRow.Ext = prevComDoc.DocContentRow.Ext;
                            //newComDoc.DocContentRow.Contents = prevComDoc.DocContentRow.Contents;
                            FM.GetDocMng().GetDocument().AddReplyHeader(prevComDoc, newComDoc);
                        }

                    }

                    //if (prevComDoc.GetRecipientRows().Length == 0)
                    //    FM.GetDocMng().GetRecipient().LoadByDocId(prevComDoc.DocId);

                    //set up recipients based on linktype
                    //get prevcom recips
                    string subject = prevComDoc.efSubject.Replace("RE: ", "").Replace("FW: ", "");

                    switch (MailAction)
                    {
                        case ConnectorType.Reply:
                            if (!hasSubject)
                                newComDoc.efSubject = DocumentBE.VerifySubjectLength("RE: " + subject);
                            docDB.RecipientRow from = (docDB.RecipientRow)FM.GetDocMng().DB.Recipient.Select("Docid=" + prevComDoc.DocId.ToString() + " and Type='0'")[0];
                            FM.GetDocMng().GetRecipient().AddRecipToMessage(from, newComDoc, RecipType.To);
                            break;
                        case ConnectorType.ReplyAll:
                            if (!hasSubject)
                                newComDoc.efSubject = DocumentBE.VerifySubjectLength("RE: " + subject);
                            foreach (docDB.RecipientRow r in prevComDoc.GetRecipientRows())
                            {
                                if (!r.IsOfficerIdNull() && r.OfficerId == FM.AtMng.WorkingAsOfficer.OfficerId)
                                {
                                    //don't add your self
                                }
                                else
                                {
                                    if (r.Type == "0" || r.Type == "1")
                                        FM.GetDocMng().GetRecipient().AddRecipToMessage(r, newComDoc, RecipType.To);
                                    if (r.Type == "2")
                                        FM.GetDocMng().GetRecipient().AddRecipToMessage(r, newComDoc, RecipType.CC);
                                }
                            }
                            break;
                        case ConnectorType.Forward:
                            if (!hasSubject)
                                newComDoc.efSubject = DocumentBE.VerifySubjectLength("FW: " + subject);
                            //add attachments
                            FM.GetDocMng().GetAttachment();
                            foreach (docDB.AttachmentRow att in prevComDoc.GetAttachmentRowsByDocument_Attachment())
                            {
                                docDB.AttachmentRow newAtt = (docDB.AttachmentRow)FM.GetDocMng().GetAttachment().Add(newComDoc);
                                newAtt.AttachmentId = att.AttachmentId;
                                newAtt.MsgId = newComDoc.DocId;

                            }
                            break;
                    }

                }
                foreach (docDB.RecipientRow fromDR in newComDoc.GetRecipientRows())
                {

                    //check for blank addresses and raise error
                    if (fromDR.IsNameNull())
                    {
                        myActivity.RowError = "Email address was not resolved.";
                        fromDR.Delete();
                        throw new AtriumException("Email address was not resolved.");
                    }

                }

                foreach (ActivityConfig.ActivityFieldRow arf in FM.AtMng.acMng.DB.ActivityField.Select("ObjectName='Document' and acseriesid=" + myAcSeries.ACSeriesId.ToString(), "seq"))
                {

                    if (!docs.Contains(arf.ObjectAlias))
                    {
                        docs.Add(arf.ObjectAlias);

                        //for additional documents create attachment records to link them to doc 0
                        docDB.AttachmentRow attXtra = (docDB.AttachmentRow)FM.GetDocMng().GetAttachment().Add(newComDoc);
                        docDB.DocumentRow attComDoc = (docDB.DocumentRow)relTables[arf.ObjectAlias][0].Row;

                        if (attComDoc.GetDocContentRows().Length == 0 && attComDoc.isElectronic && attComDoc.RowState == DataRowState.Added)
                            FM.GetDocMng().GetDocContent().Add(attComDoc);

                        attXtra.AttachmentId = attComDoc.DocId;

                        GenTemplate(arf.ObjectAlias);
                    }
                }

            }
        }

        private void GenTemplate(string objectAlias)
        {
            //gen template if required
            if (relTables.ContainsKey(objectAlias))
            {
                docDB.DocumentRow docRow = (docDB.DocumentRow)relTables[objectAlias][0].Row;

                //gen template
                if (!docRow.IstemplateCodeNull() && docRow.RowState == DataRowState.Added)
                {
                    //generate template

                    FM.AtMng.GetTemplate().GenLetter(docRow, FM, docRow.templateCode, relTables);



                }

            }

        }

        public ACEState Suspend()
        {
            ACEState aces = new ACEState();

            if (!FM.CurrentFile.IsFullFileNumberNull())
                aces.FriendlyName = String.Format("{2} - ({3}) {4} - ({0}) {1}", myActivity.StepCode, myActivity.ActivityNameEng, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), FM.CurrentFile.FullFileNumber, FM.CurrentFile.Name);
            else
                aces.FriendlyName = String.Format("{2} - ({0}) - {1} - (Unkown File Number And Name)", myActivity.StepCode, myActivity.ActivityNameEng, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            aces.HasBFs = HasBFs;
            aces.HasBilling = HasBilling;
            aces.HasDisbursement = HasDisbursement;
            aces.HasDoc = HasDoc;
            aces.HasTimeline = HasTimeline;
            aces.HasPrompt = HasPrompt;
            aces.HasRel0 = HasRel0;
            aces.HasRel1 = HasRel1;
            aces.HasRel2 = HasRel2;
            aces.HasRel3 = HasRel3;
            aces.HasRel4 = HasRel4;
            aces.HasRel5 = HasRel5;
            aces.HasRel6 = HasRel6;
            aces.HasRel7 = HasRel7;
            aces.HasRel8 = HasRel8;
            aces.HasRel9 = HasRel9;

            aces.prevComAction = prevComAction;

            aces.FileId = FM.CurrentFile.FileId;
            if (FM.ParentFile != null)
                aces.ParentFileId = FM.ParentFile.CurrentFile.FileId;

            aces.AcSeriesId = myAcSeries.ACSeriesId;
            aces.ActivityCodeId = myActivityCode.ActivityCodeID;

            if (prevComAcRow != null)
                aces.prevComAcId = prevComAcRow.ActivityId;

            if (prevAcRow != null)
                aces.prevAcId = prevAcRow.ActivityId;

            aces.ActivityId = myActivity.ActivityId;
            aces.ProcessId = myProcess.ProcessId;


            //ignore flowq

            aces.RelTables = new ACEState.RelTableInfo[relTables.Count];
            int i = 0;
            //save reltables
            foreach (string view in relTables.Keys)
            {
                ACEState.RelTableInfo rt = new ACEState.RelTableInfo();
                rt.TableName = view;
                if (relTables[view].Table == null)
                {
                    rt.SourceDS = "none";
                    rt.SourceTable = "none";
                }
                else
                {
                    rt.SourceDS = relTables[view].Table.DataSet.DataSetName;
                    rt.SourceTable = relTables[view].Table.TableName;
                }
                rt.RowFilter = relTables[view].RowFilter;
                aces.RelTables[i] = rt;
                i++;
            }

            //save dataset
            //aces.FM_DB=(atriumDB) FM.DB.GetChanges(   );
            aces.MyDataSets = new ACEState.MyDS[FM.MyMngrs.Values.Count];
            int j = 0;
            foreach (BEManager be in FM.MyMngrs.Values)
            {
                ACEState.MyDS mds = new ACEState.MyDS();
                mds.DSName = be.MyDS.DataSetName;
                mds.DS = (BEManager.GetChanges(be.MyDS));
                mds.DS.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
                aces.MyDataSets[j] = mds;
                j++;
            }

            return aces;
        }
        public ACEngine(FileManager fm, ACEState aces)
        //  : base(fm.AtMng)
        {
            HasBFs = aces.HasBFs;
            HasBilling = aces.HasBilling;
            HasDisbursement = aces.HasDisbursement;
            HasDoc = aces.HasDoc;
            HasTimeline = aces.HasTimeline;
            HasPrompt = aces.HasPrompt;
            HasRel0 = aces.HasRel0;
            HasRel1 = aces.HasRel1;
            HasRel2 = aces.HasRel2;
            HasRel3 = aces.HasRel3;
            HasRel4 = aces.HasRel4;
            HasRel5 = aces.HasRel5;
            HasRel6 = aces.HasRel6;
            HasRel7 = aces.HasRel7;
            HasRel8 = aces.HasRel8;
            HasRel9 = aces.HasRel9;

            prevComAction = aces.prevComAction;

            myFM = fm;
            if (aces.ParentFileId != 0)
            {
                myFM.ParentFile = myFM.AtMng.GetFile(aces.ParentFileId);
            }

            //restore datasets
            foreach (ACEState.MyDS ds1 in aces.MyDataSets)
            {
                BEManager mngr = FM.GetBEMngrForDS(ds1.DSName);
                mngr.isMerging = true;
                mngr.MyDS.Merge(ds1.DS);
                mngr.isMerging = false;
            }

            myAcSeries = myFM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(aces.AcSeriesId);
            myActivityCode = myFM.AtMng.acMng.DB.ActivityCode.FindByActivityCodeID(aces.ActivityCodeId);

            prevComAcRow = myFM.DB.Activity.FindByActivityId(aces.prevComAcId);
            prevAcRow = myFM.DB.Activity.FindByActivityId(aces.prevAcId);
            myActivity = myFM.DB.Activity.FindByActivityId(aces.ActivityId);
            myProcess = myFM.DB.Process.FindByProcessId(aces.ProcessId);

            //check if doc has been editted by someone else
            if (!myActivity.IsDocIdNull())
            {
                docDB.DocContentRow ddcr = myFM.GetDocMng().DB.DocContent.FindByDocId(myActivity.DocId);
                if (ddcr != null && !myFM.GetDocMng().GetDocContent().IsLatest(ddcr))
                    myFM.RaiseWarning(WarningLevel.Interrupt, "The document that was part of your suspended activity has been modified by another user - it is not possible to resume this activity, but its contents will still be made available so that you may retrieve it, should it be required", "AC Restore");
            }

            if (myFM.CurrentFile == null)
            {
                myFM.CurrentFile = myFM.DB.EFile.FindByFileId(aces.FileId);
            }

            flowQ = null; //pretty sure this is only used in the constructor

            //restore reltables
            DataSet ds = null;
            foreach (ACEState.RelTableInfo rt in aces.RelTables)
            {
                if (rt.SourceDS != "none")
                {
                    ds = FM.GetBEMngrForDS(rt.SourceDS).MyDS;
                }
                if (rt.SourceDS == "none")
                    relTables.Add(rt.TableName, new DataView());
                else
                    relTables.Add(rt.TableName, new DataView(ds.Tables[rt.SourceTable], rt.RowFilter, "", DataViewRowState.CurrentRows));
            }

            //  LoadAssocData();

            //check to see if activitydate is today
            if (myActivity.ActivityDate != DateTime.Today)
            {

            }


        }

        public enum Step
        {
            NoStep = 0,
            PickIssue = 1,
            CreateFile = 2,
            PickActivity = 3,
            ACInfo = 5,
            Prompt,
            RelatedFields0,
            RelatedFields1,
            RelatedFields2,
            RelatedFields3,
            RelatedFields4,
            RelatedFields5,
            RelatedFields6,
            RelatedFields7,
            RelatedFields8,
            RelatedFields9,
            Timeline,
            Document,
            BFs,
            Disbursements,
            Billing,
            Confirm,
            Results
        }
        public enum RevType
        {
            Nothing,
            Document,
            Appointment,
            Convert,
            CashBlotter,
            OutOfOffice,
            Context
        }
    }

    [Serializable]
    public class ACEState
    {
        //**** for restore screen
        public string FriendlyName;

        //**** from acwiz
        public List<ACEngine.Step> Seq = new List<ACEngine.Step>();

        public ACEngine.Step[] completedSteps;

        public ACEngine.Step myCurrentStep;
        public ACEngine.Step myPreviousStep;
        public int elapsedTimeSeconds;
        //**** end of acwiz section

        //**** from acengine
        [Serializable]
        public class RelTableInfo
        {
            public string TableName;
            public string SourceTable;
            public string SourceDS;
            public string RowFilter;
        }

        public bool HasPrompt = false;
        public bool HasBFs = false;
        public bool HasDisbursement = false;
        public bool HasBilling = false;
        public bool HasDoc = false;
        public bool HasTimeline = false;
        public bool HasRel0 = false;
        public bool HasRel1 = false;
        public bool HasRel2 = false;
        public bool HasRel3 = false;
        public bool HasRel4 = false;
        public bool HasRel5 = false;
        public bool HasRel6 = false;
        public bool HasRel7 = false;
        public bool HasRel8 = false;
        public bool HasRel9 = false;

        public ConnectorType prevComAction = ConnectorType.NextStep;

        public List<string> myNewRows;

        public int ParentFileId;  //for new files
        public int FileId;
        public int AcSeriesId;
        public int ActivityCodeId;

        public int prevAcId;
        public int prevComAcId;
        public int ProcessId;

        public int ActivityId;

        public RelTableInfo[] RelTables;

        [Serializable]
        public class MyDS
        {
            public string DSName;
            public DataSet DS;
        }
        public MyDS[] MyDataSets;


        //**** end of acengine section

        public override string ToString()
        {
            return FriendlyName;
        }

        public static DataSet GetDSFromACE(ACEState ace, string dsName)
        {

            foreach (MyDS d1 in ace.MyDataSets)
            {
                if (d1.DSName == dsName)
                    return d1.DS;
            }
            throw new AtriumException("Could not restore suspended activity");
        }
    }


}
