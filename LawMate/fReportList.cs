using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


 namespace LawMate
{
    public partial class fReportList : fBase
    {
        fWait fwait;
        //string reportServerUrl = System.Configuration.ConfigurationSettings.AppSettings.Get("reportServerUrl");
        //string reportServerWSUrl = System.Configuration.ConfigurationSettings.AppSettings.Get("reportServerWSUrl");
        //string reportTempDir = System.Configuration.ConfigurationSettings.AppSettings.Get("reportTempDir");
        //string reportFolder = System.Configuration.ConfigurationSettings.AppSettings.Get("reportFolder");

  		LawMate.ReportingService.ReportingService2005 myRS;

        public fReportList()
        {
            InitializeComponent();
        }

        public fReportList(Form f)
            : base(f)
        {
            InitializeComponent();
            
            fwait = new fWait(LawMate.Properties.Resources.ReportConnectingToServer);
            fwait.Show();
            fwait.Refresh();
            
            GetRS();
            
            fwait.setMessageText(LawMate.Properties.Resources.ReportRetrievingList);
            fwait.Refresh();

            ListRSFolders("/",treeView1.Nodes[0]);
            treeView1.ExpandAll();
            fwait.Hide();
        }
       
       public void ListRSFolders(string path,TreeNode node)
        {
            LawMate.ReportingService.CatalogItem[] catalogItems;
            catalogItems = this.GetRS().ListChildren(path, false);
            foreach (LawMate.ReportingService.CatalogItem ci in catalogItems)
            {
                if (!ci.Hidden && ci.Type == LawMate.ReportingService.ItemTypeEnum.Folder)
                {
                    TreeNode nd=node.Nodes.Add(ci.Name);
                    nd.Tag=ci;
                    ListRSFolders(ci.Path, nd);
                }

            }
            ListRSReports(path, node);

        }

        public void ListRSReports(string path, TreeNode node)
        {
            LawMate.ReportingService.CatalogItem[] catalogItems;
            catalogItems = this.GetRS().ListChildren(path, false);
            foreach (LawMate.ReportingService.CatalogItem ci in catalogItems)
            {
                if (!ci.Hidden && ci.Type == LawMate.ReportingService.ItemTypeEnum.Report)
                {
                    TreeNode nd = node.Nodes.Add(ci.Name);
                    nd.Tag = ci;
                    nd.ImageIndex = 2;
                    nd.SelectedImageIndex = 2;
                }

            }

        }

        public LawMate.ReportingService.ReportingService2005 GetRS()
        {
            if (myRS == null)
            {
                myRS = new LawMate.ReportingService.ReportingService2005();
                myRS.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //myRS.UseDefaultCredentials = true;
                //myRS.Url = LawMate.Properties.Settings.Default.lmwin_ReportingService_ReportingService;
                myRS.Url = AtMng.AppMan.ServerInfo.reportUrl + AtMng.AppMan.ServerInfo.reportService;
            }
            return myRS;

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                LawMate.ReportingService.CatalogItem ci = (LawMate.ReportingService.CatalogItem)e.Node.Tag;
                if (ci.Type == LawMate.ReportingService.ItemTypeEnum.Report | ci.Type == LawMate.ReportingService.ItemTypeEnum.LinkedReport)
                {
                    //fReportViewer frv = new fReportViewer(this.MainForm, ci.Path);
                    //frv.Text += " - " + ci.Name;
                    //frv.Show();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

    }
}

