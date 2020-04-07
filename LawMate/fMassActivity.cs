using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;
namespace LawMate
{
    public partial class fMassActivity : LawMate.fBase
    {

        atriumBE.FileManager fmCurrent;
        Dictionary<string, object> ctx;

        public fMassActivity()
        {
            InitializeComponent();
        }




        public fMassActivity(Form f, Object bs)
            : base(f)
        {
            InitializeComponent();

            appDB.EFileSearchDataTable efsdt = (appDB.EFileSearchDataTable)bs;

            searchResultBindingSource.DataSource = efsdt;
            foreach (appDB.EFileSearchRow efs in efsdt)
            {
                efs.SetMessageNull();
                efs.SetResultNull();
            }

            fmCurrent = this.AtMng.GetFile();

            DataView dv = new DataView(fmCurrent.Codes("vACMenu"), "Menu='MassActivity'", "StepCode", DataViewRowState.CurrentRows);
            UIHelper.ComboBoxInit(dv, ucActivity, fmCurrent);
            UIHelper.ComboBoxInit("vTemplateList1", uiTemplate, fmCurrent);
            gridFileList.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(gridFileList_LoadingRow);


        }



        private void gridFileList_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

        }

        private static bool RemoveSuccess(DataRow dr)
        {
            lmDatasets.appDB.EFileSearchRow efsr = (lmDatasets.appDB.EFileSearchRow)dr;
            if (efsr.IsResultNull() || efsr.Result == "Failed" || efsr.Result == "Raté")
                return false;
            else
                return true;
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataRow> toAction = UIHelper.GridGetSelectedData(gridFileList);
                toAction.RemoveAll(RemoveSuccess);

                if (toAction.Count > 0 && MessageBox.Show("Are you sure you want to proceed?  You have selected " + toAction.Count.ToString() + " files.", "Mass Activity", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string massMailingPath = null;

                    ActivityConfig.ACSeriesRow acsr = SelectedACSeries();
                    ACEngine ace = new ACEngine(fmCurrent);
                    ace.TestForSteps(acsr.ACSeriesId);
                    if (ace.HasDoc && chkConcatenate.Checked)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
                        saveFileDialog1.FileName = "Merge_" + acsr.StepCode.Replace(".", "") + "_" + DateTime.Today.ToString("yyyyMMdd") + ".rtf";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            massMailingPath = saveFileDialog1.FileName;

                        }
                    }

                    docDB.DocumentRow doc2Copy = null;
                    if (acsr.ACSeriesId == AtMng.GetSetting(AppIntSetting.DocumentCopyAcId))
                    {
                        fBrowseDocs fdoc = ((fMain)Application.OpenForms["fMain"]).OpenDocDialog;
                        massMailingPath = null;
                        if (fdoc.ShowDialog(this) == DialogResult.OK && fdoc.SelectedDocuments() != null)
                        {
                            doc2Copy = fdoc.SelectedDocument;
                        }
                        else
                        {
                            MessageBox.Show("You can't proceed without selecting a document.", "Mass Activity", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                    
                    //if (ctx != null && ctx.Count > 0)
                    //{
                        //we need to prompt for input
                        //launch wiz for first file to capture user input
                        lmDatasets.appDB.EFileSearchRow efsr = (lmDatasets.appDB.EFileSearchRow)toAction[0];
                  
                        FileManager fmFirst = AtMng.GetFile(efsr.FileId);
                        fACWizard facw;
                        lmDatasets.atriumDB.ActivityRow newAC=null;
                        if (doc2Copy != null)
                        {
                            docDB.DocumentRow docCopy = fmFirst.GetDocMng().GetDocument().MakeCopy(doc2Copy, fmFirst.CurrentFile, doc2Copy.IsDraft);
                            facw = new fACWizard(fmFirst, ACEngine.Step.Document, acsr.ACSeriesId,docCopy.DocId,"REVISE");
                        }
                        else
                        {
                            facw = new fACWizard(fmFirst, ACEngine.Step.ACInfo, acsr.ACSeriesId);
                        }
                        facw.ctx = ctx;
                        if (facw.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            //get newly added activity
                            newAC = fmFirst.DB.Activity[fmFirst.DB.Activity.Count - 1];
                            efsr.Result = "Success";
                            efsr.Message = "Prototype activity";
                            efsr.EndEdit();
                            toAction.Remove(efsr);
                        }
                        else
                        {
                            MessageBox.Show("You can't proceed without completing the prototype activity.", "Mass Activity", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }

                    //}

                    using (fWait fProgress = new fWait("Generating activities, please wait"))
                    {
                        AtMng.MassActivity(toAction, acsr, (string)uiTemplate.SelectedValue, massMailingPath, 0, ACEngine.RevType.Document, ctx, doc2Copy,newAC);
                    }


                }
                else if (toAction.Count == 0)
                {
                    MessageBox.Show("No files selected", "Mass Activity", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private ActivityConfig.ACSeriesRow SelectedACSeries()
        {
            int ACSeriesId = Convert.ToInt32(ucActivity.SelectedValue);
            ActivityConfig.ACSeriesRow AcSeries = this.AtMng.acMng.DB.ACSeries.FindByACSeriesId(ACSeriesId);
            return AcSeries;
        }

        void gridFileList_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            //if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
            //{
            //    e.Row.Cells["Created"].Value = "Created";
            //}


        }

        private void btnCancel_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucActivity_ASelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //check to see if step has templates

                ActivityConfig.ACSeriesRow acsr = SelectedACSeries();
                ACEngine ace = new ACEngine(fmCurrent);
                ace.TestForSteps(acsr.ACSeriesId);
                if (ace.HasDoc & ace.TemplateList != null)
                {
                    uiTemplate.Enabled = true;
                    UIHelper.ComboBoxInit(ace.TemplateList, uiTemplate, fmCurrent);
                }
                else
                {
                    uiTemplate.Enabled = false;
                    uiTemplate.SelectedValue = null;
                }

                //check for fields that require prompting

                ctx = new Dictionary<string, object>();
                foreach (ActivityConfig.ActivityFieldRow afr in acsr.GetActivityFieldRows())
                {
                    if (afr.TaskType == "F" & afr.Visible & !afr.ReadOnly & afr.IsDefaultObjectNameNull() & (afr.IsDefaultValueNull() || !afr.DefaultValue.StartsWith("[")))
                    {
                        ctx.Add(afr.ObjectAlias + afr.FieldName, null);
                    }
                }
                if (ctx.Count == 0)
                    ctx = null;

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void gridFileList_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    this.MainForm.OpenFile(CurrentRow().FileId);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        public appDB.EFileSearchRow CurrentRow()
        {
            if (searchResultBindingSource.Current == null)
                return null;
            else
                return (appDB.EFileSearchRow)((DataRowView)searchResultBindingSource.Current).Row;
        }
    }
}
