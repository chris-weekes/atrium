namespace LawMate
{
    partial class ucSSTDecision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSSTDecision));
            System.Windows.Forms.Label recDateLabel;
            System.Windows.Forms.Label assignedDateLabel;
            System.Windows.Forms.Label decisionTypeLabel;
            System.Windows.Forms.Label memberIdLabel;
            System.Windows.Forms.Label outcomeIdLabel;
            System.Windows.Forms.Label decisionDateLabel;
            System.Windows.Forms.Label decisionSentDateLabel;
            Janus.Windows.GridEX.GridEXLayout sSTDecisionGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.recDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sSTDecisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sST = new lmDatasets.SST();
            this.assignedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.decisionTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.memberIducContactSelectBox = new LawMate.ucContactSelectBox();
            this.outcomeIducMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.decisionDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.decisionSentDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.isFinalUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.sSTDecisionGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditMode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditMode = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            recDateLabel = new System.Windows.Forms.Label();
            assignedDateLabel = new System.Windows.Forms.Label();
            decisionTypeLabel = new System.Windows.Forms.Label();
            memberIdLabel = new System.Windows.Forms.Label();
            outcomeIdLabel = new System.Windows.Forms.Label();
            decisionDateLabel = new System.Windows.Forms.Label();
            decisionSentDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSTDecisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSTDecisionGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
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
            // recDateLabel
            // 
            resources.ApplyResources(recDateLabel, "recDateLabel");
            recDateLabel.BackColor = System.Drawing.Color.Transparent;
            recDateLabel.Name = "recDateLabel";
            this.helpProvider1.SetShowHelp(recDateLabel, ((bool)(resources.GetObject("recDateLabel.ShowHelp"))));
            // 
            // assignedDateLabel
            // 
            resources.ApplyResources(assignedDateLabel, "assignedDateLabel");
            assignedDateLabel.BackColor = System.Drawing.Color.Transparent;
            assignedDateLabel.Name = "assignedDateLabel";
            this.helpProvider1.SetShowHelp(assignedDateLabel, ((bool)(resources.GetObject("assignedDateLabel.ShowHelp"))));
            // 
            // decisionTypeLabel
            // 
            resources.ApplyResources(decisionTypeLabel, "decisionTypeLabel");
            decisionTypeLabel.BackColor = System.Drawing.Color.Transparent;
            decisionTypeLabel.Name = "decisionTypeLabel";
            this.helpProvider1.SetShowHelp(decisionTypeLabel, ((bool)(resources.GetObject("decisionTypeLabel.ShowHelp"))));
            // 
            // memberIdLabel
            // 
            resources.ApplyResources(memberIdLabel, "memberIdLabel");
            memberIdLabel.BackColor = System.Drawing.Color.Transparent;
            memberIdLabel.Name = "memberIdLabel";
            this.helpProvider1.SetShowHelp(memberIdLabel, ((bool)(resources.GetObject("memberIdLabel.ShowHelp"))));
            // 
            // outcomeIdLabel
            // 
            resources.ApplyResources(outcomeIdLabel, "outcomeIdLabel");
            outcomeIdLabel.BackColor = System.Drawing.Color.Transparent;
            outcomeIdLabel.Name = "outcomeIdLabel";
            this.helpProvider1.SetShowHelp(outcomeIdLabel, ((bool)(resources.GetObject("outcomeIdLabel.ShowHelp"))));
            // 
            // decisionDateLabel
            // 
            resources.ApplyResources(decisionDateLabel, "decisionDateLabel");
            decisionDateLabel.BackColor = System.Drawing.Color.Transparent;
            decisionDateLabel.Name = "decisionDateLabel";
            this.helpProvider1.SetShowHelp(decisionDateLabel, ((bool)(resources.GetObject("decisionDateLabel.ShowHelp"))));
            // 
            // decisionSentDateLabel
            // 
            resources.ApplyResources(decisionSentDateLabel, "decisionSentDateLabel");
            decisionSentDateLabel.BackColor = System.Drawing.Color.Transparent;
            decisionSentDateLabel.Name = "decisionSentDateLabel";
            this.helpProvider1.SetShowHelp(decisionSentDateLabel, ((bool)(resources.GetObject("decisionSentDateLabel.ShowHelp"))));
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
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(781, 449), true);
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
            this.pnlAllContainer.Controls.Add(recDateLabel);
            this.pnlAllContainer.Controls.Add(this.recDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(assignedDateLabel);
            this.pnlAllContainer.Controls.Add(this.assignedDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(decisionTypeLabel);
            this.pnlAllContainer.Controls.Add(this.decisionTypeucMultiDropDown);
            this.pnlAllContainer.Controls.Add(memberIdLabel);
            this.pnlAllContainer.Controls.Add(this.memberIducContactSelectBox);
            this.pnlAllContainer.Controls.Add(outcomeIdLabel);
            this.pnlAllContainer.Controls.Add(this.outcomeIducMultiDropDown);
            this.pnlAllContainer.Controls.Add(decisionDateLabel);
            this.pnlAllContainer.Controls.Add(this.decisionDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(decisionSentDateLabel);
            this.pnlAllContainer.Controls.Add(this.decisionSentDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(this.isFinalUICheckBox);
            this.pnlAllContainer.Controls.Add(this.sSTDecisionGridEX);
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // recDateCalendarCombo
            // 
            resources.ApplyResources(this.recDateCalendarCombo, "recDateCalendarCombo");
            this.recDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTDecisionBindingSource, "RecDate", true));
            // 
            // 
            // 
            this.recDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.recDateCalendarCombo.Name = "recDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.recDateCalendarCombo, ((bool)(resources.GetObject("recDateCalendarCombo.ShowHelp"))));
            this.recDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // sSTDecisionBindingSource
            // 
            this.sSTDecisionBindingSource.DataMember = "SSTDecision";
            this.sSTDecisionBindingSource.DataSource = this.sST;
            this.sSTDecisionBindingSource.CurrentChanged += new System.EventHandler(this.sSTDecisionBindingSource_CurrentChanged);
            // 
            // sST
            // 
            this.sST.DataSetName = "SST";
            this.sST.EnforceConstraints = false;
            this.sST.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // assignedDateCalendarCombo
            // 
            resources.ApplyResources(this.assignedDateCalendarCombo, "assignedDateCalendarCombo");
            this.assignedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTDecisionBindingSource, "AssignedDate", true));
            // 
            // 
            // 
            this.assignedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.assignedDateCalendarCombo.Name = "assignedDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.assignedDateCalendarCombo, ((bool)(resources.GetObject("assignedDateCalendarCombo.ShowHelp"))));
            this.assignedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // decisionTypeucMultiDropDown
            // 
            this.decisionTypeucMultiDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.decisionTypeucMultiDropDown.Column1 = "DecisionTypeId";
            resources.ApplyResources(this.decisionTypeucMultiDropDown, "decisionTypeucMultiDropDown");
            this.decisionTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.decisionTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sSTDecisionBindingSource, "DecisionType", true));
            this.decisionTypeucMultiDropDown.DataSource = null;
            this.decisionTypeucMultiDropDown.DDColumn1Visible = false;
            this.decisionTypeucMultiDropDown.DropDownColumn1Width = 100;
            this.decisionTypeucMultiDropDown.DropDownColumn2Width = 300;
            this.decisionTypeucMultiDropDown.Name = "decisionTypeucMultiDropDown";
            this.decisionTypeucMultiDropDown.ReadOnly = true;
            this.decisionTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Control;
            this.decisionTypeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.decisionTypeucMultiDropDown, ((bool)(resources.GetObject("decisionTypeucMultiDropDown.ShowHelp"))));
            this.decisionTypeucMultiDropDown.ValueMember = "DecisionTypeId";
            // 
            // memberIducContactSelectBox
            // 
            this.memberIducContactSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.memberIducContactSelectBox.ContactId = null;
            this.memberIducContactSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.sSTDecisionBindingSource, "MemberId", true));
            this.memberIducContactSelectBox.FM = null;
            resources.ApplyResources(this.memberIducContactSelectBox, "memberIducContactSelectBox");
            this.memberIducContactSelectBox.Name = "memberIducContactSelectBox";
            this.memberIducContactSelectBox.ReadOnly = false;
            this.memberIducContactSelectBox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.memberIducContactSelectBox, ((bool)(resources.GetObject("memberIducContactSelectBox.ShowHelp"))));
            this.memberIducContactSelectBox.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // outcomeIducMultiDropDown
            // 
            this.outcomeIducMultiDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.outcomeIducMultiDropDown.Column1 = "OutcomeId";
            resources.ApplyResources(this.outcomeIducMultiDropDown, "outcomeIducMultiDropDown");
            this.outcomeIducMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.outcomeIducMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sSTDecisionBindingSource, "OutcomeId", true));
            this.outcomeIducMultiDropDown.DataSource = null;
            this.outcomeIducMultiDropDown.DDColumn1Visible = false;
            this.outcomeIducMultiDropDown.DropDownColumn1Width = 100;
            this.outcomeIducMultiDropDown.DropDownColumn2Width = 300;
            this.outcomeIducMultiDropDown.Name = "outcomeIducMultiDropDown";
            this.outcomeIducMultiDropDown.ReadOnly = false;
            this.outcomeIducMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.outcomeIducMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.outcomeIducMultiDropDown, ((bool)(resources.GetObject("outcomeIducMultiDropDown.ShowHelp"))));
            this.outcomeIducMultiDropDown.ValueMember = "OutcomeId";
            // 
            // decisionDateCalendarCombo
            // 
            resources.ApplyResources(this.decisionDateCalendarCombo, "decisionDateCalendarCombo");
            this.decisionDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTDecisionBindingSource, "DecisionDate", true));
            // 
            // 
            // 
            this.decisionDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.decisionDateCalendarCombo.Name = "decisionDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.decisionDateCalendarCombo, ((bool)(resources.GetObject("decisionDateCalendarCombo.ShowHelp"))));
            this.decisionDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // decisionSentDateCalendarCombo
            // 
            resources.ApplyResources(this.decisionSentDateCalendarCombo, "decisionSentDateCalendarCombo");
            this.decisionSentDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTDecisionBindingSource, "DecisionSentDate", true));
            // 
            // 
            // 
            this.decisionSentDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.decisionSentDateCalendarCombo.Name = "decisionSentDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.decisionSentDateCalendarCombo, ((bool)(resources.GetObject("decisionSentDateCalendarCombo.ShowHelp"))));
            this.decisionSentDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // isFinalUICheckBox
            // 
            this.isFinalUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.isFinalUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isFinalUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTDecisionBindingSource, "IsFinal", true));
            resources.ApplyResources(this.isFinalUICheckBox, "isFinalUICheckBox");
            this.isFinalUICheckBox.Name = "isFinalUICheckBox";
            this.helpProvider1.SetShowHelp(this.isFinalUICheckBox, ((bool)(resources.GetObject("isFinalUICheckBox.ShowHelp"))));
            this.isFinalUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // sSTDecisionGridEX
            // 
            this.sSTDecisionGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.sSTDecisionGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sSTDecisionGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.sSTDecisionGridEX.DataSource = this.sSTDecisionBindingSource;
            resources.ApplyResources(sSTDecisionGridEX_DesignTimeLayout, "sSTDecisionGridEX_DesignTimeLayout");
            this.sSTDecisionGridEX.DesignTimeLayout = sSTDecisionGridEX_DesignTimeLayout;
            this.sSTDecisionGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.sSTDecisionGridEX, "sSTDecisionGridEX");
            this.sSTDecisionGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.sSTDecisionGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.sSTDecisionGridEX.GroupByBoxVisible = false;
            this.sSTDecisionGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.sSTDecisionGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.sSTDecisionGridEX.Indent = 20;
            this.sSTDecisionGridEX.Name = "sSTDecisionGridEX";
            this.sSTDecisionGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.helpProvider1.SetShowHelp(this.sSTDecisionGridEX, ((bool)(resources.GetObject("sSTDecisionGridEX.ShowHelp"))));
            this.sSTDecisionGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.sSTDecisionGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave,
            this.tsDelete,
            this.tsScreenTitle,
            this.tsEditMode,
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("3ae62034-b0f2-4a63-9270-34f4760e5a18");
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
            // uiCommandBar1
            // 
            this.uiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
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
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditMode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave2,
            this.tsDelete2,
            this.Separator2,
            this.tsAudit1});
            this.uiCommandBar2.FullRow = true;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // tsEditMode1
            // 
            resources.ApplyResources(this.tsEditMode1, "tsEditMode1");
            this.tsEditMode1.Name = "tsEditMode1";
            // 
            // tsScreenTitle1
            // 
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
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
            // tsSave
            // 
            this.tsSave.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsSave, "tsSave");
            this.tsSave.Name = "tsSave";
            // 
            // tsDelete
            // 
            this.tsDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsDelete, "tsDelete");
            this.tsDelete.Name = "tsDelete";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            // 
            // tsEditMode
            // 
            this.tsEditMode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditMode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditMode, "tsEditMode");
            this.tsEditMode.Name = "tsEditMode";
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
            this.tsSave1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete1});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
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
            // ucSSTDecision
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucSSTDecision";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSTDecisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSTDecisionGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
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
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.GridEX.GridEX sSTDecisionGridEX;
        private System.Windows.Forms.BindingSource sSTDecisionBindingSource;
        private lmDatasets.SST sST;
        private Janus.Windows.CalendarCombo.CalendarCombo recDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo assignedDateCalendarCombo;
        private UserControls.ucMultiDropDown decisionTypeucMultiDropDown;
        private ucContactSelectBox memberIducContactSelectBox;
        private UserControls.ucMultiDropDown outcomeIducMultiDropDown;
        private Janus.Windows.CalendarCombo.CalendarCombo decisionDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo decisionSentDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox isFinalUICheckBox;
    }
}
