using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

 namespace LawMate.Admin
{
    public partial class fLookup : fBase
    {
        atLogic.ObjectBE obe;
        bool isSysAdmin;
        public fLookup()
        {
            InitializeComponent();
        }

        public fLookup(Form f, bool showOnlyDataAdminTables): base(f)
        {
            InitializeComponent();
            DataTable dtTables;
            if (showOnlyDataAdminTables)
            {
                dtTables = AtMng.GetGeneralRec("Select TableId, TableName from ddTable where tblGroup = 'DATAADMIN' order by tablename ");
                isSysAdmin = false;
            }
            else
            {
                dtTables = AtMng.GetGeneralRec("Select TableId, TableName from ddTable where tblGroup = 'DATAADMIN' or tblGroup = 'ADMIN' order by tablename ");
                isSysAdmin = true;
            }

            gridEX1.DataSource = dtTables;
            gridEX1.DataMember = "";
            UIHelper.SetDataTableAsGridDataSource(gridEX1, dtTables);
            uiPanel2.Closed = true;
        }

        private void cGridEX_UpdatingCell(object sender, UpdatingCellEventArgs e)
        {
            try
            {

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cGridEX_EditingCell(object sender, EditingCellEventArgs e)
        {
            try
            {
                if (cGridEX.CurrentRow.RowType == RowType.Record)
                {
                    if (cGridEX.RootTable.Columns.Contains("ReadOnly"))
                    {
                        if ((bool)cGridEX.CurrentRow.Cells["ReadOnly"].Value) //lock all cells, except ReadOnly
                        {
                            if (e.Column.Key == "ReadOnly")
                            {
                                if(isSysAdmin)
                                {
                                    if (MessageBox.Show("Are you sure you want to change the value of the Read-Only column for the code: " + cGridEX.CurrentRow.Cells[0].Value.ToString() + "?", "Modification of Read-Only Value", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                        e.Cancel = true;
                                }
                                else
                                {
                                    MessageBox.Show("You cannot modify Read-Only records.", "Record is Read-Only", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    e.Cancel=true;
                                }
                            }
                            else
                                e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void Save()
        {
            cGridEX.CurrentRow.EndEdit();
            cGridEX.UpdateData();
            atLogic.BusinessProcess bp = AtMng.GetBP();
            bp.AddForUpdate(obe);
            bp.Update();
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdSave":
                        Save();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridEX1_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            try
            {
                uiPanel2.Closed = true;

                if (gridEX1.GetRow().RowType == RowType.Record)
                {
                    string TblName;
                    DataRow dr = (DataRow)((DataRowView)gridEX1.GetRow().DataRow).Row;
                    TblName = (string)dr["TableName"];
                    uiPanel1.Text = TblName;

                    for (int i = cGridEX.RootTable.Columns.Count - 1; i >= 0; i--)
                    {
                        cGridEX.RootTable.Columns.Remove(cGridEX.RootTable.Columns[i]);
                    }

                    obe = AtMng.GetCodeTableBE(TblName);
                    obe.Load();
                    cGridEX.DataSource = obe.myDT;
                    int y = 0;
                    for (int i = 0; obe.myDT.Columns.Count > i; i++)
                    {
                        if ((obe.myDT.Columns[i].ColumnName == "entryUser") ||
                            (obe.myDT.Columns[i].ColumnName == "entryDate") ||
                            (obe.myDT.Columns[i].ColumnName == "updateUser") ||
                            (obe.myDT.Columns[i].ColumnName == "updateDate") ||
                            (obe.myDT.Columns[i].ColumnName == "ts"))
                        { }
                        else
                        {
                            if (cGridEX.RootTable.Columns.Count > i)
                            { }
                            else
                            {
                                cGridEX.RootTable.Columns.Add();
                            }
                            cGridEX.RootTable.Columns[y].DataMember = obe.myDT.Columns[i].ColumnName;
                            cGridEX.RootTable.Columns[y].Key = obe.myDT.Columns[i].ColumnName;
                            cGridEX.RootTable.Columns[y].AutoSizeMode = ColumnAutoSizeMode.AllCellsAndHeader;

                            if (obe.myDT.Columns[i].DataType == System.Type.GetType("System.Boolean"))
                            {
                                cGridEX.RootTable.Columns[y].ColumnType = ColumnType.CheckBox;
                                cGridEX.RootTable.Columns[y].EditType = EditType.CheckBox;
                            }
                            if (TblName == "AccountType")
                            {
                                switch (i)
                                {
                                    case 1:
                                        cGridEX.RootTable.Columns[y].Caption = "Code";
                                        break;
                                    case 2:
                                        cGridEX.RootTable.Columns[y].Caption = "Desc Eng";
                                        break;
                                    case 3:
                                        cGridEX.RootTable.Columns[y].Caption = "Desc Fre";
                                        break;
                                    default:
                                        cGridEX.RootTable.Columns[y].Caption = obe.myDT.Columns[i].ColumnName;
                                        break;

                                }
                            }
                            else
                            {
                                cGridEX.RootTable.Columns[y].Caption = obe.myDT.Columns[i].ColumnName;
                                if (obe.myDT.Columns[i].ColumnName == "WFBGColor")
                                {
                                    cGridEX.RootTable.Columns[y].Selectable = false;
                                    uiPanel2.Closed = false;
                                    cGridEX.RootTable.Columns.Add("BGColor");
                                }
                            }
                            y++;

                        }
                        

                    }
                    cGridEX.RootTable.SortKeys.Add(cGridEX.RootTable.Columns[0], Janus.Windows.GridEX.SortOrder.Ascending);
                    
                    if (cGridEX.RootTable.Columns.Contains("Obsolete"))
                    {
                        Janus.Windows.GridEX.GridEXFormatCondition gfc2 = new GridEXFormatCondition(cGridEX.RootTable.Columns["Obsolete"], ConditionOperator.Equal, true);
                        Janus.Windows.GridEX.GridEXFormatStyle gfs2 = new GridEXFormatStyle();
                        gfs2.FontStrikeout = TriState.True;
                        gfc2.FormatStyle = gfs2;
                        cGridEX.RootTable.FormatConditions.Add(gfc2);
                    }
                    if (cGridEX.RootTable.Columns.Contains("ReadOnly"))
                    {
                        Janus.Windows.GridEX.GridEXFormatCondition gfc = new GridEXFormatCondition(cGridEX.RootTable.Columns["ReadOnly"], ConditionOperator.Equal, true);
                        Janus.Windows.GridEX.GridEXFormatStyle gfs = new GridEXFormatStyle();
                        gfs.BackColor = Color.Gainsboro;
                        gfs.ForeColor = SystemColors.ControlDarkDark;
                        gfc.FormatStyle = gfs;
                        cGridEX.RootTable.FormatConditions.Add(gfc);
                    }
                    cGridEX.AutoSizeColumns();


                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool RowSelectIsSettingColor = false;
        private void uiColorButton1_SelectedColorChanged(object sender, EventArgs e)
        {
            try
            {
                if (!RowSelectIsSettingColor)
                {
                    int ColorToStore = uiColorButton1.SelectedColor.ToArgb();
                    tbColorIntValue.Text = ColorToStore.ToString();
                    if (cGridEX.CurrentRow.RowType == RowType.Record)
                    {
                        DataRow dr = ((DataRowView)cGridEX.GetRow().DataRow).Row;
                        dr["WFBGColor"] = ColorToStore;
                        if (uiColorButton1.SelectedColor.IsKnownColor)
                        {
 
                        }
                        if (uiColorButton1.SelectedColor.IsNamedColor)
                        {
 
                        }

                        cGridEX.GetRow().Cells["BGColor"].Text = uiColorButton1.SelectedColor.Name;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try 
            {
                RowSelectIsSettingColor = true;
                uiColorButton1.SelectedColor = Color.Empty;
                if (cGridEX.CurrentRow.RowType == RowType.Record && cGridEX.RootTable.Columns.Contains("WFBGColor"))
                {
                    DataRow dr = (DataRow)((DataRowView)cGridEX.GetRow().DataRow).Row;
                    if (!dr.IsNull("WFBGColor"))
                    {
                        int ColorToSet = Convert.ToInt32(dr["WFBGColor"]);
                        tbColorIntValue.Text = ColorToSet.ToString();
                        Color gridColor = Color.FromArgb(ColorToSet);
                        uiColorButton1.SelectedColor = gridColor;
                    }
                }
                RowSelectIsSettingColor = false;
 
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try{
                uiColorButton1.SelectedColor = Color.Empty;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiColorButton1_MoreColorsButtonClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult = colorDialog1.ShowDialog();
                if (DialogResult == System.Windows.Forms.DialogResult.OK)
                    uiColorButton1.SelectedColor = colorDialog1.Color;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}