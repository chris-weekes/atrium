 namespace LawMate.UserControls
{
    partial class ucOfficerToolkit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOfficerToolkit));
            this.tvOfficerToolkit = new System.Windows.Forms.TreeView();
            this.ImageListMain = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdBFList = new Janus.Windows.UI.CommandBars.UICommand("cmdBFList");
            this.cmdDocs = new Janus.Windows.UI.CommandBars.UICommand("cmdDocs");
            this.cmdFiles = new Janus.Windows.UI.CommandBars.UICommand("cmdFiles");
            this.cmdCalendar = new Janus.Windows.UI.CommandBars.UICommand("cmdCalendar");
            this.cmdAddBook = new Janus.Windows.UI.CommandBars.UICommand("cmdAddBook");
            this.cmdPersonalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdPersonalFile");
            this.cmdMyOffice = new Janus.Windows.UI.CommandBars.UICommand("cmdMyOffice");
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdBFList1 = new Janus.Windows.UI.CommandBars.UICommand("cmdBFList");
            this.cmdDocs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocs");
            this.cmdFiles1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFiles");
            this.cmdCalendar1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCalendar");
            this.cmdAddBook1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddBook");
            this.cmdPersonalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPersonalFile");
            this.cmdMyOffice1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMyOffice");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.ucFileContextMenu1 = new LawMate.ucFileContextMenu();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tvOfficerToolkit
            // 
            this.tvOfficerToolkit.AllowDrop = true;
            this.tvOfficerToolkit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tvOfficerToolkit, "tvOfficerToolkit");
            this.tvOfficerToolkit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tvOfficerToolkit.ItemHeight = 19;
            this.tvOfficerToolkit.LabelEdit = true;
            this.tvOfficerToolkit.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.tvOfficerToolkit.Name = "tvOfficerToolkit";
            this.tvOfficerToolkit.ShowLines = false;
            this.tvOfficerToolkit.ShowNodeToolTips = true;
            this.tvOfficerToolkit.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvOfficerToolkit_NodeMouseClick);
            this.tvOfficerToolkit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOfficerToolkit_MouseDown);
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
            this.ImageListMain.Images.SetKeyName(12, "user.gif");
            this.ImageListMain.Images.SetKeyName(13, "unlinkedMail.gif");
            this.ImageListMain.Images.SetKeyName(14, "Inbox1.gif");
            this.ImageListMain.Images.SetKeyName(15, "folder.gif");
            this.ImageListMain.Images.SetKeyName(16, "MarkasRead.gif");
            this.ImageListMain.Images.SetKeyName(17, "minus.gif");
            this.ImageListMain.Images.SetKeyName(18, "plus.gif");
            this.ImageListMain.Images.SetKeyName(19, "ShortcutFile.gif");
            this.ImageListMain.Images.SetKeyName(20, "XRefFile.gif");
            this.ImageListMain.Images.SetKeyName(21, "penPaperS.png");
            this.ImageListMain.Images.SetKeyName(22, "checkbox.gif");
            this.ImageListMain.Images.SetKeyName(23, "docShortcut.gif");
            this.ImageListMain.Images.SetKeyName(24, "reload.gif");
            this.ImageListMain.Images.SetKeyName(25, "windows.gif");
            this.ImageListMain.Images.SetKeyName(26, "docViewer.png");
            this.ImageListMain.Images.SetKeyName(27, "delete.gif");
            this.ImageListMain.Images.SetKeyName(28, "find.gif");
            this.ImageListMain.Images.SetKeyName(29, "lawmateExplorer.gif");
            this.ImageListMain.Images.SetKeyName(30, "DraftDocument.jpg");
            this.ImageListMain.Images.SetKeyName(31, "DocumentCheckOut.jpg");
            this.ImageListMain.Images.SetKeyName(32, "user16.gif");
            this.ImageListMain.Images.SetKeyName(33, "ContainerCube.gif");
            this.ImageListMain.Images.SetKeyName(34, "FileNode.gif");
            this.ImageListMain.Images.SetKeyName(35, "FileContainer.png");
            this.ImageListMain.Images.SetKeyName(36, "fileShortcut.png");
            this.ImageListMain.Images.SetKeyName(37, "office-building.png");
            this.ImageListMain.Images.SetKeyName(38, "shortcut.gif");
            this.ImageListMain.Images.SetKeyName(39, "address-book.png");
            this.ImageListMain.Images.SetKeyName(40, "allmail.png");
            this.ImageListMain.Images.SetKeyName(41, "calendar_icon.png");
            this.ImageListMain.Images.SetKeyName(42, "unreadmail.png");
            this.ImageListMain.Images.SetKeyName(43, "Calendar.png");
            this.ImageListMain.Images.SetKeyName(44, "folder.png");
            this.ImageListMain.Images.SetKeyName(45, "document.png");
            this.ImageListMain.Images.SetKeyName(46, "clock16.png");
            this.ImageListMain.Images.SetKeyName(47, "otkCalendar.png");
            this.ImageListMain.Images.SetKeyName(48, "shortcut2.png");
            this.ImageListMain.Images.SetKeyName(49, "filenodepng.png");
            this.ImageListMain.Images.SetKeyName(50, "fsA.gif");
            this.ImageListMain.Images.SetKeyName(51, "fsC.gif");
            this.ImageListMain.Images.SetKeyName(52, "fsM.gif");
            this.ImageListMain.Images.SetKeyName(53, "fsO.gif");
            this.ImageListMain.Images.SetKeyName(54, "fsP.gif");
            this.ImageListMain.Images.SetKeyName(55, "whitefolder.png");
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // uiCommandManager1
            // 
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdBFList,
            this.cmdDocs,
            this.cmdFiles,
            this.cmdCalendar,
            this.cmdAddBook,
            this.cmdPersonalFile,
            this.cmdMyOffice});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("95e6a26f-25d2-4a39-aace-1814007a9cc8");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            // 
            // cmdBFList
            // 
            this.cmdBFList.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdBFList, "cmdBFList");
            this.cmdBFList.Name = "cmdBFList";
            // 
            // cmdDocs
            // 
            this.cmdDocs.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdDocs, "cmdDocs");
            this.cmdDocs.Name = "cmdDocs";
            // 
            // cmdFiles
            // 
            this.cmdFiles.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdFiles, "cmdFiles");
            this.cmdFiles.Name = "cmdFiles";
            // 
            // cmdCalendar
            // 
            this.cmdCalendar.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdCalendar, "cmdCalendar");
            this.cmdCalendar.Name = "cmdCalendar";
            // 
            // cmdAddBook
            // 
            this.cmdAddBook.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdAddBook, "cmdAddBook");
            this.cmdAddBook.Name = "cmdAddBook";
            // 
            // cmdPersonalFile
            // 
            this.cmdPersonalFile.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdPersonalFile, "cmdPersonalFile");
            this.cmdPersonalFile.Name = "cmdPersonalFile";
            // 
            // cmdMyOffice
            // 
            this.cmdMyOffice.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdMyOffice, "cmdMyOffice");
            this.cmdMyOffice.Name = "cmdMyOffice";
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdBFList1,
            this.cmdDocs1,
            this.cmdFiles1,
            this.cmdCalendar1,
            this.cmdAddBook1,
            this.cmdPersonalFile1,
            this.cmdMyOffice1});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.Popup += new System.EventHandler(this.uiContextMenu1_Popup);
            // 
            // cmdBFList1
            // 
            resources.ApplyResources(this.cmdBFList1, "cmdBFList1");
            this.cmdBFList1.Name = "cmdBFList1";
            // 
            // cmdDocs1
            // 
            resources.ApplyResources(this.cmdDocs1, "cmdDocs1");
            this.cmdDocs1.Name = "cmdDocs1";
            // 
            // cmdFiles1
            // 
            resources.ApplyResources(this.cmdFiles1, "cmdFiles1");
            this.cmdFiles1.Name = "cmdFiles1";
            // 
            // cmdCalendar1
            // 
            resources.ApplyResources(this.cmdCalendar1, "cmdCalendar1");
            this.cmdCalendar1.Name = "cmdCalendar1";
            // 
            // cmdAddBook1
            // 
            resources.ApplyResources(this.cmdAddBook1, "cmdAddBook1");
            this.cmdAddBook1.Name = "cmdAddBook1";
            // 
            // cmdPersonalFile1
            // 
            resources.ApplyResources(this.cmdPersonalFile1, "cmdPersonalFile1");
            this.cmdPersonalFile1.Name = "cmdPersonalFile1";
            // 
            // cmdMyOffice1
            // 
            resources.ApplyResources(this.cmdMyOffice1, "cmdMyOffice1");
            this.cmdMyOffice1.Name = "cmdMyOffice1";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // ucFileContextMenu1
            // 
            resources.ApplyResources(this.ucFileContextMenu1, "ucFileContextMenu1");
            this.ucFileContextMenu1.Name = "ucFileContextMenu1";
            this.ucFileContextMenu1.UsedInTreeView = true;
            // 
            // ucOfficerToolkit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ucFileContextMenu1);
            this.Controls.Add(this.tvOfficerToolkit);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.BottomRebar1);
            resources.ApplyResources(this, "$this");
            this.Name = "ucOfficerToolkit";
            this.Load += new System.EventHandler(this.ucOfficerToolkit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ImageListMain;
        public System.Windows.Forms.TreeView tvOfficerToolkit;
        public ucFileContextMenu ucFileContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdBFList;
        private Janus.Windows.UI.CommandBars.UICommand cmdFiles;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocs;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddBook;
        private Janus.Windows.UI.CommandBars.UICommand cmdPersonalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdMyOffice;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdBFList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFiles1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddBook1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPersonalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMyOffice1;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCalendar;
        private Janus.Windows.UI.CommandBars.UICommand cmdCalendar1;
    }
}
