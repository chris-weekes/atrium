using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ACDependencyTypeBE:atLogic.ObjectBE
	{
        ACManager myA;
		ActivityConfig.ACDependencyTypeDataTable myACDependencyTypeDT;
	 
		
		internal ACDependencyTypeBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.ACDependencyType)
		{
			myA=pBEMng;
			myACDependencyTypeDT=(ActivityConfig.ACDependencyTypeDataTable)myDT;
	
		}
		
		public atriumDAL.ACDependencyTypeDAL myDAL
        {
            get
            {
                return (atriumDAL.ACDependencyTypeDAL)myODAL;
            }
        }



        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.ACDependencyTypeRow dr = (ActivityConfig.ACDependencyTypeRow)row;
            string ObjectName = this.myACDependencyTypeDT.TableName;

           // dr.ACDependencyTypeId = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

