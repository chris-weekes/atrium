using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace LawMate.Admin
{
    public enum DataConfigType
    {
        WorkflowActivityCongif,
        DataDictionnary,
        OtherCodes
    }
    public partial class fConfigCompare : Form
    {
        DataTable dtAdd;
        DataTable dtEdit;
        DataTable dtDelete;
        DataConfigType ConfigType;
        DataSet configFileDataset;
        DataSet dsACConfig;
        DataSet dsAtrium;
        DataSet dsSecurity;
        atriumBE.atriumManager AtMng;


        public fConfigCompare()
        {
            InitializeComponent();
        }

        public void Init(string filename, DataConfigType configtype, atriumBE.atriumManager atmng)
        {
            AtMng = atmng;
            lblConfigFile.Text = filename;
            lblDB.Text = AtMng.AppMan.ServerInfo.serverName;
            ConfigType = configtype;
            CreateDTsSetDS(configtype);

            configFileDataset = new DataSet();
            configFileDataset.ReadXml(filename);

            DoCompare(configtype);

        }

        private void DoCompare(DataConfigType configtype)
        {
            if (configtype == DataConfigType.WorkflowActivityCongif)
                DoWorkflowCompare();
            else if (configtype == DataConfigType.DataDictionnary)
                DoDataDictionnaryCompare();
            else if (configtype == DataConfigType.OtherCodes)
                DoOtherCodesCompare();
            else
                MessageBox.Show("Something has gone wrong ... DataConfigType is not specified");
        }


        private void DoWorkflowCompare()
        {
            foreach (DataTable dt in configFileDataset.Tables)
            {
                IEnumerable<DataRow> configTable = from tableData in dt.AsEnumerable() select tableData;
                IEnumerable<DataRow> dbTable = from tableData in dsACConfig.Tables[dt.ToString()].AsEnumerable() select tableData;

                DataTable copyConfigTable = configTable.CopyToDataTable();
                DataTable copyDBTable = dbTable.CopyToDataTable();

                var NewData = copyConfigTable.AsEnumerable().Except(copyDBTable.AsEnumerable(), DataRowComparer.Default);
                var DeleteData = copyDBTable.AsEnumerable().Except(copyConfigTable.AsEnumerable(), DataRowComparer.Default);

                foreach (DataRow dr in NewData)
                {
                     
                    DataRow drNew = dtAdd.NewRow();
                    drNew[0] = dt.TableName;
                    drNew[1] = GetColumnNames(dt); //overkill for each row, ugh
                    drNew[2] = GetRowValues(dr);
                    dtAdd.Rows.Add(drNew);
                }

                foreach (DataRow dr in DeleteData)
                {
                    DataRow drDelete = dtDelete.NewRow();
                    drDelete[0] = dt.TableName;
                    drDelete[1] = GetColumnNames(dt); //overkill for each row, ugh
                    drDelete[2] = GetRowValues(dr);
                    dtDelete.Rows.Add(drDelete);
                }
            }

            dtAdd.AcceptChanges();
            dtDelete.AcceptChanges();
            gridEX1.DataSource = dtAdd;
            gridEX3.DataSource = dtDelete;
            gridEX1.Refresh();
            gridEX3.Refresh();
        }

        private string GetColumnNames(DataTable dt)
        {
            string rValue = "";
            foreach (DataColumn dc in dt.Columns)
            {
                if (rValue != "")
                    rValue += ", ";
                rValue += dc.ColumnName;
            }
            return rValue;
        }

        private string GetRowValues(DataRow dr)
        {
            string rValue = "";
            foreach (DataColumn dc in dr.Table.Columns)
            {
                if (rValue != "")
                    rValue += ", ";
                rValue += dr[dc].ToString();
            }
            return rValue;

        }

        private void DoDataDictionnaryCompare()
        {

        }

        private void DoOtherCodesCompare()
        {

        }

        private void CreateDTsSetDS(DataConfigType configtype)
        {
            dtAdd = new DataTable();
            dtAdd.Columns.Add("Table", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("Columns", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("Values", System.Type.GetType("System.String"));

            dtEdit = new DataTable();
            dtEdit.Columns.Add("Table", System.Type.GetType("System.String"));
            dtEdit.Columns.Add("Column", System.Type.GetType("System.String"));
            dtEdit.Columns.Add("From", System.Type.GetType("System.String"));
            dtEdit.Columns.Add("To", System.Type.GetType("System.String"));

            dtDelete = new DataTable();
            dtDelete.Columns.Add("Table", System.Type.GetType("System.String"));
            dtDelete.Columns.Add("Columns", System.Type.GetType("System.String"));
            dtDelete.Columns.Add("Values", System.Type.GetType("System.String"));

            switch (configtype)
            {
                case DataConfigType.WorkflowActivityCongif:
                    dsACConfig = AtMng.acMng.DB;
                    break;
                case DataConfigType.DataDictionnary:
                    dsAtrium= AtMng.DB;
                    AtMng.SecurityManager.LoadAll(true);
                    dsSecurity = AtMng.SecurityManager.DB;
                    break;
            }
        }


        private void btnViewXMLConfig_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(lblConfigFile.Text);
                System.Diagnostics.Process.Start(sInfo);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


    }
}
