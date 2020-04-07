 namespace LawMate.Admin
{
    partial class fExportDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fExportDocs));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.ebMessage = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebCount = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ebSQL = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdExecute1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExecute");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSaveExcel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSaveExcel");
            this.cmdExecute = new Janus.Windows.UI.CommandBars.UICommand("cmdExecute");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdSaveExcel = new Janus.Windows.UI.CommandBars.UICommand("cmdSaveExcel");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridEX1
            // 
            this.gridEX1.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.gridEX1.DataSource = this.bindingSource1;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridEX1.Hierarchical = true;
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.Size = new System.Drawing.Size(963, 158);
            this.gridEX1.TabIndex = 5;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEX1.EditModeChanged += new System.EventHandler(this.gridEX1_EditModeChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML|*.xml";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(3, 147);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(90, 13);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Output Message:";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Location = new System.Drawing.Point(3, 174);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(77, 13);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "Record Count:";
            // 
            // ebMessage
            // 
            this.ebMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ebMessage.Location = new System.Drawing.Point(99, 143);
            this.ebMessage.Name = "ebMessage";
            this.ebMessage.ReadOnly = true;
            this.ebMessage.Size = new System.Drawing.Size(861, 21);
            this.ebMessage.TabIndex = 8;
            this.ebMessage.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebCount
            // 
            this.ebCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ebCount.Location = new System.Drawing.Point(99, 170);
            this.ebCount.Name = "ebCount";
            this.ebCount.ReadOnly = true;
            this.ebCount.Size = new System.Drawing.Size(94, 21);
            this.ebCount.TabIndex = 9;
            this.ebCount.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.PanelPadding.Bottom = 0;
            this.uiPanelManager1.PanelPadding.Left = 0;
            this.uiPanelManager1.PanelPadding.Right = 0;
            this.uiPanelManager1.PanelPadding.Top = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlTop.Id = new System.Guid("51f719f8-e0a3-4c89-a991-f4c8c3149a8b");
            this.uiPanelManager1.Panels.Add(this.pnlTop);
            this.pnlGrid.Id = new System.Guid("9dd5e16a-8e18-42c0-b4bc-ff57f86f2473");
            this.uiPanelManager1.Panels.Add(this.pnlGrid);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("51f719f8-e0a3-4c89-a991-f4c8c3149a8b"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(965, 202), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("9dd5e16a-8e18-42c0-b4bc-ff57f86f2473"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(965, 182), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("51f719f8-e0a3-4c89-a991-f4c8c3149a8b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("9dd5e16a-8e18-42c0-b4bc-ff57f86f2473"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlTop
            // 
            this.pnlTop.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            this.pnlTop.Location = new System.Drawing.Point(0, 28);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(965, 202);
            this.pnlTop.TabIndex = 4;
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Controls.Add(this.ebSQL);
            this.pnlTopContainer.Controls.Add(this.ebCount);
            this.pnlTopContainer.Controls.Add(this.lblMessage);
            this.pnlTopContainer.Controls.Add(this.ebMessage);
            this.pnlTopContainer.Controls.Add(this.lblCount);
            this.pnlTopContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Size = new System.Drawing.Size(963, 196);
            this.pnlTopContainer.TabIndex = 0;
            // 
            // ebSQL
            // 
            this.ebSQL.AcceptsReturn = true;
            this.ebSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ebSQL.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ebSQL.HideSelection = false;
            this.ebSQL.Location = new System.Drawing.Point(3, 3);
            this.ebSQL.Multiline = true;
            this.ebSQL.Name = "ebSQL";
            this.ebSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ebSQL.Size = new System.Drawing.Size(957, 138);
            this.ebSQL.TabIndex = 10;
            this.ebSQL.Text = "select f.FullFileNumber,f.NameE,f.FileId,d.DocId,d.efSubject";
            this.ebSQL.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSQL_KeyDown);
            // 
            // pnlGrid
            // 
            this.pnlGrid.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Standard;
            this.pnlGrid.InnerContainer = this.pnlGridContainer;
            this.pnlGrid.Location = new System.Drawing.Point(0, 230);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(965, 182);
            this.pnlGrid.TabIndex = 4;
            this.pnlGrid.Text = "Query Results";
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.gridEX1);
            this.pnlGridContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(963, 158);
            this.pnlGridContainer.TabIndex = 0;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdExecute,
            this.cmdSave,
            this.cmdSaveExcel});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("ac89ee5e-3199-4166-98b3-d8ba0803e86c");
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
            this.BottomRebar1.Location = new System.Drawing.Point(0, 412);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(965, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdExecute1,
            this.Separator1,
            this.cmdSave1,
            this.Separator2,
            this.Separator3,
            this.cmdSaveExcel1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.Size = new System.Drawing.Size(965, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdExecute1
            // 
            this.cmdExecute1.Key = "cmdExecute";
            this.cmdExecute1.Name = "cmdExecute1";
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
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.Name = "Separator2";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator3.Key = "Separator";
            this.Separator3.Name = "Separator3";
            // 
            // cmdSaveExcel1
            // 
            this.cmdSaveExcel1.Key = "cmdSaveExcel";
            this.cmdSaveExcel1.Name = "cmdSaveExcel1";
            // 
            // cmdExecute
            // 
            this.cmdExecute.Image = ((System.Drawing.Image)(resources.GetObject("cmdExecute.Image")));
            this.cmdExecute.Key = "cmdExecute";
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Text = "Execute";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Key = "cmdSave";
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Text = "Export";
            // 
            // cmdSaveExcel
            // 
            this.cmdSaveExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveExcel.Image")));
            this.cmdSaveExcel.Key = "cmdSaveExcel";
            this.cmdSaveExcel.Name = "cmdSaveExcel";
            this.cmdSaveExcel.Text = "Save to Excel";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 28);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 384);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(965, 28);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 384);
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
            this.TopRebar1.Size = new System.Drawing.Size(965, 28);
            // 
            // fExportDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(965, 412);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.BottomRebar1);
            this.Name = "fExportDocs";
            this.Text = "Adhoc Query";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTopContainer.ResumeLayout(false);
            this.pnlTopContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
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

        private System.Windows.Forms.BindingSource bindingSource1;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblCount;
        private Janus.Windows.GridEX.EditControls.EditBox ebMessage;
        private Janus.Windows.GridEX.EditControls.EditBox ebCount;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.GridEX.EditControls.EditBox ebSQL;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExecute1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdSaveExcel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExecute;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdSaveExcel;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
