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
    public partial class fPreferences : fBase
    {
        OfficerPrefsBE prefBE;
        atriumManager myAtmng;
        DataTable dtSearchOnListVisible;
        DataTable dtSearchOnListHidden;
        officeDB.OfficerRow officerRow;
        
        bool calEditMode = false;

        public fPreferences()
        {
            InitializeComponent();
        }

        public fPreferences(atriumManager Atmng)
        {
            InitializeComponent();
            myAtmng = Atmng;
            LoadLabels();
            prefBE = myAtmng.OfficeMng.GetOfficerPrefs();
            officerRow = myAtmng.OfficeMng.GetOfficer().Load(myAtmng.OfficerLoggedOn.OfficerId);
            CheckPrefs();
        }

        private void LoadLabels()
        {
            uiGroupBox7.Text = String.Format(LawMate.Properties.Resources.AppCommunications, myAtmng.AppMan.AppName);
            //chckReceiveLawMailInOutlook.Text = String.Format(LawMate.Properties.Resources.AppMailReceived, myAtmng.AppMan.AppMailName);
            label9.Text = String.Format(LawMate.Properties.Resources.AppMailSettingReadOnly, myAtmng.AppMan.AppName);
        }

        private void SearchOnOptions()
        {

            dtSearchOnListVisible = new DataTable();
            dtSearchOnListVisible.Columns.Add("value", System.Type.GetType("System.String"));
            dtSearchOnListVisible.Columns.Add("text", System.Type.GetType("System.String"));
            dtSearchOnListVisible.Columns.Add("order", System.Type.GetType("System.Int32"));
            dtSearchOnListVisible.Columns.Add("image", System.Type.GetType("System.Int32"));

            dtSearchOnListHidden = new DataTable();
            dtSearchOnListHidden.Columns.Add("value", System.Type.GetType("System.String"));
            dtSearchOnListHidden.Columns.Add("text", System.Type.GetType("System.String"));
            dtSearchOnListHidden.Columns.Add("order", System.Type.GetType("System.Int32"));
            dtSearchOnListHidden.Columns.Add("image", System.Type.GetType("System.Int32"));

            if(prefBE.GetPref(OfficerPrefsBE.qsOpnBool, 1)>0)
                dtSearchOnListVisible.Rows.Add("qsOpnBool", LawMate.Properties.Resources.QuickSearchOpinionBooleanSearch, prefBE.GetPref(OfficerPrefsBE.qsOpnBool, 1), 0);
            else
                dtSearchOnListHidden.Rows.Add("qsOpnBool", LawMate.Properties.Resources.QuickSearchOpinionBooleanSearch, prefBE.GetPref(OfficerPrefsBE.qsOpnBool, 1), 0);

            if (prefBE.GetPref(OfficerPrefsBE.qsOpnFullText, 2) > 0)
                dtSearchOnListVisible.Rows.Add("qsOpnFullText", LawMate.Properties.Resources.QuickSearchFullTextOfOpinions, prefBE.GetPref(OfficerPrefsBE.qsOpnFullText, 2), 0);
            else
                dtSearchOnListHidden.Rows.Add("qsOpnFullText", LawMate.Properties.Resources.QuickSearchFullTextOfOpinions, prefBE.GetPref(OfficerPrefsBE.qsOpnFullText, 2), 0);
            
            if (prefBE.GetPref(OfficerPrefsBE.qsOpnSubj, 3) >0)
                dtSearchOnListVisible.Rows.Add("qsOpnSubj", LawMate.Properties.Resources.QuickSearchOpinionSubjectDescription, prefBE.GetPref(OfficerPrefsBE.qsOpnSubj, 3), 0);
            else
                dtSearchOnListHidden.Rows.Add("qsOpnSubj", LawMate.Properties.Resources.QuickSearchOpinionSubjectDescription, prefBE.GetPref(OfficerPrefsBE.qsOpnSubj, 3), 0);
            
            if (prefBE.GetPref(OfficerPrefsBE.qsDocBool, 4) >0)
                dtSearchOnListVisible.Rows.Add("qsDocBool", LawMate.Properties.Resources.BooleanSearch, prefBE.GetPref(OfficerPrefsBE.qsDocBool, 4), 1);
            else
                dtSearchOnListHidden.Rows.Add("qsDocBool", LawMate.Properties.Resources.BooleanSearch, prefBE.GetPref(OfficerPrefsBE.qsDocBool, 4), 1);

            if (prefBE.GetPref(OfficerPrefsBE.qsDocFullText, 5) >0)
                dtSearchOnListVisible.Rows.Add("qsDocFullText", LawMate.Properties.Resources.QuickSearchFullText, prefBE.GetPref(OfficerPrefsBE.qsDocFullText, 5), 1);
            else
                dtSearchOnListHidden.Rows.Add("qsDocFullText", LawMate.Properties.Resources.QuickSearchFullText, prefBE.GetPref(OfficerPrefsBE.qsDocFullText, 5), 1);
            
            if (prefBE.GetPref(OfficerPrefsBE.qsDocSubj, 6) >0)
                dtSearchOnListVisible.Rows.Add("qsDocSubj", LawMate.Properties.Resources.QuickSearchSubject, prefBE.GetPref(OfficerPrefsBE.qsDocSubj, 6), 1);
            else
                dtSearchOnListHidden.Rows.Add("qsDocSubj", LawMate.Properties.Resources.QuickSearchSubject, prefBE.GetPref(OfficerPrefsBE.qsDocSubj, 6), 1);
            
            if (prefBE.GetPref(OfficerPrefsBE.qsFileNameEng, 7) >0)
                dtSearchOnListVisible.Rows.Add("qsFileNameEng", LawMate.Properties.Resources.AdvSearchFileNameEnglish, prefBE.GetPref(OfficerPrefsBE.qsFileNameEng, 7), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsFileNameEng", LawMate.Properties.Resources.AdvSearchFileNameEnglish, prefBE.GetPref(OfficerPrefsBE.qsFileNameEng, 7), 2);

            if (prefBE.GetPref(OfficerPrefsBE.qsFileNameFre, 8) >0)
                dtSearchOnListVisible.Rows.Add("qsFileNameFre", LawMate.Properties.Resources.AdvSearchFileNameFrench, prefBE.GetPref(OfficerPrefsBE.qsFileNameFre, 8), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsFileNameFre", LawMate.Properties.Resources.AdvSearchFileNameFrench, prefBE.GetPref(OfficerPrefsBE.qsFileNameFre, 8), 2);

            if (prefBE.GetPref(OfficerPrefsBE.qsFullFileName, 9) >0)
                dtSearchOnListVisible.Rows.Add("qsFullFileName", LawMate.Properties.Resources.QuickSearchFullFileName, prefBE.GetPref(OfficerPrefsBE.qsFullFileName, 9), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsFullFileName", LawMate.Properties.Resources.QuickSearchFullFileName, prefBE.GetPref(OfficerPrefsBE.qsFullFileName, 9), 2);

            if (prefBE.GetPref(OfficerPrefsBE.qsFileNumber, 10) >0)
                dtSearchOnListVisible.Rows.Add("qsFileNumber", LawMate.Properties.Resources.QuickSearchFileNumber, prefBE.GetPref(OfficerPrefsBE.qsFileNumber, 10), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsFileNumber", LawMate.Properties.Resources.QuickSearchFileNumber, prefBE.GetPref(OfficerPrefsBE.qsFileNumber, 10), 2);
            
            if (prefBE.GetPref(OfficerPrefsBE.qsFullFileNumber, 11) >0)
                dtSearchOnListVisible.Rows.Add("qsFullFileNumber", LawMate.Properties.Resources.QuickSearchFullFileNumber, prefBE.GetPref(OfficerPrefsBE.qsFullFileNumber, 11), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsFullFileNumber", LawMate.Properties.Resources.QuickSearchFullFileNumber, prefBE.GetPref(OfficerPrefsBE.qsFullFileNumber, 11), 2);

            if (prefBE.GetPref(OfficerPrefsBE.qsiCaseFileNumber, 12) > 0)
                dtSearchOnListVisible.Rows.Add("qsiCaseFileNumber", LawMate.Properties.Resources.QuickSearchIcase, prefBE.GetPref(OfficerPrefsBE.qsiCaseFileNumber, 12), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsiCaseFileNumber", LawMate.Properties.Resources.QuickSearchIcase, prefBE.GetPref(OfficerPrefsBE.qsiCaseFileNumber, 12), 2);

            if (prefBE.GetPref(OfficerPrefsBE.qsSIN, 13) > 0)
                dtSearchOnListVisible.Rows.Add("qsSIN", LawMate.Properties.Resources.QuickSearchSIN, prefBE.GetPref(OfficerPrefsBE.qsSIN, 13), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsSIN", LawMate.Properties.Resources.QuickSearchSIN, prefBE.GetPref(OfficerPrefsBE.qsSIN, 13), 2);

            if (prefBE.GetPref(OfficerPrefsBE.qsLastName, 14) > 0)
                dtSearchOnListVisible.Rows.Add("qsLastName", LawMate.Properties.Resources.QuickSearchLastName, prefBE.GetPref(OfficerPrefsBE.qsLastName, 14), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsLastName", LawMate.Properties.Resources.QuickSearchLastName, prefBE.GetPref(OfficerPrefsBE.qsLastName, 14), 2);

            if (prefBE.GetPref(OfficerPrefsBE.qsOfficeFileNumber, 15) > 0)
                dtSearchOnListVisible.Rows.Add("qsOfficeFileNumber", LawMate.Properties.Resources.QuickSearchOfficeFileNumber, prefBE.GetPref(OfficerPrefsBE.qsOfficeFileNumber, 15), 2);
            else
                dtSearchOnListHidden.Rows.Add("qsOfficeFileNumber", LawMate.Properties.Resources.QuickSearchOfficeFileNumber, prefBE.GetPref(OfficerPrefsBE.qsOfficeFileNumber, 15), 2);

            

            cbDefaultSearchOn.DataSource = dtSearchOnListVisible;
            cbDefaultSearchOn.DisplayMember = "text";
            cbDefaultSearchOn.ValueMember = "value";
            BindingContext dummy = cbDefaultSearchOn.BindingContext; // without this line, the items collection is not populated yet on cbdefaultsearchon combobox - this forces the update to the collection;

            if (!prefBE.GetPref(OfficerPrefsBE.RememberSearchOnSelection, true))
                cbDefaultSearchOn.SelectedItem = cbDefaultSearchOn.Items[(object)prefBE.GetPref(OfficerPrefsBE.SearchOnDefault, "OpnBoolean")];

            gridexDisplayed.DataSource = dtSearchOnListVisible;
            gridexHidden.DataSource = dtSearchOnListHidden;

        }

        private void SaveSearchOnOptions()
        {
            foreach (DataRow dr in dtSearchOnListVisible.Rows)
            {
                prefBE.SetPref(dr["value"].ToString(), (int)dr["order"]);
            }
            foreach (DataRow dr in dtSearchOnListHidden.Rows)
            {
                prefBE.SetPref(dr["value"].ToString(), (int)dr["order"]);
            }
        }

        private void CheckPrefs()
        {
            //Language - stored in registry, not DB
            if (UIHelper.GetSetting("UserLanguage") == "")
            {
                rbEng.Checked = true;
                UIHelper.SaveSetting("UserLanguage", "ENG");
            }
            else
            {
                if ((UIHelper.GetSetting("UserLanguage")) == "ENG")
                    rbEng.Checked = true;
                else
                    rbFre.Checked = true;
            }

            tbBFDays.Value = prefBE.GetPref(OfficerPrefsBE.BFDaysAhead, 0);
            
            //Grid selection mode
            if (prefBE.GetPref(OfficerPrefsBE.GridSelectionMode, OfficerPrefsBE.vGridSelectionModeMulti) == OfficerPrefsBE.vGridSelectionModeCheckbox)
                rbCheck.Checked = true;
            else
                rbMulti.Checked = true;

            // peter Load EnableReminders
            if (prefBE.GetPref(OfficerPrefsBE.EnableReminders, true))
                chkReminders.Checked = true;
            else
                chkReminders.Checked = false;

            if (prefBE.GetPref(OfficerPrefsBE.FastDataEntry, false))
                chkFastdataEntry.Checked = true;
            else
                chkFastdataEntry.Checked = false;

            if (prefBE.GetPref(OfficerPrefsBE.BFShowNotify, false))
                chkBFNotify.Checked = true;
            else
                chkBFNotify.Checked = false;

            //load bflist on startup
            if (prefBE.GetPref(OfficerPrefsBE.LoadBFListOnStartup, true))
                cbLoadBFList.Checked = true;
            else
                cbLoadBFList.Checked = false;

            //load calendar on startup
            if (prefBE.GetPref(OfficerPrefsBE.LoadCalendarOnStartup, true))
                chkLoadCal.Checked = true;
            else
                chkLoadCal.Checked = false;

            chkBFTimer.Checked = prefBE.GetPref(OfficerPrefsBE.ReadMailOnTimer, true);

            //auto hide toolkit
            if (prefBE.GetPref(OfficerPrefsBE.AutoHideOfficerToolkitOnStartup, true))
                chkAutoHideToolkit.Checked = true;
            else
                chkAutoHideToolkit.Checked = false;

            //load personal file on startup
            if (prefBE.GetPref(OfficerPrefsBE.LoadPersonalFileOnStartup, true))
                chkLoadPF.Checked = true;
            else
                chkLoadPF.Checked = false;

            //Remember Search On Selection
            if (prefBE.GetPref(OfficerPrefsBE.RememberSearchOnSelection, true))
                cbRememberSearchOn.Checked = true;
            else
                cbRememberSearchOn.Checked = false;

            //OT Hide BF List
            if (prefBE.GetPref(OfficerPrefsBE.OfficerTKHideBF, false))
                chkOTBFList.Checked = true;
            else
                chkOTBFList.Checked = false;

            //OT Hide Emails/Docs
            if (prefBE.GetPref(OfficerPrefsBE.OfficerTKHideDocs, false))
                chkOTEmailsDocs.Checked = true;
            else
                chkOTEmailsDocs.Checked = false;

            //OT Hide Files
            if (prefBE.GetPref(OfficerPrefsBE.OfficerTKHideFiles, false))
                chkOTFiles.Checked = true;
            else
                chkOTFiles.Checked = false;

            //OT Hide Address Book
            if (prefBE.GetPref(OfficerPrefsBE.OfficerTKHideAddBook, false))
                chkOTAddressBook.Checked = true;
            else
                chkOTAddressBook.Checked = false;

            //OT Hide Calendar
            if (prefBE.GetPref(OfficerPrefsBE.OfficerTKHideCalendar, false))
                chkOTCalendar.Checked = true;
            else
                chkOTCalendar.Checked = false;

            //OT Hide Personal File
            if (prefBE.GetPref(OfficerPrefsBE.OfficerTKHidePersonalFile, false))
                chkOTPersonalFile.Checked = true;
            else
                chkOTPersonalFile.Checked = false;

            //OT Hide 
            if (prefBE.GetPref(OfficerPrefsBE.OfficerTKHideMyOffice, false))
                chkOTOfficeFile.Checked = true;
            else
                chkOTOfficeFile.Checked = false;

            //Receive LawMate in Outlook
            //if (myAtmng.OfficerLoggedOn.IsMail)
            //    chckReceiveLawMailInOutlook.Checked = false;
            //else
            //    chckReceiveLawMailInOutlook.Checked = true;

            //Auto Creation of Timeslip for Every Activity
            if (prefBE.GetPref(OfficerPrefsBE.TimeslipForEveryActivity, false))
                chkAutoTimeslip.Checked = true;
            else
                chkAutoTimeslip.Checked = false;

            //Create REVISE DOC activity when checking in a document
            if (prefBE.GetPref(OfficerPrefsBE.ReviseDocOnDocCheckIn, false))
                chkDocCheckInReviseDocAct.Checked = true;
            else
                chkDocCheckInReviseDocAct.Checked = false;

            //Always Display Draft Doc Message
            if (prefBE.GetPref(OfficerPrefsBE.AlwaysDisplayDraftDocMessage, true))
                chkAlwaysShowDraftMessage.Checked = true;
            else
                chkAlwaysShowDraftMessage.Checked = false;

            if (prefBE.GetPref(OfficerPrefsBE.PromptMetaData, true))
                chkMeta.Checked = true;
            else
                chkMeta.Checked = false;

            //Prompt on AppClose
            if (prefBE.GetPref(OfficerPrefsBE.PromptOnClose, true))
                chkConfirmOnClose.Checked = true;
            else
                chkConfirmOnClose.Checked = false;
            
            

            //Check Out Of Office
            if (myAtmng.GetSetting(AppBoolSetting.useOutOfOfficeFunctionality))
            {
                if (officerRow.OutOfOffice)
                {
                    if (officerRow.OutOfOfficeEndDate.DateTime < DateTime.Now)
                    {
                        chkOutOfOffice.Checked = false;
                    }
                    else
                    {
                        chkOutOfOffice.Checked = officerRow.OutOfOffice;
                    }
                }
            }
            else
            {
                chkOutOfOffice.Checked = false;
                uiGroupBox12.Text = Properties.Resources.OutOfOfficeDisabledMessage;
                uiGroupBox12.Enabled = false;
            }

            //chkOutOfOffice.Checked = officerRow.OutOfOffice;
            calEditMode = true;
            if (chkOutOfOffice.Checked)
            {
                startDateCalendarCombo.Value = officerRow.OutOfOfficeStartDateLocal.AddHours(-officerRow.OutOfOfficeStartDateLocal.Hour);
                startDateCalendarCombo.Value = startDateCalendarCombo.Value.AddMinutes(-officerRow.OutOfOfficeStartDateLocal.Minute);
                startTimeCalendarCombo.Value = officerRow.OutOfOfficeStartDateLocal;
                endDateCalendarCombo.Value = officerRow.OutOfOfficeEndDateLocal.AddHours(-officerRow.OutOfOfficeEndDateLocal.Hour);
                endDateCalendarCombo.Value = endDateCalendarCombo.Value.AddMinutes(-officerRow.OutOfOfficeEndDateLocal.Minute);
                endTimeCalendarCombo.Value = officerRow.OutOfOfficeEndDateLocal;
            }
            else
            {
                startTimeCalendarCombo.Value = startTimeCalendarCombo.Value.AddHours(DateTime.Now.Hour);
                endTimeCalendarCombo.Value = endTimeCalendarCombo.Value.AddHours(DateTime.Now.Hour + 1);
            }
            calEditMode = false;
            EnableDates();

            SearchOnOptions();

            tbHitTimer.Value = prefBE.GetPref(OfficerPrefsBE.HitCountTimerDelay, 50);
            if (prefBE.GetPref(OfficerPrefsBE.RetrieveHitCount, true))
                cbExecuteHitCount.Checked = true;
            else
                cbExecuteHitCount.Checked = false;

            cbHHBackground.SelectedColor = Color.FromArgb(prefBE.GetPref(OfficerPrefsBE.hhBackground, Color.Yellow.ToArgb()));
            cbHHForeground.SelectedColor = Color.FromArgb(prefBE.GetPref(OfficerPrefsBE.hhForeground, Color.Red.ToArgb()));

        }

        private void SavePrefs()
        {
            try
            {
                Application.UseWaitCursor=true;

                SaveSearchOnOptions();

                prefBE.SetPref(OfficerPrefsBE.BFDaysAhead, tbBFDays.Value);

                //Language - stored in registry, not DB
                if (rbEng.Checked)
                    UIHelper.SaveSetting("UserLanguage", "ENG");
                else if (rbFre.Checked)
                    UIHelper.SaveSetting("UserLanguage", "FRE");

                //Grid selection mode
                if (rbCheck.Checked)
                    prefBE.SetPref(OfficerPrefsBE.GridSelectionMode, OfficerPrefsBE.vGridSelectionModeCheckbox);
                else if (rbMulti.Checked)
                    prefBE.SetPref(OfficerPrefsBE.GridSelectionMode, OfficerPrefsBE.vGridSelectionModeMulti);

                //load bflist on startup
                if (cbLoadBFList.Checked)
                    prefBE.SetPref(OfficerPrefsBE.LoadBFListOnStartup, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.LoadBFListOnStartup, false);

                // peter Load EnableReminders
                if(chkReminders.Checked)
                    prefBE.SetPref(OfficerPrefsBE.EnableReminders, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.EnableReminders, false);

                if (chkFastdataEntry.Checked)
                    prefBE.SetPref(OfficerPrefsBE.FastDataEntry, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.FastDataEntry, false);

                if (chkBFNotify.Checked)
                    prefBE.SetPref(OfficerPrefsBE.BFShowNotify, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.BFShowNotify, false);


                prefBE.SetPref(OfficerPrefsBE.LoadCalendarOnStartup, chkLoadCal.Checked);
                prefBE.SetPref(OfficerPrefsBE.ReadMailOnTimer, chkBFTimer.Checked);

                //load personal file on startup
                if (chkLoadPF.Checked)
                    prefBE.SetPref(OfficerPrefsBE.LoadPersonalFileOnStartup, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.LoadPersonalFileOnStartup, false);

                //autohide officer toolkit on startup
                if (chkAutoHideToolkit.Checked)
                    prefBE.SetPref(OfficerPrefsBE.AutoHideOfficerToolkitOnStartup, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.AutoHideOfficerToolkitOnStartup, false);

                //Remember Search On Selection
                if (cbRememberSearchOn.Checked)
                    prefBE.SetPref(OfficerPrefsBE.RememberSearchOnSelection, true);
                else
                {
                    prefBE.SetPref(OfficerPrefsBE.RememberSearchOnSelection, false);
                    prefBE.SetPref(OfficerPrefsBE.SearchOnDefault, cbDefaultSearchOn.SelectedItem.Value.ToString());
                }

                prefBE.SetPref(OfficerPrefsBE.hhBackground, cbHHBackground.SelectedColor.ToArgb());
                prefBE.SetPref(OfficerPrefsBE.hhForeground, cbHHForeground.SelectedColor.ToArgb());

                if (cbExecuteHitCount.Checked)
                {
                    prefBE.SetPref(OfficerPrefsBE.RetrieveHitCount, true);
                    prefBE.SetPref(OfficerPrefsBE.HitCountTimerDelay, (int)tbHitTimer.Value);
                }
                else
                    prefBE.SetPref(OfficerPrefsBE.RetrieveHitCount, false);

                //Officer Toolkit Hide BF List
                if (chkOTBFList.Checked)
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideBF, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideBF, false);

                //Officer Toolkit Hide Docs
                if (chkOTEmailsDocs.Checked)
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideDocs, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideDocs, false);

                //Officer Toolkit Hide Files
                if (chkOTFiles.Checked)
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideFiles, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideFiles, false);

                //Officer Toolkit Hide Address Book
                if (chkOTAddressBook.Checked)
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideAddBook, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideAddBook, false);

                //Officer Toolkit Hide Calendar
                if(chkOTCalendar.Checked)
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideCalendar, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideCalendar, false);

                //Officer Toolkit Hide Personal File
                if (chkOTPersonalFile.Checked)
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHidePersonalFile, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHidePersonalFile, false);

                //Officer Toolkit Hide My Office
                if (chkOTOfficeFile.Checked)
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideMyOffice, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.OfficerTKHideMyOffice, false);

                //Auto Creation of Timeslip for Every Activity
                if (chkAutoTimeslip.Checked)
                    prefBE.SetPref(OfficerPrefsBE.TimeslipForEveryActivity, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.TimeslipForEveryActivity, false);

                //Create REVISE DOC activity when checking in a document
                if (chkDocCheckInReviseDocAct.Checked)
                    prefBE.SetPref(OfficerPrefsBE.ReviseDocOnDocCheckIn, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.ReviseDocOnDocCheckIn, false);

                //Display Draft Banner
                if (chkAlwaysShowDraftMessage.Checked)
                    prefBE.SetPref(OfficerPrefsBE.AlwaysDisplayDraftDocMessage, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.AlwaysDisplayDraftDocMessage, false);

                if (chkMeta.Checked)
                    prefBE.SetPref(OfficerPrefsBE.PromptMetaData, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.PromptMetaData, false);

                //Prompt on AppClose
                if (chkConfirmOnClose.Checked)
                    prefBE.SetPref(OfficerPrefsBE.PromptOnClose, true);
                else
                    prefBE.SetPref(OfficerPrefsBE.PromptOnClose, false);

                

                //Save Out Of Office info
                officerRow.OutOfOffice = chkOutOfOffice.Checked;
                if (chkOutOfOffice.Checked)
                {
                    officerRow.OutOfOfficeStartDateLocal = startDateCalendarCombo.Value.AddHours(-startDateCalendarCombo.Value.Hour);
                    officerRow.OutOfOfficeStartDateLocal = officerRow.OutOfOfficeStartDateLocal.AddMinutes(-startDateCalendarCombo.Value.Minute);
                    officerRow.OutOfOfficeStartDateLocal = officerRow.OutOfOfficeStartDateLocal.AddHours(startTimeCalendarCombo.Value.Hour);
                    officerRow.OutOfOfficeStartDateLocal = officerRow.OutOfOfficeStartDateLocal.AddMinutes(startTimeCalendarCombo.Value.Minute);

                    officerRow.OutOfOfficeEndDateLocal = endDateCalendarCombo.Value.AddHours(-endDateCalendarCombo.Value.Hour);
                    officerRow.OutOfOfficeEndDateLocal = officerRow.OutOfOfficeEndDateLocal.AddMinutes(-endDateCalendarCombo.Value.Minute);
                    officerRow.OutOfOfficeEndDateLocal = officerRow.OutOfOfficeEndDateLocal.AddHours(endTimeCalendarCombo.Value.Hour);
                    officerRow.OutOfOfficeEndDateLocal = officerRow.OutOfOfficeEndDateLocal.AddMinutes(endTimeCalendarCombo.Value.Minute);
                }
                else
                {
                    officerRow.SetOutOfOfficeStartDateNull();
                    officerRow.SetOutOfOfficeEndDateNull();
                }

                //myAtmng.OfficeMng.GetOfficer().SaveOutOfOffice();
                atLogic.BusinessProcess bp = myAtmng.OfficeMng.GetBP();
                bp.AddForUpdate(myAtmng.OfficeMng.GetOfficer());
                bp.AddForUpdate(myAtmng.OfficeMng.GetOfficerPrefs());
                bp.Update();
                //prefBE.SavePrefsCommit();
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
                Application.UseWaitCursor=false;
            }
            finally { Application.UseWaitCursor=false; }

            //myAtmng.OfficeMng.GetOfficer().SavePrefs(prefs);
        }

        bool buttonWasPressed = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                officerRow.RejectChanges();
                myAtmng.OfficeMng.DB.OfficerPrefs.RejectChanges();
                buttonWasPressed = true;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SavePrefs();
                buttonWasPressed = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cbRememberSearchOn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRememberSearchOn.Checked)
                {
                    lblSearchOn1.Enabled = false;
                    lblSearchOn2.Enabled = false;
                    cbDefaultSearchOn.Enabled = false;
                    cbDefaultSearchOn.SelectedValue = null;
                }
                else
                {
                    lblSearchOn1.Enabled = true;
                    lblSearchOn2.Enabled = true;
                    cbDefaultSearchOn.Enabled = true;

                    if (cbDefaultSearchOn.Items.Count > 0)
                        cbDefaultSearchOn.SelectedIndex = 0;
                }
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
                btnAddToVisible.Enabled = true;
                int removedOrderNum;
                
                DataRow dr = ((DataRowView)gridexDisplayed.CurrentRow.DataRow).Row;
                removedOrderNum = (int)dr["order"];

                dr["order"] = 0; 
                dtSearchOnListHidden.ImportRow(dr);
                dtSearchOnListVisible.Rows.Remove(dr);
                CheckVisibleCount();

                if (dtSearchOnListVisible.Rows.Count==1)
                {
                    btnAddToHidden.Enabled = false;
                    //cbDefaultSearchOn.SelectedValue = null;
                    return;
                }

                if (cbDefaultSearchOn.SelectedItem ==null || cbDefaultSearchOn.SelectedItem.Value == null)
                    cbDefaultSearchOn.SelectedIndex = 0;

                foreach (DataRow drr in dtSearchOnListVisible.Rows)
                {
                    if ((int)drr["order"] > removedOrderNum)
                        drr["order"] = (int)drr["order"] - 1;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnAddToVisible_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddToHidden.Enabled = true;
                
                DataRow dr = ((DataRowView)gridexHidden.CurrentRow.DataRow).Row;
                dr["order"] = dtSearchOnListVisible.Rows.Count+1;
                dtSearchOnListVisible.ImportRow(dr);
                dtSearchOnListHidden.Rows.Remove(dr);
                CheckVisibleCount();

                if (dtSearchOnListHidden.Rows.Count == 0)
                    btnAddToVisible.Enabled = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void CheckVisibleCount()
        {
            btnMoveUp.Enabled = (dtSearchOnListVisible.Rows.Count > 1);
            btnMoveDown.Enabled = (dtSearchOnListVisible.Rows.Count > 1);
        }

        private void RenumberOrder(DataRow dro, bool increment)
        {
            foreach (DataRow dr in dtSearchOnListVisible.Rows)
            {
                if (dr != dro && (int)dr["order"] == (int)dro["order"])
                {
                    if (increment)
                        dr["order"] = (int)dr["order"]-1;
                    else
                        dr["order"] = (int)dr["order"]+1;
                }
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ((DataRowView)gridexDisplayed.CurrentRow.DataRow).Row;
                if ((int)dr["order"] == 1)
                    return;
                else
                    dr["order"] = (int)dr["order"]-1;

                RenumberOrder(dr,false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ((DataRowView)gridexDisplayed.CurrentRow.DataRow).Row;
                if ((int)dr["order"] == dtSearchOnListVisible.Rows.Count)
                    return;
                else
                    dr["order"] = (int)dr["order"] + 1;

                RenumberOrder(dr, true);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cbHHBackground_SelectedColorChanged(object sender, EventArgs e)
        {
            try
            {
                label4.ForeColor = cbHHForeground.SelectedColor;
                label4.BackColor = cbHHBackground.SelectedColor;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cbExecuteHitCount_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                label6.Enabled = cbExecuteHitCount.Checked;
                label7.Enabled = cbExecuteHitCount.Checked;
                tbHitTimer.Enabled = cbExecuteHitCount.Checked;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fPreferences_Load(object sender, EventArgs e)
        {
            try
            {
                gridexDisplayed.MoveFirst();
                gridexHidden.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fPreferences_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!buttonWasPressed && DialogResult == DialogResult.None)
                    this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void chkOutOfOffice_CheckedChanged(object sender, EventArgs e)
        {
            EnableDates();
        }

        private void EnableDates()
        {
            startDateCalendarCombo.Enabled = chkOutOfOffice.Checked;
            endDateCalendarCombo.Enabled = chkOutOfOffice.Checked;
            startTimeCalendarCombo.Enabled = chkOutOfOffice.Checked;
            endTimeCalendarCombo.Enabled = chkOutOfOffice.Checked;
        }

        private void startTimeCalendarCombo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!calEditMode)
                {

                    calEditMode = true;

                    Janus.Windows.CalendarCombo.CalendarCombo calcombo = (Janus.Windows.CalendarCombo.CalendarCombo)sender;

                    DateTime tmpStartTime = startTimeCalendarCombo.Value;
                    DateTime tmpEndTime = endTimeCalendarCombo.Value;

                    if (startDateCalendarCombo.Value > endDateCalendarCombo.Value)
                    {
                        endDateCalendarCombo.Value = startDateCalendarCombo.Value;
                        endTimeCalendarCombo.Value = startTimeCalendarCombo.Value.AddMinutes(15);
                    }

                    startTimeCalendarCombo.Value = startDateCalendarCombo.Value.AddHours(tmpStartTime.Hour);
                    startTimeCalendarCombo.Value = startTimeCalendarCombo.Value.AddMinutes(tmpStartTime.Minute);
                    endTimeCalendarCombo.Value = endDateCalendarCombo.Value.AddHours(tmpEndTime.Hour);
                    endTimeCalendarCombo.Value = endTimeCalendarCombo.Value.AddMinutes(tmpEndTime.Minute);

                    if (startDateCalendarCombo.Value == endDateCalendarCombo.Value)
                    {
                        if (startTimeCalendarCombo.Value >= endTimeCalendarCombo.Value)
                        {
                            endTimeCalendarCombo.Value = startTimeCalendarCombo.Value.AddMinutes(15);
                        }
                    }
                        
                    calEditMode = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}