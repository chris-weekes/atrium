using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atSecurity
{
	/// <summary>
	/// 
	/// </summary>
	public class secPermLevelBE:atLogic.ObjectBE
	{
		SecurityManager myA;
		SecurityDB.secPermLevelDataTable mysecPermLevelDT;
	 
        internal secPermLevelBE(SecurityManager pBEMng)
            : base(pBEMng, pBEMng.DB.secPermLevel)
		{
			myA=pBEMng;
            mysecPermLevelDT = (SecurityDB.secPermLevelDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetsecPermLevel();

        }
        public atriumDAL.secPermLevelDAL myDAL
        {
            get
            {
                return (atriumDAL.secPermLevelDAL)myODAL;
            }
        }


    

	}
}

