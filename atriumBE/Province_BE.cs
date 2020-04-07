using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ProvinceBE:atLogic.ObjectBE
	{
		atriumManager myA;
        appDB.ProvinceDataTable myProvinceDT;

        internal ProvinceBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.Province)
		{
			myA=pBEMng;
            myProvinceDT = (appDB.ProvinceDataTable)myDT;

            this.myProvinceDT.TaxRateColumn.ExtendedProperties.Add("format", "#0.0#\\%");
            this.myProvinceDT.InterestRateonCostColumn.ExtendedProperties.Add("format", "#0.0#\\%");
            this.myProvinceDT.PostJdgmntInterestRateColumn.ExtendedProperties.Add("format", "#0.0#\\%");

			this.myProvinceDT.CosttoIssueSofCColumn.ExtendedProperties.Add("format","C");

            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetProvince();
        }
        public atriumDAL.ProvinceDAL myDAL
        {
            get
            {
                return (atriumDAL.ProvinceDAL)myODAL;
            }
        }

        public appDB.ProvinceRow Load(string ProvinceCode)
		{
            appDB.ProvinceRow or = myProvinceDT.FindByProvinceCode(ProvinceCode);
			if(or==null)
			{
                try
                {
                    Fill(myDAL.Load(ProvinceCode));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(ProvinceCode));
                }

				or=myProvinceDT.FindByProvinceCode(ProvinceCode);
			}
			return or;
			
		}




	}
}

