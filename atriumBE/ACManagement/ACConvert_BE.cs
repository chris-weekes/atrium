using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACConvertBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.ACConvertDataTable myACConvertDT;


        internal ACConvertBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ACConvert)
		{
			myA=pBEMng;
            myACConvertDT = (ActivityConfig.ACConvertDataTable)myDT;

        }
        public atriumDAL.ACConvertDAL myDAL
        {
            get
            {
                return (atriumDAL.ACConvertDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.ACConvertRow dr = (ActivityConfig.ACConvertRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = this.myA.AtMng.PKIDGet(ObjectName, 1);            
        }

	}
}

