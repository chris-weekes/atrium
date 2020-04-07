 namespace LawMate
{
    partial class fBrowseOffices
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
            Janus.Windows.GridEX.GridEXLayout officeGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBrowseOffices));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlSearch = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlSearchOffice = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSearchOfficeContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBrowseOffices = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBrowseOfficesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBottom = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBottomContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.buttonCancel = new Janus.Windows.EditControls.UIButton();
            this.buttonOK = new Janus.Windows.EditControls.UIButton();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.pnlOffices = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlOfficesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.officeGridEX = new Janus.Windows.GridEX.GridEX();
            this.officeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDB = new lmDatasets.officeDB();
            this.pnlSearchOffices = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSearchOfficesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBrowseOffice = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBrowseOfficeContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffice)).BeginInit();
            this.pnlSearchOffice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffices)).BeginInit();
            this.pnlBrowseOffices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOffices)).BeginInit();
            this.pnlOffices.SuspendLayout();
            this.pnlOfficesContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffices)).BeginInit();
            this.pnlSearchOffices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffice)).BeginInit();
            this.pnlBrowseOffice.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.AutoHideTabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.ImageAndText;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.uiPanelManager1, "uiPanelManager1");
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.TabbedMdiSettings.AllowDrag = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.AllowDrag")));
            this.uiPanelManager1.TabbedMdiSettings.MaxTabSize = ((int)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.MaxTabSize")));
            this.uiPanelManager1.TabbedMdiSettings.ShowCloseButton = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.ShowCloseButton")));
            this.uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming = ((System.Drawing.StringTrimming)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.TabCaptionTrimming")));
            this.uiPanelManager1.TabbedMdiSettings.UseFormIcons = ((bool)(resources.GetObject("uiPanelManager1.TabbedMdiSettings.UseFormIcons")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlSearch.Id = new System.Guid("796def90-bc87-426f-81be-e8dd984b9ef8");
            this.pnlSearch.StaticGroup = true;
            this.pnlSearchOffice.Id = new System.Guid("4012f743-895c-4149-9014-d9e9543ce497");
            this.pnlSearch.Panels.Add(this.pnlSearchOffice);
            this.pnlBrowseOffices.Id = new System.Guid("a0dfa5af-6a9f-4d9a-9de5-eabe562f064e");
            this.pnlSearch.Panels.Add(this.pnlBrowseOffices);
            this.uiPanelManager1.Panels.Add(this.pnlSearch);
            this.pnlBottom.Id = new System.Guid("11648e07-ccf1-4503-af53-add03c429133");
            this.uiPanelManager1.Panels.Add(this.pnlBottom);
            this.pnlOffices.Id = new System.Guid("fb72ec5a-1c09-4241-a98c-14ae87dc3242");
            this.uiPanelManager1.Panels.Add(this.pnlOffices);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("796def90-bc87-426f-81be-e8dd984b9ef8"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(200, 200), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("4012f743-895c-4149-9014-d9e9543ce497"), new System.Guid("796def90-bc87-426f-81be-e8dd984b9ef8"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a0dfa5af-6a9f-4d9a-9de5-eabe562f064e"), new System.Guid("796def90-bc87-426f-81be-e8dd984b9ef8"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("fb72ec5a-1c09-4241-a98c-14ae87dc3242"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(907, 302), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("11648e07-ccf1-4503-af53-add03c429133"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(907, 44), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("796def90-bc87-426f-81be-e8dd984b9ef8"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("4012f743-895c-4149-9014-d9e9543ce497"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a0dfa5af-6a9f-4d9a-9de5-eabe562f064e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("11648e07-ccf1-4503-af53-add03c429133"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("fb72ec5a-1c09-4241-a98c-14ae87dc3242"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlSearch
            // 
            resources.ApplyResources(this.pnlSearch, "pnlSearch");
            this.pnlSearch.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator;
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.SelectedPanel = this.pnlBrowseOffices;
            // 
            // pnlSearchOffice
            // 
            resources.ApplyResources(this.pnlSearchOffice, "pnlSearchOffice");
            this.pnlSearchOffice.InnerContainer = this.pnlSearchOfficeContainer;
            this.pnlSearchOffice.Name = "pnlSearchOffice";
            // 
            // pnlSearchOfficeContainer
            // 
            resources.ApplyResources(this.pnlSearchOfficeContainer, "pnlSearchOfficeContainer");
            this.pnlSearchOfficeContainer.Name = "pnlSearchOfficeContainer";
            // 
            // pnlBrowseOffices
            // 
            resources.ApplyResources(this.pnlBrowseOffices, "pnlBrowseOffices");
            this.pnlBrowseOffices.InnerContainer = this.pnlBrowseOfficesContainer;
            this.pnlBrowseOffices.Name = "pnlBrowseOffices";
            // 
            // pnlBrowseOfficesContainer
            // 
            resources.ApplyResources(this.pnlBrowseOfficesContainer, "pnlBrowseOfficesContainer");
            this.pnlBrowseOfficesContainer.Name = "pnlBrowseOfficesContainer";
            // 
            // pnlBottom
            // 
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlBottom.InnerContainer = this.pnlBottomContainer;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // pnlBottomContainer
            // 
            resources.ApplyResources(this.pnlBottomContainer, "pnlBottomContainer");
            this.pnlBottomContainer.Controls.Add(this.buttonCancel);
            this.pnlBottomContainer.Controls.Add(this.buttonOK);
            this.pnlBottomContainer.Controls.Add(this.lblCurrentFile);
            this.pnlBottomContainer.Controls.Add(this.lblSelectedFile);
            this.pnlBottomContainer.Name = "pnlBottomContainer";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCurrentFile
            // 
            resources.ApplyResources(this.lblCurrentFile, "lblCurrentFile");
            this.lblCurrentFile.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentFile.Name = "lblCurrentFile";
            // 
            // lblSelectedFile
            // 
            resources.ApplyResources(this.lblSelectedFile, "lblSelectedFile");
            this.lblSelectedFile.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedFile.Name = "lblSelectedFile";
            // 
            // pnlOffices
            // 
            resources.ApplyResources(this.pnlOffices, "pnlOffices");
            this.pnlOffices.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlOffices.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlOffices.InnerContainer = this.pnlOfficesContainer;
            this.pnlOffices.Name = "pnlOffices";
            // 
            // pnlOfficesContainer
            // 
            resources.ApplyResources(this.pnlOfficesContainer, "pnlOfficesContainer");
            this.pnlOfficesContainer.Controls.Add(this.officeGridEX);
            this.pnlOfficesContainer.Name = "pnlOfficesContainer";
            // 
            // officeGridEX
            // 
            resources.ApplyResources(this.officeGridEX, "officeGridEX");
            this.officeGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.officeGridEX.AlternatingColors = true;
            this.officeGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.officeGridEX.DataSource = this.officeBindingSource;
            resources.ApplyResources(officeGridEX_DesignTimeLayout, "officeGridEX_DesignTimeLayout");
            this.officeGridEX.DesignTimeLayout = officeGridEX_DesignTimeLayout;
            this.officeGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.officeGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.officeGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.officeGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.officeGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.officeGridEX.Name = "officeGridEX";
            this.officeGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.officeGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.officeGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.officeGridEX.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.officeGridEX_LinkClicked);
            // 
            // officeBindingSource
            // 
            this.officeBindingSource.DataMember = "Office";
            this.officeBindingSource.DataSource = this.officeDB;
            this.officeBindingSource.CurrentChanged += new System.EventHandler(this.officeBindingSource_CurrentChanged);
            // 
            // officeDB
            // 
            this.officeDB.DataSetName = "officeDB";
            this.officeDB.EnforceConstraints = false;
            this.officeDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlSearchOffices
            // 
            resources.ApplyResources(this.pnlSearchOffices, "pnlSearchOffices");
            this.pnlSearchOffices.InnerContainer = this.pnlSearchOfficesContainer;
            this.pnlSearchOffices.Name = "pnlSearchOffices";
            // 
            // pnlSearchOfficesContainer
            // 
            resources.ApplyResources(this.pnlSearchOfficesContainer, "pnlSearchOfficesContainer");
            this.pnlSearchOfficesContainer.Name = "pnlSearchOfficesContainer";
            // 
            // pnlBrowseOffice
            // 
            resources.ApplyResources(this.pnlBrowseOffice, "pnlBrowseOffice");
            this.pnlBrowseOffice.InnerContainer = this.pnlBrowseOfficeContainer;
            this.pnlBrowseOffice.Name = "pnlBrowseOffice";
            // 
            // pnlBrowseOfficeContainer
            // 
            resources.ApplyResources(this.pnlBrowseOfficeContainer, "pnlBrowseOfficeContainer");
            this.pnlBrowseOfficeContainer.Name = "pnlBrowseOfficeContainer";
            // 
            // fBrowseOffices
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlOffices);
            this.Controls.Add(this.pnlBottom);
            this.Name = "fBrowseOffices";
            this.Load += new System.EventHandler(this.fBrowseOffices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffice)).EndInit();
            this.pnlSearchOffice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffices)).EndInit();
            this.pnlBrowseOffices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomContainer.ResumeLayout(false);
            this.pnlBottomContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOffices)).EndInit();
            this.pnlOffices.ResumeLayout(false);
            this.pnlOfficesContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffices)).EndInit();
            this.pnlSearchOffices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffice)).EndInit();
            this.pnlBrowseOffice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlOffices;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlOfficesContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlSearch;
        private Janus.Windows.UI.Dock.UIPanel pnlSearchOffice;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSearchOfficeContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSearchOffices;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSearchOfficesContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBrowseOffice;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBrowseOfficeContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBrowseOffices;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBrowseOfficesContainer;
        private Janus.Windows.GridEX.GridEX officeGridEX;
        private System.Windows.Forms.BindingSource officeBindingSource;
        private lmDatasets.officeDB officeDB;
        private Janus.Windows.UI.Dock.UIPanel pnlBottom;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBottomContainer;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Label lblSelectedFile;
        private Janus.Windows.EditControls.UIButton buttonCancel;
        private Janus.Windows.EditControls.UIButton buttonOK;
    }
}