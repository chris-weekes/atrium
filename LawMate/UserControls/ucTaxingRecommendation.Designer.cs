 namespace LawMate
{
    partial class ucTaxingRecommendation
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
                FM.GetCLASMng().DB.Taxing.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.GetCLASMng().GetTaxing().OnUpdate -= new atLogic.UpdateEventHandler(ucTaxingRecommendation_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTaxingRecommendation));
            System.Windows.Forms.Label taxingDateLabel;
            System.Windows.Forms.Label reasonCodeLabel;
            System.Windows.Forms.Label commentLabel;
            System.Windows.Forms.Label officeCodeLabel;
            System.Windows.Forms.Label officerCodeLabel;
            System.Windows.Forms.Label nameELabel;
            System.Windows.Forms.Label taxDownDisbLabel;
            System.Windows.Forms.Label taxDownHoursLabel;
            Janus.Windows.GridEX.GridEXLayout taxingGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference taxingGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference taxingGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.HeaderImage");
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.btnJumpToIRP = new Janus.Windows.EditControls.UIButton();
            this.fileIDucFileSelectBox = new LawMate.ucFileSelectBox();
            this.taxingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taxingDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.commentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.taxDownHoursNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.taxDownDisbNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.prevInstructedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.officerIDucContactSelectBox = new LawMate.ucContactSelectBox();
            this.reasonCodeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.officeIDucOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.closedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.taxingGridEX = new Janus.Windows.GridEX.GridEX();
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
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.atriumDB = new lmDatasets.atriumDB();
            taxingDateLabel = new System.Windows.Forms.Label();
            reasonCodeLabel = new System.Windows.Forms.Label();
            commentLabel = new System.Windows.Forms.Label();
            officeCodeLabel = new System.Windows.Forms.Label();
            officerCodeLabel = new System.Windows.Forms.Label();
            nameELabel = new System.Windows.Forms.Label();
            taxDownDisbLabel = new System.Windows.Forms.Label();
            taxDownHoursLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.taxingBindingSource;
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
            this.imageListBase.Images.SetKeyName(19, "DRedit.gif");
            // 
            // taxingDateLabel
            // 
            resources.ApplyResources(taxingDateLabel, "taxingDateLabel");
            taxingDateLabel.BackColor = System.Drawing.Color.Transparent;
            taxingDateLabel.Name = "taxingDateLabel";
            this.helpProvider1.SetShowHelp(taxingDateLabel, ((bool)(resources.GetObject("taxingDateLabel.ShowHelp"))));
            // 
            // reasonCodeLabel
            // 
            resources.ApplyResources(reasonCodeLabel, "reasonCodeLabel");
            reasonCodeLabel.BackColor = System.Drawing.Color.Transparent;
            reasonCodeLabel.Name = "reasonCodeLabel";
            this.helpProvider1.SetShowHelp(reasonCodeLabel, ((bool)(resources.GetObject("reasonCodeLabel.ShowHelp"))));
            // 
            // commentLabel
            // 
            resources.ApplyResources(commentLabel, "commentLabel");
            commentLabel.BackColor = System.Drawing.Color.Transparent;
            commentLabel.Name = "commentLabel";
            this.helpProvider1.SetShowHelp(commentLabel, ((bool)(resources.GetObject("commentLabel.ShowHelp"))));
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
            // nameELabel
            // 
            resources.ApplyResources(nameELabel, "nameELabel");
            nameELabel.BackColor = System.Drawing.Color.Transparent;
            nameELabel.Name = "nameELabel";
            this.helpProvider1.SetShowHelp(nameELabel, ((bool)(resources.GetObject("nameELabel.ShowHelp"))));
            // 
            // taxDownDisbLabel
            // 
            resources.ApplyResources(taxDownDisbLabel, "taxDownDisbLabel");
            taxDownDisbLabel.BackColor = System.Drawing.Color.Transparent;
            taxDownDisbLabel.Name = "taxDownDisbLabel";
            this.helpProvider1.SetShowHelp(taxDownDisbLabel, ((bool)(resources.GetObject("taxDownDisbLabel.ShowHelp"))));
            // 
            // taxDownHoursLabel
            // 
            resources.ApplyResources(taxDownHoursLabel, "taxDownHoursLabel");
            taxDownHoursLabel.BackColor = System.Drawing.Color.Transparent;
            taxDownHoursLabel.Name = "taxDownHoursLabel";
            this.helpProvider1.SetShowHelp(taxDownHoursLabel, ((bool)(resources.GetObject("taxDownHoursLabel.ShowHelp"))));
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(812, 514), true);
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
            this.pnlAllContainer.Controls.Add(this.uiTab3);
            this.pnlAllContainer.Controls.Add(this.taxingGridEX);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
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
            this.uiTabPage3.Controls.Add(this.btnJumpToIRP);
            this.uiTabPage3.Controls.Add(this.fileIDucFileSelectBox);
            this.uiTabPage3.Controls.Add(this.taxingDateCalendarCombo);
            this.uiTabPage3.Controls.Add(nameELabel);
            this.uiTabPage3.Controls.Add(this.commentEditBox);
            this.uiTabPage3.Controls.Add(taxDownHoursLabel);
            this.uiTabPage3.Controls.Add(this.taxDownHoursNumericEditBox);
            this.uiTabPage3.Controls.Add(taxDownDisbLabel);
            this.uiTabPage3.Controls.Add(this.taxDownDisbNumericEditBox);
            this.uiTabPage3.Controls.Add(officerCodeLabel);
            this.uiTabPage3.Controls.Add(this.prevInstructedUICheckBox);
            this.uiTabPage3.Controls.Add(officeCodeLabel);
            this.uiTabPage3.Controls.Add(this.officerIDucContactSelectBox);
            this.uiTabPage3.Controls.Add(commentLabel);
            this.uiTabPage3.Controls.Add(this.reasonCodeucMultiDropDown);
            this.uiTabPage3.Controls.Add(reasonCodeLabel);
            this.uiTabPage3.Controls.Add(this.officeIDucOfficeSelectBox);
            this.uiTabPage3.Controls.Add(taxingDateLabel);
            this.uiTabPage3.Controls.Add(this.closedUICheckBox);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // btnJumpToIRP
            // 
            this.btnJumpToIRP.Image = global::LawMate.Properties.Resources.autochain;
            resources.ApplyResources(this.btnJumpToIRP, "btnJumpToIRP");
            this.btnJumpToIRP.Name = "btnJumpToIRP";
            this.helpProvider1.SetShowHelp(this.btnJumpToIRP, ((bool)(resources.GetObject("btnJumpToIRP.ShowHelp"))));
            this.btnJumpToIRP.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnJumpToIRP.Click += new System.EventHandler(this.btnJumpToIRP_Click);
            // 
            // fileIDucFileSelectBox
            // 
            resources.ApplyResources(this.fileIDucFileSelectBox, "fileIDucFileSelectBox");
            this.fileIDucFileSelectBox.AtMng = null;
            this.fileIDucFileSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.fileIDucFileSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.taxingBindingSource, "FileID", true));
            this.fileIDucFileSelectBox.FileId = null;
            this.fileIDucFileSelectBox.Name = "fileIDucFileSelectBox";
            this.fileIDucFileSelectBox.ReadOnly = false;
            this.fileIDucFileSelectBox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.fileIDucFileSelectBox, ((bool)(resources.GetObject("fileIDucFileSelectBox.ShowHelp"))));
            // 
            // taxingBindingSource
            // 
            this.taxingBindingSource.CurrentChanged += new System.EventHandler(this.taxingBindingSource_CurrentChanged);
            // 
            // taxingDateCalendarCombo
            // 
            resources.ApplyResources(this.taxingDateCalendarCombo, "taxingDateCalendarCombo");
            this.taxingDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.taxingBindingSource, "TaxingDate", true));
            this.taxingDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.taxingDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.taxingDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.taxingDateCalendarCombo.MonthIncrement = 0;
            this.taxingDateCalendarCombo.Name = "taxingDateCalendarCombo";
            this.taxingDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.taxingDateCalendarCombo, ((bool)(resources.GetObject("taxingDateCalendarCombo.ShowHelp"))));
            this.taxingDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.taxingDateCalendarCombo.YearIncrement = 0;
            // 
            // commentEditBox
            // 
            this.commentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taxingBindingSource, "Comment", true));
            resources.ApplyResources(this.commentEditBox, "commentEditBox");
            this.commentEditBox.Multiline = true;
            this.commentEditBox.Name = "commentEditBox";
            this.helpProvider1.SetShowHelp(this.commentEditBox, ((bool)(resources.GetObject("commentEditBox.ShowHelp"))));
            this.commentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // taxDownHoursNumericEditBox
            // 
            this.taxDownHoursNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.taxingBindingSource, "TaxDownHours", true));
            this.taxDownHoursNumericEditBox.DecimalDigits = 1;
            resources.ApplyResources(this.taxDownHoursNumericEditBox, "taxDownHoursNumericEditBox");
            this.taxDownHoursNumericEditBox.Name = "taxDownHoursNumericEditBox";
            this.helpProvider1.SetShowHelp(this.taxDownHoursNumericEditBox, ((bool)(resources.GetObject("taxDownHoursNumericEditBox.ShowHelp"))));
            this.taxDownHoursNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.taxDownHoursNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // taxDownDisbNumericEditBox
            // 
            this.taxDownDisbNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.taxingBindingSource, "TaxDownDisb", true));
            this.taxDownDisbNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.taxDownDisbNumericEditBox, "taxDownDisbNumericEditBox");
            this.taxDownDisbNumericEditBox.Name = "taxDownDisbNumericEditBox";
            this.helpProvider1.SetShowHelp(this.taxDownDisbNumericEditBox, ((bool)(resources.GetObject("taxDownDisbNumericEditBox.ShowHelp"))));
            this.taxDownDisbNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.taxDownDisbNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // prevInstructedUICheckBox
            // 
            this.prevInstructedUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.prevInstructedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prevInstructedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.taxingBindingSource, "PrevInstructed", true));
            resources.ApplyResources(this.prevInstructedUICheckBox, "prevInstructedUICheckBox");
            this.prevInstructedUICheckBox.Name = "prevInstructedUICheckBox";
            this.helpProvider1.SetShowHelp(this.prevInstructedUICheckBox, ((bool)(resources.GetObject("prevInstructedUICheckBox.ShowHelp"))));
            this.prevInstructedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // officerIDucContactSelectBox
            // 
            this.officerIDucContactSelectBox.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.officerIDucContactSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officerIDucContactSelectBox.ContactId = null;
            this.officerIDucContactSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.taxingBindingSource, "OfficerID", true));
            this.officerIDucContactSelectBox.FM = null;
            resources.ApplyResources(this.officerIDucContactSelectBox, "officerIDucContactSelectBox");
            this.officerIDucContactSelectBox.Name = "officerIDucContactSelectBox";
            this.officerIDucContactSelectBox.ReadOnly = false;
            this.officerIDucContactSelectBox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.officerIDucContactSelectBox, ((bool)(resources.GetObject("officerIDucContactSelectBox.ShowHelp"))));
            this.officerIDucContactSelectBox.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // reasonCodeucMultiDropDown
            // 
            this.reasonCodeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.reasonCodeucMultiDropDown.Column1 = "ReasonCode";
            resources.ApplyResources(this.reasonCodeucMultiDropDown, "reasonCodeucMultiDropDown");
            this.reasonCodeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.reasonCodeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.taxingBindingSource, "ReasonCode", true));
            this.reasonCodeucMultiDropDown.DataSource = null;
            this.reasonCodeucMultiDropDown.DDColumn1Visible = true;
            this.reasonCodeucMultiDropDown.DropDownColumn1Width = 75;
            this.reasonCodeucMultiDropDown.DropDownColumn2Width = 250;
            this.reasonCodeucMultiDropDown.Name = "reasonCodeucMultiDropDown";
            this.reasonCodeucMultiDropDown.ReadOnly = false;
            this.reasonCodeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.reasonCodeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.reasonCodeucMultiDropDown, ((bool)(resources.GetObject("reasonCodeucMultiDropDown.ShowHelp"))));
            this.reasonCodeucMultiDropDown.ValueMember = "ReasonCode";
            // 
            // officeIDucOfficeSelectBox
            // 
            this.officeIDucOfficeSelectBox.AtMng = null;
            this.officeIDucOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIDucOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.taxingBindingSource, "OfficeID", true));
            resources.ApplyResources(this.officeIDucOfficeSelectBox, "officeIDucOfficeSelectBox");
            this.officeIDucOfficeSelectBox.Name = "officeIDucOfficeSelectBox";
            this.officeIDucOfficeSelectBox.OfficeId = null;
            this.officeIDucOfficeSelectBox.ReadOnly = true;
            this.officeIDucOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIDucOfficeSelectBox, ((bool)(resources.GetObject("officeIDucOfficeSelectBox.ShowHelp"))));
            // 
            // closedUICheckBox
            // 
            this.closedUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.closedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.taxingBindingSource, "Closed", true));
            resources.ApplyResources(this.closedUICheckBox, "closedUICheckBox");
            this.closedUICheckBox.Name = "closedUICheckBox";
            this.helpProvider1.SetShowHelp(this.closedUICheckBox, ((bool)(resources.GetObject("closedUICheckBox.ShowHelp"))));
            this.closedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // taxingGridEX
            // 
            this.taxingGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.taxingGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.taxingGridEX, "taxingGridEX");
            this.taxingGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.taxingGridEX.DataSource = this.taxingBindingSource;
            taxingGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("taxingGridEX_DesignTimeLayout_Reference_0.Instance")));
            taxingGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("taxingGridEX_DesignTimeLayout_Reference_1.Instance")));
            taxingGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            taxingGridEX_DesignTimeLayout_Reference_0,
            taxingGridEX_DesignTimeLayout_Reference_1});
            resources.ApplyResources(taxingGridEX_DesignTimeLayout, "taxingGridEX_DesignTimeLayout");
            this.taxingGridEX.DesignTimeLayout = taxingGridEX_DesignTimeLayout;
            this.taxingGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.taxingGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.taxingGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.taxingGridEX.GroupByBoxVisible = false;
            this.taxingGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.taxingGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.taxingGridEX.Name = "taxingGridEX";
            this.helpProvider1.SetShowHelp(this.taxingGridEX, ((bool)(resources.GetObject("taxingGridEX.ShowHelp"))));
            this.taxingGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.taxingGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
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
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // ucTaxingRecommendation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucTaxingRecommendation";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucTaxingRecommendation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.GridEX.GridEX taxingGridEX;
        private System.Windows.Forms.BindingSource taxingBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.CalendarCombo.CalendarCombo taxingDateCalendarCombo;
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
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private ucFileSelectBox fileIDucFileSelectBox;
        private Janus.Windows.GridEX.EditControls.EditBox commentEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox taxDownHoursNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox taxDownDisbNumericEditBox;
        private Janus.Windows.EditControls.UICheckBox prevInstructedUICheckBox;
        private ucContactSelectBox officerIDucContactSelectBox;
        private UserControls.ucMultiDropDown reasonCodeucMultiDropDown;
        private ucOfficeSelectBox officeIDucOfficeSelectBox;
        private Janus.Windows.EditControls.UICheckBox closedUICheckBox;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.EditControls.UIButton btnJumpToIRP;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
    }
}
