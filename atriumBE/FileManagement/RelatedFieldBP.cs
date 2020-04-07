using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using lmDatasets;
using atLogic;
using atriumBE.Properties;

namespace atriumBE
{

    public class ActivityBP
    {

        //doc management
        //public static int ACMailCodeId = 101364;
        //public static int ACImportedMailCodeId = 101238;
        //public static int ACNewDoc = 100263;
        //public static int ACNewRec = 101353;
        //public static int ACNewDocWord = 101097;
        //public static int ACReviseDocCodeId = 101055;
        //public static int ACDocumentCopied = 101387;
        //public static int ACReplyForward = 101386;
        //public static int ACNewMemo = 101707;
        //public static int ACNewFaxCoverSheet = 101825;

        //container related
        //public static int ACNewShortcutContainer = 101501;

        //file related
        //public static int ACNewFile = 100267; //Generic


        // office management
        //public static int ACNewOffice = 101491;


        //contact management
        //public static int ACNewContactId = 101420;
        //public static int ACNewFileContactId = 101421;
        //public static int ACNewAddressBookContactId = 101423;
        //public static int ACNewAddressBookFileContactId = 101425;

        FileManager myFM;
        ACEngine myACE;
        bool skipDoc = false;
        public int? LastActivityId = null;

        public bool SkipDoc
        {
            get { return skipDoc; }
            set { skipDoc = value; }
        }

        public ACEngine CurrentACE
        {
            get { return myACE; }
            set { myACE = value; }
        }

        public FileManager FM
        {
            get { return myFM; }
        }

        public List<ActivityConfig.ACSeriesRow> AcSeriesOKToAdd = new List<ActivityConfig.ACSeriesRow>();

        public Workflow Workflow
        {
            get
            {
                return new Workflow(this.FM);
            }
        }
        internal ActivityBP(FileManager fm)
        {
            myFM = fm;
            myFM.GetActivity().DeepLoadByFileId(fm.CurrentFile.FileId);
        }

        public void Refresh()
        {
            myFM.GetProcess().PreRefresh();
            myFM.GetProcessContext().PreRefresh();
            myFM.GetActivity().PreRefresh();
            myFM.GetActivityBF().PreRefresh();
            myFM.GetActivityTime().PreRefresh();
            myFM.GetDisbursement().PreRefresh();
            myFM.GetActivity().DeepLoadByFileId(myFM.CurrentFile.FileId);
        }

        //public ACEngine Add(DateTime acDate, ActivityConfig.ACSeriesRow acSeries, atriumDB.ProcessRow process, bool adHoc, atriumDB.ActivityRow prevAc, string conversationIndex)
        //{
        //    if (myACE != null)
        //        throw new AtriumException("You cannot enter more than one activity at a time on a file.");

        //    myACE = new ACEngine(FM, acDate, acSeries, process, adHoc, conversationIndex, prevAc, ConnectorType.NextStep, null, 0, ACEngine.RevType.Nothing);

        //    return myACE;

        //}

        public ACEngine Add(DateTime acDate, ActivityConfig.ACSeriesRow acSeries, atriumDB.ProcessRow process, bool adHoc, atriumDB.ActivityRow prevAc)
        {
            if (myACE != null)
                throw new AtriumException("You cannot enter more than one activity at a time on a file.");

            myACE = new ACEngine(FM, acDate, acSeries, process, adHoc, null, prevAc, ConnectorType.NextStep, null, 0, ACEngine.RevType.Nothing,null);
            return myACE;
        }

        public ACEngine Add(DateTime acDate, ActivityConfig.ACSeriesRow acSeries, atriumDB.ProcessRow process, bool adHoc, atriumDB.ActivityRow prevAc, ConnectorType action, Stack<ParentChildStep> _flowQ, int revId, ACEngine.RevType revType, string conversationIndex,DataRow contextRow)
        {
            //if (_flowQ != null)
            //    flowQ = _flowQ;
            if (myACE != null)
                throw new AtriumException("You cannot enter more than one activity at a time on a file.");

            ConnectorType ct;
            if (action == ConnectorType.Reply | action == ConnectorType.ReplyAll | action == ConnectorType.Forward)
            {
                ct = action;
            }
            else
            {
                ct = ConnectorType.NextStep;
            }
            myACE = new ACEngine(FM, acDate, acSeries, process, adHoc, conversationIndex, prevAc, ct, _flowQ, revId, revType, contextRow);
            return myACE;
        }

