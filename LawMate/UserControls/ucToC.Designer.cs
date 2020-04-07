 namespace LawMate
{
    partial class ucToC
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

                fmCurrent.EFile.OnUpdate -= new atLogic.UpdateEventHandler(EFile_OnUpdate);
                fmCurrent.GetFileXRef().OnUpdate -= new atLogic.UpdateEventHandler(ucToC_OnUpdate);
                
                fmCurrent = null;
                Atmng=null;
                ParentFile=null;


                components.Dispose();

            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucToC));
            this.tvContents = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageListStatus = new System.Windows.Forms.ImageList(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlDockTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDockTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.flpParentLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFilenameValue = new System.Windows.Forms.Label();
            this.lblFullNumber = new System.Windows.Forms.Label();
            this.lblFullNumberValue = new System.Windows.Forms.Label();
            this.lblSharedFolder = new System.Windows.Forms.Label();
            this.lnkSharedFolder = new System.Windows.Forms.LinkLabel();
            this.lblProgram = new System.Windows.Forms.Label();
            this.lblProgramValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblOwnerOffice = new System.Windows.Forms.Label();
            this.lnkJumpToOwnerFile = new System.Windows.Forms.LinkLabel();
            this.lblLeadOffice = new System.Windows.Forms.Label();
            this.lnkJumpToLeadFile = new System.Windows.Forms.LinkLabel();
            this.lblStatusDate = new System.Windows.Forms.Label();
            this.lblStatusDateValue = new System.Windows.Forms.Label();
            this.lblCaseStatus = new System.Windows.Forms.Label();
            this.lblCaseStatusValue = new System.Windows.Forms.Label();
            this.lnkSINLabel = new System.Windows.Forms.LinkLabel();
            this.lblSINValue = new System.Windows.Forms.Label();
            this.lblParalegal = new System.Windows.Forms.Label();
            this.lblParaLegalValue = new System.Windows.Forms.Label();
            this.pnlTab = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlMetaToc = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlTofC = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTofCContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBrowseFiles = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlSubFiles = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSubFilesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucBrowse1 = new LawMate.UserControls.ucBrowse();
            this.pnlXRefs = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlXRefsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdJumpToParent = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToParent");
            this.cmdJumpToExplorer = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToExplorer");
            this.cmdImportantMessage = new Janus.Windows.UI.CommandBars.UICommand("cmdImportantMessage");
            this.cmdPin = new Janus.Windows.UI.CommandBars.UICommand("cmdPin");
            this.cmdAddShortcut = new Janus.Windows.UI.CommandBars.UICommand("cmdAddShortcut");
            this.cmdAddXref = new Janus.Windows.UI.CommandBars.UICommand("cmdAddXref");
            this.cmdReloadFileData = new Janus.Windows.UI.CommandBars.UICommand("cmdReloadFileData");
            this.cmdLoadXrefData = new Janus.Windows.UI.CommandBars.UICommand("cmdLoadXrefData");
            this.cmdSelectAll = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectAll");
            this.cmdDeselectAll = new Janus.Windows.UI.CommandBars.UICommand("cmdDeselectAll");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdSelectAll1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectAll");
            this.cmdDeselectAll1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDeselectAll");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdLoadXrefData1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLoadXrefData");
            this.pnlTableOfContents = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTableOfContentsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlFileMetaData = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlFileMetaDataContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDockTop)).BeginInit();
            this.pnlDockTop.SuspendLayout();
            this.pnlDockTopContainer.SuspendLayout();
            this.flpParentLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).BeginInit();
            this.pnlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMetaToc)).BeginInit();
            this.pnlMetaToc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTofC)).BeginInit();
            this.pnlTofC.SuspendLayout();
            this.pnlTofCContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseFiles)).BeginInit();
            this.pnlBrowseFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSubFiles)).BeginInit();
            this.pnlSubFiles.SuspendLayout();
            this.pnlSubFilesContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlXRefs)).BeginInit();
            this.pnlXRefs.SuspendLayout();
            this.pnlXRefsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTableOfContents)).BeginInit();
            this.pnlTableOfContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileMetaData)).BeginInit();
            this.pnlFileMetaData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvContents
            // 
            resources.ApplyResources(this.tvContents, "tvContents");
            this.tvContents.BackColor = System.Drawing.SystemColors.Window;
            this.tvContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvContents.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvContents.ImageList = this.imageList1;
            this.tvContents.ItemHeight = 18;
            this.tvContents.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tvContents.Name = "tvContents";
            this.tvContents.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("tvContents.Nodes")))});
            this.tvContents.ShowNodeToolTips = true;
            this.tvContents.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvContents_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.gif");
            this.imageList1.Images.SetKeyName(1, "folder.gif");
            this.imageList1.Images.SetKeyName(2, "cbProcess.gif");
            this.imageList1.Images.SetKeyName(3, "bs.gif");
            this.imageList1.Images.SetKeyName(4, "cbProcess.gif");
            this.imageList1.Images.SetKeyName(5, "bo.gif");
            this.imageList1.Images.SetKeyName(6, "priorityUrgent.gif");
            this.imageList1.Images.SetKeyName(7, "fileShortcuts.gif");
            this.imageList1.Images.SetKeyName(8, "lawmateExplorer.gif");
            this.imageList1.Images.SetKeyName(9, "screen.gif");
            this.imageList1.Images.SetKeyName(10, "FileImportantMessage.gif");
            this.imageList1.Images.SetKeyName(11, "parentFile.gif");
            this.imageList1.Images.SetKeyName(12, "pin.gif");
            this.imageList1.Images.SetKeyName(13, "pin2.gif");
            this.imageList1.Images.SetKeyName(14, "filetoc.gif");
            this.imageList1.Images.SetKeyName(15, "XRefFile.gif");
            this.imageList1.Images.SetKeyName(16, "ShortcutFile.gif");
            this.imageList1.Images.SetKeyName(17, "AddXref.gif");
            this.imageList1.Images.SetKeyName(18, "reload.gif");
            this.imageList1.Images.SetKeyName(19, "relInfoNewRecord.gif");
            this.imageList1.Images.SetKeyName(20, "docShortcut.gif");
            this.imageList1.Images.SetKeyName(21, "fileShortcut.png");
            this.imageList1.Images.SetKeyName(22, "form.png");
            this.imageList1.Images.SetKeyName(23, "tocPage.png");
            this.imageList1.Images.SetKeyName(24, "folder.png");
            this.imageList1.Images.SetKeyName(25, "application_form.png");
            this.imageList1.Images.SetKeyName(26, "hourglassPending.png");
            this.imageList1.Images.SetKeyName(27, "appellant.png");
            this.imageList1.Images.SetKeyName(28, "officebuilding.png");
            this.imageList1.Images.SetKeyName(29, "RecipientUnknown.png");
            this.imageList1.Images.SetKeyName(30, "RecipientOfficer2.png");
            this.imageList1.Images.SetKeyName(31, "respondent.png");
            this.imageList1.Images.SetKeyName(32, "isparty.png");
            this.imageList1.Images.SetKeyName(33, "iconExcel.png");
            this.imageList1.Images.SetKeyName(34, "canada.png");
            this.imageList1.Images.SetKeyName(35, "usa.png");
            this.imageList1.Images.SetKeyName(36, "globe.png");
            this.imageList1.Images.SetKeyName(37, "tocArchivedSM.gif");
            this.imageList1.Images.SetKeyName(38, "tocClosedSM.gif");
            this.imageList1.Images.SetKeyName(39, "tocMonitoredSM.gif");
            this.imageList1.Images.SetKeyName(40, "tocOpenSM.gif");
            this.imageList1.Images.SetKeyName(41, "tocPendingSM.gif");
            this.imageList1.Images.SetKeyName(42, "atriumtrans16.png");
            this.imageList1.Images.SetKeyName(43, "User3.png");
            // 
            // imageListStatus
            // 
            this.imageListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStatus.ImageStream")));
            this.imageListStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListStatus.Images.SetKeyName(0, "FSPending.ico");
            this.imageListStatus.Images.SetKeyName(1, "FSOpen.ico");
            this.imageListStatus.Images.SetKeyName(2, "FSMonitored.ico");
            this.imageListStatus.Images.SetKeyName(3, "FSClosed.ico");
            this.imageListStatus.Images.SetKeyName(4, "FSArchived.ico");
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.ForeColor = System.Drawing.Color.LightSlateGray;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.LightSlateGray;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.HotFormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.HotFormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.PressedFormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.PressedFormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.SelectedFormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.SelectedFormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiPanelManager1.ImageList = this.imageList1;
            resources.ApplyResources(this.uiPanelManager1, "uiPanelManager1");
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 2;
            this.uiPanelManager1.TabbedMdiSettings.AllowDrag = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.AllowDrag")));
            this.uiPanelManager1.TabbedMdiSettings.MaxTabSize = ((int)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.MaxTabSize")));
            this.uiPanelManager1.TabbedMdiSettings.ShowCloseButton = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.ShowCloseButton")));
            this.uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming = ((System.Drawing.StringTrimming)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming")));
            this.uiPanelManager1.TabbedMdiSettings.UseFormIcons = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.UseFormIcons")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.PanelAutoHideChanging += new Janus.Windows.UI.Dock.PanelActionCancelEventHandler(this.uiPanelManager1_PanelAutoHideChanging);
            this.pnlDockTop.Id = new System.Guid("95a40353-a756-46a9-ae46-1b4b58f98d09");
            this.uiPanelManager1.Panels.Add(this.pnlDockTop);
            this.pnlTab.Id = new System.Guid("b995a672-fa96-4940-9f72-5090e5d974b9");
            this.pnlTab.StaticGroup = true;
            this.pnlMetaToc.Id = new System.Guid("3ab511fb-f7e8-4d4e-9b80-2ba2010bab5c");
            this.pnlMetaToc.StaticGroup = true;
            this.pnlTofC.Id = new System.Guid("93432359-4871-4610-a0d7-305018d73332");
            this.pnlMetaToc.Panels.Add(this.pnlTofC);
            this.pnlTab.Panels.Add(this.pnlMetaToc);
            this.pnlBrowseFiles.Id = new System.Guid("0a288ea1-9200-4310-ab60-65d7040996ff");
            this.pnlBrowseFiles.StaticGroup = true;
            this.pnlSubFiles.Id = new System.Guid("b0a43a9a-2940-421a-9d1c-8d52ef8b3e21");
            this.pnlBrowseFiles.Panels.Add(this.pnlSubFiles);
            this.pnlTab.Panels.Add(this.pnlBrowseFiles);
            this.pnlXRefs.Id = new System.Guid("98eb3a20-4bb1-4bf5-b9e1-cd7303727034");
            this.pnlTab.Panels.Add(this.pnlXRefs);
            this.uiPanelManager1.Panels.Add(this.pnlTab);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("95a40353-a756-46a9-ae46-1b4b58f98d09"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(397, 172), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b995a672-fa96-4940-9f72-5090e5d974b9"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(397, 374), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("3ab511fb-f7e8-4d4e-9b80-2ba2010bab5c"), new System.Guid("b995a672-fa96-4940-9f72-5090e5d974b9"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("93432359-4871-4610-a0d7-305018d73332"), new System.Guid("3ab511fb-f7e8-4d4e-9b80-2ba2010bab5c"), 488, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("0a288ea1-9200-4310-ab60-65d7040996ff"), new System.Guid("b995a672-fa96-4940-9f72-5090e5d974b9"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b0a43a9a-2940-421a-9d1c-8d52ef8b3e21"), new System.Guid("0a288ea1-9200-4310-ab60-65d7040996ff"), 611, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("98eb3a20-4bb1-4bf5-b9e1-cd7303727034"), new System.Guid("b995a672-fa96-4940-9f72-5090e5d974b9"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7d600115-222d-4c50-804e-aeb114ca0aa1"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Bottom, true, new System.Drawing.Size(978, 200), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1986ac96-fb9c-498f-b5a1-e2580bfdde88"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ee1b75fb-eac2-4256-b44f-549dc8d7c45b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b995a672-fa96-4940-9f72-5090e5d974b9"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3ab511fb-f7e8-4d4e-9b80-2ba2010bab5c"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("171b0236-5820-43da-9f80-4d2f818dc4a8"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("93432359-4871-4610-a0d7-305018d73332"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0a288ea1-9200-4310-ab60-65d7040996ff"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("fca771e3-cb60-4e36-834b-6b0f2cb97625"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b0a43a9a-2940-421a-9d1c-8d52ef8b3e21"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("98eb3a20-4bb1-4bf5-b9e1-cd7303727034"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("95a40353-a756-46a9-ae46-1b4b58f98d09"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("38e83a5f-1def-4c14-882c-4edd90311e6d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlDockTop
            // 
            resources.ApplyResources(this.pnlDockTop, "pnlDockTop");
            this.pnlDockTop.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDockTop.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDockTop.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlDockTop.CaptionFormatStyle.FontName = "calibri";
            this.pnlDockTop.CaptionFormatStyle.FontSize = 8F;
            this.pnlDockTop.CaptionFormatStyle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.pnlDockTop.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Standard;
            this.pnlDockTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlDockTop.InnerContainer = this.pnlDockTopContainer;
            this.pnlDockTop.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDockTop.InnerContainerFormatStyle.BackColorGradient = System.Drawing.SystemColors.Window;
            this.pnlDockTop.InnerContainerFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Diagonal;
            this.pnlDockTop.InnerContainerFormatStyle.BlendGradient = 0.2F;
            this.pnlDockTop.Name = "pnlDockTop";
            // 
            // pnlDockTopContainer
            // 
            resources.ApplyResources(this.pnlDockTopContainer, "pnlDockTopContainer");
            this.pnlDockTopContainer.Controls.Add(this.flpParentLayout);
            this.pnlDockTopContainer.Name = "pnlDockTopContainer";
            // 
            // flpParentLayout
            // 
            resources.ApplyResources(this.flpParentLayout, "flpParentLayout");
            this.flpParentLayout.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.Controls.Add(this.lblFileName);
            this.flpParentLayout.Controls.Add(this.lblFilenameValue);
            this.flpParentLayout.Controls.Add(this.lblFullNumber);
            this.flpParentLayout.Controls.Add(this.lblFullNumberValue);
            this.flpParentLayout.Controls.Add(this.lblSharedFolder);
            this.flpParentLayout.Controls.Add(this.lnkSharedFolder);
            this.flpParentLayout.Controls.Add(this.lblProgram);
            this.flpParentLayout.Controls.Add(this.lblProgramValue);
            this.flpParentLayout.Controls.Add(this.lblStatus);
            this.flpParentLayout.Controls.Add(this.lblStatusValue);
            this.flpParentLayout.Controls.Add(this.lblType);
            this.flpParentLayout.Controls.Add(this.lblTypeValue);
            this.flpParentLayout.Controls.Add(this.lblOwnerOffice);
            this.flpParentLayout.Controls.Add(this.lnkJumpToOwnerFile);
            this.flpParentLayout.Controls.Add(this.lblLeadOffice);
            this.flpParentLayout.Controls.Add(this.lnkJumpToLeadFile);
            this.flpParentLayout.Controls.Add(this.lblStatusDate);
            this.flpParentLayout.Controls.Add(this.lblStatusDateValue);
            this.flpParentLayout.Controls.Add(this.lblCaseStatus);
            this.flpParentLayout.Controls.Add(this.lblCaseStatusValue);
            this.flpParentLayout.Controls.Add(this.lnkSINLabel);
            this.flpParentLayout.Controls.Add(this.lblSINValue);
            this.flpParentLayout.Controls.Add(this.lblParalegal);
            this.flpParentLayout.Controls.Add(this.lblParaLegalValue);
            this.flpParentLayout.Name = "flpParentLayout";
            // 
            // lblFileName
            // 
            resources.ApplyResources(this.lblFileName, "lblFileName");
            this.lblFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblFileName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFileName.ForeColor = System.Drawing.Color.Blue;
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Click += new System.EventHandler(this.lblFileName_Click);
            // 
            // lblFilenameValue
            // 
            resources.ApplyResources(this.lblFilenameValue, "lblFilenameValue");
            this.lblFilenameValue.AutoEllipsis = true;
            this.lblFilenameValue.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lblFilenameValue, true);
            this.lblFilenameValue.Name = "lblFilenameValue";
            // 
            // lblFullNumber
            // 
            resources.ApplyResources(this.lblFullNumber, "lblFullNumber");
            this.lblFullNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblFullNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFullNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblFullNumber.Name = "lblFullNumber";
            this.lblFullNumber.Click += new System.EventHandler(this.lblFullNumber_Click);
            // 
            // lblFullNumberValue
            // 
            resources.ApplyResources(this.lblFullNumberValue, "lblFullNumberValue");
            this.lblFullNumberValue.AutoEllipsis = true;
            this.lblFullNumberValue.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lblFullNumberValue, true);
            this.lblFullNumberValue.Name = "lblFullNumberValue";
            // 
            // lblSharedFolder
            // 
            resources.ApplyResources(this.lblSharedFolder, "lblSharedFolder");
            this.lblSharedFolder.BackColor = System.Drawing.Color.Transparent;
            this.lblSharedFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSharedFolder.Name = "lblSharedFolder";
            // 
            // lnkSharedFolder
            // 
            resources.ApplyResources(this.lnkSharedFolder, "lnkSharedFolder");
            this.lnkSharedFolder.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lnkSharedFolder, true);
            this.lnkSharedFolder.Name = "lnkSharedFolder";
            this.lnkSharedFolder.TabStop = true;
            // 
            // lblProgram
            // 
            resources.ApplyResources(this.lblProgram, "lblProgram");
            this.lblProgram.BackColor = System.Drawing.Color.Transparent;
            this.lblProgram.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgram.Name = "lblProgram";
            // 
            // lblProgramValue
            // 
            resources.ApplyResources(this.lblProgramValue, "lblProgramValue");
            this.lblProgramValue.AutoEllipsis = true;
            this.lblProgramValue.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lblProgramValue, true);
            this.lblProgramValue.Name = "lblProgramValue";
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Name = "lblStatus";
            // 
            // lblStatusValue
            // 
            resources.ApplyResources(this.lblStatusValue, "lblStatusValue");
            this.lblStatusValue.AutoEllipsis = true;
            this.lblStatusValue.BackColor = System.Drawing.Color.Blue;
            this.lblStatusValue.ForeColor = System.Drawing.Color.White;
            this.lblStatusValue.Name = "lblStatusValue";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblType.Name = "lblType";
            // 
            // lblTypeValue
            // 
            resources.ApplyResources(this.lblTypeValue, "lblTypeValue");
            this.lblTypeValue.AutoEllipsis = true;
            this.lblTypeValue.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lblTypeValue, true);
            this.lblTypeValue.Name = "lblTypeValue";
            // 
            // lblOwnerOffice
            // 
            resources.ApplyResources(this.lblOwnerOffice, "lblOwnerOffice");
            this.lblOwnerOffice.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerOffice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOwnerOffice.Name = "lblOwnerOffice";
            // 
            // lnkJumpToOwnerFile
            // 
            resources.ApplyResources(this.lnkJumpToOwnerFile, "lnkJumpToOwnerFile");
            this.lnkJumpToOwnerFile.BackColor = System.Drawing.Color.Transparent;
            this.lnkJumpToOwnerFile.Name = "lnkJumpToOwnerFile";
            this.lnkJumpToOwnerFile.TabStop = true;
            this.lnkJumpToOwnerFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkJumpToOwnerFile_LinkClicked);
            // 
            // lblLeadOffice
            // 
            resources.ApplyResources(this.lblLeadOffice, "lblLeadOffice");
            this.lblLeadOffice.BackColor = System.Drawing.Color.Transparent;
            this.lblLeadOffice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLeadOffice.Name = "lblLeadOffice";
            // 
            // lnkJumpToLeadFile
            // 
            resources.ApplyResources(this.lnkJumpToLeadFile, "lnkJumpToLeadFile");
            this.lnkJumpToLeadFile.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lnkJumpToLeadFile, true);
            this.lnkJumpToLeadFile.Name = "lnkJumpToLeadFile";
            this.lnkJumpToLeadFile.TabStop = true;
            this.lnkJumpToLeadFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkJumpToOwnerFile_LinkClicked);
            // 
            // lblStatusDate
            // 
            resources.ApplyResources(this.lblStatusDate, "lblStatusDate");
            this.lblStatusDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatusDate.Name = "lblStatusDate";
            // 
            // lblStatusDateValue
            // 
            resources.ApplyResources(this.lblStatusDateValue, "lblStatusDateValue");
            this.lblStatusDateValue.AutoEllipsis = true;
            this.lblStatusDateValue.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusDateValue.Name = "lblStatusDateValue";
            // 
            // lblCaseStatus
            // 
            resources.ApplyResources(this.lblCaseStatus, "lblCaseStatus");
            this.lblCaseStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCaseStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCaseStatus.Name = "lblCaseStatus";
            // 
            // lblCaseStatusValue
            // 
            resources.ApplyResources(this.lblCaseStatusValue, "lblCaseStatusValue");
            this.lblCaseStatusValue.AutoEllipsis = true;
            this.lblCaseStatusValue.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lblCaseStatusValue, true);
            this.lblCaseStatusValue.Name = "lblCaseStatusValue";
            // 
            // lnkSINLabel
            // 
            resources.ApplyResources(this.lnkSINLabel, "lnkSINLabel");
            this.lnkSINLabel.BackColor = System.Drawing.Color.Transparent;
            this.lnkSINLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkSINLabel.Name = "lnkSINLabel";
            this.lnkSINLabel.TabStop = true;
            this.lnkSINLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSINLabel_LinkClicked);
            // 
            // lblSINValue
            // 
            resources.ApplyResources(this.lblSINValue, "lblSINValue");
            this.lblSINValue.AutoEllipsis = true;
            this.lblSINValue.BackColor = System.Drawing.Color.Transparent;
            this.lblSINValue.Name = "lblSINValue";
            // 
            // lblParalegal
            // 
            resources.ApplyResources(this.lblParalegal, "lblParalegal");
            this.lblParalegal.BackColor = System.Drawing.Color.Transparent;
            this.lblParalegal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblParalegal.Name = "lblParalegal";
            // 
            // lblParaLegalValue
            // 
            resources.ApplyResources(this.lblParaLegalValue, "lblParaLegalValue");
            this.lblParaLegalValue.AutoEllipsis = true;
            this.lblParaLegalValue.BackColor = System.Drawing.Color.Transparent;
            this.flpParentLayout.SetFlowBreak(this.lblParaLegalValue, true);
            this.lblParaLegalValue.Name = "lblParaLegalValue";
            // 
            // pnlTab
            // 
            resources.ApplyResources(this.pnlTab, "pnlTab");
            this.pnlTab.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.SelectedPanel = this.pnlMetaToc;
            this.pnlTab.TabAlignment = Janus.Windows.UI.Dock.TabAlignment.Top;
            this.pnlTab.SelectedPanelChanged += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.pnlTab_SelectedPanelChanged);
            // 
            // pnlMetaToc
            // 
            resources.ApplyResources(this.pnlMetaToc, "pnlMetaToc");
            this.pnlMetaToc.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlMetaToc.Name = "pnlMetaToc";
            // 
            // pnlTofC
            // 
            resources.ApplyResources(this.pnlTofC, "pnlTofC");
            this.pnlTofC.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTofC.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTofC.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTofC.InnerContainer = this.pnlTofCContainer;
            this.pnlTofC.Name = "pnlTofC";
            // 
            // pnlTofCContainer
            // 
            resources.ApplyResources(this.pnlTofCContainer, "pnlTofCContainer");
            this.pnlTofCContainer.Controls.Add(this.tvContents);
            this.pnlTofCContainer.Name = "pnlTofCContainer";
            // 
            // pnlBrowseFiles
            // 
            resources.ApplyResources(this.pnlBrowseFiles, "pnlBrowseFiles");
            this.pnlBrowseFiles.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBrowseFiles.Name = "pnlBrowseFiles";
            // 
            // pnlSubFiles
            // 
            resources.ApplyResources(this.pnlSubFiles, "pnlSubFiles");
            this.pnlSubFiles.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlSubFiles.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlSubFiles.InnerContainer = this.pnlSubFilesContainer;
            this.pnlSubFiles.Name = "pnlSubFiles";
            // 
            // pnlSubFilesContainer
            // 
            resources.ApplyResources(this.pnlSubFilesContainer, "pnlSubFilesContainer");
            this.pnlSubFilesContainer.Controls.Add(this.ucBrowse1);
            this.pnlSubFilesContainer.Name = "pnlSubFilesContainer";
            // 
            // ucBrowse1
            // 
            resources.ApplyResources(this.ucBrowse1, "ucBrowse1");
            this.ucBrowse1.DisplayJumpToOptions = false;
            this.ucBrowse1.DisplayOptionPanel = true;
            this.ucBrowse1.HideXrefs = false;
            this.ucBrowse1.Name = "ucBrowse1";
            this.ucBrowse1.ShowContextMenu = true;
            this.ucBrowse1.ShowFileNumber = false;
            this.ucBrowse1.ShowOnlyOpenFiles = false;
            this.ucBrowse1.ContextMenuClicked += new LawMate.ContextEventHandler(this.ucBrowse1_ContextMenuClicked);
            this.ucBrowse1.TreeNodeDoubleClicked += new LawMate.UserControls.TreeNodeDoubleClickEventHandler(this.ucBrowse1_TreeNodeDoubleClicked);
            // 
            // pnlXRefs
            // 
            resources.ApplyResources(this.pnlXRefs, "pnlXRefs");
            this.pnlXRefs.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlXRefs.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlXRefs.InnerContainer = this.pnlXRefsContainer;
            this.pnlXRefs.Name = "pnlXRefs";
            // 
            // pnlXRefsContainer
            // 
            resources.ApplyResources(this.pnlXRefsContainer, "pnlXRefsContainer");
            this.pnlXRefsContainer.Controls.Add(this.TopRebar1);
            this.pnlXRefsContainer.Name = "pnlXRefsContainer";
            // 
            // TopRebar1
            // 
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Name = "TopRebar1";
            // 
            // uiCommandBar1
            // 
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSelectAll1,
            this.cmdDeselectAll1,
            this.Separator1,
            this.cmdLoadXrefData1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdJumpToParent,
            this.cmdJumpToExplorer,
            this.cmdImportantMessage,
            this.cmdPin,
            this.cmdAddShortcut,
            this.cmdAddXref,
            this.cmdReloadFileData,
            this.cmdLoadXrefData,
            this.cmdSelectAll,
            this.cmdDeselectAll});
            this.uiCommandManager1.ContainerControl = this.pnlXRefsContainer;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.ImageList = ((System.Windows.Forms.ImageList)(resources.GetObject("uiCommandManager1.EditContextMenu.ImageList")));
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.EditContextMenu.LargeImageList = ((System.Windows.Forms.ImageList)(resources.GetObject("uiCommandManager1.EditContextMenu.LargeImageList")));
            this.uiCommandManager1.Id = new System.Guid("ee2b023f-a110-49ea-a595-8d3ead28b600");
            this.uiCommandManager1.ImageList = this.imageList1;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowToolTipOnMenus = true;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Name = "BottomRebar1";
            // 
            // cmdJumpToParent
            // 
            this.cmdJumpToParent.Alignment = Janus.Windows.UI.CommandBars.CommandAlignment.Near;
            this.cmdJumpToParent.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdJumpToParent, "cmdJumpToParent");
            this.cmdJumpToParent.Name = "cmdJumpToParent";
            // 
            // cmdJumpToExplorer
            // 
            this.cmdJumpToExplorer.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdJumpToExplorer, "cmdJumpToExplorer");
            this.cmdJumpToExplorer.Name = "cmdJumpToExplorer";
            // 
            // cmdImportantMessage
            // 
            this.cmdImportantMessage.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdImportantMessage, "cmdImportantMessage");
            this.cmdImportantMessage.Name = "cmdImportantMessage";
            // 
            // cmdPin
            // 
            this.cmdPin.Alignment = Janus.Windows.UI.CommandBars.CommandAlignment.Far;
            this.cmdPin.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdPin, "cmdPin");
            this.cmdPin.Name = "cmdPin";
            // 
            // cmdAddShortcut
            // 
            this.cmdAddShortcut.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdAddShortcut, "cmdAddShortcut");
            this.cmdAddShortcut.Name = "cmdAddShortcut";
            // 
            // cmdAddXref
            // 
            this.cmdAddXref.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdAddXref, "cmdAddXref");
            this.cmdAddXref.Name = "cmdAddXref";
            // 
            // cmdReloadFileData
            // 
            this.cmdReloadFileData.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdReloadFileData, "cmdReloadFileData");
            this.cmdReloadFileData.Name = "cmdReloadFileData";
            // 
            // cmdLoadXrefData
            // 
            this.cmdLoadXrefData.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdLoadXrefData, "cmdLoadXrefData");
            this.cmdLoadXrefData.Name = "cmdLoadXrefData";
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdSelectAll, "cmdSelectAll");
            this.cmdSelectAll.Name = "cmdSelectAll";
            // 
            // cmdDeselectAll
            // 
            this.cmdDeselectAll.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdDeselectAll, "cmdDeselectAll");
            this.cmdDeselectAll.Name = "cmdDeselectAll";
            // 
            // LeftRebar1
            // 
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Name = "LeftRebar1";
            // 
            // RightRebar1
            // 
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Name = "RightRebar1";
            // 
            // cmdSelectAll1
            // 
            resources.ApplyResources(this.cmdSelectAll1, "cmdSelectAll1");
            this.cmdSelectAll1.Name = "cmdSelectAll1";
            // 
            // cmdDeselectAll1
            // 
            resources.ApplyResources(this.cmdDeselectAll1, "cmdDeselectAll1");
            this.cmdDeselectAll1.Name = "cmdDeselectAll1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdLoadXrefData1
            // 
            resources.ApplyResources(this.cmdLoadXrefData1, "cmdLoadXrefData1");
            this.cmdLoadXrefData1.Name = "cmdLoadXrefData1";
            // 
            // pnlTableOfContents
            // 
            resources.ApplyResources(this.pnlTableOfContents, "pnlTableOfContents");
            this.pnlTableOfContents.InnerContainer = this.pnlTableOfContentsContainer;
            this.pnlTableOfContents.Name = "pnlTableOfContents";
            // 
            // pnlTableOfContentsContainer
            // 
            resources.ApplyResources(this.pnlTableOfContentsContainer, "pnlTableOfContentsContainer");
            this.pnlTableOfContentsContainer.Name = "pnlTableOfContentsContainer";
            // 
            // pnlFileMetaData
            // 
            resources.ApplyResources(this.pnlFileMetaData, "pnlFileMetaData");
            this.pnlFileMetaData.InnerContainer = this.pnlFileMetaDataContainer;
            this.pnlFileMetaData.Name = "pnlFileMetaData";
            // 
            // pnlFileMetaDataContainer
            // 
            resources.ApplyResources(this.pnlFileMetaDataContainer, "pnlFileMetaDataContainer");
            this.pnlFileMetaDataContainer.Name = "pnlFileMetaDataContainer";
            // 
            // janusSuperTip1
            // 
            this.janusSuperTip1.AutoPopDelay = 2000;
            this.janusSuperTip1.BodyWidth = 260;
            this.janusSuperTip1.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.janusSuperTip1.HeaderFont = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Bold);
            this.janusSuperTip1.ImageList = this.imageList1;
            this.janusSuperTip1.InitialDelay = 100;
            this.janusSuperTip1.OfficeColorScheme = Janus.Windows.Common.OfficeColorScheme.Blue;
            this.janusSuperTip1.ShowAlways = true;
            // 
            // ucToC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlDockTop);
            this.Name = "ucToC";
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDockTop)).EndInit();
            this.pnlDockTop.ResumeLayout(false);
            this.pnlDockTopContainer.ResumeLayout(false);
            this.flpParentLayout.ResumeLayout(false);
            this.flpParentLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).EndInit();
            this.pnlTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMetaToc)).EndInit();
            this.pnlMetaToc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTofC)).EndInit();
            this.pnlTofC.ResumeLayout(false);
            this.pnlTofCContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseFiles)).EndInit();
            this.pnlBrowseFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSubFiles)).EndInit();
            this.pnlSubFiles.ResumeLayout(false);
            this.pnlSubFilesContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlXRefs)).EndInit();
            this.pnlXRefs.ResumeLayout(false);
            this.pnlXRefsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTableOfContents)).EndInit();
            this.pnlTableOfContents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFileMetaData)).EndInit();
            this.pnlFileMetaData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvContents;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageListStatus;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlTableOfContents;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTableOfContentsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlFileMetaData;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlFileMetaDataContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlTab;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlMetaToc;
        private Janus.Windows.UI.Dock.UIPanel pnlTofC;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTofCContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlBrowseFiles;
        private Janus.Windows.UI.Dock.UIPanel pnlSubFiles;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSubFilesContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlXRefs;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlXRefsContainer;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToParent;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToExplorer;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportantMessage;
        private UserControls.ucBrowse ucBrowse1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPin;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
        private Janus.Windows.UI.Dock.UIPanel pnlDockTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDockTopContainer;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddShortcut;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddXref;
        private Janus.Windows.UI.CommandBars.UICommand cmdReloadFileData;
        private Janus.Windows.UI.CommandBars.UICommand cmdLoadXrefData;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectAll;
        private Janus.Windows.UI.CommandBars.UICommand cmdDeselectAll;
        private Janus.Windows.UI.CommandBars.UICommand cmdLoadXrefData1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectAll1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDeselectAll1;
        private System.Windows.Forms.FlowLayoutPanel flpParentLayout;
        private System.Windows.Forms.Label lblFullNumberValue;
        private System.Windows.Forms.Label lblFilenameValue;
        private System.Windows.Forms.Label lblSharedFolder;
        private System.Windows.Forms.LinkLabel lnkSharedFolder;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.Label lblProgramValue;
        private System.Windows.Forms.Label lblOwnerOffice;
        private System.Windows.Forms.LinkLabel lnkJumpToOwnerFile;
        private System.Windows.Forms.Label lblLeadOffice;
        private System.Windows.Forms.LinkLabel lnkJumpToLeadFile;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblStatusDate;
        private System.Windows.Forms.Label lblStatusDateValue;
        private System.Windows.Forms.Label lblCaseStatus;
        private System.Windows.Forms.Label lblCaseStatusValue;
        private System.Windows.Forms.LinkLabel lnkSINLabel;
        private System.Windows.Forms.Label lblSINValue;
        private System.Windows.Forms.Label lblParalegal;
        private System.Windows.Forms.Label lblParaLegalValue;
        private System.Windows.Forms.Label lblFullNumber;
        private System.Windows.Forms.Label lblFileName;
    }
}
