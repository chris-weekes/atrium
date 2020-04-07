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
    public partial class ucTaxation : ucBase
    {
        public ucTaxation()
        {
            InitializeComponent();
        }

        public void BindIRPData(atriumDB.IRPDataTable a)
        {
            ucContactSelectBox1.FM = FM;
            ucOfficeSelectBox1.AtMng = FM.AtMng;
            UIHelper.ComboBoxInit("vofficerlist", iRPGridEX.DropDowns["ddOfficer"], FM);
            setBindingSources();

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetIRP().OnUpdate += new atLogic.UpdateEventHandler(ucTaxation_OnUpdate);
        }

        void ucTaxation_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.TaxationDebtor;
        }

        private void setBindingSources()
        {
            iRPBindingSource.DataMember = FM.DB.IRP.TableName;
            iRPBindingSource.DataSource = FM.DB;
            iRPBindingSource.Filter = "FileID=" + FM.CurrentFileId.ToString();
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            iRPGridEX.MoveFirst();
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                {
                    ApplyBR(false);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void ApplySecurity(DataRow dr)
        {
            atriumDB.IRPRow cbr = (atriumDB.IRPRow)dr;
            //UIHelper.EnableControls(iRPBindingSource, FM.GetIRP().CanEdit(cbr));
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            iRPBindingSource.Position = iRPBindingSource.Find("IRPId", linkId);
        }
        
        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        private atriumDB.IRPRow CurrentRow()
        {
            if (iRPBindingSource.Current == null)
                return null;
            else
                return (atriumDB.IRPRow)((DataRowView)iRPBindingSource.Current).Row;
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                    case "cmdViewSRP":
                        atriumDB.SRPRow srprow = FM.GetSRP().Load(CurrentRow().SRPID);
                        fFile agentBillingFile= FileForm().MainForm.OpenFile(srprow.FileID);
                        agentBillingFile.MoreInfo("srp", srprow.SRPID);
                        break;
                    case "cmdSRPDetail":
                        atriumDB.SRPRow srprow2 = FM.GetSRP().Load(CurrentRow().SRPID);
                        fFile agentBillingFile2= FileForm().MainForm.OpenFile(srprow2.FileID);
                        agentBillingFile2.MoreInfo("srpdetail", srprow2.SRPID);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void iRPBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            atriumDB.IRPRow dr = CurrentRow();

            if (dr == null)
                return;

            CLAS.TaxingRow[] taxRecs = (CLAS.TaxingRow[])FM.GetCLASMng().DB.Taxing.Select("IRPId=" + CurrentRow().IRPId, "TaxingDate");
            TaxRecDropDown(taxRecs);
            ApplySecurity(dr);
        }

        private void TaxRecDropDown(CLAS.TaxingRow[] trs)
        {
            uiContextMenu2.Commands.Clear();

            if (trs.Length == 0)
            {
                btnTaxRecs.Visible = false;
                return;
            }

            btnTaxRecs.Visible = true;
            btnTaxRecs.Text = "Associated Taxing Recommendations (" + trs.Length + ")";

            foreach (CLAS.TaxingRow tr in trs)
            {
                Janus.Windows.UI.CommandBars.UICommand newCmd;
                string key = "cmdTaxRec" + tr.TaxingID;
                if (uiContextMenu2.CommandManager.Commands.Contains(key))
                    newCmd = uiContextMenu2.CommandManager.Commands[key];
                else
                {
                    newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                    newCmd.Key = key;
                }

                string cmdText = "Date: " + tr.TaxingDate.ToString("yyyy/MM/dd");

                if (!tr.IsTaxDownDisbNull() && tr.TaxDownDisb > 0)
                    cmdText += "; Disb. Amount: " + tr.TaxDownDisb.ToString("C");

                if (!tr.IsTaxDownHoursNull() && tr.TaxDownHours > 0)
                    cmdText += "; Time : " + tr.TaxDownHours.ToString() + " hours";

                newCmd.Text = cmdText;
                newCmd.Tag = tr;
                newCmd.Click += new Janus.Windows.UI.CommandBars.CommandEventHandler(newCmd_Click);
                newCmd.ShowInCustomizeDialog = false;
                uiContextMenu2.Commands.Add(newCmd);
            }
        }

        void newCmd_Click(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            CLAS.TaxingRow tr = (CLAS.TaxingRow)e.Command.Tag;
            if (tr == null)
                return;

            FileForm().MoreInfo("taxing", tr.TaxingID);
        }

        private void iRPGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row != null && e.Row.DataRow != null && e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    if (e.Row.Cells["OfficerCode"].Text != "")
                        e.Row.Cells["OfficerNameCode"].Text = e.Row.Cells["OfficerID"].Text + " (" + e.Row.Cells["OfficerCode"].Text + ")";
                    else
                        e.Row.Cells["OfficerNameCode"].Text = "";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucTaxation_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                iRPGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

