using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;

 namespace LawMate.Admin
{
    public partial class ucBFCode : UserControl
    {
        atriumManager myAtmng;
        FileManager FM;
        bool bfIsUsed = false;
        DataTable dtBFUsedIn;
        
        public bool BFIsUsed
        {
            get { return bfIsUsed; }
        }

        public atriumManager AtMng
        {
            get { return myAtmng; }
            set 
            {
                myAtmng = value;
                if (myAtmng != null)
                {
                    FM = myAtmng.GetFile();
                    ucMultiDropDown1.SetDataBinding(FM.AtMng.GetGeneralRec("select * from vRoleuContactType where obsolete=0"), "");
                    ucMultiDropDown2.SetDataBinding(FM.AtMng.GetGeneralRec("select * from vRoleuContactType where obsolete=0"), "");
                    ucMultiDropDown3.SetDataBinding(FM.Codes("BFType"), "");
                    FM.Dispose();
                }
                    
                    
            }
        }

        public ucBFCode()
        {
            InitializeComponent();
            
        }

        public void EndEdit()
        {
            aCBFBindingSource.EndEdit();
        }

        public object DataSource
        {
            get { return aCBFBindingSource.DataSource; }
            set
            {
                if (dtBFUsedIn == null)
                {
                    dtBFUsedIn = new DataTable();
                    dtBFUsedIn.Columns.Add("StepCode", typeof(string));
                    dtBFUsedIn.Columns.Add("StepType", typeof(int));
                    dtBFUsedIn.Columns.Add("SeriesCode", typeof(string));
                    dtBFUsedIn.Columns.Add("SeriesDescEng", typeof(string));
                    dtBFUsedIn.Columns.Add("ACSeriesId", typeof(int));
                    dtBFUsedIn.Columns.Add("SeriesId", typeof(int));
 
                }
                aCBFBindingSource.DataMember = null;
                dtBFUsedIn.Clear();
                aCBFBindingSource.DataSource = value;
                ((DataRowView)aCBFBindingSource.Current).DataView.Table.ColumnChanged+=new DataColumnChangeEventHandler(Table_ColumnChanged);
                bfIsUsed = false;
                ActivityConfig.ACDependencyRow[] acdr = (ActivityConfig.ACDependencyRow[])AtMng.acMng.DB.ACDependency.Select("ACBFId=" + CurrentRow().ACBFId);
                foreach (ActivityConfig.ACDependencyRow acd in acdr)
                {
                    bfIsUsed = true;
                    string sCode;
                    if (acd.ACSeriesRowByNextSteps.StepType == 1)
                    {
                        ActivityConfig.SeriesRow[] sr = (ActivityConfig.SeriesRow[])AtMng.acMng.DB.Series.Select("SeriesId=" + acd.ACSeriesRowByNextSteps.SubseriesId);
                        sCode = "Go To " + sr[0].SeriesCode;
                    }
                    else
                        sCode = acd.ACSeriesRowByNextSteps.StepCode;
                    dtBFUsedIn.Rows.Add(sCode, acd.ACSeriesRowByNextSteps.StepType, acd.ACSeriesRowByNextSteps.SeriesRow.SeriesCode, acd.ACSeriesRowByNextSteps.SeriesRow.SeriesDescEng, acd.ACSeriesRowByNextSteps.ACSeriesId, acd.ACSeriesRowByNextSteps.SeriesId);
                }
                BindData();
                if (CurrentRow().RowState == DataRowState.Added)
                {
                    ebBFCode.Focus();
                }
                ValidateBFType();
                ToggleReadOnly(CurrentRow().ReadOnly);
            }
        }

        public void BindData()
        {
            gridEX1.DataSource = dtBFUsedIn;
            gridEX1.DataMember = "";
            UIHelper.SetDataTableAsGridDataSource(gridEX1, dtBFUsedIn);
        }

        void Table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName == "BFType")
                    ValidateBFType();
                if (e.Column.ColumnName == "ReadOnly")
                   ToggleReadOnly((bool)e.ProposedValue);
                    

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ToggleReadOnly(bool MakeReadOnly)
        {
            Color bg = SystemColors.Window;
            if (MakeReadOnly)
                bg = SystemColors.Control;

            ebBFCode.ReadOnly = MakeReadOnly;
            ebBFCode.BackColor = bg;
            ebBFDate.ReadOnly = MakeReadOnly;
            ebBFDate.BackColor = bg;
            ucMultiDropDown3.ReadOnly = MakeReadOnly;
            ucMultiDropDown2.ReadOnly = MakeReadOnly;
            ucMultiDropDown1.ReadOnly = MakeReadOnly;
            ebBFDescEng.ReadOnly = MakeReadOnly;
            ebBFDescEng.BackColor = bg;
            editBox1.ReadOnly = MakeReadOnly;
            editBox1.BackColor = bg;
            chkMonitorIncomplete.Enabled = !MakeReadOnly;
        }

        private ActivityConfig.ACBFRow CurrentRow()
        {
            if (aCBFBindingSource.Current == null)
                return null;
            else
                return (ActivityConfig.ACBFRow)((DataRowView)aCBFBindingSource.Current).Row;
        }

        private void ValidateBFType()
        {
            if (CurrentRow() != null && !CurrentRow().IsBFTypeNull() && CurrentRow().BFType == 7)
            {
                ucMultiDropDown1.Enabled = true;
                ucMultiDropDown2.Enabled = true;
            }
            else
            { 
                ucMultiDropDown1.Enabled = false;
                ucMultiDropDown2.Enabled = false; 
            }
        }


        public delegate void ACSeriesLinkClickedEvenHandler(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e);
        public event ACSeriesLinkClickedEvenHandler AcSeriesLinkClicked;

        public delegate void SeriesLinkClickedEvenHandler(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e);
        public event SeriesLinkClickedEvenHandler SeriesLinkClicked;

        private void gridEX1_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "StepCode")
                {
                    if (AcSeriesLinkClicked != null)
                        AcSeriesLinkClicked(sender, e);
 
                }
                if (e.Column.Key == "SeriesCode")
                {
                    if (SeriesLinkClicked != null)
                        SeriesLinkClicked(sender, e);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucMultiDropDown3_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                EndEdit();
                ValidateBFType();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
