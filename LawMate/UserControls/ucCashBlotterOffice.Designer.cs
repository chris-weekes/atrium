 namespace LawMate
{
    partial class ucCashBlotterOffice
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
                FM.GetCLASMng().DB.CBDetail.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(cbDetailDt_ColumnChanged);

                FM.GetCLASMng().GetCashBlotter().OnUpdate -= new atLogic.UpdateEventHandler(ucCashBlotterOffice_OnUpdate);
                FM.GetCLASMng().GetCBDetail().OnUpdate -= new atLogic.UpdateEventHandler(ucCashBlotterOffice_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCashBlotterOffice));
            System.Windows.Forms.Label remittedDateLabel;
            System.Windows.Forms.Label secondOfficerCodeLabel;
            System.Windows.Forms.Label firstOfficerCodeLabel;
            System.Windows.Forms.Label cashBlotterIDLabel;
            System.Windows.Forms.Label receivedDateLabel;
            System.Windows.Forms.Label paymentSourceLabel;
            System.Windows.Forms.Label valuableTypeLabel;
            System.Windows.Forms.Label valuableAmountLabel;
            System.Windows.Forms.Label valuableDateLabel;
            System.Windows.Forms.Label natureOfPaymentLabel;
            System.Windows.Forms.Label statusCodeLabel;
            System.Windows.Forms.Label currencyCodeLabel;
            System.Windows.Forms.Label officeIDLabel;
            System.Windows.Forms.Label commentsLabel;
            System.Windows.Forms.Label sINLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            Janus.Windows.GridEX.GridEXLayout cashBlotterGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cBDetailGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucContactSelectBox2 = new LawMate.ucContactSelectBox();
            this.cashBlotterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CLAS = new lmDatasets.CLAS();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.btnGoTo = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsActions2 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsActions1 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdProcessCB1 = new Janus.Windows.UI.CommandBars.UICommand("cmdProcessCB");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsPrintCB1 = new Janus.Windows.UI.CommandBars.UICommand("tsPrintCB");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsProcessFirst = new Janus.Windows.UI.CommandBars.UICommand("tsProcessFirst");
            this.tsProcessSecond = new Janus.Windows.UI.CommandBars.UICommand("tsProcessSecond");
            this.tsPrintCB = new Janus.Windows.UI.CommandBars.UICommand("tsPrintCB");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdProcessCB2 = new Janus.Windows.UI.CommandBars.UICommand("cmdProcessCB");
            this.tsPrintCB2 = new Janus.Windows.UI.CommandBars.UICommand("tsPrintCB");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdProcessCB = new Janus.Windows.UI.CommandBars.UICommand("cmdProcessCB");
            this.tsProcessFirst1 = new Janus.Windows.UI.CommandBars.UICommand("tsProcessFirst");
            this.tsProcessSecond1 = new Janus.Windows.UI.CommandBars.UICommand("tsProcessSecond");
            this.cmdGoToActivity = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToActivity");
            this.cmdGoToCB = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToCB");
            this.cmdGoToGeneralFile = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToGeneralFile");
            this.tsActions = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdGoToActivity1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToActivity");
            this.cmdGoToCB1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToCB");
            this.cmdGoToGeneralFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToGeneralFile");
            this.commentsEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cBDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentSourceComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.valuableAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.natureOfPaymentComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.statusCodeComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.lastNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.firstNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.mccOfficeCode = new LawMate.UserControls.ucMultiDropDown();
            this.valuableDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.currencyCodeComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.valuableTypeComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.receivedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sINMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.ucContactSelectBox1 = new LawMate.ucContactSelectBox();
            this.cashBlotterGridEX = new Janus.Windows.GridEX.GridEX();
            this.cashBlotterIDEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.remittedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cBDetailGridEX = new Janus.Windows.GridEX.GridEX();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            remittedDateLabel = new System.Windows.Forms.Label();
            secondOfficerCodeLabel = new System.Windows.Forms.Label();
            firstOfficerCodeLabel = new System.Windows.Forms.Label();
            cashBlotterIDLabel = new System.Windows.Forms.Label();
            receivedDateLabel = new System.Windows.Forms.Label();
            paymentSourceLabel = new System.Windows.Forms.Label();
            valuableTypeLabel = new System.Windows.Forms.Label();
            valuableAmountLabel = new System.Windows.Forms.Label();
            valuableDateLabel = new System.Windows.Forms.Label();
            natureOfPaymentLabel = new System.Windows.Forms.Label();
            statusCodeLabel = new System.Windows.Forms.Label();
            currencyCodeLabel = new System.Windows.Forms.Label();
            officeIDLabel = new System.Windows.Forms.Label();
            commentsLabel = new System.Windows.Forms.Label();
            sINLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashBlotterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashBlotterGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.cBDetailBindingSource;
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
            this.imageListBase.Images.SetKeyName(20, "gear-icon.gif");
            this.imageListBase.Images.SetKeyName(21, "cbProcess.gif");
            this.imageListBase.Images.SetKeyName(22, "print_icon.gif");
            // 
            // remittedDateLabel
            // 
            resources.ApplyResources(remittedDateLabel, "remittedDateLabel");
            remittedDateLabel.BackColor = System.Drawing.Color.Transparent;
            remittedDateLabel.Name = "remittedDateLabel";
            this.helpProvider1.SetShowHelp(remittedDateLabel, ((bool)(resources.GetObject("remittedDateLabel.ShowHelp"))));
            // 
            // secondOfficerCodeLabel
            // 
            resources.ApplyResources(secondOfficerCodeLabel, "secondOfficerCodeLabel");
            secondOfficerCodeLabel.BackColor = System.Drawing.Color.Transparent;
            secondOfficerCodeLabel.Name = "secondOfficerCodeLabel";
            this.helpProvider1.SetShowHelp(secondOfficerCodeLabel, ((bool)(resources.GetObject("secondOfficerCodeLabel.ShowHelp"))));
            // 
            // firstOfficerCodeLabel
            // 
            resources.ApplyResources(firstOfficerCodeLabel, "firstOfficerCodeLabel");
            firstOfficerCodeLabel.BackColor = System.Drawing.Color.Transparent;
            firstOfficerCodeLabel.Name = "firstOfficerCodeLabel";
            this.helpProvider1.SetShowHelp(firstOfficerCodeLabel, ((bool)(resources.GetObject("firstOfficerCodeLabel.ShowHelp"))));
            // 
            // cashBlotterIDLabel
            // 
            resources.ApplyResources(cashBlotterIDLabel, "cashBlotterIDLabel");
            cashBlotterIDLabel.BackColor = System.Drawing.Color.Transparent;
            cashBlotterIDLabel.Name = "cashBlotterIDLabel";
            this.helpProvider1.SetShowHelp(cashBlotterIDLabel, ((bool)(resources.GetObject("cashBlotterIDLabel.ShowHelp"))));
            // 
            // receivedDateLabel
            // 
            resources.ApplyResources(receivedDateLabel, "receivedDateLabel");
            receivedDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedDateLabel.Name = "receivedDateLabel";
            this.helpProvider1.SetShowHelp(receivedDateLabel, ((bool)(resources.GetObject("receivedDateLabel.ShowHelp"))));
            // 
            // paymentSourceLabel
            // 
            resources.ApplyResources(paymentSourceLabel, "paymentSourceLabel");
            paymentSourceLabel.BackColor = System.Drawing.Color.Transparent;
            paymentSourceLabel.Name = "paymentSourceLabel";
            this.helpProvider1.SetShowHelp(paymentSourceLabel, ((bool)(resources.GetObject("paymentSourceLabel.ShowHelp"))));
            // 
            // valuableTypeLabel
            // 
            resources.ApplyResources(valuableTypeLabel, "valuableTypeLabel");
            valuableTypeLabel.BackColor = System.Drawing.Color.Transparent;
            valuableTypeLabel.Name = "valuableTypeLabel";
            this.helpProvider1.SetShowHelp(valuableTypeLabel, ((bool)(resources.GetObject("valuableTypeLabel.ShowHelp"))));
            // 
            // valuableAmountLabel
            // 
            resources.ApplyResources(valuableAmountLabel, "valuableAmountLabel");
            valuableAmountLabel.BackColor = System.Drawing.Color.Transparent;
            valuableAmountLabel.Name = "valuableAmountLabel";
            this.helpProvider1.SetShowHelp(valuableAmountLabel, ((bool)(resources.GetObject("valuableAmountLabel.ShowHelp"))));
            // 
            // valuableDateLabel
            // 
            resources.ApplyResources(valuableDateLabel, "valuableDateLabel");
            valuableDateLabel.BackColor = System.Drawing.Color.Transparent;
            valuableDateLabel.Name = "valuableDateLabel";
            this.helpProvider1.SetShowHelp(valuableDateLabel, ((bool)(resources.GetObject("valuableDateLabel.ShowHelp"))));
            // 
            // natureOfPaymentLabel
            // 
            resources.ApplyResources(natureOfPaymentLabel, "natureOfPaymentLabel");
            natureOfPaymentLabel.BackColor = System.Drawing.Color.Transparent;
            natureOfPaymentLabel.Name = "natureOfPaymentLabel";
            this.helpProvider1.SetShowHelp(natureOfPaymentLabel, ((bool)(resources.GetObject("natureOfPaymentLabel.ShowHelp"))));
            // 
            // statusCodeLabel
            // 
            resources.ApplyResources(statusCodeLabel, "statusCodeLabel");
            statusCodeLabel.BackColor = System.Drawing.Color.Transparent;
            statusCodeLabel.Name = "statusCodeLabel";
            this.helpProvider1.SetShowHelp(statusCodeLabel, ((bool)(resources.GetObject("statusCodeLabel.ShowHelp"))));
            // 
            // currencyCodeLabel
            // 
            resources.ApplyResources(currencyCodeLabel, "currencyCodeLabel");
            currencyCodeLabel.BackColor = System.Drawing.Color.Transparent;
            currencyCodeLabel.Name = "currencyCodeLabel";
            this.helpProvider1.SetShowHelp(currencyCodeLabel, ((bool)(resources.GetObject("currencyCodeLabel.ShowHelp"))));
            // 
            // officeIDLabel
            // 
            resources.ApplyResources(officeIDLabel, "officeIDLabel");
            officeIDLabel.BackColor = System.Drawing.Color.Transparent;
            officeIDLabel.Name = "officeIDLabel";
            this.helpProvider1.SetShowHelp(officeIDLabel, ((bool)(resources.GetObject("officeIDLabel.ShowHelp"))));
            // 
            // commentsLabel
            // 
            resources.ApplyResources(commentsLabel, "commentsLabel");
            commentsLabel.BackColor = System.Drawing.Color.Transparent;
            commentsLabel.Name = "commentsLabel";
            this.helpProvider1.SetShowHelp(commentsLabel, ((bool)(resources.GetObject("commentsLabel.ShowHelp"))));
            // 
            // sINLabel
            // 
            resources.ApplyResources(sINLabel, "sINLabel");
            sINLabel.BackColor = System.Drawing.Color.Transparent;
            sINLabel.Name = "sINLabel";
            this.helpProvider1.SetShowHelp(sINLabel, ((bool)(resources.GetObject("sINLabel.ShowHelp"))));
            // 
            // firstNameLabel
            // 
            resources.ApplyResources(firstNameLabel, "firstNameLabel");
            firstNameLabel.BackColor = System.Drawing.Color.Transparent;
            firstNameLabel.Name = "firstNameLabel";
            this.helpProvider1.SetShowHelp(firstNameLabel, ((bool)(resources.GetObject("firstNameLabel.ShowHelp"))));
            // 
            // lastNameLabel
            // 
            resources.ApplyResources(lastNameLabel, "lastNameLabel");
            lastNameLabel.BackColor = System.Drawing.Color.Transparent;
            lastNameLabel.Name = "lastNameLabel";
            this.helpProvider1.SetShowHelp(lastNameLabel, ((bool)(resources.GetObject("lastNameLabel.ShowHelp"))));
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(772, 430), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.ucContactSelectBox2);
            this.pnlAllContainer.Controls.Add(this.uiTab1);
            this.pnlAllContainer.Controls.Add(this.ucContactSelectBox1);
            this.pnlAllContainer.Controls.Add(this.cashBlotterGridEX);
            this.pnlAllContainer.Controls.Add(cashBlotterIDLabel);
            this.pnlAllContainer.Controls.Add(this.cashBlotterIDEditBox);
            this.pnlAllContainer.Controls.Add(this.remittedDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(this.cBDetailGridEX);
            this.pnlAllContainer.Controls.Add(remittedDateLabel);
            this.pnlAllContainer.Controls.Add(secondOfficerCodeLabel);
            this.pnlAllContainer.Controls.Add(firstOfficerCodeLabel);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // ucContactSelectBox2
            // 
            this.ucContactSelectBox2.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox2.ContactId = null;
            this.ucContactSelectBox2.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.cashBlotterBindingSource, "SecondConfirm", true));
            this.ucContactSelectBox2.FM = null;
            resources.ApplyResources(this.ucContactSelectBox2, "ucContactSelectBox2");
            this.ucContactSelectBox2.Name = "ucContactSelectBox2";
            this.ucContactSelectBox2.ReadOnly = true;
            this.ucContactSelectBox2.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucContactSelectBox2, ((bool)(resources.GetObject("ucContactSelectBox2.ShowHelp"))));
            this.ucContactSelectBox2.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // cashBlotterBindingSource
            // 
            this.cashBlotterBindingSource.DataMember = "CashBlotter";
            this.cashBlotterBindingSource.DataSource = this.CLAS;
            this.cashBlotterBindingSource.CurrentChanged += new System.EventHandler(this.cashBlotterBindingSource_CurrentChanged);
            // 
            // CLAS
            // 
            this.CLAS.DataSetName = "CLAS";
            this.CLAS.EnforceConstraints = false;
            this.CLAS.Locale = new System.Globalization.CultureInfo("en-CA");
            this.CLAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // uiTab1
            // 
            resources.ApplyResources(this.uiTab1, "uiTab1");
            this.uiTab1.BackColor = System.Drawing.Color.Transparent;
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab1.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab1, ((bool)(resources.GetObject("uiTab1.ShowHelp"))));
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab1.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab1.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.btnGoTo);
            this.uiTabPage1.Controls.Add(this.commentsEditBox);
            this.uiTabPage1.Controls.Add(sINLabel);
            this.uiTabPage1.Controls.Add(this.paymentSourceComboBox);
            this.uiTabPage1.Controls.Add(this.valuableAmountNumericEditBox);
            this.uiTabPage1.Controls.Add(this.natureOfPaymentComboBox);
            this.uiTabPage1.Controls.Add(lastNameLabel);
            this.uiTabPage1.Controls.Add(this.statusCodeComboBox);
            this.uiTabPage1.Controls.Add(paymentSourceLabel);
            this.uiTabPage1.Controls.Add(this.lastNameEditBox);
            this.uiTabPage1.Controls.Add(natureOfPaymentLabel);
            this.uiTabPage1.Controls.Add(firstNameLabel);
            this.uiTabPage1.Controls.Add(statusCodeLabel);
            this.uiTabPage1.Controls.Add(this.firstNameEditBox);
            this.uiTabPage1.Controls.Add(commentsLabel);
            this.uiTabPage1.Controls.Add(officeIDLabel);
            this.uiTabPage1.Controls.Add(this.mccOfficeCode);
            this.uiTabPage1.Controls.Add(currencyCodeLabel);
            this.uiTabPage1.Controls.Add(this.valuableDateCalendarCombo);
            this.uiTabPage1.Controls.Add(valuableDateLabel);
            this.uiTabPage1.Controls.Add(valuableAmountLabel);
            this.uiTabPage1.Controls.Add(this.currencyCodeComboBox);
            this.uiTabPage1.Controls.Add(valuableTypeLabel);
            this.uiTabPage1.Controls.Add(this.valuableTypeComboBox);
            this.uiTabPage1.Controls.Add(this.receivedDateCalendarCombo);
            this.uiTabPage1.Controls.Add(this.sINMaskedEditBox);
            this.uiTabPage1.Controls.Add(receivedDateLabel);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // btnGoTo
            // 
            this.btnGoTo.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.btnGoTo.DropDownContextMenu = this.uiContextMenu1;
            this.btnGoTo.Image = global::LawMate.Properties.Resources.folder;
            resources.ApplyResources(this.btnGoTo, "btnGoTo");
            this.btnGoTo.Name = "btnGoTo";
            this.helpProvider1.SetShowHelp(this.btnGoTo, ((bool)(resources.GetObject("btnGoTo.ShowHelp"))));
            this.btnGoTo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdGoToActivity1,
            this.cmdGoToCB1,
            this.cmdGoToGeneralFile1});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiContextMenu1.Popup += new System.EventHandler(this.uiContextMenu1_Popup);
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
            this.tsProcessFirst,
            this.tsProcessSecond,
            this.tsPrintCB,
            this.cmdFile,
            this.cmdEdit,
            this.cmdProcessCB,
            this.cmdGoToActivity,
            this.cmdGoToCB,
            this.cmdGoToGeneralFile,
            this.tsActions});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("c71fcc3c-e6b2-4a9d-ac6b-23856a47202e");
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
            this.tsActions2});
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
            // tsActions2
            // 
            resources.ApplyResources(this.tsActions2, "tsActions2");
            this.tsActions2.Name = "tsActions2";
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsActions1,
            this.tsSave1,
            this.tsDelete1,
            this.Separator2,
            this.cmdProcessCB1,
            this.Separator4,
            this.tsPrintCB1,
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
            // tsActions1
            // 
            resources.ApplyResources(this.tsActions1, "tsActions1");
            this.tsActions1.Name = "tsActions1";
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
            // cmdProcessCB1
            // 
            resources.ApplyResources(this.cmdProcessCB1, "cmdProcessCB1");
            this.cmdProcessCB1.Name = "cmdProcessCB1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsPrintCB1
            // 
            resources.ApplyResources(this.tsPrintCB1, "tsPrintCB1");
            this.tsPrintCB1.Name = "tsPrintCB1";
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
            this.tsEditmode.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // tsAudit
            // 
            this.tsAudit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsProcessFirst
            // 
            this.tsProcessFirst.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsProcessFirst, "tsProcessFirst");
            this.tsProcessFirst.Name = "tsProcessFirst";
            // 
            // tsProcessSecond
            // 
            this.tsProcessSecond.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsProcessSecond.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.tsProcessSecond, "tsProcessSecond");
            this.tsProcessSecond.Name = "tsProcessSecond";
            // 
            // tsPrintCB
            // 
            resources.ApplyResources(this.tsPrintCB, "tsPrintCB");
            this.tsPrintCB.Name = "tsPrintCB";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave2,
            this.cmdProcessCB2,
            this.tsPrintCB2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // cmdProcessCB2
            // 
            resources.ApplyResources(this.cmdProcessCB2, "cmdProcessCB2");
            this.cmdProcessCB2.Name = "cmdProcessCB2";
            // 
            // tsPrintCB2
            // 
            resources.ApplyResources(this.tsPrintCB2, "tsPrintCB2");
            this.tsPrintCB2.Name = "tsPrintCB2";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete2});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // cmdProcessCB
            // 
            this.cmdProcessCB.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsProcessFirst1,
            this.tsProcessSecond1});
            this.cmdProcessCB.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdProcessCB.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdProcessCB, "cmdProcessCB");
            this.cmdProcessCB.Name = "cmdProcessCB";
            // 
            // tsProcessFirst1
            // 
            resources.ApplyResources(this.tsProcessFirst1, "tsProcessFirst1");
            this.tsProcessFirst1.Name = "tsProcessFirst1";
            // 
            // tsProcessSecond1
            // 
            resources.ApplyResources(this.tsProcessSecond1, "tsProcessSecond1");
            this.tsProcessSecond1.Name = "tsProcessSecond1";
            // 
            // cmdGoToActivity
            // 
            resources.ApplyResources(this.cmdGoToActivity, "cmdGoToActivity");
            this.cmdGoToActivity.Name = "cmdGoToActivity";
            // 
            // cmdGoToCB
            // 
            resources.ApplyResources(this.cmdGoToCB, "cmdGoToCB");
            this.cmdGoToCB.Name = "cmdGoToCB";
            // 
            // cmdGoToGeneralFile
            // 
            resources.ApplyResources(this.cmdGoToGeneralFile, "cmdGoToGeneralFile");
            this.cmdGoToGeneralFile.Name = "cmdGoToGeneralFile";
            // 
            // tsActions
            // 
            resources.ApplyResources(this.tsActions, "tsActions");
            this.tsActions.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.tsActions.Name = "tsActions";
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
            // cmdGoToActivity1
            // 
            resources.ApplyResources(this.cmdGoToActivity1, "cmdGoToActivity1");
            this.cmdGoToActivity1.Name = "cmdGoToActivity1";
            // 
            // cmdGoToCB1
            // 
            resources.ApplyResources(this.cmdGoToCB1, "cmdGoToCB1");
            this.cmdGoToCB1.Name = "cmdGoToCB1";
            // 
            // cmdGoToGeneralFile1
            // 
            resources.ApplyResources(this.cmdGoToGeneralFile1, "cmdGoToGeneralFile1");
            this.cmdGoToGeneralFile1.Name = "cmdGoToGeneralFile1";
            // 
            // commentsEditBox
            // 
            this.commentsEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cBDetailBindingSource, "Comments", true));
            resources.ApplyResources(this.commentsEditBox, "commentsEditBox");
            this.commentsEditBox.Multiline = true;
            this.commentsEditBox.Name = "commentsEditBox";
            this.helpProvider1.SetShowHelp(this.commentsEditBox, ((bool)(resources.GetObject("commentsEditBox.ShowHelp"))));
            this.commentsEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // cBDetailBindingSource
            // 
            this.cBDetailBindingSource.DataMember = "CashBlotterCBDetail";
            this.cBDetailBindingSource.DataSource = this.cashBlotterBindingSource;
            this.cBDetailBindingSource.CurrentChanged += new System.EventHandler(this.cBDetailBindingSource_CurrentChanged);
            // 
            // paymentSourceComboBox
            // 
            this.paymentSourceComboBox.BackColor = System.Drawing.Color.Transparent;
            this.paymentSourceComboBox.Column1 = "CBPaymentSource";
            resources.ApplyResources(this.paymentSourceComboBox, "paymentSourceComboBox");
            this.paymentSourceComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.paymentSourceComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "PaymentSource", true));
            this.paymentSourceComboBox.DataSource = null;
            this.paymentSourceComboBox.DDColumn1Visible = true;
            this.paymentSourceComboBox.DropDownColumn1Width = 100;
            this.paymentSourceComboBox.DropDownColumn2Width = 300;
            this.paymentSourceComboBox.Name = "paymentSourceComboBox";
            this.paymentSourceComboBox.ReadOnly = false;
            this.paymentSourceComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.paymentSourceComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.paymentSourceComboBox, ((bool)(resources.GetObject("paymentSourceComboBox.ShowHelp"))));
            this.paymentSourceComboBox.ValueMember = "CBPaymentSource";
            // 
            // valuableAmountNumericEditBox
            // 
            this.valuableAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cBDetailBindingSource, "ValuableAmount", true));
            this.valuableAmountNumericEditBox.DecimalDigits = 2;
            this.valuableAmountNumericEditBox.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
            this.valuableAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.valuableAmountNumericEditBox, "valuableAmountNumericEditBox");
            this.valuableAmountNumericEditBox.Name = "valuableAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.valuableAmountNumericEditBox, ((bool)(resources.GetObject("valuableAmountNumericEditBox.ShowHelp"))));
            this.valuableAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valuableAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // natureOfPaymentComboBox
            // 
            this.natureOfPaymentComboBox.BackColor = System.Drawing.Color.Transparent;
            this.natureOfPaymentComboBox.Column1 = "CBNatureOfPayment";
            resources.ApplyResources(this.natureOfPaymentComboBox, "natureOfPaymentComboBox");
            this.natureOfPaymentComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.natureOfPaymentComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "NatureOfPayment", true));
            this.natureOfPaymentComboBox.DataSource = null;
            this.natureOfPaymentComboBox.DDColumn1Visible = true;
            this.natureOfPaymentComboBox.DropDownColumn1Width = 100;
            this.natureOfPaymentComboBox.DropDownColumn2Width = 300;
            this.natureOfPaymentComboBox.Name = "natureOfPaymentComboBox";
            this.natureOfPaymentComboBox.ReadOnly = false;
            this.natureOfPaymentComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.natureOfPaymentComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.natureOfPaymentComboBox, ((bool)(resources.GetObject("natureOfPaymentComboBox.ShowHelp"))));
            this.natureOfPaymentComboBox.ValueMember = "CBNatureOfPayment";
            // 
            // statusCodeComboBox
            // 
            this.statusCodeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.statusCodeComboBox.Column1 = "CBStatus";
            resources.ApplyResources(this.statusCodeComboBox, "statusCodeComboBox");
            this.statusCodeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.statusCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "StatusCode", true));
            this.statusCodeComboBox.DataSource = null;
            this.statusCodeComboBox.DDColumn1Visible = true;
            this.statusCodeComboBox.DropDownColumn1Width = 100;
            this.statusCodeComboBox.DropDownColumn2Width = 300;
            this.statusCodeComboBox.Name = "statusCodeComboBox";
            this.statusCodeComboBox.ReadOnly = false;
            this.statusCodeComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.statusCodeComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.statusCodeComboBox, ((bool)(resources.GetObject("statusCodeComboBox.ShowHelp"))));
            this.statusCodeComboBox.ValueMember = "CBStatus";
            // 
            // lastNameEditBox
            // 
            this.lastNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.lastNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cBDetailBindingSource, "LastName", true));
            resources.ApplyResources(this.lastNameEditBox, "lastNameEditBox");
            this.lastNameEditBox.Name = "lastNameEditBox";
            this.lastNameEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.lastNameEditBox, ((bool)(resources.GetObject("lastNameEditBox.ShowHelp"))));
            this.lastNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // firstNameEditBox
            // 
            this.firstNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.firstNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cBDetailBindingSource, "FirstName", true));
            resources.ApplyResources(this.firstNameEditBox, "firstNameEditBox");
            this.firstNameEditBox.Name = "firstNameEditBox";
            this.firstNameEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.firstNameEditBox, ((bool)(resources.GetObject("firstNameEditBox.ShowHelp"))));
            this.firstNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // mccOfficeCode
            // 
            this.mccOfficeCode.BackColor = System.Drawing.Color.Transparent;
            this.mccOfficeCode.Column1 = "OfficeCode";
            resources.ApplyResources(this.mccOfficeCode, "mccOfficeCode");
            this.mccOfficeCode.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccOfficeCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "OfficeID", true));
            this.mccOfficeCode.DataSource = null;
            this.mccOfficeCode.DDColumn1Visible = true;
            this.mccOfficeCode.DropDownColumn1Width = 100;
            this.mccOfficeCode.DropDownColumn2Width = 300;
            this.mccOfficeCode.Name = "mccOfficeCode";
            this.mccOfficeCode.ReadOnly = true;
            this.mccOfficeCode.ReqColor = System.Drawing.SystemColors.Control;
            this.mccOfficeCode.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccOfficeCode, ((bool)(resources.GetObject("mccOfficeCode.ShowHelp"))));
            this.mccOfficeCode.ValueMember = "OfficeId";
            // 
            // valuableDateCalendarCombo
            // 
            resources.ApplyResources(this.valuableDateCalendarCombo, "valuableDateCalendarCombo");
            this.valuableDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.cBDetailBindingSource, "ValuableDate", true));
            this.valuableDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.valuableDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 4, 1, 0, 0, 0, 0);
            this.valuableDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.valuableDateCalendarCombo.MonthIncrement = 0;
            this.valuableDateCalendarCombo.Name = "valuableDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.valuableDateCalendarCombo, ((bool)(resources.GetObject("valuableDateCalendarCombo.ShowHelp"))));
            this.valuableDateCalendarCombo.Value = new System.DateTime(2007, 11, 6, 0, 0, 0, 0);
            this.valuableDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.valuableDateCalendarCombo.YearIncrement = 0;
            this.valuableDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.valuableDateCalendarCombo_KeyDown);
            // 
            // currencyCodeComboBox
            // 
            this.currencyCodeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.currencyCodeComboBox.Column1 = "CurrencyCode";
            resources.ApplyResources(this.currencyCodeComboBox, "currencyCodeComboBox");
            this.currencyCodeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.currencyCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "CurrencyCode", true));
            this.currencyCodeComboBox.DataSource = null;
            this.currencyCodeComboBox.DDColumn1Visible = true;
            this.currencyCodeComboBox.DropDownColumn1Width = 100;
            this.currencyCodeComboBox.DropDownColumn2Width = 300;
            this.currencyCodeComboBox.Name = "currencyCodeComboBox";
            this.currencyCodeComboBox.ReadOnly = false;
            this.currencyCodeComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.currencyCodeComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.currencyCodeComboBox, ((bool)(resources.GetObject("currencyCodeComboBox.ShowHelp"))));
            this.currencyCodeComboBox.ValueMember = "CurrencyCode";
            // 
            // valuableTypeComboBox
            // 
            this.valuableTypeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.valuableTypeComboBox.Column1 = "CBInstrumentType";
            resources.ApplyResources(this.valuableTypeComboBox, "valuableTypeComboBox");
            this.valuableTypeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.valuableTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "ValuableType", true));
            this.valuableTypeComboBox.DataSource = null;
            this.valuableTypeComboBox.DDColumn1Visible = true;
            this.valuableTypeComboBox.DropDownColumn1Width = 100;
            this.valuableTypeComboBox.DropDownColumn2Width = 300;
            this.valuableTypeComboBox.Name = "valuableTypeComboBox";
            this.valuableTypeComboBox.ReadOnly = false;
            this.valuableTypeComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.valuableTypeComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.valuableTypeComboBox, ((bool)(resources.GetObject("valuableTypeComboBox.ShowHelp"))));
            this.valuableTypeComboBox.ValueMember = "CBInstrumentType";
            // 
            // receivedDateCalendarCombo
            // 
            this.receivedDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.receivedDateCalendarCombo, "receivedDateCalendarCombo");
            this.receivedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.cBDetailBindingSource, "ReceivedDate", true));
            this.receivedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 4, 1, 0, 0, 0, 0);
            this.receivedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedDateCalendarCombo.MonthIncrement = 0;
            this.receivedDateCalendarCombo.Name = "receivedDateCalendarCombo";
            this.receivedDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.receivedDateCalendarCombo, ((bool)(resources.GetObject("receivedDateCalendarCombo.ShowHelp"))));
            this.receivedDateCalendarCombo.Value = new System.DateTime(2007, 11, 6, 0, 0, 0, 0);
            this.receivedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedDateCalendarCombo.YearIncrement = 0;
            // 
            // sINMaskedEditBox
            // 
            this.sINMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sINMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cBDetailBindingSource, "SIN", true));
            resources.ApplyResources(this.sINMaskedEditBox, "sINMaskedEditBox");
            this.sINMaskedEditBox.Mask = "000 000 000";
            this.sINMaskedEditBox.Name = "sINMaskedEditBox";
            this.sINMaskedEditBox.PromptChar = ' ';
            this.sINMaskedEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sINMaskedEditBox, ((bool)(resources.GetObject("sINMaskedEditBox.ShowHelp"))));
            this.sINMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucContactSelectBox1
            // 
            this.ucContactSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox1.ContactId = null;
            this.ucContactSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.cashBlotterBindingSource, "FirstConfirm", true));
            this.ucContactSelectBox1.FM = null;
            resources.ApplyResources(this.ucContactSelectBox1, "ucContactSelectBox1");
            this.ucContactSelectBox1.Name = "ucContactSelectBox1";
            this.ucContactSelectBox1.ReadOnly = true;
            this.ucContactSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucContactSelectBox1, ((bool)(resources.GetObject("ucContactSelectBox1.ShowHelp"))));
            this.ucContactSelectBox1.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // cashBlotterGridEX
            // 
            this.cashBlotterGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.cashBlotterGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cashBlotterGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.cashBlotterGridEX.DataSource = this.cashBlotterBindingSource;
            resources.ApplyResources(cashBlotterGridEX_DesignTimeLayout, "cashBlotterGridEX_DesignTimeLayout");
            this.cashBlotterGridEX.DesignTimeLayout = cashBlotterGridEX_DesignTimeLayout;
            this.cashBlotterGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.cashBlotterGridEX, "cashBlotterGridEX");
            this.cashBlotterGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.cashBlotterGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.cashBlotterGridEX.GroupByBoxVisible = false;
            this.cashBlotterGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.cashBlotterGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.cashBlotterGridEX.Name = "cashBlotterGridEX";
            this.helpProvider1.SetShowHelp(this.cashBlotterGridEX, ((bool)(resources.GetObject("cashBlotterGridEX.ShowHelp"))));
            this.cashBlotterGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.cashBlotterGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.cashBlotterGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // cashBlotterIDEditBox
            // 
            this.cashBlotterIDEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.cashBlotterIDEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cashBlotterBindingSource, "CashBlotterID", true));
            resources.ApplyResources(this.cashBlotterIDEditBox, "cashBlotterIDEditBox");
            this.cashBlotterIDEditBox.Name = "cashBlotterIDEditBox";
            this.cashBlotterIDEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.cashBlotterIDEditBox, ((bool)(resources.GetObject("cashBlotterIDEditBox.ShowHelp"))));
            this.cashBlotterIDEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // remittedDateCalendarCombo
            // 
            this.remittedDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.remittedDateCalendarCombo, "remittedDateCalendarCombo");
            this.remittedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.cashBlotterBindingSource, "RemittedDate", true));
            this.remittedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.remittedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 4, 1, 0, 0, 0, 0);
            this.remittedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.remittedDateCalendarCombo.MonthIncrement = 0;
            this.remittedDateCalendarCombo.Name = "remittedDateCalendarCombo";
            this.remittedDateCalendarCombo.Nullable = true;
            this.remittedDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.remittedDateCalendarCombo, ((bool)(resources.GetObject("remittedDateCalendarCombo.ShowHelp"))));
            this.remittedDateCalendarCombo.Value = new System.DateTime(2007, 11, 6, 0, 0, 0, 0);
            this.remittedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.remittedDateCalendarCombo.YearIncrement = 0;
            // 
            // cBDetailGridEX
            // 
            this.cBDetailGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.cBDetailGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.cBDetailGridEX, "cBDetailGridEX");
            this.cBDetailGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.cBDetailGridEX.DataSource = this.cBDetailBindingSource;
            resources.ApplyResources(cBDetailGridEX_DesignTimeLayout, "cBDetailGridEX_DesignTimeLayout");
            this.cBDetailGridEX.DesignTimeLayout = cBDetailGridEX_DesignTimeLayout;
            this.cBDetailGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.cBDetailGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.cBDetailGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.cBDetailGridEX.GroupByBoxVisible = false;
            this.cBDetailGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.cBDetailGridEX.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.cBDetailGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.cBDetailGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.cBDetailGridEX.Name = "cBDetailGridEX";
            this.helpProvider1.SetShowHelp(this.cBDetailGridEX, ((bool)(resources.GetObject("cBDetailGridEX.ShowHelp"))));
            this.cBDetailGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.cBDetailGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.cBDetailGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.cashBlotterBindingSource;
            // 
            // ucCashBlotterOffice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucCashBlotterOffice";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucCashBlotterOffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashBlotterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashBlotterGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
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
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.GridEX.GridEX cashBlotterGridEX;
        private System.Windows.Forms.BindingSource cashBlotterBindingSource;
        private lmDatasets.CLAS CLAS;
        private Janus.Windows.CalendarCombo.CalendarCombo remittedDateCalendarCombo;
        private Janus.Windows.GridEX.GridEX cBDetailGridEX;
        private System.Windows.Forms.BindingSource cBDetailBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo valuableDateCalendarCombo;
        private Janus.Windows.UI.CommandBars.UICommand tsProcessFirst;
        private Janus.Windows.UI.CommandBars.UICommand tsProcessSecond;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox sINMaskedEditBox;
        private Janus.Windows.UI.CommandBars.UICommand tsPrintCB;
        private Janus.Windows.UI.CommandBars.UICommand tsPrintCB1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private UserControls.ucMultiDropDown valuableTypeComboBox;
        private UserControls.ucMultiDropDown paymentSourceComboBox;
        private UserControls.ucMultiDropDown natureOfPaymentComboBox;
        private UserControls.ucMultiDropDown statusCodeComboBox;
        private UserControls.ucMultiDropDown currencyCodeComboBox;
        private UserControls.ucMultiDropDown mccOfficeCode;
        private Janus.Windows.GridEX.EditControls.EditBox commentsEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox valuableAmountNumericEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox lastNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox firstNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox cashBlotterIDEditBox;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdProcessCB2;
        private Janus.Windows.UI.CommandBars.UICommand tsPrintCB2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand cmdProcessCB;
        private Janus.Windows.UI.CommandBars.UICommand tsProcessFirst1;
        private Janus.Windows.UI.CommandBars.UICommand tsProcessSecond1;
        private Janus.Windows.UI.CommandBars.UICommand cmdProcessCB1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private ucContactSelectBox ucContactSelectBox2;
        private ucContactSelectBox ucContactSelectBox1;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.EditControls.UIButton btnGoTo;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToActivity;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToCB;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToActivity1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToCB1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToGeneralFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToGeneralFile1;
        private Janus.Windows.UI.CommandBars.UICommand tsActions2;
        private Janus.Windows.UI.CommandBars.UICommand tsActions1;
        private Janus.Windows.UI.CommandBars.UICommand tsActions;
    }
}
