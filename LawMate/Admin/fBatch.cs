using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fBatch : fBase
    {
        public fBatch()
        {
            InitializeComponent();
        }
        public fBatch(Form f): base(f)
        {
            InitializeComponent();

            cbStatus.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Pending", "P", 0));
            cbStatus.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Active", "A", 1));
            cbStatus.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Finished", "F", 2));
            cbStatus.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Failed", "X", 3));
            cbStatus.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Read", "R", 4));
            
            UIHelper.ComboBoxInit("vofficerlist", ucMultiDropDown1, AtMng.GetFile());

            batchBindingSource.DataSource = AtMng.DB;


           
        }

        private void fBatch_Load(object sender, EventArgs e)
        {
            try
            {
                AtMng.GetBatch().Load();
                batchGridEX.RootTable.SortKeys.Add(batchGridEX.RootTable.Columns["BatchDate"], Janus.Windows.GridEX.SortOrder.Descending);
                batchGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void batchBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try 
            {
                ApplySecurity(CurrentRow());
 
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private lmDatasets.appDB.BatchRow CurrentRow()
        {
            if (batchBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.BatchRow)((DataRowView)batchBindingSource.Current).Row;
        }

        private void ApplySecurity(DataRow dr) 
        {
            lmDatasets.appDB.BatchRow br = (lmDatasets.appDB.BatchRow)dr;
            UIHelper.EnableControls(batchBindingSource, AtMng.GetBatch().CanEdit(br));
            UIHelper.EnableCommandBarCommand(cmdDelete, AtMng.GetBatch().CanDelete(br));
        }

        private void Save()
        {
            if (AtMng.DB.Batch.HasErrors)
            {
                MessageBox.Show("Cannot save while there are errors in the data.");
            }
            else 
            {
                try
                {
                    batchGridEX.UpdateData();
                    batchBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetBatch());
                    bp.Update();

               
                }
                catch (Exception x)
                {
                  
                    UIHelper.HandleUIException(x);
                }
            }
        }

        private void Cancel()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    UIHelper.Cancel(batchBindingSource);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void Delete()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Batch Review record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    CurrentRow().Delete();
                    batchBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetBatch());
                    bp.Update();


                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdNewSQL":
                        lmDatasets.appDB.BatchRow br=(lmDatasets.appDB.BatchRow) AtMng.GetBatch().Add(null);
                        br.JobName = "RunSQL";
                        parametersEditBox.ReadOnly = false;
                        break;

                    case "cmdRun":
                        
                        AtMng.GetBatch().RunAllJobs();
                        break;
                    case "cmdSave":
                        Save();
                        parametersEditBox.ReadOnly = true;
                        break;

                    case "cmdCancel":
                        Cancel();
                        parametersEditBox.ReadOnly = true;
                        break;

                    case "cmdDelete":
                        Delete();
                        parametersEditBox.ReadOnly = true;
                        break;


                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}