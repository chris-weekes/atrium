using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atriumBE;
using lmDatasets;
using System.Xml;

namespace lmras.Workflow
{
    public class WFHelp : IDisposable
    {
        string RecordedActivity;
        string NonRecordedActivity;
        string Decision;
        string Subprocess;

        public ACManager myACM;
        AtriumApp appMan;
        atriumManager atMng;

        private void appManInit()
        {
            string userName = System.Configuration.ConfigurationManager.AppSettings["SQLUserNameForWorkflow"].ToString();
            if (String.IsNullOrEmpty(userName))
            {
                //AD autentication
                appMan = new AtriumApp("ENG", "DATABASE1");
            }
            else
            {
                //SQL autentication
                string password = System.Configuration.ConfigurationManager.AppSettings["SQLPasswordForWorfklow"].ToString();
                appMan = new AtriumApp(userName, password, "ENG", "DATABASE1");
            }
            atMng = appMan.AtMng;
            atMng.LoadDDInfo();
            myACM = atMng.acMng;
 
        }

        public WFHelp()
        {

            appManInit();
            myACM.LoadAllConfigInfo();
          //  myACM.GetOfficeMandate().Load();
            SetLabels();

        }



        public WFHelp(bool loadConfig)
        {

            appManInit();
            if (loadConfig)
            {
                myACM.LoadAllConfigInfo();
              //  myACM.GetOfficeMandate().Load();
            }
            SetLabels();
        }

        private void SetLabels()
        {
            RecordedActivity = getResource("WFRecordedAct");
            NonRecordedActivity = getResource("WFNonRecordedAct");
            Decision = getResource("WFDecision");
            Subprocess = getResource("WFSubprocess");
        }

        public string getBFType(int bftype)
        {
            string rbf = "";
            switch (bftype)
            {
                case 2:
                    rbf = getResource("lblDirectBF");
                    break;
                case 7:
                    rbf = getResource("lblRoleBF");
                    break;

            }
            return rbf;
        }

        public string getResource(string resourceName)
        {
            string resource = "RESOURCE_NOT_FOUND";
            try
            {
                return resource = HttpContext.GetGlobalResourceObject("LocalizedText", resourceName).ToString();
            }
            catch(Exception e)
            {
                return resource;
            }
            
        }

        public string AcDocRowHTMLOutput(WFHelp wfhelp, ActivityConfig.ACSeriesRow acsr, string acDocName, bool isEditMode, string headingLabel, string lang)
        {
            string rHtml = "";
            lmDatasets.ActivityConfig.ACDocumentationRow acDocRow = wfhelp.AcDocRow(acsr.Table.TableName.ToLower(), acsr.ACSeriesId, acDocName);
            if(acDocRow!=null)
            {
                rHtml = "<p><strong>" + wfhelp.getResource("lblPurpose") + " </strong>";
                if (isEditMode)
                {
                    rHtml += "<a class=\"aEdit\" href=\"javascript:launchAcDocNote(false,'','','"+acDocName+"'," + acDocRow.ACDocId + ");\"><img alt=\"\" src=\"images/edit.png\" />" + wfhelp.getResource("acdocEdit") + "</a>";
                    rHtml += "<a class=\"aEdit\" href=\"javascript:deleteAcDocNote(" + acDocRow.ACDocId + ");\"><img alt=\"\" src=\"images/delete.png\" />" + wfhelp.getResource("acdocDelete") + "</a>";
                }
                rHtml += "</p>";
                rHtml += "<p>" + acDocRow["Text" + lang] + "</p><br/>";
            }
            else if (isEditMode)
            {
                rHtml += "<p><strong>" + wfhelp.getResource("lblPurpose") + "</strong>";
                rHtml += "<a class=\"aEdit2\" href=\"javascript:launchAcDocNote(true,'acseries','"+acsr.ACSeriesId+"','"+acDocName+"',null);\"><img alt=\"\" src=\"images/newrecord.gif\" />"+ wfhelp.getResource("acdocAdd") + "</a></p><div class=\"clear\"></div>";
            }

            return rHtml;
        }

        public string getRoleType(string roleCode, bool upperFirst, string lang)
        {
            System.Data.DataTable dtRole = myACM.AtMng.GetFile().Codes("RoleCode");
            System.Data.DataRow[] drRole = dtRole.Select("RoleCode='" + roleCode + "'", "");
            string roleType = "global";
            if (upperFirst)
                roleType = "Global";
            if (drRole.Length == 0)
            {
                if(lang.ToUpper()=="ENG")
                    roleType = "file-based";
                else
                    roleType = "basé sur un dossier";
                if (upperFirst)
                {
                    if (lang.ToUpper() == "ENG")
                        roleType = "File-Based";
                    else
                        roleType = "Basé sur un dossier";
                }
            }
            return roleType;
        }

        public string getRoleDesc(string roleCode, string lang)
        {
            System.Data.DataTable dtRole = myACM.AtMng.GetFile().Codes("RoleCode");
            System.Data.DataRow[] drRole = dtRole.Select("RoleCode='" + roleCode + "'", "");
            string roleDesc;
            if (drRole.Length == 0)
            {
                dtRole = myACM.AtMng.GetFile().Codes("ContactType");
                drRole = dtRole.Select("ContactTypeCode='" + roleCode + "'", "");
                roleDesc = drRole[0]["ContactTypeDesc" + lang].ToString();
            }
            else
                roleDesc = drRole[0]["Role"+ lang].ToString();

            return roleDesc;
        }

        public bool hasPerformADMSLookup(ActivityConfig.ACSeriesRow acs)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
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
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
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
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
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
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
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
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
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
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("AcSeriesId=" + acs.ACSeriesId, "step, seq");
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

        public lmDatasets.ActivityConfig.ACSeriesRow GetPreviousStepToAutoStep(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByPreviousSteps())
            {
                if (acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                    return acdr.ACSeriesRowByNextSteps;
            }
            return null;
        }

        public SortedDictionary<string, lmDatasets.ActivityConfig.ACSeriesRow> GetAutoStepsAhead(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            SortedDictionary<string, lmDatasets.ActivityConfig.ACSeriesRow> rList = new SortedDictionary<string, ActivityConfig.ACSeriesRow>();
            foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByNextSteps())
            {
                if (acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                {
                    if (!rList.ContainsValue(acdr.ACSeriesRowByPreviousSteps))
                        rList.Add(acdr.ACSeriesRowByPreviousSteps.StepCode, acdr.ACSeriesRowByPreviousSteps);
                }
            }
            return rList;
        }



        public ActivityConfig.ACDependencyRow[] NextSteps(ActivityConfig.ACSeriesRow acs)
        {

            return NextSteps(acs, 0);
        }
        public ActivityConfig.ACDependencyRow[] EnableSteps(ActivityConfig.ACSeriesRow acs)
        {
            ActivityConfig.ACDependencyRow[] enableACDs = NextSteps(acs, 2);
            ActivityConfig.ACDependencyRow[] transferACDs = NextSteps(acs, 9);
            ActivityConfig.ACDependencyRow[] combinedACDs = enableACDs.Concat(transferACDs).ToArray();
            
            return combinedACDs;

        }
        public ActivityConfig.ACDependencyRow[] DisalbeSteps(ActivityConfig.ACSeriesRow acs)
        {

            return NextSteps(acs, 3);
        }
        private ActivityConfig.ACDependencyRow[] NextSteps(ActivityConfig.ACSeriesRow acs, int linkType)
        {
            ActivityConfig.ACDependencyRow[] acds = (ActivityConfig.ACDependencyRow[])myACM.DB.ACDependency.Select("LinkType=" + linkType.ToString() + " and CurrentStepId=" + acs.ACSeriesId.ToString(), "Seq");

            return acds;
        }

