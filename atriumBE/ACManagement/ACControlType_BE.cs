using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACControlTypeBE:atLogic.ObjectBE
	{
        ACManager myA;
        ActivityConfig.ACControlTypeDataTable myACControlTypeDT;


        internal ACControlTypeBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ACControlType)
		{
			myA=pBEMng;
            myACControlTypeDT = (ActivityConfig.ACControlTypeDataTable)myDT;
	
		}
		
		public atriumDAL.ACControlTypeDAL myDAL
        {
            get
            {
                return (atriumDAL.ACControlTypeDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.ACControlTypeRow dr = (ActivityConfig.ACControlTypeRow)row;
            string ObjectName = this.myACControlTypeDT.TableName;

        }

	}
}

