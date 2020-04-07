 namespace LawMate.Admin
{
    partial class fGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGroups));
            Janus.Windows.GridEX.GridEXLayout secGroupGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference secGroupGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference secGroupGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.ChildTables.Table0.Columns.Column0.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference secGroupGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.ChildTables.Table0.Columns.Column1.HeaderImage");
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdNewMember1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewMember");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdNewMember = new Janus.Windows.UI.CommandBars.UICommand("cmdNewMember");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.securityDB = new lmDatasets.SecurityDB();
            this.secGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.secGroupGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlGroupsMembers = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlNoBFsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlEditableFields = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlEditableFieldsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlPreviewedDoc = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlPreviewedDocContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secGroupGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGroupsMembers)).BeginInit();
            this.pnlGroupsMembers.SuspendLayout();
            this.pnlNoBFsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditableFields)).BeginInit();
            this.pnlEditableFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreviewedDoc)).BeginInit();
            this.pnlPreviewedDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.secGroupBindingSource;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowMerge = false;
            this.uiCommandManager1.AlwaysShowFullMenus = true;
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave,
            this.cmdCancel,
            this.cmdNew,
            this.cmdNewMember});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("495f1621-d4fa-4262-96fc-7722714756b0");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.LockCommandBars = true;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowQuickCustomizeMenu = false;
            this.uiCommandManager1.ShowShortcutInToolTips = true;
            this.uiCommandManager1.ShowToolTipOnMenus = true;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 394);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(770, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNew1,
            this.cmdNewMember1,
            this.Separator1,
            this.cmdSave1,
            this.Separator2,
            this.cmdCancel1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.Size = new System.Drawing.Size(770, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdSave1
            // 
            this.cmdSave1.Key = "cmdSave";
            this.cmdSave1.Name = "cmdSave1";
            // 
            // cmdCancel1
            // 
            this.cmdCancel1.Key = "cmdCancel";
            this.cmdCancel1.Name = "cmdCancel1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdNew1
            // 
            this.cmdNew1.Key = "cmdNew";
            this.cmdNew1.Name = "cmdNew1";
            // 
            // cmdNewMember1
            // 
            this.cmdNewMember1.Key = "cmdNewMember";
            this.cmdNewMember1.Name = "cmdNewMember1";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Key = "cmdSave";
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Text = "Save";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Key = "cmdCancel";
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Text = "Cancel";
            // 
            // cmdNew
            // 
            this.cmdNew.Image = ((System.Drawing.Image)(resources.GetObject("cmdNew.Image")));
            this.cmdNew.Key = "cmdNew";
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Text = "New Group";
            // 
            // cmdNewMember
            // 
            this.cmdNewMember.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewMember.Image")));
            this.cmdNewMember.Key = "cmdNewMember";
            this.cmdNewMember.Name = "cmdNewMember";
            this.cmdNewMember.Text = "New Member";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 28);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 366);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(770, 28);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 366);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(770, 28);
            // 
            // securityDB
            // 
            this.securityDB.DataSetName = "SecurityDB";
            this.securityDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // secGroupBindingSource
            // 
            this.secGroupBindingSource.DataMember = "secGroup";
            this.secGroupBindingSource.DataSource = this.securityDB;
            // 
            // secGroupGridEX
            // 
            this.secGroupGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.secGroupGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.secGroupGridEX.DataSource = this.secGroupBindingSource;
            secGroupGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("secGroupGridEX_DesignTimeLayout_Reference_0.Instance")));
            secGroupGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("secGroupGridEX_DesignTimeLayout_Reference_1.Instance")));
            secGroupGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("secGroupGridEX_DesignTimeLayout_Reference_2.Instance")));
            secGroupGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            secGroupGridEX_DesignTimeLayout_Reference_0,
            secGroupGridEX_DesignTimeLayout_Reference_1,
            secGroupGridEX_DesignTimeLayout_Reference_2});
            secGroupGridEX_DesignTimeLayout.LayoutString = resources.GetString("secGroupGridEX_DesignTimeLayout.LayoutString");
            this.secGroupGridEX.DesignTimeLayout = secGroupGridEX_DesignTimeLayout;
            this.secGroupGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secGroupGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.secGroupGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.secGroupGridEX.GroupByBoxVisible = false;
            this.secGroupGridEX.Hierarchical = true;
            this.secGroupGridEX.Indent = 24;
            this.secGroupGridEX.Location = new System.Drawing.Point(0, 0);
            this.secGroupGridEX.Name = "secGroupGridEX";
            this.secGroupGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.secGroupGridEX.Size = new System.Drawing.Size(770, 366);
            this.secGroupGridEX.TabIndex = 5;
            this.secGroupGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.secGroupGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.PanelPadding.Bottom = 0;
            this.uiPanelManager1.PanelPadding.Left = 0;
            this.uiPanelManager1.PanelPadding.Right = 0;
            this.uiPanelManager1.PanelPadding.Top = 0;
            this.uiPanelManager1.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlGroupsMembers.Id = new System.Guid("2e5c5085-0a2c-4ae4-93d3-5059f68d177e");
            this.uiPanelManager1.Panels.Add(this.pnlGroupsMembers);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("2e5c5085-0a2c-4ae4-93d3-5059f68d177e"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(770, 366), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("daf4ae32-bda1-43f1-8de6-b63925cbf060"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3a7823f1-c47a-42fc-96e4-0e24f5cb769e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a1e011ac-58ea-41b0-9192-a51f3260fc8f"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("2e5c5085-0a2c-4ae4-93d3-5059f68d177e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7625b732-7897-4aa1-8676-22627084a9ea"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0df758ed-6c58-4456-a8f2-5702adcea8ef"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("95bb2d8e-6024-4c5d-b182-a1f34ac3fde7"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d0f6248a-fd3e-43ea-bbac-66577d90add3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlGroupsMembers
            // 
            this.pnlGroupsMembers.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGroupsMembers.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Standard;
            this.pnlGroupsMembers.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGroupsMembers.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlGroupsMembers.InnerContainer = this.pnlNoBFsContainer;
            this.pnlGroupsMembers.Location = new System.Drawing.Point(0, 28);
            this.pnlGroupsMembers.Name = "pnlGroupsMembers";
            this.pnlGroupsMembers.Size = new System.Drawing.Size(770, 366);
            this.pnlGroupsMembers.TabIndex = 13;
            this.pnlGroupsMembers.Text = "Groups/Group Members";
            // 
            // pnlNoBFsContainer
            // 
            this.pnlNoBFsContainer.Controls.Add(this.secGroupGridEX);
            this.pnlNoBFsContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlNoBFsContainer.Name = "pnlNoBFsContainer";
            this.pnlNoBFsContainer.Size = new System.Drawing.Size(770, 366);
            this.pnlNoBFsContainer.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(830, 159);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Size = new System.Drawing.Size(830, 159);
            this.pnlTopContainer.TabIndex = 0;
            // 
            // pnlEditableFields
            // 
            this.pnlEditableFields.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlEditableFields.Closed = true;
            this.pnlEditableFields.InnerContainer = this.pnlEditableFieldsContainer;
            this.pnlEditableFields.Location = new System.Drawing.Point(0, 0);
            this.pnlEditableFields.MaximumSize = new System.Drawing.Size(-1, 78);
            this.pnlEditableFields.MinimumSize = new System.Drawing.Size(-1, 78);
            this.pnlEditableFields.Name = "pnlEditableFields";
            this.pnlEditableFields.Size = new System.Drawing.Size(200, 200);
            this.pnlEditableFields.TabIndex = 1;
            this.pnlEditableFields.Visible = false;
            // 
            // pnlEditableFieldsContainer
            // 
            this.pnlEditableFieldsContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlEditableFieldsContainer.Name = "pnlEditableFieldsContainer";
            this.pnlEditableFieldsContainer.Size = new System.Drawing.Size(200, 200);
            this.pnlEditableFieldsContainer.TabIndex = 0;
            // 
            // pnlPreviewedDoc
            // 
            this.pnlPreviewedDoc.InnerContainer = this.pnlPreviewedDocContainer;
            this.pnlPreviewedDoc.Location = new System.Drawing.Point(0, 163);
            this.pnlPreviewedDoc.Name = "pnlPreviewedDoc";
            this.pnlPreviewedDoc.Size = new System.Drawing.Size(830, 318);
            this.pnlPreviewedDoc.TabIndex = 2;
            this.pnlPreviewedDoc.Text = "Panel 0";
            // 
            // pnlPreviewedDocContainer
            // 
            this.pnlPreviewedDocContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlPreviewedDocContainer.Name = "pnlPreviewedDocContainer";
            this.pnlPreviewedDocContainer.Size = new System.Drawing.Size(830, 318);
            this.pnlPreviewedDocContainer.TabIndex = 0;
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.Name = "Separator2";
            // 
            // fGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(770, 394);
            this.Controls.Add(this.pnlGroupsMembers);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.BottomRebar1);
            this.Name = "fGroups";
            this.Text = "Security Groups";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secGroupGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGroupsMembers)).EndInit();
            this.pnlGroupsMembers.ResumeLayout(false);
            this.pnlNoBFsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditableFields)).EndInit();
            this.pnlEditableFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreviewedDoc)).EndInit();
            this.pnlPreviewedDoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.GridEX.GridEX secGroupGridEX;
        private System.Windows.Forms.BindingSource secGroupBindingSource;
        private lmDatasets.SecurityDB securityDB;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewMember1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewMember;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlGroupsMembers;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlNoBFsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlEditableFields;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlEditableFieldsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlPreviewedDoc;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlPreviewedDocContainer;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
    }
}
