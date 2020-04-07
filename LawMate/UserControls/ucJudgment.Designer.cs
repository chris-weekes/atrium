 namespace LawMate
{
    partial class ucJudgment
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
                FM.GetCLASMng().DB.Judgment.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.GetCLASMng().DB.JudgmentAccount.ColumnChanged -= dt_ColumnChanged;
                FM.GetCLASMng().DB.Writ.ColumnChanged -= dt_ColumnChanged;
                FM.GetCLASMng().DB.Cost.ColumnChanged -= dt_ColumnChanged;

                FM.GetCLASMng().GetJudgment().OnUpdate -= new atLogic.UpdateEventHandler(ucJudgment_OnUpdate);
                FM.GetCLASMng().GetJudgmentAccount().OnUpdate -= ucJudgment_OnUpdate;
                FM.GetCLASMng().GetWrit().OnUpdate -= ucJudgment_OnUpdate;
                FM.GetCLASMng().GetCost().OnUpdate -= ucJudgment_OnUpdate;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucJudgment));
            System.Windows.Forms.Label postJudgmentInterestRateLabel;
            System.Windows.Forms.Label postJIntRateOnCostLabel;
            System.Windows.Forms.Label lblRateOnDateOfJ;
            System.Windows.Forms.Label accruedFromDateLabel;
            System.Windows.Forms.Label accountTypeCodeLabel;
            System.Windows.Forms.Label costDateLabel;
            System.Windows.Forms.Label postJudgmentActivityCodeLabel;
            System.Windows.Forms.Label costAmountLabel1;
            System.Windows.Forms.Label rateTypeLabel;
            System.Windows.Forms.Label interestRateLabel;
            System.Windows.Forms.Label issueRenewalDateLabel1;
            System.Windows.Forms.Label expiryDateLabel1;
            System.Windows.Forms.Label typeofWritCodeLabel1;
            System.Windows.Forms.Label officeIDLabel;
            System.Windows.Forms.Label executionorRegistrationNumberLabel1;
            System.Windows.Forms.Label sheriffJurisdictionLabel1;
            System.Windows.Forms.Label processTypeCodeLabel1;
            System.Windows.Forms.Label actionNumberLabel1;
            System.Windows.Forms.Label judgmentCourtLevelCodeLabel1;
            System.Windows.Forms.Label statementofClaimIssuedDateLabel1;
            System.Windows.Forms.Label statementofClaimServedDateLabel1;
            System.Windows.Forms.Label defenceDateLabel1;
            System.Windows.Forms.Label claimAgainstCrownLabel1;
            System.Windows.Forms.Label judgmentDateLabel1;
            System.Windows.Forms.Label officeIDLabel1;
            System.Windows.Forms.Label judgmentLPDateLabel1;
            System.Windows.Forms.Label judgmentAmountLabel2;
            System.Windows.Forms.Label judgmentTypeCodeLabel1;
            System.Windows.Forms.Label principalAmountBeforeJudgmentLabel1;
            System.Windows.Forms.Label preJudgmentInterestRateLabel1;
            System.Windows.Forms.Label preJudgmentInterestFromLabel1;
            System.Windows.Forms.Label preJudgmentInterestToLabel1;
            System.Windows.Forms.Label preJudgmentInterestAmountLabel1;
            System.Windows.Forms.Label costAmountLabel2;
            System.Windows.Forms.Label judgmentAmountLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            Janus.Windows.GridEX.GridEXLayout AccountIncludedGridEx_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout judgmentAccountGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout atriumDB_WritHistoryDataTableGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout writGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference writGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ButtonImage");
            Janus.Windows.GridEX.GridEXLayout costGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference costGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ButtonImage");
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage5 = new Janus.Windows.UI.Tab.UITabPage();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.atriumDB_JudgmentDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.judgmentDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.judgmentTypeCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.officeIDucOfficeSelectBox1 = new LawMate.ucOfficeSelectBox();
            this.judgmentAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.judgmentLPDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage4 = new Janus.Windows.UI.Tab.UITabPage();
            this.processTypeCodeucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.claimAgainstCrownCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.AccountIncludedGridEx = new Janus.Windows.GridEX.GridEX();
            this.atriumDB_JudgmentAccountDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defenceDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.actionNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.statementofClaimServedDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.judgmentCourtLevelCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.statementofClaimIssuedDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiGroupBox4 = new Janus.Windows.EditControls.UIGroupBox();
            this.postJRateTypeOnCostucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.postJIntRateOnCostNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.postJudgmentRateTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.postJudgmentInterestRateNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.accruedFromDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucAccountTypeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.uiGroupBox3 = new Janus.Windows.EditControls.UIGroupBox();
            this.judgmentAmountNumericEditBox1 = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.costAmountNumericEditBox1 = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.preJudgmentInterestAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.preJudgmentInterestToCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.preJudgmentInterestFromCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.preJudgmentRateTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.preJudgmentInterestRateNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.principalAmountBeforeJudgmentNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.judgmentAccountGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.sheriffJurisdictionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.atriumDB_WritDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.executionorRegistrationNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeIDucOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.typeofWritCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.expiryDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.issueRenewalDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.atriumDB_WritHistoryDataTableGridEX = new Janus.Windows.GridEX.GridEX();
            this.atriumDB_WritHistoryDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.writGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiGroupBox5 = new Janus.Windows.EditControls.UIGroupBox();
            this.interestRateNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.atriumDB_CostDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rateTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.costAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.postJudgmentActivityCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.costDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.costGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
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
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.errorProviderJudgmentAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderWrit = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCost = new System.Windows.Forms.ErrorProvider(this.components);
            postJudgmentInterestRateLabel = new System.Windows.Forms.Label();
            postJIntRateOnCostLabel = new System.Windows.Forms.Label();
            lblRateOnDateOfJ = new System.Windows.Forms.Label();
            accruedFromDateLabel = new System.Windows.Forms.Label();
            accountTypeCodeLabel = new System.Windows.Forms.Label();
            costDateLabel = new System.Windows.Forms.Label();
            postJudgmentActivityCodeLabel = new System.Windows.Forms.Label();
            costAmountLabel1 = new System.Windows.Forms.Label();
            rateTypeLabel = new System.Windows.Forms.Label();
            interestRateLabel = new System.Windows.Forms.Label();
            issueRenewalDateLabel1 = new System.Windows.Forms.Label();
            expiryDateLabel1 = new System.Windows.Forms.Label();
            typeofWritCodeLabel1 = new System.Windows.Forms.Label();
            officeIDLabel = new System.Windows.Forms.Label();
            executionorRegistrationNumberLabel1 = new System.Windows.Forms.Label();
            sheriffJurisdictionLabel1 = new System.Windows.Forms.Label();
            processTypeCodeLabel1 = new System.Windows.Forms.Label();
            actionNumberLabel1 = new System.Windows.Forms.Label();
            judgmentCourtLevelCodeLabel1 = new System.Windows.Forms.Label();
            statementofClaimIssuedDateLabel1 = new System.Windows.Forms.Label();
            statementofClaimServedDateLabel1 = new System.Windows.Forms.Label();
            defenceDateLabel1 = new System.Windows.Forms.Label();
            claimAgainstCrownLabel1 = new System.Windows.Forms.Label();
            judgmentDateLabel1 = new System.Windows.Forms.Label();
            officeIDLabel1 = new System.Windows.Forms.Label();
            judgmentLPDateLabel1 = new System.Windows.Forms.Label();
            judgmentAmountLabel2 = new System.Windows.Forms.Label();
            judgmentTypeCodeLabel1 = new System.Windows.Forms.Label();
            principalAmountBeforeJudgmentLabel1 = new System.Windows.Forms.Label();
            preJudgmentInterestRateLabel1 = new System.Windows.Forms.Label();
            preJudgmentInterestFromLabel1 = new System.Windows.Forms.Label();
            preJudgmentInterestToLabel1 = new System.Windows.Forms.Label();
            preJudgmentInterestAmountLabel1 = new System.Windows.Forms.Label();
            costAmountLabel2 = new System.Windows.Forms.Label();
            judgmentAmountLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_JudgmentDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountIncludedGridEx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_JudgmentAccountDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).BeginInit();
            this.uiGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.judgmentAccountGridEX)).BeginInit();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_WritDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_WritHistoryDataTableGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_WritHistoryDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writGridEX)).BeginInit();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox5)).BeginInit();
            this.uiGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CostDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderJudgmentAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWrit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCost)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.atriumDB_JudgmentDataTableBindingSource;
            resources.ApplyResources(this.errorProvider1, "errorProvider1");
            // 
            // helpProvider1
            // 
            resources.ApplyResources(this.helpProvider1, "helpProvider1");
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
            // postJudgmentInterestRateLabel
            // 
            resources.ApplyResources(postJudgmentInterestRateLabel, "postJudgmentInterestRateLabel");
            postJudgmentInterestRateLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(postJudgmentInterestRateLabel, resources.GetString("postJudgmentInterestRateLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(postJudgmentInterestRateLabel, resources.GetString("postJudgmentInterestRateLabel.Error1"));
            this.errorProviderCost.SetError(postJudgmentInterestRateLabel, resources.GetString("postJudgmentInterestRateLabel.Error2"));
            this.errorProviderWrit.SetError(postJudgmentInterestRateLabel, resources.GetString("postJudgmentInterestRateLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(postJudgmentInterestRateLabel, resources.GetString("postJudgmentInterestRateLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(postJudgmentInterestRateLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJudgmentInterestRateLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(postJudgmentInterestRateLabel, resources.GetString("postJudgmentInterestRateLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(postJudgmentInterestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(postJudgmentInterestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(postJudgmentInterestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(postJudgmentInterestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(postJudgmentInterestRateLabel, ((int)(resources.GetObject("postJudgmentInterestRateLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(postJudgmentInterestRateLabel, ((int)(resources.GetObject("postJudgmentInterestRateLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(postJudgmentInterestRateLabel, ((int)(resources.GetObject("postJudgmentInterestRateLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(postJudgmentInterestRateLabel, ((int)(resources.GetObject("postJudgmentInterestRateLabel.IconPadding3"))));
            postJudgmentInterestRateLabel.Name = "postJudgmentInterestRateLabel";
            this.helpProvider1.SetShowHelp(postJudgmentInterestRateLabel, ((bool)(resources.GetObject("postJudgmentInterestRateLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(postJudgmentInterestRateLabel, resources.GetString("postJudgmentInterestRateLabel.ToolTip"));
            // 
            // postJIntRateOnCostLabel
            // 
            resources.ApplyResources(postJIntRateOnCostLabel, "postJIntRateOnCostLabel");
            postJIntRateOnCostLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(postJIntRateOnCostLabel, resources.GetString("postJIntRateOnCostLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(postJIntRateOnCostLabel, resources.GetString("postJIntRateOnCostLabel.Error1"));
            this.errorProviderCost.SetError(postJIntRateOnCostLabel, resources.GetString("postJIntRateOnCostLabel.Error2"));
            this.errorProviderWrit.SetError(postJIntRateOnCostLabel, resources.GetString("postJIntRateOnCostLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(postJIntRateOnCostLabel, resources.GetString("postJIntRateOnCostLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(postJIntRateOnCostLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJIntRateOnCostLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(postJIntRateOnCostLabel, resources.GetString("postJIntRateOnCostLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(postJIntRateOnCostLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(postJIntRateOnCostLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(postJIntRateOnCostLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(postJIntRateOnCostLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(postJIntRateOnCostLabel, ((int)(resources.GetObject("postJIntRateOnCostLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(postJIntRateOnCostLabel, ((int)(resources.GetObject("postJIntRateOnCostLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(postJIntRateOnCostLabel, ((int)(resources.GetObject("postJIntRateOnCostLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(postJIntRateOnCostLabel, ((int)(resources.GetObject("postJIntRateOnCostLabel.IconPadding3"))));
            postJIntRateOnCostLabel.Name = "postJIntRateOnCostLabel";
            this.helpProvider1.SetShowHelp(postJIntRateOnCostLabel, ((bool)(resources.GetObject("postJIntRateOnCostLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(postJIntRateOnCostLabel, resources.GetString("postJIntRateOnCostLabel.ToolTip"));
            // 
            // lblRateOnDateOfJ
            // 
            resources.ApplyResources(lblRateOnDateOfJ, "lblRateOnDateOfJ");
            lblRateOnDateOfJ.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(lblRateOnDateOfJ, resources.GetString("lblRateOnDateOfJ.Error"));
            this.errorProviderJudgmentAccount.SetError(lblRateOnDateOfJ, resources.GetString("lblRateOnDateOfJ.Error1"));
            this.errorProviderCost.SetError(lblRateOnDateOfJ, resources.GetString("lblRateOnDateOfJ.Error2"));
            this.errorProviderWrit.SetError(lblRateOnDateOfJ, resources.GetString("lblRateOnDateOfJ.Error3"));
            this.helpProvider1.SetHelpKeyword(lblRateOnDateOfJ, resources.GetString("lblRateOnDateOfJ.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(lblRateOnDateOfJ, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("lblRateOnDateOfJ.HelpNavigator"))));
            this.helpProvider1.SetHelpString(lblRateOnDateOfJ, resources.GetString("lblRateOnDateOfJ.HelpString"));
            this.errorProvider1.SetIconAlignment(lblRateOnDateOfJ, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblRateOnDateOfJ.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(lblRateOnDateOfJ, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblRateOnDateOfJ.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(lblRateOnDateOfJ, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblRateOnDateOfJ.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(lblRateOnDateOfJ, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblRateOnDateOfJ.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(lblRateOnDateOfJ, ((int)(resources.GetObject("lblRateOnDateOfJ.IconPadding"))));
            this.errorProvider1.SetIconPadding(lblRateOnDateOfJ, ((int)(resources.GetObject("lblRateOnDateOfJ.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(lblRateOnDateOfJ, ((int)(resources.GetObject("lblRateOnDateOfJ.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(lblRateOnDateOfJ, ((int)(resources.GetObject("lblRateOnDateOfJ.IconPadding3"))));
            lblRateOnDateOfJ.Name = "lblRateOnDateOfJ";
            this.helpProvider1.SetShowHelp(lblRateOnDateOfJ, ((bool)(resources.GetObject("lblRateOnDateOfJ.ShowHelp"))));
            this.toolTip1.SetToolTip(lblRateOnDateOfJ, resources.GetString("lblRateOnDateOfJ.ToolTip"));
            // 
            // accruedFromDateLabel
            // 
            resources.ApplyResources(accruedFromDateLabel, "accruedFromDateLabel");
            accruedFromDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(accruedFromDateLabel, resources.GetString("accruedFromDateLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(accruedFromDateLabel, resources.GetString("accruedFromDateLabel.Error1"));
            this.errorProviderCost.SetError(accruedFromDateLabel, resources.GetString("accruedFromDateLabel.Error2"));
            this.errorProviderWrit.SetError(accruedFromDateLabel, resources.GetString("accruedFromDateLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(accruedFromDateLabel, resources.GetString("accruedFromDateLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(accruedFromDateLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("accruedFromDateLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(accruedFromDateLabel, resources.GetString("accruedFromDateLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(accruedFromDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(accruedFromDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(accruedFromDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(accruedFromDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(accruedFromDateLabel, ((int)(resources.GetObject("accruedFromDateLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(accruedFromDateLabel, ((int)(resources.GetObject("accruedFromDateLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(accruedFromDateLabel, ((int)(resources.GetObject("accruedFromDateLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(accruedFromDateLabel, ((int)(resources.GetObject("accruedFromDateLabel.IconPadding3"))));
            accruedFromDateLabel.Name = "accruedFromDateLabel";
            this.helpProvider1.SetShowHelp(accruedFromDateLabel, ((bool)(resources.GetObject("accruedFromDateLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(accruedFromDateLabel, resources.GetString("accruedFromDateLabel.ToolTip"));
            // 
            // accountTypeCodeLabel
            // 
            resources.ApplyResources(accountTypeCodeLabel, "accountTypeCodeLabel");
            accountTypeCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(accountTypeCodeLabel, resources.GetString("accountTypeCodeLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(accountTypeCodeLabel, resources.GetString("accountTypeCodeLabel.Error1"));
            this.errorProviderCost.SetError(accountTypeCodeLabel, resources.GetString("accountTypeCodeLabel.Error2"));
            this.errorProviderWrit.SetError(accountTypeCodeLabel, resources.GetString("accountTypeCodeLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(accountTypeCodeLabel, resources.GetString("accountTypeCodeLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(accountTypeCodeLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("accountTypeCodeLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(accountTypeCodeLabel, resources.GetString("accountTypeCodeLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(accountTypeCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accountTypeCodeLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(accountTypeCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accountTypeCodeLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(accountTypeCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accountTypeCodeLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(accountTypeCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accountTypeCodeLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(accountTypeCodeLabel, ((int)(resources.GetObject("accountTypeCodeLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(accountTypeCodeLabel, ((int)(resources.GetObject("accountTypeCodeLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(accountTypeCodeLabel, ((int)(resources.GetObject("accountTypeCodeLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(accountTypeCodeLabel, ((int)(resources.GetObject("accountTypeCodeLabel.IconPadding3"))));
            accountTypeCodeLabel.Name = "accountTypeCodeLabel";
            this.helpProvider1.SetShowHelp(accountTypeCodeLabel, ((bool)(resources.GetObject("accountTypeCodeLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(accountTypeCodeLabel, resources.GetString("accountTypeCodeLabel.ToolTip"));
            // 
            // costDateLabel
            // 
            resources.ApplyResources(costDateLabel, "costDateLabel");
            this.errorProvider1.SetError(costDateLabel, resources.GetString("costDateLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(costDateLabel, resources.GetString("costDateLabel.Error1"));
            this.errorProviderCost.SetError(costDateLabel, resources.GetString("costDateLabel.Error2"));
            this.errorProviderWrit.SetError(costDateLabel, resources.GetString("costDateLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(costDateLabel, resources.GetString("costDateLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(costDateLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("costDateLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(costDateLabel, resources.GetString("costDateLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(costDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(costDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(costDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(costDateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(costDateLabel, ((int)(resources.GetObject("costDateLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(costDateLabel, ((int)(resources.GetObject("costDateLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(costDateLabel, ((int)(resources.GetObject("costDateLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(costDateLabel, ((int)(resources.GetObject("costDateLabel.IconPadding3"))));
            costDateLabel.Name = "costDateLabel";
            this.helpProvider1.SetShowHelp(costDateLabel, ((bool)(resources.GetObject("costDateLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(costDateLabel, resources.GetString("costDateLabel.ToolTip"));
            // 
            // postJudgmentActivityCodeLabel
            // 
            resources.ApplyResources(postJudgmentActivityCodeLabel, "postJudgmentActivityCodeLabel");
            this.errorProvider1.SetError(postJudgmentActivityCodeLabel, resources.GetString("postJudgmentActivityCodeLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(postJudgmentActivityCodeLabel, resources.GetString("postJudgmentActivityCodeLabel.Error1"));
            this.errorProviderCost.SetError(postJudgmentActivityCodeLabel, resources.GetString("postJudgmentActivityCodeLabel.Error2"));
            this.errorProviderWrit.SetError(postJudgmentActivityCodeLabel, resources.GetString("postJudgmentActivityCodeLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(postJudgmentActivityCodeLabel, resources.GetString("postJudgmentActivityCodeLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(postJudgmentActivityCodeLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJudgmentActivityCodeLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(postJudgmentActivityCodeLabel, resources.GetString("postJudgmentActivityCodeLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(postJudgmentActivityCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(postJudgmentActivityCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(postJudgmentActivityCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(postJudgmentActivityCodeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(postJudgmentActivityCodeLabel, ((int)(resources.GetObject("postJudgmentActivityCodeLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(postJudgmentActivityCodeLabel, ((int)(resources.GetObject("postJudgmentActivityCodeLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(postJudgmentActivityCodeLabel, ((int)(resources.GetObject("postJudgmentActivityCodeLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(postJudgmentActivityCodeLabel, ((int)(resources.GetObject("postJudgmentActivityCodeLabel.IconPadding3"))));
            postJudgmentActivityCodeLabel.Name = "postJudgmentActivityCodeLabel";
            this.helpProvider1.SetShowHelp(postJudgmentActivityCodeLabel, ((bool)(resources.GetObject("postJudgmentActivityCodeLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(postJudgmentActivityCodeLabel, resources.GetString("postJudgmentActivityCodeLabel.ToolTip"));
            // 
            // costAmountLabel1
            // 
            resources.ApplyResources(costAmountLabel1, "costAmountLabel1");
            this.errorProvider1.SetError(costAmountLabel1, resources.GetString("costAmountLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(costAmountLabel1, resources.GetString("costAmountLabel1.Error1"));
            this.errorProviderCost.SetError(costAmountLabel1, resources.GetString("costAmountLabel1.Error2"));
            this.errorProviderWrit.SetError(costAmountLabel1, resources.GetString("costAmountLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(costAmountLabel1, resources.GetString("costAmountLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(costAmountLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("costAmountLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(costAmountLabel1, resources.GetString("costAmountLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(costAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(costAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(costAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(costAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(costAmountLabel1, ((int)(resources.GetObject("costAmountLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(costAmountLabel1, ((int)(resources.GetObject("costAmountLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(costAmountLabel1, ((int)(resources.GetObject("costAmountLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(costAmountLabel1, ((int)(resources.GetObject("costAmountLabel1.IconPadding3"))));
            costAmountLabel1.Name = "costAmountLabel1";
            this.helpProvider1.SetShowHelp(costAmountLabel1, ((bool)(resources.GetObject("costAmountLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(costAmountLabel1, resources.GetString("costAmountLabel1.ToolTip"));
            // 
            // rateTypeLabel
            // 
            resources.ApplyResources(rateTypeLabel, "rateTypeLabel");
            this.errorProvider1.SetError(rateTypeLabel, resources.GetString("rateTypeLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(rateTypeLabel, resources.GetString("rateTypeLabel.Error1"));
            this.errorProviderCost.SetError(rateTypeLabel, resources.GetString("rateTypeLabel.Error2"));
            this.errorProviderWrit.SetError(rateTypeLabel, resources.GetString("rateTypeLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(rateTypeLabel, resources.GetString("rateTypeLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(rateTypeLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rateTypeLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(rateTypeLabel, resources.GetString("rateTypeLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(rateTypeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(rateTypeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(rateTypeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(rateTypeLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(rateTypeLabel, ((int)(resources.GetObject("rateTypeLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(rateTypeLabel, ((int)(resources.GetObject("rateTypeLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(rateTypeLabel, ((int)(resources.GetObject("rateTypeLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(rateTypeLabel, ((int)(resources.GetObject("rateTypeLabel.IconPadding3"))));
            rateTypeLabel.Name = "rateTypeLabel";
            this.helpProvider1.SetShowHelp(rateTypeLabel, ((bool)(resources.GetObject("rateTypeLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(rateTypeLabel, resources.GetString("rateTypeLabel.ToolTip"));
            // 
            // interestRateLabel
            // 
            resources.ApplyResources(interestRateLabel, "interestRateLabel");
            this.errorProvider1.SetError(interestRateLabel, resources.GetString("interestRateLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(interestRateLabel, resources.GetString("interestRateLabel.Error1"));
            this.errorProviderCost.SetError(interestRateLabel, resources.GetString("interestRateLabel.Error2"));
            this.errorProviderWrit.SetError(interestRateLabel, resources.GetString("interestRateLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(interestRateLabel, resources.GetString("interestRateLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(interestRateLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("interestRateLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(interestRateLabel, resources.GetString("interestRateLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(interestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(interestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(interestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(interestRateLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(interestRateLabel, ((int)(resources.GetObject("interestRateLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(interestRateLabel, ((int)(resources.GetObject("interestRateLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(interestRateLabel, ((int)(resources.GetObject("interestRateLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(interestRateLabel, ((int)(resources.GetObject("interestRateLabel.IconPadding3"))));
            interestRateLabel.Name = "interestRateLabel";
            this.helpProvider1.SetShowHelp(interestRateLabel, ((bool)(resources.GetObject("interestRateLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(interestRateLabel, resources.GetString("interestRateLabel.ToolTip"));
            // 
            // issueRenewalDateLabel1
            // 
            resources.ApplyResources(issueRenewalDateLabel1, "issueRenewalDateLabel1");
            this.errorProvider1.SetError(issueRenewalDateLabel1, resources.GetString("issueRenewalDateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(issueRenewalDateLabel1, resources.GetString("issueRenewalDateLabel1.Error1"));
            this.errorProviderCost.SetError(issueRenewalDateLabel1, resources.GetString("issueRenewalDateLabel1.Error2"));
            this.errorProviderWrit.SetError(issueRenewalDateLabel1, resources.GetString("issueRenewalDateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(issueRenewalDateLabel1, resources.GetString("issueRenewalDateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(issueRenewalDateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("issueRenewalDateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(issueRenewalDateLabel1, resources.GetString("issueRenewalDateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(issueRenewalDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(issueRenewalDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(issueRenewalDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(issueRenewalDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(issueRenewalDateLabel1, ((int)(resources.GetObject("issueRenewalDateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(issueRenewalDateLabel1, ((int)(resources.GetObject("issueRenewalDateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(issueRenewalDateLabel1, ((int)(resources.GetObject("issueRenewalDateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(issueRenewalDateLabel1, ((int)(resources.GetObject("issueRenewalDateLabel1.IconPadding3"))));
            issueRenewalDateLabel1.Name = "issueRenewalDateLabel1";
            this.helpProvider1.SetShowHelp(issueRenewalDateLabel1, ((bool)(resources.GetObject("issueRenewalDateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(issueRenewalDateLabel1, resources.GetString("issueRenewalDateLabel1.ToolTip"));
            // 
            // expiryDateLabel1
            // 
            resources.ApplyResources(expiryDateLabel1, "expiryDateLabel1");
            this.errorProvider1.SetError(expiryDateLabel1, resources.GetString("expiryDateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(expiryDateLabel1, resources.GetString("expiryDateLabel1.Error1"));
            this.errorProviderCost.SetError(expiryDateLabel1, resources.GetString("expiryDateLabel1.Error2"));
            this.errorProviderWrit.SetError(expiryDateLabel1, resources.GetString("expiryDateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(expiryDateLabel1, resources.GetString("expiryDateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(expiryDateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("expiryDateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(expiryDateLabel1, resources.GetString("expiryDateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(expiryDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(expiryDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(expiryDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(expiryDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(expiryDateLabel1, ((int)(resources.GetObject("expiryDateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(expiryDateLabel1, ((int)(resources.GetObject("expiryDateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(expiryDateLabel1, ((int)(resources.GetObject("expiryDateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(expiryDateLabel1, ((int)(resources.GetObject("expiryDateLabel1.IconPadding3"))));
            expiryDateLabel1.Name = "expiryDateLabel1";
            this.helpProvider1.SetShowHelp(expiryDateLabel1, ((bool)(resources.GetObject("expiryDateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(expiryDateLabel1, resources.GetString("expiryDateLabel1.ToolTip"));
            // 
            // typeofWritCodeLabel1
            // 
            resources.ApplyResources(typeofWritCodeLabel1, "typeofWritCodeLabel1");
            this.errorProvider1.SetError(typeofWritCodeLabel1, resources.GetString("typeofWritCodeLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(typeofWritCodeLabel1, resources.GetString("typeofWritCodeLabel1.Error1"));
            this.errorProviderCost.SetError(typeofWritCodeLabel1, resources.GetString("typeofWritCodeLabel1.Error2"));
            this.errorProviderWrit.SetError(typeofWritCodeLabel1, resources.GetString("typeofWritCodeLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(typeofWritCodeLabel1, resources.GetString("typeofWritCodeLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(typeofWritCodeLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("typeofWritCodeLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(typeofWritCodeLabel1, resources.GetString("typeofWritCodeLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(typeofWritCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(typeofWritCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(typeofWritCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(typeofWritCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(typeofWritCodeLabel1, ((int)(resources.GetObject("typeofWritCodeLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(typeofWritCodeLabel1, ((int)(resources.GetObject("typeofWritCodeLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(typeofWritCodeLabel1, ((int)(resources.GetObject("typeofWritCodeLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(typeofWritCodeLabel1, ((int)(resources.GetObject("typeofWritCodeLabel1.IconPadding3"))));
            typeofWritCodeLabel1.Name = "typeofWritCodeLabel1";
            this.helpProvider1.SetShowHelp(typeofWritCodeLabel1, ((bool)(resources.GetObject("typeofWritCodeLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(typeofWritCodeLabel1, resources.GetString("typeofWritCodeLabel1.ToolTip"));
            // 
            // officeIDLabel
            // 
            resources.ApplyResources(officeIDLabel, "officeIDLabel");
            this.errorProvider1.SetError(officeIDLabel, resources.GetString("officeIDLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(officeIDLabel, resources.GetString("officeIDLabel.Error1"));
            this.errorProviderCost.SetError(officeIDLabel, resources.GetString("officeIDLabel.Error2"));
            this.errorProviderWrit.SetError(officeIDLabel, resources.GetString("officeIDLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(officeIDLabel, resources.GetString("officeIDLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(officeIDLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("officeIDLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(officeIDLabel, resources.GetString("officeIDLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(officeIDLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(officeIDLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(officeIDLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(officeIDLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(officeIDLabel, ((int)(resources.GetObject("officeIDLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(officeIDLabel, ((int)(resources.GetObject("officeIDLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(officeIDLabel, ((int)(resources.GetObject("officeIDLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(officeIDLabel, ((int)(resources.GetObject("officeIDLabel.IconPadding3"))));
            officeIDLabel.Name = "officeIDLabel";
            this.helpProvider1.SetShowHelp(officeIDLabel, ((bool)(resources.GetObject("officeIDLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(officeIDLabel, resources.GetString("officeIDLabel.ToolTip"));
            // 
            // executionorRegistrationNumberLabel1
            // 
            resources.ApplyResources(executionorRegistrationNumberLabel1, "executionorRegistrationNumberLabel1");
            this.errorProvider1.SetError(executionorRegistrationNumberLabel1, resources.GetString("executionorRegistrationNumberLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(executionorRegistrationNumberLabel1, resources.GetString("executionorRegistrationNumberLabel1.Error1"));
            this.errorProviderCost.SetError(executionorRegistrationNumberLabel1, resources.GetString("executionorRegistrationNumberLabel1.Error2"));
            this.errorProviderWrit.SetError(executionorRegistrationNumberLabel1, resources.GetString("executionorRegistrationNumberLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(executionorRegistrationNumberLabel1, resources.GetString("executionorRegistrationNumberLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(executionorRegistrationNumberLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("executionorRegistrationNumberLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(executionorRegistrationNumberLabel1, resources.GetString("executionorRegistrationNumberLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(executionorRegistrationNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(executionorRegistrationNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(executionorRegistrationNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(executionorRegistrationNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(executionorRegistrationNumberLabel1, ((int)(resources.GetObject("executionorRegistrationNumberLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(executionorRegistrationNumberLabel1, ((int)(resources.GetObject("executionorRegistrationNumberLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(executionorRegistrationNumberLabel1, ((int)(resources.GetObject("executionorRegistrationNumberLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(executionorRegistrationNumberLabel1, ((int)(resources.GetObject("executionorRegistrationNumberLabel1.IconPadding3"))));
            executionorRegistrationNumberLabel1.Name = "executionorRegistrationNumberLabel1";
            this.helpProvider1.SetShowHelp(executionorRegistrationNumberLabel1, ((bool)(resources.GetObject("executionorRegistrationNumberLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(executionorRegistrationNumberLabel1, resources.GetString("executionorRegistrationNumberLabel1.ToolTip"));
            // 
            // sheriffJurisdictionLabel1
            // 
            resources.ApplyResources(sheriffJurisdictionLabel1, "sheriffJurisdictionLabel1");
            this.errorProvider1.SetError(sheriffJurisdictionLabel1, resources.GetString("sheriffJurisdictionLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(sheriffJurisdictionLabel1, resources.GetString("sheriffJurisdictionLabel1.Error1"));
            this.errorProviderCost.SetError(sheriffJurisdictionLabel1, resources.GetString("sheriffJurisdictionLabel1.Error2"));
            this.errorProviderWrit.SetError(sheriffJurisdictionLabel1, resources.GetString("sheriffJurisdictionLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(sheriffJurisdictionLabel1, resources.GetString("sheriffJurisdictionLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(sheriffJurisdictionLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("sheriffJurisdictionLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(sheriffJurisdictionLabel1, resources.GetString("sheriffJurisdictionLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(sheriffJurisdictionLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(sheriffJurisdictionLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(sheriffJurisdictionLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(sheriffJurisdictionLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(sheriffJurisdictionLabel1, ((int)(resources.GetObject("sheriffJurisdictionLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(sheriffJurisdictionLabel1, ((int)(resources.GetObject("sheriffJurisdictionLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(sheriffJurisdictionLabel1, ((int)(resources.GetObject("sheriffJurisdictionLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(sheriffJurisdictionLabel1, ((int)(resources.GetObject("sheriffJurisdictionLabel1.IconPadding3"))));
            sheriffJurisdictionLabel1.Name = "sheriffJurisdictionLabel1";
            this.helpProvider1.SetShowHelp(sheriffJurisdictionLabel1, ((bool)(resources.GetObject("sheriffJurisdictionLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(sheriffJurisdictionLabel1, resources.GetString("sheriffJurisdictionLabel1.ToolTip"));
            // 
            // processTypeCodeLabel1
            // 
            resources.ApplyResources(processTypeCodeLabel1, "processTypeCodeLabel1");
            processTypeCodeLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(processTypeCodeLabel1, resources.GetString("processTypeCodeLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(processTypeCodeLabel1, resources.GetString("processTypeCodeLabel1.Error1"));
            this.errorProviderCost.SetError(processTypeCodeLabel1, resources.GetString("processTypeCodeLabel1.Error2"));
            this.errorProviderWrit.SetError(processTypeCodeLabel1, resources.GetString("processTypeCodeLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(processTypeCodeLabel1, resources.GetString("processTypeCodeLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(processTypeCodeLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("processTypeCodeLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(processTypeCodeLabel1, resources.GetString("processTypeCodeLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(processTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(processTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(processTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(processTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(processTypeCodeLabel1, ((int)(resources.GetObject("processTypeCodeLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(processTypeCodeLabel1, ((int)(resources.GetObject("processTypeCodeLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(processTypeCodeLabel1, ((int)(resources.GetObject("processTypeCodeLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(processTypeCodeLabel1, ((int)(resources.GetObject("processTypeCodeLabel1.IconPadding3"))));
            processTypeCodeLabel1.Name = "processTypeCodeLabel1";
            this.helpProvider1.SetShowHelp(processTypeCodeLabel1, ((bool)(resources.GetObject("processTypeCodeLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(processTypeCodeLabel1, resources.GetString("processTypeCodeLabel1.ToolTip"));
            // 
            // actionNumberLabel1
            // 
            resources.ApplyResources(actionNumberLabel1, "actionNumberLabel1");
            actionNumberLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(actionNumberLabel1, resources.GetString("actionNumberLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(actionNumberLabel1, resources.GetString("actionNumberLabel1.Error1"));
            this.errorProviderCost.SetError(actionNumberLabel1, resources.GetString("actionNumberLabel1.Error2"));
            this.errorProviderWrit.SetError(actionNumberLabel1, resources.GetString("actionNumberLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(actionNumberLabel1, resources.GetString("actionNumberLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(actionNumberLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("actionNumberLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(actionNumberLabel1, resources.GetString("actionNumberLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(actionNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(actionNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(actionNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(actionNumberLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(actionNumberLabel1, ((int)(resources.GetObject("actionNumberLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(actionNumberLabel1, ((int)(resources.GetObject("actionNumberLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(actionNumberLabel1, ((int)(resources.GetObject("actionNumberLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(actionNumberLabel1, ((int)(resources.GetObject("actionNumberLabel1.IconPadding3"))));
            actionNumberLabel1.Name = "actionNumberLabel1";
            this.helpProvider1.SetShowHelp(actionNumberLabel1, ((bool)(resources.GetObject("actionNumberLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(actionNumberLabel1, resources.GetString("actionNumberLabel1.ToolTip"));
            // 
            // judgmentCourtLevelCodeLabel1
            // 
            resources.ApplyResources(judgmentCourtLevelCodeLabel1, "judgmentCourtLevelCodeLabel1");
            judgmentCourtLevelCodeLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(judgmentCourtLevelCodeLabel1, resources.GetString("judgmentCourtLevelCodeLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(judgmentCourtLevelCodeLabel1, resources.GetString("judgmentCourtLevelCodeLabel1.Error1"));
            this.errorProviderCost.SetError(judgmentCourtLevelCodeLabel1, resources.GetString("judgmentCourtLevelCodeLabel1.Error2"));
            this.errorProviderWrit.SetError(judgmentCourtLevelCodeLabel1, resources.GetString("judgmentCourtLevelCodeLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(judgmentCourtLevelCodeLabel1, resources.GetString("judgmentCourtLevelCodeLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(judgmentCourtLevelCodeLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentCourtLevelCodeLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(judgmentCourtLevelCodeLabel1, resources.GetString("judgmentCourtLevelCodeLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(judgmentCourtLevelCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(judgmentCourtLevelCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(judgmentCourtLevelCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(judgmentCourtLevelCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(judgmentCourtLevelCodeLabel1, ((int)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(judgmentCourtLevelCodeLabel1, ((int)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(judgmentCourtLevelCodeLabel1, ((int)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(judgmentCourtLevelCodeLabel1, ((int)(resources.GetObject("judgmentCourtLevelCodeLabel1.IconPadding3"))));
            judgmentCourtLevelCodeLabel1.Name = "judgmentCourtLevelCodeLabel1";
            this.helpProvider1.SetShowHelp(judgmentCourtLevelCodeLabel1, ((bool)(resources.GetObject("judgmentCourtLevelCodeLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(judgmentCourtLevelCodeLabel1, resources.GetString("judgmentCourtLevelCodeLabel1.ToolTip"));
            // 
            // statementofClaimIssuedDateLabel1
            // 
            resources.ApplyResources(statementofClaimIssuedDateLabel1, "statementofClaimIssuedDateLabel1");
            statementofClaimIssuedDateLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(statementofClaimIssuedDateLabel1, resources.GetString("statementofClaimIssuedDateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(statementofClaimIssuedDateLabel1, resources.GetString("statementofClaimIssuedDateLabel1.Error1"));
            this.errorProviderCost.SetError(statementofClaimIssuedDateLabel1, resources.GetString("statementofClaimIssuedDateLabel1.Error2"));
            this.errorProviderWrit.SetError(statementofClaimIssuedDateLabel1, resources.GetString("statementofClaimIssuedDateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(statementofClaimIssuedDateLabel1, resources.GetString("statementofClaimIssuedDateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(statementofClaimIssuedDateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("statementofClaimIssuedDateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(statementofClaimIssuedDateLabel1, resources.GetString("statementofClaimIssuedDateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(statementofClaimIssuedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(statementofClaimIssuedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(statementofClaimIssuedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(statementofClaimIssuedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(statementofClaimIssuedDateLabel1, ((int)(resources.GetObject("statementofClaimIssuedDateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(statementofClaimIssuedDateLabel1, ((int)(resources.GetObject("statementofClaimIssuedDateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(statementofClaimIssuedDateLabel1, ((int)(resources.GetObject("statementofClaimIssuedDateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(statementofClaimIssuedDateLabel1, ((int)(resources.GetObject("statementofClaimIssuedDateLabel1.IconPadding3"))));
            statementofClaimIssuedDateLabel1.Name = "statementofClaimIssuedDateLabel1";
            this.helpProvider1.SetShowHelp(statementofClaimIssuedDateLabel1, ((bool)(resources.GetObject("statementofClaimIssuedDateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(statementofClaimIssuedDateLabel1, resources.GetString("statementofClaimIssuedDateLabel1.ToolTip"));
            // 
            // statementofClaimServedDateLabel1
            // 
            resources.ApplyResources(statementofClaimServedDateLabel1, "statementofClaimServedDateLabel1");
            statementofClaimServedDateLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(statementofClaimServedDateLabel1, resources.GetString("statementofClaimServedDateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(statementofClaimServedDateLabel1, resources.GetString("statementofClaimServedDateLabel1.Error1"));
            this.errorProviderCost.SetError(statementofClaimServedDateLabel1, resources.GetString("statementofClaimServedDateLabel1.Error2"));
            this.errorProviderWrit.SetError(statementofClaimServedDateLabel1, resources.GetString("statementofClaimServedDateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(statementofClaimServedDateLabel1, resources.GetString("statementofClaimServedDateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(statementofClaimServedDateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("statementofClaimServedDateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(statementofClaimServedDateLabel1, resources.GetString("statementofClaimServedDateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(statementofClaimServedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(statementofClaimServedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(statementofClaimServedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(statementofClaimServedDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(statementofClaimServedDateLabel1, ((int)(resources.GetObject("statementofClaimServedDateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(statementofClaimServedDateLabel1, ((int)(resources.GetObject("statementofClaimServedDateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(statementofClaimServedDateLabel1, ((int)(resources.GetObject("statementofClaimServedDateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(statementofClaimServedDateLabel1, ((int)(resources.GetObject("statementofClaimServedDateLabel1.IconPadding3"))));
            statementofClaimServedDateLabel1.Name = "statementofClaimServedDateLabel1";
            this.helpProvider1.SetShowHelp(statementofClaimServedDateLabel1, ((bool)(resources.GetObject("statementofClaimServedDateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(statementofClaimServedDateLabel1, resources.GetString("statementofClaimServedDateLabel1.ToolTip"));
            // 
            // defenceDateLabel1
            // 
            resources.ApplyResources(defenceDateLabel1, "defenceDateLabel1");
            defenceDateLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(defenceDateLabel1, resources.GetString("defenceDateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(defenceDateLabel1, resources.GetString("defenceDateLabel1.Error1"));
            this.errorProviderCost.SetError(defenceDateLabel1, resources.GetString("defenceDateLabel1.Error2"));
            this.errorProviderWrit.SetError(defenceDateLabel1, resources.GetString("defenceDateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(defenceDateLabel1, resources.GetString("defenceDateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(defenceDateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("defenceDateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(defenceDateLabel1, resources.GetString("defenceDateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(defenceDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(defenceDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(defenceDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(defenceDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(defenceDateLabel1, ((int)(resources.GetObject("defenceDateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(defenceDateLabel1, ((int)(resources.GetObject("defenceDateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(defenceDateLabel1, ((int)(resources.GetObject("defenceDateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(defenceDateLabel1, ((int)(resources.GetObject("defenceDateLabel1.IconPadding3"))));
            defenceDateLabel1.Name = "defenceDateLabel1";
            this.helpProvider1.SetShowHelp(defenceDateLabel1, ((bool)(resources.GetObject("defenceDateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(defenceDateLabel1, resources.GetString("defenceDateLabel1.ToolTip"));
            // 
            // claimAgainstCrownLabel1
            // 
            resources.ApplyResources(claimAgainstCrownLabel1, "claimAgainstCrownLabel1");
            claimAgainstCrownLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(claimAgainstCrownLabel1, resources.GetString("claimAgainstCrownLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(claimAgainstCrownLabel1, resources.GetString("claimAgainstCrownLabel1.Error1"));
            this.errorProviderCost.SetError(claimAgainstCrownLabel1, resources.GetString("claimAgainstCrownLabel1.Error2"));
            this.errorProviderWrit.SetError(claimAgainstCrownLabel1, resources.GetString("claimAgainstCrownLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(claimAgainstCrownLabel1, resources.GetString("claimAgainstCrownLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(claimAgainstCrownLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("claimAgainstCrownLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(claimAgainstCrownLabel1, resources.GetString("claimAgainstCrownLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(claimAgainstCrownLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(claimAgainstCrownLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(claimAgainstCrownLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(claimAgainstCrownLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(claimAgainstCrownLabel1, ((int)(resources.GetObject("claimAgainstCrownLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(claimAgainstCrownLabel1, ((int)(resources.GetObject("claimAgainstCrownLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(claimAgainstCrownLabel1, ((int)(resources.GetObject("claimAgainstCrownLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(claimAgainstCrownLabel1, ((int)(resources.GetObject("claimAgainstCrownLabel1.IconPadding3"))));
            claimAgainstCrownLabel1.Name = "claimAgainstCrownLabel1";
            this.helpProvider1.SetShowHelp(claimAgainstCrownLabel1, ((bool)(resources.GetObject("claimAgainstCrownLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(claimAgainstCrownLabel1, resources.GetString("claimAgainstCrownLabel1.ToolTip"));
            // 
            // judgmentDateLabel1
            // 
            resources.ApplyResources(judgmentDateLabel1, "judgmentDateLabel1");
            judgmentDateLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(judgmentDateLabel1, resources.GetString("judgmentDateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(judgmentDateLabel1, resources.GetString("judgmentDateLabel1.Error1"));
            this.errorProviderCost.SetError(judgmentDateLabel1, resources.GetString("judgmentDateLabel1.Error2"));
            this.errorProviderWrit.SetError(judgmentDateLabel1, resources.GetString("judgmentDateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(judgmentDateLabel1, resources.GetString("judgmentDateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(judgmentDateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentDateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(judgmentDateLabel1, resources.GetString("judgmentDateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(judgmentDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(judgmentDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(judgmentDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(judgmentDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(judgmentDateLabel1, ((int)(resources.GetObject("judgmentDateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(judgmentDateLabel1, ((int)(resources.GetObject("judgmentDateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(judgmentDateLabel1, ((int)(resources.GetObject("judgmentDateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(judgmentDateLabel1, ((int)(resources.GetObject("judgmentDateLabel1.IconPadding3"))));
            judgmentDateLabel1.Name = "judgmentDateLabel1";
            this.helpProvider1.SetShowHelp(judgmentDateLabel1, ((bool)(resources.GetObject("judgmentDateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(judgmentDateLabel1, resources.GetString("judgmentDateLabel1.ToolTip"));
            // 
            // officeIDLabel1
            // 
            resources.ApplyResources(officeIDLabel1, "officeIDLabel1");
            officeIDLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(officeIDLabel1, resources.GetString("officeIDLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(officeIDLabel1, resources.GetString("officeIDLabel1.Error1"));
            this.errorProviderCost.SetError(officeIDLabel1, resources.GetString("officeIDLabel1.Error2"));
            this.errorProviderWrit.SetError(officeIDLabel1, resources.GetString("officeIDLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(officeIDLabel1, resources.GetString("officeIDLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(officeIDLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("officeIDLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(officeIDLabel1, resources.GetString("officeIDLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(officeIDLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(officeIDLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(officeIDLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(officeIDLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(officeIDLabel1, ((int)(resources.GetObject("officeIDLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(officeIDLabel1, ((int)(resources.GetObject("officeIDLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(officeIDLabel1, ((int)(resources.GetObject("officeIDLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(officeIDLabel1, ((int)(resources.GetObject("officeIDLabel1.IconPadding3"))));
            officeIDLabel1.Name = "officeIDLabel1";
            this.helpProvider1.SetShowHelp(officeIDLabel1, ((bool)(resources.GetObject("officeIDLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(officeIDLabel1, resources.GetString("officeIDLabel1.ToolTip"));
            // 
            // judgmentLPDateLabel1
            // 
            resources.ApplyResources(judgmentLPDateLabel1, "judgmentLPDateLabel1");
            judgmentLPDateLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(judgmentLPDateLabel1, resources.GetString("judgmentLPDateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(judgmentLPDateLabel1, resources.GetString("judgmentLPDateLabel1.Error1"));
            this.errorProviderCost.SetError(judgmentLPDateLabel1, resources.GetString("judgmentLPDateLabel1.Error2"));
            this.errorProviderWrit.SetError(judgmentLPDateLabel1, resources.GetString("judgmentLPDateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(judgmentLPDateLabel1, resources.GetString("judgmentLPDateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(judgmentLPDateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentLPDateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(judgmentLPDateLabel1, resources.GetString("judgmentLPDateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(judgmentLPDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(judgmentLPDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(judgmentLPDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(judgmentLPDateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(judgmentLPDateLabel1, ((int)(resources.GetObject("judgmentLPDateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(judgmentLPDateLabel1, ((int)(resources.GetObject("judgmentLPDateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(judgmentLPDateLabel1, ((int)(resources.GetObject("judgmentLPDateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(judgmentLPDateLabel1, ((int)(resources.GetObject("judgmentLPDateLabel1.IconPadding3"))));
            judgmentLPDateLabel1.Name = "judgmentLPDateLabel1";
            this.helpProvider1.SetShowHelp(judgmentLPDateLabel1, ((bool)(resources.GetObject("judgmentLPDateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(judgmentLPDateLabel1, resources.GetString("judgmentLPDateLabel1.ToolTip"));
            // 
            // judgmentAmountLabel2
            // 
            resources.ApplyResources(judgmentAmountLabel2, "judgmentAmountLabel2");
            judgmentAmountLabel2.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(judgmentAmountLabel2, resources.GetString("judgmentAmountLabel2.Error"));
            this.errorProviderJudgmentAccount.SetError(judgmentAmountLabel2, resources.GetString("judgmentAmountLabel2.Error1"));
            this.errorProviderCost.SetError(judgmentAmountLabel2, resources.GetString("judgmentAmountLabel2.Error2"));
            this.errorProviderWrit.SetError(judgmentAmountLabel2, resources.GetString("judgmentAmountLabel2.Error3"));
            this.helpProvider1.SetHelpKeyword(judgmentAmountLabel2, resources.GetString("judgmentAmountLabel2.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(judgmentAmountLabel2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentAmountLabel2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(judgmentAmountLabel2, resources.GetString("judgmentAmountLabel2.HelpString"));
            this.errorProvider1.SetIconAlignment(judgmentAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel2.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(judgmentAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel2.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(judgmentAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel2.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(judgmentAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel2.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(judgmentAmountLabel2, ((int)(resources.GetObject("judgmentAmountLabel2.IconPadding"))));
            this.errorProvider1.SetIconPadding(judgmentAmountLabel2, ((int)(resources.GetObject("judgmentAmountLabel2.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(judgmentAmountLabel2, ((int)(resources.GetObject("judgmentAmountLabel2.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(judgmentAmountLabel2, ((int)(resources.GetObject("judgmentAmountLabel2.IconPadding3"))));
            judgmentAmountLabel2.Name = "judgmentAmountLabel2";
            this.helpProvider1.SetShowHelp(judgmentAmountLabel2, ((bool)(resources.GetObject("judgmentAmountLabel2.ShowHelp"))));
            this.toolTip1.SetToolTip(judgmentAmountLabel2, resources.GetString("judgmentAmountLabel2.ToolTip"));
            // 
            // judgmentTypeCodeLabel1
            // 
            resources.ApplyResources(judgmentTypeCodeLabel1, "judgmentTypeCodeLabel1");
            judgmentTypeCodeLabel1.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(judgmentTypeCodeLabel1, resources.GetString("judgmentTypeCodeLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(judgmentTypeCodeLabel1, resources.GetString("judgmentTypeCodeLabel1.Error1"));
            this.errorProviderCost.SetError(judgmentTypeCodeLabel1, resources.GetString("judgmentTypeCodeLabel1.Error2"));
            this.errorProviderWrit.SetError(judgmentTypeCodeLabel1, resources.GetString("judgmentTypeCodeLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(judgmentTypeCodeLabel1, resources.GetString("judgmentTypeCodeLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(judgmentTypeCodeLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentTypeCodeLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(judgmentTypeCodeLabel1, resources.GetString("judgmentTypeCodeLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(judgmentTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(judgmentTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(judgmentTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(judgmentTypeCodeLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(judgmentTypeCodeLabel1, ((int)(resources.GetObject("judgmentTypeCodeLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(judgmentTypeCodeLabel1, ((int)(resources.GetObject("judgmentTypeCodeLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(judgmentTypeCodeLabel1, ((int)(resources.GetObject("judgmentTypeCodeLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(judgmentTypeCodeLabel1, ((int)(resources.GetObject("judgmentTypeCodeLabel1.IconPadding3"))));
            judgmentTypeCodeLabel1.Name = "judgmentTypeCodeLabel1";
            this.helpProvider1.SetShowHelp(judgmentTypeCodeLabel1, ((bool)(resources.GetObject("judgmentTypeCodeLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(judgmentTypeCodeLabel1, resources.GetString("judgmentTypeCodeLabel1.ToolTip"));
            // 
            // principalAmountBeforeJudgmentLabel1
            // 
            resources.ApplyResources(principalAmountBeforeJudgmentLabel1, "principalAmountBeforeJudgmentLabel1");
            this.errorProvider1.SetError(principalAmountBeforeJudgmentLabel1, resources.GetString("principalAmountBeforeJudgmentLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(principalAmountBeforeJudgmentLabel1, resources.GetString("principalAmountBeforeJudgmentLabel1.Error1"));
            this.errorProviderCost.SetError(principalAmountBeforeJudgmentLabel1, resources.GetString("principalAmountBeforeJudgmentLabel1.Error2"));
            this.errorProviderWrit.SetError(principalAmountBeforeJudgmentLabel1, resources.GetString("principalAmountBeforeJudgmentLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(principalAmountBeforeJudgmentLabel1, resources.GetString("principalAmountBeforeJudgmentLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(principalAmountBeforeJudgmentLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("principalAmountBeforeJudgmentLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(principalAmountBeforeJudgmentLabel1, resources.GetString("principalAmountBeforeJudgmentLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(principalAmountBeforeJudgmentLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(principalAmountBeforeJudgmentLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(principalAmountBeforeJudgmentLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(principalAmountBeforeJudgmentLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(principalAmountBeforeJudgmentLabel1, ((int)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(principalAmountBeforeJudgmentLabel1, ((int)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(principalAmountBeforeJudgmentLabel1, ((int)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(principalAmountBeforeJudgmentLabel1, ((int)(resources.GetObject("principalAmountBeforeJudgmentLabel1.IconPadding3"))));
            principalAmountBeforeJudgmentLabel1.Name = "principalAmountBeforeJudgmentLabel1";
            this.helpProvider1.SetShowHelp(principalAmountBeforeJudgmentLabel1, ((bool)(resources.GetObject("principalAmountBeforeJudgmentLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(principalAmountBeforeJudgmentLabel1, resources.GetString("principalAmountBeforeJudgmentLabel1.ToolTip"));
            // 
            // preJudgmentInterestRateLabel1
            // 
            resources.ApplyResources(preJudgmentInterestRateLabel1, "preJudgmentInterestRateLabel1");
            this.errorProvider1.SetError(preJudgmentInterestRateLabel1, resources.GetString("preJudgmentInterestRateLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(preJudgmentInterestRateLabel1, resources.GetString("preJudgmentInterestRateLabel1.Error1"));
            this.errorProviderCost.SetError(preJudgmentInterestRateLabel1, resources.GetString("preJudgmentInterestRateLabel1.Error2"));
            this.errorProviderWrit.SetError(preJudgmentInterestRateLabel1, resources.GetString("preJudgmentInterestRateLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(preJudgmentInterestRateLabel1, resources.GetString("preJudgmentInterestRateLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(preJudgmentInterestRateLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestRateLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(preJudgmentInterestRateLabel1, resources.GetString("preJudgmentInterestRateLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(preJudgmentInterestRateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(preJudgmentInterestRateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(preJudgmentInterestRateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(preJudgmentInterestRateLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(preJudgmentInterestRateLabel1, ((int)(resources.GetObject("preJudgmentInterestRateLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(preJudgmentInterestRateLabel1, ((int)(resources.GetObject("preJudgmentInterestRateLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(preJudgmentInterestRateLabel1, ((int)(resources.GetObject("preJudgmentInterestRateLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(preJudgmentInterestRateLabel1, ((int)(resources.GetObject("preJudgmentInterestRateLabel1.IconPadding3"))));
            preJudgmentInterestRateLabel1.Name = "preJudgmentInterestRateLabel1";
            this.helpProvider1.SetShowHelp(preJudgmentInterestRateLabel1, ((bool)(resources.GetObject("preJudgmentInterestRateLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(preJudgmentInterestRateLabel1, resources.GetString("preJudgmentInterestRateLabel1.ToolTip"));
            // 
            // preJudgmentInterestFromLabel1
            // 
            resources.ApplyResources(preJudgmentInterestFromLabel1, "preJudgmentInterestFromLabel1");
            this.errorProvider1.SetError(preJudgmentInterestFromLabel1, resources.GetString("preJudgmentInterestFromLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(preJudgmentInterestFromLabel1, resources.GetString("preJudgmentInterestFromLabel1.Error1"));
            this.errorProviderCost.SetError(preJudgmentInterestFromLabel1, resources.GetString("preJudgmentInterestFromLabel1.Error2"));
            this.errorProviderWrit.SetError(preJudgmentInterestFromLabel1, resources.GetString("preJudgmentInterestFromLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(preJudgmentInterestFromLabel1, resources.GetString("preJudgmentInterestFromLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(preJudgmentInterestFromLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestFromLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(preJudgmentInterestFromLabel1, resources.GetString("preJudgmentInterestFromLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(preJudgmentInterestFromLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(preJudgmentInterestFromLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(preJudgmentInterestFromLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(preJudgmentInterestFromLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(preJudgmentInterestFromLabel1, ((int)(resources.GetObject("preJudgmentInterestFromLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(preJudgmentInterestFromLabel1, ((int)(resources.GetObject("preJudgmentInterestFromLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(preJudgmentInterestFromLabel1, ((int)(resources.GetObject("preJudgmentInterestFromLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(preJudgmentInterestFromLabel1, ((int)(resources.GetObject("preJudgmentInterestFromLabel1.IconPadding3"))));
            preJudgmentInterestFromLabel1.Name = "preJudgmentInterestFromLabel1";
            this.helpProvider1.SetShowHelp(preJudgmentInterestFromLabel1, ((bool)(resources.GetObject("preJudgmentInterestFromLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(preJudgmentInterestFromLabel1, resources.GetString("preJudgmentInterestFromLabel1.ToolTip"));
            // 
            // preJudgmentInterestToLabel1
            // 
            resources.ApplyResources(preJudgmentInterestToLabel1, "preJudgmentInterestToLabel1");
            this.errorProvider1.SetError(preJudgmentInterestToLabel1, resources.GetString("preJudgmentInterestToLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(preJudgmentInterestToLabel1, resources.GetString("preJudgmentInterestToLabel1.Error1"));
            this.errorProviderCost.SetError(preJudgmentInterestToLabel1, resources.GetString("preJudgmentInterestToLabel1.Error2"));
            this.errorProviderWrit.SetError(preJudgmentInterestToLabel1, resources.GetString("preJudgmentInterestToLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(preJudgmentInterestToLabel1, resources.GetString("preJudgmentInterestToLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(preJudgmentInterestToLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestToLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(preJudgmentInterestToLabel1, resources.GetString("preJudgmentInterestToLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(preJudgmentInterestToLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(preJudgmentInterestToLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(preJudgmentInterestToLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(preJudgmentInterestToLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(preJudgmentInterestToLabel1, ((int)(resources.GetObject("preJudgmentInterestToLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(preJudgmentInterestToLabel1, ((int)(resources.GetObject("preJudgmentInterestToLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(preJudgmentInterestToLabel1, ((int)(resources.GetObject("preJudgmentInterestToLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(preJudgmentInterestToLabel1, ((int)(resources.GetObject("preJudgmentInterestToLabel1.IconPadding3"))));
            preJudgmentInterestToLabel1.Name = "preJudgmentInterestToLabel1";
            this.helpProvider1.SetShowHelp(preJudgmentInterestToLabel1, ((bool)(resources.GetObject("preJudgmentInterestToLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(preJudgmentInterestToLabel1, resources.GetString("preJudgmentInterestToLabel1.ToolTip"));
            // 
            // preJudgmentInterestAmountLabel1
            // 
            resources.ApplyResources(preJudgmentInterestAmountLabel1, "preJudgmentInterestAmountLabel1");
            this.errorProvider1.SetError(preJudgmentInterestAmountLabel1, resources.GetString("preJudgmentInterestAmountLabel1.Error"));
            this.errorProviderJudgmentAccount.SetError(preJudgmentInterestAmountLabel1, resources.GetString("preJudgmentInterestAmountLabel1.Error1"));
            this.errorProviderCost.SetError(preJudgmentInterestAmountLabel1, resources.GetString("preJudgmentInterestAmountLabel1.Error2"));
            this.errorProviderWrit.SetError(preJudgmentInterestAmountLabel1, resources.GetString("preJudgmentInterestAmountLabel1.Error3"));
            this.helpProvider1.SetHelpKeyword(preJudgmentInterestAmountLabel1, resources.GetString("preJudgmentInterestAmountLabel1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(preJudgmentInterestAmountLabel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestAmountLabel1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(preJudgmentInterestAmountLabel1, resources.GetString("preJudgmentInterestAmountLabel1.HelpString"));
            this.errorProvider1.SetIconAlignment(preJudgmentInterestAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountLabel1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(preJudgmentInterestAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountLabel1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(preJudgmentInterestAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountLabel1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(preJudgmentInterestAmountLabel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountLabel1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(preJudgmentInterestAmountLabel1, ((int)(resources.GetObject("preJudgmentInterestAmountLabel1.IconPadding"))));
            this.errorProvider1.SetIconPadding(preJudgmentInterestAmountLabel1, ((int)(resources.GetObject("preJudgmentInterestAmountLabel1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(preJudgmentInterestAmountLabel1, ((int)(resources.GetObject("preJudgmentInterestAmountLabel1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(preJudgmentInterestAmountLabel1, ((int)(resources.GetObject("preJudgmentInterestAmountLabel1.IconPadding3"))));
            preJudgmentInterestAmountLabel1.Name = "preJudgmentInterestAmountLabel1";
            this.helpProvider1.SetShowHelp(preJudgmentInterestAmountLabel1, ((bool)(resources.GetObject("preJudgmentInterestAmountLabel1.ShowHelp"))));
            this.toolTip1.SetToolTip(preJudgmentInterestAmountLabel1, resources.GetString("preJudgmentInterestAmountLabel1.ToolTip"));
            // 
            // costAmountLabel2
            // 
            resources.ApplyResources(costAmountLabel2, "costAmountLabel2");
            this.errorProvider1.SetError(costAmountLabel2, resources.GetString("costAmountLabel2.Error"));
            this.errorProviderJudgmentAccount.SetError(costAmountLabel2, resources.GetString("costAmountLabel2.Error1"));
            this.errorProviderCost.SetError(costAmountLabel2, resources.GetString("costAmountLabel2.Error2"));
            this.errorProviderWrit.SetError(costAmountLabel2, resources.GetString("costAmountLabel2.Error3"));
            this.helpProvider1.SetHelpKeyword(costAmountLabel2, resources.GetString("costAmountLabel2.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(costAmountLabel2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("costAmountLabel2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(costAmountLabel2, resources.GetString("costAmountLabel2.HelpString"));
            this.errorProvider1.SetIconAlignment(costAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel2.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(costAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel2.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(costAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel2.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(costAmountLabel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountLabel2.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(costAmountLabel2, ((int)(resources.GetObject("costAmountLabel2.IconPadding"))));
            this.errorProvider1.SetIconPadding(costAmountLabel2, ((int)(resources.GetObject("costAmountLabel2.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(costAmountLabel2, ((int)(resources.GetObject("costAmountLabel2.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(costAmountLabel2, ((int)(resources.GetObject("costAmountLabel2.IconPadding3"))));
            costAmountLabel2.Name = "costAmountLabel2";
            this.helpProvider1.SetShowHelp(costAmountLabel2, ((bool)(resources.GetObject("costAmountLabel2.ShowHelp"))));
            this.toolTip1.SetToolTip(costAmountLabel2, resources.GetString("costAmountLabel2.ToolTip"));
            // 
            // judgmentAmountLabel
            // 
            resources.ApplyResources(judgmentAmountLabel, "judgmentAmountLabel");
            this.errorProvider1.SetError(judgmentAmountLabel, resources.GetString("judgmentAmountLabel.Error"));
            this.errorProviderJudgmentAccount.SetError(judgmentAmountLabel, resources.GetString("judgmentAmountLabel.Error1"));
            this.errorProviderCost.SetError(judgmentAmountLabel, resources.GetString("judgmentAmountLabel.Error2"));
            this.errorProviderWrit.SetError(judgmentAmountLabel, resources.GetString("judgmentAmountLabel.Error3"));
            this.helpProvider1.SetHelpKeyword(judgmentAmountLabel, resources.GetString("judgmentAmountLabel.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(judgmentAmountLabel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentAmountLabel.HelpNavigator"))));
            this.helpProvider1.SetHelpString(judgmentAmountLabel, resources.GetString("judgmentAmountLabel.HelpString"));
            this.errorProvider1.SetIconAlignment(judgmentAmountLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(judgmentAmountLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(judgmentAmountLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(judgmentAmountLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountLabel.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(judgmentAmountLabel, ((int)(resources.GetObject("judgmentAmountLabel.IconPadding"))));
            this.errorProvider1.SetIconPadding(judgmentAmountLabel, ((int)(resources.GetObject("judgmentAmountLabel.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(judgmentAmountLabel, ((int)(resources.GetObject("judgmentAmountLabel.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(judgmentAmountLabel, ((int)(resources.GetObject("judgmentAmountLabel.IconPadding3"))));
            judgmentAmountLabel.Name = "judgmentAmountLabel";
            this.helpProvider1.SetShowHelp(judgmentAmountLabel, ((bool)(resources.GetObject("judgmentAmountLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(judgmentAmountLabel, resources.GetString("judgmentAmountLabel.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            this.errorProvider1.SetError(label2, resources.GetString("label2.Error"));
            this.errorProviderJudgmentAccount.SetError(label2, resources.GetString("label2.Error1"));
            this.errorProviderCost.SetError(label2, resources.GetString("label2.Error2"));
            this.errorProviderWrit.SetError(label2, resources.GetString("label2.Error3"));
            this.helpProvider1.SetHelpKeyword(label2, resources.GetString("label2.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(label2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(label2, resources.GetString("label2.HelpString"));
            this.errorProvider1.SetIconAlignment(label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.errorProvider1.SetIconPadding(label2, ((int)(resources.GetObject("label2.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(label2, ((int)(resources.GetObject("label2.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(label2, ((int)(resources.GetObject("label2.IconPadding3"))));
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            this.toolTip1.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            this.errorProvider1.SetError(label1, resources.GetString("label1.Error"));
            this.errorProviderJudgmentAccount.SetError(label1, resources.GetString("label1.Error1"));
            this.errorProviderCost.SetError(label1, resources.GetString("label1.Error2"));
            this.errorProviderWrit.SetError(label1, resources.GetString("label1.Error3"));
            this.helpProvider1.SetHelpKeyword(label1, resources.GetString("label1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(label1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(label1, resources.GetString("label1.HelpString"));
            this.errorProvider1.SetIconAlignment(label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.errorProvider1.SetIconPadding(label1, ((int)(resources.GetObject("label1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(label1, ((int)(resources.GetObject("label1.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(label1, ((int)(resources.GetObject("label1.IconPadding3"))));
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            this.toolTip1.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            this.errorProvider1.SetError(label3, resources.GetString("label3.Error"));
            this.errorProviderJudgmentAccount.SetError(label3, resources.GetString("label3.Error1"));
            this.errorProviderCost.SetError(label3, resources.GetString("label3.Error2"));
            this.errorProviderWrit.SetError(label3, resources.GetString("label3.Error3"));
            this.helpProvider1.SetHelpKeyword(label3, resources.GetString("label3.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(label3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label3.HelpNavigator"))));
            this.helpProvider1.SetHelpString(label3, resources.GetString("label3.HelpString"));
            this.errorProvider1.SetIconAlignment(label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.errorProvider1.SetIconPadding(label3, ((int)(resources.GetObject("label3.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(label3, ((int)(resources.GetObject("label3.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(label3, ((int)(resources.GetObject("label3.IconPadding3"))));
            label3.Name = "label3";
            this.helpProvider1.SetShowHelp(label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            this.toolTip1.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            this.errorProvider1.SetError(label4, resources.GetString("label4.Error"));
            this.errorProviderJudgmentAccount.SetError(label4, resources.GetString("label4.Error1"));
            this.errorProviderCost.SetError(label4, resources.GetString("label4.Error2"));
            this.errorProviderWrit.SetError(label4, resources.GetString("label4.Error3"));
            this.helpProvider1.SetHelpKeyword(label4, resources.GetString("label4.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(label4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label4.HelpNavigator"))));
            this.helpProvider1.SetHelpString(label4, resources.GetString("label4.HelpString"));
            this.errorProvider1.SetIconAlignment(label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(label4, ((int)(resources.GetObject("label4.IconPadding"))));
            this.errorProvider1.SetIconPadding(label4, ((int)(resources.GetObject("label4.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(label4, ((int)(resources.GetObject("label4.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(label4, ((int)(resources.GetObject("label4.IconPadding3"))));
            label4.Name = "label4";
            this.helpProvider1.SetShowHelp(label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            this.toolTip1.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            this.errorProvider1.SetError(label5, resources.GetString("label5.Error"));
            this.errorProviderJudgmentAccount.SetError(label5, resources.GetString("label5.Error1"));
            this.errorProviderCost.SetError(label5, resources.GetString("label5.Error2"));
            this.errorProviderWrit.SetError(label5, resources.GetString("label5.Error3"));
            this.helpProvider1.SetHelpKeyword(label5, resources.GetString("label5.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(label5, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label5.HelpNavigator"))));
            this.helpProvider1.SetHelpString(label5, resources.GetString("label5.HelpString"));
            this.errorProvider1.SetIconAlignment(label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(label5, ((int)(resources.GetObject("label5.IconPadding"))));
            this.errorProvider1.SetIconPadding(label5, ((int)(resources.GetObject("label5.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(label5, ((int)(resources.GetObject("label5.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(label5, ((int)(resources.GetObject("label5.IconPadding3"))));
            label5.Name = "label5";
            this.helpProvider1.SetShowHelp(label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            this.toolTip1.SetToolTip(label5, resources.GetString("label5.ToolTip"));
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.uiPanelManager1, "uiPanelManager1");
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.TabbedMdiSettings.AllowDrag = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.AllowDrag")));
            this.uiPanelManager1.TabbedMdiSettings.MaxTabSize = ((int)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.MaxTabSize")));
            this.uiPanelManager1.TabbedMdiSettings.ShowCloseButton = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.ShowCloseButton")));
            this.uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming = ((System.Drawing.StringTrimming)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming")));
            this.uiPanelManager1.TabbedMdiSettings.UseFormIcons = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.UseFormIcons")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(806, 651), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8138a7b9-b40d-47cf-ac3d-26dcf701b6dc"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f22ae99f-bbc6-4b3a-8187-a6fac8168443"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("4b73f3ad-7366-4348-9d42-c6016df5bb28"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b5bffcc0-06a2-4b8b-b1ca-0b7728d0a90c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.errorProviderJudgmentAccount.SetError(this.pnlAll, resources.GetString("pnlAll.Error"));
            this.errorProvider1.SetError(this.pnlAll, resources.GetString("pnlAll.Error1"));
            this.errorProviderCost.SetError(this.pnlAll, resources.GetString("pnlAll.Error2"));
            this.errorProviderWrit.SetError(this.pnlAll, resources.GetString("pnlAll.Error3"));
            this.helpProvider1.SetHelpKeyword(this.pnlAll, resources.GetString("pnlAll.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.pnlAll, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("pnlAll.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.pnlAll, resources.GetString("pnlAll.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.pnlAll, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAll.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.pnlAll, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAll.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(this.pnlAll, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAll.IconAlignment2"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.pnlAll, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAll.IconAlignment3"))));
            this.errorProvider1.SetIconPadding(this.pnlAll, ((int)(resources.GetObject("pnlAll.IconPadding"))));
            this.errorProviderWrit.SetIconPadding(this.pnlAll, ((int)(resources.GetObject("pnlAll.IconPadding1"))));
            this.errorProviderCost.SetIconPadding(this.pnlAll, ((int)(resources.GetObject("pnlAll.IconPadding2"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.pnlAll, ((int)(resources.GetObject("pnlAll.IconPadding3"))));
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            this.toolTip1.SetToolTip(this.pnlAll, resources.GetString("pnlAll.ToolTip"));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.uiTab3);
            this.pnlAllContainer.Controls.Add(this.uiTab2);
            this.pnlAllContainer.Controls.Add(this.uiTab1);
            this.errorProviderCost.SetError(this.pnlAllContainer, resources.GetString("pnlAllContainer.Error"));
            this.errorProvider1.SetError(this.pnlAllContainer, resources.GetString("pnlAllContainer.Error1"));
            this.errorProviderJudgmentAccount.SetError(this.pnlAllContainer, resources.GetString("pnlAllContainer.Error2"));
            this.errorProviderWrit.SetError(this.pnlAllContainer, resources.GetString("pnlAllContainer.Error3"));
            this.helpProvider1.SetHelpKeyword(this.pnlAllContainer, resources.GetString("pnlAllContainer.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.pnlAllContainer, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("pnlAllContainer.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.pnlAllContainer, resources.GetString("pnlAllContainer.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.pnlAllContainer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAllContainer.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.pnlAllContainer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAllContainer.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.pnlAllContainer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAllContainer.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.pnlAllContainer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlAllContainer.IconAlignment3"))));
            this.errorProvider1.SetIconPadding(this.pnlAllContainer, ((int)(resources.GetObject("pnlAllContainer.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.pnlAllContainer, ((int)(resources.GetObject("pnlAllContainer.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.pnlAllContainer, ((int)(resources.GetObject("pnlAllContainer.IconPadding2"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.pnlAllContainer, ((int)(resources.GetObject("pnlAllContainer.IconPadding3"))));
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            this.toolTip1.SetToolTip(this.pnlAllContainer, resources.GetString("pnlAllContainer.ToolTip"));
            // 
            // uiTab3
            // 
            resources.ApplyResources(this.uiTab3, "uiTab3");
            this.uiTab3.BackColor = System.Drawing.Color.Transparent;
            this.errorProviderCost.SetError(this.uiTab3, resources.GetString("uiTab3.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiTab3, resources.GetString("uiTab3.Error1"));
            this.errorProvider1.SetError(this.uiTab3, resources.GetString("uiTab3.Error2"));
            this.errorProviderWrit.SetError(this.uiTab3, resources.GetString("uiTab3.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTab3, resources.GetString("uiTab3.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTab3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTab3.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTab3, resources.GetString("uiTab3.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.uiTab3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab3.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.uiTab3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab3.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTab3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab3.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTab3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab3.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTab3, ((int)(resources.GetObject("uiTab3.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.uiTab3, ((int)(resources.GetObject("uiTab3.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTab3, ((int)(resources.GetObject("uiTab3.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTab3, ((int)(resources.GetObject("uiTab3.IconPadding3"))));
            this.uiTab3.Name = "uiTab3";
            this.uiTab3.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab3.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab3, ((bool)(resources.GetObject("uiTab3.ShowHelp"))));
            this.uiTab3.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage5});
            this.uiTab3.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab3.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab3.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab3.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab3.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.toolTip1.SetToolTip(this.uiTab3, resources.GetString("uiTab3.ToolTip"));
            this.uiTab3.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage5
            // 
            resources.ApplyResources(this.uiTabPage5, "uiTabPage5");
            this.uiTabPage5.Controls.Add(this.calendarCombo1);
            this.uiTabPage5.Controls.Add(label5);
            this.uiTabPage5.Controls.Add(judgmentTypeCodeLabel1);
            this.uiTabPage5.Controls.Add(this.judgmentDateCalendarCombo1);
            this.uiTabPage5.Controls.Add(this.judgmentTypeCodeucMultiDropDown);
            this.uiTabPage5.Controls.Add(judgmentDateLabel1);
            this.uiTabPage5.Controls.Add(judgmentAmountLabel2);
            this.uiTabPage5.Controls.Add(this.officeIDucOfficeSelectBox1);
            this.uiTabPage5.Controls.Add(this.judgmentAmountNumericEditBox);
            this.uiTabPage5.Controls.Add(officeIDLabel1);
            this.uiTabPage5.Controls.Add(this.judgmentLPDateCalendarCombo1);
            this.uiTabPage5.Controls.Add(judgmentLPDateLabel1);
            this.errorProviderCost.SetError(this.uiTabPage5, resources.GetString("uiTabPage5.Error"));
            this.errorProvider1.SetError(this.uiTabPage5, resources.GetString("uiTabPage5.Error1"));
            this.errorProviderWrit.SetError(this.uiTabPage5, resources.GetString("uiTabPage5.Error2"));
            this.errorProviderJudgmentAccount.SetError(this.uiTabPage5, resources.GetString("uiTabPage5.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTabPage5, resources.GetString("uiTabPage5.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTabPage5, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTabPage5.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTabPage5, resources.GetString("uiTabPage5.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTabPage5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage5.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTabPage5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage5.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.uiTabPage5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage5.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiTabPage5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage5.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTabPage5, ((int)(resources.GetObject("uiTabPage5.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTabPage5, ((int)(resources.GetObject("uiTabPage5.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.uiTabPage5, ((int)(resources.GetObject("uiTabPage5.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTabPage5, ((int)(resources.GetObject("uiTabPage5.IconPadding3"))));
            this.uiTabPage5.Name = "uiTabPage5";
            this.helpProvider1.SetShowHelp(this.uiTabPage5, ((bool)(resources.GetObject("uiTabPage5.ShowHelp"))));
            this.uiTabPage5.TabStop = true;
            this.toolTip1.SetToolTip(this.uiTabPage5, resources.GetString("uiTabPage5.ToolTip"));
            // 
            // calendarCombo1
            // 
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentDataTableBindingSource, "WithdrawalRemovalDate", true));
            this.calendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("calendarCombo1.DropDownCalendar.AccessibleDescription");
            this.calendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("calendarCombo1.DropDownCalendar.AccessibleName");
            this.calendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("calendarCombo1.DropDownCalendar.Anchor")));
            this.calendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("calendarCombo1.DropDownCalendar.BackgroundImage")));
            this.calendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("calendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.calendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("calendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.calendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("calendarCombo1.DropDownCalendar.Dock")));
            this.calendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("calendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.calendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calendarCombo1.DropDownCalendar.Font")));
            this.calendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("calendarCombo1.DropDownCalendar.HeaderFormat");
            this.calendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("calendarCombo1.DropDownCalendar.ImeMode")));
            this.calendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("calendarCombo1.DropDownCalendar.MaximumSize")));
            this.calendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("calendarCombo1.DropDownCalendar.RightToLeft")));
            this.calendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("calendarCombo1.DropDownCalendar.Visible")));
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("calendarCombo1.DropDownCalendar.WeekNumbers")));
            this.calendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("calendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.calendarCombo1, resources.GetString("calendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.calendarCombo1, resources.GetString("calendarCombo1.Error1"));
            this.errorProvider1.SetError(this.calendarCombo1, resources.GetString("calendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.calendarCombo1, resources.GetString("calendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.calendarCombo1, resources.GetString("calendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.calendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("calendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.calendarCombo1, resources.GetString("calendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.calendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("calendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.calendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("calendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.calendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("calendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.calendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("calendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.calendarCombo1, ((int)(resources.GetObject("calendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.calendarCombo1, ((int)(resources.GetObject("calendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.calendarCombo1, ((int)(resources.GetObject("calendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.calendarCombo1, ((int)(resources.GetObject("calendarCombo1.IconPadding3"))));
            this.calendarCombo1.MonthIncrement = 0;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo1, ((bool)(resources.GetObject("calendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.calendarCombo1, resources.GetString("calendarCombo1.ToolTip"));
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.YearIncrement = 0;
            // 
            // atriumDB_JudgmentDataTableBindingSource
            // 
            this.atriumDB_JudgmentDataTableBindingSource.DataMember = "Judgment";
            this.atriumDB_JudgmentDataTableBindingSource.DataSource = typeof(lmDatasets.CLAS);
            this.atriumDB_JudgmentDataTableBindingSource.CurrentChanged += new System.EventHandler(this.judgmentBindingSource_CurrentChanged);
            // 
            // judgmentDateCalendarCombo1
            // 
            resources.ApplyResources(this.judgmentDateCalendarCombo1, "judgmentDateCalendarCombo1");
            this.judgmentDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentDataTableBindingSource, "JudgmentDate", true));
            this.judgmentDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.judgmentDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("judgmentDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.judgmentDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("judgmentDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.judgmentDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.Dock")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.Font")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("judgmentDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.judgmentDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.Visible")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.judgmentDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.judgmentDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("judgmentDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.judgmentDateCalendarCombo1, resources.GetString("judgmentDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.judgmentDateCalendarCombo1, resources.GetString("judgmentDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.judgmentDateCalendarCombo1, resources.GetString("judgmentDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.judgmentDateCalendarCombo1, resources.GetString("judgmentDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.judgmentDateCalendarCombo1, resources.GetString("judgmentDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.judgmentDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.judgmentDateCalendarCombo1, resources.GetString("judgmentDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.judgmentDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.judgmentDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.judgmentDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.judgmentDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.judgmentDateCalendarCombo1, ((int)(resources.GetObject("judgmentDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.judgmentDateCalendarCombo1, ((int)(resources.GetObject("judgmentDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.judgmentDateCalendarCombo1, ((int)(resources.GetObject("judgmentDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.judgmentDateCalendarCombo1, ((int)(resources.GetObject("judgmentDateCalendarCombo1.IconPadding3"))));
            this.judgmentDateCalendarCombo1.MonthIncrement = 0;
            this.judgmentDateCalendarCombo1.Name = "judgmentDateCalendarCombo1";
            this.judgmentDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.judgmentDateCalendarCombo1, ((bool)(resources.GetObject("judgmentDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.judgmentDateCalendarCombo1, resources.GetString("judgmentDateCalendarCombo1.ToolTip"));
            this.judgmentDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.judgmentDateCalendarCombo1.YearIncrement = 0;
            // 
            // judgmentTypeCodeucMultiDropDown
            // 
            resources.ApplyResources(this.judgmentTypeCodeucMultiDropDown, "judgmentTypeCodeucMultiDropDown");
            this.judgmentTypeCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.judgmentTypeCodeucMultiDropDown.Column1 = "JudgmentTypeCode";
            this.judgmentTypeCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.judgmentTypeCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_JudgmentDataTableBindingSource, "JudgmentTypeCode", true));
            this.judgmentTypeCodeucMultiDropDown.DataSource = null;
            this.judgmentTypeCodeucMultiDropDown.DDColumn1Visible = true;
            this.judgmentTypeCodeucMultiDropDown.DropDownColumn1Width = 50;
            this.judgmentTypeCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.errorProviderCost.SetError(this.judgmentTypeCodeucMultiDropDown, resources.GetString("judgmentTypeCodeucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.judgmentTypeCodeucMultiDropDown, resources.GetString("judgmentTypeCodeucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.judgmentTypeCodeucMultiDropDown, resources.GetString("judgmentTypeCodeucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.judgmentTypeCodeucMultiDropDown, resources.GetString("judgmentTypeCodeucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.judgmentTypeCodeucMultiDropDown, resources.GetString("judgmentTypeCodeucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.judgmentTypeCodeucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentTypeCodeucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.judgmentTypeCodeucMultiDropDown, resources.GetString("judgmentTypeCodeucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.judgmentTypeCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.judgmentTypeCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.judgmentTypeCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.judgmentTypeCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.judgmentTypeCodeucMultiDropDown, ((int)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.judgmentTypeCodeucMultiDropDown, ((int)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.judgmentTypeCodeucMultiDropDown, ((int)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.judgmentTypeCodeucMultiDropDown, ((int)(resources.GetObject("judgmentTypeCodeucMultiDropDown.IconPadding3"))));
            this.judgmentTypeCodeucMultiDropDown.Name = "judgmentTypeCodeucMultiDropDown";
            this.judgmentTypeCodeucMultiDropDown.ReadOnly = false;
            this.judgmentTypeCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.judgmentTypeCodeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.judgmentTypeCodeucMultiDropDown, ((bool)(resources.GetObject("judgmentTypeCodeucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.judgmentTypeCodeucMultiDropDown, resources.GetString("judgmentTypeCodeucMultiDropDown.ToolTip"));
            this.judgmentTypeCodeucMultiDropDown.ValueMember = "JudgmentTypeCode";
            // 
            // officeIDucOfficeSelectBox1
            // 
            resources.ApplyResources(this.officeIDucOfficeSelectBox1, "officeIDucOfficeSelectBox1");
            this.officeIDucOfficeSelectBox1.AtMng = null;
            this.officeIDucOfficeSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.officeIDucOfficeSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.atriumDB_JudgmentDataTableBindingSource, "OfficeID", true));
            this.errorProviderWrit.SetError(this.officeIDucOfficeSelectBox1, resources.GetString("officeIDucOfficeSelectBox1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.officeIDucOfficeSelectBox1, resources.GetString("officeIDucOfficeSelectBox1.Error1"));
            this.errorProvider1.SetError(this.officeIDucOfficeSelectBox1, resources.GetString("officeIDucOfficeSelectBox1.Error2"));
            this.errorProviderCost.SetError(this.officeIDucOfficeSelectBox1, resources.GetString("officeIDucOfficeSelectBox1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.officeIDucOfficeSelectBox1, resources.GetString("officeIDucOfficeSelectBox1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.officeIDucOfficeSelectBox1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("officeIDucOfficeSelectBox1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.officeIDucOfficeSelectBox1, resources.GetString("officeIDucOfficeSelectBox1.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.officeIDucOfficeSelectBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox1.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.officeIDucOfficeSelectBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.officeIDucOfficeSelectBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox1.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.officeIDucOfficeSelectBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox1.IconAlignment3"))));
            this.errorProvider1.SetIconPadding(this.officeIDucOfficeSelectBox1, ((int)(resources.GetObject("officeIDucOfficeSelectBox1.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.officeIDucOfficeSelectBox1, ((int)(resources.GetObject("officeIDucOfficeSelectBox1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.officeIDucOfficeSelectBox1, ((int)(resources.GetObject("officeIDucOfficeSelectBox1.IconPadding2"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.officeIDucOfficeSelectBox1, ((int)(resources.GetObject("officeIDucOfficeSelectBox1.IconPadding3"))));
            this.officeIDucOfficeSelectBox1.Name = "officeIDucOfficeSelectBox1";
            this.officeIDucOfficeSelectBox1.OfficeId = null;
            this.officeIDucOfficeSelectBox1.ReadOnly = true;
            this.officeIDucOfficeSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIDucOfficeSelectBox1, ((bool)(resources.GetObject("officeIDucOfficeSelectBox1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.officeIDucOfficeSelectBox1, resources.GetString("officeIDucOfficeSelectBox1.ToolTip"));
            // 
            // judgmentAmountNumericEditBox
            // 
            resources.ApplyResources(this.judgmentAmountNumericEditBox, "judgmentAmountNumericEditBox");
            this.judgmentAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentDataTableBindingSource, "JudgmentAmount", true));
            this.errorProviderJudgmentAccount.SetError(this.judgmentAmountNumericEditBox, resources.GetString("judgmentAmountNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.judgmentAmountNumericEditBox, resources.GetString("judgmentAmountNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.judgmentAmountNumericEditBox, resources.GetString("judgmentAmountNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.judgmentAmountNumericEditBox, resources.GetString("judgmentAmountNumericEditBox.Error3"));
            this.judgmentAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            this.helpProvider1.SetHelpKeyword(this.judgmentAmountNumericEditBox, resources.GetString("judgmentAmountNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.judgmentAmountNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentAmountNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.judgmentAmountNumericEditBox, resources.GetString("judgmentAmountNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.judgmentAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.judgmentAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.judgmentAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.judgmentAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.judgmentAmountNumericEditBox, ((int)(resources.GetObject("judgmentAmountNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.judgmentAmountNumericEditBox, ((int)(resources.GetObject("judgmentAmountNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.judgmentAmountNumericEditBox, ((int)(resources.GetObject("judgmentAmountNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.judgmentAmountNumericEditBox, ((int)(resources.GetObject("judgmentAmountNumericEditBox.IconPadding3"))));
            this.judgmentAmountNumericEditBox.Name = "judgmentAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.judgmentAmountNumericEditBox, ((bool)(resources.GetObject("judgmentAmountNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.judgmentAmountNumericEditBox, resources.GetString("judgmentAmountNumericEditBox.ToolTip"));
            this.judgmentAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.judgmentAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // judgmentLPDateCalendarCombo1
            // 
            resources.ApplyResources(this.judgmentLPDateCalendarCombo1, "judgmentLPDateCalendarCombo1");
            this.judgmentLPDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentDataTableBindingSource, "JudgmentLPDate", true));
            this.judgmentLPDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("judgmentLPDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("judgmentLPDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.Dock")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.Font")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("judgmentLPDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.Visible")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.judgmentLPDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("judgmentLPDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.judgmentLPDateCalendarCombo1, resources.GetString("judgmentLPDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.judgmentLPDateCalendarCombo1, resources.GetString("judgmentLPDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.judgmentLPDateCalendarCombo1, resources.GetString("judgmentLPDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.judgmentLPDateCalendarCombo1, resources.GetString("judgmentLPDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.judgmentLPDateCalendarCombo1, resources.GetString("judgmentLPDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.judgmentLPDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentLPDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.judgmentLPDateCalendarCombo1, resources.GetString("judgmentLPDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.judgmentLPDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.judgmentLPDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.judgmentLPDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.judgmentLPDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentLPDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.judgmentLPDateCalendarCombo1, ((int)(resources.GetObject("judgmentLPDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.judgmentLPDateCalendarCombo1, ((int)(resources.GetObject("judgmentLPDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.judgmentLPDateCalendarCombo1, ((int)(resources.GetObject("judgmentLPDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.judgmentLPDateCalendarCombo1, ((int)(resources.GetObject("judgmentLPDateCalendarCombo1.IconPadding3"))));
            this.judgmentLPDateCalendarCombo1.MonthIncrement = 0;
            this.judgmentLPDateCalendarCombo1.Name = "judgmentLPDateCalendarCombo1";
            this.judgmentLPDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.judgmentLPDateCalendarCombo1, ((bool)(resources.GetObject("judgmentLPDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.judgmentLPDateCalendarCombo1, resources.GetString("judgmentLPDateCalendarCombo1.ToolTip"));
            this.judgmentLPDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.judgmentLPDateCalendarCombo1.YearIncrement = 0;
            // 
            // uiTab2
            // 
            resources.ApplyResources(this.uiTab2, "uiTab2");
            this.uiTab2.BackColor = System.Drawing.Color.Transparent;
            this.errorProviderCost.SetError(this.uiTab2, resources.GetString("uiTab2.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiTab2, resources.GetString("uiTab2.Error1"));
            this.errorProvider1.SetError(this.uiTab2, resources.GetString("uiTab2.Error2"));
            this.errorProviderWrit.SetError(this.uiTab2, resources.GetString("uiTab2.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTab2, resources.GetString("uiTab2.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTab2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTab2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTab2, resources.GetString("uiTab2.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.uiTab2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab2.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.uiTab2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab2.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTab2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab2.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTab2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab2.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTab2, ((int)(resources.GetObject("uiTab2.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.uiTab2, ((int)(resources.GetObject("uiTab2.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTab2, ((int)(resources.GetObject("uiTab2.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTab2, ((int)(resources.GetObject("uiTab2.IconPadding3"))));
            this.uiTab2.Name = "uiTab2";
            this.uiTab2.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab2.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab2, ((bool)(resources.GetObject("uiTab2.ShowHelp"))));
            this.uiTab2.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage4});
            this.uiTab2.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab2.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab2.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab2.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab2.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.toolTip1.SetToolTip(this.uiTab2, resources.GetString("uiTab2.ToolTip"));
            this.uiTab2.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage4
            // 
            resources.ApplyResources(this.uiTabPage4, "uiTabPage4");
            this.uiTabPage4.Controls.Add(claimAgainstCrownLabel1);
            this.uiTabPage4.Controls.Add(this.processTypeCodeucMultiDropDown1);
            this.uiTabPage4.Controls.Add(this.claimAgainstCrownCalendarCombo1);
            this.uiTabPage4.Controls.Add(this.AccountIncludedGridEx);
            this.uiTabPage4.Controls.Add(defenceDateLabel1);
            this.uiTabPage4.Controls.Add(processTypeCodeLabel1);
            this.uiTabPage4.Controls.Add(this.defenceDateCalendarCombo1);
            this.uiTabPage4.Controls.Add(this.actionNumberEditBox);
            this.uiTabPage4.Controls.Add(statementofClaimServedDateLabel1);
            this.uiTabPage4.Controls.Add(actionNumberLabel1);
            this.uiTabPage4.Controls.Add(this.statementofClaimServedDateCalendarCombo1);
            this.uiTabPage4.Controls.Add(this.judgmentCourtLevelCodeucMultiDropDown);
            this.uiTabPage4.Controls.Add(statementofClaimIssuedDateLabel1);
            this.uiTabPage4.Controls.Add(judgmentCourtLevelCodeLabel1);
            this.uiTabPage4.Controls.Add(this.statementofClaimIssuedDateCalendarCombo1);
            this.errorProviderCost.SetError(this.uiTabPage4, resources.GetString("uiTabPage4.Error"));
            this.errorProvider1.SetError(this.uiTabPage4, resources.GetString("uiTabPage4.Error1"));
            this.errorProviderWrit.SetError(this.uiTabPage4, resources.GetString("uiTabPage4.Error2"));
            this.errorProviderJudgmentAccount.SetError(this.uiTabPage4, resources.GetString("uiTabPage4.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTabPage4, resources.GetString("uiTabPage4.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTabPage4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTabPage4.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTabPage4, resources.GetString("uiTabPage4.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTabPage4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage4.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTabPage4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage4.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.uiTabPage4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage4.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiTabPage4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage4.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTabPage4, ((int)(resources.GetObject("uiTabPage4.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTabPage4, ((int)(resources.GetObject("uiTabPage4.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.uiTabPage4, ((int)(resources.GetObject("uiTabPage4.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTabPage4, ((int)(resources.GetObject("uiTabPage4.IconPadding3"))));
            this.uiTabPage4.Name = "uiTabPage4";
            this.helpProvider1.SetShowHelp(this.uiTabPage4, ((bool)(resources.GetObject("uiTabPage4.ShowHelp"))));
            this.uiTabPage4.TabStop = true;
            this.toolTip1.SetToolTip(this.uiTabPage4, resources.GetString("uiTabPage4.ToolTip"));
            // 
            // processTypeCodeucMultiDropDown1
            // 
            resources.ApplyResources(this.processTypeCodeucMultiDropDown1, "processTypeCodeucMultiDropDown1");
            this.processTypeCodeucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.processTypeCodeucMultiDropDown1.Column1 = "ProcessTypeCode";
            this.processTypeCodeucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.processTypeCodeucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_JudgmentDataTableBindingSource, "ProcessTypeCode", true));
            this.processTypeCodeucMultiDropDown1.DataSource = null;
            this.processTypeCodeucMultiDropDown1.DDColumn1Visible = true;
            this.processTypeCodeucMultiDropDown1.DropDownColumn1Width = 50;
            this.processTypeCodeucMultiDropDown1.DropDownColumn2Width = 250;
            this.errorProviderCost.SetError(this.processTypeCodeucMultiDropDown1, resources.GetString("processTypeCodeucMultiDropDown1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.processTypeCodeucMultiDropDown1, resources.GetString("processTypeCodeucMultiDropDown1.Error1"));
            this.errorProvider1.SetError(this.processTypeCodeucMultiDropDown1, resources.GetString("processTypeCodeucMultiDropDown1.Error2"));
            this.errorProviderWrit.SetError(this.processTypeCodeucMultiDropDown1, resources.GetString("processTypeCodeucMultiDropDown1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.processTypeCodeucMultiDropDown1, resources.GetString("processTypeCodeucMultiDropDown1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.processTypeCodeucMultiDropDown1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("processTypeCodeucMultiDropDown1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.processTypeCodeucMultiDropDown1, resources.GetString("processTypeCodeucMultiDropDown1.HelpString"));
            this.errorProvider1.SetIconAlignment(this.processTypeCodeucMultiDropDown1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeucMultiDropDown1.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.processTypeCodeucMultiDropDown1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeucMultiDropDown1.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.processTypeCodeucMultiDropDown1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeucMultiDropDown1.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.processTypeCodeucMultiDropDown1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("processTypeCodeucMultiDropDown1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.processTypeCodeucMultiDropDown1, ((int)(resources.GetObject("processTypeCodeucMultiDropDown1.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.processTypeCodeucMultiDropDown1, ((int)(resources.GetObject("processTypeCodeucMultiDropDown1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.processTypeCodeucMultiDropDown1, ((int)(resources.GetObject("processTypeCodeucMultiDropDown1.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.processTypeCodeucMultiDropDown1, ((int)(resources.GetObject("processTypeCodeucMultiDropDown1.IconPadding3"))));
            this.processTypeCodeucMultiDropDown1.Name = "processTypeCodeucMultiDropDown1";
            this.processTypeCodeucMultiDropDown1.ReadOnly = false;
            this.processTypeCodeucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Window;
            this.processTypeCodeucMultiDropDown1.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.processTypeCodeucMultiDropDown1, ((bool)(resources.GetObject("processTypeCodeucMultiDropDown1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.processTypeCodeucMultiDropDown1, resources.GetString("processTypeCodeucMultiDropDown1.ToolTip"));
            this.processTypeCodeucMultiDropDown1.ValueMember = "ProcessTypeCode";
            // 
            // claimAgainstCrownCalendarCombo1
            // 
            resources.ApplyResources(this.claimAgainstCrownCalendarCombo1, "claimAgainstCrownCalendarCombo1");
            this.claimAgainstCrownCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentDataTableBindingSource, "ClaimAgainstCrown", true));
            this.claimAgainstCrownCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("claimAgainstCrownCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("claimAgainstCrownCalendarCombo1.DropDownCalendar.AccessibleName");
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.Anchor")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.Dock")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.Font")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("claimAgainstCrownCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.ImeMode")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.Visible")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.claimAgainstCrownCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("claimAgainstCrownCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.claimAgainstCrownCalendarCombo1, resources.GetString("claimAgainstCrownCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.claimAgainstCrownCalendarCombo1, resources.GetString("claimAgainstCrownCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.claimAgainstCrownCalendarCombo1, resources.GetString("claimAgainstCrownCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.claimAgainstCrownCalendarCombo1, resources.GetString("claimAgainstCrownCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.claimAgainstCrownCalendarCombo1, resources.GetString("claimAgainstCrownCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.claimAgainstCrownCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("claimAgainstCrownCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.claimAgainstCrownCalendarCombo1, resources.GetString("claimAgainstCrownCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.claimAgainstCrownCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.claimAgainstCrownCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.claimAgainstCrownCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.claimAgainstCrownCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.claimAgainstCrownCalendarCombo1, ((int)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.claimAgainstCrownCalendarCombo1, ((int)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.claimAgainstCrownCalendarCombo1, ((int)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.claimAgainstCrownCalendarCombo1, ((int)(resources.GetObject("claimAgainstCrownCalendarCombo1.IconPadding3"))));
            this.claimAgainstCrownCalendarCombo1.MonthIncrement = 0;
            this.claimAgainstCrownCalendarCombo1.Name = "claimAgainstCrownCalendarCombo1";
            this.claimAgainstCrownCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.claimAgainstCrownCalendarCombo1, ((bool)(resources.GetObject("claimAgainstCrownCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.claimAgainstCrownCalendarCombo1, resources.GetString("claimAgainstCrownCalendarCombo1.ToolTip"));
            this.claimAgainstCrownCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.claimAgainstCrownCalendarCombo1.YearIncrement = 0;
            // 
            // AccountIncludedGridEx
            // 
            resources.ApplyResources(this.AccountIncludedGridEx, "AccountIncludedGridEx");
            this.AccountIncludedGridEx.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.AccountIncludedGridEx.DataSource = this.atriumDB_JudgmentAccountDataTableBindingSource;
            this.AccountIncludedGridEx.DefaultBackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
            resources.ApplyResources(AccountIncludedGridEx_DesignTimeLayout, "AccountIncludedGridEx_DesignTimeLayout");
            this.AccountIncludedGridEx.DesignTimeLayout = AccountIncludedGridEx_DesignTimeLayout;
            this.errorProviderCost.SetError(this.AccountIncludedGridEx, resources.GetString("AccountIncludedGridEx.Error"));
            this.errorProvider1.SetError(this.AccountIncludedGridEx, resources.GetString("AccountIncludedGridEx.Error1"));
            this.errorProviderJudgmentAccount.SetError(this.AccountIncludedGridEx, resources.GetString("AccountIncludedGridEx.Error2"));
            this.errorProviderWrit.SetError(this.AccountIncludedGridEx, resources.GetString("AccountIncludedGridEx.Error3"));
            this.AccountIncludedGridEx.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.AccountIncludedGridEx.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.AccountIncludedGridEx.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.AccountIncludedGridEx.GroupByBoxVisible = false;
            this.helpProvider1.SetHelpKeyword(this.AccountIncludedGridEx, resources.GetString("AccountIncludedGridEx.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.AccountIncludedGridEx, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("AccountIncludedGridEx.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.AccountIncludedGridEx, resources.GetString("AccountIncludedGridEx.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.AccountIncludedGridEx, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("AccountIncludedGridEx.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.AccountIncludedGridEx, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("AccountIncludedGridEx.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.AccountIncludedGridEx, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("AccountIncludedGridEx.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.AccountIncludedGridEx, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("AccountIncludedGridEx.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.AccountIncludedGridEx, ((int)(resources.GetObject("AccountIncludedGridEx.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.AccountIncludedGridEx, ((int)(resources.GetObject("AccountIncludedGridEx.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.AccountIncludedGridEx, ((int)(resources.GetObject("AccountIncludedGridEx.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.AccountIncludedGridEx, ((int)(resources.GetObject("AccountIncludedGridEx.IconPadding3"))));
            this.AccountIncludedGridEx.Name = "AccountIncludedGridEx";
            this.helpProvider1.SetShowHelp(this.AccountIncludedGridEx, ((bool)(resources.GetObject("AccountIncludedGridEx.ShowHelp"))));
            this.AccountIncludedGridEx.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.AccountIncludedGridEx.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.toolTip1.SetToolTip(this.AccountIncludedGridEx, resources.GetString("AccountIncludedGridEx.ToolTip"));
            this.AccountIncludedGridEx.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.AccountIncludedGridEx.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.AccountIncludedGridEx.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.AccountIncludedGridEx_RowDoubleClick);
            this.AccountIncludedGridEx.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.AccountIncludedGridEx_LoadingRow);
            // 
            // atriumDB_JudgmentAccountDataTableBindingSource
            // 
            this.atriumDB_JudgmentAccountDataTableBindingSource.DataMember = "JudgmentJudgmentAccount";
            this.atriumDB_JudgmentAccountDataTableBindingSource.DataSource = this.atriumDB_JudgmentDataTableBindingSource;
            this.atriumDB_JudgmentAccountDataTableBindingSource.CurrentChanged += new System.EventHandler(this.judgmentAccountBindingSource_CurrentChanged);
            // 
            // defenceDateCalendarCombo1
            // 
            resources.ApplyResources(this.defenceDateCalendarCombo1, "defenceDateCalendarCombo1");
            this.defenceDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentDataTableBindingSource, "DefenceDate", true));
            this.defenceDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.defenceDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("defenceDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.defenceDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("defenceDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.defenceDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.defenceDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.defenceDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.defenceDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.defenceDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.Dock")));
            this.defenceDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.defenceDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.Font")));
            this.defenceDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("defenceDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.defenceDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.defenceDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.defenceDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.defenceDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.Visible")));
            this.defenceDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.defenceDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.defenceDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("defenceDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.defenceDateCalendarCombo1, resources.GetString("defenceDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.defenceDateCalendarCombo1, resources.GetString("defenceDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.defenceDateCalendarCombo1, resources.GetString("defenceDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.defenceDateCalendarCombo1, resources.GetString("defenceDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.defenceDateCalendarCombo1, resources.GetString("defenceDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.defenceDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("defenceDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.defenceDateCalendarCombo1, resources.GetString("defenceDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.defenceDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.defenceDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.defenceDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.defenceDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defenceDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.defenceDateCalendarCombo1, ((int)(resources.GetObject("defenceDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.defenceDateCalendarCombo1, ((int)(resources.GetObject("defenceDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.defenceDateCalendarCombo1, ((int)(resources.GetObject("defenceDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.defenceDateCalendarCombo1, ((int)(resources.GetObject("defenceDateCalendarCombo1.IconPadding3"))));
            this.defenceDateCalendarCombo1.MonthIncrement = 0;
            this.defenceDateCalendarCombo1.Name = "defenceDateCalendarCombo1";
            this.defenceDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.defenceDateCalendarCombo1, ((bool)(resources.GetObject("defenceDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.defenceDateCalendarCombo1, resources.GetString("defenceDateCalendarCombo1.ToolTip"));
            this.defenceDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.defenceDateCalendarCombo1.YearIncrement = 0;
            // 
            // actionNumberEditBox
            // 
            resources.ApplyResources(this.actionNumberEditBox, "actionNumberEditBox");
            this.actionNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.atriumDB_JudgmentDataTableBindingSource, "ActionNumber", true));
            this.errorProviderJudgmentAccount.SetError(this.actionNumberEditBox, resources.GetString("actionNumberEditBox.Error"));
            this.errorProviderCost.SetError(this.actionNumberEditBox, resources.GetString("actionNumberEditBox.Error1"));
            this.errorProvider1.SetError(this.actionNumberEditBox, resources.GetString("actionNumberEditBox.Error2"));
            this.errorProviderWrit.SetError(this.actionNumberEditBox, resources.GetString("actionNumberEditBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.actionNumberEditBox, resources.GetString("actionNumberEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.actionNumberEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("actionNumberEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.actionNumberEditBox, resources.GetString("actionNumberEditBox.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.actionNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberEditBox.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.actionNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberEditBox.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(this.actionNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberEditBox.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.actionNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("actionNumberEditBox.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(this.actionNumberEditBox, ((int)(resources.GetObject("actionNumberEditBox.IconPadding"))));
            this.errorProviderWrit.SetIconPadding(this.actionNumberEditBox, ((int)(resources.GetObject("actionNumberEditBox.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.actionNumberEditBox, ((int)(resources.GetObject("actionNumberEditBox.IconPadding2"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.actionNumberEditBox, ((int)(resources.GetObject("actionNumberEditBox.IconPadding3"))));
            this.actionNumberEditBox.Name = "actionNumberEditBox";
            this.helpProvider1.SetShowHelp(this.actionNumberEditBox, ((bool)(resources.GetObject("actionNumberEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.actionNumberEditBox, resources.GetString("actionNumberEditBox.ToolTip"));
            this.actionNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // statementofClaimServedDateCalendarCombo1
            // 
            resources.ApplyResources(this.statementofClaimServedDateCalendarCombo1, "statementofClaimServedDateCalendarCombo1");
            this.statementofClaimServedDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentDataTableBindingSource, "StatementofClaimServedDate", true));
            this.statementofClaimServedDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("statementofClaimServedDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("statementofClaimServedDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.Dock")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.Font")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("statementofClaimServedDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.Visible")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.statementofClaimServedDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("statementofClaimServedDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.statementofClaimServedDateCalendarCombo1, resources.GetString("statementofClaimServedDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.statementofClaimServedDateCalendarCombo1, resources.GetString("statementofClaimServedDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.statementofClaimServedDateCalendarCombo1, resources.GetString("statementofClaimServedDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.statementofClaimServedDateCalendarCombo1, resources.GetString("statementofClaimServedDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.statementofClaimServedDateCalendarCombo1, resources.GetString("statementofClaimServedDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.statementofClaimServedDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("statementofClaimServedDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.statementofClaimServedDateCalendarCombo1, resources.GetString("statementofClaimServedDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.statementofClaimServedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.statementofClaimServedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.statementofClaimServedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.statementofClaimServedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.statementofClaimServedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.statementofClaimServedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.statementofClaimServedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.statementofClaimServedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimServedDateCalendarCombo1.IconPadding3"))));
            this.statementofClaimServedDateCalendarCombo1.MonthIncrement = 0;
            this.statementofClaimServedDateCalendarCombo1.Name = "statementofClaimServedDateCalendarCombo1";
            this.statementofClaimServedDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.statementofClaimServedDateCalendarCombo1, ((bool)(resources.GetObject("statementofClaimServedDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.statementofClaimServedDateCalendarCombo1, resources.GetString("statementofClaimServedDateCalendarCombo1.ToolTip"));
            this.statementofClaimServedDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.statementofClaimServedDateCalendarCombo1.YearIncrement = 0;
            // 
            // judgmentCourtLevelCodeucMultiDropDown
            // 
            resources.ApplyResources(this.judgmentCourtLevelCodeucMultiDropDown, "judgmentCourtLevelCodeucMultiDropDown");
            this.judgmentCourtLevelCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.judgmentCourtLevelCodeucMultiDropDown.Column1 = "JudgmentCourtLevelCode";
            this.judgmentCourtLevelCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.judgmentCourtLevelCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_JudgmentDataTableBindingSource, "JudgmentCourtLevelCode", true));
            this.judgmentCourtLevelCodeucMultiDropDown.DataSource = null;
            this.judgmentCourtLevelCodeucMultiDropDown.DDColumn1Visible = true;
            this.judgmentCourtLevelCodeucMultiDropDown.DropDownColumn1Width = 50;
            this.judgmentCourtLevelCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.errorProviderCost.SetError(this.judgmentCourtLevelCodeucMultiDropDown, resources.GetString("judgmentCourtLevelCodeucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.judgmentCourtLevelCodeucMultiDropDown, resources.GetString("judgmentCourtLevelCodeucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.judgmentCourtLevelCodeucMultiDropDown, resources.GetString("judgmentCourtLevelCodeucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.judgmentCourtLevelCodeucMultiDropDown, resources.GetString("judgmentCourtLevelCodeucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.judgmentCourtLevelCodeucMultiDropDown, resources.GetString("judgmentCourtLevelCodeucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.judgmentCourtLevelCodeucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.judgmentCourtLevelCodeucMultiDropDown, resources.GetString("judgmentCourtLevelCodeucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.judgmentCourtLevelCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.judgmentCourtLevelCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.judgmentCourtLevelCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.judgmentCourtLevelCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.judgmentCourtLevelCodeucMultiDropDown, ((int)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.judgmentCourtLevelCodeucMultiDropDown, ((int)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.judgmentCourtLevelCodeucMultiDropDown, ((int)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.judgmentCourtLevelCodeucMultiDropDown, ((int)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.IconPadding3"))));
            this.judgmentCourtLevelCodeucMultiDropDown.Name = "judgmentCourtLevelCodeucMultiDropDown";
            this.judgmentCourtLevelCodeucMultiDropDown.ReadOnly = false;
            this.judgmentCourtLevelCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.judgmentCourtLevelCodeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.judgmentCourtLevelCodeucMultiDropDown, ((bool)(resources.GetObject("judgmentCourtLevelCodeucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.judgmentCourtLevelCodeucMultiDropDown, resources.GetString("judgmentCourtLevelCodeucMultiDropDown.ToolTip"));
            this.judgmentCourtLevelCodeucMultiDropDown.ValueMember = "JudgmentCourtLevelCode";
            // 
            // statementofClaimIssuedDateCalendarCombo1
            // 
            resources.ApplyResources(this.statementofClaimIssuedDateCalendarCombo1, "statementofClaimIssuedDateCalendarCombo1");
            this.statementofClaimIssuedDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentDataTableBindingSource, "StatementofClaimIssuedDate", true));
            this.statementofClaimIssuedDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Dock")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Font")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.Visible")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.statementofClaimIssuedDateCalendarCombo1, resources.GetString("statementofClaimIssuedDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.statementofClaimIssuedDateCalendarCombo1, resources.GetString("statementofClaimIssuedDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.statementofClaimIssuedDateCalendarCombo1, resources.GetString("statementofClaimIssuedDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.statementofClaimIssuedDateCalendarCombo1, resources.GetString("statementofClaimIssuedDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.statementofClaimIssuedDateCalendarCombo1, resources.GetString("statementofClaimIssuedDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.statementofClaimIssuedDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.statementofClaimIssuedDateCalendarCombo1, resources.GetString("statementofClaimIssuedDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.statementofClaimIssuedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.statementofClaimIssuedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.statementofClaimIssuedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.statementofClaimIssuedDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.statementofClaimIssuedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.statementofClaimIssuedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.statementofClaimIssuedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.statementofClaimIssuedDateCalendarCombo1, ((int)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.IconPadding3"))));
            this.statementofClaimIssuedDateCalendarCombo1.MonthIncrement = 0;
            this.statementofClaimIssuedDateCalendarCombo1.Name = "statementofClaimIssuedDateCalendarCombo1";
            this.statementofClaimIssuedDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.statementofClaimIssuedDateCalendarCombo1, ((bool)(resources.GetObject("statementofClaimIssuedDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.statementofClaimIssuedDateCalendarCombo1, resources.GetString("statementofClaimIssuedDateCalendarCombo1.ToolTip"));
            this.statementofClaimIssuedDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.statementofClaimIssuedDateCalendarCombo1.YearIncrement = 0;
            // 
            // uiTab1
            // 
            resources.ApplyResources(this.uiTab1, "uiTab1");
            this.uiTab1.BackColor = System.Drawing.Color.Transparent;
            this.errorProviderCost.SetError(this.uiTab1, resources.GetString("uiTab1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiTab1, resources.GetString("uiTab1.Error1"));
            this.errorProvider1.SetError(this.uiTab1, resources.GetString("uiTab1.Error2"));
            this.errorProviderWrit.SetError(this.uiTab1, resources.GetString("uiTab1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTab1, resources.GetString("uiTab1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTab1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTab1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTab1, resources.GetString("uiTab1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.uiTab1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.uiTab1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTab1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTab1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTab1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTab1, ((int)(resources.GetObject("uiTab1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.uiTab1, ((int)(resources.GetObject("uiTab1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTab1, ((int)(resources.GetObject("uiTab1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTab1, ((int)(resources.GetObject("uiTab1.IconPadding3"))));
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.PanelFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.uiTab1.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab1, ((bool)(resources.GetObject("uiTab1.ShowHelp"))));
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1,
            this.uiTabPage2,
            this.uiTabPage3});
            this.uiTab1.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab1.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab1.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.toolTip1.SetToolTip(this.uiTab1, resources.GetString("uiTab1.ToolTip"));
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage1
            // 
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Controls.Add(this.uiGroupBox4);
            this.uiTabPage1.Controls.Add(this.ucAccountTypeMcc);
            this.uiTabPage1.Controls.Add(this.uiGroupBox3);
            this.uiTabPage1.Controls.Add(this.judgmentAccountGridEX);
            this.uiTabPage1.Controls.Add(accountTypeCodeLabel);
            this.errorProviderCost.SetError(this.uiTabPage1, resources.GetString("uiTabPage1.Error"));
            this.errorProvider1.SetError(this.uiTabPage1, resources.GetString("uiTabPage1.Error1"));
            this.errorProviderWrit.SetError(this.uiTabPage1, resources.GetString("uiTabPage1.Error2"));
            this.errorProviderJudgmentAccount.SetError(this.uiTabPage1, resources.GetString("uiTabPage1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTabPage1, resources.GetString("uiTabPage1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTabPage1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTabPage1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTabPage1, resources.GetString("uiTabPage1.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTabPage1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage1.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTabPage1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage1.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.uiTabPage1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage1.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiTabPage1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTabPage1, ((int)(resources.GetObject("uiTabPage1.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTabPage1, ((int)(resources.GetObject("uiTabPage1.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.uiTabPage1, ((int)(resources.GetObject("uiTabPage1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTabPage1, ((int)(resources.GetObject("uiTabPage1.IconPadding3"))));
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            this.toolTip1.SetToolTip(this.uiTabPage1, resources.GetString("uiTabPage1.ToolTip"));
            // 
            // uiGroupBox4
            // 
            resources.ApplyResources(this.uiGroupBox4, "uiGroupBox4");
            this.uiGroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox4.Controls.Add(label3);
            this.uiGroupBox4.Controls.Add(label1);
            this.uiGroupBox4.Controls.Add(this.postJRateTypeOnCostucMultiDropDown);
            this.uiGroupBox4.Controls.Add(this.postJIntRateOnCostNumericEditBox);
            this.uiGroupBox4.Controls.Add(this.postJudgmentRateTypeucMultiDropDown);
            this.uiGroupBox4.Controls.Add(this.postJudgmentInterestRateNumericEditBox);
            this.uiGroupBox4.Controls.Add(this.accruedFromDateCalendarCombo1);
            this.uiGroupBox4.Controls.Add(postJudgmentInterestRateLabel);
            this.uiGroupBox4.Controls.Add(accruedFromDateLabel);
            this.uiGroupBox4.Controls.Add(lblRateOnDateOfJ);
            this.uiGroupBox4.Controls.Add(postJIntRateOnCostLabel);
            this.errorProviderWrit.SetError(this.uiGroupBox4, resources.GetString("uiGroupBox4.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiGroupBox4, resources.GetString("uiGroupBox4.Error1"));
            this.errorProviderCost.SetError(this.uiGroupBox4, resources.GetString("uiGroupBox4.Error2"));
            this.errorProvider1.SetError(this.uiGroupBox4, resources.GetString("uiGroupBox4.Error3"));
            this.uiGroupBox4.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.helpProvider1.SetHelpKeyword(this.uiGroupBox4, resources.GetString("uiGroupBox4.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiGroupBox4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiGroupBox4.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiGroupBox4, resources.GetString("uiGroupBox4.HelpString"));
            this.errorProvider1.SetIconAlignment(this.uiGroupBox4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox4.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiGroupBox4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox4.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.uiGroupBox4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox4.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiGroupBox4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox4.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiGroupBox4, ((int)(resources.GetObject("uiGroupBox4.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.uiGroupBox4, ((int)(resources.GetObject("uiGroupBox4.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiGroupBox4, ((int)(resources.GetObject("uiGroupBox4.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.uiGroupBox4, ((int)(resources.GetObject("uiGroupBox4.IconPadding3"))));
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.helpProvider1.SetShowHelp(this.uiGroupBox4, ((bool)(resources.GetObject("uiGroupBox4.ShowHelp"))));
            this.toolTip1.SetToolTip(this.uiGroupBox4, resources.GetString("uiGroupBox4.ToolTip"));
            this.uiGroupBox4.UseThemes = false;
            this.uiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // postJRateTypeOnCostucMultiDropDown
            // 
            resources.ApplyResources(this.postJRateTypeOnCostucMultiDropDown, "postJRateTypeOnCostucMultiDropDown");
            this.postJRateTypeOnCostucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.postJRateTypeOnCostucMultiDropDown.Column1 = "InterestRateCode";
            this.postJRateTypeOnCostucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.postJRateTypeOnCostucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_JudgmentAccountDataTableBindingSource, "PostJRateTypeOnCost", true));
            this.postJRateTypeOnCostucMultiDropDown.DataSource = null;
            this.postJRateTypeOnCostucMultiDropDown.DDColumn1Visible = true;
            this.postJRateTypeOnCostucMultiDropDown.DropDownColumn1Width = 50;
            this.postJRateTypeOnCostucMultiDropDown.DropDownColumn2Width = 250;
            this.errorProviderCost.SetError(this.postJRateTypeOnCostucMultiDropDown, resources.GetString("postJRateTypeOnCostucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.postJRateTypeOnCostucMultiDropDown, resources.GetString("postJRateTypeOnCostucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.postJRateTypeOnCostucMultiDropDown, resources.GetString("postJRateTypeOnCostucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.postJRateTypeOnCostucMultiDropDown, resources.GetString("postJRateTypeOnCostucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.postJRateTypeOnCostucMultiDropDown, resources.GetString("postJRateTypeOnCostucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.postJRateTypeOnCostucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.postJRateTypeOnCostucMultiDropDown, resources.GetString("postJRateTypeOnCostucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.postJRateTypeOnCostucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.postJRateTypeOnCostucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.postJRateTypeOnCostucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.postJRateTypeOnCostucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.postJRateTypeOnCostucMultiDropDown, ((int)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.postJRateTypeOnCostucMultiDropDown, ((int)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.postJRateTypeOnCostucMultiDropDown, ((int)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.postJRateTypeOnCostucMultiDropDown, ((int)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.IconPadding3"))));
            this.postJRateTypeOnCostucMultiDropDown.Name = "postJRateTypeOnCostucMultiDropDown";
            this.postJRateTypeOnCostucMultiDropDown.ReadOnly = false;
            this.postJRateTypeOnCostucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.postJRateTypeOnCostucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.postJRateTypeOnCostucMultiDropDown, ((bool)(resources.GetObject("postJRateTypeOnCostucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.postJRateTypeOnCostucMultiDropDown, resources.GetString("postJRateTypeOnCostucMultiDropDown.ToolTip"));
            this.postJRateTypeOnCostucMultiDropDown.ValueMember = "InterestRateCode";
            // 
            // postJIntRateOnCostNumericEditBox
            // 
            resources.ApplyResources(this.postJIntRateOnCostNumericEditBox, "postJIntRateOnCostNumericEditBox");
            this.postJIntRateOnCostNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentAccountDataTableBindingSource, "PostJIntRateOnCost", true));
            this.postJIntRateOnCostNumericEditBox.DecimalDigits = 3;
            this.errorProviderJudgmentAccount.SetError(this.postJIntRateOnCostNumericEditBox, resources.GetString("postJIntRateOnCostNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.postJIntRateOnCostNumericEditBox, resources.GetString("postJIntRateOnCostNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.postJIntRateOnCostNumericEditBox, resources.GetString("postJIntRateOnCostNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.postJIntRateOnCostNumericEditBox, resources.GetString("postJIntRateOnCostNumericEditBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.postJIntRateOnCostNumericEditBox, resources.GetString("postJIntRateOnCostNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.postJIntRateOnCostNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJIntRateOnCostNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.postJIntRateOnCostNumericEditBox, resources.GetString("postJIntRateOnCostNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.postJIntRateOnCostNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.postJIntRateOnCostNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.postJIntRateOnCostNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.postJIntRateOnCostNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.postJIntRateOnCostNumericEditBox, ((int)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.postJIntRateOnCostNumericEditBox, ((int)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.postJIntRateOnCostNumericEditBox, ((int)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.postJIntRateOnCostNumericEditBox, ((int)(resources.GetObject("postJIntRateOnCostNumericEditBox.IconPadding3"))));
            this.postJIntRateOnCostNumericEditBox.Name = "postJIntRateOnCostNumericEditBox";
            this.helpProvider1.SetShowHelp(this.postJIntRateOnCostNumericEditBox, ((bool)(resources.GetObject("postJIntRateOnCostNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.postJIntRateOnCostNumericEditBox, resources.GetString("postJIntRateOnCostNumericEditBox.ToolTip"));
            this.postJIntRateOnCostNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.postJIntRateOnCostNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // postJudgmentRateTypeucMultiDropDown
            // 
            resources.ApplyResources(this.postJudgmentRateTypeucMultiDropDown, "postJudgmentRateTypeucMultiDropDown");
            this.postJudgmentRateTypeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.postJudgmentRateTypeucMultiDropDown.Column1 = "InterestRateCode";
            this.postJudgmentRateTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.postJudgmentRateTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_JudgmentAccountDataTableBindingSource, "PostJudgmentRateType", true));
            this.postJudgmentRateTypeucMultiDropDown.DataSource = null;
            this.postJudgmentRateTypeucMultiDropDown.DDColumn1Visible = true;
            this.postJudgmentRateTypeucMultiDropDown.DropDownColumn1Width = 50;
            this.postJudgmentRateTypeucMultiDropDown.DropDownColumn2Width = 250;
            this.errorProviderCost.SetError(this.postJudgmentRateTypeucMultiDropDown, resources.GetString("postJudgmentRateTypeucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.postJudgmentRateTypeucMultiDropDown, resources.GetString("postJudgmentRateTypeucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.postJudgmentRateTypeucMultiDropDown, resources.GetString("postJudgmentRateTypeucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.postJudgmentRateTypeucMultiDropDown, resources.GetString("postJudgmentRateTypeucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.postJudgmentRateTypeucMultiDropDown, resources.GetString("postJudgmentRateTypeucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.postJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.postJudgmentRateTypeucMultiDropDown, resources.GetString("postJudgmentRateTypeucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.postJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.postJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.postJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.postJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.postJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.postJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.postJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.postJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.IconPadding3"))));
            this.postJudgmentRateTypeucMultiDropDown.Name = "postJudgmentRateTypeucMultiDropDown";
            this.postJudgmentRateTypeucMultiDropDown.ReadOnly = false;
            this.postJudgmentRateTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.postJudgmentRateTypeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.postJudgmentRateTypeucMultiDropDown, ((bool)(resources.GetObject("postJudgmentRateTypeucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.postJudgmentRateTypeucMultiDropDown, resources.GetString("postJudgmentRateTypeucMultiDropDown.ToolTip"));
            this.postJudgmentRateTypeucMultiDropDown.ValueMember = "InterestRateCode";
            // 
            // postJudgmentInterestRateNumericEditBox
            // 
            resources.ApplyResources(this.postJudgmentInterestRateNumericEditBox, "postJudgmentInterestRateNumericEditBox");
            this.postJudgmentInterestRateNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentAccountDataTableBindingSource, "PostJudgmentInterestRate", true));
            this.postJudgmentInterestRateNumericEditBox.DecimalDigits = 3;
            this.errorProviderJudgmentAccount.SetError(this.postJudgmentInterestRateNumericEditBox, resources.GetString("postJudgmentInterestRateNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.postJudgmentInterestRateNumericEditBox, resources.GetString("postJudgmentInterestRateNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.postJudgmentInterestRateNumericEditBox, resources.GetString("postJudgmentInterestRateNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.postJudgmentInterestRateNumericEditBox, resources.GetString("postJudgmentInterestRateNumericEditBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.postJudgmentInterestRateNumericEditBox, resources.GetString("postJudgmentInterestRateNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.postJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJudgmentInterestRateNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.postJudgmentInterestRateNumericEditBox, resources.GetString("postJudgmentInterestRateNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.postJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.postJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.postJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.postJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.postJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.postJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.postJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.postJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("postJudgmentInterestRateNumericEditBox.IconPadding3"))));
            this.postJudgmentInterestRateNumericEditBox.Name = "postJudgmentInterestRateNumericEditBox";
            this.helpProvider1.SetShowHelp(this.postJudgmentInterestRateNumericEditBox, ((bool)(resources.GetObject("postJudgmentInterestRateNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.postJudgmentInterestRateNumericEditBox, resources.GetString("postJudgmentInterestRateNumericEditBox.ToolTip"));
            this.postJudgmentInterestRateNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.postJudgmentInterestRateNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // accruedFromDateCalendarCombo1
            // 
            resources.ApplyResources(this.accruedFromDateCalendarCombo1, "accruedFromDateCalendarCombo1");
            this.accruedFromDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentAccountDataTableBindingSource, "AccruedFromDate", true));
            this.accruedFromDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.accruedFromDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("accruedFromDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.accruedFromDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("accruedFromDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.accruedFromDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.Dock")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.Font")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("accruedFromDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.accruedFromDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.Visible")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.accruedFromDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.accruedFromDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("accruedFromDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.accruedFromDateCalendarCombo1, resources.GetString("accruedFromDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.accruedFromDateCalendarCombo1, resources.GetString("accruedFromDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.accruedFromDateCalendarCombo1, resources.GetString("accruedFromDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.accruedFromDateCalendarCombo1, resources.GetString("accruedFromDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.accruedFromDateCalendarCombo1, resources.GetString("accruedFromDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.accruedFromDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("accruedFromDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.accruedFromDateCalendarCombo1, resources.GetString("accruedFromDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.accruedFromDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.accruedFromDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.accruedFromDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.accruedFromDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("accruedFromDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.accruedFromDateCalendarCombo1, ((int)(resources.GetObject("accruedFromDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.accruedFromDateCalendarCombo1, ((int)(resources.GetObject("accruedFromDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.accruedFromDateCalendarCombo1, ((int)(resources.GetObject("accruedFromDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.accruedFromDateCalendarCombo1, ((int)(resources.GetObject("accruedFromDateCalendarCombo1.IconPadding3"))));
            this.accruedFromDateCalendarCombo1.MonthIncrement = 0;
            this.accruedFromDateCalendarCombo1.Name = "accruedFromDateCalendarCombo1";
            this.accruedFromDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.accruedFromDateCalendarCombo1, ((bool)(resources.GetObject("accruedFromDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.accruedFromDateCalendarCombo1, resources.GetString("accruedFromDateCalendarCombo1.ToolTip"));
            this.accruedFromDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.accruedFromDateCalendarCombo1.YearIncrement = 0;
            // 
            // ucAccountTypeMcc
            // 
            resources.ApplyResources(this.ucAccountTypeMcc, "ucAccountTypeMcc");
            this.ucAccountTypeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucAccountTypeMcc.Column1 = "AccountTypeCode";
            this.ucAccountTypeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucAccountTypeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_JudgmentAccountDataTableBindingSource, "AccountTypeId", true));
            this.ucAccountTypeMcc.DataSource = null;
            this.ucAccountTypeMcc.DDColumn1Visible = true;
            this.ucAccountTypeMcc.DropDownColumn1Width = 100;
            this.ucAccountTypeMcc.DropDownColumn2Width = 300;
            this.errorProviderCost.SetError(this.ucAccountTypeMcc, resources.GetString("ucAccountTypeMcc.Error"));
            this.errorProviderJudgmentAccount.SetError(this.ucAccountTypeMcc, resources.GetString("ucAccountTypeMcc.Error1"));
            this.errorProvider1.SetError(this.ucAccountTypeMcc, resources.GetString("ucAccountTypeMcc.Error2"));
            this.errorProviderWrit.SetError(this.ucAccountTypeMcc, resources.GetString("ucAccountTypeMcc.Error3"));
            this.helpProvider1.SetHelpKeyword(this.ucAccountTypeMcc, resources.GetString("ucAccountTypeMcc.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.ucAccountTypeMcc, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("ucAccountTypeMcc.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.ucAccountTypeMcc, resources.GetString("ucAccountTypeMcc.HelpString"));
            this.errorProvider1.SetIconAlignment(this.ucAccountTypeMcc, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("ucAccountTypeMcc.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.ucAccountTypeMcc, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("ucAccountTypeMcc.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.ucAccountTypeMcc, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("ucAccountTypeMcc.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.ucAccountTypeMcc, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("ucAccountTypeMcc.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.ucAccountTypeMcc, ((int)(resources.GetObject("ucAccountTypeMcc.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.ucAccountTypeMcc, ((int)(resources.GetObject("ucAccountTypeMcc.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.ucAccountTypeMcc, ((int)(resources.GetObject("ucAccountTypeMcc.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.ucAccountTypeMcc, ((int)(resources.GetObject("ucAccountTypeMcc.IconPadding3"))));
            this.ucAccountTypeMcc.Name = "ucAccountTypeMcc";
            this.ucAccountTypeMcc.ReadOnly = true;
            this.ucAccountTypeMcc.ReqColor = System.Drawing.SystemColors.Control;
            this.ucAccountTypeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucAccountTypeMcc, ((bool)(resources.GetObject("ucAccountTypeMcc.ShowHelp"))));
            this.toolTip1.SetToolTip(this.ucAccountTypeMcc, resources.GetString("ucAccountTypeMcc.ToolTip"));
            this.ucAccountTypeMcc.ValueMember = "AccountTypeId";
            // 
            // uiGroupBox3
            // 
            resources.ApplyResources(this.uiGroupBox3, "uiGroupBox3");
            this.uiGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox3.Controls.Add(label2);
            this.uiGroupBox3.Controls.Add(this.judgmentAmountNumericEditBox1);
            this.uiGroupBox3.Controls.Add(costAmountLabel2);
            this.uiGroupBox3.Controls.Add(this.costAmountNumericEditBox1);
            this.uiGroupBox3.Controls.Add(preJudgmentInterestAmountLabel1);
            this.uiGroupBox3.Controls.Add(this.preJudgmentInterestAmountNumericEditBox);
            this.uiGroupBox3.Controls.Add(this.preJudgmentInterestToCalendarCombo1);
            this.uiGroupBox3.Controls.Add(this.preJudgmentInterestFromCalendarCombo1);
            this.uiGroupBox3.Controls.Add(this.preJudgmentRateTypeucMultiDropDown);
            this.uiGroupBox3.Controls.Add(this.preJudgmentInterestRateNumericEditBox);
            this.uiGroupBox3.Controls.Add(principalAmountBeforeJudgmentLabel1);
            this.uiGroupBox3.Controls.Add(this.principalAmountBeforeJudgmentNumericEditBox);
            this.uiGroupBox3.Controls.Add(judgmentAmountLabel);
            this.uiGroupBox3.Controls.Add(preJudgmentInterestToLabel1);
            this.uiGroupBox3.Controls.Add(preJudgmentInterestFromLabel1);
            this.uiGroupBox3.Controls.Add(preJudgmentInterestRateLabel1);
            this.errorProviderWrit.SetError(this.uiGroupBox3, resources.GetString("uiGroupBox3.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiGroupBox3, resources.GetString("uiGroupBox3.Error1"));
            this.errorProviderCost.SetError(this.uiGroupBox3, resources.GetString("uiGroupBox3.Error2"));
            this.errorProvider1.SetError(this.uiGroupBox3, resources.GetString("uiGroupBox3.Error3"));
            this.uiGroupBox3.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.helpProvider1.SetHelpKeyword(this.uiGroupBox3, resources.GetString("uiGroupBox3.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiGroupBox3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiGroupBox3.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiGroupBox3, resources.GetString("uiGroupBox3.HelpString"));
            this.errorProvider1.SetIconAlignment(this.uiGroupBox3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox3.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiGroupBox3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox3.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.uiGroupBox3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox3.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiGroupBox3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox3.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiGroupBox3, ((int)(resources.GetObject("uiGroupBox3.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.uiGroupBox3, ((int)(resources.GetObject("uiGroupBox3.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiGroupBox3, ((int)(resources.GetObject("uiGroupBox3.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.uiGroupBox3, ((int)(resources.GetObject("uiGroupBox3.IconPadding3"))));
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.helpProvider1.SetShowHelp(this.uiGroupBox3, ((bool)(resources.GetObject("uiGroupBox3.ShowHelp"))));
            this.toolTip1.SetToolTip(this.uiGroupBox3, resources.GetString("uiGroupBox3.ToolTip"));
            this.uiGroupBox3.UseThemes = false;
            this.uiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // judgmentAmountNumericEditBox1
            // 
            resources.ApplyResources(this.judgmentAmountNumericEditBox1, "judgmentAmountNumericEditBox1");
            this.judgmentAmountNumericEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentAccountDataTableBindingSource, "JudgmentAmount", true));
            this.errorProviderJudgmentAccount.SetError(this.judgmentAmountNumericEditBox1, resources.GetString("judgmentAmountNumericEditBox1.Error"));
            this.errorProviderCost.SetError(this.judgmentAmountNumericEditBox1, resources.GetString("judgmentAmountNumericEditBox1.Error1"));
            this.errorProvider1.SetError(this.judgmentAmountNumericEditBox1, resources.GetString("judgmentAmountNumericEditBox1.Error2"));
            this.errorProviderWrit.SetError(this.judgmentAmountNumericEditBox1, resources.GetString("judgmentAmountNumericEditBox1.Error3"));
            this.judgmentAmountNumericEditBox1.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            this.helpProvider1.SetHelpKeyword(this.judgmentAmountNumericEditBox1, resources.GetString("judgmentAmountNumericEditBox1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.judgmentAmountNumericEditBox1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentAmountNumericEditBox1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.judgmentAmountNumericEditBox1, resources.GetString("judgmentAmountNumericEditBox1.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.judgmentAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox1.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.judgmentAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.judgmentAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox1.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.judgmentAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAmountNumericEditBox1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.judgmentAmountNumericEditBox1, ((int)(resources.GetObject("judgmentAmountNumericEditBox1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.judgmentAmountNumericEditBox1, ((int)(resources.GetObject("judgmentAmountNumericEditBox1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.judgmentAmountNumericEditBox1, ((int)(resources.GetObject("judgmentAmountNumericEditBox1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.judgmentAmountNumericEditBox1, ((int)(resources.GetObject("judgmentAmountNumericEditBox1.IconPadding3"))));
            this.judgmentAmountNumericEditBox1.Name = "judgmentAmountNumericEditBox1";
            this.helpProvider1.SetShowHelp(this.judgmentAmountNumericEditBox1, ((bool)(resources.GetObject("judgmentAmountNumericEditBox1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.judgmentAmountNumericEditBox1, resources.GetString("judgmentAmountNumericEditBox1.ToolTip"));
            this.judgmentAmountNumericEditBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.judgmentAmountNumericEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // costAmountNumericEditBox1
            // 
            resources.ApplyResources(this.costAmountNumericEditBox1, "costAmountNumericEditBox1");
            this.costAmountNumericEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentAccountDataTableBindingSource, "CostAmount", true));
            this.errorProviderJudgmentAccount.SetError(this.costAmountNumericEditBox1, resources.GetString("costAmountNumericEditBox1.Error"));
            this.errorProviderCost.SetError(this.costAmountNumericEditBox1, resources.GetString("costAmountNumericEditBox1.Error1"));
            this.errorProvider1.SetError(this.costAmountNumericEditBox1, resources.GetString("costAmountNumericEditBox1.Error2"));
            this.errorProviderWrit.SetError(this.costAmountNumericEditBox1, resources.GetString("costAmountNumericEditBox1.Error3"));
            this.costAmountNumericEditBox1.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            this.helpProvider1.SetHelpKeyword(this.costAmountNumericEditBox1, resources.GetString("costAmountNumericEditBox1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.costAmountNumericEditBox1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("costAmountNumericEditBox1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.costAmountNumericEditBox1, resources.GetString("costAmountNumericEditBox1.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.costAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox1.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.costAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.costAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox1.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.costAmountNumericEditBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.costAmountNumericEditBox1, ((int)(resources.GetObject("costAmountNumericEditBox1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.costAmountNumericEditBox1, ((int)(resources.GetObject("costAmountNumericEditBox1.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.costAmountNumericEditBox1, ((int)(resources.GetObject("costAmountNumericEditBox1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.costAmountNumericEditBox1, ((int)(resources.GetObject("costAmountNumericEditBox1.IconPadding3"))));
            this.costAmountNumericEditBox1.Name = "costAmountNumericEditBox1";
            this.helpProvider1.SetShowHelp(this.costAmountNumericEditBox1, ((bool)(resources.GetObject("costAmountNumericEditBox1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.costAmountNumericEditBox1, resources.GetString("costAmountNumericEditBox1.ToolTip"));
            this.costAmountNumericEditBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.costAmountNumericEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // preJudgmentInterestAmountNumericEditBox
            // 
            resources.ApplyResources(this.preJudgmentInterestAmountNumericEditBox, "preJudgmentInterestAmountNumericEditBox");
            this.preJudgmentInterestAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentAccountDataTableBindingSource, "PreJudgmentInterestAmount", true));
            this.errorProviderJudgmentAccount.SetError(this.preJudgmentInterestAmountNumericEditBox, resources.GetString("preJudgmentInterestAmountNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.preJudgmentInterestAmountNumericEditBox, resources.GetString("preJudgmentInterestAmountNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.preJudgmentInterestAmountNumericEditBox, resources.GetString("preJudgmentInterestAmountNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.preJudgmentInterestAmountNumericEditBox, resources.GetString("preJudgmentInterestAmountNumericEditBox.Error3"));
            this.preJudgmentInterestAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            this.helpProvider1.SetHelpKeyword(this.preJudgmentInterestAmountNumericEditBox, resources.GetString("preJudgmentInterestAmountNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.preJudgmentInterestAmountNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.preJudgmentInterestAmountNumericEditBox, resources.GetString("preJudgmentInterestAmountNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.preJudgmentInterestAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.preJudgmentInterestAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.preJudgmentInterestAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.preJudgmentInterestAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.preJudgmentInterestAmountNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.preJudgmentInterestAmountNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.preJudgmentInterestAmountNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.preJudgmentInterestAmountNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.IconPadding3"))));
            this.preJudgmentInterestAmountNumericEditBox.Name = "preJudgmentInterestAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.preJudgmentInterestAmountNumericEditBox, ((bool)(resources.GetObject("preJudgmentInterestAmountNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.preJudgmentInterestAmountNumericEditBox, resources.GetString("preJudgmentInterestAmountNumericEditBox.ToolTip"));
            this.preJudgmentInterestAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.preJudgmentInterestAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // preJudgmentInterestToCalendarCombo1
            // 
            resources.ApplyResources(this.preJudgmentInterestToCalendarCombo1, "preJudgmentInterestToCalendarCombo1");
            this.preJudgmentInterestToCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentAccountDataTableBindingSource, "PreJudgmentInterestTo", true));
            this.preJudgmentInterestToCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("preJudgmentInterestToCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("preJudgmentInterestToCalendarCombo1.DropDownCalendar.AccessibleName");
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.Anchor")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.Dock")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.Font")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("preJudgmentInterestToCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.ImeMode")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.Visible")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.preJudgmentInterestToCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("preJudgmentInterestToCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.preJudgmentInterestToCalendarCombo1, resources.GetString("preJudgmentInterestToCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.preJudgmentInterestToCalendarCombo1, resources.GetString("preJudgmentInterestToCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.preJudgmentInterestToCalendarCombo1, resources.GetString("preJudgmentInterestToCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.preJudgmentInterestToCalendarCombo1, resources.GetString("preJudgmentInterestToCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.preJudgmentInterestToCalendarCombo1, resources.GetString("preJudgmentInterestToCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.preJudgmentInterestToCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestToCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.preJudgmentInterestToCalendarCombo1, resources.GetString("preJudgmentInterestToCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.preJudgmentInterestToCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.preJudgmentInterestToCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.preJudgmentInterestToCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.preJudgmentInterestToCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.preJudgmentInterestToCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.preJudgmentInterestToCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.preJudgmentInterestToCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.preJudgmentInterestToCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestToCalendarCombo1.IconPadding3"))));
            this.preJudgmentInterestToCalendarCombo1.MonthIncrement = 0;
            this.preJudgmentInterestToCalendarCombo1.Name = "preJudgmentInterestToCalendarCombo1";
            this.preJudgmentInterestToCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.preJudgmentInterestToCalendarCombo1, ((bool)(resources.GetObject("preJudgmentInterestToCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.preJudgmentInterestToCalendarCombo1, resources.GetString("preJudgmentInterestToCalendarCombo1.ToolTip"));
            this.preJudgmentInterestToCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.preJudgmentInterestToCalendarCombo1.YearIncrement = 0;
            // 
            // preJudgmentInterestFromCalendarCombo1
            // 
            resources.ApplyResources(this.preJudgmentInterestFromCalendarCombo1, "preJudgmentInterestFromCalendarCombo1");
            this.preJudgmentInterestFromCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_JudgmentAccountDataTableBindingSource, "PreJudgmentInterestFrom", true));
            this.preJudgmentInterestFromCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.AccessibleName");
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Anchor")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Dock")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Font")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.ImeMode")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.Visible")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.preJudgmentInterestFromCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.preJudgmentInterestFromCalendarCombo1, resources.GetString("preJudgmentInterestFromCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.preJudgmentInterestFromCalendarCombo1, resources.GetString("preJudgmentInterestFromCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.preJudgmentInterestFromCalendarCombo1, resources.GetString("preJudgmentInterestFromCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.preJudgmentInterestFromCalendarCombo1, resources.GetString("preJudgmentInterestFromCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.preJudgmentInterestFromCalendarCombo1, resources.GetString("preJudgmentInterestFromCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.preJudgmentInterestFromCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.preJudgmentInterestFromCalendarCombo1, resources.GetString("preJudgmentInterestFromCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.preJudgmentInterestFromCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.preJudgmentInterestFromCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.preJudgmentInterestFromCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.preJudgmentInterestFromCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.preJudgmentInterestFromCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.preJudgmentInterestFromCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.preJudgmentInterestFromCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.preJudgmentInterestFromCalendarCombo1, ((int)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.IconPadding3"))));
            this.preJudgmentInterestFromCalendarCombo1.MonthIncrement = 0;
            this.preJudgmentInterestFromCalendarCombo1.Name = "preJudgmentInterestFromCalendarCombo1";
            this.preJudgmentInterestFromCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.preJudgmentInterestFromCalendarCombo1, ((bool)(resources.GetObject("preJudgmentInterestFromCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.preJudgmentInterestFromCalendarCombo1, resources.GetString("preJudgmentInterestFromCalendarCombo1.ToolTip"));
            this.preJudgmentInterestFromCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.preJudgmentInterestFromCalendarCombo1.YearIncrement = 0;
            // 
            // preJudgmentRateTypeucMultiDropDown
            // 
            resources.ApplyResources(this.preJudgmentRateTypeucMultiDropDown, "preJudgmentRateTypeucMultiDropDown");
            this.preJudgmentRateTypeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.preJudgmentRateTypeucMultiDropDown.Column1 = "InterestRateCode";
            this.preJudgmentRateTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.preJudgmentRateTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_JudgmentAccountDataTableBindingSource, "PreJudgmentRateType", true));
            this.preJudgmentRateTypeucMultiDropDown.DataSource = null;
            this.preJudgmentRateTypeucMultiDropDown.DDColumn1Visible = true;
            this.preJudgmentRateTypeucMultiDropDown.DropDownColumn1Width = 50;
            this.preJudgmentRateTypeucMultiDropDown.DropDownColumn2Width = 200;
            this.errorProviderCost.SetError(this.preJudgmentRateTypeucMultiDropDown, resources.GetString("preJudgmentRateTypeucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.preJudgmentRateTypeucMultiDropDown, resources.GetString("preJudgmentRateTypeucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.preJudgmentRateTypeucMultiDropDown, resources.GetString("preJudgmentRateTypeucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.preJudgmentRateTypeucMultiDropDown, resources.GetString("preJudgmentRateTypeucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.preJudgmentRateTypeucMultiDropDown, resources.GetString("preJudgmentRateTypeucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.preJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.preJudgmentRateTypeucMultiDropDown, resources.GetString("preJudgmentRateTypeucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.preJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.preJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.preJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.preJudgmentRateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.preJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.preJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.preJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.preJudgmentRateTypeucMultiDropDown, ((int)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.IconPadding3"))));
            this.preJudgmentRateTypeucMultiDropDown.Name = "preJudgmentRateTypeucMultiDropDown";
            this.preJudgmentRateTypeucMultiDropDown.ReadOnly = false;
            this.preJudgmentRateTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.preJudgmentRateTypeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.preJudgmentRateTypeucMultiDropDown, ((bool)(resources.GetObject("preJudgmentRateTypeucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.preJudgmentRateTypeucMultiDropDown, resources.GetString("preJudgmentRateTypeucMultiDropDown.ToolTip"));
            this.preJudgmentRateTypeucMultiDropDown.ValueMember = "InterestRateCode";
            // 
            // preJudgmentInterestRateNumericEditBox
            // 
            resources.ApplyResources(this.preJudgmentInterestRateNumericEditBox, "preJudgmentInterestRateNumericEditBox");
            this.preJudgmentInterestRateNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentAccountDataTableBindingSource, "PreJudgmentInterestRate", true));
            this.preJudgmentInterestRateNumericEditBox.DecimalDigits = 3;
            this.errorProviderJudgmentAccount.SetError(this.preJudgmentInterestRateNumericEditBox, resources.GetString("preJudgmentInterestRateNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.preJudgmentInterestRateNumericEditBox, resources.GetString("preJudgmentInterestRateNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.preJudgmentInterestRateNumericEditBox, resources.GetString("preJudgmentInterestRateNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.preJudgmentInterestRateNumericEditBox, resources.GetString("preJudgmentInterestRateNumericEditBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.preJudgmentInterestRateNumericEditBox, resources.GetString("preJudgmentInterestRateNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.preJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("preJudgmentInterestRateNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.preJudgmentInterestRateNumericEditBox, resources.GetString("preJudgmentInterestRateNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.preJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.preJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.preJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.preJudgmentInterestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.preJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.preJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.preJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.preJudgmentInterestRateNumericEditBox, ((int)(resources.GetObject("preJudgmentInterestRateNumericEditBox.IconPadding3"))));
            this.preJudgmentInterestRateNumericEditBox.Name = "preJudgmentInterestRateNumericEditBox";
            this.helpProvider1.SetShowHelp(this.preJudgmentInterestRateNumericEditBox, ((bool)(resources.GetObject("preJudgmentInterestRateNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.preJudgmentInterestRateNumericEditBox, resources.GetString("preJudgmentInterestRateNumericEditBox.ToolTip"));
            this.preJudgmentInterestRateNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.preJudgmentInterestRateNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // principalAmountBeforeJudgmentNumericEditBox
            // 
            resources.ApplyResources(this.principalAmountBeforeJudgmentNumericEditBox, "principalAmountBeforeJudgmentNumericEditBox");
            this.principalAmountBeforeJudgmentNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_JudgmentAccountDataTableBindingSource, "PrincipalAmountBeforeJudgment", true));
            this.errorProviderJudgmentAccount.SetError(this.principalAmountBeforeJudgmentNumericEditBox, resources.GetString("principalAmountBeforeJudgmentNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.principalAmountBeforeJudgmentNumericEditBox, resources.GetString("principalAmountBeforeJudgmentNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.principalAmountBeforeJudgmentNumericEditBox, resources.GetString("principalAmountBeforeJudgmentNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.principalAmountBeforeJudgmentNumericEditBox, resources.GetString("principalAmountBeforeJudgmentNumericEditBox.Error3"));
            this.principalAmountBeforeJudgmentNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            this.helpProvider1.SetHelpKeyword(this.principalAmountBeforeJudgmentNumericEditBox, resources.GetString("principalAmountBeforeJudgmentNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.principalAmountBeforeJudgmentNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.principalAmountBeforeJudgmentNumericEditBox, resources.GetString("principalAmountBeforeJudgmentNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.principalAmountBeforeJudgmentNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.principalAmountBeforeJudgmentNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.principalAmountBeforeJudgmentNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.principalAmountBeforeJudgmentNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.principalAmountBeforeJudgmentNumericEditBox, ((int)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.principalAmountBeforeJudgmentNumericEditBox, ((int)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.principalAmountBeforeJudgmentNumericEditBox, ((int)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.principalAmountBeforeJudgmentNumericEditBox, ((int)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.IconPadding3"))));
            this.principalAmountBeforeJudgmentNumericEditBox.Name = "principalAmountBeforeJudgmentNumericEditBox";
            this.helpProvider1.SetShowHelp(this.principalAmountBeforeJudgmentNumericEditBox, ((bool)(resources.GetObject("principalAmountBeforeJudgmentNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.principalAmountBeforeJudgmentNumericEditBox, resources.GetString("principalAmountBeforeJudgmentNumericEditBox.ToolTip"));
            this.principalAmountBeforeJudgmentNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.principalAmountBeforeJudgmentNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // judgmentAccountGridEX
            // 
            resources.ApplyResources(this.judgmentAccountGridEX, "judgmentAccountGridEX");
            this.judgmentAccountGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.judgmentAccountGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.judgmentAccountGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.judgmentAccountGridEX.DataSource = this.atriumDB_JudgmentAccountDataTableBindingSource;
            resources.ApplyResources(judgmentAccountGridEX_DesignTimeLayout, "judgmentAccountGridEX_DesignTimeLayout");
            this.judgmentAccountGridEX.DesignTimeLayout = judgmentAccountGridEX_DesignTimeLayout;
            this.errorProviderCost.SetError(this.judgmentAccountGridEX, resources.GetString("judgmentAccountGridEX.Error"));
            this.errorProvider1.SetError(this.judgmentAccountGridEX, resources.GetString("judgmentAccountGridEX.Error1"));
            this.errorProviderJudgmentAccount.SetError(this.judgmentAccountGridEX, resources.GetString("judgmentAccountGridEX.Error2"));
            this.errorProviderWrit.SetError(this.judgmentAccountGridEX, resources.GetString("judgmentAccountGridEX.Error3"));
            this.judgmentAccountGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.judgmentAccountGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.judgmentAccountGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.judgmentAccountGridEX.GroupByBoxVisible = false;
            this.judgmentAccountGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.helpProvider1.SetHelpKeyword(this.judgmentAccountGridEX, resources.GetString("judgmentAccountGridEX.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.judgmentAccountGridEX, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("judgmentAccountGridEX.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.judgmentAccountGridEX, resources.GetString("judgmentAccountGridEX.HelpString"));
            this.judgmentAccountGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.errorProviderJudgmentAccount.SetIconAlignment(this.judgmentAccountGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAccountGridEX.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.judgmentAccountGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAccountGridEX.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.judgmentAccountGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAccountGridEX.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.judgmentAccountGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("judgmentAccountGridEX.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.judgmentAccountGridEX, ((int)(resources.GetObject("judgmentAccountGridEX.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.judgmentAccountGridEX, ((int)(resources.GetObject("judgmentAccountGridEX.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.judgmentAccountGridEX, ((int)(resources.GetObject("judgmentAccountGridEX.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.judgmentAccountGridEX, ((int)(resources.GetObject("judgmentAccountGridEX.IconPadding3"))));
            this.judgmentAccountGridEX.Name = "judgmentAccountGridEX";
            this.helpProvider1.SetShowHelp(this.judgmentAccountGridEX, ((bool)(resources.GetObject("judgmentAccountGridEX.ShowHelp"))));
            this.judgmentAccountGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.toolTip1.SetToolTip(this.judgmentAccountGridEX, resources.GetString("judgmentAccountGridEX.ToolTip"));
            this.judgmentAccountGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.judgmentAccountGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.judgmentAccountGridEX.TotalRowFormatStyle.FontName = "arial";
            this.judgmentAccountGridEX.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.judgmentAccountGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.judgmentAccountGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.judgmentAccountGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.judgmentAccountGridEX_CurrentCellChanging);
            // 
            // uiTabPage2
            // 
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Controls.Add(this.uiGroupBox2);
            this.uiTabPage2.Controls.Add(this.atriumDB_WritHistoryDataTableGridEX);
            this.uiTabPage2.Controls.Add(this.writGridEX);
            this.errorProviderCost.SetError(this.uiTabPage2, resources.GetString("uiTabPage2.Error"));
            this.errorProvider1.SetError(this.uiTabPage2, resources.GetString("uiTabPage2.Error1"));
            this.errorProviderWrit.SetError(this.uiTabPage2, resources.GetString("uiTabPage2.Error2"));
            this.errorProviderJudgmentAccount.SetError(this.uiTabPage2, resources.GetString("uiTabPage2.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTabPage2, resources.GetString("uiTabPage2.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTabPage2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTabPage2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTabPage2, resources.GetString("uiTabPage2.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTabPage2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage2.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTabPage2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage2.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.uiTabPage2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage2.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiTabPage2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage2.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTabPage2, ((int)(resources.GetObject("uiTabPage2.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTabPage2, ((int)(resources.GetObject("uiTabPage2.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.uiTabPage2, ((int)(resources.GetObject("uiTabPage2.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTabPage2, ((int)(resources.GetObject("uiTabPage2.IconPadding3"))));
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            this.toolTip1.SetToolTip(this.uiTabPage2, resources.GetString("uiTabPage2.ToolTip"));
            // 
            // uiGroupBox2
            // 
            resources.ApplyResources(this.uiGroupBox2, "uiGroupBox2");
            this.uiGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox2.Controls.Add(sheriffJurisdictionLabel1);
            this.uiGroupBox2.Controls.Add(this.sheriffJurisdictionEditBox);
            this.uiGroupBox2.Controls.Add(executionorRegistrationNumberLabel1);
            this.uiGroupBox2.Controls.Add(this.executionorRegistrationNumberEditBox);
            this.uiGroupBox2.Controls.Add(officeIDLabel);
            this.uiGroupBox2.Controls.Add(this.officeIDucOfficeSelectBox);
            this.uiGroupBox2.Controls.Add(typeofWritCodeLabel1);
            this.uiGroupBox2.Controls.Add(this.typeofWritCodeucMultiDropDown);
            this.uiGroupBox2.Controls.Add(expiryDateLabel1);
            this.uiGroupBox2.Controls.Add(this.expiryDateCalendarCombo1);
            this.uiGroupBox2.Controls.Add(this.issueRenewalDateCalendarCombo1);
            this.uiGroupBox2.Controls.Add(issueRenewalDateLabel1);
            this.errorProviderWrit.SetError(this.uiGroupBox2, resources.GetString("uiGroupBox2.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiGroupBox2, resources.GetString("uiGroupBox2.Error1"));
            this.errorProviderCost.SetError(this.uiGroupBox2, resources.GetString("uiGroupBox2.Error2"));
            this.errorProvider1.SetError(this.uiGroupBox2, resources.GetString("uiGroupBox2.Error3"));
            this.uiGroupBox2.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.helpProvider1.SetHelpKeyword(this.uiGroupBox2, resources.GetString("uiGroupBox2.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiGroupBox2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiGroupBox2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiGroupBox2, resources.GetString("uiGroupBox2.HelpString"));
            this.errorProvider1.SetIconAlignment(this.uiGroupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox2.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiGroupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox2.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.uiGroupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox2.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiGroupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox2.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiGroupBox2, ((int)(resources.GetObject("uiGroupBox2.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.uiGroupBox2, ((int)(resources.GetObject("uiGroupBox2.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiGroupBox2, ((int)(resources.GetObject("uiGroupBox2.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.uiGroupBox2, ((int)(resources.GetObject("uiGroupBox2.IconPadding3"))));
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.helpProvider1.SetShowHelp(this.uiGroupBox2, ((bool)(resources.GetObject("uiGroupBox2.ShowHelp"))));
            this.toolTip1.SetToolTip(this.uiGroupBox2, resources.GetString("uiGroupBox2.ToolTip"));
            this.uiGroupBox2.UseThemes = false;
            this.uiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault;
            // 
            // sheriffJurisdictionEditBox
            // 
            resources.ApplyResources(this.sheriffJurisdictionEditBox, "sheriffJurisdictionEditBox");
            this.sheriffJurisdictionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.atriumDB_WritDataTableBindingSource, "SheriffJurisdiction", true));
            this.errorProviderJudgmentAccount.SetError(this.sheriffJurisdictionEditBox, resources.GetString("sheriffJurisdictionEditBox.Error"));
            this.errorProviderCost.SetError(this.sheriffJurisdictionEditBox, resources.GetString("sheriffJurisdictionEditBox.Error1"));
            this.errorProvider1.SetError(this.sheriffJurisdictionEditBox, resources.GetString("sheriffJurisdictionEditBox.Error2"));
            this.errorProviderWrit.SetError(this.sheriffJurisdictionEditBox, resources.GetString("sheriffJurisdictionEditBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.sheriffJurisdictionEditBox, resources.GetString("sheriffJurisdictionEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.sheriffJurisdictionEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("sheriffJurisdictionEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.sheriffJurisdictionEditBox, resources.GetString("sheriffJurisdictionEditBox.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.sheriffJurisdictionEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionEditBox.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.sheriffJurisdictionEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionEditBox.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(this.sheriffJurisdictionEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionEditBox.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.sheriffJurisdictionEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("sheriffJurisdictionEditBox.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(this.sheriffJurisdictionEditBox, ((int)(resources.GetObject("sheriffJurisdictionEditBox.IconPadding"))));
            this.errorProviderWrit.SetIconPadding(this.sheriffJurisdictionEditBox, ((int)(resources.GetObject("sheriffJurisdictionEditBox.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.sheriffJurisdictionEditBox, ((int)(resources.GetObject("sheriffJurisdictionEditBox.IconPadding2"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.sheriffJurisdictionEditBox, ((int)(resources.GetObject("sheriffJurisdictionEditBox.IconPadding3"))));
            this.sheriffJurisdictionEditBox.Name = "sheriffJurisdictionEditBox";
            this.helpProvider1.SetShowHelp(this.sheriffJurisdictionEditBox, ((bool)(resources.GetObject("sheriffJurisdictionEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.sheriffJurisdictionEditBox, resources.GetString("sheriffJurisdictionEditBox.ToolTip"));
            this.sheriffJurisdictionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // atriumDB_WritDataTableBindingSource
            // 
            this.atriumDB_WritDataTableBindingSource.DataMember = "JudgmentWrit";
            this.atriumDB_WritDataTableBindingSource.DataSource = this.atriumDB_JudgmentDataTableBindingSource;
            this.atriumDB_WritDataTableBindingSource.CurrentChanged += new System.EventHandler(this.writBindingSource_CurrentChanged);
            // 
            // executionorRegistrationNumberEditBox
            // 
            resources.ApplyResources(this.executionorRegistrationNumberEditBox, "executionorRegistrationNumberEditBox");
            this.executionorRegistrationNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.atriumDB_WritDataTableBindingSource, "ExecutionorRegistrationNumber", true));
            this.errorProviderJudgmentAccount.SetError(this.executionorRegistrationNumberEditBox, resources.GetString("executionorRegistrationNumberEditBox.Error"));
            this.errorProviderCost.SetError(this.executionorRegistrationNumberEditBox, resources.GetString("executionorRegistrationNumberEditBox.Error1"));
            this.errorProvider1.SetError(this.executionorRegistrationNumberEditBox, resources.GetString("executionorRegistrationNumberEditBox.Error2"));
            this.errorProviderWrit.SetError(this.executionorRegistrationNumberEditBox, resources.GetString("executionorRegistrationNumberEditBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.executionorRegistrationNumberEditBox, resources.GetString("executionorRegistrationNumberEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.executionorRegistrationNumberEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("executionorRegistrationNumberEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.executionorRegistrationNumberEditBox, resources.GetString("executionorRegistrationNumberEditBox.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.executionorRegistrationNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberEditBox.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.executionorRegistrationNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberEditBox.IconAlignment1"))));
            this.errorProviderCost.SetIconAlignment(this.executionorRegistrationNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberEditBox.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.executionorRegistrationNumberEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("executionorRegistrationNumberEditBox.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(this.executionorRegistrationNumberEditBox, ((int)(resources.GetObject("executionorRegistrationNumberEditBox.IconPadding"))));
            this.errorProviderWrit.SetIconPadding(this.executionorRegistrationNumberEditBox, ((int)(resources.GetObject("executionorRegistrationNumberEditBox.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.executionorRegistrationNumberEditBox, ((int)(resources.GetObject("executionorRegistrationNumberEditBox.IconPadding2"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.executionorRegistrationNumberEditBox, ((int)(resources.GetObject("executionorRegistrationNumberEditBox.IconPadding3"))));
            this.executionorRegistrationNumberEditBox.Name = "executionorRegistrationNumberEditBox";
            this.helpProvider1.SetShowHelp(this.executionorRegistrationNumberEditBox, ((bool)(resources.GetObject("executionorRegistrationNumberEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.executionorRegistrationNumberEditBox, resources.GetString("executionorRegistrationNumberEditBox.ToolTip"));
            this.executionorRegistrationNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeIDucOfficeSelectBox
            // 
            resources.ApplyResources(this.officeIDucOfficeSelectBox, "officeIDucOfficeSelectBox");
            this.officeIDucOfficeSelectBox.AtMng = null;
            this.officeIDucOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIDucOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.atriumDB_WritDataTableBindingSource, "OfficeID", true));
            this.errorProviderWrit.SetError(this.officeIDucOfficeSelectBox, resources.GetString("officeIDucOfficeSelectBox.Error"));
            this.errorProviderJudgmentAccount.SetError(this.officeIDucOfficeSelectBox, resources.GetString("officeIDucOfficeSelectBox.Error1"));
            this.errorProvider1.SetError(this.officeIDucOfficeSelectBox, resources.GetString("officeIDucOfficeSelectBox.Error2"));
            this.errorProviderCost.SetError(this.officeIDucOfficeSelectBox, resources.GetString("officeIDucOfficeSelectBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.officeIDucOfficeSelectBox, resources.GetString("officeIDucOfficeSelectBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.officeIDucOfficeSelectBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("officeIDucOfficeSelectBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.officeIDucOfficeSelectBox, resources.GetString("officeIDucOfficeSelectBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.officeIDucOfficeSelectBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.officeIDucOfficeSelectBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.officeIDucOfficeSelectBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.officeIDucOfficeSelectBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("officeIDucOfficeSelectBox.IconAlignment3"))));
            this.errorProvider1.SetIconPadding(this.officeIDucOfficeSelectBox, ((int)(resources.GetObject("officeIDucOfficeSelectBox.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.officeIDucOfficeSelectBox, ((int)(resources.GetObject("officeIDucOfficeSelectBox.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.officeIDucOfficeSelectBox, ((int)(resources.GetObject("officeIDucOfficeSelectBox.IconPadding2"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.officeIDucOfficeSelectBox, ((int)(resources.GetObject("officeIDucOfficeSelectBox.IconPadding3"))));
            this.officeIDucOfficeSelectBox.Name = "officeIDucOfficeSelectBox";
            this.officeIDucOfficeSelectBox.OfficeId = null;
            this.officeIDucOfficeSelectBox.ReadOnly = true;
            this.officeIDucOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIDucOfficeSelectBox, ((bool)(resources.GetObject("officeIDucOfficeSelectBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.officeIDucOfficeSelectBox, resources.GetString("officeIDucOfficeSelectBox.ToolTip"));
            // 
            // typeofWritCodeucMultiDropDown
            // 
            resources.ApplyResources(this.typeofWritCodeucMultiDropDown, "typeofWritCodeucMultiDropDown");
            this.typeofWritCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.typeofWritCodeucMultiDropDown.Column1 = "TypeOfWritCode";
            this.typeofWritCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.typeofWritCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_WritDataTableBindingSource, "TypeofWritCode", true));
            this.typeofWritCodeucMultiDropDown.DataSource = null;
            this.typeofWritCodeucMultiDropDown.DDColumn1Visible = true;
            this.typeofWritCodeucMultiDropDown.DropDownColumn1Width = 100;
            this.typeofWritCodeucMultiDropDown.DropDownColumn2Width = 300;
            this.errorProviderCost.SetError(this.typeofWritCodeucMultiDropDown, resources.GetString("typeofWritCodeucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.typeofWritCodeucMultiDropDown, resources.GetString("typeofWritCodeucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.typeofWritCodeucMultiDropDown, resources.GetString("typeofWritCodeucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.typeofWritCodeucMultiDropDown, resources.GetString("typeofWritCodeucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.typeofWritCodeucMultiDropDown, resources.GetString("typeofWritCodeucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.typeofWritCodeucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("typeofWritCodeucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.typeofWritCodeucMultiDropDown, resources.GetString("typeofWritCodeucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.typeofWritCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.typeofWritCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.typeofWritCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.typeofWritCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("typeofWritCodeucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.typeofWritCodeucMultiDropDown, ((int)(resources.GetObject("typeofWritCodeucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.typeofWritCodeucMultiDropDown, ((int)(resources.GetObject("typeofWritCodeucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.typeofWritCodeucMultiDropDown, ((int)(resources.GetObject("typeofWritCodeucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.typeofWritCodeucMultiDropDown, ((int)(resources.GetObject("typeofWritCodeucMultiDropDown.IconPadding3"))));
            this.typeofWritCodeucMultiDropDown.Name = "typeofWritCodeucMultiDropDown";
            this.typeofWritCodeucMultiDropDown.ReadOnly = false;
            this.typeofWritCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.typeofWritCodeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.typeofWritCodeucMultiDropDown, ((bool)(resources.GetObject("typeofWritCodeucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.typeofWritCodeucMultiDropDown, resources.GetString("typeofWritCodeucMultiDropDown.ToolTip"));
            this.typeofWritCodeucMultiDropDown.ValueMember = "TypeOfWritCode";
            // 
            // expiryDateCalendarCombo1
            // 
            resources.ApplyResources(this.expiryDateCalendarCombo1, "expiryDateCalendarCombo1");
            this.expiryDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_WritDataTableBindingSource, "ExpiryDate", true));
            this.expiryDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.expiryDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("expiryDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.expiryDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("expiryDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.expiryDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.expiryDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.expiryDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.expiryDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.expiryDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.Dock")));
            this.expiryDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.expiryDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.Font")));
            this.expiryDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("expiryDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.expiryDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.expiryDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.expiryDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.expiryDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.Visible")));
            this.expiryDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.expiryDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.expiryDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("expiryDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.expiryDateCalendarCombo1, resources.GetString("expiryDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.expiryDateCalendarCombo1, resources.GetString("expiryDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.expiryDateCalendarCombo1, resources.GetString("expiryDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.expiryDateCalendarCombo1, resources.GetString("expiryDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.expiryDateCalendarCombo1, resources.GetString("expiryDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.expiryDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("expiryDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.expiryDateCalendarCombo1, resources.GetString("expiryDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.expiryDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.expiryDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.expiryDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.expiryDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("expiryDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.expiryDateCalendarCombo1, ((int)(resources.GetObject("expiryDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.expiryDateCalendarCombo1, ((int)(resources.GetObject("expiryDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.expiryDateCalendarCombo1, ((int)(resources.GetObject("expiryDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.expiryDateCalendarCombo1, ((int)(resources.GetObject("expiryDateCalendarCombo1.IconPadding3"))));
            this.expiryDateCalendarCombo1.MonthIncrement = 0;
            this.expiryDateCalendarCombo1.Name = "expiryDateCalendarCombo1";
            this.expiryDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.expiryDateCalendarCombo1, ((bool)(resources.GetObject("expiryDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.expiryDateCalendarCombo1, resources.GetString("expiryDateCalendarCombo1.ToolTip"));
            this.expiryDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.expiryDateCalendarCombo1.YearIncrement = 0;
            // 
            // issueRenewalDateCalendarCombo1
            // 
            resources.ApplyResources(this.issueRenewalDateCalendarCombo1, "issueRenewalDateCalendarCombo1");
            this.issueRenewalDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_WritDataTableBindingSource, "IssueRenewalDate", true));
            this.issueRenewalDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.AccessibleDescription = resources.GetString("issueRenewalDateCalendarCombo1.DropDownCalendar.AccessibleDescription");
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.AccessibleName = resources.GetString("issueRenewalDateCalendarCombo1.DropDownCalendar.AccessibleName");
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.Anchor")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.BackgroundImage")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.BackgroundImageLayout")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.DayOfWeekAbbreviation")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.Dock")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.FirstDayOfWeek")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.Font")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.HeaderFormat = resources.GetString("issueRenewalDateCalendarCombo1.DropDownCalendar.HeaderFormat");
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.ImeMode")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.MaximumSize")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.RightToLeft")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.Visible = ((bool)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.Visible")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.WeekNumbers")));
            this.issueRenewalDateCalendarCombo1.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("issueRenewalDateCalendarCombo1.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.issueRenewalDateCalendarCombo1, resources.GetString("issueRenewalDateCalendarCombo1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.issueRenewalDateCalendarCombo1, resources.GetString("issueRenewalDateCalendarCombo1.Error1"));
            this.errorProvider1.SetError(this.issueRenewalDateCalendarCombo1, resources.GetString("issueRenewalDateCalendarCombo1.Error2"));
            this.errorProviderWrit.SetError(this.issueRenewalDateCalendarCombo1, resources.GetString("issueRenewalDateCalendarCombo1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.issueRenewalDateCalendarCombo1, resources.GetString("issueRenewalDateCalendarCombo1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.issueRenewalDateCalendarCombo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("issueRenewalDateCalendarCombo1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.issueRenewalDateCalendarCombo1, resources.GetString("issueRenewalDateCalendarCombo1.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.issueRenewalDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateCalendarCombo1.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.issueRenewalDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateCalendarCombo1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.issueRenewalDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateCalendarCombo1.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.issueRenewalDateCalendarCombo1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("issueRenewalDateCalendarCombo1.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.issueRenewalDateCalendarCombo1, ((int)(resources.GetObject("issueRenewalDateCalendarCombo1.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.issueRenewalDateCalendarCombo1, ((int)(resources.GetObject("issueRenewalDateCalendarCombo1.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.issueRenewalDateCalendarCombo1, ((int)(resources.GetObject("issueRenewalDateCalendarCombo1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.issueRenewalDateCalendarCombo1, ((int)(resources.GetObject("issueRenewalDateCalendarCombo1.IconPadding3"))));
            this.issueRenewalDateCalendarCombo1.MonthIncrement = 0;
            this.issueRenewalDateCalendarCombo1.Name = "issueRenewalDateCalendarCombo1";
            this.issueRenewalDateCalendarCombo1.Nullable = true;
            this.helpProvider1.SetShowHelp(this.issueRenewalDateCalendarCombo1, ((bool)(resources.GetObject("issueRenewalDateCalendarCombo1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.issueRenewalDateCalendarCombo1, resources.GetString("issueRenewalDateCalendarCombo1.ToolTip"));
            this.issueRenewalDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.issueRenewalDateCalendarCombo1.YearIncrement = 0;
            // 
            // atriumDB_WritHistoryDataTableGridEX
            // 
            resources.ApplyResources(this.atriumDB_WritHistoryDataTableGridEX, "atriumDB_WritHistoryDataTableGridEX");
            this.atriumDB_WritHistoryDataTableGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.atriumDB_WritHistoryDataTableGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.atriumDB_WritHistoryDataTableGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.atriumDB_WritHistoryDataTableGridEX.DataSource = this.atriumDB_WritHistoryDataTableBindingSource;
            resources.ApplyResources(atriumDB_WritHistoryDataTableGridEX_DesignTimeLayout, "atriumDB_WritHistoryDataTableGridEX_DesignTimeLayout");
            this.atriumDB_WritHistoryDataTableGridEX.DesignTimeLayout = atriumDB_WritHistoryDataTableGridEX_DesignTimeLayout;
            this.errorProviderCost.SetError(this.atriumDB_WritHistoryDataTableGridEX, resources.GetString("atriumDB_WritHistoryDataTableGridEX.Error"));
            this.errorProvider1.SetError(this.atriumDB_WritHistoryDataTableGridEX, resources.GetString("atriumDB_WritHistoryDataTableGridEX.Error1"));
            this.errorProviderJudgmentAccount.SetError(this.atriumDB_WritHistoryDataTableGridEX, resources.GetString("atriumDB_WritHistoryDataTableGridEX.Error2"));
            this.errorProviderWrit.SetError(this.atriumDB_WritHistoryDataTableGridEX, resources.GetString("atriumDB_WritHistoryDataTableGridEX.Error3"));
            this.atriumDB_WritHistoryDataTableGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.atriumDB_WritHistoryDataTableGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.atriumDB_WritHistoryDataTableGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.atriumDB_WritHistoryDataTableGridEX.GroupByBoxVisible = false;
            this.atriumDB_WritHistoryDataTableGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.helpProvider1.SetHelpKeyword(this.atriumDB_WritHistoryDataTableGridEX, resources.GetString("atriumDB_WritHistoryDataTableGridEX.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.atriumDB_WritHistoryDataTableGridEX, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.atriumDB_WritHistoryDataTableGridEX, resources.GetString("atriumDB_WritHistoryDataTableGridEX.HelpString"));
            this.atriumDB_WritHistoryDataTableGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.errorProviderJudgmentAccount.SetIconAlignment(this.atriumDB_WritHistoryDataTableGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.atriumDB_WritHistoryDataTableGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.atriumDB_WritHistoryDataTableGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.atriumDB_WritHistoryDataTableGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.atriumDB_WritHistoryDataTableGridEX, ((int)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.atriumDB_WritHistoryDataTableGridEX, ((int)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.atriumDB_WritHistoryDataTableGridEX, ((int)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.atriumDB_WritHistoryDataTableGridEX, ((int)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.IconPadding3"))));
            this.atriumDB_WritHistoryDataTableGridEX.Indent = 20;
            this.atriumDB_WritHistoryDataTableGridEX.Name = "atriumDB_WritHistoryDataTableGridEX";
            this.atriumDB_WritHistoryDataTableGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.helpProvider1.SetShowHelp(this.atriumDB_WritHistoryDataTableGridEX, ((bool)(resources.GetObject("atriumDB_WritHistoryDataTableGridEX.ShowHelp"))));
            this.atriumDB_WritHistoryDataTableGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.toolTip1.SetToolTip(this.atriumDB_WritHistoryDataTableGridEX, resources.GetString("atriumDB_WritHistoryDataTableGridEX.ToolTip"));
            this.atriumDB_WritHistoryDataTableGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.atriumDB_WritHistoryDataTableGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // atriumDB_WritHistoryDataTableBindingSource
            // 
            this.atriumDB_WritHistoryDataTableBindingSource.DataMember = "WritWritHistory";
            this.atriumDB_WritHistoryDataTableBindingSource.DataSource = this.atriumDB_WritDataTableBindingSource;
            this.atriumDB_WritHistoryDataTableBindingSource.CurrentChanged += new System.EventHandler(this.writHistoryBindingSource_CurrentChanged);
            // 
            // writGridEX
            // 
            resources.ApplyResources(this.writGridEX, "writGridEX");
            this.writGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.writGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.writGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.writGridEX.DataSource = this.atriumDB_WritDataTableBindingSource;
            writGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("writGridEX_DesignTimeLayout_Reference_0.Instance")));
            writGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            writGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(writGridEX_DesignTimeLayout, "writGridEX_DesignTimeLayout");
            this.writGridEX.DesignTimeLayout = writGridEX_DesignTimeLayout;
            this.errorProviderCost.SetError(this.writGridEX, resources.GetString("writGridEX.Error"));
            this.errorProvider1.SetError(this.writGridEX, resources.GetString("writGridEX.Error1"));
            this.errorProviderJudgmentAccount.SetError(this.writGridEX, resources.GetString("writGridEX.Error2"));
            this.errorProviderWrit.SetError(this.writGridEX, resources.GetString("writGridEX.Error3"));
            this.writGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.writGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.writGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.writGridEX.GroupByBoxVisible = false;
            this.writGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.helpProvider1.SetHelpKeyword(this.writGridEX, resources.GetString("writGridEX.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.writGridEX, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("writGridEX.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.writGridEX, resources.GetString("writGridEX.HelpString"));
            this.writGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.writGridEX.Hierarchical = true;
            this.errorProviderJudgmentAccount.SetIconAlignment(this.writGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("writGridEX.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.writGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("writGridEX.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.writGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("writGridEX.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.writGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("writGridEX.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.writGridEX, ((int)(resources.GetObject("writGridEX.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.writGridEX, ((int)(resources.GetObject("writGridEX.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.writGridEX, ((int)(resources.GetObject("writGridEX.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.writGridEX, ((int)(resources.GetObject("writGridEX.IconPadding3"))));
            this.writGridEX.Indent = 20;
            this.writGridEX.Name = "writGridEX";
            this.writGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.helpProvider1.SetShowHelp(this.writGridEX, ((bool)(resources.GetObject("writGridEX.ShowHelp"))));
            this.writGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.toolTip1.SetToolTip(this.writGridEX, resources.GetString("writGridEX.ToolTip"));
            this.writGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.writGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.writGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.writGridEX_ColumnButtonClick);
            this.writGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.writGridEX_CurrentCellChanging);
            // 
            // uiTabPage3
            // 
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Controls.Add(this.uiGroupBox5);
            this.uiTabPage3.Controls.Add(this.costGridEX);
            this.errorProviderCost.SetError(this.uiTabPage3, resources.GetString("uiTabPage3.Error"));
            this.errorProvider1.SetError(this.uiTabPage3, resources.GetString("uiTabPage3.Error1"));
            this.errorProviderWrit.SetError(this.uiTabPage3, resources.GetString("uiTabPage3.Error2"));
            this.errorProviderJudgmentAccount.SetError(this.uiTabPage3, resources.GetString("uiTabPage3.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiTabPage3, resources.GetString("uiTabPage3.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiTabPage3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiTabPage3.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiTabPage3, resources.GetString("uiTabPage3.HelpString"));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiTabPage3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage3.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.uiTabPage3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage3.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.uiTabPage3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage3.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiTabPage3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiTabPage3.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiTabPage3, ((int)(resources.GetObject("uiTabPage3.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiTabPage3, ((int)(resources.GetObject("uiTabPage3.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.uiTabPage3, ((int)(resources.GetObject("uiTabPage3.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.uiTabPage3, ((int)(resources.GetObject("uiTabPage3.IconPadding3"))));
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            this.toolTip1.SetToolTip(this.uiTabPage3, resources.GetString("uiTabPage3.ToolTip"));
            // 
            // uiGroupBox5
            // 
            resources.ApplyResources(this.uiGroupBox5, "uiGroupBox5");
            this.uiGroupBox5.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox5.Controls.Add(label4);
            this.uiGroupBox5.Controls.Add(this.interestRateNumericEditBox);
            this.uiGroupBox5.Controls.Add(rateTypeLabel);
            this.uiGroupBox5.Controls.Add(this.rateTypeucMultiDropDown);
            this.uiGroupBox5.Controls.Add(costAmountLabel1);
            this.uiGroupBox5.Controls.Add(this.costAmountNumericEditBox);
            this.uiGroupBox5.Controls.Add(this.postJudgmentActivityCodeucMultiDropDown);
            this.uiGroupBox5.Controls.Add(costDateLabel);
            this.uiGroupBox5.Controls.Add(this.costDateCalendarCombo);
            this.uiGroupBox5.Controls.Add(postJudgmentActivityCodeLabel);
            this.uiGroupBox5.Controls.Add(interestRateLabel);
            this.errorProviderWrit.SetError(this.uiGroupBox5, resources.GetString("uiGroupBox5.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiGroupBox5, resources.GetString("uiGroupBox5.Error1"));
            this.errorProviderCost.SetError(this.uiGroupBox5, resources.GetString("uiGroupBox5.Error2"));
            this.errorProvider1.SetError(this.uiGroupBox5, resources.GetString("uiGroupBox5.Error3"));
            this.uiGroupBox5.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.helpProvider1.SetHelpKeyword(this.uiGroupBox5, resources.GetString("uiGroupBox5.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiGroupBox5, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiGroupBox5.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiGroupBox5, resources.GetString("uiGroupBox5.HelpString"));
            this.errorProvider1.SetIconAlignment(this.uiGroupBox5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox5.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiGroupBox5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox5.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.uiGroupBox5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox5.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.uiGroupBox5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiGroupBox5.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.uiGroupBox5, ((int)(resources.GetObject("uiGroupBox5.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.uiGroupBox5, ((int)(resources.GetObject("uiGroupBox5.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiGroupBox5, ((int)(resources.GetObject("uiGroupBox5.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.uiGroupBox5, ((int)(resources.GetObject("uiGroupBox5.IconPadding3"))));
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.helpProvider1.SetShowHelp(this.uiGroupBox5, ((bool)(resources.GetObject("uiGroupBox5.ShowHelp"))));
            this.toolTip1.SetToolTip(this.uiGroupBox5, resources.GetString("uiGroupBox5.ToolTip"));
            this.uiGroupBox5.UseThemes = false;
            // 
            // interestRateNumericEditBox
            // 
            resources.ApplyResources(this.interestRateNumericEditBox, "interestRateNumericEditBox");
            this.interestRateNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_CostDataTableBindingSource, "InterestRate", true));
            this.interestRateNumericEditBox.DecimalDigits = 3;
            this.errorProviderJudgmentAccount.SetError(this.interestRateNumericEditBox, resources.GetString("interestRateNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.interestRateNumericEditBox, resources.GetString("interestRateNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.interestRateNumericEditBox, resources.GetString("interestRateNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.interestRateNumericEditBox, resources.GetString("interestRateNumericEditBox.Error3"));
            this.helpProvider1.SetHelpKeyword(this.interestRateNumericEditBox, resources.GetString("interestRateNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.interestRateNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("interestRateNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.interestRateNumericEditBox, resources.GetString("interestRateNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.interestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.interestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.interestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.interestRateNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("interestRateNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.interestRateNumericEditBox, ((int)(resources.GetObject("interestRateNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.interestRateNumericEditBox, ((int)(resources.GetObject("interestRateNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.interestRateNumericEditBox, ((int)(resources.GetObject("interestRateNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.interestRateNumericEditBox, ((int)(resources.GetObject("interestRateNumericEditBox.IconPadding3"))));
            this.interestRateNumericEditBox.Name = "interestRateNumericEditBox";
            this.helpProvider1.SetShowHelp(this.interestRateNumericEditBox, ((bool)(resources.GetObject("interestRateNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.interestRateNumericEditBox, resources.GetString("interestRateNumericEditBox.ToolTip"));
            this.interestRateNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.interestRateNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // atriumDB_CostDataTableBindingSource
            // 
            this.atriumDB_CostDataTableBindingSource.DataMember = "Judgment_Cost";
            this.atriumDB_CostDataTableBindingSource.DataSource = this.atriumDB_JudgmentDataTableBindingSource;
            this.atriumDB_CostDataTableBindingSource.CurrentChanged += new System.EventHandler(this.costBindingSource_CurrentChanged);
            // 
            // rateTypeucMultiDropDown
            // 
            resources.ApplyResources(this.rateTypeucMultiDropDown, "rateTypeucMultiDropDown");
            this.rateTypeucMultiDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.rateTypeucMultiDropDown.Column1 = "InterestRateCode";
            this.rateTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.rateTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_CostDataTableBindingSource, "RateType", true));
            this.rateTypeucMultiDropDown.DataSource = null;
            this.rateTypeucMultiDropDown.DDColumn1Visible = true;
            this.rateTypeucMultiDropDown.DropDownColumn1Width = 50;
            this.rateTypeucMultiDropDown.DropDownColumn2Width = 250;
            this.errorProviderCost.SetError(this.rateTypeucMultiDropDown, resources.GetString("rateTypeucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.rateTypeucMultiDropDown, resources.GetString("rateTypeucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.rateTypeucMultiDropDown, resources.GetString("rateTypeucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.rateTypeucMultiDropDown, resources.GetString("rateTypeucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.rateTypeucMultiDropDown, resources.GetString("rateTypeucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.rateTypeucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("rateTypeucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.rateTypeucMultiDropDown, resources.GetString("rateTypeucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.rateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.rateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.rateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.rateTypeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("rateTypeucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.rateTypeucMultiDropDown, ((int)(resources.GetObject("rateTypeucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.rateTypeucMultiDropDown, ((int)(resources.GetObject("rateTypeucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.rateTypeucMultiDropDown, ((int)(resources.GetObject("rateTypeucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.rateTypeucMultiDropDown, ((int)(resources.GetObject("rateTypeucMultiDropDown.IconPadding3"))));
            this.rateTypeucMultiDropDown.Name = "rateTypeucMultiDropDown";
            this.rateTypeucMultiDropDown.ReadOnly = false;
            this.rateTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.rateTypeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.rateTypeucMultiDropDown, ((bool)(resources.GetObject("rateTypeucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.rateTypeucMultiDropDown, resources.GetString("rateTypeucMultiDropDown.ToolTip"));
            this.rateTypeucMultiDropDown.ValueMember = "InterestRateCode";
            // 
            // costAmountNumericEditBox
            // 
            resources.ApplyResources(this.costAmountNumericEditBox, "costAmountNumericEditBox");
            this.costAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_CostDataTableBindingSource, "CostAmount", true));
            this.costAmountNumericEditBox.DecimalDigits = 2;
            this.costAmountNumericEditBox.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
            this.errorProviderJudgmentAccount.SetError(this.costAmountNumericEditBox, resources.GetString("costAmountNumericEditBox.Error"));
            this.errorProviderCost.SetError(this.costAmountNumericEditBox, resources.GetString("costAmountNumericEditBox.Error1"));
            this.errorProvider1.SetError(this.costAmountNumericEditBox, resources.GetString("costAmountNumericEditBox.Error2"));
            this.errorProviderWrit.SetError(this.costAmountNumericEditBox, resources.GetString("costAmountNumericEditBox.Error3"));
            this.costAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            this.helpProvider1.SetHelpKeyword(this.costAmountNumericEditBox, resources.GetString("costAmountNumericEditBox.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.costAmountNumericEditBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("costAmountNumericEditBox.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.costAmountNumericEditBox, resources.GetString("costAmountNumericEditBox.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.costAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.costAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.costAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.costAmountNumericEditBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costAmountNumericEditBox.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.costAmountNumericEditBox, ((int)(resources.GetObject("costAmountNumericEditBox.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.costAmountNumericEditBox, ((int)(resources.GetObject("costAmountNumericEditBox.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.costAmountNumericEditBox, ((int)(resources.GetObject("costAmountNumericEditBox.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.costAmountNumericEditBox, ((int)(resources.GetObject("costAmountNumericEditBox.IconPadding3"))));
            this.costAmountNumericEditBox.Name = "costAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.costAmountNumericEditBox, ((bool)(resources.GetObject("costAmountNumericEditBox.ShowHelp"))));
            this.toolTip1.SetToolTip(this.costAmountNumericEditBox, resources.GetString("costAmountNumericEditBox.ToolTip"));
            this.costAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.costAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // postJudgmentActivityCodeucMultiDropDown
            // 
            resources.ApplyResources(this.postJudgmentActivityCodeucMultiDropDown, "postJudgmentActivityCodeucMultiDropDown");
            this.postJudgmentActivityCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.postJudgmentActivityCodeucMultiDropDown.Column1 = "PostJudgmentActivityCode";
            this.postJudgmentActivityCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.postJudgmentActivityCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.atriumDB_CostDataTableBindingSource, "PostJudgmentActivityCode", true));
            this.postJudgmentActivityCodeucMultiDropDown.DataSource = null;
            this.postJudgmentActivityCodeucMultiDropDown.DDColumn1Visible = true;
            this.postJudgmentActivityCodeucMultiDropDown.DropDownColumn1Width = 50;
            this.postJudgmentActivityCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.errorProviderCost.SetError(this.postJudgmentActivityCodeucMultiDropDown, resources.GetString("postJudgmentActivityCodeucMultiDropDown.Error"));
            this.errorProviderJudgmentAccount.SetError(this.postJudgmentActivityCodeucMultiDropDown, resources.GetString("postJudgmentActivityCodeucMultiDropDown.Error1"));
            this.errorProvider1.SetError(this.postJudgmentActivityCodeucMultiDropDown, resources.GetString("postJudgmentActivityCodeucMultiDropDown.Error2"));
            this.errorProviderWrit.SetError(this.postJudgmentActivityCodeucMultiDropDown, resources.GetString("postJudgmentActivityCodeucMultiDropDown.Error3"));
            this.helpProvider1.SetHelpKeyword(this.postJudgmentActivityCodeucMultiDropDown, resources.GetString("postJudgmentActivityCodeucMultiDropDown.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.postJudgmentActivityCodeucMultiDropDown, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.postJudgmentActivityCodeucMultiDropDown, resources.GetString("postJudgmentActivityCodeucMultiDropDown.HelpString"));
            this.errorProvider1.SetIconAlignment(this.postJudgmentActivityCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconAlignment"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.postJudgmentActivityCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconAlignment1"))));
            this.errorProviderWrit.SetIconAlignment(this.postJudgmentActivityCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.postJudgmentActivityCodeucMultiDropDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.postJudgmentActivityCodeucMultiDropDown, ((int)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconPadding"))));
            this.errorProviderCost.SetIconPadding(this.postJudgmentActivityCodeucMultiDropDown, ((int)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.postJudgmentActivityCodeucMultiDropDown, ((int)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconPadding2"))));
            this.errorProvider1.SetIconPadding(this.postJudgmentActivityCodeucMultiDropDown, ((int)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.IconPadding3"))));
            this.postJudgmentActivityCodeucMultiDropDown.Name = "postJudgmentActivityCodeucMultiDropDown";
            this.postJudgmentActivityCodeucMultiDropDown.ReadOnly = false;
            this.postJudgmentActivityCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.postJudgmentActivityCodeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.postJudgmentActivityCodeucMultiDropDown, ((bool)(resources.GetObject("postJudgmentActivityCodeucMultiDropDown.ShowHelp"))));
            this.toolTip1.SetToolTip(this.postJudgmentActivityCodeucMultiDropDown, resources.GetString("postJudgmentActivityCodeucMultiDropDown.ToolTip"));
            this.postJudgmentActivityCodeucMultiDropDown.ValueMember = "PostJudgmentActivityCode";
            // 
            // costDateCalendarCombo
            // 
            resources.ApplyResources(this.costDateCalendarCombo, "costDateCalendarCombo");
            this.costDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CostDataTableBindingSource, "CostDate", true));
            this.costDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.costDateCalendarCombo.DropDownCalendar.AccessibleDescription = resources.GetString("costDateCalendarCombo.DropDownCalendar.AccessibleDescription");
            this.costDateCalendarCombo.DropDownCalendar.AccessibleName = resources.GetString("costDateCalendarCombo.DropDownCalendar.AccessibleName");
            this.costDateCalendarCombo.DropDownCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.Anchor")));
            this.costDateCalendarCombo.DropDownCalendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.BackgroundImage")));
            this.costDateCalendarCombo.DropDownCalendar.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.BackgroundImageLayout")));
            this.costDateCalendarCombo.DropDownCalendar.DayOfWeekAbbreviation = ((Janus.Windows.CalendarCombo.DayOfWeekAbbreviation)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.DayOfWeekAbbreviation")));
            this.costDateCalendarCombo.DropDownCalendar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.Dock")));
            this.costDateCalendarCombo.DropDownCalendar.FirstDayOfWeek = ((Janus.Windows.CalendarCombo.CalendarDayOfWeek)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.FirstDayOfWeek")));
            this.costDateCalendarCombo.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.Font")));
            this.costDateCalendarCombo.DropDownCalendar.HeaderFormat = resources.GetString("costDateCalendarCombo.DropDownCalendar.HeaderFormat");
            this.costDateCalendarCombo.DropDownCalendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.ImeMode")));
            this.costDateCalendarCombo.DropDownCalendar.MaximumSize = ((System.Drawing.Size)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.MaximumSize")));
            this.costDateCalendarCombo.DropDownCalendar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.RightToLeft")));
            this.costDateCalendarCombo.DropDownCalendar.Visible = ((bool)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.Visible")));
            this.costDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.costDateCalendarCombo.DropDownCalendar.WeekNumbers = ((bool)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.WeekNumbers")));
            this.costDateCalendarCombo.DropDownCalendar.WeekRule = ((System.Globalization.CalendarWeekRule)(resources.GetObject("costDateCalendarCombo.DropDownCalendar.WeekRule")));
            this.errorProviderCost.SetError(this.costDateCalendarCombo, resources.GetString("costDateCalendarCombo.Error"));
            this.errorProviderJudgmentAccount.SetError(this.costDateCalendarCombo, resources.GetString("costDateCalendarCombo.Error1"));
            this.errorProvider1.SetError(this.costDateCalendarCombo, resources.GetString("costDateCalendarCombo.Error2"));
            this.errorProviderWrit.SetError(this.costDateCalendarCombo, resources.GetString("costDateCalendarCombo.Error3"));
            this.helpProvider1.SetHelpKeyword(this.costDateCalendarCombo, resources.GetString("costDateCalendarCombo.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.costDateCalendarCombo, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("costDateCalendarCombo.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.costDateCalendarCombo, resources.GetString("costDateCalendarCombo.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.costDateCalendarCombo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateCalendarCombo.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.costDateCalendarCombo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateCalendarCombo.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.costDateCalendarCombo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateCalendarCombo.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.costDateCalendarCombo, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costDateCalendarCombo.IconAlignment3"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.costDateCalendarCombo, ((int)(resources.GetObject("costDateCalendarCombo.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.costDateCalendarCombo, ((int)(resources.GetObject("costDateCalendarCombo.IconPadding1"))));
            this.errorProviderWrit.SetIconPadding(this.costDateCalendarCombo, ((int)(resources.GetObject("costDateCalendarCombo.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.costDateCalendarCombo, ((int)(resources.GetObject("costDateCalendarCombo.IconPadding3"))));
            this.costDateCalendarCombo.MonthIncrement = 0;
            this.costDateCalendarCombo.Name = "costDateCalendarCombo";
            this.costDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.costDateCalendarCombo, ((bool)(resources.GetObject("costDateCalendarCombo.ShowHelp"))));
            this.toolTip1.SetToolTip(this.costDateCalendarCombo, resources.GetString("costDateCalendarCombo.ToolTip"));
            this.costDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.costDateCalendarCombo.YearIncrement = 0;
            // 
            // costGridEX
            // 
            resources.ApplyResources(this.costGridEX, "costGridEX");
            this.costGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.costGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.costGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.costGridEX.DataSource = this.atriumDB_CostDataTableBindingSource;
            costGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("costGridEX_DesignTimeLayout_Reference_0.Instance")));
            costGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            costGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(costGridEX_DesignTimeLayout, "costGridEX_DesignTimeLayout");
            this.costGridEX.DesignTimeLayout = costGridEX_DesignTimeLayout;
            this.errorProviderCost.SetError(this.costGridEX, resources.GetString("costGridEX.Error"));
            this.errorProvider1.SetError(this.costGridEX, resources.GetString("costGridEX.Error1"));
            this.errorProviderJudgmentAccount.SetError(this.costGridEX, resources.GetString("costGridEX.Error2"));
            this.errorProviderWrit.SetError(this.costGridEX, resources.GetString("costGridEX.Error3"));
            this.costGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.costGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.costGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.costGridEX.GroupByBoxVisible = false;
            this.costGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.helpProvider1.SetHelpKeyword(this.costGridEX, resources.GetString("costGridEX.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.costGridEX, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("costGridEX.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.costGridEX, resources.GetString("costGridEX.HelpString"));
            this.costGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.errorProviderJudgmentAccount.SetIconAlignment(this.costGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costGridEX.IconAlignment"))));
            this.errorProviderWrit.SetIconAlignment(this.costGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costGridEX.IconAlignment1"))));
            this.errorProvider1.SetIconAlignment(this.costGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costGridEX.IconAlignment2"))));
            this.errorProviderCost.SetIconAlignment(this.costGridEX, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("costGridEX.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.costGridEX, ((int)(resources.GetObject("costGridEX.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.costGridEX, ((int)(resources.GetObject("costGridEX.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.costGridEX, ((int)(resources.GetObject("costGridEX.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.costGridEX, ((int)(resources.GetObject("costGridEX.IconPadding3"))));
            this.costGridEX.Name = "costGridEX";
            this.helpProvider1.SetShowHelp(this.costGridEX, ((bool)(resources.GetObject("costGridEX.ShowHelp"))));
            this.costGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.toolTip1.SetToolTip(this.costGridEX, resources.GetString("costGridEX.ToolTip"));
            this.costGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.costGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.costGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.costGridEX_ColumnButtonClick);
            this.costGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.costGridEX_CurrentCellChanging);
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
            this.cmdEdit});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.ImageList = ((System.Windows.Forms.ImageList)(resources.GetObject("uiCommandManager1.EditContextMenu.ImageList")));
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.EditContextMenu.LargeImageList = ((System.Windows.Forms.ImageList)(resources.GetObject("uiCommandManager1.EditContextMenu.LargeImageList")));
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
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.errorProviderCost.SetError(this.BottomRebar1, resources.GetString("BottomRebar1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.BottomRebar1, resources.GetString("BottomRebar1.Error1"));
            this.errorProviderWrit.SetError(this.BottomRebar1, resources.GetString("BottomRebar1.Error2"));
            this.errorProvider1.SetError(this.BottomRebar1, resources.GetString("BottomRebar1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.BottomRebar1, resources.GetString("BottomRebar1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.BottomRebar1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("BottomRebar1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.BottomRebar1, resources.GetString("BottomRebar1.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.BottomRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("BottomRebar1.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.BottomRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("BottomRebar1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.BottomRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("BottomRebar1.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.BottomRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("BottomRebar1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.BottomRebar1, ((int)(resources.GetObject("BottomRebar1.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.BottomRebar1, ((int)(resources.GetObject("BottomRebar1.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.BottomRebar1, ((int)(resources.GetObject("BottomRebar1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.BottomRebar1, ((int)(resources.GetObject("BottomRebar1.IconPadding3"))));
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.BottomRebar1, resources.GetString("BottomRebar1.ToolTip"));
            // 
            // uiCommandBar2
            // 
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            this.errorProviderWrit.SetError(this.uiCommandBar2, resources.GetString("uiCommandBar2.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiCommandBar2, resources.GetString("uiCommandBar2.Error1"));
            this.errorProvider1.SetError(this.uiCommandBar2, resources.GetString("uiCommandBar2.Error2"));
            this.errorProviderCost.SetError(this.uiCommandBar2, resources.GetString("uiCommandBar2.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiCommandBar2, resources.GetString("uiCommandBar2.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiCommandBar2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiCommandBar2.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiCommandBar2, resources.GetString("uiCommandBar2.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.uiCommandBar2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar2.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.uiCommandBar2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar2.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiCommandBar2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar2.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.uiCommandBar2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar2.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(this.uiCommandBar2, ((int)(resources.GetObject("uiCommandBar2.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.uiCommandBar2, ((int)(resources.GetObject("uiCommandBar2.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiCommandBar2, ((int)(resources.GetObject("uiCommandBar2.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(this.uiCommandBar2, ((int)(resources.GetObject("uiCommandBar2.IconPadding3"))));
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.MergeRowOrder = 1;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            this.toolTip1.SetToolTip(this.uiCommandBar2, resources.GetString("uiCommandBar2.ToolTip"));
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
            // uiCommandBar3
            // 
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
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
            this.errorProviderWrit.SetError(this.uiCommandBar3, resources.GetString("uiCommandBar3.Error"));
            this.errorProviderJudgmentAccount.SetError(this.uiCommandBar3, resources.GetString("uiCommandBar3.Error1"));
            this.errorProvider1.SetError(this.uiCommandBar3, resources.GetString("uiCommandBar3.Error2"));
            this.errorProviderCost.SetError(this.uiCommandBar3, resources.GetString("uiCommandBar3.Error3"));
            this.helpProvider1.SetHelpKeyword(this.uiCommandBar3, resources.GetString("uiCommandBar3.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.uiCommandBar3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("uiCommandBar3.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.uiCommandBar3, resources.GetString("uiCommandBar3.HelpString"));
            this.errorProviderCost.SetIconAlignment(this.uiCommandBar3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar3.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this.uiCommandBar3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar3.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.uiCommandBar3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar3.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this.uiCommandBar3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("uiCommandBar3.IconAlignment3"))));
            this.errorProviderCost.SetIconPadding(this.uiCommandBar3, ((int)(resources.GetObject("uiCommandBar3.IconPadding"))));
            this.errorProvider1.SetIconPadding(this.uiCommandBar3, ((int)(resources.GetObject("uiCommandBar3.IconPadding1"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.uiCommandBar3, ((int)(resources.GetObject("uiCommandBar3.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(this.uiCommandBar3, ((int)(resources.GetObject("uiCommandBar3.IconPadding3"))));
            this.uiCommandBar3.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar3.MergeRowOrder = 2;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.uiCommandBar3.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            this.toolTip1.SetToolTip(this.uiCommandBar3, resources.GetString("uiCommandBar3.ToolTip"));
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
            // LeftRebar1
            // 
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.errorProviderCost.SetError(this.LeftRebar1, resources.GetString("LeftRebar1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.LeftRebar1, resources.GetString("LeftRebar1.Error1"));
            this.errorProviderWrit.SetError(this.LeftRebar1, resources.GetString("LeftRebar1.Error2"));
            this.errorProvider1.SetError(this.LeftRebar1, resources.GetString("LeftRebar1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.LeftRebar1, resources.GetString("LeftRebar1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.LeftRebar1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("LeftRebar1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.LeftRebar1, resources.GetString("LeftRebar1.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.LeftRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("LeftRebar1.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.LeftRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("LeftRebar1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.LeftRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("LeftRebar1.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.LeftRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("LeftRebar1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.LeftRebar1, ((int)(resources.GetObject("LeftRebar1.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.LeftRebar1, ((int)(resources.GetObject("LeftRebar1.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.LeftRebar1, ((int)(resources.GetObject("LeftRebar1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.LeftRebar1, ((int)(resources.GetObject("LeftRebar1.IconPadding3"))));
            this.LeftRebar1.Name = "LeftRebar1";
            this.helpProvider1.SetShowHelp(this.LeftRebar1, ((bool)(resources.GetObject("LeftRebar1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.LeftRebar1, resources.GetString("LeftRebar1.ToolTip"));
            // 
            // RightRebar1
            // 
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.errorProviderCost.SetError(this.RightRebar1, resources.GetString("RightRebar1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.RightRebar1, resources.GetString("RightRebar1.Error1"));
            this.errorProviderWrit.SetError(this.RightRebar1, resources.GetString("RightRebar1.Error2"));
            this.errorProvider1.SetError(this.RightRebar1, resources.GetString("RightRebar1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.RightRebar1, resources.GetString("RightRebar1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.RightRebar1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("RightRebar1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.RightRebar1, resources.GetString("RightRebar1.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.RightRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("RightRebar1.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.RightRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("RightRebar1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.RightRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("RightRebar1.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.RightRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("RightRebar1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.RightRebar1, ((int)(resources.GetObject("RightRebar1.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.RightRebar1, ((int)(resources.GetObject("RightRebar1.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.RightRebar1, ((int)(resources.GetObject("RightRebar1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.RightRebar1, ((int)(resources.GetObject("RightRebar1.IconPadding3"))));
            this.RightRebar1.Name = "RightRebar1";
            this.helpProvider1.SetShowHelp(this.RightRebar1, ((bool)(resources.GetObject("RightRebar1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.RightRebar1, resources.GetString("RightRebar1.ToolTip"));
            // 
            // TopRebar1
            // 
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar3});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Controls.Add(this.uiCommandBar3);
            this.errorProviderCost.SetError(this.TopRebar1, resources.GetString("TopRebar1.Error"));
            this.errorProviderJudgmentAccount.SetError(this.TopRebar1, resources.GetString("TopRebar1.Error1"));
            this.errorProviderWrit.SetError(this.TopRebar1, resources.GetString("TopRebar1.Error2"));
            this.errorProvider1.SetError(this.TopRebar1, resources.GetString("TopRebar1.Error3"));
            this.helpProvider1.SetHelpKeyword(this.TopRebar1, resources.GetString("TopRebar1.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this.TopRebar1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("TopRebar1.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this.TopRebar1, resources.GetString("TopRebar1.HelpString"));
            this.errorProviderWrit.SetIconAlignment(this.TopRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("TopRebar1.IconAlignment"))));
            this.errorProviderCost.SetIconAlignment(this.TopRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("TopRebar1.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this.TopRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("TopRebar1.IconAlignment2"))));
            this.errorProvider1.SetIconAlignment(this.TopRebar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("TopRebar1.IconAlignment3"))));
            this.errorProviderWrit.SetIconPadding(this.TopRebar1, ((int)(resources.GetObject("TopRebar1.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this.TopRebar1, ((int)(resources.GetObject("TopRebar1.IconPadding1"))));
            this.errorProvider1.SetIconPadding(this.TopRebar1, ((int)(resources.GetObject("TopRebar1.IconPadding2"))));
            this.errorProviderCost.SetIconPadding(this.TopRebar1, ((int)(resources.GetObject("TopRebar1.IconPadding3"))));
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            this.toolTip1.SetToolTip(this.TopRebar1, resources.GetString("TopRebar1.ToolTip"));
            // 
            // errorProviderJudgmentAccount
            // 
            this.errorProviderJudgmentAccount.ContainerControl = this;
            this.errorProviderJudgmentAccount.DataSource = this.atriumDB_JudgmentAccountDataTableBindingSource;
            resources.ApplyResources(this.errorProviderJudgmentAccount, "errorProviderJudgmentAccount");
            // 
            // errorProviderWrit
            // 
            this.errorProviderWrit.ContainerControl = this;
            this.errorProviderWrit.DataSource = this.atriumDB_WritDataTableBindingSource;
            resources.ApplyResources(this.errorProviderWrit, "errorProviderWrit");
            // 
            // errorProviderCost
            // 
            this.errorProviderCost.ContainerControl = this;
            this.errorProviderCost.DataSource = this.atriumDB_CostDataTableBindingSource;
            resources.ApplyResources(this.errorProviderCost, "errorProviderCost");
            // 
            // ucJudgment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.errorProviderJudgmentAccount.SetError(this, resources.GetString("$this.Error"));
            this.errorProvider1.SetError(this, resources.GetString("$this.Error1"));
            this.errorProviderCost.SetError(this, resources.GetString("$this.Error2"));
            this.errorProviderWrit.SetError(this, resources.GetString("$this.Error3"));
            this.helpProvider1.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
            this.helpProvider1.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.helpProvider1.SetHelpString(this, resources.GetString("$this.HelpString"));
            this.errorProviderCost.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.errorProvider1.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment1"))));
            this.errorProviderJudgmentAccount.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment2"))));
            this.errorProviderWrit.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment3"))));
            this.errorProvider1.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding"))));
            this.errorProviderJudgmentAccount.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding1"))));
            this.errorProviderCost.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding2"))));
            this.errorProviderWrit.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding3"))));
            this.Name = "ucJudgment";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.ucJudgment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage5.ResumeLayout(false);
            this.uiTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_JudgmentDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage4.ResumeLayout(false);
            this.uiTabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountIncludedGridEx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_JudgmentAccountDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).EndInit();
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.judgmentAccountGridEX)).EndInit();
            this.uiTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_WritDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_WritHistoryDataTableGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_WritHistoryDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writGridEX)).EndInit();
            this.uiTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox5)).EndInit();
            this.uiGroupBox5.ResumeLayout(false);
            this.uiGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CostDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderJudgmentAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWrit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.GridEX.GridEX AccountIncludedGridEx;
        private Janus.Windows.GridEX.GridEX judgmentAccountGridEX;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox3;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox4;
        private Janus.Windows.GridEX.GridEX writGridEX;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox5;
        private Janus.Windows.GridEX.GridEX costGridEX;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private System.Windows.Forms.ErrorProvider errorProviderJudgmentAccount;
        private System.Windows.Forms.ErrorProvider errorProviderWrit;
        private System.Windows.Forms.ErrorProvider errorProviderCost;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private UserControls.ucMultiDropDown ucAccountTypeMcc;
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
        private Janus.Windows.GridEX.EditControls.NumericEditBox interestRateNumericEditBox;
        private System.Windows.Forms.BindingSource atriumDB_CostDataTableBindingSource;
        private UserControls.ucMultiDropDown rateTypeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.NumericEditBox costAmountNumericEditBox;
        private UserControls.ucMultiDropDown postJudgmentActivityCodeucMultiDropDown;
        private Janus.Windows.CalendarCombo.CalendarCombo costDateCalendarCombo;
        private ucOfficeSelectBox officeIDucOfficeSelectBox;
        private System.Windows.Forms.BindingSource atriumDB_WritDataTableBindingSource;
        private UserControls.ucMultiDropDown typeofWritCodeucMultiDropDown;
        private Janus.Windows.CalendarCombo.CalendarCombo expiryDateCalendarCombo1;
        private Janus.Windows.CalendarCombo.CalendarCombo issueRenewalDateCalendarCombo1;
        private Janus.Windows.GridEX.EditControls.EditBox sheriffJurisdictionEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox executionorRegistrationNumberEditBox;
        private Janus.Windows.GridEX.GridEX atriumDB_WritHistoryDataTableGridEX;
        private System.Windows.Forms.BindingSource atriumDB_WritHistoryDataTableBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo claimAgainstCrownCalendarCombo1;
        private System.Windows.Forms.BindingSource atriumDB_JudgmentDataTableBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo defenceDateCalendarCombo1;
        private Janus.Windows.CalendarCombo.CalendarCombo statementofClaimServedDateCalendarCombo1;
        private Janus.Windows.CalendarCombo.CalendarCombo statementofClaimIssuedDateCalendarCombo1;
        private UserControls.ucMultiDropDown judgmentCourtLevelCodeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.EditBox actionNumberEditBox;
        private UserControls.ucMultiDropDown processTypeCodeucMultiDropDown1;
        private UserControls.ucMultiDropDown judgmentTypeCodeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.NumericEditBox judgmentAmountNumericEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo judgmentLPDateCalendarCombo1;
        private ucOfficeSelectBox officeIDucOfficeSelectBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo judgmentDateCalendarCombo1;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private Janus.Windows.GridEX.EditControls.NumericEditBox judgmentAmountNumericEditBox1;
        private System.Windows.Forms.BindingSource atriumDB_JudgmentAccountDataTableBindingSource;
        private Janus.Windows.GridEX.EditControls.NumericEditBox costAmountNumericEditBox1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox preJudgmentInterestAmountNumericEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo preJudgmentInterestToCalendarCombo1;
        private Janus.Windows.CalendarCombo.CalendarCombo preJudgmentInterestFromCalendarCombo1;
        private UserControls.ucMultiDropDown preJudgmentRateTypeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.NumericEditBox preJudgmentInterestRateNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox principalAmountBeforeJudgmentNumericEditBox;
        private UserControls.ucMultiDropDown postJRateTypeOnCostucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.NumericEditBox postJIntRateOnCostNumericEditBox;
        private UserControls.ucMultiDropDown postJudgmentRateTypeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.NumericEditBox postJudgmentInterestRateNumericEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo accruedFromDateCalendarCombo1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage4;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage5;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
    }
}
