 namespace LawMate.Admin
{
    partial class fDistributionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDistributionList));
            Janus.Windows.GridEX.GridEXLayout listGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout listMemberGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference listMemberGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ButtonImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference listMemberGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ButtonImage");
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdNewList1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewList");
            this.cmdNewMember1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewMember");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdNewList = new Janus.Windows.UI.CommandBars.UICommand("cmdNewList");
            this.cmdNewMember = new Janus.Windows.UI.CommandBars.UICommand("cmdNewMember");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.listGridEX = new Janus.Windows.GridEX.GridEX();
            this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.pnlMember = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlMemberContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.listMemberGridEX = new Janus.Windows.GridEX.GridEX();
            this.listMemberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMember)).BeginInit();
            this.pnlMember.SuspendLayout();
            this.pnlMemberContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listMemberGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listMemberBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave,
            this.cmdCancel,
            this.cmdNew,
            this.cmdDelete,
            this.cmdNewList,
            this.cmdNewMember});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("f76f5b5d-6b14-4aab-8a72-8b6f333b8c0d");
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
            this.BottomRebar1.Location = new System.Drawing.Point(0, 509);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(830, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNew1,
            this.Separator1,
            this.cmdSave1,
            this.Separator2,
            this.cmdCancel1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowToolTips = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Size = new System.Drawing.Size(1200, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdNew1
            // 
            this.cmdNew1.Key = "cmdNew";
            this.cmdNew1.Name = "cmdNew1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
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
            this.cmdNew.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNewList1,
            this.cmdNewMember1});
            this.cmdNew.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            this.cmdNew.Image = ((System.Drawing.Image)(resources.GetObject("cmdNew.Image")));
            this.cmdNew.Key = "cmdNew";
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Text = "New";
            // 
            // cmdNewList1
            // 
            this.cmdNewList1.Key = "cmdNewList";
            this.cmdNewList1.Name = "cmdNewList1";
            // 
            // cmdNewMember1
            // 
            this.cmdNewMember1.Key = "cmdNewMember";
            this.cmdNewMember1.Name = "cmdNewMember1";
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.Key = "cmdDelete";
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "Delete";
            // 
            // cmdNewList
            // 
            this.cmdNewList.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewList.Image")));
            this.cmdNewList.Key = "cmdNewList";
            this.cmdNewList.Name = "cmdNewList";
            this.cmdNewList.Text = "Distribution List";
            // 
            // cmdNewMember
            // 
            this.cmdNewMember.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewMember.Image")));
            this.cmdNewMember.Key = "cmdNewMember";
            this.cmdNewMember.Name = "cmdNewMember";
            this.cmdNewMember.Text = "Member of:";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 28);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 481);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(830, 28);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 481);
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
            this.TopRebar1.Size = new System.Drawing.Size(1200, 28);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.PanelPadding.Bottom = 4;
            this.uiPanelManager1.PanelPadding.Left = 4;
            this.uiPanelManager1.PanelPadding.Right = 4;
            this.uiPanelManager1.PanelPadding.Top = 4;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanel0.Id = new System.Guid("59490d52-db4f-435d-bf01-20909a0ddd47");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            this.pnlMember.Id = new System.Guid("c3758298-9f25-46ec-922d-cc5e6ccc5d21");
            this.uiPanelManager1.Panels.Add(this.pnlMember);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c3758298-9f25-46ec-922d-cc5e6ccc5d21"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(593, 591), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("59490d52-db4f-435d-bf01-20909a0ddd47"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(599, 591), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("87adff2f-7b4a-4f28-b4c8-0f196567e62d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("59490d52-db4f-435d-bf01-20909a0ddd47"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c3758298-9f25-46ec-922d-cc5e6ccc5d21"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel0
            // 
            this.uiPanel0.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(4, 32);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(599, 591);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Distribution Lists";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.listGridEX);
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(593, 567);
            this.uiPanel0Container.TabIndex = 0;
            // 
            // listGridEX
            // 
            this.listGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.listGridEX.AlternatingColors = true;
            this.listGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.listGridEX.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.listGridEX.DataSource = this.listBindingSource;
            listGridEX_DesignTimeLayout.LayoutString = resources.GetString("listGridEX_DesignTimeLayout.LayoutString");
            this.listGridEX.DesignTimeLayout = listGridEX_DesignTimeLayout;
            this.listGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listGridEX.GroupByBoxVisible = false;
            this.listGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.listGridEX.Hierarchical = true;
            this.listGridEX.Location = new System.Drawing.Point(0, 0);
            this.listGridEX.Name = "listGridEX";
            this.listGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.listGridEX.Size = new System.Drawing.Size(593, 567);
            this.listGridEX.TabIndex = 0;
            this.listGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.listGridEX.DeletingRecords += new System.ComponentModel.CancelEventHandler(this.listGridEX_DeletingRecords);
            // 
            // listBindingSource
            // 
            this.listBindingSource.DataMember = "List";
            this.listBindingSource.DataSource = this.appDB;
            this.listBindingSource.CurrentChanged += new System.EventHandler(this.listBindingSource_CurrentChanged);
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlMember
            // 
            this.pnlMember.InnerContainer = this.pnlMemberContainer;
            this.pnlMember.Location = new System.Drawing.Point(603, 32);
            this.pnlMember.Name = "pnlMember";
            this.pnlMember.Size = new System.Drawing.Size(593, 591);
            this.pnlMember.TabIndex = 4;
            this.pnlMember.Text = "List Members";
            // 
            // pnlMemberContainer
            // 
            this.pnlMemberContainer.Controls.Add(this.listMemberGridEX);
            this.pnlMemberContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlMemberContainer.Name = "pnlMemberContainer";
            this.pnlMemberContainer.Size = new System.Drawing.Size(591, 567);
            this.pnlMemberContainer.TabIndex = 0;
            // 
            // listMemberGridEX
            // 
            this.listMemberGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.listMemberGridEX.AlternatingColors = true;
            this.listMemberGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.listMemberGridEX.DataSource = this.listMemberBindingSource;
            listMemberGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("listMemberGridEX_DesignTimeLayout_Reference_0.Instance")));
            listMemberGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("listMemberGridEX_DesignTimeLayout_Reference_1.Instance")));
            listMemberGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            listMemberGridEX_DesignTimeLayout_Reference_0,
            listMemberGridEX_DesignTimeLayout_Reference_1});
            listMemberGridEX_DesignTimeLayout.LayoutString = resources.GetString("listMemberGridEX_DesignTimeLayout.LayoutString");
            this.listMemberGridEX.DesignTimeLayout = listMemberGridEX_DesignTimeLayout;
            this.listMemberGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMemberGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMemberGridEX.GroupByBoxVisible = false;
            this.listMemberGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.listMemberGridEX.Location = new System.Drawing.Point(0, 0);
            this.listMemberGridEX.Name = "listMemberGridEX";
            this.listMemberGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.listMemberGridEX.Size = new System.Drawing.Size(591, 567);
            this.listMemberGridEX.TabIndex = 0;
            this.listMemberGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.listMemberGridEX.DeletingRecords += new System.ComponentModel.CancelEventHandler(this.listMemberGridEX_DeletingRecords);
            this.listMemberGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.listMemberGridEX_ColumnButtonClick);
            // 
            // listMemberBindingSource
            // 
            this.listMemberBindingSource.DataMember = "ListMember";
            this.listMemberBindingSource.DataSource = this.appDB;
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.Name = "Separator2";
            // 
            // fDistributionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1200, 627);
            this.Controls.Add(this.pnlMember);
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fDistributionList";
            this.Text = "Distribution Lists";
            this.Load += new System.EventHandler(this.fDistributionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMember)).EndInit();
            this.pnlMember.ResumeLayout(false);
            this.pnlMemberContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listMemberGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listMemberBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.GridEX.GridEX listGridEX;
        private System.Windows.Forms.BindingSource listBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewList;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewMember1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewMember;
        private Janus.Windows.UI.Dock.UIPanel pnlMember;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlMemberContainer;
        private Janus.Windows.GridEX.GridEX listMemberGridEX;
        private System.Windows.Forms.BindingSource listMemberBindingSource;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
    }
}
