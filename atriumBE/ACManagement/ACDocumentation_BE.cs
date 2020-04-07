using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACDocumentationBE:atLogic.ObjectBE
	{
        ACManager myA;
		ActivityConfig.ACDocumentationDataTable myACDocumentationDT;


        internal ACDocumentationBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ACDocumentation)
		{
			myA=pBEMng;
			myACDocumentationDT=(ActivityConfig.ACDocumentationDataTable)myDT;
	
		}
		
		public atriumDAL.ACDocumentationDAL myDAL
        {
            get
            {
                return (atriumDAL.ACDocumentationDAL)myODAL;
            }
        }


        protected override void AfterAdd(DataRow dr)
        {
            ActivityConfig.ACDocumentationRow acr = (ActivityConfig.ACDocumentationRow)dr;

            acr.ACDocId = myA.AtMng.PKIDGet("ACDocumentation", 1);
        }

	}
}

