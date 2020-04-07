using System;
using System.Data;
using atLogic;using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class InsolvencyBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.InsolvencyDataTable myInsolvencyDT;
		
		internal InsolvencyBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Insolvency)
		{
			myA=pBEMng;
			myInsolvencyDT=(CLAS.InsolvencyDataTable)myDT;

			this.myInsolvencyDT.ProvenClaimAmountColumn.ExtendedProperties.Add("format","C");
        }
        public atriumDAL.InsolvencyDAL myDAL
        {
            get
            {
                return (atriumDAL.InsolvencyDAL)myODAL;
            }
        }

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.InsolvencyRow r = (CLAS.InsolvencyRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.InsolvencyRow or = (CLAS.InsolvencyRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.FileID, atSecurity.SecurityManager.Features.Insolvency);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.InsolvencyRow fo = (CLAS.InsolvencyRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.FileID, atSecurity.SecurityManager.Features.Insolvency);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        private void MyXml(CLAS.InsolvencyRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='insolvency' and @id=" + r.InsolvencyID.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "insolvency");
            }
            xe.SetAttribute("id", r.InsolvencyID.ToString());

            string dischargeable = Properties.Resources.BKCSLDischargeable;
            if (r.CSLNonDischargeable)
                dischargeable = Properties.Resources.BKCSLNonDischargeable;

            string title = r.InsolvencyType.ToString();
            title+=" - " +r.InsolvencyFiledDate.ToString("yyyy/MM/dd") + dischargeable;
            xe.SetAttribute("titlee", title);
            xe.SetAttribute("titlef", title);
            if (!r.IsProvenClaimAmountNull())
            {
                xe.SetAttribute("tooltipee", r.ProvenClaimAmount.ToString("C"));
                xe.SetAttribute("tooltipef", r.ProvenClaimAmount.ToString("C"));
            }

            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "insolvency", "Insolvency", "Insolvabilité",240);
                xes.AppendChild(xe);
            }

        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
		{
			foreach(CLAS.InsolvencyRow r in myInsolvencyDT)
			{
                MyXml(r, xd);
			
			}
			


		}
        protected override void BeforeUpdate(DataRow dr)
        {
            this.BeforeChange(dr.Table.Columns[InsolvencyFields.InsolvencyFiledDate], dr);

        }
		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			CLAS.InsolvencyRow dr=(CLAS.InsolvencyRow)ddr;
			switch(dc.ColumnName)
			{
                case "InsolvencyPeriod":
                    if(!dr.IsInsolvencyPeriodNull() && (dr.InsolvencyType!="O" &&  (dr.InsolvencyPeriod<0 || dr.InsolvencyPeriod > 60)))
                        throw new AtriumException("Insolvency Period must be between {0} and {1} months", "0", "60");
                    if (!dr.IsInsolvencyPeriodNull() && (dr.InsolvencyType == "O" && (dr.InsolvencyPeriod < 0 || dr.InsolvencyPeriod > 150)))
                        throw new AtriumException("Insolvency Period must be between {0} and {1} months", "0", "150");
                    break;
                case InsolvencyFields.InsolvencyFiledDate:
                    if (dr.IsInsolvencyFiledDateNull())
                        throw new RequiredException(Properties.Resources.InsolvencyInsolvencyFiledDate);
                    myA.IsValidDate(atriumBE.Properties.Resources.InsolvencyInsolvencyFiledDate, dr.InsolvencyFiledDate, false, (dr.IsPreviousInsolvencyDateNull() ? DebtorBE.CSLBegin : dr.PreviousInsolvencyDate), DateTime.Today, "", atriumBE.Properties.Resources.ValidationToday);
                    break;
                case "ProofOfClaimFiledDate":
                    if (!dr.IsProofOfClaimFiledDateNull())
                    {
                        if (dr.IsInsolvencyFiledDateNull())
                            throw new RelatedException("Proof of Claim Filed Date", "Insolvency Filed Date");
                        myA.IsValidDate("Proof of Claim Filed Date", dr.ProofOfClaimFiledDate, true, dr.InsolvencyFiledDate, DateTime.Today, "Insolvency Filed Date", Properties.Resources.ValidationToday);
                    }
                    break;
                case "AcceptanceDate":
                    if (!dr.IsAcceptanceDateNull())
                    {
                        if (dr.IsInsolvencyFiledDateNull())
                            throw new RelatedException("Acceptance Date", "Insolvency Filed Date");
                        myA.IsValidDate("Acceptance Date", dr.AcceptanceDate, true, dr.InsolvencyFiledDate, DateTime.Today, "Insolvency Filed Date", Properties.Resources.ValidationToday);
                    }
                    break;
                case "DefaultDate":
                    if (!dr.IsDefaultDateNull())
                        myA.IsValidDate("Default Date", dr.DefaultDate, true, dr.AcceptanceDate, DateTime.Today, "Acceptance Date", Properties.Resources.ValidationToday);
                    break;
                case "InsolvencyFulfilledDate":
                    if (!dr.IsInsolvencyFulfilledDateNull())
                        myA.IsValidDate("Fulfilled Date", dr.InsolvencyFulfilledDate, true, dr.AcceptanceDate, DateTime.Today, "Acceptance Date", Properties.Resources.ValidationToday);
                    break;

                case "InsolvencyType":
                    if (!myA.CheckDomain(dr.InsolvencyType, myA.FM.Codes("InsolvencyType")))
                        throw new AtriumException(Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Insolvency Type");
                    break;
                case "OfficeID":
                    if (!myA.CheckDomain(dr.OfficeID, myA.FM.Codes("OfficeList")))
                        throw new AtriumException(Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office List");
                    break;
                default:
					break;
			}
		}
		protected override void AfterAdd(DataRow row)
		{
			CLAS.InsolvencyRow dr = (CLAS.InsolvencyRow) row;
			string ObjectName = this.myInsolvencyDT.TableName;

			dr.InsolvencyID = this.myA.AtMng.PKIDGet(ObjectName,1);
            dr.FileID = myA.FM.CurrentFile.FileId;
            dr.OfficeID = myA.FM.CurrentFile.LeadOfficeId;
			dr.StayOfProceeding=true;
			dr.CSLNonDischargeable=false;
            CLAS.DebtorRow ddr = this.myA.GetDebtor().FindLoad(myA.FM.CurrentFile.OpponentID);
			dr.CeasedToBeStudentDate=ddr.CeasedToBeStudentDate;

            InsolvencyAccountBE jaBE = this.myA.GetInsolvencyAccount();
            foreach (CLAS.DebtRow debtr in this.myA.DB.Debt)
            {

                if (debtr.ActiveWithJustice) //  && debtr.OfficeID==debtr.EFileRow.LeadOfficeId) JLL 2010-08-11 Review this check
                {
                    CLAS.InsolvencyAccountRow jar = (CLAS.InsolvencyAccountRow)jaBE.Add(dr);
                    jar.BeginEdit();
                    jar.FileAccountID = debtr.FileAccountId;
                    jar.Include = true;
                    jar.EndEdit();
                }

            }
		}
		protected override void AfterChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myInsolvencyDT.TableName;

			CLAS.InsolvencyRow dr=(CLAS.InsolvencyRow)ddr;
			switch(dc.ColumnName)
			{
				case InsolvencyFields.InsolvencyFiledDate:
					if (dr.IsCSLEligibleForDischargeDateNull() && !dr.IsCeasedToBeStudentDateNull())
					{
						TimeSpan ts = dr.InsolvencyFiledDate - dr.CeasedToBeStudentDate;
                        if (dr.InsolvencyFiledDate >= DateTime.Parse("2008/7/7") && (ts.Days <= 7 * 365))
                        {
                            dr.CSLEligibleForDischargeDate = dr.CeasedToBeStudentDate.AddYears(7);
                            dr.CSLNonDischargeable = true;
                        }
                        else if (dr.InsolvencyFiledDate >= DateTime.Parse("1998/6/18") && dr.InsolvencyFiledDate < DateTime.Parse("2008/7/7") && (ts.Days <= 10 * 365))
                        {
                            dr.CSLEligibleForDischargeDate = dr.CeasedToBeStudentDate.AddYears(10);
                            dr.CSLNonDischargeable = true;
                        }
						else if(dr.InsolvencyFiledDate >= DateTime.Parse("1997/9/30") && dr.InsolvencyFiledDate < DateTime.Parse("1998/6/17")&& ts.Days <= 2*365)
						{
							dr.CSLEligibleForDischargeDate = dr.CeasedToBeStudentDate.AddYears(2);
							dr.CSLNonDischargeable = true;
						}
						else
						{
							dr.CSLEligibleForDischargeDate = dr.InsolvencyFiledDate.AddMonths(9);
							dr.CSLNonDischargeable=false;
						}
                        dr.EndEdit();

					}
                    CalculateInsolvencyPeriod(dr);

                    break;
                case "InsolvencyPeriod":
                        CalculateInsolvencyPeriod(dr);
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

        protected void CalculateInsolvencyPeriod(CLAS.InsolvencyRow dr)
        {
            if (!dr.IsInsolvencyFiledDateNull() && !dr.IsInsolvencyPeriodNull() && !dr.IsNull("InsolvencyType") && dr.InsolvencyType!="OPD")
            {
                dr.DebtorDischargeNonCSLDebtDate = dr.InsolvencyFiledDate.AddMonths(dr.InsolvencyPeriod);
                dr.EndEdit();
            }
        }
        

		protected override void BeforeDelete(DataRow row) 
		{
			CLAS.InsolvencyRow dr = (CLAS.InsolvencyRow) row;
			string ObjectName = this.myInsolvencyDT.TableName;
			this.myA.FM.GetActivity().DeleteRelatedCA(dr.FileID,ObjectName, dr.InsolvencyID);
		}
		
   
		public override DataRow[] GetCurrentRow()
		{
           
				return this.myInsolvencyDT.Select();
		}

		public override string PromptColumnName()
		{
			return InsolvencyFields.InsolvencyType +","+InsolvencyFields.InsolvencyFiledDate;
		}

		public override string PromptFormat()
		{
			return Properties.Resources.InsolvencyPF;
		}

		public override string FriendlyName()
		{
			return Properties.Resources.InsolvencyFN;
		}

        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.InsolvencyRow ir = myInsolvencyDT.FindByInsolvencyID(id);
            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();

            foreach (CLAS.InsolvencyAccountRow iar in ir.GetInsolvencyAccountRows())
            {
                l.Add(iar.FileAccountID);
            }
            return l;
        }


	}
}

