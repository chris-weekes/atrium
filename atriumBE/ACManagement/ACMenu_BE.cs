using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACMenuBE:atLogic.ObjectBE
	{
        ACManager myA;
		ActivityConfig.ACMenuDataTable myACMenuDT;


        internal ACMenuBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ACMenu)
		{
			myA=pBEMng;
			myACMenuDT=(ActivityConfig.ACMenuDataTable)myDT;

        }
        public atriumDAL.ACMenuDAL myDAL
        {
            get
            {
                return (atriumDAL.ACMenuDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow dr)
        {

            ActivityConfig.ACMenuRow acmr = (ActivityConfig.ACMenuRow)dr;

            acmr.Id = myA.AtMng.PKIDGet("ACMenu", 1);
            acmr.IsSeparator = false;
            acmr.Sort = 100;

        }

	}
}

