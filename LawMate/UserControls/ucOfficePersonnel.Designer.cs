 namespace LawMate
{
    partial class ucOfficePersonnel
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
                FM.LeadOfficeMng.DB.Officer.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.LeadOfficeMng.GetOfficer().OnUpdate -= new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

                FM.LeadOfficeMng.DB.OfficerDelegate.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.LeadOfficeMng.GetOfficerDelegate().OnUpdate -= new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

                FM.LeadOfficeMng.DB.OfficerRole.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.LeadOfficeMng.GetOfficerRole().OnUpdate -= new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

                FM.LeadOfficeMng.DB.ContactEmail.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.LeadOfficeMng.GetContactEmail().OnUpdate -= new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

                FM.LeadOfficeMng.DB.MemberProfile.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.LeadOfficeMng.GetMemberProfile().OnUpdate -= new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOfficePersonnel));
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label officerCodeLabel1;
            System.Windows.Forms.Label salutationLabel1;
            System.Windows.Forms.Label firstNameLabel1;
            System.Windows.Forms.Label middleNameLabel1;
            System.Windows.Forms.Label lastNameLabel1;
            System.Windows.Forms.Label suffixLabel1;
            System.Windows.Forms.Label notesLabel1;
            System.Windows.Forms.Label positionCodeLabel1;
            System.Windows.Forms.Label positionTitleLabel1;
            System.Windows.Forms.Label positionTitleFreLabel1;
            System.Windows.Forms.Label telephoneNumberLabel1;
            System.Windows.Forms.Label faxNumberLabel1;
            System.Windows.Forms.Label emailAddressLabel1;
            System.Windows.Forms.Label assistantIdLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label endDateLabel;
            System.Windows.Forms.Label startDateLabel;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            Janus.Windows.GridEX.GridEXLayout officerGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout contactEmailGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout officerRoleGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference officerRoleGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ButtonImage");
            Janus.Windows.GridEX.GridEXLayout officerDelegateGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference officerDelegateGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ButtonImage");
            this.cellPhoneLabel1 = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlOfficerGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlOfficerGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.officerGridEX = new Janus.Windows.GridEX.GridEX();
            this.officerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDB = new lmDatasets.officeDB();
            this.pnlRowDetails = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlRowDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.memberProfileTab = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.usesBillingCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isMailUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.assistantIducMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.emailAddressEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.faxNumberMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.cellPhoneMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.telephoneExtensionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.telephoneNumberMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.positionTitleFreEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.positionTitleEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.positionCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.currentEmployeeUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.notesEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.suffixEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lastNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.middleNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.firstNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.salutationEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officerCodeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.btnAddNewEmailAddress = new Janus.Windows.EditControls.UIButton();
            this.contactEmailGridEX = new Janus.Windows.GridEX.GridEX();
            this.contactEmailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.ucFSPersonal = new LawMate.ucFileSelectBox();
            this.ucFSShortcut = new LawMate.ucFileSelectBox();
            this.ucFSInbox = new LawMate.ucFileSelectBox();
            this.ucFSSentItems = new LawMate.ucFileSelectBox();
            this.uiTabPage4 = new Janus.Windows.UI.Tab.UITabPage();
            this.btnAddNewOfficerRole = new Janus.Windows.EditControls.UIButton();
            this.btnAddNewDelegate = new Janus.Windows.EditControls.UIButton();
            this.officerRoleGridEX = new Janus.Windows.GridEX.GridEX();
            this.officerRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officerDelegateGridEX = new Janus.Windows.GridEX.GridEX();
            this.officerDelegateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiTabPage5 = new Janus.Windows.UI.Tab.UITabPage();
            this.endTimeCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.startTimeCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkOutOfOffice = new System.Windows.Forms.CheckBox();
            this.endDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.startDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.tribunalTabPage = new Janus.Windows.UI.Tab.UITabPage();
            this.addAddressBtn = new Janus.Windows.EditControls.UIButton();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.confIDeditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.memberProfileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.phoneNumberEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.addressGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.ucAddress = new LawMate.UserControls.ucAddress();
            this.uiGroupBox7 = new Janus.Windows.EditControls.UIGroupBox();
            this.calExpiryDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.calStartDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.trainingGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.TrainedCharterCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.trainedEICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.trainedOASCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.trainedCPPCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.gbParticipant = new Janus.Windows.EditControls.UIGroupBox();
            this.appealLevelDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.isCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.eiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.uiGroupBoxLanguage = new Janus.Windows.EditControls.UIGroupBox();
            this.langFrenchCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.langEnglishCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlDelegateRole = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDelegateRoleContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlUserInfo = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlUserInfoContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlAlternateEmail = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAlternateEmailContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlPersonalFiles = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSecurityContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.secUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.securityDB = new lmDatasets.SecurityDB();
            this.secMembershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsNew1 = new Janus.Windows.UI.CommandBars.UICommand("tsNew");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsFilter1 = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.tsGroupBy1 = new Janus.Windows.UI.CommandBars.UICommand("tsGroupBy");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSecurity1 = new Janus.Windows.UI.CommandBars.UICommand("tsSecurity");
            this.tsMyFile1 = new Janus.Windows.UI.CommandBars.UICommand("tsMyFile");
            this.tsCopyPrefs1 = new Janus.Windows.UI.CommandBars.UICommand("tsCopyPrefs");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAddToAB1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddToAB");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsNew = new Janus.Windows.UI.CommandBars.UICommand("tsNew");
            this.tsSecurity = new Janus.Windows.UI.CommandBars.UICommand("tsSecurity");
            this.tsFilter = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.tsGroupBy = new Janus.Windows.UI.CommandBars.UICommand("tsGroupBy");
            this.tsMyFile = new Janus.Windows.UI.CommandBars.UICommand("tsMyFile");
            this.cmdAddToAB = new Janus.Windows.UI.CommandBars.UICommand("cmdAddToAB");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsNew2 = new Janus.Windows.UI.CommandBars.UICommand("tsNew");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.tsFilter2 = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.tsGroupBy2 = new Janus.Windows.UI.CommandBars.UICommand("tsGroupBy");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.tsSecurity2 = new Janus.Windows.UI.CommandBars.UICommand("tsSecurity");
            this.tsMyFile2 = new Janus.Windows.UI.CommandBars.UICommand("tsMyFile");
            this.cmdAddToAB2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddToAB");
            this.tsCopyPrefs2 = new Janus.Windows.UI.CommandBars.UICommand("tsCopyPrefs");
            this.tsCopyPrefs = new Janus.Windows.UI.CommandBars.UICommand("tsCopyPrefs");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.atriumDB = new lmDatasets.atriumDB();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            officerCodeLabel1 = new System.Windows.Forms.Label();
            salutationLabel1 = new System.Windows.Forms.Label();
            firstNameLabel1 = new System.Windows.Forms.Label();
            middleNameLabel1 = new System.Windows.Forms.Label();
            lastNameLabel1 = new System.Windows.Forms.Label();
            suffixLabel1 = new System.Windows.Forms.Label();
            notesLabel1 = new System.Windows.Forms.Label();
            positionCodeLabel1 = new System.Windows.Forms.Label();
            positionTitleLabel1 = new System.Windows.Forms.Label();
            positionTitleFreLabel1 = new System.Windows.Forms.Label();
            telephoneNumberLabel1 = new System.Windows.Forms.Label();
            faxNumberLabel1 = new System.Windows.Forms.Label();
            emailAddressLabel1 = new System.Windows.Forms.Label();
            assistantIdLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            endDateLabel = new System.Windows.Forms.Label();
            startDateLabel = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOfficerGrid)).BeginInit();
            this.pnlOfficerGrid.SuspendLayout();
            this.pnlOfficerGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRowDetails)).BeginInit();
            this.pnlRowDetails.SuspendLayout();
            this.pnlRowDetailsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberProfileTab)).BeginInit();
            this.memberProfileTab.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactEmailGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactEmailBindingSource)).BeginInit();
            this.uiTabPage3.SuspendLayout();
            this.uiTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerRoleGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerDelegateGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerDelegateBindingSource)).BeginInit();
            this.uiTabPage5.SuspendLayout();
            this.tribunalTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberProfileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressGroupBox)).BeginInit();
            this.addressGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox7)).BeginInit();
            this.uiGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingGroupBox)).BeginInit();
            this.trainingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbParticipant)).BeginInit();
            this.gbParticipant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBoxLanguage)).BeginInit();
            this.uiGroupBoxLanguage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDelegateRole)).BeginInit();
            this.pnlDelegateRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUserInfo)).BeginInit();
            this.pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAlternateEmail)).BeginInit();
            this.pnlAlternateEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPersonalFiles)).BeginInit();
            this.pnlPersonalFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secMembershipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.officerBindingSource;
            // 
            // imageListBase
            // 
            this.imageListBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBase.ImageStream")));
            this.imageListBase.Images.SetKeyName(0, "");
            this.imageListBase.Images.SetKeyName(1, "");
            this.imageListBase.Images.SetKeyName(2, "");
            this.imageListBase.Images.SetKeyName(3, "");
            this.imageListBase.Images.SetKeyName(4, "");
            this.imageListBase.Images.SetKeyName(5, "");
            this.imageListBase.Images.SetKeyName(6, "");
            this.imageListBase.Images.SetKeyName(7, "");
            this.imageListBase.Images.SetKeyName(8, "");
            this.imageListBase.Images.SetKeyName(9, "");
            this.imageListBase.Images.SetKeyName(10, "");
            this.imageListBase.Images.SetKeyName(11, "");
            this.imageListBase.Images.SetKeyName(12, "");
            this.imageListBase.Images.SetKeyName(13, "");
            this.imageListBase.Images.SetKeyName(14, "");
            this.imageListBase.Images.SetKeyName(15, "");
            this.imageListBase.Images.SetKeyName(16, "");
            this.imageListBase.Images.SetKeyName(17, "");
            this.imageListBase.Images.SetKeyName(18, "DRedit.gif");
            this.imageListBase.Images.SetKeyName(19, "audit.gif");
            this.imageListBase.Images.SetKeyName(20, "passwordReset.gif");
            this.imageListBase.Images.SetKeyName(21, "mail2.gif");
            this.imageListBase.Images.SetKeyName(22, "groupBy.gif");
            this.imageListBase.Images.SetKeyName(23, "Inbox1.gif");
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            this.helpProvider1.SetShowHelp(label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            this.helpProvider1.SetShowHelp(label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            this.helpProvider1.SetShowHelp(label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // officerCodeLabel1
            // 
            resources.ApplyResources(officerCodeLabel1, "officerCodeLabel1");
            officerCodeLabel1.BackColor = System.Drawing.Color.Transparent;
            officerCodeLabel1.Name = "officerCodeLabel1";
            this.helpProvider1.SetShowHelp(officerCodeLabel1, ((bool)(resources.GetObject("officerCodeLabel1.ShowHelp"))));
            // 
            // salutationLabel1
            // 
            resources.ApplyResources(salutationLabel1, "salutationLabel1");
            salutationLabel1.BackColor = System.Drawing.Color.Transparent;
            salutationLabel1.Name = "salutationLabel1";
            this.helpProvider1.SetShowHelp(salutationLabel1, ((bool)(resources.GetObject("salutationLabel1.ShowHelp"))));
            // 
            // firstNameLabel1
            // 
            resources.ApplyResources(firstNameLabel1, "firstNameLabel1");
            firstNameLabel1.BackColor = System.Drawing.Color.Transparent;
            firstNameLabel1.Name = "firstNameLabel1";
            this.helpProvider1.SetShowHelp(firstNameLabel1, ((bool)(resources.GetObject("firstNameLabel1.ShowHelp"))));
            // 
            // middleNameLabel1
            // 
            resources.ApplyResources(middleNameLabel1, "middleNameLabel1");
            middleNameLabel1.BackColor = System.Drawing.Color.Transparent;
            middleNameLabel1.Name = "middleNameLabel1";
            this.helpProvider1.SetShowHelp(middleNameLabel1, ((bool)(resources.GetObject("middleNameLabel1.ShowHelp"))));
            // 
            // lastNameLabel1
            // 
            resources.ApplyResources(lastNameLabel1, "lastNameLabel1");
            lastNameLabel1.BackColor = System.Drawing.Color.Transparent;
            lastNameLabel1.Name = "lastNameLabel1";
            this.helpProvider1.SetShowHelp(lastNameLabel1, ((bool)(resources.GetObject("lastNameLabel1.ShowHelp"))));
            // 
            // suffixLabel1
            // 
            resources.ApplyResources(suffixLabel1, "suffixLabel1");
            suffixLabel1.BackColor = System.Drawing.Color.Transparent;
            suffixLabel1.Name = "suffixLabel1";
            this.helpProvider1.SetShowHelp(suffixLabel1, ((bool)(resources.GetObject("suffixLabel1.ShowHelp"))));
            // 
            // notesLabel1
            // 
            resources.ApplyResources(notesLabel1, "notesLabel1");
            notesLabel1.BackColor = System.Drawing.Color.Transparent;
            notesLabel1.Name = "notesLabel1";
            this.helpProvider1.SetShowHelp(notesLabel1, ((bool)(resources.GetObject("notesLabel1.ShowHelp"))));
            // 
            // positionCodeLabel1
            // 
            resources.ApplyResources(positionCodeLabel1, "positionCodeLabel1");
            positionCodeLabel1.BackColor = System.Drawing.Color.Transparent;
            positionCodeLabel1.Name = "positionCodeLabel1";
            this.helpProvider1.SetShowHelp(positionCodeLabel1, ((bool)(resources.GetObject("positionCodeLabel1.ShowHelp"))));
            // 
            // positionTitleLabel1
            // 
            resources.ApplyResources(positionTitleLabel1, "positionTitleLabel1");
            positionTitleLabel1.BackColor = System.Drawing.Color.Transparent;
            positionTitleLabel1.Name = "positionTitleLabel1";
            this.helpProvider1.SetShowHelp(positionTitleLabel1, ((bool)(resources.GetObject("positionTitleLabel1.ShowHelp"))));
            // 
            // positionTitleFreLabel1
            // 
            resources.ApplyResources(positionTitleFreLabel1, "positionTitleFreLabel1");
            positionTitleFreLabel1.BackColor = System.Drawing.Color.Transparent;
            positionTitleFreLabel1.Name = "positionTitleFreLabel1";
            this.helpProvider1.SetShowHelp(positionTitleFreLabel1, ((bool)(resources.GetObject("positionTitleFreLabel1.ShowHelp"))));
            // 
            // telephoneNumberLabel1
            // 
            resources.ApplyResources(telephoneNumberLabel1, "telephoneNumberLabel1");
            telephoneNumberLabel1.BackColor = System.Drawing.Color.Transparent;
            telephoneNumberLabel1.Name = "telephoneNumberLabel1";
            this.helpProvider1.SetShowHelp(telephoneNumberLabel1, ((bool)(resources.GetObject("telephoneNumberLabel1.ShowHelp"))));
            // 
            // faxNumberLabel1
            // 
            resources.ApplyResources(faxNumberLabel1, "faxNumberLabel1");
            faxNumberLabel1.BackColor = System.Drawing.Color.Transparent;
            faxNumberLabel1.Name = "faxNumberLabel1";
            this.helpProvider1.SetShowHelp(faxNumberLabel1, ((bool)(resources.GetObject("faxNumberLabel1.ShowHelp"))));
            // 
            // emailAddressLabel1
            // 
            resources.ApplyResources(emailAddressLabel1, "emailAddressLabel1");
            emailAddressLabel1.BackColor = System.Drawing.Color.Transparent;
            emailAddressLabel1.Name = "emailAddressLabel1";
            this.helpProvider1.SetShowHelp(emailAddressLabel1, ((bool)(resources.GetObject("emailAddressLabel1.ShowHelp"))));
            // 
            // assistantIdLabel
            // 
            resources.ApplyResources(assistantIdLabel, "assistantIdLabel");
            assistantIdLabel.BackColor = System.Drawing.Color.Transparent;
            assistantIdLabel.Name = "assistantIdLabel";
            this.helpProvider1.SetShowHelp(assistantIdLabel, ((bool)(resources.GetObject("assistantIdLabel.ShowHelp"))));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            this.helpProvider1.SetShowHelp(label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            this.helpProvider1.SetShowHelp(label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
            // 
            // endDateLabel
            // 
            resources.ApplyResources(endDateLabel, "endDateLabel");
            endDateLabel.BackColor = System.Drawing.Color.Transparent;
            endDateLabel.Name = "endDateLabel";
            this.helpProvider1.SetShowHelp(endDateLabel, ((bool)(resources.GetObject("endDateLabel.ShowHelp"))));
            // 
            // startDateLabel
            // 
            resources.ApplyResources(startDateLabel, "startDateLabel");
            startDateLabel.BackColor = System.Drawing.Color.Transparent;
            startDateLabel.Name = "startDateLabel";
            this.helpProvider1.SetShowHelp(startDateLabel, ((bool)(resources.GetObject("startDateLabel.ShowHelp"))));
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Name = "label9";
            this.helpProvider1.SetShowHelp(label9, ((bool)(resources.GetObject("label9.ShowHelp"))));
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            this.helpProvider1.SetShowHelp(label10, ((bool)(resources.GetObject("label10.ShowHelp"))));
            // 
            // cellPhoneLabel1
            // 
            resources.ApplyResources(this.cellPhoneLabel1, "cellPhoneLabel1");
            this.cellPhoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.cellPhoneLabel1.Name = "cellPhoneLabel1";
            this.helpProvider1.SetShowHelp(this.cellPhoneLabel1, ((bool)(resources.GetObject("cellPhoneLabel1.ShowHelp"))));
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlOfficerGrid.Id = new System.Guid("ae291c2d-72b4-4f48-9040-ad2a03ea4d65");
            this.uiPanelManager1.Panels.Add(this.pnlOfficerGrid);
            this.pnlRowDetails.Id = new System.Guid("93128f44-2d10-41e9-aa7f-ce90539095d6");
            this.uiPanelManager1.Panels.Add(this.pnlRowDetails);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ae291c2d-72b4-4f48-9040-ad2a03ea4d65"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(784, 251), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("93128f44-2d10-41e9-aa7f-ce90539095d6"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(784, 351), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1520bb5b-23c1-48ee-9d3a-058f4d699d14"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5d875e44-7a6e-47e0-bbdd-7cb65713bcd1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0a9b93ab-ff6d-4a2d-a659-df91319e71b5"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("16194e53-2b13-4121-a7e7-012dee8eed7c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c2065563-a609-4324-ab7a-369c7104c8d3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("68e5db80-44c0-4166-9dcf-0f24ac42acb5"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ca8ce7c9-edb5-43a0-a412-ecf2b3eec081"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ae291c2d-72b4-4f48-9040-ad2a03ea4d65"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("93128f44-2d10-41e9-aa7f-ce90539095d6"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlOfficerGrid
            // 
            this.pnlOfficerGrid.InnerContainer = this.pnlOfficerGridContainer;
            resources.ApplyResources(this.pnlOfficerGrid, "pnlOfficerGrid");
            this.pnlOfficerGrid.Name = "pnlOfficerGrid";
            this.helpProvider1.SetShowHelp(this.pnlOfficerGrid, ((bool)(resources.GetObject("pnlOfficerGrid.ShowHelp"))));
            // 
            // pnlOfficerGridContainer
            // 
            this.pnlOfficerGridContainer.Controls.Add(this.officerGridEX);
            resources.ApplyResources(this.pnlOfficerGridContainer, "pnlOfficerGridContainer");
            this.pnlOfficerGridContainer.Name = "pnlOfficerGridContainer";
            this.helpProvider1.SetShowHelp(this.pnlOfficerGridContainer, ((bool)(resources.GetObject("pnlOfficerGridContainer.ShowHelp"))));
            // 
            // officerGridEX
            // 
            this.officerGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.officerGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.officerGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.officerGridEX.DataSource = this.officerBindingSource;
            resources.ApplyResources(officerGridEX_DesignTimeLayout, "officerGridEX_DesignTimeLayout");
            this.officerGridEX.DesignTimeLayout = officerGridEX_DesignTimeLayout;
            resources.ApplyResources(this.officerGridEX, "officerGridEX");
            this.officerGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.officerGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.officerGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.officerGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.officerGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.officerGridEX.GroupRowFormatStyle.FontName = "tahoma";
            this.officerGridEX.GroupRowFormatStyle.FontSize = 7F;
            this.officerGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.officerGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.officerGridEX.Name = "officerGridEX";
            this.officerGridEX.SettingsKey = "ucOfficePersonnelB";
            this.helpProvider1.SetShowHelp(this.officerGridEX, ((bool)(resources.GetObject("officerGridEX.ShowHelp"))));
            this.officerGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.officerGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.officerGridEX.VisualStyleAreas.GroupByBoxStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.officerGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.officerGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.officerGridEX_CurrentCellChanging);
            this.officerGridEX.SelectionChanged += new System.EventHandler(this.officerGridEX_SelectionChanged);
            this.officerGridEX.LayoutLoad += new System.EventHandler(this.officerGridEX_LayoutLoad);
            // 
            // officerBindingSource
            // 
            this.officerBindingSource.DataMember = "Officer";
            this.officerBindingSource.DataSource = this.officeDB;
            this.officerBindingSource.CurrentChanged += new System.EventHandler(this.officerBindingSource_CurrentChanged);
            // 
            // officeDB
            // 
            this.officeDB.DataSetName = "officeDB";
            this.officeDB.EnforceConstraints = false;
            this.officeDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlRowDetails
            // 
            this.pnlRowDetails.InnerContainer = this.pnlRowDetailsContainer;
            resources.ApplyResources(this.pnlRowDetails, "pnlRowDetails");
            this.pnlRowDetails.Name = "pnlRowDetails";
            this.helpProvider1.SetShowHelp(this.pnlRowDetails, ((bool)(resources.GetObject("pnlRowDetails.ShowHelp"))));
            // 
            // pnlRowDetailsContainer
            // 
            resources.ApplyResources(this.pnlRowDetailsContainer, "pnlRowDetailsContainer");
            this.pnlRowDetailsContainer.Controls.Add(this.memberProfileTab);
            this.pnlRowDetailsContainer.Name = "pnlRowDetailsContainer";
            this.helpProvider1.SetShowHelp(this.pnlRowDetailsContainer, ((bool)(resources.GetObject("pnlRowDetailsContainer.ShowHelp"))));
            // 
            // memberProfileTab
            // 
            this.memberProfileTab.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.memberProfileTab, "memberProfileTab");
            this.memberProfileTab.Name = "memberProfileTab";
            this.memberProfileTab.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.memberProfileTab, ((bool)(resources.GetObject("memberProfileTab.ShowHelp"))));
            this.memberProfileTab.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1,
            this.uiTabPage2,
            this.uiTabPage3,
            this.uiTabPage4,
            this.uiTabPage5,
            this.tribunalTabPage});
            this.memberProfileTab.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.memberProfileTab.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.memberProfileTab.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.memberProfileTab.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.memberProfileTab.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.memberProfileTab.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.memberProfileTab.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            this.memberProfileTab.SelectedTabChanged += new Janus.Windows.UI.Tab.TabEventHandler(this.memberProfileTab_SelectedTabChanged);
            // 
            // uiTabPage1
            // 
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Controls.Add(this.editBox1);
            this.uiTabPage1.Controls.Add(this.usesBillingCheckBox);
            this.uiTabPage1.Controls.Add(this.isMailUICheckBox);
            this.uiTabPage1.Controls.Add(assistantIdLabel);
            this.uiTabPage1.Controls.Add(this.assistantIducMultiDropDown);
            this.uiTabPage1.Controls.Add(emailAddressLabel1);
            this.uiTabPage1.Controls.Add(this.emailAddressEditBox);
            this.uiTabPage1.Controls.Add(faxNumberLabel1);
            this.uiTabPage1.Controls.Add(this.faxNumberMaskedEditBox);
            this.uiTabPage1.Controls.Add(this.cellPhoneLabel1);
            this.uiTabPage1.Controls.Add(this.cellPhoneMaskedEditBox);
            this.uiTabPage1.Controls.Add(this.telephoneExtensionEditBox);
            this.uiTabPage1.Controls.Add(telephoneNumberLabel1);
            this.uiTabPage1.Controls.Add(this.telephoneNumberMaskedEditBox);
            this.uiTabPage1.Controls.Add(positionTitleFreLabel1);
            this.uiTabPage1.Controls.Add(this.positionTitleFreEditBox);
            this.uiTabPage1.Controls.Add(positionTitleLabel1);
            this.uiTabPage1.Controls.Add(this.positionTitleEditBox);
            this.uiTabPage1.Controls.Add(positionCodeLabel1);
            this.uiTabPage1.Controls.Add(this.positionCodeucMultiDropDown);
            this.uiTabPage1.Controls.Add(this.currentEmployeeUICheckBox);
            this.uiTabPage1.Controls.Add(notesLabel1);
            this.uiTabPage1.Controls.Add(this.notesEditBox);
            this.uiTabPage1.Controls.Add(suffixLabel1);
            this.uiTabPage1.Controls.Add(this.suffixEditBox);
            this.uiTabPage1.Controls.Add(lastNameLabel1);
            this.uiTabPage1.Controls.Add(this.lastNameEditBox);
            this.uiTabPage1.Controls.Add(middleNameLabel1);
            this.uiTabPage1.Controls.Add(this.middleNameEditBox);
            this.uiTabPage1.Controls.Add(firstNameLabel1);
            this.uiTabPage1.Controls.Add(this.firstNameEditBox);
            this.uiTabPage1.Controls.Add(salutationLabel1);
            this.uiTabPage1.Controls.Add(this.salutationEditBox);
            this.uiTabPage1.Controls.Add(officerCodeLabel1);
            this.uiTabPage1.Controls.Add(this.officerCodeEditBox);
            this.uiTabPage1.Controls.Add(label8);
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // editBox1
            // 
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "UserName", true));
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox1, ((bool)(resources.GetObject("editBox1.ShowHelp"))));
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // usesBillingCheckBox
            // 
            this.usesBillingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.usesBillingCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usesBillingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officerBindingSource, "UsesBilling", true));
            resources.ApplyResources(this.usesBillingCheckBox, "usesBillingCheckBox");
            this.usesBillingCheckBox.Name = "usesBillingCheckBox";
            this.helpProvider1.SetShowHelp(this.usesBillingCheckBox, ((bool)(resources.GetObject("usesBillingCheckBox.ShowHelp"))));
            this.usesBillingCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isMailUICheckBox
            // 
            this.isMailUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.isMailUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isMailUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officerBindingSource, "IsMail", true));
            resources.ApplyResources(this.isMailUICheckBox, "isMailUICheckBox");
            this.isMailUICheckBox.Name = "isMailUICheckBox";
            this.helpProvider1.SetShowHelp(this.isMailUICheckBox, ((bool)(resources.GetObject("isMailUICheckBox.ShowHelp"))));
            this.isMailUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // assistantIducMultiDropDown
            // 
            this.assistantIducMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.assistantIducMultiDropDown.Column1 = "officercode";
            resources.ApplyResources(this.assistantIducMultiDropDown, "assistantIducMultiDropDown");
            this.assistantIducMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.assistantIducMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officerBindingSource, "AssistantId", true));
            this.assistantIducMultiDropDown.DataSource = null;
            this.assistantIducMultiDropDown.DDColumn1Visible = true;
            this.assistantIducMultiDropDown.DropDownColumn1Width = 100;
            this.assistantIducMultiDropDown.DropDownColumn2Width = 250;
            this.assistantIducMultiDropDown.Name = "assistantIducMultiDropDown";
            this.assistantIducMultiDropDown.ReadOnly = false;
            this.assistantIducMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.assistantIducMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.assistantIducMultiDropDown, ((bool)(resources.GetObject("assistantIducMultiDropDown.ShowHelp"))));
            this.assistantIducMultiDropDown.ValueMember = "officerid";
            // 
            // emailAddressEditBox
            // 
            this.emailAddressEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "EmailAddress", true));
            resources.ApplyResources(this.emailAddressEditBox, "emailAddressEditBox");
            this.emailAddressEditBox.Name = "emailAddressEditBox";
            this.helpProvider1.SetShowHelp(this.emailAddressEditBox, ((bool)(resources.GetObject("emailAddressEditBox.ShowHelp"))));
            this.emailAddressEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // faxNumberMaskedEditBox
            // 
            this.faxNumberMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "FaxNumber", true));
            resources.ApplyResources(this.faxNumberMaskedEditBox, "faxNumberMaskedEditBox");
            this.faxNumberMaskedEditBox.Mask = "(000) 000-0000";
            this.faxNumberMaskedEditBox.Name = "faxNumberMaskedEditBox";
            this.faxNumberMaskedEditBox.Numeric = true;
            this.helpProvider1.SetShowHelp(this.faxNumberMaskedEditBox, ((bool)(resources.GetObject("faxNumberMaskedEditBox.ShowHelp"))));
            this.faxNumberMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // cellPhoneMaskedEditBox
            // 
            this.cellPhoneMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "CellPhone", true));
            resources.ApplyResources(this.cellPhoneMaskedEditBox, "cellPhoneMaskedEditBox");
            this.cellPhoneMaskedEditBox.Mask = "(000) 000-0000";
            this.cellPhoneMaskedEditBox.Name = "cellPhoneMaskedEditBox";
            this.cellPhoneMaskedEditBox.Numeric = true;
            this.helpProvider1.SetShowHelp(this.cellPhoneMaskedEditBox, ((bool)(resources.GetObject("cellPhoneMaskedEditBox.ShowHelp"))));
            this.cellPhoneMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // telephoneExtensionEditBox
            // 
            this.telephoneExtensionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "TelephoneExtension", true));
            resources.ApplyResources(this.telephoneExtensionEditBox, "telephoneExtensionEditBox");
            this.telephoneExtensionEditBox.Name = "telephoneExtensionEditBox";
            this.helpProvider1.SetShowHelp(this.telephoneExtensionEditBox, ((bool)(resources.GetObject("telephoneExtensionEditBox.ShowHelp"))));
            this.telephoneExtensionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // telephoneNumberMaskedEditBox
            // 
            this.telephoneNumberMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "TelephoneNumber", true));
            resources.ApplyResources(this.telephoneNumberMaskedEditBox, "telephoneNumberMaskedEditBox");
            this.telephoneNumberMaskedEditBox.Mask = "(000) 000-0000";
            this.telephoneNumberMaskedEditBox.Name = "telephoneNumberMaskedEditBox";
            this.telephoneNumberMaskedEditBox.Numeric = true;
            this.helpProvider1.SetShowHelp(this.telephoneNumberMaskedEditBox, ((bool)(resources.GetObject("telephoneNumberMaskedEditBox.ShowHelp"))));
            this.telephoneNumberMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // positionTitleFreEditBox
            // 
            this.positionTitleFreEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "PositionTitleFre", true));
            resources.ApplyResources(this.positionTitleFreEditBox, "positionTitleFreEditBox");
            this.positionTitleFreEditBox.Name = "positionTitleFreEditBox";
            this.helpProvider1.SetShowHelp(this.positionTitleFreEditBox, ((bool)(resources.GetObject("positionTitleFreEditBox.ShowHelp"))));
            this.positionTitleFreEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // positionTitleEditBox
            // 
            this.positionTitleEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "PositionTitle", true));
            resources.ApplyResources(this.positionTitleEditBox, "positionTitleEditBox");
            this.positionTitleEditBox.Name = "positionTitleEditBox";
            this.helpProvider1.SetShowHelp(this.positionTitleEditBox, ((bool)(resources.GetObject("positionTitleEditBox.ShowHelp"))));
            this.positionTitleEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // positionCodeucMultiDropDown
            // 
            this.positionCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.positionCodeucMultiDropDown.Column1 = "positioncode";
            resources.ApplyResources(this.positionCodeucMultiDropDown, "positionCodeucMultiDropDown");
            this.positionCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.positionCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officerBindingSource, "PositionCode", true));
            this.positionCodeucMultiDropDown.DataSource = null;
            this.positionCodeucMultiDropDown.DDColumn1Visible = true;
            this.positionCodeucMultiDropDown.DropDownColumn1Width = 50;
            this.positionCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.positionCodeucMultiDropDown.Name = "positionCodeucMultiDropDown";
            this.positionCodeucMultiDropDown.ReadOnly = false;
            this.positionCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.positionCodeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.positionCodeucMultiDropDown, ((bool)(resources.GetObject("positionCodeucMultiDropDown.ShowHelp"))));
            this.positionCodeucMultiDropDown.ValueMember = "positioncode";
            // 
            // currentEmployeeUICheckBox
            // 
            this.currentEmployeeUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.currentEmployeeUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentEmployeeUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officerBindingSource, "CurrentEmployee", true));
            resources.ApplyResources(this.currentEmployeeUICheckBox, "currentEmployeeUICheckBox");
            this.currentEmployeeUICheckBox.Name = "currentEmployeeUICheckBox";
            this.helpProvider1.SetShowHelp(this.currentEmployeeUICheckBox, ((bool)(resources.GetObject("currentEmployeeUICheckBox.ShowHelp"))));
            this.currentEmployeeUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // notesEditBox
            // 
            this.notesEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "Notes", true));
            resources.ApplyResources(this.notesEditBox, "notesEditBox");
            this.notesEditBox.Multiline = true;
            this.notesEditBox.Name = "notesEditBox";
            this.helpProvider1.SetShowHelp(this.notesEditBox, ((bool)(resources.GetObject("notesEditBox.ShowHelp"))));
            this.notesEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // suffixEditBox
            // 
            this.suffixEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "Suffix", true));
            resources.ApplyResources(this.suffixEditBox, "suffixEditBox");
            this.suffixEditBox.Name = "suffixEditBox";
            this.helpProvider1.SetShowHelp(this.suffixEditBox, ((bool)(resources.GetObject("suffixEditBox.ShowHelp"))));
            this.suffixEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lastNameEditBox
            // 
            this.lastNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "LastName", true));
            resources.ApplyResources(this.lastNameEditBox, "lastNameEditBox");
            this.lastNameEditBox.Name = "lastNameEditBox";
            this.helpProvider1.SetShowHelp(this.lastNameEditBox, ((bool)(resources.GetObject("lastNameEditBox.ShowHelp"))));
            this.lastNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // middleNameEditBox
            // 
            this.middleNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "MiddleName", true));
            resources.ApplyResources(this.middleNameEditBox, "middleNameEditBox");
            this.middleNameEditBox.Name = "middleNameEditBox";
            this.helpProvider1.SetShowHelp(this.middleNameEditBox, ((bool)(resources.GetObject("middleNameEditBox.ShowHelp"))));
            this.middleNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // firstNameEditBox
            // 
            this.firstNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "FirstName", true));
            resources.ApplyResources(this.firstNameEditBox, "firstNameEditBox");
            this.firstNameEditBox.Name = "firstNameEditBox";
            this.helpProvider1.SetShowHelp(this.firstNameEditBox, ((bool)(resources.GetObject("firstNameEditBox.ShowHelp"))));
            this.firstNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // salutationEditBox
            // 
            this.salutationEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "Salutation", true));
            resources.ApplyResources(this.salutationEditBox, "salutationEditBox");
            this.salutationEditBox.Name = "salutationEditBox";
            this.helpProvider1.SetShowHelp(this.salutationEditBox, ((bool)(resources.GetObject("salutationEditBox.ShowHelp"))));
            this.salutationEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officerCodeEditBox
            // 
            this.officerCodeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officerBindingSource, "OfficerCode", true));
            resources.ApplyResources(this.officerCodeEditBox, "officerCodeEditBox");
            this.officerCodeEditBox.Name = "officerCodeEditBox";
            this.helpProvider1.SetShowHelp(this.officerCodeEditBox, ((bool)(resources.GetObject("officerCodeEditBox.ShowHelp"))));
            this.officerCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiTabPage2
            // 
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Controls.Add(this.btnAddNewEmailAddress);
            this.uiTabPage2.Controls.Add(this.contactEmailGridEX);
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            // 
            // btnAddNewEmailAddress
            // 
            this.btnAddNewEmailAddress.Image = global::LawMate.Properties.Resources.AddEmail;
            resources.ApplyResources(this.btnAddNewEmailAddress, "btnAddNewEmailAddress");
            this.btnAddNewEmailAddress.Name = "btnAddNewEmailAddress";
            this.btnAddNewEmailAddress.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnAddNewEmailAddress, ((bool)(resources.GetObject("btnAddNewEmailAddress.ShowHelp"))));
            this.btnAddNewEmailAddress.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnAddNewEmailAddress.Click += new System.EventHandler(this.btnAddEmail_Click);
            // 
            // contactEmailGridEX
            // 
            this.contactEmailGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.contactEmailGridEX.DataSource = this.contactEmailBindingSource;
            resources.ApplyResources(contactEmailGridEX_DesignTimeLayout, "contactEmailGridEX_DesignTimeLayout");
            this.contactEmailGridEX.DesignTimeLayout = contactEmailGridEX_DesignTimeLayout;
            this.contactEmailGridEX.GroupByBoxVisible = false;
            resources.ApplyResources(this.contactEmailGridEX, "contactEmailGridEX");
            this.contactEmailGridEX.Name = "contactEmailGridEX";
            this.contactEmailGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.helpProvider1.SetShowHelp(this.contactEmailGridEX, ((bool)(resources.GetObject("contactEmailGridEX.ShowHelp"))));
            this.contactEmailGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.contactEmailGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // contactEmailBindingSource
            // 
            this.contactEmailBindingSource.DataMember = "Officer_ContactEmail";
            this.contactEmailBindingSource.DataSource = this.officerBindingSource;
            // 
            // uiTabPage3
            // 
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Controls.Add(label5);
            this.uiTabPage3.Controls.Add(this.ucFSPersonal);
            this.uiTabPage3.Controls.Add(label2);
            this.uiTabPage3.Controls.Add(label3);
            this.uiTabPage3.Controls.Add(this.ucFSShortcut);
            this.uiTabPage3.Controls.Add(this.ucFSInbox);
            this.uiTabPage3.Controls.Add(label4);
            this.uiTabPage3.Controls.Add(this.ucFSSentItems);
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // ucFSPersonal
            // 
            this.ucFSPersonal.AtMng = null;
            this.ucFSPersonal.BackColor = System.Drawing.Color.Transparent;
            this.ucFSPersonal.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.officerBindingSource, "MyFileId", true));
            this.ucFSPersonal.FileId = null;
            resources.ApplyResources(this.ucFSPersonal, "ucFSPersonal");
            this.ucFSPersonal.Name = "ucFSPersonal";
            this.ucFSPersonal.ReadOnly = false;
            this.ucFSPersonal.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucFSPersonal, ((bool)(resources.GetObject("ucFSPersonal.ShowHelp"))));
            // 
            // ucFSShortcut
            // 
            this.ucFSShortcut.AtMng = null;
            this.ucFSShortcut.BackColor = System.Drawing.Color.Transparent;
            this.ucFSShortcut.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.officerBindingSource, "ShortcutsId", true));
            this.ucFSShortcut.FileId = null;
            resources.ApplyResources(this.ucFSShortcut, "ucFSShortcut");
            this.ucFSShortcut.Name = "ucFSShortcut";
            this.ucFSShortcut.ReadOnly = false;
            this.ucFSShortcut.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucFSShortcut, ((bool)(resources.GetObject("ucFSShortcut.ShowHelp"))));
            // 
            // ucFSInbox
            // 
            this.ucFSInbox.AtMng = null;
            this.ucFSInbox.BackColor = System.Drawing.Color.Transparent;
            this.ucFSInbox.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.officerBindingSource, "InboxId", true));
            this.ucFSInbox.FileId = null;
            resources.ApplyResources(this.ucFSInbox, "ucFSInbox");
            this.ucFSInbox.Name = "ucFSInbox";
            this.ucFSInbox.ReadOnly = false;
            this.ucFSInbox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucFSInbox, ((bool)(resources.GetObject("ucFSInbox.ShowHelp"))));
            // 
            // ucFSSentItems
            // 
            this.ucFSSentItems.AtMng = null;
            this.ucFSSentItems.BackColor = System.Drawing.Color.Transparent;
            this.ucFSSentItems.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.officerBindingSource, "SentItemsId", true));
            this.ucFSSentItems.FileId = null;
            resources.ApplyResources(this.ucFSSentItems, "ucFSSentItems");
            this.ucFSSentItems.Name = "ucFSSentItems";
            this.ucFSSentItems.ReadOnly = false;
            this.ucFSSentItems.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucFSSentItems, ((bool)(resources.GetObject("ucFSSentItems.ShowHelp"))));
            // 
            // uiTabPage4
            // 
            resources.ApplyResources(this.uiTabPage4, "uiTabPage4");
            this.uiTabPage4.Controls.Add(this.btnAddNewOfficerRole);
            this.uiTabPage4.Controls.Add(this.btnAddNewDelegate);
            this.uiTabPage4.Controls.Add(this.officerRoleGridEX);
            this.uiTabPage4.Controls.Add(this.officerDelegateGridEX);
            this.uiTabPage4.Name = "uiTabPage4";
            this.helpProvider1.SetShowHelp(this.uiTabPage4, ((bool)(resources.GetObject("uiTabPage4.ShowHelp"))));
            this.uiTabPage4.TabStop = true;
            // 
            // btnAddNewOfficerRole
            // 
            this.btnAddNewOfficerRole.Image = global::LawMate.Properties.Resources.roles;
            resources.ApplyResources(this.btnAddNewOfficerRole, "btnAddNewOfficerRole");
            this.btnAddNewOfficerRole.Name = "btnAddNewOfficerRole";
            this.btnAddNewOfficerRole.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnAddNewOfficerRole, ((bool)(resources.GetObject("btnAddNewOfficerRole.ShowHelp"))));
            this.btnAddNewOfficerRole.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnAddNewOfficerRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnAddNewDelegate
            // 
            this.btnAddNewDelegate.Image = global::LawMate.Properties.Resources.Delegate;
            resources.ApplyResources(this.btnAddNewDelegate, "btnAddNewDelegate");
            this.btnAddNewDelegate.Name = "btnAddNewDelegate";
            this.btnAddNewDelegate.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnAddNewDelegate, ((bool)(resources.GetObject("btnAddNewDelegate.ShowHelp"))));
            this.btnAddNewDelegate.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnAddNewDelegate.Click += new System.EventHandler(this.btnNewDelegate_Click);
            // 
            // officerRoleGridEX
            // 
            this.officerRoleGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.officerRoleGridEX.AlternatingColors = true;
            this.officerRoleGridEX.DataSource = this.officerRoleBindingSource;
            officerRoleGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("officerRoleGridEX_DesignTimeLayout_Reference_0.Instance")));
            officerRoleGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            officerRoleGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(officerRoleGridEX_DesignTimeLayout, "officerRoleGridEX_DesignTimeLayout");
            this.officerRoleGridEX.DesignTimeLayout = officerRoleGridEX_DesignTimeLayout;
            this.officerRoleGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.officerRoleGridEX, "officerRoleGridEX");
            this.officerRoleGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.officerRoleGridEX.GroupByBoxVisible = false;
            this.officerRoleGridEX.Name = "officerRoleGridEX";
            this.officerRoleGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.helpProvider1.SetShowHelp(this.officerRoleGridEX, ((bool)(resources.GetObject("officerRoleGridEX.ShowHelp"))));
            this.officerRoleGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.officerRoleGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.officerRoleGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.officerRoleGridEX_ColumnButtonClick);
            // 
            // officerRoleBindingSource
            // 
            this.officerRoleBindingSource.DataMember = "Officer_OfficerRole";
            this.officerRoleBindingSource.DataSource = this.officerBindingSource;
            // 
            // officerDelegateGridEX
            // 
            this.officerDelegateGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.officerDelegateGridEX.AlternatingColors = true;
            this.officerDelegateGridEX.DataSource = this.officerDelegateBindingSource;
            officerDelegateGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("officerDelegateGridEX_DesignTimeLayout_Reference_0.Instance")));
            officerDelegateGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            officerDelegateGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(officerDelegateGridEX_DesignTimeLayout, "officerDelegateGridEX_DesignTimeLayout");
            this.officerDelegateGridEX.DesignTimeLayout = officerDelegateGridEX_DesignTimeLayout;
            this.officerDelegateGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.officerDelegateGridEX, "officerDelegateGridEX");
            this.officerDelegateGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.officerDelegateGridEX.GroupByBoxVisible = false;
            this.officerDelegateGridEX.Name = "officerDelegateGridEX";
            this.officerDelegateGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.helpProvider1.SetShowHelp(this.officerDelegateGridEX, ((bool)(resources.GetObject("officerDelegateGridEX.ShowHelp"))));
            this.officerDelegateGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.officerDelegateGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.officerDelegateGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.officerDelegateGridEX_ColumnButtonClick);
            // 
            // officerDelegateBindingSource
            // 
            this.officerDelegateBindingSource.DataMember = "Officer_OfficerDelegate";
            this.officerDelegateBindingSource.DataSource = this.officerBindingSource;
            // 
            // uiTabPage5
            // 
            this.uiTabPage5.Controls.Add(label10);
            this.uiTabPage5.Controls.Add(label9);
            this.uiTabPage5.Controls.Add(this.endTimeCalendarCombo);
            this.uiTabPage5.Controls.Add(this.startTimeCalendarCombo);
            this.uiTabPage5.Controls.Add(this.chkOutOfOffice);
            this.uiTabPage5.Controls.Add(this.endDateCalendarCombo);
            this.uiTabPage5.Controls.Add(startDateLabel);
            this.uiTabPage5.Controls.Add(this.startDateCalendarCombo);
            this.uiTabPage5.Controls.Add(endDateLabel);
            resources.ApplyResources(this.uiTabPage5, "uiTabPage5");
            this.uiTabPage5.Name = "uiTabPage5";
            this.helpProvider1.SetShowHelp(this.uiTabPage5, ((bool)(resources.GetObject("uiTabPage5.ShowHelp"))));
            this.uiTabPage5.TabStop = true;
            // 
            // endTimeCalendarCombo
            // 
            resources.ApplyResources(this.endTimeCalendarCombo, "endTimeCalendarCombo");
            this.endTimeCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officerBindingSource, "OutOfOfficeEndDateLocal", true));
            // 
            // 
            // 
            this.endTimeCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endTimeCalendarCombo.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.endTimeCalendarCombo.MinuteIncrement = 15;
            this.endTimeCalendarCombo.Name = "endTimeCalendarCombo";
            this.endTimeCalendarCombo.ShowDropDown = false;
            this.helpProvider1.SetShowHelp(this.endTimeCalendarCombo, ((bool)(resources.GetObject("endTimeCalendarCombo.ShowHelp"))));
            this.endTimeCalendarCombo.ShowUpDown = true;
            this.endTimeCalendarCombo.Value = new System.DateTime(2016, 7, 6, 0, 0, 0, 0);
            this.endTimeCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // startTimeCalendarCombo
            // 
            resources.ApplyResources(this.startTimeCalendarCombo, "startTimeCalendarCombo");
            this.startTimeCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officerBindingSource, "OutOfOfficeStartDateLocal", true));
            // 
            // 
            // 
            this.startTimeCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startTimeCalendarCombo.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.startTimeCalendarCombo.MinuteIncrement = 15;
            this.startTimeCalendarCombo.Name = "startTimeCalendarCombo";
            this.startTimeCalendarCombo.ShowDropDown = false;
            this.helpProvider1.SetShowHelp(this.startTimeCalendarCombo, ((bool)(resources.GetObject("startTimeCalendarCombo.ShowHelp"))));
            this.startTimeCalendarCombo.ShowUpDown = true;
            this.startTimeCalendarCombo.Value = new System.DateTime(2016, 7, 6, 0, 0, 0, 0);
            this.startTimeCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // chkOutOfOffice
            // 
            resources.ApplyResources(this.chkOutOfOffice, "chkOutOfOffice");
            this.chkOutOfOffice.BackColor = System.Drawing.Color.Transparent;
            this.chkOutOfOffice.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.officerBindingSource, "OutOfOffice", true));
            this.chkOutOfOffice.Name = "chkOutOfOffice";
            this.helpProvider1.SetShowHelp(this.chkOutOfOffice, ((bool)(resources.GetObject("chkOutOfOffice.ShowHelp"))));
            this.toolTip1.SetToolTip(this.chkOutOfOffice, resources.GetString("chkOutOfOffice.ToolTip"));
            this.chkOutOfOffice.UseVisualStyleBackColor = false;
            this.chkOutOfOffice.CheckedChanged += new System.EventHandler(this.chkOutOfOffice_CheckedChanged);
            // 
            // endDateCalendarCombo
            // 
            resources.ApplyResources(this.endDateCalendarCombo, "endDateCalendarCombo");
            this.endDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officerBindingSource, "OutOfOfficeEndDateLocal", true));
            // 
            // 
            // 
            this.endDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.Name = "endDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.endDateCalendarCombo, ((bool)(resources.GetObject("endDateCalendarCombo.ShowHelp"))));
            this.endDateCalendarCombo.Value = new System.DateTime(2016, 7, 6, 0, 0, 0, 0);
            this.endDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // startDateCalendarCombo
            // 
            resources.ApplyResources(this.startDateCalendarCombo, "startDateCalendarCombo");
            this.startDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officerBindingSource, "OutOfOfficeStartDateLocal", true));
            // 
            // 
            // 
            this.startDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startDateCalendarCombo.Name = "startDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.startDateCalendarCombo, ((bool)(resources.GetObject("startDateCalendarCombo.ShowHelp"))));
            this.startDateCalendarCombo.Value = new System.DateTime(2016, 7, 6, 0, 0, 0, 0);
            this.startDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // tribunalTabPage
            // 
            resources.ApplyResources(this.tribunalTabPage, "tribunalTabPage");
            this.tribunalTabPage.Controls.Add(this.addAddressBtn);
            this.tribunalTabPage.Controls.Add(this.uiGroupBox2);
            this.tribunalTabPage.Controls.Add(this.addressGroupBox);
            this.tribunalTabPage.Controls.Add(this.uiGroupBox7);
            this.tribunalTabPage.Controls.Add(this.trainingGroupBox);
            this.tribunalTabPage.Controls.Add(this.gbParticipant);
            this.tribunalTabPage.Controls.Add(this.uiGroupBoxLanguage);
            this.tribunalTabPage.Name = "tribunalTabPage";
            this.helpProvider1.SetShowHelp(this.tribunalTabPage, ((bool)(resources.GetObject("tribunalTabPage.ShowHelp"))));
            this.tribunalTabPage.TabStop = true;
            this.tribunalTabPage.Click += new System.EventHandler(this.tribunalTabPage_Click);
            // 
            // addAddressBtn
            // 
            this.addAddressBtn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.addAddressBtn, "addAddressBtn");
            this.addAddressBtn.Name = "addAddressBtn";
            this.helpProvider1.SetShowHelp(this.addAddressBtn, ((bool)(resources.GetObject("addAddressBtn.ShowHelp"))));
            this.addAddressBtn.Click += new System.EventHandler(this.addAddressBtn_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.Controls.Add(this.confIDeditBox);
            this.uiGroupBox2.Controls.Add(this.phoneNumberEditBox);
            this.uiGroupBox2.Controls.Add(this.label1);
            this.uiGroupBox2.Controls.Add(this.label6);
            this.uiGroupBox2.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.uiGroupBox2, "uiGroupBox2");
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.helpProvider1.SetShowHelp(this.uiGroupBox2, ((bool)(resources.GetObject("uiGroupBox2.ShowHelp"))));
            this.uiGroupBox2.UseThemes = false;
            // 
            // confIDeditBox
            // 
            this.confIDeditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberProfileBindingSource, "ConferenceID", true));
            resources.ApplyResources(this.confIDeditBox, "confIDeditBox");
            this.confIDeditBox.Mask = "0000000";
            this.confIDeditBox.Name = "confIDeditBox";
            this.helpProvider1.SetShowHelp(this.confIDeditBox, ((bool)(resources.GetObject("confIDeditBox.ShowHelp"))));
            // 
            // memberProfileBindingSource
            // 
            this.memberProfileBindingSource.DataMember = "Officer_MemberProfile";
            this.memberProfileBindingSource.DataSource = this.officerBindingSource;
            // 
            // phoneNumberEditBox
            // 
            this.phoneNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberProfileBindingSource, "ConferenceNumber", true));
            resources.ApplyResources(this.phoneNumberEditBox, "phoneNumberEditBox");
            this.phoneNumberEditBox.Mask = "0-000 000-0000";
            this.phoneNumberEditBox.Name = "phoneNumberEditBox";
            this.helpProvider1.SetShowHelp(this.phoneNumberEditBox, ((bool)(resources.GetObject("phoneNumberEditBox.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.helpProvider1.SetShowHelp(this.label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            // 
            // addressGroupBox
            // 
            this.addressGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.addressGroupBox.Controls.Add(this.ucAddress);
            this.addressGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.addressGroupBox, "addressGroupBox");
            this.addressGroupBox.Name = "addressGroupBox";
            this.helpProvider1.SetShowHelp(this.addressGroupBox, ((bool)(resources.GetObject("addressGroupBox.ShowHelp"))));
            this.addressGroupBox.UseThemes = false;
            // 
            // ucAddress
            // 
            this.ucAddress.BackColor = System.Drawing.Color.Transparent;
            this.ucAddress.ColumnTwoLeftPositionOffset = 0;
            this.ucAddress.FM = null;
            resources.ApplyResources(this.ucAddress, "ucAddress");
            this.ucAddress.IsReadOnly = false;
            this.ucAddress.Name = "ucAddress";
            this.ucAddress.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucAddress, ((bool)(resources.GetObject("ucAddress.ShowHelp"))));
            // 
            // uiGroupBox7
            // 
            this.uiGroupBox7.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox7.Controls.Add(this.calExpiryDate);
            this.uiGroupBox7.Controls.Add(this.lblExpiryDate);
            this.uiGroupBox7.Controls.Add(this.calStartDate);
            this.uiGroupBox7.Controls.Add(this.lblStartDate);
            this.uiGroupBox7.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.uiGroupBox7, "uiGroupBox7");
            this.uiGroupBox7.Name = "uiGroupBox7";
            this.helpProvider1.SetShowHelp(this.uiGroupBox7, ((bool)(resources.GetObject("uiGroupBox7.ShowHelp"))));
            this.uiGroupBox7.UseThemes = false;
            // 
            // calExpiryDate
            // 
            resources.ApplyResources(this.calExpiryDate, "calExpiryDate");
            this.calExpiryDate.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "AppointmentEndDate", true));
            this.calExpiryDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calExpiryDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calExpiryDate.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calExpiryDate.MonthIncrement = 0;
            this.calExpiryDate.Name = "calExpiryDate";
            this.helpProvider1.SetShowHelp(this.calExpiryDate, ((bool)(resources.GetObject("calExpiryDate.ShowHelp"))));
            this.calExpiryDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calExpiryDate.YearIncrement = 0;
            // 
            // lblExpiryDate
            // 
            resources.ApplyResources(this.lblExpiryDate, "lblExpiryDate");
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.helpProvider1.SetShowHelp(this.lblExpiryDate, ((bool)(resources.GetObject("lblExpiryDate.ShowHelp"))));
            // 
            // calStartDate
            // 
            resources.ApplyResources(this.calStartDate, "calStartDate");
            this.calStartDate.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "AppointmentStartDate", true));
            this.calStartDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calStartDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calStartDate.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calStartDate.MonthIncrement = 0;
            this.calStartDate.Name = "calStartDate";
            this.helpProvider1.SetShowHelp(this.calStartDate, ((bool)(resources.GetObject("calStartDate.ShowHelp"))));
            this.calStartDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calStartDate.YearIncrement = 0;
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            this.helpProvider1.SetShowHelp(this.lblStartDate, ((bool)(resources.GetObject("lblStartDate.ShowHelp"))));
            // 
            // trainingGroupBox
            // 
            this.trainingGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.trainingGroupBox.Controls.Add(this.TrainedCharterCheckBox);
            this.trainingGroupBox.Controls.Add(this.trainedEICheckBox);
            this.trainingGroupBox.Controls.Add(this.trainedOASCheckBox);
            this.trainingGroupBox.Controls.Add(this.trainedCPPCheckBox);
            this.trainingGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.trainingGroupBox, "trainingGroupBox");
            this.trainingGroupBox.Name = "trainingGroupBox";
            this.helpProvider1.SetShowHelp(this.trainingGroupBox, ((bool)(resources.GetObject("trainingGroupBox.ShowHelp"))));
            this.trainingGroupBox.UseThemes = false;
            // 
            // TrainedCharterCheckBox
            // 
            this.TrainedCharterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TrainedCharterCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "TrainedCharter", true));
            resources.ApplyResources(this.TrainedCharterCheckBox, "TrainedCharterCheckBox");
            this.TrainedCharterCheckBox.Name = "TrainedCharterCheckBox";
            this.helpProvider1.SetShowHelp(this.TrainedCharterCheckBox, ((bool)(resources.GetObject("TrainedCharterCheckBox.ShowHelp"))));
            this.TrainedCharterCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // trainedEICheckBox
            // 
            this.trainedEICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.trainedEICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "TrainedEI", true));
            resources.ApplyResources(this.trainedEICheckBox, "trainedEICheckBox");
            this.trainedEICheckBox.Name = "trainedEICheckBox";
            this.helpProvider1.SetShowHelp(this.trainedEICheckBox, ((bool)(resources.GetObject("trainedEICheckBox.ShowHelp"))));
            this.trainedEICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // trainedOASCheckBox
            // 
            this.trainedOASCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.trainedOASCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "TrainedOAS", true));
            resources.ApplyResources(this.trainedOASCheckBox, "trainedOASCheckBox");
            this.trainedOASCheckBox.Name = "trainedOASCheckBox";
            this.helpProvider1.SetShowHelp(this.trainedOASCheckBox, ((bool)(resources.GetObject("trainedOASCheckBox.ShowHelp"))));
            this.trainedOASCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // trainedCPPCheckBox
            // 
            this.trainedCPPCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.trainedCPPCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "TrainedCPP", true));
            resources.ApplyResources(this.trainedCPPCheckBox, "trainedCPPCheckBox");
            this.trainedCPPCheckBox.Name = "trainedCPPCheckBox";
            this.helpProvider1.SetShowHelp(this.trainedCPPCheckBox, ((bool)(resources.GetObject("trainedCPPCheckBox.ShowHelp"))));
            this.trainedCPPCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // gbParticipant
            // 
            this.gbParticipant.BackColor = System.Drawing.Color.Transparent;
            this.gbParticipant.Controls.Add(label7);
            this.gbParticipant.Controls.Add(this.appealLevelDropDown);
            this.gbParticipant.Controls.Add(this.isCheckBox);
            this.gbParticipant.Controls.Add(this.eiCheckBox);
            resources.ApplyResources(this.gbParticipant, "gbParticipant");
            this.gbParticipant.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbParticipant.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbParticipant.Name = "gbParticipant";
            this.helpProvider1.SetShowHelp(this.gbParticipant, ((bool)(resources.GetObject("gbParticipant.ShowHelp"))));
            this.gbParticipant.UseThemes = false;
            this.gbParticipant.Click += new System.EventHandler(this.gbParticipant_Click);
            // 
            // appealLevelDropDown
            // 
            this.appealLevelDropDown.BackColor = System.Drawing.Color.Transparent;
            this.appealLevelDropDown.Column1 = "AppealLevelId";
            resources.ApplyResources(this.appealLevelDropDown, "appealLevelDropDown");
            this.appealLevelDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.appealLevelDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.memberProfileBindingSource, "AppealLevelId", true));
            this.appealLevelDropDown.DataSource = null;
            this.appealLevelDropDown.DDColumn1Visible = false;
            this.appealLevelDropDown.DropDownColumn1Width = 50;
            this.appealLevelDropDown.DropDownColumn2Width = 250;
            this.appealLevelDropDown.Name = "appealLevelDropDown";
            this.appealLevelDropDown.ReadOnly = false;
            this.appealLevelDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.appealLevelDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.appealLevelDropDown, ((bool)(resources.GetObject("appealLevelDropDown.ShowHelp"))));
            this.appealLevelDropDown.ValueMember = "AppealLevelId";
            // 
            // isCheckBox
            // 
            this.isCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "CanHearIS", true));
            resources.ApplyResources(this.isCheckBox, "isCheckBox");
            this.isCheckBox.Name = "isCheckBox";
            this.helpProvider1.SetShowHelp(this.isCheckBox, ((bool)(resources.GetObject("isCheckBox.ShowHelp"))));
            this.isCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // eiCheckBox
            // 
            this.eiCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eiCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "CanHearEI", true));
            resources.ApplyResources(this.eiCheckBox, "eiCheckBox");
            this.eiCheckBox.Name = "eiCheckBox";
            this.helpProvider1.SetShowHelp(this.eiCheckBox, ((bool)(resources.GetObject("eiCheckBox.ShowHelp"))));
            this.eiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiGroupBoxLanguage
            // 
            this.uiGroupBoxLanguage.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBoxLanguage.Controls.Add(this.langFrenchCheckBox);
            this.uiGroupBoxLanguage.Controls.Add(this.langEnglishCheckBox);
            this.uiGroupBoxLanguage.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.uiGroupBoxLanguage, "uiGroupBoxLanguage");
            this.uiGroupBoxLanguage.Name = "uiGroupBoxLanguage";
            this.helpProvider1.SetShowHelp(this.uiGroupBoxLanguage, ((bool)(resources.GetObject("uiGroupBoxLanguage.ShowHelp"))));
            this.uiGroupBoxLanguage.UseThemes = false;
            // 
            // langFrenchCheckBox
            // 
            this.langFrenchCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.langFrenchCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "CanHearFre", true));
            resources.ApplyResources(this.langFrenchCheckBox, "langFrenchCheckBox");
            this.langFrenchCheckBox.Name = "langFrenchCheckBox";
            this.helpProvider1.SetShowHelp(this.langFrenchCheckBox, ((bool)(resources.GetObject("langFrenchCheckBox.ShowHelp"))));
            this.langFrenchCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // langEnglishCheckBox
            // 
            this.langEnglishCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.langEnglishCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.memberProfileBindingSource, "CanHearEng", true));
            resources.ApplyResources(this.langEnglishCheckBox, "langEnglishCheckBox");
            this.langEnglishCheckBox.Name = "langEnglishCheckBox";
            this.helpProvider1.SetShowHelp(this.langEnglishCheckBox, ((bool)(resources.GetObject("langEnglishCheckBox.ShowHelp"))));
            this.langEnglishCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiPanel0
            // 
            this.uiPanel0.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            resources.ApplyResources(this.uiPanel0, "uiPanel0");
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.SelectedPanel = this.pnlDelegateRole;
            this.helpProvider1.SetShowHelp(this.uiPanel0, ((bool)(resources.GetObject("uiPanel0.ShowHelp"))));
            this.uiPanel0.TabAlignment = Janus.Windows.UI.Dock.TabAlignment.Top;
            this.uiPanel0.TabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.ImageAndText;
            // 
            // pnlDelegateRole
            // 
            this.pnlDelegateRole.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlDelegateRole.InnerContainer = this.pnlDelegateRoleContainer;
            resources.ApplyResources(this.pnlDelegateRole, "pnlDelegateRole");
            this.pnlDelegateRole.Name = "pnlDelegateRole";
            this.helpProvider1.SetShowHelp(this.pnlDelegateRole, ((bool)(resources.GetObject("pnlDelegateRole.ShowHelp"))));
            // 
            // pnlDelegateRoleContainer
            // 
            resources.ApplyResources(this.pnlDelegateRoleContainer, "pnlDelegateRoleContainer");
            this.pnlDelegateRoleContainer.Name = "pnlDelegateRoleContainer";
            this.helpProvider1.SetShowHelp(this.pnlDelegateRoleContainer, ((bool)(resources.GetObject("pnlDelegateRoleContainer.ShowHelp"))));
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlUserInfo.InnerContainer = this.pnlUserInfoContainer;
            resources.ApplyResources(this.pnlUserInfo, "pnlUserInfo");
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.helpProvider1.SetShowHelp(this.pnlUserInfo, ((bool)(resources.GetObject("pnlUserInfo.ShowHelp"))));
            // 
            // pnlUserInfoContainer
            // 
            resources.ApplyResources(this.pnlUserInfoContainer, "pnlUserInfoContainer");
            this.pnlUserInfoContainer.Name = "pnlUserInfoContainer";
            this.helpProvider1.SetShowHelp(this.pnlUserInfoContainer, ((bool)(resources.GetObject("pnlUserInfoContainer.ShowHelp"))));
            // 
            // pnlAlternateEmail
            // 
            this.pnlAlternateEmail.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAlternateEmail.InnerContainer = this.pnlAlternateEmailContainer;
            resources.ApplyResources(this.pnlAlternateEmail, "pnlAlternateEmail");
            this.pnlAlternateEmail.Name = "pnlAlternateEmail";
            this.helpProvider1.SetShowHelp(this.pnlAlternateEmail, ((bool)(resources.GetObject("pnlAlternateEmail.ShowHelp"))));
            // 
            // pnlAlternateEmailContainer
            // 
            resources.ApplyResources(this.pnlAlternateEmailContainer, "pnlAlternateEmailContainer");
            this.pnlAlternateEmailContainer.Name = "pnlAlternateEmailContainer";
            this.helpProvider1.SetShowHelp(this.pnlAlternateEmailContainer, ((bool)(resources.GetObject("pnlAlternateEmailContainer.ShowHelp"))));
            // 
            // pnlPersonalFiles
            // 
            this.pnlPersonalFiles.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlPersonalFiles.InnerContainer = this.pnlSecurityContainer;
            resources.ApplyResources(this.pnlPersonalFiles, "pnlPersonalFiles");
            this.pnlPersonalFiles.Name = "pnlPersonalFiles";
            this.helpProvider1.SetShowHelp(this.pnlPersonalFiles, ((bool)(resources.GetObject("pnlPersonalFiles.ShowHelp"))));
            // 
            // pnlSecurityContainer
            // 
            resources.ApplyResources(this.pnlSecurityContainer, "pnlSecurityContainer");
            this.pnlSecurityContainer.Name = "pnlSecurityContainer";
            this.helpProvider1.SetShowHelp(this.pnlSecurityContainer, ((bool)(resources.GetObject("pnlSecurityContainer.ShowHelp"))));
            // 
            // secUserBindingSource
            // 
            this.secUserBindingSource.DataMember = "secUser";
            this.secUserBindingSource.DataSource = this.securityDB;
            // 
            // securityDB
            // 
            this.securityDB.DataSetName = "SecurityDB";
            this.securityDB.EnforceConstraints = false;
            this.securityDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // secMembershipBindingSource
            // 
            this.secMembershipBindingSource.DataMember = "FK_secMembership_secUser";
            this.secMembershipBindingSource.DataSource = this.secUserBindingSource;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete,
            this.tsSave,
            this.tsScreenTitle,
            this.tsEditmode,
            this.tsAudit,
            this.tsNew,
            this.tsSecurity,
            this.tsFilter,
            this.tsGroupBy,
            this.tsMyFile,
            this.cmdAddToAB,
            this.cmdFile,
            this.cmdEdit,
            this.cmdView,
            this.cmdTools,
            this.tsCopyPrefs});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = global::LawMate.Properties.Resources.usesAppMail;
            this.uiCommandManager1.Id = new System.Guid("0fed8b9a-6a2d-4b66-a4f2-8f3c99f22c05");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1,
            this.cmdView1,
            this.cmdTools1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
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
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsNew1,
            this.tsSave1,
            this.tsDelete1,
            this.Separator2,
            this.tsFilter1,
            this.tsGroupBy1,
            this.Separator4,
            this.tsSecurity1,
            this.tsMyFile1,
            this.tsCopyPrefs1,
            this.Separator3,
            this.cmdAddToAB1,
            this.tsAudit1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            this.uiCommandBar1.Wrappable = Janus.Windows.UI.InheritableBoolean.True;
            // 
            // tsEditmode1
            // 
            resources.ApplyResources(this.tsEditmode1, "tsEditmode1");
            this.tsEditmode1.Name = "tsEditmode1";
            // 
            // tsScreenTitle1
            // 
            this.tsScreenTitle1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsScreenTitle1.ControlWidth = 100;
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // tsNew1
            // 
            resources.ApplyResources(this.tsNew1, "tsNew1");
            this.tsNew1.Name = "tsNew1";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsFilter1
            // 
            resources.ApplyResources(this.tsFilter1, "tsFilter1");
            this.tsFilter1.Name = "tsFilter1";
            // 
            // tsGroupBy1
            // 
            resources.ApplyResources(this.tsGroupBy1, "tsGroupBy1");
            this.tsGroupBy1.Name = "tsGroupBy1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsSecurity1
            // 
            resources.ApplyResources(this.tsSecurity1, "tsSecurity1");
            this.tsSecurity1.Name = "tsSecurity1";
            // 
            // tsMyFile1
            // 
            resources.ApplyResources(this.tsMyFile1, "tsMyFile1");
            this.tsMyFile1.Name = "tsMyFile1";
            // 
            // tsCopyPrefs1
            // 
            resources.ApplyResources(this.tsCopyPrefs1, "tsCopyPrefs1");
            this.tsCopyPrefs1.Name = "tsCopyPrefs1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdAddToAB1
            // 
            resources.ApplyResources(this.cmdAddToAB1, "cmdAddToAB1");
            this.cmdAddToAB1.Name = "cmdAddToAB1";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
            // 
            // tsDelete
            // 
            resources.ApplyResources(this.tsDelete, "tsDelete");
            this.tsDelete.Name = "tsDelete";
            // 
            // tsSave
            // 
            resources.ApplyResources(this.tsSave, "tsSave");
            this.tsSave.Name = "tsSave";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            // 
            // tsAudit
            // 
            this.tsAudit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsNew
            // 
            resources.ApplyResources(this.tsNew, "tsNew");
            this.tsNew.Name = "tsNew";
            // 
            // tsSecurity
            // 
            this.tsSecurity.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsSecurity, "tsSecurity");
            this.tsSecurity.Name = "tsSecurity";
            // 
            // tsFilter
            // 
            this.tsFilter.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsFilter, "tsFilter");
            this.tsFilter.Name = "tsFilter";
            // 
            // tsGroupBy
            // 
            this.tsGroupBy.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.tsGroupBy.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsGroupBy, "tsGroupBy");
            this.tsGroupBy.Name = "tsGroupBy";
            // 
            // tsMyFile
            // 
            this.tsMyFile.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsMyFile, "tsMyFile");
            this.tsMyFile.Name = "tsMyFile";
            // 
            // cmdAddToAB
            // 
            this.cmdAddToAB.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdAddToAB, "cmdAddToAB");
            this.cmdAddToAB.Name = "cmdAddToAB";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsNew2,
            this.tsSave2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // tsNew2
            // 
            resources.ApplyResources(this.tsNew2, "tsNew2");
            this.tsNew2.Name = "tsNew2";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete2});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsFilter2,
            this.tsGroupBy2});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView.Name = "cmdView";
            // 
            // tsFilter2
            // 
            resources.ApplyResources(this.tsFilter2, "tsFilter2");
            this.tsFilter2.Name = "tsFilter2";
            // 
            // tsGroupBy2
            // 
            resources.ApplyResources(this.tsGroupBy2, "tsGroupBy2");
            this.tsGroupBy2.Name = "tsGroupBy2";
            // 
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSecurity2,
            this.tsMyFile2,
            this.cmdAddToAB2,
            this.tsCopyPrefs2});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdTools.Name = "cmdTools";
            // 
            // tsSecurity2
            // 
            resources.ApplyResources(this.tsSecurity2, "tsSecurity2");
            this.tsSecurity2.Name = "tsSecurity2";
            // 
            // tsMyFile2
            // 
            resources.ApplyResources(this.tsMyFile2, "tsMyFile2");
            this.tsMyFile2.Name = "tsMyFile2";
            // 
            // cmdAddToAB2
            // 
            resources.ApplyResources(this.cmdAddToAB2, "cmdAddToAB2");
            this.cmdAddToAB2.Name = "cmdAddToAB2";
            // 
            // tsCopyPrefs2
            // 
            resources.ApplyResources(this.tsCopyPrefs2, "tsCopyPrefs2");
            this.tsCopyPrefs2.Name = "tsCopyPrefs2";
            // 
            // tsCopyPrefs
            // 
            this.tsCopyPrefs.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsCopyPrefs, "tsCopyPrefs");
            this.tsCopyPrefs.Name = "tsCopyPrefs";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            this.helpProvider1.SetShowHelp(this.LeftRebar1, ((bool)(resources.GetObject("LeftRebar1.ShowHelp"))));
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            this.helpProvider1.SetShowHelp(this.RightRebar1, ((bool)(resources.GetObject("RightRebar1.ShowHelp"))));
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // ucOfficePersonnel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlRowDetails);
            this.Controls.Add(this.pnlOfficerGrid);
            this.Controls.Add(this.TopRebar1);
            resources.ApplyResources(this, "$this");
            this.Name = "ucOfficePersonnel";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.ucOfficePersonnel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOfficerGrid)).EndInit();
            this.pnlOfficerGrid.ResumeLayout(false);
            this.pnlOfficerGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officerGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRowDetails)).EndInit();
            this.pnlRowDetails.ResumeLayout(false);
            this.pnlRowDetailsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memberProfileTab)).EndInit();
            this.memberProfileTab.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            this.uiTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contactEmailGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactEmailBindingSource)).EndInit();
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            this.uiTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officerRoleGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerDelegateGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerDelegateBindingSource)).EndInit();
            this.uiTabPage5.ResumeLayout(false);
            this.uiTabPage5.PerformLayout();
            this.tribunalTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberProfileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressGroupBox)).EndInit();
            this.addressGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox7)).EndInit();
            this.uiGroupBox7.ResumeLayout(false);
            this.uiGroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingGroupBox)).EndInit();
            this.trainingGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbParticipant)).EndInit();
            this.gbParticipant.ResumeLayout(false);
            this.gbParticipant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBoxLanguage)).EndInit();
            this.uiGroupBoxLanguage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDelegateRole)).EndInit();
            this.pnlDelegateRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlUserInfo)).EndInit();
            this.pnlUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAlternateEmail)).EndInit();
            this.pnlAlternateEmail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPersonalFiles)).EndInit();
            this.pnlPersonalFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secMembershipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.GridEX.GridEX officerGridEX;
        private System.Windows.Forms.BindingSource officerBindingSource;
        private lmDatasets.officeDB officeDB;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsNew;
        private Janus.Windows.UI.CommandBars.UICommand tsNew1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand tsSecurity;
        private Janus.Windows.UI.CommandBars.UICommand tsSecurity1;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanel0;
        private Janus.Windows.UI.Dock.UIPanel pnlUserInfo;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlUserInfoContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlDelegateRole;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDelegateRoleContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlAlternateEmail;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAlternateEmailContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlPersonalFiles;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSecurityContainer;
        private Janus.Windows.GridEX.GridEX officerDelegateGridEX;
        private System.Windows.Forms.BindingSource officerDelegateBindingSource;
        private Janus.Windows.GridEX.GridEX contactEmailGridEX;
        private System.Windows.Forms.BindingSource contactEmailBindingSource;
        private Janus.Windows.GridEX.GridEX officerRoleGridEX;
        private System.Windows.Forms.BindingSource officerRoleBindingSource;
        private lmDatasets.SecurityDB securityDB;
        private System.Windows.Forms.BindingSource secUserBindingSource;
        private System.Windows.Forms.BindingSource secMembershipBindingSource;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter;
        private Janus.Windows.UI.CommandBars.UICommand tsGroupBy;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter1;
        private Janus.Windows.UI.CommandBars.UICommand tsGroupBy1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand tsMyFile;
        private Janus.Windows.UI.CommandBars.UICommand tsMyFile1;
        private ucFileSelectBox ucFSShortcut;
        private ucFileSelectBox ucFSSentItems;
        private ucFileSelectBox ucFSInbox;
        private ucFileSelectBox ucFSPersonal;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddToAB;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddToAB1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand tsNew2;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter2;
        private Janus.Windows.UI.CommandBars.UICommand tsGroupBy2;
        private Janus.Windows.UI.CommandBars.UICommand tsSecurity2;
        private Janus.Windows.UI.CommandBars.UICommand tsMyFile2;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddToAB2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.Dock.UIPanel pnlRowDetails;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlRowDetailsContainer;
        private Janus.Windows.UI.Tab.UITab memberProfileTab;
        private Janus.Windows.UI.Dock.UIPanel pnlOfficerGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlOfficerGridContainer;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage4;
        private Janus.Windows.EditControls.UICheckBox isMailUICheckBox;
        private UserControls.ucMultiDropDown assistantIducMultiDropDown;
        private Janus.Windows.GridEX.EditControls.EditBox emailAddressEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox faxNumberMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox cellPhoneMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox telephoneExtensionEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox telephoneNumberMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox positionTitleFreEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox positionTitleEditBox;
        private UserControls.ucMultiDropDown positionCodeucMultiDropDown;
        private Janus.Windows.EditControls.UICheckBox currentEmployeeUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox notesEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox suffixEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox lastNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox middleNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox firstNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox salutationEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox officerCodeEditBox;
        private Janus.Windows.EditControls.UIButton btnAddNewEmailAddress;
        private Janus.Windows.EditControls.UIButton btnAddNewOfficerRole;
        private Janus.Windows.EditControls.UIButton btnAddNewDelegate;
        private Janus.Windows.EditControls.UICheckBox usesBillingCheckBox;
        private Janus.Windows.UI.Tab.UITabPage tribunalTabPage;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBoxLanguage;
        private Janus.Windows.EditControls.UICheckBox langEnglishCheckBox;
        private Janus.Windows.EditControls.UICheckBox langFrenchCheckBox;
        private Janus.Windows.EditControls.UIGroupBox gbParticipant;
        private Janus.Windows.EditControls.UICheckBox eiCheckBox;
        private Janus.Windows.EditControls.UICheckBox isCheckBox;
        private Janus.Windows.EditControls.UIGroupBox trainingGroupBox;
        private Janus.Windows.EditControls.UICheckBox TrainedCharterCheckBox;
        private Janus.Windows.EditControls.UICheckBox trainedEICheckBox;
        private Janus.Windows.EditControls.UICheckBox trainedOASCheckBox;
        private Janus.Windows.EditControls.UICheckBox trainedCPPCheckBox;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox7;
        private Janus.Windows.CalendarCombo.CalendarCombo calStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private Janus.Windows.CalendarCombo.CalendarCombo calExpiryDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private Janus.Windows.EditControls.UIGroupBox addressGroupBox;
        private UserControls.ucAddress ucAddress;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox phoneNumberEditBox;
        private System.Windows.Forms.BindingSource memberProfileBindingSource;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private UserControls.ucMultiDropDown appealLevelDropDown;
        private Janus.Windows.EditControls.UIButton addAddressBtn;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox confIDeditBox;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.UI.CommandBars.UICommand tsCopyPrefs2;
        private Janus.Windows.UI.CommandBars.UICommand tsCopyPrefs;
        private Janus.Windows.UI.CommandBars.UICommand tsCopyPrefs1;
        private Janus.Windows.CalendarCombo.CalendarCombo endTimeCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo startTimeCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo endDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo startDateCalendarCombo;
        private System.Windows.Forms.CheckBox chkOutOfOffice;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage5;
        private System.Windows.Forms.Label cellPhoneLabel1;
    }
}
