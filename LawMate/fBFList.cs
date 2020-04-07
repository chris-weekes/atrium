using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;
using System.IO;

 namespace LawMate
{
    public partial class fBFList : fBase
    {

        bool UpdateAsRead = true;
        FileManager fmCurrent;
        atriumBE.DocManager dm;
        int mybfOfficerId;
        int mybfOfficeId;
        Dictionary<string, DataView> LoadedDVs = new Dictionary<string, DataView>();
        ImageList mainImgList;

        public officeDB.OfficerRow bfOfficer
        {
            get
            {
                return AtMng.GetOffice(mybfOfficeId).DB.Officer.FindByOfficerId(mybfOfficerId);
            }
            set
            {
                mybfOfficerId = value.OfficerId;
                mybfOfficeId = value.OfficeId;

            }
        }
        bool isViewingCompletedItems = false;
        DateTime CompletedBFsStartDate;
        DateTime CompletedBFsEndDate;
        int unlinkedFileId;
        const string LayoutVersionNumber = "4_0_21";


        int refreshTimerFailCounter = 0;
        public int instance = -1;
        atriumDB.ActivityBFRow SelectedBFRow;

        docDB.DocumentRow[] drDoc;
        DataView dvDoc;



        string id = "";

        private bool startupBFList = false;
        public bool StartupBFList
        {
            set { startupBFList = value; }
        }

        public bool BFListIsInEditMode
        {
            get { return InEditMode; }
        }
        public fBFList()
        {
            InitializeComponent();
        }

        public override string Id
        {
            get { return id; }
        }

        // COMPLETED ITEMS CONSTRUCTOR
        public fBFList(Form f, officeDB.OfficerRow officer, DateTime StartDate, DateTime EndDate)
            : base(f)
        {
            InitializeComponent();
            mainImgList = MainForm.mainImageList;
            isViewingCompletedItems = true;
            CompletedBFsStartDate = StartDate;
            CompletedBFsEndDate = EndDate;
            timrefresh.Enabled = false;
            fmCurrent = this.AtMng.GetFile();
            calBFListRange.MaxDate = DateTime.Today.AddDays(30);
            int daysAhead = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.BFDaysAhead, 0);
            calBFListRange.Value = DateTime.Today.AddDays(daysAhead);
            LoadPriorityFieldValues();
            bfOfficer = officer;// Atmng.GetOfficeForOfficer(officerId).GetOfficer().Load(officerId);
            this.Text = String.Format(LawMate.Properties.Resources.CompletedItemsBFPerson, bfOfficer.LastName, bfOfficer.FirstName);
            tsScreenTitle.Text = String.Format(LawMate.Properties.Resources.ItemsCompletedBetweenStartDateAndEndDate, StartDate.ToString("yyyy/MM/dd"), EndDate.ToString("yyyy/MM/dd"));
            tsReload.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            tsSave2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            tsCancel2.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            //cmdEditPanelToggle.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            activityBFGridEX.RootTable.Columns["CompletedDate"].Visible = true;
            activityBFGridEX.RootTable.Columns["CompletedByID"].Visible = true;
            lblBF30.Visible = false;

            uiCommandBar1.Commands.Remove(cmdActions1);
            uiCommandBar1.Commands.Remove(tsSave4);
            uiCommandBar1.Commands.Remove(tsCancel4);
            uiCommandBar1.Commands.Remove(tsReload1);
            uiCommandBar1.Commands.Remove(cmdDateRange1);
            uiCommandBar1.Commands.Remove(cmdListRangeLabel1);
            foreach (Janus.Windows.UI.CommandBars.UICommand cmd in cmdActions.Commands)
            {
                cmd.BaseCommand.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            uiCommandBar4.Enabled = false;
            uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            uiCommandManager1.LockCommandBars = true;
            uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
     //       uiCommandManager1.CommandBars.Remove(uiCommandBar2);



            cbMailFilter.Checked = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.CompletedBFListMailOnly, false);
            comboBox2.SelectedIndex = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.CompletedBFListMailType, 0);

            //if (UIHelper.GetSetting("CompletedListMailType") == "")
            //    comboBox2.SelectedIndex = 0;
            //else
            //    comboBox2.SelectedIndex = int.Parse(UIHelper.GetSetting("CompletedListMailType"));

            ApplyGridFilter();
            //Atmng.GetCodeTableBE("BFType").Load();
            id = this.Name + "CompletedItems" + bfOfficer.OfficerId.ToString();

