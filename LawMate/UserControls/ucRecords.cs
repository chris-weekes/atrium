using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using atriumBE;
using lmDatasets;

 namespace LawMate
{
    public partial class ucRecords : ucBase
    {

        private global::System.Object missing = global::System.Type.Missing;
        atriumBE.DocManager myDM;
        bool LoadPreview = true;

        public ucRecords()
        {
            InitializeComponent();
            //ucDocPreview1.ReturnFocusTo = ucRecordList1;
            //ucDocPreview1.DocLoaded += new UserControls.DocLoadedEventHandler(ucDocPreview1_DocLoaded);
            ucDocView1.ReturnFocusTo = ucRecordList1;
            ucDocView1.DocLoaded += new UserControls.DocLoadedEventHandler(ucDocPreview1_DocLoaded);

            ucRecordList1.RecordsGridEx.DynamicFiltering = true;
            ucRecordList1.RecordsGridEx.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
        }

        private bool showToolbar = true;
        public bool ShowToolbar
        {
            get { return showToolbar; }
            set
            {
                showToolbar = value;
                uiCommandBar1.Visible = showToolbar;
                uiCommandBar2.Visible = showToolbar;
                if (showToolbar)
                    ucRecordList1.RecordsGridEx.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
                else
                    ucRecordList1.RecordsGridEx.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            }
        }

        private bool showDocument = true;
        public bool ShowDocument
        {
            get { return showDocument; }
            set
            {
                showDocument = value;
                //uiPanel1.Closed = !showDocument;
                HidePreviewPane(showDocument);
            }
        }

        private bool allowDocMetaDataUpdate = true;
        public bool AllowDocMetaDataUpdate
        {
            get { return allowDocMetaDataUpdate; }
            set
            {
                allowDocMetaDataUpdate = value;
                //ucDocPreview1.AllowRecipientSubjectEditWhenNotMail = allowDocMetaDataUpdate;
                ucDocView1.AllowMetadataUpdate = allowDocMetaDataUpdate;
            }
        }


        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.Document;
        }
        void ucDocPreview1_DocLoaded(object sender, UserControls.DocLoadedEventArgs e)
        {
            ApplySecurity(CurrentRow());
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void MoreInfo(string linkTable, string filter)
        {
            documentBindingSource.Filter = filter;

            NoData(this.ucRecordList1.RecordsGridEx.RowCount == 0);
         
        }
        public override void MoreInfo(string linkTable, int linkId)
        {
            documentBindingSource.Filter = null;
            documentBindingSource.Position = documentBindingSource.Find("DocId", linkId);
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        private DataColumnChangeEventHandler dcceh;
        private atLogic.UpdateEventHandler ueh;

        bool firstTime = true;
        public void BindDocumentData(lmDatasets.docDB.DocumentDataTable a, bool DocSearchResults, atriumBE.DocManager dm)
        {
            myDM = dm;

            //ucDocPreview1.Init(dm);
            ucDocView1.Init(dm);

            //if(!FM.IsVirtualFM)
            //    dm.GetRecipient().LoadByFileId(FM.CurrentFile.FileId);
            ucRecordList1.Init(myDM);

            DataView dv = new DataView(a, "", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);

            this.documentBindingSource.DataSource = dv;
            this.documentBindingSource.DataMember = "";

            
            if (firstTime)
            {
                dcceh = new DataColumnChangeEventHandler(a_ColumnChanged);
                a.ColumnChanged += dcceh;
                dm.DB.DocContent.ColumnChanged += dcceh;
                dm.DB.Recipient.ColumnChanged += dcceh;
                ueh = new atLogic.UpdateEventHandler(ucRecords_OnUpdate);
                dm.GetDocument().OnUpdate += ueh;
                dm.GetDocContent().OnUpdate += ueh;
                dm.GetRecipient().OnUpdate += ueh;
            }
            firstTime = false;

            if (DocSearchResults)                
                pnlGrid.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            
            ucRecordList1.SearchResult(DocSearchResults);

            if (documentBindingSource.Current != null)
                ApplySecurity(CurrentRow());

            NoData(documentBindingSource.Count == 0);
            if (documentBindingSource.Count > 0)
                timer1.Start();
        }

        public override void ReloadUserControlData()
        {
            //ucDocPreview1.Clear();
            ucDocView1.Clear();
            //myDM.GetDocContent().PreRefresh();
            //myDM.GetRecipient().PreRefresh();
            //myDM.GetAttachment().PreRefresh();
            //myDM.GetDocument().PreRefresh();

            //myDM.LoadAll(true);//.GetDocument().LoadByFileId(FM.CurrentFile.FileId);
            //myDM.GetRecipient().LoadByFileId(FM.CurrentFile.FileId);
            ucRecordList1.Init(myDM);
            ucRecordList1.GridMoveFirst();
        }

        private void NoData(bool hasNotData)
        {
            if (hasNotData)
            {
                //ucDocPreview1.NoAssociatedDocument(LawMate.Properties.Resources.ThereAreNoDocumentsOnThisFile);
                ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.ThereAreNoDocumentsOnThisFile);
            }
        }
        public bool HideList
        {
            get { return pnlGrid.Closed; }
            set { pnlGrid.Closed = value; }
        }
        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(documentBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            //ucDocPreview1.ReadOnly(makeReadOnly);
            ucDocView1.ReadOnly(makeReadOnly);
            if (!makeReadOnly)
                ApplySecurity(CurrentRow());

        }

        void ucRecords_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            //if (this.ParentForm != null)
            //{
            ApplyBR(e.SavedOK);
            //}


        }

