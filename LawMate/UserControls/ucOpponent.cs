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
    public partial class ucOpponent : ucBase
    {
        public ucOpponent()
        {
            InitializeComponent();
        }

        public void bindDebtorData(CLAS.DebtorDataTable a)
        {
            UIHelper.ComboBoxInit("Sex", ucSexCodeMcc, FM);
            UIHelper.ComboBoxInit("LanguageCode", ucLanguageCodeMcc, FM);
            UIHelper.ComboBoxInit("AddressType", ucAddressTypeMcc, FM);
            UIHelper.ComboBoxInit("AddressSource", ucAddressSourceMcc, FM);
            UIHelper.ComboBoxInit("Province", addressGridEX.DropDowns["ddProvince"], FM);
            UIHelper.ComboBoxInit("Country", addressGridEX.DropDowns["ddCountry"], FM);
            UIHelper.ComboBoxInit("AddressType", addressGridEX.DropDowns["ddAddressType"], FM);
            
            this.debtorBindingSource.DataSource = a.DataSet;
            this.debtorBindingSource.DataMember = a.TableName;

            DataView dvAKA = new DataView(FM.DB.AKA, "ContactID="+CurrentRow().ContactId.ToString(), "", DataViewRowState.CurrentRows);
            this.aKABindingSource.DataSource = dvAKA;

            DataView dvAddr = new DataView(FM.DB.Address, "ContactID=" + CurrentRow().ContactId.ToString(), "", DataViewRowState.CurrentRows);
            this.addressBindingSource.DataSource = dvAddr;

            ucAddress1.FM = FM;
            ucAddress1.DataSource = addressBindingSource;

            FM.DB.Address.ColumnChanged += new DataColumnChangeEventHandler(Address_ColumnChanged);
            a.ColumnChanged += new DataColumnChangeEventHandler(Address_ColumnChanged);

            FM.GetCLASMng().GetDebtor().OnUpdate += new atLogic.UpdateEventHandler(ucOpponent_OnUpdate);
            FM.GetAddress().OnUpdate += new atLogic.UpdateEventHandler(ucOpponent_OnUpdate);

            SelectCurrentAddress();
            ValidateLastKnownAddress(CurrentRow());
        }

        private void SelectCurrentAddress()
        {
            //set current address
            if (!CurrentRow().IsAddressCurrentIDNull())
                addressBindingSource.Position = addressBindingSource.Find("AddressID", CurrentRow().AddressCurrentID);
            else
                uiTabPage5.TabVisible = false;

        }

        void ucOpponent_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }
        
        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.DebtorInformation;
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        public override void ReloadUserControlData()
        {
            SelectCurrentAddress();
            ValidateLastKnownAddress(CurrentRow());
        }

        void Address_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (CurrentRowAddress() == null)
                    return;
                if (FM.IsFieldChanged(e.Column, e.Row))
                    ApplyBR(false);
               ///if (e.Column.Table.TableName == "Address" &&  CurrentRowAddress().Current)
                //{
                //    lblEditingCurrentAddress.Visible = true;
                //}
                
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(debtorBindingSource, !makeReadOnly);
            UIHelper.EnableControls(aKABindingSource, !makeReadOnly);
            UIHelper.EnableControls(addressBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled = !makeReadOnly;
            uiCommandBar3.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                aKAGridEX.RootTable.Columns["colDelete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Image;
                addressGridEX.RootTable.Columns["colDelete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Image;
                ApplySecurity(CurrentRow());
                ApplyAddressSecurity(CurrentRowAddress());
                ApplyAKASecurity(CurrentRowAKA());
            }
            else
            {
                aKAGridEX.RootTable.Columns["colDelete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                addressGridEX.RootTable.Columns["colDelete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
            }
        }

        public override void EndEdit()
        {
            addressBindingSource.EndEdit();
            debtorBindingSource.EndEdit();
        }

        private void ValidateLastKnownAddress(DataRow dr)
        {
            CLAS.DebtorRow cbr = (CLAS.DebtorRow)dr;
            if (cbr.AddressNotCurrent)
            {
                uiCheckBox1.ForeColor = Color.Red;
                uiCheckBox1.Image = Properties.Resources.warning_16x16;
            }
            else
            {
                uiCheckBox1.ForeColor = SystemColors.ControlText;
                uiCheckBox1.Image = null;
            }
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

            InEditMode = !DataNotDirty;
            
            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
            ValidateLastKnownAddress(CurrentRow());
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ApplySecurity(DataRow dr)
        {
            CLAS.DebtorRow cbr = (CLAS.DebtorRow)dr;
            bool okToEdit = FM.GetCLASMng().GetDebtor().CanEdit(cbr);
            UIHelper.EnableControls(debtorBindingSource, okToEdit);
            
            addressGridEX.RootTable.Columns["colDelete"].Visible = okToEdit;
            aKAGridEX.RootTable.Columns["colDelete"].Visible = okToEdit;
        }

        public void ApplyAddressSecurity(DataRow dr)
        {
            if (dr != null)
                UIHelper.EnableControls(addressBindingSource, FM.GetCLASMng().GetDebtor().CanEdit(CurrentRow()));
        }

        public void ApplyAKASecurity(DataRow dr)
        {
            if (dr != null)
                UIHelper.EnableControls(aKABindingSource, FM.GetCLASMng().GetDebtor().CanEdit(CurrentRow()));
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            debtorBindingSource.Position = debtorBindingSource.Find("DebtorId", linkId);
        }

        public override void Save()
        {
            if (FM.GetCLASMng().DB.Debtor.HasErrors  )
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetCLASMng().DB);
            }
            else if(FM.DB.Address.HasErrors)
            {
                 UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.debtorBindingSource.EndEdit();
                    this.addressBindingSource.EndEdit();
                    
                    FM.SaveAll();
                    
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
            throw new Exception("not yet implemented.");
        }

        private void DeleteAKA()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowAKA().Delete();
                    aKABindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetAKA());
                    
                    bp.Update();

                 
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void DeleteAddress()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowAddress().Delete();
                    addressBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetAddress());
                    bp.Update();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private CLAS.DebtorRow CurrentRow()
        {
            if (debtorBindingSource.Current == null)
                return null;
            else
                return (CLAS.DebtorRow)((DataRowView)debtorBindingSource.Current).Row;
        }

        private atriumDB.AddressRow CurrentRowAddress()
        {
            if (addressBindingSource.Current == null)
                return null;
            else
                return(atriumDB.AddressRow)((DataRowView)addressBindingSource.Current).Row;
        }

        private atriumDB.AKARow CurrentRowAKA()
        {
            if (aKABindingSource.Current == null)
                return null;
            else
                return(atriumDB.AKARow)((DataRowView)aKABindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(debtorBindingSource);
            UIHelper.Cancel(addressBindingSource, FM.DB.Address);
            UIHelper.Cancel(aKABindingSource);
            ApplyBR(true);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
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
                }
          }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void aKAGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DeleteAKA(); 
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void addressGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (CurrentRowAddress().Current)
                    throw new LMException(LawMate.Properties.Resources.UICantDeleteCurrentAddress);

                DeleteAddress();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void debtorBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CLAS.DebtorRow dr = CurrentRow();
            ApplySecurity(dr);
        }

        private void addressBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            atriumDB.AddressRow dr = CurrentRowAddress();
            uiTabPage5.TabVisible = (dr != null);

            ApplyAddressSecurity(dr);

            string mask = FM.GetAddress().PhoneMask(CurrentRowAddress());
            maskedEditBox1.Mask = mask;
            maskedEditBox2.Mask = mask;
            maskedEditBox3.Mask = mask;


        }

        private void aKABindingSource_CurrentChanged(object sender, EventArgs e)
        {
            atriumDB.AKARow dr = CurrentRowAKA();
            ApplyAKASecurity(dr);

        }

        private void addressGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
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

        private void addressGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (!CurrentRow().IsAddressCurrentIDNull())
                {
                    if (e.Row.Cells["AddressId"].Value.ToString() == CurrentRow().AddressCurrentID.ToString())
                        e.Row.Cells["isCurrentAddress"].Value = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucOpponent_Load(object sender, EventArgs e)
        {
            try
            {
                //2017-08-31 JLL: readonly user issue: all fields enabled and not readonly even though EnableControls value appropriately set to false
                //readonly hack - without it, fields are enabled and not readonly, ApplySecurity moved from BindData method to control's Load method
                //there appears to be a consistent issue here with screens without grids that the fields are inappropriately set to an enabled/not readonly set mistakenly
                ApplySecurity(CurrentRow());
                ApplyAddressSecurity(CurrentRowAddress());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