            dm = fmCurrent.GetDocMng();
            ucDocView1.Init(dm);
            ucDocView1.Clear();
            ucDocView1.ReturnFocusTo = this.activityBFGridEX;
            //ucDoc1.Init(dm);
            //ucDoc1.Clear();
            //ucDoc1.ReturnFocusTo = this.activityBFGridEX;

        }

        public fBFList(Form f, officeDB.OfficerRow officer)
            : base(f)
        {
            InitializeComponent();
            timrefresh.Interval = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.BFTimerInterval, AtMng.GetSetting(atriumBE.AppIntSetting.DefaultBFTimerInterval));
            fmCurrent = this.AtMng.GetBFFile(officer.OfficerId);
            calBFListRange.MaxDate = DateTime.Today.AddDays(30);
            int daysAhead=AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.BFDaysAhead, 0);
            calBFListRange.Value = DateTime.Today.AddDays(daysAhead);
            mainImgList = MainForm.mainImageList;
            LoadPriorityFieldValues();
            bfOfficer = officer;
            unlinkedFileId = bfOfficer.InboxId;

            this.Text += " (" + bfOfficer.LastName + ", " + bfOfficer.FirstName + ")";


            cbMailFilter.Checked = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.BFListMailOnly, false);
            comboBox2.SelectedIndex = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.BFListMailType, 0);

            ApplyGridFilter();

            id = this.Name + bfOfficer.OfficerId.ToString();

            dm = fmCurrent.GetDocMng();

            ucDocView1.Init(dm);
            ucDocView1.Clear();
            ucDocView1.ReturnFocusTo = this.activityBFGridEX;
            
            this.uiCommandManager1.SetContextMenu(this.activityBFGridEX, this.uiContextMenu1);
        }

        private void toggleLoad(bool hide)
        {
            tbTo.Visible = !hide;
            bFOfficerCodeLabel.Visible = !hide;
            lblMailIcon.Visible = !hide;
            priorityJComboBox.Visible = !hide;
            priorityLabel.Visible = !hide;
            bFDateCalendarCombo.Visible = !hide;
            bFDateLabel.Visible = !hide;
            BFCommentCounter.Visible = !hide;
            bFCommentEditBox.Visible = !hide;
            bFCommentLabel.Visible = !hide;
            pnlPreviewedDoc.Closed = hide;
            label9.Visible = hide;
        }

        private void HookUpDataSource()
        {
            BindBFData(fmCurrent.DB.ActivityBF);

            if (isViewingCompletedItems)
            {
                LoadCompletedItems(bfOfficer.OfficerId, CompletedBFsStartDate, CompletedBFsEndDate);
            }
            else
            {
                DoReload(bfOfficer);
            }

            tsNumBFs.Text = fmCurrent.DB.ActivityBF.Rows.Count.ToString();
            tsOfficer.Text = bfOfficer.LastName + ", " + bfOfficer.FirstName + " (" + bfOfficer.OfficerCode + ")";
        }

        private void HookUpGridExDropDowns()
        {
            UIHelper.ComboBoxInit("vRoleucontacttype", activityBFGridEX.DropDowns["ddRoleCode"], fmCurrent);
            UIHelper.ComboBoxInit(AtMng.acMng.DB.ACBF, activityBFGridEX.DropDowns["ddACBFId"], fmCurrent);
            UIHelper.ComboBoxInit(AtMng.acMng.DB.ACSeries, activityBFGridEX.DropDowns["ddAcSeries"], fmCurrent);
            UIHelper.ComboBoxInit("vOfficerList", activityBFGridEX.DropDowns["ddOfficer"], fmCurrent);
        }

        private void SetCommandsState()
        {
            tsFilter.IsChecked = (activityBFGridEX.FilterMode != Janus.Windows.GridEX.FilterMode.None);
            cmdGroupBy.IsChecked = activityBFGridEX.GroupByBoxVisible;
            //cmdEditPanelToggle.IsChecked = !pnlEditableFields.Closed;
            cmdGrdExpand.IsChecked = pnlPreviewedDoc.Closed;
        }

        private void LoadPriorityFieldValues()
        {
            priorityJComboBox.ImageList = mainImgList;
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityNormal, 0, 36));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityHigh, 1, 34));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityUrgent, 2, 35));
        }

        private void BindBFData(atriumDB.ActivityBFDataTable bft)
        {
            
            this.activityBFBindingSource.DataMember = bft.TableName;
            this.activityBFBindingSource.DataSource = bft.DataSet;

            bft.ColumnChanged += new DataColumnChangeEventHandler(bft_ColumnChanged);
        }

        void bft_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName != "isRead")
                    ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool InEditMode = false;
        private void ApplyBR(bool DataNotDirty)
        {
            if (DataNotDirty)
            {
                tsReload.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsMove4.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsMoreInfo2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdSend.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdResetGrid.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                calBFListRange.Enabled = true;
                comboBox2.Enabled = true;
                uiCommandBar1.Commands["tsEditmode"].Image = LawMate.Properties.Resources.blank;
                uiCommandBar1.Commands["tsEditmode"].IsChecked = false;
                uiCommandBar1.Commands["tsEditmode"].ToolTipText = "";
                InEditMode = false;
            }
            else
            {
                tsReload.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsMove4.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsMoreInfo2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdSend.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdResetGrid.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                calBFListRange.Enabled = false;
                comboBox2.Enabled = false;
                uiCommandBar1.Commands["tsEditmode"].Image = LawMate.Properties.Resources.modified;
                uiCommandBar1.Commands["tsEditmode"].IsChecked = true;
                uiCommandBar1.Commands["tsEditmode"].ToolTipText = LawMate.Properties.Resources.YouAreInEditMode;
                InEditMode = true;
            }
            CheckForComplete();
        }

        string mbEditText = LawMate.Properties.Resources.UIBFListEditModePrompt;
        string mbCaption = LawMate.Properties.Resources.UIBFListInEditMode;
        public void OfficerToolkitMailClick(bool BFsOnly, bool MailOnly, int MailType)
        {
            if (InEditMode)
            {
                if (MessageBox.Show(mbEditText, mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    UIHelper.Cancel(activityBFBindingSource);
                    ApplyBR(true);
                    setFilter(BFsOnly, MailOnly, MailType);
                }
            }
            else
            {
                setFilter(BFsOnly, MailOnly, MailType);
            }

        }

        private void setFilter(bool BFsOnly, bool MailOny, int MailType)
        {
            chkOnlyBFs.Checked = BFsOnly;
            if (BFsOnly) //overide mailfilter if bfsonly = true
                cbMailFilter.Checked = false;
            else
                cbMailFilter.Checked = MailOny;
            comboBox2.SelectedIndex = MailType;
            ApplyGridFilter();
        }

        private void ApplyGridFilter()
        {

            int curBFID = 0;
            if (CurrentRow() != null)
                curBFID = CurrentRow().ActivityBFId;

            string filter = "BFDate<=#" + calBFListRange.Value.ToString("yyyy/MM/dd") + "#";
            if (isViewingCompletedItems)
                filter = "true";

            if (chkOnlyBFs.Checked)
            {
                tsScreenTitle.Text = Properties.Resources.otkJustBFs;
                filter += " and isMail=0";
            }
            else if (cbMailFilter.Checked)
            {
                filter += " and isMail=1";
                switch (comboBox2.SelectedIndex)
                {
                    case 1: //Unread Mail
                        filter += " and isRead=False";
                        tsScreenTitle.Text = LawMate.Properties.Resources.otkUnreadMail;
                        break;
                    case 2: //Read Mail
                        filter += " and isRead=True";
                        tsScreenTitle.Text = LawMate.Properties.Resources.ReadMail;
                        break;
                    default:
                        tsScreenTitle.Text = LawMate.Properties.Resources.otkAllMail;
                        break;
                }
            }
            else
            {
                if (!isViewingCompletedItems)
                    tsScreenTitle.Text = LawMate.Properties.Resources.otkAllBFs;
            }

            if (!isViewingCompletedItems)
            {
                AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.BFListMailType, comboBox2.SelectedIndex);
                AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.BFListMailOnly, cbMailFilter.Checked);
            }
            else
            {
                AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.CompletedBFListMailType, comboBox2.SelectedIndex);
                AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.CompletedBFListMailOnly, cbMailFilter.Checked);
            }

            activityBFBindingSource.Filter = filter;

            if (activityBFGridEX.RowCount == 0 && fmCurrent.DB.ActivityBF.Rows.Count > 0)
                GridHasNoSelection();
            else
            {
                if (fmCurrent.DB.ActivityBF.Rows.Count != 0)
                {

                    GridHasSelection();
                }
            }

            if(curBFID!=0)
                activityBFBindingSource.Position= activityBFBindingSource.Find("ActivityBFId", curBFID);

            SetBFListStatus();
        }

        private void GridHasSelection()
        {
            if (!SelectedBFRow.IsDocIdNull())
                DisplayDoc();

            bFDateCalendarCombo.Enabled = true;
            priorityJComboBox.Enabled = true;
            bFCommentEditBox.Enabled =  true;
            highlightCurrentRowInGrid();
        }


        private void GridHasNoSelection()
        {
            ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.NoSelectedBF);
            bFDateCalendarCombo.Enabled = false;
            priorityJComboBox.Enabled = false;
            bFCommentEditBox.Enabled = false;
        }

        private void SetBFListStatus()
        {
            if (!isViewingCompletedItems)
            {
                string filter = "";
                if (activityBFGridEX.GetRows().Length != activityBFBindingSource.Count)
                {
                    filter = Properties.Resources.BFListFilteredCount + activityBFGridEX.GetRows().Length.ToString() + " | ";
                }

                MainForm.SetBFListStatus(filter+ LawMate.Properties.Resources.BFsDisplayed + activityBFBindingSource.Count.ToString() + " | " + LawMate.Properties.Resources.BFs30Days + fmCurrent.DB.ActivityBF.Select("Completed=0").Length.ToString());
            }
            else
                MainForm.SetBFListStatus(LawMate.Properties.Resources.BFsDisplayed + activityBFBindingSource.Count.ToString());
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;

                UpdateAsRead = false; //don't auto save the read flag

                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars["Standard"];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                bar = uiCommandManager1.CommandBars["Advanced"];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                switch (e.Command.Key)
                {
                    case "cmdCopyFileNumber":
                        Clipboard.SetText(CurrentRow().FullFileNumber);
                        break;
                    case "cmdActions":
                        Application.UseWaitCursor = false; Cursor = Cursors.Default;
                        break;
                    case "cmdGridCommands":
                        Application.UseWaitCursor = false; Cursor = Cursors.Default;
                        break;
                    case "cmdResetGrid":
                        if (gridLayoutStream != null)
                        {
                            gridLayoutStream.Position = 0;
                            HookUpDataSource();
                            activityBFGridEX.LoadLayoutFile(gridLayoutStream);
                            UIHelper.GridToggleSelectMode(activityBFGridEX);
                            HookUpGridExDropDowns();
                            SetCommandsState();
                            activityBFGridEX.Refetch();
                        }
                        break;
                    case "tsReload":
                        
                        bool reapplyFilterRow = false;
                        if (activityBFGridEX.FilterMode == Janus.Windows.GridEX.FilterMode.Automatic)
                        {
                            activityBFGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                            reapplyFilterRow = true;
                        }

                        DoReload(bfOfficer);

                        if (reapplyFilterRow)
                        {
                            activityBFGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                            MessageBox.Show("In order to properly reload the data, Atrium needed to remove any filters that were applied to the grid.\n\nIf any values were applied to the grid filters, you will need to reapply them.", "Grid Filter Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "tsMoreInfo":
                        atriumDB.ActivityBFRow abr = CurrentRow();
                        if (abr != null)
                        {
                            fFile f = MainForm.OpenFile(abr.FileId);
                            f.MoreInfo("activity", abr.ActivityId);
                        }
                        break;
                    case "tsColSet":
                        if (e.Command.IsChecked)
                        {
                            activityBFGridEX.RootTable.CellLayoutMode = Janus.Windows.GridEX.CellLayoutMode.UseColumnSets;
                            cmdFieldChooser.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            tsFilter.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            cmdGroupBy.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            activityBFGridEX.AlternatingColors = true;
                        }
                        else
                        {
                            activityBFGridEX.RootTable.CellLayoutMode = Janus.Windows.GridEX.CellLayoutMode.UseColumns;
                            cmdFieldChooser.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            tsFilter.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            cmdGroupBy.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            activityBFGridEX.AlternatingColors = false;
                        }
                        break;
                    case "cmdGrdExpand":
                        pnlPreviewedDoc.Closed = e.Command.IsChecked;
                        break;
                    case "cmdGroupBy":
                        if (e.Command.IsChecked)
                        {
                            activityBFGridEX.GroupByBoxVisible = true;
                        }
                        else
                        {
                            activityBFGridEX.RootTable.Groups.Clear();
                            activityBFGridEX.GroupByBoxVisible = false;
                        }
                        break;
                    case "tsFilter":
                        if (e.Command.IsChecked)
                            activityBFGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                        {
                            activityBFGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                            ApplyGridFilter();
                        }
                        break;
                    case "cmdFieldChooser":
                        activityBFGridEX.ShowFieldChooser(this, LawMate.Properties.Resources.FieldSelector);
                        break;
                    case "tsCancel":
                        UIHelper.Cancel(activityBFBindingSource);
                        ApplyBR(true);
                        break;
                    case "tsDelete":
                        break;
                    case "tsMove":
                        DoMove();
                        break;
                    case "tsSave":
                        DoSave(false);
                        break;
                    case "tsCompleteBF":
                        DoCompleteBF();
                        SelectionCountChanged();
                        activityBFGridEX.Focus();
                        break;
                    case "tsNextSteps":
                        MainForm.LaunchNextSteps(CurrentRow().FileId, CurrentRow().ActivityId);
                        break;
                    case "tsConvert":
                        tsConvert.Expand();
                        break;

                    case "cmdMarkAsUnread":
                        DoMarkAsRead();
                        break;
                    case "cmdSend":
                        cmdSend.Expand();
                        break;
                    case "cmdReply":
                        FileManager FMReply = GetFMForMail();
                        lmWinHelper.ReplyForward(FMReply, CurrentRow().ActivityId, ConnectorType.Reply);
                        break;

                    case "cmdReplyAll":
                        FileManager FMReplyAll = GetFMForMail();
                        lmWinHelper.ReplyForward(FMReplyAll, CurrentRow().ActivityId, ConnectorType.ReplyAll);
                        break;

                    case "cmdForward":
                        FileManager FMForward = GetFMForMail();
                        lmWinHelper.ReplyForward(FMForward, CurrentRow().ActivityId, ConnectorType.Forward);
                        break;
                }
                if (e.Command.Key.StartsWith("tsConvertAC"))
                {
                    DoConvert(e.Command);
                }
            }
            catch (Exception x)
            {
                Application.UseWaitCursor = false; Cursor = Cursors.Default;
                UIHelper.HandleUIException(x);
            }
            finally { Application.UseWaitCursor = false; Cursor = Cursors.Default; }

            UpdateAsRead = true;
            Application.UseWaitCursor = false; Cursor = Cursors.Default;
        }



        private void DoMarkAsRead()
        {
            //make dict of rows
            List<DataRow> tomove = UIHelper.GridGetSelectedData(activityBFGridEX);
            foreach (atriumDB.ActivityBFRow abfr in tomove)
            {

                abfr.isRead = !abfr.isRead;// (bool)cmdMarkAsUnread.Tag;
            }

            DoSave(true);

            activityBFGridEX.UnCheckAllRecords();
            activityBFGridEX.Focus();
        }

        private FileManager GetFMForMail()
        {
            FileManager FMReply = null;
            try
            {

                FMReply = AtMng.GetFile(CurrentRow().FileId);

            }
            catch (Exception x)
            {
                if (FMReply == null)
                    FMReply = AtMng.GetFile((int)SpecialFileIds.Inbox);
                else
                    throw x;
            }
            return FMReply;
        }

        private void DoCompleteBF()
        {
            //make dict of rows
            List<DataRow> toaction = UIHelper.GridGetSelectedData(activityBFGridEX);
            if (toaction.Count == 1) //toggle if only one
            {
                foreach (atriumDB.ActivityBFRow abfr in toaction)
                {

                    if (abfr.Completed)
                    {
                        abfr.Completed = false;
                        abfr.ManuallyCompleted = false; 
                    }
                    else
                    {
                        abfr.Completed = true;
                        abfr.ManuallyCompleted = true;
                    }
                }
            }
            else if (toaction.Count > 1) // just complete all
            {
                foreach (atriumDB.ActivityBFRow abfr in toaction)
                {
                    abfr.Completed = true;
                    abfr.ManuallyCompleted = true;
                }
            }


            DoSave(false);
            activityBFGridEX.UnCheckAllRecords();

        }

        private void DoBuildConvertMenu(Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            tsConvert.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            atriumDB.ActivityBFRow abr = CurrentRow();
            ActivityConfig.ACSeriesRow acsr = AtMng.acMng.DB.ACSeries.FindByACSeriesId(abr.ACSeriesId);
            UIHelper.DoConvertMenu(abr.FileId, cmd, acsr, true);
            if (cmd.Commands.Count > 0)
            {
                if (cmd.BaseCommand != null)
                    cmd.BaseCommand.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmd.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        //private Janus.Windows.UI.CommandBars.UICommand DoBuildNextStepMenu(Janus.Windows.UI.CommandBars.UICommand cmd)
        //{
        //    atriumDB.ActivityBFRow abrBFLISTONLY = CurrentRow();

        //    //get fm
        //    FileManager fm = Atmng.GetFile(abrBFLISTONLY.FileId, false);

        //    //load activity
        //    fm.InitActivityProcess(true);

        //    //do convert
        //    atriumDB.ActivityRow ar = fm.DB.Activity.FindByActivityId(abrBFLISTONLY.ActivityId);

        //    //clear current items
        //    cmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //    cmd.Commands.Clear();

        //    //add list of next steps
        //    Dictionary<int, CurrentFlow> aps = fm.InitActivityProcess(true).Workflow.NextSteps(ar);
        //    if (aps.Count > 0)
        //    {
        //        atriumBE.CurrentFlow ap = aps[ar.ProcessId];
        //        foreach (NextStep ns in ap.NextSteps.Values)
        //        {

        //            Janus.Windows.UI.CommandBars.UICommand newCmd;
        //            //add new items
        //            string key = "tsDoNextStep" + ns.acs.ACSeriesId.ToString();
        //            if (uiCommandManager1.Commands.Contains(key))
        //            {
        //                newCmd = uiCommandManager1.Commands[key];
        //            }
        //            else
        //            {

        //                newCmd = new Janus.Windows.UI.CommandBars.UICommand();
        //                newCmd.Key =key;
        //            }
        //            newCmd.Text = Atmng.acMng.GetACSeries().GetNodeText(ns.acs, (StepType)ns.acs.StepType, false);
        //            newCmd.Tag = ns;
        //            cmd.Commands.Add(newCmd);
        //        }
        //    }
        //    if (cmd.Commands.Count > 0)
        //        cmd.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        //    if (cmd.Commands.Count == 1)
        //        return cmd.Commands[0];
        //    else
        //        return null;
        //}

        private bool IsFirstACOnThread(atriumDB.ActivityRow ar)
        {

            if (ar.ProcessRow.GetActivityRows().Length > 1 & ar.ProcessRow.GetActivityRows()[0].ActivityId != ar.ActivityId)
                return false;
            else
                return true;

        }
        private void DoConvert(Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)cmd.Tag;
            atriumDB.ActivityBFRow abrBFLISTONLY = CurrentRow();
            List<DataRow> tomove = UIHelper.GridGetSelectedData(activityBFGridEX);


            if (!acsr.SeriesRow.IsContainerFileIdNull())
            {
                FileManager fmOrig = AtMng.GetFile(abrBFLISTONLY.FileId);
                fmOrig.InitActivityProcess();
                UIHelper.MoveAcBF(acsr.SeriesRow.ContainerFileId, tomove);
                fmCurrent.GetActivityBF().Load(abrBFLISTONLY.ActivityBFId);
            }

            //get fm
            FileManager fm = AtMng.GetFile(abrBFLISTONLY.FileId);

            //load activity
            ActivityBP abp = fm.InitActivityProcess();

            //do convert
            atriumDB.ActivityRow ar = fm.DB.Activity.FindByActivityId(abrBFLISTONLY.ActivityId);
            fm.GetActivity().ConvertAC(ar, acsr);

            //complete bf
            fm.DB.ActivityBF.FindByActivityBFId(abrBFLISTONLY.ActivityBFId).Completed = true;

            //save
            try
            {
                fm.SaveAll();
                //atLogic.BusinessProcess bp = fm.GetBP();
                //bp.AddForUpdate(fm.GetProcess());
                //bp.AddForUpdate(fm.GetActivity());
                //bp.AddForUpdate(fm.GetActivityBF());
                //bp.Update();
              

                //if successful do autosteps
                //do auto steps
                abp.AutoNextStep(ar);
                  

                //update the filestructxml in a new transaction
                fm.SaveAll();
                //bp.Clear();
                //bp.AddForUpdate(fm.EFile);
                //bp.Update();

                if (acsr.AutoChain)
                    MainForm.LaunchNextSteps(abrBFLISTONLY.FileId, abrBFLISTONLY.ActivityId);

            }
            catch (Exception x)
            {
               
                fm.DB.RejectChanges();
                UIHelper.HandleUIException(x);
            }
            finally
            {
                //refresh bf list
                fmCurrent.GetActivityBF().Load(abrBFLISTONLY.ActivityBFId);
                DoBuildConvertMenu(tsConvert);

            }

        }


        private void DisplayDoc()
        {
            //if (!ucDoc1.NoDocDisplayed && ucDoc1.DocRecord != null && ucDoc1.DocRecord.DocId == SelectedBFRow.DocId)
            if (!ucDocView1.NoDocDisplayed && ucDocView1.DocRecord != null && ucDocView1.DocRecord.DocId == SelectedBFRow.DocId)
                return;  //don't redisplay the current doc as it causes the scroll bar to move

            if (LoadedDVs.ContainsKey(SelectedBFRow.DocId.ToString()))
            {
                dvDoc = LoadedDVs[SelectedBFRow.DocId.ToString()];
            }
            else
            {
                fmCurrent.GetDocMng().GetDocument().Load(SelectedBFRow.DocId);
                drDoc = (docDB.DocumentRow[])fmCurrent.GetDocMng().DB.Document.Select("DocId=" + SelectedBFRow.DocId.ToString());
                if (drDoc.Length == 1)
                {
                    dvDoc = new DataView(drDoc[0].Table, "DocId=" + drDoc[0].DocId.ToString(), "", DataViewRowState.CurrentRows);
                    LoadedDVs.Add(SelectedBFRow.DocId.ToString(), dvDoc);
                }
                else
                {
                    dvDoc = null;
                    LoadedDVs.Add(SelectedBFRow.DocId.ToString(), dvDoc);
                }
            }
            if (dvDoc != null)
            {
                //ucDoc1.Datasource = dvDoc;
                //ucDoc1.PreviewAsync();
                ucDocView1.Datasource = dvDoc;
                ucDocView1.PreviewAsync();
            }
            else
            {
                //ucDoc1.NoAssociatedDocument(LawMate.Properties.Resources.YouCantViewThisDocumentBecauseOfSecurity);
                ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.YouCantViewThisDocumentBecauseOfSecurity);
            }
        }

        bool MailWasRead = false;
        private void timerReadMail_Tick(object sender, EventArgs e)
        {
            timerReadMail.Stop();
            if( AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.ReadMailOnTimer, true))
            {
                MailWasRead = true;
            }

            /*
            if (!InEditMode)
            {
                CurrentRow().isRead = true;
                DoSave();
            }
            else
                CurrentRow().isRead = true;
             */
        }

        //private void pnlTab_SelectedPanelChanged(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        //{
        //    if (e.Panel == pnlDoc)
        //        CurrentView = ViewMode.Document;
        //    else
        //        CurrentView = ViewMode.BF;
        //}

        private void DoSave(bool ignoreConcError)
        {
            if (fmCurrent.DB.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(fmCurrent.DB);
                if (SelectedBFRow != null && MailWasRead)
                {
                    SelectedBFRow.RejectChanges();
                    activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", SelectedBFRow.ActivityBFId);
                }
            }
            else
            {
                try
                {

                    this.activityBFBindingSource.EndEdit();
                  
                    fmCurrent.SaveAll();
                    //atLogic.BusinessProcess bp = fmCurrent.GetBP();

                    //bp.AddForUpdate(fmCurrent.GetActivityBF());
                    //bp.Update();
                    //fmCurrent.AtMng.SyncBF(CurrentRow(), true);
                    ApplyBR(true);
                    //tsNumBFs.Text = fmCurrent.DB.ActivityBF.Rows.Count.ToString();
                }
                catch (Exception x)
                {
                    if (x.InnerException != null && x.InnerException.GetType() == typeof(DBConcurrencyException))
                    {
                        if (ignoreConcError)
                        {
                            DBConcurrencyException dbcx = (DBConcurrencyException)x.InnerException;
                            atriumDB.ActivityBFRow abr = (atriumDB.ActivityBFRow)dbcx.Row;
                            abr.RejectChanges();
                            fmCurrent.GetActivityBF().Load(abr.ActivityBFId);
                        }
                        else
                        {
                            UIHelper.HandleUIException(x);
                            UIHelper.Cancel(activityBFBindingSource);

                        }


                        ApplyBR(true);
                    }
                    else
                        UIHelper.HandleUIException(x);

                    if (SelectedBFRow != null && MailWasRead)
                    {
                        SelectedBFRow.RejectChanges();
                        activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", SelectedBFRow.ActivityBFId);
                    }
                }
            }

        }

        fBrowse fileBrowser;
        private void DoMove()
        {
            //get abf row
            //atriumDB.ActivityBFRow abr=CurrentRow();

            List<DataRow> tomove = UIHelper.GridGetSelectedData(activityBFGridEX);
            foreach (atriumDB.ActivityBFRow abr in tomove)
            {
                FileManager FM = AtMng.GetFile(abr.FileId);
                FM.InitActivityProcess();
                if (!FM.GetActivity().CheckMove(FM.DB.Activity.FindByActivityId(abr.ActivityId), false))
                {
                    throw new LMException("You cannot move this activity.");
                }
            }

            if (fileBrowser == null)
                fileBrowser = new fBrowse(AtMng, 0, false, false, false, true);

            fileBrowser.FindFile(CurrentRow().FileId);

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                //DialogResult result;
                //bool splitThread = false;
                //if (UIHelper.GridGetSelectedCount(activityBFGridEX) == 1)
                //{
                //    atriumDB.ActivityBFRow abr = CurrentRow();

                //    FileManager FM = Atmng.GetFile(abr.FileId, false);
                //    FM.InitActivityProcess();

                //    atriumDB.ActivityRow ar = FM.DB.Activity.FindByActivityId(abr.ActivityId);// abr.ActivityRow;
                //    atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])FM.DB.Activity.Select("Processid=" + ar.ProcessId.ToString(), "ConvIndexBase,ConversationIndex");
                //    //if (ar.ProcessRow == null)
                //    //{
                //    //    //this means we are moving a acxref
                //    //    splitThread = true;
                //    //}
                //    //else if (ars.Length > 1 & ars[0].ActivityId != ar.ActivityId)
                //    //{
                //    //    result = MessageBox.Show(LawMate.Properties.Resources.UISplitThread, LawMate.Properties.Resources.UISplitThreadCaption, MessageBoxButtons.YesNoCancel);

                //    //    if (result == DialogResult.Cancel)
                //    //        return;
                //    //    splitThread = result == DialogResult.Yes;
                //    //}
                //}

                //bool splitThread = false;
                //if (activityBFGridEX.SelectedItems.Count == 1)
                //{
                //    DialogResult dr = MessageBox.Show(LawMate.Properties.Resources.UISplitThread, LawMate.Properties.Resources.UISplitThreadCaption, MessageBoxButtons.YesNoCancel);
                //    if (dr == DialogResult.Cancel)
                //        return;
                //    else
                //        splitThread = dr == DialogResult.Yes;
                //}
                //    //splitThread = MessageBox.Show(LawMate.Properties.Resources.UISplitThread, LawMate.Properties.Resources.UISplitThreadCaption, MessageBoxButtons.YesNoCancel)== DialogResult.Yes;


                //make dict of rows

                UIHelper.MoveAcBF(fileBrowser.SelectedFile.FileId, tomove);
                //reload
                DoReload(bfOfficer);
                activityBFGridEX.UnCheckAllRecords();

            }
        }


        public void LoadCompletedItems(int bfOfficerId, DateTime StartDate, DateTime EndDate)
        {

            fmCurrent.DB.ActivityBF.Clear();
            fmCurrent.DB.ActivityBF.AcceptChanges();
            ClearLoadedDV();

            fmCurrent.GetActivityBF().LoadCompleted(bfOfficerId, StartDate, EndDate);
            tsScreenTitle.Text = String.Format(LawMate.Properties.Resources.ItemsCompletedBetweenStartDateAndEndDate, StartDate.ToString("yyyy/MM/dd"), EndDate.ToString("yyyy/MM/dd"));
            if (fmCurrent.DB.ActivityBF.Rows.Count == 0)
            {
                MessageBox.Show(LawMate.Properties.Resources.ThereWereNoCompletedBFsFoundForTheSpecifiedDateDateRange, LawMate.Properties.Resources.CompletedBFs, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
                this.BeginInvoke(new MethodInvoker(this.Close));
            }

            tsNumBFs.Text = fmCurrent.DB.ActivityBF.Rows.Count.ToString();
            ApplyGridFilter();
            activityBFGridEX.MoveFirst();
        }

        public void DoReload(officeDB.OfficerRow bfOfficer)
        {
            using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
            {
                fmCurrent.DB.ActivityBF.Clear();
                fmCurrent.DB.ActivityBF.AcceptChanges();
                toggleLoad(true);
                //Application.DoEvents();

                ClearLoadedDV();

              //  System.Threading.Thread t = new System.Threading.Thread(() => fmCurrent.GetActivityBF().LoadBF(bfOfficer.OfficeId, bfOfficer.OfficerId, calBFListRange.MaxDate, true));
              //  t.Start();

                fmCurrent.GetActivityBF().LoadBF(bfOfficer.OfficeId, bfOfficer.OfficerId, calBFListRange.MaxDate, true);
                if (fmCurrent.DB.ActivityBF.Rows.Count == 0)
                {
                    //pnlEditableFields.Closed = true;
                    SetCommandsState();
                    GridHasNoSelection();
                    SetBFListStatus();
                }
                if (fmCurrent.DB.ActivityBF.Rows.Count == -5)
                {
                    fMain mainForm = (fMain)this.ParentForm;
                    if (!mainForm.AppStartup)
                        MessageBox.Show(LawMate.Properties.Resources.YouHaveNoBFsOrMailInYourBFList, LawMate.Properties.Resources.BFList, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.BeginInvoke(new MethodInvoker(this.Close)); //does  not cause error when called during form_load
                }

                tsNumBFs.Text = fmCurrent.DB.ActivityBF.Rows.Count.ToString();
                ApplyGridFilter();
                activityBFGridEX.MoveFirst();
                toggleLoad(false);
            }
        }

        private void ClearLoadedDV()
        {
            foreach (DataView dv in LoadedDVs.Values)
            {
                dv.Dispose();
            }
            LoadedDVs.Clear();
        }

        public atriumDB.ActivityBFRow CurrentRow()
        {
            if (activityBFBindingSource.Current != null)
                return (atriumDB.ActivityBFRow)((DataRowView)activityBFBindingSource.Current).Row;
            else
                return null;
        }

        private void fBFList_KeyDown(object sender, KeyEventArgs e)
        {
            //string op = null;
            //if (e.Control && e.KeyCode == Keys.PageUp)
            //    op = "previous";

            //if (e.Control && e.KeyCode == Keys.PageDown)
            //    op = "next";

            //if (op != null)
            //{
            //    e.Handled = true;
            //    UIHelper.MoveTab(pnlTab, op);
            //}
        }

        private void CheckForComplete()
        {
            if (CurrentRow() == null)
                return;

            string cmdText = LawMate.Properties.Resources.UncompleteBF;
            string imgKey = "uncheckbox.gif";

            if (!CurrentRow().Completed)
            {
                cmdText = LawMate.Properties.Resources.CompleteBF;
                imgKey = "checkbox.gif";
            }

            //no freakin clue why the base command update does not work
            //no time for this; just set them all individually ... whatever, right?
            tsCompleteBF1.ImageKey = tsCompleteBF2.ImageKey = tsCompleteBF3.ImageKey = tsCompleteBF.ImageKey= imgKey;
            tsCompleteBF1.Text = tsCompleteBF2.Text = tsCompleteBF3.Text = tsCompleteBF.Text = cmdText;
            
        }
        private void NoRecordsDisplayed()
        {
            //ucDoc1.NoAssociatedDocument(LawMate.Properties.Resources.ThereIsNoDocument);
            ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.ThereIsNoDocument);
            foreach (Janus.Windows.UI.CommandBars.UICommand cmd in cmdActions.Commands)
            {
                cmd.BaseCommand.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }


        }
        private void RecordChanged()
        {
            try
            {
                if (activityBFBindingSource.Current == null)
                {
                    NoRecordsDisplayed();
                    return;
                }
                else if (CurrentRow() == null)
                {
                    NoRecordsDisplayed();
                    return;
                }
                //else if (SelectedBFRow != null && SelectedBFRow.RowState != DataRowState.Detached && CurrentRow().ActivityBFId == SelectedBFRow.ActivityBFId)
                //    return;

                if (!isViewingCompletedItems)
                {
                    foreach (Janus.Windows.UI.CommandBars.UICommand cmd in cmdActions.Commands)
                    {
                        cmd.BaseCommand.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    }
                }

                if (SelectedBFRow != null && SelectedBFRow.RowState != DataRowState.Detached && CurrentRow().ActivityBFId != SelectedBFRow.ActivityBFId)
                {
                    try
                    {
                        if (UpdateAsRead && MailWasRead && SelectedBFRow.RowState != DataRowState.Detached && !SelectedBFRow.isRead)
                        {
                            SelectedBFRow.isRead = true;
                           
                            DoSave(true);
                            activityBFGridEX.Focus();
                        }
                    }
                    catch (Exception xi)
                    {
                        
                        UIHelper.LogError(xi);
                    }
                }
                if (activityBFBindingSource.Current != null)
                {
                    uiCommandBar1.Enabled = true;

                    if (activityBFGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record && activityBFGridEX.CurrentRow.Cells["CanAccessFile"].Text == "" && activityBFGridEX.CurrentRow.DataRow != null)
                    {
                        //e.Row.BeginEdit();
                        if (AtMng.SecurityManager.CanRead(Convert.ToInt32(activityBFGridEX.CurrentRow.Cells["FileId"].Text), atSecurity.SecurityManager.Features.Efile) > atSecurity.SecurityManager.LevelPermissions.No)
                            activityBFGridEX.CurrentRow.Cells["CanAccessFile"].Text = "true";
                        else
                            activityBFGridEX.CurrentRow.Cells["CanAccessFile"].Text = "false";
                        //e.Row.EndEdit();
                    }

                    //if (Atmng.SecurityManager.CanRead(CurrentRow().FileId, atSecurity.SecurityManager.Features.Efile) > atSecurity.SecurityManager.LevelPermissions.No)
                    if (activityBFGridEX.CurrentRow.Cells["CanAccessFile"].Text == "true")
                    {
                        DoBuildConvertMenu(tsConvert);
                        tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        tsMove2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        tsMoreInfo2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        //DoBuildNextStepMenu(tsNextSteps);
                    }
                    else
                    {
                        tsConvert.Commands.Clear();
                        tsConvert.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        tsMove2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        tsMoreInfo2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        //tsNextSteps.Commands.Clear();
                    }
                    MailWasRead = false;
                    CheckForComplete();

                    if (CurrentRow() != SelectedBFRow && !CurrentRow().isRead && fmCurrent.GetActivityBF().IsDirect( CurrentRow()))
                    {
                        timerReadMail.Start();
                    }

                    SelectedBFRow = CurrentRow();
                    if (SelectedBFRow.Communication)
                    {
                        cmdReply.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        cmdReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    }
                    else
                    {
                        cmdReply.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        cmdReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    }


                    if (CurrentRow().IsBFOfficerIDNull())
                        tbTo.Text = activityBFGridEX.CurrentRow.Cells["RoleCode"].Text;
                    else
                        tbTo.Text = activityBFGridEX.CurrentRow.Cells["BFOfficerID"].Text;

                    if (CurrentRow().BFType == 1)
                        tbTo.Image = imgListBFType.Images[16];
                    else if (CurrentRow().BFType == 2)
                        tbTo.Image = imgListBFType.Images[15];
                    else if (CurrentRow().BFType == 7)
                        tbTo.Image = imgListBFType.Images[14];
                    else if (CurrentRow().BFType == 8)
                        tbTo.Image = imgListBFType.Images[17];
                    else
                        tbTo.Image = null;

                    if (CurrentRow().isMail)
                        lblMailIcon.Image = imgListBFType.Images[0];
                    else
                        lblMailIcon.Image = imgListBFType.Images[6];

                    if (!SelectedBFRow.IsDocIdNull())
                        DisplayDoc();
                    else
                    {
                        //ucDoc1.NoAssociatedDocument(LawMate.Properties.Resources.ThereIsNoDocument);
                        ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.ThereIsNoDocument);
                    }

                    //from selection changed
                    SelectionCountChanged();

                }
                else
                {
                    uiCommandBar1.Enabled = false;
                    //ucDoc1.Clear();
                    ucDocView1.Clear();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void SelectionCountChanged()
        {


            tsCompleteBF.ImageKey = "checkbox.gif";
            tsCompleteBF.Enabled = Janus.Windows.UI.InheritableBoolean.True;

            if (UIHelper.GridGetSelectedCount(activityBFGridEX) > 1)
            {
                tsCompleteBF.Text = tsCompleteBF1.Text = tsCompleteBF2.Text = tsCompleteBF3.Text = LawMate.Properties.Resources.CompleteBFsAllSelected;
                tsCompleteBF.ImageKey = tsCompleteBF1.ImageKey= tsCompleteBF2.ImageKey = tsCompleteBF3.ImageKey = "checkbox.gif";
                tsCompleteBF.Enabled = tsCompleteBF1.Enabled = tsCompleteBF2.Enabled = tsCompleteBF3.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                if (activityBFGridEX.CurrentRow.Cells["CanAccessFile"].Text == "true")
                    tsMove2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsMove2.Text = LawMate.Properties.Resources.MoveActivitiesAllSelected;

                cmdReply.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                tsMoreInfo2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsConvert.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdMarkAsUnread.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            if (UIHelper.GridGetSelectedCount(activityBFGridEX) == 1)
            {
                // if (activityBFGridEX.CurrentRow.Cells["CanAccessFile"].Text == "true")
                //     tsMove2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsMove2.Text = LawMate.Properties.Resources.UISplitThreadCaption;
                tsCompleteBF.Text = LawMate.Properties.Resources.CompleteBF;
                tsCompleteBF.ImageKey = "checkbox.gif";
                tsCompleteBF.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                if (activityBFGridEX.CurrentRow.Cells["CanAccessFile"].Text == "true")
                    tsMove2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsMove2.Text = LawMate.Properties.Resources.UISplitThreadCaption;
            }


            if (UIHelper.GridGetSelectedCount(activityBFGridEX) == 0)
            {

                tsMove2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsCompleteBF.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //tsCompleteBF.Text = LawMate.Properties.Resources.CompleteBF;
                tsMove2.Text = LawMate.Properties.Resources.UISplitThreadCaption;
            }
        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            try
            {

                atriumDB.ActivityBFRow abr = CurrentRow();
                if (abr == null || activityBFGridEX.HitTest() != Janus.Windows.GridEX.GridArea.Cell && activityBFGridEX.HitTest() != Janus.Windows.GridEX.GridArea.PreviewRow)
                {
                    uiContextMenu1.Close();
                    return;
                }

                if (fmCurrent.GetActivityBF().IsDirect( abr))
                {
                    cmdMarkAsUnread.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                    // cmd tag contains value to set to bftype if cmdMarkAsUnread is clicked
                    if (abr.isRead)
                    {
                        cmdMarkAsUnread.Text = LawMate.Properties.Resources.UIMailMarkAsUnread;
                        cmdMarkAsUnread.Tag = false;
                    }
                    else
                    {
                        cmdMarkAsUnread.Text = LawMate.Properties.Resources.UIMailMarkAsRead;
                        cmdMarkAsUnread.Tag = true;
                    }
                }
                else
                    cmdMarkAsUnread.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                //DoBuildConvertMenu(tsConvert);
                //DoBuildNextStepMenu(tsNextSteps);

            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CommandPopup(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //switch (e.Command.Key)
            //{
            //    case "tsConvert":
            //        DoBuildConvertMenu(e.Command);
            //        break;
            //    case "tsNextSteps":
            //        DoBuildNextStepMenu(e.Command);
            //        break;
            //}
        }

        private void cbMailFilter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyGridFilter();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_RowDrag(object sender, Janus.Windows.GridEX.RowDragEventArgs e)
        {
            try
            {
                DragDropEffects d = activityBFGridEX.DoDragDrop(UIHelper.GridGetSelectedData(activityBFGridEX), DragDropEffects.Move);
                if (d == DragDropEffects.Move)
                    activityBFGridEX.UnCheckAllRecords();
            }
            catch (LMException lx)
            {
                //ignore
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }


        private void activityBFGridEX_SelectionChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(activityBFGridEX.CurrentRow.RowType);
            if (activityBFGridEX.CurrentRow == null)
            {
                NoRecordsDisplayed();
                return;
            }
            if (activityBFGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.FilterRow)
                return;
            else
            {
                RecordChanged();
            }

        }

        private void activityBFGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                //Moved to LoadingRow event to allow value to be set - otherwise sort doesnt work
                //if (e.Row.Cells["BFOfficerID"].Text == "")
                //    e.Row.Cells["To"].Text = e.Row.Cells["RoleCode"].Text;
                //else
                //    e.Row.Cells["To"].Text = e.Row.Cells["BFOfficerID"].Text;

                //bold row if un-read and "direct" bf
                
                lmWinHelper.FormatGridRowBFIsUnread(fmCurrent, e.Row);
                
                //lmDatasets.atriumDB.ActivityBFRow abr =(lmDatasets.atriumDB.ActivityBFRow)((DataRowView) e.Row.DataRow).Row;
                //if (fmCurrent.GetActivityBF().IsDirect(abr) && !abr.isRead)
                //{
                //    Janus.Windows.GridEX.GridEXFormatStyle fmt = new Janus.Windows.GridEX.GridEXFormatStyle();
                //    fmt.FontBold = Janus.Windows.GridEX.TriState.True;
                //    e.Row.RowStyle = fmt;
                //}

                //format date differently if bf is not mail - i.e. remove time.
                lmWinHelper.FormatGridRowBFDate(fmCurrent, e.Row);


                //if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record && e.Row.Cells["CanAccessFile"].Text == "" && e.Row.DataRow != null)
                //{
                //    //e.Row.BeginEdit();
                //    if (Atmng.SecurityManager.CanRead(Convert.ToInt32(e.Row.Cells["FileId"].Text), atSecurity.SecurityManager.Features.Efile) > atSecurity.SecurityManager.LevelPermissions.No)
                //        e.Row.Cells["CanAccessFile"].Text = "true";
                //    else
                //        e.Row.Cells["CanAccessFile"].Text = "false";
                //    //e.Row.EndEdit();
                //}

            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine(x.Message);
            }

        }

        private void bFCommentTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.TextBoxTextCounter(bFCommentEditBox, BFCommentCounter, 255);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_SortKeysChanged(object sender, EventArgs e)
        {
            try
            {
                if (activityBFGridEX.RootTable.SortKeys.Count == 1 && activityBFGridEX.RootTable.SortKeys[0].Column.Key == "BFDate")
                    activityBFGridEX.RootTable.SortKeys.Add(new Janus.Windows.GridEX.GridEXSortKey(activityBFGridEX.RootTable.Columns["entryDate"], activityBFGridEX.RootTable.Columns["BFDate"].SortOrder));
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        Stream gridLayoutStream = new MemoryStream();
        private void fBFList_Load(object sender, EventArgs e)
        {
            try
            {
                activityBFGridEX.SaveLayoutFile(gridLayoutStream); //for resetting purposes
                HookUpDataSource();
                if (!isViewingCompletedItems)
                {
                    lmWinHelper.LoadGridLayout(activityBFGridEX, "BFListGridLayout", LayoutVersionNumber);    
                    lmWinHelper.LoadCommandManagerLayout(uiCommandManager1, "BFListCommandManager", LayoutVersionNumber);
                    lmWinHelper.LoadPanelManagerLayout(uiPanelManager1, "BFListPanelManager_" + LayoutVersionNumber);
                }
                else
                {
                    lmWinHelper.LoadGridLayout(activityBFGridEX, "CompletedBFsGridLayout", LayoutVersionNumber);
                    lmWinHelper.LoadPanelManagerLayout(uiPanelManager1, "CompletedBFsPanelManager");
                    activityBFGridEX.RootTable.Columns["Column1"].Visible = false;
                }

                HookUpGridExDropDowns();
                SetCommandsState();
                activityBFGridEX.Refetch();
                activityBFGridEX.Focus();
                activityBFGridEX.MoveFirst();
                activityBFGridEX.RemoveFilters();
                SelectedBFRow = null;
                RecordChanged();
                if (activityBFGridEX.RowCount == 0)
                    GridHasNoSelection();


            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        int allBFs;
        private void timrefresh_Tick(object sender, EventArgs e)
        {
            try
            {
                timrefresh.Stop();
                allBFs = fmCurrent.DB.ActivityBF.Rows.Count; 
                backgroundWorker1.RunWorkerAsync();
                //int allBFs = fmCurrent.DB.ActivityBF.Rows.Count;

                ////int newMail = fmCurrent.DB.ActivityBF.Select("isRead=False and isMail=True").Length;

                //int newMail= fmCurrent.GetActivityBF().LoadBF(bfOfficer.OfficeId, bfOfficer.OfficerId, calBFListRange.MaxDate, false);
                ////newMail = fmCurrent.DB.ActivityBF.Select("isRead=False and isMail=True").Length - newMail;
                //if (newMail > 0)
                //{
                //    //notify user
                //    fNotify f = new fNotify(this, newMail);
                //    //f.BFlist = this;
                //    //f.Show();
                //}

                //if ((allBFs - fmCurrent.DB.ActivityBF.Rows.Count) != 0)
                //{
                //    tsNumBFs.Text = fmCurrent.DB.ActivityBF.Rows.Count.ToString();
                //    ApplyGridFilter();
                //}
                //refreshTimerFailCounter = 0;
            }
            catch (Exception x)
            {
                //refreshTimerFailCounter++;
                //if (refreshTimerFailCounter > 5)
                //{
                //    timrefresh.Stop();
                    UIHelper.HandleUIException(x);
                //}
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
         
            

            int newMail = fmCurrent.GetActivityBF().LoadBF(bfOfficer.OfficeId, bfOfficer.OfficerId, calBFListRange.MaxDate, false);
            e.Result = newMail;
          
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                timrefresh.Start();
                if (e.Error != null)
                    throw e.Error;

                int newMail = (int)e.Result;
                if (newMail > 0 && AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.BFShowNotify, false))
                {
                    //notify user
                    fNotify f = new fNotify(this, newMail);
                }

                if ((allBFs - fmCurrent.DB.ActivityBF.Rows.Count) != 0)
                {
                    tsNumBFs.Text = fmCurrent.DB.ActivityBF.Rows.Count.ToString();
                    ApplyGridFilter();
                }
                refreshTimerFailCounter = 0;
              
            }
            catch (Exception x)
            {
                   refreshTimerFailCounter++;
                 if (refreshTimerFailCounter > 5)
                 {
                     timrefresh.Stop();
                 }
                    UIHelper.HandleUIException(x);
            }
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

        private void calBFListRange_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyGridFilter();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                lmWinHelper.FormatGridRowBFOfficer(e.Row);
                lmWinHelper.FormatGridRowBFDateLoading(e.Row);

                if (e.Row.DataRow != null)
                {
                    atriumDB.ActivityBFRow abf = (atriumDB.ActivityBFRow)((DataRowView)e.Row.DataRow).Row;
                    if (!abf.IsReceivedTimeNull())
                    {
                        e.Row.Cells["ReceivedTime"].Value = abf.ReceivedTime.ToLocalTime();
                    }
                }
            }
            catch (Exception x)
            {
               // UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {

                    atriumDB.ActivityBFRow abr = CurrentRow();
                    MailWasRead = true;
                    fFile f = MainForm.OpenFile(abr.FileId);
                    f.MoreInfo("activity", abr.ActivityId);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(activityBFGridEX);
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

        private void fBFList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (InEditMode)
                {
                    DialogResult dialogResult = MessageBox.Show(LawMate.Properties.Resources.MadeChangesWithoutSavingSaveYourChangesBeforeClosing, LawMate.Properties.Resources.SaveChanges, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        DoSave(false);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                        UIHelper.Cancel(activityBFBindingSource);
                        ApplyBR(true);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }

                if (!e.Cancel)
                {
                    if (!isViewingCompletedItems)
                    {
                        lmWinHelper.SaveGridLayout(activityBFGridEX, "BFListGridLayout", fmCurrent.AtMng, LayoutVersionNumber);
                        lmWinHelper.SaveCommandManagerLayout(uiCommandManager1, "BFListCommandManager", fmCurrent.AtMng, LayoutVersionNumber);
                        lmWinHelper.SavePanelManagerLayout(uiPanelManager1, "BFListPanelManager_" + LayoutVersionNumber, fmCurrent.AtMng);
                    }
                    else
                    {
                        lmWinHelper.SaveGridLayout(activityBFGridEX, "CompletedBFsGridLayout", fmCurrent.AtMng, LayoutVersionNumber);
                        lmWinHelper.SavePanelManagerLayout(uiPanelManager1, "CompletedBFsPanelManager", fmCurrent.AtMng);
                    }
                    MainForm.ClearBFListStatus();

                    ClearLoadedDV();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fBFList_Activated(object sender, EventArgs e)
        {
            try
            {
                ApplyGridFilter();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fBFList_Deactivate(object sender, EventArgs e)
        {
            try
            {
                MainForm.ClearBFListStatus();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                { e.Cancel = true; }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandBar1_Resize(object sender, EventArgs e)
        {
            try
            {
                uiCommandBar1.Location = new Point(0, uiCommandBar1.Top);
                if (uiCommandBar2.Visible)
                    uiCommandBar2.Location = new Point(1, uiCommandBar1.Top);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_RowCheckStateChanged(object sender, Janus.Windows.GridEX.RowCheckStateChangeEventArgs e)
        {
            try
            {
                SelectionCountChanged();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_FilterApplied(object sender, EventArgs e)
        {
            try
            {
                if (activityBFGridEX.RowCount == 0)
                    GridHasNoSelection();
                else
                {
                    GridHasSelection();
                    highlightCurrentRowInGrid();
                }
                SetBFListStatus();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_ClearFilterButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                highlightCurrentRowInGrid();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void highlightCurrentRowInGrid()
        {
            if (CurrentRow() == null)
                return;

            //bool found = activityBFGridEX.Find(activityBFGridEX.RootTable.Columns["ActivityBFId"], Janus.Windows.GridEX.ConditionOperator.Equal, CurrentRow().ActivityBFId, 0, 1);
            //if (!found)
            if (activityBFBindingSource.Find("ActivityBFId", CurrentRow().ActivityBFId) < 0)
                activityBFGridEX.MoveFirst();
        }

      

  
    }
}

