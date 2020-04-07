 namespace LawMate.Admin
{
    partial class fOfficeToJudicialDistrict
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
            System.Windows.Forms.Label officeIdLabel;
            System.Windows.Forms.Label jDCodeLabel;
            System.Windows.Forms.Label jDDescEngLabel;
            System.Windows.Forms.Label provinceCodeLabel;
            Janus.Windows.GridEX.GridEXLayout office2JDGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOfficeToJudicialDistrict));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlLeft = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLeftContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.office2JDGridEX = new Janus.Windows.GridEX.GridEX();
            this.office2JDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFields = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlFieldsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.mccProvinceCode = new UserControls.ucMultiDropDown();
            this.jDCodeTextBox = new System.Windows.Forms.TextBox();
            this.mccOfficeId = new UserControls.ucMultiDropDown();
            this.jDDescEngEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivitiesListContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlDetails = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityCodeDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.officeDB = new lmDatasets.officeDB();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            officeIdLabel = new System.Windows.Forms.Label();
            jDCodeLabel = new System.Windows.Forms.Label();
            jDDescEngLabel = new System.Windows.Forms.Label();
            provinceCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.office2JDGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.office2JDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFields)).BeginInit();
            this.pnlFields.SuspendLayout();
            this.pnlFieldsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetails)).BeginInit();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // officeIdLabel
            // 
            officeIdLabel.AutoSize = true;
            officeIdLabel.BackColor = System.Drawing.Color.Transparent;
            officeIdLabel.Location = new System.Drawing.Point(17, 102);
            officeIdLabel.Name = "officeIdLabel";
            officeIdLabel.Size = new System.Drawing.Size(100, 13);
            officeIdLabel.TabIndex = 0;
            officeIdLabel.Text = "Responsible Office:";
            // 
            // jDCodeLabel
            // 
            jDCodeLabel.AutoSize = true;
            jDCodeLabel.BackColor = System.Drawing.Color.Transparent;
            jDCodeLabel.Location = new System.Drawing.Point(17, 20);
            jDCodeLabel.Name = "jDCodeLabel";
            jDCodeLabel.Size = new System.Drawing.Size(109, 13);
            jDCodeLabel.TabIndex = 6;
            jDCodeLabel.Text = "Judicial District Code:";
            // 
            // jDDescEngLabel
            // 
            jDDescEngLabel.AutoSize = true;
            jDDescEngLabel.BackColor = System.Drawing.Color.Transparent;
            jDDescEngLabel.Location = new System.Drawing.Point(17, 48);
            jDDescEngLabel.Name = "jDDescEngLabel";
            jDDescEngLabel.Size = new System.Drawing.Size(81, 13);
            jDDescEngLabel.TabIndex = 8;
            jDDescEngLabel.Text = "Judicial District:";
            // 
            // provinceCodeLabel
            // 
            provinceCodeLabel.AutoSize = true;
            provinceCodeLabel.BackColor = System.Drawing.Color.Transparent;
            provinceCodeLabel.Location = new System.Drawing.Point(17, 75);
            provinceCodeLabel.Name = "provinceCodeLabel";
            provinceCodeLabel.Size = new System.Drawing.Size(80, 13);
            provinceCodeLabel.TabIndex = 10;
            provinceCodeLabel.Text = "Province Code:";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlLeft.Id = new System.Guid("1a3e1ee6-7b82-4cef-88db-e6a624d2c449");
            this.uiPanelManager1.Panels.Add(this.pnlLeft);
            this.pnlFields.Id = new System.Guid("0f89a5c6-7dda-42bb-84c5-211013e768c7");
            this.uiPanelManager1.Panels.Add(this.pnlFields);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("1a3e1ee6-7b82-4cef-88db-e6a624d2c449"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(447, 311), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("0f89a5c6-7dda-42bb-84c5-211013e768c7"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(450, 311), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("59466cee-7156-4631-87a5-2a22fb966b6c"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e66ca4db-b710-440f-9e78-69a2449a22a1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("781514b0-d837-4426-b179-4cfa8bc6cf2b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b41e9eb9-a043-4d26-8bbe-8b54d893b734"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7dd7c9eb-ceff-439e-88c8-e8a9a19120aa"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e67541b4-db01-4943-a3d2-eca11f81f0d1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("420b2dad-9a8c-4eed-bac3-45d46e44e1cd"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1a3e1ee6-7b82-4cef-88db-e6a624d2c449"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0f89a5c6-7dda-42bb-84c5-211013e768c7"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlLeft
            // 
            this.pnlLeft.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlLeft.InnerContainer = this.pnlLeftContainer;
            this.pnlLeft.Location = new System.Drawing.Point(3, 31);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(447, 311);
            this.pnlLeft.TabIndex = 4;
            this.pnlLeft.Text = "Offices to Judicial Districts";
            // 
            // pnlLeftContainer
            // 
            this.pnlLeftContainer.Controls.Add(this.office2JDGridEX);
            this.pnlLeftContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlLeftContainer.Name = "pnlLeftContainer";
            this.pnlLeftContainer.Size = new System.Drawing.Size(441, 287);
            this.pnlLeftContainer.TabIndex = 0;
            // 
            // office2JDGridEX
            // 
            this.office2JDGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.office2JDGridEX.AlternatingColors = true;
            this.office2JDGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.office2JDGridEX.DataSource = this.office2JDBindingSource;
            office2JDGridEX_DesignTimeLayout.LayoutString = resources.GetString("office2JDGridEX_DesignTimeLayout.LayoutString");
            this.office2JDGridEX.DesignTimeLayout = office2JDGridEX_DesignTimeLayout;
            this.office2JDGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.office2JDGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.office2JDGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.office2JDGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.office2JDGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.office2JDGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.office2JDGridEX.GroupRowFormatStyle.FontName = "arial";
            this.office2JDGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.office2JDGridEX.Location = new System.Drawing.Point(0, 0);
            this.office2JDGridEX.Name = "office2JDGridEX";
            this.office2JDGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.office2JDGridEX.Size = new System.Drawing.Size(441, 287);
            this.office2JDGridEX.TabIndex = 0;
            this.office2JDGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // office2JDBindingSource
            // 
            this.office2JDBindingSource.DataMember = "Office2JD";
            this.office2JDBindingSource.DataSource = typeof(lmDatasets.officeDB);
            // 
            // pnlFields
            // 
            this.pnlFields.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlFields.InnerContainer = this.pnlFieldsContainer;
            this.pnlFields.Location = new System.Drawing.Point(450, 31);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(450, 311);
            this.pnlFields.TabIndex = 4;
            this.pnlFields.Text = "Details";
            // 
            // pnlFieldsContainer
            // 
            this.pnlFieldsContainer.Controls.Add(this.mccProvinceCode);
            this.pnlFieldsContainer.Controls.Add(jDCodeLabel);
            this.pnlFieldsContainer.Controls.Add(officeIdLabel);
            this.pnlFieldsContainer.Controls.Add(this.jDCodeTextBox);
            this.pnlFieldsContainer.Controls.Add(this.mccOfficeId);
            this.pnlFieldsContainer.Controls.Add(jDDescEngLabel);
            this.pnlFieldsContainer.Controls.Add(this.jDDescEngEditBox);
            this.pnlFieldsContainer.Controls.Add(provinceCodeLabel);
            this.pnlFieldsContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlFieldsContainer.Name = "pnlFieldsContainer";
            this.pnlFieldsContainer.Size = new System.Drawing.Size(448, 287);
            this.pnlFieldsContainer.TabIndex = 0;
            // 
            // mccProvinceCode
            // 
            this.mccProvinceCode.BackColor = System.Drawing.Color.Transparent;
            this.mccProvinceCode.Column1 = "provincecode";
            this.mccProvinceCode.Column2 = "provincedescriptioneng";
            this.mccProvinceCode.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccProvinceCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.office2JDBindingSource, "ProvinceCode", true));
            this.mccProvinceCode.DataSource = null;
            this.mccProvinceCode.DisplayMember = "provincecode";
            this.mccProvinceCode.DisplayNameColumn1 = "Code";
            this.mccProvinceCode.DisplayNameColumn2 = "Description";
            this.mccProvinceCode.DropDownColumn1Width = 70;
            this.mccProvinceCode.DropDownColumn2Width = 300;
            this.mccProvinceCode.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mccProvinceCode.Location = new System.Drawing.Point(132, 71);
            this.mccProvinceCode.Middle = 60;
            this.mccProvinceCode.Name = "mccProvinceCode";
            this.mccProvinceCode.ReadOnly = false;
            this.mccProvinceCode.ReqColor = System.Drawing.SystemColors.Window;
            this.mccProvinceCode.SelectedValue = null;
            this.mccProvinceCode.Size = new System.Drawing.Size(297, 21);
            this.mccProvinceCode.TabIndex = 12;
            this.mccProvinceCode.ValueMember = "provincecode";
            // 
            // jDCodeTextBox
            // 
            this.jDCodeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.jDCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.office2JDBindingSource, "JDCode", true));
            this.jDCodeTextBox.Location = new System.Drawing.Point(132, 17);
            this.jDCodeTextBox.Name = "jDCodeTextBox";
            this.jDCodeTextBox.Size = new System.Drawing.Size(59, 21);
            this.jDCodeTextBox.TabIndex = 7;
            // 
            // mccOfficeId
            // 
            this.mccOfficeId.BackColor = System.Drawing.Color.Transparent;
            this.mccOfficeId.Column1 = "officecode";
            this.mccOfficeId.Column2 = "officename";
            this.mccOfficeId.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccOfficeId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.office2JDBindingSource, "OfficeId", true));
            this.mccOfficeId.DataSource = null;
            this.mccOfficeId.DisplayMember = "officecode";
            this.mccOfficeId.DisplayNameColumn1 = "";
            this.mccOfficeId.DisplayNameColumn2 = "";
            this.mccOfficeId.DropDownColumn1Width = 100;
            this.mccOfficeId.DropDownColumn2Width = 300;
            this.mccOfficeId.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mccOfficeId.Location = new System.Drawing.Point(132, 98);
            this.mccOfficeId.Middle = 60;
            this.mccOfficeId.Name = "mccOfficeId";
            this.mccOfficeId.ReadOnly = false;
            this.mccOfficeId.ReqColor = System.Drawing.SystemColors.Window;
            this.mccOfficeId.SelectedValue = null;
            this.mccOfficeId.Size = new System.Drawing.Size(297, 21);
            this.mccOfficeId.TabIndex = 4;
            this.mccOfficeId.ValueMember = "officeid";
            // 
            // jDDescEngEditBox
            // 
            this.jDDescEngEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.office2JDBindingSource, "JDDescEng", true));
            this.jDDescEngEditBox.Location = new System.Drawing.Point(132, 44);
            this.jDDescEngEditBox.Name = "jDDescEngEditBox";
            this.jDDescEngEditBox.ReadOnly = true;
            this.jDDescEngEditBox.Size = new System.Drawing.Size(297, 21);
            this.jDDescEngEditBox.TabIndex = 9;
            // 
            // pnlGrid
            // 
            this.pnlGrid.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlGrid.InnerContainer = this.pnlActivitiesListContainer;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(249, 625);
            this.pnlGrid.TabIndex = 0;
            this.pnlGrid.Text = "Office To Judicial District";
            // 
            // pnlActivitiesListContainer
            // 
            this.pnlActivitiesListContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivitiesListContainer.Name = "pnlActivitiesListContainer";
            this.pnlActivitiesListContainer.Size = new System.Drawing.Size(249, 625);
            this.pnlActivitiesListContainer.TabIndex = 0;
            // 
            // pnlDetails
            // 
            this.pnlDetails.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDetails.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlDetails.InnerContainer = this.pnlActivityCodeDetailsContainer;
            this.pnlDetails.Location = new System.Drawing.Point(253, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(476, 625);
            this.pnlDetails.TabIndex = 1;
            // 
            // pnlActivityCodeDetailsContainer
            // 
            this.pnlActivityCodeDetailsContainer.AutoScroll = true;
            this.pnlActivityCodeDetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivityCodeDetailsContainer.Name = "pnlActivityCodeDetailsContainer";
            this.pnlActivityCodeDetailsContainer.Size = new System.Drawing.Size(476, 625);
            this.pnlActivityCodeDetailsContainer.TabIndex = 0;
            // 
            // officeDB
            // 
            this.officeDB.DataSetName = "officeDB";
            this.officeDB.EnforceConstraints = false;
            this.officeDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.cmdDelete});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("b608898e-f7dd-464d-9dc1-0133322bacb5");
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
            this.BottomRebar1.Location = new System.Drawing.Point(0, 525);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(936, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNew1,
            this.Separator1,
            this.cmdSave1,
            this.Separator2,
            this.cmdCancel1,
            this.Separator3,
            this.cmdDelete1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowToolTips = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Size = new System.Drawing.Size(903, 28);
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
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.Name = "Separator2";
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
            this.LeftRebar1.Location = new System.Drawing.Point(0, 28);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 497);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(936, 28);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 497);
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
            this.TopRebar1.Size = new System.Drawing.Size(903, 28);
            // 
            // fOfficeToJudicialDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 345);
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fOfficeToJudicialDistrict";
            this.Text = "Office to Judicial District Management";
            this.Load += new System.EventHandler(this.fOfficeToJudicialDistrict_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.office2JDGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.office2JDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFields)).EndInit();
            this.pnlFields.ResumeLayout(false);
            this.pnlFieldsContainer.ResumeLayout(false);
            this.pnlFieldsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetails)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).EndInit();
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
        private System.Windows.Forms.BindingSource office2JDBindingSource;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivitiesListContainer;
        private Janus.Windows.GridEX.GridEX office2JDGridEX;
        private Janus.Windows.UI.Dock.UIPanel pnlDetails;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityCodeDetailsContainer;
        private UserControls.ucMultiDropDown mccOfficeId;
        private lmDatasets.officeDB officeDB;
        private System.Windows.Forms.TextBox jDCodeTextBox;
        private Janus.Windows.GridEX.EditControls.EditBox jDDescEngEditBox;
        private Janus.Windows.UI.Dock.UIPanel pnlFields;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlFieldsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlLeft;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLeftContainer;
        private UserControls.ucMultiDropDown mccProvinceCode;
    }
}