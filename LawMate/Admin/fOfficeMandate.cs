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
     public partial class fOfficeMandate : LawMate.Admin.fBase
    {
        atriumBE.OfficeManager offMng;

        public fOfficeMandate()
        {
            InitializeComponent();
        }
        public fOfficeMandate(Form f)
            : base(f)
        {
            InitializeComponent();

            //AtMng.acMng.GetOfficeMandate().Load();
            
            officeMandateBindingSource.DataSource = AtMng.acMng.DB;
            officeMandateBindingSource.DataMember = AtMng.acMng.DB.OfficeMandate.TableName;

            offMng= AtMng.GetOffice();
            offMng.GetOffice().Load();

            DataView dvOffice = new DataView(offMng.DB.Office, "IsOnLine=1", "officecode", DataViewRowState.CurrentRows);
            DataView dvACSeries = new DataView(AtMng.acMng.DB.ACSeries, "(Start=1 or initialstep=1 or initialstep=2) and obsolete=0", "stepcode", DataViewRowState.CurrentRows);
            
            officeCodeComboBox.SetDataBinding(dvOffice, "");
            suffixComboBox.SetDataBinding(dvACSeries, "");
            mccSeries.SetDataBinding(dvACSeries, "");
            mccRole.SetDataBinding(dvACSeries, "");

           officeMandateGridEX.DropDowns[0].SetDataBinding(dvOffice, "");
           officeMandateGridEX.DropDowns[1].SetDataBinding(dvACSeries, "");
           officeMandateGridEX.DropDowns[2].SetDataBinding(dvACSeries, "");
           officeMandateGridEX.DropDowns[3].SetDataBinding(dvACSeries, "");
           officeMandateGridEX.DropDowns[4].SetDataBinding(dvACSeries, "");

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
                    case "cmdDelete":
                        Delete();
                        break;
                    case "cmdNew":
                        New();
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
            UIHelper.Cancel(officeMandateBindingSource);
        }
        private void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    officeMandateBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.acMng.GetOfficeMandate());
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
            if (AtMng.acMng.DB.OfficeMandate.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.acMng.DB);
            }
            else
            {
                try
                {
                    officeMandateBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.acMng.GetOfficeMandate());
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
            ActivityConfig.OfficeMandateRow omr = (ActivityConfig.OfficeMandateRow)AtMng.acMng.GetOfficeMandate().Add(null);
            officeMandateBindingSource.Position = officeMandateBindingSource.Find("Id", omr.Id);
 
        }

        private ActivityConfig.OfficeMandateRow CurrentRow()
        {
            return (ActivityConfig.OfficeMandateRow)((DataRowView)officeMandateBindingSource.Current).Row;
        }

        private void fOfficeMandate_Load(object sender, EventArgs e)
        {
            try
            {
                officeMandateGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void officeMandateGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (officeMandateGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.GroupHeader)
                {
                    uiGroupBox4.Visible = false;
                    cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    uiGroupBox4.Visible = true;
                    cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True; 
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