        public delegate void ApplyBRCallBack(bool dirty);

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "icon")
                return;

            if (e.Column.ColumnName == "FailedToSend")
                return;
            if (e.Column.ColumnName == "ReceivedLocal")
                return; 
            if (e.Column.ColumnName == "SentLocal")
                return;
            try
            {
                //if (this.ParentForm != null)
                //{
                ApplyBRCallBack ap = new ApplyBRCallBack(ApplyBR);
                this.Invoke(ap, new object[] { false });
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void ApplyBR(bool DataNotDirty)
        {


            fFile f = FileForm();
            if (f != null)
            {
                f.IsDirty = !DataNotDirty;

                if (f.ReadOnly)
                    return;

                f.fileToc.Enabled = DataNotDirty;
                f.EditModeTitle(!DataNotDirty);
            }

            ucRecordList1.InEditMode = !DataNotDirty;


            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);

        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
            {
                //ucDocPreview1.ReadOnly(true);
                ucDocView1.ReadOnly(true);
                return;
            }

            docDB.DocumentRow cbr = (docDB.DocumentRow)dr;

            if (cbr == null)
                return;
            //problem here is that doccontent does not load until preview async finsihes
            //need to implement a canedit that just takes the docid
            bool canEditDC = myDM.GetDocContent().CanEdit(cbr.DocContentRow);

            UIHelper.EnableControls(documentBindingSource, myDM.GetDocument().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete2, myDM.GetDocument().CanDelete(cbr));

            if (cbr.isElectronic)
            {


                if (canEditDC)
                {
                    CheckoutToggle(cbr);
                    cmdRevise.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    tsCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsCheckin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsUndoCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.False;


                    cmdRevise.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }

            }
            else
            {
                tsCheckin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsUndoCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdRevise.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        private void CheckoutToggle(docDB.DocumentRow cbr)
        {
            if (cbr.IsCheckedOutByNull())
            {
                tsCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsCheckin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsUndoCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                tsCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsCheckin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsUndoCheckout.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        public override void Save()
        {
            if (FM.GetDocMng().DB.Document.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    //ucDocPreview1.EndEdit();
                    ucDocView1.EndEdit();

                    this.documentBindingSource.EndEdit();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();
                    //bp.AddForUpdate(FM.GetDocMng().GetDocContent());
                    //bp.AddForUpdate(FM.GetDocMng().GetDocument());
                    //bp.AddForUpdate(FM.GetDocMng().GetRecipient());
                    //bp.Update();

                    ApplyBR(true);

                    //ReloadUserControlData();
                }
                catch (Exception x)
                {
                    throw x;
                }
            }

        }

        private docDB.DocumentRow CurrentRow()
        {
            if (documentBindingSource.Current == null)
                return null;
            else
                return (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;
        }

        public void StartCopy()
        {
            docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;
            //ucDocPreview1.WriteTempFile(dr.DocContentRow);
            ucDocView1.WriteTempFile(dr);
            System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
            //sc.Add(ucDocPreview1.TempFile);
            sc.Add(ucDocView1.TempFile);
            Clipboard.SetFileDropList(sc);
        }


        private void CheckOut()
        {

            docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;

            string checkOutFile = myDM.GetDocument().Checkout(dr);
            //ucDocPreview1.NoDoc(LawMate.Properties.Resources.TheDocumentIsCheckedOut);
            ucDocView1.HideContent(LawMate.Properties.Resources.TheDocumentIsCheckedOut);
            CheckoutToggle(dr);

            //UIHelper.LaunchNative(checkOutFile, ucDocPreview1, "");
            UIHelper.LaunchNativeN(checkOutFile, ucDocView1, "");


        }


        private void CheckIn()
        {
            docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;

            //ucDocPreview1.Clear();
            ucDocView1.Clear();
            myDM.GetDocument().Checkin(dr);
            CheckoutToggle(dr);

            //ucDocPreview1.Preview();
            ucDocView1.Preview();
        }


        private void documentBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
        }


        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars["cbMergeToolbar"];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();


                switch (e.Command.Key)
                {
                    case "cmdFieldSelector":
                        ucRecordList1.RecordsGridEx.ShowFieldChooser(this.ParentForm, LawMate.Properties.Resources.FieldSelector);
                        break;
                    case "tsFilter":
                        if (e.Command.IsChecked)
                            ucRecordList1.RecordsGridEx.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            ucRecordList1.RecordsGridEx.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "tsGroupBy":
                        if (e.Command.IsChecked)
                            ucRecordList1.RecordsGridEx.GroupByBoxVisible = true;
                        else
                        {
                            ucRecordList1.RecordsGridEx.RootTable.Groups.Clear();
                            ucRecordList1.RecordsGridEx.GroupByBoxVisible = false;
                        }
                        break;
                    case "cmdClone":
                        myDM.GetDocument().MakeCopy(CurrentRow(), FM.CurrentFile, true);
                        break;
                    case "tsTemplate":
                        FileForm().GetUcCtlToc("template");

                        break;
                    case "cmdRevise":
                        lmWinHelper.ReviseDocument(FM, CurrentRow().DocId);
                        break;
                    case "tsPrint":
                        //ucDocPreview1.Print();
                        ucDocView1.Print();
                        break;
                    case "tsPrintPreview":
                        //ucDocPreview1.PrintPreview();
                        ucDocView1.PrintPreview();
                        break;
                    case "tsAdd":
                        //new activity
                        NewDoc(FM.AtMng.GetSetting( AppIntSetting.NewDocAcId));
                        break;
                    case "tsAddRec":
                        //new activity
                        NewDoc(FM.AtMng.GetSetting( AppIntSetting.NewRecordAcId));
                        break;
                    case "tsSend":
                        docDB.DocumentRow drc = CurrentRow();
                        if (drc.IsDraft)
                        {
                            drc = FM.GetDocMng().GetDocument().MakeCopy(CurrentRow(), FM.CurrentFile, false);

                        }

                        lmWinHelper.NewMail(FM, drc.DocId);
                        break;
                    case "tsCopy":
                        StartCopy();

                        break;
                    case "tsExport":
                        myDM.AtMng.Export("f.openeddate>'2011-1-1'");
                        break;
                    case "tsCheckout":
                        CheckOut();
                        break;
                    case "tsCheckin":

                        CheckIn();

                        break;
                    case "tsUndoCheckout":
                        docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;
                        ucDocView1.Clear();
                        //ucDocPreview1.Clear();
                        myDM.GetDocument().UndoCheckout(dr);
                        CheckoutToggle(dr);
                        ucDocView1.Preview();
                        //ucDocPreview1.Preview();
                        break;
                    case "tsPreviewPane":
                        HidePreviewPane(tsPreviewPane.IsChecked);
                        break;
                    case "tsSave":
                        Save();
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                    case "cmdJumpToActivity":
                        if(e.Command.Tag!=null)
                            FileForm().MoreInfo("activity", (int)e.Command.Tag);
                        break;
                }

                if (e.Command.Key.StartsWith("cmdActivityMoreInfo"))
                    FileForm().MoreInfo("activity", (int)e.Command.Tag);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void Cancel()
        {
            ApplyBR(true);
            UIHelper.Cancel(documentBindingSource);
            ucDocView1.Cancel();
        }

        private void HidePreviewPane(bool Show)
        {
            if (Show)
            {
                uiPanel1.Closed = false;
                pnlGrid.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
                LoadPreview = true;
            }
            else
            {
                uiPanel1.Closed = true;
                pnlGrid.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
                LoadPreview = true;
            }
        }


        public void Preview()
        {
            //ucDocPreview1.Preview();
            ucDocView1.Preview();
        }

        private void bkwFSWatcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Preview();
        }

        private void bkwApplyBR_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void uiPanelManager1_PanelActivated(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            try
            {
                LoadPreview = true;

                //if (e.Panel == pnlPreview)
                //    LoadPreview = true;
                //if (e.Panel == pnlDetail)
                //    LoadPreview = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        public void NewDoc(int acsId)
        {
            try
            {

                fACWizard facw = new fACWizard(FM, ACEngine.Step.ACInfo, acsId);
                if (!facw.Disposing && !facw.IsDisposed)
                {
                    facw.ShowDialog(this);
                    facw.Close();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void documentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                docDB.DocumentRow dr = CurrentRow();
                if (dr == null)
                {
                    //ucDocPreview1.Clear();
                    ucDocView1.Clear();
                    return;
                }
                if (LoadPreview & !dr.IsNull("DocId"))
                {
                    ucDocView1.Datasource = new DataView(myDM.DB.Document, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                    ucDocView1.PreviewAsync();
                    //ucDocPreview1.Datasource = new DataView(myDM.DB.Document, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                    //ucDocPreview1.PreviewAsync();
                }
                else
                {
                    ucDocView1.Clear();
                    //ucDocPreview1.Clear();
                }
                //load activity more info menu items
                if(showToolbar)
                    ActivityMoreInfoLoad();



                //ApplySecurity(CurrentRow());

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ActivityMoreInfoLoad()
        {
            cmdJumpToActivity.Commands.Clear();
            atriumDB.ActivityRow[] actrs;
            actrs= (atriumDB.ActivityRow[])FM.DB.Activity.Select("docid=" + CurrentRow().DocId);

            //must be an attachment, loop through all attachments and find parent doc
            if (actrs.Length == 0)
            {
                docDB.AttachmentRow[] attrow = (docDB.AttachmentRow[])myDM.DB.Attachment.Select("attachmentid=" + CurrentRow().DocId);
                string acIDs = "";
                foreach (docDB.AttachmentRow ar in attrow)
                {
                    if (acIDs == "")
                        acIDs = ar.MsgId.ToString();
                    else
                        acIDs += ", " + ar.MsgId.ToString();
                }
                if(acIDs!="")
                    actrs = (atriumDB.ActivityRow[])FM.DB.Activity.Select("docid in (" + acIDs + ")");
 
            }
            if (actrs.Length == 0)
                cmdJumpToActivity.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            else
                cmdJumpToActivity.Enabled = Janus.Windows.UI.InheritableBoolean.True;

            foreach (atriumDB.ActivityRow actr in actrs)
            {
                Janus.Windows.UI.CommandBars.UICommand newCmd;

                //add new items
                string key = "cmdActivityMoreInfo" + actr.ActivityId.ToString();
                if (cmdJumpToActivity.CommandManager.Commands.Contains(key))
                {
                    newCmd = cmdJumpToActivity.CommandManager.Commands[key];
                }
                else
                {

                    newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                    newCmd.Key = key;
                }
                ActivityConfig.ACSeriesRow[] acsrC = (ActivityConfig.ACSeriesRow[])FM.AtMng.acMng.DB.ACSeries.Select("acseriesid=" + actr.ACSeriesId, "");
                newCmd.Text = actr.ActivityDate.ToString("yyyy/MM/dd") +" - " + FM.AtMng.acMng.GetACSeries().GetNodeText(acsrC[0], (atriumBE.StepType)acsrC[0].StepType, false);
                newCmd.Tag = actr.ActivityId;
                newCmd.ShowInCustomizeDialog = false;
                cmdJumpToActivity.Commands.Add(newCmd);

            }
            if (cmdJumpToActivity.Commands.Count == 1)
            {
                cmdJumpToActivity.Tag = cmdJumpToActivity.Commands[0].Tag;
                cmdJumpToActivity.Commands.Clear();
            }
            else
                cmdJumpToActivity.Tag = null;
        }

        private void ucDocPreview1_DocAction(object sender, UserControls.DocActionEventArgs e)
        {
            lmWinHelper.DocAction(FM.AtMng.GetFile(e.DocRecord.FileId), e);
        }

        private void ucRecords_VisibleChanged(object sender, EventArgs e)
        {
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Preview();
            
        }

    }
}

