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
    public partial class ucDoc : UserControl
    {
        public event DocLoadedEventHandler DocLoaded;
        public event DocActionEventHandler DocAction;
        public event RecipientChangedEventHandler RecipientChanged;

        public bool isDirty = false;
        bool noDocDisplayed = false;

        public bool NoDocDisplayed
        {
            get { return noDocDisplayed; }
            set { noDocDisplayed = value; }
        }

        public Control ReturnFocusTo;
        public fBrowseDocs OpenDocDialog;
        private fBrowse fileBrowser;
        private Color bgColor = SystemColors.Control;  //Color.FromArgb(213, 228, 242);


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

        bool mbShowRecips = true;
        public bool ShowRecipients
        {
            get { return mbShowRecips; }
            set
            {
                mbShowRecips = value;
                pnlTo.Closed = !(ShowRecipients);
                pnlCC.Closed = !(ShowRecipients);
            }
        }

        bool mbShowFromAndDate = true;
        public bool ShowFromAndDate
        {
            get { return mbShowFromAndDate; }
            set
            {
                mbShowFromAndDate = value;
                pnlFromDate.Closed = !(mbShowFromAndDate);
            }

        }

        bool mbShowSubject = true;
        public bool ShowSubject
        {
            get { return mbShowSubject; }
            set
            {
                mbShowSubject = value;
                pnlSubject.Closed = !(ShowSubject);
            }

        }

        bool allowActionToolbar = true;
        public bool AllowActionToolbar
        {
            get { return allowActionToolbar; }
            set
            {
                allowActionToolbar = value;
                uiCommandBar2.Enabled = AllowActionToolbar;
                uiCommandBar2.Visible = AllowActionToolbar;
            }
        }

        bool mbShowComposeToolbar = false;
        public bool ShowComposeToolbar
        {
            get { return mbShowComposeToolbar; }
            set
            {
                mbShowComposeToolbar = value;
                if (displayedDoc != null)
                {
                    if (!displayedDoc.IsisLawmailNull() && displayedDoc.isLawmail && myEffectiveEditMode == EditModeEnum.Compose)
                    {
                        priorityJComboBox.Visible = true;
                        chkEncrypt.Visible = true;
                        VerifyIfMail(displayedDoc);
                    }
                    else
                    {
                        priorityJComboBox.Visible = false;
                        chkEncrypt.Visible = false;
                    }
                }
                btnInsert.Visible = mbShowComposeToolbar;
                if (mbShowComposeToolbar)
                    flowLayoutPanel1.Dock = DockStyle.None;
                else
                    flowLayoutPanel1.Dock = DockStyle.Fill;
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
                SizeAttachmentPanel(mbShowAttachmentPanel);
            }

        }

        bool mbShowTabs = false;
        public bool ShowTabs
        {
            get { return mbShowTabs; }
            set
            {
                mbShowTabs = value;
                if (ShowTabs)
                {
                    pnlMetaData.Closed = false;
                }
                else
                {
                    pnlMetaData.Closed = true;
                }
            }
        }

        bool mbForceTextControl = false;
        public bool ForceTextControl
        {
            get { return mbForceTextControl; }
            set { mbForceTextControl = value; }
        }

        bool mbAllowUserCompose = true;
        public bool AllowUserCompose
        {
            get { return mbAllowUserCompose; }
            set { mbAllowUserCompose = value; }
        }

        bool mbAllowRecipientSubjectEditWhenNotMail = false;
        public bool AllowRecipientSubjectEditWhenNotMail
        {
            get { return mbAllowRecipientSubjectEditWhenNotMail; }
            set { mbAllowRecipientSubjectEditWhenNotMail = value; }
        }

        public enum EditModeEnum
        {
            Read,
            Compose
        }

        bool isManageTemplates = false;
        public bool IsManageTemplates
        {
            get { return isManageTemplates; }
            set { isManageTemplates = value; }
        }

        EditModeEnum myEffectiveEditMode = EditModeEnum.Read;
        EditModeEnum myEditMode = EditModeEnum.Read;

        public EditModeEnum EditMode
        {
            get { return myEditMode; }
            set
            {
                if (mbAllowUserCompose)
                    myEditMode = value;

                ToggleReadOnly(EditMode);
            }
        }

        public bool ToPersonIsNullOnCompose
        {
            get { return !ucRecipientTextBoxTo.HasRecipients; }
        }

        private void EnableRecipientDateSubjectForEdit()
        {
            Size szCOMP = new Size(pnlBCC.Width, 27);

            ToggleEnableOfRecipientButtons(true, btnCC, ucRecipientTextBoxCc);
            ToggleEnableOfRecipientButtons(true, btnTo, ucRecipientTextBoxTo);
            ToggleEnableOfRecipientButtons(true, btnFrom, ucRecipientTextBoxFrom);

            calEfDate.Enabled = true;

            tbEfSubject.ReadOnly = false;
            tbEfSubject.BackColor = SystemColors.Window;
            tbEfSubject.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            tbEfSubject.Top = 2;
            efSubjectCounter.Visible = true;
            efSubjectCounter.Top = 2;
            tbEfSubject.ImageVerticalAlignment = Janus.Windows.GridEX.ImageVerticalAlignment.Center;
            pnlSubject.MinimumSize = szCOMP;
            pnlSubject.Size = szCOMP;
        }

        private void ToggleReadOnly(EditModeEnum editMode)
        {
            if (editMode == EditModeEnum.Compose)
            {
                //make form read-write
                ShowComposeToolbar = true;
                if (!isManageTemplates)
                    ShowAttachmentPanel = true;
                ShowFromAndDate = false;

                textControlCompose.EditMode = TXTextControl.EditMode.Edit;

                EnableRecipientDateSubjectForEdit();
            }
            else
            {
                //make form read-only
                ShowComposeToolbar = false;
                ShowFromAndDate = true;
                textControlCompose.EditMode = TXTextControl.EditMode.ReadAndSelect;
                Size szRO = new Size(pnlBCC.Width, 24);
                ToggleEnableOfRecipientButtons(false, btnCC, ucRecipientTextBoxCc);
                ToggleEnableOfRecipientButtons(false, btnTo, ucRecipientTextBoxTo);
                ToggleEnableOfRecipientButtons(false, btnFrom, ucRecipientTextBoxFrom);

                calEfDate.Enabled = false;
                tbEfSubject.ReadOnly = true;
                tbEfSubject.Top = 5;
                tbEfSubject.BackColor = bgColor;
                tbEfSubject.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
                tbEfSubject.ImageVerticalAlignment = Janus.Windows.GridEX.ImageVerticalAlignment.Near;
                efSubjectCounter.Visible = false;

                pnlSubject.MinimumSize = szRO;
                pnlSubject.Size = szRO;
            }
        }

        public event WebBrowserDocumentCompletedEventHandler DocumentCompleted;

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

        public void MetadataConfirmForFDoc()
        {
            ShowComposeToolbar = false;
            ShowAttachmentPanel = false;
            AllowRecipientSubjectEditWhenNotMail = true;
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
                uiCommandBar2.Enabled = !makeReadOnly;

                ucRecipientTextBoxFrom.IsReadOnly = makeReadOnly;
                ucRecipientTextBoxTo.IsReadOnly = makeReadOnly;
                ucRecipientTextBoxCc.IsReadOnly = makeReadOnly;
                ucRecipientTextBoxBcc.IsReadOnly = makeReadOnly;
            }
            else
                Preview();
        }

        public void Focus1()
        {
            tbEfSubject.Focus();
        }

        public void ApplySecurity(DataRow dr)
        {
            docDB.DocumentRow cbr = (docDB.DocumentRow)dr;
            if (dr != null)
            {
                UIHelper.EnableControls(documentBindingSource, myDM.GetDocument().CanEdit(cbr));
                UIHelper.EnableControls(docContentBindingSource, myDM.GetDocContent().CanEdit(cbr.DocContentRow));
                UIHelper.EnableControls(documentDocContentBindingSource, myDM.GetDocContent().CanEdit(cbr.DocContentRow));

                //make data label enabled 
                lblDateReadValue.Enabled = true;

                //show mail icon if IsLawMail
                if (cbr.isLawmail)
                {
                    // only accurate for non-compose mode type docs - senttime gets populated when mail is sent, not while composing
                    //if (cbr.IsSentTimeNull()) //sent internally
                    tbEfSubject.ImageIndex = 0;
                    // else //sent through external mail
                    //    tbEfSubject.ImageIndex = 1;

                    tbEfSubject.HasImage = true;
                    priorityJComboBox.Visible = true;
                }
                else
                {
                    tbEfSubject.HasImage = false;
                    chkEncrypt.Visible = false;
                    priorityJComboBox.Visible = false;
                }

                //make subject field read-only instead of disabled if cant edit
                if (!myDM.GetDocument().CanEdit(cbr))
                {
                    ucRecipientTextBoxFrom.IsReadOnly = true;
                    ucRecipientTextBoxTo.IsReadOnly = true;
                    ucRecipientTextBoxCc.IsReadOnly = true;
                    ucRecipientTextBoxBcc.IsReadOnly = true;

                    tbEfSubject.Enabled = true;
                    tbEfSubject.ReadOnly = true;
                }
                else
                {
                    tbEfSubject.Enabled = true;
                    tbEfSubject.ReadOnly = false;
                }

                chkIsDraft.Enabled = false;
                chkReadOnly.Enabled = false;
            }
        }

        atriumBE.DocManager myDM;

        private docDB.DocumentRow displayedDoc;
        private docDB.DocumentRow mainDoc;
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

        public void Cancel()
        {
            UIHelper.Cancel(documentBindingSource);
            UIHelper.Cancel(docContentBindingSource);
            DisplayContents(DocRecord, false, false);
        }

        private void LoadLabels()
        {
            cmdViewDDoc.Text = String.Format(Properties.Resources.AppDocViewer, myDM.AtMng.AppMan.AppName);
            cmdViewDDoc.ToolTipText = String.Format(Properties.Resources.AppDocViewerTooltip, myDM.AtMng.AppMan.AppName);
        }

        Janus.Windows.Common.SuperTipSettings jstSettings;
        private void LoadPriorityFieldValues()
        {
           // priorityJComboBox.ImageList = mainImgList;
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityNormal, 0, 4));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityHigh, 1, 2));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityUrgent, 2, 3));
        }
        public ucDoc()
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

            //These are set at runtime because the IDE always changes the french to english when changing languages at design time
            uiStatusBar1.Panels["PreviewMode"].Text = Properties.Resources.NoteAboutDocumentPreview;
            uiStatusBar1.Panels["PreviewMode"].Image = Properties.Resources.lightbulb;
            uiStatusBar1.Panels["DraftMessage"].Text = Properties.Resources.DraftDocument;
            uiStatusBar1.Panels["DraftMessage"].Image = Properties.Resources.DraftDocumentPNG;

            textControlCompose.ButtonBar = buttonBar1;
        
            LoadPriorityFieldValues();
            //  pageCounteditBox.BackColor = Color.Pink;
        }

        int DocSizeLimit;

        public void Init(atriumBE.DocManager dm)
        {
            myDM = dm;
            LoadLabels();
            timPreview.Stop();
            DocSizeLimit = myDM.AtMng.GetSetting(atriumBE.AppIntSetting.DocumentPreviewSize);
           
            if (myDM != null)
            {
                UIHelper.ComboBoxInit("DocType", mccCommType, myDM.FM);
                UIHelper.ComboBoxInit("CommMode", ucMultiDropDown2, myDM.FM);
                ucMultiDropDown1.SetDataBinding(myDM.FM.Codes("OfficerList"), "");
                if (myDM.AtMng.AppMan.Language.ToLower() == "fre")
                    btnDraftWatermark.Text = "Ébauche de document";
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
                isDirty = false;

                if (axEDOffice1.GetDocumentName() != null)
                {
                    axEDOffice1.CloseDoc();
                }
            }
            catch (Exception x)
            {
            }
        }

        public void NoAssociatedDocument(string message)
        {
            noDocDisplayed = true;
            timPreview.Stop();
            ReturnFocusTo = Win32.GetFocusControl();
            Clear();

            lblNoDocumentImg.Visible = (message.Length > 0);
            lblNoDocumentText.Text = message;

            pnlControlContainer.Closed = true;
            pnlNoDocument.Closed = false;
            uiCommandBar2.Visible = false;
        }

        public void NoDoc(string message)
        {
            noDocDisplayed = true;
            ReturnFocusTo = Win32.GetFocusControl();
            Clear();
            //pnlNoDoc.Closed = false;
            // JL - I did not comment this out as part of the switch to v.8 //axOfficeViewer1.Close();
            lblReason.Text = message;
            btnLoadLargeDoc.Visible = false;
            FlipPanelsNoDisplayOfContent(true, false);

            ReturnFocus();

        }

        private void FlipPanelsNoDisplayOfContent(bool hasNoDoc, bool enableActionBar)
        {
            pnlNoDocToDisplay.Closed = !hasNoDoc;
            pnlDocDisplay.Closed = hasNoDoc;
            uiCommandBar2.Enabled = enableActionBar;
        }

        public void Preview()
        {
            Application.UseWaitCursor = true;
            isHighlight = false;
            docDB.DocumentRow dr = DocRecord;

            if (dr == null)
            {
                Clear();
                //TAC Sept 5 2013 - Reset Cursor No Work Item 
                Application.UseWaitCursor = false;
                return;
            }

            FlipPanelsNoDisplayOfContent(false, true);

            pnlControlContainer.SuspendGroupLayout();
            InitDocRecordDep(dr);
            DisplayContents(dr, false, false);
            pnlControlContainer.ResumeGroupLayout();

            if (DocLoaded != null)
                DocLoaded(this, new DocLoadedEventArgs());

            Application.UseWaitCursor = false;
        }

        private void ToggleEnableOfRecipientButtons(bool enable, Button btn, ucRecipientTextBox ucRec)
        {
            if (enable)
            {
                btn.BackColor = System.Drawing.SystemColors.Control;
                btn.FlatStyle = FlatStyle.Standard;
                btn.FlatAppearance.BorderSize = 1;
                if (btn.Text.EndsWith(Properties.Resources.UIColon))
                    btn.Text = btn.Text.TrimEnd(':') + "...";
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.UseVisualStyleBackColor = true;
                ucRec.IsReadOnly = false;
                ucRec.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                if (btn.Text.EndsWith("..."))
                    btn.Text = btn.Text.TrimEnd('.') + Properties.Resources.UIColon;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                ucRec.IsReadOnly = true;
                ucRec.BorderStyle = BorderStyle.None;
            }

            btn.Enabled = enable;
        }

        public void AddRecip(string email)
        {
            ucRecipientTextBoxTo.Add(email);
        }

        private bool Initializing = false;
        private void InitDocRecordDep(docDB.DocumentRow ddr)
        {
            //Load Recipients and Display
            if (Initializing)
                return;
            Initializing = true;

            try
            {
                InitDisplay(ddr, false);
                docContentBindingSource.DataSource = new DataView(ddr.Table.DataSet.Tables["DocContent"], "DocId=" + ddr.DocRefId.ToString(), "", DataViewRowState.CurrentRows);

                //if not email - hide recipients
                switch (ddr.CommMode)
                {
                    case "DC":
                    case "N/A":
                        ShowRecipients = false;
                        break;
                    default:
                        if (!IsManageTemplates)
                        {
                            ShowRecipients = true;
                        }
                        else
                        {
                            ShowRecipients = false;
                        }
                        break;
                }


                //----------------------
                // Can this block be moved inside the above 'if' statement; i.e. only load when we show?
                //----------------------

                //if (ddr.GetRecipientRows().Length == 0)
                //    myDM.GetRecipient().LoadByDocId(ddr.DocId);

                ucRecipientTextBoxFrom.Init(myDM, ddr);
                ucRecipientTextBoxTo.Init(myDM, ddr);
                ucRecipientTextBoxCc.Init(myDM, ddr);
                NoRecipientCcBcc_ClosePanel();

                //----------------------
                // end block move comment
                //----------------------

                btnMessageRead.Tag = ddr;

                // Load Attachments
                ShowAttachmentPanel = false;

                // Remove attachment buttons & events from previously displayed doc, if any
                int iAtt = flowLayoutPanel1.Controls.Count - 1;
                for (int i = 1; i <= iAtt; i++)
                {
                    if (flowLayoutPanel1.Controls[1].Name.StartsWith("Delete"))
                        flowLayoutPanel1.Controls[1].Click -= new System.EventHandler(this.btnAttachmentDelete_Click);
                    else
                        flowLayoutPanel1.Controls[1].Click -= new System.EventHandler(this.btnMessageRead_Click);

                    flowLayoutPanel1.Controls.RemoveAt(1);
                }

                foreach (docDB.AttachmentRow attch in ddr.GetAttachmentRowsByDocument_Attachment())
                {
                    AddAtt(attch);
                }

                SizeAttachmentPanel(ShowAttachmentPanel);
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

        private void SizeAttachmentPanel(bool AttachmentPanelDisplayed)
        {
            if (AttachmentPanelDisplayed)
            {
                int vHeight;
                if (flowLayoutPanel1.Height < 75 && flowLayoutPanel1.VerticalScroll.Visible)
                    vHeight = 75;
                else
                {
                    if (myEffectiveEditMode == EditModeEnum.Compose)
                        vHeight = 36;// 52;
                    else
                        vHeight = 36;
                }

                pnlAttachment.MinimumSize = new Size(-1, vHeight);
                pnlAttachment.MaximumSize = new Size(-1, vHeight);
                pnlAttachment.Size = new Size(pnlAttachment.Width, vHeight);
            }
        }

        private void NoRecipientCcBcc_ClosePanel()
        {
            if (myEditMode == EditModeEnum.Read)
            {
                if (!ucRecipientTextBoxTo.HasRecipients)
                    pnlTo.Closed = true;
                else
                    pnlTo.Closed = false;
            }
            if (!ucRecipientTextBoxCc.HasRecipients)
                pnlCC.Closed = true;
            else
                pnlCC.Closed = false;
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
                btn.WordWrap = false;
                string ext = "";
                if (!attr.IsextNull() || (attr.DocContentRow != null && !attr.DocContentRow.IsExtNull()))
                {
                    ext = attr.IsextNull() ? attr.DocContentRow.Ext : attr.ext;
                }
                btn.Width = System.Windows.Forms.TextRenderer.MeasureText(attr.efSubject + ext, btn.Font).Width + 30;
                btn.ShowFocusRectangle = false;
                btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
                btn.UseThemes = true;
                btn.HighlightActiveButton = false;

                btn.Tag = attch;  //use attachment in tag so we have access to version CJW 2015-4-21

                btn.Text = attr.efSubject + ext;
                if (attr.IsDraft)
                {
                    btn.Font = new Font(btn.Font, FontStyle.Underline);
                }
                else
                {
                }
                btn.Click += new System.EventHandler(this.btnMessageRead_Click);
                uiCommandManager1.SetContextMenu(btn, uiContextMenuViewAttachment);

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

                //allow user to remove inserted attachment from user interface if new message
                if (EditMode == EditModeEnum.Compose && (attch.RowState == DataRowState.Added || attch.DocumentRowByDocument_Attachment.IsDraft))
                {
                    Janus.Windows.EditControls.UIButton delBtn = new Janus.Windows.EditControls.UIButton();
                    delBtn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
                    delBtn.Name = "Delete" + attch.Id.ToString();
                    delBtn.Image = Properties.Resources.delete;
                    delBtn.Tag = attch;
                    delBtn.Width = Properties.Resources.delete.Width + 4;
                    delBtn.Click += new System.EventHandler(this.btnAttachmentDelete_Click);
                    flowLayoutPanel1.Controls.Add(delBtn);
                    delBtn.ToolTipText = Properties.Resources.UIRemoveAttachment + attr.efSubject + ext;
                    delBtn.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);

                    btn.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);

                }

                ShowAttachmentPanel = true;
            }

        }

        private void DisplayContents(docDB.DocumentRow ddr, bool isAttach, bool load)
        {
            DisplayContents(ddr, isAttach, load, ddr.CurrentVersion);
        }
        private void DisplayContents(docDB.DocumentRow ddr, bool isAttach, bool load, string version)
        {
            if (ddr == null)
                return;

            displayedDoc = ddr;
            if (!isAttach)
                mainDoc = ddr;

            noDocDisplayed = false;
            Datasource = new DataView(ddr.Table, "Docid=" + ddr.DocId.ToString(), "", DataViewRowState.CurrentRows);
            docContentBindingSource.DataSource = new DataView(ddr.Table.DataSet.Tables["DocContent"], "DocId=" + ddr.DocRefId.ToString(), "", DataViewRowState.CurrentRows);

            if (this.ParentForm != null)
            {
                if (this.ParentForm.Name == "fBFList")
                {
                    cmdViewVersionHistory.Visible = Janus.Windows.UI.InheritableBoolean.False;
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
            }

            if (((!ddr.IsSizeNull() && ddr.Size > DocSizeLimit) | (ddr.DocContentRow != null && ddr.DocContentRow.Size > DocSizeLimit)) && !load && ddr.isElectronic)
            {
                int size = 0;
                if (ddr.IsSizeNull())
                    size = ddr.DocContentRow.Size;
                else
                    size = ddr.Size;
                NoDoc(String.Format(Properties.Resources.WarningThisDocumentIsLarge, size));
                btnLoadLargeDoc.Visible = true;
                btnLoadLargeDoc.Tag = isAttach;
            }
            else
            {
                if (ddr.isElectronic && ddr.DocContentRow == null && ddr.RowState != DataRowState.Added)
                {
                    myDM.GetDocContent().Load(ddr.DocRefId, version);
                }

                InitDisplay(ddr, isAttach);

                ToggleReadOnly(myEffectiveEditMode);

                if (!ddr.isLawmail && ddr.CommMode != "N/A" && ddr.CommMode != "DC" && !IsManageTemplates)
                    ShowFromAndDate = true;

                if (ddr.CommMode == "N/A" && !isAttach)
                    ShowAttachmentPanel = false;

                if (axEDOffice1.GetDocumentName() != null)
                    axEDOffice1.CloseDoc();

                textControlCompose.ResetContents();
                isDirty = false;
                buttonBar1.Visible = false;

                if (textControlCompose.Top == 32)
                {
                    textControlCompose.Top = 4;
                    textControlCompose.Height += 28;
                }
                else
                {
                    textControlCompose.Top = 4; //no change to height
                }

                if (!ddr.isElectronic)
                {
                    //do not display
                    textControlCompose.Visible = false;
                    axEDOffice1.Visible = false;
                    ucWB1.Visible = false;
                    NoDoc(Properties.Resources.ThereIsNoElectronicVersionOfTheDocument);
                }
                else
                {
                    if (!ddr.IsCheckedOutByNull())
                    {
                        pnlDocCheckInCheckOut.Closed = false;
                        lnkEditCheckedOutDocument.Visible = (ddr.CheckedOutBy == myDM.AtMng.OfficerLoggedOn.OfficerId);
                    }
                    else
                    {
                        pnlDocCheckInCheckOut.Closed = true;
                        lnkEditCheckedOutDocument.Visible = false;
                    }

                    if (ddr.DocContentRow.FileFormatRow != null && ddr.DocContentRow.FileFormatRow.AllowPreview)
                    {
                        if (isAttach)
                        {
                            //check for and load recips
                            LoadDocContents(myDM.GetDocument().Print(ddr, version).DocumentRow);
                        }
                        else
                            LoadDocContents(ddr);
                    }
                    else
                        NoDoc(Properties.Resources.YouCannotPreviewThisTypeOfDocument);
                }

                //Allow Metadata update for recipients and subject if Doc is not IsLawMail
                if (!isAttach && !ddr.isLawmail && mbAllowRecipientSubjectEditWhenNotMail)
                    EnableRecipientDateSubjectForEdit();
            }
            isDirty = false;
        }

        private void InitDisplay(docDB.DocumentRow ddr, bool isAttach)
        {
            //JLL: This the right place for these 4 lines?
            pnlControlContainer.Closed = false;
            pnlNoDocument.Closed = true;
            uiCommandBar2.Visible = AllowActionToolbar;
            cmdViewDDoc.Enabled = Janus.Windows.UI.InheritableBoolean.True;

            //make read-only if displaying an attachment
            if (isAttach)  //&& !ddr.IsDraft -removed on sept 17 2009
            {
                myEffectiveEditMode = EditModeEnum.Read;
                if (allowActionToolbar)
                    uiCommandBar2.Enabled = true;
            }
            else
            {
                if ((myDM.GetDocContent().CanEdit(ddr.DocContentRow) || myDM.GetDocument().CanEdit(ddr))
                    && EditMode == EditModeEnum.Compose)
                {
                    myEffectiveEditMode = EditModeEnum.Compose;
                    uiCommandBar2.Enabled = false;
                }
                else
                {
                    myEffectiveEditMode = EditModeEnum.Read;
                    if (allowActionToolbar)
                        uiCommandBar2.Enabled = true;
                }
            }
            cmdDisplayName.Text = ddr.efSubject + ddr.ext;

            bool DocIsDraft = (ddr.IsDraft && myEffectiveEditMode == EditModeEnum.Read);

            //Display or Hide Draft Message in statusbar
            ToggleStatusBarPanel("DraftMessage", DocIsDraft);

            //Display or Hide Draft Watermark, if preference set to display
            if (myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.AlwaysDisplayDraftDocMessage, true))
                btnDraftWatermark.Visible = DocIsDraft;
            else
                btnDraftWatermark.Visible = false;

            //Enable/Disable MakeFinal command
            if (!isAttach && ddr.IsCheckedOutByNull() && DocIsDraft && myDM.GetDocContent().CanEdit(ddr.DocContentRow) && myDM.GetDocument().CanEdit(ddr))
                cmdMakeFinal.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmdMakeFinal.Enabled = Janus.Windows.UI.InheritableBoolean.False;

          
            if (myDM.GetDocContent().CanEdit(ddr.DocContentRow))
            {
                cmdDocCheckOutCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                if (ddr.IsCheckedOutByNull())
                {
                    //DOC IS NOT CHECKED OUT
                    cmdReviseDocument.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdDocCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdUndoDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    if (ddr.IsDraft)
                    {
                        cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    }
                    else
                    {
                        cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    }
                }
                else
                {
                    //DOC IS CHECKED OUT TO USER
                    cmdReviseDocument.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdDocCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdUndoDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
            }
            else
            {
                //CANT EDIT, SO NO REVISE OR CHECKOUT POSSIBLE
                cmdReviseDocument.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdDocCheckOutCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.False;
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
                cmdDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdDocCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdUndoDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                cmdDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdDocCheckIn.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdUndoDocCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        private void LoadDocContents(docDB.DocumentRow ddr)
        {
            try
            {
                ReturnFocusTo = Win32.GetFocusControl();
                ToggleStatusBarPanel("PreviewMode", false);
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
                        //case ".mht":
                        if (ForceTextControl)
                        {
                            ToggleStatusBarPanel("PreviewMode", true);
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
                            //JLL: temporarily commented out 2012-07-16
                            //if (textControlCompose.HeadersAndFooters.Count > 0)
                            //{
                            //    textControlCompose.ViewMode = TXTextControl.ViewMode.PageView;
                            //}
                            //else
                            //    textControlCompose.ViewMode = TXTextControl.ViewMode.Normal;

                        }
                        else
                        {
                            DisplayOfficeDoc(ddr);
                        }
                        break;
                    case ".csv":
                    case ".xls":
                    case ".xlsx":
                        NoDoc(Properties.Resources.TheSpreadsheetHasBeenClosedFromThisView);
                        uiCommandBar2.Enabled = (myEffectiveEditMode != EditModeEnum.Compose);
                        cmdReviseDocument.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        cmdViewDDoc.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        break;
                    case ".ppt":
                    case ".pptx":
                        DisplayOfficeDoc(ddr);
                        break;

                    case ".htm":
                    case ".html":
                        if (IsManageTemplates && this.Enabled)
                        {
                            //load in txtcontrol as text for raw editting
                            textControlCompose.Visible = true;
                            axEDOffice1.Visible = false;
                            ucWB1.Visible = false;
                            textControlCompose.ViewMode = TXTextControl.ViewMode.Normal;
                            if (!ddr.DocContentRow.IsContentsNull())
                                textControlCompose.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.PlainText);


                        }
                        else if (ddr.RowState == DataRowState.Added) //we are in acwiz! false)// (ddr.IsDraft ||
                        {
                            textControlCompose.Visible = true;
                            textControlCompose.Top = 32;
                            textControlCompose.Height = textControlCompose.Height - 28;
                            buttonBar1.Visible = true;
                            buttonBar1.BringToFront();
                            axEDOffice1.Visible = false;
                            ucWB1.Visible = false;
                            textControlCompose.ViewMode = TXTextControl.ViewMode.Normal;
                            if (!ddr.DocContentRow.IsContentsNull())
                                textControlCompose.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.HTMLFormat);

                        }
                        else
                        {
                            if (!ddr.DocContentRow.IsContentsNull())
                                ucWB1.WriteContent(ddr.DocContentRow.ContentsAsText);
                            ucWB1.Visible = true;
                            ucWB1.BringToFront();
                            axEDOffice1.Visible = false;
                            textControlCompose.Visible = false;

                            ReturnFocus();
                        }
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
                NoDoc(String.Format(Properties.Resources.DocCantBeDisplayedTryExternalApp, x.Message));
                uiCommandBar2.Enabled = true;
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

            //disable menus after opening a document
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableNew, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableOpen, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableSave, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableSaveAs, true);
            axEDOffice1.DisableFileCommand(EDOfficeLib.WdUIType.wdUIDisableClose, true);
            axEDOffice1.ShowRibbonTitlebar(false);

            // 2013-06-12 JLL: update to use isDraft only
            //if (!ddr.ReadOnly & myEffectiveEditMode == EditModeEnum.Compose)
            //if (ddr.DocumentRow.IsDraft & myEffectiveEditMode == EditModeEnum.Compose)
            if ((ddr.RowState == DataRowState.Added || (bool)ddr["IsDraft", DataRowVersion.Original]) & myEffectiveEditMode == EditModeEnum.Compose)
            {
                //axOfficeViewer1.Menubar = true;
                //axOfficeViewer1.Toolbars = true;
                axEDOffice1.ShowMenubar(true);
                axEDOffice1.Toolbars = true;

                axEDOffice1.SwitchViewType(1);
                try
                {
                    //2017-08-02 (JLL) IUTIR - 9290
                    //implementation of LayoutStyle feature on Template row
                    if (!ddr.IsTemplateIdNull())
                    {
                        int viewType = 1;
                        appDB.TemplateRow templateRow = myDM.AtMng.DB.Template.FindByTemplateId(ddr.TemplateId);
                        if (templateRow != null && !templateRow.IsLayoutStyleNull())
                        {
                            
                            switch (templateRow.LayoutStyle)
                            {
                                case 1033: //print layout
                                    viewType = 3;
                                    break;
                                case 1034: //web layout
                                    viewType = 6;
                                    break;
                                case 1035: //reading mode
                                    viewType = 7;
                                    break;
                            }
                        }
                        else
                        {
                            if (ddr.isLawmail)
                                viewType = 6;
                            else
                                viewType = 3; 
                        }

                        axEDOffice1.SwitchViewType(viewType);

                    }
                    else
                    {
                        //set normal view
                        if (ddr.isLawmail)
                            axEDOffice1.SwitchViewType(6);
                        else
                            axEDOffice1.SwitchViewType(3);
                    }
                }
                catch (Exception x)
                {
                    axEDOffice1.SwitchViewType(1);
                }
            }
            else
            {
                //JL - did not comment this out as part of v.8 //axOfficeViewer1.PrintPreview();

                axEDOffice1.ProtectDoc(3);
                axEDOffice1.ShowMenubar(false);
                axEDOffice1.Toolbars = false;
            }

            ReturnFocus();
        }

        public void PreviewAsync()
        {
            timPreview.Stop();
            timPreview.Start();
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

        bool isHighlight = false;

        public string PreviewHitHighlight(string fullText)
        {

            docDB.DocumentRow dr = DocRecord;
            displayedDoc = dr;

            if (dr == null)
                return "";
            FlipPanelsNoDisplayOfContent(false, true);

            pnlControlContainer.SuspendGroupLayout();
            InitDocRecordDep(dr);
            pnlControlContainer.ResumeGroupLayout();
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

        private void btnAttachmentDelete_Click(object sender, EventArgs e)
        {
            Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
            docDB.AttachmentRow attchrow = (docDB.AttachmentRow)btn.Tag;

            docDB.DocumentRow docrow = attchrow.DocumentRowByDocument_Attachment1;

            //remove buttons from UI
            flowLayoutPanel1.Controls[attchrow.Id.ToString()].Click -= new System.EventHandler(this.btnAttachmentDelete_Click);
            flowLayoutPanel1.Controls.RemoveByKey(attchrow.Id.ToString());
            flowLayoutPanel1.Controls["Delete" + attchrow.Id.ToString()].Click -= new System.EventHandler(this.btnMessageRead_Click);
            flowLayoutPanel1.Controls.RemoveByKey("Delete" + attchrow.Id.ToString());

            //delete attachment
            attchrow.Delete();

            //delete doc if just added
            if (docrow.RowState == DataRowState.Added)
            {
                if (docrow.DocContentRow != null)
                    docrow.DocContentRow.Delete();
                docrow.Delete();
            }
        }

        private void btnMessageRead_Click(object sender, EventArgs e)
        {
            Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;

            //save the current doc before displaying another
            TextToRecord();
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
                DisplayContents(attch.DocumentRowByDocument_Attachment1, true, false, version);
            }

        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            docDB.DocumentRow dr = DocRecord;

            fContactSelect fcs = new fContactSelect(myDM.FM, dr, true);
            fcs.ActiveOnly = true;
            fcs.ShowDialog(this);
            ucRecipientTextBoxFrom.Reload();
            ucRecipientTextBoxTo.Reload();
            ucRecipientTextBoxCc.Reload();
            NoRecipientCcBcc_ClosePanel();
        }

        public void EndEdit()
        {
            TextToRecord();
            documentBindingSource.EndEdit();
            docContentBindingSource.EndEdit();
        }

        private void TextToRecord()
        {

            //write data back to record
            if (DocRecord == null)
                return;
            docDB.DocContentRow dr = DocRecord.DocContentRow;

            if (myEffectiveEditMode == EditModeEnum.Compose & (isDirty | (axEDOffice1.GetDocumentName() != null && axEDOffice1.IsDirty())))
            {
                isDirty = false;
                //save from tx control

                if (dr != null)
                {
                    // 2013-06-12 JLL: update to use isDraft only
                    //if (dr.ReadOnly)
                    if (DocRecord.RowState != DataRowState.Added && !(bool)DocRecord["IsDraft", DataRowVersion.Original])
                    {
                        //MessageBox.Show(Properties.Resources.YouCantSaveAReadOnlyDocument);
                        return;
                    }

                    switch (dr.Ext.ToLower())
                    {
                        //case ".pdf":
                        //    byte[] contentsPDF;
                        //    textControlCompose.Save(out contentsPDF, TXTextControl.BinaryStreamType.AdobePDF);
                        //    dr.Contents = contentsPDF;

                        //    break;
                        //case ".docx":
                        //    byte[] contentsXML;
                        //    textControlCompose.Save(out contentsXML, TXTextControl.BinaryStreamType.WordprocessingML);
                        //    dr.Contents = contentsXML;
                        //    break;
                        //case ".doc":
                        //    byte[] contentsDOC;
                        //    textControlCompose.Save(out contentsDOC, TXTextControl.BinaryStreamType.MSWord);
                        //    dr.Contents = contentsDOC;
                        //    break;
                        //case ".rtf":
                        //    string contentsRTF;
                        //    textControlCompose.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);
                        //    dr.ContentsAsText =contentsRTF;
                        //    break;
                        //case ".htm":
                        //case ".html":
                        //    string contentsHTML;
                        //    textControlCompose.Save(out contentsHTML, TXTextControl.StringStreamType.HTMLFormat);
                        //    dr.ContentsAsText =contentsHTML;
                        //    break;
                        //case ".pdf":
                        //    byte[] contentsPDF;
                        //    textControlCompose.Save(out contentsPDF, TXTextControl.BinaryStreamType.AdobePDF);
                        //    dr.Contents = contentsPDF;

                        //    break;
                        case ".ppt":
                        case ".xslx":
                        case ".xls":
                            axEDOffice1.Save();
                            System.IO.FileStream fs1 = new FileStream(TempFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            System.IO.BinaryReader br1 = new BinaryReader(fs1);
                            dr.Contents = br1.ReadBytes((int)fs1.Length);
                            br1.Close();
                            break;
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
                            if (IsManageTemplates)
                                textControlCompose.Save(out contentsTxt1, TXTextControl.StringStreamType.PlainText);
                            else
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

        }
        private void textControlCompose_Validated(object sender, EventArgs e)
        {
            try
            {
                TextToRecord();
                documentBindingSource.EndEdit();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void WriteContentToDoc(string content)
        {
            if (myEffectiveEditMode == EditModeEnum.Compose)
            {
                if (axEDOffice1.Visible)
                {
                    axEDOffice1.WordInsertText(content);
                }
                else if (textControlCompose.Visible)
                {
                    textControlCompose.Selection.Text = content;
                }
            }
        }

        public string WriteTempFile(docDB.DocumentRow ddr)
        {
            if (EditMode == EditModeEnum.Compose)
            {
              
                if (ddr.RowState == DataRowState.Added)
                    TempFile = myDM.GetDocContent().WriteTempFile(ddr, false); //always make new documents editable
                else
                {
                    if (ddr.HasVersion(DataRowVersion.Original))
                        TempFile = myDM.GetDocContent().WriteTempFile(ddr, !(bool)ddr["IsDraft", DataRowVersion.Original]);
                    else
                        TempFile = myDM.GetDocContent().WriteTempFile(ddr, !ddr.IsDraft);
                }
            }
            else
            {
                TempFile = myDM.GetDocContent().WriteTempFile(ddr, !IsManageTemplates);
            }
            return TempFile;

        }

        public void SaveAs(string format)
        {
            if (mainDoc.DocId != displayedDoc.DocId)
                DisplayContents(mainDoc, false, false);

            string v = axEDOffice1.GetOfficeVersion();

            //jll: problem still exists where saveas ext set to docx and converting doc from format that does not use Officer Viewer Control
            //e.g. converting from pdf to docx fails since string v above returns empty string which causes v.substring check below to throw an exception

            if (format == ".docx" && System.Convert.ToInt32(v.Substring(0, 2)) < 12)
                format = ".doc";

            DocRecord.DocContentRow.Ext = format;
            isDirty = true;

            EditModeEnum temp = myEffectiveEditMode;
            myEffectiveEditMode = EditModeEnum.Compose;
            TextToRecord();
            myEffectiveEditMode = temp;
        }

        private void textControlCompose_Changed(object sender, EventArgs e)
        {
            isDirty = true;
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
            }
        }

        private void documentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ApplySecurity(DocRecord);
        }

        private void InsertSignature(bool FullSig)
        {
            string sFName = myDM.AtMng.WorkingAsOfficer.FirstName + " " + myDM.AtMng.WorkingAsOfficer.LastName + Environment.NewLine;
            string sPos = myDM.AtMng.WorkingAsOfficer.PositionTitle + Environment.NewLine;
            string sTel = "Tel. | tél. " + "(" + myDM.AtMng.WorkingAsOfficer.TelephoneNumber.Substring(0, 3) + ") " + myDM.AtMng.WorkingAsOfficer.TelephoneNumber.Substring(3, 3) + "-" + myDM.AtMng.WorkingAsOfficer.TelephoneNumber.Substring(5, 4) + Environment.NewLine;

            if (!FullSig)
                textControlCompose.Selection.Text = sFName + sPos + sTel;
            else
            {
                string sOfficeName = myDM.AtMng.WorkingAsOfficer.OfficeRow.OfficeName + " | " + myDM.AtMng.WorkingAsOfficer.OfficeRow.OfficeNameFre + Environment.NewLine;

                atriumBE.FileManager fakeFM = myDM.AtMng.GetFile();
                lmDatasets.atriumDB.AddressRow addr = fakeFM.GetAddress().Load(myDM.AtMng.WorkingAsOfficer.OfficeRow.AddressId);
                string sAddress = addr.Address1 + Environment.NewLine;
                if (!addr.IsAddress2Null())
                    sAddress += addr.Address2 + Environment.NewLine;
                if (!addr.IsAddress3Null())
                    sAddress += addr.Address3 + Environment.NewLine;

                lmDatasets.appDB.ProvinceRow provr = fakeFM.AtMng.GetProvince().Load(addr.ProvinceCode);
                string sCityProvPostalCode = addr.City + ", " + provr.ProvinceDescriptionEng + " " + addr.PostalCode + Environment.NewLine;

                string sFax = "";
                if (!addr.IsFaxNumberNull())
                    sFax = "Fax: | téléc. " + "(" + addr.FaxNumber.Substring(0, 3) + ") " + addr.FaxNumber.Substring(3, 3) + "-" + addr.FaxNumber.Substring(5, 4) + Environment.NewLine;

                string sEmail = "";
                if (!myDM.AtMng.WorkingAsOfficer.IsEmailAddressNull())
                    sEmail = myDM.AtMng.WorkingAsOfficer.EmailAddress + Environment.NewLine;

                string sGoC = "Government of Canada | Gouvernement du Canada";

                textControlCompose.Selection.Text = sFName + sPos + sOfficeName + sAddress + sCityProvPostalCode + sTel + sFax + sEmail + sGoC;

                fakeFM.Dispose();
            }

            TextToRecord();
        }

        private void InsertExternalDocument(bool InsertAsDraft)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                string[] fs = this.openFileDialog1.FileNames;
                foreach (string f in fs)
                {
                    //if (f != "")
                    //{
                    docDB.DocumentRow newDoc = (docDB.DocumentRow)myDM.GetDocument().Add(myDM.FM.CurrentFile, f);
                    string tmp = f.Substring(f.LastIndexOf("\\") + 1);
                    newDoc.efSubject = tmp.Remove(tmp.LastIndexOf("."));

                    newDoc.icon = UIHelper.GetFileIcon(f);

                    if (myDM.AtMng.GetSetting(atriumBE.AppBoolSetting.useSSTMngr))
                    {
                        newDoc.SetColumnError("PageCount", "Page count is a required field");

                    
                        newDoc.SetefTypeNull();
                    }
                    else
                    {
                        newDoc.efType = "ATT";
                    }
                    newDoc.IsDraft = InsertAsDraft;
                    // 2013-06-12 JLL: update to use isDraft only
                    //newDoc.DocContentRow.ReadOnly = !InsertAsDraft;
                    atriumBE.AttachmentBE d = myDM.GetAttachment();
                    lmDatasets.docDB.AttachmentRow att = (lmDatasets.docDB.AttachmentRow)d.Add(DocRecord);
                    att.AttachmentId = newDoc.DocId;
                    att.Version = newDoc.CurrentVersion;

                    if (myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.PromptMetaData,true))
                    {
                        fDoc fMeta = new fDoc(myDM, newDoc);
                        fMeta.MetaDataPrompt = true;
                        fMeta.Show(this.ParentForm);
                    }
                    AddAtt(att);
                }
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (displayedDoc == null)
                return;
            try
            {
                switch (e.Command.Key)
                {

                    case "cmdMakeFinal":
                        DoMakeFinal();
                        break;
                    case "cmdSendAsAttachment":
                        docDB.DocumentRow drc = displayedDoc;
                        if (drc.IsDraft)
                            CreateDocumentCopy(displayedDoc.FileId, DocActionEnum.SendAsAttachment);
                        else
                            AdviseDocActionSubscribers(displayedDoc, DocActionEnum.SendAsAttachment);
                        break;
                    case "cmdPrint":
                        Print();
                        break;
                    case "cmdViewDDoc":
                        fDocView fd = new fDocView(myDM, displayedDoc);
                        fd.Show(this.ParentForm);
                        break;
                    case "cmdViewNative":
                        if (displayedDoc.DocContentRow == null)
                        {
                            myDM.GetDocContent().Load(displayedDoc.DocRefId, displayedDoc.CurrentVersion);
                        }
                        UIHelper.LaunchNative(myDM.GetDocContent().WriteTempFile(displayedDoc, true), this, "");
                        break;
                    case "cmdInsertExternalFileAsDraft":
                        InsertExternalDocument(true);
                        break;
                    case "cmdInsertExternalFile":
                        InsertExternalDocument(false);
                        break;
                    case "cmdInsertInternalFile": //copy of draft
                        AddLMItem("iselectronic=true", false);
                        break;
                        //case "cmdInsertLink":
                        //    AddLMItem("iselectronic=true", true);
                        break;
                    //  case "cmdInsertRecord":
                    //      AddLMItem("isdraft=false and iselectronic=true", true);
                    //break;
                    case "cmdSignatureNewMessage":
                        InsertSignature(true);
                        break;
                    case "cmdSignatureReplyForward":
                        InsertSignature(false);
                        break;
                    case "cmdReviseDocument":
                        AdviseDocActionSubscribers(displayedDoc, DocActionEnum.Revise);
                        break;
                    case "cmdCopyToClipboard":
                        WriteTempFile(displayedDoc);
                        System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
                        sc.Add(TempFile);
                        Clipboard.SetFileDropList(sc);
                        break;
                    case "cmdCopyAttachment":
                        //myDM.GetDocument().MakeCopy(displayedDoc, myDM.FM.CurrentFile, true);
                        break;
                    case "cmdAutoAcNoWizardOriginalFile":
                        CreateDocumentCopy(displayedDoc.FileId, DocActionEnum.CopyOnly);
                        break;
                    case "cmdAutoAcNoWizardPersonalFile":
                        CreateDocumentCopy(myDM.AtMng.WorkingAsOfficer.MyFileId, DocActionEnum.CopyOnly);
                        break;
                    case "cmdAutoACNoWizard": //browse
                        if (fileBrowser == null)
                            fileBrowser = new fBrowse(myDM.AtMng, 0, false, false, false, true);

                        fileBrowser.FindFile(displayedDoc.FileId);
                        if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            CreateDocumentCopy(fileBrowser.FileId, DocActionEnum.CopyOnly);
                        }
                        break;
                    case "cmdOpenWizardOriginalFile":
                        CreateDocumentCopy(displayedDoc.FileId, DocActionEnum.CopyAndOpen);
                        break;
                    case "cmdOpenWizardPersonalFile":
                        CreateDocumentCopy(myDM.AtMng.WorkingAsOfficer.MyFileId, DocActionEnum.CopyAndOpen);
                        break;
                    case "cmdOpenWizard": //browse
                        if (fileBrowser == null)
                            fileBrowser = new fBrowse(myDM.AtMng, 0, false, false, false, true);

                        fileBrowser.FindFile(displayedDoc.FileId);
                        if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            CreateDocumentCopy(fileBrowser.FileId, DocActionEnum.CopyAndOpen);
                        }
                        break;
                    case "cmdAddDocXref":
                        UIHelper.CreateNewDocXRef(myDM.AtMng, displayedDoc);
                        break;
                    case "cmdDocCheckOut":
                        UIHelper.DocumentCheckOutAction(DocCheckOutActionEnum.CheckOut, displayedDoc, myDM, this);
                        break;
                    case "cmdDocCheckIn":
                        UIHelper.DocumentCheckOutAction(DocCheckOutActionEnum.CheckIn, displayedDoc, myDM, this);
                        //Launch Wizard based on preference
                        if (myDM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.ReviseDocOnDocCheckIn, false))
                            AdviseDocActionSubscribers(displayedDoc, DocActionEnum.Revise);
                        break;
                    case "cmdUndoDocCheckOut":
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
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        public void FocusToOffice()
        {
            try
            {
                axEDOffice1.SetAppFocus();
            }
            catch (Exception x)
            { }

        }
        public void PasteToOffice()
        {
            try
            {
                axEDOffice1.SetAppFocus();

                //wdInDocumentPosCursor = 1,
                //wdInDocumentPosStart = 2,
                //wdInDocumentPosEnd = 3
                axEDOffice1.WordPasteFromClipboard(1);
            }
            catch (Exception x)
            { }

        }
        private void AddLMItem(string filter, bool asLink)
        {

            this.OpenDocDialog.SetDocFilter(filter);
            if (myDM.FM.CurrentFile.RowState != DataRowState.Added)
                this.OpenDocDialog.FindFile(myDM.FM.CurrentFileId);
            DialogResult dRes = this.OpenDocDialog.ShowDialog(this);
            this.OpenDocDialog.SetDocFilter("");
            if (dRes == DialogResult.OK && this.OpenDocDialog.SelectedDocuments() != null)
            {
                //docDB.DocumentRow docToAttach = OpenDocDialog.SelectedDocument;
                foreach (docDB.DocumentRow docsel in OpenDocDialog.SelectedDocuments())
                {
                    docDB.DocumentRow docToAttach = docsel;
                    if (!docToAttach.IsCheckedOutByNull())
                    {
                        if (docToAttach.CheckedOutBy == myDM.AtMng.OfficerLoggedOn.OfficerId)
                        {
                            MessageBox.Show("You are trying to attach a document that is checked out to you.  You should check it in before sending it.", "Adding attachment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("You are trying to attach a document that is checked out to someone else.  You should wait until they check it in before sending it.", "Adding attachment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }


                    if (myDM.DB.Document.FindByDocId(docToAttach.DocId) == null)
                        myDM.GetDocument().Load(docToAttach.DocId);

                    atriumBE.AttachmentBE d = myDM.GetAttachment();
                    lmDatasets.docDB.AttachmentRow att = (lmDatasets.docDB.AttachmentRow)d.Add(DocRecord);
                    att.AttachmentId = docToAttach.DocId;


                    //set attachment version for copies so that it always shows the same version CJW 2015-4-41
                    att.Version = docToAttach.CurrentVersion;


                    AddAtt(att);

                    //if (!asLink)
                    //{
                    //    fDoc fMeta = new fDoc(myDM, docToAttach);
                    //    fMeta.Show();
                    //}

                    //                    if (!asLink)
                    //                    {

                    //                        docToAttach = myDM.GetDocument().MakeCopy(docToAttach, myDM.FM.CurrentFile, false);
                    //                    }
                    //                    else
                    //                    {
                    //                        if (myDM.DB.Document.FindByDocId(docToAttach.DocId) == null)
                    //                            myDM.GetDocument().Load(docToAttach.DocId);
                    //                    }
                    //                    atriumBE.AttachmentBE d = myDM.GetAttachment();
                    //                    lmDatasets.docDB.AttachmentRow att = (lmDatasets.docDB.AttachmentRow)d.Add(DocRecord);
                    //                    att.AttachmentId = docToAttach.DocId;

                    ////                    if(!asLink)
                    ////                    {
                    //                        //set attachment version for copies so that it always shows the same version CJW 2015-4-41
                    //                    att.Version = docToAttach.CurrentVersion;

                    //  //                  }

                    //                    AddAtt(att);

                    //                    if (!asLink)
                    //                    {
                    //                        fDoc fMeta = new fDoc(myDM, docToAttach);
                    //                        fMeta.Show();
                    //                    }
                }
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

        private void axOfficeViewer1_Validated(object sender, EventArgs e)
        {
            try
            {
               
                EndEdit();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
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

        public string sendType = "";
        private void VerifyIfMail(docDB.DocumentRow dr)
        {
            if (dr == null)
                return;

            sendType = "";

            if (!dr.IsisLawmailNull() && dr.isLawmail)// && myEffectiveEditMode == EditModeEnum.Compose)
            {
                cmdInsertExternalFileAsDraft.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                bool[] sendMail = myDM.GetDocument().SendByMail(dr);

                if (sendMail[0] && sendMail[1])
                {
                    //send by both outlook and atrium
                    chkEncrypt.Enabled = true;
                    sendType = "B";
                    tbEfSubject.Image = Properties.Resources.email2;
                }
                else if (sendMail[0] && !sendMail[1])
                {
                    //sent outlook only
                    chkEncrypt.Enabled = true;
                    sendType = "O";
                    tbEfSubject.Image = Properties.Resources.outlook2016;
                }
                else
                {
                    //sent atrium mail
                    chkEncrypt.Enabled = false;
                    sendType = "A";
                    tbEfSubject.Image = Properties.Resources.atrium16x16;
                }

                if (RecipientChanged != null)
                {
                    RecipientChangedEventArgs rxea = new RecipientChangedEventArgs();
                    rxea.RecipCount = dr.GetRecipientRows().Length;
                    RecipientChanged(this, rxea);
                }

            }
            else
                cmdInsertExternalFileAsDraft.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        }

        int RecipientMaxBoxHeight = 49;
        int RecipientMinBoxHeight = 29;

        private void ucRecipientTextBoxCc_RecipientAdded(object sender, ControlEventArgs e)
        {
            try
            {
                VerifyIfMail(DocRecord);
                FlowLayoutPanel flp = (FlowLayoutPanel)sender;
                ucRecipientTextBox rtb = (ucRecipientTextBox)flp.Parent;
                Janus.Windows.UI.Dock.UIPanel pnl = null;

                if (rtb.IsScrollVisible)
                {
                    switch (rtb.Name)
                    {
                        case "ucRecipientTextBoxTo":
                            pnl = pnlTo;
                            break;
                        case "ucRecipientTextBoxCc":
                            pnl = pnlCC;
                            break;
                        case "ucRecipientTextBoxBcc":
                            pnl = pnlBCC;
                            break;

                    }
                    if (pnl != null)
                    {
                        Size sz = new Size(-1, RecipientMaxBoxHeight);
                        pnl.MaximumSize = sz;
                        pnl.MinimumSize = sz;
                        pnl.Height = RecipientMaxBoxHeight;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucRecipientTextBoxCc_RecipientRemoved(object sender, ControlEventArgs e)
        {
            try
            {
                VerifyIfMail(DocRecord);
                FlowLayoutPanel flp = (FlowLayoutPanel)sender;
                ucRecipientTextBox rtb = (ucRecipientTextBox)flp.Parent;
                Janus.Windows.UI.Dock.UIPanel pnl = null;

                if (flp.Controls.Count < 5)
                {
                    switch (rtb.Name)
                    {
                        case "ucRecipientTextBoxTo":
                            pnl = pnlTo;
                            break;
                        case "ucRecipientTextBoxCc":
                            pnl = pnlCC;
                            break;
                        case "ucRecipientTextBoxBcc":
                            pnl = pnlBCC;
                            break;
                    }
                    if (pnl != null)
                    {
                        Size sz = new Size(-1, RecipientMinBoxHeight);
                        pnl.MaximumSize = sz;
                        pnl.MinimumSize = sz;
                        pnl.Height = RecipientMinBoxHeight;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
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

        private void CreateDocumentCopy(int fmfileid, DocActionEnum docAction)
        {
            atriumBE.FileManager tempFM = myDM.AtMng.GetFile(fmfileid);
            docDB.DocumentRow docCopy = tempFM.GetDocMng().GetDocument().MakeCopy(displayedDoc, tempFM.CurrentFile, displayedDoc.IsDraft);
            AdviseDocActionSubscribers(docCopy, docAction);
        }

        private void uiCommandBar2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
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

        private void lnkEditCheckedOutDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                UIHelper.LaunchNative(displayedDoc.CheckedOutPath, this, "");
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
                        case Keys.X:
                            if (textControlCompose.EditMode == TXTextControl.EditMode.Edit)
                                textControlCompose.Cut();
                            break;
                        case Keys.V:
                            if (textControlCompose.EditMode == TXTextControl.EditMode.Edit)
                                textControlCompose.Paste();
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(new LMException(x.Message));
            }
        }

        private void tbEfSubject_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (myEffectiveEditMode == EditModeEnum.Compose)
                {
                    Janus.Windows.GridEX.EditControls.EditBox tbText = (Janus.Windows.GridEX.EditControls.EditBox)sender;
                    int ReverseCounter = 255 - tbText.Text.Length;
                    efSubjectCounter.Text = ReverseCounter.ToString();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiStatusBar1_PanelClick(object sender, Janus.Windows.UI.StatusBar.StatusBarEventArgs e)
        {
            try
            {
                if (e.Panel.Key == uiStatusBar1.Panels["PreviewMode"].Key)
                {
                    UIHelper.LaunchNative(myDM.GetDocContent().WriteTempFile(displayedDoc, true), this, "");
                }
                if (e.Panel.Key == uiStatusBar1.Panels["DraftMessage"].Key)
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
                if (e.Panel.Key == uiStatusBar1.Panels["PreviewMode"].Key)
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
            uiStatusBar1.Panels["PnlFiller"].Visible = false;

            uiStatusBar1.Panels[PanelKey].Visible = ShowPanel;

            bool PreviewModeVisible = false;
            bool AtLeastOnePanelVisible = false;
            for (int i = 0; i < uiStatusBar1.Panels.Count; i++)
            {
                if (uiStatusBar1.Panels[i].Visible)
                {
                    AtLeastOnePanelVisible = true;
                    if (uiStatusBar1.Panels[i].ToString() == "PreviewMode")
                        PreviewModeVisible = true;
                }
            }
            if (AtLeastOnePanelVisible)
            {
                uiStatusBar1.Panels["PnlFiller"].Visible = true;
                uiStatusBar1.Visible = true;
            }
            else
                uiStatusBar1.Visible = false;

            if (PreviewModeVisible)
                janusSuperTip1.Show(jstSettings);
            else
                janusSuperTip1.ClearToolTipArea();
        }

        private void btnLoadLargeDoc_Click(object sender, EventArgs e)
        {
            try
            {
                bool isAttach = (bool)btnLoadLargeDoc.Tag;
                FlipPanelsNoDisplayOfContent(false, true);
                DisplayContents(displayedDoc, isAttach, true);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void SetFocusToSelectedViewer()
        {
            if (ucWB1.Visible)
                ucWB1.Focus();
            else if (textControlCompose.Visible)
                textControlCompose.Focus();
            else if (axEDOffice1.Visible)
            {
                axEDOffice1.Focus();
              //  axEDOffice1.SetAppFocus();
            }
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {
            try
            {
                DoMakeFinal();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void DoMakeFinal()
        {
            if (MessageBox.Show("This will make the document read-only.  This operation cannot be undone. \n\nAre you sure you want to continue?", "Finalize Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DocRecord.IsDraft = false;
                cmdViewVersionHistory.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                // 2013-06-12 JLL: update to use isDraft only
                //DocRecord.DocContentRow.ReadOnly = true;
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

        private void PageCount_Validated(object sender, EventArgs e)
        {
            if (pageCounteditBox.Text.Length > 0)
            {
                pageCounteditBox.BackColor = Color.White;
            }
            else
            {
                pageCounteditBox.BackColor = Color.Pink;
            }
        }

        private void mccCommType_Validated(object sender, EventArgs e)
        {
            if (mccCommType.SelectedIndex >= 0)
            {
                mccCommType.ReqColor = Color.White;
            }
            else
            {
                mccCommType.ReqColor = Color.Pink;
            }
        }

  

    }

    public enum DocCheckOutActionEnum
    {
        CheckOut,
        CheckIn,
        UndoCheckOut
    }

    public enum DocActionEnum
    {
        CopyAndOpen,
        CopyOnly,
        Revise,
        SendAsAttachment
    }
    public class DocLoadedEventArgs : EventArgs
    {
    }

    public delegate void DocLoadedEventHandler(object sender, DocLoadedEventArgs e);

    public class DocActionEventArgs : EventArgs
    {
        public DocActionEnum Action;
        public docDB.DocumentRow DocRecord = null;
    }

    public delegate void DocActionEventHandler(object sender, DocActionEventArgs e);

    public class RecipientChangedEventArgs : EventArgs
    {
        public int RecipCount = 0;
    }

    public delegate void RecipientChangedEventHandler(object sender, RecipientChangedEventArgs e);

}