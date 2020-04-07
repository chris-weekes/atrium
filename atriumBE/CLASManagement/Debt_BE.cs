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
	public class DebtBE:FileAccountBE
	{
		CLASManager myA;
		CLAS.DebtDataTable myDebtDT;
		
		internal DebtBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Debt)
		{
			myA=pBEMng;
			myDebtDT=(CLAS.DebtDataTable)myDT;

			this.myDebtDT.PrincipalAmountColumn.ExtendedProperties.Add("format","C");
			this.myDebtDT.InterestAmountColumn.ExtendedProperties.Add("format","C");
			this.myDebtDT.InterestRateColumn.ExtendedProperties.Add("format","#0.0#\\%");
			this.myDebtDT.CurrentLiabilityColumn.ExtendedProperties.Add("format","C");
        }
        public atriumDAL.DebtDAL myDAL
        {
            get
            {
                return (atriumDAL.DebtDAL)myODAL;
            }
        }

        public decimal TotalOutstanding()
        {
            decimal total=0;
            foreach (CLAS.DebtRow dr in myDebtDT)
            {
                total += dr.CurrentLiability;
            }

            return total;
        }

		protected override void AfterAdd(DataRow row)
		{
			base.AfterAdd(row );
			CLAS.DebtRow dr=(CLAS.DebtRow)row;
			string ObjectName = this.myDebtDT.TableName;
            dr.FileId = myA.FM.CurrentFileId;
			dr.DebtId= dr.FileAccountId;
            dr.OfficeID = myA.FM.CurrentFile.LeadOfficeId;
			dr.MSOAOverDARS=false;
			dr.MSOARequest=false;
			dr.StatementRequest=false;
            dr.ReceivedByJusticeDate = myA.FM.CurrentFile.OpenedDate;
            dr.StatBarred = false;

		}

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.DebtRow debtRow = (CLAS.DebtRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(debtRow.FileId, atSecurity.SecurityManager.Features.Debt);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.DebtRow fhr = (CLAS.DebtRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fhr.FileId, atSecurity.SecurityManager.Features.Debt);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.DebtRow r = (CLAS.DebtRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }
        private void MyXml(CLAS.DebtRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='account' and @id=" + r.FileAccountId.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "account");
                xe.SetAttribute("supertype", "debt");
            }

            string dType="DARS";
            if (r.MSOAOverDARS)
                dType = "MSOA";
            if (r.StatBarred)
                dType = Properties.Resources.TocDebtStatuteBarred;

            xe.SetAttribute("id", r.FileAccountId.ToString());
            xe.SetAttribute("titlee", r["AccountTypeCode"].ToString() + " (" + r["DARSAccountType"].ToString() + ") - " + dType);
            xe.SetAttribute("titlef", r["AccountTypeCode"].ToString() + " (" + r["DARSAccountType"].ToString() + ") - " + dType);

            if (r.ActiveWithJustice)
            {
                xe.SetAttribute("tooltipe", r["AccountTypeDescEng"].ToString() + " / Active");
                xe.SetAttribute("tooltipf", r["AccountTypeDescEng"].ToString() + " / Actif");
                xe.SetAttribute("strikeout", "false");
            }
            else
            {
                if (r.StatBarred)
                {
                    xe.SetAttribute("tooltipe", r["AccountTypeDescEng"].ToString() + " / Statute-Barred");
                    xe.SetAttribute("tooltipf", r["AccountTypeDescEng"].ToString() + " / Prescrit");
                }
                else
                {
                    xe.SetAttribute("tooltipe", r["AccountTypeDescEng"].ToString() + " / Non-Active");
                    xe.SetAttribute("tooltipf", r["AccountTypeDescEng"].ToString() + " / Non actif");
                }
    
                xe.SetAttribute("strikeout", "true");
            }

            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "account", "Accounts", "Comptes",220);
                xes.AppendChild(xe);
            }
        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {
            foreach (CLAS.DebtRow r in myDebtDT)
            {
                MyXml(r, xd);
            }
        }


		protected  override void AfterChange(DataColumn dc, DataRow ddr)
		{
			base.AfterChange (dc, ddr);
			string ObjectName = this.myDebtDT.TableName;
			CLAS.DebtRow dr=(CLAS.DebtRow)ddr;
			switch(dc.ColumnName)
			{
                case DebtFields.InterestAmount:
                case DebtFields.PrincipalAmount:
                    dr.CurrentLiability =(dr.IsInterestAmountNull()? 0: dr.InterestAmount) + (dr.IsPrincipalAmountNull()? 0: dr.PrincipalAmount);
                    dr.EndEdit();
                    break;
				case DebtFields.MSOAOverDARS:
					if(dr.MSOAOverDARS)
						dr.StatementRequest=false;
                    dr.EndEdit();

					break;
				case DebtFields.DebtId:
					dr.FileAccountId=dr.DebtId;
                    dr.EndEdit();
                    break;
				case "FileAccountId":
					dr.DebtId=dr.FileAccountId;
                    dr.EndEdit();
                    break;
                case DebtFields.LPExpires:
                    myA.FM.GetActivityBF().MaintainBFDate(dr.DebtId, "DEBT", "CURRENTLPDATE", dr.LPExpires);

                    CLAS.AccountHistoryRow[] ahrs = (CLAS.AccountHistoryRow[])myA.DB.AccountHistory.Select("ReceivedFromOfficeDate is null and FileAccountId=" + dr.DebtId.ToString());
                    if (ahrs.Length > 0)
                    {
                        myA.FM.GetActivityBF().MaintainBFDate(ahrs[0].AccountHistoryId, "ACCOUNTHISTORY", "CURRENTLPDATE", dr.LPExpires);
                    }

                    //jll: 2014-05-30 set stat barred 
                    dr.StatBarred = dr.LPExpires < DateTime.Today;

                    if (dr.StatBarred)
                        dr.ActiveWithJustice = false;
                    dr.EndEdit();
                    
                    break;
			}

		}

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			base.BeforeChange(dc,ddr);
			string ObjectName = this.myDebtDT.TableName;
			CLAS.DebtRow dr=(CLAS.DebtRow)ddr;
			DataRow acctR;
			switch(dc.ColumnName)
			{
                case "AccountTypeId":
                    if (!myA.CheckDomain(dr.AccountTypeId, myA.FM.Codes("vaccounttypelist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Account Type List");
                    break;
                case "RateType":
                    if (!myA.CheckDomain(dr.RateType, myA.FM.Codes("InterestRateType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Interest Rate Type");
                    break;
                case DebtFields.DARSOccurenceDate:
                    if (dr.IsDARSOccurenceDateNull() & dr.AccountTypeCode == "CSL")
                        throw new RequiredException(Resources.DebtDARSOccuranceDate);
                    break;
                case "InvoiceNumber":
                    if (dr.IsInvoiceNumberNull() & (dr.AccountTypeCode == "CPP" | dr.AccountTypeCode == "OAS"))
                        throw new RequiredException(Resources.DebtInvoiceNumber);
                    break;
                //case "SequenceBalance":
                //    if (dr.IsSequenceBalanceNull() & dr.AccountTypeCode == "EI")
                //        throw new RequiredException(Resources.DebtSequenceBalance);
                //    break;
				case "StatementRequest":
                    if (dr.MSOAOverDARS && dr.StatementRequest)
                        throw new AtriumException(Resources.MSOAOverDARS);
					break;
				case "InterestRate":
                    if (dr.IsInterestRateNull() || dr.InterestRate > 60 || dr.InterestRate < 0)
                        throw new AtriumException(Resources.InvalidInterestRate, Resources.DebtInterestRate);
					break;
				case "PrincipalAmount":
                    if (dr.IsPrincipalAmountNull())
                        throw new RequiredException(Resources.DebtPrincipalAmount);
                    else if (dr.PrincipalAmount > 100000)
                        RaiseWarning(WarningLevel.Interrupt, Properties.Resources.AmountNotGreaterThan,"Principal amount",100000);
					break;
                case "InterestAmount":
                    if (!dr.IsInterestAmountNull() && dr.InterestAmount > 100000)
                        RaiseWarning(WarningLevel.Interrupt, Properties.Resources.AmountNotGreaterThan, "Interest amount", 100000);
                    break;
                case "CurrentLiability":
                    if (!dr.IsCurrentLiabilityNull() && dr.CurrentLiability > 100000)
                        RaiseWarning(WarningLevel.Interrupt, Properties.Resources.AmountNotGreaterThan, "Current liability", 100000);
                    break;
                case "LPCode":
					 acctR=this.AccountTypeInfo(dr.AccountTypeId);
                     if (dr.IsLPCodeNull() && (acctR["AccountTypeCode"].ToString() != "CPP" && acctR["AccountTypeCode"].ToString() != "OAS"))
                         throw new RequiredException(Resources.DebtLPCode);
                     else if (!myA.CheckDomain(dr.LPCode, myA.FM.Codes("LP")))
                         throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Limitation Period Code");
					break;
				case "CurrentTo":
                    if (dr.IsCurrentToNull())
                        throw new RequiredException(Resources.DebtCurrentTo);
					myA.IsValidDate(Resources.DebtCurrentTo,dr.CurrentTo, false, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin,Resources.ValidationToday);
					break;
				case "InterestFromDate":
					if(!dr.IsInterestFromDateNull())
						myA.IsValidDate(Resources.DebtInterestFromDate, dr.InterestFromDate, true, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin,Resources.ValidationToday);
					//this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.CannotBeBlank, myA.GetLabelLeft(ObjectName, dc.ColumnName));
					break;
				case "LPDate":
					acctR=this.AccountTypeInfo(dr.AccountTypeId);
                    if (dr.IsLPDateNull() && (acctR["AccountTypeCode"].ToString() != "CPP" && acctR["AccountTypeCode"].ToString() != "OAS"))
                        throw new RequiredException(Resources.DebtLPDate);
					myA.IsValidDate(Resources.DebtLPDate,dr.LPDate, false, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin,Resources.ValidationToday);
					break;
				case "LPExpires":
					acctR=this.AccountTypeInfo(dr.AccountTypeId);
                    if (dr.IsLPExpiresNull() && (acctR["AccountTypeCode"].ToString() != "CPP" && acctR["AccountTypeCode"].ToString() != "OAS"))
                        throw new RequiredException(Resources.DebtLPExpires);

					if(!dr.IsLPDateNull())
						myA.IsValidDate(Resources.DebtLPExpires, dr.LPExpires, false, dr.LPDate, DateTime.Today.AddYears(20), Resources.DebtLPDate, Resources.Validation20YearsLater);
					break;
				default:
					break;
			}
		}

		protected override void BeforeUpdate(DataRow row) 
		{
			base.BeforeUpdate(row);
			CLAS.DebtRow dr = (CLAS.DebtRow) row;

			//this.BeforeChange(dr.Table.Columns["MostRecentPCACode"],dr);
			this.BeforeChange(dr.Table.Columns["InterestRate"],dr);
			this.BeforeChange(dr.Table.Columns["LPCode"],dr);
			this.BeforeChange(dr.Table.Columns["PrincipalAmount"],dr);
			this.BeforeChange(dr.Table.Columns["CurrentTo"],dr);
			this.BeforeChange(dr.Table.Columns["LPExpires"],dr);
			
			//opponentid on file is debtor
			//load account
			DataRow acctR=this.AccountTypeInfo(dr.AccountTypeId);
            CLAS.DebtorRow ddr = this.myA.GetDebtor().FindLoad(myA.FM.CurrentFile.OpponentID);

            if (ddr == null)
            {
                //must have a debtor if there is a debt
                throw new AtriumException("There must be a debtor to have a debt");
            }
            else
            {

                if (acctR["ProgramCode"].ToString() == "CSLP")
                {
                    if (ddr.IsCeasedToBeStudentDateNull())
                        throw new RequiredException(Resources.DebtPSED);

                    //JLL: still valid? 2014-03-10
                    //if (dr.IsDARSOccurenceDateNull())
                    //    throw new RequiredException(Resources.DebtDARSOccuranceDate);
                }
                else if (acctR["ProgramCode"].ToString() == "ISP")
                {
                    if (dr.IsInvoiceNumberNull() )
                        throw new RequiredException(Resources.DebtInvoiceNumber);
                }
                //else if (acctR["ProgramCode"].ToString() == "EI")
                //{
                //    if (dr.IsSequenceBalanceNull() )
                //        throw new RequiredException(Resources.DebtSequenceBalance);
                //}
                else if (acctR["ProgramCode"].ToString() == "EP")
                {
                }
                else if (acctR["ProgramCode"].ToString() == "FAS")
                {
                }

            }
		}

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[]{this.myA.FM.CurrentFile};
        //}

		public override DataRow[] GetCurrentRow()
		{
            //if(this.myDebtDT.Rows.Count==0)
            //    this.LoadByFileId(myA.FM.CurrentFile.FileId);
			return this.myDebtDT.Select();

		}

		public override string PromptColumnName()
		{
			return "AccountTypeCode,AccountTypeDesc"+ this.myA.AppMan.Language +",ReceivedByJusticeDate";
		}

		public override string FriendlyName()
		{
			return Resources.DebtFN;
		}

		public override string PromptFormat()
		{
            return Resources.DebtPF ;
		}

        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.DebtRow ahr =myDebtDT.FindByDebtId(id);
            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
            l.Add(ahr.FileAccountId);
            return l;
        }

	}
}

