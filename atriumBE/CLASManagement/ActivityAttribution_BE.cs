using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ActivityAttributionBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.ActivityAttributionDataTable myActivityAttributionDT;


        internal ActivityAttributionBE(CLASManager pBEMng)
            : base(pBEMng, pBEMng.DB.ActivityAttribution)
		{
			myA=pBEMng;
            myActivityAttributionDT = (CLAS.ActivityAttributionDataTable)myDT;
	
		}

        public atriumDAL.ActivityAttributionDAL myDAL
        {
            get
            {
                return (atriumDAL.ActivityAttributionDAL)myODAL;
            }
        }


        protected override void AfterAdd(DataRow dr)
        {
            CLAS.ActivityAttributionRow abf = (CLAS.ActivityAttributionRow)dr;
            string ObjectName = this.myDT.TableName;

            abf.Id = this.myA.AtMng.PKIDGet(ObjectName, 10);
            abf.FileID = myA.FM.CurrentFileId;
            abf.PercentAlloc = 0;
        }

	}
}

