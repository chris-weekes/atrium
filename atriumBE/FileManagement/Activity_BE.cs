using System;
using System.Data;
using System.Collections.Generic;
using atLogic;
using lmDatasets;
using atriumBE.Properties;


namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ActivityBE : atLogic.ObjectBE
    {
        FileManager myA;
        atriumDB.ActivityDataTable myActivityDT;

        bool ignoreActivityDateWarning = true;

        public bool IgnoreActivityDateWarning
        {
            get { return ignoreActivityDateWarning; }
            set { ignoreActivityDateWarning = value; }
        }

        private global::System.Object missing = global::System.Type.Missing;

        internal ActivityBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.Activity)
        {
            myA = pBEMng;
            myActivityDT = (atriumDB.ActivityDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetActivity();


        }
        public atriumDAL.ActivityDAL myDAL
        {
            get
            {
                return (atriumDAL.ActivityDAL)myODAL;
            }
        }

        public void Update(atLogic.BusinessProcess BP)
        {

            BP.AddForUpdate(myA.GetProcess());
            BP.AddForUpdate(myA.GetProcessContext());


            BP.AddForUpdate(myA.GetDocMng().GetDocContent());
            BP.AddForUpdate(myA.GetDocMng().GetDocument());

            BP.AddForUpdate(this);
            BP.AddForUpdate(myA.GetActivityTime());

            //2014-03-17 -- where to move the ActivityAttribution save?
            //BP.AddForUpdate(myA.GetActivityAttribution());

            BP.AddForUpdate(myA.GetDisbursement());
            //recipient was moved before activitybf to fix a problem on the bf list- the from was not showing immediately after importing mail
            BP.AddForUpdate(myA.GetDocMng().GetRecipient());
            BP.AddForUpdate(myA.GetActivityBF());

            BP.AddForUpdate(myA.GetDocMng().GetAttachment());


        }

        public atriumDB.ActivityRow Load(int ActivityId, bool refresh)
        {
            if (refresh)
                return _Load(ActivityId);
            else
            {
                atriumDB.ActivityRow ar = myA.DB.Activity.FindByActivityId(ActivityId);
                if (ar == null)
                    ar = _Load(ActivityId);

                return ar;
            }
        }
        public atriumDB.ActivityRow Load(int ActivityId)
        {
            return Load(ActivityId, false);
        }

        private atriumDB.ActivityRow _Load(int ActivityId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().Activity_Load(ActivityId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(ActivityId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(ActivityId));
                }
            }
            return myActivityDT.FindByActivityId(ActivityId);

        }


        public void DeepLoadByFileId(int fileId)
        {
            //isLoadedByFileId = true;
            if (myA.CurrentFile.RowState != DataRowState.Added)
            {
                DataSet ds = new atriumDB();
                if (myA.AtMng.AppMan.UseService)
                {
                    ds = atLogic.BEManager.DecompressDataSet(myA.AtMng.AppMan.AtriumX().LoadActivity(fileId, myA.AtMng.AppMan.AtriumXCon), ds);
                }
                else
                {
                    try
                    {
                        ds = atLogic.BEManager.DecompressDataSet(myDAL.DeepLoadByFileId(fileId, SerializationFormat.Binary), ds);
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        ds = atLogic.BEManager.DecompressDataSet(myDAL.DeepLoadByFileId(fileId, SerializationFormat.Binary), ds);
                    }
                }
                myA.GetProcess().Fill(ds.Tables["Process"]);
                myA.GetProcessContext().Fill(ds.Tables["ProcessContext"]);
                Fill(ds.Tables["Activity"]);
                myA.GetActivityBF().Fill(ds.Tables["ActivityBF"]);
                myA.GetActivityTime().Fill(ds.Tables["ActivityTime"]);
                myA.GetActivityTime().SetDisplayHours();
                myA.GetDisbursement().Fill(ds.Tables["Disbursement"]);
                myA.GetDisbursement().IncludeOnIRP();
                //
                //myA.GetActivityAttribution().Fill(ds.Tables["ActivityAttribution"]);

                myA.GetDocMng().GetRecipient().SyncActivity(myA.GetDocMng().DB.Recipient);
            }
        }




        public void LoadByProcessId(int processId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ActivityLoadByProcessId(processId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByProcessId(processId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByProcessId(processId));
                }
            }
        }





        protected override void BeforeAdd(DataRow row)
        {
            //atriumDB.ActivityRow dr = (atriumDB.ActivityRow)row;
            //if (!myA.CurrentFile.FileMetaTypeRow.AllowActivities & myA.CurrentFile.RowState != DataRowState.Added)
            //    throw new AtriumException(Resources.ActivityFileDoesNotAllowActivities);
        }
        protected override void AfterAdd(DataRow row)
        {
            atriumDB.ActivityRow dr = (atriumDB.ActivityRow)row;
            string ObjectName = this.myActivityDT.TableName;

            //			System.Diagnostics.Debug.WriteLine(dr["ActivityId"] + dr.RowState.ToString() );
            if (dr.IsNull("ActivityId") || dr.ActivityId != 0)
                dr.ActivityId = this.myA.AtMng.PKIDGet(ObjectName, 10);

            if (dr.IsFileIdNull())
                dr.FileId = myA.CurrentFile.FileId;

            dr.ActivityDate = DateTime.Today;
            dr.ActivityEntryDate = DateTime.UtcNow;
            dr.FailedToSend = false;

            dr.CurrentStep = 0;

            dr.OfficerId = myA.AtMng.WorkingAsOfficer.OfficerId;
            dr.OfficerCode = myA.AtMng.WorkingAsOfficer.OfficerCode;
            dr.OfficeId = myA.AtMng.WorkingAsOfficer.OfficeId;
            dr.OfficeCode = myA.AtMng.WorkingAsOfficer.OfficeRow.OfficeCode;


            dr.FileStatusCode = dr.EFileRow.StatusCode;


        }

        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            string ObjectName = this.myActivityDT.TableName;

            atriumDB.ActivityRow dr = (atriumDB.ActivityRow)ddr;

            //check bf edit rule
            switch (dc.ColumnName)
            {
                case ActivityFields.ActivityCodeID:
                case ActivityFields.ActivityComment:
                case ActivityFields.ActivityDate:
                case ActivityFields.OfficerId:
                    if (!CanEdit(dr))
                    {
                        if (this.myA.IsFieldChanged(dc, dr))
                            throw new AtriumException(Resources.ActivityCannotEditAnotherOffice);
                    }
                    break;
            }


            //check billing edit rule???

            //regular validation rules
            switch (dc.ColumnName)
            {
                case "ACSeriesId":
                    if (dr.IsACSeriesIdNull())
                        throw new RequiredException(Resources.ActivityActivityCodeID);
                    else if (!myA.CheckDomain(dr.ACSeriesId, myA.AtMng.acMng.DB.ACSeries))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Activity Code");
                    break;
                case "OfficeId":
                    if (dr.IsOfficeIdNull())
                        throw new RequiredException(dc.ColumnName);
                    else if (!myA.CheckDomain(dr.OfficeId, myA.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
                    break;

                case ActivityFields.ActivityCodeID:
                    if (dr.IsActivityCodeIDNull())
                        throw new RequiredException(Resources.ActivityActivityCodeID);
                    else
                    {
                        //check mandate instead

                        //if (dr.RowState==DataRowState.Added)
                        //{
                        //    if (myA.Codes("ActivityCodeFileType").Select("ActivityCodeID="+dr.ActivityCodeID.ToString()).Length==0)
                        //        myA.RaiseError((int)AtriumEnum.AppErrorCodes.CANoEntryInOfficeMod, dr.ActivityCode);
                        //    if (myA.Codes("ActivityCodeOfficeType").Select("ActivityCodeID="+dr.ActivityCodeID.ToString()).Length==0)
                        //        myA.RaiseError((int)AtriumEnum.AppErrorCodes.CANoEntryByOffices, dr.ActivityCode); // different error code
                        //}
                    }
                    break;
                case ActivityFields.ActivityDate:
                    if (dr.IsActivityDateNull())
                        throw new RequiredException(Resources.ActivityActivityDate);
                    myA.IsValidDate(Resources.ActivityActivityDate, dr.ActivityDate, false, DateTime.Today.AddYears(-40), DateTime.Today.AddYears(1), String.Format(Resources.ValidationXYearsAgo, 40), String.Format(Resources.ValidationXYearsFromToday, 1));

                    if (myA.AtMng.acMng.DB.ACSeries.FindByACSeriesId(dr.ACSeriesId).ActivityCodeRow.Communication & dr.ActivityDate < DateTime.Today)
                        throw new AtriumException("You cannot back-date communication activities.");

                    if (!IgnoreActivityDateWarning)
                        myA.IsWarningDate(Resources.ActivityDateWarning, dr.ActivityDate, false, DateTime.Today.AddYears(-1), DateTime.Today);
                    break;
                case ActivityFields.OfficerId:
                    if (dr.IsOfficerIdNull())
                        throw new RequiredException(Resources.ActivityOfficerId);
                    else if (!myA.CheckDomain(dr.OfficerId, myA.Codes("OfficerList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Officer List");
                    break;
                default:
                    break;
            }
        }
        public static System.DateTime AtriumDateAdd(System.DateTime date, string expression)
        {
            string sInterval = expression.Substring(expression.Length - 1).ToLower();
            int iNumber = Convert.ToInt32(expression.Substring(0, expression.Length - 1));

            if (sInterval == "m")
            {
                return date.AddMonths(iNumber);
            }
            else if (sInterval == "d")
            {
                return date.AddDays(iNumber);
            }
            else if (sInterval == "y")
            {
                return date.AddYears(iNumber);
            }
            else if (sInterval == "h")
            {
                return date.AddHours(iNumber);
            }
            else if (sInterval == "n")
            {
                return date.AddMinutes(iNumber);
            }
            else
            {
                throw new AtriumException(Resources.BFDateInvalid);
            }
        }

        public static System.DateTime CalculateBFDate(string strType, System.DateTime dateType, string BFDate)
        {
            string sInterval = BFDate.Substring(BFDate.Length - 1).ToLower();
            int iNumber = Convert.ToInt32(BFDate.Substring(strType.Length, BFDate.Length - strType.Length - 1));

            if (sInterval == "m")
            {
                return dateType.AddMonths(iNumber);
            }
            else if (sInterval == "d")
            {
                return dateType.AddDays(iNumber);
            }
            else if (sInterval == "y")
            {
                return dateType.AddYears(iNumber);
            }
            else
            {
                throw new AtriumException(Resources.BFDateInvalid);
            }
        }

        private bool CheckBFDate(string strType, string BFDate)
        {
            if (strType.Length > BFDate.Length)
                return false;
            else if (BFDate.ToUpper().Substring(0, strType.Length) == strType)
                return true;
            else
                return false;
        }


        public ActivityConfig.ACSeriesRow GetACSeriesRow(atriumDB.ActivityRow dr)
        {
            ActivityConfig.ACSeriesRow arc = null;

            if (!dr.IsACSeriesIdNull())
            {
                arc = (ActivityConfig.ACSeriesRow)this.myA.AtMng.acMng.DB.ACSeries.Select("ACSeriesID=" + dr.ACSeriesId.ToString())[0];
            }

            return arc;
        }

        internal bool AboutSameAccount(atriumDB.ActivityRow a1, atriumDB.ActivityRow a2)
        {
            //how to establish this
            //eg accounthistory to judgment
            if (a1.IsLinkTableNull() | a2.IsLinkTableNull())
                return false;

            if (myA.DB.Tables.Contains(a1.LinkTable) & myA.DB.Tables.Contains(a2.LinkTable))
            {
                DataTable dt1 = myA.DB.Tables[a1.LinkTable];
                atLogic.ObjectBE obe1 = myA.GetBEFromTable(dt1);
                List<int> accts1 = ((atLogic.ObjectBE)dt1.ExtendedProperties["BE"]).Accounts(a1.LinkID);

                DataTable dt2 = myA.DB.Tables[a2.LinkTable];
                atLogic.ObjectBE obe2 = myA.GetBEFromTable(dt2);
                List<int> accts2 = ((atLogic.ObjectBE)dt1.ExtendedProperties["BE"]).Accounts(a2.LinkID);

                foreach (int i in accts1)
                {
                    if (accts2.Contains(i))
                        return true;
                }

                return false;
            }
            else
                return false;
        }

        //public void MaintainBFDate(int linkId, string linkTable, string field, DateTime relDate)
        //{
        //    //find all liked activities
        //    //how to find the activity if the link table info is not there 
        //    //or if the ac is linked to the file
        //    //related field config data determines this

        //    //**** acbf.bfdate is of this form objectalias,fieldname
        //    AllowEdit = true;
        //    //find all acbf records that match
        //    ActivityConfig.ACBFRow[] acbfrs = (ActivityConfig.ACBFRow[])myA.AtMng.acMng.DB.ACBF.Select("BFDate like '" + linkTable + "%' and BFDate like '%" + field + "%'");
        //    foreach (ActivityConfig.ACBFRow acbfr in acbfrs)
        //    {
        //        atriumDB.ActivityBFRow[] abfrs = (atriumDB.ActivityBFRow[])myA.DB.ActivityBF.Select("Completed=false and ACBFId=" + acbfr.ACBFId.ToString());

        //        DateTime newBf;
        //        if (acbfr.BFDate.Contains(","))
        //        {
        //            string[] args = acbfr.BFDate.Split(',');
        //            newBf = AtriumDateAdd(relDate, args[2]);
        //        }
        //        else
        //            newBf = CalculateBFDate(field, relDate, acbfr.BFDate);

        //        if (newBf < DateTime.Today)
        //            newBf = DateTime.Today;

        //        foreach (atriumDB.ActivityBFRow abfr in abfrs)
        //        {
        //            atriumDB.ActivityRow ar = abfr.ActivityRow;
        //            bool inContext = false;
        //            foreach (atriumDB.ProcessContextRow pcr in ar.ProcessRow.GetProcessContextRows())
        //            {
        //                if (pcr.LinkTable == linkTable & pcr.LinkId == linkId)
        //                {
        //                    inContext = true;
        //                }
        //            }
        //            if (!ar.IsLinkTableNull() && ar.LinkTable == linkTable && ar.LinkID == linkId)  //best match
        //            {
        //                abfr.BFDate = newBf;
        //                abfr.InitialBFDate = abfr.BFDate;

        //            }
        //            else if (inContext) //check for process context match
        //            {
        //                abfr.BFDate = newBf;
        //                abfr.InitialBFDate = abfr.BFDate;
        //            }
        //            else if (ar.IsLinkTableNull()) //should this be allowed
        //            {
        //                abfr.BFDate = newBf;
        //                abfr.InitialBFDate = abfr.BFDate;

        //            }

        //        }
        //    }
        //    AllowEdit = false;


        //}


        private atriumDB.ActivityBFRow CreateBF(atriumDB.ActivityRow dr, ActivityConfig.ACDependencyRow acdr, Dictionary<int, ActivityConfig.ACBFRow> bfs)
        {
            int LP;

            ActivityConfig.ACBFRow arcb = (ActivityConfig.ACBFRow)myA.AtMng.acMng.DB.ACBF.Select("BFCODE='NEML'")[0];
            if (dr.ACSeriesId == myA.AtMng.GetSetting(AppIntSetting.OutOfOfficeNotification))
                arcb = (ActivityConfig.ACBFRow)myA.AtMng.acMng.DB.ACBF.Select("BFCODE='OUT'")[0];

            if (acdr != null)
                arcb = acdr.ACBFRow;

            //make sure we don't create the same bf more than once
            if (arcb != null && !bfs.ContainsKey(arcb.ACBFId))
            {
                bfs.Add(arcb.ACBFId, arcb);

                //add new activity bf record
                //atriumDB.ActivityBFRow arbf=this.myA.DB.ActivityBF.NewActivityBFRow();
                //arbf.ActivityId=dr.ActivityId;
                //this.myA.DB.ActivityBF.AddActivityBFRow(arbf);
                atriumDB.ActivityBFRow arbf = (atriumDB.ActivityBFRow)myA.GetActivityBF().Add(dr);

                arbf.BeginEdit();
                arbf.ACBFId = arcb.ACBFId;
                if (acdr != null)
                    arbf.ACDepId = acdr.ACDependencyId;

                if (!arcb.IsBFDateNull())
                {
                    if (arcb.BFDate.ToUpper() == "TODAY")
                    {
                        arbf.BFDate = DateTime.Today;

                    }
                    else if (arcb.BFDate.Contains(","))
                    {
                        //new syntax is objectalias,fieldname,expression
                        //eg  SSTCase0,ReceivedDate,+365d
                        string[] args = arcb.BFDate.Split(',');

                        ActivityBP abp = myA.CurrentActivityProcess;
                        if (abp.CurrentACE != null)
                        {
                            if (abp.CurrentACE.relTables.ContainsKey(args[0]))
                            {
                                arbf.BFDate = AtriumDateAdd((DateTime)abp.CurrentACE.relTables[args[0]][0].Row[args[1]], args[2]);
                                arbf.InitialBFDate = arbf.BFDate;
                            }
                            else
                            {
                                throw new AtriumException("Cannot calculate BF as related data is not loaded.");
                            }
                        }
                    }
                    else if (this.CheckBFDate("REQDUEDATE", arcb.BFDate))
                    {
                        ActivityBP abp = myA.CurrentActivityProcess;

                        if (abp.CurrentACE.relTables.ContainsKey("SSTRequest0"))
                        {
                            SST.SSTRequestRow sstr = (SST.SSTRequestRow)abp.CurrentACE.relTables["SSTRequest0"][0].Row;
                            arbf.BFDate = CalculateBFDate("REQDUEDATE", sstr.DueDate, arcb.BFDate);
                            arbf.InitialBFDate = arbf.BFDate;
                        }
                    }
                    else if (this.CheckBFDate("OPINIONDUEDATE", arcb.BFDate))
                    {
                        ActivityBP abp = myA.CurrentActivityProcess;

                        //if (!dr.IsLinkTableNull() && dr.LinkTable == "Opinion")
                        //{
                        if (abp.CurrentACE.relTables.ContainsKey("Opinion0"))
                        {
                            //                            atriumDB.OpinionRow drOp = this.myA.DB.Opinion.FindByOpinionId(dr.LinkID);
                            Advisory.OpinionRow drOp = (Advisory.OpinionRow)abp.CurrentACE.relTables["Opinion0"][0].Row;
                            arbf.BFDate = CalculateBFDate("OPINIONDUEDATE", drOp.DueDate, arcb.BFDate);
                            arbf.InitialBFDate = arbf.BFDate;
                        }

                    }
                    else if (this.CheckBFDate("PROVLPDATE", arcb.BFDate))
                    {
                        officeDB.OfficeRow drOffice = this.myA.AtMng.GetOffice(dr.OfficeId).CurrentOffice;
                        if (!drOffice.IsJudgmentLPNull())
                        {
                            LP = drOffice.JudgmentLP;
                        }
                        else
                            LP = 10;

                        arbf.BFDate = CalculateBFDate("PROVLPDATE", dr.ActivityDate.AddYears(LP), arcb.BFDate);
                    }
                    else if (this.CheckBFDate("WRITLPDATE", arcb.BFDate))
                    {
                        if (!dr.IsLinkTableNull() && dr.LinkTable == "Writ")
                        {
                            CLAS.WritRow drWrit = this.myA.GetCLASMng().DB.Writ.FindByWritID(dr.LinkID);
                            arbf.BFDate = CalculateBFDate("WRITLPDATE", drWrit.ExpiryDate, arcb.BFDate);
                        }
                    }
                    else if (this.CheckBFDate("CURRENTLPDATE", arcb.BFDate))
                    {
                        if (!dr.IsLinkTableNull())
                        {
                            if (dr.LinkTable == "Debt")
                            {
                                //atriumDB.AccountHistoryRow fhr =this.myA.DB.AccountHistory.FindByAccountHistoryId(dr.LinkID);
                                CLAS.DebtRow drDebt = this.myA.GetCLASMng().DB.Debt.FindByDebtId(dr.LinkID);
                                if (!drDebt.IsLPExpiresNull())
                                    arbf.BFDate = CalculateBFDate("CURRENTLPDATE", drDebt.LPExpires, arcb.BFDate);
                            }
                            if (dr.LinkTable == "AccountHistory")
                            {
                                CLAS.AccountHistoryRow fhr = this.myA.GetCLASMng().DB.AccountHistory.FindByAccountHistoryId(dr.LinkID);
                                CLAS.DebtRow drDebt = this.myA.GetCLASMng().DB.Debt.FindByDebtId(fhr.FileAccountID);
                                if (!drDebt.IsLPExpiresNull())
                                    arbf.BFDate = CalculateBFDate("CURRENTLPDATE", drDebt.LPExpires, arcb.BFDate);
                            }
                        }
                    }
                    else if (this.CheckBFDate("JUDGMENTLPDATE", arcb.BFDate))
                    {
                        if (!dr.IsLinkTableNull() && dr.LinkTable == "Judgment")
                        {
                            CLAS.JudgmentRow drJudg = this.myA.GetCLASMng().DB.Judgment.FindByJudgmentID(dr.LinkID);
                            arbf.BFDate = CalculateBFDate("JUDGMENTLPDATE", drJudg.JudgmentLPDate, arcb.BFDate);
                        }
                    }
                    else
                    {
                        arbf.BFDate = CalculateBFDate("", dr.ActivityDate, arcb.BFDate);
                    }

                    arbf.InitialBFDate = arbf.BFDate;
                }

                //if (!arcb.IsDefaultForOfficeNull())
                //{
                //    switch (arcb.DefaultForOffice.ToUpper())
                //    {
                //        case "OO":
                //            arbf.ForOfficeId = dr.EFileRow.OwnerOfficeId;
                //            break;
                //        case "LO":
                //            if(myA.AtMng.GetOffice(dr.EFileRow.LeadOfficeId).CurrentOffice.IsOnLine)
                //                arbf.ForOfficeId = dr.EFileRow.LeadOfficeId;
                //            else
                //                arbf.ForOfficeId = dr.EFileRow.OwnerOfficeId;
                //            break;
                //    }
                //}
                arbf.BFType = arcb.BFType;
                //if (myA.AtMng.OfficeLoggedOn.OfficerBF)
                //    arbf.BFType = arcb.BFType;
                //else
                //    arbf.BFType = 1;  //set to office type of bf

                if (arcb.IsRoleCodeNull())
                {
                    //set default rolecode for office on this file
                    //if we hit breakpoint on setting rolecode to PL (if it's still there), look into it. Why are we setting this rolecode to PL
                    if (arcb.BFType == 7)
                        arbf.RoleCode = "PL";
                }
                else
                {
                    if (!arcb.IsRoleCodeLeadNull() && myA.AtMng.WorkingAsOfficer.OfficeId == myA.CurrentFile.LeadOfficeId)
                        arbf.RoleCode = arcb.RoleCodeLead;
                    else
                        arbf.RoleCode = arcb.RoleCode;
                }
                //check to see if role is filled
                if (!arbf.IsRoleCodeNull())
                {
                    //add new column to acbf - leadofficerole
                    //in here if officeid == leadofficeid, use leadofficerole
                    // otherwise use owner role


                    if (myA.CheckDomain(arbf.RoleCode, myA.Codes("RoleCode")))
                    {
                        //global roles
                        //we aren't checking for global roles yet
                    }
                    else
                    {
                        //file based role
                        atriumDB.FileContactRow fcr = myA.GetFileContact().GetByRole(arbf.RoleCode);
                        if (fcr == null)
                            myA.RaiseWarning(WarningLevel.Display, String.Format("The role, {0}, does not exist on this file.", arbf.RoleCode), myA.AtMng.AppMan.AppName);
                    }
                }

                arbf.isMail = arcb.isMail;
                arbf.EndEdit();
                return arbf;
            }
            else
                return null;

        }

        internal ActivityConfig.ACSeriesRow FindParentStepForAutoComplete(atriumDB.ActivityRow acr)
        {

            if (acr.ProcessRow.IsTriggerACSeriesIdNull())
                return null;
            else
            {
                //atriumDB.ActivityRow ar = myActivityDT.FindByActivityId(acr.ProcessRow.FirstActivityId);
                ActivityConfig.ACSeriesRow acsr = this.myA.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acr.ProcessRow.TriggerACSeriesId);
                return acsr;
            }
        }
        internal ActivityConfig.ACSeriesRow FindParentStep(atriumDB.ActivityRow acr)
        {

            if (acr.ProcessRow.IsFirstActivityIdNull())
                return null;
            else
            {

                ActivityConfig.ACSeriesRow acsr = this.myA.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acr.ProcessRow.FirstActivityId);
                atriumDB.ProcessRow pr = acr.ProcessRow;

                //to handle popping through multiple parent processes
                while (acsr.GetACDependencyRowsByNextSteps().Length == 0)
                {
                    //get my parent process
                    string thread = "";

                    thread = pr.Thread.Substring(0, pr.Thread.LastIndexOf("-"));

                    DataRow[] prs;// = myA.DB.Process.Select("Thread='" + thread + "' and SeriesId=" + acsr.SeriesId.ToString());
                    //need to handle intervening processes
                    do
                    {
                        prs = myA.DB.Process.Select("Thread='" + thread + "' and SeriesId=" + acsr.SeriesId.ToString());
                        if (prs.Length > 0)
                            break;
                        if (thread.LastIndexOf("-") == -1)
                            return null;
                        thread = thread.Substring(0, thread.LastIndexOf("-"));
                    } while (true);


                    pr = (atriumDB.ProcessRow)prs[0];
                    if (pr.IsFirstActivityIdNull())
                        return null;

                    acsr = this.myA.AtMng.acMng.DB.ACSeries.FindByACSeriesId(pr.FirstActivityId);
                }
                return acsr;
            }
            //*****not used
            ////alternative solution would be to drill back through previous activityids - not a good idea because of ad hoc entry
            ////find parent process
            ////needs to be recursive?


            //atriumDB.ProcessRow[] prs=(atriumDB.ProcessRow[]) myA.DB.Process.Select("'"+ acr.ProcessRow.Thread + "' Like Thread +'-%'","Thread desc");
            //foreach (atriumDB.ProcessRow pr in prs)
            //{
            //    foreach (atriumDB.ActivityRow ar in pr.GetActivityRows())
            //    {
            //        ActivityConfig.ACSeriesRow acsr = this.myA.AtMng.acMng.DB.ACSeries.FindByACSeriesId(ar.ACSeriesId);
            //        foreach (ActivityConfig.ACDependencyRow acdr in acsr.GetACDependencyRowsByNextSteps())
            //        {
            //            if (acdr.ACSeriesRowByPreviousSteps.StepType == (int)StepType.Subseries)
            //            {
            //                //compare subseriesid on acseries row?  will this help
            //                //this must be it
            //                if(acdr.ACSeriesRowByPreviousSteps.SubseriesId==acr.ProcessRow.SeriesId)
            //                    return acdr.ACSeriesRowByPreviousSteps;
            //            }
            //        }
            //    }
            //}
            //return null;

        }

        public atriumDB.ddEntityRow GetCurrentCaseStatus()
        {


            //activityid is required in the sort to differentiate between records entered in the same minute
            atriumDB.ddEntityRow[] ars = (atriumDB.ddEntityRow[])myA.GetddEntity("FileCaseStatus").myDT.Select("", "EntryDate desc,Id desc");
            if (ars.Length > 0)
                return ars[0];
            else
                return null;

        }

        public atriumDB.ActivityRow GetCurrentCaseStatus(DateTime cutOff)
        {


            //activityid is required in the sort to differentiate between records entered in the same minute
            atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])myActivityDT.Select("CasestatusId is not null and ActivityEntryDate<=#" + cutOff.ToString("yyyy-MM-dd") + "#", "ActivityEntryDate desc,ActivityId desc");
            if (ars.Length > 0)
                return ars[0];
            else
                return null;

        }
        public void CalculateBF(atriumDB.ActivityRow dr, bool forConvert, bool imported)
        {
            Dictionary<int, ActivityConfig.ACBFRow> bfs = new Dictionary<int, ActivityConfig.ACBFRow>();

            if (!dr.IsACSeriesIdNull())
            {
                this.myA.GetActivityBF();

                //all ac config data should be  loaded at startup
                ActivityConfig.ACSeriesRow acsr = GetACSeriesRow(dr);
                ActivityConfig.ActivityCodeRow arc = acsr.ActivityCodeRow;

                ActivityConfig.ACDependencyRow[] acds = (ActivityConfig.ACDependencyRow[])myA.AtMng.acMng.DB.ACDependency.Select("LinkType not in (99) and ACBFId is not null and CurrentStepID=" + acsr.ACSeriesId.ToString());
                if (acds.Length == 0)
                {
                    //check to see if we are a sub-series?
                    ActivityConfig.ACSeriesRow acss = FindParentStep(dr);
                    //TFS 83015 cjw 2014-12-12
                    //check to see if the series on the process matches the series on the step
                    //if they don't match it is because it is a special communication step o-mail,email, reply
                    //that is getting added to the process
                    //it should not trigger any bfs as if we were coming into the process
                    if (acss != null & !acsr.NoResurface & acsr.SeriesId == dr.ProcessRow.SeriesId)
                    {
                        foreach (ActivityConfig.ACDependencyRow acdr in acss.GetACDependencyRowsByNextSteps())
                        {
                            //CJW 2015-5-8  added the check against obsolete to fix the problem with coming out of SA01 in GP01
                            if (acdr.ACBFRow != null && acdr.LinkType != (int)ConnectorType.Obsolete)
                            {
                                CreateBF(dr, acdr, bfs);
                            }
                        }
                    }
                }
                else
                {
                    foreach (ActivityConfig.ACDependencyRow acdr in acsr.GetACDependencyRowsByNextSteps())
                    {
                        if (acdr.ACBFRow != null && acdr.LinkType != (int)ConnectorType.Obsolete)
                        {
                            //if (!acdr.ACBFRow.IsDefaultBFOfficerNull())
                            //{
                            //    switch (acdr.ACBFRow.DefaultBFOfficer.ToUpper())
                            //    {
                            //        case "USER":
                            //            atriumDB.ActivityBFRow arbf1 = CreateBF(dr, acdr, bfs);
                            //            if (arbf1 != null)
                            //                arbf1.BFOfficerID = this.myA.AtMng.WorkingAsOfficer.OfficerId;
                            //            break;
                            //        default:
                            //            CreateBF(dr, acdr, bfs);
                            //            break;
                            //    }
                            //}
                            //else
                            //{
                            atriumDB.ActivityBFRow abfr = CreateBF(dr, acdr, bfs);
                            //}
                        }
                        else
                        {
                            ActivityConfig.ACSeriesRow acBR = acdr.ACSeriesRowByPreviousSteps;
                            if (acBR.StepType == (int)StepType.Branch)
                            {
                                foreach (ActivityConfig.ACDependencyRow acdrB in acBR.GetACDependencyRowsByNextSteps())
                                {
                                    if (acdrB.ACBFRow != null)
                                    {
                                        CreateBF(dr, acdrB, bfs);
                                    }
                                }

                            }

                        }
                    }
                }
                if (GetACSeriesRow(dr).ActivityCodeRow.Communication & !forConvert)
                    CalculateRecipBF(dr, imported);
            }
        }

        public void CalculateRecipBF(atriumDB.ActivityRow dr, bool imported)
        {
            Dictionary<int, ActivityConfig.ACBFRow> bfs = new Dictionary<int, ActivityConfig.ACBFRow>();

            if (!dr.IsACSeriesIdNull())
            {
                this.myA.GetActivityBF();
                ActivityConfig.ACBFRow neml = (ActivityConfig.ACBFRow)myA.AtMng.acMng.DB.ACBF.Select("BFCODE='NEML'")[0];
                if (dr.ACSeriesId == myA.AtMng.GetSetting(AppIntSetting.OutOfOfficeNotification))
                    neml = (ActivityConfig.ACBFRow)myA.AtMng.acMng.DB.ACBF.Select("BFCODE='OUT'")[0];

                //all ac config data should be  loaded at startup
                if (!dr.IsDocIdNull())
                {
                    docDB.DocumentRow[] doc = (docDB.DocumentRow[])myA.GetDocMng().DB.Document.Select("DocId=" + dr.DocId.ToString());

                    List<int> officers = new List<int>();
                    //init list with all NEML BFs to prevent dups
                    foreach (atriumDB.ActivityBFRow abfr in dr.GetActivityBFRows())
                    {
                        if (abfr.ACBFId == neml.ACBFId && !abfr.IsBFOfficerIDNull())
                        {
                            officers.Add(abfr.BFOfficerID);
                        }
                    }
                    foreach (docDB.RecipientRow rr in doc[0].GetRecipientRows())
                    {
                        //add bf for each recip with officerid
                        if (!rr.IsOfficerIdNull() && !rr.IsOfficeIdNull() && (rr.Type != "0" | imported))
                        {
                            //get officer and make sure they can receive bfs and haven't already got one for this ac
                            officeDB.OfficerRow orr = myA.AtMng.OfficeMng.GetOfficer().FindLoad(rr.OfficerId);
                            if (orr != null && orr.IsMail && !orr.IsActiveNull() && orr.Active && !officers.Contains(orr.OfficerId))
                            {
                                CreateSingleBF(dr, imported, bfs, neml, officers, rr.OfficerId);
                            }
                        }
                        //else if (!rr.IsOfficeIdNull() && rr.Type != "0")
                        //{
                        //    atriumDB.ActivityBFRow arbf = CreateBF(dr, null, bfs);
                        //    if (arbf != null)
                        //    {
                        //        bfs.Remove(neml.ACBFId);

                    //        arbf.ForOfficeId = rr.OfficeId;
                        //        arbf.BFType = 1;
                        //    }

                    //}
                        else if (!rr.IsListIdNull() && rr.Type != "0")
                        {
                            //TODO:need to move this bit to a function as it needs to be recursive
                            //get listmembers
                            BFFromLawmateList(dr, bfs, neml, rr.ListId, officers, imported);

                        }
                        else if (rr.Type != "0" | imported)
                        {
                            //check to see if it is an email distribution list
                            //if it is create bfs for all members of the distrib list that are in lawmate
                            //recurse though nested lists


                            try
                            {
                                Redemption.RDOSession session = DocumentBE.RDOSession();
                                session.Logon(missing, missing, missing, missing, missing, missing);
                                Redemption.RDOAddressEntry dl = session.AddressBook.ResolveName(rr.Address, false, missing);
                                Redemption.RDOAddressEntries members = dl.Members;
                                if (members != null)
                                {
                                    BFFromExchangeList(dr, bfs, neml, members, officers, imported);
                                }
                            }
                            catch (Exception xra)
                            {
                                //ignore
                            }
                        }
                    }
                    if (imported)
                    {
                        if (dr.GetActivityBFRows().Length == 0)
                        {
                            //if there are no bfs at all created on for the WorkingAsOfficer
                            CreateSingleBF(dr, imported, bfs, neml, officers, myA.AtMng.WorkingAsOfficer.OfficerId);
                        }
                        //if the workingas did not get a bf give them one anyway
                        bool ok = false;
                        foreach (atriumDB.ActivityBFRow newbf in dr.GetActivityBFRows())
                        {
                            if (newbf.BFOfficerID == myA.AtMng.WorkingAsOfficer.OfficerId)
                            {
                                if (newbf.Completed)
                                    newbf.Completed = false;
                                ok = true;
                            }
                            else if (!newbf.Completed & newbf.BFOfficerID == myA.AtMng.OfficerLoggedOn.OfficerId)
                            {
                                if (newbf.Completed)
                                    newbf.Completed = false;
                                ok = true;
                            }
                        }
                        if (!ok)
                        {
                            CreateSingleBF(dr, imported, bfs, neml, officers, myA.AtMng.WorkingAsOfficer.OfficerId);
                        }
                    }
                }
            }
        }

        public void CreateBFsForFiling(atriumDB.ActivityRow dr, ActivityConfig.ACBFRow acbf, List<int> bfofficers)
        {
            Dictionary<int, ActivityConfig.ACBFRow> bfs = new Dictionary<int, ActivityConfig.ACBFRow>();
            List<int> officers = new List<int>();

            foreach (int officerId in bfofficers)
            {
                CreateSingleBF(dr, false, bfs, acbf, officers, officerId);
            }
        }
        private void CreateSingleBF(atriumDB.ActivityRow dr, bool imported, Dictionary<int, ActivityConfig.ACBFRow> bfs, ActivityConfig.ACBFRow neml, List<int> officers, int officerId)
        {
            atriumDB.ActivityBFRow arbf = CreateBF(dr, null, bfs);
            officers.Add(officerId);
            if (arbf != null)
            {
                bfs.Remove(neml.ACBFId);

                arbf.BFOfficerID = officerId;
                if (imported & officerId != myA.AtMng.WorkingAsOfficer.OfficerId)
                {
                    //when importing only create bfs for working as officer
                    arbf.Completed = true;
                    arbf.BFDate = DateTime.Today;
                    arbf.InitialBFDate = arbf.BFDate;
                }
                else if (imported)
                {
                    arbf.BFDate = DateTime.Today;
                    arbf.InitialBFDate = arbf.BFDate;
                }
            }

        }

        private void BFFromLawmateList(atriumDB.ActivityRow dr, Dictionary<int, ActivityConfig.ACBFRow> bfs, ActivityConfig.ACBFRow neml, int listId, List<int> officers, bool imported)
        {
            appDB.ListRow lr = myA.AtMng.DB.List.FindByListId(listId);
            //create a bf for every list member
            foreach (appDB.ListMemberRow lmr in lr.GetListMemberRows())
            {
                if (!lmr.IsMemberListIdNull())
                {
                    BFFromLawmateList(dr, bfs, neml, lmr.MemberListId, officers, imported);
                }
                else
                {
                    if (!officers.Contains(lmr.ContactId))
                    {
                        CreateSingleBF(dr, imported, bfs, neml, officers, lmr.ContactId);
                        //atriumDB.ActivityBFRow arbf = CreateBF(dr, null, bfs);
                        //if (arbf != null)
                        //{
                        //    bfs.Remove(neml.ACBFId);

                        //    arbf.BFOfficerID = lmr.ContactId;
                        //}
                    }
                }
            }
        }

        private void BFFromExchangeList(atriumDB.ActivityRow dr, Dictionary<int, ActivityConfig.ACBFRow> bfs, ActivityConfig.ACBFRow neml, Redemption.RDOAddressEntries members, List<int> officers, bool imported)
        {
            foreach (Redemption.RDOAddressEntry addr in members)
            {
                //add bf
                //resolve officer from recipient
                if (addr.Members != null && addr.Members.Count > 0)
                {
                    BFFromExchangeList(dr, bfs, neml, addr.Members, officers, imported);
                }
                else
                {
                    string ade = addr.SMTPAddress;
                    if (ade != null)
                    {
                        officeDB.OfficerRow or = myA.AtMng.OfficeMng.GetOfficer().LoadByEmail(ade);
                        if (or != null && !officers.Contains(or.OfficerId))
                        {

                            CreateSingleBF(dr, imported, bfs, neml, officers, or.OfficerId);
                            //atriumDB.ActivityBFRow arbf = CreateBF(dr, null, bfs);
                            //if (arbf != null)
                            //{
                            //    bfs.Remove(neml.ACBFId);

                            //    arbf.BFOfficerID = or.OfficerId;
                            //}

                        }
                    }
                }
            }
        }

        protected override void AfterUpdate(DataRow row)
        {

            atriumDB.ActivityRow dr = (atriumDB.ActivityRow)row;

        }


        protected override void BeforeUpdate(DataRow row)
        {
            atriumDB.ActivityRow dr = (atriumDB.ActivityRow)row;
            if (!this.myA.EFile.IsFileReceived())
            {
                throw new AtriumException(Resources.FileNotReceived);
            }

            if (dr.RowState == DataRowState.Added)
            {

                myA.GetActivityBF().AutoCompleteBFs(dr);

                if (!myA.CurrentFile.IsOpponentIDNull())
                {
                    //set dim1id as casestatusid for CLAS
                    if (!dr.IsCaseStatusIdNull())
                        myA.CurrentFile.Dim1Id = dr.CaseStatusId;

                    foreach (CLAS.DebtRow dar in myA.GetCLASMng().DB.Debt)
                    {
                        if (dar.ActiveWithJustice)
                        {
                            CLAS.ActivityAttributionRow aar = (CLAS.ActivityAttributionRow)myA.GetCLASMng().GetActivityAttribution().Add(dr);
                            aar.ActivityID = dr.ActivityId;
                            aar.FileAccountID = dar.DebtId;
                            aar.PercentAlloc = dar.PercentAlloc;
                        }
                    }
                }
            }

            myA.GetProcess().SetActive(dr.ProcessRow);
            if (!CanEdit(dr))
                throw new AtriumException(Resources.ActivityCannotEditAnotherOffice);

            this.BeforeChange(ActivityFields.ActivityCodeID, dr);
            if (dr.IsActivityDateNull())
                throw new RequiredException(Resources.ActivityActivityDate);
            this.BeforeChange(ActivityFields.OfficerId, dr);

        }

        public void DeleteRelatedCA(int fileId, string linkTable, int linkId)
        {
            //  LoadByFileId(fileId);
            DataRow[] dra = this.myActivityDT.Select("LinkTable='" + linkTable + "' and LinkID=" + linkId);
            foreach (DataRow dr in dra)
            {
                //				this.myActivityDT.RemoveActivityRow((atriumDB.ActivityRow)dr);
                //dr.Delete();
            }

        }


        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {

            string ObjectName = this.myActivityDT.TableName;

            atriumDB.ActivityRow dr = (atriumDB.ActivityRow)ddr;
            switch (dc.ColumnName)
            {
                case "DocId":
                    if (dr.IsDocIdNull())
                        dr.SendType = "";
                    break;
                case ActivityFields.ActivityCodeID:
                    ActivityConfig.ACSeriesRow arc = GetACSeriesRow(dr);
                    if (dr.RowState == DataRowState.Added)
                    {
                        dr.ActivityNameEng = arc.ActivityCodeRow.ActivityNameEng + "-" + arc.DescEng;
                        dr.ActivityNameFre = arc.ActivityCodeRow.ActivityNameFre + "-" + arc.DescFre;
                        dr.EndEdit();

                    }
                    break;
                default:
                    break;
            }
        }

        protected override void BeforeDelete(System.Data.DataRow row)
        {
            atriumDB.ActivityRow dr = (atriumDB.ActivityRow)row;
            //ctivityConfig.ActivityCodeRow arc = GetActivityCodeRow(dr);

       

            ActivityConfig.ACBFRow neml = (ActivityConfig.ACBFRow)myA.AtMng.acMng.DB.ACBF.Select("BFCODE='NEML'")[0];
            ActivityConfig.ACBFRow outo = (ActivityConfig.ACBFRow)myA.AtMng.acMng.DB.ACBF.Select("BFCODE='OUT'")[0];
            foreach (atriumDB.ActivityBFRow abr in dr.GetActivityBFRows())
            {
                if (abr.ACBFId != ActivityBFBE.USERBFID && abr.ACBFId != neml.ACBFId && abr.ACBFId != outo.ACBFId)
                {
                    //check to see if bf is a "next step" bf
                    if (!abr.IsACDepIdNull())
                    {
                        lmDatasets.ActivityConfig.ACDependencyRow acdr = myA.AtMng.acMng.DB.ACDependency.FindByACDependencyId(abr.ACDepId);
                        if (acdr.LinkType != (int)ConnectorType.BFOnly)
                        {
                            bool canOverride = myA.AtMng.SecurityManager.CanOverride(dr.FileId, atSecurity.SecurityManager.Features.Activity) == atSecurity.SecurityManager.ExPermissions.Yes;
                            if (!canOverride)
                                throw new AtriumException("You cannot delete an activity that is part of a process.");
                        }
                    }
                }
            }
            if (dr.GetActivityTimeRows().Length > 0)
            {
                foreach (atriumDB.ActivityTimeRow atr in dr.GetActivityTimeRows())
                {
                    if (!myA.GetActivityTime().CanDelete(atr))
                        throw new AtriumException(Resources.ActivityTimeNoDeleteCommitted);
                }
            }
            if (dr.GetDisbursementRows().Length > 0)
            {
                foreach (atriumDB.DisbursementRow atr in dr.GetDisbursementRows())
                {
                    if (!myA.GetDisbursement().CanDelete(atr))
                        throw new AtriumException(Resources.ActivityNoDelWithDisb);
                }
            }
            if (!CanDelete(dr, myA.CurrentFileId))
                throw new AtriumException(Resources.ActivityNoDelOtherOffice);

            //if there is an assoc document check to see if it can be deleted
            if (!dr.IsDocIdNull())
            {
                myA.GetDocMng().GetDocument().Delete(dr.DocId, dr, null);
            }

        }


        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[] { this.myA.CurrentFile };
        //}

        public void ConvertAC(atriumDB.ActivityRow ar, ActivityConfig.ACSeriesRow acsr)
        {
            ConvertAC(ar, acsr, false);
        }
        public void ConvertAC(atriumDB.ActivityRow ar, ActivityConfig.ACSeriesRow acsr, bool forRevert)
        {
            //check to see if it is allowed
            if (ar.ACSeriesId == acsr.ACSeriesId)
                return;

            if (forRevert)
            {

                foreach (atriumDB.ActivityBFRow abr in ar.GetActivityBFRows())
                {
                    if (!abr.IsACDepIdNull())
                    {
                        ActivityConfig.ACDependencyRow acdr = myA.AtMng.acMng.DB.ACDependency.FindByACDependencyId(abr.ACDepId);
                        if (acdr.ACSeriesRowByNextSteps.ACSeriesId == ar.ACSeriesId)
                        {
                            if (abr.Completed)//check to see if next step has been done
                            {
                                throw new AtriumException("You cannot revert this activity since the next activity has already been done.");
                            }

                            //remove bfs related to current acseries
                            abr.ACBFId = ActivityBFBE.USERBFID;//fake the id to bypass the delete rule
                            abr.Delete();
                            abr.RowError = "";
                        }
                    }
                }

            }

            //Load process
            myA.GetProcess().Load(ar.ProcessId);

            //change activity
            ar.ActivityCodeID = acsr.ActivityCodeID;
            ar.ACSeriesId = acsr.ACSeriesId;
            ar.StepCode = acsr.StepCode;
            CalculateBF(ar, true, false);

            //complete BFs
            myA.GetActivityBF().AutoCompleteBFs(ar);

            //change process
            ar.ProcessRow.SeriesId = acsr.SeriesId;

            if (!ar.IsLinkTableNull() && ar.LinkTable == "Document")
            {
                string friendly = ACEngine.GetPromptText(myA.GetDocMng().DB.Document.FindByDocId(ar.DocId));
                ar.ProcessRow.NameE = ACEngine.Truncate(String.Format(acsr.SeriesRow.NameFormatE, friendly), 256);
                ar.ProcessRow.NameF = ACEngine.Truncate(String.Format(acsr.SeriesRow.NameFormatF, friendly), 256);
            }
            else
            {
                ar.ProcessRow.NameE = acsr.SeriesRow.SeriesDescEng;
                ar.ProcessRow.NameF = acsr.SeriesRow.SeriesDescFre;
            }
            ar.ProcessRow.Active = true;
            ar.ProcessRow.Thread = ar.ProcessId.ToString();

        }

        public void DeleteActivityXrefs(atriumDB.ActivityXRefRow[] ars)
        {
            throw new Exception("Delete Activity Cross-Reference Not Implemented");
        }

        public void Move(atriumDB.ActivityRow[] ars, int toFileId)
        {
            Move(ars, toFileId, false);
        }
        public void Move(atriumDB.ActivityRow[] ars, int toFileId, bool allowWFMove)
        {

            //the incoming activities must already be loaded in the target fm db
            myA.InitActivityProcess();
            FileManager toFM = myA.AtMng.GetFile(toFileId);

            //check activities
            foreach (atriumDB.ActivityRow ar in ars)
            {
                if (ar.ProcessRow == null)
                {
                    myA.GetProcess().Load(ar.ProcessId);
 //todo                   myA.GetProcessContext().LoadByProcessId(ar.ProcessId);
                }
                if (!CheckMove(ar, allowWFMove))
                {
                    throw new AtriumException(Properties.Resources.CantMoveWorkflowActivities);
                }

                if (ar.FileId == toFileId)
                {
                    return;// throw new AtriumException("You are trying to move an activity to the same file");
                }
            }

            //move or create processes
            Dictionary<int, int> processCount = new Dictionary<int, int>();
            foreach (atriumDB.ActivityRow ar in ars)
            {
                if (processCount.ContainsKey(ar.ProcessId))
                {
                    processCount[ar.ProcessId]++;
                }
                else
                    processCount.Add(ar.ProcessId, 1);
            }
            foreach (int procid in processCount.Keys)
            {
                atriumDB.ProcessRow pr = myA.DB.Process.FindByProcessId(procid);

                //need to check permissions on target file
                if (!toFM.GetProcess().CanAdd(toFM.CurrentFile))
                    throw new AtriumException(Properties.Resources.YouNeedAddProcessPermissionOnTheDestinationFile);


                myA.GetProcess().CheckMove(pr);


                ////this needs to be here
                //myA.GetActivity().LoadByProcessId(procid);

                atriumDB.ProcessRow newPr = null;
                int oldFileid = pr.FileId;
                bool moveProc = false;

                //if we are moving all the activities on a process then move the process
                //mke sure the process and activities are loaded in the original file - this is not the case when converting on the bf list
                if (processCount[procid] == myA.AtMng.GetFile(oldFileid).DB.Process.FindByProcessId(pr.ProcessId).GetActivityRows().Length)
                {
                    pr.FileId = toFileId;
                    pr.Thread = pr.ProcessId.ToString();
                    moveProc = true;

                    //move process context records too
                    foreach (atriumDB.ProcessContextRow pcr in pr.GetProcessContextRows())
                    {
                        pcr.FileId = toFileId;
                    }

                }
                else //else create a new one 
                {
                    newPr = (atriumDB.ProcessRow)myA.GetProcess().Add(myA.CurrentFile);

                    newPr.Active = pr.Active;
                    //newPr.CurrentStep = pr.CurrentStep;
                    newPr.NameE = pr.NameE;
                    newPr.NameF = pr.NameF;
                    newPr.SeriesId = pr.SeriesId;

                }

                foreach (atriumDB.ActivityRow ar in ars)
                {
                    if (ar.ProcessId == procid)
                    {

                        _Move(ar, toFileId);

                        if (newPr != null) //why is this after move?
                            ar.ProcessId = newPr.ProcessId;
                    }
                }

                if (moveProc)
                {
                    FileManager fmOld = myA.AtMng.GetFile(oldFileid);
                    atriumDB.ProcessRow prOld = fmOld.DB.Process.FindByProcessId(pr.ProcessId);
                    if (prOld != null)
                    {
                        prOld.Delete();
                        prOld.AcceptChanges();
                    }
                }


            }
        }

        /// <summary>
        /// Moves an activity to another file
        /// </summary>
        /// <param name="ar">Activity to move</param>
        /// <param name="toFile">Target file</param>
        internal void _Move(atriumDB.ActivityRow ar, int toFileId)
        {
            AllowEdit = true;

            //need to check permissions on current activity
            //if (myA.CurrentFileId == toFileId)
            //{
            //    CheckMove(ar,false);
            //}
            //else
            //{
            //    if (!CanDelete(ar, myA.CurrentFileId))
            //        throw new AtriumException(Resources.YouNeedDeletePermissionOnTheActivityToMoveIt);
            //}


            //need to check permissions on target file
            FileManager toFM = myA.AtMng.GetFile(toFileId);

            //check meta type on target file
            //if (!toFM.CurrentFile.FileMetaTypeRow.AllowActivities)
            //    throw new AtriumException(Resources.ActivityFileDoesNotAllowActivities);

            if (!toFM.GetActivity().CanAdd(toFM.CurrentFile))
                throw new AtriumException(Resources.YouNeedAddActivityPermissionOnTheDestinationFile);



            //sept 23 2009
            //don't check anymore
            //check linktable
            //if (!ar.IsLinkTableNull())
            //{
            //    switch (ar.LinkTable)
            //    {
            //        case "Document":
            //        case "Activity":
            //        case "Disbursement":
            //        case "ActivityTime":
            //            //ok
            //            break;
            //        default:
            //            throw new AtriumException(Resources.YouCanTMoveAnActivityWithRelatedInfo);
            //    }
            //}

            int oldFileid = ar.FileId;

            //move all dependent items
            ar.FileId = toFileId;

            //nov 10 2010
            //need to remove ac from original fm
            FileManager fmOld = myA.AtMng.GetFile(oldFileid);
            //assume for now that the ac is loaded or how would we be moving it
            //actually it only needs to be  done if they are loaded
            atriumDB.ActivityRow arOld = fmOld.DB.Activity.FindByActivityId(ar.ActivityId);
            if (arOld != null)
            {
                //need to do the same with activitytime and disbursements
                //as they get cascade deleted in the dataset
                foreach (atriumDB.ActivityTimeRow atrold in arOld.GetActivityTimeRows())
                {
                    atrold.Delete();
                    atrold.AcceptChanges();
                }
                foreach (atriumDB.DisbursementRow drold in arOld.GetDisbursementRows())
                {
                    drold.Delete();
                    drold.AcceptChanges();
                }
                foreach (atriumDB.ActivityBFRow abrold in arOld.GetActivityBFRows())
                {
                    abrold.Delete();
                    abrold.AcceptChanges();
                }
                arOld.Delete();
                arOld.AcceptChanges();
            }

            //sept 23 2009
            //clear these when moving ac
            ar.SetLinkIDNull();
            ar.SetLinkTableNull();

            if (ar.IsXrefIdNull())
            {
                //load data
                myA.GetActivityBF().LoadByActivityId(ar.ActivityId);
                foreach (atriumDB.ActivityBFRow atr in ar.GetActivityBFRows())
                {
                    atr.FileId = toFileId;
                }
                myA.GetActivityTime().LoadByActivityId(ar.ActivityId);
                foreach (atriumDB.ActivityTimeRow atr in ar.GetActivityTimeRows())
                {
                    atr.FileId = toFileId;
                }
                myA.GetDisbursement().LoadByActivityId(ar.ActivityId);
                foreach (atriumDB.DisbursementRow atr in ar.GetDisbursementRows())
                {
                    atr.FileID = toFileId;
                }
                if (!ar.IsDocIdNull())
                {
                    DocManager dm = myA.GetDocMng();
                    docDB.DocumentRow dr = dm.GetDocument().Load(ar.DocId);

                    //load recips for use by rel fields
                    //dm.GetRecipient().LoadByDocId(ar.DocId);

                    if (dr.FileId == oldFileid)
                    {
                        dr.FileId = toFileId;

                        docDB.DocumentRow docOld = fmOld.GetDocMng().DB.Document.FindByDocId(dr.DocId);
                        if (docOld != null)
                        {
                            docOld.Delete();
                            docOld.AcceptChanges();
                        }
                        //dm.GetAttachment().LoadByMsgId(ar.DocId);
                        foreach (docDB.AttachmentRow att in dr.GetAttachmentRowsByDocument_Attachment())
                        {
                            docDB.DocumentRow dr1 = dm.DB.Document.FindByDocId(att.AttachmentId);
                            //only move it if it has no matching activity. ie it is a floater

                            if (dr1.FileId == oldFileid && fmOld.DB.Activity.Select("Docid=" + dr1.DocId.ToString()).Length == 0)
                            {
                                dr1.FileId = toFileId;

                                docDB.DocumentRow docOld1 = fmOld.GetDocMng().DB.Document.FindByDocId(dr1.DocId);
                                if (docOld1 != null)
                                {
                                    docOld1.FileId = toFileId;
                                    docOld1.AcceptChanges();
                                    fmOld.GetDocMng().GetDocument().Cancel();
                                }
                            }
                        }
                        fmOld.GetDocMng().DB.AcceptChanges();
                        fmOld.GetDocMng().GetDocument().Cancel();

                    }
                }
            }
            AllowEdit = false;

        }
        public bool CanMove(atriumDB.ActivityRow ar)
        {
            try
            {
                return CheckMove(ar, false);

            }
            catch (Exception x)
            {
                return false;
            }
        }
        public bool CheckMove(atriumDB.ActivityRow ar, bool allowWFMove)
        {

            if (ar.IsXrefIdNull())
            {
                if (!CanDelete(ar, ar.FileId))
                {
                    return false;
                    //throw new AtriumException(Resources.YouNeedDeletePermissionOnTheActivityToMoveIt);

                }
                ActivityConfig.SeriesRow sr = myA.AtMng.acMng.DB.Series.FindBySeriesId(ar.ProcessRow.SeriesId);
                if (!sr.AllowMove & !allowWFMove)
                {
                    if (myA.AtMng.acMng.GetSeries().SeriesContainsStep(sr.SeriesId, ar.ACSeriesId))
                    {
                        //can't move define workflow steps
                        //throw new AtriumException(Properties.Resources.CantMoveWorkflowActivities);
                        return false;
                    }
                }
                myA.GetProcess().CheckMove(ar.ProcessRow);
            }
            else
            {
                int fid = myA.GetActivityXRef().Load(ar.XrefId).FileId;
                if (!CanDelete(ar, fid))
                {
                    //return false;
                    throw new AtriumException(Resources.YouNeedDeletePermissionOnTheActivityToMoveIt);
                }

            }
            return true;

        }
        public bool CanDelete(atriumDB.ActivityRow dr, int fileId)
        {

            bool ok = false;
            if (!dr.IsXrefIdNull())
            {
                ok = true;
            }

            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fileId, atSecurity.SecurityManager.Features.Activity);
            switch (perm)
            {
                case atSecurity.SecurityManager.LevelPermissions.All:
                    ok = true;
                    break;
                case atSecurity.SecurityManager.LevelPermissions.Mine:
                    if (dr.OfficerId == myA.AtMng.OfficerLoggedOn.OfficerId)
                        ok = true;
                    else if (dr.OfficerId == myA.AtMng.WorkingAsOfficer.OfficerId)
                        ok = true;

                    break;
                case atSecurity.SecurityManager.LevelPermissions.MyOffice:
                    if (dr.OfficeId == myA.AtMng.OfficerLoggedOn.OfficeId)
                        ok = true;
                    else if (dr.HasVersion(DataRowVersion.Original) && (myA.AtMng.OfficeLoggedOn.OfficeId == dr.EFileRow.OwnerOfficeId) && (DateTime.Compare(DateTime.Parse(dr["ActivityEntryDate", DataRowVersion.Original].ToString()), DateTime.Parse("2000/10/1")) < 0))
                    {
                        ok = true;
                    }
                    break;
                case atSecurity.SecurityManager.LevelPermissions.No:
                    ok = false;
                    break;
                default:
                    ok = false;
                    break;
            }
            return ok;

        }
        public override bool CanDelete(DataRow row)
        {
            atriumDB.ActivityRow dr = (atriumDB.ActivityRow)row;
            return CanDelete(dr, dr.FileId);
        }
        public override bool CanAdd(DataRow parent)
        {
            atriumDB.EFileRow er = (atriumDB.EFileRow)parent;
            if (er.RowState == DataRowState.Added)
                return true;

            if (!myA.CurrentFile.FileMetaTypeRow.AllowActivities & myA.CurrentFile.RowState != DataRowState.Added)
                return false;

            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(er.FileId, atSecurity.SecurityManager.Features.Activity) > atSecurity.SecurityManager.ExPermissions.No;
        }

        public override bool CanEdit(DataRow ddr)
        {
            try
            {
                if (ddr == null)
                    return true;
                atriumDB.ActivityRow dr = (atriumDB.ActivityRow)ddr;

                //make read-only if the activity does not relate to the current file
                if (!myA.IsVirtualFM && dr.FileId != myA.CurrentFile.FileId)
                    return false | AllowEdit;

                if (dr.EFileRow.RowState == DataRowState.Added)
                    return true;

                bool ok = false;
                if (dr.RowState != DataRowState.Added)
                {
                    atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(dr.FileId, atSecurity.SecurityManager.Features.Activity);
                    switch (perm)
                    {
                        case atSecurity.SecurityManager.LevelPermissions.All:
                            ok = true;
                            break;
                        case atSecurity.SecurityManager.LevelPermissions.Mine:
                            if (dr.OfficerId == myA.AtMng.OfficerLoggedOn.OfficerId)
                                ok = true;
                            else if (dr.OfficerId == myA.AtMng.WorkingAsOfficer.OfficerId)
                                ok = true;

                            break;
                        case atSecurity.SecurityManager.LevelPermissions.MyOffice:
                            if (dr.OfficeId == myA.AtMng.OfficerLoggedOn.OfficeId)
                                ok = true;
                            else if (dr.HasVersion(DataRowVersion.Original) && (myA.AtMng.OfficeLoggedOn.OfficeId == dr.EFileRow.OwnerOfficeId) && (DateTime.Compare(DateTime.Parse(dr["ActivityEntryDate", DataRowVersion.Original].ToString()), DateTime.Parse("2000/10/1")) < 0))
                            {
                                ok = true;
                            }
                            break;
                        case atSecurity.SecurityManager.LevelPermissions.No:
                            ok = false;
                            break;
                        default:
                            ok = false;
                            break;
                    }
                    //ok = myA.AtMng.SecurityManager.CanUpdate(dr.FileId, atSecurity.SecurityManager.Features.Activity) > atSecurity.SecurityManager.LevelPermissions.No;
                }
                else
                    ok = true;
                return ok | AllowEdit;
            }
            catch
            {
                return false;
            }


        }
    }
}

