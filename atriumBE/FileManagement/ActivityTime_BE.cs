
using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ActivityTimeBE : atLogic.ObjectBE
    {
        FileManager myA;
        atriumDB.ActivityTimeDataTable myActivityTimeDT;

        internal ActivityTimeBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.ActivityTime)
        {
            myA = pBEMng;
            myActivityTimeDT = (atriumDB.ActivityTimeDataTable)myDT;

            this.myActivityTimeDT.FeesClaimedColumn.ExtendedProperties.Add("format", "C");
            this.myActivityTimeDT.FeesClaimedTaxColumn.ExtendedProperties.Add("format", "$#.0000");

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetActivityTime();
        }
        public atriumDAL.ActivityTimeDAL myDAL
        {
            get
            {
                return (atriumDAL.ActivityTimeDAL)myODAL;
            }
        }


        public atriumDB.ActivityTimeRow Load(int ActivityTimeId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ActivityTimeLoad(ActivityTimeId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(ActivityTimeId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(ActivityTimeId));
                }
            }
            SetDisplayHours();
            return myActivityTimeDT.FindByActivityTimeId(ActivityTimeId);
        }


        public void LoadByActivityId(int ActivityId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ActivityTimeLoadByActivityId(ActivityId, myA.AtMng.AppMan.AtriumXCon));
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
            SetDisplayHours();
        }

       
        
        public appDB.SRPClientDataTable LoadSRPClientByOfficerId(int SRPID, int OfficerId, DateTime StartDate, DateTime EndDate)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                return myA.AtMng.AppMan.AtriumX().ActivityTimeLoadSRPClientByOfficerId(SRPID, OfficerId, StartDate, EndDate, myA.AtMng.AppMan.AtriumXCon);
            }
            else
            {
                try
                {
                    return SetSRPClientHours(myDAL.LoadSRPClientByOfficerId(SRPID, OfficerId, StartDate, EndDate));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    return SetSRPClientHours(myDAL.LoadSRPClientByOfficerId(SRPID, OfficerId, StartDate, EndDate));
                }
            }
        }

        public appDB.SRPClientDataTable LoadSRPClientBySRPID(int SRPID)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                return myA.AtMng.AppMan.AtriumX().ActivityTimeLoadSRPClientBySRPID(SRPID, myA.AtMng.AppMan.AtriumXCon);
            }
            else
            {
                try
                {
                    return SetSRPClientHours(myDAL.LoadSRPClientBySRPID(SRPID));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    return SetSRPClientHours(myDAL.LoadSRPClientBySRPID(SRPID));
                }
            }
        }

        public appDB.TimeSlipDataTable LoadByOfficerId(int OfficerId, DateTime StartDate, DateTime EndDate)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                return myA.AtMng.AppMan.AtriumX().ActivityTimeLoadByOfficerId(OfficerId, StartDate, EndDate, myA.AtMng.WorkingAsOfficer.ShortcutsId, myA.AtMng.AppMan.AtriumXCon);
            }
            else
            {
                try
                {
                    return SetTimeSlipHours(myDAL.LoadByOfficerId(OfficerId, StartDate, EndDate, myA.AtMng.WorkingAsOfficer.ShortcutsId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    return SetTimeSlipHours(myDAL.LoadByOfficerId(OfficerId, StartDate, EndDate, myA.AtMng.WorkingAsOfficer.ShortcutsId));
                }
            }
        }


        public appDB.TimeSlipDataTable LoadBySRPID(int SRPID)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                return myA.AtMng.AppMan.AtriumX().ActivityTimeLoadBySRPID(SRPID, myA.AtMng.WorkingAsOfficer.ShortcutsId, myA.AtMng.AppMan.AtriumXCon);
            }
            else
            {
                try
                {
                    return SetTimeSlipHours(myDAL.LoadBySRPID(SRPID, myA.AtMng.WorkingAsOfficer.ShortcutsId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    return SetTimeSlipHours(myDAL.LoadBySRPID(SRPID, myA.AtMng.WorkingAsOfficer.ShortcutsId));
                }
            }
        }

        public appDB.TimeSlipBranchDataTable LoadBranchByOfficerId(int OfficerId, DateTime StartDate, DateTime EndDate)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                return myA.AtMng.AppMan.AtriumX().ActivityTimeLoadBranchByOfficerId(OfficerId, StartDate, EndDate, myA.AtMng.AppMan.AtriumXCon);
            }
            else
            {
                try
                {
                    return myDAL.LoadBranchByOfficerId(OfficerId, StartDate, EndDate);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    return myDAL.LoadBranchByOfficerId(OfficerId, StartDate, EndDate);
                }
            }
        }

        public appDB.TimeSlipBranchDataTable LoadBranchBySRPID(int SRPID)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                return myA.AtMng.AppMan.AtriumX().ActivityTimeLoadBranchBySRPID(SRPID, myA.AtMng.AppMan.AtriumXCon);
            }
            else
            {
                try
                {
                    return myDAL.LoadBranchBySRPID(SRPID);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    return myDAL.LoadBranchBySRPID(SRPID);
                }
            }
        }

        protected override void AfterAdd(DataRow ddr)
        {
            string ObjectName = this.myActivityTimeDT.TableName;

            atriumDB.ActivityTimeRow dr = (atriumDB.ActivityTimeRow)ddr;
            ActivityConfig.ActivityCodeRow arc = myA.GetActivity().GetACSeriesRow(dr.ActivityRow).ActivityCodeRow;

            dr.ActivityTimeId = this.myA.AtMng.PKIDGet(ObjectName, 10);
            dr.Taxed = false;
            dr.Final = false;
            dr.Posted = true;

            dr.FileId = dr.ActivityRow.FileId;
            if (!arc.IsDefaultHoursNull() && dr.IsHoursNull())
            {
                dr.Hours = Math.Round(arc.DefaultHours, 1);
            }
            else
                dr.Hours = 0;

       
            //  JLL: 2009-12-21 officeid should default to workingAs office and not activity row's officeid
            dr.OfficeId = myA.AtMng.WorkingAsOfficer.OfficeId;  //dr.ActivityRow.OfficeId;

            dr.OfficerId = myA.AtMng.WorkingAsOfficer.OfficerId;

            // JLL: 2009-12-21 changed to now as per PS request
            if (dr.ActivityRow.RowState == DataRowState.Added)
            {
                dr.StartTime = dr.ActivityRow.ActivityDate;
            }
            else
            {
                dr.StartTime = DateTime.Now;
            }

            CalcFees(dr);


        }
        protected override void BeforeDelete(System.Data.DataRow row)
        {
            atriumDB.ActivityTimeRow dr = (atriumDB.ActivityTimeRow)row;
            if (!CanDelete(dr))
                throw new AtriumException(atriumBE.Properties.Resources.ActivityTimeNoDeleteCommitted);
        }

        public override bool CanDelete(DataRow row)
        {
            atriumDB.ActivityTimeRow dr = (atriumDB.ActivityTimeRow)row;

            bool ok = false;

            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(dr.FileId, atSecurity.SecurityManager.Features.ActivityTime);
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
                    break;
                case atSecurity.SecurityManager.LevelPermissions.No:
                    ok = false;
                    break;
                default:
                    ok = false;
                    break;
            }

            bool canOverride = myA.AtMng.SecurityManager.CanOverride(dr.FileId, atSecurity.SecurityManager.Features.ActivityTime) == atSecurity.SecurityManager.ExPermissions.Yes;

            if (dr.Final && !dr.IsIRPIdNull() && !canOverride)
            {
                ok = false;
            }
            return ok;

        }

        public override bool CanAdd(DataRow parent)
        {
            atriumDB.ActivityRow ar = (atriumDB.ActivityRow)parent;
            if (ar.EFileRow == null)
                return false;
            else
            {
                //2017-08-11 JLL IUTIR - 9113: isBillable MetaFileType flag
                bool fileIsBillable = ar.EFileRow.FileMetaTypeRow.isBillable;
                return (fileIsBillable && myA.GetActivity().CanAdd(ar.EFileRow));
            }


            //JLL 2014-10-21 changed to account for office of officer
            //can only manually add timelsips to my office's activities
            //commented out on 2014-11-12 - causes wizard to fail on mandate when adding file. canadd below fails.

            //if(myA.AtMng.SecurityManager.CanAdd(ar.FileId, atSecurity.SecurityManager.Features.ActivityTime) == atSecurity.SecurityManager.ExPermissions.Yes)
            //{
            //    if(myA.AtMng.WorkingAsOfficer.OfficeId == ar.OfficeId || myA.AtMng.OfficeLoggedOn.OfficeId == ar.OfficeId)
            //        return true;
            //}

            //return false;
        }

        public override bool CanEdit(DataRow ddr)
        {
            atriumDB.ActivityTimeRow dr = (atriumDB.ActivityTimeRow)ddr;
            if (!myA.IsVirtualFM && dr.FileId != myA.CurrentFile.FileId)
                return false;
            //2017-08-21 JLL: On refresh, ActivityRow is null, return false;
            if (dr.ActivityRow == null)
                return false;
            if (dr.ActivityRow.EFileRow.RowState == DataRowState.Added)
                return true;

            bool doCheck = false;
            if (dr.RowState != DataRowState.Modified)
            {
                doCheck = true;
            }
            else
            {
                    //if only fileid or audit values was changed then return true
                    foreach (DataColumn dc in dr.Table.Columns)
                    {
                        switch (dc.ColumnName.ToLower())
                        {
                            case "fileid":
                            case "updatedate":
                            case "updateuser":
                                break;
                            default:
                                if (myA.IsFieldChanged(dc, dr))
                                    doCheck = true;
                                break;
                        }
                    }

            }
            if (doCheck)
            {
                bool ok = false;// myA.AtMng.SecurityManager.CanUpdate(dr.FileId, atSecurity.SecurityManager.Features.ActivityTime) > atSecurity.SecurityManager.LevelPermissions.No;
                atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(dr.FileId, atSecurity.SecurityManager.Features.ActivityTime);
                switch (perm)
                {
                    case atSecurity.SecurityManager.LevelPermissions.All:
                        ok = true;
                        break;
                    case atSecurity.SecurityManager.LevelPermissions.Mine:
                        if (dr.OfficerId == myA.AtMng.OfficerLoggedOn.OfficerId)
                            ok = true;
                        else
                        {
                            OfficeManager myOfficeMng = myA.AtMng.GetOffice(myA.AtMng.OfficeLoggedOn.OfficeId);

                            foreach (lmDatasets.officeDB.OfficerDelegateRow odr in myOfficeMng.GetOfficerDelegate().DelegatesForOfficer(myA.AtMng.OfficerLoggedOn.OfficerId))
                            {
                                if (dr.OfficerId == odr.OfficerId)
                                    ok = true;
                            }
                        }
                        //else if (dr.OfficerId == myA.AtMng.WorkingAsOfficer.OfficerId)
                        //    ok = true;
                        break;
                    case atSecurity.SecurityManager.LevelPermissions.MyOffice:
                        if (dr.OfficeId == myA.AtMng.OfficerLoggedOn.OfficeId)
                            ok = true;
                        break;
                    case atSecurity.SecurityManager.LevelPermissions.No:
                        ok = false;
                        break;
                    default:
                        ok = false;
                        break;
                }


                bool canOverride = myA.AtMng.SecurityManager.CanOverride(dr.FileId, atSecurity.SecurityManager.Features.ActivityTime) == atSecurity.SecurityManager.ExPermissions.Yes;
                if (dr.Final && !dr.IsIRPIdNull() && !canOverride)
                {
                    ok = false;
                }

                return ok | AllowEdit;
            }
            else
                return true;
        }
        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            atriumDB.ActivityTimeRow dr = (atriumDB.ActivityTimeRow)ddr;

            switch (dc.ColumnName)
            {
                case "OfficeId":
                    if (dr.IsOfficeIdNull())
                        throw new RequiredException(dc.ColumnName);
                    else if (!myA.CheckDomain(dr.OfficeId, myA.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
                    break;

                case ActivityFields.OfficerId:
                    if (dr.IsOfficerIdNull())
                        throw new RequiredException(dc.ColumnName);
                    else if (!myA.CheckDomain(dr.OfficerId, myA.Codes("OfficerList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Officer List");
                    break;
                case ActivityFields.Hours:
                    //JLL: 2014-10-16 Change from minute to hour
                    //if (dr.Hours > (24 * 60))
                    if (!fixingHours)
                    {
                        if (dr.Hours > 24)
                            throw new AtriumException("Minutes cannot be greater than 1440 minutes (24 hours) for one entry");
                        //if (dr.OfficeId != this.myA.AtMng.OfficeLoggedOn.OfficeId || (dr.Final && !dr.IsIRPIdNull()))
                        //    throw new AtriumException(atriumBE.Properties.Resources.ActivityTimeCannotEditHoursFees);
                    }
                    break;
                case ActivityFields.IRPId:
                case ActivityFields.FeesClaimed:
                case ActivityFields.FeesClaimedTax:
                case ActivityFields.Posted:
                case ActivityFields.Final:
                    //if (dr.OfficeId != this.myA.AtMng.OfficeLoggedOn.OfficeId || (dr.Final && !dr.IsIRPIdNull()))
                    //    throw new AtriumException(atriumBE.Properties.Resources.ActivityTimeCannotEditHoursFees);
                    break;
                case ActivityFields.Taxed:
                    if (!dr.Final && dr.Taxed)
                        throw new AtriumException(atriumBE.Properties.Resources.ActivityTimeCannotTax);
                    break;

            }
        }

        public bool fixingHours = false;
        internal void SetDisplayHours()
        {
        
            fixingHours = true;
            foreach (atriumDB.ActivityTimeRow dr in myActivityTimeDT)
            {
                dr.Hours = dr.Minutes / 60;
                dr.AcceptChanges();
            }

            fixingHours = false;
            if (currentirpId != 0)
            {
                IncludeOnSRP(myA.DB.IRP.FindByIRPId(currentirpId), isPostedBR,isSubmitted);
            }
        
        }
        internal appDB.TimeSlipDataTable SetTimeSlipHours(appDB.TimeSlipDataTable dt)
        {
            fixingHours = true;
            foreach (appDB.TimeSlipRow  dr in dt)
            {
                dr.Hours = dr.Minutes / 60;
                dr.AcceptChanges();
            }
            fixingHours = false;
            return dt;
        }
        internal appDB.SRPClientDataTable SetSRPClientHours(appDB.SRPClientDataTable dt)
        {
            fixingHours = true;
            foreach (appDB.SRPClientRow  dr in dt)
            {
                dr.Minutes = dr.Minutes / 60;
                dr.AcceptChanges();
            }
            fixingHours = false;
            return dt;
        }

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {

            string ObjectName = this.myActivityTimeDT.TableName;

            atriumDB.ActivityTimeRow dr = (atriumDB.ActivityTimeRow)ddr;
            switch (dc.ColumnName)
            {
              
                case ActivityFields.Hours:
                    if (!fixingHours)
                    {
                        dr.Hours = decimal.Round(dr.Hours, 1, MidpointRounding.AwayFromZero);
                        CalcFees(dr);
                    }
                    break;
                default:
                    break;
            }
        }

        private void CalcFees(atriumDB.ActivityTimeRow dr)
        {
            dr.Minutes = dr.Hours * 60;
            if (!dr.Final)
            {
                if (!dr.IsHoursNull())
                {
                    officeDB.OfficeRow or = this.myA.AtMng.GetOffice(dr.OfficeId).CurrentOffice;
                    //officeDB.OfficeRow or = (officeDB.OfficeRow)this.myA.AtMng.officeMng.DB.Office.Select("officeID=" + dr.OfficeId.ToString())[0];

                    //JLL: 2014-10-16 Change from minute to hour
                    //dr.FeesClaimed = decimal.Round(dr.Hours * or.HourlyRate / 60, 2, MidpointRounding.AwayFromZero);
                    dr.FeesClaimed = decimal.Round(dr.Hours * or.HourlyRate, 2, MidpointRounding.AwayFromZero);
                    if (!this.myA.AtMng.GetOffice(dr.OfficeId).CurrentOffice.IsTaxRateNull())
                        dr.FeesClaimedTax = Math.Round(this.myA.AtMng.GetOffice(dr.OfficeId).CurrentOffice.TaxRate * dr.FeesClaimed, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    dr.SetFeesClaimedNull();
                    dr.SetFeesClaimedTaxNull();
                }
                dr.EndEdit();
            }
        }

        int currentirpId;
        bool isPostedBR;
        bool isSubmitted = false;
        public void IncludeOnSRP( atriumDB.IRPRow irp, bool isPosted,bool submitted)
        {
            //JLL: have to load only applicable records; right now we're loading everything.
            //build filter on binding source
            /*where (vActivity.officeid=@officeid
            and vActivity.FileId=@FileId
            and vActivity.final=0 
            and activitydate between dateadd(m,-6,@srpdate ) and @srpdate
            and activityentrydate between dateadd(m,-6,@srpdate )and dateadd(y,14,@srpdate )
            )
            or( 
            vActivity.fileid=@fileid
            and exists(select * from disbursement as d where 
            vActivity.activityid=d.activityid 
            and d.officeid=@officeid
            and   d.final=0 
            and d.DisbDate between dateadd(m,-6,@srpdate ) and @srpdate
            and d.entrydate between dateadd(m,-6,@srpdate )and dateadd(y,14,@srpdate )
            ))     
             */

            isSubmitted = submitted;
            currentirpId = irp.IRPId;
            isPostedBR = isPosted;
            foreach (atriumDB.ActivityTimeRow atr in myA.DB.ActivityTime)
            {
                atr.IncludeOnSRP = false;

                if (!isSubmitted)
                {
                    if (!isPosted && !atr.Posted)
                    {
                        atr.IncludeOnSRP = true;
                    }
                    else if (isPosted && atr.Posted && !atr.Final && atr.OfficeId == irp.OfficeID && atr.StartTime > irp.SRPDate.AddMonths(-6) && atr.StartTime <= irp.SRPDate && atr.entryDate > irp.SRPDate.AddMonths(-6) && atr.entryDate <= irp.SRPDate.AddDays(14))
                    {
                        atr.IncludeOnSRP = true;
                    }
                }
                else
                {
                    if (!atr.IsIRPIdNull() && atr.IRPId == irp.IRPId)
                        atr.IncludeOnSRP = true;
                }

                atr.AcceptChanges();
            }
        }


    }
}

