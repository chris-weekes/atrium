using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class fACMenu : fBase
    {
        public fACMenu()
        {
            InitializeComponent();
        }

        public fACMenu(Form f)
            : base(f)
        {
            InitializeComponent();
            aCMenuGridEX.DropDowns["ddACSeries"].SetDataBinding(AtMng.acMng.DB.ACSeries, "");
            aCMenuGridEX.DropDowns["ddACSeriesActivityName"].SetDataBinding(AtMng.acMng.DB.ACSeries, "");
            aCMenuGridEX.DropDowns["ddACSeriesSuffix"].SetDataBinding(AtMng.acMng.DB.ACSeries, "");
            aCMenuGridEX.DropDowns["ddMenu"].SetDataBinding(AtMng.GetFile().Codes( "MenuForms"), "");

            aCMenuBindingSource.DataSource = AtMng.acMng.DB;
            aCMenuBindingSource.DataMember = AtMng.acMng.DB.ACMenu.TableName;

            menuBindingSource.DataSource = AtMng.acMng.DB;
            menuBindingSource.DataSource = AtMng.acMng.DB.Menu.TableName;
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
                    case "cmdNew":
                        New();
                        break;
                    case "cmdSave":
                        Save();
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

        private void Save()
        {
            if (AtMng.acMng.DB.ACMenu.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.acMng.DB);
            }
            else
            {
                try
                {
                    aCMenuGridEX.UpdateData();
                    aCMenuBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.acMng.GetACMenu());
                    bp.Update();
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }

        private lmDatasets.ActivityConfig.ACMenuRow CurrentRow()
        {
            if (aCMenuBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.ActivityConfig.ACMenuRow)((DataRowView)aCMenuBindingSource.Current).Row;
        }

        private void Cancel()
        {
            UIHelper.Cancel(aCMenuBindingSource);
        }

        private void New()
        {
            lmDatasets.ActivityConfig.ACMenuRow acmr = (lmDatasets.ActivityConfig.ACMenuRow)AtMng.acMng.GetACMenu().Add(null);
            aCMenuBindingSource.Position = aCMenuBindingSource.Find("Id", acmr.Id);
        }

        private void Delete()
        {
            try
            {
                lmDatasets.ActivityConfig.ACMenuRow acmr = CurrentRow();
                if (CurrentRow() == null)
                    return;

                if (!AtMng.acMng.GetACMenu().CanDelete(acmr))
                {
                    MessageBox.Show("Not Allowed to Delete", "Deleting Quick Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (!UIHelper.ConfirmDelete())
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            acmr.Delete();
                            atLogic.BusinessProcess bp = AtMng.GetBP();
                            bp.AddForUpdate(AtMng.acMng.GetACMenu());
                            bp.Update();
                        }
                        catch (Exception x1)
                        {

                            AtMng.acMng.DB.ACMenu.RejectChanges();
                            throw x1;
                        }

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

