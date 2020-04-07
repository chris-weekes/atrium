using System;
using System.Data;
using atLogic;
using lmDatasets;
using atriumBE.Properties;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ActivityBFBE : atLogic.ObjectBE
    {
        public static int USERBFID = -1;
        FileManager myA;
        atriumDB.ActivityBFDataTable myActivityBFDT;

        internal ActivityBFBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.ActivityBF)
        {
            myA = pBEMng;
            myActivityBFDT = (atriumDB.ActivityBFDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetActivityBF();
        }
        public atriumDAL.ActivityBFDAL myDAL
        {
            get
            {
                return (atriumDAL.ActivityBFDAL)myODAL;
            }
        }

        public void LoadCompleted(int officerId, DateTime fromDtate, DateTime toDate)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ActivityBFLoadCompleted(officerId, fromDtate, toDate, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByCompleted(officerId, fromDtate, toDate));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByCompleted(officerId, fromDtate, toDate));
                }
            }

        }

        //DateTime myLastEdit = new DateTime(1900, 1, 1);
        Int64 myLastTS;
        public int LoadBF(int officeId, int officerID, DateTime date, bool refresh)
        {
            if (refresh)
            {
                //                myLastEdit = new DateTime(1900, 1, 1);
                myLastTS = 0;
                //myDAL.PreRefresh();
            }
            else
            {
                //  myA.AtMng.LogMessage(String.Format("RefreshBF {0} {1}", myA.IsVirtualFM, myA.CurrentFileId));
            }


            if (myActivityBFDT.Rows.Count > 0)
            {
                myLastTS = (Int64)myActivityBFDT.Select("", "ver desc")[0]["ver"];
            }

            
            int i;
            DataSet ds;
            if (myA.AtMng.AppMan.UseService)
                ds = BEManager.DecompressDataSet(myA.AtMng.AppMan.AtriumX().ActivityBFLoadBF(officeId, officerID, date, myA.AtMng.OfficeLoggedOn.OfficerBF, myLastTS, myA.AtMng.AppMan.AtriumXCon), new atriumDB());
            else
            {
                //to fix two threads using connection at same time
                atriumDAL.ActivityBFDAL abdal = myDAL;
                if(!refresh)
                {
                    atriumDAL.atriumDALManager adm = new atriumDAL.atriumDALManager( myA.AtMng.AppMan.myUser,myA.AtMng.AppMan.myPwd,myA.AtMng.AppMan.Connect);
                    abdal = adm.GetActivityBF();
                }
                try
                {
                    ds = atLogic.BEManager.DecompressDataSet(abdal.LoadBF(officeId, officerID, date, myA.AtMng.OfficeLoggedOn.OfficerBF, myLastTS), new atriumDB());
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    ds = atLogic.BEManager.DecompressDataSet(myDAL.LoadBF(officeId, officerID, date, myA.AtMng.OfficeLoggedOn.OfficerBF, myLastTS), new atriumDB());
                }

            }
            i = ds.Tables["ACtivityBF"].Rows.Count;
            Fill(ds.Tables["ActivityBF"]);

            return i;

        }

        public atriumDB.ActivityBFRow Load(int ActivityBFId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ActivityBFLoad(ActivityBFId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(ActivityBFId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(ActivityBFId));
                }
            }
            return myActivityBFDT.FindByActivityBFId(ActivityBFId);
        }


        public void LoadByActivityId(int ActivityId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ActivityBFLoadByActivityId(ActivityId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByActivityId(ActivityId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByActivityId(ActivityId));
                }
            }
        }


        protected override void AfterAdd(DataRow dr)
        {
            atriumDB.ActivityBFRow abf = (atriumDB.ActivityBFRow)dr;
            string ObjectName = this.myActivityBFDT.TableName;

            abf.ActivityBFId = this.myA.AtMng.PKIDGet(ObjectName, 10);

            abf.FileId = abf.ActivityRow.FileId;
            abf.ACBFId = USERBFID;
            ActivityConfig.ACBFRow acbr = myA.AtMng.acMng.DB.ACBF.FindByACBFId(abf.ACBFId);

            if (!abf.ActivityRow.IsBFPriorityNull())
            {
                abf.Priority = abf.ActivityRow.BFPriority;
            }
            else
            {
                abf.Priority = 0;
            }

            abf.BFType = acbr.BFType;
            switch (abf.BFType)
            {
                case 2: //Direct
                    abf.BFOfficerID = myA.AtMng.WorkingAsOfficer.OfficerId;
                    break;
                case 7: //Role
                case 5: // Roles
                    abf.RoleCode = acbr.RoleCode;
                    break;
            }


            // if (abf.IsNull("Completed"))
            abf.Completed = false;

            //if (abf.IsNull("isRead"))
            abf.isRead = false;

            //if (abf.IsBFDateNull())
            abf.BFDate = DateTime.Today;
            abf.InitialBFDate = abf.BFDate;
            abf.ManuallyCompleted = false;
            abf.isMail = acbr.isMail;
            abf.MonitorIncomplete = acbr.MonitorIncomplete;


        }

        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            atriumDB.ActivityBFRow dr = (atriumDB.ActivityBFRow)ddr;
            switch (dc.ColumnName)
            {
                case "Completed":
                case "Priority":
                case "isRead":
                case "BFComment":
                case "BFDate":
                    if (dr.RowState != DataRowState.Added && !CanEditBF(dr))
                        throw new ReadOnlyException();
                    break;
            }

            switch (dc.ColumnName)
            {
                case "ManuallyCompleted":
                    //only allow manual completion for user and mail bfs that are marked as allow manual complete
                    ActivityConfig.ACBFRow neml = (ActivityConfig.ACBFRow)myA.AtMng.acMng.DB.ACBF.FindByACBFId(dr.ACBFId);
                    if (neml.AllowManualComplete)
                    { //ok
                    }
                    else
                    {
                        //   if(dr.ManuallyCompleted)
                        bool canOverride = myA.AtMng.SecurityManager.CanOverride(dr.FileId, atSecurity.SecurityManager.Features.ActivityBF) == atSecurity.SecurityManager.ExPermissions.Yes;
                        if (!canOverride)
                            throw new AtriumException("You cannot manually complete this type of BF.");
                    }

                    break;
                case "BFType":
                    if (dr.IsBFTypeNull())
                        throw new RequiredException(dc.ColumnName);
                    else if (!myA.CheckDomain(dr.BFType, myA.Codes("BFType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, "BF Type", "Activity BF", "BF Type");
                    break;
                case "ACBFId":
                    if (!myA.CheckDomain(dr.ACBFId, myA.AtMng.acMng.DB.ACBF))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "ACBF");
                    break;
                case "ForOfficeId":
                    if (!myA.CheckDomain(dr.ForOfficeId, myA.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office List");
                    break;

                case ActivityFields.BFOfficerID:
                    if (!dr.IsBFOfficerIDNull())
                    {
                        if (!myA.CheckDomain(dr.BFOfficerID, myA.Codes("OfficerList")))
                            throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Officer List");
                    }
                    break;
                //case ActivityBFFields.ForOfficeId:
                //    if (!myA.AtMng.GetOffice(dr.ForOfficeId).CurrentOffice.IsOnLine)
                //        throw new AtriumException(Resources.ActivityBFCannotBeCreatedForAnOffLineOffice);
                //    break;
                case ActivityFields.BFDate:
                    if (dr.IsBFDateNull())
                        throw new RequiredException(ActivityFields.BFDate);
                    if (!dr.IsBFDateNull())
                        myA.IsValidDate(Resources.ActivityBFBFDate, dr.BFDate, true, DebtorBE.CSLBegin, DateTime.Today.AddYears(30), Resources.ValidationCSLBegin, Resources.ValidationThirtyYearsLater);
                    break;

            }
        }
        public bool IsDirect(atriumDB.ActivityBFRow abr)
        {

            if (abr.IsisMailNull())
                return false;

            if (abr.isMail)
                return true;
            if (abr.BFType == 2 || abr.BFType == 8)
                return true;
            if (abr.BFType == 7)
            {
                if ((!abr.IsRoleCodeNull() && abr.RoleCode.Substring(0, 1) == "F") || myA.AtMng.GetSetting(AppBoolSetting.FileBFRead))
                    return true;

                if ((!abr.IsRoleCodeNull() && abr.RoleCode.Substring(0, 1) == "G") || myA.AtMng.GetSetting(AppBoolSetting.RoleBFRead))
                    return true;

            }
            return false;
        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            atriumDB.ActivityBFRow dr = (atriumDB.ActivityBFRow)row;
            switch (dc.ColumnName)
            {
                case ActivityFields.Completed:
                    //if (dr.Completed && dr.isMail && dr.isRead == false)
                    //JLL: 2018-07-19 removed ismail flag. mark as read whenever it's completed.
                    if (dr.Completed && dr.isRead == false)
                        dr.isRead = true;

                    if (dr.Completed)
                    {
                        dr.CompletedByID = this.myA.AtMng.WorkingAsOfficer.OfficerId;
                        dr.CompletedDate = DateTime.Now;
                    }
                    else
                    {
                        dr.SetCompletedByIDNull();
                        dr.SetCompletedDateNull();
                    }

                    dr.EndEdit();
                    break;
                case "BFType":
                    switch (dr.BFType)
                    {
                        //case 1: //Office BFs
                        //    dr.SetBFOfficerIDNull();
                        //    dr.SetRoleCodeNull();
                        //    dr.ForOfficeId = myA.AtMng.OfficeLoggedOn.OfficeId;
                        //    break;

                        case 2: //Direct - wipe out Role; update ForOfficeId to LoggedOnOffice
                            dr.BFOfficerID = myA.AtMng.WorkingAsOfficer.OfficerId;
                            dr.SetRoleCodeNull();
                            //dr.ForOfficeId = myA.AtMng.OfficeLoggedOn.OfficeId;
                            break;

                        case 7: //Roles
                            dr.SetBFOfficerIDNull();
                            dr.SetRoleCodeNull();
                            //dr.ForOfficeId = myA.AtMng.OfficeLoggedOn.OfficeId;
                            break;
                        case 8: //Recipient
                            //JLL: 2009/07/27 Handling of proper diarizing without FILE - e.g. LA09.04
                            if (dr.ActivityRow.IsDocIdNull())
                                throw new Exception("Workflow is not configured properly.  Please contact an administrator.  \n\nError: Cannot use BF Type Recipient without a document");
                            else
                            {
                                docDB.DocumentRow docr = myA.GetDocMng().DB.Document.FindByDocId(dr.ActivityRow.DocId);
                                //if (docr.GetRecipientRows().Length == 0)
                                //    myA.GetDocMng().GetRecipient().LoadByDocId(docr.DocId);
                                bool notfound = true;
                                foreach (docDB.RecipientRow rr in docr.GetRecipientRows())
                                {
                                    if (rr.Type == "1")
                                        if (!rr.IsOfficerIdNull())
                                        {
                                            dr.BFOfficerID = rr.OfficerId;
                                            notfound = false;
                                        }
                                }
                                if (notfound)
                                    throw new Exception("Workflow is not configured properly.  Please contact an administrator.  \n\nError: Cannot use BF Type Recipient without an officer as the document \"To\" recipient");
                            }
                            break;
                    }
                    break;
            }
        }


        protected override void BeforeDelete(DataRow row)
        {
            if (!CanDelete(row))
                throw new AtriumException(Resources.ActivityNoDelOtherOffice);

            if (!myA.IsVirtualFM)
                myA.AtMng.SyncBF((atriumDB.ActivityBFRow)row, false, true);
        }


        protected override void BeforeUpdate(DataRow ddr)
        {
            atriumDB.ActivityBFRow dr = (atriumDB.ActivityBFRow)ddr;
            if (dr.ActivityRow != null)
                myA.GetProcess().SetActive(dr.ActivityRow.ProcessRow);

            AllowEdit = true;
            BeforeChange("BFDate", ddr);
            AllowEdit = false;

        }

        protected override void AfterUpdate(DataRow ddr)
        {
            atriumDB.ActivityBFRow dr = (atriumDB.ActivityBFRow)ddr;
            ActivityConfig.ACBFRow arc = myA.AtMng.acMng.DB.ACBF.FindByACBFId(dr.ACBFId);
            myA.AtMng.SyncBF(dr, myA.IsVirtualFM, false);

        }

        public override bool CanDelete(DataRow row)
        {
            atriumDB.ActivityBFRow dr = (atriumDB.ActivityBFRow)row;

            if (myA.IsVirtualFM)
                return true;

            if (dr.ACBFId != USERBFID)
            {
                return false;

            }
            //if (myA.AtMng.OfficeLoggedOn.OfficeId == dr.ForOfficeId)
            //{ return true; }
            //else 

            if (dr.HasVersion(DataRowVersion.Original) && myA.AtMng.WorkingAsOfficer.OfficerId.ToString() == dr["BFOfficerID", DataRowVersion.Original].ToString())
                return true;
            else if (!dr.HasVersion(DataRowVersion.Original) && myA.AtMng.WorkingAsOfficer.OfficerId.ToString() == dr["BFOfficerID"].ToString())
                return true;
            else
            {
                //if (dr.HasVersion(DataRowVersion.Original) && !dr.IsNull(dr.Table.Columns[ActivityFields.BFOfficerID],DataRowVersion.Original))
                //{
                //    DataRow odr;
                //    odr = this.myA.AtMng.officeMng.DB.Officer.Select("officerId=" + dr["BFOfficerID",DataRowVersion.Original])[0];
                //    if (odr == null)
                //    {
                //        throw new AtriumException(Resources.ActivityNoDelOtherOffice);
                //    }
                //}
                //else
                //{
                return false | AllowDelete;
                //}
            }
        }
        public bool CanEditBF(DataRow ddr)
        {
            atriumDB.ActivityBFRow dr = (atriumDB.ActivityBFRow)ddr;
            if (!myA.IsVirtualFM && dr.FileId != myA.CurrentFile.FileId)
                return false;
            if (dr.ActivityRow != null && dr.ActivityRow.EFileRow.RowState == DataRowState.Added)
                return true;

            bool ok = myA.AtMng.SecurityManager.CanUpdate(dr.FileId, atSecurity.SecurityManager.Features.ActivityBF) > atSecurity.SecurityManager.LevelPermissions.No;

            if (!ok)
                return ok;

            //fixed!!!!
            if (!dr.IsRoleCodeNull())
            {
                if (myA.IsVirtualFM)
                    ok = true;
                else
                {
                    ok = false;
                    if ((myA.AtMng.OfficeMng.GetOfficer().IsInRole(dr.RoleCode) || myA.GetFileContact().IsInRole(dr.RoleCode)))
                    {
                        //ok to keep
                        ok = true;
                    }
                    else
                    {
                        //check buddies
                        foreach (lmDatasets.officeDB.OfficerDelegateRow odr in myA.AtMng.OfficerLoggedOn.GetOfficerDelegateRowsByOfficerWorkAs())
                        {
                            if (odr.AccessLevel == 1 & (myA.AtMng.OfficeMng.GetOfficer().IsInRole(dr.RoleCode, odr.OfficerId) || myA.GetFileContact().IsInRole(dr.RoleCode, odr.OfficerId)))
                            {
                                ok = true;
                            }
                        }
                    }
                }

            }
            else if (!dr.IsBFOfficerIDNull())
            {
                ok = false;

                //ok to keep
                if (dr.BFOfficerID == myA.AtMng.WorkingAsOfficer.OfficerId)
                    ok = true;
                else
                {
                    //check buddies
                    foreach (lmDatasets.officeDB.OfficerDelegateRow odr in myA.AtMng.OfficerLoggedOn.GetOfficerDelegateRowsByOfficerWorkAs())
                    {
                        if (odr.AccessLevel == 1 & odr.OfficerId == dr.BFOfficerID)
                        {
                            ok = true;
                        }
                    }

                }

            }
            else
            {
                ok = false;
            }

            //if they have override permission let them edit
            //override is used to override manual completes as well
            bool canOverride = myA.AtMng.SecurityManager.CanOverride(dr.FileId, atSecurity.SecurityManager.Features.ActivityBF) == atSecurity.SecurityManager.ExPermissions.Yes;

            return ok | AllowEdit | canOverride;

            //old incomplete code follows 
            //kept in case there is a bug above

            //if (myA.AtMng.OfficeLoggedOn.OfficeId == dr.ForOfficeId)
            //{ }
            //else 
            if (!dr.IsRoleCodeNull() && (myA.AtMng.OfficeMng.GetOfficer().IsInRole(dr.RoleCode) | myA.GetFileContact().IsInRole(dr.RoleCode)))
            { }
            else if (dr.HasVersion(DataRowVersion.Original) && this.myA.AtMng.WorkingAsOfficer.OfficerId.ToString() == dr["BFOfficerID", DataRowVersion.Original].ToString())
            { }
            else
            {
                DataColumn dc = dr.Table.Columns["BFOfficerID"];
                if (dr.HasVersion(DataRowVersion.Original) && !dr.IsNull(dc, DataRowVersion.Original))
                {
                    if (this.myA.AtMng.OfficeMng.DB.Officer.FindByOfficerId(dr.BFOfficerID) != null)
                    {
                    }
                    else
                    {
                        ok = false;
                        //this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.CACannotEditAnotherOffice);
                    }
                }
                else
                {
                    ok = false;
                    //this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.CACannotEditAnotherOffice);
                }
            }
            return ok | AllowEdit;
        }

        //public override void FixLookups(System.Data.DataRow ddr)
        //{
        //    atriumDB.ActivityBFRow dr = (atriumDB.ActivityBFRow)ddr;

        //    OfficerBE ofr = this.myA.AtMng.OfficeMng.GetOfficer();


        //    if (!dr.IsBFOfficerCodeNull())
        //        dr.BFOfficerID = ofr.LookupId(dr.BFOfficerCode);
        //    else
        //        dr.SetBFOfficerIDNull();


        //}

        public void AutoCompleteBFs(atriumDB.ActivityRow newAC)
        {
            //this.myA..AppMan.ExecuteSP("ActivityAutoComplete", dr.FileId, dr.OfficerId, dr.ActivityDate, dr.ActivityCodeID);
            if (newAC.ACSeriesId == myA.AtMng.GetSetting(AppIntSetting.OutOfOfficeNotification))
                return;

            stackLimit = 0;
            if (!newAC.IsACSeriesIdNull())
            {
                ActivityConfig.ACSeriesRow acsr = this.myA.AtMng.acMng.DB.ACSeries.FindByACSeriesId(newAC.ACSeriesId);
                AutoCompleteBFs(newAC, acsr);
            }
        }


        int stackLimit = 0;
        private void AutoCompleteBFs(atriumDB.ActivityRow newAC, ActivityConfig.ACSeriesRow acsr)
        {
            stackLimit++;
            if (stackLimit < 9)
            {
                //if (acsr.GetACDependencyRowsByPreviousSteps().Length == 0)
                if (myA.AtMng.acMng.DB.ACDependency.Select("LinkType in (0,4,8,9)  and NextStepId=" + acsr.ACSeriesId.ToString()).Length == 0)
                {
                    ActivityConfig.ACSeriesRow acss = null;
                    //check to see if we are a sub-series?
                    if (newAC.ACSeriesId == acsr.ACSeriesId)
                    {
                        //use this when we are starting to follow the thread back
                        acss = myA.GetActivity().FindParentStepForAutoComplete(newAC);
                    }
                    else
                    {
                        //we have popped into a process without hitting a step
                        //this used to cause a stack overflow
                        //use the acsr to find a parent that has been done
                        //problem is that the process might have multiple references
                        //throw new AtriumException("Workflow is trying to connect through a sub-process without recording a step");
                        //do it anyways so we can handle nr and questions in same series
                        acss = myA.GetActivity().FindParentStepForAutoComplete(newAC);
                    }
                    if (acss != null && acsr.ACSeriesId != acss.ACSeriesId)
                        AutoCompleteBFs(newAC, acss);
                }

                //     else
                //     {
                //loop through previous steps and determine what this one completes
                foreach (ActivityConfig.ACDependencyRow acdr in acsr.GetACDependencyRowsByPreviousSteps())
                {
                    if ((StepType)acdr.ACSeriesRowByNextSteps.StepType == StepType.Decision | (StepType)acdr.ACSeriesRowByNextSteps.StepType == StepType.Merge | (StepType)acdr.ACSeriesRowByNextSteps.StepType == StepType.NonRecorded)// | (StepType)acdr.ACSeriesRowByNextSteps.StepType == StepType.Branch | (StepType)acdr.ACSeriesRowByNextSteps.StepType == StepType.Merge)
                    {
                        //don't recurse over obsolete links
                        if (acdr.LinkType != (int)ConnectorType.Obsolete)
                            AutoCompleteBFs(newAC, acdr.ACSeriesRowByNextSteps);
                    }
                    else if (!acdr.IsNextStepIdNull() & !acdr.IsACBFIdNull())
                    {
                        //find bf and complete
                        foreach (atriumDB.ActivityBFRow abr in this.myA.DB.ActivityBF.Select("Completed=0 and fileid=" + newAC.FileId.ToString()))
                        {
                            //changed on april 27 2009
                            //if ((!abr.IsACDepIdNull() && abr.ACDepId == acxdr.ACDependencyId) | abr.ActivityRow.ACSeriesId==acdr.CurrentStepId)
                            bool standardTest = (!abr.IsACDepIdNull() && abr.ACDepId == acdr.ACDependencyId);
                            bool versionTest = (!abr.IsACDepIdNull() && !acdr.IsOldACDepIdNull() && abr.ACDepId == acdr.OldACDepId);

                            bool oldversionTest = false;
                            if (!standardTest & !versionTest & abr.ActivityRow!=null)
                                oldversionTest = (abr.ActivityRow.ACSeriesId == acdr.CurrentStepId && !abr.IsBFCodeNull() && abr.BFCode == acdr.ACBFRow.BFCode && acdr.NextStepId == newAC.ACSeriesId);
                                // JLL commented out my fix as per TFS 3943
                                //oldversionTest = (abr.ActivityRow != null && abr.ActivityRow.ACSeriesId == acdr.CurrentStepId && !abr.IsBFCodeNull() && abr.BFCode == acdr.ACBFRow.BFCode && acdr.NextStepId == newAC.ACSeriesId);

                            if (standardTest || versionTest || oldversionTest)
                            {
                                //don't complete yourself!
                                if (newAC.ActivityId != abr.ActivityId)
                                {
                                    AllowEdit = true;
                                    //must be in same process or parent process
                                    if (newAC.ProcessRow.Thread.StartsWith(abr.ActivityRow.ProcessRow.Thread))
                                    {
                                        abr.Completed = true;
                                    }
                                    else if (abr.ActivityRow.ProcessRow.Thread.StartsWith(newAC.ProcessRow.Thread)) //or child process!
                                    {
                                        abr.Completed = true;
                                    }
                                    else if (myA.AtMng.acMng.DB.Series.FindBySeriesId(abr.ActivityRow.ProcessRow.SeriesId).SingleInstancePerFile || myA.AtMng.acMng.DB.Series.FindBySeriesId(abr.ActivityRow.ProcessRow.SeriesId).OncePerFile)
                                    {
                                        abr.Completed = true;
                                    }
                                    else if (myA.GetActivity().AboutSameAccount(newAC, abr.ActivityRow)) //there is a relationship between associated objects
                                    {
                                        abr.Completed = true;

                                    }
                                    else if (acdr.ACBFRow.AllowManualComplete & acdr.LinkType == (int)ConnectorType.BFOnly)//phase 1 for CLAS!
                                    {
                                        abr.Completed = true;
                                    }
                                    AllowEdit = false;
                                }
                            }
                        }

                    }
                    //else if (!acdr.IsNextStepIdNull() & acdr.LinkType==(int)ConnectorType.Transfer & acdr.IsACBFIdNull())
                    //{
                    //    if (!newAC.IsPreviousActivityIdNull())
                    //    {
                    //        atriumDB.ActivityRow preva = myA.DB.Activity.FindByActivityId(newAC.PreviousActivityId);

                    //        //don't kill your own process
                    //        if(newAC.ProcessId!=preva.ProcessId)
                    //            myA.GetActivityBF().CompleteAllOnProcess(preva.ProcessRow,newAC.ProcessId);
                    //    }
                    //}

                }
            }
            //  }
            stackLimit--;

        }
        public void MaintainBFDate(int linkId, string linkTable, string field, DateTime relDate)
        {
            //find all liked activities
            //how to find the activity if the link table info is not there 
            //or if the ac is linked to the file
            //related field config data determines this

            //**** acbf.bfdate is of this form objectalias,fieldname
            AllowEdit = true;
            //find all acbf records that match
            ActivityConfig.ACBFRow[] acbfrs = (ActivityConfig.ACBFRow[])myA.AtMng.acMng.DB.ACBF.Select("BFDate like '" + linkTable + "%' and BFDate like '%" + field + "%'");
            foreach (ActivityConfig.ACBFRow acbfr in acbfrs)
            {
                atriumDB.ActivityBFRow[] abfrs = (atriumDB.ActivityBFRow[])myA.DB.ActivityBF.Select("Completed=false and ACBFId=" + acbfr.ACBFId.ToString());

                DateTime newBf;
                if (acbfr.BFDate.Contains(","))
                {
                    string[] args = acbfr.BFDate.Split(',');
                    newBf = ActivityBE.AtriumDateAdd(relDate, args[2]);
                }
                else
                    newBf = ActivityBE.CalculateBFDate(field, relDate, acbfr.BFDate);

                if (newBf < DateTime.Today)
                    newBf = DateTime.Today;

                foreach (atriumDB.ActivityBFRow abfr in abfrs)
                {
                    atriumDB.ActivityRow ar = abfr.ActivityRow;
                    bool inContext = false;
                    foreach (atriumDB.ProcessContextRow pcr in ar.ProcessRow.GetProcessContextRows())
                    {
                        if (pcr.LinkTable == linkTable & pcr.LinkId == linkId)
                        {
                            inContext = true;
                        }
                    }
                    if (!ar.IsLinkTableNull() && ar.LinkTable == linkTable && ar.LinkID == linkId)  //best match
                    {
                        abfr.BFDate = newBf;
                        abfr.InitialBFDate = abfr.BFDate;

                    }
                    else if (inContext) //check for process context match
                    {
                        abfr.BFDate = newBf;
                        abfr.InitialBFDate = abfr.BFDate;
                    }
                    else if (ar.IsLinkTableNull()) //should this be allowed
                    {
                        abfr.BFDate = newBf;
                        abfr.InitialBFDate = abfr.BFDate;

                    }

                }
            }
            AllowEdit = false;


        }

        public void CompleteAllBFs(atriumDB.EFileRow er, bool WFOnly)
        {
            AllowEdit = true;
            atriumDB.ProcessRow[] prs = er.GetProcessRows();
            foreach (atriumDB.ProcessRow pr in prs)
            {
                foreach (atriumDB.ActivityRow ar in pr.GetActivityRows())
                {
                    foreach (atriumDB.ActivityBFRow abr in ar.GetActivityBFRows())
                    {
                        if (WFOnly)
                        {
                            if (abr.Completed == false && (abr.ACBFId != ActivityBFBE.USERBFID & abr.ACBFId!=368 ))
                            {
                                abr.Completed = true;
                            }

                        }
                        else
                        {
                            if (abr.Completed == false)
                            {
                                abr.Completed = true;
                            }
                        }
                    }
                }
                myA.GetProcess().SetActive(pr);
            }
            AllowEdit = false;
        }

        //move to activitybf?
        public bool HasIncompleteBFs(atriumDB.EFileRow er, bool monitor)
        {
            //if (er.GetActivityRows().Length == 0)
            //    this.myA.GetActivity().LoadByFileId(er.FileId);
            //else if (er.GetActivityRows().Length == 1 && er.GetActivityRows()[0].RowState == DataRowState.Added)
            //    this.myA.GetActivity().LoadByFileId(er.FileId);

            atriumDB.ActivityRow[] ars = er.GetActivityRows();
            foreach (atriumDB.ActivityRow ar in ars)
            {
                foreach (atriumDB.ActivityBFRow br in ar.GetActivityBFRows())
                {
                    if (monitor)
                    {
                        if (!br.isMail && !br.IsBFDateNull() && !br.Completed && !br.MonitorIncomplete)
                            return true;

                    }
                    else
                    {
                        if (!br.isMail && !br.IsBFDateNull() && !br.Completed)
                            return true;
                    }
                }
            }

            return false;

        }




        internal void CompleteAllOnProcess(atriumDB.ProcessRow pr1, int procid)
        {
            AllowEdit = true;
            foreach (atriumDB.ProcessRow pr in myA.DB.Process.Select("ProcessId=" + pr1.ProcessId.ToString() + " or Thread like '" + pr1.Thread + "-%' or '" + pr1.Thread + "' like Thread+'%' "))
            {
                if (pr.ProcessId != procid)
                {
                    foreach (atriumDB.ActivityRow ar in pr.GetActivityRows())
                    {
                        foreach (atriumDB.ActivityBFRow abr in ar.GetActivityBFRows())
                        {
                            if (abr.Completed == false && abr.ACBFId != USERBFID)
                            {
                                abr.Completed = true;
                            }
                        }
                    }
                }
            }
            AllowEdit = false;
        }
    }
}

