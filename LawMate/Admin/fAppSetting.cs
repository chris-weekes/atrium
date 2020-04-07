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
    public partial class fAppSetting : LawMate.Admin.fBase
    {
        public fAppSetting()
        {
            InitializeComponent();
        }
        public fAppSetting(Form f)
            : base(f)
        {
            InitializeComponent();
            
            AtMng.GetAppSetting().Load();

            appSettingBindingSource.DataSource = AtMng.DB;
            appSettingBindingSource.DataMember = AtMng.DB.AppSetting.TableName;
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
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void Cancel()
        {
            UIHelper.Cancel(appSettingBindingSource);
            settingNameEditBox.ReadOnly = true;
            settingNameEditBox.BackColor = SystemColors.Control;
            settingValueEditBox.ReadOnly = true;
            settingValueEditBox.BackColor = SystemColors.Control;
        }

        private void Save()
        {
            if (AtMng.DB.AppSetting.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.DB);
            }
            else
            {
                try
                {
                    appSettingBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetAppSetting());
                    bp.Update();

                }
                catch (Exception x)
                {
                    
                    throw x;
                }
            }
        }

        private void EnableTextBox(Janus.Windows.GridEX.EditControls.EditBox eb)
        {
            if (MessageBox.Show("Are you sure you want to edit this Application Setting?", "Application Setting Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                eb.BackColor = SystemColors.Window ;
                eb.ReadOnly = false;
            }   
        }

        private void settingNameEditBox_ButtonClick(object sender, EventArgs e)
        {
            try
            {
               EnableTextBox(settingNameEditBox);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void settingValueEditBox_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                EnableTextBox(settingValueEditBox);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void appSettingBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                settingNameEditBox.ReadOnly = true;
                settingNameEditBox.BackColor = SystemColors.Control;
                settingValueEditBox.ReadOnly = true;
                settingValueEditBox.BackColor = SystemColors.Control;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
