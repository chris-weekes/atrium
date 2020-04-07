 namespace LawMate.UserControls
{
    partial class ucDoc
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
                Clear();
                ClearBindings(this);
                
                this.docContentBindingSource.CurrentChanged -= new System.EventHandler(this.documentBindingSource_CurrentChanged);
          
                DocumentCompleted = null;

                ucWB1.Dispose();

                this.timPreview.Tick -= new System.EventHandler(this.timPreview_Tick);
                timPreview.Dispose();
                this.lblDateReadValue.DataBindings.Clear();
                this.tbEfSubject.DataBindings.Clear();
                this.btnTo.Click -= new System.EventHandler(this.btnTo_Click);
                this.btnCC.Click -= new System.EventHandler(this.btnTo_Click);
                this.btnBCC.Click -= new System.EventHandler(this.btnTo_Click);
                this.btnMessageRead.Click -= new System.EventHandler(this.btnMessageRead_Click);
                this.uiCommandManager1.CommandClick -= new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
                this.textControlCompose.ImageCreated -= new TXTextControl.ImageEventHandler(this.textControlCompose_ImageCreated);
                this.textControlCompose.Validated -= new System.EventHandler(this.textControlCompose_Validated);
                this.textControlCompose.Changed -= new System.EventHandler(this.textControlCompose_Changed);


                textControlCompose.Dispose();
                ucRecipientTextBoxBcc.Dispose();
                ucRecipientTextBoxCc.Dispose();
                ucRecipientTextBoxFrom.Dispose();
                ucRecipientTextBoxTo.Dispose();

                //axFramerControl1.EventsEnabled = false;
                //axOfficeViewer1.Close();
                
                //axOfficeViewer1.Validated -= new System.EventHandler(axOfficeViewer1_Validated);
                axEDOffice1.Validated -= new System.EventHandler(axOfficeViewer1_Validated);
                //axFramerControl1.Close();
                //axFramerControl1.Dispose();

                if (axEDOffice1 != null)
                {
                    System.Reflection.FieldInfo fi = typeof(System.Windows.Forms.AxHost).GetField("oleSite",
                           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    object o = fi.GetValue(axEDOffice1);
                    System.GC.SuppressFinalize(o);
                }
                //if (axOfficeViewer1 != null)
                //{
                //    System.Reflection.FieldInfo fi = typeof(System.Windows.Forms.AxHost).GetField("oleSite",
                //           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                //    object o = fi.GetValue(axOfficeViewer1);
                //    System.GC.SuppressFinalize(o);
                //}

                components.Dispose();
            }
            else
            {
                //axFramerControl1.Close();
                //axFramerControl1.EventsEnabled = false;
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
            System.Windows.Forms.Label efTypeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDoc));
            System.Windows.Forms.Label efCodesLabel;
            System.Windows.Forms.Label sourceLabel;
            System.Windows.Forms.Label filedByLabel;
            System.Windows.Forms.Label authorLabel;
            System.Windows.Forms.Label checkedOutDateLabel;
            System.Windows.Forms.Label checkedOutByLabel;
            System.Windows.Forms.Label checkedOutPathLabel;
            lmDatasets.docDB docDB;
            System.Windows.Forms.Label extLabel;
            System.Windows.Forms.Label modDateLabel;
            System.Windows.Forms.Label createDateLabel;
            System.Windows.Forms.Label sizeLabel;
            System.Windows.Forms.Label versionLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label sourceDivisionLabel;
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timPreview = new System.Windows.Forms.Timer(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlNoDocument = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlNoDocumentContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.lblNoDocumentText = new System.Windows.Forms.Label();
            this.lblNoDocumentImg = new System.Windows.Forms.Label();
            this.pnlControlContainer = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlDocContainer = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlDocCheckInCheckOut = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocCheckInCheckOutContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lnkEditCheckedOutDocument = new System.Windows.Forms.LinkLabel();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.pnlFromDate = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel7Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnFrom = new System.Windows.Forms.Button();
            this.lblDateReadValue = new System.Windows.Forms.Label();
            this.ucRecipientTextBoxFrom = new LawMate.ucRecipientTextBox();
            this.lblFromCompose = new System.Windows.Forms.Label();
            this.lblDateRead = new System.Windows.Forms.Label();
            this.pnlTo = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnTo = new System.Windows.Forms.Button();
            this.ucRecipientTextBoxTo = new LawMate.ucRecipientTextBox();
            this.pnlCC = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlCCContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucRecipientTextBoxCc = new LawMate.ucRecipientTextBox();
            this.btnCC = new System.Windows.Forms.Button();
            this.pnlBCC = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBCCContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucRecipientTextBoxBcc = new LawMate.ucRecipientTextBox();
            this.btnBCC = new System.Windows.Forms.Button();
            this.pnlSubject = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel8Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.chkEncrypt = new System.Windows.Forms.CheckBox();
            this.tbEfSubject = new Janus.Windows.GridEX.EditControls.EditBox();
            this.efSubjectCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label6 = new System.Windows.Forms.Label();
            this.priorityJComboBox = new Janus.Windows.EditControls.UIComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlAttachment = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnInsert = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdPrint1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPrint");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAddDocXref1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddDocXref");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdReviseDocument1 = new Janus.Windows.UI.CommandBars.UICommand("cmdReviseDocument");
            this.cmdViewVersionHistory1 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewVersionHistory");
            this.cmdDocCheckOutCheckIn1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocCheckOutCheckIn");
            this.cmdCopyAttachment1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyAttachment");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMakeFinal1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMakeFinal");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdViewDDoc1 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewDDoc");
            this.cmdViewNative1 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewNative");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDisplayName1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDisplayName");
            this.cmdInsertExternalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertExternalFile");
            this.cmdInsertInternalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertInternalFile");
            this.cmdInsertSignatureBlock = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertSignatureBlock");
            this.cmdSignatureNewMessage1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSignatureNewMessage");
            this.cmdSignatureReplyForward1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSignatureReplyForward");
            this.cmdSignatureNewMessage = new Janus.Windows.UI.CommandBars.UICommand("cmdSignatureNewMessage");
            this.cmdSignatureReplyForward = new Janus.Windows.UI.CommandBars.UICommand("cmdSignatureReplyForward");
            this.cmdInsert = new Janus.Windows.UI.CommandBars.UICommand("cmdInsert");
            this.cmdInsertExternalFile2 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertExternalFile");
            this.cmdInsertInternalFile2 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertInternalFile");
            this.cmdInsertLink1 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertLink");
            this.cmdInsertRecord1 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertRecord");
            this.cmdFormat = new Janus.Windows.UI.CommandBars.UICommand("cmdFormat");
            this.cmdPlainText1 = new Janus.Windows.UI.CommandBars.UICommand("cmdPlainText");
            this.cmdRichText1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRichText");
            this.cmdWord1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWord");
            this.cmdPlainText = new Janus.Windows.UI.CommandBars.UICommand("cmdPlainText");
            this.cmdRichText = new Janus.Windows.UI.CommandBars.UICommand("cmdRichText");
            this.cmdWord = new Janus.Windows.UI.CommandBars.UICommand("cmdWord");
            this.cmdCopyAttachment = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyAttachment");
            this.cmdCopyToOriginalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyToOriginalFile");
            this.cmdCopyToPersonalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyToPersonalFile");
            this.cmdBrowseToFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdBrowseToFile");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCopyToClipboard1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyToClipboard");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdSendAsAttachment1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSendAsAttachment");
            this.cmdViewNative = new Janus.Windows.UI.CommandBars.UICommand("cmdViewNative");
            this.cmdViewDDoc = new Janus.Windows.UI.CommandBars.UICommand("cmdViewDDoc");
            this.cmdDisplayName = new Janus.Windows.UI.CommandBars.UICommand("cmdDisplayName");
            this.cmdCopyToOriginalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyToOriginalFile");
            this.cmdOpenWizardOriginalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdOpenWizardOriginalFile");
            this.cmdAutoAcNoWizardOriginalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoAcNoWizardOriginalFile");
            this.cmdBrowseToFile = new Janus.Windows.UI.CommandBars.UICommand("cmdBrowseToFile");
            this.cmdOpenWizard3 = new Janus.Windows.UI.CommandBars.UICommand("cmdOpenWizard");
            this.cmdAutoACNoWizard3 = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoACNoWizard");
            this.cmdCopyToPersonalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyToPersonalFile");
            this.cmdOpenWizardPersonalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdOpenWizardPersonalFile");
            this.cmdAutoAcNoWizardPersonalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoAcNoWizardPersonalFile");
            this.cmdOpenWizard = new Janus.Windows.UI.CommandBars.UICommand("cmdOpenWizard");
            this.cmdAutoACNoWizard = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoACNoWizard");
            this.cmdReviseDocument = new Janus.Windows.UI.CommandBars.UICommand("cmdReviseDocument");
            this.cmdOpenWizardPersonalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdOpenWizardPersonalFile");
            this.cmdOpenWizardOriginalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdOpenWizardOriginalFile");
            this.cmdAutoAcNoWizardPersonalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoAcNoWizardPersonalFile");
            this.cmdAutoAcNoWizardOriginalFile = new Janus.Windows.UI.CommandBars.UICommand("cmdAutoAcNoWizardOriginalFile");
            this.cmdPrint = new Janus.Windows.UI.CommandBars.UICommand("cmdPrint");
            this.cmdInsertLink = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertLink");
            this.cmdInsertRecord = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertRecord");
            this.cmdAddDocXref = new Janus.Windows.UI.CommandBars.UICommand("cmdAddDocXref");
            this.cmdDocCheckOutCheckIn = new Janus.Windows.UI.CommandBars.UICommand("cmdDocCheckOutCheckIn");
            this.cmdDocCheckOut1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocCheckOut");
            this.cmdDocCheckIn1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocCheckIn");
            this.cmdUndoDocCheckOut1 = new Janus.Windows.UI.CommandBars.UICommand("cmdUndoDocCheckOut");
            this.cmdDocCheckOut = new Janus.Windows.UI.CommandBars.UICommand("cmdDocCheckOut");
            this.cmdDocCheckIn = new Janus.Windows.UI.CommandBars.UICommand("cmdDocCheckIn");
            this.cmdUndoDocCheckOut = new Janus.Windows.UI.CommandBars.UICommand("cmdUndoDocCheckOut");
            this.cmdCopyToClipboard = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyToClipboard");
            this.cmdCopyAsLink = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyAsLink");
            this.cmdCopyText = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyText");
            this.cmdSelectAllText = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectAllText");
            this.cmdSendAsAttachment = new Janus.Windows.UI.CommandBars.UICommand("cmdSendAsAttachment");
            this.cmdMakeFinal = new Janus.Windows.UI.CommandBars.UICommand("cmdMakeFinal");
            this.cmdInsertExternalFileAsDraft = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertExternalFileAsDraft");
            this.cmdViewVersionHistory = new Janus.Windows.UI.CommandBars.UICommand("cmdViewVersionHistory");
            this.uiContextMenu2 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdCopyText1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCopyText");
            this.cmdSelectAllText1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSelectAllText");
            this.uiContextMenuViewAttachment = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdViewDDoc2 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewDDoc");
            this.cmdViewNative2 = new Janus.Windows.UI.CommandBars.UICommand("cmdViewNative");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.textControlCompose = new TXTextControl.TextControl();
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.cmdInsertExternalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertExternalFile");
            this.cmdInsertExternalFileAsDraft1 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertExternalFileAsDraft");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdInsertInternalFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertInternalFile");
            this.cmdInsertLink2 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertLink");
            this.cmdInsertRecord2 = new Janus.Windows.UI.CommandBars.UICommand("cmdInsertRecord");
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMessageRead = new Janus.Windows.EditControls.UIButton();
            this.pnlDocDisplay = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel2Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.btnDraftWatermark = new Janus.Windows.EditControls.UIButton();
            this.axEDOffice1 = new AxEDOfficeLib.AxEDOffice();
            this.ucWB1 = new LawMate.UserControls.ucWB();
            this.pnlNoDocToDisplay = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlNoDocToDisplayContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnLoadLargeDoc = new Janus.Windows.EditControls.UIButton();
            this.lblReason = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMetaData = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel5Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.sourceDivisionDataLabel = new System.Windows.Forms.Label();
            this.pageCounteditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.chkReadOnly = new Janus.Windows.EditControls.UICheckBox();
            this.docContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.documentDocContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkOpinion = new Janus.Windows.EditControls.UICheckBox();
            this.calEfDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkIsDraft = new Janus.Windows.EditControls.UICheckBox();
            this.dtmefDate = new System.Windows.Forms.DateTimePicker();
            this.ucMultiDropDown2 = new LawMate.UserControls.ucMultiDropDown();
            this.mccCommType = new LawMate.UserControls.ucMultiDropDown();
            this.readOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.versionLabel1 = new System.Windows.Forms.Label();
            this.sizeLabel1 = new System.Windows.Forms.Label();
            this.createDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.modDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.extLabel1 = new System.Windows.Forms.Label();
            this.lblCommModeCompose = new System.Windows.Forms.Label();
            this.opinionCheckBox = new System.Windows.Forms.CheckBox();
            this.efCodesTextBox = new System.Windows.Forms.TextBox();
            this.filedByLabel1 = new System.Windows.Forms.Label();
            this.authorLabel1 = new System.Windows.Forms.Label();
            this.pVCheckBox = new System.Windows.Forms.CheckBox();
            this.isDraftCheckBox = new System.Windows.Forms.CheckBox();
            this.isElectronicCheckBox = new System.Windows.Forms.CheckBox();
            this.isPaperCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceLabel1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            efTypeLabel = new System.Windows.Forms.Label();
            efCodesLabel = new System.Windows.Forms.Label();
            sourceLabel = new System.Windows.Forms.Label();
            filedByLabel = new System.Windows.Forms.Label();
            authorLabel = new System.Windows.Forms.Label();
            checkedOutDateLabel = new System.Windows.Forms.Label();
            checkedOutByLabel = new System.Windows.Forms.Label();
            checkedOutPathLabel = new System.Windows.Forms.Label();
            docDB = new lmDatasets.docDB();
            extLabel = new System.Windows.Forms.Label();
            modDateLabel = new System.Windows.Forms.Label();
            createDateLabel = new System.Windows.Forms.Label();
            sizeLabel = new System.Windows.Forms.Label();
            versionLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            sourceDivisionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(docDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNoDocument)).BeginInit();
            this.pnlNoDocument.SuspendLayout();
            this.pnlNoDocumentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControlContainer)).BeginInit();
            this.pnlControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocContainer)).BeginInit();
            this.pnlDocContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocCheckInCheckOut)).BeginInit();
            this.pnlDocCheckInCheckOut.SuspendLayout();
            this.pnlDocCheckInCheckOutContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFromDate)).BeginInit();
            this.pnlFromDate.SuspendLayout();
            this.uiPanel7Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTo)).BeginInit();
            this.pnlTo.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCC)).BeginInit();
            this.pnlCC.SuspendLayout();
            this.pnlCCContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBCC)).BeginInit();
            this.pnlBCC.SuspendLayout();
            this.pnlBCCContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSubject)).BeginInit();
            this.pnlSubject.SuspendLayout();
            this.uiPanel8Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAttachment)).BeginInit();
            this.pnlAttachment.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenuViewAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocDisplay)).BeginInit();
            this.pnlDocDisplay.SuspendLayout();
            this.uiPanel2Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axEDOffice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNoDocToDisplay)).BeginInit();
            this.pnlNoDocToDisplay.SuspendLayout();
            this.pnlNoDocToDisplayContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMetaData)).BeginInit();
            this.pnlMetaData.SuspendLayout();
            this.uiPanel5Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentDocContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // efTypeLabel
            // 
            resources.ApplyResources(efTypeLabel, "efTypeLabel");
            efTypeLabel.BackColor = System.Drawing.Color.Transparent;
            efTypeLabel.Name = "efTypeLabel";
            // 
            // efCodesLabel
            // 
            resources.ApplyResources(efCodesLabel, "efCodesLabel");
            efCodesLabel.BackColor = System.Drawing.Color.Transparent;
            efCodesLabel.Name = "efCodesLabel";
            // 
            // sourceLabel
            // 
            resources.ApplyResources(sourceLabel, "sourceLabel");
            sourceLabel.BackColor = System.Drawing.Color.Transparent;
            sourceLabel.Name = "sourceLabel";
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
            // docDB
            // 
            docDB.DataSetName = "docDB";
            docDB.EnforceConstraints = false;
            docDB.Locale = new System.Globalization.CultureInfo("en-CA");
            docDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            // 
            // sourceDivisionLabel
            // 
            resources.ApplyResources(sourceDivisionLabel, "sourceDivisionLabel");
            sourceDivisionLabel.BackColor = System.Drawing.Color.Transparent;
            sourceDivisionLabel.Name = "sourceDivisionLabel";
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataMember = "Document";
            this.documentBindingSource.DataSource = docDB;
            this.documentBindingSource.CurrentChanged += new System.EventHandler(this.documentBindingSource_CurrentChanged);
            // 
            // timPreview
            // 
            this.timPreview.Interval = 200;
            this.timPreview.Tick += new System.EventHandler(this.timPreview_Tick);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.DefaultPanelSettings.MinimumSize = ((System.Drawing.Size)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.MinimumSize")));
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlNoDocument.Id = new System.Guid("716cd8df-ade7-4414-952d-7838f9601580");
            this.uiPanelManager1.Panels.Add(this.pnlNoDocument);
            this.pnlControlContainer.Id = new System.Guid("aaebfe10-5eef-4c65-97aa-b8fb37a8617f");
            this.pnlControlContainer.StaticGroup = true;
            this.pnlDocContainer.Id = new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9");
            this.pnlDocContainer.StaticGroup = true;
            this.pnlDocCheckInCheckOut.Id = new System.Guid("a4167858-928c-48ca-b13b-b96ca93bf267");
            this.pnlDocContainer.Panels.Add(this.pnlDocCheckInCheckOut);
            this.pnlFromDate.Id = new System.Guid("f449d7db-72a7-49dd-8e31-d4536e708e0b");
            this.pnlDocContainer.Panels.Add(this.pnlFromDate);
            this.pnlTo.Id = new System.Guid("f0e8e2a3-1cea-40fb-84f9-57928be6734b");
            this.pnlDocContainer.Panels.Add(this.pnlTo);
            this.pnlCC.Id = new System.Guid("b23d88e7-76ec-44cb-9409-eb0e7ef9783f");
            this.pnlDocContainer.Panels.Add(this.pnlCC);
            this.pnlBCC.Id = new System.Guid("127eeabe-ad55-46df-8449-e2fadff4a639");
            this.pnlDocContainer.Panels.Add(this.pnlBCC);
            this.pnlSubject.Id = new System.Guid("a1cb68a2-a8f2-4a93-9e25-2241148c4e2b");
            this.pnlDocContainer.Panels.Add(this.pnlSubject);
            this.pnlAttachment.Id = new System.Guid("ec24b59b-4842-4353-b180-8fd09f493ffc");
            this.pnlDocContainer.Panels.Add(this.pnlAttachment);
            this.pnlDocDisplay.Id = new System.Guid("375c7ced-a73f-4b88-9435-ebda59890e30");
            this.pnlDocContainer.Panels.Add(this.pnlDocDisplay);
            this.pnlNoDocToDisplay.Id = new System.Guid("1b81f98a-382b-4d27-bd68-a658350db210");
            this.pnlDocContainer.Panels.Add(this.pnlNoDocToDisplay);
            this.pnlControlContainer.Panels.Add(this.pnlDocContainer);
            this.pnlMetaData.Id = new System.Guid("330904a9-1653-4339-9b47-2ec450406fd9");
            this.pnlControlContainer.Panels.Add(this.pnlMetaData);
            this.uiPanelManager1.Panels.Add(this.pnlControlContainer);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("aaebfe10-5eef-4c65-97aa-b8fb37a8617f"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(892, 493), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), new System.Guid("aaebfe10-5eef-4c65-97aa-b8fb37a8617f"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, 435, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a4167858-928c-48ca-b13b-b96ca93bf267"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 100, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("f449d7db-72a7-49dd-8e31-d4536e708e0b"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 29, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("f0e8e2a3-1cea-40fb-84f9-57928be6734b"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 29, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b23d88e7-76ec-44cb-9409-eb0e7ef9783f"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 29, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("127eeabe-ad55-46df-8449-e2fadff4a639"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 24, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a1cb68a2-a8f2-4a93-9e25-2241148c4e2b"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 24, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ec24b59b-4842-4353-b180-8fd09f493ffc"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 88, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("375c7ced-a73f-4b88-9435-ebda59890e30"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 427, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("1b81f98a-382b-4d27-bd68-a658350db210"), new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), 200, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("330904a9-1653-4339-9b47-2ec450406fd9"), new System.Guid("aaebfe10-5eef-4c65-97aa-b8fb37a8617f"), 635, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("716cd8df-ade7-4414-952d-7838f9601580"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(928, 648), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f0e8e2a3-1cea-40fb-84f9-57928be6734b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ec24b59b-4842-4353-b180-8fd09f493ffc"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("375c7ced-a73f-4b88-9435-ebda59890e30"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("aaebfe10-5eef-4c65-97aa-b8fb37a8617f"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("58bd90a5-fc39-4802-9d9b-d3379b068cf9"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("330904a9-1653-4339-9b47-2ec450406fd9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("75d135a4-0de4-4af9-aacc-bec39aefcf69"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f449d7db-72a7-49dd-8e31-d4536e708e0b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a1cb68a2-a8f2-4a93-9e25-2241148c4e2b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b23d88e7-76ec-44cb-9409-eb0e7ef9783f"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("127eeabe-ad55-46df-8449-e2fadff4a639"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b3314ada-a236-492a-af50-9ccf32a43dff"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("85304f90-ee64-40e5-ae4d-5b577163ac0b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("66a75679-f8d9-493c-a0b3-67cddea8d600"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a4167858-928c-48ca-b13b-b96ca93bf267"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1b81f98a-382b-4d27-bd68-a658350db210"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("716cd8df-ade7-4414-952d-7838f9601580"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlNoDocument
            // 
            this.pnlNoDocument.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlNoDocument, "pnlNoDocument");
            this.pnlNoDocument.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlNoDocument.InnerContainer = this.pnlNoDocumentContainer;
            this.pnlNoDocument.Name = "pnlNoDocument";
            // 
            // pnlNoDocumentContainer
            // 
            this.pnlNoDocumentContainer.Controls.Add(this.lblNoDocumentText);
            this.pnlNoDocumentContainer.Controls.Add(this.lblNoDocumentImg);
            resources.ApplyResources(this.pnlNoDocumentContainer, "pnlNoDocumentContainer");
            this.pnlNoDocumentContainer.Name = "pnlNoDocumentContainer";
            // 
            // lblNoDocumentText
            // 
            resources.ApplyResources(this.lblNoDocumentText, "lblNoDocumentText");
            this.lblNoDocumentText.BackColor = System.Drawing.Color.Transparent;
            this.lblNoDocumentText.Name = "lblNoDocumentText";
            // 
            // lblNoDocumentImg
            // 
            this.lblNoDocumentImg.BackColor = System.Drawing.Color.Transparent;
            this.lblNoDocumentImg.Image = global::LawMate.Properties.Resources.information;
            resources.ApplyResources(this.lblNoDocumentImg, "lblNoDocumentImg");
            this.lblNoDocumentImg.Name = "lblNoDocumentImg";
            // 
            // pnlControlContainer
            // 
            this.pnlControlContainer.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            resources.ApplyResources(this.pnlControlContainer, "pnlControlContainer");
            this.pnlControlContainer.Name = "pnlControlContainer";
            this.pnlControlContainer.SelectedPanel = this.pnlDocContainer;
            this.pnlControlContainer.TabAlignment = Janus.Windows.UI.Dock.TabAlignment.Top;
            this.pnlControlContainer.TabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.ImageAndText;
            // 
            // pnlDocContainer
            // 
            resources.ApplyResources(this.pnlDocContainer, "pnlDocContainer");
            this.pnlDocContainer.Name = "pnlDocContainer";
            // 
            // pnlDocCheckInCheckOut
            // 
            this.pnlDocCheckInCheckOut.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.pnlDocCheckInCheckOut.BorderCaption = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlDocCheckInCheckOut.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlDocCheckInCheckOut.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlDocCheckInCheckOut.CaptionFormatStyle.FontName = "arial";
            this.pnlDocCheckInCheckOut.CaptionFormatStyle.FontSize = 9F;
            resources.ApplyResources(this.pnlDocCheckInCheckOut, "pnlDocCheckInCheckOut");
            this.pnlDocCheckInCheckOut.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlDocCheckInCheckOut.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlDocCheckInCheckOut.InnerContainer = this.pnlDocCheckInCheckOutContainer;
            this.pnlDocCheckInCheckOut.Name = "pnlDocCheckInCheckOut";
            // 
            // pnlDocCheckInCheckOutContainer
            // 
            this.pnlDocCheckInCheckOutContainer.Controls.Add(this.editBox1);
            this.pnlDocCheckInCheckOutContainer.Controls.Add(this.lnkEditCheckedOutDocument);
            this.pnlDocCheckInCheckOutContainer.Controls.Add(this.calendarCombo1);
            this.pnlDocCheckInCheckOutContainer.Controls.Add(checkedOutDateLabel);
            this.pnlDocCheckInCheckOutContainer.Controls.Add(this.ucMultiDropDown1);
            this.pnlDocCheckInCheckOutContainer.Controls.Add(checkedOutPathLabel);
            this.pnlDocCheckInCheckOutContainer.Controls.Add(checkedOutByLabel);
            resources.ApplyResources(this.pnlDocCheckInCheckOutContainer, "pnlDocCheckInCheckOutContainer");
            this.pnlDocCheckInCheckOutContainer.Name = "pnlDocCheckInCheckOutContainer";
            // 
            // editBox1
            // 
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "CheckedOutPath", true));
            this.editBox1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.editBox1.DisabledForeColor = System.Drawing.Color.Black;
            this.editBox1.FlatBorderColor = System.Drawing.Color.Black;
            this.editBox1.MaxLength = 255;
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lnkEditCheckedOutDocument
            // 
            this.lnkEditCheckedOutDocument.BackColor = System.Drawing.Color.Transparent;
            this.lnkEditCheckedOutDocument.Image = global::LawMate.Properties.Resources.form;
            resources.ApplyResources(this.lnkEditCheckedOutDocument, "lnkEditCheckedOutDocument");
            this.lnkEditCheckedOutDocument.Name = "lnkEditCheckedOutDocument";
            this.lnkEditCheckedOutDocument.TabStop = true;
            this.lnkEditCheckedOutDocument.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditCheckedOutDocument_LinkClicked);
            // 
            // calendarCombo1
            // 
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.documentBindingSource, "CheckedOutDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.calendarCombo1.DropDownCalendar.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Nullable = true;
            this.calendarCombo1.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.calendarCombo1.ReadOnly = true;
            this.calendarCombo1.Value = new System.DateTime(2011, 4, 13, 0, 0, 0, 0);
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
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
            // pnlFromDate
            // 
            this.pnlFromDate.InnerContainer = this.uiPanel7Container;
            resources.ApplyResources(this.pnlFromDate, "pnlFromDate");
            this.pnlFromDate.Name = "pnlFromDate";
            // 
            // uiPanel7Container
            // 
            this.uiPanel7Container.Controls.Add(this.btnFrom);
            this.uiPanel7Container.Controls.Add(this.lblDateReadValue);
            this.uiPanel7Container.Controls.Add(this.ucRecipientTextBoxFrom);
            this.uiPanel7Container.Controls.Add(this.lblFromCompose);
            this.uiPanel7Container.Controls.Add(this.lblDateRead);
            resources.ApplyResources(this.uiPanel7Container, "uiPanel7Container");
            this.uiPanel7Container.Name = "uiPanel7Container";
            // 
            // btnFrom
            // 
            this.btnFrom.BackColor = System.Drawing.SystemColors.Control;
            this.btnFrom.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFrom, "btnFrom");
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.UseVisualStyleBackColor = true;
            this.btnFrom.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // lblDateReadValue
            // 
            resources.ApplyResources(this.lblDateReadValue, "lblDateReadValue");
            this.lblDateReadValue.BackColor = System.Drawing.Color.Transparent;
            this.lblDateReadValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "efDate", true));
            this.lblDateReadValue.Name = "lblDateReadValue";
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
            this.ucRecipientTextBoxFrom.UsesNewDocViewer = false;
            // 
            // lblFromCompose
            // 
            resources.ApplyResources(this.lblFromCompose, "lblFromCompose");
            this.lblFromCompose.BackColor = System.Drawing.Color.Transparent;
            this.lblFromCompose.Name = "lblFromCompose";
            // 
            // lblDateRead
            // 
            resources.ApplyResources(this.lblDateRead, "lblDateRead");
            this.lblDateRead.BackColor = System.Drawing.Color.Transparent;
            this.lblDateRead.Name = "lblDateRead";
            // 
            // pnlTo
            // 
            this.pnlTo.InnerContainer = this.uiPanel0Container;
            resources.ApplyResources(this.pnlTo, "pnlTo");
            this.pnlTo.Name = "pnlTo";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.btnTo);
            this.uiPanel0Container.Controls.Add(this.ucRecipientTextBoxTo);
            resources.ApplyResources(this.uiPanel0Container, "uiPanel0Container");
            this.uiPanel0Container.Name = "uiPanel0Container";
            // 
            // btnTo
            // 
            this.btnTo.BackColor = System.Drawing.SystemColors.Control;
            this.btnTo.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTo, "btnTo");
            this.btnTo.Name = "btnTo";
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
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
            this.ucRecipientTextBoxTo.UsesNewDocViewer = false;
            this.ucRecipientTextBoxTo.RecipientAdded += new LawMate.RecipientAddedToRecipientBoxHandler(this.ucRecipientTextBoxCc_RecipientAdded);
            this.ucRecipientTextBoxTo.RecipientRemoved += new LawMate.RecipientRemovedFromRecipientBoxHandler(this.ucRecipientTextBoxCc_RecipientRemoved);
            // 
            // pnlCC
            // 
            this.pnlCC.InnerContainer = this.pnlCCContainer;
            resources.ApplyResources(this.pnlCC, "pnlCC");
            this.pnlCC.Name = "pnlCC";
            // 
            // pnlCCContainer
            // 
            this.pnlCCContainer.Controls.Add(this.ucRecipientTextBoxCc);
            this.pnlCCContainer.Controls.Add(this.btnCC);
            resources.ApplyResources(this.pnlCCContainer, "pnlCCContainer");
            this.pnlCCContainer.Name = "pnlCCContainer";
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
            this.ucRecipientTextBoxCc.UsesNewDocViewer = false;
            this.ucRecipientTextBoxCc.RecipientAdded += new LawMate.RecipientAddedToRecipientBoxHandler(this.ucRecipientTextBoxCc_RecipientAdded);
            this.ucRecipientTextBoxCc.RecipientRemoved += new LawMate.RecipientRemovedFromRecipientBoxHandler(this.ucRecipientTextBoxCc_RecipientRemoved);
            // 
            // btnCC
            // 
            resources.ApplyResources(this.btnCC, "btnCC");
            this.btnCC.Name = "btnCC";
            this.btnCC.UseVisualStyleBackColor = true;
            this.btnCC.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // pnlBCC
            // 
            resources.ApplyResources(this.pnlBCC, "pnlBCC");
            this.pnlBCC.InnerContainer = this.pnlBCCContainer;
            this.pnlBCC.Name = "pnlBCC";
            // 
            // pnlBCCContainer
            // 
            this.pnlBCCContainer.Controls.Add(this.ucRecipientTextBoxBcc);
            this.pnlBCCContainer.Controls.Add(this.btnBCC);
            resources.ApplyResources(this.pnlBCCContainer, "pnlBCCContainer");
            this.pnlBCCContainer.Name = "pnlBCCContainer";
            // 
            // ucRecipientTextBoxBcc
            // 
            this.ucRecipientTextBoxBcc.AllowMultiple = true;
            resources.ApplyResources(this.ucRecipientTextBoxBcc, "ucRecipientTextBoxBcc");
            this.ucRecipientTextBoxBcc.BackColor = System.Drawing.Color.Transparent;
            this.ucRecipientTextBoxBcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucRecipientTextBoxBcc.IsReadOnly = false;
            this.ucRecipientTextBoxBcc.Name = "ucRecipientTextBoxBcc";
            this.ucRecipientTextBoxBcc.RecipType = "3";
            this.ucRecipientTextBoxBcc.UsesNewDocViewer = false;
            // 
            // btnBCC
            // 
            resources.ApplyResources(this.btnBCC, "btnBCC");
            this.btnBCC.Name = "btnBCC";
            this.btnBCC.UseVisualStyleBackColor = true;
            this.btnBCC.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // pnlSubject
            // 
            this.pnlSubject.InnerContainer = this.uiPanel8Container;
            resources.ApplyResources(this.pnlSubject, "pnlSubject");
            this.pnlSubject.Name = "pnlSubject";
            // 
            // uiPanel8Container
            // 
            this.uiPanel8Container.Controls.Add(this.chkEncrypt);
            this.uiPanel8Container.Controls.Add(this.tbEfSubject);
            this.uiPanel8Container.Controls.Add(this.efSubjectCounter);
            this.uiPanel8Container.Controls.Add(this.label6);
            this.uiPanel8Container.Controls.Add(this.priorityJComboBox);
            resources.ApplyResources(this.uiPanel8Container, "uiPanel8Container");
            this.uiPanel8Container.Name = "uiPanel8Container";
            // 
            // chkEncrypt
            // 
            resources.ApplyResources(this.chkEncrypt, "chkEncrypt");
            this.chkEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.chkEncrypt.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.documentBindingSource, "EncryptionRequired", true));
            this.chkEncrypt.Image = global::LawMate.Properties.Resources.encrypt;
            this.chkEncrypt.Name = "chkEncrypt";
            this.chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // tbEfSubject
            // 
            resources.ApplyResources(this.tbEfSubject, "tbEfSubject");
            this.tbEfSubject.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.tbEfSubject.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "efSubject", true));
            this.tbEfSubject.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.tbEfSubject.DisabledForeColor = System.Drawing.Color.Black;
            this.tbEfSubject.FlatBorderColor = System.Drawing.Color.Black;
            this.tbEfSubject.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Near;
            this.tbEfSubject.MaxLength = 255;
            this.tbEfSubject.Name = "tbEfSubject";
            this.tbEfSubject.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.tbEfSubject.TextChanged += new System.EventHandler(this.tbEfSubject_TextChanged);
            // 
            // efSubjectCounter
            // 
            resources.ApplyResources(this.efSubjectCounter, "efSubjectCounter");
            this.efSubjectCounter.BackColor = System.Drawing.SystemColors.Control;
            this.efSubjectCounter.DecimalDigits = 0;
            this.efSubjectCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.efSubjectCounter.MaxLength = 3;
            this.efSubjectCounter.Name = "efSubjectCounter";
            this.efSubjectCounter.ReadOnly = true;
            this.efSubjectCounter.TabStop = false;
            this.efSubjectCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.efSubjectCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.efSubjectCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // priorityJComboBox
            // 
            resources.ApplyResources(this.priorityJComboBox, "priorityJComboBox");
            this.priorityJComboBox.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.priorityJComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentBindingSource, "MailImportance", true));
            this.priorityJComboBox.ImageList = this.imageList1;
            this.priorityJComboBox.Name = "priorityJComboBox";
            this.priorityJComboBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mail.gif");
            this.imageList1.Images.SetKeyName(1, "outlook16x16.png");
            this.imageList1.Images.SetKeyName(2, "priorityHigh.png");
            this.imageList1.Images.SetKeyName(3, "priorityUrgent.png");
            this.imageList1.Images.SetKeyName(4, "blank.gif");
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.InnerContainer = this.uiPanel1Container;
            resources.ApplyResources(this.pnlAttachment, "pnlAttachment");
            this.pnlAttachment.Name = "pnlAttachment";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.btnInsert);
            this.uiPanel1Container.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.uiPanel1Container, "uiPanel1Container");
            this.uiPanel1Container.Name = "uiPanel1Container";
            // 
            // btnInsert
            // 
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Appearance = Janus.Windows.UI.Appearance.Normal;
            this.btnInsert.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.btnInsert.DropDownContextMenu = this.uiContextMenu1;
            this.btnInsert.HighlightActiveButton = false;
            this.btnInsert.Image = global::LawMate.Properties.Resources.paperclip;
            this.btnInsert.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.ShowFocusRectangle = false;
            this.btnInsert.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.btnInsert.UseCompatibleTextRendering = false;
            this.btnInsert.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdInsertExternalFile1,
            this.cmdInsertExternalFileAsDraft1,
            this.Separator8,
            this.cmdInsertInternalFile1,
            this.cmdInsertLink2,
            this.cmdInsertRecord2});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdInsertExternalFile,
            this.cmdInsertInternalFile,
            this.cmdInsertSignatureBlock,
            this.cmdSignatureNewMessage,
            this.cmdSignatureReplyForward,
            this.cmdInsert,
            this.cmdFormat,
            this.cmdPlainText,
            this.cmdRichText,
            this.cmdWord,
            this.cmdCopyAttachment,
            this.cmdViewNative,
            this.cmdViewDDoc,
            this.cmdDisplayName,
            this.cmdCopyToOriginalFile,
            this.cmdBrowseToFile,
            this.cmdCopyToPersonalFile,
            this.cmdOpenWizard,
            this.cmdAutoACNoWizard,
            this.cmdReviseDocument,
            this.cmdOpenWizardPersonalFile,
            this.cmdOpenWizardOriginalFile,
            this.cmdAutoAcNoWizardPersonalFile,
            this.cmdAutoAcNoWizardOriginalFile,
            this.cmdPrint,
            this.cmdInsertLink,
            this.cmdInsertRecord,
            this.cmdAddDocXref,
            this.cmdDocCheckOutCheckIn,
            this.cmdDocCheckOut,
            this.cmdDocCheckIn,
            this.cmdUndoDocCheckOut,
            this.cmdCopyToClipboard,
            this.cmdCopyAsLink,
            this.cmdCopyText,
            this.cmdSelectAllText,
            this.cmdSendAsAttachment,
            this.cmdMakeFinal,
            this.cmdInsertExternalFileAsDraft,
            this.cmdViewVersionHistory});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu2,
            this.uiContextMenuViewAttachment,
            this.uiContextMenu1});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("ab78109f-fbec-4bb7-9cce-92909bd5a732");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdPrint1,
            this.Separator4,
            this.cmdAddDocXref1,
            this.Separator2,
            this.cmdReviseDocument1,
            this.cmdViewVersionHistory1,
            this.cmdDocCheckOutCheckIn1,
            this.cmdCopyAttachment1,
            this.Separator3,
            this.cmdMakeFinal1,
            this.Separator1,
            this.cmdViewDDoc1,
            this.cmdViewNative1,
            this.Separator7,
            this.cmdDisplayName1});
            this.uiCommandBar2.FullRow = true;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.uiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandBar2_CommandClick);
            // 
            // cmdPrint1
            // 
            resources.ApplyResources(this.cmdPrint1, "cmdPrint1");
            this.cmdPrint1.Name = "cmdPrint1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdAddDocXref1
            // 
            resources.ApplyResources(this.cmdAddDocXref1, "cmdAddDocXref1");
            this.cmdAddDocXref1.Name = "cmdAddDocXref1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdReviseDocument1
            // 
            resources.ApplyResources(this.cmdReviseDocument1, "cmdReviseDocument1");
            this.cmdReviseDocument1.Name = "cmdReviseDocument1";
            // 
            // cmdViewVersionHistory1
            // 
            resources.ApplyResources(this.cmdViewVersionHistory1, "cmdViewVersionHistory1");
            this.cmdViewVersionHistory1.Name = "cmdViewVersionHistory1";
            // 
            // cmdDocCheckOutCheckIn1
            // 
            this.cmdDocCheckOutCheckIn1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdDocCheckOutCheckIn1, "cmdDocCheckOutCheckIn1");
            this.cmdDocCheckOutCheckIn1.Name = "cmdDocCheckOutCheckIn1";
            // 
            // cmdCopyAttachment1
            // 
            this.cmdCopyAttachment1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdCopyAttachment1, "cmdCopyAttachment1");
            this.cmdCopyAttachment1.Name = "cmdCopyAttachment1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdMakeFinal1
            // 
            resources.ApplyResources(this.cmdMakeFinal1, "cmdMakeFinal1");
            this.cmdMakeFinal1.Name = "cmdMakeFinal1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdViewDDoc1
            // 
            resources.ApplyResources(this.cmdViewDDoc1, "cmdViewDDoc1");
            this.cmdViewDDoc1.Name = "cmdViewDDoc1";
            // 
            // cmdViewNative1
            // 
            resources.ApplyResources(this.cmdViewNative1, "cmdViewNative1");
            this.cmdViewNative1.Name = "cmdViewNative1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // cmdDisplayName1
            // 
            resources.ApplyResources(this.cmdDisplayName1, "cmdDisplayName1");
            this.cmdDisplayName1.Name = "cmdDisplayName1";
            // 
            // cmdInsertExternalFile
            // 
            resources.ApplyResources(this.cmdInsertExternalFile, "cmdInsertExternalFile");
            this.cmdInsertExternalFile.Name = "cmdInsertExternalFile";
            // 
            // cmdInsertInternalFile
            // 
            resources.ApplyResources(this.cmdInsertInternalFile, "cmdInsertInternalFile");
            this.cmdInsertInternalFile.Name = "cmdInsertInternalFile";
            // 
            // cmdInsertSignatureBlock
            // 
            this.cmdInsertSignatureBlock.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSignatureNewMessage1,
            this.cmdSignatureReplyForward1});
            resources.ApplyResources(this.cmdInsertSignatureBlock, "cmdInsertSignatureBlock");
            this.cmdInsertSignatureBlock.Name = "cmdInsertSignatureBlock";
            // 
            // cmdSignatureNewMessage1
            // 
            resources.ApplyResources(this.cmdSignatureNewMessage1, "cmdSignatureNewMessage1");
            this.cmdSignatureNewMessage1.Name = "cmdSignatureNewMessage1";
            // 
            // cmdSignatureReplyForward1
            // 
            resources.ApplyResources(this.cmdSignatureReplyForward1, "cmdSignatureReplyForward1");
            this.cmdSignatureReplyForward1.Name = "cmdSignatureReplyForward1";
            // 
            // cmdSignatureNewMessage
            // 
            resources.ApplyResources(this.cmdSignatureNewMessage, "cmdSignatureNewMessage");
            this.cmdSignatureNewMessage.Name = "cmdSignatureNewMessage";
            // 
            // cmdSignatureReplyForward
            // 
            resources.ApplyResources(this.cmdSignatureReplyForward, "cmdSignatureReplyForward");
            this.cmdSignatureReplyForward.Name = "cmdSignatureReplyForward";
            // 
            // cmdInsert
            // 
            this.cmdInsert.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdInsertExternalFile2,
            this.cmdInsertInternalFile2,
            this.cmdInsertLink1,
            this.cmdInsertRecord1});
            this.cmdInsert.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdInsert, "cmdInsert");
            this.cmdInsert.Name = "cmdInsert";
            // 
            // cmdInsertExternalFile2
            // 
            resources.ApplyResources(this.cmdInsertExternalFile2, "cmdInsertExternalFile2");
            this.cmdInsertExternalFile2.Name = "cmdInsertExternalFile2";
            // 
            // cmdInsertInternalFile2
            // 
            resources.ApplyResources(this.cmdInsertInternalFile2, "cmdInsertInternalFile2");
            this.cmdInsertInternalFile2.Name = "cmdInsertInternalFile2";
            // 
            // cmdInsertLink1
            // 
            resources.ApplyResources(this.cmdInsertLink1, "cmdInsertLink1");
            this.cmdInsertLink1.Name = "cmdInsertLink1";
            // 
            // cmdInsertRecord1
            // 
            resources.ApplyResources(this.cmdInsertRecord1, "cmdInsertRecord1");
            this.cmdInsertRecord1.Name = "cmdInsertRecord1";
            // 
            // cmdFormat
            // 
            this.cmdFormat.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdPlainText1,
            this.cmdRichText1,
            this.cmdWord1});
            resources.ApplyResources(this.cmdFormat, "cmdFormat");
            this.cmdFormat.Name = "cmdFormat";
            // 
            // cmdPlainText1
            // 
            resources.ApplyResources(this.cmdPlainText1, "cmdPlainText1");
            this.cmdPlainText1.Name = "cmdPlainText1";
            // 
            // cmdRichText1
            // 
            resources.ApplyResources(this.cmdRichText1, "cmdRichText1");
            this.cmdRichText1.Name = "cmdRichText1";
            // 
            // cmdWord1
            // 
            resources.ApplyResources(this.cmdWord1, "cmdWord1");
            this.cmdWord1.Name = "cmdWord1";
            // 
            // cmdPlainText
            // 
            resources.ApplyResources(this.cmdPlainText, "cmdPlainText");
            this.cmdPlainText.Name = "cmdPlainText";
            // 
            // cmdRichText
            // 
            resources.ApplyResources(this.cmdRichText, "cmdRichText");
            this.cmdRichText.Name = "cmdRichText";
            // 
            // cmdWord
            // 
            resources.ApplyResources(this.cmdWord, "cmdWord");
            this.cmdWord.Name = "cmdWord";
            // 
            // cmdCopyAttachment
            // 
            this.cmdCopyAttachment.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCopyToOriginalFile1,
            this.cmdCopyToPersonalFile1,
            this.cmdBrowseToFile1,
            this.Separator5,
            this.cmdCopyToClipboard1,
            this.Separator6,
            this.cmdSendAsAttachment1});
            this.cmdCopyAttachment.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdCopyAttachment, "cmdCopyAttachment");
            this.cmdCopyAttachment.Name = "cmdCopyAttachment";
            // 
            // cmdCopyToOriginalFile1
            // 
            resources.ApplyResources(this.cmdCopyToOriginalFile1, "cmdCopyToOriginalFile1");
            this.cmdCopyToOriginalFile1.Name = "cmdCopyToOriginalFile1";
            // 
            // cmdCopyToPersonalFile1
            // 
            resources.ApplyResources(this.cmdCopyToPersonalFile1, "cmdCopyToPersonalFile1");
            this.cmdCopyToPersonalFile1.Name = "cmdCopyToPersonalFile1";
            // 
            // cmdBrowseToFile1
            // 
            resources.ApplyResources(this.cmdBrowseToFile1, "cmdBrowseToFile1");
            this.cmdBrowseToFile1.Name = "cmdBrowseToFile1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdCopyToClipboard1
            // 
            resources.ApplyResources(this.cmdCopyToClipboard1, "cmdCopyToClipboard1");
            this.cmdCopyToClipboard1.Name = "cmdCopyToClipboard1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdSendAsAttachment1
            // 
            resources.ApplyResources(this.cmdSendAsAttachment1, "cmdSendAsAttachment1");
            this.cmdSendAsAttachment1.Name = "cmdSendAsAttachment1";
            // 
            // cmdViewNative
            // 
            this.cmdViewNative.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdViewNative, "cmdViewNative");
            this.cmdViewNative.Name = "cmdViewNative";
            // 
            // cmdViewDDoc
            // 
            this.cmdViewDDoc.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdViewDDoc, "cmdViewDDoc");
            this.cmdViewDDoc.Name = "cmdViewDDoc";
            // 
            // cmdDisplayName
            // 
            this.cmdDisplayName.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdDisplayName, "cmdDisplayName");
            this.cmdDisplayName.Name = "cmdDisplayName";
            this.cmdDisplayName.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.cmdDisplayName.StateStyles.FormatStyle.FontName = "arial";
            // 
            // cmdCopyToOriginalFile
            // 
            this.cmdCopyToOriginalFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdOpenWizardOriginalFile1,
            this.cmdAutoAcNoWizardOriginalFile1});
            resources.ApplyResources(this.cmdCopyToOriginalFile, "cmdCopyToOriginalFile");
            this.cmdCopyToOriginalFile.Name = "cmdCopyToOriginalFile";
            // 
            // cmdOpenWizardOriginalFile1
            // 
            resources.ApplyResources(this.cmdOpenWizardOriginalFile1, "cmdOpenWizardOriginalFile1");
            this.cmdOpenWizardOriginalFile1.Name = "cmdOpenWizardOriginalFile1";
            // 
            // cmdAutoAcNoWizardOriginalFile1
            // 
            resources.ApplyResources(this.cmdAutoAcNoWizardOriginalFile1, "cmdAutoAcNoWizardOriginalFile1");
            this.cmdAutoAcNoWizardOriginalFile1.Name = "cmdAutoAcNoWizardOriginalFile1";
            // 
            // cmdBrowseToFile
            // 
            this.cmdBrowseToFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdOpenWizard3,
            this.cmdAutoACNoWizard3});
            resources.ApplyResources(this.cmdBrowseToFile, "cmdBrowseToFile");
            this.cmdBrowseToFile.Name = "cmdBrowseToFile";
            // 
            // cmdOpenWizard3
            // 
            resources.ApplyResources(this.cmdOpenWizard3, "cmdOpenWizard3");
            this.cmdOpenWizard3.Name = "cmdOpenWizard3";
            // 
            // cmdAutoACNoWizard3
            // 
            resources.ApplyResources(this.cmdAutoACNoWizard3, "cmdAutoACNoWizard3");
            this.cmdAutoACNoWizard3.Name = "cmdAutoACNoWizard3";
            // 
            // cmdCopyToPersonalFile
            // 
            this.cmdCopyToPersonalFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdOpenWizardPersonalFile1,
            this.cmdAutoAcNoWizardPersonalFile1});
            resources.ApplyResources(this.cmdCopyToPersonalFile, "cmdCopyToPersonalFile");
            this.cmdCopyToPersonalFile.Name = "cmdCopyToPersonalFile";
            // 
            // cmdOpenWizardPersonalFile1
            // 
            resources.ApplyResources(this.cmdOpenWizardPersonalFile1, "cmdOpenWizardPersonalFile1");
            this.cmdOpenWizardPersonalFile1.Name = "cmdOpenWizardPersonalFile1";
            // 
            // cmdAutoAcNoWizardPersonalFile1
            // 
            resources.ApplyResources(this.cmdAutoAcNoWizardPersonalFile1, "cmdAutoAcNoWizardPersonalFile1");
            this.cmdAutoAcNoWizardPersonalFile1.Name = "cmdAutoAcNoWizardPersonalFile1";
            // 
            // cmdOpenWizard
            // 
            resources.ApplyResources(this.cmdOpenWizard, "cmdOpenWizard");
            this.cmdOpenWizard.Name = "cmdOpenWizard";
            // 
            // cmdAutoACNoWizard
            // 
            resources.ApplyResources(this.cmdAutoACNoWizard, "cmdAutoACNoWizard");
            this.cmdAutoACNoWizard.Name = "cmdAutoACNoWizard";
            // 
            // cmdReviseDocument
            // 
            this.cmdReviseDocument.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdReviseDocument, "cmdReviseDocument");
            this.cmdReviseDocument.Name = "cmdReviseDocument";
            // 
            // cmdOpenWizardPersonalFile
            // 
            resources.ApplyResources(this.cmdOpenWizardPersonalFile, "cmdOpenWizardPersonalFile");
            this.cmdOpenWizardPersonalFile.Name = "cmdOpenWizardPersonalFile";
            // 
            // cmdOpenWizardOriginalFile
            // 
            resources.ApplyResources(this.cmdOpenWizardOriginalFile, "cmdOpenWizardOriginalFile");
            this.cmdOpenWizardOriginalFile.Name = "cmdOpenWizardOriginalFile";
            // 
            // cmdAutoAcNoWizardPersonalFile
            // 
            resources.ApplyResources(this.cmdAutoAcNoWizardPersonalFile, "cmdAutoAcNoWizardPersonalFile");
            this.cmdAutoAcNoWizardPersonalFile.Name = "cmdAutoAcNoWizardPersonalFile";
            // 
            // cmdAutoAcNoWizardOriginalFile
            // 
            resources.ApplyResources(this.cmdAutoAcNoWizardOriginalFile, "cmdAutoAcNoWizardOriginalFile");
            this.cmdAutoAcNoWizardOriginalFile.Name = "cmdAutoAcNoWizardOriginalFile";
            // 
            // cmdPrint
            // 
            this.cmdPrint.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdPrint, "cmdPrint");
            this.cmdPrint.Name = "cmdPrint";
            // 
            // cmdInsertLink
            // 
            resources.ApplyResources(this.cmdInsertLink, "cmdInsertLink");
            this.cmdInsertLink.Name = "cmdInsertLink";
            // 
            // cmdInsertRecord
            // 
            resources.ApplyResources(this.cmdInsertRecord, "cmdInsertRecord");
            this.cmdInsertRecord.Name = "cmdInsertRecord";
            // 
            // cmdAddDocXref
            // 
            this.cmdAddDocXref.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdAddDocXref, "cmdAddDocXref");
            this.cmdAddDocXref.Name = "cmdAddDocXref";
            // 
            // cmdDocCheckOutCheckIn
            // 
            this.cmdDocCheckOutCheckIn.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdDocCheckOut1,
            this.cmdDocCheckIn1,
            this.cmdUndoDocCheckOut1});
            this.cmdDocCheckOutCheckIn.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdDocCheckOutCheckIn, "cmdDocCheckOutCheckIn");
            this.cmdDocCheckOutCheckIn.Name = "cmdDocCheckOutCheckIn";
            // 
            // cmdDocCheckOut1
            // 
            resources.ApplyResources(this.cmdDocCheckOut1, "cmdDocCheckOut1");
            this.cmdDocCheckOut1.Name = "cmdDocCheckOut1";
            // 
            // cmdDocCheckIn1
            // 
            resources.ApplyResources(this.cmdDocCheckIn1, "cmdDocCheckIn1");
            this.cmdDocCheckIn1.Name = "cmdDocCheckIn1";
            // 
            // cmdUndoDocCheckOut1
            // 
            resources.ApplyResources(this.cmdUndoDocCheckOut1, "cmdUndoDocCheckOut1");
            this.cmdUndoDocCheckOut1.Name = "cmdUndoDocCheckOut1";
            // 
            // cmdDocCheckOut
            // 
            resources.ApplyResources(this.cmdDocCheckOut, "cmdDocCheckOut");
            this.cmdDocCheckOut.Name = "cmdDocCheckOut";
            // 
            // cmdDocCheckIn
            // 
            resources.ApplyResources(this.cmdDocCheckIn, "cmdDocCheckIn");
            this.cmdDocCheckIn.Name = "cmdDocCheckIn";
            // 
            // cmdUndoDocCheckOut
            // 
            resources.ApplyResources(this.cmdUndoDocCheckOut, "cmdUndoDocCheckOut");
            this.cmdUndoDocCheckOut.Name = "cmdUndoDocCheckOut";
            // 
            // cmdCopyToClipboard
            // 
            resources.ApplyResources(this.cmdCopyToClipboard, "cmdCopyToClipboard");
            this.cmdCopyToClipboard.Name = "cmdCopyToClipboard";
            // 
            // cmdCopyAsLink
            // 
            resources.ApplyResources(this.cmdCopyAsLink, "cmdCopyAsLink");
            this.cmdCopyAsLink.Name = "cmdCopyAsLink";
            // 
            // cmdCopyText
            // 
            resources.ApplyResources(this.cmdCopyText, "cmdCopyText");
            this.cmdCopyText.Name = "cmdCopyText";
            // 
            // cmdSelectAllText
            // 
            resources.ApplyResources(this.cmdSelectAllText, "cmdSelectAllText");
            this.cmdSelectAllText.Name = "cmdSelectAllText";
            // 
            // cmdSendAsAttachment
            // 
            resources.ApplyResources(this.cmdSendAsAttachment, "cmdSendAsAttachment");
            this.cmdSendAsAttachment.Name = "cmdSendAsAttachment";
            // 
            // cmdMakeFinal
            // 
            this.cmdMakeFinal.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdMakeFinal, "cmdMakeFinal");
            this.cmdMakeFinal.Name = "cmdMakeFinal";
            // 
            // cmdInsertExternalFileAsDraft
            // 
            resources.ApplyResources(this.cmdInsertExternalFileAsDraft, "cmdInsertExternalFileAsDraft");
            this.cmdInsertExternalFileAsDraft.Name = "cmdInsertExternalFileAsDraft";
            // 
            // cmdViewVersionHistory
            // 
            this.cmdViewVersionHistory.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdViewVersionHistory, "cmdViewVersionHistory");
            this.cmdViewVersionHistory.Name = "cmdViewVersionHistory";
            // 
            // uiContextMenu2
            // 
            this.uiContextMenu2.CommandManager = this.uiCommandManager1;
            this.uiContextMenu2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCopyText1,
            this.cmdSelectAllText1});
            resources.ApplyResources(this.uiContextMenu2, "uiContextMenu2");
            this.uiContextMenu2.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            // 
            // cmdCopyText1
            // 
            resources.ApplyResources(this.cmdCopyText1, "cmdCopyText1");
            this.cmdCopyText1.Name = "cmdCopyText1";
            // 
            // cmdSelectAllText1
            // 
            resources.ApplyResources(this.cmdSelectAllText1, "cmdSelectAllText1");
            this.cmdSelectAllText1.Name = "cmdSelectAllText1";
            // 
            // uiContextMenuViewAttachment
            // 
            this.uiContextMenuViewAttachment.CommandManager = this.uiCommandManager1;
            this.uiContextMenuViewAttachment.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdViewDDoc2,
            this.cmdViewNative2});
            resources.ApplyResources(this.uiContextMenuViewAttachment, "uiContextMenuViewAttachment");
            this.uiContextMenuViewAttachment.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            // 
            // cmdViewDDoc2
            // 
            resources.ApplyResources(this.cmdViewDDoc2, "cmdViewDDoc2");
            this.cmdViewDDoc2.Name = "cmdViewDDoc2";
            // 
            // cmdViewNative2
            // 
            resources.ApplyResources(this.cmdViewNative2, "cmdViewNative2");
            this.cmdViewNative2.Name = "cmdViewNative2";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            // 
            // textControlCompose
            // 
            resources.ApplyResources(this.textControlCompose, "textControlCompose");
            this.textControlCompose.ButtonBar = this.buttonBar1;
            this.uiCommandManager1.SetContextMenu(this.textControlCompose, this.uiContextMenu2);
            this.textControlCompose.Name = "textControlCompose";
            this.textControlCompose.PageMargins.Bottom = 79.03D;
            this.textControlCompose.PageMargins.Left = 79.03D;
            this.textControlCompose.PageMargins.Right = 79.03D;
            this.textControlCompose.PageMargins.Top = 79.03D;
            this.textControlCompose.ViewMode = TXTextControl.ViewMode.Normal;
            this.textControlCompose.Changed += new System.EventHandler(this.textControlCompose_Changed);
            this.textControlCompose.ImageCreated += new TXTextControl.ImageEventHandler(this.textControlCompose_ImageCreated);
            this.textControlCompose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textControlCompose_KeyDown);
            this.textControlCompose.Validated += new System.EventHandler(this.textControlCompose_Validated);
            // 
            // buttonBar1
            // 
            resources.ApplyResources(this.buttonBar1, "buttonBar1");
            this.buttonBar1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar1.Name = "buttonBar1";
            // 
            // cmdInsertExternalFile1
            // 
            resources.ApplyResources(this.cmdInsertExternalFile1, "cmdInsertExternalFile1");
            this.cmdInsertExternalFile1.Name = "cmdInsertExternalFile1";
            // 
            // cmdInsertExternalFileAsDraft1
            // 
            resources.ApplyResources(this.cmdInsertExternalFileAsDraft1, "cmdInsertExternalFileAsDraft1");
            this.cmdInsertExternalFileAsDraft1.Name = "cmdInsertExternalFileAsDraft1";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator8, "Separator8");
            this.Separator8.Name = "Separator8";
            // 
            // cmdInsertInternalFile1
            // 
            resources.ApplyResources(this.cmdInsertInternalFile1, "cmdInsertInternalFile1");
            this.cmdInsertInternalFile1.Name = "cmdInsertInternalFile1";
            // 
            // cmdInsertLink2
            // 
            resources.ApplyResources(this.cmdInsertLink2, "cmdInsertLink2");
            this.cmdInsertLink2.Name = "cmdInsertLink2";
            this.cmdInsertLink2.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // cmdInsertRecord2
            // 
            resources.ApplyResources(this.cmdInsertRecord2, "cmdInsertRecord2");
            this.cmdInsertRecord2.Name = "cmdInsertRecord2";
            this.cmdInsertRecord2.Visible = Janus.Windows.UI.InheritableBoolean.False;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnMessageRead);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnMessageRead
            // 
            this.btnMessageRead.Appearance = Janus.Windows.UI.Appearance.Normal;
            this.btnMessageRead.HighlightActiveButton = false;
            this.btnMessageRead.Image = global::LawMate.Properties.Resources.MarkasRead;
            this.btnMessageRead.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnMessageRead, "btnMessageRead");
            this.btnMessageRead.Name = "btnMessageRead";
            this.btnMessageRead.ShowFocusRectangle = false;
            this.btnMessageRead.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.btnMessageRead.UseCompatibleTextRendering = false;
            this.btnMessageRead.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnMessageRead.Click += new System.EventHandler(this.btnMessageRead_Click);
            // 
            // pnlDocDisplay
            // 
            this.pnlDocDisplay.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlDocDisplay.CaptionFormatStyle.FontName = "arial";
            this.pnlDocDisplay.CaptionFormatStyle.FontSize = 9F;
            resources.ApplyResources(this.pnlDocDisplay, "pnlDocDisplay");
            this.pnlDocDisplay.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlDocDisplay.InnerContainer = this.uiPanel2Container;
            this.pnlDocDisplay.Name = "pnlDocDisplay";
            // 
            // uiPanel2Container
            // 
            this.uiPanel2Container.Controls.Add(this.uiStatusBar1);
            this.uiPanel2Container.Controls.Add(this.btnDraftWatermark);
            this.uiPanel2Container.Controls.Add(this.buttonBar1);
            this.uiPanel2Container.Controls.Add(this.textControlCompose);
            this.uiPanel2Container.Controls.Add(this.axEDOffice1);
            this.uiPanel2Container.Controls.Add(this.ucWB1);
            resources.ApplyResources(this.uiPanel2Container, "uiPanel2Container");
            this.uiPanel2Container.Name = "uiPanel2Container";
            // 
            // uiStatusBar1
            // 
            resources.ApplyResources(this.uiStatusBar1, "uiStatusBar1");
            this.uiStatusBar1.Name = "uiStatusBar1";
            this.uiStatusBar1.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            uiStatusBarPanel1.Key = "PreviewMode";
            resources.ApplyResources(uiStatusBarPanel1, "uiStatusBarPanel1");
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            uiStatusBarPanel2.Key = "DraftMessage";
            resources.ApplyResources(uiStatusBarPanel2, "uiStatusBarPanel2");
            uiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "PnlFiller";
            resources.ApplyResources(uiStatusBarPanel3, "uiStatusBarPanel3");
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2,
            uiStatusBarPanel3});
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiStatusBar1.PanelHover += new Janus.Windows.UI.StatusBar.StatusBarEventHandler(this.uiStatusBar1_PanelHover);
            this.uiStatusBar1.PanelClick += new Janus.Windows.UI.StatusBar.StatusBarEventHandler(this.uiStatusBar1_PanelClick);
            // 
            // btnDraftWatermark
            // 
            resources.ApplyResources(this.btnDraftWatermark, "btnDraftWatermark");
            this.btnDraftWatermark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDraftWatermark.Image = global::LawMate.Properties.Resources.DraftDocumentPNG;
            this.btnDraftWatermark.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.btnDraftWatermark.Name = "btnDraftWatermark";
            this.btnDraftWatermark.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.SlateGray;
            this.btnDraftWatermark.UseCompatibleTextRendering = false;
            this.btnDraftWatermark.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnDraftWatermark.Click += new System.EventHandler(this.btnDraftWatermark_Click);
            // 
            // axEDOffice1
            // 
            resources.ApplyResources(this.axEDOffice1, "axEDOffice1");
            this.axEDOffice1.Name = "axEDOffice1";
            this.axEDOffice1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axEDOffice1.OcxState")));
            this.axEDOffice1.Tag = "a";
            this.axEDOffice1.Validated += new System.EventHandler(this.axOfficeViewer1_Validated);
            // 
            // ucWB1
            // 
            resources.ApplyResources(this.ucWB1, "ucWB1");
            this.ucWB1.Name = "ucWB1";
            this.ucWB1.TabStop = false;
            this.ucWB1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.ucWB1.DocumentCompleted += new LawMate.UserControls.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // pnlNoDocToDisplay
            // 
            this.pnlNoDocToDisplay.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlNoDocToDisplay, "pnlNoDocToDisplay");
            this.pnlNoDocToDisplay.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlNoDocToDisplay.InnerContainer = this.pnlNoDocToDisplayContainer;
            this.pnlNoDocToDisplay.Name = "pnlNoDocToDisplay";
            // 
            // pnlNoDocToDisplayContainer
            // 
            this.pnlNoDocToDisplayContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNoDocToDisplayContainer.Controls.Add(this.btnLoadLargeDoc);
            this.pnlNoDocToDisplayContainer.Controls.Add(this.lblReason);
            this.pnlNoDocToDisplayContainer.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlNoDocToDisplayContainer, "pnlNoDocToDisplayContainer");
            this.pnlNoDocToDisplayContainer.Name = "pnlNoDocToDisplayContainer";
            // 
            // btnLoadLargeDoc
            // 
            this.btnLoadLargeDoc.Image = global::LawMate.Properties.Resources.largefile;
            resources.ApplyResources(this.btnLoadLargeDoc, "btnLoadLargeDoc");
            this.btnLoadLargeDoc.Name = "btnLoadLargeDoc";
            this.btnLoadLargeDoc.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.btnLoadLargeDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.btnLoadLargeDoc.Click += new System.EventHandler(this.btnLoadLargeDoc_Click);
            // 
            // lblReason
            // 
            resources.ApplyResources(this.lblReason, "lblReason");
            this.lblReason.BackColor = System.Drawing.Color.Transparent;
            this.lblReason.Name = "lblReason";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Image = global::LawMate.Properties.Resources.information;
            this.label1.Name = "label1";
            // 
            // pnlMetaData
            // 
            this.pnlMetaData.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlMetaData.InnerContainer = this.uiPanel5Container;
            resources.ApplyResources(this.pnlMetaData, "pnlMetaData");
            this.pnlMetaData.Name = "pnlMetaData";
            // 
            // uiPanel5Container
            // 
            this.uiPanel5Container.Controls.Add(this.sourceDivisionDataLabel);
            this.uiPanel5Container.Controls.Add(sourceDivisionLabel);
            this.uiPanel5Container.Controls.Add(this.pageCounteditBox);
            this.uiPanel5Container.Controls.Add(label3);
            this.uiPanel5Container.Controls.Add(this.chkReadOnly);
            this.uiPanel5Container.Controls.Add(this.chkOpinion);
            this.uiPanel5Container.Controls.Add(this.calEfDate);
            this.uiPanel5Container.Controls.Add(this.chkIsDraft);
            this.uiPanel5Container.Controls.Add(label2);
            this.uiPanel5Container.Controls.Add(this.dtmefDate);
            this.uiPanel5Container.Controls.Add(this.ucMultiDropDown2);
            this.uiPanel5Container.Controls.Add(this.mccCommType);
            this.uiPanel5Container.Controls.Add(this.readOnlyCheckBox);
            this.uiPanel5Container.Controls.Add(versionLabel);
            this.uiPanel5Container.Controls.Add(this.versionLabel1);
            this.uiPanel5Container.Controls.Add(sizeLabel);
            this.uiPanel5Container.Controls.Add(this.sizeLabel1);
            this.uiPanel5Container.Controls.Add(createDateLabel);
            this.uiPanel5Container.Controls.Add(this.createDateDateTimePicker);
            this.uiPanel5Container.Controls.Add(modDateLabel);
            this.uiPanel5Container.Controls.Add(this.modDateDateTimePicker);
            this.uiPanel5Container.Controls.Add(extLabel);
            this.uiPanel5Container.Controls.Add(this.extLabel1);
            this.uiPanel5Container.Controls.Add(this.lblCommModeCompose);
            this.uiPanel5Container.Controls.Add(this.opinionCheckBox);
            this.uiPanel5Container.Controls.Add(efTypeLabel);
            this.uiPanel5Container.Controls.Add(efCodesLabel);
            this.uiPanel5Container.Controls.Add(this.efCodesTextBox);
            this.uiPanel5Container.Controls.Add(sourceLabel);
            this.uiPanel5Container.Controls.Add(filedByLabel);
            this.uiPanel5Container.Controls.Add(this.filedByLabel1);
            this.uiPanel5Container.Controls.Add(authorLabel);
            this.uiPanel5Container.Controls.Add(this.authorLabel1);
            this.uiPanel5Container.Controls.Add(this.pVCheckBox);
            this.uiPanel5Container.Controls.Add(this.isDraftCheckBox);
            this.uiPanel5Container.Controls.Add(this.isElectronicCheckBox);
            this.uiPanel5Container.Controls.Add(this.isPaperCheckBox);
            this.uiPanel5Container.Controls.Add(this.sourceLabel1);
            resources.ApplyResources(this.uiPanel5Container, "uiPanel5Container");
            this.uiPanel5Container.Name = "uiPanel5Container";
            // 
            // sourceDivisionDataLabel
            // 
            this.sourceDivisionDataLabel.BackColor = System.Drawing.Color.Transparent;
            this.sourceDivisionDataLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "SourceDivision", true));
            resources.ApplyResources(this.sourceDivisionDataLabel, "sourceDivisionDataLabel");
            this.sourceDivisionDataLabel.Name = "sourceDivisionDataLabel";
            // 
            // pageCounteditBox
            // 
            this.pageCounteditBox.BackColor = System.Drawing.Color.Pink;
            this.pageCounteditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.documentBindingSource, "PageCount", true));
            resources.ApplyResources(this.pageCounteditBox, "pageCounteditBox");
            this.pageCounteditBox.Name = "pageCounteditBox";
            this.pageCounteditBox.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
            this.pageCounteditBox.Value = 0;
            this.pageCounteditBox.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this.pageCounteditBox.Validated += new System.EventHandler(this.PageCount_Validated);
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkReadOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReadOnly.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.docContentBindingSource, "ReadOnly", true));
            this.chkReadOnly.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            resources.ApplyResources(this.chkReadOnly, "chkReadOnly");
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.chkReadOnly.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
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
            // chkOpinion
            // 
            this.chkOpinion.BackColor = System.Drawing.Color.Transparent;
            this.chkOpinion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOpinion.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.documentBindingSource, "Opinion", true));
            this.chkOpinion.Image = global::LawMate.Properties.Resources.opinion;
            this.chkOpinion.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            resources.ApplyResources(this.chkOpinion, "chkOpinion");
            this.chkOpinion.Name = "chkOpinion";
            this.chkOpinion.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.chkOpinion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // calEfDate
            // 
            resources.ApplyResources(this.calEfDate, "calEfDate");
            this.calEfDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.documentBindingSource, "efDate", true));
            this.calEfDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calEfDate.DropDownCalendar.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.calEfDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.calEfDate.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calEfDate.MonthIncrement = 0;
            this.calEfDate.Name = "calEfDate";
            this.calEfDate.OfficeColorScheme = Janus.Windows.CalendarCombo.OfficeColorScheme.Blue;
            this.calEfDate.Value = new System.DateTime(2016, 12, 7, 0, 0, 0, 0);
            this.calEfDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.calEfDate.YearIncrement = 0;
            // 
            // chkIsDraft
            // 
            this.chkIsDraft.BackColor = System.Drawing.Color.Transparent;
            this.chkIsDraft.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsDraft.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.documentBindingSource, "IsDraft", true));
            this.chkIsDraft.Image = global::LawMate.Properties.Resources.DraftDocumentPNG;
            this.chkIsDraft.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.AfterText;
            resources.ApplyResources(this.chkIsDraft, "chkIsDraft");
            this.chkIsDraft.Name = "chkIsDraft";
            this.chkIsDraft.OfficeColorScheme = Janus.Windows.UI.OfficeColorScheme.Blue;
            this.chkIsDraft.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // dtmefDate
            // 
            resources.ApplyResources(this.dtmefDate, "dtmefDate");
            this.dtmefDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.documentBindingSource, "efDate", true));
            this.dtmefDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmefDate.Name = "dtmefDate";
            // 
            // ucMultiDropDown2
            // 
            this.ucMultiDropDown2.BackColor = System.Drawing.Color.Transparent;
            this.ucMultiDropDown2.Column1 = "DocStyleCode";
            resources.ApplyResources(this.ucMultiDropDown2, "ucMultiDropDown2");
            this.ucMultiDropDown2.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.ucMultiDropDown2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentBindingSource, "CommMode", true));
            this.ucMultiDropDown2.DataSource = null;
            this.ucMultiDropDown2.DDColumn1Visible = true;
            this.ucMultiDropDown2.DropDownColumn1Width = 100;
            this.ucMultiDropDown2.DropDownColumn2Width = 300;
            this.ucMultiDropDown2.Name = "ucMultiDropDown2";
            this.ucMultiDropDown2.ReadOnly = false;
            this.ucMultiDropDown2.ReqColor = System.Drawing.SystemColors.Window;
            this.ucMultiDropDown2.SelectedValue = null;
            this.ucMultiDropDown2.ValueMember = "DocStyleCode";
            // 
            // mccCommType
            // 
            this.mccCommType.BackColor = System.Drawing.Color.White;
            this.mccCommType.Column1 = "DocTypeCode";
            resources.ApplyResources(this.mccCommType, "mccCommType");
            this.mccCommType.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.mccCommType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentBindingSource, "efType", true));
            this.mccCommType.DataSource = null;
            this.mccCommType.DDColumn1Visible = true;
            this.mccCommType.DropDownColumn1Width = 100;
            this.mccCommType.DropDownColumn2Width = 300;
            this.mccCommType.Name = "mccCommType";
            this.mccCommType.ReadOnly = false;
            this.mccCommType.ReqColor = System.Drawing.Color.Pink;
            this.mccCommType.SelectedValue = null;
            this.mccCommType.ValueMember = "DocTypeCode";
            this.mccCommType.Validated += new System.EventHandler(this.mccCommType_Validated);
            // 
            // readOnlyCheckBox
            // 
            this.readOnlyCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.readOnlyCheckBox, "readOnlyCheckBox");
            this.readOnlyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.docContentBindingSource, "ReadOnly", true));
            this.readOnlyCheckBox.Name = "readOnlyCheckBox";
            this.readOnlyCheckBox.UseVisualStyleBackColor = false;
            // 
            // versionLabel1
            // 
            this.versionLabel1.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.docContentBindingSource, "Version", true));
            resources.ApplyResources(this.versionLabel1, "versionLabel1");
            this.versionLabel1.Name = "versionLabel1";
            // 
            // sizeLabel1
            // 
            this.sizeLabel1.BackColor = System.Drawing.Color.Transparent;
            this.sizeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.docContentBindingSource, "Size", true));
            resources.ApplyResources(this.sizeLabel1, "sizeLabel1");
            this.sizeLabel1.Name = "sizeLabel1";
            // 
            // createDateDateTimePicker
            // 
            resources.ApplyResources(this.createDateDateTimePicker, "createDateDateTimePicker");
            this.createDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.docContentBindingSource, "CreateDate", true));
            this.createDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.createDateDateTimePicker.Name = "createDateDateTimePicker";
            // 
            // modDateDateTimePicker
            // 
            resources.ApplyResources(this.modDateDateTimePicker, "modDateDateTimePicker");
            this.modDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.docContentBindingSource, "ModDate", true));
            this.modDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.modDateDateTimePicker.Name = "modDateDateTimePicker";
            // 
            // extLabel1
            // 
            this.extLabel1.BackColor = System.Drawing.Color.Transparent;
            this.extLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.docContentBindingSource, "Ext", true));
            resources.ApplyResources(this.extLabel1, "extLabel1");
            this.extLabel1.Name = "extLabel1";
            // 
            // lblCommModeCompose
            // 
            resources.ApplyResources(this.lblCommModeCompose, "lblCommModeCompose");
            this.lblCommModeCompose.BackColor = System.Drawing.Color.Transparent;
            this.lblCommModeCompose.Name = "lblCommModeCompose";
            // 
            // opinionCheckBox
            // 
            this.opinionCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.opinionCheckBox, "opinionCheckBox");
            this.opinionCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.documentBindingSource, "Opinion", true));
            this.opinionCheckBox.Name = "opinionCheckBox";
            this.opinionCheckBox.UseVisualStyleBackColor = false;
            // 
            // efCodesTextBox
            // 
            this.efCodesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "efCodes", true));
            resources.ApplyResources(this.efCodesTextBox, "efCodesTextBox");
            this.efCodesTextBox.Name = "efCodesTextBox";
            // 
            // filedByLabel1
            // 
            this.filedByLabel1.BackColor = System.Drawing.Color.Transparent;
            this.filedByLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "FiledBy", true));
            resources.ApplyResources(this.filedByLabel1, "filedByLabel1");
            this.filedByLabel1.Name = "filedByLabel1";
            // 
            // authorLabel1
            // 
            this.authorLabel1.BackColor = System.Drawing.Color.Transparent;
            this.authorLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Author", true));
            resources.ApplyResources(this.authorLabel1, "authorLabel1");
            this.authorLabel1.Name = "authorLabel1";
            // 
            // pVCheckBox
            // 
            this.pVCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pVCheckBox, "pVCheckBox");
            this.pVCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.documentBindingSource, "PV", true));
            this.pVCheckBox.Name = "pVCheckBox";
            this.pVCheckBox.UseVisualStyleBackColor = false;
            // 
            // isDraftCheckBox
            // 
            this.isDraftCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.isDraftCheckBox, "isDraftCheckBox");
            this.isDraftCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.documentBindingSource, "IsDraft", true));
            this.isDraftCheckBox.Name = "isDraftCheckBox";
            this.isDraftCheckBox.UseVisualStyleBackColor = false;
            // 
            // isElectronicCheckBox
            // 
            this.isElectronicCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.isElectronicCheckBox, "isElectronicCheckBox");
            this.isElectronicCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.documentBindingSource, "isElectronic", true));
            this.isElectronicCheckBox.Name = "isElectronicCheckBox";
            this.isElectronicCheckBox.UseVisualStyleBackColor = false;
            // 
            // isPaperCheckBox
            // 
            this.isPaperCheckBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.isPaperCheckBox, "isPaperCheckBox");
            this.isPaperCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.documentBindingSource, "isPaper", true));
            this.isPaperCheckBox.Name = "isPaperCheckBox";
            this.isPaperCheckBox.UseVisualStyleBackColor = false;
            // 
            // sourceLabel1
            // 
            this.sourceLabel1.BackColor = System.Drawing.Color.Transparent;
            this.sourceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Source", true));
            resources.ApplyResources(this.sourceLabel1, "sourceLabel1");
            this.sourceLabel1.Name = "sourceLabel1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.documentBindingSource;
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = null;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.Name = "uiCommandBar1";
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
            // ucDoc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlControlContainer);
            this.Controls.Add(this.pnlNoDocument);
            this.Controls.Add(this.TopRebar1);
            resources.ApplyResources(this, "$this");
            this.Name = "ucDoc";
            ((System.ComponentModel.ISupportInitialize)(docDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNoDocument)).EndInit();
            this.pnlNoDocument.ResumeLayout(false);
            this.pnlNoDocumentContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlControlContainer)).EndInit();
            this.pnlControlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocContainer)).EndInit();
            this.pnlDocContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocCheckInCheckOut)).EndInit();
            this.pnlDocCheckInCheckOut.ResumeLayout(false);
            this.pnlDocCheckInCheckOutContainer.ResumeLayout(false);
            this.pnlDocCheckInCheckOutContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFromDate)).EndInit();
            this.pnlFromDate.ResumeLayout(false);
            this.uiPanel7Container.ResumeLayout(false);
            this.uiPanel7Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTo)).EndInit();
            this.pnlTo.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            this.uiPanel0Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCC)).EndInit();
            this.pnlCC.ResumeLayout(false);
            this.pnlCCContainer.ResumeLayout(false);
            this.pnlCCContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBCC)).EndInit();
            this.pnlBCC.ResumeLayout(false);
            this.pnlBCCContainer.ResumeLayout(false);
            this.pnlBCCContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSubject)).EndInit();
            this.pnlSubject.ResumeLayout(false);
            this.uiPanel8Container.ResumeLayout(false);
            this.uiPanel8Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAttachment)).EndInit();
            this.pnlAttachment.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenuViewAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDocDisplay)).EndInit();
            this.pnlDocDisplay.ResumeLayout(false);
            this.uiPanel2Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axEDOffice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNoDocToDisplay)).EndInit();
            this.pnlNoDocToDisplay.ResumeLayout(false);
            this.pnlNoDocToDisplayContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMetaData)).EndInit();
            this.pnlMetaData.ResumeLayout(false);
            this.uiPanel5Container.ResumeLayout(false);
            this.uiPanel5Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentDocContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timPreview;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlDocDisplay;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel2Container;
        internal ucWB ucWB1;
        private TXTextControl.TextControl textControlCompose;
        private Janus.Windows.UI.Dock.UIPanel pnlAttachment;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private Janus.Windows.UI.Dock.UIPanel pnlTo;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private System.Windows.Forms.Label lblDateRead;
        private System.Windows.Forms.Label lblDateReadValue;
        private ucRecipientTextBox ucRecipientTextBoxBcc;
        private ucRecipientTextBox ucRecipientTextBoxCc;
        private ucRecipientTextBox ucRecipientTextBoxTo;
        private System.Windows.Forms.Button btnCC;
        private System.Windows.Forms.Label lblFromCompose;
        private System.Windows.Forms.Button btnBCC;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Janus.Windows.EditControls.UIButton btnMessageRead;
        private System.Windows.Forms.Button btnTo;
        private ucRecipientTextBox ucRecipientTextBoxFrom;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlControlContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlDocContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlMetaData;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel5Container;
        private System.Windows.Forms.CheckBox opinionCheckBox;
        private System.Windows.Forms.TextBox efCodesTextBox;
        private System.Windows.Forms.Label sourceLabel1;
        private System.Windows.Forms.Label filedByLabel1;
        private System.Windows.Forms.Label authorLabel1;
        private System.Windows.Forms.CheckBox pVCheckBox;
        private System.Windows.Forms.CheckBox isDraftCheckBox;
        private System.Windows.Forms.CheckBox isElectronicCheckBox;
        private System.Windows.Forms.CheckBox isPaperCheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private ucMultiDropDown ucMultiDropDown1;
        private System.Windows.Forms.Label lblCommModeCompose;
        private Janus.Windows.UI.Dock.UIPanel pnlFromDate;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel7Container;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertExternalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertInternalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertSignatureBlock;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertExternalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertInternalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSignatureNewMessage1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSignatureReplyForward1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSignatureNewMessage;
        private Janus.Windows.UI.CommandBars.UICommand cmdSignatureReplyForward;
        private Janus.Windows.UI.Dock.UIPanel pnlSubject;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel8Container;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox readOnlyCheckBox;
        private System.Windows.Forms.BindingSource docContentBindingSource;
        private System.Windows.Forms.Label versionLabel1;
        private System.Windows.Forms.Label sizeLabel1;
        private System.Windows.Forms.DateTimePicker createDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker modDateDateTimePicker;
        private System.Windows.Forms.Label extLabel1;
        private System.Windows.Forms.BindingSource documentDocContentBindingSource;
        private ucMultiDropDown mccCommType;
        private ucMultiDropDown ucMultiDropDown2;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsert;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertExternalFile2;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertInternalFile2;
        private Janus.Windows.UI.Dock.UIPanel pnlCC;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlCCContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBCC;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBCCContainer;
        private Janus.Windows.UI.CommandBars.UICommand cmdFormat;
        private Janus.Windows.UI.CommandBars.UICommand cmdPlainText1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRichText1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWord1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPlainText;
        private Janus.Windows.UI.CommandBars.UICommand cmdRichText;
        private Janus.Windows.UI.CommandBars.UICommand cmdWord;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private Janus.Windows.EditControls.UIButton btnInsert;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyAttachment1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyAttachment;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewNative1;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewNative;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewDDoc1;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewDDoc;
        private System.Windows.Forms.Label lblReason;
        private Janus.Windows.UI.CommandBars.UICommand cmdDisplayName1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDisplayName;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyToOriginalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyToPersonalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdBrowseToFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyToOriginalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdBrowseToFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyToPersonalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdOpenWizard3;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoACNoWizard3;
        private Janus.Windows.UI.CommandBars.UICommand cmdOpenWizard;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoACNoWizard;
        private Janus.Windows.UI.CommandBars.UICommand cmdReviseDocument1;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdOpenWizardOriginalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoAcNoWizardOriginalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdOpenWizardPersonalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoAcNoWizardPersonalFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdReviseDocument;
        private Janus.Windows.UI.CommandBars.UICommand cmdOpenWizardPersonalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdOpenWizardOriginalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoAcNoWizardPersonalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdAutoAcNoWizardOriginalFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrint1;
        private Janus.Windows.UI.CommandBars.UICommand cmdPrint;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertLink1;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertRecord1;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertLink;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertRecord;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertLink2;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertRecord2;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddDocXref1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddDocXref;
        private Janus.Windows.UI.Dock.UIPanel pnlDocCheckInCheckOut;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocCheckInCheckOutContainer;
        private System.Windows.Forms.LinkLabel lnkEditCheckedOutDocument;
        private Janus.Windows.GridEX.EditControls.EditBox tbEfSubject;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocCheckOutCheckIn;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocCheckOut;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocCheckIn;
        private Janus.Windows.UI.CommandBars.UICommand cmdUndoDocCheckOut;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocCheckOutCheckIn1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocCheckOut1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocCheckIn1;
        private Janus.Windows.UI.CommandBars.UICommand cmdUndoDocCheckOut1;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyToClipboard;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyAsLink;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyToClipboard1;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.UI.Dock.UIPanel pnlNoDocToDisplay;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlNoDocToDisplayContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlNoDocument;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlNoDocumentContainer;
        private System.Windows.Forms.Label lblNoDocumentText;
        private System.Windows.Forms.Label lblNoDocumentImg;
        private System.Windows.Forms.Button btnFrom;
        private Janus.Windows.GridEX.EditControls.NumericEditBox efSubjectCounter;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyText;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectAllText;
        private Janus.Windows.UI.CommandBars.UICommand cmdCopyText1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSelectAllText1;
        private System.Windows.Forms.DateTimePicker dtmefDate;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenuViewAttachment;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewDDoc2;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewNative2;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.EditControls.UIButton btnLoadLargeDoc;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand cmdSendAsAttachment1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSendAsAttachment;
        private TXTextControl.ButtonBar buttonBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMakeFinal;
        private Janus.Windows.UI.CommandBars.UICommand cmdMakeFinal1;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertExternalFileAsDraft;
        private Janus.Windows.UI.CommandBars.UICommand cmdInsertExternalFileAsDraft1;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.CalendarCombo.CalendarCombo calEfDate;
        private Janus.Windows.EditControls.UICheckBox chkIsDraft;
        private Janus.Windows.EditControls.UICheckBox chkReadOnly;
        private Janus.Windows.EditControls.UICheckBox chkOpinion;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private AxEDOfficeLib.AxEDOffice axEDOffice1;
        private Janus.Windows.EditControls.UIButton btnDraftWatermark;
        private Janus.Windows.GridEX.EditControls.NumericEditBox pageCounteditBox;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewVersionHistory;
        private Janus.Windows.UI.CommandBars.UICommand cmdViewVersionHistory1;
        private System.Windows.Forms.Label sourceDivisionDataLabel;
        private Janus.Windows.EditControls.UIComboBox priorityJComboBox;
    }
}
