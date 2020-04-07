using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.UserControls
{
    public partial class ucFileRule : ucBase
    {
        public ucFileRule()
        {
            InitializeComponent();
        }

        public void BindData(lmDatasets.atriumDB.secFileRuleDataTable a)
        {

            DataTable dtGr=FM.AtMng.GetGeneralRec("Select * from vsecGroupList order by groupname");
            DataTable dtRu = FM.AtMng.GetGeneralRec("Select * from vsecrule order by rulename");
            
            secFileRuleGridEX.DropDowns["ddGroup"].SetDataBinding(dtGr, "");
            secFileRuleGridEX.DropDowns["ddRule"].SetDataBinding(dtRu, "");

            this.secFileRuleBindingSource.DataSource = a.DataSet;
            this.secFileRuleBindingSource.DataMember = a.TableName;
            this.secFileRuleBindingSource.Filter = "Fileid=" + FM.CurrentFile.FileId.ToString();

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetsecFileRule().OnUpdate += new atLogic.UpdateEventHandler(EFile_OnUpdate);

            if (FM.CurrentFile.FileId == 0)
            {
                cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {

                if (FM.EFile.GetParentFileXref(FM.CurrentFile).secBreakInherit)
                {
                    cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
            }

        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            lmDatasets.atriumDB.secFileRuleRow cbr = (lmDatasets.atriumDB.secFileRuleRow)dr;
            //UIHelper.EnableControls(secFileRuleBindingSource, FM.AtMng.SecurityManager.GetsecFileRule().CanEdit(cbr));
            if (FM.GetsecFileRule().CanEdit(cbr))
                secFileRuleGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
            else
                secFileRuleGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;

            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetsecFileRule().CanDelete(cbr));
            UIHelper.EnableCommandBarCommand(tsAdd, FM.GetsecFileRule().CanAdd(cbr));
            UIHelper.EnableCommandBarCommand(tsBreakInherit, FM.GetsecFileRule().CanAdd(cbr));

        }
        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.FileSecurity;
        }
        public override void ReloadUserControlData()
        {

            secFileRuleGridEX.MoveFirst();
            if (FM.EFile.GetParentFileXref(FM.CurrentFile).secBreakInherit)
            {
                cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        void EFile_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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

        public override void Save()
        {
            try
            {
                secFileRuleGridEX.UpdateData();
                secFileRuleBindingSource.EndEdit();

                FM.SaveAll();
                //atLogic.BusinessProcess bp = FM.GetBP();
                //bp.AddForUpdate(FM.GetsecFileRule());
                //bp.Update();

                //get rid of new row if present as database new row will have been returned with a different pkid
                //moved to secfileerule afterupdate
                //lmDatasets.SecurityDB.secFileRuleRow sfr = FM.AtMng.SecurityManager.DB.secFileRule.FindById(0);
                //if (sfr != null)
                //{
                //    FM.AtMng.SecurityManager.DB.secFileRule.RemovesecFileRuleRow(sfr);
                //    FM.AtMng.SecurityManager.DB.secFileRule.AcceptChanges();
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdUnbreak":
                        FM.EFile.UnBreakInherit();
                        if (FM.EFile.GetParentFileXref(FM.CurrentFile).secBreakInherit)
                        {
                            cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        else
                        {
                            cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        }
                        break;
                    case "tsBreakInherit":
                        FM.EFile.BreakInherit();
                        if (FM.EFile.GetParentFileXref(FM.CurrentFile).secBreakInherit)
                        {
                            cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                            tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        else
                        {
                            cmdUnbreak.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            tsBreakInherit.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        }
                        break;
                    case "tsAdd":
                        lmDatasets.atriumDB.secFileRuleRow dr=(lmDatasets.atriumDB.secFileRuleRow) FM.GetsecFileRule().Add(FM.CurrentFile);
                        dr.FileId = FM.CurrentFile.FileId;
                        secFileRuleBindingSource.MoveLast();
                        break;

                    case "tsSave":
                        Save();
                        break;

                    case "tsCancel":
                        Cancel();
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

        public override  void Cancel()
        {
            UIHelper.Cancel(secFileRuleBindingSource);
            ApplyBR(true);
        }
        private lmDatasets.atriumDB.secFileRuleRow  CurrentRow()
        {
            if (secFileRuleBindingSource.Current != null)
                return (lmDatasets.atriumDB.secFileRuleRow)((DataRowView)secFileRuleBindingSource.Current).Row;
            else
                return null;
        }
        public override void Delete()
        {


            try
            {

                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    this.secFileRuleBindingSource.EndEdit();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();
                    //bp.AddForUpdate(FM.GetsecFileRule());
                    //bp.Update();
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
                tsEditMode.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsEditMode.Visible = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        private void secFileRuleBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if(CurrentRow()!=null)
                ApplySecurity(CurrentRow());
        }

        private void ucFileRule_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                secFileRuleGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

