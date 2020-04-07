using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ADMSPDecisionBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.ADMSPDecisionDataTable myADMSPDecisionDT;
	 
		
		internal ADMSPDecisionBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.ADMSPDecision)
		{
			myA=pBEMng;
			myADMSPDecisionDT=(SST.ADMSPDecisionDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetADMSPDecision();
	
		}
   
        public atriumDAL.ADMSPDecisionDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSPDecisionDAL)myODAL;
            }
        }

		public SST.ADMSPDecisionRow Load(int Id)
		{
			Fill(myDAL.Load(Id));
			return myADMSPDecisionDT.FindById(Id);
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
            SST.ADMSPDecisionRow dr = (SST.ADMSPDecisionRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
            dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;


        }

	}
}

