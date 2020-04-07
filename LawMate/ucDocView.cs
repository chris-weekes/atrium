using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using lmDatasets;

namespace LawMate.UserControls
{
    public enum DocViewDisplayType
    {
        MailHeader,
        DocHeader,
        AttachmentHeader
    }

    public enum RecipientType
    {
        From = 0,
        To = 1,
        Cc = 2,
        Bcc = 3
    }

    public enum DocCommandBar
    {
        Hide = 0,
        Enable = 1,
        Disable = 2
    }

    public partial class ucDocView : UserControl
    {
        public Control ReturnFocusTo;
        private Color tbBGColor = Color.FromArgb(219, 235, 255);
        atriumBE.DocManager myDM;
        Janus.Windows.Common.SuperTipSettings jstSettings;
        int DocSizeLimit;
        private fBrowse fileBrowser;
        public fBrowseDocs OpenDocDialog;
        bool isHighlight = false;

        public event DocLoadedEventHandler DocLoaded;
        public event DocActionEventHandler DocAction;
        public event WebBrowserDocumentCompletedEventHandler DocumentCompleted;

        bool allowActionToolbar = true;
        public bool AllowActionToolbar
        {
            get { return allowActionToolbar; }
            set { allowActionToolbar = value; }
        }

        bool noDocDisplayed = false;
        public bool NoDocDisplayed
        {
            get { return noDocDisplayed; }
            set { noDocDisplayed = value; }
        }

        string tempFileForPreview;
        public string TempFile
        {
            get { return tempFileForPreview; }
            set { tempFileForPreview = value; }
        }

        string tmpFldForPreview;
        public string TempFld
        {
            get { return tmpFldForPreview; }
            set { tmpFldForPreview = value; }
        }

        DocViewDisplayType docDisplayType = DocViewDisplayType.MailHeader;
        public DocViewDisplayType DocDisplayType
        {
            get { return docDisplayType; }
            set
            {
                docDisplayType = value;
                switch (docDisplayType)
                {
                    case DocViewDisplayType.MailHeader:
                        pnlEmailTop.Closed = false;
                        pnlDocTop.Closed = true;
                        pnlAttachTop.Closed = true;
                        tabDocument.Image = Properties.Resources.mail5;
                        tabDocument.Text = "Message";
                        if (mbAllowMetadata)
                            ShowMetadata = true;
                        btnMessageRead.Text = "Message";
                        btnMessageRead.Image = Properties.Resources.mail5;
                        break;
                    case DocViewDisplayType.DocHeader:
                        pnlEmailTop.Closed = true;
                        pnlDocTop.Closed = false;
                        pnlAttachTop.Closed = true;
                        tabDocument.Image = Properties.Resources.SoC;
                        tabDocument.Text = "Document";
                        if (mbAllowMetadata)
                            ShowMetadata = true;
                        btnMessageRead.Text = "Document";
                        btnMessageRead.Image = Properties.Resources.SoC;
                        break;
                    case DocViewDisplayType.AttachmentHeader:
                        pnlEmailTop.Closed = true;
                        pnlDocTop.Closed = true;
                        pnlAttachTop.Closed = false;
                        tabDocument.Image = Properties.Resources.paperclip;
                        tabDocument.Text = "Attachment";
                        ShowMetadata = false;
                        if (displayedDoc != null && displayedDoc.isLawmail)
                        {

                            btnMessageRead.Text = "Message";
                            btnMessageRead.Image = Properties.Resources.mail5;
                        }
                        else
                        {
                            btnMessageRead.Text = "Document";
                            btnMessageRead.Image = Properties.Resources.SoC;
                        }
                        break;
                }
            }
        }

        DocCommandBar actionToolbarView = DocCommandBar.Enable;
        public DocCommandBar ActionToolbarView
        {
            get { return actionToolbarView; }
            set
            {
                actionToolbarView = value;
                switch (actionToolbarView)
                {
                    case DocCommandBar.Enable:
                        pnlCommandBar.Closed = false;
                        uiCommandBar1.Enabled = true;
                        btnExternalApp.Visible = false;
                        break;
                    case DocCommandBar.Disable:
                        pnlCommandBar.Closed = false;
                        btnExternalApp.Visible = true;
                        uiCommandBar1.Enabled = false;
                        break;
                    case DocCommandBar.Hide:
                        pnlCommandBar.Closed = true;
                        uiCommandBar1.Enabled = false;
                        btnExternalApp.Visible = false;
                        break;
                }
            }
        }

        bool mbShowAttachmentPanel = false;
        public bool ShowAttachmentPanel
        {
            get { return mbShowAttachmentPanel; }
            set
            {
                mbShowAttachmentPanel = value;
                pnlAttachment.Closed = !(ShowAttachmentPanel);
            }
        }

        bool mbAllowMetadata = false;
        public bool AllowMetadata
        {
            get { return mbAllowMetadata; }
            set
            {
                mbAllowMetadata = value;
            }
        }


        bool mbAllowMetadataUpdate = false;
        public bool AllowMetadataUpdate
        {
            get { return mbAllowMetadataUpdate; }
            set
            {
                mbAllowMetadataUpdate = value;
            }
        }

        bool mbShowMetadata = false;
        public bool ShowMetadata
        {
            get { return mbShowMetadata; }
            set
            {
                mbShowMetadata = value;
                tabMetadata.TabVisible = mbShowMetadata;
            }
        }

        bool mbShowVersion = false;
        public bool ShowVersion
        {
            get { return mbShowVersion; }
            set
            {
                mbShowVersion = value;
                tabVersionning.TabVisible = mbShowVersion;
            }
        }

        bool mbForceTextControl = false;
        public bool ForceTextControl
        {
            get { return mbForceTextControl; }
            set { mbForceTextControl = value; }
        }

        public object Datasource
        {
            get { return documentBindingSource.DataSource; }
            set
            {
                timPreview.Stop();
                documentBindingSource.DataSource = value;
                ApplySecurity(DocRecord);
            }
        }

        private docDB.DocumentRow displayedDoc;
        public docDB.DocumentRow DocRecord
        {
            get
            {
                if (documentBindingSource.Count == 0)
                    return null;
                else
                    return (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;
            }
        }

        public ucDocView()
        {
            InitializeComponent();

            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableNew, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableOpen, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableSave, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableSaveAs, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableClose, true);
            axEDOffice1.ShowRibbonTitlebar(false);

            ucWB1.OpenLinksInNewWindows = true;

            jstSettings = new Janus.Windows.Common.SuperTipSettings();
            jstSettings.Text = Properties.Resources.ThisViewIsAPreviewOnly;
            jstSettings.HeaderText = Properties.Resources.NoteAboutDocumentPreview;
            jstSettings.HeaderImage = Properties.Resources.lightbulb;
            janusSuperTip1.SetSuperTip(uiStatusBar1, jstSettings);

            uiStatusBar1.Panels["pnlPreview"].Text = Properties.Resources.NoteAboutDocumentPreview;
            uiStatusBar1.Panels["pnlPreview"].Image = Properties.Resources.lightbulb;
            uiStatusBar1.Panels["pnlDraft"].Text = Properties.Resources.DraftDocument;
            uiStatusBar1.Panels["pnlDraft"].Image = Properties.Resources.DraftDocumentPNG;

            
        }

        public void Init(atriumBE.DocManager dm)
        {
            try
            {
                myDM = dm;
                LoadLabels();
                timPreview.Stop();
                DocSizeLimit = myDM.AtMng.GetSetting(atriumBE.AppIntSetting.DocumentPreviewSize);

                if (myDM != null)
                {
                    UIHelper.ComboBoxInit("docType", efTypeucMultiDropDown, myDM.FM);
                    UIHelper.ComboBoxInit("CommMode", commModeucMultiDropDown, myDM.FM);
                    ucMultiDropDown1.SetDataBinding(myDM.FM.Codes("OfficerList"), "");

                    //DataTable dt1 = myDM.AtMng.GetFile().Codes("Dim1");
                    //lmDatasets.appDB.ddLookupRow dlr1 = (lmDatasets.appDB.ddLookupRow)myDM.AtMng.DB.ddLookup.Select("LookupName='Dim1'")[0];
                    //UIHelper.ComboBoxInit(dt1, ddSourceDivision, myDM.AtMng.GetFile());
                    UIHelper.ComboBoxInit("vAppealLevel", ddSourceDivision, myDM.AtMng.GetFile());

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);

            }


        }

