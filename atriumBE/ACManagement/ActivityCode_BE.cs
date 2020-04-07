using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ActivityCodeBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.ActivityCodeDataTable myActivityCodeDT;

		
		internal ActivityCodeBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.ActivityCode)
		{
			myA=pBEMng;
			myActivityCodeDT=(ActivityConfig.ActivityCodeDataTable)myDT;

        }
        public atriumDAL.ActivityCodeDAL myDAL
        {
            get
            {
                return (atriumDAL.ActivityCodeDAL)myODAL;
            }
        }


        public int LookupId(string activityCode)
        {
            //this.my*DAL.LoadByActivityCode(activityCode);
            ActivityConfig.ActivityCodeRow[] or = (ActivityConfig.ActivityCodeRow[])this.myActivityCodeDT.Select("activityCode='" + activityCode + "'");
            if (or.Length == 1)
                return or[0].ActivityCodeID;
            else
                throw new AtriumException(String.Format(Properties.Resources.IsNotAValidActivityCode, activityCode));
        }

        protected override void AfterAdd(DataRow dr)
        {
            ActivityConfig.ActivityCodeRow acr = (ActivityConfig.ActivityCodeRow)dr;

            acr.ActivityCodeID = myA.AtMng.PKIDGet(ActivityCodeFields.ActivityCode, 1);
            acr.Communication = false;
            acr.Milestone = false;
            acr.Obsolete = false;
            acr.ReadOnly = false;
            acr.SkipRelatedFields = false;
            acr.GoToDisbursements = false;

        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            ActivityConfig.ActivityCodeRow acr = (ActivityConfig.ActivityCodeRow)dr;
            switch (dc.ColumnName)
            {
                case ActivityCodeFields.ActivityNameEng:
                    if (acr.IsNull("ActivityNameFre"))
                    {
                        acr.ActivityNameFre = acr.ActivityNameEng;
                        acr.EndEdit();
                    }
                    break;
                case ActivityCodeFields.ActivityNameFre:
                    if (acr.IsNull("ActivityNameEng"))
                    {
                        acr.ActivityNameEng = acr.ActivityNameFre;
                        acr.EndEdit();
                    }
                    break;
            }
        }
	}
}

