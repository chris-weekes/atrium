using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;

namespace LawMate
{
    public partial class fBrowseDocs : Form
    {
        atriumManager myAtmng;
        DocManager myDM;

        bool findingFile = false;
        private bool allowBrowseFiles = true;
        public bool AllowBrowseFiles
        {
            get { return allowBrowseFiles; }
            set
            {
                allowBrowseFiles = value;
                pnlLeft.Closed = !allowBrowseFiles;
            }
        }

        private docDB.DocumentRow selectedDocument;
        public docDB.DocumentRow SelectedDocument
        {
            get { return selectedDocument; }
        }
        private List<DataRow> selectedDocuments;
        public List<DataRow> SelectedDocuments()
        {
            return selectedDocuments;
        }

        private int docId;
        public int DocId
        {
            get { return docId; }
        }

        public fBrowseDocs()
        {
            InitializeComponent();
        }

        public fBrowseDocs(atriumManager atmng)
        {
            InitializeComponent();

            myAtmng = atmng;
            myDM = myAtmng.GetFile().GetDocMng();

            ucBrowse1.LoadRoot(atmng, 0, false, false, true);

            ucRecordList1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            LoadDocs();
            //tvMyFiles.ExpandAll();
            lblCurrentFile.Text = "";
            panelDisplayHandler(Properties.Resources.Browse, Properties.Resources.folder);
        }

