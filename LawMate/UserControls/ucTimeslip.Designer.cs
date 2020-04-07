 namespace LawMate
{
    partial class ucTimeslip
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
                timeSlipGridEX.UpdateData();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTimeslip));
            Janus.Windows.GridEX.GridEXLayout sRPClientGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout sRPGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout timeSlipGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference timeSlipGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference timeSlipGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column17.ButtonImage");
            this.timeSlipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.sRPClientGridEX = new Janus.Windows.GridEX.GridEX();
            this.sRPClientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sRPGridEX = new Janus.Windows.GridEX.GridEX();
            this.sRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.pnlTab = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlActivityTime = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityTimeContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.timeSlipGridEX = new Janus.Windows.GridEX.GridEX();
            this.btnExpandCollapseNextSteps = new Janus.Windows.EditControls.UIButton();
            this.iRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdTitle1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdRefresh1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdGridSettings1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGridSettings");
            this.cmdFilter1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFilter");
            this.cmdFieldChooser1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCloseTimeSlip1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCloseTimeSlip");
            this.cmdTitle = new Janus.Windows.UI.CommandBars.UICommand("cmdTitle");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdCloseTimeSlip = new Janus.Windows.UI.CommandBars.UICommand("cmdCloseTimeSlip");
            this.cmdFilter = new Janus.Windows.UI.CommandBars.UICommand("cmdFilter");
            this.cmdFieldChooser = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.cmdRefresh = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdFilter2 = new Janus.Windows.UI.CommandBars.UICommand("cmdFilter");
            this.cmdFieldChooser2 = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.cmdGridSettings2 = new Janus.Windows.UI.CommandBars.UICommand("cmdGridSettings");
            this.cmdRefresh2 = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.cmdCloseTimeSlip2 = new Janus.Windows.UI.CommandBars.UICommand("cmdCloseTimeSlip");
            this.cmdGridSettings = new Janus.Windows.UI.CommandBars.UICommand("cmdGridSettings");
            this.cmdStoreLayout3 = new Janus.Windows.UI.CommandBars.UICommand("cmdStoreLayout");
            this.cmdSetLayout1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSetLayout");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdResetGridToAppLayout1 = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGridToAppLayout");
            this.cmdStoreLayout = new Janus.Windows.UI.CommandBars.UICommand("cmdStoreLayout");
            this.cmdSetLayout = new Janus.Windows.UI.CommandBars.UICommand("cmdSetLayout");
            this.cmdResetGridToAppLayout = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGridToAppLayout");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSlipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRPClientGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRPClientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRPGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).BeginInit();
            this.pnlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityTime)).BeginInit();
            this.pnlActivityTime.SuspendLayout();
            this.pnlActivityTimeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSlipGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iRPBindingSource)).BeginInit();
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
            // timeSlipBindingSource
            // 
            this.timeSlipBindingSource.DataMember = "TimeSlip";
            this.timeSlipBindingSource.DataSource = this.appDB;
            this.timeSlipBindingSource.CurrentChanged += new System.EventHandler(this.timeSlipBindingSource_CurrentChanged);
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("5eed214b-5da4-4ad3-ac0e-f76f303ebfc0");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            this.pnlTab.Id = new System.Guid("e6af5cbc-9e17-42a8-acd2-431c6750b4e4");
            this.pnlTab.StaticGroup = true;
            this.pnlActivityTime.Id = new System.Guid("25aef546-25f6-411b-8e8f-4d1a8b5e212a");
            this.pnlTab.Panels.Add(this.pnlActivityTime);
            this.uiPanelManager1.Panels.Add(this.pnlTab);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("e6af5cbc-9e17-42a8-acd2-431c6750b4e4"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(891, 583), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("25aef546-25f6-411b-8e8f-4d1a8b5e212a"), new System.Guid("e6af5cbc-9e17-42a8-acd2-431c6750b4e4"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5eed214b-5da4-4ad3-ac0e-f76f303ebfc0"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(891, 152), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5eed214b-5da4-4ad3-ac0e-f76f303ebfc0"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e6af5cbc-9e17-42a8-acd2-431c6750b4e4"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("4a72ef53-523b-485f-ac91-91a4c1f36575"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("25aef546-25f6-411b-8e8f-4d1a8b5e212a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1ab93962-cff6-4692-9396-079e7046712e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.sRPClientGridEX);
            this.pnlAllContainer.Controls.Add(this.sRPGridEX);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // sRPClientGridEX
            // 
            this.sRPClientGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            resources.ApplyResources(this.sRPClientGridEX, "sRPClientGridEX");
            this.sRPClientGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.sRPClientGridEX.DataSource = this.sRPClientBindingSource;
            resources.ApplyResources(sRPClientGridEX_DesignTimeLayout, "sRPClientGridEX_DesignTimeLayout");
            this.sRPClientGridEX.DesignTimeLayout = sRPClientGridEX_DesignTimeLayout;
            this.sRPClientGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.sRPClientGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.sRPClientGridEX.GroupByBoxVisible = false;
            this.sRPClientGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.sRPClientGridEX.Name = "sRPClientGridEX";
            this.helpProvider1.SetShowHelp(this.sRPClientGridEX, ((bool)(resources.GetObject("sRPClientGridEX.ShowHelp"))));
            this.sRPClientGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.sRPClientGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.sRPClientGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.sRPClientGridEX_FormattingRow);
            // 
            // sRPClientBindingSource
            // 
            this.sRPClientBindingSource.DataMember = "SRPClient";
            this.sRPClientBindingSource.DataSource = this.appDB;
            // 
            // sRPGridEX
            // 
            this.sRPGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.sRPGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.sRPGridEX.DataSource = this.sRPBindingSource;
            resources.ApplyResources(sRPGridEX_DesignTimeLayout, "sRPGridEX_DesignTimeLayout");
            this.sRPGridEX.DesignTimeLayout = sRPGridEX_DesignTimeLayout;
            this.sRPGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.sRPGridEX, "sRPGridEX");
            this.sRPGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.sRPGridEX.GroupByBoxVisible = false;
            this.sRPGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.sRPGridEX.KeepRowSettings = true;
            this.sRPGridEX.Name = "sRPGridEX";
            this.helpProvider1.SetShowHelp(this.sRPGridEX, ((bool)(resources.GetObject("sRPGridEX.ShowHelp"))));
            this.sRPGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.sRPGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.sRPGridEX.WatermarkImage.Alpha = 60;
            this.sRPGridEX.WatermarkImage.Image = ((System.Drawing.Image)(resources.GetObject("sRPGridEX.WatermarkImage.Image")));
            this.sRPGridEX.WatermarkImage.WashColor = System.Drawing.Color.Blue;
            this.sRPGridEX.WatermarkImage.WashMode = Janus.Windows.GridEX.WashMode.UseWashColor;
            this.sRPGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.sRPGridEX_FormattingRow);
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
            // pnlTab
            // 
            this.pnlTab.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            resources.ApplyResources(this.pnlTab, "pnlTab");
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.SelectedPanel = this.pnlActivityTime;
            this.helpProvider1.SetShowHelp(this.pnlTab, ((bool)(resources.GetObject("pnlTab.ShowHelp"))));
            this.pnlTab.TabAlignment = Janus.Windows.UI.Dock.TabAlignment.Top;
            this.pnlTab.TabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.ImageAndText;
            // 
            // pnlActivityTime
            // 
            this.pnlActivityTime.InnerContainer = this.pnlActivityTimeContainer;
            resources.ApplyResources(this.pnlActivityTime, "pnlActivityTime");
            this.pnlActivityTime.Name = "pnlActivityTime";
            this.helpProvider1.SetShowHelp(this.pnlActivityTime, ((bool)(resources.GetObject("pnlActivityTime.ShowHelp"))));
            // 
            // pnlActivityTimeContainer
            // 
            this.pnlActivityTimeContainer.Controls.Add(this.timeSlipGridEX);
            this.pnlActivityTimeContainer.Controls.Add(this.btnExpandCollapseNextSteps);
            resources.ApplyResources(this.pnlActivityTimeContainer, "pnlActivityTimeContainer");
            this.pnlActivityTimeContainer.Name = "pnlActivityTimeContainer";
            this.helpProvider1.SetShowHelp(this.pnlActivityTimeContainer, ((bool)(resources.GetObject("pnlActivityTimeContainer.ShowHelp"))));
            // 
            // timeSlipGridEX
            // 
            this.timeSlipGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            resources.ApplyResources(this.timeSlipGridEX, "timeSlipGridEX");
            this.timeSlipGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.timeSlipGridEX.DataSource = this.timeSlipBindingSource;
            timeSlipGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("timeSlipGridEX_DesignTimeLayout_Reference_0.Instance")));
            timeSlipGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("timeSlipGridEX_DesignTimeLayout_Reference_1.Instance")));
            timeSlipGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            timeSlipGridEX_DesignTimeLayout_Reference_0,
            timeSlipGridEX_DesignTimeLayout_Reference_1});
            resources.ApplyResources(timeSlipGridEX_DesignTimeLayout, "timeSlipGridEX_DesignTimeLayout");
            this.timeSlipGridEX.DesignTimeLayout = timeSlipGridEX_DesignTimeLayout;
            this.timeSlipGridEX.DynamicFiltering = true;
            this.timeSlipGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.timeSlipGridEX.FilterRowFormatStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.timeSlipGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.timeSlipGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.timeSlipGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.timeSlipGridEX.GroupRowFormatStyle.FontName = "arial";
            this.timeSlipGridEX.GroupRowFormatStyle.FontSize = 8F;
            this.timeSlipGridEX.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.timeSlipGridEX.GroupRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Empty;
            this.timeSlipGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.timeSlipGridEX.Name = "timeSlipGridEX";
            this.helpProvider1.SetShowHelp(this.timeSlipGridEX, ((bool)(resources.GetObject("timeSlipGridEX.ShowHelp"))));
            this.timeSlipGridEX.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.timeSlipGridEX.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
            this.timeSlipGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.timeSlipGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.timeSlipGridEX.WatermarkImage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.timeSlipGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.timeSlipGridEX_FormattingRow);
            this.timeSlipGridEX.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.timeSlipGridEX_CellUpdated);
            this.timeSlipGridEX.GroupsChanged += new Janus.Windows.GridEX.GroupsChangedEventHandler(this.timeSlipGridEX_GroupsChanged);
            this.timeSlipGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.timeSlipGridEX_ColumnButtonClick);
            this.timeSlipGridEX.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.timeSlipGridEX_CurrentLayoutChanging);
            this.timeSlipGridEX.DoubleClick += new System.EventHandler(this.timeSlipGridEX_DoubleClick);
            this.timeSlipGridEX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timeSlipGridEX_KeyDown);
            // 
            // btnExpandCollapseNextSteps
            // 
            resources.ApplyResources(this.btnExpandCollapseNextSteps, "btnExpandCollapseNextSteps");
            this.btnExpandCollapseNextSteps.Image = global::LawMate.Properties.Resources.ExpandAllSteps2;
            this.btnExpandCollapseNextSteps.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Far;
            this.btnExpandCollapseNextSteps.Name = "btnExpandCollapseNextSteps";
            this.btnExpandCollapseNextSteps.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnExpandCollapseNextSteps, ((bool)(resources.GetObject("btnExpandCollapseNextSteps.ShowHelp"))));
            this.btnExpandCollapseNextSteps.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnExpandCollapseNextSteps.Click += new System.EventHandler(this.btnExpandCollapseNextSteps_Click);
            // 
            // iRPBindingSource
            // 
            this.iRPBindingSource.DataMember = "IRP";
            this.iRPBindingSource.DataSource = this.atriumDB;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdTitle,
            this.cmdSave,
            this.cmdCancel,
            this.cmdCloseTimeSlip,
            this.cmdFilter,
            this.cmdFieldChooser,
            this.cmdRefresh,
            this.cmdView,
            this.cmdTools,
            this.cmdGridSettings,
            this.cmdStoreLayout,
            this.cmdSetLayout,
            this.cmdResetGridToAppLayout});
            this.uiCommandManager1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("f9bffc7a-e097-440c-bea7-565ea85b1589");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
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
            this.cmdView1,
            this.cmdTools1});
            this.uiCommandBar2.FullRow = true;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
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
            this.cmdTitle1,
            this.Separator1,
            this.cmdRefresh1,
            this.Separator3,
            this.cmdGridSettings1,
            this.cmdFilter1,
            this.cmdFieldChooser1,
            this.Separator2,
            this.cmdCloseTimeSlip1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // cmdTitle1
            // 
            resources.ApplyResources(this.cmdTitle1, "cmdTitle1");
            this.cmdTitle1.Name = "cmdTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdRefresh1
            // 
            resources.ApplyResources(this.cmdRefresh1, "cmdRefresh1");
            this.cmdRefresh1.Name = "cmdRefresh1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdGridSettings1
            // 
            this.cmdGridSettings1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdGridSettings1, "cmdGridSettings1");
            this.cmdGridSettings1.Name = "cmdGridSettings1";
            // 
            // cmdFilter1
            // 
            resources.ApplyResources(this.cmdFilter1, "cmdFilter1");
            this.cmdFilter1.Name = "cmdFilter1";
            // 
            // cmdFieldChooser1
            // 
            resources.ApplyResources(this.cmdFieldChooser1, "cmdFieldChooser1");
            this.cmdFieldChooser1.Name = "cmdFieldChooser1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdCloseTimeSlip1
            // 
            this.cmdCloseTimeSlip1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdCloseTimeSlip1, "cmdCloseTimeSlip1");
            this.cmdCloseTimeSlip1.Name = "cmdCloseTimeSlip1";
            // 
            // cmdTitle
            // 
            this.cmdTitle.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdTitle, "cmdTitle");
            this.cmdTitle.Name = "cmdTitle";
            this.cmdTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.cmdTitle.StateStyles.FormatStyle.FontName = "tahoma";
            this.cmdTitle.StateStyles.FormatStyle.FontSize = 8F;
            // 
            // cmdSave
            // 
            this.cmdSave.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.cmdSave, "cmdSave");
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.TagString = "";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            // 
            // cmdCloseTimeSlip
            // 
            resources.ApplyResources(this.cmdCloseTimeSlip, "cmdCloseTimeSlip");
            this.cmdCloseTimeSlip.Name = "cmdCloseTimeSlip";
            // 
            // cmdFilter
            // 
            this.cmdFilter.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdFilter.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdFilter.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdFilter, "cmdFilter");
            this.cmdFilter.Name = "cmdFilter";
            // 
            // cmdFieldChooser
            // 
            this.cmdFieldChooser.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdFieldChooser, "cmdFieldChooser");
            this.cmdFieldChooser.Name = "cmdFieldChooser";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdRefresh, "cmdRefresh");
            this.cmdRefresh.Name = "cmdRefresh";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFilter2,
            this.cmdFieldChooser2});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView.Name = "cmdView";
            // 
            // cmdFilter2
            // 
            resources.ApplyResources(this.cmdFilter2, "cmdFilter2");
            this.cmdFilter2.Name = "cmdFilter2";
            // 
            // cmdFieldChooser2
            // 
            resources.ApplyResources(this.cmdFieldChooser2, "cmdFieldChooser2");
            this.cmdFieldChooser2.Name = "cmdFieldChooser2";
            // 
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdGridSettings2,
            this.cmdRefresh2,
            this.cmdCloseTimeSlip2});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdTools.Name = "cmdTools";
            // 
            // cmdGridSettings2
            // 
            resources.ApplyResources(this.cmdGridSettings2, "cmdGridSettings2");
            this.cmdGridSettings2.Name = "cmdGridSettings2";
            // 
            // cmdRefresh2
            // 
            resources.ApplyResources(this.cmdRefresh2, "cmdRefresh2");
            this.cmdRefresh2.Name = "cmdRefresh2";
            // 
            // cmdCloseTimeSlip2
            // 
            resources.ApplyResources(this.cmdCloseTimeSlip2, "cmdCloseTimeSlip2");
            this.cmdCloseTimeSlip2.Name = "cmdCloseTimeSlip2";
            // 
            // cmdGridSettings
            // 
            this.cmdGridSettings.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdStoreLayout3,
            this.cmdSetLayout1,
            this.Separator4,
            this.cmdResetGridToAppLayout1});
            this.cmdGridSettings.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdGridSettings, "cmdGridSettings");
            this.cmdGridSettings.Name = "cmdGridSettings";
            // 
            // cmdStoreLayout3
            // 
            resources.ApplyResources(this.cmdStoreLayout3, "cmdStoreLayout3");
            this.cmdStoreLayout3.Name = "cmdStoreLayout3";
            // 
            // cmdSetLayout1
            // 
            resources.ApplyResources(this.cmdSetLayout1, "cmdSetLayout1");
            this.cmdSetLayout1.Name = "cmdSetLayout1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdResetGridToAppLayout1
            // 
            resources.ApplyResources(this.cmdResetGridToAppLayout1, "cmdResetGridToAppLayout1");
            this.cmdResetGridToAppLayout1.Name = "cmdResetGridToAppLayout1";
            // 
            // cmdStoreLayout
            // 
            resources.ApplyResources(this.cmdStoreLayout, "cmdStoreLayout");
            this.cmdStoreLayout.Name = "cmdStoreLayout";
            // 
            // cmdSetLayout
            // 
            resources.ApplyResources(this.cmdSetLayout, "cmdSetLayout");
            this.cmdSetLayout.Name = "cmdSetLayout";
            // 
            // cmdResetGridToAppLayout
            // 
            resources.ApplyResources(this.cmdResetGridToAppLayout, "cmdResetGridToAppLayout");
            this.cmdResetGridToAppLayout.Name = "cmdResetGridToAppLayout";
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
            // ucTimeslip
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucTimeslip";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucTimeslip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSlipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sRPClientGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRPClientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRPGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).EndInit();
            this.pnlTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityTime)).EndInit();
            this.pnlActivityTime.ResumeLayout(false);
            this.pnlActivityTimeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeSlipGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iRPBindingSource)).EndInit();
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
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTitle;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private System.Windows.Forms.BindingSource sRPBindingSource;
        private Janus.Windows.GridEX.GridEX sRPGridEX;
        private Janus.Windows.UI.CommandBars.UICommand cmdCloseTimeSlip;
        private Janus.Windows.UI.CommandBars.UICommand cmdCloseTimeSlip1;
        private System.Windows.Forms.BindingSource iRPBindingSource;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlTab;
        private Janus.Windows.UI.Dock.UIPanel pnlActivityTime;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityTimeContainer;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.GridEX.GridEX timeSlipGridEX;
        private System.Windows.Forms.BindingSource timeSlipBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.UI.CommandBars.UICommand cmdFilter;
        private Janus.Windows.UI.CommandBars.UICommand cmdFilter1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh1;
        private Janus.Windows.GridEX.GridEX sRPClientGridEX;
        private System.Windows.Forms.BindingSource sRPClientBindingSource;
        private Janus.Windows.EditControls.UIButton btnExpandCollapseNextSteps;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdFilter2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser2;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCloseTimeSlip2;
        private Janus.Windows.UI.CommandBars.UICommand cmdStoreLayout;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridSettings;
        private Janus.Windows.UI.CommandBars.UICommand cmdSetLayout;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridSettings2;
        private Janus.Windows.UI.CommandBars.UICommand cmdStoreLayout3;
        private Janus.Windows.UI.CommandBars.UICommand cmdSetLayout1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGridToAppLayout1;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGridToAppLayout;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridSettings1;
        private lmDatasets.atriumDB atriumDB;
    }
}
