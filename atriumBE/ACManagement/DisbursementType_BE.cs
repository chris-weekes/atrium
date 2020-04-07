using System;
using System.Data;
using atLogic;using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class DisbursementTypeBE:atLogic.ObjectBE
	{

		ACManager myA;
		CodesDB.DisbursementTypeDataTable myDisbursementTypeDT;
		
		internal DisbursementTypeBE(ACManager pBEMng):base(pBEMng, pBEMng.AtMng.CodeDB.DisbursementType)
		{
			myA=pBEMng;
            myDisbursementTypeDT = (CodesDB.DisbursementTypeDataTable)myDT;

        }
        public atriumDAL.DisbursementTypeDAL myDAL
        {
            get
            {
                return (atriumDAL.DisbursementTypeDAL)myODAL;
            }
        }

	}
}

