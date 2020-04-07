using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class SSTGroupBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.SSTGroupDataTable mySSTGroupDT;
	 
		
		internal SSTGroupBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.SSTGroup)
		{
			myA=pBEMng;
			mySSTGroupDT=(SST.SSTGroupDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetSSTGroup();
	
		}
		
		public atriumDAL.SSTGroupDAL myDAL
        {
            get
            {
                return (atriumDAL.SSTGroupDAL)myODAL;
            }
        }

		public SST.SSTGroupRow Load(int SSTGroupId)
		{
		    try
            {
				Fill(myDAL.Load(SSTGroupId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.Load(SSTGroupId));
            }

			return mySSTGroupDT.FindBySSTGroupId(SSTGroupId);
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




        protected override void AfterAdd(DataRow row)
        {
            SST.SSTGroupRow dr = (SST.SSTGroupRow)row;
            string ObjectName = this.mySSTGroupDT.TableName;

            dr.SSTGroupId = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

