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
    public partial class ucFileContact : ucBase
    {

        public ucFileContact()
        {
            InitializeComponent();
        }

        public void BindFileContactData(atriumDB.FileContactDataTable dt)
        {
            UIHelper.ComboBoxInit("ContactType", ucMultiDropDown1, FM);
            UIHelper.ComboBoxInit("LanguageCode", languageCodeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("NativeLanguage", ucMultiDDNativeLanguage, FM);

            ucAddress1.FM = FM;
            if (FM.GetSSTMng() == null)
            {
                cmdEditParticipant.Text = "Edit Contact Info";
                NativeLang.Visible = false;
                ucMultiDDNativeLanguage.Visible = false;
                chkInterpreter.Visible = false;
                notesEditBox.Top = 74;
                notesLabel.Top = 78;
                fileContactGridEX.RootTable.Columns["isParty"].Visible = false;
                fileContactGridEX.RootTable.Columns["isPending"].Visible = false;
            }
            else
                fileContactGridEX.RootTable.Columns["isOfficer"].Visible = false;

            addressBindingSource.DataMember = FM.DB.Address.TableName;
            addressBindingSource.DataSource = FM.DB;

 
            contactBindingSource.DataMember = "Contact";
            contactBindingSource.DataSource = dt.DataSet;
            

            ucAddress1.DataSource = addressBindingSource;

        
            DataView dv = new DataView(dt, "", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);
            fileContactBindingSource.DataSource = dv;
            fileContactBindingSource.DataMember = "";
            
            UIHelper.ComboBoxInit("ContactType", fileContactGridEX.DropDowns["ddContactType"], FM);
            //UIHelper.ComboBoxInit("vofficelist", fileContactGridEX.DropDowns["ddOffice"], FM);
            //UIHelper.ComboBoxInit("vofficelist", fileContactGridEX.DropDowns["ddOfficeCode"], FM);
            ucOfficeSelectBox1.AtMng = FM.AtMng;

            dt.ColumnChanged+= new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.DB.Contact.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.DB.Address.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);

            FM.GetFileContact().OnUpdate += new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);
            FM.GetPerson().OnUpdate += new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);
            FM.GetAddress().OnUpdate += new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);
        }

        void ucFileContact_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);

        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName.ToUpper() == "RECIPTYPE")
                    return;
                if (e.Column.ColumnName.ToUpper() == "CLOSESTSCCID")
                    return;
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
            contactBindingSource.EndEdit();
            fileContactBindingSource.EndEdit();
            filePartyBindingSource.EndEdit();
            addressBindingSource.EndEdit();
            
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(fileContactBindingSource, !makeReadOnly);
            UIHelper.EnableControls(filePartyBindingSource, !makeReadOnly);
            UIHelper.EnableControls(contactBindingSource, !makeReadOnly);
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
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
            
            
        }
        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;
            
            atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)dr;
            UIHelper.EnableControls(fileContactBindingSource, FM.GetFileContact().CanEdit(fcr));
            UIHelper.EnableControls(filePartyBindingSource, FM.GetFileContact().CanEdit(fcr));
            UIHelper.EnableControls(contactBindingSource, FM.GetPerson().CanEdit(CurrentRowContact()));
            if (!CurrentRowContact().IsAddressCurrentIDNull() && CurrentRowAddress() != null)
                UIHelper.EnableControls(addressBindingSource, FM.GetAddress().CanEdit(CurrentRowAddress()));

            bool canDelFP = true;
            if (FM.GetSSTMng() != null)
            {
                canDelFP = FM.GetSSTMng().GetFileParty().CanDelete(CurrentRowFP());
            }
            bool canDelete= FM.GetFileContact().CanDelete(fcr) && ( CurrentRowFP()==null || CurrentRowFP().FileContactId!=CurrentRow().FileContactid || canDelFP );
            bool canOverride = FM.AtMng.SecurityManager.CanOverride(FM.CurrentFileId, atSecurity.SecurityManager.Features.FileContact) == atSecurity.SecurityManager.ExPermissions.Yes;

            UIHelper.EnableCommandBarCommand(tsDelete, canDelete && (fcr.ContactType != "FTM" || canOverride));

            if (canOverride)
            {
                ucMultiDropDown1.ReadOnly = false;
            }
            else
            {
                ucMultiDropDown1.ReadOnly = true;
            }

            bool isReadOnly = FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No;
            if(isReadOnly)
            {
                tsConvertToOfficer.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdEditParticipant.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

        }
        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.FileContact;
        }
        public override void ReloadUserControlData()
        {
            fileContactGridEX.MoveFirst();
        }

        public override void Save()
        {
            if (FM.DB.FileContact.HasErrors || FM.DB.Contact.HasErrors || FM.DB.Address.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else if (FM.GetSSTMng()!=null && FM.GetSSTMng().DB.FileParty.HasErrors)
            {    
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetSSTMng().DB);
            }
            else
            {
                try
                {
                    fileContactBindingSource.EndEdit();
                    filePartyBindingSource.EndEdit();
                    contactBindingSource.EndEdit();
                    addressBindingSource.EndEdit();

                    //atLogic.BusinessProcess bp = FM.GetBP();

                    //force an update of filecontact so TOC gets updated
                    CurrentRow().updateDate = DateTime.Now.ToUniversalTime();
                    //force update on fileparty to trigger validation rules
                    if(CurrentRowFP()!=null)
                        CurrentRowFP().updateDate = DateTime.Now.ToUniversalTime();

                    FM.SaveAll();
                    //bp.AddForUpdate(FM.GetPerson());
                    //bp.AddForUpdate(FM.GetFileContact());
                    //bp.AddForUpdate(FM.GetAddress());
                    //bp.AddForUpdate(FM.GetSSTMng().GetFileParty());
                    //bp.AddForUpdate(FM.GetAKA());
                    //bp.AddForUpdate(FM.EFile);
                    //bp.Update();

                    //bp.AddForUpdate(FM.EFile);
                    //bp.Update();

                   
                    ApplyBR(true);
                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
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
                    //TFS#51604 CJW 2013-8-21
                    //added check to make sure it is related to the filecontact being deleted 
                    if (CurrentRowFP() != null && CurrentRowFP().FileContactId==CurrentRow().FileContactid)
                        CurrentRowFP().Delete();

                    CurrentRow().Delete();
                    filePartyBindingSource.EndEdit();
                    fileContactBindingSource.EndEdit();

                    FM.SaveAll();
                  

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
            if (fileContactBindingSource.Current == null)
                return null;
            else
                return (atriumDB.FileContactRow)((DataRowView)fileContactBindingSource.Current).Row;
        }
        private SST.FilePartyRow CurrentRowFP()
        {
            if (filePartyBindingSource.Current == null)
                return null;
            else
                return (SST.FilePartyRow)((DataRowView)filePartyBindingSource.Current).Row;
        }
        private atriumDB.ContactRow CurrentRowContact()
        {
            if (contactBindingSource.Current == null)
                return null;
            else
                return (atriumDB.ContactRow)((DataRowView)contactBindingSource.Current).Row;
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
            fileContactBindingSource.Position = fileContactBindingSource.Find("FileContactid", linkId);
        }

        private void ConvertToOfficer()
        {
            //find out what office they belong to
            fBrowseOffices f = new fBrowseOffices(FM.AtMng);

            if (f.ShowDialog() == DialogResult.OK)
            {

                int officeid = f.OfficeId;

                //get officemng
                atriumBE.OfficeManager ofm = FM.AtMng.GetOffice(officeid);

                //convert
                ofm.GetOfficer().AddFromContact(FM.GetPerson().Load(CurrentRow().ContactId), ofm.CurrentOffice);

                //goto new record to finish operation
                fFile ff = FileForm().MainForm.OpenFile(ofm.CurrentOffice.OfficeFileId);

                ff.MoreInfo("officer", CurrentRow().ContactId);
            }

        }

        private void DoEditParty()
        {
            //JL: We're missing a query to check if party is fileparty on other files
            //2013-01-30
            string message = "This contact may be a contact on a different file. Editing this information will update the (boilerplate) information for all files to which this contact relates" + Environment.NewLine + Environment.NewLine + "Are you sure you want to continue?";
            string caption = "Edit Contact Information";
            if(FM.GetSSTMng()!=null)
            {
                message = Properties.Resources.EditParticipantMessage;
                caption = Properties.Resources.EditParticipantCaption;
            }

            TogglePartyEditableMode(MessageBox.Show(message,caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
        }

        private void TogglePartyEditableMode(bool Enable)
        {
            btnAddAddress.Enabled = Enable;

            chkNoReassign.Enabled = Enable;
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
            languageCodeucMultiDropDown.ReadOnly = !Enable;
            notesEditBox.ReadOnly = !Enable;
            notesEditBox.BackColor = (notesEditBox.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            maskedEditBox1.ReadOnly = !Enable;
            maskedEditBox1.BackColor = (maskedEditBox1.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox1.ReadOnly = !Enable;
            editBox1.BackColor = (editBox1.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            maskedEditBox2.ReadOnly = !Enable;
            maskedEditBox2.BackColor = (maskedEditBox2.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            maskedEditBox3.ReadOnly = !Enable;
            maskedEditBox3.BackColor = (maskedEditBox3.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox4.ReadOnly = !Enable;
            editBox4.BackColor = (editBox4.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            maskedEditBox4.ReadOnly = !Enable;
            maskedEditBox4.BackColor = (maskedEditBox4.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox5.ReadOnly = !Enable;
            editBox5.BackColor = (editBox5.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox3.ReadOnly = !Enable;
            editBox3.BackColor = (editBox3.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            editBox6.ReadOnly = !Enable;
            editBox6.BackColor = (editBox6.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            ucAddress1.IsReadOnly = !Enable;

            ucMultiDDNativeLanguage.ReadOnly = !Enable;
            chkInterpreter.Enabled =  Enable;
        }

        public override void Cancel()
        {
            ApplyBR(true);
            UIHelper.Cancel(fileContactBindingSource);
            UIHelper.Cancel(filePartyBindingSource);
            UIHelper.Cancel(contactBindingSource);
            UIHelper.Cancel(addressBindingSource);
            FM.DB.AKA.RejectChanges();
            TogglePartyEditableMode(false);

            //JLL 2015-04-16
            //forces currentchanged to fire on current record - in case adding address is cancelled
            int moveTo = CurrentRow().FileContactid;
            fileContactBindingSource.SuspendBinding();
            fileContactBindingSource.ResumeBinding();
            fileContactBindingSource.Position = fileContactBindingSource.Find("FileContactid", moveTo);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsConvertToOfficer" :
                        ConvertToOfficer();
                        break;
                    case "cmdEditParticipant":
                        DoEditParty();
                        break;
                    case "tsSave":
                        Save();
                        break;
                    case "tsCancel":
                        Cancel();
                        break;
                    case "tsDelete":
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


        private void isOfficer(bool isAnOfficer)
        {
            Janus.Windows.UI.InheritableBoolean jBoolConvert = Janus.Windows.UI.InheritableBoolean.True;

            if (isAnOfficer)
                jBoolConvert = Janus.Windows.UI.InheritableBoolean.False;

            tsConvertToOfficer.Enabled = jBoolConvert;
            gbOfficer.Visible = isAnOfficer;
            gbOfficer.Top = contactTypeLabel.Top + 25;

            //  don't let officers be editted on the filecontact screen
            if (!isAnOfficer)
                cmdEditParticipant.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmdEditParticipant.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        private void isParticipant(bool isAParticipant)
        {
            gbParticipant.Visible = isAParticipant;
            gbParticipant.Top = contactTypeLabel.Top + 25;
        }

        private void verifyContactType(bool isAnOfficer, bool isAParticipant)
        {
            isOfficer(isAnOfficer);
            isParticipant(isAParticipant);
            if (!isAnOfficer && !isAParticipant)
            {
                gbPerson.Top = contactTypeLabel.Top + 25;
                gbBusiness.Top = contactTypeLabel.Top + 25;
            }
            else
            {
                if (isAnOfficer)
                {
                    gbPerson.Top = gbOfficer.Top + gbOfficer.Height + 9;
                    gbBusiness.Top = gbOfficer.Top + gbOfficer.Height + 9;
                }
                else if (isAParticipant)
                {
                    gbPerson.Top = gbParticipant.Top + gbParticipant.Height + 9;
                    gbBusiness.Top = gbParticipant.Top + gbParticipant.Height + 9; 
                }
            }

            gbContactInfo.Top = gbPerson.Top + gbPerson.Height + 9;
        }

        bool participantsLoaded = false;
        private void displayParticipant()
        {
            if (!participantsLoaded & FM.GetSSTMng()!=null)
            {
                FM.GetSSTMng();//.GetFileParty().LoadByFileId(FM.CurrentFile.FileId);
                filePartyBindingSource.DataMember = "FileParty";
                filePartyBindingSource.DataSource = FM.GetSSTMng().DB.FileParty;

                FM.GetSSTMng().DB.FileParty.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
                FM.GetSSTMng().GetFileParty().OnUpdate += new atLogic.UpdateEventHandler(ucFileContact_OnUpdate);

                participantsLoaded = true;
            }
            int rowpos = filePartyBindingSource.Find("FileContactid", CurrentRow().FileContactid);

            filePartyBindingSource.Position = rowpos;
                //filePartyBindingSource.Find("FileContactid", CurrentRow().FileContactid);

            if (rowpos == -1) // contact class is P, but no file party record ... treat as nonofficer, nonparticipant filecontact
                verifyContactType(false,false);
            else
                verifyContactType(false, true);

        }

        private void fileContactBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                atriumDB.FileContactRow fcr = CurrentRow();

                if (fcr==null|| fcr.IsNull("FileContactid"))
                    return;

                TogglePartyEditableMode(false);
                
                switch (fcr.ContactClass)
                {
                    case "O":
                        verifyContactType(true, false);
                        UIHelper.ComboBoxInit("ContactTypeFile", ucMultiDropDown1, FM);
                        break;
                    case "P":
                        displayParticipant();
                        UIHelper.ComboBoxInit("Test", ucMultiDropDown1, FM);
                        //verifyContactType(false, true);
                        break;
                    default:
                        verifyContactType(false,false);
                        UIHelper.ComboBoxInit("ContactType", ucMultiDropDown1, FM);
                        break;
                }

                

                atriumDB.ContactRow pr = CurrentRowContact();
                if (pr == null || pr.IsNull("ContactId"))
                    return;

                

                contactBindingSource.Position = contactBindingSource.Find("ContactId", fcr.ContactId);

                if (!CurrentRowContact().IsAddressCurrentIDNull() && (CurrentRow().IsPositionCodeNull() || CurrentRow().PositionCode !="TM"))
                {
                    atriumDB.AddressRow adr = FM.DB.Address.FindByAddressId(CurrentRowContact().AddressCurrentID);
                    if (adr == null)
                        FM.GetAddress().Load(CurrentRowContact().AddressCurrentID);

                    addressBindingSource.Filter = "";
                    addressBindingSource.Position = addressBindingSource.Find("AddressId", CurrentRowContact().AddressCurrentID.ToString());
                    ucAddress1.Visible = true;
                    btnAddAddress.Visible = false;
                }
                else
                {
                    //addressBindingSource.Filter = "contactid=0";
                    if(fcr.ContactClass=="P" || fcr.ContactClass=="B")
                        btnAddAddress.Visible = true;
                    else
                        btnAddAddress.Visible = false;
                    ucAddress1.Visible = false;
                }

                if (!CurrentRow().IsPositionCodeNull() &&  CurrentRow().PositionCode == "TM")
                {
                    btnAddAddress.Visible = false;
                    ucAddress1.Visible = false;
                }

                ApplySecurity(fcr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fileContactGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fileContactGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                // gridex isParty value list:
                // 1 - appellant
                // 2 - respondent
                // 3 - added party
                // 4 - none of the above

               int fcId = (int)e.Row.Cells["FileContactid"].Value;
               if (FM.GetSSTMng() != null)
               {
                   foreach (SST.FilePartyRow fpr in FM.GetSSTMng().DB.FileParty)
                   {
                       if (fpr.RowState != DataRowState.Deleted && !fpr.IsFileContactIdNull() && fpr.FileContactId == fcId)
                       {
                           if (fpr.IsPending)
                               e.Row.Cells["IsPending"].Value = true;

                           if (fpr.IsAppellant)
                               e.Row.Cells["IsParty"].Value = 1;
                           else if (fpr.IsRespondent)
                               e.Row.Cells["IsParty"].Value = 2;
                           else
                               e.Row.Cells["IsParty"].Value = 3;
                           return;
                       }
                       else
                           e.Row.Cells["IsParty"].Value = 4;
                   }
               }
               else
               {
                   atriumDB.FileContactRow fcr = FM.DB.FileContact.FindByFileContactid(fcId);
                   if(fcr.ContactClass=="O")
                       e.Row.Cells["IsOfficer"].Value = true;
                   else
                       e.Row.Cells["IsOfficer"].Value = false;
               }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            ucAddress1.Visible = true;
            btnAddAddress.Visible = false;
            //UIHelper.EnableControls(addressBindingSource, true);
            //int contactId= CurrentRow().ContactId;
            //atriumDB.ContactRow cr = (atriumDB.ContactRow)FM.DB.Contact.Select("ContactId=" + contactId.ToString())[0];
         //   FM.GetAddress().Load();
            atriumDB.AddressRow ar = (atriumDB.AddressRow)FM.GetAddress().Add(CurrentRowContact());
            
            int adrpos = addressBindingSource.Find("AddressId", CurrentRowContact().AddressCurrentID);
            addressBindingSource.Position = adrpos;



        }
    }
}

