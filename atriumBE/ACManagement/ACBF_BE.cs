using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACBFBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.ACBFDataTable myACBFDT;

		
		internal ACBFBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.ACBF)
		{
			myA=pBEMng;
			myACBFDT=(ActivityConfig.ACBFDataTable)myDT;

        }
        public atriumDAL.ACBFDAL myDAL
        {
            get
            {
                return (atriumDAL.ACBFDAL)myODAL;
            }
        }
        protected override void AfterAdd(DataRow dr)
        {

            ActivityConfig.ACBFRow acr = (ActivityConfig.ACBFRow)dr;

            acr.ACBFId = myA.AtMng.PKIDGet("ACBF", 1);
            acr.Obsolete = false;
            acr.ReadOnly = false;
            acr.isMail = false;
            acr.MonitorIncomplete = false;
            acr.AllowManualComplete = false;


        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            ActivityConfig.ACBFRow acr = (ActivityConfig.ACBFRow)dr;
            switch (dc.ColumnName)
            {
                case ACBFFields.BFType:
                    if (acr.BFType != 7)
                        acr.SetRoleCodeNull();
                    break;
            }
        }

	}
}

