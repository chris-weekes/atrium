using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate
{


    public partial class fBrowse : Form
    {

        private appDB.EFileSearchRow selectedFile;
        private int selectedFileId;
        private atriumManager Atmng;
        private int RootFileId;

        public Janus.Windows.UI.Dock.UIPanelInnerContainer PanelContainerOfOpenFiles
        {
            get { return pnlActiveFilesContainer; }
        }

        public appDB.EFileSearchRow SelectedFile
        {
            get { return selectedFile; }
        }

        public int FileId
        {
            get { return selectedFileId; }
        }

        private void LoadLabels()
        {
            lblBrowseText.Text = String.Format(Properties.Resources.UseAppExplorerToNavigate, LawMate.UIHelper.AtMng.AppMan.AppName);
            lnkJumpToRoot.Text = String.Format(Properties.Resources.JumpToAppRoot, LawMate.UIHelper.AtMng.AppMan.AppName);
            
            explorerBar1.Groups["groupFiles"].Text = Properties.Resources.otkFiles;
            explorerBar1.Groups["groupFiles"].Items["ndAssFiles"].Text = Properties.Resources.otkAssignedFiles;
            explorerBar1.Groups["groupFiles"].Items["ndContactFiles"].Text = Properties.Resources.otkContactFiles;

            explorerBar1.Groups["groupRecent"].Text = Properties.Resources.otkRecentlyViewed;
            explorerBar1.Groups["groupRecent"].Items["ndToday"].Text = Properties.Resources.otkToday;
            explorerBar1.Groups["groupRecent"].Items["ndYesterday"].Text = Properties.Resources.otkYesterday;
            explorerBar1.Groups["groupRecent"].Items["ndThisWeek"].Text = Properties.Resources.otkThisWeek;
            explorerBar1.Groups["groupRecent"].Items["ndLastWeek"].Text = Properties.Resources.otkLastWeek;
            explorerBar1.Groups["groupRecent"].Items["ndCustom"].Text = Properties.Resources.otkCustom;

            cbSearchType.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchFullFileNumber, OfficerPrefsBE.qsFullFileNumber));
            cbSearchType.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchFileName, "qsFileName"));
            cbSearchType.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchFullFileName, OfficerPrefsBE.qsFullFileName));
            cbSearchType.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchFileNumber, OfficerPrefsBE.qsFileNumber));
            cbSearchType.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchSIN, OfficerPrefsBE.qsSIN));

        }

        public fBrowse()
        {
            InitializeComponent();
        }

        bool InitializeForm = true;
        public fBrowse(atriumManager atmng,int rootFileId,bool collapseLeftPanel, bool hideShortcuts, bool hideXRefs, bool hideDocShortcuts)
        {
            InitializeComponent();
            LoadLabels();
            PanelDisplayHandler(false);
            pnlLeft.Closed=collapseLeftPanel; 
            Atmng = atmng;
            ucBrowse1.LoadRoot(atmng, rootFileId,hideShortcuts,hideXRefs,hideDocShortcuts);
            ucBrowse1.ShowContextMenu = false;
            cbSearchType.SelectedIndex = 0;
            RootFileId=rootFileId;
            lblCurrentFile.Text = "";
            LoadActiveFiles();
            InitializeForm = false;
        }

        private void LoadActiveFiles()
        {
            int valX = 6;
            int valY = 6;
            try
            {


                foreach (string FileIdAsString in Atmng.LoadedFMs)
                {
                    FileManager loadedFM = Atmng.GetFile(System.Convert.ToInt32(FileIdAsString));
                    if (loadedFM.CurrentFile != null && !loadedFM.CurrentFile.IsNameENull() && !loadedFM.CurrentFile.IsNameFNull())
                    {
                        LinkLabel lnk = new LinkLabel();
                        lnk.Name = "lnk" + loadedFM.CurrentFileId;
                        lnk.Text = "       " + loadedFM.CurrentFile.Name;
                        lnk.AutoSize = true;
                        lnk.BackColor = Color.Transparent;
                        lnk.ImageList = ImageListMain;
                        lnk.ImageKey = "folder.gif";
                        lnk.ImageAlign = ContentAlignment.MiddleLeft;
                        lnk.TextAlign = ContentAlignment.MiddleLeft;
                        lnk.Left = valX;
                        lnk.Top = valY;
                        lnk.Padding = new Padding(0, 0, 0, 0);
                        lnk.Margin = new Padding(0, 0, 0, 0);
                        lnk.Tag = loadedFM.CurrentFileId;
                        lnk.LinkClicked += new LinkLabelLinkClickedEventHandler(lnk_LinkClicked);
                        valY += 18;

                        pnlActiveFilesContainer.Controls.Add(lnk);
                    }
                }
            }
            catch (Exception x)
            {
                //suppress the error and move on
            }
        }

        void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Application.UseWaitCursor=true;
                LinkLabel lbl = (LinkLabel)sender;
                ucBrowse1.FindFile((int)lbl.Tag);
                Application.UseWaitCursor=false;
            }
            catch (Exception x)
            {
                Application.UseWaitCursor=true;
                UIHelper.HandleUIException(x);
            }
        }

      
        public fBrowse(atriumManager atmng)
        {
            
            InitializeComponent();
            PanelDisplayHandler(false);
            ucBrowse1.LoadRoot(atmng, 0,false,false,false);
            ucBrowse1.ShowContextMenu = false;
            Atmng = atmng;
            cbSearchType.SelectedIndex = 0;

            lblCurrentFile.Text = "";
        }

        private void ucBrowse1_FileSelected(object sender, FileContextEventArgs e)
        {
            SetSelectedFile(ucBrowse1);
        }

        private void SetSelectedFile(UserControls.ucBrowse ucb)
        {
            if (ucb.SelectedFile != null)
            {
                selectedFile = ucb.SelectedFile;
                selectedFileId = (int)selectedFile["FileId"];
                buttonOK.Enabled = true;
                lblCurrentFile.Text = selectedFile.Name + " (" + selectedFile.FullFileNumber + ")";
            }
            else
            {
                selectedFile = null;
                buttonOK.Enabled = false;
                lblCurrentFile.Text = "";
            }
        }

        private void SetSelectedFile(BindingSource bs)
        {
            if (bs.Current != null)
            {
                selectedFile = (appDB.EFileSearchRow)((DataRowView)bs.Current).Row;
                buttonOK.Enabled = true;
                lblCurrentFile.Text = selectedFile.Name + " (" + selectedFile.FullFileNumber + ")";
            }
            else
            {
                selectedFile = null;
                buttonOK.Enabled = false;
                lblCurrentFile.Text = "";
            }
                
        }

        bool lookupsLoaded = false;
        private void LoadLookups()
        {
            FileManager fm = Atmng.GetFile();

            UIHelper.ComboBoxInit("vOfficerList", eFileGridEX.DropDowns["ddPL"], fm);
            UIHelper.ComboBoxInit("vLawyerList", eFileGridEX.DropDowns["ddLA"], fm);
            UIHelper.ComboBoxInit("vofficelist", eFileGridEX.DropDowns["ddOffice"], fm);
            UIHelper.ComboBoxInit("FileType", eFileGridEX.DropDowns["ddFileType"], fm);
            UIHelper.ComboBoxInit("FileMetaType", eFileGridEX.DropDowns["ddMetaType"], fm);
            lookupsLoaded = true;
        }

        bool NoResultPnlDisplayed = false;
        private void btnExecuteSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void DoSearch()
        {
            try
            {
                Application.UseWaitCursor=true;
                pnlNoSearchResults.Closed = true;
                if (!lookupsLoaded)
                    LoadLookups();

                if (ebSearchFor.Text.Length > 0)
                {
                    Search srch = new Search(Atmng, eFileBindingSource);

                    string searchTerm = UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, ebSearchFor.Text);

                    srch.DoSearch(searchTerm, cbSearchType.SelectedItem.Value.ToString());
                    if (eFileBindingSource.Count == 0)
                    {
                        NoResultPnlDisplayed = true;
                        pnlNoSearchResults.Closed = false;
                        lblNoResultSearchTerm.Text = ebSearchFor.Text;
                    }
                    else
                    {
                        NoResultPnlDisplayed = false;
                        pnlNoSearchResults.Closed = true;
                        lblNoResultSearchTerm.Text = "";
                    }


                    if (cbSearchType.SelectedItem.Value.ToString() == "SIN")
                    {
                        eFileGridEX.RootTable.Columns["FullFileNumber"].Visible = false;
                        eFileGridEX.RootTable.Columns["SIN"].Visible = true;
                    }
                    else
                    {
                        eFileGridEX.RootTable.Columns["FullFileNumber"].Visible = true;
                        eFileGridEX.RootTable.Columns["SIN"].Visible = false;
                    }

                    PanelDisplayHandler(true);
                    eFileGridEX.MoveFirst();
                    eFileGridEX.Focus();
                }
                else
                    MessageBox.Show(Properties.Resources.UIMissingCriteria);

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally
            {
                Application.UseWaitCursor=false;
            }
        }

        private void PanelDisplayHandler(bool showResults)
        {
            if (showResults)
            {
                if (NoResultPnlDisplayed)
                    pnlNoSearchResults.Closed = false;
                uiTabPage1.TabVisible = false;
                uiTabPage2.TabVisible = true;
                uiTab1.SelectedTab = uiTabPage2;
                if(!InitializeForm)
                    SetSelectedFile(eFileBindingSource);
            }
            else
            {
                uiTabPage1.TabVisible = true;
                uiTabPage2.TabVisible = false;
                uiTab1.SelectedTab = uiTabPage1;
                pnlNoSearchResults.Closed = true;
                if(!InitializeForm)
                    SetSelectedFile(ucBrowse1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uiTabPage1.TabVisible)
                    selectedFileId = SelectedFile.FileId;
                else
                    selectedFileId = ucBrowse1.SelectedFile.FileId;

                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void eFileGridEX_DoubleClick(object sender, EventArgs e)
        {
            selectedFileId = SelectedFile.FileId;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void explorerBar1_ItemClick(object sender, Janus.Windows.ExplorerBar.ItemEventArgs e)
        {
            try
            {
                Application.UseWaitCursor=true;
                if (!lookupsLoaded)
                    LoadLookups();

                Search srch = new Search(Atmng, eFileBindingSource);
                switch (e.Item.Key)
                {
                    case "ndToday":
                        srch.DoSearch(Atmng.WorkingAsOfficer.UserName, DateTime.Today, atDates.StandardDate.Tomorrow.BeginDate);
                        break;
                    case "ndYesterday":
                        srch.DoSearch(Atmng.WorkingAsOfficer.UserName, atDates.StandardDate.Yesterday.BeginDate, DateTime.Today);
                        break;
                    case "ndLastWeek":
                        srch.DoSearch(Atmng.WorkingAsOfficer.UserName, atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                        break;
                    case "ndThisWeek":
                        srch.DoSearch(Atmng.WorkingAsOfficer.UserName, atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                        break;
                    case "ndCustom":
                        fCustomDateRange fDateRangeFiles = new fCustomDateRange();
                        if (fDateRangeFiles.ShowDialog() == DialogResult.OK)
                            srch.DoSearch(Atmng.WorkingAsOfficer.UserName, (DateTime)fDateRangeFiles.BeginDate, (DateTime)fDateRangeFiles.EndDate);
                        break;
                    case "ndAssFiles":
                        srch.DoSearch(Atmng.WorkingAsOfficer.ContactId, Atmng.WorkingAsOfficer.PositionCode);
                        break;
                    case "ndContactFiles":
                        srch.DoSearch(Atmng.WorkingAsOfficer.ContactId, null);
                        break;
                    default:
                        return;
                }
                eFileGridEX.RootTable.Columns["FullFileNumber"].Visible = true;
                eFileGridEX.RootTable.Columns["SIN"].Visible = false;
                eFileGridEX.Focus();
                Application.UseWaitCursor=false;
            }
            catch (Exception x)
            {
                Application.UseWaitCursor=false;
                UIHelper.HandleUIException(x);
            }
        }

        //private void tvMyFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    try
        //    {
        //        if (!lookupsLoaded)
        //            LoadLookups();

        //        Search srch = new Search(Atmng, eFileBindingSource);
        //            switch (e.Node.Name)
        //            {
        //                case "ndToday":
        //                    srch.DoSearch(Atmng.WorkingAsOfficer.UserName, DateTime.Today, atDates.StandardDate.Tomorrow.BeginDate);
        //                    break;
        //                case "ndYesterday":
        //                    srch.DoSearch(Atmng.WorkingAsOfficer.UserName, atDates.StandardDate.Yesterday.BeginDate, DateTime.Today);
        //                    break;
        //                case "ndLastWeek":
        //                    srch.DoSearch(Atmng.WorkingAsOfficer.UserName,atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
        //                    break;
        //                case "ndThisWeek":
        //                    srch.DoSearch(Atmng.WorkingAsOfficer.UserName, atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
        //                    break;
        //                case "ndCustom":
        //                    fCustomDateRange fDateRangeFiles = new fCustomDateRange();
        //                    if (fDateRangeFiles.ShowDialog() == DialogResult.OK)
        //                        srch.DoSearch(Atmng.WorkingAsOfficer.UserName,(DateTime)fDateRangeFiles.BeginDate, (DateTime)fDateRangeFiles.EndDate);
        //                    break;
        //                case "ndAssFiles":
        //                    srch.DoSearch(Atmng.WorkingAsOfficer.ContactId, Atmng.WorkingAsOfficer.PositionCode);
        //                    break;
        //                case "ndContactFiles":
        //                    srch.DoSearch(Atmng.WorkingAsOfficer.ContactId, null);
        //                    break;
        //                default:
        //                    return;
        //            }
        //            eFileGridEX.RootTable.Columns["FullFileNumber"].Visible = true;
        //            eFileGridEX.RootTable.Columns["SIN"].Visible = false;
        //            eFileGridEX.Focus();
                    
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFile = null;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }


        private void uiPanelManager1_PanelActivated(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            if (e.Panel.Name == pnlMyFiles.Name)
            {
                PanelDisplayHandler(true);
            }
            else if(e.Panel.Name== pnlSearch.Name)
            {
                PanelDisplayHandler(true);
                ebSearchFor.Focus();
                ebSearchFor.SelectAll();
            }
            else if (e.Panel.Name == pnlBrowseSelect.Name)
            {
                PanelDisplayHandler(false);
            }
            else if (e.Panel.Name == pnlActiveFiles.Name)
            {
                PanelDisplayHandler(false);
            }

        }

        private void eFileBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                SetSelectedFile(eFileBindingSource);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void lnkJumpToRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Application.UseWaitCursor=true;
                ucBrowse1.ReloadRoot();
                Application.UseWaitCursor=false;
                //ucBrowse1.clearTreeViewNodes();
                //ucBrowse1.LoadRoot(Atmng, 0,false,false,false);
            }
            catch (Exception x)
            {
                Application.UseWaitCursor=false;
                UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Application.UseWaitCursor=true;
                ucBrowse1.FindFile(Atmng.WorkingAsOfficer.ShortcutsId);
                Application.UseWaitCursor=false;
            }
            catch (Exception x)
            {
                Application.UseWaitCursor=false;
                UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Application.UseWaitCursor=true;
                ucBrowse1.FindFile(Atmng.WorkingAsOfficer.MyFileId);
                Application.UseWaitCursor=false;
            }
            catch (Exception x)
            {
                Application.UseWaitCursor=false;
                UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Application.UseWaitCursor=true;
                ucBrowse1.FindFile(RootFileId);
                Application.UseWaitCursor=false;
            }
            catch (Exception x)
            {
                Application.UseWaitCursor=false;
                UIHelper.HandleUIException(x);
            }
        }

        public void FindFile(int fileId)
        {
            Application.UseWaitCursor=true;
            ucBrowse1.FindFile(fileId);
            Application.UseWaitCursor=false;

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

        private void lnkRecentlyBrowsed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                pnlLeft.SelectedPanel = pnlActiveFiles;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void lnkJumpToSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                pnlLeft.SelectedPanel = pnlSearch;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tbSearchFor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    DoSearch();
                }
            }
            catch (Exception x)
            {

            }   
        }

        private void ucBrowse1_ContextMenuClicked(object sender, FileContextEventArgs e)
        {
            try
            {
                Application.UseWaitCursor=true;
                switch (e.MenuItem)
                {
                    case FileContextMenuItem.BrowseFileInExplorer:

                        ucBrowse1.myFTV.FindNode(e.SelectedFile);
                        break;
                    case FileContextMenuItem.Refresh:
                        e.Node.Nodes.Clear();
                        ucBrowse1.myFTV.LoadLevelPublic(e.Node, e.SelectedFile);
                        e.Node.Expand();
                        break;
              
                }
                Application.UseWaitCursor=false;
            }
            catch (Exception x)
            {
                Application.UseWaitCursor=false;
                UIHelper.HandleUIException(x);
            }

        }

        private lmDatasets.appDB.EFileSearchRow CurrentRow()
        {
            return (lmDatasets.appDB.EFileSearchRow)((DataRowView)eFileBindingSource.Current).Row;
        }

        private void eFileGridEX_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) //display context menu
            {
                try
                {
                    //TODO:create context menu control 
                    //raise event
                    if (CurrentRow() != null && eFileGridEX.HitTest() == Janus.Windows.GridEX.GridArea.Cell)
                    {

                        Application.UseWaitCursor=true;
                        atriumBE.FileManager fm = Atmng.GetFile(CurrentRow().FileId);
                        FileTreeView.BuildMenu(fm, ucFileContextMenu1.uiCommandManager1.Commands["cmdFNew"], FileTreeView.dmFILENEW);
                        FileTreeView.BuidAKA(fm, ucFileContextMenu1.uiCommandManager1.Commands["cmdFileAKA"]);

                        ucFileContextMenu1.uiContextMenu7.CommandManager.Tag = CurrentRow();
                        ucFileContextMenu1.uiContextMenu7.Show();
                        Application.UseWaitCursor=false;
                    }
                }
                catch (Exception x)
                {
                    Application.UseWaitCursor=false;
                    UIHelper.HandleUIException(x);
                }

            }
        }

        private void ucFileContextMenu1_ContextMenuClicked(object sender, FileContextEventArgs e)
        {

        }

    }
}