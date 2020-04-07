 namespace LawMate
{
    partial class ucLRM
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
                FM.DB.RiskAssessment.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetRiskAssessment().OnUpdate -= new atLogic.UpdateEventHandler(ucLRM_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLRM));
            System.Windows.Forms.Label assessmentDateLabel;
            System.Windows.Forms.Label contingentLiabilityLabel;
            System.Windows.Forms.Label statusLabel;
            System.Windows.Forms.Label settlementEstLabel;
            System.Windows.Forms.Label amountClaimedLabel;
            System.Windows.Forms.Label complexityLabel;
            System.Windows.Forms.Label impactLabel;
            System.Windows.Forms.Label likelihoodLabel;
            System.Windows.Forms.Label riskLevelLabel;
            System.Windows.Forms.Label possibilityOfSettlementLabel;
            System.Windows.Forms.Label assessedByIdLabel1;
            System.Windows.Forms.Label courtNameLabel;
            System.Windows.Forms.Label courtFileNumberLabel;
            System.Windows.Forms.Label statementOfClaimDateLabel;
            System.Windows.Forms.Label contigentLiabilityCommentLabel;
            System.Windows.Forms.Label backgroundDetailLabel;
            System.Windows.Forms.Label statusCommentLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.calendarCombo2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.riskAssessmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.CourtNameCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ContingentLiabilityCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.backgroundDetailTextBox = new System.Windows.Forms.TextBox();
            this.contigentLiabilityCommentTextBox = new System.Windows.Forms.TextBox();
            this.statementOfClaimDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.courtFileNumberTextBox = new System.Windows.Forms.TextBox();
            this.courtNameTextBox = new System.Windows.Forms.TextBox();
            this.subjectToContingentLiabilityCheckBox = new System.Windows.Forms.CheckBox();
            this.ucSettlementPossibilityMcc = new LawMate.UserControls.ucMultiDropDown();
            this.amountClaimedTextBox = new System.Windows.Forms.TextBox();
            this.settlementEstTextBox = new System.Windows.Forms.TextBox();
            this.contingentLiabilityTextBox = new System.Windows.Forms.TextBox();
            this.gbRiskAssessment = new Janus.Windows.EditControls.UIGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ucRiskLevelMcc = new LawMate.UserControls.ucMultiDropDown();
            this.statusCommentTextBox = new System.Windows.Forms.TextBox();
            this.ucLikelihoodMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucAssessedByMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucImpactMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucComplexityMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucRAStatusMcc = new LawMate.UserControls.ucMultiDropDown();
            this.assessmentDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
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
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            assessmentDateLabel = new System.Windows.Forms.Label();
            contingentLiabilityLabel = new System.Windows.Forms.Label();
            statusLabel = new System.Windows.Forms.Label();
            settlementEstLabel = new System.Windows.Forms.Label();
            amountClaimedLabel = new System.Windows.Forms.Label();
            complexityLabel = new System.Windows.Forms.Label();
            impactLabel = new System.Windows.Forms.Label();
            likelihoodLabel = new System.Windows.Forms.Label();
            riskLevelLabel = new System.Windows.Forms.Label();
            possibilityOfSettlementLabel = new System.Windows.Forms.Label();
            assessedByIdLabel1 = new System.Windows.Forms.Label();
            courtNameLabel = new System.Windows.Forms.Label();
            courtFileNumberLabel = new System.Windows.Forms.Label();
            statementOfClaimDateLabel = new System.Windows.Forms.Label();
            contigentLiabilityCommentLabel = new System.Windows.Forms.Label();
            backgroundDetailLabel = new System.Windows.Forms.Label();
            statusCommentLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.riskAssessmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRiskAssessment)).BeginInit();
            this.gbRiskAssessment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.errorProvider1.DataSource = this.riskAssessmentBindingSource;
            // 
            // imageListBase
            // 
            this.imageListBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBase.ImageStream")));
            this.imageListBase.Images.SetKeyName(0, "find.gif");
            this.imageListBase.Images.SetKeyName(1, "cancel.gif");
            this.imageListBase.Images.SetKeyName(2, "delete.gif");
            this.imageListBase.Images.SetKeyName(3, "filter.gif");
            this.imageListBase.Images.SetKeyName(4, "shortcut.gif");
            this.imageListBase.Images.SetKeyName(5, "bo.gif");
            this.imageListBase.Images.SetKeyName(6, "browse.gif");
            this.imageListBase.Images.SetKeyName(7, "bs.gif");
            this.imageListBase.Images.SetKeyName(8, "cal.gif");
            this.imageListBase.Images.SetKeyName(9, "drafts.gif");
            this.imageListBase.Images.SetKeyName(10, "help.gif");
            this.imageListBase.Images.SetKeyName(11, "information.gif");
            this.imageListBase.Images.SetKeyName(12, "lang.gif");
            this.imageListBase.Images.SetKeyName(13, "moveFolder.gif");
            this.imageListBase.Images.SetKeyName(14, "msgS.gif");
            this.imageListBase.Images.SetKeyName(15, "newDoc.gif");
            this.imageListBase.Images.SetKeyName(16, "save.gif");
            this.imageListBase.Images.SetKeyName(17, "search.gif");
            this.imageListBase.Images.SetKeyName(18, "audit.gif");
            // 
            // assessmentDateLabel
            // 
            resources.ApplyResources(assessmentDateLabel, "assessmentDateLabel");
            assessmentDateLabel.Name = "assessmentDateLabel";
            this.helpProvider1.SetShowHelp(assessmentDateLabel, ((bool)(resources.GetObject("assessmentDateLabel.ShowHelp"))));
            // 
            // contingentLiabilityLabel
            // 
            resources.ApplyResources(contingentLiabilityLabel, "contingentLiabilityLabel");
            contingentLiabilityLabel.Name = "contingentLiabilityLabel";
            this.helpProvider1.SetShowHelp(contingentLiabilityLabel, ((bool)(resources.GetObject("contingentLiabilityLabel.ShowHelp"))));
            // 
            // statusLabel
            // 
            resources.ApplyResources(statusLabel, "statusLabel");
            statusLabel.Name = "statusLabel";
            this.helpProvider1.SetShowHelp(statusLabel, ((bool)(resources.GetObject("statusLabel.ShowHelp"))));
            // 
            // settlementEstLabel
            // 
            resources.ApplyResources(settlementEstLabel, "settlementEstLabel");
            settlementEstLabel.Name = "settlementEstLabel";
            this.helpProvider1.SetShowHelp(settlementEstLabel, ((bool)(resources.GetObject("settlementEstLabel.ShowHelp"))));
            // 
            // amountClaimedLabel
            // 
            resources.ApplyResources(amountClaimedLabel, "amountClaimedLabel");
            amountClaimedLabel.Name = "amountClaimedLabel";
            this.helpProvider1.SetShowHelp(amountClaimedLabel, ((bool)(resources.GetObject("amountClaimedLabel.ShowHelp"))));
            // 
            // complexityLabel
            // 
            resources.ApplyResources(complexityLabel, "complexityLabel");
            complexityLabel.Name = "complexityLabel";
            this.helpProvider1.SetShowHelp(complexityLabel, ((bool)(resources.GetObject("complexityLabel.ShowHelp"))));
            // 
            // impactLabel
            // 
            resources.ApplyResources(impactLabel, "impactLabel");
            impactLabel.Name = "impactLabel";
            this.helpProvider1.SetShowHelp(impactLabel, ((bool)(resources.GetObject("impactLabel.ShowHelp"))));
            // 
            // likelihoodLabel
            // 
            resources.ApplyResources(likelihoodLabel, "likelihoodLabel");
            likelihoodLabel.Name = "likelihoodLabel";
            this.helpProvider1.SetShowHelp(likelihoodLabel, ((bool)(resources.GetObject("likelihoodLabel.ShowHelp"))));
            // 
            // riskLevelLabel
            // 
            resources.ApplyResources(riskLevelLabel, "riskLevelLabel");
            riskLevelLabel.Name = "riskLevelLabel";
            this.helpProvider1.SetShowHelp(riskLevelLabel, ((bool)(resources.GetObject("riskLevelLabel.ShowHelp"))));
            // 
            // possibilityOfSettlementLabel
            // 
            resources.ApplyResources(possibilityOfSettlementLabel, "possibilityOfSettlementLabel");
            possibilityOfSettlementLabel.Name = "possibilityOfSettlementLabel";
            this.helpProvider1.SetShowHelp(possibilityOfSettlementLabel, ((bool)(resources.GetObject("possibilityOfSettlementLabel.ShowHelp"))));
            // 
            // assessedByIdLabel1
            // 
            resources.ApplyResources(assessedByIdLabel1, "assessedByIdLabel1");
            assessedByIdLabel1.Name = "assessedByIdLabel1";
            this.helpProvider1.SetShowHelp(assessedByIdLabel1, ((bool)(resources.GetObject("assessedByIdLabel1.ShowHelp"))));
            // 
            // courtNameLabel
            // 
            resources.ApplyResources(courtNameLabel, "courtNameLabel");
            courtNameLabel.Name = "courtNameLabel";
            this.helpProvider1.SetShowHelp(courtNameLabel, ((bool)(resources.GetObject("courtNameLabel.ShowHelp"))));
            // 
            // courtFileNumberLabel
            // 
            resources.ApplyResources(courtFileNumberLabel, "courtFileNumberLabel");
            courtFileNumberLabel.Name = "courtFileNumberLabel";
            this.helpProvider1.SetShowHelp(courtFileNumberLabel, ((bool)(resources.GetObject("courtFileNumberLabel.ShowHelp"))));
            // 
            // statementOfClaimDateLabel
            // 
            resources.ApplyResources(statementOfClaimDateLabel, "statementOfClaimDateLabel");
            statementOfClaimDateLabel.Name = "statementOfClaimDateLabel";
            this.helpProvider1.SetShowHelp(statementOfClaimDateLabel, ((bool)(resources.GetObject("statementOfClaimDateLabel.ShowHelp"))));
            // 
            // contigentLiabilityCommentLabel
            // 
            resources.ApplyResources(contigentLiabilityCommentLabel, "contigentLiabilityCommentLabel");
            contigentLiabilityCommentLabel.Name = "contigentLiabilityCommentLabel";
            this.helpProvider1.SetShowHelp(contigentLiabilityCommentLabel, ((bool)(resources.GetObject("contigentLiabilityCommentLabel.ShowHelp"))));
            // 
            // backgroundDetailLabel
            // 
            resources.ApplyResources(backgroundDetailLabel, "backgroundDetailLabel");
            backgroundDetailLabel.Name = "backgroundDetailLabel";
            this.helpProvider1.SetShowHelp(backgroundDetailLabel, ((bool)(resources.GetObject("backgroundDetailLabel.ShowHelp"))));
            // 
            // statusCommentLabel
            // 
            resources.ApplyResources(statusCommentLabel, "statusCommentLabel");
            statusCommentLabel.Name = "statusCommentLabel";
            this.helpProvider1.SetShowHelp(statusCommentLabel, ((bool)(resources.GetObject("statusCommentLabel.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(745, 801), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
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
            this.pnlAllContainer.Controls.Add(this.gbRiskAssessment);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(this.calendarCombo2);
            this.uiGroupBox1.Controls.Add(this.calendarCombo1);
            this.uiGroupBox1.Controls.Add(label2);
            this.uiGroupBox1.Controls.Add(label1);
            this.uiGroupBox1.Controls.Add(this.CourtNameCounter);
            this.uiGroupBox1.Controls.Add(this.ContingentLiabilityCommentCounter);
            this.uiGroupBox1.Controls.Add(backgroundDetailLabel);
            this.uiGroupBox1.Controls.Add(this.backgroundDetailTextBox);
            this.uiGroupBox1.Controls.Add(contigentLiabilityCommentLabel);
            this.uiGroupBox1.Controls.Add(this.contigentLiabilityCommentTextBox);
            this.uiGroupBox1.Controls.Add(statementOfClaimDateLabel);
            this.uiGroupBox1.Controls.Add(this.statementOfClaimDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(courtFileNumberLabel);
            this.uiGroupBox1.Controls.Add(this.courtFileNumberTextBox);
            this.uiGroupBox1.Controls.Add(courtNameLabel);
            this.uiGroupBox1.Controls.Add(this.courtNameTextBox);
            this.uiGroupBox1.Controls.Add(this.subjectToContingentLiabilityCheckBox);
            this.uiGroupBox1.Controls.Add(this.ucSettlementPossibilityMcc);
            this.uiGroupBox1.Controls.Add(this.amountClaimedTextBox);
            this.uiGroupBox1.Controls.Add(amountClaimedLabel);
            this.uiGroupBox1.Controls.Add(this.settlementEstTextBox);
            this.uiGroupBox1.Controls.Add(settlementEstLabel);
            this.uiGroupBox1.Controls.Add(this.contingentLiabilityTextBox);
            this.uiGroupBox1.Controls.Add(contingentLiabilityLabel);
            this.uiGroupBox1.Controls.Add(possibilityOfSettlementLabel);
            this.uiGroupBox1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.helpProvider1.SetShowHelp(this.uiGroupBox1, ((bool)(resources.GetObject("uiGroupBox1.ShowHelp"))));
            this.uiGroupBox1.UseThemes = false;
            // 
            // calendarCombo2
            // 
            resources.ApplyResources(this.calendarCombo2, "calendarCombo2");
            this.calendarCombo2.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.riskAssessmentBindingSource, "CLREndDate", true));
            // 
            // 
            // 
            this.calendarCombo2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo2.Name = "calendarCombo2";
            this.calendarCombo2.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo2, ((bool)(resources.GetObject("calendarCombo2.ShowHelp"))));
            this.calendarCombo2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // riskAssessmentBindingSource
            // 
            this.riskAssessmentBindingSource.DataMember = "RiskAssessment";
            this.riskAssessmentBindingSource.DataSource = this.atriumDB;
            this.riskAssessmentBindingSource.CurrentChanged += new System.EventHandler(this.riskAssessmentBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // calendarCombo1
            // 
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.riskAssessmentBindingSource, "CLRStartDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo1, ((bool)(resources.GetObject("calendarCombo1.ShowHelp"))));
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // CourtNameCounter
            // 
            this.CourtNameCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CourtNameCounter.DecimalDigits = 0;
            this.CourtNameCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.CourtNameCounter, "CourtNameCounter");
            this.CourtNameCounter.MaxLength = 3;
            this.CourtNameCounter.Name = "CourtNameCounter";
            this.CourtNameCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.CourtNameCounter, ((bool)(resources.GetObject("CourtNameCounter.ShowHelp"))));
            this.CourtNameCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.CourtNameCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CourtNameCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ContingentLiabilityCommentCounter
            // 
            this.ContingentLiabilityCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ContingentLiabilityCommentCounter.DecimalDigits = 0;
            this.ContingentLiabilityCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.ContingentLiabilityCommentCounter, "ContingentLiabilityCommentCounter");
            this.ContingentLiabilityCommentCounter.MaxLength = 3;
            this.ContingentLiabilityCommentCounter.Name = "ContingentLiabilityCommentCounter";
            this.ContingentLiabilityCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.ContingentLiabilityCommentCounter, ((bool)(resources.GetObject("ContingentLiabilityCommentCounter.ShowHelp"))));
            this.ContingentLiabilityCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ContingentLiabilityCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ContingentLiabilityCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // backgroundDetailTextBox
            // 
            this.backgroundDetailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "BackgroundDetail", true));
            resources.ApplyResources(this.backgroundDetailTextBox, "backgroundDetailTextBox");
            this.backgroundDetailTextBox.Name = "backgroundDetailTextBox";
            this.helpProvider1.SetShowHelp(this.backgroundDetailTextBox, ((bool)(resources.GetObject("backgroundDetailTextBox.ShowHelp"))));
            // 
            // contigentLiabilityCommentTextBox
            // 
            this.contigentLiabilityCommentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "ContigentLiabilityComment", true));
            resources.ApplyResources(this.contigentLiabilityCommentTextBox, "contigentLiabilityCommentTextBox");
            this.contigentLiabilityCommentTextBox.Name = "contigentLiabilityCommentTextBox";
            this.helpProvider1.SetShowHelp(this.contigentLiabilityCommentTextBox, ((bool)(resources.GetObject("contigentLiabilityCommentTextBox.ShowHelp"))));
            this.contigentLiabilityCommentTextBox.TextChanged += new System.EventHandler(this.statusCommentTextBox_TextChanged);
            // 
            // statementOfClaimDateCalendarCombo
            // 
            resources.ApplyResources(this.statementOfClaimDateCalendarCombo, "statementOfClaimDateCalendarCombo");
            this.statementOfClaimDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.riskAssessmentBindingSource, "StatementOfClaimDate", true));
            // 
            // 
            // 
            this.statementOfClaimDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.statementOfClaimDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.statementOfClaimDateCalendarCombo.Name = "statementOfClaimDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.statementOfClaimDateCalendarCombo, ((bool)(resources.GetObject("statementOfClaimDateCalendarCombo.ShowHelp"))));
            this.statementOfClaimDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // courtFileNumberTextBox
            // 
            this.courtFileNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "CourtFileNumber", true));
            resources.ApplyResources(this.courtFileNumberTextBox, "courtFileNumberTextBox");
            this.courtFileNumberTextBox.Name = "courtFileNumberTextBox";
            this.helpProvider1.SetShowHelp(this.courtFileNumberTextBox, ((bool)(resources.GetObject("courtFileNumberTextBox.ShowHelp"))));
            // 
            // courtNameTextBox
            // 
            this.courtNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "CourtName", true));
            resources.ApplyResources(this.courtNameTextBox, "courtNameTextBox");
            this.courtNameTextBox.Name = "courtNameTextBox";
            this.helpProvider1.SetShowHelp(this.courtNameTextBox, ((bool)(resources.GetObject("courtNameTextBox.ShowHelp"))));
            this.courtNameTextBox.TextChanged += new System.EventHandler(this.statusCommentTextBox_TextChanged);
            // 
            // subjectToContingentLiabilityCheckBox
            // 
            resources.ApplyResources(this.subjectToContingentLiabilityCheckBox, "subjectToContingentLiabilityCheckBox");
            this.subjectToContingentLiabilityCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.riskAssessmentBindingSource, "SubjectToContingentLiability", true));
            this.subjectToContingentLiabilityCheckBox.Name = "subjectToContingentLiabilityCheckBox";
            this.helpProvider1.SetShowHelp(this.subjectToContingentLiabilityCheckBox, ((bool)(resources.GetObject("subjectToContingentLiabilityCheckBox.ShowHelp"))));
            // 
            // ucSettlementPossibilityMcc
            // 
            this.ucSettlementPossibilityMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucSettlementPossibilityMcc.Column1 = "RASettlementPossibilityId";
            resources.ApplyResources(this.ucSettlementPossibilityMcc, "ucSettlementPossibilityMcc");
            this.ucSettlementPossibilityMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucSettlementPossibilityMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riskAssessmentBindingSource, "PossibilityOfSettlement", true));
            this.ucSettlementPossibilityMcc.DataSource = null;
            this.ucSettlementPossibilityMcc.DDColumn1Visible = true;
            this.ucSettlementPossibilityMcc.DropDownColumn1Width = 100;
            this.ucSettlementPossibilityMcc.DropDownColumn2Width = 300;
            this.ucSettlementPossibilityMcc.Name = "ucSettlementPossibilityMcc";
            this.ucSettlementPossibilityMcc.ReadOnly = false;
            this.ucSettlementPossibilityMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucSettlementPossibilityMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucSettlementPossibilityMcc, ((bool)(resources.GetObject("ucSettlementPossibilityMcc.ShowHelp"))));
            this.ucSettlementPossibilityMcc.ValueMember = "RASettlementPossibilityId";
            // 
            // amountClaimedTextBox
            // 
            this.amountClaimedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "AmountClaimed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            resources.ApplyResources(this.amountClaimedTextBox, "amountClaimedTextBox");
            this.amountClaimedTextBox.Name = "amountClaimedTextBox";
            this.helpProvider1.SetShowHelp(this.amountClaimedTextBox, ((bool)(resources.GetObject("amountClaimedTextBox.ShowHelp"))));
            // 
            // settlementEstTextBox
            // 
            this.settlementEstTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "SettlementEst", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            resources.ApplyResources(this.settlementEstTextBox, "settlementEstTextBox");
            this.settlementEstTextBox.Name = "settlementEstTextBox";
            this.helpProvider1.SetShowHelp(this.settlementEstTextBox, ((bool)(resources.GetObject("settlementEstTextBox.ShowHelp"))));
            // 
            // contingentLiabilityTextBox
            // 
            this.contingentLiabilityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "ContingentLiability", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            resources.ApplyResources(this.contingentLiabilityTextBox, "contingentLiabilityTextBox");
            this.contingentLiabilityTextBox.Name = "contingentLiabilityTextBox";
            this.helpProvider1.SetShowHelp(this.contingentLiabilityTextBox, ((bool)(resources.GetObject("contingentLiabilityTextBox.ShowHelp"))));
            // 
            // gbRiskAssessment
            // 
            this.gbRiskAssessment.BackColor = System.Drawing.Color.Transparent;
            this.gbRiskAssessment.Controls.Add(this.pictureBox1);
            this.gbRiskAssessment.Controls.Add(this.StatusCommentCounter);
            this.gbRiskAssessment.Controls.Add(statusCommentLabel);
            this.gbRiskAssessment.Controls.Add(this.ucRiskLevelMcc);
            this.gbRiskAssessment.Controls.Add(this.statusCommentTextBox);
            this.gbRiskAssessment.Controls.Add(this.ucLikelihoodMcc);
            this.gbRiskAssessment.Controls.Add(this.ucAssessedByMcc);
            this.gbRiskAssessment.Controls.Add(this.ucImpactMcc);
            this.gbRiskAssessment.Controls.Add(this.ucComplexityMcc);
            this.gbRiskAssessment.Controls.Add(impactLabel);
            this.gbRiskAssessment.Controls.Add(likelihoodLabel);
            this.gbRiskAssessment.Controls.Add(this.ucRAStatusMcc);
            this.gbRiskAssessment.Controls.Add(riskLevelLabel);
            this.gbRiskAssessment.Controls.Add(assessedByIdLabel1);
            this.gbRiskAssessment.Controls.Add(complexityLabel);
            this.gbRiskAssessment.Controls.Add(assessmentDateLabel);
            this.gbRiskAssessment.Controls.Add(this.assessmentDateCalendarCombo);
            this.gbRiskAssessment.Controls.Add(statusLabel);
            this.gbRiskAssessment.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbRiskAssessment, "gbRiskAssessment");
            this.gbRiskAssessment.Name = "gbRiskAssessment";
            this.helpProvider1.SetShowHelp(this.gbRiskAssessment, ((bool)(resources.GetObject("gbRiskAssessment.ShowHelp"))));
            this.gbRiskAssessment.UseThemes = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.helpProvider1.SetShowHelp(this.pictureBox1, ((bool)(resources.GetObject("pictureBox1.ShowHelp"))));
            this.pictureBox1.TabStop = false;
            // 
            // StatusCommentCounter
            // 
            this.StatusCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.StatusCommentCounter.DecimalDigits = 0;
            this.StatusCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.StatusCommentCounter, "StatusCommentCounter");
            this.StatusCommentCounter.MaxLength = 3;
            this.StatusCommentCounter.Name = "StatusCommentCounter";
            this.StatusCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.StatusCommentCounter, ((bool)(resources.GetObject("StatusCommentCounter.ShowHelp"))));
            this.StatusCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.StatusCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.StatusCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucRiskLevelMcc
            // 
            this.ucRiskLevelMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucRiskLevelMcc.Column1 = "RARiskLevelId";
            resources.ApplyResources(this.ucRiskLevelMcc, "ucRiskLevelMcc");
            this.ucRiskLevelMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucRiskLevelMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riskAssessmentBindingSource, "RiskLevel", true));
            this.ucRiskLevelMcc.DataSource = null;
            this.ucRiskLevelMcc.DDColumn1Visible = true;
            this.ucRiskLevelMcc.DropDownColumn1Width = 100;
            this.ucRiskLevelMcc.DropDownColumn2Width = 300;
            this.ucRiskLevelMcc.Name = "ucRiskLevelMcc";
            this.ucRiskLevelMcc.ReadOnly = true;
            this.ucRiskLevelMcc.ReqColor = System.Drawing.SystemColors.Control;
            this.ucRiskLevelMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucRiskLevelMcc, ((bool)(resources.GetObject("ucRiskLevelMcc.ShowHelp"))));
            this.ucRiskLevelMcc.ValueMember = "RARiskLevelId";
            this.ucRiskLevelMcc.ASelectedValueChanged += new System.EventHandler(this.riskLevelUIComboBox_SelectedIndexChanged);
            // 
            // statusCommentTextBox
            // 
            this.statusCommentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.riskAssessmentBindingSource, "StatusComment", true));
            resources.ApplyResources(this.statusCommentTextBox, "statusCommentTextBox");
            this.statusCommentTextBox.Name = "statusCommentTextBox";
            this.helpProvider1.SetShowHelp(this.statusCommentTextBox, ((bool)(resources.GetObject("statusCommentTextBox.ShowHelp"))));
            this.statusCommentTextBox.TextChanged += new System.EventHandler(this.statusCommentTextBox_TextChanged);
            // 
            // ucLikelihoodMcc
            // 
            this.ucLikelihoodMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucLikelihoodMcc.Column1 = "RALikelihoodId";
            resources.ApplyResources(this.ucLikelihoodMcc, "ucLikelihoodMcc");
            this.ucLikelihoodMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucLikelihoodMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riskAssessmentBindingSource, "Likelihood", true));
            this.ucLikelihoodMcc.DataSource = null;
            this.ucLikelihoodMcc.DDColumn1Visible = true;
            this.ucLikelihoodMcc.DropDownColumn1Width = 100;
            this.ucLikelihoodMcc.DropDownColumn2Width = 300;
            this.ucLikelihoodMcc.Name = "ucLikelihoodMcc";
            this.ucLikelihoodMcc.ReadOnly = false;
            this.ucLikelihoodMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucLikelihoodMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucLikelihoodMcc, ((bool)(resources.GetObject("ucLikelihoodMcc.ShowHelp"))));
            this.ucLikelihoodMcc.ValueMember = "RALikelihoodId";
            // 
            // ucAssessedByMcc
            // 
            this.ucAssessedByMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucAssessedByMcc.Column1 = "OfficerCode";
            resources.ApplyResources(this.ucAssessedByMcc, "ucAssessedByMcc");
            this.ucAssessedByMcc.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucAssessedByMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riskAssessmentBindingSource, "AssessedById", true));
            this.ucAssessedByMcc.DataSource = null;
            this.ucAssessedByMcc.DDColumn1Visible = true;
            this.ucAssessedByMcc.DropDownColumn1Width = 100;
            this.ucAssessedByMcc.DropDownColumn2Width = 300;
            this.ucAssessedByMcc.Name = "ucAssessedByMcc";
            this.ucAssessedByMcc.ReadOnly = false;
            this.ucAssessedByMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucAssessedByMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucAssessedByMcc, ((bool)(resources.GetObject("ucAssessedByMcc.ShowHelp"))));
            this.ucAssessedByMcc.ValueMember = "OfficerId";
            // 
            // ucImpactMcc
            // 
            this.ucImpactMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucImpactMcc.Column1 = "RAImpactId";
            resources.ApplyResources(this.ucImpactMcc, "ucImpactMcc");
            this.ucImpactMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucImpactMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riskAssessmentBindingSource, "Impact", true));
            this.ucImpactMcc.DataSource = null;
            this.ucImpactMcc.DDColumn1Visible = true;
            this.ucImpactMcc.DropDownColumn1Width = 100;
            this.ucImpactMcc.DropDownColumn2Width = 300;
            this.ucImpactMcc.Name = "ucImpactMcc";
            this.ucImpactMcc.ReadOnly = false;
            this.ucImpactMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucImpactMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucImpactMcc, ((bool)(resources.GetObject("ucImpactMcc.ShowHelp"))));
            this.ucImpactMcc.ValueMember = "RAImpactId";
            // 
            // ucComplexityMcc
            // 
            this.ucComplexityMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucComplexityMcc.Column1 = "RAComplexityId";
            resources.ApplyResources(this.ucComplexityMcc, "ucComplexityMcc");
            this.ucComplexityMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucComplexityMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riskAssessmentBindingSource, "Complexity", true));
            this.ucComplexityMcc.DataSource = null;
            this.ucComplexityMcc.DDColumn1Visible = true;
            this.ucComplexityMcc.DropDownColumn1Width = 100;
            this.ucComplexityMcc.DropDownColumn2Width = 300;
            this.ucComplexityMcc.Name = "ucComplexityMcc";
            this.ucComplexityMcc.ReadOnly = false;
            this.ucComplexityMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucComplexityMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucComplexityMcc, ((bool)(resources.GetObject("ucComplexityMcc.ShowHelp"))));
            this.ucComplexityMcc.ValueMember = "RAComplexityId";
            // 
            // ucRAStatusMcc
            // 
            this.ucRAStatusMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucRAStatusMcc.Column1 = "RAStatus";
            resources.ApplyResources(this.ucRAStatusMcc, "ucRAStatusMcc");
            this.ucRAStatusMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucRAStatusMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.riskAssessmentBindingSource, "Status", true));
            this.ucRAStatusMcc.DataSource = null;
            this.ucRAStatusMcc.DDColumn1Visible = true;
            this.ucRAStatusMcc.DropDownColumn1Width = 100;
            this.ucRAStatusMcc.DropDownColumn2Width = 300;
            this.ucRAStatusMcc.Name = "ucRAStatusMcc";
            this.ucRAStatusMcc.ReadOnly = false;
            this.ucRAStatusMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucRAStatusMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucRAStatusMcc, ((bool)(resources.GetObject("ucRAStatusMcc.ShowHelp"))));
            this.ucRAStatusMcc.ValueMember = "RAStatus";
            // 
            // assessmentDateCalendarCombo
            // 
            resources.ApplyResources(this.assessmentDateCalendarCombo, "assessmentDateCalendarCombo");
            this.assessmentDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.riskAssessmentBindingSource, "AssessmentDate", true));
            this.assessmentDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.assessmentDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.assessmentDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.assessmentDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.assessmentDateCalendarCombo.MonthIncrement = 0;
            this.assessmentDateCalendarCombo.Name = "assessmentDateCalendarCombo";
            this.assessmentDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.assessmentDateCalendarCombo, ((bool)(resources.GetObject("assessmentDateCalendarCombo.ShowHelp"))));
            this.assessmentDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.assessmentDateCalendarCombo.YearIncrement = 0;
            this.assessmentDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.assessmentDateCalendarCombo_KeyDown);
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
            this.cmdFile,
            this.cmdEdit,
            this.tsEditmode});
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
            this.Separator2,
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
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
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
            // ucLRM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucLRM";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.ucLRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.riskAssessmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRiskAssessment)).EndInit();
            this.gbRiskAssessment.ResumeLayout(false);
            this.gbRiskAssessment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private Janus.Windows.EditControls.UIGroupBox gbRiskAssessment;
        private System.Windows.Forms.BindingSource riskAssessmentBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.CalendarCombo.CalendarCombo assessmentDateCalendarCombo;
        private System.Windows.Forms.TextBox contingentLiabilityTextBox;
        private System.Windows.Forms.TextBox settlementEstTextBox;
        private System.Windows.Forms.TextBox amountClaimedTextBox;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
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
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private UserControls.ucMultiDropDown ucRAStatusMcc;
        private UserControls.ucMultiDropDown ucComplexityMcc;
        private UserControls.ucMultiDropDown ucAssessedByMcc;
        private UserControls.ucMultiDropDown ucSettlementPossibilityMcc;
        private UserControls.ucMultiDropDown ucImpactMcc;
        private UserControls.ucMultiDropDown ucLikelihoodMcc;
        private UserControls.ucMultiDropDown ucRiskLevelMcc;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.CalendarCombo.CalendarCombo statementOfClaimDateCalendarCombo;
        private System.Windows.Forms.TextBox courtFileNumberTextBox;
        private System.Windows.Forms.TextBox courtNameTextBox;
        private System.Windows.Forms.CheckBox subjectToContingentLiabilityCheckBox;
        private System.Windows.Forms.TextBox statusCommentTextBox;
        private System.Windows.Forms.TextBox backgroundDetailTextBox;
        private System.Windows.Forms.TextBox contigentLiabilityCommentTextBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ContingentLiabilityCommentCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox StatusCommentCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox CourtNameCounter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo2;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
    }
}
