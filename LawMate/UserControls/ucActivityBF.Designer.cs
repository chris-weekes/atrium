namespace LawMate.UserControls
{
    partial class ucActivityBF
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
                FM.DB.ActivityBF.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dtBF_ColumnChanged);
                FM.GetActivityBF().OnUpdate -= new atLogic.UpdateEventHandler(ucActivityBF_OnUpdate);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucActivityBF));
            System.Windows.Forms.Label priorityLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label bFDateLabel;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label bFCommentLabel;
            Janus.Windows.GridEX.GridEXLayout activityBFGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityBFGridEX_Layout_0_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityBFGridEX_Layout_0_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item2.Image");
            this.activityBFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.priorityJComboBox = new Janus.Windows.EditControls.UIComboBox();
            this.bfCommentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ucContactSelectBox1 = new LawMate.ucContactSelectBox();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.bFDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ebBFPerson = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ucBFOfficerId = new LawMate.ucContactSelectBox();
            this.activityBFGridEX = new Janus.Windows.GridEX.GridEX();
            this.imgListBFType = new System.Windows.Forms.ImageList(this.components);
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.uiContextMenu2 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdCompleteBF2 = new Janus.Windows.UI.CommandBars.UICommand("cmdCompleteBF");
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCompleteBF1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCompleteBF");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdHideCompletedBFs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHideCompletedBFs");
            this.cmdToggleTooltip1 = new Janus.Windows.UI.CommandBars.UICommand("cmdToggleTooltip");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdHideCompletedBFs = new Janus.Windows.UI.CommandBars.UICommand("cmdHideCompletedBFs");
            this.cmdToggleTooltip = new Janus.Windows.UI.CommandBars.UICommand("cmdToggleTooltip");
            this.cmdCompleteBF = new Janus.Windows.UI.CommandBars.UICommand("cmdCompleteBF");
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.Separator11 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.Separator12 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            priorityLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            bFDateLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            bFCommentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
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
            // priorityLabel
            // 
            resources.ApplyResources(priorityLabel, "priorityLabel");
            priorityLabel.BackColor = System.Drawing.Color.Transparent;
            priorityLabel.Name = "priorityLabel";
            this.helpProvider1.SetShowHelp(priorityLabel, ((bool)(resources.GetObject("priorityLabel.ShowHelp"))));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            this.helpProvider1.SetShowHelp(label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
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
            // bFDateLabel
            // 
            resources.ApplyResources(bFDateLabel, "bFDateLabel");
            bFDateLabel.BackColor = System.Drawing.Color.Transparent;
            bFDateLabel.Name = "bFDateLabel";
            this.helpProvider1.SetShowHelp(bFDateLabel, ((bool)(resources.GetObject("bFDateLabel.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            this.helpProvider1.SetShowHelp(label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // bFCommentLabel
            // 
            resources.ApplyResources(bFCommentLabel, "bFCommentLabel");
            bFCommentLabel.BackColor = System.Drawing.Color.Transparent;
            bFCommentLabel.Name = "bFCommentLabel";
            this.helpProvider1.SetShowHelp(bFCommentLabel, ((bool)(resources.GetObject("bFCommentLabel.ShowHelp"))));
            // 
            // activityBFBindingSource
            // 
            this.activityBFBindingSource.DataMember = "ActivityBF";
            this.activityBFBindingSource.DataSource = this.atriumDB;
            this.activityBFBindingSource.CurrentChanged += new System.EventHandler(this.activityBFBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(787, 411), true);
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
            this.pnlAllContainer.Controls.Add(this.uiTab1);
            this.pnlAllContainer.Controls.Add(this.activityBFGridEX);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // uiTab1
            // 
            resources.ApplyResources(this.uiTab1, "uiTab1");
            this.uiTab1.BackColor = System.Drawing.Color.Transparent;
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.PanelFormatStyle.BackColor = System.Drawing.Color.Transparent;
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
            this.uiTabPage1.Controls.Add(this.editBox1);
            this.uiTabPage1.Controls.Add(this.priorityJComboBox);
            this.uiTabPage1.Controls.Add(priorityLabel);
            this.uiTabPage1.Controls.Add(label3);
            this.uiTabPage1.Controls.Add(this.bfCommentEditBox);
            this.uiTabPage1.Controls.Add(this.ucContactSelectBox1);
            this.uiTabPage1.Controls.Add(bFCommentLabel);
            this.uiTabPage1.Controls.Add(this.calendarCombo1);
            this.uiTabPage1.Controls.Add(label5);
            this.uiTabPage1.Controls.Add(label4);
            this.uiTabPage1.Controls.Add(bFDateLabel);
            this.uiTabPage1.Controls.Add(this.bFDateCalendarCombo);
            this.uiTabPage1.Controls.Add(label6);
            this.uiTabPage1.Controls.Add(this.ebBFPerson);
            this.uiTabPage1.Controls.Add(this.ucBFOfficerId);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.Multiline = true;
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.editBox1, ((bool)(resources.GetObject("editBox1.ShowHelp"))));
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // priorityJComboBox
            // 
            resources.ApplyResources(this.priorityJComboBox, "priorityJComboBox");
            this.priorityJComboBox.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.priorityJComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.activityBFBindingSource, "Priority", true));
            this.priorityJComboBox.Name = "priorityJComboBox";
            this.helpProvider1.SetShowHelp(this.priorityJComboBox, ((bool)(resources.GetObject("priorityJComboBox.ShowHelp"))));
            this.priorityJComboBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // bfCommentEditBox
            // 
            this.bfCommentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBFBindingSource, "BFComment", true));
            resources.ApplyResources(this.bfCommentEditBox, "bfCommentEditBox");
            this.bfCommentEditBox.Multiline = true;
            this.bfCommentEditBox.Name = "bfCommentEditBox";
            this.bfCommentEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.bfCommentEditBox, ((bool)(resources.GetObject("bfCommentEditBox.ShowHelp"))));
            this.bfCommentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucContactSelectBox1
            // 
            this.ucContactSelectBox1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucContactSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox1.ContactId = null;
            this.ucContactSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.activityBFBindingSource, "CompletedByID", true));
            this.ucContactSelectBox1.FM = null;
            resources.ApplyResources(this.ucContactSelectBox1, "ucContactSelectBox1");
            this.ucContactSelectBox1.Name = "ucContactSelectBox1";
            this.ucContactSelectBox1.ReadOnly = true;
            this.ucContactSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucContactSelectBox1, ((bool)(resources.GetObject("ucContactSelectBox1.ShowHelp"))));
            this.ucContactSelectBox1.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBFBindingSource, "CompletedDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calendarCombo1.DropDownCalendar.Font")));
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.calendarCombo1.ShowDropDown = false;
            this.helpProvider1.SetShowHelp(this.calendarCombo1, ((bool)(resources.GetObject("calendarCombo1.ShowHelp"))));
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // bFDateCalendarCombo
            // 
            resources.ApplyResources(this.bFDateCalendarCombo, "bFDateCalendarCombo");
            this.bFDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBFBindingSource, "BFDate", true));
            this.bFDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.bFDateCalendarCombo.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("bFDateCalendarCombo.DropDownCalendar.Font")));
            this.bFDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bFDateCalendarCombo.MonthIncrement = 0;
            this.bFDateCalendarCombo.Name = "bFDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.bFDateCalendarCombo, ((bool)(resources.GetObject("bFDateCalendarCombo.ShowHelp"))));
            this.bFDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bFDateCalendarCombo.YearIncrement = 0;
            // 
            // ebBFPerson
            // 
            this.ebBFPerson.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ebBFPerson, "ebBFPerson");
            this.ebBFPerson.Name = "ebBFPerson";
            this.ebBFPerson.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.ebBFPerson, ((bool)(resources.GetObject("ebBFPerson.ShowHelp"))));
            this.ebBFPerson.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucBFOfficerId
            // 
            this.ucBFOfficerId.BackColor = System.Drawing.Color.Transparent;
            this.ucBFOfficerId.ContactId = null;
            this.ucBFOfficerId.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.activityBFBindingSource, "BFOfficerID", true));
            this.ucBFOfficerId.FM = null;
            resources.ApplyResources(this.ucBFOfficerId, "ucBFOfficerId");
            this.ucBFOfficerId.Name = "ucBFOfficerId";
            this.ucBFOfficerId.ReadOnly = false;
            this.ucBFOfficerId.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucBFOfficerId, ((bool)(resources.GetObject("ucBFOfficerId.ShowHelp"))));
            this.ucBFOfficerId.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // activityBFGridEX
            // 
            this.activityBFGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.activityBFGridEX, "activityBFGridEX");
            this.activityBFGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.activityBFGridEX.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.uiCommandManager1.SetContextMenu(this.activityBFGridEX, this.uiContextMenu2);
            this.activityBFGridEX.DataSource = this.activityBFBindingSource;
            this.activityBFGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.activityBFGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.activityBFGridEX.GridLineColor = System.Drawing.SystemColors.Window;
            this.activityBFGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityBFGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.activityBFGridEX.GroupByBoxVisible = false;
            this.activityBFGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.activityBFGridEX.ImageList = this.imgListBFType;
            activityBFGridEX_Layout_0.DataSource = this.activityBFBindingSource;
            activityBFGridEX_Layout_0.IsCurrentLayout = true;
            activityBFGridEX_Layout_0.Key = "LayoutAll";
            activityBFGridEX_Layout_0_Reference_0.Instance = ((object)(resources.GetObject("activityBFGridEX_Layout_0_Reference_0.Instance")));
            activityBFGridEX_Layout_0_Reference_1.Instance = ((object)(resources.GetObject("activityBFGridEX_Layout_0_Reference_1.Instance")));
            activityBFGridEX_Layout_0.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityBFGridEX_Layout_0_Reference_0,
            activityBFGridEX_Layout_0_Reference_1});
            resources.ApplyResources(activityBFGridEX_Layout_0, "activityBFGridEX_Layout_0");
            this.activityBFGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            activityBFGridEX_Layout_0});
            this.activityBFGridEX.Name = "activityBFGridEX";
            this.activityBFGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.activityBFGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.helpProvider1.SetShowHelp(this.activityBFGridEX, ((bool)(resources.GetObject("activityBFGridEX.ShowHelp"))));
            this.activityBFGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityBFGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityBFGridEX.FetchCellToolTipText += new Janus.Windows.GridEX.FetchCellToolTipTextEventHandler(this.activityBFGridEX_FetchCellToolTipText);
            this.activityBFGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityBFGridEX_FormattingRow);
            this.activityBFGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityBFGridEX_LoadingRow);
            this.activityBFGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.activityBFGridEX_CurrentCellChanging);
            this.activityBFGridEX.SelectionChanged += new System.EventHandler(this.activityBFGridEX_SelectionChanged);
            this.activityBFGridEX.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityBFGridEX_LinkClicked);
            this.activityBFGridEX.MouseLeave += new System.EventHandler(this.activityBFGridEX_MouseLeave);
            this.activityBFGridEX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.activityBFGridEX_MouseMove);
            // 
            // imgListBFType
            // 
            this.imgListBFType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBFType.ImageStream")));
            this.imgListBFType.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBFType.Images.SetKeyName(0, "MarkasRead.gif");
            this.imgListBFType.Images.SetKeyName(1, "bf1.gif");
            this.imgListBFType.Images.SetKeyName(2, "bf2.gif");
            this.imgListBFType.Images.SetKeyName(3, "bf3.gif");
            this.imgListBFType.Images.SetKeyName(4, "bf4.gif");
            this.imgListBFType.Images.SetKeyName(5, "bf5.gif");
            this.imgListBFType.Images.SetKeyName(6, "priorityNormal.gif");
            this.imgListBFType.Images.SetKeyName(7, "priorityHigh.gif");
            this.imgListBFType.Images.SetKeyName(8, "priorityUrgent.gif");
            this.imgListBFType.Images.SetKeyName(9, "FSArchived.ico");
            this.imgListBFType.Images.SetKeyName(10, "FSClosed.ico");
            this.imgListBFType.Images.SetKeyName(11, "FSMonitored.ico");
            this.imgListBFType.Images.SetKeyName(12, "FSOpen.ico");
            this.imgListBFType.Images.SetKeyName(13, "FSPending.ico");
            this.imgListBFType.Images.SetKeyName(14, "RolesBF.gif");
            this.imgListBFType.Images.SetKeyName(15, "DirectBF.gif");
            this.imgListBFType.Images.SetKeyName(16, "OfficeBF.gif");
            this.imgListBFType.Images.SetKeyName(17, "RecipientOfficer2.gif");
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.uiCommandManager1.CommandBarsFormatStyle.FontName = "tahoma";
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsScreenTitle,
            this.tsAudit,
            this.tsEditmode,
            this.cmdFile,
            this.cmdView,
            this.cmdEdit,
            this.cmdSave,
            this.cmdHideCompletedBFs,
            this.cmdToggleTooltip,
            this.cmdCompleteBF});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu2,
            this.uiContextMenu1});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("9126f6ed-88c4-4b11-a320-6da03270c015");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // uiContextMenu2
            // 
            this.uiContextMenu2.CommandManager = this.uiCommandManager1;
            this.uiContextMenu2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCompleteBF2});
            resources.ApplyResources(this.uiContextMenu2, "uiContextMenu2");
            this.uiContextMenu2.Popup += new System.EventHandler(this.uiContextMenu2_Popup);
            // 
            // cmdCompleteBF2
            // 
            resources.ApplyResources(this.cmdCompleteBF2, "cmdCompleteBF2");
            this.cmdCompleteBF2.Name = "cmdCompleteBF2";
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
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1,
            this.cmdView1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
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
            // cmdView1
            // 
            resources.ApplyResources(this.cmdView1, "cmdView1");
            this.cmdView1.Name = "cmdView1";
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator5,
            this.cmdSave1,
            this.cmdCompleteBF1,
            this.Separator1,
            this.cmdHideCompletedBFs1,
            this.cmdToggleTooltip1,
            this.Separator2,
            this.tsAudit1});
            this.uiCommandBar2.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.FullRow = true;
            this.uiCommandBar2.MergeRowOrder = 2;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // tsEditmode1
            // 
            resources.ApplyResources(this.tsEditmode1, "tsEditmode1");
            this.tsEditmode1.Name = "tsEditmode1";
            // 
            // tsScreenTitle1
            // 
            this.tsScreenTitle1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdSave1
            // 
            resources.ApplyResources(this.cmdSave1, "cmdSave1");
            this.cmdSave1.Name = "cmdSave1";
            // 
            // cmdCompleteBF1
            // 
            resources.ApplyResources(this.cmdCompleteBF1, "cmdCompleteBF1");
            this.cmdCompleteBF1.Name = "cmdCompleteBF1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdHideCompletedBFs1
            // 
            resources.ApplyResources(this.cmdHideCompletedBFs1, "cmdHideCompletedBFs1");
            this.cmdHideCompletedBFs1.Name = "cmdHideCompletedBFs1";
            // 
            // cmdToggleTooltip1
            // 
            resources.ApplyResources(this.cmdToggleTooltip1, "cmdToggleTooltip1");
            this.cmdToggleTooltip1.Name = "cmdToggleTooltip1";
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
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // cmdFile
            // 
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdView
            // 
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView.Name = "cmdView";
            // 
            // cmdEdit
            // 
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdSave
            // 
            resources.ApplyResources(this.cmdSave, "cmdSave");
            this.cmdSave.Name = "cmdSave";
            // 
            // cmdHideCompletedBFs
            // 
            this.cmdHideCompletedBFs.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdHideCompletedBFs, "cmdHideCompletedBFs");
            this.cmdHideCompletedBFs.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdHideCompletedBFs.Name = "cmdHideCompletedBFs";
            // 
            // cmdToggleTooltip
            // 
            this.cmdToggleTooltip.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdToggleTooltip, "cmdToggleTooltip");
            this.cmdToggleTooltip.Name = "cmdToggleTooltip";
            // 
            // cmdCompleteBF
            // 
            resources.ApplyResources(this.cmdCompleteBF, "cmdCompleteBF");
            this.cmdCompleteBF.Name = "cmdCompleteBF";
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.Separator10,
            this.Separator11,
            this.Separator12});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator10, "Separator10");
            this.Separator10.Name = "Separator10";
            // 
            // Separator11
            // 
            this.Separator11.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator11, "Separator11");
            this.Separator11.Name = "Separator11";
            // 
            // Separator12
            // 
            this.Separator12.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator12, "Separator12");
            this.Separator12.Name = "Separator12";
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
            // janusSuperTip1
            // 
            this.janusSuperTip1.AutoPopDelay = 0;
            this.janusSuperTip1.BodyWidth = 250;
            this.janusSuperTip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.janusSuperTip1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.janusSuperTip1.ImageList = null;
            this.janusSuperTip1.InitialDelay = 0;
            this.janusSuperTip1.OfficeColorScheme = Janus.Windows.Common.OfficeColorScheme.Silver;
            this.janusSuperTip1.ShowAlways = true;
            // 
            // ucActivityBF
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucActivityBF";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucActivityBF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.UI.CommandBars.UICommand Separator11;
        private Janus.Windows.UI.CommandBars.UICommand Separator12;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.GridEX.GridEX activityBFGridEX;
        private System.Windows.Forms.BindingSource activityBFBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.EditControls.UIComboBox priorityJComboBox;
        private ucContactSelectBox ucContactSelectBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo bFDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox bfCommentEditBox;
        private ucContactSelectBox ucBFOfficerId;
        private Janus.Windows.GridEX.EditControls.EditBox ebBFPerson;
        private System.Windows.Forms.ImageList imgListBFType;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHideCompletedBFs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHideCompletedBFs;
        private Janus.Windows.UI.CommandBars.UICommand cmdCompleteBF1;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggleTooltip1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggleTooltip;
        private Janus.Windows.UI.CommandBars.UICommand cmdCompleteBF;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCompleteBF2;
    }
}
