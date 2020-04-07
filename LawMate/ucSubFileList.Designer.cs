 namespace LawMate
{
    partial class ucSubFileList
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
            Janus.Windows.GridEX.GridEXLayout eFileSearchGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference eFileSearchGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference eFileSearchGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference eFileSearchGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item2.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference eFileSearchGridEX_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item3.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference eFileSearchGridEX_DesignTimeLayout_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item4.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference eFileSearchGridEX_DesignTimeLayout_Reference_5 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.Image");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSubFileList));
            this.atriumDB = new lmDatasets.atriumDB();
            this.appDB = new lmDatasets.appDB();
            this.eFileSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eFileSearchGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdMove1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMove");
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdMove = new Janus.Windows.UI.CommandBars.UICommand("cmdMove");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFileSearchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFileSearchGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.SuspendLayout();
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eFileSearchBindingSource
            // 
            this.eFileSearchBindingSource.DataMember = "EFileSearch";
            this.eFileSearchBindingSource.DataSource = this.appDB;
            this.eFileSearchBindingSource.CurrentChanged += new System.EventHandler(this.eFileSearchBindingSource_CurrentChanged);
            // 
            // eFileSearchGridEX
            // 
            this.eFileSearchGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.eFileSearchGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.uiCommandManager1.SetContextMenu(this.eFileSearchGridEX, this.uiContextMenu1);
            this.eFileSearchGridEX.DataSource = this.eFileSearchBindingSource;
            eFileSearchGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("eFileSearchGridEX_DesignTimeLayout_Reference_0.Instance")));
            eFileSearchGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("eFileSearchGridEX_DesignTimeLayout_Reference_1.Instance")));
            eFileSearchGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("eFileSearchGridEX_DesignTimeLayout_Reference_2.Instance")));
            eFileSearchGridEX_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("eFileSearchGridEX_DesignTimeLayout_Reference_3.Instance")));
            eFileSearchGridEX_DesignTimeLayout_Reference_4.Instance = ((object)(resources.GetObject("eFileSearchGridEX_DesignTimeLayout_Reference_4.Instance")));
            eFileSearchGridEX_DesignTimeLayout_Reference_5.Instance = ((object)(resources.GetObject("eFileSearchGridEX_DesignTimeLayout_Reference_5.Instance")));
            eFileSearchGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            eFileSearchGridEX_DesignTimeLayout_Reference_0,
            eFileSearchGridEX_DesignTimeLayout_Reference_1,
            eFileSearchGridEX_DesignTimeLayout_Reference_2,
            eFileSearchGridEX_DesignTimeLayout_Reference_3,
            eFileSearchGridEX_DesignTimeLayout_Reference_4,
            eFileSearchGridEX_DesignTimeLayout_Reference_5});
            eFileSearchGridEX_DesignTimeLayout.LayoutString = resources.GetString("eFileSearchGridEX_DesignTimeLayout.LayoutString");
            this.eFileSearchGridEX.DesignTimeLayout = eFileSearchGridEX_DesignTimeLayout;
            this.eFileSearchGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eFileSearchGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.eFileSearchGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.eFileSearchGridEX.GroupByBoxVisible = false;
            this.eFileSearchGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.eFileSearchGridEX.Location = new System.Drawing.Point(0, 0);
            this.eFileSearchGridEX.Name = "eFileSearchGridEX";
            this.eFileSearchGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.eFileSearchGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.eFileSearchGridEX.Size = new System.Drawing.Size(673, 349);
            this.eFileSearchGridEX.TabIndex = 1;
            this.eFileSearchGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.eFileSearchGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdMove});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1});
            this.uiCommandManager1.Id = new System.Guid("a6999fea-0bf1-4280-a46f-51493b829448");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdMove1});
            this.uiContextMenu1.Key = "ContextMenu1";
            this.uiContextMenu1.Popup += new System.EventHandler(this.uiContextMenu1_Popup);
            // 
            // cmdMove1
            // 
            this.cmdMove1.Key = "cmdMove";
            this.cmdMove1.Name = "cmdMove1";
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 349);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(673, 0);
            // 
            // cmdMove
            // 
            this.cmdMove.Image = ((System.Drawing.Image)(resources.GetObject("cmdMove.Image")));
            this.cmdMove.Key = "cmdMove";
            this.cmdMove.Name = "cmdMove";
            this.cmdMove.Text = "Move Selected Files";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 349);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(673, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 349);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(673, 0);
            // 
            // ucSubFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eFileSearchGridEX);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.BottomRebar1);
            this.Name = "ucSubFileList";
            this.Size = new System.Drawing.Size(673, 349);
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFileSearchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFileSearchGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private lmDatasets.atriumDB atriumDB;
        private lmDatasets.appDB appDB;
        private System.Windows.Forms.BindingSource eFileSearchBindingSource;
        private Janus.Windows.GridEX.GridEX eFileSearchGridEX;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMove;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMove1;
    }
}
