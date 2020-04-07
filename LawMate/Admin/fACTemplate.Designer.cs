 namespace LawMate.Admin
{
    partial class fACTemplate
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
            Janus.Windows.GridEX.GridEXLayout activityCodeGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fACTemplate));
            this.activityCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activityCodeGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.Save1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.Save2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlRecordDetails = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlRecordDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucActivityCode1 = new LawMate.Admin.ucActivityCode();
            this.pnlTopGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlActivitiesList = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivitiesListContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlActivityCodeDetails = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityCodeDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlActivity = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityCodeGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRecordDetails)).BeginInit();
            this.pnlRecordDetails.SuspendLayout();
            this.pnlRecordDetailsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopGrid)).BeginInit();
            this.pnlTopGrid.SuspendLayout();
            this.pnlTopGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivitiesList)).BeginInit();
            this.pnlActivitiesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetails)).BeginInit();
            this.pnlActivityCodeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivity)).BeginInit();
            this.pnlActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // activityCodeBindingSource
            // 
            this.activityCodeBindingSource.Filter = "";
            this.activityCodeBindingSource.CurrentChanged += new System.EventHandler(this.activityCodeBindingSource_PositionChanged);
            // 
            // activityCodeGridEX
            // 
            this.activityCodeGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityCodeGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.activityCodeGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.activityCodeGridEX.DataSource = this.activityCodeBindingSource;
            activityCodeGridEX_DesignTimeLayout.LayoutString = resources.GetString("activityCodeGridEX_DesignTimeLayout.LayoutString");
            this.activityCodeGridEX.DesignTimeLayout = activityCodeGridEX_DesignTimeLayout;
            this.activityCodeGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activityCodeGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.activityCodeGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.activityCodeGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.activityCodeGridEX.GridLineColor = System.Drawing.SystemColors.ControlLight;
            this.activityCodeGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityCodeGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.activityCodeGridEX.GroupRowFormatStyle.FontSize = 7F;
            this.activityCodeGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.activityCodeGridEX.Location = new System.Drawing.Point(0, 0);
            this.activityCodeGridEX.Name = "activityCodeGridEX";
            this.activityCodeGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.activityCodeGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.activityCodeGridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.activityCodeGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityCodeGridEX.Size = new System.Drawing.Size(1215, 197);
            this.activityCodeGridEX.TabIndex = 1;
            this.activityCodeGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.activityCodeGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityCodeGridEX.SelectionChanged += new System.EventHandler(this.activityCodeGridEX_SelectionChanged);
            this.activityCodeGridEX.FilterApplied += new System.EventHandler(this.activityCodeGridEX_FilterApplied);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.Save2,
            this.cmdCancel,
            this.cmdNew,
            this.cmdDelete});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("4012ede4-f69b-4975-bf43-44777fb83252");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 0);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNew1,
            this.Separator2,
            this.Save1,
            this.Separator1,
            this.cmdCancel1,
            this.Separator3,
            this.cmdDelete1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowToolTips = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Size = new System.Drawing.Size(1223, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdNew1
            // 
            this.cmdNew1.Key = "cmdNew";
            this.cmdNew1.Name = "cmdNew1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.Name = "Separator2";
            // 
            // Save1
            // 
            this.Save1.Key = "cmdSave";
            this.Save1.Name = "Save1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdCancel1
            // 
            this.cmdCancel1.Key = "cmdCancel";
            this.cmdCancel1.Name = "cmdCancel1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator3.Key = "Separator";
            this.Separator3.Name = "Separator3";
            // 
            // cmdDelete1
            // 
            this.cmdDelete1.Key = "cmdDelete";
            this.cmdDelete1.Name = "cmdDelete1";
            // 
            // Save2
            // 
            this.Save2.Image = ((System.Drawing.Image)(resources.GetObject("Save2.Image")));
            this.Save2.Key = "cmdSave";
            this.Save2.Name = "Save2";
            this.Save2.Text = "Save";
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
            this.cmdNew.Text = "New";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.Key = "cmdDelete";
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "Delete";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(0, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 0);
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
            this.TopRebar1.Size = new System.Drawing.Size(1223, 28);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlRecordDetails.Id = new System.Guid("01b5ac83-627d-48cc-a555-4d9b296ff751");
            this.uiPanelManager1.Panels.Add(this.pnlRecordDetails);
            this.pnlTopGrid.Id = new System.Guid("c8bebc15-f5f4-478a-8746-a985328f1140");
            this.uiPanelManager1.Panels.Add(this.pnlTopGrid);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c8bebc15-f5f4-478a-8746-a985328f1140"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1217, 199), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("01b5ac83-627d-48cc-a555-4d9b296ff751"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(1217, 308), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("59466cee-7156-4631-87a5-2a22fb966b6c"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e66ca4db-b710-440f-9e78-69a2449a22a1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("781514b0-d837-4426-b179-4cfa8bc6cf2b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b41e9eb9-a043-4d26-8bbe-8b54d893b734"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7dd7c9eb-ceff-439e-88c8-e8a9a19120aa"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e67541b4-db01-4943-a3d2-eca11f81f0d1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("420b2dad-9a8c-4eed-bac3-45d46e44e1cd"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("01b5ac83-627d-48cc-a555-4d9b296ff751"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c8bebc15-f5f4-478a-8746-a985328f1140"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlRecordDetails
            // 
            this.pnlRecordDetails.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlRecordDetails.InnerContainer = this.pnlRecordDetailsContainer;
            this.pnlRecordDetails.Location = new System.Drawing.Point(3, 230);
            this.pnlRecordDetails.Name = "pnlRecordDetails";
            this.pnlRecordDetails.Size = new System.Drawing.Size(1217, 308);
            this.pnlRecordDetails.TabIndex = 4;
            this.pnlRecordDetails.Text = "Panel 0";
            // 
            // pnlRecordDetailsContainer
            // 
            this.pnlRecordDetailsContainer.Controls.Add(this.ucActivityCode1);
            this.pnlRecordDetailsContainer.Location = new System.Drawing.Point(0, 4);
            this.pnlRecordDetailsContainer.Name = "pnlRecordDetailsContainer";
            this.pnlRecordDetailsContainer.Size = new System.Drawing.Size(1217, 304);
            this.pnlRecordDetailsContainer.TabIndex = 0;
            // 
            // ucActivityCode1
            // 
            this.ucActivityCode1.AtMng = null;
            this.ucActivityCode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucActivityCode1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucActivityCode1.Location = new System.Drawing.Point(0, 0);
            this.ucActivityCode1.Name = "ucActivityCode1";
            this.ucActivityCode1.Size = new System.Drawing.Size(1217, 304);
            this.ucActivityCode1.TabIndex = 0;
            // 
            // pnlTopGrid
            // 
            this.pnlTopGrid.InnerContainer = this.pnlTopGridContainer;
            this.pnlTopGrid.Location = new System.Drawing.Point(3, 31);
            this.pnlTopGrid.Name = "pnlTopGrid";
            this.pnlTopGrid.Size = new System.Drawing.Size(1217, 199);
            this.pnlTopGrid.TabIndex = 4;
            this.pnlTopGrid.Text = "Panel 0";
            // 
            // pnlTopGridContainer
            // 
            this.pnlTopGridContainer.Controls.Add(this.activityCodeGridEX);
            this.pnlTopGridContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlTopGridContainer.Name = "pnlTopGridContainer";
            this.pnlTopGridContainer.Size = new System.Drawing.Size(1215, 197);
            this.pnlTopGridContainer.TabIndex = 0;
            // 
            // pnlActivitiesList
            // 
            this.pnlActivitiesList.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivitiesList.InnerContainer = this.pnlActivitiesListContainer;
            this.pnlActivitiesList.Location = new System.Drawing.Point(0, 0);
            this.pnlActivitiesList.Name = "pnlActivitiesList";
            this.pnlActivitiesList.Size = new System.Drawing.Size(785, 283);
            this.pnlActivitiesList.TabIndex = 4;
            this.pnlActivitiesList.Text = "Step Templates";
            // 
            // pnlActivitiesListContainer
            // 
            this.pnlActivitiesListContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivitiesListContainer.Name = "pnlActivitiesListContainer";
            this.pnlActivitiesListContainer.Size = new System.Drawing.Size(785, 283);
            this.pnlActivitiesListContainer.TabIndex = 0;
            // 
            // pnlActivityCodeDetails
            // 
            this.pnlActivityCodeDetails.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivityCodeDetails.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivityCodeDetails.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlActivityCodeDetails.InnerContainer = this.pnlActivityCodeDetailsContainer;
            this.pnlActivityCodeDetails.Location = new System.Drawing.Point(0, 287);
            this.pnlActivityCodeDetails.Name = "pnlActivityCodeDetails";
            this.pnlActivityCodeDetails.Size = new System.Drawing.Size(785, 343);
            this.pnlActivityCodeDetails.TabIndex = 4;
            // 
            // pnlActivityCodeDetailsContainer
            // 
            this.pnlActivityCodeDetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivityCodeDetailsContainer.Name = "pnlActivityCodeDetailsContainer";
            this.pnlActivityCodeDetailsContainer.Size = new System.Drawing.Size(785, 343);
            this.pnlActivityCodeDetailsContainer.TabIndex = 0;
            // 
            // pnlActivity
            // 
            this.pnlActivity.InnerContainer = this.pnlActivityContainer;
            this.pnlActivity.Location = new System.Drawing.Point(0, 0);
            this.pnlActivity.Name = "pnlActivity";
            this.pnlActivity.Size = new System.Drawing.Size(598, 546);
            this.pnlActivity.TabIndex = 4;
            this.pnlActivity.Text = "Activities";
            // 
            // pnlActivityContainer
            // 
            this.pnlActivityContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivityContainer.Name = "pnlActivityContainer";
            this.pnlActivityContainer.Size = new System.Drawing.Size(598, 546);
            this.pnlActivityContainer.TabIndex = 0;
            // 
            // fACTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1223, 541);
            this.Controls.Add(this.pnlTopGrid);
            this.Controls.Add(this.pnlRecordDetails);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fACTemplate";
            this.Text = "Step Templates";
            this.Load += new System.EventHandler(this.fACTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityCodeGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRecordDetails)).EndInit();
            this.pnlRecordDetails.ResumeLayout(false);
            this.pnlRecordDetailsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopGrid)).EndInit();
            this.pnlTopGrid.ResumeLayout(false);
            this.pnlTopGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivitiesList)).EndInit();
            this.pnlActivitiesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetails)).EndInit();
            this.pnlActivityCodeDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivity)).EndInit();
            this.pnlActivity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource activityCodeBindingSource;
        private Janus.Windows.GridEX.GridEX activityCodeGridEX;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand Save1;
        private Janus.Windows.UI.CommandBars.UICommand Save2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlActivity;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlActivitiesList;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivitiesListContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlActivityCodeDetails;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityCodeDetailsContainer;
        private ucActivityCode ucActivityCode1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.Dock.UIPanel pnlTopGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopGridContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlRecordDetails;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlRecordDetailsContainer;

    }
}
