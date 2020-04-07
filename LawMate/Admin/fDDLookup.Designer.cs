namespace LawMate.Admin
{
    partial class fDDLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDDLookup));
            Janus.Windows.GridEX.GridEXLayout ddLookupGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout ddGenericGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdUndo1 = new Janus.Windows.UI.CommandBars.UICommand("cmdUndo");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNewLookup1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewLookup");
            this.cmdNewGeneric1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewGeneric");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdNewLookup = new Janus.Windows.UI.CommandBars.UICommand("cmdNewLookup");
            this.cmdNewGeneric = new Janus.Windows.UI.CommandBars.UICommand("cmdNewGeneric");
            this.cmdUndo = new Janus.Windows.UI.CommandBars.UICommand("cmdUndo");
            this.cmdDeleteList = new Janus.Windows.UI.CommandBars.UICommand("cmdDeleteList");
            this.cmdDeleteItem = new Janus.Windows.UI.CommandBars.UICommand("cmdDeleteItem");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.appDB = new lmDatasets.appDB();
            this.ddLookupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ddLookupGridEX = new Janus.Windows.GridEX.GridEX();
            this.ddGenericBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ddGenericGridEX = new Janus.Windows.GridEX.GridEX();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlResults = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlResultsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddLookupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddLookupGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddGenericBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddGenericGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlResults)).BeginInit();
            this.pnlResults.SuspendLayout();
            this.pnlResultsContainer.SuspendLayout();
            this.SuspendLayout();
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
            this.cmdNewLookup,
            this.cmdNewGeneric,
            this.cmdUndo,
            this.cmdDeleteList,
            this.cmdDeleteItem});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("d2a7ba95-46c5-480a-bf67-ac0d51142e75");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.LockCommandBars = true;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowQuickCustomizeMenu = false;
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
            this.cmdSave1,
            this.cmdUndo1,
            this.Separator1,
            this.cmdNewLookup1,
            this.cmdNewGeneric1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.Size = new System.Drawing.Size(830, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdSave1
            // 
            this.cmdSave1.Key = "cmdSave";
            this.cmdSave1.Name = "cmdSave1";
            // 
            // cmdUndo1
            // 
            this.cmdUndo1.Key = "cmdUndo";
            this.cmdUndo1.Name = "cmdUndo1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdNewLookup1
            // 
            this.cmdNewLookup1.Key = "cmdNewLookup";
            this.cmdNewLookup1.Name = "cmdNewLookup1";
            // 
            // cmdNewGeneric1
            // 
            this.cmdNewGeneric1.Key = "cmdNewGeneric";
            this.cmdNewGeneric1.Name = "cmdNewGeneric1";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Key = "cmdSave";
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Text = "Save";
            // 
            // cmdNewLookup
            // 
            this.cmdNewLookup.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewLookup.Image")));
            this.cmdNewLookup.Key = "cmdNewLookup";
            this.cmdNewLookup.Name = "cmdNewLookup";
            this.cmdNewLookup.Text = "New List";
            // 
            // cmdNewGeneric
            // 
            this.cmdNewGeneric.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewGeneric.Image")));
            this.cmdNewGeneric.Key = "cmdNewGeneric";
            this.cmdNewGeneric.Name = "cmdNewGeneric";
            this.cmdNewGeneric.Text = "New List Item";
            // 
            // cmdUndo
            // 
            this.cmdUndo.Image = ((System.Drawing.Image)(resources.GetObject("cmdUndo.Image")));
            this.cmdUndo.Key = "cmdUndo";
            this.cmdUndo.Name = "cmdUndo";
            this.cmdUndo.Text = "Undo";
            // 
            // cmdDeleteList
            // 
            this.cmdDeleteList.Key = "cmdDeleteList";
            this.cmdDeleteList.Name = "cmdDeleteList";
            this.cmdDeleteList.Text = "Delete List";
            // 
            // cmdDeleteItem
            // 
            this.cmdDeleteItem.Key = "cmdDeleteItem";
            this.cmdDeleteItem.Name = "cmdDeleteItem";
            this.cmdDeleteItem.Text = "Delete Item";
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
            this.TopRebar1.Size = new System.Drawing.Size(830, 28);
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ddLookupBindingSource
            // 
            this.ddLookupBindingSource.DataMember = "ddLookup";
            this.ddLookupBindingSource.DataSource = this.appDB;
            this.ddLookupBindingSource.CurrentChanged += new System.EventHandler(this.ddLookupBindingSource_CurrentChanged);
            // 
            // ddLookupGridEX
            // 
            this.ddLookupGridEX.AlternatingColors = true;
            this.ddLookupGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ddLookupGridEX.DataSource = this.ddLookupBindingSource;
            ddLookupGridEX_DesignTimeLayout.LayoutString = resources.GetString("ddLookupGridEX_DesignTimeLayout.LayoutString");
            this.ddLookupGridEX.DesignTimeLayout = ddLookupGridEX_DesignTimeLayout;
            this.ddLookupGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddLookupGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.ddLookupGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.ddLookupGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.ddLookupGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.ddLookupGridEX.GroupByBoxVisible = false;
            this.ddLookupGridEX.Location = new System.Drawing.Point(0, 0);
            this.ddLookupGridEX.Name = "ddLookupGridEX";
            this.ddLookupGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.ddLookupGridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.ddLookupGridEX.Size = new System.Drawing.Size(822, 257);
            this.ddLookupGridEX.TabIndex = 2;
            this.ddLookupGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ddGenericBindingSource
            // 
            this.ddGenericBindingSource.DataMember = "ddLookup_ddGeneric";
            this.ddGenericBindingSource.DataSource = this.ddLookupBindingSource;
            // 
            // ddGenericGridEX
            // 
            this.ddGenericGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.ddGenericGridEX.AlternatingColors = true;
            this.ddGenericGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ddGenericGridEX.DataSource = this.ddGenericBindingSource;
            ddGenericGridEX_DesignTimeLayout.LayoutString = resources.GetString("ddGenericGridEX_DesignTimeLayout.LayoutString");
            this.ddGenericGridEX.DesignTimeLayout = ddGenericGridEX_DesignTimeLayout;
            this.ddGenericGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddGenericGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.ddGenericGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.ddGenericGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.ddGenericGridEX.GroupByBoxVisible = false;
            this.ddGenericGridEX.Location = new System.Drawing.Point(0, 0);
            this.ddGenericGridEX.Name = "ddGenericGridEX";
            this.ddGenericGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.ddGenericGridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.ddGenericGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.ddGenericGridEX.Size = new System.Drawing.Size(822, 148);
            this.ddGenericGridEX.TabIndex = 2;
            this.ddGenericGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.gridEX1.DataSource = this.bindingSource1;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEX1.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.gridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridEX1.Hierarchical = true;
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.Size = new System.Drawing.Size(822, 148);
            this.gridEX1.TabIndex = 6;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontSize = 11F;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.ForeColor = System.Drawing.Color.SlateGray;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = 32;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontSize = 11F;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlTop.Id = new System.Guid("7b2bb8a3-c209-4c76-95bf-9bf12846e5a0");
            this.uiPanelManager1.Panels.Add(this.pnlTop);
            this.pnlResults.Id = new System.Guid("48905070-05ee-4948-99e4-883e1771d1e9");
            this.uiPanelManager1.Panels.Add(this.pnlResults);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7b2bb8a3-c209-4c76-95bf-9bf12846e5a0"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(824, 294), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("48905070-05ee-4948-99e4-883e1771d1e9"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(824, 181), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7b2bb8a3-c209-4c76-95bf-9bf12846e5a0"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("48905070-05ee-4948-99e4-883e1771d1e9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlTop
            // 
            this.pnlTop.Image = ((System.Drawing.Image)(resources.GetObject("pnlTop.Image")));
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            this.pnlTop.Location = new System.Drawing.Point(3, 31);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(824, 294);
            this.pnlTop.TabIndex = 4;
            this.pnlTop.Text = "Lists";
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Controls.Add(this.ddLookupGridEX);
            this.pnlTopContainer.Location = new System.Drawing.Point(1, 32);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Size = new System.Drawing.Size(822, 257);
            this.pnlTopContainer.TabIndex = 0;
            // 
            // pnlResults
            // 
            this.pnlResults.Image = ((System.Drawing.Image)(resources.GetObject("pnlResults.Image")));
            this.pnlResults.InnerContainer = this.pnlResultsContainer;
            this.pnlResults.Location = new System.Drawing.Point(3, 325);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(824, 181);
            this.pnlResults.TabIndex = 4;
            this.pnlResults.Text = "List Items";
            // 
            // pnlResultsContainer
            // 
            this.pnlResultsContainer.Controls.Add(this.ddGenericGridEX);
            this.pnlResultsContainer.Controls.Add(this.gridEX1);
            this.pnlResultsContainer.Location = new System.Drawing.Point(1, 32);
            this.pnlResultsContainer.Name = "pnlResultsContainer";
            this.pnlResultsContainer.Size = new System.Drawing.Size(822, 148);
            this.pnlResultsContainer.TabIndex = 0;
            // 
            // fDDLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(830, 509);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fDDLookup";
            this.Text = "DD Lookup";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddLookupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddLookupGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddGenericBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddGenericGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTopContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlResults)).EndInit();
            this.pnlResults.ResumeLayout(false);
            this.pnlResultsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.GridEX.GridEX ddLookupGridEX;
        private System.Windows.Forms.BindingSource ddLookupBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdUndo1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewLookup1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewGeneric1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewLookup;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewGeneric;
        private Janus.Windows.UI.CommandBars.UICommand cmdUndo;
        private Janus.Windows.UI.CommandBars.UICommand cmdDeleteList;
        private Janus.Windows.UI.CommandBars.UICommand cmdDeleteItem;
        private Janus.Windows.GridEX.GridEX ddGenericGridEX;
        private System.Windows.Forms.BindingSource ddGenericBindingSource;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Janus.Windows.UI.Dock.UIPanel pnlResults;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlResultsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;

    }
}
