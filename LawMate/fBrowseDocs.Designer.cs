namespace LawMate
{
    partial class fBrowseDocs
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
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBrowseDocs));
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.ImageListMain = new System.Windows.Forms.ImageList(this.components);
            this.pnlMessage = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlMessageContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLeft = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlBrowseSelect = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBrowseSelectContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucBrowse1 = new LawMate.UserControls.ucBrowse();
            this.pnlSearch = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSearchContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnPerformSearch = new Janus.Windows.EditControls.UIButton();
            this.ebSearchFor = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cbSearchType = new Janus.Windows.EditControls.UIComboBox();
            this.lblOn = new System.Windows.Forms.Label();
            this.lblSearchFor = new System.Windows.Forms.Label();
            this.pnlResults = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlResultsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.buttonCancel = new Janus.Windows.EditControls.UIButton();
            this.buttonOK = new Janus.Windows.EditControls.UIButton();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.ucRecordList1 = new LawMate.ucRecordList();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.pnlSearchResults = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSearchResultsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).BeginInit();
            this.pnlMessage.SuspendLayout();
            this.pnlMessageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseSelect)).BeginInit();
            this.pnlBrowseSelect.SuspendLayout();
            this.pnlBrowseSelectContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResults)).BeginInit();
            this.pnlResults.SuspendLayout();
            this.pnlResultsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchResults)).BeginInit();
            this.pnlSearchResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataMember = "Document";
            this.documentBindingSource.CurrentChanged += new System.EventHandler(this.documentBindingSource_CurrentChanged);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideTabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.ImageAndText;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.ImageList = this.ImageListMain;
            this.uiPanelManager1.SplitterSize = 3;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.PanelActivated += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.uiPanelManager1_PanelActivated);
            this.pnlMessage.Id = new System.Guid("dd406747-d700-4225-b755-c86856f2f455");
            this.uiPanelManager1.Panels.Add(this.pnlMessage);
            this.pnlLeft.Id = new System.Guid("bc74e180-36c2-48fc-8d88-4b32658bda60");
            this.pnlLeft.StaticGroup = true;
            this.pnlBrowseSelect.Id = new System.Guid("087b713c-a2ee-4c47-99c6-75d897ec3c1f");
            this.pnlLeft.Panels.Add(this.pnlBrowseSelect);
            this.pnlSearch.Id = new System.Guid("8c3687f0-9dfa-46cb-8fe6-fe9f0bb49614");
            this.pnlLeft.Panels.Add(this.pnlSearch);
            this.uiPanelManager1.Panels.Add(this.pnlLeft);
            this.pnlResults.Id = new System.Guid("d1c3dcf5-2bae-4515-b2f0-c71d0f22969e");
            this.uiPanelManager1.Panels.Add(this.pnlResults);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("dd406747-d700-4225-b755-c86856f2f455"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(957, 26), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("bc74e180-36c2-48fc-8d88-4b32658bda60"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(233, 419), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("087b713c-a2ee-4c47-99c6-75d897ec3c1f"), new System.Guid("bc74e180-36c2-48fc-8d88-4b32658bda60"), 162, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("8c3687f0-9dfa-46cb-8fe6-fe9f0bb49614"), new System.Guid("bc74e180-36c2-48fc-8d88-4b32658bda60"), 162, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("d1c3dcf5-2bae-4515-b2f0-c71d0f22969e"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(724, 419), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("bc74e180-36c2-48fc-8d88-4b32658bda60"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8c3687f0-9dfa-46cb-8fe6-fe9f0bb49614"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3bd9ae9b-99e1-4c95-b945-fd82d24ad8fb"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3f525188-93da-4e30-8186-26d1862b7c98"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("df782b78-737b-481b-a2fa-304f66c8245c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("47c1098b-839d-4bfe-be5d-e9d6b0bc0912"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c406b984-eefa-4c55-8ae1-5f0d536c02ff"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c991dfa0-e8c0-4433-b4f6-a4a7d0b95073"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("087b713c-a2ee-4c47-99c6-75d897ec3c1f"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0210b985-6364-4b49-b58e-36782a8907c5"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("dd406747-d700-4225-b755-c86856f2f455"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d1c3dcf5-2bae-4515-b2f0-c71d0f22969e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // ImageListMain
            // 
            this.ImageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListMain.ImageStream")));
            this.ImageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListMain.Images.SetKeyName(0, "drafts.gif");
            this.ImageListMain.Images.SetKeyName(1, "shortcut.gif");
            this.ImageListMain.Images.SetKeyName(2, "reports.gif");
            this.ImageListMain.Images.SetKeyName(3, "batch.gif");
            this.ImageListMain.Images.SetKeyName(4, "myDocuments.gif");
            this.ImageListMain.Images.SetKeyName(5, "cal.gif");
            this.ImageListMain.Images.SetKeyName(6, "bs.gif");
            this.ImageListMain.Images.SetKeyName(7, "bo.gif");
            this.ImageListMain.Images.SetKeyName(8, "doc.gif");
            this.ImageListMain.Images.SetKeyName(9, "msgS.gif");
            this.ImageListMain.Images.SetKeyName(10, "datePick.gif");
            this.ImageListMain.Images.SetKeyName(11, "search.gif");
            this.ImageListMain.Images.SetKeyName(12, "FSArchived.ico");
            this.ImageListMain.Images.SetKeyName(13, "FSClosed.ico");
            this.ImageListMain.Images.SetKeyName(14, "FSMonitored.ico");
            this.ImageListMain.Images.SetKeyName(15, "FSOpen.ico");
            this.ImageListMain.Images.SetKeyName(16, "FSPending.ico");
            this.ImageListMain.Images.SetKeyName(17, "folder.gif");
            // 
            // pnlMessage
            // 
            this.pnlMessage.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlMessage, "pnlMessage");
            this.pnlMessage.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlMessage.InnerContainer = this.pnlMessageContainer;
            this.pnlMessage.Name = "pnlMessage";
            // 
            // pnlMessageContainer
            // 
            this.pnlMessageContainer.Controls.Add(this.label2);
            this.pnlMessageContainer.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlMessageContainer, "pnlMessageContainer");
            this.pnlMessageContainer.Name = "pnlMessageContainer";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = global::LawMate.Properties.Resources.paper;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // pnlLeft
            // 
            this.pnlLeft.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.SelectedPanel = this.pnlSearch;
            // 
            // pnlBrowseSelect
            // 
            resources.ApplyResources(this.pnlBrowseSelect, "pnlBrowseSelect");
            this.pnlBrowseSelect.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlBrowseSelect.InnerContainer = this.pnlBrowseSelectContainer;
            this.pnlBrowseSelect.Name = "pnlBrowseSelect";
            // 
            // pnlBrowseSelectContainer
            // 
            this.pnlBrowseSelectContainer.Controls.Add(this.ucBrowse1);
            resources.ApplyResources(this.pnlBrowseSelectContainer, "pnlBrowseSelectContainer");
            this.pnlBrowseSelectContainer.Name = "pnlBrowseSelectContainer";
            // 
            // ucBrowse1
            // 
            this.ucBrowse1.DisplayJumpToOptions = true;
            this.ucBrowse1.DisplayOptionPanel = true;
            resources.ApplyResources(this.ucBrowse1, "ucBrowse1");
            this.ucBrowse1.HideXrefs = false;
            this.ucBrowse1.Name = "ucBrowse1";
            this.ucBrowse1.ShowContextMenu = true;
            this.ucBrowse1.ShowFileNumber = false;
            this.ucBrowse1.ShowOnlyOpenFiles = false;
            this.ucBrowse1.FileSelected += new LawMate.UserControls.BrowseEventHandler(this.ucBrowse1_FileSelected);
            // 
            // pnlSearch
            // 
            resources.ApplyResources(this.pnlSearch, "pnlSearch");
            this.pnlSearch.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlSearch.InnerContainer = this.pnlSearchContainer;
            this.pnlSearch.Name = "pnlSearch";
            // 
            // pnlSearchContainer
            // 
            resources.ApplyResources(this.pnlSearchContainer, "pnlSearchContainer");
            this.pnlSearchContainer.Controls.Add(this.btnPerformSearch);
            this.pnlSearchContainer.Controls.Add(this.ebSearchFor);
            this.pnlSearchContainer.Controls.Add(this.cbSearchType);
            this.pnlSearchContainer.Controls.Add(this.lblOn);
            this.pnlSearchContainer.Controls.Add(this.lblSearchFor);
            this.pnlSearchContainer.Name = "pnlSearchContainer";
            // 
            // btnPerformSearch
            // 
            this.btnPerformSearch.Image = global::LawMate.Properties.Resources.search;
            resources.ApplyResources(this.btnPerformSearch, "btnPerformSearch");
            this.btnPerformSearch.Name = "btnPerformSearch";
            this.btnPerformSearch.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnPerformSearch.Click += new System.EventHandler(this.btnExecuteSearch_Click);
            // 
            // ebSearchFor
            // 
            resources.ApplyResources(this.ebSearchFor, "ebSearchFor");
            this.ebSearchFor.Name = "ebSearchFor";
            this.ebSearchFor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.ebSearchFor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ebSearchFor_KeyDown);
            // 
            // cbSearchType
            // 
            this.cbSearchType.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.cbSearchType.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            resources.ApplyResources(uiComboBoxItem1, "uiComboBoxItem1");
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.IsSeparator = false;
            resources.ApplyResources(uiComboBoxItem2, "uiComboBoxItem2");
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.IsSeparator = false;
            resources.ApplyResources(uiComboBoxItem3, "uiComboBoxItem3");
            this.cbSearchType.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2,
            uiComboBoxItem3});
            resources.ApplyResources(this.cbSearchType, "cbSearchType");
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cbSearchType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ebSearchFor_KeyDown);
            // 
            // lblOn
            // 
            resources.ApplyResources(this.lblOn, "lblOn");
            this.lblOn.BackColor = System.Drawing.Color.Transparent;
            this.lblOn.Name = "lblOn";
            // 
            // lblSearchFor
            // 
            resources.ApplyResources(this.lblSearchFor, "lblSearchFor");
            this.lblSearchFor.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchFor.Name = "lblSearchFor";
            // 
            // pnlResults
            // 
            this.pnlResults.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlResults.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlResults.InnerContainer = this.pnlResultsContainer;
            resources.ApplyResources(this.pnlResults, "pnlResults");
            this.pnlResults.Name = "pnlResults";
            // 
            // pnlResultsContainer
            // 
            this.pnlResultsContainer.Controls.Add(this.buttonCancel);
            this.pnlResultsContainer.Controls.Add(this.buttonOK);
            this.pnlResultsContainer.Controls.Add(this.uiTab1);
            this.pnlResultsContainer.Controls.Add(this.uiButton1);
            this.pnlResultsContainer.Controls.Add(this.lblSelectedFile);
            this.pnlResultsContainer.Controls.Add(this.lblCurrentFile);
            resources.ApplyResources(this.pnlResultsContainer, "pnlResultsContainer");
            this.pnlResultsContainer.Name = "pnlResultsContainer";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.buttonOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // uiTab1
            // 
            resources.ApplyResources(this.uiTab1, "uiTab1");
            this.uiTab1.BackColor = System.Drawing.Color.Transparent;
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.ShowFocusRectangle = false;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.ucRecordList1);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.TabStop = true;
            // 
            // ucRecordList1
            // 
            resources.ApplyResources(this.ucRecordList1, "ucRecordList1");
            this.ucRecordList1.DataSource = this.documentBindingSource;
            this.ucRecordList1.InEditMode = false;
            this.ucRecordList1.Name = "ucRecordList1";
            this.ucRecordList1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            // 
            // uiButton1
            // 
            this.uiButton1.HighlightActiveButton = false;
            this.uiButton1.Image = global::LawMate.Properties.Resources.docMoreInfo;
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.ShowFocusRectangle = false;
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // lblSelectedFile
            // 
            resources.ApplyResources(this.lblSelectedFile, "lblSelectedFile");
            this.lblSelectedFile.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFile.Name = "lblSelectedFile";
            // 
            // lblCurrentFile
            // 
            resources.ApplyResources(this.lblCurrentFile, "lblCurrentFile");
            this.lblCurrentFile.AutoEllipsis = true;
            this.lblCurrentFile.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.MouseHover += new System.EventHandler(this.lblCurrentFile_MouseHover);
            // 
            // pnlSearchResults
            // 
            this.pnlSearchResults.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlSearchResults.InnerContainer = this.pnlSearchResultsContainer;
            resources.ApplyResources(this.pnlSearchResults, "pnlSearchResults");
            this.pnlSearchResults.Name = "pnlSearchResults";
            // 
            // pnlSearchResultsContainer
            // 
            resources.ApplyResources(this.pnlSearchResultsContainer, "pnlSearchResultsContainer");
            this.pnlSearchResultsContainer.Name = "pnlSearchResultsContainer";
            // 
            // fBrowseDocs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.buttonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlMessage);
            this.Name = "fBrowseDocs";
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessageContainer.ResumeLayout(false);
            this.pnlMessageContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseSelect)).EndInit();
            this.pnlBrowseSelect.ResumeLayout(false);
            this.pnlBrowseSelectContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearchContainer.ResumeLayout(false);
            this.pnlSearchContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResults)).EndInit();
            this.pnlResults.ResumeLayout(false);
            this.pnlResultsContainer.ResumeLayout(false);
            this.pnlResultsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchResults)).EndInit();
            this.pnlSearchResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource documentBindingSource;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private UserControls.ucBrowse ucBrowse1;
        private ucRecordList ucRecordList1;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Label lblSelectedFile;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlLeft;
        private Janus.Windows.UI.Dock.UIPanel pnlBrowseSelect;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBrowseSelectContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSearch;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSearchContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSearchResults;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSearchResultsContainer;
        private System.Windows.Forms.ImageList ImageListMain;
        private Janus.Windows.EditControls.UIComboBox cbSearchType;
        private System.Windows.Forms.Label lblOn;
        private System.Windows.Forms.Label lblSearchFor;
        private System.Windows.Forms.ToolTip toolTip1;
        private Janus.Windows.UI.Dock.UIPanel pnlMessage;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlMessageContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Dock.UIPanel pnlResults;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlResultsContainer;
        private Janus.Windows.GridEX.EditControls.EditBox ebSearchFor;
        private Janus.Windows.EditControls.UIButton btnPerformSearch;
        private Janus.Windows.EditControls.UIButton buttonCancel;
        private Janus.Windows.EditControls.UIButton buttonOK;

    }
}
