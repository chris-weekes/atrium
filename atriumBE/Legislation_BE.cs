using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class LegislationBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.LegislationDataTable myLegislationDT;
	 
		
		internal LegislationBE(atriumManager pBEMng):base(pBEMng,pBEMng.DB.Legislation)
		{
			myA=pBEMng;
			myLegislationDT=(appDB.LegislationDataTable)myDT;


            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetLegislation();
	
		}
		
		public atriumDAL.LegislationDAL myDAL
        {
            get
            {
                return (atriumDAL.LegislationDAL)myODAL;
            }
        }

		
        protected override void AfterAdd(DataRow dr)
        {
            appDB.LegislationRow ir = (appDB.LegislationRow)dr;
            string ObjectName = this.myLegislationDT.TableName;
            ir.LegislationId = this.myA.PKIDGet(ObjectName, 1);
            ir.IsRegulation = false;

        }


	}
}

