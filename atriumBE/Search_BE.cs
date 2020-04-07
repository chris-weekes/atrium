using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	public class SearchBE : ObjectBE
	{
        atriumManager myA;
        appDB.SearchDataTable mySearchDT;


        internal SearchBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.Search)
		{
			myA=pBEMng;
            mySearchDT = (appDB.SearchDataTable)myDT;
            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetSearch();
	
		}
		
		public atriumDAL.SearchDAL myDAL
        {
            get
            {
                return (atriumDAL.SearchDAL)myODAL;
            }
        }


        protected override void AfterAdd(DataRow row)
        {
            appDB.SearchRow dr = (appDB.SearchRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = this.myA.PKIDGet(ObjectName, 1);
        }
    }
}

