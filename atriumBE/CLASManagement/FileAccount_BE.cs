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
	public class FileAccountBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.FileAccountDataTable myFileAccountDT;

        internal FileAccountBE(CLASManager pBEMng, DataTable pdt)
            : base(pBEMng,pdt)
		{
			myA=pBEMng;
		}

        internal FileAccountBE(CLASManager pBEMng)
            : base(pBEMng, pBEMng.DB.FileAccount)
		{
			myA=pBEMng;
            myFileAccountDT = (CLAS.FileAccountDataTable)myDT;

        }
        public atriumDAL.FileAccountDAL myDAL
        {
            get
            {
                return (atriumDAL.FileAccountDAL)myODAL;
            }
        }

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.FileAccountRow r = (CLAS.FileAccountRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }
        private void MyXml(CLAS.FileAccountRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='account' and @id=" + r.FileAccountId.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "account");
                xe.SetAttribute("supertype", "fileaccount");

            }
            xe.SetAttribute("id", r.FileAccountId.ToString());
            xe.SetAttribute("titlee", r["AccountTypeCode"].ToString() + " (" + r["DARSAccountType"].ToString() + ")");
            xe.SetAttribute("titlef", r["AccountTypeCode"].ToString() + " (" + r["DARSAccountType"].ToString() + ")");
            
            if (r.ActiveWithJustice)
            {
                xe.SetAttribute("tooltipe", "Assigned");
                xe.SetAttribute("strikeout", "false");
            }
            else
            {
                xe.SetAttribute("tooltipe", "Not Assigned");
                xe.SetAttribute("strikeout", "true");
            }


            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "account", "Accounts", "Comptes",220);
                xes.AppendChild(xe);
            }
        }
		public  void MyXml(atriumDB.EFileRow efr,System.Xml.XmlDocument xd)
		{
			foreach(CLAS.FileAccountRow r in myFileAccountDT.Rows)
			{
                MyXml(r, xd);
			}
		}

		protected override void AfterAdd(DataRow row)
		{
			//CLAS.FileAccountRow dr=(CLAS.FileAccountRow)row;
			string ObjectName = "FileAccount";

            //TODO resolve currentfile use and statuscode checks - see last line
            if ("OP".IndexOf(myA.FM.CurrentFile.StatusCode) ==-1)
				throw new AtriumException(Resources.FileMustBeOpenOrPending);

			if(row.IsNull("FileAccountId"))
				row["FileAccountId"]= myA.AtMng.PKIDGet(ObjectName,10);
            
            //assign to owner before assignment to agent
            row["OfficeID"] = myA.FM.CurrentFile.OwnerOfficeId;
            
            row["ActiveWithJustice"] = true;
            row["StatusCode"] = "O";

			//if(this.myA.CurrentFile.StatusCode=="P")
			//	this.myA.CurrentFile.StatusCode="O";

		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			
            switch(dc.ColumnName)
			{
				case "ActiveWithJustice":
					//cqn't be active if filestatus is ACM
					if((bool)ddr[dc.ColumnName] && "ACM".IndexOf(this.myA.FM.CurrentFile.StatusCode)>0)
						throw new AtriumException(Resources.AccountCannotBeActiveWhenTheFileIsClosed);
					break;
				case "AccountTypeId":
                    if (ddr.IsNull(dc))
                        throw new RequiredException(Resources.FileAccountAccountTypeId);
                    // JLL 2010-08-09 commented out checkdomain as it causes issues ... trying to setup clas workflows for demo
                    //else if (!myA.CheckDomain((string)ddr[dc.ColumnName], myA.Codes("accounttypelist")))
                    //    throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Account Type");
					break;
				case "ReceivedByJusticeDate":
                    if (ddr.IsNull(dc))
                        throw new RequiredException(Resources.FileAccountReceivedByJusticeDate);
					myA.IsValidDate(Resources.FileAccountReceivedByJusticeDate,(DateTime) ddr[dc], false, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin, Resources.ValidationToday);
					break;
				case "ClosureDate":
                    if (ddr.IsNull(dc) && !ddr.IsNull("ClosureCode"))
                        throw new RequiredException(Resources.FileAccountClosureDate);
                    if (ddr.IsNull("ReceivedByJusticeDate"))
                        throw new RelatedException(Resources.FileAccountClosureDate, Resources.FileAccountReceivedByJusticeDate);
					if(!ddr.IsNull(dc))
						myA.IsValidDate(Resources.FileAccountClosureDate,(DateTime) ddr[dc], true,(DateTime) ddr["ReceivedByJusticeDate"], DateTime.Today, Resources.FileAccountReceivedByJusticeDate,Resources.ValidationToday);
					break;
				case "ClosureCode":
                    if (!ddr.IsNull("ClosureDate") && ddr.IsNull(dc))
                        throw new AtriumException(Resources.DebtCloseCodeRqd);
                    else if (!ddr.IsNull(dc) && !myA.CheckDomain((string)ddr[dc.ColumnName], myA.FM.Codes("returncode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Closure Code");
					break;
                case "OfficeID":
                    if (!myA.CheckDomain((int)ddr[dc.ColumnName], myA.FM.Codes("officelist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
                    break;
				default:
					break;
			}
		}

		protected override void AfterChange(DataColumn dc, DataRow dr)
		{
			switch(dc.ColumnName)
			{
                case FileAccountFields.AccountTypeId:
                    DataRow acctR = this.AccountTypeInfo((int)dr[FileAccountFields.AccountTypeId]);
                    dr[AccountTypeFields.AccountTypeCode] = acctR[AccountTypeFields.AccountTypeCode];
                    dr[AccountTypeFields.AccountTypeDescEng] = acctR[AccountTypeFields.AccountTypeDescEng];

                    break;

				case FileAccountFields.ActiveWithJustice:
					if((bool)dr[dc])
					{
						dr[FileAccountFields.ClosureCode]=System.DBNull.Value;
						dr[FileAccountFields.ClosureDate]=System.DBNull.Value;
                        dr.EndEdit();
                    }
					break;
				case FileAccountFields.ClosureCode:
				case FileAccountFields.ClosureDate:
					if(!dr.IsNull(FileAccountFields.ClosureDate))
						dr[FileAccountFields.ActiveWithJustice]=0;
					else
						dr[FileAccountFields.ActiveWithJustice]=1;
                    dr.EndEdit();
                    break;
			}

		}


		protected override void BeforeUpdate(DataRow row) 
		{
			//CLAS.FileAccountRow dr = (CLAS.FileAccountRow) row;

			this.BeforeChange(row.Table.Columns["ReceivedByJusticeDate"],row);
			this.BeforeChange(row.Table.Columns["AccountTypeId"],row);

            //is this the right place for this
			//should it be on fileoffice?
//			if(row["StatusCode"].ToString()=="O")
//				this.myA.CurrentFile.LeadOfficeId=(int)row["OfficeID"];
		}

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[]{this.myA.CurrentFile};
        //}

		public override DataRow[] GetCurrentRow()
		{
			DataRow[] dr=base.GetCurrentRow();
            //if(dr==null ||dr.Length==0)
            //    this.LoadByFileId(myA.CurrentFile.FileId);
			return this.myFileAccountDT.Select();

		}

		public override string PromptColumnName()
		{
			return "AccountTypeCode,ReceivedByJusticeDate";
		}

		public DataRow AccountTypeInfo(int accountTypeId)
		{
            //TODO: change method to used cached data from codesdb
			DataTable acctDt=this.myA.AtMng.GetGeneralRec("Select * from vaccounttype where accounttypeid="+accountTypeId.ToString());
			return acctDt.Rows[0];
		}

        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.FileAccountRow ahr = myFileAccountDT.FindByFileAccountId(id);
            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
            l.Add(ahr.FileAccountId);
            return l;
        }
    }
}

