using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fBFCode : fBase
    {
        public fBFCode()
        {
            InitializeComponent();
        }
        public fBFCode(Form f)
            : base(f)
        {
            InitializeComponent();

            ucBFCode1.AtMng = AtMng;

            aCBFBindingSource.DataMember = AtMng.acMng.DB.ACBF.ToString();
            aCBFBindingSource.DataSource = AtMng.acMng.DB;
            

            atriumBE.FileManager FM = AtMng.GetFile();
            aCBFGridEX.DropDowns["ddBFType"].SetDataBinding(FM.Codes("BFType"),"");
            aCBFGridEX.DropDowns["ddRoleCode"].SetDataBinding(FM.AtMng.GetGeneralRec("select * from vRoleuContactType where obsolete=0"),"");
            FM.Dispose();

            
            int id = CurrentRow().ACBFId;
            ucBFCode1.DataSource = new DataView(AtMng.acMng.DB.ACBF, "ACBFId=" + id.ToString(), "", DataViewRowState.CurrentRows);
        }

        private lmDatasets.ActivityConfig.ACBFRow CurrentRow()
        {
            if (aCBFBindingSource.Current != null)
                return (lmDatasets.ActivityConfig.ACBFRow)((DataRowView)aCBFBindingSource.Current).Row;
            else
                return null;
        }

        private void aCBFBindingSource_PositionChanged(object sender, EventArgs e)
        {
            
            int id = CurrentRow().ACBFId;
            ucBFCode1.DataSource = new DataView(AtMng.acMng.DB.ACBF, "ACBFId=" + id.ToString(), "", DataViewRowState.CurrentRows);

            if (ucBFCode1.BFIsUsed)
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            else
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
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
                        aCBFGridEX.EnsureVisible(aCBFGridEX.CurrentRow.Position);
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

        private void Delete()
        {
            try
            {
                if (MessageBox.Show("Your current selection will be deleted.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int gridPos = aCBFGridEX.CurrentRow.Position;
                    CurrentRow().Delete();
                    if (gridPos > aCBFGridEX.RowCount)
                        aCBFGridEX.Row = aCBFGridEX.RowCount;
                    else
                        aCBFGridEX.Row = gridPos;

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.acMng.GetACBF());
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

        private void New()
        {
            lmDatasets.ActivityConfig.ACBFRow bfr = (lmDatasets.ActivityConfig.ACBFRow)AtMng.acMng.GetACBF().Add(null);
            aCBFBindingSource.Position = aCBFBindingSource.Find("ACBFId", bfr.ACBFId);
        }

        private bool Save()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be saved.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ucBFCode1.EndEdit();
                    aCBFBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.acMng.GetACBF());
                    bp.Update();


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
                    UIHelper.Cancel(aCBFBindingSource);
                    UIHelper.Cancel(AtMng.acMng.DB);
                    ucBFCode1.DataSource = new DataView(AtMng.acMng.DB.ACBF, "ACBFId=" + CurrentRow().ACBFId, "", DataViewRowState.CurrentRows);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void aCBFGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //UIHelper.GroupRowVerify(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void aCBFGridEX_FilterApplied(object sender, EventArgs e)
        {
            try
            {
                aCBFGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fBFCode_Load(object sender, EventArgs e)
        {
            try
            {
                aCBFGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucBFCode1_SeriesLinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DataRow dr = ((DataRowView)e.Column.GridEX.CurrentRow.DataRow).Row;
                int seriesid = (int)dr["SeriesId"];
                MainAdminForm.MoreInfoSeries(seriesid);

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucBFCode1_AcSeriesLinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DataRow dr = ((DataRowView)e.Column.GridEX.CurrentRow.DataRow).Row;
                int seriesid = (int)dr["SeriesId"];
                int acseriesid = (int)dr["ACSeriesId"];
                MainAdminForm.MoreInfoACSeries(seriesid, acseriesid);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

