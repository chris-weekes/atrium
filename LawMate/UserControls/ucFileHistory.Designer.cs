using System.Data;
 namespace LawMate
{
    partial class ucFileHistory
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
                FM.GetCLASMng().DB.FileHistory.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetCLASMng().GetFileHistory().OnUpdate -= new atLogic.UpdateEventHandler(ucFileHistory_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFileHistory));
            System.Windows.Forms.Label sentToOfficeDateLabel;
            System.Windows.Forms.Label receivedByOfficeDateLabel;
            System.Windows.Forms.Label returnedByOfficeDateLabel;
            System.Windows.Forms.Label receivedFromOfficeDateLabel;
            System.Windows.Forms.Label returnCodeLabel;
            System.Windows.Forms.Label officeCodeLabel;
            Janus.Windows.GridEX.GridEXLayout fileHistoryGridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.fileHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cLAS = new lmDatasets.CLAS();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.returnedByOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.receivedFromOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage5 = new Janus.Windows.UI.Tab.UITabPage();
            this.sentToOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.officeIducOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.receivedByOfficeDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.fileHistoryGridEX1 = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode2 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle2 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave3 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete3 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit2 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            sentToOfficeDateLabel = new System.Windows.Forms.Label();
            receivedByOfficeDateLabel = new System.Windows.Forms.Label();
            returnedByOfficeDateLabel = new System.Windows.Forms.Label();
            receivedFromOfficeDateLabel = new System.Windows.Forms.Label();
            returnCodeLabel = new System.Windows.Forms.Label();
            officeCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileHistoryGridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.fileHistoryBindingSource;
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
            // sentToOfficeDateLabel
            // 
            resources.ApplyResources(sentToOfficeDateLabel, "sentToOfficeDateLabel");
            sentToOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            sentToOfficeDateLabel.Name = "sentToOfficeDateLabel";
            this.helpProvider1.SetShowHelp(sentToOfficeDateLabel, ((bool)(resources.GetObject("sentToOfficeDateLabel.ShowHelp"))));
            // 
            // receivedByOfficeDateLabel
            // 
            resources.ApplyResources(receivedByOfficeDateLabel, "receivedByOfficeDateLabel");
            receivedByOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedByOfficeDateLabel.Name = "receivedByOfficeDateLabel";
            this.helpProvider1.SetShowHelp(receivedByOfficeDateLabel, ((bool)(resources.GetObject("receivedByOfficeDateLabel.ShowHelp"))));
            // 
            // returnedByOfficeDateLabel
            // 
            resources.ApplyResources(returnedByOfficeDateLabel, "returnedByOfficeDateLabel");
            returnedByOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            returnedByOfficeDateLabel.Name = "returnedByOfficeDateLabel";
            this.helpProvider1.SetShowHelp(returnedByOfficeDateLabel, ((bool)(resources.GetObject("returnedByOfficeDateLabel.ShowHelp"))));
            // 
            // receivedFromOfficeDateLabel
            // 
            resources.ApplyResources(receivedFromOfficeDateLabel, "receivedFromOfficeDateLabel");
            receivedFromOfficeDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedFromOfficeDateLabel.Name = "receivedFromOfficeDateLabel";
            this.helpProvider1.SetShowHelp(receivedFromOfficeDateLabel, ((bool)(resources.GetObject("receivedFromOfficeDateLabel.ShowHelp"))));
            // 
            // returnCodeLabel
            // 
            resources.ApplyResources(returnCodeLabel, "returnCodeLabel");
            returnCodeLabel.BackColor = System.Drawing.Color.Transparent;
            returnCodeLabel.Name = "returnCodeLabel";
            this.helpProvider1.SetShowHelp(returnCodeLabel, ((bool)(resources.GetObject("returnCodeLabel.ShowHelp"))));
            // 
            // officeCodeLabel
            // 
            resources.ApplyResources(officeCodeLabel, "officeCodeLabel");
            officeCodeLabel.BackColor = System.Drawing.Color.Transparent;
            officeCodeLabel.Name = "officeCodeLabel";
            this.helpProvider1.SetShowHelp(officeCodeLabel, ((bool)(resources.GetObject("officeCodeLabel.ShowHelp"))));
            // 
            // fileHistoryBindingSource
            // 
            this.fileHistoryBindingSource.DataMember = "FileHistory";
            this.fileHistoryBindingSource.DataSource = this.cLAS;
            this.fileHistoryBindingSource.CurrentChanged += new System.EventHandler(this.fileHistoryBindingSource_CurrentChanged);
            // 
            // cLAS
            // 
            this.cLAS.DataSetName = "CLAS";
            this.cLAS.EnforceConstraints = false;
            this.cLAS.Locale = new System.Globalization.CultureInfo("en-CA");
            this.cLAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(738, 390), true);
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
            this.pnlAllContainer.Controls.Add(this.uiTab2);
            this.pnlAllContainer.Controls.Add(this.fileHistoryGridEX1);
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
            this.uiTabPage3.Controls.Add(this.returnedByOfficeDateCalendarCombo);
            this.uiTabPage3.Controls.Add(returnedByOfficeDateLabel);
            this.uiTabPage3.Controls.Add(this.receivedFromOfficeDateCalendarCombo);
            this.uiTabPage3.Controls.Add(returnCodeLabel);
            this.uiTabPage3.Controls.Add(receivedFromOfficeDateLabel);
            this.uiTabPage3.Controls.Add(this.ucMultiDropDown1);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // returnedByOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.returnedByOfficeDateCalendarCombo, "returnedByOfficeDateCalendarCombo");
            this.returnedByOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileHistoryBindingSource, "ReturnedByOfficeDate", true));
            this.returnedByOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.returnedByOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.returnedByOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.returnedByOfficeDateCalendarCombo.MonthIncrement = 0;
            this.returnedByOfficeDateCalendarCombo.Name = "returnedByOfficeDateCalendarCombo";
            this.returnedByOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.returnedByOfficeDateCalendarCombo, ((bool)(resources.GetObject("returnedByOfficeDateCalendarCombo.ShowHelp"))));
            this.returnedByOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.returnedByOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // receivedFromOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.receivedFromOfficeDateCalendarCombo, "receivedFromOfficeDateCalendarCombo");
            this.receivedFromOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileHistoryBindingSource, "ReceivedFromOfficeDate", true));
            this.receivedFromOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedFromOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.receivedFromOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedFromOfficeDateCalendarCombo.MonthIncrement = 0;
            this.receivedFromOfficeDateCalendarCombo.Name = "receivedFromOfficeDateCalendarCombo";
            this.receivedFromOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.receivedFromOfficeDateCalendarCombo, ((bool)(resources.GetObject("receivedFromOfficeDateCalendarCombo.ShowHelp"))));
            this.receivedFromOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedFromOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown1.Column1 = "ReturnCode";
            resources.ApplyResources(this.ucMultiDropDown1, "ucMultiDropDown1");
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fileHistoryBindingSource, "ReturnCode", true));
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = false;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown1.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown1, ((bool)(resources.GetObject("ucMultiDropDown1.ShowHelp"))));
            this.ucMultiDropDown1.ValueMember = "ReturnCode";
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
            this.uiTabPage5});
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
            // uiTabPage5
            // 
            this.uiTabPage5.Controls.Add(sentToOfficeDateLabel);
            this.uiTabPage5.Controls.Add(this.sentToOfficeDateCalendarCombo);
            this.uiTabPage5.Controls.Add(this.officeIducOfficeSelectBox);
            this.uiTabPage5.Controls.Add(this.receivedByOfficeDateCalendarCombo);
            this.uiTabPage5.Controls.Add(officeCodeLabel);
            this.uiTabPage5.Controls.Add(receivedByOfficeDateLabel);
            resources.ApplyResources(this.uiTabPage5, "uiTabPage5");
            this.uiTabPage5.Name = "uiTabPage5";
            this.helpProvider1.SetShowHelp(this.uiTabPage5, ((bool)(resources.GetObject("uiTabPage5.ShowHelp"))));
            this.uiTabPage5.TabStop = true;
            // 
            // sentToOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.sentToOfficeDateCalendarCombo, "sentToOfficeDateCalendarCombo");
            this.sentToOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileHistoryBindingSource, "SentToOfficeDate", true));
            this.sentToOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.sentToOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.sentToOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentToOfficeDateCalendarCombo.MonthIncrement = 0;
            this.sentToOfficeDateCalendarCombo.Name = "sentToOfficeDateCalendarCombo";
            this.sentToOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.sentToOfficeDateCalendarCombo, ((bool)(resources.GetObject("sentToOfficeDateCalendarCombo.ShowHelp"))));
            this.sentToOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentToOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // officeIducOfficeSelectBox
            // 
            this.officeIducOfficeSelectBox.AtMng = null;
            this.officeIducOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIducOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.fileHistoryBindingSource, "OfficeId", true));
            resources.ApplyResources(this.officeIducOfficeSelectBox, "officeIducOfficeSelectBox");
            this.officeIducOfficeSelectBox.Name = "officeIducOfficeSelectBox";
            this.officeIducOfficeSelectBox.OfficeId = null;
            this.officeIducOfficeSelectBox.ReadOnly = false;
            this.officeIducOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.officeIducOfficeSelectBox, ((bool)(resources.GetObject("officeIducOfficeSelectBox.ShowHelp"))));
            // 
            // receivedByOfficeDateCalendarCombo
            // 
            resources.ApplyResources(this.receivedByOfficeDateCalendarCombo, "receivedByOfficeDateCalendarCombo");
            this.receivedByOfficeDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileHistoryBindingSource, "ReceivedByOfficeDate", true));
            this.receivedByOfficeDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedByOfficeDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.receivedByOfficeDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedByOfficeDateCalendarCombo.MonthIncrement = 0;
            this.receivedByOfficeDateCalendarCombo.Name = "receivedByOfficeDateCalendarCombo";
            this.receivedByOfficeDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.receivedByOfficeDateCalendarCombo, ((bool)(resources.GetObject("receivedByOfficeDateCalendarCombo.ShowHelp"))));
            this.receivedByOfficeDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedByOfficeDateCalendarCombo.YearIncrement = 0;
            // 
            // fileHistoryGridEX1
            // 
            this.fileHistoryGridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.fileHistoryGridEX1.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            resources.ApplyResources(this.fileHistoryGridEX1, "fileHistoryGridEX1");
            this.fileHistoryGridEX1.DataSource = this.fileHistoryBindingSource;
            resources.ApplyResources(fileHistoryGridEX1_DesignTimeLayout, "fileHistoryGridEX1_DesignTimeLayout");
            this.fileHistoryGridEX1.DesignTimeLayout = fileHistoryGridEX1_DesignTimeLayout;
            this.fileHistoryGridEX1.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.fileHistoryGridEX1.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.fileHistoryGridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.fileHistoryGridEX1.GroupByBoxVisible = false;
            this.fileHistoryGridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.fileHistoryGridEX1.Name = "fileHistoryGridEX1";
            this.helpProvider1.SetShowHelp(this.fileHistoryGridEX1, ((bool)(resources.GetObject("fileHistoryGridEX1.ShowHelp"))));
            this.fileHistoryGridEX1.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.fileHistoryGridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.fileHistoryGridEX1.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.fileHistoryGridEX1.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.fileHistoryGridEX1_CurrentCellChanging);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar3});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete,
            this.tsSave,
            this.tsScreenTitle,
            this.tsEditmode,
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
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.MergeRowOrder = 1;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
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
            // uiCommandBar3
            // 
            this.uiCommandBar3.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode2,
            this.tsScreenTitle2,
            this.Separator3,
            this.tsSave3,
            this.tsDelete3,
            this.Separator4,
            this.tsAudit2});
            this.uiCommandBar3.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar3.MergeRowOrder = 2;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.uiCommandBar3.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            // 
            // tsEditmode2
            // 
            resources.ApplyResources(this.tsEditmode2, "tsEditmode2");
            this.tsEditmode2.Name = "tsEditmode2";
            // 
            // tsScreenTitle2
            // 
            this.tsScreenTitle2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsScreenTitle2, "tsScreenTitle2");
            this.tsScreenTitle2.Name = "tsScreenTitle2";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // tsSave3
            // 
            resources.ApplyResources(this.tsSave3, "tsSave3");
            this.tsSave3.Name = "tsSave3";
            // 
            // tsDelete3
            // 
            resources.ApplyResources(this.tsDelete3, "tsDelete3");
            this.tsDelete3.Name = "tsDelete3";
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
            this.tsScreenTitle.StateStyles.FormatStyle.FontSize = 8F;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.ShowInCustomizeDialog = false;
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
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
            // ucFileHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucFileHistory";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucFileHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage5.ResumeLayout(false);
            this.uiTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileHistoryGridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource fileHistoryBindingSource;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.CalendarCombo.CalendarCombo sentToOfficeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedByOfficeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo returnedByOfficeDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedFromOfficeDateCalendarCombo;
        private Janus.Windows.GridEX.GridEX fileHistoryGridEX1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle2;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand tsSave3;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete3;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private ucOfficeSelectBox officeIducOfficeSelectBox;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit2;
        private UserControls.ucMultiDropDown ucMultiDropDown1;
        private lmDatasets.CLAS cLAS;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage5;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
    }
}
