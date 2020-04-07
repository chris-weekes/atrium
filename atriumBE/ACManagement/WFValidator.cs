using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atriumBE;
using lmDatasets;

namespace atriumBE
{
    public class WFValidator
    {
        public enum ValidationType
        {
            Error = 1,
            Warning = 2,
            Message = 3
        }

        int errorCount = 0;

        public int ErrorCount
        {
            get { return errorCount; }
            set { errorCount = value; }
        }
        int warningCount = 0;

        public int WarningCount
        {
            get { return warningCount; }
            set { warningCount = value; }
        }
        int messageCount = 0;

        public int MessageCount
        {
            get { return messageCount; }
            set { messageCount = value; }
        }

        ACManager acMng;
        public WFValidator(ACManager acm)
        {
            acMng = acm;
        }

        public void Clear()
        {
            ErrorCount = 0;
            MessageCount = 0;
            WarningCount = 0;

            acMng.DB.WFValidation.Clear();
        }
        public void ValidateWF(lmDatasets.ActivityConfig.SeriesRow sr)
        {

            Clear();

            foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in acMng.DB.ACSeries.Select("seriesid=" + sr.SeriesId))
            {

                if (acMng.GetACSeries().IsStart(acsr))
                {
                    //put rules that apply to start steps here
                    StartTypeRule(acsr);
                }

                if (acMng.GetACSeries().IsFinish(acsr))
                {
                    //put rules that apply to finish steps here
                    FinishTypeRule(acsr);
                }

                //put rules that test individual related field records here
                RelatedFieldsVerify(acsr);
                ConnectorRules(acsr);

                //put general rules here
                TemplateRule(acsr);
                InternalDecisionRule(acsr);

            }
        }

        private void ConnectorRules(ActivityConfig.ACSeriesRow acsr)
        {
            foreach (ActivityConfig.ACDependencyRow acdr in acsr.GetACDependencyRowsByNextSteps())
            {
                if (!acsr.SeriesRow.OncePerFile & !acsr.SeriesRow.SingleInstancePerFile & acdr.LinkType == (int)ConnectorType.Transfer)
                {
                    AddValidationRecord(acsr, ValidationType.Error, "You cannot use a 'Transfer' connector in a series that is not single instance or once per file.");
                }
            }
        }
        private void InternalDecisionRule(ActivityConfig.ACSeriesRow acsr)
        {
            if (acsr.StepType == (int)StepType.Decision && acsr.GetActivityFieldRows().Length>0)
            {
                //make sure connectors are Yes and No
                foreach (ActivityConfig.ACDependencyRow acdr in acsr.GetACDependencyRowsByNextSteps())
                {
                    if(acdr.DescEng=="Yes" || acdr.DescEng=="No")
                    {
                        //good
                    }
                    else
                        AddValidationRecord(acsr, ValidationType.Error, "Internal decision has invalid answer descriptions");

                    if (acdr.DescFre == "Oui" || acdr.DescFre == "Non")
                    {
                        //good
                    }
                    else
                        AddValidationRecord(acsr, ValidationType.Error, "Internal decision has invalid answer descriptions");
                }
            }
    
        }

        private void AddValidationRecord(ActivityConfig.ActivityFieldRow afr, ValidationType ErrorType, string validationText)
        {


            acMng.DB.WFValidation.AddWFValidationRow((int)ErrorType, afr.ACSeriesRow.StepCode, validationText, afr.ACSeriesRow.ACSeriesId, afr.ObjectAlias, afr.FieldName);
            acMng.DB.WFValidation.AcceptChanges();

            switch (ErrorType)
            {
                case ValidationType.Error:
                    errorCount++;
                    break;
                case ValidationType.Message:
                    messageCount++;
                    break;
                case ValidationType.Warning:
                    warningCount++;
                    break;
            }

        }



        private void AddValidationRecord(ActivityConfig.ACSeriesRow acsr, ValidationType ErrorType, string validationText)
        {


            acMng.DB.WFValidation.AddWFValidationRow((int)ErrorType, acsr.StepCode, validationText, acsr.ACSeriesId, "", "");
            acMng.DB.WFValidation.AcceptChanges();

            switch (ErrorType)
            {
                case ValidationType.Error:
                    errorCount++;
                    break;
                case ValidationType.Message:
                    messageCount++;
                    break;
                case ValidationType.Warning:
                    warningCount++;
                    break;
            }

        }

        //****begin rules


