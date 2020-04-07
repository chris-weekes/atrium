 namespace LawMate
{
    partial class ucBankruptcy
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
                FM.GetCLASMng().DB.Bankruptcy.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.GetCLASMng().GetBankruptcy().OnUpdate -= new atLogic.UpdateEventHandler(ucBankruptcy_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBankruptcy));
            System.Windows.Forms.Label bankruptcyDateLabel;
            System.Windows.Forms.Label provenClaimAmountLabel;
            System.Windows.Forms.Label dateofOrderLabel;
            System.Windows.Forms.Label cSLEligibleForDischargeDateLabel;
            System.Windows.Forms.Label bankruptcyOrderTypeLabel;
            System.Windows.Forms.Label conditionalOrderAmountLabel;
            System.Windows.Forms.Label judgmentAssignedtoCrownDateLabel;
            System.Windows.Forms.Label dateofTrusteeDischargeLabel;
            System.Windows.Forms.Label debtorDischargeNonCSLDebtDateLabel;
            System.Windows.Forms.Label proofOfClaimFiledDateLabel;
            System.Windows.Forms.Label officeCodeLabel;
            System.Windows.Forms.Label ceasedToBeStudentDateLabel;
            System.Windows.Forms.Label label1;
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab4 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage4 = new Janus.Windows.UI.Tab.UITabPage();
            this.ceasedToBeStudentDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.bankruptcyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CLAS = new lmDatasets.CLAS();
            this.cSLNonDischargeableUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.stayOfProceedingUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.debtorDischargeNonCSLDebtDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dateofTrusteeDischargeCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cSLEligibleForDischargeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.judgmentinFavourofCrownUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.judgmentObtainedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.judgmentAssignedtoCrownDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.signingJudgmentATermUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.bankruptcyOrderTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.conditionalOrderFufilledUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.conditionalOrderAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.dateofOrderCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.mccInsolvencyPeriod = new LawMate.UserControls.ucMultiDropDown();
            this.provenClaimAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.officeIDucOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.bankruptcyDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.proofOfClaimFiledDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
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
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            bankruptcyDateLabel = new System.Windows.Forms.Label();
            provenClaimAmountLabel = new System.Windows.Forms.Label();
            dateofOrderLabel = new System.Windows.Forms.Label();
            cSLEligibleForDischargeDateLabel = new System.Windows.Forms.Label();
            bankruptcyOrderTypeLabel = new System.Windows.Forms.Label();
            conditionalOrderAmountLabel = new System.Windows.Forms.Label();
            judgmentAssignedtoCrownDateLabel = new System.Windows.Forms.Label();
            dateofTrusteeDischargeLabel = new System.Windows.Forms.Label();
            debtorDischargeNonCSLDebtDateLabel = new System.Windows.Forms.Label();
            proofOfClaimFiledDateLabel = new System.Windows.Forms.Label();
            officeCodeLabel = new System.Windows.Forms.Label();
            ceasedToBeStudentDateLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab4)).BeginInit();
            this.uiTab4.SuspendLayout();
            this.uiTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankruptcyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
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
            this.errorProvider1.DataSource = this.bankruptcyBindingSource;
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
            // bankruptcyDateLabel
            // 
            resources.ApplyResources(bankruptcyDateLabel, "bankruptcyDateLabel");
            bankruptcyDateLabel.BackColor = System.Drawing.Color.Transparent;
            bankruptcyDateLabel.Name = "bankruptcyDateLabel";
            this.helpProvider1.SetShowHelp(bankruptcyDateLabel, ((bool)(resources.GetObject("bankruptcyDateLabel.ShowHelp"))));
            // 
            // provenClaimAmountLabel
            // 
            resources.ApplyResources(provenClaimAmountLabel, "provenClaimAmountLabel");
            provenClaimAmountLabel.BackColor = System.Drawing.Color.Transparent;
            provenClaimAmountLabel.Name = "provenClaimAmountLabel";
            this.helpProvider1.SetShowHelp(provenClaimAmountLabel, ((bool)(resources.GetObject("provenClaimAmountLabel.ShowHelp"))));
            // 
            // dateofOrderLabel
            // 
            resources.ApplyResources(dateofOrderLabel, "dateofOrderLabel");
            dateofOrderLabel.BackColor = System.Drawing.Color.Transparent;
            dateofOrderLabel.Name = "dateofOrderLabel";
            this.helpProvider1.SetShowHelp(dateofOrderLabel, ((bool)(resources.GetObject("dateofOrderLabel.ShowHelp"))));
            // 
            // cSLEligibleForDischargeDateLabel
            // 
            resources.ApplyResources(cSLEligibleForDischargeDateLabel, "cSLEligibleForDischargeDateLabel");
            cSLEligibleForDischargeDateLabel.BackColor = System.Drawing.Color.Transparent;
            cSLEligibleForDischargeDateLabel.Name = "cSLEligibleForDischargeDateLabel";
            this.helpProvider1.SetShowHelp(cSLEligibleForDischargeDateLabel, ((bool)(resources.GetObject("cSLEligibleForDischargeDateLabel.ShowHelp"))));
            // 
            // bankruptcyOrderTypeLabel
            // 
            resources.ApplyResources(bankruptcyOrderTypeLabel, "bankruptcyOrderTypeLabel");
            bankruptcyOrderTypeLabel.BackColor = System.Drawing.Color.Transparent;
            bankruptcyOrderTypeLabel.Name = "bankruptcyOrderTypeLabel";
            this.helpProvider1.SetShowHelp(bankruptcyOrderTypeLabel, ((bool)(resources.GetObject("bankruptcyOrderTypeLabel.ShowHelp"))));
            // 
            // conditionalOrderAmountLabel
            // 
            resources.ApplyResources(conditionalOrderAmountLabel, "conditionalOrderAmountLabel");
            conditionalOrderAmountLabel.BackColor = System.Drawing.Color.Transparent;
            conditionalOrderAmountLabel.Name = "conditionalOrderAmountLabel";
            this.helpProvider1.SetShowHelp(conditionalOrderAmountLabel, ((bool)(resources.GetObject("conditionalOrderAmountLabel.ShowHelp"))));
            // 
            // judgmentAssignedtoCrownDateLabel
            // 
            resources.ApplyResources(judgmentAssignedtoCrownDateLabel, "judgmentAssignedtoCrownDateLabel");
            judgmentAssignedtoCrownDateLabel.BackColor = System.Drawing.Color.Transparent;
            judgmentAssignedtoCrownDateLabel.Name = "judgmentAssignedtoCrownDateLabel";
            this.helpProvider1.SetShowHelp(judgmentAssignedtoCrownDateLabel, ((bool)(resources.GetObject("judgmentAssignedtoCrownDateLabel.ShowHelp"))));
            // 
            // dateofTrusteeDischargeLabel
            // 
            resources.ApplyResources(dateofTrusteeDischargeLabel, "dateofTrusteeDischargeLabel");
            dateofTrusteeDischargeLabel.BackColor = System.Drawing.Color.Transparent;
            dateofTrusteeDischargeLabel.Name = "dateofTrusteeDischargeLabel";
            this.helpProvider1.SetShowHelp(dateofTrusteeDischargeLabel, ((bool)(resources.GetObject("dateofTrusteeDischargeLabel.ShowHelp"))));
            // 
            // debtorDischargeNonCSLDebtDateLabel
            // 
            resources.ApplyResources(debtorDischargeNonCSLDebtDateLabel, "debtorDischargeNonCSLDebtDateLabel");
            debtorDischargeNonCSLDebtDateLabel.BackColor = System.Drawing.Color.Transparent;
            debtorDischargeNonCSLDebtDateLabel.Name = "debtorDischargeNonCSLDebtDateLabel";
            this.helpProvider1.SetShowHelp(debtorDischargeNonCSLDebtDateLabel, ((bool)(resources.GetObject("debtorDischargeNonCSLDebtDateLabel.ShowHelp"))));
            // 
            // proofOfClaimFiledDateLabel
            // 
            resources.ApplyResources(proofOfClaimFiledDateLabel, "proofOfClaimFiledDateLabel");
            proofOfClaimFiledDateLabel.BackColor = System.Drawing.Color.Transparent;
            proofOfClaimFiledDateLabel.Name = "proofOfClaimFiledDateLabel";
            this.helpProvider1.SetShowHelp(proofOfClaimFiledDateLabel, ((bool)(resources.GetObject("proofOfClaimFiledDateLabel.ShowHelp"))));
            // 
            // officeCodeLabel
            // 
            resources.ApplyResources(officeCodeLabel, "officeCodeLabel");
            officeCodeLabel.BackColor = System.Drawing.Color.Transparent;
            officeCodeLabel.Name = "officeCodeLabel";
            this.helpProvider1.SetShowHelp(officeCodeLabel, ((bool)(resources.GetObject("officeCodeLabel.ShowHelp"))));
            // 
            // ceasedToBeStudentDateLabel
            // 
            resources.ApplyResources(ceasedToBeStudentDateLabel, "ceasedToBeStudentDateLabel");
            ceasedToBeStudentDateLabel.BackColor = System.Drawing.Color.Transparent;
            ceasedToBeStudentDateLabel.Name = "ceasedToBeStudentDateLabel";
            this.helpProvider1.SetShowHelp(ceasedToBeStudentDateLabel, ((bool)(resources.GetObject("ceasedToBeStudentDateLabel.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(821, 516), true);
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
            this.pnlAllContainer.Controls.Add(this.uiTab4);
            this.pnlAllContainer.Controls.Add(this.uiTab3);
            this.pnlAllContainer.Controls.Add(this.uiTab2);
            this.pnlAllContainer.Controls.Add(this.uiTab1);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // uiTab4
            // 
            resources.ApplyResources(this.uiTab4, "uiTab4");
            this.uiTab4.BackColor = System.Drawing.Color.Transparent;
            this.uiTab4.Name = "uiTab4";
            this.uiTab4.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab4.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab4, ((bool)(resources.GetObject("uiTab4.ShowHelp"))));
            this.uiTab4.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage4});
            this.uiTab4.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab4.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab4.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab4.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab4.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab4.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab4.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab4.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab4.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage4
            // 
            this.uiTabPage4.Controls.Add(this.ceasedToBeStudentDateCalendarCombo);
            this.uiTabPage4.Controls.Add(this.cSLNonDischargeableUICheckBox);
            this.uiTabPage4.Controls.Add(ceasedToBeStudentDateLabel);
            this.uiTabPage4.Controls.Add(this.stayOfProceedingUICheckBox);
            this.uiTabPage4.Controls.Add(this.debtorDischargeNonCSLDebtDateCalendarCombo);
            this.uiTabPage4.Controls.Add(debtorDischargeNonCSLDebtDateLabel);
            this.uiTabPage4.Controls.Add(this.dateofTrusteeDischargeCalendarCombo);
            this.uiTabPage4.Controls.Add(cSLEligibleForDischargeDateLabel);
            this.uiTabPage4.Controls.Add(dateofTrusteeDischargeLabel);
            this.uiTabPage4.Controls.Add(this.cSLEligibleForDischargeDateCalendarCombo);
            resources.ApplyResources(this.uiTabPage4, "uiTabPage4");
            this.uiTabPage4.Name = "uiTabPage4";
            this.helpProvider1.SetShowHelp(this.uiTabPage4, ((bool)(resources.GetObject("uiTabPage4.ShowHelp"))));
            this.uiTabPage4.TabStop = true;
            // 
            // ceasedToBeStudentDateCalendarCombo
            // 
            this.ceasedToBeStudentDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ceasedToBeStudentDateCalendarCombo, "ceasedToBeStudentDateCalendarCombo");
            this.ceasedToBeStudentDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "CeasedToBeStudentDate", true));
            this.ceasedToBeStudentDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.ceasedToBeStudentDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.ceasedToBeStudentDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.ceasedToBeStudentDateCalendarCombo.MonthIncrement = 0;
            this.ceasedToBeStudentDateCalendarCombo.Name = "ceasedToBeStudentDateCalendarCombo";
            this.ceasedToBeStudentDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.ceasedToBeStudentDateCalendarCombo, ((bool)(resources.GetObject("ceasedToBeStudentDateCalendarCombo.ShowHelp"))));
            this.ceasedToBeStudentDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.ceasedToBeStudentDateCalendarCombo.YearIncrement = 0;
            this.ceasedToBeStudentDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
            // 
            // bankruptcyBindingSource
            // 
            this.bankruptcyBindingSource.DataMember = "Bankruptcy";
            this.bankruptcyBindingSource.DataSource = this.CLAS;
            this.bankruptcyBindingSource.CurrentChanged += new System.EventHandler(this.bankruptcyBindingSource_CurrentChanged);
            // 
            // CLAS
            // 
            this.CLAS.DataSetName = "CLAS";
            this.CLAS.EnforceConstraints = false;
            this.CLAS.Locale = new System.Globalization.CultureInfo("en-CA");
            this.CLAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // cSLNonDischargeableUICheckBox
            // 
            this.cSLNonDischargeableUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.cSLNonDischargeableUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cSLNonDischargeableUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "CSLNonDischargeable", true));
            resources.ApplyResources(this.cSLNonDischargeableUICheckBox, "cSLNonDischargeableUICheckBox");
            this.cSLNonDischargeableUICheckBox.Name = "cSLNonDischargeableUICheckBox";
            this.helpProvider1.SetShowHelp(this.cSLNonDischargeableUICheckBox, ((bool)(resources.GetObject("cSLNonDischargeableUICheckBox.ShowHelp"))));
            this.cSLNonDischargeableUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // stayOfProceedingUICheckBox
            // 
            this.stayOfProceedingUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.stayOfProceedingUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stayOfProceedingUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "StayOfProceeding", true));
            resources.ApplyResources(this.stayOfProceedingUICheckBox, "stayOfProceedingUICheckBox");
            this.stayOfProceedingUICheckBox.Name = "stayOfProceedingUICheckBox";
            this.helpProvider1.SetShowHelp(this.stayOfProceedingUICheckBox, ((bool)(resources.GetObject("stayOfProceedingUICheckBox.ShowHelp"))));
            this.stayOfProceedingUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // debtorDischargeNonCSLDebtDateCalendarCombo
            // 
            resources.ApplyResources(this.debtorDischargeNonCSLDebtDateCalendarCombo, "debtorDischargeNonCSLDebtDateCalendarCombo");
            this.debtorDischargeNonCSLDebtDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "DebtorDischargeNonCSLDebtDate", true));
            this.debtorDischargeNonCSLDebtDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.debtorDischargeNonCSLDebtDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.debtorDischargeNonCSLDebtDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.debtorDischargeNonCSLDebtDateCalendarCombo.MonthIncrement = 0;
            this.debtorDischargeNonCSLDebtDateCalendarCombo.Name = "debtorDischargeNonCSLDebtDateCalendarCombo";
            this.debtorDischargeNonCSLDebtDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.debtorDischargeNonCSLDebtDateCalendarCombo, ((bool)(resources.GetObject("debtorDischargeNonCSLDebtDateCalendarCombo.ShowHelp"))));
            this.debtorDischargeNonCSLDebtDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.debtorDischargeNonCSLDebtDateCalendarCombo.YearIncrement = 0;
            this.debtorDischargeNonCSLDebtDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
            // 
            // dateofTrusteeDischargeCalendarCombo
            // 
            resources.ApplyResources(this.dateofTrusteeDischargeCalendarCombo, "dateofTrusteeDischargeCalendarCombo");
            this.dateofTrusteeDischargeCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "DateofTrusteeDischarge", true));
            this.dateofTrusteeDischargeCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.dateofTrusteeDischargeCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.dateofTrusteeDischargeCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateofTrusteeDischargeCalendarCombo.MonthIncrement = 0;
            this.dateofTrusteeDischargeCalendarCombo.Name = "dateofTrusteeDischargeCalendarCombo";
            this.dateofTrusteeDischargeCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.dateofTrusteeDischargeCalendarCombo, ((bool)(resources.GetObject("dateofTrusteeDischargeCalendarCombo.ShowHelp"))));
            this.dateofTrusteeDischargeCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateofTrusteeDischargeCalendarCombo.YearIncrement = 0;
            this.dateofTrusteeDischargeCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
            // 
            // cSLEligibleForDischargeDateCalendarCombo
            // 
            this.cSLEligibleForDischargeDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.cSLEligibleForDischargeDateCalendarCombo, "cSLEligibleForDischargeDateCalendarCombo");
            this.cSLEligibleForDischargeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "CSLEligibleForDischargeDate", true));
            this.cSLEligibleForDischargeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.cSLEligibleForDischargeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.cSLEligibleForDischargeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.cSLEligibleForDischargeDateCalendarCombo.MonthIncrement = 0;
            this.cSLEligibleForDischargeDateCalendarCombo.Name = "cSLEligibleForDischargeDateCalendarCombo";
            this.cSLEligibleForDischargeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.cSLEligibleForDischargeDateCalendarCombo, ((bool)(resources.GetObject("cSLEligibleForDischargeDateCalendarCombo.ShowHelp"))));
            this.cSLEligibleForDischargeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.cSLEligibleForDischargeDateCalendarCombo.YearIncrement = 0;
            this.cSLEligibleForDischargeDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
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
            this.uiTabPage3.Controls.Add(this.judgmentinFavourofCrownUICheckBox);
            this.uiTabPage3.Controls.Add(this.judgmentObtainedUICheckBox);
            this.uiTabPage3.Controls.Add(this.judgmentAssignedtoCrownDateCalendarCombo);
            this.uiTabPage3.Controls.Add(judgmentAssignedtoCrownDateLabel);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // judgmentinFavourofCrownUICheckBox
            // 
            this.judgmentinFavourofCrownUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.judgmentinFavourofCrownUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.judgmentinFavourofCrownUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "JudgmentinFavourofCrown", true));
            resources.ApplyResources(this.judgmentinFavourofCrownUICheckBox, "judgmentinFavourofCrownUICheckBox");
            this.judgmentinFavourofCrownUICheckBox.Name = "judgmentinFavourofCrownUICheckBox";
            this.helpProvider1.SetShowHelp(this.judgmentinFavourofCrownUICheckBox, ((bool)(resources.GetObject("judgmentinFavourofCrownUICheckBox.ShowHelp"))));
            this.judgmentinFavourofCrownUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // judgmentObtainedUICheckBox
            // 
            this.judgmentObtainedUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.judgmentObtainedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.judgmentObtainedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "JudgmentObtained", true));
            resources.ApplyResources(this.judgmentObtainedUICheckBox, "judgmentObtainedUICheckBox");
            this.judgmentObtainedUICheckBox.Name = "judgmentObtainedUICheckBox";
            this.helpProvider1.SetShowHelp(this.judgmentObtainedUICheckBox, ((bool)(resources.GetObject("judgmentObtainedUICheckBox.ShowHelp"))));
            this.judgmentObtainedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // judgmentAssignedtoCrownDateCalendarCombo
            // 
            resources.ApplyResources(this.judgmentAssignedtoCrownDateCalendarCombo, "judgmentAssignedtoCrownDateCalendarCombo");
            this.judgmentAssignedtoCrownDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "JudgmentAssignedtoCrownDate", true));
            this.judgmentAssignedtoCrownDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.judgmentAssignedtoCrownDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.judgmentAssignedtoCrownDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.judgmentAssignedtoCrownDateCalendarCombo.MonthIncrement = 0;
            this.judgmentAssignedtoCrownDateCalendarCombo.Name = "judgmentAssignedtoCrownDateCalendarCombo";
            this.judgmentAssignedtoCrownDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.judgmentAssignedtoCrownDateCalendarCombo, ((bool)(resources.GetObject("judgmentAssignedtoCrownDateCalendarCombo.ShowHelp"))));
            this.judgmentAssignedtoCrownDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.judgmentAssignedtoCrownDateCalendarCombo.YearIncrement = 0;
            this.judgmentAssignedtoCrownDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
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
            this.uiTabPage2.Controls.Add(this.signingJudgmentATermUICheckBox);
            this.uiTabPage2.Controls.Add(dateofOrderLabel);
            this.uiTabPage2.Controls.Add(this.bankruptcyOrderTypeucMultiDropDown);
            this.uiTabPage2.Controls.Add(conditionalOrderAmountLabel);
            this.uiTabPage2.Controls.Add(this.conditionalOrderFufilledUICheckBox);
            this.uiTabPage2.Controls.Add(bankruptcyOrderTypeLabel);
            this.uiTabPage2.Controls.Add(this.conditionalOrderAmountNumericEditBox);
            this.uiTabPage2.Controls.Add(this.dateofOrderCalendarCombo);
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            // 
            // signingJudgmentATermUICheckBox
            // 
            this.signingJudgmentATermUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.signingJudgmentATermUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.signingJudgmentATermUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "SigningJudgmentATerm", true));
            resources.ApplyResources(this.signingJudgmentATermUICheckBox, "signingJudgmentATermUICheckBox");
            this.signingJudgmentATermUICheckBox.Name = "signingJudgmentATermUICheckBox";
            this.helpProvider1.SetShowHelp(this.signingJudgmentATermUICheckBox, ((bool)(resources.GetObject("signingJudgmentATermUICheckBox.ShowHelp"))));
            this.signingJudgmentATermUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // bankruptcyOrderTypeucMultiDropDown
            // 
            this.bankruptcyOrderTypeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.bankruptcyOrderTypeucMultiDropDown.Column1 = "BankruptcyOrderType";
            resources.ApplyResources(this.bankruptcyOrderTypeucMultiDropDown, "bankruptcyOrderTypeucMultiDropDown");
            this.bankruptcyOrderTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.bankruptcyOrderTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bankruptcyBindingSource, "BankruptcyOrderType", true));
            this.bankruptcyOrderTypeucMultiDropDown.DataSource = null;
            this.bankruptcyOrderTypeucMultiDropDown.DDColumn1Visible = true;
            this.bankruptcyOrderTypeucMultiDropDown.DropDownColumn1Width = 50;
            this.bankruptcyOrderTypeucMultiDropDown.DropDownColumn2Width = 250;
            this.bankruptcyOrderTypeucMultiDropDown.Name = "bankruptcyOrderTypeucMultiDropDown";
            this.bankruptcyOrderTypeucMultiDropDown.ReadOnly = false;
            this.bankruptcyOrderTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.bankruptcyOrderTypeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.bankruptcyOrderTypeucMultiDropDown, ((bool)(resources.GetObject("bankruptcyOrderTypeucMultiDropDown.ShowHelp"))));
            this.bankruptcyOrderTypeucMultiDropDown.ValueMember = "BankruptcyOrderType";
            // 
            // conditionalOrderFufilledUICheckBox
            // 
            this.conditionalOrderFufilledUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.conditionalOrderFufilledUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.conditionalOrderFufilledUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "ConditionalOrderFufilled", true));
            resources.ApplyResources(this.conditionalOrderFufilledUICheckBox, "conditionalOrderFufilledUICheckBox");
            this.conditionalOrderFufilledUICheckBox.Name = "conditionalOrderFufilledUICheckBox";
            this.helpProvider1.SetShowHelp(this.conditionalOrderFufilledUICheckBox, ((bool)(resources.GetObject("conditionalOrderFufilledUICheckBox.ShowHelp"))));
            this.conditionalOrderFufilledUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // conditionalOrderAmountNumericEditBox
            // 
            this.conditionalOrderAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bankruptcyBindingSource, "ConditionalOrderAmount", true));
            this.conditionalOrderAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.conditionalOrderAmountNumericEditBox, "conditionalOrderAmountNumericEditBox");
            this.conditionalOrderAmountNumericEditBox.Name = "conditionalOrderAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.conditionalOrderAmountNumericEditBox, ((bool)(resources.GetObject("conditionalOrderAmountNumericEditBox.ShowHelp"))));
            this.conditionalOrderAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.conditionalOrderAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // dateofOrderCalendarCombo
            // 
            resources.ApplyResources(this.dateofOrderCalendarCombo, "dateofOrderCalendarCombo");
            this.dateofOrderCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "DateofOrder", true));
            this.dateofOrderCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.dateofOrderCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.dateofOrderCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateofOrderCalendarCombo.MonthIncrement = 0;
            this.dateofOrderCalendarCombo.Name = "dateofOrderCalendarCombo";
            this.dateofOrderCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.dateofOrderCalendarCombo, ((bool)(resources.GetObject("dateofOrderCalendarCombo.ShowHelp"))));
            this.dateofOrderCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateofOrderCalendarCombo.YearIncrement = 0;
            this.dateofOrderCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
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
            this.uiTabPage1.Controls.Add(this.mccInsolvencyPeriod);
            this.uiTabPage1.Controls.Add(label1);
            this.uiTabPage1.Controls.Add(this.provenClaimAmountNumericEditBox);
            this.uiTabPage1.Controls.Add(this.officeIDucOfficeSelectBox);
            this.uiTabPage1.Controls.Add(officeCodeLabel);
            this.uiTabPage1.Controls.Add(bankruptcyDateLabel);
            this.uiTabPage1.Controls.Add(provenClaimAmountLabel);
            this.uiTabPage1.Controls.Add(this.bankruptcyDateCalendarCombo);
            this.uiTabPage1.Controls.Add(this.proofOfClaimFiledDateCalendarCombo);
            this.uiTabPage1.Controls.Add(proofOfClaimFiledDateLabel);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // mccInsolvencyPeriod
            // 
            this.mccInsolvencyPeriod.BackColor = System.Drawing.Color.Transparent;
            this.mccInsolvencyPeriod.Column1 = "InsolvencyPeriod";
            resources.ApplyResources(this.mccInsolvencyPeriod, "mccInsolvencyPeriod");
            this.mccInsolvencyPeriod.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.mccInsolvencyPeriod.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bankruptcyBindingSource, "InsolvencyPeriod", true));
            this.mccInsolvencyPeriod.DataSource = null;
            this.mccInsolvencyPeriod.DDColumn1Visible = false;
            this.mccInsolvencyPeriod.DropDownColumn1Width = 40;
            this.mccInsolvencyPeriod.DropDownColumn2Width = 200;
            this.mccInsolvencyPeriod.Name = "mccInsolvencyPeriod";
            this.mccInsolvencyPeriod.ReadOnly = false;
            this.mccInsolvencyPeriod.ReqColor = System.Drawing.SystemColors.Window;
            this.mccInsolvencyPeriod.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccInsolvencyPeriod, ((bool)(resources.GetObject("mccInsolvencyPeriod.ShowHelp"))));
            this.mccInsolvencyPeriod.ValueMember = "InsolvencyPeriod";
            // 
            // provenClaimAmountNumericEditBox
            // 
            this.provenClaimAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bankruptcyBindingSource, "ProvenClaimAmount", true));
            this.provenClaimAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.provenClaimAmountNumericEditBox, "provenClaimAmountNumericEditBox");
            this.provenClaimAmountNumericEditBox.Name = "provenClaimAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.provenClaimAmountNumericEditBox, ((bool)(resources.GetObject("provenClaimAmountNumericEditBox.ShowHelp"))));
            this.provenClaimAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.provenClaimAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeIDucOfficeSelectBox
            // 
            this.officeIDucOfficeSelectBox.AtMng = null;
            this.officeIDucOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIDucOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.bankruptcyBindingSource, "OfficeID", true));
            resources.ApplyResources(this.officeIDucOfficeSelectBox, "officeIDucOfficeSelectBox");
            this.officeIDucOfficeSelectBox.Name = "officeIDucOfficeSelectBox";
            this.officeIDucOfficeSelectBox.OfficeId = null;
            this.officeIDucOfficeSelectBox.ReadOnly = true;
            this.officeIDucOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIDucOfficeSelectBox, ((bool)(resources.GetObject("officeIDucOfficeSelectBox.ShowHelp"))));
            // 
            // bankruptcyDateCalendarCombo
            // 
            resources.ApplyResources(this.bankruptcyDateCalendarCombo, "bankruptcyDateCalendarCombo");
            this.bankruptcyDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "BankruptcyDate", true));
            this.bankruptcyDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.bankruptcyDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.bankruptcyDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bankruptcyDateCalendarCombo.MonthIncrement = 0;
            this.bankruptcyDateCalendarCombo.Name = "bankruptcyDateCalendarCombo";
            this.bankruptcyDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.bankruptcyDateCalendarCombo, ((bool)(resources.GetObject("bankruptcyDateCalendarCombo.ShowHelp"))));
            this.bankruptcyDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bankruptcyDateCalendarCombo.YearIncrement = 0;
            this.bankruptcyDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
            // 
            // proofOfClaimFiledDateCalendarCombo
            // 
            resources.ApplyResources(this.proofOfClaimFiledDateCalendarCombo, "proofOfClaimFiledDateCalendarCombo");
            this.proofOfClaimFiledDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.bankruptcyBindingSource, "ProofOfClaimFiledDate", true));
            this.proofOfClaimFiledDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.proofOfClaimFiledDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.proofOfClaimFiledDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.proofOfClaimFiledDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.proofOfClaimFiledDateCalendarCombo.MonthIncrement = 0;
            this.proofOfClaimFiledDateCalendarCombo.Name = "proofOfClaimFiledDateCalendarCombo";
            this.proofOfClaimFiledDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.proofOfClaimFiledDateCalendarCombo, ((bool)(resources.GetObject("proofOfClaimFiledDateCalendarCombo.ShowHelp"))));
            this.proofOfClaimFiledDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.proofOfClaimFiledDateCalendarCombo.YearIncrement = 0;
            this.proofOfClaimFiledDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bankruptcyDateCalendarCombo_KeyDown);
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
            this.tsEditmode,
            this.tsDelete,
            this.tsSave,
            this.tsScreenTitle,
            this.tsAudit,
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
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
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
            this.tsAudit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
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
            // ucBankruptcy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucBankruptcy";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucBankruptcy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab4)).EndInit();
            this.uiTab4.ResumeLayout(false);
            this.uiTabPage4.ResumeLayout(false);
            this.uiTabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankruptcyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage2.ResumeLayout(false);
            this.uiTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
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
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private System.Windows.Forms.BindingSource bankruptcyBindingSource;
        private lmDatasets.CLAS CLAS;
        private Janus.Windows.CalendarCombo.CalendarCombo bankruptcyDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo dateofOrderCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo cSLEligibleForDischargeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo judgmentAssignedtoCrownDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo dateofTrusteeDischargeCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo debtorDischargeNonCSLDebtDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo proofOfClaimFiledDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo ceasedToBeStudentDateCalendarCombo;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox provenClaimAmountNumericEditBox;
        private ucOfficeSelectBox officeIDucOfficeSelectBox;
        private Janus.Windows.EditControls.UICheckBox judgmentinFavourofCrownUICheckBox;
        private Janus.Windows.EditControls.UICheckBox judgmentObtainedUICheckBox;
        private Janus.Windows.EditControls.UICheckBox signingJudgmentATermUICheckBox;
        private UserControls.ucMultiDropDown bankruptcyOrderTypeucMultiDropDown;
        private Janus.Windows.EditControls.UICheckBox conditionalOrderFufilledUICheckBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox conditionalOrderAmountNumericEditBox;
        private Janus.Windows.EditControls.UICheckBox cSLNonDischargeableUICheckBox;
        private Janus.Windows.EditControls.UICheckBox stayOfProceedingUICheckBox;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.Tab.UITab uiTab4;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage4;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private UserControls.ucMultiDropDown mccInsolvencyPeriod;
    }
}
