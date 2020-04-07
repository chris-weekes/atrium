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
    public partial class fWorkloadView : LawMate.fBase
    {
        atriumBE.atriumManager atmng;
        object currentContactId;
        public int SelectedContactId = 0;
        atriumBE.FileManager fmNew;
        lmDatasets.atriumDB.ContactRow cr ;
        lmDatasets.atriumDB.AddressRow ar ;

        private bool expectsReturnValue;
        WorkloadQuery myWorkloadQuery;
        public bool ExpectsReturnValue
        {
            get { return expectsReturnValue; }
            set
            {
                expectsReturnValue = value;
                lblSelectedOfficer.Visible = expectsReturnValue;
                ebSelectedOfficer.Visible = expectsReturnValue;
                btnOK.Visible = expectsReturnValue;

                lblSelectedParticipant.Visible = expectsReturnValue;
                ebSelectedParticipant.Visible = expectsReturnValue;
                btnOK2.Visible = expectsReturnValue;


                if (expectsReturnValue)
                {
                    uiTab1.Top = 33;
                    uiTab2.Top = 60;
                }
                else
                {
                    uiTab1.Top = 6;
                    uiTab2.Top = 33;
                }
            }
        }

        public fWorkloadView()
        {
            InitializeComponent();
        }

        public fWorkloadView(WorkloadQuery wlQuery, bool pExpectsReturnValue, atriumBE.FileManager fm,object contactId)
        {
            InitializeComponent();
            atmng = fm.AtMng;
            fmNew = fm;
            myWorkloadQuery = wlQuery;
            currentContactId = contactId;
         
            UIHelper.ComboBoxInit("LanguageCode", languageCodeucMultiDropDown, fm);
            UIHelper.ComboBoxInit("NativeLanguage", ucMultiDDNativeLanguage, fm);

            ucAddress1.FM = fm;

            addressBindingSource.DataMember = fmNew.DB.Address.TableName;
            addressBindingSource.DataSource = fmNew.DB;
            contactBindingSource.DataMember = "Contact";// .Contact.Select("", "", DataViewRowState.Added);
            contactBindingSource.DataSource = fmNew.DB;


           // addressBindingSource.DataSource = fmNew.DB.Address.Select("", "", DataViewRowState.Added);
            ucAddress1.DataSource = addressBindingSource;

            ExpectsReturnValue = pExpectsReturnValue;

            if (wlQuery == WorkloadQuery.ParticipantSearch)
            {
                pnlAll.Closed = true;
                pnlParticipant.Closed = false;
                pnlNewCoontact.Closed = true;
                this.Text = Properties.Resources.ParticipantSearch;
                tbSearchName.Focus();
            }
            else
            {
                pnlParticipant.Closed = true;
                pnlAll.Closed = false;
                pnlNewCoontact.Closed = true;
                this.Text = Properties.Resources.WorkloadDistribution;
                tbSearchName.Focus();
            }
        }

        private appDB.ContactSearchRow CurrentContact()
        {
            if (contactSearchBindingSource.Current != null)
                return (appDB.ContactSearchRow)((DataRowView)contactSearchBindingSource.Current).Row;

            return null;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if(cr!=null)
                {
                    cr.RejectChanges();
                    ar.RejectChanges();
                    cr = null;
                    ar = null;
                }
                SelectedContactId = 0;
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
                if (!pnlParticipant.Closed)
                {

                    if (SelectedContactId == 0 && ExpectsReturnValue)
                    {
                        throw new LMException(Properties.Resources.SelectAParticipant);
                    }
                    if (SelectedContactId != 0)
                        this.Close();
                }

                this.Close();

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
                if (tbSearchName.Text.Length > 0)
                {
                    switch (myWorkloadQuery)
                    {
                        case WorkloadQuery.NotApplicable:
                            appDB.ContactSearchDataTable cdt = atmng.ContactSearch(tbSearchName.Text);
                            //NEED PARTICIPANT SEARCH THAT RETURNS CONTACTS THAT ARE PARTIES

                            //contactBindingSource.Filter = filter;
                            contactSearchBindingSource.DataSource = cdt;
                            contactSearchBindingSource.DataMember = "";
                            break;
                        case WorkloadQuery.ParticipantSearch:
                            appDB.ContactSearchDataTable pdt = atmng.PartySearch(tbSearchName.Text);
                            //NEED PARTICIPANT SEARCH THAT RETURNS CONTACTS THAT ARE PARTIES

                            //contactBindingSource.Filter = filter;
                            contactSearchBindingSource.DataSource = pdt;
                            contactSearchBindingSource.DataMember = "";
                            break;
                    }
                    contactGridEX.Focus();
                    this.AcceptButton = btnOK2;
                }
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

        private void contactGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (contactGridEX.CurrentRow != null && contactGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    SelectedContactId = CurrentContact().ContactId;
                    ebSelectedParticipant.Text = CurrentContact().DisplayName;
                }
                else
                {
                    SelectedContactId = 0;
                    ebSelectedParticipant.Text = "";
                }
            }
            catch (Exception x)
            {

            }
        }

        private void tbSearchName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnSearch;
        }

        private void fWorkloadView_Shown(object sender, EventArgs e)
        {
            tbSearchName.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlAll.Closed = true;
            pnlParticipant.Closed = true;
            pnlNewCoontact.Closed = false;
            btnAddAddress.Visible = false;

            if (currentContactId != null && currentContactId.GetType() == typeof(int))
            {
                cr=fmNew.DB.Contact.FindByContactId((int)currentContactId);
                ar = fmNew.DB.Address.FindByAddressId(cr.AddressCurrentID);
                cr.RejectChanges();
                ar.RejectChanges();

            }
            cr = (lmDatasets.atriumDB.ContactRow)fmNew.GetPerson().Add(null);
            ar = (lmDatasets.atriumDB.AddressRow)fmNew.GetAddress().Add(cr);
            cr.ContactClass = "P";
            cr.AddressCurrentID = ar.AddressId;

            contactBindingSource.Filter = "ContactId=" + cr.ContactId.ToString();
            addressBindingSource.Filter = "Addressid=" + ar.AddressId.ToString();
            //contactBindingSource.DataSource = fmNew.DB.Contact.Select("", "", DataViewRowState.Added);
            //addressBindingSource.DataSource = fmNew.DB.Address.Select("", "", DataViewRowState.Added);
            fmNew.GetPerson().Validate(cr);
            fmNew.GetAddress().Validate(ar);

            SelectedContactId = cr.ContactId;

        }
    }
}
