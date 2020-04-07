using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate
{
    public partial class fBatchReview : fBase
    {
        //FileManager fmCurrent;

        public fBatchReview()
        {
            InitializeComponent();
        }

        public fBatchReview(Form f): base(f)
        {
            InitializeComponent();
            AtMng.GetBatch().LoadByOfficeCode(AtMng.OfficeLoggedOn.OfficeCode);
            BindBatchData(AtMng.DB.Batch);
            batchGridEX.MoveFirst();
        }

        private void BindBatchData(appDB.BatchDataTable dt)
        {
            batchBindingSource.DataSource = dt.DataSet;
            batchBindingSource.DataMember = dt.TableName;

        }

        private appDB.BatchRow CurrentRow()
        {
            return (appDB.BatchRow)((DataRowView)batchBindingSource.Current).Row;
        }
        
        public void MoreInfo(int linkId)
        {
            batchBindingSource.Position = batchBindingSource.Find("BatchId", linkId);
        }
        private void Save()
        {
            if (AtMng.DB.Batch.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.DB);
            }
            else
            {
                try
                {
                    batchBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetBatch());
                    bp.Update();
                   
                }
                catch (Exception x)
                {
                   
                   throw x;
                }
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsReload":
                        AtMng.DB.Batch.Clear();
                        AtMng.GetBatch().LoadByOfficeCode(AtMng.OfficeLoggedOn.OfficeCode);
                        batchGridEX.Row= 0;
                        break;
                    case "tsMarkAsRead":
                        
                        CurrentRow().Status = "R";
                        Save();

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


        
    }
}