        public string UsedRecordsHTMLOutput(ActivityConfig.ActivityFieldRow afr, string lang)
        {
            string RowOutput = "";

            //Retrieve TaskType display text
            string taskType = GetTaskTypeValue(afr.TaskType);
            if (taskType == "")
                taskType = "Invalid_Task_Type | Type_de_tâche_non_valide";

            //Retrieve DefaultValues
            string parentRow = "";
            string defaultValue = "";
            List<string> parDefList = GetParentRowOrDefaultValue(afr, lang);
            if (parDefList[0] != "")
                parentRow = parDefList[0];
            if (parDefList[1] != "")
                defaultValue = parDefList[1];

            if (afr.TaskType == "T") // make link to show all included data, class for T tr
            {
                RowOutput = "<tr class=\"trinc\"><td colspan=\"6\">" + taskType + " <a target=\"_blank\" href=\"RFInclude.aspx?acseriesid=" + afr.DefaultValue + "&hostacseriesid=" + afr.ACSeriesId + "\">" + defaultValue + "</a>";
            }
            else
                RowOutput = "<tr><td>" + taskType + "</td><td>" + afr.ObjectName + "</td><td>" + afr.FieldName + "</td><td><strong>" + afr.ObjectAlias + "</strong></td><td>" + parentRow + "</td><td>" + defaultValue + "</td></tr>";

            return RowOutput;

        }

        public string PrntScreenTop(ActivityConfig.ACSeriesRow acs, string lang)
        {
            string rHTML;

            rHTML = "<table class=\"naw\"><tr><td class=\"nawTL\"></td><td class=\"nawT\"></td><td class=\"nawTR\"></td></tr><tr>";
            rHTML += "<td class=\"nawL\"></td><td class=\"ttlBar\"><div class=\"ttlBarLeft\"><img alt=\"\" src=\"images/nawicon.png\" />" + acs.StepCode + " - " + acs["ActivityName" + lang] + "</div><div class=\"ttlBarRight\"><img alt=\"\" src=\"images/toolbox.png\" /></div></td>";
            rHTML += "<td class=\"nawR\"></td></tr><tr><td class=\"nawL\"></td><td class=\"nawheader\"><div class=\"nawhdrttl\"><img alt=\"\" src=\"images/relFields.png\" />" + getResource("lblRelatedFields") + "</div><div class=\"nawhdrtext\">"+getResource("lblAtriumExpects")+"</div></td>";
            rHTML += "<td class=\"nawR\"></td></tr><tr><td class=\"nawL\"></td><td class=\"nawContent\"><div class=\"rlfldlayout\"><table class=\"rlfldtbl\">";

            return rHTML;
        }

        public string PrntScreenBottom()
        {
            string rHTML;

            rHTML = "</table></div><div class=\"clear\"></div></td><td class=\"nawR\"></td></tr><tr><td class=\"nawL\"></td><td>";
            rHTML += "<div class=\"footerBtnBar\"><img alt=\"\" src=\"images/btnSuspendOn.png\" /><img alt=\"\" src=\"images/btnCancelOn.png\" /><img alt=\"\" src=\"images/btnBackOn.png\" /><img alt=\"\" src=\"images/btnNextOn.png\" /><img alt=\"\" src=\"images/btnLastOn.png\" /><img alt=\"\" src=\"images/btnFinishOn.png\" />";
            rHTML += "</div></td><td class=\"nawR\"></td></tr><tr><td class=\"nawBL\"></td><td class=\"nawB\"></td><td class=\"nawBR\"></td></tr></table>";

            return rHTML;
        }

        public string HiddenFieldsHTMLOutput(ActivityConfig.ActivityFieldRow afr, string lang)
        {
            string RowOutput = "";
            string defaultValue = "";
            List<string> parDefList = GetParentRowOrDefaultValue(afr, lang);
            defaultValue = parDefList[1];

            string defaultDisplay;
            if (afr.FieldName.ToUpper() == "TEMPLATECODE")
            {
                if (!afr.IsDefaultValueNull())
                    defaultDisplay = "<a href=\"docdisplay.aspx?fileid=1028654&templatecode=" + afr.DefaultValue + "\" class=\"tmplt\" title=\"" + getResource("lblViewSourceTemplate") + "\"><img alt=\"\" src=\"images/word.png\"/>" + defaultValue + "</a>";
                else
                    defaultDisplay = "";
            }
                
            else
                defaultDisplay = defaultValue;

            RowOutput = "<tr><td><strong>" + afr.ObjectAlias + "</strong></td><td>" + afr.FieldName + "</td><td>" + defaultDisplay + "</td></tr>";
            return RowOutput;

        }

        public string DisplayedFieldsTableHTMLOutput(ActivityConfig.ActivityFieldRow afr, string lang)
        {
            string RowOutput = "";
            string defaultValue = "";
            List<string> parDefList = GetParentRowOrDefaultValue(afr, lang);
            defaultValue = parDefList[1];

            string vlookup = afr.IsLookUpNull() ? "" : afr.LookUp;
            string vcontrol = afr.IsFieldTypeNull() ? "" : ControlType(afr.FieldType);
            string vparam = afr.IsSpecialParameterNull() ? "" : afr.SpecialParameter;
            string vreq = afr.Required ? "<img src=\"images/checkbox.gif\" alt=\"\"/>" : "";
            string vreadonly = afr.ReadOnly ? "<img src=\"images/checkbox.gif\" alt=\"\"/>" : "";
            string vlabel = afr.IsNull("Label" + lang) ? "" : afr["Label" + lang].ToString();
            string vHelp = afr.IsNull("Help" + lang.Substring(0,1).ToUpper())  ? "" : afr["Help" + lang.Substring(0,1).ToUpper()].ToString();

            RowOutput = "<tr><td><strong>" + afr.ObjectAlias + "</strong></td><td>" + afr.FieldName + "</td><td>" + vlookup + "</td><td>" + vcontrol + "</td><td>" + vparam + "</td><td>" + defaultValue + " </td><td class=\"cntr\">" + vreq + "</td><td class=\"cntr\">" + vreadonly + "</td><td>" + vlabel + "</td><td>" + vHelp + "</td></tr>";
            return RowOutput;

        }

        public string ReqOrRoClass(ActivityConfig.ActivityFieldRow afr)
        {
            string rClass = "";
            if (afr.ReadOnly)
                rClass = "RO";
            else if (afr.Required)
                rClass = "Req";

            return rClass;

        }

