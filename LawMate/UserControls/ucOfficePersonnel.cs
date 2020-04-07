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
    public partial class ucOfficePersonnel : ucBase
    {
        List<int> myLoadedOfficers = new List<int>();
        public ucOfficePersonnel()
        {
            InitializeComponent();
        }

        private void LoadLabels()
        {
            isMailUICheckBox.Text = String.Format(LawMate.Properties.Resources.usesAppMail, FM.AtMng.AppMan.AppMailName);
            if (FM.AtMng.GetSetting(atriumBE.AppBoolSetting.isCVB))
                cellPhoneLabel1.Text = Properties.Resources.lblTollFreeNumber;
        }

        public void BindPersonnelData(officeDB.OfficerDataTable dt)
        {
            officerDelegateGridEX.DropDowns["ddOfficer"].SetDataBinding(FM.Codes("vOfficerUserList"), "");
            officerGridEX.DropDowns["ddPositionCode"].SetDataBinding(FM.Codes("PositionCode"), "");
            DataView dvRole = new DataView(FM.Codes("RoleCode"), "RoleCode like 'G%'", "RoleCode", DataViewRowState.CurrentRows);
            officerRoleGridEX.DropDowns["ddRoleCode"].SetDataBinding(dvRole, "");
            UIHelper.ComboBoxInit("AppealLevel", appealLevelDropDown, FM);


            LoadLabels();
            assistantIducMultiDropDown.SetDataBinding(FM.OfficerByOffice(FM.CurrentFile.LeadOfficeId, false, true), "");
            ucAddress.FM = FM;
            addressBindingSource.DataMember = FM.DB.Address.TableName;
            addressBindingSource.DataSource = FM.DB;
            ucAddress.DataSource = addressBindingSource;



            UIHelper.ComboBoxInit(FM.Codes("PositionCode"), positionCodeucMultiDropDown, FM);

            officerBindingSource.DataSource = dt.DataSet;
            officerBindingSource.DataMember = dt.TableName;

            officerBindingSource.Filter = "OfficeId=" + FM.CurrentFile.LeadOfficeId.ToString(); ;

            FM.LeadOfficeMng.DB.MemberProfile.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.LeadOfficeMng.GetMemberProfile().OnUpdate += new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);



            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.LeadOfficeMng.GetOfficer().OnUpdate += new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

            FM.LeadOfficeMng.DB.OfficerDelegate.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.LeadOfficeMng.GetOfficerDelegate().OnUpdate += new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

            FM.LeadOfficeMng.DB.OfficerRole.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.LeadOfficeMng.GetOfficerRole().OnUpdate += new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

            FM.LeadOfficeMng.DB.ContactEmail.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.LeadOfficeMng.GetContactEmail().OnUpdate += new atLogic.UpdateEventHandler(ucOfficePersonnel_OnUpdate);

            ucFSInbox.AtMng = FM.AtMng;
            ucFSPersonal.AtMng = FM.AtMng;
            ucFSSentItems.AtMng = FM.AtMng;
            ucFSShortcut.AtMng = FM.AtMng;


            officerGridEX.MoveFirst();
        }
        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.OfficePersonnel;
        }
        public override void ReloadUserControlData()
        {
            myLoadedOfficers.Clear();
            FM.LeadOfficeMng.GetOfficerDelegate().PreRefresh();
            FM.LeadOfficeMng.GetOfficerRole().PreRefresh();
            FM.LeadOfficeMng.GetContactEmail().PreRefresh();
            FM.LeadOfficeMng.GetOfficer().PreRefresh();
            FM.LeadOfficeMng.GetOffice().PreRefresh();

            FM.LeadOfficeMng.GetOffice().LoadByOfficeFileId(FM.CurrentFileId);

            FM.LeadOfficeMng.GetOfficer().LoadByOfficeId(FM.CurrentFile.LeadOfficeId);
            officerGridEX.MoveFirst();
        }

        void ucOfficePersonnel_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {

                switch (e.Column.ColumnName)
                {
                    case "OutOfOfficeEndDateLocal":
                    case "OutOfOfficeStartDateLocal":
                    case "OutEndEng":
                    case "OutEndFre":
                        break;
                    default:
                        if (FM.IsFieldChanged(e.Column, e.Row))
                            ApplyBR(false);
                        break;
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        public override void EndEdit()
        {
            officerBindingSource.EndEdit();
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(officerBindingSource, !makeReadOnly);
            UIHelper.EnableControls(contactEmailBindingSource, !makeReadOnly);
            UIHelper.EnableControls(officerDelegateBindingSource, !makeReadOnly);
            UIHelper.EnableControls(officerRoleBindingSource, !makeReadOnly);
            UIHelper.EnableControls(secMembershipBindingSource, !makeReadOnly);
            UIHelper.EnableControls(secUserBindingSource, !makeReadOnly);
            btnAddNewDelegate.Enabled = !makeReadOnly;
            btnAddNewOfficerRole.Enabled = !makeReadOnly;
            btnAddNewEmailAddress.Enabled = !makeReadOnly;
            if (makeReadOnly)
            {
                officerDelegateGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                officerRoleGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                contactEmailGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            }
            else
            {
                officerDelegateGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                officerRoleGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                contactEmailGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
            }
            if (!makeReadOnly)
                ApplySecurity(CurrentRow());

        }

        bool InEditMode = false;
        public override void ApplyBR(bool DataNotDirty)
        {
            fFile f = FileForm();
            if (f != null)
            {
                f.IsDirty = !DataNotDirty;

                if (f.ReadOnly)
                    return;

                f.fileToc.Enabled = DataNotDirty;
                f.EditModeTitle(!DataNotDirty);
            }

            if (DataNotDirty)
            {
                tsNew.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                InEditMode = false;
            }
            else
            {
                tsNew.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                InEditMode = true;
            }
            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            if (dr == null)
                return;

            officeDB.OfficerRow odr = (officeDB.OfficerRow)dr;
            bool okToAdd = FM.LeadOfficeMng.GetOfficer().CanAdd(odr.OfficeRow);
            UIHelper.EnableControls(officerBindingSource, FM.LeadOfficeMng.GetOfficer().CanEdit(odr));
            UIHelper.EnableCommandBarCommand(tsNew, okToAdd);
            UIHelper.EnableCommandBarCommand(tsCopyPrefs, okToAdd);
            UIHelper.EnableCommandBarCommand(tsSecurity, okToAdd);
            UIHelper.EnableCommandBarCommand(tsMyFile, okToAdd);
            UIHelper.EnableCommandBarCommand(cmdAddToAB, okToAdd);
            UIHelper.EnableCommandBarCommand(tsDelete, FM.LeadOfficeMng.GetOfficer().CanDelete(odr));

            bool isClientReadOnly = FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No;

            uiTabPage2.TabVisible = !isClientReadOnly;
            uiTabPage3.TabVisible = !isClientReadOnly;
            uiTabPage4.TabVisible = !isClientReadOnly;
            tribunalTabPage.TabVisible = (FM.GetSSTMng() != null);




            //if (!odr.IsActiveNull())
            //{
            //    currentEmployeeUICheckBox.Enabled = true;
            //}
            //else
            //{
            //    currentEmployeeUICheckBox.Enabled = false;
            //}


        }

        private officeDB.OfficerRow CurrentRow()
        {
            if (officerBindingSource.Current == null)
                return null;
            else
                return (officeDB.OfficerRow)((DataRowView)officerBindingSource.Current).Row;
        }

        private officeDB.OfficerDelegateRow CurrentRowDelegate()
        {
            if (officerDelegateBindingSource.Current == null)
                return null;
            else
                return (officeDB.OfficerDelegateRow)((DataRowView)officerDelegateBindingSource.Current).Row;
        }

        private officeDB.OfficerRoleRow CurrentRowRole()
        {
            if (officerRoleBindingSource.Current == null)
                return null;
            else
                return (officeDB.OfficerRoleRow)((DataRowView)officerRoleBindingSource.Current).Row;
        }

        public override void Save()
        {
            if (FM.LeadOfficeMng.DB.Officer.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.LeadOfficeMng.DB);
            }
            else
            {
                try
                {
                    int linkId = CurrentRow().OfficerId;

                    officerDelegateGridEX.UpdateData();
                    officerRoleGridEX.UpdateData();
                    contactEmailGridEX.UpdateData();

                    this.officerBindingSource.EndEdit();
                    this.officerDelegateBindingSource.EndEdit();
                    this.officerRoleBindingSource.EndEdit();
                    this.contactEmailBindingSource.EndEdit();
                    this.memberProfileBindingSource.EndEdit();
                    addressBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();

                    bp.AddForUpdate(FM.LeadOfficeMng.GetOfficer());
                    bp.AddForUpdate(FM.GetAddress());
                    bp.AddForUpdate(FM.LeadOfficeMng.GetOfficerRole());
                    bp.AddForUpdate(FM.LeadOfficeMng.GetOfficerDelegate());
                    bp.AddForUpdate(FM.LeadOfficeMng.GetContactEmail());
                    bp.AddForUpdate(FM.LeadOfficeMng.GetMemberProfile());
                    bp.Update();




                    ApplyBR(true);

                    officerBindingSource.Position = officerBindingSource.Find("OfficerId", linkId);
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
                    atSecurity.SecurityManager mySM = FM.AtMng.SecurityManager;
                    SecurityDB.secUserRow sur = null;

                    if (!CurrentRow().IsUserNameNull())
                        sur = mySM.GetsecUser().Load(CurrentRow().UserName);

                    CurrentRow().Delete();
                    this.officerBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();

                    bp.AddForUpdate(FM.LeadOfficeMng.GetOfficer());
                    bp.AddForUpdate(FM.EFile);

                    if (sur != null)
                    {
                        sur.Delete();
                        //   bp.AddForUpdate(mySM.GetsecFileRule());
                        bp.AddForUpdate(mySM.GetsecMembership());
                        bp.AddForUpdate(mySM.GetsecUser());
                    }
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
        public override void MoreInfo(string linkTable, int linkId)
        {
            officerBindingSource.Position = officerBindingSource.Find("OfficerId", linkId);
            if (CurrentRow().RowState == DataRowState.Modified | CurrentRow().RowState == DataRowState.Added)
                ApplyBR(false);
        }


        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsCopyPrefs":

                        fContactSelect fcs = new fContactSelect(FM, null, false);
                        if (fcs.ShowDialog() == DialogResult.OK)
                        {
                            officeDB.OfficerRow fromR = FM.LeadOfficeMng.GetOfficer().FindLoad(fcs.ContactId);
                            if (MessageBox.Show("Are you sure you want to copy all the preferences from " + fromR.DisplayName + " to " + CurrentRow().DisplayName + "?", "Copy Preferences", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int fromOfficer = fcs.ContactId;

                                FM.LeadOfficeMng.GetOfficer().CopyPreferences(fromOfficer, CurrentRow().OfficerId, true);
                                atLogic.BusinessProcess bp1 = FM.GetBP();
                                bp1.AddForUpdate(FM.LeadOfficeMng.DB.OfficerPrefs);
                                bp1.Update();
                            }
                        }
                        break;
                    case "cmdAddToAB":
                        atriumBE.FileManager fmAB = FM.AtMng.GetFile(FM.AtMng.WorkingAsOfficer.MyFileId);
                        try
                        {
                            fmAB.GetFileContact().Add(CurrentRow(), "FAB");

                            atLogic.BusinessProcess bp = fmAB.GetBP();
                            bp.AddForUpdate(fmAB.GetFileOffice());
                            bp.AddForUpdate(fmAB.GetPerson());
                            bp.AddForUpdate(fmAB.GetFileContact());
                            bp.AddForUpdate(fmAB.EFile);
                            bp.Update();


                        }
                        catch (Exception x)
                        {

                            fmAB.DB.RejectChanges();
                            throw x;
                        }

                        break;
                    case "tsMyFile":
                        if (CurrentRow().IsMyFileIdNull() || (!CurrentRow().IsMyFileIdNull() && MessageBox.Show(LawMate.Properties.Resources.PersonalFileAlreadyExists, LawMate.Properties.Resources.CreatePersonalFile, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            fBrowse f = new fBrowse(FM.AtMng, FM.CurrentFile.FileId, true, true, true, true);
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                FM.LeadOfficeMng.GetOfficer().CreatePersonalFiles(f.SelectedFile.FileId, CurrentRow(), LawMate.Properties.Settings.Default.UseSeparatePersonalFiles);
                                Save();
                            }
                        }
                        break;
                    case "tsSave":
                        Save();
                        break;
                    case "tsDelete":
                        Delete();
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                    case "tsNew":
                        //officerBindingSource.AddNew();
                        officeDB.OfficerRow or = (officeDB.OfficerRow)FM.LeadOfficeMng.GetOfficer().Add(FM.LeadOfficeMng.CurrentOffice);
                        officerBindingSource.Position = officerBindingSource.Find("OfficerId", or.OfficerId);
                        break;
                    case "tsOfficeMailView":
                        FileForm().MainForm.OpenBFList(CurrentRow());
                        break;
                    case "tsOfficerBFList":
                        FileForm().MainForm.OpenBFList(CurrentRow());

                        break;
                    case "tsResetPassword":

                        break;
                    case "tsGroupBy":
                        if (e.Command.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            officerGridEX.GroupByBoxVisible = true;
                        else
                            officerGridEX.GroupByBoxVisible = false;
                        break;
                    case "tsFilter":
                        if (e.Command.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            officerGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            officerGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "tsSecurity":
                        Save();
                        fSecurity fs = new fSecurity();
                        fs.Init(FM.AtMng.SecurityManager, CurrentRow());
                        fs.ShowDialog();
                        Save();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void Cancel()
        {
            ApplyBR(true);
            UIHelper.Cancel(officerBindingSource);
            UIHelper.Cancel(officerRoleBindingSource, FM.LeadOfficeMng.DB.OfficerRole);
            UIHelper.Cancel(officerDelegateBindingSource, FM.LeadOfficeMng.DB.OfficerDelegate);
            UIHelper.Cancel(contactEmailBindingSource, FM.LeadOfficeMng.DB.ContactEmail);
            UIHelper.Cancel(memberProfileBindingSource, FM.LeadOfficeMng.DB.MemberProfile);
            UIHelper.Cancel(addressBindingSource, FM.DB.Address);
        }

        private void officerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                officeDB.OfficerRow dr = CurrentRow();

                if (dr == null)
                    return;

                if (dr.IsNull("OfficerId"))
                    return;


                if (!myLoadedOfficers.Contains(dr.OfficerId))
                {
                    myLoadedOfficers.Add(dr.OfficerId);
                    //load emails and delegates
                    FM.LeadOfficeMng.GetOfficerDelegate().LoadByOfficerId(dr.OfficerId);

                    FM.LeadOfficeMng.GetMemberProfile().Load(dr.OfficerId);

                    //load roles
                    FM.LeadOfficeMng.GetOfficerRole().LoadByOfficerID(dr.OfficerId);
                    FM.LeadOfficeMng.GetContactEmail().LoadByContactId(dr.OfficerId);
                }

                if ((dr.IsNull("PositionCode")) || (dr.PositionCode != "TM"))
                {
                    tribunalTabPage.Enabled = false;
                }
                else
                {
                    displayMemberProfile();

                }

                if (!dr.IsActiveNull())
                {
                    pnlDelegateRole.Enabled = true;
                    pnlPersonalFiles.Enabled = true;
                    tsMyFile.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                }
                else
                {
                    pnlDelegateRole.Enabled = false;
                    pnlPersonalFiles.Enabled = false;
                    tsMyFile.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                }

                ApplySecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void displayMemberProfile()
        {
            tribunalTabPage.Enabled = true;

            if (CurrentRow().GetMemberProfileRows().Length == 0)
            {
                FM.LeadOfficeMng.GetMemberProfile().Add(CurrentRow());
            }
            if (memberProfileBindingSource.Count > 0)
            {
                int pos = memberProfileBindingSource.Find("OfficerId", CurrentRow().OfficerId);
                memberProfileBindingSource.Position = pos;
            }

            //ucAddress
            if (CurrentRow().IsAddressCurrentIDNull())
            {
                addAddressBtn.Visible = true;
                addressGroupBox.Visible = false;
                ucAddress.Visible = false;
            }
            else
            {


                addAddressBtn.Visible = false;
                addressGroupBox.Visible = true;
                ucAddress.Visible = true;
                if (FM.DB.Address.FindByAddressId(CurrentRow().AddressCurrentID) == null)
                {
                    FM.GetAddress().LoadByContactId(CurrentRow().OfficerId);
                }
                int adrpos = addressBindingSource.Find("AddressId", CurrentRow().AddressCurrentID);
                addressBindingSource.Position = adrpos;
            }

        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            FM.LeadOfficeMng.GetContactEmail().Add(CurrentRow());
        }

        private void btnNewDelegate_Click(object sender, EventArgs e)
        {
            FM.LeadOfficeMng.GetOfficerDelegate().Add(CurrentRow());
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            FM.LeadOfficeMng.GetOfficerRole().Add(CurrentRow());
        }

        private void officerGridEX_SelectionChanged(object sender, EventArgs e)
        {
            if (officerGridEX.CurrentRow == null)
                return;
            else
            {
                if (FM.AtMng.GetSetting(atriumBE.AppBoolSetting.useOutOfOfficeFunctionality))
                {
                    if (FM.AtMng.SecurityManager.CanExecute(FM.CurrentFileId, atSecurity.SecurityManager.Features.Officer) == atSecurity.SecurityManager.ExPermissions.Yes)
                    {
                        uiTabPage5.Enabled = true;
                        if (chkOutOfOffice.Checked)
                        {
                            if (endDateCalendarCombo.Value < DateTime.Now)
                            {
                                CurrentRow().OutOfOffice = false;
                                chkOutOfOffice.Checked = false;
                                Save();
                            }
                        }
                        EnableDates(chkOutOfOffice.Checked);
                    }
                    else
                    {
                        uiTabPage5.Enabled = false;
                    }
                }
            }

        }
        private void EnableDates(bool enabled)
        {
            //calEditMode = true;
            startDateCalendarCombo.Enabled = enabled;
            endDateCalendarCombo.Enabled = enabled;
            startTimeCalendarCombo.Enabled = enabled;
            endTimeCalendarCombo.Enabled = enabled;


        }

        private void officerGridEX_LayoutLoad(object sender, EventArgs e)
        {
            officerGridEX.MoveFirst();
        }

        private void officerGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
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

        private void tribunalTabPage_Click(object sender, EventArgs e)
        {

        }

        private void gbParticipant_Click(object sender, EventArgs e)
        {

        }

        private void addAddressBtn_Click(object sender, EventArgs e)
        {
            ucAddress.Visible = true;
            addressGroupBox.Visible = true;
            addAddressBtn.Visible = false;
            atriumDB.AddressRow ar = (atriumDB.AddressRow)FM.GetAddress().Add(CurrentRow());
            //CurrentRow().AddressCurrentID = ar.AddressId;
            //ar.ContactId = CurrentRow().OfficerId;
            int adrpos = addressBindingSource.Find("AddressId", CurrentRow().AddressCurrentID);
            addressBindingSource.Position = adrpos;
        }

        private void memberProfileTab_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {

        }

        private void chkOutOfOffice_CheckedChanged(object sender, EventArgs e)
        {
            EnableDates(chkOutOfOffice.Checked);
        }

        private void officerDelegateGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DeleteDelegate();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void DeleteDelegate()
        {
            if (CurrentRowDelegate() == null)
                return;

            if (UIHelper.ConfirmDelete())
            {
                CurrentRowDelegate().Delete();
                officerDelegateBindingSource.EndEdit();
            }
        }
        private void DeleteRole()
        {
            if (CurrentRowRole() == null)
                return;

            if (UIHelper.ConfirmDelete())
            {
                CurrentRowRole().Delete();
                officerRoleBindingSource.EndEdit();
            }
        }

        private void officerRoleGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DeleteRole();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucOfficePersonnel_Load(object sender, EventArgs e)
        {
            try
            {
                officerGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