        public void ClearBindings(Control ctl)
        {
            Binding[] bindings = new Binding[ctl.DataBindings.Count];
            ctl.DataBindings.CopyTo(bindings, 0);
            ctl.DataBindings.Clear();

            foreach (Binding bnd in bindings)
                if (null != bnd) TypeDescriptor.Refresh(bnd.DataSource);

            PropertyInfo dataSourceProperty = ctl.GetType().GetProperty("DataSource");
            object[] obj = new object[] { };
            if (null != dataSourceProperty)
                dataSourceProperty.SetValue(ctl, null, obj);

            foreach (Control child in ctl.Controls)
                ClearBindings(child);
        }

        public void Clear()
        {
            try
            {
                ucWB1.Url = new Uri("about:blank");
                textControlCompose.ResetContents();

                if (axEDOffice1.GetDocumentName() != null)
                {
                    axEDOffice1.CloseDoc();
                }
            }
            catch (Exception x)
            {
            }
        }

        public void EndEdit()
        {
            documentBindingSource.EndEdit();
            docContentBindingSource.EndEdit();
        }

        Janus.Windows.UI.Tab.UITabPage lastDisplayTab;
        public void NoAssociatedDocument(string message)
        {
            noDocDisplayed = true;
            timPreview.Stop();
            ReturnFocusTo = Win32.GetFocusControl();
            Clear();

            lblNoDocumentText.Visible = (message.Length > 0);
            lblNoDocumentText.Text = message;

            lastDisplayTab = uiTab1.SelectedTab;
            uiTab1.ShowTabs = false;
            tabNoDoc.TabVisible = true;
            uiTab1.SelectedTab = tabNoDoc;
        }

        public void HideContent(string message)
        {
            noDocDisplayed = true;
            ReturnFocusTo = Win32.GetFocusControl();
            Clear();
            btnLoadLargeDoc.Visible = false;
            btnLaunchExcel.Visible = false;
            lblHideContentMessage.Visible = (message.Length > 0);
            lblHideContentMessage.Text = message;
            FlipPanelsNoDisplayOfContent(true, false);
            ReturnFocus();

        }

        private void FlipPanelsNoDisplayOfContent(bool dontShowDoc, bool enableActionToolbar)
        {
            pnlDocView.Closed = dontShowDoc;
            pnlHideDocDisplay.Closed = !dontShowDoc;
            if (allowActionToolbar)
            {
                if (enableActionToolbar)
                    ActionToolbarView = DocCommandBar.Enable;
                else
                    actionToolbarView = DocCommandBar.Disable;
            }
        }

        public void Preview()
        {
            Application.UseWaitCursor = true;
            isHighlight = false;
            docDB.DocumentRow dr = DocRecord;

            if (dr == null)
            {
                Clear();
                Application.UseWaitCursor = false;
                return;
            }

            FlipPanelsNoDisplayOfContent(false, true);
            uiPanelManager1.SuspendPanelLayout();
            InitDocRecordDep(dr);
            if (dr.CommMode == "DC" && dr.GetAttachmentRowsByDocument_Attachment().Length > 0)
            {

                DisplayContents(dr.GetAttachmentRowsByDocument_Attachment()[0].DocumentRowByDocument_Attachment1, true, false);
            }
            else
            {
                DisplayContents(dr, false, false);
            }

            SetRecipientBoxHeight();
            uiPanelManager1.ResumePanelLayout();


            if (DocLoaded != null)
                DocLoaded(this, new DocLoadedEventArgs());
            Application.UseWaitCursor = false;
        }

        private bool Initializing = false;
        private void InitDocRecordDep(docDB.DocumentRow ddr)
        {
            // Load Recipients and Display
            if (Initializing)
                return;
            Initializing = true;

            try
            {
                InitDisplay(ddr, false);
                if (ddr.IsDocRefIdNull())
                    docContentBindingSource.DataSource = new DataView(ddr.Table.DataSet.Tables["DocContent"], "false", "", DataViewRowState.CurrentRows);
                else
                    docContentBindingSource.DataSource = new DataView(ddr.Table.DataSet.Tables["DocContent"], "DocId=" + ddr.DocRefId.ToString(), "", DataViewRowState.CurrentRows);

                // grab current list of recips in case of cancel
                // does this grab all recipients for all docs?

                LoadRecipients(ddr, tbFrom, RecipientType.From);
                LoadRecipients(ddr, tbTo, RecipientType.To);
                LoadRecipients(ddr, tbCC, RecipientType.Cc);
                ccRow(tbCC.Text.Length == 0);

                btnMessageRead.Tag = ddr;

                // Load Attachments
                ShowAttachmentPanel = false;
                flowLayoutPanel1.Controls.Clear();
                foreach (docDB.AttachmentRow attch in ddr.GetAttachmentRowsByDocument_Attachment())
                {
                    AddAtt(attch);
                }
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {
                Initializing = false;
            }
        }

        private void LoadRecipients(docDB.DocumentRow doc, Janus.Windows.GridEX.EditControls.EditBox eb, RecipientType recType)
        {
            DataView dvRecip = new DataView(doc.Table.DataSet.Tables["Recipient"], "docid=" + doc.DocId.ToString() + " and Type='" + Convert.ToInt32(recType) + "'", "", DataViewRowState.CurrentRows);
            eb.Text = "";
            foreach (DataRowView dvr in dvRecip)
            {
                CreateRecipient((docDB.RecipientRow)dvr.Row, eb, recType);
            }

            switch (recType)
            {
                case RecipientType.From:
                    ucRecipientTextBoxFrom.Init(myDM, doc);

                    break;
                case RecipientType.To:
                    ucRecipientTextBoxTo.Init(myDM, doc);

                    break;
                case RecipientType.Cc:
                    ucRecipientTextBoxCc.Init(myDM, doc);
                    break;
            }
        }

        bool ToTextBoxExpanded = false;
        bool CcTextBoxExpanded = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showCCRow">Whether to display the Cc row</param>
        /// <param name="reset">Whether to reset the heights and tops on controls in MailHeader Panel</param>
        public void SetRecipientBoxHeight()
        {
            int tbHeightIncrement = 15;
            Size toTextWidth = TextRenderer.MeasureText(tbTo.Text, tbTo.Font);
            Size ccTextWidth = TextRenderer.MeasureText(tbCC.Text, tbCC.Font);

            if (toTextWidth.Width > tbTo.Width) //text width greater than width of text box
            {
                if (!ToTextBoxExpanded) //if not expanded yet
                {
                    ToTextBoxExpanded = true;
                    tbTo.Height += tbHeightIncrement;
                    tbTo.ScrollBars = ScrollBars.Vertical;
                    lblCC.Top += tbHeightIncrement;
                    tbCC.Top += tbHeightIncrement;
                    lblSubject.Top += tbHeightIncrement;
                    tbSubjectMail.Top += tbHeightIncrement;
                    pnlEmailTop.Height += tbHeightIncrement;
                }
            }
            else //text less than width of control
            {
                if (ToTextBoxExpanded) //text box is expanded; reset
                {
                    ToTextBoxExpanded = false;
                    tbTo.Height -= tbHeightIncrement;
                    tbTo.ScrollBars = ScrollBars.None;
                    lblCC.Top -= tbHeightIncrement;
                    tbCC.Top -= tbHeightIncrement;
                    lblSubject.Top -= tbHeightIncrement;
                    tbSubjectMail.Top -= tbHeightIncrement;
                    pnlEmailTop.Height -= tbHeightIncrement;
                }
            }
            if (ccTextWidth.Width > tbCC.Width) //text width greater than width of text box
            {
                if (!CcTextBoxExpanded) //if not expanded yet
                {
                    CcTextBoxExpanded = true;
                    tbCC.Height += tbHeightIncrement;
                    tbCC.ScrollBars = ScrollBars.Vertical;
                    lblSubject.Top += tbHeightIncrement;
                    tbSubjectMail.Top += tbHeightIncrement;
                    pnlEmailTop.Height += tbHeightIncrement;
                }
            }
            else //text less than width of control
            {
                if (CcTextBoxExpanded) //text box is expanded; reset
                {
                    CcTextBoxExpanded = false;
                    tbCC.Height -= tbHeightIncrement;
                    tbCC.ScrollBars = ScrollBars.None;
                    lblSubject.Top -= tbHeightIncrement;
                    tbSubjectMail.Top -= tbHeightIncrement;
                    pnlEmailTop.Height -= tbHeightIncrement;
                }
            }

            const int DefaultAttachmentPanelHeight = 0;
            const int pnlHeightIncrement = 28;
            pnlAttachment.Height = DefaultAttachmentPanelHeight;
            if (ShowAttachmentPanel)
            {
                if (flowLayoutPanel1.VerticalScroll.Visible)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        pnlAttachment.Height += pnlHeightIncrement;
                        if (!flowLayoutPanel1.VerticalScroll.Visible)
                            return;
                    }
                }
            }
        }

