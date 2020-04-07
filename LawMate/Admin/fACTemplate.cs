using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fACTemplate : fBase
    {
        public fACTemplate()
        {
            InitializeComponent();
        }

        public fACTemplate(Form f)
            : base(f)
        {
            InitializeComponent();

            ucActivityCode1.AtMng = AtMng;

            activityCodeBindingSource.DataMember = AtMng.acMng.DB.ActivityCode.ToString();
            activityCodeBindingSource.DataSource = AtMng.acMng.DB;
            

            int id = CurrentRow().ActivityCodeID;
            ucActivityCode1.DataSource = new DataView(AtMng.acMng.DB.ActivityCode, "ActivityCodeID=" + id.ToString(), "", DataViewRowState.CurrentRows);

        }

        private bool Save()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be saved.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ucActivityCode1.EndEdit();
                    activityCodeBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.acMng.GetActivityCode());
                   
                    bp.Update();

                   

                    pnlActivitiesList.Closed = false;
                    if (NewAcId != 0)
                    {
                        activityCodeBindingSource.Position = activityCodeBindingSource.Find("ActivityCodeID", NewAcId);
                        NewAcId = 0;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception x)
            {
               
                UIHelper.HandleUIException(x);

                return false;
            }
        }
        private void Cancel()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    UIHelper.Cancel(activityCodeBindingSource);
                    UIHelper.Cancel(AtMng.acMng.DB);
                    pnlActivitiesList.Closed = false;
                    NewAcId = 0;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        int NewAcId = 0;

        private void New()
        {
            lmDatasets.ActivityConfig.ActivityCodeRow ar = (lmDatasets.ActivityConfig.ActivityCodeRow)AtMng.acMng.GetActivityCode().Add(null);
            activityCodeBindingSource.Position = activityCodeBindingSource.Find("ActivityCodeID", ar.ActivityCodeID);
            NewAcId = ar.ActivityCodeID;
            pnlActivitiesList.Closed = true;
        }

        private void Delete()
        {
            try
            {
                if (MessageBox.Show("Your current selection will be deleted.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int gridPos = activityCodeGridEX.CurrentRow.Position;
                    CurrentRow().Delete();
                    if (gridPos > activityCodeGridEX.RowCount)
                        activityCodeGridEX.Row = activityCodeGridEX.RowCount;
                    else
                        activityCodeGridEX.Row = gridPos;

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.acMng.GetActivityCode());

                    bp.Update();

                }
                else
                    return;
            }
            catch (Exception x)
            {
               
                UIHelper.HandleUIException(x);
                return;
            }


            
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
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdNew":
                        New();
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityCodeBindingSource_PositionChanged(object sender, EventArgs e)
        {
            
                int id = CurrentRow().ActivityCodeID;
                ucActivityCode1.DataSource = new DataView(AtMng.acMng.DB.ActivityCode, "ActivityCodeID=" + id.ToString(), "", DataViewRowState.CurrentRows);

                if (ucActivityCode1.ACIsUsed)
                    cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                else
                    cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        }

        private lmDatasets.ActivityConfig.ActivityCodeRow CurrentRow()
        {
            if (activityCodeBindingSource.Current != null)
                return (lmDatasets.ActivityConfig.ActivityCodeRow)((DataRowView)activityCodeBindingSource.Current).Row;
            else 
                return null;
        }

        private void activityCodeGridEX_FilterApplied(object sender, EventArgs e)
        {
            try
            {
                activityCodeGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
            
        }

        private void activityCodeGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GroupRowVerify(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fACTemplate_Load(object sender, EventArgs e)
        {
            try
            {
                activityCodeGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}

