using System;
using System.Data;
using atLogic;
using lmDatasets;


namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACTaskTypeBE:atLogic.ObjectBE
	{
        ACManager myA;
        ActivityConfig.ACTaskTypeDataTable myACTaskTypeDT;


        internal ACTaskTypeBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ACTaskType)
		{
			myA=pBEMng;
            myACTaskTypeDT = (ActivityConfig.ACTaskTypeDataTable)myDT;
	
		}
		
		public atriumDAL.ACTaskTypeDAL myDAL
        {
            get
            {
                return (atriumDAL.ACTaskTypeDAL)myODAL;
            }
        }



        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.ACTaskTypeRow dr = (ActivityConfig.ACTaskTypeRow)row;
            string ObjectName = this.myACTaskTypeDT.TableName;

            //dr.ACTaskTypeCode = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

