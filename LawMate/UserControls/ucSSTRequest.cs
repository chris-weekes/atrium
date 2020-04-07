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
    public partial class ucSSTRequest : ucBase
    {
        atriumBE.SSTManager SSTM;

        public ucSSTRequest()
        {
            InitializeComponent();
        }

        public void bindData(lmDatasets.SST.SSTRequestDataTable dt)
        {
            SSTM = FM.GetSSTMng();

            setBindingSources();

            UIHelper.ComboBoxInit("vReqType", sSTRequestGridEX.DropDowns["ddReqType"], FM);

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            SSTM.DB.SSTReqRecipient.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);

            SSTM.GetSSTRequest().OnUpdate += new atLogic.UpdateEventHandler(ucSSTRequest_OnUpdate);
            SSTM.GetSSTReqRecipient().OnUpdate += new atLogic.UpdateEventHandler(ucSSTRequest_OnUpdate);

        }

        void ucSSTRequest_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (FM.IsFieldChanged(e.Column, e.Row))
                ApplyBR(false);
        }

        private void setBindingSources()
        {
            sSTRequestBindingSource.DataMember = SSTM.DB.SSTRequest.TableName;
            sSTRequestBindingSource.DataSource = SSTM.DB;
        }

        public override string ucDisplayName()
        {
            return "Correspondence Requests";
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void EndEdit()
        {
            sSTRequestBindingSource.EndEdit();
        }

        public override void ApplySecurity(DataRow dr)
        {
            SST.SSTRequestRow cbr = (SST.SSTRequestRow)dr;
            UIHelper.EnableControls(sSTRequestBindingSource, SSTM.GetSSTRequest().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, SSTM.GetSSTRequest().CanDelete(cbr));
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
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(sSTRequestBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            sSTRequestBindingSource.Position = sSTRequestBindingSource.Find("SSTReqId", linkId);
        }

        public override void Save()
        {
            if (SSTM.DB.SSTRequest.HasErrors || SSTM.DB.SSTReqRecipient.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(SSTM.DB);
            }
            else
            {
                try
                {
                    sSTRequestGridEX.UpdateData();
                    this.sSTRequestBindingSource.EndEdit();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();

                    //bp.AddForUpdate(SSTM.GetSSTRequest());
                    //bp.AddForUpdate(SSTM.GetSSTReqRecipient());
                    //bp.AddForUpdate(FM.EFile);
                    //bp.Update();


                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }

        public override void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    if (sSTRequestGridEX.CurrentTable.Key == "SSTRequest")
                    {
                        foreach (SST.SSTReqRecipientRow rrr in CurrentRow().GetSSTReqRecipientRows())
                        {
                            rrr.Delete();
                        }

                        CurrentRow().Delete();
                    }
                    else
                    {
                        CurrentRow().updateDate = DateTime.UtcNow; //this forces the validation rules on SSTRequest to fire preventing a request with no recipients
                        sSTRequestGridEX.CurrentRow.Delete();
                        //sSTRequestGridEX.Delete();
                        sSTRequestGridEX.UpdateData();
                        this.sSTRequestBindingSource.EndEdit();
                    }
                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();

                    //bp.AddForUpdate(SSTM.GetSSTReqRecipient());
                    //bp.AddForUpdate(SSTM.GetSSTRequest());

                    //bp.Update();

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private SST.SSTRequestRow CurrentRow()
        {
            if (sSTRequestBindingSource.Current == null)
                return null;
            else
                return (SST.SSTRequestRow)((DataRowView)sSTRequestBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(sSTRequestBindingSource);
            SSTM.DB.SSTRequest.RejectChanges();
            SSTM.DB.SSTReqRecipient.RejectChanges();
            FM.CurrentFile.RejectChanges();
            ApplyBR(true);

        }

        private void AddRecip()
        {
            int id = 0;
            fContactSelect f = new fContactSelect(FM, null, true,true,true);
            if (f.ShowDialog() == DialogResult.OK)
            {
                id = f.ContactId;
                SST.SSTReqRecipientRow rrr = (SST.SSTReqRecipientRow)SSTM.GetSSTReqRecipient().Add(CurrentRow());

                rrr.SentToContactId = id;

                FM.SaveAll();
            }
        }
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsAddRecip":
                        AddRecip();
                        break;
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
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void sSTRequestBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("SSTReqId"))
                    return;

                ApplySecurity(CurrentRow());

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucSSTRequest_Load(object sender, EventArgs e)
        {
            try
            {
                sSTRequestGridEX.ExpandRecords();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
