 namespace LawMate
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

                //try
                //{
                //    //delete temp file folder
                //    string temp = Atmng.GetFile().GetDocMng().GetDocContent().GetTempPath(null);
                //    if (System.IO.Directory.Exists(temp))
                //    {
                //        System.IO.Directory.Delete(temp, true);
                //    }
                //}
                //catch (System.Exception x)
                //{
                //    //UIHelper.HandleUIException(x);
                //}

                AtMng.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel5 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel6 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.Common.JanusColorScheme janusColorScheme2 = new Janus.Windows.Common.JanusColorScheme();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatsNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lawMateUserGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.ImageListMain = new System.Windows.Forms.ImageList(this.components);
            this.pnlToolbar = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlToolbarContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ebWorkingAs = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnWorkingAs = new Janus.Windows.EditControls.UIButton();
            this.contextMenuWorkAs = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.cmdActions1 = new Janus.Windows.UI.CommandBars.UICommand("cmdActions");
            this.cmdWindows1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWindows");
            this.cmdHelp1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdSearchText2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchText");
            this.cmdOn2 = new Janus.Windows.UI.CommandBars.UICommand("cmdOn");
            this.cmdSearchDD2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchDD");
            this.cmdSelectedSearchOption1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectedSearchOption");
            this.cmdExecuteSearch1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExecuteSearch");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAdvancedSearch1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedSearch");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdOutlook2 = new Janus.Windows.UI.CommandBars.UICommand("cmdOutlook");
            this.cmdDocBrowser2 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocBrowser");
            this.cmdBrowseOffices1 = new Janus.Windows.UI.CommandBars.UICommand("cmdBrowseOffices");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMandateControlPopup1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMandateControlPopup");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAutoSave2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoSave");
            this.cmdGoToTimekeeping1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToTimekeeping");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMemberAssignmentTool1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMemberAssignmentTool");
            this.Separator13 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdLblWorkingAs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLblWorkingAs");
            this.cmdWorkAs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWorkAs");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdLabelHitCount1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLabelHitCount");
            this.cmdHitCountValue1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHitCountValue");
            this.cmdBoolWarning2 = new Janus.Windows.UI.CommandBars.UICommand("cmdBoolWarning");
            this.cmdBoolWarningText2 = new Janus.Windows.UI.CommandBars.UICommand("cmdBoolWarningText");
            this.Separator12 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdRemoveBoolOperators2 = new Janus.Windows.UI.CommandBars.UICommand("cmdRemoveBoolOperators");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdClose1 = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdExit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdOutlook1 = new Janus.Windows.UI.CommandBars.UICommand("cmdOutlook");
            this.cmdGoToTimekeeping2 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToTimekeeping");
            this.cmdDocBrowser1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocBrowser");
            this.cmdAdvancedSearch2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedSearch");
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdReports2 = new Janus.Windows.UI.CommandBars.UICommand("cmdReports");
            this.cmdIssues1 = new Janus.Windows.UI.CommandBars.UICommand("cmdIssues");
            this.cmdBatchReview3 = new Janus.Windows.UI.CommandBars.UICommand("cmdBatchReview");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNavPane1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNavPane");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.cmdLanguage2 = new Janus.Windows.UI.CommandBars.UICommand("cmdLanguage");
            this.cmdAutoSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoSave");
            this.cmdListenForMessages1 = new Janus.Windows.UI.CommandBars.UICommand("cmdListenForMessages");
            this.cmdPreferences1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPreferences");
            this.cmdChangePassword2 = new Janus.Windows.UI.CommandBars.UICommand("cmdChangePassword");
            this.Separator9 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdUtilities1 = new Janus.Windows.UI.CommandBars.UICommand("cmdUtilities");
            this.cmdHelp = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.cmdLSBDeskbook1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLSBDeskbook");
            this.cmdTriangle1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTriangle");
            this.cmdWhatsNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWhatsNew");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAbout1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAbout");
            this.cmdSearchText = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchText");
            this.cmdOn = new Janus.Windows.UI.CommandBars.UICommand("cmdOn");
            this.cmdSearchDD = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchDD");
            this.cmdAdvancedSearch = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedSearch");
            this.cmdAdvancedFileSearch1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedFileSearch");
            this.cmdAdvancedSearchDocs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedSearchDocs");
            this.cmdSearchOffices1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchOffices");
            this.cmdSearchContacts1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchContacts");
            this.cmdMandates = new Janus.Windows.UI.CommandBars.UICommand("cmdMandates");
            this.cmdWorkAs = new Janus.Windows.UI.CommandBars.UICommand("cmdWorkAs");
            this.cmdWAMyself2 = new Janus.Windows.UI.CommandBars.UICommand("cmdWAMyself");
            this.cmdLblWorkingAs = new Janus.Windows.UI.CommandBars.UICommand("cmdLblWorkingAs");
            this.cmdWAMyself = new Janus.Windows.UI.CommandBars.UICommand("cmdWAMyself");
            this.cmdExecuteSearch = new Janus.Windows.UI.CommandBars.UICommand("cmdExecuteSearch");
            this.cmdClose = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.cmdExit = new Janus.Windows.UI.CommandBars.UICommand("cmdExit");
            this.cmdNavPane = new Janus.Windows.UI.CommandBars.UICommand("cmdNavPane");
            this.cmdLanguage = new Janus.Windows.UI.CommandBars.UICommand("cmdLanguage");
            this.cmdEnglish1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEnglish");
            this.cmdFrench1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFrench");
            this.cmdReloadConfigData = new Janus.Windows.UI.CommandBars.UICommand("cmdReloadConfigData");
            this.cmdEnglish = new Janus.Windows.UI.CommandBars.UICommand("cmdEnglish");
            this.cmdFrench = new Janus.Windows.UI.CommandBars.UICommand("cmdFrench");
            this.cmdPreferences = new Janus.Windows.UI.CommandBars.UICommand("cmdPreferences");
            this.cmdLSBDeskbook = new Janus.Windows.UI.CommandBars.UICommand("cmdLSBDeskbook");
            this.cmdWhatsNew = new Janus.Windows.UI.CommandBars.UICommand("cmdWhatsNew");
            this.cmdAbout = new Janus.Windows.UI.CommandBars.UICommand("cmdAbout");
            this.cmdDocBrowser = new Janus.Windows.UI.CommandBars.UICommand("cmdDocBrowser");
            this.cmdChangePassword = new Janus.Windows.UI.CommandBars.UICommand("cmdChangePassword");
            this.cmdReports = new Janus.Windows.UI.CommandBars.UICommand("cmdReports");
            this.cmdBatchReview = new Janus.Windows.UI.CommandBars.UICommand("cmdBatchReview");
            this.cmdUtilities = new Janus.Windows.UI.CommandBars.UICommand("cmdUtilities");
            this.cmdAdmin1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdmin");
            this.cmdReloadConfigData3 = new Janus.Windows.UI.CommandBars.UICommand("cmdReloadConfigData");
            this.cmdAutoSave = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoSave");
            this.cmdNewMail = new Janus.Windows.UI.CommandBars.UICommand("cmdNewMail");
            this.cmdNewDoc = new Janus.Windows.UI.CommandBars.UICommand("cmdNewDoc");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdNewMail2 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewMail");
            this.cmdNewDoc2 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewDoc");
            this.cmdOutlook = new Janus.Windows.UI.CommandBars.UICommand("cmdOutlook");
            this.cmdAdvancedFileSearch = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedFileSearch");
            this.cmdAdvancedSearchDocs = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedSearchDocs");
            this.cmdSearchOffices = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchOffices");
            this.cmdBrowseOffices = new Janus.Windows.UI.CommandBars.UICommand("cmdBrowseOffices");
            this.cmdSelectedSearchOption = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectedSearchOption");
            this.cmdSearchFileName1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFileName");
            this.cmdSearchFullFileName1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFullFileName");
            this.cmdSearchFileNumber1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFileNumber");
            this.cmdSearchFullFileNumber1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFullFileNumber");
            this.cmdSearchDocSubject1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchDocSubject");
            this.cmdSearchDocFullText1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchDocFullText");
            this.cmdSearchBoolean1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchBoolean");
            this.cmdSearchFileName = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFileName");
            this.cmdSearchFullFileName = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFullFileName");
            this.cmdSearchFileNumber = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFileNumber");
            this.cmdSearchFullFileNumber = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchFullFileNumber");
            this.cmdSearchDocSubject = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchDocSubject");
            this.cmdSearchDocFullText = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchDocFullText");
            this.cmdSearchBoolean = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchBoolean");
            this.cmdIssues = new Janus.Windows.UI.CommandBars.UICommand("cmdIssues");
            this.cmdSearchContacts = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchContacts");
            this.cmdWindows = new Janus.Windows.UI.CommandBars.UICommand("cmdWindows");
            this.cmdGoToTimekeeping = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToTimekeeping");
            this.cmdActions = new Janus.Windows.UI.CommandBars.UICommand("cmdActions");
            this.cmdMandateControlPopup2 = new Janus.Windows.UI.CommandBars.UICommand("cmdMandateControlPopup");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdSpacer = new Janus.Windows.UI.CommandBars.UICommand("cmdSpacer");
            this.cmdLabelHitCount = new Janus.Windows.UI.CommandBars.UICommand("cmdLabelHitCount");
            this.cmdHitCountValue = new Janus.Windows.UI.CommandBars.UICommand("cmdHitCountValue");
            this.cmdBoolWarning = new Janus.Windows.UI.CommandBars.UICommand("cmdBoolWarning");
            this.cmdBoolWarningText = new Janus.Windows.UI.CommandBars.UICommand("cmdBoolWarningText");
            this.cmdRemoveBoolOperators = new Janus.Windows.UI.CommandBars.UICommand("cmdRemoveBoolOperators");
            this.cmdMandateControlPopup = new Janus.Windows.UI.CommandBars.UICommand("cmdMandateControlPopup");
            this.cmdAdmin = new Janus.Windows.UI.CommandBars.UICommand("cmdAdmin");
            this.cmdTriangle = new Janus.Windows.UI.CommandBars.UICommand("cmdTriangle");
            this.cmdMemberAssignmentTool = new Janus.Windows.UI.CommandBars.UICommand("cmdMemberAssignmentTool");
            this.cmdListenForMessages = new Janus.Windows.UI.CommandBars.UICommand("cmdListenForMessages");
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdAdvancedFileSearch2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedFileSearch");
            this.cmdAdvancedSearchDocs2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAdvancedSearchDocs");
            this.cmdSearchOffices2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchOffices");
            this.cmdSearchContacts2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSearchContacts");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdWAMyself3 = new Janus.Windows.UI.CommandBars.UICommand("cmdWAMyself");
            this.btnMemberAssignmentTool = new Janus.Windows.EditControls.UIButton();
            this.btnTimekeeping = new Janus.Windows.EditControls.UIButton();
            this.btnAutoSave = new Janus.Windows.EditControls.UIButton();
            this.btnMandates = new Janus.Windows.EditControls.UIButton();
            this.btnAtriumExplorer = new Janus.Windows.EditControls.UIButton();
            this.btnMailBrowser = new Janus.Windows.EditControls.UIButton();
            this.btnAdvancedSearch = new Janus.Windows.EditControls.UIButton();
            this.cbSearch = new Janus.Windows.EditControls.UIComboBox();
            this.btnSearch = new Janus.Windows.EditControls.UIButton();
            this.ebSearch = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkQSExactMatch = new Janus.Windows.EditControls.UICheckBox();
            this.pnlToolbar2 = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlToolbar2Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lblHitCount = new System.Windows.Forms.Label();
            this.btnRemoveBoolOps = new Janus.Windows.EditControls.UIButton();
            this.lblNumOfHits = new System.Windows.Forms.Label();
            this.lblWarnMessage = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.pnlSysMessage = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSysMessageContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ebAtriumMessage = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlNav = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlOfficerToolkit = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlOfficerToolkitContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlLawMateFilesTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLawMateFilesTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pblLawMateFilesBrowser = new Janus.Windows.UI.Dock.UIPanel();
            this.pblLawMateFilesBrowserContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ribbonStatusBar1 = new Janus.Windows.Ribbon.RibbonStatusBar();
            this.cmdWAMyself1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWAMyself");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmdLanguage1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLanguage");
            this.cmdReloadConfigData1 = new Janus.Windows.UI.CommandBars.UICommand("cmdReloadConfigData");
            this.timHitCountDelay = new System.Windows.Forms.Timer(this.components);
            this.bkwHitCount = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolbar)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.pnlToolbarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuWorkAs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolbar2)).BeginInit();
            this.pnlToolbar2.SuspendLayout();
            this.pnlToolbar2Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSysMessage)).BeginInit();
            this.pnlSysMessage.SuspendLayout();
            this.pnlSysMessageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNav)).BeginInit();
            this.pnlNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOfficerToolkit)).BeginInit();
            this.pnlOfficerToolkit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLawMateFilesTop)).BeginInit();
            this.pnlLawMateFilesTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblLawMateFilesBrowser)).BeginInit();
            this.pblLawMateFilesBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.ColorScheme = "Scheme1";
            resources.ApplyResources(this.uiStatusBar1, "uiStatusBar1");
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "BFListMessage";
            resources.ApplyResources(uiStatusBarPanel1, "uiStatusBarPanel1");
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "Message";
            resources.ApplyResources(uiStatusBarPanel2, "uiStatusBarPanel2");
            uiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "MailMessage";
            resources.ApplyResources(uiStatusBarPanel3, "uiStatusBarPanel3");
            uiStatusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Key = "Progress";
            uiStatusBarPanel4.PanelType = Janus.Windows.UI.StatusBar.StatusBarPanelType.ProgressBar;
            resources.ApplyResources(uiStatusBarPanel4, "uiStatusBarPanel4");
            uiStatusBarPanel5.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel5.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel5.Key = "Logged";
            resources.ApplyResources(uiStatusBarPanel5, "uiStatusBarPanel5");
            uiStatusBarPanel6.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel6.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            uiStatusBarPanel6.Key = "OfficerCode";
            resources.ApplyResources(uiStatusBarPanel6, "uiStatusBarPanel6");
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2,
            uiStatusBarPanel3,
            uiStatusBarPanel4,
            uiStatusBarPanel5,
            uiStatusBarPanel6});
            this.uiStatusBar1.VisualStyleManager = this.visualStyleManager1;
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
            janusColorScheme2.OfficeCustomColor = System.Drawing.Color.Azure;
            janusColorScheme2.VisualStyle = Janus.Windows.Common.VisualStyle.Office2010;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme2);
            this.visualStyleManager1.DefaultColorScheme = "Scheme1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // printToolStripMenuItem
            // 
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            // 
            // printPreviewToolStripMenuItem
            // 
            resources.ApplyResources(this.printPreviewToolStripMenuItem, "printPreviewToolStripMenuItem");
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            resources.ApplyResources(this.undoToolStripMenuItem, "undoToolStripMenuItem");
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            resources.ApplyResources(this.redoToolStripMenuItem, "redoToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // cutToolStripMenuItem
            // 
            resources.ApplyResources(this.cutToolStripMenuItem, "cutToolStripMenuItem");
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            // 
            // copyToolStripMenuItem
            // 
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            // 
            // pasteToolStripMenuItem
            // 
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whatsNewToolStripMenuItem,
            this.navigationPaneToolStripMenuItem,
            this.tabsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // whatsNewToolStripMenuItem
            // 
            this.whatsNewToolStripMenuItem.Name = "whatsNewToolStripMenuItem";
            resources.ApplyResources(this.whatsNewToolStripMenuItem, "whatsNewToolStripMenuItem");
            this.whatsNewToolStripMenuItem.Click += new System.EventHandler(this.whatsNewToolStripMenuItem_Click);
            // 
            // navigationPaneToolStripMenuItem
            // 
            this.navigationPaneToolStripMenuItem.Checked = true;
            this.navigationPaneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.navigationPaneToolStripMenuItem.Name = "navigationPaneToolStripMenuItem";
            resources.ApplyResources(this.navigationPaneToolStripMenuItem, "navigationPaneToolStripMenuItem");
            // 
            // tabsToolStripMenuItem
            // 
            this.tabsToolStripMenuItem.Name = "tabsToolStripMenuItem";
            resources.ApplyResources(this.tabsToolStripMenuItem, "tabsToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            resources.ApplyResources(this.customizeToolStripMenuItem, "customizeToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lawMateUserGuideToolStripMenuItem,
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // lawMateUserGuideToolStripMenuItem
            // 
            this.lawMateUserGuideToolStripMenuItem.Name = "lawMateUserGuideToolStripMenuItem";
            resources.ApplyResources(this.lawMateUserGuideToolStripMenuItem, "lawMateUserGuideToolStripMenuItem");
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            resources.ApplyResources(this.contentsToolStripMenuItem, "contentsToolStripMenuItem");
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            resources.ApplyResources(this.indexToolStripMenuItem, "indexToolStripMenuItem");
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            resources.ApplyResources(this.searchToolStripMenuItem, "searchToolStripMenuItem");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            resources.ApplyResources(this.uiPanelManager1, "uiPanelManager1");
            this.uiPanelManager1.ColorScheme = "Scheme1";
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideTabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.ImageAndText;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.Window;
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "tahoma";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.HotFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.PressedFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.PressedFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.SelectedFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.SelectedFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultTabGroupStyle = Janus.Windows.UI.Dock.TabGroupStyle.None;
            this.uiPanelManager1.ImageList = this.ImageListMain;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SettingsKey = "uiPanelManager1";
            this.uiPanelManager1.TabbedMdiSettings.BorderColor = System.Drawing.Color.Transparent;
            this.uiPanelManager1.TabbedMdiSettings.DockingStyleMode = Janus.Windows.UI.Dock.DockingStyleMode.Standard;
            this.uiPanelManager1.TabbedMdiSettings.MaxTabSize = ((int)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.MaxTabSize")));
            this.uiPanelManager1.TabbedMdiSettings.ShowCloseButtonOnSelectedTab = true;
            this.uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming = ((System.Drawing.StringTrimming)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming")));
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.DisabledFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.DisabledFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.DisabledFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.FormatStyle.FontName = "tahoma";
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.FormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.HotFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.HotFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.HotFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.PressedFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.PressedFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.PressedFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.SelectedFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.SelectedFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.TabbedMdiSettings.TabStateStyles.SelectedFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.TabbedMdiSettings.UseFormIcons = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.UseFormIcons")));
            this.uiPanelManager1.TabbedMdiSettings.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.UseCompatibleTextRendering = false;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.VisualStyleManager = this.visualStyleManager1;
            this.uiPanelManager1.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.uiPanelManager1_CurrentLayoutChanging);
            this.pnlToolbar.Id = new System.Guid("b107e55e-fd8f-4285-b80d-78cb9654b084");
            this.uiPanelManager1.Panels.Add(this.pnlToolbar);
            this.pnlToolbar2.Id = new System.Guid("cf120067-c90f-4156-9e5b-256c97044820");
            this.uiPanelManager1.Panels.Add(this.pnlToolbar2);
            this.pnlSysMessage.Id = new System.Guid("814c70e5-2f91-4851-9e20-9d25efaf20b9");
            this.uiPanelManager1.Panels.Add(this.pnlSysMessage);
            this.pnlNav.Id = new System.Guid("5ecd9b29-abb3-4505-8b64-592384f49404");
            this.pnlNav.StaticGroup = true;
            this.pnlOfficerToolkit.Id = new System.Guid("5a95bc9c-a955-434d-b7fd-6c5251b75818");
            this.pnlNav.Panels.Add(this.pnlOfficerToolkit);
            this.uiPanelManager1.Panels.Add(this.pnlNav);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b107e55e-fd8f-4285-b80d-78cb9654b084"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1071, 30), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("cf120067-c90f-4156-9e5b-256c97044820"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1071, 27), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("814c70e5-2f91-4851-9e20-9d25efaf20b9"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(961, 89), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5ecd9b29-abb3-4505-8b64-592384f49404"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(235, 378), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5a95bc9c-a955-434d-b7fd-6c5251b75818"), new System.Guid("5ecd9b29-abb3-4505-8b64-592384f49404"), 491, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5ecd9b29-abb3-4505-8b64-592384f49404"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5a95bc9c-a955-434d-b7fd-6c5251b75818"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("db547d95-952a-49b3-9969-e7cc3362e45b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d5a10b62-bff0-45fd-b3aa-f6f66092ea49"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("21687c5e-803a-42e8-bb49-b2e994774d5b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7229f4f2-7f15-410d-8c2c-6a29bdd6cd0f"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("07fb7bd6-6d56-4704-a8e5-49c6b1db5164"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("9e31b7d8-86dd-4284-aded-c5ce2d489cea"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("9064d157-e3d1-422b-8625-c1ae8a2219a0"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8b6970a5-2546-4d95-a9ba-e193c26e3c16"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("2af2ec8d-134b-43c7-9b9d-baaf95b9f5a3"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("814c70e5-2f91-4851-9e20-9d25efaf20b9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b107e55e-fd8f-4285-b80d-78cb9654b084"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("cf120067-c90f-4156-9e5b-256c97044820"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // ImageListMain
            // 
            this.ImageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListMain.ImageStream")));
            this.ImageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListMain.Images.SetKeyName(0, "drafts.gif");
            this.ImageListMain.Images.SetKeyName(1, "shortcut.gif");
            this.ImageListMain.Images.SetKeyName(2, "reports.gif");
            this.ImageListMain.Images.SetKeyName(3, "batch.gif");
            this.ImageListMain.Images.SetKeyName(4, "myDocuments.gif");
            this.ImageListMain.Images.SetKeyName(5, "cal.gif");
            this.ImageListMain.Images.SetKeyName(6, "bs.gif");
            this.ImageListMain.Images.SetKeyName(7, "bo.gif");
            this.ImageListMain.Images.SetKeyName(8, "doc.gif");
            this.ImageListMain.Images.SetKeyName(9, "msgS.gif");
            this.ImageListMain.Images.SetKeyName(10, "datePick.gif");
            this.ImageListMain.Images.SetKeyName(11, "search.gif");
            this.ImageListMain.Images.SetKeyName(12, "user.gif");
            this.ImageListMain.Images.SetKeyName(13, "unlinkedMail.gif");
            this.ImageListMain.Images.SetKeyName(14, "Inbox1.gif");
            this.ImageListMain.Images.SetKeyName(15, "myEfiles.gif");
            this.ImageListMain.Images.SetKeyName(16, "activity2.gif");
            this.ImageListMain.Images.SetKeyName(17, "sentItems.gif");
            this.ImageListMain.Images.SetKeyName(18, "outlook.gif");
            this.ImageListMain.Images.SetKeyName(19, "advancedSearch.gif");
            this.ImageListMain.Images.SetKeyName(20, "folder.gif");
            this.ImageListMain.Images.SetKeyName(21, "lawmateExplorer.gif");
            this.ImageListMain.Images.SetKeyName(22, "new.gif");
            this.ImageListMain.Images.SetKeyName(23, "officeicon.gif");
            this.ImageListMain.Images.SetKeyName(24, "mandates.gif");
            this.ImageListMain.Images.SetKeyName(25, "officerToolkit.gif");
            this.ImageListMain.Images.SetKeyName(26, "opinion.png");
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.AllowPanelDrag = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar.AllowPanelDrop = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlToolbar.InnerContainer = this.pnlToolbarContainer;
            resources.ApplyResources(this.pnlToolbar, "pnlToolbar");
            this.pnlToolbar.Name = "pnlToolbar";
            // 
            // pnlToolbarContainer
            // 
            this.pnlToolbarContainer.Controls.Add(this.ebWorkingAs);
            this.pnlToolbarContainer.Controls.Add(this.btnWorkingAs);
            this.pnlToolbarContainer.Controls.Add(this.btnMemberAssignmentTool);
            this.pnlToolbarContainer.Controls.Add(this.btnTimekeeping);
            this.pnlToolbarContainer.Controls.Add(this.btnAutoSave);
            this.pnlToolbarContainer.Controls.Add(this.btnMandates);
            this.pnlToolbarContainer.Controls.Add(this.btnAtriumExplorer);
            this.pnlToolbarContainer.Controls.Add(this.btnMailBrowser);
            this.pnlToolbarContainer.Controls.Add(this.btnAdvancedSearch);
            this.pnlToolbarContainer.Controls.Add(this.cbSearch);
            this.pnlToolbarContainer.Controls.Add(this.btnSearch);
            this.pnlToolbarContainer.Controls.Add(this.ebSearch);
            this.pnlToolbarContainer.Controls.Add(this.label1);
            this.pnlToolbarContainer.Controls.Add(this.chkQSExactMatch);
            resources.ApplyResources(this.pnlToolbarContainer, "pnlToolbarContainer");
            this.pnlToolbarContainer.Name = "pnlToolbarContainer";
            // 
            // ebWorkingAs
            // 
            resources.ApplyResources(this.ebWorkingAs, "ebWorkingAs");
            this.ebWorkingAs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ebWorkingAs.Name = "ebWorkingAs";
            this.ebWorkingAs.ReadOnly = true;
            this.ebWorkingAs.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ebWorkingAs.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // btnWorkingAs
            // 
            resources.ApplyResources(this.btnWorkingAs, "btnWorkingAs");
            this.btnWorkingAs.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnWorkingAs.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton;
            this.btnWorkingAs.DropDownContextMenu = this.contextMenuWorkAs;
            this.btnWorkingAs.Image = global::LawMate.Properties.Resources.workas4;
            this.btnWorkingAs.Name = "btnWorkingAs";
            this.btnWorkingAs.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnWorkingAs.UseThemes = false;
            this.btnWorkingAs.Click += new System.EventHandler(this.btnWorkingAs_Click);
            this.btnWorkingAs.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnWorkingAs.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnWorkingAs.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnWorkingAs.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // contextMenuWorkAs
            // 
            this.contextMenuWorkAs.CommandManager = this.uiCommandManager1;
            this.contextMenuWorkAs.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdWAMyself3});
            resources.ApplyResources(this.contextMenuWorkAs, "contextMenuWorkAs");
            this.contextMenuWorkAs.UseThemes = Janus.Windows.UI.InheritableBoolean.False;
            this.contextMenuWorkAs.VisualStyle = Janus.Windows.UI.VisualStyle.Standard;
            this.contextMenuWorkAs.Popup += new System.EventHandler(this.contextMenuWorkAs_Popup);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.ColorScheme = "Scheme1";
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar3,
            this.uiCommandBar2});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile,
            this.cmdView,
            this.cmdTools,
            this.cmdHelp,
            this.cmdSearchText,
            this.cmdOn,
            this.cmdSearchDD,
            this.cmdAdvancedSearch,
            this.cmdMandates,
            this.cmdWorkAs,
            this.cmdLblWorkingAs,
            this.cmdWAMyself,
            this.cmdExecuteSearch,
            this.cmdClose,
            this.cmdExit,
            this.cmdNavPane,
            this.cmdLanguage,
            this.cmdReloadConfigData,
            this.cmdEnglish,
            this.cmdFrench,
            this.cmdPreferences,
            this.cmdLSBDeskbook,
            this.cmdWhatsNew,
            this.cmdAbout,
            this.cmdDocBrowser,
            this.cmdChangePassword,
            this.cmdReports,
            this.cmdBatchReview,
            this.cmdUtilities,
            this.cmdAutoSave,
            this.cmdNewMail,
            this.cmdNewDoc,
            this.cmdNew,
            this.cmdOutlook,
            this.cmdAdvancedFileSearch,
            this.cmdAdvancedSearchDocs,
            this.cmdSearchOffices,
            this.cmdBrowseOffices,
            this.cmdSelectedSearchOption,
            this.cmdSearchFileName,
            this.cmdSearchFullFileName,
            this.cmdSearchFileNumber,
            this.cmdSearchFullFileNumber,
            this.cmdSearchDocSubject,
            this.cmdSearchDocFullText,
            this.cmdSearchBoolean,
            this.cmdIssues,
            this.cmdSearchContacts,
            this.cmdWindows,
            this.cmdGoToTimekeeping,
            this.cmdActions,
            this.cmdEdit,
            this.cmdSpacer,
            this.cmdLabelHitCount,
            this.cmdHitCountValue,
            this.cmdBoolWarning,
            this.cmdBoolWarningText,
            this.cmdRemoveBoolOperators,
            this.cmdMandateControlPopup,
            this.cmdAdmin,
            this.cmdTriangle,
            this.cmdMemberAssignmentTool,
            this.cmdListenForMessages});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1,
            this.contextMenuWorkAs});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("5acaa5e0-2ae9-45ac-a0ee-5cdf16b697c2");
            this.uiCommandManager1.ImageList = this.ImageListMain;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
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
            this.cmdEdit1,
            this.cmdView1,
            this.cmdTools1,
            this.cmdActions1,
            this.cmdWindows1,
            this.cmdHelp1});
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            resources.ApplyResources(this.cmdEdit1, "cmdEdit1");
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // cmdView1
            // 
            resources.ApplyResources(this.cmdView1, "cmdView1");
            this.cmdView1.Name = "cmdView1";
            // 
            // cmdTools1
            // 
            resources.ApplyResources(this.cmdTools1, "cmdTools1");
            this.cmdTools1.Name = "cmdTools1";
            // 
            // cmdActions1
            // 
            resources.ApplyResources(this.cmdActions1, "cmdActions1");
            this.cmdActions1.Name = "cmdActions1";
            // 
            // cmdWindows1
            // 
            resources.ApplyResources(this.cmdWindows1, "cmdWindows1");
            this.cmdWindows1.Name = "cmdWindows1";
            // 
            // cmdHelp1
            // 
            resources.ApplyResources(this.cmdHelp1, "cmdHelp1");
            this.cmdHelp1.Name = "cmdHelp1";
            // 
            // uiCommandBar3
            // 
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSearchText2,
            this.cmdOn2,
            this.cmdSearchDD2,
            this.cmdSelectedSearchOption1,
            this.cmdExecuteSearch1,
            this.Separator1,
            this.cmdAdvancedSearch1,
            this.Separator4,
            this.cmdOutlook2,
            this.cmdDocBrowser2,
            this.cmdBrowseOffices1,
            this.Separator2,
            this.cmdMandateControlPopup1,
            this.Separator7,
            this.cmdAutoSave2,
            this.cmdGoToTimekeeping1,
            this.Separator8,
            this.cmdMemberAssignmentTool1,
            this.Separator13,
            this.cmdNew1,
            this.cmdLblWorkingAs1,
            this.cmdWorkAs1});
            this.uiCommandBar3.FullRow = true;
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.LockCommandBar = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.uiCommandBar3.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandBar3_CommandClick);
            // 
            // cmdSearchText2
            // 
            resources.ApplyResources(this.cmdSearchText2, "cmdSearchText2");
            this.cmdSearchText2.Name = "cmdSearchText2";
            // 
            // cmdOn2
            // 
            resources.ApplyResources(this.cmdOn2, "cmdOn2");
            this.cmdOn2.Name = "cmdOn2";
            // 
            // cmdSearchDD2
            // 
            this.cmdSearchDD2.ControlWidth = 200;
            resources.ApplyResources(this.cmdSearchDD2, "cmdSearchDD2");
            this.cmdSearchDD2.Name = "cmdSearchDD2";
            // 
            // cmdSelectedSearchOption1
            // 
            resources.ApplyResources(this.cmdSelectedSearchOption1, "cmdSelectedSearchOption1");
            this.cmdSelectedSearchOption1.Name = "cmdSelectedSearchOption1";
            this.cmdSelectedSearchOption1.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdExecuteSearch1
            // 
            resources.ApplyResources(this.cmdExecuteSearch1, "cmdExecuteSearch1");
            this.cmdExecuteSearch1.Name = "cmdExecuteSearch1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdAdvancedSearch1
            // 
            this.cmdAdvancedSearch1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdAdvancedSearch1, "cmdAdvancedSearch1");
            this.cmdAdvancedSearch1.Name = "cmdAdvancedSearch1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdOutlook2
            // 
            this.cmdOutlook2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdOutlook2, "cmdOutlook2");
            this.cmdOutlook2.Name = "cmdOutlook2";
            // 
            // cmdDocBrowser2
            // 
            this.cmdDocBrowser2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdDocBrowser2, "cmdDocBrowser2");
            this.cmdDocBrowser2.Name = "cmdDocBrowser2";
            // 
            // cmdBrowseOffices1
            // 
            resources.ApplyResources(this.cmdBrowseOffices1, "cmdBrowseOffices1");
            this.cmdBrowseOffices1.Name = "cmdBrowseOffices1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdMandateControlPopup1
            // 
            resources.ApplyResources(this.cmdMandateControlPopup1, "cmdMandateControlPopup1");
            this.cmdMandateControlPopup1.Name = "cmdMandateControlPopup1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // cmdAutoSave2
            // 
            this.cmdAutoSave2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdAutoSave2, "cmdAutoSave2");
            this.cmdAutoSave2.Name = "cmdAutoSave2";
            // 
            // cmdGoToTimekeeping1
            // 
            resources.ApplyResources(this.cmdGoToTimekeeping1, "cmdGoToTimekeeping1");
            this.cmdGoToTimekeeping1.Name = "cmdGoToTimekeeping1";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator8, "Separator8");
            this.Separator8.Name = "Separator8";
            // 
            // cmdMemberAssignmentTool1
            // 
            this.cmdMemberAssignmentTool1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdMemberAssignmentTool1, "cmdMemberAssignmentTool1");
            this.cmdMemberAssignmentTool1.Name = "cmdMemberAssignmentTool1";
            // 
            // Separator13
            // 
            this.Separator13.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator13, "Separator13");
            this.Separator13.Name = "Separator13";
            // 
            // cmdNew1
            // 
            resources.ApplyResources(this.cmdNew1, "cmdNew1");
            this.cmdNew1.Name = "cmdNew1";
            this.cmdNew1.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdLblWorkingAs1
            // 
            resources.ApplyResources(this.cmdLblWorkingAs1, "cmdLblWorkingAs1");
            this.cmdLblWorkingAs1.Name = "cmdLblWorkingAs1";
            // 
            // cmdWorkAs1
            // 
            this.cmdWorkAs1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdWorkAs1, "cmdWorkAs1");
            this.cmdWorkAs1.Name = "cmdWorkAs1";
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowMerge = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdLabelHitCount1,
            this.cmdHitCountValue1,
            this.cmdBoolWarning2,
            this.cmdBoolWarningText2,
            this.Separator12,
            this.cmdRemoveBoolOperators2});
            this.uiCommandBar2.FullRow = true;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdLabelHitCount1
            // 
            resources.ApplyResources(this.cmdLabelHitCount1, "cmdLabelHitCount1");
            this.cmdLabelHitCount1.Name = "cmdLabelHitCount1";
            // 
            // cmdHitCountValue1
            // 
            resources.ApplyResources(this.cmdHitCountValue1, "cmdHitCountValue1");
            this.cmdHitCountValue1.Name = "cmdHitCountValue1";
            // 
            // cmdBoolWarning2
            // 
            resources.ApplyResources(this.cmdBoolWarning2, "cmdBoolWarning2");
            this.cmdBoolWarning2.Name = "cmdBoolWarning2";
            // 
            // cmdBoolWarningText2
            // 
            resources.ApplyResources(this.cmdBoolWarningText2, "cmdBoolWarningText2");
            this.cmdBoolWarningText2.Name = "cmdBoolWarningText2";
            // 
            // Separator12
            // 
            this.Separator12.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator12, "Separator12");
            this.Separator12.Name = "Separator12";
            // 
            // cmdRemoveBoolOperators2
            // 
            resources.ApplyResources(this.cmdRemoveBoolOperators2, "cmdRemoveBoolOperators2");
            this.cmdRemoveBoolOperators2.Name = "cmdRemoveBoolOperators2";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdClose1,
            this.Separator3,
            this.cmdExit1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdClose1
            // 
            resources.ApplyResources(this.cmdClose1, "cmdClose1");
            this.cmdClose1.Name = "cmdClose1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdExit1
            // 
            resources.ApplyResources(this.cmdExit1, "cmdExit1");
            this.cmdExit1.Name = "cmdExit1";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdOutlook1,
            this.cmdGoToTimekeeping2,
            this.cmdDocBrowser1,
            this.cmdAdvancedSearch2,
            this.Separator10,
            this.cmdReports2,
            this.cmdIssues1,
            this.cmdBatchReview3,
            this.Separator6,
            this.cmdNavPane1});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.Name = "cmdView";
            // 
            // cmdOutlook1
            // 
            this.cmdOutlook1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.cmdOutlook1, "cmdOutlook1");
            this.cmdOutlook1.Name = "cmdOutlook1";
            // 
            // cmdGoToTimekeeping2
            // 
            resources.ApplyResources(this.cmdGoToTimekeeping2, "cmdGoToTimekeeping2");
            this.cmdGoToTimekeeping2.Name = "cmdGoToTimekeeping2";
            // 
            // cmdDocBrowser1
            // 
            resources.ApplyResources(this.cmdDocBrowser1, "cmdDocBrowser1");
            this.cmdDocBrowser1.Name = "cmdDocBrowser1";
            // 
            // cmdAdvancedSearch2
            // 
            resources.ApplyResources(this.cmdAdvancedSearch2, "cmdAdvancedSearch2");
            this.cmdAdvancedSearch2.Name = "cmdAdvancedSearch2";
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator10, "Separator10");
            this.Separator10.Name = "Separator10";
            // 
            // cmdReports2
            // 
            resources.ApplyResources(this.cmdReports2, "cmdReports2");
            this.cmdReports2.Name = "cmdReports2";
            // 
            // cmdIssues1
            // 
            resources.ApplyResources(this.cmdIssues1, "cmdIssues1");
            this.cmdIssues1.Name = "cmdIssues1";
            // 
            // cmdBatchReview3
            // 
            this.cmdBatchReview3.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.cmdBatchReview3, "cmdBatchReview3");
            this.cmdBatchReview3.Name = "cmdBatchReview3";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdNavPane1
            // 
            resources.ApplyResources(this.cmdNavPane1, "cmdNavPane1");
            this.cmdNavPane1.Name = "cmdNavPane1";
            // 
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdLanguage2,
            this.cmdAutoSave1,
            this.cmdListenForMessages1,
            this.cmdPreferences1,
            this.cmdChangePassword2,
            this.Separator9,
            this.cmdUtilities1});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.Name = "cmdTools";
            // 
            // cmdLanguage2
            // 
            resources.ApplyResources(this.cmdLanguage2, "cmdLanguage2");
            this.cmdLanguage2.Name = "cmdLanguage2";
            this.cmdLanguage2.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdAutoSave1
            // 
            resources.ApplyResources(this.cmdAutoSave1, "cmdAutoSave1");
            this.cmdAutoSave1.Name = "cmdAutoSave1";
            // 
            // cmdListenForMessages1
            // 
            resources.ApplyResources(this.cmdListenForMessages1, "cmdListenForMessages1");
            this.cmdListenForMessages1.Name = "cmdListenForMessages1";
            // 
            // cmdPreferences1
            // 
            resources.ApplyResources(this.cmdPreferences1, "cmdPreferences1");
            this.cmdPreferences1.Name = "cmdPreferences1";
            // 
            // cmdChangePassword2
            // 
            resources.ApplyResources(this.cmdChangePassword2, "cmdChangePassword2");
            this.cmdChangePassword2.Name = "cmdChangePassword2";
            // 
            // Separator9
            // 
            this.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator9, "Separator9");
            this.Separator9.Name = "Separator9";
            // 
            // cmdUtilities1
            // 
            resources.ApplyResources(this.cmdUtilities1, "cmdUtilities1");
            this.cmdUtilities1.Name = "cmdUtilities1";
            // 
            // cmdHelp
            // 
            this.cmdHelp.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdLSBDeskbook1,
            this.cmdTriangle1,
            this.cmdWhatsNew1,
            this.Separator5,
            this.cmdAbout1});
            resources.ApplyResources(this.cmdHelp, "cmdHelp");
            this.cmdHelp.Name = "cmdHelp";
            // 
            // cmdLSBDeskbook1
            // 
            resources.ApplyResources(this.cmdLSBDeskbook1, "cmdLSBDeskbook1");
            this.cmdLSBDeskbook1.Name = "cmdLSBDeskbook1";
            // 
            // cmdTriangle1
            // 
            resources.ApplyResources(this.cmdTriangle1, "cmdTriangle1");
            this.cmdTriangle1.Name = "cmdTriangle1";
            // 
            // cmdWhatsNew1
            // 
            resources.ApplyResources(this.cmdWhatsNew1, "cmdWhatsNew1");
            this.cmdWhatsNew1.Name = "cmdWhatsNew1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdAbout1
            // 
            resources.ApplyResources(this.cmdAbout1, "cmdAbout1");
            this.cmdAbout1.Name = "cmdAbout1";
            // 
            // cmdSearchText
            // 
            this.cmdSearchText.CommandType = Janus.Windows.UI.CommandBars.CommandType.TextBoxCommand;
            resources.ApplyResources(this.cmdSearchText, "cmdSearchText");
            this.cmdSearchText.ControlWidth = 150;
            this.cmdSearchText.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdSearchText.Name = "cmdSearchText";
            // 
            // cmdOn
            // 
            this.cmdOn.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdOn, "cmdOn");
            this.cmdOn.Name = "cmdOn";
            // 
            // cmdSearchDD
            // 
            this.cmdSearchDD.CommandType = Janus.Windows.UI.CommandBars.CommandType.ComboBoxCommand;
            this.cmdSearchDD.ControlWidth = 200;
            this.cmdSearchDD.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.cmdSearchDD, "cmdSearchDD");
            this.cmdSearchDD.Name = "cmdSearchDD";
            // 
            // cmdAdvancedSearch
            // 
            this.cmdAdvancedSearch.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAdvancedFileSearch1,
            this.cmdAdvancedSearchDocs1,
            this.cmdSearchOffices1,
            this.cmdSearchContacts1});
            this.cmdAdvancedSearch.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdAdvancedSearch.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdAdvancedSearch, "cmdAdvancedSearch");
            this.cmdAdvancedSearch.Name = "cmdAdvancedSearch";
            // 
            // cmdAdvancedFileSearch1
            // 
            resources.ApplyResources(this.cmdAdvancedFileSearch1, "cmdAdvancedFileSearch1");
            this.cmdAdvancedFileSearch1.Name = "cmdAdvancedFileSearch1";
            // 
            // cmdAdvancedSearchDocs1
            // 
            resources.ApplyResources(this.cmdAdvancedSearchDocs1, "cmdAdvancedSearchDocs1");
            this.cmdAdvancedSearchDocs1.Name = "cmdAdvancedSearchDocs1";
            // 
            // cmdSearchOffices1
            // 
            resources.ApplyResources(this.cmdSearchOffices1, "cmdSearchOffices1");
            this.cmdSearchOffices1.Name = "cmdSearchOffices1";
            // 
            // cmdSearchContacts1
            // 
            resources.ApplyResources(this.cmdSearchContacts1, "cmdSearchContacts1");
            this.cmdSearchContacts1.Name = "cmdSearchContacts1";
            // 
            // cmdMandates
            // 
            this.cmdMandates.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdMandates.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdMandates, "cmdMandates");
            this.cmdMandates.Name = "cmdMandates";
            // 
            // cmdWorkAs
            // 
            this.cmdWorkAs.Alignment = Janus.Windows.UI.CommandBars.CommandAlignment.Far;
            this.cmdWorkAs.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdWAMyself2});
            resources.ApplyResources(this.cmdWorkAs, "cmdWorkAs");
            this.cmdWorkAs.Name = "cmdWorkAs";
            // 
            // cmdWAMyself2
            // 
            resources.ApplyResources(this.cmdWAMyself2, "cmdWAMyself2");
            this.cmdWAMyself2.Name = "cmdWAMyself2";
            // 
            // cmdLblWorkingAs
            // 
            this.cmdLblWorkingAs.Alignment = Janus.Windows.UI.CommandBars.CommandAlignment.Far;
            this.cmdLblWorkingAs.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdLblWorkingAs, "cmdLblWorkingAs");
            this.cmdLblWorkingAs.Name = "cmdLblWorkingAs";
            // 
            // cmdWAMyself
            // 
            resources.ApplyResources(this.cmdWAMyself, "cmdWAMyself");
            this.cmdWAMyself.Name = "cmdWAMyself";
            // 
            // cmdExecuteSearch
            // 
            this.cmdExecuteSearch.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdExecuteSearch, "cmdExecuteSearch");
            this.cmdExecuteSearch.Name = "cmdExecuteSearch";
            // 
            // cmdClose
            // 
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Name = "cmdClose";
            // 
            // cmdExit
            // 
            resources.ApplyResources(this.cmdExit, "cmdExit");
            this.cmdExit.Name = "cmdExit";
            // 
            // cmdNavPane
            // 
            this.cmdNavPane.Checked = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.cmdNavPane, "cmdNavPane");
            this.cmdNavPane.Name = "cmdNavPane";
            // 
            // cmdLanguage
            // 
            this.cmdLanguage.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdEnglish1,
            this.cmdFrench1});
            resources.ApplyResources(this.cmdLanguage, "cmdLanguage");
            this.cmdLanguage.Name = "cmdLanguage";
            // 
            // cmdEnglish1
            // 
            resources.ApplyResources(this.cmdEnglish1, "cmdEnglish1");
            this.cmdEnglish1.Name = "cmdEnglish1";
            // 
            // cmdFrench1
            // 
            resources.ApplyResources(this.cmdFrench1, "cmdFrench1");
            this.cmdFrench1.Name = "cmdFrench1";
            // 
            // cmdReloadConfigData
            // 
            resources.ApplyResources(this.cmdReloadConfigData, "cmdReloadConfigData");
            this.cmdReloadConfigData.Name = "cmdReloadConfigData";
            // 
            // cmdEnglish
            // 
            this.cmdEnglish.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdEnglish.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdEnglish, "cmdEnglish");
            this.cmdEnglish.Name = "cmdEnglish";
            // 
            // cmdFrench
            // 
            this.cmdFrench.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdFrench, "cmdFrench");
            this.cmdFrench.Name = "cmdFrench";
            // 
            // cmdPreferences
            // 
            resources.ApplyResources(this.cmdPreferences, "cmdPreferences");
            this.cmdPreferences.Name = "cmdPreferences";
            // 
            // cmdLSBDeskbook
            // 
            resources.ApplyResources(this.cmdLSBDeskbook, "cmdLSBDeskbook");
            this.cmdLSBDeskbook.Name = "cmdLSBDeskbook";
            // 
            // cmdWhatsNew
            // 
            resources.ApplyResources(this.cmdWhatsNew, "cmdWhatsNew");
            this.cmdWhatsNew.Name = "cmdWhatsNew";
            // 
            // cmdAbout
            // 
            resources.ApplyResources(this.cmdAbout, "cmdAbout");
            this.cmdAbout.Name = "cmdAbout";
            // 
            // cmdDocBrowser
            // 
            resources.ApplyResources(this.cmdDocBrowser, "cmdDocBrowser");
            this.cmdDocBrowser.Name = "cmdDocBrowser";
            // 
            // cmdChangePassword
            // 
            resources.ApplyResources(this.cmdChangePassword, "cmdChangePassword");
            this.cmdChangePassword.Name = "cmdChangePassword";
            // 
            // cmdReports
            // 
            resources.ApplyResources(this.cmdReports, "cmdReports");
            this.cmdReports.Name = "cmdReports";
            // 
            // cmdBatchReview
            // 
            resources.ApplyResources(this.cmdBatchReview, "cmdBatchReview");
            this.cmdBatchReview.Name = "cmdBatchReview";
            // 
            // cmdUtilities
            // 
            this.cmdUtilities.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAdmin1,
            this.cmdReloadConfigData3});
            resources.ApplyResources(this.cmdUtilities, "cmdUtilities");
            this.cmdUtilities.Name = "cmdUtilities";
            // 
            // cmdAdmin1
            // 
            resources.ApplyResources(this.cmdAdmin1, "cmdAdmin1");
            this.cmdAdmin1.Name = "cmdAdmin1";
            // 
            // cmdReloadConfigData3
            // 
            resources.ApplyResources(this.cmdReloadConfigData3, "cmdReloadConfigData3");
            this.cmdReloadConfigData3.Name = "cmdReloadConfigData3";
            // 
            // cmdAutoSave
            // 
            resources.ApplyResources(this.cmdAutoSave, "cmdAutoSave");
            this.cmdAutoSave.Name = "cmdAutoSave";
            // 
            // cmdNewMail
            // 
            this.cmdNewMail.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdNewMail, "cmdNewMail");
            this.cmdNewMail.Name = "cmdNewMail";
            // 
            // cmdNewDoc
            // 
            this.cmdNewDoc.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdNewDoc, "cmdNewDoc");
            this.cmdNewDoc.Name = "cmdNewDoc";
            // 
            // cmdNew
            // 
            this.cmdNew.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNewMail2,
            this.cmdNewDoc2});
            this.cmdNew.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdNew, "cmdNew");
            this.cmdNew.Name = "cmdNew";
            // 
            // cmdNewMail2
            // 
            resources.ApplyResources(this.cmdNewMail2, "cmdNewMail2");
            this.cmdNewMail2.Name = "cmdNewMail2";
            // 
            // cmdNewDoc2
            // 
            resources.ApplyResources(this.cmdNewDoc2, "cmdNewDoc2");
            this.cmdNewDoc2.Name = "cmdNewDoc2";
            // 
            // cmdOutlook
            // 
            resources.ApplyResources(this.cmdOutlook, "cmdOutlook");
            this.cmdOutlook.Name = "cmdOutlook";
            // 
            // cmdAdvancedFileSearch
            // 
            resources.ApplyResources(this.cmdAdvancedFileSearch, "cmdAdvancedFileSearch");
            this.cmdAdvancedFileSearch.Name = "cmdAdvancedFileSearch";
            // 
            // cmdAdvancedSearchDocs
            // 
            resources.ApplyResources(this.cmdAdvancedSearchDocs, "cmdAdvancedSearchDocs");
            this.cmdAdvancedSearchDocs.Name = "cmdAdvancedSearchDocs";
            // 
            // cmdSearchOffices
            // 
            resources.ApplyResources(this.cmdSearchOffices, "cmdSearchOffices");
            this.cmdSearchOffices.Name = "cmdSearchOffices";
            // 
            // cmdBrowseOffices
            // 
            this.cmdBrowseOffices.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdBrowseOffices, "cmdBrowseOffices");
            this.cmdBrowseOffices.Name = "cmdBrowseOffices";
            this.cmdBrowseOffices.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdSelectedSearchOption
            // 
            this.cmdSelectedSearchOption.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdSelectedSearchOption.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSearchFileName1,
            this.cmdSearchFullFileName1,
            this.cmdSearchFileNumber1,
            this.cmdSearchFullFileNumber1,
            this.cmdSearchDocSubject1,
            this.cmdSearchDocFullText1,
            this.cmdSearchBoolean1});
            this.cmdSelectedSearchOption.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSelectedSearchOption, "cmdSelectedSearchOption");
            this.cmdSelectedSearchOption.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdSelectedSearchOption.Name = "cmdSelectedSearchOption";
            this.cmdSelectedSearchOption.Tag = "FileName";
            // 
            // cmdSearchFileName1
            // 
            resources.ApplyResources(this.cmdSearchFileName1, "cmdSearchFileName1");
            this.cmdSearchFileName1.Name = "cmdSearchFileName1";
            // 
            // cmdSearchFullFileName1
            // 
            resources.ApplyResources(this.cmdSearchFullFileName1, "cmdSearchFullFileName1");
            this.cmdSearchFullFileName1.Name = "cmdSearchFullFileName1";
            // 
            // cmdSearchFileNumber1
            // 
            resources.ApplyResources(this.cmdSearchFileNumber1, "cmdSearchFileNumber1");
            this.cmdSearchFileNumber1.Name = "cmdSearchFileNumber1";
            // 
            // cmdSearchFullFileNumber1
            // 
            resources.ApplyResources(this.cmdSearchFullFileNumber1, "cmdSearchFullFileNumber1");
            this.cmdSearchFullFileNumber1.Name = "cmdSearchFullFileNumber1";
            // 
            // cmdSearchDocSubject1
            // 
            resources.ApplyResources(this.cmdSearchDocSubject1, "cmdSearchDocSubject1");
            this.cmdSearchDocSubject1.Name = "cmdSearchDocSubject1";
            // 
            // cmdSearchDocFullText1
            // 
            resources.ApplyResources(this.cmdSearchDocFullText1, "cmdSearchDocFullText1");
            this.cmdSearchDocFullText1.Name = "cmdSearchDocFullText1";
            // 
            // cmdSearchBoolean1
            // 
            resources.ApplyResources(this.cmdSearchBoolean1, "cmdSearchBoolean1");
            this.cmdSearchBoolean1.Name = "cmdSearchBoolean1";
            // 
            // cmdSearchFileName
            // 
            this.cmdSearchFileName.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdSearchFileName.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSearchFileName, "cmdSearchFileName");
            this.cmdSearchFileName.Name = "cmdSearchFileName";
            this.cmdSearchFileName.Tag = "FileName";
            // 
            // cmdSearchFullFileName
            // 
            this.cmdSearchFullFileName.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdSearchFullFileName.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSearchFullFileName, "cmdSearchFullFileName");
            this.cmdSearchFullFileName.Name = "cmdSearchFullFileName";
            this.cmdSearchFullFileName.Tag = "FullFileName";
            // 
            // cmdSearchFileNumber
            // 
            this.cmdSearchFileNumber.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdSearchFileNumber.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSearchFileNumber, "cmdSearchFileNumber");
            this.cmdSearchFileNumber.Name = "cmdSearchFileNumber";
            this.cmdSearchFileNumber.Tag = "FileNumber";
            // 
            // cmdSearchFullFileNumber
            // 
            this.cmdSearchFullFileNumber.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSearchFullFileNumber, "cmdSearchFullFileNumber");
            this.cmdSearchFullFileNumber.Name = "cmdSearchFullFileNumber";
            this.cmdSearchFullFileNumber.Tag = "FullFileNumber";
            // 
            // cmdSearchDocSubject
            // 
            this.cmdSearchDocSubject.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdSearchDocSubject.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSearchDocSubject, "cmdSearchDocSubject");
            this.cmdSearchDocSubject.Name = "cmdSearchDocSubject";
            this.cmdSearchDocSubject.Tag = "Subject";
            // 
            // cmdSearchDocFullText
            // 
            this.cmdSearchDocFullText.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdSearchDocFullText.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSearchDocFullText, "cmdSearchDocFullText");
            this.cmdSearchDocFullText.Name = "cmdSearchDocFullText";
            this.cmdSearchDocFullText.Tag = "FullText";
            // 
            // cmdSearchBoolean
            // 
            this.cmdSearchBoolean.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdSearchBoolean.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSearchBoolean, "cmdSearchBoolean");
            this.cmdSearchBoolean.Name = "cmdSearchBoolean";
            this.cmdSearchBoolean.Tag = "Boolean";
            // 
            // cmdIssues
            // 
            resources.ApplyResources(this.cmdIssues, "cmdIssues");
            this.cmdIssues.Name = "cmdIssues";
            // 
            // cmdSearchContacts
            // 
            resources.ApplyResources(this.cmdSearchContacts, "cmdSearchContacts");
            this.cmdSearchContacts.Name = "cmdSearchContacts";
            // 
            // cmdWindows
            // 
            this.cmdWindows.CommandType = Janus.Windows.UI.CommandBars.CommandType.MdiList;
            resources.ApplyResources(this.cmdWindows, "cmdWindows");
            this.cmdWindows.Name = "cmdWindows";
            // 
            // cmdGoToTimekeeping
            // 
            this.cmdGoToTimekeeping.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdGoToTimekeeping, "cmdGoToTimekeeping");
            this.cmdGoToTimekeeping.Name = "cmdGoToTimekeeping";
            // 
            // cmdActions
            // 
            this.cmdActions.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdMandateControlPopup2});
            this.cmdActions.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.cmdActions, "cmdActions");
            this.cmdActions.Name = "cmdActions";
            // 
            // cmdMandateControlPopup2
            // 
            resources.ApplyResources(this.cmdMandateControlPopup2, "cmdMandateControlPopup2");
            this.cmdMandateControlPopup2.Name = "cmdMandateControlPopup2";
            // 
            // cmdEdit
            // 
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdSpacer
            // 
            this.cmdSpacer.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdSpacer.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdSpacer, "cmdSpacer");
            this.cmdSpacer.Name = "cmdSpacer";
            // 
            // cmdLabelHitCount
            // 
            this.cmdLabelHitCount.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdLabelHitCount, "cmdLabelHitCount");
            this.cmdLabelHitCount.Name = "cmdLabelHitCount";
            this.cmdLabelHitCount.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            // 
            // cmdHitCountValue
            // 
            this.cmdHitCountValue.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.cmdHitCountValue.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.cmdHitCountValue, "cmdHitCountValue");
            this.cmdHitCountValue.Name = "cmdHitCountValue";
            // 
            // cmdBoolWarning
            // 
            this.cmdBoolWarning.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdBoolWarning, "cmdBoolWarning");
            this.cmdBoolWarning.Name = "cmdBoolWarning";
            this.cmdBoolWarning.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            // 
            // cmdBoolWarningText
            // 
            this.cmdBoolWarningText.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.cmdBoolWarningText.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdBoolWarningText, "cmdBoolWarningText");
            this.cmdBoolWarningText.Name = "cmdBoolWarningText";
            // 
            // cmdRemoveBoolOperators
            // 
            resources.ApplyResources(this.cmdRemoveBoolOperators, "cmdRemoveBoolOperators");
            this.cmdRemoveBoolOperators.Name = "cmdRemoveBoolOperators";
            // 
            // cmdMandateControlPopup
            // 
            this.cmdMandateControlPopup.CommandType = Janus.Windows.UI.CommandBars.CommandType.ControlPopup;
            resources.ApplyResources(this.cmdMandateControlPopup, "cmdMandateControlPopup");
            this.cmdMandateControlPopup.Name = "cmdMandateControlPopup";
            // 
            // cmdAdmin
            // 
            resources.ApplyResources(this.cmdAdmin, "cmdAdmin");
            this.cmdAdmin.Name = "cmdAdmin";
            // 
            // cmdTriangle
            // 
            resources.ApplyResources(this.cmdTriangle, "cmdTriangle");
            this.cmdTriangle.Name = "cmdTriangle";
            // 
            // cmdMemberAssignmentTool
            // 
            resources.ApplyResources(this.cmdMemberAssignmentTool, "cmdMemberAssignmentTool");
            this.cmdMemberAssignmentTool.Name = "cmdMemberAssignmentTool";
            // 
            // cmdListenForMessages
            // 
            this.cmdListenForMessages.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdListenForMessages.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdListenForMessages, "cmdListenForMessages");
            this.cmdListenForMessages.Name = "cmdListenForMessages";
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAdvancedFileSearch2,
            this.cmdAdvancedSearchDocs2,
            this.cmdSearchOffices2,
            this.cmdSearchContacts2});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.False;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.Standard;
            this.uiContextMenu1.Popup += new System.EventHandler(this.uiContextMenu1_Popup);
            // 
            // cmdAdvancedFileSearch2
            // 
            resources.ApplyResources(this.cmdAdvancedFileSearch2, "cmdAdvancedFileSearch2");
            this.cmdAdvancedFileSearch2.Name = "cmdAdvancedFileSearch2";
            // 
            // cmdAdvancedSearchDocs2
            // 
            resources.ApplyResources(this.cmdAdvancedSearchDocs2, "cmdAdvancedSearchDocs2");
            this.cmdAdvancedSearchDocs2.Name = "cmdAdvancedSearchDocs2";
            // 
            // cmdSearchOffices2
            // 
            resources.ApplyResources(this.cmdSearchOffices2, "cmdSearchOffices2");
            this.cmdSearchOffices2.Name = "cmdSearchOffices2";
            // 
            // cmdSearchContacts2
            // 
            resources.ApplyResources(this.cmdSearchContacts2, "cmdSearchContacts2");
            this.cmdSearchContacts2.Name = "cmdSearchContacts2";
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
            this.uiCommandBar1,
            this.uiCommandBar3,
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar3);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // cmdWAMyself3
            // 
            resources.ApplyResources(this.cmdWAMyself3, "cmdWAMyself3");
            this.cmdWAMyself3.Name = "cmdWAMyself3";
            // 
            // btnMemberAssignmentTool
            // 
            this.btnMemberAssignmentTool.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnMemberAssignmentTool.Image = global::LawMate.Properties.Resources.isparty;
            resources.ApplyResources(this.btnMemberAssignmentTool, "btnMemberAssignmentTool");
            this.btnMemberAssignmentTool.Name = "btnMemberAssignmentTool";
            this.btnMemberAssignmentTool.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnMemberAssignmentTool.UseThemes = false;
            this.btnMemberAssignmentTool.Click += new System.EventHandler(this.btnMemberAssignmentTool_Click);
            this.btnMemberAssignmentTool.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnMemberAssignmentTool.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnMemberAssignmentTool.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnMemberAssignmentTool.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // btnTimekeeping
            // 
            this.btnTimekeeping.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnTimekeeping.Image = global::LawMate.Properties.Resources.clock2;
            resources.ApplyResources(this.btnTimekeeping, "btnTimekeeping");
            this.btnTimekeeping.Name = "btnTimekeeping";
            this.btnTimekeeping.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnTimekeeping.UseThemes = false;
            this.btnTimekeeping.Click += new System.EventHandler(this.btnTimekeeping_Click);
            this.btnTimekeeping.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnTimekeeping.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnTimekeeping.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnTimekeeping.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // btnAutoSave
            // 
            this.btnAutoSave.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnAutoSave.Image = global::LawMate.Properties.Resources.autosave;
            resources.ApplyResources(this.btnAutoSave, "btnAutoSave");
            this.btnAutoSave.Name = "btnAutoSave";
            this.btnAutoSave.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnAutoSave.UseThemes = false;
            this.btnAutoSave.Click += new System.EventHandler(this.btnAutoSave_Click);
            this.btnAutoSave.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnAutoSave.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnAutoSave.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnAutoSave.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // btnMandates
            // 
            this.btnMandates.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnMandates.Image = global::LawMate.Properties.Resources.mandates;
            resources.ApplyResources(this.btnMandates, "btnMandates");
            this.btnMandates.Name = "btnMandates";
            this.btnMandates.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnMandates.UseThemes = false;
            this.btnMandates.Click += new System.EventHandler(this.btnMandates_Click);
            this.btnMandates.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnMandates.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnMandates.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnMandates.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // btnAtriumExplorer
            // 
            this.btnAtriumExplorer.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnAtriumExplorer.Image = global::LawMate.Properties.Resources.appTreeExplorer;
            resources.ApplyResources(this.btnAtriumExplorer, "btnAtriumExplorer");
            this.btnAtriumExplorer.Name = "btnAtriumExplorer";
            this.btnAtriumExplorer.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnAtriumExplorer.UseThemes = false;
            this.btnAtriumExplorer.Click += new System.EventHandler(this.btnAtriumExplorer_Click);
            this.btnAtriumExplorer.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnAtriumExplorer.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnAtriumExplorer.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnAtriumExplorer.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // btnMailBrowser
            // 
            this.btnMailBrowser.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnMailBrowser.Image = global::LawMate.Properties.Resources.mailimporter2;
            resources.ApplyResources(this.btnMailBrowser, "btnMailBrowser");
            this.btnMailBrowser.Name = "btnMailBrowser";
            this.btnMailBrowser.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnMailBrowser.UseThemes = false;
            this.btnMailBrowser.Click += new System.EventHandler(this.btnMailBrowser_Click);
            this.btnMailBrowser.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnMailBrowser.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnMailBrowser.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnMailBrowser.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // btnAdvancedSearch
            // 
            this.btnAdvancedSearch.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnAdvancedSearch.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton;
            this.btnAdvancedSearch.DropDownContextMenu = this.uiContextMenu1;
            this.btnAdvancedSearch.Image = global::LawMate.Properties.Resources.advancedsearchicon;
            resources.ApplyResources(this.btnAdvancedSearch, "btnAdvancedSearch");
            this.btnAdvancedSearch.Name = "btnAdvancedSearch";
            this.btnAdvancedSearch.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnAdvancedSearch.UseThemes = false;
            this.btnAdvancedSearch.Click += new System.EventHandler(this.btnAdvancedSearch_Click);
            this.btnAdvancedSearch.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnAdvancedSearch.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnAdvancedSearch.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnAdvancedSearch.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // cbSearch
            // 
            this.cbSearch.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbSearch.ImageList = this.ImageListMain;
            resources.ApplyResources(this.cbSearch, "cbSearch");
            this.cbSearch.MaxDropDownItems = 16;
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Custom;
            this.cbSearch.OfficeCustomColor = System.Drawing.Color.LightSteelBlue;
            this.cbSearch.UseThemes = false;
            this.cbSearch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cbSearch.SelectedItemChanged += new System.EventHandler(this.cbSearch_SelectedItemChanged);
            this.cbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnSearch.Image = global::LawMate.Properties.Resources.search;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnSearch.UseThemes = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnSearch.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnSearch.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // ebSearch
            // 
            resources.ApplyResources(this.ebSearch, "ebSearch");
            this.ebSearch.Name = "ebSearch";
            this.ebSearch.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.ebSearch.TextChanged += new System.EventHandler(this.ebSearch_TextChanged);
            this.ebSearch.Enter += new System.EventHandler(this.ebSearch_Enter);
            this.ebSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ebSearch_KeyDown);
            this.ebSearch.Leave += new System.EventHandler(this.ebSearch_Leave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // chkQSExactMatch
            // 
            this.chkQSExactMatch.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkQSExactMatch, "chkQSExactMatch");
            this.chkQSExactMatch.Name = "chkQSExactMatch";
            this.toolTip1.SetToolTip(this.chkQSExactMatch, resources.GetString("chkQSExactMatch.ToolTip"));
            this.chkQSExactMatch.UseThemes = false;
            this.chkQSExactMatch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            // 
            // pnlToolbar2
            // 
            this.pnlToolbar2.AllowPanelDrag = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar2.AllowPanelDrop = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar2.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar2.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar2.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar2.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolbar2.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlToolbar2.InnerContainer = this.pnlToolbar2Container;
            resources.ApplyResources(this.pnlToolbar2, "pnlToolbar2");
            this.pnlToolbar2.Name = "pnlToolbar2";
            // 
            // pnlToolbar2Container
            // 
            this.pnlToolbar2Container.Controls.Add(this.lblHitCount);
            this.pnlToolbar2Container.Controls.Add(this.btnRemoveBoolOps);
            this.pnlToolbar2Container.Controls.Add(this.lblNumOfHits);
            this.pnlToolbar2Container.Controls.Add(this.lblWarnMessage);
            this.pnlToolbar2Container.Controls.Add(this.lblWarning);
            resources.ApplyResources(this.pnlToolbar2Container, "pnlToolbar2Container");
            this.pnlToolbar2Container.Name = "pnlToolbar2Container";
            // 
            // lblHitCount
            // 
            resources.ApplyResources(this.lblHitCount, "lblHitCount");
            this.lblHitCount.BackColor = System.Drawing.Color.Transparent;
            this.lblHitCount.Name = "lblHitCount";
            // 
            // btnRemoveBoolOps
            // 
            this.btnRemoveBoolOps.Appearance = Janus.Windows.UI.Appearance.Flat;
            this.btnRemoveBoolOps.Image = global::LawMate.Properties.Resources.eraser;
            resources.ApplyResources(this.btnRemoveBoolOps, "btnRemoveBoolOps");
            this.btnRemoveBoolOps.Name = "btnRemoveBoolOps";
            this.btnRemoveBoolOps.StateStyles.FormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.btnRemoveBoolOps.UseThemes = false;
            this.btnRemoveBoolOps.Click += new System.EventHandler(this.btnRemoveBoolOps_Click);
            this.btnRemoveBoolOps.Enter += new System.EventHandler(this.btnSearch_Enter);
            this.btnRemoveBoolOps.Leave += new System.EventHandler(this.btnSearch_Leave);
            this.btnRemoveBoolOps.MouseEnter += new System.EventHandler(this.uiButton1_MouseEnter);
            this.btnRemoveBoolOps.MouseLeave += new System.EventHandler(this.uiButton1_MouseLeave);
            // 
            // lblNumOfHits
            // 
            this.lblNumOfHits.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblNumOfHits, "lblNumOfHits");
            this.lblNumOfHits.Image = global::LawMate.Properties.Resources.hitcount;
            this.lblNumOfHits.Name = "lblNumOfHits";
            // 
            // lblWarnMessage
            // 
            resources.ApplyResources(this.lblWarnMessage, "lblWarnMessage");
            this.lblWarnMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblWarnMessage.Name = "lblWarnMessage";
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.Image = global::LawMate.Properties.Resources.warning_16x16;
            this.lblWarning.Name = "lblWarning";
            // 
            // pnlSysMessage
            // 
            this.pnlSysMessage.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlSysMessage.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlSysMessage.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.pnlSysMessage, "pnlSysMessage");
            this.pnlSysMessage.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Standard;
            this.pnlSysMessage.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlSysMessage.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlSysMessage.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlSysMessage.InnerContainer = this.pnlSysMessageContainer;
            this.pnlSysMessage.Name = "pnlSysMessage";
            // 
            // pnlSysMessageContainer
            // 
            this.pnlSysMessageContainer.Controls.Add(this.ebAtriumMessage);
            resources.ApplyResources(this.pnlSysMessageContainer, "pnlSysMessageContainer");
            this.pnlSysMessageContainer.Name = "pnlSysMessageContainer";
            // 
            // ebAtriumMessage
            // 
            this.ebAtriumMessage.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ebAtriumMessage.ButtonFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.ebAtriumMessage.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.TextButton;
            resources.ApplyResources(this.ebAtriumMessage, "ebAtriumMessage");
            this.ebAtriumMessage.ForeColor = System.Drawing.Color.White;
            this.ebAtriumMessage.HoverMode = Janus.Windows.GridEX.HoverMode.Highlight;
            this.ebAtriumMessage.Multiline = true;
            this.ebAtriumMessage.Name = "ebAtriumMessage";
            this.ebAtriumMessage.ReadOnly = true;
            this.ebAtriumMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ebAtriumMessage.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebAtriumMessage.ButtonClick += new System.EventHandler(this.ebAtriumMessage_ButtonClick);
            // 
            // pnlNav
            // 
            this.pnlNav.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            resources.ApplyResources(this.pnlNav, "pnlNav");
            this.pnlNav.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.SelectedPanel = this.pnlOfficerToolkit;
            // 
            // pnlOfficerToolkit
            // 
            this.pnlOfficerToolkit.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.pnlOfficerToolkit.CaptionFormatStyle.FontName = "calibri";
            this.pnlOfficerToolkit.CaptionFormatStyle.FontSize = 11F;
            resources.ApplyResources(this.pnlOfficerToolkit, "pnlOfficerToolkit");
            this.pnlOfficerToolkit.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Standard;
            this.pnlOfficerToolkit.InnerContainer = this.pnlOfficerToolkitContainer;
            this.pnlOfficerToolkit.Name = "pnlOfficerToolkit";
            // 
            // pnlOfficerToolkitContainer
            // 
            resources.ApplyResources(this.pnlOfficerToolkitContainer, "pnlOfficerToolkitContainer");
            this.pnlOfficerToolkitContainer.Name = "pnlOfficerToolkitContainer";
            // 
            // pnlLawMateFilesTop
            // 
            this.pnlLawMateFilesTop.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlLawMateFilesTop.BorderCaption = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlLawMateFilesTop.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlLawMateFilesTop.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.pnlLawMateFilesTop.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlLawMateFilesTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlLawMateFilesTop.InnerContainer = this.pnlLawMateFilesTopContainer;
            resources.ApplyResources(this.pnlLawMateFilesTop, "pnlLawMateFilesTop");
            this.pnlLawMateFilesTop.Name = "pnlLawMateFilesTop";
            // 
            // pnlLawMateFilesTopContainer
            // 
            resources.ApplyResources(this.pnlLawMateFilesTopContainer, "pnlLawMateFilesTopContainer");
            this.pnlLawMateFilesTopContainer.Name = "pnlLawMateFilesTopContainer";
            // 
            // pblLawMateFilesBrowser
            // 
            this.pblLawMateFilesBrowser.BorderCaption = Janus.Windows.UI.InheritableBoolean.True;
            this.pblLawMateFilesBrowser.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pblLawMateFilesBrowser.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pblLawMateFilesBrowser.InnerContainer = this.pblLawMateFilesBrowserContainer;
            resources.ApplyResources(this.pblLawMateFilesBrowser, "pblLawMateFilesBrowser");
            this.pblLawMateFilesBrowser.Name = "pblLawMateFilesBrowser";
            // 
            // pblLawMateFilesBrowserContainer
            // 
            resources.ApplyResources(this.pblLawMateFilesBrowserContainer, "pblLawMateFilesBrowserContainer");
            this.pblLawMateFilesBrowserContainer.Name = "pblLawMateFilesBrowserContainer";
            // 
            // ribbonStatusBar1
            // 
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.ShowToolTips = false;
            // 
            // 
            // 
            this.ribbonStatusBar1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbonStatusBar1.SuperTipComponent.ImageList = null;
            this.ribbonStatusBar1.UseCompatibleTextRendering = false;
            // 
            // cmdWAMyself1
            // 
            resources.ApplyResources(this.cmdWAMyself1, "cmdWAMyself1");
            this.cmdWAMyself1.Name = "cmdWAMyself1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmdLanguage1
            // 
            resources.ApplyResources(this.cmdLanguage1, "cmdLanguage1");
            this.cmdLanguage1.Name = "cmdLanguage1";
            // 
            // cmdReloadConfigData1
            // 
            resources.ApplyResources(this.cmdReloadConfigData1, "cmdReloadConfigData1");
            this.cmdReloadConfigData1.Name = "cmdReloadConfigData1";
            // 
            // timHitCountDelay
            // 
            this.timHitCountDelay.Interval = 300;
            this.timHitCountDelay.Tick += new System.EventHandler(this.timHitCountDelay_Tick);
            // 
            // bkwHitCount
            // 
            this.bkwHitCount.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwHitCount_DoWork);
            this.bkwHitCount.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkwHitCount_RunWorkerCompleted);
            // 
            // fMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlSysMessage);
            this.Controls.Add(this.pnlToolbar2);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.TopRebar1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "fMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.Shown += new System.EventHandler(this.fMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolbar)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbarContainer.ResumeLayout(false);
            this.pnlToolbarContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuWorkAs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolbar2)).EndInit();
            this.pnlToolbar2.ResumeLayout(false);
            this.pnlToolbar2Container.ResumeLayout(false);
            this.pnlToolbar2Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSysMessage)).EndInit();
            this.pnlSysMessage.ResumeLayout(false);
            this.pnlSysMessageContainer.ResumeLayout(false);
            this.pnlSysMessageContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNav)).EndInit();
            this.pnlNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlOfficerToolkit)).EndInit();
            this.pnlOfficerToolkit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLawMateFilesTop)).EndInit();
            this.pnlLawMateFilesTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pblLawMateFilesBrowser)).EndInit();
            this.pblLawMateFilesBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlNav;
        private Janus.Windows.UI.Dock.UIPanel pnlOfficerToolkit;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlOfficerToolkitContainer;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatsNewToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripMenuItem navigationPaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lawMateUserGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabsToolStripMenuItem;
        private Janus.Windows.UI.Dock.UIPanel pnlLawMateFilesTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLawMateFilesTopContainer;
        private Janus.Windows.UI.Dock.UIPanel pblLawMateFilesBrowser;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pblLawMateFilesBrowserContainer;
        private System.Windows.Forms.ImageList ImageListMain;
        private Janus.Windows.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchText;
        private Janus.Windows.UI.CommandBars.UICommand cmdOn;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchDD;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedSearch;
        private Janus.Windows.UI.CommandBars.UICommand cmdMandates;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchText2;
        private Janus.Windows.UI.CommandBars.UICommand cmdOn2;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchDD2;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedSearch1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdLblWorkingAs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWorkAs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWorkAs;
        private Janus.Windows.UI.CommandBars.UICommand cmdLblWorkingAs;
        private Janus.Windows.UI.CommandBars.UICommand cmdWAMyself;
        private Janus.Windows.UI.CommandBars.UICommand cmdWAMyself1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExecuteSearch1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWAMyself2;
        private Janus.Windows.UI.CommandBars.UICommand cmdExecuteSearch;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedSearch2;
        private Janus.Windows.UI.CommandBars.UICommand cmdNavPane1;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose;
        private Janus.Windows.UI.CommandBars.UICommand cmdExit;
        private Janus.Windows.UI.CommandBars.UICommand cmdNavPane;
        private Janus.Windows.UI.CommandBars.UICommand cmdLanguage;
        private Janus.Windows.UI.CommandBars.UICommand cmdReloadConfigData;
        private Janus.Windows.UI.CommandBars.UICommand cmdEnglish;
        private Janus.Windows.UI.CommandBars.UICommand cmdFrench;
        private Janus.Windows.UI.CommandBars.UICommand cmdLanguage1;
        private Janus.Windows.UI.CommandBars.UICommand cmdReloadConfigData1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLanguage2;
        private Janus.Windows.UI.CommandBars.UICommand cmdPreferences1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEnglish1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFrench1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPreferences;
        private Janus.Windows.UI.CommandBars.UICommand cmdLSBDeskbook1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWhatsNew1;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand cmdAbout1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLSBDeskbook;
        private Janus.Windows.UI.CommandBars.UICommand cmdWhatsNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdAbout;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocBrowser1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocBrowser;
        private Janus.Windows.UI.CommandBars.UICommand cmdChangePassword;
        private Janus.Windows.UI.CommandBars.UICommand cmdReports;
        private Janus.Windows.UI.CommandBars.UICommand cmdBatchReview;
        private Janus.Windows.UI.CommandBars.UICommand cmdUtilities;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        //private UserControls.ucOfficerToolkit ucOfficerToolkit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewMail;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewDoc;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewMail2;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewDoc2;
        private Janus.Windows.UI.CommandBars.UICommand cmdReports2;
        private Janus.Windows.UI.CommandBars.UICommand cmdBatchReview3;
        private Janus.Windows.UI.CommandBars.UICommand cmdChangePassword2;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocBrowser2;
        private Janus.Windows.UI.CommandBars.UICommand cmdOutlook1;
        private Janus.Windows.UI.CommandBars.UICommand cmdOutlook;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedFileSearch;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedFileSearch1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedSearchDocs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedSearchDocs;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchOffices;
        private Janus.Windows.UI.CommandBars.UICommand cmdBrowseOffices;
        private Janus.Windows.UI.CommandBars.UICommand cmdBrowseOffices1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectedSearchOption1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectedSearchOption;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFileName;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFileName1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFullFileName;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFileNumber;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFullFileNumber;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchDocSubject;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchDocFullText;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchBoolean;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFullFileName1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFileNumber1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchFullFileNumber1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchDocSubject1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchDocFullText1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchBoolean1;
        private Janus.Windows.UI.CommandBars.UICommand cmdOutlook2;
        private Janus.Windows.UI.CommandBars.UICommand cmdIssues1;
        private Janus.Windows.UI.CommandBars.UICommand cmdIssues;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchOffices1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchContacts1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchContacts;
        private Janus.Windows.UI.CommandBars.UICommand cmdWindows;
        private Janus.Windows.UI.CommandBars.UICommand cmdWindows1;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToTimekeeping1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToTimekeeping;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdActions;
        private Janus.Windows.UI.CommandBars.UICommand cmdActions1;
        private Janus.Windows.UI.CommandBars.UICommand Separator9;
        private Janus.Windows.UI.CommandBars.UICommand cmdUtilities1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSpacer;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToTimekeeping2;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private System.Windows.Forms.Timer timHitCountDelay;
        private System.ComponentModel.BackgroundWorker bkwHitCount;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdLabelHitCount1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHitCountValue1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLabelHitCount;
        private Janus.Windows.UI.CommandBars.UICommand cmdHitCountValue;
        private Janus.Windows.UI.CommandBars.UICommand cmdBoolWarning;
        private Janus.Windows.UI.CommandBars.UICommand cmdBoolWarningText;
        private Janus.Windows.UI.CommandBars.UICommand cmdRemoveBoolOperators;
        private Janus.Windows.UI.CommandBars.UICommand cmdBoolWarning2;
        private Janus.Windows.UI.CommandBars.UICommand cmdBoolWarningText2;
        private Janus.Windows.UI.CommandBars.UICommand Separator12;
        private Janus.Windows.UI.CommandBars.UICommand cmdRemoveBoolOperators2;
        private Janus.Windows.UI.CommandBars.UICommand cmdMandateControlPopup1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMandateControlPopup;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdmin1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdmin;
        private Janus.Windows.UI.CommandBars.UICommand cmdMandateControlPopup2;
        private Janus.Windows.UI.CommandBars.UICommand cmdTriangle1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTriangle;
        private Janus.Windows.UI.CommandBars.UICommand cmdMemberAssignmentTool1;
        private Janus.Windows.UI.CommandBars.UICommand Separator13;
        private Janus.Windows.UI.CommandBars.UICommand cmdMemberAssignmentTool;
        private Janus.Windows.UI.CommandBars.UICommand cmdReloadConfigData3;
        private Janus.Windows.UI.Dock.UIPanel pnlSysMessage;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSysMessageContainer;
        private Janus.Windows.GridEX.EditControls.EditBox ebAtriumMessage;
        private Janus.Windows.UI.CommandBars.UICommand cmdListenForMessages1;
        private Janus.Windows.UI.CommandBars.UICommand cmdListenForMessages;
        private Janus.Windows.UI.Dock.UIPanel pnlToolbar;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlToolbarContainer;
        private Janus.Windows.EditControls.UIComboBox cbSearch;
        private Janus.Windows.EditControls.UIButton btnSearch;
        private Janus.Windows.GridEX.EditControls.EditBox ebSearch;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnAdvancedSearch;
        private Janus.Windows.EditControls.UIButton btnAtriumExplorer;
        private Janus.Windows.EditControls.UIButton btnMailBrowser;
        private Janus.Windows.EditControls.UIButton btnMandates;
        private Janus.Windows.EditControls.UIButton btnAutoSave;
        private Janus.Windows.EditControls.UIButton btnTimekeeping;
        private Janus.Windows.EditControls.UIButton btnWorkingAs;
        private Janus.Windows.EditControls.UIButton btnMemberAssignmentTool;
        private Janus.Windows.UI.CommandBars.UIContextMenu contextMenuWorkAs;
        private System.Windows.Forms.Label lblNumOfHits;
        private System.Windows.Forms.Label lblWarnMessage;
        private System.Windows.Forms.Label lblHitCount;
        private System.Windows.Forms.Label lblWarning;
        private Janus.Windows.EditControls.UIButton btnRemoveBoolOps;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedFileSearch2;
        private Janus.Windows.UI.CommandBars.UICommand cmdAdvancedSearchDocs2;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchOffices2;
        private Janus.Windows.UI.CommandBars.UICommand cmdSearchContacts2;
        private Janus.Windows.UI.CommandBars.UICommand cmdWAMyself3;
        private Janus.Windows.UI.Dock.UIPanel pnlToolbar2;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlToolbar2Container;
        public Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UICheckBox chkQSExactMatch;
        private Janus.Windows.GridEX.EditControls.EditBox ebWorkingAs;
    }
}