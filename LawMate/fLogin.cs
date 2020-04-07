using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fLogin : Form
    {

        public Boolean isCancel;
        bool hide = true;
        atriumBE.Servers serverList;

        public atriumBE.Servers ServerList
        {
            get { return serverList; }
            set
            {
                serverList = value;
                cboServer.DataSource = serverList.Server;
                cboServer.DisplayMember = "serverName";
                cboServer.ValueMember = "serverName";

                if (UIHelper.GetSetting("Server") != "")
                    cboServer.Text = UIHelper.GetSetting("Server");

                Remote(cboServer.Text);
            }
        }

        private string GetCurrentUser()
        {
            AppDomain myDomain = System.Threading.Thread.GetDomain();

            myDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            System.Security.Principal.WindowsPrincipal myPrincipal = (System.Security.Principal.WindowsPrincipal)System.Threading.Thread.CurrentPrincipal;

            return myPrincipal.Identity.Name;
        }

        private void Remote(string server)
        {
            gbUser.Enabled = true;
            atriumBE.Servers.ServerRow svr = ServerList.Server.FindByserverName(server);
            if (svr == null)
            {
                fwPassword.Visible = false;
                label4.Visible = false;
            }
            else if (svr.trustedConnection)
            {
                editBox1.Text = GetCurrentUser();
                fwPassword.Visible = false;
                label4.Visible = false;
                gbUser.Enabled = false;
            }
            else if (svr.useProxy)
            {
                fwPassword.Visible = true;
                label4.Visible = true;
            }
            else
            {
                fwPassword.Visible = false;
                label4.Visible = false;
            }
        }

        public fLogin()
        {
            InitializeComponent();
            this.Text = Properties.Resources.AppName + " Logon / Connexion à " + Properties.Resources.AppName;
            
            if (Properties.Resources.AppName == "Atrium")
                this.Icon = Properties.Resources.AtriumTrans48x48;
            else
                this.Icon = Properties.Resources.scale_icon;

            editBox1.Text = UIHelper.GetSetting("UserName");

            if (UIHelper.GetSetting("UserLanguage") == "")
            {
                EnglishRadio.Checked = true;
                UIHelper.SaveSetting("UserLanguage", "ENG");
            }
            else
            {
                if ((UIHelper.GetSetting("UserLanguage")) == "FRE")
                    FrenchRadio.Checked = true; 
                else
                    EnglishRadio.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                hide = true;
                string err = "";
                if (gbUser.Enabled)
                {
                    if (this.editBox1.Text.Length == 0)
                        err = Properties.Resources.LoginBlankUserName;
                    if (this.editBox2.Text.Length == 0)
                    {
                        if (err != "")
                            err += "\n";
                        err += Properties.Resources.LoginBlankPassword;
                    }
                    if (err != "")
                    {
                        MessageBox.Show(err, Properties.Resources.AppName , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hide = false;
                    }
                }
                if (hide)
                    this.Hide();

                UIHelper.SaveSetting("UserName", editBox1.Text);

                if (EnglishRadio.Checked)
                    UIHelper.SaveSetting("UserLanguage", "ENG");
                else
                    UIHelper.SaveSetting("UserLanguage", "FRE");

                UIHelper.SaveSetting("Server", cboServer.Text);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void fLogin_Shown(object sender, EventArgs e)
        {
            if (editBox1.Text.Length > 0)
                editBox2.Focus();
        }

        private void cboServer_SelectedValueChanged(object sender, EventArgs e)
        {
            Remote(cboServer.Text);
        }

        private void editBox2_TextChanged(object sender, EventArgs e)
        {
            fwPassword.Text = editBox2.Text;
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                CloseForm();
            }
        }

        private void CloseForm()
        {
            try
            {
                this.Hide();
                this.isCancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}