using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ProvisionBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.ProvisionDataTable myProvisionDT;
	 
		
		internal ProvisionBE(atriumManager pBEMng):base(pBEMng,pBEMng.DB.Provision)
		{
			myA=pBEMng;
			myProvisionDT=(appDB.ProvisionDataTable)myDT;

            myProvisionDT.ProvisionTextEngColumn.ExtendedProperties.Add("rtf", true);
            myProvisionDT.ProvisionTextFreColumn.ExtendedProperties.Add("rtf", true);
            myProvisionDT.AnalysisTextEngColumn.ExtendedProperties.Add("rtf", true);
            myProvisionDT.AnalysisTextFreColumn.ExtendedProperties.Add("rtf", true);

            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetProvision();
	
		}
		
		public atriumDAL.ProvisionDAL myDAL
        {
            get
            {
                return (atriumDAL.ProvisionDAL)myODAL;
            }
        }

		

		

        protected override void AfterAdd(DataRow dr)
        {
            appDB.ProvisionRow ir = (appDB.ProvisionRow)dr;
            string ObjectName = this.myProvisionDT.TableName;
            ir.ProvisionId = this.myA.PKIDGet(ObjectName, 1);

        }


	}
}

