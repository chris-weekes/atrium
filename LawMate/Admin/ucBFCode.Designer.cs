 namespace LawMate.Admin
{
    partial class ucBFCode
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
            System.Windows.Forms.Label bFTypeLabel;
            System.Windows.Forms.Label bFCodeLabel;
            System.Windows.Forms.Label bFDateLabel;
            System.Windows.Forms.Label bFDescriptionEngLabel;
            System.Windows.Forms.Label bFDescriptionFreLabel;
            System.Windows.Forms.Label roleCodeLabel;
            System.Windows.Forms.Label lblTemplateUsed;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBFCode));
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX1_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX1_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlActivityCodeDetail = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityCodeDetailContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucMultiDropDown2 = new LawMate.UserControls.ucMultiDropDown();
            this.aCBFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activityConfig = new lmDatasets.ActivityConfig();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.chkObsolete = new Janus.Windows.EditControls.UICheckBox();
            this.chkReadOnly = new Janus.Windows.EditControls.UICheckBox();
            this.chkMonitorIncomplete = new Janus.Windows.EditControls.UICheckBox();
            this.chkIsMail = new Janus.Windows.EditControls.UICheckBox();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebBFDescEng = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebBFDate = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebBFCode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.ucMultiDropDown3 = new LawMate.UserControls.ucMultiDropDown();
            bFTypeLabel = new System.Windows.Forms.Label();
            bFCodeLabel = new System.Windows.Forms.Label();
            bFDateLabel = new System.Windows.Forms.Label();
            bFDescriptionEngLabel = new System.Windows.Forms.Label();
            bFDescriptionFreLabel = new System.Windows.Forms.Label();
            roleCodeLabel = new System.Windows.Forms.Label();
            lblTemplateUsed = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetail)).BeginInit();
            this.pnlActivityCodeDetail.SuspendLayout();
            this.pnlActivityCodeDetailContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCBFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // bFTypeLabel
            // 
            bFTypeLabel.AutoSize = true;
            bFTypeLabel.BackColor = System.Drawing.Color.Transparent;
            bFTypeLabel.Location = new System.Drawing.Point(3, 36);
            bFTypeLabel.Name = "bFTypeLabel";
            bFTypeLabel.Size = new System.Drawing.Size(50, 13);
            bFTypeLabel.TabIndex = 4;
            bFTypeLabel.Text = "BF Type:";
            // 
            // bFCodeLabel
            // 
            bFCodeLabel.AutoSize = true;
            bFCodeLabel.BackColor = System.Drawing.Color.Transparent;
            bFCodeLabel.Location = new System.Drawing.Point(3, 10);
            bFCodeLabel.Name = "bFCodeLabel";
            bFCodeLabel.Size = new System.Drawing.Size(51, 13);
            bFCodeLabel.TabIndex = 0;
            bFCodeLabel.Text = "BF Code:";
            // 
            // bFDateLabel
            // 
            bFDateLabel.AutoSize = true;
            bFDateLabel.BackColor = System.Drawing.Color.Transparent;
            bFDateLabel.Location = new System.Drawing.Point(228, 10);
            bFDateLabel.Name = "bFDateLabel";
            bFDateLabel.Size = new System.Drawing.Size(49, 13);
            bFDateLabel.TabIndex = 2;
            bFDateLabel.Text = "BF Date:";
            // 
            // bFDescriptionEngLabel
            // 
            bFDescriptionEngLabel.AutoSize = true;
            bFDescriptionEngLabel.BackColor = System.Drawing.Color.Transparent;
            bFDescriptionEngLabel.Location = new System.Drawing.Point(3, 116);
            bFDescriptionEngLabel.Name = "bFDescriptionEngLabel";
            bFDescriptionEngLabel.Size = new System.Drawing.Size(108, 13);
            bFDescriptionEngLabel.TabIndex = 10;
            bFDescriptionEngLabel.Text = "BF Description (Eng):";
            // 
            // bFDescriptionFreLabel
            // 
            bFDescriptionFreLabel.AutoSize = true;
            bFDescriptionFreLabel.BackColor = System.Drawing.Color.Transparent;
            bFDescriptionFreLabel.Location = new System.Drawing.Point(3, 156);
            bFDescriptionFreLabel.Name = "bFDescriptionFreLabel";
            bFDescriptionFreLabel.Size = new System.Drawing.Size(106, 13);
            bFDescriptionFreLabel.TabIndex = 12;
            bFDescriptionFreLabel.Text = "BF Description (Fre):";
            // 
            // roleCodeLabel
            // 
            roleCodeLabel.AutoSize = true;
            roleCodeLabel.BackColor = System.Drawing.Color.Transparent;
            roleCodeLabel.Location = new System.Drawing.Point(3, 62);
            roleCodeLabel.Name = "roleCodeLabel";
            roleCodeLabel.Size = new System.Drawing.Size(103, 13);
            roleCodeLabel.TabIndex = 6;
            roleCodeLabel.Text = "Role Code (Owner):";
            // 
            // lblTemplateUsed
            // 
            lblTemplateUsed.BackColor = System.Drawing.Color.SteelBlue;
            lblTemplateUsed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            lblTemplateUsed.ForeColor = System.Drawing.Color.White;
            lblTemplateUsed.Location = new System.Drawing.Point(3, 309);
            lblTemplateUsed.Name = "lblTemplateUsed";
            lblTemplateUsed.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            lblTemplateUsed.Size = new System.Drawing.Size(376, 18);
            lblTemplateUsed.TabIndex = 19;
            lblTemplateUsed.Text = "BF is used by following Workflow Steps:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(3, 89);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 13);
            label1.TabIndex = 8;
            label1.Text = "Role Code (Lead):";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.PanelPadding.Bottom = 0;
            this.uiPanelManager1.PanelPadding.Left = 0;
            this.uiPanelManager1.PanelPadding.Right = 0;
            this.uiPanelManager1.PanelPadding.Top = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlActivityCodeDetail.Id = new System.Guid("87adff2f-7b4a-4f28-b4c8-0f196567e62d");
            this.uiPanelManager1.Panels.Add(this.pnlActivityCodeDetail);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("87adff2f-7b4a-4f28-b4c8-0f196567e62d"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(386, 605), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("87adff2f-7b4a-4f28-b4c8-0f196567e62d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlActivityCodeDetail
            // 
            this.pnlActivityCodeDetail.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.pnlActivityCodeDetail.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivityCodeDetail.Image = ((System.Drawing.Image)(resources.GetObject("pnlActivityCodeDetail.Image")));
            this.pnlActivityCodeDetail.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlActivityCodeDetail.InnerContainer = this.pnlActivityCodeDetailContainer;
            this.pnlActivityCodeDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlActivityCodeDetail.Name = "pnlActivityCodeDetail";
            this.pnlActivityCodeDetail.Size = new System.Drawing.Size(386, 605);
            this.pnlActivityCodeDetail.TabIndex = 0;
            this.pnlActivityCodeDetail.Text = "Selected BF Template";
            // 
            // pnlActivityCodeDetailContainer
            // 
            this.pnlActivityCodeDetailContainer.AutoScroll = true;
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ucMultiDropDown2);
            this.pnlActivityCodeDetailContainer.Controls.Add(label1);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.uiCheckBox1);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.gridEX1);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.chkObsolete);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.chkReadOnly);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.chkMonitorIncomplete);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.chkIsMail);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.editBox1);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebBFDescEng);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebBFDate);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebBFCode);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ucMultiDropDown1);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ucMultiDropDown3);
            this.pnlActivityCodeDetailContainer.Controls.Add(lblTemplateUsed);
            this.pnlActivityCodeDetailContainer.Controls.Add(bFTypeLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(bFCodeLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(bFDateLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(bFDescriptionEngLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(bFDescriptionFreLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(roleCodeLabel);
            this.pnlActivityCodeDetailContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlActivityCodeDetailContainer.Name = "pnlActivityCodeDetailContainer";
            this.pnlActivityCodeDetailContainer.Size = new System.Drawing.Size(384, 603);
            this.pnlActivityCodeDetailContainer.TabIndex = 0;
            // 
            // ucMultiDropDown2
            // 
            this.ucMultiDropDown2.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown2.Column1 = "RoleCode";
            this.ucMultiDropDown2.Column2 = "RoleEng";
            this.ucMultiDropDown2.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aCBFBindingSource, "RoleCodeLead", true));
            this.ucMultiDropDown2.DataSource = null;
            this.ucMultiDropDown2.DDColumn1Visible = true;
            this.ucMultiDropDown2.DisplayMember = "RoleEng";
            this.ucMultiDropDown2.DisplayNameColumn1 = "Code";
            this.ucMultiDropDown2.DisplayNameColumn2 = "Description";
            this.ucMultiDropDown2.DropDownColumn1Width = 100;
            this.ucMultiDropDown2.DropDownColumn2Width = 300;
            this.ucMultiDropDown2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucMultiDropDown2.Location = new System.Drawing.Point(117, 86);
            this.ucMultiDropDown2.Middle = 265;
            this.ucMultiDropDown2.Name = "ucMultiDropDown2";
            this.ucMultiDropDown2.ReadOnly = false;
            this.ucMultiDropDown2.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown2.SelectedValue = null;
            this.ucMultiDropDown2.Size = new System.Drawing.Size(262, 21);
            this.ucMultiDropDown2.TabIndex = 9;
            this.ucMultiDropDown2.ValueMember = "RoleCode";
            // 
            // aCBFBindingSource
            // 
            this.aCBFBindingSource.DataMember = "ACBF";
            this.aCBFBindingSource.DataSource = this.activityConfig;
            // 
            // activityConfig
            // 
            this.activityConfig.DataSetName = "ActivityConfig";
            this.activityConfig.EnforceConstraints = false;
            this.activityConfig.Locale = new System.Globalization.CultureInfo("en-US");
            this.activityConfig.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.aCBFBindingSource, "AllowManualComplete", true));
            this.uiCheckBox1.Location = new System.Drawing.Point(3, 252);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Size = new System.Drawing.Size(129, 23);
            this.uiCheckBox1.TabIndex = 16;
            this.uiCheckBox1.Text = "Allow Manual Complete:";
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.AlternatingColors = true;
            this.gridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            gridEX1_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gridEX1_DesignTimeLayout_Reference_0.Instance")));
            gridEX1_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("gridEX1_DesignTimeLayout_Reference_1.Instance")));
            gridEX1_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gridEX1_DesignTimeLayout_Reference_0,
            gridEX1_DesignTimeLayout_Reference_1});
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.gridEX1.GridLines = Janus.Windows.GridEX.GridLines.RowOutline;
            this.gridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.gridEX1.Location = new System.Drawing.Point(3, 330);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.gridEX1.Size = new System.Drawing.Size(376, 270);
            this.gridEX1.TabIndex = 20;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEX1.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gridEX1_LinkClicked);
            // 
            // chkObsolete
            // 
            this.chkObsolete.BackColor = System.Drawing.Color.Transparent;
            this.chkObsolete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkObsolete.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.aCBFBindingSource, "Obsolete", true));
            this.chkObsolete.Location = new System.Drawing.Point(245, 226);
            this.chkObsolete.Name = "chkObsolete";
            this.chkObsolete.Size = new System.Drawing.Size(134, 20);
            this.chkObsolete.TabIndex = 18;
            this.chkObsolete.Text = "Obsolete:";
            this.chkObsolete.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkReadOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReadOnly.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.aCBFBindingSource, "ReadOnly", true));
            this.chkReadOnly.Location = new System.Drawing.Point(3, 226);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Size = new System.Drawing.Size(129, 20);
            this.chkReadOnly.TabIndex = 15;
            this.chkReadOnly.Text = "Read Only:";
            this.chkReadOnly.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // chkMonitorIncomplete
            // 
            this.chkMonitorIncomplete.BackColor = System.Drawing.Color.Transparent;
            this.chkMonitorIncomplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMonitorIncomplete.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.aCBFBindingSource, "MonitorIncomplete", true));
            this.chkMonitorIncomplete.Location = new System.Drawing.Point(245, 197);
            this.chkMonitorIncomplete.Name = "chkMonitorIncomplete";
            this.chkMonitorIncomplete.Size = new System.Drawing.Size(134, 23);
            this.chkMonitorIncomplete.TabIndex = 17;
            this.chkMonitorIncomplete.Text = "Skip Warning:";
            this.chkMonitorIncomplete.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // chkIsMail
            // 
            this.chkIsMail.BackColor = System.Drawing.Color.Transparent;
            this.chkIsMail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsMail.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.aCBFBindingSource, "isMail", true));
            this.chkIsMail.Enabled = false;
            this.chkIsMail.Location = new System.Drawing.Point(3, 197);
            this.chkIsMail.Name = "chkIsMail";
            this.chkIsMail.Size = new System.Drawing.Size(129, 23);
            this.chkIsMail.TabIndex = 14;
            this.chkIsMail.Text = "Mail BF (Locked):";
            this.chkIsMail.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // editBox1
            // 
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCBFBindingSource, "BFDescriptionFre", true));
            this.editBox1.Location = new System.Drawing.Point(117, 155);
            this.editBox1.Multiline = true;
            this.editBox1.Name = "editBox1";
            this.editBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.editBox1.Size = new System.Drawing.Size(262, 36);
            this.editBox1.TabIndex = 13;
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebBFDescEng
            // 
            this.ebBFDescEng.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCBFBindingSource, "BFDescriptionEng", true));
            this.ebBFDescEng.Location = new System.Drawing.Point(117, 113);
            this.ebBFDescEng.Multiline = true;
            this.ebBFDescEng.Name = "ebBFDescEng";
            this.ebBFDescEng.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ebBFDescEng.Size = new System.Drawing.Size(262, 36);
            this.ebBFDescEng.TabIndex = 11;
            this.ebBFDescEng.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebBFDate
            // 
            this.ebBFDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCBFBindingSource, "BFDate", true));
            this.ebBFDate.Location = new System.Drawing.Point(283, 5);
            this.ebBFDate.Name = "ebBFDate";
            this.ebBFDate.Size = new System.Drawing.Size(96, 21);
            this.ebBFDate.TabIndex = 3;
            this.ebBFDate.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebBFCode
            // 
            this.ebBFCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aCBFBindingSource, "BFCode", true));
            this.ebBFCode.Location = new System.Drawing.Point(117, 5);
            this.ebBFCode.Name = "ebBFCode";
            this.ebBFCode.Size = new System.Drawing.Size(63, 21);
            this.ebBFCode.TabIndex = 1;
            this.ebBFCode.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown1.Column1 = "RoleCode";
            this.ucMultiDropDown1.Column2 = "RoleEng";
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aCBFBindingSource, "RoleCode", true));
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DisplayMember = "RoleEng";
            this.ucMultiDropDown1.DisplayNameColumn1 = "Code";
            this.ucMultiDropDown1.DisplayNameColumn2 = "Description";
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucMultiDropDown1.Location = new System.Drawing.Point(117, 59);
            this.ucMultiDropDown1.Middle = 265;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = false;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown1.SelectedValue = null;
            this.ucMultiDropDown1.Size = new System.Drawing.Size(262, 21);
            this.ucMultiDropDown1.TabIndex = 7;
            this.ucMultiDropDown1.ValueMember = "RoleCode";
            // 
            // ucMultiDropDown3
            // 
            this.ucMultiDropDown3.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown3.Column1 = "BFTypeId";
            this.ucMultiDropDown3.Column2 = "BFTypeDescE";
            this.ucMultiDropDown3.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucMultiDropDown3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.aCBFBindingSource, "BFType", true));
            this.ucMultiDropDown3.DataSource = null;
            this.ucMultiDropDown3.DDColumn1Visible = true;
            this.ucMultiDropDown3.DisplayMember = "BFTypeDescE";
            this.ucMultiDropDown3.DisplayNameColumn1 = "Code";
            this.ucMultiDropDown3.DisplayNameColumn2 = "Description";
            this.ucMultiDropDown3.DropDownColumn1Width = 100;
            this.ucMultiDropDown3.DropDownColumn2Width = 300;
            this.ucMultiDropDown3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucMultiDropDown3.Location = new System.Drawing.Point(117, 32);
            this.ucMultiDropDown3.Middle = 265;
            this.ucMultiDropDown3.Name = "ucMultiDropDown3";
            this.ucMultiDropDown3.ReadOnly = false;
            this.ucMultiDropDown3.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown3.SelectedValue = null;
            this.ucMultiDropDown3.Size = new System.Drawing.Size(262, 21);
            this.ucMultiDropDown3.TabIndex = 5;
            this.ucMultiDropDown3.ValueMember = "BFTypeId";
            this.ucMultiDropDown3.ASelectedValueChanged += new System.EventHandler(this.ucMultiDropDown3_SelectedValueChanged);
            // 
            // ucBFCode
            // 
            this.Controls.Add(this.pnlActivityCodeDetail);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ucBFCode";
            this.Size = new System.Drawing.Size(386, 605);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetail)).EndInit();
            this.pnlActivityCodeDetail.ResumeLayout(false);
            this.pnlActivityCodeDetailContainer.ResumeLayout(false);
            this.pnlActivityCodeDetailContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCBFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlActivityCodeDetail;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityCodeDetailContainer;
        private System.Windows.Forms.BindingSource aCBFBindingSource;
        private lmDatasets.ActivityConfig activityConfig;
        private UserControls.ucMultiDropDown ucMultiDropDown3;
        private UserControls.ucMultiDropDown ucMultiDropDown1;
        private Janus.Windows.EditControls.UICheckBox chkObsolete;
        private Janus.Windows.EditControls.UICheckBox chkReadOnly;
        private Janus.Windows.EditControls.UICheckBox chkMonitorIncomplete;
        private Janus.Windows.EditControls.UICheckBox chkIsMail;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.GridEX.EditControls.EditBox ebBFDescEng;
        private Janus.Windows.GridEX.EditControls.EditBox ebBFDate;
        private Janus.Windows.GridEX.EditControls.EditBox ebBFCode;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
        private UserControls.ucMultiDropDown ucMultiDropDown2;
    }
}