        private void CreateRecipient(docDB.RecipientRow recipientRow, Janus.Windows.GridEX.EditControls.EditBox eb, RecipientType recType)
        {
            if (recipientRow.Name == "")
                return;
            if (eb.Text.Length == 0)
                eb.Text = recipientRow.Name + ";";
            else
                eb.Text += " " + recipientRow.Name + ";";
        }

        private void SizeAttachmentPanel(bool AttachmentPanelDisplayed)
        {
            if (AttachmentPanelDisplayed)
            {
                //int vHeight;
                //if (flowLayoutPanel1.Height < 56 && flowLayoutPanel1.VerticalScroll.Visible)
                //    vHeight = 56;
                //else
                //    vHeight = 28;


                //pnlAttachment.MinimumSize = new Size(-1, vHeight);
                //pnlAttachment.MaximumSize = new Size(-1, vHeight);
                //pnlAttachment.Size = new Size(pnlAttachment.Width, vHeight);
            }
        }

        bool ccRowHidden;
        private void ccRow(bool hideCCRow)
        {
            int RowHeight = 19;

            if (hideCCRow)
            {
                if (!ccRowHidden)
                {
                    ccRowHidden = true;
                    lblCC.Visible = false;
                    tbCC.Visible = false;

                    lblSubject.Top -= RowHeight;
                    tbSubjectMail.Top -= RowHeight;
                    pnlEmailTop.Height -= RowHeight;
                }
            }
            else
            {
                if (ccRowHidden)
                {
                    ccRowHidden = false;
                    lblCC.Visible = true;
                    tbCC.Visible = true;

                    lblSubject.Top += RowHeight;
                    tbSubjectMail.Top += RowHeight;
                    pnlEmailTop.Height += RowHeight;
                }
            }
        }

        private void ToggleEnableOfRecipientButtons(bool enable, Button btn, ucRecipientTextBox ucRec)
        {
            ucRec.IsReadOnly = !enable;
            btn.Enabled = enable;
        }

        private void AddAtt(docDB.AttachmentRow attch)
        {
            docDB.DocumentRow attr = attch.DocumentRowByDocument_Attachment1;
            if (attr != null)
            {
                Janus.Windows.EditControls.UIButton btn = new Janus.Windows.EditControls.UIButton();
                btn.Name = attch.Id.ToString();
                btn.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
                btn.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
                string ext = attr.IsextNull() ? attr.DocContentRow.Ext : attr.ext;
                btn.Width = System.Windows.Forms.TextRenderer.MeasureText(attr.efSubject + ext, btn.Font).Width + 30;
                btn.Height = 20;
                btn.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
                btn.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
                btn.ShowFocusRectangle = false;

                btn.Tag = attch;  //use attachment in tag so we have access to version CJW 2015-4-21

                btn.Text = attr.efSubject + ext;
                if (attr.IsDraft)
                {
                    btn.Font = new Font(btn.Font, FontStyle.Underline);
                }
                btn.Click += new System.EventHandler(this.btnMessageRead_Click);

                if (attr.IsiconNull())
                {
                    if (attr.RowState == DataRowState.Unchanged)
                    {
                        //try to load image
                        attr.icon = UIHelper.GetFileIcon(attr.Name.Trim());
                        attr.AcceptChanges();
                    }
                    else
                    {
                        attr.icon = UIHelper.GetFileIcon(attr.Name.Trim());
                    }
                }
                if (!attr.IsiconNull())
                {
                    System.IO.MemoryStream ms = new MemoryStream(attr.icon);
                    btn.Image = Image.FromStream(ms);
                    ms.Close();
                }

                flowLayoutPanel1.Controls.Add(btn);

                ShowAttachmentPanel = true;
            }
        }

