using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class CashBlotterBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.CashBlotterDataTable myCashBlotterDT;
		
		internal CashBlotterBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.CashBlotter)
		{
			myA=pBEMng;
			myCashBlotterDT=(CLAS.CashBlotterDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetCashBlotter();

        }
        public atriumDAL.CashBlotterDAL myDAL
        {
            get
            {
                return (atriumDAL.CashBlotterDAL)myODAL;
            }
        }

        public override bool CanAdd(DataRow parent)
        {
            atriumDB.EFileRow er = (atriumDB.EFileRow)parent;
            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(er.FileId, atSecurity.SecurityManager.Features.CashBlotter) > atSecurity.SecurityManager.ExPermissions.No;
        }
        public override bool CanEdit(DataRow dr)
        {
            CLAS.CashBlotterRow er = (CLAS.CashBlotterRow)dr;
            return AllowEdit || myA.AtMng.SecurityManager.CanUpdate(er.FileID, atSecurity.SecurityManager.Features.CashBlotter) > atSecurity.SecurityManager.LevelPermissions.No;
        }

		public CLAS.CashBlotterRow Load(int CashBlotterID)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().CashBlotterLoad(CashBlotterID, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(CashBlotterID));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(CashBlotterID));
                }
            }
			
			return myCashBlotterDT.FindByCashBlotterID(CashBlotterID);
		}

		protected override void AfterAdd(DataRow row)
		{
			CLAS.CashBlotterRow dr=(CLAS.CashBlotterRow)row;
			string ObjectName = this.myCashBlotterDT.TableName;

			dr.CashBlotterID = this.myA.AtMng.PKIDGet(ObjectName,1);
            dr.OfficeID = myA.FM.CurrentFile.LeadOfficeId;
		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			CLAS.CashBlotterRow dr=(CLAS.CashBlotterRow)ddr;
			switch(dc.ColumnName)
			{
                case "FirstConfirm":
                    if (!myA.CheckDomain(dr.FirstConfirm, myA.FM.Codes("OfficerList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Officer List");
                    break;
                case "SecondConfirm":
                    if (!myA.CheckDomain(dr.SecondConfirm, myA.FM.Codes("OfficerList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Officer List");
                    break;
                case "OfficeID":
                    if (!myA.CheckDomain(dr.OfficeID, myA.FM.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office List");
                    break;
				default:
					break;
			}
		}
        protected override void AfterUpdate(DataRow row)
        {
            CLAS.CashBlotterRow dr = (CLAS.CashBlotterRow)row;
            EFileBE.XmlAddToc(myA.FM.CurrentFile, "cashblotter", "Cash Blotter", "Cash Blotter", 120);

        }

		public int ConfirmManage(int fileId)
		{
			CLAS.CashBlotterRow drCB =(CLAS.CashBlotterRow)GetCurrentRow()[0];
            int docId;

			System.Collections.Hashtable hashTable = new System.Collections.Hashtable();
			hashTable["fileid"] = fileId;
			hashTable["cashblotterid"] = drCB.CashBlotterID;

			drCB.BeginEdit();
            FileManager fm = myA.AtMng.GetFile(fileId);
            if (drCB.IsFirstConfirmNull())
			{
                drCB.FirstConfirm = this.myA.AtMng.WorkingAsOfficer.OfficerId;
				docDB.DocumentRow drnew = this.myA.AtMng.GetTemplate().GenLetter(fm,"5119D",hashTable);
                docId = drnew.DocId;
			}
			else
			{
                drCB.SecondConfirm = this.myA.AtMng.WorkingAsOfficer.OfficerId;
				drCB.RemittedDate = DateTime.Now;
				//this.myA.CreateRelatedActivity("020", DateTime.Now, "", drCB);
                Add(myA.FM.CurrentFile);
                docDB.DocumentRow drnew = this.myA.AtMng.GetTemplate().GenLetter(fm, "5119O", hashTable);
                docId = drnew.DocId;
			}
			drCB.EndEdit();

            return docId;
		}

        public void LoadByOfficeId(int OfficeId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().CashBlotterLoadbyOfficeId(OfficeId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficeID(OfficeId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficeID(OfficeId));
                }
            }
        }
        public override DataRow[] GetCurrentRow()
        {
            //get the open cashblotter for the working as office
            //don't auto create a new one here
//            this.LoadByOfficeId(myA.AtMng.WorkingAsOfficer.OfficeId);

            lmDatasets.CLAS.CashBlotterRow[] cbs = (lmDatasets.CLAS.CashBlotterRow[])myCashBlotterDT.Select("SecondConfirm is null");
            if(cbs.Length==0)
            {
                this.LoadByOfficeId(myA.AtMng.WorkingAsOfficer.OfficeId);

                cbs = (lmDatasets.CLAS.CashBlotterRow[])myCashBlotterDT.Select("SecondConfirm is null");

            }
            if (cbs.Length == 0)
                throw new AtriumException("There is no current cashblotter");

            return cbs;

            //if (this.myCashBlotterDT.Rows.Count == 0)
            //{
            //    return new DataRow[] { this.Add(myA.FM.CurrentFile) };
            //}
            //else if (this.myCashBlotterDT[0].IsSecondConfirmNull())
            //{
            //    return new DataRow[] { this.myCashBlotterDT[0] };
            //}
            //else
            //{
            //    return new DataRow[] { this.Add(myA.FM.CurrentFile) };
            //}
        }

	}
}