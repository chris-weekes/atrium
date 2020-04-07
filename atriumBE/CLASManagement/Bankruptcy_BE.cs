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
	public class BankruptcyBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.BankruptcyDataTable myBankruptcyDT;
		
		internal BankruptcyBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Bankruptcy)
		{
			myA=pBEMng;
			myBankruptcyDT=(CLAS.BankruptcyDataTable)myDT;
        }
        public atriumDAL.BankruptcyDAL myDAL
        {
            get
            {
                return (atriumDAL.BankruptcyDAL)myODAL;
            }
        }

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.BankruptcyRow r = (CLAS.BankruptcyRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml =myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }
        private void MyXml(CLAS.BankruptcyRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='bankruptcy' and @id=" + r.BankruptcyID.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type","bankruptcy");
            }
            xe.SetAttribute("id", r.BankruptcyID.ToString());

            string dischargeable = Properties.Resources.BKCSLDischargeable;
            if (r.CSLNonDischargeable)
                dischargeable = Properties.Resources.BKCSLNonDischargeable;

            if (!r.IsBankruptcyDateNull())
            {
                xe.SetAttribute("titlee", r.BankruptcyDate.ToString("yyyy/MM/dd") + dischargeable);
                xe.SetAttribute("titlef", r.BankruptcyDate.ToString("yyyy/MM/dd") + dischargeable);
            }
            else
            {
                xe.SetAttribute("titlee", "Assignment Date is missing");
                xe.SetAttribute("titlef", "Date de faillite est manquante");
            }

            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "bankruptcy", "Bankruptcy", "Faillite",230);
                xes.AppendChild(xe);
            }


        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
		{
			foreach(CLAS.BankruptcyRow r in myBankruptcyDT)
			{
                MyXml(r, xd);

			}
		}

		protected override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myBankruptcyDT.TableName;
			CLAS.BankruptcyRow dr=(CLAS.BankruptcyRow)ddr;
			switch(dc.ColumnName)
			{
				case "BankruptcyDate":
                    if (dr.IsBankruptcyDateNull())
                        throw new RequiredException(Resources.BankruptcyBankruptcyDate);
					myA.IsValidDate(Resources.BankruptcyBankruptcyDate, dr.BankruptcyDate, false, (dr.IsPreviousBankruptcyDateNull()? DebtorBE.CSLBegin : dr.PreviousBankruptcyDate), DateTime.Today,"",Resources.ValidationToday);
					break;
				case "CSLEligibleForDischargeDate":
                    if (dr.IsCSLEligibleForDischargeDateNull())
                        throw new RequiredException(Resources.BankruptcyCSLEligibleForDischargeDate);
                    if (dr.IsBankruptcyDateNull())
                        throw new RelatedException(Resources.BankruptcyCSLEligibleForDischargeDate, Resources.BankruptcyBankruptcyDate);
					myA.IsValidDate(Resources.BankruptcyCSLEligibleForDischargeDate, dr.CSLEligibleForDischargeDate, false, dr.BankruptcyDate,DateTime.Today.AddYears(30),Resources.BankruptcyBankruptcyDate, Resources.ValidationThirtyYearsLater);
					break;
				case "DateofOrder":
                    if (dr.IsDateofOrderNull())
                        throw new RequiredException(Resources.BankruptcyDateofOrder);
                    if (dr.IsBankruptcyDateNull())
                        throw new RelatedException(Resources.BankruptcyDateofOrder, Resources.BankruptcyBankruptcyDate);
					myA.IsValidDate(Resources.BankruptcyDateofOrder,dr.DateofOrder, false, dr.BankruptcyDate, DateTime.Today, Resources.BankruptcyBankruptcyDate, Resources.ValidationToday);
					break;
				case "DateofTrusteeDischarge":
                    if (dr.IsDateofTrusteeDischargeNull())
                        throw new RequiredException(Resources.BankruptcyDateofTrusteeDischarge);
                    if (dr.IsBankruptcyDateNull())
                        throw new RelatedException(Resources.BankruptcyDateofTrusteeDischarge, Resources.BankruptcyBankruptcyDate);
					myA.IsValidDate(Resources.BankruptcyDateofTrusteeDischarge, dr.DateofTrusteeDischarge, true, dr.BankruptcyDate, DateTime.Today, Resources.BankruptcyBankruptcyDate, Resources.ValidationToday);
					break;
				case "DebtorDischargeNonCSLDebtDate":
                    if (dr.IsDebtorDischargeNonCSLDebtDateNull())
                        throw new RequiredException(Resources.BankruptcyDebtorDischargeNonCSLDebtDate);
                    if (dr.IsBankruptcyDateNull())
                        throw new RelatedException(Resources.BankruptcyDebtorDischargeNonCSLDebtDate, Resources.BankruptcyBankruptcyDate);
					myA.IsValidDate(Resources.BankruptcyDebtorDischargeNonCSLDebtDate, dr.DebtorDischargeNonCSLDebtDate, true, dr.BankruptcyDate, DateTime.Today.AddYears(20),Resources.BankruptcyBankruptcyDate, Resources.Validation20YearsLater);
					break;
				case "JudgmentAssignedtoCrownDate":
                    if (dr.IsJudgmentAssignedtoCrownDateNull())
                        throw new RequiredException(Resources.BankruptcyJudgmentAssignedtoCrownDate);
                    if (dr.IsBankruptcyDateNull())
                        throw new RelatedException(Resources.BankruptcyJudgmentAssignedtoCrownDate, Resources.BankruptcyBankruptcyDate);
					myA.IsValidDate(Resources.BankruptcyJudgmentAssignedtoCrownDate, dr.JudgmentAssignedtoCrownDate, true, dr.BankruptcyDate, DateTime.Today,Resources.BankruptcyBankruptcyDate, Resources.ValidationToday);
					break;
				case "PreviousBankruptcyDate":
                    if (dr.IsPreviousBankruptcyDateNull())
                        throw new RequiredException(Resources.BankruptcyPreviousBankruptcyDate);
					myA.IsValidDate(Resources.BankruptcyPreviousBankruptcyDate, dr.PreviousBankruptcyDate, true, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin, Resources.ValidationToday);
					break;
				case "ProvenClaimAmount":
                    if (!dr.IsProvenClaimAmountNull() && dr.ProvenClaimAmount <= 0)
                        throw new AtriumException(Resources.MustBeGreaterThanZero, Resources.BankruptcyProvenClaimAmount);
					break;
				case "ConditionalOrderAmount":
					if (!dr.IsConditionalOrderAmountNull() && dr.ConditionalOrderAmount <= 0)
                        throw new AtriumException(Resources.MustBeGreaterThanZero, Resources.BankruptcyConditionalOrderAmount);
					break;
				case "CSLNonDischargeable":
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.BankruptcyCSLNonDischargeable);
					break;
                case "InsolvencyPeriod":
                    if (!myA.CheckDomain(dr.InsolvencyPeriod, myA.FM.Codes("InsolvencyPeriod")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Duration of Bankruptcy");
                    break;
                case "BankruptcyOrderType":
                    if (!myA.CheckDomain(dr.BankruptcyOrderType, myA.FM.Codes("BankruptcyOrderType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Bankruptcy Order Type");
                    break;
                case "OfficeID":
                    if (!myA.CheckDomain(dr.OfficeID, myA.FM.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office List");
                    break;
				default:
					break;
			}
		}


		protected override void BeforeUpdate(DataRow row)
		{
			CLAS.BankruptcyRow dr = (CLAS.BankruptcyRow) row;
			this.BeforeChange(dr.Table.Columns["ProvenClaimAmount"],dr);
			this.BeforeChange(dr.Table.Columns["BankruptcyDate"],dr);
		}

		protected override void AfterAdd(DataRow row)
		{
			CLAS.BankruptcyRow dr=(CLAS.BankruptcyRow)row;
			string ObjectName = this.myBankruptcyDT.TableName;

			dr.BankruptcyID = this.myA.AtMng.PKIDGet(ObjectName,1);
            dr.OfficeID = myA.FM.CurrentFile.LeadOfficeId;
            dr.FileID = myA.FM.CurrentFile.FileId;
			dr.StayOfProceeding=true;
			dr.ConditionalOrderFufilled=false;
			dr.CSLNonDischargeable=false;
			dr.JudgmentinFavourofCrown=false;
			dr.JudgmentObtained=false;
			dr.SigningJudgmentATerm=false;
            CLAS.DebtorRow ddr = this.myA.GetDebtor().FindLoad(myA.FM.CurrentFile.OpponentID);
            if (!ddr.IsCeasedToBeStudentDateNull())
                dr.CeasedToBeStudentDate = ddr.CeasedToBeStudentDate;

            BankruptcyAccountBE jaBE = this.myA.GetBankruptcyAccount();

            foreach (CLAS.DebtRow debtr in this.myA.DB.Debt)
            {
               
                if (debtr.ActiveWithJustice) //  && debtr.OfficeID==debtr.EFileRow.LeadOfficeId) JLL 2010-08-11 Review this check
                {
                    CLAS.BankruptcyAccountRow jar = (CLAS.BankruptcyAccountRow)jaBE.Add(dr);
                    jar.BeginEdit();
                    jar.FileAccountID = debtr.FileAccountId;
                    jar.Include = true;
                    jar.EndEdit();
                }

            }
		}


		protected override void AfterChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myBankruptcyDT.TableName;

			CLAS.BankruptcyRow dr=(CLAS.BankruptcyRow)ddr;
			switch(dc.ColumnName)
			{
				case "BankruptcyDate":
					if (dr.IsCSLEligibleForDischargeDateNull() && !dr.IsCeasedToBeStudentDateNull())
					{
						TimeSpan ts = dr.BankruptcyDate - dr.CeasedToBeStudentDate;
						if (dr.BankruptcyDate >= DateTime.Parse("2008/7/7") && (ts.Days <= 7*365))
						{
							dr.CSLEligibleForDischargeDate = dr.CeasedToBeStudentDate.AddYears(7);
							dr.CSLNonDischargeable = true;
						}
                        else if (dr.BankruptcyDate >= DateTime.Parse("1998/6/18") && dr.BankruptcyDate < DateTime.Parse("2008/7/7") && (ts.Days <= 10 * 365))
                        {
                            dr.CSLEligibleForDischargeDate = dr.CeasedToBeStudentDate.AddYears(10);
                            dr.CSLNonDischargeable = true;
                        }
						else if(dr.BankruptcyDate >= DateTime.Parse("1997/9/30") && dr.BankruptcyDate < DateTime.Parse("1998/6/17")&& ts.Days <= 2*365)
						{
							dr.CSLEligibleForDischargeDate = dr.CeasedToBeStudentDate.AddYears(2);
							dr.CSLNonDischargeable = true;
						}
						else
						{
							dr.CSLEligibleForDischargeDate = dr.BankruptcyDate.AddMonths(9);
							dr.CSLNonDischargeable=false;
						}
                        dr.EndEdit();
                    }

                    CalculateDurationOfBankruptcy(dr);

                    break;
                case "InsolvencyPeriod":
                    CalculateDurationOfBankruptcy(dr);
                    break;
                case "DateofTrusteeDischarge":
					if (!dr.IsDateofTrusteeDischargeNull())
						dr.StayOfProceeding = false;
                    dr.EndEdit();
                    break;
				default:
					break;
			}
		}

        protected void CalculateDurationOfBankruptcy(CLAS.BankruptcyRow dr)
        {
            if (!dr.IsBankruptcyDateNull() && !dr.IsInsolvencyPeriodNull())
            {
                dr.DebtorDischargeNonCSLDebtDate = dr.BankruptcyDate.AddMonths(dr.InsolvencyPeriod);
                dr.EndEdit();
            }

        }
        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.BankruptcyRow bkr = (CLAS.BankruptcyRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(bkr.FileID, atSecurity.SecurityManager.Features.Bankruptcy);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }


        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.BankruptcyRow bkr = (CLAS.BankruptcyRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(bkr.FileID, atSecurity.SecurityManager.Features.Bankruptcy);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

		protected override void BeforeDelete(DataRow row)
		{
			CLAS.BankruptcyRow dr = (CLAS.BankruptcyRow) row;
			string ObjectName = this.myBankruptcyDT.TableName;
			this.myA.FM.GetActivity().DeleteRelatedCA(dr.FileID, ObjectName,dr.BankruptcyID);

            //remove node from file struct
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;

            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='bankruptcy' and @id=" + dr.BankruptcyID.ToString() + "]");
            if (xe != null)
                xe.ParentNode.RemoveChild(xe);

            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;

            //    DropCurrentNode Me.Parent, LCase(csObjectName), LCase(csPKName), Me.Field(csPKName)
		}
		
        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[]{this.myA.FM.CurrentFile};
        //}

		public override DataRow[] GetCurrentRow()
		{
			//this.LoadByFileId(this.myA.FM.CurrentFile.FileId);

			if(this.myBankruptcyDT.Rows.Count==1)
				return this.myBankruptcyDT.Select();
			else
				return this.myBankruptcyDT.Select();
		}

		public override string PromptColumnName()
		{
			return "BankruptcyDate";
		}

        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.BankruptcyRow br = myBankruptcyDT.FindByBankruptcyID(id);

            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();

            foreach (CLAS.BankruptcyAccountRow bar in br.GetBankruptcyAccountRows())
            {
                l.Add(bar.FileAccountID);
            }
            return l;
        }
	}
}

