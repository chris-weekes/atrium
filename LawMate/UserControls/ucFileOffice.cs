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
    public partial class ucFileOffice : ucBase
    {
        fFile f;

        public ucFileOffice()
        {
            InitializeComponent();
        }
        public void bindFileOfficeData(lmDatasets.atriumDB.FileOfficeDataTable dt)
        {
            officeIducOfficeSelectBox.AtMng = FM.AtMng;

            fileOfficeBindingSource.DataSource = dt.DataSet;
            fileOfficeBindingSource.DataMember = dt.TableName;

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetFileOffice().OnUpdate += new atLogic.UpdateEventHandler(ucFileOffice_OnUpdate);

            ApplySecurity(CurrentRow());
        }

        void ucFileOffice_OnUpdate(object sender, atLogic.UpdateEventArgs e)
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

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(fileOfficeBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());

        }
        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }
        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.FileOffice;
        }
        public override void ReloadUserControlData()
        {
            //FM.GetFileOffice().PreRefresh();
            //FM.GetFileOffice().LoadByFileId(FM.CurrentFileId);
            fileOfficeGridEX.MoveFirst();
        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            atriumDB.FileOfficeRow cbr = (atriumDB.FileOfficeRow)dr;
            UIHelper.EnableControls(fileOfficeBindingSource, FM.GetFileOffice().CanEdit(cbr));
            if(!InEditMode)
                UIHelper.EnableCommandBarCommand(tsDelete, FM.GetFileOffice().CanDelete(cbr));
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

            if (DataNotDirty)
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
            InEditMode = !DataNotDirty;
        }

        public override void EndEdit()
        {
            fileOfficeBindingSource.EndEdit();
        }

        private atriumDB.FileOfficeRow CurrentRow()
        {
            if (fileOfficeBindingSource.Current != null)
                return (atriumDB.FileOfficeRow)((DataRowView)fileOfficeBindingSource.Current).Row;
            else
                return null;
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            fileOfficeBindingSource.Position = fileOfficeBindingSource.Find("FileOfficeId", linkId);
        }

        public override void Save()
        {
            if (FM.DB.FileOffice.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    fileOfficeBindingSource.EndEdit();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();
                    //bp.AddForUpdate(FM.GetFileOffice());
                    //bp.AddForUpdate(FM.EFile);
                    //bp.Update();
                    ApplyBR(true);

                    f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();

                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
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
                    fileOfficeBindingSource.EndEdit();

                    FM.SaveAll();
                  
                    ApplyBR(true);

                    f = (fFile)this.ParentForm;
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
            UIHelper.Cancel(fileOfficeBindingSource);
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

        private void fileOfficeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentRow() != null)
            {
                atriumDB.FileOfficeRow cbr = CurrentRow();
                ApplySecurity(cbr);
            }
        }

        private void ucFileOffice_Load(object sender, EventArgs e)
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

