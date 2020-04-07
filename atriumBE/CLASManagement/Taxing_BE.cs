using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class TaxingBE:atLogic.ObjectBE
	{
        CLASManager myA;
		CLAS.TaxingDataTable myTaxingDT;

        internal TaxingBE(CLASManager pBEMng)
            : base(pBEMng, pBEMng.DB.Taxing)
		{
			myA=pBEMng;
            myTaxingDT = (CLAS.TaxingDataTable)myDT;

			this.myTaxingDT.TaxDownDisbColumn.ExtendedProperties.Add("format","C");


            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetTaxing();
        }
        public atriumDAL.TaxingDAL myDAL
        {
            get
            {
                return (atriumDAL.TaxingDAL)myODAL;
            }
        }

        public void LoadByOfficeID(int OfficeID)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().TaxingLoadByOfficeId(OfficeID, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficeID(OfficeID));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficeID(OfficeID));
                }
            }
		}

		public void LoadBySRPID(int SrpID)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().TaxingLoadBySrpID(SrpID, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadBySRPId(SrpID));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadBySRPId(SrpID));
                }
            }
		}

		protected override void AfterAdd(DataRow row)
		{
            CLAS.TaxingRow dr = (CLAS.TaxingRow)row;
			string ObjectName = this.myTaxingDT.TableName;

            dr.FileID = myA.FM.CurrentFileId;
			dr.TaxingID = this.myA.AtMng.PKIDGet(ObjectName,1);            
			dr.TaxingDate=DateTime.Today;
			//dr.OfficeCode=this.myA.AtMng.OfficeLoggedOn.OfficeCode;
			//get officecode for leadoffice
			dr.OfficeCode=this.myA.FM.CurrentFile.LeadOfficeCode;
			dr.OfficeID=this.myA.FM.CurrentFile.LeadOfficeId;
            dr.OfficerCode = this.myA.AtMng.WorkingAsOfficer.OfficerCode;
            dr.OfficerID = this.myA.AtMng.WorkingAsOfficer.OfficerId;
			dr.PrevInstructed=false;
            dr.Closed = false;
            
		}

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.TaxingRow r = (CLAS.TaxingRow)dr;
            EFileBE.XmlAddToc(myA.FM.CurrentFile, "taxing", "Taxing recommendations", "Recommendations de taxation",200);

        }

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myTaxingDT.TableName;
            CLAS.TaxingRow dr = (CLAS.TaxingRow)ddr;
			switch(dc.ColumnName)
			{
				case TaxingFields.Comment:
                    if (dr.IsNull(dc))
                        throw new RequiredException(atriumBE.Properties.Resources.ResourceManager.GetString(ObjectName + dc.ColumnName));
                    break;
				case TaxingFields.ReasonCode:
					if(dr.IsNull(dc))
						throw new RequiredException(atriumBE.Properties.Resources.ResourceManager.GetString(ObjectName+ dc.ColumnName));
                    else if (!myA.CheckDomain(dr.ReasonCode, myA.FM.Codes("ReasonCode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Reason Code");
					break;
                case TaxingFields.OfficeID:
                    if (dr.IsNull("OfficeID"))
                        throw new RequiredException(atriumBE.Properties.Resources.ResourceManager.GetString(ObjectName+ dc.ColumnName));
                    else if (!myA.CheckDomain(dr.OfficeID, myA.FM.Codes("officelist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
                    break;
                case TaxingFields.OfficerID:
                    if (dr.IsOfficerIDNull())
                        throw new RequiredException(atriumBE.Properties.Resources.ResourceManager.GetString(ObjectName + dc.ColumnName));
                    else if (!myA.CheckDomain(dr.OfficerID, myA.FM.Codes("claslist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Officer List");
                    break;
				case TaxingFields.TaxingDate:
                    if (dr.IsTaxingDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.TaxingTaxingDate);
					myA.IsValidDate(atriumBE.Properties.Resources.TaxingTaxingDate, dr.TaxingDate, false,DateTime.Today.AddMonths(-6), DateTime.Today, atriumBE.Properties.Resources.ValidationSixMonthsAgo, atriumBE.Properties.Resources.ValidationToday);
					break;
				default:
					break;
			}
		}
		protected override void BeforeUpdate(DataRow row) 
		{
            CLAS.TaxingRow dr = (CLAS.TaxingRow)row;
			if(dr.IsTaxingDateNull())
				this.BeforeChange(dr.Table.Columns[TaxingFields.TaxingDate],dr);
			this.BeforeChange(dr.Table.Columns[TaxingFields.Comment],dr);
			this.BeforeChange(dr.Table.Columns[TaxingFields.ReasonCode],dr);

		}

        public void closeTaxRec(CLAS.TaxingRow taxRow, atriumDB.IRPRow irpRow)
        {
            taxRow.Closed = true;
            taxRow.IRPId = irpRow.IRPId;
        }

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {
           	string ObjectName = this.myTaxingDT.TableName;
            CLAS.TaxingRow dr = (CLAS.TaxingRow)ddr;
            switch (dc.ColumnName)
            {
                case "Closed":
                    if (dr.Closed)
                    {
                        
                    }
                    else
                    {
                        dr.SetIRPIdNull();
                        
                    }


                    break;
            }
        }
        public override bool CanEdit(DataRow dr)
        {
            if (dr == null)
                return true;

            if (dr.RowState == DataRowState.Added)
                return true;

            bool allowEdit = false;

            CLAS.TaxingRow taxingRow = (CLAS.TaxingRow)dr;

            if (myA.FM.AllowedForOwnerOrSysAdmin() && myA.AtMng.SecurityManager.CanUpdate(taxingRow.FileID, atSecurity.SecurityManager.Features.Taxing) == atSecurity.SecurityManager.LevelPermissions.All)
            {
                //you are CLAS and you have perms on Taxing
                if (taxingRow.Closed && !taxingRow.IsIRPIdNull())
                {
                    //check to see if taxation is completed on SRP
                    atriumDB.IRPRow irprow = myA.FM.DB.IRP.FindByIRPId(taxingRow.IRPId);
                    if (irprow == null) // hmmm. how is it that irprow is null? assume it's a no go
                        return false;
                    if (irprow.SRPRow == null) // oops, gotta load it to check it
                        myA.FM.GetSRP().Load(irprow.SRPID);


                    if (myA.FM.GetSRP().isSRPTaxationCompleted(irprow))
                        allowEdit = false;  //taxation completed - edits never allowed; 
                    //else if (!irprow.IsDateTaxedNull() && !irprow.IsOfficerIDNull() && irprow["DateTaxed", DataRowVersion.Current].Equals(irprow["DateTaxed", DataRowVersion.Original]) && irprow["OfficerID", DataRowVersion.Current].Equals(irprow["OfficerID", DataRowVersion.Original]))
                    //    allowEdit = false; // irp taxed - edits not allowed;
                    else
                        allowEdit = true; //taxation not completed yet; allow edits by CLAS w/ taxing perm
                }
                else if (!taxingRow.Closed)
                    allowEdit = true;
            }

            return allowEdit;
        }

        public override bool CanDelete(DataRow row)
        {
            bool allowDelete=false;
            CLAS.TaxingRow taxingRow = (CLAS.TaxingRow)row;

            if (myA.AtMng.SecurityManager.CanDelete(taxingRow.FileID, atSecurity.SecurityManager.Features.Taxing) == atSecurity.SecurityManager.LevelPermissions.All)
            {
                allowDelete=true;
                if (taxingRow.Closed)
                {
                    allowDelete = false;
                    bool canOverride = myA.AtMng.SecurityManager.CanOverride(taxingRow.FileID, atSecurity.SecurityManager.Features.Taxing) == atSecurity.SecurityManager.ExPermissions.Yes;
                    if (canOverride)
                        allowDelete = true;
                }

            }

            return allowDelete;
        }

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[]{this.myA.CurrentFile};
        //}



	}
}

