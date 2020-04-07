 namespace LawMate
{
    partial class ucOpinion
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
                FM.GetAdvisoryMng().DB.Opinion.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetAdvisoryMng().GetOpinion().OnUpdate -= new atLogic.UpdateEventHandler(ucOpinion_OnUpdate);

                ucDocView1.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOpinion));
            System.Windows.Forms.Label subjectLabel;
            System.Windows.Forms.Label requestDateLabel;
            System.Windows.Forms.Label assignedDateLabel;
            System.Windows.Forms.Label dueDateLabel;
            System.Windows.Forms.Label completedDateLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label receivedDateLabel;
            System.Windows.Forms.Label assignedToIdLabel;
            System.Windows.Forms.Label opinionTypeIdLabel;
            System.Windows.Forms.Label requestContactIdLabel;
            System.Windows.Forms.Label requestOfficeIdLabel;
            System.Windows.Forms.Label acknowledgeDateLabel;
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.acCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.subjectEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.opinionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.mccOpinionType = new LawMate.UserControls.ucMultiDropDown();
            this.ucOfficeSelectBox1 = new LawMate.ucOfficeSelectBox();
            this.ucContactSelectBox1 = new LawMate.ucContactSelectBox();
            this.assignedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.dueDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.completedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.acknowledgeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.receivedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.requestDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.pnlDoc = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucDocView1 = new LawMate.UserControls.ucDocView();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsShowRequest1 = new Janus.Windows.UI.CommandBars.UICommand("tsShowRequest");
            this.tsShowOpinion1 = new Janus.Windows.UI.CommandBars.UICommand("tsShowOpinion");
            this.cmdLinkDocumentToOpinion1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkDocumentToOpinion");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsShowRequest = new Janus.Windows.UI.CommandBars.UICommand("tsShowRequest");
            this.tsShowOpinion = new Janus.Windows.UI.CommandBars.UICommand("tsShowOpinion");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave3 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.tsShowRequest2 = new Janus.Windows.UI.CommandBars.UICommand("tsShowRequest");
            this.tsShowOpinion2 = new Janus.Windows.UI.CommandBars.UICommand("tsShowOpinion");
            this.cmdLinkDocumentToOpinion = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkDocumentToOpinion");
            this.cmdLinkRequest1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkRequest");
            this.cmdLinkOpinion1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkOpinion");
            this.cmdLinkRequest = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkRequest");
            this.cmdLinkOpinion = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkOpinion");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            subjectLabel = new System.Windows.Forms.Label();
            requestDateLabel = new System.Windows.Forms.Label();
            assignedDateLabel = new System.Windows.Forms.Label();
            dueDateLabel = new System.Windows.Forms.Label();
            completedDateLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            receivedDateLabel = new System.Windows.Forms.Label();
            assignedToIdLabel = new System.Windows.Forms.Label();
            opinionTypeIdLabel = new System.Windows.Forms.Label();
            requestContactIdLabel = new System.Windows.Forms.Label();
            requestOfficeIdLabel = new System.Windows.Forms.Label();
            acknowledgeDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opinionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).BeginInit();
            this.pnlDoc.SuspendLayout();
            this.pnlDocContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.opinionBindingSource;
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
            this.imageListBase.Images.SetKeyName(19, "DRedit.gif");
            this.imageListBase.Images.SetKeyName(20, "mail2.gif");
            this.imageListBase.Images.SetKeyName(21, "opinion.png");
            // 
            // subjectLabel
            // 
            resources.ApplyResources(subjectLabel, "subjectLabel");
            subjectLabel.BackColor = System.Drawing.Color.Transparent;
            subjectLabel.Name = "subjectLabel";
            this.helpProvider1.SetShowHelp(subjectLabel, ((bool)(resources.GetObject("subjectLabel.ShowHelp"))));
            // 
            // requestDateLabel
            // 
            resources.ApplyResources(requestDateLabel, "requestDateLabel");
            requestDateLabel.BackColor = System.Drawing.Color.Transparent;
            requestDateLabel.Name = "requestDateLabel";
            this.helpProvider1.SetShowHelp(requestDateLabel, ((bool)(resources.GetObject("requestDateLabel.ShowHelp"))));
            // 
            // assignedDateLabel
            // 
            resources.ApplyResources(assignedDateLabel, "assignedDateLabel");
            assignedDateLabel.BackColor = System.Drawing.Color.Transparent;
            assignedDateLabel.Name = "assignedDateLabel";
            this.helpProvider1.SetShowHelp(assignedDateLabel, ((bool)(resources.GetObject("assignedDateLabel.ShowHelp"))));
            // 
            // dueDateLabel
            // 
            resources.ApplyResources(dueDateLabel, "dueDateLabel");
            dueDateLabel.BackColor = System.Drawing.Color.Transparent;
            dueDateLabel.Name = "dueDateLabel";
            this.helpProvider1.SetShowHelp(dueDateLabel, ((bool)(resources.GetObject("dueDateLabel.ShowHelp"))));
            // 
            // completedDateLabel
            // 
            resources.ApplyResources(completedDateLabel, "completedDateLabel");
            completedDateLabel.BackColor = System.Drawing.Color.Transparent;
            completedDateLabel.Name = "completedDateLabel";
            this.helpProvider1.SetShowHelp(completedDateLabel, ((bool)(resources.GetObject("completedDateLabel.ShowHelp"))));
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(descriptionLabel, "descriptionLabel");
            descriptionLabel.BackColor = System.Drawing.Color.Transparent;
            descriptionLabel.Name = "descriptionLabel";
            this.helpProvider1.SetShowHelp(descriptionLabel, ((bool)(resources.GetObject("descriptionLabel.ShowHelp"))));
            // 
            // receivedDateLabel
            // 
            resources.ApplyResources(receivedDateLabel, "receivedDateLabel");
            receivedDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedDateLabel.Name = "receivedDateLabel";
            this.helpProvider1.SetShowHelp(receivedDateLabel, ((bool)(resources.GetObject("receivedDateLabel.ShowHelp"))));
            // 
            // assignedToIdLabel
            // 
            resources.ApplyResources(assignedToIdLabel, "assignedToIdLabel");
            assignedToIdLabel.BackColor = System.Drawing.Color.Transparent;
            assignedToIdLabel.Name = "assignedToIdLabel";
            this.helpProvider1.SetShowHelp(assignedToIdLabel, ((bool)(resources.GetObject("assignedToIdLabel.ShowHelp"))));
            // 
            // opinionTypeIdLabel
            // 
            resources.ApplyResources(opinionTypeIdLabel, "opinionTypeIdLabel");
            opinionTypeIdLabel.BackColor = System.Drawing.Color.Transparent;
            opinionTypeIdLabel.Name = "opinionTypeIdLabel";
            this.helpProvider1.SetShowHelp(opinionTypeIdLabel, ((bool)(resources.GetObject("opinionTypeIdLabel.ShowHelp"))));
            // 
            // requestContactIdLabel
            // 
            resources.ApplyResources(requestContactIdLabel, "requestContactIdLabel");
            requestContactIdLabel.BackColor = System.Drawing.Color.Transparent;
            requestContactIdLabel.Name = "requestContactIdLabel";
            this.helpProvider1.SetShowHelp(requestContactIdLabel, ((bool)(resources.GetObject("requestContactIdLabel.ShowHelp"))));
            // 
            // requestOfficeIdLabel
            // 
            resources.ApplyResources(requestOfficeIdLabel, "requestOfficeIdLabel");
            requestOfficeIdLabel.BackColor = System.Drawing.Color.Transparent;
            requestOfficeIdLabel.Name = "requestOfficeIdLabel";
            this.helpProvider1.SetShowHelp(requestOfficeIdLabel, ((bool)(resources.GetObject("requestOfficeIdLabel.ShowHelp"))));
            // 
            // acknowledgeDateLabel
            // 
            resources.ApplyResources(acknowledgeDateLabel, "acknowledgeDateLabel");
            acknowledgeDateLabel.BackColor = System.Drawing.Color.Transparent;
            acknowledgeDateLabel.Name = "acknowledgeDateLabel";
            this.helpProvider1.SetShowHelp(acknowledgeDateLabel, ((bool)(resources.GetObject("acknowledgeDateLabel.ShowHelp"))));
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
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
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            this.pnlDoc.Id = new System.Guid("eea2ef7d-a49c-47db-99cc-e820ac3a30c1");
            this.uiPanelManager1.Panels.Add(this.pnlDoc);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("eea2ef7d-a49c-47db-99cc-e820ac3a30c1"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(745, 384), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(745, 265), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("eea2ef7d-a49c-47db-99cc-e820ac3a30c1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
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
            this.pnlAllContainer.Controls.Add(this.acCommentCounter);
            this.pnlAllContainer.Controls.Add(this.subjectEditBox);
            this.pnlAllContainer.Controls.Add(this.descriptionEditBox);
            this.pnlAllContainer.Controls.Add(this.mccOpinionType);
            this.pnlAllContainer.Controls.Add(this.ucOfficeSelectBox1);
            this.pnlAllContainer.Controls.Add(this.ucContactSelectBox1);
            this.pnlAllContainer.Controls.Add(requestDateLabel);
            this.pnlAllContainer.Controls.Add(this.assignedDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(assignedDateLabel);
            this.pnlAllContainer.Controls.Add(this.ucMultiDropDown1);
            this.pnlAllContainer.Controls.Add(this.dueDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(acknowledgeDateLabel);
            this.pnlAllContainer.Controls.Add(dueDateLabel);
            this.pnlAllContainer.Controls.Add(assignedToIdLabel);
            this.pnlAllContainer.Controls.Add(this.completedDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(this.acknowledgeDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(requestOfficeIdLabel);
            this.pnlAllContainer.Controls.Add(completedDateLabel);
            this.pnlAllContainer.Controls.Add(opinionTypeIdLabel);
            this.pnlAllContainer.Controls.Add(this.receivedDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(descriptionLabel);
            this.pnlAllContainer.Controls.Add(receivedDateLabel);
            this.pnlAllContainer.Controls.Add(requestContactIdLabel);
            this.pnlAllContainer.Controls.Add(this.requestDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(subjectLabel);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // acCommentCounter
            // 
            this.acCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.acCommentCounter.DecimalDigits = 0;
            this.acCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.acCommentCounter.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
            resources.ApplyResources(this.acCommentCounter, "acCommentCounter");
            this.acCommentCounter.MaxLength = 4;
            this.acCommentCounter.Name = "acCommentCounter";
            this.acCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.acCommentCounter, ((bool)(resources.GetObject("acCommentCounter.ShowHelp"))));
            this.acCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.acCommentCounter.Value = 1024;
            this.acCommentCounter.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this.acCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // subjectEditBox
            // 
            this.subjectEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opinionBindingSource, "Subject", true));
            resources.ApplyResources(this.subjectEditBox, "subjectEditBox");
            this.subjectEditBox.Multiline = true;
            this.subjectEditBox.Name = "subjectEditBox";
            this.subjectEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.subjectEditBox, ((bool)(resources.GetObject("subjectEditBox.ShowHelp"))));
            this.subjectEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.subjectEditBox.TextChanged += new System.EventHandler(this.subjectEditBox_TextChanged);
            // 
            // opinionBindingSource
            // 
            this.opinionBindingSource.DataMember = "Opinion";
            this.opinionBindingSource.DataSource = typeof(lmDatasets.Advisory);
            this.opinionBindingSource.CurrentChanged += new System.EventHandler(this.opinionBindingSource_CurrentChanged);
            // 
            // descriptionEditBox
            // 
            this.descriptionEditBox.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.descriptionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.opinionBindingSource, "Description", true));
            resources.ApplyResources(this.descriptionEditBox, "descriptionEditBox");
            this.descriptionEditBox.Multiline = true;
            this.descriptionEditBox.Name = "descriptionEditBox";
            this.descriptionEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.descriptionEditBox, ((bool)(resources.GetObject("descriptionEditBox.ShowHelp"))));
            this.descriptionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // mccOpinionType
            // 
            this.mccOpinionType.BackColor = System.Drawing.Color.Transparent;
            this.mccOpinionType.Column1 = "OpinionTypeId";
            resources.ApplyResources(this.mccOpinionType, "mccOpinionType");
            this.mccOpinionType.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccOpinionType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.opinionBindingSource, "OpinionTypeId", true));
            this.mccOpinionType.DataSource = null;
            this.mccOpinionType.DDColumn1Visible = true;
            this.mccOpinionType.DropDownColumn1Width = 40;
            this.mccOpinionType.DropDownColumn2Width = 300;
            this.mccOpinionType.Name = "mccOpinionType";
            this.mccOpinionType.ReadOnly = false;
            this.mccOpinionType.ReqColor = System.Drawing.SystemColors.Window;
            this.mccOpinionType.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccOpinionType, ((bool)(resources.GetObject("mccOpinionType.ShowHelp"))));
            this.mccOpinionType.ValueMember = "OpinionTypeId";
            // 
            // ucOfficeSelectBox1
            // 
            this.ucOfficeSelectBox1.AtMng = null;
            this.ucOfficeSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucOfficeSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.opinionBindingSource, "RequestOfficeId", true));
            resources.ApplyResources(this.ucOfficeSelectBox1, "ucOfficeSelectBox1");
            this.ucOfficeSelectBox1.Name = "ucOfficeSelectBox1";
            this.ucOfficeSelectBox1.OfficeId = null;
            this.ucOfficeSelectBox1.ReadOnly = false;
            this.ucOfficeSelectBox1.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucOfficeSelectBox1, ((bool)(resources.GetObject("ucOfficeSelectBox1.ShowHelp"))));
            // 
            // ucContactSelectBox1
            // 
            this.ucContactSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox1.ContactId = null;
            this.ucContactSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.opinionBindingSource, "RequestContactId", true));
            this.ucContactSelectBox1.FM = null;
            resources.ApplyResources(this.ucContactSelectBox1, "ucContactSelectBox1");
            this.ucContactSelectBox1.Name = "ucContactSelectBox1";
            this.ucContactSelectBox1.ReadOnly = false;
            this.ucContactSelectBox1.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucContactSelectBox1, ((bool)(resources.GetObject("ucContactSelectBox1.ShowHelp"))));
            this.ucContactSelectBox1.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // assignedDateCalendarCombo
            // 
            resources.ApplyResources(this.assignedDateCalendarCombo, "assignedDateCalendarCombo");
            this.assignedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.opinionBindingSource, "AssignedDate", true));
            this.assignedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.assignedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.assignedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.assignedDateCalendarCombo.MonthIncrement = 0;
            this.assignedDateCalendarCombo.Name = "assignedDateCalendarCombo";
            this.assignedDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.assignedDateCalendarCombo, ((bool)(resources.GetObject("assignedDateCalendarCombo.ShowHelp"))));
            this.assignedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.assignedDateCalendarCombo.YearIncrement = 0;
            this.assignedDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.requestDateCalendarCombo_KeyDown);
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown1.Column1 = "OfficerCode";
            resources.ApplyResources(this.ucMultiDropDown1, "ucMultiDropDown1");
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.opinionBindingSource, "AssignedToId", true));
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = false;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown1.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown1, ((bool)(resources.GetObject("ucMultiDropDown1.ShowHelp"))));
            this.ucMultiDropDown1.ValueMember = "OfficerId";
            // 
            // dueDateCalendarCombo
            // 
            resources.ApplyResources(this.dueDateCalendarCombo, "dueDateCalendarCombo");
            this.dueDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.opinionBindingSource, "DueDate", true));
            this.dueDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.dueDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.dueDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dueDateCalendarCombo.MonthIncrement = 0;
            this.dueDateCalendarCombo.Name = "dueDateCalendarCombo";
            this.dueDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.dueDateCalendarCombo, ((bool)(resources.GetObject("dueDateCalendarCombo.ShowHelp"))));
            this.dueDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dueDateCalendarCombo.YearIncrement = 0;
            this.dueDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.requestDateCalendarCombo_KeyDown);
            // 
            // completedDateCalendarCombo
            // 
            resources.ApplyResources(this.completedDateCalendarCombo, "completedDateCalendarCombo");
            this.completedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.opinionBindingSource, "CompletedDate", true));
            this.completedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.completedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.completedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.completedDateCalendarCombo.MonthIncrement = 0;
            this.completedDateCalendarCombo.Name = "completedDateCalendarCombo";
            this.completedDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.completedDateCalendarCombo, ((bool)(resources.GetObject("completedDateCalendarCombo.ShowHelp"))));
            this.completedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.completedDateCalendarCombo.YearIncrement = 0;
            this.completedDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.requestDateCalendarCombo_KeyDown);
            // 
            // acknowledgeDateCalendarCombo
            // 
            resources.ApplyResources(this.acknowledgeDateCalendarCombo, "acknowledgeDateCalendarCombo");
            this.acknowledgeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.opinionBindingSource, "AcknowledgeDate", true));
            this.acknowledgeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.acknowledgeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.acknowledgeDateCalendarCombo.MonthIncrement = 0;
            this.acknowledgeDateCalendarCombo.Name = "acknowledgeDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.acknowledgeDateCalendarCombo, ((bool)(resources.GetObject("acknowledgeDateCalendarCombo.ShowHelp"))));
            this.acknowledgeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.acknowledgeDateCalendarCombo.YearIncrement = 0;
            this.acknowledgeDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.requestDateCalendarCombo_KeyDown);
            // 
            // receivedDateCalendarCombo
            // 
            resources.ApplyResources(this.receivedDateCalendarCombo, "receivedDateCalendarCombo");
            this.receivedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.opinionBindingSource, "ReceivedDate", true));
            this.receivedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.receivedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedDateCalendarCombo.MonthIncrement = 0;
            this.receivedDateCalendarCombo.Name = "receivedDateCalendarCombo";
            this.receivedDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.receivedDateCalendarCombo, ((bool)(resources.GetObject("receivedDateCalendarCombo.ShowHelp"))));
            this.receivedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedDateCalendarCombo.YearIncrement = 0;
            this.receivedDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.requestDateCalendarCombo_KeyDown);
            // 
            // requestDateCalendarCombo
            // 
            resources.ApplyResources(this.requestDateCalendarCombo, "requestDateCalendarCombo");
            this.requestDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.opinionBindingSource, "RequestDate", true));
            this.requestDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.requestDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.requestDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.requestDateCalendarCombo.MonthIncrement = 0;
            this.requestDateCalendarCombo.Name = "requestDateCalendarCombo";
            this.requestDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.requestDateCalendarCombo, ((bool)(resources.GetObject("requestDateCalendarCombo.ShowHelp"))));
            this.requestDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.requestDateCalendarCombo.YearIncrement = 0;
            this.requestDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.requestDateCalendarCombo_KeyDown);
            // 
            // pnlDoc
            // 
            this.pnlDoc.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.pnlDoc.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDoc.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlDoc.InnerContainer = this.pnlDocContainer;
            resources.ApplyResources(this.pnlDoc, "pnlDoc");
            this.pnlDoc.Name = "pnlDoc";
            this.helpProvider1.SetShowHelp(this.pnlDoc, ((bool)(resources.GetObject("pnlDoc.ShowHelp"))));
            // 
            // pnlDocContainer
            // 
            this.pnlDocContainer.Controls.Add(this.ucDocView1);
            resources.ApplyResources(this.pnlDocContainer, "pnlDocContainer");
            this.pnlDocContainer.Name = "pnlDocContainer";
            this.helpProvider1.SetShowHelp(this.pnlDocContainer, ((bool)(resources.GetObject("pnlDocContainer.ShowHelp"))));
            // 
            // ucDocView1
            // 
            this.ucDocView1.ActionToolbarView = LawMate.UserControls.DocCommandBar.Enable;
            this.ucDocView1.AllowActionToolbar = true;
            this.ucDocView1.AllowMetadata = true;
            this.ucDocView1.AllowMetadataUpdate = true;
            this.ucDocView1.DocDisplayType = LawMate.UserControls.DocViewDisplayType.MailHeader;
            resources.ApplyResources(this.ucDocView1, "ucDocView1");
            this.ucDocView1.ForceTextControl = true;
            this.ucDocView1.Name = "ucDocView1";
            this.ucDocView1.NoDocDisplayed = false;
            this.ucDocView1.ShowAttachmentPanel = false;
            this.helpProvider1.SetShowHelp(this.ucDocView1, ((bool)(resources.GetObject("ucDocView1.ShowHelp"))));
            this.ucDocView1.ShowMetadata = true;
            this.ucDocView1.ShowVersion = false;
            this.ucDocView1.TempFile = null;
            this.ucDocView1.TempFld = null;
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
            this.tsSave2,
            this.tsScreenTitle,
            this.tsShowRequest,
            this.tsShowOpinion,
            this.tsAudit,
            this.tsEditmode,
            this.cmdFile,
            this.cmdEdit,
            this.cmdView,
            this.cmdLinkDocumentToOpinion,
            this.cmdLinkRequest,
            this.cmdLinkOpinion});
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
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave1,
            this.tsDelete1,
            this.Separator5,
            this.tsShowRequest1,
            this.tsShowOpinion1,
            this.cmdLinkDocumentToOpinion1,
            this.Separator4,
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
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // tsShowRequest1
            // 
            resources.ApplyResources(this.tsShowRequest1, "tsShowRequest1");
            this.tsShowRequest1.Name = "tsShowRequest1";
            // 
            // tsShowOpinion1
            // 
            resources.ApplyResources(this.tsShowOpinion1, "tsShowOpinion1");
            this.tsShowOpinion1.Name = "tsShowOpinion1";
            // 
            // cmdLinkDocumentToOpinion1
            // 
            this.cmdLinkDocumentToOpinion1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdLinkDocumentToOpinion1, "cmdLinkDocumentToOpinion1");
            this.cmdLinkDocumentToOpinion1.Name = "cmdLinkDocumentToOpinion1";
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
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsShowRequest
            // 
            this.tsShowRequest.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.tsShowRequest.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsShowRequest.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsShowRequest, "tsShowRequest");
            this.tsShowRequest.Name = "tsShowRequest";
            // 
            // tsShowOpinion
            // 
            this.tsShowOpinion.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.tsShowOpinion.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsShowOpinion.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsShowOpinion, "tsShowOpinion");
            this.tsShowOpinion.Name = "tsShowOpinion";
            // 
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsEditmode
            // 
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
            this.tsSave3});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave3
            // 
            resources.ApplyResources(this.tsSave3, "tsSave3");
            this.tsSave3.Name = "tsSave3";
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
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsShowRequest2,
            this.tsShowOpinion2});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView.Name = "cmdView";
            // 
            // tsShowRequest2
            // 
            resources.ApplyResources(this.tsShowRequest2, "tsShowRequest2");
            this.tsShowRequest2.Name = "tsShowRequest2";
            // 
            // tsShowOpinion2
            // 
            resources.ApplyResources(this.tsShowOpinion2, "tsShowOpinion2");
            this.tsShowOpinion2.Name = "tsShowOpinion2";
            // 
            // cmdLinkDocumentToOpinion
            // 
            this.cmdLinkDocumentToOpinion.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdLinkRequest1,
            this.cmdLinkOpinion1});
            resources.ApplyResources(this.cmdLinkDocumentToOpinion, "cmdLinkDocumentToOpinion");
            this.cmdLinkDocumentToOpinion.Name = "cmdLinkDocumentToOpinion";
            // 
            // cmdLinkRequest1
            // 
            resources.ApplyResources(this.cmdLinkRequest1, "cmdLinkRequest1");
            this.cmdLinkRequest1.Name = "cmdLinkRequest1";
            // 
            // cmdLinkOpinion1
            // 
            resources.ApplyResources(this.cmdLinkOpinion1, "cmdLinkOpinion1");
            this.cmdLinkOpinion1.Name = "cmdLinkOpinion1";
            // 
            // cmdLinkRequest
            // 
            resources.ApplyResources(this.cmdLinkRequest, "cmdLinkRequest");
            this.cmdLinkRequest.Name = "cmdLinkRequest";
            // 
            // cmdLinkOpinion
            // 
            resources.ApplyResources(this.cmdLinkOpinion, "cmdLinkOpinion");
            this.cmdLinkOpinion.Name = "cmdLinkOpinion";
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
            // documentBindingSource
            // 
            this.documentBindingSource.DataMember = "Document";
            this.documentBindingSource.CurrentChanged += new System.EventHandler(this.documentBindingSource_CurrentChanged);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.documentBindingSource;
            // 
            // ucOpinion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlDoc);
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucOpinion";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucOpinion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opinionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).EndInit();
            this.pnlDoc.ResumeLayout(false);
            this.pnlDocContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private System.Windows.Forms.BindingSource opinionBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo requestDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo completedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo dueDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo assignedDateCalendarCombo;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private lmDatasets.docDB docDB;
        private Janus.Windows.UI.CommandBars.UICommand tsShowRequest;
        private Janus.Windows.UI.CommandBars.UICommand tsShowOpinion;
        private Janus.Windows.UI.CommandBars.UICommand tsShowRequest1;
        private Janus.Windows.UI.CommandBars.UICommand tsShowOpinion1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.CalendarCombo.CalendarCombo acknowledgeDateCalendarCombo;
        private UserControls.ucMultiDropDown ucMultiDropDown1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox acCommentCounter;
        private Janus.Windows.UI.Dock.UIPanel pnlDoc;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocContainer;
        private ucOfficeSelectBox ucOfficeSelectBox1;
        private ucContactSelectBox ucContactSelectBox1;
        private UserControls.ucMultiDropDown mccOpinionType;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave3;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand tsShowRequest2;
        private Janus.Windows.UI.CommandBars.UICommand tsShowOpinion2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkDocumentToOpinion;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkDocumentToOpinion1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkRequest1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkOpinion1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkRequest;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkOpinion;
        private Janus.Windows.GridEX.EditControls.EditBox subjectEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox descriptionEditBox;
        private UserControls.ucDocView ucDocView1;
    }
}
