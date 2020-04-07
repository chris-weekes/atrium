 namespace LawMate
{
    partial class fSearchResultsDoc
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
                ucRecordList1.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSearchResultsDoc));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlLeft = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlLeftTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLeftTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnNextDoc = new Janus.Windows.EditControls.UIButton();
            this.btnPreviousDoc = new Janus.Windows.EditControls.UIButton();
            this.btnLastDoc = new Janus.Windows.EditControls.UIButton();
            this.btnFirstDoc = new Janus.Windows.EditControls.UIButton();
            this.lblSelectedHitPosition = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkShowDocSummary = new Janus.Windows.EditControls.UICheckBox();
            this.lblCurrentDocHitCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFullTextCriteriaRO = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnNextHit = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreviousHit = new Janus.Windows.EditControls.UIButton();
            this.tbDocSubject = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnLastHit = new Janus.Windows.EditControls.UIButton();
            this.btnFirstHit = new Janus.Windows.EditControls.UIButton();
            this.pnlSummary = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSummaryContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucWB1 = new LawMate.UserControls.ucWB();
            this.pnlRecordList = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlRecordListContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucRecordList1 = new LawMate.ucRecordList();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlPreview = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlPreviewContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucDocView1 = new LawMate.UserControls.ucDocView();
            this.pnlResultDetails = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlResultDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lblNoMatches = new System.Windows.Forms.Label();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsLblNumOfMatches1 = new Janus.Windows.UI.CommandBars.UICommand("tsLblNumOfMatches");
            this.tsMatchesCount1 = new Janus.Windows.UI.CommandBars.UICommand("tsMatchesCount");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdPrintGrid1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPrintGrid");
            this.cmdPrintPreview1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPrintPreview");
            this.tsReviseSearchCriteria1 = new Janus.Windows.UI.CommandBars.UICommand("tsReviseSearchCriteria");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdGridExFilter1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGridExFilter");
            this.cmdGridExGroupBy1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGridExGroupBy");
            this.cmdFldChooser1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFldChooser");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdJumptToActivity1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumptToActivity");
            this.tsJump1 = new Janus.Windows.UI.CommandBars.UICommand("tsJump");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdFirst1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFirst");
            this.cmdPrev1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPrev");
            this.cmdNext1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNext");
            this.cmdLast1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLast");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdFirstHit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFirstHit");
            this.cmdPrevHit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPrevHit");
            this.cmdNextHit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNextHit");
            this.cmdLastHit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLastHit");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsPreview1 = new Janus.Windows.UI.CommandBars.UICommand("tsPreview");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdToggleHighlight1 = new Janus.Windows.UI.CommandBars.UICommand("cmdToggleHighlight");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsShowDetails = new Janus.Windows.UI.CommandBars.UICommand("tsShowDetails");
            this.tsReviseSearchCriteria = new Janus.Windows.UI.CommandBars.UICommand("tsReviseSearchCriteria");
            this.tsCloseResults = new Janus.Windows.UI.CommandBars.UICommand("tsCloseResults");
            this.tsMatchesCount = new Janus.Windows.UI.CommandBars.UICommand("tsMatchesCount");
            this.tsLblNumOfMatches = new Janus.Windows.UI.CommandBars.UICommand("tsLblNumOfMatches");
            this.tsPreview2 = new Janus.Windows.UI.CommandBars.UICommand("tsPreview");
            this.tsJump = new Janus.Windows.UI.CommandBars.UICommand("tsJump");
            this.tsRevise = new Janus.Windows.UI.CommandBars.UICommand("tsRevise");
            this.tsHitHilite = new Janus.Windows.UI.CommandBars.UICommand("tsHitHilite");
            this.cmdGridExFilter = new Janus.Windows.UI.CommandBars.UICommand("cmdGridExFilter");
            this.cmdGridExGroupBy = new Janus.Windows.UI.CommandBars.UICommand("cmdGridExGroupBy");
            this.cmdFldChooser = new Janus.Windows.UI.CommandBars.UICommand("cmdFldChooser");
            this.cmdJumptToActivity = new Janus.Windows.UI.CommandBars.UICommand("cmdJumptToActivity");
            this.cmdFirst = new Janus.Windows.UI.CommandBars.UICommand("cmdFirst");
            this.cmdPrev = new Janus.Windows.UI.CommandBars.UICommand("cmdPrev");
            this.cmdNext = new Janus.Windows.UI.CommandBars.UICommand("cmdNext");
            this.cmdLast = new Janus.Windows.UI.CommandBars.UICommand("cmdLast");
            this.cmdFirstHit = new Janus.Windows.UI.CommandBars.UICommand("cmdFirstHit");
            this.cmdPrevHit = new Janus.Windows.UI.CommandBars.UICommand("cmdPrevHit");
            this.cmdNextHit = new Janus.Windows.UI.CommandBars.UICommand("cmdNextHit");
            this.cmdLastHit = new Janus.Windows.UI.CommandBars.UICommand("cmdLastHit");
            this.cmdToggleHighlight = new Janus.Windows.UI.CommandBars.UICommand("cmdToggleHighlight");
            this.cmdPrintGrid = new Janus.Windows.UI.CommandBars.UICommand("cmdPrintGrid");
            this.cmdPrintPreview = new Janus.Windows.UI.CommandBars.UICommand("cmdPrintPreview");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.docDB = new lmDatasets.docDB();
            this.gridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftTop)).BeginInit();
            this.pnlLeftTop.SuspendLayout();
            this.pnlLeftTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSummary)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.pnlSummaryContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRecordList)).BeginInit();
            this.pnlRecordList.SuspendLayout();
            this.pnlRecordListContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreview)).BeginInit();
            this.pnlPreview.SuspendLayout();
            this.pnlPreviewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResultDetails)).BeginInit();
            this.pnlResultDetails.SuspendLayout();
            this.pnlResultDetailsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docDB)).BeginInit();
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
            this.imageListfBase.Images.SetKeyName(18, "revisecriteria.gif");
            this.imageListfBase.Images.SetKeyName(19, "panel.gif");
            this.imageListfBase.Images.SetKeyName(20, "highlight.gif");
            this.imageListfBase.Images.SetKeyName(21, "exe_icon.gif");
            this.imageListfBase.Images.SetKeyName(22, "groupBy.gif");
            this.imageListfBase.Images.SetKeyName(23, "filter.gif");
            this.imageListfBase.Images.SetKeyName(24, "fieldChooser.gif");
            this.imageListfBase.Images.SetKeyName(25, "folder.gif");
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Horizontal;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlLeft.Id = new System.Guid("d5c14afe-8dd9-4d8e-ba4a-8aed44e1d79f");
            this.pnlLeft.StaticGroup = true;
            this.pnlLeftTop.Id = new System.Guid("02e19d16-cb7f-4787-b8f3-e3037b70a8a6");
            this.pnlLeft.Panels.Add(this.pnlLeftTop);
            this.pnlSummary.Id = new System.Guid("82513785-74b1-43d4-9e40-f1a180288a18");
            this.pnlLeft.Panels.Add(this.pnlSummary);
            this.uiPanelManager1.Panels.Add(this.pnlLeft);
            this.pnlRecordList.Id = new System.Guid("5ab7f8fa-2df1-4438-babe-3af2af17fcc9");
            this.uiPanelManager1.Panels.Add(this.pnlRecordList);
            this.pnlPreview.Id = new System.Guid("a328f949-fd5a-4594-ad3c-06a1ecd81770");
            this.uiPanelManager1.Panels.Add(this.pnlPreview);
            this.pnlResultDetails.Id = new System.Guid("7b60fcb4-8219-4fcf-b656-0f8f01177611");
            this.uiPanelManager1.Panels.Add(this.pnlResultDetails);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("d5c14afe-8dd9-4d8e-ba4a-8aed44e1d79f"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(306, 634), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("02e19d16-cb7f-4787-b8f3-e3037b70a8a6"), new System.Guid("d5c14afe-8dd9-4d8e-ba4a-8aed44e1d79f"), 232, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("82513785-74b1-43d4-9e40-f1a180288a18"), new System.Guid("d5c14afe-8dd9-4d8e-ba4a-8aed44e1d79f"), 378, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5ab7f8fa-2df1-4438-babe-3af2af17fcc9"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(778, 170), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7b60fcb4-8219-4fcf-b656-0f8f01177611"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1032, 100), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a328f949-fd5a-4594-ad3c-06a1ecd81770"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(778, 235), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8835d33a-c3b7-460c-8ba5-ff055fa088ef"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f49f41d3-4bcd-4a9b-9647-beb442310354"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("997e7681-588c-4026-a661-f0fa85a9fd25"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7b60fcb4-8219-4fcf-b656-0f8f01177611"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5ab7f8fa-2df1-4438-babe-3af2af17fcc9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a328f949-fd5a-4594-ad3c-06a1ecd81770"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d5967c4f-583f-4965-844e-72e4a63061d0"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d5c14afe-8dd9-4d8e-ba4a-8aed44e1d79f"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("02e19d16-cb7f-4787-b8f3-e3037b70a8a6"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("82513785-74b1-43d4-9e40-f1a180288a18"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlLeft
            // 
            this.pnlLeft.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            this.helpProvider1.SetShowHelp(this.pnlLeft, ((bool)(resources.GetObject("pnlLeft.ShowHelp"))));
            // 
            // pnlLeftTop
            // 
            this.pnlLeftTop.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlLeftTop.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlLeftTop.InnerContainer = this.pnlLeftTopContainer;
            resources.ApplyResources(this.pnlLeftTop, "pnlLeftTop");
            this.pnlLeftTop.Name = "pnlLeftTop";
            this.helpProvider1.SetShowHelp(this.pnlLeftTop, ((bool)(resources.GetObject("pnlLeftTop.ShowHelp"))));
            // 
            // pnlLeftTopContainer
            // 
            this.pnlLeftTopContainer.Controls.Add(this.btnNextDoc);
            this.pnlLeftTopContainer.Controls.Add(this.btnPreviousDoc);
            this.pnlLeftTopContainer.Controls.Add(this.btnLastDoc);
            this.pnlLeftTopContainer.Controls.Add(this.btnFirstDoc);
            this.pnlLeftTopContainer.Controls.Add(this.lblSelectedHitPosition);
            this.pnlLeftTopContainer.Controls.Add(this.label5);
            this.pnlLeftTopContainer.Controls.Add(this.chkShowDocSummary);
            this.pnlLeftTopContainer.Controls.Add(this.lblCurrentDocHitCount);
            this.pnlLeftTopContainer.Controls.Add(this.label1);
            this.pnlLeftTopContainer.Controls.Add(this.label3);
            this.pnlLeftTopContainer.Controls.Add(this.tbFullTextCriteriaRO);
            this.pnlLeftTopContainer.Controls.Add(this.btnNextHit);
            this.pnlLeftTopContainer.Controls.Add(this.label2);
            this.pnlLeftTopContainer.Controls.Add(this.btnPreviousHit);
            this.pnlLeftTopContainer.Controls.Add(this.tbDocSubject);
            this.pnlLeftTopContainer.Controls.Add(this.btnLastHit);
            this.pnlLeftTopContainer.Controls.Add(this.btnFirstHit);
            resources.ApplyResources(this.pnlLeftTopContainer, "pnlLeftTopContainer");
            this.pnlLeftTopContainer.Name = "pnlLeftTopContainer";
            this.helpProvider1.SetShowHelp(this.pnlLeftTopContainer, ((bool)(resources.GetObject("pnlLeftTopContainer.ShowHelp"))));
            // 
            // btnNextDoc
            // 
            this.btnNextDoc.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            resources.ApplyResources(this.btnNextDoc, "btnNextDoc");
            this.btnNextDoc.ImageList = this.imageListfBase;
            this.btnNextDoc.Name = "btnNextDoc";
            this.helpProvider1.SetShowHelp(this.btnNextDoc, ((bool)(resources.GetObject("btnNextDoc.ShowHelp"))));
            this.btnNextDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnNextDoc.Click += new System.EventHandler(this.btnFirstDoc_Click);
            // 
            // btnPreviousDoc
            // 
            resources.ApplyResources(this.btnPreviousDoc, "btnPreviousDoc");
            this.btnPreviousDoc.ImageList = this.imageListfBase;
            this.btnPreviousDoc.Name = "btnPreviousDoc";
            this.helpProvider1.SetShowHelp(this.btnPreviousDoc, ((bool)(resources.GetObject("btnPreviousDoc.ShowHelp"))));
            this.btnPreviousDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnPreviousDoc.Click += new System.EventHandler(this.btnFirstDoc_Click);
            // 
            // btnLastDoc
            // 
            this.btnLastDoc.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            resources.ApplyResources(this.btnLastDoc, "btnLastDoc");
            this.btnLastDoc.ImageList = this.imageListfBase;
            this.btnLastDoc.Name = "btnLastDoc";
            this.helpProvider1.SetShowHelp(this.btnLastDoc, ((bool)(resources.GetObject("btnLastDoc.ShowHelp"))));
            this.btnLastDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnLastDoc.Click += new System.EventHandler(this.btnFirstDoc_Click);
            // 
            // btnFirstDoc
            // 
            resources.ApplyResources(this.btnFirstDoc, "btnFirstDoc");
            this.btnFirstDoc.ImageList = this.imageListfBase;
            this.btnFirstDoc.Name = "btnFirstDoc";
            this.helpProvider1.SetShowHelp(this.btnFirstDoc, ((bool)(resources.GetObject("btnFirstDoc.ShowHelp"))));
            this.btnFirstDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnFirstDoc.Click += new System.EventHandler(this.btnFirstDoc_Click);
            // 
            // lblSelectedHitPosition
            // 
            resources.ApplyResources(this.lblSelectedHitPosition, "lblSelectedHitPosition");
            this.lblSelectedHitPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedHitPosition.Name = "lblSelectedHitPosition";
            this.helpProvider1.SetShowHelp(this.lblSelectedHitPosition, ((bool)(resources.GetObject("lblSelectedHitPosition.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            this.helpProvider1.SetShowHelp(this.label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // chkShowDocSummary
            // 
            this.chkShowDocSummary.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkShowDocSummary, "chkShowDocSummary");
            this.chkShowDocSummary.Name = "chkShowDocSummary";
            this.helpProvider1.SetShowHelp(this.chkShowDocSummary, ((bool)(resources.GetObject("chkShowDocSummary.ShowHelp"))));
            this.chkShowDocSummary.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.chkShowDocSummary.CheckedChanged += new System.EventHandler(this.chkShowDocSummary_CheckedChanged);
            // 
            // lblCurrentDocHitCount
            // 
            resources.ApplyResources(this.lblCurrentDocHitCount, "lblCurrentDocHitCount");
            this.lblCurrentDocHitCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentDocHitCount.Name = "lblCurrentDocHitCount";
            this.helpProvider1.SetShowHelp(this.lblCurrentDocHitCount, ((bool)(resources.GetObject("lblCurrentDocHitCount.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // tbFullTextCriteriaRO
            // 
            resources.ApplyResources(this.tbFullTextCriteriaRO, "tbFullTextCriteriaRO");
            this.tbFullTextCriteriaRO.Name = "tbFullTextCriteriaRO";
            this.tbFullTextCriteriaRO.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbFullTextCriteriaRO, ((bool)(resources.GetObject("tbFullTextCriteriaRO.ShowHelp"))));
            this.tbFullTextCriteriaRO.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // btnNextHit
            // 
            this.btnNextHit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            resources.ApplyResources(this.btnNextHit, "btnNextHit");
            this.btnNextHit.ImageList = this.imageListfBase;
            this.btnNextHit.Name = "btnNextHit";
            this.helpProvider1.SetShowHelp(this.btnNextHit, ((bool)(resources.GetObject("btnNextHit.ShowHelp"))));
            this.btnNextHit.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnNextHit.Click += new System.EventHandler(this.btnFirstHit_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // btnPreviousHit
            // 
            resources.ApplyResources(this.btnPreviousHit, "btnPreviousHit");
            this.btnPreviousHit.ImageList = this.imageListfBase;
            this.btnPreviousHit.Name = "btnPreviousHit";
            this.helpProvider1.SetShowHelp(this.btnPreviousHit, ((bool)(resources.GetObject("btnPreviousHit.ShowHelp"))));
            this.btnPreviousHit.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnPreviousHit.Click += new System.EventHandler(this.btnFirstHit_Click);
            // 
            // tbDocSubject
            // 
            this.tbDocSubject.ButtonImage = ((System.Drawing.Image)(resources.GetObject("tbDocSubject.ButtonImage")));
            this.tbDocSubject.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image;
            this.tbDocSubject.ImageList = this.imageListfBase;
            resources.ApplyResources(this.tbDocSubject, "tbDocSubject");
            this.tbDocSubject.Name = "tbDocSubject";
            this.tbDocSubject.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbDocSubject, ((bool)(resources.GetObject("tbDocSubject.ShowHelp"))));
            this.toolTip1.SetToolTip(this.tbDocSubject, resources.GetString("tbDocSubject.ToolTip"));
            this.tbDocSubject.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.tbDocSubject.ButtonClick += new System.EventHandler(this.tbDocSubject_ButtonClick);
            // 
            // btnLastHit
            // 
            this.btnLastHit.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            resources.ApplyResources(this.btnLastHit, "btnLastHit");
            this.btnLastHit.ImageList = this.imageListfBase;
            this.btnLastHit.Name = "btnLastHit";
            this.helpProvider1.SetShowHelp(this.btnLastHit, ((bool)(resources.GetObject("btnLastHit.ShowHelp"))));
            this.btnLastHit.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnLastHit.Click += new System.EventHandler(this.btnFirstHit_Click);
            // 
            // btnFirstHit
            // 
            resources.ApplyResources(this.btnFirstHit, "btnFirstHit");
            this.btnFirstHit.ImageList = this.imageListfBase;
            this.btnFirstHit.Name = "btnFirstHit";
            this.helpProvider1.SetShowHelp(this.btnFirstHit, ((bool)(resources.GetObject("btnFirstHit.ShowHelp"))));
            this.btnFirstHit.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnFirstHit.Click += new System.EventHandler(this.btnFirstHit_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlSummary.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlSummary, "pnlSummary");
            this.pnlSummary.InnerContainer = this.pnlSummaryContainer;
            this.pnlSummary.Name = "pnlSummary";
            this.helpProvider1.SetShowHelp(this.pnlSummary, ((bool)(resources.GetObject("pnlSummary.ShowHelp"))));
            // 
            // pnlSummaryContainer
            // 
            this.pnlSummaryContainer.Controls.Add(this.ucWB1);
            resources.ApplyResources(this.pnlSummaryContainer, "pnlSummaryContainer");
            this.pnlSummaryContainer.Name = "pnlSummaryContainer";
            this.helpProvider1.SetShowHelp(this.pnlSummaryContainer, ((bool)(resources.GetObject("pnlSummaryContainer.ShowHelp"))));
            // 
            // ucWB1
            // 
            resources.ApplyResources(this.ucWB1, "ucWB1");
            this.ucWB1.Name = "ucWB1";
            this.helpProvider1.SetShowHelp(this.ucWB1, ((bool)(resources.GetObject("ucWB1.ShowHelp"))));
            this.ucWB1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.ucWB1.DocumentCompleted += new LawMate.UserControls.WebBrowserDocumentCompletedEventHandler(this.ucWB1_DocumentCompleted);
            this.ucWB1.DocumentNavigating += new LawMate.UserControls.WebBrowserNavigatingEventHandler(this.ucWB1_DocumentNavigating);
            // 
            // pnlRecordList
            // 
            this.pnlRecordList.AllowResize = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlRecordList.InnerContainer = this.pnlRecordListContainer;
            resources.ApplyResources(this.pnlRecordList, "pnlRecordList");
            this.pnlRecordList.Name = "pnlRecordList";
            this.helpProvider1.SetShowHelp(this.pnlRecordList, ((bool)(resources.GetObject("pnlRecordList.ShowHelp"))));
            // 
            // pnlRecordListContainer
            // 
            this.pnlRecordListContainer.Controls.Add(this.ucRecordList1);
            resources.ApplyResources(this.pnlRecordListContainer, "pnlRecordListContainer");
            this.pnlRecordListContainer.Name = "pnlRecordListContainer";
            this.helpProvider1.SetShowHelp(this.pnlRecordListContainer, ((bool)(resources.GetObject("pnlRecordListContainer.ShowHelp"))));
            // 
            // ucRecordList1
            // 
            this.ucRecordList1.DataSource = this.documentBindingSource;
            resources.ApplyResources(this.ucRecordList1, "ucRecordList1");
            this.ucRecordList1.InEditMode = false;
            this.ucRecordList1.Name = "ucRecordList1";
            this.ucRecordList1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            this.helpProvider1.SetShowHelp(this.ucRecordList1, ((bool)(resources.GetObject("ucRecordList1.ShowHelp"))));
            this.ucRecordList1.LinkClicked += new LawMate.LinkClickedEventHandler(this.ucRecordList1_LinkClicked);
            this.ucRecordList1.ColumnButtonClicked += new LawMate.ColumnButtonClickEventHandler(this.ucRecordList1_ColumnButtonClicked);
            this.ucRecordList1.RowDoubleClicked += new LawMate.RowDoubleClickedEventHandler(this.ucRecordList1_RowDoubleClicked);
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataMember = "Document";
            this.documentBindingSource.CurrentChanged += new System.EventHandler(this.documentBindingSource_CurrentChanged);
            // 
            // pnlPreview
            // 
            this.pnlPreview.AllowResize = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlPreview.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlPreview.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlPreview.InnerContainer = this.pnlPreviewContainer;
            resources.ApplyResources(this.pnlPreview, "pnlPreview");
            this.pnlPreview.Name = "pnlPreview";
            this.helpProvider1.SetShowHelp(this.pnlPreview, ((bool)(resources.GetObject("pnlPreview.ShowHelp"))));
            // 
            // pnlPreviewContainer
            // 
            this.pnlPreviewContainer.Controls.Add(this.ucDocView1);
            resources.ApplyResources(this.pnlPreviewContainer, "pnlPreviewContainer");
            this.pnlPreviewContainer.Name = "pnlPreviewContainer";
            this.helpProvider1.SetShowHelp(this.pnlPreviewContainer, ((bool)(resources.GetObject("pnlPreviewContainer.ShowHelp"))));
            // 
            // ucDocView1
            // 
            this.ucDocView1.ActionToolbarView = LawMate.UserControls.DocCommandBar.Enable;
            this.ucDocView1.AllowActionToolbar = true;
            this.ucDocView1.AllowMetadata = false;
            this.ucDocView1.AllowMetadataUpdate = false;
            this.ucDocView1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocView1.DocDisplayType = LawMate.UserControls.DocViewDisplayType.MailHeader;
            resources.ApplyResources(this.ucDocView1, "ucDocView1");
            this.ucDocView1.ForceTextControl = true;
            this.ucDocView1.Name = "ucDocView1";
            this.ucDocView1.NoDocDisplayed = false;
            this.ucDocView1.ShowAttachmentPanel = true;
            this.ucDocView1.ShowMetadata = false;
            this.ucDocView1.ShowVersion = false;
            this.ucDocView1.TempFile = null;
            this.ucDocView1.TempFld = null;
            this.ucDocView1.DocAction += new LawMate.UserControls.DocActionEventHandler(this.ucDoc1_DocAction);
            this.ucDocView1.DocumentCompleted += new LawMate.UserControls.WebBrowserDocumentCompletedEventHandler(this.ucDoc1_DocumentCompleted);
            // 
            // pnlResultDetails
            // 
            resources.ApplyResources(this.pnlResultDetails, "pnlResultDetails");
            this.pnlResultDetails.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlResultDetails.InnerContainer = this.pnlResultDetailsContainer;
            this.pnlResultDetails.Name = "pnlResultDetails";
            this.helpProvider1.SetShowHelp(this.pnlResultDetails, ((bool)(resources.GetObject("pnlResultDetails.ShowHelp"))));
            // 
            // pnlResultDetailsContainer
            // 
            this.pnlResultDetailsContainer.Controls.Add(this.lblNoMatches);
            resources.ApplyResources(this.pnlResultDetailsContainer, "pnlResultDetailsContainer");
            this.pnlResultDetailsContainer.Name = "pnlResultDetailsContainer";
            this.helpProvider1.SetShowHelp(this.pnlResultDetailsContainer, ((bool)(resources.GetObject("pnlResultDetailsContainer.ShowHelp"))));
            // 
            // lblNoMatches
            // 
            resources.ApplyResources(this.lblNoMatches, "lblNoMatches");
            this.lblNoMatches.BackColor = System.Drawing.Color.Transparent;
            this.lblNoMatches.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblNoMatches.Name = "lblNoMatches";
            this.helpProvider1.SetShowHelp(this.lblNoMatches, ((bool)(resources.GetObject("lblNoMatches.ShowHelp"))));
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
            this.tsScreenTitle,
            this.tsShowDetails,
            this.tsReviseSearchCriteria,
            this.tsCloseResults,
            this.tsMatchesCount,
            this.tsLblNumOfMatches,
            this.tsPreview2,
            this.tsJump,
            this.tsRevise,
            this.tsHitHilite,
            this.cmdGridExFilter,
            this.cmdGridExGroupBy,
            this.cmdFldChooser,
            this.cmdJumptToActivity,
            this.cmdFirst,
            this.cmdPrev,
            this.cmdNext,
            this.cmdLast,
            this.cmdFirstHit,
            this.cmdPrevHit,
            this.cmdNextHit,
            this.cmdLastHit,
            this.cmdToggleHighlight,
            this.cmdPrintGrid,
            this.cmdPrintPreview});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("ed9c753f-7d41-4171-ae89-4d4866c05652");
            this.uiCommandManager1.ImageList = this.imageListfBase;
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
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsLblNumOfMatches1,
            this.tsMatchesCount1,
            this.Separator2,
            this.cmdPrintGrid1,
            this.cmdPrintPreview1,
            this.tsReviseSearchCriteria1,
            this.Separator4,
            this.cmdGridExFilter1,
            this.cmdGridExGroupBy1,
            this.cmdFldChooser1,
            this.Separator5,
            this.cmdJumptToActivity1,
            this.tsJump1,
            this.Separator3,
            this.cmdFirst1,
            this.cmdPrev1,
            this.cmdNext1,
            this.cmdLast1,
            this.Separator1,
            this.cmdFirstHit1,
            this.cmdPrevHit1,
            this.cmdNextHit1,
            this.cmdLastHit1,
            this.Separator6,
            this.tsPreview1,
            this.Separator7,
            this.cmdToggleHighlight1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // tsLblNumOfMatches1
            // 
            resources.ApplyResources(this.tsLblNumOfMatches1, "tsLblNumOfMatches1");
            this.tsLblNumOfMatches1.Name = "tsLblNumOfMatches1";
            // 
            // tsMatchesCount1
            // 
            resources.ApplyResources(this.tsMatchesCount1, "tsMatchesCount1");
            this.tsMatchesCount1.Name = "tsMatchesCount1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdPrintGrid1
            // 
            resources.ApplyResources(this.cmdPrintGrid1, "cmdPrintGrid1");
            this.cmdPrintGrid1.Name = "cmdPrintGrid1";
            // 
            // cmdPrintPreview1
            // 
            resources.ApplyResources(this.cmdPrintPreview1, "cmdPrintPreview1");
            this.cmdPrintPreview1.Name = "cmdPrintPreview1";
            // 
            // tsReviseSearchCriteria1
            // 
            resources.ApplyResources(this.tsReviseSearchCriteria1, "tsReviseSearchCriteria1");
            this.tsReviseSearchCriteria1.Name = "tsReviseSearchCriteria1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdGridExFilter1
            // 
            resources.ApplyResources(this.cmdGridExFilter1, "cmdGridExFilter1");
            this.cmdGridExFilter1.Name = "cmdGridExFilter1";
            // 
            // cmdGridExGroupBy1
            // 
            resources.ApplyResources(this.cmdGridExGroupBy1, "cmdGridExGroupBy1");
            this.cmdGridExGroupBy1.Name = "cmdGridExGroupBy1";
            // 
            // cmdFldChooser1
            // 
            resources.ApplyResources(this.cmdFldChooser1, "cmdFldChooser1");
            this.cmdFldChooser1.Name = "cmdFldChooser1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdJumptToActivity1
            // 
            resources.ApplyResources(this.cmdJumptToActivity1, "cmdJumptToActivity1");
            this.cmdJumptToActivity1.Name = "cmdJumptToActivity1";
            // 
            // tsJump1
            // 
            resources.ApplyResources(this.tsJump1, "tsJump1");
            this.tsJump1.Name = "tsJump1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdFirst1
            // 
            resources.ApplyResources(this.cmdFirst1, "cmdFirst1");
            this.cmdFirst1.Name = "cmdFirst1";
            // 
            // cmdPrev1
            // 
            resources.ApplyResources(this.cmdPrev1, "cmdPrev1");
            this.cmdPrev1.Name = "cmdPrev1";
            // 
            // cmdNext1
            // 
            resources.ApplyResources(this.cmdNext1, "cmdNext1");
            this.cmdNext1.Name = "cmdNext1";
            // 
            // cmdLast1
            // 
            resources.ApplyResources(this.cmdLast1, "cmdLast1");
            this.cmdLast1.Name = "cmdLast1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdFirstHit1
            // 
            resources.ApplyResources(this.cmdFirstHit1, "cmdFirstHit1");
            this.cmdFirstHit1.Name = "cmdFirstHit1";
            // 
            // cmdPrevHit1
            // 
            resources.ApplyResources(this.cmdPrevHit1, "cmdPrevHit1");
            this.cmdPrevHit1.Name = "cmdPrevHit1";
            // 
            // cmdNextHit1
            // 
            resources.ApplyResources(this.cmdNextHit1, "cmdNextHit1");
            this.cmdNextHit1.Name = "cmdNextHit1";
            // 
            // cmdLastHit1
            // 
            resources.ApplyResources(this.cmdLastHit1, "cmdLastHit1");
            this.cmdLastHit1.Name = "cmdLastHit1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // tsPreview1
            // 
            this.tsPreview1.Checked = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.tsPreview1, "tsPreview1");
            this.tsPreview1.Name = "tsPreview1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // cmdToggleHighlight1
            // 
            resources.ApplyResources(this.cmdToggleHighlight1, "cmdToggleHighlight1");
            this.cmdToggleHighlight1.Name = "cmdToggleHighlight1";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.StateStyles.FormatStyle.FontName = "arial";
            this.tsScreenTitle.StateStyles.FormatStyle.FontSize = 9F;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsShowDetails
            // 
            this.tsShowDetails.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsShowDetails.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsShowDetails, "tsShowDetails");
            this.tsShowDetails.Name = "tsShowDetails";
            // 
            // tsReviseSearchCriteria
            // 
            this.tsReviseSearchCriteria.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsReviseSearchCriteria, "tsReviseSearchCriteria");
            this.tsReviseSearchCriteria.Name = "tsReviseSearchCriteria";
            // 
            // tsCloseResults
            // 
            this.tsCloseResults.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsCloseResults, "tsCloseResults");
            this.tsCloseResults.Name = "tsCloseResults";
            // 
            // tsMatchesCount
            // 
            this.tsMatchesCount.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsMatchesCount.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsMatchesCount, "tsMatchesCount");
            this.tsMatchesCount.Name = "tsMatchesCount";
            // 
            // tsLblNumOfMatches
            // 
            this.tsLblNumOfMatches.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsLblNumOfMatches.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsLblNumOfMatches, "tsLblNumOfMatches");
            this.tsLblNumOfMatches.Name = "tsLblNumOfMatches";
            // 
            // tsPreview2
            // 
            this.tsPreview2.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.tsPreview2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsPreview2.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsPreview2, "tsPreview2");
            this.tsPreview2.Name = "tsPreview2";
            // 
            // tsJump
            // 
            this.tsJump.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsJump, "tsJump");
            this.tsJump.Name = "tsJump";
            this.tsJump.TagString = "";
            // 
            // tsRevise
            // 
            this.tsRevise.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsRevise, "tsRevise");
            this.tsRevise.Name = "tsRevise";
            // 
            // tsHitHilite
            // 
            this.tsHitHilite.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsHitHilite.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsHitHilite, "tsHitHilite");
            this.tsHitHilite.Name = "tsHitHilite";
            // 
            // cmdGridExFilter
            // 
            this.cmdGridExFilter.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdGridExFilter.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdGridExFilter, "cmdGridExFilter");
            this.cmdGridExFilter.Name = "cmdGridExFilter";
            // 
            // cmdGridExGroupBy
            // 
            this.cmdGridExGroupBy.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdGridExGroupBy.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdGridExGroupBy, "cmdGridExGroupBy");
            this.cmdGridExGroupBy.Name = "cmdGridExGroupBy";
            // 
            // cmdFldChooser
            // 
            resources.ApplyResources(this.cmdFldChooser, "cmdFldChooser");
            this.cmdFldChooser.Name = "cmdFldChooser";
            // 
            // cmdJumptToActivity
            // 
            resources.ApplyResources(this.cmdJumptToActivity, "cmdJumptToActivity");
            this.cmdJumptToActivity.Name = "cmdJumptToActivity";
            // 
            // cmdFirst
            // 
            this.cmdFirst.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdFirst, "cmdFirst");
            this.cmdFirst.Name = "cmdFirst";
            this.cmdFirst.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.cmdFirst.StateStyles.FormatStyle.FontName = "Arial";
            this.cmdFirst.StateStyles.FormatStyle.FontSize = 12F;
            // 
            // cmdPrev
            // 
            this.cmdPrev.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdPrev, "cmdPrev");
            this.cmdPrev.Name = "cmdPrev";
            this.cmdPrev.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.Overlay;
            // 
            // cmdNext
            // 
            this.cmdNext.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdNext, "cmdNext");
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.Overlay;
            // 
            // cmdLast
            // 
            this.cmdLast.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdLast, "cmdLast");
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.Overlay;
            // 
            // cmdFirstHit
            // 
            this.cmdFirstHit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdFirstHit, "cmdFirstHit");
            this.cmdFirstHit.Name = "cmdFirstHit";
            this.cmdFirstHit.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.Overlay;
            // 
            // cmdPrevHit
            // 
            this.cmdPrevHit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdPrevHit, "cmdPrevHit");
            this.cmdPrevHit.Name = "cmdPrevHit";
            this.cmdPrevHit.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.Overlay;
            // 
            // cmdNextHit
            // 
            this.cmdNextHit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdNextHit, "cmdNextHit");
            this.cmdNextHit.Name = "cmdNextHit";
            this.cmdNextHit.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.Overlay;
            // 
            // cmdLastHit
            // 
            this.cmdLastHit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdLastHit, "cmdLastHit");
            this.cmdLastHit.Name = "cmdLastHit";
            this.cmdLastHit.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.Overlay;
            // 
            // cmdToggleHighlight
            // 
            this.cmdToggleHighlight.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdToggleHighlight.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdToggleHighlight, "cmdToggleHighlight");
            this.cmdToggleHighlight.Name = "cmdToggleHighlight";
            // 
            // cmdPrintGrid
            // 
            resources.ApplyResources(this.cmdPrintGrid, "cmdPrintGrid");
            this.cmdPrintGrid.Name = "cmdPrintGrid";
            // 
            // cmdPrintPreview
            // 
            resources.ApplyResources(this.cmdPrintPreview, "cmdPrintPreview");
            this.cmdPrintPreview.Name = "cmdPrintPreview";
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
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // docDB
            // 
            this.docDB.DataSetName = "docDB";
            this.docDB.EnforceConstraints = false;
            this.docDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridEXPrintDocument1
            // 
            this.gridEXPrintDocument1.DocumentName = "[app] Search Results";
            resources.ApplyResources(this.gridEXPrintDocument1, "gridEXPrintDocument1");
            this.gridEXPrintDocument1.PrintHierarchical = true;
            // 
            // uiStatusBar1
            // 
            resources.ApplyResources(this.uiStatusBar1, "uiStatusBar1");
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            uiStatusBarPanel1.Key = "NoHHPDF";
            resources.ApplyResources(uiStatusBarPanel1, "uiStatusBarPanel1");
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1});
            this.helpProvider1.SetShowHelp(this.uiStatusBar1, ((bool)(resources.GetObject("uiStatusBar1.ShowHelp"))));
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // fSearchResultsDoc
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlResultDetails);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.pnlRecordList);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.TopRebar1);
            this.MakeMdiChild = false;
            this.Name = "fSearchResultsDoc";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fSearchResultsDoc_FormClosed);
            this.Shown += new System.EventHandler(this.fSearchResultsDoc_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftTop)).EndInit();
            this.pnlLeftTop.ResumeLayout(false);
            this.pnlLeftTopContainer.ResumeLayout(false);
            this.pnlLeftTopContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSummary)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummaryContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlRecordList)).EndInit();
            this.pnlRecordList.ResumeLayout(false);
            this.pnlRecordListContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreview)).EndInit();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreviewContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlResultDetails)).EndInit();
            this.pnlResultDetails.ResumeLayout(false);
            this.pnlResultDetailsContainer.ResumeLayout(false);
            this.pnlResultDetailsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docDB)).EndInit();
            this.ResumeLayout(false);

        }
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;

        #endregion
        private System.Windows.Forms.Label lblNoMatches;
        private Janus.Windows.UI.Dock.UIPanel pnlResultDetails;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlResultDetailsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlRecordList;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlRecordListContainer;
        private ucRecordList ucRecordList1;
        private Janus.Windows.UI.Dock.UIPanel pnlPreview;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlPreviewContainer;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsShowDetails;
        private Janus.Windows.UI.CommandBars.UICommand tsReviseSearchCriteria;
        private Janus.Windows.UI.CommandBars.UICommand tsCloseResults;
        private Janus.Windows.UI.CommandBars.UICommand tsMatchesCount;
        private Janus.Windows.UI.CommandBars.UICommand tsLblNumOfMatches;
        private Janus.Windows.UI.CommandBars.UICommand tsPreview2;
        private Janus.Windows.UI.CommandBars.UICommand tsLblNumOfMatches1;
        private Janus.Windows.UI.CommandBars.UICommand tsMatchesCount1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand tsReviseSearchCriteria1;
        private Janus.Windows.UI.CommandBars.UICommand tsPreview1;
        private Janus.Windows.UI.CommandBars.UICommand tsJump;
        private Janus.Windows.UI.CommandBars.UICommand tsRevise;
        private Janus.Windows.UI.CommandBars.UICommand tsHitHilite;
        private Janus.Windows.UI.CommandBars.UICommand tsJump1;
        private Janus.Windows.GridEX.EditControls.EditBox tbDocSubject;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox tbFullTextCriteriaRO;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton btnFirstHit;
        private Janus.Windows.EditControls.UIButton btnNextHit;
        private Janus.Windows.EditControls.UIButton btnPreviousHit;
        private Janus.Windows.EditControls.UIButton btnLastHit;
        private lmDatasets.docDB docDB;
        private System.Windows.Forms.Label lblCurrentDocHitCount;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlLeft;
        private Janus.Windows.UI.Dock.UIPanel pnlLeftTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLeftTopContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSummary;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSummaryContainer;
        private UserControls.ucWB ucWB1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridExFilter;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridExGroupBy;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridExFilter1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridExGroupBy1;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private System.Windows.Forms.Label lblSelectedHitPosition;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.EditControls.UICheckBox chkShowDocSummary;
        private Janus.Windows.EditControls.UIButton btnNextDoc;
        private Janus.Windows.EditControls.UIButton btnPreviousDoc;
        private Janus.Windows.EditControls.UIButton btnLastDoc;
        private Janus.Windows.EditControls.UIButton btnFirstDoc;
        private Janus.Windows.UI.CommandBars.UICommand cmdFldChooser;
        private Janus.Windows.UI.CommandBars.UICommand cmdFldChooser1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumptToActivity;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumptToActivity1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFirst;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrev;
        private Janus.Windows.UI.CommandBars.UICommand cmdNext;
        private Janus.Windows.UI.CommandBars.UICommand cmdLast;
        private Janus.Windows.UI.CommandBars.UICommand cmdFirst1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrev1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNext1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLast1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFirstHit;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrevHit;
        private Janus.Windows.UI.CommandBars.UICommand cmdNextHit;
        private Janus.Windows.UI.CommandBars.UICommand cmdLastHit;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFirstHit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrevHit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNextHit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdLastHit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggleHighlight;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggleHighlight1;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrintGrid;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrintPreview;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrintGrid1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrintPreview1;
        private Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument1;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private UserControls.ucDocView ucDocView1;
    }
}
