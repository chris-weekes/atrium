using System.Data;
 namespace LawMate
{
    partial class ucEFile
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
                FM.DB.EFile.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.EFile.OnUpdate -= new atLogic.UpdateEventHandler(EFile_OnUpdate);

                this.eFileBindingSource.CurrentChanged -= new System.EventHandler(this.eFileBindingSource_CurrentChanged);
                this.uiCommandManager1.CommandClick -= new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEFile));
            System.Windows.Forms.Label statusCodeLabel;
            System.Windows.Forms.Label fileNumberLabel;
            System.Windows.Forms.Label fileTypeLabel;
            System.Windows.Forms.Label descriptionELabel;
            System.Windows.Forms.Label descriptionFLabel;
            System.Windows.Forms.Label nameELabel;
            System.Windows.Forms.Label nameFLabel;
            System.Windows.Forms.Label fullPathLabel;
            System.Windows.Forms.Label fullFileNumberLabel;
            System.Windows.Forms.Label archiveDateLabel;
            System.Windows.Forms.Label openedDateLabel;
            System.Windows.Forms.Label closedDateLabel;
            System.Windows.Forms.Label closeCodeLabel;
            System.Windows.Forms.Label metaTypeLabel;
            System.Windows.Forms.Label subFileNumMinLabel;
            System.Windows.Forms.Label importantMsgLabel;
            System.Windows.Forms.Label LocationLabel;
            System.Windows.Forms.Label dispositionLabel;
            System.Windows.Forms.Label languageCodeLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label accessionNumberLabel1;
            System.Windows.Forms.Label roomLabel1;
            System.Windows.Forms.Label bayLabel1;
            System.Windows.Forms.Label boxNumberLabel1;
            Janus.Windows.GridEX.GridEXLayout fileAKAGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.atriumDB = new lmDatasets.atriumDB();
            this.eFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.fileAKAGridEX = new Janus.Windows.GridEX.GridEX();
            this.fileAKABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbArchiving = new Janus.Windows.EditControls.UIGroupBox();
            this.accessionNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.archiveBatchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.bayEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.roomEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.dispositionIducMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.temporarilyRecalledUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.archiveDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gbFileConfig = new Janus.Windows.EditControls.UIGroupBox();
            this.locationIducMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.riskManageChildrenUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.riskManageUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.subFileNumMaxEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.subFileNumMinEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.fullPathEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.hasPaperFileUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.fileIdEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.calPeriodStartDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.mccPeriod = new LawMate.UserControls.ucMultiDropDown();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.ucSecurity = new LawMate.UserControls.ucMultiDropDown();
            this.ucMultiDropDown3 = new LawMate.UserControls.ucMultiDropDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gbEfileInfo = new Janus.Windows.EditControls.UIGroupBox();
            this.fullFileNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.fileNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.fileNumberCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ucClosureCodeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucStatusCodeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucFileTypeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.openedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.closedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucMetaTypeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.gbNameDescription = new Janus.Windows.EditControls.UIGroupBox();
            this.importantMsgEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.descriptionFEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.descriptionEEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.nameFEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.nameEEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.NameFCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.NameECounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.codesDB = new lmDatasets.CodesDB();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode2 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsResetFileStruct3 = new Janus.Windows.UI.CommandBars.UICommand("tsResetFileStruct");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSecurity3 = new Janus.Windows.UI.CommandBars.UICommand("tsSecurity");
            this.cmdFileAccess1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFileAccess");
            this.tsDump3 = new Janus.Windows.UI.CommandBars.UICommand("tsDump");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit2 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.Separator9 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsResetFileStruct = new Janus.Windows.UI.CommandBars.UICommand("tsResetFileStruct");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsSecurity = new Janus.Windows.UI.CommandBars.UICommand("tsSecurity");
            this.tsDump = new Janus.Windows.UI.CommandBars.UICommand("tsDump");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave3 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.tsResetFileStruct2 = new Janus.Windows.UI.CommandBars.UICommand("tsResetFileStruct");
            this.tsSecurity2 = new Janus.Windows.UI.CommandBars.UICommand("tsSecurity");
            this.tsDump2 = new Janus.Windows.UI.CommandBars.UICommand("tsDump");
            this.cmdFileAccess = new Janus.Windows.UI.CommandBars.UICommand("cmdFileAccess");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            statusCodeLabel = new System.Windows.Forms.Label();
            fileNumberLabel = new System.Windows.Forms.Label();
            fileTypeLabel = new System.Windows.Forms.Label();
            descriptionELabel = new System.Windows.Forms.Label();
            descriptionFLabel = new System.Windows.Forms.Label();
            nameELabel = new System.Windows.Forms.Label();
            nameFLabel = new System.Windows.Forms.Label();
            fullPathLabel = new System.Windows.Forms.Label();
            fullFileNumberLabel = new System.Windows.Forms.Label();
            archiveDateLabel = new System.Windows.Forms.Label();
            openedDateLabel = new System.Windows.Forms.Label();
            closedDateLabel = new System.Windows.Forms.Label();
            closeCodeLabel = new System.Windows.Forms.Label();
            metaTypeLabel = new System.Windows.Forms.Label();
            subFileNumMinLabel = new System.Windows.Forms.Label();
            importantMsgLabel = new System.Windows.Forms.Label();
            LocationLabel = new System.Windows.Forms.Label();
            dispositionLabel = new System.Windows.Forms.Label();
            languageCodeLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            accessionNumberLabel1 = new System.Windows.Forms.Label();
            roomLabel1 = new System.Windows.Forms.Label();
            bayLabel1 = new System.Windows.Forms.Label();
            boxNumberLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileAKAGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileAKABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbArchiving)).BeginInit();
            this.gbArchiving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archiveBatchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbFileConfig)).BeginInit();
            this.gbFileConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbEfileInfo)).BeginInit();
            this.gbEfileInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbNameDescription)).BeginInit();
            this.gbNameDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codesDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.eFileBindingSource;
            // 
            // imageListBase
            // 
            this.imageListBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBase.ImageStream")));
            this.imageListBase.Images.SetKeyName(0, "");
            this.imageListBase.Images.SetKeyName(1, "");
            this.imageListBase.Images.SetKeyName(2, "");
            this.imageListBase.Images.SetKeyName(3, "");
            this.imageListBase.Images.SetKeyName(4, "");
            this.imageListBase.Images.SetKeyName(5, "");
            this.imageListBase.Images.SetKeyName(6, "");
            this.imageListBase.Images.SetKeyName(7, "");
            this.imageListBase.Images.SetKeyName(8, "");
            this.imageListBase.Images.SetKeyName(9, "");
            this.imageListBase.Images.SetKeyName(10, "");
            this.imageListBase.Images.SetKeyName(11, "");
            this.imageListBase.Images.SetKeyName(12, "");
            this.imageListBase.Images.SetKeyName(13, "");
            this.imageListBase.Images.SetKeyName(14, "");
            this.imageListBase.Images.SetKeyName(15, "");
            this.imageListBase.Images.SetKeyName(16, "");
            this.imageListBase.Images.SetKeyName(17, "");
            this.imageListBase.Images.SetKeyName(18, "resetFileStruct.gif");
            this.imageListBase.Images.SetKeyName(19, "audit.gif");
            this.imageListBase.Images.SetKeyName(20, "DRedit.gif");
            // 
            // statusCodeLabel
            // 
            resources.ApplyResources(statusCodeLabel, "statusCodeLabel");
            statusCodeLabel.Name = "statusCodeLabel";
            this.helpProvider1.SetShowHelp(statusCodeLabel, ((bool)(resources.GetObject("statusCodeLabel.ShowHelp"))));
            // 
            // fileNumberLabel
            // 
            resources.ApplyResources(fileNumberLabel, "fileNumberLabel");
            fileNumberLabel.Name = "fileNumberLabel";
            this.helpProvider1.SetShowHelp(fileNumberLabel, ((bool)(resources.GetObject("fileNumberLabel.ShowHelp"))));
            // 
            // fileTypeLabel
            // 
            resources.ApplyResources(fileTypeLabel, "fileTypeLabel");
            fileTypeLabel.Name = "fileTypeLabel";
            this.helpProvider1.SetShowHelp(fileTypeLabel, ((bool)(resources.GetObject("fileTypeLabel.ShowHelp"))));
            // 
            // descriptionELabel
            // 
            resources.ApplyResources(descriptionELabel, "descriptionELabel");
            descriptionELabel.Name = "descriptionELabel";
            this.helpProvider1.SetShowHelp(descriptionELabel, ((bool)(resources.GetObject("descriptionELabel.ShowHelp"))));
            // 
            // descriptionFLabel
            // 
            resources.ApplyResources(descriptionFLabel, "descriptionFLabel");
            descriptionFLabel.Name = "descriptionFLabel";
            this.helpProvider1.SetShowHelp(descriptionFLabel, ((bool)(resources.GetObject("descriptionFLabel.ShowHelp"))));
            // 
            // nameELabel
            // 
            resources.ApplyResources(nameELabel, "nameELabel");
            nameELabel.Name = "nameELabel";
            this.helpProvider1.SetShowHelp(nameELabel, ((bool)(resources.GetObject("nameELabel.ShowHelp"))));
            // 
            // nameFLabel
            // 
            resources.ApplyResources(nameFLabel, "nameFLabel");
            nameFLabel.Name = "nameFLabel";
            this.helpProvider1.SetShowHelp(nameFLabel, ((bool)(resources.GetObject("nameFLabel.ShowHelp"))));
            // 
            // fullPathLabel
            // 
            resources.ApplyResources(fullPathLabel, "fullPathLabel");
            fullPathLabel.Name = "fullPathLabel";
            this.helpProvider1.SetShowHelp(fullPathLabel, ((bool)(resources.GetObject("fullPathLabel.ShowHelp"))));
            // 
            // fullFileNumberLabel
            // 
            resources.ApplyResources(fullFileNumberLabel, "fullFileNumberLabel");
            fullFileNumberLabel.Name = "fullFileNumberLabel";
            this.helpProvider1.SetShowHelp(fullFileNumberLabel, ((bool)(resources.GetObject("fullFileNumberLabel.ShowHelp"))));
            // 
            // archiveDateLabel
            // 
            resources.ApplyResources(archiveDateLabel, "archiveDateLabel");
            archiveDateLabel.Name = "archiveDateLabel";
            this.helpProvider1.SetShowHelp(archiveDateLabel, ((bool)(resources.GetObject("archiveDateLabel.ShowHelp"))));
            // 
            // openedDateLabel
            // 
            resources.ApplyResources(openedDateLabel, "openedDateLabel");
            openedDateLabel.Name = "openedDateLabel";
            this.helpProvider1.SetShowHelp(openedDateLabel, ((bool)(resources.GetObject("openedDateLabel.ShowHelp"))));
            // 
            // closedDateLabel
            // 
            resources.ApplyResources(closedDateLabel, "closedDateLabel");
            closedDateLabel.Name = "closedDateLabel";
            this.helpProvider1.SetShowHelp(closedDateLabel, ((bool)(resources.GetObject("closedDateLabel.ShowHelp"))));
            // 
            // closeCodeLabel
            // 
            resources.ApplyResources(closeCodeLabel, "closeCodeLabel");
            closeCodeLabel.Name = "closeCodeLabel";
            this.helpProvider1.SetShowHelp(closeCodeLabel, ((bool)(resources.GetObject("closeCodeLabel.ShowHelp"))));
            // 
            // metaTypeLabel
            // 
            resources.ApplyResources(metaTypeLabel, "metaTypeLabel");
            metaTypeLabel.Name = "metaTypeLabel";
            this.helpProvider1.SetShowHelp(metaTypeLabel, ((bool)(resources.GetObject("metaTypeLabel.ShowHelp"))));
            // 
            // subFileNumMinLabel
            // 
            resources.ApplyResources(subFileNumMinLabel, "subFileNumMinLabel");
            subFileNumMinLabel.Name = "subFileNumMinLabel";
            this.helpProvider1.SetShowHelp(subFileNumMinLabel, ((bool)(resources.GetObject("subFileNumMinLabel.ShowHelp"))));
            // 
            // importantMsgLabel
            // 
            resources.ApplyResources(importantMsgLabel, "importantMsgLabel");
            importantMsgLabel.Name = "importantMsgLabel";
            this.helpProvider1.SetShowHelp(importantMsgLabel, ((bool)(resources.GetObject("importantMsgLabel.ShowHelp"))));
            // 
            // LocationLabel
            // 
            resources.ApplyResources(LocationLabel, "LocationLabel");
            LocationLabel.Name = "LocationLabel";
            this.helpProvider1.SetShowHelp(LocationLabel, ((bool)(resources.GetObject("LocationLabel.ShowHelp"))));
            // 
            // dispositionLabel
            // 
            resources.ApplyResources(dispositionLabel, "dispositionLabel");
            dispositionLabel.Name = "dispositionLabel";
            this.helpProvider1.SetShowHelp(dispositionLabel, ((bool)(resources.GetObject("dispositionLabel.ShowHelp"))));
            // 
            // languageCodeLabel
            // 
            resources.ApplyResources(languageCodeLabel, "languageCodeLabel");
            languageCodeLabel.Name = "languageCodeLabel";
            this.helpProvider1.SetShowHelp(languageCodeLabel, ((bool)(resources.GetObject("languageCodeLabel.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // accessionNumberLabel1
            // 
            resources.ApplyResources(accessionNumberLabel1, "accessionNumberLabel1");
            accessionNumberLabel1.Name = "accessionNumberLabel1";
            this.helpProvider1.SetShowHelp(accessionNumberLabel1, ((bool)(resources.GetObject("accessionNumberLabel1.ShowHelp"))));
            // 
            // roomLabel1
            // 
            resources.ApplyResources(roomLabel1, "roomLabel1");
            roomLabel1.Name = "roomLabel1";
            this.helpProvider1.SetShowHelp(roomLabel1, ((bool)(resources.GetObject("roomLabel1.ShowHelp"))));
            // 
            // bayLabel1
            // 
            resources.ApplyResources(bayLabel1, "bayLabel1");
            bayLabel1.Name = "bayLabel1";
            this.helpProvider1.SetShowHelp(bayLabel1, ((bool)(resources.GetObject("bayLabel1.ShowHelp"))));
            // 
            // boxNumberLabel1
            // 
            resources.ApplyResources(boxNumberLabel1, "boxNumberLabel1");
            boxNumberLabel1.Name = "boxNumberLabel1";
            this.helpProvider1.SetShowHelp(boxNumberLabel1, ((bool)(resources.GetObject("boxNumberLabel1.ShowHelp"))));
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eFileBindingSource
            // 
            this.eFileBindingSource.AllowNew = true;
            this.eFileBindingSource.DataMember = "EFile";
            this.eFileBindingSource.DataSource = this.atriumDB;
            this.eFileBindingSource.CurrentChanged += new System.EventHandler(this.eFileBindingSource_CurrentChanged);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(740, 682), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.uiGroupBox1);
            this.pnlAllContainer.Controls.Add(this.gbArchiving);
            this.pnlAllContainer.Controls.Add(this.gbFileConfig);
            this.pnlAllContainer.Controls.Add(this.gbEfileInfo);
            this.pnlAllContainer.Controls.Add(this.gbNameDescription);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(this.fileAKAGridEX);
            this.uiGroupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiGroupBox1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox1.FormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.helpProvider1.SetShowHelp(this.uiGroupBox1, ((bool)(resources.GetObject("uiGroupBox1.ShowHelp"))));
            this.uiGroupBox1.UseThemes = false;
            // 
            // fileAKAGridEX
            // 
            this.fileAKAGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.fileAKAGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.fileAKAGridEX.DataSource = this.fileAKABindingSource;
            resources.ApplyResources(fileAKAGridEX_DesignTimeLayout, "fileAKAGridEX_DesignTimeLayout");
            this.fileAKAGridEX.DesignTimeLayout = fileAKAGridEX_DesignTimeLayout;
            this.fileAKAGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.fileAKAGridEX, "fileAKAGridEX");
            this.fileAKAGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.fileAKAGridEX.GroupByBoxVisible = false;
            this.fileAKAGridEX.Name = "fileAKAGridEX";
            this.fileAKAGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.helpProvider1.SetShowHelp(this.fileAKAGridEX, ((bool)(resources.GetObject("fileAKAGridEX.ShowHelp"))));
            this.fileAKAGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.fileAKAGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.fileAKAGridEX.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.fileAKAGridEX_DeletingRecord);
            this.fileAKAGridEX.RecordsDeleted += new System.EventHandler(this.fileAKAGridEX_RecordsDeleted);
            // 
            // fileAKABindingSource
            // 
            this.fileAKABindingSource.DataMember = "EFile_FileAKA";
            this.fileAKABindingSource.DataSource = this.eFileBindingSource;
            // 
            // gbArchiving
            // 
            this.gbArchiving.BackColor = System.Drawing.Color.Transparent;
            this.gbArchiving.Controls.Add(this.accessionNumberEditBox);
            this.gbArchiving.Controls.Add(this.boxNumberEditBox);
            this.gbArchiving.Controls.Add(bayLabel1);
            this.gbArchiving.Controls.Add(this.bayEditBox);
            this.gbArchiving.Controls.Add(roomLabel1);
            this.gbArchiving.Controls.Add(this.roomEditBox);
            this.gbArchiving.Controls.Add(accessionNumberLabel1);
            this.gbArchiving.Controls.Add(this.dispositionIducMultiDropDown);
            this.gbArchiving.Controls.Add(this.temporarilyRecalledUICheckBox);
            this.gbArchiving.Controls.Add(dispositionLabel);
            this.gbArchiving.Controls.Add(this.archiveDateCalendarCombo);
            this.gbArchiving.Controls.Add(boxNumberLabel1);
            this.gbArchiving.Controls.Add(archiveDateLabel);
            this.gbArchiving.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbArchiving, "gbArchiving");
            this.gbArchiving.Name = "gbArchiving";
            this.helpProvider1.SetShowHelp(this.gbArchiving, ((bool)(resources.GetObject("gbArchiving.ShowHelp"))));
            this.gbArchiving.UseThemes = false;
            // 
            // accessionNumberEditBox
            // 
            this.accessionNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archiveBatchBindingSource, "AccessionNumber", true));
            resources.ApplyResources(this.accessionNumberEditBox, "accessionNumberEditBox");
            this.accessionNumberEditBox.Name = "accessionNumberEditBox";
            this.helpProvider1.SetShowHelp(this.accessionNumberEditBox, ((bool)(resources.GetObject("accessionNumberEditBox.ShowHelp"))));
            this.accessionNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // archiveBatchBindingSource
            // 
            this.archiveBatchBindingSource.DataMember = "ArchiveBatchEFile";
            this.archiveBatchBindingSource.DataSource = this.eFileBindingSource;
            // 
            // boxNumberEditBox
            // 
            this.boxNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "BoxAlpha", true));
            resources.ApplyResources(this.boxNumberEditBox, "boxNumberEditBox");
            this.boxNumberEditBox.Name = "boxNumberEditBox";
            this.helpProvider1.SetShowHelp(this.boxNumberEditBox, ((bool)(resources.GetObject("boxNumberEditBox.ShowHelp"))));
            this.boxNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // bayEditBox
            // 
            this.bayEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archiveBatchBindingSource, "Bay", true));
            resources.ApplyResources(this.bayEditBox, "bayEditBox");
            this.bayEditBox.Name = "bayEditBox";
            this.helpProvider1.SetShowHelp(this.bayEditBox, ((bool)(resources.GetObject("bayEditBox.ShowHelp"))));
            this.bayEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // roomEditBox
            // 
            this.roomEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.archiveBatchBindingSource, "Room", true));
            resources.ApplyResources(this.roomEditBox, "roomEditBox");
            this.roomEditBox.Name = "roomEditBox";
            this.helpProvider1.SetShowHelp(this.roomEditBox, ((bool)(resources.GetObject("roomEditBox.ShowHelp"))));
            this.roomEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // dispositionIducMultiDropDown
            // 
            this.dispositionIducMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.dispositionIducMultiDropDown.Column1 = "DispositionAuthId";
            resources.ApplyResources(this.dispositionIducMultiDropDown, "dispositionIducMultiDropDown");
            this.dispositionIducMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.dispositionIducMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "DispositionId", true));
            this.dispositionIducMultiDropDown.DataSource = null;
            this.dispositionIducMultiDropDown.DDColumn1Visible = true;
            this.dispositionIducMultiDropDown.DropDownColumn1Width = 100;
            this.dispositionIducMultiDropDown.DropDownColumn2Width = 300;
            this.dispositionIducMultiDropDown.Name = "dispositionIducMultiDropDown";
            this.dispositionIducMultiDropDown.ReadOnly = false;
            this.dispositionIducMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.dispositionIducMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.dispositionIducMultiDropDown, ((bool)(resources.GetObject("dispositionIducMultiDropDown.ShowHelp"))));
            this.dispositionIducMultiDropDown.ValueMember = "DispositionAuthId";
            // 
            // temporarilyRecalledUICheckBox
            // 
            this.temporarilyRecalledUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "TemporarilyRecalled", true));
            resources.ApplyResources(this.temporarilyRecalledUICheckBox, "temporarilyRecalledUICheckBox");
            this.temporarilyRecalledUICheckBox.Name = "temporarilyRecalledUICheckBox";
            this.helpProvider1.SetShowHelp(this.temporarilyRecalledUICheckBox, ((bool)(resources.GetObject("temporarilyRecalledUICheckBox.ShowHelp"))));
            this.temporarilyRecalledUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // archiveDateCalendarCombo
            // 
            resources.ApplyResources(this.archiveDateCalendarCombo, "archiveDateCalendarCombo");
            this.archiveDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.archiveBatchBindingSource, "ArchiveDate", true));
            this.archiveDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.archiveDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.archiveDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.archiveDateCalendarCombo.IsNullDate = true;
            this.archiveDateCalendarCombo.MonthIncrement = 0;
            this.archiveDateCalendarCombo.Name = "archiveDateCalendarCombo";
            this.archiveDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.archiveDateCalendarCombo, ((bool)(resources.GetObject("archiveDateCalendarCombo.ShowHelp"))));
            this.archiveDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.archiveDateCalendarCombo.YearIncrement = 0;
            this.archiveDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openedDateCalendarCombo_KeyDown);
            // 
            // gbFileConfig
            // 
            this.gbFileConfig.BackColor = System.Drawing.Color.Transparent;
            this.gbFileConfig.Controls.Add(this.locationIducMultiDropDown);
            this.gbFileConfig.Controls.Add(this.riskManageChildrenUICheckBox);
            this.gbFileConfig.Controls.Add(this.riskManageUICheckBox);
            this.gbFileConfig.Controls.Add(this.subFileNumMaxEditBox);
            this.gbFileConfig.Controls.Add(this.subFileNumMinEditBox);
            this.gbFileConfig.Controls.Add(this.fullPathEditBox);
            this.gbFileConfig.Controls.Add(this.hasPaperFileUICheckBox);
            this.gbFileConfig.Controls.Add(this.fileIdEditBox);
            this.gbFileConfig.Controls.Add(this.calPeriodStartDate);
            this.gbFileConfig.Controls.Add(this.mccPeriod);
            this.gbFileConfig.Controls.Add(this.lblPeriod);
            this.gbFileConfig.Controls.Add(label2);
            this.gbFileConfig.Controls.Add(this.ucSecurity);
            this.gbFileConfig.Controls.Add(label1);
            this.gbFileConfig.Controls.Add(this.ucMultiDropDown3);
            this.gbFileConfig.Controls.Add(languageCodeLabel);
            this.gbFileConfig.Controls.Add(LocationLabel);
            this.gbFileConfig.Controls.Add(subFileNumMinLabel);
            this.gbFileConfig.Controls.Add(fullPathLabel);
            this.gbFileConfig.Controls.Add(this.label4);
            this.gbFileConfig.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbFileConfig, "gbFileConfig");
            this.gbFileConfig.Name = "gbFileConfig";
            this.helpProvider1.SetShowHelp(this.gbFileConfig, ((bool)(resources.GetObject("gbFileConfig.ShowHelp"))));
            this.gbFileConfig.UseThemes = false;
            // 
            // locationIducMultiDropDown
            // 
            this.locationIducMultiDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.locationIducMultiDropDown.Column1 = "LocationId";
            resources.ApplyResources(this.locationIducMultiDropDown, "locationIducMultiDropDown");
            this.locationIducMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.locationIducMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "LocationId", true));
            this.locationIducMultiDropDown.DataSource = null;
            this.locationIducMultiDropDown.DDColumn1Visible = true;
            this.locationIducMultiDropDown.DropDownColumn1Width = 100;
            this.locationIducMultiDropDown.DropDownColumn2Width = 300;
            this.locationIducMultiDropDown.Name = "locationIducMultiDropDown";
            this.locationIducMultiDropDown.ReadOnly = false;
            this.locationIducMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.locationIducMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.locationIducMultiDropDown, ((bool)(resources.GetObject("locationIducMultiDropDown.ShowHelp"))));
            this.locationIducMultiDropDown.ValueMember = "LocationId";
            // 
            // riskManageChildrenUICheckBox
            // 
            this.riskManageChildrenUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.riskManageChildrenUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "RiskManageChildren", true));
            resources.ApplyResources(this.riskManageChildrenUICheckBox, "riskManageChildrenUICheckBox");
            this.riskManageChildrenUICheckBox.Name = "riskManageChildrenUICheckBox";
            this.helpProvider1.SetShowHelp(this.riskManageChildrenUICheckBox, ((bool)(resources.GetObject("riskManageChildrenUICheckBox.ShowHelp"))));
            this.riskManageChildrenUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // riskManageUICheckBox
            // 
            this.riskManageUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.riskManageUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "RiskManage", true));
            resources.ApplyResources(this.riskManageUICheckBox, "riskManageUICheckBox");
            this.riskManageUICheckBox.Name = "riskManageUICheckBox";
            this.helpProvider1.SetShowHelp(this.riskManageUICheckBox, ((bool)(resources.GetObject("riskManageUICheckBox.ShowHelp"))));
            this.riskManageUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // subFileNumMaxEditBox
            // 
            this.subFileNumMaxEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "SubFileNumMax", true));
            resources.ApplyResources(this.subFileNumMaxEditBox, "subFileNumMaxEditBox");
            this.subFileNumMaxEditBox.Name = "subFileNumMaxEditBox";
            this.helpProvider1.SetShowHelp(this.subFileNumMaxEditBox, ((bool)(resources.GetObject("subFileNumMaxEditBox.ShowHelp"))));
            this.subFileNumMaxEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // subFileNumMinEditBox
            // 
            this.subFileNumMinEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "SubFileNumMin", true));
            resources.ApplyResources(this.subFileNumMinEditBox, "subFileNumMinEditBox");
            this.subFileNumMinEditBox.Name = "subFileNumMinEditBox";
            this.helpProvider1.SetShowHelp(this.subFileNumMinEditBox, ((bool)(resources.GetObject("subFileNumMinEditBox.ShowHelp"))));
            this.subFileNumMinEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // fullPathEditBox
            // 
            this.fullPathEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.fullPathEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "FullPath", true));
            resources.ApplyResources(this.fullPathEditBox, "fullPathEditBox");
            this.fullPathEditBox.Name = "fullPathEditBox";
            this.fullPathEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.fullPathEditBox, ((bool)(resources.GetObject("fullPathEditBox.ShowHelp"))));
            this.fullPathEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // hasPaperFileUICheckBox
            // 
            this.hasPaperFileUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hasPaperFileUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "HasPaperFile", true));
            resources.ApplyResources(this.hasPaperFileUICheckBox, "hasPaperFileUICheckBox");
            this.hasPaperFileUICheckBox.Name = "hasPaperFileUICheckBox";
            this.helpProvider1.SetShowHelp(this.hasPaperFileUICheckBox, ((bool)(resources.GetObject("hasPaperFileUICheckBox.ShowHelp"))));
            this.hasPaperFileUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // fileIdEditBox
            // 
            this.fileIdEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.fileIdEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "FileId", true));
            resources.ApplyResources(this.fileIdEditBox, "fileIdEditBox");
            this.fileIdEditBox.Name = "fileIdEditBox";
            this.fileIdEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.fileIdEditBox, ((bool)(resources.GetObject("fileIdEditBox.ShowHelp"))));
            this.fileIdEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // calPeriodStartDate
            // 
            resources.ApplyResources(this.calPeriodStartDate, "calPeriodStartDate");
            this.calPeriodStartDate.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "PeriodStartDate", true));
            this.calPeriodStartDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calPeriodStartDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calPeriodStartDate.MonthIncrement = 0;
            this.calPeriodStartDate.Name = "calPeriodStartDate";
            this.calPeriodStartDate.Nullable = true;
            this.helpProvider1.SetShowHelp(this.calPeriodStartDate, ((bool)(resources.GetObject("calPeriodStartDate.ShowHelp"))));
            this.calPeriodStartDate.ShowNullButton = true;
            this.calPeriodStartDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calPeriodStartDate.YearIncrement = 0;
            // 
            // mccPeriod
            // 
            this.mccPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mccPeriod.Column1 = "PeriodCode";
            resources.ApplyResources(this.mccPeriod, "mccPeriod");
            this.mccPeriod.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccPeriod.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "PeriodId", true));
            this.mccPeriod.DataSource = null;
            this.mccPeriod.DDColumn1Visible = true;
            this.mccPeriod.DropDownColumn1Width = 100;
            this.mccPeriod.DropDownColumn2Width = 300;
            this.mccPeriod.Name = "mccPeriod";
            this.mccPeriod.ReadOnly = false;
            this.mccPeriod.ReqColor = System.Drawing.SystemColors.Window;
            this.mccPeriod.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccPeriod, ((bool)(resources.GetObject("mccPeriod.ShowHelp"))));
            this.mccPeriod.ValueMember = "PeriodId";
            // 
            // lblPeriod
            // 
            resources.ApplyResources(this.lblPeriod, "lblPeriod");
            this.lblPeriod.Name = "lblPeriod";
            this.helpProvider1.SetShowHelp(this.lblPeriod, ((bool)(resources.GetObject("lblPeriod.ShowHelp"))));
            // 
            // ucSecurity
            // 
            this.ucSecurity.BackColor = System.Drawing.Color.Transparent;
            this.ucSecurity.Column1 = "SecurityLevel";
            resources.ApplyResources(this.ucSecurity, "ucSecurity");
            this.ucSecurity.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucSecurity.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "Security", true));
            this.ucSecurity.DataSource = null;
            this.ucSecurity.DDColumn1Visible = true;
            this.ucSecurity.DropDownColumn1Width = 60;
            this.ucSecurity.DropDownColumn2Width = 300;
            this.ucSecurity.Name = "ucSecurity";
            this.ucSecurity.ReadOnly = false;
            this.ucSecurity.ReqColor = System.Drawing.SystemColors.Window;
            this.ucSecurity.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucSecurity, ((bool)(resources.GetObject("ucSecurity.ShowHelp"))));
            this.ucSecurity.ValueMember = "SecurityLevel";
            // 
            // ucMultiDropDown3
            // 
            this.ucMultiDropDown3.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown3.Column1 = "LanguageCode";
            resources.ApplyResources(this.ucMultiDropDown3, "ucMultiDropDown3");
            this.ucMultiDropDown3.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucMultiDropDown3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "LanguageCode", true));
            this.ucMultiDropDown3.DataSource = null;
            this.ucMultiDropDown3.DDColumn1Visible = true;
            this.ucMultiDropDown3.DropDownColumn1Width = 100;
            this.ucMultiDropDown3.DropDownColumn2Width = 300;
            this.ucMultiDropDown3.Name = "ucMultiDropDown3";
            this.ucMultiDropDown3.ReadOnly = false;
            this.ucMultiDropDown3.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown3.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMultiDropDown3, ((bool)(resources.GetObject("ucMultiDropDown3.ShowHelp"))));
            this.ucMultiDropDown3.ValueMember = "LanguageCode";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.helpProvider1.SetShowHelp(this.label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            // 
            // gbEfileInfo
            // 
            this.gbEfileInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbEfileInfo.Controls.Add(this.fullFileNumberEditBox);
            this.gbEfileInfo.Controls.Add(this.fileNumberEditBox);
            this.gbEfileInfo.Controls.Add(this.fileNumberCounter);
            this.gbEfileInfo.Controls.Add(this.ucClosureCodeMcc);
            this.gbEfileInfo.Controls.Add(this.ucStatusCodeMcc);
            this.gbEfileInfo.Controls.Add(this.ucFileTypeMcc);
            this.gbEfileInfo.Controls.Add(closedDateLabel);
            this.gbEfileInfo.Controls.Add(openedDateLabel);
            this.gbEfileInfo.Controls.Add(this.openedDateCalendarCombo);
            this.gbEfileInfo.Controls.Add(this.closedDateCalendarCombo);
            this.gbEfileInfo.Controls.Add(fullFileNumberLabel);
            this.gbEfileInfo.Controls.Add(fileNumberLabel);
            this.gbEfileInfo.Controls.Add(statusCodeLabel);
            this.gbEfileInfo.Controls.Add(this.ucMetaTypeMcc);
            this.gbEfileInfo.Controls.Add(closeCodeLabel);
            this.gbEfileInfo.Controls.Add(fileTypeLabel);
            this.gbEfileInfo.Controls.Add(metaTypeLabel);
            this.gbEfileInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbEfileInfo.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbEfileInfo.FormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.gbEfileInfo, "gbEfileInfo");
            this.gbEfileInfo.Name = "gbEfileInfo";
            this.helpProvider1.SetShowHelp(this.gbEfileInfo, ((bool)(resources.GetObject("gbEfileInfo.ShowHelp"))));
            this.gbEfileInfo.UseThemes = false;
            // 
            // fullFileNumberEditBox
            // 
            this.fullFileNumberEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.fullFileNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "FullFileNumber", true));
            resources.ApplyResources(this.fullFileNumberEditBox, "fullFileNumberEditBox");
            this.fullFileNumberEditBox.Name = "fullFileNumberEditBox";
            this.fullFileNumberEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.fullFileNumberEditBox, ((bool)(resources.GetObject("fullFileNumberEditBox.ShowHelp"))));
            this.fullFileNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // fileNumberEditBox
            // 
            this.fileNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "FileNumber", true));
            resources.ApplyResources(this.fileNumberEditBox, "fileNumberEditBox");
            this.fileNumberEditBox.Name = "fileNumberEditBox";
            this.helpProvider1.SetShowHelp(this.fileNumberEditBox, ((bool)(resources.GetObject("fileNumberEditBox.ShowHelp"))));
            this.fileNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.fileNumberEditBox.TextChanged += new System.EventHandler(this.nameETextBox_TextChanged);
            // 
            // fileNumberCounter
            // 
            this.fileNumberCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileNumberCounter.DecimalDigits = 0;
            this.fileNumberCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.fileNumberCounter, "fileNumberCounter");
            this.fileNumberCounter.MaxLength = 3;
            this.fileNumberCounter.Name = "fileNumberCounter";
            this.fileNumberCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.fileNumberCounter, ((bool)(resources.GetObject("fileNumberCounter.ShowHelp"))));
            this.fileNumberCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.fileNumberCounter.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.fileNumberCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucClosureCodeMcc
            // 
            this.ucClosureCodeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucClosureCodeMcc.Column1 = "ReturnCode";
            resources.ApplyResources(this.ucClosureCodeMcc, "ucClosureCodeMcc");
            this.ucClosureCodeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucClosureCodeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "CloseCode", true));
            this.ucClosureCodeMcc.DataSource = null;
            this.ucClosureCodeMcc.DDColumn1Visible = true;
            this.ucClosureCodeMcc.DropDownColumn1Width = 100;
            this.ucClosureCodeMcc.DropDownColumn2Width = 300;
            this.ucClosureCodeMcc.Name = "ucClosureCodeMcc";
            this.ucClosureCodeMcc.ReadOnly = false;
            this.ucClosureCodeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucClosureCodeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucClosureCodeMcc, ((bool)(resources.GetObject("ucClosureCodeMcc.ShowHelp"))));
            this.ucClosureCodeMcc.ValueMember = "ReturnCode";
            // 
            // ucStatusCodeMcc
            // 
            this.ucStatusCodeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucStatusCodeMcc.Column1 = "StatusCode";
            resources.ApplyResources(this.ucStatusCodeMcc, "ucStatusCodeMcc");
            this.ucStatusCodeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucStatusCodeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "StatusCode", true));
            this.ucStatusCodeMcc.DataSource = null;
            this.ucStatusCodeMcc.DDColumn1Visible = true;
            this.ucStatusCodeMcc.DropDownColumn1Width = 100;
            this.ucStatusCodeMcc.DropDownColumn2Width = 300;
            this.ucStatusCodeMcc.Name = "ucStatusCodeMcc";
            this.ucStatusCodeMcc.ReadOnly = false;
            this.ucStatusCodeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucStatusCodeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucStatusCodeMcc, ((bool)(resources.GetObject("ucStatusCodeMcc.ShowHelp"))));
            this.ucStatusCodeMcc.ValueMember = "StatusCode";
            // 
            // ucFileTypeMcc
            // 
            this.ucFileTypeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucFileTypeMcc.Column1 = "FileTypeCode";
            resources.ApplyResources(this.ucFileTypeMcc, "ucFileTypeMcc");
            this.ucFileTypeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucFileTypeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "FileType", true));
            this.ucFileTypeMcc.DataSource = null;
            this.ucFileTypeMcc.DDColumn1Visible = true;
            this.ucFileTypeMcc.DropDownColumn1Width = 100;
            this.ucFileTypeMcc.DropDownColumn2Width = 300;
            this.ucFileTypeMcc.Name = "ucFileTypeMcc";
            this.ucFileTypeMcc.ReadOnly = false;
            this.ucFileTypeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucFileTypeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucFileTypeMcc, ((bool)(resources.GetObject("ucFileTypeMcc.ShowHelp"))));
            this.ucFileTypeMcc.ValueMember = "FileTypeCode";
            // 
            // openedDateCalendarCombo
            // 
            resources.ApplyResources(this.openedDateCalendarCombo, "openedDateCalendarCombo");
            this.openedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "OpenedDate", true));
            this.openedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.openedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.openedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.openedDateCalendarCombo.MonthIncrement = 0;
            this.openedDateCalendarCombo.Name = "openedDateCalendarCombo";
            this.openedDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.openedDateCalendarCombo, ((bool)(resources.GetObject("openedDateCalendarCombo.ShowHelp"))));
            this.openedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.openedDateCalendarCombo.YearIncrement = 0;
            this.openedDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openedDateCalendarCombo_KeyDown);
            // 
            // closedDateCalendarCombo
            // 
            resources.ApplyResources(this.closedDateCalendarCombo, "closedDateCalendarCombo");
            this.closedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eFileBindingSource, "ClosedDate", true));
            this.closedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.closedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.closedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.closedDateCalendarCombo.MonthIncrement = 0;
            this.closedDateCalendarCombo.Name = "closedDateCalendarCombo";
            this.closedDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.closedDateCalendarCombo, ((bool)(resources.GetObject("closedDateCalendarCombo.ShowHelp"))));
            this.closedDateCalendarCombo.ShowNullButton = true;
            this.closedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.closedDateCalendarCombo.YearIncrement = 0;
            this.closedDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openedDateCalendarCombo_KeyDown);
            // 
            // ucMetaTypeMcc
            // 
            this.ucMetaTypeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucMetaTypeMcc.Column1 = "MetaTypeCode";
            resources.ApplyResources(this.ucMetaTypeMcc, "ucMetaTypeMcc");
            this.ucMetaTypeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucMetaTypeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eFileBindingSource, "MetaType", true));
            this.ucMetaTypeMcc.DataSource = null;
            this.ucMetaTypeMcc.DDColumn1Visible = true;
            this.ucMetaTypeMcc.DropDownColumn1Width = 100;
            this.ucMetaTypeMcc.DropDownColumn2Width = 300;
            this.ucMetaTypeMcc.Name = "ucMetaTypeMcc";
            this.ucMetaTypeMcc.ReadOnly = false;
            this.ucMetaTypeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMetaTypeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucMetaTypeMcc, ((bool)(resources.GetObject("ucMetaTypeMcc.ShowHelp"))));
            this.ucMetaTypeMcc.ValueMember = "MetaTypeCode";
            // 
            // gbNameDescription
            // 
            this.gbNameDescription.BackColor = System.Drawing.Color.Transparent;
            this.gbNameDescription.Controls.Add(this.importantMsgEditBox);
            this.gbNameDescription.Controls.Add(this.descriptionFEditBox);
            this.gbNameDescription.Controls.Add(this.descriptionEEditBox);
            this.gbNameDescription.Controls.Add(this.nameFEditBox);
            this.gbNameDescription.Controls.Add(this.nameEEditBox);
            this.gbNameDescription.Controls.Add(this.NameFCounter);
            this.gbNameDescription.Controls.Add(this.NameECounter);
            this.gbNameDescription.Controls.Add(importantMsgLabel);
            this.gbNameDescription.Controls.Add(nameELabel);
            this.gbNameDescription.Controls.Add(descriptionFLabel);
            this.gbNameDescription.Controls.Add(descriptionELabel);
            this.gbNameDescription.Controls.Add(nameFLabel);
            this.gbNameDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbNameDescription.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbNameDescription, "gbNameDescription");
            this.gbNameDescription.Name = "gbNameDescription";
            this.helpProvider1.SetShowHelp(this.gbNameDescription, ((bool)(resources.GetObject("gbNameDescription.ShowHelp"))));
            this.gbNameDescription.UseThemes = false;
            // 
            // importantMsgEditBox
            // 
            this.importantMsgEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "ImportantMsg", true));
            resources.ApplyResources(this.importantMsgEditBox, "importantMsgEditBox");
            this.importantMsgEditBox.Multiline = true;
            this.importantMsgEditBox.Name = "importantMsgEditBox";
            this.importantMsgEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.importantMsgEditBox, ((bool)(resources.GetObject("importantMsgEditBox.ShowHelp"))));
            this.importantMsgEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // descriptionFEditBox
            // 
            this.descriptionFEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "DescriptionF", true));
            resources.ApplyResources(this.descriptionFEditBox, "descriptionFEditBox");
            this.descriptionFEditBox.Multiline = true;
            this.descriptionFEditBox.Name = "descriptionFEditBox";
            this.descriptionFEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.descriptionFEditBox, ((bool)(resources.GetObject("descriptionFEditBox.ShowHelp"))));
            this.descriptionFEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // descriptionEEditBox
            // 
            this.descriptionEEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "DescriptionE", true));
            resources.ApplyResources(this.descriptionEEditBox, "descriptionEEditBox");
            this.descriptionEEditBox.Multiline = true;
            this.descriptionEEditBox.Name = "descriptionEEditBox";
            this.descriptionEEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.descriptionEEditBox, ((bool)(resources.GetObject("descriptionEEditBox.ShowHelp"))));
            this.descriptionEEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // nameFEditBox
            // 
            this.nameFEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "NameF", true));
            resources.ApplyResources(this.nameFEditBox, "nameFEditBox");
            this.nameFEditBox.Name = "nameFEditBox";
            this.helpProvider1.SetShowHelp(this.nameFEditBox, ((bool)(resources.GetObject("nameFEditBox.ShowHelp"))));
            this.nameFEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.nameFEditBox.TextChanged += new System.EventHandler(this.nameETextBox_TextChanged);
            // 
            // nameEEditBox
            // 
            this.nameEEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "NameE", true));
            resources.ApplyResources(this.nameEEditBox, "nameEEditBox");
            this.nameEEditBox.Name = "nameEEditBox";
            this.helpProvider1.SetShowHelp(this.nameEEditBox, ((bool)(resources.GetObject("nameEEditBox.ShowHelp"))));
            this.nameEEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.nameEEditBox.TextChanged += new System.EventHandler(this.nameETextBox_TextChanged);
            // 
            // NameFCounter
            // 
            this.NameFCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.NameFCounter.DecimalDigits = 0;
            this.NameFCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.NameFCounter, "NameFCounter");
            this.NameFCounter.MaxLength = 3;
            this.NameFCounter.Name = "NameFCounter";
            this.NameFCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.NameFCounter, ((bool)(resources.GetObject("NameFCounter.ShowHelp"))));
            this.NameFCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.NameFCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NameFCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // NameECounter
            // 
            this.NameECounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.NameECounter.DecimalDigits = 0;
            this.NameECounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.NameECounter, "NameECounter");
            this.NameECounter.MaxLength = 3;
            this.NameECounter.Name = "NameECounter";
            this.NameECounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.NameECounter, ((bool)(resources.GetObject("NameECounter.ShowHelp"))));
            this.NameECounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.NameECounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NameECounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // codesDB
            // 
            this.codesDB.DataSetName = "CodesDB";
            this.codesDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar1,
            this.uiCommandBar3});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete,
            this.tsSave2,
            this.tsScreenTitle,
            this.tsEditmode,
            this.tsResetFileStruct,
            this.tsAudit,
            this.tsSecurity,
            this.tsDump,
            this.cmdFile,
            this.cmdEdit,
            this.cmdTools,
            this.cmdFileAccess});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("e84fd5d2-99ef-4b3d-be32-c13755915580");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.uiCommandManager1_CurrentLayoutChanging);
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1,
            this.cmdTools1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.MergeRowOrder = 1;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            resources.ApplyResources(this.cmdEdit1, "cmdEdit1");
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // cmdTools1
            // 
            resources.ApplyResources(this.cmdTools1, "cmdTools1");
            this.cmdTools1.Name = "cmdTools1";
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode2,
            this.tsScreenTitle1,
            this.Separator2,
            this.tsSave1,
            this.tsDelete1,
            this.Separator3});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.MergeRowOrder = 2;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // tsEditmode2
            // 
            resources.ApplyResources(this.tsEditmode2, "tsEditmode2");
            this.tsEditmode2.Name = "tsEditmode2";
            // 
            // tsScreenTitle1
            // 
            this.tsScreenTitle1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // uiCommandBar3
            // 
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsResetFileStruct3,
            this.Separator6,
            this.tsSecurity3,
            this.cmdFileAccess1,
            this.tsDump3,
            this.Separator8,
            this.tsAudit2,
            this.Separator9});
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.MergeRowOrder = 2;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            // 
            // tsResetFileStruct3
            // 
            resources.ApplyResources(this.tsResetFileStruct3, "tsResetFileStruct3");
            this.tsResetFileStruct3.Name = "tsResetFileStruct3";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // tsSecurity3
            // 
            resources.ApplyResources(this.tsSecurity3, "tsSecurity3");
            this.tsSecurity3.Name = "tsSecurity3";
            // 
            // cmdFileAccess1
            // 
            resources.ApplyResources(this.cmdFileAccess1, "cmdFileAccess1");
            this.cmdFileAccess1.Name = "cmdFileAccess1";
            // 
            // tsDump3
            // 
            resources.ApplyResources(this.tsDump3, "tsDump3");
            this.tsDump3.Name = "tsDump3";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator8, "Separator8");
            this.Separator8.Name = "Separator8";
            // 
            // tsAudit2
            // 
            resources.ApplyResources(this.tsAudit2, "tsAudit2");
            this.tsAudit2.Name = "tsAudit2";
            // 
            // Separator9
            // 
            this.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator9, "Separator9");
            this.Separator9.Name = "Separator9";
            // 
            // tsDelete
            // 
            resources.ApplyResources(this.tsDelete, "tsDelete");
            this.tsDelete.Name = "tsDelete";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.StateStyles.FormatStyle.FontSize = 8F;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.ShowInCustomizeDialog = false;
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // tsResetFileStruct
            // 
            this.tsResetFileStruct.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsResetFileStruct, "tsResetFileStruct");
            this.tsResetFileStruct.Name = "tsResetFileStruct";
            // 
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsSecurity
            // 
            this.tsSecurity.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsSecurity, "tsSecurity");
            this.tsSecurity.Name = "tsSecurity";
            // 
            // tsDump
            // 
            this.tsDump.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsDump, "tsDump");
            this.tsDump.Name = "tsDump";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave3});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave3
            // 
            resources.ApplyResources(this.tsSave3, "tsSave3");
            this.tsSave3.Name = "tsSave3";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete2});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsResetFileStruct2,
            this.tsSecurity2,
            this.tsDump2});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdTools.Name = "cmdTools";
            // 
            // tsResetFileStruct2
            // 
            resources.ApplyResources(this.tsResetFileStruct2, "tsResetFileStruct2");
            this.tsResetFileStruct2.Name = "tsResetFileStruct2";
            // 
            // tsSecurity2
            // 
            resources.ApplyResources(this.tsSecurity2, "tsSecurity2");
            this.tsSecurity2.Name = "tsSecurity2";
            // 
            // tsDump2
            // 
            resources.ApplyResources(this.tsDump2, "tsDump2");
            this.tsDump2.Name = "tsDump2";
            // 
            // cmdFileAccess
            // 
            resources.ApplyResources(this.cmdFileAccess, "cmdFileAccess");
            this.cmdFileAccess.Name = "cmdFileAccess";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            this.helpProvider1.SetShowHelp(this.LeftRebar1, ((bool)(resources.GetObject("LeftRebar1.ShowHelp"))));
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            this.helpProvider1.SetShowHelp(this.RightRebar1, ((bool)(resources.GetObject("RightRebar1.ShowHelp"))));
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2,
            this.uiCommandBar3});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Controls.Add(this.uiCommandBar3);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // ucEFile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucEFile";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucEFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileAKAGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileAKABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbArchiving)).EndInit();
            this.gbArchiving.ResumeLayout(false);
            this.gbArchiving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archiveBatchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbFileConfig)).EndInit();
            this.gbFileConfig.ResumeLayout(false);
            this.gbFileConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbEfileInfo)).EndInit();
            this.gbEfileInfo.ResumeLayout(false);
            this.gbEfileInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbNameDescription)).EndInit();
            this.gbNameDescription.ResumeLayout(false);
            this.gbNameDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codesDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private lmDatasets.atriumDB atriumDB;
        private System.Windows.Forms.BindingSource eFileBindingSource;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.EditControls.UIGroupBox gbEfileInfo;
        private Janus.Windows.EditControls.UIGroupBox gbNameDescription;
        private Janus.Windows.EditControls.UIGroupBox gbArchiving;
        private Janus.Windows.EditControls.UIGroupBox gbFileConfig;
        private Janus.Windows.CalendarCombo.CalendarCombo archiveDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo openedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo closedDateCalendarCombo;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsResetFileStruct;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private UserControls.ucMultiDropDown ucFileTypeMcc;
        private UserControls.ucMultiDropDown ucStatusCodeMcc;
        private UserControls.ucMultiDropDown ucClosureCodeMcc;
        private UserControls.ucMultiDropDown ucMetaTypeMcc;
        private Janus.Windows.UI.CommandBars.UICommand tsSecurity;
        private Janus.Windows.GridEX.GridEX fileAKAGridEX;
        private System.Windows.Forms.BindingSource fileAKABindingSource;
        private UserControls.ucMultiDropDown ucMultiDropDown3;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private lmDatasets.CodesDB codesDB;
        private UserControls.ucMultiDropDown ucSecurity;
        private Janus.Windows.GridEX.EditControls.NumericEditBox NameFCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox NameECounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox fileNumberCounter;
        private Janus.Windows.UI.CommandBars.UICommand tsDump;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave3;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsResetFileStruct2;
        private Janus.Windows.UI.CommandBars.UICommand tsSecurity2;
        private Janus.Windows.UI.CommandBars.UICommand tsDump2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand tsResetFileStruct3;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand tsSecurity3;
        private Janus.Windows.UI.CommandBars.UICommand tsDump3;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit2;
        private Janus.Windows.UI.CommandBars.UICommand Separator9;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private UserControls.ucMultiDropDown mccPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private Janus.Windows.CalendarCombo.CalendarCombo calPeriodStartDate;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.UI.CommandBars.UICommand cmdFileAccess1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFileAccess;
        private Janus.Windows.GridEX.EditControls.EditBox fullFileNumberEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox fileNumberEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox importantMsgEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox descriptionFEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox descriptionEEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox nameFEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox nameEEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox fileIdEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox subFileNumMaxEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox subFileNumMinEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox fullPathEditBox;
        private Janus.Windows.EditControls.UICheckBox hasPaperFileUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox boxNumberEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox bayEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox roomEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox accessionNumberEditBox;
        private UserControls.ucMultiDropDown dispositionIducMultiDropDown;
        private Janus.Windows.EditControls.UICheckBox temporarilyRecalledUICheckBox;
        private UserControls.ucMultiDropDown locationIducMultiDropDown;
        private Janus.Windows.EditControls.UICheckBox riskManageChildrenUICheckBox;
        private Janus.Windows.EditControls.UICheckBox riskManageUICheckBox;
        private System.Windows.Forms.BindingSource archiveBatchBindingSource;
    }
}
