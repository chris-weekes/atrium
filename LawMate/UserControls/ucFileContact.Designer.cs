 namespace LawMate
{
    partial class ucFileContact
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
                FM.DB.FileContact.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.GetFileContact().OnUpdate -= new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);
                FM.DB.Contact.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.DB.Address.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);

                FM.GetPerson().OnUpdate -= new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);
                FM.GetAddress().OnUpdate -= new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);

                if (participantsLoaded)
                {
                    FM.GetSSTMng().DB.FileParty.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                    FM.GetSSTMng().GetFileParty().OnUpdate -= new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFileContact));
            System.Windows.Forms.Label startDateLabel;
            System.Windows.Forms.Label endDateLabel;
            System.Windows.Forms.Label officerCodeLabel1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label sINLabel;
            System.Windows.Forms.Label salutationLabel;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label middleNameLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label suffixLabel;
            System.Windows.Forms.Label telephoneNumberLabel;
            System.Windows.Forms.Label cellPhoneLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label faxNumberLabel;
            System.Windows.Forms.Label emailAddressLabel;
            System.Windows.Forms.Label languageCodeLabel;
            System.Windows.Forms.Label advisedOfHearingDateLabel;
            System.Windows.Forms.Label sentNoticeOfHearingDateLabel;
            System.Windows.Forms.Label notifiedOfAppealDateLabel;
            System.Windows.Forms.Label certifiedReadyDateLabel;
            System.Windows.Forms.Label notifiedOfDecisionDateLabel;
            Janus.Windows.GridEX.GridEXLayout fileContactGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference fileContactGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference fileContactGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference fileContactGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item2.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference fileContactGridEX_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference fileContactGridEX_DesignTimeLayout_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item0.Image");
            this.contactTypeLabel = new System.Windows.Forms.Label();
            this.notesLabel = new System.Windows.Forms.Label();
            this.NativeLang = new System.Windows.Forms.Label();
            this.fileContactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.contactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdEditParticipant1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEditParticipant");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsConvertToOfficer1 = new Janus.Windows.UI.CommandBars.UICommand("tsConvertToOfficer");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsConvertToOfficer = new Janus.Windows.UI.CommandBars.UICommand("tsConvertToOfficer");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.tsConvertToOfficer2 = new Janus.Windows.UI.CommandBars.UICommand("tsConvertToOfficer");
            this.cmdEditParticipant = new Janus.Windows.UI.CommandBars.UICommand("cmdEditParticipant");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.gbBusiness = new Janus.Windows.EditControls.UIGroupBox();
            this.maskedEditBox4 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.editBox5 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox3 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox4 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.gbOfficer = new Janus.Windows.EditControls.UIGroupBox();
            this.chkNoReassign = new Janus.Windows.EditControls.UICheckBox();
            this.officerCodeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ucOfficeSelectBox1 = new LawMate.ucOfficeSelectBox();
            this.gbPerson = new Janus.Windows.EditControls.UIGroupBox();
            this.salutationEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.suffixEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.firstNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lastNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.middleNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.gbParticipant = new Janus.Windows.EditControls.UIGroupBox();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.filePartyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notifiedOfAppealDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.certifiedReadyDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.notifiedOfDecisionDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.advisedOfHearingDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sentNoticeOfHearingDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.isPendingUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isAppellantUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.fileContactGridEX = new Janus.Windows.GridEX.GridEX();
            this.endDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gbContactInfo = new Janus.Windows.EditControls.UIGroupBox();
            this.btnAddAddress = new Janus.Windows.EditControls.UIButton();
            this.chkInterpreter = new Janus.Windows.EditControls.UICheckBox();
            this.ucMultiDDNativeLanguage = new LawMate.UserControls.ucMultiDropDown();
            this.sINMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.notesEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox6 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.maskedEditBox1 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.languageCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.maskedEditBox2 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.maskedEditBox3 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.ucAddress1 = new LawMate.UserControls.ucAddress();
            this.startDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            startDateLabel = new System.Windows.Forms.Label();
            endDateLabel = new System.Windows.Forms.Label();
            officerCodeLabel1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            sINLabel = new System.Windows.Forms.Label();
            salutationLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            suffixLabel = new System.Windows.Forms.Label();
            telephoneNumberLabel = new System.Windows.Forms.Label();
            cellPhoneLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            faxNumberLabel = new System.Windows.Forms.Label();
            emailAddressLabel = new System.Windows.Forms.Label();
            languageCodeLabel = new System.Windows.Forms.Label();
            advisedOfHearingDateLabel = new System.Windows.Forms.Label();
            sentNoticeOfHearingDateLabel = new System.Windows.Forms.Label();
            notifiedOfAppealDateLabel = new System.Windows.Forms.Label();
            certifiedReadyDateLabel = new System.Windows.Forms.Label();
            notifiedOfDecisionDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileContactBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbBusiness)).BeginInit();
            this.gbBusiness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbOfficer)).BeginInit();
            this.gbOfficer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbPerson)).BeginInit();
            this.gbPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbParticipant)).BeginInit();
            this.gbParticipant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePartyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileContactGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbContactInfo)).BeginInit();
            this.gbContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.fileContactBindingSource;
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
            // startDateLabel
            // 
            resources.ApplyResources(startDateLabel, "startDateLabel");
            startDateLabel.BackColor = System.Drawing.Color.Transparent;
            startDateLabel.Name = "startDateLabel";
            this.helpProvider1.SetShowHelp(startDateLabel, ((bool)(resources.GetObject("startDateLabel.ShowHelp"))));
            // 
            // endDateLabel
            // 
            resources.ApplyResources(endDateLabel, "endDateLabel");
            endDateLabel.BackColor = System.Drawing.Color.Transparent;
            endDateLabel.Name = "endDateLabel";
            this.helpProvider1.SetShowHelp(endDateLabel, ((bool)(resources.GetObject("endDateLabel.ShowHelp"))));
            // 
            // officerCodeLabel1
            // 
            resources.ApplyResources(officerCodeLabel1, "officerCodeLabel1");
            officerCodeLabel1.Name = "officerCodeLabel1";
            this.helpProvider1.SetShowHelp(officerCodeLabel1, ((bool)(resources.GetObject("officerCodeLabel1.ShowHelp"))));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            this.helpProvider1.SetShowHelp(label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            this.toolTip1.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            this.helpProvider1.SetShowHelp(label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            this.helpProvider1.SetShowHelp(label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // sINLabel
            // 
            resources.ApplyResources(sINLabel, "sINLabel");
            sINLabel.Name = "sINLabel";
            this.helpProvider1.SetShowHelp(sINLabel, ((bool)(resources.GetObject("sINLabel.ShowHelp"))));
            // 
            // salutationLabel
            // 
            resources.ApplyResources(salutationLabel, "salutationLabel");
            salutationLabel.Name = "salutationLabel";
            this.helpProvider1.SetShowHelp(salutationLabel, ((bool)(resources.GetObject("salutationLabel.ShowHelp"))));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            this.helpProvider1.SetShowHelp(label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            // 
            // middleNameLabel
            // 
            resources.ApplyResources(middleNameLabel, "middleNameLabel");
            middleNameLabel.Name = "middleNameLabel";
            this.helpProvider1.SetShowHelp(middleNameLabel, ((bool)(resources.GetObject("middleNameLabel.ShowHelp"))));
            // 
            // firstNameLabel
            // 
            resources.ApplyResources(firstNameLabel, "firstNameLabel");
            firstNameLabel.Name = "firstNameLabel";
            this.helpProvider1.SetShowHelp(firstNameLabel, ((bool)(resources.GetObject("firstNameLabel.ShowHelp"))));
            // 
            // suffixLabel
            // 
            resources.ApplyResources(suffixLabel, "suffixLabel");
            suffixLabel.Name = "suffixLabel";
            this.helpProvider1.SetShowHelp(suffixLabel, ((bool)(resources.GetObject("suffixLabel.ShowHelp"))));
            // 
            // telephoneNumberLabel
            // 
            resources.ApplyResources(telephoneNumberLabel, "telephoneNumberLabel");
            telephoneNumberLabel.Name = "telephoneNumberLabel";
            this.helpProvider1.SetShowHelp(telephoneNumberLabel, ((bool)(resources.GetObject("telephoneNumberLabel.ShowHelp"))));
            // 
            // cellPhoneLabel
            // 
            resources.ApplyResources(cellPhoneLabel, "cellPhoneLabel");
            cellPhoneLabel.Name = "cellPhoneLabel";
            this.helpProvider1.SetShowHelp(cellPhoneLabel, ((bool)(resources.GetObject("cellPhoneLabel.ShowHelp"))));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            this.helpProvider1.SetShowHelp(label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // faxNumberLabel
            // 
            resources.ApplyResources(faxNumberLabel, "faxNumberLabel");
            faxNumberLabel.Name = "faxNumberLabel";
            this.helpProvider1.SetShowHelp(faxNumberLabel, ((bool)(resources.GetObject("faxNumberLabel.ShowHelp"))));
            // 
            // emailAddressLabel
            // 
            resources.ApplyResources(emailAddressLabel, "emailAddressLabel");
            emailAddressLabel.Name = "emailAddressLabel";
            this.helpProvider1.SetShowHelp(emailAddressLabel, ((bool)(resources.GetObject("emailAddressLabel.ShowHelp"))));
            // 
            // languageCodeLabel
            // 
            resources.ApplyResources(languageCodeLabel, "languageCodeLabel");
            languageCodeLabel.Name = "languageCodeLabel";
            this.helpProvider1.SetShowHelp(languageCodeLabel, ((bool)(resources.GetObject("languageCodeLabel.ShowHelp"))));
            // 
            // advisedOfHearingDateLabel
            // 
            resources.ApplyResources(advisedOfHearingDateLabel, "advisedOfHearingDateLabel");
            advisedOfHearingDateLabel.Name = "advisedOfHearingDateLabel";
            this.helpProvider1.SetShowHelp(advisedOfHearingDateLabel, ((bool)(resources.GetObject("advisedOfHearingDateLabel.ShowHelp"))));
            // 
            // sentNoticeOfHearingDateLabel
            // 
            resources.ApplyResources(sentNoticeOfHearingDateLabel, "sentNoticeOfHearingDateLabel");
            sentNoticeOfHearingDateLabel.Name = "sentNoticeOfHearingDateLabel";
            this.helpProvider1.SetShowHelp(sentNoticeOfHearingDateLabel, ((bool)(resources.GetObject("sentNoticeOfHearingDateLabel.ShowHelp"))));
            // 
            // notifiedOfAppealDateLabel
            // 
            resources.ApplyResources(notifiedOfAppealDateLabel, "notifiedOfAppealDateLabel");
            notifiedOfAppealDateLabel.Name = "notifiedOfAppealDateLabel";
            this.helpProvider1.SetShowHelp(notifiedOfAppealDateLabel, ((bool)(resources.GetObject("notifiedOfAppealDateLabel.ShowHelp"))));
            // 
            // certifiedReadyDateLabel
            // 
            resources.ApplyResources(certifiedReadyDateLabel, "certifiedReadyDateLabel");
            certifiedReadyDateLabel.Name = "certifiedReadyDateLabel";
            this.helpProvider1.SetShowHelp(certifiedReadyDateLabel, ((bool)(resources.GetObject("certifiedReadyDateLabel.ShowHelp"))));
            // 
            // notifiedOfDecisionDateLabel
            // 
            resources.ApplyResources(notifiedOfDecisionDateLabel, "notifiedOfDecisionDateLabel");
            notifiedOfDecisionDateLabel.Name = "notifiedOfDecisionDateLabel";
            this.helpProvider1.SetShowHelp(notifiedOfDecisionDateLabel, ((bool)(resources.GetObject("notifiedOfDecisionDateLabel.ShowHelp"))));
            // 
            // contactTypeLabel
            // 
            resources.ApplyResources(this.contactTypeLabel, "contactTypeLabel");
            this.contactTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.contactTypeLabel.Name = "contactTypeLabel";
            this.helpProvider1.SetShowHelp(this.contactTypeLabel, ((bool)(resources.GetObject("contactTypeLabel.ShowHelp"))));
            // 
            // notesLabel
            // 
            resources.ApplyResources(this.notesLabel, "notesLabel");
            this.notesLabel.Name = "notesLabel";
            this.helpProvider1.SetShowHelp(this.notesLabel, ((bool)(resources.GetObject("notesLabel.ShowHelp"))));
            // 
            // NativeLang
            // 
            resources.ApplyResources(this.NativeLang, "NativeLang");
            this.NativeLang.Name = "NativeLang";
            this.helpProvider1.SetShowHelp(this.NativeLang, ((bool)(resources.GetObject("NativeLang.ShowHelp"))));
            // 
            // fileContactBindingSource
            // 
            this.fileContactBindingSource.DataMember = "FileContact";
            this.fileContactBindingSource.DataSource = this.atriumDB;
            this.fileContactBindingSource.CurrentChanged += new System.EventHandler(this.fileContactBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
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
            this.tsConvertToOfficer,
            this.cmdFile,
            this.cmdEdit,
            this.cmdTools,
            this.cmdEditParticipant});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("29725a75-d501-4431-a9e7-f2546ecbc617");
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
            this.tsSave1,
            this.tsDelete1,
            this.Separator2,
            this.cmdEditParticipant1,
            this.Separator4,
            this.tsConvertToOfficer1,
            this.Separator3,
            this.tsAudit1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
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
            // cmdEditParticipant1
            // 
            resources.ApplyResources(this.cmdEditParticipant1, "cmdEditParticipant1");
            this.cmdEditParticipant1.Name = "cmdEditParticipant1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsConvertToOfficer1
            // 
            resources.ApplyResources(this.tsConvertToOfficer1, "tsConvertToOfficer1");
            this.tsConvertToOfficer1.Name = "tsConvertToOfficer1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
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
            this.tsEditmode.Visible = Janus.Windows.UI.InheritableBoolean.True;
            // 
            // tsAudit
            // 
            this.tsAudit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsConvertToOfficer
            // 
            this.tsConvertToOfficer.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsConvertToOfficer, "tsConvertToOfficer");
            this.tsConvertToOfficer.Name = "tsConvertToOfficer";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
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
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsConvertToOfficer2});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdTools.Name = "cmdTools";
            // 
            // tsConvertToOfficer2
            // 
            resources.ApplyResources(this.tsConvertToOfficer2, "tsConvertToOfficer2");
            this.tsConvertToOfficer2.Name = "tsConvertToOfficer2";
            // 
            // cmdEditParticipant
            // 
            this.cmdEditParticipant.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdEditParticipant, "cmdEditParticipant");
            this.cmdEditParticipant.Name = "cmdEditParticipant";
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
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(730, 796), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("bb3061fb-8c4a-4f62-838b-fec8a5c1ca87"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8ea79ee8-cdb3-46ad-9e33-4491edce473b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.gbBusiness);
            this.pnlAllContainer.Controls.Add(this.contactTypeLabel);
            this.pnlAllContainer.Controls.Add(startDateLabel);
            this.pnlAllContainer.Controls.Add(this.gbOfficer);
            this.pnlAllContainer.Controls.Add(this.gbPerson);
            this.pnlAllContainer.Controls.Add(this.gbParticipant);
            this.pnlAllContainer.Controls.Add(endDateLabel);
            this.pnlAllContainer.Controls.Add(this.fileContactGridEX);
            this.pnlAllContainer.Controls.Add(this.endDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(this.gbContactInfo);
            this.pnlAllContainer.Controls.Add(this.startDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(this.ucMultiDropDown1);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // gbBusiness
            // 
            this.gbBusiness.BackColor = System.Drawing.Color.Transparent;
            this.gbBusiness.Controls.Add(this.maskedEditBox4);
            this.gbBusiness.Controls.Add(label3);
            this.gbBusiness.Controls.Add(this.editBox5);
            this.gbBusiness.Controls.Add(label2);
            this.gbBusiness.Controls.Add(this.editBox3);
            this.gbBusiness.Controls.Add(this.editBox4);
            this.gbBusiness.Controls.Add(label5);
            this.gbBusiness.Controls.Add(label4);
            this.gbBusiness.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbBusiness, "gbBusiness");
            this.gbBusiness.Name = "gbBusiness";
            this.helpProvider1.SetShowHelp(this.gbBusiness, ((bool)(resources.GetObject("gbBusiness.ShowHelp"))));
            this.gbBusiness.UseThemes = false;
            // 
            // maskedEditBox4
            // 
            this.maskedEditBox4.BackColor = System.Drawing.SystemColors.Control;
            this.maskedEditBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maskedEditBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "BusinessNumber", true));
            resources.ApplyResources(this.maskedEditBox4, "maskedEditBox4");
            this.maskedEditBox4.Mask = "000000000 LL 0000";
            this.maskedEditBox4.Name = "maskedEditBox4";
            this.maskedEditBox4.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.maskedEditBox4, ((bool)(resources.GetObject("maskedEditBox4.ShowHelp"))));
            this.maskedEditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox5
            // 
            this.editBox5.BackColor = System.Drawing.SystemColors.Control;
            this.editBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "Attention", true));
            resources.ApplyResources(this.editBox5, "editBox5");
            this.editBox5.Name = "editBox5";
            this.editBox5.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox5, ((bool)(resources.GetObject("editBox5.ShowHelp"))));
            this.editBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox3
            // 
            this.editBox3.BackColor = System.Drawing.SystemColors.Control;
            this.editBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "LegalName", true));
            resources.ApplyResources(this.editBox3, "editBox3");
            this.editBox3.Name = "editBox3";
            this.editBox3.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox3, ((bool)(resources.GetObject("editBox3.ShowHelp"))));
            this.editBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox4
            // 
            this.editBox4.BackColor = System.Drawing.SystemColors.Control;
            this.editBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "OperatingAs", true));
            resources.ApplyResources(this.editBox4, "editBox4");
            this.editBox4.Name = "editBox4";
            this.editBox4.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox4, ((bool)(resources.GetObject("editBox4.ShowHelp"))));
            this.editBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gbOfficer
            // 
            this.gbOfficer.BackColor = System.Drawing.Color.Transparent;
            this.gbOfficer.Controls.Add(this.chkNoReassign);
            this.gbOfficer.Controls.Add(this.officerCodeEditBox);
            this.gbOfficer.Controls.Add(officerCodeLabel1);
            this.gbOfficer.Controls.Add(this.ucOfficeSelectBox1);
            resources.ApplyResources(this.gbOfficer, "gbOfficer");
            this.gbOfficer.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbOfficer.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbOfficer.Name = "gbOfficer";
            this.helpProvider1.SetShowHelp(this.gbOfficer, ((bool)(resources.GetObject("gbOfficer.ShowHelp"))));
            this.gbOfficer.UseThemes = false;
            this.gbOfficer.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // chkNoReassign
            // 
            this.chkNoReassign.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoReassign.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.fileContactBindingSource, "NoReassign", true));
            resources.ApplyResources(this.chkNoReassign, "chkNoReassign");
            this.chkNoReassign.Name = "chkNoReassign";
            this.helpProvider1.SetShowHelp(this.chkNoReassign, ((bool)(resources.GetObject("chkNoReassign.ShowHelp"))));
            this.chkNoReassign.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // officerCodeEditBox
            // 
            this.officerCodeEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.officerCodeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fileContactBindingSource, "OfficerCode", true));
            resources.ApplyResources(this.officerCodeEditBox, "officerCodeEditBox");
            this.officerCodeEditBox.Name = "officerCodeEditBox";
            this.officerCodeEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.officerCodeEditBox, ((bool)(resources.GetObject("officerCodeEditBox.ShowHelp"))));
            this.officerCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucOfficeSelectBox1
            // 
            this.ucOfficeSelectBox1.AtMng = null;
            this.ucOfficeSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucOfficeSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.fileContactBindingSource, "OfficeId", true));
            resources.ApplyResources(this.ucOfficeSelectBox1, "ucOfficeSelectBox1");
            this.ucOfficeSelectBox1.Name = "ucOfficeSelectBox1";
            this.ucOfficeSelectBox1.OfficeId = null;
            this.ucOfficeSelectBox1.ReadOnly = true;
            this.ucOfficeSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucOfficeSelectBox1, ((bool)(resources.GetObject("ucOfficeSelectBox1.ShowHelp"))));
            // 
            // gbPerson
            // 
            this.gbPerson.BackColor = System.Drawing.Color.Transparent;
            this.gbPerson.Controls.Add(this.salutationEditBox);
            this.gbPerson.Controls.Add(suffixLabel);
            this.gbPerson.Controls.Add(salutationLabel);
            this.gbPerson.Controls.Add(this.suffixEditBox);
            this.gbPerson.Controls.Add(this.firstNameEditBox);
            this.gbPerson.Controls.Add(label6);
            this.gbPerson.Controls.Add(this.lastNameEditBox);
            this.gbPerson.Controls.Add(middleNameLabel);
            this.gbPerson.Controls.Add(this.middleNameEditBox);
            this.gbPerson.Controls.Add(firstNameLabel);
            this.gbPerson.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbPerson, "gbPerson");
            this.gbPerson.Name = "gbPerson";
            this.helpProvider1.SetShowHelp(this.gbPerson, ((bool)(resources.GetObject("gbPerson.ShowHelp"))));
            this.gbPerson.UseThemes = false;
            // 
            // salutationEditBox
            // 
            this.salutationEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.salutationEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "Salutation", true));
            resources.ApplyResources(this.salutationEditBox, "salutationEditBox");
            this.salutationEditBox.Name = "salutationEditBox";
            this.salutationEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.salutationEditBox, ((bool)(resources.GetObject("salutationEditBox.ShowHelp"))));
            this.salutationEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // suffixEditBox
            // 
            this.suffixEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.suffixEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "Suffix", true));
            resources.ApplyResources(this.suffixEditBox, "suffixEditBox");
            this.suffixEditBox.Name = "suffixEditBox";
            this.suffixEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.suffixEditBox, ((bool)(resources.GetObject("suffixEditBox.ShowHelp"))));
            this.suffixEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // firstNameEditBox
            // 
            this.firstNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.firstNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "FirstName", true));
            resources.ApplyResources(this.firstNameEditBox, "firstNameEditBox");
            this.firstNameEditBox.Name = "firstNameEditBox";
            this.firstNameEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.firstNameEditBox, ((bool)(resources.GetObject("firstNameEditBox.ShowHelp"))));
            this.firstNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lastNameEditBox
            // 
            this.lastNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.lastNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "LastName", true));
            resources.ApplyResources(this.lastNameEditBox, "lastNameEditBox");
            this.lastNameEditBox.Name = "lastNameEditBox";
            this.lastNameEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.lastNameEditBox, ((bool)(resources.GetObject("lastNameEditBox.ShowHelp"))));
            this.lastNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // middleNameEditBox
            // 
            this.middleNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.middleNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "MiddleName", true));
            resources.ApplyResources(this.middleNameEditBox, "middleNameEditBox");
            this.middleNameEditBox.Name = "middleNameEditBox";
            this.middleNameEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.middleNameEditBox, ((bool)(resources.GetObject("middleNameEditBox.ShowHelp"))));
            this.middleNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gbParticipant
            // 
            this.gbParticipant.BackColor = System.Drawing.Color.Transparent;
            this.gbParticipant.Controls.Add(this.uiCheckBox1);
            this.gbParticipant.Controls.Add(this.notifiedOfAppealDateCalendarCombo);
            this.gbParticipant.Controls.Add(this.certifiedReadyDateCalendarCombo);
            this.gbParticipant.Controls.Add(this.notifiedOfDecisionDateCalendarCombo);
            this.gbParticipant.Controls.Add(this.advisedOfHearingDateCalendarCombo);
            this.gbParticipant.Controls.Add(this.sentNoticeOfHearingDateCalendarCombo);
            this.gbParticipant.Controls.Add(this.isPendingUICheckBox);
            this.gbParticipant.Controls.Add(this.isAppellantUICheckBox);
            this.gbParticipant.Controls.Add(notifiedOfAppealDateLabel);
            this.gbParticipant.Controls.Add(advisedOfHearingDateLabel);
            this.gbParticipant.Controls.Add(notifiedOfDecisionDateLabel);
            this.gbParticipant.Controls.Add(certifiedReadyDateLabel);
            this.gbParticipant.Controls.Add(sentNoticeOfHearingDateLabel);
            resources.ApplyResources(this.gbParticipant, "gbParticipant");
            this.gbParticipant.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbParticipant.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbParticipant.Image = global::LawMate.Properties.Resources.RecipientUnknown;
            this.gbParticipant.Name = "gbParticipant";
            this.helpProvider1.SetShowHelp(this.gbParticipant, ((bool)(resources.GetObject("gbParticipant.ShowHelp"))));
            this.gbParticipant.UseThemes = false;
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "IsRespondent", true));
            this.uiCheckBox1.Image = global::LawMate.Properties.Resources.respondent;
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.helpProvider1.SetShowHelp(this.uiCheckBox1, ((bool)(resources.GetObject("uiCheckBox1.ShowHelp"))));
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // notifiedOfAppealDateCalendarCombo
            // 
            resources.ApplyResources(this.notifiedOfAppealDateCalendarCombo, "notifiedOfAppealDateCalendarCombo");
            this.notifiedOfAppealDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "NotifiedOfAppealDate", true));
            this.notifiedOfAppealDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.notifiedOfAppealDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.notifiedOfAppealDateCalendarCombo.MonthIncrement = 0;
            this.notifiedOfAppealDateCalendarCombo.Name = "notifiedOfAppealDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.notifiedOfAppealDateCalendarCombo, ((bool)(resources.GetObject("notifiedOfAppealDateCalendarCombo.ShowHelp"))));
            this.notifiedOfAppealDateCalendarCombo.ShowNullButton = true;
            this.notifiedOfAppealDateCalendarCombo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            this.notifiedOfAppealDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.notifiedOfAppealDateCalendarCombo.YearIncrement = 0;
            // 
            // certifiedReadyDateCalendarCombo
            // 
            resources.ApplyResources(this.certifiedReadyDateCalendarCombo, "certifiedReadyDateCalendarCombo");
            this.certifiedReadyDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "CertifiedReadyDate", true));
            this.certifiedReadyDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.certifiedReadyDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.certifiedReadyDateCalendarCombo.MonthIncrement = 0;
            this.certifiedReadyDateCalendarCombo.Name = "certifiedReadyDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.certifiedReadyDateCalendarCombo, ((bool)(resources.GetObject("certifiedReadyDateCalendarCombo.ShowHelp"))));
            this.certifiedReadyDateCalendarCombo.ShowNullButton = true;
            this.certifiedReadyDateCalendarCombo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            this.certifiedReadyDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.certifiedReadyDateCalendarCombo.YearIncrement = 0;
            // 
            // notifiedOfDecisionDateCalendarCombo
            // 
            resources.ApplyResources(this.notifiedOfDecisionDateCalendarCombo, "notifiedOfDecisionDateCalendarCombo");
            this.notifiedOfDecisionDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "NotifiedOfDecisionDate", true));
            this.notifiedOfDecisionDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.notifiedOfDecisionDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.notifiedOfDecisionDateCalendarCombo.MonthIncrement = 0;
            this.notifiedOfDecisionDateCalendarCombo.Name = "notifiedOfDecisionDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.notifiedOfDecisionDateCalendarCombo, ((bool)(resources.GetObject("notifiedOfDecisionDateCalendarCombo.ShowHelp"))));
            this.notifiedOfDecisionDateCalendarCombo.ShowNullButton = true;
            this.notifiedOfDecisionDateCalendarCombo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            this.notifiedOfDecisionDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.notifiedOfDecisionDateCalendarCombo.YearIncrement = 0;
            // 
            // advisedOfHearingDateCalendarCombo
            // 
            resources.ApplyResources(this.advisedOfHearingDateCalendarCombo, "advisedOfHearingDateCalendarCombo");
            this.advisedOfHearingDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "AdvisedOfHearingDate", true));
            this.advisedOfHearingDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.advisedOfHearingDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.advisedOfHearingDateCalendarCombo.MonthIncrement = 0;
            this.advisedOfHearingDateCalendarCombo.Name = "advisedOfHearingDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.advisedOfHearingDateCalendarCombo, ((bool)(resources.GetObject("advisedOfHearingDateCalendarCombo.ShowHelp"))));
            this.advisedOfHearingDateCalendarCombo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            this.advisedOfHearingDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.advisedOfHearingDateCalendarCombo.YearIncrement = 0;
            // 
            // sentNoticeOfHearingDateCalendarCombo
            // 
            resources.ApplyResources(this.sentNoticeOfHearingDateCalendarCombo, "sentNoticeOfHearingDateCalendarCombo");
            this.sentNoticeOfHearingDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "SentNoticeOfHearingDate", true));
            this.sentNoticeOfHearingDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.sentNoticeOfHearingDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentNoticeOfHearingDateCalendarCombo.MonthIncrement = 0;
            this.sentNoticeOfHearingDateCalendarCombo.Name = "sentNoticeOfHearingDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.sentNoticeOfHearingDateCalendarCombo, ((bool)(resources.GetObject("sentNoticeOfHearingDateCalendarCombo.ShowHelp"))));
            this.sentNoticeOfHearingDateCalendarCombo.ShowNullButton = true;
            this.sentNoticeOfHearingDateCalendarCombo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            this.sentNoticeOfHearingDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentNoticeOfHearingDateCalendarCombo.YearIncrement = 0;
            // 
            // isPendingUICheckBox
            // 
            this.isPendingUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isPendingUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "IsPending", true));
            this.isPendingUICheckBox.Image = global::LawMate.Properties.Resources.hourglassPending;
            resources.ApplyResources(this.isPendingUICheckBox, "isPendingUICheckBox");
            this.isPendingUICheckBox.Name = "isPendingUICheckBox";
            this.helpProvider1.SetShowHelp(this.isPendingUICheckBox, ((bool)(resources.GetObject("isPendingUICheckBox.ShowHelp"))));
            this.isPendingUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isAppellantUICheckBox
            // 
            this.isAppellantUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isAppellantUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.filePartyBindingSource, "IsAppellant", true));
            this.isAppellantUICheckBox.Image = global::LawMate.Properties.Resources.appellant;
            resources.ApplyResources(this.isAppellantUICheckBox, "isAppellantUICheckBox");
            this.isAppellantUICheckBox.Name = "isAppellantUICheckBox";
            this.helpProvider1.SetShowHelp(this.isAppellantUICheckBox, ((bool)(resources.GetObject("isAppellantUICheckBox.ShowHelp"))));
            this.isAppellantUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // fileContactGridEX
            // 
            this.fileContactGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.fileContactGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileContactGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.fileContactGridEX.DataSource = this.fileContactBindingSource;
            fileContactGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("fileContactGridEX_DesignTimeLayout_Reference_0.Instance")));
            fileContactGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("fileContactGridEX_DesignTimeLayout_Reference_1.Instance")));
            fileContactGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("fileContactGridEX_DesignTimeLayout_Reference_2.Instance")));
            fileContactGridEX_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("fileContactGridEX_DesignTimeLayout_Reference_3.Instance")));
            fileContactGridEX_DesignTimeLayout_Reference_4.Instance = ((object)(resources.GetObject("fileContactGridEX_DesignTimeLayout_Reference_4.Instance")));
            fileContactGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            fileContactGridEX_DesignTimeLayout_Reference_0,
            fileContactGridEX_DesignTimeLayout_Reference_1,
            fileContactGridEX_DesignTimeLayout_Reference_2,
            fileContactGridEX_DesignTimeLayout_Reference_3,
            fileContactGridEX_DesignTimeLayout_Reference_4});
            resources.ApplyResources(fileContactGridEX_DesignTimeLayout, "fileContactGridEX_DesignTimeLayout");
            this.fileContactGridEX.DesignTimeLayout = fileContactGridEX_DesignTimeLayout;
            this.fileContactGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.fileContactGridEX, "fileContactGridEX");
            this.fileContactGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.fileContactGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.fileContactGridEX.GroupByBoxVisible = false;
            this.fileContactGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.fileContactGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.fileContactGridEX.Name = "fileContactGridEX";
            this.fileContactGridEX.SettingsKey = "ucFileContact2";
            this.helpProvider1.SetShowHelp(this.fileContactGridEX, ((bool)(resources.GetObject("fileContactGridEX.ShowHelp"))));
            this.fileContactGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.fileContactGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.fileContactGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.fileContactGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.fileContactGridEX_LoadingRow);
            this.fileContactGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.fileContactGridEX_CurrentCellChanging);
            // 
            // endDateCalendarCombo
            // 
            this.endDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.endDateCalendarCombo, "endDateCalendarCombo");
            this.endDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileContactBindingSource, "EndDate", true));
            this.endDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.endDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.MonthIncrement = 0;
            this.endDateCalendarCombo.Name = "endDateCalendarCombo";
            this.endDateCalendarCombo.Nullable = true;
            this.endDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.endDateCalendarCombo, ((bool)(resources.GetObject("endDateCalendarCombo.ShowHelp"))));
            this.endDateCalendarCombo.ShowNullButton = true;
            this.endDateCalendarCombo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            this.endDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.YearIncrement = 0;
            // 
            // gbContactInfo
            // 
            this.gbContactInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbContactInfo.Controls.Add(this.btnAddAddress);
            this.gbContactInfo.Controls.Add(this.chkInterpreter);
            this.gbContactInfo.Controls.Add(this.ucMultiDDNativeLanguage);
            this.gbContactInfo.Controls.Add(this.NativeLang);
            this.gbContactInfo.Controls.Add(this.notesLabel);
            this.gbContactInfo.Controls.Add(emailAddressLabel);
            this.gbContactInfo.Controls.Add(this.sINMaskedEditBox);
            this.gbContactInfo.Controls.Add(sINLabel);
            this.gbContactInfo.Controls.Add(this.notesEditBox);
            this.gbContactInfo.Controls.Add(this.editBox1);
            this.gbContactInfo.Controls.Add(this.editBox6);
            this.gbContactInfo.Controls.Add(this.maskedEditBox1);
            this.gbContactInfo.Controls.Add(faxNumberLabel);
            this.gbContactInfo.Controls.Add(cellPhoneLabel);
            this.gbContactInfo.Controls.Add(languageCodeLabel);
            this.gbContactInfo.Controls.Add(label7);
            this.gbContactInfo.Controls.Add(this.languageCodeucMultiDropDown);
            this.gbContactInfo.Controls.Add(this.maskedEditBox2);
            this.gbContactInfo.Controls.Add(telephoneNumberLabel);
            this.gbContactInfo.Controls.Add(this.maskedEditBox3);
            this.gbContactInfo.Controls.Add(this.ucAddress1);
            resources.ApplyResources(this.gbContactInfo, "gbContactInfo");
            this.gbContactInfo.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbContactInfo.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbContactInfo.Name = "gbContactInfo";
            this.helpProvider1.SetShowHelp(this.gbContactInfo, ((bool)(resources.GetObject("gbContactInfo.ShowHelp"))));
            this.gbContactInfo.UseThemes = false;
            this.gbContactInfo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // btnAddAddress
            // 
            resources.ApplyResources(this.btnAddAddress, "btnAddAddress");
            this.btnAddAddress.Name = "btnAddAddress";
            this.helpProvider1.SetShowHelp(this.btnAddAddress, ((bool)(resources.GetObject("btnAddAddress.ShowHelp"))));
            this.btnAddAddress.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // chkInterpreter
            // 
            this.chkInterpreter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInterpreter.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileContactBindingSource, "InterpreterBooked", true));
            resources.ApplyResources(this.chkInterpreter, "chkInterpreter");
            this.chkInterpreter.Name = "chkInterpreter";
            this.helpProvider1.SetShowHelp(this.chkInterpreter, ((bool)(resources.GetObject("chkInterpreter.ShowHelp"))));
            this.chkInterpreter.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // ucMultiDDNativeLanguage
            // 
            this.ucMultiDDNativeLanguage.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDDNativeLanguage.Column1 = "LangId";
            resources.ApplyResources(this.ucMultiDDNativeLanguage, "ucMultiDDNativeLanguage");
            this.ucMultiDDNativeLanguage.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDDNativeLanguage.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fileContactBindingSource, "NativeLangId", true));
            this.ucMultiDDNativeLanguage.DataSource = null;
            this.ucMultiDDNativeLanguage.DDColumn1Visible = false;
            this.ucMultiDDNativeLanguage.DropDownColumn1Width = 100;
            this.ucMultiDDNativeLanguage.DropDownColumn2Width = 300;
            this.ucMultiDDNativeLanguage.Name = "ucMultiDDNativeLanguage";
            this.ucMultiDDNativeLanguage.ReadOnly = true;
            this.ucMultiDDNativeLanguage.ReqColor = System.Drawing.SystemColors.Control;
            this.ucMultiDDNativeLanguage.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDDNativeLanguage, ((bool)(resources.GetObject("ucMultiDDNativeLanguage.ShowHelp"))));
            this.ucMultiDDNativeLanguage.ValueMember = "LangId";
            // 
            // sINMaskedEditBox
            // 
            this.sINMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sINMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "SIN", true));
            this.sINMaskedEditBox.IncludeLiterals = false;
            resources.ApplyResources(this.sINMaskedEditBox, "sINMaskedEditBox");
            this.sINMaskedEditBox.Mask = "000 000 000";
            this.sINMaskedEditBox.Name = "sINMaskedEditBox";
            this.sINMaskedEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sINMaskedEditBox, ((bool)(resources.GetObject("sINMaskedEditBox.ShowHelp"))));
            this.sINMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // notesEditBox
            // 
            resources.ApplyResources(this.notesEditBox, "notesEditBox");
            this.notesEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.notesEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "Notes", true));
            this.notesEditBox.Multiline = true;
            this.notesEditBox.Name = "notesEditBox";
            this.notesEditBox.ReadOnly = true;
            this.notesEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.notesEditBox, ((bool)(resources.GetObject("notesEditBox.ShowHelp"))));
            this.notesEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.SystemColors.Control;
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "TelephoneExtension", true));
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox1, ((bool)(resources.GetObject("editBox1.ShowHelp"))));
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox6
            // 
            this.editBox6.BackColor = System.Drawing.SystemColors.Control;
            this.editBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "EmailAddress", true));
            resources.ApplyResources(this.editBox6, "editBox6");
            this.editBox6.Name = "editBox6";
            this.editBox6.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox6, ((bool)(resources.GetObject("editBox6.ShowHelp"))));
            this.editBox6.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // maskedEditBox1
            // 
            this.maskedEditBox1.BackColor = System.Drawing.SystemColors.Control;
            this.maskedEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "TelephoneNumber", true));
            resources.ApplyResources(this.maskedEditBox1, "maskedEditBox1");
            this.maskedEditBox1.Mask = "!(###) 000-0000";
            this.maskedEditBox1.Name = "maskedEditBox1";
            this.maskedEditBox1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.maskedEditBox1, ((bool)(resources.GetObject("maskedEditBox1.ShowHelp"))));
            this.maskedEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // languageCodeucMultiDropDown
            // 
            this.languageCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.languageCodeucMultiDropDown.Column1 = "LanguageCode";
            resources.ApplyResources(this.languageCodeucMultiDropDown, "languageCodeucMultiDropDown");
            this.languageCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.languageCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contactBindingSource, "LanguageCode", true));
            this.languageCodeucMultiDropDown.DataSource = null;
            this.languageCodeucMultiDropDown.DDColumn1Visible = true;
            this.languageCodeucMultiDropDown.DropDownColumn1Width = 50;
            this.languageCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.languageCodeucMultiDropDown.Name = "languageCodeucMultiDropDown";
            this.languageCodeucMultiDropDown.ReadOnly = true;
            this.languageCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Control;
            this.languageCodeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.languageCodeucMultiDropDown, ((bool)(resources.GetObject("languageCodeucMultiDropDown.ShowHelp"))));
            this.languageCodeucMultiDropDown.ValueMember = "LanguageCode";
            // 
            // maskedEditBox2
            // 
            this.maskedEditBox2.BackColor = System.Drawing.SystemColors.Control;
            this.maskedEditBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "CellPhone", true));
            resources.ApplyResources(this.maskedEditBox2, "maskedEditBox2");
            this.maskedEditBox2.Mask = "!(###) 000-0000";
            this.maskedEditBox2.Name = "maskedEditBox2";
            this.maskedEditBox2.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.maskedEditBox2, ((bool)(resources.GetObject("maskedEditBox2.ShowHelp"))));
            this.maskedEditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // maskedEditBox3
            // 
            this.maskedEditBox3.BackColor = System.Drawing.SystemColors.Control;
            this.maskedEditBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactBindingSource, "FaxNumber", true));
            resources.ApplyResources(this.maskedEditBox3, "maskedEditBox3");
            this.maskedEditBox3.Mask = "!(###) 000-0000";
            this.maskedEditBox3.Name = "maskedEditBox3";
            this.maskedEditBox3.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.maskedEditBox3, ((bool)(resources.GetObject("maskedEditBox3.ShowHelp"))));
            this.maskedEditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucAddress1
            // 
            resources.ApplyResources(this.ucAddress1, "ucAddress1");
            this.ucAddress1.BackColor = System.Drawing.Color.Transparent;
            this.ucAddress1.ColumnTwoLeftPositionOffset = 6;
            this.ucAddress1.FM = null;
            this.ucAddress1.IsReadOnly = true;
            this.ucAddress1.Name = "ucAddress1";
            this.ucAddress1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucAddress1, ((bool)(resources.GetObject("ucAddress1.ShowHelp"))));
            // 
            // startDateCalendarCombo
            // 
            this.startDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.startDateCalendarCombo, "startDateCalendarCombo");
            this.startDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileContactBindingSource, "StartDate", true));
            this.startDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.startDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 5, 1, 0, 0, 0, 0);
            this.startDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startDateCalendarCombo.MonthIncrement = 0;
            this.startDateCalendarCombo.Name = "startDateCalendarCombo";
            this.startDateCalendarCombo.Nullable = true;
            this.startDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.startDateCalendarCombo, ((bool)(resources.GetObject("startDateCalendarCombo.ShowHelp"))));
            this.startDateCalendarCombo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            this.startDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startDateCalendarCombo.YearIncrement = 0;
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown1.Column1 = "ContactTypeCode";
            resources.ApplyResources(this.ucMultiDropDown1, "ucMultiDropDown1");
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fileContactBindingSource, "ContactType", true));
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = true;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Control;
            this.ucMultiDropDown1.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown1, ((bool)(resources.GetObject("ucMultiDropDown1.ShowHelp"))));
            this.ucMultiDropDown1.ValueMember = "ContactTypeCode";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.contactBindingSource;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.DataSource = this.filePartyBindingSource;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            this.errorProvider4.DataSource = this.addressBindingSource;
            // 
            // ucFileContact
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucFileContact";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileContactBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbBusiness)).EndInit();
            this.gbBusiness.ResumeLayout(false);
            this.gbBusiness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbOfficer)).EndInit();
            this.gbOfficer.ResumeLayout(false);
            this.gbOfficer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbPerson)).EndInit();
            this.gbPerson.ResumeLayout(false);
            this.gbPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbParticipant)).EndInit();
            this.gbParticipant.ResumeLayout(false);
            this.gbParticipant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePartyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileContactGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbContactInfo)).EndInit();
            this.gbContactInfo.ResumeLayout(false);
            this.gbContactInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.GridEX.GridEX fileContactGridEX;
        private System.Windows.Forms.BindingSource fileContactBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.CalendarCombo.CalendarCombo startDateCalendarCombo;
        private UserControls.ucMultiDropDown ucMultiDropDown1;
        private Janus.Windows.UI.CommandBars.UICommand tsConvertToOfficer;
        private Janus.Windows.UI.CommandBars.UICommand tsConvertToOfficer1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.CalendarCombo.CalendarCombo endDateCalendarCombo;
        private ucOfficeSelectBox ucOfficeSelectBox1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommand tsConvertToOfficer2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.EditControls.UIGroupBox gbContactInfo;
        private Janus.Windows.GridEX.EditControls.EditBox officerCodeEditBox;
        private System.Windows.Forms.BindingSource filePartyBindingSource;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private Janus.Windows.EditControls.UIGroupBox gbPerson;
        private UserControls.ucAddress ucAddress1;
        private Janus.Windows.EditControls.UIGroupBox gbOfficer;
        private Janus.Windows.GridEX.EditControls.EditBox editBox4;
        private Janus.Windows.GridEX.EditControls.EditBox editBox5;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.GridEX.EditControls.EditBox editBox3;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox sINMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox salutationEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox lastNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox middleNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox firstNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox suffixEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox1;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox2;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox3;
        private Janus.Windows.GridEX.EditControls.EditBox editBox6;
        private UserControls.ucMultiDropDown languageCodeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.EditBox notesEditBox;
        private Janus.Windows.EditControls.UIGroupBox gbBusiness;
        private Janus.Windows.EditControls.UIGroupBox gbParticipant;
        private Janus.Windows.EditControls.UICheckBox isPendingUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isAppellantUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo advisedOfHearingDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo sentNoticeOfHearingDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo notifiedOfAppealDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo certifiedReadyDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo notifiedOfDecisionDateCalendarCombo;
        private System.Windows.Forms.BindingSource contactBindingSource;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditParticipant1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditParticipant;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox4;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
        private Janus.Windows.EditControls.UIButton btnAddAddress;
        private UserControls.ucMultiDropDown ucMultiDDNativeLanguage;
        private Janus.Windows.EditControls.UICheckBox chkInterpreter;
        private System.Windows.Forms.Label NativeLang;
        private System.Windows.Forms.Label notesLabel;
        private System.Windows.Forms.Label contactTypeLabel;
        private Janus.Windows.EditControls.UICheckBox chkNoReassign;
    }
}
