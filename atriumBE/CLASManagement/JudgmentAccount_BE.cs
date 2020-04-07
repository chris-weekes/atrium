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
	public class JudgmentAccountBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.JudgmentAccountDataTable myJudgmentAccountDT;
		

		internal JudgmentAccountBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.JudgmentAccount)
		{
			myA=pBEMng;
			myJudgmentAccountDT=(CLAS.JudgmentAccountDataTable)myDT;

            this.myJudgmentAccountDT.PrincipalAmountBeforeJudgmentColumn.ExtendedProperties.Add("format", "C");
            this.myJudgmentAccountDT.CostAmountColumn.ExtendedProperties.Add("format", "C");
            this.myJudgmentAccountDT.JudgmentAmountColumn.ExtendedProperties.Add("format", "C");
            this.myJudgmentAccountDT.PreJudgmentInterestAmountColumn.ExtendedProperties.Add("format", "C");
            this.myJudgmentAccountDT.PostJudgmentInterestRateColumn.ExtendedProperties.Add("format","#0.0#\\%");
            this.myJudgmentAccountDT.PostJIntRateOnCostColumn.ExtendedProperties.Add("format", "#0.0#\\%");
            this.myJudgmentAccountDT.PreJudgmentInterestRateColumn.ExtendedProperties.Add("format", "#0.0#\\%");
        }
        public atriumDAL.JudgmentAccountDAL myDAL
        {
            get
            {
                return (atriumDAL.JudgmentAccountDAL)myODAL;
            }
        }
	

		protected override void AfterAdd(DataRow row)
		{
			CLAS.JudgmentAccountRow dr=(CLAS.JudgmentAccountRow)row;
			string ObjectName = this.myJudgmentAccountDT.TableName;

			dr.JudgmentAccountID= this.myA.AtMng.PKIDGet(ObjectName,1);

            dr.CostAmount = 0;
            dr.PrincipalAmountBeforeJudgment = 0;
            dr.PreJudgmentInterestAmount = 0;
            
		}

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.JudgmentAccountRow or = (CLAS.JudgmentAccountRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.JudgmentAccount);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.JudgmentAccountRow fo = (CLAS.JudgmentAccountRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.JudgmentAccount);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

		protected override void BeforeUpdate(DataRow ddr)
		{
			CLAS.JudgmentAccountRow dr=(CLAS.JudgmentAccountRow)ddr;

            if (dr.RowState== DataRowState.Added && !dr.Include)
            { 
                dr.Delete();
                //2016-05-03 JLL: without the return below, object reference errors are thrown below when judgment accounts are de-selected from AC 404
                return;
            }

			if(dr.JudgmentRow.IsJudgmentDateNull() || dr.JudgmentRow.IsNull(dr.JudgmentRow.Table.Columns["JudgmentDate"],DataRowVersion.Original))
			{
				CLAS.DebtRow debtR=dr.DebtRow;

				if(!dr.JudgmentRow.IsJudgmentDateNull())
				{
					debtR.LPCode="8";
					debtR.LPDate=dr.JudgmentRow.JudgmentDate;
					debtR.LPExpires=dr.JudgmentRow.JudgmentLPDate;
					debtR.CurrentTo=dr.JudgmentRow.JudgmentDate;
					debtR.PrincipalAmount=dr.JudgmentAmount;
					debtR.InterestAmount=0;
					debtR.InterestRate=dr.IsPostJudgmentInterestRateNull() ? 0: dr.PostJudgmentInterestRate;
                    if(dr.IsPostJudgmentRateTypeNull())
					    debtR.RateType= dr.PostJudgmentRateType;
					debtR.InterestFromDate=dr.AccruedFromDate;
				}

                //the following code is obsolete as of nov 26 2008 per chris and jean
                //else
                //{
                //    if(!dr.IsPrincipalAmountBeforeJudgmentNull())
                //        debtR.PrincipalAmount=dr.PrincipalAmountBeforeJudgment;
			
                //    if(!dr.IsPreJudgmentInterestToNull())
                //        debtR.CurrentTo=dr.PreJudgmentInterestTo;
			
                //    if(!dr.IsPreJudgmentInterestAmountNull())
                //        debtR.InterestAmount=dr.PreJudgmentInterestAmount;
			
                //    if(!dr.IsPreJudgmentInterestRateNull())
                //        debtR.InterestRate=dr.PreJudgmentInterestRate;
			
                //    if(!dr.IsPreJudgmentInterestFromNull())
                //        debtR.InterestFromDate=dr.PreJudgmentInterestFrom;
			
                //    if(!dr.IsPreJudgmentRateTypeNull())
                //        debtR.RateType=dr.PreJudgmentRateType;
                //}
				//debtR.EndEdit();
			}
		}


		protected  override void AfterChange(DataColumn dc, DataRow ddr)
		{
			string ObjectName = this.myJudgmentAccountDT.TableName;
			CLAS.JudgmentAccountRow dr=(CLAS.JudgmentAccountRow)ddr;
			switch(dc.ColumnName)
			{
                case JudgmentAccountFields.CostAmount:
                case JudgmentAccountFields.PreJudgmentInterestAmount:
                case JudgmentAccountFields.PrincipalAmountBeforeJudgment:
                    if (!dr.IsCostAmountNull() && !dr.IsPreJudgmentInterestAmountNull() && !dr.IsPrincipalAmountBeforeJudgmentNull())
                    {
                        dr.JudgmentAmount = dr.CostAmount + dr.PreJudgmentInterestAmount + dr.PrincipalAmountBeforeJudgment;
                        dr.EndEdit();
                    }
                    break;
				case "Include":
					break;
			}
		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myJudgmentAccountDT.TableName;
			CLAS.JudgmentAccountRow dr=(CLAS.JudgmentAccountRow)ddr;
			switch(dc.ColumnName)
			{
				case "CostDate":
                    if (dr.IsCostDateNull())
                        throw new RequiredException(Resources.JudgmentAccountCostDate);
                    if (dr.JudgmentRow.IsJudgmentDateNull())
                        throw new RelatedException(Resources.JudgmentAccountCostDate, Resources.JudgmentJudgmentDate);
                    myA.IsValidDate(Resources.JudgmentAccountCostDate, dr.CostDate, true, dr.JudgmentRow.JudgmentDate, DateTime.Today, Resources.JudgmentJudgmentDate, Resources.ValidationToday);
					break;
				case "CostAmount":
                    if (!dr.IsCostAmountNull() && (dr.CostAmount < 0))
                        throw new AtriumException(Resources.MustBeGreaterThanZero, Resources.JudgmentAccountCostAmount);
                    if (!dr.IsCostAmountNull() && dr.CostAmount > 40000)
                        RaiseWarning(WarningLevel.Interrupt, Properties.Resources.CostShouldNotBeGreaterThanX);
					break;
				case "InterestIncluded":
					break;
				case "JudgmentAmount":
                    if (dr.JudgmentAmount != dr.CostAmount + dr.PreJudgmentInterestAmount + dr.PrincipalAmountBeforeJudgment)
                        throw new AtriumException(Resources.JudgmentAccountInvalidJudgAmt);

					if (!dr.IsJudgmentAmountNull() && (dr.JudgmentAmount < 0))
                        throw new AtriumException(Resources.MustBeGreaterThanZero, Resources.JudgmentAccountJudgmentAmount);
                    if (!dr.IsJudgmentAmountNull() && (dr.JudgmentAmount > 100000))
                        RaiseWarning(WarningLevel.Interrupt, Properties.Resources.JudgmentAmountShouldNotBeGreaterThanX);
                    break;
				case "PostJudgmentInterestRate":
                    if (dr.IsPostJudgmentInterestRateNull() || dr.PostJudgmentInterestRate > 60 || dr.PostJudgmentInterestRate < 0)
                        throw new AtriumException(Resources.InvalidInterestRate, Resources.JudgmentAccountPostJudgmentInterestRate);
					break;
				case "PreJudgmentInterestRate":
					if (dr.IsPreJudgmentInterestRateNull() || dr.PreJudgmentInterestRate > 60 || dr.PreJudgmentInterestRate < 0)
                        throw new AtriumException(Resources.InvalidInterestRate, Resources.JudgmentAccountPreJudgmentInterestRate);
					break;
				case "PostJudgmentRateType":
                    if (!myA.CheckDomain(dr.PostJudgmentRateType, myA.FM.Codes("InterestRateType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Interest Rate Type");
					break;
				case "PreJudgmentInterestAmount":
                    if (!dr.IsPreJudgmentInterestAmountNull() && (dr.PreJudgmentInterestAmount > 100000))
                        RaiseWarning(WarningLevel.Interrupt, Properties.Resources.AmountNotGreaterThan,"Pre-Judgment Interest Amount",100000);
					break;
				case "PreJudgmentRateType":
                    if (!myA.CheckDomain(dr.PreJudgmentRateType, myA.FM.Codes("InterestRateType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Interest Rate Type");
					break;
				case "PrincipalAmountBeforeJudgment":
                    if (!dr.IsPrincipalAmountBeforeJudgmentNull() && (dr.PrincipalAmountBeforeJudgment > 100000))
                        RaiseWarning(WarningLevel.Interrupt, Properties.Resources.AmountNotGreaterThan, "Principal Amount Before Judgment", 100000);
                    break;
                default:
					break;
			}
		}
        
    

		public override DataRow[] GetCurrentRow()
		{
           
			return this.myJudgmentAccountDT.Select();
		}

        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.JudgmentAccountRow ahr = myJudgmentAccountDT.FindByJudgmentAccountID(id);
            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
            l.Add(ahr.FileAccountID);
            return l;
        }
    }
}

