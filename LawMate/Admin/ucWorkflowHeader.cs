using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class ucWorkflowHeader : UserControl
    {
        atriumBE.atriumManager Atmng;

        public ucWorkflowHeader()
        {
            InitializeComponent();
        }

        public void Init(atriumBE.atriumManager atmng)
        {
            Atmng = atmng;
        }

        public void SetWorkflow(lmDatasets.ActivityConfig.SeriesRow sr)
        {
            ebSeriesName.Text = sr.SeriesCode + " - " + sr.SeriesDescEng;
 
        }
        public void SetStep(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            ebStep.Text = Atmng.acMng.GetACSeries().GetNodeText(acs, (atriumBE.StepType)acs.StepType, false);

            switch ((atriumBE.StepType)acs.StepType)
            {
                case atriumBE.StepType.Activity:
                    ebStep.Text = acs.StepCode + " - " + Atmng.acMng.GetACSeries().GetRecordedStepText(acs);
                    ebStep.Image = Properties.Resources.act;
                    break;
                case atriumBE.StepType.Decision:
                    ebStep.Text = acs.StepCode + " - " + acs.DescEng;
                    if (acs.GetActivityFieldRows().Length > 0)
                        ebStep.Image = Properties.Resources.batch;
                    else
                        ebStep.Image = Properties.Resources.decision;
                    break;

                case atriumBE.StepType.Form:
                case atriumBE.StepType.Action:
                case atriumBE.StepType.Rule:
                case atriumBE.StepType.NonRecorded:
                    ebStep.Text = acs.StepCode + " - " + acs.DescEng;
                    ebStep.Image = Properties.Resources.nonrecorded;
                    break;
                case atriumBE.StepType.Subseries:
                    if (!acs.IsSubseriesIdNull())
                    {
                        lmDatasets.ActivityConfig.SeriesRow sr = Atmng.acMng.DB.Series.FindBySeriesId(acs.SubseriesId);
                        ebStep.Text = "Go To " + sr.SeriesCode + ": " + sr.SeriesDescEng;
                    }
                    else
                        ebStep.Text = "SUBPROCESS NOT FOUND";
                    ebStep.Image = Properties.Resources.subprocess;
                    break;
            }

        }

        public void SetNull()
        {
            ebStep.Text = "";
            ebSeriesName.Text = "";
            ebStep.Image = null;
        }
    }
}
