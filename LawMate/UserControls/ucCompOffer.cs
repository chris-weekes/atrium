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
    public partial class ucCompOffer : ucBase
    {
        public ucCompOffer()
        {
            InitializeComponent();
        }
        public void BindCompOfferData(CLAS.CompOfferDataTable compOfferTable)
        {
            officeIducOfficeSelectBox.AtMng = FM.AtMng;

            atriumDB_CompOfferDetailDataTableBindingSource.DataMember = "CompOfferDetail";
            atriumDB_CompOfferDataTableBindingSource.DataMember = "CompOffer";
            
            atriumDB_CompOfferDetailDataTableBindingSource.DataSource = compOfferTable.DataSet;
            atriumDB_CompOfferDataTableBindingSource.DataSource = compOfferTable.DataSet;
            

            compOfferTable.ColumnChanged += new DataColumnChangeEventHandler(compOfferTable_ColumnChanged);
            FM.GetCLASMng().DB.CompOfferDetail.ColumnChanged += new DataColumnChangeEventHandler(compOfferTable_ColumnChanged);

            FM.GetCLASMng().GetCompOffer().OnUpdate += new atLogic.UpdateEventHandler(ucCompOffer_OnUpdate);
            FM.GetCLASMng().GetCompOfferDetail().OnUpdate += new atLogic.UpdateEventHandler(ucCompOffer_OnUpdate);
        }

        void ucCompOffer_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void compOfferTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.CompOffer;
        }

        public override void ReloadUserControlData()
        {
            FM.GetCLASMng().GetCompOffer().PreRefresh();
            FM.GetCLASMng().GetCompOfferDetail().PreRefresh();
            
            //FM.GetCLASMng().GetCompOffer().LoadByFileID(FM.CurrentFile.FileId);
            //FM.GetCLASMng().GetCompOfferDetail().LoadByFileId(FM.CurrentFile.FileId);
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void EndEdit()
        {
            atriumDB_CompOfferDataTableBindingSource.EndEdit();
            atriumDB_CompOfferDetailDataTableBindingSource.EndEdit();
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(atriumDB_CompOfferDataTableBindingSource, !makeReadOnly);
            UIHelper.EnableControls(atriumDB_CompOfferDetailDataTableBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
                ApplyDetailSecurity(CurrentRowDetail());
            }
        }

        public override void ApplySecurity(DataRow dr)
        {
            CLAS.CompOfferRow cbr = (CLAS.CompOfferRow)dr;
            UIHelper.EnableControls(atriumDB_CompOfferDataTableBindingSource, FM.GetCLASMng().GetCompOffer().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetCompOffer().CanDelete(cbr));
        }

        public void ApplyDetailSecurity(DataRow dr)
        {
            if (dr != null)
            {
                CLAS.CompOfferDetailRow cbr = (CLAS.CompOfferDetailRow)dr;
                UIHelper.EnableControls(atriumDB_CompOfferDetailDataTableBindingSource, FM.GetCLASMng().GetCompOfferDetail().CanEdit(cbr));
            }
        }

        private int NavId = -1;
        public override void MoreInfo(string linkTable, int linkId)
        {
            if (linkTable.ToUpper() == "COMPOFFER")
            {
                atriumDB_CompOfferDataTableBindingSource.Position = atriumDB_CompOfferDataTableBindingSource.Find("CompOfferId", linkId);
                NavId = linkId;
            }
            else if (linkTable.ToUpper() == "COMPOFFERDETAIL")
            {
                CLAS.CompOfferDetailRow[] codr = (CLAS.CompOfferDetailRow[])FM.GetCLASMng().DB.CompOfferDetail.Select("CompOfferDetailId=" + linkId);
                if (codr.Length == 0)
                    throw new Exception("Record could not be found");

                CLAS.CompOfferRow[] cor = (CLAS.CompOfferRow[])FM.GetCLASMng().DB.CompOffer.Select("CompOfferId=" + codr[0].CompOfferId);

                atriumDB_CompOfferDataTableBindingSource.Position = atriumDB_CompOfferDataTableBindingSource.Find("CompOfferId", cor[0].CompOfferId);
                atriumDB_CompOfferDetailDataTableBindingSource.Position = atriumDB_CompOfferDetailDataTableBindingSource.Find("CompOfferDetailId", linkId);
            }
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
            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
        }

        public override void Save()
        {
            if (FM.GetCLASMng().DB.CompOffer.HasErrors || FM.GetCLASMng().DB.CompOfferDetail.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetCLASMng().DB);
            }
            else
            {
                try
                {
                    atriumDB_CompOfferDataTableBindingSource.EndEdit();
                    atriumDB_CompOfferDetailDataTableBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();

                    bp.AddForUpdate(FM.GetCLASMng().GetCompOffer());
                    bp.AddForUpdate(FM.GetCLASMng().GetCompOfferDetail());
                    bp.AddForUpdate(FM.EFile);

                    bp.Update();
                  
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
                if (atriumDB_CompOfferDetailDataTableBindingSource.Count > 0)
                {
                    throw new LMException("Must delete offer details before deleting a compromise offer record");
                }
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    atriumDB_CompOfferDataTableBindingSource.EndEdit();

                    FM.SaveAll();

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

        private void DeleteCompOfferDetail()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowDetail().Delete();
                    atriumDB_CompOfferDetailDataTableBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetCompOfferDetail());
                   
                    bp.Update();

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

        private CLAS.CompOfferRow CurrentRow()
        {
            if (atriumDB_CompOfferDataTableBindingSource.Current == null)
                return null;
            else
                return (CLAS.CompOfferRow)((DataRowView)atriumDB_CompOfferDataTableBindingSource.Current).Row;
        }

        private CLAS.CompOfferDetailRow CurrentRowDetail()
        {
            if (atriumDB_CompOfferDetailDataTableBindingSource.Current == null)
                return null;
            else
                return (CLAS.CompOfferDetailRow)((DataRowView)atriumDB_CompOfferDetailDataTableBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(atriumDB_CompOfferDataTableBindingSource);
            UIHelper.Cancel(atriumDB_CompOfferDetailDataTableBindingSource);
            ApplyBR(true);
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
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

         private void atriumDB_CompOfferDataTableBindingSource_CurrentChanged(object sender, EventArgs e)
         {
             try
             {
                 if (CurrentRow() == null)
                     return;

                 if (CurrentRow().IsNull("CompOfferId"))
                     return;

                 //apply security
                 ApplySecurity(CurrentRow());
                 atriumDB_CompOfferDetailDataTableBindingSource.Filter = "CompOfferId=" + CurrentRow().CompOfferId;

             }
             catch (Exception x)
             {
                 UIHelper.HandleUIException(x);
             }
         }

         private void atriumDB_CompOfferDetailDataTableBindingSource_CurrentChanged(object sender, EventArgs e)
         {
             try
             {
                 CLAS.CompOfferDetailRow cbr = CurrentRowDetail();
                 ApplyDetailSecurity(cbr);
             }
             catch (Exception x)
             {
                 UIHelper.HandleUIException(x);
             }
         }

         private void ucCompOffer_Load(object sender, EventArgs e)
         {
             try
             {
                ApplySecurity(CurrentRow());
                ApplyDetailSecurity(CurrentRowDetail());
                atriumDB_CompOfferDetailDataTableGridEX.MoveFirst();
             }
             catch (Exception x)
             {
                 UIHelper.HandleUIException(x);
             }
         }


    }
}
