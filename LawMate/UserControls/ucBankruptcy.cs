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
    public partial class ucBankruptcy : ucBase
    {
        public ucBankruptcy()
        {
            InitializeComponent();
        }


        public void bindBankruptcyData(CLAS.BankruptcyDataTable dt)
        {
            officeIDucOfficeSelectBox.AtMng = FM.AtMng;
            setBindingSources();
            UIHelper.ComboBoxInit("BankruptcyOrderType", bankruptcyOrderTypeucMultiDropDown, FM);
            UIHelper.ComboBoxInit(FM.Codes("InsolvencyPeriod"), mccInsolvencyPeriod, FM);

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetCLASMng().GetBankruptcy().OnUpdate += new atLogic.UpdateEventHandler(ucBankruptcy_OnUpdate);

        }

        void ucBankruptcy_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);

        }

        public override bool controlHasBorder()
        {
            return false;
        }

        public override void EndEdit()
        {
            bankruptcyBindingSource.EndEdit();
        }

        private int NavId = -1;
        public override void MoreInfo(string linkTable, int linkId)
        {
            bankruptcyBindingSource.Position = bankruptcyBindingSource.Find("BankruptcyId", linkId);
            NavId = linkId;
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
            return LawMate.Properties.Resources.Bankruptcy;
        }

        private void setBindingSources()
        {
            bankruptcyBindingSource.DataMember = FM.GetCLASMng().DB.Bankruptcy.TableName;
            bankruptcyBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            MoreInfo("Bankruptcy", NavId);
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
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
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                InEditMode = false;
                //tsEditmode.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                InEditMode = true; 
                //tsEditmode.Visible = Janus.Windows.UI.InheritableBoolean.True;
            }

            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
        }


        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(bankruptcyBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }


        public override void ApplySecurity(DataRow brow)
        {
            CLAS.BankruptcyRow br = (CLAS.BankruptcyRow)brow;
            
            UIHelper.EnableControls(bankruptcyBindingSource, FM.GetCLASMng().GetBankruptcy().CanEdit(br));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetBankruptcy().CanDelete(br));

            cSLNonDischargeableUICheckBox.Enabled = false;
        }


        public override void Save()
        {
            if (FM.GetCLASMng().DB.Bankruptcy.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetCLASMng().DB);
            }
            else
            {
                try
                {
                    this.bankruptcyBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();

                    bp.AddForUpdate(FM.GetCLASMng().GetBankruptcy());
                    bp.AddForUpdate(FM.EFile);

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

        public override void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    this.bankruptcyBindingSource.EndEdit();

                   
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

        public override void Cancel()
        {
            UIHelper.Cancel(bankruptcyBindingSource);
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
                        fData fAudit = new fData(CurrentRow()) ;
                        fAudit.Show();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private CLAS.BankruptcyRow CurrentRow()
        {
            if (bankruptcyBindingSource.Current == null)
                return null;
            else
                return (CLAS.BankruptcyRow)((DataRowView)bankruptcyBindingSource.Current).Row;
        }


        private void bankruptcyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("BankruptcyID"))
                    return;

                //apply security
                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void bankruptcyDateCalendarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            UIHelper.TodaysDateShortcutKey(sender, e);
        }

        private void ucBankruptcy_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

