using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;

namespace LawMate
{
    public partial class ucA5 : ucBase, IRelatedFieldsHost
    {
        public ucA5()
        {
            InitializeComponent();

        }

   
        ACEngine MyACE;
        atriumManager Atmng;
        appDB.ddTableRow myPrimaryTable;
        ActivityConfig.ACSeriesRow myACSeries;
        bool secReadOnly = false;

        RelatedFields myRF;

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public void LoadACS(string form)
        {
            int acsid = System.Convert.ToInt32(form.Replace("acs-", ""));
            Atmng = FM.AtMng;
            myACSeries = Atmng.acMng.DB.ACSeries.FindByACSeriesId(acsid);

            appDB.ddTableRow[] dtrs = (appDB.ddTableRow[])Atmng.DB.ddTable.Select("DefaultFormID=" + acsid.ToString());

            myPrimaryTable = dtrs[0];
            secReadOnly = Atmng.SecurityManager.CanUpdate(FM.CurrentFileId, MyFeatureID()) == atSecurity.SecurityManager.LevelPermissions.No;
            tsScreenTitle.Text = myACSeries["Desc" + Atmng.AppMan.Language].ToString();


            Init(myACSeries);

            FileTreeView.BuildMenu(FM, tsActions, myACSeries.StepCode);

        }
        bool first = true;
        private void Init(ActivityConfig.ACSeriesRow acsr)
        {
            this.SuspendLayout();
            //flowLayoutPanel1.Controls.Clear();
            if (myRF != null)
                myRF.Dispose();
            myRF = null;
            MyACE = new ACEngine(FM);
            MyACE.myAcSeries = acsr;
            MyACE.myActivityCode = acsr.ActivityCodeRow;
            MyACE.DoRelFields();
            MyACE.DoStep(ACEngine.Step.RelatedFields0, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields1, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields2, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields3, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields4, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields5, true);
            MyACE.DoStep(ACEngine.Step.RelatedFields6, true);

            BuildForm(acsr);
            if (first)
            {
                foreach (DataView dv in MyACE.relTables.Values)
                {
                    DataTable dt = dv.Table;
                    dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
                    atLogic.ObjectBE obe = FM.GetBEFromTable(dt);
                    obe.OnUpdate += new atLogic.UpdateEventHandler(ucSSTCase_OnUpdate);

                }
                first = false;
            }
            this.ResumeLayout();
        }
        public void BuildForm(ActivityConfig.ACSeriesRow acsr)
        {

            if (myRF == null)
                myRF = new RelatedFields(MyACE, this, secReadOnly,false);

            myRF.BeginLayout();


            DoBlock(acsr, MyACE.HasRel0, 0);
            DoBlock(acsr, MyACE.HasRel1, 1);
            DoBlock(acsr, MyACE.HasRel2, 2);
            DoBlock(acsr, MyACE.HasRel3, 3);
            DoBlock(acsr, MyACE.HasRel4, 4);
            DoBlock(acsr, MyACE.HasRel5, 5);
            DoBlock(acsr, MyACE.HasRel6, 6);
            DoBlock(acsr, MyACE.HasRel7, 7);
            DoBlock(acsr, MyACE.HasRel8, 8);
            DoBlock(acsr, MyACE.HasRel9, 9);

            myRF.FinishLayout();
        }

        private void DoBlock(ActivityConfig.ACSeriesRow acsr, bool HasBlock, int step)
        {
            if (HasBlock)
            {
                MyACE.LoadDataForStep(step, acsr.ACSeriesId);
                if (!MyACE.skipBlock)
                    myRF.DoRelFields(acsr, step); ;
            }
        }



