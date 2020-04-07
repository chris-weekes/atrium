using System.Data;

namespace LawMate.Admin
{
    partial class fTemplates
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
                templateBindingSource.CurrentChanged += new System.EventHandler(templateBindingSource_CurrentChanged);

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
            System.Windows.Forms.Label letterNameLabel;
            System.Windows.Forms.Label letterDescEngLabel;
            System.Windows.Forms.Label letterDescFreLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label exportedDateLabel;
            System.Windows.Forms.Label importedDateLabel;
            System.Windows.Forms.Label tagLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label efTypeLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            Janus.Windows.GridEX.GridEXLayout templateGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference templateGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference templateGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference templateGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference templateGridEX_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column7.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference templateGridEX_DesignTimeLayout_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column10.ValueList.Item0.Image");
            Janus.Windows.GridEX.GridEXLayout gridEX2_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item0.Image");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTemplates));
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item2.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item3.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item4.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_5 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item5.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_6 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item6.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_7 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_8 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEX2_DesignTimeLayout_Reference_9 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ValueList.Item2.Image");
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlLeft = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLeftContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.templateGridEX = new Janus.Windows.GridEX.GridEX();
            this.templateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.pnlTagParse = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTagParseContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lbTagVerify = new System.Windows.Forms.ListBox();
            this.pnlMeta = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlMetaContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.mccLayoutStyle = new LawMate.UserControls.ucMultiDropDown();
            this.editBox4 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.mccCommType = new LawMate.UserControls.ucMultiDropDown();
            this.ebBaseTemplate = new Janus.Windows.GridEX.EditControls.EditBox();
            this.gridEX2 = new Janus.Windows.GridEX.GridEX();
            this.tagEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.importedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.exportedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.flagForExportUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.uiCheckBox5 = new Janus.Windows.EditControls.UICheckBox();
            this.uiCheckBox4 = new Janus.Windows.EditControls.UICheckBox();
            this.uiCheckBox3 = new Janus.Windows.EditControls.UICheckBox();
            this.uiCheckBox2 = new Janus.Windows.EditControls.UICheckBox();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.checkReadOnly = new Janus.Windows.EditControls.UICheckBox();
            this.editBox3 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox2 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlContainer = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlContents = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlContentsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucDoc1 = new LawMate.UserControls.ucDoc();
            this.TopRebar2 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.uiCommandManager2 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar2 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdLinkToDifferentDoc = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkToDifferentDoc");
            this.cmdEditContents = new Janus.Windows.UI.CommandBars.UICommand("cmdEditContents");
            this.cmdInsertTag = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertTag");
            this.cmdVerifyDocTag = new Janus.Windows.UI.CommandBars.UICommand("cmdVerifyDocTag");
            this.cmdTitle = new Janus.Windows.UI.CommandBars.UICommand("cmdTitle");
            this.LeftRebar2 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar2 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdTitle1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdLinkToDifferentDoc1 = new Janus.Windows.UI.CommandBars.UICommand("cmdLinkToDifferentDoc");
            this.cmdEditContents1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEditContents");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdInsertTag1 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertTag");
            this.cmdVerifyDocTag1 = new Janus.Windows.UI.CommandBars.UICommand("cmdVerifyDocTag");
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdNew1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdClone1 = new Janus.Windows.UI.CommandBars.UICommand("cmdClone");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdFlagCont1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFlagCont");
            this.Separator9 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdImportExport1 = new Janus.Windows.UI.CommandBars.UICommand("cmdImportExport");
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdPreviewDoc1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPreviewDoc");
            this.cmdChangeCode1 = new Janus.Windows.UI.CommandBars.UICommand("cmdChangeCode");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdNew = new Janus.Windows.UI.CommandBars.UICommand("cmdNew");
            this.cmdNewRTFTemplate1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewRTFTemplate");
            this.cmdNewHTMLTemplate1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewHTMLTemplate");
            this.cmdNewTextTemplate1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewTextTemplate");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdNewRTFTemplate = new Janus.Windows.UI.CommandBars.UICommand("cmdNewRTFTemplate");
            this.cmdNewHTMLTemplate = new Janus.Windows.UI.CommandBars.UICommand("cmdNewHTMLTemplate");
            this.cmdNewTextTemplate = new Janus.Windows.UI.CommandBars.UICommand("cmdNewTextTemplate");
            this.cmdExport = new Janus.Windows.UI.CommandBars.UICommand("cmdExport");
            this.cmdImport = new Janus.Windows.UI.CommandBars.UICommand("cmdImport");
            this.cmdClone = new Janus.Windows.UI.CommandBars.UICommand("cmdClone");
            this.cmdPreviewDoc = new Janus.Windows.UI.CommandBars.UICommand("cmdPreviewDoc");
            this.cmdClearSelectedDocs = new Janus.Windows.UI.CommandBars.UICommand("cmdClearSelectedDocs");
            this.cmdSelectAllFlaggedDocs = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectAllFlaggedDocs");
            this.cmdFlagCont = new Janus.Windows.UI.CommandBars.UICommand("cmdFlagCont");
            this.cmdSelectAllFlaggedDocs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectAllFlaggedDocs");
            this.cmdClearSelectedDocs1 = new Janus.Windows.UI.CommandBars.UICommand("cmdClearSelectedDocs");
            this.cmdImportExport = new Janus.Windows.UI.CommandBars.UICommand("cmdImportExport");
            this.cmdExport1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExport");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdImport1 = new Janus.Windows.UI.CommandBars.UICommand("cmdImport");
            this.cmdChangeCode = new Janus.Windows.UI.CommandBars.UICommand("cmdChangeCode");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmdSave2 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.timFMHeartbeat = new System.Windows.Forms.Timer(this.components);
            letterNameLabel = new System.Windows.Forms.Label();
            letterDescEngLabel = new System.Windows.Forms.Label();
            letterDescFreLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            exportedDateLabel = new System.Windows.Forms.Label();
            importedDateLabel = new System.Windows.Forms.Label();
            tagLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            efTypeLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.templateGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTagParse)).BeginInit();
            this.pnlTagParse.SuspendLayout();
            this.pnlTagParseContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMeta)).BeginInit();
            this.pnlMeta.SuspendLayout();
            this.pnlMetaContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContents)).BeginInit();
            this.pnlContents.SuspendLayout();
            this.pnlContentsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar2)).BeginInit();
            this.TopRebar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // letterNameLabel
            // 
            letterNameLabel.AutoSize = true;
            letterNameLabel.BackColor = System.Drawing.Color.Transparent;
            letterNameLabel.Location = new System.Drawing.Point(7, 9);
            letterNameLabel.Name = "letterNameLabel";
            letterNameLabel.Size = new System.Drawing.Size(83, 13);
            letterNameLabel.TabIndex = 0;
            letterNameLabel.Text = "Template Code:";
            // 
            // letterDescEngLabel
            // 
            letterDescEngLabel.AutoSize = true;
            letterDescEngLabel.BackColor = System.Drawing.Color.Transparent;
            letterDescEngLabel.Location = new System.Drawing.Point(7, 62);
            letterDescEngLabel.Name = "letterDescEngLabel";
            letterDescEngLabel.Size = new System.Drawing.Size(93, 13);
            letterDescEngLabel.TabIndex = 7;
            letterDescEngLabel.Text = "Description (Eng):";
            // 
            // letterDescFreLabel
            // 
            letterDescFreLabel.AutoSize = true;
            letterDescFreLabel.BackColor = System.Drawing.Color.Transparent;
            letterDescFreLabel.Location = new System.Drawing.Point(7, 89);
            letterDescFreLabel.Name = "letterDescFreLabel";
            letterDescFreLabel.Size = new System.Drawing.Size(91, 13);
            letterDescFreLabel.TabIndex = 9;
            letterDescFreLabel.Text = "Description (Fre):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(7, 114);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 13);
            label1.TabIndex = 11;
            label1.Text = "Make available in:";
            // 
            // exportedDateLabel
            // 
            exportedDateLabel.AutoSize = true;
            exportedDateLabel.BackColor = System.Drawing.Color.Transparent;
            exportedDateLabel.Location = new System.Drawing.Point(7, 166);
            exportedDateLabel.Name = "exportedDateLabel";
            exportedDateLabel.Size = new System.Drawing.Size(81, 13);
            exportedDateLabel.TabIndex = 20;
            exportedDateLabel.Text = "Exported Date:";
            // 
            // importedDateLabel
            // 
            importedDateLabel.AutoSize = true;
            importedDateLabel.BackColor = System.Drawing.Color.Transparent;
            importedDateLabel.Location = new System.Drawing.Point(248, 166);
            importedDateLabel.Name = "importedDateLabel";
            importedDateLabel.Size = new System.Drawing.Size(81, 13);
            importedDateLabel.TabIndex = 22;
            importedDateLabel.Text = "Imported Date:";
            // 
            // tagLabel
            // 
            tagLabel.AutoSize = true;
            tagLabel.BackColor = System.Drawing.Color.Transparent;
            tagLabel.Location = new System.Drawing.Point(7, 193);
            tagLabel.Name = "tagLabel";
            tagLabel.Size = new System.Drawing.Size(67, 13);
            tagLabel.TabIndex = 24;
            tagLabel.Text = "Version Tag:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(7, 139);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(81, 13);
            label2.TabIndex = 16;
            label2.Text = "Base Template:";
            // 
            // efTypeLabel
            // 
            efTypeLabel.AutoSize = true;
            efTypeLabel.BackColor = System.Drawing.Color.Transparent;
            efTypeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            efTypeLabel.Location = new System.Drawing.Point(248, 193);
            efTypeLabel.Name = "efTypeLabel";
            efTypeLabel.Size = new System.Drawing.Size(35, 13);
            efTypeLabel.TabIndex = 26;
            efTypeLabel.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Location = new System.Drawing.Point(7, 35);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(92, 13);
            label3.TabIndex = 3;
            label3.Text = "Letterhead Code:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(289, 37);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 13);
            label4.TabIndex = 5;
            label4.Text = "Layout:";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.BackColorAutoHideStrip = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.BackColorGradientResizeBar = System.Drawing.SystemColors.ControlDark;
            this.uiPanelManager1.BackColorResizeBar = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionFormatStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionFormatStyle.BackColorGradient = System.Drawing.Color.DarkSlateBlue;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionFormatStyle.ForeColor = System.Drawing.Color.White;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaptionColor = System.Drawing.Color.DarkGray;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlLeft.Id = new System.Guid("bd695b96-e6a4-4c31-9500-f5ee5e5bb74f");
            this.uiPanelManager1.Panels.Add(this.pnlLeft);
            this.pnlTagParse.Id = new System.Guid("071256e7-efcb-4b43-8d16-beed49c5444b");
            this.uiPanelManager1.Panels.Add(this.pnlTagParse);
            this.pnlMeta.Id = new System.Guid("a5462cdb-4824-43a7-9ec6-79f725f5cb20");
            this.uiPanelManager1.Panels.Add(this.pnlMeta);
            this.pnlContainer.Id = new System.Guid("212b5189-5d64-4e30-9853-a7d0687909c0");
            this.pnlContainer.StaticGroup = true;
            this.pnlContents.Id = new System.Guid("54dbe922-f10a-4349-bee3-c911278ccea7");
            this.pnlContainer.Panels.Add(this.pnlContents);
            this.uiPanelManager1.Panels.Add(this.pnlContainer);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("bd695b96-e6a4-4c31-9500-f5ee5e5bb74f"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(573, 707), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("071256e7-efcb-4b43-8d16-beed49c5444b"), Janus.Windows.UI.Dock.PanelDockStyle.Right, new System.Drawing.Size(200, 637), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("212b5189-5d64-4e30-9853-a7d0687909c0"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(887, 464), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("54dbe922-f10a-4349-bee3-c911278ccea7"), new System.Guid("212b5189-5d64-4e30-9853-a7d0687909c0"), 420, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a5462cdb-4824-43a7-9ec6-79f725f5cb20"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(887, 243), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d346e81d-d34c-4eb3-85d6-54671a3668eb"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("bd0e15f7-5489-48bf-ac6c-25cbb82df842"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a5a567f6-40c2-430c-94f2-81eea8d971d9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("bd695b96-e6a4-4c31-9500-f5ee5e5bb74f"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("212b5189-5d64-4e30-9853-a7d0687909c0"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a5462cdb-4824-43a7-9ec6-79f725f5cb20"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("54dbe922-f10a-4349-bee3-c911278ccea7"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("071256e7-efcb-4b43-8d16-beed49c5444b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlLeft
            // 
            this.pnlLeft.InnerContainer = this.pnlLeftContainer;
            this.pnlLeft.Location = new System.Drawing.Point(3, 31);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(573, 707);
            this.pnlLeft.TabIndex = 4;
            this.pnlLeft.Text = "Templates";
            // 
            // pnlLeftContainer
            // 
            this.pnlLeftContainer.Controls.Add(this.templateGridEX);
            this.pnlLeftContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlLeftContainer.Name = "pnlLeftContainer";
            this.pnlLeftContainer.Size = new System.Drawing.Size(567, 683);
            this.pnlLeftContainer.TabIndex = 0;
            // 
            // templateGridEX
            // 
            this.templateGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.templateGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.templateGridEX.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.templateGridEX.DataSource = this.templateBindingSource;
            templateGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("templateGridEX_DesignTimeLayout_Reference_0.Instance")));
            templateGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("templateGridEX_DesignTimeLayout_Reference_1.Instance")));
            templateGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("templateGridEX_DesignTimeLayout_Reference_2.Instance")));
            templateGridEX_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("templateGridEX_DesignTimeLayout_Reference_3.Instance")));
            templateGridEX_DesignTimeLayout_Reference_4.Instance = ((object)(resources.GetObject("templateGridEX_DesignTimeLayout_Reference_4.Instance")));
            templateGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            templateGridEX_DesignTimeLayout_Reference_0,
            templateGridEX_DesignTimeLayout_Reference_1,
            templateGridEX_DesignTimeLayout_Reference_2,
            templateGridEX_DesignTimeLayout_Reference_3,
            templateGridEX_DesignTimeLayout_Reference_4});
            templateGridEX_DesignTimeLayout.LayoutString = resources.GetString("templateGridEX_DesignTimeLayout.LayoutString");
            this.templateGridEX.DesignTimeLayout = templateGridEX_DesignTimeLayout;
            this.templateGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.templateGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.templateGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.templateGridEX.GridLines = Janus.Windows.GridEX.GridLines.RowOutline;
            this.templateGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.templateGridEX.GroupExpandBoxStyle = Janus.Windows.GridEX.ExpandBoxStyle.Classic;
            this.templateGridEX.GroupIndent = 24;
            this.templateGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.templateGridEX.Location = new System.Drawing.Point(0, 0);
            this.templateGridEX.Name = "templateGridEX";
            this.templateGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.templateGridEX.Size = new System.Drawing.Size(567, 683);
            this.templateGridEX.TabIndex = 0;
            this.templateGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.templateGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.templateGridEX_LoadingRow);
            this.templateGridEX.EnabledChanged += new System.EventHandler(this.templateGridEX_EnabledChanged);
            // 
            // templateBindingSource
            // 
            this.templateBindingSource.DataMember = "Template";
            this.templateBindingSource.DataSource = this.appDB;
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlTagParse
            // 
            this.pnlTagParse.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTagParse.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlTagParse.Closed = true;
            this.pnlTagParse.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlTagParse.InnerContainer = this.pnlTagParseContainer;
            this.pnlTagParse.Location = new System.Drawing.Point(1003, 31);
            this.pnlTagParse.Name = "pnlTagParse";
            this.pnlTagParse.Size = new System.Drawing.Size(200, 637);
            this.pnlTagParse.TabIndex = 4;
            this.pnlTagParse.Text = "Tag Verification";
            // 
            // pnlTagParseContainer
            // 
            this.pnlTagParseContainer.Controls.Add(this.lbTagVerify);
            this.pnlTagParseContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlTagParseContainer.Name = "pnlTagParseContainer";
            this.pnlTagParseContainer.Size = new System.Drawing.Size(200, 637);
            this.pnlTagParseContainer.TabIndex = 0;
            // 
            // lbTagVerify
            // 
            this.lbTagVerify.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTagVerify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTagVerify.FormattingEnabled = true;
            this.lbTagVerify.Location = new System.Drawing.Point(0, 0);
            this.lbTagVerify.Name = "lbTagVerify";
            this.lbTagVerify.Size = new System.Drawing.Size(200, 637);
            this.lbTagVerify.TabIndex = 0;
            // 
            // pnlMeta
            // 
            this.pnlMeta.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlMeta.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlMeta.InnerContainer = this.pnlMetaContainer;
            this.pnlMeta.Location = new System.Drawing.Point(576, 31);
            this.pnlMeta.MaximumSize = new System.Drawing.Size(-1, 210);
            this.pnlMeta.MinimumSize = new System.Drawing.Size(-1, 210);
            this.pnlMeta.Name = "pnlMeta";
            this.pnlMeta.Size = new System.Drawing.Size(887, 243);
            this.pnlMeta.TabIndex = 0;
            this.pnlMeta.Text = "Metadata";
            // 
            // pnlMetaContainer
            // 
            this.pnlMetaContainer.AutoScroll = true;
            this.pnlMetaContainer.Controls.Add(this.mccLayoutStyle);
            this.pnlMetaContainer.Controls.Add(label4);
            this.pnlMetaContainer.Controls.Add(this.editBox4);
            this.pnlMetaContainer.Controls.Add(label3);
            this.pnlMetaContainer.Controls.Add(this.mccCommType);
            this.pnlMetaContainer.Controls.Add(efTypeLabel);
            this.pnlMetaContainer.Controls.Add(this.ebBaseTemplate);
            this.pnlMetaContainer.Controls.Add(label2);
            this.pnlMetaContainer.Controls.Add(this.gridEX2);
            this.pnlMetaContainer.Controls.Add(tagLabel);
            this.pnlMetaContainer.Controls.Add(this.tagEditBox);
            this.pnlMetaContainer.Controls.Add(importedDateLabel);
            this.pnlMetaContainer.Controls.Add(this.importedDateCalendarCombo);
            this.pnlMetaContainer.Controls.Add(exportedDateLabel);
            this.pnlMetaContainer.Controls.Add(this.exportedDateCalendarCombo);
            this.pnlMetaContainer.Controls.Add(this.flagForExportUICheckBox);
            this.pnlMetaContainer.Controls.Add(this.uiCheckBox5);
            this.pnlMetaContainer.Controls.Add(this.uiCheckBox4);
            this.pnlMetaContainer.Controls.Add(this.uiCheckBox3);
            this.pnlMetaContainer.Controls.Add(this.uiCheckBox2);
            this.pnlMetaContainer.Controls.Add(label1);
            this.pnlMetaContainer.Controls.Add(this.uiCheckBox1);
            this.pnlMetaContainer.Controls.Add(this.checkReadOnly);
            this.pnlMetaContainer.Controls.Add(this.editBox3);
            this.pnlMetaContainer.Controls.Add(this.editBox2);
            this.pnlMetaContainer.Controls.Add(this.editBox1);
            this.pnlMetaContainer.Controls.Add(letterNameLabel);
            this.pnlMetaContainer.Controls.Add(letterDescEngLabel);
            this.pnlMetaContainer.Controls.Add(letterDescFreLabel);
            this.pnlMetaContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlMetaContainer.Name = "pnlMetaContainer";
            this.pnlMetaContainer.Size = new System.Drawing.Size(885, 215);
            this.pnlMetaContainer.TabIndex = 0;
            // 
            // mccLayoutStyle
            // 
            this.mccLayoutStyle.BackColor = System.Drawing.Color.White;
            this.mccLayoutStyle.Column1 = "GenericId";
            this.mccLayoutStyle.Column2 = "DescriptionEng";
            this.mccLayoutStyle.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccLayoutStyle.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.templateBindingSource, "LayoutStyle", true));
            this.mccLayoutStyle.DataSource = null;
            this.mccLayoutStyle.DDColumn1Visible = true;
            this.mccLayoutStyle.DisplayMember = "DescriptionEng";
            this.mccLayoutStyle.DisplayNameColumn1 = "";
            this.mccLayoutStyle.DisplayNameColumn2 = "";
            this.mccLayoutStyle.DropDownColumn1Width = 40;
            this.mccLayoutStyle.DropDownColumn2Width = 200;
            this.mccLayoutStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mccLayoutStyle.Location = new System.Drawing.Point(338, 32);
            this.mccLayoutStyle.Middle = 138;
            this.mccLayoutStyle.Name = "mccLayoutStyle";
            this.mccLayoutStyle.ReadOnly = false;
            this.mccLayoutStyle.ReqColor = System.Drawing.Color.White;
            this.mccLayoutStyle.SelectedValue = null;
            this.mccLayoutStyle.Size = new System.Drawing.Size(135, 22);
            this.mccLayoutStyle.TabIndex = 6;
            this.mccLayoutStyle.ValueMember = "GenericId";
            // 
            // editBox4
            // 
            this.editBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.templateBindingSource, "LetterHeadName", true));
            this.editBox4.Location = new System.Drawing.Point(109, 32);
            this.editBox4.Name = "editBox4";
            this.editBox4.Size = new System.Drawing.Size(174, 21);
            this.editBox4.TabIndex = 4;
            this.editBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // mccCommType
            // 
            this.mccCommType.BackColor = System.Drawing.Color.White;
            this.mccCommType.Column1 = "DocTypeCode";
            this.mccCommType.Column2 = "DocDescEng";
            this.mccCommType.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccCommType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.templateBindingSource, "DocType", true));
            this.mccCommType.DataSource = null;
            this.mccCommType.DDColumn1Visible = true;
            this.mccCommType.DisplayMember = "DocDescEng";
            this.mccCommType.DisplayNameColumn1 = "";
            this.mccCommType.DisplayNameColumn2 = "";
            this.mccCommType.DropDownColumn1Width = 40;
            this.mccCommType.DropDownColumn2Width = 150;
            this.mccCommType.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mccCommType.Location = new System.Drawing.Point(336, 187);
            this.mccCommType.Middle = 138;
            this.mccCommType.Name = "mccCommType";
            this.mccCommType.ReadOnly = false;
            this.mccCommType.ReqColor = System.Drawing.Color.White;
            this.mccCommType.SelectedValue = null;
            this.mccCommType.Size = new System.Drawing.Size(135, 22);
            this.mccCommType.TabIndex = 27;
            this.mccCommType.ValueMember = "DocTypeCode";
            // 
            // ebBaseTemplate
            // 
            this.ebBaseTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.ebBaseTemplate.Location = new System.Drawing.Point(107, 134);
            this.ebBaseTemplate.Name = "ebBaseTemplate";
            this.ebBaseTemplate.ReadOnly = true;
            this.ebBaseTemplate.Size = new System.Drawing.Size(135, 21);
            this.ebBaseTemplate.TabIndex = 17;
            this.ebBaseTemplate.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gridEX2
            // 
            this.gridEX2.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX2.AlternatingColors = true;
            this.gridEX2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridEX2_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_0.Instance")));
            gridEX2_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_1.Instance")));
            gridEX2_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_2.Instance")));
            gridEX2_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_3.Instance")));
            gridEX2_DesignTimeLayout_Reference_4.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_4.Instance")));
            gridEX2_DesignTimeLayout_Reference_5.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_5.Instance")));
            gridEX2_DesignTimeLayout_Reference_6.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_6.Instance")));
            gridEX2_DesignTimeLayout_Reference_7.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_7.Instance")));
            gridEX2_DesignTimeLayout_Reference_8.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_8.Instance")));
            gridEX2_DesignTimeLayout_Reference_9.Instance = ((object)(resources.GetObject("gridEX2_DesignTimeLayout_Reference_9.Instance")));
            gridEX2_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gridEX2_DesignTimeLayout_Reference_0,
            gridEX2_DesignTimeLayout_Reference_1,
            gridEX2_DesignTimeLayout_Reference_2,
            gridEX2_DesignTimeLayout_Reference_3,
            gridEX2_DesignTimeLayout_Reference_4,
            gridEX2_DesignTimeLayout_Reference_5,
            gridEX2_DesignTimeLayout_Reference_6,
            gridEX2_DesignTimeLayout_Reference_7,
            gridEX2_DesignTimeLayout_Reference_8,
            gridEX2_DesignTimeLayout_Reference_9});
            gridEX2_DesignTimeLayout.LayoutString = resources.GetString("gridEX2_DesignTimeLayout.LayoutString");
            this.gridEX2.DesignTimeLayout = gridEX2_DesignTimeLayout;
            this.gridEX2.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.gridEX2.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.gridEX2.GroupByBoxVisible = false;
            this.gridEX2.Location = new System.Drawing.Point(485, 9);
            this.gridEX2.Name = "gridEX2";
            this.gridEX2.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.gridEX2.Size = new System.Drawing.Size(392, 203);
            this.gridEX2.TabIndex = 22;
            this.gridEX2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEX2.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gridEX2_LinkClicked);
            // 
            // tagEditBox
            // 
            this.tagEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.tagEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.templateBindingSource, "Tag", true));
            this.tagEditBox.Location = new System.Drawing.Point(107, 188);
            this.tagEditBox.Name = "tagEditBox";
            this.tagEditBox.ReadOnly = true;
            this.tagEditBox.Size = new System.Drawing.Size(135, 21);
            this.tagEditBox.TabIndex = 25;
            this.tagEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // importedDateCalendarCombo
            // 
            this.importedDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.importedDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd hh:mm tt";
            this.importedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.templateBindingSource, "ImportedDate", true));
            this.importedDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.importedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.importedDateCalendarCombo.Location = new System.Drawing.Point(336, 161);
            this.importedDateCalendarCombo.Name = "importedDateCalendarCombo";
            this.importedDateCalendarCombo.ReadOnly = true;
            this.importedDateCalendarCombo.Size = new System.Drawing.Size(135, 21);
            this.importedDateCalendarCombo.TabIndex = 23;
            this.importedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // exportedDateCalendarCombo
            // 
            this.exportedDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.exportedDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd hh:mm tt";
            this.exportedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.templateBindingSource, "ExportedDate", true));
            this.exportedDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.exportedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.exportedDateCalendarCombo.Location = new System.Drawing.Point(107, 161);
            this.exportedDateCalendarCombo.Name = "exportedDateCalendarCombo";
            this.exportedDateCalendarCombo.ReadOnly = true;
            this.exportedDateCalendarCombo.Size = new System.Drawing.Size(135, 21);
            this.exportedDateCalendarCombo.TabIndex = 21;
            this.exportedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // flagForExportUICheckBox
            // 
            this.flagForExportUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.flagForExportUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.flagForExportUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.templateBindingSource, "FlagForExport", true));
            this.flagForExportUICheckBox.Location = new System.Drawing.Point(336, 4);
            this.flagForExportUICheckBox.Name = "flagForExportUICheckBox";
            this.flagForExportUICheckBox.Size = new System.Drawing.Size(137, 23);
            this.flagForExportUICheckBox.TabIndex = 2;
            this.flagForExportUICheckBox.Text = "Flagged for Export:";
            this.flagForExportUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiCheckBox5
            // 
            this.uiCheckBox5.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox5.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.templateBindingSource, "Agent", true));
            this.uiCheckBox5.Location = new System.Drawing.Point(394, 111);
            this.uiCheckBox5.Name = "uiCheckBox5";
            this.uiCheckBox5.Size = new System.Drawing.Size(77, 19);
            this.uiCheckBox5.TabIndex = 15;
            this.uiCheckBox5.Text = "List 4";
            this.uiCheckBox5.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiCheckBox4
            // 
            this.uiCheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox4.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.templateBindingSource, "HQ", true));
            this.uiCheckBox4.Location = new System.Drawing.Point(321, 110);
            this.uiCheckBox4.Name = "uiCheckBox4";
            this.uiCheckBox4.Size = new System.Drawing.Size(55, 19);
            this.uiCheckBox4.TabIndex = 14;
            this.uiCheckBox4.Text = "List 3";
            this.uiCheckBox4.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiCheckBox3
            // 
            this.uiCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox3.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.templateBindingSource, "AboutAgent", true));
            this.uiCheckBox3.Location = new System.Drawing.Point(221, 110);
            this.uiCheckBox3.Name = "uiCheckBox3";
            this.uiCheckBox3.Size = new System.Drawing.Size(53, 19);
            this.uiCheckBox3.TabIndex = 13;
            this.uiCheckBox3.Text = "List 2";
            this.uiCheckBox3.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiCheckBox2
            // 
            this.uiCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox2.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.templateBindingSource, "AboutDebtor", true));
            this.uiCheckBox2.Location = new System.Drawing.Point(107, 110);
            this.uiCheckBox2.Name = "uiCheckBox2";
            this.uiCheckBox2.Size = new System.Drawing.Size(54, 19);
            this.uiCheckBox2.TabIndex = 12;
            this.uiCheckBox2.Text = "List 1";
            this.uiCheckBox2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.templateBindingSource, "Obsolete", true));
            this.uiCheckBox1.Location = new System.Drawing.Point(401, 136);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Size = new System.Drawing.Size(70, 19);
            this.uiCheckBox1.TabIndex = 19;
            this.uiCheckBox1.Text = "Obsolete:";
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // checkReadOnly
            // 
            this.checkReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.checkReadOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkReadOnly.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.templateBindingSource, "ReadOnly", true));
            this.checkReadOnly.Location = new System.Drawing.Point(301, 136);
            this.checkReadOnly.Name = "checkReadOnly";
            this.checkReadOnly.Size = new System.Drawing.Size(75, 19);
            this.checkReadOnly.TabIndex = 18;
            this.checkReadOnly.Text = "Read-Only:";
            this.checkReadOnly.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // editBox3
            // 
            this.editBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.templateBindingSource, "LetterDescFre", true));
            this.editBox3.Location = new System.Drawing.Point(109, 86);
            this.editBox3.Name = "editBox3";
            this.editBox3.Size = new System.Drawing.Size(364, 21);
            this.editBox3.TabIndex = 10;
            this.editBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox2
            // 
            this.editBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.templateBindingSource, "LetterDescEng", true));
            this.editBox2.Location = new System.Drawing.Point(109, 59);
            this.editBox2.Name = "editBox2";
            this.editBox2.Size = new System.Drawing.Size(364, 21);
            this.editBox2.TabIndex = 8;
            this.editBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox1
            // 
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.templateBindingSource, "LetterName", true));
            this.editBox1.Location = new System.Drawing.Point(109, 6);
            this.editBox1.Name = "editBox1";
            this.editBox1.Size = new System.Drawing.Size(174, 21);
            this.editBox1.TabIndex = 1;
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // pnlContainer
            // 
            this.pnlContainer.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlContainer.Location = new System.Drawing.Point(576, 274);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(887, 464);
            this.pnlContainer.TabIndex = 4;
            // 
            // pnlContents
            // 
            this.pnlContents.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlContents.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlContents.InnerContainer = this.pnlContentsContainer;
            this.pnlContents.Location = new System.Drawing.Point(0, 0);
            this.pnlContents.Name = "pnlContents";
            this.pnlContents.Size = new System.Drawing.Size(887, 464);
            this.pnlContents.TabIndex = 0;
            this.pnlContents.Text = "Template Contents";
            // 
            // pnlContentsContainer
            // 
            this.pnlContentsContainer.Controls.Add(this.ucDoc1);
            this.pnlContentsContainer.Controls.Add(this.TopRebar2);
            this.pnlContentsContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlContentsContainer.Name = "pnlContentsContainer";
            this.pnlContentsContainer.Size = new System.Drawing.Size(885, 462);
            this.pnlContentsContainer.TabIndex = 0;
            // 
            // ucDoc1
            // 
            this.ucDoc1.AllowActionToolbar = false;
            this.ucDoc1.AllowRecipientSubjectEditWhenNotMail = false;
            this.ucDoc1.AllowUserCompose = true;
            this.ucDoc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDoc1.EditMode = LawMate.UserControls.ucDoc.EditModeEnum.Read;
            this.ucDoc1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucDoc1.ForceTextControl = true;
            this.ucDoc1.IsManageTemplates = true;
            this.ucDoc1.Location = new System.Drawing.Point(0, 28);
            this.ucDoc1.Name = "ucDoc1";
            this.ucDoc1.NoDocDisplayed = false;
            this.ucDoc1.ShowAttachmentPanel = false;
            this.ucDoc1.ShowComposeToolbar = false;
            this.ucDoc1.ShowFromAndDate = true;
            this.ucDoc1.ShowRecipients = false;
            this.ucDoc1.ShowSubject = true;
            this.ucDoc1.ShowTabs = false;
            this.ucDoc1.Size = new System.Drawing.Size(885, 434);
            this.ucDoc1.TabIndex = 0;
            this.ucDoc1.TempFile = null;
            this.ucDoc1.TempFld = null;
            // 
            // TopRebar2
            // 
            this.TopRebar2.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2});
            this.TopRebar2.CommandManager = this.uiCommandManager2;
            this.TopRebar2.Controls.Add(this.uiCommandBar2);
            this.TopRebar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar2.Location = new System.Drawing.Point(0, 0);
            this.TopRebar2.Name = "TopRebar2";
            this.TopRebar2.Size = new System.Drawing.Size(885, 28);
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandManager = this.uiCommandManager2;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdTitle1,
            this.Separator1,
            this.cmdLinkToDifferentDoc1,
            this.cmdEditContents1,
            this.Separator4,
            this.cmdInsertTag1,
            this.cmdVerifyDocTag1});
            this.uiCommandBar2.FullRow = true;
            this.uiCommandBar2.Key = "CommandBar1";
            this.uiCommandBar2.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.RowIndex = 0;
            this.uiCommandBar2.Size = new System.Drawing.Size(885, 28);
            this.uiCommandBar2.Text = "CommandBar1";
            // 
            // uiCommandManager2
            // 
            this.uiCommandManager2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager2.AllowMerge = false;
            this.uiCommandManager2.AlwaysShowFullMenus = true;
            this.uiCommandManager2.BottomRebar = this.BottomRebar2;
            this.uiCommandManager2.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2});
            this.uiCommandManager2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdLinkToDifferentDoc,
            this.cmdEditContents,
            this.cmdInsertTag,
            this.cmdVerifyDocTag,
            this.cmdTitle});
            this.uiCommandManager2.ContainerControl = this.pnlContentsContainer;
            // 
            // 
            // 
            this.uiCommandManager2.EditContextMenu.Key = "";
            this.uiCommandManager2.Id = new System.Guid("4dc5e7d0-63ea-4ba8-86e0-68ac1c687b83");
            this.uiCommandManager2.LeftRebar = this.LeftRebar2;
            this.uiCommandManager2.LockCommandBars = true;
            this.uiCommandManager2.RightRebar = this.RightRebar2;
            this.uiCommandManager2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager2.ShowQuickCustomizeMenu = false;
            this.uiCommandManager2.TopRebar = this.TopRebar2;
            this.uiCommandManager2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager2.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager2_CommandClick);
            // 
            // BottomRebar2
            // 
            this.BottomRebar2.CommandManager = this.uiCommandManager2;
            this.BottomRebar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar2.Location = new System.Drawing.Point(0, 668);
            this.BottomRebar2.Name = "BottomRebar2";
            this.BottomRebar2.Size = new System.Drawing.Size(1179, 0);
            // 
            // cmdLinkToDifferentDoc
            // 
            this.cmdLinkToDifferentDoc.Image = ((System.Drawing.Image)(resources.GetObject("cmdLinkToDifferentDoc.Image")));
            this.cmdLinkToDifferentDoc.Key = "cmdLinkToDifferentDoc";
            this.cmdLinkToDifferentDoc.Name = "cmdLinkToDifferentDoc";
            this.cmdLinkToDifferentDoc.Text = "Link to Different Document";
            // 
            // cmdEditContents
            // 
            this.cmdEditContents.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditContents.Image")));
            this.cmdEditContents.Key = "cmdEditContents";
            this.cmdEditContents.Name = "cmdEditContents";
            this.cmdEditContents.Text = "Edit Document Contents";
            // 
            // cmdInsertTag
            // 
            this.cmdInsertTag.Image = ((System.Drawing.Image)(resources.GetObject("cmdInsertTag.Image")));
            this.cmdInsertTag.Key = "cmdInsertTag";
            this.cmdInsertTag.Name = "cmdInsertTag";
            this.cmdInsertTag.Text = "Insert Template Tag...";
            // 
            // cmdVerifyDocTag
            // 
            this.cmdVerifyDocTag.Image = ((System.Drawing.Image)(resources.GetObject("cmdVerifyDocTag.Image")));
            this.cmdVerifyDocTag.Key = "cmdVerifyDocTag";
            this.cmdVerifyDocTag.Name = "cmdVerifyDocTag";
            this.cmdVerifyDocTag.Text = "Verify Tags";
            // 
            // cmdTitle
            // 
            this.cmdTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.cmdTitle.Key = "cmdTitle";
            this.cmdTitle.Name = "cmdTitle";
            this.cmdTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.cmdTitle.Text = "Document Contents";
            // 
            // LeftRebar2
            // 
            this.LeftRebar2.CommandManager = this.uiCommandManager2;
            this.LeftRebar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar2.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar2.Name = "LeftRebar2";
            this.LeftRebar2.Size = new System.Drawing.Size(0, 668);
            // 
            // RightRebar2
            // 
            this.RightRebar2.CommandManager = this.uiCommandManager2;
            this.RightRebar2.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar2.Location = new System.Drawing.Point(1179, 0);
            this.RightRebar2.Name = "RightRebar2";
            this.RightRebar2.Size = new System.Drawing.Size(0, 668);
            // 
            // cmdTitle1
            // 
            this.cmdTitle1.Key = "cmdTitle";
            this.cmdTitle1.Name = "cmdTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdLinkToDifferentDoc1
            // 
            this.cmdLinkToDifferentDoc1.Key = "cmdLinkToDifferentDoc";
            this.cmdLinkToDifferentDoc1.Name = "cmdLinkToDifferentDoc1";
            // 
            // cmdEditContents1
            // 
            this.cmdEditContents1.Key = "cmdEditContents";
            this.cmdEditContents1.Name = "cmdEditContents1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator4.Key = "Separator";
            this.Separator4.Name = "Separator4";
            // 
            // cmdInsertTag1
            // 
            this.cmdInsertTag1.Key = "cmdInsertTag";
            this.cmdInsertTag1.Name = "cmdInsertTag1";
            // 
            // cmdVerifyDocTag1
            // 
            this.cmdVerifyDocTag1.Key = "cmdVerifyDocTag";
            this.cmdVerifyDocTag1.Name = "cmdVerifyDocTag1";
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
            this.cmdNewRTFTemplate,
            this.cmdNewHTMLTemplate,
            this.cmdNewTextTemplate,
            this.cmdExport,
            this.cmdImport,
            this.cmdClone,
            this.cmdPreviewDoc,
            this.cmdClearSelectedDocs,
            this.cmdSelectAllFlaggedDocs,
            this.cmdFlagCont,
            this.cmdImportExport,
            this.cmdChangeCode});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("e3dbf5b1-40fb-4af3-bf7e-799d035cc694");
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
            this.BottomRebar1.Location = new System.Drawing.Point(0, 671);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(1206, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNew1,
            this.Separator2,
            this.cmdSave1,
            this.Separator5,
            this.cmdCancel1,
            this.Separator6,
            this.cmdDelete1,
            this.Separator7,
            this.cmdClone1,
            this.Separator3,
            this.cmdFlagCont1,
            this.Separator9,
            this.cmdImportExport1,
            this.Separator10,
            this.cmdPreviewDoc1,
            this.cmdChangeCode1});
            this.uiCommandBar1.FloatingLocation = new System.Drawing.Point(148, 408);
            this.uiCommandBar1.FloatingSize = new System.Drawing.Size(604, 22);
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowToolTips = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Size = new System.Drawing.Size(1466, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdNew1
            // 
            this.cmdNew1.Key = "cmdNew";
            this.cmdNew1.Name = "cmdNew1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.Name = "Separator2";
            // 
            // cmdSave1
            // 
            this.cmdSave1.Key = "cmdSave";
            this.cmdSave1.Name = "cmdSave1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator5.Key = "Separator";
            this.Separator5.Name = "Separator5";
            // 
            // cmdCancel1
            // 
            this.cmdCancel1.Key = "cmdCancel";
            this.cmdCancel1.Name = "cmdCancel1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator6.Key = "Separator";
            this.Separator6.Name = "Separator6";
            // 
            // cmdDelete1
            // 
            this.cmdDelete1.Key = "cmdDelete";
            this.cmdDelete1.Name = "cmdDelete1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator7.Key = "Separator";
            this.Separator7.Name = "Separator7";
            // 
            // cmdClone1
            // 
            this.cmdClone1.Key = "cmdClone";
            this.cmdClone1.Name = "cmdClone1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator3.Key = "Separator";
            this.Separator3.Name = "Separator3";
            // 
            // cmdFlagCont1
            // 
            this.cmdFlagCont1.Key = "cmdFlagCont";
            this.cmdFlagCont1.Name = "cmdFlagCont1";
            // 
            // Separator9
            // 
            this.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator9.Key = "Separator";
            this.Separator9.Name = "Separator9";
            // 
            // cmdImportExport1
            // 
            this.cmdImportExport1.Key = "cmdImportExport";
            this.cmdImportExport1.Name = "cmdImportExport1";
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator10.Key = "Separator";
            this.Separator10.Name = "Separator10";
            // 
            // cmdPreviewDoc1
            // 
            this.cmdPreviewDoc1.Key = "cmdPreviewDoc";
            this.cmdPreviewDoc1.Name = "cmdPreviewDoc1";
            // 
            // cmdChangeCode1
            // 
            this.cmdChangeCode1.Key = "cmdChangeCode";
            this.cmdChangeCode1.Name = "cmdChangeCode1";
            // 
            // cmdSave
            // 
            this.cmdSave.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Key = "cmdSave";
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Text = "Save";
            this.cmdSave.ToolTipText = "Save changes to current document";
            // 
            // cmdCancel
            // 
            this.cmdCancel.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Key = "cmdCancel";
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.ToolTipText = "Cancel changes to current document";
            // 
            // cmdNew
            // 
            this.cmdNew.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNewRTFTemplate1,
            this.cmdNewHTMLTemplate1,
            this.cmdNewTextTemplate1});
            this.cmdNew.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdNew.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            this.cmdNew.Image = ((System.Drawing.Image)(resources.GetObject("cmdNew.Image")));
            this.cmdNew.Key = "cmdNew";
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Text = "New";
            // 
            // cmdNewRTFTemplate1
            // 
            this.cmdNewRTFTemplate1.Key = "cmdNewRTFTemplate";
            this.cmdNewRTFTemplate1.Name = "cmdNewRTFTemplate1";
            // 
            // cmdNewHTMLTemplate1
            // 
            this.cmdNewHTMLTemplate1.Key = "cmdNewHTMLTemplate";
            this.cmdNewHTMLTemplate1.Name = "cmdNewHTMLTemplate1";
            // 
            // cmdNewTextTemplate1
            // 
            this.cmdNewTextTemplate1.Key = "cmdNewTextTemplate";
            this.cmdNewTextTemplate1.Name = "cmdNewTextTemplate1";
            // 
            // cmdDelete
            // 
            this.cmdDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.Key = "cmdDelete";
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.ToolTipText = "Delete the currently selected document";
            // 
            // cmdNewRTFTemplate
            // 
            this.cmdNewRTFTemplate.Key = "cmdNewRTFTemplate";
            this.cmdNewRTFTemplate.Name = "cmdNewRTFTemplate";
            this.cmdNewRTFTemplate.Text = "RTF Template";
            // 
            // cmdNewHTMLTemplate
            // 
            this.cmdNewHTMLTemplate.Key = "cmdNewHTMLTemplate";
            this.cmdNewHTMLTemplate.Name = "cmdNewHTMLTemplate";
            this.cmdNewHTMLTemplate.Text = "HTML Template";
            // 
            // cmdNewTextTemplate
            // 
            this.cmdNewTextTemplate.Key = "cmdNewTextTemplate";
            this.cmdNewTextTemplate.Name = "cmdNewTextTemplate";
            this.cmdNewTextTemplate.Text = "Plain Text Template";
            // 
            // cmdExport
            // 
            this.cmdExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport.Image")));
            this.cmdExport.Key = "cmdExport";
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Text = "Export Selected Documents";
            // 
            // cmdImport
            // 
            this.cmdImport.Image = ((System.Drawing.Image)(resources.GetObject("cmdImport.Image")));
            this.cmdImport.Key = "cmdImport";
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Text = "Import Template XML File";
            // 
            // cmdClone
            // 
            this.cmdClone.Image = ((System.Drawing.Image)(resources.GetObject("cmdClone.Image")));
            this.cmdClone.Key = "cmdClone";
            this.cmdClone.Name = "cmdClone";
            this.cmdClone.Text = "Clone Template";
            // 
            // cmdPreviewDoc
            // 
            this.cmdPreviewDoc.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdPreviewDoc.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            this.cmdPreviewDoc.Image = ((System.Drawing.Image)(resources.GetObject("cmdPreviewDoc.Image")));
            this.cmdPreviewDoc.Key = "cmdPreviewDoc";
            this.cmdPreviewDoc.Name = "cmdPreviewDoc";
            this.cmdPreviewDoc.Text = "Display Document Contents";
            // 
            // cmdClearSelectedDocs
            // 
            this.cmdClearSelectedDocs.Image = ((System.Drawing.Image)(resources.GetObject("cmdClearSelectedDocs.Image")));
            this.cmdClearSelectedDocs.Key = "cmdClearSelectedDocs";
            this.cmdClearSelectedDocs.Name = "cmdClearSelectedDocs";
            this.cmdClearSelectedDocs.Text = "Clear Selected Documents";
            // 
            // cmdSelectAllFlaggedDocs
            // 
            this.cmdSelectAllFlaggedDocs.Image = ((System.Drawing.Image)(resources.GetObject("cmdSelectAllFlaggedDocs.Image")));
            this.cmdSelectAllFlaggedDocs.Key = "cmdSelectAllFlaggedDocs";
            this.cmdSelectAllFlaggedDocs.Name = "cmdSelectAllFlaggedDocs";
            this.cmdSelectAllFlaggedDocs.Text = "Select All Flagged Templates";
            // 
            // cmdFlagCont
            // 
            this.cmdFlagCont.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSelectAllFlaggedDocs1,
            this.cmdClearSelectedDocs1});
            this.cmdFlagCont.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            this.cmdFlagCont.Image = ((System.Drawing.Image)(resources.GetObject("cmdFlagCont.Image")));
            this.cmdFlagCont.Key = "cmdFlagCont";
            this.cmdFlagCont.Name = "cmdFlagCont";
            this.cmdFlagCont.Text = "Select";
            // 
            // cmdSelectAllFlaggedDocs1
            // 
            this.cmdSelectAllFlaggedDocs1.Key = "cmdSelectAllFlaggedDocs";
            this.cmdSelectAllFlaggedDocs1.Name = "cmdSelectAllFlaggedDocs1";
            // 
            // cmdClearSelectedDocs1
            // 
            this.cmdClearSelectedDocs1.Key = "cmdClearSelectedDocs";
            this.cmdClearSelectedDocs1.Name = "cmdClearSelectedDocs1";
            // 
            // cmdImportExport
            // 
            this.cmdImportExport.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdExport1,
            this.Separator8,
            this.cmdImport1});
            this.cmdImportExport.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            this.cmdImportExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportExport.Image")));
            this.cmdImportExport.Key = "cmdImportExport";
            this.cmdImportExport.Name = "cmdImportExport";
            this.cmdImportExport.Text = "Import / Export";
            // 
            // cmdExport1
            // 
            this.cmdExport1.Key = "cmdExport";
            this.cmdExport1.Name = "cmdExport1";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator8.Key = "Separator";
            this.Separator8.Name = "Separator8";
            // 
            // cmdImport1
            // 
            this.cmdImport1.Key = "cmdImport";
            this.cmdImport1.Name = "cmdImport1";
            // 
            // cmdChangeCode
            // 
            this.cmdChangeCode.Key = "cmdChangeCode";
            this.cmdChangeCode.Name = "cmdChangeCode";
            this.cmdChangeCode.Text = "Change Code";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 28);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 643);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(1206, 28);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 643);
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
            this.TopRebar1.Size = new System.Drawing.Size(1466, 28);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmdSave2
            // 
            this.cmdSave2.Key = "cmdSave";
            this.cmdSave2.Name = "cmdSave2";
            // 
            // timFMHeartbeat
            // 
            this.timFMHeartbeat.Enabled = true;
            this.timFMHeartbeat.Interval = 10000;
            this.timFMHeartbeat.Tick += new System.EventHandler(this.timFMHeartbeat_Tick);
            // 
            // fTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 741);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMeta);
            this.Controls.Add(this.pnlTagParse);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fTemplates";
            this.Text = "Document Templates";
            this.Load += new System.EventHandler(this.fTemplates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.templateGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTagParse)).EndInit();
            this.pnlTagParse.ResumeLayout(false);
            this.pnlTagParseContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMeta)).EndInit();
            this.pnlMeta.ResumeLayout(false);
            this.pnlMetaContainer.ResumeLayout(false);
            this.pnlMetaContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContents)).EndInit();
            this.pnlContents.ResumeLayout(false);
            this.pnlContentsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar2)).EndInit();
            this.TopRebar2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar2)).EndInit();
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
        private Janus.Windows.GridEX.GridEX templateGridEX;
        private System.Windows.Forms.BindingSource templateBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlLeft;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLeftContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlMeta;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlMetaContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlContents;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlContentsContainer;
        private UserControls.ucDoc ucDoc1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNew1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.Dock.UIPanel pnlTagParse;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTagParseContainer;
        private System.Windows.Forms.ListBox lbTagVerify;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewRTFTemplate1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewHTMLTemplate1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewTextTemplate1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewRTFTemplate;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewHTMLTemplate;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewTextTemplate;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
        private Janus.Windows.EditControls.UICheckBox checkReadOnly;
        private Janus.Windows.GridEX.EditControls.EditBox editBox3;
        private Janus.Windows.GridEX.EditControls.EditBox editBox2;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager2;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkToDifferentDoc;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditContents;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertTag;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar2;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdLinkToDifferentDoc1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditContents1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertTag1;
        private Janus.Windows.UI.CommandBars.UICommand cmdVerifyDocTag;
        private Janus.Windows.UI.CommandBars.UICommand cmdVerifyDocTag1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTitle;
        private Janus.Windows.UI.CommandBars.UICommand cmdTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExport;
        private Janus.Windows.UI.CommandBars.UICommand cmdImport;
        private Janus.Windows.UI.CommandBars.UICommand cmdClone;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdClone1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdPreviewDoc;
        private Janus.Windows.UI.CommandBars.UICommand cmdClearSelectedDocs;
        private Janus.Windows.UI.CommandBars.UICommand Separator9;
        private Janus.Windows.UI.CommandBars.UICommand cmdPreviewDoc1;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox5;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox4;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox3;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox2;
        private Janus.Windows.EditControls.UICheckBox flagForExportUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo importedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo exportedDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox tagEditBox;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectAllFlaggedDocs;
        private Janus.Windows.UI.CommandBars.UICommand cmdFlagCont;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectAllFlaggedDocs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdClearSelectedDocs1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFlagCont1;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportExport;
        private Janus.Windows.UI.CommandBars.UICommand cmdExport1;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.UI.CommandBars.UICommand cmdImport1;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportExport1;
        private Janus.Windows.GridEX.GridEX gridEX2;
        private Janus.Windows.GridEX.EditControls.EditBox ebBaseTemplate;
        private Janus.Windows.UI.CommandBars.UICommand cmdChangeCode;
        private Janus.Windows.UI.CommandBars.UICommand cmdChangeCode1;
        private System.Windows.Forms.Timer timFMHeartbeat;
        private UserControls.ucMultiDropDown mccCommType;
        private Janus.Windows.GridEX.EditControls.EditBox editBox4;
        private UserControls.ucMultiDropDown mccLayoutStyle;
    }
}