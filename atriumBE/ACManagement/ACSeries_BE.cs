using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    //associated with table ACSeriesType
    public enum StepType
    {
        Activity = 0,
        Subseries = 1,
        Decision = 2,
        Branch = 3,
        NonRecorded = 4,
        Start = 5,
        Stop = 6,
        Merge = 7,
        Move = 8,
        Convert = 9,
        Rule=10,
        Form=11,
        Action=12
    }
    public enum Step
    {
        NoStep = 0,
        PickIssue = 1,
        CreateFile = 2,
        PickActivity = 3,
        ACInfo = 5,
        Prompt,
        RelatedFields0,
        RelatedFields1,
        RelatedFields2,
        RelatedFields3,
        RelatedFields4,
        BFs,
        Disbursements,
        Billing,
        Document,
        Confirm
    }

    /// <summary>
    /// 
    /// </summary>
    public class ACSeriesBE : atLogic.ObjectBE
    {


        ACManager myA;
        ActivityConfig.ACSeriesDataTable myACSeriesDT;


        internal ACSeriesBE(ACManager pBEMng)
            : base(pBEMng, pBEMng.DB.ACSeries)
        {
            myA = pBEMng;
            myACSeriesDT = (ActivityConfig.ACSeriesDataTable)myDT;

        }
        public atriumDAL.ACSeriesDAL myDAL
        {
            get
            {
                return (atriumDAL.ACSeriesDAL)myODAL;
            }
        }

        public override bool CanDelete(DataRow dr)
        {
            return myA.AtMng.SecurityManager.CanDelete(0, atSecurity.SecurityManager.Features.ACSeries) == atSecurity.SecurityManager.LevelPermissions.All;
        }
        public override bool CanEdit(DataRow dr)
        {
            return myA.AtMng.SecurityManager.CanUpdate(0, atSecurity.SecurityManager.Features.ACSeries) == atSecurity.SecurityManager.LevelPermissions.All;
        }


        protected override void AfterAdd(DataRow dr)
        {

            ActivityConfig.ACSeriesRow acr = (ActivityConfig.ACSeriesRow)dr;

            acr.ACSeriesId = myA.AtMng.PKIDGet("ACSeries", 1);
            acr.Finish = false;
            if (acr.SeriesRow.GetACSeriesRows().Length == 1)
                acr.Start = true;
            else
                acr.Start = false;
            
            acr.OnceOnly = true;
            acr.Seq = acr.SeriesRow.GetACSeriesRows().Length * 10;
            acr.InitialStep = 5;
            acr.StepType = (int)StepType.Activity;

            acr.ForAgent = false;
            acr.ForClient = false;
            acr.ForOwner = false;
            acr.ForLead = false;
            acr.Obsolete = false;
            acr.StepCode = acr.ACSeriesId.ToString();
            acr.AutoChain = false;
            acr.AllowFileType = true;
            acr.NoResurface = false;
            acr.PauseParent = false;
            acr.StartParent = false;
            acr.StopParent = false;
            acr.ShowDisb = false;
            acr.ShowSkipDoc = false;
        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            ActivityConfig.ACSeriesRow acr = (ActivityConfig.ACSeriesRow)dr;
            switch (dc.ColumnName)
            {
                case "HelpE":
                    if (acr.IsHelpFNull() && !acr.IsHelpENull())
                    {
                        acr.HelpF = acr.HelpE;
                        acr.EndEdit();
                    }
                    break;
                case "DescEng":
                    if (acr.IsDescFreNull())
                    {
                        acr.DescFre = acr.DescEng;
                        acr.EndEdit();
                    }
                    break;

                case "HelpF":
                    if (acr.IsHelpENull() && !acr.IsHelpFNull())
                    {
                        acr.HelpE = acr.HelpF;
                        acr.EndEdit();
                    }
                    break;
                case "DescFre":
                    if (acr.IsDescEngNull())
                    {
                        acr.DescEng = acr.DescFre;
                        acr.EndEdit();
                    }
                    break;
                case ACSeriesFields.ActivityCodeID:
                    //create clone of activity code

                    //myA.GetActivityCode().NewACSeries(acr, myA.DB.ActivityCode.FindByActivityCodeID(acr.ActivityCodeID));
                    break;
                case "StepType":
                    switch ((StepType)acr.StepType)
                    {
                        case StepType.Branch:
                            acr.ActivityCodeID = -4;
                            break;
                        case StepType.Decision:
                            acr.ActivityCodeID = -1;
                            break;
                        case StepType.Merge:
                            acr.ActivityCodeID = -3;
                            break;
                        case StepType.NonRecorded:
                            acr.ActivityCodeID = -2;
                            break;
                        case StepType.Subseries:
                            acr.ActivityCodeID = -5;
                            break;
                        case StepType.Move:
                            acr.ActivityCodeID = -6;
                            break;
                        case StepType.Convert:
                            acr.ActivityCodeID = -7;
                            break;
                        case StepType.Form:
                            acr.ActivityCodeID = -9;
                            break;
                        case StepType.Action:
                            acr.ActivityCodeID = -7;
                            break;
                        case StepType.Rule:
                            acr.ActivityCodeID = -8;
                            break;
                    }
                    //if (!acr.IsNull("ActivityCodeID"))
                    //    myA.GetActivityCode().NewACSeries(acr, myA.DB.ActivityCode.FindByActivityCodeID(acr.ActivityCodeID));
                    break;
            }
        }


        public void ReplaceRelFields(ActivityConfig.ACSeriesRow asr, ActivityConfig.ACSeriesRow tempAC, bool ReplaceValues)
        {
            //delete ac field
            if (ReplaceValues)
            {
                foreach (ActivityConfig.ActivityFieldRow afrOld in asr.GetActivityFieldRows())
                {
                    afrOld.Delete();
                }
            }

            //this works if all the rel fields are for the same object
            //TODO:this fails if there are no activity field rows - why do we need the max instance
            //int instance=myA.GetActivityField().InstanceMax(asr,tempAC.GetActivityFieldRows()[0].ObjectName);
            //clone acfield reocrds
            ActivityConfig.ActivityFieldRow[] arfs = (ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("ACSeriesId=" + tempAC.ACSeriesId, "Step,Seq");
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow arf in arfs)
            {
                lmDatasets.ActivityConfig.ActivityFieldRow newArf = myA.DB.ActivityField.NewActivityFieldRow();
                newArf.ItemArray = arf.ItemArray;
                newArf.ACSeriesId = asr.ACSeriesId;
                myA.DB.ActivityField.AddActivityFieldRow(newArf);

                newArf.Seq = arf.Seq;
                newArf.Step = arf.Step;
                newArf.TaskType = arf.TaskType;
                //newArf.Instance = arf.Instance;// instance;
                newArf.Visible = arf.Visible;
                newArf.Required = arf.Required;
                newArf.ReadOnly = arf.ReadOnly;
                newArf.ObjectAlias = arf.ObjectAlias;
            }
        }

        public string GetRecordedStepText(ActivityConfig.ACSeriesRow acsr)
        {
            string lang="Eng",acText = "";

            if (myA.AppMan.Language.ToUpper() == "FRE")
                lang = "Fre";

            acText = acsr.ActivityCodeRow["ActivityName" + lang].ToString();
            if (acsr["Desc" + lang].ToString().Length > 0)
                    acText += " " + acsr["Desc" + lang].ToString();

            return acText;
        }

        public string GetSeriesText(ActivityConfig.ACSeriesRow acsr)
        {
            string srText = string.Empty;

            if (myA.AppMan.Language.ToUpper() == "ENG")
            {
                if (!acsr.IsSeriesDescEngNull())
                    srText = acsr.SeriesDescEng;
            }
            else
            {
                if (!acsr.SeriesRow.IsSeriesDescFreNull())
                    srText = acsr.SeriesRow.SeriesDescFre;
            }

            srText += " (" + acsr.StepCode + ")";
            
            return srText;
        }

        public string GetNodeText(ActivityConfig.ACSeriesRow acsr, StepType st, bool multiLine)
        
        {
            string newLine = " ";
            if (multiLine)
                newLine = Environment.NewLine;

            string acsrDesc = "";
            string acText = "",acSeriesText="";
            string acQuestion = "";
            
            ActivityConfig.SeriesRow ssr = null;
            if(!acsr.IsSubseriesIdNull())
                ssr = myA.DB.Series.FindBySeriesId(acsr.SubseriesId);

            if (myA.AppMan.Language.ToUpper() == "ENG")
            {
                //acText = "AC " + acsr.ActivityCodeRow.ActivityCode;
                //if (!acsr.IsSuffixNull())
                
                acText = acsr.ActivityCodeRow.ActivityNameEng;
                if (acsr.DescEng.Length > 0)
                    acText += ": " + acsr.DescEng;
                acText += newLine + " (" + acsr.StepCode + ")";
                acsrDesc = acsr.DescEng;
                
                //acText =  acsr.StepCode;
                //acText += newLine + acsr.ActivityCodeRow.ActivityNameEng;
                //acsrDesc = acsr.DescEng;
                //if(acsr.DescEng.Length>0)
                //    acText += " - " + acsr.DescEng;
                
                if (multiLine)
                    acQuestion = acsr.StepCode + newLine + acsr.DescEng;
                else
                    acQuestion = acsrDesc;
                if(ssr!=null)
                    acSeriesText = ssr.SeriesDescEng;
            }
            else
            {
                //acText = "AC " + acsr.ActivityCodeRow.ActivityCode;
                //if (!acsr.IsSuffixNull())

                acText = acsr.ActivityCodeRow.ActivityNameFre;
                if (acsr.DescFre.Length > 0)
                    acText += " : " + acsr.DescFre;
                acText += newLine + " (" + acsr.StepCode + ")";
                acsrDesc = acsr.DescFre;

                //acText =  acsr.StepCode;
                //acText += newLine + acsr.ActivityCodeRow.ActivityNameFre;
                //acsrDesc = acsr.DescFre;

                //acText += " : " + acsr.DescFre;
                if (multiLine)
                    acQuestion = acsr.StepCode + newLine + acsr.DescFre;
                else
                    acQuestion = acsrDesc;

                if (ssr != null)
                    acSeriesText = ssr.SeriesDescFre;
            }

            switch (st)
            {
                case StepType.Subseries:
                    return acSeriesText;

                case StepType.Branch:
                case StepType.Merge:
                case StepType.NonRecorded:
                case StepType.Move:
                case StepType.Convert:
                case StepType.Rule:
                case StepType.Action:
                    return acsrDesc;
                
                case StepType.Decision:
                    return acQuestion;
                
                default:
                    return acText;

            }
        }

        public bool IsObsolete(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            bool isObsolete = true;
            if (acs.Obsolete)
                return isObsolete;
            else
            {
                foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByPreviousSteps())
                {
                    if (acdr.LinkType != (int)ConnectorType.Obsolete)
                    {
                        isObsolete = false;
                        break;
                    }
                }
                return isObsolete;
            }
        }

        public bool IsStart(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            bool isStart = true;
            foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByPreviousSteps())
            {

                if (acdr.ACSeriesRowByNextSteps.SeriesId == acs.SeriesId)
                {
                    if (acdr.LinkType == (int)ConnectorType.BFOnly && acs.StepType == (int)StepType.Activity)
                    {

                    }
                    else
                    {
                        isStart = false;
                        break;
                    }
                }

            }
            return isStart;
        }

        public bool IsFinish(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            bool finish = false;
            int subCount = 0;
            if (acs.GetACDependencyRowsByNextSteps().Length == 0)
                return true;

            foreach (lmDatasets.ActivityConfig.ACDependencyRow acd in acs.GetACDependencyRowsByNextSteps())
            {
                //if (!acd.ACSeriesRowByPreviousSteps.IsSubseriesIdNull())
                //    subCount++;
                //else 

                if (acd.LinkType == (int)atriumBE.ConnectorType.Obsolete)
                    subCount++;
            }
            if (subCount == acs.GetACDependencyRowsByNextSteps().Length)
                finish = true;

            return finish;
        }

        public bool hasPerformADMSLookup(ActivityConfig.ACSeriesRow acs)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
            bool hasNewADMSLookupRow = false;
            bool hasCall = false;
            bool hasSend = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
            {
                if (afr.TaskType == "N" && afr.ObjectName == "ADMSLookup")
                    hasNewADMSLookupRow = true;
                if (afr.TaskType == "F" && afr.ObjectName == "ADMSLookup" && afr.FieldName == "Call")
                    hasCall = true;
                if (afr.TaskType == "F" && afr.ObjectName == "ADMSLookup" && afr.FieldName == "Send" && (!afr.IsDefaultValueNull() && afr.DefaultValue.ToUpper() == "TRUE"))
                    hasSend = true;
            }
            if (hasNewADMSLookupRow && hasCall && hasSend)
                return true;

            return false;
        }

        public bool hasAppealDataXchange(ActivityConfig.ACSeriesRow acs)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
            bool hasADMSAppealrow = false;
            bool hasData = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
            {
                if (afr.TaskType == "N" && (afr.ObjectName == "ADMSEAppeal" || afr.ObjectName == "ADMSPAppeal"))
                    hasADMSAppealrow = true;
                if (afr.TaskType == "F" && (afr.ObjectName == "ADMSEAppeal" || afr.ObjectName == "ADMSPAppeal") && (!afr.IsDefaultValueNull() || !afr.IsDefaultObjectNameNull())) //at least one related field with a value
                    hasData = true;
            }
            if (hasADMSAppealrow && hasData)
                return true;

            return false;
        }

        public bool hasADMSDumpParticipants(ActivityConfig.ACSeriesRow acs)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
            bool hasNewADMSLookupRow = false;
            bool hasDump = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
            {
                if (afr.TaskType == "N" && afr.ObjectName == "ADMSLookup")
                    hasNewADMSLookupRow = true;
                if (afr.TaskType == "F" && afr.ObjectName == "ADMSLookup" && afr.FieldName == "DumpParticipants" && (!afr.IsDefaultValueNull() && afr.DefaultValue.ToUpper() == "TRUE"))
                    hasDump = true;
            }
            if (hasNewADMSLookupRow && hasDump)
                return true;

            return false;
        }

        public bool hasADMSDumpIssues(ActivityConfig.ACSeriesRow acs)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
            bool hasNewADMSLookupRow = false;
            bool hasDump = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
            {
                if (afr.TaskType == "N" && afr.ObjectName == "ADMSLookup")
                    hasNewADMSLookupRow = true;
                if (afr.TaskType == "F" && afr.ObjectName == "ADMSLookup" && afr.FieldName == "DumpIssues" && (!afr.IsDefaultValueNull() && afr.DefaultValue.ToUpper() == "TRUE"))
                    hasDump = true;
            }
            if (hasNewADMSLookupRow && hasDump)
                return true;

            return false;
        }

        public bool hasSendingOfDecision(ActivityConfig.ACSeriesRow acs)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
            bool hasNewADMSDecision = false;
            bool hasDecision = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
            {
                if (afr.TaskType == "N" && (afr.ObjectName == "ADMSEDecision" || afr.ObjectName == "ADMSPDecision"))
                    hasNewADMSDecision = true;
                if (afr.TaskType == "F" && (afr.ObjectName == "ADMSEDecision" || afr.ObjectName == "ADMSPDecision") && afr.FieldName == "DecisionDocument")
                    hasDecision = true;
            }
            if (hasNewADMSDecision && hasDecision)
                return true;

            return false;
        }

        public bool hasDocXchange(ActivityConfig.ACSeriesRow acs)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myA.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
            bool hasDocTransfer = false;
            bool hasDump = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
            {
                if (afr.TaskType == "N" && afr.ObjectName == "DocTransfer")
                    hasDocTransfer = true;
                if (afr.TaskType == "F" && afr.ObjectName == "DocTransfer" && afr.FieldName == "Dump" && (!afr.IsDefaultValueNull() && afr.DefaultValue.ToUpper() == "TRUE"))
                    hasDump = true;
            }
            if (hasDocTransfer && hasDump)
                return true;

            return false;
        }

        public bool isAnAutoStep(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByPreviousSteps())
            {
                if (acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                    return true;
            }
            return false;
        }

        public bool hasAnAutoStep(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByNextSteps())
            {
                if (acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                    return true;
            }
            return false;
        }

        public ActivityConfig.ACSeriesRow GetAutoStep(ActivityConfig.ACSeriesRow acs)
        {
            foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByNextSteps())
            {
                if (acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                    return acdr.ACSeriesRowByPreviousSteps;
            }
            return null;
 
        }

    }
}

