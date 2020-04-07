using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate
{
    public partial class fSearchResultsDoc : fBase
    {
        fAdvancedSearch myfAS;
        string FullText;
        atriumBE.DocManager dm;
        bool IsFullTextSearch = false;
        fWait fProgress;
        
        private void LoadLabels()
        {
            gridEXPrintDocument1.DocumentName = String.Format(LawMate.Properties.Resources.SearchPrintGrid, AtMng.AppMan.AppName);
            gridEXPrintDocument1.PageFooterLeft = String.Format(LawMate.Properties.Resources.SearchPrintGrid, AtMng.AppMan.AppName);
 
        }
        private void Init(fAdvancedSearch referrer, string fullText)
        {
            LoadLabels();
            dm = this.AtMng.GetFile().GetDocMng();
            //ucDoc1.Init(dm);
            //ucDoc1.ReturnFocusTo = ucRecordList1;
            ucDocView1.Init(dm);
            ucDocView1.ReturnFocusTo = ucRecordList1;

            fProgress = MainForm.FProgress;
            if (referrer != null)
                myfAS = referrer;
            else
                tsReviseSearchCriteria.Visible = Janus.Windows.UI.InheritableBoolean.False;

            //ucDoc1.Clear();
            ucDocView1.Clear();

            if (fullText != "")
            {
                FullText = fullText;
                tbFullTextCriteriaRO.Text = fullText;
                this.Text += " [" + fullText + "]";
                
                //pnlLeft.Closed = false;
                pnlLeft.Closed = true;
                tsHitHilite.Visible = Janus.Windows.UI.InheritableBoolean.False;

                tsPreview1.Visible = Janus.Windows.UI.InheritableBoolean.False;
                IsFullTextSearch = true;
                tsHitHilite.Checked = Janus.Windows.UI.InheritableBoolean.True;

                cmdPrevHit.Visible = Janus.Windows.UI.InheritableBoolean.True;
                cmdNextHit.Visible = Janus.Windows.UI.InheritableBoolean.True;
                cmdFirstHit.Visible = Janus.Windows.UI.InheritableBoolean.True;
                cmdLastHit.Visible = Janus.Windows.UI.InheritableBoolean.True;
                cmdToggleHighlight.Visible = Janus.Windows.UI.InheritableBoolean.True;
                SetPreview(true);
            }
            else
            {
                tsHitHilite.Visible = Janus.Windows.UI.InheritableBoolean.False;
                pnlLeft.Closed = true;
                cmdPrevHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdNextHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdFirstHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdLastHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdToggleHighlight.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        bool ok2Preview = false;
        private void InitDT(docDB.DocumentDataTable dt)
        {
            documentBindingSource.DataSource = new DataView(dt);

            tsMatchesCount.Text = dt.Rows.Count.ToString();

            ucRecordList1.Init(dm);
            ucRecordList1.SearchResult(true);
            NoHits(dt.Rows.Count);
            ok2Preview = true;
            PreviewCurrentDoc();

        }
   

        public fSearchResultsDoc(Form f, atLogic.WhereClause wc, fAdvancedSearch referrer, string fullText, bool includeXrefs, string formName,bool opinionsOnly)
            : base(f)
        {
            try
            {
                InitializeComponent();
                SearchDoc(f, wc, referrer, fullText, includeXrefs, formName, opinionsOnly);
                fProgress.resetForm();
                //dm.FM.Dispose();
            }
            catch (Exception x)
            {
                throw x;
                UIHelper.HandleUIException(x);
            }
            finally
            {
                fProgress.resetForm();
            }

        }

        private void NoHits(int hits)
        {
            if (hits == 0)
            {
                lblNoMatches.Visible = true;
                tsPreview1.Visible = Janus.Windows.UI.InheritableBoolean.False;
                pnlPreview.Closed = true;
                pnlRecordList.Closed = true;
                pnlResultDetails.Closed = false;
                tsLblNumOfMatches.Visible = Janus.Windows.UI.InheritableBoolean.False;
                tsMatchesCount.Visible = Janus.Windows.UI.InheritableBoolean.False;
                tsJump.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdJumptToActivity.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdGridExGroupBy.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdGridExFilter.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdFldChooser.Visible = Janus.Windows.UI.InheritableBoolean.False;
                tsHitHilite.Visible = Janus.Windows.UI.InheritableBoolean.False;
                pnlLeft.Closed = true;
                cmdLast.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdLastHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdNext.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdNextHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdFirst.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdFirstHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdPrev.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdPrevHit.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdToggleHighlight.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                lblNoMatches.Visible = false;
                //pnlPreview.Closed = true;
                pnlRecordList.Closed = false;
                pnlResultDetails.Closed = true;
            }
        }

        public void SearchDoc(Form f, atLogic.WhereClause wc, fAdvancedSearch referrer, string fullText, bool includeXrefs, string formName,bool opinionsOnly)
        {
                Init(referrer, fullText);
                fProgress.setMessageText(LawMate.Properties.Resources.RetrievingDataMessage);
                if (wc == null)
                {
                    dm.GetDocument().Search(fullText,opinionsOnly);
                }
                else
                {
                    dm.GetDocument().Search(wc, includeXrefs);//.GetGeneralRec("select v.* from vefile v inner join efile f on v.fileid=f.fileid " + wc.Clause());
                }
                
                //InitDT(dm.DB.Document);
                if (formName != null)
                    this.Text = formName;

                if (this.Visible)
                {
                    InitDT(dm.DB.Document);
                    //if (formName != null)
                    //    this.Text = formName;
                    fProgress.resetForm();

                }
            
        }

        bool FullTextDocLoading = false;
        private void PreviewCurrentDoc()
        {
            docDB.DocumentRow dr = CurrentRow();
            if (dr != null & ok2Preview)
            {
                //ucDoc1.Datasource = new DataView(dr.Table, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                ucDocView1.Datasource = new DataView(dr.Table, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);

                if (IsFullTextSearch && !pnlPreview.Closed && dr.FileFormatRow!=null && dr.FileFormatRow.AllowSearch)
                {
                    FullTextDocLoading = true;
                    {
                        if (dr.ext.ToUpper() == ".PDF")
                        {
                            uiStatusBar1.Visible = true;
                            cmdFirstHit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            cmdNextHit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            cmdPrevHit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            cmdLastHit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        else
                        {
                            uiStatusBar1.Visible = false;
                            cmdFirstHit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            cmdNextHit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            cmdPrevHit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            cmdLastHit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        }

                    }
                    if (!cmdToggleHighlight.IsChecked)
                        cmdToggleHighlight.IsChecked = true;

                    //string summaryText = ucDoc1.PreviewHitHighlight(FullText);
                    string summaryText = ucDocView1.PreviewHitHighlight(FullText);
                    if (summaryText != "")
                        ucWB1.WriteContent(summaryText);
                    //lblSelectedHitPosition.Text = "1";
                }
                else if (!pnlPreview.Closed )
                    ucDocView1.PreviewAsync();
                    //ucDoc1.PreviewAsync();
            }
        }

        private docDB.DocumentRow CurrentRow()
        {
            if(this.documentBindingSource.Current!=null)
                return (docDB.DocumentRow)((DataRowView)this.documentBindingSource.Current).Row;

            return null;
        }

        private void ucRecordList1_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)this.documentBindingSource.Current).Row;
                MainForm.OpenFile(dr.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void ucDoc1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                ucRecordList1.Focus();
                if (FullTextDocLoading)
                {
                    int FullTextHitCount;
                    //FullTextHitCount = ucDoc1.HitHighlightDocLoaded();
                    FullTextHitCount = ucDocView1.HitHighlightDocLoaded();
                    lblCurrentDocHitCount.Text = FullTextHitCount.ToString();
                    FullTextDocLoading = false;
                }
                if (LoadLastHitDocument)
                {
                    //int HitCount = ucDoc1.SelectLastHitOfDocument();
                    int HitCount = ucDocView1.SelectLastHitOfDocument();
                    lblSelectedHitPosition.Text = HitCount.ToString();
                    int MaxTag = HitCount - 1;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdPrintGrid":
                        if (gridEXPrintDocument1.GridEX == null)
                            gridEXPrintDocument1.GridEX = ucRecordList1.RecordsGridEx;
                        UIHelper.GridExPrintDocument(gridEXPrintDocument1);
                        break;
                    case "cmdPrintPreview":
                        if (gridEXPrintDocument1.GridEX == null)
                            gridEXPrintDocument1.GridEX = ucRecordList1.RecordsGridEx;
                        UIHelper.GridExPrintPreview(gridEXPrintDocument1);
                        break;
                    case "cmdFirstHit":
                        MoveToDoc(FullTextNavigation.MoveFirst, false);
                        break;
                    case "cmdPrevHit":
                        MoveToHit(MoveHit.MovePrevious);
                        break;
                    case "cmdNextHit":
                        MoveToHit(MoveHit.MoveNext);
                        break;
                    case "cmdLastHit":
                        MoveToDoc(FullTextNavigation.MoveLast, true);
                        break;

                    case "cmdFirst":
                        MoveToDoc(FullTextNavigation.MoveFirst, false);
                        break;
                    case "cmdPrev":
                        MoveToDoc(FullTextNavigation.MovePrevious, false);
                        break;
                    case "cmdNext":
                        MoveToDoc(FullTextNavigation.MoveNext, false);
                        break;
                    case "cmdLast":
                        MoveToDoc(FullTextNavigation.MoveLast, false);
                        break;

                    case "tsJump":
                        fFile f = MainForm.OpenFile(CurrentRow().FileId);
                        f.MoreInfo("document", CurrentRow().DocId);

                        break;
                    case "tsRevise":
                        lmWinHelper.ReviseDocument(AtMng.GetFile(CurrentRow().FileId), CurrentRow().DocId);
                        break;
                    case "cmdGridExFilter":
                        if (e.Command.IsChecked)
                            ucRecordList1.RecordsGridEx.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            ucRecordList1.RecordsGridEx.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "cmdGridExGroupBy":
                        if (e.Command.IsChecked)
                            ucRecordList1.RecordsGridEx.GroupByBoxVisible = true;
                        else
                        {
                            ucRecordList1.RecordsGridEx.RootTable.Groups.Clear();
                            ucRecordList1.RecordsGridEx.GroupByBoxVisible = false;
                        }
                        break;
                    case "cmdFldChooser":
                        ucRecordList1.RecordsGridEx.ShowFieldChooser(this );
                        break;
                    case "tsCloseResults":
                        this.Close();
                        break;
                    case "tsHitHilite":
                        SetPreview(tsHitHilite.IsChecked);
                        break;
                    case "tsPreview":
                        SetPreview(tsPreview1.IsChecked);
                        break;
                    case "tsReviseSearchCriteria":
                        if (!myfAS.IsDisposed)
                        {
                            MainForm.Focus();
                            myfAS.Activate();
                        }
                        else
                        {
                            MessageBox.Show(LawMate.Properties.Resources.TheAdvancedSearchScreenIsNoLongerAccessible, LawMate.Properties.Resources.AdvancedSearchScreenNotAccessible, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tsReviseSearchCriteria.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        break;
                    case "tsShowDetails":
                        if (tsShowDetails.IsChecked)
                            pnlResultDetails.Closed = false;
                        else
                            pnlResultDetails.Closed = true;
                        break;
                    case "cmdJumptToActivity":
                        MainForm.OpenFile(CurrentRow().FileId);
                        break;
                    case "cmdToggleHighlight":
                        if(!cmdToggleHighlight.IsChecked)
                        {
                            IsFullTextSearch = false; //Suspend IsFullTextSearch so preview shows doc in proper ucdoc doc display control
                            PreviewCurrentDoc();
                            IsFullTextSearch = true; //Set IsFullTextSearch back to original value
                        }
                        else
                            PreviewCurrentDoc();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void SetPreview(bool SetToTrue)
        {
            if (SetToTrue)
            {
                pnlPreview.Closed = false;
                pnlRecordList.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
                //if (IsFullTextSearch)
                //{
                //    pnlLeft.Closed = false;
                //    pnlLeft.AutoHide = false;
                //}
                PreviewCurrentDoc();
                ucRecordList1.RecordsGridEx.Tag = true;
                tsPreview1.Checked = Janus.Windows.UI.InheritableBoolean.True;
            }
            else 
            {
                pnlPreview.Closed = true;
                pnlRecordList.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
                pnlLeft.Closed = true;
                //ucDoc1.Clear();
                ucDocView1.Clear();
                ucRecordList1.RecordsGridEx.Tag = false;
                tsPreview1.Checked = Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        private void documentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (tsPreview1.IsChecked || tsHitHilite.IsChecked)
                    PreviewCurrentDoc();
                if (FullText != null && documentBindingSource.Current != null)
                {
                    tbDocSubject.Text = CurrentRow().efSubject;
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        HtmlElement SelectedHit;
        int AncInCollection;
        private int PostSummaryLoad()
        {
            AncInCollection = 0;
            foreach (HtmlElement elmt in ucWB1.WebBrowser.Document.GetElementsByTagName("a"))
            {
                if (elmt.Name.StartsWith("CiTag"))
                    AncInCollection++;
            }

            if (ucWB1.WebBrowser.Document.All.GetElementsByName("CiTag0").Count > 0)
                HighlightSelectedHit("CiTag0");

            if (LoadLastHitDocument)
            {
                int MaxHit = AncInCollection - 1;
                HighlightSelectedHit("CiTag" + MaxHit.ToString());
                LoadLastHitDocument = false;
            }
            return AncInCollection;
        }

        private enum MoveHit
        {
            MovePrevious,
            MoveNext
        }
        bool LoadLastHitDocument = false;
        private void btnFirstHit_Click(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                switch (btn.Name)
                {
                    case "btnFirstHit":
                        MoveToDoc(FullTextNavigation.MoveFirst, false);
                        break;
                    case "btnPreviousHit":
                        MoveToHit(MoveHit.MovePrevious);
                        break;
                    case "btnNextHit":
                        MoveToHit(MoveHit.MoveNext);
                        break;
                    case "btnLastHit":
                        MoveToDoc(FullTextNavigation.MoveLast, true);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void MoveToHit(MoveHit moveTo)
        {
            int SelectedHitInt;
            if (moveTo == MoveHit.MovePrevious)
            {
                //SelectedHitInt = ucDoc1.NextPreviousHitFullText(false);
                SelectedHitInt = ucDocView1.NextPreviousHitFullText(false);
            }
            else
            {
                //SelectedHitInt = ucDoc1.NextPreviousHitFullText(true);
                SelectedHitInt = ucDocView1.NextPreviousHitFullText(true);
            }
            if (SelectedHitInt == -1)
            {
                switch (moveTo)
                {
                    case MoveHit.MoveNext:
                        if (ucRecordList1.RecordsGridEx.CurrentRow.AbsolutePosition != ucRecordList1.RecordsGridEx.RowCount)
                            MoveToDoc(FullTextNavigation.MoveNext, false);
                        else if (MessageBox.Show(LawMate.Properties.Resources.EndOfTheDocumentJumpToTheTop, LawMate.Properties.Resources.FullTextHitNavigation, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            MoveToDoc(FullTextNavigation.MoveFirst, false);
                        break;
                    case MoveHit.MovePrevious:
                        if (ucRecordList1.RecordsGridEx.CurrentRow.AbsolutePosition != 0)
                            MoveToDoc(FullTextNavigation.MovePrevious, true);
                        else if (MessageBox.Show(LawMate.Properties.Resources.BeginningOfTheDocumentJumpToTheBottom, LawMate.Properties.Resources.FullTextHitNavigation, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            MoveToDoc(FullTextNavigation.MoveLast, true);
                        break;
                }
            }
            else
            {
                //pnlLeft.AutoHide = false;
                lblSelectedHitPosition.Text = SelectedHitInt.ToString();
                int tagNum = SelectedHitInt - 1;
                HighlightSelectedHit("CiTag" + tagNum.ToString());
            }       
        }

        private void tbDocSubject_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (tbDocSubject.Tag == null || (int)tbDocSubject.Tag == 0)
                {
                    IsFullTextSearch = false; //Suspend IsFullTextSearch so preview shows doc in proper ucdoc doc display control
                    PreviewCurrentDoc();
                    IsFullTextSearch = true; //Set IsFullTextSearch back to original value
                    tbDocSubject.Tag = 1;
                    tbDocSubject.ButtonImage = imageListfBase.Images["highlight.gif"];
                }
                else
                {
                    PreviewCurrentDoc();
                    tbDocSubject.Tag = 0;
                    tbDocSubject.ButtonImage = imageListfBase.Images["exe_icon.gif"];
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucRecordList1_ColumnButtonClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)this.documentBindingSource.Current).Row;
                MainForm.OpenFile(dr.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void chkShowDocSummary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnlSummary.Closed = !chkShowDocSummary.Checked;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        

        private void ucWB1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                PostSummaryLoad();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucWB1_DocumentNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                string hitName = e.Url.ToString().Replace("about:","");
                hitName = hitName.Replace("blank", "");
                if (!String.IsNullOrEmpty(hitName))// && SelectedHit.Name != hitName)
                {
                    HighlightSelectedHit(hitName);
                    //ucDoc1.HighlightSelectedHit(hitName);
                    ucDocView1.HighlightSelectedHit(hitName);
                    e.Cancel=true;
                    ucWB1.WebBrowser.Visible = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void HighlightSelectedHit(string hitName)
        {
            //int CurrentHit = Convert.ToInt32(hitName.Substring(5));
            //CurrentHit = CurrentHit + 1;
            //lblSelectedHitPosition.Text = CurrentHit.ToString();
            //SelectedHit = ucWB1.WebBrowser.Document.All.GetElementsByName(hitName)[0];
            //if (SelectedHit != null)
            //{
            //    SelectedHit.ScrollIntoView(true);
            //    SelectedHit.Focus();
            //    foreach (HtmlElement elmt in ucWB1.WebBrowser.Document.GetElementsByTagName("a"))
            //    {
            //        elmt.Style = null;
            //    }
            //    SelectedHit.Style = "text-decoration:none;padding:3px;background-color:darkblue;color:white;";
            //}
        }

        private enum FullTextNavigation
        {
            MoveFirst,
            MovePrevious,
            MoveNext,
            MoveLast
        }

        private void btnFirstDoc_Click(object sender, EventArgs e)
        {
            try 
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                switch (btn.Name)
                {
                    case "btnFirstDoc":
                        MoveToDoc(FullTextNavigation.MoveFirst,false);
                        break;
                    case "btnPreviousDoc":
                        MoveToDoc(FullTextNavigation.MovePrevious,false);
                        break;
                    case "btnNextDoc":
                        MoveToDoc(FullTextNavigation.MoveNext,false);
                        break;
                    case "btnLastDoc":
                        MoveToDoc(FullTextNavigation.MoveLast,false);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void MoveToDoc(FullTextNavigation NavEnum, bool HighlightLastHit)
        {
            //pnlLeft.AutoHide = false;
            switch (NavEnum)
            {
                case FullTextNavigation.MoveFirst:
                    ucRecordList1.RecordsGridEx.MoveFirst();
                    break;
                case FullTextNavigation.MovePrevious:
                    LoadLastHitDocument = HighlightLastHit;
                    if (ucRecordList1.RecordsGridEx.CurrentRow.AbsolutePosition != 1)
                        ucRecordList1.RecordsGridEx.MovePrevious();
                    else if (MessageBox.Show(LawMate.Properties.Resources.FirstDocumentJumpToTheBottom, LawMate.Properties.Resources.FullTextHitNavigation, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        ucRecordList1.RecordsGridEx.MoveLast();
                    break;
                case FullTextNavigation.MoveNext:
                    if (ucRecordList1.RecordsGridEx.CurrentRow.AbsolutePosition != ucRecordList1.RecordsGridEx.RowCount)
                        ucRecordList1.RecordsGridEx.MoveNext();
                    else if (MessageBox.Show(LawMate.Properties.Resources.LastDocumentJumpToTheTop, LawMate.Properties.Resources.FullTextHitNavigation, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        ucRecordList1.RecordsGridEx.MoveFirst();
                    break;
                case FullTextNavigation.MoveLast:
                    LoadLastHitDocument = HighlightLastHit;
                    ucRecordList1.RecordsGridEx.MoveLast();
                    break;
            }
        }

        private void fSearchResultsDoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ucDoc1.Clear();
            ucDocView1.Clear();
        }

        private void ucDoc1_DocAction(object sender, UserControls.DocActionEventArgs e)
        {
            try
            {
                lmWinHelper.DocAction(AtMng.GetFile(e.DocRecord.FileId), e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fSearchResultsDoc_Shown(object sender, EventArgs e)
        {
            try
            {
                InitDT(dm.DB.Document);
                //if (formName != null)
                //    this.Text = formName;
                fProgress.resetForm();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void ucRecordList1_RowDoubleClicked(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)this.documentBindingSource.Current).Row;
                fFile f = MainForm.OpenFile(dr.FileId);
                f.MoreInfo("document", dr.DocId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

