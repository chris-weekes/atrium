using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

namespace LawMate
{

    public partial class fMain : Form
    {
        FileTreeView ftvMyFile;
        fTriangle HelpTriangle = null;
        OfficerPrefsBE OfficerPref;
        public ImageList mainImageList;

        private fWait fProgress;

        //const string LayoutVersionNumber = "4_1_6"; //COMMENTED OUT. JLL - I don't see any benefit to storing layout ... anytime we make a change (for instance the SystemMessage panel), it can cause issues.  We do not care about the state of the panel layout.

        public fWait FProgress
        {
            get
            {
                if (this.fProgress == null || this.fProgress.IsDisposed)
                    fProgress = new fWait();
                return this.fProgress;
            }
        }

        private fBrowseDocs openDocDialog;
        public fBrowseDocs OpenDocDialog
        {
            get
            {
                if (this.openDocDialog == null)
                    openDocDialog = new fBrowseDocs(AtMng);

                return this.openDocDialog;
            }
        }

        private string fMainStyleScheme;
        public string FMainStyleScheme
        {
            get { return fMainStyleScheme; }
        }

        private Janus.Windows.Common.VisualStyleManager fMainStyleManager;
        public Janus.Windows.Common.VisualStyleManager FMainStyleManager
        {
            get { return fMainStyleManager; }
        }

        Dictionary<int, Janus.Windows.UI.Dock.UIPanel> OfficerToolkits = new Dictionary<int, Janus.Windows.UI.Dock.UIPanel>();

