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
	public class DisbursementBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.DisbursementDataTable myDisbursementDT;
		
		internal DisbursementBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.Disbursement)
		{
			myA=pBEMng;
			myDisbursementDT=(atriumDB.DisbursementDataTable)myDT;

			this.myDisbursementDT.DisbTaxableColumn.ExtendedProperties.Add("format","C");
			this.myDisbursementDT.DisbTaxColumn.ExtendedProperties.Add("format","$#.0000");
			this.myDisbursementDT.DisbTaxExemptColumn.ExtendedProperties.Add("format","C");

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetDisbursement();
        }

        public atriumDAL.DisbursementDAL myDAL
        {
            get
            {
                return (atriumDAL.DisbursementDAL)myODAL;
            }
        }

        public void LoadByActivityId(int activityId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().DisbursementLoadByActivityId(activityId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByActivityID(activityId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByActivityID(activityId));
                }
            }
        }

		public override string BestFKName()
		{
			return "ActivityID";
		}

        public override bool CanDelete(DataRow row)
        {
            atriumDB.DisbursementRow dr = (atriumDB.DisbursementRow)row;

            bool ok = false;

            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(dr.FileID, atSecurity.SecurityManager.Features.Disbursement);
            switch (perm)
            {
                case atSecurity.SecurityManager.LevelPermissions.All:
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

            bool canOverride = myA.AtMng.SecurityManager.CanOverride(dr.FileID, atSecurity.SecurityManager.Features.Disbursement) == atSecurity.SecurityManager.ExPermissions.Yes;

            if (dr.Final && !dr.IsIRPIdNull() && !canOverride)
            {
                ok = false;
            }
            return ok;

        }
        public override bool CanAdd(DataRow parent)
        {
            atriumDB.ActivityRow er = (atriumDB.ActivityRow)parent;
            if (er == null)
                return false;
            if (er.OfficeId != myA.AtMng.WorkingAsOfficer.OfficeId)
                return false;
            if (er.EFileRow == null || !er.EFileRow.FileMetaTypeRow.isBillable)
                return false;

            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(er.FileId, atSecurity.SecurityManager.Features.Disbursement) > atSecurity.SecurityManager.ExPermissions.No;
        }

		public override bool CanEdit(DataRow ddr)
		{
			
			atriumDB.DisbursementRow dr=(atriumDB.DisbursementRow)ddr;
            if (dr == null || dr.ActivityRow == null)
                return false;

            if (dr.ActivityRow.EFileRow.RowState == DataRowState.Added)
                return true;

            if(dr.IsNull("FileId"))
                return true;

            if (!myA.IsVirtualFM && dr.FileID != myA.CurrentFile.FileId)
                return false;

			if(dr.Final  )
				return false;
			
            if(!dr.IsNull("OfficeId") && dr.OfficeId!=this.myA.AtMng.WorkingAsOfficer.OfficeId)
				return false;

            if (dr.ActivityRow != null && dr.ActivityRow.OfficeId != this.myA.AtMng.WorkingAsOfficer.OfficeId)
				return false;

            return myA.AtMng.SecurityManager.CanUpdate(dr.FileID, atSecurity.SecurityManager.Features.Disbursement) > atSecurity.SecurityManager.LevelPermissions.No | AllowEdit;

		}

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myDisbursementDT.TableName;
			atriumDB.DisbursementRow dr=(atriumDB.DisbursementRow)ddr;
			switch(dc.ColumnName)
			{
				case DisbursementFields.DisbDate:
                    if (dr.IsDisbDateNull() || myA.IsEmpty(dr.DisbDate.ToString()))
                        throw new RequiredException(Resources.DisbursementDisbDate);
                    this.myA.IsValidDate(Resources.DisbursementDisbDate, dr.DisbDate, false, DateTime.Today.AddMonths(-6), DateTime.Today, Resources.ValidationSixMonthsAgo, Resources.ValidationToday);
					break;
				case DisbursementFields.DisbType:
                    if (dr.IsNull(dc) || dr.DisbType.Length == 0)
                        throw new RequiredException(Resources.DisbursementDisbType);
                    else if (!myA.CheckDomain(dr.DisbType,myA.Codes("DisbursementType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Dsibursement Type");
					break;
                case "TaxRateId":
                    if (!dr.IsTaxRateIdNull() && !myA.CheckDomain(dr.TaxRateId, myA.Codes("TaxRate")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Tax Rate");
                    break;
                case "OfficeId":
                    if (!myA.CheckDomain(dr.OfficeId, myA.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.IsNotValid, dc.ColumnName);
                    else if (!myA.CheckDomain(dr.OfficeId, myA.Codes("officelist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
                    break;
				case DisbursementFields.IRPId:
				case DisbursementFields.DisbTaxExempt:
				case DisbursementFields.DisbTaxable:
				case DisbursementFields.DisbTax:
				case DisbursementFields.Posted:
				case DisbursementFields.Final:
                    if (dr.Final)
                        throw new AtriumException(Resources.DisbNoEditAfterCommit);
					break;
				case DisbursementFields.Taxed:
                    if (!dr.Final && dr.Taxed)
                        throw new AtriumException(Resources.DisbNoTaxUnlessCommit);
					break;
				default:
					break;
			}
		}
		protected override void BeforeUpdate(DataRow row)
		{
			atriumDB.DisbursementRow dr=(atriumDB.DisbursementRow)row;
			if(!CanEdit(dr))
				throw new AtriumException(atriumBE.Properties.Resources.CACannotEditAnotherOffice);

			if(dr.IsDisbDateNull())
				this.BeforeChange(DisbursementFields.DisbDate,dr);
			if(dr.IsNull(dr.Table.Columns[DisbursementFields.DisbType]))
				this.BeforeChange(DisbursementFields.DisbType,dr);
			if(dr.IsDisbTaxableNull() && dr.IsDisbTaxExemptNull())
				throw new RequiredException(DisbursementFields.DisbTaxable);
		
		}
		
		protected override void AfterAdd(DataRow row)
		{
			atriumDB.DisbursementRow dr=(atriumDB.DisbursementRow)row;
			string ObjectName = this.myDisbursementDT.TableName;

			if (dr.IsNull("DisbId") || dr.DisbId>0)
				dr.DisbId = this.myA.AtMng.PKIDGet(ObjectName,1);

            dr.DisbDate = dr.ActivityRow.ActivityDate;// DateTime.Today;
			dr.FileID=dr.ActivityRow.FileId;
			dr.Final=false;
			dr.Posted=true;
			dr.OfficeId=this.myA.AtMng.WorkingAsOfficer.OfficeId;
			dr.Taxed=false;

            //2017-08-09 JLL IUTIR - 9755
            if (!myA.AtMng.WorkingAsOfficer.OfficeRow.IsDefaultTaxRateNull())
                dr.TaxRateId = myA.AtMng.WorkingAsOfficer.OfficeRow.DefaultTaxRate;

            //2017-09-20 JLL
            //validate disbdate on entry, otherwise on ACs older than 6 months, date can be saved if not edited without being validated properly
            this.BeforeChange(this.myDisbursementDT.Columns["DisbDate"], row);
        }



		protected override void AfterChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myDisbursementDT.TableName;

			atriumDB.DisbursementRow dr=(atriumDB.DisbursementRow)ddr;
            

			switch(dc.ColumnName)
			{
				case DisbursementFields.DisbTaxable:
                case "TaxRateId":
					if (!dr.Final)
					{
                        if (dr.IsDisbTaxableNull())
                            dr.SetDisbTaxNull();
                        else
                        {
                            if (!dr.IsTaxRateIdNull())
                            {
                                appDB.TaxRateRow taxRateRow = myA.AtMng.DB.TaxRate.FindByTaxRateId(dr.TaxRateId);
                                dr.DisbTax = dr.DisbTaxable * taxRateRow.TaxRate;
                            }
                            else
                            {
                                officeDB.OfficeRow drOffice = this.myA.AtMng.GetOffice(dr.OfficeId).CurrentOffice;
                                dr.DisbTax = dr.DisbTaxable * (drOffice.IsTaxRateNull() ? 0 : drOffice.TaxRate);
                            }
                            
                            dr.DisbTax = Math.Round(dr.DisbTax, 2, MidpointRounding.AwayFromZero);
                        }
                        dr.EndEdit();
                    }
					break;
				default:
					break;
			}
		}
		
		protected override void BeforeDelete(DataRow row)
		{
			atriumDB.DisbursementRow dr = (atriumDB.DisbursementRow) row;

			if (dr.Final && !dr.IsIRPIdNull() || dr.OfficeId!=this.myA.AtMng.OfficeLoggedOn.OfficeId)
			{
                throw new AtriumException(Resources.DisbNoDelete);
			}
		}

        int currentirpId;
        bool isPostedBR;
        bool isSubmitted = false;
        public void IncludeOnSRP(atriumDB.IRPRow irp, bool isPosted, bool submitted)
        {
            isSubmitted = submitted;
            currentirpId = irp.IRPId;
            isPostedBR = isPosted;
            foreach (atriumDB.DisbursementRow disbr in myA.DB.Disbursement)
            {
                disbr.IncludeOnSRP = false;

                if (!isSubmitted)
                {
                    if (!isPosted && !disbr.Posted)
                    {
                        disbr.IncludeOnSRP = true;
                    }
                    else if (isPosted && disbr.Posted && !disbr.Final && disbr.OfficeId == irp.OfficeID && disbr.DisbDate > irp.SRPDate.AddMonths(-6) && disbr.DisbDate <= irp.SRPDate && disbr.entryDate > irp.SRPDate.AddMonths(-6) && disbr.entryDate <= irp.SRPDate.AddDays(14))
                    {
                        disbr.IncludeOnSRP = true;
                    }
                }
                else
                {
                    if (!disbr.IsIRPIdNull() && disbr.IRPId == irp.IRPId)
                        disbr.IncludeOnSRP = true;
                }
                disbr.AcceptChanges();
            }
        }

        public void IncludeOnIRP()
        {
            if (currentirpId != 0)
            {
                IncludeOnSRP(myA.DB.IRP.FindByIRPId(currentirpId), isPostedBR, isSubmitted);
            }
        }
	}
}

