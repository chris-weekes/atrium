 namespace LawMate.Admin
{
    partial class fTagPicker
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
            Janus.Windows.GridEX.GridEXLayout ddTableGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout ddFieldGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTagPicker));
            this.ddTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.ddFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlLeft = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLeftContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ddTableGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlRight = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlRightContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.cboEndTag = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTagType = new System.Windows.Forms.ComboBox();
            this.ddFieldGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlTables = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivitiesListContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlFields = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityCodeDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ddTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddFieldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddTableGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlRightContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddFieldGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTables)).BeginInit();
            this.pnlTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFields)).BeginInit();
            this.pnlFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddTableBindingSource
            // 
            this.ddTableBindingSource.AllowNew = false;
            this.ddTableBindingSource.DataSource = this.appDB;
            this.ddTableBindingSource.Position = 0;
            this.ddTableBindingSource.CurrentChanged += new System.EventHandler(this.ddTableBindingSource_CurrentChanged);
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ddFieldBindingSource
            // 
            this.ddFieldBindingSource.AllowNew = false;
            this.ddFieldBindingSource.DataMember = "ddField";
            this.ddFieldBindingSource.DataSource = this.appDB;
            this.ddFieldBindingSource.CurrentChanged += new System.EventHandler(this.ddFieldBindingSource_CurrentChanged);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlLeft.Id = new System.Guid("0e646114-9f0f-40b7-b2dd-4e5badf7ab8e");
            this.uiPanelManager1.Panels.Add(this.pnlLeft);
            this.pnlRight.Id = new System.Guid("7421417b-838d-4eda-ac05-8abd200b742c");
            this.uiPanelManager1.Panels.Add(this.pnlRight);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("0e646114-9f0f-40b7-b2dd-4e5badf7ab8e"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(357, 252), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7421417b-838d-4eda-ac05-8abd200b742c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(467, 252), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("59466cee-7156-4631-87a5-2a22fb966b6c"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e66ca4db-b710-440f-9e78-69a2449a22a1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("781514b0-d837-4426-b179-4cfa8bc6cf2b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b41e9eb9-a043-4d26-8bbe-8b54d893b734"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7dd7c9eb-ceff-439e-88c8-e8a9a19120aa"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e67541b4-db01-4943-a3d2-eca11f81f0d1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("420b2dad-9a8c-4eed-bac3-45d46e44e1cd"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0e646114-9f0f-40b7-b2dd-4e5badf7ab8e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7421417b-838d-4eda-ac05-8abd200b742c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("663e57ed-1ee8-44c3-a521-e91ca3a62cae"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlLeft
            // 
            this.pnlLeft.InnerContainer = this.pnlLeftContainer;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(357, 252);
            this.pnlLeft.TabIndex = 4;
            this.pnlLeft.Text = "Tables";
            // 
            // pnlLeftContainer
            // 
            this.pnlLeftContainer.Controls.Add(this.ddTableGridEX);
            this.pnlLeftContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlLeftContainer.Name = "pnlLeftContainer";
            this.pnlLeftContainer.Size = new System.Drawing.Size(351, 228);
            this.pnlLeftContainer.TabIndex = 0;
            // 
            // ddTableGridEX
            // 
            this.ddTableGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ddTableGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.ddTableGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ddTableGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ddTableGridEX.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ddTableGridEX.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ddTableGridEX.DataSource = this.ddTableBindingSource;
            this.ddTableGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddTableGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.ddTableGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ddTableGridEX.GridLineColor = System.Drawing.SystemColors.Window;
            this.ddTableGridEX.GroupByBoxVisible = false;
            this.ddTableGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            ddTableGridEX_Layout_0.DataSource = this.ddTableBindingSource;
            ddTableGridEX_Layout_0.IsCurrentLayout = true;
            ddTableGridEX_Layout_0.Key = "LayoutAll";
            ddTableGridEX_Layout_0.LayoutString = resources.GetString("ddTableGridEX_Layout_0.LayoutString");
            this.ddTableGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            ddTableGridEX_Layout_0});
            this.ddTableGridEX.Location = new System.Drawing.Point(0, 0);
            this.ddTableGridEX.Name = "ddTableGridEX";
            this.ddTableGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.ddTableGridEX.SelectedFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.ddTableGridEX.Size = new System.Drawing.Size(351, 228);
            this.ddTableGridEX.TabIndex = 0;
            this.ddTableGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // pnlRight
            // 
            this.pnlRight.InnerContainer = this.pnlRightContainer;
            this.pnlRight.Location = new System.Drawing.Point(360, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(467, 252);
            this.pnlRight.TabIndex = 4;
            this.pnlRight.Text = "Fields";
            // 
            // pnlRightContainer
            // 
            this.pnlRightContainer.Controls.Add(this.button1);
            this.pnlRightContainer.Controls.Add(this.cboEndTag);
            this.pnlRightContainer.Controls.Add(this.label2);
            this.pnlRightContainer.Controls.Add(this.label1);
            this.pnlRightContainer.Controls.Add(this.cboTagType);
            this.pnlRightContainer.Controls.Add(this.ddFieldGridEX);
            this.pnlRightContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlRightContainer.Name = "pnlRightContainer";
            this.pnlRightContainer.Size = new System.Drawing.Size(465, 228);
            this.pnlRightContainer.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(318, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Insert Tag";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboEndTag
            // 
            this.cboEndTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboEndTag.FormattingEnabled = true;
            this.cboEndTag.Items.AddRange(new object[] {
            "else",
            "endif",
            "end repeat",
            "value:Special/Today",
            "value:Special/Time",
            "value:Special/Counter"});
            this.cboEndTag.Location = new System.Drawing.Point(70, 202);
            this.cboEndTag.Name = "cboEndTag";
            this.cboEndTag.Size = new System.Drawing.Size(242, 21);
            this.cboEndTag.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Other Tag:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tag Type:";
            // 
            // cboTagType
            // 
            this.cboTagType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboTagType.FormattingEnabled = true;
            this.cboTagType.Items.AddRange(new object[] {
            "value",
            "nvalue",
            "if",
            "repeat"});
            this.cboTagType.Location = new System.Drawing.Point(70, 178);
            this.cboTagType.Name = "cboTagType";
            this.cboTagType.Size = new System.Drawing.Size(242, 21);
            this.cboTagType.TabIndex = 1;
            this.cboTagType.Text = "value";
            // 
            // ddFieldGridEX
            // 
            this.ddFieldGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ddFieldGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.ddFieldGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ddFieldGridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddFieldGridEX.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ddFieldGridEX.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ddFieldGridEX.DataSource = this.ddFieldBindingSource;
            this.ddFieldGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.ddFieldGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ddFieldGridEX.GridLineColor = System.Drawing.SystemColors.Window;
            this.ddFieldGridEX.GroupByBoxVisible = false;
            this.ddFieldGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            ddFieldGridEX_Layout_0.DataSource = this.ddFieldBindingSource;
            ddFieldGridEX_Layout_0.IsCurrentLayout = true;
            ddFieldGridEX_Layout_0.Key = "LayoutAll";
            ddFieldGridEX_Layout_0.LayoutString = resources.GetString("ddFieldGridEX_Layout_0.LayoutString");
            this.ddFieldGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            ddFieldGridEX_Layout_0});
            this.ddFieldGridEX.Location = new System.Drawing.Point(-1, -1);
            this.ddFieldGridEX.Name = "ddFieldGridEX";
            this.ddFieldGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.ddFieldGridEX.SelectedFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.ddFieldGridEX.Size = new System.Drawing.Size(467, 173);
            this.ddFieldGridEX.TabIndex = 0;
            this.ddFieldGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ddFieldGridEX.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.ddFieldGridEX_LinkClicked);
            // 
            // pnlTables
            // 
            this.pnlTables.InnerContainer = this.pnlActivitiesListContainer;
            this.pnlTables.Location = new System.Drawing.Point(0, 0);
            this.pnlTables.Name = "pnlTables";
            this.pnlTables.Size = new System.Drawing.Size(190, 503);
            this.pnlTables.TabIndex = 0;
            this.pnlTables.Text = "Tables";
            // 
            // pnlActivitiesListContainer
            // 
            this.pnlActivitiesListContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivitiesListContainer.Name = "pnlActivitiesListContainer";
            this.pnlActivitiesListContainer.Size = new System.Drawing.Size(190, 503);
            this.pnlActivitiesListContainer.TabIndex = 0;
            // 
            // pnlFields
            // 
            this.pnlFields.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlFields.InnerContainer = this.pnlActivityCodeDetailsContainer;
            this.pnlFields.Location = new System.Drawing.Point(194, 0);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(230, 503);
            this.pnlFields.TabIndex = 1;
            this.pnlFields.Text = "Fields";
            // 
            // pnlActivityCodeDetailsContainer
            // 
            this.pnlActivityCodeDetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivityCodeDetailsContainer.Name = "pnlActivityCodeDetailsContainer";
            this.pnlActivityCodeDetailsContainer.Size = new System.Drawing.Size(230, 503);
            this.pnlActivityCodeDetailsContainer.TabIndex = 0;
            // 
            // fTagPicker
            // 
            this.ClientSize = new System.Drawing.Size(830, 258);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "fTagPicker";
            this.Text = "Tag Picker";
            ((System.ComponentModel.ISupportInitialize)(this.ddTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddFieldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddTableGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRightContainer.ResumeLayout(false);
            this.pnlRightContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddFieldGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTables)).EndInit();
            this.pnlTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFields)).EndInit();
            this.pnlFields.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlTables;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivitiesListContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlFields;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityCodeDetailsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlRight;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlRightContainer;
        private Janus.Windows.GridEX.GridEX ddFieldGridEX;
        private System.Windows.Forms.BindingSource ddFieldBindingSource;
        private Janus.Windows.UI.Dock.UIPanel pnlLeft;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLeftContainer;
        private Janus.Windows.GridEX.GridEX ddTableGridEX;
        private System.Windows.Forms.BindingSource ddTableBindingSource;
        private lmDatasets.appDB appDB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboEndTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTagType;
    }
}
