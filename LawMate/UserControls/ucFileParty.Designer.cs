namespace LawMate
{
    partial class ucFileParty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFileParty));
            System.Windows.Forms.Label hearingMethodRequestedLabel;
            System.Windows.Forms.Label notifiedOfAppealDateLabel;
            System.Windows.Forms.Label advisedOfHearingDateLabel;
            System.Windows.Forms.Label sentNoticeOfHearingDateLabel;
            System.Windows.Forms.Label certifiedReadyDateLabel;
            System.Windows.Forms.Label notifiedOfDecisionDateLabel;
            System.Windows.Forms.Label partyIdLabel;
            System.Windows.Forms.Label contactTypeCodeLabel;
            System.Windows.Forms.Label sINLabel;
            System.Windows.Forms.Label salutationLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label middleNameLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label suffixLabel;
            System.Windows.Forms.Label telephoneNumberLabel;
            System.Windows.Forms.Label cellPhoneLabel;
            System.Windows.Forms.Label telephoneExtensionLabel;
            System.Windows.Forms.Label faxNumberLabel;
            System.Windows.Forms.Label emailAddressLabel;
            System.Windows.Forms.Label sexCodeLabel;
            System.Windows.Forms.Label birthDateLabel;
            System.Windows.Forms.Label languageCodeLabel;
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label companyLabel;
            Janus.Windows.GridEX.GridEXLayout filePartyGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference filePartyGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference filePartyGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.gbAddress = new Janus.Windows.EditControls.UIGroupBox();
            this.ucAddress1 = new LawMate.UserControls.ucAddress();
            this.gbPerson = new Janus.Windows.EditControls.UIGroupBox();
            this.editBox4 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.partyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.editBox5 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox2 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.telephoneExtensionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox3 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.companyEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sINMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.salutationEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lastNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.middleNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.firstNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.suffixEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.telephoneNumberMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.cellPhoneMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.faxNumberMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.emailAddressEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sexCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.birthDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.languageCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.notesEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.gbLP = new Janus.Windows.EditControls.UIGroupBox();
            this.isPendingUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.filePartyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactFileContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.isAppellantUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.mccHearingMethod = new LawMate.UserControls.ucMultiDropDown();
            this.notifiedOfAppealDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.advisedOfHearingDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sentNoticeOfHearingDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.certifiedReadyDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.notifiedOfDecisionDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.contactTypeCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.filePartyGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditMode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.cmdTitle1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSave2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel2 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdDelete2 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdEditParty1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEditParty");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdTitle = new Janus.Windows.UI.CommandBars.UICommand("cmdTitle");
            this.tsEditMode = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdEditParty = new Janus.Windows.UI.CommandBars.UICommand("cmdEditParty");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            hearingMethodRequestedLabel = new System.Windows.Forms.Label();
            notifiedOfAppealDateLabel = new System.Windows.Forms.Label();
            advisedOfHearingDateLabel = new System.Windows.Forms.Label();
            sentNoticeOfHearingDateLabel = new System.Windows.Forms.Label();
            certifiedReadyDateLabel = new System.Windows.Forms.Label();
            notifiedOfDecisionDateLabel = new System.Windows.Forms.Label();
            partyIdLabel = new System.Windows.Forms.Label();
            contactTypeCodeLabel = new System.Windows.Forms.Label();
            sINLabel = new System.Windows.Forms.Label();
            salutationLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            suffixLabel = new System.Windows.Forms.Label();
            telephoneNumberLabel = new System.Windows.Forms.Label();
            cellPhoneLabel = new System.Windows.Forms.Label();
            telephoneExtensionLabel = new System.Windows.Forms.Label();
            faxNumberLabel = new System.Windows.Forms.Label();
            emailAddressLabel = new System.Windows.Forms.Label();
            sexCodeLabel = new System.Windows.Forms.Label();
            birthDateLabel = new System.Windows.Forms.Label();
            languageCodeLabel = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            companyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbAddress)).BeginInit();
            this.gbAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbPerson)).BeginInit();
            this.gbPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbLP)).BeginInit();
            this.gbLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePartyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactFileContactBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePartyGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.filePartyBindingSource;
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
            // 
            // hearingMethodRequestedLabel
            // 
            hearingMethodRequestedLabel.AutoSize = true;
            hearingMethodRequestedLabel.Location = new System.Drawing.Point(7, 76);
            hearingMethodRequestedLabel.Name = "hearingMethodRequestedLabel";
            hearingMethodRequestedLabel.Size = new System.Drawing.Size(142, 13);
            hearingMethodRequestedLabel.TabIndex = 5;
            hearingMethodRequestedLabel.Text = "Hearing Method Requested:";
            // 
            // notifiedOfAppealDateLabel
            // 
            notifiedOfAppealDateLabel.AutoSize = true;
            notifiedOfAppealDateLabel.Location = new System.Drawing.Point(471, 75);
            notifiedOfAppealDateLabel.Name = "notifiedOfAppealDateLabel";
            notifiedOfAppealDateLabel.Size = new System.Drawing.Size(123, 13);
            notifiedOfAppealDateLabel.TabIndex = 11;
            notifiedOfAppealDateLabel.Text = "Date Notified of Appeal:";
            // 
            // advisedOfHearingDateLabel
            // 
            advisedOfHearingDateLabel.AutoSize = true;
            advisedOfHearingDateLabel.Location = new System.Drawing.Point(7, 104);
            advisedOfHearingDateLabel.Name = "advisedOfHearingDateLabel";
            advisedOfHearingDateLabel.Size = new System.Drawing.Size(128, 13);
            advisedOfHearingDateLabel.TabIndex = 7;
            advisedOfHearingDateLabel.Text = "Advised of Hearing Date:";
            // 
            // sentNoticeOfHearingDateLabel
            // 
            sentNoticeOfHearingDateLabel.AutoSize = true;
            sentNoticeOfHearingDateLabel.Location = new System.Drawing.Point(7, 131);
            sentNoticeOfHearingDateLabel.Name = "sentNoticeOfHearingDateLabel";
            sentNoticeOfHearingDateLabel.Size = new System.Drawing.Size(145, 13);
            sentNoticeOfHearingDateLabel.TabIndex = 9;
            sentNoticeOfHearingDateLabel.Text = "Sent Notice of Hearing Date:";
            // 
            // certifiedReadyDateLabel
            // 
            certifiedReadyDateLabel.AutoSize = true;
            certifiedReadyDateLabel.Location = new System.Drawing.Point(471, 104);
            certifiedReadyDateLabel.Name = "certifiedReadyDateLabel";
            certifiedReadyDateLabel.Size = new System.Drawing.Size(112, 13);
            certifiedReadyDateLabel.TabIndex = 13;
            certifiedReadyDateLabel.Text = "Certified Ready Date:";
            // 
            // notifiedOfDecisionDateLabel
            // 
            notifiedOfDecisionDateLabel.AutoSize = true;
            notifiedOfDecisionDateLabel.Location = new System.Drawing.Point(471, 132);
            notifiedOfDecisionDateLabel.Name = "notifiedOfDecisionDateLabel";
            notifiedOfDecisionDateLabel.Size = new System.Drawing.Size(129, 13);
            notifiedOfDecisionDateLabel.TabIndex = 15;
            notifiedOfDecisionDateLabel.Text = "Notified of Decision Date:";
            // 
            // partyIdLabel
            // 
            partyIdLabel.AutoSize = true;
            partyIdLabel.Location = new System.Drawing.Point(7, 22);
            partyIdLabel.Name = "partyIdLabel";
            partyIdLabel.Size = new System.Drawing.Size(38, 13);
            partyIdLabel.TabIndex = 0;
            partyIdLabel.Text = "Name:";
            // 
            // contactTypeCodeLabel
            // 
            contactTypeCodeLabel.AutoSize = true;
            contactTypeCodeLabel.Location = new System.Drawing.Point(7, 49);
            contactTypeCodeLabel.Name = "contactTypeCodeLabel";
            contactTypeCodeLabel.Size = new System.Drawing.Size(102, 13);
            contactTypeCodeLabel.TabIndex = 3;
            contactTypeCodeLabel.Text = "Type of Participant:";
            // 
            // sINLabel
            // 
            sINLabel.AutoSize = true;
            sINLabel.Location = new System.Drawing.Point(7, 159);
            sINLabel.Name = "sINLabel";
            sINLabel.Size = new System.Drawing.Size(28, 13);
            sINLabel.TabIndex = 10;
            sINLabel.Text = "SIN:";
            // 
            // salutationLabel
            // 
            salutationLabel.AutoSize = true;
            salutationLabel.Location = new System.Drawing.Point(7, 24);
            salutationLabel.Name = "salutationLabel";
            salutationLabel.Size = new System.Drawing.Size(59, 13);
            salutationLabel.TabIndex = 0;
            salutationLabel.Text = "Salutation:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(7, 105);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 6;
            lastNameLabel.Text = "Last Name:";
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new System.Drawing.Point(7, 78);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new System.Drawing.Size(71, 13);
            middleNameLabel.TabIndex = 4;
            middleNameLabel.Text = "Middle Name:";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(7, 51);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(62, 13);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // suffixLabel
            // 
            suffixLabel.AutoSize = true;
            suffixLabel.Location = new System.Drawing.Point(7, 132);
            suffixLabel.Name = "suffixLabel";
            suffixLabel.Size = new System.Drawing.Size(39, 13);
            suffixLabel.TabIndex = 8;
            suffixLabel.Text = "Suffix:";
            // 
            // telephoneNumberLabel
            // 
            telephoneNumberLabel.AutoSize = true;
            telephoneNumberLabel.Location = new System.Drawing.Point(376, 51);
            telephoneNumberLabel.Name = "telephoneNumberLabel";
            telephoneNumberLabel.Size = new System.Drawing.Size(61, 13);
            telephoneNumberLabel.TabIndex = 24;
            telephoneNumberLabel.Text = "Telephone:";
            // 
            // cellPhoneLabel
            // 
            cellPhoneLabel.AutoSize = true;
            cellPhoneLabel.Location = new System.Drawing.Point(376, 78);
            cellPhoneLabel.Name = "cellPhoneLabel";
            cellPhoneLabel.Size = new System.Drawing.Size(46, 13);
            cellPhoneLabel.TabIndex = 28;
            cellPhoneLabel.Text = "Cellular:";
            // 
            // telephoneExtensionLabel
            // 
            telephoneExtensionLabel.AutoSize = true;
            telephoneExtensionLabel.Location = new System.Drawing.Point(606, 51);
            telephoneExtensionLabel.Name = "telephoneExtensionLabel";
            telephoneExtensionLabel.Size = new System.Drawing.Size(31, 13);
            telephoneExtensionLabel.TabIndex = 26;
            telephoneExtensionLabel.Text = "Ext.:";
            // 
            // faxNumberLabel
            // 
            faxNumberLabel.AutoSize = true;
            faxNumberLabel.Location = new System.Drawing.Point(376, 105);
            faxNumberLabel.Name = "faxNumberLabel";
            faxNumberLabel.Size = new System.Drawing.Size(53, 13);
            faxNumberLabel.TabIndex = 30;
            faxNumberLabel.Text = "Facsimile:";
            // 
            // emailAddressLabel
            // 
            emailAddressLabel.AutoSize = true;
            emailAddressLabel.Location = new System.Drawing.Point(376, 240);
            emailAddressLabel.Name = "emailAddressLabel";
            emailAddressLabel.Size = new System.Drawing.Size(39, 13);
            emailAddressLabel.TabIndex = 16;
            emailAddressLabel.Text = "E-mail:";
            // 
            // sexCodeLabel
            // 
            sexCodeLabel.AutoSize = true;
            sexCodeLabel.Location = new System.Drawing.Point(7, 239);
            sexCodeLabel.Name = "sexCodeLabel";
            sexCodeLabel.Size = new System.Drawing.Size(46, 13);
            sexCodeLabel.TabIndex = 20;
            sexCodeLabel.Text = "Gender:";
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Location = new System.Drawing.Point(376, 24);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new System.Drawing.Size(59, 13);
            birthDateLabel.TabIndex = 22;
            birthDateLabel.Text = "Birth Date:";
            // 
            // languageCodeLabel
            // 
            languageCodeLabel.AutoSize = true;
            languageCodeLabel.Location = new System.Drawing.Point(7, 212);
            languageCodeLabel.Name = "languageCodeLabel";
            languageCodeLabel.Size = new System.Drawing.Size(58, 13);
            languageCodeLabel.TabIndex = 18;
            languageCodeLabel.Text = "Language:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(7, 266);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(39, 13);
            notesLabel.TabIndex = 14;
            notesLabel.Text = "Notes:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(376, 132);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 13);
            label1.TabIndex = 0;
            label1.Text = "Business Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(376, 159);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 13);
            label2.TabIndex = 2;
            label2.Text = "Legal Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(376, 186);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 13);
            label3.TabIndex = 4;
            label3.Text = "Operating As:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(376, 213);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 13);
            label4.TabIndex = 6;
            label4.Text = "Attention:";
            // 
            // companyLabel
            // 
            companyLabel.AutoSize = true;
            companyLabel.Location = new System.Drawing.Point(7, 186);
            companyLabel.Name = "companyLabel";
            companyLabel.Size = new System.Drawing.Size(56, 13);
            companyLabel.TabIndex = 12;
            companyLabel.Text = "Company:";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = false;
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = 0;
            this.uiPanelManager1.PanelPadding.Left = 0;
            this.uiPanelManager1.PanelPadding.Right = 0;
            this.uiPanelManager1.PanelPadding.Top = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(778, 780), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Location = new System.Drawing.Point(0, 50);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(778, 780);
            this.pnlAll.TabIndex = 4;
            this.pnlAll.Text = "File Parties";
            // 
            // pnlAllContainer
            // 
            this.pnlAllContainer.AutoScroll = true;
            this.pnlAllContainer.AutoScrollMargin = new System.Drawing.Size(0, 8);
            this.pnlAllContainer.Controls.Add(this.gbAddress);
            this.pnlAllContainer.Controls.Add(this.gbPerson);
            this.pnlAllContainer.Controls.Add(this.gbLP);
            this.pnlAllContainer.Controls.Add(this.filePartyGridEX);
            this.pnlAllContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.pnlAllContainer.Size = new System.Drawing.Size(778, 780);
            this.pnlAllContainer.TabIndex = 0;
            // 
            // gbAddress
            // 
            this.gbAddress.BackColor = System.Drawing.Color.Transparent;
            this.gbAddress.Controls.Add(this.ucAddress1);
            this.gbAddress.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbAddress.Location = new System.Drawing.Point(12, 604);
            this.gbAddress.Name = "gbAddress";
            this.gbAddress.Size = new System.Drawing.Size(709, 160);
            this.gbAddress.TabIndex = 4;
            this.gbAddress.Text = "Participant Address";
            this.gbAddress.UseThemes = false;
            // 
            // ucAddress1
            // 
            this.ucAddress1.AutoSize = true;
            this.ucAddress1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucAddress1.BackColor = System.Drawing.Color.Transparent;
            this.ucAddress1.ColumnTwoLeftPositionOffset = 63;
            this.ucAddress1.FM = null;
            this.ucAddress1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucAddress1.IsReadOnly = true;
            this.ucAddress1.Location = new System.Drawing.Point(6, 14);
            this.ucAddress1.Name = "ucAddress1";
            this.ucAddress1.ReqColor = System.Drawing.SystemColors.Control;
            this.ucAddress1.Size = new System.Drawing.Size(422, 139);
            this.ucAddress1.TabIndex = 0;
            // 
            // gbPerson
            // 
            this.gbPerson.BackColor = System.Drawing.Color.Transparent;
            this.gbPerson.Controls.Add(label3);
            this.gbPerson.Controls.Add(label1);
            this.gbPerson.Controls.Add(this.editBox4);
            this.gbPerson.Controls.Add(label4);
            this.gbPerson.Controls.Add(companyLabel);
            this.gbPerson.Controls.Add(this.editBox5);
            this.gbPerson.Controls.Add(this.editBox2);
            this.gbPerson.Controls.Add(label2);
            this.gbPerson.Controls.Add(this.telephoneExtensionEditBox);
            this.gbPerson.Controls.Add(this.editBox3);
            this.gbPerson.Controls.Add(this.companyEditBox);
            this.gbPerson.Controls.Add(sINLabel);
            this.gbPerson.Controls.Add(this.sINMaskedEditBox);
            this.gbPerson.Controls.Add(salutationLabel);
            this.gbPerson.Controls.Add(this.salutationEditBox);
            this.gbPerson.Controls.Add(lastNameLabel);
            this.gbPerson.Controls.Add(this.lastNameEditBox);
            this.gbPerson.Controls.Add(middleNameLabel);
            this.gbPerson.Controls.Add(this.middleNameEditBox);
            this.gbPerson.Controls.Add(firstNameLabel);
            this.gbPerson.Controls.Add(this.firstNameEditBox);
            this.gbPerson.Controls.Add(suffixLabel);
            this.gbPerson.Controls.Add(this.suffixEditBox);
            this.gbPerson.Controls.Add(telephoneNumberLabel);
            this.gbPerson.Controls.Add(this.telephoneNumberMaskedEditBox);
            this.gbPerson.Controls.Add(cellPhoneLabel);
            this.gbPerson.Controls.Add(this.cellPhoneMaskedEditBox);
            this.gbPerson.Controls.Add(telephoneExtensionLabel);
            this.gbPerson.Controls.Add(faxNumberLabel);
            this.gbPerson.Controls.Add(this.faxNumberMaskedEditBox);
            this.gbPerson.Controls.Add(emailAddressLabel);
            this.gbPerson.Controls.Add(this.emailAddressEditBox);
            this.gbPerson.Controls.Add(sexCodeLabel);
            this.gbPerson.Controls.Add(this.sexCodeucMultiDropDown);
            this.gbPerson.Controls.Add(birthDateLabel);
            this.gbPerson.Controls.Add(this.birthDateCalendarCombo);
            this.gbPerson.Controls.Add(languageCodeLabel);
            this.gbPerson.Controls.Add(this.languageCodeucMultiDropDown);
            this.gbPerson.Controls.Add(notesLabel);
            this.gbPerson.Controls.Add(this.notesEditBox);
            this.gbPerson.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gbPerson.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbPerson.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbPerson.Location = new System.Drawing.Point(12, 287);
            this.gbPerson.Name = "gbPerson";
            this.helpProvider1.SetShowHelp(this.gbPerson, true);
            this.gbPerson.Size = new System.Drawing.Size(709, 311);
            this.gbPerson.TabIndex = 2;
            this.gbPerson.Text = "Participant Information";
            this.gbPerson.UseThemes = false;
            this.gbPerson.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // editBox4
            // 
            this.editBox4.BackColor = System.Drawing.SystemColors.Control;
            this.editBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "OperatingAs", true));
            this.editBox4.Location = new System.Drawing.Point(474, 181);
            this.editBox4.Name = "editBox4";
            this.editBox4.ReadOnly = true;
            this.editBox4.Size = new System.Drawing.Size(205, 21);
            this.editBox4.TabIndex = 5;
            this.editBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // partyBindingSource
            // 
            this.partyBindingSource.DataMember = "Contact";
            this.partyBindingSource.DataSource = typeof(lmDatasets.atriumDB);
            // 
            // editBox5
            // 
            this.editBox5.BackColor = System.Drawing.SystemColors.Control;
            this.editBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "Attention", true));
            this.editBox5.Location = new System.Drawing.Point(474, 208);
            this.editBox5.Name = "editBox5";
            this.editBox5.ReadOnly = true;
            this.editBox5.Size = new System.Drawing.Size(205, 21);
            this.editBox5.TabIndex = 7;
            this.editBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox2
            // 
            this.editBox2.BackColor = System.Drawing.SystemColors.Control;
            this.editBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "BusinessNumber", true));
            this.editBox2.Location = new System.Drawing.Point(474, 127);
            this.editBox2.Name = "editBox2";
            this.editBox2.ReadOnly = true;
            this.editBox2.Size = new System.Drawing.Size(205, 21);
            this.editBox2.TabIndex = 1;
            this.editBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // telephoneExtensionEditBox
            // 
            this.telephoneExtensionEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.telephoneExtensionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "TelephoneExtension", true));
            this.telephoneExtensionEditBox.Location = new System.Drawing.Point(636, 46);
            this.telephoneExtensionEditBox.Name = "telephoneExtensionEditBox";
            this.telephoneExtensionEditBox.ReadOnly = true;
            this.telephoneExtensionEditBox.Size = new System.Drawing.Size(43, 21);
            this.telephoneExtensionEditBox.TabIndex = 27;
            this.telephoneExtensionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox3
            // 
            this.editBox3.BackColor = System.Drawing.SystemColors.Control;
            this.editBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "LegalName", true));
            this.editBox3.Location = new System.Drawing.Point(474, 154);
            this.editBox3.Name = "editBox3";
            this.editBox3.ReadOnly = true;
            this.editBox3.Size = new System.Drawing.Size(205, 21);
            this.editBox3.TabIndex = 3;
            this.editBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // companyEditBox
            // 
            this.companyEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.companyEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "Company", true));
            this.companyEditBox.Location = new System.Drawing.Point(160, 181);
            this.companyEditBox.Name = "companyEditBox";
            this.companyEditBox.ReadOnly = true;
            this.companyEditBox.Size = new System.Drawing.Size(195, 21);
            this.companyEditBox.TabIndex = 13;
            this.companyEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sINMaskedEditBox
            // 
            this.sINMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sINMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "SIN", true));
            this.sINMaskedEditBox.Location = new System.Drawing.Point(160, 154);
            this.sINMaskedEditBox.Mask = "000 000 000";
            this.sINMaskedEditBox.Name = "sINMaskedEditBox";
            this.sINMaskedEditBox.ReadOnly = true;
            this.sINMaskedEditBox.Size = new System.Drawing.Size(108, 21);
            this.sINMaskedEditBox.TabIndex = 11;
            this.sINMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // salutationEditBox
            // 
            this.salutationEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.salutationEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "Salutation", true));
            this.salutationEditBox.Location = new System.Drawing.Point(160, 19);
            this.salutationEditBox.Name = "salutationEditBox";
            this.salutationEditBox.ReadOnly = true;
            this.salutationEditBox.Size = new System.Drawing.Size(108, 21);
            this.salutationEditBox.TabIndex = 1;
            this.salutationEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lastNameEditBox
            // 
            this.lastNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.lastNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "LastName", true));
            this.lastNameEditBox.Location = new System.Drawing.Point(160, 100);
            this.lastNameEditBox.Name = "lastNameEditBox";
            this.lastNameEditBox.ReadOnly = true;
            this.lastNameEditBox.Size = new System.Drawing.Size(195, 21);
            this.lastNameEditBox.TabIndex = 7;
            this.lastNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // middleNameEditBox
            // 
            this.middleNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.middleNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "MiddleName", true));
            this.middleNameEditBox.Location = new System.Drawing.Point(160, 73);
            this.middleNameEditBox.Name = "middleNameEditBox";
            this.middleNameEditBox.ReadOnly = true;
            this.middleNameEditBox.Size = new System.Drawing.Size(195, 21);
            this.middleNameEditBox.TabIndex = 5;
            this.middleNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // firstNameEditBox
            // 
            this.firstNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.firstNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "FirstName", true));
            this.firstNameEditBox.Location = new System.Drawing.Point(160, 46);
            this.firstNameEditBox.Name = "firstNameEditBox";
            this.firstNameEditBox.ReadOnly = true;
            this.firstNameEditBox.Size = new System.Drawing.Size(195, 21);
            this.firstNameEditBox.TabIndex = 3;
            this.firstNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // suffixEditBox
            // 
            this.suffixEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.suffixEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "Suffix", true));
            this.suffixEditBox.Location = new System.Drawing.Point(160, 127);
            this.suffixEditBox.Name = "suffixEditBox";
            this.suffixEditBox.ReadOnly = true;
            this.suffixEditBox.Size = new System.Drawing.Size(108, 21);
            this.suffixEditBox.TabIndex = 9;
            this.suffixEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // telephoneNumberMaskedEditBox
            // 
            this.telephoneNumberMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.telephoneNumberMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "TelephoneNumber", true));
            this.telephoneNumberMaskedEditBox.Location = new System.Drawing.Point(474, 46);
            this.telephoneNumberMaskedEditBox.Mask = "!(###) 000-0000";
            this.telephoneNumberMaskedEditBox.Name = "telephoneNumberMaskedEditBox";
            this.telephoneNumberMaskedEditBox.ReadOnly = true;
            this.telephoneNumberMaskedEditBox.Size = new System.Drawing.Size(126, 21);
            this.telephoneNumberMaskedEditBox.TabIndex = 25;
            this.telephoneNumberMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // cellPhoneMaskedEditBox
            // 
            this.cellPhoneMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.cellPhoneMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "CellPhone", true));
            this.cellPhoneMaskedEditBox.Location = new System.Drawing.Point(474, 73);
            this.cellPhoneMaskedEditBox.Mask = "!(###) 000-0000";
            this.cellPhoneMaskedEditBox.Name = "cellPhoneMaskedEditBox";
            this.cellPhoneMaskedEditBox.ReadOnly = true;
            this.cellPhoneMaskedEditBox.Size = new System.Drawing.Size(126, 21);
            this.cellPhoneMaskedEditBox.TabIndex = 29;
            this.cellPhoneMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // faxNumberMaskedEditBox
            // 
            this.faxNumberMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.faxNumberMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "FaxNumber", true));
            this.faxNumberMaskedEditBox.Location = new System.Drawing.Point(474, 100);
            this.faxNumberMaskedEditBox.Mask = "!(###) 000-0000";
            this.faxNumberMaskedEditBox.Name = "faxNumberMaskedEditBox";
            this.faxNumberMaskedEditBox.ReadOnly = true;
            this.faxNumberMaskedEditBox.Size = new System.Drawing.Size(126, 21);
            this.faxNumberMaskedEditBox.TabIndex = 31;
            this.faxNumberMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // emailAddressEditBox
            // 
            this.emailAddressEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.emailAddressEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "EmailAddress", true));
            this.emailAddressEditBox.Location = new System.Drawing.Point(474, 235);
            this.emailAddressEditBox.Name = "emailAddressEditBox";
            this.emailAddressEditBox.ReadOnly = true;
            this.emailAddressEditBox.Size = new System.Drawing.Size(205, 21);
            this.emailAddressEditBox.TabIndex = 17;
            this.emailAddressEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sexCodeucMultiDropDown
            // 
            this.sexCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.sexCodeucMultiDropDown.Column1 = "SexCode";
            this.sexCodeucMultiDropDown.Column2 = "SexDescEng";
            this.sexCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.sexCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.partyBindingSource, "SexCode", true));
            this.sexCodeucMultiDropDown.DataSource = null;
            this.sexCodeucMultiDropDown.DDColumn1Visible = true;
            this.sexCodeucMultiDropDown.DisplayMember = "SexDescEng";
            this.sexCodeucMultiDropDown.DisplayNameColumn1 = "Code";
            this.sexCodeucMultiDropDown.DisplayNameColumn2 = "Description";
            this.sexCodeucMultiDropDown.DropDownColumn1Width = 50;
            this.sexCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.sexCodeucMultiDropDown.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.sexCodeucMultiDropDown.Location = new System.Drawing.Point(160, 235);
            this.sexCodeucMultiDropDown.Middle = 198;
            this.sexCodeucMultiDropDown.Name = "sexCodeucMultiDropDown";
            this.sexCodeucMultiDropDown.ReadOnly = true;
            this.sexCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Control;
            this.sexCodeucMultiDropDown.SelectedValue = null;
            this.sexCodeucMultiDropDown.Size = new System.Drawing.Size(195, 21);
            this.sexCodeucMultiDropDown.TabIndex = 21;
            this.sexCodeucMultiDropDown.ValueMember = "SexDescEng";
            // 
            // birthDateCalendarCombo
            // 
            this.birthDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.birthDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.birthDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.partyBindingSource, "BirthDate", true));
            this.birthDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.birthDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.birthDateCalendarCombo.Location = new System.Drawing.Point(474, 19);
            this.birthDateCalendarCombo.Name = "birthDateCalendarCombo";
            this.birthDateCalendarCombo.ReadOnly = true;
            this.birthDateCalendarCombo.Size = new System.Drawing.Size(92, 21);
            this.birthDateCalendarCombo.TabIndex = 23;
            this.birthDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // languageCodeucMultiDropDown
            // 
            this.languageCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.languageCodeucMultiDropDown.Column1 = "LanguageCode";
            this.languageCodeucMultiDropDown.Column2 = "LanguageDescEng";
            this.languageCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.languageCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.partyBindingSource, "LanguageCode", true));
            this.languageCodeucMultiDropDown.DataSource = null;
            this.languageCodeucMultiDropDown.DDColumn1Visible = true;
            this.languageCodeucMultiDropDown.DisplayMember = "LanguageDescEng";
            this.languageCodeucMultiDropDown.DisplayNameColumn1 = "Code";
            this.languageCodeucMultiDropDown.DisplayNameColumn2 = "Description";
            this.languageCodeucMultiDropDown.DropDownColumn1Width = 50;
            this.languageCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.languageCodeucMultiDropDown.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.languageCodeucMultiDropDown.Location = new System.Drawing.Point(160, 208);
            this.languageCodeucMultiDropDown.Middle = 198;
            this.languageCodeucMultiDropDown.Name = "languageCodeucMultiDropDown";
            this.languageCodeucMultiDropDown.ReadOnly = true;
            this.languageCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Control;
            this.languageCodeucMultiDropDown.SelectedValue = null;
            this.languageCodeucMultiDropDown.Size = new System.Drawing.Size(195, 21);
            this.languageCodeucMultiDropDown.TabIndex = 19;
            this.languageCodeucMultiDropDown.ValueMember = "LanguageCode";
            // 
            // notesEditBox
            // 
            this.notesEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.notesEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.partyBindingSource, "Notes", true));
            this.notesEditBox.Location = new System.Drawing.Point(160, 262);
            this.notesEditBox.Multiline = true;
            this.notesEditBox.Name = "notesEditBox";
            this.notesEditBox.ReadOnly = true;
            this.notesEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.notesEditBox.Size = new System.Drawing.Size(519, 40);
            this.notesEditBox.TabIndex = 15;
            this.notesEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gbLP
            // 
            this.gbLP.BackColor = System.Drawing.Color.Transparent;
            this.gbLP.Controls.Add(this.isPendingUICheckBox);
            this.gbLP.Controls.Add(this.isAppellantUICheckBox);
            this.gbLP.Controls.Add(this.mccHearingMethod);
            this.gbLP.Controls.Add(hearingMethodRequestedLabel);
            this.gbLP.Controls.Add(notifiedOfAppealDateLabel);
            this.gbLP.Controls.Add(this.notifiedOfAppealDateCalendarCombo);
            this.gbLP.Controls.Add(advisedOfHearingDateLabel);
            this.gbLP.Controls.Add(this.advisedOfHearingDateCalendarCombo);
            this.gbLP.Controls.Add(sentNoticeOfHearingDateLabel);
            this.gbLP.Controls.Add(this.sentNoticeOfHearingDateCalendarCombo);
            this.gbLP.Controls.Add(certifiedReadyDateLabel);
            this.gbLP.Controls.Add(this.certifiedReadyDateCalendarCombo);
            this.gbLP.Controls.Add(notifiedOfDecisionDateLabel);
            this.gbLP.Controls.Add(this.notifiedOfDecisionDateCalendarCombo);
            this.gbLP.Controls.Add(partyIdLabel);
            this.gbLP.Controls.Add(contactTypeCodeLabel);
            this.gbLP.Controls.Add(this.contactTypeCodeucMultiDropDown);
            this.gbLP.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gbLP.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbLP.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbLP.Location = new System.Drawing.Point(12, 127);
            this.gbLP.Name = "gbLP";
            this.helpProvider1.SetShowHelp(this.gbLP, true);
            this.gbLP.Size = new System.Drawing.Size(709, 154);
            this.gbLP.TabIndex = 1;
            this.gbLP.Text = "Participant";
            this.gbLP.UseThemes = false;
            this.gbLP.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // isPendingUICheckBox
            // 
            this.isPendingUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isPendingUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "IsPending", true));
            this.isPendingUICheckBox.Image = global::LawMate.Properties.Resources.hourglassPending;
            this.isPendingUICheckBox.Location = new System.Drawing.Point(604, 16);
            this.isPendingUICheckBox.Name = "isPendingUICheckBox";
            this.isPendingUICheckBox.Size = new System.Drawing.Size(95, 23);
            this.isPendingUICheckBox.TabIndex = 18;
            this.isPendingUICheckBox.Text = " Is Pending:";
            this.isPendingUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // filePartyBindingSource
            // 
            this.filePartyBindingSource.DataSource = this.contactFileContactBindingSource;
            this.filePartyBindingSource.CurrentChanged += new System.EventHandler(this.filePartyBindingSource_CurrentChanged);
            // 
            // contactFileContactBindingSource
            // 
            this.contactFileContactBindingSource.DataMember = "Contact_FileContact";
            this.contactFileContactBindingSource.DataSource = this.partyBindingSource;
            // 
            // isAppellantUICheckBox
            // 
            this.isAppellantUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isAppellantUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "IsAppellant", true));
            this.isAppellantUICheckBox.Image = global::LawMate.Properties.Resources.appellant;
            this.isAppellantUICheckBox.Location = new System.Drawing.Point(459, 16);
            this.isAppellantUICheckBox.Name = "isAppellantUICheckBox";
            this.isAppellantUICheckBox.Size = new System.Drawing.Size(101, 23);
            this.isAppellantUICheckBox.TabIndex = 2;
            this.isAppellantUICheckBox.Text = " Is Appellant:";
            this.isAppellantUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // mccHearingMethod
            // 
            this.mccHearingMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mccHearingMethod.Column1 = "HearingMethodId";
            this.mccHearingMethod.Column2 = "HearingMethodEng";
            this.mccHearingMethod.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.mccHearingMethod.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.filePartyBindingSource, "HearingMethodRequested", true));
            this.mccHearingMethod.DataSource = null;
            this.mccHearingMethod.DDColumn1Visible = true;
            this.mccHearingMethod.DisplayMember = "HearingMethodEng";
            this.mccHearingMethod.DisplayNameColumn1 = "Code";
            this.mccHearingMethod.DisplayNameColumn2 = "Description";
            this.mccHearingMethod.DropDownColumn1Width = 60;
            this.mccHearingMethod.DropDownColumn2Width = 240;
            this.mccHearingMethod.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mccHearingMethod.Location = new System.Drawing.Point(160, 72);
            this.mccHearingMethod.Middle = 296;
            this.mccHearingMethod.Name = "mccHearingMethod";
            this.mccHearingMethod.ReadOnly = false;
            this.mccHearingMethod.ReqColor = System.Drawing.SystemColors.Window;
            this.mccHearingMethod.SelectedValue = null;
            this.mccHearingMethod.Size = new System.Drawing.Size(293, 21);
            this.mccHearingMethod.TabIndex = 6;
            this.mccHearingMethod.ValueMember = "HearingMethodId";
            // 
            // notifiedOfAppealDateCalendarCombo
            // 
            this.notifiedOfAppealDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.notifiedOfAppealDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "NotifiedOfAppealDate", true));
            this.notifiedOfAppealDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.notifiedOfAppealDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.notifiedOfAppealDateCalendarCombo.Location = new System.Drawing.Point(610, 70);
            this.notifiedOfAppealDateCalendarCombo.Name = "notifiedOfAppealDateCalendarCombo";
            this.notifiedOfAppealDateCalendarCombo.Size = new System.Drawing.Size(89, 21);
            this.notifiedOfAppealDateCalendarCombo.TabIndex = 12;
            this.notifiedOfAppealDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // advisedOfHearingDateCalendarCombo
            // 
            this.advisedOfHearingDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.advisedOfHearingDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "AdvisedOfHearingDate", true));
            this.advisedOfHearingDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.advisedOfHearingDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.advisedOfHearingDateCalendarCombo.Location = new System.Drawing.Point(160, 99);
            this.advisedOfHearingDateCalendarCombo.Name = "advisedOfHearingDateCalendarCombo";
            this.advisedOfHearingDateCalendarCombo.Size = new System.Drawing.Size(89, 21);
            this.advisedOfHearingDateCalendarCombo.TabIndex = 8;
            this.advisedOfHearingDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // sentNoticeOfHearingDateCalendarCombo
            // 
            this.sentNoticeOfHearingDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.sentNoticeOfHearingDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "SentNoticeOfHearingDate", true));
            this.sentNoticeOfHearingDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.sentNoticeOfHearingDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentNoticeOfHearingDateCalendarCombo.Location = new System.Drawing.Point(160, 126);
            this.sentNoticeOfHearingDateCalendarCombo.Name = "sentNoticeOfHearingDateCalendarCombo";
            this.sentNoticeOfHearingDateCalendarCombo.Size = new System.Drawing.Size(89, 21);
            this.sentNoticeOfHearingDateCalendarCombo.TabIndex = 10;
            this.sentNoticeOfHearingDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // certifiedReadyDateCalendarCombo
            // 
            this.certifiedReadyDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.certifiedReadyDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "CertifiedReadyDate", true));
            this.certifiedReadyDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.certifiedReadyDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.certifiedReadyDateCalendarCombo.Location = new System.Drawing.Point(610, 99);
            this.certifiedReadyDateCalendarCombo.Name = "certifiedReadyDateCalendarCombo";
            this.certifiedReadyDateCalendarCombo.Size = new System.Drawing.Size(89, 21);
            this.certifiedReadyDateCalendarCombo.TabIndex = 14;
            this.certifiedReadyDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // notifiedOfDecisionDateCalendarCombo
            // 
            this.notifiedOfDecisionDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.notifiedOfDecisionDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "NotifiedOfDecisionDate", true));
            this.notifiedOfDecisionDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.notifiedOfDecisionDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.notifiedOfDecisionDateCalendarCombo.Location = new System.Drawing.Point(610, 127);
            this.notifiedOfDecisionDateCalendarCombo.Name = "notifiedOfDecisionDateCalendarCombo";
            this.notifiedOfDecisionDateCalendarCombo.Size = new System.Drawing.Size(89, 21);
            this.notifiedOfDecisionDateCalendarCombo.TabIndex = 16;
            this.notifiedOfDecisionDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // contactTypeCodeucMultiDropDown
            // 
            this.contactTypeCodeucMultiDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.contactTypeCodeucMultiDropDown.Column1 = "ContactTypeCode";
            this.contactTypeCodeucMultiDropDown.Column2 = "ContactTypeDescEng";
            this.contactTypeCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.contactTypeCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.filePartyBindingSource, "ContactTypeCode", true));
            this.contactTypeCodeucMultiDropDown.DataSource = null;
            this.contactTypeCodeucMultiDropDown.DDColumn1Visible = true;
            this.contactTypeCodeucMultiDropDown.DisplayMember = "ContactTypeDescEng";
            this.contactTypeCodeucMultiDropDown.DisplayNameColumn1 = "Code";
            this.contactTypeCodeucMultiDropDown.DisplayNameColumn2 = "Description";
            this.contactTypeCodeucMultiDropDown.DropDownColumn1Width = 60;
            this.contactTypeCodeucMultiDropDown.DropDownColumn2Width = 240;
            this.contactTypeCodeucMultiDropDown.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.contactTypeCodeucMultiDropDown.Location = new System.Drawing.Point(160, 45);
            this.contactTypeCodeucMultiDropDown.Middle = 296;
            this.contactTypeCodeucMultiDropDown.Name = "contactTypeCodeucMultiDropDown";
            this.contactTypeCodeucMultiDropDown.ReadOnly = false;
            this.contactTypeCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.contactTypeCodeucMultiDropDown.SelectedValue = null;
            this.contactTypeCodeucMultiDropDown.Size = new System.Drawing.Size(293, 21);
            this.contactTypeCodeucMultiDropDown.TabIndex = 4;
            this.contactTypeCodeucMultiDropDown.ValueMember = "ContactTypeCode";
            // 
            // filePartyGridEX
            // 
            this.filePartyGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.filePartyGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.filePartyGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.filePartyGridEX.DataSource = this.filePartyBindingSource;
            filePartyGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("filePartyGridEX_DesignTimeLayout_Reference_0.Instance")));
            filePartyGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("filePartyGridEX_DesignTimeLayout_Reference_1.Instance")));
            filePartyGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            filePartyGridEX_DesignTimeLayout_Reference_0,
            filePartyGridEX_DesignTimeLayout_Reference_1});
            filePartyGridEX_DesignTimeLayout.LayoutString = resources.GetString("filePartyGridEX_DesignTimeLayout.LayoutString");
            this.filePartyGridEX.DesignTimeLayout = filePartyGridEX_DesignTimeLayout;
            this.filePartyGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.filePartyGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.filePartyGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.filePartyGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.filePartyGridEX.GroupByBoxVisible = false;
            this.filePartyGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.filePartyGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.filePartyGridEX.Indent = 20;
            this.filePartyGridEX.Location = new System.Drawing.Point(12, 6);
            this.filePartyGridEX.Name = "filePartyGridEX";
            this.filePartyGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.filePartyGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.filePartyGridEX.Size = new System.Drawing.Size(709, 115);
            this.filePartyGridEX.TabIndex = 0;
            this.filePartyGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.filePartyGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.filePartyGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.filePartyGridEX_LoadingRow);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AlwaysShowFullMenus = true;
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile,
            this.cmdEdit,
            this.cmdView,
            this.cmdSave,
            this.cmdCancel,
            this.cmdDelete,
            this.cmdTitle,
            this.tsEditMode,
            this.tsAudit,
            this.cmdEditParty});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("29725a75-d501-4431-a9e7-f2546ecbc617");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.LockCommandBars = true;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 0);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1,
            this.cmdView1});
            this.uiCommandBar1.Key = "cbMergeMenu";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.Size = new System.Drawing.Size(778, 22);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdFile1
            // 
            this.cmdFile1.Key = "cmdFile";
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            this.cmdEdit1.Key = "cmdEdit";
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // cmdView1
            // 
            this.cmdView1.Key = "cmdView";
            this.cmdView1.Name = "cmdView1";
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditMode1,
            this.cmdTitle1,
            this.Separator1,
            this.cmdSave2,
            this.cmdCancel2,
            this.cmdDelete2,
            this.Separator3,
            this.cmdEditParty1,
            this.Separator2,
            this.tsAudit1});
            this.uiCommandBar2.FullRow = true;
            this.uiCommandBar2.Key = "cbMergeToolbar";
            this.uiCommandBar2.Location = new System.Drawing.Point(0, 22);
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.RowIndex = 1;
            this.uiCommandBar2.Size = new System.Drawing.Size(778, 28);
            this.uiCommandBar2.Text = "CommandBar1";
            // 
            // tsEditMode1
            // 
            this.tsEditMode1.Key = "tsEditMode";
            this.tsEditMode1.Name = "tsEditMode1";
            // 
            // cmdTitle1
            // 
            this.cmdTitle1.Key = "cmdTitle";
            this.cmdTitle1.MergeOrder = 1;
            this.cmdTitle1.Name = "cmdTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.MergeOrder = 2;
            this.Separator1.Name = "Separator1";
            // 
            // cmdSave2
            // 
            this.cmdSave2.Key = "cmdSave";
            this.cmdSave2.MergeOrder = 20;
            this.cmdSave2.Name = "cmdSave2";
            // 
            // cmdCancel2
            // 
            this.cmdCancel2.Key = "cmdCancel";
            this.cmdCancel2.MergeOrder = 21;
            this.cmdCancel2.Name = "cmdCancel2";
            // 
            // cmdDelete2
            // 
            this.cmdDelete2.Key = "cmdDelete";
            this.cmdDelete2.MergeOrder = 22;
            this.cmdDelete2.Name = "cmdDelete2";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator3.Key = "Separator";
            this.Separator3.MergeOrder = 23;
            this.Separator3.Name = "Separator3";
            // 
            // cmdEditParty1
            // 
            this.cmdEditParty1.Key = "cmdEditParty";
            this.cmdEditParty1.MergeOrder = 24;
            this.cmdEditParty1.Name = "cmdEditParty1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.MergeOrder = 25;
            this.Separator2.Name = "Separator2";
            // 
            // tsAudit1
            // 
            this.tsAudit1.Key = "tsAudit";
            this.tsAudit1.MergeOrder = 80;
            this.tsAudit1.Name = "tsAudit1";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave1});
            this.cmdFile.Key = "cmdFile";
            this.cmdFile.Name = "cmdFile";
            this.cmdFile.Text = "&File";
            // 
            // cmdSave1
            // 
            this.cmdSave1.Key = "cmdSave";
            this.cmdSave1.Name = "cmdSave1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCancel1,
            this.cmdDelete1});
            this.cmdEdit.Key = "cmdEdit";
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Text = "Edit";
            // 
            // cmdCancel1
            // 
            this.cmdCancel1.Key = "cmdCancel";
            this.cmdCancel1.Name = "cmdCancel1";
            // 
            // cmdDelete1
            // 
            this.cmdDelete1.Key = "cmdDelete";
            this.cmdDelete1.Name = "cmdDelete1";
            // 
            // cmdView
            // 
            this.cmdView.Key = "cmdView";
            this.cmdView.Name = "cmdView";
            this.cmdView.Text = "&View";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Key = "cmdSave";
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Text = "Save";
            // 
            // cmdCancel
            // 
            this.cmdCancel.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Key = "cmdCancel";
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Text = "Cancel";
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.Key = "cmdDelete";
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "Delete";
            // 
            // cmdTitle
            // 
            this.cmdTitle.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.cmdTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.cmdTitle.Key = "cmdTitle";
            this.cmdTitle.Name = "cmdTitle";
            this.cmdTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.cmdTitle.Text = "Participants";
            // 
            // tsEditMode
            // 
            this.tsEditMode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditMode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.tsEditMode.Image = ((System.Drawing.Image)(resources.GetObject("tsEditMode.Image")));
            this.tsEditMode.Key = "tsEditMode";
            this.tsEditMode.Name = "tsEditMode";
            // 
            // tsAudit
            // 
            this.tsAudit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsAudit.Image = ((System.Drawing.Image)(resources.GetObject("tsAudit.Image")));
            this.tsAudit.Key = "tsAudit";
            this.tsAudit.Name = "tsAudit";
            this.tsAudit.Text = "Data Row Properties";
            this.tsAudit.ToolTipText = "Data Row Properties";
            // 
            // cmdEditParty
            // 
            this.cmdEditParty.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdEditParty.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditParty.Image")));
            this.cmdEditParty.Key = "cmdEditParty";
            this.cmdEditParty.Name = "cmdEditParty";
            this.cmdEditParty.Text = "Edit Party Information/Address";
            this.cmdEditParty.ToolTipText = "Edit Party Information/Address";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(0, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(778, 50);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.partyBindingSource;
            // 
            // ucFileParty
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucFileParty";
            this.helpProvider1.SetShowHelp(this, true);
            this.Size = new System.Drawing.Size(778, 830);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbAddress)).EndInit();
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbPerson)).EndInit();
            this.gbPerson.ResumeLayout(false);
            this.gbPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbLP)).EndInit();
            this.gbLP.ResumeLayout(false);
            this.gbLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePartyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactFileContactBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filePartyGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel2;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UICommand cmdTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.GridEX.GridEX filePartyGridEX;
        private System.Windows.Forms.BindingSource filePartyBindingSource;
        private Janus.Windows.EditControls.UIGroupBox gbLP;
        private Janus.Windows.CalendarCombo.CalendarCombo notifiedOfAppealDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo advisedOfHearingDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo sentNoticeOfHearingDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo certifiedReadyDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo notifiedOfDecisionDateCalendarCombo;
        private UserControls.ucMultiDropDown contactTypeCodeucMultiDropDown;
        private Janus.Windows.EditControls.UIGroupBox gbPerson;
        private Janus.Windows.GridEX.EditControls.EditBox telephoneExtensionEditBox;
        private System.Windows.Forms.BindingSource partyBindingSource;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox sINMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox salutationEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox lastNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox middleNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox firstNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox suffixEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox telephoneNumberMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox cellPhoneMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox faxNumberMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox emailAddressEditBox;
        private UserControls.ucMultiDropDown sexCodeucMultiDropDown;
        private Janus.Windows.CalendarCombo.CalendarCombo birthDateCalendarCombo;
        private UserControls.ucMultiDropDown languageCodeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.EditBox notesEditBox;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private UserControls.ucMultiDropDown mccHearingMethod;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private Janus.Windows.EditControls.UIGroupBox gbAddress;
        private UserControls.ucAddress ucAddress1;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private Janus.Windows.GridEX.EditControls.EditBox editBox2;
        private Janus.Windows.GridEX.EditControls.EditBox editBox3;
        private Janus.Windows.GridEX.EditControls.EditBox editBox4;
        private Janus.Windows.GridEX.EditControls.EditBox editBox5;
        private Janus.Windows.GridEX.EditControls.EditBox companyEditBox;
        private Janus.Windows.EditControls.UICheckBox isAppellantUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isPendingUICheckBox;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditParty1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditParty;
        private System.Windows.Forms.BindingSource contactFileContactBindingSource;
    }
}
