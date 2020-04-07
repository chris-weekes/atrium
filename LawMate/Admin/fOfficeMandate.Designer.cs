 namespace LawMate.Admin
{
    partial class fOfficeMandate
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
            Janus.Windows.GridEX.GridEXLayout officeMandateGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference officeMandateGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOfficeMandate));
            Janus.Windows.Common.Layouts.JanusLayoutReference officeMandateGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference officeMandateGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference officeMandateGridEX_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.Image");
            this.idLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlMandate = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlMandateContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.officeMandateGridEX = new Janus.Windows.GridEX.GridEX();
            this.officeMandateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activityConfig = new lmDatasets.ActivityConfig();
            this.uiGroupBox4 = new Janus.Windows.EditControls.UIGroupBox();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.mccRole = new LawMate.UserControls.ucMultiDropDown();
            this.mccSeries = new LawMate.UserControls.ucMultiDropDown();
            this.suffixComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.officeCodeComboBox = new LawMate.UserControls.ucMultiDropDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMandate)).BeginInit();
            this.pnlMandate.SuspendLayout();
            this.pnlMandateContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeMandateGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeMandateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).BeginInit();
            this.uiGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(28, 25);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(22, 13);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID:";
            // 
            // label1
            // 
            this.label1.Image = global::LawMate.Properties.Resources.office_building;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(27, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "      Office Code:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Image = global::LawMate.Properties.Resources.act;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(28, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "      Step Code:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Image = global::LawMate.Properties.Resources.workflow;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(28, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "      Worfklow:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Image = global::LawMate.Properties.Resources.roles;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(28, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "      Role Code:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlMandate.Id = new System.Guid("ebb99d86-fa04-4ed1-977b-3ec5eaa9e545");
            this.uiPanelManager1.Panels.Add(this.pnlMandate);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ebb99d86-fa04-4ed1-977b-3ec5eaa9e545"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1220, 627), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ebb99d86-fa04-4ed1-977b-3ec5eaa9e545"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlMandate
            // 
            this.pnlMandate.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlMandate.InnerContainer = this.pnlMandateContainer;
            this.pnlMandate.Location = new System.Drawing.Point(3, 31);
            this.pnlMandate.Name = "pnlMandate";
            this.pnlMandate.Size = new System.Drawing.Size(1220, 627);
            this.pnlMandate.TabIndex = 4;
            this.pnlMandate.Text = "Office Mandates";
            // 
            // pnlMandateContainer
            // 
            this.pnlMandateContainer.AutoScroll = true;
            this.pnlMandateContainer.Controls.Add(this.officeMandateGridEX);
            this.pnlMandateContainer.Controls.Add(this.uiGroupBox4);
            this.pnlMandateContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMandateContainer.Name = "pnlMandateContainer";
            this.pnlMandateContainer.Padding = new System.Windows.Forms.Padding(8);
            this.pnlMandateContainer.Size = new System.Drawing.Size(1220, 627);
            this.pnlMandateContainer.TabIndex = 0;
            // 
            // officeMandateGridEX
            // 
            this.officeMandateGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.officeMandateGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.officeMandateGridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.officeMandateGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.officeMandateGridEX.DataSource = this.officeMandateBindingSource;
            officeMandateGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("officeMandateGridEX_DesignTimeLayout_Reference_0.Instance")));
            officeMandateGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("officeMandateGridEX_DesignTimeLayout_Reference_1.Instance")));
            officeMandateGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("officeMandateGridEX_DesignTimeLayout_Reference_2.Instance")));
            officeMandateGridEX_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("officeMandateGridEX_DesignTimeLayout_Reference_3.Instance")));
            officeMandateGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            officeMandateGridEX_DesignTimeLayout_Reference_0,
            officeMandateGridEX_DesignTimeLayout_Reference_1,
            officeMandateGridEX_DesignTimeLayout_Reference_2,
            officeMandateGridEX_DesignTimeLayout_Reference_3});
            officeMandateGridEX_DesignTimeLayout.LayoutString = resources.GetString("officeMandateGridEX_DesignTimeLayout.LayoutString");
            this.officeMandateGridEX.DesignTimeLayout = officeMandateGridEX_DesignTimeLayout;
            this.officeMandateGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.officeMandateGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.officeMandateGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.officeMandateGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.officeMandateGridEX.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.officeMandateGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.officeMandateGridEX.GroupRowFormatStyle.FontName = "calibri";
            this.officeMandateGridEX.GroupRowFormatStyle.FontSize = 12F;
            this.officeMandateGridEX.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.officeMandateGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.officeMandateGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.officeMandateGridEX.Location = new System.Drawing.Point(9, 11);
            this.officeMandateGridEX.Name = "officeMandateGridEX";
            this.officeMandateGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.officeMandateGridEX.Size = new System.Drawing.Size(1202, 442);
            this.officeMandateGridEX.TabIndex = 25;
            this.officeMandateGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.officeMandateGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.officeMandateGridEX.SelectionChanged += new System.EventHandler(this.officeMandateGridEX_SelectionChanged);
            // 
            // officeMandateBindingSource
            // 
            this.officeMandateBindingSource.DataMember = "OfficeMandate";
            this.officeMandateBindingSource.DataSource = this.activityConfig;
            // 
            // activityConfig
            // 
            this.activityConfig.DataSetName = "ActivityConfig";
            this.activityConfig.EnforceConstraints = false;
            this.activityConfig.Locale = new System.Globalization.CultureInfo("en-US");
            this.activityConfig.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.AutoScroll = true;
            this.uiGroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox4.Controls.Add(this.editBox1);
            this.uiGroupBox4.Controls.Add(this.label4);
            this.uiGroupBox4.Controls.Add(this.mccRole);
            this.uiGroupBox4.Controls.Add(this.label3);
            this.uiGroupBox4.Controls.Add(this.mccSeries);
            this.uiGroupBox4.Controls.Add(this.label2);
            this.uiGroupBox4.Controls.Add(this.label1);
            this.uiGroupBox4.Controls.Add(this.suffixComboBox);
            this.uiGroupBox4.Controls.Add(this.officeCodeComboBox);
            this.uiGroupBox4.Controls.Add(this.idLabel);
            this.uiGroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiGroupBox4.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox4.Location = new System.Drawing.Point(8, 459);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Size = new System.Drawing.Size(1204, 160);
            this.uiGroupBox4.TabIndex = 25;
            this.uiGroupBox4.Text = "Office Mandate";
            this.uiGroupBox4.UseThemes = false;
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.SystemColors.Control;
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.officeMandateBindingSource, "Id", true));
            this.editBox1.Location = new System.Drawing.Point(133, 20);
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.Size = new System.Drawing.Size(78, 21);
            this.editBox1.TabIndex = 26;
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // mccRole
            // 
            this.mccRole.BackColor = System.Drawing.Color.Transparent;
            this.mccRole.Column1 = "RoleCode";
            this.mccRole.Column2 = "SeriesDescEng";
            this.mccRole.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccRole.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeMandateBindingSource, "ACSeriesId", true));
            this.mccRole.DataSource = null;
            this.mccRole.DisplayMember = "RoleCode";
            this.mccRole.DisplayNameColumn1 = "Activity";
            this.mccRole.DisplayNameColumn2 = "Description";
            this.mccRole.DropDownColumn1Width = 100;
            this.mccRole.DropDownColumn2Width = 300;
            this.mccRole.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mccRole.Location = new System.Drawing.Point(133, 128);
            this.mccRole.Middle = 81;
            this.mccRole.Name = "mccRole";
            this.mccRole.ReadOnly = true;
            this.mccRole.ReqColor = System.Drawing.SystemColors.Control;
            this.mccRole.SelectedValue = null;
            this.mccRole.Size = new System.Drawing.Size(78, 21);
            this.mccRole.TabIndex = 24;
            this.mccRole.ValueMember = "ACSeriesId";
            // 
            // mccSeries
            // 
            this.mccSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mccSeries.BackColor = System.Drawing.Color.Transparent;
            this.mccSeries.Column1 = "SeriesCode";
            this.mccSeries.Column2 = "SeriesDescEng";
            this.mccSeries.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccSeries.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeMandateBindingSource, "ACSeriesId", true));
            this.mccSeries.DataSource = null;
            this.mccSeries.DisplayMember = "SeriesCode";
            this.mccSeries.DisplayNameColumn1 = "Code";
            this.mccSeries.DisplayNameColumn2 = "Description";
            this.mccSeries.DropDownColumn1Width = 100;
            this.mccSeries.DropDownColumn2Width = 300;
            this.mccSeries.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mccSeries.Location = new System.Drawing.Point(133, 101);
            this.mccSeries.Middle = 95;
            this.mccSeries.Name = "mccSeries";
            this.mccSeries.ReadOnly = true;
            this.mccSeries.ReqColor = System.Drawing.SystemColors.Control;
            this.mccSeries.SelectedValue = null;
            this.mccSeries.Size = new System.Drawing.Size(1058, 21);
            this.mccSeries.TabIndex = 22;
            this.mccSeries.ValueMember = "ACSeriesId";
            // 
            // suffixComboBox
            // 
            this.suffixComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suffixComboBox.BackColor = System.Drawing.Color.Transparent;
            this.suffixComboBox.Column1 = "StepCode";
            this.suffixComboBox.Column2 = "ActivityNameEng";
            this.suffixComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.suffixComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeMandateBindingSource, "ACSeriesId", true));
            this.suffixComboBox.DataSource = null;
            this.suffixComboBox.DisplayMember = "StepCode";
            this.suffixComboBox.DisplayNameColumn1 = "Code";
            this.suffixComboBox.DisplayNameColumn2 = "Description";
            this.suffixComboBox.DropDownColumn1Width = 100;
            this.suffixComboBox.DropDownColumn2Width = 300;
            this.suffixComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.suffixComboBox.Location = new System.Drawing.Point(133, 74);
            this.suffixComboBox.Middle = 95;
            this.suffixComboBox.Name = "suffixComboBox";
            this.suffixComboBox.ReadOnly = false;
            this.suffixComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.suffixComboBox.SelectedValue = null;
            this.suffixComboBox.Size = new System.Drawing.Size(1058, 21);
            this.suffixComboBox.TabIndex = 19;
            this.suffixComboBox.ValueMember = "ACSeriesId";
            // 
            // officeCodeComboBox
            // 
            this.officeCodeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.officeCodeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.officeCodeComboBox.Column1 = "OfficeCode";
            this.officeCodeComboBox.Column2 = "OfficeName";
            this.officeCodeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.officeCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.officeMandateBindingSource, "OfficeId", true));
            this.officeCodeComboBox.DataSource = null;
            this.officeCodeComboBox.DisplayMember = "OfficeCode";
            this.officeCodeComboBox.DisplayNameColumn1 = "Office Code";
            this.officeCodeComboBox.DisplayNameColumn2 = "Office Name";
            this.officeCodeComboBox.DropDownColumn1Width = 100;
            this.officeCodeComboBox.DropDownColumn2Width = 300;
            this.officeCodeComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.officeCodeComboBox.Location = new System.Drawing.Point(133, 47);
            this.officeCodeComboBox.Middle = 95;
            this.officeCodeComboBox.Name = "officeCodeComboBox";
            this.officeCodeComboBox.ReadOnly = false;
            this.officeCodeComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.officeCodeComboBox.SelectedValue = null;
            this.officeCodeComboBox.Size = new System.Drawing.Size(1058, 21);
            this.officeCodeComboBox.TabIndex = 18;
            this.officeCodeComboBox.ValueMember = "OfficeId";
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
            this.uiCommandManager1.Id = new System.Guid("f0bd3234-1b95-44c2-87e8-a2a5ba9aecc5");
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
            this.uiCommandBar1.Size = new System.Drawing.Size(1226, 28);
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
            this.TopRebar1.Size = new System.Drawing.Size(1226, 28);
            // 
            // fOfficeMandate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1226, 661);
            this.Controls.Add(this.pnlMandate);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fOfficeMandate";
            this.Text = "Office Mandate";
            this.Load += new System.EventHandler(this.fOfficeMandate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMandate)).EndInit();
            this.pnlMandate.ResumeLayout(false);
            this.pnlMandateContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeMandateGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeMandateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).EndInit();
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox4.PerformLayout();
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
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.Dock.UIPanel pnlMandate;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlMandateContainer;
        private System.Windows.Forms.BindingSource officeMandateBindingSource;
        private lmDatasets.ActivityConfig activityConfig;
        private Janus.Windows.GridEX.GridEX officeMandateGridEX;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox4;
        private UserControls.ucMultiDropDown suffixComboBox;
        private UserControls.ucMultiDropDown officeCodeComboBox;
        private UserControls.ucMultiDropDown mccSeries;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private UserControls.ucMultiDropDown mccRole;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
