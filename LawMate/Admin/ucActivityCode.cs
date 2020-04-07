using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class ucActivityCode : UserControl
    {
        
        atriumBE.atriumManager myAtmng;
        bool aCIsUsed = false;

        public bool ACIsUsed
        {
            get { return aCIsUsed; }
        }

        public atriumBE.atriumManager AtMng
        {
            get { return myAtmng; }
            set 
            { 
                myAtmng = value;
                if (myAtmng != null)
                {
                    //activityCodeBindingSource.DataMember = "";
                    //activityCodeBindingSource.DataSource = myAtmng.acMng.DB.ActivityCode;
                    multiColumnCombo1.SetDataBinding(myAtmng.acMng.DB, myAtmng.acMng.DB.ACMajor.ToString());

                    DataTable dtTables = myAtmng.GetGeneralRec("Select * from ddTable where isdbtable=1 order by tablename");
                    //UIHelper.BindComboBox(associatedObjectCB, dtTables, "TableName", "TableName");
                    UIHelper.ComboBoxInit(dtTables, cbAssociatedObject, "TableName", "TableName");

                }
            }
        }

        public ucActivityCode()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get { return activityCodeBindingSource.DataSource; }
            set
            {
                
                //activityCodeBindingSource.DataSource = null;
                activityCodeBindingSource.DataMember = "";
                lbSeriesUsingAC.Items.Clear();
                activityCodeBindingSource.DataSource = value;

                lmDatasets.ActivityConfig.ACSeriesRow[] acsrs = (lmDatasets.ActivityConfig.ACSeriesRow[])AtMng.acMng.DB.ACSeries.Select("ActivityCodeID=" + CurrentRow().ActivityCodeID);
                lbSeriesUsingAC.BeginUpdate();
                aCIsUsed = false;
                foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in acsrs)
                {
                    
                    lbSeriesUsingAC.Items.Add("Step Code " + acsr.StepCode + " used in process: (" + acsr.SeriesRow.SeriesCode + ") " + acsr.SeriesRow.SeriesDescEng);
                    aCIsUsed = true;
                }
                lbSeriesUsingAC.EndUpdate();
                if (CurrentRow().RowState == DataRowState.Added)
                {
                    ebActivityNameEng.Focus();
                }
            }
        }

        public void EndEdit()
        {
            
            activityCodeBindingSource.EndEdit();
        }

        private void ucActivityCode_Load(object sender, EventArgs e)
        {
        }

        private lmDatasets.ActivityConfig.ActivityCodeRow CurrentRow()
        {
            return (lmDatasets.ActivityConfig.ActivityCodeRow)((DataRowView)activityCodeBindingSource.Current).Row;
        }

        private void associatedObjectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAssociatedObject.SelectedValue == null)
            {
                cbAssociatedField.DataSource = null;
            }
            else
            {
                DataTable dtField = AtMng.GetGeneralRec("Select * from vddField where tableName='" + cbAssociatedObject.SelectedValue.ToString() + "'");
                UIHelper.ComboBoxInit(dtField, cbAssociatedField, "FieldName", "FieldName");
                cbAssociatedField.DataBindings[0].ReadValue();
                //associatedFieldCB.ResetText();
            }

        }

        private void ebActivityNameEng_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.EditControls.EditBox tbText = (Janus.Windows.GridEX.EditControls.EditBox)sender;
                switch (tbText.Name)
                {
                    case "ebActivityNameEng":
                        UIHelper.TextBoxTextCounter(tbText, ebDescEngCounter, 200);
                        break;
                    case "DescPastTenseEng":
                        UIHelper.TextBoxTextCounter(tbText, ebDescPTEngCounter, 255);
                        break;
                    case "ebActivityNameFre":
                        UIHelper.TextBoxTextCounter(tbText, ebDescFreCounter, 200);
                        break;
                    case "DescPastTenseFre":
                        UIHelper.TextBoxTextCounter(tbText, ebDescPTFreCounter, 255);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}