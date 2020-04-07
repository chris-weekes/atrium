using System.Data;
 namespace LawMate
{
    partial class fBFList
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
                fmCurrent.DB.ActivityBF.ColumnChanged -=  new DataColumnChangeEventHandler(bft_ColumnChanged);

                timerReadMail.Tick -= new System.EventHandler(this.timerReadMail_Tick);
                timerReadMail.Dispose();

                timrefresh.Tick -= new System.EventHandler(this.timrefresh_Tick);
                timrefresh.Dispose();

                backgroundWorker1.DoWork -= new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                backgroundWorker1.RunWorkerCompleted -= new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                backgroundWorker1.Dispose();

                //the following line does not clean up the event but instead creates another event handler
                //this.activityBFGridEX.LayoutLoad -= new System.EventHandler(this.activityBFGridEX_LayoutLoad);
                this.activityBFGridEX.RowDrag -= new Janus.Windows.GridEX.RowDragEventHandler(activityBFGridEX_RowDrag);
                this.activityBFGridEX.SelectionChanged -= new System.EventHandler(activityBFGridEX_SelectionChanged);
                

                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.fBFList_KeyDown);
                this.comboBox2.SelectionChangeCommitted -= new System.EventHandler(this.calBFListRange_ValueChanged);
                this.calBFListRange.ValueChanged -= new System.EventHandler(this.calBFListRange_ValueChanged);
                this.uiCommandManager1.CommandClick -= new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
                this.uiCommandManager1.CommandPopup -= new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandPopup);
                this.uiContextMenu1.Popup -= new System.EventHandler(this.uiContextMenu1_Popup);
                cbMailFilter.CheckedChanged -= new System.EventHandler(cbMailFilter_CheckedChanged);


                ucDocView1.Dispose();

                //fmCurrent.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBFList));
            lmDatasets.atriumDB atriumDB;
            Janus.Windows.GridEX.GridEXLayout activityBFGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityBFGridEX_Layout_0_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityBFGridEX_Layout_0_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.ValueList.Item2.Image");
            Janus.Windows.Common.SuperTipSettings superTipSettings1 = new Janus.Windows.Common.SuperTipSettings();
            this.activityBFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.priorityLabel = new System.Windows.Forms.Label();
            this.bFCommentLabel = new System.Windows.Forms.Label();
            this.bFDateLabel = new System.Windows.Forms.Label();
            this.bFOfficerCodeLabel = new System.Windows.Forms.Label();
            this.lblMailIcon = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlNoBFs = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlNoBFsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlParent = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label9 = new System.Windows.Forms.Label();
            this.bFCommentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.activityBFGridEX = new Janus.Windows.GridEX.GridEX();
            this.imgListBFType = new System.Windows.Forms.ImageList(this.components);
            this.bFDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblBF30 = new System.Windows.Forms.Label();
            this.lblBFCount = new System.Windows.Forms.Label();
            this.priorityJComboBox = new Janus.Windows.EditControls.UIComboBox();
            this.tbTo = new Janus.Windows.GridEX.EditControls.EditBox();
            this.BFCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cbMailFilter = new Janus.Windows.EditControls.UICheckBox();
            this.chkOnlyBFs = new Janus.Windows.EditControls.UICheckBox();
            this.pnlEditableFields = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlEditableFieldsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlPreviewedDoc = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlPreviewedDocContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucDocView1 = new LawMate.UserControls.ucDocView();
            this.calBFListRange = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.pnlDoc = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdActions1 = new Janus.Windows.UI.CommandBars.UICommand("cmdActions");
            this.Separator11 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave4 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsCancel4 = new Janus.Windows.UI.CommandBars.UICommand("tsCancel");
            this.tsMoreInfo6 = new Janus.Windows.UI.CommandBars.UICommand("tsMoreInfo");
            this.tsReload1 = new Janus.Windows.UI.CommandBars.UICommand("tsReload");
            this.Separator14 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdListRangeLabel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdListRangeLabel");
            this.cmdDateRange1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDateRange");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdGridCommands1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGridCommands");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdEditPanelToggle2 = new Janus.Windows.UI.CommandBars.UICommand("cmdEditPanelToggle");
            this.cmdResetGrid2 = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGrid");
            this.cmdGrdExpand2 = new Janus.Windows.UI.CommandBars.UICommand("cmdGrdExpand");
            this.tsFilter2 = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.cmdGroupBy2 = new Janus.Windows.UI.CommandBars.UICommand("cmdGroupBy");
            this.cmdFieldChooser2 = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.uiCommandBar4 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdActions2 = new Janus.Windows.UI.CommandBars.UICommand("cmdActions");
            this.tsCancel2 = new Janus.Windows.UI.CommandBars.UICommand("tsCancel");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsFilter = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsMoreInfo2 = new Janus.Windows.UI.CommandBars.UICommand("tsMoreInfo");
            this.tsMove2 = new Janus.Windows.UI.CommandBars.UICommand("tsMove");
            this.tsConvert = new Janus.Windows.UI.CommandBars.UICommand("tsConvert");
            this.tsLblOfficer = new Janus.Windows.UI.CommandBars.UICommand("tsLblOfficer");
            this.tsOfficer = new Janus.Windows.UI.CommandBars.UICommand("tsOfficer");
            this.tsLblNumBFs = new Janus.Windows.UI.CommandBars.UICommand("tsLblNumBFs");
            this.tsNumBFs = new Janus.Windows.UI.CommandBars.UICommand("tsNumBFs");
            this.tsNextSteps = new Janus.Windows.UI.CommandBars.UICommand("tsNextSteps");
            this.tsDummy = new Janus.Windows.UI.CommandBars.UICommand("tsDummy");
            this.tsReload = new Janus.Windows.UI.CommandBars.UICommand("tsReload");
            this.tsCompleteBF = new Janus.Windows.UI.CommandBars.UICommand("tsCompleteBF");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.cmdMarkAsUnread = new Janus.Windows.UI.CommandBars.UICommand("cmdMarkAsUnread");
            this.cmdSend = new Janus.Windows.UI.CommandBars.UICommand("cmdSend");
            this.cmdReply1 = new Janus.Windows.UI.CommandBars.UICommand("cmdReply");
            this.cmdReplyAll1 = new Janus.Windows.UI.CommandBars.UICommand("cmdReplyAll");
            this.cmdForward1 = new Janus.Windows.UI.CommandBars.UICommand("cmdForward");
            this.Separator12 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMarkAsUnread2 = new Janus.Windows.UI.CommandBars.UICommand("cmdMarkAsUnread");
            this.tsCompleteBF3 = new Janus.Windows.UI.CommandBars.UICommand("tsCompleteBF");
            this.tsMove4 = new Janus.Windows.UI.CommandBars.UICommand("tsMove");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsMoreInfo4 = new Janus.Windows.UI.CommandBars.UICommand("tsMoreInfo");
            this.Separator13 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsConvert3 = new Janus.Windows.UI.CommandBars.UICommand("tsConvert");
            this.tsNextSteps3 = new Janus.Windows.UI.CommandBars.UICommand("tsNextSteps");
            this.cmdReply = new Janus.Windows.UI.CommandBars.UICommand("cmdReply");
            this.cmdReplyAll = new Janus.Windows.UI.CommandBars.UICommand("cmdReplyAll");
            this.cmdForward = new Janus.Windows.UI.CommandBars.UICommand("cmdForward");
            this.cmdGroupBy = new Janus.Windows.UI.CommandBars.UICommand("cmdGroupBy");
            this.cmdGrdExpand = new Janus.Windows.UI.CommandBars.UICommand("cmdGrdExpand");
            this.cmdFieldChooser = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.tsLblFilterCount = new Janus.Windows.UI.CommandBars.UICommand("tsLblFilterCount");
            this.tsFilterCount = new Janus.Windows.UI.CommandBars.UICommand("tsFilterCount");
            this.cmdEditPanelToggle = new Janus.Windows.UI.CommandBars.UICommand("cmdEditPanelToggle");
            this.cmdResetGrid = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGrid");
            this.cmdListRangeLabel = new Janus.Windows.UI.CommandBars.UICommand("cmdListRangeLabel");
            this.cmdDateRange = new Janus.Windows.UI.CommandBars.UICommand("cmdDateRange");
            this.cmdActions = new Janus.Windows.UI.CommandBars.UICommand("cmdActions");
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdReply4 = new Janus.Windows.UI.CommandBars.UICommand("cmdReply");
            this.cmdReplyAll3 = new Janus.Windows.UI.CommandBars.UICommand("cmdReplyAll");
            this.cmdForward3 = new Janus.Windows.UI.CommandBars.UICommand("cmdForward");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMarkAsUnread3 = new Janus.Windows.UI.CommandBars.UICommand("cmdMarkAsUnread");
            this.tsCompleteBF1 = new Janus.Windows.UI.CommandBars.UICommand("tsCompleteBF");
            this.tsMove1 = new Janus.Windows.UI.CommandBars.UICommand("tsMove");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsMoreInfo1 = new Janus.Windows.UI.CommandBars.UICommand("tsMoreInfo");
            this.cmdCopyFileNumber2 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyFileNumber");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsConvert2 = new Janus.Windows.UI.CommandBars.UICommand("tsConvert");
            this.tsNextSteps2 = new Janus.Windows.UI.CommandBars.UICommand("tsNextSteps");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsCancel1 = new Janus.Windows.UI.CommandBars.UICommand("tsCancel");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdGridCommands = new Janus.Windows.UI.CommandBars.UICommand("cmdGridCommands");
            this.cmdResetGrid1 = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGrid");
            this.cmdGrdExpand1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGrdExpand");
            this.tsFilter1 = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.cmdGroupBy1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGroupBy");
            this.cmdFieldChooser1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.cmdCopyFileNumber = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyFileNumber");
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdReply2 = new Janus.Windows.UI.CommandBars.UICommand("cmdReply");
            this.cmdReplyAll2 = new Janus.Windows.UI.CommandBars.UICommand("cmdReplyAll");
            this.cmdForward2 = new Janus.Windows.UI.CommandBars.UICommand("cmdForward");
            this.Separator9 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMarkAsUnread1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMarkAsUnread");
            this.tsCompleteBF2 = new Janus.Windows.UI.CommandBars.UICommand("tsCompleteBF");
            this.tsMove3 = new Janus.Windows.UI.CommandBars.UICommand("tsMove");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsMoreInfo3 = new Janus.Windows.UI.CommandBars.UICommand("tsMoreInfo");
            this.cmdCopyFileNumber1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyFileNumber");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsConvert1 = new Janus.Windows.UI.CommandBars.UICommand("tsConvert");
            this.tsNextSteps1 = new Janus.Windows.UI.CommandBars.UICommand("tsNextSteps");
            this.imageListBase = new System.Windows.Forms.ImageList(this.components);
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.timerReadMail = new System.Windows.Forms.Timer(this.components);
            this.tsDummy3 = new Janus.Windows.UI.CommandBars.UICommand("tsDummy");
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            this.timrefresh = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            atriumDB = new lmDatasets.atriumDB();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNoBFs)).BeginInit();
            this.pnlNoBFs.SuspendLayout();
            this.pnlNoBFsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlParent)).BeginInit();
            this.pnlParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditableFields)).BeginInit();
            this.pnlEditableFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreviewedDoc)).BeginInit();
            this.pnlPreviewedDoc.SuspendLayout();
            this.pnlPreviewedDocContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).BeginInit();
            this.pnlDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            this.uiCommandBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListfBase
            // 
            this.imageListfBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListfBase.ImageStream")));
            this.imageListfBase.Images.SetKeyName(0, "");
            this.imageListfBase.Images.SetKeyName(1, "");
            this.imageListfBase.Images.SetKeyName(2, "");
            this.imageListfBase.Images.SetKeyName(3, "");
            this.imageListfBase.Images.SetKeyName(4, "");
            this.imageListfBase.Images.SetKeyName(5, "");
            this.imageListfBase.Images.SetKeyName(6, "");
            this.imageListfBase.Images.SetKeyName(7, "");
            this.imageListfBase.Images.SetKeyName(8, "");
            this.imageListfBase.Images.SetKeyName(9, "");
            this.imageListfBase.Images.SetKeyName(10, "");
            this.imageListfBase.Images.SetKeyName(11, "");
            this.imageListfBase.Images.SetKeyName(12, "");
            this.imageListfBase.Images.SetKeyName(13, "");
            this.imageListfBase.Images.SetKeyName(14, "");
            this.imageListfBase.Images.SetKeyName(15, "");
            this.imageListfBase.Images.SetKeyName(16, "");
            this.imageListfBase.Images.SetKeyName(17, "");
            this.imageListfBase.Images.SetKeyName(18, "reload.gif");
            this.imageListfBase.Images.SetKeyName(19, "mail2.gif");
            // 
            // atriumDB
            // 
            atriumDB.DataSetName = "atriumDB";
            atriumDB.EnforceConstraints = false;
            atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // activityBFBindingSource
            // 
            this.activityBFBindingSource.DataMember = "ActivityBF";
            this.activityBFBindingSource.DataSource = atriumDB;
            // 
            // priorityLabel
            // 
            resources.ApplyResources(this.priorityLabel, "priorityLabel");
            this.priorityLabel.BackColor = System.Drawing.Color.Transparent;
            this.priorityLabel.Name = "priorityLabel";
            this.helpProvider1.SetShowHelp(this.priorityLabel, ((bool)(resources.GetObject("priorityLabel.ShowHelp"))));
            // 
            // bFCommentLabel
            // 
            resources.ApplyResources(this.bFCommentLabel, "bFCommentLabel");
            this.bFCommentLabel.BackColor = System.Drawing.Color.Transparent;
            this.bFCommentLabel.Name = "bFCommentLabel";
            this.helpProvider1.SetShowHelp(this.bFCommentLabel, ((bool)(resources.GetObject("bFCommentLabel.ShowHelp"))));
            // 
            // bFDateLabel
            // 
            resources.ApplyResources(this.bFDateLabel, "bFDateLabel");
            this.bFDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.bFDateLabel.Name = "bFDateLabel";
            this.helpProvider1.SetShowHelp(this.bFDateLabel, ((bool)(resources.GetObject("bFDateLabel.ShowHelp"))));
            // 
            // bFOfficerCodeLabel
            // 
            resources.ApplyResources(this.bFOfficerCodeLabel, "bFOfficerCodeLabel");
            this.bFOfficerCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.bFOfficerCodeLabel.Name = "bFOfficerCodeLabel";
            this.helpProvider1.SetShowHelp(this.bFOfficerCodeLabel, ((bool)(resources.GetObject("bFOfficerCodeLabel.ShowHelp"))));
            // 
            // lblMailIcon
            // 
            resources.ApplyResources(this.lblMailIcon, "lblMailIcon");
            this.lblMailIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblMailIcon.Image = global::LawMate.Properties.Resources.mail;
            this.lblMailIcon.Name = "lblMailIcon";
            this.helpProvider1.SetShowHelp(this.lblMailIcon, ((bool)(resources.GetObject("lblMailIcon.ShowHelp"))));
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
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.uiPanelManager1_CurrentLayoutChanging);
            this.pnlNoBFs.Id = new System.Guid("2e5c5085-0a2c-4ae4-93d3-5059f68d177e");
            this.uiPanelManager1.Panels.Add(this.pnlNoBFs);
            this.pnlParent.Id = new System.Guid("7625b732-7897-4aa1-8676-22627084a9ea");
            this.pnlParent.StaticGroup = true;
            this.pnlTop.Id = new System.Guid("0df758ed-6c58-4456-a8f2-5702adcea8ef");
            this.pnlParent.Panels.Add(this.pnlTop);
            this.pnlEditableFields.Id = new System.Guid("95bb2d8e-6024-4c5d-b182-a1f34ac3fde7");
            this.pnlParent.Panels.Add(this.pnlEditableFields);
            this.pnlPreviewedDoc.Id = new System.Guid("d0f6248a-fd3e-43ea-bbac-66577d90add3");
            this.pnlParent.Panels.Add(this.pnlPreviewedDoc);
            this.uiPanelManager1.Panels.Add(this.pnlParent);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("2e5c5085-0a2c-4ae4-93d3-5059f68d177e"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1001, 37), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7625b732-7897-4aa1-8676-22627084a9ea"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(1301, 695), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("0df758ed-6c58-4456-a8f2-5702adcea8ef"), new System.Guid("7625b732-7897-4aa1-8676-22627084a9ea"), 275, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("95bb2d8e-6024-4c5d-b182-a1f34ac3fde7"), new System.Guid("7625b732-7897-4aa1-8676-22627084a9ea"), 77, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("d0f6248a-fd3e-43ea-bbac-66577d90add3"), new System.Guid("7625b732-7897-4aa1-8676-22627084a9ea"), 366, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("daf4ae32-bda1-43f1-8de6-b63925cbf060"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3a7823f1-c47a-42fc-96e4-0e24f5cb769e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a1e011ac-58ea-41b0-9192-a51f3260fc8f"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("2e5c5085-0a2c-4ae4-93d3-5059f68d177e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7625b732-7897-4aa1-8676-22627084a9ea"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0df758ed-6c58-4456-a8f2-5702adcea8ef"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("95bb2d8e-6024-4c5d-b182-a1f34ac3fde7"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d0f6248a-fd3e-43ea-bbac-66577d90add3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlNoBFs
            // 
            resources.ApplyResources(this.pnlNoBFs, "pnlNoBFs");
            this.pnlNoBFs.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlNoBFs.InnerContainer = this.pnlNoBFsContainer;
            this.pnlNoBFs.Name = "pnlNoBFs";
            this.helpProvider1.SetShowHelp(this.pnlNoBFs, ((bool)(resources.GetObject("pnlNoBFs.ShowHelp"))));
            // 
            // pnlNoBFsContainer
            // 
            this.pnlNoBFsContainer.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlNoBFsContainer, "pnlNoBFsContainer");
            this.pnlNoBFsContainer.Name = "pnlNoBFsContainer";
            this.helpProvider1.SetShowHelp(this.pnlNoBFsContainer, ((bool)(resources.GetObject("pnlNoBFsContainer.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // pnlParent
            // 
            this.pnlParent.AllowResize = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlParent, "pnlParent");
            this.pnlParent.Name = "pnlParent";
            this.helpProvider1.SetShowHelp(this.pnlParent, ((bool)(resources.GetObject("pnlParent.ShowHelp"))));
            // 
            // pnlTop
            // 
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            this.helpProvider1.SetShowHelp(this.pnlTop, ((bool)(resources.GetObject("pnlTop.ShowHelp"))));
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Controls.Add(this.label9);
            this.pnlTopContainer.Controls.Add(this.bFCommentEditBox);
            this.pnlTopContainer.Controls.Add(this.activityBFGridEX);
            this.pnlTopContainer.Controls.Add(this.bFDateCalendarCombo);
            this.pnlTopContainer.Controls.Add(this.bFDateLabel);
            this.pnlTopContainer.Controls.Add(this.lblBF30);
            this.pnlTopContainer.Controls.Add(this.lblMailIcon);
            this.pnlTopContainer.Controls.Add(this.lblBFCount);
            this.pnlTopContainer.Controls.Add(this.priorityJComboBox);
            this.pnlTopContainer.Controls.Add(this.tbTo);
            this.pnlTopContainer.Controls.Add(this.bFCommentLabel);
            this.pnlTopContainer.Controls.Add(this.priorityLabel);
            this.pnlTopContainer.Controls.Add(this.BFCommentCounter);
            this.pnlTopContainer.Controls.Add(this.bFOfficerCodeLabel);
            this.pnlTopContainer.Controls.Add(this.comboBox2);
            this.pnlTopContainer.Controls.Add(this.cbMailFilter);
            this.pnlTopContainer.Controls.Add(this.chkOnlyBFs);
            resources.ApplyResources(this.pnlTopContainer, "pnlTopContainer");
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.helpProvider1.SetShowHelp(this.pnlTopContainer, ((bool)(resources.GetObject("pnlTopContainer.ShowHelp"))));
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Image = global::LawMate.Properties.Resources.hourglass;
            this.label9.Name = "label9";
            this.helpProvider1.SetShowHelp(this.label9, ((bool)(resources.GetObject("label9.ShowHelp"))));
            // 
            // bFCommentEditBox
            // 
            resources.ApplyResources(this.bFCommentEditBox, "bFCommentEditBox");
            this.bFCommentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBFBindingSource, "BFComment", true));
            this.bFCommentEditBox.Multiline = true;
            this.bFCommentEditBox.Name = "bFCommentEditBox";
            this.bFCommentEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.bFCommentEditBox, ((bool)(resources.GetObject("bFCommentEditBox.ShowHelp"))));
            this.bFCommentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.bFCommentEditBox.TextChanged += new System.EventHandler(this.bFCommentTextBox_TextChanged);
            // 
            // activityBFGridEX
            // 
            this.activityBFGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.activityBFGridEX, "activityBFGridEX");
            this.activityBFGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.activityBFGridEX.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.activityBFGridEX.DataSource = this.activityBFBindingSource;
            this.activityBFGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.activityBFGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.activityBFGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.activityBFGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityBFGridEX.GroupByBoxVisible = false;
            this.activityBFGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.activityBFGridEX.ImageList = this.imgListBFType;
            activityBFGridEX_Layout_0.DataSource = this.activityBFBindingSource;
            activityBFGridEX_Layout_0.IsCurrentLayout = true;
            activityBFGridEX_Layout_0.Key = "LayoutAll";
            activityBFGridEX_Layout_0_Reference_0.Instance = ((object)(resources.GetObject("activityBFGridEX_Layout_0_Reference_0.Instance")));
            activityBFGridEX_Layout_0_Reference_1.Instance = ((object)(resources.GetObject("activityBFGridEX_Layout_0_Reference_1.Instance")));
            activityBFGridEX_Layout_0.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityBFGridEX_Layout_0_Reference_0,
            activityBFGridEX_Layout_0_Reference_1});
            resources.ApplyResources(activityBFGridEX_Layout_0, "activityBFGridEX_Layout_0");
            this.activityBFGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            activityBFGridEX_Layout_0});
            this.activityBFGridEX.Name = "activityBFGridEX";
            this.activityBFGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.activityBFGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.activityBFGridEX.SettingsKey = "activityBFGridEX";
            this.helpProvider1.SetShowHelp(this.activityBFGridEX, ((bool)(resources.GetObject("activityBFGridEX.ShowHelp"))));
            this.activityBFGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityBFGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityBFGridEX.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.activityBFGridEX_RowCheckStateChanged);
            this.activityBFGridEX.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.activityBFGridEX_RowDoubleClick);
            this.activityBFGridEX.RowDrag += new Janus.Windows.GridEX.RowDragEventHandler(this.activityBFGridEX_RowDrag);
            this.activityBFGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityBFGridEX_FormattingRow);
            this.activityBFGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityBFGridEX_LoadingRow);
            this.activityBFGridEX.SortKeysChanged += new System.EventHandler(this.activityBFGridEX_SortKeysChanged);
            this.activityBFGridEX.ClearFilterButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityBFGridEX_ClearFilterButtonClick);
            this.activityBFGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.activityBFGridEX_CurrentCellChanging);
            this.activityBFGridEX.SelectionChanged += new System.EventHandler(this.activityBFGridEX_SelectionChanged);
            this.activityBFGridEX.FilterApplied += new System.EventHandler(this.activityBFGridEX_FilterApplied);
            this.activityBFGridEX.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.activityBFGridEX_CurrentLayoutChanging);
            // 
            // imgListBFType
            // 
            this.imgListBFType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBFType.ImageStream")));
            this.imgListBFType.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBFType.Images.SetKeyName(0, "MarkasRead.gif");
            this.imgListBFType.Images.SetKeyName(1, "bf1.gif");
            this.imgListBFType.Images.SetKeyName(2, "bf2.gif");
            this.imgListBFType.Images.SetKeyName(3, "bf3.gif");
            this.imgListBFType.Images.SetKeyName(4, "bf4.gif");
            this.imgListBFType.Images.SetKeyName(5, "bf5.gif");
            this.imgListBFType.Images.SetKeyName(6, "priorityNormal.gif");
            this.imgListBFType.Images.SetKeyName(7, "priorityHigh.gif");
            this.imgListBFType.Images.SetKeyName(8, "priorityUrgent.gif");
            this.imgListBFType.Images.SetKeyName(9, "FSArchived.ico");
            this.imgListBFType.Images.SetKeyName(10, "FSClosed.ico");
            this.imgListBFType.Images.SetKeyName(11, "FSMonitored.ico");
            this.imgListBFType.Images.SetKeyName(12, "FSOpen.ico");
            this.imgListBFType.Images.SetKeyName(13, "FSPending.ico");
            this.imgListBFType.Images.SetKeyName(14, "RolesBF.gif");
            this.imgListBFType.Images.SetKeyName(15, "DirectBF.gif");
            this.imgListBFType.Images.SetKeyName(16, "OfficeBF.gif");
            this.imgListBFType.Images.SetKeyName(17, "RecipientOfficer2.gif");
            // 
            // bFDateCalendarCombo
            // 
            resources.ApplyResources(this.bFDateCalendarCombo, "bFDateCalendarCombo");
            this.bFDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBFBindingSource, "BFDate", true));
            // 
            // 
            // 
            this.bFDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 2, 1, 0, 0, 0, 0);
            this.bFDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bFDateCalendarCombo.HourIncrement = 0;
            this.bFDateCalendarCombo.MonthIncrement = 0;
            this.bFDateCalendarCombo.Name = "bFDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.bFDateCalendarCombo, ((bool)(resources.GetObject("bFDateCalendarCombo.ShowHelp"))));
            this.bFDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bFDateCalendarCombo.YearIncrement = 0;
            // 
            // lblBF30
            // 
            resources.ApplyResources(this.lblBF30, "lblBF30");
            this.lblBF30.BackColor = System.Drawing.Color.Transparent;
            this.lblBF30.Name = "lblBF30";
            this.helpProvider1.SetShowHelp(this.lblBF30, ((bool)(resources.GetObject("lblBF30.ShowHelp"))));
            // 
            // lblBFCount
            // 
            resources.ApplyResources(this.lblBFCount, "lblBFCount");
            this.lblBFCount.BackColor = System.Drawing.Color.Transparent;
            this.lblBFCount.Name = "lblBFCount";
            this.helpProvider1.SetShowHelp(this.lblBFCount, ((bool)(resources.GetObject("lblBFCount.ShowHelp"))));
            // 
            // priorityJComboBox
            // 
            resources.ApplyResources(this.priorityJComboBox, "priorityJComboBox");
            this.priorityJComboBox.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.priorityJComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.activityBFBindingSource, "Priority", true));
            this.priorityJComboBox.ImageList = this.imgListBFType;
            this.priorityJComboBox.Name = "priorityJComboBox";
            this.helpProvider1.SetShowHelp(this.priorityJComboBox, ((bool)(resources.GetObject("priorityJComboBox.ShowHelp"))));
            this.priorityJComboBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // tbTo
            // 
            resources.ApplyResources(this.tbTo, "tbTo");
            this.tbTo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbTo.Name = "tbTo";
            this.tbTo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbTo, ((bool)(resources.GetObject("tbTo.ShowHelp"))));
            this.tbTo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // BFCommentCounter
            // 
            resources.ApplyResources(this.BFCommentCounter, "BFCommentCounter");
            this.BFCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BFCommentCounter.DecimalDigits = 0;
            this.BFCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.BFCommentCounter.MaxLength = 3;
            this.BFCommentCounter.Name = "BFCommentCounter";
            this.BFCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.BFCommentCounter, ((bool)(resources.GetObject("BFCommentCounter.ShowHelp"))));
            superTipSettings1.ImageListProvider = null;
            this.janusSuperTip1.SetSuperTip(this.BFCommentCounter, superTipSettings1);
            this.BFCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.BFCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BFCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            resources.GetString("comboBox2.Items"),
            resources.GetString("comboBox2.Items1"),
            resources.GetString("comboBox2.Items2")});
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            this.helpProvider1.SetShowHelp(this.comboBox2, ((bool)(resources.GetObject("comboBox2.ShowHelp"))));
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.cbMailFilter_CheckedChanged);
            // 
            // cbMailFilter
            // 
            this.cbMailFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbMailFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            resources.ApplyResources(this.cbMailFilter, "cbMailFilter");
            this.cbMailFilter.Name = "cbMailFilter";
            this.helpProvider1.SetShowHelp(this.cbMailFilter, ((bool)(resources.GetObject("cbMailFilter.ShowHelp"))));
            this.cbMailFilter.CheckedChanged += new System.EventHandler(this.cbMailFilter_CheckedChanged);
            // 
            // chkOnlyBFs
            // 
            this.chkOnlyBFs.BackColor = System.Drawing.Color.Transparent;
            this.chkOnlyBFs.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            resources.ApplyResources(this.chkOnlyBFs, "chkOnlyBFs");
            this.chkOnlyBFs.Name = "chkOnlyBFs";
            this.helpProvider1.SetShowHelp(this.chkOnlyBFs, ((bool)(resources.GetObject("chkOnlyBFs.ShowHelp"))));
            // 
            // pnlEditableFields
            // 
            resources.ApplyResources(this.pnlEditableFields, "pnlEditableFields");
            this.pnlEditableFields.InnerContainer = this.pnlEditableFieldsContainer;
            this.pnlEditableFields.Name = "pnlEditableFields";
            this.helpProvider1.SetShowHelp(this.pnlEditableFields, ((bool)(resources.GetObject("pnlEditableFields.ShowHelp"))));
            // 
            // pnlEditableFieldsContainer
            // 
            resources.ApplyResources(this.pnlEditableFieldsContainer, "pnlEditableFieldsContainer");
            this.pnlEditableFieldsContainer.Name = "pnlEditableFieldsContainer";
            this.helpProvider1.SetShowHelp(this.pnlEditableFieldsContainer, ((bool)(resources.GetObject("pnlEditableFieldsContainer.ShowHelp"))));
            // 
            // pnlPreviewedDoc
            // 
            this.pnlPreviewedDoc.InnerContainer = this.pnlPreviewedDocContainer;
            resources.ApplyResources(this.pnlPreviewedDoc, "pnlPreviewedDoc");
            this.pnlPreviewedDoc.Name = "pnlPreviewedDoc";
            this.helpProvider1.SetShowHelp(this.pnlPreviewedDoc, ((bool)(resources.GetObject("pnlPreviewedDoc.ShowHelp"))));
            // 
            // pnlPreviewedDocContainer
            // 
            this.pnlPreviewedDocContainer.Controls.Add(this.ucDocView1);
            resources.ApplyResources(this.pnlPreviewedDocContainer, "pnlPreviewedDocContainer");
            this.pnlPreviewedDocContainer.Name = "pnlPreviewedDocContainer";
            this.helpProvider1.SetShowHelp(this.pnlPreviewedDocContainer, ((bool)(resources.GetObject("pnlPreviewedDocContainer.ShowHelp"))));
            // 
            // ucDocView1
            // 
            this.ucDocView1.ActionToolbarView = LawMate.UserControls.DocCommandBar.Enable;
            this.ucDocView1.AllowActionToolbar = true;
            this.ucDocView1.AllowMetadata = true;
            this.ucDocView1.AllowMetadataUpdate = false;
            this.ucDocView1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocView1.DocDisplayType = LawMate.UserControls.DocViewDisplayType.MailHeader;
            resources.ApplyResources(this.ucDocView1, "ucDocView1");
            this.ucDocView1.ForceTextControl = true;
            this.ucDocView1.Name = "ucDocView1";
            this.ucDocView1.NoDocDisplayed = false;
            this.ucDocView1.ShowAttachmentPanel = true;
            this.helpProvider1.SetShowHelp(this.ucDocView1, ((bool)(resources.GetObject("ucDocView1.ShowHelp"))));
            this.ucDocView1.ShowMetadata = true;
            this.ucDocView1.ShowVersion = false;
            this.ucDocView1.TempFile = null;
            this.ucDocView1.TempFld = null;
            this.ucDocView1.DocAction += new LawMate.UserControls.DocActionEventHandler(this.ucDoc1_DocAction);
            // 
            // calBFListRange
            // 
            this.calBFListRange.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            resources.ApplyResources(this.calBFListRange, "calBFListRange");
            // 
            // 
            // 
            this.calBFListRange.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calBFListRange.DropDownCalendar.Font")));
            this.calBFListRange.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calBFListRange.HourIncrement = 0;
            this.calBFListRange.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.calBFListRange.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.calBFListRange.MonthIncrement = 0;
            this.calBFListRange.Name = "calBFListRange";
            this.helpProvider1.SetShowHelp(this.calBFListRange, ((bool)(resources.GetObject("calBFListRange.ShowHelp"))));
            this.calBFListRange.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calBFListRange.YearIncrement = 0;
            this.calBFListRange.ValueChanged += new System.EventHandler(this.calBFListRange_ValueChanged);
            // 
            // pnlDoc
            // 
            this.pnlDoc.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlDoc.InnerContainer = this.pnlDocContainer;
            resources.ApplyResources(this.pnlDoc, "pnlDoc");
            this.pnlDoc.Name = "pnlDoc";
            this.helpProvider1.SetShowHelp(this.pnlDoc, ((bool)(resources.GetObject("pnlDoc.ShowHelp"))));
            // 
            // pnlDocContainer
            // 
            resources.ApplyResources(this.pnlDocContainer, "pnlDocContainer");
            this.pnlDocContainer.Name = "pnlDocContainer";
            this.helpProvider1.SetShowHelp(this.pnlDocContainer, ((bool)(resources.GetObject("pnlDocContainer.ShowHelp"))));
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2,
            this.uiCommandBar4});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsCancel2,
            this.tsDelete2,
            this.tsSave2,
            this.tsFilter,
            this.tsScreenTitle,
            this.tsMoreInfo2,
            this.tsMove2,
            this.tsConvert,
            this.tsLblOfficer,
            this.tsOfficer,
            this.tsLblNumBFs,
            this.tsNumBFs,
            this.tsNextSteps,
            this.tsDummy,
            this.tsReload,
            this.tsCompleteBF,
            this.tsEditmode,
            this.cmdMarkAsUnread,
            this.cmdSend,
            this.cmdReply,
            this.cmdReplyAll,
            this.cmdForward,
            this.cmdGroupBy,
            this.cmdGrdExpand,
            this.cmdFieldChooser,
            this.tsLblFilterCount,
            this.tsFilterCount,
            this.cmdEditPanelToggle,
            this.cmdResetGrid,
            this.cmdListRangeLabel,
            this.cmdDateRange,
            this.cmdActions,
            this.cmdFile,
            this.cmdEdit,
            this.cmdGridCommands,
            this.cmdCopyFileNumber});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("ed9c753f-7d41-4171-ae89-4d4866c05652");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.uiCommandManager1_CurrentLayoutChanging);
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            this.uiCommandManager1.CommandPopup += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandPopup);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.AllowMerge = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.cmdActions1,
            this.Separator11,
            this.tsSave4,
            this.tsCancel4,
            this.tsMoreInfo6,
            this.tsReload1,
            this.Separator14,
            this.cmdListRangeLabel1,
            this.cmdDateRange1,
            this.Separator3,
            this.cmdGridCommands1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            this.uiCommandBar1.Wrappable = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.Resize += new System.EventHandler(this.uiCommandBar1_Resize);
            // 
            // tsEditmode1
            // 
            resources.ApplyResources(this.tsEditmode1, "tsEditmode1");
            this.tsEditmode1.Name = "tsEditmode1";
            // 
            // tsScreenTitle1
            // 
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
            // cmdActions1
            // 
            this.cmdActions1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdActions1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdActions1, "cmdActions1");
            this.cmdActions1.Name = "cmdActions1";
            // 
            // Separator11
            // 
            this.Separator11.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator11, "Separator11");
            this.Separator11.Name = "Separator11";
            // 
            // tsSave4
            // 
            resources.ApplyResources(this.tsSave4, "tsSave4");
            this.tsSave4.Name = "tsSave4";
            // 
            // tsCancel4
            // 
            resources.ApplyResources(this.tsCancel4, "tsCancel4");
            this.tsCancel4.Name = "tsCancel4";
            // 
            // tsMoreInfo6
            // 
            resources.ApplyResources(this.tsMoreInfo6, "tsMoreInfo6");
            this.tsMoreInfo6.Name = "tsMoreInfo6";
            // 
            // tsReload1
            // 
            resources.ApplyResources(this.tsReload1, "tsReload1");
            this.tsReload1.Name = "tsReload1";
            // 
            // Separator14
            // 
            this.Separator14.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator14, "Separator14");
            this.Separator14.Name = "Separator14";
            // 
            // cmdListRangeLabel1
            // 
            resources.ApplyResources(this.cmdListRangeLabel1, "cmdListRangeLabel1");
            this.cmdListRangeLabel1.Name = "cmdListRangeLabel1";
            // 
            // cmdDateRange1
            // 
            this.cmdDateRange1.Control = this.calBFListRange;
            resources.ApplyResources(this.cmdDateRange1, "cmdDateRange1");
            this.cmdDateRange1.Name = "cmdDateRange1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdGridCommands1
            // 
            resources.ApplyResources(this.cmdGridCommands1, "cmdGridCommands1");
            this.cmdGridCommands1.Name = "cmdGridCommands1";
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowMerge = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdEditPanelToggle2,
            this.cmdResetGrid2,
            this.cmdGrdExpand2,
            this.tsFilter2,
            this.cmdGroupBy2,
            this.cmdFieldChooser2});
            this.uiCommandBar2.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // cmdEditPanelToggle2
            // 
            resources.ApplyResources(this.cmdEditPanelToggle2, "cmdEditPanelToggle2");
            this.cmdEditPanelToggle2.Name = "cmdEditPanelToggle2";
            // 
            // cmdResetGrid2
            // 
            resources.ApplyResources(this.cmdResetGrid2, "cmdResetGrid2");
            this.cmdResetGrid2.Name = "cmdResetGrid2";
            // 
            // cmdGrdExpand2
            // 
            resources.ApplyResources(this.cmdGrdExpand2, "cmdGrdExpand2");
            this.cmdGrdExpand2.Name = "cmdGrdExpand2";
            // 
            // tsFilter2
            // 
            resources.ApplyResources(this.tsFilter2, "tsFilter2");
            this.tsFilter2.Name = "tsFilter2";
            // 
            // cmdGroupBy2
            // 
            resources.ApplyResources(this.cmdGroupBy2, "cmdGroupBy2");
            this.cmdGroupBy2.Name = "cmdGroupBy2";
            // 
            // cmdFieldChooser2
            // 
            resources.ApplyResources(this.cmdFieldChooser2, "cmdFieldChooser2");
            this.cmdFieldChooser2.Name = "cmdFieldChooser2";
            // 
            // uiCommandBar4
            // 
            this.uiCommandBar4.AllowMerge = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar4.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar4.CommandManager = this.uiCommandManager1;
            this.uiCommandBar4.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1,
            this.cmdActions2});
            resources.ApplyResources(this.uiCommandBar4, "uiCommandBar4");
            this.uiCommandBar4.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar4.Name = "uiCommandBar4";
            this.helpProvider1.SetShowHelp(this.uiCommandBar4, ((bool)(resources.GetObject("uiCommandBar4.ShowHelp"))));
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
            // cmdActions2
            // 
            resources.ApplyResources(this.cmdActions2, "cmdActions2");
            this.cmdActions2.Name = "cmdActions2";
            // 
            // tsCancel2
            // 
            resources.ApplyResources(this.tsCancel2, "tsCancel2");
            this.tsCancel2.Name = "tsCancel2";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // tsFilter
            // 
            this.tsFilter.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.tsFilter.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsFilter, "tsFilter");
            this.tsFilter.Name = "tsFilter";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.tsScreenTitle.ControlWidth = 100;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.ShowInCustomizeDialog = false;
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.StateStyles.FormatStyle.FontName = "tahoma";
            this.tsScreenTitle.StateStyles.FormatStyle.FontSize = 8F;
            // 
            // tsMoreInfo2
            // 
            this.tsMoreInfo2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsMoreInfo2, "tsMoreInfo2");
            this.tsMoreInfo2.Name = "tsMoreInfo2";
            this.tsMoreInfo2.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            // 
            // tsMove2
            // 
            this.tsMove2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsMove2, "tsMove2");
            this.tsMove2.Name = "tsMove2";
            // 
            // tsConvert
            // 
            this.tsConvert.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsConvert.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.tsConvert, "tsConvert");
            this.tsConvert.Name = "tsConvert";
            this.tsConvert.ShowInCustomizeDialog = false;
            // 
            // tsLblOfficer
            // 
            this.tsLblOfficer.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsLblOfficer.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsLblOfficer, "tsLblOfficer");
            this.tsLblOfficer.Name = "tsLblOfficer";
            this.tsLblOfficer.ShowInCustomizeDialog = false;
            this.tsLblOfficer.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleRight;
            // 
            // tsOfficer
            // 
            this.tsOfficer.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsOfficer.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsOfficer, "tsOfficer");
            this.tsOfficer.Name = "tsOfficer";
            this.tsOfficer.ShowInCustomizeDialog = false;
            this.tsOfficer.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsOfficer.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleLeft;
            // 
            // tsLblNumBFs
            // 
            this.tsLblNumBFs.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsLblNumBFs.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsLblNumBFs, "tsLblNumBFs");
            this.tsLblNumBFs.Name = "tsLblNumBFs";
            this.tsLblNumBFs.ShowInCustomizeDialog = false;
            this.tsLblNumBFs.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleRight;
            // 
            // tsNumBFs
            // 
            this.tsNumBFs.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsNumBFs.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsNumBFs, "tsNumBFs");
            this.tsNumBFs.Name = "tsNumBFs";
            this.tsNumBFs.ShowInCustomizeDialog = false;
            this.tsNumBFs.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsNumBFs.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleLeft;
            // 
            // tsNextSteps
            // 
            this.tsNextSteps.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsNextSteps, "tsNextSteps");
            this.tsNextSteps.Name = "tsNextSteps";
            this.tsNextSteps.ShowInCustomizeDialog = false;
            // 
            // tsDummy
            // 
            resources.ApplyResources(this.tsDummy, "tsDummy");
            this.tsDummy.Name = "tsDummy";
            this.tsDummy.ShowInCustomizeDialog = false;
            // 
            // tsReload
            // 
            this.tsReload.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsReload, "tsReload");
            this.tsReload.Name = "tsReload";
            // 
            // tsCompleteBF
            // 
            resources.ApplyResources(this.tsCompleteBF, "tsCompleteBF");
            this.tsCompleteBF.Name = "tsCompleteBF";
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            this.tsEditmode.ControlWidth = 100;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.ShowInCustomizeDialog = false;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "courier new";
            this.tsEditmode.StateStyles.FormatStyle.FontSize = 9F;
            this.tsEditmode.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // cmdMarkAsUnread
            // 
            resources.ApplyResources(this.cmdMarkAsUnread, "cmdMarkAsUnread");
            this.cmdMarkAsUnread.Name = "cmdMarkAsUnread";
            // 
            // cmdSend
            // 
            this.cmdSend.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdReply1,
            this.cmdReplyAll1,
            this.cmdForward1,
            this.Separator12,
            this.cmdMarkAsUnread2,
            this.tsCompleteBF3,
            this.tsMove4,
            this.Separator8,
            this.tsMoreInfo4,
            this.Separator13,
            this.tsConvert3,
            this.tsNextSteps3});
            this.cmdSend.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.cmdSend, "cmdSend");
            this.cmdSend.Name = "cmdSend";
            // 
            // cmdReply1
            // 
            resources.ApplyResources(this.cmdReply1, "cmdReply1");
            this.cmdReply1.Name = "cmdReply1";
            // 
            // cmdReplyAll1
            // 
            resources.ApplyResources(this.cmdReplyAll1, "cmdReplyAll1");
            this.cmdReplyAll1.Name = "cmdReplyAll1";
            // 
            // cmdForward1
            // 
            resources.ApplyResources(this.cmdForward1, "cmdForward1");
            this.cmdForward1.Name = "cmdForward1";
            // 
            // Separator12
            // 
            this.Separator12.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator12, "Separator12");
            this.Separator12.Name = "Separator12";
            // 
            // cmdMarkAsUnread2
            // 
            resources.ApplyResources(this.cmdMarkAsUnread2, "cmdMarkAsUnread2");
            this.cmdMarkAsUnread2.Name = "cmdMarkAsUnread2";
            // 
            // tsCompleteBF3
            // 
            resources.ApplyResources(this.tsCompleteBF3, "tsCompleteBF3");
            this.tsCompleteBF3.Name = "tsCompleteBF3";
            // 
            // tsMove4
            // 
            resources.ApplyResources(this.tsMove4, "tsMove4");
            this.tsMove4.Name = "tsMove4";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator8, "Separator8");
            this.Separator8.Name = "Separator8";
            // 
            // tsMoreInfo4
            // 
            resources.ApplyResources(this.tsMoreInfo4, "tsMoreInfo4");
            this.tsMoreInfo4.Name = "tsMoreInfo4";
            // 
            // Separator13
            // 
            this.Separator13.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator13, "Separator13");
            this.Separator13.Name = "Separator13";
            // 
            // tsConvert3
            // 
            resources.ApplyResources(this.tsConvert3, "tsConvert3");
            this.tsConvert3.Name = "tsConvert3";
            // 
            // tsNextSteps3
            // 
            resources.ApplyResources(this.tsNextSteps3, "tsNextSteps3");
            this.tsNextSteps3.Name = "tsNextSteps3";
            // 
            // cmdReply
            // 
            this.cmdReply.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdReply, "cmdReply");
            this.cmdReply.Name = "cmdReply";
            // 
            // cmdReplyAll
            // 
            this.cmdReplyAll.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdReplyAll, "cmdReplyAll");
            this.cmdReplyAll.Name = "cmdReplyAll";
            // 
            // cmdForward
            // 
            this.cmdForward.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdForward, "cmdForward");
            this.cmdForward.Name = "cmdForward";
            // 
            // cmdGroupBy
            // 
            this.cmdGroupBy.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdGroupBy.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdGroupBy, "cmdGroupBy");
            this.cmdGroupBy.Name = "cmdGroupBy";
            // 
            // cmdGrdExpand
            // 
            this.cmdGrdExpand.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdGrdExpand, "cmdGrdExpand");
            this.cmdGrdExpand.Name = "cmdGrdExpand";
            // 
            // cmdFieldChooser
            // 
            this.cmdFieldChooser.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdFieldChooser, "cmdFieldChooser");
            this.cmdFieldChooser.Name = "cmdFieldChooser";
            // 
            // tsLblFilterCount
            // 
            this.tsLblFilterCount.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsLblFilterCount.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsLblFilterCount, "tsLblFilterCount");
            this.tsLblFilterCount.Name = "tsLblFilterCount";
            this.tsLblFilterCount.ShowInCustomizeDialog = false;
            this.tsLblFilterCount.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleRight;
            // 
            // tsFilterCount
            // 
            this.tsFilterCount.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsFilterCount.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsFilterCount, "tsFilterCount");
            this.tsFilterCount.Name = "tsFilterCount";
            this.tsFilterCount.ShowInCustomizeDialog = false;
            this.tsFilterCount.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsFilterCount.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleLeft;
            // 
            // cmdEditPanelToggle
            // 
            this.cmdEditPanelToggle.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdEditPanelToggle.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdEditPanelToggle, "cmdEditPanelToggle");
            this.cmdEditPanelToggle.Name = "cmdEditPanelToggle";
            this.cmdEditPanelToggle.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdResetGrid
            // 
            resources.ApplyResources(this.cmdResetGrid, "cmdResetGrid");
            this.cmdResetGrid.Name = "cmdResetGrid";
            // 
            // cmdListRangeLabel
            // 
            this.cmdListRangeLabel.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdListRangeLabel.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdListRangeLabel, "cmdListRangeLabel");
            this.cmdListRangeLabel.Name = "cmdListRangeLabel";
            this.cmdListRangeLabel.ShowInCustomizeDialog = false;
            // 
            // cmdDateRange
            // 
            this.cmdDateRange.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdDateRange.CommandType = Janus.Windows.UI.CommandBars.CommandType.ControlContainer;
            this.cmdDateRange.Control = this.calBFListRange;
            resources.ApplyResources(this.cmdDateRange, "cmdDateRange");
            this.cmdDateRange.Name = "cmdDateRange";
            this.cmdDateRange.ShowInCustomizeDialog = false;
            // 
            // cmdActions
            // 
            this.cmdActions.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.Separator10,
            this.cmdReply4,
            this.cmdReplyAll3,
            this.cmdForward3,
            this.Separator2,
            this.cmdMarkAsUnread3,
            this.tsCompleteBF1,
            this.tsMove1,
            this.Separator6,
            this.tsMoreInfo1,
            this.cmdCopyFileNumber2,
            this.Separator5,
            this.tsConvert2,
            this.tsNextSteps2});
            resources.ApplyResources(this.cmdActions, "cmdActions");
            this.cmdActions.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdActions.Name = "cmdActions";
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator10, "Separator10");
            this.Separator10.Name = "Separator10";
            // 
            // cmdReply4
            // 
            resources.ApplyResources(this.cmdReply4, "cmdReply4");
            this.cmdReply4.Name = "cmdReply4";
            // 
            // cmdReplyAll3
            // 
            resources.ApplyResources(this.cmdReplyAll3, "cmdReplyAll3");
            this.cmdReplyAll3.Name = "cmdReplyAll3";
            // 
            // cmdForward3
            // 
            resources.ApplyResources(this.cmdForward3, "cmdForward3");
            this.cmdForward3.Name = "cmdForward3";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdMarkAsUnread3
            // 
            resources.ApplyResources(this.cmdMarkAsUnread3, "cmdMarkAsUnread3");
            this.cmdMarkAsUnread3.Name = "cmdMarkAsUnread3";
            // 
            // tsCompleteBF1
            // 
            resources.ApplyResources(this.tsCompleteBF1, "tsCompleteBF1");
            this.tsCompleteBF1.Name = "tsCompleteBF1";
            // 
            // tsMove1
            // 
            resources.ApplyResources(this.tsMove1, "tsMove1");
            this.tsMove1.Name = "tsMove1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // tsMoreInfo1
            // 
            resources.ApplyResources(this.tsMoreInfo1, "tsMoreInfo1");
            this.tsMoreInfo1.Name = "tsMoreInfo1";
            // 
            // cmdCopyFileNumber2
            // 
            resources.ApplyResources(this.cmdCopyFileNumber2, "cmdCopyFileNumber2");
            this.cmdCopyFileNumber2.Name = "cmdCopyFileNumber2";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // tsConvert2
            // 
            resources.ApplyResources(this.tsConvert2, "tsConvert2");
            this.tsConvert2.Name = "tsConvert2";
            // 
            // tsNextSteps2
            // 
            resources.ApplyResources(this.tsNextSteps2, "tsNextSteps2");
            this.tsNextSteps2.Name = "tsNextSteps2";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsCancel1,
            this.tsDelete1});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsCancel1
            // 
            resources.ApplyResources(this.tsCancel1, "tsCancel1");
            this.tsCancel1.Name = "tsCancel1";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
            // 
            // cmdGridCommands
            // 
            this.cmdGridCommands.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdResetGrid1,
            this.cmdGrdExpand1,
            this.tsFilter1,
            this.cmdGroupBy1,
            this.cmdFieldChooser1});
            this.cmdGridCommands.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdGridCommands, "cmdGridCommands");
            this.cmdGridCommands.Name = "cmdGridCommands";
            // 
            // cmdResetGrid1
            // 
            resources.ApplyResources(this.cmdResetGrid1, "cmdResetGrid1");
            this.cmdResetGrid1.Name = "cmdResetGrid1";
            // 
            // cmdGrdExpand1
            // 
            resources.ApplyResources(this.cmdGrdExpand1, "cmdGrdExpand1");
            this.cmdGrdExpand1.Name = "cmdGrdExpand1";
            // 
            // tsFilter1
            // 
            resources.ApplyResources(this.tsFilter1, "tsFilter1");
            this.tsFilter1.Name = "tsFilter1";
            // 
            // cmdGroupBy1
            // 
            resources.ApplyResources(this.cmdGroupBy1, "cmdGroupBy1");
            this.cmdGroupBy1.Name = "cmdGroupBy1";
            // 
            // cmdFieldChooser1
            // 
            resources.ApplyResources(this.cmdFieldChooser1, "cmdFieldChooser1");
            this.cmdFieldChooser1.Name = "cmdFieldChooser1";
            // 
            // cmdCopyFileNumber
            // 
            resources.ApplyResources(this.cmdCopyFileNumber, "cmdCopyFileNumber");
            this.cmdCopyFileNumber.Name = "cmdCopyFileNumber";
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdReply2,
            this.cmdReplyAll2,
            this.cmdForward2,
            this.Separator9,
            this.cmdMarkAsUnread1,
            this.tsCompleteBF2,
            this.tsMove3,
            this.Separator4,
            this.tsMoreInfo3,
            this.cmdCopyFileNumber1,
            this.Separator7,
            this.tsConvert1,
            this.tsNextSteps1});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.Popup += new System.EventHandler(this.uiContextMenu1_Popup);
            // 
            // cmdReply2
            // 
            resources.ApplyResources(this.cmdReply2, "cmdReply2");
            this.cmdReply2.Name = "cmdReply2";
            // 
            // cmdReplyAll2
            // 
            resources.ApplyResources(this.cmdReplyAll2, "cmdReplyAll2");
            this.cmdReplyAll2.Name = "cmdReplyAll2";
            // 
            // cmdForward2
            // 
            resources.ApplyResources(this.cmdForward2, "cmdForward2");
            this.cmdForward2.Name = "cmdForward2";
            // 
            // Separator9
            // 
            this.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator9, "Separator9");
            this.Separator9.Name = "Separator9";
            // 
            // cmdMarkAsUnread1
            // 
            resources.ApplyResources(this.cmdMarkAsUnread1, "cmdMarkAsUnread1");
            this.cmdMarkAsUnread1.Name = "cmdMarkAsUnread1";
            // 
            // tsCompleteBF2
            // 
            resources.ApplyResources(this.tsCompleteBF2, "tsCompleteBF2");
            this.tsCompleteBF2.Name = "tsCompleteBF2";
            // 
            // tsMove3
            // 
            resources.ApplyResources(this.tsMove3, "tsMove3");
            this.tsMove3.Name = "tsMove3";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsMoreInfo3
            // 
            resources.ApplyResources(this.tsMoreInfo3, "tsMoreInfo3");
            this.tsMoreInfo3.Name = "tsMoreInfo3";
            // 
            // cmdCopyFileNumber1
            // 
            resources.ApplyResources(this.cmdCopyFileNumber1, "cmdCopyFileNumber1");
            this.cmdCopyFileNumber1.Name = "cmdCopyFileNumber1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // tsConvert1
            // 
            resources.ApplyResources(this.tsConvert1, "tsConvert1");
            this.tsConvert1.Name = "tsConvert1";
            // 
            // tsNextSteps1
            // 
            resources.ApplyResources(this.tsNextSteps1, "tsNextSteps1");
            this.tsNextSteps1.Name = "tsNextSteps1";
            // 
            // imageListBase
            // 
            this.imageListBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBase.ImageStream")));
            this.imageListBase.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBase.Images.SetKeyName(0, "find.gif");
            this.imageListBase.Images.SetKeyName(1, "cancel.gif");
            this.imageListBase.Images.SetKeyName(2, "delete.gif");
            this.imageListBase.Images.SetKeyName(3, "filter.gif");
            this.imageListBase.Images.SetKeyName(4, "shortcut.gif");
            this.imageListBase.Images.SetKeyName(5, "bo.gif");
            this.imageListBase.Images.SetKeyName(6, "browse.gif");
            this.imageListBase.Images.SetKeyName(7, "bs.gif");
            this.imageListBase.Images.SetKeyName(8, "cal.gif");
            this.imageListBase.Images.SetKeyName(9, "drafts.gif");
            this.imageListBase.Images.SetKeyName(10, "help.gif");
            this.imageListBase.Images.SetKeyName(11, "information.gif");
            this.imageListBase.Images.SetKeyName(12, "lang.gif");
            this.imageListBase.Images.SetKeyName(13, "moveFolder.gif");
            this.imageListBase.Images.SetKeyName(14, "msgS.gif");
            this.imageListBase.Images.SetKeyName(15, "newDoc.gif");
            this.imageListBase.Images.SetKeyName(16, "save.gif");
            this.imageListBase.Images.SetKeyName(17, "search.gif");
            this.imageListBase.Images.SetKeyName(18, "reload.gif");
            this.imageListBase.Images.SetKeyName(19, "checkbox.gif");
            this.imageListBase.Images.SetKeyName(20, "DRedit.gif");
            this.imageListBase.Images.SetKeyName(21, "mail2.gif");
            this.imageListBase.Images.SetKeyName(22, "MarkasRead.gif");
            this.imageListBase.Images.SetKeyName(23, "replyAll.gif");
            this.imageListBase.Images.SetKeyName(24, "forward.gif");
            this.imageListBase.Images.SetKeyName(25, "reply.gif");
            this.imageListBase.Images.SetKeyName(26, "sentItems.gif");
            this.imageListBase.Images.SetKeyName(27, "uncheckbox.gif");
            this.imageListBase.Images.SetKeyName(28, "colSet.gif");
            this.imageListBase.Images.SetKeyName(29, "panel.gif");
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
            this.uiCommandBar4});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Controls.Add(this.uiCommandBar4);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // timerReadMail
            // 
            this.timerReadMail.Interval = 1000;
            this.timerReadMail.Tick += new System.EventHandler(this.timerReadMail_Tick);
            // 
            // tsDummy3
            // 
            resources.ApplyResources(this.tsDummy3, "tsDummy3");
            this.tsDummy3.Name = "tsDummy3";
            // 
            // janusSuperTip1
            // 
            this.janusSuperTip1.AutoPopDelay = 30000;
            this.janusSuperTip1.BodyWidth = 200;
            this.janusSuperTip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.janusSuperTip1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.janusSuperTip1.ImageList = null;
            this.janusSuperTip1.InitialDelay = 200;
            // 
            // timrefresh
            // 
            this.timrefresh.Enabled = true;
            this.timrefresh.Interval = 120000;
            this.timrefresh.Tick += new System.EventHandler(this.timrefresh_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // fBFList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlParent);
            this.Controls.Add(this.pnlNoBFs);
            this.Controls.Add(this.TopRebar1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "fBFList";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Activated += new System.EventHandler(this.fBFList_Activated);
            this.Deactivate += new System.EventHandler(this.fBFList_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fBFList_FormClosing);
            this.Load += new System.EventHandler(this.fBFList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fBFList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNoBFs)).EndInit();
            this.pnlNoBFs.ResumeLayout(false);
            this.pnlNoBFsContainer.ResumeLayout(false);
            this.pnlNoBFsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlParent)).EndInit();
            this.pnlParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTopContainer.ResumeLayout(false);
            this.pnlTopContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditableFields)).EndInit();
            this.pnlEditableFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPreviewedDoc)).EndInit();
            this.pnlPreviewedDoc.ResumeLayout(false);
            this.pnlPreviewedDocContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).EndInit();
            this.pnlDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            this.uiCommandBar1.ResumeLayout(false);
            this.uiCommandBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.GridEX.GridEX activityBFGridEX;
        private System.Windows.Forms.BindingSource activityBFBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo bFDateCalendarCombo;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsCancel2;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsMoreInfo2;
        private Janus.Windows.UI.CommandBars.UICommand tsMove2;
        private Janus.Windows.UI.CommandBars.UICommand tsConvert;
        protected System.Windows.Forms.ImageList imageListBase;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand tsLblOfficer;
        private Janus.Windows.UI.CommandBars.UICommand tsOfficer;
        private Janus.Windows.UI.CommandBars.UICommand tsLblNumBFs;
        private Janus.Windows.UI.CommandBars.UICommand tsNumBFs;
        private Janus.Windows.UI.CommandBars.UICommand tsNextSteps;
        private Janus.Windows.UI.CommandBars.UICommand tsNextSteps1;
        private System.Windows.Forms.Timer timerReadMail;
        private Janus.Windows.UI.Dock.UIPanel pnlDoc;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocContainer;
        private System.Windows.Forms.ComboBox comboBox2;
        private Janus.Windows.UI.CommandBars.UICommand tsDummy;
        private Janus.Windows.UI.CommandBars.UICommand tsConvert1;
        private Janus.Windows.UI.CommandBars.UICommand tsDummy3;
        private Janus.Windows.UI.CommandBars.UICommand tsReload;
        private Janus.Windows.UI.CommandBars.UICommand tsCompleteBF;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand cmdMarkAsUnread;
        private Janus.Windows.UI.CommandBars.UICommand cmdMarkAsUnread1;
        private Janus.Windows.UI.CommandBars.UICommand tsCompleteBF2;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand tsMoreInfo3;
        private Janus.Windows.UI.CommandBars.UICommand tsMove3;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private System.Windows.Forms.ImageList imgListBFType;
        private Janus.Windows.UI.CommandBars.UICommand cmdSend;
        private Janus.Windows.UI.CommandBars.UICommand cmdReply1;
        private Janus.Windows.UI.CommandBars.UICommand cmdReplyAll1;
        private Janus.Windows.UI.CommandBars.UICommand cmdForward1;
        private Janus.Windows.UI.CommandBars.UICommand cmdReply;
        private Janus.Windows.UI.CommandBars.UICommand cmdReplyAll;
        private Janus.Windows.UI.CommandBars.UICommand cmdForward;
        private Janus.Windows.UI.CommandBars.UICommand cmdReply2;
        private Janus.Windows.UI.CommandBars.UICommand cmdReplyAll2;
        private Janus.Windows.UI.CommandBars.UICommand cmdForward2;
        private Janus.Windows.UI.CommandBars.UICommand Separator9;
        private Janus.Windows.EditControls.UIComboBox priorityJComboBox;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroupBy;
        private Janus.Windows.UI.CommandBars.UICommand cmdGrdExpand;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser;
        private Janus.Windows.EditControls.UICheckBox cbMailFilter;
        private Janus.Windows.UI.Dock.UIPanel pnlNoBFs;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlNoBFsContainer;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.UI.CommandBars.UICommand tsLblFilterCount;
        private Janus.Windows.UI.CommandBars.UICommand tsFilterCount;
        private Janus.Windows.GridEX.EditControls.NumericEditBox BFCommentCounter;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
        private Janus.Windows.GridEX.EditControls.EditBox tbTo;
        private System.Windows.Forms.Label lblMailIcon;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditPanelToggle;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlParent;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlEditableFields;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlEditableFieldsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlPreviewedDoc;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlPreviewedDocContainer;
        private Janus.Windows.UI.CommandBars.UICommand Separator12;
        private Janus.Windows.UI.CommandBars.UICommand tsCompleteBF3;
        private Janus.Windows.UI.CommandBars.UICommand tsMove4;
        private Janus.Windows.UI.CommandBars.UICommand cmdMarkAsUnread2;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.UI.CommandBars.UICommand tsMoreInfo4;
        private Janus.Windows.UI.CommandBars.UICommand Separator13;
        private Janus.Windows.UI.CommandBars.UICommand tsConvert3;
        private Janus.Windows.UI.CommandBars.UICommand tsNextSteps3;
        private System.Windows.Forms.Timer timrefresh;
        private Janus.Windows.CalendarCombo.CalendarCombo calBFListRange;
        private System.Windows.Forms.Label lblBF30;
        private System.Windows.Forms.Label lblBFCount;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGrid;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditPanelToggle2;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGrid2;
        private Janus.Windows.UI.CommandBars.UICommand cmdGrdExpand2;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter2;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroupBy2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand cmdListRangeLabel;
        private Janus.Windows.UI.CommandBars.UICommand cmdListRangeLabel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDateRange;
        private Janus.Windows.UI.CommandBars.UICommand cmdDateRange1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdActions;
        private Janus.Windows.UI.CommandBars.UICommand cmdReplyAll3;
        private Janus.Windows.UI.CommandBars.UICommand cmdForward3;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdMarkAsUnread3;
        private Janus.Windows.UI.CommandBars.UICommand tsCompleteBF1;
        private Janus.Windows.UI.CommandBars.UICommand tsMove1;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand tsMoreInfo1;
        private Janus.Windows.UI.CommandBars.UICommand tsConvert2;
        private Janus.Windows.UI.CommandBars.UICommand tsNextSteps2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar4;
        private Janus.Windows.UI.CommandBars.UICommand cmdActions2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsCancel1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand Separator11;
        private Janus.Windows.UI.CommandBars.UICommand tsSave4;
        private Janus.Windows.UI.CommandBars.UICommand tsCancel4;
        private Janus.Windows.UI.CommandBars.UICommand tsMoreInfo6;
        private Janus.Windows.UI.CommandBars.UICommand tsReload1;
        private Janus.Windows.UI.CommandBars.UICommand Separator14;
        private Janus.Windows.UI.CommandBars.UICommand cmdActions1;
        private Janus.Windows.UI.CommandBars.UICommand cmdReply4;
        private Janus.Windows.GridEX.EditControls.EditBox bFCommentEditBox;
        private UserControls.ucDocView ucDocView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridCommands;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGrid1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGrdExpand1;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroupBy1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridCommands1;
        private System.Windows.Forms.Label bFOfficerCodeLabel;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Label bFDateLabel;
        private System.Windows.Forms.Label bFCommentLabel;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.EditControls.UICheckBox chkOnlyBFs;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyFileNumber;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyFileNumber1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyFileNumber2;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
    }
}
