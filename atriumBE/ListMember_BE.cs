using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ListMemberBE:atLogic.ObjectBE
	{
		
        atriumManager  myA;
        appDB.ListMemberDataTable myListMemberDT;


        internal ListMemberBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.ListMember)
		{
			myA=pBEMng;
            myListMemberDT = (appDB.ListMemberDataTable)myDT;

            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetListMember();
        }
        public atriumDAL.ListMemberDAL myDAL
        {
            get
            {
                return (atriumDAL.ListMemberDAL)myODAL;
            }
        }


     

        protected override void AfterAdd(DataRow dr)
        {
            appDB.ListMemberRow lstmemr = (appDB.ListMemberRow)dr;
            string ObjectName = this.myListMemberDT.TableName;

            lstmemr.Id = this.myA.PKIDGet(ObjectName, 1);
        }
	}
}

