using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class OfficeMandateBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.OfficeMandateDataTable myOfficeMandateDT;

		
		internal OfficeMandateBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.OfficeMandate)
		{
			myA=pBEMng;
			myOfficeMandateDT=(ActivityConfig.OfficeMandateDataTable)myDT;

        }
        public atriumDAL.OfficeMandateDAL myDAL
        {
            get
            {
                return (atriumDAL.OfficeMandateDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow dr)
        {
            ActivityConfig.OfficeMandateRow omr = (ActivityConfig.OfficeMandateRow)dr;
            string ObjectName = this.myOfficeMandateDT.TableName;

            omr.Id = this.myA.AtMng.PKIDGet(ObjectName, 1);
        }

	}
}

