using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;

 namespace LawMate
{
    public partial class fMandateList : Form
    {

        DataTable dtMandate;
        fMain fmain;
        atriumManager atmng;
        Janus.Windows.UI.CommandBars.UICommand cmd;

        public fMandateList()
        {
            InitializeComponent();
        }

        public fMandateList(fMain mainForm)
        {

            InitializeComponent();
            fmain = mainForm;
            atmng = fmain.AtMng;
            dtMandate = new DataTable("mandateList");
            dtMandate.Columns.Add("AcSeriesId", typeof(int));
            dtMandate.Columns.Add("SeriesId", typeof(int));
            dtMandate.Columns.Add("Activity", typeof(string));
            dtMandate.Columns.Add("Workflow", typeof(string));
            dtMandate.Columns.Add("AcSeriesDeskbookLink", typeof(string));
            dtMandate.Columns.Add("SeriesDeskbookLink", typeof(string));
            
            FileManager FMforTranslation = atmng.GetFile();
            FileManager cntFM = null;

            lmDatasets.ActivityConfig.OfficeMandateRow[] omrs = (lmDatasets.ActivityConfig.OfficeMandateRow[]) atmng.acMng.DB.OfficeMandate.Select("OfficeId="+atmng.WorkingAsOfficer.OfficeId.ToString());
            
            foreach (lmDatasets.ActivityConfig.OfficeMandateRow omr in omrs)
            {
                try
                {
                    //new form
                    if (omr.ACSeriesRow.SeriesRow.IsContainerFileIdNull())
                        cntFM = null;
                    else
                        cntFM = atmng.GetFile(omr.ACSeriesRow.SeriesRow.ContainerFileId);

                    if (!omr.ACSeriesRow.Obsolete && atriumBE.Workflow.AllowedForRole(omr.ACSeriesRow, atmng, cntFM))
                    {
                        string ActDesc;
                        if (!omr.ACSeriesRow.IsNull(UIHelper.Translate(FMforTranslation, "DescEng")))
                            ActDesc = omr.ACSeriesRow.ActivityCodeRow[UIHelper.Translate(FMforTranslation, "ActivityNameEng")].ToString() + ": " + omr.ACSeriesRow[UIHelper.Translate(FMforTranslation, "DescEng")].ToString();
                        else
                            ActDesc = omr.ACSeriesRow.ActivityCodeRow[UIHelper.Translate(FMforTranslation, "ActivityNameEng")].ToString();

                        ActDesc = "(" + omr.ACSeriesRow.StepCode + ") " + ActDesc ;

                        string gridRowKey = "NewMandate" + omr.ACSeriesRow.StepCode;
                        string WorkflowText = omr.ACSeriesRow.SeriesRow.SeriesCode + " - " + omr.ACSeriesRow.SeriesRow[UIHelper.Translate(FMforTranslation, "SeriesDescEng")].ToString();

                        ////TFS#54757 JLL 2013-8-29 modify to include help for series and acseries
                        string AcSeriesHelpLink;
                        string AcSeriesHelpLinkColumn = UIHelper.Translate(FMforTranslation, "HelpE");
                        if (!omr.ACSeriesRow.IsNull(AcSeriesHelpLinkColumn) && omr.ACSeriesRow[AcSeriesHelpLinkColumn].ToString() != "")
                            AcSeriesHelpLink = Properties.Resources.mHelp;
                        else
                            AcSeriesHelpLink = "";

                        ////TFS#54757 JLL 2013-8-29 modify to include help for series and acseries
                        string SeriesHelpLink;
                        string SeriesHelpLinkColumn = UIHelper.Translate(FMforTranslation, "HelpLinkE");
                        if (!omr.ACSeriesRow.SeriesRow.IsNull(SeriesHelpLinkColumn) && omr.ACSeriesRow.SeriesRow[SeriesHelpLinkColumn].ToString() != "")
                            SeriesHelpLink = Properties.Resources.mHelp;
                        else
                            SeriesHelpLink = "";

                        dtMandate.Rows.Add(omr.ACSeriesRow.ACSeriesId, omr.ACSeriesRow.SeriesId, ActDesc, WorkflowText, AcSeriesHelpLink, SeriesHelpLink);
                        BindData();
                    }
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
            }

        }

        public void BindData()
        {
            gridEX1.DataSource = dtMandate;
            gridEX1.DataMember = "";
            UIHelper.SetDataTableAsGridDataSource(gridEX1, dtMandate);
        }

        private void CheckForMandateReturn()
        {
            if (CurrentAcSeriesId() != -1)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Hide();
                if (fmain != null)
                    fmain.Refresh();
            }
        }

        public int CurrentAcSeriesId()
        {
            DataRow dr = (DataRow)((DataRowView)gridEX1.GetRow().DataRow).Row;
            if (dr != null)
                return (int)dr[0];
            else
                return -1;
        }

        public int CurrentSeriesId()
        {
            DataRow dr = (DataRow)((DataRowView)gridEX1.GetRow().DataRow).Row;
            if (dr != null)
                return (int)dr[1];
            else
                return -1;
        }

        private void fMandateList_Load(object sender, EventArgs e)
        {
            try
            {
                gridEX1.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridEX1_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "AcSeriesHelp")
                {
                    DataRow dr = (DataRow)((DataRowView)gridEX1.GetRow().DataRow).Row;
                    if (dr["AcSeriesDeskbookLink"].ToString() == Properties.Resources.mHelp)
                    {
                        ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)UIHelper.AtMng.acMng.DB.ACSeries.FindByACSeriesId(CurrentAcSeriesId());
                        fTriangle HelpTriangle = new fTriangle(acsr, UIHelper.AtMng);
                        HelpTriangle.Show();
                    }
                }
                if (e.Column.Key == "SeriesHelp")
                {
                    DataRow dr = (DataRow)((DataRowView)gridEX1.GetRow().DataRow).Row;
                    if (dr["SeriesDeskbookLink"].ToString() == Properties.Resources.mHelp)
                    {
                        ActivityConfig.SeriesRow asr = (ActivityConfig.SeriesRow)UIHelper.AtMng.acMng.DB.Series.FindBySeriesId(CurrentSeriesId());
                        fTriangle HelpTriangle = new fTriangle(asr, UIHelper.AtMng);
                        HelpTriangle.Show();
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridEX1_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                using (fWait fwait = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    if (e.Column.Key == "AcSeriesId")
                        CheckForMandateReturn();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                using (fWait fwait = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    if (gridEX1.GetRow().RowType == Janus.Windows.GridEX.RowType.Record)
                        CheckForMandateReturn();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Hide();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}