using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class SeriesPackageBE:atLogic.ObjectBE
	{
        ACManager myA;
        ActivityConfig.SeriesPackageDataTable mySeriesPackageDT;


        internal SeriesPackageBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.SeriesPackage)
		{
			myA=pBEMng;
            mySeriesPackageDT = (ActivityConfig.SeriesPackageDataTable)myDT;
	
		}
		
		public atriumDAL.SeriesPackageDAL myDAL
        {
            get
            {
                return (atriumDAL.SeriesPackageDAL)myODAL;
            }
        }



        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.SeriesPackageRow dr = (ActivityConfig.SeriesPackageRow)row;
            string ObjectName = this.mySeriesPackageDT.TableName;

            //dr.SeriesPackageCode = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

