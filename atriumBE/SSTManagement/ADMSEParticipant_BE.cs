using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ADMSEParticipantBE:atLogic.ObjectBE
	{
		SSTManager myA;
		SST.ADMSEParticipantDataTable myADMSEParticipantDT;
	 
		
		internal ADMSEParticipantBE(SSTManager pBEMng):base(pBEMng,pBEMng.DB.ADMSEParticipant)
		{
			myA=pBEMng;
			myADMSEParticipantDT=(SST.ADMSEParticipantDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetADMSEParticipant();
	
		}
   
        public atriumDAL.ADMSEParticipantDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSEParticipantDAL)myODAL;
            }
        }

		public SST.ADMSEParticipantRow Load(int Id)
		{
			Fill(myDAL.Load(Id));
			return myADMSEParticipantDT.FindById(Id);
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
            SST.ADMSEParticipantRow dr = (SST.ADMSEParticipantRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
            dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;

            dr.IsAppellant = false;

        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.ADMSEParticipantRow dr = (SST.ADMSEParticipantRow)row;

            switch (dc.ColumnName)
            {
                case "TelephoneNumber":
                    if(!dr.IsTelephoneNumberNull())
                    {
                        if (dr.TelephoneNumber.Length > 3)
                        {
                            string temp = dr.TelephoneNumber.Replace("(", "");
                            temp = temp.Replace(")", "");
                            temp = temp.Replace(" ", "");
                            temp = temp.Replace("-", "");
                            
                            dr.AreaCode = temp.Substring(0, 3);

                            dr.TelNumber = temp.Replace(dr.AreaCode , "");
                        }
                        else
                        { dr.TelNumber = dr.TelephoneNumber; }
                    }
                    break;

                case "CountryM":
                    dr.Country = myA.AtMng.GetMap().MapOut("Country", dr.CountryM);
                    break;
                case "ProvinceCodeM":
                    dr.ProvinceCode = myA.AtMng.GetMap().MapOut("Province", dr.ProvinceCodeM);
                    break;
                case "LangCdM":
                    dr.LangCd = myA.AtMng.GetMap().MapOut("LanguageCode", dr.LangCdM);
                    break;
                case "ParticipantTypeM":
                    dr.ParticipantType = myA.AtMng.GetMap().MapOut("ContactType", dr.ParticipantTypeM);
                    break;
            
            }
        }

        protected override void BeforeUpdate(DataRow row)
        {
            SST.ADMSEParticipantRow dr = (SST.ADMSEParticipantRow)row;

            //SST.SSTCaseRow scr=(SST.SSTCaseRow)myA.GetSSTCase().GetCurrentRow()[0];
            //if (!dr.IsParticipantTypeMNull())
            //{
            //    switch (scr.AppelantSourceId)
            //    {
            //        case 1:
            //            dr.IsAppellant = dr.ParticipantTypeM == "PCL";
            //            break;
            //        case 2:
            //            dr.IsAppellant = dr.ParticipantTypeM == "PEMP";
            //            break;
            //        case 3:
            //            dr.IsAppellant = dr.ParticipantTypeM == "PEMA";
            //            break;
            //        case 4:
            //            dr.IsAppellant = dr.ParticipantTypeM == "PERA";
            //            break;
            //        case 5:
            //            dr.IsAppellant = dr.ParticipantTypeM == "POTA";
            //            break;
            //    }
            //}
        }
	}
}

