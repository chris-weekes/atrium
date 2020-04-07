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
    public partial class fSelectFeatures : LawMate.Admin.fBase
    {
        public Janus.Windows.GridEX.GridEXRow[] checkedRows
        {
            get
            {
                return secFeatureGridEX.GetCheckedRows();
            }
        }

        public fSelectFeatures()
        {
            InitializeComponent();
        }

        public fSelectFeatures(atriumBE.atriumManager atmng, SecurityDB.secRuleRow ruleRow)
        {
            InitializeComponent();
            secFeatureGridEX.RootTable.Caption = "Available Features for: " + ruleRow.RuleName;

            List<SecurityDB.secFeatureRow> availableFeatures = new List<SecurityDB.secFeatureRow>();

            SecurityDB.secPermissionRow[] establishedRulePerms = (SecurityDB.secPermissionRow[])atmng.SecurityManager.DB.secPermission.Select("RuleId=" + ruleRow.RuleId);
            foreach (SecurityDB.secFeatureRow fr in atmng.SecurityManager.DB.secFeature)
            {
                bool featureImplemented=false;
                foreach (SecurityDB.secPermissionRow secr in establishedRulePerms)
                {
                    if (secr.FeatureId == fr.FeatureId)
                        featureImplemented = true;
                }
                if (!featureImplemented)
                    availableFeatures.Add(fr);
            }

            if (availableFeatures.Count == 0)
                MessageBox.Show("All features are already implemented on this rule");

            secFeatureBindingSource.DataSource = availableFeatures;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void secFeatureGridEX_RowCheckStateChanged(object sender, Janus.Windows.GridEX.RowCheckStateChangeEventArgs e)
        {
            try
            {
                e.Row.Cells["Message"].Text = "";
                if (e.Row.CheckState == Janus.Windows.GridEX.RowCheckState.Checked)
                    e.Row.Cells["Message"].Text = "Feature will be added to the rule";
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void secFeatureGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.IsChecked)
                {
                    e.Row.Cells["Message"].Text = "Feature will be added to the rule";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
    }
}
