 namespace LawMate
{
    partial class fExplorer
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
                timFMHeartbeat.Tick -= new System.EventHandler(this.timFMHeartbeat_Tick);
                timFMHeartbeat.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fExplorer));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlPath = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlPathContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumber = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlLeftExplorer = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlFileExplorer = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlFileExplorerContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucBrowse1 = new LawMate.UserControls.ucBrowse();
            this.pnlChildren = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlChildrenContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucSubFileList1 = new LawMate.ucSubFileList();
            this.pnlDocViewer = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocViewerContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucRecords1 = new LawMate.ucRecords();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdJumpToFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToFile");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdPreviewDoc1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPreviewDoc");
            this.cmdToggleSubFiles1 = new Janus.Windows.UI.CommandBars.UICommand("cmdToggleSubFiles");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdPreviewDoc = new Janus.Windows.UI.CommandBars.UICommand("cmdPreviewDoc");
            this.cmdJumpToFile = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToFile");
            this.cmdExplorer = new Janus.Windows.UI.CommandBars.UICommand("cmdExplorer");
            this.cmdToggleSubFiles = new Janus.Windows.UI.CommandBars.UICommand("cmdToggleSubFiles");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdJumpToFile2 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToFile");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdClose1 = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdPreviewDoc2 = new Janus.Windows.UI.CommandBars.UICommand("cmdPreviewDoc");
            this.cmdToggleSubFiles2 = new Janus.Windows.UI.CommandBars.UICommand("cmdToggleSubFiles");
            this.cmdClose = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.uiPanel2 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel2Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlFileProps = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlFilePropsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlExplorer = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlExplorerContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.timFMHeartbeat = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPath)).BeginInit();
            this.pnlPath.SuspendLayout();
            this.pnlPathContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftExplorer)).BeginInit();
            this.pnlLeftExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileExplorer)).BeginInit();
            this.pnlFileExplorer.SuspendLayout();
            this.pnlFileExplorerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChildren)).BeginInit();
            this.pnlChildren.SuspendLayout();
            this.pnlChildrenContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocViewer)).BeginInit();
            this.pnlDocViewer.SuspendLayout();
            this.pnlDocViewerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).BeginInit();
            this.uiPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileProps)).BeginInit();
            this.pnlFileProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlExplorer)).BeginInit();
            this.pnlExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListfBase
            // 
            this.imageListfBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListfBase.ImageStream")));
            this.imageListfBase.Images.SetKeyName(0, "");
            this.imageListfBase.Images.SetKeyName(1, "");
            this.imageListfBase.Images.SetKeyName(2, "");
            this.imageListfBase.Images.SetKeyName(3, "");
            this.imageListfBase.Images.SetKeyName(4, "");
            this.imageListfBase.Images.SetKeyName(5, "");
            this.imageListfBase.Images.SetKeyName(6, "");
            this.imageListfBase.Images.SetKeyName(7, "");
            this.imageListfBase.Images.SetKeyName(8, "");
            this.imageListfBase.Images.SetKeyName(9, "");
            this.imageListfBase.Images.SetKeyName(10, "");
            this.imageListfBase.Images.SetKeyName(11, "");
            this.imageListfBase.Images.SetKeyName(12, "");
            this.imageListfBase.Images.SetKeyName(13, "");
            this.imageListfBase.Images.SetKeyName(14, "");
            this.imageListfBase.Images.SetKeyName(15, "");
            this.imageListfBase.Images.SetKeyName(16, "");
            this.imageListfBase.Images.SetKeyName(17, "");
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.uiPanelManager1_CurrentLayoutChanging);
            this.uiPanelManager1.PanelClosedChanged += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.uiPanelManager1_PanelClosedChanged);
            this.pnlPath.Id = new System.Guid("bbaf45eb-4ddc-4301-96f6-b4b794ee460a");
            this.uiPanelManager1.Panels.Add(this.pnlPath);
            this.pnlLeftExplorer.Id = new System.Guid("ca23f935-468c-423f-9824-a41e7171f659");
            this.pnlLeftExplorer.StaticGroup = true;
            this.pnlFileExplorer.Id = new System.Guid("e978fb64-c800-42a8-9f1e-380b16149de3");
            this.pnlLeftExplorer.Panels.Add(this.pnlFileExplorer);
            this.uiPanelManager1.Panels.Add(this.pnlLeftExplorer);
            this.pnlChildren.Id = new System.Guid("eb8dfb30-1196-47b3-b900-7ff73b7d08bb");
            this.uiPanelManager1.Panels.Add(this.pnlChildren);
            this.pnlDocViewer.Id = new System.Guid("47a7060e-76e4-454e-ae1a-9c7d05a3c8a7");
            this.uiPanelManager1.Panels.Add(this.pnlDocViewer);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("bbaf45eb-4ddc-4301-96f6-b4b794ee460a"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(932, 60), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ca23f935-468c-423f-9824-a41e7171f659"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(283, 548), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("e978fb64-c800-42a8-9f1e-380b16149de3"), new System.Guid("ca23f935-468c-423f-9824-a41e7171f659"), 526, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("47a7060e-76e4-454e-ae1a-9c7d05a3c8a7"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(649, 408), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("eb8dfb30-1196-47b3-b900-7ff73b7d08bb"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(649, 140), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("26eb5da3-7324-4a58-a76d-e6919ae6aea4"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("309dffe7-795c-45ce-9dd2-475101d5eafd"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("37309f4d-4634-4f14-8c13-65df68e02e67"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ca23f935-468c-423f-9824-a41e7171f659"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3ee0a561-7119-41a1-9349-4d1809213841"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e978fb64-c800-42a8-9f1e-380b16149de3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("47a7060e-76e4-454e-ae1a-9c7d05a3c8a7"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("bbaf45eb-4ddc-4301-96f6-b4b794ee460a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("eb8dfb30-1196-47b3-b900-7ff73b7d08bb"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlPath
            // 
            this.pnlPath.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlPath.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlPath.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlPath.InnerContainer = this.pnlPathContainer;
            this.pnlPath.InnerContainerFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(254)))));
            resources.ApplyResources(this.pnlPath, "pnlPath");
            this.pnlPath.Name = "pnlPath";
            this.helpProvider1.SetShowHelp(this.pnlPath, ((bool)(resources.GetObject("pnlPath.ShowHelp"))));
            // 
            // pnlPathContainer
            // 
            this.pnlPathContainer.Controls.Add(this.label2);
            this.pnlPathContainer.Controls.Add(this.tbNumber);
            this.pnlPathContainer.Controls.Add(this.label1);
            this.pnlPathContainer.Controls.Add(this.tbPath);
            resources.ApplyResources(this.pnlPathContainer, "pnlPathContainer");
            this.pnlPathContainer.Name = "pnlPathContainer";
            this.helpProvider1.SetShowHelp(this.pnlPathContainer, ((bool)(resources.GetObject("pnlPathContainer.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // tbNumber
            // 
            resources.ApplyResources(this.tbNumber, "tbNumber");
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbNumber, ((bool)(resources.GetObject("tbNumber.ShowHelp"))));
            this.tbNumber.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // tbPath
            // 
            resources.ApplyResources(this.tbPath, "tbPath");
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbPath, ((bool)(resources.GetObject("tbPath.ShowHelp"))));
            this.tbPath.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // pnlLeftExplorer
            // 
            resources.ApplyResources(this.pnlLeftExplorer, "pnlLeftExplorer");
            this.pnlLeftExplorer.Name = "pnlLeftExplorer";
            this.helpProvider1.SetShowHelp(this.pnlLeftExplorer, ((bool)(resources.GetObject("pnlLeftExplorer.ShowHelp"))));
            // 
            // pnlFileExplorer
            // 
            this.pnlFileExplorer.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlFileExplorer.InnerContainer = this.pnlFileExplorerContainer;
            resources.ApplyResources(this.pnlFileExplorer, "pnlFileExplorer");
            this.pnlFileExplorer.Name = "pnlFileExplorer";
            this.helpProvider1.SetShowHelp(this.pnlFileExplorer, ((bool)(resources.GetObject("pnlFileExplorer.ShowHelp"))));
            // 
            // pnlFileExplorerContainer
            // 
            this.pnlFileExplorerContainer.Controls.Add(this.ucBrowse1);
            resources.ApplyResources(this.pnlFileExplorerContainer, "pnlFileExplorerContainer");
            this.pnlFileExplorerContainer.Name = "pnlFileExplorerContainer";
            this.helpProvider1.SetShowHelp(this.pnlFileExplorerContainer, ((bool)(resources.GetObject("pnlFileExplorerContainer.ShowHelp"))));
            // 
            // ucBrowse1
            // 
            this.ucBrowse1.AllowDrop = true;
            this.ucBrowse1.DisplayJumpToOptions = true;
            this.ucBrowse1.DisplayOptionPanel = true;
            resources.ApplyResources(this.ucBrowse1, "ucBrowse1");
            this.ucBrowse1.HideXrefs = false;
            this.ucBrowse1.Name = "ucBrowse1";
            this.ucBrowse1.ShowContextMenu = true;
            this.ucBrowse1.ShowFileNumber = false;
            this.helpProvider1.SetShowHelp(this.ucBrowse1, ((bool)(resources.GetObject("ucBrowse1.ShowHelp"))));
            this.ucBrowse1.ShowOnlyOpenFiles = false;
            this.ucBrowse1.FileSelected += new LawMate.UserControls.BrowseEventHandler(this.ucBrowse1_FileSelected);
            this.ucBrowse1.ContextMenuClicked += new LawMate.ContextEventHandler(this.ucBrowse1_ContextMenuClicked);
            this.ucBrowse1.TreeNodeDoubleClicked += new LawMate.UserControls.TreeNodeDoubleClickEventHandler(this.ucBrowse1_TreeNodeDoubleClicked);
            // 
            // pnlChildren
            // 
            this.pnlChildren.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlChildren.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlChildren, "pnlChildren");
            this.pnlChildren.InnerContainer = this.pnlChildrenContainer;
            this.pnlChildren.Name = "pnlChildren";
            this.helpProvider1.SetShowHelp(this.pnlChildren, ((bool)(resources.GetObject("pnlChildren.ShowHelp"))));
            // 
            // pnlChildrenContainer
            // 
            this.pnlChildrenContainer.Controls.Add(this.ucSubFileList1);
            resources.ApplyResources(this.pnlChildrenContainer, "pnlChildrenContainer");
            this.pnlChildrenContainer.Name = "pnlChildrenContainer";
            this.helpProvider1.SetShowHelp(this.pnlChildrenContainer, ((bool)(resources.GetObject("pnlChildrenContainer.ShowHelp"))));
            // 
            // ucSubFileList1
            // 
            resources.ApplyResources(this.ucSubFileList1, "ucSubFileList1");
            this.ucSubFileList1.Name = "ucSubFileList1";
            this.helpProvider1.SetShowHelp(this.ucSubFileList1, ((bool)(resources.GetObject("ucSubFileList1.ShowHelp"))));
            // 
            // pnlDocViewer
            // 
            this.pnlDocViewer.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDocViewer.InnerContainer = this.pnlDocViewerContainer;
            resources.ApplyResources(this.pnlDocViewer, "pnlDocViewer");
            this.pnlDocViewer.Name = "pnlDocViewer";
            this.helpProvider1.SetShowHelp(this.pnlDocViewer, ((bool)(resources.GetObject("pnlDocViewer.ShowHelp"))));
            // 
            // pnlDocViewerContainer
            // 
            this.pnlDocViewerContainer.Controls.Add(this.ucRecords1);
            resources.ApplyResources(this.pnlDocViewerContainer, "pnlDocViewerContainer");
            this.pnlDocViewerContainer.Name = "pnlDocViewerContainer";
            this.helpProvider1.SetShowHelp(this.pnlDocViewerContainer, ((bool)(resources.GetObject("pnlDocViewerContainer.ShowHelp"))));
            // 
            // ucRecords1
            // 
            this.ucRecords1.AllowDocMetaDataUpdate = false;
            resources.ApplyResources(this.ucRecords1, "ucRecords1");
            this.ucRecords1.FM = null;
            this.ucRecords1.HideList = false;
            this.ucRecords1.Name = "ucRecords1";
            this.ucRecords1.ShowDocument = true;
            this.helpProvider1.SetShowHelp(this.ucRecords1, ((bool)(resources.GetObject("ucRecords1.ShowHelp"))));
            this.ucRecords1.ShowToolbar = false;
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
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdView1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
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
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdPreviewDoc,
            this.cmdJumpToFile,
            this.cmdExplorer,
            this.cmdToggleSubFiles,
            this.cmdFile,
            this.cmdEdit,
            this.cmdView,
            this.cmdClose});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("08c1ef62-464d-4bce-b615-a8276e1e42b5");
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
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdJumpToFile1,
            this.Separator2,
            this.cmdPreviewDoc1,
            this.cmdToggleSubFiles1,
            this.Separator3});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // cmdJumpToFile1
            // 
            resources.ApplyResources(this.cmdJumpToFile1, "cmdJumpToFile1");
            this.cmdJumpToFile1.Name = "cmdJumpToFile1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdPreviewDoc1
            // 
            resources.ApplyResources(this.cmdPreviewDoc1, "cmdPreviewDoc1");
            this.cmdPreviewDoc1.Name = "cmdPreviewDoc1";
            // 
            // cmdToggleSubFiles1
            // 
            resources.ApplyResources(this.cmdToggleSubFiles1, "cmdToggleSubFiles1");
            this.cmdToggleSubFiles1.Name = "cmdToggleSubFiles1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdPreviewDoc
            // 
            this.cmdPreviewDoc.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdPreviewDoc.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdPreviewDoc, "cmdPreviewDoc");
            this.cmdPreviewDoc.Name = "cmdPreviewDoc";
            // 
            // cmdJumpToFile
            // 
            resources.ApplyResources(this.cmdJumpToFile, "cmdJumpToFile");
            this.cmdJumpToFile.Name = "cmdJumpToFile";
            // 
            // cmdExplorer
            // 
            this.cmdExplorer.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.cmdExplorer.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdExplorer, "cmdExplorer");
            this.cmdExplorer.Name = "cmdExplorer";
            this.cmdExplorer.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.cmdExplorer.StateStyles.FormatStyle.FontName = "arial";
            // 
            // cmdToggleSubFiles
            // 
            this.cmdToggleSubFiles.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdToggleSubFiles.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdToggleSubFiles, "cmdToggleSubFiles");
            this.cmdToggleSubFiles.Name = "cmdToggleSubFiles";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdJumpToFile2,
            this.Separator1,
            this.cmdClose1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdJumpToFile2
            // 
            resources.ApplyResources(this.cmdJumpToFile2, "cmdJumpToFile2");
            this.cmdJumpToFile2.Name = "cmdJumpToFile2";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdClose1
            // 
            resources.ApplyResources(this.cmdClose1, "cmdClose1");
            this.cmdClose1.Name = "cmdClose1";
            // 
            // cmdEdit
            // 
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdPreviewDoc2,
            this.cmdToggleSubFiles2});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.Name = "cmdView";
            // 
            // cmdPreviewDoc2
            // 
            resources.ApplyResources(this.cmdPreviewDoc2, "cmdPreviewDoc2");
            this.cmdPreviewDoc2.Name = "cmdPreviewDoc2";
            // 
            // cmdToggleSubFiles2
            // 
            resources.ApplyResources(this.cmdToggleSubFiles2, "cmdToggleSubFiles2");
            this.cmdToggleSubFiles2.Name = "cmdToggleSubFiles2";
            // 
            // cmdClose
            // 
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Name = "cmdClose";
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
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdView1
            // 
            resources.ApplyResources(this.cmdView1, "cmdView1");
            this.cmdView1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView1.Name = "cmdView1";
            // 
            // uiPanel2
            // 
            this.uiPanel2.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel2.InnerContainer = this.uiPanel2Container;
            resources.ApplyResources(this.uiPanel2, "uiPanel2");
            this.uiPanel2.Name = "uiPanel2";
            this.helpProvider1.SetShowHelp(this.uiPanel2, ((bool)(resources.GetObject("uiPanel2.ShowHelp"))));
            // 
            // uiPanel2Container
            // 
            resources.ApplyResources(this.uiPanel2Container, "uiPanel2Container");
            this.uiPanel2Container.Name = "uiPanel2Container";
            this.helpProvider1.SetShowHelp(this.uiPanel2Container, ((bool)(resources.GetObject("uiPanel2Container.ShowHelp"))));
            // 
            // pnlFileProps
            // 
            this.pnlFileProps.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlFileProps.InnerContainer = this.pnlFilePropsContainer;
            resources.ApplyResources(this.pnlFileProps, "pnlFileProps");
            this.pnlFileProps.Name = "pnlFileProps";
            this.helpProvider1.SetShowHelp(this.pnlFileProps, ((bool)(resources.GetObject("pnlFileProps.ShowHelp"))));
            // 
            // pnlFilePropsContainer
            // 
            resources.ApplyResources(this.pnlFilePropsContainer, "pnlFilePropsContainer");
            this.pnlFilePropsContainer.Name = "pnlFilePropsContainer";
            this.helpProvider1.SetShowHelp(this.pnlFilePropsContainer, ((bool)(resources.GetObject("pnlFilePropsContainer.ShowHelp"))));
            // 
            // pnlExplorer
            // 
            this.pnlExplorer.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlExplorer.InnerContainer = this.pnlExplorerContainer;
            resources.ApplyResources(this.pnlExplorer, "pnlExplorer");
            this.pnlExplorer.Name = "pnlExplorer";
            this.helpProvider1.SetShowHelp(this.pnlExplorer, ((bool)(resources.GetObject("pnlExplorer.ShowHelp"))));
            // 
            // pnlExplorerContainer
            // 
            resources.ApplyResources(this.pnlExplorerContainer, "pnlExplorerContainer");
            this.pnlExplorerContainer.Name = "pnlExplorerContainer";
            this.helpProvider1.SetShowHelp(this.pnlExplorerContainer, ((bool)(resources.GetObject("pnlExplorerContainer.ShowHelp"))));
            // 
            // timFMHeartbeat
            // 
            this.timFMHeartbeat.Interval = 5000;
            this.timFMHeartbeat.Tick += new System.EventHandler(this.timFMHeartbeat_Tick);
            // 
            // fExplorer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlDocViewer);
            this.Controls.Add(this.pnlChildren);
            this.Controls.Add(this.pnlLeftExplorer);
            this.Controls.Add(this.pnlPath);
            this.Controls.Add(this.TopRebar1);
            this.MakeMdiChild = false;
            this.Name = "fExplorer";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fExplorer_FormClosing);
            this.Load += new System.EventHandler(this.fExplorer_Load);
            this.Shown += new System.EventHandler(this.fExplorer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPath)).EndInit();
            this.pnlPath.ResumeLayout(false);
            this.pnlPathContainer.ResumeLayout(false);
            this.pnlPathContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftExplorer)).EndInit();
            this.pnlLeftExplorer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileExplorer)).EndInit();
            this.pnlFileExplorer.ResumeLayout(false);
            this.pnlFileExplorerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlChildren)).EndInit();
            this.pnlChildren.ResumeLayout(false);
            this.pnlChildrenContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocViewer)).EndInit();
            this.pnlDocViewer.ResumeLayout(false);
            this.pnlDocViewerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileProps)).EndInit();
            this.pnlFileProps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlExplorer)).EndInit();
            this.pnlExplorer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel2;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel2Container;
        private ucRecords ucRecords1;
        private Janus.Windows.UI.Dock.UIPanel pnlFileProps;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlFilePropsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlExplorer;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlExplorerContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlLeftExplorer;
        private Janus.Windows.UI.Dock.UIPanel pnlFileExplorer;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlFileExplorerContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlDocViewer;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocViewerContainer;
        private UserControls.ucBrowse ucBrowse1;
        private System.Windows.Forms.Timer timFMHeartbeat;
        private Janus.Windows.UI.Dock.UIPanel pnlPath;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlPathContainer;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPreviewDoc;
        private Janus.Windows.UI.CommandBars.UICommand cmdPreviewDoc1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToFile;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox tbPath;
        private Janus.Windows.UI.CommandBars.UICommand cmdExplorer;
        private Janus.Windows.UI.Dock.UIPanel pnlChildren;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlChildrenContainer;
        private ucSubFileList ucSubFileList1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggleSubFiles1;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggleSubFiles;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose1;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToFile2;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPreviewDoc2;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggleSubFiles2;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox tbNumber;
    }
}
