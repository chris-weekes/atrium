using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atSecurity
{
	/// <summary>
	/// 
	/// </summary>
    /// 

    public enum SpecialGroups
    {
        Everyone = 1012
    }
	public class secGroupBE:atLogic.ObjectBE
	{
		SecurityManager myA;
		SecurityDB.secGroupDataTable mysecGroupDT;

 

		internal secGroupBE(SecurityManager pBEMng):base(pBEMng,pBEMng.DB.secGroup)
		{
			myA=pBEMng;
			mysecGroupDT=(SecurityDB.secGroupDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetsecGroup();

        }
        public atriumDAL.secGroupDAL myDAL
        {
            get
            {
                return (atriumDAL.secGroupDAL)myODAL;
            }
        }


	

        protected override void AfterAdd(DataRow dr)
        {
            SecurityDB.secGroupRow mem = (SecurityDB.secGroupRow)dr;
            mem.GroupId = myA.PKIDGet("secGroup", 1);
            mem.CanHaveMembers = true;
        }

	}
}

