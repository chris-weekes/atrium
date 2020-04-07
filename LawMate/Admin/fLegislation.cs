using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

namespace LawMate.Admin
{
    public partial class fLegislation : LawMate.Admin.fBase
    {

        public fLegislation()
        {
            InitializeComponent();
        }

        public fLegislation(Form f)
            : base(f)
        {
            InitializeComponent();
            
            AtMng.GetLegislation().Load();
            AtMng.GetProvision().Load();

            legislationBindingSource.DataMember = AtMng.DB.Legislation.TableName;
            provisionBindingSource.DataMember = AtMng.DB.Provision.TableName;
            provisionBindingSource.DataSource = AtMng.DB;
            legislationBindingSource.DataSource = AtMng.DB;
            legislationBindingSource.CurrentChanged += new EventHandler(legislationBindingSource_CurrentChanged);
            provisionBindingSource.CurrentChanged += new EventHandler(provisionBindingSource_CurrentChanged);
            
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdCancel":
                        Cancel();
                        break;
                    case "cmdNewLegislation":
                        New();
                        break;
                    case "cmdNewProvision":
                        NewProvision();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void Cancel()
        {
            UIHelper.Cancel(legislationBindingSource);
            UIHelper.Cancel(provisionBindingSource);
            SetRTFValues(false);
            setEditMode(false);
        }

        private void Delete()
        {
            try
            {   //not called
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    legislationBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();

                    bp.AddForUpdate(AtMng.GetLegislation());
                    bp.AddForUpdate(AtMng.GetProvision());
                    bp.Update();

                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void Save()
        {
            if (AtMng.DB.Legislation.HasErrors || AtMng.DB.Provision.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.DB);
            }
            else
            {
                try
                {
                    SaveRtfValues();
                    legislationBindingSource.EndEdit();
                    provisionBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();

                    bp.AddForUpdate(AtMng.GetLegislation());
                    bp.AddForUpdate(AtMng.GetProvision());
                    bp.Update();

                    setEditMode(false);
                    SetRTFValues(false);
                }
                catch (Exception x)
                {
                 
                    throw x;
                }
            }
        }

        private void New()
        {
            appDB.LegislationRow legr = (appDB.LegislationRow)AtMng.GetLegislation().Add(null);
            legislationBindingSource.Position = legislationBindingSource.Find("LegislationId", legr.LegislationId);
        }

        private void NewProvision()
        {
            if (CurrentRow() != null)
            {
                foreach (Janus.Windows.GridEX.GridEXRow gr in legislationGridEX.GetRows())
                {
                    if ((int)gr.Cells["LegislationId"].Value == CurrentRow().LegislationId)
                    {
                        legislationGridEX.Row = gr.Position;
                        break;
                    }
                   
                }
                legislationGridEX.CurrentRow.Expanded = true;
                appDB.ProvisionRow dfr = (appDB.ProvisionRow)AtMng.GetProvision().Add(CurrentRow());
                foreach (Janus.Windows.GridEX.GridEXRow gr in legislationGridEX.CurrentRow.GetChildRecords())
                {
                    if ((int)gr.Cells["ProvisionId"].Value == dfr.ProvisionId)
                    {
                        legislationGridEX.Row = gr.Position;
                        legislationGridEX.CurrentColumn = legislationGridEX.RootTable.ChildTables[0].Columns["ProvisionNameEng"];
                    }
                }
            }
            else
                MessageBox.Show("Please select a Legislation row before choosing to create a new provision", "No Legislation Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private appDB.LegislationRow CurrentRow()
        {
            if (legislationBindingSource.Current == null)
                return null;
            else
                return (appDB.LegislationRow)((DataRowView)legislationBindingSource.Current).Row;
        }

        private appDB.ProvisionRow CurrentRowProvision()
        {
            if (provisionBindingSource.Current == null)
                return null;
            else
                return (appDB.ProvisionRow)((DataRowView)provisionBindingSource.Current).Row;
        }

        private void legislationGridEX_DeletingRecords(object sender, CancelEventArgs e)
        {
            try
            {
                if (!UIHelper.ConfirmDelete())
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void legislationBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() != null && !CurrentRow().IsNull("LegislationNameEng"))
                {
                    cmdNewProvision.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdNewProvision.Text = "New Provison for: " + CurrentRow().LegislationNameEng;
                    cmdNewProvision.Tag = CurrentRow().LegislationId;
                }
                else
                {
                    cmdNewProvision.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdNewProvision.Text = "New Provision";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void legislationGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.GridEXRow gr = legislationGridEX.CurrentRow;
                if (gr.Table.Key == AtMng.DB.Legislation.TableName)
                {
                    pnlProvisionDetail.Closed = true;
                    pnlDetail.Closed = false;
                }
                else if (gr.Table.Key == "Provision")
                {
                    pnlDetail.Closed = true;
                    pnlProvisionDetail.Closed = false;

                    if (gr.RowType == Janus.Windows.GridEX.RowType.Record)
                    {
                        provisionBindingSource.Position = provisionBindingSource.Find("ProvisionId", gr.Cells["ProvisionId"].Value);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        
        private void btnTextEBold_Click(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                switch (btn.Name)
                {
                    case "btnTextEBold":
                        UIHelper.RtbFormat(provisionTextEngRichTextBox, FontStyle.Bold);
                        break;
                    case "btnTextEItalics":
                        UIHelper.RtbFormat(provisionTextEngRichTextBox, FontStyle.Italic);
                        break;
                    case "btnTextEUnderline":
                        UIHelper.RtbFormat(provisionTextEngRichTextBox, FontStyle.Underline);
                        break;
                    case "btnTextFBold":
                        UIHelper.RtbFormat(provisionTextFreRichTextBox, FontStyle.Bold);
                        break;
                    case "btnTextFItalics":
                        UIHelper.RtbFormat(provisionTextFreRichTextBox, FontStyle.Italic);
                        break;
                    case "btnTextFUnderline":
                        UIHelper.RtbFormat(provisionTextFreRichTextBox, FontStyle.Underline);
                        break;

                    case "btnAnalysisEBold":
                        UIHelper.RtbFormat(analysisTextEngRichTextBox, FontStyle.Bold);
                        break;
                    case "btnAnalysisEItalics":
                        UIHelper.RtbFormat(analysisTextEngRichTextBox, FontStyle.Italic);
                        break;
                    case "btnAnalysisEUnderline":
                        UIHelper.RtbFormat(analysisTextEngRichTextBox, FontStyle.Underline);
                        break;
                    case "btnAnalysisFBold":
                        UIHelper.RtbFormat(analysisTextFreRichTextBox, FontStyle.Bold);
                        break;
                    case "btnAnalysisFItalics":
                        UIHelper.RtbFormat(analysisTextFreRichTextBox, FontStyle.Italic);
                        break;
                    case "btnAnalysisFUnderline":
                        UIHelper.RtbFormat(analysisTextFreRichTextBox, FontStyle.Underline);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnClearTextE_Click(object sender, EventArgs e)
        {
             try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                switch (btn.Name)
                {
                    case "btnClearTextE":
                        UIHelper.RtbClearFormat(provisionTextEngRichTextBox);
                        break;
                    case "btnClearTextF":
                        UIHelper.RtbClearFormat(provisionTextFreRichTextBox);
                        break;
                    case "btnClearAnalysisE":
                        UIHelper.RtbClearFormat(analysisTextEngRichTextBox);
                        break;
                    case "btnClearAnalysisF":
                        UIHelper.RtbClearFormat(analysisTextFreRichTextBox);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool inEditMode = false;
        bool isSettingValues = false;
        string OrigTextEng = "";
        string OrigTextFre = "";
        string OrigAnalysisEng = "";
        string OrigAnalysisFre = "";

        private void SetRTFValues(bool BlankOutField)
        {

            isSettingValues = true;
            if (!BlankOutField)
            {
                //Provision Text Eng
                if (!CurrentRowProvision().IsProvisionTextEngNull())
                {
                    OrigTextEng = CurrentRowProvision().ProvisionTextEng;
                    try
                    { provisionTextEngRichTextBox.Rtf = CurrentRowProvision().ProvisionTextEng; }
                    catch (Exception x)
                    {
                        provisionTextEngRichTextBox.Text = CurrentRowProvision().ProvisionTextEng;
                    }
                }
                else
                {
                    provisionTextEngRichTextBox.Rtf = String.Empty;
                    provisionTextEngRichTextBox.Text = "";
                    OrigTextEng = "";
                }

                //Provision Text Fre
                if (!CurrentRowProvision().IsProvisionTextFreNull())
                {
                    OrigTextFre = CurrentRowProvision().ProvisionTextFre;
                    try
                    { provisionTextFreRichTextBox.Rtf = CurrentRowProvision().ProvisionTextFre; }
                    catch (Exception x)
                    {
                        provisionTextFreRichTextBox.Text = CurrentRowProvision().ProvisionTextFre;
                    }
                }
                else
                {
                    provisionTextFreRichTextBox.Rtf = String.Empty;
                    provisionTextFreRichTextBox.Text = "";
                    OrigTextFre = "";
                }

                //Analysis Text Eng
                if (!CurrentRowProvision().IsAnalysisTextEngNull())
                {
                    OrigAnalysisEng = CurrentRowProvision().AnalysisTextEng;
                    try
                    { analysisTextEngRichTextBox.Rtf = CurrentRowProvision().AnalysisTextEng; }
                    catch (Exception x)
                    {
                        analysisTextEngRichTextBox.Text = CurrentRowProvision().AnalysisTextEng;
                    }
                }
                else
                {
                    analysisTextEngRichTextBox.Rtf = String.Empty;
                    analysisTextEngRichTextBox.Text = "";
                    OrigAnalysisEng = "";
                }

                //Analysis Text Fre
                if (!CurrentRowProvision().IsAnalysisTextFreNull())
                {
                    OrigAnalysisFre = CurrentRowProvision().AnalysisTextFre;
                    try
                    { analysisTextFreRichTextBox.Rtf = CurrentRowProvision().AnalysisTextFre; }
                    catch (Exception x)
                    {
                        analysisTextFreRichTextBox.Text = CurrentRowProvision().AnalysisTextFre;
                    }
                }
                else
                {
                    analysisTextFreRichTextBox.Rtf = String.Empty;
                    analysisTextFreRichTextBox.Text = "";
                    OrigAnalysisFre = "";
                }
            }
            else
            {
                provisionTextEngRichTextBox.Rtf = String.Empty;
                provisionTextEngRichTextBox.Text = "";
                OrigTextEng = "";
                provisionTextFreRichTextBox.Rtf = String.Empty;
                provisionTextFreRichTextBox.Text = "";
                OrigTextFre = "";
                analysisTextEngRichTextBox.Rtf = String.Empty;
                analysisTextEngRichTextBox.Text = "";
                OrigAnalysisEng = "";
                analysisTextFreRichTextBox.Rtf = String.Empty;
                analysisTextFreRichTextBox.Text = "";
                OrigAnalysisFre = "";
            }
            isSettingValues = false;
        }

        private void SaveRtfValues()
        {
            if (OrigTextEng != provisionTextEngRichTextBox.Rtf)
                CurrentRowProvision().ProvisionTextEng = provisionTextEngRichTextBox.Rtf;
            if (OrigTextFre != provisionTextFreRichTextBox.Rtf)
                CurrentRowProvision().ProvisionTextFre = provisionTextFreRichTextBox.Rtf;
            if (OrigAnalysisEng != analysisTextEngRichTextBox.Rtf)
                CurrentRowProvision().AnalysisTextEng = analysisTextEngRichTextBox.Rtf;
            if (OrigAnalysisFre != analysisTextFreRichTextBox.Rtf)
                CurrentRowProvision().AnalysisTextFre = analysisTextFreRichTextBox.Rtf;
        }

        private void provisionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                SetRTFValues(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void setEditMode(bool EnableEditMode)
        {
            inEditMode = EnableEditMode;
            lblRtfEdited.Visible = EnableEditMode;
            legislationGridEX.Enabled = !EnableEditMode;
            if (EnableEditMode)
            {
                legislationGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
                cmdNew.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                cmdNew.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                legislationGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            }

        }

        private void provisionTextEngRichTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isSettingValues)
                {
                    if (analysisTextEngRichTextBox.Rtf != OrigAnalysisEng | analysisTextFreRichTextBox.Rtf != OrigAnalysisFre | provisionTextEngRichTextBox.Rtf != OrigTextEng | provisionTextFreRichTextBox.Rtf != OrigTextFre)
                    {
                        setEditMode(true);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void provisionTextEngRichTextBox_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!isSettingValues)
            //    {
            //        if ((analysisTextEngRichTextBox.Rtf != OrigAnalysisEng && OrigAnalysisEng != "" && analysisTextEngRichTextBox.Text != "") | (analysisTextFreRichTextBox.Rtf != OrigAnalysisFre && OrigAnalysisFre != "" && analysisTextFreRichTextBox.Text != "") | (provisionTextEngRichTextBox.Rtf != OrigTextEng && OrigTextEng != "" && provisionTextEngRichTextBox.Text != "") | (provisionTextFreRichTextBox.Rtf != OrigTextFre && OrigTextFre != "" && provisionTextFreRichTextBox.Text != ""))
            //        {
            //            inEditMode = true;
            //            lblRtfEdited.Visible = true;
            //            legislationGridEX.Enabled = false;
            //        }
            //    }

            //}
            //catch (Exception x)
            //{
            //    UIHelper.HandleUIException(x);
            //}
        }

        private void InEditModeMessage()
        {
                MessageBox.Show("You have edited the RTF Contents. Please save your changes before navigating off the selected provision.");
        }

        private void legislationGridEX_Click(object sender, EventArgs e)
        {
            try
            {
                if (inEditMode)
                    InEditModeMessage();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
