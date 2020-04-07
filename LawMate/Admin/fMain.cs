using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using atriumBE;

 namespace LawMate.Admin
{
    public partial class fMain : Form
    {
        private int childFormNumber = 0;

        fWait fwait;
        fSeries WorkflowDesigner;
        string appOwner;
        public fMain()
        {
            InitializeComponent();

            if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.DataAdmin) == atSecurity.SecurityManager.ExPermissions.No)
                throw new LawMate.LMException("You do not have permission to run the admin module.");

            if(AtMng.acMng.DB.ACSeries.Count==0)
                AtMng.acMng.LoadAllConfigInfo();

            appOwner = AtMng.GetSetting(AppStringSetting.OwnerOfficeEng);
            if (AtMng.AppMan.Language == "FRE")
                appOwner = AtMng.GetSetting(AppStringSetting.OwnerOfficeFre);

            this.Text = AtMng.AppMan.AppAdminModule + " - " + appOwner + " - " + AtMng.AppMan.ServerName;
            uiStatusBar1.Panels["sbPnlAdminName"].Text = " " + AtMng.OfficerLoggedOn.FirstName + " " + AtMng.OfficerLoggedOn.LastName + " (" + AtMng.OfficerLoggedOn.OfficerCode + ")";
            //splash.TopMost = true;
           

        }

        public atriumBE.atriumManager AtMng
        {
            get
            {
                return UIHelper.AtMng;
            }
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void CommandFeatureCheck(atSecurity.SecurityManager.Features feature, Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            if (AtMng.SecurityManager.CanExecute(0, feature) == atSecurity.SecurityManager.ExPermissions.No)
                cmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        private void fMain_Load(object sender, EventArgs e)
        {

            if (!AtMng.GetSetting(AppBoolSetting.isPROD))
                UIHelper.SetNonProdUI(this, visualStyleManager1);
               
            CommandFeatureCheck(atSecurity.SecurityManager.Features.Series, cmdWFDesigner);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.Series, cmdActivityCode);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.Series, cmdBFTemplates);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.Template, cmdDocTemplates);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdOfficeMandates);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdACMenu);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.SysAdmin, cmdConfigSync);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.SysAdmin, cmdAdhocQuery);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdImportExternalDocs);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.SysAdmin, cmdExportDocs);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdPeriodicFileClosure);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.PLOffice, cmdPLOffice);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.Batch, cmdBatchReview);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.SysAdmin, cmdWWHelp);

            if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.No)
                cmdLookupTablesAll.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            else
                cmdLookupTables.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdLookupTablesAll);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdFileMetaType);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdIssues);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdLegislation);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdDistList);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdProvinces);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdCity);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdOfficeToJD);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.Series, cmdDataDictionnary);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.Series, cmdDDLookup);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.AppSetting, cmdAppSettings);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdOfficerPrefs);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.DataAdmin, cmdSystemMessages);

            CommandFeatureCheck(atSecurity.SecurityManager.Features.secGroup, cmdGroups);
            CommandFeatureCheck(atSecurity.SecurityManager.Features.secRule, cmdSecRules);

            //set permissions
            //if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.secRule) == atSecurity.SecurityManager.ExPermissions.No)
            //    cmdSecurity.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            //if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Series) == atSecurity.SecurityManager.ExPermissions.No)
            //    cmdWorkflow.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            //if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.PLOffice) == atSecurity.SecurityManager.ExPermissions.No)
            //    cmdTools.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            //if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.DataAdmin) == atSecurity.SecurityManager.ExPermissions.No)
            //    cmdTables.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            //if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.AppSetting) == atSecurity.SecurityManager.ExPermissions.No)
            //    cmdSettings.Enabled = Janus.Windows.UI.InheritableBoolean.False;


        }
        public bool verifyOpenForm(string formName)
        {
            bool isOpen = false;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == formName) //form is open, activate it
                {
                    childForm.Activate();
                    //childForm.WindowState = FormWindowState.Maximized;
                    isOpen=true;
                    return isOpen;
                }
            }
            return isOpen;
        }

        public void DoSetWFCoords(Point pt)
        {
            uiStatusBar1.Panels["WFCoords"].Text = "X: " + pt.X + " | Y: " + pt.Y;
        }

        private void LaunchWorkflowDesigner()
        {
            if (!verifyOpenForm("fSeries"))
            {
                using (fWait fProgress = new fWait("Loading Workflow Designer, please wait"))
                {
                    fSeries f = new fSeries(this);
                    f.Show();
                    f.WindowState = FormWindowState.Maximized;
                    WorkflowDesigner = f;
                }
            }
        }

        public void MoreInfoSeries(int SeriesId)
        {
            LaunchWorkflowDesigner();
            WorkflowDesigner.MoreInfoSeries(SeriesId);
        }

        public void MoreInfoACSeries(int SeriesId, int ACSeriesId)
        {
            MoreInfoSeries(SeriesId);
            WorkflowDesigner.MoreInfoACSeries(ACSeriesId);
        }

        public void MoreInfoRelField(int seriesId, int acseriesId, int activityfieldId)
        {
            MoreInfoACSeries(seriesId, acseriesId);
            WorkflowDesigner.MoreInfoRelField(activityfieldId);
        }


        //private void dumpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.saveFileDialog1.ShowDialog();
        //        string file = this.saveFileDialog1.FileName;


        //        Atmng.acMng.DB.WriteXml(file);//, XmlWriteMode.WriteSchema);
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }

        //}

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    if (MdiChildren.Length > 0)
        //    {
        //        if (MessageBox.Show("All screens must be closed in order to reload the configuration data.\nIf you made any edits and want to save your changes before refreshing the data, please cancel this dialog by selecting No, save your changes, then refresh the config data.\n\nAre you sure you want to refresh the config data and close all screens automatically?", "Refresh Configuration Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //        {
        //            foreach (Form childForm in MdiChildren)
        //            {
        //                childForm.Close();
        //            }
        //            atmng.acMng.LoadAllConfigInfo();
        //            atmng.LoadDDInfo();

        //        }
        //    }
        //    else
        //    {
        //        atmng.acMng.LoadAllConfigInfo();
        //        atmng.LoadDDInfo();
        //    }
        //}


        //private void examineToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("This will erase all pending changes.  Do not edit data after examining.", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            this.openFileDialog1.ShowDialog();
        //            string file = this.openFileDialog1.FileName;

        //            Atmng.acMng.DB.Clear();
        //            foreach (DataTable dt in Atmng.acMng.DB.Tables)
        //            {
        //                dt.BeginLoadData();
        //            }
        //            Atmng.acMng.isMerging = true;
        //            Atmng.acMng.DB.ReadXml(file);//, XmlReadMode.ReadSchema);
        //            Atmng.acMng.isMerging = false;
        //            foreach (DataTable dt in Atmng.acMng.DB.Tables)
        //            {
        //                dt.EndLoadData();
        //            }
        //            Atmng.acMng.DB.AcceptChanges();

        //        }

        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }

        //}

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            Application.UseWaitCursor=true;

            try
            {
                switch (e.Command.Key)
                {
                    case "cmdArchive":
                        if (!verifyOpenForm("fArchive"))
                        {
                            fArchive f = new fArchive(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdSystemMessages":
                        if (!verifyOpenForm("fSystemMessage"))
                        {
                            fSystemMessage f = new fSystemMessage(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdExportDocs":
                          fExportDocs fexp = new fExportDocs(this);
                          fexp.Show();
                          fexp.WindowState = FormWindowState.Maximized;
                        break;
                    case "cmdConfigSync":
                        fConfigSync fcsy = new fConfigSync(this);
                        fcsy.Show();
                        fcsy.WindowState = FormWindowState.Maximized;
                        break;
                    case "cmdWWHelp":
                        using (fWait fProgress = new fWait("Loading Deskbook Data, please wait"))
                        {
                            fHelp fh = new fHelp(this);
                            fh.Show();
                            fh.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdClose":
                             if (ActiveMdiChild != null)
                                ActiveMdiChild.Close();
                            break;
                    case "cmdExit":
                        this.Close();
                        break;
                    case "cmdAppSettings":
                        if (!verifyOpenForm("fAppSetting"))
                        {
                            fAppSetting f = new fAppSetting(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdReportAdmin":
                        using (fWait fProgress = new fWait("Loading Report Admin Module, please wait"))
                        {
                            if (!verifyOpenForm("fReportAdmin"))
                            {
                                fReportAdmin f = new fReportAdmin(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdActivityCode":
                        using (fWait fProgress = new fWait("Loading Activity Code Templates, please wait"))
                        {
                            if (!verifyOpenForm("fACTemplate"))
                            {
                                fACTemplate f = new fACTemplate(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdCity":
                        if (!verifyOpenForm("fCity"))
                        {
                            fCity f = new fCity(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdPLOffice":
                        using (fWait fProgress = new fWait("Loading Office File Distribution Data, please wait"))
                        {
                            if (!verifyOpenForm("fPLOffice"))
                            {
                                fPLOffice f = new fPLOffice(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdBatchReview":
                        using (fWait fProgress = new fWait("Loading Batch Job Data, please wait"))
                        {
                            if (!verifyOpenForm("fBatch"))
                            {
                                fBatch f = new fBatch(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdProvinces":
                        if (!verifyOpenForm("fProvinces"))
                        {
                            fProvinces f = new fProvinces(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdDocTemplates":
                        using (fWait fProgress = new fWait("Loading Document Templates, please wait"))
                        {
                            if (!verifyOpenForm("fTemplates"))
                            {
                                fTemplates f = new fTemplates(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdLookupTables":
                        using (fWait fProgress = new fWait("Loading Lookup Table Data, please wait"))
                        {
                            if (!verifyOpenForm("fLookup"))
                            {
                                fLookup f = new fLookup(this, true);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdLookupTablesAll":
                        using (fWait fProgress = new fWait("Loading Lookup Table Data, please wait"))
                        {
                            if (!verifyOpenForm("fLookup"))
                            {
                                fLookup f = new fLookup(this, false);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdOfficeToJD":
                        if (!verifyOpenForm("fOfficeToJudicialDistrict"))
                        {
                            fOfficeToJudicialDistrict f = new fOfficeToJudicialDistrict(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdWFDesigner":
                        LaunchWorkflowDesigner();
                        break;
                    case "cmdAdhocQuery":
                        fSQL fsql = new fSQL(this);
                        fsql.Show();
                        fsql.WindowState = FormWindowState.Maximized;
                        break;
                    case "cmdBFTemplates":
                        using (fWait fProgress = new fWait("Loading BF Template Data, please wait"))
                        {
                            if (!verifyOpenForm("fBFCode"))
                            {
                                fBFCode f = new fBFCode(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdIssues":
                        using (fWait fProgress = new fWait("Loading Issues, please wait"))
                        {
                            if (!verifyOpenForm("fIssues"))
                            {
                                fIssues f = new fIssues(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdOfficeMandates":
                        if (!verifyOpenForm("fOfficeMandate"))
                        {
                            fOfficeMandate f = new fOfficeMandate(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }        
                        break;
                    case "cmdDataDictionnary":
                        using (fWait fProgress = new fWait("Loading Data Dictionnary Data, please wait"))
                        {
                            if (!verifyOpenForm("fDataDictionnary"))
                            {
                                fDataDictionnary f = new fDataDictionnary(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdDDLookup":
                        using (fWait fProgress = new fWait("Loading DD Lookup, please wait"))
                        {
                            if (!verifyOpenForm("fDDLookup"))
                            {
                                fDDLookup f = new fDDLookup(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdSecRules":
                        using (fWait fProgress = new fWait("Loading Security Rules Data, please wait"))
                        {
                            if (!verifyOpenForm("fRules"))
                            {
                                fRules f = new fRules(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdGroups":
                        using (fWait fProgress = new fWait("Loading Security Groups Data, please wait"))
                        {
                            if (!verifyOpenForm("fGroups"))
                            {
                                fGroups f = new fGroups(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdDistList":
                        if (!verifyOpenForm("fDistributionList"))
                        {
                            fDistributionList f = new fDistributionList(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }    
                        break;
                    case "cmdImportExternalDocs":
                         fLoad fl = new fLoad(this);
                        fl.Show();
                        fl.WindowState = FormWindowState.Maximized;
                        break;
                    case "cmdACMenu":
                        if (!verifyOpenForm("fACMenu"))
                        {
                            fACMenu f = new fACMenu(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }    
                        break;
                    case "cmdPeriodicFileClosure":
                        if (!verifyOpenForm("fClose"))
                        {
                            fClose f = new fClose(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                    case "cmdFileMetaType":
                        if (!verifyOpenForm("fFileMetaChildren"))
                        {
                            fFileMetaChildren f = new fFileMetaChildren(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }    
                        break;
                    case "cmdOfficerPrefs":
                        using (fWait fProgress = new fWait("Loading Officer Preferences Data, please wait"))
                        {
                            if (!verifyOpenForm("fOfficerPreferences"))
                            {
                                fOfficerPreferences f = new fOfficerPreferences(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdEventLog":
                        using (fWait fProgress = new fWait("Loading Log Event Data, please wait"))
                        {
                            if (!verifyOpenForm("fLogEvent"))
                            {
                                fLogEvent f = new fLogEvent(this);
                                f.Show();
                                f.WindowState = FormWindowState.Maximized;
                            }
                        }
                        break;
                    case "cmdLegislation":
                        if (!verifyOpenForm("fLegislation"))
                        {
                            fLegislation f = new fLegislation(this);
                            f.Show();
                            f.WindowState = FormWindowState.Maximized;
                        }
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally
            {
                Application.UseWaitCursor=false;
            }

        }

    }
}