        public string LayoutHTMLOutput(ActivityConfig.ActivityFieldRow afr, string lang)
        {
            string RowOutput = "<tr>";

            //default to textbox
            string fldType = "TB";

            //if not null, set to specified control.
            if (!afr.IsFieldTypeNull())
                fldType = afr.FieldType.ToUpper();

            //if address control, handle separately
            if (fldType == "AD")
                RowOutput += "<td class=\"adLabels\"></td><td class=\"ad\"></td>";

            else if (fldType == "CM")
            {
                if (!afr.IsSpecialParameterNull() && afr.SpecialParameter.ToLower() == "prompt")
                {
                    RowOutput += "<td colspan=\"2\" class=\"icPrompt\"></td>";
                }
                else if (!afr.IsSpecialParameterNull() && afr.SpecialParameter.ToLower() == "setoutcome")
                {
                    RowOutput += "<td colspan=\"2\" class=\"icSetOutcome\"></td>";
                }
                else
                {
                    RowOutput += "<td colspan=\"2\" class=\"icNone\"></td>";
                }
            }
            else if (fldType == "M") // grid control
            {
                //table headers
                ActivityConfig.ActivityFieldRow[] grdRows = (ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("acseriesid=" + afr.ACSeriesId + " and tasktype='F' and objectalias='" + afr.ObjectAlias + "' and step='" + afr.Step + "'", "seq");
                bool mColumnIsHidden;
                int ColumnCount;
                string pipe = "";
                if (!afr.IsSpecialParameterNull() && afr.SpecialParameter.ToLower() == "hide")
                {
                    mColumnIsHidden = true;
                    ColumnCount = grdRows.Length - 1;
                }
                else
                {
                    mColumnIsHidden = false;
                    ColumnCount = grdRows.Length;
                }

                RowOutput += "<td colspan=\"2\"><div class=\"layoutbg\"><table class=\"layoutGrid\"><tr><th class=\"grdCaption\" colspan=\"" + ColumnCount.ToString() + "\">" + afr["Label" + lang] + "</th></tr><tr>";
                foreach (ActivityConfig.ActivityFieldRow af in grdRows)
                {
                    if (mColumnIsHidden && af == afr)
                        continue;

                    if (af != grdRows[grdRows.Length - ColumnCount]) // if not first column, add pipe
                        pipe = "<span class=\"pipe\">| </span>";
                    string lstClass = ""; //IE8 does not support last-child css, so we'll manually add a class to the last child
                    if (af == grdRows.Last())
                        lstClass = " lst";

                    string label = af["Label" + lang].ToString();
                    if (!mColumnIsHidden && af == afr)
                        label = af.FieldName;

                    RowOutput += "<th class=\"grdHeader" + lstClass + "\">" + pipe + label + "</th>";
                }

                RowOutput += "</tr>";
                //end table headers

                RowOutput += "<tr>";

                //insert fake row here
                foreach (ActivityConfig.ActivityFieldRow af in grdRows)
                {
                    if (mColumnIsHidden && af == afr)
                        continue;

                    string className = elementClassName("grd", af);
                    if (className != "")
                        className = " class=\"fkRow " + className + "\"";
                    else
                        className = " class=\"fkRow\"";

                    RowOutput += "<td" + className + ">" + GetParentRowOrDefaultValue(af, lang)[1] + "</td>";
                }

                RowOutput += "</tr></table></div></td>";

            }

            else //draw out control
            {
                //check to see if acticityfield row is part of grid, if so, skip adding the control
                bool isPartOfGrid = false;
                ActivityConfig.ActivityFieldRow[] gridActFldRow = (ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("acseriesid=" + afr.ACSeriesId + " and fieldtype='M' and step='" + afr.Step + "'", "seq");
                if (gridActFldRow.Length > 0)
                {
                    //there is a grid displayed; find rows meant for grid
                    ActivityConfig.ActivityFieldRow[] grdRows = (ActivityConfig.ActivityFieldRow[])myACM.DB.ActivityField.Select("acseriesid=" + afr.ACSeriesId + " and objectalias='" + gridActFldRow[0].ObjectAlias + "' and step='" + gridActFldRow[0].Step + "'", "seq");
                    //loop through rows to see if we should skip adding the control
                    foreach (ActivityConfig.ActivityFieldRow grdAfr in grdRows)
                    {
                        if (afr == grdAfr)
                        {
                            isPartOfGrid = true;
                            break;
                        }
                    }
                }

                if (!isPartOfGrid) //determine which class to set to <td> so correct control img is displayed as bg
                {
                    RowOutput += "<td>" + afr["Label" + lang] + ":</td>";
                    string className = "";
                    if (fldType == "T")
                        className = "t" + ReqOrRoClass(afr);

                    if (fldType == "A")
                        className = "a" + ReqOrRoClass(afr);

                    if (fldType == "?")
                        className = "docUpl" + ReqOrRoClass(afr);

                    if (fldType == "?C")
                        className = "selContact" + ReqOrRoClass(afr);

                    if (fldType == "?F")
                        className = "selFile" + ReqOrRoClass(afr);

                    if (fldType == "?D")
                        className = "selDoc" + ReqOrRoClass(afr);

                    if (fldType == "?O")
                        className = "selOffice" + ReqOrRoClass(afr);

                    if (fldType == "?W")
                        className = "selParty" + ReqOrRoClass(afr);

                    if (fldType == "?I")
                        className = "selIssue" + ReqOrRoClass(afr);

                    if (fldType == "TB" || fldType == "P" || fldType == "B")
                        className = "tb" + ReqOrRoClass(afr);

                    if (fldType == "C" || fldType == "MC")
                        className = "c" + ReqOrRoClass(afr);

                    if (fldType == "X")
                        className = "x" + ReqOrRoClass(afr);


                    if (className != "")
                        className = " class=\"" + className + "\"";

                    RowOutput += "<td" + className + ">";

                    // if there is a mask, display it as a user sees it in the UI
                    if (!afr.IsMaskNull())
                    {
                        string maskOutput = afr.Mask.Replace("#", "_");
                        maskOutput = maskOutput.Replace("0", "_");
                        maskOutput = maskOutput.Replace("L", "_");
                        RowOutput += maskOutput;
                    }

                    //if there is a default value, display lookup value, or object/field calculation
                    if (GetParentRowOrDefaultValue(afr, lang)[1] != "")
                    {
                        if (afr.IsLookUpNull())
                            RowOutput += "<div>{ " + GetParentRowOrDefaultValue(afr, lang)[1] + " }</div>";
                        else
                        {
                            if (!afr.IsDefaultValueNull())
                            {
                                //look up value in lookup table
                                System.Data.DataTable dt = myACM.AtMng.GetFile().Codes(afr.LookUp);
                                System.Data.DataRow[] dr = dt.Select(dt.Columns[0].ColumnName + "='" + afr.DefaultValue + "'", "");
                                if (dr.Length > 0)
                                {
                                    int langColumn = 1;
                                    if (lang.ToUpper() == "FRE")
                                        langColumn = 2;
                                    
                                    RowOutput += "<div>" + dr[0][langColumn].ToString() + "</div>";
                                }
                                else
                                    RowOutput += "<div>" + afr.DefaultValue + "</div>";
                            }
                            else if (!afr.IsDefaultObjectNameNull() && !afr.IsDefaultFieldNameNull())
                            {
                                RowOutput += "<div>{ " + GetParentRowOrDefaultValue(afr, lang)[1] + " }</div>";
                            }
                        }
                    }
                    //if there is help, add icon after; class nesting will determine positioning
                    if (!afr.IsNull("Help" + lang.Substring(0,1).ToUpper()))
                    {
                        RowOutput += "<img title=\"" + System.Web.HttpUtility.HtmlAttributeEncode(afr["Help" + lang.Substring(0, 1).ToUpper()].ToString()) + "\" class=\"hlpicn\" alt=\"\" src=\"images/help.gif\"/>";
                    }

                    RowOutput += "</td>";
                }
            }

            RowOutput += "</tr>";
            return RowOutput;
        }



        private string elementClassName(string prefix, ActivityConfig.ActivityFieldRow afr)
        {
            string className;

            switch (afr.FieldType.ToUpper())
            {
                case "T":
                    className = prefix + "t" + ReqOrRoClass(afr);
                    break;
                case "A":
                    className = prefix + "a" + ReqOrRoClass(afr);
                    break;
                case "?":
                    className = prefix + "docUpl" + ReqOrRoClass(afr);
                    break;
                case "?C":
                    className = prefix + "selContact" + ReqOrRoClass(afr);
                    break;
                case "?F":
                    className = prefix + "selFile" + ReqOrRoClass(afr);
                    break;
                case "?D":
                    className = prefix + "selDoc" + ReqOrRoClass(afr);
                    break;
                case "?O":
                    className = prefix + "selOffice" + ReqOrRoClass(afr);
                    break;
                case "?W":
                    className = prefix + "selParty" + ReqOrRoClass(afr);
                    break;
                case "?I":
                    className = prefix + "selIssue" + ReqOrRoClass(afr);
                    break;
                case "TB":
                case "P":
                case "B":
                    className = prefix + "tb" + ReqOrRoClass(afr);
                    break;
                case "C":
                case "MC":
                    className = prefix + "c" + ReqOrRoClass(afr);
                    break;
                case "X":
                    className = prefix + "x" + ReqOrRoClass(afr);
                    break;
                default:
                    className = "";
                    break;
            }

            return className;
        }


        private string ControlType(string controlType)
        {
            string rControl = "";
            string imgSrc = "";
            switch (controlType)
            {
                case "TB":
                    rControl = getResource("ctlTxtFld");
                    imgSrc = "txtfld.gif";
                    break;
                case "X":
                    rControl = getResource("ctlchkbx");
                    imgSrc = "checkbox.png";
                    break;
                case "C":
                    rControl =getResource("ctlDD");
                    imgSrc = "dd.png";
                    break;
                case "M":
                    rControl =getResource("ctlGrid");
                    imgSrc = "grid.gif";
                    break;
                case "P":
                    rControl = getResource("ctlpercent");
                    imgSrc = "txtfld.gif";
                    break;
                case "T":
                    rControl = getResource("ctlMultilineText");
                    imgSrc = "txtfld.gif";
                    break;
                case "?":
                    rControl = getResource("ctlUploadDoc");
                    imgSrc = "doc2.png";
                    break;
                case "B":
                    rControl = getResource("ctlCurrencyFld");
                    imgSrc = "txtfld.gif";
                    break;
                case "MC":
                    rControl = getResource("ctlMulticolumnDD");
                    imgSrc = "dd.png";
                    break;
                case "AD":
                    rControl = getResource("ctlAddress");
                    imgSrc = "address.png";
                    break;
                case "?C":
                    rControl = getResource("ctlSelectContact");
                    imgSrc = "officer.gif";
                    break;
                case "?F":
                    rControl = getResource("ctlSelectFile");
                    imgSrc = "folder16.png";
                    break;
                case "?D":
                    rControl =getResource("ctlSelectDoc");
                    imgSrc = "document2.gif";
                    break;
                case "A":
                    rControl =getResource("ctlCal");
                    imgSrc = "bflistcalendar.png";
                    break;
                case "?O":
                    rControl =getResource("ctlSelectOffice");
                    imgSrc = "officebuilding.png";
                    break;
                case "?W":
                    rControl =getResource("ctlSelectParty");
                    imgSrc = "officer.gif";
                    break;
                case "?I":
                    rControl = getResource("ctlSelectIssue");
                    imgSrc = "issue.png";
                    break;

            }

            return "<img alt=\"\" src=\"images/" + imgSrc + "\"/>" + rControl;
        }

        public List<string> GetParentRowOrDefaultValue(lmDatasets.ActivityConfig.ActivityFieldRow afr, string lang)
        {
            //always returns a list containing two items
            // first is parentrow
            // second is default value
            List<string> rList = new List<string>();

            switch (afr.TaskType)
            {
                case "N":
                    rList.Add(afr.DefaultObjectName);
                    rList.Add("");
                    break;
                case "Q":
                case "S":
                case "F":
                    rList.Add("");
                    if (!afr.IsDefaultValueNull())
                    {
                        if (afr.IsSpecialParameterNull())
                            rList.Add(LookupDefaultValue(afr, lang));
                        else
                            rList.Add(afr.SpecialParameter + " " + afr.DefaultValue);
                    }
                    else if (!afr.IsDefaultObjectNameNull())
                    {
                        if (afr.IsSpecialParameterNull())
                            rList.Add(afr.DefaultObjectName + "/" + afr.DefaultFieldName);
                        else
                            rList.Add(afr.SpecialParameter + " " + afr.DefaultObjectName + "/" + afr.DefaultFieldName);
                    }
                    if (rList.Count == 1)
                        rList.Add("");
                    break;
                case "I": //Issue
                    rList.Add("");
                    rList.Add(LookupIssue(Convert.ToInt32(afr.DefaultValue), lang));
                    break;
                case "T": //Include
                    rList.Add("");
                    rList.Add(LookupStepCode(Convert.ToInt32(afr.DefaultValue)));
                    break;
                default:
                    rList.Add("");
                    rList.Add("");
                    break;
            }
            return rList;

        }

        public string LookupStepCode(int acseriesid)
        {
            lmDatasets.ActivityConfig.ACSeriesRow[] acsr = (lmDatasets.ActivityConfig.ACSeriesRow[])myACM.DB.ACSeries.Select("AcSeriesId=" + acseriesid, "");
            if (acsr.Length == 1)
                return acsr[0].StepCode;

            return getResource("lblStepCodeNotFound");
        }

        public string LookupIssue(int issueId, string lang)
        {
            lmDatasets.appDB.IssueRow issr = myACM.AtMng.DB.Issue.FindByIssueId(issueId);
            atriumBE.FileManager ifm = myACM.AtMng.GetFile(issr.FileId);

            return issr["IssueName" + lang].ToString() + " (" + ifm.CurrentFile.FullFileNumber + ") " + ifm.CurrentFile["Name" + lang.Substring(0,1).ToUpper()].ToString();
        }

        public string LookupLookupValue(string lookupValue, string lang, string codeTable)
        {
            string rValue = "LOOKUP_NOT_FOUND";
            if (lookupValue == null)
                return "";

            System.Data.DataTable dt = myACM.AtMng.GetFile().Codes(codeTable);
            System.Data.DataRow[] dr = dt.Select(dt.Columns[0].ColumnName + "='" + lookupValue + "'", "");
            if (dr.Length > 0) //found lookup row, use it
            {
                int iLang = 1;
                if (lang.ToUpper() == "FRE")
                    iLang = 2;
                rValue = dr[0][iLang].ToString();
            }
            return rValue;
        }

        public string LookupDefaultValue(ActivityConfig.ActivityFieldRow afr, string lang)
        {
            string defValue = "";
            if (!afr.IsDefaultValueNull())
            {
                if (afr.IsLookUpNull()) // can't look it up, just return default value;
                    defValue = afr.DefaultValue;
                else
                {
                    System.Data.DataTable dt = myACM.AtMng.GetFile().Codes(afr.LookUp);
                    System.Data.DataRow[] dr = dt.Select(dt.Columns[0].ColumnName + "='" + afr.DefaultValue + "'", "");
                    if (dr.Length > 0) //found lookup row, use it
                    {
                        int iLang = 1;
                        if (lang.ToUpper() == "FRE")
                            iLang = 2;
                        defValue = dr[0][iLang].ToString();
                    }
                    else //couldn't find it, just return default value;
                        defValue = afr.DefaultValue;
                }
            }

            return defValue;

        }

        public string GetTaskTypeValue(string taskType)
        {
            string NewRecord = "<img alt=\"\" src=\"images/newrecordrelflds.gif\"/>" + getResource("lblTTNewRec");
            string GetRecord = "<img alt=\"\" src=\"images/get.png\"/>" + getResource("lblTTGet");
            string QueryRecord = "<img alt=\"\" src=\"images/query.gif\"/>" + getResource("lblTTQuery");
            string SelectRecord = "<img alt=\"\" src=\"images/selectrecords.png\"/>" + getResource("lblTTSelect");
            string LoadRecord = "<img alt=\"\" src=\"images/load.png\"/>" + getResource("lblTTLoad");
            string SpecialObject = "<img alt=\"\" src=\"images/specialobject.png\"/>" + getResource("lblTTSpecial");
            string DefaultIssue = "<img alt=\"\" src=\"images/issue.png\"/>" + getResource("lblTTIssue");
            string TemplateRelFields = "<img alt=\"\" src=\"images/selectall.png\"/>" + getResource("lblTTInc");
            string TaskText = "";

            switch (taskType)
            {
                case "N":
                    TaskText = NewRecord;
                    break;
                case "G":
                    TaskText = GetRecord;
                    break;
                case "Q":
                    TaskText = QueryRecord;
                    break;
                case "S":
                    TaskText = SelectRecord;
                    break;
                case "L":
                    TaskText = LoadRecord;
                    break;
                case "O":
                    TaskText = SpecialObject;
                    break;
                case "I":
                    TaskText = DefaultIssue;
                    break;
                case "T":
                    TaskText = TemplateRelFields;
                    break;
            }
            return TaskText;

        }


        public XmlDocument GetNextSteps(ActivityConfig.ACSeriesRow acs, string lang)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("NextSteps");
            xmlDoc.AppendChild(root);

            ActivityConfig.ACDependencyRow[] acds = (ActivityConfig.ACDependencyRow[])myACM.DB.ACDependency.Select("LinkType=0 and CurrentStepId=" + acs.ACSeriesId.ToString(), "Seq");
            foreach (ActivityConfig.ACDependencyRow acd in acds)
            {
                XmlNode nNode = AddStep(xmlDoc, acd.ACSeriesRowByPreviousSteps, "", lang);
                root.AppendChild(nNode);
            }
            return xmlDoc;

        }

        private XmlNode AddStep(XmlDocument xmldoc, ActivityConfig.ACSeriesRow acs, string connectorText, string lang)
        {
            XmlNode nNode = xmldoc.CreateElement("Step");


            XmlAttribute StepType = xmldoc.CreateAttribute("StepType");
            XmlAttribute AcSeriesId = xmldoc.CreateAttribute("AcSeriesId");
            XmlAttribute ConnectorText = xmldoc.CreateAttribute("ConnectorText");
            AcSeriesId.Value = acs.ACSeriesId.ToString();
            ConnectorText.Value = connectorText;
            nNode.Attributes.Append(StepType);
            nNode.Attributes.Append(AcSeriesId);
            nNode.Attributes.Append(ConnectorText);

            if (acs.StepType == (int)atriumBE.StepType.Activity)
            {
                StepType.Value = RecordedActivity;

                //if outgoing connector is auto, add it nested inside
                ActivityConfig.ACDependencyRow[] outAcdp = acs.GetACDependencyRowsByNextSteps();
                foreach (ActivityConfig.ACDependencyRow depRow in outAcdp)
                {
                    if (depRow.LinkType == (int)atriumBE.ConnectorType.Auto)
                    {
                        XmlNode cNode = AddStep(xmldoc, depRow.ACSeriesRowByPreviousSteps, "Auto", lang);
                        nNode.AppendChild(cNode);
                    }
                }


            }
            else if (acs.StepType == (int)atriumBE.StepType.Decision)
            {
                StepType.Value = Decision;
                ActivityConfig.ACDependencyRow[] acds = (ActivityConfig.ACDependencyRow[])myACM.DB.ACDependency.Select("LinkType=4 and CurrentStepId=" + acs.ACSeriesId.ToString(), "Seq");
                foreach (ActivityConfig.ACDependencyRow acd in acds)
                {
                    string vConnectorText = "";
                    if (!acd.IsNull("Desc" + lang))
                        vConnectorText = acd["Desc" + lang].ToString();

                    XmlNode cNode = AddStep(xmldoc, acd.ACSeriesRowByPreviousSteps, vConnectorText, lang);
                    nNode.AppendChild(cNode);
                }
            }
            else if (acs.StepType == (int)atriumBE.StepType.NonRecorded)
            {
                StepType.Value = NonRecordedActivity;
                ActivityConfig.ACDependencyRow[] acds = (ActivityConfig.ACDependencyRow[])myACM.DB.ACDependency.Select("LinkType=0 and CurrentStepId=" + acs.ACSeriesId.ToString(), "Seq");
                foreach (ActivityConfig.ACDependencyRow acd in acds)
                {
                    XmlNode cNode = AddStep(xmldoc, acd.ACSeriesRowByPreviousSteps, "", lang);
                    nNode.AppendChild(cNode);
                }
            }
            else if (acs.StepType == (int)atriumBE.StepType.Subseries)
            {
                StepType.Value = Subprocess;
                ActivityConfig.SeriesRow[] sr = (ActivityConfig.SeriesRow[])myACM.DB.Series.Select("SeriesId=" + acs.SubseriesId.ToString(), "");
                XmlAttribute SeriesId = xmldoc.CreateAttribute("SeriesId");
                SeriesId.Value = sr[0].SeriesId.ToString();
                nNode.Attributes.Append(SeriesId);

                ActivityConfig.ACSeriesRow[] acsrs = (ActivityConfig.ACSeriesRow[])myACM.DB.ACSeries.Select("SeriesId=" + sr[0].SeriesId.ToString() + " and Start=true", "");
                foreach (ActivityConfig.ACSeriesRow acsr in acsrs)
                {
                    XmlNode cNode = AddStep(xmldoc, acsr, "", lang);
                    nNode.AppendChild(cNode);
                }
            }
            return nNode;

        }

        //public ActivityConfig.ACFileTypeRow[]  StarterRestrictions(ActivityConfig.ACSeriesRow acs)
        //{
        //    return acs.GetACFileTypeRows();
        //}

        public string NextStepsHtmlOutput(XmlDocument xmldoc, string lang)
        {
            string htmlOutput = "";
            if (xmldoc.DocumentElement.ChildNodes.Count > 0)
                htmlOutput = "<ul class=\"ultop\">";

            foreach (System.Xml.XmlElement xnode in xmldoc.DocumentElement.ChildNodes)
            {
                htmlOutput += StepHtmlOutput(xnode, lang);
            }

            if (xmldoc.DocumentElement.ChildNodes.Count > 0)
                htmlOutput += "</ul>";

            return htmlOutput;
        }

        private string StepHtmlOutput(XmlNode xnode, string lang)
        {
            string htmlOutput = "";

            int acseriesid = Convert.ToInt32(xnode.Attributes["AcSeriesId"].Value);
            lmDatasets.ActivityConfig.ACSeriesRow[] acsr = (lmDatasets.ActivityConfig.ACSeriesRow[])myACM.DB.ACSeries.Select("AcSeriesId=" + acseriesid, "");

            if (xnode.Attributes["StepType"].Value == this.RecordedActivity) //draw step; we're done
            {
                string conn = "";
                string clssup = "";
                XmlNode attr = xnode.Attributes["ConnectorText"];
                if (attr != null && attr.Value != "")
                {
                    if (attr.Value == "Auto")
                    {
                        clssup = attr.Value;
                        conn = "<div class=\"auto\"><img src=\"images/automaticstep2.png\" alt=\"\"/>"+ getResource("lblAutoStep") +"</div> ";
                    }
                    else
                        conn = "<div class=\"answer\">" + xnode.Attributes["ConnectorText"].Value + ":</div> ";
                }


                htmlOutput = "<li class=\"recorded" + clssup + "\">" + conn + "<a href=\"step.aspx?acseriesid=" + acsr[0].ACSeriesId + "\">" + acsr[0].StepCode + " - " + acsr[0].ActivityCodeRow["ActivityName" + lang] + "</a></li>";
                if (xnode.ChildNodes.Count > 0)
                {
                    htmlOutput += "<ul class=\"ulin\">";
                    foreach (System.Xml.XmlElement cnode in xnode.ChildNodes)
                    {
                        htmlOutput += StepHtmlOutput(cnode, lang);
                    }
                    htmlOutput += "</ul>";
                }

            }
            else if (xnode.Attributes["StepType"].Value == this.Decision) //draw decision, continue to children;
            {
                string conn = "";
                XmlNode attr = xnode.Attributes["ConnectorText"];
                if (attr != null && xnode.Attributes["ConnectorText"].Value != "")
                    conn = "<div class=\"answer\">" + xnode.Attributes["ConnectorText"].Value + ":</div> ";

                string decClass = "decision";
                if (acsr[0].GetActivityFieldRows().Length > 0)
                    decClass = "internaldecision";

                htmlOutput = "<li class=\"" + decClass + "\">" + conn + acsr[0]["Desc" + lang] + "</li>";
                htmlOutput += "<ul class=\"ulin\">";
                foreach (System.Xml.XmlElement cnode in xnode.ChildNodes)
                {
                    htmlOutput += StepHtmlOutput(cnode, lang);
                }
                htmlOutput += "</ul>";

            }
            else if (xnode.Attributes["StepType"].Value == this.NonRecordedActivity) //draw step, continue to children;
            {
                string conn = "";
                XmlNode attr = xnode.Attributes["ConnectorText"];
                if (attr != null && xnode.Attributes["ConnectorText"].Value != "")
                    conn = "<div class=\"answer\">" + xnode.Attributes["ConnectorText"].Value + ":</div> ";

                htmlOutput = "<li class=\"nonrecorded\">" + conn + acsr[0]["Desc" + lang] + "</li>";
                htmlOutput += "<ul class=\"ulin\">";
                foreach (System.Xml.XmlElement cnode in xnode.ChildNodes)
                {
                    htmlOutput += StepHtmlOutput(cnode, lang);
                }
                htmlOutput += "</ul>";
            }
            else if (xnode.Attributes["StepType"].Value == this.Subprocess) //draw subprocess, continue to children;
            {
                lmDatasets.ActivityConfig.SeriesRow[] sr = (lmDatasets.ActivityConfig.SeriesRow[])myACM.DB.Series.Select("SeriesId=" + xnode.Attributes["SeriesId"].Value, "");

                string conn = "";
                XmlNode attr = xnode.Attributes["ConnectorText"];
                if (attr != null && xnode.Attributes["ConnectorText"].Value != "")
                    conn = "<div class=\"answer\">" + xnode.Attributes["ConnectorText"].Value + ":</div> ";

                htmlOutput = "<li class=\"subprocess\">" + conn + getResource("lblGoTo") + " <a href=\"workflow.aspx?seriesid=" + sr[0].SeriesId + "\">" + sr[0].SeriesCode + " - " + sr[0]["SeriesDesc" + lang] + "</a></li>";
                htmlOutput += "<ul class=\"ulinsub\">";
                foreach (System.Xml.XmlElement cnode in xnode.ChildNodes)
                {
                    htmlOutput += StepHtmlOutput(cnode, lang);
                }
                htmlOutput += "</ul>";

            }
            return htmlOutput;

        }

        public bool isStepFirstRecordedStep(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            bool FoundToBeStarter = false;
            if (acs.Start)
                FoundToBeStarter = true;

            SortedDictionary<string, ActivityConfig.ACSeriesRow> listOfRecordedSteps = FindLastRecordedSteps(acs);
            if (listOfRecordedSteps.Count == 0)
                FoundToBeStarter = true;

            bool foundOneInsideFlow = false;
            bool foundOneOutsideFlow = false;
            foreach (ActivityConfig.ACSeriesRow acsr in listOfRecordedSteps.Values)
            {
                if (acs.SeriesId == acsr.SeriesId)
                    foundOneInsideFlow = true;
                if (acs.SeriesId != acsr.SeriesId)
                    foundOneOutsideFlow = true;
            }
            if (foundOneInsideFlow && foundOneOutsideFlow)
                FoundToBeStarter = true;

            if (foundOneInsideFlow && !foundOneOutsideFlow)
                FoundToBeStarter = false;

            if (!foundOneInsideFlow && foundOneOutsideFlow)
                FoundToBeStarter = true;

            return FoundToBeStarter;
        }

        

        public SortedDictionary<string, ActivityConfig.ACSeriesRow> GetOutputPaths(ActivityConfig.SeriesRow sr)
        {
            //calculate if worfklow is a subprocess
            //if so, lookup possible output paths coming out of subprocess.
            SortedDictionary<string, ActivityConfig.ACSeriesRow> OutputPaths = new SortedDictionary<string, ActivityConfig.ACSeriesRow>();
            

            //get all acseries records that are subseries type for this workflow
            lmDatasets.ActivityConfig.ACSeriesRow[] ssr = (lmDatasets.ActivityConfig.ACSeriesRow[])myACM.DB.ACSeries.Select("StepType=1 and Subseriesid=" + sr.SeriesId + "", "");

            //loop through returned array
            foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in ssr)
            {
                //navigate outgoing connectors to look for nextstep type connectors
                foreach (lmDatasets.ActivityConfig.ACDependencyRow acdep in acsr.GetACDependencyRowsByNextSteps())
                {
                    if (acdep.LinkType == (int)atriumBE.ConnectorType.NextStep)
                    {
                        SortedDictionary<string, ActivityConfig.ACSeriesRow> PossibleNextSteps = StepNavigateForward(acdep.ACSeriesRowByPreviousSteps);
                        foreach (ActivityConfig.ACSeriesRow fwdStp in PossibleNextSteps.Values)
                        {
                            if (!OutputPaths.ContainsValue(fwdStp))
                                OutputPaths.Add(fwdStp.StepCode, fwdStp);
                        }
                    }
                }
            }

            return OutputPaths;
 
        }

