using System.Data;
namespace LawMate
{
    partial class ucHardship
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

                FM.GetCLASMng().DB.Hardship.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetCLASMng().GetHardship().OnUpdate -= new atLogic.UpdateEventHandler(uc_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHardship));
            System.Windows.Forms.Label requestDateLabel;
            System.Windows.Forms.Label requestReasonLabel;
            System.Windows.Forms.Label commentLabel;
            System.Windows.Forms.Label approvedDateLabel;
            System.Windows.Forms.Label approvedByIdLabel;
            System.Windows.Forms.Label endDateLabel;
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.endDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.hardshipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CLAS = new lmDatasets.CLAS();
            this.approvedByIducContactSelectBox1 = new LawMate.ucContactSelectBox();
            this.approvedDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.setoffUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.recoveryUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.commentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.requestReasonEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.requestDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            requestDateLabel = new System.Windows.Forms.Label();
            requestReasonLabel = new System.Windows.Forms.Label();
            commentLabel = new System.Windows.Forms.Label();
            approvedDateLabel = new System.Windows.Forms.Label();
            approvedByIdLabel = new System.Windows.Forms.Label();
            endDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hardshipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
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
            // requestDateLabel
            // 
            requestDateLabel.AutoSize = true;
            requestDateLabel.BackColor = System.Drawing.Color.Transparent;
            requestDateLabel.Location = new System.Drawing.Point(25, 19);
            requestDateLabel.Name = "requestDateLabel";
            requestDateLabel.Size = new System.Drawing.Size(77, 13);
            requestDateLabel.TabIndex = 0;
            requestDateLabel.Text = "Request Date:";
            // 
            // requestReasonLabel
            // 
            requestReasonLabel.AutoSize = true;
            requestReasonLabel.BackColor = System.Drawing.Color.Transparent;
            requestReasonLabel.Location = new System.Drawing.Point(25, 46);
            requestReasonLabel.Name = "requestReasonLabel";
            requestReasonLabel.Size = new System.Drawing.Size(90, 13);
            requestReasonLabel.TabIndex = 4;
            requestReasonLabel.Text = "Request Reason:";
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.BackColor = System.Drawing.Color.Transparent;
            commentLabel.Location = new System.Drawing.Point(25, 72);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new System.Drawing.Size(56, 13);
            commentLabel.TabIndex = 6;
            commentLabel.Text = "Comment:";
            // 
            // approvedDateLabel
            // 
            approvedDateLabel.AutoSize = true;
            approvedDateLabel.BackColor = System.Drawing.Color.Transparent;
            approvedDateLabel.Location = new System.Drawing.Point(25, 127);
            approvedDateLabel.Name = "approvedDateLabel";
            approvedDateLabel.Size = new System.Drawing.Size(84, 13);
            approvedDateLabel.TabIndex = 8;
            approvedDateLabel.Text = "Approved Date:";
            // 
            // approvedByIdLabel
            // 
            approvedByIdLabel.AutoSize = true;
            approvedByIdLabel.BackColor = System.Drawing.Color.Transparent;
            approvedByIdLabel.Location = new System.Drawing.Point(25, 155);
            approvedByIdLabel.Name = "approvedByIdLabel";
            approvedByIdLabel.Size = new System.Drawing.Size(73, 13);
            approvedByIdLabel.TabIndex = 12;
            approvedByIdLabel.Text = "Approved By:";
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.BackColor = System.Drawing.Color.Transparent;
            endDateLabel.Location = new System.Drawing.Point(329, 127);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new System.Drawing.Size(55, 13);
            endDateLabel.TabIndex = 10;
            endDateLabel.Text = "End Date:";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = false;
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = 0;
            this.uiPanelManager1.PanelPadding.Left = 0;
            this.uiPanelManager1.PanelPadding.Right = 0;
            this.uiPanelManager1.PanelPadding.Top = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(773, 331), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Location = new System.Drawing.Point(0, 50);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(773, 331);
            this.pnlAll.TabIndex = 4;
            this.pnlAll.Text = "Legal Risk Management";
            // 
            // pnlAllContainer
            // 
            this.pnlAllContainer.AutoScroll = true;
            this.pnlAllContainer.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.pnlAllContainer.Controls.Add(this.uiTab3);
            this.pnlAllContainer.Controls.Add(this.gridEX1);
            this.pnlAllContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.pnlAllContainer.Size = new System.Drawing.Size(773, 331);
            this.pnlAllContainer.TabIndex = 0;
            // 
            // uiTab3
            // 
            this.uiTab3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTab3.BackColor = System.Drawing.Color.Transparent;
            this.uiTab3.Location = new System.Drawing.Point(0, 105);
            this.uiTab3.MinimumSize = new System.Drawing.Size(0, 202);
            this.uiTab3.Name = "uiTab3";
            this.uiTab3.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab3.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab3, true);
            this.uiTab3.Size = new System.Drawing.Size(773, 226);
            this.uiTab3.TabIndex = 4;
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
            this.uiTabPage3.Controls.Add(this.endDateCalendarCombo);
            this.uiTabPage3.Controls.Add(requestDateLabel);
            this.uiTabPage3.Controls.Add(this.approvedByIducContactSelectBox1);
            this.uiTabPage3.Controls.Add(commentLabel);
            this.uiTabPage3.Controls.Add(this.approvedDateCalendarCombo1);
            this.uiTabPage3.Controls.Add(approvedDateLabel);
            this.uiTabPage3.Controls.Add(this.setoffUICheckBox);
            this.uiTabPage3.Controls.Add(requestReasonLabel);
            this.uiTabPage3.Controls.Add(this.recoveryUICheckBox);
            this.uiTabPage3.Controls.Add(approvedByIdLabel);
            this.uiTabPage3.Controls.Add(this.commentEditBox);
            this.uiTabPage3.Controls.Add(endDateLabel);
            this.uiTabPage3.Controls.Add(this.requestReasonEditBox);
            this.uiTabPage3.Controls.Add(this.requestDateCalendarCombo1);
            this.uiTabPage3.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage3.Name = "uiTabPage3";
            this.uiTabPage3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.helpProvider1.SetShowHelp(this.uiTabPage3, true);
            this.uiTabPage3.Size = new System.Drawing.Size(771, 204);
            this.uiTabPage3.TabStop = true;
            this.uiTabPage3.Text = "Hardship";
            // 
            // endDateCalendarCombo
            // 
            this.endDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.endDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.hardshipBindingSource, "EndDate", true));
            this.endDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.endDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.endDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.Location = new System.Drawing.Point(407, 122);
            this.endDateCalendarCombo.MonthIncrement = 0;
            this.endDateCalendarCombo.Name = "endDateCalendarCombo";
            this.endDateCalendarCombo.Size = new System.Drawing.Size(97, 21);
            this.endDateCalendarCombo.TabIndex = 11;
            this.endDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.YearIncrement = 0;
            // 
            // hardshipBindingSource
            // 
            this.hardshipBindingSource.DataMember = "Hardship";
            this.hardshipBindingSource.DataSource = this.CLAS;
            // 
            // CLAS
            // 
            this.CLAS.DataSetName = "CLAS";
            this.CLAS.EnforceConstraints = false;
            this.CLAS.Locale = new System.Globalization.CultureInfo("en-CA");
            this.CLAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // approvedByIducContactSelectBox1
            // 
            this.approvedByIducContactSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.approvedByIducContactSelectBox1.ContactId = null;
            this.approvedByIducContactSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.hardshipBindingSource, "ApprovedById", true));
            this.approvedByIducContactSelectBox1.FM = null;
            this.approvedByIducContactSelectBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.approvedByIducContactSelectBox1.Location = new System.Drawing.Point(147, 149);
            this.approvedByIducContactSelectBox1.Name = "approvedByIducContactSelectBox1";
            this.approvedByIducContactSelectBox1.ReadOnly = false;
            this.approvedByIducContactSelectBox1.ReqColor = System.Drawing.SystemColors.Window;
            this.approvedByIducContactSelectBox1.Size = new System.Drawing.Size(357, 24);
            this.approvedByIducContactSelectBox1.TabIndex = 13;
            this.approvedByIducContactSelectBox1.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // approvedDateCalendarCombo1
            // 
            this.approvedDateCalendarCombo1.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.approvedDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.hardshipBindingSource, "ApprovedDate", true));
            this.approvedDateCalendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.approvedDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.approvedDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.approvedDateCalendarCombo1.Location = new System.Drawing.Point(147, 122);
            this.approvedDateCalendarCombo1.MonthIncrement = 0;
            this.approvedDateCalendarCombo1.Name = "approvedDateCalendarCombo1";
            this.approvedDateCalendarCombo1.Size = new System.Drawing.Size(100, 21);
            this.approvedDateCalendarCombo1.TabIndex = 9;
            this.approvedDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.approvedDateCalendarCombo1.YearIncrement = 0;
            // 
            // setoffUICheckBox
            // 
            this.setoffUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.setoffUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.setoffUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.hardshipBindingSource, "Setoff", true));
            this.setoffUICheckBox.Location = new System.Drawing.Point(437, 18);
            this.setoffUICheckBox.Name = "setoffUICheckBox";
            this.setoffUICheckBox.Size = new System.Drawing.Size(67, 18);
            this.setoffUICheckBox.TabIndex = 3;
            this.setoffUICheckBox.Text = "Setoff:";
            this.setoffUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // recoveryUICheckBox
            // 
            this.recoveryUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.recoveryUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recoveryUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.hardshipBindingSource, "Recovery", true));
            this.recoveryUICheckBox.Location = new System.Drawing.Point(312, 18);
            this.recoveryUICheckBox.Name = "recoveryUICheckBox";
            this.recoveryUICheckBox.Size = new System.Drawing.Size(93, 18);
            this.recoveryUICheckBox.TabIndex = 2;
            this.recoveryUICheckBox.Text = "Recovery:";
            this.recoveryUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // commentEditBox
            // 
            this.commentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hardshipBindingSource, "Comment", true));
            this.commentEditBox.Location = new System.Drawing.Point(147, 69);
            this.commentEditBox.Multiline = true;
            this.commentEditBox.Name = "commentEditBox";
            this.commentEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentEditBox.Size = new System.Drawing.Size(357, 47);
            this.commentEditBox.TabIndex = 7;
            this.commentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // requestReasonEditBox
            // 
            this.requestReasonEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hardshipBindingSource, "RequestReason", true));
            this.requestReasonEditBox.Location = new System.Drawing.Point(147, 42);
            this.requestReasonEditBox.Name = "requestReasonEditBox";
            this.requestReasonEditBox.Size = new System.Drawing.Size(357, 21);
            this.requestReasonEditBox.TabIndex = 5;
            this.requestReasonEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // requestDateCalendarCombo1
            // 
            this.requestDateCalendarCombo1.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.requestDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.hardshipBindingSource, "RequestDate", true));
            this.requestDateCalendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.requestDateCalendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.requestDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.requestDateCalendarCombo1.Location = new System.Drawing.Point(147, 15);
            this.requestDateCalendarCombo1.MonthIncrement = 0;
            this.requestDateCalendarCombo1.Name = "requestDateCalendarCombo1";
            this.requestDateCalendarCombo1.Size = new System.Drawing.Size(100, 21);
            this.requestDateCalendarCombo1.TabIndex = 1;
            this.requestDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.requestDateCalendarCombo1.YearIncrement = 0;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridEX1.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.gridEX1.DataSource = this.hardshipBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gridEX1.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.gridEX1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gridEX1.GridLineColor = System.Drawing.SystemColors.Control;
            this.gridEX1.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(773, 99);
            this.gridEX1.TabIndex = 0;
            this.gridEX1.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEX1.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AlwaysShowFullMenus = true;
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
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
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("ff3236e4-6c52-4a26-a5c8-6bbb944ba029");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.LockCommandBars = true;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 394);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(763, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            this.uiCommandBar1.Key = "cbMergeMenu";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.Size = new System.Drawing.Size(773, 22);
            this.uiCommandBar1.Text = "cbMergeMenu";
            // 
            // cmdFile1
            // 
            this.cmdFile1.Key = "cmdFile";
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            this.cmdEdit1.Key = "cmdEdit";
            this.cmdEdit1.MergeOrder = 2;
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave2,
            this.tsDelete2,
            this.Separator2,
            this.tsAudit1});
            this.uiCommandBar2.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.uiCommandBar2.FloatingSize = new System.Drawing.Size(63, 22);
            this.uiCommandBar2.FullRow = true;
            this.uiCommandBar2.Key = "cbMergeToolbar";
            this.uiCommandBar2.Location = new System.Drawing.Point(0, 22);
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.RowIndex = 1;
            this.uiCommandBar2.Size = new System.Drawing.Size(773, 28);
            this.uiCommandBar2.Text = "cbMergeToolbar";
            // 
            // tsEditmode1
            // 
            this.tsEditmode1.Key = "tsEditmode";
            this.tsEditmode1.Name = "tsEditmode1";
            // 
            // tsScreenTitle1
            // 
            this.tsScreenTitle1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsScreenTitle1.ControlWidth = 100;
            this.tsScreenTitle1.Key = "tsScreenTitle";
            this.tsScreenTitle1.MergeOrder = 1;
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.MergeOrder = 2;
            this.Separator1.Name = "Separator1";
            // 
            // tsSave2
            // 
            this.tsSave2.Key = "tsSave";
            this.tsSave2.MergeOrder = 20;
            this.tsSave2.Name = "tsSave2";
            this.tsSave2.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            // 
            // tsDelete2
            // 
            this.tsDelete2.Key = "tsDelete";
            this.tsDelete2.MergeOrder = 22;
            this.tsDelete2.Name = "tsDelete2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.MergeOrder = 23;
            this.Separator2.Name = "Separator2";
            // 
            // tsAudit1
            // 
            this.tsAudit1.Key = "tsAudit";
            this.tsAudit1.MergeOrder = 60;
            this.tsAudit1.Name = "tsAudit1";
            // 
            // tsDelete
            // 
            this.tsDelete.ImageIndex = 2;
            this.tsDelete.Key = "tsDelete";
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Text = "Delete";
            this.tsDelete.ToolTipText = "Delete";
            // 
            // tsSave
            // 
            this.tsSave.ImageIndex = 16;
            this.tsSave.Key = "tsSave";
            this.tsSave.Name = "tsSave";
            this.tsSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.tsSave.Text = "Save";
            this.tsSave.ToolTipText = "Save";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.tsScreenTitle.Key = "tsScreenTitle";
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.Text = "Hardship";
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsAudit
            // 
            this.tsAudit.Key = "tsAudit";
            this.tsAudit.Name = "tsAudit";
            this.tsAudit.ToolTipText = "Data Row LawMate.Properties";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave1});
            this.cmdFile.Key = "cmdFile";
            this.cmdFile.MergeOrder = 1;
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            this.cmdFile.Text = "&File";
            // 
            // tsSave1
            // 
            this.tsSave1.Key = "tsSave";
            this.tsSave1.Name = "tsSave1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete1});
            this.cmdEdit.Key = "cmdEdit";
            this.cmdEdit.MergeOrder = 2;
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Text = "&Edit";
            // 
            // tsDelete1
            // 
            this.tsDelete1.Key = "tsDelete";
            this.tsDelete1.Name = "tsDelete1";
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.tsEditmode.Key = "tsEditmode";
            this.tsEditmode.Name = "tsEditmode";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 54);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 340);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(763, 54);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 340);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(773, 50);
            // 
            // ucHardship
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucHardship";
            this.helpProvider1.SetShowHelp(this, true);
            this.Size = new System.Drawing.Size(773, 381);
            this.Load += new System.EventHandler(this.ucHardship_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hardshipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
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
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource hardshipBindingSource;
        private lmDatasets.CLAS CLAS;
        private Janus.Windows.CalendarCombo.CalendarCombo endDateCalendarCombo;
        private ucContactSelectBox approvedByIducContactSelectBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo approvedDateCalendarCombo1;
        private Janus.Windows.EditControls.UICheckBox setoffUICheckBox;
        private Janus.Windows.EditControls.UICheckBox recoveryUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox commentEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox requestReasonEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo requestDateCalendarCombo1;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;

    }
}