        //verify Related Fields data
        private void RelatedFieldsVerify(ActivityConfig.ACSeriesRow acsr)
        {
            List<string> objAliases = new List<string>();
            //Task Types
            // I - Issue
            // P - prompt
            // N - new record 
            // D - delete record
            // F - Related field
            // T - include
            // Q - queried record must return one record
            // S - select records can return 0 or more
            // L - load a record will load from db if record not already loaded
            // G - gets all records no criteria required
            // O - special object
            // R - repeat for block
            // U - one or more records must be returned
            // C - Query or new
            // M -  most recent for criteria
            for (int i = -10; i < 20; i++)
            {

                foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in acMng.DB.ActivityField.Select("TaskType<>'F' and Step="+i.ToString()+" and ACseriesid=" + acsr.ACSeriesId.ToString(), "seq"))
                {
                    if (!objAliases.Contains(afr.ObjectAlias) && (afr.TaskType == "Z" | afr.TaskType == "U" |afr.TaskType == "M" |afr.TaskType == "D" | afr.TaskType == "C" | afr.TaskType == "R" | afr.TaskType == "O" | afr.TaskType == "N" | afr.TaskType == "G" | afr.TaskType == "L" | afr.TaskType == "Q" | afr.TaskType == "S"))
                        objAliases.Add(afr.ObjectAlias);


                    if (afr.TaskType == "T")
                    {
                        //need to resolve "T" tasks
                        foreach (lmDatasets.ActivityConfig.ActivityFieldRow afrT in acMng.DB.ActivityField.Select("ACseriesid=" + afr.DefaultValue, "step,seq"))
                        {
                            if (!objAliases.Contains(afrT.ObjectAlias) && (afr.TaskType == "Z" | afrT.TaskType == "U" | afrT.TaskType == "M" | afrT.TaskType == "C" | afrT.TaskType == "R" | afrT.TaskType == "O" | afrT.TaskType == "N" | afrT.TaskType == "G" | afrT.TaskType == "L" | afrT.TaskType == "Q" | afrT.TaskType == "S"))
                                objAliases.Add(afrT.ObjectAlias);
                        }
                        //skip rules

                    }
                    else
                    {
                        //put rules that test individual related field records here
                        RelatedFieldsVerify(afr, objAliases);

                    }
                }

                foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in acMng.DB.ActivityField.Select("TaskType='F' and Step=" + i.ToString() + " and ACseriesid=" + acsr.ACSeriesId.ToString(), "seq"))
                {
                  
                    //put rules that test individual related field records here
                    RelatedFieldsVerify(afr, objAliases);

                  
                }

            }
        }

        private void RelatedFieldsVerify(ActivityConfig.ActivityFieldRow afr, List<string> objAliasesLoaded)
        {
            //if objectalias or defaultobject is not in alias list
            if (!objAliasesLoaded.Contains(afr.ObjectAlias))
                AddValidationRecord(afr, ValidationType.Error, "Object alias has not yet been loaded");
            if (!afr.IsDefaultObjectNameNull() && !objAliasesLoaded.Contains(afr.DefaultObjectName))
                AddValidationRecord(afr, ValidationType.Error, "Default object has not yet been referenced in an object alias");


            //If related field is a drop down type it must have a value for lookup
            if (afr.IsLookUpNull() && (afr.FieldType == "C" | afr.FieldType == "MC"))
                AddValidationRecord(afr, ValidationType.Error, "Related Field is a drop down control, but no Lookup value has been provided.");

            //JLL:2013-07-08
            //Can provide default value only for (DefaultValue) or (DefaultObjectName and DefaultFieldName)
            if (!afr.IsDefaultValueNull() && (!afr.IsDefaultObjectNameNull() || !afr.IsDefaultFieldNameNull()))
                AddValidationRecord(afr, ValidationType.Warning, "You have provided default values for both the Default Value column, as well as Default Object Name and/or Default Field Name.");

            //JLL:2013-07-08
            //Must provide value for DefaultFieldName if DefaultObjectName is populated
            //except when adding a new record
            if (!afr.IsDefaultObjectNameNull() && afr.IsDefaultFieldNameNull() && afr.TaskType != "N")
                AddValidationRecord(afr, ValidationType.Error, "When providing a value for Default Object Name, you must also provide a value for Default Field Name.");

            //JLL:2013-07-08
            //Must provide value for DefaultObjectName if DefaultFieldName is populated
            //except when adding a new record
            if (!afr.IsDefaultFieldNameNull() && afr.IsDefaultObjectNameNull() && afr.TaskType != "N" && afr.TaskType != "T")
                AddValidationRecord(afr, ValidationType.Error, "When providing a value for Default Field Name, you must also provide a value for Default Object Name.");

            //JLL:2013-07-08
            //If Queried Record, must provide (DefaultValue) or (DefaultObjectName and DefaultFieldName)
            if ((afr.TaskType.ToUpper() == "Q" | afr.TaskType.ToUpper() == "S" | afr.TaskType.ToUpper() == "M" | afr.TaskType.ToUpper() == "L" | afr.TaskType.ToUpper() == "U" | afr.TaskType.ToUpper() == "C") && afr.IsDefaultValueNull() && afr.IsDefaultObjectNameNull())
                AddValidationRecord(afr, ValidationType.Error, "Queried, Select or Load Record does not provide for a default value.");

            //JLL:2013-07-08
            //If related field not visible, and no defaults provided
            //Still valid since we do this to load data for templates.
            if (!afr.Visible && afr.TaskType.ToUpper() == "F" && afr.IsDefaultValueNull() && afr.IsDefaultObjectNameNull())
                AddValidationRecord(afr, ValidationType.Warning, "Non-visible field does not provide for a default value.");


        }


        //check start step type
        private void StartTypeRule(ActivityConfig.ACSeriesRow acsr)
        {
            switch ((StepType)acsr.StepType)
            {
                case StepType.Activity:
                case StepType.Decision:
                case StepType.NonRecorded:
                    //ok
                    break;
                default:
                    AddValidationRecord(acsr, ValidationType.Error, "Process must start on a Recorded Activity, Decision or Non-Recorded Step.");
                    break;
            }
        }


        //check finish step type
        //JLL:2013-07-09
        private void FinishTypeRule(ActivityConfig.ACSeriesRow acsr)
        {
            switch ((StepType)acsr.StepType)
            {
                case StepType.Activity:
                case StepType.Subseries:
                    //ok
                    break;
                default:
                    AddValidationRecord(acsr, ValidationType.Warning, "Process should end on a Recorded Activity or a Subprocess.");
                    break;
            }
        }


        //If StepTemplate has template, is language specified?
        private bool TemplateLanguageNotSpecified(ActivityConfig.ACSeriesRow acsr)
        {
            bool languageSpecified = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in acsr.GetActivityFieldRows())
            {
                if (!afr.IsNull("ObjectName") && afr.ObjectName.ToUpper() == "DOCUMENT" && afr.FieldName.ToUpper() == "LANGUAGECODE")
                {
                    if (!afr.IsDefaultValueNull() || (!afr.IsDefaultObjectNameNull() && !afr.IsDefaultFieldNameNull()))
                    {
                        languageSpecified = true;
                        break;
                    }
                }
            }
            return languageSpecified;
        }

        private bool TemplateExists(string TemplateCode)
        {
            acMng.AtMng.GetTemplate();
            lmDatasets.appDB.TemplateRow[] selectedTemplates = (lmDatasets.appDB.TemplateRow[])acMng.AtMng.DB.Template.Select("LetterName like '" + TemplateCode + "%'");
            if (selectedTemplates.Length == 0)
                return false;

            return true;
        }

        private void TemplateRule(ActivityConfig.ACSeriesRow acsr)
        {
            bool hasDoc = false;
            bool templateHookedUp = false;
            bool isEmail = false;
            bool languageSpecified = false;
            bool templateExists = false;
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in acsr.GetActivityFieldRows())
            {
                //If StepTemplate is "isEmail", doc template must be hooked up
                if (acsr.ActivityCodeRow.Communication)
                    isEmail = true;

                if (!afr.IsNull("ObjectName") && afr.ObjectName.ToUpper() == "DOCUMENT" && afr.FieldName.ToUpper() == "TEMPLATECODE")
                {
                    hasDoc = true;
                    templateHookedUp = true;
                    languageSpecified = TemplateLanguageNotSpecified(acsr);
                    if (afr.IsDefaultValueNull())
                        AddValidationRecord(acsr, ValidationType.Warning, "Related Fields reference a blank template code.");
                    else
                        templateExists = TemplateExists(afr.DefaultValue);
                }
            }
            if (isEmail && !templateHookedUp) //add error row
                AddValidationRecord(acsr, ValidationType.Error, "Step  is intended to be an e-mail, yet a template is not hooked up in Related Fields");

            if (hasDoc && !languageSpecified)
                AddValidationRecord(acsr, ValidationType.Warning, "Step has a document, yet the language is not set through Related Fields.");

            if (hasDoc && !templateExists)
                AddValidationRecord(acsr, ValidationType.Error, "Related Fields reference a template code that does not exist.");

        }
    }
}