        /// <summary>
        /// Navigate process to populate recorded steps with all recorded activities, accounting for includeObsoletePaths flag
        /// </summary>
        /// <param name="sr">Series Row</param>
        /// <param name="includeObsoletePaths">Whether to navigate Obsolete connectors when retrieving all steps</param>
        /// <returns>Sorted Dictionnary of all Recorded Steps for the sr Series</returns>
        public SortedDictionary<string, ActivityConfig.ACSeriesRow> GetAllSteps(ActivityConfig.SeriesRow sr, bool includeObsoletePaths)
        {
            SortedDictionary<string, ActivityConfig.ACSeriesRow> recordedSteps = new SortedDictionary<string, ActivityConfig.ACSeriesRow>();

            //find all starters
            ActivityConfig.ACSeriesRow[] acStarters = (ActivityConfig.ACSeriesRow[])myACM.DB.ACSeries.Select("Start=1 and SeriesId=" + sr.SeriesId.ToString(), "stepcode");

            foreach (ActivityConfig.ACSeriesRow asr in acStarters)
            {
                SortedDictionary<string, ActivityConfig.ACSeriesRow> NavigateForwardSteps = StepsNavigateForward(asr, includeObsoletePaths, false);
                foreach (ActivityConfig.ACSeriesRow fwdStp in NavigateForwardSteps.Values)
                {
                    if (!recordedSteps.ContainsValue(fwdStp))
                        recordedSteps.Add(fwdStp.StepCode, fwdStp);
                }
            }
            return recordedSteps;
        }

