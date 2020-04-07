using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ADMSPIssuesBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.ADMSPIssuesDataTable myADMSPIssuesDT;
	 
		
		internal ADMSPIssuesBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.ADMSPIssues)
		{
			myA=pBEMng;
			myADMSPIssuesDT=(SST.ADMSPIssuesDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetADMSPIssues();
	
		}
   
        public atriumDAL.ADMSPIssuesDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSPIssuesDAL)myODAL;
            }
        }

		public SST.ADMSPIssuesRow Load(int Id)
		{
			Fill(myDAL.Load(Id));
			return myADMSPIssuesDT.FindById(Id);
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
            SST.ADMSPIssuesRow dr = (SST.ADMSPIssuesRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
          //  dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;


        }

	}
}

