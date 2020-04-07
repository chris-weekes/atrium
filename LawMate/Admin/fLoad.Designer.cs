 namespace LawMate.Admin
{
    partial class fLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLoad));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ucDest = new LawMate.ucFileSelectBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkInclude = new System.Windows.Forms.CheckBox();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNewFile = new System.Windows.Forms.CheckBox();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlProcedure = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlProcedureContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.ebParentFileID = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ebStartAt = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.btnImportLotus = new Janus.Windows.EditControls.UIButton();
            this.btnImport = new Janus.Windows.EditControls.UIButton();
            this.ebImportFile = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ucMultiDropDown2 = new LawMate.UserControls.ucMultiDropDown();
            this.pnlListBox = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlListBoxContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlActivitiesList = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivitiesListContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlActivityCodeDetails = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlActivityCodeDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProcedure)).BeginInit();
            this.pnlProcedure.SuspendLayout();
            this.pnlProcedureContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlListBox)).BeginInit();
            this.pnlListBox.SuspendLayout();
            this.pnlListBoxContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivitiesList)).BeginInit();
            this.pnlActivitiesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetails)).BeginInit();
            this.pnlActivityCodeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(961, 333);
            this.listBox1.TabIndex = 1;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // ucDest
            // 
            this.ucDest.AtMng = null;
            this.ucDest.BackColor = System.Drawing.Color.Transparent;
            this.ucDest.FileId = null;
            this.ucDest.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucDest.Location = new System.Drawing.Point(123, 68);
            this.ucDest.Name = "ucDest";
            this.ucDest.ReadOnly = false;
            this.ucDest.ReqColor = System.Drawing.SystemColors.Window;
            this.ucDest.Size = new System.Drawing.Size(390, 23);
            this.ucDest.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select File to Import:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(20, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Destination:";
            // 
            // chkInclude
            // 
            this.chkInclude.AutoSize = true;
            this.chkInclude.BackColor = System.Drawing.Color.Transparent;
            this.chkInclude.Location = new System.Drawing.Point(528, 16);
            this.chkInclude.Name = "chkInclude";
            this.chkInclude.Size = new System.Drawing.Size(107, 17);
            this.chkInclude.TabIndex = 6;
            this.chkInclude.Text = "Include Sub-Files";
            this.chkInclude.UseVisualStyleBackColor = false;
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown1.Column1 = "StepCode";
            this.ucMultiDropDown1.Column2 = "DescEng";
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DisplayMember = "StepCode";
            this.ucMultiDropDown1.DisplayNameColumn1 = "Step";
            this.ucMultiDropDown1.DisplayNameColumn2 = "Desc";
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucMultiDropDown1.Location = new System.Drawing.Point(123, 125);
            this.ucMultiDropDown1.Middle = 80;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = false;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown1.SelectedValue = null;
            this.ucMultiDropDown1.Size = new System.Drawing.Size(534, 22);
            this.ucMultiDropDown1.TabIndex = 8;
            this.ucMultiDropDown1.ValueMember = "ACSeriesId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(10, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select Activity Code:";
            // 
            // chkNewFile
            // 
            this.chkNewFile.AutoSize = true;
            this.chkNewFile.BackColor = System.Drawing.Color.Transparent;
            this.chkNewFile.Location = new System.Drawing.Point(528, 71);
            this.chkNewFile.Name = "chkNewFile";
            this.chkNewFile.Size = new System.Drawing.Size(102, 17);
            this.chkNewFile.TabIndex = 11;
            this.chkNewFile.Text = "Create New File";
            this.chkNewFile.UseVisualStyleBackColor = false;
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
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlProcedure.Id = new System.Guid("93e6a0de-4b95-4aac-9fbf-07aa756ae904");
            this.uiPanelManager1.Panels.Add(this.pnlProcedure);
            this.pnlTop.Id = new System.Guid("1086cd6d-5bf6-4fc1-9891-3e9ea620dcfd");
            this.uiPanelManager1.Panels.Add(this.pnlTop);
            this.pnlListBox.Id = new System.Guid("a71e7ecf-432e-4311-8c2d-1ec68291c37d");
            this.uiPanelManager1.Panels.Add(this.pnlListBox);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("93e6a0de-4b95-4aac-9fbf-07aa756ae904"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(963, 176), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("1086cd6d-5bf6-4fc1-9891-3e9ea620dcfd"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(963, 233), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a71e7ecf-432e-4311-8c2d-1ec68291c37d"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(963, 357), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("59466cee-7156-4631-87a5-2a22fb966b6c"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e66ca4db-b710-440f-9e78-69a2449a22a1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("781514b0-d837-4426-b179-4cfa8bc6cf2b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b41e9eb9-a043-4d26-8bbe-8b54d893b734"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7dd7c9eb-ceff-439e-88c8-e8a9a19120aa"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e67541b4-db01-4943-a3d2-eca11f81f0d1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("420b2dad-9a8c-4eed-bac3-45d46e44e1cd"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("93e6a0de-4b95-4aac-9fbf-07aa756ae904"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1086cd6d-5bf6-4fc1-9891-3e9ea620dcfd"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a71e7ecf-432e-4311-8c2d-1ec68291c37d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlProcedure
            // 
            this.pnlProcedure.AutoHide = true;
            this.pnlProcedure.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlProcedure.InnerContainer = this.pnlProcedureContainer;
            this.pnlProcedure.Location = new System.Drawing.Point(3, 3);
            this.pnlProcedure.Name = "pnlProcedure";
            this.pnlProcedure.Size = new System.Drawing.Size(963, 176);
            this.pnlProcedure.TabIndex = 4;
            this.pnlProcedure.Text = "Instructions";
            // 
            // pnlProcedureContainer
            // 
            this.pnlProcedureContainer.AutoScroll = true;
            this.pnlProcedureContainer.Controls.Add(this.label3);
            this.pnlProcedureContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlProcedureContainer.Name = "pnlProcedureContainer";
            this.pnlProcedureContainer.Size = new System.Drawing.Size(961, 148);
            this.pnlProcedureContainer.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(882, 147);
            this.label3.TabIndex = 5;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // pnlTop
            // 
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            this.pnlTop.Location = new System.Drawing.Point(3, 27);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(963, 233);
            this.pnlTop.TabIndex = 4;
            this.pnlTop.Text = "Import External Data (Files & Documents)";
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.AutoScroll = true;
            this.pnlTopContainer.Controls.Add(this.uiButton2);
            this.pnlTopContainer.Controls.Add(this.label7);
            this.pnlTopContainer.Controls.Add(this.ebParentFileID);
            this.pnlTopContainer.Controls.Add(this.label6);
            this.pnlTopContainer.Controls.Add(this.ebStartAt);
            this.pnlTopContainer.Controls.Add(this.uiButton1);
            this.pnlTopContainer.Controls.Add(this.btnImportLotus);
            this.pnlTopContainer.Controls.Add(this.btnImport);
            this.pnlTopContainer.Controls.Add(this.ebImportFile);
            this.pnlTopContainer.Controls.Add(this.label5);
            this.pnlTopContainer.Controls.Add(this.ucMultiDropDown2);
            this.pnlTopContainer.Controls.Add(this.label4);
            this.pnlTopContainer.Controls.Add(this.ucMultiDropDown1);
            this.pnlTopContainer.Controls.Add(this.chkNewFile);
            this.pnlTopContainer.Controls.Add(this.label1);
            this.pnlTopContainer.Controls.Add(this.ucDest);
            this.pnlTopContainer.Controls.Add(this.label2);
            this.pnlTopContainer.Controls.Add(this.chkInclude);
            this.pnlTopContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Size = new System.Drawing.Size(961, 205);
            this.pnlTopContainer.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(391, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Parent FileID:";
            // 
            // ebParentFileID
            // 
            this.ebParentFileID.Location = new System.Drawing.Point(470, 41);
            this.ebParentFileID.Name = "ebParentFileID";
            this.ebParentFileID.Size = new System.Drawing.Size(160, 21);
            this.ebParentFileID.TabIndex = 20;
            this.ebParentFileID.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(33, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Start Import At:";
            // 
            // ebStartAt
            // 
            this.ebStartAt.Location = new System.Drawing.Point(123, 41);
            this.ebStartAt.Name = "ebStartAt";
            this.ebStartAt.Size = new System.Drawing.Size(251, 21);
            this.ebStartAt.TabIndex = 18;
            this.ebStartAt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiButton1
            // 
            this.uiButton1.Image = global::LawMate.Properties.Resources.atriumtrans16;
            this.uiButton1.Location = new System.Drawing.Point(414, 163);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(179, 23);
            this.uiButton1.TabIndex = 17;
            this.uiButton1.Text = "Lotus File Extension Pre-pass";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // btnImportLotus
            // 
            this.btnImportLotus.Image = global::LawMate.Properties.Resources.atriumtrans16;
            this.btnImportLotus.Location = new System.Drawing.Point(237, 163);
            this.btnImportLotus.Name = "btnImportLotus";
            this.btnImportLotus.Size = new System.Drawing.Size(171, 23);
            this.btnImportLotus.TabIndex = 16;
            this.btnImportLotus.Text = "Import to Atrium (from Lotus)";
            this.btnImportLotus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnImportLotus.Click += new System.EventHandler(this.btnImportLotus_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = global::LawMate.Properties.Resources.atriumtrans16;
            this.btnImport.Location = new System.Drawing.Point(123, 163);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(108, 23);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "Import to Atrium";
            this.btnImport.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ebImportFile
            // 
            this.ebImportFile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ebImportFile.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis;
            this.ebImportFile.Location = new System.Drawing.Point(123, 14);
            this.ebImportFile.Name = "ebImportFile";
            this.ebImportFile.ReadOnly = true;
            this.ebImportFile.Size = new System.Drawing.Size(390, 21);
            this.ebImportFile.TabIndex = 14;
            this.ebImportFile.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebImportFile.ButtonClick += new System.EventHandler(this.ebImportFile_ButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(31, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Select File Type:";
            // 
            // ucMultiDropDown2
            // 
            this.ucMultiDropDown2.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown2.Column1 = "FileTypeCode";
            this.ucMultiDropDown2.Column2 = "FileTypeDescEng";
            this.ucMultiDropDown2.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown2.DataSource = null;
            this.ucMultiDropDown2.DDColumn1Visible = true;
            this.ucMultiDropDown2.DisplayMember = "FileTypeDescEng";
            this.ucMultiDropDown2.DisplayNameColumn1 = "Code";
            this.ucMultiDropDown2.DisplayNameColumn2 = "Description";
            this.ucMultiDropDown2.DropDownColumn1Width = 100;
            this.ucMultiDropDown2.DropDownColumn2Width = 300;
            this.ucMultiDropDown2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucMultiDropDown2.Location = new System.Drawing.Point(123, 97);
            this.ucMultiDropDown2.Middle = 393;
            this.ucMultiDropDown2.Name = "ucMultiDropDown2";
            this.ucMultiDropDown2.ReadOnly = false;
            this.ucMultiDropDown2.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown2.SelectedValue = null;
            this.ucMultiDropDown2.Size = new System.Drawing.Size(390, 22);
            this.ucMultiDropDown2.TabIndex = 12;
            this.ucMultiDropDown2.ValueMember = "FileTypeCode";
            // 
            // pnlListBox
            // 
            this.pnlListBox.InnerContainer = this.pnlListBoxContainer;
            this.pnlListBox.Location = new System.Drawing.Point(3, 260);
            this.pnlListBox.Name = "pnlListBox";
            this.pnlListBox.Size = new System.Drawing.Size(963, 357);
            this.pnlListBox.TabIndex = 4;
            this.pnlListBox.Text = "Import Details";
            // 
            // pnlListBoxContainer
            // 
            this.pnlListBoxContainer.Controls.Add(this.listBox1);
            this.pnlListBoxContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlListBoxContainer.Name = "pnlListBoxContainer";
            this.pnlListBoxContainer.Size = new System.Drawing.Size(961, 333);
            this.pnlListBoxContainer.TabIndex = 0;
            // 
            // pnlActivitiesList
            // 
            this.pnlActivitiesList.InnerContainer = this.pnlActivitiesListContainer;
            this.pnlActivitiesList.Location = new System.Drawing.Point(0, 0);
            this.pnlActivitiesList.Name = "pnlActivitiesList";
            this.pnlActivitiesList.Size = new System.Drawing.Size(1216, 276);
            this.pnlActivitiesList.TabIndex = 0;
            this.pnlActivitiesList.Text = "Step Templates";
            // 
            // pnlActivitiesListContainer
            // 
            this.pnlActivitiesListContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivitiesListContainer.Name = "pnlActivitiesListContainer";
            this.pnlActivitiesListContainer.Size = new System.Drawing.Size(1216, 276);
            this.pnlActivitiesListContainer.TabIndex = 0;
            // 
            // pnlActivityCodeDetails
            // 
            this.pnlActivityCodeDetails.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivityCodeDetails.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlActivityCodeDetails.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlActivityCodeDetails.InnerContainer = this.pnlActivityCodeDetailsContainer;
            this.pnlActivityCodeDetails.Location = new System.Drawing.Point(0, 280);
            this.pnlActivityCodeDetails.Name = "pnlActivityCodeDetails";
            this.pnlActivityCodeDetails.Size = new System.Drawing.Size(1216, 334);
            this.pnlActivityCodeDetails.TabIndex = 1;
            // 
            // pnlActivityCodeDetailsContainer
            // 
            this.pnlActivityCodeDetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlActivityCodeDetailsContainer.Name = "pnlActivityCodeDetailsContainer";
            this.pnlActivityCodeDetailsContainer.Size = new System.Drawing.Size(1216, 334);
            this.pnlActivityCodeDetailsContainer.TabIndex = 0;
            // 
            // uiButton2
            // 
            this.uiButton2.Image = global::LawMate.Properties.Resources.atriumtrans16;
            this.uiButton2.Location = new System.Drawing.Point(599, 163);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(179, 23);
            this.uiButton2.TabIndex = 22;
            this.uiButton2.Text = "Locate Empty Lotus Extracts";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // fLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 620);
            this.Controls.Add(this.pnlListBox);
            this.Controls.Add(this.pnlTop);
            this.Name = "fLoad";
            this.Text = "Import External Documents";
            this.Load += new System.EventHandler(this.fLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlProcedure)).EndInit();
            this.pnlProcedure.ResumeLayout(false);
            this.pnlProcedureContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTopContainer.ResumeLayout(false);
            this.pnlTopContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlListBox)).EndInit();
            this.pnlListBox.ResumeLayout(false);
            this.pnlListBoxContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivitiesList)).EndInit();
            this.pnlActivitiesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlActivityCodeDetails)).EndInit();
            this.pnlActivityCodeDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private ucFileSelectBox ucDest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkInclude;
        private UserControls.ucMultiDropDown ucMultiDropDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNewFile;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlListBox;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlListBoxContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlActivitiesList;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivitiesListContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlActivityCodeDetails;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlActivityCodeDetailsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlProcedure;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlProcedureContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private UserControls.ucMultiDropDown ucMultiDropDown2;
        private Janus.Windows.GridEX.EditControls.EditBox ebImportFile;
        private Janus.Windows.EditControls.UIButton btnImportLotus;
        private Janus.Windows.EditControls.UIButton btnImport;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.EditControls.EditBox ebStartAt;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.GridEX.EditControls.EditBox ebParentFileID;
        private Janus.Windows.EditControls.UIButton uiButton2;
    }
}