        //returns list possible recorded steps coming out of any ONE recorded step
        public SortedDictionary<string, ActivityConfig.ACSeriesRow> StepNavigateForward(ActivityConfig.ACSeriesRow asr)
        {
            SortedDictionary<string, ActivityConfig.ACSeriesRow> recordedSteps = new SortedDictionary<string, ActivityConfig.ACSeriesRow>();
            recordedSteps = StepsNavigateForward(asr, false, true);
            return recordedSteps;
        }


        List<ActivityConfig.ACDependencyRow> navigatedACDepRecord = new List<ActivityConfig.ACDependencyRow>();
        private SortedDictionary<string, ActivityConfig.ACSeriesRow> StepsNavigateForward(ActivityConfig.ACSeriesRow asr, bool includeObsoletePaths, bool OneLevelDeep)
        {
            SortedDictionary<string, ActivityConfig.ACSeriesRow> recordedSteps = new SortedDictionary<string, ActivityConfig.ACSeriesRow>();
            if (asr.StepType != (int)atriumBE.StepType.Activity) //don't add
            { // move fwd if ok to nav fwd
                foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in asr.GetACDependencyRowsByNextSteps())
                {
                    if (!navigatedACDepRecord.Contains(acdr))
                    {
                        navigatedACDepRecord.Add(acdr);
                        bool okToNav = false;
                        if (acdr.LinkType == (int)atriumBE.ConnectorType.NextStep || acdr.LinkType == (int)atriumBE.ConnectorType.Answer || acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                            okToNav = true;
                        if (acdr.LinkType == (int)atriumBE.ConnectorType.Obsolete && includeObsoletePaths)
                            okToNav = true;

                        if (okToNav)
                        {
                            SortedDictionary<string, ActivityConfig.ACSeriesRow> NavigateForwardSteps = StepsNavigateForward(acdr.ACSeriesRowByPreviousSteps, includeObsoletePaths, OneLevelDeep);
                            foreach (ActivityConfig.ACSeriesRow fwdStp in NavigateForwardSteps.Values)
                            {
                                if (!recordedSteps.ContainsValue(fwdStp))
                                    recordedSteps.Add(fwdStp.StepCode, fwdStp);
                            }
                        }
                    }
                    else
                    {
                        //looping workflow?
                    }
                }
            }
            else
            {
                if (!recordedSteps.ContainsValue(asr)) //let's add it 
                {
                    if (includeObsoletePaths) //if we're including obsolete, just add it straight up
                        recordedSteps.Add(asr.StepCode, asr);
                    else if (!asr.Obsolete)
                        recordedSteps.Add(asr.StepCode, asr);

                    //loop through outgoing connectors to determine if okToNav Fwd
                    if (!OneLevelDeep)
                    {
                        foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in asr.GetACDependencyRowsByNextSteps())
                        {
                            if (!navigatedACDepRecord.Contains(acdr))
                            {
                                navigatedACDepRecord.Add(acdr);
                                bool okToNav = false;
                                if (acdr.LinkType == (int)atriumBE.ConnectorType.NextStep || acdr.LinkType == (int)atriumBE.ConnectorType.Answer || acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                                    okToNav = true;
                                if (acdr.LinkType == (int)atriumBE.ConnectorType.Obsolete && includeObsoletePaths)
                                    okToNav = true;

                                if (okToNav)
                                {
                                    SortedDictionary<string, ActivityConfig.ACSeriesRow> NavigateForwardSteps = StepsNavigateForward(acdr.ACSeriesRowByPreviousSteps, includeObsoletePaths, OneLevelDeep);
                                    foreach (ActivityConfig.ACSeriesRow fwdStp in NavigateForwardSteps.Values)
                                    {
                                        if (!recordedSteps.ContainsValue(fwdStp))
                                            recordedSteps.Add(fwdStp.StepCode, fwdStp);
                                    }
                                }
                            }
                            else
                            {
                                //looping workflow?
                            }
                        }
                    }
                }
            }
            return recordedSteps;
        }



