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
    public partial class fAddressBook : fBase
    {
        FileManager myfmAB;

        public fAddressBook()
        {
            InitializeComponent();
        }

        public fAddressBook(Form f,atriumBE.FileManager fmAB)
            : base(f)
        {
            InitializeComponent();
            myfmAB = fmAB;
            timFMHeartbeat.Start();
//            myfmAB.KeepAlive = true;
            //myfmAB.GetFileContact().LoadByFileId(myfmAB.CurrentFileId);
            fileContactBindingSource.DataSource = myfmAB.DB.FileContact;
            fileContactGridEX.DropDowns["ddOfficeCode"].SetDataBinding(myfmAB.Codes("vOfficeList"),"");
            fileContactGridEX.DropDowns["ddOfficeName"].SetDataBinding(myfmAB.Codes("vOfficeList"), "");
            myfmAB.DB.FileContact.ColumnChanged += new DataColumnChangeEventHandler(FileContact_ColumnChanged);
        }

        void FileContact_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try 
            {
                if (fileContactGridEX.CurrentRow != null)
                {
                    fileContactGridEX.CurrentRow.BeginEdit();
                    fileContactGridEX.CurrentRow.Cells["Modified"].Value = true;
                    fileContactGridEX.CurrentRow.EndEdit();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private atriumDB.FileContactRow CurrentRow()
        {
            if(fileContactBindingSource.Current!=null)
                return (atriumDB.FileContactRow)((DataRowView)fileContactBindingSource.Current).Row;

            return null;
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try 
            {
                switch (e.Command.Key)
                {
                    case "cmdNewContact":
                        cmdNewContact1.Expand();
                        break;
                    case "cmdAddExistingContact":
                        fACWizard faacw1 = new fACWizard(myfmAB, ACEngine.Step.ACInfo, UIHelper.AtMng.GetSetting(AppIntSetting.AddressBookFileContactAcId));
                        faacw1.ShowDialog();
                        faacw1.Close();
                        break;
                    case "cmdCreateNewContact":
                        fACWizard faacw2 = new fACWizard(myfmAB, ACEngine.Step.ACInfo, UIHelper.AtMng.GetSetting(AppIntSetting.AddressBookNewContactAcId));
                        faacw2.ShowDialog();
                        faacw2.Close();
                        break;
                    case "cmdCardView":
                        if (!e.Command.IsChecked)
                        {
                            e.Command.IsChecked = true;
                        }
                        else
                        {
                            cmdListView.IsChecked = false;
                            fileContactGridEX.View = Janus.Windows.GridEX.View.CardView;
                            cmdGroupBy.Visible = Janus.Windows.UI.InheritableBoolean.False;
                            cmdFilter.Visible = Janus.Windows.UI.InheritableBoolean.False;
                            cmdFldChooser.Visible = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        break;
                    case "cmdFilter":
                        if (e.Command.IsChecked)
                            fileContactGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            fileContactGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "cmdFldChooser":
                        fileContactGridEX.ShowFieldChooser(this,LawMate.Properties.Resources.FieldSelector);
                        break;
                    case "cmdGroupBy":
                        fileContactGridEX.GroupByBoxVisible = e.Command.IsChecked;
                        break;
                    case "cmdListView":
                        if (!e.Command.IsChecked)
                        {
                            e.Command.IsChecked = true;
                        }
                        else
                        {
                            cmdCardView.IsChecked = false;
                            fileContactGridEX.View = Janus.Windows.GridEX.View.TableView;
                            cmdGroupBy.Visible = Janus.Windows.UI.InheritableBoolean.True;
                            cmdFilter.Visible = Janus.Windows.UI.InheritableBoolean.True;
                            cmdFldChooser.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        }
                        break;
                    case "cmdSave":
                        DoSave();
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                    case "cmdCancel":
                        Cancel();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void Cancel()
        {
            UIHelper.Cancel(fileContactBindingSource, myfmAB.DB.FileContact);
            ClearModifiedFlag();
        }

        private void ClearModifiedFlag()
        {
            foreach (Janus.Windows.GridEX.GridEXRow gr in fileContactGridEX.GetRows())
            {
                if (gr.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    gr.BeginEdit();
                    gr.Cells["Modified"].Value = false;
                    gr.EndEdit();
                }
            }
        }

        private void Delete()
        {
            atriumDB.FileContactRow fcr = CurrentRow();
            if (fcr != null)
            {
                if (MessageBox.Show(String.Format(LawMate.Properties.Resources.AreYouSureYouWantToRemoveFromYourAddressBook, fcr.FirstName, fcr.LastName), LawMate.Properties.Resources.RemoveContactFromAddressBook, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    fcr.Delete();
                    DoSave();
                }
            }
        }

        private void DoSave()
        {
            if (myfmAB.DB.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(myfmAB.DB);
            }
            else
            {
                try
                {
                    string attemptDebtorUpdateMessage = "";
                    string sharedContactMessage = "";
                    if (myfmAB.DB.FileContact.GetChanges(DataRowState.Modified)!=null)
                    {
                        foreach (atriumDB.FileContactRow fcr in (atriumDB.FileContactDataTable)myfmAB.DB.FileContact.GetChanges(DataRowState.Modified))
                        {
                            if (fcr.IsOfficeIdNull())
                            {
                                if (!myfmAB.GetFileContact().IsADebtor(fcr.ContactId))
                                {
                                    atriumDB.ContactRow cr = myfmAB.GetPerson().Load(fcr.ContactId);
                                    int sharedCount = myfmAB.GetFileContact().FileContactCount(fcr.ContactId);
                                    if (sharedCount > 1)
                                        sharedContactMessage += String.Format(LawMate.Properties.Resources.TheContactIsASharedContact, fcr.FirstName ,fcr.LastName, sharedCount);

                                    cr.LastName = fcr.LastName;
                                    cr.FirstName = fcr.FirstName;

                                    if (fcr.IsTelephoneNumberNull())
                                        cr.SetTelephoneNumberNull();
                                    else
                                        cr.TelephoneNumber = fcr.TelephoneNumber;

                                    if (fcr.IsTelephoneExtensionNull())
                                        cr.SetTelephoneExtensionNull();
                                    else
                                        cr.TelephoneExtension = fcr.TelephoneExtension;

                                    if (fcr.IsFaxNumberNull())
                                        cr.SetFaxNumberNull();
                                    else
                                        cr.FaxNumber = fcr.FaxNumber;

                                    if (fcr.IsCellPhoneNull())
                                        cr.SetCellPhoneNull();
                                    else
                                        cr.CellPhone = fcr.CellPhone;

                                    if (fcr.IsEmailAddressNull())
                                        cr.SetEmailAddressNull();
                                    else
                                        cr.EmailAddress = fcr.EmailAddress;
                                }
                                else
                                {
                                    attemptDebtorUpdateMessage +=  String.Format(LawMate.Properties.Resources.AttemptedToUpdateContactInfoForDebtor,fcr.FirstName, fcr.LastName, AtMng.AppMan.AppName);
                                }
                            }
                        }
                    }
                    if (attemptDebtorUpdateMessage.Length > 0)
                        MessageBox.Show(attemptDebtorUpdateMessage, LawMate.Properties.Resources.UpdateOfOpponentContact, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (sharedContactMessage.Length > 0)
                    {
                        sharedContactMessage += LawMate.Properties.Resources.ContactInfoUpdatedForEveryUserOrFileThatSharesContact;
                        MessageBox.Show(sharedContactMessage, LawMate.Properties.Resources.UpdateOfSharedContacts, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    fileContactGridEX.UpdateData();
                    fileContactBindingSource.EndEdit();

                    myfmAB.SaveAll();
                    //atLogic.BusinessProcess bp = myfmAB.GetBP();
                    //bp.AddForUpdate(myfmAB.GetFileContact());
                    //bp.AddForUpdate(myfmAB.GetPerson());
                    //bp.Update();

                //    myfmAB.GetFileContact().LoadByFileId(myfmAB.CurrentFile.FileId);
                    ClearModifiedFlag();
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
            }
        }

        private void fileContactGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (fileContactGridEX.CurrentRow != null && e.Row.RowType == Janus.Windows.GridEX.RowType.Record && e.Row.Cells["IsLoaded"].Value == null && e.Row.Cells["ContactId"].Value !=null && e.Row.Cells["ContactId"].Value.ToString().Length > 0)
                {
                    e.Row.BeginEdit();
                    if (e.Row.Cells["OfficerCode"].Value.ToString().Length > 0)
                    {
                        officeDB.OfficerRow offrow = myfmAB.LeadOfficeMng.GetOfficer().LoadByOfficerCode(e.Row.Cells["OfficerCode"].Value.ToString());
                        if (!offrow.IsActiveNull() && offrow.Active)
                            e.Row.Cells["icon"].Value = 2; //active user
                        else
                            e.Row.Cells["icon"].Value = 1; //officer - non-user
                    }
                    else
                    {
                        if (myfmAB.GetFileContact().IsADebtor((int)e.Row.Cells["ContactId"].Value)) // is a debtor
                            e.Row.Cells["icon"].Value = 3; //debtor
                        else if (myfmAB.GetFileContact().FileContactCount((int)e.Row.Cells["ContactId"].Value) > 1) // is a shared plain contact
                            e.Row.Cells["icon"].Value = 4; //person, shared
                        else
                            e.Row.Cells["icon"].Value = 0; //contact, standalone - not shared
                    }
                    e.Row.Cells["IsLoaded"].Value = true;
                    e.Row.EndEdit();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fileContactGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                switch (e.Column.Key)
                {
                    case "EmailAddress":
                        if(!CurrentRow().IsEmailAddressNull())
                            lmWinHelper.NewMail(AtMng.GetFile(AtMng.WorkingAsOfficer.SentItemsId), CurrentRow().EmailAddress);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fileContactGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (fileContactGridEX.CurrentRow!=null && fileContactGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record && fileContactGridEX.CurrentRow.Cells["IsLoaded"].Value != null)
                {
                    int ctype=(int)fileContactGridEX.CurrentRow.Cells["icon"].Value;
                    switch (ctype)
                    {
                        case 0:
                        case 4:
                            fileContactGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                            break;
                        default:
                            fileContactGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void timFMHeartbeat_Tick(object sender, EventArgs e)
        {
            try
            {
                atriumBE.FileManager fm = AtMng.GetFile(myfmAB.CurrentFile.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
    }
}

