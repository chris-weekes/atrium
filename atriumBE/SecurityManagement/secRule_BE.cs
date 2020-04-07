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

    public enum SpecialRules
    {
        GeneralRule = 1024,        
        MyPersonalFile = 1018,
        ReadMail=1021,
        DelegateFileRO=1023,
        DelegateFileRW=1022
    }

	public class secRuleBE:atLogic.ObjectBE
	{
		SecurityManager myA;
		SecurityDB.secRuleDataTable mysecRuleDT;
		
		internal secRuleBE(SecurityManager pBEMng):base(pBEMng,pBEMng.DB.secRule)
		{
			myA=pBEMng;
			mysecRuleDT=(SecurityDB.secRuleDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetsecRule();

        }
        public atriumDAL.secRuleDAL myDAL
        {
            get
            {
                return (atriumDAL.secRuleDAL)myODAL;
            }
        }


	
        protected override void AfterAdd(DataRow ddr)
        {
            SecurityDB.secRuleRow mem = (SecurityDB.secRuleRow)ddr;
            mem.RuleId = myA.PKIDGet("secRule", 1);
            mem.RuleName = "[New Rule]";

            //JLL 2009/07/28 Automatically create secPermission records for each feature when rule is created
            //JLL 2014/3/27 commented out
            //myA.GetsecPermission().CreateFeaturePermissionForNewRule(mem);

        }

	}
}