        private SortedDictionary<string, ActivityConfig.ACSeriesRow> FindLastRecordedSteps(ActivityConfig.ACSeriesRow acsr)
        {
            SortedDictionary<string, ActivityConfig.ACSeriesRow> recordedSteps = new SortedDictionary<string, ActivityConfig.ACSeriesRow>();

            //retrieve connectors leading into acseries row
            ActivityConfig.ACDependencyRow[] acds = acsr.GetACDependencyRowsByPreviousSteps();

            //loop through connectors to retrieve previous step and determine if recorded activity
            foreach (ActivityConfig.ACDependencyRow acdr in acds)
            {
                if (acdr.LinkType != (int)atriumBE.ConnectorType.NextStep) //not next step connector
                {
                    //check for obsolete connector pointing to subprocess ...
                    //we don't want to add this one
                    if (acdr.LinkType != (int)atriumBE.ConnectorType.Obsolete)
                    {
                        //check for Enable connector leading to subprocess
                        if (acdr.LinkType == (int)atriumBE.ConnectorType.Enable)
                        {
                            //check to see if steptype is not recorded activity. if it's not, validation fails. only recorded activity can enable subprocess
                            if (acdr.ACSeriesRowByNextSteps.StepType != (int)atriumBE.StepType.Activity)
                                throw new Exception(getResource("lblInvalidStepToEnable"));
                            //elseif() //check to if enabled process is obsolete
                            else
                            {
                                if (!recordedSteps.ContainsValue(acdr.ACSeriesRowByNextSteps))
                                    recordedSteps.Add(acdr.ACSeriesRowByNextSteps.StepCode, acdr.ACSeriesRowByNextSteps);
                            }
                        }

                        else if (acdr.LinkType == (int)atriumBE.ConnectorType.Transfer)
                        {
                            //check to see if steptype is not recorded activity. if it's not, validation fails. only recorded activity can enable subprocess
                            if (acdr.ACSeriesRowByNextSteps.StepType != (int)atriumBE.StepType.Activity)
                                throw new Exception(getResource("lblInvalidStepToTransfer"));
                            else
                            {
                                if (!recordedSteps.ContainsValue(acdr.ACSeriesRowByNextSteps))
                                    recordedSteps.Add(acdr.ACSeriesRowByNextSteps.StepCode, acdr.ACSeriesRowByNextSteps);
                            }
                        }
                        else if (acdr.LinkType == (int)atriumBE.ConnectorType.Auto)
                        {
                            //check to see if steptype is not recorded activity. if it's not, validation fails. only recorded activity can use outgoing auto connector
                            if (acdr.ACSeriesRowByNextSteps.StepType != (int)atriumBE.StepType.Activity)
                                throw new Exception(getResource("INVALID_STEPTYPE_USING_AUTO_CONNECTOR"));
                            else
                            {
                                if (!recordedSteps.ContainsValue(acdr.ACSeriesRowByNextSteps))
                                    recordedSteps.Add(acdr.ACSeriesRowByNextSteps.StepCode, acdr.ACSeriesRowByNextSteps);
                            }
                        }
                        else //move on up - recursive
                        {
                            SortedDictionary<string, ActivityConfig.ACSeriesRow> parentSteps = FindLastRecordedSteps(acdr.ACSeriesRowByNextSteps);
                            foreach (ActivityConfig.ACSeriesRow asr in parentSteps.Values)
                            {
                                if (!recordedSteps.ContainsValue(asr))
                                    recordedSteps.Add(asr.StepCode, asr);
                            }
                        }
                    }
                }
                else
                {
                    if (acdr.ACSeriesRowByNextSteps.StepType != (int)atriumBE.StepType.Activity)
                    {
                        SortedDictionary<string, ActivityConfig.ACSeriesRow> parentSteps = FindLastRecordedSteps(acdr.ACSeriesRowByNextSteps);
                        foreach (ActivityConfig.ACSeriesRow asr in parentSteps.Values)
                        {
                            if (!recordedSteps.ContainsValue(asr))
                                recordedSteps.Add(asr.StepCode, asr);
                        }
                    }
                    else
                    {
                        if (!recordedSteps.ContainsValue(acdr.ACSeriesRowByNextSteps))
                            recordedSteps.Add(acdr.ACSeriesRowByNextSteps.StepCode, acdr.ACSeriesRowByNextSteps);
                    }
                }


            }

            return recordedSteps;
        }

