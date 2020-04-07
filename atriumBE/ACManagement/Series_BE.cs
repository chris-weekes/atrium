using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class SeriesBE:atLogic.ObjectBE
	{
		ACManager myA;
		ActivityConfig.SeriesDataTable mySeriesDT;

		
		internal SeriesBE(ACManager pBEMng):base(pBEMng,pBEMng.DB.Series)
		{
			myA=pBEMng;
			mySeriesDT=(ActivityConfig.SeriesDataTable)myDT;

        }
        public atriumDAL.SeriesDAL myDAL
        {
            get
            {
                return (atriumDAL.SeriesDAL)myODAL;
            }
        }


        public override bool CanDelete(DataRow dr)
        {
            return myA.AtMng.SecurityManager.CanDelete(0, atSecurity.SecurityManager.Features.Series) == atSecurity.SecurityManager.LevelPermissions.All;
        }
        public override bool CanEdit(DataRow dr)
        {
            return myA.AtMng.SecurityManager.CanUpdate(0, atSecurity.SecurityManager.Features.Series) == atSecurity.SecurityManager.LevelPermissions.All;
        }

        protected override void AfterAdd(DataRow dr)
        {
            ActivityConfig.SeriesRow acr = (ActivityConfig.SeriesRow)dr;

            acr.SeriesId = myA.AtMng.PKIDGet("Series", 1);
            acr.CreatesFile = false;
            acr.OncePerFile = false;
            acr.ConfirmMultipleInstance = false;
            acr.SingleInstancePerFile = false;
            acr.Obsolete = false;
            acr.AllowMove = false;
            acr.AlwaysAvailable = false;

            //acr.ContainerFileId = 1;

            acr.SeriesDescEng = "Enter series description...";
            acr.SeriesDescFre = "Enter series description...";
        }

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {
            ActivityConfig.SeriesRow dr = (ActivityConfig.SeriesRow)ddr;
            switch (dc.ColumnName)
            {
                case SeriesFields.SeriesDescEng:
                    if (dr.IsNull("SeriesDescFre"))
                    {
                        dr.SeriesDescFre = dr.SeriesDescEng;
                        dr.EndEdit();
                    }

                    break;
                case "NameFormatE":
                    if (dr.IsNull("NameFormatF"))
                    {
                        dr.NameFormatF = dr.NameFormatE;
                        dr.EndEdit();
                    }
                    break;
                case SeriesFields.SeriesDescFre:
                    if (dr.IsNull("SeriesDescEng"))
                    {
                        dr.SeriesDescEng = dr.SeriesDescFre;
                        dr.EndEdit();
                    }

                    break;
                case "NameFormatF":
                    if (dr.IsNull("NameFormatE"))
                    {
                        dr.NameFormatE = dr.NameFormatF;
                        dr.EndEdit();
                    }
                    break;
            }
        }
        public ActivityConfig.SeriesRow Clone(ActivityConfig.SeriesRow oldSeries)
        {
            //copy series row
            ActivityConfig.SeriesRow newSeries = mySeriesDT.NewSeriesRow();
            
            newSeries.ItemArray = oldSeries.ItemArray;
            mySeriesDT.AddSeriesRow(newSeries);
            
            newSeries.CreatesFile = oldSeries.CreatesFile;
            newSeries.OncePerFile = oldSeries.OncePerFile;
            newSeries.ConfirmMultipleInstance = oldSeries.ConfirmMultipleInstance;
            newSeries.SingleInstancePerFile = oldSeries.SingleInstancePerFile;
            newSeries.Obsolete = oldSeries.Obsolete;

            newSeries.ContainerFileId = 0;
            newSeries.SeriesDescEng = "Copy of " + newSeries.SeriesDescEng;
            newSeries.SeriesDescFre = "Copie de " + newSeries.SeriesDescFre;

            System.Collections.Generic.Dictionary<int, int> concordance = new System.Collections.Generic.Dictionary<int, int>();

            //copy acseries rows
            foreach (ActivityConfig.ACSeriesRow acsr in oldSeries.GetACSeriesRows())
            {
                ActivityConfig.ACSeriesRow newAcsr = myA.DB.ACSeries.NewACSeriesRow();
                
                newAcsr.ItemArray = acsr.ItemArray;
                newAcsr.SeriesId = newSeries.SeriesId;
                myA.DB.ACSeries.AddACSeriesRow(newAcsr);

                concordance.Add(acsr.ACSeriesId, newAcsr.ACSeriesId);

                newAcsr.Finish = acsr.Finish;
                newAcsr.Start = acsr.Start;
                newAcsr.OnceOnly = acsr.OnceOnly;
                newAcsr.Seq =acsr.Seq;
                newAcsr.InitialStep = acsr.InitialStep;
                newAcsr.StepType = acsr.StepType;

                myA.GetACSeries().ReplaceRelFields(newAcsr, acsr,true);

                
                //foreach (ActivityConfig.ACConvertRow accr in acsr.GetACConvertRowsByACSeries_ACConvert())
                //{
                //    lmDatasets.ActivityConfig.ACConvertRow newAcc = myA.DB.ACConvert.NewACConvertRow();
                //    newAcc.ItemArray = accr.ItemArray;
                //    newAcc.ACSeriesId = accr.ACSeriesId;
                //    myA.DB.ACConvert.AddACConvertRow(newAcc);


                //}
            }


            foreach (ActivityConfig.ACSeriesRow acsr in oldSeries.GetACSeriesRows())
            {
                foreach (ActivityConfig.ACDependencyRow acdr in acsr.GetACDependencyRowsByNextSteps())
                {
                    lmDatasets.ActivityConfig.ACDependencyRow newAcd = myA.DB.ACDependency.NewACDependencyRow();

                    newAcd.ItemArray = acdr.ItemArray;
                    newAcd.CurrentStepId =concordance[ acdr.CurrentStepId];
                    if (concordance.ContainsKey(acdr.NextStepId))
                        newAcd.NextStepId = concordance[acdr.NextStepId];
                    else
                        newAcd.NextStepId = acdr.NextStepId;
                    myA.DB.ACDependency.AddACDependencyRow(newAcd);

                    newAcd.LinkType = acdr.LinkType;
                    if (!acdr.IsDescEngNull())
                        newAcd.DescEng = acdr.DescEng;
                    if (!acdr.IsDescFreNull())
                        newAcd.DescFre = acdr.DescFre;
                }
            }            
            return newSeries;
        }

        public DataTable Validate(ActivityConfig.SeriesRow sr)
        {
            return null;
        }

        public bool SeriesContainsStep(int seriesId, int acSeriesId)
        {
            return myA.DB.ACSeries.Select("Seriesid = " + seriesId.ToString() + " and acseriesid = " + acSeriesId.ToString()).Length > 0;
        }

	}
}

