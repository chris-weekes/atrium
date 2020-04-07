using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ADMSPParticipantBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.ADMSPParticipantDataTable myADMSPParticipantDT;
	 
		
		internal ADMSPParticipantBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.ADMSPParticipant)
		{
			myA=pBEMng;
			myADMSPParticipantDT=(SST.ADMSPParticipantDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetADMSPParticipant();
	
		}
        public atriumDAL.ADMSPParticipantDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSPParticipantDAL)myODAL;
            }
        }

		public SST.ADMSPParticipantRow Load(int Id)
		{
			Fill(myDAL.Load(Id));
			return myADMSPParticipantDT.FindById(Id);
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
            SST.ADMSPParticipantRow dr = (SST.ADMSPParticipantRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
            //dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;


        }
	}
}

