using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class fDDLookup : LawMate.Admin.fBase
    {
        public fDDLookup()
        {
            InitializeComponent();
        }

        public fDDLookup(Form f)
            : base(f)
        {
            InitializeComponent();
            ddLookupBindingSource.DataSource = AtMng.DB.ddLookup;
    }

        private void ddLookupBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentRowddLookup().LookupType == "GEN")
            {
                ddGenericGridEX.Visible = true;
                gridEX1.Visible = false;
                cmdDeleteItem.Enabled =  Janus.Windows.UI.InheritableBoolean.True;
                cmdNewGeneric.Enabled =  Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                ddGenericGridEX.Visible = false;
                gridEX1.Visible = true;
                cmdDeleteItem.Enabled =  Janus.Windows.UI.InheritableBoolean.False;
                cmdNewGeneric.Enabled =  Janus.Windows.UI.InheritableBoolean.False;

                DataTable ds = AtMng.GetddLookup().Codes(CurrentRowddLookup().LookupName, AtMng.GetFile());
                bindingSource1.DataSource = ds;
                gridEX1.DataSource = ds;


                gridEX1.RetrieveStructure(true);

                //foreach (Janus.Windows.GridEX.GridEXColumn gc in gridEX1.Tables[1].Columns)
                //{
                //    gc.EditType = Janus.Windows.GridEX.EditType.NoEdit;
                //    if (gc.DataTypeCode == TypeCode.DateTime)
                //        gc.FormatString = "g";

                //}
            }
        }

        public lmDatasets.appDB.ddLookupRow CurrentRowddLookup()
        {
            if (ddLookupBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ddLookupRow)((DataRowView)ddLookupBindingSource.Current).Row;
        }
        public lmDatasets.appDB.ddGenericRow CurrentRowddgeneric()
        {
            if (ddGenericBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ddGenericRow)((DataRowView)ddGenericBindingSource.Current).Row;
        }
        private void Cancel()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    UIHelper.Cancel(ddLookupBindingSource);
                    UIHelper.Cancel(ddGenericBindingSource);
                    AtMng.DB.ddLookup.RejectChanges();
                    AtMng.DB.ddGeneric.RejectChanges();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void Save()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be saved.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ddLookupGridEX.CurrentRow.EndEdit();
                    ddLookupGridEX.UpdateData();
                    ddLookupBindingSource.EndEdit();

                    if (ddGenericGridEX.CurrentRow != null)
                        ddGenericGridEX.CurrentRow.EndEdit();
                    ddGenericGridEX.UpdateData();
                    ddGenericBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();

                    bp.AddForUpdate(AtMng.GetddLookup());
                    bp.AddForUpdate(AtMng.GetddGeneric());
                    bp.Update();
                }
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
                    case "cmdDeleteItem":

                        break;
                    case "cmdUndo":
                        Cancel();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdNewLookup":
                        lmDatasets.appDB.ddLookupRow dtr = (lmDatasets.appDB.ddLookupRow)AtMng.GetddLookup().Add(null);
                        //ddTableGridEX.Find(ddTableGridEX.RootTable.Columns["TableName"], Janus.Windows.GridEX.ConditionOperator.Equal, "New Table", 0, 1);
                        //ddTableGridEX.CurrentColumn = ddTableGridEX.RootTable.Columns["TableName"];
                        //ddLookupGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                        break;
                    case "cmdNewGeneric":
                        if (CurrentRowddLookup() != null)
                        {
                            lmDatasets.appDB.ddGenericRow dfr = (lmDatasets.appDB.ddGenericRow)AtMng.GetddGeneric().Add(CurrentRowddLookup());
                            //ddFieldGridEX.Find(ddTableGridEX.RootTable.Columns["FieldId"], Janus.Windows.GridEX.ConditionOperator.Equal, dfr.FieldId, 0, 1);
                            //ddFieldGridEX.CurrentColumn = ddTableGridEX.RootTable.ChildTables[0].Columns["FieldName"];
                            //ddFieldGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                        }
                        else
                            MessageBox.Show("Please select a valid row before choosing to create a new field", "No Table Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
