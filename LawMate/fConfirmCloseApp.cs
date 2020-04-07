using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fConfirmCloseApp : Form
    {
        atriumBE.OfficerPrefsBE offPrefs;
        public DialogResult dResult;
        public bool Warn = false;
        public fConfirmCloseApp()
        {
            InitializeComponent();
            offPrefs = UIHelper.AtMng.OfficeMng.GetOfficerPrefs();
            uiCheckBox1.Checked = !offPrefs.GetPref(atriumBE.OfficerPrefsBE.PromptOnClose, true);
            LoadLabels();
            //label1.BackColor = pnlClose.BackColor;
        }

        private void LoadLabels()
        {
            this.Text = String.Format(LawMate.Properties.Resources.ConfirmCloseTitle, UIHelper.AtMng.AppMan.AppName);
            label1.Text = String.Format(LawMate.Properties.Resources.ConfirmCloseApp, UIHelper.AtMng.AppMan.AppName);
        }
        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                offPrefs = UIHelper.AtMng.OfficeMng.GetOfficerPrefs();
                bool prompt= !uiCheckBox1.Checked;
                offPrefs.SetPref(atriumBE.OfficerPrefsBE.PromptOnClose, prompt);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            dResult = DialogResult.Yes;
            Close();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            dResult = DialogResult.No;
            Close();

        }

        private void fConfirmCloseApp_Load(object sender, EventArgs e)
        {
            try
            {
                uiButton1.Focus();
                if (Warn)
                {
                    label1.Text = String.Format(LawMate.Properties.Resources.ConfirmCloseAppEdit, UIHelper.AtMng.AppMan.AppName);
                    uiCheckBox1.Visible = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }




    }
}