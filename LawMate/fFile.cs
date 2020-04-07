using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;
using System.Linq;

 namespace LawMate
{
    public partial class fFile : fBase
    {
        atriumBE.FileManager fmCurrent;
        Dictionary<string, ucBase> ucDic = new Dictionary<string, ucBase>();
        ucBase currentCtl;
        bool isDirty = false;
        public Janus.Windows.UI.CommandBars.UICommand CancelCommand
        {
            get { return cmdCancel; }
        }

        public bool IsDirty
        {
            get { return isDirty; }
            set 
            {
                isDirty = value;
                if (isDirty)
                {
                    cmdNewWizard.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsActions.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdRefresh.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCancel.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    VerifyCanAdd();
                    cmdRefresh.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    SetImportantMessageCmdState();
                }
            }
        }
        bool isIdleExceeded = false;
        bool isReadOnly = false;

        public bool ReadOnly
        {
            get { return isReadOnly; }
            set
            {
                //check if changed and true
                //this is need to prevent breaking the caching of the original read-only state of a control
                bool setReadOnly = false;
                if ( value != isReadOnly)
                    setReadOnly = true;

                isReadOnly = value;
                foreach (ucBase u in ucDic.Values)
                {
                    if(setReadOnly)
                        u.ReadOnly(isReadOnly);
                    u.ApplyBR(!isReadOnly);
                    u.CommandManager().ShortcutBehavior = Janus.Windows.UI.CommandBars.ShortcutBehavior.OnToolbarCommands;
                }

                uiCommandBar1.Visible = !isReadOnly; //menu bar


                uiCommandBar2.Visible = isReadOnly; // read-only mode menu bar
                uiCommandBar3.Enabled = !isReadOnly; // toolbar
                ucActivityNew2.ReadOnly(isReadOnly);
                if (isReadOnly)
                    cmdImportantFileMessageToggle.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                else
                    SetImportantMessageCmdState();
               
            }
        }

        //Janus.Windows.UI.Dock.UIPanel filePanel;

        public Janus.Windows.UI.Dock.UIPanel ImportantMessagePanel
        {
            get { return uiPanel2; }
        }

        public bool IsPageLoaded(string name)
        {
            return ucDic.ContainsKey(name);
        }
        public int CountOfLoadedUCs
        {
            get { return ucDic.Count; }
        }

        public int FileId
        {
            get { return fmCurrent.CurrentFile.FileId; }
        }

        public bool IsAPersonalFile
        {
            get 
            {
                if (fmCurrent.CurrentFile.FileType.ToUpper() == "PR")
                    return true;
                return false;
            }
        }

        public void EndEdit()
        {
            currentCtl.EndEdit();
        }