        private void DisplayContents(docDB.DocumentRow ddr, bool isAttach, bool load)
        {
            //JLL if ddr is null here, it bombs because of currentversion property on null row
            if (ddr == null)
                return;
            DisplayContents(ddr, isAttach, load, ddr.CurrentVersion);
        }
        private void DisplayContents(docDB.DocumentRow ddr, bool isAttach, bool load, string version)
        {
            if (ddr == null)
                return;

            ToggleStatusBarPanel("pnlVersion", false);

            sentToESDCEditBox.ImageIndex = -1;
            sentToESDCEditBox.Visible = false;
            if (sentToESDCEditBox.Tag.ToString() != string.Empty)
            {
                string sent = sentToESDCEditBox.Tag.ToString();
                if (sent == "2")
                    sentToESDCEditBox.ImageIndex = 0;
                if (sent == "3")
                    sentToESDCEditBox.ImageIndex = 1;
                if (sentToESDCEditBox.ImageIndex > -1)
                    sentToESDCEditBox.Visible = true;
            }

            displayedDoc = ddr;
            noDocDisplayed = false;
            Datasource = new DataView(ddr.Table, "Docid=" + ddr.DocId.ToString(), "", DataViewRowState.CurrentRows);
            if (ddr.IsDocRefIdNull())
                docContentBindingSource.DataSource = new DataView(ddr.Table.DataSet.Tables["DocContent"], "false", "", DataViewRowState.CurrentRows);
            else
                docContentBindingSource.DataSource = new DataView(ddr.Table.DataSet.Tables["DocContent"], "DocId=" + ddr.DocRefId.ToString(), "", DataViewRowState.CurrentRows);


            cmdViewVersionHistory.Visible = Janus.Windows.UI.InheritableBoolean.True;
            cmdConvertToPDF.Visible = Janus.Windows.UI.InheritableBoolean.True;

            if (this.ParentForm != null)
            {
                if (this.ParentForm.Name == "fBFList")
                {
                    cmdViewVersionHistory.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdConvertToPDF.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }
            }

            if (cmdViewVersionHistory.Visible == Janus.Windows.UI.InheritableBoolean.True)
            {
                if (ddr.IsDraft)
                {
                    cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                if (myDM.AtMng.SecurityManager.CanExecute(myDM.FM.CurrentFileId, atSecurity.SecurityManager.Features.DocVersion) != atSecurity.SecurityManager.ExPermissions.Yes)
                {
                    cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
            }

            if (cmdConvertToPDF.Visible == Janus.Windows.UI.InheritableBoolean.True)
            {
                switch (ddr.ext.ToLower())
                {
                    case ".doc":
                    case ".docx":
                    case ".rtf":
                        if (ddr.IsDraft)
                        {
                            cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        }
                        else
                        {
                            cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        break;
                    default:
                        cmdConvertToPDF.Visible = Janus.Windows.UI.InheritableBoolean.False;
                        break;
                }
                if (myDM.AtMng.SecurityManager.CanExecute(myDM.FM.CurrentFileId, atSecurity.SecurityManager.Features.ConvertDoc) != atSecurity.SecurityManager.ExPermissions.Yes)
                {
                    cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
            }



            if (isAttach)
            {
                DocDisplayType = DocViewDisplayType.AttachmentHeader;
                string attachFilename;
                if (ddr.IsextNull())
                    attachFilename = ddr.efSubject + ddr.DocContentRow.Ext;
                else
                    attachFilename = ddr.efSubject + ddr.ext;

                ebAttachFileName.Text = attachFilename;
                if (!ddr.IsSizeNull())
                    ebAttachSize.Text = UIHelper.GetSizeReadable(ddr.Size);
                if (!ddr.IsupdateDateNull())
                    calAttachLastChanged.Value = ddr.updateDate;
            }
            else if (ddr.isLawmail)
                DocDisplayType = DocViewDisplayType.MailHeader;
            else
                DocDisplayType = DocViewDisplayType.DocHeader;

            if (((!ddr.IsSizeNull() && ddr.Size > DocSizeLimit) | (ddr.DocContentRow != null && !ddr.DocContentRow.IsSizeNull() && ddr.DocContentRow.Size > DocSizeLimit)) && !load && ddr.isElectronic && ddr.DocContentRow == null)
            {
                int size = 0;
                if (ddr.IsSizeNull())
                    size = ddr.DocContentRow.Size;
                else
                    size = ddr.Size;
                HideContent(String.Format(Properties.Resources.WarningThisDocumentIsLarge, size));
                btnLoadLargeDoc.Visible = true;
                btnLoadLargeDoc.Tag = isAttach;
            }
            else
            {
                if (ddr.isElectronic && (( ddr.DocContentRow == null && ddr.RowState != DataRowState.Added )||(ddr.DocContentRow!=null && version !=null && !ddr.DocContentRow.IsVersionNull() && version!=ddr.DocContentRow.Version )))
                    myDM.GetDocContent().Load(ddr.DocRefId, version);

                InitDisplay(ddr, isAttach);

                if (ddr.DocContentRow != null && !ddr.DocContentRow.IsSizeNull())
                    ebAttachSize.Text = UIHelper.GetSizeReadable(ddr.DocContentRow.Size);

                if (axEDOffice1.GetDocumentName() != null)
                    axEDOffice1.CloseDoc();

                textControlCompose.ResetContents();

                if (!ddr.isElectronic)
                {
                    cmdPrint.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdExternalApp.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCopy.Visible = Janus.Windows.UI.InheritableBoolean.False;

                    HideContent(Properties.Resources.ThereIsNoElectronicVersionOfTheDocument);
                }
                else
                {
                    cmdPrint.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    cmdExternalApp.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    cmdCopy.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    if (!ddr.IsCheckedOutByNull())
                    {
                        pnlCheckOut.Closed = false;
                        lnkEditCheckedOutDocument.Visible = (ddr.CheckedOutBy == myDM.AtMng.OfficerLoggedOn.OfficerId);
                    }
                    else
                    {
                        pnlCheckOut.Closed = true;
                        lnkEditCheckedOutDocument.Visible = false;
                    }

                    if (ddr.DocContentRow!=null && ddr.DocContentRow.FileFormatRow != null && ddr.DocContentRow.FileFormatRow.AllowPreview)
                    {
                        if (isAttach)
                        {
                            if (version != null && version != ddr.CurrentVersion)
                                ToggleStatusBarPanel("pnlVersion", true);
                            LoadDocContents(myDM.GetDocument().Print(ddr,version).DocumentRow);
                        }
                        else
                            LoadDocContents(ddr);
                    }
                    else
                        HideContent(Properties.Resources.YouCannotPreviewThisTypeOfDocument);
                }
            }
        }

        private void InitDisplay(docDB.DocumentRow ddr, bool isAttach)
        {
            if (tabNoDoc.TabVisible)
            {
                if (lastDisplayTab != null && lastDisplayTab != tabNoDoc)
                    uiTab1.SelectedTab = lastDisplayTab;
                else
                    uiTab1.SelectedTab = tabDocument;
                tabNoDoc.TabVisible = false;
                uiTab1.ShowTabs = true;
            }
            pnlCommandBar.Closed = (ActionToolbarView != DocCommandBar.Enable);
            cmdDocViewer.Enabled = Janus.Windows.UI.InheritableBoolean.True;

            //if (isAttach)  //&& !ddr.IsDraft -removed on sept 17 2009
            //{
            //   // if (allowActionToolbar)
            //   //     uiCommandBar2.Enabled = true;
            //}
            //else
            //{
            //   //     if (allowActionToolbar)
            //   //         uiCommandBar2.Enabled = true;
            //}

            bool DocIsDraft = ddr.IsDraft;

            //Display or Hide Draft Message in statusbar
            ToggleStatusBarPanel("pnlDraft", DocIsDraft);

            //Display or Hide Draft Watermark, if preference set to display
            if (myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.AlwaysDisplayDraftDocMessage, true))
                btnDraftWatermark.Visible = DocIsDraft;

            //Enable/Disable MakeFinal command
            if (!isAttach && ddr.IsCheckedOutByNull() && (myDM.GetDocument().CanEdit(ddr) | myDM.AtMng.SecurityManager.CanOverride(myDM.FM.CurrentFileId, atSecurity.SecurityManager.Features.Document) == atSecurity.SecurityManager.ExPermissions.Yes))
                cmdMakeReadOnly.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmdMakeReadOnly.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            if (myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.AlwaysDisplayDraftDocMessage, true))
                btnDraftWatermark.Visible = DocIsDraft;
            else
                btnDraftWatermark.Visible = false;

            if (ddr.DocContentRow != null && myDM.GetDocContent().CanEdit(ddr.DocContentRow))
            {
                cmdCheckInCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                if (ddr.IsCheckedOutByNull())
                {
                    //DOC IS NOT CHECKED OUT
                    cmdRevise.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdUndoCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    if (ddr.IsDraft)
                    {
                        cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    }
                    else
                    {
                        cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    }

                }
                else
                {
                    //DOC IS CHECKED OUT TO USER
                    cmdRevise.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdUndoCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
            }
            else
            {
                //CANT EDIT, SO NO REVISE OR CHECKOUT POSSIBLE
                cmdRevise.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdCheckInCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            if (myDM.AtMng.SecurityManager.CanExecute(myDM.FM.CurrentFileId, atSecurity.SecurityManager.Features.DocVersion) != atSecurity.SecurityManager.ExPermissions.Yes)
            {
                cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            if (myDM.AtMng.SecurityManager.CanExecute(myDM.FM.CurrentFileId, atSecurity.SecurityManager.Features.ConvertDoc) != atSecurity.SecurityManager.ExPermissions.Yes)
            {
                cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

        }

        public void ToggleCheckout()
        {
            CheckoutToggle(displayedDoc);
        }

        private void CheckoutToggle(docDB.DocumentRow cbr)
        {
            if (cbr.IsCheckedOutByNull())
            {
                cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdUndoCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdUndoCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        private void LoadDocContents(docDB.DocumentRow ddr)
        {
            try
            {
                ReturnFocusTo = Win32.GetFocusControl();
                ToggleStatusBarPanel("pnlPreview", false);

                switch (ddr.DocContentRow.Ext.Trim().ToLower())
                {
                    case ".txt":
                        textControlCompose.Visible = true;
                        axEDOffice1.Visible = false;
                        ucWB1.Visible = false;
                        textControlCompose.ViewMode = TXTextControl.ViewMode.Normal;
                        if (!ddr.DocContentRow.IsContentsNull())
                            textControlCompose.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.PlainText);
                        break;
                    case ".docx":
                    case ".dot":
                    case ".dotx":
                    case ".rtf":
                    case ".doc":
                        if (ForceTextControl)
                        {
                            ToggleStatusBarPanel("pnlPreview", true);
                            axEDOffice1.Visible = false;
                            ucWB1.Visible = false;

                            switch (ddr.DocContentRow.Ext.Trim().ToLower())
                            {
                                case ".docx":
                                    textControlCompose.Visible = true;
                                    if (!ddr.DocContentRow.IsContentsNull())
                                        textControlCompose.Load(ddr.DocContentRow.Contents, TXTextControl.BinaryStreamType.WordprocessingML);
                                    break;
                                case ".rtf":
                                    try
                                    {
                                        textControlCompose.Visible = true;
                                        if (!ddr.DocContentRow.IsContentsNull())
                                            textControlCompose.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.RichTextFormat);

                                    }
                                    catch (Exception ximage)
                                    {
                                        TXTextControl.LoadSettings ls = new TXTextControl.LoadSettings();
                                        ls.LoadImages = false;
                                        ls.LoadHypertextLinks = false;
                                        textControlCompose.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.RichTextFormat, ls);
                                    }
                                    break;
                                case ".doc":
                                    textControlCompose.Visible = true;
                                    if (!ddr.DocContentRow.IsContentsNull())
                                        textControlCompose.Load(ddr.DocContentRow.Contents, TXTextControl.BinaryStreamType.MSWord);
                                    break;
                            }
                        }
                        else
                        {
                            DisplayOfficeDoc(ddr);
                        }
                        break;
                    case ".csv":
                    case ".xls":
                    case ".xlsx":
                        HideContent(Properties.Resources.TheSpreadsheetHasBeenClosedFromThisView);
                        btnLaunchExcel.Visible = true;
                        break;
                    case ".ppt":
                    case ".pptx":
                        DisplayOfficeDoc(ddr);
                        break;

                    case ".htm":
                    case ".html":
                      
                        ucWB1.Visible = true;
                        ucWB1.BringToFront();
                        axEDOffice1.Visible = false;
                        textControlCompose.Visible = false;
                        if (!ddr.DocContentRow.IsContentsNull())
                            ucWB1.WriteContent(ddr.DocContentRow.ContentsAsText);
                        ReturnFocus();

                        break;
                    case ".wp":
                    case ".wpd":
                    default:
                        string temp1 = WriteTempFile(ddr);

                        //display doc from tempfile
                        try
                        {
                            ucWB1.Url = new Uri(temp1);
                        }
                        catch (Exception x)
                        {
                            System.Diagnostics.Trace.WriteLine("ha gotcha");
                            System.Threading.Thread.Sleep(200);
                            ucWB1.Url = new Uri(temp1);
                        }
                        ucWB1.Visible = true;
                        axEDOffice1.Visible = false;
                        textControlCompose.Visible = false;
                        ReturnFocus();

                        break;
                }
            }
            catch (Exception x)
            {
                HideContent(String.Format(Properties.Resources.DocCantBeDisplayedTryExternalApp, x.Message));
                ActionToolbarView = DocCommandBar.Enable;
            }
        }

        private void ReturnFocus()
        {
            if (ReturnFocusTo != null)
            {
                if (this.ParentForm != null)
                {
                    if (Form.ActiveForm == this.ParentForm)
                    {
                        this.ParentForm.Activate();
                    }
                }
                ReturnFocusTo.Focus();
            }
        }

        private void DisplayOfficeDoc(docDB.DocumentRow ddr)
        {
            axEDOffice1.Visible = true;

            textControlCompose.Visible = false;

            ucWB1.Visible = false;
            string temp = WriteTempFile(ddr);

            //the next two lines are to fix the print twice in a row bug
            if (axEDOffice1.GetDocumentName() != null)
                axEDOffice1.CloseDoc();

            axEDOffice1.Open(temp);
            axEDOffice1.ProtectDoc(3);
            axEDOffice1.ShowMenubar(false);
            axEDOffice1.Toolbars = false;

            ReturnFocus();
        }

        public void PreviewAsync()
        {
            timPreview.Stop();
            timPreview.Start();
        }

        public void ApplySecurity(DataRow dr)
        {
            docDB.DocumentRow cbr = (docDB.DocumentRow)dr;
            if (dr != null)
            {
                if (myDM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No)
                {
                    //CLIENT READONLY
                    UIHelper.EnableControls(documentBindingSource, false);
                    UIHelper.EnableControls(docContentBindingSource, false);
                    UIHelper.EnableControls(documentDocContentBindingSource, false);
                    isLawmailUICheckBox.Enabled = false; //can never be modified;
                    tbSubjectDoc.Enabled = false;
                    tbSubjectMail.Enabled = false;
                    tbFrom.Enabled = false;
                    tbTo.Enabled = false;
                    tbCC.Enabled = false;
                    ucRecipientTextBoxFrom.IsReadOnly = true;
                    ucRecipientTextBoxTo.IsReadOnly = true;
                    ucRecipientTextBoxCc.IsReadOnly = true;
                    efSubjectEditBox.ReadOnly = true;
                    efSubjectEditBox.BackColor = SystemColors.Control;
                    efDateCalendarCombo.ReadOnly = true;
                    efDateCalendarCombo.BackColor = SystemColors.Control;
                    efTypeucMultiDropDown.ReadOnly = true;
                    commModeucMultiDropDown.ReadOnly = true;

                    buttonFrom.Enabled = false;
                    buttonTo.Enabled = false;
                    buttonCC.Enabled = false;
                    //uiCommandBar1.Enabled = false;
                    foreach(Janus.Windows.UI.CommandBars.UICommand cmd in uiCommandBar1.Commands )
                    {
                        cmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    }
                    cmdPrint.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdPrintPreview.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdPrint1.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdExternalApp.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdExternalApp1.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    
                }
                else
                {
                    //uiCommandBar1.Enabled = true;
                    bool canEditDoc = myDM.GetDocument().CanEdit(cbr);
                    bool canEditDocContent = myDM.GetDocContent().CanEdit(cbr.DocContentRow);
                    UIHelper.EnableControls(documentBindingSource, canEditDoc);
                    UIHelper.EnableControls(docContentBindingSource, canEditDocContent);
                    UIHelper.EnableControls(documentDocContentBindingSource, canEditDocContent);

                    isLawmailUICheckBox.Enabled = false; //can never be modified;

                    tbSubjectDoc.Enabled = true;
                    tbSubjectMail.Enabled = true;
                    tbFrom.Enabled = true;
                    tbTo.Enabled = true;
                    tbCC.Enabled = true;

                    bool canEditRecipients = canEditDoc;
                    if (cbr.isLawmail)
                        canEditRecipients = false;

                    ucRecipientTextBoxFrom.IsReadOnly = !canEditRecipients;
                    ucRecipientTextBoxTo.IsReadOnly = !canEditRecipients;
                    ucRecipientTextBoxCc.IsReadOnly = !canEditRecipients;

                    efSubjectEditBox.ReadOnly = !canEditRecipients;
                    efSubjectEditBox.BackColor = (efSubjectEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
                    efDateCalendarCombo.ReadOnly = !canEditRecipients;
                    efDateCalendarCombo.BackColor = (efDateCalendarCombo.ReadOnly) ? SystemColors.Control : SystemColors.Window;

                    efTypeucMultiDropDown.ReadOnly = !canEditDoc;
                    commModeucMultiDropDown.ReadOnly = !canEditDoc;

                    buttonFrom.Enabled = canEditRecipients;
                    buttonTo.Enabled = canEditRecipients;
                    buttonCC.Enabled = canEditRecipients;
                }
            }
        }

        bool IsReadOnly = false;
        public void ReadOnly(bool makeReadOnly)
        {
            IsReadOnly = makeReadOnly;

            if (makeReadOnly)
            {
                UIHelper.EnableControls(documentBindingSource, !makeReadOnly);
                UIHelper.EnableControls(docContentBindingSource, !makeReadOnly);
                UIHelper.EnableControls(documentDocContentBindingSource, !makeReadOnly);
                ActionToolbarView = DocCommandBar.Disable;
                ucRecipientTextBoxFrom.IsReadOnly = makeReadOnly;
                ucRecipientTextBoxTo.IsReadOnly = makeReadOnly;
                ucRecipientTextBoxCc.IsReadOnly = makeReadOnly;
            }
            else
                Preview();
        }

        public void Cancel()
        {
            UIHelper.Cancel(documentBindingSource);
            UIHelper.Cancel(docContentBindingSource);
            DisplayContents(DocRecord, false, false);
        }

        private void LoadLabels()
        {
            cmdDocViewer.Text = String.Format(Properties.Resources.AppDocViewer, myDM.AtMng.AppMan.AppName);
            cmdDocViewer.ToolTipText = String.Format(Properties.Resources.AppDocViewerTooltip, myDM.AtMng.AppMan.AppName);

            //JL 2017-10-23 Hide checkincheckout if CVB
            if (myDM.AtMng.GetSetting(atriumBE.AppBoolSetting.isCVB))
                cmdCheckInCheckOut.Visible = Janus.Windows.UI.InheritableBoolean.False;
        }

        private void timPreview_Tick(object sender, EventArgs e)
        {
            try
            {
                timPreview.Stop();
                Preview();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public string PreviewHitHighlight(string fullText)
        {
            docDB.DocumentRow dr = DocRecord;
            displayedDoc = dr;

            if (dr == null)
                return "";
            FlipPanelsNoDisplayOfContent(false, true);
            uiPanelManager1.SuspendPanelLayout();
            InitDocRecordDep(dr);
            uiPanelManager1.ResumePanelLayout();
            isHighlight = false;

            if (fullText != null && fullText.Length > 0)
            {
                if (DocRecord.ext.ToLower() == ".pdf")
                {

                    if (DocRecord.DocContentRow == null)
                        myDM.GetDocContent().Load(DocRecord.DocRefId, DocRecord.CurrentVersion);

                    string temp1 = WriteTempFile(DocRecord);
                    //fix up fulltext string for adobe
                    fullText = fullText.ToLower();
                    fullText = fullText.Replace(" and ", " ");
                    fullText = fullText.Replace(" or ", " ");
                    fullText = fullText.Replace(" near ", " ");
                    fullText = fullText.Replace("*", "");
                    fullText = fullText.Replace("&", " ");
                    fullText = fullText.Replace("#", " ");
                    fullText = fullText.Replace("\"", "");

                    temp1 += "#search=\"" + fullText + "\"";
                    //display doc from tempfile
                    try
                    {
                        ucWB1.Url = new Uri(temp1);
                    }
                    catch (Exception x)
                    {
                        System.Threading.Thread.Sleep(200);
                        ucWB1.Url = new Uri(temp1);
                    }
                }
                else
                {
                    isHighlight = true;
                    string hiliteFull = myDM.HitHilite(DocRecord.DocRefId, fullText, false, DocRecord.CurrentVersion);//fullText.Replace("\"","")
                    if (hiliteFull != null)
                    {
                        hiliteFull = hiliteFull.Replace("<a href", "<a style='display:none' href");
                        hiliteFull = hiliteFull.Replace("<font color=\"#FF0000\">", "");
                        hiliteFull = hiliteFull.Replace("</font>", "");

                        //Hit Highlight Preference - update b style in <style> tag of qfullhit doc
                        hiliteFull = hiliteFull.Replace("b{background-color:steelblue;color:#ffffc0;padding:1px 3px 1px 3px;}", "b{background-color:" + UIHelper.ArgbColorToHtml(myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.hhBackground, Color.Yellow.ToArgb())) + ";color:" + UIHelper.ArgbColorToHtml(myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.hhForeground, Color.Red.ToArgb())) + ";padding:1px 3px 1px 3px;}");

                        ucWB1.WriteContent(hiliteFull);
                    }
                }

                axEDOffice1.Visible = false;
                textControlCompose.Visible = false;
                ucWB1.Visible = true;
            }
            return "";
        }

        private string GetSummaryResult(string fullText)
        {
            if (DocRecord == null)
                return "";

            string hiliteSummary = myDM.HitHilite(DocRecord.DocRefId, fullText, true, DocRecord.CurrentVersion);
            if (hiliteSummary != null)
            {
                hiliteSummary = hiliteSummary.Replace("<P>", "<p style='border:1px solid steelblue;background-color:#f0f0f0;padding:2px;'>...");
                hiliteSummary = hiliteSummary.Replace("<HR>", "");
                hiliteSummary = hiliteSummary.Replace("<font color=\"#FF0000\">", "");
                hiliteSummary = hiliteSummary.Replace("</font>", "");
                hiliteSummary = hiliteSummary.Replace("0.75em", "0.7em");
                int ancInc = 0;
                while (hiliteSummary.IndexOf("<B>") != -1)
                {
                    int pos = hiliteSummary.IndexOf("<B>");
                    hiliteSummary = hiliteSummary.Remove(pos, 3);
                    hiliteSummary = hiliteSummary.Insert(pos, "<A  href=\"CiTag" + ancInc + "\" name=\"CiTag" + ancInc + "\"><strong>");
                    ancInc++;
                }
                hiliteSummary = hiliteSummary.Replace("</B>", "</strong></A>");
                return hiliteSummary;
            }
            return "";
        }

        HtmlElement SelectedHit;
        int AncInCollection;
        public int HitHighlightDocLoaded()
        {
            AncInCollection = 0;
            if (ucWB1.webBrowser1.Document != null)
            {
                foreach (HtmlElement elmt in ucWB1.webBrowser1.Document.GetElementsByTagName("a"))
                {
                    if (elmt.Name.StartsWith("CiTag"))
                        AncInCollection++;
                }

                if (ucWB1.webBrowser1.Document.All.GetElementsByName("CiTag0").Count > 0)
                    HighlightSelectedHit("CiTag0");
            }
            return AncInCollection;
        }

        public void HighlightSelectedHit(string HitName)
        {
            HtmlElementCollection elm = ucWB1.webBrowser1.Document.All.GetElementsByName(HitName);
            if (elm.Count == 0)
                elm = ucWB1.webBrowser1.Document.All.GetElementsByName("CiTag-1");
            SelectedHit = elm[0];
            if (SelectedHit != null)
            {
                SelectedHit.ScrollIntoView(true);
                SelectedHit.Focus();
                foreach (HtmlElement elmt in ucWB1.webBrowser1.Document.GetElementsByTagName("b"))
                {
                    elmt.Style = null;
                }
                SelectedHit.NextSibling.Style = "background-color:navy;color:white;";
            }
        }

        public int NextPreviousHitFullText(bool IsNextHit)
        {
            if (SelectedHit != null)
            {
                HtmlElementCollection AnchorCollection = ucWB1.webBrowser1.Document.All.GetElementsByName(SelectedHit.Name);
                if (AnchorCollection.Count > 0)
                {
                    string currentId = ucWB1.webBrowser1.Document.All.GetElementsByName(SelectedHit.Name)[0].Name.Substring(5);
                    int counter = Convert.ToInt32(currentId);
                    if (IsNextHit)
                    {
                        if (counter == AncInCollection - 1)
                            return -1;
                        else
                            counter++;
                    }
                    else
                    {
                        if (counter == 0)
                            return -1;
                        else
                            counter--;
                    }
                    HighlightSelectedHit("CiTag" + counter.ToString());
                    return counter + 1;
                }
            }
            return -1;
        }

        public int SelectLastHitOfDocument()
        {
            foreach (HtmlElement elmt in ucWB1.webBrowser1.Document.GetElementsByTagName("b"))
            {
                elmt.Style = null;
            }
            HtmlElementCollection AnchorCollection = ucWB1.webBrowser1.Document.GetElementsByTagName("a");
            if (AnchorCollection.Count > 2)
            {
                HighlightSelectedHit(AnchorCollection[AnchorCollection.Count - 2].Name);
                return AncInCollection;
            }
            return -1;
        }

        bool toPrint = false;
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (toPrint)
            {
                ucWB1.Print();
                LoadDocContents(displayedDoc);
            }
            toPrint = false;
            if (DocumentCompleted != null)
                DocumentCompleted(this, e);
        }

        private void btnMessageRead_Click(object sender, EventArgs e)
        {
            Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;

            FlipPanelsNoDisplayOfContent(false, true);
            if (btn.Name == "btnMessageRead")
            {
                docDB.DocumentRow edr = (docDB.DocumentRow)btn.Tag;
                DisplayContents(edr, false, false);
            }
            else
            {
                docDB.AttachmentRow attch = (docDB.AttachmentRow)btn.Tag; //changed to Attachement so we can access version CJW 2015-4-21
                string version = null;
                if (!attch.IsVersionNull())
                    version = attch.Version;
                DisplayContents(attch.DocumentRowByDocument_Attachment1, true, false,version);
            }
        }

        public string WriteTempFile(docDB.DocumentRow ddr)
        {
            TempFile = myDM.GetDocContent().WriteTempFile(ddr, true);
            return TempFile;
        }

        private void textControlCompose_ImageCreated(object sender, TXTextControl.ImageEventArgs e)
        {
            try
            {
                if (e.Image.FilterIndex == 0)
                    e.Image.FilterIndex = textControlCompose.Images.ExportFilters[3];
            }
            catch (Exception x)
            {
                //JLL: we should display some form of message to advise user of a potential error with the display of an image
                //UIHelper.HandleUIException(x);
            }
        }

        private void documentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ApplySecurity(DocRecord);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (displayedDoc == null)
                return;
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdMakeReadOnly":
                        DoMakeFinal();
                        break;
                    case "cmdPrint":
                        Print();
                        break;
                    case "cmdDocViewer":
                        fDocView fd = new fDocView(myDM, displayedDoc);
                        fd.Show(this.ParentForm);
                        break;
                    case "cmdExternalApp":
                        if (displayedDoc.DocContentRow == null)
                        {
                            myDM.GetDocContent().Load(displayedDoc.DocRefId, displayedDoc.CurrentVersion);
                        }
                        UIHelper.LaunchNativeN(myDM.GetDocContent().WriteTempFile(displayedDoc, true), this, "");
                        break;
                    case "cmdRevise":
                        AdviseDocActionSubscribers(displayedDoc, DocActionEnum.Revise);
                        break;
                    case "cmdCopyClipboard":
                        if (displayedDoc.DocContentRow == null)
                        {
                            myDM.GetDocContent().Load(displayedDoc.DocRefId, displayedDoc.CurrentVersion);
                        }
                        WriteTempFile(displayedDoc);
                        System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
                        sc.Add(TempFile);
                        Clipboard.SetFileDropList(sc);
                        break;
                    case "cmdCopyNoOpen": //browse
                        if (fileBrowser == null)
                            fileBrowser = new fBrowse(myDM.AtMng, 0, false, false, false, true);

                        fileBrowser.FindFile(displayedDoc.FileId);
                        if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            CreateDocumentCopy(fileBrowser.FileId, DocActionEnum.CopyOnly);
                        }
                        break;
                    case "cmdCopyOpen": //browse
                        if (fileBrowser == null)
                            fileBrowser = new fBrowse(myDM.AtMng, 0, false, false, false, true);

                        fileBrowser.FindFile(displayedDoc.FileId);
                        if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            CreateDocumentCopy(fileBrowser.FileId, DocActionEnum.CopyAndOpen);
                        }
                        break;
                    case "cmdDocShortcut":
                        UIHelper.CreateNewDocXRef(myDM.AtMng, displayedDoc);
                        break;
                    case "cmdCheckOut":
                        UIHelper.DocumentCheckOutAction(DocCheckOutActionEnum.CheckOut, displayedDoc, myDM, this);
                        break;
                    case "cmdCheckIn":
                        UIHelper.DocumentCheckOutAction(DocCheckOutActionEnum.CheckIn, displayedDoc, myDM, this);
                        if (myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.ReviseDocOnDocCheckIn, false))
                            AdviseDocActionSubscribers(displayedDoc, DocActionEnum.Revise);
                        break;
                    case "cmdUndoCheckOut":
                        UIHelper.DocumentCheckOutAction(DocCheckOutActionEnum.UndoCheckOut, displayedDoc, myDM, this);
                        break;
                    case "cmdCopyText":
                        if (ucWB1.Visible)
                            ucWB1.CopyText();
                        else if (textControlCompose.Visible)
                        {
                            textControlCompose.Focus();
                            textControlCompose.Copy();
                        }
                        break;
                    case "cmdSelectAllText":
                        if (ucWB1.Visible)
                            ucWB1.SelectAllText();
                        else if (textControlCompose.Visible)
                        {
                            textControlCompose.Focus();
                            textControlCompose.SelectAll();
                        }
                        break;
                    case "cmdViewVersionHistory":
                        fVersionHistory fVerHis = new fVersionHistory(myDM, displayedDoc);
                        if (fVerHis.VersionCount > 0)
                        {
                            fVerHis.ShowDialog();
                            Preview();
                        }

                        break;
                    case "cmdConvertToPDF":
                        SaveAs(".pdf");
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AdviseDocActionSubscribers(docDB.DocumentRow dr, DocActionEnum docAction)
        {
            DocActionEventArgs daea = new DocActionEventArgs();
            daea.Action = docAction;
            daea.DocRecord = dr;
            if (DocAction != null)
                DocAction(this, daea);
        }

        private void Printout()
        {
            if (textControlCompose.Visible)
            {
                textControlCompose.Print(DocRecord.efSubject);
            }
            else if (axEDOffice1.Visible)
            {
                axEDOffice1.PrintDialog();
            }
            else if (ucWB1.Visible)
            {
                ucWB1.Print();
            }
        }

        public void PrintPreview()
        {
            if (textControlCompose.Visible)
                textControlCompose.PrintPreview(DocRecord.efSubject);
            else if (axEDOffice1.Visible)
                axEDOffice1.PrintPreview();
            else if (ucWB1.Visible)
                ucWB1.PrintPreview();
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == 2)
                {
                    System.Reflection.FieldInfo fi = typeof(System.Windows.Forms.AxHost).GetField("oleSite", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    object o2 = fi.GetValue(axEDOffice1);
                    GC.SuppressFinalize(o2);
                }
            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine(x.Message);
            }
            base.WndProc(ref m);
        }

        public void Print()
        {
            if (isHighlight)
            {
                Printout();
            }
            else
            {
                bool origForce = ForceTextControl;

                ForceTextControl = false;
                docDB.DocContentRow po = myDM.GetDocument().Print(displayedDoc);
                LoadDocContents(po.DocumentRow);

                if (po.Ext.ToLower() == ".htm" || po.Ext.ToLower() == ".html")
                {
                    toPrint = true;
                    ForceTextControl = origForce;
                }
                else
                {
                    Printout();
                    ForceTextControl = origForce;

                    LoadDocContents(displayedDoc);
                }
            }
        }

        public void SaveAs(string format)
        {
            bool origForce = ForceTextControl;

            ForceTextControl = false;

            DisplayContents(displayedDoc, false, false);

            string v = axEDOffice1.GetOfficeVersion();

            //jll: problem still exists where saveas ext set to docx and converting doc from format that does not use Officer Viewer Control
            //e.g. converting from pdf to docx fails since string v above returns empty string which causes v.substring check below to throw an exception

            if (format == ".docx" && System.Convert.ToInt32(v.Substring(0, 2)) < 12)
                format = ".doc";

            DocRecord.DocContentRow.Ext = format;
            TextToRecord();
            ForceTextControl = origForce;

            LoadDocContents(displayedDoc);

            DisplayContents(displayedDoc, false, false);
        }

        private void TextToRecord()
        {
            //only for save as .pdf

            //write data back to record
            if (DocRecord == null)
                return;
            docDB.DocContentRow dr = DocRecord.DocContentRow;


            if (dr != null)
            {
                // 2013-06-12 JLL: update to use isDraft only
                //if (dr.ReadOnly)
                if (dr.RowState != DataRowState.Added && !(bool)DocRecord["IsDraft", DataRowVersion.Original])
                {
                    //MessageBox.Show(Properties.Resources.YouCantSaveAReadOnlyDocument);
                    return;
                }

                switch (dr.Ext.ToLower())
                {
                    case ".pdf":
                    case ".docx":
                    case ".doc":
                    case ".rtf":
                        EDOfficeLib.WdSaveFormat fmt = EDOfficeLib.WdSaveFormat.wdFormatDocument;
                        switch (dr.Ext.ToLower())
                        {
                            case ".pdf":
                                fmt = EDOfficeLib.WdSaveFormat.wdFormatPDF;
                                break;
                            case ".docx":
                                fmt = EDOfficeLib.WdSaveFormat.wdFormatXMLDocument;
                                break;
                            case ".doc":
                                fmt = EDOfficeLib.WdSaveFormat.wdFormatDocument;
                                break;
                            case ".rtf":
                                fmt = EDOfficeLib.WdSaveFormat.wdFormatRTF;
                                break;
                            case ".htm":
                            case ".html":
                                fmt = EDOfficeLib.WdSaveFormat.wdFormatHTML;
                                break;
                        }

                        //fix extension in case it was changed
                        if (dr.Ext != System.IO.Path.GetExtension(TempFile))
                        {
                            TempFile = System.IO.Path.ChangeExtension(TempFile, dr.Ext);
                            TempFile = atriumBE.DocContentBE.GetUniqueTempFileName(System.IO.Path.GetDirectoryName(TempFile), TempFile);
                        }

                        axEDOffice1.SaveAs(TempFile, fmt);

                        System.IO.FileStream fs = new FileStream(TempFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        System.IO.BinaryReader br = new BinaryReader(fs);
                        dr.Contents = br.ReadBytes((int)fs.Length);

                        br.Close();
                        break;
                    case ".htm":
                    case ".html":
                        string contentsTxt1;
                        textControlCompose.Save(out contentsTxt1, TXTextControl.StringStreamType.HTMLFormat);
                        dr.ContentsAsText = contentsTxt1;
                        break;

                    default:
                        string contentsTxt;
                        textControlCompose.Save(out contentsTxt, TXTextControl.StringStreamType.PlainText);
                        dr.ContentsAsText = contentsTxt;
                        break;
                }
            }

        }

        private void CreateDocumentCopy(int fmfileid, DocActionEnum docAction)
        {
            atriumBE.FileManager tempFM = myDM.AtMng.GetFile(fmfileid);
            docDB.DocumentRow docCopy = tempFM.GetDocMng().GetDocument().MakeCopy(displayedDoc, tempFM.CurrentFile, displayedDoc.IsDraft);
            AdviseDocActionSubscribers(docCopy, docAction);
        }

        private void uiCommandBar1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                if (e.Command.Commands.Count > 0)
                    e.Command.Expand();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void lnkEditCheckedOutDocument_Click(object sender, EventArgs e)
        {
            try
            {
                UIHelper.LaunchNativeN(displayedDoc.CheckedOutPath, this, "");
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void textControlCompose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control & !e.Alt & !e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.A:
                            textControlCompose.SelectAll();
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(new LMException(x.Message));
            }
        }

        private void uiStatusBar1_PanelClick(object sender, Janus.Windows.UI.StatusBar.StatusBarEventArgs e)
        {
            try
            {
                if (e.Panel.Key == uiStatusBar1.Panels["pnlPreview"].Key)
                {
                    UIHelper.LaunchNativeN(myDM.GetDocContent().WriteTempFile(displayedDoc, true), this, "");
                }
                if (e.Panel.Key == uiStatusBar1.Panels["pnlDraft"].Key)
                {
                    if (myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.AlwaysDisplayDraftDocMessage, true))
                        btnDraftWatermark.Visible = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiStatusBar1_PanelHover(object sender, Janus.Windows.UI.StatusBar.StatusBarEventArgs e)
        {
            try
            {
                if (e.Panel.Key == uiStatusBar1.Panels["pnlPreview"].Key)
                {
                    janusSuperTip1.Show(jstSettings);
                }
                else
                { janusSuperTip1.ClearToolTipArea(); }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ToggleStatusBarPanel(string PanelKey, bool ShowPanel)
        {
            uiStatusBar1.Panels["pnlFiller"].Visible = false;
            uiStatusBar1.Panels[PanelKey].Visible = ShowPanel;

            bool PreviewModeVisible = false;
            bool AtLeastOnePanelVisible = false;
            for (int i = 0; i < uiStatusBar1.Panels.Count; i++)
            {
                if (uiStatusBar1.Panels[i].Visible)
                {
                    AtLeastOnePanelVisible = true;
                    if (uiStatusBar1.Panels[i].ToString() == "pnlPreview")
                        PreviewModeVisible = true;
                }
            }
            if (AtLeastOnePanelVisible)
            {
                uiStatusBar1.Panels["pnlFiller"].Visible = true;
                pnlStatusBar.Closed = false;
            }
            else
                pnlStatusBar.Closed = true;

            if (PreviewModeVisible)
                janusSuperTip1.Show(jstSettings);
            else
                janusSuperTip1.ClearToolTipArea();
        }

        private void btnLoadLargeDoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    Application.UseWaitCursor = true;
                    bool isAttach = (bool)btnLoadLargeDoc.Tag;
                    FlipPanelsNoDisplayOfContent(false, true);
                    if (!myDM.AtMng.AppMan.ServerInfo.useProxy && !displayedDoc.IsDraft && !displayedDoc.FileFormatRow.IsEncodingNull())
                    {
                        string temp1 = myDM.AtMng.AppMan.ServerInfo.proxyUrl;
                        if (!temp1.EndsWith(@"/"))
                            temp1 += "/";

                        temp1 += "doc.aspx?docid=" + displayedDoc.DocId.ToString();
                        try
                        {
                            ucWB1.Url = new Uri(temp1);
                        }
                        catch (Exception x)
                        {
                            System.Diagnostics.Trace.WriteLine("ha gotcha");
                            System.Threading.Thread.Sleep(200);
                            ucWB1.Url = new Uri(temp1);
                        }
                        ucWB1.Visible = true;
                        axEDOffice1.Visible = false;
                        textControlCompose.Visible = false;
                        ReturnFocus();
                    }
                    else
                    {
                        DisplayContents(displayedDoc, isAttach, true);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally { Application.UseWaitCursor = false; }
        }

        private void SetFocusToSelectedViewer()
        {
            if (ucWB1.Visible)
                ucWB1.Focus();
            else if (textControlCompose.Visible)
                textControlCompose.Focus();
            else if (axEDOffice1.Visible)
                axEDOffice1.Focus();
        }

        private void DoMakeFinal()
        {
            if (DocRecord.IsDraft)
            {
                if (MessageBox.Show("This will make the document read-only.  This operation cannot be undone. \n\nAre you sure you want to continue?", "Finalize Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DocRecord.IsDraft = false;
                    cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    // 2013-06-12 JLL: update to use isDraft only
                    //DocRecord.DocContentRow.ReadOnly = true;
                }
            }
            else
            {
                if (MessageBox.Show("This will make the document read-write.  \n\nAre you sure you want to continue?", "Un-Finalize Document", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DocRecord.IsDraft = true;
                    cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
            }
            if (myDM.AtMng.SecurityManager.CanExecute(myDM.FM.CurrentFileId, atSecurity.SecurityManager.Features.DocVersion) != atSecurity.SecurityManager.ExPermissions.Yes)
            {
                cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            if (myDM.AtMng.SecurityManager.CanExecute(myDM.FM.CurrentFileId, atSecurity.SecurityManager.Features.ConvertDoc) != atSecurity.SecurityManager.ExPermissions.Yes)
            {
                cmdConvertToPDF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        private void btnDraftWatermark_Click(object sender, EventArgs e)
        {
            try
            {
                btnDraftWatermark.Visible = false;
                SetFocusToSelectedViewer();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucDocView_Resize(object sender, EventArgs e)
        {
            try
            {
                SetRecipientBoxHeight();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnLaunchExcel_Click(object sender, EventArgs e)
        {
            try
            {
                UIHelper.LaunchNativeN(myDM.GetDocContent().WriteTempFile(displayedDoc, true), this, "");
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void buttonFrom_Click(object sender, EventArgs e)
        {
            try
            {
                docDB.DocumentRow dr = DocRecord;

                fContactSelect fcs = new fContactSelect(myDM.FM, dr, true);
                fcs.ActiveOnly = true;
                fcs.ShowDialog(this);
                ucRecipientTextBoxFrom.Reload();
                ucRecipientTextBoxTo.Reload();
                ucRecipientTextBoxCc.Reload();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnExternalApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (displayedDoc.DocContentRow == null)
                {
                    myDM.GetDocContent().Load(displayedDoc.DocRefId, displayedDoc.CurrentVersion);
                }
                UIHelper.LaunchNativeN(myDM.GetDocContent().WriteTempFile(displayedDoc, true), this, "");
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucDocView_VisibleChanged(object sender, EventArgs e)
        {
            if (ShowAttachmentPanel & this.Visible)
            {
                const int DefaultAttachmentPanelHeight = 0;
                const int pnlHeightIncrement = 28;
           
                //if (flowLayoutPanel1.VerticalScroll.Visible)
                //{  
                    pnlAttachment.Height = DefaultAttachmentPanelHeight;
                    for (int i = 1; i <= 3; i++)
                    {
                        pnlAttachment.Height += pnlHeightIncrement;
                        if (!flowLayoutPanel1.VerticalScroll.Visible)
                            return;
                    }
                //}
            }
            if(this.Visible)
                Preview();
        }

    }
}