        public SortedDictionary<string, ActivityConfig.ACSeriesRow> PreviousStepToSubprocess(ActivityConfig.SeriesRow sr)
        {
            SortedDictionary<string, ActivityConfig.ACSeriesRow> acSteps = new SortedDictionary<string, ActivityConfig.ACSeriesRow>();

            //retieve subseries step types that point to series passed to method
            ActivityConfig.ACSeriesRow[] acpp = (ActivityConfig.ACSeriesRow[])myACM.DB.ACSeries.Select("SubseriesId=" + sr.SeriesId, "stepcode");

            //loop through each Subseries step
            foreach (ActivityConfig.ACSeriesRow acsr in acpp)
            {
                //retrieve list of all recorded steps that lead to Subseries step
                SortedDictionary<string, ActivityConfig.ACSeriesRow> fr = FindLastRecordedSteps(acsr);
                //loop through list to add to returned List<>
                foreach (ActivityConfig.ACSeriesRow asr in fr.Values)
                {
                    //problematic given stepcode is not unique
                    if (!acSteps.ContainsKey(asr.StepCode))
                        acSteps.Add(asr.StepCode, asr);
                }
            }
            return acSteps;
        }

        public SortedDictionary<string, ActivityConfig.ACSeriesRow> StepsLeadingTo(ActivityConfig.ACSeriesRow acsr)
        {
            SortedDictionary<string, ActivityConfig.ACSeriesRow> acSteps = FindLastRecordedSteps(acsr);
            return acSteps;
        }

