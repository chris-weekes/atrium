 namespace LawMate.Admin
{
    partial class fIssues
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
            System.Windows.Forms.Label issueIdLabel;
            System.Windows.Forms.Label fileIdLabel;
            System.Windows.Forms.Label issueNameEngLabel;
            System.Windows.Forms.Label issueNameFreLabel;
            System.Windows.Forms.Label issueDescEngLabel;
            System.Windows.Forms.Label issueDescFreLabel;
            System.Windows.Forms.Label clientOfficeIdLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label legProvisionIdLabel;
            System.Windows.Forms.Label regProvisionIdLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            Janus.Windows.GridEX.GridEXLayout mccRegProvision_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fIssues));
            Janus.Windows.GridEX.GridEXLayout mccLegProvision_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlIssueList = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlIssueListContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlIssues = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlIssuesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiGroupBox5 = new Janus.Windows.EditControls.UIGroupBox();
            this.lblRtfEdited = new System.Windows.Forms.Label();
            this.mccRegProvision = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.issueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.btnClearTextF = new Janus.Windows.EditControls.UIButton();
            this.btnTextFUnderline = new Janus.Windows.EditControls.UIButton();
            this.btnTextFItalics = new Janus.Windows.EditControls.UIButton();
            this.btnTextFBold = new Janus.Windows.EditControls.UIButton();
            this.AnalysisTextFRtb = new System.Windows.Forms.RichTextBox();
            this.btnClearTextE = new Janus.Windows.EditControls.UIButton();
            this.btnTextEUnderline = new Janus.Windows.EditControls.UIButton();
            this.btnTextEItalics = new Janus.Windows.EditControls.UIButton();
            this.btnTextEBold = new Janus.Windows.EditControls.UIButton();
            this.AnalysisTextERtb = new System.Windows.Forms.RichTextBox();
            this.mccLegProvision = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.uiGroupBox4 = new Janus.Windows.EditControls.UIGroupBox();
            this.ucOfficeSelectBox1 = new LawMate.ucOfficeSelectBox();
            this.uiGroupBox3 = new Janus.Windows.EditControls.UIGroupBox();
            this.ebParentIssueDescription = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebParentIssueName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.parentIssueIdEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.ucFileSelectBox1 = new LawMate.ucFileSelectBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.issueDescFreEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sortByFileNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.issueDescEngEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.issueNameFreEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.issueNameEngEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.issueIdEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
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
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdToggle1 = new Janus.Windows.UI.CommandBars.UICommand("cmdToggle");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdToggle = new Janus.Windows.UI.CommandBars.UICommand("cmdToggle");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdExport = new Janus.Windows.UI.CommandBars.UICommand("cmdExport");
            this.cmdImport = new Janus.Windows.UI.CommandBars.UICommand("cmdImport");
            this.cmdExport1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExport");
            this.cmdImport1 = new Janus.Windows.UI.CommandBars.UICommand("cmdImport");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            issueIdLabel = new System.Windows.Forms.Label();
            fileIdLabel = new System.Windows.Forms.Label();
            issueNameEngLabel = new System.Windows.Forms.Label();
            issueNameFreLabel = new System.Windows.Forms.Label();
            issueDescEngLabel = new System.Windows.Forms.Label();
            issueDescFreLabel = new System.Windows.Forms.Label();
            clientOfficeIdLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            legProvisionIdLabel = new System.Windows.Forms.Label();
            regProvisionIdLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIssueList)).BeginInit();
            this.pnlIssueList.SuspendLayout();
            this.pnlIssueListContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIssues)).BeginInit();
            this.pnlIssues.SuspendLayout();
            this.pnlIssuesContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox5)).BeginInit();
            this.uiGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mccRegProvision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issueBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mccLegProvision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).BeginInit();
            this.uiGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // issueIdLabel
            // 
            issueIdLabel.AutoSize = true;
            issueIdLabel.Location = new System.Drawing.Point(20, 23);
            issueIdLabel.Name = "issueIdLabel";
            issueIdLabel.Size = new System.Drawing.Size(51, 13);
            issueIdLabel.TabIndex = 0;
            issueIdLabel.Text = "Issue ID:";
            // 
            // fileIdLabel
            // 
            fileIdLabel.AutoSize = true;
            fileIdLabel.Location = new System.Drawing.Point(20, 202);
            fileIdLabel.Name = "fileIdLabel";
            fileIdLabel.Size = new System.Drawing.Size(118, 13);
            fileIdLabel.TabIndex = 4;
            fileIdLabel.Text = "Knowledge Center File:";
            // 
            // issueNameEngLabel
            // 
            issueNameEngLabel.AutoSize = true;
            issueNameEngLabel.Location = new System.Drawing.Point(20, 50);
            issueNameEngLabel.Name = "issueNameEngLabel";
            issueNameEngLabel.Size = new System.Drawing.Size(67, 13);
            issueNameEngLabel.TabIndex = 6;
            issueNameEngLabel.Text = "Name (Eng):";
            // 
            // issueNameFreLabel
            // 
            issueNameFreLabel.AutoSize = true;
            issueNameFreLabel.Location = new System.Drawing.Point(20, 125);
            issueNameFreLabel.Name = "issueNameFreLabel";
            issueNameFreLabel.Size = new System.Drawing.Size(65, 13);
            issueNameFreLabel.TabIndex = 8;
            issueNameFreLabel.Text = "Name (Fre):";
            // 
            // issueDescEngLabel
            // 
            issueDescEngLabel.AutoSize = true;
            issueDescEngLabel.Location = new System.Drawing.Point(20, 77);
            issueDescEngLabel.Name = "issueDescEngLabel";
            issueDescEngLabel.Size = new System.Drawing.Size(93, 13);
            issueDescEngLabel.TabIndex = 10;
            issueDescEngLabel.Text = "Description (Eng):";
            // 
            // issueDescFreLabel
            // 
            issueDescFreLabel.AutoSize = true;
            issueDescFreLabel.Location = new System.Drawing.Point(20, 152);
            issueDescFreLabel.Name = "issueDescFreLabel";
            issueDescFreLabel.Size = new System.Drawing.Size(91, 13);
            issueDescFreLabel.TabIndex = 12;
            issueDescFreLabel.Text = "Description (Fre):";
            // 
            // clientOfficeIdLabel
            // 
            clientOfficeIdLabel.AutoSize = true;
            clientOfficeIdLabel.Location = new System.Drawing.Point(20, 23);
            clientOfficeIdLabel.Name = "clientOfficeIdLabel";
            clientOfficeIdLabel.Size = new System.Drawing.Size(70, 13);
            clientOfficeIdLabel.TabIndex = 14;
            clientOfficeIdLabel.Text = "Client Office:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 77);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(128, 13);
            label3.TabIndex = 22;
            label3.Text = "Parent Description (Eng):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(20, 52);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(101, 13);
            label4.TabIndex = 20;
            label4.Text = "Parent Issue (Eng):";
            // 
            // legProvisionIdLabel
            // 
            legProvisionIdLabel.AutoSize = true;
            legProvisionIdLabel.BackColor = System.Drawing.Color.Transparent;
            legProvisionIdLabel.Location = new System.Drawing.Point(20, 26);
            legProvisionIdLabel.Name = "legProvisionIdLabel";
            legProvisionIdLabel.Size = new System.Drawing.Size(107, 13);
            legProvisionIdLabel.TabIndex = 0;
            legProvisionIdLabel.Text = "Legislative Provision:";
            // 
            // regProvisionIdLabel
            // 
            regProvisionIdLabel.AutoSize = true;
            regProvisionIdLabel.BackColor = System.Drawing.Color.Transparent;
            regProvisionIdLabel.Location = new System.Drawing.Point(20, 53);
            regProvisionIdLabel.Name = "regProvisionIdLabel";
            regProvisionIdLabel.Size = new System.Drawing.Size(108, 13);
            regProvisionIdLabel.TabIndex = 2;
            regProvisionIdLabel.Text = "Regulation Provision:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(20, 81);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(108, 13);
            label1.TabIndex = 56;
            label1.Text = "Analysis Text (Eng.):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(20, 171);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(106, 13);
            label2.TabIndex = 57;
            label2.Text = "Analysis Text (Fre.):";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlIssueList.Id = new System.Guid("562125bd-3a85-485b-8d40-db347f3ea7ed");
            this.uiPanelManager1.Panels.Add(this.pnlIssueList);
            this.pnlIssues.Id = new System.Guid("f8188c66-77fe-40da-bd8f-848dee7233df");
            this.uiPanelManager1.Panels.Add(this.pnlIssues);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("f8188c66-77fe-40da-bd8f-848dee7233df"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(633, 726), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("562125bd-3a85-485b-8d40-db347f3ea7ed"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(359, 726), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f8188c66-77fe-40da-bd8f-848dee7233df"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("562125bd-3a85-485b-8d40-db347f3ea7ed"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlIssueList
            // 
            this.pnlIssueList.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlIssueList.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlIssueList.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.pnlIssueList.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlIssueList.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlIssueList.Image = ((System.Drawing.Image)(resources.GetObject("pnlIssueList.Image")));
            this.pnlIssueList.InnerContainer = this.pnlIssueListContainer;
            this.pnlIssueList.Location = new System.Drawing.Point(3, 31);
            this.pnlIssueList.Name = "pnlIssueList";
            this.pnlIssueList.Size = new System.Drawing.Size(359, 726);
            this.pnlIssueList.TabIndex = 4;
            this.pnlIssueList.Text = "Issue List";
            // 
            // pnlIssueListContainer
            // 
            this.pnlIssueListContainer.Controls.Add(this.treeView1);
            this.pnlIssueListContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlIssueListContainer.Name = "pnlIssueListContainer";
            this.pnlIssueListContainer.Size = new System.Drawing.Size(353, 702);
            this.pnlIssueListContainer.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageKey = "activity1.gif";
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageKey = "activity1.gif";
            this.treeView1.Size = new System.Drawing.Size(353, 702);
            this.treeView1.TabIndex = 0;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "views.gif");
            this.imageList1.Images.SetKeyName(1, "activity1.gif");
            this.imageList1.Images.SetKeyName(2, "penTrans.gif");
            this.imageList1.Images.SetKeyName(3, "folder.gif");
            this.imageList1.Images.SetKeyName(4, "issue.png");
            // 
            // pnlIssues
            // 
            this.pnlIssues.InnerContainer = this.pnlIssuesContainer;
            this.pnlIssues.Location = new System.Drawing.Point(362, 31);
            this.pnlIssues.Name = "pnlIssues";
            this.pnlIssues.Size = new System.Drawing.Size(633, 726);
            this.pnlIssues.TabIndex = 4;
            this.pnlIssues.Text = "Issues";
            // 
            // pnlIssuesContainer
            // 
            this.pnlIssuesContainer.AutoScroll = true;
            this.pnlIssuesContainer.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.pnlIssuesContainer.Controls.Add(this.uiGroupBox5);
            this.pnlIssuesContainer.Controls.Add(this.uiGroupBox4);
            this.pnlIssuesContainer.Controls.Add(this.uiGroupBox3);
            this.pnlIssuesContainer.Controls.Add(this.uiGroupBox1);
            this.pnlIssuesContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlIssuesContainer.Name = "pnlIssuesContainer";
            this.pnlIssuesContainer.Size = new System.Drawing.Size(631, 724);
            this.pnlIssuesContainer.TabIndex = 0;
            // 
            // uiGroupBox5
            // 
            this.uiGroupBox5.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox5.Controls.Add(this.lblRtfEdited);
            this.uiGroupBox5.Controls.Add(this.mccRegProvision);
            this.uiGroupBox5.Controls.Add(label2);
            this.uiGroupBox5.Controls.Add(label1);
            this.uiGroupBox5.Controls.Add(this.btnClearTextF);
            this.uiGroupBox5.Controls.Add(this.btnTextFUnderline);
            this.uiGroupBox5.Controls.Add(this.btnTextFItalics);
            this.uiGroupBox5.Controls.Add(this.btnTextFBold);
            this.uiGroupBox5.Controls.Add(this.AnalysisTextFRtb);
            this.uiGroupBox5.Controls.Add(this.btnClearTextE);
            this.uiGroupBox5.Controls.Add(this.btnTextEUnderline);
            this.uiGroupBox5.Controls.Add(this.btnTextEItalics);
            this.uiGroupBox5.Controls.Add(this.btnTextEBold);
            this.uiGroupBox5.Controls.Add(this.AnalysisTextERtb);
            this.uiGroupBox5.Controls.Add(this.mccLegProvision);
            this.uiGroupBox5.Controls.Add(regProvisionIdLabel);
            this.uiGroupBox5.Controls.Add(legProvisionIdLabel);
            this.uiGroupBox5.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox5.Location = new System.Drawing.Point(6, 237);
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.uiGroupBox5.Size = new System.Drawing.Size(609, 259);
            this.uiGroupBox5.TabIndex = 25;
            this.uiGroupBox5.Text = "Legislative Provisions";
            this.uiGroupBox5.UseThemes = false;
            // 
            // lblRtfEdited
            // 
            this.lblRtfEdited.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRtfEdited.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRtfEdited.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRtfEdited.Location = new System.Drawing.Point(6, 230);
            this.lblRtfEdited.Name = "lblRtfEdited";
            this.lblRtfEdited.Size = new System.Drawing.Size(141, 21);
            this.lblRtfEdited.TabIndex = 59;
            this.lblRtfEdited.Text = "* In Edit Mode *";
            this.lblRtfEdited.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRtfEdited.Visible = false;
            // 
            // mccRegProvision
            // 
            this.mccRegProvision.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.issueBindingSource1, "RegProvisionId", true));
            mccRegProvision_DesignTimeLayout.LayoutString = resources.GetString("mccRegProvision_DesignTimeLayout.LayoutString");
            this.mccRegProvision.DesignTimeLayout = mccRegProvision_DesignTimeLayout;
            this.mccRegProvision.DisplayMember = "ProvisionNameEng";
            this.mccRegProvision.Image = ((System.Drawing.Image)(resources.GetObject("mccRegProvision.Image")));
            this.mccRegProvision.Location = new System.Drawing.Point(153, 49);
            this.mccRegProvision.Name = "mccRegProvision";
            this.mccRegProvision.SelectedIndex = -1;
            this.mccRegProvision.SelectedItem = null;
            this.mccRegProvision.Size = new System.Drawing.Size(430, 22);
            this.mccRegProvision.TabIndex = 58;
            this.mccRegProvision.ValueMember = "ProvisionId";
            this.mccRegProvision.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // issueBindingSource1
            // 
            this.issueBindingSource1.DataMember = "Issue";
            this.issueBindingSource1.DataSource = this.appDB;
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClearTextF
            // 
            this.btnClearTextF.Image = global::LawMate.Properties.Resources.edit;
            this.btnClearTextF.Location = new System.Drawing.Point(486, 167);
            this.btnClearTextF.Name = "btnClearTextF";
            this.btnClearTextF.Size = new System.Drawing.Size(97, 22);
            this.btnClearTextF.TabIndex = 55;
            this.btnClearTextF.Text = "Clear Format";
            this.btnClearTextF.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnClearTextF.Click += new System.EventHandler(this.btnClearTextE_Click);
            // 
            // btnTextFUnderline
            // 
            this.btnTextFUnderline.Image = global::LawMate.Properties.Resources.underline2;
            this.btnTextFUnderline.Location = new System.Drawing.Point(551, 195);
            this.btnTextFUnderline.Name = "btnTextFUnderline";
            this.btnTextFUnderline.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Silver;
            this.btnTextFUnderline.Size = new System.Drawing.Size(21, 22);
            this.btnTextFUnderline.TabIndex = 54;
            this.btnTextFUnderline.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnTextFUnderline.Click += new System.EventHandler(this.btnTextEBold_Click);
            // 
            // btnTextFItalics
            // 
            this.btnTextFItalics.Image = global::LawMate.Properties.Resources.italic;
            this.btnTextFItalics.Location = new System.Drawing.Point(524, 195);
            this.btnTextFItalics.Name = "btnTextFItalics";
            this.btnTextFItalics.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Silver;
            this.btnTextFItalics.Size = new System.Drawing.Size(21, 22);
            this.btnTextFItalics.TabIndex = 53;
            this.btnTextFItalics.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnTextFItalics.Click += new System.EventHandler(this.btnTextEBold_Click);
            // 
            // btnTextFBold
            // 
            this.btnTextFBold.Image = global::LawMate.Properties.Resources.bold;
            this.btnTextFBold.Location = new System.Drawing.Point(497, 195);
            this.btnTextFBold.Name = "btnTextFBold";
            this.btnTextFBold.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Silver;
            this.btnTextFBold.Size = new System.Drawing.Size(21, 22);
            this.btnTextFBold.TabIndex = 52;
            this.btnTextFBold.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnTextFBold.Click += new System.EventHandler(this.btnTextEBold_Click);
            // 
            // AnalysisTextFRtb
            // 
            this.AnalysisTextFRtb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalysisTextFRtb.HideSelection = false;
            this.AnalysisTextFRtb.Location = new System.Drawing.Point(153, 167);
            this.AnalysisTextFRtb.Name = "AnalysisTextFRtb";
            this.AnalysisTextFRtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.AnalysisTextFRtb.Size = new System.Drawing.Size(327, 84);
            this.AnalysisTextFRtb.TabIndex = 51;
            this.AnalysisTextFRtb.Text = "";
            this.AnalysisTextFRtb.TextChanged += new System.EventHandler(this.AnalysisTextERtb_TextChanged);
            // 
            // btnClearTextE
            // 
            this.btnClearTextE.Image = global::LawMate.Properties.Resources.edit;
            this.btnClearTextE.Location = new System.Drawing.Point(486, 77);
            this.btnClearTextE.Name = "btnClearTextE";
            this.btnClearTextE.Size = new System.Drawing.Size(97, 22);
            this.btnClearTextE.TabIndex = 50;
            this.btnClearTextE.Text = "Clear Format";
            this.btnClearTextE.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnClearTextE.Click += new System.EventHandler(this.btnClearTextE_Click);
            // 
            // btnTextEUnderline
            // 
            this.btnTextEUnderline.Image = global::LawMate.Properties.Resources.underline2;
            this.btnTextEUnderline.Location = new System.Drawing.Point(551, 105);
            this.btnTextEUnderline.Name = "btnTextEUnderline";
            this.btnTextEUnderline.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Silver;
            this.btnTextEUnderline.Size = new System.Drawing.Size(21, 22);
            this.btnTextEUnderline.TabIndex = 49;
            this.btnTextEUnderline.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnTextEUnderline.Click += new System.EventHandler(this.btnTextEBold_Click);
            // 
            // btnTextEItalics
            // 
            this.btnTextEItalics.Image = global::LawMate.Properties.Resources.italic;
            this.btnTextEItalics.Location = new System.Drawing.Point(524, 105);
            this.btnTextEItalics.Name = "btnTextEItalics";
            this.btnTextEItalics.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Silver;
            this.btnTextEItalics.Size = new System.Drawing.Size(21, 22);
            this.btnTextEItalics.TabIndex = 48;
            this.btnTextEItalics.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnTextEItalics.Click += new System.EventHandler(this.btnTextEBold_Click);
            // 
            // btnTextEBold
            // 
            this.btnTextEBold.Image = global::LawMate.Properties.Resources.bold;
            this.btnTextEBold.Location = new System.Drawing.Point(497, 105);
            this.btnTextEBold.Name = "btnTextEBold";
            this.btnTextEBold.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Silver;
            this.btnTextEBold.Size = new System.Drawing.Size(21, 22);
            this.btnTextEBold.TabIndex = 47;
            this.btnTextEBold.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnTextEBold.Click += new System.EventHandler(this.btnTextEBold_Click);
            // 
            // AnalysisTextERtb
            // 
            this.AnalysisTextERtb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalysisTextERtb.HideSelection = false;
            this.AnalysisTextERtb.Location = new System.Drawing.Point(153, 77);
            this.AnalysisTextERtb.Name = "AnalysisTextERtb";
            this.AnalysisTextERtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.AnalysisTextERtb.Size = new System.Drawing.Size(327, 84);
            this.AnalysisTextERtb.TabIndex = 46;
            this.AnalysisTextERtb.Text = "";
            this.AnalysisTextERtb.TextChanged += new System.EventHandler(this.AnalysisTextERtb_TextChanged);
            this.AnalysisTextERtb.Validated += new System.EventHandler(this.AnalysisTextERtb_Validated);
            // 
            // mccLegProvision
            // 
            this.mccLegProvision.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.issueBindingSource1, "LegProvisionId", true));
            mccLegProvision_DesignTimeLayout.LayoutString = resources.GetString("mccLegProvision_DesignTimeLayout.LayoutString");
            this.mccLegProvision.DesignTimeLayout = mccLegProvision_DesignTimeLayout;
            this.mccLegProvision.DisplayMember = "ProvisionNameEng";
            this.mccLegProvision.Image = ((System.Drawing.Image)(resources.GetObject("mccLegProvision.Image")));
            this.mccLegProvision.Location = new System.Drawing.Point(153, 21);
            this.mccLegProvision.Name = "mccLegProvision";
            this.mccLegProvision.SelectedIndex = -1;
            this.mccLegProvision.SelectedItem = null;
            this.mccLegProvision.Size = new System.Drawing.Size(430, 22);
            this.mccLegProvision.TabIndex = 4;
            this.mccLegProvision.ValueMember = "ProvisionId";
            this.mccLegProvision.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox4.Controls.Add(this.ucOfficeSelectBox1);
            this.uiGroupBox4.Controls.Add(clientOfficeIdLabel);
            this.uiGroupBox4.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox4.Location = new System.Drawing.Point(6, 636);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Size = new System.Drawing.Size(609, 56);
            this.uiGroupBox4.TabIndex = 24;
            this.uiGroupBox4.Text = "Client Office";
            this.uiGroupBox4.UseThemes = false;
            // 
            // ucOfficeSelectBox1
            // 
            this.ucOfficeSelectBox1.AtMng = null;
            this.ucOfficeSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucOfficeSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.issueBindingSource1, "ClientOfficeId", true));
            this.ucOfficeSelectBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucOfficeSelectBox1.Location = new System.Drawing.Point(153, 18);
            this.ucOfficeSelectBox1.Name = "ucOfficeSelectBox1";
            this.ucOfficeSelectBox1.OfficeId = null;
            this.ucOfficeSelectBox1.ReadOnly = false;
            this.ucOfficeSelectBox1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucOfficeSelectBox1.Size = new System.Drawing.Size(430, 23);
            this.ucOfficeSelectBox1.TabIndex = 16;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox3.Controls.Add(this.ebParentIssueDescription);
            this.uiGroupBox3.Controls.Add(this.ebParentIssueName);
            this.uiGroupBox3.Controls.Add(this.parentIssueIdEditBox);
            this.uiGroupBox3.Controls.Add(this.linkLabel2);
            this.uiGroupBox3.Controls.Add(label3);
            this.uiGroupBox3.Controls.Add(label4);
            this.uiGroupBox3.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox3.Location = new System.Drawing.Point(6, 500);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(609, 130);
            this.uiGroupBox3.TabIndex = 20;
            this.uiGroupBox3.Text = "Parent Issue";
            this.uiGroupBox3.UseThemes = false;
            // 
            // ebParentIssueDescription
            // 
            this.ebParentIssueDescription.BackColor = System.Drawing.SystemColors.Control;
            this.ebParentIssueDescription.Location = new System.Drawing.Point(153, 74);
            this.ebParentIssueDescription.Multiline = true;
            this.ebParentIssueDescription.Name = "ebParentIssueDescription";
            this.ebParentIssueDescription.ReadOnly = true;
            this.ebParentIssueDescription.Size = new System.Drawing.Size(430, 46);
            this.ebParentIssueDescription.TabIndex = 26;
            this.ebParentIssueDescription.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebParentIssueName
            // 
            this.ebParentIssueName.BackColor = System.Drawing.SystemColors.Control;
            this.ebParentIssueName.Location = new System.Drawing.Point(153, 47);
            this.ebParentIssueName.Name = "ebParentIssueName";
            this.ebParentIssueName.ReadOnly = true;
            this.ebParentIssueName.Size = new System.Drawing.Size(430, 21);
            this.ebParentIssueName.TabIndex = 25;
            this.ebParentIssueName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // parentIssueIdEditBox
            // 
            this.parentIssueIdEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.parentIssueIdEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.issueBindingSource1, "ParentIssueId", true));
            this.parentIssueIdEditBox.Location = new System.Drawing.Point(153, 20);
            this.parentIssueIdEditBox.Name = "parentIssueIdEditBox";
            this.parentIssueIdEditBox.ReadOnly = true;
            this.parentIssueIdEditBox.Size = new System.Drawing.Size(96, 21);
            this.parentIssueIdEditBox.TabIndex = 24;
            this.parentIssueIdEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(20, 25);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(86, 13);
            this.linkLabel2.TabIndex = 22;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Parent Issue ID:";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(this.ucFileSelectBox1);
            this.uiGroupBox1.Controls.Add(this.uiButton1);
            this.uiGroupBox1.Controls.Add(this.issueDescFreEditBox);
            this.uiGroupBox1.Controls.Add(fileIdLabel);
            this.uiGroupBox1.Controls.Add(this.sortByFileNumberCheckBox);
            this.uiGroupBox1.Controls.Add(this.issueDescEngEditBox);
            this.uiGroupBox1.Controls.Add(this.issueNameFreEditBox);
            this.uiGroupBox1.Controls.Add(this.issueNameEngEditBox);
            this.uiGroupBox1.Controls.Add(this.issueIdEditBox);
            this.uiGroupBox1.Controls.Add(issueIdLabel);
            this.uiGroupBox1.Controls.Add(issueNameEngLabel);
            this.uiGroupBox1.Controls.Add(issueNameFreLabel);
            this.uiGroupBox1.Controls.Add(issueDescEngLabel);
            this.uiGroupBox1.Controls.Add(issueDescFreLabel);
            this.uiGroupBox1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox1.Location = new System.Drawing.Point(6, 3);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(609, 228);
            this.uiGroupBox1.TabIndex = 9;
            this.uiGroupBox1.Text = "Details for Selected Issue";
            this.uiGroupBox1.UseThemes = false;
            // 
            // ucFileSelectBox1
            // 
            this.ucFileSelectBox1.AtMng = null;
            this.ucFileSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucFileSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.issueBindingSource1, "FileId", true));
            this.ucFileSelectBox1.FileId = null;
            this.ucFileSelectBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucFileSelectBox1.Location = new System.Drawing.Point(153, 197);
            this.ucFileSelectBox1.Name = "ucFileSelectBox1";
            this.ucFileSelectBox1.ReadOnly = false;
            this.ucFileSelectBox1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucFileSelectBox1.Size = new System.Drawing.Size(392, 23);
            this.ucFileSelectBox1.TabIndex = 22;
            // 
            // uiButton1
            // 
            this.uiButton1.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.uiButton1.Image = global::LawMate.Properties.Resources.delete;
            this.uiButton1.Location = new System.Drawing.Point(551, 197);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(32, 23);
            this.uiButton1.TabIndex = 21;
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // issueDescFreEditBox
            // 
            this.issueDescFreEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.issueBindingSource1, "IssueDescFre", true));
            this.issueDescFreEditBox.Location = new System.Drawing.Point(153, 149);
            this.issueDescFreEditBox.Multiline = true;
            this.issueDescFreEditBox.Name = "issueDescFreEditBox";
            this.issueDescFreEditBox.Size = new System.Drawing.Size(430, 42);
            this.issueDescFreEditBox.TabIndex = 18;
            this.issueDescFreEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sortByFileNumberCheckBox
            // 
            this.sortByFileNumberCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.sortByFileNumberCheckBox.Location = new System.Drawing.Point(284, 18);
            this.sortByFileNumberCheckBox.Name = "sortByFileNumberCheckBox";
            this.sortByFileNumberCheckBox.Size = new System.Drawing.Size(125, 24);
            this.sortByFileNumberCheckBox.TabIndex = 25;
            this.sortByFileNumberCheckBox.Text = "Sort By File Number";
            this.sortByFileNumberCheckBox.UseVisualStyleBackColor = false;
            // 
            // issueDescEngEditBox
            // 
            this.issueDescEngEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.issueBindingSource1, "IssueDescEng", true));
            this.issueDescEngEditBox.Location = new System.Drawing.Point(153, 74);
            this.issueDescEngEditBox.Multiline = true;
            this.issueDescEngEditBox.Name = "issueDescEngEditBox";
            this.issueDescEngEditBox.Size = new System.Drawing.Size(430, 42);
            this.issueDescEngEditBox.TabIndex = 17;
            this.issueDescEngEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // issueNameFreEditBox
            // 
            this.issueNameFreEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.issueBindingSource1, "IssueNameFre", true));
            this.issueNameFreEditBox.Location = new System.Drawing.Point(153, 122);
            this.issueNameFreEditBox.Name = "issueNameFreEditBox";
            this.issueNameFreEditBox.Size = new System.Drawing.Size(430, 21);
            this.issueNameFreEditBox.TabIndex = 16;
            this.issueNameFreEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // issueNameEngEditBox
            // 
            this.issueNameEngEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.issueBindingSource1, "IssueNameEng", true));
            this.issueNameEngEditBox.Location = new System.Drawing.Point(153, 47);
            this.issueNameEngEditBox.Name = "issueNameEngEditBox";
            this.issueNameEngEditBox.Size = new System.Drawing.Size(430, 21);
            this.issueNameEngEditBox.TabIndex = 15;
            this.issueNameEngEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.issueNameEngEditBox.Validating += new System.ComponentModel.CancelEventHandler(this.issueNameEngTextBox_Validating);
            // 
            // issueIdEditBox
            // 
            this.issueIdEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.issueIdEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.issueBindingSource1, "IssueId", true));
            this.issueIdEditBox.Location = new System.Drawing.Point(153, 20);
            this.issueIdEditBox.Name = "issueIdEditBox";
            this.issueIdEditBox.ReadOnly = true;
            this.issueIdEditBox.Size = new System.Drawing.Size(116, 21);
            this.issueIdEditBox.TabIndex = 14;
            this.issueIdEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
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
            this.cmdToggle,
            this.cmdExport,
            this.cmdImport});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("a7c406f8-4938-4d57-ac20-00d6284c1784");
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
            this.cmdDelete1,
            this.Separator4,
            this.cmdToggle1,
            this.Separator5,
            this.cmdExport1,
            this.cmdImport1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowToolTips = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Size = new System.Drawing.Size(998, 28);
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
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator4.Key = "Separator";
            this.Separator4.Name = "Separator4";
            // 
            // cmdToggle1
            // 
            this.cmdToggle1.Key = "cmdToggle";
            this.cmdToggle1.Name = "cmdToggle1";
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
            this.cmdDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.Key = "cmdDelete";
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "Delete";
            // 
            // cmdToggle
            // 
            this.cmdToggle.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdToggle.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            this.cmdToggle.Image = ((System.Drawing.Image)(resources.GetObject("cmdToggle.Image")));
            this.cmdToggle.Key = "cmdToggle";
            this.cmdToggle.Name = "cmdToggle";
            this.cmdToggle.Text = "Expand/Collapse";
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
            this.TopRebar1.Size = new System.Drawing.Size(998, 28);
            // 
            // cmdExport
            // 
            this.cmdExport.Key = "cmdExport";
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Text = "Export";
            // 
            // cmdImport
            // 
            this.cmdImport.Key = "cmdImport";
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Text = "Import";
            // 
            // cmdExport1
            // 
            this.cmdExport1.Key = "cmdExport";
            this.cmdExport1.Name = "cmdExport1";
            // 
            // cmdImport1
            // 
            this.cmdImport1.Key = "cmdImport";
            this.cmdImport1.Name = "cmdImport1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator5.Key = "Separator";
            this.Separator5.Name = "Separator5";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fIssues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(998, 760);
            this.Controls.Add(this.pnlIssues);
            this.Controls.Add(this.pnlIssueList);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fIssues";
            this.Text = "Issues";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIssueList)).EndInit();
            this.pnlIssueList.ResumeLayout(false);
            this.pnlIssueListContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIssues)).EndInit();
            this.pnlIssues.ResumeLayout(false);
            this.pnlIssuesContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox5)).EndInit();
            this.uiGroupBox5.ResumeLayout(false);
            this.uiGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mccRegProvision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issueBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mccLegProvision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).EndInit();
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
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
        private Janus.Windows.UI.Dock.UIPanel pnlIssues;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlIssuesContainer;
        private System.Windows.Forms.TreeView treeView1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox3;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox4;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggle;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdToggle1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private ucFileSelectBox ucFileSelectBox1;
        private System.Windows.Forms.CheckBox sortByFileNumberCheckBox;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox5;
        private Janus.Windows.GridEX.EditControls.EditBox issueDescFreEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox issueDescEngEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox issueNameFreEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox issueNameEngEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox issueIdEditBox;
        private Janus.Windows.UI.Dock.UIPanel pnlIssueList;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlIssueListContainer;
        private System.Windows.Forms.BindingSource issueBindingSource1;
        private lmDatasets.appDB appDB;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo mccLegProvision;
        private Janus.Windows.GridEX.EditControls.EditBox ebParentIssueDescription;
        private Janus.Windows.GridEX.EditControls.EditBox ebParentIssueName;
        private Janus.Windows.GridEX.EditControls.EditBox parentIssueIdEditBox;
        private Janus.Windows.EditControls.UIButton btnClearTextF;
        private Janus.Windows.EditControls.UIButton btnTextFUnderline;
        private Janus.Windows.EditControls.UIButton btnTextFItalics;
        private Janus.Windows.EditControls.UIButton btnTextFBold;
        private System.Windows.Forms.RichTextBox AnalysisTextFRtb;
        private Janus.Windows.EditControls.UIButton btnClearTextE;
        private Janus.Windows.EditControls.UIButton btnTextEUnderline;
        private Janus.Windows.EditControls.UIButton btnTextEItalics;
        private Janus.Windows.EditControls.UIButton btnTextEBold;
        private System.Windows.Forms.RichTextBox AnalysisTextERtb;
        private ucOfficeSelectBox ucOfficeSelectBox1;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo mccRegProvision;
        private System.Windows.Forms.Label lblRtfEdited;
        private Janus.Windows.UI.CommandBars.UICommand cmdExport;
        private Janus.Windows.UI.CommandBars.UICommand cmdImport;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand cmdExport1;
        private Janus.Windows.UI.CommandBars.UICommand cmdImport1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
