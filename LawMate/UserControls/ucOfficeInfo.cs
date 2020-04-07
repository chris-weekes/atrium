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
    public partial class ucOfficeInfo : ucBase
    {
        public ucOfficeInfo()
        {
            InitializeComponent();
        }

        public void bindOfficeData(lmDatasets.officeDB.OfficeDataTable dt)
        {
            
            ucMultiDropDown1.SetDataBinding(FM.Codes("OfficeList"), "");
            ucMultiDropDown2.SetDataBinding(FM.Codes("OfficeType"), "");
            ucMultiDropDown3.SetDataBinding(FM.Codes("AppointmentType"), "");
            ucMultiDropDown4.SetDataBinding(FM.Codes("CurrencyCode"), "");
            UIHelper.ComboBoxInit("Department", mccDepartment, FM);
            UIHelper.ComboBoxInit(FM.Codes("OfficeList"), mccBranch, FM);
            UIHelper.ComboBoxInit(FM.Codes("TaxRate"), mccDefaultTaxRate, FM);

            officeBindingSource.DataSource = dt.DataSet;
            officeBindingSource.DataMember = dt.TableName;

            DataView dv;
            if (CurrentRow().IsAddressIdNull())
            {
                atriumDB.AddressRow addr= (atriumDB.AddressRow)FM.GetAddress().Add(CurrentRow());
                dv = new DataView(FM.DB.Address, "AddressId=" + addr.AddressId.ToString(), "", DataViewRowState.CurrentRows);
            }
            else
                dv = new DataView(FM.DB.Address, "AddressId=" + CurrentRow().AddressId.ToString(), "", DataViewRowState.CurrentRows);

            this.addressBindingSource.DataSource = dv;

            ucAddress1.FM = FM;
            ucAddress1.DataSource = addressBindingSource;

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.DB.Address.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);

            FM.LeadOfficeMng.GetOffice().OnUpdate += new atLogic.UpdateEventHandler(ucOfficeInfo_OnUpdate);
            FM.GetAddress().OnUpdate += new atLogic.UpdateEventHandler(ucOfficeInfo_OnUpdate);

        }
        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.OfficeInformation;
        }
        void ucOfficeInfo_OnUpdate(object sender, atLogic.UpdateEventArgs e)
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
                ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(officeBindingSource, !makeReadOnly);
            UIHelper.EnableControls(addressBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            //ucAddress1.Enabled = !makeReadOnly;
            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }

        public override void ReloadUserControlData()
        {
            FM.LeadOfficeMng.GetOffice().PreRefresh();
            FM.GetAddress().PreRefresh();
            
            lmDatasets.officeDB.OfficeRow or = FM.LeadOfficeMng.GetOffice().LoadByOfficeFileId(FM.CurrentFile.FileId);
            FM.GetAddress().Load(or.AddressId);
        }

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
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            officeDB.OfficeRow cbr = (officeDB.OfficeRow)dr;
            UIHelper.EnableControls(officeBindingSource, FM.LeadOfficeMng.GetOffice().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.LeadOfficeMng.GetOffice().CanDelete(cbr));
            ApplyAddressSecurity(CurrentRowAddress());

        }
        public void ApplyAddressSecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            if (dr != null)
                UIHelper.EnableControls(addressBindingSource, FM.LeadOfficeMng.GetOffice().CanEdit(CurrentRow()));
        }
        public override void Save()
        {
            if (FM.LeadOfficeMng.DB.Office.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.officeBindingSource.EndEdit();
                    this.addressBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.LeadOfficeMng.GetOffice());
                    bp.AddForUpdate(FM.GetAddress());
                    bp.Update();
                    
                  

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
        private lmDatasets.officeDB.OfficeRow CurrentRow()
        {
            if (officeBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.officeDB.OfficeRow)((DataRowView)officeBindingSource.Current).Row;
        }
        private lmDatasets.atriumDB.AddressRow CurrentRowAddress()
        {
            if (addressBindingSource.Current == null)
                return null;
            else
                return(lmDatasets.atriumDB.AddressRow)((DataRowView)addressBindingSource.Current).Row;
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            officeBindingSource.Position = officeBindingSource.Find("OfficeId", linkId);
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

        public override  void Cancel()
        {
            UIHelper.Cancel(officeBindingSource);
            UIHelper.Cancel(addressBindingSource);
            ApplyBR(true);
        }

        private void officeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            officeDB.OfficeRow dr = CurrentRow();
            if (dr == null)
                return;

            ApplySecurity(dr);
        }

        private void addressBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            atriumDB.AddressRow dr = CurrentRowAddress();
            ApplyAddressSecurity(dr);

            string mask= FM.GetAddress().PhoneMask(CurrentRowAddress());
            maskedEditBox1.Mask =mask;
            maskedEditBox2.Mask = mask;
            maskedEditBox3.Mask = mask;
        }

        private void ucOfficeInfo_Load(object sender, EventArgs e)
        {
            try
            {
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

