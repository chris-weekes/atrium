 namespace LawMate
{
    partial class ucFileAccount
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
                FM.GetCLASMng().DB.Debt.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.GetCLASMng().DB.AccountHistory.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);

                FM.GetCLASMng().GetDebt().OnUpdate -= new atLogic.UpdateEventHandler(ucFileAccount_OnUpdate);
                FM.GetCLASMng().GetAccountHistory().OnUpdate -= new atLogic.UpdateEventHandler(ucFileAccount_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFileAccount));
            System.Windows.Forms.Label principalAmountLabel;
            System.Windows.Forms.Label interestRateLabel;
            System.Windows.Forms.Label interestFromDateLabel;
            System.Windows.Forms.Label rateTypeLabel;
            System.Windows.Forms.Label interestAmountLabel;
            System.Windows.Forms.Label lPCodeLabel;
            System.Windows.Forms.Label lPDateLabel;
            System.Windows.Forms.Label lPExpiresLabel;
            System.Windows.Forms.Label currentToLabel;
            System.Windows.Forms.Label receivedByJusticeDateLabel;
            System.Windows.Forms.Label closureDateLabel;
            System.Windows.Forms.Label closureCodeLabel;
            System.Windows.Forms.Label currentLiabilityLabel;
            System.Windows.Forms.Label accountTypeCodeLabel;
            System.Windows.Forms.Label sentToOfficeDateLabel;
            System.Windows.Forms.Label receivedByOfficeDateLabel;
            System.Windows.Forms.Label returnedByOfficeDateLabel;
            System.Windows.Forms.Label receivedFromOfficeDateLabel;
            System.Windows.Forms.Label returnCodeLabel;
            System.Windows.Forms.Label officeCodeLabel;
            System.Windows.Forms.Label dARSOccurenceDateLabel;
            System.Windows.Forms.Label sequenceBalanceLabel;
            System.Windows.Forms.Label invoiceNumberLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            Janus.Windows.GridEX.GridEXLayout debtGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout accountHistoryGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference accountHistoryGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.ButtonImage");
            this.lblStatuteBarredMessage = new System.Windows.Forms.Label();
            this.CLAS = new lmDatasets.CLAS();
            this.debtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.debtGridEX = new Janus.Windows.GridEX.GridEX();
            this.interestFromDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lPDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lPExpiresCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.currentToCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.receivedByJusticeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.closureDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.mSOAOverDARSUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.rateTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.interestAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.currentLiabilityNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.invoiceNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sequenceBalanceEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.principalAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ucAccountTypeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.numericEditBox1 = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.dARSOccurenceDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.accountHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucLPCodeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucReturnCodeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.sentToOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.receivedByOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.returnedByOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.receivedFromOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.accountHistoryGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.activeWithJusticeCheckbox = new Janus.Windows.EditControls.UICheckBox();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage5 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.LPCommentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.officeIducOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.ucClosureCodeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode2 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle2 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave3 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete3 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            principalAmountLabel = new System.Windows.Forms.Label();
            interestRateLabel = new System.Windows.Forms.Label();
            interestFromDateLabel = new System.Windows.Forms.Label();
            rateTypeLabel = new System.Windows.Forms.Label();
            interestAmountLabel = new System.Windows.Forms.Label();
            lPCodeLabel = new System.Windows.Forms.Label();
            lPDateLabel = new System.Windows.Forms.Label();
            lPExpiresLabel = new System.Windows.Forms.Label();
            currentToLabel = new System.Windows.Forms.Label();
            receivedByJusticeDateLabel = new System.Windows.Forms.Label();
            closureDateLabel = new System.Windows.Forms.Label();
            closureCodeLabel = new System.Windows.Forms.Label();
            currentLiabilityLabel = new System.Windows.Forms.Label();
            accountTypeCodeLabel = new System.Windows.Forms.Label();
            sentToOfficeDateLabel = new System.Windows.Forms.Label();
            receivedByOfficeDateLabel = new System.Windows.Forms.Label();
            returnedByOfficeDateLabel = new System.Windows.Forms.Label();
            receivedFromOfficeDateLabel = new System.Windows.Forms.Label();
            returnCodeLabel = new System.Windows.Forms.Label();
            officeCodeLabel = new System.Windows.Forms.Label();
            dARSOccurenceDateLabel = new System.Windows.Forms.Label();
            sequenceBalanceLabel = new System.Windows.Forms.Label();
            invoiceNumberLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountHistoryGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.debtBindingSource;
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
            // principalAmountLabel
            // 
            resources.ApplyResources(principalAmountLabel, "principalAmountLabel");
            principalAmountLabel.BackColor = System.Drawing.Color.Transparent;
            principalAmountLabel.Name = "principalAmountLabel";
            this.helpProvider1.SetShowHelp(principalAmountLabel, ((bool)(resources.GetObject("principalAmountLabel.ShowHelp"))));
            // 
            // interestRateLabel
            // 
            resources.ApplyResources(interestRateLabel, "interestRateLabel");
            interestRateLabel.BackColor = System.Drawing.Color.Transparent;
            interestRateLabel.Name = "interestRateLabel";
            this.helpProvider1.SetShowHelp(interestRateLabel, ((bool)(resources.GetObject("interestRateLabel.ShowHelp"))));
            // 
            // interestFromDateLabel
            // 
            resources.ApplyResources(interestFromDateLabel, "interestFromDateLabel");
            interestFromDateLabel.BackColor = System.Drawing.Color.Transparent;
            interestFromDateLabel.Name = "interestFromDateLabel";
            this.helpProvider1.SetShowHelp(interestFromDateLabel, ((bool)(resources.GetObject("interestFromDateLabel.ShowHelp"))));
            // 
            // rateTypeLabel
            // 
            resources.ApplyResources(rateTypeLabel, "rateTypeLabel");
            rateTypeLabel.BackColor = System.Drawing.Color.Transparent;
            rateTypeLabel.Name = "rateTypeLabel";
            this.helpProvider1.SetShowHelp(rateTypeLabel, ((bool)(resources.GetObject("rateTypeLabel.ShowHelp"))));
            // 
            // interestAmountLabel
            // 
            resources.ApplyResources(interestAmountLabel, "interestAmountLabel");
            interestAmountLabel.BackColor = System.Drawing.Color.Transparent;
            interestAmountLabel.Name = "interestAmountLabel";
            this.helpProvider1.SetShowHelp(interestAmountLabel, ((bool)(resources.GetObject("interestAmountLabel.ShowHelp"))));
            // 
            // lPCodeLabel
            // 
            resources.ApplyResources(lPCodeLabel, "lPCodeLabel");
            lPCodeLabel.BackColor = System.Drawing.Color.Transparent;
            lPCodeLabel.Name = "lPCodeLabel";
            this.helpProvider1.SetShowHelp(lPCodeLabel, ((bool)(resources.GetObject("lPCodeLabel.ShowHelp"))));
            // 
            // lPDateLabel
            // 
            resources.ApplyResources(lPDateLabel, "lPDateLabel");
            lPDateLabel.BackColor = System.Drawing.Color.Transparent;
            lPDateLabel.Name = "lPDateLabel";
            this.helpProvider1.SetShowHelp(lPDateLabel, ((bool)(resources.GetObject("lPDateLabel.ShowHelp"))));
            // 
            // lPExpiresLabel
            // 
            resources.ApplyResources(lPExpiresLabel, "lPExpiresLabel");
            lPExpiresLabel.BackColor = System.Drawing.Color.Transparent;
            lPExpiresLabel.Name = "lPExpiresLabel";
            this.helpProvider1.SetShowHelp(lPExpiresLabel, ((bool)(resources.GetObject("lPExpiresLabel.ShowHelp"))));
            // 
            // currentToLabel
            // 
            resources.ApplyResources(currentToLabel, "currentToLabel");
            currentToLabel.BackColor = System.Drawing.Color.Transparent;
            currentToLabel.Name = "currentToLabel";
            this.helpProvider1.SetShowHelp(currentToLabel, ((bool)(resources.GetObject("currentToLabel.ShowHelp"))));
            // 
            // receivedByJusticeDateLabel
            // 
            resources.ApplyResources(receivedByJusticeDateLabel, "receivedByJusticeDateLabel");
            receivedByJusticeDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedByJusticeDateLabel.Name = "receivedByJusticeDateLabel";
            this.helpProvider1.SetShowHelp(receivedByJusticeDateLabel, ((bool)(resources.GetObject("receivedByJusticeDateLabel.ShowHelp"))));
            // 
            // closureDateLabel
            // 
            resources.ApplyResources(closureDateLabel, "closureDateLabel");
            closureDateLabel.BackColor = System.Drawing.Color.Transparent;
            closureDateLabel.Name = "closureDateLabel";
            this.helpProvider1.SetShowHelp(closureDateLabel, ((bool)(resources.GetObject("closureDateLabel.ShowHelp"))));
            // 
            // closureCodeLabel
            // 
            resources.ApplyResources(closureCodeLabel, "closureCodeLabel");
            closureCodeLabel.BackColor = System.Drawing.Color.Transparent;
            closureCodeLabel.Name = "closureCodeLabel";
            this.helpProvider1.SetShowHelp(closureCodeLabel, ((bool)(resources.GetObject("closureCodeLabel.ShowHelp"))));
            // 
            // currentLiabilityLabel
            // 
            resources.ApplyResources(currentLiabilityLabel, "currentLiabilityLabel");
            currentLiabilityLabel.BackColor = System.Drawing.Color.Transparent;
            currentLiabilityLabel.Name = "currentLiabilityLabel";
            this.helpProvider1.SetShowHelp(currentLiabilityLabel, ((bool)(resources.GetObject("currentLiabilityLabel.ShowHelp"))));
            // 
            // accountTypeCodeLabel
            // 
            resources.ApplyResources(accountTypeCodeLabel, "accountTypeCodeLabel");
            accountTypeCodeLabel.BackColor = System.Drawing.Color.Transparent;
            accountTypeCodeLabel.Name = "accountTypeCodeLabel";
            this.helpProvider1.SetShowHelp(accountTypeCodeLabel, ((bool)(resources.GetObject("accountTypeCodeLabel.ShowHelp"))));
            // 
            // sentToOfficeDateLabel
            // 
            resources.ApplyResources(sentToOfficeDateLabel, "sentToOfficeDateLabel");
            sentToOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            sentToOfficeDateLabel.Name = "sentToOfficeDateLabel";
            this.helpProvider1.SetShowHelp(sentToOfficeDateLabel, ((bool)(resources.GetObject("sentToOfficeDateLabel.ShowHelp"))));
            // 
            // receivedByOfficeDateLabel
            // 
            resources.ApplyResources(receivedByOfficeDateLabel, "receivedByOfficeDateLabel");
            receivedByOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedByOfficeDateLabel.Name = "receivedByOfficeDateLabel";
            this.helpProvider1.SetShowHelp(receivedByOfficeDateLabel, ((bool)(resources.GetObject("receivedByOfficeDateLabel.ShowHelp"))));
            // 
            // returnedByOfficeDateLabel
            // 
            resources.ApplyResources(returnedByOfficeDateLabel, "returnedByOfficeDateLabel");
            returnedByOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            returnedByOfficeDateLabel.Name = "returnedByOfficeDateLabel";
            this.helpProvider1.SetShowHelp(returnedByOfficeDateLabel, ((bool)(resources.GetObject("returnedByOfficeDateLabel.ShowHelp"))));
            // 
            // receivedFromOfficeDateLabel
            // 
            resources.ApplyResources(receivedFromOfficeDateLabel, "receivedFromOfficeDateLabel");
            receivedFromOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedFromOfficeDateLabel.Name = "receivedFromOfficeDateLabel";
            this.helpProvider1.SetShowHelp(receivedFromOfficeDateLabel, ((bool)(resources.GetObject("receivedFromOfficeDateLabel.ShowHelp"))));
            // 
            // returnCodeLabel
            // 
            resources.ApplyResources(returnCodeLabel, "returnCodeLabel");
            returnCodeLabel.BackColor = System.Drawing.Color.Transparent;
            returnCodeLabel.Name = "returnCodeLabel";
            this.helpProvider1.SetShowHelp(returnCodeLabel, ((bool)(resources.GetObject("returnCodeLabel.ShowHelp"))));
            // 
            // officeCodeLabel
            // 
            resources.ApplyResources(officeCodeLabel, "officeCodeLabel");
            officeCodeLabel.BackColor = System.Drawing.Color.Transparent;
            officeCodeLabel.Name = "officeCodeLabel";
            this.helpProvider1.SetShowHelp(officeCodeLabel, ((bool)(resources.GetObject("officeCodeLabel.ShowHelp"))));
            // 
            // dARSOccurenceDateLabel
            // 
            resources.ApplyResources(dARSOccurenceDateLabel, "dARSOccurenceDateLabel");
            dARSOccurenceDateLabel.BackColor = System.Drawing.Color.Transparent;
            dARSOccurenceDateLabel.Name = "dARSOccurenceDateLabel";
            this.helpProvider1.SetShowHelp(dARSOccurenceDateLabel, ((bool)(resources.GetObject("dARSOccurenceDateLabel.ShowHelp"))));
            // 
            // sequenceBalanceLabel
            // 
            resources.ApplyResources(sequenceBalanceLabel, "sequenceBalanceLabel");
            sequenceBalanceLabel.BackColor = System.Drawing.Color.Transparent;
            sequenceBalanceLabel.Name = "sequenceBalanceLabel";
            this.helpProvider1.SetShowHelp(sequenceBalanceLabel, ((bool)(resources.GetObject("sequenceBalanceLabel.ShowHelp"))));
            // 
            // invoiceNumberLabel
            // 
            resources.ApplyResources(invoiceNumberLabel, "invoiceNumberLabel");
            invoiceNumberLabel.BackColor = System.Drawing.Color.Transparent;
            invoiceNumberLabel.Name = "invoiceNumberLabel";
            this.helpProvider1.SetShowHelp(invoiceNumberLabel, ((bool)(resources.GetObject("invoiceNumberLabel.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // lblStatuteBarredMessage
            // 
            this.lblStatuteBarredMessage.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblStatuteBarredMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblStatuteBarredMessage, "lblStatuteBarredMessage");
            this.lblStatuteBarredMessage.ForeColor = System.Drawing.Color.Red;
            this.lblStatuteBarredMessage.Name = "lblStatuteBarredMessage";
            this.helpProvider1.SetShowHelp(this.lblStatuteBarredMessage, ((bool)(resources.GetObject("lblStatuteBarredMessage.ShowHelp"))));
            // 
            // CLAS
            // 
            this.CLAS.DataSetName = "CLAS";
            this.CLAS.EnforceConstraints = false;
            this.CLAS.Locale = new System.Globalization.CultureInfo("en-CA");
            this.CLAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // debtBindingSource
            // 
            this.debtBindingSource.DataMember = "Debt";
            this.debtBindingSource.DataSource = this.CLAS;
            this.debtBindingSource.CurrentChanged += new System.EventHandler(this.debtBindingSource_CurrentChanged);
            // 
            // debtGridEX
            // 
            this.debtGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Crimson;
            resources.ApplyResources(this.debtGridEX, "debtGridEX");
            this.debtGridEX.DataSource = this.debtBindingSource;
            resources.ApplyResources(debtGridEX_DesignTimeLayout, "debtGridEX_DesignTimeLayout");
            this.debtGridEX.DesignTimeLayout = debtGridEX_DesignTimeLayout;
            this.debtGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.debtGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.debtGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.debtGridEX.GroupByBoxVisible = false;
            this.debtGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.debtGridEX.Name = "debtGridEX";
            this.helpProvider1.SetShowHelp(this.debtGridEX, ((bool)(resources.GetObject("debtGridEX.ShowHelp"))));
            this.debtGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.debtGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.debtGridEX.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.debtGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.debtGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.debtGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.debtGridEX_CurrentCellChanging);
            // 
            // interestFromDateCalendarCombo
            // 
            resources.ApplyResources(this.interestFromDateCalendarCombo, "interestFromDateCalendarCombo");
            this.interestFromDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "InterestFromDate", true));
            this.interestFromDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.interestFromDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.interestFromDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.interestFromDateCalendarCombo.MonthIncrement = 0;
            this.interestFromDateCalendarCombo.Name = "interestFromDateCalendarCombo";
            this.interestFromDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.interestFromDateCalendarCombo, ((bool)(resources.GetObject("interestFromDateCalendarCombo.ShowHelp"))));
            this.interestFromDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.interestFromDateCalendarCombo.YearIncrement = 0;
            // 
            // lPDateCalendarCombo
            // 
            resources.ApplyResources(this.lPDateCalendarCombo, "lPDateCalendarCombo");
            this.lPDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "LPDate", true));
            this.lPDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.lPDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.lPDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.lPDateCalendarCombo.MonthIncrement = 0;
            this.lPDateCalendarCombo.Name = "lPDateCalendarCombo";
            this.lPDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.lPDateCalendarCombo, ((bool)(resources.GetObject("lPDateCalendarCombo.ShowHelp"))));
            this.lPDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.lPDateCalendarCombo.YearIncrement = 0;
            // 
            // lPExpiresCalendarCombo
            // 
            resources.ApplyResources(this.lPExpiresCalendarCombo, "lPExpiresCalendarCombo");
            this.lPExpiresCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "LPExpires", true));
            this.lPExpiresCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.lPExpiresCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.lPExpiresCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.lPExpiresCalendarCombo.MonthIncrement = 0;
            this.lPExpiresCalendarCombo.Name = "lPExpiresCalendarCombo";
            this.lPExpiresCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.lPExpiresCalendarCombo, ((bool)(resources.GetObject("lPExpiresCalendarCombo.ShowHelp"))));
            this.lPExpiresCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.lPExpiresCalendarCombo.YearIncrement = 0;
            // 
            // currentToCalendarCombo
            // 
            resources.ApplyResources(this.currentToCalendarCombo, "currentToCalendarCombo");
            this.currentToCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "CurrentTo", true));
            this.currentToCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.currentToCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.currentToCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.currentToCalendarCombo.MonthIncrement = 0;
            this.currentToCalendarCombo.Name = "currentToCalendarCombo";
            this.currentToCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.currentToCalendarCombo, ((bool)(resources.GetObject("currentToCalendarCombo.ShowHelp"))));
            this.currentToCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.currentToCalendarCombo.YearIncrement = 0;
            // 
            // receivedByJusticeDateCalendarCombo
            // 
            resources.ApplyResources(this.receivedByJusticeDateCalendarCombo, "receivedByJusticeDateCalendarCombo");
            this.receivedByJusticeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "ReceivedByJusticeDate", true));
            this.receivedByJusticeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedByJusticeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.receivedByJusticeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedByJusticeDateCalendarCombo.MonthIncrement = 0;
            this.receivedByJusticeDateCalendarCombo.Name = "receivedByJusticeDateCalendarCombo";
            this.receivedByJusticeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.receivedByJusticeDateCalendarCombo, ((bool)(resources.GetObject("receivedByJusticeDateCalendarCombo.ShowHelp"))));
            this.receivedByJusticeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedByJusticeDateCalendarCombo.YearIncrement = 0;
            // 
            // closureDateCalendarCombo
            // 
            resources.ApplyResources(this.closureDateCalendarCombo, "closureDateCalendarCombo");
            this.closureDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "ClosureDate", true));
            this.closureDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.closureDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.closureDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.closureDateCalendarCombo.MonthIncrement = 0;
            this.closureDateCalendarCombo.Name = "closureDateCalendarCombo";
            this.closureDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.closureDateCalendarCombo, ((bool)(resources.GetObject("closureDateCalendarCombo.ShowHelp"))));
            this.closureDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.closureDateCalendarCombo.YearIncrement = 0;
            // 
            // mSOAOverDARSUICheckBox
            // 
            this.mSOAOverDARSUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.mSOAOverDARSUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mSOAOverDARSUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "MSOAOverDARS", true));
            resources.ApplyResources(this.mSOAOverDARSUICheckBox, "mSOAOverDARSUICheckBox");
            this.mSOAOverDARSUICheckBox.Name = "mSOAOverDARSUICheckBox";
            this.helpProvider1.SetShowHelp(this.mSOAOverDARSUICheckBox, ((bool)(resources.GetObject("mSOAOverDARSUICheckBox.ShowHelp"))));
            this.mSOAOverDARSUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // rateTypeucMultiDropDown
            // 
            this.rateTypeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.rateTypeucMultiDropDown.Column1 = "InterestRateCode";
            resources.ApplyResources(this.rateTypeucMultiDropDown, "rateTypeucMultiDropDown");
            this.rateTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.rateTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.debtBindingSource, "RateType", true));
            this.rateTypeucMultiDropDown.DataSource = null;
            this.rateTypeucMultiDropDown.DDColumn1Visible = true;
            this.rateTypeucMultiDropDown.DropDownColumn1Width = 100;
            this.rateTypeucMultiDropDown.DropDownColumn2Width = 300;
            this.rateTypeucMultiDropDown.Name = "rateTypeucMultiDropDown";
            this.rateTypeucMultiDropDown.ReadOnly = false;
            this.rateTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.rateTypeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.rateTypeucMultiDropDown, ((bool)(resources.GetObject("rateTypeucMultiDropDown.ShowHelp"))));
            this.rateTypeucMultiDropDown.ValueMember = "InterestRateCode";
            // 
            // interestAmountNumericEditBox
            // 
            this.interestAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtBindingSource, "InterestAmount", true));
            this.interestAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.interestAmountNumericEditBox, "interestAmountNumericEditBox");
            this.interestAmountNumericEditBox.Name = "interestAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.interestAmountNumericEditBox, ((bool)(resources.GetObject("interestAmountNumericEditBox.ShowHelp"))));
            this.interestAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.interestAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // currentLiabilityNumericEditBox
            // 
            this.currentLiabilityNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtBindingSource, "CurrentLiability", true));
            this.currentLiabilityNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.currentLiabilityNumericEditBox, "currentLiabilityNumericEditBox");
            this.currentLiabilityNumericEditBox.Name = "currentLiabilityNumericEditBox";
            this.helpProvider1.SetShowHelp(this.currentLiabilityNumericEditBox, ((bool)(resources.GetObject("currentLiabilityNumericEditBox.ShowHelp"))));
            this.currentLiabilityNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.currentLiabilityNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // invoiceNumberEditBox
            // 
            this.invoiceNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtBindingSource, "InvoiceNumber", true));
            resources.ApplyResources(this.invoiceNumberEditBox, "invoiceNumberEditBox");
            this.invoiceNumberEditBox.MaxLength = 8;
            this.invoiceNumberEditBox.Name = "invoiceNumberEditBox";
            this.helpProvider1.SetShowHelp(this.invoiceNumberEditBox, ((bool)(resources.GetObject("invoiceNumberEditBox.ShowHelp"))));
            this.invoiceNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sequenceBalanceEditBox
            // 
            this.sequenceBalanceEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtBindingSource, "SequenceBalance", true));
            resources.ApplyResources(this.sequenceBalanceEditBox, "sequenceBalanceEditBox");
            this.sequenceBalanceEditBox.MaxLength = 2;
            this.sequenceBalanceEditBox.Name = "sequenceBalanceEditBox";
            this.helpProvider1.SetShowHelp(this.sequenceBalanceEditBox, ((bool)(resources.GetObject("sequenceBalanceEditBox.ShowHelp"))));
            this.sequenceBalanceEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // principalAmountNumericEditBox
            // 
            this.principalAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtBindingSource, "PrincipalAmount", true));
            this.principalAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.principalAmountNumericEditBox, "principalAmountNumericEditBox");
            this.principalAmountNumericEditBox.Name = "principalAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.principalAmountNumericEditBox, ((bool)(resources.GetObject("principalAmountNumericEditBox.ShowHelp"))));
            this.principalAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.principalAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucAccountTypeMcc
            // 
            this.ucAccountTypeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucAccountTypeMcc.Column1 = "AccountTypeCode";
            resources.ApplyResources(this.ucAccountTypeMcc, "ucAccountTypeMcc");
            this.ucAccountTypeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucAccountTypeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.debtBindingSource, "AccountTypeId", true));
            this.ucAccountTypeMcc.DataSource = null;
            this.ucAccountTypeMcc.DDColumn1Visible = true;
            this.ucAccountTypeMcc.DropDownColumn1Width = 100;
            this.ucAccountTypeMcc.DropDownColumn2Width = 300;
            this.ucAccountTypeMcc.Name = "ucAccountTypeMcc";
            this.ucAccountTypeMcc.ReadOnly = false;
            this.ucAccountTypeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucAccountTypeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucAccountTypeMcc, ((bool)(resources.GetObject("ucAccountTypeMcc.ShowHelp"))));
            this.ucAccountTypeMcc.ValueMember = "AccountTypeId";
            // 
            // numericEditBox1
            // 
            this.numericEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.debtBindingSource, "InterestRate", true));
            this.numericEditBox1.DecimalDigits = 3;
            resources.ApplyResources(this.numericEditBox1, "numericEditBox1");
            this.numericEditBox1.Name = "numericEditBox1";
            this.numericEditBox1.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
            this.helpProvider1.SetShowHelp(this.numericEditBox1, ((bool)(resources.GetObject("numericEditBox1.ShowHelp"))));
            this.numericEditBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // dARSOccurenceDateCalendarCombo
            // 
            resources.ApplyResources(this.dARSOccurenceDateCalendarCombo, "dARSOccurenceDateCalendarCombo");
            this.dARSOccurenceDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "DARSOccurenceDate", true));
            this.dARSOccurenceDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.dARSOccurenceDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dARSOccurenceDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dARSOccurenceDateCalendarCombo.MonthIncrement = 0;
            this.dARSOccurenceDateCalendarCombo.Name = "dARSOccurenceDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.dARSOccurenceDateCalendarCombo, ((bool)(resources.GetObject("dARSOccurenceDateCalendarCombo.ShowHelp"))));
            this.dARSOccurenceDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dARSOccurenceDateCalendarCombo.YearIncrement = 0;
            // 
            // accountHistoryBindingSource
            // 
            this.accountHistoryBindingSource.DataMember = "Debt_AccountHistory";
            this.accountHistoryBindingSource.DataSource = this.debtBindingSource;
            this.accountHistoryBindingSource.CurrentChanged += new System.EventHandler(this.accountHistoryBindingSource_CurrentChanged);
            // 
            // ucLPCodeMcc
            // 
            this.ucLPCodeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucLPCodeMcc.Column1 = "LPCode";
            resources.ApplyResources(this.ucLPCodeMcc, "ucLPCodeMcc");
            this.ucLPCodeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucLPCodeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.debtBindingSource, "LPCode", true));
            this.ucLPCodeMcc.DataSource = null;
            this.ucLPCodeMcc.DDColumn1Visible = true;
            this.ucLPCodeMcc.DropDownColumn1Width = 100;
            this.ucLPCodeMcc.DropDownColumn2Width = 300;
            this.ucLPCodeMcc.Name = "ucLPCodeMcc";
            this.ucLPCodeMcc.ReadOnly = false;
            this.ucLPCodeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucLPCodeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucLPCodeMcc, ((bool)(resources.GetObject("ucLPCodeMcc.ShowHelp"))));
            this.ucLPCodeMcc.ValueMember = "LPCode";
            // 
            // ucReturnCodeMcc
            // 
            this.ucReturnCodeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucReturnCodeMcc.Column1 = "ReturnCode";
            resources.ApplyResources(this.ucReturnCodeMcc, "ucReturnCodeMcc");
            this.ucReturnCodeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucReturnCodeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.accountHistoryBindingSource, "ReturnCode", true));
            this.ucReturnCodeMcc.DataSource = null;
            this.ucReturnCodeMcc.DDColumn1Visible = true;
            this.ucReturnCodeMcc.DropDownColumn1Width = 100;
            this.ucReturnCodeMcc.DropDownColumn2Width = 300;
            this.ucReturnCodeMcc.Name = "ucReturnCodeMcc";
            this.ucReturnCodeMcc.ReadOnly = false;
            this.ucReturnCodeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucReturnCodeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucReturnCodeMcc, ((bool)(resources.GetObject("ucReturnCodeMcc.ShowHelp"))));
            this.ucReturnCodeMcc.ValueMember = "ReturnCode";
            // 
            // sentToOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.sentToOfficeDateCalendarCombo, "sentToOfficeDateCalendarCombo");
            this.sentToOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.accountHistoryBindingSource, "SentToOfficeDate", true));
            this.sentToOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.sentToOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.sentToOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentToOfficeDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.sentToOfficeDateCalendarCombo.MonthIncrement = 0;
            this.sentToOfficeDateCalendarCombo.Name = "sentToOfficeDateCalendarCombo";
            this.sentToOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.sentToOfficeDateCalendarCombo, ((bool)(resources.GetObject("sentToOfficeDateCalendarCombo.ShowHelp"))));
            this.sentToOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentToOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // receivedByOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.receivedByOfficeDateCalendarCombo, "receivedByOfficeDateCalendarCombo");
            this.receivedByOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.accountHistoryBindingSource, "ReceivedByOfficeDate", true));
            this.receivedByOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedByOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.receivedByOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedByOfficeDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.receivedByOfficeDateCalendarCombo.MonthIncrement = 0;
            this.receivedByOfficeDateCalendarCombo.Name = "receivedByOfficeDateCalendarCombo";
            this.receivedByOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.receivedByOfficeDateCalendarCombo, ((bool)(resources.GetObject("receivedByOfficeDateCalendarCombo.ShowHelp"))));
            this.receivedByOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedByOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // returnedByOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.returnedByOfficeDateCalendarCombo, "returnedByOfficeDateCalendarCombo");
            this.returnedByOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.accountHistoryBindingSource, "ReturnedByOfficeDate", true));
            this.returnedByOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.returnedByOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.returnedByOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.returnedByOfficeDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.returnedByOfficeDateCalendarCombo.MonthIncrement = 0;
            this.returnedByOfficeDateCalendarCombo.Name = "returnedByOfficeDateCalendarCombo";
            this.returnedByOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.returnedByOfficeDateCalendarCombo, ((bool)(resources.GetObject("returnedByOfficeDateCalendarCombo.ShowHelp"))));
            this.returnedByOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.returnedByOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // receivedFromOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.receivedFromOfficeDateCalendarCombo, "receivedFromOfficeDateCalendarCombo");
            this.receivedFromOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.accountHistoryBindingSource, "ReceivedFromOfficeDate", true));
            this.receivedFromOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedFromOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.receivedFromOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedFromOfficeDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.receivedFromOfficeDateCalendarCombo.MonthIncrement = 0;
            this.receivedFromOfficeDateCalendarCombo.Name = "receivedFromOfficeDateCalendarCombo";
            this.receivedFromOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.receivedFromOfficeDateCalendarCombo, ((bool)(resources.GetObject("receivedFromOfficeDateCalendarCombo.ShowHelp"))));
            this.receivedFromOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedFromOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // accountHistoryGridEX
            // 
            this.accountHistoryGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.accountHistoryGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Crimson;
            this.accountHistoryGridEX.DataSource = this.accountHistoryBindingSource;
            accountHistoryGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("accountHistoryGridEX_DesignTimeLayout_Reference_0.Instance")));
            accountHistoryGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            accountHistoryGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(accountHistoryGridEX_DesignTimeLayout, "accountHistoryGridEX_DesignTimeLayout");
            this.accountHistoryGridEX.DesignTimeLayout = accountHistoryGridEX_DesignTimeLayout;
            this.accountHistoryGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.accountHistoryGridEX, "accountHistoryGridEX");
            this.accountHistoryGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.accountHistoryGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.accountHistoryGridEX.GroupByBoxVisible = false;
            this.accountHistoryGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.accountHistoryGridEX.Name = "accountHistoryGridEX";
            this.helpProvider1.SetShowHelp(this.accountHistoryGridEX, ((bool)(resources.GetObject("accountHistoryGridEX.ShowHelp"))));
            this.accountHistoryGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.accountHistoryGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.accountHistoryGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.accountHistoryGridEX_ColumnButtonClick);
            this.accountHistoryGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.accountHistoryGridEX_CurrentCellChanging);
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(817, 625), true);
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
            this.pnlAllContainer.Controls.Add(this.receivedByJusticeDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(this.activeWithJusticeCheckbox);
            this.pnlAllContainer.Controls.Add(receivedByJusticeDateLabel);
            this.pnlAllContainer.Controls.Add(this.uiTab2);
            this.pnlAllContainer.Controls.Add(closureDateLabel);
            this.pnlAllContainer.Controls.Add(this.uiTab1);
            this.pnlAllContainer.Controls.Add(this.ucClosureCodeMcc);
            this.pnlAllContainer.Controls.Add(this.debtGridEX);
            this.pnlAllContainer.Controls.Add(this.closureDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(closureCodeLabel);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // activeWithJusticeCheckbox
            // 
            this.activeWithJusticeCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.activeWithJusticeCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.activeWithJusticeCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "ActiveWithJustice", true));
            resources.ApplyResources(this.activeWithJusticeCheckbox, "activeWithJusticeCheckbox");
            this.activeWithJusticeCheckbox.Name = "activeWithJusticeCheckbox";
            this.helpProvider1.SetShowHelp(this.activeWithJusticeCheckbox, ((bool)(resources.GetObject("activeWithJusticeCheckbox.ShowHelp"))));
            this.activeWithJusticeCheckbox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiTab2
            // 
            resources.ApplyResources(this.uiTab2, "uiTab2");
            this.uiTab2.BackColor = System.Drawing.Color.Transparent;
            this.uiTab2.Name = "uiTab2";
            this.uiTab2.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab2.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab2, ((bool)(resources.GetObject("uiTab2.ShowHelp"))));
            this.uiTab2.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage5});
            this.uiTab2.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab2.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab2.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab2.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab2.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab2.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage5
            // 
            this.uiTabPage5.Controls.Add(label2);
            this.uiTabPage5.Controls.Add(accountTypeCodeLabel);
            this.uiTabPage5.Controls.Add(this.mSOAOverDARSUICheckBox);
            this.uiTabPage5.Controls.Add(currentLiabilityLabel);
            this.uiTabPage5.Controls.Add(this.rateTypeucMultiDropDown);
            this.uiTabPage5.Controls.Add(this.interestFromDateCalendarCombo);
            this.uiTabPage5.Controls.Add(this.interestAmountNumericEditBox);
            this.uiTabPage5.Controls.Add(interestFromDateLabel);
            this.uiTabPage5.Controls.Add(this.currentLiabilityNumericEditBox);
            this.uiTabPage5.Controls.Add(rateTypeLabel);
            this.uiTabPage5.Controls.Add(this.invoiceNumberEditBox);
            this.uiTabPage5.Controls.Add(this.currentToCalendarCombo);
            this.uiTabPage5.Controls.Add(this.sequenceBalanceEditBox);
            this.uiTabPage5.Controls.Add(interestRateLabel);
            this.uiTabPage5.Controls.Add(this.principalAmountNumericEditBox);
            this.uiTabPage5.Controls.Add(currentToLabel);
            this.uiTabPage5.Controls.Add(this.ucAccountTypeMcc);
            this.uiTabPage5.Controls.Add(interestAmountLabel);
            this.uiTabPage5.Controls.Add(invoiceNumberLabel);
            this.uiTabPage5.Controls.Add(principalAmountLabel);
            this.uiTabPage5.Controls.Add(sequenceBalanceLabel);
            this.uiTabPage5.Controls.Add(this.dARSOccurenceDateCalendarCombo);
            this.uiTabPage5.Controls.Add(dARSOccurenceDateLabel);
            this.uiTabPage5.Controls.Add(this.numericEditBox1);
            resources.ApplyResources(this.uiTabPage5, "uiTabPage5");
            this.uiTabPage5.Name = "uiTabPage5";
            this.helpProvider1.SetShowHelp(this.uiTabPage5, ((bool)(resources.GetObject("uiTabPage5.ShowHelp"))));
            this.uiTabPage5.TabStop = true;
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
            this.uiTabPage1,
            this.uiTabPage2});
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
            this.uiTabPage1.Controls.Add(this.lblStatuteBarredMessage);
            this.uiTabPage1.Controls.Add(this.uiCheckBox1);
            this.uiTabPage1.Controls.Add(label1);
            this.uiTabPage1.Controls.Add(this.LPCommentEditBox);
            this.uiTabPage1.Controls.Add(this.ucLPCodeMcc);
            this.uiTabPage1.Controls.Add(this.lPExpiresCalendarCombo);
            this.uiTabPage1.Controls.Add(lPExpiresLabel);
            this.uiTabPage1.Controls.Add(lPCodeLabel);
            this.uiTabPage1.Controls.Add(this.lPDateCalendarCombo);
            this.uiTabPage1.Controls.Add(lPDateLabel);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtBindingSource, "StatBarred", true));
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.helpProvider1.SetShowHelp(this.uiCheckBox1, ((bool)(resources.GetObject("uiCheckBox1.ShowHelp"))));
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCheckBox1.BindableValueChanged += new System.EventHandler(this.uiCheckBox1_BindableValueChanged);
            // 
            // LPCommentEditBox
            // 
            this.LPCommentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtBindingSource, "LPComment", true));
            resources.ApplyResources(this.LPCommentEditBox, "LPCommentEditBox");
            this.LPCommentEditBox.MaxLength = 0;
            this.LPCommentEditBox.Multiline = true;
            this.LPCommentEditBox.Name = "LPCommentEditBox";
            this.LPCommentEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.LPCommentEditBox, ((bool)(resources.GetObject("LPCommentEditBox.ShowHelp"))));
            this.LPCommentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiTabPage2
            // 
            this.uiTabPage2.Controls.Add(this.officeIducOfficeSelectBox);
            this.uiTabPage2.Controls.Add(sentToOfficeDateLabel);
            this.uiTabPage2.Controls.Add(this.ucReturnCodeMcc);
            this.uiTabPage2.Controls.Add(this.accountHistoryGridEX);
            this.uiTabPage2.Controls.Add(officeCodeLabel);
            this.uiTabPage2.Controls.Add(this.sentToOfficeDateCalendarCombo);
            this.uiTabPage2.Controls.Add(returnCodeLabel);
            this.uiTabPage2.Controls.Add(receivedByOfficeDateLabel);
            this.uiTabPage2.Controls.Add(this.receivedFromOfficeDateCalendarCombo);
            this.uiTabPage2.Controls.Add(this.receivedByOfficeDateCalendarCombo);
            this.uiTabPage2.Controls.Add(receivedFromOfficeDateLabel);
            this.uiTabPage2.Controls.Add(returnedByOfficeDateLabel);
            this.uiTabPage2.Controls.Add(this.returnedByOfficeDateCalendarCombo);
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            // 
            // officeIducOfficeSelectBox
            // 
            this.officeIducOfficeSelectBox.AtMng = null;
            this.officeIducOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIducOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.accountHistoryBindingSource, "OfficeId", true));
            resources.ApplyResources(this.officeIducOfficeSelectBox, "officeIducOfficeSelectBox");
            this.officeIducOfficeSelectBox.Name = "officeIducOfficeSelectBox";
            this.officeIducOfficeSelectBox.OfficeId = null;
            this.officeIducOfficeSelectBox.ReadOnly = false;
            this.officeIducOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.officeIducOfficeSelectBox, ((bool)(resources.GetObject("officeIducOfficeSelectBox.ShowHelp"))));
            // 
            // ucClosureCodeMcc
            // 
            this.ucClosureCodeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucClosureCodeMcc.Column1 = "ReturnCode";
            resources.ApplyResources(this.ucClosureCodeMcc, "ucClosureCodeMcc");
            this.ucClosureCodeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucClosureCodeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.debtBindingSource, "ClosureCode", true));
            this.ucClosureCodeMcc.DataSource = null;
            this.ucClosureCodeMcc.DDColumn1Visible = true;
            this.ucClosureCodeMcc.DropDownColumn1Width = 100;
            this.ucClosureCodeMcc.DropDownColumn2Width = 300;
            this.ucClosureCodeMcc.Name = "ucClosureCodeMcc";
            this.ucClosureCodeMcc.ReadOnly = false;
            this.ucClosureCodeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucClosureCodeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucClosureCodeMcc, ((bool)(resources.GetObject("ucClosureCodeMcc.ShowHelp"))));
            this.ucClosureCodeMcc.ValueMember = "ReturnCode";
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar3});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete,
            this.tsSave,
            this.tsScreenTitle,
            this.tsEditmode,
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit,
            this.cmdView});
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
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1,
            this.cmdView1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.MergeRowOrder = 1;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
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
            // uiCommandBar3
            // 
            this.uiCommandBar3.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode2,
            this.tsScreenTitle2,
            this.Separator2,
            this.tsSave3,
            this.tsDelete3,
            this.Separator4,
            this.tsAudit1});
            this.uiCommandBar3.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar3.MergeRowOrder = 2;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.uiCommandBar3.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            // 
            // tsEditmode2
            // 
            resources.ApplyResources(this.tsEditmode2, "tsEditmode2");
            this.tsEditmode2.Name = "tsEditmode2";
            // 
            // tsScreenTitle2
            // 
            this.tsScreenTitle2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsScreenTitle2, "tsScreenTitle2");
            this.tsScreenTitle2.Name = "tsScreenTitle2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsSave3
            // 
            resources.ApplyResources(this.tsSave3, "tsSave3");
            this.tsSave3.Name = "tsSave3";
            // 
            // tsDelete3
            // 
            resources.ApplyResources(this.tsDelete3, "tsDelete3");
            this.tsDelete3.Name = "tsDelete3";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
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
            this.tsScreenTitle.StateStyles.FormatStyle.FontSize = 8F;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.ShowInCustomizeDialog = false;
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
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
            // cmdView
            // 
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.Name = "cmdView";
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
            this.uiCommandBar2,
            this.uiCommandBar3});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Controls.Add(this.uiCommandBar3);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.accountHistoryBindingSource;
            // 
            // uiTabPage3
            // 
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // ucFileAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucFileAccount";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debtGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountHistoryGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage5.ResumeLayout(false);
            this.uiTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            this.uiTabPage2.ResumeLayout(false);
            this.uiTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private lmDatasets.CLAS CLAS;
        private System.Windows.Forms.BindingSource debtBindingSource;
        private Janus.Windows.GridEX.GridEX debtGridEX;
        private Janus.Windows.CalendarCombo.CalendarCombo interestFromDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo lPDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo lPExpiresCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo currentToCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedByJusticeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo closureDateCalendarCombo;
        private Janus.Windows.GridEX.GridEX accountHistoryGridEX;
        private System.Windows.Forms.BindingSource accountHistoryBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo sentToOfficeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedByOfficeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo returnedByOfficeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedFromOfficeDateCalendarCombo;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numericEditBox1;
        private UserControls.ucMultiDropDown ucClosureCodeMcc;
        private Janus.Windows.CalendarCombo.CalendarCombo dARSOccurenceDateCalendarCombo;
        private UserControls.ucMultiDropDown ucAccountTypeMcc;
        private UserControls.ucMultiDropDown ucLPCodeMcc;
        private UserControls.ucMultiDropDown ucReturnCodeMcc;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle2;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsSave3;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete3;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox principalAmountNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox interestAmountNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox currentLiabilityNumericEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox invoiceNumberEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox sequenceBalanceEditBox;
        private Janus.Windows.EditControls.UICheckBox mSOAOverDARSUICheckBox;
        private UserControls.ucMultiDropDown rateTypeucMultiDropDown;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private ucOfficeSelectBox officeIducOfficeSelectBox;
        private Janus.Windows.GridEX.EditControls.EditBox LPCommentEditBox;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
        private Janus.Windows.EditControls.UICheckBox activeWithJusticeCheckbox;
        private System.Windows.Forms.Label lblStatuteBarredMessage;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage5;

        
    }
}
