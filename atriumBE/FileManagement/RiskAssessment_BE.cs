using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class RiskAssessmentBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.RiskAssessmentDataTable myRiskAssessmentDT;
		
        int[,] rl=new int[4,4];

		internal RiskAssessmentBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.RiskAssessment)
		{
			myA=pBEMng;
			myRiskAssessmentDT=(atriumDB.RiskAssessmentDataTable)myDT;

            //likelihood,impact
            rl[0, 0] = 0;
            rl[0, 1] = 0;
            rl[0, 2] = 0;
            rl[0, 3] = 0;
            rl[1, 0] = 0;
            rl[1, 1] = 1;
            rl[1, 2] = 4;
            rl[1, 3] = 7;
            rl[2, 0] = 0;
            rl[2, 1] = 2;
            rl[2, 2] = 5;
            rl[2, 3] = 8;
            rl[3, 0] = 0;
            rl[3, 1] = 3;
            rl[3, 2] = 6;
            rl[3, 3] = 9;

			this.myRiskAssessmentDT.ContingentLiabilityColumn.ExtendedProperties.Add("format","C");
			this.myRiskAssessmentDT.SettlementEstColumn.ExtendedProperties.Add("format","C");
			this.myRiskAssessmentDT.AmountClaimedColumn.ExtendedProperties.Add("format","C");


            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetRiskAssessment();
        }
        public atriumDAL.RiskAssessmentDAL myDAL
        {
            get
            {
                return (atriumDAL.RiskAssessmentDAL)myODAL;
            }
        }

	

	


		protected override void AfterAdd(DataRow row)
		{
			atriumDB.RiskAssessmentRow dr=(atriumDB.RiskAssessmentRow)row;
			string ObjectName = this.myRiskAssessmentDT.TableName;

			dr.RiskAssessId = this.myA.AtMng.PKIDGet(ObjectName,10);     
			dr.RiskLevel=0;
			dr.PossibilityOfSettlement=0;
			dr.Impact=0;
			dr.Likelihood=0;
			dr.Complexity=0;
			dr.Status="PS";
            dr.AssessedById = myA.AtMng.WorkingAsOfficer.OfficerId;
            dr.AssessmentDate = DateTime.Today;
            dr.SubjectToContingentLiability = false;
		}

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {
            atriumDB.RiskAssessmentRow sur = (atriumDB.RiskAssessmentRow)ddr;
            switch (dc.ColumnName)
            {
                case RiskAssessmentFields.Likelihood:
                case RiskAssessmentFields.Impact:

                    sur.RiskLevel = rl[sur.Likelihood , sur.Impact ]; ;
                    sur.EndEdit();
                    break;
                case "SubjectToContingentLiability":
                    if (sur.SubjectToContingentLiability)
                    {
                        sur.CLRStartDate = DateTime.Now;
                        if (!sur.IsCLREndDateNull())
                            sur.SetCLREndDateNull();
                    }
                    else
                    {
                        sur.CLREndDate = DateTime.Now;
                    }
                    break;
                default:
                    break;
            }
        }

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			atriumDB.RiskAssessmentRow sur=(atriumDB.RiskAssessmentRow)ddr;
			switch(dc.ColumnName)
			{
				default:
					break;
			}
		}

        protected override void AfterUpdate(DataRow row)
        {
            atriumDB.RiskAssessmentRow dr = (atriumDB.RiskAssessmentRow)row;
            EFileBE.XmlAddToc(dr.EFileRow, "riskassessment", "Legal Risk Management", "Gestion du risque juridique",140);

        }

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[]{this.myA.CurrentFile};
        //}

		public override DataRow[] GetCurrentRow()
		{
			

			if(this.myRiskAssessmentDT.Rows.Count==1)
				return this.myRiskAssessmentDT.Select();
			else
				return this.myRiskAssessmentDT.Select();
		}

	}
}

