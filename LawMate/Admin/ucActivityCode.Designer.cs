 namespace LawMate.Admin
{
    partial class ucActivityCode
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
            System.Windows.Forms.Label activityCodeLabel;
            System.Windows.Forms.Label aCMajorCodeLabel;
            System.Windows.Forms.Label activityNameEngLabel;
            System.Windows.Forms.Label activityNameFreLabel;
            System.Windows.Forms.Label associatedObjectLabel;
            System.Windows.Forms.Label associatedFieldLabel;
            System.Windows.Forms.Label lblTemplateUsed;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucActivityCode));
            Janus.Windows.GridEX.GridEXLayout multiColumnCombo1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlActivityCodeDetail = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityCodeDetailContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.activityCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activityConfig = new lmDatasets.ActivityConfig();
            this.ebDescFreCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ebDescPTFreCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ebDescPTEngCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ebDescEngCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.communicationUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.DescPastTenseFre = new Janus.Windows.GridEX.EditControls.EditBox();
            this.DescPastTenseEng = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cbAssociatedField = new Janus.Windows.EditControls.UIComboBox();
            this.cbAssociatedObject = new Janus.Windows.EditControls.UIComboBox();
            this.ebActivityNameFre = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebActivityNameEng = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebActivityCode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lbSeriesUsingAC = new System.Windows.Forms.ListBox();
            this.multiColumnCombo1 = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.numericEditBox1 = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            activityCodeLabel = new System.Windows.Forms.Label();
            aCMajorCodeLabel = new System.Windows.Forms.Label();
            activityNameEngLabel = new System.Windows.Forms.Label();
            activityNameFreLabel = new System.Windows.Forms.Label();
            associatedObjectLabel = new System.Windows.Forms.Label();
            associatedFieldLabel = new System.Windows.Forms.Label();
            lblTemplateUsed = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetail)).BeginInit();
            this.pnlActivityCodeDetail.SuspendLayout();
            this.pnlActivityCodeDetailContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnCombo1)).BeginInit();
            this.SuspendLayout();
            // 
            // activityCodeLabel
            // 
            activityCodeLabel.AutoSize = true;
            activityCodeLabel.BackColor = System.Drawing.Color.Transparent;
            activityCodeLabel.Location = new System.Drawing.Point(13, 10);
            activityCodeLabel.Name = "activityCodeLabel";
            activityCodeLabel.Size = new System.Drawing.Size(83, 13);
            activityCodeLabel.TabIndex = 0;
            activityCodeLabel.Text = "Template Code:";
            // 
            // aCMajorCodeLabel
            // 
            aCMajorCodeLabel.AutoSize = true;
            aCMajorCodeLabel.BackColor = System.Drawing.Color.Transparent;
            aCMajorCodeLabel.Location = new System.Drawing.Point(13, 38);
            aCMajorCodeLabel.Name = "aCMajorCodeLabel";
            aCMajorCodeLabel.Size = new System.Drawing.Size(66, 13);
            aCMajorCodeLabel.TabIndex = 3;
            aCMajorCodeLabel.Text = "Major Code:";
            // 
            // activityNameEngLabel
            // 
            activityNameEngLabel.AutoSize = true;
            activityNameEngLabel.BackColor = System.Drawing.Color.Transparent;
            activityNameEngLabel.Location = new System.Drawing.Point(13, 76);
            activityNameEngLabel.Name = "activityNameEngLabel";
            activityNameEngLabel.Size = new System.Drawing.Size(133, 13);
            activityNameEngLabel.TabIndex = 5;
            activityNameEngLabel.Text = "Present Description (Eng):";
            // 
            // activityNameFreLabel
            // 
            activityNameFreLabel.AutoSize = true;
            activityNameFreLabel.BackColor = System.Drawing.Color.Transparent;
            activityNameFreLabel.Location = new System.Drawing.Point(13, 183);
            activityNameFreLabel.Name = "activityNameFreLabel";
            activityNameFreLabel.Size = new System.Drawing.Size(131, 13);
            activityNameFreLabel.TabIndex = 11;
            activityNameFreLabel.Text = "Present Description (Fre):";
            // 
            // associatedObjectLabel
            // 
            associatedObjectLabel.AutoSize = true;
            associatedObjectLabel.BackColor = System.Drawing.Color.Transparent;
            associatedObjectLabel.Location = new System.Drawing.Point(424, 10);
            associatedObjectLabel.Name = "associatedObjectLabel";
            associatedObjectLabel.Size = new System.Drawing.Size(98, 13);
            associatedObjectLabel.TabIndex = 17;
            associatedObjectLabel.Text = "Associated Object:";
            // 
            // associatedFieldLabel
            // 
            associatedFieldLabel.AutoSize = true;
            associatedFieldLabel.BackColor = System.Drawing.Color.Transparent;
            associatedFieldLabel.Location = new System.Drawing.Point(424, 37);
            associatedFieldLabel.Name = "associatedFieldLabel";
            associatedFieldLabel.Size = new System.Drawing.Size(88, 13);
            associatedFieldLabel.TabIndex = 19;
            associatedFieldLabel.Text = "Associated Field:";
            // 
            // lblTemplateUsed
            // 
            lblTemplateUsed.AutoSize = true;
            lblTemplateUsed.BackColor = System.Drawing.Color.Transparent;
            lblTemplateUsed.Location = new System.Drawing.Point(424, 67);
            lblTemplateUsed.Name = "lblTemplateUsed";
            lblTemplateUsed.Size = new System.Drawing.Size(227, 13);
            lblTemplateUsed.TabIndex = 21;
            lblTemplateUsed.Text = "Step Template is used by following workflows:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(13, 124);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(149, 13);
            label1.TabIndex = 8;
            label1.Text = "Past Tense Description (Eng):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(13, 231);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(147, 13);
            label2.TabIndex = 14;
            label2.Text = "Past Tense Description (Fre):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Location = new System.Drawing.Point(772, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 13);
            label3.TabIndex = 23;
            label3.Text = "Default hours:";
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("87adff2f-7b4a-4f28-b4c8-0f196567e62d"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(925, 308), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("87adff2f-7b4a-4f28-b4c8-0f196567e62d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlActivityCodeDetail
            // 
            this.pnlActivityCodeDetail.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.pnlActivityCodeDetail.Image = ((System.Drawing.Image)(resources.GetObject("pnlActivityCodeDetail.Image")));
            this.pnlActivityCodeDetail.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlActivityCodeDetail.InnerContainer = this.pnlActivityCodeDetailContainer;
            this.pnlActivityCodeDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlActivityCodeDetail.Name = "pnlActivityCodeDetail";
            this.pnlActivityCodeDetail.Size = new System.Drawing.Size(925, 308);
            this.pnlActivityCodeDetail.TabIndex = 4;
            this.pnlActivityCodeDetail.Text = "Step Template Details";
            // 
            // pnlActivityCodeDetailContainer
            // 
            this.pnlActivityCodeDetailContainer.AutoScroll = true;
            this.pnlActivityCodeDetailContainer.Controls.Add(this.numericEditBox1);
            this.pnlActivityCodeDetailContainer.Controls.Add(label3);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebDescFreCounter);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebDescPTFreCounter);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebDescPTEngCounter);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebDescEngCounter);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.communicationUICheckBox);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.DescPastTenseFre);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.DescPastTenseEng);
            this.pnlActivityCodeDetailContainer.Controls.Add(label1);
            this.pnlActivityCodeDetailContainer.Controls.Add(label2);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.cbAssociatedField);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.cbAssociatedObject);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebActivityNameFre);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebActivityNameEng);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.ebActivityCode);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.lbSeriesUsingAC);
            this.pnlActivityCodeDetailContainer.Controls.Add(lblTemplateUsed);
            this.pnlActivityCodeDetailContainer.Controls.Add(this.multiColumnCombo1);
            this.pnlActivityCodeDetailContainer.Controls.Add(activityCodeLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(aCMajorCodeLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(activityNameEngLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(activityNameFreLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(associatedObjectLabel);
            this.pnlActivityCodeDetailContainer.Controls.Add(associatedFieldLabel);
            this.pnlActivityCodeDetailContainer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "ACMajorCode", true));
            this.pnlActivityCodeDetailContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlActivityCodeDetailContainer.Name = "pnlActivityCodeDetailContainer";
            this.pnlActivityCodeDetailContainer.Size = new System.Drawing.Size(923, 284);
            this.pnlActivityCodeDetailContainer.TabIndex = 0;
            // 
            // activityCodeBindingSource
            // 
            this.activityCodeBindingSource.DataMember = "ActivityCode";
            this.activityCodeBindingSource.DataSource = this.activityConfig;
            // 
            // activityConfig
            // 
            this.activityConfig.DataSetName = "ActivityConfig";
            this.activityConfig.EnforceConstraints = false;
            this.activityConfig.Locale = new System.Globalization.CultureInfo("en-US");
            this.activityConfig.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // ebDescFreCounter
            // 
            this.ebDescFreCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ebDescFreCounter.DecimalDigits = 0;
            this.ebDescFreCounter.Font = new System.Drawing.Font("Tahoma", 7F);
            this.ebDescFreCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ebDescFreCounter.Location = new System.Drawing.Point(358, 203);
            this.ebDescFreCounter.MaxLength = 3;
            this.ebDescFreCounter.Name = "ebDescFreCounter";
            this.ebDescFreCounter.ReadOnly = true;
            this.ebDescFreCounter.Size = new System.Drawing.Size(29, 19);
            this.ebDescFreCounter.TabIndex = 13;
            this.ebDescFreCounter.TabStop = false;
            this.ebDescFreCounter.Text = "200";
            this.ebDescFreCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ebDescFreCounter.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ebDescFreCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebDescPTFreCounter
            // 
            this.ebDescPTFreCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ebDescPTFreCounter.DecimalDigits = 0;
            this.ebDescPTFreCounter.Font = new System.Drawing.Font("Tahoma", 7F);
            this.ebDescPTFreCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ebDescPTFreCounter.Location = new System.Drawing.Point(358, 251);
            this.ebDescPTFreCounter.MaxLength = 3;
            this.ebDescPTFreCounter.Name = "ebDescPTFreCounter";
            this.ebDescPTFreCounter.ReadOnly = true;
            this.ebDescPTFreCounter.Size = new System.Drawing.Size(29, 19);
            this.ebDescPTFreCounter.TabIndex = 16;
            this.ebDescPTFreCounter.TabStop = false;
            this.ebDescPTFreCounter.Text = "255";
            this.ebDescPTFreCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ebDescPTFreCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ebDescPTFreCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebDescPTEngCounter
            // 
            this.ebDescPTEngCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ebDescPTEngCounter.DecimalDigits = 0;
            this.ebDescPTEngCounter.Font = new System.Drawing.Font("Tahoma", 7F);
            this.ebDescPTEngCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ebDescPTEngCounter.Location = new System.Drawing.Point(358, 144);
            this.ebDescPTEngCounter.MaxLength = 3;
            this.ebDescPTEngCounter.Name = "ebDescPTEngCounter";
            this.ebDescPTEngCounter.ReadOnly = true;
            this.ebDescPTEngCounter.Size = new System.Drawing.Size(29, 19);
            this.ebDescPTEngCounter.TabIndex = 10;
            this.ebDescPTEngCounter.TabStop = false;
            this.ebDescPTEngCounter.Text = "255";
            this.ebDescPTEngCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ebDescPTEngCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ebDescPTEngCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebDescEngCounter
            // 
            this.ebDescEngCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ebDescEngCounter.DecimalDigits = 0;
            this.ebDescEngCounter.Font = new System.Drawing.Font("Tahoma", 7F);
            this.ebDescEngCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ebDescEngCounter.Location = new System.Drawing.Point(358, 96);
            this.ebDescEngCounter.MaxLength = 3;
            this.ebDescEngCounter.Name = "ebDescEngCounter";
            this.ebDescEngCounter.ReadOnly = true;
            this.ebDescEngCounter.Size = new System.Drawing.Size(29, 19);
            this.ebDescEngCounter.TabIndex = 7;
            this.ebDescEngCounter.TabStop = false;
            this.ebDescEngCounter.Text = "200";
            this.ebDescEngCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ebDescEngCounter.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ebDescEngCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // communicationUICheckBox
            // 
            this.communicationUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.communicationUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.communicationUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityCodeBindingSource, "Communication", true));
            this.communicationUICheckBox.Image = global::LawMate.Properties.Resources.mail;
            this.communicationUICheckBox.Location = new System.Drawing.Point(253, 8);
            this.communicationUICheckBox.Name = "communicationUICheckBox";
            this.communicationUICheckBox.Size = new System.Drawing.Size(134, 16);
            this.communicationUICheckBox.TabIndex = 2;
            this.communicationUICheckBox.Text = "Activity is an e-mail:";
            // 
            // DescPastTenseFre
            // 
            this.DescPastTenseFre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "ActivityNamePastTenseFre", true));
            this.DescPastTenseFre.Location = new System.Drawing.Point(163, 228);
            this.DescPastTenseFre.Multiline = true;
            this.DescPastTenseFre.Name = "DescPastTenseFre";
            this.DescPastTenseFre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescPastTenseFre.Size = new System.Drawing.Size(196, 42);
            this.DescPastTenseFre.TabIndex = 15;
            this.DescPastTenseFre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.DescPastTenseFre.TextChanged += new System.EventHandler(this.ebActivityNameEng_TextChanged);
            // 
            // DescPastTenseEng
            // 
            this.DescPastTenseEng.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "ActivityNamePastTenseEng", true));
            this.DescPastTenseEng.Location = new System.Drawing.Point(163, 121);
            this.DescPastTenseEng.Multiline = true;
            this.DescPastTenseEng.Name = "DescPastTenseEng";
            this.DescPastTenseEng.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescPastTenseEng.Size = new System.Drawing.Size(196, 42);
            this.DescPastTenseEng.TabIndex = 9;
            this.DescPastTenseEng.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.DescPastTenseEng.TextChanged += new System.EventHandler(this.ebActivityNameEng_TextChanged);
            // 
            // cbAssociatedField
            // 
            this.cbAssociatedField.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "AssociatedField", true));
            this.cbAssociatedField.Location = new System.Drawing.Point(568, 34);
            this.cbAssociatedField.Name = "cbAssociatedField";
            this.cbAssociatedField.Size = new System.Drawing.Size(224, 21);
            this.cbAssociatedField.TabIndex = 20;
            this.cbAssociatedField.Text = "uiComboBox1";
            this.cbAssociatedField.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // cbAssociatedObject
            // 
            this.cbAssociatedObject.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "AssociatedObject", true));
            this.cbAssociatedObject.Location = new System.Drawing.Point(568, 7);
            this.cbAssociatedObject.Name = "cbAssociatedObject";
            this.cbAssociatedObject.Size = new System.Drawing.Size(224, 21);
            this.cbAssociatedObject.TabIndex = 18;
            this.cbAssociatedObject.Text = "uiComboBox1";
            this.cbAssociatedObject.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.cbAssociatedObject.SelectedIndexChanged += new System.EventHandler(this.associatedObjectCB_SelectedIndexChanged);
            // 
            // ebActivityNameFre
            // 
            this.ebActivityNameFre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "ActivityNameFre", true));
            this.ebActivityNameFre.Location = new System.Drawing.Point(163, 180);
            this.ebActivityNameFre.Multiline = true;
            this.ebActivityNameFre.Name = "ebActivityNameFre";
            this.ebActivityNameFre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ebActivityNameFre.Size = new System.Drawing.Size(196, 42);
            this.ebActivityNameFre.TabIndex = 12;
            this.ebActivityNameFre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebActivityNameFre.TextChanged += new System.EventHandler(this.ebActivityNameEng_TextChanged);
            // 
            // ebActivityNameEng
            // 
            this.ebActivityNameEng.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "ActivityNameEng", true));
            this.ebActivityNameEng.Location = new System.Drawing.Point(163, 73);
            this.ebActivityNameEng.Multiline = true;
            this.ebActivityNameEng.Name = "ebActivityNameEng";
            this.ebActivityNameEng.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ebActivityNameEng.Size = new System.Drawing.Size(196, 42);
            this.ebActivityNameEng.TabIndex = 6;
            this.ebActivityNameEng.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebActivityNameEng.TextChanged += new System.EventHandler(this.ebActivityNameEng_TextChanged);
            // 
            // ebActivityCode
            // 
            this.ebActivityCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "ActivityCode", true));
            this.ebActivityCode.Location = new System.Drawing.Point(163, 7);
            this.ebActivityCode.Name = "ebActivityCode";
            this.ebActivityCode.Size = new System.Drawing.Size(69, 21);
            this.ebActivityCode.TabIndex = 1;
            this.ebActivityCode.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lbSeriesUsingAC
            // 
            this.lbSeriesUsingAC.FormattingEnabled = true;
            this.lbSeriesUsingAC.Location = new System.Drawing.Point(427, 84);
            this.lbSeriesUsingAC.Name = "lbSeriesUsingAC";
            this.lbSeriesUsingAC.Size = new System.Drawing.Size(475, 186);
            this.lbSeriesUsingAC.TabIndex = 22;
            // 
            // multiColumnCombo1
            // 
            this.multiColumnCombo1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.activityCodeBindingSource, "ACMajorCode", true));
            this.multiColumnCombo1.DataMember = "ACMajor";
            this.multiColumnCombo1.DataSource = this.activityConfig;
            multiColumnCombo1_DesignTimeLayout.LayoutString = resources.GetString("multiColumnCombo1_DesignTimeLayout.LayoutString");
            this.multiColumnCombo1.DesignTimeLayout = multiColumnCombo1_DesignTimeLayout;
            this.multiColumnCombo1.DisplayMember = "ACMajorDescEng";
            this.multiColumnCombo1.Location = new System.Drawing.Point(163, 34);
            this.multiColumnCombo1.Name = "multiColumnCombo1";
            this.multiColumnCombo1.SelectedIndex = -1;
            this.multiColumnCombo1.SelectedItem = null;
            this.multiColumnCombo1.Size = new System.Drawing.Size(224, 21);
            this.multiColumnCombo1.TabIndex = 4;
            this.multiColumnCombo1.ValueMember = "ActivityCodeMajor";
            this.multiColumnCombo1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // numericEditBox1
            // 
            this.numericEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityCodeBindingSource, "DefaultHours", true));
            this.numericEditBox1.DecimalDigits = 1;
            this.numericEditBox1.Location = new System.Drawing.Point(854, 59);
            this.numericEditBox1.Name = "numericEditBox1";
            this.numericEditBox1.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
            this.numericEditBox1.Size = new System.Drawing.Size(48, 21);
            this.numericEditBox1.TabIndex = 25;
            this.numericEditBox1.Text = "0.0";
            this.numericEditBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucActivityCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlActivityCodeDetail);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ucActivityCode";
            this.Size = new System.Drawing.Size(925, 308);
            this.Load += new System.EventHandler(this.ucActivityCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetail)).EndInit();
            this.pnlActivityCodeDetail.ResumeLayout(false);
            this.pnlActivityCodeDetailContainer.ResumeLayout(false);
            this.pnlActivityCodeDetailContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnCombo1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlActivityCodeDetail;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityCodeDetailContainer;
        private System.Windows.Forms.BindingSource activityCodeBindingSource;
        private lmDatasets.ActivityConfig activityConfig;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo multiColumnCombo1;
        private System.Windows.Forms.ListBox lbSeriesUsingAC;
        private Janus.Windows.EditControls.UIComboBox cbAssociatedObject;
        private Janus.Windows.GridEX.EditControls.EditBox ebActivityNameFre;
        private Janus.Windows.GridEX.EditControls.EditBox ebActivityNameEng;
        private Janus.Windows.GridEX.EditControls.EditBox ebActivityCode;
        private Janus.Windows.EditControls.UIComboBox cbAssociatedField;
        private Janus.Windows.EditControls.UICheckBox communicationUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox DescPastTenseFre;
        private Janus.Windows.GridEX.EditControls.EditBox DescPastTenseEng;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ebDescEngCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ebDescFreCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ebDescPTFreCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ebDescPTEngCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numericEditBox1;
    }
}