/*
namespace Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class ActivityTest
	{
		atriumBE.atriumManager atmng;
		public ActivityTest()
		{}

		[SetUp]public void Init()
		{
			atmng=new atriumBE.atriumManager("week.c","doucette","JZ0","E");
			atmng.GetFile(40015);
			atmng.GetActivity();
		}

		[TearDown]public void Dispose()
		{
			atmng=null;
		}

		[Test]public void Load()
		{
			atmng.GetActivity().LoadByFileId(atmng.CurrentFile.FileId);
		 
		}
		[Test]public void UpdateOtherOffice()
		{
			atmng.GetActivity().LoadByFileId(atmng.CurrentFile.FileId);
			atriumBE.atriumDB.ActivityRow ar=atmng.DB.Activity.FindByActivityId(4796918);
			ar.BeginEdit();
			ar.ActivityComment="Something stupid";
			ar.EndEdit();
			atmng.GetActivity().Update();
			
		}

		[Test]public void Add()
		{
			atriumBE.atriumDB.ActivityRow ar=(atriumBE.atriumDB.ActivityRow)atmng.GetActivity().Add(atmng.CurrentFile);
			ar.BeginEdit();
			ar.ActivityCode="999";
			ar.ActivityComment="test";
			atmng.GetActivity().FixLookups(ar);
			ar.EndEdit();
			atmng.GetActivity().Update();
			atmng.Commit();
		 
		}
	}
}
*/