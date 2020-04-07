using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class SSTRequestBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.SSTRequestDataTable mySSTRequestDT;


        internal SSTRequestBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.SSTRequest)
		{
			myA=pBEMng;
			mySSTRequestDT=(SST.SSTRequestDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetSSTRequest();
	
		}

        public override bool CanDelete(DataRow dr)
        {
            if (myA.AtMng.SecurityManager.CanDelete(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.SSTRequest) == atSecurity.SecurityManager.LevelPermissions.All)
                return true;
            else
                return false;
        }
		
		public atriumDAL.SSTRequestDAL myDAL
        {
            get
            {
                return (atriumDAL.SSTRequestDAL)myODAL;
            }
        }

		public SST.SSTRequestRow Load(int SSTReqId)
		{
		    try
            {
				Fill(myDAL.Load(SSTReqId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.Load(SSTReqId));
            }

			return mySSTRequestDT.FindBySSTReqId(SSTReqId);
		}


		public void LoadByFileId(int FileId)
		{
		    try
            {
				Fill(myDAL.LoadByFileId(FileId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadByFileId(FileId));
            }
		}

		public void LoadByReqType(int ReqType)
		{
		    try
            {
				Fill(myDAL.LoadByReqType(ReqType));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadByReqType(ReqType));
            }
		}



		public void LoadBySSTCaseId(int SSTCaseId)
		{
		    try
            {
				Fill(myDAL.LoadBySSTCaseId(SSTCaseId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadBySSTCaseId(SSTCaseId));
            }
		}




        protected override void AfterAdd(DataRow row)
        {
            SST.SSTRequestRow dr = (SST.SSTRequestRow)row;
            string ObjectName = this.mySSTRequestDT.TableName;

            dr.SSTReqId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = dr.SSTCaseRow.FileId;
            dr.Abandoned = false;

        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.SSTRequestRow dr = (SST.SSTRequestRow)row;

            switch (dc.ColumnName)
            {
                case "DueDate":
                    myA.FM.GetActivityBF().MaintainBFDate(dr.SSTReqId, myDT.TableName, dc.ColumnName, dr.DueDate);
                    break;
                case "RefreshRecips":
                    if (dr.RefreshRecips)
                    {
                        foreach (SST.SSTReqRecipientRow rrr in dr.GetSSTReqRecipientRows())
                        {
                            rrr.Delete();
                        }
                        foreach (SST.FilePartyRow fpr in myA.DB.FileParty)
                        {
                            if (fpr.SendTo)
                            {
                                SST.SSTReqRecipientRow reqrow = (SST.SSTReqRecipientRow)myA.GetSSTReqRecipient().Add(dr);
                                atriumDB.FileContactRow[] fcr = (atriumDB.FileContactRow[])myA.FM.DB.FileContact.Select("FileContactid=" + fpr.FileContactId, "");
                                if (fcr.Length == 1)
                                    reqrow.SentToContactId = fcr[0].ContactId;
                                else
                                    throw new Exception("Could not set ContactID for Party: " + fpr.DisplayName);
                            }
                        }

                    }
                    break;
            }
        }
        protected override void AfterUpdate(DataRow row)
        {
            SST.SSTRequestRow dr = (SST.SSTRequestRow)row;
            EFileBE.XmlAddToc(myA.FM.CurrentFile, "sstrequest", "Correspondence Requests", "Demandes de correspondances", 111);
        }

        protected override void BeforeUpdate(DataRow dr)
        {
            SST.SSTRequestRow sr=(SST.SSTRequestRow)dr;
            if (sr.RowState != DataRowState.Deleted)
            {
                if(sr.GetSSTReqRecipientRows().Length==0)
                {
                    throw new AtriumException("You must have at least one recipient");
                }
                
            }
        } 
	}
}

