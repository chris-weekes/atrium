using System.Data;
namespace LawMate
{
    partial class ucSRPBillingReview
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
                FM.DB.IRP.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetIRP().OnUpdate -= new atLogic.UpdateEventHandler(ucIRP_OnUpdate);

                if (fmBillingReview != null)
                {
                    fmBillingReview.DB.ActivityTime.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                    fmBillingReview.DB.Disbursement.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                    fmBillingReview.GetActivityTime().OnUpdate -= new atLogic.UpdateEventHandler(ucIRP_OnUpdate);
                    fmBillingReview.GetDisbursement().OnUpdate -= new atLogic.UpdateEventHandler(ucIRP_OnUpdate);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSRPBillingReview));
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label feesClaimedLabel;
            System.Windows.Forms.Label feesClaimedTaxLabel;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label disbursementClaimedLabel;
            System.Windows.Forms.Label disbursementClaimedTaxLabel;
            System.Windows.Forms.Label feesTaxedLabel;
            System.Windows.Forms.Label feesTaxedTaxLabel;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label netTotalClaimedLabel;
            System.Windows.Forms.Label netTotalTaxedLabel;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label label32;
            System.Windows.Forms.Label label33;
            System.Windows.Forms.Label taxingDifferenceLabel;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label38;
            System.Windows.Forms.Label fileIDLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            Janus.Windows.GridEX.GridEXLayout taxingGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference taxingGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference taxingGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference taxingGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference taxingGridEX_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.ValueList.Item0.Image");
            Janus.Windows.GridEX.GridEXLayout disbursementGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference disbursementGridEX_Layout_0_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.HeaderImage");
            Janus.Windows.GridEX.GridEXLayout activityTimeGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityTimeGridEX_Layout_0_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ButtonImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityTimeGridEX_Layout_0_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.HeaderImage");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_0_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_0_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.HeaderImage");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_1_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ButtonImage");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_2 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_2_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ButtonImage");
            this.disbursementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.activityTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlIRP = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlIRPContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnRollbackTaxation = new Janus.Windows.EditControls.UIButton();
            this.btnClearOfficer = new Janus.Windows.EditControls.UIButton();
            this.btnApplyTaxRecs = new Janus.Windows.EditControls.UIButton();
            this.taxingGridEX = new Janus.Windows.GridEX.GridEX();
            this.taxingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbMessage = new Janus.Windows.EditControls.UIGroupBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode3 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitleBillingReview1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitleBillingReview");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSaveBillingReview1 = new Janus.Windows.UI.CommandBars.UICommand("tsSaveBillingReview");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsGoToSRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRP");
            this.tsGoToSRPDetail1 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRPDetail");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsPrevious1 = new Janus.Windows.UI.CommandBars.UICommand("tsPrevious");
            this.tsNext1 = new Janus.Windows.UI.CommandBars.UICommand("tsNext");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAddTaxRec1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddTaxRec");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSaveAndPrevious1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSaveAndPrevious");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSaveAndNext1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSaveAndNext");
            this.tsSaveBillingReview = new Janus.Windows.UI.CommandBars.UICommand("tsSaveBillingReview");
            this.tsGoToSRP = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRP");
            this.tsGoToSRPDetail = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRPDetail");
            this.tsScreenTitleBillingReview = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitleBillingReview");
            this.tsNext2 = new Janus.Windows.UI.CommandBars.UICommand("tsNext");
            this.tsPrevious2 = new Janus.Windows.UI.CommandBars.UICommand("tsPrevious");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsMessage = new Janus.Windows.UI.CommandBars.UICommand("tsMessage");
            this.cmdGoToActivity = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToActivity");
            this.cmdGoToTaxation = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToTaxation");
            this.cmdGoToTaxingRec = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToTaxingRec");
            this.cmdSaveAndNext = new Janus.Windows.UI.CommandBars.UICommand("cmdSaveAndNext");
            this.cmdSaveAndPrevious = new Janus.Windows.UI.CommandBars.UICommand("cmdSaveAndPrevious");
            this.cmdAddTaxRec = new Janus.Windows.UI.CommandBars.UICommand("cmdAddTaxRec");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdGoToActivity1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToActivity");
            this.cmdGoToTaxation1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToTaxation");
            this.cmdGoToTaxingRec1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToTaxingRec");
            this.fileIDucFileSelectBox = new LawMate.ucFileSelectBox();
            this.officeDB_IRPDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taxingDifferenceNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.dateTaxedBillingReview = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.netTotalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.netTotalClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.officeIDucOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.fileTotalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.sINMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.officerIDucContactSelectBox = new LawMate.ucContactSelectBox();
            this.disbursementClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.calendarCombo2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.feesTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.numericEditBox1 = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.btnBeginTaxation = new Janus.Windows.EditControls.UIButton();
            this.pnlActivityDisb = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityDisbContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.disbursementGridEX = new Janus.Windows.GridEX.GridEX();
            this.activityTimeGridEX = new Janus.Windows.GridEX.GridEX();
            this.activityGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlBillingReview = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBillingReviewContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlSRP = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSRPContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            label28 = new System.Windows.Forms.Label();
            feesClaimedLabel = new System.Windows.Forms.Label();
            feesClaimedTaxLabel = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            disbursementClaimedLabel = new System.Windows.Forms.Label();
            disbursementClaimedTaxLabel = new System.Windows.Forms.Label();
            feesTaxedLabel = new System.Windows.Forms.Label();
            feesTaxedTaxLabel = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            netTotalClaimedLabel = new System.Windows.Forms.Label();
            netTotalTaxedLabel = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            taxingDifferenceLabel = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            fileIDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIRP)).BeginInit();
            this.pnlIRP.SuspendLayout();
            this.pnlIRPContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMessage)).BeginInit();
            this.gbMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB_IRPDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityDisb)).BeginInit();
            this.pnlActivityDisb.SuspendLayout();
            this.pnlActivityDisbContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBillingReview)).BeginInit();
            this.pnlBillingReview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRP)).BeginInit();
            this.pnlSRP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.officeDB_IRPDataTableBindingSource;
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
            // 
            // label28
            // 
            resources.ApplyResources(label28, "label28");
            label28.BackColor = System.Drawing.Color.Transparent;
            label28.Name = "label28";
            this.helpProvider1.SetShowHelp(label28, ((bool)(resources.GetObject("label28.ShowHelp"))));
            // 
            // feesClaimedLabel
            // 
            resources.ApplyResources(feesClaimedLabel, "feesClaimedLabel");
            feesClaimedLabel.BackColor = System.Drawing.Color.Transparent;
            feesClaimedLabel.Name = "feesClaimedLabel";
            this.helpProvider1.SetShowHelp(feesClaimedLabel, ((bool)(resources.GetObject("feesClaimedLabel.ShowHelp"))));
            // 
            // feesClaimedTaxLabel
            // 
            resources.ApplyResources(feesClaimedTaxLabel, "feesClaimedTaxLabel");
            feesClaimedTaxLabel.BackColor = System.Drawing.Color.Transparent;
            feesClaimedTaxLabel.Name = "feesClaimedTaxLabel";
            this.helpProvider1.SetShowHelp(feesClaimedTaxLabel, ((bool)(resources.GetObject("feesClaimedTaxLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(feesClaimedTaxLabel, resources.GetString("feesClaimedTaxLabel.ToolTip"));
            // 
            // label29
            // 
            resources.ApplyResources(label29, "label29");
            label29.BackColor = System.Drawing.Color.Transparent;
            label29.Name = "label29";
            this.helpProvider1.SetShowHelp(label29, ((bool)(resources.GetObject("label29.ShowHelp"))));
            this.toolTip1.SetToolTip(label29, resources.GetString("label29.ToolTip"));
            // 
            // disbursementClaimedLabel
            // 
            resources.ApplyResources(disbursementClaimedLabel, "disbursementClaimedLabel");
            disbursementClaimedLabel.BackColor = System.Drawing.Color.Transparent;
            disbursementClaimedLabel.Name = "disbursementClaimedLabel";
            this.helpProvider1.SetShowHelp(disbursementClaimedLabel, ((bool)(resources.GetObject("disbursementClaimedLabel.ShowHelp"))));
            // 
            // disbursementClaimedTaxLabel
            // 
            resources.ApplyResources(disbursementClaimedTaxLabel, "disbursementClaimedTaxLabel");
            disbursementClaimedTaxLabel.BackColor = System.Drawing.Color.Transparent;
            disbursementClaimedTaxLabel.Name = "disbursementClaimedTaxLabel";
            this.helpProvider1.SetShowHelp(disbursementClaimedTaxLabel, ((bool)(resources.GetObject("disbursementClaimedTaxLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(disbursementClaimedTaxLabel, resources.GetString("disbursementClaimedTaxLabel.ToolTip"));
            // 
            // feesTaxedLabel
            // 
            resources.ApplyResources(feesTaxedLabel, "feesTaxedLabel");
            feesTaxedLabel.BackColor = System.Drawing.Color.Transparent;
            feesTaxedLabel.Name = "feesTaxedLabel";
            this.helpProvider1.SetShowHelp(feesTaxedLabel, ((bool)(resources.GetObject("feesTaxedLabel.ShowHelp"))));
            // 
            // feesTaxedTaxLabel
            // 
            resources.ApplyResources(feesTaxedTaxLabel, "feesTaxedTaxLabel");
            feesTaxedTaxLabel.BackColor = System.Drawing.Color.Transparent;
            feesTaxedTaxLabel.Name = "feesTaxedTaxLabel";
            this.helpProvider1.SetShowHelp(feesTaxedTaxLabel, ((bool)(resources.GetObject("feesTaxedTaxLabel.ShowHelp"))));
            // 
            // label30
            // 
            resources.ApplyResources(label30, "label30");
            label30.BackColor = System.Drawing.Color.Transparent;
            label30.Name = "label30";
            this.helpProvider1.SetShowHelp(label30, ((bool)(resources.GetObject("label30.ShowHelp"))));
            // 
            // netTotalClaimedLabel
            // 
            resources.ApplyResources(netTotalClaimedLabel, "netTotalClaimedLabel");
            netTotalClaimedLabel.BackColor = System.Drawing.Color.Transparent;
            netTotalClaimedLabel.Name = "netTotalClaimedLabel";
            this.helpProvider1.SetShowHelp(netTotalClaimedLabel, ((bool)(resources.GetObject("netTotalClaimedLabel.ShowHelp"))));
            // 
            // netTotalTaxedLabel
            // 
            resources.ApplyResources(netTotalTaxedLabel, "netTotalTaxedLabel");
            netTotalTaxedLabel.BackColor = System.Drawing.Color.Transparent;
            netTotalTaxedLabel.Name = "netTotalTaxedLabel";
            this.helpProvider1.SetShowHelp(netTotalTaxedLabel, ((bool)(resources.GetObject("netTotalTaxedLabel.ShowHelp"))));
            // 
            // label31
            // 
            resources.ApplyResources(label31, "label31");
            label31.BackColor = System.Drawing.Color.Transparent;
            label31.Name = "label31";
            this.helpProvider1.SetShowHelp(label31, ((bool)(resources.GetObject("label31.ShowHelp"))));
            this.toolTip1.SetToolTip(label31, resources.GetString("label31.ToolTip"));
            // 
            // label32
            // 
            resources.ApplyResources(label32, "label32");
            label32.BackColor = System.Drawing.Color.Transparent;
            label32.Name = "label32";
            this.helpProvider1.SetShowHelp(label32, ((bool)(resources.GetObject("label32.ShowHelp"))));
            // 
            // label33
            // 
            resources.ApplyResources(label33, "label33");
            label33.BackColor = System.Drawing.Color.Transparent;
            label33.Name = "label33";
            this.helpProvider1.SetShowHelp(label33, ((bool)(resources.GetObject("label33.ShowHelp"))));
            // 
            // taxingDifferenceLabel
            // 
            resources.ApplyResources(taxingDifferenceLabel, "taxingDifferenceLabel");
            taxingDifferenceLabel.BackColor = System.Drawing.Color.Transparent;
            taxingDifferenceLabel.Name = "taxingDifferenceLabel";
            this.helpProvider1.SetShowHelp(taxingDifferenceLabel, ((bool)(resources.GetObject("taxingDifferenceLabel.ShowHelp"))));
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.BackColor = System.Drawing.Color.Transparent;
            label27.Name = "label27";
            this.helpProvider1.SetShowHelp(label27, ((bool)(resources.GetObject("label27.ShowHelp"))));
            // 
            // label38
            // 
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            this.helpProvider1.SetShowHelp(label38, ((bool)(resources.GetObject("label38.ShowHelp"))));
            // 
            // fileIDLabel
            // 
            resources.ApplyResources(fileIDLabel, "fileIDLabel");
            fileIDLabel.BackColor = System.Drawing.Color.Transparent;
            fileIDLabel.Name = "fileIDLabel";
            this.helpProvider1.SetShowHelp(fileIDLabel, ((bool)(resources.GetObject("fileIDLabel.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Image = global::LawMate.Properties.Resources.fees;
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Image = global::LawMate.Properties.Resources.disb;
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            this.helpProvider1.SetShowHelp(label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            this.helpProvider1.SetShowHelp(label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            this.helpProvider1.SetShowHelp(label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // label7
            // 
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Image = global::LawMate.Properties.Resources.act;
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            this.helpProvider1.SetShowHelp(label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // disbursementBindingSource
            // 
            this.disbursementBindingSource.DataMember = "ActivityDisbursement";
            this.disbursementBindingSource.DataSource = this.activityBindingSource;
            // 
            // activityBindingSource
            // 
            this.activityBindingSource.DataMember = "Activity";
            this.activityBindingSource.DataSource = this.atriumDB;
            this.activityBindingSource.CurrentChanged += new System.EventHandler(this.activityBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // activityTimeBindingSource
            // 
            this.activityTimeBindingSource.DataMember = "ActivityActivityTime";
            this.activityTimeBindingSource.DataSource = this.activityBindingSource;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 2;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlIRP.Id = new System.Guid("9911d7d8-e7ed-4d91-9ff2-45c185a929d8");
            this.uiPanelManager1.Panels.Add(this.pnlIRP);
            this.pnlActivityDisb.Id = new System.Guid("cbac48d0-24c2-46ec-840a-1ac8580d9304");
            this.uiPanelManager1.Panels.Add(this.pnlActivityDisb);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("9911d7d8-e7ed-4d91-9ff2-45c185a929d8"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1108, 302), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("cbac48d0-24c2-46ec-840a-1ac8580d9304"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1108, 398), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c45f40d3-3a69-4b5f-9bb4-bcc4041b2c39"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5c30eda2-4594-41e2-9985-376c5fce72e9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e11a25cc-9449-486a-b562-5ebf98e4b383"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ea2edd7d-ea58-44fc-8638-9bbef782288a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("9911d7d8-e7ed-4d91-9ff2-45c185a929d8"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("cbac48d0-24c2-46ec-840a-1ac8580d9304"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5c33d950-36a1-43f7-8afe-32365928feaa"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlIRP
            // 
            this.pnlIRP.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlIRP.CaptionFormatStyle.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pnlIRP, "pnlIRP");
            this.pnlIRP.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlIRP.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlIRP.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlIRP.InnerContainer = this.pnlIRPContainer;
            this.pnlIRP.Name = "pnlIRP";
            this.helpProvider1.SetShowHelp(this.pnlIRP, ((bool)(resources.GetObject("pnlIRP.ShowHelp"))));
            // 
            // pnlIRPContainer
            // 
            resources.ApplyResources(this.pnlIRPContainer, "pnlIRPContainer");
            this.pnlIRPContainer.Controls.Add(this.btnRollbackTaxation);
            this.pnlIRPContainer.Controls.Add(this.btnClearOfficer);
            this.pnlIRPContainer.Controls.Add(this.btnApplyTaxRecs);
            this.pnlIRPContainer.Controls.Add(this.taxingGridEX);
            this.pnlIRPContainer.Controls.Add(this.gbMessage);
            this.pnlIRPContainer.Controls.Add(this.uiButton1);
            this.pnlIRPContainer.Controls.Add(fileIDLabel);
            this.pnlIRPContainer.Controls.Add(this.fileIDucFileSelectBox);
            this.pnlIRPContainer.Controls.Add(this.taxingDifferenceNumericEditBox);
            this.pnlIRPContainer.Controls.Add(taxingDifferenceLabel);
            this.pnlIRPContainer.Controls.Add(label30);
            this.pnlIRPContainer.Controls.Add(this.dateTaxedBillingReview);
            this.pnlIRPContainer.Controls.Add(this.netTotalTaxedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(label38);
            this.pnlIRPContainer.Controls.Add(this.netTotalClaimedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(label28);
            this.pnlIRPContainer.Controls.Add(netTotalClaimedLabel);
            this.pnlIRPContainer.Controls.Add(netTotalTaxedLabel);
            this.pnlIRPContainer.Controls.Add(this.disbursementTaxExemptTaxedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.disbursementTaxedTaxNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.disbursementTaxExemptClaimedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.officeIDucOfficeSelectBox);
            this.pnlIRPContainer.Controls.Add(this.fileTotalTaxedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.disbursementTaxedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.sINMaskedEditBox);
            this.pnlIRPContainer.Controls.Add(this.officerIDucContactSelectBox);
            this.pnlIRPContainer.Controls.Add(this.disbursementClaimedTaxNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.feesTaxedTaxNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.disbursementClaimedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.calendarCombo2);
            this.pnlIRPContainer.Controls.Add(label33);
            this.pnlIRPContainer.Controls.Add(this.feesTaxedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.numericEditBox1);
            this.pnlIRPContainer.Controls.Add(feesTaxedTaxLabel);
            this.pnlIRPContainer.Controls.Add(label32);
            this.pnlIRPContainer.Controls.Add(label31);
            this.pnlIRPContainer.Controls.Add(this.feesClaimedTaxNumericEditBox);
            this.pnlIRPContainer.Controls.Add(this.feesClaimedNumericEditBox);
            this.pnlIRPContainer.Controls.Add(label27);
            this.pnlIRPContainer.Controls.Add(feesClaimedLabel);
            this.pnlIRPContainer.Controls.Add(label29);
            this.pnlIRPContainer.Controls.Add(feesClaimedTaxLabel);
            this.pnlIRPContainer.Controls.Add(disbursementClaimedLabel);
            this.pnlIRPContainer.Controls.Add(disbursementClaimedTaxLabel);
            this.pnlIRPContainer.Controls.Add(feesTaxedLabel);
            this.pnlIRPContainer.Controls.Add(this.btnBeginTaxation);
            this.pnlIRPContainer.Name = "pnlIRPContainer";
            this.helpProvider1.SetShowHelp(this.pnlIRPContainer, ((bool)(resources.GetObject("pnlIRPContainer.ShowHelp"))));
            // 
            // btnRollbackTaxation
            // 
            this.btnRollbackTaxation.Image = global::LawMate.Properties.Resources.eraser;
            resources.ApplyResources(this.btnRollbackTaxation, "btnRollbackTaxation");
            this.btnRollbackTaxation.Name = "btnRollbackTaxation";
            this.btnRollbackTaxation.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnRollbackTaxation, ((bool)(resources.GetObject("btnRollbackTaxation.ShowHelp"))));
            this.btnRollbackTaxation.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnRollbackTaxation.Click += new System.EventHandler(this.btnRollbackTaxation_Click);
            // 
            // btnClearOfficer
            // 
            this.btnClearOfficer.Image = global::LawMate.Properties.Resources.eraser;
            resources.ApplyResources(this.btnClearOfficer, "btnClearOfficer");
            this.btnClearOfficer.Name = "btnClearOfficer";
            this.btnClearOfficer.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnClearOfficer, ((bool)(resources.GetObject("btnClearOfficer.ShowHelp"))));
            this.btnClearOfficer.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnClearOfficer.Click += new System.EventHandler(this.btnClearOfficer_Click);
            // 
            // btnApplyTaxRecs
            // 
            this.btnApplyTaxRecs.Image = global::LawMate.Properties.Resources.taxRecClosed;
            resources.ApplyResources(this.btnApplyTaxRecs, "btnApplyTaxRecs");
            this.btnApplyTaxRecs.Name = "btnApplyTaxRecs";
            this.btnApplyTaxRecs.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnApplyTaxRecs, ((bool)(resources.GetObject("btnApplyTaxRecs.ShowHelp"))));
            this.btnApplyTaxRecs.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnApplyTaxRecs.Click += new System.EventHandler(this.btnApplyTaxRecs_Click);
            // 
            // taxingGridEX
            // 
            this.taxingGridEX.AllowColumnDrag = false;
            this.taxingGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.taxingGridEX.AutomaticSort = false;
            this.taxingGridEX.DataSource = this.taxingBindingSource;
            taxingGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("taxingGridEX_DesignTimeLayout_Reference_0.Instance")));
            taxingGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("taxingGridEX_DesignTimeLayout_Reference_1.Instance")));
            taxingGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("taxingGridEX_DesignTimeLayout_Reference_2.Instance")));
            taxingGridEX_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("taxingGridEX_DesignTimeLayout_Reference_3.Instance")));
            taxingGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            taxingGridEX_DesignTimeLayout_Reference_0,
            taxingGridEX_DesignTimeLayout_Reference_1,
            taxingGridEX_DesignTimeLayout_Reference_2,
            taxingGridEX_DesignTimeLayout_Reference_3});
            resources.ApplyResources(taxingGridEX_DesignTimeLayout, "taxingGridEX_DesignTimeLayout");
            this.taxingGridEX.DesignTimeLayout = taxingGridEX_DesignTimeLayout;
            this.taxingGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.taxingGridEX, "taxingGridEX");
            this.taxingGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.taxingGridEX.GroupByBoxVisible = false;
            this.taxingGridEX.Name = "taxingGridEX";
            this.taxingGridEX.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Custom;
            this.taxingGridEX.OfficeCustomColor = System.Drawing.Color.Orange;
            this.taxingGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.taxingGridEX.SettingsKey = "taxingGridEX2";
            this.helpProvider1.SetShowHelp(this.taxingGridEX, ((bool)(resources.GetObject("taxingGridEX.ShowHelp"))));
            this.taxingGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.taxingGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.taxingGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.taxingGridEX_LoadingRow);
            this.taxingGridEX.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.taxingGridEX_CellUpdated);
            this.taxingGridEX.RecordUpdated += new System.EventHandler(this.taxingGridEX_RecordUpdated);
            // 
            // taxingBindingSource
            // 
            this.taxingBindingSource.CurrentChanged += new System.EventHandler(this.taxingBindingSource_CurrentChanged);
            // 
            // gbMessage
            // 
            this.gbMessage.BackColor = System.Drawing.Color.Transparent;
            this.gbMessage.Controls.Add(this.label3);
            this.gbMessage.FrameStyle = Janus.Windows.EditControls.FrameStyle.Top;
            this.gbMessage.Image = global::LawMate.Properties.Resources.blue_info2_gif;
            this.gbMessage.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.gbMessage, "gbMessage");
            this.gbMessage.Name = "gbMessage";
            this.helpProvider1.SetShowHelp(this.gbMessage, ((bool)(resources.GetObject("gbMessage.ShowHelp"))));
            this.gbMessage.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.gbMessage.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            // 
            // uiButton1
            // 
            this.uiButton1.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.uiButton1.DropDownContextMenu = this.uiContextMenu1;
            this.uiButton1.Image = global::LawMate.Properties.Resources.folder;
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiButton1, ((bool)(resources.GetObject("uiButton1.ShowHelp"))));
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdGoToActivity1,
            this.cmdGoToTaxation1,
            this.cmdGoToTaxingRec1});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar3});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSaveBillingReview,
            this.tsGoToSRP,
            this.tsGoToSRPDetail,
            this.tsScreenTitleBillingReview,
            this.tsNext2,
            this.tsPrevious2,
            this.tsEditmode,
            this.tsMessage,
            this.cmdGoToActivity,
            this.cmdGoToTaxation,
            this.cmdGoToTaxingRec,
            this.cmdSaveAndNext,
            this.cmdSaveAndPrevious,
            this.cmdAddTaxRec});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1});
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
            // uiCommandBar3
            // 
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode3,
            this.tsScreenTitleBillingReview1,
            this.Separator4,
            this.tsSaveBillingReview1,
            this.Separator5,
            this.tsGoToSRP1,
            this.tsGoToSRPDetail1,
            this.Separator1,
            this.tsPrevious1,
            this.tsNext1,
            this.Separator6,
            this.cmdAddTaxRec1,
            this.Separator2,
            this.cmdSaveAndPrevious1,
            this.Separator3,
            this.cmdSaveAndNext1});
            this.uiCommandBar3.FullRow = true;
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            // 
            // tsEditmode3
            // 
            resources.ApplyResources(this.tsEditmode3, "tsEditmode3");
            this.tsEditmode3.Name = "tsEditmode3";
            // 
            // tsScreenTitleBillingReview1
            // 
            resources.ApplyResources(this.tsScreenTitleBillingReview1, "tsScreenTitleBillingReview1");
            this.tsScreenTitleBillingReview1.Name = "tsScreenTitleBillingReview1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsSaveBillingReview1
            // 
            resources.ApplyResources(this.tsSaveBillingReview1, "tsSaveBillingReview1");
            this.tsSaveBillingReview1.Name = "tsSaveBillingReview1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // tsGoToSRP1
            // 
            resources.ApplyResources(this.tsGoToSRP1, "tsGoToSRP1");
            this.tsGoToSRP1.Name = "tsGoToSRP1";
            // 
            // tsGoToSRPDetail1
            // 
            resources.ApplyResources(this.tsGoToSRPDetail1, "tsGoToSRPDetail1");
            this.tsGoToSRPDetail1.Name = "tsGoToSRPDetail1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // tsPrevious1
            // 
            resources.ApplyResources(this.tsPrevious1, "tsPrevious1");
            this.tsPrevious1.Name = "tsPrevious1";
            // 
            // tsNext1
            // 
            resources.ApplyResources(this.tsNext1, "tsNext1");
            this.tsNext1.Name = "tsNext1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdAddTaxRec1
            // 
            resources.ApplyResources(this.cmdAddTaxRec1, "cmdAddTaxRec1");
            this.cmdAddTaxRec1.Name = "cmdAddTaxRec1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdSaveAndPrevious1
            // 
            this.cmdSaveAndPrevious1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSaveAndPrevious1, "cmdSaveAndPrevious1");
            this.cmdSaveAndPrevious1.Name = "cmdSaveAndPrevious1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdSaveAndNext1
            // 
            this.cmdSaveAndNext1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSaveAndNext1, "cmdSaveAndNext1");
            this.cmdSaveAndNext1.Name = "cmdSaveAndNext1";
            // 
            // tsSaveBillingReview
            // 
            this.tsSaveBillingReview.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsSaveBillingReview, "tsSaveBillingReview");
            this.tsSaveBillingReview.Name = "tsSaveBillingReview";
            // 
            // tsGoToSRP
            // 
            this.tsGoToSRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsGoToSRP, "tsGoToSRP");
            this.tsGoToSRP.Name = "tsGoToSRP";
            // 
            // tsGoToSRPDetail
            // 
            this.tsGoToSRPDetail.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsGoToSRPDetail, "tsGoToSRPDetail");
            this.tsGoToSRPDetail.Name = "tsGoToSRPDetail";
            // 
            // tsScreenTitleBillingReview
            // 
            this.tsScreenTitleBillingReview.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsScreenTitleBillingReview.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitleBillingReview, "tsScreenTitleBillingReview");
            this.tsScreenTitleBillingReview.Name = "tsScreenTitleBillingReview";
            this.tsScreenTitleBillingReview.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            // 
            // tsNext2
            // 
            this.tsNext2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsNext2, "tsNext2");
            this.tsNext2.Name = "tsNext2";
            // 
            // tsPrevious2
            // 
            this.tsPrevious2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsPrevious2, "tsPrevious2");
            this.tsPrevious2.Name = "tsPrevious2";
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
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.ImageBeforeText;
            this.tsEditmode.Visible = Janus.Windows.UI.InheritableBoolean.True;
            // 
            // tsMessage
            // 
            this.tsMessage.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsMessage.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsMessage, "tsMessage");
            this.tsMessage.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.StateStyles.FormatStyle.BackColor = System.Drawing.Color.DarkRed;
            this.tsMessage.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsMessage.StateStyles.FormatStyle.FontName = "calibri";
            this.tsMessage.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.SkyBlue;
            this.tsMessage.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // cmdGoToActivity
            // 
            resources.ApplyResources(this.cmdGoToActivity, "cmdGoToActivity");
            this.cmdGoToActivity.Name = "cmdGoToActivity";
            // 
            // cmdGoToTaxation
            // 
            resources.ApplyResources(this.cmdGoToTaxation, "cmdGoToTaxation");
            this.cmdGoToTaxation.Name = "cmdGoToTaxation";
            // 
            // cmdGoToTaxingRec
            // 
            resources.ApplyResources(this.cmdGoToTaxingRec, "cmdGoToTaxingRec");
            this.cmdGoToTaxingRec.Name = "cmdGoToTaxingRec";
            // 
            // cmdSaveAndNext
            // 
            this.cmdSaveAndNext.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdSaveAndNext, "cmdSaveAndNext");
            this.cmdSaveAndNext.Name = "cmdSaveAndNext";
            this.cmdSaveAndNext.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // cmdSaveAndPrevious
            // 
            resources.ApplyResources(this.cmdSaveAndPrevious, "cmdSaveAndPrevious");
            this.cmdSaveAndPrevious.Name = "cmdSaveAndPrevious";
            // 
            // cmdAddTaxRec
            // 
            this.cmdAddTaxRec.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdAddTaxRec, "cmdAddTaxRec");
            this.cmdAddTaxRec.Name = "cmdAddTaxRec";
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
            this.uiCommandBar3});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar3);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // cmdGoToActivity1
            // 
            resources.ApplyResources(this.cmdGoToActivity1, "cmdGoToActivity1");
            this.cmdGoToActivity1.Name = "cmdGoToActivity1";
            // 
            // cmdGoToTaxation1
            // 
            resources.ApplyResources(this.cmdGoToTaxation1, "cmdGoToTaxation1");
            this.cmdGoToTaxation1.Name = "cmdGoToTaxation1";
            // 
            // cmdGoToTaxingRec1
            // 
            resources.ApplyResources(this.cmdGoToTaxingRec1, "cmdGoToTaxingRec1");
            this.cmdGoToTaxingRec1.Name = "cmdGoToTaxingRec1";
            // 
            // fileIDucFileSelectBox
            // 
            this.fileIDucFileSelectBox.AtMng = null;
            this.fileIDucFileSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.fileIDucFileSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.officeDB_IRPDataTableBindingSource, "FileID", true));
            this.fileIDucFileSelectBox.FileId = null;
            resources.ApplyResources(this.fileIDucFileSelectBox, "fileIDucFileSelectBox");
            this.fileIDucFileSelectBox.Name = "fileIDucFileSelectBox";
            this.fileIDucFileSelectBox.ReadOnly = true;
            this.fileIDucFileSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.fileIDucFileSelectBox, ((bool)(resources.GetObject("fileIDucFileSelectBox.ShowHelp"))));
            // 
            // officeDB_IRPDataTableBindingSource
            // 
            this.officeDB_IRPDataTableBindingSource.DataMember = "IRP";
            this.officeDB_IRPDataTableBindingSource.DataSource = this.atriumDB;
            // 
            // taxingDifferenceNumericEditBox
            // 
            this.taxingDifferenceNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.taxingDifferenceNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "TaxingDifference", true));
            this.taxingDifferenceNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.taxingDifferenceNumericEditBox, "taxingDifferenceNumericEditBox");
            this.taxingDifferenceNumericEditBox.Name = "taxingDifferenceNumericEditBox";
            this.taxingDifferenceNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.taxingDifferenceNumericEditBox, ((bool)(resources.GetObject("taxingDifferenceNumericEditBox.ShowHelp"))));
            this.taxingDifferenceNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.taxingDifferenceNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // dateTaxedBillingReview
            // 
            resources.ApplyResources(this.dateTaxedBillingReview, "dateTaxedBillingReview");
            this.dateTaxedBillingReview.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeDB_IRPDataTableBindingSource, "DateTaxed", true));
            // 
            // 
            // 
            this.dateTaxedBillingReview.DropDownCalendar.FirstMonth = new System.DateTime(2007, 3, 1, 0, 0, 0, 0);
            this.dateTaxedBillingReview.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateTaxedBillingReview.HourIncrement = 0;
            this.dateTaxedBillingReview.MonthIncrement = 0;
            this.dateTaxedBillingReview.Name = "dateTaxedBillingReview";
            this.dateTaxedBillingReview.Nullable = true;
            this.helpProvider1.SetShowHelp(this.dateTaxedBillingReview, ((bool)(resources.GetObject("dateTaxedBillingReview.ShowHelp"))));
            this.dateTaxedBillingReview.Value = new System.DateTime(2015, 1, 19, 0, 0, 0, 0);
            this.dateTaxedBillingReview.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateTaxedBillingReview.YearIncrement = 0;
            // 
            // netTotalTaxedNumericEditBox
            // 
            this.netTotalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.netTotalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "TotalTaxed", true));
            this.netTotalTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.netTotalTaxedNumericEditBox, "netTotalTaxedNumericEditBox");
            this.netTotalTaxedNumericEditBox.Name = "netTotalTaxedNumericEditBox";
            this.netTotalTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.netTotalTaxedNumericEditBox, ((bool)(resources.GetObject("netTotalTaxedNumericEditBox.ShowHelp"))));
            this.netTotalTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.netTotalTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // netTotalClaimedNumericEditBox
            // 
            this.netTotalClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.netTotalClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "TotalClaimed", true));
            this.netTotalClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.netTotalClaimedNumericEditBox, "netTotalClaimedNumericEditBox");
            this.netTotalClaimedNumericEditBox.Name = "netTotalClaimedNumericEditBox";
            this.netTotalClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.netTotalClaimedNumericEditBox, ((bool)(resources.GetObject("netTotalClaimedNumericEditBox.ShowHelp"))));
            this.netTotalClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.netTotalClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxExemptTaxedNumericEditBox
            // 
            this.disbursementTaxExemptTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "DisbursementTaxExemptTaxed", true));
            this.disbursementTaxExemptTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxExemptTaxedNumericEditBox, "disbursementTaxExemptTaxedNumericEditBox");
            this.disbursementTaxExemptTaxedNumericEditBox.Name = "disbursementTaxExemptTaxedNumericEditBox";
            this.helpProvider1.SetShowHelp(this.disbursementTaxExemptTaxedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxExemptTaxedNumericEditBox.ShowHelp"))));
            this.disbursementTaxExemptTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxExemptTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxedTaxNumericEditBox
            // 
            this.disbursementTaxedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "DisbursementTaxedTax", true));
            this.disbursementTaxedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxedTaxNumericEditBox, "disbursementTaxedTaxNumericEditBox");
            this.disbursementTaxedTaxNumericEditBox.Name = "disbursementTaxedTaxNumericEditBox";
            this.disbursementTaxedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxedTaxNumericEditBox, ((bool)(resources.GetObject("disbursementTaxedTaxNumericEditBox.ShowHelp"))));
            this.disbursementTaxedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxExemptClaimedNumericEditBox
            // 
            this.disbursementTaxExemptClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxExemptClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "DisbursementTaxExemptClaimed", true));
            this.disbursementTaxExemptClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxExemptClaimedNumericEditBox, "disbursementTaxExemptClaimedNumericEditBox");
            this.disbursementTaxExemptClaimedNumericEditBox.Name = "disbursementTaxExemptClaimedNumericEditBox";
            this.disbursementTaxExemptClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxExemptClaimedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxExemptClaimedNumericEditBox.ShowHelp"))));
            this.disbursementTaxExemptClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxExemptClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeIDucOfficeSelectBox
            // 
            this.officeIDucOfficeSelectBox.AtMng = null;
            this.officeIDucOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIDucOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.officeDB_IRPDataTableBindingSource, "OfficeID", true));
            resources.ApplyResources(this.officeIDucOfficeSelectBox, "officeIDucOfficeSelectBox");
            this.officeIDucOfficeSelectBox.Name = "officeIDucOfficeSelectBox";
            this.officeIDucOfficeSelectBox.OfficeId = null;
            this.officeIDucOfficeSelectBox.ReadOnly = true;
            this.officeIDucOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIDucOfficeSelectBox, ((bool)(resources.GetObject("officeIDucOfficeSelectBox.ShowHelp"))));
            // 
            // fileTotalTaxedNumericEditBox
            // 
            this.fileTotalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.fileTotalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "FileTotalTaxed", true));
            this.fileTotalTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.fileTotalTaxedNumericEditBox, "fileTotalTaxedNumericEditBox");
            this.fileTotalTaxedNumericEditBox.Name = "fileTotalTaxedNumericEditBox";
            this.fileTotalTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.fileTotalTaxedNumericEditBox, ((bool)(resources.GetObject("fileTotalTaxedNumericEditBox.ShowHelp"))));
            this.fileTotalTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fileTotalTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxedNumericEditBox
            // 
            this.disbursementTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "DisbursementTaxed", true));
            this.disbursementTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxedNumericEditBox, "disbursementTaxedNumericEditBox");
            this.disbursementTaxedNumericEditBox.Name = "disbursementTaxedNumericEditBox";
            this.helpProvider1.SetShowHelp(this.disbursementTaxedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxedNumericEditBox.ShowHelp"))));
            this.disbursementTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sINMaskedEditBox
            // 
            this.sINMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sINMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeDB_IRPDataTableBindingSource, "SIN", true));
            resources.ApplyResources(this.sINMaskedEditBox, "sINMaskedEditBox");
            this.sINMaskedEditBox.Mask = "000 000 000";
            this.sINMaskedEditBox.Name = "sINMaskedEditBox";
            this.sINMaskedEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sINMaskedEditBox, ((bool)(resources.GetObject("sINMaskedEditBox.ShowHelp"))));
            this.sINMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officerIDucContactSelectBox
            // 
            this.officerIDucContactSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officerIDucContactSelectBox.ContactId = null;
            this.officerIDucContactSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.officeDB_IRPDataTableBindingSource, "OfficerID", true));
            this.officerIDucContactSelectBox.FM = null;
            resources.ApplyResources(this.officerIDucContactSelectBox, "officerIDucContactSelectBox");
            this.officerIDucContactSelectBox.Name = "officerIDucContactSelectBox";
            this.officerIDucContactSelectBox.ReadOnly = false;
            this.officerIDucContactSelectBox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.officerIDucContactSelectBox, ((bool)(resources.GetObject("officerIDucContactSelectBox.ShowHelp"))));
            this.officerIDucContactSelectBox.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // disbursementClaimedTaxNumericEditBox
            // 
            this.disbursementClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "DisbursementClaimedTax", true));
            this.disbursementClaimedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementClaimedTaxNumericEditBox, "disbursementClaimedTaxNumericEditBox");
            this.disbursementClaimedTaxNumericEditBox.Name = "disbursementClaimedTaxNumericEditBox";
            this.disbursementClaimedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementClaimedTaxNumericEditBox, ((bool)(resources.GetObject("disbursementClaimedTaxNumericEditBox.ShowHelp"))));
            this.disbursementClaimedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementClaimedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesTaxedTaxNumericEditBox
            // 
            this.feesTaxedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "FeesTaxedTax", true));
            this.feesTaxedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesTaxedTaxNumericEditBox, "feesTaxedTaxNumericEditBox");
            this.feesTaxedTaxNumericEditBox.Name = "feesTaxedTaxNumericEditBox";
            this.feesTaxedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesTaxedTaxNumericEditBox, ((bool)(resources.GetObject("feesTaxedTaxNumericEditBox.ShowHelp"))));
            this.feesTaxedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesTaxedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementClaimedNumericEditBox
            // 
            this.disbursementClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "DisbursementClaimed", true));
            this.disbursementClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementClaimedNumericEditBox, "disbursementClaimedNumericEditBox");
            this.disbursementClaimedNumericEditBox.Name = "disbursementClaimedNumericEditBox";
            this.disbursementClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementClaimedNumericEditBox, ((bool)(resources.GetObject("disbursementClaimedNumericEditBox.ShowHelp"))));
            this.disbursementClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // calendarCombo2
            // 
            this.calendarCombo2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo2, "calendarCombo2");
            this.calendarCombo2.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.officeDB_IRPDataTableBindingSource, "SRPDate", true));
            // 
            // 
            // 
            this.calendarCombo2.DropDownCalendar.FirstMonth = new System.DateTime(2007, 3, 1, 0, 0, 0, 0);
            this.calendarCombo2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.HourIncrement = 0;
            this.calendarCombo2.MonthIncrement = 0;
            this.calendarCombo2.Name = "calendarCombo2";
            this.calendarCombo2.Nullable = true;
            this.calendarCombo2.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo2, ((bool)(resources.GetObject("calendarCombo2.ShowHelp"))));
            this.calendarCombo2.Value = new System.DateTime(2015, 1, 19, 0, 0, 0, 0);
            this.calendarCombo2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.YearIncrement = 0;
            // 
            // feesTaxedNumericEditBox
            // 
            this.feesTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "FeesTaxed", true));
            this.feesTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesTaxedNumericEditBox, "feesTaxedNumericEditBox");
            this.feesTaxedNumericEditBox.Name = "feesTaxedNumericEditBox";
            this.helpProvider1.SetShowHelp(this.feesTaxedNumericEditBox, ((bool)(resources.GetObject("feesTaxedNumericEditBox.ShowHelp"))));
            this.feesTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // numericEditBox1
            // 
            this.numericEditBox1.BackColor = System.Drawing.SystemColors.Control;
            this.numericEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "PercentOfPrincipal", true));
            this.numericEditBox1.DecimalDigits = 3;
            this.numericEditBox1.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent;
            resources.ApplyResources(this.numericEditBox1, "numericEditBox1");
            this.numericEditBox1.Name = "numericEditBox1";
            this.numericEditBox1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.numericEditBox1, ((bool)(resources.GetObject("numericEditBox1.ShowHelp"))));
            this.numericEditBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesClaimedTaxNumericEditBox
            // 
            this.feesClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "FeesClaimedTax", true));
            this.feesClaimedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesClaimedTaxNumericEditBox, "feesClaimedTaxNumericEditBox");
            this.feesClaimedTaxNumericEditBox.Name = "feesClaimedTaxNumericEditBox";
            this.feesClaimedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesClaimedTaxNumericEditBox, ((bool)(resources.GetObject("feesClaimedTaxNumericEditBox.ShowHelp"))));
            this.feesClaimedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesClaimedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesClaimedNumericEditBox
            // 
            this.feesClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.officeDB_IRPDataTableBindingSource, "FeesClaimed", true));
            this.feesClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesClaimedNumericEditBox, "feesClaimedNumericEditBox");
            this.feesClaimedNumericEditBox.Name = "feesClaimedNumericEditBox";
            this.feesClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesClaimedNumericEditBox, ((bool)(resources.GetObject("feesClaimedNumericEditBox.ShowHelp"))));
            this.feesClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // btnBeginTaxation
            // 
            this.btnBeginTaxation.Image = global::LawMate.Properties.Resources.edit3;
            resources.ApplyResources(this.btnBeginTaxation, "btnBeginTaxation");
            this.btnBeginTaxation.Name = "btnBeginTaxation";
            this.btnBeginTaxation.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnBeginTaxation, ((bool)(resources.GetObject("btnBeginTaxation.ShowHelp"))));
            this.btnBeginTaxation.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnBeginTaxation.Click += new System.EventHandler(this.btnBeginTaxation_Click);
            // 
            // pnlActivityDisb
            // 
            this.pnlActivityDisb.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivityDisb.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlActivityDisb.InnerContainer = this.pnlActivityDisbContainer;
            resources.ApplyResources(this.pnlActivityDisb, "pnlActivityDisb");
            this.pnlActivityDisb.Name = "pnlActivityDisb";
            this.helpProvider1.SetShowHelp(this.pnlActivityDisb, ((bool)(resources.GetObject("pnlActivityDisb.ShowHelp"))));
            // 
            // pnlActivityDisbContainer
            // 
            resources.ApplyResources(this.pnlActivityDisbContainer, "pnlActivityDisbContainer");
            this.pnlActivityDisbContainer.Controls.Add(label5);
            this.pnlActivityDisbContainer.Controls.Add(label7);
            this.pnlActivityDisbContainer.Controls.Add(label4);
            this.pnlActivityDisbContainer.Controls.Add(label2);
            this.pnlActivityDisbContainer.Controls.Add(this.disbursementGridEX);
            this.pnlActivityDisbContainer.Controls.Add(this.activityTimeGridEX);
            this.pnlActivityDisbContainer.Controls.Add(this.activityGridEX);
            this.pnlActivityDisbContainer.Controls.Add(label1);
            this.pnlActivityDisbContainer.Controls.Add(label6);
            this.pnlActivityDisbContainer.Name = "pnlActivityDisbContainer";
            this.helpProvider1.SetShowHelp(this.pnlActivityDisbContainer, ((bool)(resources.GetObject("pnlActivityDisbContainer.ShowHelp"))));
            // 
            // disbursementGridEX
            // 
            resources.ApplyResources(this.disbursementGridEX, "disbursementGridEX");
            this.disbursementGridEX.DataSource = this.disbursementBindingSource;
            this.disbursementGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.None;
            this.disbursementGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.disbursementGridEX.GroupByBoxVisible = false;
            this.disbursementGridEX.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.disbursementGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            disbursementGridEX_Layout_0.DataSource = this.disbursementBindingSource;
            disbursementGridEX_Layout_0.IsCurrentLayout = true;
            disbursementGridEX_Layout_0.Key = "layoutAll";
            disbursementGridEX_Layout_0_Reference_0.Instance = ((object)(resources.GetObject("disbursementGridEX_Layout_0_Reference_0.Instance")));
            disbursementGridEX_Layout_0.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            disbursementGridEX_Layout_0_Reference_0});
            resources.ApplyResources(disbursementGridEX_Layout_0, "disbursementGridEX_Layout_0");
            this.disbursementGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            disbursementGridEX_Layout_0});
            this.disbursementGridEX.Name = "disbursementGridEX";
            this.disbursementGridEX.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.disbursementGridEX, ((bool)(resources.GetObject("disbursementGridEX.ShowHelp"))));
            this.disbursementGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.disbursementGridEX.TableSpacing = 16;
            this.disbursementGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.disbursementGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.disbursementGridEX.RecordUpdated += new System.EventHandler(this.activityTimeGridEX_RecordUpdated);
            this.disbursementGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityGridEX_ColumnButtonClick);
            // 
            // activityTimeGridEX
            // 
            resources.ApplyResources(this.activityTimeGridEX, "activityTimeGridEX");
            this.activityTimeGridEX.DataSource = this.activityTimeBindingSource;
            this.activityTimeGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.None;
            this.activityTimeGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityTimeGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.activityTimeGridEX.GroupByBoxVisible = false;
            this.activityTimeGridEX.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.activityTimeGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            activityTimeGridEX_Layout_0.DataSource = this.activityTimeBindingSource;
            activityTimeGridEX_Layout_0.IsCurrentLayout = true;
            activityTimeGridEX_Layout_0.Key = "layoutAll";
            activityTimeGridEX_Layout_0_Reference_0.Instance = ((object)(resources.GetObject("activityTimeGridEX_Layout_0_Reference_0.Instance")));
            activityTimeGridEX_Layout_0_Reference_1.Instance = ((object)(resources.GetObject("activityTimeGridEX_Layout_0_Reference_1.Instance")));
            activityTimeGridEX_Layout_0.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityTimeGridEX_Layout_0_Reference_0,
            activityTimeGridEX_Layout_0_Reference_1});
            resources.ApplyResources(activityTimeGridEX_Layout_0, "activityTimeGridEX_Layout_0");
            this.activityTimeGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            activityTimeGridEX_Layout_0});
            this.activityTimeGridEX.Name = "activityTimeGridEX";
            this.activityTimeGridEX.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.activityTimeGridEX, ((bool)(resources.GetObject("activityTimeGridEX.ShowHelp"))));
            this.activityTimeGridEX.TableSpacing = 16;
            this.activityTimeGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityTimeGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityTimeGridEX.RecordUpdated += new System.EventHandler(this.activityTimeGridEX_RecordUpdated);
            this.activityTimeGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityGridEX_ColumnButtonClick);
            // 
            // activityGridEX
            // 
            this.activityGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            resources.ApplyResources(this.activityGridEX, "activityGridEX");
            this.activityGridEX.DataSource = this.activityBindingSource;
            this.activityGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.None;
            this.activityGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityGridEX.GroupByBoxVisible = false;
            this.activityGridEX.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.activityGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            activityGridEX_Layout_0.DataSource = this.activityBindingSource;
            activityGridEX_Layout_0.IsCurrentLayout = true;
            activityGridEX_Layout_0.Key = "layoutAll";
            activityGridEX_Layout_0_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_0_Reference_0.Instance")));
            activityGridEX_Layout_0_Reference_1.Instance = ((object)(resources.GetObject("activityGridEX_Layout_0_Reference_1.Instance")));
            activityGridEX_Layout_0.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_0_Reference_0,
            activityGridEX_Layout_0_Reference_1});
            resources.ApplyResources(activityGridEX_Layout_0, "activityGridEX_Layout_0");
            activityGridEX_Layout_1.DataSource = this.activityBindingSource;
            activityGridEX_Layout_1.Key = "layoutDisb";
            activityGridEX_Layout_1_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_1_Reference_0.Instance")));
            activityGridEX_Layout_1.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_1_Reference_0});
            resources.ApplyResources(activityGridEX_Layout_1, "activityGridEX_Layout_1");
            activityGridEX_Layout_2.DataSource = this.activityBindingSource;
            activityGridEX_Layout_2.Key = "layoutTime";
            activityGridEX_Layout_2_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_2_Reference_0.Instance")));
            activityGridEX_Layout_2.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_2_Reference_0});
            resources.ApplyResources(activityGridEX_Layout_2, "activityGridEX_Layout_2");
            this.activityGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            activityGridEX_Layout_0,
            activityGridEX_Layout_1,
            activityGridEX_Layout_2});
            this.activityGridEX.Name = "activityGridEX";
            this.activityGridEX.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.activityGridEX, ((bool)(resources.GetObject("activityGridEX.ShowHelp"))));
            this.activityGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.activityGridEX.TableSpacing = 16;
            this.activityGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityGridEX.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.activityGridEX_RowDoubleClick);
            this.activityGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityGridEX_FormattingRow);
            this.activityGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityGridEX_LoadingRow);
            this.activityGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityGridEX_ColumnButtonClick);
            // 
            // pnlBillingReview
            // 
            this.pnlBillingReview.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlBillingReview.InnerContainer = this.pnlBillingReviewContainer;
            resources.ApplyResources(this.pnlBillingReview, "pnlBillingReview");
            this.pnlBillingReview.Name = "pnlBillingReview";
            this.helpProvider1.SetShowHelp(this.pnlBillingReview, ((bool)(resources.GetObject("pnlBillingReview.ShowHelp"))));
            // 
            // pnlBillingReviewContainer
            // 
            resources.ApplyResources(this.pnlBillingReviewContainer, "pnlBillingReviewContainer");
            this.pnlBillingReviewContainer.Name = "pnlBillingReviewContainer";
            this.helpProvider1.SetShowHelp(this.pnlBillingReviewContainer, ((bool)(resources.GetObject("pnlBillingReviewContainer.ShowHelp"))));
            // 
            // pnlGrid
            // 
            this.pnlGrid.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlGrid.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlGrid.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlGrid.InnerContainer = this.pnlGridContainer;
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            this.helpProvider1.SetShowHelp(this.pnlGrid, ((bool)(resources.GetObject("pnlGrid.ShowHelp"))));
            // 
            // pnlGridContainer
            // 
            resources.ApplyResources(this.pnlGridContainer, "pnlGridContainer");
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.helpProvider1.SetShowHelp(this.pnlGridContainer, ((bool)(resources.GetObject("pnlGridContainer.ShowHelp"))));
            // 
            // pnlSRP
            // 
            this.pnlSRP.InnerContainer = this.pnlSRPContainer;
            resources.ApplyResources(this.pnlSRP, "pnlSRP");
            this.pnlSRP.Name = "pnlSRP";
            this.helpProvider1.SetShowHelp(this.pnlSRP, ((bool)(resources.GetObject("pnlSRP.ShowHelp"))));
            // 
            // pnlSRPContainer
            // 
            resources.ApplyResources(this.pnlSRPContainer, "pnlSRPContainer");
            this.pnlSRPContainer.Name = "pnlSRPContainer";
            this.helpProvider1.SetShowHelp(this.pnlSRPContainer, ((bool)(resources.GetObject("pnlSRPContainer.ShowHelp"))));
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.DataSource = this.activityBindingSource;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            this.errorProvider4.DataSource = this.taxingBindingSource;
            // 
            // ucSRPBillingReview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlActivityDisb);
            this.Controls.Add(this.pnlIRP);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucSRPBillingReview";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIRP)).EndInit();
            this.pnlIRP.ResumeLayout(false);
            this.pnlIRPContainer.ResumeLayout(false);
            this.pnlIRPContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMessage)).EndInit();
            this.gbMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeDB_IRPDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityDisb)).EndInit();
            this.pnlActivityDisb.ResumeLayout(false);
            this.pnlActivityDisbContainer.ResumeLayout(false);
            this.pnlActivityDisbContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBillingReview)).EndInit();
            this.pnlBillingReview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRP)).EndInit();
            this.pnlSRP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSRP;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSRPContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBillingReview;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBillingReviewContainer;
        private System.Windows.Forms.BindingSource activityBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private System.Windows.Forms.BindingSource taxingBindingSource;
        private Janus.Windows.GridEX.GridEX activityGridEX;
        private Janus.Windows.GridEX.GridEX taxingGridEX;
        private Janus.Windows.CalendarCombo.CalendarCombo dateTaxedBillingReview;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numericEditBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo2;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitleBillingReview;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRPDetail;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitleBillingReview1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand tsSaveBillingReview1;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand tsSaveBillingReview;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRP;
        private Janus.Windows.UI.CommandBars.UICommand tsNext2;
        private Janus.Windows.UI.CommandBars.UICommand tsPrevious2;
        private Janus.Windows.UI.CommandBars.UICommand tsNext1;
        private Janus.Windows.UI.CommandBars.UICommand tsPrevious1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode3;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private Janus.Windows.UI.CommandBars.UICommand tsMessage;
        private Janus.Windows.GridEX.EditControls.NumericEditBox taxingDifferenceNumericEditBox;
        private System.Windows.Forms.BindingSource officeDB_IRPDataTableBindingSource;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox fileTotalTaxedNumericEditBox;
        private ucContactSelectBox officerIDucContactSelectBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox sINMaskedEditBox;
        private ucOfficeSelectBox officeIDucOfficeSelectBox;
        private Janus.Windows.UI.Dock.UIPanel pnlActivityDisb;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityDisbContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlIRP;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlIRPContainer;
        private ucFileSelectBox fileIDucFileSelectBox;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToActivity;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToTaxation;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToTaxingRec;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToActivity1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToTaxation1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToTaxingRec1;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRP1;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRPDetail1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.GridEX.GridEX disbursementGridEX;
        private System.Windows.Forms.BindingSource disbursementBindingSource;
        private Janus.Windows.GridEX.GridEX activityTimeGridEX;
        private System.Windows.Forms.BindingSource activityTimeBindingSource;
        private Janus.Windows.EditControls.UIGroupBox gbMessage;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnBeginTaxation;
        private Janus.Windows.EditControls.UIButton btnApplyTaxRecs;
        private Janus.Windows.EditControls.UIButton btnClearOfficer;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdSaveAndPrevious1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSaveAndNext1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSaveAndNext;
        private Janus.Windows.UI.CommandBars.UICommand cmdSaveAndPrevious;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddTaxRec1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddTaxRec;
        private Janus.Windows.EditControls.UIButton btnRollbackTaxation;
    }
}