        private void ucBrowse1_FileSelected(object sender, FileContextEventArgs e)
        {
            try
            {
                if (!findingFile)
                {
                    Application.UseWaitCursor = true;
                    ucRecordList1.SearchResult(false);
                    LoadDocs();
                    Application.UseWaitCursor = false;

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
                Application.UseWaitCursor = false;
            }
        }

        private void LoadDocs()
        {
            myDM.GetDocument().PreRefresh();
            myDM.GetDocument().LoadByFileId(ucBrowse1.SelectedFile.FileId);
            ucRecordList1.Init(myDM);
            documentBindingSource.DataSource = new DataView(myDM.DB.Document);
            documentBindingSource.Filter = myDocFilter;
            //PostDataLoad(myDM);
        }

        private void PostDataLoad(DocManager dcmngr)
        {
            ucRecordList1.Init(dcmngr);
            documentBindingSource.DataSource = new DataView(dcmngr.DB.Document);
            documentBindingSource.Filter = myDocFilter;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucRecordList1.SelectionMode == Janus.Windows.GridEX.SelectionMode.MultipleSelection)
                {
                    selectedDocuments = ucRecordList1.SelectedDocuments();
                }
                else
                {
                    selectedDocument = ucRecordList1.SelectedDocument();
                }
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        string myDocFilter = "";
        public void SetDocFilter(string filter)
        {
            myDocFilter = filter;
            documentBindingSource.Filter = filter;
            pnlMessage.Closed = (filter == "");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                selectedDocument = null;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void FindFile(int fileId)
        {
            appDB.EFileSearchRow esr = myAtmng.FileSearchByFileId(fileId)[0];
            findingFile = true;
            ucBrowse1.myFTV.FindNode(esr);
            findingFile = false;

            LoadDocs();
        }

        //private void tvMyFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    try
        //    {
        //        Application.UseWaitCursor=true;
        //        atLogic.WhereClause wcy = new atLogic.WhereClause();
        //        wcy.Add("d.OfficerId", "=", myAtmng.WorkingAsOfficer.OfficerId);
        //        atLogic.WhereClause wcToExecute = wcy;
        //        bool executeSearch = true;

        //        switch (e.Node.Name)
        //        {
        //            case "ndCheckedOut":
        //                atLogic.WhereClause wc = new atLogic.WhereClause();
        //                wc.Add("CheckedoutBy", "=", myAtmng.WorkingAsOfficer.OfficerId);
        //                wcToExecute = wc;
        //                break;
        //            case "ndDrafts":
        //                atLogic.WhereClause wcDrafts = new atLogic.WhereClause();
        //                wcDrafts.Add("d.OfficerId", "=", myAtmng.WorkingAsOfficer.OfficerId);
        //                wcDrafts.Add("d.IsDraft", "=", true);
        //                wcToExecute = wcDrafts;
        //                break;
        //            case "ndToday":
        //                wcy.Add("d.efDate", "Between", atDates.StandardDate.Today.BeginDate, atDates.StandardDate.Today.EndDate);
        //                break;
        //            case "ndYesterday":
        //                wcy.Add("d.efDate", "Between", atDates.StandardDate.Yesterday.BeginDate, atDates.StandardDate.Yesterday.EndDate);
        //                break;
        //            case "ndThisWeek":
        //                wcy.Add("d.efDate", "Between", atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
        //                break;
        //            case "ndLastWeek":
        //                wcy.Add("d.efDate", "Between", atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
        //                break;
        //            case "ndCustom":
        //                fCustomDateRange fDateRange = new fCustomDateRange();
        //                if (fDateRange.ShowDialog() == DialogResult.OK)
        //                    wcy.Add("d.efDate", "Between", (DateTime)fDateRange.BeginDate, (DateTime)fDateRange.EndDate);
        //                else
        //                    executeSearch = false;
        //                break;
        //            default:
        //                executeSearch = false;
        //                break;
        //        }

        //        if (executeSearch)
        //        {
        //            myDM.GetDocument().PreRefresh();
        //            myDM.GetDocument().Search(wcToExecute, false);
        //            PostDataLoad(myDM);
        //            ucRecordList1.SearchResult(true);
        //        }
        //        Application.UseWaitCursor=false;
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //        Application.UseWaitCursor=false;
        //    }
        //}

        private void documentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (documentBindingSource.Current != null)
                {
                    selectedDocument = (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;
                    lblCurrentFile.Text = selectedDocument.efSubject;
                    buttonOK.Enabled = true;
                    uiButton1.Enabled = true;
                }
                else
                {
                    selectedDocument = null;
                    lblCurrentFile.Text = "";
                    buttonOK.Enabled = false;
                    uiButton1.Enabled = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void panelDisplayHandler(string recordListTitle, Bitmap img)
        {
            uiTabPage1.Text = recordListTitle;
            uiTabPage1.Image = img;
            //ucRecordList1.RecordsGridEx.RootTable.Caption = recordListTitle;
            //ucRecordList1.RecordsGridEx.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
        }

        private void uiPanelManager1_PanelActivated(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            try
            {
                if (e.Panel.Name == pnlBrowseSelect.Name)
                    panelDisplayHandler(Properties.Resources.Browse, Properties.Resources.folder);
                else if (e.Panel.Name == pnlSearch.Name)
                {
                    panelDisplayHandler(Properties.Resources.DocBrowseSearchCaption, Properties.Resources.search);
                    ebSearchFor.Focus();
                    if (cbSearchType.SelectedItem == null)
                        cbSearchType.SelectedIndex = 2;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                if (ebSearchFor.Text.Length > 0)
                {
                    atLogic.WhereClause wc = new atLogic.WhereClause();
                    switch (cbSearchType.SelectedItem.Value.ToString())
                    {

                        case "efSubject":
                            wc.Add("d.efSubject", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, ebSearchFor.Text));
                            break;
                        case "fulltext":
                            wc.Add("contents", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, ebSearchFor.Text));
                            break;
                        case "FileNumber":
                            wc.Add("f.filenumber", "likeboth", ebSearchFor.Text);
                            break;
                        case "FullFileNumber":
                            wc.Add("f.FullFileNumber", "like", ebSearchFor.Text);
                            break;

                    }

                    myDM.GetDocument().PreRefresh();
                    myDM.GetDocument().Search(wc, false);
                    PostDataLoad(myDM);
                    ucRecordList1.SearchResult(true);

                }
                else
                    MessageBox.Show(Properties.Resources.UIMissingCriteria);

                Application.UseWaitCursor = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
                Application.UseWaitCursor = false;
            }
        }

        private void lblCurrentFile_MouseHover(object sender, EventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                toolTip1.SetToolTip(lbl, lbl.Text);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucRecordList1.SelectionMode == Janus.Windows.GridEX.SelectionMode.MultipleSelection)
                {

                    foreach (lmDatasets.docDB.DocumentRow dr in ucRecordList1.SelectedDocuments())
                    {
                        fDoc fd = new fDoc(myDM, dr);
                        fd.Show(this);
                    }
                }
                else
                {
                    if (ucRecordList1.SelectedDocument() != null)
                    {
                        fDoc fd = new fDoc(myDM, ucRecordList1.SelectedDocument());
                        fd.Show(this);
                    }
                }
              
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void explorerBar1_ItemClick(object sender, Janus.Windows.ExplorerBar.ItemEventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                atLogic.WhereClause wcy = new atLogic.WhereClause();
                if (e.Item.Key.StartsWith("ndChron"))
                    wcy.Add("d.docid", "in", "select docid from recipient where officerid = " + myAtmng.WorkingAsOfficer.OfficerId.ToString() + " and type=0");
                else
                    wcy.Add("d.docid", "in", "select docid from recipient where officerid = " + myAtmng.WorkingAsOfficer.OfficerId.ToString() + " and type in (1,2)");

                atLogic.WhereClause wcToExecute = wcy;
                bool executeSearch = true;

                switch (e.Item.Key)
                {
                    case "ndCheckedOut":
                        atLogic.WhereClause wc = new atLogic.WhereClause();
                        wc.Add("CheckedoutBy", "=", myAtmng.WorkingAsOfficer.OfficerId);
                        wcToExecute = wc;
                        break;
                    case "ndDrafts":
                        atLogic.WhereClause wcDrafts = new atLogic.WhereClause();
                        wcDrafts.Add("d.OfficerId", "=", myAtmng.WorkingAsOfficer.OfficerId);
                        wcDrafts.Add("d.IsDraft", "=", true);
                        wcToExecute = wcDrafts;
                        break;
                    case "ndChronToday":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.Today.BeginDate, atDates.StandardDate.Today.EndDate);
                        break;
                    case "ndChronYesterday":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.Yesterday.BeginDate, atDates.StandardDate.Yesterday.EndDate);
                        break;
                    case "ndChronThisWeek":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                        break;
                    case "ndChronLastWeek":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                        break;
                    case "ndChronCustom":
                        fCustomDateRange fDateRange = new fCustomDateRange();
                        if (fDateRange.ShowDialog() == DialogResult.OK)
                            wcy.Add("d.efDate", "Between", (DateTime)fDateRange.BeginDate, (DateTime)fDateRange.EndDate);
                        else
                            executeSearch = false;
                        break;
                    case "ndRecToday":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.Today.BeginDate, atDates.StandardDate.Today.EndDate);
                        break;
                    case "ndRecYesterday":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.Yesterday.BeginDate, atDates.StandardDate.Yesterday.EndDate);
                        break;
                    case "ndRecThisWeek":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                        break;
                    case "ndRecLastWeek":
                        wcy.Add("d.efDate", "Between", atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                        break;
                    case "ndRecCustom":
                        fCustomDateRange fDateRange2 = new fCustomDateRange();
                        if (fDateRange2.ShowDialog() == DialogResult.OK)
                            wcy.Add("d.efDate", "Between", (DateTime)fDateRange2.BeginDate, (DateTime)fDateRange2.EndDate);
                        else
                            executeSearch = false;
                        break;
                    default:
                        executeSearch = false;
                        break;
                }

                if (executeSearch)
                {
                    myDM.GetDocument().PreRefresh();
                    myDM.GetDocument().Search(wcToExecute, false);
                    PostDataLoad(myDM);
                    ucRecordList1.SearchResult(true);
                }
                Application.UseWaitCursor = false;
            }
            catch (Exception x)
            {
                Application.UseWaitCursor = false;
                UIHelper.HandleUIException(x);
            }
        }

        private void ebSearchFor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnPerformSearch.PerformClick();
                }
            }
            catch (Exception x)
            {

            }
        }
    }
}
