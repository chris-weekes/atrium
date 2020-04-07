using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class SSTReqRecipientBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.SSTReqRecipientDataTable mySSTReqRecipientDT;
	 
		
		internal SSTReqRecipientBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.SSTReqRecipient)
		{
			myA=pBEMng;
			mySSTReqRecipientDT=(SST.SSTReqRecipientDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetSSTReqRecipient();
	
		}
		
		public atriumDAL.SSTReqRecipientDAL myDAL
        {
            get
            {
                return (atriumDAL.SSTReqRecipientDAL)myODAL;
            }
        }

		public SST.SSTReqRecipientRow Load(int SSTReqRecId)
		{
		    try
            {
				Fill(myDAL.Load(SSTReqRecId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.Load(SSTReqRecId));
            }

			return mySSTReqRecipientDT.FindBySSTReqRecId(SSTReqRecId);
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



		public void LoadBySSTReqId(int SSTReqId)
		{
		    try
            {
				Fill(myDAL.LoadBySSTReqId(SSTReqId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadBySSTReqId(SSTReqId));
            }
		}




        protected override void AfterAdd(DataRow row)
        {
            SST.SSTReqRecipientRow dr = (SST.SSTReqRecipientRow)row;
            string ObjectName = this.mySSTReqRecipientDT.TableName;

            dr.SSTReqRecId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = dr.SSTRequestRow.FileId;
        }

	}
}

