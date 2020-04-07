using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.EditControls;
using lmDatasets;
using System.Linq;

namespace LawMate
{
    public partial class fAdvancedSearch : fBase
    {
        //IF ADDING NEW FIELDS, MUST UPDATE ResetDefaults() (AND SetDefaults(), WHERE APPLICABLE) FOR DEFAULT/RESET ACTION.


        atriumBE.FileManager fmCurrent;
        fWait fProgress;
        fBrowse fileBrowser;

        public enum SearchType
        {
            None,
            File,
            Document,
            Office,
            Person
        }

        SearchType myCurrentSearchType = SearchType.None;

        public SearchType CurrentSearchType
        {
            get { return myCurrentSearchType; }
            set
            {
                ClosePanels();
                myCurrentSearchType = value;
                switch (CurrentSearchType)
                {
                    case SearchType.Document:
                        pnlFileSearch.Closed = false;
                        tableLayoutPanel2.Visible = true;
                        pnlFileSearch.Activate();
                        CollapseExpandPicAndGroupBox(pbFSearchOn, gbFSearchOn, true);
                        CollapseExpandPicAndGroupBox(pbFFileOpened, gbFFileOpened, true);
                        CollapseExpandPicAndGroupBox(pbFFileClosed, gbFFileClosed, true);
                        CollapseExpandPicAndGroupBox(pbFStatusCodes, gbFStatusCodes, true);
                        CollapseExpandPicAndGroupBox(pbFFileTypes, gbFFileTypes, true);
                        tsDocs.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        tableLayoutPanel1.Height = 1220;
                        SetBindingSource(dicFileSearchLocations);
                        break;
                    case SearchType.File:
                        pnlFileSearch.Closed = false;
                        tableLayoutPanel2.Visible = false;
                        pnlFileSearch.Activate();
                        tsFiles.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        tableLayoutPanel1.Height = 800;
                        SetBindingSource(dicFileSearchLocations);
                        break;
                    case SearchType.Office:
                        pnlOfficeSearch.Closed = false;
                        pnlOfficeSearch.Activate();
                        tsOffices.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        break;
                    case SearchType.Person:
                        pnlPersonSearch.Closed = false;
                        pnlPersonSearch.Activate();
                        tsPeople.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        break;
                }
            }
        }

        public fAdvancedSearch()
        {
            InitializeComponent();
        }

        public fAdvancedSearch(Form f)
            : base(f)
        {
            InitializeComponent();


        }

        private void Uc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSearch(cmdSearchName.GetUIComboBox().Text);
        }

