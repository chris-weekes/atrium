 namespace LawMate
{
    partial class ucRecords
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


                myDM.DB.Document.ColumnChanged -= dcceh;
                myDM.GetDocument().OnUpdate -= ueh;
                myDM.DB.DocContent.ColumnChanged -= dcceh;
                myDM.GetDocContent().OnUpdate -= ueh;
                myDM.DB.Recipient.ColumnChanged -= dcceh;
                myDM.GetRecipient().OnUpdate -= ueh;

                this.documentBindingSource.CurrentChanged -= new System.EventHandler(this.documentBindingSource_CurrentChanged);
                this.documentBindingSource.AddingNew -= new System.ComponentModel.AddingNewEventHandler(this.documentBindingSource_AddingNew);
                this.uiPanelManager1.PanelActivated -= new Janus.Windows.UI.Dock.PanelActionEventHandler(this.uiPanelManager1_PanelActivated);
                this.uiCommandManager1.CommandClick -= new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
                ucDocView1.DocLoaded -= new UserControls.DocLoadedEventHandler(ucDocPreview1_DocLoaded);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecords));
            this.docDB = new lmDatasets.docDB();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucRecordList1 = new LawMate.ucRecordList();
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucDocView1 = new LawMate.UserControls.ucDocView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdJumpToActivity1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToActivity");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsPreviewPane1 = new Janus.Windows.UI.CommandBars.UICommand("tsPreviewPane");
            this.tsFilter1 = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.tsGroupBy1 = new Janus.Windows.UI.CommandBars.UICommand("tsGroupBy");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdFieldSelector1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldSelector");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsPreviewPane = new Janus.Windows.UI.CommandBars.UICommand("tsPreviewPane");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsAdd = new Janus.Windows.UI.CommandBars.UICommand("tsAdd");
            this.tsCopy = new Janus.Windows.UI.CommandBars.UICommand("tsCopy");
            this.tsCheckout = new Janus.Windows.UI.CommandBars.UICommand("tsCheckout");
            this.tsCheckin = new Janus.Windows.UI.CommandBars.UICommand("tsCheckin");
            this.tsUndoCheckout = new Janus.Windows.UI.CommandBars.UICommand("tsUndoCheckout");
            this.tsPrint = new Janus.Windows.UI.CommandBars.UICommand("tsPrint");
            this.tsPrintPreview2 = new Janus.Windows.UI.CommandBars.UICommand("tsPrintPreview");
            this.tsPrintPreview = new Janus.Windows.UI.CommandBars.UICommand("tsPrintPreview");
            this.cmdRevise = new Janus.Windows.UI.CommandBars.UICommand("cmdRevise");
            this.tsTemplate = new Janus.Windows.UI.CommandBars.UICommand("tsTemplate");
            this.tsAddRec = new Janus.Windows.UI.CommandBars.UICommand("tsAddRec");
            this.tsActions = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.cmdClone = new Janus.Windows.UI.CommandBars.UICommand("cmdClone");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave3 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsExport1 = new Janus.Windows.UI.CommandBars.UICommand("tsExport");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdJumpToActivity2 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToActivity");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsPreviewPane2 = new Janus.Windows.UI.CommandBars.UICommand("tsPreviewPane");
            this.cmdJumpToActivity = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToActivity");
            this.tsFilter = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.tsGroupBy = new Janus.Windows.UI.CommandBars.UICommand("tsGroupBy");
            this.cmdFieldSelector = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldSelector");
            this.tsExport = new Janus.Windows.UI.CommandBars.UICommand("tsExport");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
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
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.documentBindingSource;
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
            // 
            // docDB
            // 
            this.docDB.DataSetName = "docDB";
            this.docDB.EnforceConstraints = false;
            this.docDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataMember = "Document";
            this.documentBindingSource.DataSource = this.docDB;
            this.documentBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.documentBindingSource_AddingNew);
            this.documentBindingSource.CurrentChanged += new System.EventHandler(this.documentBindingSource_CurrentChanged);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.BackColorGradientSplitter = System.Drawing.Color.White;
            this.uiPanelManager1.BackColorSplitter = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackColor = System.Drawing.Color.GhostWhite;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackColorGradient = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BlendGradient = 0.2F;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.PanelActivated += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.uiPanelManager1_PanelActivated);
            this.pnlGrid.Id = new System.Guid("dfda71cf-ab3f-47c3-aca6-c56befdc2f01");
            this.uiPanelManager1.Panels.Add(this.pnlGrid);
            this.uiPanel1.Id = new System.Guid("29aae7a9-e219-477a-b63a-329b66a66302");
            this.uiPanelManager1.Panels.Add(this.uiPanel1);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("dfda71cf-ab3f-47c3-aca6-c56befdc2f01"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(763, 203), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("29aae7a9-e219-477a-b63a-329b66a66302"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(763, 375), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("dfda71cf-ab3f-47c3-aca6-c56befdc2f01"), new System.Drawing.Point(110, 145), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e3f110de-6163-4ce2-9f98-11895e93a274"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ddb7cd2a-0f8f-4b59-b734-c0cd75555fac"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7915bdab-733d-4860-8369-72faa5ba24de"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0b04cb99-a0ca-4630-9bf2-db3ddf5440fb"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c3c29af3-af5c-4f04-a1c5-f26e3699372b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8daabda9-ee30-44d5-a4cc-ba4716c3635a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("06e5b083-a7a3-4541-ad66-c662e7b965c1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c94e8660-e166-42fe-b72b-97e571a2f1ba"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("64ccbc6f-b6b6-4b88-a3bc-dba334f832f0"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("db824b68-65f7-41c0-bcd3-14de72e2bcd2"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("2ba84890-47e1-469b-af75-43c55a2a47f3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("29aae7a9-e219-477a-b63a-329b66a66302"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGrid.CaptionFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical;
            this.pnlGrid.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlGrid.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGrid.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGrid.FloatingLocation = new System.Drawing.Point(110, 145);
            this.pnlGrid.InnerContainer = this.pnlGridContainer;
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            this.helpProvider1.SetShowHelp(this.pnlGrid, ((bool)(resources.GetObject("pnlGrid.ShowHelp"))));
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.ucRecordList1);
            resources.ApplyResources(this.pnlGridContainer, "pnlGridContainer");
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.helpProvider1.SetShowHelp(this.pnlGridContainer, ((bool)(resources.GetObject("pnlGridContainer.ShowHelp"))));
            // 
            // ucRecordList1
            // 
            this.ucRecordList1.DataSource = this.documentBindingSource;
            resources.ApplyResources(this.ucRecordList1, "ucRecordList1");
            this.ucRecordList1.InEditMode = false;
            this.ucRecordList1.Name = "ucRecordList1";
            this.ucRecordList1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            this.helpProvider1.SetShowHelp(this.ucRecordList1, ((bool)(resources.GetObject("ucRecordList1.ShowHelp"))));
            // 
            // uiPanel1
            // 
            this.uiPanel1.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            resources.ApplyResources(this.uiPanel1, "uiPanel1");
            this.uiPanel1.Name = "uiPanel1";
            this.helpProvider1.SetShowHelp(this.uiPanel1, ((bool)(resources.GetObject("uiPanel1.ShowHelp"))));
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.ucDocView1);
            resources.ApplyResources(this.uiPanel1Container, "uiPanel1Container");
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.helpProvider1.SetShowHelp(this.uiPanel1Container, ((bool)(resources.GetObject("uiPanel1Container.ShowHelp"))));
            // 
            // ucDocView1
            // 
            this.ucDocView1.ActionToolbarView = LawMate.UserControls.DocCommandBar.Enable;
            this.ucDocView1.AllowActionToolbar = true;
            this.ucDocView1.AllowMetadata = true;
            this.ucDocView1.AllowMetadataUpdate = false;
            this.ucDocView1.BackColor = System.Drawing.Color.Transparent;
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
            this.ucDocView1.DocAction += new LawMate.UserControls.DocActionEventHandler(this.ucDocPreview1_DocAction);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.tsDelete2,
            this.tsSave2,
            this.tsScreenTitle,
            this.tsPreviewPane,
            this.tsAudit,
            this.tsEditmode,
            this.tsAdd,
            this.tsCopy,
            this.tsCheckout,
            this.tsCheckin,
            this.tsUndoCheckout,
            this.tsPrint,
            this.tsPrintPreview,
            this.cmdRevise,
            this.tsTemplate,
            this.tsAddRec,
            this.tsActions,
            this.cmdClone,
            this.cmdFile,
            this.cmdEdit,
            this.cmdView,
            this.cmdJumpToActivity,
            this.tsFilter,
            this.tsGroupBy,
            this.cmdFieldSelector,
            this.tsExport});
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
            this.Separator6,
            this.cmdJumpToActivity1,
            this.Separator2,
            this.tsPreviewPane1,
            this.tsFilter1,
            this.tsGroupBy1,
            this.Separator5,
            this.cmdFieldSelector1,
            this.Separator3,
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
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdJumpToActivity1
            // 
            resources.ApplyResources(this.cmdJumpToActivity1, "cmdJumpToActivity1");
            this.cmdJumpToActivity1.Name = "cmdJumpToActivity1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsPreviewPane1
            // 
            resources.ApplyResources(this.tsPreviewPane1, "tsPreviewPane1");
            this.tsPreviewPane1.Name = "tsPreviewPane1";
            // 
            // tsFilter1
            // 
            resources.ApplyResources(this.tsFilter1, "tsFilter1");
            this.tsFilter1.Name = "tsFilter1";
            // 
            // tsGroupBy1
            // 
            resources.ApplyResources(this.tsGroupBy1, "tsGroupBy1");
            this.tsGroupBy1.Name = "tsGroupBy1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdFieldSelector1
            // 
            resources.ApplyResources(this.cmdFieldSelector1, "cmdFieldSelector1");
            this.cmdFieldSelector1.Name = "cmdFieldSelector1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
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
            // tsPreviewPane
            // 
            this.tsPreviewPane.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.tsPreviewPane.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsPreviewPane.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsPreviewPane, "tsPreviewPane");
            this.tsPreviewPane.Name = "tsPreviewPane";
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
            this.tsEditmode.StateStyles.FormatStyle.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            // 
            // tsAdd
            // 
            this.tsAdd.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsAdd, "tsAdd");
            this.tsAdd.Name = "tsAdd";
            // 
            // tsCopy
            // 
            this.tsCopy.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsCopy, "tsCopy");
            this.tsCopy.Name = "tsCopy";
            // 
            // tsCheckout
            // 
            this.tsCheckout.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsCheckout, "tsCheckout");
            this.tsCheckout.Name = "tsCheckout";
            // 
            // tsCheckin
            // 
            this.tsCheckin.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsCheckin, "tsCheckin");
            this.tsCheckin.Name = "tsCheckin";
            // 
            // tsUndoCheckout
            // 
            this.tsUndoCheckout.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsUndoCheckout, "tsUndoCheckout");
            this.tsUndoCheckout.Name = "tsUndoCheckout";
            // 
            // tsPrint
            // 
            this.tsPrint.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsPrintPreview2});
            this.tsPrint.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsPrint, "tsPrint");
            this.tsPrint.Name = "tsPrint";
            // 
            // tsPrintPreview2
            // 
            resources.ApplyResources(this.tsPrintPreview2, "tsPrintPreview2");
            this.tsPrintPreview2.Name = "tsPrintPreview2";
            // 
            // tsPrintPreview
            // 
            this.tsPrintPreview.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsPrintPreview, "tsPrintPreview");
            this.tsPrintPreview.Name = "tsPrintPreview";
            // 
            // cmdRevise
            // 
            resources.ApplyResources(this.cmdRevise, "cmdRevise");
            this.cmdRevise.Name = "cmdRevise";
            // 
            // tsTemplate
            // 
            this.tsTemplate.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsTemplate, "tsTemplate");
            this.tsTemplate.Name = "tsTemplate";
            // 
            // tsAddRec
            // 
            resources.ApplyResources(this.tsAddRec, "tsAddRec");
            this.tsAddRec.Name = "tsAddRec";
            // 
            // tsActions
            // 
            this.tsActions.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsActions, "tsActions");
            this.tsActions.Name = "tsActions";
            // 
            // cmdClone
            // 
            resources.ApplyResources(this.cmdClone, "cmdClone");
            this.cmdClone.Name = "cmdClone";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave3,
            this.tsExport1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave3
            // 
            resources.ApplyResources(this.tsSave3, "tsSave3");
            this.tsSave3.Name = "tsSave3";
            // 
            // tsExport1
            // 
            resources.ApplyResources(this.tsExport1, "tsExport1");
            this.tsExport1.Name = "tsExport1";
            this.tsExport1.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdEdit
            // 
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdJumpToActivity2,
            this.Separator4,
            this.tsPreviewPane2});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView.Name = "cmdView";
            // 
            // cmdJumpToActivity2
            // 
            resources.ApplyResources(this.cmdJumpToActivity2, "cmdJumpToActivity2");
            this.cmdJumpToActivity2.Name = "cmdJumpToActivity2";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsPreviewPane2
            // 
            resources.ApplyResources(this.tsPreviewPane2, "tsPreviewPane2");
            this.tsPreviewPane2.Name = "tsPreviewPane2";
            // 
            // cmdJumpToActivity
            // 
            resources.ApplyResources(this.cmdJumpToActivity, "cmdJumpToActivity");
            this.cmdJumpToActivity.Name = "cmdJumpToActivity";
            // 
            // tsFilter
            // 
            this.tsFilter.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsFilter, "tsFilter");
            this.tsFilter.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            this.tsFilter.Name = "tsFilter";
            // 
            // tsGroupBy
            // 
            this.tsGroupBy.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsGroupBy, "tsGroupBy");
            this.tsGroupBy.Name = "tsGroupBy";
            // 
            // cmdFieldSelector
            // 
            resources.ApplyResources(this.cmdFieldSelector, "cmdFieldSelector");
            this.cmdFieldSelector.Name = "cmdFieldSelector";
            // 
            // tsExport
            // 
            resources.ApplyResources(this.tsExport, "tsExport");
            this.tsExport.Name = "tsExport";
            this.tsExport.Visible = Janus.Windows.UI.InheritableBoolean.False;
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucRecords
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucRecords";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.VisibleChanged += new System.EventHandler(this.ucRecords_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
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

        private lmDatasets.docDB docDB;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        //private Janus.Windows.UI.Dock.UIPanel pnlDetail;
        //private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDetailContainer;
        //private Janus.Windows.UI.Dock.UIPanel pnlPreview;
        //private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlPreviewContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        //private Janus.Windows.EditControls.UIGroupBox gbDocMetadata;
        //private System.Windows.Forms.Label extLabel1;
        //private System.Windows.Forms.Label sizeLabel2;
        //private Janus.Windows.CalendarCombo.CalendarCombo efDateCalendarCombo;
        //private System.Windows.Forms.TextBox efCodesTextBox;
        //private System.Windows.Forms.Label sourceLabel1;
        //private System.Windows.Forms.TextBox keywordsTextBox;
        //private System.Windows.Forms.Label filedByLabel1;
        //private System.Windows.Forms.TextBox pathTextBox;
        //private Janus.Windows.CalendarCombo.CalendarCombo modDateCalendarCombo;
        //private System.Windows.Forms.Label authorLabel1;
        //private System.Windows.Forms.CheckBox pVCheckBox;
        //private Janus.Windows.CalendarCombo.CalendarCombo createDateCalendarCombo;
        //private System.Windows.Forms.CheckBox isDraftCheckBox;
        //private System.Windows.Forms.TextBox efToTextBox;
        //private System.Windows.Forms.TextBox efFromTextBox;
        //private System.Windows.Forms.TextBox efSubjectTextBox;
        //private System.Windows.Forms.CheckBox isElectronicCheckBox;
        //private System.Windows.Forms.CheckBox isPaperCheckBox;
        //private System.Windows.Forms.ComboBox efTypeComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ucRecordList ucRecordList1;
        //private System.Windows.Forms.CheckBox opinionCheckBox;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsPreviewPane;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsPreviewPane1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        //private System.Windows.Forms.ComboBox languageComboBox;
        private Janus.Windows.UI.Dock.UIPanel uiPanel1;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private Janus.Windows.UI.CommandBars.UICommand tsAdd;
        private Janus.Windows.UI.CommandBars.UICommand tsCopy;
        private Janus.Windows.UI.CommandBars.UICommand tsCheckout;
        private Janus.Windows.UI.CommandBars.UICommand tsCheckin;
        private Janus.Windows.UI.CommandBars.UICommand tsUndoCheckout;
        private Janus.Windows.UI.CommandBars.UICommand tsPrint;
        private Janus.Windows.UI.CommandBars.UICommand tsPrintPreview;
        private Janus.Windows.UI.CommandBars.UICommand cmdRevise;
        private Janus.Windows.UI.CommandBars.UICommand tsTemplate;
        private Janus.Windows.UI.CommandBars.UICommand tsAddRec;
        private Janus.Windows.UI.CommandBars.UICommand tsActions;
        private Janus.Windows.UI.CommandBars.UICommand tsPrintPreview2;
        private Janus.Windows.UI.CommandBars.UICommand cmdClone;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave3;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand tsPreviewPane2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToActivity;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToActivity1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToActivity2;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter;
        private Janus.Windows.UI.CommandBars.UICommand tsGroupBy;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter1;
        private Janus.Windows.UI.CommandBars.UICommand tsGroupBy1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldSelector;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldSelector1;
        private Janus.Windows.UI.CommandBars.UICommand tsExport1;
        private Janus.Windows.UI.CommandBars.UICommand tsExport;
        private UserControls.ucDocView ucDocView1;
        private System.Windows.Forms.Timer timer1;
    }
}
