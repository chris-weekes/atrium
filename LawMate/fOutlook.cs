using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;
using Redemption;
using System.IO;


namespace LawMate
{
    public partial class fOutlook : fBase
    {

        RDOSession mySession;
        object myMapi;
        private global::System.Object missing = global::System.Type.Missing;

        int tmpDocId = 0;
        int tmpAttid = 0;
        int tmpRecipId = 0;

        fBrowse fileBrowser;
        const string LayoutVersionNumber = "4_0_14";
        docDB freeDocDB;
        FileManager myFM;
        ActivityConfig.ACSeriesRow acsrMail;
        public fOutlook()
        {
            InitializeComponent();
        }

        public fOutlook(Form f)
            : base(f)
        {

            InitializeComponent();


            try
            {
                //DocManager dm = MainForm.AtMng.GetFile(Atmng.UnFiledMailFileId, false).GetDocMng();
                acsrMail = AtMng.acMng.DB.ACSeries.FindByACSeriesId(AtMng.GetSetting(AppIntSetting.ImportedMailCodeAcId));

                myFM = MainForm.AtMng.GetFile();

                DocManager dm = myFM.GetDocMng();

                dm.GetDocument();
                dm.GetDocContent();
                dm.GetAttachment();
                dm.GetRecipient();

                freeDocDB = new docDB();// dm.DB;
                freeDocDB.EnforceConstraints = false;



                //ucDoc1.Init(dm);
                ucDocView1.Init(dm);

                mySession = DocumentBE.RDOSession();
                mySession.Logon(missing, missing, missing, missing, missing, missing);

                myMapi = mySession.MAPIOBJECT;

                mySession.OnNewMail += new IRDOSessionEvents_OnNewMailEventHandler(mySession_OnNewMail);

                outlookGridEX.KeepRowSettings = true;
                fs.BackColor = Color.LightYellow;
                fs.BackColorGradient = Color.Wheat;
                fs.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
                fs.BlendGradient = 0.3f;
                fs.ForeColor = Color.Black;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void mySession_OnNewMail(string EntryID)
        {
            try
            {
                //check to see if mail is in current folder
                //RDOMail newMail = mySession.GetMessageFromID(EntryID, missing, missing);
                RDOMail newMail = GetMessageFromId(EntryID, false);
                if (newMail == null)
                    return;

                RDOFolder fld = (RDOFolder)newMail.Parent;
                if (fld == null || treeView1.SelectedNode==null)
                    return;

                if (fld.EntryID == treeView1.SelectedNode.Name)
                {
                    if (newMail.ReceivedTime < DateTime.Today.AddYears(10))
                    {
                        appDB.OutlookRow oldr = myOLDT.NewOutlookRow();
                        LoadMailRow(oldr, newMail);
                        myOLDT.AddOutlookRow(oldr);
                    }

                    SetPanelMailCount(fld.Name, fld.Items.Count.ToString());
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void LoadStores()
        {
            foreach (RDOStore store in mySession.Stores)
            {
                try
                {
                    TreeNode ndStore = treeView1.Nodes.Add(store.EntryID, store.Name);
                    //ndStore.ImageIndex = 22;
                    //ndStore.SelectedImageIndex = 22;
                    ndStore.Tag = "Store";
                }
                catch (Exception x)
                {
                    uiStatusBar1.Panels[0].Text = x.Message;
                }
            }
        }

        public void LoadFolders(TreeNode ndParent, RDOFolder parent)
        {
            ndParent.Nodes.Clear();
            foreach (RDOFolder folder in parent.Folders)
            {
                if (folder.FolderKind == rdoFolderKind.fkGeneric && (folder.DefaultItemType == (int)rdoItemType.olMailItem))//|folder.DefaultItemType==(int)rdoItemType.olAppointmentItem 
                {
                    TreeNode nd = ndParent.Nodes.Add(folder.EntryID, folder.Name);
                    //nd.ImageIndex = 7;
                    //nd.SelectedImageIndex = 5;
                    LoadFolders(nd, folder);
                }
            }
        }

        private TreeNode GetTopNode(TreeNode nd)
        {
            if (nd.Parent == null)
                return nd;
            else
                return GetTopNode(nd.Parent);
        }

        private appDB.EFileSearchThreadDataTable FindFile(string ci)
        {

            if (ci == null)
                return null;

            return AtMng.FileSearchByThread(ci.Substring(0, 44));

        }

        private int IsImported(int fileId, string ci)
        {
            DataSet ds = AtMng.AppMan.ExecuteDataset("IsMailImported", fileId, ci.Substring(0, 44), ci.Substring(44, ci.Length - 44));
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                ImportPerson = ds.Tables[0].Rows[0][0].ToString();
                string date = ds.Tables[0].Rows[0][1].ToString();
                ImportDate = DateTime.Parse(date);
                return System.Convert.ToInt32(ds.Tables[0].Rows[0][2]);
            }
            else
            {
                return fileId;
            }
            ////ActivityBP abp = fm.InitActivityProcess(false);
            //if (fm.DB.Activity.Count == 0)
            //    fm.GetActivity().LoadByFileId(fm.CurrentFile.FileId);
            ////look for activity with same thread
            //atriumDB.ActivityRow[] arsMatch = (atriumDB.ActivityRow[])fm.DB.Activity.Select("ConvIndexBase+ConversationIndex='" + ci + "' or (ConvIndexBase='" + ci + "' and ConversationIndex is null)");
            //if (arsMatch.Length == 0)
            //    return;
            //else
            //{
            //    docDB.DocumentRow dr = fm.GetDocMng().GetDocument().Load(arsMatch[0].DocId);
            //    ImportPerson = dr.FiledBy;
            //    ImportDate = dr.entryDate;
            //}

        }

        string ImportPerson = "";
        DateTime ImportDate;
        string SortBy = "ReceivedTime";
        bool SortDescending = true;
        appDB.OutlookDataTable myOLDT;
        BackgroundWorker currentbkw;
        public void LoadMAil(RDOFolder folder)
        {


            //ucDoc1.NoAssociatedDocument("");
            ucDocView1.NoAssociatedDocument("");

            threadMatch.Clear();
            threadMatchDT.Clear();

            appDB.EFileSearchThreadRow er = threadMatchDT.NewEFileSearchThreadRow();
            er.FileNumber = LawMate.Properties.Resources.IgnoreThread;
            er.FullFileNumber = LawMate.Properties.Resources.IgnoreThread;
            er.NameE = LawMate.Properties.Resources.IgnoreThread;
            er.NameF = LawMate.Properties.Resources.IgnoreThread;
            er.StatusCode = "O";
            er.FileType = "PR";
            er.OwnerOfficeId = AtMng.OfficeLoggedOn.OfficeId;
            er.OpenedDate = DateTime.Today;
            er.Thread = "Nothing";
            er.FileId = -1;
            threadMatchDT.AddEFileSearchThreadRow(er);
            UIHelper.ComboBoxInit(threadMatchDT, outlookGridEX.DropDowns["ddFile"], myFM);

            if (currentbkw != null && currentbkw.IsBusy)
            {
                currentbkw.CancelAsync();
            }

            this.UseWaitCursor = true;

            currentbkw = new BackgroundWorker();
            currentbkw.WorkerReportsProgress = true;
            currentbkw.WorkerSupportsCancellation = true;
            currentbkw.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            currentbkw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            currentbkw.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);

            RDOItems itms = folder.Items;
            if (outlookGridEX.RootTable.Groups.Count > 0)
            {
                SetSortBy(outlookGridEX.RootTable.Groups[0].Column.Key);
                SortDescending = (outlookGridEX.RootTable.Groups[0].Column.SortOrder == Janus.Windows.GridEX.SortOrder.Descending);

            }
            itms.Sort(SortBy, SortDescending);

            itms.MAPITable.Position = 0;


            myOLDT = new appDB.OutlookDataTable();


            currentbkw.RunWorkerAsync(folder.EntryID);
            //this.Cursor = Cursors.AppStarting;

            outlookBindingSource.DataSource = myOLDT;
            SetPanelMailCount(folder.Name, itms.Count.ToString());

            if (CurrentRow() != null)
                DisplayMail(CurrentRow().id);

            // Application.UseWaitCursor=false;
        }

        private void SetPanelMailCount(string folderName, string ItmCount)
        {
            uiPanel1.Text = folderName;
            uiPanel1.InfoText = String.Format(LawMate.Properties.Resources.OutlookFolderNameAndNumOfItems, ItmCount);
        }

        private appDB.OutlookDataTable LoadOutlookDT(string fid, BackgroundWorker bkw, DoWorkEventArgs e)
        {

            RDOSession session = DocumentBE.RDOSession();
            session.MAPIOBJECT = myMapi;
            RDOFolder fld = session.GetFolderFromID(fid);
            RDOItems itms = fld.Items;

            appDB.OutlookDataTable oldt = new appDB.OutlookDataTable();

            int iMax = 20;
            oldt.BeginLoadData();
            for (int i = 0; i < itms.Count; i++)
            {
                if (i == itms.Count)
                    break;

                if (bkw.CancellationPending)
                {
                    e.Cancel = true;
                    return null;
                }
                RDOMail mail = itms[i + 1];

                if (mail.ReceivedTime < DateTime.Today.AddYears(10))
                {
                    //appDB.OutlookRow newIncomingMail = myOLDT.FindByid(mail.EntryID);
                    //if (newIncomingMail == null)
                    //{
                        appDB.OutlookRow oldr = oldt.NewOutlookRow();
                        LoadMailRow(oldr, mail);
                        oldt.AddOutlookRow(oldr);
                    //}
                }
                if ((i + 1) % iMax == 0)
                {
                    iMax = 100;
                    oldt.EndLoadData();
                    bkw.ReportProgress(0, oldt);
                    oldt = new appDB.OutlookDataTable();
                    oldt.BeginLoadData();
                }
            }
            oldt.EndLoadData();
            //outlookGridEX.Refresh();
            return oldt;
        }


        private static void LoadMailRow(appDB.OutlookRow oldr, RDOMail mail)
        {
            oldr.id = mail.EntryID;
            oldr.isRead = !mail.UnRead;
            oldr.hasAttach = (mail.Attachments.Count > 0);


            oldr.From = mail.SenderName;
            oldr.Subject = mail.Subject;
            //oldr.ReceivedTime = mail.ReceivedTime;

            if (mail.ReceivedTime > DateTime.Today.AddYears(10))
            {
                oldr.ReceivedTime = DateTime.Now;

            }
            else
            {
                oldr.ReceivedTime = mail.ReceivedTime;
            }

            oldr.Size = (int)(mail.Size / 1024);
            oldr.To = mail.To;
            oldr.ConversationIndex = mail.ConversationIndex;
            if (mail.MessageClass.ToUpper().StartsWith("IPM.NOTE"))
            {
                if (!oldr.isRead)
                    oldr.MailItemType = 1;
                else
                    oldr.MailItemType = 2;
            }
            else if (mail.MessageClass.ToUpper().StartsWith("REPORT.IPM.NOTE"))
            {
                oldr.MailItemType = 4;
            }
            else if (mail.MessageClass.ToUpper().StartsWith("IPM.APPOINTMENT"))
            {
                oldr.MailItemType = 5;
            }
            else if (mail.MessageClass.ToUpper().StartsWith("IPM.SCHEDULE.MEETING"))
            {
                oldr.MailItemType = 6;
            }
            else
            {
                oldr.MailItemType = 0;
                oldr.Subject = mail.MessageClass.ToUpper();
            }
            foreach (RDOAttachment att in mail.Attachments)
            {
                if (att.FileName.EndsWith(".p7m"))
                {
                    oldr.MailItemType = 3;
                }
            }
        }



        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private RDOMail GetMessageFromId(string id, bool fromGrid)
        {
            try
            {
                if (fromGrid)
                    return mySession.Stores.GetStoreFromID(GetTopNode(treeView1.SelectedNode).Name, missing).GetMessageFromID(id, missing);
                else
                    return mySession.GetMessageFromID(id, missing, missing);
            }
            catch (Exception x)
            {
                //message

                if (fromGrid)
                {
                    MessageBox.Show("Message could not be retrieved from Outlook.  It has been deleted or moved");
                    CurrentRow().Delete();
                }
                return null;
            }
        }
        private void DisplayMail(string id)
        {
            //RDOMail mail = mySession.Stores.GetStoreFromID(GetTopNode(treeView1.SelectedNode).Name, missing).GetMessageFromID(id, missing);
            RDOMail mail = GetMessageFromId(id, true);
            if (mail == null)
                return;

            freeDocDB.Clear();
            freeDocDB.AcceptChanges();

            freeDocDB.FileFormat.Merge(myFM.GetDocMng().DB.FileFormat);
            try
            {
                docDB.DocumentRow dr = ImportMsg(freeDocDB, freeDocDB.Recipient, mail);

                if (!uiPanel2.Closed)
                {
                    DataView dvDoc = new DataView(dr.Table, "DocId=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);

                    //ucDoc1.Datasource = dvDoc;
                    //ucDoc1.PreviewAsync();
                    ucDocView1.Datasource = dvDoc;
                    ucDocView1.PreviewAsync();
                }
            }
            catch (Exception x)
            {
                //don't display error when just displaying email
            }
        }
        public static int CompareByIndex(DataRow dr1, DataRow dr2)
        {
            appDB.OutlookRow or1 = (appDB.OutlookRow)dr1;
            appDB.OutlookRow or2 = (appDB.OutlookRow)dr2;
            if (or1.IsConversationIndexNull() && or1.IsConversationIndexNull())
                return 0;
            else if (or1.IsConversationIndexNull())
                return -1;
            else if (or2.IsConversationIndexNull())
                return 1;
            else
                return or1.ConversationIndex.CompareTo(or2.ConversationIndex);
        }

        void Import(bool createBFs, ActivityConfig.ACSeriesRow acsr, atriumBE.ConnectorType mailAction, bool promptForBF)
        {


            //  Cursor.Current = Cursors.WaitCursor;
            int ImportFileId = 0;
            if (acsr != null && !acsr.SeriesRow.IsContainerFileIdNull())
                ImportFileId = acsr.SeriesRow.ContainerFileId;

            try
            {


                RDOFolder movedToLM = null;
                foreach (RDOFolder folder in mySession.Stores.DefaultStore.IPMRootFolder.Folders)
                {
                    string MovedToAppEng = AtMng.GetSetting(AppStringSetting.MovedToAtriumFolderEng);
                    string MovedToAppFre = AtMng.GetSetting(AppStringSetting.MovedToAtriumFolderFre);
                    if (folder.FolderKind == rdoFolderKind.fkGeneric && (folder.Name.ToUpper() == MovedToAppEng.ToUpper() || folder.Name.ToUpper() == MovedToAppFre.ToUpper()))
                    {
                        movedToLM = folder;
                        break;
                    }
                }

                List<DataRow> toAction = UIHelper.GridGetSelectedData(outlookGridEX);
                //determine if we need to prompt for a file

                foreach (lmDatasets.appDB.OutlookRow oldr in toAction)
                {
                    if (ImportFileId != 0)
                        oldr.FileId = ImportFileId;

                    if ((oldr.IsFileIdNull() || oldr.FileId == -1))
                    {
                        //prompt for file
                        if (fileBrowser == null)
                        {
                            fileBrowser = new fBrowse(AtMng, 0, false, false, false, true);
                            fileBrowser.Text = LawMate.Properties.Resources.SelectFileForFiling;

                        }

                        if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            ImportFileId = fileBrowser.SelectedFile.FileId;
                        }
                        else
                        {
                            throw new LMException("No file selected");
                        }
                        break;
                    }
                }

                List<int> bfofficers = new List<int>();
                if (!createBFs && acsr != null && promptForBF)
                {
                    //prompt for bf officers

                    fContactSelect fCSel = new fContactSelect(AtMng.GetFile(ImportFileId), null, true);
                    fCSel.ActiveOnly = true;

                    FileManager fmTemp = AtMng.GetFile();
                    docDB.DocumentRow multiDoc = fmTemp.GetDocMng().DB.Document.NewDocumentRow();
                    multiDoc.DocId = 0;
                    fCSel.MultiSelect(fmTemp.GetDocMng(), multiDoc);
                    if (fCSel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        foreach (docDB.RecipientRow rr in multiDoc.GetRecipientRows())
                        {
                            if (rr.OfficerId != 0)
                            {
                                bfofficers.Add(rr.OfficerId);
                            }
                        }
                        fmTemp.GetDocMng().DB.RejectChanges();
                        fCSel.Close();
                    }
                    else
                    {
                        fmTemp.GetDocMng().DB.RejectChanges();
                        fCSel.Close();
                        throw new LMException("No contact selected");
                    }

                }
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    toAction.Sort(CompareByIndex);

                    bool checkForAutoChain = false;
                    if (toAction.Count == 1)
                        checkForAutoChain = true;

                    List<string> toRecheck = new List<string>();

                    foreach (lmDatasets.appDB.OutlookRow oldr in toAction)
                    {
                        bool skip = false;
                        docDB ds1 = new docDB();// dm.DB;
                        ds1.EnforceConstraints = false;
                        ds1.FileFormat.Merge(myFM.GetDocMng().DB.FileFormat);

                        docDB.DocumentDataTable doc = ds1.Document;
                        docDB.RecipientDataTable recip = ds1.Recipient;
                        // RDOMail mail = mySession.Stores.GetStoreFromID(GetTopNode(treeView1.SelectedNode).Name, missing).GetMessageFromID(oldr.id, missing);// ; mySession.Stores.DefaultStore.GetMessageFromID(lvi.Tag.ToString(), missing);
                        RDOMail mail = GetMessageFromId(oldr.id, true);
                        if (mail != null)
                        {
                            bool encrypted = false;
                            foreach (RDOAttachment att in mail.Attachments)
                            {
                                if (att.FileName.EndsWith(".p7m"))
                                    encrypted = true;
                            }
                            if (encrypted)
                            {
                                string p7msg = LawMate.Properties.Resources.p7mMessage; //"LawMate has scanned this message and it appears that part or all if it is still secured (encrypted):\n\n\n          Subject: {0}\n          Received: {1}\n\n\nIt is possible that this message has been unsecured (decrypted) but that Outlook has not removed all traces of its previously secured (encrypted) status.\n\nYou may choose to import this message if you are sure that it is no longer secured (decrypted) - if you can read the body of the message in the Outlook Browser, it is probably acceptable to import this message.\n\nDo you want to continue to import this message to LawMate?";

                                if (MessageBox.Show(String.Format(p7msg, mail.Subject, mail.ReceivedTime.ToString("f"), "Atrium"), "Encrypted Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                    skip = false;
                                else
                                    skip = true;
                            }

                            if (oldr.HasErrors)
                            {
                                //bool encrypted = false;
                                //foreach (RDOAttachment att in mail.Attachments)
                                //{
                                //    if (att.FileName.EndsWith(".p7m"))
                                //        encrypted = true;
                                //}
                                //if (encrypted)
                                //{
                                //    MessageBox.Show(String.Format("You cannot import '{0}' because it is encrypted", mail.Subject));
                                //    skip = true;
                                //}
                                //else
                                //{
                                //MessageBox.Show(String.Format("'{0}' cannot be imported because there are errors with the message.\n\r{1}", mail.Subject, oldr.RowError));
                                if (MessageBox.Show(String.Format("Some attachment(s) on '{0}' cannot be imported.\n\r{1}\n\rImport message anyways?", mail.Subject, oldr.RowError), "Import Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    skip = false;
                                else
                                    skip = true;
                                //}
                            }
                            else if (!mail.Sent)
                            {
                                MessageBox.Show(String.Format("'{0}' cannot be imported because it is a draft.", mail.Subject));
                                skip = true;
                            }

                            if (!skip)
                            {
                                //this code seems to ignore if we have selected IgnoreThread option
                                if (oldr.IsFileIdNull() || oldr.FileId == -1)
                                    oldr.FileId = ImportFileId;

                                if (mail.MessageClass.ToUpper().StartsWith("IPM.NOTE") || mail.MessageClass.ToUpper().StartsWith("REPORT.IPM.NOTE"))
                                {
                                    docDB.DocumentRow dr = ImportMsg(ds1, recip, mail);



                                    if (acsr == null)
                                    {
                                        FileManager fmC = AtMng.GetFile(oldr.FileId);
                                        DocManager dm = fmC.GetDocMng();
                                        docDB.DocumentRow drNew = (docDB.DocumentRow)dm.GetDocument().Add(fmC.CurrentFile);
                                        dm.GetDocContent().Add(drNew);
                                        AtMng.ImportEmail(dr, dm, drNew);
                                       
                                        UIHelper.ImportConvertMail(MainForm, fmC, acsrMail.ACSeriesId, drNew.DocId);

                                        if (movedToLM == null)
                                            mail.Delete(redDeleteFlags.dfMoveToDeletedItems);
                                        else
                                            mail.Move(movedToLM);
                                    }
                                    else
                                    {
                                        if (mail.MessageClass.ToUpper().StartsWith("REPORT.IPM.NOTE"))
                                            acsr = AtMng.acMng.DB.ACSeries.FindByACSeriesId(AtMng.GetSetting(AppIntSetting.ImportReadReceiptID));

                                        int acid = MainForm.AtMng.ImportOutlookItems(ds1, createBFs, oldr.FileId, acsr);

                                        FileManager fm = MainForm.AtMng.GetFile(oldr.FileId);

                                        //create bfs for filing
                                        ActivityConfig.ACBFRow arcb = (ActivityConfig.ACBFRow)MainForm.AtMng.acMng.DB.ACBF.Select("BFCODE='NEML'")[0];
                                        atriumDB.ActivityRow arNew = fm.DB.Activity.FindByActivityId(acid);
                                        fm.GetActivity().CreateBFsForFiling(arNew, arcb, bfofficers);

                                        if (checkForAutoChain && acid != 0 && acsr.AutoChain)
                                        {
                                            fm.CurrentActivityProcess.CurrentACE = null;
                                            this.MainForm.LaunchNextSteps(oldr.FileId, acid);
                                        }
                                        else if (checkForAutoChain && acid != 0 && mailAction != ConnectorType.Obsolete)
                                        {
                                            fm.CurrentActivityProcess.CurrentACE = null;
                                            oldr.SetFileIdNull();
                                            if (createBFs)
                                                lmWinHelper.ReplyForward(fm, acid, mailAction, true);
                                            else
                                                lmWinHelper.ReplyForward(fm, acid, mailAction, true);
                                        }
                                        else
                                        {
                                            fm.CurrentActivityProcess.CurrentACE.Save(createBFs, true);
                                            fm.CurrentActivityProcess.CurrentACE = null;
                                        }
                                    }
                                    if (movedToLM == null)
                                        mail.Delete(redDeleteFlags.dfMoveToDeletedItems);
                                    else
                                        mail.Move(movedToLM);

                                    toRecheck.Add(oldr.ConversationIndex);

                                    oldr.Delete();
                                    RDOFolder fld = GetRDOFolder(treeView1.SelectedNode);
                                    SetPanelMailCount(fld.Name, fld.Items.Count.ToString());
                                }
                                else if (mail.MessageClass.ToUpper().StartsWith("IPM.SCHEDULE.MEETING.REQUEST"))
                                {
                                    docDB.DocumentRow dr = ImportMsg(ds1, recip, mail);


                                    int acid = MainForm.AtMng.ImportOutlookItems(ds1, createBFs, oldr.FileId, acsr);

                                    if (checkForAutoChain && acid != 0 && acsr.AutoChain)
                                    {
                                        this.MainForm.LaunchNextSteps(oldr.FileId, acid);
                                    }
                                    toRecheck.Add(oldr.ConversationIndex);

                                    oldr.Delete();
                                    RDOFolder fld = GetRDOFolder(treeView1.SelectedNode);
                                    SetPanelMailCount(fld.Name, fld.Items.Count.ToString());
                                }
                                //else if (mail.MessageClass.ToUpper() == "IPM.NOTE.SM.ENCRYPTED")
                                //{

                                //}
                                else
                                {
                                    MessageBox.Show(String.Format("'{0}' is not a type of message that can be imported into LawMate.", mail.Subject));
                                }
                            }
                        }
                    }
                    foreach (string ci in toRecheck)
                    {
                        FindOnCI(ci);
                    }
                    TreeNode nd = treeView1.SelectedNode;
                    TreeNode top = GetTopNode(nd);
                    //LoadMAil(mySession.Stores.GetStoreFromID(top.Name, missing).GetFolderFromID(nd.Name, missing));

                    if (CurrentRow() != null)
                        DisplayMail(CurrentRow().id);
                    else
                        ucDocView1.NoAssociatedDocument("");
                    //ucDoc1.NoAssociatedDocument("");
                }
            }
            catch (Exception x)
            {
                //      Cursor.Current = Cursors.Default;
                UIHelper.HandleUIException(x);
            }
            //    Cursor.Current = Cursors.Default;

        }
        private void ProvideUserFeedback(appDB.EFileSearchRow efsr, bool MovedToLMIsNull, int itemCount, int movedCount)
        {
            string sMessage;
            string sPart;

            if (itemCount == 1)
            {
                sMessage = LawMate.Properties.Resources.SelectedMessageSuccessfullyImported;
                sPart = LawMate.Properties.Resources.TheSelectedMessageHasBeenMoved;
            }
            else
            {
                sMessage = String.Format(LawMate.Properties.Resources.SelectedMessagesSuccessfullyImported, movedCount, itemCount);
                sPart = String.Format(LawMate.Properties.Resources.TheSelectedMessagesHaveBeenMoved, movedCount, itemCount);
            }

            sMessage += String.Format(LawMate.Properties.Resources.ImportedToNameNumber, efsr.Name, efsr.FullFileNumber);

            if (MovedToLMIsNull)
                sMessage += sPart + LawMate.Properties.Resources.ToYourDeletedItemsFolderInOutlook;
            else
                sMessage += sPart + LawMate.Properties.Resources.ToYourMovedToLawMateFolderInOutlook;


            MessageBox.Show(sMessage, LawMate.Properties.Resources.MessagesImportedToLawMate, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private docDB.DocumentRow ImportMsg(docDB ds1, docDB.RecipientDataTable recip, RDOMail mail)
        {

            docDB.DocumentRow dr = AddMail(ds1, mail);

            try
            {
                if (mail.Sender == null)
                {
                    AddRecipient(recip, "[No name]", "[No address]", "0", dr);
                }
                else
                {
                    AddRecipient(recip, mail.SenderName, mail.Sender.SMTPAddress, "0", dr);
                }

                foreach (RDORecipient r in mail.Recipients)
                {
                    AddRecipient(recip, r, dr);
                }
            }
            catch (Exception x)
            {
                throw new LMException("Atrium could not obtain a recipient's email address.  Please try again.", x);
            }
            CurrentRow().RowError = "";

            foreach (RDOAttachment att in mail.Attachments)
            {
                AddAttachment(ds1, att, dr);
            }

            ds1.AcceptChanges();
            return dr;
        }

        private docDB.DocumentRow AddMail(docDB docDS, RDOMail mail)
        {
            try
            {
                docDB.DocumentRow dr = docDS.Document.NewDocumentRow();
                docDB.DocContentRow dcr = docDS.DocContent.NewDocContentRow();

                tmpDocId++;
                dr.DocId = tmpDocId;
                dr.DocRefId = dr.DocId;
                //if (mail.Subject != null && mail.Subject.Length > 128)
                //    dr.efSubject = mail.Subject.Substring(0, 128);
                //else
                //    dr.efSubject = mail.Subject;

                if (mail.Subject != null)
                    dr.efSubject = atriumBE.DocumentBE.VerifySubjectLength(mail.Subject);

                if (mail.ReceivedTime > DateTime.Today.AddYears(10))
                {
                    dr.efDate = DateTime.Today;
                    dr.ReceivedTime = DateTime.UtcNow;
                }
                else
                {
                    dr.efDate = mail.ReceivedTime.Date;
                    dr.ReceivedTime = mail.ReceivedTime.ToUniversalTime();
                }
                dr.SentTime = mail.ReceivedTime.ToUniversalTime();
                dr.CommMode = "EML";
                dr.efType = "MEM";
                dr.Source = "Outlook LawmateFiler";
                dr.isLawmail = true;

                dr.ConversationIndex = mail.ConversationIndex;
                if (dr.IsConversationIndexNull())
                {
                    //set it to a valid index
                    try
                    {
                        MAPIUtils mapiUtil = DocumentBE.MAPIUtils();
                        dr.ConversationIndex = mapiUtil.ScCreateConversationIndex("");
                    }
                    catch (Exception xRDO)
                    {

                        //this is the correct way
                        string g = Guid.NewGuid().ToString("N");  //32 char guid
                        string t = "CF4E8797C7"; //10 char representing FILETIME - faked for now
                        dr.ConversationIndex = "01" + t + g;

                    }
                }
                dr.isElectronic = true;
                dr.isPaper = false;
                dr.IsDraft = false;

                dr.CurrentVersion = "1";
                //dr.efFrom = mail.SenderName;
                //dr.efTo=mail.Recipients.

                //file attributes
                //string tmpFilename = System.IO.Path.GetTempPath();
                //tmpFilename += @"\~lmfile" + DateTime.Now.Ticks.ToString();
                //Outlook.OlSaveAsType mode;
                switch ((rdoBodyFormat)mail.BodyFormat)
                {
                    case rdoBodyFormat.olFormatHTML:
                        dcr.ContentsAsText = mail.HTMLBody;
                        dcr.Ext = ".htm";
                        break;
                    case rdoBodyFormat.olFormatRichText:

                        dcr.ContentsAsText = mail.RTFBody;

                        //dcr.Contents = System.Text.Encoding.GetEncoding(mail.InternetCodepage).GetBytes(mail.RTFBody);

                        //dcr.Contents = System.Text.Encoding.UTF8.GetBytes(mail.RTFBody);

                        dcr.Ext = ".rtf";
                        break;
                    case rdoBodyFormat.olFormatPlain:
                    case rdoBodyFormat.olFormatUnspecified:
                    default:
                        dcr.ContentsAsText = mail.Body;
                        dcr.Ext = ".txt";
                        break;
                }
                dr.ext = dcr.Ext;
                //mail.SaveAs(tmpFilename, mode);

                //System.IO.FileInfo fi = new System.IO.FileInfo(tmpFilename);

                dcr.DocId = dr.DocId;
                //dcr.Ext = fi.Extension;
                //dcr.Size = (int)fi.Length;
                dcr.CreateDate = DateTime.Now;
                dcr.ModDate = DateTime.Now;
                // 2013-06-12 JLL: update to use isDraft only
                //dcr.ReadOnly = false;

                dcr.Version = "1";
                //string temp = mail.Subject + dcr.Ext;
                //foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                //{
                //    temp = temp.Replace(c, '_');
                //}
                //dr.Name = temp;

                if (!dcr.IsContentsNull())
                    dcr.Size = dcr.Contents.Length;
                //dcr.Contents = System.IO.File.ReadAllBytes(tmpFilename);

                docDS.Document.AddDocumentRow(dr);
                docDS.DocContent.AddDocContentRow(dcr);

                //System.IO.File.Delete(tmpFilename);

                return dr;
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine(x.Message);
                return null;
            }
        }

        private void AddAttachment(docDB ds1, RDOAttachment att, docDB.DocumentRow parent)
        {
            try
            {
                docDB.DocumentDataTable doc = ds1.Document;
                docDB.DocumentRow dr = doc.NewDocumentRow();
                docDB.DocContentRow dcr = ds1.DocContent.NewDocContentRow();


                tmpDocId++;
                dr.DocId = tmpDocId;
                dr.DocRefId = dr.DocId;
                //dr.AttachedToId = parent.DocId;
                dr.CurrentVersion = "1";


                //file attributes
                string tmpFilename = System.IO.Path.GetTempPath();
                tmpFilename += @"\~lmfile" + att.FileName;
                if (System.IO.Path.GetExtension(tmpFilename) == "")
                    tmpFilename += ".bmp";
                att.SaveAsFile(tmpFilename);

                //System.IO.FileInfo fi = new System.IO.FileInfo(tmpFilename);

                dcr.DocId = dr.DocId;
                dcr.Version = "1";
                doc.AddDocumentRow(dr);
                ds1.DocContent.AddDocContentRow(dcr);

                DocumentBE.LoadFileX(dr, tmpFilename);

                //if (att.DisplayName.Length > 128)
                //    dr.efSubject = att.DisplayName.Substring(0, 128);
                //else
                //    dr.efSubject = att.DisplayName;

                dr.efDate = parent.efDate;
                //    dr.ReceivedTime = parent.ReceivedTime;
                dr.efType = "ATT";
                dr.CommMode = "EML";
                dr.Source = "Outlook LawmateFiler";
                if (!parent.IsConversationIndexNull())
                {
                    dr.ConversationIndex = parent.ConversationIndex;
                }
                dr.isElectronic = true;
                dr.isPaper = false;
                dr.IsDraft = false;
                dr.isLawmail = false;

                string temp = att.FileName;
                dr.efSubject = DocumentBE.VerifySubjectLength(System.IO.Path.GetFileNameWithoutExtension(temp));

                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    temp = temp.Replace(c, '_');
                }
                //dr.Name = temp;
                dr.ext = dcr.Ext;
                //     dcr.Contents = System.IO.File.ReadAllBytes(tmpFilename);


                //add attachment record
                docDB.AttachmentRow attR = ds1.Attachment.NewAttachmentRow();
                attR.Id = tmpAttid++;

                attR.AttachmentId = dr.DocId;
                attR.MsgId = parent.DocId;
                ds1.Attachment.AddAttachmentRow(attR);

                System.IO.File.Delete(tmpFilename);

            }
            catch (Exception x)
            {
                CurrentRow().RowError += "Attachment '" + att.DisplayName + "' has a problem and cannot be imported.\n\r[" + x.Message + "]\n\r";
                //UIHelper.HandleUIException(x);
                System.Diagnostics.Debug.WriteLine(x.Message);
            }
        }

        private void AddRecipient(docDB.RecipientDataTable recDt, string name, string address, string type, docDB.DocumentRow parent)
        {
            docDB.RecipientRow rr = recDt.NewRecipientRow();
            rr.RecipId = tmpRecipId++;
            rr.DocId = parent.DocId;
            rr.Type = type;
            rr.Address = address;
            rr.AddressType = "SMTP";
            rr.Name = name;


            recDt.AddRecipientRow(rr);

        }

        //not used anymore CJW 2016-8-2
        //private void AddRecipient(docDB.RecipientDataTable recDt, RDOAddressEntry ae, string type, docDB.DocumentRow parent)
        //{
        //    docDB.RecipientRow rr = recDt.NewRecipientRow();
        //    rr.RecipId = tmpRecipId++;
        //    rr.DocId = parent.DocId;
        //    rr.Type = type;
        //    rr.Address = ae.Address;
        //    rr.Name = ae.Name;


        //    recDt.AddRecipientRow(rr);

        //}

        private void AddRecipient(docDB.RecipientDataTable recDt, RDORecipient recip, docDB.DocumentRow parent)
        {
            docDB.RecipientRow rr;
            //need to handle distribution lists
            switch (recip.DisplayType)
            {
                case 1://exchange dl
                    rr = recDt.NewRecipientRow();
                    rr.RecipId = tmpRecipId++;
                    rr.DocId = parent.DocId;
                    rr.Type = recip.Type.ToString();
                    if (recip.AddressEntry.SMTPAddress != null)
                    {
                        rr.AddressType = "SMTP";
                        rr.Address = recip.AddressEntry.SMTPAddress;
                    }
                    else
                    {
                        rr.AddressType = "X400";
                        rr.Address = recip.Address;
                    }
                    rr.Name = recip.Name;
                    recDt.AddRecipientRow(rr);

                    //TODO:this bit shouldn't be here
                    //the calc recip bf code should create bfs for the dl members who are in lawmate
                    //foreach (RDOAddressEntry ae in recip.AddressEntry.Members)
                    //{
                    //    rr = recDt.NewRecipientRow();
                    //    rr.RecipId = tmpRecipId++;
                    //    rr.DocId = parent.DocId;
                    //    rr.Type = recip.Type.ToString();
                    //    if (ae.SMTPAddress == null)
                    //        rr.Address = ae.Address;
                    //    else
                    //        rr.Address = ae.SMTPAddress;
                    //    rr.Name = ae.Name;
                    //    rr.AddressType = "DLX";
                    //    recDt.AddRecipientRow(rr);
                    //}
                    break;
                default:
                    if (recip.AddressEntry != null)
                    {
                        rr = recDt.NewRecipientRow();
                        rr.RecipId = tmpRecipId++;
                        rr.DocId = parent.DocId;
                        rr.Type = recip.Type.ToString();
                        if (recip.AddressEntry.SMTPAddress == null)
                        {
                            rr.Address = recip.Address;
                            rr.AddressType = "X400";
                        }
                        else
                        {
                            rr.Address = recip.AddressEntry.SMTPAddress;
                            rr.AddressType = "SMTP";
                        }
                        rr.Name = recip.Name;
                        recDt.AddRecipientRow(rr);
                    }
                    break;
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {

            try
            {

                switch (e.Command.Key)
                {
                    case "cmdJumpToFile":
                        outlookGridEX.UpdateData();
                        if (!CurrentRow().IsFileIdNull())
                            MainForm.OpenFile(CurrentRow().FileId);
                        break;
                    case "cmdFieldChooser":
                        outlookGridEX.ShowFieldChooser(this, LawMate.Properties.Resources.FieldSelector);
                        break;
                    case "cmdNew":
                        RDOFolder fld = GetRDOFolder(treeView1.SelectedNode);

                        RDOFolder newFld = fld.Folders.Add("New folder", missing);
                        TreeNode nd = treeView1.SelectedNode.Nodes.Add(newFld.EntryID, "New folder");
                        //nd.ImageIndex = 7;
                        //nd.SelectedImageIndex = 5;

                        break;
                    case "cmdResetGrid":
                        if (gridLayoutStream != null)
                        {
                            gridLayoutStream.Position = 0;
                            HookUpDataSource();
                            outlookGridEX.LoadLayoutFile(gridLayoutStream);
                            UIHelper.GridToggleSelectMode(outlookGridEX);
                            UIHelper.ComboBoxInit(threadMatchDT, outlookGridEX.DropDowns["ddFile"], myFM);
                            SetCommandsState();
                            outlookGridEX.Refetch();
                        }
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                    case "cmdMove":
                        fOutlookFolder fo = new fOutlookFolder(mySession);
                        if (fo.ShowDialog(this) == DialogResult.OK)
                        {
                            MoveToFolder(fo.SelectedFolder);
                        }
                        break;
                    case "cmdReset":
                        TreeNode nd1 = treeView1.SelectedNode;
                        TreeNode top = GetTopNode(nd1);
                        LoadMAil(mySession.Stores.GetStoreFromID(top.Name, missing).GetFolderFromID(nd1.Name, missing));

                        break;
                    case "cmdReply":
                    case "cmdReplyAll":
                    case "cmdForward":
                        ConnectorType mailAction = ConnectorType.Obsolete;
                        switch (e.Command.Key)
                        {
                            case "cmdReply":
                                mailAction = ConnectorType.Reply;
                                break;
                            case "cmdReplyAll":
                                mailAction = ConnectorType.ReplyAll;
                                break;
                            case "cmdForward":
                                mailAction = ConnectorType.Forward;
                                break;

                        }
                        outlookGridEX.UpdateData();

                        if (IsAttemptingToFileDuplicate())
                            Import(true, acsrMail, mailAction, false);

                        break;
                    case "cmdImportAs":

                        outlookGridEX.UpdateData();

                        if (IsAttemptingToFileDuplicate())
                            Import(false, null, ConnectorType.Obsolete, false);

                        break;
                    case "cmdFiling":

                        outlookGridEX.UpdateData();


                        if (IsAttemptingToFileDuplicate())
                            Import(false, acsrMail, ConnectorType.Obsolete, false);
                        break;
                    case "cmdFilingBF":

                        outlookGridEX.UpdateData();


                        if (IsAttemptingToFileDuplicate())
                            Import(false, acsrMail, ConnectorType.Obsolete, true);
                        break;

                    case "cmdImportAction":

                        outlookGridEX.UpdateData();


                        if (IsAttemptingToFileDuplicate())
                            Import(true, acsrMail, ConnectorType.Obsolete, false);
                        break;
                    case "cmdClose":
                        this.Close();
                        break;
                    case "cmdDocPreview":
                        if (!e.Command.IsChecked)
                        {
                            uiPanel1.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
                            uiPanel2.Closed = false;
                            if (CurrentRow() != null)
                                DisplayMail(CurrentRow().id);
                        }
                        else
                        {
                            uiPanel2.Closed = true;
                            uiPanel1.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;

                        }
                        break;
                    case "cmdFilter":
                        if (e.Command.IsChecked)
                            outlookGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            outlookGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "cmdGroupBy":
                        if (e.Command.IsChecked)
                            outlookGridEX.GroupByBoxVisible = true;
                        else
                        {
                            outlookGridEX.RootTable.Groups.Clear();
                            outlookGridEX.GroupByBoxVisible = false;
                        }
                        break;
                }
                if (e.Command.Key.StartsWith("tsConvertAC"))
                {
                    ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)e.Command.Tag;
                    outlookGridEX.UpdateData();
                    Import(false, acsr, ConnectorType.Obsolete, false);

                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private int CheckThreadDuplicateCellValue(Janus.Windows.GridEX.GridEXSelectedItem gsi)
        {
            return CheckThreadDuplicateCellValue(gsi.GetRow());
        }

        private int CheckThreadDuplicateCellValue(Janus.Windows.GridEX.GridEXRow gsi)
        {
            if (gsi.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                try
                {
                    if ((int)gsi.Cells["ThreadDuplicate"].Value == 2)
                        return 1;
                }
                catch (Exception x)
                {
                    return 0;
                }
            }
            return 0;
        }
        private bool IsAttemptingToFileDuplicate()
        {
            bool AllowFiling = true;
            if (outlookGridEX.SelectionMode != Janus.Windows.GridEX.SelectionMode.SingleSelection)
            {
                if (UIHelper.GridGetSelectedCount(outlookGridEX) == 1)
                {
                    if (CheckThreadDuplicateCellValue(outlookGridEX.SelectedItems[0]) == 1)
                    {
                        //trying to import duplicate
                        string smessage = "You are trying to import an item that is already filed in LawMate.\n\nIf you attempt to file a duplicate item to the same file as where the duplicate is stored, LawMate will ignore to import the item.\n\nAre you sure you want to proceed?\n\nSubject: " + outlookGridEX.SelectedItems[0].GetRow().Cells["Subject"].Value + "\nReceived: " + outlookGridEX.SelectedItems[0].GetRow().Cells["ReceivedTime"].Value;
                        if (MessageBox.Show(smessage, "Import Duplicate Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            AllowFiling = false;
                    }
                }
                else if (UIHelper.GridGetSelectedCount(outlookGridEX) > 1)
                {
                    int DupCount = 0;
                    foreach (Janus.Windows.GridEX.GridEXSelectedItem gsi in outlookGridEX.SelectedItems)
                    {
                        DupCount += CheckThreadDuplicateCellValue(gsi);
                    }
                    if (DupCount > 0)
                    {
                        string smessage = "You are trying to import " + DupCount.ToString() + " items that are already filed in LawMate.\n\nIf you attempt to file a duplicate item to the same file as where the duplicate is stored, LawMate will ignore to import the item.\n\nAre you sure you want to proceed?";
                        if (MessageBox.Show(smessage, "Import Duplicate Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            AllowFiling = false;
                    }
                }
            }
            else
            {
                int DupCount = 0;
                foreach (Janus.Windows.GridEX.GridEXRow gsi in outlookGridEX.GetCheckedRows())
                {
                    DupCount += CheckThreadDuplicateCellValue(gsi);
                }
                if (DupCount > 0)
                {
                    string smessage = "";
                    if (DupCount == 1)
                        smessage = "You are trying to import an item that is already filed in LawMate.\n\nIf you attempt to file a duplicate item to the same file as where the duplicate is stored, LawMate will ignore to import the item.\n\nAre you sure you want to proceed?\n\nSubject: " + outlookGridEX.SelectedItems[0].GetRow().Cells["Subject"].Value + "\nReceived: " + outlookGridEX.SelectedItems[0].GetRow().Cells["ReceivedTime"].Value;
                    else
                        smessage = "You are trying to import " + DupCount.ToString() + " items that are already filed in LawMate.\n\nIf you attempt to file a duplicate item to the same file as where the duplicate is stored, LawMate will ignore to import the item.\n\nAre you sure you want to proceed?";
                    if (MessageBox.Show(smessage, "Import Duplicate Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        AllowFiling = false;
                }
            }
            return AllowFiling;
        }


        private void Delete()
        {
            List<DataRow> toAction = UIHelper.GridGetSelectedData(outlookGridEX);
            foreach (lmDatasets.appDB.OutlookRow oldr in toAction)
            {
                //RDOMail mail = mySession.Stores.GetStoreFromID(GetTopNode(treeView1.SelectedNode).Name, missing).GetMessageFromID(oldr.id, missing);
                RDOMail mail = GetMessageFromId(oldr.id, true);
                if (mail != null)
                {

                    mail.Delete(redDeleteFlags.dfMoveToDeletedItems);
                    //listView1.Items.Remove(lvi);
                    oldr.Delete();
                    //jll 2010/12/23 - updated mail count in panel text
                }
            }

            TreeNode nd = treeView1.SelectedNode;
            TreeNode top = GetTopNode(nd);
            RDOFolder fld = GetRDOFolder(treeView1.SelectedNode);
            SetPanelMailCount(fld.Name, fld.Items.Count.ToString());

            //LoadMAil(mySession.Stores.GetStoreFromID(top.Name, missing).GetFolderFromID(nd.Name, missing));
            if (CurrentRow() != null)
                DisplayMail(CurrentRow().id);
            else
                ucDocView1.NoAssociatedDocument("");
            //ucDoc1.NoAssociatedDocument("");
        }

        private void MoveToFolder(RDOFolder fld)
        {
            List<DataRow> toAction = UIHelper.GridGetSelectedData(outlookGridEX);
            foreach (lmDatasets.appDB.OutlookRow oldr in toAction)
            {


                // RDOMail mail = mySession.Stores.GetStoreFromID(GetTopNode(treeView1.SelectedNode).Name, missing).GetMessageFromID(oldr.id, missing);
                RDOMail mail = GetMessageFromId(oldr.id, true);
                if (mail != null)
                {

                    mail.Move(fld);
                    //listView1.Items.Remove(lvi);
                    oldr.Delete();
                }
            }

            TreeNode nd = treeView1.SelectedNode;
            TreeNode top = GetTopNode(nd);
            RDOFolder mailfolder = GetRDOFolder(treeView1.SelectedNode);
            SetPanelMailCount(mailfolder.Name, mailfolder.Items.Count.ToString());

            //LoadMAil(mySession.Stores.GetStoreFromID(top.Name, missing).GetFolderFromID(nd.Name, missing));
            if (CurrentRow() != null)
                DisplayMail(CurrentRow().id);
            else
                ucDocView1.NoAssociatedDocument("");
            //ucDoc1.NoAssociatedDocument("");
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                LoadFolder(e.Node);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void LoadFolder(TreeNode tn)
        {
            //            SelectedPage = 0;
            RDOFolder fld = GetRDOFolder(tn);
            if (tn.Tag == "Store")
            {

                LoadFolders(tn, fld);  //
            }
            else
            {
                //uiPanel1.Text = tn.Text;
                SetPanelMailCount(fld.Name, fld.Items.Count.ToString());
                TreeNode top = GetTopNode(tn);
                LoadMAil(fld);
            }
        }



        private void outlookBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public appDB.OutlookRow CurrentRow()
        {
            if (outlookBindingSource.Current == null)
                return null;
            else
                return (appDB.OutlookRow)((DataRowView)outlookBindingSource.Current).Row;
        }

        private void outlookGridEX_ColumnHeaderClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                SetSortBy(e.Column.Key);

                SortDescending = (e.Column.SortOrder == Janus.Windows.GridEX.SortOrder.Descending);
                //LoadFolder(treeView1.SelectedNode);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void SetSortBy(string col)
        {
            switch (col)
            {
                case "From":
                    SortBy = "SenderName";
                    break;
                case "Subject":
                    SortBy = "Subject";
                    break;
                case "ReceivedTime":
                    SortBy = "ReceivedTime";
                    break;
                case "Size":
                    SortBy = "Size";
                    break;
                case "To":
                    SortBy = "To";
                    break;
                default:
                    //SortDescending = true ;
                    //SortBy = "ReceivedTime";
                    break;
            }
        }

        private void outlookGridEX_RowDrag(object sender, Janus.Windows.GridEX.RowDragEventArgs e)
        {
            try
            {
                //DragDropEffects d = outlookGridEX.DoDragDrop("outlookitems", DragDropEffects.Move);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                //get treenode
                Point p = treeView1.PointToClient(new Point(e.X, e.Y));
                TreeNode nd = treeView1.HitTest(p).Node;
                if (nd != null)
                {
                    RDOFolder fld = GetRDOFolder(nd);
                    MoveToFolder(fld);

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                //get treenode
                Point p = treeView1.PointToClient(new Point(e.X, e.Y));
                TreeNode nd = treeView1.HitTest(p).Node;
                if (nd != null)
                {
                    RDOFolder fld = GetRDOFolder(nd);
                    if (fld.FolderKind == rdoFolderKind.fkGeneric && fld.DefaultItemType == (int)rdoItemType.olMailItem)
                        e.Effect = DragDropEffects.Move;
                    else
                        e.Effect = DragDropEffects.None;
                }
                else
                    e.Effect = DragDropEffects.None;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private RDOFolder GetRDOFolder(TreeNode nd)
        {
            if (nd.Tag == "Store")
            {

                return mySession.Stores.GetStoreFromID(nd.Name, missing).IPMRootFolder;
            }
            else
            {

                TreeNode top = GetTopNode(nd);
                RDOFolder fld = mySession.Stores.GetStoreFromID(top.Name, missing).GetFolderFromID(nd.Name, missing);
                return fld;
            }
        }

        List<string> threadMatch = new List<string>();
        appDB.EFileSearchThreadDataTable threadMatchDT = new appDB.EFileSearchThreadDataTable();
        private void outlookGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                int last = outlookGridEX.LastVisibleRow(false);
                if (e.Row.Position < outlookGridEX.FirstRow || e.Row.Position > last + 1)
                    return;

                if (e.Row.DataRow != null)
                {
                    //           Application.UseWaitCursor = true;
                    appDB.OutlookRow oldr = (appDB.OutlookRow)((DataRowView)e.Row.DataRow).Row;
                    CheckThreading(e, oldr);
                    //            Application.UseWaitCursor = false;
                    ApplyThreadMatchDropDownFilter();
                }
            }
            catch (Exception x)
            {
                //        Application.UseWaitCursor = false;
                UIHelper.HandleUIException(x);
            }

        }
        private void FindOnCI(string ci)
        {
            appDB.OutlookRow[] ors = (appDB.OutlookRow[])myOLDT.Select("ConversationIndex like '" + ci.Substring(0, 44) + "%'");
            threadMatch.Remove(ci.Substring(0, 44));
            foreach (appDB.OutlookRow olr in ors)
            {
                olr.ProcessState = 0;
                CheckThreading(null, olr);
            }
        }

        Janus.Windows.GridEX.GridEXFormatStyle fs = new Janus.Windows.GridEX.GridEXFormatStyle();
        private void CheckThreading(Janus.Windows.GridEX.RowLoadEventArgs e, appDB.OutlookRow oldr)
        {
            if (oldr.ProcessState == 0)
            {
                oldr.ProcessState = 1;
                if (oldr.IsConversationIndexNull())
                {
                    oldr.FullFileNumber = "No thread";
                    oldr.DuplicateThreadMatch = 0;
                }
                else
                {
                    if (!threadMatch.Contains(oldr.ConversationIndex.Substring(0, 44)))
                    {
                        appDB.EFileSearchThreadDataTable efsDt = FindFile(oldr.ConversationIndex);
                        threadMatchDT.Merge(efsDt);
                        threadMatch.Add(oldr.ConversationIndex.Substring(0, 44));
                        // UIHelper.ComboBoxInit(threadMatchDT, outlookGridEX.DropDowns["ddFile"], myFM);

                    }
                    //string fullpath = "";
                    if (threadMatch.Contains(oldr.ConversationIndex.Substring(0, 44)))
                    {
                        ImportPerson = "";
                        appDB.EFileSearchThreadRow[] efsr = (appDB.EFileSearchThreadRow[])threadMatchDT.Select("Thread='" + oldr.ConversationIndex.Substring(0, 44) + "'");
                        if (efsr.Length > 0)
                        {
                            if (oldr.IsFileIdNull())
                            {
                                oldr.FileId = IsImported(efsr[0].FileId, oldr.ConversationIndex);

                                oldr.FileName = efsr[0].NameE;
                                if (!efsr[0].IsOfficeFileNumNull())
                                    oldr.OfficeFileNum = efsr[0].OfficeFileNum;

                                oldr.FullFileNumber = efsr[0].FullFileNumber;
                            }
                            else if (oldr.FileId == -1)
                            {
                                oldr.FileName = "";
                                oldr.OfficeFileNum = "";
                                oldr.FullFileNumber = "";
                            }
                            else
                            {
                                //set officefilenumber and name
                                foreach (appDB.EFileSearchThreadRow ef1 in efsr)
                                {
                                    if (ef1.FileId == oldr.FileId)
                                    {
                                        oldr.FileName = ef1.NameE;
                                        if (!ef1.IsOfficeFileNumNull())
                                            oldr.OfficeFileNum = ef1.OfficeFileNum;
                                        oldr.FullFileNumber = ef1.FullFileNumber;
                                    }
                                }
                            }
                            oldr.ImportedBy = ImportPerson;
                            if (ImportPerson != "")
                            {
                                oldr.ImportedDate = ImportDate;
                                oldr.DuplicateThreadMatch = 2;
                            }
                            else
                                oldr.DuplicateThreadMatch = 1;

                            if (efsr.Length > 1) //format grid to display more than one thread match
                            {
                                Janus.Windows.GridEX.GridEXRow ger = null;
                                if (e != null) // found row off event argument;
                                    ger = e.Row;
                                else // try and find row using gridex GetRow
                                    ger = outlookGridEX.GetRow(oldr);

                                if (ger != null)
                                    ger.Cells["FullFileNumber"].FormatStyle = fs;

                            }
                        }
                    }
                }
            }
        }


        private void outlookGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bkw = (BackgroundWorker)sender;

            if (!uiStatusBar1.Panels["StatusMessage"].Text.StartsWith("Retrieving messages..."))
            {
                uiStatusBar1.Panels["StatusMessage"].Text = "Retrieving messages...";
                uiStatusBar1.Panels["StatusMessage"].Image = LawMate.Properties.Resources.warning_16x16;
            }
            e.Result = LoadOutlookDT((string)e.Argument, bkw, e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                UIHelper.HandleUIException(e.Error);
                this.UseWaitCursor = false;
            }
            else if (!e.Cancelled)
            {
                appDB.OutlookDataTable oldt = (appDB.OutlookDataTable)e.Result;
                myOLDT.Merge(oldt);
                this.UseWaitCursor = false;
            }
            uiStatusBar1.Panels["StatusMessage"].Text = "";
            uiStatusBar1.Panels["StatusMessage"].Image = null;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            appDB.OutlookDataTable oldt = (appDB.OutlookDataTable)e.UserState;
            outlookGridEX.SuspendBinding();
            myOLDT.Merge(oldt);
            outlookGridEX.ResumeBinding();
            ToggleCommands();
            if(uiStatusBar1.Panels["StatusMessage"].Text.EndsWith("..."))
                uiStatusBar1.Panels["StatusMessage"].Text = "Retrieving messages";
            else
                uiStatusBar1.Panels["StatusMessage"].Text = uiStatusBar1.Panels["StatusMessage"].Text + " .";
            this.UseWaitCursor = false;
        }

        private void ApplyThreadMatchDropDownFilter()
        {
            if (CurrentRow() != null && !CurrentRow().IsConversationIndexNull())
            {
                Janus.Windows.GridEX.GridEXFilterCondition filt = new Janus.Windows.GridEX.GridEXFilterCondition(outlookGridEX.DropDowns["ddFile"].Columns["Thread"], Janus.Windows.GridEX.ConditionOperator.Equal, CurrentRow().ConversationIndex.Substring(0, 44));
                filt.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, new Janus.Windows.GridEX.GridEXFilterCondition(outlookGridEX.DropDowns["ddFile"].Columns["FileId"], Janus.Windows.GridEX.ConditionOperator.Equal, -1));
                outlookGridEX.DropDowns["ddFile"].ApplyFilter(filt);
            }
        }

        private void outlookBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() != null)
                {
                    DisplayMail(CurrentRow().id);

                    CurrentRow().ProcessState = 0;
                    if (!CurrentRow().IsConversationIndexNull())
                    {
                        threadMatch.Remove(CurrentRow().ConversationIndex.Substring(0, 44));
                        foreach (appDB.EFileSearchThreadRow x in threadMatchDT.Select("Thread='" + CurrentRow().ConversationIndex.Substring(0, 44) + "'"))
                        {
                            x.Delete();

                        }
                        CheckThreading(null, CurrentRow());

                        if (threadMatch.Contains(CurrentRow().ConversationIndex.Substring(0, 44)))
                        {
                            ApplyThreadMatchDropDownFilter();
                            //Janus.Windows.GridEX.GridEXFilterCondition filt = new Janus.Windows.GridEX.GridEXFilterCondition(outlookGridEX.DropDowns["ddFile"].Columns["Thread"], Janus.Windows.GridEX.ConditionOperator.Equal, CurrentRow().ConversationIndex.Substring(0, 44));
                            //filt.AddCondition(  Janus.Windows.GridEX.LogicalOperator.Or,new Janus.Windows.GridEX.GridEXFilterCondition(outlookGridEX.DropDowns["ddFile"].Columns["FileId"], Janus.Windows.GridEX.ConditionOperator.Equal, -1));
                            //outlookGridEX.DropDowns["ddFile"].ApplyFilter(filt);
                        }
                        else
                        {

                        }
                    }
                    if (CurrentRow().IsNull("FileId"))
                        cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    else
                        cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                    ToggleCommands();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void outlookGridEX_GroupsChanged(object sender, Janus.Windows.GridEX.GroupsChangedEventArgs e)
        {
            try
            {
                foreach (Janus.Windows.GridEX.GridEXGroup geg in e.Table.Groups)
                {
                    if (geg.Column.Key == "ReceivedTime")
                    {
                        geg.SortOrder = Janus.Windows.GridEX.SortOrder.Descending;
                        return;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        Stream gridLayoutStream = new MemoryStream();
        private void fOutlook_Load(object sender, EventArgs e)
        {
            try
            {
                outlookGridEX.SaveLayoutFile(gridLayoutStream); //for resetting purposes
                HookUpDataSource();
                lmWinHelper.LoadGridLayout(outlookGridEX, "OutlookGridLayout", LayoutVersionNumber);
                lmWinHelper.LoadPanelManagerLayout(uiPanelManager1, "OutlookPanelManager_" + LayoutVersionNumber);
                lmWinHelper.LoadCommandManagerLayout(uiCommandManager1, "OutlookCommandManager", LayoutVersionNumber);
                SetCommandsState();
                outlookGridEX.Refetch();
                outlookGridEX.Focus();
                outlookGridEX.MoveFirst();

                LoadStores();
                LoadFolders(treeView1.Nodes.Find(mySession.Stores.DefaultStore.EntryID, true)[0], mySession.Stores.DefaultStore.IPMRootFolder);  //
                treeView1.SelectedNode = treeView1.Nodes.Find(mySession.Stores.DefaultStore.GetDefaultFolder(rdoDefaultFolders.olFolderInbox).EntryID, true)[0];
                SetPanelMailCount(treeView1.SelectedNode.Text, mySession.Stores.DefaultStore.GetDefaultFolder(rdoDefaultFolders.olFolderInbox).Items.Count.ToString());
                //uiPanel1.Text = treeView1.SelectedNode.Text;
                uiStatusBar1.Panels["OfficerCode"].Text = MainForm.AtMng.OfficerLoggedOn.LastName + ", " + MainForm.AtMng.OfficerLoggedOn.FirstName + " (" + MainForm.AtMng.OfficerLoggedOn.OfficerCode + ")";
                //LoadMAil(mySession.Stores.DefaultStore.GetDefaultFolder(rdoDefaultFolders.olFolderInbox));

                cmdImportAs.Commands.Clear();
                UIHelper.DoConvertMenu(0, cmdImportAs, acsrMail, false, true);
                if (acsrMail.GetACConvertRowsByACSeries_ACConvert().Length == 0)
                {
                    cmdImportAs.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }
                //if (cmdImportAs.Commands.Count == 0)
                //    cmdImportAs.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void HookUpDataSource()
        {
            outlookBindingSource.DataSource = myOLDT;
        }

        private void SetCommandsState()
        {
            cmdFilter.IsChecked = (outlookGridEX.FilterMode != Janus.Windows.GridEX.FilterMode.None);
            cmdGroupBy.IsChecked = outlookGridEX.GroupByBoxVisible;
            cmdDocPreview.IsChecked = uiPanel2.Closed;

            outlookGridEX.RemoveFilters();
        }

        private void fOutlook_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (currentbkw != null && currentbkw.IsBusy)
                {
                    currentbkw.CancelAsync();
                }

                lmWinHelper.SaveGridLayout(outlookGridEX, "OutlookGridLayout", AtMng, LayoutVersionNumber);
                lmWinHelper.SavePanelManagerLayout(uiPanelManager1, "OutlookPanelManager", AtMng);
                lmWinHelper.SaveCommandManagerLayout(uiCommandManager1, "OutlookCommandManager", AtMng, LayoutVersionNumber);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void outlookGridEX_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(outlookGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiPanelManager1_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(uiPanelManager1);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(uiCommandManager1);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                RDOFolder fld = GetRDOFolder(e.Node);
                fld.Name = e.Label;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
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

        private void outlookGridEX_RowCheckStateChanged(object sender, Janus.Windows.GridEX.RowCheckStateChangeEventArgs e)
        {
            ToggleCommands();
        }

        private void ToggleCommands()
        {
            if (UIHelper.GridGetSelectedCount(outlookGridEX) > 0)
            {
                cmdImportAction.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdImport.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdFiling.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdFilingBF.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdMove.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                if (UIHelper.GridGetSelectedCount(outlookGridEX) == 1)
                {

                    cmdImport.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                    cmdReply.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    cmdImport.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                    cmdReply.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                }
            }
            else
            {
                // cmdActions.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdImportAction.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdImport.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdFiling.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdFilingBF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdMove.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                cmdReply.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        private void outlookGridEX_SelectionChanged(object sender, EventArgs e)
        {
            ToggleCommands();
        }

        private void outlookGridEX_CellEdited(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            e.Column.GridEX.UpdateData();
            if (e.Column.Key == "FullFileNumber")
            {
                appDB.OutlookRow olr = CurrentRow();
                olr.ProcessState = 0;
                olr.EndEdit();
                CheckThreading(null, olr);
            }
        }
    }

}