        private void fAdvancedSearch_Load(object sender, EventArgs e)
        {

            //File Panel
            fmCurrent = this.AtMng.GetFile();
            fProgress = MainForm.FProgress;

            UIHelper.CheckedComboBoxInit("Status", clbStatus, fmCurrent);
            UIHelper.CheckedComboBoxInit("FileType", clbFileType, fmCurrent);
            UIHelper.CheckedComboBoxInit("ContactType", cbContactType, fmCurrent);

            UIHelper.ComboBoxInit("CaseStatusActive", ucMultiCaseStatus, fmCurrent);
            ucMultiCaseStatus.SelectedValue = null;

            cbFileContact.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchLastName, "LastName", 20));
            cbFileContact.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchFirstName, "FirstName", 20));

            cbSearchByContactInfo.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchCity, "City", 20));
            cbSearchByContactInfo.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchPostalCode, "PostalCode", 20));
            cbSearchByContactInfo.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchProvince, "Province", 20));
            cbSearchByContactInfo.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchCountry, "Country", 20));


            cbFileNameOrNumber.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchFileNameEnglish, "FileNameEng", 20));
            cbFileNameOrNumber.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchFileNameFrench, "FileNameFre", 20));
            cbFileNameOrNumber.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchFileDescEnglish, "FileDescEng", 20));
            cbFileNameOrNumber.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.AdvSearchFileDescFrench, "FileDescFre", 20));
            cbFileNameOrNumber.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchFullFileName, "FullFileName", 20));
            cbFileNameOrNumber.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchFileNumber, "FileNumber", 20));
            cbFileNameOrNumber.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.QuickSearchFullFileNumber, "FullFileNumber", 20));

            ddTextOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.AdvSearchExactPhrase, "exactPhrase"));
            ddTextOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.AdvSearchAllWords, "allWords"));
            ddTextOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.AdvSearchAtLeastOne, "atLeastOneWord"));
            ddTextOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.AdvSearchBoolean, "boolean"));

            UIHelper.ComboBoxInit("Province", provinceCodeComboBox, fmCurrent);
            provinceCodeComboBox.SetDataBinding(new DataView(fmCurrent.Codes("Province"), "CountryCode = 'CDN'", "ProvinceCode", DataViewRowState.CurrentRows), "");
            provinceCodeComboBox.SelectedValue = null;

            UIHelper.ComboBoxInit("Country", countryCodeComboBox, fmCurrent);
            countryCodeComboBox.SelectedValue = null;
            //Doc Panel

            //TFS#55708 CJW 2013-09-19 changed the table used to DocType from CommType
            UIHelper.CheckedComboBoxInit("DocType", clbCommTypes, fmCurrent);
            UIHelper.CheckedComboBoxInit("FileFormat", clbFileFormat, fmCurrent);

            atLogic.WhereClause wcAdv = new atLogic.WhereClause();
            wcAdv.Add("DocTypeMajorCode", "=", "ADV");
            UIHelper.CheckedComboBoxInit("DocType", clbAdvisoryCodes, fmCurrent, wcAdv);

            atLogic.WhereClause wcLit = new atLogic.WhereClause();
            wcLit.Add("DocTypeMajorCode", "=", "LIT");
            UIHelper.CheckedComboBoxInit("DocType", clbLitigationCodes, fmCurrent, wcLit);

            //Office Panel

            UIHelper.CheckedComboBoxInit("OfficeType", clbOfficeType, fmCurrent);
            UIHelper.CheckedComboBoxInit("AppointmentType", clbAppointmentType, fmCurrent);
            UIHelper.CheckedComboBoxInit("CurrencyCode", clbCurrencyCodes, fmCurrent);


            SetDefaults();

            if (myCurrentSearchType == SearchType.None)
                CurrentSearchType = SearchType.File;

            AtMng.GetSearch().Load();
            AtMng.GetSearchTerm().Load();

            UIComboBox uc = cmdSearchName.GetUIComboBox();
            foreach (appDB.SearchRow sr in AtMng.DB.Search)
            {
                if (sr.OfficerId == AtMng.OfficerLoggedOn.OfficerId)
                {
                    if(sr.Type==0 & CurrentSearchType== SearchType.File)
                        uc.Items.Add(sr.NameE);
                    else if (sr.Type == 1 & CurrentSearchType == SearchType.Document)
                        uc.Items.Add(sr.NameE);
                }
            }

            uc.SelectedIndexChanged += Uc_SelectedIndexChanged;
        }

        private void CollapseExpandPicAndGroupBox(PictureBox pb, Janus.Windows.EditControls.UIGroupBox gb, bool Collapse)
        {
            if (Collapse)
            {
                pb.Image = LawMate.Properties.Resources.plus;
                gb.Enabled = false;
                gb.Tag = gb.Height;
                gb.Height = 18;
                gb.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
                gb.BorderColor = SystemColors.ControlDark;
            }
            else
            {
                gb.Enabled = true;
                gb.Height = (int)gb.Tag;
                gb.FrameStyle = Janus.Windows.EditControls.FrameStyle.Frame;
                gb.BorderColor = Color.Black;
                pb.Image = LawMate.Properties.Resources.minus;
            }
        }
        private void SetDefaults()
        {
            //file
            cbFileNameOrNumber.SelectedValue = "FileNameEng";
            ddTextOptions.SelectedValue = "exactPhrase";

            //doc
            cbDocSubjectTextOptions.SelectedIndex = 1;
            cbFullTextTextOptions.SelectedIndex = 1;
            cbPaperElectronic.SelectedIndex = 0;
            ucDateRange1.SetToNull();
            ucDateRange2.SetToNull();
            ucDateRange3.SetToNull();
            ucDateRange4.SetToNull();

            //office
            cbActive.SelectedIndex = 0;
            cbRetainer.SelectedIndex = 0;
            cbOnlineOffice.SelectedIndex = 0;
            cbUsesBilling.SelectedIndex = 0;
            cbUploadsDisbursements.SelectedIndex = 0;
        }

        private void ResetDefaults()
        {

            switch (CurrentSearchType)
            {
                case SearchType.File:
                    MainForm.ShowAdvancedFileSearch();
                    break;
                case SearchType.Document:
                    MainForm.ShowAdvancedDocumentSearch();
                    break;
                case SearchType.Office:
                    MainForm.ShowAdvancedOfficeSearch();
                    break;
            }
            Close();

        }



        private void ClosePanels()
        {
            foreach (Janus.Windows.UI.Dock.UIPanel pnl in pnlTab.Panels)
            {
                pnl.Closed = true;
            }
            tsFiles.Visible = Janus.Windows.UI.InheritableBoolean.False;
            tsDocs.Visible = Janus.Windows.UI.InheritableBoolean.False;
            tsOffices.Visible = Janus.Windows.UI.InheritableBoolean.False;
            tsPeople.Visible = Janus.Windows.UI.InheritableBoolean.False;
        }

        public void setSearchPath(appDB.EFileSearchRow er, SearchType st)
        {
            dicFileSearchLocations.Add(er.FileId, er);
            SetBindingSource(dicFileSearchLocations);
            CurrentSearchType = st;
        }

        public void OpinionSearch()
        {
            chkOpinion.Checked = true;
        }

        private void SetBindingSource(Dictionary<int, appDB.EFileSearchRow> dic)
        {
            eFileBindingSource.DataSource = null;
            if (dic.Count > 0)
                eFileBindingSource.DataSource = dic.Values;

            chkIncludeXrefs.Visible = dic.Count > 0;
            if (!chkIncludeXrefs.Visible)
                chkIncludeXrefs.Checked = false;
        }


        private Dictionary<int, appDB.EFileSearchRow> dicFileSearchLocations = new Dictionary<int, appDB.EFileSearchRow>();


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileBrowser == null)
                    fileBrowser = new fBrowse(AtMng, 0, false, false, false, true);
                if (fileBrowser.ShowDialog(this) == DialogResult.OK && fileBrowser.SelectedFile != null)
                {
                    dicFileSearchLocations.Add(fileBrowser.SelectedFile.FileId, fileBrowser.SelectedFile);
                    SetBindingSource(dicFileSearchLocations);
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }

        }

        private void searchFile()
        {
            try
            {
                Application.UseWaitCursor = true;
                bool searchWillBeExcuted = false;

                fProgress.InitiateForm(LawMate.Properties.Resources.ValidatingSearchCriteria);
                fProgress.Show();

                atLogic.WhereClause wc = BuildFileCriteria(ref searchWillBeExcuted);
                //atLogic.WhereClause wcContact = BuildFileCriteriaForContact(ref searchWillBeExcuted);
                //atLogic.WhereClause wcCaseStatus = BuildFileCriteriaForCaseStatus(ref searchWillBeExcuted);
                if (searchWillBeExcuted)
                {
                    fSearchResults fSR = new fSearchResults(this.MainForm, wc, null, null, this, chkIncludeXrefs.Checked);
                    if (!fSR.IsDisposed)
                        fSR.Show();
                }
                else
                {
                    MessageBox.Show(LawMate.Properties.Resources.SearchInsufficientCriteria);
                    fProgress.resetForm();
                }
                Application.UseWaitCursor = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
                fProgress.resetForm();
                Application.UseWaitCursor = false;
            }
        }

        private string FixSQLFTTerms(string term)
        {
            term.Replace("'", "''");
            term.Replace(",", " ");
            term.Replace("  ", " ");
            return term;
        }
        private atLogic.WhereClause BuildFileCriteriaForCaseStatus(ref bool searchWillBeExcuted)
        {
            string caseStatusField = "";
            atLogic.WhereClause wcCaseStatus = new atLogic.WhereClause();
            if (ucMultiCaseStatus.SelectedValue != null)
            {
                string caseStatusId = ucMultiCaseStatus.SelectedValue.ToString();
                wcCaseStatus.Add("CaseStatusid", "=", caseStatusId);
                searchWillBeExcuted = true;
            }
            return wcCaseStatus;
        }
        private atLogic.WhereClause BuildFileCriteriaForContact(ref bool searchWillBeExcuted)
        {

            string contactField = "";
            atLogic.WhereClause wcContact = new atLogic.WhereClause();
            try
            {

                //
                // File Contact
                //
                string txtFileContact = FixSQLFTTerms(editBoxFileContact.Text);
                if (txtFileContact.Length > 0)
                {
                    switch (cbFileContact.SelectedValue.ToString())
                    {
                        case "LastName":
                            contactField = "c.Lastname";
                            wcContact.Add(contactField, "LIKE", txtFileContact);
                            break;
                        case "FirstName":
                            contactField = "c.Firstname";
                            wcContact.Add(contactField, "LIKE", txtFileContact);
                            break;

                    }
                    searchWillBeExcuted = true;
                }
                //
                // Contact Types
                //
                if (cbContactType.CheckedItems.Count > 0)
                {
                    if (cbContactType.Items.Count != cbContactType.CheckedItems.Count)
                    {

                        wcContact.Add("FC.ContactType", cbContactType.CheckedItems, LawMate.Properties.Resources.SearchFriendlyTextFileStatus);
                        searchWillBeExcuted = true;
                    }
                }
                //
                // Address
                //

                if (cbSearchByContactInfo.SelectedValue != null)
                {
                    switch (cbSearchByContactInfo.SelectedValue.ToString())
                    {

                        case "City":
                            string addressSearch = FixSQLFTTerms(ebSearchAddress.Text);
                            if (addressSearch.Length > 0)
                            {
                                contactField = "A.City";
                                wcContact.Add(contactField, "LIKE", addressSearch);
                                searchWillBeExcuted = true;
                            }
                            break;
                        case "PostalCode":
                            string postalCode = FixSQLFTTerms(ebMaskPostalCode.Text);
                            if (postalCode.Length > 0)
                            {
                                contactField = "A.PostalCode";
                                wcContact.Add(contactField, "LIKE", postalCode);
                                searchWillBeExcuted = true;
                            }
                            break;
                        case "Country":

                            if (cbInternationalSearch.Checked)
                            {
                                string countrySearch = "CDN";
                                contactField = "A.CountryCode";
                                wcContact.Add(contactField, "<>", countrySearch);
                                searchWillBeExcuted = true;
                            }
                            else
                            {
                                if (countryCodeComboBox.SelectedValue != null)
                                {
                                    string countrySearch = countryCodeComboBox.SelectedValue.ToString();
                                    contactField = "A.CountryCode";
                                    wcContact.Add(contactField, "LIKE", countrySearch);
                                    searchWillBeExcuted = true;
                                }

                            }


                            break;
                        case "Province":
                            if (provinceCodeComboBox.SelectedValue != null)
                            {
                                string provinceSearch = provinceCodeComboBox.SelectedValue.ToString();
                                contactField = "A.ProvinceCode";
                                wcContact.Add(contactField, "LIKE", provinceSearch);
                                searchWillBeExcuted = true;
                            }
                            break;

                    }
                }


                //if (addressSearch.Length > 0)
                //{
                //    switch (cbSearchByContactInfo.SelectedValue.ToString())
                //    {

                //        case "City":
                //            contactField = "A.City";
                //            wcContact.Add(contactField, "LIKE", addressSearch);
                //            break;
                //        case "PostalCode":
                //            contactField = "A.PostalCode";
                //            wcContact.Add(contactField, "LIKE", addressSearch);
                //            break;
                //        //case "Country":
                //        //    contactField = "A.CountryCode";
                //        //    wcContact.Add(contactField, "LIKE", addressSearch);
                //        //    break;

                //    }
                //    searchWillBeExcuted = true;
                //}
                //else
                //{
                //    string provinceSearch = provinceCodeComboBox.SelectedValue.ToString();
                //    if (provinceSearch.Length > 0 && provinceCodeComboBox.Visible == true)
                //    {
                //        contactField = "A.ProvinceCode";
                //        wcContact.Add(contactField, "LIKE", provinceSearch);
                //        searchWillBeExcuted = true;
                //    }
                //    string countrySearch = countryCodeComboBox.SelectedValue.ToString();
                //    if (countrySearch.Length > 0 && countryCodeComboBox.Visible == true)
                //    {
                //        contactField = "A.CountryCode";
                //        wcContact.Add(contactField, "LIKE", countrySearch);
                //        searchWillBeExcuted = true;
                //    }
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
                fProgress.resetForm();
                Application.UseWaitCursor = false;
            }
            return wcContact;
        }

        private atLogic.WhereClause BuildFileCriteria(ref bool searchWillBeExcuted)
        {
            atLogic.WhereClause wc = new atLogic.WhereClause();

            //
            //TODO: File location clause must be OR in between them
            //

            //if (!chkIncludeXref.Checked)
            //    wc.Add("LinkType", "=", 0);

            atLogic.WhereClause wcOR = new atLogic.WhereClause();
            wcOR.Operator = " or ";
            if (dicFileSearchLocations.Count > 0)
            {
                foreach (appDB.EFileSearchRow efr in dicFileSearchLocations.Values)
                {
                    wcOR.Add("x.sortkey", "like", efr.SortKey, LawMate.Properties.Resources.SearchFriendlyTextFileLocation);
                }
                wc.And(wcOR);
            }


            string fileNameOrNumber = FixSQLFTTerms(ebNameNumberValue.Text);
            if (fileNameOrNumber.Length > 0)
            {
                string ffn = "";
                SearchContainsOptions mode;

                switch (cbFileNameOrNumber.SelectedValue.ToString())
                {
                    case "FileNameFre":
                    case "FileNameEng":
                    case "FileDescEng":
                    case "FileDescFre":
                    case "FullFileName":

                        if (cbFileNameOrNumber.SelectedValue.ToString() == "FileNameEng")
                            ffn = "f.namee";
                        else if (cbFileNameOrNumber.SelectedValue.ToString() == "FileNameFre")
                            ffn = "f.namef";
                        else if (cbFileNameOrNumber.SelectedValue.ToString() == "FileDescEng")
                            ffn = "f.descriptione";
                        else if (cbFileNameOrNumber.SelectedValue.ToString() == "FileDescFre")
                            ffn = "f.descriptionf";
                        else
                            ffn = "f.fullpath";


                        if (ddTextOptions.SelectedIndex == 0)//exact
                        {
                            mode = SearchContainsOptions.ExactMatch;

                        }
                        else if (ddTextOptions.SelectedIndex == 1)//all
                        {
                            mode = SearchContainsOptions.AllOfTheTerms;
                        }
                        else if (ddTextOptions.SelectedIndex == 2)//at least one
                        {
                            mode = SearchContainsOptions.AtLeastOneOfTheTerms;
                        }
                        else //boolean if (ddTextOptions.SelectedValue == "boolean")
                        {
                            mode = SearchContainsOptions.BooleanSearch;
                        }
                        wc.Add(ffn, "contains", UIHelper.BuildContains(mode, fileNameOrNumber));
                        break;
                    case "FileNumber":
                        wc.Add("f.filenumber", "like", fileNameOrNumber, LawMate.Properties.Resources.SearchFriendlyTextFileNumber);
                        break;
                    case "FullFileNumber":
                        wc.Add("f.fullfilenumber", "likeboth", fileNameOrNumber, LawMate.Properties.Resources.SearchFriendlyTextFileNumber);
                        break;
                }
                searchWillBeExcuted = true;
            }

            if (ucDateRange3.BeginDate != null)
            {
                if (ucDateRange3.EndDate != null)
                    wc.Add("f.OpenedDate", "between", (DateTime)ucDateRange3.BeginDate, (DateTime)ucDateRange3.EndDate, LawMate.Properties.Resources.SearchFriendlyTextFileOpened);
                else
                    wc.Add("f.OpenedDate", "=", (DateTime)ucDateRange3.BeginDate, LawMate.Properties.Resources.SearchFriendlyTextFileOpened);

                searchWillBeExcuted = true;
            }
            if (ucDateRange4.BeginDate != null)
            {
                if (ucDateRange4.EndDate != null)
                    wc.Add("f.ClosedDate", "between", (DateTime)ucDateRange4.BeginDate, (DateTime)ucDateRange4.EndDate, LawMate.Properties.Resources.SearchFriendlyTextFileClosed);
                else
                    wc.Add("f.ClosedDate", "=", (DateTime)ucDateRange4.BeginDate, LawMate.Properties.Resources.SearchFriendlyTextFileClosed);

                searchWillBeExcuted = true;
            }

            if (clbFileType.CheckedItems.Count > 0)
            {
                if (clbFileType.Items.Count != clbFileType.CheckedItems.Count)
                {
                    wc.Add("f.filetype", clbFileType.CheckedItems, LawMate.Properties.Resources.SearchFriendlyTextFileType);
                    searchWillBeExcuted = true;
                }
            }
            if (clbStatus.CheckedItems.Count > 0)
            {
                if (clbStatus.Items.Count != clbStatus.CheckedItems.Count)
                {
                    wc.Add("f.statuscode", clbStatus.CheckedItems, LawMate.Properties.Resources.SearchFriendlyTextFileStatus);
                    searchWillBeExcuted = true;
                }
            }

            atLogic.WhereClause wcContact = BuildFileCriteriaForContact(ref searchWillBeExcuted);
            if (wcContact.Filter().Length > 0)
            {
                wc.Add("f.fileid", "in", "select fileid from  FileContact FC INNER JOIN Contact C ON FC.ContactID = C.ContactID LEFT JOIN  Address A ON C.AddressCurrentID = A.AddressId WHERE (" + wcContact.Filter() + ")");
            }
            atLogic.WhereClause wcCaseStatus = BuildFileCriteriaForCaseStatus(ref searchWillBeExcuted);
            if (wcCaseStatus.Filter().Length > 0)
            {
                wc.Add("f.fileid", "in", "select fileid from vEFileCaseStatus where " + wcCaseStatus.Filter());
            }


            return wc;
        }

        private void searchOffice()
        {
            try
            {
                bool searchWillBeExcuted = false;
                atLogic.WhereClause wc = new atLogic.WhereClause();

                string OfficeName = tbOfficeName.Text;
                if (OfficeName.Length > 0)
                {
                    wc.Add("officename", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, OfficeName), "Office Name");
                    searchWillBeExcuted = true;
                }

                string OfficeNameFre = tbOfficeNameFre.Text;
                if (OfficeNameFre.Length > 0)
                {
                    wc.Add("officenamefre", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, OfficeNameFre), "French Office Name");
                    searchWillBeExcuted = true;
                }

                string Signatory = tbLetterSignatory.Text;
                if (Signatory.Length > 0)
                {
                    wc.Add("LetterSignatory", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, Signatory), "Signatory to Letter of Appointment");
                    searchWillBeExcuted = true;
                }

                int Active = cbActive.SelectedIndex;
                if (Active > 0)
                {
                    if (Active == 1)
                        wc.Add("Active", "=", true, "Active Office");
                    else
                        wc.Add("Active", "=", false, "Active Office");

                    searchWillBeExcuted = true;
                }

                string OfficeCode = tbOfficeCode.Text;
                if (OfficeCode.Length > 0)
                {
                    wc.Add("OfficeCode", "like", OfficeCode, "Office Code");
                    searchWillBeExcuted = true;
                }

                string Address1 = tbAddress1.Text;
                if (Address1.Length > 0)
                {
                    wc.Add("Address1", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, Address1), "Address Line 1");
                    searchWillBeExcuted = true;
                }

                string Address2 = tbAddress2.Text;
                if (Address2.Length > 0)
                {
                    wc.Add("Address2", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, Address2), "Address Line 2");
                    searchWillBeExcuted = true;
                }

                string Address3 = tbAddress3.Text;
                if (Address3.Length > 0)
                {
                    wc.Add("Address3", "contains", UIHelper.BuildContains(SearchContainsOptions.AllOfTheTerms, Address3), "Address Line 3");
                    searchWillBeExcuted = true;
                }

                string City = tbCity.Text;
                if (City.Length > 0)
                {
                    wc.Add("city", "like", City, "City");
                    searchWillBeExcuted = true;
                }

                //Need MultiColumn ComboBox control for Province
                //string Province = 

                //Need MultiColumn ComboBox control for Country
                //string Country = 

                string PostalCode = tbPostalCode.Text;
                if (PostalCode.Length > 0)
                {
                    wc.Add("PostalCode", "like", PostalCode, "Postal Code");
                    searchWillBeExcuted = true;
                }

                string WorkPhone = workPhoneTextBox.Text;
                if (WorkPhone.Length > 0)
                {
                    wc.Add("WorkPhone", "like", WorkPhone, "Office Telephone Number");
                    searchWillBeExcuted = true;
                }

                string WorkExt = workExtensionTextBox.Text;
                if (WorkExt.Length > 0)
                {
                    wc.Add("WorkExtension", "like", WorkExt, "Telephone Number Extension");
                    searchWillBeExcuted = true;
                }

                string TollFree = homePhoneTextBox.Text;
                if (TollFree.Length > 0)
                {
                    wc.Add("HomePhone", "like", TollFree, "Toll Free Number");
                    searchWillBeExcuted = true;
                }

                string FaxNumber = faxNumberTextBox.Text;
                if (FaxNumber.Length > 0)
                {
                    wc.Add("FaxNumber", "like", FaxNumber, "Fascimile Number");
                    searchWillBeExcuted = true;
                }

                string Email = emailAddressTextBox.Text;
                if (Email.Length > 0)
                {
                    wc.Add("EmailAddress", "like", Email, "E-mail Address");
                    searchWillBeExcuted = true;
                }

                if (clbAppointmentType.CheckedItems.Count > 0)
                {
                    if (clbAppointmentType.Items.Count != clbAppointmentType.CheckedItems.Count)
                    {
                        wc.Add("AppointmentTypeCode", clbAppointmentType.CheckedItems, "Appointment Type");
                        searchWillBeExcuted = true;
                    }
                }
                if (searchWillBeExcuted)
                {

                }
                else
                {

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void searchDoc()
        {
            try
            {
                Application.UseWaitCursor = true;
                fProgress.InitiateForm(LawMate.Properties.Resources.ValidatingSearchCriteria);
                fProgress.Show();

                bool searchWillBeExcuted = false;

                atLogic.WhereClause wc = BuildFileCriteria(ref searchWillBeExcuted);



                //atLogic.WhereClause wcOR = new atLogic.WhereClause();
                //wcOR.Operator = " or ";
                //if (dicDocSearchLocations.Count > 0)
                //{
                //    //if (!chkIncludeXref1.Checked)
                //    //    wc.Add("LinkType", "=", 0, "Link Type");

                //    foreach (appDB.EFileSearchRow efr in dicDocSearchLocations.Values)
                //    {
                //        wcOR.Add("f.fullfilenumber", "like", efr.FullFileNumber, LawMate.Properties.Resources.SearchFriendlyTextFileLocation);
                //    }
                //    wc.And(wcOR);
                //}


                string docSubject = ebDocSubject.Text;
                if (docSubject.Length > 0)
                {
                    wc.Add("d.efsubject", "contains", UIHelper.BuildContains((SearchContainsOptions)cbDocSubjectTextOptions.SelectedIndex, docSubject), LawMate.Properties.Resources.SearchFriendlyTextSubject);
                    searchWillBeExcuted = true;
                }

                string docFrom = ebFrom.Text;
                string docTo = ebTo.Text;
                bool SearchBoth = false;
                if (docFrom.Length > 0 && docTo.Length > 0)
                    SearchBoth = true;

                if (SearchBoth && cbChangeANDtoOR.Checked)
                {
                    atLogic.WhereClause wcOR = new atLogic.WhereClause();
                    wcOR.Operator = " or ";
                    wcOR.Add("d.docid", "in", "select docid from recipient where name like '%" + docFrom + "%' and type=0");
                    wcOR.Add("d.docid", "in", "select docid from recipient where name like '%" + docTo + "%' and type in (1,2)");
                    wc.And(wcOR);
                    searchWillBeExcuted = true;
                }
                else
                {
                    if (docFrom.Length > 0)
                    {
                        wc.Add("d.docid", "in", "select docid from recipient where name like '%" + docFrom + "%' and type=0");
                        // wc.Add("d.efFrom", "like", docFrom, LawMate.Properties.Resources.SearchFriendlyTextFrom);
                        searchWillBeExcuted = true;
                    }


                    if (docTo.Length > 0)
                    {
                        wc.Add("d.docid", "in", "select docid from recipient where name like '%" + docTo + "%' and type in (1,2)");
                        //wc.Add("d.efTo", "like", docTo, LawMate.Properties.Resources.SearchFriendlyTextTo);
                        searchWillBeExcuted = true;
                    }
                }

                if (clbCommTypes.CheckedItems.Count > 0)
                {
                    if (clbCommTypes.Items.Count != clbCommTypes.CheckedItems.Count)
                    {
                        wc.Add("d.eftype", clbCommTypes.CheckedItems, LawMate.Properties.Resources.SearchFriendlyTextCommType);
                        searchWillBeExcuted = true;
                    }
                }

                int paperElectSelectedIndex = cbPaperElectronic.SelectedIndex;
                string docFullText = ebFullText.Text;

                switch (cbPaperElectronic.SelectedIndex)
                {
                    case 1:
                        wc.Add("d.isElectronic", "=", true, LawMate.Properties.Resources.SearchFriendlyTextElectronicDocument);
                        if (docFullText.Length > 0)
                        {
                            wc.Add("contents", "contains", UIHelper.BuildContains((SearchContainsOptions)cbFullTextTextOptions.SelectedIndex, docFullText), LawMate.Properties.Resources.SearchFriendlyTextFullText);
                            searchWillBeExcuted = true;
                        }
                        break;
                    case 2:
                        wc.Add("d.isPaper", "=", true, LawMate.Properties.Resources.SearchFriendlyTextPaperDocument);
                        searchWillBeExcuted = true;
                        break;

                    default:
                        if (docFullText.Length > 0)
                        {
                            wc.Add("contents", "contains", UIHelper.BuildContains((SearchContainsOptions)cbFullTextTextOptions.SelectedIndex, docFullText), LawMate.Properties.Resources.SearchFriendlyTextFullText);
                            searchWillBeExcuted = true;
                        }
                        break;
                }

                bool OPNChecked = chkOpinion.Checked;
                if (OPNChecked)
                {
                    wc.Add("d.Opinion", "=", 1, LawMate.Properties.Resources.SearchFriendlyTextLegalOpinion);
                    searchWillBeExcuted = true;
                }

                bool PVChecked = chkPV.Checked;
                if (PVChecked)
                {
                    wc.Add("d.PV", "=", 1, LawMate.Properties.Resources.SearchFriendlyTextPV);
                    searchWillBeExcuted = true;
                }

                if (clbFileFormat.CheckedItems.Count > 0)
                {
                    if (clbFileFormat.Items.Count != clbFileFormat.CheckedItems.Count)
                    {

                        wc.Add("doccontent.ext", clbFileFormat.CheckedItems, LawMate.Properties.Resources.SearchFriendlyTextFileExtension);
                        searchWillBeExcuted = true;
                    }
                }

                if (clbAdvisoryCodes.CheckedItems.Count > 0)
                {
                    if (clbAdvisoryCodes.Items.Count != clbAdvisoryCodes.CheckedItems.Count)
                    {
                        wc.Add("d.efCodes", clbAdvisoryCodes.CheckedItems, LawMate.Properties.Resources.SearchFriendlyTextADVCodes);
                        searchWillBeExcuted = true;
                    }
                }

                if (clbLitigationCodes.CheckedItems.Count > 0)
                {
                    if (clbLitigationCodes.Items.Count != clbLitigationCodes.CheckedItems.Count)
                    {
                        wc.Add("d.efCodes", clbLitigationCodes.CheckedItems, LawMate.Properties.Resources.SearchFriendlyTextLITCodes);
                        searchWillBeExcuted = true;
                    }
                }

                if (ucDateRange1.BeginDate != null) //doc date
                {
                    if (ucDateRange1.EndDate != null)
                        wc.Add("d.efdate", "between", (DateTime)ucDateRange1.BeginDate, (DateTime)ucDateRange1.EndDate, LawMate.Properties.Resources.SearchFriendlyTextDocDate);
                    else
                        wc.Add("d.efdate", "=", (DateTime)ucDateRange1.BeginDate, LawMate.Properties.Resources.SearchFriendlyTextDocDate);

                    searchWillBeExcuted = true;
                }

                if (ucDateRange2.BeginDate != null) //doc entrydate
                {
                    if (ucDateRange2.EndDate != null)
                        wc.Add("d.entrydate", "between", (DateTime)ucDateRange2.BeginDate, (DateTime)ucDateRange2.EndDate, "Entry Date");
                    else
                        wc.Add("d.entrydate", "between", (DateTime)ucDateRange2.BeginDate, ((DateTime)ucDateRange2.BeginDate).AddDays(1), "Entry Date");

                    searchWillBeExcuted = true;
                }

                if (searchWillBeExcuted)
                {
                    fSearchResultsDoc fSR = new fSearchResultsDoc(this.MainForm, wc, this, UIHelper.BuildContains((SearchContainsOptions)cbFullTextTextOptions.SelectedIndex, docFullText), chkIncludeXrefs.Checked, null, false);
                    fSR.Show();
                }

                else
                {
                    MessageBox.Show(LawMate.Properties.Resources.SearchInsufficientCriteria);
                    fProgress.resetForm();
                }
                Application.UseWaitCursor = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
                fProgress.resetForm();
                Application.UseWaitCursor = false;
            }
        }
        private void DeleteSearch(string name)
        {

            if (name == null || name == "")
                return;

            string type = "0";
            if (CurrentSearchType == SearchType.Document)
                type = "1";
            appDB.SearchRow[] srs = (appDB.SearchRow[])AtMng.DB.Search.Select("OfficerID=" + AtMng.OfficerLoggedOn.OfficerId + " and NameE='" + name + "' and Type=" + type);
            appDB.SearchRow sr;
            if (srs.Length == 1)
            {
                if (UIHelper.ConfirmDelete("Are you sure you want to delete the selected Saved Search?\n\nYou cannot undo this operation."))
                {
                    srs[0].Delete();

                    atLogic.BusinessProcess bp = new atLogic.BusinessProcess(AtMng);
                    bp.AddForUpdate(AtMng.GetSearch());
                    bp.AddForUpdate(AtMng.GetSearchTerm());
                    bp.Update();

                    UIComboBox uc = cmdSearchName.GetUIComboBox();
                    if (uc.Items.Contains(name))
                    {
                        uc.Items.Remove(uc.Items[name]);
                        uc.Text = "";
                    }
                }
            }
        }
        private void SaveSearch(string name)
        {

            if (name == null || name == "")
                throw new LMException("You must provide a name for the saved search");

            string type = "0";
            if (CurrentSearchType == SearchType.Document)
                type = "1";
            appDB.SearchRow[] srs = (appDB.SearchRow[])AtMng.DB.Search.Select("OfficerID=" + AtMng.OfficerLoggedOn.OfficerId + " and NameE='" + name + "' and Type=" + type);
            appDB.SearchRow sr;
            if (srs.Length == 1)
            {
                if (MessageBox.Show("This will update the currently selected Saved Search.\n\nClick OK to update the Saved Search.\n\nIf you mean to create a new Saved Search, click Cancel and change the name of the Saved Search before saving (this will create a new Saved Search)", "Update Existing Saved Search", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    sr = srs[0];
                else
                    return;
            }
            else
            {
                sr =(appDB.SearchRow)AtMng.GetSearch().Add(null);
            }
            if (CurrentSearchType == SearchType.File)
                sr.Type = 0;
            else
                sr.Type = 1;

            sr.OfficeId = AtMng.OfficeLoggedOn.OfficeId;
            sr.OfficerId = AtMng.OfficerLoggedOn.OfficerId;
            sr.NameE = name;
            sr.NameF = name;

            string locs="";
            string sep = "";
            foreach(appDB.EFileSearchRow efr in dicFileSearchLocations.Values)
            {
                locs +=sep+ efr.FileId.ToString();
                sep = ",";
            }
            SaveSearchTerm(sr, "FileLoc", locs,chkIncludeXrefs.Checked.ToString());  //what happened to chkIncludeXref

            SaveSearchTerm(sr, "fileNameOrNumber", cbFileNameOrNumber.SelectedValue, ebNameNumberValue.Text,ddTextOptions.SelectedIndex);
            SaveSearchTerm(sr, "Contact", cbFileContact.SelectedValue, editBoxFileContact.Text);

            //need a case to switch input fields for address
            object text = null;
            if (cbSearchByContactInfo.SelectedValue == null)
                text = null;
            else if (cbSearchByContactInfo.SelectedValue.ToString() == "Province")
                text = provinceCodeComboBox.SelectedValue;
            else if (cbSearchByContactInfo.SelectedValue.ToString() == "Country")
                text = countryCodeComboBox.SelectedValue;
            else if (cbSearchByContactInfo.SelectedValue.ToString() == "PostalCode")
                text = ebMaskPostalCode.Text;
            else
                text = ebSearchAddress.Text;

            SaveSearchTerm(sr, "Address", cbSearchByContactInfo.SelectedValue, text==null? null:text.ToString(),cbInternationalSearch.Checked.ToString());

            SaveSearchTerm(sr, "Casestatus", ucMultiCaseStatus.SelectedValue);

            SaveSearchTerm(sr, "ucDateRange3", ucDateRange3.Mode, ucDateRange3.BeginDate, ucDateRange3.EndDate);
            SaveSearchTerm(sr, "ucDateRange4", ucDateRange4.Mode, ucDateRange4.BeginDate, ucDateRange4.EndDate);

            SaveSearchTerm(sr, "clbFileType", clbFileType);
            SaveSearchTerm(sr, "clbStatus", clbStatus);
            SaveSearchTerm(sr, "cbContactType", cbContactType);

            if(CurrentSearchType== SearchType.Document)
            {
                SaveSearchTerm(sr,"chkOpinion", chkOpinion.Checked.ToString());
                SaveSearchTerm(sr,"cbPaperElectronic", cbPaperElectronic.SelectedIndex.ToString());
                SaveSearchTerm(sr, "cbDocSubjectTextOptions", cbDocSubjectTextOptions.SelectedIndex.ToString(),ebDocSubject.Text);
                SaveSearchTerm(sr, "cbFullTextTextOptions", cbFullTextTextOptions.SelectedIndex.ToString(), ebFullText.Text);
                SaveSearchTerm(sr, "chkPV", chkPV.Checked.ToString());
                SaveSearchTerm(sr, "comm", ebFrom.Text, ebTo.Text, cbChangeANDtoOR.Checked.ToString());
                SaveSearchTerm(sr, "clbCommTypes", clbCommTypes);
                SaveSearchTerm(sr, "clbFileFormat", clbFileFormat);
                SaveSearchTerm(sr, "ucDateRange1", ucDateRange1.Mode, ucDateRange1.BeginDate, ucDateRange1.EndDate);
                SaveSearchTerm(sr, "ucDateRange2", ucDateRange2.Mode, ucDateRange2.BeginDate, ucDateRange2.EndDate);
                SaveSearchTerm(sr, "clbAdvisoryCodes", clbAdvisoryCodes);
                SaveSearchTerm(sr, "clbLitigationCodes", clbLitigationCodes);
            }



            atLogic.BusinessProcess bp = new atLogic.BusinessProcess(AtMng);
            bp.AddForUpdate(AtMng.GetSearch());
            bp.AddForUpdate(AtMng.GetSearchTerm());
            bp.Update();

            UIComboBox uc = cmdSearchName.GetUIComboBox();
            if (!uc.Items.Contains(sr.NameE))
                uc.Items.Add(sr.NameE);
        }

        private void LoadSearch(string name)
        {
            string type = "0";
            if (CurrentSearchType == SearchType.Document)
                type = "1";
            appDB.SearchRow[] srs =(appDB.SearchRow[]) AtMng.DB.Search.Select("OfficerID=" + AtMng.OfficerLoggedOn.OfficerId + " and NameE='" + name + "' and Type="+type );
            if (srs.Length == 1)
            {
                foreach (appDB.SearchTermRow str in srs[0].GetSearchTermRows())
                {
                    switch (str.Term)
                    {
                        case "Casestatus":
                            if (!str.IsP1Null())
                                ucMultiCaseStatus.SelectedValue =System.Convert.ToInt32( str.P1);
                            else
                                ucMultiCaseStatus.SelectedValue = null;
                            break;
                        case "FileLoc":
                            dicFileSearchLocations.Clear();
                            if (!str.IsP1Null())
                            {
                                foreach (string loc in str.P1.Split(','))
                                {
                                    dicFileSearchLocations.Add(System.Convert.ToInt32(loc), AtMng.FileSearchByFileId(System.Convert.ToInt32(loc))[0]);
                                }
                            }
                       
                            chkIncludeXrefs.Checked =System.Convert.ToBoolean( str.P2);
                            SetBindingSource(dicFileSearchLocations);
                            break;
                        case "fileNameOrNumber":
                            cbFileNameOrNumber.SelectedValue = str.P1;
                            if (str.IsP2Null())
                                ebNameNumberValue.Text = null;
                            else
                            {
                                ebNameNumberValue.Text = str.P2;
                            }
                            
                            ddTextOptions.SelectedIndex =System.Convert.ToInt32( str.P3);
                            
                            
                            break;
                        case "Contact":
                            cbFileContact.SelectedValue =str.IsP1Null() ? null: str.P1;
                            editBoxFileContact.Text = str.IsP2Null() ? null : str.P2;
                            break;
                        case "Address":
                            cbSearchByContactInfo.SelectedValue= str.IsP1Null() ? null : str.P1;
                           
                            
                            if (cbSearchByContactInfo.SelectedValue == null)
                                ebSearchAddress.Text = null;
                            else if (cbSearchByContactInfo.SelectedValue.ToString() == "Province")
                                provinceCodeComboBox.SelectedValue = str.IsP2Null() ? null : str.P2; 
                            else if (cbSearchByContactInfo.SelectedValue.ToString() == "Country")
                                countryCodeComboBox.SelectedValue = str.IsP2Null() ? null : str.P2; 
                            else if (cbSearchByContactInfo.SelectedValue.ToString() == "PostalCode")
                                ebMaskPostalCode.Text = str.IsP2Null() ? null : str.P2; 
                            else
                                ebSearchAddress.Text = str.IsP2Null() ? null : str.P2;

                            cbInternationalSearch.Checked =System.Convert.ToBoolean( str.P3);
                            break;
                        case "chkPV":
                        case "chkOpinion":
                            UICheckBox cb = (UICheckBox)this.Controls.Find(str.Term, true)[0];
                            cb.Checked = System.Convert.ToBoolean(str.P1);
                            break;
                        case "cbPaperElectronic":
                            cbPaperElectronic.SelectedIndex = System.Convert.ToInt32(str.P1);
                            break;
                        case "cbDocSubjectTextOptions":
                            cbDocSubjectTextOptions.SelectedIndex = System.Convert.ToInt32(str.P1);
                            ebDocSubject.Text=str.IsP2Null()? null:str.P2;
                            break;
                        case "cbFullTextTextOptions":
                            cbFullTextTextOptions.SelectedIndex = System.Convert.ToInt32(str.P1);
                            ebFullText.Text = str.IsP2Null() ? null : str.P2;
                            break;
                        case "comm":
                            ebFrom.Text= str.IsP1Null() ? null : str.P1;
                            ebTo.Text= str.IsP2Null() ? null : str.P2;
                            cbChangeANDtoOR.Checked = System.Convert.ToBoolean(str.P3);
                            break;
                        case "ucDateRange1":
                        case "ucDateRange2":
                        case "ucDateRange3":
                        case "ucDateRange4":
                            ucDateRange ud = (ucDateRange)this.Controls.Find(str.Term,true)[0];
                            ud.Mode = System.Convert.ToInt32(str.P1);
                            if (ud.Mode == 8)
                            {
                                ud.BeginDate = DateTime.Parse(str.P2);
                                ud.EndDate = DateTime.Parse(str.P3);
                            }
                            break;
                        default:
                            CheckedListBox clb = (CheckedListBox)this.Controls.Find(str.Term, true)[0];
                            //clear everything first
                           for(int i=0;i<clb.Items.Count;i++)
                            {
                                clb.SetItemChecked(i, false);
                            }
                            if (!str.IsP1Null())
                            {
                                foreach (string s in str.P1.Split(','))
                                {

                                    clb.SetItemChecked(clb.FindString(s), true);
                                }
                            }
                            break;
                    }
                }
            }
        }

        private void SaveSearchTerm(appDB.SearchRow sr, string term, CheckedListBox clb)
        {
            appDB.SearchTermRow str = FindAddSearchTerm(sr, term);
            string p1 = "";
            string sep = "";
            foreach (var i in clb.CheckedItems)
            {
                p1 += sep + i.ToString().Substring(0,i.ToString().IndexOf(" - "));
                sep = ",";
            }
            str.P1 = p1;
        }

        private appDB.SearchTermRow FindAddSearchTerm(appDB.SearchRow sr, string term)
        {
            appDB.SearchTermRow str;
            DataRow[] drs = AtMng.DB.SearchTerm.Select("SearchId=" + sr.Id.ToString() + " and Term='" + term + "'");
            if (drs.Length == 1)
            {
                str = (appDB.SearchTermRow)drs[0];
            }
            else
            {
                str = (appDB.SearchTermRow)AtMng.GetSearchTerm().Add(null);
                str.SearchId = sr.Id;
                str.Term = term;

            }

            return str;
        }

        private void SaveSearchTerm(appDB.SearchRow sr,string term,object p1, object p2=null,object p3=null)
        {
            appDB.SearchTermRow str = FindAddSearchTerm(sr, term);
            if (p1 == null)
                str.P1 = null;
            else
                str.P1 = p1.ToString();
            if (p2 == null)
                str.P2 = null;
            else
                str.P2 = p2.ToString();
            if (p3 == null)
                str.P3 = null;
            else
                str.P3 = p3.ToString();

        }
        private void SaveSearchTerm(appDB.SearchRow sr, string term, int p1, DateTime? p2 , DateTime? p3 )
        {
            appDB.SearchTermRow str = FindAddSearchTerm(sr, term);
            str.P1 = p1.ToString();
            if (p1 == 8 )
            {
                str.P2 = p2.Value.ToString();
                str.P3 = p3.Value.ToString();
            }
        }
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdSave":
                        SaveSearch(cmdSearchName.GetUIComboBox().Text);
                        break;
                    //case "cmdSaveAs":
                    //    SaveSearch(cmdSearchName.GetUIComboBox().Text);
                    //    break;
                    //case "cmdLoad":
                    //    LoadSearch(cmdSearchName.GetUIComboBox().SelectedValue.ToString());
                    //    break;
                    case "cmdDelete":
                        DeleteSearch(cmdSearchName.GetUIComboBox().Text);
                        break;
                    case "tsSearch":
                        ExecuteSearch();
                        break;
                    case "tsReset":
                        string mbMessage = LawMate.Properties.Resources.SearchPromptForReset;
                        string mbCaption = LawMate.Properties.Resources.SearchCriteriaCaption;
                        if (MessageBox.Show(mbMessage, mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            ResetDefaults();
                        break;
                    case "tsClose":
                        this.Close();
                        break;
                    case "tsFiles":
                        CurrentSearchType = SearchType.File;
                        break;
                    case "tsDocs":
                        CurrentSearchType = SearchType.Document;
                        break;
                    case "tsOffices":
                        CurrentSearchType = SearchType.Office;
                        break;
                    case "tsPeople":
                        CurrentSearchType = SearchType.Person;
                        break;
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }

        }

        private void ExecuteSearch()
        {
            switch (CurrentSearchType)
            {
                case SearchType.Document:
                    searchDoc();
                    break;
                case SearchType.File:
                    searchFile();
                    break;
                case SearchType.Office:
                    searchOffice();
                    break;
                case SearchType.Person:
                    break;
                case SearchType.None:
                    break;
            }
        }

        private void eFileGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            try
            {
                RemoveFileFromLocationList();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridEX1_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                RemoveFileFromLocationList();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void RemoveFileFromLocationList()
        {
            appDB.EFileSearchRow efr = (appDB.EFileSearchRow)eFileBindingSource.Current;
            if (dicFileSearchLocations.ContainsKey(efr.FileId))
            {
                dicFileSearchLocations.Remove(efr.FileId);
                SetBindingSource(dicFileSearchLocations);
            }
        }

        private void eFileGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(eFileGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tabFileNameNumber_Click(object sender, EventArgs e)
        {

        }

        private void pbFElectDoc_Click(object sender, EventArgs e)
        {
            try
            {
                PictureBox pb = (PictureBox)sender;
                Janus.Windows.EditControls.UIGroupBox gb = null;

                switch (pb.Name)
                {
                    case "pbAddress":
                        gb = groupboxAddress;
                        break;
                    case "pbCaseStatus":
                        gb = groupboxCaseStatus;
                        break;

                    case "pbContact":
                        gb = gbContact;
                        break;

                    case "pbContactType":
                        gb = gbContactType;
                        break;
                    case "pbFElectDoc":
                        gb = gbFLookIn;
                        break;
                    case "pbFFileClosed":
                        gb = gbFFileClosed;
                        break;
                    case "pbFFileOpened":
                        gb = gbFFileOpened;
                        break;
                    case "pbFFileTypes":
                        gb = gbFFileTypes;
                        break;
                    case "pbFSearchOn":
                        gb = gbFSearchOn;
                        break;
                    case "pbFStatusCodes":
                        gb = gbFStatusCodes;
                        break;
                    case "pbDAdvCodes":
                        gb = gbDAdvCodes;
                        break;
                    case "pbDCommType":
                        gb = gbDCommType;
                        break;
                    case "pbDCommunications":
                        gb = gbDCommunications;
                        break;
                    case "pbDDocDate":
                        gb = gbDDocDate;
                        break;
                    case "pbDDocLocation":
                        gb = gbDDocLocation;
                        break;
                    case "pbDDocMod":
                        gb = gbDDocMod;
                        break;
                    case "pbDFileFormat":
                        gb = gbDFileFormat;
                        break;
                    case "pbDFullText":
                        gb = gbDFullText;
                        break;
                    case "pbDLitCodes":
                        gb = gbDLitCodes;
                        break;
                    case "pbDOpinion":
                        gb = gbDOpinion;
                        break;
                    case "pbDPV":
                        gb = gbDPV;
                        break;
                    case "pbDSubject":
                        gb = gbDSubject;
                        break;
                    case "pbDOffice":
                        gb = gbOffice;
                        break;
                    case "pbDOfficeAddress":
                        gb = gbAddress;
                        break;
                    case "pbDApptInfo":
                        gb = gbAppointmentInfo;
                        break;
                }
                if (gb != null)
                {
                    if (gb.Enabled)
                    {
                        gb.Enabled = false;
                        gb.Tag = gb.Height;
                        gb.Height = 18;
                        gb.FrameStyle = Janus.Windows.EditControls.FrameStyle.None;
                        gb.BorderColor = SystemColors.ControlDark;
                        pb.Image = LawMate.Properties.Resources.plus;
                    }
                    else
                    {
                        gb.Enabled = true;
                        gb.Height = (int)gb.Tag;
                        gb.FrameStyle = Janus.Windows.EditControls.FrameStyle.Frame;
                        gb.BorderColor = Color.Empty;
                        pb.Image = LawMate.Properties.Resources.minus;
                    }

                }
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
                if (e.Command.Key == "tsSearchFor")
                {
                    e.Command.Expand();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tbNameNumberValue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        ExecuteSearch();
                        e.SuppressKeyPress = true;
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cbFileNameOrNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbFileNameOrNumber.SelectedValue.ToString() == "FileNumber" || cbFileNameOrNumber.SelectedValue.ToString() == "FullFileNumber")
                    ddTextOptions.Visible = false;
                else
                    ddTextOptions.Visible = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void tbFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ebFrom.Text.Length > 0 && ebTo.Text.Length > 0)
                {
                    lblFromToAndOr.Visible = true;
                    cbChangeANDtoOR.Visible = true;
                }
                else
                {
                    lblFromToAndOr.Visible = false;
                    cbChangeANDtoOR.Visible = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void cbChangeANDtoOR_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UICheckBox cb = (Janus.Windows.EditControls.UICheckBox)sender;
                if (cb.Checked)
                    lblFromToAndOr.Text = LawMate.Properties.Resources.OR;
                else
                    lblFromToAndOr.Text = LawMate.Properties.Resources.AND;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbSearchByContactInfo_SelectedIndexChanged(object sender, EventArgs e)
        {




            try
            {
                if(cbSearchByContactInfo.SelectedValue==null)
                {
                    countryCodeComboBox.Visible = false;
                    ebSearchAddress.Visible = true;
                    ebMaskPostalCode.Visible = false;
                    provinceCodeComboBox.Visible = false;
                    cbInternationalSearch.Visible = false;
                }
                else if (cbSearchByContactInfo.SelectedValue.ToString() == "Province")
                {
                    provinceCodeComboBox.Visible = true;
                    ebSearchAddress.Visible = false;
                    ebMaskPostalCode.Visible = false;
                    countryCodeComboBox.Visible = false;
                    cbInternationalSearch.Visible = false;

                }
                else if (cbSearchByContactInfo.SelectedValue.ToString() == "Country")
                {
                    countryCodeComboBox.Visible = true;
                    ebSearchAddress.Visible = false;
                    ebMaskPostalCode.Visible = false;
                    provinceCodeComboBox.Visible = false;
                    cbInternationalSearch.Visible = true;

                }
                else if (cbSearchByContactInfo.SelectedValue.ToString() == "PostalCode")
                {
                    countryCodeComboBox.Visible = false;
                    ebSearchAddress.Visible = false;
                    ebMaskPostalCode.Visible = true;
                    provinceCodeComboBox.Visible = false;
                    cbInternationalSearch.Visible = false;
                }
                else
                {
                    countryCodeComboBox.Visible = false;
                    ebSearchAddress.Visible = true;
                    ebMaskPostalCode.Visible = false;
                    provinceCodeComboBox.Visible = false;
                    cbInternationalSearch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleUIException(ex);
            }


        }

        private void cbInternational_checkedChanged(object sender, EventArgs e)
        {
            if (cbInternationalSearch.Checked)
            {
                countryCodeComboBox.Visible = false;
                countryCodeComboBox.SelectedValue = null;
            }
            else
            {
                countryCodeComboBox.Visible = true;
                //countryCodeComboBox.SelectedValue = null;
            }
        }
    }
}



