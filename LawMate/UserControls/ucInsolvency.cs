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
    public partial class ucInsolvency : ucBase
    {
        public ucInsolvency()
        {
            InitializeComponent();
        }

        public void bindInsolvencyData(lmDatasets.CLAS.InsolvencyDataTable dt)
        {
            UIHelper.ComboBoxInit("InsolvencyType", ucInsolvencyTypeMcc, FM);

            setBindingSources();

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetCLASMng().GetInsolvency().OnUpdate += new atLogic.UpdateEventHandler(ucInsolvency_OnUpdate);

            ApplySecurity(CurrentRow());
        }

        void ucInsolvency_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        public override string ucDisplayName()
        {
            return Properties.Resources.DisplayNameInsolvency;
        }

        private void setBindingSources()
        {
            insolvencyBindingSource.DataMember = FM.GetCLASMng().DB.Insolvency.TableName;
            insolvencyBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            MoreInfo("Insolvency", NavId);
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
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
            insolvencyBindingSource.EndEdit();
        }

        public override void ApplySecurity(DataRow dr)
        {
            CLAS.InsolvencyRow cbr = (CLAS.InsolvencyRow)dr;
            UIHelper.EnableControls(insolvencyBindingSource, FM.GetCLASMng().GetInsolvency().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetInsolvency().CanDelete(cbr));

            //always keep disabled
            cSLNonDischargeableUICheckBox.Enabled = false;

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
            }
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                InEditMode = true;
            }
            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(insolvencyBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        private int NavId = -1;
        public override void MoreInfo(string linkTable, int linkId)
        {
            insolvencyBindingSource.Position = insolvencyBindingSource.Find("InsolvencyID", linkId);
            NavId = linkId;
        }

        public override void Save()
        {
            if (FM.GetCLASMng().DB.Insolvency.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetCLASMng().DB);
            }
            else
            {
                try
                {
                    this.insolvencyBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetInsolvency());
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
                    insolvencyBindingSource.EndEdit();

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

        private CLAS.InsolvencyRow CurrentRow()
        {
            if (insolvencyBindingSource.Current == null)
                return null;
            else
                return (CLAS.InsolvencyRow)((DataRowView)insolvencyBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(insolvencyBindingSource);
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


        private void insolvencyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("InsolvencyID"))
                    return;

                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucInsolvency_Load(object sender, EventArgs e)
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

