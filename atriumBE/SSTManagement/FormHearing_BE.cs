using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class FormHearingBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.FormHearingDataTable myFormHearingDT;
	 
		
		internal FormHearingBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.FormHearing)
		{
			myA=pBEMng;
			myFormHearingDT=(SST.FormHearingDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetFormHearing();
	
		}
		
		public atriumDAL.FormHearingDAL myDAL
        {
            get
            {
                return (atriumDAL.FormHearingDAL)myODAL;
            }
        }

		public  
            SST.FormHearingRow Load(int FormHearingId)
		{
		    try
            {
				Fill(myDAL.Load(FormHearingId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.Load(FormHearingId));
            }

			return myFormHearingDT.FindByFormHearingId(FormHearingId);
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
            SST.FormHearingRow dr = (SST.FormHearingRow)row;
            string ObjectName = this.myFormHearingDT.TableName;

            dr.FormHearingId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = ((SST.SSTCaseRow)myA.GetSSTCase().GetCurrentRow()[0]).FileId;// myA.AtMng.GetFile().CurrentFileId;
            dr.SSTCaseId = ((SST.SSTCaseRow)myA.GetSSTCase().GetCurrentRow()[0]).SSTCaseId;
            dr.Obsolete = false;
            dr.ReadOnly = false;
            dr.OtherInPerson =false;
            dr.OtherQuestAnswers=false;
            dr.OtherTeleconference = false;
            dr.OtherVideoconference = false;

            dr.isAddedPartyNoShow = false;
            dr.isClaimantNoShow = false;
            dr.isMinisterNoShow = false;
            dr.isEmployerNoShow = false;
            dr.isCommissionNoShow = false;
              
        }

	}
}

