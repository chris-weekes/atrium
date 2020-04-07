using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	public class SearchTermBE : ObjectBE
	{
        atriumManager myA;
        appDB.SearchTermDataTable mySearchTermDT;


        internal SearchTermBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.SearchTerm)
		{
			myA=pBEMng;
            mySearchTermDT = (appDB.SearchTermDataTable)myDT;
            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetSearchTerm();
	
		}
		
		public atriumDAL.SearchTermDAL myDAL
        {
            get
            {
                return (atriumDAL.SearchTermDAL)myODAL;
            }
        }

	
	}
}

