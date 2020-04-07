using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using System.Linq;

 namespace LawMate
{
    public partial class ucSSTDetail : ucBase
    {
        atriumBE.SSTManager SSTM;

        public ucSSTDetail()
        {
            InitializeComponent();
        }

        public void bindData(lmDatasets.SST.SSTCaseDataTable dt)
        {
            SSTM = FM.GetSSTMng();
            setBindingSources();

            UIHelper.ComboBoxInit(FM.Codes("vFlagCode"), FlagCodeMultiDropDown, FM);

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.DB.FileFlag.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);

            SSTM.GetSSTCase().OnUpdate += new atLogic.UpdateEventHandler(ucSSTCase_OnUpdate);
            FM.GetFileFlag().OnUpdate += new atLogic.UpdateEventHandler(ucSSTCase_OnUpdate);
            
            AddFileFlagButton.Enabled = false;

        }

        private void setBindingSources()
        {
            sSTCaseBindingSource.DataMember = SSTM.DB.SSTCase.TableName;
            sSTCaseBindingSource.DataSource = SSTM.DB;
            FileFlagBindingSource.DataMember = FM.DB.FileFlag.TableName;
            FileFlagBindingSource.DataSource = FM.DB;
        }

        void ucSSTCase_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName == "Received365Date")
                    return;
                if (e.Column.ColumnName == "IsLate365")
                    return;

                if (FM.IsFieldChanged(e.Column, e.Row))
                    ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override string ucDisplayName()
        {
            return Properties.Resources.DisplayNameSSTAppeal;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void EndEdit()
        {
            sSTCaseBindingSource.EndEdit();
        }

        public override void ApplySecurity(DataRow dr)
        {
            SST.SSTCaseRow cbr = (SST.SSTCaseRow)dr;
            UIHelper.EnableControls(sSTCaseBindingSource, SSTM.GetSSTCase().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, SSTM.GetSSTCase().CanDelete(cbr));

            //Keep these fields disabled at all times, regardless of CanEdit call above
            voluntaryUICheckBox.Enabled = false;
            mQPAgreedUICheckBox.Enabled = false;
            maxRetroactivityUICheckBox.Enabled = false;
            disabledUICheckBox.Enabled = false;
            isDeceasedUICheckBox.Enabled = false;
            isIncapacitatedUICheckBox.Enabled = false;
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
            lmWinHelper.EditModeCommandToggle(tsEditMode, InEditMode);
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(sSTCaseBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            sSTCaseBindingSource.Position = sSTCaseBindingSource.Find("SSTCaseId", linkId);
        }

        public override void Save()
        {
            if (SSTM.DB.SSTCase.HasErrors )
            {
                UIHelper.TableHasErrorsOnSaveMessBox(SSTM.DB);
            }
            else
            {
                try
                {
                    this.sSTCaseBindingSource.EndEdit();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();

                    //bp.AddForUpdate(FM.GetFileFlag());
                    //bp.AddForUpdate(SSTM.GetSSTCase());
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
                    throw new Exception("Delete not implemented on SSTRecord");
                    //CurrentRow().Delete();
                    //atriumDB_SSTDemoDataTableBindingSource.EndEdit();
                    //FM.GetSSTDemo().Update();
                    //FM.EFile.Update();
                    //FM.AtMng.AppMan.Commit();
                    //ApplyBR(true);

                    //fFile f = (fFile)this.ParentForm;
                    //f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
               throw x;
            }
        }

        private SST.SSTCaseRow CurrentRow()
        {
            if (sSTCaseBindingSource.Current == null)
                return null;
            else
                return (SST.SSTCaseRow)((DataRowView)sSTCaseBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(sSTCaseBindingSource);
            UIHelper.Cancel(FileFlagBindingSource);
            FM.CurrentFile.RejectChanges();
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

        private atriumDB.FileFlagRow CurrentFileFlagRow()
        {
            if (FileFlagBindingSource.Current != null)
                return (atriumDB.FileFlagRow)((DataRowView)FileFlagBindingSource.Current).Row;
            else
                return null;
        }

        private void FileFlagGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (CurrentFileFlagRow() == null) { return; }

                if (e.Column.Key.ToUpper() == "DELETE") // verify which column button was clicked
                {
                    if (FM.GetFileFlag().CanDelete(CurrentFileFlagRow()))
                    {
                        if (UIHelper.ConfirmDelete())
                        {
                            CurrentFileFlagRow().Delete();
                            FileFlagBindingSource.EndEdit();
                            Save();
                            FileForm().DisplayFileFlag();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool locationShifted = false;
        private void sSTCaseBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("SSTCaseId"))
                    return;

                ApplySecurity(CurrentRow());

                if (CurrentRow().ProgramId == 3) // EI
                {
                    gbIS.Visible = false;
                }
                else //assume IS
                {
                    gbEI.Visible = false;
                    if (!locationShifted)
                    {
                        gbIS.Location = new Point(gbIS.Location.X, gbIS.Location.Y - (gbEI.Height + 6));
                        //locationShifted = true;
                    }
                }
                if (!locationShifted)
                {
                    if (!gbEI.Visible)
                    {
                        gbFlagCode.Location = new Point(gbFlagCode.Location.X, gbFlagCode.Location.Y - (gbEI.Height + 6));
                    }
                    if (!gbIS.Visible)
                    {
                        gbFlagCode.Location = new Point(gbFlagCode.Location.X, gbFlagCode.Location.Y - (gbIS.Height + 13));
                    }
                    locationShifted = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AddFileFlagButton_Click(object sender, EventArgs e)
        {
            try
            {
                //bool flagCodeExists = FileFlagGridEX.Find(FileFlagGridEX.RootTable.Columns[3], Janus.Windows.GridEX.ConditionOperator.Equal, FlagCodeMultiDropDown.SelectedValue, 0, 1);

                int rowNum = FileFlagBindingSource.Find("FlagCode", FlagCodeMultiDropDown.SelectedValue);

                if (rowNum < 0)
                {
                    atriumDB.FileFlagRow ffr;

                    // add new appeal grounds
                    ffr = (atriumDB.FileFlagRow)FM.GetFileFlag().Add(FM.CurrentFile);
                    ffr.FileId = FM.CurrentFileId;
                    ffr.FlagCode = FlagCodeMultiDropDown.SelectedValue.ToString();
                    ffr.EndEdit();
                    //FileFlagBindingSource.EndEdit();
                    //FileFlagGridEX.Refresh();
                    Save();
                    FileForm().DisplayFileFlag();
                    //FM.
                    //OnValidated(new EventArgs());
                }
                else
                {
                    FileFlagGridEX.MoveToRowIndex(rowNum);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void FlagCodeMulti_SelectedValueChanged(object sender, EventArgs e)
        {
            if (FlagCodeMultiDropDown.SelectedValue != null)
            {
                AddFileFlagButton.Enabled = true;
            }
            else 
            {
                AddFileFlagButton.Enabled = false;
            }
        }
    }
}