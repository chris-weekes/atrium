using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class PLOfficeBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.PLOfficeDataTable myPLOfficeDT;

        internal PLOfficeBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.PLOffice)
		{
			myA=pBEMng;
			myPLOfficeDT=(appDB.PLOfficeDataTable)myDT;

            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetPLOffice();
        }
        public atriumDAL.PLOfficeDAL myDAL
        {
            get
            {
                return (atriumDAL.PLOfficeDAL)myODAL;
            }
        }

		


        protected override void AfterAdd(DataRow row)
        {
            appDB.PLOfficeRow dr = (appDB.PLOfficeRow)row;
            string ObjectName = this.myDT.TableName;

            dr.PLOfficeID = this.myA.PKIDGet(ObjectName, 1);
            dr.Mod = 1;
            dr.ModResult = 0;

        }

        public string OfficeDistributionProjectionQuery()
        {
            lmDatasets.docDB.DocContentRow doccontentrow = myA.GetFile().GetDocMng().GetDocContent().Load(myA.GetSetting(atriumBE.AppIntSetting.PLOfficeForecastDocID));
            if (doccontentrow != null && doccontentrow.ContentsAsText != null)
                return doccontentrow.ContentsAsText;
            else
                return "[Office Distribution Forecast Document could not be found]";
        }


	}
}