        public void OutOfOfficeReply(atriumDB.ActivityRow activity)
        {
            if (myFM.AtMng.GetSetting(AppBoolSetting.useOutOfOfficeFunctionality))
            {
                if (activity.Communication)
                {
                    docDB.DocumentRow docr = myFM.GetDocMng().DB.Document.FindByDocId(activity.DocId);
                    docDB.RecipientRow[] recips = docr.GetRecipientRows();
                    officeDB.OfficerRow officerRow;
                    foreach (docDB.RecipientRow rr in recips)
                    {
                        if (rr.Type != "0" && !rr.IsOfficerIdNull())
                        {
                            //check to see if they are out of the office
                            //always load in case person just set their out off office flag
                            officerRow = (officeDB.OfficerRow)myFM.AtMng.OfficeMng.GetOfficer().Load(rr.OfficerId);
                         
                            //jll 2018-04-24 - if recipient is external, this check should never happen. 
                            if (officerRow !=null && officerRow.OutOfOffice)
                            {
                                if (DateTime.Now >= officerRow.OutOfOfficeStartDate && DateTime.Now <= officerRow.OutOfOfficeEndDate)
                                {
                                    // do out of office activity
                                    ActivityConfig.ACSeriesRow acsr = myFM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(myFM.AtMng.GetSetting(AppIntSetting.OutOfOfficeNotification));
                                    CurrentACE = null;
                                    AutoAC(activity, acsr, officerRow.OfficerId, ACEngine.RevType.OutOfOffice, false);
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool AutoNextStep(atriumDB.ActivityRow activity)
        {
            //TODO:  prevent recursive calls to outofofficereply
            OutOfOfficeReply(activity);
            
            bool any = false;
            ActivityConfig.ACSeriesRow acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(activity.ACSeriesId);
            if (acsr.GetACDependencyRowsByNextSteps().Length == 0)
            {
                ActivityConfig.ACSeriesRow acss = FM.GetActivity().FindParentStep(activity);
                if (acss != null)
                {
                    foreach (ActivityConfig.ACDependencyRow acdr in acss.GetACDependencyRowsByNextSteps())
                    {
                        if (acdr.LinkType == (int)ConnectorType.Auto)
                        {
                            CurrentACE = null;
                            AutoAC(activity, acdr.ACSeriesRowByPreviousSteps, 0, ACEngine.RevType.Nothing);
                            any = true;
                        }
                    }
                }
            }
            else
            {
                foreach (ActivityConfig.ACDependencyRow acdr in acsr.GetACDependencyRowsByNextSteps())
                {
                    if (acdr.LinkType == (int)ConnectorType.Auto)
                    {
                        if (acdr.ACSeriesRowByPreviousSteps.StepType == (int)StepType.Decision && acdr.ACSeriesRowByPreviousSteps.GetActivityFieldRows().Length > 0)
                        {
                            //handle auto-steps that go to internal decisions
                            //only handles one level and must be a single path

                            bool ok = CurrentACE.SillyQuestion(acdr.ACSeriesRowByPreviousSteps);
                            foreach (ActivityConfig.ACDependencyRow acdrAnswr in acdr.ACSeriesRowByPreviousSteps.GetACDependencyRowsByNextSteps())
                            {
                                if ((ok && acdrAnswr.DescEng == "Yes") | (!ok && acdrAnswr.DescEng == "No"))
                                {
                                    ActivityConfig.ACSeriesRow acs_auto = acdrAnswr.ACSeriesRowByPreviousSteps;
                                    CurrentACE = null;
                                    AutoAC(activity, acs_auto, 0, ACEngine.RevType.Nothing);
                                    any = true;
                                }
                            }
                        }
                        else
                        {
                            CurrentACE = null;
                            AutoAC(activity, acdr.ACSeriesRowByPreviousSteps, 0, ACEngine.RevType.Nothing);
                            any = true;
                        }
                    }
                }
            }

            CurrentACE = null;

            return any;
        }

        //TFS#54543 BY 2013-8-29
        //made the function overloading so that we can set the activitydate
        private void AutoAC(atriumDB.ActivityRow prevAC, ActivityConfig.ACSeriesRow asr, int revId, ACEngine.RevType revType)
        {
            AutoAC(prevAC, asr, revId, revType, DateTime.Today,null,true);
        }

        private void AutoAC(atriumDB.ActivityRow prevAC, ActivityConfig.ACSeriesRow asr, int revId, ACEngine.RevType revType,bool recurse)
        {
            AutoAC(prevAC, asr, revId, revType, DateTime.Today, null,recurse);
        }

        public string Doc0 = null;
        //public string TemplateCode = null;
        public Dictionary<string, object> ctx;
        public atriumDB.ActivityRow PrototypeAC;

        private void AutoAC(atriumDB.ActivityRow prevAC, ActivityConfig.ACSeriesRow asr, int revId, ACEngine.RevType revType, DateTime acDate, Stack<ParentChildStep> _flowQ, bool recurse)
        {
            FileManager fmp = FM;
            try
            {
                if (asr.InitialStep == (int)ACEngine.Step.CreateFile)
                {
                    myFM = FM.AtMng.CreateFile(fmp);
                    prevAC = null;
                    revId = 0;
                }

         
                ACEngine ace;
                atriumDB.ActivityRow newAC;
                DoACAllSteps(prevAC, asr, revId, revType, acDate, out ace, out newAC,  _flowQ,null);
                LastActivityId = newAC.ActivityId;
                FM.GetActivity().CalculateBF(newAC, revId != 0, false);
                if(PrototypeAC!=null)
                {
                    if (!PrototypeAC.IsActivityCommentNull())
                        newAC.ActivityComment = PrototypeAC.ActivityComment;
                    //copy user bfs
                    foreach(atriumDB.ActivityBFRow abfr in PrototypeAC.GetActivityBFRows())
                    {
                        if(abfr.ACBFId==ActivityBFBE.USERBFID)
                        {
                            atriumDB.ActivityBFRow newabfr=(atriumDB.ActivityBFRow)FM.GetActivityBF().Add(newAC);
                            newabfr.BFDate = abfr.BFDate;
                            newabfr.InitialBFDate = abfr.InitialBFDate;
                            if(!abfr.IsBFCommentNull())
                                newabfr.BFComment = abfr.BFComment;
                            newabfr.BFType = abfr.BFType;
                            newabfr.BFOfficerID = abfr.BFOfficerID;
                            
                        }
                    }
                }
                ace.Save(true, false);

                FM.GetDocMng().GetDocument().Send(newAC);

                //recurse to allow nested files
                if(recurse)
                    AutoNextStep(newAC);
            }
            catch (Exception x)
            {
                myFM = fmp;
                throw x;
            }
            finally
            {
                myFM = fmp;
            }
        }

        internal void DoACAllSteps(atriumDB.ActivityRow prevAC, ActivityConfig.ACSeriesRow asr, int revId, ACEngine.RevType revType, DateTime acDate, out ACEngine ace, out atriumDB.ActivityRow newAC, Stack<ParentChildStep> _flowQ, string conversationIndex)
        {
            atriumDB.ProcessRow pr = null;
            if (prevAC != null)
                pr = prevAC.ProcessRow;
            ace = Add(acDate, asr, pr, false, prevAC, ConnectorType.NextStep, _flowQ, revId, revType, conversationIndex,null);
            ace.ctx = ctx;
         
            newAC = ace.NewActivity;
            if (ace.HasRel0)
                ace.DoStep(ACEngine.Step.RelatedFields0, true);
            if (ace.HasRel1)
                ace.DoStep(ACEngine.Step.RelatedFields1, true);
            if (ace.HasRel2)
                ace.DoStep(ACEngine.Step.RelatedFields2, true);
            if (ace.HasRel3)
                ace.DoStep(ACEngine.Step.RelatedFields3, true);
            if (ace.HasRel4)
                ace.DoStep(ACEngine.Step.RelatedFields4, true);
            if (ace.HasRel5)
                ace.DoStep(ACEngine.Step.RelatedFields5, true);
            if (ace.HasRel6)
                ace.DoStep(ACEngine.Step.RelatedFields6, true);
            if (ace.HasRel7)
                ace.DoStep(ACEngine.Step.RelatedFields7, true);
            if (ace.HasRel8)
                ace.DoStep(ACEngine.Step.RelatedFields8, true);
            if (ace.HasRel9)
                ace.DoStep(ACEngine.Step.RelatedFields9, true);
            if (ace.HasTimeline)
                ace.DoStep(ACEngine.Step.Timeline, true);
            
            if (ace.HasDoc & !SkipDoc)
            {
                docDB.DocumentRow dr = (docDB.DocumentRow)ace.relTables["Document0"][0].Row;

                //if (TemplateCode != null) //only set the template if it is provided
                //    dr.templateCode = TemplateCode;

                ace.DocumentDefaults(revId != 0);
                // if (dr.DocContentRow == null)
                //FM.GetDocMng().GetDocContent().Load(dr.DocRefId, dr.CurrentVersion);

                Doc0 = dr.DocContentRow.ContentsAsText;
            }
            else
            {
                ace.FM.GetDocMng().DB.RejectChanges();
                ace.relTables.Remove("Document0");

                ace.NewActivity.SetDocIdNull();
            }
            if (ace.HasBilling)
                ace.DoStep(ACEngine.Step.Billing, true);
        }

        //TFS#54543 BY 2013-8-29
        //made the function overloading so that we can set the activitydate
        public void DoAutoAC(NextStep ns, ActivityConfig.ACSeriesRow asr, int revId, ACEngine.RevType revType)
        {
            DoAutoAC(ns, asr, revId, revType, DateTime.Today);
        }

        public void DoAutoAC(NextStep ns, ActivityConfig.ACSeriesRow asr, int revId, ACEngine.RevType revType, DateTime acDate)
        {
            try
            {
                if(ns==null)
                    AutoAC(null, asr, revId, revType, acDate, null,true);
                else
                    AutoAC(ns.prevAc, asr, revId, revType, acDate,ns.FlowQ,true);

                CurrentACE = null;

                FM.GetDocMng().DB.DocContent.AcceptChanges();
            }
            catch (Exception xx)
            {
                if (CurrentACE != null)
                    CurrentACE.Cancel();
                CurrentACE = null;

                throw xx;
            }
        }

    
        public void CreateAC(int acseriesId, DateTime acDate, string ctxTable, int ctxId, int revId, ACEngine.RevType revType)
        {
            //get context process
            atriumDB.ProcessRow pr = null;
            if (ctxTable != null)
            {
                foreach (atriumDB.ProcessContextRow pcr in FM.DB.ProcessContext)
                {
                    if (pcr.LinkTable == ctxTable && pcr.LinkId == ctxId)
                    {
                        pr = pcr.ProcessRow;
                        break;
                    }
                }
            }
            ActivityConfig.ACSeriesRow acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acseriesId);

            AcSeriesOKToAdd.Clear();
            Dictionary<int, atriumBE.CurrentFlow> activeProcesses = this.Workflow.NextSteps();
            
            Workflow.EnabledProcesses();
            Workflow.AvailableProcesses();

            if (AcSeriesOKToAdd.Contains(acsr))
            {
                //atriumDB.ActivityRow prevAc = null;
                NextStep ns = null;
                foreach (atriumBE.CurrentFlow ap in activeProcesses.Values)
                {
                    ns = LoadNextSteps(acseriesId, ap);
                    //test for process match
                    if (ns != null)
                    {
                        bool match = TestForProcessMatch(pr, ns.prevAc);

                        if (ns != null && ns.prevAc != null && match)
                            break;
                    }
                }

                if (ns==null || ns.prevAc == null)
                {
                    activeProcesses = this.Workflow.EnabledProcesses();
                    foreach (atriumBE.CurrentFlow ap in activeProcesses.Values)
                    {
                        ns = LoadNextSteps(acseriesId, ap);
                        if (ns != null)
                        {
                            bool match = TestForProcessMatch(pr, ns.prevAc);
                            if (ns != null && ns.prevAc != null && match)
                                break;
                        }
                    }
                }

                this.DoAutoAC(ns, acsr, revId, revType, acDate);
            }
            else
            {
                throw new AtriumException("You cannot perform this activity on this file");
            }
        }

        private static bool TestForProcessMatch(atriumDB.ProcessRow pr, atriumDB.ActivityRow prevAc)
        {
            bool match = true;
            if (prevAc == null)
                return match;
            if (pr != null)
            {
                match = false;
                if (pr.Thread.StartsWith(prevAc.ProcessRow.Thread) | prevAc.ProcessRow.Thread.StartsWith(pr.Thread))
                    match = true;
            }
            return match;
        }

        private static NextStep LoadNextSteps(int acseriesId, atriumBE.CurrentFlow ap)
        {
            NextStep prevAc = null;
            foreach (atriumBE.NextStep ns in ap.NextSteps.Values)
            {
                if (ns.acs.ACSeriesId == acseriesId)
                {
                    return ns;
                }
                if (ns.Children != null)
                    prevAc = LoadNextSteps(acseriesId, ns.Children);
            }
            return prevAc;
        }
    }

    public class ParentChildStep
    {
        public ActivityConfig.ACSeriesRow ParentStep;
        public ActivityConfig.SeriesRow ChildStep;
    }
}