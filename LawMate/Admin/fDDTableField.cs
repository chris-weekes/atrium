using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;


 namespace LawMate.Admin
{
    public partial class fDDTableField : fBase
    {
        public fDDTableField()
        {
            InitializeComponent();
        }

        public fDDTableField(Form f)
            : base(f)
        {
            InitializeComponent();
            AtMng.GetddTable().Load();
            AtMng.GetddField().Load();
            ddTableBindingSource1.DataSource = AtMng.DB;

            atriumBE.FileManager fm = AtMng.GetFile();

            DataTable dtDatasetName;
            dtDatasetName = new DataTable("DatasetList");
            dtDatasetName.Columns.Add("dsName", typeof(string));
            dtDatasetName.Rows.Add(AtMng.DB.DataSetName);
            dtDatasetName.Rows.Add(fm.DB.DataSetName);
            dtDatasetName.Rows.Add(fm.GetDocMng().DB.DataSetName);
            dtDatasetName.Rows.Add(fm.GetAdvisoryMng().DB.DataSetName);
            dtDatasetName.Rows.Add(fm.GetSSTMng().DB.DataSetName);
            dtDatasetName.Rows.Add(fm.GetCLASMng().DB.DataSetName);
            dtDatasetName.Rows.Add(AtMng.acMng.DB.DataSetName);
            dtDatasetName.Rows.Add(AtMng.CodeDB.DataSetName);
            dtDatasetName.Rows.Add(AtMng.SecurityManager.DB.DataSetName);
            dtDatasetName.Rows.Add(AtMng.HelpMng.DB.DataSetName);
            dtDatasetName.Rows.Add(AtMng.GetOffice().DB.DataSetName);

            UIHelper.ComboBoxInit(dtDatasetName, ddTableGridEX.DropDowns["ddDatasetName"], fm);
        }
        private void fDDTableField_Load(object sender, EventArgs e)
        {
           // ddTableGridEX.ExpandRecords();
            ddTableGridEX.Row = 0;
        }

        private void Populate()
        {
            ddTableGridEX.UpdateData();
            ddTableBindingSource1.EndEdit();

            AtMng.GetddField().Populate(CurrentRowTable());

            ddTableGridEX.CurrentRow.Expanded = true;
            ddTableGridEX.EnsureVisible();

        }
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
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
                    case "cmdNew":
                        cmdNew1.Expand();
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
                            foreach (Janus.Windows.GridEX.GridEXRow gr in ddTableGridEX.GetRows())
                            {
                                if ((int)gr.Cells["TableId"].Value == CurrentRowTable().TableId)
                                    ddTableGridEX.Row = gr.Position;
                            }
                            ddTableGridEX.CurrentRow.Expanded = true;
                            lmDatasets.appDB.ddFieldRow dfr = (lmDatasets.appDB.ddFieldRow)AtMng.GetddField().Add(CurrentRowTable());
                            foreach (Janus.Windows.GridEX.GridEXRow gr in ddTableGridEX.CurrentRow.GetChildRecords())
                            {
                                if ((int)gr.Cells["FieldId"].Value == dfr.FieldId)
                                {
                                    ddTableGridEX.Row = gr.Position;
                                    ddTableGridEX.CurrentColumn = ddTableGridEX.RootTable.ChildTables[0].Columns["FieldName"];
                                    ddTableGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                                }
                            }
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
                    ddTableGridEX.CurrentRow.EndEdit();
                    ddTableGridEX.UpdateData();
                    ddTableBindingSource1.EndEdit();

                    atLogic.BusinessProcess bp=AtMng.GetBP();

                    bp.AddForUpdate(AtMng.GetddTable());
                    bp.AddForUpdate(AtMng.GetddField());
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
                    UIHelper.Cancel(ddTableBindingSource1);
                    UIHelper.Cancel(AtMng.DB);
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
                    
                    if(!tr.IsDescriptionEngNull())
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

                    foreach (lmDatasets.appDB.ddFieldRow fr in AtMng.DB.ddField.Select("tableid="+tr.TableId,"fieldname"))
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
                if(MessageBox.Show("Would you like to launch Windows Explorer to view the exported XML file?","XML File Exported", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    System.Diagnostics.Process.Start("explorer.exe", "/e,"+fld);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public lmDatasets.appDB.ddTableRow CurrentRowTable()
        {
            if (ddTableBindingSource1.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ddTableRow)((DataRowView)ddTableBindingSource1.Current).Row;
        }

        private void ddTableBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRowTable() != null)
                {
                    cmdNewField.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdNewField.Text = "New Field in following Table: " + CurrentRowTable().TableName;
                    cmdNewField.Tag = CurrentRowTable().TableId;
                }
                else
                    cmdNewField.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ddTableGridEX_FilterApplied(object sender, EventArgs e)
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
    }
}

