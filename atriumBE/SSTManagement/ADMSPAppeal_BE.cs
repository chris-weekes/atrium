using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ADMSPAppealBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.ADMSPAppealDataTable myADMSPAppealDT;
	 
		
		internal ADMSPAppealBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.ADMSPAppeal)
		{
			myA=pBEMng;
			myADMSPAppealDT=(SST.ADMSPAppealDataTable)myDT;
            ////if (myODAL == null)
            ////    myODAL = myA.AtMng.DALMngr.GetADMSPAppeal();
	
		}
  
        public atriumDAL.ADMSPAppealDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSPAppealDAL)myODAL;
            }
        }

		public SST.ADMSPAppealRow Load(int Id)
		{
			Fill(myDAL.Load(Id));
			return myADMSPAppealDT.FindById(Id);
		}
        public void LoadBySSTFileNumber(string SSTFileNumber)
        {
            try
            {
                Fill(myDAL.LoadByFileNumber(SSTFileNumber));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByFileNumber(SSTFileNumber));
            }

        }
        protected override void AfterAdd(DataRow row)
        {
            SST.ADMSPAppealRow dr = (SST.ADMSPAppealRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
            dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;


        }

	}
}

