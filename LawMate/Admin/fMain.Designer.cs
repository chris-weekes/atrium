 namespace LawMate.Admin
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                try
                {
                    ////delete temp file folder
                    //string temp = Atmng.GetFile().GetDocMng().GetDocContent().GetTempPath(null);
                    //if (System.IO.Directory.Exists(temp))
                    //{
                    //    System.IO.Directory.Delete(temp, true);
                    //}
                }
                catch (System.Exception x)
                {
                    //UIHelper.HandleUIException(x);
                }
                //Atmng.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.Common.JanusColorScheme janusColorScheme2 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdWorkflow1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWorkflow");
            this.cmdTables1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTables");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.cmdSecurity1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSecurity");
            this.cmdSettings1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSettings");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdClose1 = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.cmdExit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdWorkflow = new Janus.Windows.UI.CommandBars.UICommand("cmdWorkflow");
            this.cmdWFDesigner1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWFDesigner");
            this.cmdActivityCode1 = new Janus.Windows.UI.CommandBars.UICommand("cmdActivityCode");
            this.cmdBFTemplates1 = new Janus.Windows.UI.CommandBars.UICommand("cmdBFTemplates");
            this.cmdDocTemplates1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocTemplates");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdOfficeMandates1 = new Janus.Windows.UI.CommandBars.UICommand("cmdOfficeMandates");
            this.cmdACMenu2 = new Janus.Windows.UI.CommandBars.UICommand("cmdACMenu");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdConfigSync2 = new Janus.Windows.UI.CommandBars.UICommand("cmdConfigSync");
            this.cmdReloadConfig2 = new Janus.Windows.UI.CommandBars.UICommand("cmdReloadConfig");
            this.cmdTables = new Janus.Windows.UI.CommandBars.UICommand("cmdTables");
            this.cmdLookupTablesAll1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLookupTablesAll");
            this.cmdLookupTables1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLookupTables");
            this.cmdFileMetaType1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFileMetaType");
            this.cmdIssues1 = new Janus.Windows.UI.CommandBars.UICommand("cmdIssues");
            this.cmdLegislation1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLegislation");
            this.cmdDistList1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDistList");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdProvinces1 = new Janus.Windows.UI.CommandBars.UICommand("cmdProvinces");
            this.cmdCity1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCity");
            this.cmdOfficeToJD1 = new Janus.Windows.UI.CommandBars.UICommand("cmdOfficeToJD");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDataDictionnary1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDataDictionnary");
            this.cmdDDLookup1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDDLookup");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.cmdAdhocQuery1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdhocQuery");
            this.cmdImportExternalDocs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdImportExternalDocs");
            this.cmdExportDocs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExportDocs");
            this.cmdPeriodicFileClosure1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPeriodicFileClosure");
            this.cmdEventLog1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEventLog");
            this.cmdPLOffice1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPLOffice");
            this.cmdBatchReview1 = new Janus.Windows.UI.CommandBars.UICommand("cmdBatchReview");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdWWHelp1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWWHelp");
            this.cmdExit = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdWFDesigner = new Janus.Windows.UI.CommandBars.UICommand("cmdWFDesigner");
            this.cmdActivityCode = new Janus.Windows.UI.CommandBars.UICommand("cmdActivityCode");
            this.cmdBFTemplates = new Janus.Windows.UI.CommandBars.UICommand("cmdBFTemplates");
            this.cmdDocTemplates = new Janus.Windows.UI.CommandBars.UICommand("cmdDocTemplates");
            this.cmdOfficeMandates = new Janus.Windows.UI.CommandBars.UICommand("cmdOfficeMandates");
            this.cmdACMenu = new Janus.Windows.UI.CommandBars.UICommand("cmdACMenu");
            this.cmdDistList = new Janus.Windows.UI.CommandBars.UICommand("cmdDistList");
            this.cmdIssues = new Janus.Windows.UI.CommandBars.UICommand("cmdIssues");
            this.cmdCity = new Janus.Windows.UI.CommandBars.UICommand("cmdCity");
            this.cmdLookupTables = new Janus.Windows.UI.CommandBars.UICommand("cmdLookupTables");
            this.cmdFileMetaType = new Janus.Windows.UI.CommandBars.UICommand("cmdFileMetaType");
            this.cmdProvinces = new Janus.Windows.UI.CommandBars.UICommand("cmdProvinces");
            this.cmdOfficeToJD = new Janus.Windows.UI.CommandBars.UICommand("cmdOfficeToJD");
            this.cmdBatchReview = new Janus.Windows.UI.CommandBars.UICommand("cmdBatchReview");
            this.cmdOfficerPrefs = new Janus.Windows.UI.CommandBars.UICommand("cmdOfficerPrefs");
            this.cmdImportExternalDocs = new Janus.Windows.UI.CommandBars.UICommand("cmdImportExternalDocs");
            this.cmdPLOffice = new Janus.Windows.UI.CommandBars.UICommand("cmdPLOffice");
            this.cmdPeriodicFileClosure = new Janus.Windows.UI.CommandBars.UICommand("cmdPeriodicFileClosure");
            this.cmdReportAdmin = new Janus.Windows.UI.CommandBars.UICommand("cmdReportAdmin");
            this.cmdEventLog = new Janus.Windows.UI.CommandBars.UICommand("cmdEventLog");
            this.cmdAdhocQuery = new Janus.Windows.UI.CommandBars.UICommand("cmdAdhocQuery");
            this.cmdSecurity = new Janus.Windows.UI.CommandBars.UICommand("cmdSecurity");
            this.cmdGroups1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGroups");
            this.cmdSecRules1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSecRules");
            this.cmdGroups = new Janus.Windows.UI.CommandBars.UICommand("cmdGroups");
            this.cmdSecRules = new Janus.Windows.UI.CommandBars.UICommand("cmdSecRules");
            this.cmdReloadConfig = new Janus.Windows.UI.CommandBars.UICommand("cmdReloadConfig");
            this.cmdAppSettings = new Janus.Windows.UI.CommandBars.UICommand("cmdAppSettings");
            this.cmdLegislation = new Janus.Windows.UI.CommandBars.UICommand("cmdLegislation");
            this.cmdWWHelp = new Janus.Windows.UI.CommandBars.UICommand("cmdWWHelp");
            this.cmdConfigSync = new Janus.Windows.UI.CommandBars.UICommand("cmdConfigSync");
            this.cmdExportDocs = new Janus.Windows.UI.CommandBars.UICommand("cmdExportDocs");
            this.cmdSettings = new Janus.Windows.UI.CommandBars.UICommand("cmdSettings");
            this.cmdAppSettings2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAppSettings");
            this.cmdOfficerPrefs2 = new Janus.Windows.UI.CommandBars.UICommand("cmdOfficerPrefs");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSystemMessages1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSystemMessages");
            this.cmdClose = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.cmdDataDictionnary = new Janus.Windows.UI.CommandBars.UICommand("cmdDataDictionnary");
            this.cmdDDLookup = new Janus.Windows.UI.CommandBars.UICommand("cmdDDLookup");
            this.cmdSystemMessages = new Janus.Windows.UI.CommandBars.UICommand("cmdSystemMessages");
            this.cmdLookupTablesAll = new Janus.Windows.UI.CommandBars.UICommand("cmdLookupTablesAll");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.cmdArchive = new Janus.Windows.UI.CommandBars.UICommand("cmdArchive");
            this.cmdArchive1 = new Janus.Windows.UI.CommandBars.UICommand("cmdArchive");
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.BackColorAutoHideStrip = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.BackColorGradientResizeBar = System.Drawing.SystemColors.ControlDark;
            this.uiPanelManager1.BackColorResizeBar = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            resources.ApplyResources(this.uiPanelManager1, "uiPanelManager1");
            this.uiPanelManager1.TabbedMdiSettings.DockingStyleMode = Janus.Windows.UI.Dock.DockingStyleMode.Standard;
            this.uiPanelManager1.TabbedMdiSettings.ShowCloseButtonOnSelectedTab = true;
            this.uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming = ((System.Drawing.StringTrimming)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming")));
            this.uiPanelManager1.TabbedMdiSettings.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.VisualStyleManager = this.visualStyleManager1;
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme1";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2010;
            janusColorScheme2.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme2.Name = "Scheme2";
            janusColorScheme2.OfficeColorScheme = Janus.Windows.Common.OfficeColorScheme.Custom;
            janusColorScheme2.OfficeCustomColor = System.Drawing.Color.SlateGray;
            janusColorScheme2.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme2);
            this.visualStyleManager1.DefaultColorScheme = "Scheme1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "workflow.gif");
            this.imageList1.Images.SetKeyName(1, "icon_pen.gif");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile,
            this.cmdWorkflow,
            this.cmdTables,
            this.cmdTools,
            this.cmdExit,
            this.cmdWFDesigner,
            this.cmdActivityCode,
            this.cmdBFTemplates,
            this.cmdDocTemplates,
            this.cmdOfficeMandates,
            this.cmdACMenu,
            this.cmdDistList,
            this.cmdIssues,
            this.cmdCity,
            this.cmdLookupTables,
            this.cmdFileMetaType,
            this.cmdProvinces,
            this.cmdOfficeToJD,
            this.cmdBatchReview,
            this.cmdOfficerPrefs,
            this.cmdImportExternalDocs,
            this.cmdPLOffice,
            this.cmdPeriodicFileClosure,
            this.cmdReportAdmin,
            this.cmdEventLog,
            this.cmdAdhocQuery,
            this.cmdSecurity,
            this.cmdGroups,
            this.cmdSecRules,
            this.cmdReloadConfig,
            this.cmdAppSettings,
            this.cmdLegislation,
            this.cmdWWHelp,
            this.cmdConfigSync,
            this.cmdExportDocs,
            this.cmdSettings,
            this.cmdClose,
            this.cmdDataDictionnary,
            this.cmdDDLookup,
            this.cmdSystemMessages,
            this.cmdLookupTablesAll,
            this.cmdArchive});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("171e3c6f-3dca-475d-959b-3b964501f0c2");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.VisualStyleManager = this.visualStyleManager1;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdWorkflow1,
            this.cmdTables1,
            this.cmdTools1,
            this.cmdSecurity1,
            this.cmdSettings1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdWorkflow1
            // 
            resources.ApplyResources(this.cmdWorkflow1, "cmdWorkflow1");
            this.cmdWorkflow1.Name = "cmdWorkflow1";
            // 
            // cmdTables1
            // 
            resources.ApplyResources(this.cmdTables1, "cmdTables1");
            this.cmdTables1.Name = "cmdTables1";
            // 
            // cmdTools1
            // 
            resources.ApplyResources(this.cmdTools1, "cmdTools1");
            this.cmdTools1.Name = "cmdTools1";
            // 
            // cmdSecurity1
            // 
            resources.ApplyResources(this.cmdSecurity1, "cmdSecurity1");
            this.cmdSecurity1.Name = "cmdSecurity1";
            // 
            // cmdSettings1
            // 
            resources.ApplyResources(this.cmdSettings1, "cmdSettings1");
            this.cmdSettings1.Name = "cmdSettings1";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdClose1,
            this.cmdExit1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdClose1
            // 
            resources.ApplyResources(this.cmdClose1, "cmdClose1");
            this.cmdClose1.Name = "cmdClose1";
            // 
            // cmdExit1
            // 
            resources.ApplyResources(this.cmdExit1, "cmdExit1");
            this.cmdExit1.Name = "cmdExit1";
            // 
            // cmdWorkflow
            // 
            this.cmdWorkflow.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdWFDesigner1,
            this.cmdActivityCode1,
            this.cmdBFTemplates1,
            this.cmdDocTemplates1,
            this.Separator6,
            this.cmdOfficeMandates1,
            this.cmdACMenu2,
            this.Separator7,
            this.cmdConfigSync2,
            this.cmdReloadConfig2});
            resources.ApplyResources(this.cmdWorkflow, "cmdWorkflow");
            this.cmdWorkflow.Name = "cmdWorkflow";
            // 
            // cmdWFDesigner1
            // 
            resources.ApplyResources(this.cmdWFDesigner1, "cmdWFDesigner1");
            this.cmdWFDesigner1.Name = "cmdWFDesigner1";
            // 
            // cmdActivityCode1
            // 
            resources.ApplyResources(this.cmdActivityCode1, "cmdActivityCode1");
            this.cmdActivityCode1.Name = "cmdActivityCode1";
            // 
            // cmdBFTemplates1
            // 
            resources.ApplyResources(this.cmdBFTemplates1, "cmdBFTemplates1");
            this.cmdBFTemplates1.Name = "cmdBFTemplates1";
            // 
            // cmdDocTemplates1
            // 
            resources.ApplyResources(this.cmdDocTemplates1, "cmdDocTemplates1");
            this.cmdDocTemplates1.Name = "cmdDocTemplates1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdOfficeMandates1
            // 
            resources.ApplyResources(this.cmdOfficeMandates1, "cmdOfficeMandates1");
            this.cmdOfficeMandates1.Name = "cmdOfficeMandates1";
            // 
            // cmdACMenu2
            // 
            resources.ApplyResources(this.cmdACMenu2, "cmdACMenu2");
            this.cmdACMenu2.Name = "cmdACMenu2";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // cmdConfigSync2
            // 
            resources.ApplyResources(this.cmdConfigSync2, "cmdConfigSync2");
            this.cmdConfigSync2.Name = "cmdConfigSync2";
            // 
            // cmdReloadConfig2
            // 
            resources.ApplyResources(this.cmdReloadConfig2, "cmdReloadConfig2");
            this.cmdReloadConfig2.Name = "cmdReloadConfig2";
            // 
            // cmdTables
            // 
            this.cmdTables.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdLookupTablesAll1,
            this.cmdLookupTables1,
            this.cmdFileMetaType1,
            this.cmdIssues1,
            this.cmdLegislation1,
            this.cmdDistList1,
            this.Separator4,
            this.cmdProvinces1,
            this.cmdCity1,
            this.cmdOfficeToJD1,
            this.Separator5,
            this.cmdDataDictionnary1,
            this.cmdDDLookup1});
            resources.ApplyResources(this.cmdTables, "cmdTables");
            this.cmdTables.Name = "cmdTables";
            // 
            // cmdLookupTablesAll1
            // 
            resources.ApplyResources(this.cmdLookupTablesAll1, "cmdLookupTablesAll1");
            this.cmdLookupTablesAll1.Name = "cmdLookupTablesAll1";
            // 
            // cmdLookupTables1
            // 
            resources.ApplyResources(this.cmdLookupTables1, "cmdLookupTables1");
            this.cmdLookupTables1.Name = "cmdLookupTables1";
            // 
            // cmdFileMetaType1
            // 
            resources.ApplyResources(this.cmdFileMetaType1, "cmdFileMetaType1");
            this.cmdFileMetaType1.Name = "cmdFileMetaType1";
            // 
            // cmdIssues1
            // 
            resources.ApplyResources(this.cmdIssues1, "cmdIssues1");
            this.cmdIssues1.Name = "cmdIssues1";
            // 
            // cmdLegislation1
            // 
            resources.ApplyResources(this.cmdLegislation1, "cmdLegislation1");
            this.cmdLegislation1.Name = "cmdLegislation1";
            // 
            // cmdDistList1
            // 
            resources.ApplyResources(this.cmdDistList1, "cmdDistList1");
            this.cmdDistList1.Name = "cmdDistList1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdProvinces1
            // 
            resources.ApplyResources(this.cmdProvinces1, "cmdProvinces1");
            this.cmdProvinces1.Name = "cmdProvinces1";
            // 
            // cmdCity1
            // 
            resources.ApplyResources(this.cmdCity1, "cmdCity1");
            this.cmdCity1.Name = "cmdCity1";
            // 
            // cmdOfficeToJD1
            // 
            resources.ApplyResources(this.cmdOfficeToJD1, "cmdOfficeToJD1");
            this.cmdOfficeToJD1.Name = "cmdOfficeToJD1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdDataDictionnary1
            // 
            resources.ApplyResources(this.cmdDataDictionnary1, "cmdDataDictionnary1");
            this.cmdDataDictionnary1.Name = "cmdDataDictionnary1";
            // 
            // cmdDDLookup1
            // 
            resources.ApplyResources(this.cmdDDLookup1, "cmdDDLookup1");
            this.cmdDDLookup1.Name = "cmdDDLookup1";
            // 
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAdhocQuery1,
            this.cmdImportExternalDocs1,
            this.cmdExportDocs1,
            this.cmdPeriodicFileClosure1,
            this.cmdEventLog1,
            this.cmdPLOffice1,
            this.cmdBatchReview1,
            this.cmdArchive1,
            this.Separator3,
            this.cmdWWHelp1});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.Name = "cmdTools";
            // 
            // cmdAdhocQuery1
            // 
            resources.ApplyResources(this.cmdAdhocQuery1, "cmdAdhocQuery1");
            this.cmdAdhocQuery1.Name = "cmdAdhocQuery1";
            // 
            // cmdImportExternalDocs1
            // 
            resources.ApplyResources(this.cmdImportExternalDocs1, "cmdImportExternalDocs1");
            this.cmdImportExternalDocs1.Name = "cmdImportExternalDocs1";
            // 
            // cmdExportDocs1
            // 
            resources.ApplyResources(this.cmdExportDocs1, "cmdExportDocs1");
            this.cmdExportDocs1.Name = "cmdExportDocs1";
            // 
            // cmdPeriodicFileClosure1
            // 
            resources.ApplyResources(this.cmdPeriodicFileClosure1, "cmdPeriodicFileClosure1");
            this.cmdPeriodicFileClosure1.Name = "cmdPeriodicFileClosure1";
            // 
            // cmdEventLog1
            // 
            resources.ApplyResources(this.cmdEventLog1, "cmdEventLog1");
            this.cmdEventLog1.Name = "cmdEventLog1";
            // 
            // cmdPLOffice1
            // 
            resources.ApplyResources(this.cmdPLOffice1, "cmdPLOffice1");
            this.cmdPLOffice1.Name = "cmdPLOffice1";
            // 
            // cmdBatchReview1
            // 
            resources.ApplyResources(this.cmdBatchReview1, "cmdBatchReview1");
            this.cmdBatchReview1.Name = "cmdBatchReview1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdWWHelp1
            // 
            resources.ApplyResources(this.cmdWWHelp1, "cmdWWHelp1");
            this.cmdWWHelp1.Name = "cmdWWHelp1";
            // 
            // cmdExit
            // 
            resources.ApplyResources(this.cmdExit, "cmdExit");
            this.cmdExit.Name = "cmdExit";
            // 
            // cmdWFDesigner
            // 
            resources.ApplyResources(this.cmdWFDesigner, "cmdWFDesigner");
            this.cmdWFDesigner.Name = "cmdWFDesigner";
            // 
            // cmdActivityCode
            // 
            resources.ApplyResources(this.cmdActivityCode, "cmdActivityCode");
            this.cmdActivityCode.Name = "cmdActivityCode";
            // 
            // cmdBFTemplates
            // 
            resources.ApplyResources(this.cmdBFTemplates, "cmdBFTemplates");
            this.cmdBFTemplates.Name = "cmdBFTemplates";
            // 
            // cmdDocTemplates
            // 
            resources.ApplyResources(this.cmdDocTemplates, "cmdDocTemplates");
            this.cmdDocTemplates.Name = "cmdDocTemplates";
            // 
            // cmdOfficeMandates
            // 
            resources.ApplyResources(this.cmdOfficeMandates, "cmdOfficeMandates");
            this.cmdOfficeMandates.Name = "cmdOfficeMandates";
            // 
            // cmdACMenu
            // 
            resources.ApplyResources(this.cmdACMenu, "cmdACMenu");
            this.cmdACMenu.Name = "cmdACMenu";
            // 
            // cmdDistList
            // 
            resources.ApplyResources(this.cmdDistList, "cmdDistList");
            this.cmdDistList.Name = "cmdDistList";
            // 
            // cmdIssues
            // 
            resources.ApplyResources(this.cmdIssues, "cmdIssues");
            this.cmdIssues.Name = "cmdIssues";
            // 
            // cmdCity
            // 
            resources.ApplyResources(this.cmdCity, "cmdCity");
            this.cmdCity.Name = "cmdCity";
            // 
            // cmdLookupTables
            // 
            resources.ApplyResources(this.cmdLookupTables, "cmdLookupTables");
            this.cmdLookupTables.Name = "cmdLookupTables";
            // 
            // cmdFileMetaType
            // 
            resources.ApplyResources(this.cmdFileMetaType, "cmdFileMetaType");
            this.cmdFileMetaType.Name = "cmdFileMetaType";
            // 
            // cmdProvinces
            // 
            resources.ApplyResources(this.cmdProvinces, "cmdProvinces");
            this.cmdProvinces.Name = "cmdProvinces";
            // 
            // cmdOfficeToJD
            // 
            resources.ApplyResources(this.cmdOfficeToJD, "cmdOfficeToJD");
            this.cmdOfficeToJD.Name = "cmdOfficeToJD";
            // 
            // cmdBatchReview
            // 
            resources.ApplyResources(this.cmdBatchReview, "cmdBatchReview");
            this.cmdBatchReview.Name = "cmdBatchReview";
            // 
            // cmdOfficerPrefs
            // 
            resources.ApplyResources(this.cmdOfficerPrefs, "cmdOfficerPrefs");
            this.cmdOfficerPrefs.Name = "cmdOfficerPrefs";
            // 
            // cmdImportExternalDocs
            // 
            resources.ApplyResources(this.cmdImportExternalDocs, "cmdImportExternalDocs");
            this.cmdImportExternalDocs.Name = "cmdImportExternalDocs";
            // 
            // cmdPLOffice
            // 
            resources.ApplyResources(this.cmdPLOffice, "cmdPLOffice");
            this.cmdPLOffice.Name = "cmdPLOffice";
            // 
            // cmdPeriodicFileClosure
            // 
            resources.ApplyResources(this.cmdPeriodicFileClosure, "cmdPeriodicFileClosure");
            this.cmdPeriodicFileClosure.Name = "cmdPeriodicFileClosure";
            // 
            // cmdReportAdmin
            // 
            resources.ApplyResources(this.cmdReportAdmin, "cmdReportAdmin");
            this.cmdReportAdmin.Name = "cmdReportAdmin";
            // 
            // cmdEventLog
            // 
            resources.ApplyResources(this.cmdEventLog, "cmdEventLog");
            this.cmdEventLog.Name = "cmdEventLog";
            // 
            // cmdAdhocQuery
            // 
            resources.ApplyResources(this.cmdAdhocQuery, "cmdAdhocQuery");
            this.cmdAdhocQuery.Name = "cmdAdhocQuery";
            // 
            // cmdSecurity
            // 
            this.cmdSecurity.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdGroups1,
            this.cmdSecRules1});
            resources.ApplyResources(this.cmdSecurity, "cmdSecurity");
            this.cmdSecurity.Name = "cmdSecurity";
            // 
            // cmdGroups1
            // 
            resources.ApplyResources(this.cmdGroups1, "cmdGroups1");
            this.cmdGroups1.Name = "cmdGroups1";
            // 
            // cmdSecRules1
            // 
            resources.ApplyResources(this.cmdSecRules1, "cmdSecRules1");
            this.cmdSecRules1.Name = "cmdSecRules1";
            // 
            // cmdGroups
            // 
            resources.ApplyResources(this.cmdGroups, "cmdGroups");
            this.cmdGroups.Name = "cmdGroups";
            // 
            // cmdSecRules
            // 
            resources.ApplyResources(this.cmdSecRules, "cmdSecRules");
            this.cmdSecRules.Name = "cmdSecRules";
            // 
            // cmdReloadConfig
            // 
            resources.ApplyResources(this.cmdReloadConfig, "cmdReloadConfig");
            this.cmdReloadConfig.Name = "cmdReloadConfig";
            // 
            // cmdAppSettings
            // 
            resources.ApplyResources(this.cmdAppSettings, "cmdAppSettings");
            this.cmdAppSettings.Name = "cmdAppSettings";
            // 
            // cmdLegislation
            // 
            resources.ApplyResources(this.cmdLegislation, "cmdLegislation");
            this.cmdLegislation.Name = "cmdLegislation";
            // 
            // cmdWWHelp
            // 
            resources.ApplyResources(this.cmdWWHelp, "cmdWWHelp");
            this.cmdWWHelp.Name = "cmdWWHelp";
            // 
            // cmdConfigSync
            // 
            resources.ApplyResources(this.cmdConfigSync, "cmdConfigSync");
            this.cmdConfigSync.Name = "cmdConfigSync";
            // 
            // cmdExportDocs
            // 
            resources.ApplyResources(this.cmdExportDocs, "cmdExportDocs");
            this.cmdExportDocs.Name = "cmdExportDocs";
            // 
            // cmdSettings
            // 
            this.cmdSettings.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAppSettings2,
            this.cmdOfficerPrefs2,
            this.Separator1,
            this.cmdSystemMessages1});
            resources.ApplyResources(this.cmdSettings, "cmdSettings");
            this.cmdSettings.Name = "cmdSettings";
            // 
            // cmdAppSettings2
            // 
            resources.ApplyResources(this.cmdAppSettings2, "cmdAppSettings2");
            this.cmdAppSettings2.Name = "cmdAppSettings2";
            // 
            // cmdOfficerPrefs2
            // 
            resources.ApplyResources(this.cmdOfficerPrefs2, "cmdOfficerPrefs2");
            this.cmdOfficerPrefs2.Name = "cmdOfficerPrefs2";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdSystemMessages1
            // 
            resources.ApplyResources(this.cmdSystemMessages1, "cmdSystemMessages1");
            this.cmdSystemMessages1.Name = "cmdSystemMessages1";
            // 
            // cmdClose
            // 
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Name = "cmdClose";
            // 
            // cmdDataDictionnary
            // 
            resources.ApplyResources(this.cmdDataDictionnary, "cmdDataDictionnary");
            this.cmdDataDictionnary.Name = "cmdDataDictionnary";
            // 
            // cmdDDLookup
            // 
            resources.ApplyResources(this.cmdDDLookup, "cmdDDLookup");
            this.cmdDDLookup.Name = "cmdDDLookup";
            // 
            // cmdSystemMessages
            // 
            resources.ApplyResources(this.cmdSystemMessages, "cmdSystemMessages");
            this.cmdSystemMessages.Name = "cmdSystemMessages";
            // 
            // cmdLookupTablesAll
            // 
            resources.ApplyResources(this.cmdLookupTablesAll, "cmdLookupTablesAll");
            this.cmdLookupTablesAll.Name = "cmdLookupTablesAll";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // uiStatusBar1
            // 
            resources.ApplyResources(this.uiStatusBar1, "uiStatusBar1");
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Black;
            uiStatusBarPanel1.Key = "WFCoords";
            resources.ApplyResources(uiStatusBarPanel1, "uiStatusBarPanel1");
            resources.ApplyResources(uiStatusBarPanel2, "uiStatusBarPanel2");
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "";
            resources.ApplyResources(uiStatusBarPanel3, "uiStatusBarPanel3");
            uiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "sbPnlAdminName";
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2,
            uiStatusBarPanel3});
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiStatusBar1.VisualStyleManager = this.visualStyleManager1;
            // 
            // cmdArchive
            // 
            resources.ApplyResources(this.cmdArchive, "cmdArchive");
            this.cmdArchive.Name = "cmdArchive";
            // 
            // cmdArchive1
            // 
            resources.ApplyResources(this.cmdArchive1, "cmdArchive1");
            this.cmdArchive1.Name = "cmdArchive1";
            // 
            // fMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.TopRebar1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.Name = "fMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip ToolTip;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWorkflow1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTables1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdWorkflow;
        private Janus.Windows.UI.CommandBars.UICommand cmdTables;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWFDesigner1;
        private Janus.Windows.UI.CommandBars.UICommand cmdActivityCode1;
        private Janus.Windows.UI.CommandBars.UICommand cmdBFTemplates1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocTemplates1;
        private Janus.Windows.UI.CommandBars.UICommand cmdOfficeMandates1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDistList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdIssues1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCity1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLookupTables1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFileMetaType1;
        private Janus.Windows.UI.CommandBars.UICommand cmdProvinces1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdhocQuery1;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportExternalDocs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPeriodicFileClosure1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEventLog1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPLOffice1;
        private Janus.Windows.UI.CommandBars.UICommand cmdBatchReview1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit;
        private Janus.Windows.UI.CommandBars.UICommand cmdWFDesigner;
        private Janus.Windows.UI.CommandBars.UICommand cmdActivityCode;
        private Janus.Windows.UI.CommandBars.UICommand cmdBFTemplates;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocTemplates;
        private Janus.Windows.UI.CommandBars.UICommand cmdOfficeMandates;
        private Janus.Windows.UI.CommandBars.UICommand cmdACMenu;
        private Janus.Windows.UI.CommandBars.UICommand cmdDistList;
        private Janus.Windows.UI.CommandBars.UICommand cmdIssues;
        private Janus.Windows.UI.CommandBars.UICommand cmdCity;
        private Janus.Windows.UI.CommandBars.UICommand cmdLookupTables;
        private Janus.Windows.UI.CommandBars.UICommand cmdFileMetaType;
        private Janus.Windows.UI.CommandBars.UICommand cmdProvinces;
        private Janus.Windows.UI.CommandBars.UICommand cmdOfficeToJD;
        private Janus.Windows.UI.CommandBars.UICommand cmdBatchReview;
        private Janus.Windows.UI.CommandBars.UICommand cmdOfficerPrefs;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportExternalDocs;
        private Janus.Windows.UI.CommandBars.UICommand cmdPLOffice;
        private Janus.Windows.UI.CommandBars.UICommand cmdPeriodicFileClosure;
        private Janus.Windows.UI.CommandBars.UICommand cmdReportAdmin;
        private Janus.Windows.UI.CommandBars.UICommand cmdEventLog;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdhocQuery;
        private Janus.Windows.UI.CommandBars.UICommand cmdSecurity;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroups;
        private Janus.Windows.UI.CommandBars.UICommand cmdSecRules;
        private Janus.Windows.UI.CommandBars.UICommand cmdReloadConfig;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroups1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSecRules1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdAppSettings;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLegislation1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand cmdLegislation;
        private Janus.Windows.UI.CommandBars.UICommand cmdWWHelp1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWWHelp;
        private Janus.Windows.UI.CommandBars.UICommand cmdConfigSync;
        private Janus.Windows.UI.CommandBars.UICommand cmdExportDocs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExportDocs;
        private Janus.Windows.UI.CommandBars.UICommand cmdSecurity1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSettings1;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand cmdACMenu2;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand cmdConfigSync2;
        private Janus.Windows.UI.CommandBars.UICommand cmdReloadConfig2;
        private Janus.Windows.UI.CommandBars.UICommand cmdOfficeToJD1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSettings;
        private Janus.Windows.UI.CommandBars.UICommand cmdOfficerPrefs2;
        private Janus.Windows.UI.CommandBars.UICommand cmdAppSettings2;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose1;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose;
        private Janus.Windows.UI.CommandBars.UICommand cmdDataDictionnary1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDataDictionnary;
        private Janus.Windows.UI.CommandBars.UICommand cmdDDLookup1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDDLookup;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSystemMessages1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSystemMessages;
        private Janus.Windows.UI.CommandBars.UICommand cmdLookupTablesAll1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLookupTablesAll;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.UI.CommandBars.UICommand cmdArchive1;
        private Janus.Windows.UI.CommandBars.UICommand cmdArchive;
    }
}