        public void VerifyCanAdd()
        {
            bool canAdd = fmCurrent.GetActivity().CanAdd(fmCurrent.CurrentFile);
            ucActivityNew2.Enabled = canAdd;
            if (canAdd)
            {
                tsActions.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdNewWizard.Enabled = Janus.Windows.UI.InheritableBoolean.True;    
            }
            else
            {
                tsActions.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdNewWizard.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        public void EditModeTitle(bool EditModeStart)
        {
            if (EditModeStart)
            {
                if (this.Text.IndexOf(LawMate.Properties.Resources.UIFileEditModeConcat) == -1)
                {
                    this.Text += LawMate.Properties.Resources.UIFileEditModeConcat;
                    IsDirty = true;
                }
                cmdRefresh.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                if (this.Text.IndexOf(LawMate.Properties.Resources.UIFileEditModeConcat) != -1)
                {
                    this.Text = this.Text.Substring(0, this.Text.Length - LawMate.Properties.Resources.UIFileEditModeConcat.Length);
                    IsDirty = false;
                }
                cmdRefresh.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        public override string Id
        {
            get { return this.Name + fmCurrent.CurrentFile.FileId.ToString(); }

        }

        public fFile()
        {
            InitializeComponent();
        }

        public fFile(Form f, int fileId)
            : base(f)
        {
            initFile(fileId);
            ucActivityNew2.Init(fmCurrent, this);
            if(AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.F4On,false))
            {
                 pnlNewActivity.Closed = false;
                 ucActivityNew2.FocusToCode();
            }
            MainForm.IncrementProgressBar(20);
            switch (fmCurrent.CurrentFile.FileType)
            {
                //case "X":

                //    fileToc.SelectedNode = "document";
                //    GetucCtl("document");
                //    break;
                case "F":
                    fileToc.SelectedNode = "activity";
                    GetucCtl("activity");

                    break;
                default:
                    fileToc.SelectedNode = "activity";
                    GetucCtl("activity");
                    break;
            }
            fileToc.LoadTOC();
            MainForm.IncrementProgressBar(20);
            MainForm.ResetProgressBar();
        }

        //public fFile(Form f, int fileId, string userControl)
        //    : base(f)
        //{
        //    initFile(fileId);
        //    MainForm.IncrementProgressBar(20);
        //    fileToc.SelectedNode = userControl;
        //    MainForm.IncrementProgressBar(20);
        //    GetucCtl(userControl);
        //    MainForm.IncrementProgressBar(20);
        //    MainForm.ResetProgressBar();
        //}
        private void LoadLabels()
        {
            cmdJumpToExplorer.Text = String.Format(LawMate.Properties.Resources.cmdBrowseExplorer, AtMng.AppMan.AppName);
            cmdJumpToExplorer.ToolTipText = String.Format(LawMate.Properties.Resources.cmdBrowseExplorer, AtMng.AppMan.AppName);
        }

        private void initFile(int fileId)
        {
            InitializeComponent();
            LoadLabels();
            //fwait = new fWait("Retrieving file, please wait");
            //fwait.Show();
            //fwait.Refresh();
            MainForm.IncrementProgressBar(10, LawMate.Properties.Resources.UIRetrievingFile);

            if (Screen.FromHandle(this.Handle).WorkingArea.Width < 1000)
                uiPanel0.AutoHide = true;


            timer1.Interval = LawMate.Properties.Settings.Default.IdleTimeDefault;

            fmCurrent = this.AtMng.GetFile(fileId);


            //if (fmCurrent.CurrentFile.IsFileStructXmlNull() || fmCurrent.CurrentFile.RebuildTOC)
            //{
            //    fmCurrent.EFile.RebuildFileStruct(fmCurrent.CurrentFile);
            //    //fmCurrent.CurrentFile.FileStructXml = fmCurrent.EFile.CalcFileStructXml(fmCurrent.CurrentFile, true, false).OuterXml;
            //}

            uiPanel0.AutoHide= AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.TocAutoHide, false);
            cmdHideToc.IsChecked = !uiPanel0.AutoHide;

            timFMHeartbeat.Start();
           // fmCurrent.KeepAlive = true;

            fmCurrent.OnWarning += new atLogic.WarningEventHandler(fmCurrent_OnWarning);
            eFileBindingSource.DataSource = fmCurrent.DB.EFile;
            SetImportantMessageCmdState();

            //fwait.incrementProgressBar(10);
            //DoAddTocPanel();
            fileToc.Init(fmCurrent, this);

            fmCurrent.GetFileXRef().OnUpdate += new atLogic.UpdateEventHandler(fFile_OnUpdate);

            this.Text = fmCurrent.CurrentFile.Name + " (" + fmCurrent.CurrentFile.FullFileNumber + ")";
            LoadFSIcon(fmCurrent.CurrentFile.StatusCode);
            fmCurrent.DB.EFile.ColumnChanged += new DataColumnChangeEventHandler(EFile_ColumnChanged);

            //this always fires!
            //no, not always
            if (fmCurrent.NeedsRefresh)
            {
                ReloadFileData();
                fmCurrent.NeedsRefresh = false;
            }
            MessageCheck();
            DisplayFileFlag();

            //add dynamic menu items
            FileTreeView.BuildMenu(fmCurrent, tsActions, FileTreeView.dmACTIVITY);
            FileTreeView.BuildMenu(fmCurrent, tsTimeKeeping, FileTreeView.dmTIMEKEEP);
            VerifyCanAdd();

            if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No)
            { 
                cmdJumpToExplorer.Visible = Janus.Windows.UI.InheritableBoolean.False;
                cmdNewXRef.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }

        }

        public void DisplayFileFlag()
        {
            string strComma = ",";
            string strSpace = " ";
            uiFileFlagBanner.Closed = true;
            uiFileFlagBanner.Visible = false;
            uiFileFlagBanner.Enabled = false;

            atriumDB.FileFlagDataTable fft = (atriumDB.FileFlagDataTable)fmCurrent.GetFileFlag().myDT;
            edFileBanner.Text = "";
            if (fft.Count != 0)
            {
                uiFileFlagBanner.Closed = false;
                uiFileFlagBanner.Visible = true;
                uiFileFlagBanner.Enabled = true;
                uiFileFlagBannerContainer.Size = uiFileFlagBanner.Size;
                edFileBanner.Size = uiFileFlagBannerContainer.Size;
                String FileFlag = null;
                foreach (atriumDB.FileFlagRow ffr in fft)
                {
                    if (fmCurrent.AppMan.Language.ToUpper() == "ENG")
                        FileFlag += strSpace + ffr.FlagCodeNameEng + strComma;
                    else
                        FileFlag += strSpace + ffr.FlagCodeNameFre + strComma;
                }
                edFileBanner.Text += FileFlag.Substring(0, FileFlag.Length - 1);

                Font f = edFileBanner.Font;
                Size sz = TextRenderer.MeasureText(edFileBanner.Text, f);
                if (edFileBanner.Width < sz.Width)
                {
                    uiFileFlagBanner.Height = uiFileFlagBanner.Size.Height + sz.Height;
                    uiFileFlagBannerContainer.Height = uiFileFlagBannerContainer.Height + sz.Height;
                    edFileBanner.Height = edFileBanner.Size.Height + sz.Height;

                }

            }

        }

        public void ReloadDocs()
        {
            if (fmCurrent.IsDocMng)
                fmCurrent.GetDocMng().LoadAll(true);

            if (ucDic.ContainsKey("document"))
            {
                ucDic["document"].ReloadUserControlData();
            }
        }
        public void ReloadFileData()
        {
            using (fWait fProgress = new fWait(LawMate.Properties.Resources.Reloading))
            {
               

                int fileid = fmCurrent.CurrentFileId;

                fmCurrent.RefreshMngrs();

                foreach (ucBase u in ucDic.Values)
                {
                    fProgress.setMessageText(LawMate.Properties.Resources.ReloadingData + u.ucDisplayName());
                    u.ReloadUserControlData();
                }
                fileToc.LoadTOC();
                this.Text = fmCurrent.CurrentFile.Name + " (" + fmCurrent.CurrentFile.FullFileNumber + ")";
                LoadFSIcon(fmCurrent.CurrentFile.StatusCode);
                MessageCheck();

            }
            
        }

        void MessageCheck()
        {
            //hate this, but for now.
            if (fmCurrent.GetCLASMng() != null && !fmCurrent.EFile.IsFileReceived())
            {
                pnlMessage.Closed = false;
                ebInfoMessage.Text = "You must receive the file";
            }
            else
            {
                pnlMessage.Closed = true;
                ebInfoMessage.Text = "";
            }
        }

        void fFile_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            try
            {
                fileToc.SetShortcutsXrefs();
            }
            catch (Exception x)
            { 
                //ignore so that we don't mess up the save acceptchanges
            }
        }

