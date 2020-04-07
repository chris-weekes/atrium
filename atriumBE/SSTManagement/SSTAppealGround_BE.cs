using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class SSTAppealGroundBE : atLogic.ObjectBE
	{
		SSTManager myA;
		SST.SSTAppealGroundDataTable mySSTAppealGroundDT;


        internal SSTAppealGroundBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.SSTAppealGround)
		{
			myA=pBEMng;
			mySSTAppealGroundDT=(SST.SSTAppealGroundDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetSSTAppealGround();
	
		}
		
		public atriumDAL.SSTAppealGroundDAL myDAL
        {
            get
            {
                return (atriumDAL.SSTAppealGroundDAL)myODAL;
            }
        }

        public SST.SSTAppealGroundRow Load(int SSTAppealGroundId)
		{
		    try
            {
				Fill(myDAL.Load(SSTAppealGroundId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.Load(SSTAppealGroundId));
            }

			return mySSTAppealGroundDT.FindBySSTAppealGroundId(SSTAppealGroundId);
		}



        protected override void AfterAdd(DataRow row)
        {
            SST.SSTAppealGroundRow dr = (SST.SSTAppealGroundRow)row;
            string ObjectName = this.mySSTAppealGroundDT.TableName;

            dr.SSTAppealGroundId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = myA.FM.CurrentFileId;

        }

        protected override void BeforeChange(DataColumn dc, DataRow row)
        {

            SST.SSTAppealGroundRow dr = (SST.SSTAppealGroundRow)row;

            switch (dc.ColumnName)
            {

                case "FileId":
                case "SSTDecisionId":
                case "AppealGroundId":
                    if (dr.IsNull(dc))
                        throw new RequiredException(dc.ColumnName);
                    break;
            }

        }

        //protected override void AfterUpdate(DataRow dr)
        //{
            
        //    SST.SSTAppealGroundRow agr = (SST.SSTAppealGroundRow)dr;

        //    bool granted = false;
        //    SST.SSTAppealGroundDataTable agdt = myDAL.LoadByFileId(agr.FileId);
            
        //    foreach (SST.SSTAppealGroundRow agrow in agdt)
        //    {
        //        if (!agrow.IsOutcomeIdNull() && agrow.OutcomeId == 9)
        //        {
        //            granted = true;
        //            break;
        //        }
        //    }

        //    atriumDAL.SSTDecisionDAL ddal = myA.AtMng.DALMngr.GetSSTDecision();
        //    SST.SSTDecisionDataTable ddt = ddal.Load(agr.SSTDecisonId);
        //    SST.SSTDecisionRow sstdr = (SST.SSTDecisionRow)ddt.Rows[0];

        //    if (granted)
        //    {
        //        sstdr.OutcomeId = 9; // granted
        //    }
        //    else
        //    {
        //        sstdr.OutcomeId = 10; // refused
        //    }

        //    sstdr.EndEdit();

        //}

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {

            SST.SSTAppealGroundRow agr = (SST.SSTAppealGroundRow)dr;
            SST.SSTDecisionRow[] sstdrs = (SST.SSTDecisionRow[])myA.FM.GetSSTMng().DB.SSTDecision.Select("FileID = " + agr.FileId.ToString());
            
            foreach(SST.SSTDecisionRow decisionRow in sstdrs){
                if (decisionRow.DecisionType == 4)
                {
                    agr.SSTDecisonId = decisionRow.SSTDecisionId;
                    break;
                }
            }

            switch (dc.ColumnName)
            {
                case "OutcomeId": // set outcome to granted on SSTDecisionRow if at least 1 Appeal Ground is granted
                    bool granted = false;
                    foreach (SST.SSTAppealGroundRow agrow in mySSTAppealGroundDT)
                    {
                        if (!agrow.IsOutcomeIdNull() && agrow.OutcomeId == 9)
                        {
                            granted = true;
                            break;
                        }
                    }

                    SST.SSTDecisionRow sstdr = agr.SSTDecisionRow;
                    
                    if (granted)
                    {
                        sstdr.OutcomeId = 9; // granted
                    }
                    else
                    {
                        sstdr.OutcomeId = 10; // refused
                    }
                    sstdr.EndEdit();
                    break;
            }
        }

	}
}

