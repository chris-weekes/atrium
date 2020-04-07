using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACDisbBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.ACDisbDataTable myACDisbDT;

		
		internal ACDisbBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.ACDisb)
		{
			myA=pBEMng;
			myACDisbDT=(ActivityConfig.ACDisbDataTable)myDT;

        }
        public atriumDAL.ACDisbDAL myDAL
        {
            get
            {
                return (atriumDAL.ACDisbDAL)myODAL;
            }
        }

	}
}

