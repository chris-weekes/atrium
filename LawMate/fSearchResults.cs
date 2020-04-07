using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawMate
{
    public partial class fSearchResults : fBase
    {
        fAdvancedSearch myfAS;
        fWait fProgress;
        string formTitle;
        string id = "fSearchResults";

        const string LayoutVersionNumber = "4_0_19";
        System.IO.Stream gridLayoutStream = new System.IO.MemoryStream();

        public override string Id
        {
            get { return id; }
            set { id = value; }
        }

        public void ExactMatch(int hits)
        {
            if (hits == 1)
            {
                fProgress.setMessageText(LawMate.Properties.Resources.OneFileFoundOpeningFile);
                OpenFile();
                this.Close();
            }
        }
        private void LoadLabels()
        {
            //secure admin/testing menu
            if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.MassActivity) == atSecurity.SecurityManager.ExPermissions.Yes)
            {
                cmdMassActivity.Visible = Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                cmdMassActivity.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }
            lmDatasets.appDB.ddFieldRow[] dfr = (lmDatasets.appDB.ddFieldRow[])AtMng.DB.ddField.Select("FieldName='Misc1Date'");
            if (dfr.Length == 1)
            {
                eFileGridEX.RootTable.Columns["Misc1Date"].Caption = dfr[0]["Top" + AtMng.AppMan.Language].ToString();
            }
            dfr = (lmDatasets.appDB.ddFieldRow[])AtMng.DB.ddField.Select("FieldName='Misc2Date'");
            if (dfr.Length == 1)
            {
                eFileGridEX.RootTable.Columns["Misc2Date"].Caption = dfr[0]["Top" + AtMng.AppMan.Language].ToString();
            }

            gridEXPrintDocument1.DocumentName = String.Format(LawMate.Properties.Resources.SearchPrintGrid, AtMng.AppMan.AppName);
            gridEXPrintDocument1.PageFooterLeft = String.Format(LawMate.Properties.Resources.SearchPrintGrid, AtMng.AppMan.AppName);
            ucFileContextMenu1.LoadLabels();
        }
        public fSearchResults(Form f, string searchCriteria, string searchFor, string searchForType, bool SearchForExactMatch)
            : base(f)
        {
            System.DateTime start = DateTime.Now;
            InitializeComponent();
            LoadLabels();
            System.Diagnostics.Trace.WriteLine("search", "start");
            HookupfProgress((fMain)f);
            tsReviseSearchCriteria.Visible = Janus.Windows.UI.InheritableBoolean.False;

            Search srch = new Search(AtMng, eFileBindingSource);

            if (searchForType == atriumBE.OfficerPrefsBE.qsSIN)
            {
                eFileGridEX.RootTable.Columns[1].Visible = false;
                eFileGridEX.RootTable.Columns[2].Visible = true;
            }

            fProgress.setMessageText(LawMate.Properties.Resources.RetrievingDataMessage);


            if (!SearchForExactMatch)
                searchCriteria = searchCriteria + "%";

            int iHits = srch.DoSearch(searchCriteria, searchForType);
            tsMatchesCount.Text = iHits.ToString();
            if (iHits < 1)
                NoResults();
            else
                ShowResults();
            System.Diagnostics.Trace.WriteLine("search", "stop");
            TimeSpan ts = DateTime.Now.Subtract(start);
            MainForm.SetStatusMsg(String.Format(LawMate.Properties.Resources.MsElapsed, ts.TotalMilliseconds.ToString()), null);
            ExactMatch(iHits);

            InitCombos();

            fProgress.resetForm();
        }

        private void InitCombos()
        {
            UIHelper.ComboBoxInit("FileType", eFileGridEX.DropDowns["ddFileType"], AtMng.GetFile());
            UIHelper.ComboBoxInit("FileMetaType", eFileGridEX.DropDowns["ddMetaType"], AtMng.GetFile());
            UIHelper.ComboBoxInit("ReturnCode", eFileGridEX.DropDowns["ddCloseCode"], AtMng.GetFile());

            DataTable dt1 = AtMng.GetFile().Codes("Dim1");
            lmDatasets.appDB.ddLookupRow dlr1 = (lmDatasets.appDB.ddLookupRow)AtMng.DB.ddLookup.Select("LookupName='Dim1'")[0];
            eFileGridEX.RootTable.Columns["Dim1Id"].Caption = dlr1["Description" + AtMng.AppMan.Language].ToString();
            eFileGridEX.DropDowns["ddDim1"].ValueMember = dt1.PrimaryKey[0].ColumnName;
            eFileGridEX.DropDowns["ddDim1"].DisplayMember = dt1.Columns[1].ColumnName;
            eFileGridEX.DropDowns["ddDim1"].Columns[0].DataMember = dt1.Columns[1].ColumnName;
            UIHelper.ComboBoxInit(dt1, eFileGridEX.DropDowns["ddDim1"], AtMng.GetFile());

            DataTable dt2 = AtMng.GetFile().Codes("Dim2");
            lmDatasets.appDB.ddLookupRow dlr2 = (lmDatasets.appDB.ddLookupRow)AtMng.DB.ddLookup.Select("LookupName='Dim2'")[0];
            eFileGridEX.RootTable.Columns["Dim2Id"].Caption = dlr2["Description" + AtMng.AppMan.Language].ToString();
            eFileGridEX.DropDowns["ddDim2"].ValueMember = dt2.PrimaryKey[0].ColumnName;
            eFileGridEX.DropDowns["ddDim2"].DisplayMember = dt2.Columns[1].ColumnName;
            eFileGridEX.DropDowns["ddDim2"].Columns[0].DataMember = dt2.Columns[1].ColumnName;
            UIHelper.ComboBoxInit(dt2, eFileGridEX.DropDowns["ddDim2"], AtMng.GetFile());

            eFileGridEX.DropDowns["ddOffice"].SetDataBinding(AtMng.GetFile().Codes("OfficeList"), "");

            //DataTable dt3 = AtMng.GetFile().Codes("EfileLeadPL");
            //lmDatasets.appDB.ddLookupRow dlr3 = (lmDatasets.appDB.ddLookupRow)AtMng.DB.ddLookup.Select("LookupName='EfileLeadPL'")[0];
            //eFileGridEX.RootTable.Columns["LeadParaLegalCode"].Caption = dlr3["Description" + AtMng.AppMan.Language].ToString();
            //UIHelper.ComboBoxInit(dt3, eFileGridEX.DropDowns["ddOfficer"], AtMng.GetFile());

            DataTable dt3 = AtMng.GetFile().Codes("EfileLeadPL");
            lmDatasets.appDB.ddLookupRow dlr3 = (lmDatasets.appDB.ddLookupRow)AtMng.DB.ddLookup.Select("LookupName='EfileLeadPL'")[0];
            eFileGridEX.RootTable.Columns["LeadParaLegalCode"].Caption = dlr3["Description" + AtMng.AppMan.Language].ToString();
            eFileGridEX.DropDowns["ddOfficer"].ValueMember = dlr3.PKName;// dt3.Columns[4].ColumnName;
            eFileGridEX.DropDowns["ddOfficer"].DisplayMember = dt3.Columns[1].ColumnName;
            eFileGridEX.DropDowns["ddOfficer"].Columns[0].DataMember = dt3.Columns[1].ColumnName;
            UIHelper.ComboBoxInit(dt3, eFileGridEX.DropDowns["ddOfficer"], AtMng.GetFile());

            DataTable dt5 = AtMng.GetFile().Codes("EfileOfficer");
            lmDatasets.appDB.ddLookupRow dlr5 = (lmDatasets.appDB.ddLookupRow)AtMng.DB.ddLookup.Select("LookupName='EfileOfficer'")[0];
            eFileGridEX.RootTable.Columns["OfficerId"].Caption = dlr5["Description" + AtMng.AppMan.Language].ToString();
            eFileGridEX.DropDowns["ddOfficer1"].ValueMember = dlr5.PKName;// dt5.Columns[4].ColumnName;
            eFileGridEX.DropDowns["ddOfficer1"].DisplayMember = dt5.Columns[1].ColumnName;
            eFileGridEX.DropDowns["ddOfficer1"].Columns[0].DataMember = dt5.Columns[1].ColumnName;
            UIHelper.ComboBoxInit(dt5, eFileGridEX.DropDowns["ddOfficer1"], AtMng.GetFile());


            DataTable dt4 = AtMng.GetFile().Codes("EfileLeadLawyer");
            lmDatasets.appDB.ddLookupRow dlr4 = (lmDatasets.appDB.ddLookupRow)AtMng.DB.ddLookup.Select("LookupName='EfileLeadLawyer'")[0];
            eFileGridEX.RootTable.Columns["LeadLawyerId"].Caption = dlr4["Description" + AtMng.AppMan.Language].ToString();
            UIHelper.ComboBoxInit(dt4, eFileGridEX.DropDowns["ddLawyer"], AtMng.GetFile());
        }

        public fSearchResults(Form f, int contactId, string contactType)
            : base(f)
        {
            InitializeComponent();
            HookupfProgress((fMain)f);
            LoadLabels();
            contactTypeSearch(f, contactId, contactType);
            InitCombos();
        }

        public void contactTypeSearch(Form f, int contactId, string contactType)
        {
            switch (contactType)
            {
                case "*A":
                    formTitle = LawMate.Properties.Resources.UIFileShared;
                    break;

                case null:
                    formTitle = LawMate.Properties.Resources.UIFileOnWhichIAmAContact;
                    break;
                default:
                    formTitle = LawMate.Properties.Resources.UIMyAssignedFiles;
                    break;
            }

            this.id = "fSearchResultsContactType";
            this.Text = formTitle;
            tsScreenTitle2.Text = formTitle;
            System.Diagnostics.Trace.WriteLine("searchc", "start");

            Search srch = new Search(AtMng, eFileBindingSource);
            fProgress.setMessageText(LawMate.Properties.Resources.RetrievingDataMessage);
            int iHits = srch.DoSearch(contactId, contactType);
            tsMatchesCount.Text = iHits.ToString();
            if (iHits < 1)
                NoResults();
            else
                ShowResults();
            tsReviseSearchCriteria.Visible = Janus.Windows.UI.InheritableBoolean.False;

            System.Diagnostics.Trace.WriteLine("searchc", "stop");
            fProgress.resetForm();
        }

        public fSearchResults(Form f, string userName, DateTime dateStart, DateTime dateEnd)
            : base(f)
        {
            InitializeComponent();
            HookupfProgress((fMain)f);
            LoadLabels();
            DateTimeSearch(f, userName, dateStart, dateEnd);
            InitCombos();
        }

        public void DateTimeSearch(Form f, string userName, DateTime dateStart, DateTime dateEnd)
        {
            if (dateStart == DateTime.Today && dateEnd == atDates.StandardDate.Tomorrow.BeginDate)
                formTitle = LawMate.Properties.Resources.UIFilesViewedToday;
            else if (dateStart == atDates.StandardDate.Yesterday.BeginDate && dateEnd == DateTime.Today)
                formTitle = LawMate.Properties.Resources.UIFilesViewedYesterday;
            else if (dateStart == atDates.StandardDate.ThisWeek.BeginDate && dateEnd == atDates.StandardDate.ThisWeek.EndDate)
                formTitle = LawMate.Properties.Resources.UIFilesViewedThisWeek;
            else if (dateStart == atDates.StandardDate.LastWeek.BeginDate && dateEnd == atDates.StandardDate.LastWeek.EndDate)
                formTitle = LawMate.Properties.Resources.UIFilesViewedLastWeek;
            else
                formTitle = String.Format(Properties.Resources.UIFilesViewedCustom, dateStart.ToShortDateString(), dateEnd.Date.ToShortDateString());

            this.id = "fSearchResultsDateTime";
            this.Text = formTitle;
            tsScreenTitle2.Text = formTitle;

            System.Diagnostics.Trace.WriteLine("searchr", "start");

            tsReviseSearchCriteria.Visible = Janus.Windows.UI.InheritableBoolean.False;

            Search srch = new Search(AtMng, eFileBindingSource);
            fProgress.setMessageText(LawMate.Properties.Resources.RetrievingDataMessage);
            int iHits = srch.DoSearch(userName, dateStart, dateEnd);
            tsMatchesCount.Text = iHits.ToString();
            if (iHits < 1)
                NoResults();
            else
                ShowResults();

          

            tsReviseSearchCriteria.Visible = Janus.Windows.UI.InheritableBoolean.False;
            System.Diagnostics.Trace.WriteLine("searchr", "stop");
            fProgress.resetForm();
        }

        public fSearchResults(Form f, atLogic.WhereClause wc, atLogic.WhereClause wcContact, atLogic.WhereClause wcCaseStatus, fAdvancedSearch referrer, bool includeXrefs)
            : base(f)
        {
            InitializeComponent();
            HookupfProgress((fMain)f);
            LoadLabels();

            if (referrer == null) //quicksearch
            {
                tsReviseSearchCriteria.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }
            else //advanced search
            {
                formTitle = LawMate.Properties.Resources.AdvancedSearchResults;
                myfAS = referrer;
                this.Text = formTitle;
                tsScreenTitle2.Text = formTitle;
            }
            System.Diagnostics.Trace.WriteLine("searchadv", "start");

            //.GetGeneralRec("select v.* from vefile v inner join efile f on v.fileid=f.fileid " + wc.Clause());
            System.Diagnostics.Trace.WriteLine("searchadv", "bind");
            // hdrSearchCriteria.Text = wc.uiClause();

            Search srch = new Search(AtMng, eFileBindingSource);
            fProgress.setMessageText(LawMate.Properties.Resources.RetrievingDataMessage);
            int iHits = srch.DoSearch(wc, wcContact, wcCaseStatus, includeXrefs);
            tsMatchesCount.Text = iHits.ToString();
            if (iHits < 1)
                NoResults();
            else
                ShowResults();
            System.Diagnostics.Trace.WriteLine("searchadv", "stop");
            InitCombos();
            ExactMatch(iHits);
            fProgress.resetForm();
        }

        private void HookupfProgress(fMain f)
        {
            fProgress = f.FProgress;
        }
        private void NoResults()
        {
            //pnlGrid.Closed = true;
            //pnlResultCriteria.Closed = false;
            //pnlResultCriteria.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
            //tsShowDetails.Visible = Janus.Windows.UI.InheritableBoolean.False;

            eFileGridEX.Visible = false;
            lblNoMatches.Visible = true;
            cmdFieldChooser.Visible = Janus.Windows.UI.InheritableBoolean.False;
            cmdGroupBy.Visible = Janus.Windows.UI.InheritableBoolean.False;
            cmdFilter.Visible = Janus.Windows.UI.InheritableBoolean.False;
            tsOpenAndKeep1.Visible = Janus.Windows.UI.InheritableBoolean.False;
        }

        private void ShowResults()
        {
            //pnlResultCriteria.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
            //pnlGrid.Closed = false;
            //tsShowDetails.Visible = Janus.Windows.UI.InheritableBoolean.True;


            eFileGridEX.Visible = true;
            lblNoMatches.Visible = false;
            cmdFieldChooser.Visible = Janus.Windows.UI.InheritableBoolean.True;
            cmdGroupBy.Visible = Janus.Windows.UI.InheritableBoolean.True;
            cmdFilter.Visible = Janus.Windows.UI.InheritableBoolean.True;
            tsOpenAndKeep1.Visible = Janus.Windows.UI.InheritableBoolean.True;
        }

        private void eFileGridEX_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // check row type - causes error when not datarow

                //OpenFile();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void OpenFile()
        {
            int fileId = CurrentRow().FileId;
            this.MainForm.OpenFile(fileId);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdResetGrid":
                        if (gridLayoutStream != null)
                        {
                            gridLayoutStream.Position = 0;
                            // HookUpDataSource();
                            eFileGridEX.LoadLayoutFile(gridLayoutStream);
                            // UIHelper.GridToggleSelectMode(activityBFGridEX);
                            // HookUpGridExDropDowns();
                            // SetCommandsState();
                            // activityBFGridEX.Refetch();
                        }
                        break;
                    case "cmdPrintPreview":
                        UIHelper.GridExPrintPreview(gridEXPrintDocument1);
                        //gridEXPrintDocument1.PrepareDocument();
                        //gridEXPrintDocument1.PageFooterRight = DateTime.Today.ToLongDateString();
                        //PrintPreviewDialog ppDialog = new PrintPreviewDialog();
                        //ppDialog.Document = gridEXPrintDocument1;
                        //ppDialog.Document.DefaultPageSettings.Landscape = true;
                        //ppDialog.ShowDialog();
                        break;
                    case "cmdPrintGrid":
                        UIHelper.GridExPrintDocument(gridEXPrintDocument1);
                        //gridEXPrintDocument1.PrepareDocument();
                        //gridEXPrintDocument1.PageFooterRight = DateTime.Today.ToLongDateString();
                        //PrintDialog printDialog = new PrintDialog();
                        //printDialog.Document = gridEXPrintDocument1;
                        //printDialog.Document.DefaultPageSettings.Landscape = true;
                        //printDialog.AllowCurrentPage = true;
                        //printDialog.AllowPrintToFile = true;
                        //printDialog.AllowSelection = true;
                        //printDialog.AllowSomePages = true;
                        //printDialog.ShowNetwork = true;
                        //printDialog.ShowHelp = true;
                        //printDialog.UseEXDialog = true;

                        //if (printDialog.ShowDialog() == DialogResult.OK)
                        //    printDialog.Document.Print();
                        break;
                    case "tsCloseResults":
                        this.Close();
                        break;
                    case "tsOpen":
                        OpenFile();
                        this.Close();
                        break;
                    case "tsOpenAndKeep":
                        OpenFile();
                        break;
                    case "tsReviseSearchCriteria":
                        if (!myfAS.IsDisposed)
                            myfAS.Activate();
                        else
                        {
                            MessageBox.Show(LawMate.Properties.Resources.TheAdvancedSearchScreenIsNoLongerAccessible, LawMate.Properties.Resources.AdvancedSearchScreenNotAccessible, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tsReviseSearchCriteria.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        break;
                    case "tsShowDetails":
                        if (tsShowDetails.IsChecked)
                            pnlResultCriteria.Closed = false;
                        else
                            pnlResultCriteria.Closed = true;
                        break;
                    case "cmdFilter":
                        if (e.Command.IsChecked)
                            eFileGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            eFileGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "cmdGroupBy":
                        eFileGridEX.GroupByBoxVisible = e.Command.IsChecked;
                        break;
                    case "cmdFieldChooser":
                        eFileGridEX.ShowFieldChooser();
                        break;

                    case "cmdMassActivity":
                        fMassActivity fMassAct = new fMassActivity(this.MainForm, eFileBindingSource.DataSource);
                        fMassAct.Show();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void eFileGridEX_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) //display context menu
            {
                try
                {
                    if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No)
                        return;

                    if (CurrentRow() != null && eFileGridEX.HitTest() == Janus.Windows.GridEX.GridArea.Cell)
                    {


                        atriumBE.FileManager fm = AtMng.GetFile(CurrentRow().FileId);
                        FileTreeView.BuildMenu(fm, ucFileContextMenu1.uiCommandManager1.Commands["cmdFNew"], FileTreeView.dmFILENEW);
                        FileTreeView.BuidAKA(fm, ucFileContextMenu1.uiCommandManager1.Commands["cmdFileAKA"]);

                        ucFileContextMenu1.uiContextMenu4.CommandManager.Tag = CurrentRow();
                        ucFileContextMenu1.uiContextMenu4.Show();
                    }
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }

            }
        }

        private void eFileGridEX_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && eFileGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    OpenFile();
                }
                if (e.KeyValue == 93)
                {
                    ucFileContextMenu1.uiContextMenu4.CommandManager.Tag = CurrentRow();
                    ucFileContextMenu1.uiContextMenu4.Show();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private lmDatasets.appDB.EFileSearchRow CurrentRow()
        {
            return (lmDatasets.appDB.EFileSearchRow)((DataRowView)eFileBindingSource.Current).Row;
        }

        private void ucFileContextMenu1_ContextMenuClicked(object sender, FileContextEventArgs e)
        {
            lmWinHelper.HelpContextMenuClicked(MainForm, sender, e);

        }

        private void eFileGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                    OpenFile();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        string origSortkey = "";
        private void fSearchResults_Load(object sender, EventArgs e)
        {
            eFileGridEX.SaveLayoutFile(gridLayoutStream); //for resetting purposes

            lmWinHelper.LoadGridLayout(eFileGridEX, "FileSearchGridLayout", LayoutVersionNumber);
            InitCombos();

            if (id == "fSearchResultsDateTime")
            {
                if (eFileGridEX.RootTable.SortKeys.Count>0)
                    origSortkey = eFileGridEX.RootTable.SortKeys[0].Column.Key;
                eFileGridEX.RootTable.SortKeys.Clear();
            }
            eFileGridEX.Refetch();
            eFileGridEX.Focus();
            eFileGridEX.MoveFirst();
            eFileGridEX.RemoveFilters();
        }

        private void fSearchResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (id == "fSearchResultsDateTime")
            {
                if (origSortkey != "")
                    eFileGridEX.RootTable.SortKeys.Add(origSortkey);
            }

            lmWinHelper.SaveGridLayout(eFileGridEX, "FileSearchGridLayout", this.AtMng, LayoutVersionNumber);
        }

    }
}

