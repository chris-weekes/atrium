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
	public class IRPBE:atLogic.ObjectBE
	{
        FileManager myA;
		atriumDB.IRPDataTable myIRPDT;

        internal IRPBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.IRP)
		{
			myA=pBEMng;
            myIRPDT = (atriumDB.IRPDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetIRP();

            this.myIRPDT.FeesClaimedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.FeesClaimedTaxColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.FeesTaxedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.FeesTaxedTaxColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.FileTotalTaxedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.DisbursementClaimedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.DisbursementClaimedTaxColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.DisbursementTaxedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.DisbursementTaxedTaxColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.DisbursementTaxExemptClaimedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.DisbursementTaxExemptTaxedColumn.ExtendedProperties.Add("format", "C");

            this.myIRPDT.TotalClaimedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.TotalTaxClaimedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.TotalTaxedColumn.ExtendedProperties.Add("format", "C");
            this.myIRPDT.TotalTaxTaxedColumn.ExtendedProperties.Add("format", "C");
        }

        public atriumDAL.IRPDAL myDAL
        {
            get
            {
                return (atriumDAL.IRPDAL)myODAL;
            }
        }

		public void LoadBySRPId(int srpId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().IRPLoadBySRPId(srpId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadBySRPID(srpId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadBySRPID(srpId));
                }
            }
		}

        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.IRPRow r = (atriumDB.IRPRow)dr;
            //try
            //{
            //    EFileBE.XmlAddToc(myA.AtMng.GetFile(r.FileID).CurrentFile, "irp", "Taxation", "Taxation", 190);
            //}
            //catch (Exception x)
            //{
            //}
        }

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myIRPDT.TableName;
            atriumDB.IRPRow dr = (atriumDB.IRPRow)ddr;
			switch(dc.ColumnName)
			{
				case "FeesClaimed":
				case "FeesClaimedTax":
				case "DisbursementTaxExemptClaimed":
				case "DisbursementClaimed":
				case "DisbursementClaimedTax":
                    if (!dr.SRPRow.IsSRPSubmittedDateNull())
                        throw new AtriumException(Resources.IRPNoChangeAfterSRP);
					break;
                //case "FeesTaxed":
                //    if (dr.FeesTaxed > dr.FeesClaimed)
                //        throw new AtriumException(Resources.IRPTaxedLessThanClaimed);
                //    break;
                //case "DisbursementTaxExemptTaxed":
                //    if(dr.DisbursementTaxExemptTaxed>dr.DisbursementTaxExemptClaimed)
                //        throw new AtriumException(Resources.IRPTaxedLessThanClaimed);
                //    break;
                //case "DisbursementTaxed":
                //    if (dr.DisbursementTaxed > dr.DisbursementClaimed)
                //        throw new AtriumException(Resources.IRPTaxedLessThanClaimed);
                //    break;
                default:
					break;
			}
		}

		protected override void AfterAdd(DataRow row)
		{
            atriumDB.IRPRow dr = (atriumDB.IRPRow)row;
			string ObjectName = this.myIRPDT.TableName;

			dr.IRPId = this.myA.AtMng.PKIDGet(ObjectName,10);     
			dr.SRPDate=dr.SRPRow.SRPDate;
			dr.OfficeID=dr.SRPRow.OfficeID;

            //default to office file; for non online agents, it was the mechanism to make sure a general file made its way in there?
            //jll: with the file selector, can we remove this default? or leave it out of habit? ask clas.
			//dr.FileID=-dr.OfficeID; // commented out; validate sin function will handle setting of fileid
	
		}


		protected override void AfterChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myIRPDT.TableName;

            atriumDB.IRPRow dr = (atriumDB.IRPRow)ddr;
            officeDB.OfficeRow drOffice = this.myA.AtMng.GetOffice(dr.OfficeID).CurrentOffice;

			switch(dc.ColumnName)
			{
				case "FeesTaxed":
					if(dr.IsFeesTaxedNull())
						dr.SetFeesTaxedTaxNull();
					else
						dr.FeesTaxedTax =decimal.Round( dr.FeesTaxed * (drOffice.IsTaxRateNull()? 0 : drOffice.TaxRate) ,2, MidpointRounding.AwayFromZero);
                    dr.EndEdit();
                    break;
				case "DisbursementTaxed":
                    if (dr.IsDisbursementTaxedNull())
                        dr.SetDisbursementTaxedTaxNull();
                    else
                    {
                        officeDB.OfficeRow officeRow= myA.AtMng.GetOffice().GetOffice(dr.OfficeID);
                        if(!officeRow.IsOnLine)
                            dr.DisbursementTaxedTax = decimal.Round(dr.DisbursementTaxed * (drOffice.IsTaxRateNull() ? 0 : drOffice.TaxRate), 2, MidpointRounding.AwayFromZero);
                    }
                    dr.EndEdit();
                    break;
				case "FeesClaimed":
					if(dr.IsFeesClaimedNull())
						dr.SetFeesClaimedTaxNull();
					else
                        dr.FeesClaimedTax = decimal.Round(dr.FeesClaimed * (drOffice.IsTaxRateNull() ? 0 : drOffice.TaxRate), 2, MidpointRounding.AwayFromZero);
                    dr.EndEdit();
                    break;
				case "DisbursementClaimed":
                    if (dr.IsDisbursementClaimedNull())
                        dr.SetDisbursementClaimedTaxNull();
                    else
                    {
                        officeDB.OfficeRow officeRow = myA.AtMng.GetOffice().GetOffice(dr.OfficeID);
                        if (!officeRow.IsOnLine)
                            dr.DisbursementClaimedTax = decimal.Round(dr.DisbursementClaimed * (drOffice.IsTaxRateNull() ? 0 : drOffice.TaxRate), 2, MidpointRounding.AwayFromZero);
                    }
                    dr.EndEdit();
                    break;
				case "DateTaxed":
					if (dr.SRPRow.IsTaxationBeganNull())
					{
						dr.SRPRow.TaxationBegan = DateTime.Today;
						//dr.SRPRow.AcceptChanges();
                        dr.EndEdit();
                        dr.SRPRow.EndEdit();
                    }
					break;
				case "OfficerID":
					if(!dr.IsOfficerIDNull() && dr.IsDateTaxedNull())
					{
						dr.DateTaxed = DateTime.Today;
						dr.FeesTaxed = dr.IsFeesClaimedNull()? 0 : dr.FeesClaimed;
						dr.FeesTaxedTax = dr.IsFeesClaimedTaxNull() ? 0 : dr.FeesClaimedTax;
						dr.DisbursementTaxed = dr.IsDisbursementClaimedNull() ? 0 : dr.DisbursementClaimed;
						dr.DisbursementTaxedTax = dr.IsDisbursementClaimedTaxNull()? 0 : dr.DisbursementClaimedTax;
						dr.DisbursementTaxExemptTaxed = dr.IsDisbursementTaxExemptClaimedNull() ? 0 : dr.DisbursementTaxExemptClaimed;
                        dr.EndEdit();
                    }
					break;
				case "SIN":
                    try
                    {
                        //FileManager fm = myA.AtMng.GetFileBySIN(dr.SIN);
                        //dr.FileID = fm.CurrentFile.FileId;
                        //fm.Dispose();
                        //dr.EndEdit();
                    }
                    catch (Exception x)
                    {
                        System.Diagnostics.Trace.WriteLine(x.Message);
                        throw new AtriumException(atriumBE.Properties.Resources.SINNotFound);
                    }
					break;
				default:
					break;
			}
		}

		public override string BestFKName()
		{
			return "SRPId";
		}

        public override bool CanEdit(DataRow dr)
        {
            atriumDB.IRPRow ir = (atriumDB.IRPRow)dr;

            //JLL: if taxation completed then read-only
            // This line fails when trying to load the ucTaxation control because currentRow's SRPRow is null - commented out temporarily
            //if(!ir.SRPRow.IsTaxationCompletedNull())
            //    return false;

            //if officeloggedon != irp officeid and agent uses billing
            //if(ir.SRPRow.OfficeRow.UsesBilling & ir.OfficeID!=myA.AtMng.OfficeLoggedOn.OfficeId)

            return myA.AtMng.SecurityManager.CanUpdate(ir.FileID, atSecurity.SecurityManager.Features.IRP) > atSecurity.SecurityManager.LevelPermissions.No | AllowEdit;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr">SRP Row</param>
        /// <param name="billingFileId">File ID of Billing File</param>
        /// <returns></returns>
        public bool CanAdd(DataRow dr, int billingFileId)
        {
            atriumDB.SRPRow srpr = (atriumDB.SRPRow)dr;

            if (myA.CurrentFile.OwnerOfficeId == myA.AtMng.WorkingAsOfficer.OfficeId && !myA.LeadOfficeMng.CurrentOffice.UsesBilling && srpr.IsTaxationCompletedNull())
                return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr">IRP Row</param>
        /// <param name="billingFileId">File ID of Billing File</param>
        /// <returns></returns>
        public bool CanDelete(DataRow dr, int billingFileId)
        {
            atriumDB.IRPRow irpr = (atriumDB.IRPRow)dr;

            FileManager fm = myA.AtMng.GetFile(billingFileId);

            if (fm.AllowedForOwnerOrSysAdmin() && !fm.LeadOfficeMng.CurrentOffice.UsesBilling && irpr.SRPRow.IsTaxationCompletedNull())
                return true;

            return false;
        }

        public void RollbackTaxation(atriumDB.IRPRow irpRow)
        {
            irpRow.SetOfficerIDNull();
            irpRow.SetDateTaxedNull();
            irpRow.SetFeesTaxedNull();
            irpRow.SetFeesTaxedTaxNull();
            irpRow.SetDisbursementTaxedNull();
            irpRow.SetDisbursementTaxedTaxNull();
            irpRow.SetDisbursementTaxExemptTaxedNull();
        }
	}

}

