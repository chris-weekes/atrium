using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atSecurity
{
	/// <summary>
	/// 
	/// </summary>
	public class secPermissionBE:atLogic.ObjectBE
	{
		SecurityManager myA;
		SecurityDB.secPermissionDataTable mysecPermissionDT;
	        
		
		internal secPermissionBE(SecurityManager pBEMng):base(pBEMng,pBEMng.DB.secPermission)
		{
			myA=pBEMng;
			mysecPermissionDT=(SecurityDB.secPermissionDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetsecPermission();

        }
        public atriumDAL.secPermissionDAL myDAL
        {
            get
            {
                return (atriumDAL.secPermissionDAL)myODAL;
            }
        }


	
	


        protected override void AfterAdd(DataRow ddr)
        {
            SecurityDB.secPermissionRow mem = (SecurityDB.secPermissionRow)ddr;
            mem.PermId = myA.PKIDGet("secPermission", 1);

            mem.AllowCreate = 0;
            mem.AllowExecute = 0;
            mem.OverrideRule = 0;
            mem.ReadLevel = 0;
            mem.UpdateLevel = 0; 
            mem.DeleteLevel = 0;

        }

        //JLL: 2009/07/28
        public void CreateFeaturePermissionForNewRule(SecurityDB.secRuleRow srr)
        {
            foreach (int id in Enum.GetValues(typeof(atSecurity.SecurityManager.Features)))
            {
                SecurityDB.secPermissionRow spr = (SecurityDB.secPermissionRow)myA.GetsecPermission().Add(srr);
                spr.FeatureId = id;
                //spr.RuleId = srr.RuleId;
            }
        }



	}
}

