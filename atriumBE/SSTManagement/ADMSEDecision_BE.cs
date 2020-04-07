using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ADMSEDecisionBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.ADMSEDecisionDataTable myADMSEDecisionDT;
	 
		
		internal ADMSEDecisionBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.ADMSEDecision)
		{
			myA=pBEMng;
			myADMSEDecisionDT=(SST.ADMSEDecisionDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetADMSEDecision();
	
		}
   
        public atriumDAL.ADMSEDecisionDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSEDecisionDAL)myODAL;
            }
        }

		public SST.ADMSEDecisionRow Load(int Id)
		{
			Fill(myDAL.Load(Id));
			return myADMSEDecisionDT.FindById(Id);
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
            SST.ADMSEDecisionRow dr = (SST.ADMSEDecisionRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
            dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;


        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.ADMSEDecisionRow dr = (SST.ADMSEDecisionRow)row;
            switch (dc.ColumnName)
            {
                case "HearingMethodIdM":
                    dr.HearingMethod = dr.HearingMethodIdM.ToString().PadLeft(2, '0');
                    break;
                case "LeaveToAppealDecTypeM":
                    dr.LeaveToAppealDecType = myA.AtMng.GetMap().MapOut("LeaveToAppealType", dr.LeaveToAppealDecTypeM);
                    break;
            }
        }

	}
}

