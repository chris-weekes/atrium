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
    public partial class ucHardship : ucBase
    {
        public ucHardship()
        {
            InitializeComponent();
        }

        public void BindData(CLAS.HardshipDataTable a)
        {

            setBindingSources();

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetCLASMng().GetHardship().OnUpdate += new atLogic.UpdateEventHandler(uc_OnUpdate);

        }

        void uc_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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
        private CLAS.HardshipRow CurrentRow()
        {
            if (hardshipBindingSource.Current == null)
                return null;
            else
                return (CLAS.HardshipRow)((DataRowView)hardshipBindingSource.Current).Row;
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.DisplayNameHardship;
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(hardshipBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
           

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());

        }

        private void setBindingSources()
        {
            hardshipBindingSource.DataMember = FM.GetCLASMng().DB.Hardship.TableName;
            hardshipBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            gridEX1.MoveFirst();
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

            CLAS.HardshipRow cbr = (CLAS.HardshipRow)dr;
            UIHelper.EnableControls(hardshipBindingSource , FM.GetCLASMng().GetHardship().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetHardship().CanDelete(cbr));
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            hardshipBindingSource.Position = hardshipBindingSource.Find("HardshipId", linkId);
        }
        public override void Save()
        {
            if (FM.GetAdvisoryMng().DB.Opinion.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.hardshipBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetHardship());
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
                    this.hardshipBindingSource.EndEdit();

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
            UIHelper.Cancel(hardshipBindingSource);
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

        private void ucHardship_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                gridEX1.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
