using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate.Admin
{
    public partial class fRules : fBase
    {
        atSecurity.SecurityManager mySecMan;

        public fRules()
        {
            InitializeComponent();
        }

        public fRules(Form f): base(f)
        {
            InitializeComponent();

            mySecMan = AtMng.SecurityManager;
            mySecMan.GetsecRule().Load();
            mySecMan.GetsecFeature().Load();
            mySecMan.GetsecPermission().Load();
            mySecMan.GetsecPermLevel().Load();

            secRuleBindingSource.DataSource = mySecMan.DB;
            
            secRuleGridEX.DropDowns["ddFeature"].SetDataBinding(mySecMan.DB.secFeature, "FeatureName");
            secRuleGridEX.DropDowns["ddPermLevel"].SetDataBinding(new DataView(mySecMan.DB.secPermLevel, "Permlevel>1 or Permlevel=0", "Permlevel", DataViewRowState.CurrentRows), "");
            secRuleGridEX.DropDowns["ddPermLevelAllow"].SetDataBinding(new DataView(mySecMan.DB.secPermLevel, "Permlevel<2", "Permlevel", DataViewRowState.CurrentRows), "");
            cmdFeatureCount.Text = mySecMan.DB.secFeature.Count.ToString();
           
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdCancel":
                        UIHelper.Cancel(secRuleBindingSource, mySecMan.DB.secPermission);
                        UIHelper.Cancel(secRuleBindingSource, mySecMan.DB.secRule);
                        break;
                    case "cmdAdd":
                        SecurityDB.secRuleRow srr =  (SecurityDB.secRuleRow)mySecMan.GetsecRule().Add(null);
                        secRuleBindingSource.Position = secRuleBindingSource.Find("RuleId", srr.RuleId);

                        break;
                    case "cmdNewFeature":
                        mySecMan.GetsecPermission().Add(CurrentRow());
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdCollapse":
                        secRuleGridEX.CollapseRecords();
                        break;
                    case "cmdExpand":
                        secRuleGridEX.ExpandRecords();
                        break;
                    case "cmdCloneRule":
                        CloneRule();
                        break;

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void CloneRule()
        {
            SecurityDB.secRuleRow currRowRef = CurrentRow();
            SecurityDB.secRuleRow srr = (SecurityDB.secRuleRow)mySecMan.GetsecRule().Add(null);
            srr.RuleName = "Copy of: " + currRowRef.RuleName;
            SecurityDB.secPermissionRow[] currPerms = (SecurityDB.secPermissionRow[])mySecMan.DB.secPermission.Select("RuleId=" + currRowRef.RuleId);

            foreach (SecurityDB.secPermissionRow prm in currPerms)
            {
                SecurityDB.secPermissionRow newPerm = (SecurityDB.secPermissionRow)mySecMan.GetsecPermission().Add(srr);
                newPerm.FeatureId = prm.FeatureId;
                newPerm.AllowCreate = prm.AllowCreate;
                newPerm.AllowExecute = prm.AllowExecute;
                newPerm.DeleteLevel = prm.DeleteLevel;
                newPerm.OverrideRule = prm.OverrideRule;
                newPerm.ReadLevel = prm.ReadLevel;
                newPerm.UpdateLevel = prm.UpdateLevel;
            }

            secRuleBindingSource.Position= secRuleBindingSource.Find("RuleId", srr.RuleId);
 
        }

        public void Save()
        {
            try
            {
                secRuleGridEX.UpdateData();
                secRuleBindingSource.EndEdit();

                atLogic.BusinessProcess bp = mySecMan.GetBP();
                bp.AddForUpdate(mySecMan.GetsecRule());
                bp.AddForUpdate(mySecMan.GetsecPermission());
                bp.Update();

            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void secRuleGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record && e.Row.Table.Key.ToUpper() == "SECRULE")
                {
                    SecurityDB.secRuleRow srr = (SecurityDB.secRuleRow)((DataRowView)e.Row.DataRow).Row;
                    SecurityDB.secPermissionRow[] sprs = (SecurityDB.secPermissionRow[])mySecMan.DB.secPermission.Select("RuleId=" + srr.RuleId);
                    e.Row.Cells["FeaturesCount"].Text = sprs.Length.ToString();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public lmDatasets.SecurityDB.secRuleRow CurrentRow()
        {
            if (secRuleBindingSource.Current != null)
                return (SecurityDB.secRuleRow)((DataRowView)secRuleBindingSource.Current).Row;
            else
                return null;
        }

        private void secRuleGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                 fSelectFeatures fSel = new fSelectFeatures(AtMng, CurrentRow());
                 DialogResult dr = fSel.ShowDialog(this);
                 if (dr == System.Windows.Forms.DialogResult.OK)
                 {
                     foreach (Janus.Windows.GridEX.GridEXRow gr in fSel.checkedRows)
                     {
                         SecurityDB.secFeatureRow fr = (SecurityDB.secFeatureRow)gr.DataRow;
                         SecurityDB.secPermissionRow pr = (SecurityDB.secPermissionRow)mySecMan.GetsecPermission().Add(CurrentRow());
                         pr.FeatureId = fr.FeatureId;
                     }
                     
                 }
                 secRuleGridEX.Refresh();

            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void secRuleGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                if(e.Row.Table.Key == "FK_secPermission_secRule")
                {
                    SecurityDB.secPermissionRow spr = (SecurityDB.secPermissionRow)((DataRowView)e.Row.DataRow).Row;
                    if (spr.RowState == DataRowState.Added)
                        e.Row.Cells["State"].Value = 1;
                    else if (spr.RowState == DataRowState.Modified)
                        e.Row.Cells["State"].Value = 2;
                    else
                        e.Row.Cells["State"].Value = 0;
                }

                if (e.Row.Table.Key.ToUpper() == "SECRULE")
                {
                    SecurityDB.secRuleRow spr = (SecurityDB.secRuleRow)((DataRowView)e.Row.DataRow).Row;
                    if (spr.RowState == DataRowState.Added)
                        e.Row.Cells["State"].Value = 1;
                    else if (spr.RowState == DataRowState.Modified)
                        e.Row.Cells["State"].Value = 2;
                    else
                        e.Row.Cells["State"].Value = 0;
                }
   
            }

        }

        private void fRules_Load(object sender, EventArgs e)
        {
            try
            {
                secRuleGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

    }
}

