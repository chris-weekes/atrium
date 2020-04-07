 namespace LawMate
{
    partial class ucTaxation
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
                FM.GetIRP().OnUpdate -= new atLogic.UpdateEventHandler(ucTaxation_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTaxation));
            System.Windows.Forms.Label lblFees;
            System.Windows.Forms.Label lblDisbursements;
            System.Windows.Forms.Label disbursementTaxExemptClaimedLabel;
            System.Windows.Forms.Label lblAmounts;
            System.Windows.Forms.Label lblTax;
            System.Windows.Forms.Label officeCodeLabel;
            System.Windows.Forms.Label officerCodeLabel;
            System.Windows.Forms.Label lblTotals;
            System.Windows.Forms.Label totalTaxClaimedLabel;
            System.Windows.Forms.Label fileTotalTaxedLabel;
            System.Windows.Forms.Label percentOfPrincipalLabel;
            System.Windows.Forms.Label taxingDifferenceLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label sRPDateLabel;
            System.Windows.Forms.Label dateTaxedLabel;
            Janus.Windows.GridEX.GridEXLayout iRPGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.panelManager = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.totalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.iRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.totalTaxTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.netTotalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.totalClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.totalTaxClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.netTotalClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.fileTotalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.iRPGridEX = new Janus.Windows.GridEX.GridEX();
            this.percentOfPrincipalNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.btnTaxRecs = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu2 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode2 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle2 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit2 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsEditMode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdViewSRP1 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewSRP");
            this.cmdSRPDetail1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSRPDetail");
            this.cmdViewSRP = new Janus.Windows.UI.CommandBars.UICommand("cmdViewSRP");
            this.cmdSRPDetail = new Janus.Windows.UI.CommandBars.UICommand("cmdSRPDetail");
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdViewSRP2 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewSRP");
            this.cmdSRPDetail2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSRPDetail");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.sRPDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucOfficeSelectBox1 = new LawMate.ucOfficeSelectBox();
            this.btnJumpTo = new Janus.Windows.EditControls.UIButton();
            this.ucContactSelectBox1 = new LawMate.ucContactSelectBox();
            this.taxingDifferenceNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.dateTaxedCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            lblFees = new System.Windows.Forms.Label();
            lblDisbursements = new System.Windows.Forms.Label();
            disbursementTaxExemptClaimedLabel = new System.Windows.Forms.Label();
            lblAmounts = new System.Windows.Forms.Label();
            lblTax = new System.Windows.Forms.Label();
            officeCodeLabel = new System.Windows.Forms.Label();
            officerCodeLabel = new System.Windows.Forms.Label();
            lblTotals = new System.Windows.Forms.Label();
            totalTaxClaimedLabel = new System.Windows.Forms.Label();
            fileTotalTaxedLabel = new System.Windows.Forms.Label();
            percentOfPrincipalLabel = new System.Windows.Forms.Label();
            taxingDifferenceLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            sRPDateLabel = new System.Windows.Forms.Label();
            dateTaxedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRPGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.iRPBindingSource;
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
            // 
            // lblFees
            // 
            resources.ApplyResources(lblFees, "lblFees");
            lblFees.BackColor = System.Drawing.Color.Transparent;
            lblFees.Name = "lblFees";
            this.helpProvider1.SetShowHelp(lblFees, ((bool)(resources.GetObject("lblFees.ShowHelp"))));
            // 
            // lblDisbursements
            // 
            resources.ApplyResources(lblDisbursements, "lblDisbursements");
            lblDisbursements.BackColor = System.Drawing.Color.Transparent;
            lblDisbursements.Name = "lblDisbursements";
            this.helpProvider1.SetShowHelp(lblDisbursements, ((bool)(resources.GetObject("lblDisbursements.ShowHelp"))));
            // 
            // disbursementTaxExemptClaimedLabel
            // 
            resources.ApplyResources(disbursementTaxExemptClaimedLabel, "disbursementTaxExemptClaimedLabel");
            disbursementTaxExemptClaimedLabel.BackColor = System.Drawing.Color.Transparent;
            disbursementTaxExemptClaimedLabel.Name = "disbursementTaxExemptClaimedLabel";
            this.helpProvider1.SetShowHelp(disbursementTaxExemptClaimedLabel, ((bool)(resources.GetObject("disbursementTaxExemptClaimedLabel.ShowHelp"))));
            // 
            // lblAmounts
            // 
            resources.ApplyResources(lblAmounts, "lblAmounts");
            lblAmounts.BackColor = System.Drawing.Color.Transparent;
            lblAmounts.Name = "lblAmounts";
            this.helpProvider1.SetShowHelp(lblAmounts, ((bool)(resources.GetObject("lblAmounts.ShowHelp"))));
            // 
            // lblTax
            // 
            resources.ApplyResources(lblTax, "lblTax");
            lblTax.BackColor = System.Drawing.Color.Transparent;
            lblTax.Name = "lblTax";
            this.helpProvider1.SetShowHelp(lblTax, ((bool)(resources.GetObject("lblTax.ShowHelp"))));
            // 
            // officeCodeLabel
            // 
            resources.ApplyResources(officeCodeLabel, "officeCodeLabel");
            officeCodeLabel.BackColor = System.Drawing.Color.Transparent;
            officeCodeLabel.Name = "officeCodeLabel";
            this.helpProvider1.SetShowHelp(officeCodeLabel, ((bool)(resources.GetObject("officeCodeLabel.ShowHelp"))));
            // 
            // officerCodeLabel
            // 
            resources.ApplyResources(officerCodeLabel, "officerCodeLabel");
            officerCodeLabel.BackColor = System.Drawing.Color.Transparent;
            officerCodeLabel.Name = "officerCodeLabel";
            this.helpProvider1.SetShowHelp(officerCodeLabel, ((bool)(resources.GetObject("officerCodeLabel.ShowHelp"))));
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
            // fileTotalTaxedLabel
            // 
            resources.ApplyResources(fileTotalTaxedLabel, "fileTotalTaxedLabel");
            fileTotalTaxedLabel.BackColor = System.Drawing.Color.Transparent;
            fileTotalTaxedLabel.Name = "fileTotalTaxedLabel";
            this.helpProvider1.SetShowHelp(fileTotalTaxedLabel, ((bool)(resources.GetObject("fileTotalTaxedLabel.ShowHelp"))));
            // 
            // percentOfPrincipalLabel
            // 
            resources.ApplyResources(percentOfPrincipalLabel, "percentOfPrincipalLabel");
            percentOfPrincipalLabel.BackColor = System.Drawing.Color.Transparent;
            percentOfPrincipalLabel.Name = "percentOfPrincipalLabel";
            this.helpProvider1.SetShowHelp(percentOfPrincipalLabel, ((bool)(resources.GetObject("percentOfPrincipalLabel.ShowHelp"))));
            // 
            // taxingDifferenceLabel
            // 
            resources.ApplyResources(taxingDifferenceLabel, "taxingDifferenceLabel");
            taxingDifferenceLabel.BackColor = System.Drawing.Color.Transparent;
            taxingDifferenceLabel.Name = "taxingDifferenceLabel";
            this.helpProvider1.SetShowHelp(taxingDifferenceLabel, ((bool)(resources.GetObject("taxingDifferenceLabel.ShowHelp"))));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            this.helpProvider1.SetShowHelp(label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
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
            // sRPDateLabel
            // 
            resources.ApplyResources(sRPDateLabel, "sRPDateLabel");
            sRPDateLabel.BackColor = System.Drawing.Color.Transparent;
            sRPDateLabel.Name = "sRPDateLabel";
            this.helpProvider1.SetShowHelp(sRPDateLabel, ((bool)(resources.GetObject("sRPDateLabel.ShowHelp"))));
            // 
            // dateTaxedLabel
            // 
            resources.ApplyResources(dateTaxedLabel, "dateTaxedLabel");
            dateTaxedLabel.BackColor = System.Drawing.Color.Transparent;
            dateTaxedLabel.Name = "dateTaxedLabel";
            this.helpProvider1.SetShowHelp(dateTaxedLabel, ((bool)(resources.GetObject("dateTaxedLabel.ShowHelp"))));
            // 
            // panelManager
            // 
            this.panelManager.AllowPanelDrag = false;
            this.panelManager.AllowPanelDrop = false;
            this.panelManager.ContainerControl = this;
            this.panelManager.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.panelManager.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("panelManager.DefaultPanelSettings.BorderCaption")));
            this.panelManager.DefaultPanelSettings.BorderPanel = false;
            this.panelManager.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.panelManager.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("panelManager.DefaultPanelSettings.CaptionVisible")));
            this.panelManager.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("panelManager.DefaultPanelSettings.CloseButtonVisible")));
            this.panelManager.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.panelManager.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelManager.PanelPadding.Bottom = ((int)(resources.GetObject("panelManager.PanelPadding.Bottom")));
            this.panelManager.PanelPadding.Left = ((int)(resources.GetObject("panelManager.PanelPadding.Left")));
            this.panelManager.PanelPadding.Right = ((int)(resources.GetObject("panelManager.PanelPadding.Right")));
            this.panelManager.PanelPadding.Top = ((int)(resources.GetObject("panelManager.PanelPadding.Top")));
            this.panelManager.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.panelManager.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.panelManager.BeginPanelInfo();
            this.panelManager.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(738, 568), true);
            this.panelManager.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.panelManager.EndPanelInfo();
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
            this.pnlAllContainer.Controls.Add(this.uiTab2);
            this.pnlAllContainer.Controls.Add(this.uiTab1);
            this.pnlAllContainer.Controls.Add(this.fileTotalTaxedNumericEditBox);
            this.pnlAllContainer.Controls.Add(this.iRPGridEX);
            this.pnlAllContainer.Controls.Add(this.percentOfPrincipalNumericEditBox);
            this.pnlAllContainer.Controls.Add(fileTotalTaxedLabel);
            this.pnlAllContainer.Controls.Add(percentOfPrincipalLabel);
            this.pnlAllContainer.Controls.Add(this.uiTab3);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
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
            this.uiTabPage2.Controls.Add(this.totalTaxTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label16);
            this.uiTabPage2.Controls.Add(this.netTotalTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label15);
            this.uiTabPage2.Controls.Add(this.disbursementTaxedTaxNumericEditBox);
            this.uiTabPage2.Controls.Add(this.disbursementTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(this.disbursementTaxExemptTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(this.feesTaxedTaxNumericEditBox);
            this.uiTabPage2.Controls.Add(this.feesTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label9);
            this.uiTabPage2.Controls.Add(label12);
            this.uiTabPage2.Controls.Add(label11);
            this.uiTabPage2.Controls.Add(label14);
            this.uiTabPage2.Controls.Add(label13);
            this.uiTabPage2.Controls.Add(label10);
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            // 
            // totalTaxedNumericEditBox
            // 
            this.totalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalTaxed", true));
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
            // iRPBindingSource
            // 
            this.iRPBindingSource.DataMember = "IRP";
            this.iRPBindingSource.DataSource = this.atriumDB;
            this.iRPBindingSource.CurrentChanged += new System.EventHandler(this.iRPBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // totalTaxTaxedNumericEditBox
            // 
            this.totalTaxTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalTaxTaxed", true));
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
            this.netTotalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "NetTotalTaxed", true));
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
            this.disbursementTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxedTax", true));
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
            this.disbursementTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxed", true));
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
            this.disbursementTaxExemptTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxExemptTaxed", true));
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
            this.feesTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesTaxedTax", true));
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
            // feesTaxedNumericEditBox
            // 
            this.feesTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesTaxed", true));
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
            this.uiTabPage1.Controls.Add(this.feesClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(this.totalTaxClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(totalTaxClaimedLabel);
            this.uiTabPage1.Controls.Add(this.netTotalClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(lblTotals);
            this.uiTabPage1.Controls.Add(this.disbursementTaxExemptClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(lblDisbursements);
            this.uiTabPage1.Controls.Add(this.disbursementClaimedTaxNumericEditBox);
            this.uiTabPage1.Controls.Add(disbursementTaxExemptClaimedLabel);
            this.uiTabPage1.Controls.Add(this.disbursementClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(lblAmounts);
            this.uiTabPage1.Controls.Add(this.feesClaimedTaxNumericEditBox);
            this.uiTabPage1.Controls.Add(lblTax);
            this.uiTabPage1.Controls.Add(lblFees);
            this.uiTabPage1.Controls.Add(label8);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // totalClaimedNumericEditBox
            // 
            this.totalClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalClaimed", true));
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
            // feesClaimedNumericEditBox
            // 
            this.feesClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesClaimed", true));
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
            // totalTaxClaimedNumericEditBox
            // 
            this.totalTaxClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalTaxClaimed", true));
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
            this.netTotalClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "NetTotalClaimed", true));
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
            // disbursementTaxExemptClaimedNumericEditBox
            // 
            this.disbursementTaxExemptClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxExemptClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxExemptClaimed", true));
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
            // disbursementClaimedTaxNumericEditBox
            // 
            this.disbursementClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementClaimedTax", true));
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
            this.disbursementClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementClaimed", true));
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
            // feesClaimedTaxNumericEditBox
            // 
            this.feesClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesClaimedTax", true));
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
            // fileTotalTaxedNumericEditBox
            // 
            resources.ApplyResources(this.fileTotalTaxedNumericEditBox, "fileTotalTaxedNumericEditBox");
            this.fileTotalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.fileTotalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iRPBindingSource, "FileTotalTaxed", true));
            this.fileTotalTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
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
            // iRPGridEX
            // 
            this.iRPGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.iRPGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            resources.ApplyResources(this.iRPGridEX, "iRPGridEX");
            this.iRPGridEX.DataSource = this.iRPBindingSource;
            resources.ApplyResources(iRPGridEX_DesignTimeLayout, "iRPGridEX_DesignTimeLayout");
            this.iRPGridEX.DesignTimeLayout = iRPGridEX_DesignTimeLayout;
            this.iRPGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.iRPGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.iRPGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.iRPGridEX.GroupByBoxVisible = false;
            this.iRPGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.iRPGridEX.Name = "iRPGridEX";
            this.helpProvider1.SetShowHelp(this.iRPGridEX, ((bool)(resources.GetObject("iRPGridEX.ShowHelp"))));
            this.iRPGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.iRPGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.iRPGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.iRPGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.iRPGridEX_FormattingRow);
            // 
            // percentOfPrincipalNumericEditBox
            // 
            resources.ApplyResources(this.percentOfPrincipalNumericEditBox, "percentOfPrincipalNumericEditBox");
            this.percentOfPrincipalNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.percentOfPrincipalNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iRPBindingSource, "PercentOfPrincipal", true));
            this.percentOfPrincipalNumericEditBox.DecimalDigits = 2;
            this.percentOfPrincipalNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent;
            this.percentOfPrincipalNumericEditBox.Name = "percentOfPrincipalNumericEditBox";
            this.percentOfPrincipalNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.percentOfPrincipalNumericEditBox, ((bool)(resources.GetObject("percentOfPrincipalNumericEditBox.ShowHelp"))));
            this.percentOfPrincipalNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.percentOfPrincipalNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
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
            this.uiTabPage3.Controls.Add(this.btnTaxRecs);
            this.uiTabPage3.Controls.Add(this.sRPDateCalendarCombo);
            this.uiTabPage3.Controls.Add(this.ucOfficeSelectBox1);
            this.uiTabPage3.Controls.Add(this.btnJumpTo);
            this.uiTabPage3.Controls.Add(this.ucContactSelectBox1);
            this.uiTabPage3.Controls.Add(this.taxingDifferenceNumericEditBox);
            this.uiTabPage3.Controls.Add(this.dateTaxedCalendarCombo);
            this.uiTabPage3.Controls.Add(officeCodeLabel);
            this.uiTabPage3.Controls.Add(officerCodeLabel);
            this.uiTabPage3.Controls.Add(taxingDifferenceLabel);
            this.uiTabPage3.Controls.Add(sRPDateLabel);
            this.uiTabPage3.Controls.Add(dateTaxedLabel);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // btnTaxRecs
            // 
            this.btnTaxRecs.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.btnTaxRecs.DropDownContextMenu = this.uiContextMenu2;
            resources.ApplyResources(this.btnTaxRecs, "btnTaxRecs");
            this.btnTaxRecs.Name = "btnTaxRecs";
            this.helpProvider1.SetShowHelp(this.btnTaxRecs, ((bool)(resources.GetObject("btnTaxRecs.ShowHelp"))));
            this.btnTaxRecs.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
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
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar3});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditMode,
            this.tsScreenTitle,
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit,
            this.cmdView,
            this.cmdViewSRP,
            this.cmdSRPDetail});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1,
            this.uiContextMenu2});
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
            this.cmdEdit1,
            this.cmdView1});
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
            // uiCommandBar3
            // 
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode2,
            this.tsScreenTitle2,
            this.Separator3,
            this.Separator4,
            this.tsAudit2});
            this.uiCommandBar3.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.FullRow = true;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            // 
            // tsEditmode2
            // 
            resources.ApplyResources(this.tsEditmode2, "tsEditmode2");
            this.tsEditmode2.Name = "tsEditmode2";
            // 
            // tsScreenTitle2
            // 
            this.tsScreenTitle2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsScreenTitle2.ControlWidth = 100;
            resources.ApplyResources(this.tsScreenTitle2, "tsScreenTitle2");
            this.tsScreenTitle2.Name = "tsScreenTitle2";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsAudit2
            // 
            resources.ApplyResources(this.tsAudit2, "tsAudit2");
            this.tsAudit2.Name = "tsAudit2";
            // 
            // tsEditMode
            // 
            this.tsEditMode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditMode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditMode, "tsEditMode");
            this.tsEditMode.Name = "tsEditMode";
            this.tsEditMode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditMode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditMode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditMode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
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
            // cmdFile
            // 
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdEdit
            // 
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdViewSRP1,
            this.cmdSRPDetail1});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.Name = "cmdView";
            // 
            // cmdViewSRP1
            // 
            resources.ApplyResources(this.cmdViewSRP1, "cmdViewSRP1");
            this.cmdViewSRP1.Name = "cmdViewSRP1";
            // 
            // cmdSRPDetail1
            // 
            resources.ApplyResources(this.cmdSRPDetail1, "cmdSRPDetail1");
            this.cmdSRPDetail1.Name = "cmdSRPDetail1";
            // 
            // cmdViewSRP
            // 
            resources.ApplyResources(this.cmdViewSRP, "cmdViewSRP");
            this.cmdViewSRP.Name = "cmdViewSRP";
            // 
            // cmdSRPDetail
            // 
            resources.ApplyResources(this.cmdSRPDetail, "cmdSRPDetail");
            this.cmdSRPDetail.Name = "cmdSRPDetail";
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdViewSRP2,
            this.cmdSRPDetail2});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // cmdViewSRP2
            // 
            resources.ApplyResources(this.cmdViewSRP2, "cmdViewSRP2");
            this.cmdViewSRP2.Name = "cmdViewSRP2";
            // 
            // cmdSRPDetail2
            // 
            resources.ApplyResources(this.cmdSRPDetail2, "cmdSRPDetail2");
            this.cmdSRPDetail2.Name = "cmdSRPDetail2";
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
            // sRPDateCalendarCombo
            // 
            this.sRPDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.sRPDateCalendarCombo, "sRPDateCalendarCombo");
            this.sRPDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.iRPBindingSource, "SRPDate", true));
            this.sRPDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.sRPDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.sRPDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPDateCalendarCombo.MonthIncrement = 0;
            this.sRPDateCalendarCombo.Name = "sRPDateCalendarCombo";
            this.sRPDateCalendarCombo.Nullable = true;
            this.sRPDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sRPDateCalendarCombo, ((bool)(resources.GetObject("sRPDateCalendarCombo.ShowHelp"))));
            this.sRPDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPDateCalendarCombo.YearIncrement = 0;
            // 
            // ucOfficeSelectBox1
            // 
            this.ucOfficeSelectBox1.AtMng = null;
            this.ucOfficeSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucOfficeSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.iRPBindingSource, "OfficeID", true));
            resources.ApplyResources(this.ucOfficeSelectBox1, "ucOfficeSelectBox1");
            this.ucOfficeSelectBox1.Name = "ucOfficeSelectBox1";
            this.ucOfficeSelectBox1.OfficeId = null;
            this.ucOfficeSelectBox1.ReadOnly = true;
            this.ucOfficeSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucOfficeSelectBox1, ((bool)(resources.GetObject("ucOfficeSelectBox1.ShowHelp"))));
            // 
            // btnJumpTo
            // 
            this.btnJumpTo.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.btnJumpTo.DropDownContextMenu = this.uiContextMenu1;
            resources.ApplyResources(this.btnJumpTo, "btnJumpTo");
            this.btnJumpTo.Name = "btnJumpTo";
            this.helpProvider1.SetShowHelp(this.btnJumpTo, ((bool)(resources.GetObject("btnJumpTo.ShowHelp"))));
            this.btnJumpTo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // ucContactSelectBox1
            // 
            this.ucContactSelectBox1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucContactSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox1.ContactId = null;
            this.ucContactSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.iRPBindingSource, "OfficerID", true));
            this.ucContactSelectBox1.FM = null;
            resources.ApplyResources(this.ucContactSelectBox1, "ucContactSelectBox1");
            this.ucContactSelectBox1.Name = "ucContactSelectBox1";
            this.ucContactSelectBox1.ReadOnly = true;
            this.ucContactSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucContactSelectBox1, ((bool)(resources.GetObject("ucContactSelectBox1.ShowHelp"))));
            this.ucContactSelectBox1.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // taxingDifferenceNumericEditBox
            // 
            this.taxingDifferenceNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.taxingDifferenceNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TaxingDifference", true));
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
            // dateTaxedCalendarCombo
            // 
            this.dateTaxedCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dateTaxedCalendarCombo, "dateTaxedCalendarCombo");
            this.dateTaxedCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.iRPBindingSource, "DateTaxed", true));
            this.dateTaxedCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.dateTaxedCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.dateTaxedCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateTaxedCalendarCombo.MonthIncrement = 0;
            this.dateTaxedCalendarCombo.Name = "dateTaxedCalendarCombo";
            this.dateTaxedCalendarCombo.Nullable = true;
            this.dateTaxedCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.dateTaxedCalendarCombo, ((bool)(resources.GetObject("dateTaxedCalendarCombo.ShowHelp"))));
            this.dateTaxedCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateTaxedCalendarCombo.YearIncrement = 0;
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // ucTaxation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucTaxation";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.ucTaxation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage2.ResumeLayout(false);
            this.uiTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRPGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager panelManager;
        private Janus.Windows.GridEX.GridEX iRPGridEX;
        private System.Windows.Forms.BindingSource iRPBindingSource;
        private Janus.Windows.GridEX.EditControls.NumericEditBox percentOfPrincipalNumericEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo dateTaxedCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo sRPDateCalendarCombo;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.GridEX.EditControls.NumericEditBox fileTotalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox taxingDifferenceNumericEditBox;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private lmDatasets.atriumDB atriumDB;
        private ucContactSelectBox ucContactSelectBox1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle2;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private ucOfficeSelectBox ucOfficeSelectBox1;
        private Janus.Windows.EditControls.UIButton btnJumpTo;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewSRP1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSRPDetail1;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewSRP;
        private Janus.Windows.UI.CommandBars.UICommand cmdSRPDetail;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewSRP2;
        private Janus.Windows.UI.CommandBars.UICommand cmdSRPDetail2;
        private Janus.Windows.EditControls.UIButton btnTaxRecs;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu2;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
     
    }
}
