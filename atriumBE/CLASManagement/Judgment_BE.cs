using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class JudgmentBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.JudgmentDataTable myJudgmentDT;
		
		internal JudgmentBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Judgment)
		{
			myA=pBEMng;
			myJudgmentDT=(CLAS.JudgmentDataTable)myDT;

			this.myJudgmentDT.JudgmentAmountColumn.ExtendedProperties.Add("format","C");
			this.myJudgmentDT.PrincipalAmountBeforeJudgmentColumn.ExtendedProperties.Add("format","C");
			this.myJudgmentDT.PreJudgmentInterestAmountColumn.ExtendedProperties.Add("format","C");
			this.myJudgmentDT.CostAmountColumn.ExtendedProperties.Add("format","C");
        }
        public atriumDAL.JudgmentDAL myDAL
        {
            get
            {
                return (atriumDAL.JudgmentDAL)myODAL;
            }
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.JudgmentRow or = (CLAS.JudgmentRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.FileID, atSecurity.SecurityManager.Features.Judgment);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.JudgmentRow fo = (CLAS.JudgmentRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.FileID, atSecurity.SecurityManager.Features.Judgment);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

       protected override void AfterUpdate(DataRow dr)
        {
            CLAS.JudgmentRow r = (CLAS.JudgmentRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }
        private void MyXml(CLAS.JudgmentRow jr, System.Xml.XmlDocument xd)
        {
            if (jr.ProcessTypeCode != "TP")
            {
                System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='judgment' and @id=" + jr.JudgmentID.ToString() + "]");
                if (xe == null)
                {
                    xe = xd.CreateElement("toc");
                    xe.SetAttribute("type", "judgment");
                }
                xe.SetAttribute("id", jr.JudgmentID.ToString());
                string title = "";
                bool isTextStruckout = false;
                if (!jr.IsActionNumberNull())
                {
                    title += jr.ActionNumber;
                }

                if (!jr.IsWithdrawalRemovalDateNull())
                {
                    isTextStruckout = true;
                    string withdrawnTooltipE= "Judgment Withdrawal/Removal Date: " + jr.WithdrawalRemovalDate.ToString("yyyy/MM/dd");
                    string withdrawnTooltipF = "Jugement retiré le : " + jr.WithdrawalRemovalDate.ToString("yyyy/MM/dd");

                    xe.SetAttribute("tooltipe", withdrawnTooltipE);
                    xe.SetAttribute("tooltipf", withdrawnTooltipF);
                    title += " (" + Properties.Resources.JudgmentJudgmentDate + " " + jr.JudgmentDate.ToString("yyyy/MM/dd") + ")";
                }
                else if (!jr.IsJudgmentDateNull())
                {
                    title += " (" + Properties.Resources.JudgmentJudgmentDate + " " + jr.JudgmentDate.ToString("yyyy/MM/dd") + ")";

                }
                else if (!jr.IsDefenceDateNull())
                {
                    title += " (" + Properties.Resources.JudgmentDefenceDate + " " + jr.DefenceDate.ToString("yyyy/MM/dd") + ")";

                }
                else if (!jr.IsStatementofClaimServedDateNull())
                {
                    title += " (" + Properties.Resources.JudgmentStatementofClaimServedDate + " " + jr.StatementofClaimServedDate.ToString("yyyy/MM/dd") + ")";
                }
                else if (!jr.IsStatementofClaimIssuedDateNull())
                {
                    title += " (" + Properties.Resources.JudgmentStatementofClaimIssuedDate + " " + jr.StatementofClaimIssuedDate.ToString("yyyy/MM/dd") + ")";
                }


                xe.SetAttribute("titlee", title);
                xe.SetAttribute("titlef", title);
                xe.SetAttribute("strikeout", isTextStruckout.ToString().ToLower());
                
                

                if (xe.ParentNode == null)
                {
                    System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "judgment", "Litigation", "Litige", 250);
                    xes.AppendChild(xe);
                }

            }
        }
		public  void MyXml(atriumDB.EFileRow efr,System.Xml.XmlDocument xd)
		{
            WritBE wbe = this.myA.GetWrit();
            
            CostBE cbe = this.myA.GetCost();
            
            PropertyBE pbe = this.myA.GetProperty();
            
            foreach (CLAS.JudgmentRow jr in myJudgmentDT)
            {
                MyXml(jr, xd);
                wbe.MyXml(jr, xd);
                cbe.MyXml(jr, xd);

            }
            

		}

        // JLL: 2012/06/15 
        //I think this should be moved to ObjectBE
        //
        protected bool IsFieldChanged(DataColumn dc, DataRow dr)
        {
            if (dr.RowState == DataRowState.Detached)
                return false;

            if (dr.HasVersion(DataRowVersion.Proposed))
            {
                if (!dr[dc, DataRowVersion.Current].Equals(dr[dc, DataRowVersion.Proposed]))
                {
                    return true;
                }
                else
                    return false;
            }
            else if (dr.HasVersion(DataRowVersion.Original))
            {
                if (!dr[dc, DataRowVersion.Current].Equals(dr[dc, DataRowVersion.Original]))
                {
                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }


		protected override void AfterChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myJudgmentDT.TableName;

			CLAS.JudgmentRow dr=(CLAS.JudgmentRow)ddr;
			switch(dc.ColumnName)
			{
                case "OfficeID":
				case "JudgmentDate":
					if(!dr.IsJudgmentDateNull() &&!dr.IsOfficeIDNull())
					{    
                        officeDB.OfficeRow drOffice = this.myA.AtMng.GetOffice(dr.OfficeID).CurrentOffice;
                        if (!drOffice.IsJudgmentLPNull())
                        {


                            dr.JudgmentLPDate = dr.JudgmentDate.AddYears(drOffice.JudgmentLP);
                        }
                        else
                        {
                            dr.JudgmentLPDate = dr.JudgmentDate.AddYears(10);
                        }


                        myA.FM.GetActivityBF().MaintainBFDate(dr.JudgmentID, "Judgment", "JUDGMENTLPDATE", dr.JudgmentLPDate);
                        dr.EndEdit();
					}
					break;
                case "JudgmentLPDate":
                    myA.FM.GetActivityBF().MaintainBFDate(dr.JudgmentID, "Judgment", "JUDGMENTLPDATE", dr.JudgmentLPDate);
                    break;
                case "SetJudgmentAccountDefaults":
                    if(dr.SetJudgmentAccountDefaults)
                        SetJudgmentAccountDefaultValues(dr);
                    break;
				default:
					break;
			}


		}

        private void SetJudgmentAccountDefaultValues(CLAS.JudgmentRow jr)
        {
            foreach (CLAS.JudgmentAccountRow jar in jr.GetJudgmentAccountRows())
            {
                jar.PrincipalAmountBeforeJudgment = jar.DebtRow.PrincipalAmount;
                jar.PreJudgmentInterestRate = jar.DebtRow.InterestRate;
                jar.PreJudgmentRateType = jar.DebtRow.RateType;
                if(!jar.DebtRow.IsInterestFromDateNull())
                    jar.PreJudgmentInterestFrom = jar.DebtRow.InterestFromDate;
                jar.PreJudgmentInterestTo = jar.DebtRow.CurrentTo;
                jar.PreJudgmentInterestAmount = jar.DebtRow.InterestAmount;
                jar.AccruedFromDate = jr.JudgmentDate;
                jar.CostAmount = 0;
                //for read reference only
                jar.DARSAccountType = jar.DebtRow.DARSAccountType;

            }
        }

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myJudgmentDT.TableName;
			CLAS.JudgmentRow dr=(CLAS.JudgmentRow)ddr;
			switch(dc.ColumnName)
			{
				case "JudgmentID":
					//					if CLng(vNewValue) <> mrst(dc.ColumnName))
					//						Me.Find vNewValue
					//					End If
					break;
				case "ActionNumber":
                    if (dr.IsActionNumberNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentActionNumber);
					break;
				case "JudgmentCourtLevelCode":
                    if (dr.IsJudgmentCourtLevelCodeNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentJudgmentCourtLevelCode);
                    else if (!myA.CheckDomain(dr.JudgmentCourtLevelCode, myA.FM.Codes("JudgmentCourtLevel")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Judgment Court Level");
					break;
				case "OfficeID":
                    if (dr.IsOfficeIDNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentOfficeID);
                    else if (!myA.CheckDomain(dr.OfficeID, myA.FM.Codes("officelist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
					break;
				case "StatementofClaimIssuedDate":
                    if (dr.IsStatementofClaimIssuedDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentStatementofClaimIssuedDate);
                    myA.IsValidDate(atriumBE.Properties.Resources.JudgmentStatementofClaimIssuedDate, dr.StatementofClaimIssuedDate, false, DebtorBE.CSLBegin, DateTime.Today, atriumBE.Properties.Resources.ValidationCSLBegin,atriumBE.Properties.Resources.ValidationToday);
					break;
				case "StatementofClaimServedDate":
                    if (dr.IsStatementofClaimServedDateNull()  & !dr.IsDefenceDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentStatementofClaimServedDate);
                    if (!dr.IsStatementofClaimServedDateNull())
                    {
                        if (dr.IsStatementofClaimIssuedDateNull())
                            throw new RelatedException(atriumBE.Properties.Resources.JudgmentStatementofClaimServedDate, atriumBE.Properties.Resources.JudgmentStatementofClaimIssuedDate);
                        this.myA.IsValidDate(atriumBE.Properties.Resources.JudgmentStatementofClaimServedDate, dr.StatementofClaimServedDate, true, dr.StatementofClaimIssuedDate, DateTime.Today, atriumBE.Properties.Resources.JudgmentStatementofClaimIssuedDate, atriumBE.Properties.Resources.ValidationToday);
                    }
					break;
				case "DefenceDate":
                    //2017-09-20 commented out ... otherwise we're saying: once you've provided value, you can't remove it.  odd rule.
                    //if (dr.IsDefenceDateNull())
                    //    throw new RequiredException(atriumBE.Properties.Resources.JudgmentDefenceDate);
					if(dr.IsStatementofClaimServedDateNull())
                        throw new RelatedException(atriumBE.Properties.Resources.JudgmentDefenceDate, atriumBE.Properties.Resources.JudgmentStatementofClaimServedDate);
                    if(!dr.IsDefenceDateNull())
                        myA.IsValidDate(atriumBE.Properties.Resources.JudgmentDefenceDate, dr.DefenceDate, true, dr.StatementofClaimServedDate, DateTime.Today, atriumBE.Properties.Resources.JudgmentStatementofClaimServedDate,atriumBE.Properties.Resources.ValidationToday);
					break;
				case "ClaimAgainstCrown":
                    if (dr.IsClaimAgainstCrownNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentClaimAgainstCrown);
					if(dr.IsStatementofClaimIssuedDateNull())
                        throw new RelatedException(atriumBE.Properties.Resources.JudgmentClaimAgainstCrown,atriumBE.Properties.Resources.JudgmentStatementofClaimIssuedDate);
					myA.IsValidDate(atriumBE.Properties.Resources.JudgmentClaimAgainstCrown, dr.ClaimAgainstCrown, true, dr.StatementofClaimIssuedDate, DateTime.Today, atriumBE.Properties.Resources.JudgmentStatementofClaimIssuedDate,atriumBE.Properties.Resources.ValidationToday);
					break;
				case "JudgmentDate":
                    if (dr.IsJudgmentDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentJudgmentDate);
					if (!dr.IsStatementofClaimIssuedDateNull())
                        myA.IsValidDate(atriumBE.Properties.Resources.JudgmentJudgmentDate, dr.JudgmentDate, true,  dr.StatementofClaimIssuedDate,  DateTime.Today, atriumBE.Properties.Resources.JudgmentStatementofClaimIssuedDate,atriumBE.Properties.Resources.ValidationToday);
					else
                        myA.IsValidDate(atriumBE.Properties.Resources.JudgmentJudgmentDate, dr.JudgmentDate, true,  DebtorBE.CSLBegin,  DateTime.Today, atriumBE.Properties.Resources.ValidationCSLBegin, atriumBE.Properties.Resources.ValidationToday);
					break;
				case "JudgmentLPDate":
                    if (dr.IsJudgmentLPDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.JudgmentJudgmentLPDate);
                    if (dr.IsJudgmentDateNull())
                        throw new RelatedException(atriumBE.Properties.Resources.JudgmentJudgmentLPDate, atriumBE.Properties.Resources.JudgmentJudgmentDate);
					this.myA.IsValidDate(atriumBE.Properties.Resources.JudgmentJudgmentLPDate, dr.JudgmentLPDate, true, dr.JudgmentDate, DateTime.Today.AddYears(30), atriumBE.Properties.Resources.JudgmentJudgmentDate,atriumBE.Properties.Resources.ValidationThirtyYearsLater);
					break;
				case "JudgmentTypeCode":
                    if (!myA.CheckDomain(dr.JudgmentTypeCode, myA.FM.Codes("JudgmentType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Judgment Type");
					break;
                case "ProcessTypeCode":
                    if (!myA.CheckDomain(dr.ProcessTypeCode, myA.FM.Codes("ProcessType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Legal Process Type");
                    break;
				default:
					break;
			}
		}
		
		protected override void AfterAdd(DataRow row)
		{
			CLAS.JudgmentRow dr=(CLAS.JudgmentRow)row;
			string ObjectName = this.myJudgmentDT.TableName;

			dr.JudgmentID = this.myA.AtMng.PKIDGet(ObjectName,1);
            dr.FileID = myA.FM.CurrentFile.FileId;
			dr.CombineAccountsAfterJudgment=false;
			dr.OfficeID=this.myA.FM.CurrentFile.LeadOfficeId;
			//copy over active accounts

			JudgmentAccountBE jaBE=this.myA.GetJudgmentAccount();
			

			foreach(CLAS.DebtRow debtr in this.myA.DB.Debt)
			{
				//&& debtr.IsClosureCodeNull()
				if(debtr.ActiveWithJustice) //  && debtr.OfficeID==debtr.EFileRow.LeadOfficeId) JLL 2010-08-11 Review this check
				{
					CLAS.JudgmentAccountRow jar=(CLAS.JudgmentAccountRow)jaBE.Add(dr);
					jar.BeginEdit();
					jar.FileAccountID=debtr.FileAccountId;
					jar.AccountTypeCode=debtr.AccountTypeCode;
                    jar.AccountTypeId = debtr.AccountTypeId;
                    jar.AccountTypeDescEng = debtr.AccountTypeDescEng;
                    jar.AccountTypeDescFre = debtr.AccountTypeDescEng;
                    jar.DARSAccountType = debtr.DARSAccountType;
                    jar.AccountPrincipal = debtr.PrincipalAmount;
					jar.Include=true;
					jar.EndEdit();
				}

			}
		}

		protected override void BeforeUpdate(DataRow row)
		{
			CLAS.JudgmentRow dr = (CLAS.JudgmentRow) row;
			this.BeforeChange(dr.Table.Columns["ActionNumber"],dr);
			this.BeforeChange(dr.Table.Columns["JudgmentCourtLevelCode"], dr);
			this.BeforeChange(dr.Table.Columns["StatementofClaimIssuedDate"],dr);

		}

		protected override void BeforeDelete(DataRow row) 
		{
			CLAS.JudgmentRow dr =(CLAS.JudgmentRow) row;
			string ObjectName = this.myJudgmentDT.TableName;
			this.myA.FM.GetActivity().DeleteRelatedCA(dr.FileID,ObjectName,dr.JudgmentID);
		}

    

		public override DataRow[] GetCurrentRow()
		{
			
				return this.myJudgmentDT.Select();
		}

		public override string PromptColumnName()
		{
			return "ActionNumber,StatementofClaimIssuedDate,JudgmentDate" ;
		}

		public override string FriendlyName()
		{
			return Properties.Resources.JudgmentFN;
		}
		public override string PromptFormat()
		{
			return Properties.Resources.JudgmentPF;
		}
        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.JudgmentRow jr = myJudgmentDT.FindByJudgmentID(id);

            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();

            foreach (CLAS.JudgmentAccountRow jar in jr.GetJudgmentAccountRows())
            {
                l.Add(jar.FileAccountID);
            }
            return l;
        }


	}

	public class FCCProcessBE:JudgmentBE
	{
	
		internal FCCProcessBE(CLASManager pBEMng):base(pBEMng)
		{
		}
	}
}

