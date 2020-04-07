using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class TaxRateBE : atLogic.ObjectBE
    {
        atriumManager myA;
        appDB.TaxRateDataTable myTaxRateDT;

        internal TaxRateBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.TaxRate)
        {
            myA = pBEMng;
            myTaxRateDT = (appDB.TaxRateDataTable)myDT;

            this.myTaxRateDT.TaxRateColumn.ExtendedProperties.Add("format", "#0.0#\\%");

            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetTaxRate();
        }
        public atriumDAL.TaxRateDAL myDAL
        {
            get
            {
                return (atriumDAL.TaxRateDAL)myODAL;
            }
        }

        public appDB.TaxRateRow Load(int TaxRateId)
        {
            appDB.TaxRateRow or = myTaxRateDT.FindByTaxRateId(TaxRateId);
            if (or == null)
            {
                try
                {
                    Fill(myDAL.Load(TaxRateId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(TaxRateId));
                }

                or = myTaxRateDT.FindByTaxRateId(TaxRateId);
            }
            return or;

        }




    }
}

