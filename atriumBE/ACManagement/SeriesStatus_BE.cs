using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class SeriesStatusBE:atLogic.ObjectBE
	{
        ACManager myA;
        ActivityConfig.SeriesStatusDataTable mySeriesStatusDT;


        internal SeriesStatusBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.SeriesStatus)
		{
			myA=pBEMng;
            mySeriesStatusDT = (ActivityConfig.SeriesStatusDataTable)myDT;
	
		}
		
		public atriumDAL.SeriesStatusDAL myDAL
        {
            get
            {
                return (atriumDAL.SeriesStatusDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.SeriesStatusRow dr = (ActivityConfig.SeriesStatusRow)row;
            string ObjectName = this.mySeriesStatusDT.TableName;

           // dr.SeriesStatusCode = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

