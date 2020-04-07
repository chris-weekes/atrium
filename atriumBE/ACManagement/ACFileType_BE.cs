using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACFileTypeBE:atLogic.ObjectBE
	{
        ACManager myA;
		ActivityConfig.ACFileTypeDataTable myACFileTypeDT;


        internal ACFileTypeBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ACFileType)
		{
			myA=pBEMng;
            myACFileTypeDT = (ActivityConfig.ACFileTypeDataTable)myDT;

        }
        public atriumDAL.ACFileTypeDAL myDAL
        {
            get
            {
                return (atriumDAL.ACFileTypeDAL)myODAL;
            }
        }


        protected override void AfterAdd(DataRow dr)
        {
            ActivityConfig.ACFileTypeRow acr = (ActivityConfig.ACFileTypeRow)dr;

            acr.Id = myA.AtMng.PKIDGet("ACFileType", 1);

            

        }
	}
}

