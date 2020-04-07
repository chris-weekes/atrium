namespace LawMate.UserControls
{
    partial class ucDocView
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
            lmDatasets.docDB docDB;
            System.Windows.Forms.Label checkedOutDateLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDocView));
            System.Windows.Forms.Label checkedOutByLabel;
            System.Windows.Forms.Label checkedOutPathLabel;
            System.Windows.Forms.Label docIdLabel;
            System.Windows.Forms.Label sourceLabel;
            System.Windows.Forms.Label commModeLabel;
            System.Windows.Forms.Label efDateLabel;
            System.Windows.Forms.Label efSubjectLabel;
            System.Windows.Forms.Label sentTimeLabel;
            System.Windows.Forms.Label receivedTimeLabel;
            System.Windows.Forms.Label filedByLabel;
            System.Windows.Forms.Label authorLabel;
            System.Windows.Forms.Label conversationIndexLabel;
            System.Windows.Forms.Label entryUserLabel;
            System.Windows.Forms.Label entryDateLabel;
            System.Windows.Forms.Label updateUserLabel;
            System.Windows.Forms.Label updateDateLabel;
            System.Windows.Forms.Label extLabel;
            System.Windows.Forms.Label modDateLabel;
            System.Windows.Forms.Label createDateLabel;
            System.Windows.Forms.Label sizeLabel;
            System.Windows.Forms.Label versionLabel;
            System.Windows.Forms.Label updateUserLabel1;
            System.Windows.Forms.Label updateDateLabel1;
            System.Windows.Forms.Label lblPageCount;
            System.Windows.Forms.Label efTypeLabel;
            System.Windows.Forms.Label sourceDivisionLabel;
            System.Windows.Forms.Label sentToESDCLabel;
            System.Windows.Forms.Label sentDateLabel;
            System.Windows.Forms.Label sentByLabel;
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sentIndicatorImageList = new System.Windows.Forms.ImageList(this.components);
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.tabDocument = new Janus.Windows.UI.Tab.UITabPage();
            this.pnlHideDocDisplay = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlHideDocDisplayContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnLoadLargeDoc = new Janus.Windows.EditControls.UIButton();
            this.lblHideContentMessage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLaunchExcel = new Janus.Windows.EditControls.UIButton();
            this.pnlDocView = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocViewContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnExternalApp = new Janus.Windows.EditControls.UIButton();
            this.btnDraftWatermark = new Janus.Windows.EditControls.UIButton();
            this.textControlCompose = new TXTextControl.TextControl();
            this.axEDOffice1 = new AxEDOfficeLib.AxEDOffice();
            this.ucWB1 = new LawMate.UserControls.ucWB();
            this.pnlStatusBar = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlStatusBarContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.pnlCommandBar = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlCommandBarContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdPrint = new Janus.Windows.UI.CommandBars.UICommand("cmdPrint");
            this.cmdPrintPreview = new Janus.Windows.UI.CommandBars.UICommand("cmdPrintPreview");
            this.cmdRevise = new Janus.Windows.UI.CommandBars.UICommand("cmdRevise");
            this.cmdCheckInCheckOut = new Janus.Windows.UI.CommandBars.UICommand("cmdCheckInCheckOut");
            this.cmdCheckOut1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCheckOut");
            this.cmdUndoCheckOut1 = new Janus.Windows.UI.CommandBars.UICommand("cmdUndoCheckOut");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCheckIn1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCheckIn");
            this.cmdCopy = new Janus.Windows.UI.CommandBars.UICommand("cmdCopy");
            this.cmdCopyBrowse1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyBrowse");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCopyClipboard1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyClipboard");
            this.cmdMakeReadOnly = new Janus.Windows.UI.CommandBars.UICommand("cmdMakeReadOnly");
            this.cmdDocViewer = new Janus.Windows.UI.CommandBars.UICommand("cmdDocViewer");
            this.cmdExternalApp = new Janus.Windows.UI.CommandBars.UICommand("cmdExternalApp");
            this.cmdCheckIn = new Janus.Windows.UI.CommandBars.UICommand("cmdCheckIn");
            this.cmdCheckOut = new Janus.Windows.UI.CommandBars.UICommand("cmdCheckOut");
            this.cmdUndoCheckOut = new Janus.Windows.UI.CommandBars.UICommand("cmdUndoCheckOut");
            this.cmdCopyBrowse = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyBrowse");
            this.cmdCopyOpen1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyOpen");
            this.cmdCopyNoOpen1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyNoOpen");
            this.cmdCopyOpen = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyOpen");
            this.cmdCopyNoOpen = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyNoOpen");
            this.cmdCopyClipboard = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyClipboard");
            this.cmdDocShortcut = new Janus.Windows.UI.CommandBars.UICommand("cmdDocShortcut");
            this.cmdViewVersionHistory = new Janus.Windows.UI.CommandBars.UICommand("cmdViewVersionHistory");
            this.cmdConvertToPDF = new Janus.Windows.UI.CommandBars.UICommand("cmdConvertToPDF");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdPrint1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPrint");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDocShortcut1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocShortcut");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdRevise1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRevise");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCheckInCheckOut1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCheckInCheckOut");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCopy1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopy");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMakeReadOnly1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMakeReadOnly");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDocViewer1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocViewer");
            this.Separator9 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdExternalApp1 = new Janus.Windows.UI.CommandBars.UICommand("cmdExternalApp");
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdViewVersionHistory1 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewVersionHistory");
            this.cmdConvertToPDF1 = new Janus.Windows.UI.CommandBars.UICommand("cmdConvertToPDF");
            this.pnlAttachment = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAttachmentContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMessageRead = new Janus.Windows.EditControls.UIButton();
            this.pnlAttachTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAttachTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.calAttachLastChanged = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ebAttachAuthor = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebAttachSize = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebAttachFileName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlDocTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.calEfDateDoc = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSubjectDoc = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlEmailTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlFromContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.tbSubjectMail = new Janus.Windows.GridEX.EditControls.EditBox();
            this.calEfDateMail = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.tbTo = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblCC = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.tbFrom = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tbCC = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlCheckOut = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlCheckOutContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lnkEditCheckedOutDocument = new Janus.Windows.EditControls.UIButton();
            this.editBox8 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.tabMetadata = new Janus.Windows.UI.Tab.UITabPage();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.sentToESDCEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sentUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sentDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ddSourceDivision = new LawMate.UserControls.ucMultiDropDown();
            this.editPageCount = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.efSubjectEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.docIdEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.updateDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.updateDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.docContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.documentDocContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.efDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.versionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.updateUserEditBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sizeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.readOnlyUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.extEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sentTimeCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.receivedTimeCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.updateUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.createDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.entryDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.isDraftUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.entryUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.efTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.modDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.conversationIndexEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.commModeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.filedByEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sourceEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.authorEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.gbRecipients = new Janus.Windows.EditControls.UIGroupBox();
            this.ucRecipientTextBoxFrom = new LawMate.ucRecipientTextBox();
            this.buttonCC = new Janus.Windows.EditControls.UIButton();
            this.isLawmailUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.buttonTo = new Janus.Windows.EditControls.UIButton();
            this.ucRecipientTextBoxTo = new LawMate.ucRecipientTextBox();
            this.buttonFrom = new Janus.Windows.EditControls.UIButton();
            this.ucRecipientTextBoxCc = new LawMate.ucRecipientTextBox();
            this.tabVersionning = new Janus.Windows.UI.Tab.UITabPage();
            this.tabNoDoc = new Janus.Windows.UI.Tab.UITabPage();
            this.lblNoDocumentText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNoDoc = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.timPreview = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            docDB = new lmDatasets.docDB();
            checkedOutDateLabel = new System.Windows.Forms.Label();
            checkedOutByLabel = new System.Windows.Forms.Label();
            checkedOutPathLabel = new System.Windows.Forms.Label();
            docIdLabel = new System.Windows.Forms.Label();
            sourceLabel = new System.Windows.Forms.Label();
            commModeLabel = new System.Windows.Forms.Label();
            efDateLabel = new System.Windows.Forms.Label();
            efSubjectLabel = new System.Windows.Forms.Label();
            sentTimeLabel = new System.Windows.Forms.Label();
            receivedTimeLabel = new System.Windows.Forms.Label();
            filedByLabel = new System.Windows.Forms.Label();
            authorLabel = new System.Windows.Forms.Label();
            conversationIndexLabel = new System.Windows.Forms.Label();
            entryUserLabel = new System.Windows.Forms.Label();
            entryDateLabel = new System.Windows.Forms.Label();
            updateUserLabel = new System.Windows.Forms.Label();
            updateDateLabel = new System.Windows.Forms.Label();
            extLabel = new System.Windows.Forms.Label();
            modDateLabel = new System.Windows.Forms.Label();
            createDateLabel = new System.Windows.Forms.Label();
            sizeLabel = new System.Windows.Forms.Label();
            versionLabel = new System.Windows.Forms.Label();
            updateUserLabel1 = new System.Windows.Forms.Label();
            updateDateLabel1 = new System.Windows.Forms.Label();
            lblPageCount = new System.Windows.Forms.Label();
            efTypeLabel = new System.Windows.Forms.Label();
            sourceDivisionLabel = new System.Windows.Forms.Label();
            sentToESDCLabel = new System.Windows.Forms.Label();
            sentDateLabel = new System.Windows.Forms.Label();
            sentByLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(docDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.tabDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHideDocDisplay)).BeginInit();
            this.pnlHideDocDisplay.SuspendLayout();
            this.pnlHideDocDisplayContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocView)).BeginInit();
            this.pnlDocView.SuspendLayout();
            this.pnlDocViewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axEDOffice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStatusBar)).BeginInit();
            this.pnlStatusBar.SuspendLayout();
            this.pnlStatusBarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommandBar)).BeginInit();
            this.pnlCommandBar.SuspendLayout();
            this.pnlCommandBarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAttachment)).BeginInit();
            this.pnlAttachment.SuspendLayout();
            this.pnlAttachmentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAttachTop)).BeginInit();
            this.pnlAttachTop.SuspendLayout();
            this.pnlAttachTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocTop)).BeginInit();
            this.pnlDocTop.SuspendLayout();
            this.pnlDocTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailTop)).BeginInit();
            this.pnlEmailTop.SuspendLayout();
            this.pnlFromContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCheckOut)).BeginInit();
            this.pnlCheckOut.SuspendLayout();
            this.pnlCheckOutContainer.SuspendLayout();
            this.tabMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentDocContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRecipients)).BeginInit();
            this.gbRecipients.SuspendLayout();
            this.tabNoDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // docDB
            // 
            docDB.DataSetName = "docDB";
            docDB.EnforceConstraints = false;
            docDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkedOutDateLabel
            // 
            resources.ApplyResources(checkedOutDateLabel, "checkedOutDateLabel");
            checkedOutDateLabel.BackColor = System.Drawing.Color.Transparent;
            checkedOutDateLabel.Name = "checkedOutDateLabel";
            // 
            // checkedOutByLabel
            // 
            resources.ApplyResources(checkedOutByLabel, "checkedOutByLabel");
            checkedOutByLabel.BackColor = System.Drawing.Color.Transparent;
            checkedOutByLabel.Name = "checkedOutByLabel";
            // 
            // checkedOutPathLabel
            // 
            resources.ApplyResources(checkedOutPathLabel, "checkedOutPathLabel");
            checkedOutPathLabel.BackColor = System.Drawing.Color.Transparent;
            checkedOutPathLabel.Name = "checkedOutPathLabel";
            // 
            // docIdLabel
            // 
            resources.ApplyResources(docIdLabel, "docIdLabel");
            docIdLabel.BackColor = System.Drawing.Color.Transparent;
            docIdLabel.Name = "docIdLabel";
            // 
            // sourceLabel
            // 
            resources.ApplyResources(sourceLabel, "sourceLabel");
            sourceLabel.BackColor = System.Drawing.Color.Transparent;
            sourceLabel.Name = "sourceLabel";
            // 
            // commModeLabel
            // 
            resources.ApplyResources(commModeLabel, "commModeLabel");
            commModeLabel.BackColor = System.Drawing.Color.Transparent;
            commModeLabel.Name = "commModeLabel";
            // 
            // efDateLabel
            // 
            resources.ApplyResources(efDateLabel, "efDateLabel");
            efDateLabel.BackColor = System.Drawing.Color.Transparent;
            efDateLabel.Name = "efDateLabel";
            // 
            // efSubjectLabel
            // 
            resources.ApplyResources(efSubjectLabel, "efSubjectLabel");
            efSubjectLabel.BackColor = System.Drawing.Color.Transparent;
            efSubjectLabel.Name = "efSubjectLabel";
            // 
            // sentTimeLabel
            // 
            resources.ApplyResources(sentTimeLabel, "sentTimeLabel");
            sentTimeLabel.BackColor = System.Drawing.Color.Transparent;
            sentTimeLabel.Name = "sentTimeLabel";
            // 
            // receivedTimeLabel
            // 
            resources.ApplyResources(receivedTimeLabel, "receivedTimeLabel");
            receivedTimeLabel.BackColor = System.Drawing.Color.Transparent;
            receivedTimeLabel.Name = "receivedTimeLabel";
            // 
            // filedByLabel
            // 
            resources.ApplyResources(filedByLabel, "filedByLabel");
            filedByLabel.BackColor = System.Drawing.Color.Transparent;
            filedByLabel.Name = "filedByLabel";
            // 
            // authorLabel
            // 
            resources.ApplyResources(authorLabel, "authorLabel");
            authorLabel.BackColor = System.Drawing.Color.Transparent;
            authorLabel.Name = "authorLabel";
            // 
            // conversationIndexLabel
            // 
            resources.ApplyResources(conversationIndexLabel, "conversationIndexLabel");
            conversationIndexLabel.BackColor = System.Drawing.Color.Transparent;
            conversationIndexLabel.Name = "conversationIndexLabel";
            // 
            // entryUserLabel
            // 
            resources.ApplyResources(entryUserLabel, "entryUserLabel");
            entryUserLabel.BackColor = System.Drawing.Color.Transparent;
            entryUserLabel.Name = "entryUserLabel";
            // 
            // entryDateLabel
            // 
            resources.ApplyResources(entryDateLabel, "entryDateLabel");
            entryDateLabel.BackColor = System.Drawing.Color.Transparent;
            entryDateLabel.Name = "entryDateLabel";
            // 
            // updateUserLabel
            // 
            resources.ApplyResources(updateUserLabel, "updateUserLabel");
            updateUserLabel.BackColor = System.Drawing.Color.Transparent;
            updateUserLabel.Name = "updateUserLabel";
            // 
            // updateDateLabel
            // 
            resources.ApplyResources(updateDateLabel, "updateDateLabel");
            updateDateLabel.BackColor = System.Drawing.Color.Transparent;
            updateDateLabel.Name = "updateDateLabel";
            // 
            // extLabel
            // 
            resources.ApplyResources(extLabel, "extLabel");
            extLabel.BackColor = System.Drawing.Color.Transparent;
            extLabel.Name = "extLabel";
            // 
            // modDateLabel
            // 
            resources.ApplyResources(modDateLabel, "modDateLabel");
            modDateLabel.BackColor = System.Drawing.Color.Transparent;
            modDateLabel.Name = "modDateLabel";
            // 
            // createDateLabel
            // 
            resources.ApplyResources(createDateLabel, "createDateLabel");
            createDateLabel.BackColor = System.Drawing.Color.Transparent;
            createDateLabel.Name = "createDateLabel";
            // 
            // sizeLabel
            // 
            resources.ApplyResources(sizeLabel, "sizeLabel");
            sizeLabel.BackColor = System.Drawing.Color.Transparent;
            sizeLabel.Name = "sizeLabel";
            // 
            // versionLabel
            // 
            resources.ApplyResources(versionLabel, "versionLabel");
            versionLabel.BackColor = System.Drawing.Color.Transparent;
            versionLabel.Name = "versionLabel";
            // 
            // updateUserLabel1
            // 
            resources.ApplyResources(updateUserLabel1, "updateUserLabel1");
            updateUserLabel1.BackColor = System.Drawing.Color.Transparent;
            updateUserLabel1.Name = "updateUserLabel1";
            // 
            // updateDateLabel1
            // 
            resources.ApplyResources(updateDateLabel1, "updateDateLabel1");
            updateDateLabel1.BackColor = System.Drawing.Color.Transparent;
            updateDateLabel1.Name = "updateDateLabel1";
            // 
            // lblPageCount
            // 
            resources.ApplyResources(lblPageCount, "lblPageCount");
            lblPageCount.BackColor = System.Drawing.Color.Transparent;
            lblPageCount.Name = "lblPageCount";
            // 
            // efTypeLabel
            // 
            resources.ApplyResources(efTypeLabel, "efTypeLabel");
            efTypeLabel.BackColor = System.Drawing.Color.Transparent;
            efTypeLabel.Name = "efTypeLabel";
            // 
            // sourceDivisionLabel
            // 
            resources.ApplyResources(sourceDivisionLabel, "sourceDivisionLabel");
            sourceDivisionLabel.BackColor = System.Drawing.Color.Transparent;
            sourceDivisionLabel.Name = "sourceDivisionLabel";
            // 
            // sentToESDCLabel
            // 
            resources.ApplyResources(sentToESDCLabel, "sentToESDCLabel");
            sentToESDCLabel.BackColor = System.Drawing.Color.Transparent;
            sentToESDCLabel.Name = "sentToESDCLabel";
            // 
            // sentDateLabel
            // 
            resources.ApplyResources(sentDateLabel, "sentDateLabel");
            sentDateLabel.BackColor = System.Drawing.Color.Transparent;
            sentDateLabel.Name = "sentDateLabel";
            // 
            // sentByLabel
            // 
            resources.ApplyResources(sentByLabel, "sentByLabel");
            sentByLabel.BackColor = System.Drawing.Color.Transparent;
            sentByLabel.Name = "sentByLabel";
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataMember = "Document";
            this.documentBindingSource.DataSource = docDB;
            this.documentBindingSource.CurrentChanged += new System.EventHandler(this.documentBindingSource_CurrentChanged);
            // 
            // sentIndicatorImageList
            // 
            this.sentIndicatorImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sentIndicatorImageList.ImageStream")));
            this.sentIndicatorImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.sentIndicatorImageList.Images.SetKeyName(0, "SentToShareSuccess.png");
            this.sentIndicatorImageList.Images.SetKeyName(1, "SentToShareFail.png");
            // 
            // uiTab1
            // 
            this.uiTab1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uiTab1, "uiTab1");
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.TabDisplay = Janus.Windows.UI.Tab.TabDisplay.Image;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabDocument,
            this.tabMetadata,
            this.tabVersionning,
            this.tabNoDoc});
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiTab1.TabStripAlignment = Janus.Windows.UI.Tab.TabStripAlignment.Left;
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // tabDocument
            // 
            this.tabDocument.AllowClose = false;
            this.tabDocument.Controls.Add(this.pnlDocView);
            this.tabDocument.Controls.Add(this.pnlHideDocDisplay);
            this.tabDocument.Controls.Add(this.pnlStatusBar);
            this.tabDocument.Controls.Add(this.pnlCommandBar);
            this.tabDocument.Controls.Add(this.pnlAttachment);
            this.tabDocument.Controls.Add(this.pnlAttachTop);
            this.tabDocument.Controls.Add(this.pnlDocTop);
            this.tabDocument.Controls.Add(this.pnlEmailTop);
            this.tabDocument.Controls.Add(this.pnlCheckOut);
            resources.ApplyResources(this.tabDocument, "tabDocument");
            this.tabDocument.Key = "Document";
            this.tabDocument.Name = "tabDocument";
            this.tabDocument.TabStop = true;
            // 
            // pnlHideDocDisplay
            // 
            resources.ApplyResources(this.pnlHideDocDisplay, "pnlHideDocDisplay");
            this.pnlHideDocDisplay.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlHideDocDisplay.InnerContainer = this.pnlHideDocDisplayContainer;
            this.pnlHideDocDisplay.Name = "pnlHideDocDisplay";
            // 
            // pnlHideDocDisplayContainer
            // 
            this.pnlHideDocDisplayContainer.Controls.Add(this.btnLoadLargeDoc);
            this.pnlHideDocDisplayContainer.Controls.Add(this.lblHideContentMessage);
            this.pnlHideDocDisplayContainer.Controls.Add(this.label7);
            this.pnlHideDocDisplayContainer.Controls.Add(this.btnLaunchExcel);
            resources.ApplyResources(this.pnlHideDocDisplayContainer, "pnlHideDocDisplayContainer");
            this.pnlHideDocDisplayContainer.Name = "pnlHideDocDisplayContainer";
            // 
            // btnLoadLargeDoc
            // 
            this.btnLoadLargeDoc.Image = global::LawMate.Properties.Resources.dump2;
            resources.ApplyResources(this.btnLoadLargeDoc, "btnLoadLargeDoc");
            this.btnLoadLargeDoc.Name = "btnLoadLargeDoc";
            this.btnLoadLargeDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnLoadLargeDoc.Click += new System.EventHandler(this.btnLoadLargeDoc_Click);
            // 
            // lblHideContentMessage
            // 
            resources.ApplyResources(this.lblHideContentMessage, "lblHideContentMessage");
            this.lblHideContentMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblHideContentMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblHideContentMessage.Name = "lblHideContentMessage";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Image = global::LawMate.Properties.Resources.Information2;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // btnLaunchExcel
            // 
            this.btnLaunchExcel.Image = global::LawMate.Properties.Resources.Excel_icon;
            resources.ApplyResources(this.btnLaunchExcel, "btnLaunchExcel");
            this.btnLaunchExcel.Name = "btnLaunchExcel";
            this.btnLaunchExcel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnLaunchExcel.Click += new System.EventHandler(this.btnLaunchExcel_Click);
            // 
            // pnlDocView
            // 
            this.pnlDocView.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDocView.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlDocView.CaptionFormatStyle.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDocView.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlDocView.InnerContainer = this.pnlDocViewContainer;
            resources.ApplyResources(this.pnlDocView, "pnlDocView");
            this.pnlDocView.Name = "pnlDocView";
            // 
            // pnlDocViewContainer
            // 
            this.pnlDocViewContainer.Controls.Add(this.btnExternalApp);
            this.pnlDocViewContainer.Controls.Add(this.btnDraftWatermark);
            this.pnlDocViewContainer.Controls.Add(this.ucWB1);
            this.pnlDocViewContainer.Controls.Add(this.textControlCompose);
            this.pnlDocViewContainer.Controls.Add(this.axEDOffice1);
            resources.ApplyResources(this.pnlDocViewContainer, "pnlDocViewContainer");
            this.pnlDocViewContainer.Name = "pnlDocViewContainer";
            // 
            // btnExternalApp
            // 
            resources.ApplyResources(this.btnExternalApp, "btnExternalApp");
            this.btnExternalApp.Appearance = Janus.Windows.UI.Appearance.Empty;
            this.btnExternalApp.Image = global::LawMate.Properties.Resources.exe;
            this.btnExternalApp.Name = "btnExternalApp";
            this.btnExternalApp.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Black;
            this.btnExternalApp.ShowFocusRectangle = false;
            this.btnExternalApp.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            this.btnExternalApp.Click += new System.EventHandler(this.btnExternalApp_Click);
            // 
            // btnDraftWatermark
            // 
            resources.ApplyResources(this.btnDraftWatermark, "btnDraftWatermark");
            this.btnDraftWatermark.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.btnDraftWatermark.Image = global::LawMate.Properties.Resources.DraftDocumentPNG;
            this.btnDraftWatermark.Name = "btnDraftWatermark";
            this.btnDraftWatermark.ShowFocusRectangle = false;
            this.btnDraftWatermark.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.btnDraftWatermark.UseCompatibleTextRendering = false;
            this.btnDraftWatermark.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnDraftWatermark.Click += new System.EventHandler(this.btnDraftWatermark_Click);
            // 
            // textControlCompose
            // 
            resources.ApplyResources(this.textControlCompose, "textControlCompose");
            this.textControlCompose.EditMode = TXTextControl.EditMode.ReadAndSelect;
            this.textControlCompose.Name = "textControlCompose";
            this.textControlCompose.PageMargins.Bottom = 79.03D;
            this.textControlCompose.PageMargins.Left = 79.03D;
            this.textControlCompose.PageMargins.Right = 79.03D;
            this.textControlCompose.PageMargins.Top = 79.03D;
            this.textControlCompose.ViewMode = TXTextControl.ViewMode.Normal;
            this.textControlCompose.ImageCreated += new TXTextControl.ImageEventHandler(this.textControlCompose_ImageCreated);
            this.textControlCompose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textControlCompose_KeyDown);
            // 
            // axEDOffice1
            // 
            resources.ApplyResources(this.axEDOffice1, "axEDOffice1");
            this.axEDOffice1.Name = "axEDOffice1";
            this.axEDOffice1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axEDOffice1.OcxState")));
            this.axEDOffice1.Tag = "a";
            // 
            // ucWB1
            // 
            resources.ApplyResources(this.ucWB1, "ucWB1");
            this.ucWB1.Name = "ucWB1";
            this.ucWB1.TabStop = false;
            this.ucWB1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.ucWB1.DocumentCompleted += new LawMate.UserControls.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // pnlStatusBar
            // 
            this.pnlStatusBar.InnerContainer = this.pnlStatusBarContainer;
            resources.ApplyResources(this.pnlStatusBar, "pnlStatusBar");
            this.pnlStatusBar.Name = "pnlStatusBar";
            // 
            // pnlStatusBarContainer
            // 
            this.pnlStatusBarContainer.Controls.Add(this.uiStatusBar1);
            resources.ApplyResources(this.pnlStatusBarContainer, "pnlStatusBarContainer");
            this.pnlStatusBarContainer.Name = "pnlStatusBarContainer";
            // 
            // uiStatusBar1
            // 
            resources.ApplyResources(this.uiStatusBar1, "uiStatusBar1");
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "pnlPreview";
            resources.ApplyResources(uiStatusBarPanel1, "uiStatusBarPanel1");
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "pnlDraft";
            resources.ApplyResources(uiStatusBarPanel2, "uiStatusBarPanel2");
            uiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "pnlVersion";
            resources.ApplyResources(uiStatusBarPanel3, "uiStatusBarPanel3");
            uiStatusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Key = "pnlFiller";
            resources.ApplyResources(uiStatusBarPanel4, "uiStatusBarPanel4");
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2,
            uiStatusBarPanel3,
            uiStatusBarPanel4});
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiStatusBar1.PanelHover += new Janus.Windows.UI.StatusBar.StatusBarEventHandler(this.uiStatusBar1_PanelHover);
            this.uiStatusBar1.PanelClick += new Janus.Windows.UI.StatusBar.StatusBarEventHandler(this.uiStatusBar1_PanelClick);
            // 
            // pnlCommandBar
            // 
            this.pnlCommandBar.InnerContainer = this.pnlCommandBarContainer;
            resources.ApplyResources(this.pnlCommandBar, "pnlCommandBar");
            this.pnlCommandBar.Name = "pnlCommandBar";
            // 
            // pnlCommandBarContainer
            // 
            this.pnlCommandBarContainer.Controls.Add(this.TopRebar1);
            resources.ApplyResources(this.pnlCommandBarContainer, "pnlCommandBarContainer");
            this.pnlCommandBarContainer.Name = "pnlCommandBarContainer";
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdPrint1,
            this.Separator7,
            this.cmdDocShortcut1,
            this.Separator1,
            this.cmdRevise1,
            this.Separator6,
            this.cmdCheckInCheckOut1,
            this.Separator8,
            this.cmdCopy1,
            this.Separator2,
            this.cmdMakeReadOnly1,
            this.Separator3,
            this.cmdDocViewer1,
            this.Separator9,
            this.cmdExternalApp1,
            this.Separator10,
            this.cmdViewVersionHistory1,
            this.cmdConvertToPDF1});
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandBar1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandBar1_CommandClick);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdPrint,
            this.cmdPrintPreview,
            this.cmdRevise,
            this.cmdCheckInCheckOut,
            this.cmdCopy,
            this.cmdMakeReadOnly,
            this.cmdDocViewer,
            this.cmdExternalApp,
            this.cmdCheckIn,
            this.cmdCheckOut,
            this.cmdUndoCheckOut,
            this.cmdCopyBrowse,
            this.cmdCopyOpen,
            this.cmdCopyNoOpen,
            this.cmdCopyClipboard,
            this.cmdDocShortcut,
            this.cmdViewVersionHistory,
            this.cmdConvertToPDF});
            this.uiCommandManager1.ContainerControl = this.pnlCommandBarContainer;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("800651c6-2a3c-4cf4-b7a1-efffa3f548d1");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
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
            // 
            // cmdPrint
            // 
            this.cmdPrint.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdPrint, "cmdPrint");
            this.cmdPrint.Name = "cmdPrint";
            // 
            // cmdPrintPreview
            // 
            this.cmdPrintPreview.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdPrintPreview, "cmdPrintPreview");
            this.cmdPrintPreview.Name = "cmdPrintPreview";
            // 
            // cmdRevise
            // 
            this.cmdRevise.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdRevise, "cmdRevise");
            this.cmdRevise.Name = "cmdRevise";
            // 
            // cmdCheckInCheckOut
            // 
            this.cmdCheckInCheckOut.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCheckOut1,
            this.cmdUndoCheckOut1,
            this.Separator4,
            this.cmdCheckIn1});
            this.cmdCheckInCheckOut.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdCheckInCheckOut.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdCheckInCheckOut, "cmdCheckInCheckOut");
            this.cmdCheckInCheckOut.Name = "cmdCheckInCheckOut";
            // 
            // cmdCheckOut1
            // 
            resources.ApplyResources(this.cmdCheckOut1, "cmdCheckOut1");
            this.cmdCheckOut1.Name = "cmdCheckOut1";
            // 
            // cmdUndoCheckOut1
            // 
            resources.ApplyResources(this.cmdUndoCheckOut1, "cmdUndoCheckOut1");
            this.cmdUndoCheckOut1.Name = "cmdUndoCheckOut1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdCheckIn1
            // 
            resources.ApplyResources(this.cmdCheckIn1, "cmdCheckIn1");
            this.cmdCheckIn1.Name = "cmdCheckIn1";
            // 
            // cmdCopy
            // 
            this.cmdCopy.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCopyBrowse1,
            this.Separator5,
            this.cmdCopyClipboard1});
            this.cmdCopy.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdCopy.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdCopy, "cmdCopy");
            this.cmdCopy.Name = "cmdCopy";
            // 
            // cmdCopyBrowse1
            // 
            resources.ApplyResources(this.cmdCopyBrowse1, "cmdCopyBrowse1");
            this.cmdCopyBrowse1.Name = "cmdCopyBrowse1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdCopyClipboard1
            // 
            resources.ApplyResources(this.cmdCopyClipboard1, "cmdCopyClipboard1");
            this.cmdCopyClipboard1.Name = "cmdCopyClipboard1";
            // 
            // cmdMakeReadOnly
            // 
            this.cmdMakeReadOnly.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdMakeReadOnly, "cmdMakeReadOnly");
            this.cmdMakeReadOnly.Name = "cmdMakeReadOnly";
            // 
            // cmdDocViewer
            // 
            this.cmdDocViewer.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdDocViewer, "cmdDocViewer");
            this.cmdDocViewer.Name = "cmdDocViewer";
            // 
            // cmdExternalApp
            // 
            this.cmdExternalApp.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdExternalApp, "cmdExternalApp");
            this.cmdExternalApp.Name = "cmdExternalApp";
            // 
            // cmdCheckIn
            // 
            this.cmdCheckIn.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdCheckIn, "cmdCheckIn");
            this.cmdCheckIn.Name = "cmdCheckIn";
            // 
            // cmdCheckOut
            // 
            this.cmdCheckOut.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdCheckOut, "cmdCheckOut");
            this.cmdCheckOut.Name = "cmdCheckOut";
            // 
            // cmdUndoCheckOut
            // 
            this.cmdUndoCheckOut.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdUndoCheckOut, "cmdUndoCheckOut");
            this.cmdUndoCheckOut.Name = "cmdUndoCheckOut";
            // 
            // cmdCopyBrowse
            // 
            this.cmdCopyBrowse.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCopyOpen1,
            this.cmdCopyNoOpen1});
            resources.ApplyResources(this.cmdCopyBrowse, "cmdCopyBrowse");
            this.cmdCopyBrowse.Name = "cmdCopyBrowse";
            // 
            // cmdCopyOpen1
            // 
            resources.ApplyResources(this.cmdCopyOpen1, "cmdCopyOpen1");
            this.cmdCopyOpen1.Name = "cmdCopyOpen1";
            // 
            // cmdCopyNoOpen1
            // 
            resources.ApplyResources(this.cmdCopyNoOpen1, "cmdCopyNoOpen1");
            this.cmdCopyNoOpen1.Name = "cmdCopyNoOpen1";
            // 
            // cmdCopyOpen
            // 
            resources.ApplyResources(this.cmdCopyOpen, "cmdCopyOpen");
            this.cmdCopyOpen.Name = "cmdCopyOpen";
            // 
            // cmdCopyNoOpen
            // 
            resources.ApplyResources(this.cmdCopyNoOpen, "cmdCopyNoOpen");
            this.cmdCopyNoOpen.Name = "cmdCopyNoOpen";
            // 
            // cmdCopyClipboard
            // 
            resources.ApplyResources(this.cmdCopyClipboard, "cmdCopyClipboard");
            this.cmdCopyClipboard.Name = "cmdCopyClipboard";
            // 
            // cmdDocShortcut
            // 
            this.cmdDocShortcut.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdDocShortcut, "cmdDocShortcut");
            this.cmdDocShortcut.Name = "cmdDocShortcut";
            // 
            // cmdViewVersionHistory
            // 
            this.cmdViewVersionHistory.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdViewVersionHistory, "cmdViewVersionHistory");
            this.cmdViewVersionHistory.Name = "cmdViewVersionHistory";
            // 
            // cmdConvertToPDF
            // 
            this.cmdConvertToPDF.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdConvertToPDF, "cmdConvertToPDF");
            this.cmdConvertToPDF.Name = "cmdConvertToPDF";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            // 
            // cmdPrint1
            // 
            resources.ApplyResources(this.cmdPrint1, "cmdPrint1");
            this.cmdPrint1.Name = "cmdPrint1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // cmdDocShortcut1
            // 
            resources.ApplyResources(this.cmdDocShortcut1, "cmdDocShortcut1");
            this.cmdDocShortcut1.Name = "cmdDocShortcut1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdRevise1
            // 
            resources.ApplyResources(this.cmdRevise1, "cmdRevise1");
            this.cmdRevise1.Name = "cmdRevise1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdCheckInCheckOut1
            // 
            resources.ApplyResources(this.cmdCheckInCheckOut1, "cmdCheckInCheckOut1");
            this.cmdCheckInCheckOut1.Name = "cmdCheckInCheckOut1";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator8, "Separator8");
            this.Separator8.Name = "Separator8";
            // 
            // cmdCopy1
            // 
            resources.ApplyResources(this.cmdCopy1, "cmdCopy1");
            this.cmdCopy1.Name = "cmdCopy1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdMakeReadOnly1
            // 
            resources.ApplyResources(this.cmdMakeReadOnly1, "cmdMakeReadOnly1");
            this.cmdMakeReadOnly1.Name = "cmdMakeReadOnly1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdDocViewer1
            // 
            resources.ApplyResources(this.cmdDocViewer1, "cmdDocViewer1");
            this.cmdDocViewer1.Name = "cmdDocViewer1";
            // 
            // Separator9
            // 
            this.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator9, "Separator9");
            this.Separator9.Name = "Separator9";
            // 
            // cmdExternalApp1
            // 
            resources.ApplyResources(this.cmdExternalApp1, "cmdExternalApp1");
            this.cmdExternalApp1.Name = "cmdExternalApp1";
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator10, "Separator10");
            this.Separator10.Name = "Separator10";
            // 
            // cmdViewVersionHistory1
            // 
            resources.ApplyResources(this.cmdViewVersionHistory1, "cmdViewVersionHistory1");
            this.cmdViewVersionHistory1.Name = "cmdViewVersionHistory1";
            // 
            // cmdConvertToPDF1
            // 
            resources.ApplyResources(this.cmdConvertToPDF1, "cmdConvertToPDF1");
            this.cmdConvertToPDF1.Name = "cmdConvertToPDF1";
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlAttachment.InnerContainer = this.pnlAttachmentContainer;
            resources.ApplyResources(this.pnlAttachment, "pnlAttachment");
            this.pnlAttachment.Name = "pnlAttachment";
            // 
            // pnlAttachmentContainer
            // 
            this.pnlAttachmentContainer.Controls.Add(this.flowLayoutPanel1);
            this.pnlAttachmentContainer.Controls.Add(this.btnMessageRead);
            resources.ApplyResources(this.pnlAttachmentContainer, "pnlAttachmentContainer");
            this.pnlAttachmentContainer.Name = "pnlAttachmentContainer";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnMessageRead
            // 
            this.btnMessageRead.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            resources.ApplyResources(this.btnMessageRead, "btnMessageRead");
            this.btnMessageRead.Image = global::LawMate.Properties.Resources.mail5;
            this.btnMessageRead.Name = "btnMessageRead";
            this.btnMessageRead.ShowFocusRectangle = false;
            this.btnMessageRead.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnMessageRead.Click += new System.EventHandler(this.btnMessageRead_Click);
            // 
            // pnlAttachTop
            // 
            this.pnlAttachTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlAttachTop.InnerContainer = this.pnlAttachTopContainer;
            resources.ApplyResources(this.pnlAttachTop, "pnlAttachTop");
            this.pnlAttachTop.Name = "pnlAttachTop";
            // 
            // pnlAttachTopContainer
            // 
            this.pnlAttachTopContainer.Controls.Add(this.calAttachLastChanged);
            this.pnlAttachTopContainer.Controls.Add(this.ebAttachAuthor);
            this.pnlAttachTopContainer.Controls.Add(this.ebAttachSize);
            this.pnlAttachTopContainer.Controls.Add(this.ebAttachFileName);
            this.pnlAttachTopContainer.Controls.Add(this.label1);
            this.pnlAttachTopContainer.Controls.Add(this.label8);
            this.pnlAttachTopContainer.Controls.Add(this.label2);
            this.pnlAttachTopContainer.Controls.Add(this.label6);
            resources.ApplyResources(this.pnlAttachTopContainer, "pnlAttachTopContainer");
            this.pnlAttachTopContainer.Name = "pnlAttachTopContainer";
            // 
            // calAttachLastChanged
            // 
            this.calAttachLastChanged.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.None;
            resources.ApplyResources(this.calAttachLastChanged, "calAttachLastChanged");
            this.calAttachLastChanged.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.calAttachLastChanged.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // 
            // 
            this.calAttachLastChanged.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calAttachLastChanged.Name = "calAttachLastChanged";
            this.calAttachLastChanged.ReadOnly = true;
            this.calAttachLastChanged.ShowDropDown = false;
            this.calAttachLastChanged.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // ebAttachAuthor
            // 
            resources.ApplyResources(this.ebAttachAuthor, "ebAttachAuthor");
            this.ebAttachAuthor.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ebAttachAuthor.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.ebAttachAuthor.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.ebAttachAuthor.Multiline = true;
            this.ebAttachAuthor.Name = "ebAttachAuthor";
            this.ebAttachAuthor.ReadOnly = true;
            this.ebAttachAuthor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebAttachSize
            // 
            resources.ApplyResources(this.ebAttachSize, "ebAttachSize");
            this.ebAttachSize.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ebAttachSize.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.ebAttachSize.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.ebAttachSize.Multiline = true;
            this.ebAttachSize.Name = "ebAttachSize";
            this.ebAttachSize.ReadOnly = true;
            this.ebAttachSize.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ebAttachFileName
            // 
            resources.ApplyResources(this.ebAttachFileName, "ebAttachFileName");
            this.ebAttachFileName.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ebAttachFileName.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.ebAttachFileName.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.ebAttachFileName.Multiline = true;
            this.ebAttachFileName.Name = "ebAttachFileName";
            this.ebAttachFileName.ReadOnly = true;
            this.ebAttachFileName.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Name = "label8";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // pnlDocTop
            // 
            this.pnlDocTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlDocTop.InnerContainer = this.pnlDocTopContainer;
            resources.ApplyResources(this.pnlDocTop, "pnlDocTop");
            this.pnlDocTop.Name = "pnlDocTop";
            // 
            // pnlDocTopContainer
            // 
            this.pnlDocTopContainer.Controls.Add(this.calEfDateDoc);
            this.pnlDocTopContainer.Controls.Add(this.label4);
            this.pnlDocTopContainer.Controls.Add(this.tbSubjectDoc);
            this.pnlDocTopContainer.Controls.Add(this.label3);
            resources.ApplyResources(this.pnlDocTopContainer, "pnlDocTopContainer");
            this.pnlDocTopContainer.Name = "pnlDocTopContainer";
            // 
            // calEfDateDoc
            // 
            resources.ApplyResources(this.calEfDateDoc, "calEfDateDoc");
            this.calEfDateDoc.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.None;
            this.calEfDateDoc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.documentBindingSource, "efDate", true));
            this.calEfDateDoc.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.calEfDateDoc.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // 
            // 
            this.calEfDateDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calEfDateDoc.Name = "calEfDateDoc";
            this.calEfDateDoc.ReadOnly = true;
            this.calEfDateDoc.ShowDropDown = false;
            this.calEfDateDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // tbSubjectDoc
            // 
            resources.ApplyResources(this.tbSubjectDoc, "tbSubjectDoc");
            this.tbSubjectDoc.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.tbSubjectDoc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "efSubject", true));
            this.tbSubjectDoc.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.tbSubjectDoc.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.tbSubjectDoc.Multiline = true;
            this.tbSubjectDoc.Name = "tbSubjectDoc";
            this.tbSubjectDoc.ReadOnly = true;
            this.tbSubjectDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // pnlEmailTop
            // 
            this.pnlEmailTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlEmailTop.InnerContainer = this.pnlFromContainer;
            resources.ApplyResources(this.pnlEmailTop, "pnlEmailTop");
            this.pnlEmailTop.Name = "pnlEmailTop";
            // 
            // pnlFromContainer
            // 
            this.pnlFromContainer.Controls.Add(this.tbSubjectMail);
            this.pnlFromContainer.Controls.Add(this.calEfDateMail);
            this.pnlFromContainer.Controls.Add(this.tbTo);
            this.pnlFromContainer.Controls.Add(this.lblSubject);
            this.pnlFromContainer.Controls.Add(this.lblCC);
            this.pnlFromContainer.Controls.Add(this.lblTo);
            this.pnlFromContainer.Controls.Add(this.lblDate);
            this.pnlFromContainer.Controls.Add(this.lblFrom);
            this.pnlFromContainer.Controls.Add(this.tbFrom);
            this.pnlFromContainer.Controls.Add(this.tbCC);
            resources.ApplyResources(this.pnlFromContainer, "pnlFromContainer");
            this.pnlFromContainer.Name = "pnlFromContainer";
            // 
            // tbSubjectMail
            // 
            resources.ApplyResources(this.tbSubjectMail, "tbSubjectMail");
            this.tbSubjectMail.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.tbSubjectMail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "efSubject", true));
            this.tbSubjectMail.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.tbSubjectMail.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.tbSubjectMail.Multiline = true;
            this.tbSubjectMail.Name = "tbSubjectMail";
            this.tbSubjectMail.ReadOnly = true;
            this.tbSubjectMail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // calEfDateMail
            // 
            resources.ApplyResources(this.calEfDateMail, "calEfDateMail");
            this.calEfDateMail.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.None;
            this.calEfDateMail.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.documentBindingSource, "efDate", true));
            this.calEfDateMail.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.calEfDateMail.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // 
            // 
            this.calEfDateMail.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calEfDateMail.Name = "calEfDateMail";
            this.calEfDateMail.ReadOnly = true;
            this.calEfDateMail.ShowDropDown = false;
            this.calEfDateMail.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // tbTo
            // 
            resources.ApplyResources(this.tbTo, "tbTo");
            this.tbTo.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.tbTo.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.tbTo.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.tbTo.Multiline = true;
            this.tbTo.Name = "tbTo";
            this.tbTo.ReadOnly = true;
            this.tbTo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lblSubject
            // 
            resources.ApplyResources(this.lblSubject, "lblSubject");
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Name = "lblSubject";
            // 
            // lblCC
            // 
            resources.ApplyResources(this.lblCC, "lblCC");
            this.lblCC.BackColor = System.Drawing.Color.Transparent;
            this.lblCC.Name = "lblCC";
            // 
            // lblTo
            // 
            resources.ApplyResources(this.lblTo, "lblTo");
            this.lblTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTo.Name = "lblTo";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Name = "lblDate";
            // 
            // lblFrom
            // 
            resources.ApplyResources(this.lblFrom, "lblFrom");
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Name = "lblFrom";
            // 
            // tbFrom
            // 
            resources.ApplyResources(this.tbFrom, "tbFrom");
            this.tbFrom.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.tbFrom.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.tbFrom.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.tbFrom.Multiline = true;
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.ReadOnly = true;
            this.tbFrom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // tbCC
            // 
            resources.ApplyResources(this.tbCC, "tbCC");
            this.tbCC.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.tbCC.DisabledBackColor = System.Drawing.SystemColors.Window;
            this.tbCC.DisabledForeColor = System.Drawing.SystemColors.ControlText;
            this.tbCC.Multiline = true;
            this.tbCC.Name = "tbCC";
            this.tbCC.ReadOnly = true;
            this.tbCC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // pnlCheckOut
            // 
            this.pnlCheckOut.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlCheckOut.BorderCaption = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlCheckOut.BorderCaptionColor = System.Drawing.Color.RosyBrown;
            this.pnlCheckOut.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlCheckOut.BorderPanelColor = System.Drawing.Color.RosyBrown;
            this.pnlCheckOut.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlCheckOut.CaptionFormatStyle.ForeColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.pnlCheckOut, "pnlCheckOut");
            this.pnlCheckOut.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlCheckOut.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlCheckOut.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlCheckOut.InnerContainer = this.pnlCheckOutContainer;
            this.pnlCheckOut.Name = "pnlCheckOut";
            // 
            // pnlCheckOutContainer
            // 
            resources.ApplyResources(this.pnlCheckOutContainer, "pnlCheckOutContainer");
            this.pnlCheckOutContainer.Controls.Add(this.lnkEditCheckedOutDocument);
            this.pnlCheckOutContainer.Controls.Add(this.editBox8);
            this.pnlCheckOutContainer.Controls.Add(checkedOutPathLabel);
            this.pnlCheckOutContainer.Controls.Add(this.ucMultiDropDown1);
            this.pnlCheckOutContainer.Controls.Add(checkedOutByLabel);
            this.pnlCheckOutContainer.Controls.Add(this.calendarCombo1);
            this.pnlCheckOutContainer.Controls.Add(checkedOutDateLabel);
            this.pnlCheckOutContainer.Name = "pnlCheckOutContainer";
            // 
            // lnkEditCheckedOutDocument
            // 
            resources.ApplyResources(this.lnkEditCheckedOutDocument, "lnkEditCheckedOutDocument");
            this.lnkEditCheckedOutDocument.Image = global::LawMate.Properties.Resources.edit1;
            this.lnkEditCheckedOutDocument.Name = "lnkEditCheckedOutDocument";
            this.lnkEditCheckedOutDocument.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.lnkEditCheckedOutDocument.Click += new System.EventHandler(this.lnkEditCheckedOutDocument_Click);
            // 
            // editBox8
            // 
            this.editBox8.BackColor = System.Drawing.SystemColors.Control;
            this.editBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "CheckedOutPath", true));
            this.editBox8.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.editBox8.DisabledForeColor = System.Drawing.Color.Black;
            this.editBox8.FlatBorderColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.editBox8, "editBox8");
            this.editBox8.MaxLength = 255;
            this.editBox8.Name = "editBox8";
            this.editBox8.ReadOnly = true;
            this.editBox8.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown1.Column1 = "fullname";
            resources.ApplyResources(this.ucMultiDropDown1, "ucMultiDropDown1");
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentBindingSource, "CheckedOutBy", true));
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = true;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown1.SelectedValue = null;
            this.ucMultiDropDown1.ValueMember = "OfficerId";
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "CheckedOutDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.calendarCombo1.DropDownCalendar.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Nullable = true;
            this.calendarCombo1.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.calendarCombo1.ReadOnly = true;
            this.calendarCombo1.Value = new System.DateTime(2011, 4, 13, 0, 0, 0, 0);
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // tabMetadata
            // 
            this.tabMetadata.AllowClose = false;
            resources.ApplyResources(this.tabMetadata, "tabMetadata");
            this.tabMetadata.Controls.Add(this.uiGroupBox1);
            this.tabMetadata.Controls.Add(this.gbRecipients);
            this.tabMetadata.Key = "Metadata";
            this.tabMetadata.Name = "tabMetadata";
            this.tabMetadata.TabStop = true;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(this.sentToESDCEditBox);
            this.uiGroupBox1.Controls.Add(this.sentUserEditBox);
            this.uiGroupBox1.Controls.Add(this.sentDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(sentByLabel);
            this.uiGroupBox1.Controls.Add(sentDateLabel);
            this.uiGroupBox1.Controls.Add(sentToESDCLabel);
            this.uiGroupBox1.Controls.Add(this.ddSourceDivision);
            this.uiGroupBox1.Controls.Add(sourceDivisionLabel);
            this.uiGroupBox1.Controls.Add(this.editPageCount);
            this.uiGroupBox1.Controls.Add(efTypeLabel);
            this.uiGroupBox1.Controls.Add(lblPageCount);
            this.uiGroupBox1.Controls.Add(this.efSubjectEditBox);
            this.uiGroupBox1.Controls.Add(this.docIdEditBox);
            this.uiGroupBox1.Controls.Add(updateDateLabel1);
            this.uiGroupBox1.Controls.Add(this.updateDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(docIdLabel);
            this.uiGroupBox1.Controls.Add(this.updateDateCalendarCombo1);
            this.uiGroupBox1.Controls.Add(this.efDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(versionLabel);
            this.uiGroupBox1.Controls.Add(updateUserLabel1);
            this.uiGroupBox1.Controls.Add(this.versionEditBox);
            this.uiGroupBox1.Controls.Add(efDateLabel);
            this.uiGroupBox1.Controls.Add(this.updateUserEditBox1);
            this.uiGroupBox1.Controls.Add(this.sizeEditBox);
            this.uiGroupBox1.Controls.Add(efSubjectLabel);
            this.uiGroupBox1.Controls.Add(extLabel);
            this.uiGroupBox1.Controls.Add(this.readOnlyUICheckBox);
            this.uiGroupBox1.Controls.Add(this.extEditBox);
            this.uiGroupBox1.Controls.Add(this.sentTimeCalendarCombo);
            this.uiGroupBox1.Controls.Add(sentTimeLabel);
            this.uiGroupBox1.Controls.Add(this.receivedTimeCalendarCombo);
            this.uiGroupBox1.Controls.Add(updateUserLabel);
            this.uiGroupBox1.Controls.Add(createDateLabel);
            this.uiGroupBox1.Controls.Add(this.updateUserEditBox);
            this.uiGroupBox1.Controls.Add(receivedTimeLabel);
            this.uiGroupBox1.Controls.Add(entryDateLabel);
            this.uiGroupBox1.Controls.Add(this.createDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(this.entryDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(this.isDraftUICheckBox);
            this.uiGroupBox1.Controls.Add(entryUserLabel);
            this.uiGroupBox1.Controls.Add(modDateLabel);
            this.uiGroupBox1.Controls.Add(this.entryUserEditBox);
            this.uiGroupBox1.Controls.Add(this.efTypeucMultiDropDown);
            this.uiGroupBox1.Controls.Add(conversationIndexLabel);
            this.uiGroupBox1.Controls.Add(this.modDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(this.conversationIndexEditBox);
            this.uiGroupBox1.Controls.Add(filedByLabel);
            this.uiGroupBox1.Controls.Add(this.commModeucMultiDropDown);
            this.uiGroupBox1.Controls.Add(this.filedByEditBox);
            this.uiGroupBox1.Controls.Add(sourceLabel);
            this.uiGroupBox1.Controls.Add(commModeLabel);
            this.uiGroupBox1.Controls.Add(this.sourceEditBox);
            this.uiGroupBox1.Controls.Add(this.authorEditBox);
            this.uiGroupBox1.Controls.Add(authorLabel);
            this.uiGroupBox1.Controls.Add(sizeLabel);
            this.uiGroupBox1.Controls.Add(updateDateLabel);
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.UseThemes = false;
            // 
            // sentToESDCEditBox
            // 
            this.sentToESDCEditBox.BackColor = System.Drawing.Color.White;
            this.sentToESDCEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.documentBindingSource, "SentToShareFolder", true));
            resources.ApplyResources(this.sentToESDCEditBox, "sentToESDCEditBox");
            this.sentToESDCEditBox.ImageList = this.sentIndicatorImageList;
            this.sentToESDCEditBox.Name = "sentToESDCEditBox";
            this.sentToESDCEditBox.ReadOnly = true;
            this.sentToESDCEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sentUserEditBox
            // 
            this.sentUserEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sentUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "DocDumpUser", true));
            resources.ApplyResources(this.sentUserEditBox, "sentUserEditBox");
            this.sentUserEditBox.Name = "sentUserEditBox";
            this.sentUserEditBox.ReadOnly = true;
            this.sentUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sentDateCalendarCombo
            // 
            this.sentDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.sentDateCalendarCombo, "sentDateCalendarCombo");
            this.sentDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "DocDumpDate", true));
            // 
            // 
            // 
            this.sentDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.sentDateCalendarCombo.Name = "sentDateCalendarCombo";
            this.sentDateCalendarCombo.ReadOnly = true;
            this.sentDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // ddSourceDivision
            // 
            this.ddSourceDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ddSourceDivision.Column1 = "AppealLevelId";
            resources.ApplyResources(this.ddSourceDivision, "ddSourceDivision");
            this.ddSourceDivision.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ddSourceDivision.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentBindingSource, "SourceDivision", true));
            this.ddSourceDivision.DataSource = null;
            this.ddSourceDivision.DDColumn1Visible = false;
            this.ddSourceDivision.DropDownColumn1Width = 100;
            this.ddSourceDivision.DropDownColumn2Width = 300;
            this.ddSourceDivision.Name = "ddSourceDivision";
            this.ddSourceDivision.ReadOnly = false;
            this.ddSourceDivision.ReqColor = System.Drawing.SystemColors.Window;
            this.ddSourceDivision.SelectedValue = null;
            this.ddSourceDivision.ValueMember = "AppealLevelId";
            // 
            // editPageCount
            // 
            this.editPageCount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "PageCount", true));
            resources.ApplyResources(this.editPageCount, "editPageCount");
            this.editPageCount.Name = "editPageCount";
            this.editPageCount.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
            this.editPageCount.Value = 0;
            this.editPageCount.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this.editPageCount.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // efSubjectEditBox
            // 
            this.efSubjectEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "efSubject", true));
            resources.ApplyResources(this.efSubjectEditBox, "efSubjectEditBox");
            this.efSubjectEditBox.Name = "efSubjectEditBox";
            this.efSubjectEditBox.ReadOnly = true;
            this.efSubjectEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // docIdEditBox
            // 
            this.docIdEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.docIdEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "DocId", true));
            resources.ApplyResources(this.docIdEditBox, "docIdEditBox");
            this.docIdEditBox.Name = "docIdEditBox";
            this.docIdEditBox.ReadOnly = true;
            this.docIdEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // updateDateCalendarCombo
            // 
            this.updateDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.updateDateCalendarCombo, "updateDateCalendarCombo");
            this.updateDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "updateDate", true));
            // 
            // 
            // 
            this.updateDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.updateDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.updateDateCalendarCombo.Name = "updateDateCalendarCombo";
            this.updateDateCalendarCombo.ReadOnly = true;
            this.updateDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // updateDateCalendarCombo1
            // 
            this.updateDateCalendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.updateDateCalendarCombo1, "updateDateCalendarCombo1");
            this.updateDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.docContentBindingSource, "updateDate", true));
            // 
            // 
            // 
            this.updateDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.updateDateCalendarCombo1.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.updateDateCalendarCombo1.Name = "updateDateCalendarCombo1";
            this.updateDateCalendarCombo1.ReadOnly = true;
            this.updateDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // docContentBindingSource
            // 
            this.docContentBindingSource.DataSource = this.documentDocContentBindingSource;
            // 
            // documentDocContentBindingSource
            // 
            this.documentDocContentBindingSource.DataMember = "DocContent";
            this.documentDocContentBindingSource.DataSource = docDB;
            // 
            // efDateCalendarCombo
            // 
            resources.ApplyResources(this.efDateCalendarCombo, "efDateCalendarCombo");
            this.efDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "efDate", true));
            this.efDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.efDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.efDateCalendarCombo.MonthIncrement = 0;
            this.efDateCalendarCombo.Name = "efDateCalendarCombo";
            this.efDateCalendarCombo.ReadOnly = true;
            this.efDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.efDateCalendarCombo.YearIncrement = 0;
            // 
            // versionEditBox
            // 
            this.versionEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.versionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.docContentBindingSource, "Version", true));
            resources.ApplyResources(this.versionEditBox, "versionEditBox");
            this.versionEditBox.Name = "versionEditBox";
            this.versionEditBox.ReadOnly = true;
            this.versionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // updateUserEditBox1
            // 
            this.updateUserEditBox1.BackColor = System.Drawing.SystemColors.Control;
            this.updateUserEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.docContentBindingSource, "updateUser", true));
            resources.ApplyResources(this.updateUserEditBox1, "updateUserEditBox1");
            this.updateUserEditBox1.Name = "updateUserEditBox1";
            this.updateUserEditBox1.ReadOnly = true;
            this.updateUserEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sizeEditBox
            // 
            this.sizeEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sizeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.docContentBindingSource, "Size", true));
            resources.ApplyResources(this.sizeEditBox, "sizeEditBox");
            this.sizeEditBox.Name = "sizeEditBox";
            this.sizeEditBox.ReadOnly = true;
            this.sizeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // readOnlyUICheckBox
            // 
            this.readOnlyUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.readOnlyUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.readOnlyUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.docContentBindingSource, "ReadOnly", true));
            resources.ApplyResources(this.readOnlyUICheckBox, "readOnlyUICheckBox");
            this.readOnlyUICheckBox.Name = "readOnlyUICheckBox";
            this.readOnlyUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // extEditBox
            // 
            this.extEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.extEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.docContentBindingSource, "Ext", true));
            resources.ApplyResources(this.extEditBox, "extEditBox");
            this.extEditBox.Name = "extEditBox";
            this.extEditBox.ReadOnly = true;
            this.extEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sentTimeCalendarCombo
            // 
            this.sentTimeCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.sentTimeCalendarCombo, "sentTimeCalendarCombo");
            this.sentTimeCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "SentLocal", true));
            // 
            // 
            // 
            this.sentTimeCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sentTimeCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.sentTimeCalendarCombo.Name = "sentTimeCalendarCombo";
            this.sentTimeCalendarCombo.ReadOnly = true;
            this.sentTimeCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // receivedTimeCalendarCombo
            // 
            this.receivedTimeCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.receivedTimeCalendarCombo, "receivedTimeCalendarCombo");
            this.receivedTimeCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "ReceivedLocal", true));
            // 
            // 
            // 
            this.receivedTimeCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedTimeCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.receivedTimeCalendarCombo.Name = "receivedTimeCalendarCombo";
            this.receivedTimeCalendarCombo.ReadOnly = true;
            this.receivedTimeCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // updateUserEditBox
            // 
            this.updateUserEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.updateUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "updateUser", true));
            resources.ApplyResources(this.updateUserEditBox, "updateUserEditBox");
            this.updateUserEditBox.Name = "updateUserEditBox";
            this.updateUserEditBox.ReadOnly = true;
            this.updateUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // createDateCalendarCombo
            // 
            this.createDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.createDateCalendarCombo, "createDateCalendarCombo");
            this.createDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.docContentBindingSource, "CreateDate", true));
            // 
            // 
            // 
            this.createDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.createDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.createDateCalendarCombo.Name = "createDateCalendarCombo";
            this.createDateCalendarCombo.ReadOnly = true;
            this.createDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // entryDateCalendarCombo
            // 
            this.entryDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.entryDateCalendarCombo, "entryDateCalendarCombo");
            this.entryDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "entryDate", true));
            // 
            // 
            // 
            this.entryDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.entryDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.entryDateCalendarCombo.Name = "entryDateCalendarCombo";
            this.entryDateCalendarCombo.ReadOnly = true;
            this.entryDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // isDraftUICheckBox
            // 
            this.isDraftUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.isDraftUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isDraftUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "IsDraft", true));
            resources.ApplyResources(this.isDraftUICheckBox, "isDraftUICheckBox");
            this.isDraftUICheckBox.Name = "isDraftUICheckBox";
            this.isDraftUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // entryUserEditBox
            // 
            this.entryUserEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.entryUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "entryUser", true));
            resources.ApplyResources(this.entryUserEditBox, "entryUserEditBox");
            this.entryUserEditBox.Name = "entryUserEditBox";
            this.entryUserEditBox.ReadOnly = true;
            this.entryUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // efTypeucMultiDropDown
            // 
            this.efTypeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.efTypeucMultiDropDown.Column1 = "DocTypeCode";
            resources.ApplyResources(this.efTypeucMultiDropDown, "efTypeucMultiDropDown");
            this.efTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.efTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentBindingSource, "efType", true));
            this.efTypeucMultiDropDown.DataSource = null;
            this.efTypeucMultiDropDown.DDColumn1Visible = true;
            this.efTypeucMultiDropDown.DropDownColumn1Width = 50;
            this.efTypeucMultiDropDown.DropDownColumn2Width = 250;
            this.efTypeucMultiDropDown.Name = "efTypeucMultiDropDown";
            this.efTypeucMultiDropDown.ReadOnly = false;
            this.efTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.efTypeucMultiDropDown.SelectedValue = null;
            this.efTypeucMultiDropDown.ValueMember = "DocTypeCode";
            // 
            // modDateCalendarCombo
            // 
            this.modDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.modDateCalendarCombo, "modDateCalendarCombo");
            this.modDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.docContentBindingSource, "ModDate", true));
            // 
            // 
            // 
            this.modDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.modDateCalendarCombo.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.modDateCalendarCombo.Name = "modDateCalendarCombo";
            this.modDateCalendarCombo.ReadOnly = true;
            this.modDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // conversationIndexEditBox
            // 
            this.conversationIndexEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.conversationIndexEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "ConversationIndex", true));
            resources.ApplyResources(this.conversationIndexEditBox, "conversationIndexEditBox");
            this.conversationIndexEditBox.Name = "conversationIndexEditBox";
            this.conversationIndexEditBox.ReadOnly = true;
            this.conversationIndexEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // commModeucMultiDropDown
            // 
            this.commModeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.commModeucMultiDropDown.Column1 = "DocStyleCode";
            resources.ApplyResources(this.commModeucMultiDropDown, "commModeucMultiDropDown");
            this.commModeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.commModeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentBindingSource, "CommMode", true));
            this.commModeucMultiDropDown.DataSource = null;
            this.commModeucMultiDropDown.DDColumn1Visible = true;
            this.commModeucMultiDropDown.DropDownColumn1Width = 50;
            this.commModeucMultiDropDown.DropDownColumn2Width = 250;
            this.commModeucMultiDropDown.Name = "commModeucMultiDropDown";
            this.commModeucMultiDropDown.ReadOnly = false;
            this.commModeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.commModeucMultiDropDown.SelectedValue = null;
            this.commModeucMultiDropDown.ValueMember = "DocStyleCode";
            // 
            // filedByEditBox
            // 
            this.filedByEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.filedByEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "FiledBy", true));
            resources.ApplyResources(this.filedByEditBox, "filedByEditBox");
            this.filedByEditBox.Name = "filedByEditBox";
            this.filedByEditBox.ReadOnly = true;
            this.filedByEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sourceEditBox
            // 
            this.sourceEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sourceEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Source", true));
            resources.ApplyResources(this.sourceEditBox, "sourceEditBox");
            this.sourceEditBox.Name = "sourceEditBox";
            this.sourceEditBox.ReadOnly = true;
            this.sourceEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // authorEditBox
            // 
            this.authorEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.authorEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Author", true));
            resources.ApplyResources(this.authorEditBox, "authorEditBox");
            this.authorEditBox.Name = "authorEditBox";
            this.authorEditBox.ReadOnly = true;
            this.authorEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // gbRecipients
            // 
            this.gbRecipients.BackColor = System.Drawing.Color.Transparent;
            this.gbRecipients.Controls.Add(this.ucRecipientTextBoxFrom);
            this.gbRecipients.Controls.Add(this.buttonCC);
            this.gbRecipients.Controls.Add(this.isLawmailUICheckBox);
            this.gbRecipients.Controls.Add(this.buttonTo);
            this.gbRecipients.Controls.Add(this.ucRecipientTextBoxTo);
            this.gbRecipients.Controls.Add(this.buttonFrom);
            this.gbRecipients.Controls.Add(this.ucRecipientTextBoxCc);
            resources.ApplyResources(this.gbRecipients, "gbRecipients");
            this.gbRecipients.Name = "gbRecipients";
            this.gbRecipients.UseThemes = false;
            // 
            // ucRecipientTextBoxFrom
            // 
            this.ucRecipientTextBoxFrom.AllowMultiple = false;
            resources.ApplyResources(this.ucRecipientTextBoxFrom, "ucRecipientTextBoxFrom");
            this.ucRecipientTextBoxFrom.BackColor = System.Drawing.Color.Transparent;
            this.ucRecipientTextBoxFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucRecipientTextBoxFrom.IsReadOnly = false;
            this.ucRecipientTextBoxFrom.Name = "ucRecipientTextBoxFrom";
            this.ucRecipientTextBoxFrom.RecipType = "0";
            this.ucRecipientTextBoxFrom.UsesNewDocViewer = true;
            // 
            // buttonCC
            // 
            resources.ApplyResources(this.buttonCC, "buttonCC");
            this.buttonCC.Name = "buttonCC";
            this.buttonCC.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonCC.Click += new System.EventHandler(this.buttonFrom_Click);
            // 
            // isLawmailUICheckBox
            // 
            this.isLawmailUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.isLawmailUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isLawmailUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "isLawmail", true));
            resources.ApplyResources(this.isLawmailUICheckBox, "isLawmailUICheckBox");
            this.isLawmailUICheckBox.Image = global::LawMate.Properties.Resources.mail5;
            this.isLawmailUICheckBox.ImageVerticalAlignment = Janus.Windows.EditControls.ImageAlignment.Bottom;
            this.isLawmailUICheckBox.Name = "isLawmailUICheckBox";
            this.isLawmailUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // buttonTo
            // 
            resources.ApplyResources(this.buttonTo, "buttonTo");
            this.buttonTo.Name = "buttonTo";
            this.buttonTo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonTo.Click += new System.EventHandler(this.buttonFrom_Click);
            // 
            // ucRecipientTextBoxTo
            // 
            this.ucRecipientTextBoxTo.AllowMultiple = true;
            resources.ApplyResources(this.ucRecipientTextBoxTo, "ucRecipientTextBoxTo");
            this.ucRecipientTextBoxTo.BackColor = System.Drawing.Color.Transparent;
            this.ucRecipientTextBoxTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucRecipientTextBoxTo.IsReadOnly = false;
            this.ucRecipientTextBoxTo.Name = "ucRecipientTextBoxTo";
            this.ucRecipientTextBoxTo.RecipType = "1";
            this.ucRecipientTextBoxTo.UsesNewDocViewer = true;
            // 
            // buttonFrom
            // 
            resources.ApplyResources(this.buttonFrom, "buttonFrom");
            this.buttonFrom.Name = "buttonFrom";
            this.buttonFrom.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonFrom.Click += new System.EventHandler(this.buttonFrom_Click);
            // 
            // ucRecipientTextBoxCc
            // 
            this.ucRecipientTextBoxCc.AllowMultiple = true;
            resources.ApplyResources(this.ucRecipientTextBoxCc, "ucRecipientTextBoxCc");
            this.ucRecipientTextBoxCc.BackColor = System.Drawing.Color.Transparent;
            this.ucRecipientTextBoxCc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucRecipientTextBoxCc.IsReadOnly = false;
            this.ucRecipientTextBoxCc.Name = "ucRecipientTextBoxCc";
            this.ucRecipientTextBoxCc.RecipType = "2";
            this.ucRecipientTextBoxCc.UsesNewDocViewer = true;
            // 
            // tabVersionning
            // 
            this.tabVersionning.AllowClose = false;
            resources.ApplyResources(this.tabVersionning, "tabVersionning");
            this.tabVersionning.Key = "Version";
            this.tabVersionning.Name = "tabVersionning";
            this.tabVersionning.TabStop = true;
            // 
            // tabNoDoc
            // 
            this.tabNoDoc.Controls.Add(this.lblNoDocumentText);
            this.tabNoDoc.Controls.Add(this.label5);
            this.tabNoDoc.Controls.Add(this.lblNoDoc);
            this.tabNoDoc.Key = "NoDocument";
            resources.ApplyResources(this.tabNoDoc, "tabNoDoc");
            this.tabNoDoc.Name = "tabNoDoc";
            this.tabNoDoc.TabStop = true;
            // 
            // lblNoDocumentText
            // 
            resources.ApplyResources(this.lblNoDocumentText, "lblNoDocumentText");
            this.lblNoDocumentText.BackColor = System.Drawing.Color.Transparent;
            this.lblNoDocumentText.Name = "lblNoDocumentText";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Image = global::LawMate.Properties.Resources.Information2;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblNoDoc
            // 
            resources.ApplyResources(this.lblNoDoc, "lblNoDoc");
            this.lblNoDoc.BackColor = System.Drawing.Color.Transparent;
            this.lblNoDoc.ForeColor = System.Drawing.Color.Blue;
            this.lblNoDoc.Name = "lblNoDoc";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this.tabDocument;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlCheckOut.Id = new System.Guid("5b649b4b-8e3e-46e7-9438-14e5c2861920");
            this.uiPanelManager1.Panels.Add(this.pnlCheckOut);
            this.pnlEmailTop.Id = new System.Guid("d549f204-7778-462b-a92c-7f60e933211b");
            this.uiPanelManager1.Panels.Add(this.pnlEmailTop);
            this.pnlDocTop.Id = new System.Guid("aeb4761d-4ce2-497b-a720-32aa1727831e");
            this.uiPanelManager1.Panels.Add(this.pnlDocTop);
            this.pnlAttachTop.Id = new System.Guid("72e357b4-dd7a-48b9-9ebb-d89749a57201");
            this.uiPanelManager1.Panels.Add(this.pnlAttachTop);
            this.pnlAttachment.Id = new System.Guid("416b916e-721a-46d6-bacb-921c7b70a775");
            this.uiPanelManager1.Panels.Add(this.pnlAttachment);
            this.pnlCommandBar.Id = new System.Guid("7e54ad98-afc0-4d8f-8367-a010b3718d2f");
            this.uiPanelManager1.Panels.Add(this.pnlCommandBar);
            this.pnlStatusBar.Id = new System.Guid("6397c794-ca37-498e-b5c3-32c772818b91");
            this.uiPanelManager1.Panels.Add(this.pnlStatusBar);
            this.pnlHideDocDisplay.Id = new System.Guid("21f5756e-9b45-45e9-83be-e9fd97ce5e54");
            this.uiPanelManager1.Panels.Add(this.pnlHideDocDisplay);
            this.pnlDocView.Id = new System.Guid("0568c280-d687-4101-a49d-8821bbd71ee1");
            this.uiPanelManager1.Panels.Add(this.pnlDocView);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5b649b4b-8e3e-46e7-9438-14e5c2861920"), Janus.Windows.UI.Dock.PanelDockStyle.Right, new System.Drawing.Size(263, 563), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("d549f204-7778-462b-a92c-7f60e933211b"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(785, 85), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("aeb4761d-4ce2-497b-a720-32aa1727831e"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(785, 25), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("72e357b4-dd7a-48b9-9ebb-d89749a57201"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(785, 77), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("416b916e-721a-46d6-bacb-921c7b70a775"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(785, 29), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7e54ad98-afc0-4d8f-8367-a010b3718d2f"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(785, 27), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("21f5756e-9b45-45e9-83be-e9fd97ce5e54"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(785, 273), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("6397c794-ca37-498e-b5c3-32c772818b91"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(785, 22), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("0568c280-d687-4101-a49d-8821bbd71ee1"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(785, 291), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("d549f204-7778-462b-a92c-7f60e933211b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("416b916e-721a-46d6-bacb-921c7b70a775"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("aeb4761d-4ce2-497b-a720-32aa1727831e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0568c280-d687-4101-a49d-8821bbd71ee1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5b649b4b-8e3e-46e7-9438-14e5c2861920"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("21f5756e-9b45-45e9-83be-e9fd97ce5e54"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7e54ad98-afc0-4d8f-8367-a010b3718d2f"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("72e357b4-dd7a-48b9-9ebb-d89749a57201"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("6397c794-ca37-498e-b5c3-32c772818b91"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // timPreview
            // 
            this.timPreview.Interval = 200;
            this.timPreview.Tick += new System.EventHandler(this.timPreview_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.documentBindingSource;
            // 
            // janusSuperTip1
            // 
            this.janusSuperTip1.AutoPopDelay = 10000;
            this.janusSuperTip1.BodyWidth = 360;
            this.janusSuperTip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.janusSuperTip1.ImageList = null;
            this.janusSuperTip1.InitialDelay = 200;
            this.janusSuperTip1.ShowAlways = true;
            // 
            // ucDocView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.uiTab1);
            resources.ApplyResources(this, "$this");
            this.Name = "ucDocView";
            this.VisibleChanged += new System.EventHandler(this.ucDocView_VisibleChanged);
            this.Resize += new System.EventHandler(this.ucDocView_Resize);
            ((System.ComponentModel.ISupportInitialize)(docDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.tabDocument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHideDocDisplay)).EndInit();
            this.pnlHideDocDisplay.ResumeLayout(false);
            this.pnlHideDocDisplayContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocView)).EndInit();
            this.pnlDocView.ResumeLayout(false);
            this.pnlDocViewContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axEDOffice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStatusBar)).EndInit();
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlStatusBarContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommandBar)).EndInit();
            this.pnlCommandBar.ResumeLayout(false);
            this.pnlCommandBarContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAttachment)).EndInit();
            this.pnlAttachment.ResumeLayout(false);
            this.pnlAttachmentContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAttachTop)).EndInit();
            this.pnlAttachTop.ResumeLayout(false);
            this.pnlAttachTopContainer.ResumeLayout(false);
            this.pnlAttachTopContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocTop)).EndInit();
            this.pnlDocTop.ResumeLayout(false);
            this.pnlDocTopContainer.ResumeLayout(false);
            this.pnlDocTopContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailTop)).EndInit();
            this.pnlEmailTop.ResumeLayout(false);
            this.pnlFromContainer.ResumeLayout(false);
            this.pnlFromContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCheckOut)).EndInit();
            this.pnlCheckOut.ResumeLayout(false);
            this.pnlCheckOutContainer.ResumeLayout(false);
            this.pnlCheckOutContainer.PerformLayout();
            this.tabMetadata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentDocContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRecipients)).EndInit();
            this.gbRecipients.ResumeLayout(false);
            this.gbRecipients.PerformLayout();
            this.tabNoDoc.ResumeLayout(false);
            this.tabNoDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage tabDocument;
        private Janus.Windows.UI.Tab.UITabPage tabMetadata;
        private Janus.Windows.UI.Tab.UITabPage tabVersionning;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.GridEX.EditControls.EditBox tbFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblCC;
        private Janus.Windows.UI.Dock.UIPanel pnlAttachment;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAttachmentContainer;
        private System.Windows.Forms.Label lblTo;
        private Janus.Windows.UI.Dock.UIPanel pnlEmailTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlFromContainer;
        private System.Windows.Forms.Label lblDate;
        private Janus.Windows.EditControls.UIButton btnMessageRead;
        private Janus.Windows.GridEX.EditControls.EditBox tbCC;
        private Janus.Windows.GridEX.EditControls.EditBox tbTo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Janus.Windows.UI.Dock.UIPanel pnlDocView;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocViewContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlDocTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocTopContainer;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.EditControls.EditBox tbSubjectDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timPreview;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private System.Windows.Forms.BindingSource docContentBindingSource;
        private System.Windows.Forms.BindingSource documentDocContentBindingSource;
        private TXTextControl.TextControl textControlCompose;
        private AxEDOfficeLib.AxEDOffice axEDOffice1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrint;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrintPreview;
        private Janus.Windows.UI.CommandBars.UICommand cmdRevise;
        private Janus.Windows.UI.CommandBars.UICommand cmdCheckInCheckOut;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopy;
        private Janus.Windows.UI.CommandBars.UICommand cmdMakeReadOnly;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocViewer;
        private Janus.Windows.UI.CommandBars.UICommand cmdExternalApp;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrint1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRevise1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCheckInCheckOut1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopy1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdMakeReadOnly1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocViewer1;
        private Janus.Windows.UI.CommandBars.UICommand cmdExternalApp1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCheckOut1;
        private Janus.Windows.UI.CommandBars.UICommand cmdUndoCheckOut1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdCheckIn1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCheckIn;
        private Janus.Windows.UI.CommandBars.UICommand cmdCheckOut;
        private Janus.Windows.UI.CommandBars.UICommand cmdUndoCheckOut;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyBrowse;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyOpen;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyNoOpen;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyClipboard;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyBrowse1;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyClipboard1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyOpen1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyNoOpen1;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        internal ucWB ucWB1;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.UI.CommandBars.UICommand Separator9;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
        private Janus.Windows.UI.Tab.UITabPage tabNoDoc;
        private System.Windows.Forms.Label lblNoDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNoDocumentText;
        private Janus.Windows.UI.Dock.UIPanel pnlCheckOut;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlCheckOutContainer;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private ucMultiDropDown ucMultiDropDown1;
        private Janus.Windows.GridEX.EditControls.EditBox editBox8;
        private Janus.Windows.EditControls.UIButton lnkEditCheckedOutDocument;
        private Janus.Windows.EditControls.UIButton btnDraftWatermark;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocShortcut;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocShortcut1;
        private Janus.Windows.UI.Dock.UIPanel pnlHideDocDisplay;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlHideDocDisplayContainer;
        private Janus.Windows.EditControls.UIButton btnLoadLargeDoc;
        private System.Windows.Forms.Label lblHideContentMessage;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.UI.Dock.UIPanel pnlCommandBar;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlCommandBarContainer;
        private Janus.Windows.CalendarCombo.CalendarCombo calEfDateMail;
        private Janus.Windows.CalendarCombo.CalendarCombo calEfDateDoc;
        private Janus.Windows.UI.Dock.UIPanel pnlAttachTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAttachTopContainer;
        private Janus.Windows.GridEX.EditControls.EditBox ebAttachFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.CalendarCombo.CalendarCombo calAttachLastChanged;
        private Janus.Windows.GridEX.EditControls.EditBox ebAttachAuthor;
        private Janus.Windows.GridEX.EditControls.EditBox ebAttachSize;
        private Janus.Windows.UI.Dock.UIPanel pnlStatusBar;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlStatusBarContainer;
        private Janus.Windows.CalendarCombo.CalendarCombo updateDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox updateUserEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo entryDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox entryUserEditBox;
        private Janus.Windows.EditControls.UICheckBox isDraftUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isLawmailUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox conversationIndexEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox authorEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox filedByEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedTimeCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo sentTimeCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox efSubjectEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo efDateCalendarCombo;
        private ucMultiDropDown commModeucMultiDropDown;
        private ucMultiDropDown efTypeucMultiDropDown;
        private Janus.Windows.GridEX.EditControls.EditBox sourceEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox docIdEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo updateDateCalendarCombo1;
        private Janus.Windows.GridEX.EditControls.EditBox updateUserEditBox1;
        private Janus.Windows.EditControls.UICheckBox readOnlyUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox versionEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox sizeEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo createDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo modDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox extEditBox;
        private Janus.Windows.EditControls.UIButton btnLaunchExcel;
        private ucRecipientTextBox ucRecipientTextBoxFrom;
        private ucRecipientTextBox ucRecipientTextBoxTo;
        private Janus.Windows.EditControls.UIButton buttonCC;
        private Janus.Windows.EditControls.UIButton buttonTo;
        private Janus.Windows.EditControls.UIButton buttonFrom;
        private ucRecipientTextBox ucRecipientTextBoxCc;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIGroupBox gbRecipients;
        private Janus.Windows.EditControls.UIButton btnExternalApp;
        private Janus.Windows.GridEX.EditControls.NumericEditBox editPageCount;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewVersionHistory;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewVersionHistory1;
        private Janus.Windows.UI.CommandBars.UICommand cmdConvertToPDF1;
        private Janus.Windows.UI.CommandBars.UICommand cmdConvertToPDF;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private ucMultiDropDown ddSourceDivision;
        private Janus.Windows.GridEX.EditControls.EditBox sentUserEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo sentDateCalendarCombo;
        private System.Windows.Forms.ImageList sentIndicatorImageList;
        private Janus.Windows.GridEX.EditControls.EditBox sentToESDCEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox tbSubjectMail;
    }
}
