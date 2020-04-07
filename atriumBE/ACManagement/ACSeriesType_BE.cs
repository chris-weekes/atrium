using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACSeriesTypeBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.ACSeriesTypeDataTable myACSeriesTypeDT;
	 
		
		internal ACSeriesTypeBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.ACSeriesType)
		{
			myA=pBEMng;
			myACSeriesTypeDT=(ActivityConfig.ACSeriesTypeDataTable)myDT;
	
		}
		
		public atriumDAL.ACSeriesTypeDAL myDAL
        {
            get
            {
                return (atriumDAL.ACSeriesTypeDAL)myODAL;
            }
        }


        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.ACSeriesTypeRow dr = (ActivityConfig.ACSeriesTypeRow)row;
            string ObjectName = this.myACSeriesTypeDT.TableName;

            //dr.ACSeriesTypeId = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

