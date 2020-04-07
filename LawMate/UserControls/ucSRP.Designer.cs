 namespace LawMate
{
    partial class ucSRP
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
                FM.DB.SRP.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetSRP().OnUpdate -= new atLogic.UpdateEventHandler(ucSRP_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSRP));
            System.Windows.Forms.Label sRPDateLabel;
            System.Windows.Forms.Label sRPReceivedDateLabel;
            System.Windows.Forms.Label taxationBeganLabel;
            System.Windows.Forms.Label taxationCompletedLabel;
            System.Windows.Forms.Label countOfTaxationLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label lblFees;
            System.Windows.Forms.Label lblTax;
            System.Windows.Forms.Label lblAmounts;
            System.Windows.Forms.Label disbursementTaxExemptClaimedLabel;
            System.Windows.Forms.Label lblDisbursements;
            System.Windows.Forms.Label lblTotals;
            System.Windows.Forms.Label totalTaxClaimedLabel;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            Janus.Windows.GridEX.GridEXLayout sRPGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout taxingGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.label1 = new System.Windows.Forms.Label();
            this.sRPSubmittedDateLabel = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlTab = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlSRPs = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSRPsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.totalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.sRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.feesTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.totalTaxTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.netTotalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.totalClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.totalTaxClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.netTotalClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.countOfTaxationEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sRPDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.taxationBeganCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sRPSubmittedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sRPReceivedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.taxationCompletedCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.officeIDucOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.sRPGridEX = new Janus.Windows.GridEX.GridEX();
            this.taxingGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlSRP = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSRPContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.tsGoToSRPDetail2 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRPDetail");
            this.tsGoToBillingReview2 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToBillingReview");
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsActions2 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitleSRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitleSRP");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.tsActions1 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSave2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdDelete2 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsGenSRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsGenSRP");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSubmitSRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsSubmitSRP");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdRollbackSRP1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRollbackSRP");
            this.tsGoToSRPDetail = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRPDetail");
            this.tsGoToBillingReview = new Janus.Windows.UI.CommandBars.UICommand("tsGoToBillingReview");
            this.tsScreenTitleSRP = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitleSRP");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsGenSRP = new Janus.Windows.UI.CommandBars.UICommand("tsGenSRP");
            this.tsSubmitSRP = new Janus.Windows.UI.CommandBars.UICommand("tsSubmitSRP");
            this.tsMessage = new Janus.Windows.UI.CommandBars.UICommand("tsMessage");
            this.tsExternalData = new Janus.Windows.UI.CommandBars.UICommand("tsExternalData");
            this.tsExportFees1 = new Janus.Windows.UI.CommandBars.UICommand("tsExportFees");
            this.tsExportDisb1 = new Janus.Windows.UI.CommandBars.UICommand("tsExportDisb");
            this.tsImportBulk = new Janus.Windows.UI.CommandBars.UICommand("tsImportBulk");
            this.tsImportAll = new Janus.Windows.UI.CommandBars.UICommand("tsImportAll");
            this.tsExportFees = new Janus.Windows.UI.CommandBars.UICommand("tsExportFees");
            this.tsExportDisb = new Janus.Windows.UI.CommandBars.UICommand("tsExportDisb");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.tsGoToSRPDetail1 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRPDetail");
            this.tsGoToBillingReview1 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToBillingReview");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.tsGenSRP2 = new Janus.Windows.UI.CommandBars.UICommand("tsGenSRP");
            this.tsExternalData2 = new Janus.Windows.UI.CommandBars.UICommand("tsExternalData");
            this.tsImport1 = new Janus.Windows.UI.CommandBars.UICommand("tsImport");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSubmitSRP2 = new Janus.Windows.UI.CommandBars.UICommand("tsSubmitSRP");
            this.cmdRollbackSRP2 = new Janus.Windows.UI.CommandBars.UICommand("cmdRollbackSRP");
            this.cmdActions = new Janus.Windows.UI.CommandBars.UICommand("cmdActions");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.tsImport = new Janus.Windows.UI.CommandBars.UICommand("tsImport");
            this.tsImportBulk1 = new Janus.Windows.UI.CommandBars.UICommand("tsImportBulk");
            this.tsImportAll1 = new Janus.Windows.UI.CommandBars.UICommand("tsImportAll");
            this.cmdRollbackSRP = new Janus.Windows.UI.CommandBars.UICommand("cmdRollbackSRP");
            this.tsActions = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            sRPDateLabel = new System.Windows.Forms.Label();
            sRPReceivedDateLabel = new System.Windows.Forms.Label();
            taxationBeganLabel = new System.Windows.Forms.Label();
            taxationCompletedLabel = new System.Windows.Forms.Label();
            countOfTaxationLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            lblFees = new System.Windows.Forms.Label();
            lblTax = new System.Windows.Forms.Label();
            lblAmounts = new System.Windows.Forms.Label();
            disbursementTaxExemptClaimedLabel = new System.Windows.Forms.Label();
            lblDisbursements = new System.Windows.Forms.Label();
            lblTotals = new System.Windows.Forms.Label();
            totalTaxClaimedLabel = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).BeginInit();
            this.pnlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRPs)).BeginInit();
            this.pnlSRPs.SuspendLayout();
            this.pnlSRPsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRPGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRP)).BeginInit();
            this.pnlSRP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.sRPBindingSource;
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
            // sRPDateLabel
            // 
            resources.ApplyResources(sRPDateLabel, "sRPDateLabel");
            sRPDateLabel.BackColor = System.Drawing.Color.Transparent;
            sRPDateLabel.Name = "sRPDateLabel";
            this.helpProvider1.SetShowHelp(sRPDateLabel, ((bool)(resources.GetObject("sRPDateLabel.ShowHelp"))));
            // 
            // sRPReceivedDateLabel
            // 
            resources.ApplyResources(sRPReceivedDateLabel, "sRPReceivedDateLabel");
            sRPReceivedDateLabel.BackColor = System.Drawing.Color.Transparent;
            sRPReceivedDateLabel.Name = "sRPReceivedDateLabel";
            this.helpProvider1.SetShowHelp(sRPReceivedDateLabel, ((bool)(resources.GetObject("sRPReceivedDateLabel.ShowHelp"))));
            // 
            // taxationBeganLabel
            // 
            resources.ApplyResources(taxationBeganLabel, "taxationBeganLabel");
            taxationBeganLabel.BackColor = System.Drawing.Color.Transparent;
            taxationBeganLabel.Name = "taxationBeganLabel";
            this.helpProvider1.SetShowHelp(taxationBeganLabel, ((bool)(resources.GetObject("taxationBeganLabel.ShowHelp"))));
            // 
            // taxationCompletedLabel
            // 
            resources.ApplyResources(taxationCompletedLabel, "taxationCompletedLabel");
            taxationCompletedLabel.BackColor = System.Drawing.Color.Transparent;
            taxationCompletedLabel.Name = "taxationCompletedLabel";
            this.helpProvider1.SetShowHelp(taxationCompletedLabel, ((bool)(resources.GetObject("taxationCompletedLabel.ShowHelp"))));
            // 
            // countOfTaxationLabel
            // 
            resources.ApplyResources(countOfTaxationLabel, "countOfTaxationLabel");
            countOfTaxationLabel.BackColor = System.Drawing.Color.Transparent;
            countOfTaxationLabel.Name = "countOfTaxationLabel";
            this.helpProvider1.SetShowHelp(countOfTaxationLabel, ((bool)(resources.GetObject("countOfTaxationLabel.ShowHelp"))));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            this.helpProvider1.SetShowHelp(label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
            // 
            // lblFees
            // 
            resources.ApplyResources(lblFees, "lblFees");
            lblFees.BackColor = System.Drawing.Color.Transparent;
            lblFees.Name = "lblFees";
            this.helpProvider1.SetShowHelp(lblFees, ((bool)(resources.GetObject("lblFees.ShowHelp"))));
            // 
            // lblTax
            // 
            resources.ApplyResources(lblTax, "lblTax");
            lblTax.BackColor = System.Drawing.Color.Transparent;
            lblTax.Name = "lblTax";
            this.helpProvider1.SetShowHelp(lblTax, ((bool)(resources.GetObject("lblTax.ShowHelp"))));
            // 
            // lblAmounts
            // 
            resources.ApplyResources(lblAmounts, "lblAmounts");
            lblAmounts.BackColor = System.Drawing.Color.Transparent;
            lblAmounts.Name = "lblAmounts";
            this.helpProvider1.SetShowHelp(lblAmounts, ((bool)(resources.GetObject("lblAmounts.ShowHelp"))));
            // 
            // disbursementTaxExemptClaimedLabel
            // 
            resources.ApplyResources(disbursementTaxExemptClaimedLabel, "disbursementTaxExemptClaimedLabel");
            disbursementTaxExemptClaimedLabel.BackColor = System.Drawing.Color.Transparent;
            disbursementTaxExemptClaimedLabel.Name = "disbursementTaxExemptClaimedLabel";
            this.helpProvider1.SetShowHelp(disbursementTaxExemptClaimedLabel, ((bool)(resources.GetObject("disbursementTaxExemptClaimedLabel.ShowHelp"))));
            // 
            // lblDisbursements
            // 
            resources.ApplyResources(lblDisbursements, "lblDisbursements");
            lblDisbursements.BackColor = System.Drawing.Color.Transparent;
            lblDisbursements.Name = "lblDisbursements";
            this.helpProvider1.SetShowHelp(lblDisbursements, ((bool)(resources.GetObject("lblDisbursements.ShowHelp"))));
            // 
            // lblTotals
            // 
            resources.ApplyResources(lblTotals, "lblTotals");
            lblTotals.BackColor = System.Drawing.Color.Transparent;
            lblTotals.Name = "lblTotals";
            this.helpProvider1.SetShowHelp(lblTotals, ((bool)(resources.GetObject("lblTotals.ShowHelp"))));
            // 
            // totalTaxClaimedLabel
            // 
            resources.ApplyResources(totalTaxClaimedLabel, "totalTaxClaimedLabel");
            totalTaxClaimedLabel.BackColor = System.Drawing.Color.Transparent;
            totalTaxClaimedLabel.Name = "totalTaxClaimedLabel";
            this.helpProvider1.SetShowHelp(totalTaxClaimedLabel, ((bool)(resources.GetObject("totalTaxClaimedLabel.ShowHelp"))));
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
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Name = "label11";
            this.helpProvider1.SetShowHelp(label11, ((bool)(resources.GetObject("label11.ShowHelp"))));
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.Name = "label12";
            this.helpProvider1.SetShowHelp(label12, ((bool)(resources.GetObject("label12.ShowHelp"))));
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.BackColor = System.Drawing.Color.Transparent;
            label13.Name = "label13";
            this.helpProvider1.SetShowHelp(label13, ((bool)(resources.GetObject("label13.ShowHelp"))));
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.BackColor = System.Drawing.Color.Transparent;
            label14.Name = "label14";
            this.helpProvider1.SetShowHelp(label14, ((bool)(resources.GetObject("label14.ShowHelp"))));
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.BackColor = System.Drawing.Color.Transparent;
            label15.Name = "label15";
            this.helpProvider1.SetShowHelp(label15, ((bool)(resources.GetObject("label15.ShowHelp"))));
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.BackColor = System.Drawing.Color.Transparent;
            label16.Name = "label16";
            this.helpProvider1.SetShowHelp(label16, ((bool)(resources.GetObject("label16.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // sRPSubmittedDateLabel
            // 
            resources.ApplyResources(this.sRPSubmittedDateLabel, "sRPSubmittedDateLabel");
            this.sRPSubmittedDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.sRPSubmittedDateLabel.Name = "sRPSubmittedDateLabel";
            this.helpProvider1.SetShowHelp(this.sRPSubmittedDateLabel, ((bool)(resources.GetObject("sRPSubmittedDateLabel.ShowHelp"))));
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
            this.pnlTab.Id = new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e");
            this.pnlTab.StaticGroup = true;
            this.pnlSRPs.Id = new System.Guid("c45f40d3-3a69-4b5f-9bb4-bcc4041b2c39");
            this.pnlTab.Panels.Add(this.pnlSRPs);
            this.uiPanelManager1.Panels.Add(this.pnlTab);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(741, 503), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c45f40d3-3a69-4b5f-9bb4-bcc4041b2c39"), new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e"), -1, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c45f40d3-3a69-4b5f-9bb4-bcc4041b2c39"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5c30eda2-4594-41e2-9985-376c5fce72e9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e11a25cc-9449-486a-b562-5ebf98e4b383"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ea2edd7d-ea58-44fc-8638-9bbef782288a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlTab
            // 
            this.pnlTab.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            resources.ApplyResources(this.pnlTab, "pnlTab");
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.SelectedPanel = this.pnlSRPs;
            this.helpProvider1.SetShowHelp(this.pnlTab, ((bool)(resources.GetObject("pnlTab.ShowHelp"))));
            this.pnlTab.TabAlignment = Janus.Windows.UI.Dock.TabAlignment.Top;
            // 
            // pnlSRPs
            // 
            this.pnlSRPs.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlSRPs.InnerContainer = this.pnlSRPsContainer;
            resources.ApplyResources(this.pnlSRPs, "pnlSRPs");
            this.pnlSRPs.Name = "pnlSRPs";
            this.helpProvider1.SetShowHelp(this.pnlSRPs, ((bool)(resources.GetObject("pnlSRPs.ShowHelp"))));
            // 
            // pnlSRPsContainer
            // 
            resources.ApplyResources(this.pnlSRPsContainer, "pnlSRPsContainer");
            this.pnlSRPsContainer.Controls.Add(this.uiTab2);
            this.pnlSRPsContainer.Controls.Add(this.uiTab1);
            this.pnlSRPsContainer.Controls.Add(this.uiTab3);
            this.pnlSRPsContainer.Controls.Add(this.label2);
            this.pnlSRPsContainer.Controls.Add(this.label1);
            this.pnlSRPsContainer.Controls.Add(this.officeIDucOfficeSelectBox);
            this.pnlSRPsContainer.Controls.Add(this.sRPGridEX);
            this.pnlSRPsContainer.Name = "pnlSRPsContainer";
            this.helpProvider1.SetShowHelp(this.pnlSRPsContainer, ((bool)(resources.GetObject("pnlSRPsContainer.ShowHelp"))));
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
            this.uiTabPage2});
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
            // uiTabPage2
            // 
            this.uiTabPage2.Controls.Add(this.totalTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(this.feesTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(this.totalTaxTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label16);
            this.uiTabPage2.Controls.Add(this.netTotalTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label15);
            this.uiTabPage2.Controls.Add(this.disbursementTaxedTaxNumericEditBox);
            this.uiTabPage2.Controls.Add(label14);
            this.uiTabPage2.Controls.Add(this.disbursementTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label13);
            this.uiTabPage2.Controls.Add(this.disbursementTaxExemptTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label12);
            this.uiTabPage2.Controls.Add(this.feesTaxedTaxNumericEditBox);
            this.uiTabPage2.Controls.Add(label11);
            this.uiTabPage2.Controls.Add(label10);
            this.uiTabPage2.Controls.Add(label9);
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            // 
            // totalTaxedNumericEditBox
            // 
            this.totalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "TotalTaxed", true));
            this.totalTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalTaxedNumericEditBox, "totalTaxedNumericEditBox");
            this.totalTaxedNumericEditBox.Name = "totalTaxedNumericEditBox";
            this.totalTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalTaxedNumericEditBox, ((bool)(resources.GetObject("totalTaxedNumericEditBox.ShowHelp"))));
            this.totalTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sRPBindingSource
            // 
            this.sRPBindingSource.DataMember = "SRP";
            this.sRPBindingSource.DataSource = this.atriumDB;
            this.sRPBindingSource.CurrentChanged += new System.EventHandler(this.sRPBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // feesTaxedNumericEditBox
            // 
            this.feesTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "FeesTaxed", true));
            this.feesTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesTaxedNumericEditBox, "feesTaxedNumericEditBox");
            this.feesTaxedNumericEditBox.Name = "feesTaxedNumericEditBox";
            this.feesTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesTaxedNumericEditBox, ((bool)(resources.GetObject("feesTaxedNumericEditBox.ShowHelp"))));
            this.feesTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // totalTaxTaxedNumericEditBox
            // 
            this.totalTaxTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "TotalTaxTaxed", true));
            this.totalTaxTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalTaxTaxedNumericEditBox, "totalTaxTaxedNumericEditBox");
            this.totalTaxTaxedNumericEditBox.Name = "totalTaxTaxedNumericEditBox";
            this.totalTaxTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalTaxTaxedNumericEditBox, ((bool)(resources.GetObject("totalTaxTaxedNumericEditBox.ShowHelp"))));
            this.totalTaxTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalTaxTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // netTotalTaxedNumericEditBox
            // 
            this.netTotalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.netTotalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "NetTotalTaxed", true));
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
            // disbursementTaxedTaxNumericEditBox
            // 
            this.disbursementTaxedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "DisbursementTaxedTax", true));
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
            // disbursementTaxedNumericEditBox
            // 
            this.disbursementTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "DisbursementTaxed", true));
            this.disbursementTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxedNumericEditBox, "disbursementTaxedNumericEditBox");
            this.disbursementTaxedNumericEditBox.Name = "disbursementTaxedNumericEditBox";
            this.disbursementTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxedNumericEditBox.ShowHelp"))));
            this.disbursementTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxExemptTaxedNumericEditBox
            // 
            this.disbursementTaxExemptTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxExemptTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "DisbursementTaxExemptTaxed", true));
            this.disbursementTaxExemptTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxExemptTaxedNumericEditBox, "disbursementTaxExemptTaxedNumericEditBox");
            this.disbursementTaxExemptTaxedNumericEditBox.Name = "disbursementTaxExemptTaxedNumericEditBox";
            this.disbursementTaxExemptTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxExemptTaxedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxExemptTaxedNumericEditBox.ShowHelp"))));
            this.disbursementTaxExemptTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxExemptTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesTaxedTaxNumericEditBox
            // 
            this.feesTaxedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "FeesTaxedTax", true));
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
            this.uiTabPage1.Controls.Add(this.totalClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(lblFees);
            this.uiTabPage1.Controls.Add(this.totalTaxClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(totalTaxClaimedLabel);
            this.uiTabPage1.Controls.Add(this.netTotalClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(lblTotals);
            this.uiTabPage1.Controls.Add(this.disbursementClaimedTaxNumericEditBox);
            this.uiTabPage1.Controls.Add(lblDisbursements);
            this.uiTabPage1.Controls.Add(this.disbursementClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(disbursementTaxExemptClaimedLabel);
            this.uiTabPage1.Controls.Add(this.disbursementTaxExemptClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(lblAmounts);
            this.uiTabPage1.Controls.Add(this.feesClaimedTaxNumericEditBox);
            this.uiTabPage1.Controls.Add(lblTax);
            this.uiTabPage1.Controls.Add(this.feesClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(label8);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // totalClaimedNumericEditBox
            // 
            this.totalClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "TotalClaimed", true));
            this.totalClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalClaimedNumericEditBox, "totalClaimedNumericEditBox");
            this.totalClaimedNumericEditBox.Name = "totalClaimedNumericEditBox";
            this.totalClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalClaimedNumericEditBox, ((bool)(resources.GetObject("totalClaimedNumericEditBox.ShowHelp"))));
            this.totalClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // totalTaxClaimedNumericEditBox
            // 
            this.totalTaxClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "TotalTaxClaimed", true));
            this.totalTaxClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalTaxClaimedNumericEditBox, "totalTaxClaimedNumericEditBox");
            this.totalTaxClaimedNumericEditBox.Name = "totalTaxClaimedNumericEditBox";
            this.totalTaxClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalTaxClaimedNumericEditBox, ((bool)(resources.GetObject("totalTaxClaimedNumericEditBox.ShowHelp"))));
            this.totalTaxClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalTaxClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // netTotalClaimedNumericEditBox
            // 
            this.netTotalClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.netTotalClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "NetTotalClaimed", true));
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
            // disbursementClaimedTaxNumericEditBox
            // 
            this.disbursementClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "DisbursementClaimedTax", true));
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
            // disbursementClaimedNumericEditBox
            // 
            this.disbursementClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "DisbursementClaimed", true));
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
            // disbursementTaxExemptClaimedNumericEditBox
            // 
            this.disbursementTaxExemptClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxExemptClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "DisbursementTaxExemptClaimed", true));
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
            // feesClaimedTaxNumericEditBox
            // 
            this.feesClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "FeesClaimedTax", true));
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
            this.feesClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.sRPBindingSource, "FeesClaimed", true));
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
            // uiTab3
            // 
            resources.ApplyResources(this.uiTab3, "uiTab3");
            this.uiTab3.BackColor = System.Drawing.Color.Transparent;
            this.uiTab3.Name = "uiTab3";
            this.uiTab3.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab3.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab3, ((bool)(resources.GetObject("uiTab3.ShowHelp"))));
            this.uiTab3.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage3});
            this.uiTab3.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab3.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab3.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab3.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab3.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab3.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage3
            // 
            this.uiTabPage3.Controls.Add(this.countOfTaxationEditBox);
            this.uiTabPage3.Controls.Add(this.sRPDateCalendarCombo);
            this.uiTabPage3.Controls.Add(this.sRPSubmittedDateLabel);
            this.uiTabPage3.Controls.Add(this.taxationBeganCalendarCombo);
            this.uiTabPage3.Controls.Add(this.sRPSubmittedDateCalendarCombo);
            this.uiTabPage3.Controls.Add(taxationBeganLabel);
            this.uiTabPage3.Controls.Add(countOfTaxationLabel);
            this.uiTabPage3.Controls.Add(this.sRPReceivedDateCalendarCombo);
            this.uiTabPage3.Controls.Add(taxationCompletedLabel);
            this.uiTabPage3.Controls.Add(sRPReceivedDateLabel);
            this.uiTabPage3.Controls.Add(this.taxationCompletedCalendarCombo);
            this.uiTabPage3.Controls.Add(sRPDateLabel);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // countOfTaxationEditBox
            // 
            this.countOfTaxationEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.countOfTaxationEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sRPBindingSource, "CountOfTaxation", true));
            resources.ApplyResources(this.countOfTaxationEditBox, "countOfTaxationEditBox");
            this.countOfTaxationEditBox.Name = "countOfTaxationEditBox";
            this.countOfTaxationEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.countOfTaxationEditBox, ((bool)(resources.GetObject("countOfTaxationEditBox.ShowHelp"))));
            this.countOfTaxationEditBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.countOfTaxationEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sRPDateCalendarCombo
            // 
            resources.ApplyResources(this.sRPDateCalendarCombo, "sRPDateCalendarCombo");
            this.sRPDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sRPBindingSource, "SRPDate", true));
            this.sRPDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.sRPDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.sRPDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPDateCalendarCombo.MonthIncrement = 0;
            this.sRPDateCalendarCombo.Name = "sRPDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.sRPDateCalendarCombo, ((bool)(resources.GetObject("sRPDateCalendarCombo.ShowHelp"))));
            this.sRPDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPDateCalendarCombo.YearIncrement = 0;
            // 
            // taxationBeganCalendarCombo
            // 
            resources.ApplyResources(this.taxationBeganCalendarCombo, "taxationBeganCalendarCombo");
            this.taxationBeganCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sRPBindingSource, "TaxationBegan", true));
            this.taxationBeganCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.taxationBeganCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.taxationBeganCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.taxationBeganCalendarCombo.MonthIncrement = 0;
            this.taxationBeganCalendarCombo.Name = "taxationBeganCalendarCombo";
            this.taxationBeganCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.taxationBeganCalendarCombo, ((bool)(resources.GetObject("taxationBeganCalendarCombo.ShowHelp"))));
            this.taxationBeganCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.taxationBeganCalendarCombo.YearIncrement = 0;
            // 
            // sRPSubmittedDateCalendarCombo
            // 
            this.sRPSubmittedDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.sRPSubmittedDateCalendarCombo, "sRPSubmittedDateCalendarCombo");
            this.sRPSubmittedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sRPBindingSource, "SRPSubmittedDate", true));
            this.sRPSubmittedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.sRPSubmittedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.sRPSubmittedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPSubmittedDateCalendarCombo.MonthIncrement = 0;
            this.sRPSubmittedDateCalendarCombo.Name = "sRPSubmittedDateCalendarCombo";
            this.sRPSubmittedDateCalendarCombo.Nullable = true;
            this.sRPSubmittedDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sRPSubmittedDateCalendarCombo, ((bool)(resources.GetObject("sRPSubmittedDateCalendarCombo.ShowHelp"))));
            this.sRPSubmittedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPSubmittedDateCalendarCombo.YearIncrement = 0;
            // 
            // sRPReceivedDateCalendarCombo
            // 
            resources.ApplyResources(this.sRPReceivedDateCalendarCombo, "sRPReceivedDateCalendarCombo");
            this.sRPReceivedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sRPBindingSource, "SRPReceivedDate", true));
            this.sRPReceivedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.sRPReceivedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.sRPReceivedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPReceivedDateCalendarCombo.MonthIncrement = 0;
            this.sRPReceivedDateCalendarCombo.Name = "sRPReceivedDateCalendarCombo";
            this.sRPReceivedDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.sRPReceivedDateCalendarCombo, ((bool)(resources.GetObject("sRPReceivedDateCalendarCombo.ShowHelp"))));
            this.sRPReceivedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPReceivedDateCalendarCombo.YearIncrement = 0;
            // 
            // taxationCompletedCalendarCombo
            // 
            resources.ApplyResources(this.taxationCompletedCalendarCombo, "taxationCompletedCalendarCombo");
            this.taxationCompletedCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sRPBindingSource, "TaxationCompleted", true));
            this.taxationCompletedCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.taxationCompletedCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.taxationCompletedCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.taxationCompletedCalendarCombo.MonthIncrement = 0;
            this.taxationCompletedCalendarCombo.Name = "taxationCompletedCalendarCombo";
            this.taxationCompletedCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.taxationCompletedCalendarCombo, ((bool)(resources.GetObject("taxationCompletedCalendarCombo.ShowHelp"))));
            this.taxationCompletedCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.taxationCompletedCalendarCombo.YearIncrement = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Image = global::LawMate.Properties.Resources.hourglass;
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // officeIDucOfficeSelectBox
            // 
            resources.ApplyResources(this.officeIDucOfficeSelectBox, "officeIDucOfficeSelectBox");
            this.officeIDucOfficeSelectBox.AtMng = null;
            this.officeIDucOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIDucOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.sRPBindingSource, "OfficeID", true));
            this.officeIDucOfficeSelectBox.Name = "officeIDucOfficeSelectBox";
            this.officeIDucOfficeSelectBox.OfficeId = null;
            this.officeIDucOfficeSelectBox.ReadOnly = true;
            this.officeIDucOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIDucOfficeSelectBox, ((bool)(resources.GetObject("officeIDucOfficeSelectBox.ShowHelp"))));
            // 
            // sRPGridEX
            // 
            this.sRPGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.sRPGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.uiCommandManager1.SetContextMenu(this.sRPGridEX, this.uiContextMenu1);
            this.sRPGridEX.DataSource = this.sRPBindingSource;
            resources.ApplyResources(sRPGridEX_DesignTimeLayout, "sRPGridEX_DesignTimeLayout");
            this.sRPGridEX.DesignTimeLayout = sRPGridEX_DesignTimeLayout;
            this.sRPGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.sRPGridEX, "sRPGridEX");
            this.sRPGridEX.GridLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sRPGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.sRPGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.sRPGridEX.GroupByBoxVisible = false;
            this.sRPGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.sRPGridEX.Name = "sRPGridEX";
            this.helpProvider1.SetShowHelp(this.sRPGridEX, ((bool)(resources.GetObject("sRPGridEX.ShowHelp"))));
            this.sRPGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.sRPGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.sRPGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.sRPGridEX.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.sRPGridEX_RowDoubleClick);
            // 
            // taxingGridEX
            // 
            this.taxingGridEX.AllowColumnDrag = false;
            this.taxingGridEX.AutomaticSort = false;
            resources.ApplyResources(taxingGridEX_DesignTimeLayout, "taxingGridEX_DesignTimeLayout");
            this.taxingGridEX.DesignTimeLayout = taxingGridEX_DesignTimeLayout;
            resources.ApplyResources(this.taxingGridEX, "taxingGridEX");
            this.taxingGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.taxingGridEX.GroupByBoxVisible = false;
            this.taxingGridEX.Name = "taxingGridEX";
            this.helpProvider1.SetShowHelp(this.taxingGridEX, ((bool)(resources.GetObject("taxingGridEX.ShowHelp"))));
            this.taxingGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.taxingGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
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
            this.tsGoToSRPDetail,
            this.tsGoToBillingReview,
            this.tsScreenTitleSRP,
            this.tsEditmode,
            this.tsGenSRP,
            this.tsSubmitSRP,
            this.tsMessage,
            this.tsExternalData,
            this.tsImportBulk,
            this.tsImportAll,
            this.tsExportFees,
            this.tsExportDisb,
            this.cmdFile,
            this.cmdEdit,
            this.cmdView,
            this.cmdTools,
            this.cmdActions,
            this.cmdSave,
            this.cmdDelete,
            this.cmdNew,
            this.tsImport,
            this.cmdRollbackSRP,
            this.tsActions});
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
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsGoToSRPDetail2,
            this.tsGoToBillingReview2});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.Popup += new System.EventHandler(this.uiContextMenu1_Popup);
            // 
            // tsGoToSRPDetail2
            // 
            resources.ApplyResources(this.tsGoToSRPDetail2, "tsGoToSRPDetail2");
            this.tsGoToSRPDetail2.Name = "tsGoToSRPDetail2";
            // 
            // tsGoToBillingReview2
            // 
            resources.ApplyResources(this.tsGoToBillingReview2, "tsGoToBillingReview2");
            this.tsGoToBillingReview2.Name = "tsGoToBillingReview2";
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
            this.tsActions2,
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
            // tsActions2
            // 
            resources.ApplyResources(this.tsActions2, "tsActions2");
            this.tsActions2.Name = "tsActions2";
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
            this.tsScreenTitleSRP1,
            this.Separator1,
            this.cmdNew1,
            this.tsActions1,
            this.Separator4,
            this.cmdSave2,
            this.cmdDelete2,
            this.Separator10,
            this.tsGenSRP1,
            this.Separator2,
            this.tsSubmitSRP1,
            this.Separator3,
            this.cmdRollbackSRP1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // tsEditmode1
            // 
            resources.ApplyResources(this.tsEditmode1, "tsEditmode1");
            this.tsEditmode1.Name = "tsEditmode1";
            // 
            // tsScreenTitleSRP1
            // 
            resources.ApplyResources(this.tsScreenTitleSRP1, "tsScreenTitleSRP1");
            this.tsScreenTitleSRP1.Name = "tsScreenTitleSRP1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdNew1
            // 
            resources.ApplyResources(this.cmdNew1, "cmdNew1");
            this.cmdNew1.Name = "cmdNew1";
            // 
            // tsActions1
            // 
            resources.ApplyResources(this.tsActions1, "tsActions1");
            this.tsActions1.Name = "tsActions1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdSave2
            // 
            resources.ApplyResources(this.cmdSave2, "cmdSave2");
            this.cmdSave2.Name = "cmdSave2";
            // 
            // cmdDelete2
            // 
            resources.ApplyResources(this.cmdDelete2, "cmdDelete2");
            this.cmdDelete2.Name = "cmdDelete2";
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator10, "Separator10");
            this.Separator10.Name = "Separator10";
            // 
            // tsGenSRP1
            // 
            resources.ApplyResources(this.tsGenSRP1, "tsGenSRP1");
            this.tsGenSRP1.Name = "tsGenSRP1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsSubmitSRP1
            // 
            resources.ApplyResources(this.tsSubmitSRP1, "tsSubmitSRP1");
            this.tsSubmitSRP1.Name = "tsSubmitSRP1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdRollbackSRP1
            // 
            resources.ApplyResources(this.cmdRollbackSRP1, "cmdRollbackSRP1");
            this.cmdRollbackSRP1.Name = "cmdRollbackSRP1";
            // 
            // tsGoToSRPDetail
            // 
            this.tsGoToSRPDetail.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsGoToSRPDetail, "tsGoToSRPDetail");
            this.tsGoToSRPDetail.Name = "tsGoToSRPDetail";
            // 
            // tsGoToBillingReview
            // 
            this.tsGoToBillingReview.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsGoToBillingReview, "tsGoToBillingReview");
            this.tsGoToBillingReview.Name = "tsGoToBillingReview";
            // 
            // tsScreenTitleSRP
            // 
            this.tsScreenTitleSRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsScreenTitleSRP.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitleSRP, "tsScreenTitleSRP");
            this.tsScreenTitleSRP.Name = "tsScreenTitleSRP";
            this.tsScreenTitleSRP.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitleSRP.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
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
            // tsGenSRP
            // 
            this.tsGenSRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsGenSRP, "tsGenSRP");
            this.tsGenSRP.Name = "tsGenSRP";
            // 
            // tsSubmitSRP
            // 
            this.tsSubmitSRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsSubmitSRP, "tsSubmitSRP");
            this.tsSubmitSRP.Name = "tsSubmitSRP";
            // 
            // tsMessage
            // 
            this.tsMessage.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsMessage.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsMessage, "tsMessage");
            this.tsMessage.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsMessage.StateStyles.FormatStyle.FontName = "arial";
            this.tsMessage.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Red;
            this.tsMessage.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsExternalData
            // 
            this.tsExternalData.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsExportFees1,
            this.tsExportDisb1});
            this.tsExternalData.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsExternalData, "tsExternalData");
            this.tsExternalData.Name = "tsExternalData";
            // 
            // tsExportFees1
            // 
            resources.ApplyResources(this.tsExportFees1, "tsExportFees1");
            this.tsExportFees1.Name = "tsExportFees1";
            // 
            // tsExportDisb1
            // 
            resources.ApplyResources(this.tsExportDisb1, "tsExportDisb1");
            this.tsExportDisb1.Name = "tsExportDisb1";
            // 
            // tsImportBulk
            // 
            this.tsImportBulk.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsImportBulk, "tsImportBulk");
            this.tsImportBulk.Name = "tsImportBulk";
            // 
            // tsImportAll
            // 
            this.tsImportAll.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsImportAll, "tsImportAll");
            this.tsImportAll.Name = "tsImportAll";
            // 
            // tsExportFees
            // 
            this.tsExportFees.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsExportFees, "tsExportFees");
            this.tsExportFees.Name = "tsExportFees";
            // 
            // tsExportDisb
            // 
            this.tsExportDisb.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsExportDisb, "tsExportDisb");
            this.tsExportDisb.Name = "tsExportDisb";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdSave1
            // 
            resources.ApplyResources(this.cmdSave1, "cmdSave1");
            this.cmdSave1.Name = "cmdSave1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdDelete1});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdDelete1
            // 
            resources.ApplyResources(this.cmdDelete1, "cmdDelete1");
            this.cmdDelete1.Name = "cmdDelete1";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsGoToSRPDetail1,
            this.tsGoToBillingReview1});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.Name = "cmdView";
            // 
            // tsGoToSRPDetail1
            // 
            resources.ApplyResources(this.tsGoToSRPDetail1, "tsGoToSRPDetail1");
            this.tsGoToSRPDetail1.Name = "tsGoToSRPDetail1";
            // 
            // tsGoToBillingReview1
            // 
            resources.ApplyResources(this.tsGoToBillingReview1, "tsGoToBillingReview1");
            this.tsGoToBillingReview1.Name = "tsGoToBillingReview1";
            // 
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsGenSRP2,
            this.tsExternalData2,
            this.tsImport1,
            this.Separator5,
            this.tsSubmitSRP2,
            this.cmdRollbackSRP2});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.Name = "cmdTools";
            // 
            // tsGenSRP2
            // 
            resources.ApplyResources(this.tsGenSRP2, "tsGenSRP2");
            this.tsGenSRP2.Name = "tsGenSRP2";
            // 
            // tsExternalData2
            // 
            resources.ApplyResources(this.tsExternalData2, "tsExternalData2");
            this.tsExternalData2.Name = "tsExternalData2";
            // 
            // tsImport1
            // 
            resources.ApplyResources(this.tsImport1, "tsImport1");
            this.tsImport1.Name = "tsImport1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // tsSubmitSRP2
            // 
            resources.ApplyResources(this.tsSubmitSRP2, "tsSubmitSRP2");
            this.tsSubmitSRP2.Name = "tsSubmitSRP2";
            // 
            // cmdRollbackSRP2
            // 
            resources.ApplyResources(this.cmdRollbackSRP2, "cmdRollbackSRP2");
            this.cmdRollbackSRP2.Name = "cmdRollbackSRP2";
            // 
            // cmdActions
            // 
            resources.ApplyResources(this.cmdActions, "cmdActions");
            this.cmdActions.Name = "cmdActions";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdSave, "cmdSave");
            this.cmdSave.Name = "cmdSave";
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdDelete, "cmdDelete");
            this.cmdDelete.Name = "cmdDelete";
            // 
            // cmdNew
            // 
            this.cmdNew.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdNew, "cmdNew");
            this.cmdNew.Name = "cmdNew";
            // 
            // tsImport
            // 
            this.tsImport.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsImportBulk1,
            this.tsImportAll1});
            resources.ApplyResources(this.tsImport, "tsImport");
            this.tsImport.Name = "tsImport";
            // 
            // tsImportBulk1
            // 
            resources.ApplyResources(this.tsImportBulk1, "tsImportBulk1");
            this.tsImportBulk1.Name = "tsImportBulk1";
            // 
            // tsImportAll1
            // 
            resources.ApplyResources(this.tsImportAll1, "tsImportAll1");
            this.tsImportAll1.Name = "tsImportAll1";
            // 
            // cmdRollbackSRP
            // 
            this.cmdRollbackSRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdRollbackSRP, "cmdRollbackSRP");
            this.cmdRollbackSRP.Name = "cmdRollbackSRP";
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ucSRP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucSRP";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucSRP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).EndInit();
            this.pnlTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRPs)).EndInit();
            this.pnlSRPs.ResumeLayout(false);
            this.pnlSRPsContainer.ResumeLayout(false);
            this.pnlSRPsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage2.ResumeLayout(false);
            this.uiTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRPGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRP)).EndInit();
            this.pnlSRP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSRP;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSRPContainer;
        private System.Windows.Forms.BindingSource sRPBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo taxationCompletedCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo taxationBeganCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo sRPReceivedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo sRPDateCalendarCombo;
        private Janus.Windows.GridEX.GridEX sRPGridEX;
        private Janus.Windows.CalendarCombo.CalendarCombo sRPSubmittedDateCalendarCombo;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlTab;
        private Janus.Windows.UI.Dock.UIPanel pnlSRPs;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSRPsContainer;
        private Janus.Windows.GridEX.GridEX taxingGridEX;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitleSRP;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRPDetail;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToBillingReview;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitleSRP1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand tsGenSRP;
        private Janus.Windows.UI.CommandBars.UICommand tsSubmitSRP;
        private Janus.Windows.UI.CommandBars.UICommand tsGenSRP1;
        private Janus.Windows.UI.CommandBars.UICommand tsSubmitSRP1;
        private System.Windows.Forms.Label sRPSubmittedDateLabel;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.UI.CommandBars.UICommand tsMessage;
        private Janus.Windows.UI.CommandBars.UICommand tsExternalData;
        private Janus.Windows.UI.CommandBars.UICommand tsExportFees1;
        private Janus.Windows.UI.CommandBars.UICommand tsExportDisb1;
        private Janus.Windows.UI.CommandBars.UICommand tsImportBulk;
        private Janus.Windows.UI.CommandBars.UICommand tsImportAll;
        private Janus.Windows.UI.CommandBars.UICommand tsExportFees;
        private Janus.Windows.UI.CommandBars.UICommand tsExportDisb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ucOfficeSelectBox officeIDucOfficeSelectBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox countOfTaxationEditBox;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRPDetail1;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToBillingReview1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommand tsExternalData2;
        private Janus.Windows.UI.CommandBars.UICommand cmdActions;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete2;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsImport1;
        private Janus.Windows.UI.CommandBars.UICommand tsImport;
        private Janus.Windows.UI.CommandBars.UICommand tsImportBulk1;
        private Janus.Windows.UI.CommandBars.UICommand tsImportAll1;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRPDetail2;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToBillingReview2;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdRollbackSRP1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRollbackSRP;
        private Janus.Windows.UI.CommandBars.UICommand tsGenSRP2;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand tsSubmitSRP2;
        private Janus.Windows.UI.CommandBars.UICommand cmdRollbackSRP2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.CommandBars.UICommand tsActions2;
        private Janus.Windows.UI.CommandBars.UICommand tsActions1;
        private Janus.Windows.UI.CommandBars.UICommand tsActions;
    }
}