        public ActivityConfig.ACDocumentationRow AcDocRow(int acDocId)
        {
            ActivityConfig.ACDocumentationRow[] aadr = (ActivityConfig.ACDocumentationRow[])myACM.DB.ACDocumentation.Select("acdocid=" + acDocId, "");
            if (aadr.Length == 1)
                return aadr[0];
            else
                return null;
        }

        public ActivityConfig.ACDocumentationRow AcDocRow(string linktable, int linkid, string kind)
        {
            ActivityConfig.ACDocumentationRow[] aadr = (ActivityConfig.ACDocumentationRow[])myACM.DB.ACDocumentation.Select("linktable='" + linktable + "' and linkid=" + linkid + " and kind='" + kind + "'", "");
            if (aadr.Length == 1)
                return aadr[0];
            else
                return null;

        }

        public string FriendlyName(string Kind)
        {
            string rName = "";

            switch (Kind.ToLower())
            {
                case "seriesobjective":
                    rName = getResource("acdocWFObjective");
                    break;
                case "stepobjective":
                    rName = getResource("acdocStepObjective");
                    break;
                case "blockobjective":
                    rName = getResource("acdocRelFldObj");
                    break;
                case "block1purpose":
                    rName = getResource("acdocBlock1Pur");
                    break;
                case "block2purpose":
                    rName = getResource("acdocBlock2Pur");
                    break;
                case "block3purpose":
                    rName = getResource("acdocBlock3Pur");
                    break;
                case "block4purpose":
                    rName = getResource("acdocBlock4Pur");
                    break;
                case "block5purpose":
                    rName = getResource("acdocBlock5Pur");
                    break;
                case "docblockpurpose":
                    rName = getResource("acdocDocBlockPur");
                    break;
                case "pickissuepurpose":
                    rName = getResource("acdocIssuePur");
                    break;
                case "block1processing":
                    rName = getResource("acdocBlock1Proc");
                    break;
                case "block2processing":
                    rName = getResource("acdocBlock2Proc");
                    break;
                case "block3processing":
                    rName = getResource("acdocBlock3Proc");
                    break;
                case "block4processing":
                    rName = getResource("acdocBlock4Proc");
                    break;
                case "block5processing":
                    rName = getResource("acdocBlock5Proc");
                    break;
                case "docprocessing":
                    rName = getResource("acdocDocBlockProc");
                    break;
                case "schedulingblockpurpose":
                    rName = getResource("acdocScheduleProc");
                    break;
                case "finishblock":
                    rName = getResource("acdocFinishNote");
                    break;

            }

            return rName;
        }
        #region IDisposable Members
        private bool isDisposed = false;
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.isDisposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    myACM.Dispose();
                    appMan.Dispose();
                    atMng.Dispose();

                    myACM = null;
                    appMan = null;
                    atMng = null;
                }

            }
            isDisposed = true;
        }

        ~WFHelp()
        {
            Dispose(false);
        }
        #endregion

    }
}