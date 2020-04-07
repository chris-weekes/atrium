 namespace LawMate
{
    partial class ucFileOffice
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
                FM.DB.FileOffice.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.GetFileOffice().OnUpdate -= new atLogic.UpdateEventHandler(ucFileOffice_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFileOffice));
            System.Windows.Forms.Label officeFileNumLabel;
            System.Windows.Forms.Label officeCodeLabel;
            System.Windows.Forms.Label percentAllocLabel1;
            System.Windows.Forms.Label orderNumberLabel1;
            Janus.Windows.GridEX.GridEXLayout fileOfficeGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.gbLP = new Janus.Windows.EditControls.UIGroupBox();
            this.percentAllocMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.fileOfficeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.orderNumberEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.isPrimaryUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isAgentUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isClientUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isLeadUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isOwnerUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.officeFileNumEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeIducOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.fileOfficeGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave3 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            officeFileNumLabel = new System.Windows.Forms.Label();
            officeCodeLabel = new System.Windows.Forms.Label();
            percentAllocLabel1 = new System.Windows.Forms.Label();
            orderNumberLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbLP)).BeginInit();
            this.gbLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileOfficeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileOfficeGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.fileOfficeBindingSource;
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
            this.imageListBase.Images.SetKeyName(18, "audit.gif");
            this.imageListBase.Images.SetKeyName(19, "DRedit.gif");
            // 
            // officeFileNumLabel
            // 
            resources.ApplyResources(officeFileNumLabel, "officeFileNumLabel");
            officeFileNumLabel.Name = "officeFileNumLabel";
            this.helpProvider1.SetShowHelp(officeFileNumLabel, ((bool)(resources.GetObject("officeFileNumLabel.ShowHelp"))));
            // 
            // officeCodeLabel
            // 
            resources.ApplyResources(officeCodeLabel, "officeCodeLabel");
            officeCodeLabel.Name = "officeCodeLabel";
            this.helpProvider1.SetShowHelp(officeCodeLabel, ((bool)(resources.GetObject("officeCodeLabel.ShowHelp"))));
            // 
            // percentAllocLabel1
            // 
            resources.ApplyResources(percentAllocLabel1, "percentAllocLabel1");
            percentAllocLabel1.Name = "percentAllocLabel1";
            this.helpProvider1.SetShowHelp(percentAllocLabel1, ((bool)(resources.GetObject("percentAllocLabel1.ShowHelp"))));
            // 
            // orderNumberLabel1
            // 
            resources.ApplyResources(orderNumberLabel1, "orderNumberLabel1");
            orderNumberLabel1.Name = "orderNumberLabel1";
            this.helpProvider1.SetShowHelp(orderNumberLabel1, ((bool)(resources.GetObject("orderNumberLabel1.ShowHelp"))));
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(744, 398), true);
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
            this.pnlAllContainer.Controls.Add(this.gbLP);
            this.pnlAllContainer.Controls.Add(this.fileOfficeGridEX);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // gbLP
            // 
            this.gbLP.BackColor = System.Drawing.Color.Transparent;
            this.gbLP.Controls.Add(this.percentAllocMaskedEditBox);
            this.gbLP.Controls.Add(orderNumberLabel1);
            this.gbLP.Controls.Add(this.orderNumberEditBox);
            this.gbLP.Controls.Add(percentAllocLabel1);
            this.gbLP.Controls.Add(this.isPrimaryUICheckBox);
            this.gbLP.Controls.Add(this.isAgentUICheckBox);
            this.gbLP.Controls.Add(this.isClientUICheckBox);
            this.gbLP.Controls.Add(this.isLeadUICheckBox);
            this.gbLP.Controls.Add(this.isOwnerUICheckBox);
            this.gbLP.Controls.Add(this.officeFileNumEditBox);
            this.gbLP.Controls.Add(this.officeIducOfficeSelectBox);
            this.gbLP.Controls.Add(officeFileNumLabel);
            this.gbLP.Controls.Add(officeCodeLabel);
            resources.ApplyResources(this.gbLP, "gbLP");
            this.gbLP.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbLP.Name = "gbLP";
            this.helpProvider1.SetShowHelp(this.gbLP, ((bool)(resources.GetObject("gbLP.ShowHelp"))));
            this.gbLP.UseThemes = false;
            // 
            // percentAllocMaskedEditBox
            // 
            this.percentAllocMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fileOfficeBindingSource, "PercentAlloc", true));
            resources.ApplyResources(this.percentAllocMaskedEditBox, "percentAllocMaskedEditBox");
            this.percentAllocMaskedEditBox.Mask = "### %";
            this.percentAllocMaskedEditBox.Name = "percentAllocMaskedEditBox";
            this.helpProvider1.SetShowHelp(this.percentAllocMaskedEditBox, ((bool)(resources.GetObject("percentAllocMaskedEditBox.ShowHelp"))));
            this.percentAllocMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // fileOfficeBindingSource
            // 
            this.fileOfficeBindingSource.DataMember = "FileOffice";
            this.fileOfficeBindingSource.DataSource = this.atriumDB;
            this.fileOfficeBindingSource.CurrentChanged += new System.EventHandler(this.fileOfficeBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // orderNumberEditBox
            // 
            this.orderNumberEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fileOfficeBindingSource, "OrderNumber", true));
            resources.ApplyResources(this.orderNumberEditBox, "orderNumberEditBox");
            this.orderNumberEditBox.Name = "orderNumberEditBox";
            this.helpProvider1.SetShowHelp(this.orderNumberEditBox, ((bool)(resources.GetObject("orderNumberEditBox.ShowHelp"))));
            this.orderNumberEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // isPrimaryUICheckBox
            // 
            this.isPrimaryUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isPrimaryUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileOfficeBindingSource, "IsPrimary", true));
            resources.ApplyResources(this.isPrimaryUICheckBox, "isPrimaryUICheckBox");
            this.isPrimaryUICheckBox.Name = "isPrimaryUICheckBox";
            this.helpProvider1.SetShowHelp(this.isPrimaryUICheckBox, ((bool)(resources.GetObject("isPrimaryUICheckBox.ShowHelp"))));
            this.isPrimaryUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isAgentUICheckBox
            // 
            this.isAgentUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isAgentUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileOfficeBindingSource, "IsAgent", true));
            resources.ApplyResources(this.isAgentUICheckBox, "isAgentUICheckBox");
            this.isAgentUICheckBox.Name = "isAgentUICheckBox";
            this.helpProvider1.SetShowHelp(this.isAgentUICheckBox, ((bool)(resources.GetObject("isAgentUICheckBox.ShowHelp"))));
            this.isAgentUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isClientUICheckBox
            // 
            this.isClientUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isClientUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileOfficeBindingSource, "IsClient", true));
            resources.ApplyResources(this.isClientUICheckBox, "isClientUICheckBox");
            this.isClientUICheckBox.Name = "isClientUICheckBox";
            this.helpProvider1.SetShowHelp(this.isClientUICheckBox, ((bool)(resources.GetObject("isClientUICheckBox.ShowHelp"))));
            this.isClientUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isLeadUICheckBox
            // 
            this.isLeadUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isLeadUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileOfficeBindingSource, "IsLead", true));
            resources.ApplyResources(this.isLeadUICheckBox, "isLeadUICheckBox");
            this.isLeadUICheckBox.Name = "isLeadUICheckBox";
            this.helpProvider1.SetShowHelp(this.isLeadUICheckBox, ((bool)(resources.GetObject("isLeadUICheckBox.ShowHelp"))));
            this.isLeadUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isOwnerUICheckBox
            // 
            this.isOwnerUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isOwnerUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.fileOfficeBindingSource, "IsOwner", true));
            resources.ApplyResources(this.isOwnerUICheckBox, "isOwnerUICheckBox");
            this.isOwnerUICheckBox.Name = "isOwnerUICheckBox";
            this.helpProvider1.SetShowHelp(this.isOwnerUICheckBox, ((bool)(resources.GetObject("isOwnerUICheckBox.ShowHelp"))));
            this.isOwnerUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // officeFileNumEditBox
            // 
            this.officeFileNumEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fileOfficeBindingSource, "OfficeFileNum", true));
            resources.ApplyResources(this.officeFileNumEditBox, "officeFileNumEditBox");
            this.officeFileNumEditBox.Name = "officeFileNumEditBox";
            this.helpProvider1.SetShowHelp(this.officeFileNumEditBox, ((bool)(resources.GetObject("officeFileNumEditBox.ShowHelp"))));
            this.officeFileNumEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeIducOfficeSelectBox
            // 
            this.officeIducOfficeSelectBox.AtMng = null;
            this.officeIducOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIducOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.fileOfficeBindingSource, "OfficeId", true));
            resources.ApplyResources(this.officeIducOfficeSelectBox, "officeIducOfficeSelectBox");
            this.officeIducOfficeSelectBox.Name = "officeIducOfficeSelectBox";
            this.officeIducOfficeSelectBox.OfficeId = null;
            this.officeIducOfficeSelectBox.ReadOnly = false;
            this.officeIducOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.officeIducOfficeSelectBox, ((bool)(resources.GetObject("officeIducOfficeSelectBox.ShowHelp"))));
            // 
            // fileOfficeGridEX
            // 
            this.fileOfficeGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.fileOfficeGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fileOfficeGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.fileOfficeGridEX.DataSource = this.fileOfficeBindingSource;
            resources.ApplyResources(fileOfficeGridEX_DesignTimeLayout, "fileOfficeGridEX_DesignTimeLayout");
            this.fileOfficeGridEX.DesignTimeLayout = fileOfficeGridEX_DesignTimeLayout;
            this.fileOfficeGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.fileOfficeGridEX, "fileOfficeGridEX");
            this.fileOfficeGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.fileOfficeGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.fileOfficeGridEX.GroupByBoxVisible = false;
            this.fileOfficeGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.fileOfficeGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.fileOfficeGridEX.Name = "fileOfficeGridEX";
            this.fileOfficeGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.fileOfficeGridEX.SettingsKey = "ucFileOffice2";
            this.helpProvider1.SetShowHelp(this.fileOfficeGridEX, ((bool)(resources.GetObject("fileOfficeGridEX.ShowHelp"))));
            this.fileOfficeGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.fileOfficeGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete,
            this.tsSave2,
            this.tsScreenTitle,
            this.tsAudit,
            this.tsEditmode,
            this.cmdFile,
            this.cmdEdit});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("e84fd5d2-99ef-4b3d-be32-c13755915580");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
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
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            resources.ApplyResources(this.cmdEdit1, "cmdEdit1");
            this.cmdEdit1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave1,
            this.tsDelete1,
            this.Separator2,
            this.tsAudit1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // tsEditmode1
            // 
            resources.ApplyResources(this.tsEditmode1, "tsEditmode1");
            this.tsEditmode1.Name = "tsEditmode1";
            // 
            // tsScreenTitle1
            // 
            this.tsScreenTitle1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsScreenTitle1.ControlWidth = 100;
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
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
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
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
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave3});
            resources.ApplyResources(this.cmdFile, "cmdFile");
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
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
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
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // ucFileOffice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucFileOffice";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucFileOffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbLP)).EndInit();
            this.gbLP.ResumeLayout(false);
            this.gbLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileOfficeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileOfficeGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.GridEX.GridEX fileOfficeGridEX;
        private System.Windows.Forms.BindingSource fileOfficeBindingSource;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.EditControls.UIGroupBox gbLP;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave3;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox percentAllocMaskedEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox orderNumberEditBox;
        private Janus.Windows.EditControls.UICheckBox isPrimaryUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isAgentUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isClientUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isLeadUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isOwnerUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox officeFileNumEditBox;
        private ucOfficeSelectBox officeIducOfficeSelectBox;
    }
}
