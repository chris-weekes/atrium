using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using LawMate.UserControls;

// TFS#75221: UserControl created to accomodate adding multiple appeal grounds

namespace LawMate
{
    public partial class ucSSTAppealGround : UserControl, IRequiredCtl
    {

        atriumBE.SSTManager SSTM;
        atriumBE.FileManager myFM;
        private bool appealGroundConfirmed = false;

        public ucSSTAppealGround()
        {
            InitializeComponent();
        }

        public atriumBE.FileManager FM
        {
            get
            {
                return myFM;
            }
            set
            {
                myFM = value;
                if (myFM != null)
                {
                    SSTM = myFM.GetSSTMng();
                    SSTAppealGroundGridEX.DataSource = myFM.Codes("AppealGround");
                }
            }
        }

        public Color ReqColor
        {
            get
            {
                return Color.Transparent;
            }
            set
            {
                SSTAppealGroundGridEX.Tables[0].Columns[1].CellStyle.BackColor = value;
            }
        }

        public bool IsPopulated
        {
            get
            {
                return appealGroundConfirmed;
            }
        }

        private enum AppealGroundActivities
        {
            GDFailed = 0,
            GDErred = 1,
            GDBased =2,
            NoGround=3
        }

        private void SSTAppealGroundGridEX_RowCheckStateChanged(object sender, Janus.Windows.GridEX.RowCheckStateChangeEventArgs e)
        {
            try
            {
                btnConfirmAppealGround.Enabled = (SSTAppealGroundGridEX.GetCheckedRows().Length > 0);
                appealGroundConfirmed = false;

                Janus.Windows.GridEX.GridEXRow row;
                if (e.CheckState == Janus.Windows.GridEX.RowCheckState.Checked && e.Row == null)
                {
                    row = SSTAppealGroundGridEX.GetRow((int)AppealGroundActivities.NoGround);

                  // row = SSTAppealGroundGridEX.GetRow(2);

                    row.BeginEdit();
                    row.CheckState = Janus.Windows.GridEX.RowCheckState.Unchecked;
                    row.EndEdit();
                }

                row = SSTAppealGroundGridEX.GetRow((int)AppealGroundActivities.NoGround);
                if (row.CheckState == Janus.Windows.GridEX.RowCheckState.Checked)
                {
                    row.BeginEdit();
                    Janus.Windows.GridEX.GridEXRow rowA;
                    Janus.Windows.GridEX.GridEXRow rowB;
                    Janus.Windows.GridEX.GridEXRow rowC;
                    rowA = SSTAppealGroundGridEX.GetRow((int)AppealGroundActivities.GDFailed);
                    rowA.IsChecked = false;
                    rowA.CheckState = Janus.Windows.GridEX.RowCheckState.Unchecked;
                    rowB = SSTAppealGroundGridEX.GetRow((int)AppealGroundActivities.GDErred);
                    rowB.IsChecked = false;
                    rowB.CheckState = Janus.Windows.GridEX.RowCheckState.Unchecked;
                    rowC = SSTAppealGroundGridEX.GetRow((int)AppealGroundActivities.GDBased);
                    rowC.IsChecked = false;
                    rowC.CheckState = Janus.Windows.GridEX.RowCheckState.Unchecked;
                    row.EndEdit();
                }
                OnValidated(new EventArgs());
            

            }
            catch (Exception exc)
            {
                
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
                 
          


        }

        private void btnConfirmAppealGround_Click(object sender, EventArgs e)
        {
            
            if (SSTAppealGroundGridEX.GetCheckedRows().Length > 0)
            {
                try
                {

                    SST.SSTAppealGroundRow[] agra = (SST.SSTAppealGroundRow[])SSTM.DB.SSTAppealGround.Select("FileId=" + FM.CurrentFileId.ToString());

                    // delete existing appeal grounds
                    foreach (SST.SSTAppealGroundRow dr in agra)
                    {
                        SSTM.DB.SSTAppealGround.RemoveSSTAppealGroundRow(dr);
                    }
                    
                    SST.SSTDecisionRow sdr = null;
                    foreach (SST.SSTDecisionRow sstd in SSTM.DB.SSTDecision)
                    {
                        //if (sstd.DecisionType == 4)
                            sdr = sstd;
                    }

                    SST.SSTAppealGroundRow sstagr;
                    // add new appeal grounds
                    foreach (Janus.Windows.GridEX.GridEXRow gexr in SSTAppealGroundGridEX.GetCheckedRows())
                    {
                        if (gexr.IsChecked)
                        {
                            sstagr = (SST.SSTAppealGroundRow)SSTM.GetSSTAppealGround().Add(sdr);
                            sstagr.AppealGroundId = (int)gexr.Cells[0].Value;
                            sstagr.ConfirmedByMemberId = myFM.AtMng.WorkingAsOfficer.OfficerId;
                        }
                    }

                    appealGroundConfirmed = true;
                    
                }
                catch(Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
                OnValidated(new EventArgs());
                btnConfirmAppealGround.Enabled = false;
            }
            else
            {
                UIHelper.NoAppealGroundSelected();
            }
        }

        private void SSTAppealGroundGridEX_EditingCell(object sender, Janus.Windows.GridEX.EditingCellEventArgs e)
        {
            if (e.Column.ActAsSelector == true)
            {
                Janus.Windows.GridEX.GridEXRow row;
            }

        }

        private void SSTAppealGroundGridEX_UpdatingCell(object sender, Janus.Windows.GridEX.UpdatingCellEventArgs e)
        {
            if (e.Column.ActAsSelector == true)
            {
                Janus.Windows.GridEX.GridEXRow row;
            }

        }

        private void SSTAppealGroundGridEX_RowCheckStateChanging(object sender, Janus.Windows.GridEX.RowCheckStateChangingEventArgs e)
        {
    //        btnConfirmAppealGround.Enabled = (SSTAppealGroundGridEX.GetCheckedRows().Length > 0);
    //        appealGroundConfirmed = false;
             
    ////        SSTAppealGroundGridEX.RowCheckStateBehavior()
             
    //        Janus.Windows.GridEX.GridEXRow row;
    //        if (e.CheckState == Janus.Windows.GridEX.RowCheckState.Checked && e.Row == null)
    //        {
                
    //            row = SSTAppealGroundGridEX.GetRow(3);
    //            row.BeginEdit();
    //            row.Cells["AppealGroundChecked"].Selected = false;
    //            row.Cells["AppealGroundChecked"].Value = 0;    
    //            row.EndEdit();
    //        }

        }


        public void RequiredAction()
        {
           
        }
    }
}