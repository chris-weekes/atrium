using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ADMSEAppealBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.ADMSEAppealDataTable myADMSEAppealDT;
	 
		
		internal ADMSEAppealBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.ADMSEAppeal)
		{
			myA=pBEMng;
			myADMSEAppealDT=(SST.ADMSEAppealDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetADMSEAppeal();
	
		}
  
        public atriumDAL.ADMSEAppealDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSEAppealDAL)myODAL;
            }
        }

		public SST.ADMSEAppealRow Load(int Id)
		{
			Fill(myDAL.Load(Id));
			return myADMSEAppealDT.FindById(Id);
		}
        public void LoadBySSTFileNumber(string SSTFileNumber)
        {
            try
            {
                Fill(myDAL.LoadByFileNumber(SSTFileNumber));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByFileNumber(SSTFileNumber));
            }

        }
        protected override void AfterAdd(DataRow row)
        {
            SST.ADMSEAppealRow dr = (SST.ADMSEAppealRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
            dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;


        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.ADMSEAppealRow dr = (SST.ADMSEAppealRow)row;

            switch(dc.ColumnName)
            {
                case "SourceCodeM":
                    dr.SourceCode = myA.AtMng.GetMap().MapOut("AppelantSource", dr.SourceCodeM);                    
                    break;
                case "AppealLevelM":
                    dr.AppealLevel = myA.AtMng.GetMap().MapOut("AppealLevel", dr.AppealLevelM);
                    break;
                case "OfficeIdM":
                    dr.OfficeId =System.Convert.ToInt32( myA.AtMng.GetMap().MapOut("Office", dr.OfficeIdM.ToString()));
                    break;
            }
        }
	}
}

