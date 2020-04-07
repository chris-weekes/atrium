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
    public partial class fPLOffice : fBase
    {
        public fPLOffice()
        {
            InitializeComponent();
        }
        public fPLOffice(Form f): base(f)
        {
            InitializeComponent();
        }

        private void fPLOffice_Load(object sender, EventArgs e)
        {
            AtMng.GetPLOffice().Load();
            pLOfficeBindingSource.DataSource = AtMng.DB;

            atriumBE.FileManager FM = AtMng.GetFile();

            pLOfficeGridEX.DropDowns["ddContactType"].SetDataBinding(FM.Codes("ContactType"), "");
            pLOfficeGridEX.DropDowns["ddFileType"].SetDataBinding(FM.Codes("FileType"), "");
            pLOfficeGridEX.DropDowns["ddStatus"].SetDataBinding(FM.Codes("Status"), "");
            pLOfficeGridEX.DropDowns["ddOffice"].SetDataBinding(FM.Codes("vOfficeList"), "");
            pLOfficeGridEX.DropDowns["ddOfficer"].SetDataBinding(FM.Codes("vOfficerList"), "");
            pLOfficeGridEX.DropDowns["ddOfficeType"].SetDataBinding(FM.Codes("OfficeType"), "");

            pLOfficeGridEX.MoveFirst();
        }

        private void pLOfficeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                pLOfficeGridEX.CurrentRow.EndEdit();
                pLOfficeGridEX.UpdateData();
                pLOfficeBindingSource.EndEdit();

                atLogic.BusinessProcess bp = AtMng.GetBP();
                bp.AddForUpdate(AtMng.GetPLOffice());

                bp.Update();
                
            }
            catch (Exception x)
            {
               
                UIHelper.HandleUIException(x);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AtMng.GetPLOffice().Add(null);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void uiCommandBar1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdCancel":
                        Cancel();
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                    case "cmdNew":
                        New();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdProjection":
                        RunProjections();
                        break;
                    case "cmdRunAll":
                        RunJob(true);
                        break;
                    case "cmdSingleJob":
                        RunJob(false);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        

        private void RunJob(bool isFull)
        {
            pnlCreateJob.Closed = false;
            calendarCombo1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 0, 0);
            if (isFull)
            {
                label3.Text = "FULL Redistribution of All Files";
                uiButton1.Text = "Schedule Job";
                pLOfficeGridEX.RootTable.RemoveFilter();
                uiButton1.Tag = "FULL";
            }
            else
            {
                label3.Text = "PARTIAL Redistribution of Files";
                uiButton1.Text = "Schedule Jobs";
                pLOfficeGridEX.RootTable.FilterCondition = pLOfficeGridEX.RootTable.StoredFilters[0];
                uiButton1.Tag = "PARTIAL";
            }
        }

        private void RunProjections()
        {
            fSQL fsql = new fSQL(this.ParentForm);
            fsql.Show();
            fsql.OfficeDistributionProjection();
            fsql.WindowState = FormWindowState.Maximized;

        }

        private void Cancel()
        {
            UIHelper.Cancel(pLOfficeBindingSource);
        }

        private void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    pLOfficeBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetPLOffice());
                    bp.Update();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void Save()
        {
            if (AtMng.DB.PLOffice.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.DB);
            }
            else
            {
                try
                {
                    pLOfficeBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetPLOffice());
                    bp.Update();
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
            }
        }

        private void New()
        {
            appDB.PLOfficeRow omr = (appDB.PLOfficeRow)AtMng.GetPLOffice().Add(null);
            pLOfficeBindingSource.Position = pLOfficeBindingSource.Find("PLOfficeID", omr.PLOfficeID);
        }

        private appDB.PLOfficeRow CurrentRow()
        {
            return (appDB.PLOfficeRow)((DataRowView)pLOfficeBindingSource.Current).Row;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                pnlCreateJob.Closed = true;
                uiPanel1.Closed = false;
                pLOfficeGridEX.RootTable.RemoveFilter();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void SaveBatchJob()
        {
            atLogic.BusinessProcess bp = AtMng.GetBP();
            bp.AddForUpdate(AtMng.GetBatch());
            bp.Update();
        }

        private void AddBatchJob(DateTime RunAfterDate, string JobParams)
        {
            lmDatasets.appDB.BatchRow br = (lmDatasets.appDB.BatchRow)AtMng.GetBatch().Add(null);
            br.JobName = "RunSQL";
            br.RunAfterDate = RunAfterDate;
            br.Parameters = JobParams;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string)uiButton1.Tag == "FULL")
                {
                    AddBatchJob(calendarCombo1.Value, "exec PLOfficeDistribUpdate");
                }
                else
                {
                    foreach (Janus.Windows.GridEX.GridEXRow gsi in pLOfficeGridEX.GetCheckedRows())
                    {
                        string plOfficeId = ((appDB.PLOfficeRow)(((DataRowView)gsi.DataRow).Row)).PLOfficeID.ToString();
                        AddBatchJob(calendarCombo1.Value, "exec PLOfficeDistribUpdateSingle " + plOfficeId);
                    }
                }
                SaveBatchJob();
                if (MessageBox.Show("The Office Distribution Job(s) has(have) been successfully created.\n\nDo you want to display the Batch Job Review screen?", "Office Distribution Batch Job(s) Created", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!MainAdminForm.verifyOpenForm("fBatch"))
                    {
                        fBatch f = new fBatch(this.ParentForm);
                        f.Show();
                        f.WindowState = FormWindowState.Maximized;
                    }
                }


            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
    }
}