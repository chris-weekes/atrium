using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atSecurity
{
	/// <summary>
	/// 
	/// </summary>
	public class secFeatureBE:atLogic.ObjectBE
	{
		SecurityManager myA;
		SecurityDB.secFeatureDataTable mysecFeatureDT;
	      

		
		internal secFeatureBE(SecurityManager pBEMng):base(pBEMng,pBEMng.DB.secFeature)
		{
			myA=pBEMng;
			mysecFeatureDT=(SecurityDB.secFeatureDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetsecFeature();

        }
        public atriumDAL.secFeatureDAL myDAL
        {
            get
            {
                return (atriumDAL.secFeatureDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow ddr)
        {
            SecurityDB.secFeatureRow mem = (SecurityDB.secFeatureRow)ddr;
            mem.FeatureId = myA.PKIDGet("secFeature", 1);
            mem.FeatureName = "[New feature]";


        }


	


	
	}
}

