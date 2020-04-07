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
	public class AccountHistoryBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.AccountHistoryDataTable myAccountHistoryDT;
		
		internal AccountHistoryBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.AccountHistory)
		{
			myA=pBEMng;
			myAccountHistoryDT=(CLAS.AccountHistoryDataTable)myDT;
        }
        public atriumDAL.AccountHistoryDAL myDAL
        {
            get
            {
                return (atriumDAL.AccountHistoryDAL)myODAL;
            }
        }


		protected  override void BeforeUpdate(DataRow ddr)
		{
			CLAS.AccountHistoryRow dr = (CLAS.AccountHistoryRow)ddr;
			if(this.myA.GetFileHistory().GetCurrentRow().Length!=0)
			{
				if(((CLAS.FileHistoryRow)this.myA.GetFileHistory().GetCurrentRow()[0]).IsReceivedByOfficeDateNull())
				{
					if(!dr.IsReceivedByOfficeDateNull())
                        throw new AtriumException(Resources.FileNotReceived);
				}
			}
			if(dr.IsReceivedByOfficeDateNull())
			{
                CLAS.DebtRow cddr = myA.DB.Debt.FindByDebtId(dr.FileAccountID);
				cddr.OfficeID = dr.OfficeId;
			}

		}


		protected  override void AfterAdd(DataRow ddr)
		{
			CLAS.AccountHistoryRow dr = (CLAS.AccountHistoryRow)ddr;
			string ObjectName = this.myAccountHistoryDT.TableName;

			if(dr.IsNull("AccountHistoryId"))
				dr.AccountHistoryId = this.myA.AtMng.PKIDGet(ObjectName,1);  

			if(dr.DebtRow==null)
                throw new AtriumException(Resources.NoAccount);
			dr.FileAccountID=dr.DebtRow.FileAccountId;
			dr.FileId=dr.DebtRow.FileId;
			dr.StatusCode=dr.DebtRow.StatusCode;
			dr.SentToOfficeDate=DateTime.Today;
			dr.OfficeId=dr.DebtRow.OfficeID;
			dr.FileHistoryId=((CLAS.FileHistoryRow)this.myA.GetFileHistory().GetCurrentRow()[0]).HistoryId;

		}

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myAccountHistoryDT.TableName;
			CLAS.AccountHistoryRow dr=(CLAS.AccountHistoryRow)ddr;
			switch(dc.ColumnName)
			{
				case "SentToOfficeDate":
                    if (dr.IsSentToOfficeDateNull())
                        throw new RequiredException(Resources.AccountHistorySentToOfficeDate);
					//					if(dr.DebtRow.IsReceivedByJusticeDateNull())
					//						this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.RelatedDateRequired, myA.GetLabelLeft(ObjectName, dc.ColumnName), myA.GetLabelLeft("FileAccount", "ReceivedByJusticeDate"));
					myA.IsValidDate(Resources.AccountHistorySentToOfficeDate, dr.SentToOfficeDate, false, dr.DebtRow.ReceivedByJusticeDate, DateTime.Today.AddDays(7),Resources.DebtReceivedByJusticeDate,Resources.ValidationSevenDaysLater);
					break;
				case "ReceivedByOfficeDate":
//					if(dr.IsReceivedByOfficeDateNull())
//						this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.CannotBeBlank, myA.GetLabelLeft(ObjectName, dc.ColumnName));
                    if (dr.IsSentToOfficeDateNull())
                        throw new RelatedException(Resources.AccountHistoryReceivedByOfficeDate, Resources.AccountHistorySentToOfficeDate);
					if(!dr.IsReceivedByOfficeDateNull())
						myA.IsValidDate(Resources.AccountHistoryReceivedByOfficeDate, dr.ReceivedByOfficeDate, true, dr.SentToOfficeDate, DateTime.Today, Resources.AccountHistorySentToOfficeDate,Resources.ValidationToday);
					break;
				case "ReturnedByOfficeDate":
					if(dr.IsReceivedByOfficeDateNull())
					{
                        throw new AtriumException(Resources.AccountNotReceived);
						//this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.CannotBeBlank, myA.GetLabelLeft(ObjectName, dc.ColumnName));
					}
//					if(dr.IsReceivedByOfficeDateNull())
//						this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.RelatedDateRequired,myA.GetLabelLeft(ObjectName, dc.ColumnName),myA.GetLabelLeft(ObjectName, "ReceivedByOfficeDate"));
					if(!dr.IsReturnedByOfficeDateNull())
						myA.IsValidDate(Resources.AccountHistoryReturnedByOfficeDate, dr.ReturnedByOfficeDate, true, dr.ReceivedByOfficeDate, DateTime.Today, Resources.AccountHistoryReceivedByOfficeDate, Resources.ValidationToday);
					break;
                case "ReceivedFromOfficeDate":
                    //					if(dr.IsReceivedFromOfficeDateNull())
                    //						this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.CannotBeBlank, myA.GetLabelLeft(ObjectName, dc.ColumnName));
                    if (dr.IsReceivedByOfficeDateNull())
                        throw new RelatedException(Resources.AccountHistoryReceivedFromOfficeDate,Resources.AccountHistoryReceivedByOfficeDate);
                    if (!dr.IsReceivedFromOfficeDateNull())
                        myA.IsValidDate(Resources.AccountHistoryReceivedFromOfficeDate, dr.ReceivedFromOfficeDate, true, dr.ReturnedByOfficeDate, DateTime.Today,Resources.AccountHistoryReturnedByOfficeDate, Resources.ValidationToday);
                    break;
                case "OfficeId":
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.OfficeID);
                    else if (!myA.CheckDomain(dr.OfficeId, myA.FM.Codes("officelist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
					break;
                case "StatusCode":
                    if (!myA.CheckDomain(dr.StatusCode, myA.FM.Codes("status")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Status Code");
                    break;
                //case "SubFileType":
                //    if (dr.IsNull(dc))
                //        myA.RaiseError((int)AtriumEnum.AppErrorCodes.CannotBeBlank, myA.GetLabelLeft(ObjectName, dc.ColumnName));
                //    else if (!myA.Codes("HistoryType").Rows.Contains(dr.SubFileType))
                //        myA.RaiseError((int)AtriumEnum.AppErrorCodes.FHInvalidFileType);
                //    break;

				default:
					break;
			}
		}

        //public override DataRow[] GetParentRow()
        //{
        //    return this.myA.GetCLASMng().GetDebt().GetCurrentRow();
        //}

		public override DataRow[] GetCurrentRow()
		{
            if (this.myA.GetDebt().GetCurrentRow().Length == 1)
			{
				//this.LoadByFileAccountId(this.myA.DB.Debt[0].FileAccountId);
				return this.myAccountHistoryDT.Select("ReceivedFromOfficeDate is null and FileAccountId="+this.myA.DB.Debt[0].FileAccountId.ToString());
			}
			else
			{
				//this.LoadByFileId(myA.FM.CurrentFile.FileId);
				return this.myAccountHistoryDT.Select("ReceivedFromOfficeDate is null");
			}
		}

		public override string PromptColumnName()
		{
			return "OfficeCode,AccountTypeCode,SentToOfficeDate";
		}



        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.AccountHistoryRow ahr = myAccountHistoryDT.FindByAccountHistoryId(id);
            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
            l.Add(ahr.FileAccountID);
            return l;
        }
	}
}

