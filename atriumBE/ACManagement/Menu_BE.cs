using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class MenuBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.MenuDataTable myMenuDT;
	 
		
		internal MenuBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.Menu)
		{
			myA=pBEMng;
			myMenuDT=(ActivityConfig.MenuDataTable)myDT;
	
		}
		
		public atriumDAL.MenuDAL myDAL
        {
            get
            {
                return (atriumDAL.MenuDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            ActivityConfig.MenuRow dr = (ActivityConfig.MenuRow)row;
            string ObjectName = this.myMenuDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