        static public bool SaveSettings = true;
        public static fSplash splash;
        public static fMain Main;
        string appOwner;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));

        public fMain(string[] args)
        {
            InitializeComponent();

            Main = this;

            this.Visible = false;
            try
            {

                if (splash == null)
                {
                    splash = new fSplash();
                    splash.Show(this);
                    splash.Refresh();
                    splash.setMessageText(String.Format(LawMate.Properties.Resources.UILoggingIntoLawMate, AtMng.AppMan.AppName));
                    splash.incrementProgressBar(10);
                }
                //if (Atmng == null)
                //    Atmng = UIHelper.Login();

                AtMng.LoadDDInfo();
                ChangeLanguage(AtMng.AppMan.Language);

                appOwner = AtMng.GetSetting(AppStringSetting.OwnerOfficeEng);
                if (AtMng.AppMan.Language == "FRE")
                    appOwner = AtMng.GetSetting(AppStringSetting.OwnerOfficeFre);

                this.Text = AtMng.AppMan.AppName + " - " + appOwner + " - " + AtMng.AppMan.ServerName + " - " + Properties.Resources.ProtectedB;

                //JLL:2014-07-23
                //verify file tenant permission for browse capacity; e.i. no atrium explorer
                //should we wrap this around a clasmngr check? otherwise the feature MUST be implemented elsewhere (i.e. SST)
                //if flip the check around?  if canexec == no, hide btn
                if (!(AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.FileOwner) == atSecurity.SecurityManager.ExPermissions.Yes))
                {
                    cmdDocBrowser.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    btnAtriumExplorer.Enabled = false;
                }

                //secure admin/testing menu
                if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.DataAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                {
                    cmdUtilities.Visible = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    cmdUtilities.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }

                //readonly account
                bool isNotReadOnly = true;
                if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No)
                    isNotReadOnly = false;
                
                btnMailBrowser.Visible = isNotReadOnly;
                btnAutoSave.Visible = isNotReadOnly;
                btnMandates.Visible = isNotReadOnly;
                btnTimekeeping.Visible = isNotReadOnly;
                btnAtriumExplorer.Visible = isNotReadOnly;
                if (!isNotReadOnly)
                {
                    cmdAdvancedFileSearch.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdAdvancedSearchDocs.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdSearchContacts.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdOutlook.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdAutoSave.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdMandates.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdMandateControlPopup.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdDocBrowser.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdGoToTimekeeping.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdIssues.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdReports.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdTriangle.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdPreferences.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }

               
                //secure vc assignment tool
                if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.MemberProfile) == atSecurity.SecurityManager.ExPermissions.Yes)
                {
                    cmdMemberAssignmentTool.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    btnMemberAssignmentTool.Visible = true;
                }
                else
                {
                    cmdMemberAssignmentTool.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    btnMemberAssignmentTool.Visible = false;
                }

                //load all activity config info
                AtMng.acMng.LoadAllConfigInfo();
                AtMng.InitMailSubSystem();

                //set OfficerPrefBE
                OfficerPref = AtMng.OfficeMng.GetOfficerPrefs();

                if (AtMng.SecurityManager.CurrentUser.AuthType == 0)
                {
                    cmdChangePassword.Visible = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    cmdChangePassword.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }

                //load frequently used code tables
                AtMng.GetCodeTableBE("FileType").Load();
                AtMng.GetCodeTableBE("Status").Load();

                splash.incrementProgressBar(10);
                AtMng.AppMan.AlertRaised += new atriumBE.AlertHandler(atmng_AlertRaised);

                ProcessCommandArgs(args);
                splash.incrementProgressBar(10);
                mainImageList = UIHelper.browseImgList();
                splash.incrementProgressBar(10);
            }
            catch (Exception x)
            {
                if (splash != null)
                    splash.Close();

                throw x;
            }
        }
        public void ProcessCommandArgs(string[] args)
        {
            if (args == null)
                return;

            foreach (string arg in args)
            {

                XmlTextReader r = new XmlTextReader(arg);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(r);


                foreach (XmlElement xe in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (xe.Name)
                    {
                        case "FileName":
                            break;
                        case "Action":
                            switch (xe.GetAttribute("ActionName"))
                            {
                                case "View":
                                    int fileId = System.Convert.ToInt32(xe.SelectSingleNode("FileId").InnerText);
                                    OpenFile(fileId);
                                    break;
                                case "DocLink":
                                    int fileId1 = System.Convert.ToInt32(xe.SelectSingleNode("FileId").InnerText);
                                    fFile f = OpenFile(fileId1);
                                    int docId = System.Convert.ToInt32(xe.SelectSingleNode("DocId").InnerText);
                                    f.MoreInfo("Document", docId); ;

                                    break;
                            }
                            break;
                    }
                }
                r.Close();

            }
        }

        delegate void SetTextCallback(string msg, bool close);
        private void SetText(string msg, bool close)
        {
            if (ebAtriumMessage.InvokeRequired && pnlSysMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { msg, close });
            }
            else
            {
                ebAtriumMessage.Text = msg;
                pnlSysMessage.Closed = close;
            }
        }

        public void SetStatusMsg(string msg, Image img)
        {
            this.uiStatusBar1.Panels["Message"].Visible = true;
            this.uiStatusBar1.Panels["Message"].Text = msg;
            this.uiStatusBar1.Panels["Message"].Image = img;
        }

        public void SetBlueBar(string msg) 
        {
            if (!SysMessageClosed)
                SetText(msg, false);
        }

        void atmng_AlertRaised(object sender, atriumBE.MessageArgs e)
        {
            try
            {
                if (e.Type == MessageType.System)
                    SetBlueBar(e.Message);
                else if (e.Type == MessageType.Mail)
                {
                    this.uiStatusBar1.Panels["MailMessage"].Text = e.Message;
                    this.uiStatusBar1.Panels["MailMessage"].Visible = true;
                }
                else if (e.Type == MessageType.Alert)
                    MessageBox.Show(e.Message, "atrium", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception x)
            {
                //JLL: should we just ignore errors here instead?... boohoo a message didn't get displayed.
                UIHelper.HandleUIException(x);
            }
        }
        public atriumBE.atriumManager AtMng
        {
            get { return UIHelper.AtMng; }
        }

        private void ExecuteSearch(bool useCmdBarValues)
        {
            uiStatusBar1.Panels["Message"].Text = "";

            Janus.Windows.EditControls.UIComboBox cb;
            string textBoxSearchText;

            if (useCmdBarValues)
            {
                cb = uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox();
                textBoxSearchText = uiCommandBar3.Commands["cmdSearchText"].GetTextBox().Text;
            }
            else
            {
                cb = cbSearch;
                textBoxSearchText = ebSearch.Text;
            }

            FProgress.setMessageText(LawMate.Properties.Resources.ExecutingSearch);
            FProgress.Show();

            string SearchTerm = textBoxSearchText.Trim();

            if ((SearchTerm.Length > 0 && SearchTerm != String.Format(LawMate.Properties.Resources.uiSearchLawMateTextBox, AtMng.AppMan.AppName)) && cb.Text.Length > 0)
            {
                //Save "Search On" preference if remember search is on
                if (AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.RememberSearchOnSelection, true))
                    AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.SearchOnDefault, cb.SelectedItem.Value.ToString());


                if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsDocSubj)
                {
                    atLogic.WhereClause wc = new atLogic.WhereClause();
                    wc.Add("d.efSubject", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, SearchTerm));

                    fSearchResultsDoc fSR = new fSearchResultsDoc(this, wc, null, "", false, null, false);
                    fSR.Show();
                }

                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsOpnSubj)
                {
                    atLogic.WhereClause wc = new atLogic.WhereClause();
                    wc.Add("d.Opinion", "=", 1);
                    wc.Add("d.efSubject", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, SearchTerm));

                    fSearchResultsDoc fSR = new fSearchResultsDoc(this, wc, null, "", false, null, true);
                    fSR.Show();
                }
                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsDocFullText)
                {
                    fSearchResultsDoc fSR = new fSearchResultsDoc(this, null, null, UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, SearchTerm), false, null, false);
                    fSR.Show();
                }
                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsOpnFullText)
                {
                    fSearchResultsDoc fSR = new fSearchResultsDoc(this, null, null, UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, SearchTerm), false, null, true);
                    fSR.Show();
                }
                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsDocBool)
                {
                    fSearchResultsDoc fSR = new fSearchResultsDoc(this, null, null, UIHelper.BuildContains(SearchContainsOptions.BooleanSearch, SearchTerm), false, null, false);
                    fSR.Show();
                }
                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsOpnBool)
                {
                    fSearchResultsDoc fSR = new fSearchResultsDoc(this, null, null, UIHelper.BuildContains(SearchContainsOptions.BooleanSearch, SearchTerm), false, null, true);
                    fSR.Show();
                }
                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsFileNameEng)
                {
                    atLogic.WhereClause wc = new atLogic.WhereClause();
                    if(chkQSExactMatch.Checked)
                        wc.Add("f.namee", "like", SearchTerm);
                    else
                        wc.Add("f.namee", "like", SearchTerm + "%");

                    fSearchResults fSR = new fSearchResults(this, wc, null, null,null, false);
                    if (!fSR.IsDisposed)
                        fSR.Show();
                }
                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsFileNameFre)
                {
                    atLogic.WhereClause wc = new atLogic.WhereClause();
                    if (chkQSExactMatch.Checked)
                        wc.Add("f.namef", "like", SearchTerm);
                    else
                        wc.Add("f.namef", "like", SearchTerm + "%");

                    fSearchResults fSR = new fSearchResults(this, wc, null, null, null, false);
                    if (!fSR.IsDisposed)
                        fSR.Show();
                }
                else if (cb.SelectedItem.Value.ToString() == OfficerPrefsBE.qsFullFileName)
                {
                    atLogic.WhereClause wc = new atLogic.WhereClause();
                    wc.Add("f.fullpath", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, SearchTerm));

                    fSearchResults fSR = new fSearchResults(this, wc, null, null,null, false);
                    if (!fSR.IsDisposed)
                        fSR.Show();
                }
                else
                {
                    //File Search
                    fSearchResults fSR = new fSearchResults(this, SearchTerm, cb.Text, cb.SelectedItem.Value.ToString(), chkQSExactMatch.Checked);
                    if (!fSR.IsDisposed)
                        fSR.Show();
                }

                FProgress.resetForm();
            }
            else
            {
                MessageBox.Show(LawMate.Properties.Resources.UIQuickSearchMissingCriteria, LawMate.Properties.Resources.UIQuickSearchMissingCriteriaCaption, MessageBoxButtons.OK);
                FProgress.resetForm();
            }
        }

        private void whatsNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fWebBrowser f = new fWebBrowser(this);
                f.NavigateToWhatsNew();
                f.MdiParent = this;
                f.Show();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        public int UserScreenResolution
        {
            get
            {
                return screenRes;
            }
        }

        public int NavPanelWidth
        {
            get
            {
                return pnlNav.Width;
            }
        }

        private int screenRes;


        private DataTable dtSearchOnListVisible;

        private void PopulateSearchOnOptions(Janus.Windows.EditControls.UIComboBox combo)
        {
            combo.DataSource = null;
            combo.Items.Clear();
            combo.ImageList = mainImageList;

            dtSearchOnListVisible = new DataTable();
            dtSearchOnListVisible.Columns.Add("value", System.Type.GetType("System.String"));
            dtSearchOnListVisible.Columns.Add("text", System.Type.GetType("System.String"));
            dtSearchOnListVisible.Columns.Add("order", System.Type.GetType("System.Int32"));
            dtSearchOnListVisible.Columns.Add("image", System.Type.GetType("System.Int32"));

            OfficerPrefsBE prefBE = AtMng.OfficeMng.GetOfficerPrefs();

            if (prefBE.GetPref(OfficerPrefsBE.qsOpnBool, 1) > 0)
                dtSearchOnListVisible.Rows.Add("qsOpnBool", LawMate.Properties.Resources.QuickSearchOpinionBooleanSearch, prefBE.GetPref(OfficerPrefsBE.qsOpnBool, 1), 18);

            if (prefBE.GetPref(OfficerPrefsBE.qsOpnFullText, 2) > 0)
                dtSearchOnListVisible.Rows.Add("qsOpnFullText", LawMate.Properties.Resources.QuickSearchFullTextOfOpinions, prefBE.GetPref(OfficerPrefsBE.qsOpnFullText, 2), 18);

            if (prefBE.GetPref(OfficerPrefsBE.qsOpnSubj, 3) > 0)
                dtSearchOnListVisible.Rows.Add("qsOpnSubj", LawMate.Properties.Resources.QuickSearchOpinionSubjectDescription, prefBE.GetPref(OfficerPrefsBE.qsOpnSubj, 3), 18);

            if (prefBE.GetPref(OfficerPrefsBE.qsDocBool, 4) > 0)
                dtSearchOnListVisible.Rows.Add("qsDocBool", LawMate.Properties.Resources.BooleanSearch, prefBE.GetPref(OfficerPrefsBE.qsDocBool, 4), 23);

            if (prefBE.GetPref(OfficerPrefsBE.qsDocFullText, 5) > 0)
                dtSearchOnListVisible.Rows.Add("qsDocFullText", LawMate.Properties.Resources.QuickSearchFullText, prefBE.GetPref(OfficerPrefsBE.qsDocFullText, 5), 23);

            if (prefBE.GetPref(OfficerPrefsBE.qsDocSubj, 6) > 0)
                dtSearchOnListVisible.Rows.Add("qsDocSubj", LawMate.Properties.Resources.QuickSearchSubject, prefBE.GetPref(OfficerPrefsBE.qsDocSubj, 6), 23);

            if (prefBE.GetPref(OfficerPrefsBE.qsFileNameEng, 7) > 0)
                dtSearchOnListVisible.Rows.Add("qsFileNameEng", LawMate.Properties.Resources.AdvSearchFileNameEnglish, prefBE.GetPref(OfficerPrefsBE.qsFileNameEng, 7), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsFileNameFre, 8) > 0)
                dtSearchOnListVisible.Rows.Add("qsFileNameFre", LawMate.Properties.Resources.AdvSearchFileNameFrench, prefBE.GetPref(OfficerPrefsBE.qsFileNameFre, 8), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsFullFileName, 9) > 0)
                dtSearchOnListVisible.Rows.Add("qsFullFileName", LawMate.Properties.Resources.QuickSearchFullFileName, prefBE.GetPref(OfficerPrefsBE.qsFullFileName, 9), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsFileNumber, 10) > 0)
                dtSearchOnListVisible.Rows.Add("qsFileNumber", LawMate.Properties.Resources.QuickSearchFileNumber, prefBE.GetPref(OfficerPrefsBE.qsFileNumber, 10), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsFullFileNumber, 11) > 0)
                dtSearchOnListVisible.Rows.Add("qsFullFileNumber", LawMate.Properties.Resources.QuickSearchFullFileNumber, prefBE.GetPref(OfficerPrefsBE.qsFullFileNumber, 11), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsiCaseFileNumber, 12) > 0)
                dtSearchOnListVisible.Rows.Add("qsiCaseFileNumber", LawMate.Properties.Resources.QuickSearchIcase, prefBE.GetPref(OfficerPrefsBE.qsiCaseFileNumber, 12), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsSIN, 13) > 0)
                dtSearchOnListVisible.Rows.Add("qsSIN", LawMate.Properties.Resources.QuickSearchSIN, prefBE.GetPref(OfficerPrefsBE.qsSIN, 0), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsLastName, 14) > 0)
                dtSearchOnListVisible.Rows.Add("qsLastName", LawMate.Properties.Resources.QuickSearchLastName, prefBE.GetPref(OfficerPrefsBE.qsLastName, 0), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsOfficeFileNumber, 15) > 0)
                dtSearchOnListVisible.Rows.Add("qsOfficeFileNumber", LawMate.Properties.Resources.QuickSearchOfficeFileNumber, prefBE.GetPref(OfficerPrefsBE.qsOfficeFileNumber, 0), 0);



            DataRow[] drs = dtSearchOnListVisible.Select("", "order");
            bool SearchOnDefaultInList = false;
            string SearchOnDefault = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.SearchOnDefault, OfficerPrefsBE.qsOpnBool);
            foreach (DataRow dr in drs)
            {
                combo.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(dr["text"].ToString(), (object)dr["value"], (int)dr["image"]));
                if ((string)dr["value"] == SearchOnDefault)
                    SearchOnDefaultInList = true;
            }

            if (SearchOnDefaultInList)
                combo.SelectedValue = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.SearchOnDefault, OfficerPrefsBE.qsFullFileNumber);
            else
            {
                combo.SelectedIndex = 0;
                if (AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.RememberSearchOnSelection, true))
                    AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.SearchOnDefault, cbSearchOn.SelectedItem.Value.ToString());
            }
        }

        private void LoadLabels()
        {
            

            cmdLSBDeskbook.Text = string.Format(LawMate.Properties.Resources.cmdDeskbook, appOwner);
            cmdAbout.Text = string.Format(LawMate.Properties.Resources.cmdAbout, AtMng.AppMan.AppName);
            cmdDocBrowser.Text = string.Format(LawMate.Properties.Resources.cmdExplorer, AtMng.AppMan.AppName);
            
            //new "toolbar"
            btnAtriumExplorer.ToolTipText = string.Format(LawMate.Properties.Resources.cmdExplorer, AtMng.AppMan.AppName);

            cmdDocBrowser.ToolTipText = string.Format(LawMate.Properties.Resources.cmdExplorer, AtMng.AppMan.AppName);
            if (AtMng.AppMan.AppName == "Atrium")
                this.Icon = LawMate.Properties.Resources.AtriumTrans48x48;
            else
                this.Icon = LawMate.Properties.Resources.scale_icon;
        }

        public bool AppStartup = false;

        Janus.Windows.EditControls.UIComboBox cbSearchOn;

        private void fMain_Load(object sender, EventArgs e)
        {
            try
            {

              

                AppStartup = true;
                this.Visible = false;
                //lmWinHelper.LoadPanelManagerLayout(uiPanelManager1, "fMainPanelManager" + LayoutVersionNumber);
                LoadLabels();

                uiStatusBar1.Panels["OfficerCode"].Text = AtMng.OfficerLoggedOn.LastName + ", " + AtMng.OfficerLoggedOn.FirstName + " (" + AtMng.OfficerLoggedOn.OfficerCode + ")";

                AtMng.GetFile().GetDocMng().GetDocument().GetCheckOutPath();

                splash.incrementProgressBar(10);
                fMainStyleManager = visualStyleManager1;
                SetVisualStyle(AtMng.OfficerLoggedOn.OfficerId);
                LoadToolkits();

                //set runtime values for janus toolbar
                TextBox tb = uiCommandBar3.Commands["cmdSearchText"].GetTextBox();
                tb.ForeColor = SystemColors.ControlDark;
                tb.Font = new Font(tb.Font, FontStyle.Italic);
                tb.Text = String.Format(LawMate.Properties.Resources.uiSearchLawMateTextBox, AtMng.AppMan.AppName);
                tb.GotFocus += new EventHandler(tb_GotFocus);
                tb.KeyDown += new KeyEventHandler(tb_KeyDown);
                tb.TextChanged += new EventHandler(tb_TextChanged);
                tb.TabStop = true;
                tb.TabIndex = 0;
                tb.Width = 200;
                
                ebSearch.Text = String.Format(LawMate.Properties.Resources.uiSearchLawMateTextBox, AtMng.AppMan.AppName);
                ebSearch.ForeColor = SystemColors.ControlDark;
                ebSearch.Font = new Font(tb.Font, FontStyle.Italic);

                cbSearchOn = uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox();
                cbSearchOn.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;

                //cbSearchOn.ImageList = ImageListMain;
                cbSearchOn.HasImage = true;
                PopulateSearchOnOptions(cbSearchOn);
                PopulateSearchOnOptions(cbSearch);

                cbSearchOn.MaxDropDownItems = 16;
                cbSearchOn.Width = 170;


                cbSearchOn.TabStop = true;
                cbSearchOn.TabIndex = 0;
                cbSearchOn.KeyDown += new KeyEventHandler(cb_KeyDown);
                cbSearchOn.SelectedItemChanged += new EventHandler(cb_SelectedItemChanged);


                Screen screen = Screen.PrimaryScreen;
                screenRes = screen.Bounds.Width;

                //check officer pref
                Janus.Windows.EditControls.UIComboBox cb = uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox();
                cb.SelectedValue = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.SearchOnDefault, OfficerPrefsBE.qsOpnBool);
                cbSearch.SelectedValue = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.SearchOnDefault, OfficerPrefsBE.qsOpnBool);

                CheckBillingOrTK();

                //hit count
                uiCommandBar2.Visible = false;
                pnlToolbar2.Closed = true;
                //pnlToolbar.Height = 30;

                cmdHitCountValue.Text = "";
                //timer delau
                if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                    timHitCountDelay.Interval = OfficerPref.GetPref(OfficerPrefsBE.HitCountTimerDelay, 300);


                splash.incrementProgressBar(10);

                this.Refresh();

                splash.incrementProgressBar(10);

                //open logged on officer personal file
                //not anymore 2009-11-09
                //check pref 2010-09-07
                if (OfficerPref.GetPref(OfficerPrefsBE.LoadPersonalFileOnStartup, false))
                {
                    OpenFile(AtMng.OfficerLoggedOn.MyFileId);
                }


                if (OfficerPref.GetPref(OfficerPrefsBE.LoadBFListOnStartup, true))
                {
                    fBFList fBFList = new fBFList(this, AtMng.OfficerLoggedOn);
                    Application.DoEvents();
                    if (!fBFList.Disposing && !fBFList.IsDisposed)
                    {
                        fBFList.Show();
                        fBFList.OfficerToolkitMailClick(false,false, 0);
                        //fBFList.Refresh();
                        fBFList.instance = 0;
                    }
                }
                splash.incrementProgressBar(10);
                WhatsNewOnStartup();

                this.Visible = true;

                splash.Close();
                splash = null;
                AppStartup = false;

                pnlNav.AutoHide = OfficerPref.GetPref(OfficerPrefsBE.AutoHideOfficerToolkitOnStartup, true);

            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        void cb_SelectedItemChanged(object sender, EventArgs e)
        {
            if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                timHitCountDelay.Start();
        }

        void cb_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteSearch(true);
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    Janus.Windows.EditControls.UIComboBox cb = uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox();
                    if (cb.SelectedIndex != cb.Items.Count - 1)
                        cb.SelectedIndex++;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    cb.Focus();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    Janus.Windows.EditControls.UIComboBox cb = uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox();
                    if (cb.SelectedIndex != 0)
                        cb.SelectedIndex--;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    cb.Focus();
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        
        fWebBrowser fwb;
        private void WhatsNewOnStartup()
        {
            //GethlpPage().Load(pagename, lang);
            //check to seee if whats new should be loaded
            HelpDB.hlpPageRow hpr = AtMng.HelpMng().GethlpPage().Load("8087.asp", AtMng.AppMan.Language);
            DateTime lastMod = hpr.updateDate;
            DateTime lastDismissedWhatsNew = AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.DismissWhatsNew, lastMod.AddYears(-1));
            if (lastMod>=lastDismissedWhatsNew)
            {
                fwb = new fWebBrowser(this);
                fwb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(fwb_DocumentCompleted);
                fwb.AppStartupSetToTrue();
                fwb.NavigateToWhatsNew();
            }
        }

        void fwb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (fwb.AutoCloseWhatsNew)
                    fwb.Close();
                else
                {
                    fwb.MdiParent = this;
                    fwb.Show();
                    fwb.Refresh();
                }
            }
            catch (Exception x)
            {
                fwb.Close();
                UIHelper.HandleUIException(x);
            }
        }

        UserControls.ucOfficerToolkit ucOfficerToolkit1;
        private void LoadToolkits()
        {
            //Expand Officer Toolkit TreeView
            //string mainToolkitName = Atmng.OfficerLoggedOn.LastName + ", " + Atmng.OfficerLoggedOn.FirstName + " (" + Atmng.OfficerLoggedOn.OfficerCode + ")";
            //pnlOfficerToolkit.Text = mainToolkitName;


            //remove empty panels stored in layout before adding officer toolkit panels
            List<Janus.Windows.UI.Dock.UIPanel> panelsToRemove = new List<Janus.Windows.UI.Dock.UIPanel>();
            foreach (Janus.Windows.UI.Dock.UIPanel pnl in pnlNav.Panels)
            {
                if (pnl.Name != "pnlOfficerToolkit")
                    panelsToRemove.Add(pnl);
                else
                    pnl.Closed = false;
            }
            foreach (Janus.Windows.UI.Dock.UIPanel pnl in panelsToRemove)
            {
                pnlNav.Panels.Remove(pnl);
            }
            if (pnlNav.Closed)
                cmdNavPane.IsChecked = false;

            ucOfficerToolkit1 = new UserControls.ucOfficerToolkit(AtMng, this);
            pnlOfficerToolkitContainer.Controls.Add(ucOfficerToolkit1);
            ucOfficerToolkit1.Dock = DockStyle.Fill;
            ucOfficerToolkit1.Name = "ucOfficerToolkit1";
            ucOfficerToolkit1.NodeSelected += new UserControls.ToolkitEventHandler(ucOfficerToolkit1_NodeSelected);


            ucOfficerToolkit1.SetAtmng(AtMng, this);
            ucOfficerToolkit1.setOfficer(AtMng.OfficerLoggedOn);
            ucOfficerToolkit1.ucFileContextMenu1.LoadLabels();
            ucOfficerToolkit1.LoadContextMenuLabels();
            ftvMyFile = new FileTreeView(AtMng, ucOfficerToolkit1.tvOfficerToolkit, ucOfficerToolkit1.ucFileContextMenu1);
            ftvMyFile.NodeDoubleClicked += new TreeDoubleClickEventHandler(ftvMyFile_NodeDoubleClicked);
            ftvMyFile.HideShortcutsAndXRefs(false, false, false);
            ftvMyFile.ShowFileNumber = false;
            ucOfficerToolkit1.ucFileContextMenu1.Ftv = ftvMyFile;
            ucOfficerToolkit1.ucFileContextMenu1.ContextMenuClicked += new ContextEventHandler(ucFileContextMenu1_ContextMenuClicked);
            OfficerToolkits.Add(AtMng.OfficerLoggedOn.OfficerId, pnlOfficerToolkit);

            //tvOfficerToolkit.ExpandAll();
            //tvOfficerToolkit.Nodes["NodeMyItems"].Tag = Atmng.OfficerLoggedOn.OfficerId;

            splash.incrementProgressBar(10);

            //Set Selection for "Working As"; Always defaults to self on app startup
            //Set visible to false if logged on user has no delegated access.
            //load working as list
            OfficeManager myOfficeMng = AtMng.GetOffice(AtMng.OfficeLoggedOn.OfficeId);
            myOfficeMng.GetOfficerDelegate().LoadByDelegateToId(AtMng.OfficerLoggedOn.OfficerId);

            cmdWAMyself.Tag = AtMng.OfficerLoggedOn.OfficerId;

            splash.incrementProgressBar(10);

            //load working as menu
            Janus.Windows.UI.CommandBars.UICommand cmdOfficerWorkAs = null;
            bool HasWorkingAsOfficers = false;
            foreach (lmDatasets.officeDB.OfficerDelegateRow odr in myOfficeMng.DB.OfficerDelegate)
            {

                if (odr.WorkAs)
                {
                    myOfficeMng = AtMng.GetOfficeForOfficer(odr.OfficerId);
                    officeDB.OfficerRow odrr = myOfficeMng.GetOfficer().FindLoad(odr.OfficerId);

                    Janus.Windows.UI.Dock.UIPanel pnl = new Janus.Windows.UI.Dock.UIPanel(LawMate.Properties.Resources.OfficerToolkit);
                    pnlNav.Panels.Add(pnl);
                    pnl.Closed = true;
                    OfficerToolkits.Add(odrr.OfficerId, pnl);
                    UserControls.ucOfficerToolkit otk = new UserControls.ucOfficerToolkit(odrr, AtMng, this);
                    otk.NodeSelected += new UserControls.ToolkitEventHandler(ucOfficerToolkit1_NodeSelected);
                    pnl.InnerContainer.Padding = new Padding(0, 5, 0, 0);
                    pnl.InnerContainer.Controls.Add(otk);
                    otk.Dock = DockStyle.Fill;

                    ftvMyFile = new FileTreeView(AtMng, otk.tvOfficerToolkit, otk.ucFileContextMenu1);
                    ftvMyFile.NodeDoubleClicked += new TreeDoubleClickEventHandler(ftvMyFile_NodeDoubleClicked);
                    ftvMyFile.HideShortcutsAndXRefs(false, false, false);
                    ftvMyFile.ShowFileNumber = false;
                    otk.ucFileContextMenu1.Ftv = ftvMyFile;
                    otk.ucFileContextMenu1.ContextMenuClicked += new ContextEventHandler(ucFileContextMenu1_ContextMenuClicked);

                    string del = odrr.LastName + ", " + odrr.FirstName + " (" + odrr.OfficerCode + ")";
                    cmdOfficerWorkAs = new Janus.Windows.UI.CommandBars.UICommand("WorkAs" + odr.OfficerId, del);
                    cmdOfficerWorkAs.Tag = odr.OfficerId;
                    cmdWorkAs.Commands.Add(cmdOfficerWorkAs);
                    contextMenuWorkAs.Commands.Add(cmdOfficerWorkAs);
                    HasWorkingAsOfficers = true;
                }
            }
            if (!HasWorkingAsOfficers)
            {
                cmdWorkAs.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdLblWorkingAs.Visible = Janus.Windows.UI.InheritableBoolean.False;
                btnWorkingAs.Visible = false;
                ebWorkingAs.Visible = false;
            }

            ucOfficerToolkit1.Refresh();
        }

        void ftvMyFile_NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                {
                    appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)e.Node.Tag;
                    OpenFile(efsr.FileId);
                }
                else if (e.Node.Name.StartsWith("nodeDocXRef"))
                {
                    //docxref node clicked - launch in viewer
                    docDB.DocXRefRow docXrefRow = (docDB.DocXRefRow)e.Node.Tag;
                    FileManager fmDoc = AtMng.GetFile(docXrefRow.FileId);
                    DocManager dmDoc = fmDoc.GetDocMng();
                    docDB.DocumentRow dr = dmDoc.GetDocument().Load(docXrefRow.DocId);
                    fDocView fd = new fDocView(dmDoc, dr);
                    fd.Show(this);
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
    {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteSearch(true);
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                {
                    //restart timer for hit count delay
                    timHitCountDelay.Stop();
                    timHitCountDelay.Start();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void tb_GotFocus(object sender, EventArgs e) //Toolbar Search Criteria TextBox
        {
            try
            {
                TextBox tb = (TextBox)sender;
                if (tb.Text == String.Format(LawMate.Properties.Resources.uiSearchLawMateTextBox, AtMng.AppMan.AppName))
                {
                    tb.ForeColor = SystemColors.WindowText;
                    tb.Font = new Font(tb.Font, FontStyle.Regular);
                    tb.Text = "";
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }


        public bool VerifyOpenForm(string id)
        {
            Form f = GetOpenForm(id);
            if (f == null)
                return false;
            else
                return true;
        }

        public Form GetOpenForm(string id)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is fBase)
                {
                    fBase childForm = (fBase)f;
                    if (childForm.Id == id) //form is open, activate it
                    {
                        childForm.Activate();
                        return childForm;
                    }
                }
            }
            return null;

        }

        public Form GetOpenResults(string id)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is fBase)
                {
                    fBase childForm = (fBase)f;
                    if (childForm.Id == id)
                    {
                        return childForm;
                    }
                }
            }
            return null;
        }

        public Form GetOpenDocResults(string name)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is fBase)
                {
                    fBase childForm = (fBase)f;
                    if (childForm.Name == "fSearchResultsDoc" && childForm.Text.StartsWith(name))
                    {
                        return childForm;
                    }
                }
            }
            return null;
        }

        public void ChangeLanguage(string language)
        {
            if (language.ToUpper() == "ENG")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                cmdFrench.Checked = Janus.Windows.UI.InheritableBoolean.False;
                cmdEnglish.Checked = Janus.Windows.UI.InheritableBoolean.True;
                AtMng.AppMan.Language = "ENG";
                UIHelper.SaveSetting("UserLanguage", "ENG");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-CA");
                cmdFrench.Checked = Janus.Windows.UI.InheritableBoolean.True;
                cmdEnglish.Checked = Janus.Windows.UI.InheritableBoolean.False;
                AtMng.AppMan.Language = "FRE";
                UIHelper.SaveSetting("UserLanguage", "FRE");
            }
        }

        public fFile OpenFile(int fileId)
        {
            try
            {
                if (AtMng.SecurityManager.CanRead(fileId, atSecurity.SecurityManager.Features.EfileScreen) == atSecurity.SecurityManager.LevelPermissions.No)
                {
                    throw new LMException(LawMate.Properties.Resources.NoPermissionToViewThisFile);

                }
                if (AtMng.SecurityManager.CanRead(fileId, atSecurity.SecurityManager.Features.Efile) > atSecurity.SecurityManager.LevelPermissions.No)
                {
                    fFile f = (fFile)GetOpenForm("fFile" + fileId.ToString());

                    if (f == null)
                    {
                        Application.UseWaitCursor = true;

                        f = new fFile(this, fileId);
                        f.Show();

                        Application.UseWaitCursor = false;
                    }
                    //f.Activate();
                    return f;
                }
                else
                {
                    throw new LMException(LawMate.Properties.Resources.YouDoNotHavePermissionToOpenThisFile);
                }
            }
            catch (Exception x)
            {
                Application.UseWaitCursor = false;
                throw x;

            }
        }

        private void ucBrowse1_FileSelected(object sender, EventArgs e)
        {
            try
            {
                //OpenFile(ucBrowse1.SelectedFile.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                foreach (Form f in MdiChildren)
                {
                    f.Close();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void ResetProgressBar()
        {
            Application.UseWaitCursor = false; Cursor = Cursors.Default;
            uiStatusBar1.Panels["Message"].Text = "";
            uiStatusBar1.Panels["Message"].Visible = false;
            uiStatusBar1.Panels["Progress"].ProgressBarValue = 0;
        }
        public void IncrementProgressBar(int amt, string text)
        {
            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
            if (text != null)
            {
                uiStatusBar1.Panels["Message"].Text = text;
                uiStatusBar1.Panels["Message"].Visible = true;
            }
            IncrementProgressBar(amt);
        }
        public void IncrementProgressBar(int amt)
        {
            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
            if (uiStatusBar1.Panels["Progress"].ProgressBarValue + amt > uiStatusBar1.Panels["Progress"].ProgressBarMaxValue)
                uiStatusBar1.Panels["Progress"].ProgressBarValue = uiStatusBar1.Panels["Progress"].ProgressBarMaxValue;
            else
                uiStatusBar1.Panels["Progress"].ProgressBarValue += amt;
        }

        private void LaunchMemberAssignmentTool()
        {
            if (!VerifyOpenForm("fMemberManagement"))
            {
                fMemberManagement fMemMng = new fMemberManagement(this, AtMng);
                fMemMng.Show();
            }
        }

        private void LaunchMandates()
        {
            using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
            {
                fMandateList fMandates = new fMandateList(this);
                fProgress.Hide();
                this.Refresh();
                DialogResult dr = fMandates.ShowDialog();
                fProgress.Show();
                if (dr == DialogResult.OK && fMandates.CurrentAcSeriesId() != -1)
                {
                    ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)UIHelper.AtMng.acMng.DB.ACSeries.FindByACSeriesId(fMandates.CurrentAcSeriesId());
                    if (acsr.StepType == (int)StepType.Activity)
                    {
                        FileManager newFM;
                        if (!acsr.SeriesRow.IsContainerFileIdNull())
                        {
                            int fileId = acsr.SeriesRow.ContainerFileId;
                            newFM = UIHelper.AtMng.GetFile(fileId);
                        }
                        else
                        {
                            newFM = UIHelper.AtMng.GetFile((int)SpecialFileIds.Personal);
                        }
                        fACWizard facw = new fACWizard(newFM, (ACEngine.Step)acsr.InitialStep, acsr.ACSeriesId);
                        facw.Show();
                    }
                    //else if (acsr.StepType == (int)StepType.Decision)
                    //{
                    //    FileManager newFM;
                    //    if (!acsr.SeriesRow.IsContainerFileIdNull())
                    //    {
                    //        int fileId = acsr.SeriesRow.ContainerFileId;
                    //        newFM = UIHelper.AtMng.GetFile(fileId);
                    //    }
                    //    else
                    //    {
                    //        newFM = UIHelper.AtMng.GetFile((int)SpecialFileIds.Personal);
                    //    }
                    //    fACWizard facw = new fACWizard(newFM, (ACEngine.Step)3, acsr.ACSeriesId);
                    //    facw.Show();

                    //}

                }
                fProgress.Hide();
            }
        }



        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
            {
                try
                {
                    switch (e.Command.Key)
                    {
                        case "cmdMemberAssignmentTool":
                            LaunchMemberAssignmentTool();
                            break;
                        case "cmdAdmin":
                            Admin.fMain admin = new Admin.fMain();
                            admin.Show();
                            break;
                        case "cmdListenForMessages":
                            SysMessageClosed = !cmdListenForMessages.IsChecked;
                            break;
                        case "cmdMandateControlPopup":
                            LaunchMandates();
                            fProgress.Hide();
                            break;
                        case "cmdRemoveBoolOperators":
                            Janus.Windows.EditControls.UIComboBox cb = uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox();
                            TextBox tb = uiCommandBar3.Commands["cmdSearchText"].GetTextBox();
                            string tbValue = tb.Text.Replace(" and ", " ");
                            tbValue = tbValue.Replace(" or ", " ");
                            tb.Text = tbValue;
                            uiCommandBar2.Visible = false;
                            if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                                timHitCountDelay.Start();
                            break;
                        case "cmdSearchContacts":
                            fContactSelect fcs = new fContactSelect(AtMng.GetFile(AtMng.WorkingAsOfficer.MyFileId), null, false);
                            fcs.Show();
                            break;
                        case "cmdSearchOffices":
                            //ShowAdvancedOfficeSearch();
                            fBrowseOffices fos = new fBrowseOffices(AtMng);
                            fos.Show();
                            break;
                        case "cmdIssues":
                            if (!VerifyOpenForm("fBrowseIssues"))
                            {
                                fBrowseIssues fiss = new fBrowseIssues(AtMng, true, 0);
                                fiss.Show();
                            }
                            break;
                        //case "cmdSearchDocFullText":
                        //case "cmdSearchDocSubject":
                        //case "cmdSearchFileName":
                        //case "cmdSearchFileNumber":
                        //case "cmdSearchFullFileName":
                        //case "cmdSearchFullFileNumber":
                        //case "cmdSearchBoolean":
                        //case "cmdSearchICASE":
                        //    SetSearchOn(e.Command);
                        //    break;
                        case "cmdOutlook":
                            LaunchOutlook();
                            break;
                        case "cmdNewMail":
                            lmWinHelper.NewMail(AtMng.GetFile(AtMng.WorkingAsOfficer.SentItemsId));

                            break;
                        case "cmdNewDoc":
                            lmWinHelper.NewDocument(AtMng.GetFile(AtMng.WorkingAsOfficer.MyFileId), AtMng.GetSetting(AppIntSetting.NewWordDocAcId));
                            break;
                        case "cmdAutoSave":
                            if (!VerifyOpenForm("fAutoSave"))
                            {
                                fAutoSave fAutoSave = new fAutoSave(this);
                                fAutoSave.MdiParent = this;
                                fAutoSave.Show();
                            }
                            break;
                        case "cmdChangePassword":
                            //if (MessageBox.Show("You will be required to logout and log back into the application after changing your password.  Please ensure you save all currents edits in LawMate before proceeding with changing your password.\n\nDo you want to change your password now?", "Change Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            //{
                            fChangePassword f = new fChangePassword();
                            fProgress.Hide();
                            f.ShowDialog();
                            //}
                            break;
                        case "cmdBatchReview":
                            if (!VerifyOpenForm("fBatchReview"))
                            {
                                fBatchReview fBR = new fBatchReview(this);
                                fBR.Show();
                            }
                            break;
                        case "cmdReports":
                            //if (!VerifyOpenForm("fReportList"))
                            //{
                            //    fReportList fr = new fReportList(this);
                            //    fr.Show();
                            //}
                            if (!VerifyOpenForm("fReportAdmin"))
                            {
                                Admin.fReportAdmin fr = new Admin.fReportAdmin(this);
                                fr.Show();
                            }
                            break;
                        case "cmdBrowseOffices":
                            fExplorer fofe = new fExplorer(this, 1171204);
                            fofe.Text = LawMate.Properties.Resources.OfficeExplorer;
                            fofe.Show();
                            break;
                        case "cmdDocBrowser":
                            fExplorer fbd = new fExplorer(this, 0);
                            fbd.Show();
                            break;
                        case "cmdExecuteSearch":
                            ExecuteSearch(true);
                            break;
                        case "cmdAdvancedFileSearch":
                            ShowAdvancedFileSearch();
                            break;
                        case "cmdAdvancedSearchDocs":
                            ShowAdvancedDocumentSearch();
                            break;
                        case "cmdTriangle":
                            fTriangle triangle = new fTriangle(AtMng);
                            triangle.Show();
                            break;
                        case "cmdAbout":
                            AboutBox1 fAbout = new AboutBox1();
                            fProgress.Hide();
                            fAbout.ShowDialog(this);
                            break;

                        case "cmdClose":
                            if (ActiveMdiChild != null)
                                ActiveMdiChild.Close();
                            break;
                        case "cmdExit":
                            this.Close();
                            break;
                        case "cmdEnglish":
                            ChangeLanguage("ENG");
                            break;
                        case "cmdFrench":
                            ChangeLanguage("FRE");
                            break;

                        case "cmdLSBDeskbook":
                            if (false)
                            {
                                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(AtMng.AppMan.ServerInfo.helpUrl+AtMng.AppMan.ServerInfo.DeskbookHomePath);
                                System.Diagnostics.Process.Start(sInfo);

                            }
                            else
                            {
                                fWebBrowser fDeskbook = new fWebBrowser(this);
                                fDeskbook.MdiParent = this;
                                fDeskbook.Text = String.Format(LawMate.Properties.Resources.UILSBDeskbook, AtMng.AppMan.AppName);
                                fDeskbook.NavigateToDeskbookHome();
                                fDeskbook.Show();
                            }
                            break;
                        case "cmdNavPane":
                            if (e.Command.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            {
                                pnlNav.Closed = true;
                                e.Command.Checked = Janus.Windows.UI.InheritableBoolean.False;
                            }
                            else
                            {
                                pnlNav.Closed = false;
                                e.Command.Checked = Janus.Windows.UI.InheritableBoolean.True;
                            }
                            break;
                        case "cmdPreferences":
                            fPreferences fPref = new fPreferences(AtMng);
                            fProgress.Hide();
                            DialogResult fprefr = fPref.ShowDialog();
                            if (fprefr == DialogResult.OK)
                            {
                                PopulateSearchOnOptions(uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox());
                                PopulateSearchOnOptions(cbSearch);
                                ucOfficerToolkit1.SetOfficerToolkitPrefs();
                            }
                            break;
                        case "cmdReloadConfigData":

                            bool wasReloaded = false;
                            if (MessageBox.Show(String.Format(LawMate.Properties.Resources.ReloadConfigDataMessage, AtMng.AppMan.AppName), LawMate.Properties.Resources.ReloadConfigurationDataCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                            {
                                AtMng.acMng.LoadAllConfigInfo();
                                wasReloaded = true;
                            }

                            if (wasReloaded)
                                MessageBox.Show(LawMate.Properties.Resources.TheConfigurationDataHasBeenReloaded, LawMate.Properties.Resources.ConfigurationData, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;


                        case "cmdWhatsNew":
                            WhatsNew();
                            break;
                        case "cmdWAMyself":
                            SetWorkingAs((int)e.Command.Tag, e.Command.Text, true);
                            break;
                        case "cmdGoToTimekeeping":
                            GotoBillingOrTK();
                            break;
                    }
                    if (e.Command.Key.StartsWith("MandateHelp"))
                    {
                        lmDatasets.ActivityConfig.ACSeriesRow acsr = (lmDatasets.ActivityConfig.ACSeriesRow)e.Command.Tag;

                        if (HelpTriangle == null || HelpTriangle.IsDisposed)
                            HelpTriangle = new fTriangle(acsr, AtMng);
                        else
                            HelpTriangle.Navigate(acsr);

                        HelpTriangle.Show();
                        HelpTriangle.Activate();
                    }


                    if (e.Command.Key.StartsWith("NewMandate"))
                    {

                        lmDatasets.ActivityConfig.ACSeriesRow acsr = (lmDatasets.ActivityConfig.ACSeriesRow)e.Command.Tag;
                        if (acsr.StepType == (int)StepType.Activity)
                        {
                            FileManager newFM;
                            if (!acsr.SeriesRow.IsContainerFileIdNull())
                            {
                                int fileId = acsr.SeriesRow.ContainerFileId;
                                newFM = AtMng.GetFile(fileId);
                            }
                            else
                            {
                                newFM = AtMng.GetFile((int)SpecialFileIds.Personal);
                                //throw new LMException(LawMate.Properties.Resources.UIMandateClickPromptForContext);
                            }
                            fACWizard facw = new fACWizard(newFM, (ACEngine.Step)acsr.InitialStep, acsr.ACSeriesId);
                            //facw.ShowDialog(this);
                            facw.Show();
                            //if (facw.OpenFile)
                            //    OpenFile(facw.FileId);

                            //facw.Close();
                            //facw.Dispose();
                        }
                    }
                    if (e.Command.Key.StartsWith("WorkAs"))
                    {
                        SetWorkingAs((int)e.Command.Tag, e.Command.Text, false);
                    }
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
                finally
                {

                    FProgress.resetForm();
                }
            }
        }

        private void GotoBillingOrTK()
        {
            if (!AtMng.WorkingAsOfficer.OfficeRow.UsesBilling)
            {
                fFile workasFile = OpenFile(AtMng.WorkingAsOfficer.MyFileId);
                if (workasFile.IsDirty)
                    MessageBox.Show(LawMate.Properties.Resources.FileIsAlreadyOpenAndInEditMode, LawMate.Properties.Resources.PersonalFileInEditMode, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else
                    workasFile.MoreInfo("timeslip", 0);
            }
            else
            {
                atriumDB.SRPRow sr= AtMng.GetFile().GetSRP().GetCurrentSRP(AtMng.WorkingAsOfficer.OfficeId);
                if(sr!=null)
                {
                    fFile workasFile = OpenFile(sr.FileID);
                    workasFile.MoreInfo("srp",sr.SRPID);
                }

            }
        }

        private void WhatsNew()
        {
            fWebBrowser fwn = new fWebBrowser(this);
            fwn.NavigateToWhatsNew();
            fwn.MdiParent = this;
            fwn.Show();
        }

        private void SetWorkingAs(int officerId, string officerText, bool asMyself)
        {
            if (AtMng.WorkingAsOfficer.OfficerId != officerId)
            {
                FProgress.InitiateForm(LawMate.Properties.Resources.InitiatingWorkAsPleaseWait);
                bool OkToWorkAs = DisplayToolkit(OfficerToolkits[officerId], officerText);
                if (OkToWorkAs)
                {
                    AtMng.WorkAs(officerId);
                    SetVisualStyle(officerId);
                    //OpenFile(Atmng.WorkingAsOfficer.MyFileId);
                    CheckBillingOrTK();

                    if (OfficerPref.GetPref(OfficerPrefsBE.LoadBFListOnStartup, true))
                    {
                        OpenBFList(AtMng.WorkingAsOfficer);
                    }
                    string msg;
                    if (asMyself)
                        msg = LawMate.Properties.Resources.YouAreNowWorkingAsYourself;
                    else
                        msg = LawMate.Properties.Resources.YouAreNowWorkingAs + officerText;
                    MessageBox.Show(msg, LawMate.Properties.Resources.WorkingAs, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(LawMate.Properties.Resources.CannotWorkAsWhileInEditOrReadOnlyMode, LawMate.Properties.Resources.EditMode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string msg;
                if (asMyself)
                    msg = LawMate.Properties.Resources.YouAreAlreadyWorkingAsYourself;
                else
                    msg = LawMate.Properties.Resources.YouAreAlreadyWorkingAs + officerText;
                MessageBox.Show(msg, LawMate.Properties.Resources.WorkingAs, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            FProgress.resetForm();

        }

        private void CheckBillingOrTK()
        {
            if (AtMng.WorkingAsOfficer.UsesBilling)
            {
                cmdGoToTimekeeping.Visible = Janus.Windows.UI.InheritableBoolean.True;
                btnTimekeeping.Visible = true;
            }
            else
            {
                cmdGoToTimekeeping.Visible = Janus.Windows.UI.InheritableBoolean.False;
                btnTimekeeping.Visible = false;
            }
        }

        private bool DisplayToolkit(Janus.Windows.UI.Dock.UIPanel tkPnl, string WorkAsString)
        {
            List<Form> offs = new List<Form>();
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(fFile))
                {
                    offs.Add(f);
                }
                else if (f.GetType() == typeof(fBFList))
                {
                    offs.Add(f);
                }
            }
            foreach (Form f in offs)
            {
                if (f.GetType() == typeof(fFile))
                {
                    fFile ffl = (fFile)f;
                    if (ffl.ReadOnly)
                        return false;
                    else
                    {
                        if (ffl.IsAPersonalFile)
                            ffl.Close();
                    }
                }
                else if (f.GetType() == typeof(fBFList))
                {
                    fBFList fbf = (fBFList)f;
                    if (fbf.BFListIsInEditMode)
                        return false;
                    else
                        f.Close();
                }
                //else if(f.GetType()!=typeof(fMain))
                //    f.Close();   
            }
            foreach (Janus.Windows.UI.Dock.UIPanel pnl in pnlNav.Panels)
            {
                pnl.Closed = true;
            }
            tkPnl.Closed = false;
            cmdLblWorkingAs.Text = WorkAsString;
            ebWorkingAs.Text = WorkAsString;
            return true; //"You are now working as: " + WorkAsString;
        }


        /// <summary>
        /// Loops through the list of FileIDs (files with ActivityTime records that have just been closed) to see if the file was open in the App; and if so, reload, or advise that a reload is required where file is read-only
        /// </summary>
        /// <param name="fileList"></param>
        public void PostSubmitTimekeepingReloadActivityTime(List<int> fileList)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(fFile))
                {
                    fFile ffl = (fFile)f;
                    if (fileList.Contains(ffl.FileId))
                    {
                        if (ffl.ReadOnly || ffl.IsDirty) // uh oh ... timekeeping data was committed while file was in read-only ... put message saying changing might be lost, reload required
                        {
                            MessageBox.Show(String.Format(LawMate.Properties.Resources.FileWasOpenInLawMateTryingToRefreshData, ffl.Text, AtMng.AppMan.AppName), LawMate.Properties.Resources.UnableToReloadData, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else // reload activitytime data
                        {
                            ffl.GetUcCtlToc("activity").ReloadUserControlData();
                        }
                    }
                }
            }
        }

        public void ShowAdvancedOfficeSearch()
        {
            fAdvancedSearch advOfficeSearch = new fAdvancedSearch(this);
            //advOfficeSearch.MdiParent = this;
            advOfficeSearch.CurrentSearchType = fAdvancedSearch.SearchType.Office;
            advOfficeSearch.Show();
            advOfficeSearch.Activate();
        }

        public void ShowAdvancedDocumentSearch()
        {
            fAdvancedSearch advDocSearch = new fAdvancedSearch(this);
            //advDocSearch.MdiParent = this;
            advDocSearch.CurrentSearchType = fAdvancedSearch.SearchType.Document;
            advDocSearch.Show();
            advDocSearch.Activate();
        }

        public void ShowAdvancedFileSearch()
        {
            fAdvancedSearch advFileSearch = new fAdvancedSearch(this);
            //advFileSearch.MdiParent = this;
            advFileSearch.CurrentSearchType = fAdvancedSearch.SearchType.File;
            advFileSearch.Show();
            advFileSearch.Activate();
        }

        private void SetVisualStyle(int officerId)
        {
            if (officerId == AtMng.OfficerLoggedOn.OfficerId)
                fMainStyleScheme = visualStyleManager1.ColorSchemes[0].Name;
            else
                fMainStyleScheme = visualStyleManager1.ColorSchemes[1].Name;


            uiPanelManager1.ColorScheme = fMainStyleScheme;
            uiCommandManager1.ColorScheme = fMainStyleScheme;
            uiStatusBar1.ColorScheme = fMainStyleScheme;
        }

        private void uiCommandBar3_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdNew":
                    case "cmdMandates":
                    case "cmdWorkAs":
                    case "cmdAdvancedSearch":
                    case "cmdSelectedSearchOption":
                    case "cmdActions":
                        if (e.Command.Commands.Count > 0)
                            e.Command.Expand();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        /// <summary>
        /// Sets Visibility of Status Bar w/ BF List Message to True and sets text;
        /// </summary>
        public void SetBFListStatus(string message)
        {
            uiStatusBar1.Panels["BFListMessage"].Visible = true;
            uiStatusBar1.Panels["BFListMessage"].Text = message;
        }

        /// <summary>
        /// Sets Visibility of Status Bar w/ BF List Message to False and clears text;
        /// </summary>
        public void ClearBFListStatus()
        {
            uiStatusBar1.Panels["BFListMessage"].Visible = false;
            uiStatusBar1.Panels["BFListMessage"].Text = "";
        }

        private void ucOfficerToolkit1_NodeSelected(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                UserControls.ucOfficerToolkit utk = (UserControls.ucOfficerToolkit)sender;
                string utkname = "(" + utk.ToolkitOfficer.LastName + ", " + utk.ToolkitOfficer.FirstName + ")";
                fSearchResults fSR = null;
                atLogic.WhereClause wcy = new atLogic.WhereClause();
                if (e.Node.Name.StartsWith("ndChron"))
                    wcy.Add("d.docid", "in", "select docid from recipient where officerid = " + utk.ToolkitOfficer.OfficerId.ToString() + " and type=0");
                else
                    wcy.Add("d.docid", "in", "select docid from recipient where officerid = " + utk.ToolkitOfficer.OfficerId.ToString() + " and type in (1,2)");
                //wcy.Add("d.docid", "in", "select docid from vrecipient where officerid = " + utk.ToolkitOfficer.OfficerId.ToString() + " and type=0");


                if (!VerifyOpenForm("fSearchResults" + e.Node.Name))
                {
                    switch (e.Node.Name)
                    {
                        case "ndChronToday":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsSentToday);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.Today.BeginDate, atDates.StandardDate.Today.EndDate);
                            OpenLetterbook(utkname, wcy);
                            break;
                        case "ndChronYesterday":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsSentYesterday);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.Yesterday.BeginDate, atDates.StandardDate.Yesterday.EndDate);
                            OpenLetterbook(utkname, wcy);
                            break;
                        case "ndChronThisWeek":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsSentThisWeek);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                            OpenLetterbook(utkname, wcy);
                            break;
                        case "ndChronLastWeek":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsSentLastWeek);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                            OpenLetterbook(utkname, wcy);
                            break;
                        case "ndChronCustom":
                            fCustomDateRange fDateRange = new fCustomDateRange();
                            if (fDateRange.ShowDialog() == DialogResult.OK)
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsSentWithinSpecifiedRange);
                                wcy.Add("d.efDate", "Between", (DateTime)fDateRange.BeginDate, (DateTime)fDateRange.EndDate);
                                OpenLetterbook(utkname, wcy);
                            }
                            break;

                        case "ndRecToday":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsReceivedToday);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.Today.BeginDate, atDates.StandardDate.Today.EndDate);
                            OpenReceivedItems(utkname, wcy);
                            break;
                        case "ndRecYesterday":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsReceivedYesterday);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.Yesterday.BeginDate, atDates.StandardDate.Yesterday.EndDate);
                            OpenReceivedItems(utkname, wcy);
                            break;
                        case "ndRecThisWeek":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsReceivedThisWeek);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                            OpenReceivedItems(utkname, wcy);
                            break;
                        case "ndRecLastWeek":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsReceivedLastWeek);
                            wcy.Add("d.efDate", "Between", atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                            OpenReceivedItems(utkname, wcy);
                            break;
                        case "ndRecCustom":
                            fCustomDateRange fDateRange1 = new fCustomDateRange();
                            if (fDateRange1.ShowDialog() == DialogResult.OK)
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDocumentsReceivedWithinSpecifiedRange);
                                wcy.Add("d.efDate", "Between", (DateTime)fDateRange1.BeginDate, (DateTime)fDateRange1.EndDate);
                                OpenReceivedItems(utkname, wcy);
                            }
                            break;
                        case "NodeCheckOut":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingCheckedOutDocuments);
                            atLogic.WhereClause wc = new atLogic.WhereClause();
                            wc.Add("d.CheckedoutBy", "=", utk.ToolkitOfficer.OfficerId);
                            fSearchResultsDoc fsd = new fSearchResultsDoc(this, wc, null, "", false, LawMate.Properties.Resources.CheckedOutDocuments + utkname, false);
                            fsd.Show();

                            break;
                        case "NodeMyDrafts":
                            FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingDraftDocuments);
                            atLogic.WhereClause wcDrafts = new atLogic.WhereClause();
                            wcDrafts.Add("d.OfficerId", "=", utk.ToolkitOfficer.OfficerId);
                            wcDrafts.Add("d.IsDraft", "=", true);
                            fSearchResultsDoc fDrafts = new fSearchResultsDoc(this, wcDrafts, null, "", false, LawMate.Properties.Resources.DraftDocuments + utkname, false);
                            fDrafts.Show();
                            break;
                        case "nodeMyDocShortcuts":
                            //if (e.Node.Nodes.Count == 0)
                            //    lmWinHelper.LoadDocShortcuts(e.Node, Atmng);
                            break;
                        case "ndMyOfficesOpinions":
                            fCustomDateRange fOpnDateRange = new fCustomDateRange();
                            if (fOpnDateRange.ShowDialog() == DialogResult.OK)
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingOfficeOpinionsWithinSpecifiedRange);
                                atLogic.WhereClause wcOfficeOpns = new atLogic.WhereClause();
                                wcOfficeOpns.Add("d.Opinion", "=", true);
                                wcOfficeOpns.Add("d.efDate", "Between", (DateTime)fOpnDateRange.BeginDate, (DateTime)fOpnDateRange.EndDate);
                                fSearchResultsDoc fOfficeOpns = new fSearchResultsDoc(this, wcOfficeOpns, null, "", false, LawMate.Properties.Resources.MyOfficeSOpinions + utkname, true);
                                fOfficeOpns.Show();
                            }
                            break;
                        case "NodeCompletedItems":
                            fCustomDateRange fCompletedRange = new fCustomDateRange();
                            if (fCompletedRange.ShowDialog() == DialogResult.OK)
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingListOfCompletedBFsWithinSpecifiedRange);
                                if (!VerifyOpenForm("fBFListCompletedItems" + utk.ToolkitOfficer.OfficerId.ToString()))
                                {
                                    fBFList fBFList = new fBFList(this, utk.ToolkitOfficer, (DateTime)fCompletedRange.BeginDate, (DateTime)fCompletedRange.EndDate);
                                    if (!fBFList.Disposing && !fBFList.IsDisposed)
                                    {
                                        fBFList.Show();
                                        //fBFList.LoadCompletedItems(Atmng.WorkingAsOfficer.OfficerId, (DateTime)fCompletedRange.BeginDate, (DateTime)fCompletedRange.EndDate);
                                    }
                                }
                                else
                                {
                                    fBFList fBFList = (fBFList)GetOpenForm("fBFListCompletedItems" + utk.ToolkitOfficer.OfficerId.ToString());
                                    fBFList.LoadCompletedItems(AtMng.WorkingAsOfficer.OfficerId, (DateTime)fCompletedRange.BeginDate, (DateTime)fCompletedRange.EndDate);
                                }
                            }
                            break;
                        case "NodeMyShortcuts":
                            //load tree below
                            //ftvShortcuts.LoadRoot( 0, utk.SelectedNode);

                            //OpenFile(utk.ToolkitOfficer.ShortcutsId);
                            break;
                        case "NodePersonalFile":
                            //ftvMyFile.LoadRoot( utk.ToolkitOfficer.MyFileId, utk.SelectedNode);
                            break;
                        case "nodeAddressBook":
                            if (!VerifyOpenForm("fAddressBook"))
                            {
                                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                                {
                                    fAddressBook fad = new fAddressBook(this, AtMng.GetFile(utk.ToolkitOfficer.MyFileId));
                                    fad.Show();
                                }
                            }
                            break;
                        case "ndCalendar":
                            if (!VerifyOpenForm("fCalendar"))
                            {
                                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                                {
                                    fCalendar fcal = new fCalendar(this, utk.ToolkitOfficer.OfficerId);
                                    fcal.Show();
                                }
                            }
                            break;
                        case "NodeMyReports":
                            //if (!VerifyOpenForm("fReportList"))
                            //{
                            //    fReportList fr = new fReportList(this);
                            //    fr.Show();
                            //}
                            if (!VerifyOpenForm("fReportAdmin"))
                            {
                                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                                {
                                    Admin.fReportAdmin fr = new Admin.fReportAdmin(this);
                                    fr.Show();
                                }
                            }
                            break;
                        case "NodeChangePassword":
                            fChangePassword f = new fChangePassword();
                            f.ShowDialog();
                            break;
                        //case "NodeMyFiles":
                        //    pnlNav.SelectedPanel = pnlMyFiles;
                        //    break;
                        
                        case "NodeAllBFs":
                            if (!VerifyOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString()))
                            {
                                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                                {
                                    fBFList fBFList = new fBFList(this, utk.ToolkitOfficer);
                                    if (!fBFList.Disposing && !fBFList.IsDisposed)
                                    {
                                        fBFList.Show();
                                        fBFList.OfficerToolkitMailClick(true, false, 0);
                                    }
                                }
                            }
                            else
                            {
                                fBFList fBFList = (fBFList)GetOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString());
                                fBFList.OfficerToolkitMailClick(true, false, 0);
                            }
                            break;

                        case "NodeAllMail":
                            if (!VerifyOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString()))
                            {
                                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                                {
                                    fBFList fBFList = new fBFList(this, utk.ToolkitOfficer);
                                    if (!fBFList.Disposing && !fBFList.IsDisposed)
                                    {
                                        fBFList.Show();
                                        fBFList.OfficerToolkitMailClick(false,true, 0);
                                    }
                                }
                            }
                            else
                            {
                                fBFList fBFList = (fBFList)GetOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString());
                                fBFList.OfficerToolkitMailClick(false, true, 0);
                            }
                            break;
                        case "NodeUnreadMail":
                            if (!VerifyOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString()))
                            {
                                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                                {
                                    fBFList fBFList = new fBFList(this, utk.ToolkitOfficer);
                                    if (!fBFList.Disposing && !fBFList.IsDisposed)
                                    {
                                        fBFList.Show();
                                        fBFList.OfficerToolkitMailClick(false,true, 1);
                                    }
                                }
                            }
                            else
                            {
                                fBFList fBFList = (fBFList)GetOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString());
                                fBFList.OfficerToolkitMailClick(false,true, 1);
                            }
                            break;
                        case "NodeUnlinkedMail":
                            if (!VerifyOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString()))
                            {
                                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                                {
                                    fBFList fBFList = new fBFList(this, utk.ToolkitOfficer);
                                    if (!fBFList.Disposing && !fBFList.IsDisposed)
                                    {
                                        fBFList.Show();
                                        fBFList.OfficerToolkitMailClick(false, true, 2);
                                    }
                                }
                            }
                            else
                            {
                                fBFList fBFList = (fBFList)GetOpenForm("fBFList" + utk.ToolkitOfficer.OfficerId.ToString());
                                fBFList.OfficerToolkitMailClick(false, true, 2);
                            }
                            break;
                        case "NodeBFList":
                            OpenBFList(utk.ToolkitOfficer);

                            break;
                        case "ndToday":
                            fSearchResults fToday = (fSearchResults)GetOpenResults("fSearchResultsDateTime");
                            if (fToday != null)
                            {
                                fToday.DateTimeSearch(this, utk.ToolkitOfficer.UserName, DateTime.Today, atDates.StandardDate.Tomorrow.BeginDate);
                                fToday.Activate();
                            }
                            else
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingFilesViewedToday);
                                fSR = new fSearchResults(this, utk.ToolkitOfficer.UserName, DateTime.Today, atDates.StandardDate.Tomorrow.BeginDate);
                                fSR.Show();
                            }
                            break;
                        case "ndYesterday":
                            fSearchResults fYesterday = (fSearchResults)GetOpenResults("fSearchResultsDateTime");
                            if (fYesterday != null)
                            {
                                fYesterday.DateTimeSearch(this, utk.ToolkitOfficer.UserName, atDates.StandardDate.Yesterday.BeginDate, DateTime.Today);
                                fYesterday.Activate();
                            }
                            else
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingFilesViewedYesterday);
                                fSR = new fSearchResults(this, utk.ToolkitOfficer.UserName, atDates.StandardDate.Yesterday.BeginDate, DateTime.Today);
                                fSR.Show();
                            }
                            break;
                        case "ndLastWeek":
                            fSearchResults fLastWeek = (fSearchResults)GetOpenResults("fSearchResultsDateTime");
                            if (fLastWeek != null)
                            {
                                fLastWeek.DateTimeSearch(this, utk.ToolkitOfficer.UserName, atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                                fLastWeek.Activate();
                            }
                            else
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingFilesViewedLastWeek);
                                fSR = new fSearchResults(this, utk.ToolkitOfficer.UserName, atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                                fSR.Show();
                            }
                            break;
                        case "ndThisWeek":
                            fSearchResults fThisWeek = (fSearchResults)GetOpenResults("fSearchResultsDateTime");
                            if (fThisWeek != null)
                            {
                                fThisWeek.DateTimeSearch(this, utk.ToolkitOfficer.UserName, atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                                fThisWeek.Activate();
                            }
                            else
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingFilesViewedThisWeek);
                                fSR = new fSearchResults(this, utk.ToolkitOfficer.UserName, atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                                fSR.Show();
                            }
                            break;
                        case "ndCustom":
                            fCustomDateRange fDateRangeFiles = new fCustomDateRange();
                            if (fDateRangeFiles.ShowDialog() == DialogResult.OK)
                            {
                                fSearchResults fRecentFilesCustom = (fSearchResults)GetOpenResults("fSearchResultsDateTime");
                                //(DateTime)fDateRange.BeginDate, (DateTime)fDateRange.EndDate);
                                if (fRecentFilesCustom != null)
                                {
                                    fRecentFilesCustom.DateTimeSearch(this, utk.ToolkitOfficer.UserName, (DateTime)fDateRangeFiles.BeginDate, (DateTime)fDateRangeFiles.EndDate);
                                    fRecentFilesCustom.Activate();
                                }
                                else
                                {
                                    FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingFilesViewedWithinSpecifiedRange);
                                    fSR = new fSearchResults(this, utk.ToolkitOfficer.UserName, (DateTime)fDateRangeFiles.BeginDate, (DateTime)fDateRangeFiles.EndDate);
                                    fSR.Show();

                                }
                            }
                            break;
                        case "ndAss":
                            fSearchResults fAssignedFiles = (fSearchResults)GetOpenResults("fSearchResultsContactType");
                            if (fAssignedFiles != null)
                            {
                                fAssignedFiles.contactTypeSearch(this, utk.ToolkitOfficer.ContactId, utk.ToolkitOfficer.PositionCode);
                                fAssignedFiles.Activate();
                            }
                            else
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingAssignedFiles);
                                fSR = new fSearchResults(this, utk.ToolkitOfficer.ContactId, utk.ToolkitOfficer.PositionCode);
                                fSR.Show();
                            }
                            break;
                        case "ndContact":
                            fSearchResults fAmContact = (fSearchResults)GetOpenResults("fSearchResultsContactType");
                            if (fAmContact != null)
                            {
                                fAmContact.contactTypeSearch(this, utk.ToolkitOfficer.ContactId, null);
                                fAmContact.Activate();
                            }
                            else
                            {
                                FProgress.InitiateForm(LawMate.Properties.Resources.RetrievingFilesOnWhichYouAreAContact);
                                fSR = new fSearchResults(this, utk.ToolkitOfficer.ContactId, null);
                                fSR.Show();
                            }
                            break;
                        case "NodeBatchReview":
                            if (!VerifyOpenForm("fBatchReview"))
                            {
                                fBatchReview fBR = new fBatchReview(this);
                                fBR.Show();
                            }
                            break;
                    }
                    //if (e.Node.Name.StartsWith("nodeDocXRef"))
                    //{
                    //    //docxref node clicked - launch in viewer
                    //    docDB.DocXRefRow docXrefRow = (docDB.DocXRefRow)e.Node.Tag;
                    //    FileManager fmDoc = Atmng.GetFile(docXrefRow.FileId,false);
                    //    DocManager dmDoc = fmDoc.GetDocMng();
                    //    docDB.DocumentRow dr= dmDoc.GetDocument().Load(docXrefRow.DocId);
                    //    fDoc fd = new fDoc(dmDoc, dr);
                    //    fd.Show();
                    //}
                    //if (e.Node.Name.StartsWith("nodeContainerDocXref"))
                    //{
                    //    //shortcuts subfolder docxref container node clicked - expand if necessary
                    //    if(e.Node.Nodes.Count==0)
                    //        lmWinHelper.LoadDocShortcuts(e.Node, Atmng);
                    //}

                    if (fSR != null && fSR.Id != "fSearchResultsContactType" && fSR.Id != "fSearchResultsDateTime")
                        fSR.Id = fSR.Name + e.Node.Name;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally
            {
                FProgress.resetForm();
            }
        }

        private void OpenReceivedItems(string utkname, atLogic.WhereClause wcy)
        {
            fSearchResultsDoc fReceivedItems = (fSearchResultsDoc)GetOpenDocResults(LawMate.Properties.Resources.ReceivedItems + utkname);
            if (fReceivedItems != null)
            {
                fReceivedItems.SearchDoc(this, wcy, null, "", false, LawMate.Properties.Resources.ReceivedItems + utkname, false);
                fReceivedItems.Activate();
            }
            else
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    fSearchResultsDoc fsd1t = new fSearchResultsDoc(this, wcy, null, "", false, LawMate.Properties.Resources.ReceivedItems + utkname, false);
                    fsd1t.Show();
                }
            }
        }

        private void OpenLetterbook(string utkname, atLogic.WhereClause wcy)
        {
            fSearchResultsDoc fChronToday = (fSearchResultsDoc)GetOpenDocResults(LawMate.Properties.Resources.Letterbook + utkname);
            if (fChronToday != null)
            {
                fChronToday.SearchDoc(this, wcy, null, "", false, LawMate.Properties.Resources.Letterbook + utkname, false);
                fChronToday.Activate();
            }
            else
            {
                fSearchResultsDoc fsd1t = new fSearchResultsDoc(this, wcy, null, "", false, LawMate.Properties.Resources.Letterbook + utkname, false);
                fsd1t.Show();
            }
        }

        public void OpenBFList(officeDB.OfficerRow officer)
        {
            if (!VerifyOpenForm("fBFList" + officer.OfficerId.ToString()))
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    fBFList fBFList = new fBFList(this, officer);
                    if (!fBFList.Disposing && !fBFList.IsDisposed)
                    {
                        fBFList.Show();
                        fBFList.OfficerToolkitMailClick(false,false, 0);
                        fBFList.instance = 1;
                    }
                }
            }
            else
            {
                fBFList fBFList = (fBFList)GetOpenForm("fBFList" + officer.OfficerId.ToString());
                fBFList.OfficerToolkitMailClick(false,false, 0);
                fBFList.instance = 2;
            }
        }

        private void ucFileContextMenu1_ContextMenuClicked(object sender, FileContextEventArgs e)
        {
            try
            {
                lmWinHelper.HelpContextMenuClicked(this, sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool warn = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is fFile)
                    {
                        fFile ff = (fFile)f;
                        if (ff.IsDirty | ff.ReadOnly)
                        {
                            warn = true;
                        }
                    }

                }
                if (warn)
                {
                    fConfirmCloseApp fCC = new fConfirmCloseApp();
                    fCC.Warn = true;
                    fCC.ShowDialog(this);
                    if (fCC.dResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else if (e.CloseReason == CloseReason.UserClosing && AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.PromptOnClose, true))
                {
                    fConfirmCloseApp fCC = new fConfirmCloseApp();
                    fCC.ShowDialog(this);
                    if (fCC.dResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    //&& MessageBox.Show("Are you sure you want to exit LawMate?", "LawMate", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                }

                if (!e.Cancel)
                {
                    AtMng.OfficeMng.GetOfficerPrefs().SavePrefsCommit();
                    //lmWinHelper.SavePanelManagerLayout(uiPanelManager1, "fMainPanelManager" + LayoutVersionNumber, AtMng);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fMain_Shown(object sender, EventArgs e)
        {

            if (!AtMng.GetSetting(AppBoolSetting.isPROD))
            {
                MessageBox.Show(this, Properties.Resources.AtriumNotInPROD, "ATRIUM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UIHelper.SetNonProdUI(this, visualStyleManager1);
            }

            ucOfficerToolkit1.Refresh();
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

        public void LaunchNextSteps(int fileId, int activityId)
        {
            bool isSingle = false;

            FileManager fm = AtMng.GetFile(fileId);
            if (fm.InitActivityProcess().CurrentACE != null)
            {
                isSingle = true;
                throw new LMException("You cannot enter more than one activity at a time on a file.");
            }
            if (AtMng.SecurityManager.CanRead(fileId, atSecurity.SecurityManager.Features.EfileScreen) == atSecurity.SecurityManager.LevelPermissions.No)
            {
                fACWizard fNS = new fACWizard(fm, activityId);
                fNS.Show();

            }
            else
            {
                fFile ffns = OpenFile(fileId);
                try
                {
                    if ((ffns != null && ffns.ReadOnly))
                    {
                        isSingle = true;
                        throw new LMException("You cannot enter more than one activity at a time on a file.");
                    }
                    ffns.ReadOnly = true;
                    fACWizard fNS = new fACWizard(fm, activityId);
                    ffns.HookupWizClose(fNS);
                    fNS.Show();
                }
                catch (Exception x1)
                {
                    if (!isSingle)
                    {
                        if (ffns != null)
                            ffns.ReadOnly = false;
                        fm.KillACEngine();
                    }

                    throw x1;
                }
            }
        }

        private void timHitCountDelay_Tick(object sender, EventArgs e)
        {
            //get hit count
            timHitCountDelay.Stop();
            if (!bkwHitCount.IsBusy)
                bkwHitCount.RunWorkerAsync();
            else if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                timHitCountDelay.Start();


        }


        const string BoolOperatorOnNonBoolSearch = "BoolOperatorOnNonBoolSearch";
        private void bkwHitCount_DoWork(object sender, DoWorkEventArgs e)
        {
            int iHits = 0;
            bool opinion = false;
            bool docHits = false;
            bool boolSearch = false;
            bool fullTextSearch = false;
            bool subjectSearch = false;

            //Janus.Windows.EditControls.UIComboBox cb = uiCommandBar3.Commands["cmdSearchDD"].GetUIComboBox();
            //TextBox tb = uiCommandBar3.Commands["cmdSearchText"].GetTextBox();
            Janus.Windows.EditControls.UIComboBox cb = cbSearch;
            Janus.Windows.GridEX.EditControls.EditBox tb = ebSearch;
            if (tb.Text.Length == 0)
            {
                e.Result = null;
            }
            else
            {
                if (cb.SelectedItem != null)
                {
                    switch (cb.SelectedItem.Value.ToString())
                    {
                        case OfficerPrefsBE.qsDocSubj:
                            docHits = true;
                            subjectSearch = true;
                            break;
                        case OfficerPrefsBE.qsOpnSubj:
                            docHits = true;
                            subjectSearch = true;
                            opinion = true;
                            break;
                        case OfficerPrefsBE.qsDocBool:
                            boolSearch = true;
                            fullTextSearch = true;
                            docHits = true;
                            break;
                        case OfficerPrefsBE.qsDocFullText:
                            docHits = true;
                            fullTextSearch = true;
                            break;
                        case OfficerPrefsBE.qsOpnBool:
                            boolSearch = true;
                            fullTextSearch = true;
                            docHits = true;
                            opinion = true;
                            break;
                        case OfficerPrefsBE.qsOpnFullText:
                            docHits = true;
                            fullTextSearch = true;
                            opinion = true;
                            break;
                        default:
                            break;
                    }
                }
                try
                {
                    if (docHits && tb.Text != String.Format(LawMate.Properties.Resources.uiSearchLawMateTextBox, AtMng.AppMan.AppName))
                    {
                        //check to see if passing boolean operators to non-boolean query
                        if (!boolSearch && BooleanOperatorsOnNonBooleanSearch(tb.Text))
                            e.Result = BoolOperatorOnNonBoolSearch;
                        else
                        {
                            //
                            if (fullTextSearch)
                            {
                                string searchTerms;
                                if (!boolSearch)
                                {
                                    //not to AND the search terms
                                    searchTerms = UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, tb.Text);
                                }
                                else
                                {
                                    searchTerms = tb.Text;
                                }
                                iHits = AtMng.GetFile().GetDocMng().GetDocument().HitCount(searchTerms, opinion, false);
                                e.Result = iHits;
                            }
                            else if (subjectSearch)
                            {
                                string searchTerms = UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, tb.Text);
                                iHits = AtMng.GetFile().GetDocMng().GetDocument().HitCount(searchTerms, opinion, true);
                                e.Result = iHits;
                            }
                        }
                    }
                    else
                    {
                        e.Result = null;
                    }
                }
                catch (Exception x)
                {
                    //ignore
                    e.Result = -1;
                }
            }
        }

        private bool BooleanOperatorsOnNonBooleanSearch(string criteria)
        {
            if (criteria.Contains(" and ") || criteria.Contains(" or "))
                return true;
            else
                return false;
        }

        private void ShowPreSearchHit(int hitCount)
        {
            //hide warning commands
            //cmdBoolWarning.Visible = Janus.Windows.UI.InheritableBoolean.False;
            //cmdBoolWarningText.Visible = Janus.Windows.UI.InheritableBoolean.False;
            //Separator12.Visible = Janus.Windows.UI.InheritableBoolean.False;
            //cmdRemoveBoolOperators.Visible = Janus.Windows.UI.InheritableBoolean.False;
            //new "command bar"
            lblWarning.Visible = false;
            lblWarnMessage.Visible = false;
            btnRemoveBoolOps.Visible = false;


            //show hit count commands
            //cmdHitCountValue.Visible = Janus.Windows.UI.InheritableBoolean.True;
            //cmdLabelHitCount.Visible = Janus.Windows.UI.InheritableBoolean.True;
            //cmdHitCountValue.Text = String.Format(LawMate.Properties.Resources.AboutX, hitCount.ToString());
            uiStatusBar1.Panels["Message"].Visible = true;
            uiStatusBar1.Panels["Message"].Text = String.Format(LawMate.Properties.Resources.About0Hits, hitCount.ToString());
            //uiCommandBar2.Visible = true;
            //new "command bar"
            lblHitCount.Visible = true;
            lblNumOfHits.Visible = true;
            lblHitCount.Text = String.Format(LawMate.Properties.Resources.AboutX, hitCount.ToString());
            pnlToolbar2.Closed = false;
            //pnlToolbar.Height = 58;




        }

        private void ShowBoolOperatorWarning()
        {
            //hide hit count commands
            //cmdHitCountValue.Visible = Janus.Windows.UI.InheritableBoolean.False;
            //cmdLabelHitCount.Visible = Janus.Windows.UI.InheritableBoolean.False;
            //cmdHitCountValue.Text = "";
            uiStatusBar1.Panels["Message"].Text = "";
            //new "command" bar
            lblHitCount.Visible = false;
            lblNumOfHits.Visible = false;
            lblHitCount.Text = "";


            //show warning commands
            //cmdBoolWarning.Visible = Janus.Windows.UI.InheritableBoolean.True;
            //cmdBoolWarningText.Visible = Janus.Windows.UI.InheritableBoolean.True;
            //Separator12.Visible = Janus.Windows.UI.InheritableBoolean.True;
            //cmdRemoveBoolOperators.Visible = Janus.Windows.UI.InheritableBoolean.True;
            //uiCommandBar2.Visible = true;

            lblWarning.Visible = true;
            lblWarnMessage.Visible = true;
            btnRemoveBoolOps.Visible = true;
            //pnlToolbar.Height = 58;
            pnlToolbar2.Closed = false;


        }

        private void ClearHitCountWarningCommandBar()
        {
            lblHitCount.Text = "";
            //pnlToolbar.Height = 30;
            pnlToolbar2.Closed = true;
            //cmdHitCountValue.Text = "";
            //uiCommandBar2.Visible = false;
            //uiStatusBar1.Panels["Message"].Text = "";
        }


        private void bkwHitCount_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                ClearHitCountWarningCommandBar();
            }
            else if (e.Result.GetType() == typeof(int)) //Match Count Passed
            {
                int iHits = (int)e.Result;

                if (iHits >= 0) //query returned a count
                {
                    ShowPreSearchHit(iHits);
                }
                else if (iHits == -1) // query hit an exception
                {
                    ClearHitCountWarningCommandBar();
                }
            }
            else if (e.Result.GetType() == typeof(string)) // Bool operator passed to non boolean search
            {
                ShowBoolOperatorWarning();
            }
        }

        bool SysMessageClosed = false;
        private void ebAtriumMessage_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                pnlSysMessage.Closed = true;
                SysMessageClosed = true;
                cmdListenForMessages.Checked = Janus.Windows.UI.InheritableBoolean.False;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;    
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                if(!btn.Focused)
                    btn.VisualStyle = Janus.Windows.UI.VisualStyle.Standard;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ebSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                if (ebSearch.Text == String.Format(LawMate.Properties.Resources.uiSearchLawMateTextBox, AtMng.AppMan.AppName))
                {
                    ebSearch.ForeColor = SystemColors.WindowText;
                    ebSearch.Font = new Font(ebSearch.Font, FontStyle.Regular);
                    ebSearch.Text = "";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void ebSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteSearch(false);
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        int quicksearchControlwidth = 0;
        private void cbSearch_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                if (quicksearchControlwidth == 0)
                    quicksearchControlwidth = ebSearch.Width;

                if (cbSearch.SelectedValue != null)
                {
                    switch (cbSearch.SelectedValue.ToString())
                    {

                        case OfficerPrefsBE.qsFileNameEng:
                        case OfficerPrefsBE.qsFileNameFre:
                        case OfficerPrefsBE.qsFileNumber:
                        case OfficerPrefsBE.qsFullFileNumber:
                        case OfficerPrefsBE.qsLastName:
                            chkQSExactMatch.Visible = true;
                            chkQSExactMatch.Checked = false;
                            ebSearch.Width = quicksearchControlwidth;
                            break;
                        default:
                            chkQSExactMatch.Visible = false;
                            chkQSExactMatch.Checked = false;
                            ebSearch.Width = quicksearchControlwidth + 16;
                            break;


                    }
                }

                if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                    timHitCountDelay.Start();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ebSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                {
                    //restart timer for hit count delay
                    timHitCountDelay.Stop();
                    timHitCountDelay.Start();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ebSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ebSearch.Text == "")
                {
                    ebSearch.Text= String.Format(LawMate.Properties.Resources.uiSearchLawMateTextBox, AtMng.AppMan.AppName);
                    ebSearch.ForeColor = SystemColors.ControlDark;
                    ebSearch.Font = new Font(ebSearch.Font, FontStyle.Italic);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ExecuteSearch(false);
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
               ExecuteSearch(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            try
            {
                uiContextMenu1.Show(btnAdvancedSearch, new Point(0,21));
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void contextMenuWorkAs_Popup(object sender, EventArgs e)
        {
            try
            {
                contextMenuWorkAs.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
                contextMenuWorkAs.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            }
            catch (Exception x)
            {}   
        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            try
            {
                uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
                uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            }
            catch (Exception x)
            {}
        }

        private void LaunchOutlook()
        {
            if (!VerifyOpenForm("fOutlook"))
            {
                fOutlook fout = new fOutlook(this);
                fout.Show();
            }
        }

        private void btnMailBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    LaunchOutlook();
                }
            }
            catch (Exception x)
            { UIHelper.HandleUIException(x); }
        }

        private void btnAtriumExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    fExplorer fbd = new fExplorer(this, 0);
                    fbd.Show();
                }
            }
            catch (Exception x)
            { UIHelper.HandleUIException(x); }
        }

        private void btnMandates_Click(object sender, EventArgs e)
        {
            try
            {
                LaunchMandates();
            }
            catch (Exception x)
            { UIHelper.HandleUIException(x); }
        }

        private void btnAutoSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    if (!VerifyOpenForm("fAutoSave"))
                    {
                        fAutoSave fAutoSave = new fAutoSave(this);
                        fAutoSave.MdiParent = this;
                        fAutoSave.Show();
                    }
                }
            }
            catch (Exception x)
            { UIHelper.HandleUIException(x); }
        }

        private void btnTimekeeping_Click(object sender, EventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    GotoBillingOrTK();
                }
            }
            catch (Exception x)
            { UIHelper.HandleUIException(x); }
        }

        private void btnMemberAssignmentTool_Click(object sender, EventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    LaunchMemberAssignmentTool();
                }
            }
            catch (Exception x)
            { UIHelper.HandleUIException(x); }
        }

        private void btnRemoveBoolOps_Click(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIComboBox cb = cbSearch;
                Janus.Windows.GridEX.EditControls.EditBox tb = ebSearch;
                string tbValue = tb.Text.Replace(" and ", " ");
                tbValue = tbValue.Replace(" or ", " ");
                tb.Text = tbValue;
                //pnlToolbar.Height = 30;
                pnlToolbar2.Closed = true;
                if (OfficerPref.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                    timHitCountDelay.Start();
            }
            catch (Exception x)
            { UIHelper.HandleUIException(x); }
        }

        private void btnWorkingAs_Click(object sender, EventArgs e)
        {
            try
            {
                contextMenuWorkAs.Show(btnWorkingAs, new Point(0, 21));
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                btn.VisualStyle = Janus.Windows.UI.VisualStyle.Standard;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}