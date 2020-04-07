using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fChangePassword : Form
    {
        public fChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LawMate.Properties.Resources.UIPasswordNotChanged, LawMate.Properties.Resources.UIPasswordNotChangedCaption, MessageBoxButtons.OK);
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbOldPass.Text=="")
                {
                    MessageBox.Show(LawMate.Properties.Resources.YouMustEnterYourCurrentPassword, LawMate.Properties.Resources.ChangePassword, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (tbNewPass.Text == tbConfirmPass.Text)
                {
                    UIHelper.AtMng.SecurityManager.GetsecUser().ChangeSQLPassword(UIHelper.AtMng.SecurityManager.CurrentUser, this.tbNewPass.Text, tbOldPass.Text);
      //TODO              UIHelper.AtMng.AppMan.ResetDBConnection(new System.Net.NetworkCredential(UIHelper.AtMng.SecurityManager.CurrentUser.UserName, tbNewPass.Text));
                    MessageBox.Show(LawMate.Properties.Resources.YourPasswordHasBeenSuccessfullyChangedYouMustLogOutAndLogBackInImmediately, LawMate.Properties.Resources.LogoutRequired, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                    MessageBox.Show(LawMate.Properties.Resources.ThePasswordDoesNotMatchTheConfirmPassword, LawMate.Properties.Resources.ChangePassword, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}