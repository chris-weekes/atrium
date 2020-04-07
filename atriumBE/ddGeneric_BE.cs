using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ddGenericBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.ddGenericDataTable myddGenericDT;
	 
		
		internal ddGenericBE(atriumManager pBEMng):base(pBEMng,pBEMng.DB.ddGeneric)
		{
			myA=pBEMng;
			myddGenericDT=(appDB.ddGenericDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.DALMngr.GetddGeneric();
	
		}
		
		public atriumDAL.ddGenericDAL myDAL
        {
            get
            {
                return (atriumDAL.ddGenericDAL)myODAL;
            }
        }

    




        protected override void AfterAdd(DataRow row)
        {
            appDB.ddGenericRow dr = (appDB.ddGenericRow)row;
            string ObjectName = this.myddGenericDT.TableName;

            dr.GenericId = myA.PKIDGet(ObjectName, 10);
            dr.Obsolete = false;
            dr.ReadOnly = false;
            
        }

	}
}

