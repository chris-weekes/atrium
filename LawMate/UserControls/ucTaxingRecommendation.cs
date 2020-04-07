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
    public partial class ucTaxingRecommendation : ucBase
    {
        bool forOffice = false;
        public ucTaxingRecommendation()
        {
            InitializeComponent();
        }
        public void bindTaxRecData(lmDatasets.CLAS.TaxingDataTable dt,bool _forOffice)
        {
            forOffice = _forOffice;

            UIHelper.ComboBoxInit("ReasonCode", reasonCodeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("ReasonCode", taxingGridEX.DropDowns["ddReason"], FM);
            UIHelper.ComboBoxInit("vofficerlist", taxingGridEX.DropDowns["ddOfficer"], FM);
            officeIDucOfficeSelectBox.AtMng = FM.AtMng;
            officerIDucContactSelectBox.FM = FM;
            fileIDucFileSelectBox.AtMng = FM.AtMng;

            setBindingSources(); 
          
            //setBSFilter();

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetCLASMng().GetTaxing().OnUpdate += new atLogic.UpdateEventHandler(ucTaxingRecommendation_OnUpdate);

            ApplySecurity(CurrentRow());

        }

      
        public override bool controlHasBorder()
        {
            return false;
        }

        //private void setBSFilter()
        //{
        //    bool viewAll = (FM.AtMng.WorkingAsOfficer.OfficeId == FM.CurrentFile.OwnerOfficeId);
        //    if (FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
        //        viewAll = true;

        //    if (!viewAll)
        //    {
        //        taxingBindingSource.Filter = "OfficeId = " + FM.AtMng.WorkingAsOfficer.OfficeId;
        //    }

        //}

        void ucTaxingRecommendation_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                {
                    ApplyBR(false);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.TaxingRecommendation;
        }

        private void setBindingSources()
        {
            if (forOffice)
            {
                FM.GetCLASMng().GetTaxing().LoadByOfficeID(FM.CurrentFile.LeadOfficeId);
            }


            taxingBindingSource.DataMember = FM.GetCLASMng().DB.Taxing.TableName;
            taxingBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            taxingGridEX.MoveFirst();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void EndEdit()
        {
            taxingBindingSource.EndEdit();
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(taxingBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }

        public override void ApplySecurity(DataRow dr)
        {
            if (dr == null)
            {
                UIHelper.EnableControls(taxingBindingSource, false);
                UIHelper.EnableCommandBarCommand(tsDelete, false);
                btnJumpToIRP.Visible = false;
            }
            else
            {
                CLAS.TaxingRow cbr = (CLAS.TaxingRow)dr;
                UIHelper.EnableControls(taxingBindingSource, FM.GetCLASMng().GetTaxing().CanEdit(cbr));
                UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetTaxing().CanDelete(cbr));
                btnJumpToIRP.Visible = !cbr.IsIRPIdNull(); //allow jumping to billing file if tax rec linked to IRP
            }
            closedUICheckBox.Enabled = false;
            
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
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }
        public override void MoreInfo(string linkTable, string filter)
        {
            taxingBindingSource.Filter = filter;
        }
        public override void MoreInfo(string linkTable, int linkId)
        {
            taxingBindingSource.Position =taxingBindingSource.Find("TaxingId", linkId);
        }

        public override void Save()
        {
            if (FM.GetCLASMng().DB.Taxing.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.taxingBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetTaxing());
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
                //would like to have most of this moved to BE CanDelete, but the UI interaction with the confirm messages makes it impossible at the moment
                bool okToDelete=false;
                if (CurrentRow().Closed)
                {
                    //since it's closed, candelete will return true if canoverride=true
                    if (FM.GetCLASMng().GetTaxing().CanDelete(CurrentRow()))
                    {
                        //check to see if IRPId is null; if so, who cares about link back to irp, there is none; go ahead and chuck
                        if (CurrentRow().IsIRPIdNull())
                            okToDelete = true;
                        else
                        {
                            //check state of srp to see if taxation completed; if so, warn about impact
                            //loading irp and srp data to read it
                            atriumDB.IRPRow irpRow = FM.DB.IRP.FindByIRPId(CurrentRow().IRPId);
                            if (irpRow == null)
                            {
                                //a LoadByIRPID would be nice here ... but whatever, only called when deleting a taxrec by an overrider, very isolated
                                FM.GetIRP().Load();
                                irpRow = FM.DB.IRP.FindByIRPId(CurrentRow().IRPId);
                            }
                            atriumDB.SRPRow srpRow = FM.GetSRP().Load(irpRow.SRPID);

                            if (!srpRow.IsTaxationCompletedNull())
                            {
                                if (MessageBox.Show("This taxing recommendation is closed and linked to an IRP for which taxation has been completed on the SRP.  You cannot modify the IRP values as they are read-only.\n\nAre you sure you want to proceed with deleting this linked and closed taxing recommendation?", "Closed and Linked Taxing Recommendation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                    okToDelete = true;
                            }
                            else // taxation not completed yet
                            {
                                if (MessageBox.Show("This taxing recommendation is closed and linked to an IRP for which taxation is not completed on the SRP.  You may still modify the IRP values to account for the deleting of this taxing recommendation if need be.\n\nAre you sure you want to proceed with deleting this linked and closed taxing recommendation?", "Closed and Linked Taxing Recommendation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                    okToDelete = true;
                            }

                            //if taxation not completed, explain that taxed amounts can still be manipulated until SRP taxation completed date populated
                        }
                    }
                }
                else
                {//JLL: 2016/09/28, added Else so taxrec gets delete when not closed
                    if (FM.GetCLASMng().GetTaxing().CanDelete(CurrentRow()))
                        okToDelete = true;
                }

                if (okToDelete)
                {
                    CurrentRow().Delete();
                    taxingBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetTaxing());
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


        private CLAS.TaxingRow CurrentRow()
        {
            if (taxingBindingSource.Current == null)
                return null;
            else
                return (CLAS.TaxingRow)((DataRowView)taxingBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(taxingBindingSource);
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

        private void taxingBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                //if (CurrentRow()==null || CurrentRow().IsNull("TaxingID"))
                //    return;

                ApplySecurity(CurrentRow());

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnJumpToIRP_Click(object sender, EventArgs e)
        {
            try
            {
                fFile fileToView = FileForm().MainForm.OpenFile(CurrentRow().FileID);
                fileToView.MoreInfo("irp", CurrentRow().IRPId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }

        private void ucTaxingRecommendation_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                taxingGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

