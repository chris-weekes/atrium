using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace LawMate.Admin
{
    public partial class fDataDictionnary : LawMate.Admin.fBase
    {
        DataTable dtReferencedInSteps;

        public fDataDictionnary()
        {
            InitializeComponent();
        }

        public fDataDictionnary(Form f)
            : base(f)
        {
            InitializeComponent();
            //App FMain Loads All data, don't need to load again,.
            //AtMng.GetddTable().Load();
            //AtMng.GetddField().Load();
            ddTableBindingSource.DataSource = AtMng.DB.ddTable;
            ddFieldBindingSource.DataSource = AtMng.DB.ddField;

            DataView dv1 = new DataView(AtMng.acMng.DB.ACDocumentation);
            aCDocumentationBindingSource.DataSource = dv1;
            aCDocumentationBindingSource.Filter = "ACDocid=0";

            DataView dv2 = new DataView(AtMng.acMng.DB.ACDocumentation);
            ddFieldRuleMSg.DataSource = dv2;
            ddFieldRuleMSg.Filter = "ACDocid=0";
           
            atriumBE.FileManager fm = AtMng.GetFile();

            DataTable dtDatasetName;
            dtDatasetName = new DataTable("DatasetList");
            dtDatasetName.Columns.Add("dsName", typeof(string));
            dtDatasetName.Columns.Add("dsFullName", typeof(string));
            dtDatasetName.Rows.Add("ActivityConfig", "ActivityConfig Dataset");
            dtDatasetName.Rows.Add("appDB", "AppDB Dataset");
            dtDatasetName.Rows.Add("CodesDB", "CodesDB Dataset");
            dtDatasetName.Rows.Add("atriumDB", "AtriumDB Dataset");
            dtDatasetName.Rows.Add("docDB", "DocDB Dataset");
            dtDatasetName.Rows.Add("officeDB", "OfficeDB Dataset");
            dtDatasetName.Rows.Add("SecurityDB", "SecurityDB Dataset");
            dtDatasetName.Rows.Add("HelpDB", "HelpDB Dataset");
            dtDatasetName.Rows.Add("SST", "SST Dataset");
            dtDatasetName.Rows.Add("CLAS", "CLAS Dataset");
            dtDatasetName.Rows.Add("Advisory", "Advisory Dataset");

            DataTable dtEvents = AtMng.GetddRule().dtEvents;

            DataTable dtRuleTypes = AtMng.GetddRule().dtRuleTypes;

            UIHelper.ComboBoxInit(new DataView(dtEvents, "Id not in (1,7,10)", "", DataViewRowState.CurrentRows), ucTableEvent, fm);
            UIHelper.ComboBoxInit(new DataView(dtEvents, "Id in (1,7,10)", "", DataViewRowState.CurrentRows), eventIducMultiDropDown, fm);
            //UIHelper.ComboBoxInit(dtEvents, ucTableEvent, fm);

            UIHelper.ComboBoxInit(new DataView(dtRuleTypes, "id in (0,2,99)", "", DataViewRowState.CurrentRows), ucTableRuleType, fm);
            UIHelper.ComboBoxInit(new DataView(dtRuleTypes), ruleTypeIducMultiDropDown, fm);
            //UIHelper.ComboBoxInit(dtRuleTypes, ucTableEvent, fm);

            UIHelper.ComboBoxInit(dtDatasetName, ddTableGridEX.DropDowns["ddDataset"], fm);
            UIHelper.ComboBoxInit("ACControlType", ddFieldGridEX.DropDowns["ddACControlType"], fm);
            UIHelper.ComboBoxInit(dtDatasetName, mccDataset, fm);
            UIHelper.ComboBoxInit("ACControlType", mccACControlType, fm);

            DataView dvACSeries = new DataView(AtMng.acMng.DB.ACSeries, "(steptype=11) and obsolete=0", "stepcode", DataViewRowState.CurrentRows);
            suffixComboBox.SetDataBinding(dvACSeries, "");

            DataView dvACSeriesRules = new DataView(AtMng.acMng.DB.ACSeries, "(steptype in(10,12)) and obsolete=0", "stepcode", DataViewRowState.CurrentRows);
            ucTableRuleACS.SetDataBinding(dvACSeriesRules, "");
            ucFieldRuleACS.SetDataBinding(dvACSeriesRules, "");

            atSecurity.SecurityManager mySecMan = AtMng.SecurityManager;
            mySecMan.GetsecFeature().Load();
            UIHelper.ComboBoxInit(new System.Data.DataView(mySecMan.DB.secFeature, "", "FeatureName", DataViewRowState.CurrentRows), mccFeature, fm);
            UIHelper.ComboBoxInit(new System.Data.DataView(mySecMan.DB.secFeature, "", "FeatureName", DataViewRowState.CurrentRows), ucFieldFeatureId, fm);

            UIHelper.ComboBoxInit(AtMng.DB.ddLookup, mccLookup, fm);

            dtReferencedInSteps = new DataTable("dtReferencedInSteps");
            dtReferencedInSteps.Columns.Add("FieldId", typeof(int));
            dtReferencedInSteps.Columns.Add("StepCode", typeof(string));
            dtReferencedInSteps.Columns.Add("TaskType", typeof(string));
            dtReferencedInSteps.Columns.Add("ObjectAlias", typeof(string));
            dtReferencedInSteps.Columns.Add("Block", typeof(string));
            dtReferencedInSteps.Columns.Add("ActivityFieldID", typeof(int));
            dtReferencedInSteps.Columns.Add("ActivityNameEng", typeof(string));
            dtReferencedInSteps.Columns.Add("SeriesCode", typeof(string));
            dtReferencedInSteps.Columns.Add("SeriesDescEng", typeof(string));
            dtReferencedInSteps.Columns.Add("ACSeriesId", typeof(int));
            dtReferencedInSteps.Columns.Add("SeriesId", typeof(int));
            dtReferencedInSteps.Columns.Add("DefaultValue", typeof(string));
            UIHelper.SetDataTableAsGridDataSource(gridEX1, dtReferencedInSteps);
            bindingSourceFieldReference.DataSource = dtReferencedInSteps;
            gridEX1.DataSource = bindingSourceFieldReference;

        }


        private void Populate()
        {
            ddTableGridEX.UpdateData();
            ddTableBindingSource.EndEdit();

            AtMng.GetddField().Populate(CurrentRowTable());

            //ddTableGridEX.CurrentRow.Expanded = true;
            ddTableGridEX.EnsureVisible();

        }
        private void RefreshReferences()
        {
            loadedReferences.Clear();
            dtReferencedInSteps.Clear();
            dtReferencedInSteps.AcceptChanges();
            CalculateRelatedFieldReferences(CurrentRowTable());
            ddFieldGridEX.Refresh();
        }


        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdCreateView":
                        string sql = AtMng.GetddTable().CreateSQLView(CurrentRowTable());
                        Clipboard.SetText(sql);
                        MessageBox.Show("SQL statement placed on clipboard");
                        break;
                    case "cmdRefreshReferences":
                        RefreshReferences();
                        break;
                    case "cmdPopulate":
                        Populate();
                        break;
                    case "cmdCancel":
                        Cancel();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdExportToXML":
                        ExportToXml();
                        break;
                    case "cmdNewTable":
                        lmDatasets.appDB.ddTableRow dtr = (lmDatasets.appDB.ddTableRow)AtMng.GetddTable().Add(null);
                        ddTableGridEX.Find(ddTableGridEX.RootTable.Columns["TableName"], Janus.Windows.GridEX.ConditionOperator.Equal, "New Table", 0, 1);
                        ddTableGridEX.CurrentColumn = ddTableGridEX.RootTable.Columns["TableName"];
                        ddTableGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                        break;
                    case "cmdNewField":
                        if (CurrentRowTable() != null)
                        {
                            lmDatasets.appDB.ddFieldRow dfr = (lmDatasets.appDB.ddFieldRow)AtMng.GetddField().Add(CurrentRowTable());
                            ddFieldGridEX.Find(ddFieldGridEX.RootTable.Columns["FieldId"], Janus.Windows.GridEX.ConditionOperator.Equal, dfr.FieldId, 0, 1);
                            //ddFieldGridEX.CurrentColumn = ddFieldGridEX.RootTable.Columns["FieldName"];
                            //ddFieldGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                        }
                        else
                            MessageBox.Show("Please select a Table row before choosing to create a new field", "No Table Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void Save()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be saved.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (ddTableGridEX.CurrentRow != null)
                        ddTableGridEX.CurrentRow.EndEdit();
                    ddTableGridEX.UpdateData();
                    ddTableBindingSource.EndEdit();

                    if (ddFieldGridEX.CurrentRow != null)
                        ddFieldGridEX.CurrentRow.EndEdit();
                    ddFieldGridEX.UpdateData();
                    ddFieldBindingSource.EndEdit();

                    ddRuleBindingSource.EndEdit();
                    ddTableRuleBS.EndEdit();

                    aCDocumentationBindingSource.EndEdit();
                    ddFieldRuleMSg.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();

                    bp.AddForUpdate(AtMng.GetddTable());
                    bp.AddForUpdate(AtMng.GetddField());
                    bp.AddForUpdate(AtMng.GetddRule());
                    bp.AddForUpdate(AtMng.acMng.GetACDocumentation());
                    bp.Update();
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }
        private void Cancel()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    UIHelper.Cancel(ddTableBindingSource);
                    UIHelper.Cancel(ddFieldBindingSource);
                    UIHelper.Cancel(ddRuleBindingSource);
                 
                    UIHelper.Cancel(ddTableRuleBS);

                    UIHelper.Cancel(aCDocumentationBindingSource);
                    UIHelper.Cancel(ddFieldRuleMSg);

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ExportToXml()
        {
            try
            {
                string fld = AtMng.AppMan.LawMatePath;
                fld += @"Admin\";

                if (!System.IO.Directory.Exists(fld))
                    System.IO.Directory.CreateDirectory(fld);

                string filename = fld + "DDExport.xml";

                StreamWriter writer = new StreamWriter(filename);
                writer.Close();

                XmlDocument xmlDoc = new XmlDocument();

                XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.GetEncoding(28591));
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='ISO-8859-1'");
                xmlWriter.WriteStartElement("DataDictionnary");
                xmlWriter.Close();
                xmlDoc.Load(filename);

                // loop through DDTable and DDFields to add nodes

                XmlNode root = xmlDoc.DocumentElement;

                foreach (lmDatasets.appDB.ddTableRow tr in AtMng.DB.ddTable.Rows)
                {
                    XmlElement tNode = xmlDoc.CreateElement("Table");
                    tNode.SetAttribute("TableId", tr.TableId.ToString());
                    tNode.SetAttribute("TableName", tr.TableName);
                    tNode.SetAttribute("isDBTable", tr.isDBTable.ToString());
                    tNode.SetAttribute("isLookup", tr.isLookup.ToString());

                    if (!tr.IsDescriptionEngNull())
                        tNode.SetAttribute("DescriptionEng", tr.DescriptionEng);
                    else
                        tNode.SetAttribute("DescriptionEng", "");

                    if (!tr.IsDescriptionFreNull())
                        tNode.SetAttribute("DescriptionFre", tr.DescriptionFre);
                    else
                        tNode.SetAttribute("DescriptionFre", "");

                    if (!tr.IsLookupNameNull())
                        tNode.SetAttribute("LookupName", tr.LookupName);
                    else
                        tNode.SetAttribute("LookupName", "");

                    if (!tr.IstblGroupNull())
                        tNode.SetAttribute("tblGroup", tr.tblGroup);
                    else
                        tNode.SetAttribute("tblGroup", "");

                    if (!tr.IstblTypeNull())
                        tNode.SetAttribute("tblType", tr.tblType);
                    else
                        tNode.SetAttribute("tblType", "");

                    root.AppendChild(tNode);

                    foreach (lmDatasets.appDB.ddFieldRow fr in AtMng.DB.ddField.Select("tableid=" + tr.TableId, "fieldname"))
                    {
                        XmlElement fNode = xmlDoc.CreateElement("Field");
                        fNode.SetAttribute("FieldId", fr.FieldId.ToString());
                        fNode.SetAttribute("FieldName", fr.FieldName);

                        if (!fr.IsLeftEngNull())
                            fNode.SetAttribute("uiLabelEng", fr.LeftEng);
                        else
                            fNode.SetAttribute("uiLabelEng", "");

                        if (!fr.IsLeftFreNull())
                            fNode.SetAttribute("uiLabelFre", fr.LeftFre);
                        else
                            fNode.SetAttribute("uiLabelFre", "");

                        if (!fr.IsLookupNull())
                            fNode.SetAttribute("LookupName", fr.Lookup);
                        else
                            fNode.SetAttribute("LookupName", "");

                        if (!fr.IsDataTypeNull())
                            fNode.SetAttribute("DataType", fr.DataType);
                        else
                            fNode.SetAttribute("DataType", "");

                        if (!fr.IsFieldTypeNull())
                            fNode.SetAttribute("FieldType", fr.FieldType);
                        else
                            fNode.SetAttribute("FieldType", "");

                        fNode.SetAttribute("AllowInRelInfo", fr.AllowInRelatedFields.ToString());

                        if (!fr.IsDefaultSystemValueNull())
                            fNode.SetAttribute("DefaultSystemValue", fr.DefaultSystemValue);
                        else
                            fNode.SetAttribute("DefaultSystemValue", "");

                        if (!fr.IsHelpEngNull())
                            fNode.SetAttribute("HelpEng", fr.HelpEng);
                        else
                            fNode.SetAttribute("HelpEng", "");

                        if (!fr.IsHelpFreNull())
                            fNode.SetAttribute("HelpFre", fr.HelpFre);
                        else
                            fNode.SetAttribute("HelpFre", "");

                        tNode.AppendChild(fNode);
                    }
                }

                xmlDoc.Save(filename);
                if (MessageBox.Show("Would you like to launch Windows Explorer to view the exported XML file?", "XML File Exported", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    System.Diagnostics.Process.Start("explorer.exe", "/e," + fld);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public lmDatasets.appDB.ddTableRow CurrentRowTable()
        {
            if (ddTableBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ddTableRow)((DataRowView)ddTableBindingSource.Current).Row;
        }

        public lmDatasets.appDB.ddRuleRow CurrentRowTableRule()
        {
            if (ddTableRuleBS.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ddRuleRow)((DataRowView)ddTableRuleBS.Current).Row;
        }
        public lmDatasets.appDB.ddRuleRow CurrentRowFieldRule()
        {
            if (ddRuleBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ddRuleRow)((DataRowView)ddRuleBindingSource.Current).Row;
        }
        public lmDatasets.appDB.ddFieldRow CurrentRowField()
        {
            if (ddFieldBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ddFieldRow)((DataRowView)ddFieldBindingSource.Current).Row;
        }

        private void ddTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRowTable() != null)
                {
                    pnlFields.Text = CurrentRowTable().TableName + " Fields";
                    cmdNewField.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdNewField.Text = "New " + CurrentRowTable().TableName + " Field";
                    cmdNewField.Tag = CurrentRowTable().TableId;
                    ddFieldBindingSource.Filter = "TableId = " + CurrentRowTable().TableId;
                    CalculateRelatedFieldReferences(CurrentRowTable());

                    uiTabPage5.Text = "Rules and Actions (" + CurrentRowTable().GetddRuleRows().Length.ToString() + ")";

                }
                else
                {
                    cmdNewField.Text = "New Field";
                    cmdNewField.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        Dictionary<int, lmDatasets.appDB.ddTableRow> loadedReferences = new Dictionary<int, lmDatasets.appDB.ddTableRow>();
        private void CalculateRelatedFieldReferences(lmDatasets.appDB.ddTableRow ddtable)
        {
            if (!loadedReferences.ContainsKey(ddtable.TableId))
            {
                lmDatasets.appDB.ddFieldRow[] flds = (lmDatasets.appDB.ddFieldRow[])AtMng.DB.ddField.Select("TableId=" + ddtable.TableId);
                foreach (lmDatasets.appDB.ddFieldRow ddfield in flds)
                {
                    lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])AtMng.acMng.DB.ActivityField.Select("ObjectName='" + ddtable.TableName + "' and FieldName='" + ddfield.FieldName + "'");
                    foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
                    {
                        lmDatasets.ActivityConfig.ACSeriesRow acr = AtMng.acMng.DB.ACSeries.FindByACSeriesId(afr.ACSeriesId);
                        string df = "";
                        if (!afr.IsDefaultValueNull())
                            df = afr.DefaultValue;
                        dtReferencedInSteps.Rows.Add(ddfield.FieldId, acr.StepCode, afr.TaskType, afr.ObjectAlias, afr.Step, afr.ActivityFieldID, acr.ActivityNameEng, acr.SeriesRow.SeriesCode, acr.SeriesRow.SeriesDescEng, acr.ACSeriesId, acr.SeriesId, df);
                    }
                }
                loadedReferences.Add(ddtable.TableId, ddtable);
            }
        }

        private void fDataDictionnary_Load(object sender, EventArgs e)
        {

            try
            {
                ddTableGridEX.Row = 0;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ddFieldBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRowField() != null && !CurrentRowField().IsNull("FieldId"))
                {


                    uiTab1.Enabled = true;
                    bindingSourceFieldReference.Filter = "FieldId=" + CurrentRowField().FieldId.ToString();
                    int fldCount = bindingSourceFieldReference.Count;
                    gridEX1.DataSource = bindingSourceFieldReference;
                    uiTabPage3.Text = "Field References (" + fldCount + ")";
                    uiTabPage2.Text = "Rules and Actions (" + CurrentRowField().GetddRuleRows().Length.ToString() + ")";
                }
                else
                {
                    uiTab1.Enabled = false;
                    gridEX1.DataSource = null;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridEX1_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "StepCode")
                {
                    if (gridEX1.CurrentRow != null)
                    {
                        int acseriesid = (int)gridEX1.CurrentRow.Cells["ACSeriesId"].Value;
                        int seriesid = (int)gridEX1.CurrentRow.Cells["SeriesId"].Value;
                        int afrid = (int)gridEX1.CurrentRow.Cells["ActivityFieldID"].Value;

                        MainAdminForm.MoreInfoRelField(seriesid, acseriesid, afrid);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ddFieldGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.Cells["FieldId"].Value != null)
                {
                    int fieldid = (int)e.Row.Cells["FieldId"].Value;
                    DataRow[] arrRelFields = dtReferencedInSteps.Select("FieldId=" + fieldid);
                    if (arrRelFields.Length > 0)
                        e.Row.Cells["ReferenceCount"].Text = arrRelFields.Length.ToString();
                    else
                        e.Row.Cells["ReferenceCount"].Text = "";
                }
            }
            catch (Exception x)
            {
                //  UIHelper.HandleUIException(x);
            }
        }

        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {

        }

        private void uiTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void uiTab2_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {

        }

        private void descriptionEngEditBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void editBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mccFeature_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mccDataset_Load(object sender, EventArgs e)
        {

        }

        private void allowInRelatedFieldsUICheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tblGroupEditBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void isLookupUICheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lookupNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void lookupNameEditBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tblTypeLabel_Click(object sender, EventArgs e)
        {

        }

        private void isDBTableUICheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void descriptionFreLabel_Click(object sender, EventArgs e)
        {

        }

        private void descriptionFreEditBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void descriptionEngLabel_Click(object sender, EventArgs e)
        {

        }

        private void suffixComboBox_Load(object sender, EventArgs e)
        {

        }

        private void tblGroupLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add new ddRule for field
            AtMng.GetddRule().Add(CurrentRowField());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add new ddRule for table
            AtMng.GetddRule().Add(CurrentRowTable());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurrentRowTableRule() != null)
            {
                if (CurrentRowTableRule().IsMsgIdNull())
                {
                    lmDatasets.ActivityConfig.ACDocumentationRow acdr = (lmDatasets.ActivityConfig.ACDocumentationRow)AtMng.acMng.GetACDocumentation().Add(null);
                    acdr.Kind = "message";
                    acdr.LinkId = CurrentRowTableRule().RuleId;
                    acdr.LinkTable = "ddRule";
                    acdr.TextEng = "enter message";
                    acdr.TextFre = "en francais";
                    acdr.EndEdit();

                    CurrentRowTableRule().MsgId = acdr.ACDocId;
                    aCDocumentationBindingSource.Filter = "ACDocID=" + acdr.ACDocId.ToString();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CurrentRowFieldRule() != null)
            {
                if (CurrentRowFieldRule().IsMsgIdNull())
                {
                    lmDatasets.ActivityConfig.ACDocumentationRow acdr = (lmDatasets.ActivityConfig.ACDocumentationRow)AtMng.acMng.GetACDocumentation().Add(null);
                    acdr.Kind = "message";
                    acdr.LinkId = CurrentRowFieldRule().RuleId;
                    acdr.LinkTable = "ddRule";
                    acdr.TextEng = "enter message";
                    acdr.TextFre = "en francais";
                    acdr.EndEdit();
                    CurrentRowFieldRule().MsgId = acdr.ACDocId;
                    ddFieldRuleMSg.Filter = "ACDocID=" + acdr.ACDocId.ToString();
                }
            }
        }

        private void ddTableRuleBS_CurrentChanged(object sender, EventArgs e)
        {
            aCDocumentationBindingSource.Filter = "ACDocid=0";

            if(CurrentRowTableRule()!=null && !CurrentRowTableRule().IsMsgIdNull())
            {
                aCDocumentationBindingSource.Filter = "ACDocID=" + CurrentRowTableRule().MsgId.ToString();
            }
        }

        private void ddFieldRuleMSg_CurrentChanged(object sender, EventArgs e)
        {
            ddFieldRuleMSg.Filter = "ACDocid=0";

            if (CurrentRowFieldRule()!=null && !CurrentRowFieldRule().IsMsgIdNull())
            {
                ddFieldRuleMSg.Filter = "ACDocID=" + CurrentRowFieldRule().MsgId.ToString();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentRowTableRule() != null && !CurrentRowTableRule().IsACSeriesIdNull())
            {
                //table rule
                lmDatasets.ActivityConfig.ACSeriesRow acsr = AtMng.acMng.DB.ACSeries.FindByACSeriesId(CurrentRowTableRule().ACSeriesId);

                if(acsr.GetActivityFieldRows().Length>0)
                    MainAdminForm.MoreInfoRelField(acsr.SeriesId, acsr.ACSeriesId,acsr.GetActivityFieldRows()[0].ActivityFieldID);
                else
                    MainAdminForm.MoreInfoACSeries(acsr.SeriesId, acsr.ACSeriesId);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //field rule
            if (CurrentRowFieldRule() != null && !CurrentRowFieldRule().IsACSeriesIdNull())
            {
                //table rule
                lmDatasets.ActivityConfig.ACSeriesRow acsr = AtMng.acMng.DB.ACSeries.FindByACSeriesId(CurrentRowFieldRule().ACSeriesId);

                if (acsr.GetActivityFieldRows().Length > 0)
                    MainAdminForm.MoreInfoRelField(acsr.SeriesId, acsr.ACSeriesId, acsr.GetActivityFieldRows()[0].ActivityFieldID);
                else
                    MainAdminForm.MoreInfoACSeries(acsr.SeriesId, acsr.ACSeriesId);
            }
        }

        private void lblDefaultForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentRowTable() != null && !CurrentRowTable().IsDefaultFormIDNull())
            {
                //table rule
                lmDatasets.ActivityConfig.ACSeriesRow acsr = AtMng.acMng.DB.ACSeries.FindByACSeriesId(CurrentRowTable().DefaultFormID);

                if (acsr.GetActivityFieldRows().Length > 0)
                    MainAdminForm.MoreInfoRelField(acsr.SeriesId, acsr.ACSeriesId, acsr.GetActivityFieldRows()[0].ActivityFieldID);
                else
                    MainAdminForm.MoreInfoACSeries(acsr.SeriesId, acsr.ACSeriesId);
            }
        }
    }
}