        public override void ReadOnly(bool makeReadOnly)
        {

            foreach (Control ctl in flowLayoutPanel1.Controls)
            {
                ctl.Enabled = !makeReadOnly;
            }
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        void ucSSTCase_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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
                        if (FM.IsFieldChanged(e.Column, e.Row))
                            ApplyBR(false);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override string ucDisplayName()
        {
            return tsScreenTitle.Text;
        }

        public override void ReloadUserControlData()
        {
            //UnhookEvents();
            Init(myACSeries);
        }



        public override void EndEdit()
        {
            foreach (DataView dv in MyACE.relTables.Values)
            {
                BindingManagerBase bc = this.BindingContext[dv];
                bc.EndCurrentEdit();
            }
        }

        public override void ApplySecurity(DataRow dr)
        {
            Init(myACSeries);


            atSecurity.SecurityManager.Features feat = MyFeatureID();

            UIHelper.EnableCommandBarCommand(tsDelete, Atmng.SecurityManager.CanDelete(FM.CurrentFileId, feat) != atSecurity.SecurityManager.LevelPermissions.No);

        }

        private atSecurity.SecurityManager.Features MyFeatureID()
        {
            atSecurity.SecurityManager.Features feat = atSecurity.SecurityManager.Features.Efile;
            if (!myPrimaryTable.IsFeatureIdNull())
                feat = (atSecurity.SecurityManager.Features)myPrimaryTable.FeatureId;
            return feat;
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
            // tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }




        private void lblBFHelpImg_Click(object sender, EventArgs e)
        {

        }

        public override void Cancel()
        {
            foreach (DataView dv in MyACE.relTables.Values)
            {
                BindingManagerBase bc = this.BindingContext[dv];

                bc.CancelCurrentEdit();
                DataTable dt = dv.Table;
                if (dt.HasErrors)
                {
                    foreach (DataRow dr in dt.GetErrors())
                    {
                        dr.ClearErrors();
                    }
                }
                dt.RejectChanges();
            }
            ApplyBR(true);
        }
        public override void Save()
        {
            bool hasError = false;
            foreach (DataView dv in MyACE.relTables.Values)
            {
                BindingManagerBase bc = this.BindingContext[dv];
                bc.EndCurrentEdit();
            }
        

            foreach (atLogic.BEManager be in FM.MyMngrs.Values)
            {
                if (be.MyDS.HasErrors)
                {
                    hasError = true;
                    UIHelper.TableHasErrorsOnSaveMessBox(be.MyDS);
                    break;
                }
            }
            if (!hasError)
            {

                FM.SaveAll();
            }
        }

        public override void Delete()
        {

            if (CurrentRow() != null)
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    FM.SaveAll();
                }
            }
            else
            {
                throw new LMException("No current record");
            }

        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            DataView dv;
            if (myPrimaryTable == null)
                return;
            if (MyACE.relTables.ContainsKey(myPrimaryTable.TableName + "0"))
                dv = MyACE.relTables[myPrimaryTable.TableName + "0"];
            else
                dv = MyACE.relTables[myPrimaryTable.TableName];


            BindingManagerBase bc = this.BindingContext[dv];
            dv.Sort = dv.Table.PrimaryKey[0].ToString();
            bc.Position = dv.Find(linkId);
        }
        DataRow CurrentRow()
        {
            DataView dv;
            if (myPrimaryTable == null)
                return null;
            if (MyACE.relTables.ContainsKey(myPrimaryTable.TableName + "0"))
                dv = MyACE.relTables[myPrimaryTable.TableName + "0"];
            else
                dv = MyACE.relTables[myPrimaryTable.TableName];

            BindingManagerBase bc = this.BindingContext[dv];

            if (bc.Current != null)
            {
                DataRow dr = ((DataRowView)bc.Current).Row;
                return dr;
            }

           
            return null;
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
                FileForm().HandleACSMenu(e, CurrentRow());


            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void EnableButtons(int required)
        {
            if (required == 0)
                tsSave.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                tsSave.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        FlowLayoutPanel IRelatedFieldsHost.flowLayoutPanel1
        {
            get {return flowLayoutPanel1; }
        }

       

        Janus.Windows.Common.JanusSuperTip IRelatedFieldsHost.janusSuperTip1
        {
            get { return janusSuperTip1; }
        }


        public void SetHelpPanel(bool showpanel, string helptext)
        {
            throw new NotImplementedException();
        }


        public void SkipStep()
        {
            throw new NotImplementedException();
        }
    }
}
