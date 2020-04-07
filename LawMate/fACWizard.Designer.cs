namespace LawMate
{
    partial class fACWizard
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
                fmCurrent.OnWarning -= new atLogic.WarningEventHandler(fmCurrent_OnWarning);
                this.activityBFBindingSource.CurrentChanged -= new System.EventHandler(this.activityBFBindingSource_CurrentChanged);

                ucDoc1.RecipientChanged -= new UserControls.RecipientChangedEventHandler(ucDoc1_RecipientChanged);
                ucDoc1.Dispose();

                this.timAutosave.Tick -= new System.EventHandler(this.timAutosave_Tick);
                timAutosave.Dispose();

                this.timer1.Tick -= new System.EventHandler(this.timer1_Tick);
                timer1.Dispose();

                components.Dispose();
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
            System.Windows.Forms.Label statusCodeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fACWizard));
            System.Windows.Forms.Label fileNumberLabel;
            System.Windows.Forms.Label openedDateLabel;
            System.Windows.Forms.Label fileTypeLabel;
            System.Windows.Forms.Label nameELabel;
            System.Windows.Forms.Label nameFLabel;
            System.Windows.Forms.Label activityCommentLabel;
            System.Windows.Forms.Label activityCodeLabel;
            System.Windows.Forms.Label officerCodeLabel;
            System.Windows.Forms.Label lblShortcutName;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label24;
            Janus.Windows.GridEX.GridEXLayout activityBFGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityBFGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.HeaderImage");
            Janus.Windows.GridEX.GridEXLayout disbursementGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout activityTimeGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.SuperTipSettings superTipSettings1 = new Janus.Windows.Common.SuperTipSettings();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlHelpText = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlHelpTextContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lblBFHelpImg = new System.Windows.Forms.Label();
            this.lblHelpText = new System.Windows.Forms.Label();
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBottom = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBottomContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.chkSkipDoc = new Janus.Windows.EditControls.UICheckBox();
            this.tbWizardTimer = new Janus.Windows.GridEX.EditControls.EditBox();
            this.buttonFinish = new Janus.Windows.EditControls.UIButton();
            this.buttonLast = new Janus.Windows.EditControls.UIButton();
            this.buttonNext = new Janus.Windows.EditControls.UIButton();
            this.buttonBack = new Janus.Windows.EditControls.UIButton();
            this.buttonCancel = new Janus.Windows.EditControls.UIButton();
            this.checkboxJumpToFile = new Janus.Windows.EditControls.UICheckBox();
            this.btnSuspendActivity = new Janus.Windows.EditControls.UIButton();
            this.pnlTabs = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlActivity = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lblNoCodeSelectedMessage = new System.Windows.Forms.Label();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabNextSteps = new Janus.Windows.UI.Tab.UITabPage();
            this.btnExpandCollapseNextSteps = new Janus.Windows.EditControls.UIButton();
            this.tvNextSteps = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uiTabEnabledProcesses = new Janus.Windows.UI.Tab.UITabPage();
            this.btnExpandCollapseEnabledProcesses = new Janus.Windows.EditControls.UIButton();
            this.tvEnabledProcesses = new System.Windows.Forms.TreeView();
            this.uiTabAlwaysAvailable = new Janus.Windows.UI.Tab.UITabPage();
            this.btnExpandCollapseAvailProcesses = new Janus.Windows.EditControls.UIButton();
            this.ExplorerBarAvailableProcesses = new System.Windows.Forms.TreeView();
            this.uiTabPage4 = new Janus.Windows.UI.Tab.UITabPage();
            this.ExplorerBarAllActivities = new System.Windows.Forms.TreeView();
            this.label14 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.ebACDescription = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tbJCode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnHelpTriangle = new Janus.Windows.EditControls.UIButton();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.lnkNextStepsProcesses = new System.Windows.Forms.LinkLabel();
            this.lnkAllActivities = new System.Windows.Forms.LinkLabel();
            this.pnlIssue = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlIssueContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ebPrimaryIssue = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uibtnRemoveSecondary = new Janus.Windows.EditControls.UIButton();
            this.uibtnAddSecondary = new Janus.Windows.EditControls.UIButton();
            this.uibtnRemovePrimary = new Janus.Windows.EditControls.UIButton();
            this.uibtnAddPrimary = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSecondary = new System.Windows.Forms.ListBox();
            this.ucBrowseIssues1 = new LawMate.UserControls.ucBrowseIssues();
            this.lblSelectIssue = new System.Windows.Forms.Label();
            this.pnlFile = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlFileContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrimaryIssueConfirm = new System.Windows.Forms.TextBox();
            this.lblPrimaryIssueConfirm = new System.Windows.Forms.Label();
            this.lblSecondaryIssueConfirm = new System.Windows.Forms.Label();
            this.listBoxSecondaryIssueConfirm = new System.Windows.Forms.ListBox();
            this.nameFTextBox = new System.Windows.Forms.TextBox();
            this.eFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.nameETextBox = new System.Windows.Forms.TextBox();
            this.fileTypeComboBox = new System.Windows.Forms.ComboBox();
            this.openedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.fileNumberTextBox = new System.Windows.Forms.TextBox();
            this.statusCodeComboBox = new System.Windows.Forms.ComboBox();
            this.pnlActivityConfirm = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityConfirmContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label13 = new System.Windows.Forms.Label();
            this.officerIdComboBox = new System.Windows.Forms.ComboBox();
            this.activityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ActivityDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.lblActivityDescription = new System.Windows.Forms.Label();
            this.lblActvityDate = new System.Windows.Forms.Label();
            this.activityCommentTextBox = new System.Windows.Forms.TextBox();
            this.activityCodeTextBox = new System.Windows.Forms.TextBox();
            this.activityDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.pnlRelatedFields = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlRelatedFieldsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label15 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTimeline = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTimelineContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucTimeline1 = new LawMate.ucTimeline();
            this.label16 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.pnlBF = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBFContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label17 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnAddNewBF = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu2 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.tsHelp = new Janus.Windows.UI.CommandBars.UICommand("tsHelp");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.activityBFGridEX = new Janus.Windows.GridEX.GridEX();
            this.activityBFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.pnlDisbursements = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDisbursementsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnAddNewDisb = new Janus.Windows.EditControls.UIButton();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.disbursementGridEX = new Janus.Windows.GridEX.GridEX();
            this.disbursementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBilling = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBillingContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lblDefaultHoursValue = new System.Windows.Forms.Label();
            this.lblDefaultHours = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.btnAddNewTime = new Janus.Windows.EditControls.UIButton();
            this.label9 = new System.Windows.Forms.Label();
            this.activityTimeGridEX = new Janus.Windows.GridEX.GridEX();
            this.activityTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlDocument = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocumentContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucDoc1 = new LawMate.UserControls.ucDoc();
            this.pnlConfirm = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlConfirmContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ucContactSelectBox1 = new LawMate.ucContactSelectBox();
            this.ebACComment = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox2 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.acCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.gbActivityShortcut = new Janus.Windows.EditControls.UIGroupBox();
            this.txtActivitySCName = new System.Windows.Forms.TextBox();
            this.cmdBrowseASC = new System.Windows.Forms.Button();
            this.lblASCDest = new System.Windows.Forms.Label();
            this.gbFileShortcut = new Janus.Windows.EditControls.UIGroupBox();
            this.txtFileSCName = new System.Windows.Forms.TextBox();
            this.cmdBrowseFSC = new System.Windows.Forms.Button();
            this.lblFSCDest = new System.Windows.Forms.Label();
            this.chkActivityShortcut = new System.Windows.Forms.CheckBox();
            this.chkFileShortcut = new System.Windows.Forms.CheckBox();
            this.pnlBFHelp = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBFHelpContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlWizBF = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlWizBFContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsHelp1 = new Janus.Windows.UI.CommandBars.UICommand("tsHelp");
            this.officeDB1 = new lmDatasets.officeDB();
            this.codesDB1 = new lmDatasets.CodesDB();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            this.timAutosave = new System.Windows.Forms.Timer(this.components);
            this.timFMHeartbeat = new System.Windows.Forms.Timer(this.components);
            this.timFocus = new System.Windows.Forms.Timer(this.components);
            statusCodeLabel = new System.Windows.Forms.Label();
            fileNumberLabel = new System.Windows.Forms.Label();
            openedDateLabel = new System.Windows.Forms.Label();
            fileTypeLabel = new System.Windows.Forms.Label();
            nameELabel = new System.Windows.Forms.Label();
            nameFLabel = new System.Windows.Forms.Label();
            activityCommentLabel = new System.Windows.Forms.Label();
            activityCodeLabel = new System.Windows.Forms.Label();
            officerCodeLabel = new System.Windows.Forms.Label();
            lblShortcutName = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHelpText)).BeginInit();
            this.pnlHelpText.SuspendLayout();
            this.pnlHelpTextContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTabs)).BeginInit();
            this.pnlTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivity)).BeginInit();
            this.pnlActivity.SuspendLayout();
            this.pnlActivityContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabNextSteps.SuspendLayout();
            this.uiTabEnabledProcesses.SuspendLayout();
            this.uiTabAlwaysAvailable.SuspendLayout();
            this.uiTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIssue)).BeginInit();
            this.pnlIssue.SuspendLayout();
            this.pnlIssueContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFile)).BeginInit();
            this.pnlFile.SuspendLayout();
            this.pnlFileContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityConfirm)).BeginInit();
            this.pnlActivityConfirm.SuspendLayout();
            this.pnlActivityConfirmContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRelatedFields)).BeginInit();
            this.pnlRelatedFields.SuspendLayout();
            this.pnlRelatedFieldsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeline)).BeginInit();
            this.pnlTimeline.SuspendLayout();
            this.pnlTimelineContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBF)).BeginInit();
            this.pnlBF.SuspendLayout();
            this.pnlBFContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDisbursements)).BeginInit();
            this.pnlDisbursements.SuspendLayout();
            this.pnlDisbursementsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBilling)).BeginInit();
            this.pnlBilling.SuspendLayout();
            this.pnlBillingContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocument)).BeginInit();
            this.pnlDocument.SuspendLayout();
            this.pnlDocumentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConfirm)).BeginInit();
            this.pnlConfirm.SuspendLayout();
            this.pnlConfirmContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbActivityShortcut)).BeginInit();
            this.gbActivityShortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbFileShortcut)).BeginInit();
            this.gbFileShortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBFHelp)).BeginInit();
            this.pnlBFHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWizBF)).BeginInit();
            this.pnlWizBF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codesDB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            this.SuspendLayout();
            // 
            // statusCodeLabel
            // 
            resources.ApplyResources(statusCodeLabel, "statusCodeLabel");
            statusCodeLabel.BackColor = System.Drawing.Color.Transparent;
            statusCodeLabel.Name = "statusCodeLabel";
            // 
            // fileNumberLabel
            // 
            resources.ApplyResources(fileNumberLabel, "fileNumberLabel");
            fileNumberLabel.BackColor = System.Drawing.Color.Transparent;
            fileNumberLabel.Name = "fileNumberLabel";
            // 
            // openedDateLabel
            // 
            resources.ApplyResources(openedDateLabel, "openedDateLabel");
            openedDateLabel.BackColor = System.Drawing.Color.Transparent;
            openedDateLabel.Name = "openedDateLabel";
            // 
            // fileTypeLabel
            // 
            resources.ApplyResources(fileTypeLabel, "fileTypeLabel");
            fileTypeLabel.BackColor = System.Drawing.Color.Transparent;
            fileTypeLabel.Name = "fileTypeLabel";
            // 
            // nameELabel
            // 
            resources.ApplyResources(nameELabel, "nameELabel");
            nameELabel.BackColor = System.Drawing.Color.Transparent;
            nameELabel.Name = "nameELabel";
            // 
            // nameFLabel
            // 
            resources.ApplyResources(nameFLabel, "nameFLabel");
            nameFLabel.BackColor = System.Drawing.Color.Transparent;
            nameFLabel.Name = "nameFLabel";
            // 
            // activityCommentLabel
            // 
            resources.ApplyResources(activityCommentLabel, "activityCommentLabel");
            activityCommentLabel.BackColor = System.Drawing.Color.Transparent;
            activityCommentLabel.Name = "activityCommentLabel";
            // 
            // activityCodeLabel
            // 
            resources.ApplyResources(activityCodeLabel, "activityCodeLabel");
            activityCodeLabel.BackColor = System.Drawing.Color.Transparent;
            activityCodeLabel.Name = "activityCodeLabel";
            // 
            // officerCodeLabel
            // 
            resources.ApplyResources(officerCodeLabel, "officerCodeLabel");
            officerCodeLabel.BackColor = System.Drawing.Color.Transparent;
            officerCodeLabel.Name = "officerCodeLabel";
            // 
            // lblShortcutName
            // 
            resources.ApplyResources(lblShortcutName, "lblShortcutName");
            lblShortcutName.BackColor = System.Drawing.Color.Transparent;
            lblShortcutName.Name = "lblShortcutName";
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.BackColor = System.Drawing.Color.Transparent;
            label25.Name = "label25";
            // 
            // label26
            // 
            resources.ApplyResources(label26, "label26");
            label26.BackColor = System.Drawing.Color.Transparent;
            label26.Name = "label26";
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.BackColor = System.Drawing.Color.Transparent;
            label27.Name = "label27";
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.BackColor = System.Drawing.Color.Transparent;
            label19.Name = "label19";
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.BackColor = System.Drawing.Color.Transparent;
            label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.Name = "label22";
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.BackColor = System.Drawing.Color.Transparent;
            label23.Name = "label23";
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.BackColor = System.Drawing.Color.Transparent;
            label24.Name = "label24";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlHelpText.Id = new System.Guid("6abe32a0-b8ec-44d2-829b-a1df572b1e7b");
            this.uiPanelManager1.Panels.Add(this.pnlHelpText);
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            this.pnlBottom.Id = new System.Guid("180c1357-8988-4c3a-a774-8c47d8f508e6");
            this.uiPanelManager1.Panels.Add(this.pnlBottom);
            this.pnlTabs.Id = new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872");
            this.pnlTabs.StaticGroup = true;
            this.pnlActivity.Id = new System.Guid("994813a6-10c0-4a0f-bad3-7d2d176205e6");
            this.pnlTabs.Panels.Add(this.pnlActivity);
            this.pnlIssue.Id = new System.Guid("e5f829a2-184b-4648-a206-e5a4c014b753");
            this.pnlTabs.Panels.Add(this.pnlIssue);
            this.pnlFile.Id = new System.Guid("a6a1df1b-2904-419d-b779-3e47542dfad5");
            this.pnlTabs.Panels.Add(this.pnlFile);
            this.pnlActivityConfirm.Id = new System.Guid("b38e1dc3-a8ba-40d4-8745-2535d02467a0");
            this.pnlTabs.Panels.Add(this.pnlActivityConfirm);
            this.pnlRelatedFields.Id = new System.Guid("6a8e2a73-3105-4a56-9821-f37d58724fc5");
            this.pnlTabs.Panels.Add(this.pnlRelatedFields);
            this.pnlTimeline.Id = new System.Guid("7d42d038-cd89-4d0c-8215-520a8e629594");
            this.pnlTabs.Panels.Add(this.pnlTimeline);
            this.pnlBF.Id = new System.Guid("bbea93ff-cb17-4416-ae97-a89e4417978b");
            this.pnlTabs.Panels.Add(this.pnlBF);
            this.pnlDisbursements.Id = new System.Guid("99f20eac-4c6b-4401-b198-40a7e6b71385");
            this.pnlTabs.Panels.Add(this.pnlDisbursements);
            this.pnlBilling.Id = new System.Guid("fcffcb56-6dcc-4391-8a23-a125ca1d90b3");
            this.pnlTabs.Panels.Add(this.pnlBilling);
            this.pnlDocument.Id = new System.Guid("1e36faf0-c48f-4c8e-a241-b28c335b04ea");
            this.pnlTabs.Panels.Add(this.pnlDocument);
            this.pnlConfirm.Id = new System.Guid("839f1e54-aa95-4e2a-9789-3be9f320d610");
            this.pnlTabs.Panels.Add(this.pnlConfirm);
            this.uiPanelManager1.Panels.Add(this.pnlTabs);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("6abe32a0-b8ec-44d2-829b-a1df572b1e7b"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(939, 55), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(939, 19), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("180c1357-8988-4c3a-a774-8c47d8f508e6"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(939, 50), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(939, 401), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("994813a6-10c0-4a0f-bad3-7d2d176205e6"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("e5f829a2-184b-4648-a206-e5a4c014b753"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a6a1df1b-2904-419d-b779-3e47542dfad5"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), 322, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b38e1dc3-a8ba-40d4-8745-2535d02467a0"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("6a8e2a73-3105-4a56-9821-f37d58724fc5"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7d42d038-cd89-4d0c-8215-520a8e629594"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("bbea93ff-cb17-4416-ae97-a89e4417978b"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("99f20eac-4c6b-4401-b198-40a7e6b71385"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("fcffcb56-6dcc-4391-8a23-a125ca1d90b3"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("1e36faf0-c48f-4c8e-a241-b28c335b04ea"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("839f1e54-aa95-4e2a-9789-3be9f320d610"), new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), -1, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("180c1357-8988-4c3a-a774-8c47d8f508e6"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("46e3d7ad-ba94-4477-a578-e65d24cee872"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("994813a6-10c0-4a0f-bad3-7d2d176205e6"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e5f829a2-184b-4648-a206-e5a4c014b753"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a6a1df1b-2904-419d-b779-3e47542dfad5"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b38e1dc3-a8ba-40d4-8745-2535d02467a0"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("6a8e2a73-3105-4a56-9821-f37d58724fc5"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("bbea93ff-cb17-4416-ae97-a89e4417978b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("99f20eac-4c6b-4401-b198-40a7e6b71385"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1e36faf0-c48f-4c8e-a241-b28c335b04ea"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("fcffcb56-6dcc-4391-8a23-a125ca1d90b3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("839f1e54-aa95-4e2a-9789-3be9f320d610"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("07790e8d-d8d6-419d-bc96-d7f9374a0d48"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("cdbb4d42-efe4-4994-9d67-743b358f81a3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("4f89c668-f3a8-4ce4-9a7d-a73e84c13ba8"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("6abe32a0-b8ec-44d2-829b-a1df572b1e7b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7d42d038-cd89-4d0c-8215-520a8e629594"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlHelpText
            // 
            this.pnlHelpText.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlHelpText, "pnlHelpText");
            this.pnlHelpText.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.UseFormatStyle;
            this.pnlHelpText.InnerContainer = this.pnlHelpTextContainer;
            this.pnlHelpText.InnerContainerFormatStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlHelpText.Name = "pnlHelpText";
            // 
            // pnlHelpTextContainer
            // 
            this.pnlHelpTextContainer.Controls.Add(this.lblBFHelpImg);
            this.pnlHelpTextContainer.Controls.Add(this.lblHelpText);
            resources.ApplyResources(this.pnlHelpTextContainer, "pnlHelpTextContainer");
            this.pnlHelpTextContainer.Name = "pnlHelpTextContainer";
            // 
            // lblBFHelpImg
            // 
            this.lblBFHelpImg.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblBFHelpImg, "lblBFHelpImg");
            this.lblBFHelpImg.Image = global::LawMate.Properties.Resources.note_icon;
            this.lblBFHelpImg.Name = "lblBFHelpImg";
            // 
            // lblHelpText
            // 
            resources.ApplyResources(this.lblHelpText, "lblHelpText");
            this.lblHelpText.BackColor = System.Drawing.Color.Transparent;
            this.lblHelpText.ForeColor = System.Drawing.Color.Blue;
            this.lblHelpText.Name = "lblHelpText";
            // 
            // pnlAll
            // 
            this.pnlAll.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlAll.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlAll.BorderPanelColor = System.Drawing.Color.Black;
            this.pnlAll.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlAll.CaptionFormatStyle.FontName = "arial";
            this.pnlAll.CaptionFormatStyle.FontSize = 8F;
            this.pnlAll.CaptionFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Standard;
            this.pnlAll.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlAll.ImageAlignment = Janus.Windows.UI.Dock.PanelImageAlignment.Near;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.Window;
            this.pnlAll.InnerContainerFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.pnlAll.Name = "pnlAll";
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Name = "pnlAllContainer";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlBottom.InnerContainer = this.pnlBottomContainer;
            this.pnlBottom.InnerContainerFormatStyle.Alpha = 255;
            this.pnlBottom.InnerContainerFormatStyle.BackColor = System.Drawing.Color.LightBlue;
            this.pnlBottom.InnerContainerFormatStyle.BackColorGradient = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // pnlBottomContainer
            // 
            this.pnlBottomContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this.pnlBottomContainer.Controls.Add(this.chkSkipDoc);
            this.pnlBottomContainer.Controls.Add(this.tbWizardTimer);
            this.pnlBottomContainer.Controls.Add(this.buttonFinish);
            this.pnlBottomContainer.Controls.Add(this.buttonLast);
            this.pnlBottomContainer.Controls.Add(this.buttonNext);
            this.pnlBottomContainer.Controls.Add(this.buttonBack);
            this.pnlBottomContainer.Controls.Add(this.buttonCancel);
            this.pnlBottomContainer.Controls.Add(this.checkboxJumpToFile);
            this.pnlBottomContainer.Controls.Add(this.btnSuspendActivity);
            resources.ApplyResources(this.pnlBottomContainer, "pnlBottomContainer");
            this.pnlBottomContainer.Name = "pnlBottomContainer";
            // 
            // chkSkipDoc
            // 
            resources.ApplyResources(this.chkSkipDoc, "chkSkipDoc");
            this.chkSkipDoc.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSkipDoc.BackColor = System.Drawing.Color.Transparent;
            this.chkSkipDoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSkipDoc.Image = global::LawMate.Properties.Resources.skipdocument;
            this.chkSkipDoc.Name = "chkSkipDoc";
            this.chkSkipDoc.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.chkSkipDoc.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.chkSkipDoc.CheckedChanged += new System.EventHandler(this.uiCheckBox1_CheckedChanged);
            // 
            // tbWizardTimer
            // 
            resources.ApplyResources(this.tbWizardTimer, "tbWizardTimer");
            this.tbWizardTimer.Name = "tbWizardTimer";
            this.tbWizardTimer.ReadOnly = true;
            this.tbWizardTimer.TabStop = false;
            this.tbWizardTimer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.tbWizardTimer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // buttonFinish
            // 
            resources.ApplyResources(this.buttonFinish, "buttonFinish");
            this.buttonFinish.HighlightActiveButton = false;
            this.buttonFinish.Image = global::LawMate.Properties.Resources.save1;
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // buttonLast
            // 
            resources.ApplyResources(this.buttonLast, "buttonLast");
            this.buttonLast.HighlightActiveButton = false;
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // buttonNext
            // 
            resources.ApplyResources(this.buttonNext, "buttonNext");
            this.buttonNext.HighlightActiveButton = false;
            this.buttonNext.Image = global::LawMate.Properties.Resources.arrow_right_green;
            this.buttonNext.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // buttonBack
            // 
            resources.ApplyResources(this.buttonBack, "buttonBack");
            this.buttonBack.HighlightActiveButton = false;
            this.buttonBack.Image = global::LawMate.Properties.Resources.arrow_left_green;
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.HighlightActiveButton = false;
            this.buttonCancel.Image = global::LawMate.Properties.Resources.StopCancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseCompatibleTextRendering = false;
            this.buttonCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkboxJumpToFile
            // 
            resources.ApplyResources(this.checkboxJumpToFile, "checkboxJumpToFile");
            this.checkboxJumpToFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkboxJumpToFile.BackColor = System.Drawing.Color.Transparent;
            this.checkboxJumpToFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkboxJumpToFile.Checked = true;
            this.checkboxJumpToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxJumpToFile.Image = global::LawMate.Properties.Resources.folder;
            this.checkboxJumpToFile.Name = "checkboxJumpToFile";
            this.checkboxJumpToFile.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.checkboxJumpToFile.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // btnSuspendActivity
            // 
            resources.ApplyResources(this.btnSuspendActivity, "btnSuspendActivity");
            this.btnSuspendActivity.HighlightActiveButton = false;
            this.btnSuspendActivity.Image = global::LawMate.Properties.Resources.pause1;
            this.btnSuspendActivity.Name = "btnSuspendActivity";
            this.btnSuspendActivity.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnSuspendActivity.Click += new System.EventHandler(this.btnSaveAsDraft_Click);
            // 
            // pnlTabs
            // 
            this.pnlTabs.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            resources.ApplyResources(this.pnlTabs, "pnlTabs");
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.SelectedPanel = this.pnlIssue;
            this.pnlTabs.TabAlignment = Janus.Windows.UI.Dock.TabAlignment.Top;
            this.pnlTabs.TabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.Text;
            this.pnlTabs.SelectedPanelChanged += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.pnlTabs_SelectedPanelChanged);
            // 
            // pnlActivity
            // 
            this.pnlActivity.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivity.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.pnlActivity.InnerContainer = this.pnlActivityContainer;
            resources.ApplyResources(this.pnlActivity, "pnlActivity");
            this.pnlActivity.Name = "pnlActivity";
            // 
            // pnlActivityContainer
            // 
            resources.ApplyResources(this.pnlActivityContainer, "pnlActivityContainer");
            this.pnlActivityContainer.Controls.Add(this.lblNoCodeSelectedMessage);
            this.pnlActivityContainer.Controls.Add(this.uiTab1);
            this.pnlActivityContainer.Controls.Add(this.label14);
            this.pnlActivityContainer.Controls.Add(this.label32);
            this.pnlActivityContainer.Controls.Add(this.ebACDescription);
            this.pnlActivityContainer.Controls.Add(this.tbJCode);
            this.pnlActivityContainer.Controls.Add(this.label1);
            this.pnlActivityContainer.Controls.Add(this.calDate);
            this.pnlActivityContainer.Controls.Add(this.lblCode);
            this.pnlActivityContainer.Controls.Add(this.lblDate);
            this.pnlActivityContainer.Controls.Add(this.btnHelpTriangle);
            this.pnlActivityContainer.Controls.Add(this.uiCheckBox1);
            this.pnlActivityContainer.Controls.Add(this.lnkNextStepsProcesses);
            this.pnlActivityContainer.Controls.Add(this.lnkAllActivities);
            this.pnlActivityContainer.Name = "pnlActivityContainer";
            // 
            // lblNoCodeSelectedMessage
            // 
            resources.ApplyResources(this.lblNoCodeSelectedMessage, "lblNoCodeSelectedMessage");
            this.lblNoCodeSelectedMessage.AutoEllipsis = true;
            this.lblNoCodeSelectedMessage.BackColor = System.Drawing.SystemColors.Window;
            this.lblNoCodeSelectedMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoCodeSelectedMessage.ForeColor = System.Drawing.Color.Red;
            this.lblNoCodeSelectedMessage.Image = global::LawMate.Properties.Resources.act;
            this.lblNoCodeSelectedMessage.Name = "lblNoCodeSelectedMessage";
            // 
            // uiTab1
            // 
            resources.ApplyResources(this.uiTab1, "uiTab1");
            this.uiTab1.BackColor = System.Drawing.Color.Transparent;
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.ShowFocusRectangle = false;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabNextSteps,
            this.uiTabEnabledProcesses,
            this.uiTabAlwaysAvailable,
            this.uiTabPage4});
            this.uiTab1.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab1.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabNextSteps
            // 
            this.uiTabNextSteps.Controls.Add(this.btnExpandCollapseNextSteps);
            this.uiTabNextSteps.Controls.Add(this.tvNextSteps);
            resources.ApplyResources(this.uiTabNextSteps, "uiTabNextSteps");
            this.uiTabNextSteps.Name = "uiTabNextSteps";
            this.uiTabNextSteps.TabStop = true;
            // 
            // btnExpandCollapseNextSteps
            // 
            resources.ApplyResources(this.btnExpandCollapseNextSteps, "btnExpandCollapseNextSteps");
            this.btnExpandCollapseNextSteps.Image = global::LawMate.Properties.Resources.ExpandAllSteps2;
            this.btnExpandCollapseNextSteps.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.btnExpandCollapseNextSteps.Name = "btnExpandCollapseNextSteps";
            this.btnExpandCollapseNextSteps.ShowFocusRectangle = false;
            this.btnExpandCollapseNextSteps.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnExpandCollapseNextSteps.Click += new System.EventHandler(this.btnExpandCollapseNextSteps_Click);
            // 
            // tvNextSteps
            // 
            resources.ApplyResources(this.tvNextSteps, "tvNextSteps");
            this.tvNextSteps.BackColor = System.Drawing.SystemColors.Window;
            this.tvNextSteps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvNextSteps.HideSelection = false;
            this.tvNextSteps.ImageList = this.imageList1;
            this.tvNextSteps.ItemHeight = 18;
            this.tvNextSteps.Name = "tvNextSteps";
            this.tvNextSteps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNextSteps_AfterSelect);
            this.tvNextSteps.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNextSteps_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "wfWait.gif");
            this.imageList1.Images.SetKeyName(1, "wfActivity.gif");
            this.imageList1.Images.SetKeyName(2, "wfBranch.gif");
            this.imageList1.Images.SetKeyName(3, "wfDecision.gif");
            this.imageList1.Images.SetKeyName(4, "wfEnd.gif");
            this.imageList1.Images.SetKeyName(5, "wfNoActivity.gif");
            this.imageList1.Images.SetKeyName(6, "wfStart.gif");
            this.imageList1.Images.SetKeyName(7, "wfSubProcess.gif");
            this.imageList1.Images.SetKeyName(8, "OfficeBF.gif");
            this.imageList1.Images.SetKeyName(9, "DirectBF.gif");
            this.imageList1.Images.SetKeyName(10, "RolesBF.gif");
            this.imageList1.Images.SetKeyName(11, "priorityNormal.gif");
            this.imageList1.Images.SetKeyName(12, "priorityHigh.gif");
            this.imageList1.Images.SetKeyName(13, "priorityUrgent.gif");
            this.imageList1.Images.SetKeyName(14, "RecipientOfficer2.gif");
            this.imageList1.Images.SetKeyName(15, "act.png");
            this.imageList1.Images.SetKeyName(16, "decision.png");
            this.imageList1.Images.SetKeyName(17, "nonrecorded.png");
            this.imageList1.Images.SetKeyName(18, "subprocess.png");
            this.imageList1.Images.SetKeyName(19, "workflow.png");
            this.imageList1.Images.SetKeyName(20, "automaticstep2.png");
            // 
            // uiTabEnabledProcesses
            // 
            this.uiTabEnabledProcesses.Controls.Add(this.btnExpandCollapseEnabledProcesses);
            this.uiTabEnabledProcesses.Controls.Add(this.tvEnabledProcesses);
            resources.ApplyResources(this.uiTabEnabledProcesses, "uiTabEnabledProcesses");
            this.uiTabEnabledProcesses.Name = "uiTabEnabledProcesses";
            this.uiTabEnabledProcesses.TabStop = true;
            // 
            // btnExpandCollapseEnabledProcesses
            // 
            resources.ApplyResources(this.btnExpandCollapseEnabledProcesses, "btnExpandCollapseEnabledProcesses");
            this.btnExpandCollapseEnabledProcesses.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExpandCollapseEnabledProcesses.Image = global::LawMate.Properties.Resources.ExpandAllSteps2;
            this.btnExpandCollapseEnabledProcesses.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.btnExpandCollapseEnabledProcesses.Name = "btnExpandCollapseEnabledProcesses";
            this.btnExpandCollapseEnabledProcesses.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.btnExpandCollapseEnabledProcesses.ShowFocusRectangle = false;
            this.btnExpandCollapseEnabledProcesses.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnExpandCollapseEnabledProcesses.Click += new System.EventHandler(this.btnExpandCollapseEnabledProcesses_Click);
            // 
            // tvEnabledProcesses
            // 
            resources.ApplyResources(this.tvEnabledProcesses, "tvEnabledProcesses");
            this.tvEnabledProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvEnabledProcesses.HideSelection = false;
            this.tvEnabledProcesses.ImageList = this.imageList1;
            this.tvEnabledProcesses.ItemHeight = 18;
            this.tvEnabledProcesses.Name = "tvEnabledProcesses";
            this.tvEnabledProcesses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNextSteps_AfterSelect);
            // 
            // uiTabAlwaysAvailable
            // 
            this.uiTabAlwaysAvailable.Controls.Add(this.btnExpandCollapseAvailProcesses);
            this.uiTabAlwaysAvailable.Controls.Add(this.ExplorerBarAvailableProcesses);
            resources.ApplyResources(this.uiTabAlwaysAvailable, "uiTabAlwaysAvailable");
            this.uiTabAlwaysAvailable.Name = "uiTabAlwaysAvailable";
            this.uiTabAlwaysAvailable.TabStop = true;
            // 
            // btnExpandCollapseAvailProcesses
            // 
            resources.ApplyResources(this.btnExpandCollapseAvailProcesses, "btnExpandCollapseAvailProcesses");
            this.btnExpandCollapseAvailProcesses.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnExpandCollapseAvailProcesses.Image = global::LawMate.Properties.Resources.ExpandAllSteps2;
            this.btnExpandCollapseAvailProcesses.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.btnExpandCollapseAvailProcesses.Name = "btnExpandCollapseAvailProcesses";
            this.btnExpandCollapseAvailProcesses.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.btnExpandCollapseAvailProcesses.ShowFocusRectangle = false;
            this.btnExpandCollapseAvailProcesses.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnExpandCollapseAvailProcesses.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // ExplorerBarAvailableProcesses
            // 
            resources.ApplyResources(this.ExplorerBarAvailableProcesses, "ExplorerBarAvailableProcesses");
            this.ExplorerBarAvailableProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExplorerBarAvailableProcesses.HideSelection = false;
            this.ExplorerBarAvailableProcesses.ImageList = this.imageList1;
            this.ExplorerBarAvailableProcesses.ItemHeight = 18;
            this.ExplorerBarAvailableProcesses.Name = "ExplorerBarAvailableProcesses";
            this.ExplorerBarAvailableProcesses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNextSteps_AfterSelect);
            this.ExplorerBarAvailableProcesses.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNextSteps_NodeMouseClick);
            // 
            // uiTabPage4
            // 
            this.uiTabPage4.Controls.Add(this.ExplorerBarAllActivities);
            resources.ApplyResources(this.uiTabPage4, "uiTabPage4");
            this.uiTabPage4.Name = "uiTabPage4";
            this.uiTabPage4.TabStop = true;
            // 
            // ExplorerBarAllActivities
            // 
            resources.ApplyResources(this.ExplorerBarAllActivities, "ExplorerBarAllActivities");
            this.ExplorerBarAllActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExplorerBarAllActivities.HideSelection = false;
            this.ExplorerBarAllActivities.ImageList = this.imageList1;
            this.ExplorerBarAllActivities.Name = "ExplorerBarAllActivities";
            this.ExplorerBarAllActivities.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNextSteps_AfterSelect);
            this.ExplorerBarAllActivities.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNextSteps_NodeMouseClick);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label14, "label14");
            this.label14.Image = global::LawMate.Properties.Resources.edit;
            this.label14.Name = "label14";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.ForeColor = System.Drawing.Color.Maroon;
            this.label32.Name = "label32";
            // 
            // ebACDescription
            // 
            resources.ApplyResources(this.ebACDescription, "ebACDescription");
            this.ebACDescription.BackColor = System.Drawing.SystemColors.Control;
            this.ebACDescription.Name = "ebACDescription";
            this.ebACDescription.ReadOnly = true;
            this.ebACDescription.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // tbJCode
            // 
            resources.ApplyResources(this.tbJCode, "tbJCode");
            this.tbJCode.Name = "tbJCode";
            this.tbJCode.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.tbJCode.TextChanged += new System.EventHandler(this.tbCode_TextChanged);
            this.tbJCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbJCode_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // calDate
            // 
            resources.ApplyResources(this.calDate, "calDate");
            this.calDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calDate.DropDownCalendar.FirstMonth = new System.DateTime(2007, 1, 1, 0, 0, 0, 0);
            this.calDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calDate.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calDate.MonthIncrement = 0;
            this.calDate.Name = "calDate";
            this.calDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calDate.YearIncrement = 0;
            // 
            // lblCode
            // 
            resources.ApplyResources(this.lblCode, "lblCode");
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Name = "lblCode";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Name = "lblDate";
            // 
            // btnHelpTriangle
            // 
            this.btnHelpTriangle.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnHelpTriangle.Image = global::LawMate.Properties.Resources.deskbook;
            resources.ApplyResources(this.btnHelpTriangle, "btnHelpTriangle");
            this.btnHelpTriangle.Name = "btnHelpTriangle";
            this.btnHelpTriangle.ShowFocusRectangle = false;
            this.btnHelpTriangle.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Empty;
            this.btnHelpTriangle.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnHelpTriangle.WordWrap = false;
            this.btnHelpTriangle.Click += new System.EventHandler(this.lblHelpClick_Click);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.uiCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox1.Image = global::LawMate.Properties.Resources.skipdocument;
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiCheckBox1.CheckedChanged += new System.EventHandler(this.uiCheckBox1_CheckedChanged);
            // 
            // lnkNextStepsProcesses
            // 
            resources.ApplyResources(this.lnkNextStepsProcesses, "lnkNextStepsProcesses");
            this.lnkNextStepsProcesses.BackColor = System.Drawing.Color.Transparent;
            this.lnkNextStepsProcesses.Name = "lnkNextStepsProcesses";
            this.lnkNextStepsProcesses.TabStop = true;
            // 
            // lnkAllActivities
            // 
            resources.ApplyResources(this.lnkAllActivities, "lnkAllActivities");
            this.lnkAllActivities.BackColor = System.Drawing.Color.Transparent;
            this.lnkAllActivities.Name = "lnkAllActivities";
            this.lnkAllActivities.TabStop = true;
            // 
            // pnlIssue
            // 
            this.pnlIssue.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlIssue.InnerContainer = this.pnlIssueContainer;
            resources.ApplyResources(this.pnlIssue, "pnlIssue");
            this.pnlIssue.Name = "pnlIssue";
            // 
            // pnlIssueContainer
            // 
            resources.ApplyResources(this.pnlIssueContainer, "pnlIssueContainer");
            this.pnlIssueContainer.Controls.Add(this.label10);
            this.pnlIssueContainer.Controls.Add(this.label11);
            this.pnlIssueContainer.Controls.Add(this.ebPrimaryIssue);
            this.pnlIssueContainer.Controls.Add(this.uibtnRemoveSecondary);
            this.pnlIssueContainer.Controls.Add(this.uibtnAddSecondary);
            this.pnlIssueContainer.Controls.Add(this.uibtnRemovePrimary);
            this.pnlIssueContainer.Controls.Add(this.uibtnAddPrimary);
            this.pnlIssueContainer.Controls.Add(this.label3);
            this.pnlIssueContainer.Controls.Add(this.label2);
            this.pnlIssueContainer.Controls.Add(this.listBoxSecondary);
            this.pnlIssueContainer.Controls.Add(this.ucBrowseIssues1);
            this.pnlIssueContainer.Controls.Add(this.lblSelectIssue);
            this.pnlIssueContainer.Name = "pnlIssueContainer";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Image = global::LawMate.Properties.Resources.issue;
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Name = "label11";
            // 
            // ebPrimaryIssue
            // 
            resources.ApplyResources(this.ebPrimaryIssue, "ebPrimaryIssue");
            this.ebPrimaryIssue.BackColor = System.Drawing.SystemColors.Control;
            this.ebPrimaryIssue.Multiline = true;
            this.ebPrimaryIssue.Name = "ebPrimaryIssue";
            this.ebPrimaryIssue.ReadOnly = true;
            this.ebPrimaryIssue.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
            // 
            // uibtnRemoveSecondary
            // 
            resources.ApplyResources(this.uibtnRemoveSecondary, "uibtnRemoveSecondary");
            this.uibtnRemoveSecondary.Image = global::LawMate.Properties.Resources.arrow_left_green;
            this.uibtnRemoveSecondary.Name = "uibtnRemoveSecondary";
            this.uibtnRemoveSecondary.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uibtnRemoveSecondary.Click += new System.EventHandler(this.btnRemoveSecondary_Click);
            // 
            // uibtnAddSecondary
            // 
            resources.ApplyResources(this.uibtnAddSecondary, "uibtnAddSecondary");
            this.uibtnAddSecondary.Image = global::LawMate.Properties.Resources.arrow_right_green;
            this.uibtnAddSecondary.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uibtnAddSecondary.Name = "uibtnAddSecondary";
            this.uibtnAddSecondary.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uibtnAddSecondary.Click += new System.EventHandler(this.btnAddSecondary_Click);
            // 
            // uibtnRemovePrimary
            // 
            resources.ApplyResources(this.uibtnRemovePrimary, "uibtnRemovePrimary");
            this.uibtnRemovePrimary.Image = global::LawMate.Properties.Resources.arrow_left_green;
            this.uibtnRemovePrimary.Name = "uibtnRemovePrimary";
            this.uibtnRemovePrimary.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uibtnRemovePrimary.Click += new System.EventHandler(this.btnRemovePrimary_Click);
            // 
            // uibtnAddPrimary
            // 
            resources.ApplyResources(this.uibtnAddPrimary, "uibtnAddPrimary");
            this.uibtnAddPrimary.Image = global::LawMate.Properties.Resources.arrow_right_green;
            this.uibtnAddPrimary.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            this.uibtnAddPrimary.Name = "uibtnAddPrimary";
            this.uibtnAddPrimary.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uibtnAddPrimary.Click += new System.EventHandler(this.btnAddPrimary_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // listBoxSecondary
            // 
            resources.ApplyResources(this.listBoxSecondary, "listBoxSecondary");
            this.listBoxSecondary.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxSecondary.FormattingEnabled = true;
            this.listBoxSecondary.Name = "listBoxSecondary";
            // 
            // ucBrowseIssues1
            // 
            resources.ApplyResources(this.ucBrowseIssues1, "ucBrowseIssues1");
            this.ucBrowseIssues1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucBrowseIssues1.Name = "ucBrowseIssues1";
            // 
            // lblSelectIssue
            // 
            resources.ApplyResources(this.lblSelectIssue, "lblSelectIssue");
            this.lblSelectIssue.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectIssue.Name = "lblSelectIssue";
            // 
            // pnlFile
            // 
            this.pnlFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlFile.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlFile.InnerContainer = this.pnlFileContainer;
            resources.ApplyResources(this.pnlFile, "pnlFile");
            this.pnlFile.Name = "pnlFile";
            // 
            // pnlFileContainer
            // 
            resources.ApplyResources(this.pnlFileContainer, "pnlFileContainer");
            this.pnlFileContainer.Controls.Add(this.label12);
            this.pnlFileContainer.Controls.Add(this.label4);
            this.pnlFileContainer.Controls.Add(this.tbPrimaryIssueConfirm);
            this.pnlFileContainer.Controls.Add(this.lblPrimaryIssueConfirm);
            this.pnlFileContainer.Controls.Add(this.lblSecondaryIssueConfirm);
            this.pnlFileContainer.Controls.Add(this.listBoxSecondaryIssueConfirm);
            this.pnlFileContainer.Controls.Add(nameFLabel);
            this.pnlFileContainer.Controls.Add(this.nameFTextBox);
            this.pnlFileContainer.Controls.Add(nameELabel);
            this.pnlFileContainer.Controls.Add(this.nameETextBox);
            this.pnlFileContainer.Controls.Add(fileTypeLabel);
            this.pnlFileContainer.Controls.Add(this.fileTypeComboBox);
            this.pnlFileContainer.Controls.Add(openedDateLabel);
            this.pnlFileContainer.Controls.Add(this.openedDateCalendarCombo);
            this.pnlFileContainer.Controls.Add(fileNumberLabel);
            this.pnlFileContainer.Controls.Add(this.fileNumberTextBox);
            this.pnlFileContainer.Controls.Add(statusCodeLabel);
            this.pnlFileContainer.Controls.Add(this.statusCodeComboBox);
            this.pnlFileContainer.Name = "pnlFileContainer";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Name = "label12";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // tbPrimaryIssueConfirm
            // 
            this.tbPrimaryIssueConfirm.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tbPrimaryIssueConfirm, "tbPrimaryIssueConfirm");
            this.tbPrimaryIssueConfirm.Name = "tbPrimaryIssueConfirm";
            this.tbPrimaryIssueConfirm.ReadOnly = true;
            // 
            // lblPrimaryIssueConfirm
            // 
            resources.ApplyResources(this.lblPrimaryIssueConfirm, "lblPrimaryIssueConfirm");
            this.lblPrimaryIssueConfirm.BackColor = System.Drawing.Color.Transparent;
            this.lblPrimaryIssueConfirm.Name = "lblPrimaryIssueConfirm";
            // 
            // lblSecondaryIssueConfirm
            // 
            resources.ApplyResources(this.lblSecondaryIssueConfirm, "lblSecondaryIssueConfirm");
            this.lblSecondaryIssueConfirm.BackColor = System.Drawing.Color.Transparent;
            this.lblSecondaryIssueConfirm.Name = "lblSecondaryIssueConfirm";
            // 
            // listBoxSecondaryIssueConfirm
            // 
            resources.ApplyResources(this.listBoxSecondaryIssueConfirm, "listBoxSecondaryIssueConfirm");
            this.listBoxSecondaryIssueConfirm.FormattingEnabled = true;
            this.listBoxSecondaryIssueConfirm.Name = "listBoxSecondaryIssueConfirm";
            // 
            // nameFTextBox
            // 
            this.nameFTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "NameF", true));
            resources.ApplyResources(this.nameFTextBox, "nameFTextBox");
            this.nameFTextBox.Name = "nameFTextBox";
            // 
            // eFileBindingSource
            // 
            this.eFileBindingSource.DataMember = "EFile";
            this.eFileBindingSource.DataSource = this.atriumDB;
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // nameETextBox
            // 
            this.nameETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "NameE", true));
            resources.ApplyResources(this.nameETextBox, "nameETextBox");
            this.nameETextBox.Name = "nameETextBox";
            // 
            // fileTypeComboBox
            // 
            this.fileTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "FileType", true));
            this.fileTypeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.fileTypeComboBox, "fileTypeComboBox");
            this.fileTypeComboBox.Name = "fileTypeComboBox";
            // 
            // openedDateCalendarCombo
            // 
            resources.ApplyResources(this.openedDateCalendarCombo, "openedDateCalendarCombo");
            this.openedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "OpenedDate", true));
            // 
            // 
            // 
            this.openedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.openedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.openedDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.openedDateCalendarCombo.Name = "openedDateCalendarCombo";
            this.openedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // fileNumberTextBox
            // 
            this.fileNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "FileNumber", true));
            resources.ApplyResources(this.fileNumberTextBox, "fileNumberTextBox");
            this.fileNumberTextBox.Name = "fileNumberTextBox";
            // 
            // statusCodeComboBox
            // 
            this.statusCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "StatusCode", true));
            this.statusCodeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.statusCodeComboBox, "statusCodeComboBox");
            this.statusCodeComboBox.Name = "statusCodeComboBox";
            // 
            // pnlActivityConfirm
            // 
            this.pnlActivityConfirm.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivityConfirm.InnerContainer = this.pnlActivityConfirmContainer;
            resources.ApplyResources(this.pnlActivityConfirm, "pnlActivityConfirm");
            this.pnlActivityConfirm.Name = "pnlActivityConfirm";
            // 
            // pnlActivityConfirmContainer
            // 
            resources.ApplyResources(this.pnlActivityConfirmContainer, "pnlActivityConfirmContainer");
            this.pnlActivityConfirmContainer.Controls.Add(this.label13);
            this.pnlActivityConfirmContainer.Controls.Add(this.officerIdComboBox);
            this.pnlActivityConfirmContainer.Controls.Add(this.label5);
            this.pnlActivityConfirmContainer.Controls.Add(this.ActivityDescriptionTextBox);
            this.pnlActivityConfirmContainer.Controls.Add(this.lblActivityDescription);
            this.pnlActivityConfirmContainer.Controls.Add(this.lblActvityDate);
            this.pnlActivityConfirmContainer.Controls.Add(activityCommentLabel);
            this.pnlActivityConfirmContainer.Controls.Add(this.activityCommentTextBox);
            this.pnlActivityConfirmContainer.Controls.Add(activityCodeLabel);
            this.pnlActivityConfirmContainer.Controls.Add(this.activityCodeTextBox);
            this.pnlActivityConfirmContainer.Controls.Add(this.activityDateCalendarCombo);
            this.pnlActivityConfirmContainer.Controls.Add(officerCodeLabel);
            this.pnlActivityConfirmContainer.Name = "pnlActivityConfirmContainer";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Name = "label13";
            // 
            // officerIdComboBox
            // 
            this.officerIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.activityBindingSource, "OfficerId", true));
            this.officerIdComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.officerIdComboBox, "officerIdComboBox");
            this.officerIdComboBox.Name = "officerIdComboBox";
            // 
            // activityBindingSource
            // 
            this.activityBindingSource.DataMember = "Activity";
            this.activityBindingSource.DataSource = this.atriumDB;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ActivityDescriptionTextBox
            // 
            this.ActivityDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "ActivityNameEng", true));
            resources.ApplyResources(this.ActivityDescriptionTextBox, "ActivityDescriptionTextBox");
            this.ActivityDescriptionTextBox.Name = "ActivityDescriptionTextBox";
            this.ActivityDescriptionTextBox.ReadOnly = true;
            // 
            // lblActivityDescription
            // 
            resources.ApplyResources(this.lblActivityDescription, "lblActivityDescription");
            this.lblActivityDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblActivityDescription.Name = "lblActivityDescription";
            // 
            // lblActvityDate
            // 
            resources.ApplyResources(this.lblActvityDate, "lblActvityDate");
            this.lblActvityDate.BackColor = System.Drawing.Color.Transparent;
            this.lblActvityDate.Name = "lblActvityDate";
            // 
            // activityCommentTextBox
            // 
            this.activityCommentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "ActivityComment", true));
            resources.ApplyResources(this.activityCommentTextBox, "activityCommentTextBox");
            this.activityCommentTextBox.Name = "activityCommentTextBox";
            // 
            // activityCodeTextBox
            // 
            this.activityCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "StepCode", true));
            resources.ApplyResources(this.activityCodeTextBox, "activityCodeTextBox");
            this.activityCodeTextBox.Name = "activityCodeTextBox";
            this.activityCodeTextBox.ReadOnly = true;
            // 
            // activityDateCalendarCombo
            // 
            this.activityDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.activityDateCalendarCombo, "activityDateCalendarCombo");
            this.activityDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBindingSource, "ActivityDate", true));
            // 
            // 
            // 
            this.activityDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.activityDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.activityDateCalendarCombo.Name = "activityDateCalendarCombo";
            this.activityDateCalendarCombo.ReadOnly = true;
            // 
            // pnlRelatedFields
            // 
            this.pnlRelatedFields.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlRelatedFields.InnerContainer = this.pnlRelatedFieldsContainer;
            resources.ApplyResources(this.pnlRelatedFields, "pnlRelatedFields");
            this.pnlRelatedFields.Name = "pnlRelatedFields";
            // 
            // pnlRelatedFieldsContainer
            // 
            resources.ApplyResources(this.pnlRelatedFieldsContainer, "pnlRelatedFieldsContainer");
            this.pnlRelatedFieldsContainer.Controls.Add(this.label15);
            this.pnlRelatedFieldsContainer.Controls.Add(this.label31);
            this.pnlRelatedFieldsContainer.Controls.Add(this.label6);
            this.pnlRelatedFieldsContainer.Controls.Add(this.flowLayoutPanel1);
            this.pnlRelatedFieldsContainer.Name = "pnlRelatedFieldsContainer";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label15, "label15");
            this.label15.Image = global::LawMate.Properties.Resources.section;
            this.label15.Name = "label15";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.ForeColor = System.Drawing.Color.Maroon;
            this.label31.Name = "label31";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // pnlTimeline
            // 
            this.pnlTimeline.InnerContainer = this.pnlTimelineContainer;
            resources.ApplyResources(this.pnlTimeline, "pnlTimeline");
            this.pnlTimeline.Name = "pnlTimeline";
            // 
            // pnlTimelineContainer
            // 
            resources.ApplyResources(this.pnlTimelineContainer, "pnlTimelineContainer");
            this.pnlTimelineContainer.Controls.Add(this.ucTimeline1);
            this.pnlTimelineContainer.Controls.Add(this.label16);
            this.pnlTimelineContainer.Controls.Add(this.label35);
            this.pnlTimelineContainer.Controls.Add(this.label36);
            this.pnlTimelineContainer.Name = "pnlTimelineContainer";
            // 
            // ucTimeline1
            // 
            resources.ApplyResources(this.ucTimeline1, "ucTimeline1");
            this.ucTimeline1.BackColor = System.Drawing.Color.Transparent;
            this.ucTimeline1.Name = "ucTimeline1";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label16, "label16");
            this.label16.Image = global::LawMate.Properties.Resources.Calendar;
            this.label16.Name = "label16";
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.ForeColor = System.Drawing.Color.Maroon;
            this.label35.Name = "label35";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Name = "label36";
            // 
            // pnlBF
            // 
            this.pnlBF.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBF.InnerContainer = this.pnlBFContainer;
            resources.ApplyResources(this.pnlBF, "pnlBF");
            this.pnlBF.Name = "pnlBF";
            // 
            // pnlBFContainer
            // 
            resources.ApplyResources(this.pnlBFContainer, "pnlBFContainer");
            this.pnlBFContainer.Controls.Add(this.label17);
            this.pnlBFContainer.Controls.Add(this.label30);
            this.pnlBFContainer.Controls.Add(this.btnAddNewBF);
            this.pnlBFContainer.Controls.Add(this.activityBFGridEX);
            this.pnlBFContainer.Controls.Add(this.label7);
            this.pnlBFContainer.Name = "pnlBFContainer";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label17, "label17");
            this.label17.Image = global::LawMate.Properties.Resources.calendar_icon;
            this.label17.Name = "label17";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.ForeColor = System.Drawing.Color.Maroon;
            this.label30.Name = "label30";
            // 
            // btnAddNewBF
            // 
            this.btnAddNewBF.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.btnAddNewBF.DropDownContextMenu = this.uiContextMenu2;
            this.btnAddNewBF.Image = global::LawMate.Properties.Resources.calendar_icon;
            this.btnAddNewBF.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnAddNewBF, "btnAddNewBF");
            this.btnAddNewBF.Name = "btnAddNewBF";
            this.btnAddNewBF.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnAddNewBF.Click += new System.EventHandler(this.btnNewBF_Click);
            // 
            // uiContextMenu2
            // 
            this.uiContextMenu2.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.uiContextMenu2, "uiContextMenu2");
            this.uiContextMenu2.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu2.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsHelp});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu2});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("d277909a-e0c1-48e7-8946-65e96d985f31");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
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
            // tsHelp
            // 
            this.tsHelp.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsHelp.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.tsHelp, "tsHelp");
            this.tsHelp.Name = "tsHelp";
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
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // activityBFGridEX
            // 
            this.activityBFGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.activityBFGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.activityBFGridEX.DataSource = this.activityBFBindingSource;
            activityBFGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("activityBFGridEX_DesignTimeLayout_Reference_0.Instance")));
            activityBFGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityBFGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(activityBFGridEX_DesignTimeLayout, "activityBFGridEX_DesignTimeLayout");
            this.activityBFGridEX.DesignTimeLayout = activityBFGridEX_DesignTimeLayout;
            this.activityBFGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.activityBFGridEX, "activityBFGridEX");
            this.activityBFGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.activityBFGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityBFGridEX.GroupByBoxVisible = false;
            this.activityBFGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.activityBFGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.activityBFGridEX.ImageList = this.imageList1;
            this.activityBFGridEX.Name = "activityBFGridEX";
            this.activityBFGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.activityBFGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.activityBFGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityBFGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityBFGridEX.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.activityBFGridEX_DeletingRecord);
            this.activityBFGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityBFGridEX_LoadingRow);
            this.activityBFGridEX.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityBFGridEX_CellUpdated);
            this.activityBFGridEX.SelectionChanged += new System.EventHandler(this.activityBFGridEX_SelectionChanged);
            // 
            // activityBFBindingSource
            // 
            this.activityBFBindingSource.DataMember = "Activity_ActivityBF";
            this.activityBFBindingSource.DataSource = this.activityBindingSource;
            this.activityBFBindingSource.Filter = "isMail=0";
            this.activityBFBindingSource.CurrentChanged += new System.EventHandler(this.activityBFBindingSource_CurrentChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            // 
            // pnlDisbursements
            // 
            this.pnlDisbursements.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDisbursements.InnerContainer = this.pnlDisbursementsContainer;
            resources.ApplyResources(this.pnlDisbursements, "pnlDisbursements");
            this.pnlDisbursements.Name = "pnlDisbursements";
            // 
            // pnlDisbursementsContainer
            // 
            resources.ApplyResources(this.pnlDisbursementsContainer, "pnlDisbursementsContainer");
            this.pnlDisbursementsContainer.Controls.Add(this.btnAddNewDisb);
            this.pnlDisbursementsContainer.Controls.Add(this.label33);
            this.pnlDisbursementsContainer.Controls.Add(this.label34);
            this.pnlDisbursementsContainer.Controls.Add(this.label8);
            this.pnlDisbursementsContainer.Controls.Add(this.disbursementGridEX);
            this.pnlDisbursementsContainer.Name = "pnlDisbursementsContainer";
            // 
            // btnAddNewDisb
            // 
            this.btnAddNewDisb.Image = global::LawMate.Properties.Resources.disb;
            this.btnAddNewDisb.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnAddNewDisb, "btnAddNewDisb");
            this.btnAddNewDisb.Name = "btnAddNewDisb";
            this.btnAddNewDisb.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnAddNewDisb.Click += new System.EventHandler(this.btnAddNewDisb_Click);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label33, "label33");
            this.label33.Image = global::LawMate.Properties.Resources.disb;
            this.label33.Name = "label33";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.ForeColor = System.Drawing.Color.Maroon;
            this.label34.Name = "label34";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Name = "label8";
            // 
            // disbursementGridEX
            // 
            this.disbursementGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.disbursementGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.disbursementGridEX.DataSource = this.disbursementBindingSource;
            resources.ApplyResources(disbursementGridEX_DesignTimeLayout, "disbursementGridEX_DesignTimeLayout");
            this.disbursementGridEX.DesignTimeLayout = disbursementGridEX_DesignTimeLayout;
            this.disbursementGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.disbursementGridEX, "disbursementGridEX");
            this.disbursementGridEX.GridLineColor = System.Drawing.SystemColors.ControlLight;
            this.disbursementGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.disbursementGridEX.GroupByBoxVisible = false;
            this.disbursementGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.disbursementGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.disbursementGridEX.Name = "disbursementGridEX";
            this.disbursementGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.disbursementGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.disbursementGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.disbursementGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.disbursementGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.disbursementGridEX.DeletingRecords += new System.ComponentModel.CancelEventHandler(this.disbursementGridEX_DeletingRecords);
            // 
            // disbursementBindingSource
            // 
            this.disbursementBindingSource.DataMember = "ActivityDisbursement";
            this.disbursementBindingSource.DataSource = this.activityBindingSource;
            // 
            // pnlBilling
            // 
            this.pnlBilling.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBilling.InnerContainer = this.pnlBillingContainer;
            resources.ApplyResources(this.pnlBilling, "pnlBilling");
            this.pnlBilling.Name = "pnlBilling";
            // 
            // pnlBillingContainer
            // 
            resources.ApplyResources(this.pnlBillingContainer, "pnlBillingContainer");
            this.pnlBillingContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBillingContainer.Controls.Add(this.lblDefaultHoursValue);
            this.pnlBillingContainer.Controls.Add(this.lblDefaultHours);
            this.pnlBillingContainer.Controls.Add(this.label28);
            this.pnlBillingContainer.Controls.Add(this.label29);
            this.pnlBillingContainer.Controls.Add(this.btnAddNewTime);
            this.pnlBillingContainer.Controls.Add(this.label9);
            this.pnlBillingContainer.Controls.Add(this.activityTimeGridEX);
            this.pnlBillingContainer.Name = "pnlBillingContainer";
            // 
            // lblDefaultHoursValue
            // 
            resources.ApplyResources(this.lblDefaultHoursValue, "lblDefaultHoursValue");
            this.lblDefaultHoursValue.BackColor = System.Drawing.Color.Transparent;
            this.lblDefaultHoursValue.Name = "lblDefaultHoursValue";
            // 
            // lblDefaultHours
            // 
            resources.ApplyResources(this.lblDefaultHours, "lblDefaultHours");
            this.lblDefaultHours.BackColor = System.Drawing.Color.Transparent;
            this.lblDefaultHours.Name = "lblDefaultHours";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label28, "label28");
            this.label28.Image = global::LawMate.Properties.Resources.clock;
            this.label28.Name = "label28";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.ForeColor = System.Drawing.Color.Maroon;
            this.label29.Name = "label29";
            // 
            // btnAddNewTime
            // 
            this.btnAddNewTime.Image = global::LawMate.Properties.Resources.clock;
            this.btnAddNewTime.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnAddNewTime, "btnAddNewTime");
            this.btnAddNewTime.Name = "btnAddNewTime";
            this.btnAddNewTime.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnAddNewTime.Click += new System.EventHandler(this.btnNewActivityTime_Click);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Name = "label9";
            // 
            // activityTimeGridEX
            // 
            this.activityTimeGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.activityTimeGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.activityTimeGridEX.DataSource = this.activityTimeBindingSource;
            resources.ApplyResources(activityTimeGridEX_DesignTimeLayout, "activityTimeGridEX_DesignTimeLayout");
            this.activityTimeGridEX.DesignTimeLayout = activityTimeGridEX_DesignTimeLayout;
            this.activityTimeGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.activityTimeGridEX, "activityTimeGridEX");
            this.activityTimeGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.activityTimeGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityTimeGridEX.GroupByBoxVisible = false;
            this.activityTimeGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.activityTimeGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.activityTimeGridEX.Name = "activityTimeGridEX";
            this.activityTimeGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.activityTimeGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityTimeGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.activityTimeGridEX.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.activityTimeGridEX.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.activityTimeGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityTimeGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityTimeGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityTimeGridEX_FormattingRow);
            this.activityTimeGridEX.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityTimeGridEX_CellUpdated);
            this.activityTimeGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityTimeGridEX_ColumnButtonClick);
            this.activityTimeGridEX.EnabledChanged += new System.EventHandler(this.activityTimeGridEX_EnabledChanged);
            // 
            // activityTimeBindingSource
            // 
            this.activityTimeBindingSource.DataMember = "ActivityActivityTime";
            this.activityTimeBindingSource.DataSource = this.activityBindingSource;
            // 
            // pnlDocument
            // 
            this.pnlDocument.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDocument.InnerContainer = this.pnlDocumentContainer;
            resources.ApplyResources(this.pnlDocument, "pnlDocument");
            this.pnlDocument.Name = "pnlDocument";
            // 
            // pnlDocumentContainer
            // 
            this.pnlDocumentContainer.Controls.Add(this.ucDoc1);
            resources.ApplyResources(this.pnlDocumentContainer, "pnlDocumentContainer");
            this.pnlDocumentContainer.Name = "pnlDocumentContainer";
            // 
            // ucDoc1
            // 
            this.ucDoc1.AllowActionToolbar = false;
            this.ucDoc1.AllowRecipientSubjectEditWhenNotMail = true;
            this.ucDoc1.AllowUserCompose = true;
            this.ucDoc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            resources.ApplyResources(this.ucDoc1, "ucDoc1");
            this.ucDoc1.EditMode = LawMate.UserControls.ucDoc.EditModeEnum.Compose;
            this.ucDoc1.ForceTextControl = false;
            this.ucDoc1.IsManageTemplates = false;
            this.ucDoc1.Name = "ucDoc1";
            this.ucDoc1.NoDocDisplayed = false;
            this.ucDoc1.ShowAttachmentPanel = false;
            this.ucDoc1.ShowComposeToolbar = true;
            this.ucDoc1.ShowFromAndDate = false;
            this.ucDoc1.ShowRecipients = true;
            this.ucDoc1.ShowSubject = true;
            this.ucDoc1.ShowTabs = false;
            this.ucDoc1.TempFile = null;
            this.ucDoc1.TempFld = null;
            // 
            // pnlConfirm
            // 
            this.pnlConfirm.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlConfirm.InnerContainer = this.pnlConfirmContainer;
            resources.ApplyResources(this.pnlConfirm, "pnlConfirm");
            this.pnlConfirm.Name = "pnlConfirm";
            // 
            // pnlConfirmContainer
            // 
            resources.ApplyResources(this.pnlConfirmContainer, "pnlConfirmContainer");
            this.pnlConfirmContainer.Controls.Add(this.label18);
            this.pnlConfirmContainer.Controls.Add(this.label20);
            this.pnlConfirmContainer.Controls.Add(label24);
            this.pnlConfirmContainer.Controls.Add(this.ucContactSelectBox1);
            this.pnlConfirmContainer.Controls.Add(label23);
            this.pnlConfirmContainer.Controls.Add(label22);
            this.pnlConfirmContainer.Controls.Add(label21);
            this.pnlConfirmContainer.Controls.Add(label19);
            this.pnlConfirmContainer.Controls.Add(this.ebACComment);
            this.pnlConfirmContainer.Controls.Add(this.editBox2);
            this.pnlConfirmContainer.Controls.Add(this.editBox1);
            this.pnlConfirmContainer.Controls.Add(this.calendarCombo1);
            this.pnlConfirmContainer.Controls.Add(this.acCommentCounter);
            this.pnlConfirmContainer.Controls.Add(this.gbActivityShortcut);
            this.pnlConfirmContainer.Controls.Add(this.gbFileShortcut);
            this.pnlConfirmContainer.Controls.Add(this.chkActivityShortcut);
            this.pnlConfirmContainer.Controls.Add(this.chkFileShortcut);
            this.pnlConfirmContainer.Name = "pnlConfirmContainer";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label18, "label18");
            this.label18.Image = global::LawMate.Properties.Resources.save1;
            this.label18.Name = "label18";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.Color.Maroon;
            this.label20.Name = "label20";
            // 
            // ucContactSelectBox1
            // 
            this.ucContactSelectBox1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucContactSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox1.ContactId = null;
            this.ucContactSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.activityBindingSource, "OfficerId", true));
            this.ucContactSelectBox1.FM = null;
            resources.ApplyResources(this.ucContactSelectBox1, "ucContactSelectBox1");
            this.ucContactSelectBox1.Name = "ucContactSelectBox1";
            this.ucContactSelectBox1.ReadOnly = true;
            this.ucContactSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.ucContactSelectBox1.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // ebACComment
            // 
            this.ebACComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "ActivityComment", true));
            resources.ApplyResources(this.ebACComment, "ebACComment");
            this.ebACComment.Multiline = true;
            this.ebACComment.Name = "ebACComment";
            this.ebACComment.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebACComment.TextChanged += new System.EventHandler(this.ebACComment_TextChanged);
            // 
            // editBox2
            // 
            this.editBox2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.editBox2, "editBox2");
            this.editBox2.Multiline = true;
            this.editBox2.Name = "editBox2";
            this.editBox2.ReadOnly = true;
            this.editBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBindingSource, "ActivityDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // acCommentCounter
            // 
            this.acCommentCounter.BackColor = System.Drawing.SystemColors.Control;
            this.acCommentCounter.DecimalDigits = 0;
            this.acCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.acCommentCounter, "acCommentCounter");
            this.acCommentCounter.MaxLength = 3;
            this.acCommentCounter.Name = "acCommentCounter";
            this.acCommentCounter.ReadOnly = true;
            superTipSettings1.ImageListProvider = null;
            this.janusSuperTip1.SetSuperTip(this.acCommentCounter, superTipSettings1);
            this.acCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.acCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.acCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gbActivityShortcut
            // 
            this.gbActivityShortcut.BackColor = System.Drawing.Color.Transparent;
            this.gbActivityShortcut.Controls.Add(label26);
            this.gbActivityShortcut.Controls.Add(label27);
            this.gbActivityShortcut.Controls.Add(this.txtActivitySCName);
            this.gbActivityShortcut.Controls.Add(this.cmdBrowseASC);
            this.gbActivityShortcut.Controls.Add(this.lblASCDest);
            this.gbActivityShortcut.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbActivityShortcut, "gbActivityShortcut");
            this.gbActivityShortcut.Name = "gbActivityShortcut";
            this.gbActivityShortcut.UseThemes = false;
            this.gbActivityShortcut.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // txtActivitySCName
            // 
            resources.ApplyResources(this.txtActivitySCName, "txtActivitySCName");
            this.txtActivitySCName.Name = "txtActivitySCName";
            // 
            // cmdBrowseASC
            // 
            this.cmdBrowseASC.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.cmdBrowseASC, "cmdBrowseASC");
            this.cmdBrowseASC.Name = "cmdBrowseASC";
            this.cmdBrowseASC.UseVisualStyleBackColor = false;
            this.cmdBrowseASC.Click += new System.EventHandler(this.cmdBrowseASC_Click);
            // 
            // lblASCDest
            // 
            resources.ApplyResources(this.lblASCDest, "lblASCDest");
            this.lblASCDest.BackColor = System.Drawing.Color.Transparent;
            this.lblASCDest.Name = "lblASCDest";
            // 
            // gbFileShortcut
            // 
            this.gbFileShortcut.BackColor = System.Drawing.Color.Transparent;
            this.gbFileShortcut.Controls.Add(label25);
            this.gbFileShortcut.Controls.Add(lblShortcutName);
            this.gbFileShortcut.Controls.Add(this.txtFileSCName);
            this.gbFileShortcut.Controls.Add(this.cmdBrowseFSC);
            this.gbFileShortcut.Controls.Add(this.lblFSCDest);
            this.gbFileShortcut.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbFileShortcut, "gbFileShortcut");
            this.gbFileShortcut.Name = "gbFileShortcut";
            this.gbFileShortcut.UseThemes = false;
            // 
            // txtFileSCName
            // 
            resources.ApplyResources(this.txtFileSCName, "txtFileSCName");
            this.txtFileSCName.Name = "txtFileSCName";
            this.txtFileSCName.TextChanged += new System.EventHandler(this.txtFileSCName_TextChanged);
            // 
            // cmdBrowseFSC
            // 
            this.cmdBrowseFSC.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.cmdBrowseFSC, "cmdBrowseFSC");
            this.cmdBrowseFSC.Name = "cmdBrowseFSC";
            this.cmdBrowseFSC.UseVisualStyleBackColor = false;
            this.cmdBrowseFSC.Click += new System.EventHandler(this.cmdBrowseFSC_Click);
            // 
            // lblFSCDest
            // 
            resources.ApplyResources(this.lblFSCDest, "lblFSCDest");
            this.lblFSCDest.BackColor = System.Drawing.Color.Transparent;
            this.lblFSCDest.Name = "lblFSCDest";
            // 
            // chkActivityShortcut
            // 
            this.chkActivityShortcut.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkActivityShortcut, "chkActivityShortcut");
            this.chkActivityShortcut.Image = global::LawMate.Properties.Resources.shortcut2;
            this.chkActivityShortcut.Name = "chkActivityShortcut";
            this.chkActivityShortcut.UseVisualStyleBackColor = false;
            this.chkActivityShortcut.CheckedChanged += new System.EventHandler(this.chkActivityShortcut_CheckedChanged);
            // 
            // chkFileShortcut
            // 
            this.chkFileShortcut.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkFileShortcut, "chkFileShortcut");
            this.chkFileShortcut.Image = global::LawMate.Properties.Resources.shortcut2;
            this.chkFileShortcut.Name = "chkFileShortcut";
            this.chkFileShortcut.UseVisualStyleBackColor = false;
            this.chkFileShortcut.CheckedChanged += new System.EventHandler(this.chkFileShortcut_CheckedChanged);
            // 
            // pnlBFHelp
            // 
            this.pnlBFHelp.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlBFHelp.InnerContainer = this.pnlBFHelpContainer;
            resources.ApplyResources(this.pnlBFHelp, "pnlBFHelp");
            this.pnlBFHelp.Name = "pnlBFHelp";
            // 
            // pnlBFHelpContainer
            // 
            resources.ApplyResources(this.pnlBFHelpContainer, "pnlBFHelpContainer");
            this.pnlBFHelpContainer.Name = "pnlBFHelpContainer";
            // 
            // pnlWizBF
            // 
            this.pnlWizBF.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlWizBF.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlWizBF.InnerContainer = this.pnlWizBFContainer;
            resources.ApplyResources(this.pnlWizBF, "pnlWizBF");
            this.pnlWizBF.Name = "pnlWizBF";
            // 
            // pnlWizBFContainer
            // 
            resources.ApplyResources(this.pnlWizBFContainer, "pnlWizBFContainer");
            this.pnlWizBFContainer.Name = "pnlWizBFContainer";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tsHelp1
            // 
            resources.ApplyResources(this.tsHelp1, "tsHelp1");
            this.tsHelp1.Name = "tsHelp1";
            // 
            // officeDB1
            // 
            this.officeDB1.DataSetName = "officeDB";
            this.officeDB1.EnforceConstraints = false;
            this.officeDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // codesDB1
            // 
            this.codesDB1.DataSetName = "CodesDB";
            this.codesDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.eFileBindingSource;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.activityBindingSource;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.DataSource = this.activityBFBindingSource;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            this.errorProvider4.DataSource = this.disbursementBindingSource;
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            this.errorProvider5.DataSource = this.activityTimeBindingSource;
            // 
            // janusSuperTip1
            // 
            this.janusSuperTip1.AutoPopDelay = 30000;
            this.janusSuperTip1.BodyWidth = 200;
            this.janusSuperTip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.janusSuperTip1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.janusSuperTip1.ImageList = this.imageList1;
            this.janusSuperTip1.InitialDelay = 200;
            // 
            // timAutosave
            // 
            this.timAutosave.Interval = 300000;
            this.timAutosave.Tick += new System.EventHandler(this.timAutosave_Tick);
            // 
            // timFMHeartbeat
            // 
            this.timFMHeartbeat.Interval = 5000;
            this.timFMHeartbeat.Tick += new System.EventHandler(this.timFMHeartbeat_Tick);
            // 
            // timFocus
            // 
            this.timFocus.Interval = 10;
            this.timFocus.Tick += new System.EventHandler(this.timFocus_Tick);
            // 
            // fACWizard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.pnlHelpText);
            this.Controls.Add(this.TopRebar1);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "fACWizard";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.fACWizard_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fACWizard_FormClosing);
            this.Load += new System.EventHandler(this.fACWizard_Load);
            this.Shown += new System.EventHandler(this.fACWizard_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fACWizard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHelpText)).EndInit();
            this.pnlHelpText.ResumeLayout(false);
            this.pnlHelpTextContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomContainer.ResumeLayout(false);
            this.pnlBottomContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTabs)).EndInit();
            this.pnlTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivity)).EndInit();
            this.pnlActivity.ResumeLayout(false);
            this.pnlActivityContainer.ResumeLayout(false);
            this.pnlActivityContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabNextSteps.ResumeLayout(false);
            this.uiTabEnabledProcesses.ResumeLayout(false);
            this.uiTabAlwaysAvailable.ResumeLayout(false);
            this.uiTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIssue)).EndInit();
            this.pnlIssue.ResumeLayout(false);
            this.pnlIssueContainer.ResumeLayout(false);
            this.pnlIssueContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFile)).EndInit();
            this.pnlFile.ResumeLayout(false);
            this.pnlFileContainer.ResumeLayout(false);
            this.pnlFileContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityConfirm)).EndInit();
            this.pnlActivityConfirm.ResumeLayout(false);
            this.pnlActivityConfirmContainer.ResumeLayout(false);
            this.pnlActivityConfirmContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRelatedFields)).EndInit();
            this.pnlRelatedFields.ResumeLayout(false);
            this.pnlRelatedFieldsContainer.ResumeLayout(false);
            this.pnlRelatedFieldsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeline)).EndInit();
            this.pnlTimeline.ResumeLayout(false);
            this.pnlTimelineContainer.ResumeLayout(false);
            this.pnlTimelineContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBF)).EndInit();
            this.pnlBF.ResumeLayout(false);
            this.pnlBFContainer.ResumeLayout(false);
            this.pnlBFContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDisbursements)).EndInit();
            this.pnlDisbursements.ResumeLayout(false);
            this.pnlDisbursementsContainer.ResumeLayout(false);
            this.pnlDisbursementsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBilling)).EndInit();
            this.pnlBilling.ResumeLayout(false);
            this.pnlBillingContainer.ResumeLayout(false);
            this.pnlBillingContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocument)).EndInit();
            this.pnlDocument.ResumeLayout(false);
            this.pnlDocumentContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlConfirm)).EndInit();
            this.pnlConfirm.ResumeLayout(false);
            this.pnlConfirmContainer.ResumeLayout(false);
            this.pnlConfirmContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbActivityShortcut)).EndInit();
            this.gbActivityShortcut.ResumeLayout(false);
            this.gbActivityShortcut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbFileShortcut)).EndInit();
            this.gbFileShortcut.ResumeLayout(false);
            this.gbFileShortcut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBFHelp)).EndInit();
            this.pnlBFHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlWizBF)).EndInit();
            this.pnlWizBF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeDB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codesDB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlBottom;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBottomContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlTabs;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlFile;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlFileContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlIssue;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlIssueContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlActivity;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlActivityConfirm;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityConfirmContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlRelatedFields;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlRelatedFieldsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBF;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBFContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlDisbursements;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDisbursementsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlDocument;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocumentContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBilling;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBillingContainer;
        private UserControls.ucBrowseIssues ucBrowseIssues1;
        private System.Windows.Forms.TextBox nameFTextBox;
        private System.Windows.Forms.BindingSource eFileBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private System.Windows.Forms.TextBox nameETextBox;
        private System.Windows.Forms.ComboBox fileTypeComboBox;
        private Janus.Windows.CalendarCombo.CalendarCombo openedDateCalendarCombo;
        private System.Windows.Forms.TextBox fileNumberTextBox;
        private System.Windows.Forms.ComboBox statusCodeComboBox;
        public Janus.Windows.CalendarCombo.CalendarCombo calDate;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNoCodeSelectedMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkNextStepsProcesses;
        private System.Windows.Forms.LinkLabel lnkAllActivities;
        private System.Windows.Forms.Label lblSelectIssue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.BindingSource activityBindingSource;
        private System.Windows.Forms.BindingSource activityBFBindingSource;
        private System.Windows.Forms.BindingSource activityTimeBindingSource;
        private System.Windows.Forms.BindingSource disbursementBindingSource;
        private System.Windows.Forms.TextBox activityCommentTextBox;
        private System.Windows.Forms.TextBox activityCodeTextBox;
        private Janus.Windows.CalendarCombo.CalendarCombo activityDateCalendarCombo;
        private System.Windows.Forms.Label lblActivityDescription;
        private System.Windows.Forms.Label lblActvityDate;
        private Janus.Windows.GridEX.GridEX activityBFGridEX;
        private Janus.Windows.GridEX.GridEX disbursementGridEX;
        private System.Windows.Forms.TextBox ActivityDescriptionTextBox;
        private Janus.Windows.GridEX.GridEX activityTimeGridEX;
        private System.Windows.Forms.ListBox listBoxSecondary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrimaryIssueConfirm;
        private System.Windows.Forms.Label lblSecondaryIssueConfirm;
        private System.Windows.Forms.ListBox listBoxSecondaryIssueConfirm;
        private System.Windows.Forms.TextBox tbPrimaryIssueConfirm;
        private System.Windows.Forms.Timer timer1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsHelp;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        //private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand tsHelp1;
        private lmDatasets.officeDB officeDB1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox officerIdComboBox;
        private lmDatasets.CodesDB codesDB1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private UserControls.ucDoc ucDoc1;
        private Janus.Windows.UI.Dock.UIPanel pnlConfirm;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlConfirmContainer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkActivityShortcut;
        private System.Windows.Forms.CheckBox chkFileShortcut;
        private System.Windows.Forms.TextBox txtActivitySCName;
        private System.Windows.Forms.TextBox txtFileSCName;
        private System.Windows.Forms.TreeView tvNextSteps;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView ExplorerBarAvailableProcesses;
        private System.Windows.Forms.TreeView ExplorerBarAllActivities;
        private System.Windows.Forms.Button cmdBrowseASC;
        private System.Windows.Forms.Button cmdBrowseFSC;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private System.Windows.Forms.ErrorProvider errorProvider5;
        private System.Windows.Forms.Label lblASCDest;
        private System.Windows.Forms.Label lblFSCDest;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
        private Janus.Windows.EditControls.UIGroupBox gbFileShortcut;
        private Janus.Windows.EditControls.UIGroupBox gbActivityShortcut;
        private Janus.Windows.GridEX.EditControls.NumericEditBox acCommentCounter;
        private System.Windows.Forms.Timer timAutosave;
        private Janus.Windows.EditControls.UIButton btnAddNewTime;
        private Janus.Windows.EditControls.UIButton btnAddNewBF;
        private Janus.Windows.EditControls.UIButton btnSuspendActivity;
        private Janus.Windows.EditControls.UICheckBox checkboxJumpToFile;
        private Janus.Windows.EditControls.UIButton buttonFinish;
        private Janus.Windows.EditControls.UIButton buttonLast;
        private Janus.Windows.EditControls.UIButton buttonNext;
        private Janus.Windows.EditControls.UIButton buttonBack;
        private Janus.Windows.EditControls.UIButton buttonCancel;
        private Janus.Windows.EditControls.UIButton uibtnRemoveSecondary;
        private Janus.Windows.EditControls.UIButton uibtnAddSecondary;
        private Janus.Windows.EditControls.UIButton uibtnRemovePrimary;
        private Janus.Windows.EditControls.UIButton uibtnAddPrimary;
        private System.Windows.Forms.Timer timFMHeartbeat;
        private Janus.Windows.UI.Dock.UIPanel pnlBFHelp;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBFHelpContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlWizBF;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlWizBFContainer;
        private System.Windows.Forms.Label lblBFHelpImg;
        private System.Windows.Forms.Label lblHelpText;
        private Janus.Windows.UI.Dock.UIPanel pnlHelpText;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlHelpTextContainer;
        private Janus.Windows.EditControls.UIButton btnExpandCollapseNextSteps;
        private Janus.Windows.EditControls.UIButton btnExpandCollapseAvailProcesses;
        private Janus.Windows.EditControls.UIButton btnHelpTriangle;
        private Janus.Windows.GridEX.EditControls.EditBox tbWizardTimer;
        private System.Windows.Forms.Timer timFocus;
        private System.Windows.Forms.TreeView tvEnabledProcesses;
        private Janus.Windows.EditControls.UIButton btnExpandCollapseEnabledProcesses;
        private Janus.Windows.GridEX.EditControls.EditBox tbJCode;
        private Janus.Windows.GridEX.EditControls.EditBox ebACDescription;
        private ucContactSelectBox ucContactSelectBox1;
        private Janus.Windows.GridEX.EditControls.EditBox ebACComment;
        private Janus.Windows.GridEX.EditControls.EditBox editBox2;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private Janus.Windows.GridEX.EditControls.EditBox ebPrimaryIssue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Janus.Windows.EditControls.UIButton btnAddNewDisb;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabNextSteps;
        private Janus.Windows.UI.Tab.UITabPage uiTabAlwaysAvailable;
        private Janus.Windows.UI.Tab.UITabPage uiTabEnabledProcesses;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage4;
        private Janus.Windows.UI.Dock.UIPanel pnlTimeline;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTimelineContainer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private ucTimeline ucTimeline1;
        private System.Windows.Forms.Label lblDefaultHoursValue;
        private System.Windows.Forms.Label lblDefaultHours;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
        private Janus.Windows.EditControls.UICheckBox chkSkipDoc;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu2;
    }
}
