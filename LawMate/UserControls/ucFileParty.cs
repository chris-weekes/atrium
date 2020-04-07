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
    public partial class ucFileParty : ucBase
    {   

        atriumBE.SSTManager sstMngr;

        public ucFileParty()
        {
            InitializeComponent();
        }

        public void BindData( atriumDB.FileContactDataTable dt)
        {
            sstMngr = FM.GetSSTMng();

            ucAddress1.FM = FM;
            addressBindingSource.DataMember = FM.DB.Address.TableName;
            addressBindingSource.DataSource = FM.DB;

            partyBindingSource.DataSource = dt.DataSet;
            partyBindingSource.DataMember = "Contact";

            filePartyBindingSource.DataSource = dt.DataSet;
            filePartyBindingSource.DataMember = dt.TableName;

            ucAddress1.DataSource = addressBindingSource;

            
            UIHelper.ComboBoxInit("vcontacttypeparty", contactTypeCodeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("HearingMethod", mccHearingMethod, FM);
            UIHelper.ComboBoxInit("HearingMethod", filePartyGridEX.DropDowns["ddHearingMethod"], FM);
            UIHelper.ComboBoxInit("vcontacttypeparty", filePartyGridEX.DropDowns["ddContactType"], FM);

            UIHelper.ComboBoxInit("Sex", sexCodeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("LanguageCode", languageCodeucMultiDropDown, FM);

            LoadContactIdDataView();

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.DB.Contact.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.DB.Address.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetFileContact().OnUpdate += new atLogic.UpdateEventHandler(ucFileParty_OnUpdate);
            FM.GetPerson().OnUpdate += new atLogic.UpdateEventHandler(ucFileParty_OnUpdate);
            FM.GetAddress().OnUpdate += new atLogic.UpdateEventHandler(ucFileParty_OnUpdate);
            
        }

        private void LoadContactIdDataView()
        {
            DataTable contactDT = new DataTable();
            contactDT.Columns.Add("contactId",typeof(int));
            contactDT.Columns.Add("contactName", typeof(string));

            foreach (atriumDB.ContactRow pr in FM.DB.Contact.Rows)
            {
                if(!pr.IsLastNameNull())
                    contactDT.Rows.Add(pr.ContactId, pr.FirstName + " " + pr.LastName);
                else
                    contactDT.Rows.Add(pr.ContactId, pr.LegalName );
            }
            contactDT.AcceptChanges();

            DataView contactDV = new DataView(contactDT);
            filePartyGridEX.DropDowns["ddContact"].SetDataBinding(contactDV, "");
        }

        void ucFileParty_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                    ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void EndEdit()
        {
            filePartyBindingSource.EndEdit();
            partyBindingSource.EndEdit();
            addressBindingSource.EndEdit();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(filePartyBindingSource, !makeReadOnly);
            UIHelper.EnableControls(partyBindingSource, !makeReadOnly);
            UIHelper.EnableControls(addressBindingSource, !makeReadOnly);

            uiCommandBar1.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());

        }

        bool InEditMode = false;
        public override void ApplyBR(bool DataNotDirty)
        {
            fFile f = FileForm();
            if (f != null)
            {
                if (f.ReadOnly)
                    return;

                f.fileToc.Enabled = DataNotDirty;
                f.EditModeTitle(!DataNotDirty);
            }

            InEditMode = !DataNotDirty;

            if (DataNotDirty)
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            lmWinHelper.EditModeCommandToggle(cmdEdit, InEditMode);

        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)dr;
            UIHelper.EnableControls(filePartyBindingSource, FM.GetFileContact().CanEdit(fcr));
            UIHelper.EnableControls(partyBindingSource, FM.GetPerson().CanEdit(CurrentRowParty()));
            if (!CurrentRowParty().IsAddressCurrentIDNull() && CurrentRowAddress() != null)
                UIHelper.EnableControls(addressBindingSource, FM.GetAddress().CanEdit(CurrentRowAddress()));

            UIHelper.EnableCommandBarCommand(cmdDelete, FM.GetFileContact().CanDelete(fcr));
        }

        public override string ucDisplayName()
        {
            return "File Participants";
        }

        public override void ReloadUserControlData()
        {
            //FM.GetFileContact().PreRefresh();
            //FM.GetPerson().PreRefresh();
            //FM.GetAddress().PreRefresh();
            //FM.GetFileContact().LoadByFileId(FM.CurrentFile.FileId);
            //FM.GetPerson().LoadByFileId(FM.CurrentFile.FileId);
            //FM.GetAddress().LoadByFileIdP(FM.CurrentFile.FileId);
            LoadContactIdDataView();
        }

        public override void Save()
        {
            if (sstMngr.DB.FileParty.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(sstMngr.DB);
            }
            else
            {
                try
                {

                    filePartyBindingSource.EndEdit();
                    partyBindingSource.EndEdit();
                    addressBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();

                    bp.AddForUpdate(FM.GetFileContact());
                    bp.AddForUpdate(FM.GetPerson());
                    bp.AddForUpdate(FM.GetAddress());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();

                

                    ApplyBR(true);
                }
                catch (Exception x)
                {
                  
                    throw x;
                }
            }
        }

        public override void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    filePartyBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetFileContact());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();
                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private atriumDB.FileContactRow CurrentRow()
        {
            if (filePartyBindingSource.Current == null)
                return null;
            else
                return (atriumDB.FileContactRow)((DataRowView)filePartyBindingSource.Current).Row;
        }

        private atriumDB.ContactRow CurrentRowParty()
        {
            if (partyBindingSource.Current == null)
                return null;
            else
                return (atriumDB.ContactRow)((DataRowView)partyBindingSource.Current).Row;
        }

        private atriumDB.AddressRow CurrentRowAddress()
        {
            if (addressBindingSource.Current == null)
                return null;
            else
                return (atriumDB.AddressRow)((DataRowView)addressBindingSource.Current).Row;
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            filePartyBindingSource.Position = filePartyBindingSource.Find("FilePartyId", linkId);
        }

        private void TogglePartyEditableMode(bool Enable)
        {
            salutationEditBox.ReadOnly = !Enable;
            salutationEditBox.BackColor = (salutationEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            firstNameEditBox.ReadOnly = !Enable;
            firstNameEditBox.BackColor = (firstNameEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            middleNameEditBox.ReadOnly = !Enable;
            middleNameEditBox.BackColor = (middleNameEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            lastNameEditBox.ReadOnly = !Enable;
            lastNameEditBox.BackColor = (lastNameEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            suffixEditBox.ReadOnly = !Enable;
            suffixEditBox.BackColor = (suffixEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            sINMaskedEditBox.ReadOnly = !Enable;
            sINMaskedEditBox.BackColor = (sINMaskedEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            companyEditBox.ReadOnly = !Enable;
            companyEditBox.BackColor = (companyEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            languageCodeucMultiDropDown.ReadOnly = !Enable;
            sexCodeucMultiDropDown.ReadOnly = !Enable;
            notesEditBox.ReadOnly = !Enable;
            notesEditBox.BackColor = (notesEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            birthDateCalendarCombo.ReadOnly = !Enable;
            birthDateCalendarCombo.BackColor = (birthDateCalendarCombo.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            telephoneNumberMaskedEditBox.ReadOnly = !Enable;
            telephoneNumberMaskedEditBox.BackColor = (telephoneNumberMaskedEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            telephoneExtensionEditBox.ReadOnly = !Enable;
            telephoneExtensionEditBox.BackColor = (telephoneExtensionEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            cellPhoneMaskedEditBox.ReadOnly = !Enable;
            cellPhoneMaskedEditBox.BackColor = (cellPhoneMaskedEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            faxNumberMaskedEditBox.ReadOnly = !Enable;
            faxNumberMaskedEditBox.BackColor = (faxNumberMaskedEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox4.ReadOnly = !Enable;
            editBox4.BackColor = (editBox4.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox2.ReadOnly = !Enable;
            editBox2.BackColor = (editBox2.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox5.ReadOnly = !Enable;
            editBox5.BackColor = (editBox5.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox3.ReadOnly = !Enable;
            editBox3.BackColor = (editBox3.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            emailAddressEditBox.ReadOnly = !Enable;
            emailAddressEditBox.BackColor = (emailAddressEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            ucAddress1.IsReadOnly = !Enable;
        }

        private void DoEditParty()
        {
            //JL: We're missing a query to check if party is fileparty on other files
            //2013-01-30

            string mbCaption="Edit Party Information/Address";
            string mbText="This party may be a party/participant on a different file. Editing this information will update the information for all files to which this party/participant relates.\n\nAre you sure you want to continue?";
            TogglePartyEditableMode(MessageBox.Show(mbText, mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdEditParty":
                        DoEditParty();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdCancel":
                        ApplyBR(true);
                        UIHelper.Cancel(filePartyBindingSource);
                        UIHelper.Cancel(partyBindingSource);
                        UIHelper.Cancel(addressBindingSource);
                        TogglePartyEditableMode(false);
                        ApplySecurity(CurrentRow());
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void filePartyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                atriumDB.FileContactRow fcr = CurrentRow();

                if (fcr == null || fcr.IsNull("FileContactId"))
                    return;
                TogglePartyEditableMode(false);
                partyBindingSource.Position = partyBindingSource.Find("ContactId", fcr.ContactId.ToString());

                ApplySecurity(fcr);

                //check for address record and set binding source position
                atriumDB.ContactRow pr = CurrentRowParty();
                if (pr == null || pr.IsNull("ContactId"))
                    return;



                if (!pr.IsAddressCurrentIDNull() && CurrentRowAddress() != null)
                {
                    addressBindingSource.Position = addressBindingSource.Find("AddressId", pr.AddressCurrentID.ToString());
                    gbAddress.Visible = true;
                }
                else
                    gbAddress.Visible = false;

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void filePartyGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.Cells["IsPending"].Value != null && e.Row.Cells["IsPending"].Value.ToString()!="" && (bool)e.Row.Cells["IsPending"].Value == true)
                {
                    e.Row.Cells["Icon"].Value = "PP";
                }
                if (e.Row.Cells["IsAppellant"].Value != null && e.Row.Cells["IsAppellant"].Value.ToString() != "" && (bool)e.Row.Cells["IsAppellant"].Value == true)
                {
                    e.Row.Cells["Icon"].Value = "APP";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }



    }
}
