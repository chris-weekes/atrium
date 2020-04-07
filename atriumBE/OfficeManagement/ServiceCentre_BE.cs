using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ServiceCentreBE:atLogic.ObjectBE
	{
		OfficeManager myA;
		officeDB.ServiceCentreDataTable myServiceCentreDT;
	 
		
		internal ServiceCentreBE(OfficeManager pBEMng):base(pBEMng,pBEMng.DB.ServiceCentre)
		{
			myA=pBEMng;
            myServiceCentreDT = (officeDB.ServiceCentreDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetServiceCentre();
	
		}

        public atriumDAL.ServiceCentreDAL myDAL
        {
            get
            {
                return (atriumDAL.ServiceCentreDAL)myODAL;
            }
        }

        public officeDB.ServiceCentreRow Load(int OfficeId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ServiceCentreLoad(OfficeId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(OfficeId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(OfficeId));
                }
            }
			return myServiceCentreDT.FindByOfficeId(OfficeId);
		}



        protected override void AfterAdd(DataRow row)
        {
            officeDB.ServiceCentreRow dr = (officeDB.ServiceCentreRow)row;
            string ObjectName = this.myServiceCentreDT.TableName;

            

        }

	}
}

