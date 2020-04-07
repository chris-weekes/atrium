 namespace LawMate.UserControls
{
    partial class ucBrowse
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
                if(myFM!=null)
                    myFM.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBrowse));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdShowFN2 = new Janus.Windows.UI.CommandBars.UICommand("cmdShowFN");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdShowOpenFiles2 = new Janus.Windows.UI.CommandBars.UICommand("cmdShowOpenFiles");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdHideXRef2 = new Janus.Windows.UI.CommandBars.UICommand("cmdHideXRef");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdJump1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJump");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdReset1 = new Janus.Windows.UI.CommandBars.UICommand("cmdReset");
            this.cmdShowFN = new Janus.Windows.UI.CommandBars.UICommand("cmdShowFN");
            this.cmdShowOpenFiles = new Janus.Windows.UI.CommandBars.UICommand("cmdShowOpenFiles");
            this.cmdHideXRef = new Janus.Windows.UI.CommandBars.UICommand("cmdHideXRef");
            this.cmdReset = new Janus.Windows.UI.CommandBars.UICommand("cmdReset");
            this.cmdJumpPersonal = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpPersonal");
            this.cmdJumpShortcuts = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpShortcuts");
            this.cmdJumpOffice = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpOffice");
            this.cmdJump = new Janus.Windows.UI.CommandBars.UICommand("cmdJump");
            this.cmdJumpPersonal1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpPersonal");
            this.cmdJumpShortcuts1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpShortcuts");
            this.cmdJumpOffice1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpOffice");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.ucFileContextMenu1 = new LawMate.ucFileContextMenu();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bs.gif");
            this.imageList1.Images.SetKeyName(1, "bo.gif");
            this.imageList1.Images.SetKeyName(2, "form.gif");
            this.imageList1.Images.SetKeyName(3, "folder.gif");
            this.imageList1.Images.SetKeyName(4, "XRefFile.gif");
            this.imageList1.Images.SetKeyName(5, "ShortcutFile.gif");
            this.imageList1.Images.SetKeyName(6, "ContainerCube.gif");
            this.imageList1.Images.SetKeyName(7, "FileNode.gif");
            this.imageList1.Images.SetKeyName(8, "FileContainer.png");
            this.imageList1.Images.SetKeyName(9, "fileShortcut.png");
            this.imageList1.Images.SetKeyName(10, "shortcut.gif");
            this.imageList1.Images.SetKeyName(11, "docShortcut.gif");
            this.imageList1.Images.SetKeyName(12, "shortcut.gif");
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdShowFN,
            this.cmdShowOpenFiles,
            this.cmdHideXRef,
            this.cmdReset,
            this.cmdJumpPersonal,
            this.cmdJumpShortcuts,
            this.cmdJumpOffice,
            this.cmdJump});
            this.uiCommandManager1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("3e0900ac-76c7-4ded-b0fd-62f70cf317ca");
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
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdShowFN2,
            this.Separator3,
            this.cmdShowOpenFiles2,
            this.Separator4,
            this.cmdHideXRef2,
            this.Separator1,
            this.cmdJump1,
            this.Separator2,
            this.cmdReset1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.Name = "uiCommandBar1";
            // 
            // cmdShowFN2
            // 
            resources.ApplyResources(this.cmdShowFN2, "cmdShowFN2");
            this.cmdShowFN2.Name = "cmdShowFN2";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdShowOpenFiles2
            // 
            resources.ApplyResources(this.cmdShowOpenFiles2, "cmdShowOpenFiles2");
            this.cmdShowOpenFiles2.Name = "cmdShowOpenFiles2";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdHideXRef2
            // 
            resources.ApplyResources(this.cmdHideXRef2, "cmdHideXRef2");
            this.cmdHideXRef2.Name = "cmdHideXRef2";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdJump1
            // 
            this.cmdJump1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdJump1, "cmdJump1");
            this.cmdJump1.Name = "cmdJump1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdReset1
            // 
            resources.ApplyResources(this.cmdReset1, "cmdReset1");
            this.cmdReset1.Name = "cmdReset1";
            // 
            // cmdShowFN
            // 
            this.cmdShowFN.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdShowFN.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdShowFN, "cmdShowFN");
            this.cmdShowFN.Name = "cmdShowFN";
            // 
            // cmdShowOpenFiles
            // 
            this.cmdShowOpenFiles.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdShowOpenFiles.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdShowOpenFiles.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdShowOpenFiles, "cmdShowOpenFiles");
            this.cmdShowOpenFiles.Name = "cmdShowOpenFiles";
            // 
            // cmdHideXRef
            // 
            this.cmdHideXRef.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdHideXRef.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdHideXRef, "cmdHideXRef");
            this.cmdHideXRef.Name = "cmdHideXRef";
            // 
            // cmdReset
            // 
            this.cmdReset.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdReset, "cmdReset");
            this.cmdReset.Name = "cmdReset";
            // 
            // cmdJumpPersonal
            // 
            this.cmdJumpPersonal.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdJumpPersonal, "cmdJumpPersonal");
            this.cmdJumpPersonal.Name = "cmdJumpPersonal";
            // 
            // cmdJumpShortcuts
            // 
            this.cmdJumpShortcuts.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdJumpShortcuts, "cmdJumpShortcuts");
            this.cmdJumpShortcuts.Name = "cmdJumpShortcuts";
            // 
            // cmdJumpOffice
            // 
            this.cmdJumpOffice.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdJumpOffice, "cmdJumpOffice");
            this.cmdJumpOffice.Name = "cmdJumpOffice";
            // 
            // cmdJump
            // 
            this.cmdJump.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdJumpPersonal1,
            this.cmdJumpShortcuts1,
            this.cmdJumpOffice1});
            resources.ApplyResources(this.cmdJump, "cmdJump");
            this.cmdJump.Name = "cmdJump";
            // 
            // cmdJumpPersonal1
            // 
            resources.ApplyResources(this.cmdJumpPersonal1, "cmdJumpPersonal1");
            this.cmdJumpPersonal1.Name = "cmdJumpPersonal1";
            // 
            // cmdJumpShortcuts1
            // 
            resources.ApplyResources(this.cmdJumpShortcuts1, "cmdJumpShortcuts1");
            this.cmdJumpShortcuts1.Name = "cmdJumpShortcuts1";
            // 
            // cmdJumpOffice1
            // 
            resources.ApplyResources(this.cmdJumpOffice1, "cmdJumpOffice1");
            this.cmdJumpOffice1.Name = "cmdJumpOffice1";
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
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // pnlTopContainer
            // 
            resources.ApplyResources(this.pnlTopContainer, "pnlTopContainer");
            this.pnlTopContainer.Name = "pnlTopContainer";
            // 
            // pnlTop
            // 
            this.pnlTop.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // tvFiles
            // 
            this.tvFiles.AllowDrop = true;
            resources.ApplyResources(this.tvFiles, "tvFiles");
            this.tvFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvFiles.HideSelection = false;
            this.tvFiles.ItemHeight = 19;
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.ShowNodeToolTips = true;
            // 
            // ucFileContextMenu1
            // 
            resources.ApplyResources(this.ucFileContextMenu1, "ucFileContextMenu1");
            this.ucFileContextMenu1.Name = "ucFileContextMenu1";
            this.ucFileContextMenu1.UsedInTreeView = true;
            this.ucFileContextMenu1.ContextMenuClicked += new LawMate.ContextEventHandler(this.ucFileContextMenu1_ContextMenuClicked);
            // 
            // ucBrowse
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tvFiles);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.ucFileContextMenu1);
            this.Controls.Add(this.BottomRebar1);
            resources.ApplyResources(this, "$this");
            this.Name = "ucBrowse";
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJump1;
        private Janus.Windows.UI.CommandBars.UICommand cmdReset1;
        private Janus.Windows.UI.CommandBars.UICommand cmdShowFN;
        private Janus.Windows.UI.CommandBars.UICommand cmdShowOpenFiles;
        private Janus.Windows.UI.CommandBars.UICommand cmdHideXRef;
        private Janus.Windows.UI.CommandBars.UICommand cmdReset;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpPersonal;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpShortcuts;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpOffice;
        private Janus.Windows.UI.CommandBars.UICommand cmdJump;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpPersonal1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpShortcuts1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpOffice1;
        private System.Windows.Forms.TreeView tvFiles;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private ucFileContextMenu ucFileContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdShowFN2;
        private Janus.Windows.UI.CommandBars.UICommand cmdShowOpenFiles2;
        private Janus.Windows.UI.CommandBars.UICommand cmdHideXRef2;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
    }
}
