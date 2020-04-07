 namespace LawMate
{
    partial class ucOfficeInfo
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
                FM.LeadOfficeMng.DB.Office.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.DB.Address.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);

                FM.LeadOfficeMng.GetOffice().OnUpdate -= new atLogic.UpdateEventHandler(ucOfficeInfo_OnUpdate);
                FM.GetAddress().OnUpdate -= new atLogic.UpdateEventHandler(ucOfficeInfo_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOfficeInfo));
            System.Windows.Forms.Label officeCodeLabel;
            System.Windows.Forms.Label dARSOfficeCodeLabel;
            System.Windows.Forms.Label officeNameLabel;
            System.Windows.Forms.Label officeNameFreLabel;
            System.Windows.Forms.Label letterSignatoryLabel;
            System.Windows.Forms.Label attentionAdministratorLabel;
            System.Windows.Forms.Label attentionBillingLabel;
            System.Windows.Forms.Label officeTypeCodeLabel;
            System.Windows.Forms.Label reappointedDateLabel;
            System.Windows.Forms.Label appointmentTypeCodeLabel;
            System.Windows.Forms.Label hourlyRateLabel;
            System.Windows.Forms.Label currencyCodeLabel;
            System.Windows.Forms.Label gSTNumberLabel;
            System.Windows.Forms.Label emailAddressLabel;
            System.Windows.Forms.Label homePhoneLabel;
            System.Windows.Forms.Label workPhoneLabel;
            System.Windows.Forms.Label faxNumberLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label officeFriendlyNameEngLabel;
            System.Windows.Forms.Label officeFriendlyNameFreLabel;
            System.Windows.Forms.Label branchIDLabel;
            System.Windows.Forms.Label departmentIDLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.isClientOfficeUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.officeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDB = new lmDatasets.officeDB();
            this.isBranchUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.mccBranch = new LawMate.UserControls.ucMultiDropDown();
            this.mccDepartment = new LawMate.UserControls.ucMultiDropDown();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.gbAppointmentInfo = new Janus.Windows.EditControls.UIGroupBox();
            this.uploadsDisbUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.usesBillingUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.retainerUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isOnLineUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.hourlyRateNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.gSTNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.attentionBillingEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.attentionAdministratorEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ucMultiDropDown4 = new LawMate.UserControls.ucMultiDropDown();
            this.ucMultiDropDown3 = new LawMate.UserControls.ucMultiDropDown();
            this.ucMultiDropDown2 = new LawMate.UserControls.ucMultiDropDown();
            this.reappointedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.mccDefaultTaxRate = new LawMate.UserControls.ucMultiDropDown();
            this.gbAddress = new Janus.Windows.EditControls.UIGroupBox();
            this.editBox3 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.emailAddressEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.workExtensionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox2 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.maskedEditBox3 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.maskedEditBox2 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.maskedEditBox1 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.ucAddress1 = new LawMate.UserControls.ucAddress();
            this.gbOffice = new Janus.Windows.EditControls.UIGroupBox();
            this.activeUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.dARSOfficeCodeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeCodeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeFriendlyNameFreEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeFriendlyNameEngEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.letterSignatoryEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeNameFreEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            officeCodeLabel = new System.Windows.Forms.Label();
            dARSOfficeCodeLabel = new System.Windows.Forms.Label();
            officeNameLabel = new System.Windows.Forms.Label();
            officeNameFreLabel = new System.Windows.Forms.Label();
            letterSignatoryLabel = new System.Windows.Forms.Label();
            attentionAdministratorLabel = new System.Windows.Forms.Label();
            attentionBillingLabel = new System.Windows.Forms.Label();
            officeTypeCodeLabel = new System.Windows.Forms.Label();
            reappointedDateLabel = new System.Windows.Forms.Label();
            appointmentTypeCodeLabel = new System.Windows.Forms.Label();
            hourlyRateLabel = new System.Windows.Forms.Label();
            currencyCodeLabel = new System.Windows.Forms.Label();
            gSTNumberLabel = new System.Windows.Forms.Label();
            emailAddressLabel = new System.Windows.Forms.Label();
            homePhoneLabel = new System.Windows.Forms.Label();
            workPhoneLabel = new System.Windows.Forms.Label();
            faxNumberLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            officeFriendlyNameEngLabel = new System.Windows.Forms.Label();
            officeFriendlyNameFreLabel = new System.Windows.Forms.Label();
            branchIDLabel = new System.Windows.Forms.Label();
            departmentIDLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbAppointmentInfo)).BeginInit();
            this.gbAppointmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbAddress)).BeginInit();
            this.gbAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOffice)).BeginInit();
            this.gbOffice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.officeBindingSource;
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
            this.imageListBase.Images.SetKeyName(18, "audit.gif");
            this.imageListBase.Images.SetKeyName(19, "DRedit.gif");
            // 
            // officeCodeLabel
            // 
            resources.ApplyResources(officeCodeLabel, "officeCodeLabel");
            officeCodeLabel.Name = "officeCodeLabel";
            this.helpProvider1.SetShowHelp(officeCodeLabel, ((bool)(resources.GetObject("officeCodeLabel.ShowHelp"))));
            // 
            // dARSOfficeCodeLabel
            // 
            resources.ApplyResources(dARSOfficeCodeLabel, "dARSOfficeCodeLabel");
            dARSOfficeCodeLabel.Name = "dARSOfficeCodeLabel";
            this.helpProvider1.SetShowHelp(dARSOfficeCodeLabel, ((bool)(resources.GetObject("dARSOfficeCodeLabel.ShowHelp"))));
            // 
            // officeNameLabel
            // 
            resources.ApplyResources(officeNameLabel, "officeNameLabel");
            officeNameLabel.Name = "officeNameLabel";
            this.helpProvider1.SetShowHelp(officeNameLabel, ((bool)(resources.GetObject("officeNameLabel.ShowHelp"))));
            // 
            // officeNameFreLabel
            // 
            resources.ApplyResources(officeNameFreLabel, "officeNameFreLabel");
            officeNameFreLabel.Name = "officeNameFreLabel";
            this.helpProvider1.SetShowHelp(officeNameFreLabel, ((bool)(resources.GetObject("officeNameFreLabel.ShowHelp"))));
            // 
            // letterSignatoryLabel
            // 
            resources.ApplyResources(letterSignatoryLabel, "letterSignatoryLabel");
            letterSignatoryLabel.Name = "letterSignatoryLabel";
            this.helpProvider1.SetShowHelp(letterSignatoryLabel, ((bool)(resources.GetObject("letterSignatoryLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(letterSignatoryLabel, resources.GetString("letterSignatoryLabel.ToolTip"));
            // 
            // attentionAdministratorLabel
            // 
            resources.ApplyResources(attentionAdministratorLabel, "attentionAdministratorLabel");
            attentionAdministratorLabel.Name = "attentionAdministratorLabel";
            this.helpProvider1.SetShowHelp(attentionAdministratorLabel, ((bool)(resources.GetObject("attentionAdministratorLabel.ShowHelp"))));
            // 
            // attentionBillingLabel
            // 
            resources.ApplyResources(attentionBillingLabel, "attentionBillingLabel");
            attentionBillingLabel.Name = "attentionBillingLabel";
            this.helpProvider1.SetShowHelp(attentionBillingLabel, ((bool)(resources.GetObject("attentionBillingLabel.ShowHelp"))));
            // 
            // officeTypeCodeLabel
            // 
            resources.ApplyResources(officeTypeCodeLabel, "officeTypeCodeLabel");
            officeTypeCodeLabel.Name = "officeTypeCodeLabel";
            this.helpProvider1.SetShowHelp(officeTypeCodeLabel, ((bool)(resources.GetObject("officeTypeCodeLabel.ShowHelp"))));
            // 
            // reappointedDateLabel
            // 
            resources.ApplyResources(reappointedDateLabel, "reappointedDateLabel");
            reappointedDateLabel.Name = "reappointedDateLabel";
            this.helpProvider1.SetShowHelp(reappointedDateLabel, ((bool)(resources.GetObject("reappointedDateLabel.ShowHelp"))));
            // 
            // appointmentTypeCodeLabel
            // 
            resources.ApplyResources(appointmentTypeCodeLabel, "appointmentTypeCodeLabel");
            appointmentTypeCodeLabel.Name = "appointmentTypeCodeLabel";
            this.helpProvider1.SetShowHelp(appointmentTypeCodeLabel, ((bool)(resources.GetObject("appointmentTypeCodeLabel.ShowHelp"))));
            // 
            // hourlyRateLabel
            // 
            resources.ApplyResources(hourlyRateLabel, "hourlyRateLabel");
            hourlyRateLabel.Name = "hourlyRateLabel";
            this.helpProvider1.SetShowHelp(hourlyRateLabel, ((bool)(resources.GetObject("hourlyRateLabel.ShowHelp"))));
            // 
            // currencyCodeLabel
            // 
            resources.ApplyResources(currencyCodeLabel, "currencyCodeLabel");
            currencyCodeLabel.Name = "currencyCodeLabel";
            this.helpProvider1.SetShowHelp(currencyCodeLabel, ((bool)(resources.GetObject("currencyCodeLabel.ShowHelp"))));
            // 
            // gSTNumberLabel
            // 
            resources.ApplyResources(gSTNumberLabel, "gSTNumberLabel");
            gSTNumberLabel.Name = "gSTNumberLabel";
            this.helpProvider1.SetShowHelp(gSTNumberLabel, ((bool)(resources.GetObject("gSTNumberLabel.ShowHelp"))));
            // 
            // emailAddressLabel
            // 
            resources.ApplyResources(emailAddressLabel, "emailAddressLabel");
            emailAddressLabel.Name = "emailAddressLabel";
            this.helpProvider1.SetShowHelp(emailAddressLabel, ((bool)(resources.GetObject("emailAddressLabel.ShowHelp"))));
            // 
            // homePhoneLabel
            // 
            resources.ApplyResources(homePhoneLabel, "homePhoneLabel");
            homePhoneLabel.Name = "homePhoneLabel";
            this.helpProvider1.SetShowHelp(homePhoneLabel, ((bool)(resources.GetObject("homePhoneLabel.ShowHelp"))));
            // 
            // workPhoneLabel
            // 
            resources.ApplyResources(workPhoneLabel, "workPhoneLabel");
            workPhoneLabel.Name = "workPhoneLabel";
            this.helpProvider1.SetShowHelp(workPhoneLabel, ((bool)(resources.GetObject("workPhoneLabel.ShowHelp"))));
            // 
            // faxNumberLabel
            // 
            resources.ApplyResources(faxNumberLabel, "faxNumberLabel");
            faxNumberLabel.Name = "faxNumberLabel";
            this.helpProvider1.SetShowHelp(faxNumberLabel, ((bool)(resources.GetObject("faxNumberLabel.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // officeFriendlyNameEngLabel
            // 
            resources.ApplyResources(officeFriendlyNameEngLabel, "officeFriendlyNameEngLabel");
            officeFriendlyNameEngLabel.Name = "officeFriendlyNameEngLabel";
            this.helpProvider1.SetShowHelp(officeFriendlyNameEngLabel, ((bool)(resources.GetObject("officeFriendlyNameEngLabel.ShowHelp"))));
            // 
            // officeFriendlyNameFreLabel
            // 
            resources.ApplyResources(officeFriendlyNameFreLabel, "officeFriendlyNameFreLabel");
            officeFriendlyNameFreLabel.Name = "officeFriendlyNameFreLabel";
            this.helpProvider1.SetShowHelp(officeFriendlyNameFreLabel, ((bool)(resources.GetObject("officeFriendlyNameFreLabel.ShowHelp"))));
            // 
            // branchIDLabel
            // 
            resources.ApplyResources(branchIDLabel, "branchIDLabel");
            branchIDLabel.Name = "branchIDLabel";
            this.helpProvider1.SetShowHelp(branchIDLabel, ((bool)(resources.GetObject("branchIDLabel.ShowHelp"))));
            // 
            // departmentIDLabel
            // 
            resources.ApplyResources(departmentIDLabel, "departmentIDLabel");
            departmentIDLabel.Name = "departmentIDLabel";
            this.helpProvider1.SetShowHelp(departmentIDLabel, ((bool)(resources.GetObject("departmentIDLabel.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            this.helpProvider1.SetShowHelp(label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(738, 750), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
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
            this.pnlAllContainer.Controls.Add(this.uiGroupBox1);
            this.pnlAllContainer.Controls.Add(this.gbAppointmentInfo);
            this.pnlAllContainer.Controls.Add(this.gbAddress);
            this.pnlAllContainer.Controls.Add(this.gbOffice);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(this.isClientOfficeUICheckBox);
            this.uiGroupBox1.Controls.Add(this.isBranchUICheckBox);
            this.uiGroupBox1.Controls.Add(this.mccBranch);
            this.uiGroupBox1.Controls.Add(this.mccDepartment);
            this.uiGroupBox1.Controls.Add(departmentIDLabel);
            this.uiGroupBox1.Controls.Add(branchIDLabel);
            this.uiGroupBox1.Controls.Add(label1);
            this.uiGroupBox1.Controls.Add(this.ucMultiDropDown1);
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.helpProvider1.SetShowHelp(this.uiGroupBox1, ((bool)(resources.GetObject("uiGroupBox1.ShowHelp"))));
            this.uiGroupBox1.UseThemes = false;
            this.uiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // isClientOfficeUICheckBox
            // 
            this.isClientOfficeUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isClientOfficeUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "IsClientOffice", true));
            resources.ApplyResources(this.isClientOfficeUICheckBox, "isClientOfficeUICheckBox");
            this.isClientOfficeUICheckBox.Name = "isClientOfficeUICheckBox";
            this.helpProvider1.SetShowHelp(this.isClientOfficeUICheckBox, ((bool)(resources.GetObject("isClientOfficeUICheckBox.ShowHelp"))));
            this.isClientOfficeUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // officeBindingSource
            // 
            this.officeBindingSource.DataMember = "Office";
            this.officeBindingSource.DataSource = this.officeDB;
            this.officeBindingSource.CurrentChanged += new System.EventHandler(this.officeBindingSource_CurrentChanged);
            // 
            // officeDB
            // 
            this.officeDB.DataSetName = "officeDB";
            this.officeDB.EnforceConstraints = false;
            this.officeDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // isBranchUICheckBox
            // 
            this.isBranchUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isBranchUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "IsBranch", true));
            resources.ApplyResources(this.isBranchUICheckBox, "isBranchUICheckBox");
            this.isBranchUICheckBox.Name = "isBranchUICheckBox";
            this.helpProvider1.SetShowHelp(this.isBranchUICheckBox, ((bool)(resources.GetObject("isBranchUICheckBox.ShowHelp"))));
            this.isBranchUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // mccBranch
            // 
            this.mccBranch.BackColor = System.Drawing.Color.Transparent;
            this.mccBranch.Column1 = "OfficeCode";
            resources.ApplyResources(this.mccBranch, "mccBranch");
            this.mccBranch.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccBranch.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeBindingSource, "BranchID", true));
            this.mccBranch.DataSource = null;
            this.mccBranch.DDColumn1Visible = true;
            this.mccBranch.DropDownColumn1Width = 100;
            this.mccBranch.DropDownColumn2Width = 300;
            this.mccBranch.Name = "mccBranch";
            this.mccBranch.ReadOnly = false;
            this.mccBranch.ReqColor = System.Drawing.SystemColors.Window;
            this.mccBranch.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccBranch, ((bool)(resources.GetObject("mccBranch.ShowHelp"))));
            this.mccBranch.ValueMember = "OfficeId";
            // 
            // mccDepartment
            // 
            this.mccDepartment.BackColor = System.Drawing.Color.Transparent;
            this.mccDepartment.Column1 = "DepartmentCode";
            resources.ApplyResources(this.mccDepartment, "mccDepartment");
            this.mccDepartment.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccDepartment.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeBindingSource, "DepartmentID", true));
            this.mccDepartment.DataSource = null;
            this.mccDepartment.DDColumn1Visible = true;
            this.mccDepartment.DropDownColumn1Width = 100;
            this.mccDepartment.DropDownColumn2Width = 300;
            this.mccDepartment.Name = "mccDepartment";
            this.mccDepartment.ReadOnly = false;
            this.mccDepartment.ReqColor = System.Drawing.SystemColors.Window;
            this.mccDepartment.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccDepartment, ((bool)(resources.GetObject("mccDepartment.ShowHelp"))));
            this.mccDepartment.ValueMember = "DepartmentID";
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown1.Column1 = "OfficeCode";
            resources.ApplyResources(this.ucMultiDropDown1, "ucMultiDropDown1");
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeBindingSource, "ParentOfficeId", true));
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = false;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown1.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown1, ((bool)(resources.GetObject("ucMultiDropDown1.ShowHelp"))));
            this.ucMultiDropDown1.ValueMember = "OfficeId";
            // 
            // gbAppointmentInfo
            // 
            this.gbAppointmentInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbAppointmentInfo.Controls.Add(this.uploadsDisbUICheckBox);
            this.gbAppointmentInfo.Controls.Add(this.usesBillingUICheckBox);
            this.gbAppointmentInfo.Controls.Add(this.retainerUICheckBox);
            this.gbAppointmentInfo.Controls.Add(this.isOnLineUICheckBox);
            this.gbAppointmentInfo.Controls.Add(this.hourlyRateNumericEditBox);
            this.gbAppointmentInfo.Controls.Add(this.gSTNumberEditBox);
            this.gbAppointmentInfo.Controls.Add(this.attentionBillingEditBox);
            this.gbAppointmentInfo.Controls.Add(this.attentionAdministratorEditBox);
            this.gbAppointmentInfo.Controls.Add(this.ucMultiDropDown4);
            this.gbAppointmentInfo.Controls.Add(this.ucMultiDropDown3);
            this.gbAppointmentInfo.Controls.Add(this.ucMultiDropDown2);
            this.gbAppointmentInfo.Controls.Add(gSTNumberLabel);
            this.gbAppointmentInfo.Controls.Add(currencyCodeLabel);
            this.gbAppointmentInfo.Controls.Add(attentionAdministratorLabel);
            this.gbAppointmentInfo.Controls.Add(hourlyRateLabel);
            this.gbAppointmentInfo.Controls.Add(officeTypeCodeLabel);
            this.gbAppointmentInfo.Controls.Add(attentionBillingLabel);
            this.gbAppointmentInfo.Controls.Add(appointmentTypeCodeLabel);
            this.gbAppointmentInfo.Controls.Add(this.reappointedDateCalendarCombo);
            this.gbAppointmentInfo.Controls.Add(reappointedDateLabel);
            this.gbAppointmentInfo.Controls.Add(this.mccDefaultTaxRate);
            this.gbAppointmentInfo.Controls.Add(label5);
            resources.ApplyResources(this.gbAppointmentInfo, "gbAppointmentInfo");
            this.gbAppointmentInfo.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbAppointmentInfo.Name = "gbAppointmentInfo";
            this.helpProvider1.SetShowHelp(this.gbAppointmentInfo, ((bool)(resources.GetObject("gbAppointmentInfo.ShowHelp"))));
            this.gbAppointmentInfo.UseThemes = false;
            this.gbAppointmentInfo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // uploadsDisbUICheckBox
            // 
            this.uploadsDisbUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uploadsDisbUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "UploadsDisb", true));
            resources.ApplyResources(this.uploadsDisbUICheckBox, "uploadsDisbUICheckBox");
            this.uploadsDisbUICheckBox.Name = "uploadsDisbUICheckBox";
            this.helpProvider1.SetShowHelp(this.uploadsDisbUICheckBox, ((bool)(resources.GetObject("uploadsDisbUICheckBox.ShowHelp"))));
            this.uploadsDisbUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // usesBillingUICheckBox
            // 
            this.usesBillingUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usesBillingUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "UsesBilling", true));
            resources.ApplyResources(this.usesBillingUICheckBox, "usesBillingUICheckBox");
            this.usesBillingUICheckBox.Name = "usesBillingUICheckBox";
            this.helpProvider1.SetShowHelp(this.usesBillingUICheckBox, ((bool)(resources.GetObject("usesBillingUICheckBox.ShowHelp"))));
            this.usesBillingUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // retainerUICheckBox
            // 
            this.retainerUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.retainerUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "Retainer", true));
            resources.ApplyResources(this.retainerUICheckBox, "retainerUICheckBox");
            this.retainerUICheckBox.Name = "retainerUICheckBox";
            this.helpProvider1.SetShowHelp(this.retainerUICheckBox, ((bool)(resources.GetObject("retainerUICheckBox.ShowHelp"))));
            this.retainerUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isOnLineUICheckBox
            // 
            this.isOnLineUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isOnLineUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "IsOnLine", true));
            resources.ApplyResources(this.isOnLineUICheckBox, "isOnLineUICheckBox");
            this.isOnLineUICheckBox.Name = "isOnLineUICheckBox";
            this.helpProvider1.SetShowHelp(this.isOnLineUICheckBox, ((bool)(resources.GetObject("isOnLineUICheckBox.ShowHelp"))));
            this.isOnLineUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // hourlyRateNumericEditBox
            // 
            this.hourlyRateNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeBindingSource, "HourlyRate", true));
            this.hourlyRateNumericEditBox.DecimalDigits = 2;
            this.hourlyRateNumericEditBox.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
            this.hourlyRateNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.hourlyRateNumericEditBox, "hourlyRateNumericEditBox");
            this.hourlyRateNumericEditBox.Name = "hourlyRateNumericEditBox";
            this.helpProvider1.SetShowHelp(this.hourlyRateNumericEditBox, ((bool)(resources.GetObject("hourlyRateNumericEditBox.ShowHelp"))));
            this.hourlyRateNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.hourlyRateNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gSTNumberEditBox
            // 
            this.gSTNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "GSTNumber", true));
            resources.ApplyResources(this.gSTNumberEditBox, "gSTNumberEditBox");
            this.gSTNumberEditBox.Name = "gSTNumberEditBox";
            this.helpProvider1.SetShowHelp(this.gSTNumberEditBox, ((bool)(resources.GetObject("gSTNumberEditBox.ShowHelp"))));
            this.gSTNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // attentionBillingEditBox
            // 
            this.attentionBillingEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "AttentionBilling", true));
            resources.ApplyResources(this.attentionBillingEditBox, "attentionBillingEditBox");
            this.attentionBillingEditBox.Name = "attentionBillingEditBox";
            this.helpProvider1.SetShowHelp(this.attentionBillingEditBox, ((bool)(resources.GetObject("attentionBillingEditBox.ShowHelp"))));
            this.attentionBillingEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // attentionAdministratorEditBox
            // 
            this.attentionAdministratorEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "AttentionAdministrator", true));
            resources.ApplyResources(this.attentionAdministratorEditBox, "attentionAdministratorEditBox");
            this.attentionAdministratorEditBox.Name = "attentionAdministratorEditBox";
            this.helpProvider1.SetShowHelp(this.attentionAdministratorEditBox, ((bool)(resources.GetObject("attentionAdministratorEditBox.ShowHelp"))));
            this.attentionAdministratorEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucMultiDropDown4
            // 
            this.ucMultiDropDown4.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown4.Column1 = "CurrencyCode";
            resources.ApplyResources(this.ucMultiDropDown4, "ucMultiDropDown4");
            this.ucMultiDropDown4.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeBindingSource, "CurrencyCode", true));
            this.ucMultiDropDown4.DataSource = null;
            this.ucMultiDropDown4.DDColumn1Visible = true;
            this.ucMultiDropDown4.DropDownColumn1Width = 100;
            this.ucMultiDropDown4.DropDownColumn2Width = 300;
            this.ucMultiDropDown4.Name = "ucMultiDropDown4";
            this.ucMultiDropDown4.ReadOnly = false;
            this.ucMultiDropDown4.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown4.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown4, ((bool)(resources.GetObject("ucMultiDropDown4.ShowHelp"))));
            this.ucMultiDropDown4.ValueMember = "CurrencyCode";
            // 
            // ucMultiDropDown3
            // 
            this.ucMultiDropDown3.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown3.Column1 = "AppointmentTypeCode";
            resources.ApplyResources(this.ucMultiDropDown3, "ucMultiDropDown3");
            this.ucMultiDropDown3.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeBindingSource, "AppointmentTypeCode", true));
            this.ucMultiDropDown3.DataSource = null;
            this.ucMultiDropDown3.DDColumn1Visible = true;
            this.ucMultiDropDown3.DropDownColumn1Width = 100;
            this.ucMultiDropDown3.DropDownColumn2Width = 300;
            this.ucMultiDropDown3.Name = "ucMultiDropDown3";
            this.ucMultiDropDown3.ReadOnly = false;
            this.ucMultiDropDown3.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown3.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown3, ((bool)(resources.GetObject("ucMultiDropDown3.ShowHelp"))));
            this.ucMultiDropDown3.ValueMember = "AppointmentTypeCode";
            // 
            // ucMultiDropDown2
            // 
            this.ucMultiDropDown2.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown2.Column1 = "OfficeTypeCode";
            resources.ApplyResources(this.ucMultiDropDown2, "ucMultiDropDown2");
            this.ucMultiDropDown2.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeBindingSource, "OfficeTypeCode", true));
            this.ucMultiDropDown2.DataSource = null;
            this.ucMultiDropDown2.DDColumn1Visible = true;
            this.ucMultiDropDown2.DropDownColumn1Width = 100;
            this.ucMultiDropDown2.DropDownColumn2Width = 300;
            this.ucMultiDropDown2.Name = "ucMultiDropDown2";
            this.ucMultiDropDown2.ReadOnly = false;
            this.ucMultiDropDown2.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown2.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown2, ((bool)(resources.GetObject("ucMultiDropDown2.ShowHelp"))));
            this.ucMultiDropDown2.ValueMember = "OfficeTypeCode";
            // 
            // reappointedDateCalendarCombo
            // 
            resources.ApplyResources(this.reappointedDateCalendarCombo, "reappointedDateCalendarCombo");
            this.reappointedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "ReappointedDate", true));
            this.reappointedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.reappointedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.reappointedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.reappointedDateCalendarCombo.MonthIncrement = 0;
            this.reappointedDateCalendarCombo.Name = "reappointedDateCalendarCombo";
            this.reappointedDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.reappointedDateCalendarCombo, ((bool)(resources.GetObject("reappointedDateCalendarCombo.ShowHelp"))));
            this.reappointedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.reappointedDateCalendarCombo.YearIncrement = 0;
            // 
            // mccDefaultTaxRate
            // 
            this.mccDefaultTaxRate.BackColor = System.Drawing.Color.Transparent;
            this.mccDefaultTaxRate.Column1 = "TaxRateId";
            resources.ApplyResources(this.mccDefaultTaxRate, "mccDefaultTaxRate");
            this.mccDefaultTaxRate.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.mccDefaultTaxRate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeBindingSource, "DefaultTaxRate", true));
            this.mccDefaultTaxRate.DataSource = null;
            this.mccDefaultTaxRate.DDColumn1Visible = false;
            this.mccDefaultTaxRate.DropDownColumn1Width = 100;
            this.mccDefaultTaxRate.DropDownColumn2Width = 109;
            this.mccDefaultTaxRate.Name = "mccDefaultTaxRate";
            this.mccDefaultTaxRate.ReadOnly = false;
            this.mccDefaultTaxRate.ReqColor = System.Drawing.SystemColors.Window;
            this.mccDefaultTaxRate.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccDefaultTaxRate, ((bool)(resources.GetObject("mccDefaultTaxRate.ShowHelp"))));
            this.mccDefaultTaxRate.ValueMember = "TaxRateId";
            // 
            // gbAddress
            // 
            this.gbAddress.BackColor = System.Drawing.Color.Transparent;
            this.gbAddress.Controls.Add(this.editBox3);
            this.gbAddress.Controls.Add(this.emailAddressEditBox);
            this.gbAddress.Controls.Add(label4);
            this.gbAddress.Controls.Add(this.workExtensionEditBox);
            this.gbAddress.Controls.Add(this.editBox2);
            this.gbAddress.Controls.Add(label3);
            this.gbAddress.Controls.Add(this.maskedEditBox3);
            this.gbAddress.Controls.Add(this.editBox1);
            this.gbAddress.Controls.Add(this.maskedEditBox2);
            this.gbAddress.Controls.Add(label2);
            this.gbAddress.Controls.Add(this.maskedEditBox1);
            this.gbAddress.Controls.Add(this.ucAddress1);
            this.gbAddress.Controls.Add(faxNumberLabel);
            this.gbAddress.Controls.Add(workPhoneLabel);
            this.gbAddress.Controls.Add(homePhoneLabel);
            this.gbAddress.Controls.Add(emailAddressLabel);
            resources.ApplyResources(this.gbAddress, "gbAddress");
            this.gbAddress.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbAddress.Name = "gbAddress";
            this.helpProvider1.SetShowHelp(this.gbAddress, ((bool)(resources.GetObject("gbAddress.ShowHelp"))));
            this.gbAddress.UseThemes = false;
            this.gbAddress.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // editBox3
            // 
            this.editBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "Address2Fre", true));
            resources.ApplyResources(this.editBox3, "editBox3");
            this.editBox3.Name = "editBox3";
            this.helpProvider1.SetShowHelp(this.editBox3, ((bool)(resources.GetObject("editBox3.ShowHelp"))));
            this.editBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // addressBindingSource
            // 
            this.addressBindingSource.DataMember = "Address";
            this.addressBindingSource.DataSource = this.atriumDB;
            this.addressBindingSource.CurrentChanged += new System.EventHandler(this.addressBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // emailAddressEditBox
            // 
            this.emailAddressEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "EmailAddress", true));
            resources.ApplyResources(this.emailAddressEditBox, "emailAddressEditBox");
            this.emailAddressEditBox.Name = "emailAddressEditBox";
            this.helpProvider1.SetShowHelp(this.emailAddressEditBox, ((bool)(resources.GetObject("emailAddressEditBox.ShowHelp"))));
            this.emailAddressEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // workExtensionEditBox
            // 
            this.workExtensionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "WorkExtension", true));
            resources.ApplyResources(this.workExtensionEditBox, "workExtensionEditBox");
            this.workExtensionEditBox.Name = "workExtensionEditBox";
            this.helpProvider1.SetShowHelp(this.workExtensionEditBox, ((bool)(resources.GetObject("workExtensionEditBox.ShowHelp"))));
            this.workExtensionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox2
            // 
            this.editBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "Address1Fre", true));
            resources.ApplyResources(this.editBox2, "editBox2");
            this.editBox2.Name = "editBox2";
            this.helpProvider1.SetShowHelp(this.editBox2, ((bool)(resources.GetObject("editBox2.ShowHelp"))));
            this.editBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // maskedEditBox3
            // 
            this.maskedEditBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "FaxNumber", true));
            resources.ApplyResources(this.maskedEditBox3, "maskedEditBox3");
            this.maskedEditBox3.Mask = "(###) ###-####";
            this.maskedEditBox3.Name = "maskedEditBox3";
            this.helpProvider1.SetShowHelp(this.maskedEditBox3, ((bool)(resources.GetObject("maskedEditBox3.ShowHelp"))));
            this.maskedEditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox1
            // 
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "Address3Fre", true));
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.Name = "editBox1";
            this.helpProvider1.SetShowHelp(this.editBox1, ((bool)(resources.GetObject("editBox1.ShowHelp"))));
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // maskedEditBox2
            // 
            this.maskedEditBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "HomePhone", true));
            resources.ApplyResources(this.maskedEditBox2, "maskedEditBox2");
            this.maskedEditBox2.Mask = "(###) ###-####";
            this.maskedEditBox2.Name = "maskedEditBox2";
            this.helpProvider1.SetShowHelp(this.maskedEditBox2, ((bool)(resources.GetObject("maskedEditBox2.ShowHelp"))));
            this.maskedEditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // maskedEditBox1
            // 
            this.maskedEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "WorkPhone", true));
            resources.ApplyResources(this.maskedEditBox1, "maskedEditBox1");
            this.maskedEditBox1.Mask = "(###) ###-####";
            this.maskedEditBox1.Name = "maskedEditBox1";
            this.helpProvider1.SetShowHelp(this.maskedEditBox1, ((bool)(resources.GetObject("maskedEditBox1.ShowHelp"))));
            this.maskedEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucAddress1
            // 
            this.ucAddress1.BackColor = System.Drawing.Color.Transparent;
            this.ucAddress1.ColumnTwoLeftPositionOffset = 0;
            this.ucAddress1.FM = null;
            resources.ApplyResources(this.ucAddress1, "ucAddress1");
            this.ucAddress1.IsReadOnly = false;
            this.ucAddress1.Name = "ucAddress1";
            this.ucAddress1.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucAddress1, ((bool)(resources.GetObject("ucAddress1.ShowHelp"))));
            // 
            // gbOffice
            // 
            this.gbOffice.BackColor = System.Drawing.Color.Transparent;
            this.gbOffice.Controls.Add(this.activeUICheckBox);
            this.gbOffice.Controls.Add(this.dARSOfficeCodeEditBox);
            this.gbOffice.Controls.Add(this.officeCodeEditBox);
            this.gbOffice.Controls.Add(this.officeFriendlyNameFreEditBox);
            this.gbOffice.Controls.Add(this.officeFriendlyNameEngEditBox);
            this.gbOffice.Controls.Add(this.letterSignatoryEditBox);
            this.gbOffice.Controls.Add(this.officeNameFreEditBox);
            this.gbOffice.Controls.Add(this.officeNameEditBox);
            this.gbOffice.Controls.Add(officeFriendlyNameFreLabel);
            this.gbOffice.Controls.Add(officeFriendlyNameEngLabel);
            this.gbOffice.Controls.Add(officeNameLabel);
            this.gbOffice.Controls.Add(officeNameFreLabel);
            this.gbOffice.Controls.Add(dARSOfficeCodeLabel);
            this.gbOffice.Controls.Add(officeCodeLabel);
            this.gbOffice.Controls.Add(letterSignatoryLabel);
            resources.ApplyResources(this.gbOffice, "gbOffice");
            this.gbOffice.FormatStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gbOffice.Name = "gbOffice";
            this.helpProvider1.SetShowHelp(this.gbOffice, ((bool)(resources.GetObject("gbOffice.ShowHelp"))));
            this.gbOffice.UseThemes = false;
            this.gbOffice.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // activeUICheckBox
            // 
            this.activeUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.activeUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeBindingSource, "Active", true));
            resources.ApplyResources(this.activeUICheckBox, "activeUICheckBox");
            this.activeUICheckBox.Name = "activeUICheckBox";
            this.helpProvider1.SetShowHelp(this.activeUICheckBox, ((bool)(resources.GetObject("activeUICheckBox.ShowHelp"))));
            this.activeUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // dARSOfficeCodeEditBox
            // 
            this.dARSOfficeCodeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "DARSOfficeCode", true));
            resources.ApplyResources(this.dARSOfficeCodeEditBox, "dARSOfficeCodeEditBox");
            this.dARSOfficeCodeEditBox.Name = "dARSOfficeCodeEditBox";
            this.helpProvider1.SetShowHelp(this.dARSOfficeCodeEditBox, ((bool)(resources.GetObject("dARSOfficeCodeEditBox.ShowHelp"))));
            this.dARSOfficeCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeCodeEditBox
            // 
            this.officeCodeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "OfficeCode", true));
            resources.ApplyResources(this.officeCodeEditBox, "officeCodeEditBox");
            this.officeCodeEditBox.Name = "officeCodeEditBox";
            this.helpProvider1.SetShowHelp(this.officeCodeEditBox, ((bool)(resources.GetObject("officeCodeEditBox.ShowHelp"))));
            this.officeCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeFriendlyNameFreEditBox
            // 
            this.officeFriendlyNameFreEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "OfficeFriendlyNameFre", true));
            resources.ApplyResources(this.officeFriendlyNameFreEditBox, "officeFriendlyNameFreEditBox");
            this.officeFriendlyNameFreEditBox.Name = "officeFriendlyNameFreEditBox";
            this.helpProvider1.SetShowHelp(this.officeFriendlyNameFreEditBox, ((bool)(resources.GetObject("officeFriendlyNameFreEditBox.ShowHelp"))));
            this.officeFriendlyNameFreEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeFriendlyNameEngEditBox
            // 
            this.officeFriendlyNameEngEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "OfficeFriendlyNameEng", true));
            resources.ApplyResources(this.officeFriendlyNameEngEditBox, "officeFriendlyNameEngEditBox");
            this.officeFriendlyNameEngEditBox.Name = "officeFriendlyNameEngEditBox";
            this.helpProvider1.SetShowHelp(this.officeFriendlyNameEngEditBox, ((bool)(resources.GetObject("officeFriendlyNameEngEditBox.ShowHelp"))));
            this.officeFriendlyNameEngEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // letterSignatoryEditBox
            // 
            this.letterSignatoryEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "LetterSignatory", true));
            resources.ApplyResources(this.letterSignatoryEditBox, "letterSignatoryEditBox");
            this.letterSignatoryEditBox.Name = "letterSignatoryEditBox";
            this.helpProvider1.SetShowHelp(this.letterSignatoryEditBox, ((bool)(resources.GetObject("letterSignatoryEditBox.ShowHelp"))));
            this.letterSignatoryEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeNameFreEditBox
            // 
            this.officeNameFreEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "OfficeNameFre", true));
            resources.ApplyResources(this.officeNameFreEditBox, "officeNameFreEditBox");
            this.officeNameFreEditBox.Name = "officeNameFreEditBox";
            this.helpProvider1.SetShowHelp(this.officeNameFreEditBox, ((bool)(resources.GetObject("officeNameFreEditBox.ShowHelp"))));
            this.officeNameFreEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeNameEditBox
            // 
            this.officeNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeBindingSource, "OfficeName", true));
            resources.ApplyResources(this.officeNameEditBox, "officeNameEditBox");
            this.officeNameEditBox.Name = "officeNameEditBox";
            this.helpProvider1.SetShowHelp(this.officeNameEditBox, ((bool)(resources.GetObject("officeNameEditBox.ShowHelp"))));
            this.officeNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
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
            this.tsAudit,
            this.tsEditmode,
            this.cmdFile,
            this.cmdEdit});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("e84fd5d2-99ef-4b3d-be32-c13755915580");
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
            this.cmdEdit1});
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
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave1,
            this.tsDelete1,
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
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsEditmode
            // 
            this.tsEditmode.Alignment = Janus.Windows.UI.CommandBars.CommandAlignment.Near;
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
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
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.addressBindingSource;
            // 
            // ucOfficeInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucOfficeInfo";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucOfficeInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbAppointmentInfo)).EndInit();
            this.gbAppointmentInfo.ResumeLayout(false);
            this.gbAppointmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbAddress)).EndInit();
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOffice)).EndInit();
            this.gbOffice.ResumeLayout(false);
            this.gbOffice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private System.Windows.Forms.BindingSource officeBindingSource;
        private lmDatasets.officeDB officeDB;
        private Janus.Windows.CalendarCombo.CalendarCombo reappointedDateCalendarCombo;
        private Janus.Windows.EditControls.UIGroupBox gbAppointmentInfo;
        private Janus.Windows.EditControls.UIGroupBox gbAddress;
        private Janus.Windows.EditControls.UIGroupBox gbOffice;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private UserControls.ucAddress ucAddress1;
        private UserControls.ucMultiDropDown ucMultiDropDown1;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox3;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox2;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox1;
        private UserControls.ucMultiDropDown ucMultiDropDown2;
        private UserControls.ucMultiDropDown ucMultiDropDown4;
        private UserControls.ucMultiDropDown ucMultiDropDown3;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private UserControls.ucMultiDropDown mccDepartment;
        private UserControls.ucMultiDropDown mccBranch;
        private Janus.Windows.EditControls.UICheckBox isClientOfficeUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isBranchUICheckBox;
        private Janus.Windows.EditControls.UICheckBox uploadsDisbUICheckBox;
        private Janus.Windows.EditControls.UICheckBox usesBillingUICheckBox;
        private Janus.Windows.EditControls.UICheckBox retainerUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isOnLineUICheckBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox hourlyRateNumericEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox gSTNumberEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox attentionBillingEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox attentionAdministratorEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox emailAddressEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox workExtensionEditBox;
        private Janus.Windows.EditControls.UICheckBox activeUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox dARSOfficeCodeEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox officeCodeEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox officeFriendlyNameFreEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox officeFriendlyNameEngEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox letterSignatoryEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox officeNameFreEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox officeNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox editBox3;
        private Janus.Windows.GridEX.EditControls.EditBox editBox2;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private UserControls.ucMultiDropDown mccDefaultTaxRate;
    }
}
