using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class fHelp : LawMate.Admin.fBase
    {
        atriumBE.HelpManager myHelp;
        public fHelp()
        {
            InitializeComponent();
        }

        public fHelp(Form f)
            : base(f)
        {
            InitializeComponent();

            myHelp = AtMng.HelpMng();
            myHelp.LoadAll(true);

            hlpPageBindingSource.DataSource = myHelp.DB;
            bindingSource1.DataSource = myHelp.DB;

          //  gridEX1.SetDataBinding(myHelp.DB, "hlpPage");

            linkLabel5.Text = AtMng.AppMan.ServerInfo.helpUrl + AtMng.AppMan.ServerInfo.DeskbookHomePath;
            linkLabel6.Text = AtMng.AppMan.ServerInfo.reportAdminUrl;
            linkLabel7.Text = AtMng.AppMan.ServerInfo.remoteUrl + "/deskbooksam/";
            linkLabel8.Text = AtMng.AppMan.ServerInfo.remoteUrl + "/workflow/";


        }
        private void btnDump_Click(object sender, EventArgs e)
        {
            string path;

            saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FileName = "AtriumHelp" + DateTime.Today.ToString("yyyy-MM-dd") + ".xml";

            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                path = saveFileDialog1.FileName;
                myHelp.Dump(path, uiCheckBox1.Checked, uiCheckBox2.Checked);
            }
        }

        private void btnPages_Click(object sender, EventArgs e)
        {
            string path;

            try
            {
                if (folderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    path = folderBrowserDialog1.SelectedPath;
                    myHelp.DumpFiles(path);
                }
            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string path;
            try
            {
                if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    path = openFileDialog1.FileName;
                    myHelp.Import(path);
                }
            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!uiCheckBox1.Checked && !uiCheckBox2.Checked)
            {
                uiButton1.Enabled = false;
                uiButton2.Enabled = false;
            }
            else
            {
                uiButton1.Enabled = true;
                uiButton2.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (lmDatasets.HelpDB.hlpPageRow pg in myHelp.DB.hlpPage.Rows)
                {
                    if (!pg.Publish)
                        pg.Publish = true;
                }
                bindingSource1.EndEdit();
                gridEX1.Refresh();

            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (lmDatasets.HelpDB.hlpImageRow img in myHelp.DB.hlpImage.Rows)
                {
                    if (!img.Publish)
                        img.Publish = true;
                }
                bindingSource1.EndEdit();
                gridEX2.Refresh();

            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (lmDatasets.HelpDB.hlpPageRow pg in myHelp.DB.hlpPage.Rows)
                {
                    if (pg.Publish)
                        pg.Publish = false;
                }
                bindingSource1.EndEdit();
                gridEX1.Refresh();

            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                foreach (lmDatasets.HelpDB.hlpImageRow img in myHelp.DB.hlpImage.Rows)
                {
                    if (img.Publish)
                        img.Publish = false;
                }
                bindingSource1.EndEdit();
                gridEX2.Refresh();

            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(AtMng.AppMan.ServerInfo.helpUrl + AtMng.AppMan.ServerInfo.DeskbookHomePath);
                System.Diagnostics.Process.Start(sInfo);
            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(AtMng.AppMan.ServerInfo.reportAdminUrl);
                System.Diagnostics.Process.Start(sInfo);
            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(AtMng.AppMan.ServerInfo.remoteUrl + "/deskbooksam/");
                System.Diagnostics.Process.Start(sInfo);
            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
            
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(AtMng.AppMan.ServerInfo.remoteUrl + "/workflow/");
                System.Diagnostics.Process.Start(sInfo);
            }
            catch (Exception x)
            {
                LawMate.UIHelper.HandleUIException(x);
            }
        }
    }
}
