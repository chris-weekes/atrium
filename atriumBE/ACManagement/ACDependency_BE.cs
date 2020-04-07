using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
    public enum ConnectorType
    {
        NextStep=0,
        BFOnly=1,
        Enable=2,
        Disable=3,
        Answer=4,
        Reply=5,
        ReplyAll=6,
        Forward=7,
        Auto=8,
        Transfer=9,
        Obsolete=99
    }
    public class ACDependencyBE : atLogic.ObjectBE
	{

		ACManager myA;
		ActivityConfig.ACDependencyDataTable myACDependencyDT;

		
		internal ACDependencyBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.ACDependency)
		{
			myA=pBEMng;
			myACDependencyDT=(ActivityConfig.ACDependencyDataTable)myDT;

        }
        public atriumDAL.ACDependencyDAL myDAL
        {
            get
            {
                return (atriumDAL.ACDependencyDAL)myODAL;
            }
        }

        public override bool CanDelete(DataRow dr)
        {
            return myA.AtMng.SecurityManager.CanDelete(0, atSecurity.SecurityManager.Features.ACDependency) == atSecurity.SecurityManager.LevelPermissions.All;
        }
        public override bool CanEdit(DataRow dr)
        {
            return myA.AtMng.SecurityManager.CanUpdate(0, atSecurity.SecurityManager.Features.ACDependency) == atSecurity.SecurityManager.LevelPermissions.All;
        }


        protected override void AfterAdd(DataRow dr)
        {

            ActivityConfig.ACDependencyRow acr = (ActivityConfig.ACDependencyRow)dr;

            acr.ACDependencyId = myA.AtMng.PKIDGet("ACDependency", 1);
            acr.LinkType = (int)ConnectorType.NextStep;
            acr.Seq = 100;

            //if origin is a decision
            if (acr.ACSeriesRowByNextSteps.StepType == (int)StepType.Decision)
            {
                acr.LinkType = (int)ConnectorType.Answer;
                if (acr.ACSeriesRowByNextSteps.GetACDependencyRowsByNextSteps().Length == 1)
                {
                    acr.DescEng = "Yes";
                    acr.DescFre = "Oui";
                }
                else if (acr.ACSeriesRowByNextSteps.GetACDependencyRowsByNextSteps().Length == 2)
                {
                    acr.DescEng = "No";
                    acr.DescFre = "Non";
                }
            }
            else if(acr.ACSeriesRowByNextSteps.StepType == (int)StepType.NonRecorded)
            {
                //no default bf
            }
            else
            {
                acr.ACBFId = 327;
            }


        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            ActivityConfig.ACDependencyRow acdr = (ActivityConfig.ACDependencyRow)dr;
            switch (dc.ColumnName)
            {
                case ACDependencyFields.LinkType:
                    if (acdr.LinkType > 0 && acdr.LinkType<99) // zap ACBFID since not a nextstep connector
                        acdr.SetACBFIdNull();
                    break;
                default:
                    break;
            }
        }

	}
}

