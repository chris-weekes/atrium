using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class RAClientImpactBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.RAClientImpactDataTable myRAClientImpactDT;
		
		internal RAClientImpactBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.RAClientImpact)
		{
			myA=pBEMng;
			myRAClientImpactDT=(atriumDB.RAClientImpactDataTable)myDT;

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetRAClientImpact();
        }
        public atriumDAL.RAClientImpactDAL myDAL
        {
            get
            {
                return (atriumDAL.RAClientImpactDAL)myODAL;
            }
        }

	

	

		protected override void AfterAdd(DataRow row)
		{
			atriumDB.RAClientImpactRow dr=(atriumDB.RAClientImpactRow)row;
			string ObjectName = this.myRAClientImpactDT.TableName;

			dr.RAClientImpactId = this.myA.AtMng.PKIDGet(ObjectName,10);            
		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			atriumDB.RAClientImpactRow sur=(atriumDB.RAClientImpactRow)ddr;
			switch(dc.ColumnName)
			{
				default:
					break;
			}
		}

        //public override DataRow[] GetParentRow()
        //{
        //    return this.myA.GetRiskAssessment().GetCurrentRow();
        //}

        public override DataRow[] GetCurrentRow()
        {
           return this.myRAClientImpactDT.Select();
        }

	}
}

