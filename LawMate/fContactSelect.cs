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
    public partial class fContactSelect : Form
    {
        private global::System.Object missing = global::System.Type.Missing;

        bool MyAddressBookLoaded = false;
        bool FileContactsLoaded = false;
        bool CurrentFileContactsLoaded = false;
        bool LeadLoaded = false;
        bool OwnerLoaded = false;
        bool MyOfficeLoaded = false;
        bool AllOfficesLoaded = false;
        public bool ActiveOnly = false;
        private bool multiSelect = false;
        docDB.DocumentRow multiDoc;

        public void MultiSelect(DocManager dm, docDB.DocumentRow dr)
        {
            multiSelect = true;
            multiDoc = dr;
             pnlBF.Closed = false;
             pnlAuthor.Closed = true;
             pnlRecipients.Closed = true;
             buttonOK.Enabled = false;
             ucRecipientTextBox1.Init(dm, dr);
        }
        bool PartiesOnly = false;

        DataView dvAddressBook;
        DataView dvFileContacts;
        DataView dvCurrentFile;
        DataView dvLead;
        DataView dvOwner;
        DataView dvMyOffice;
        DataView dvAllOffices;
        
        docDB.RecipientDataTable rcUndo;

        FileManager fmCurrent;

        private int contactId;

        public int ContactId
        {
            get { return contactId; }
            set 
            {
                contactId = value;                
            }
        }

        private bool docIsMail = true;
        private bool hasDoc = true;

        private Janus.Windows.UI.Dock.UIPanel SelectedPanel
        {
            get
            {
                if (pnlOwner.Closed == false)
                    return pnlOwner;
                if (pnlContact.Closed == false)
                    return pnlContact;
                if (pnlLists.Closed == false)
                    return pnlLists;
                else
                    return pnlFileContact;
            }
        }
        
        public fContactSelect()
        {
            InitializeComponent();
        }

        public fContactSelect(FileManager fm, docDB.DocumentRow doc, bool onAFile)
        {
            InitializeComponent();
            Init(fm, doc, onAFile, false, false);
        }

        public fContactSelect(FileManager fm,docDB.DocumentRow doc, bool onAFile,bool onlyFileContacts,bool onlyParties)
        {
            InitializeComponent();
            Init(fm, doc, onAFile,onlyFileContacts,onlyParties);
        }

        private void LoadLabels()
        {
            pnlLists.Text = String.Format(Properties.Resources.LawMateDistributionLists, fmCurrent.AtMng.AppMan.AppName);
        }

        private void Init(FileManager fm, docDB.DocumentRow doc, bool onAFile, bool onlyFileContacts, bool onlyParties)
        {
            PartiesOnly = onlyParties;
            fmCurrent = fm;
            LoadLabels();
            UIHelper.ComboBoxInit("ContactType", fileContactGridEX.DropDowns["ddContactType"], fmCurrent);

            pnlBF.Closed = true;

            if (onlyFileContacts)
            {
                cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.CurrentFileContacts, "CurrentFileContacts", 1));
            }
            else
            {
                cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.MyAddressBook, "MyAddressBook", 0));
                if (onAFile)
                {
                    cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.CurrentFileContacts, "CurrentFileContacts", 1));
                    cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.OwnerOffice, "OwnerOffice", 1));
                    cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.LeadOffice, "LeadOffice", 1));
                }
                cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.MyOffice, "MyOffice", 1));
                cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.AllOffices, "AllOffices", 1));
                if (doc != null)
                {
                    cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(String.Format(Properties.Resources.LawMateDistributionLists, fm.AtMng.AppMan.AppName), "LawMateDistributionList", 6));
                    cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.Outlook, "Outlook", 2));
                }

                cbNameList.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.ContactSelectSearch, "Search", 3));
            }
            cbNameList.SelectedIndex = cbNameList.Items.Count - 1;
            ddListSelectionMade();

            //if (onAFile)
            //    cbNameList.SelectedItem = cbNameList.Items[1];
            //else
            //    cbNameList.SelectedItem = cbNameList.Items[3];


            if (doc == null)
            {
                lblImage.ImageKey = "officer.gif";
                hasDoc = false;
                pnlAuthor.Closed = true;
                pnlRecipients.Closed = true;
            }
            else
            {
                docIsMail = doc.isLawmail;
                pnlAuthor.Closed = docIsMail;

                if (!docIsMail)
                {
                    ucRecipientTextBoxFrom.Init(fm.GetDocMng(), doc);
                    lblImage.ImageKey = "document2.gif";
                }
                else
                    lblImage.ImageKey = "mail.gif";

                ucRecipientTextBoxTo.Init(fm.GetDocMng(), doc);
                ucRecipientTextBoxCc.Init(fm.GetDocMng(), doc);

                //grab current list of recips in case of cancel
                rcUndo = (docDB.RecipientDataTable)fm.GetDocMng().DB.Recipient.Copy();
            }
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;

                string resolveValue = "";
                bool nullCurrentRow = true;
                bool mailFound = false;

                if (SelectedPanel == pnlLists)
                {
                    if (CurrentList() != null)
                    {
                        nullCurrentRow = false;
                        mailFound = true;
                        resolveValue = CurrentList().ListNameEng;
                    }

                }

                if (SelectedPanel == pnlFileContact)
                {
                    if (CurrentFC() != null)
                    {
                        nullCurrentRow = false;
                        if (!CurrentFC().IsEmailAddressNull())
                        {
                            resolveValue = CurrentFC().EmailAddress;
                            mailFound = true;
                        }
                        else if (!CurrentFC().IsOfficerCodeNull())
                            resolveValue = CurrentFC().OfficerCode;
                        else if (!docIsMail)
                            resolveValue = CurrentFC().DisplayName;// CurrentFC().LastName + ", " + CurrentFC().FirstName;
                    }
                }
                else if (SelectedPanel == pnlContact)
                {
                    if (CurrentContact() != null)
                    {
                        nullCurrentRow = false;
                        if (!CurrentContact().IsEmailAddressNull())
                        {
                            resolveValue = CurrentContact().EmailAddress;
                            mailFound = true;
                        }
                        else if (!docIsMail)
                            resolveValue = CurrentContact().DisplayName;// CurrentContact().LastName + ", " + CurrentContact().FirstName;
                    }
                }
                else if (SelectedPanel == pnlOwner)
                {
                    if (CurrentOfficer() != null)
                    {
                        nullCurrentRow = false;
                        if (!CurrentOfficer().IsEmailAddressNull())
                        {
                            resolveValue = CurrentOfficer().EmailAddress;
                            mailFound = true;
                        }
                        else
                            resolveValue = CurrentOfficer().OfficerCode;
                    }
                }

                if (resolveValue.Length > 0)
                {
                    switch (btn.Name)
                    {
                        case "btnBF":
                            ucRecipientTextBox1.Add(resolveValue);
                            buttonOK.Enabled = true;
                            break;
                        case "buttonFrom":
                            ucRecipientTextBoxFrom.Add(resolveValue);
                            break;
                        case "buttonTo":
                            ucRecipientTextBoxTo.Add(resolveValue);
                            break;
                        case "buttonCC":
                            ucRecipientTextBoxCc.Add(resolveValue);
                            break;
                    }
                }
                else
                {
                    if (nullCurrentRow)
                        MessageBox.Show(Properties.Resources.PleaseSelectAContact, Properties.Resources.NoContactSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (docIsMail && !mailFound)
                        MessageBox.Show(Properties.Resources.NoValidEMailWasFoundForTheContactYouHaveSelectedThereforeAnEMailCannotBeSentToThatContact, Properties.Resources.NoEMailAddress, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void LeadGridEX_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (hasDoc)
                    buttonTo.PerformClick();
                else if (multiSelect)
                    btnBF.PerformClick();
                else
                    SetSelectedContact(SelectedPanel);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void SetSelectedContact(Janus.Windows.UI.Dock.UIPanel pnl)
        {
            ContactId = 0;
            switch (pnl.Name)
            {
                case "pnlContact":
                    if (CurrentContact() != null)
                        ContactId = CurrentContact().ContactId;
                    break;

                case "pnlFileContact":
                    if (CurrentFC() != null)
                        ContactId = CurrentFC().ContactId;
                    break;

                case "pnlOwner":
                    if (CurrentOfficer() != null)
                        ContactId = CurrentOfficer().OfficerId;
                    break;

                case "pnlLists":
                    return;
                    break;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ContactId = 0;
                if (rcUndo != null)
                {
                    fmCurrent.GetDocMng().DB.Recipient.Clear();
                    fmCurrent.GetDocMng().DB.Recipient.AcceptChanges();
                    fmCurrent.GetDocMng().isMerging = true;
                    fmCurrent.GetDocMng().DB.Recipient.Merge(rcUndo);
                    fmCurrent.GetDocMng().isMerging = false;
                }
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
                if (multiSelect)
                {
                    if (multiDoc.GetRecipientRows().Length == 0)
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
                else if (!hasDoc)
                    SetSelectedContact(SelectedPanel);


                this.Close();
            }
            catch(Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private officeDB.OfficerRow CurrentOfficer()
        {
            if(officerBindingSource.Current!=null)
                return (officeDB.OfficerRow)((DataRowView)officerBindingSource.Current).Row;

            return null;
        }
        private atriumDB.FileContactRow CurrentFC()
        {
            if(fileContactBindingSource.Current!=null)
                return (atriumDB.FileContactRow)((DataRowView)fileContactBindingSource.Current).Row;

            return null;
        }

        private appDB.ListRow CurrentList()
        {
            if (listBindingSource.Current != null)
                return (appDB.ListRow)((DataRowView)listBindingSource.Current).Row;

            return null;
        }

        private appDB.ContactSearchRow CurrentContact()
        {
            if (contactBindingSource.Current != null)
                return (appDB.ContactSearchRow)((DataRowView)contactBindingSource.Current).Row;

            return null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbSearchName.Text.Length > 0)
                {
                    appDB.ContactSearchDataTable cdt = fmCurrent.AtMng.ContactSearch(tbSearchName.Text);
                    string filter = "";
                    if (ActiveOnly)
                    {
                        filter = "CurrentEmployee=1 or CurrentEmployee is null";
                    }
                    contactBindingSource.Filter = filter;
                    contactBindingSource.DataSource = cdt;
                    contactBindingSource.DataMember = "";

                    switch (cbNameList.SelectedValue.ToString())
                    {
                        case "Search":
                            contactGridEX.Focus();
                            break;
                        case "MyAddressBook":
                        case "CurrentFileContacts":
                            fileContactGridEX.Focus();
                            break;
                        case "OwnerOffice":
                        case "LeadOffice":
                        case "MyOffice":
                        case "AllOffices":
                            OwnerGridEx.Focus();
                            break;
                    }
                    this.AcceptButton = null;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ddListSelectionMade()
        {
            switch (cbNameList.SelectedValue.ToString())
            {
                case "Search":
                    IsSearch = true;

                    pnlContact.Closed = false;
                    pnlFileContact.Closed = true;
                    pnlOwner.Closed = true;
                    pnlLists.Closed = true;

                    contactBindingSource.DataSource = null;
                    contactBindingSource.DataMember = "";
                    tbSearchName.Focus();
                    this.AcceptButton = btnSearch;

                    break;
                case "MyAddressBook":
                case "CurrentFileContacts":
                    IsSearch = false;

                    pnlFileContact.Closed = false;
                    pnlContact.Closed = true;
                    pnlOwner.Closed = true;
                    pnlLists.Closed = true;
                    string activeFilter3 = "";
                    if (ActiveOnly)
                    {
                        activeFilter3 = "Active=1";
                    }
                    if (PartiesOnly)
                    {
                        if (ActiveOnly)
                            activeFilter3 += " and ";

                        activeFilter3 += "ContactClass='P'";
                    }
                    DataView dvFC;
                    if (cbNameList.SelectedValue.ToString() == "CurrentFileContacts")
                    {

                        //fmCurrent.GetFileContact().LoadByFileId(fmCurrent.CurrentFile.FileId);
                        dvFC = new DataView(fmCurrent.DB.FileContact, activeFilter3, "", DataViewRowState.CurrentRows);
                    }
                    else //Address Book
                    {
                        FileManager fm = fmCurrent.AtMng.GetFile(fmCurrent.AtMng.WorkingAsOfficer.MyFileId);
                        //fm.GetFileContact().LoadByFileId(fm.CurrentFile.FileId);
                        dvFC = new DataView(fm.DB.FileContact, activeFilter3, "", DataViewRowState.CurrentRows);
                    }

                    fileContactBindingSource.DataSource = dvFC;
                    fileContactBindingSource.DataMember = "";
                    fileContactGridEX.SetDataBinding(fileContactBindingSource, null);
                    fileContactGridEX.Focus();
                    this.AcceptButton = null;

                    break;
                case "LawMateDistributionList":
                    IsSearch = false;

                    pnlFileContact.Closed = true;
                    pnlContact.Closed = true;
                    pnlOwner.Closed = true;
                    pnlLists.Closed = false;

                    fmCurrent.AtMng.GetList().Load();

                    listBindingSource.DataSource = fmCurrent.AtMng.DB;
                    listBindingSource.DataMember = fmCurrent.AtMng.DB.List.TableName;
                    listBindingSource.Filter = "SyncExchange=True";
                    listGridEX.SetDataBinding(listBindingSource, null);
                    listGridEX.Focus();
                    this.AcceptButton = null;
                    break;
                case "OwnerOffice":
                case "LeadOffice":
                case "MyOffice":
                case "AllOffices":
                    IsSearch = false;

                    pnlFileContact.Closed = true;
                    pnlContact.Closed = true;
                    pnlOwner.Closed = false;
                    pnlLists.Closed = true;

                    string activeFilter = "", activeFilter1 = "";
                    if (ActiveOnly)
                    {
                        activeFilter = "CurrentEmployee=1";
                        activeFilter1 = "CurrentEmployee=1 and ";
                    }

                    switch (cbNameList.SelectedValue.ToString())
                    {
                        case "AllOffices":
                            if (!AllOfficesLoaded)
                            {
                                fmCurrent.AtMng.OfficeMng.GetOfficer().Load();
                                dvAllOffices = new DataView(fmCurrent.AtMng.OfficeMng.DB.Officer, activeFilter, "", DataViewRowState.CurrentRows);
                                AllOfficesLoaded = true;
                            }
                            officerBindingSource.DataSource = dvAllOffices;
                            break;
                        case "OwnerOffice":
                            if (!OwnerLoaded)
                            {
                                fmCurrent.AtMng.OfficeMng.GetOfficer().LoadByOfficeId(fmCurrent.CurrentFile.OwnerOfficeId);
                                dvOwner = new DataView(fmCurrent.AtMng.OfficeMng.DB.Officer, activeFilter1 + "OfficeId=" + fmCurrent.CurrentFile.OwnerOfficeId.ToString(), "", DataViewRowState.CurrentRows);
                                OwnerLoaded = true;
                            }
                            officerBindingSource.DataSource = dvOwner;
                            break;
                        case "LeadOffice":
                            if (!LeadLoaded)
                            {
                                fmCurrent.AtMng.OfficeMng.GetOfficer().LoadByOfficeId(fmCurrent.CurrentFile.LeadOfficeId);
                                dvLead = new DataView(fmCurrent.AtMng.OfficeMng.DB.Officer, activeFilter1 + "OfficeId=" + fmCurrent.CurrentFile.LeadOfficeId.ToString(), "", DataViewRowState.CurrentRows);
                                LeadLoaded = true;
                            }
                            officerBindingSource.DataSource = dvLead;
                            break;
                        case "MyOffice":
                            if (!MyOfficeLoaded)
                            {
                                fmCurrent.AtMng.OfficeMng.GetOfficer().LoadByOfficeId(fmCurrent.AtMng.OfficeLoggedOn.OfficeId);
                                dvMyOffice = new DataView(fmCurrent.AtMng.OfficeMng.DB.Officer, activeFilter1 + "OfficeId=" + fmCurrent.AtMng.OfficeLoggedOn.OfficeId.ToString(), "", DataViewRowState.CurrentRows);
                                MyOfficeLoaded = true;
                            }
                            officerBindingSource.DataSource = dvMyOffice;
                            break;
                    }
                    OwnerGridEx.Focus();
                    this.AcceptButton = null;

                    break;

                case "Outlook":
                    IsSearch = false;
                    Redemption.MAPIUtils mapiUtil = DocumentBE.MAPIUtils();
                    try
                    {
                        Redemption.SafeRecipients recips = mapiUtil.AddressBook(missing, missing, 3, true, missing, missing, missing, missing, missing);
                        if (recips != null)
                        {
                            for (int i = 1; i <= recips.Count; i++)
                            {
                                Redemption.SafeRecipient recip = recips.Item(i);

                                if (recip.Type == 1)
                                    ucRecipientTextBoxTo.Add(recip.AddressEntry.SMTPAddress, recip.Name);
                                else if (recip.Type == 2)
                                    ucRecipientTextBoxCc.Add(recip.AddressEntry.SMTPAddress, recip.Name);
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        UIHelper.HandleUIException(x);
                    }
                    mapiUtil.Cleanup();
                    break;
            }

            lblTypeName.Visible = IsSearch;
            tbSearchName.Visible = IsSearch;
            btnSearch.Visible = IsSearch;
        }


        bool IsSearch = false;
        private void cbNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            //    ddListSelectionMade();   
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tbSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnSearch.PerformClick();
                }
            }
            catch (Exception x)
            {
 
            }
        }

        private void fContactSelect_Shown(object sender, EventArgs e)
        {
            try
            {
                tbSearchName.Focus();
            }
            catch (Exception x)
            {

            }
        }

        private void cbNameList_Closed(object sender, EventArgs e)
        {
            try
            {
                ddListSelectionMade(); 
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tbSearchName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnSearch;
        }

    }
}