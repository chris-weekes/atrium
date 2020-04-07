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
    public partial class ucEFile : ucBase
    {
        const string LayoutVersionNumber = "4_0_12";

        public ucEFile()
        {
            InitializeComponent();
        }

        public void BindEfileData(lmDatasets.atriumDB.EFileDataTable a)
        {
            UIHelper.ComboBoxInit(FM.Codes("CHILDFILETYPE"), ucFileTypeMcc, FM);
            UIHelper.ComboBoxInit(FM.AtMng.CodeDB.Status, ucStatusCodeMcc, FM);
            UIHelper.ComboBoxInit("ReturnCode", ucClosureCodeMcc, FM);
            UIHelper.ComboBoxInit(FM.Codes("CHILDMETATYPE"), ucMetaTypeMcc, FM);
            UIHelper.ComboBoxInit("LanguageCodeAll", ucMultiDropDown3, FM);
            UIHelper.ComboBoxInit("SecurityLevel", ucSecurity, FM);
            UIHelper.ComboBoxInit("FilePeriod", mccPeriod, FM);
            UIHelper.ComboBoxInit(FM.AtMng.GetGeneralRec("select DispositionAuthId, DispDescEng, DispDescFre from DispositionAuthority"), dispositionIducMultiDropDown, FM);
            UIHelper.ComboBoxInit(FM.AtMng.GetGeneralRec("select Id, LocationEng, LocationFre from FileLocation"), locationIducMultiDropDown, FM);
            UIHelper.ComboBoxInit("vLocation", locationIducMultiDropDown, FM);

            this.eFileBindingSource.DataSource = a.DataSet;
            this.eFileBindingSource.DataMember = a.TableName;

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.EFile.OnUpdate += new atLogic.UpdateEventHandler(EFile_OnUpdate);

            //ApplySecurity(CurrentRow());

            if (CurrentRow().GetArchiveBatchRows().Length==0)
                gbArchiving.Enabled = false;

            
        }

        void EFile_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override string ucDisplayName()
        {
            return Properties.Resources.EFileProperty;
        }

        public override void ReloadUserControlData()
        {
            //int fileid=FM.CurrentFileId;

            //FM.EFile.PreRefresh();
            //FM.GetFileAKA().PreRefresh();


            //FM.EFile.Refresh(fileid);
            //FM.GetFileAKA().LoadByFileId(fileid);
            //FM.CurrentFile = FM.DB.EFile.FindByFileId(fileid);
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                switch (e.Column.ColumnName.ToLower())
                {
                    case "misc1date":
                    case "misc2date":
                    case "dim1id":
                    case "dim2id":
                    case "filestructxml":
                        break;

                    default:
                        ApplyBR(false);
                        break;


                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(eFileBindingSource, !makeReadOnly);
            UIHelper.EnableControls(archiveBatchBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar3.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                fileAKAGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
                ApplySecurity(CurrentRow());
            }
            else
                fileAKAGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False;
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

            //if (DataNotDirty)
            //    tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            //else
            //    tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            atriumDB.EFileRow cbr = (atriumDB.EFileRow)dr;
            if (FM.CurrentFile.RowState != DataRowState.Deleted)
            {
                int perm = (int)FM.AtMng.SecurityManager.CanUpdate(FM.CurrentFile.FileId, atSecurity.SecurityManager.Features.EfileScreen);
                bool ok = perm > 0 & perm < 10 & FM.EFile.CanEdit(FM.CurrentFile);

                if (ok)
                {
                    tsDump.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    cmdFileAccess.Visible = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    tsDump.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdFileAccess.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }

                if (FM.AtMng.SecurityManager.CanOverride(FM.CurrentFileId, atSecurity.SecurityManager.Features.secFileRule)== atSecurity.SecurityManager.ExPermissions.Yes)
                {
                    tsSecurity.Visible = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    tsSecurity.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }

                UIHelper.EnableControls(eFileBindingSource, ok);
                UIHelper.EnableControls(archiveBatchBindingSource, ok);
                appDB.EFileSearchRow pdr = FM.EFile.GetEfileParentRow(cbr);
                bool auto = false;// FM.DB.FileMetaType.FindByMetaTypeCode(pdr.MetaType).SubFileAutoNumber;
                if (pdr != null & ok)
                {
                    auto = FM.DB.FileMetaType.FindByMetaTypeCode(pdr.MetaType).SubFileAutoNumber;
                    fileNumberEditBox.ReadOnly = auto;
                }
                //disable period fields where children are not auto-numbered
                if (!auto)
                {
                    mccPeriod.Enabled = false;
                    calPeriodStartDate.Enabled = false;
                }



                perm = (int)FM.AtMng.SecurityManager.CanDelete(FM.CurrentFile.FileId, atSecurity.SecurityManager.Features.EfileScreen);
                ok = perm > 0 & perm < 10 & FM.EFile.CanDelete(FM.CurrentFile);
                UIHelper.EnableCommandBarCommand(tsDelete, ok);

                //jll 2015-10-02: what the hell is this?!?
                if (!descriptionEEditBox.Enabled)
                {
                    descriptionEEditBox.ReadOnly = true;
                    descriptionEEditBox.Enabled = true;
                }

            }
        }

        //void dv_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    //this.eFileBindingSource.ResetCurrentItem();
        //    //this.eFileBindingSource.CurrencyManager.Refresh();
        //   // throw new Exception("The method or operation is not implemented.");
        //}

        public override void MoreInfo(string linkTable, int linkId)
        {
            eFileBindingSource.Position = eFileBindingSource.Find("FileId", linkId);
        }

        public override void Delete()
        {


            try
            {
                //throw new LMException(LawMate.Properties.Resources.UIOpNotAllowed);

                if (FM.EFile.CanDelete(FM.CurrentFile))
                {
                    if (UIHelper.ConfirmDelete())
                    {
                        //CurrentRow().Delete();
                        //this.eFileBindingSource.EndEdit();
                        this.ParentForm.Close();
                        FM.CurrentFile.Delete();

                        FM.SaveAll();
                        //atLogic.BusinessProcess bp = FM.GetBP();
                        //bp.AddForUpdate(FM.EFile);
                        //bp.Update();
                        // FM.Dispose();
                        //ApplyBR(true);

                        //fFile f = (fFile)this.ParentForm;
                        //f.fileToc.LoadTOC();
                    }
                }

            }
            catch (Exception x)
            {
                FM.DB.EFile.RejectChanges();
                //FM.Dispose();

                throw new LMException(LawMate.Properties.Resources.UICannotDeleteThisFile, x);// RollbackException(LawMate.Properties.Resources.UITransactionRolledBack, x);
            }
        }

        public override void Save()
        {
            if (FM.DB.EFile.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    eFileBindingSource.EndEdit();
                    fileAKABindingSource.EndEdit();

                    archiveBatchBindingSource.EndEdit();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();
                    //bp.AddForUpdate(FM.GetFileContact());
                    //bp.AddForUpdate(FM.EFile);
                    //bp.AddForUpdate(FM.GetFileAKA());
                    //bp.Update();


                    //      FM.GetFileAKA().LoadByFileId(FM.CurrentFile.FileId);
                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    //f.fileToc.LoadTOC();

                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
            }

        }

        private lmDatasets.atriumDB.EFileRow CurrentRow()
        {
            if (eFileBindingSource.Current != null)
                return (lmDatasets.atriumDB.EFileRow)((DataRowView)eFileBindingSource.Current).Row;
            else
                return null;
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsTestCAL":
                        FileForm().GetUcCtlToc("appointment");
                        break;
                    case "tsDump":
                        string file = FM.AtMng.AppMan.LawMatePath + FM.CurrentFile.FileId.ToString();
                        FM.DB.WriteXml(file + "_atriumDB.xml");
                        FM.GetDocMng().DB.WriteXml(file + "_docDB.xml");
                        break;
                    case "tsSecurity":
                        FileForm().GetUcCtlToc("security");
                        break;
                    case "cmdFileAccess":
                        FileForm().GetUcCtlToc("fileaccess");
                        break;
                    case "tsSave":
                        Save();
                        break;
                    case "tsDelete":
                        Delete();
                        break;
                    case "tsResetFileStruct":
                        //FM.EFile.RebuildFileStruct(FM.CurrentFile);
                        //Save();
                        FileForm().ReloadFileData();
                        fFile pfile = (fFile)this.ParentForm;
                        pfile.fileToc.LoadTOC();
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

        public override void Cancel()
        {
            UIHelper.Cancel(eFileBindingSource);
            UIHelper.Cancel(archiveBatchBindingSource);
            ApplyBR(true);
        }

        private void eFileBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentRow() != null)
            {
                atriumDB.EFileRow cbr = CurrentRow();
                ApplySecurity(cbr);
            }
        }

        private void fileAKAGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            try
            {
                if (UIHelper.ConfirmDelete() == false)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fileAKAGridEX_RecordsDeleted(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void nameETextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.EditControls.EditBox tbText = (Janus.Windows.GridEX.EditControls.EditBox)sender;
                switch (tbText.Name)
                {
                    case "nameEEditBox":
                        UIHelper.TextBoxTextCounter(tbText, NameECounter, 255);
                        break;
                    case "nameFEditBox":
                        UIHelper.TextBoxTextCounter(tbText, NameFCounter, 255);
                        break;
                    case "fileNumberEditBox":
                        UIHelper.TextBoxTextCounter(tbText, fileNumberCounter, 16);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        private void openedDateCalendarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                UIHelper.TodaysDateShortcutKey(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucEFile_Load(object sender, EventArgs e)
        {
            try
            {
                lmWinHelper.LoadCommandManagerLayout(uiCommandManager1, "EfilePropsCommandManager", LayoutVersionNumber);

                //2017-08-31 JLL: readonly user issue: all fields enabled and not readonly even though EnableControls value appropriately set to false
                //readonly hack - without it, fields are enabled and not readonly, ApplySecurity moved from BindData method to control's Load method
                //there appears to be a consistent issue here with screens without grids that the fields are inappropriately set to an enabled/not readonly set mistakenly
                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(uiCommandManager1);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void SaveLayout()
        {
            uiCommandBar3.RowIndex = 1;
            lmWinHelper.SaveCommandManagerLayout(uiCommandManager1, "EfilePropsCommandManager", FM.AtMng, LayoutVersionNumber);
        }
    }
}