        void EFile_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName == "StatusCode")
                    LoadFSIcon(fmCurrent.CurrentFile.StatusCode);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void fmCurrent_OnWarning(object sender, atLogic.WarningEventArgs e)
        {
            if (e.Level == atLogic.WarningLevel.Interrupt)
            {
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void LoadFSIcon(string fileStatus)
        {
            switch (fileStatus)
            {
                case "A":
                    this.Icon = LawMate.Properties.Resources.FSArchived;
                    break;
                case "M":
                    this.Icon = LawMate.Properties.Resources.FSMonitored;
                    break;
                case "C":
                    this.Icon = LawMate.Properties.Resources.FSClosed;
                    break;
                case "P":
                    this.Icon = LawMate.Properties.Resources.FSPending;
                    break;
                default:
                    this.Icon = LawMate.Properties.Resources.FSOpen;
                    break;

            }
        }

        private void LoadingMessage(bool start)
        {
            if (start)
            {

                //MainForm.ResetProgressBar();
                MainForm.IncrementProgressBar(10);
            }
            else
            {
                MainForm.ResetProgressBar();
            }
        }
        private void incrementProgressBar(int inc)
        {
            MainForm.IncrementProgressBar(inc, null);
        }

        public void RestoreWizard(atriumBE.ACEState aces)
        {
            try
            {
                this.ReadOnly = true;
                fACWizard fACW = new fACWizard(fmCurrent,aces);
                fACW.Text += " - " + this.Text;
                HookupWizClose(fACW);

                fACW.Show();
            }
            catch (Exception x)
            {
                this.ReadOnly = false;
                fmCurrent.KillACEngine();

                UIHelper.HandleUIException(x);
            }
        }

        public void Cancel()
        {
            ucActivityNew2.Cancel();
            foreach (ucBase u in ucDic.Values)
            {
                u.Cancel();
            }
            
        }

        public void LaunchWizard()
        {

            try
            {
                this.ReadOnly = true;
                ucActivityNew2.Cancel();
                fACWizard fACW = new fACWizard(fmCurrent);
                fACW.Text += " - " + this.Text;
                HookupWizClose(fACW);

                fileToc.LoadTOC(); 
                fACW.Show();
            }
            catch (Exception x)
            {
                this.ReadOnly = false;
                fmCurrent.KillACEngine();

                UIHelper.HandleUIException(x);
            }
        }

        public  void HookupWizClose(fACWizard facwNewMail)
        {
            facwNewMail.FormClosed += new FormClosedEventHandler(fACW_FormClosed);
        }

        public void LaunchNewDocMailMemo(atriumBE.ACEngine.Step st, int StaticACSeriesID)
        {
            try
            {
                this.ReadOnly = true;
                fACWizard fNAW = new fACWizard(fmCurrent, st, StaticACSeriesID);
                HookupWizClose(fNAW);

                fileToc.LoadTOC();
                if (!fNAW.IsDisposed)
                    fNAW.Show();
                else
                {
                    this.ReadOnly = false;
                    fmCurrent.KillACEngine();
                }
            }
            catch (Exception x)
            {
                this.ReadOnly = false;
                fmCurrent.KillACEngine();
                UIHelper.HandleUIException(x);
            }
        }

        public void LaunchWiz( int StaticACSeriesID,DataRow contextRow)
        {
            try
            {
                this.ReadOnly = true;
                fACWizard fNAW = new fACWizard(fmCurrent,  StaticACSeriesID, ACEngine.RevType.Context,0,contextRow);
                HookupWizClose(fNAW);

                fileToc.LoadTOC();
                if (!fNAW.IsDisposed)
                    fNAW.Show();
                else
                {
                    this.ReadOnly = false;
                    fmCurrent.KillACEngine();
                }
            }
            catch (Exception x)
            {
                this.ReadOnly = false;
                fmCurrent.KillACEngine();
                UIHelper.HandleUIException(x);
            }
        }


        void fACW_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.ReadOnly = false;
                fACWizard f = (fACWizard)sender;
                ucActivityNew2.Init(fmCurrent, this);
                if (f.Reload)
                    ReloadFileData();
                fileToc.LoadTOC();

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        public ucBase GetUcCtlToc(string ctlName)
        { return GetucCtl(ctlName); }

        public ucBase GetUcCtlToc(string ctlName, string linkTable, int linkId)
        { return GetucCtl(ctlName, linkTable, linkId,null); }

        public ucBase GetUcCtlToc(string ctlName, string linkTable, string filter)
        { return GetucCtl(ctlName, linkTable,0, filter); }

        private ucBase GetucCtl(string ctlName)
        { return GetucCtl(ctlName, null, 0,null); }

        private ucBase GetucCtl(string ctlName, string linkTable, int linkId ,string filter)
        {
            bool currentCtlIsActiveCtl = ucDic.ContainsKey(ctlName) && currentCtl == ucDic[ctlName];

            if (!currentCtlIsActiveCtl)
                RevertStrips();

            //check to see if ctl exists
            if (!ucDic.ContainsKey(ctlName))
            {
                
                foreach (ucBase uc in ucDic.Values)
                {
                    uc.Visible = false;
                }
                LoadingMessage(true);

                //if not create it
                switch (ctlName)
                {
                    case "activitybf":
                        UserControls.ucActivityBF ucActivityBF = new UserControls.ucActivityBF();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucActivityBF);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        ucActivityBF.BindActivityBFData(fmCurrent.DB.ActivityBF);
                        incrementProgressBar(10);
                        break;
                    case "appointment":
                  //      fmCurrent.GetAppointment().LoadByFileId(fmCurrent.CurrentFile.FileId);
                   //     fmCurrent.GetAttendee().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucCalendar uccal = new ucCalendar();
                        uccal.IsOfficerCal = false;
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uccal);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        uccal.BindData(fmCurrent.DB.Appointment);
                        incrementProgressBar(10);
                        break;
                    case "fileparty":
                        fmCurrent.GetSSTMng();
                      
                        incrementProgressBar(10);
                        ucFileParty ucfp = new ucFileParty();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucfp);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucfp.BindData(fmCurrent.DB.FileContact);
                        incrementProgressBar(10);
                        break;
                    case "hardship":
                        fmCurrent.GetCLASMng();
                        
                        incrementProgressBar(10);
                        ucHardship uch = new ucHardship();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uch);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        uch.BindData(fmCurrent.GetCLASMng().DB.Hardship);
                        incrementProgressBar(10);
                        break;
                    case "fileaccess":
                        UserControls.ucFileAccess ucFileAcc = new UserControls.ucFileAccess();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucFileAcc);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        fmCurrent.GetFileAccess().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucFileAcc.BindData(fmCurrent.DB.FileAccess);
                        incrementProgressBar(10);
                        break;
                    case "security":
                        //load secfilerule
                        incrementProgressBar(10);
                        UserControls.ucFileRule ucFR = new UserControls.ucFileRule();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucFR);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                       // fmCurrent.GetsecFileRule().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        ucFR.BindData(fmCurrent.DB.secFileRule);
                        incrementProgressBar(10);
                        break;
                    case "document":

                        //fmCurrent.GetDocMng().GetDocument().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        //fmCurrent.GetDocMng().GetRecipient().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucRecords ucR = new ucRecords();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucR);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucR.BindDocumentData(fmCurrent.GetDocMng().DB.Document, false, fmCurrent.GetDocMng());
                        incrementProgressBar(10);
                        break;
                    case "activity":

                        ucActivity uca = new ucActivity();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uca);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        uca.ucActLoad();
                        incrementProgressBar(10);
                        //uca.BindActivityData(fmCurrent.DB.Activity);
                        incrementProgressBar(10);
                        break;
                    case "efile":
                        ucEFile uce = new ucEFile();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uce);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        uce.BindEfileData(fmCurrent.DB.EFile);
                        incrementProgressBar(10);
                        break;
                    case "opinion":
                        fmCurrent.GetAdvisoryMng();//.GetOpinion().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucOpinion ucopn = new ucOpinion();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucopn);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucopn.bindOpinionData(fmCurrent.GetAdvisoryMng().DB.Opinion);
                        incrementProgressBar(10);
                        break;
                    case "sstcase":
                        fmCurrent.GetSSTMng();
                        incrementProgressBar(10);
                        ucSSTCase ucsstCase = new ucSSTCase();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucsstCase);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucsstCase.bindData(fmCurrent.GetSSTMng().DB.SSTCase);
                        incrementProgressBar(10);
                        break;
                    case "sstdetail":
                        fmCurrent.GetSSTMng();
                        incrementProgressBar(10);
                        ucSSTDetail ucsstDetail = new ucSSTDetail();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucsstDetail);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucsstDetail.bindData(fmCurrent.GetSSTMng().DB.SSTCase);
                        incrementProgressBar(10);
                        break;
                    case "sstdecision":
                        fmCurrent.GetSSTMng();
                        incrementProgressBar(10);
                        ucSSTDecision ucsstDecision = new ucSSTDecision();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucsstDecision);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucsstDecision.bindData(fmCurrent.GetSSTMng().DB.SSTDecision);
                        incrementProgressBar(10);
                        break;

                    case "sstrequest":
                        fmCurrent.GetSSTMng();
                        incrementProgressBar(10);
                        ucSSTRequest ucsstRequest = new ucSSTRequest();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucsstRequest);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucsstRequest.bindData(fmCurrent.GetSSTMng().DB.SSTRequest);
                        incrementProgressBar(10);
                        break;

                    case "compoffer":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucCompOffer uccompoffer = new ucCompOffer();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uccompoffer);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        uccompoffer.BindCompOfferData(fmCurrent.GetCLASMng().DB.CompOffer);
                        incrementProgressBar(10);
                        break;
                    case "filehistory":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucFileHistory ucfh = new ucFileHistory();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucfh);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucfh.BindFileHistoryData(fmCurrent.GetCLASMng().DB.FileHistory);
                        incrementProgressBar(10);
                        break;
                    case "irp":
                     //   fmCurrent.GetIRP().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucTaxation uct = new ucTaxation();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uct);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        uct.BindIRPData(fmCurrent.DB.IRP);
                        incrementProgressBar(10);
                        break;
                    case "srp":
                        //Atmng.GetOfficeForOfficeFile(fmCurrent.CurrentFileId);
                        fmCurrent.GetSRP().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucSRP ucsrp = new ucSRP();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucsrp);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucsrp.bindSRPData(fmCurrent.DB.SRP);
                        incrementProgressBar(10);
                        break;
                    case "srpdetail":
                        //fmCurrent.OfficeMng.GetSRP().Load(linkId);
                        //fmCurrent.OfficeMng.GetIRP().LoadBySRPId(linkId);
                        
                        //jll 2014-10-09
                        //let's assume that if user clicked on srp detail node in toc, an srp exists.
                        //therefore, if no srp shows up in dataset, srp data has not yet been loaded
                        //if the case of no srp rows appearing in the dataset, let's load all srps, moreinfo handles loading of IRPs
                        if (fmCurrent.DB.SRP.Count == 0)
                            fmCurrent.GetSRP().LoadByFileId(fmCurrent.CurrentFile.FileId);

                        incrementProgressBar(10);
                        ucSRPDetail ucirp = new ucSRPDetail();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucirp);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = fmCurrent;
                        ucirp.bindIRPData(fmCurrent.DB.IRP);
                        incrementProgressBar(10);
                        break;
                    case "billingreview":
                        //fmCurrent.GetIRP().LoadBySRPId(linkId);
                        incrementProgressBar(10);
                        ucSRPBillingReview ucbr = new ucSRPBillingReview();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucbr);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = fmCurrent;
                        ucbr.BindData(fmCurrent.DB.IRP);
                        incrementProgressBar(10);
                        break;
                    case "opponent":
                     //   fmCurrent.GetCLASMng().GetDebtor().LoadByFileId(fmCurrent.CurrentFile.FileId);
                     //   fmCurrent.GetAKA().LoadByContactId(fmCurrent.CurrentFile.OpponentID);
                     //   fmCurrent.GetAddress().LoadByContactId(fmCurrent.CurrentFile.OpponentID);
                        incrementProgressBar(10);
                        ucOpponent ucDebtor = new ucOpponent();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucDebtor);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        ucDebtor.bindDebtorData(fmCurrent.GetCLASMng().DB.Debtor);
                        incrementProgressBar(10);
                        break;
                    case "cbdetail":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucCashBlotter uccb = new ucCashBlotter();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uccb);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        uccb.bindCBData(fmCurrent.GetCLASMng().DB.CBDetail);
                        incrementProgressBar(10);
                        break;
                    case "cashblotter":
                        
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucCashBlotterOffice uccbo = new ucCashBlotterOffice();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, uccbo);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        uccbo.bindCBData(fmCurrent.GetCLASMng().DB.CashBlotter);
                        incrementProgressBar(10);
                        break;
                    case "riskassessment":
                      //  fmCurrent.GetRiskAssessment().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucLRM ucLRM = new ucLRM();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucLRM);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        ucLRM.bindLRMData(fmCurrent.DB.RiskAssessment);
                        incrementProgressBar(10);
                        break;
                    case "account":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucFileAccount ucFA = new ucFileAccount();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucFA);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        ucFA.bindFileAccountData(fmCurrent.GetCLASMng().DB.Debt);
                        incrementProgressBar(10);
                        break;
                    case "bankruptcy":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucBankruptcy ucBK = new ucBankruptcy();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucBK);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucBK.bindBankruptcyData(fmCurrent.GetCLASMng().DB.Bankruptcy);
                        incrementProgressBar(10);
                        break;
                    case "insolvency":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucInsolvency ucIns = new ucInsolvency();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucIns);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        ucIns.bindInsolvencyData(fmCurrent.GetCLASMng().DB.Insolvency);
                        incrementProgressBar(10);
                        break;
                    case "judgment":
                    case "writ":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucJudgment ucJgt = new ucJudgment();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucJgt);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        ucJgt.bindJudgmentData(fmCurrent.GetCLASMng().DB);
                        incrementProgressBar(10);
                        break;
                    case "template":
                        fmCurrent.AtMng.GetTemplate().Load();
                        incrementProgressBar(10);
                        ucTemplate ucTemplate = new ucTemplate();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucTemplate);
                        ucDic[ctlName].FM = this.fmCurrent;
                        incrementProgressBar(10);
                        ucTemplate.bindDocumentData(fmCurrent.AtMng.DB.Template);
                        incrementProgressBar(10);
                        break;
                    case "fileoffice":
                        //fmCurrent.GetFileOffice().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucFileOffice ucFO = new ucFileOffice();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucFO);
                        ucDic[ctlName].FM = fmCurrent;
                        incrementProgressBar(10);
                        ucFO.bindFileOfficeData(fmCurrent.DB.FileOffice);
                        incrementProgressBar(10);
                        break;
                    case "taxing":
                    case "filetaxing":
                    case "officetaxing":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucTaxingRecommendation ucTaxRec = new ucTaxingRecommendation();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucTaxRec);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;

                        ucTaxRec.bindTaxRecData(fmCurrent.GetCLASMng().DB.Taxing, ctlName == "officetaxing");
                        incrementProgressBar(10);
                        break;

                    case "contact":
                        //fmCurrent.GetFileContact().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        incrementProgressBar(10);
                        ucFileContact ucfc = new ucFileContact();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucfc);
                        ucDic[ctlName].FM = fmCurrent;
                        incrementProgressBar(10);
                        ucfc.BindFileContactData(fmCurrent.DB.FileContact);
                        incrementProgressBar(10);
                        break;
                    case "office":

                        lmDatasets.officeDB.OfficeRow or = fmCurrent.LeadOfficeMng.GetOffice().LoadByOfficeFileId(fmCurrent.CurrentFile.FileId);
                        if(!or.IsAddressIdNull())
                            fmCurrent.GetAddress().Load(or.AddressId);
                        incrementProgressBar(10);
                        ucOfficeInfo ucOI = new ucOfficeInfo();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucOI);
                        incrementProgressBar(10);
                        ucDic[ctlName].FM = this.fmCurrent;
                        ucOI.bindOfficeData(fmCurrent.LeadOfficeMng.DB.Office);
                        incrementProgressBar(10);
                        break;
                    case "officeaccount":
                        fmCurrent.GetCLASMng();
                        incrementProgressBar(10);
                        ucOfficeQR ucqr = new ucOfficeQR();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucqr);
                        ucDic[ctlName].FM = fmCurrent;
                        incrementProgressBar(10);
                        ucqr.BindQRData(fmCurrent.GetCLASMng().DB.OfficeAccount);
                        incrementProgressBar(10);
                        break;
                    case "officer":

                        //this works when the personnel link is in the office file
                        //fmCurrent.OfficeMng.GetOffice().LoadByOfficeFileId(fmCurrent.CurrentFile.FileId);
                        //fmCurrent.OfficeMng.GetOfficer().LoadByOfficeId(fmCurrent.CurrentFile.LeadOfficeId);

                        //this works for the lead office
                        fmCurrent.LeadOfficeMng.GetOfficer().LoadByOfficeId(fmCurrent.CurrentFile.LeadOfficeId);

                        incrementProgressBar(10);
                        ucOfficePersonnel ucOP = new ucOfficePersonnel();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucOP);
                        ucDic[ctlName].FM = fmCurrent;
                        incrementProgressBar(10);
                        ucOP.BindPersonnelData(fmCurrent.LeadOfficeMng.DB.Officer);
                        incrementProgressBar(10);
                        break;

                    case "timeslip":
                        fmCurrent.GetSRP().LoadByFileId(fmCurrent.CurrentFileId);
                        incrementProgressBar(10);
                        ucTimeslip ucTimeSlip = new ucTimeslip();
                        incrementProgressBar(10);
                        ucDic.Add(ctlName, ucTimeSlip);
                        ucDic[ctlName].FM = fmCurrent;
                        incrementProgressBar(10);
                        ucTimeSlip.BindTimeSlipData(fmCurrent.DB.SRP);
                        incrementProgressBar(10);
                        break;

                    default:
                        if (ctlName.StartsWith("s-"))
                        {
                            incrementProgressBar(10);
                            ucScript ucs = new ucScript();
                            incrementProgressBar(10);
                            ucDic.Add(ctlName, ucs);
                            ucDic[ctlName].FM = fmCurrent;
                            incrementProgressBar(10);
                            ucs.LoadHTML(ctlName);
                            incrementProgressBar(10);
                        }
                        else if (ctlName.StartsWith("acs-"))
                        {
                            incrementProgressBar(10);
                            ucA5 ucs = new ucA5();
                            incrementProgressBar(10);
                            ucDic.Add(ctlName, ucs);
                            ucDic[ctlName].FM = fmCurrent;
                            incrementProgressBar(10);
                            ucs.LoadACS(ctlName);
                            incrementProgressBar(10);
                        }
                        else
                        {
                            throw new Exception(String.Format(LawMate.Properties.Resources.UIScreenNotComplete, ctlName));
                        }
                        break;
                }
                incrementProgressBar(50);
                //  ucDic[ctlName].ReadOnly(isReadOnly);
                ucDic[ctlName].Dock = DockStyle.Fill;
                ucDic[ctlName].AutoScroll = true;
                uiPanel1.InnerContainer.Controls.Add(ucDic[ctlName]);
            }

            //and hide all the rest

            if (!currentCtlIsActiveCtl)
            {
                foreach (ucBase uc in ucDic.Values)
                {
                    uc.Visible = false;
                }
            }

            //then show it
            LoadingMessage(false);

            ucDic[ctlName].Visible = true;
            if (ucDic[ctlName].controlHasBorder())
                uiPanel1.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            else
                uiPanel1.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;

            currentCtl = ucDic[ctlName];
            fileToc.SelectedNode = ctlName;

            if (linkTable != null)
            {
                if(filter==null)
                    currentCtl.MoreInfo(linkTable, linkId);
                else
                    currentCtl.MoreInfo(linkTable, filter);
            }
            if(!currentCtlIsActiveCtl)
                MergeStrips();

            //ucDic[ctlName].ReadOnly(ReadOnly);
            ReadOnly = ReadOnly;

            ucDic[ctlName].Focus();

            return ucDic[ctlName];
        }

        //private void DoRemoveTocPanel()
        //{
        //    try
        //    {
        //        filePanel.Controls.Remove(fileToc);
        //        MainForm.pnlAllTocs.Panels.SetPanelIndex(filePanel,0);
        //        MainForm.pnlAllTocs.Panels.RemoveAt(0);

        //        filePanel.Dispose();
        //        fileToc.Dispose();
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        //private void DoHideTocPanel(bool hidePanel)
        //{
        //    try
        //    {
        //        MainForm.pnlAllTocs.Panels[MainForm.pnlAllTocs.Panels.IndexOf(filePanel)].Closed = hidePanel;
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        //private void DoAddTocPanel()
        //{
        //    try
        //    {
        //        Janus.Windows.UI.Dock.UIPanel pnl = new Janus.Windows.UI.Dock.UIPanel(fmCurrent.CurrentFile.NameE);
        //        pnl.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
        //        MainForm.pnlAllTocs.Panels.Add(pnl);
        //        fileToc = new ucToC();
        //        fileToc.Init( fmCurrent, this);
        //        pnl.InnerContainer.Controls.Add(fileToc);
        //        fileToc.Dock = DockStyle.Fill;
        //        filePanel = pnl;
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }

        //}


        //private void fFile_Activated(object sender, EventArgs e)
        //{
        //    if (isIdleExceeded)
        //    {
        //        if (IsDirty)
        //        {
        //            MessageBox.Show(LawMate.Properties.Resources.UIIdleTimePassedEditMode, LawMate.Properties.Resources.UIIdleTimeLimitExceeded, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        //        }
        //        else
        //        {
        //            MessageBox.Show(LawMate.Properties.Resources.UIIdleTimePassed, LawMate.Properties.Resources.UIIdleTimeLimitExceeded, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        //        }
        //        isIdleExceeded = false;
        //        timer1.Stop();
        //        //this.Close();
        //    }
        //    else
        //    {
        //        //DoHideTocPanel(false);
        //        timer1.Stop();
        //    }

        //}

        //private void fFile_Deactivate(object sender, EventArgs e)
        //{
        //    //if(MainForm.pnlAllTocs.Panels.Contains(filePanel))
        //    //    DoHideTocPanel(true);

        //    timer1.Start();
        //}

        private Janus.Windows.UI.CommandBars.UICommandManager FileCommandManager()
        {
            return uiCommandManager1;
        }

        private void MergeStrips()
        {
            if (currentCtl != null && currentCtl.CommandManager() != null)
            {
                FileCommandManager().MergeCommandManager(currentCtl.CommandManager());
            }
        }


        private void RevertStrips()
        {
            if (currentCtl != null && currentCtl.CommandManager() != null)
                FileCommandManager().UnmergeCommandManager();
        }

        public void MoreInfo(string linkTable, int LinkId)
        {
            ucBase uc;
            uc = MoreInfo(linkTable);
            uc.MoreInfo(linkTable, LinkId);
        }

        public ucBase MoreInfo(string linkTable)
        {
            ucBase uc;
            switch (linkTable.ToLower())
            {

                case "activitybf":
                    uc = GetucCtl("activitybf");
                    break;
                case "appointment":
                    uc = GetucCtl("appointment");
                    break;
                case "officeaccount":
                    uc = GetucCtl("officeaccount");
                    break;
                case "bankruptcy":
                    uc = GetucCtl("bankruptcy");
                    break;
                case "insolvency":
                    uc = GetucCtl("insolvency");
                    break;
                case "taxing":
                    uc = GetucCtl("taxing");
                    break;
                case "filetaxing":
                    uc = GetucCtl("filetaxing");
                    break;
                case "officetaxing":
                    uc = GetucCtl("officetaxing");
                    break;
                case "opinion":
                    uc = GetucCtl("opinion");
                    break;
                case "fileoffice":
                    uc = GetucCtl("fileoffice");
                    break;
                case "irp":
                    uc = GetucCtl("irp");
                    break;
                case "filehistory":
                    uc = GetucCtl("filehistory");
                    break;
                case "filecontact":
                    uc = GetucCtl("contact");
                    break;
                case "accounthistory":
                    uc = GetucCtl("accounthistory");
                    break;
                case "cashblotter":
                    uc = GetucCtl("cashblotter");
                    break;
                case "cbdetail":
                    uc = GetucCtl("cbdetail");
                    break;
                case "debt":
                    uc = GetucCtl("account");
                    break;
                case "debtor":
                    uc = GetucCtl("opponent");
                    break;
                case "efile":
                    uc = GetucCtl("efile");
                    break;
                case "riskassessment":
                    uc = GetucCtl("riskassessment");
                    break;
                case "document":
                    uc = GetucCtl("document");
                    break;
                case "activity":
                    uc = GetucCtl("activity");
                    break;
                case "officer":
                    uc = GetucCtl("officer");
                    break;
                case "cost":
                case "writ":
                case "judgment":
                case "judgmentaccount":
                    uc = GetucCtl("judgment");
                    break;
                case "srp":
                    uc = GetucCtl("srp");
                    break;
                case "srpdetail":
                    uc = GetucCtl("srpdetail");
                    break;
                case "billingreview":
                    uc = GetucCtl("billingreview");
                    break;
                case "timeslip":
                    uc = GetucCtl("timeslip");
                    break;
                default:
                    if (linkTable.ToLower().StartsWith("acs-"))
                    {
                        uc = GetucCtl(linkTable);
                        break;
                    }
                    else
                    {
                        throw new LMException(LawMate.Properties.Resources.UIMoreInfoNotSupported);
                    }
            }
            return uc;
        }

      

        private void fFile_KeyDown(object sender, KeyEventArgs e)
        {
            string op = null;
            if (e.Control && e.KeyCode == Keys.PageUp)
                op = "previous";

            if (e.Control && e.KeyCode == Keys.PageDown)
                op = "next";

            if (e.Control && e.KeyCode == Keys.Home)
                op = "first";

            if (e.Control && e.KeyCode == Keys.End)
                op = "last";

            if (op != null)
            {
                e.Handled = true;
                currentCtl.MoveTab(op);
            }

            //quick activity entry
            if (e.KeyCode == Keys.F4)
            {
                if (pnlNewActivity.Closed)
                {
                    AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.F4On, true);
                    pnlNewActivity.Closed = false;
                    ucActivityNew2.FocusToCode();
                }
                else 
                {
                    AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.F4On, false);
                    pnlNewActivity.Closed = true;
                    ucActivityNew2.ClearCode();
                    this.Focus();
                }
 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isIdleExceeded = true;
            timer1.Stop();
        }


        private void uiPanelManager1_PanelClosedChanged(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            if (e.Panel.Name == "uiPanel2")
            {
                if (uiPanel2.Closed)
                    EnableImportantMessageLink(true);
                else
                    EnableImportantMessageLink(false);
            }
        }

        private void EnableImportantMessageLink(bool enable)
        {
            if (enable)
                cmdImportantFileMessageToggle.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmdImportantFileMessageToggle.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        private void SetImportantMessageCmdState()
        {
            if (!fmCurrent.CurrentFile.IsImportantMsgNull())
            {
                cmdImportantFileMessageToggle.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                uiPanel2.Closed = false;
            }
            else
            {
                uiPanel2.Closed = true;
                cmdImportantFileMessageToggle.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
            using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
            {
                try
                {
                    switch (e.Command.Key)
                    {
                        case "cmdCancel":
                            Cancel();
                            break;
                        case "cmdClose":
                            this.Close();
                            break;
                        case "cmdFileTemplates":
                            GetucCtl("template");
                            break;
                        case "cmdSave":
                            currentCtl.Save();
                            fileToc.LoadTOC();
                            break;
                        case "cmdSecurity":
                            GetucCtl("security");
                            break;
                        case "cmdAddToShortcuts":
                            fProgress.Dispose();
                            lmWinHelper.AddToMyShortcuts(AtMng, AtMng.FileSearchByFileId(fmCurrent.CurrentFileId)[0]);
                            break;
                        case "cmdHideToc":
                            fProgress.Dispose();
                            uiPanel0.AutoHide = !(uiPanel0.AutoHide);
                            AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.TocAutoHide, uiPanel0.AutoHide);
                            break;
                        case "cmdImportantFileMessageToggle":
                            fProgress.Dispose();
                            uiPanel2.Closed = false;
                            break;
                        case "cmdJumpToExplorer":
                            lmWinHelper.JumpToExplorer(this.MainForm, fmCurrent.CurrentFileId);
                            break;
                        case "cmdNewXRef":
                            fProgress.Dispose();
                            lmWinHelper.CreateNewXRef(AtMng, AtMng.FileSearchByFileId(fmCurrent.CurrentFileId)[0]);
                            break;
                        case "cmdReadOnly":
                            RestoreNAWWindow();
                            break;
                        case "cmdRefresh":
                            ReloadFileData();
                            break;
                        case "cmdNewWizard":
                        case "tsNew":
                            LaunchWizard();
                            break;
                    }

                    HandleACSMenu(e, null);

                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
            }
            Application.UseWaitCursor = false; Cursor = Cursors.Default;
        }
        public void HandleACSMenu(Janus.Windows.UI.CommandBars.CommandEventArgs e, DataRow current)
        {
            if (e.Command.Key.StartsWith("tsACMenu"))
            {
                ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)e.Command.Tag;
                if (acsr.InitialStep == (int)ACEngine.Step.CreateFile)
                {
                    fACWizard fACWDyn = new fACWizard(fmCurrent, (ACEngine.Step)acsr.InitialStep, acsr.ACSeriesId);
                    fileToc.LoadTOC();
                    fACWDyn.ShowDialog(MainForm);
                    fACWDyn.Close();
                }
                else if (acsr.StepType == (int)atriumBE.StepType.Action)//action
                {
                    AtMng.GetddRule().ExecuteAction(fmCurrent, current, acsr);
                }
                else// if (e.ACSeries.InitialStep == (int)ACEngine.Step.Document)
                {
                    LaunchWiz(acsr.ACSeriesId,current);

                }

            }
        }

        public void toggleNavPanel()
        {
            cmdHideToc.InvokeOnClick();
        }

        private void RestoreNAWWindow()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(fACWizard))
                {
                    fACWizard ffl = (fACWizard)f;
                    if (ffl.FileId == fmCurrent.CurrentFileId)
                    {
                        if (ffl.WindowState == FormWindowState.Minimized)
                            ffl.WindowState = FormWindowState.Normal;
                        ffl.Activate();
                        return;
                    }
                }
            }
            //we didn't find a wizard - oops!
            ReadOnly = false;
            fmCurrent.KillACEngine();
        }


        private void uiPanelManager1_PanelAutoHideChanged(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            try
            {
                if (e.Panel.Name == "uiPanel0")
                {
                    if (e.Panel.AutoHide)
                    {
                        cmdHideToc1.Checked = Janus.Windows.UI.InheritableBoolean.False;
                        cmdHideToc2.Checked = Janus.Windows.UI.InheritableBoolean.False;
                        AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.TocAutoHide, true);
                        uiPanel0.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Right;
                        uiPanel1.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
                    }
                    else
                    {
                        cmdHideToc1.Checked = Janus.Windows.UI.InheritableBoolean.True;
                        cmdHideToc2.Checked = Janus.Windows.UI.InheritableBoolean.True;
                        AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.TocAutoHide, false);
                        uiPanel1.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Left;
                        uiPanel0.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
                    }
                    
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ucDic.ContainsKey("doc"))
            {
                //clear ucdoc
            }
            fmCurrent.NeedsRefresh = true;
        }

        private void timFMHeartbeat_Tick(object sender, EventArgs e)
        {
            try
            {
                atriumBE.FileManager fm = AtMng.GetFile(fmCurrent.CurrentFile.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void fFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReadOnly)
            {
                e.Cancel = true;
                MessageBox.Show(LawMate.Properties.Resources.YouCanTCloseTheFormWhileThereIsAWizardOpen);
            }
            else if (IsDirty)
            {
                DialogResult dr = MessageBox.Show(LawMate.Properties.Resources.YouHaveMadeChangesToThisFileWhichHaveNotBeenSaved, AtMng.AppMan.AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        currentCtl.Save();


                    }
                    catch (Exception x)
                    {
                        UIHelper.HandleUIException(x);
                        e.Cancel = true;
                    }

                }
                else if (dr == DialogResult.No)
                {
                    //just close
                    //do we need to call some kind of cancel code?
                    currentCtl.Cancel();
                }
                else
                {
                    e.Cancel = true;
                }
            }

            foreach (ucBase u in ucDic.Values)
            {
                u.SaveLayout();
            }

        }

        private void uiCommandBar3_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
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

        private void ebInfoMessage_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                pnlMessage.Closed = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //public bool IsOnScreen(Form form)
        //{
        //    // Create rectangle
        //    Rectangle formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);

        //    // Test
        //    return Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(formRectangle));
        //}

        //private void fFile_SizeChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if(!IsOnScreen(this))
        //            this.Location = new Point(0, 0);
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}
    }
}

