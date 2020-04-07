using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

 namespace LawMate
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs

            //this.Text = String.Format(LawMate.Properties.Resources.UIAboutLawMate, AssemblyTitle);
            this.Text = String.Format(LawMate.Properties.Resources.UIAboutLawMate, UIHelper.AtMng.AppMan.AppName);
            this.lblProductName.Text = AssemblyProduct;
            this.lblVersion.Text = String.Format(LawMate.Properties.Resources.UIVersion, AssemblyVersion);
            this.lblCopyright.Text = AssemblyCopyright;
            this.lblCompanyName.Text = AssemblyCompany;
            this.ebDescription.Text = AssemblyDescription;

            if (LawMate.Properties.Resources.AppName == "LawMate")
                pictureBox4.Image = Properties.Resources.lawmateSplash;
            if (LawMate.Properties.Resources.AppName == "Atrium")
                pictureBox4.Image = Properties.Resources.atriumlogo;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                this.ebDescription.Text += "Click-once deployed from:\r\n" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.AbsoluteUri + "\r\n\r\n";
            }
            else
            {
                this.ebDescription.Text += "Not Click-once deployed\r\n";
            }
            Assembly asm = Assembly.GetExecutingAssembly();
            this.ebDescription.Text += "File Version:\r\n" + asm.FullName + "\r\n\r\n";

            this.ebDescription.Text += "References :" + "\r\n";
            AssemblyName[] asmNames = asm.GetReferencedAssemblies();
            foreach (AssemblyName nm in asmNames)
            {
                this.ebDescription.Text += nm.FullName + "\r\n\r\n";
            }

            string servInfo = "{0}: {1}\r\n";

            this.ebDescription.Text += String.Format(servInfo, "DB connect", UIHelper.AtMng.AppMan.ServerInfo.dbConnect);
            this.ebDescription.Text += String.Format(servInfo, "Remote Url", UIHelper.AtMng.AppMan.ServerInfo.remoteUrl);
            this.ebDescription.Text += String.Format(servInfo, "Report Url", UIHelper.AtMng.AppMan.ServerInfo.reportUrl);
            this.ebDescription.Text += String.Format(servInfo, "Report Service", UIHelper.AtMng.AppMan.ServerInfo.reportService);

        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            try
            {
                ebDescription.Focus();
                ebDescription.Select(0, 0);
            }
            catch (Exception ex)
            {
                UIHelper.HandleUIException(ex);
            }
        }

       
    }
}
