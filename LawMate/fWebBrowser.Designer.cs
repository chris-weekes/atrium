 namespace LawMate
{
    partial class fWebBrowser
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
                DocumentCompleted = null;
                ucWB1.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fWebBrowser));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAddress = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAddressContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAddress = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlWebBrowser = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlWebBrowserContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucWB1 = new LawMate.UserControls.ucWB();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdBack1 = new Janus.Windows.UI.CommandBars.UICommand("cmdBack");
            this.cmdForward1 = new Janus.Windows.UI.CommandBars.UICommand("cmdForward");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdRefresh1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDismiss1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDismiss");
            this.cmdBack = new Janus.Windows.UI.CommandBars.UICommand("cmdBack");
            this.cmdForward = new Janus.Windows.UI.CommandBars.UICommand("cmdForward");
            this.cmdRefresh = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.cmdDismiss = new Janus.Windows.UI.CommandBars.UICommand("cmdDismiss");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAddress)).BeginInit();
            this.pnlAddress.SuspendLayout();
            this.pnlAddressContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWebBrowser)).BeginInit();
            this.pnlWebBrowser.SuspendLayout();
            this.pnlWebBrowserContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
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
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.uiPanelManager1.DefaultPanelSettings.MinimumSize = ((System.Drawing.Size)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.MinimumSize")));
            this.uiPanelManager1.SplitterSize = 2;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAddress.Id = new System.Guid("c43a02ab-442e-4165-a83e-720d8be4378a");
            this.uiPanelManager1.Panels.Add(this.pnlAddress);
            this.pnlWebBrowser.Id = new System.Guid("283bb0a9-a6a1-4dba-9008-845d72891c71");
            this.uiPanelManager1.Panels.Add(this.pnlWebBrowser);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c43a02ab-442e-4165-a83e-720d8be4378a"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(829, 26), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("283bb0a9-a6a1-4dba-9008-845d72891c71"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(829, 336), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c43a02ab-442e-4165-a83e-720d8be4378a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("283bb0a9-a6a1-4dba-9008-845d72891c71"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAddress
            // 
            this.pnlAddress.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlAddress.InnerContainer = this.pnlAddressContainer;
            resources.ApplyResources(this.pnlAddress, "pnlAddress");
            this.pnlAddress.Name = "pnlAddress";
            this.helpProvider1.SetShowHelp(this.pnlAddress, ((bool)(resources.GetObject("pnlAddress.ShowHelp"))));
            // 
            // pnlAddressContainer
            // 
            this.pnlAddressContainer.Controls.Add(this.label1);
            this.pnlAddressContainer.Controls.Add(this.tbAddress);
            resources.ApplyResources(this.pnlAddressContainer, "pnlAddressContainer");
            this.pnlAddressContainer.Name = "pnlAddressContainer";
            this.helpProvider1.SetShowHelp(this.pnlAddressContainer, ((bool)(resources.GetObject("pnlAddressContainer.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // tbAddress
            // 
            resources.ApplyResources(this.tbAddress, "tbAddress");
            this.tbAddress.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.tbAddress.ButtonFont = new System.Drawing.Font("Tahoma", 7.25F);
            this.tbAddress.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.tbAddress.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbAddress, ((bool)(resources.GetObject("tbAddress.ShowHelp"))));
            this.tbAddress.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // pnlWebBrowser
            // 
            this.pnlWebBrowser.InnerContainer = this.pnlWebBrowserContainer;
            resources.ApplyResources(this.pnlWebBrowser, "pnlWebBrowser");
            this.pnlWebBrowser.Name = "pnlWebBrowser";
            this.helpProvider1.SetShowHelp(this.pnlWebBrowser, ((bool)(resources.GetObject("pnlWebBrowser.ShowHelp"))));
            // 
            // pnlWebBrowserContainer
            // 
            this.pnlWebBrowserContainer.Controls.Add(this.ucWB1);
            this.pnlWebBrowserContainer.Controls.Add(this.uiStatusBar1);
            resources.ApplyResources(this.pnlWebBrowserContainer, "pnlWebBrowserContainer");
            this.pnlWebBrowserContainer.Name = "pnlWebBrowserContainer";
            this.helpProvider1.SetShowHelp(this.pnlWebBrowserContainer, ((bool)(resources.GetObject("pnlWebBrowserContainer.ShowHelp"))));
            // 
            // ucWB1
            // 
            this.ucWB1.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.ucWB1, "ucWB1");
            this.ucWB1.Name = "ucWB1";
            this.helpProvider1.SetShowHelp(this.ucWB1, ((bool)(resources.GetObject("ucWB1.ShowHelp"))));
            this.ucWB1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.ucWB1.DocumentCompleted += new LawMate.UserControls.WebBrowserDocumentCompletedEventHandler(this.ucWB1_DocumentCompleted);
            this.ucWB1.StatusTextChanged += new LawMate.UserControls.WebBrowserStatusTextChangedEventHandler(this.ucWB1_StatusTextChanged);
            this.ucWB1.ProgressChanged += new LawMate.UserControls.WebBrowserProgressChangedEventHandler(this.ucWB1_ProgressChanged);
            // 
            // uiStatusBar1
            // 
            resources.ApplyResources(this.uiStatusBar1, "uiStatusBar1");
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            resources.ApplyResources(uiStatusBarPanel1, "uiStatusBarPanel1");
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            resources.ApplyResources(uiStatusBarPanel2, "uiStatusBarPanel2");
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.PanelType = Janus.Windows.UI.StatusBar.StatusBarPanelType.ProgressBar;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2});
            this.helpProvider1.SetShowHelp(this.uiStatusBar1, ((bool)(resources.GetObject("uiStatusBar1.ShowHelp"))));
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiCommandManager1
            // 
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdBack,
            this.cmdForward,
            this.cmdRefresh,
            this.cmdDismiss});
            this.uiCommandManager1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("95958436-85b2-43f1-9375-665ac61c3dfd");
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
            this.uiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdBack1,
            this.cmdForward1,
            this.Separator1,
            this.cmdRefresh1,
            this.Separator2,
            this.cmdDismiss1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // cmdBack1
            // 
            resources.ApplyResources(this.cmdBack1, "cmdBack1");
            this.cmdBack1.Name = "cmdBack1";
            // 
            // cmdForward1
            // 
            resources.ApplyResources(this.cmdForward1, "cmdForward1");
            this.cmdForward1.Name = "cmdForward1";
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
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdDismiss1
            // 
            resources.ApplyResources(this.cmdDismiss1, "cmdDismiss1");
            this.cmdDismiss1.Name = "cmdDismiss1";
            // 
            // cmdBack
            // 
            this.cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.cmdBack, "cmdBack");
            this.cmdBack.Name = "cmdBack";
            // 
            // cmdForward
            // 
            this.cmdForward.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.cmdForward, "cmdForward");
            this.cmdForward.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdForward.Name = "cmdForward";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdRefresh, "cmdRefresh");
            this.cmdRefresh.Name = "cmdRefresh";
            // 
            // cmdDismiss
            // 
            resources.ApplyResources(this.cmdDismiss, "cmdDismiss");
            this.cmdDismiss.Name = "cmdDismiss";
            this.cmdDismiss.Visible = Janus.Windows.UI.InheritableBoolean.False;
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
            // fWebBrowser
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlWebBrowser);
            this.Controls.Add(this.pnlAddress);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fWebBrowser";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAddress)).EndInit();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddressContainer.ResumeLayout(false);
            this.pnlAddressContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWebBrowser)).EndInit();
            this.pnlWebBrowser.ResumeLayout(false);
            this.pnlWebBrowserContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlWebBrowser;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlWebBrowserContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlAddress;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAddressContainer;
        private Janus.Windows.GridEX.EditControls.EditBox tbAddress;
        private UserControls.ucWB ucWB1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdBack;
        private Janus.Windows.UI.CommandBars.UICommand cmdForward;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh;
        private Janus.Windows.UI.CommandBars.UICommand cmdBack1;
        private Janus.Windows.UI.CommandBars.UICommand cmdForward1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh1;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDismiss;
        private Janus.Windows.UI.CommandBars.UICommand cmdDismiss1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
    }
}
