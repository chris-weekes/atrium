using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fSQL : fBase
    {
        public fSQL()
        {
            InitializeComponent();
        }

        public fSQL(Form f)
            : base(f)
        {
            InitializeComponent();
        }

        public void OfficeDistributionProjection()
        {
            ebSQL.Text = AtMng.GetPLOffice().OfficeDistributionProjectionQuery();
        }

        private void gridEX1_EditModeChanged(object sender, EventArgs e)
        {
            if (gridEX1.EditTextBox != null)
            {
                gridEX1.EditTextBox.ReadOnly = true;
            }
        }

        private void txtSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == System.Windows.Forms.Keys.A))
            {
                ebSQL.SelectAll();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdSave":
                        this.saveFileDialog1.ShowDialog();
                        string file = this.saveFileDialog1.FileName;
                        if (file == "")
                            return;

                        DataSet dt = (DataSet)bindingSource1.DataSource;

                        dt.WriteXml(file, XmlWriteMode.WriteSchema);
                        break;
                    case "cmdExamine":
                        if (MessageBox.Show("This will clear the current text in the Query text field. Are you sure you want to clear the text?", "Clear Current Text", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            ebSQL.Text = "";
                            DataSet dt2 = new DataSet();
                           
                            this.openFileDialog1.ShowDialog();
                            string file2 = this.openFileDialog1.FileName;
                            if (file2 == "")
                                return;

                            dt2.ReadXml(file2);

                            bindingSource1.DataSource = dt2;
                            gridEX1.DataSource = dt2;
                            gridEX1.RetrieveStructure(true);
                            
                        }
                        break;
                    case "cmdExecute":
                        try
                        {
                            ebMessage.Text = "Executing...Please Wait";
                            ebCount.Text = "";

                            string sSQL = ebSQL.Text;
                            if (ebSQL.SelectedText.Length > 0)
                                sSQL = ebSQL.SelectedText;

                            if (sSQL == "")
                            {
                                ebMessage.Text = "No query to execute";
                                ebCount.Text = "";
                                return;
                            }

                            DataSet ds = AtMng.AppMan.ExecuteDatasetSQL(sSQL);
                            bindingSource1.DataSource = ds;
                            gridEX1.DataSource = ds;

                            
                            gridEX1.RetrieveStructure(true);
                            foreach (Janus.Windows.GridEX.GridEXColumn gc in gridEX1.Tables[1].Columns)
                            {
                                gc.EditType = Janus.Windows.GridEX.EditType.NoEdit;
                                if (gc.DataTypeCode == TypeCode.DateTime)
                                    gc.FormatString = "g";
                                
                            }
                            ebMessage.Text = "Done";
                            if (ds.Tables.Count > 0)
                            {
                                ebCount.Text = ds.Tables[0].Rows.Count.ToString();
                                gridEX1.ExpandRecords();
                            }
                        }
                        catch (Exception x)
                        {
                            ebMessage.Text = "Error: " + x.Message;
                            ebCount.Text = "";
                            UIHelper.HandleUIException(x);
                        }
                        break;
                    case "cmdSaveExcel":
                         this.saveFileDialog1.ShowDialog();
                        string file3 = this.saveFileDialog1.FileName;
                        if (file3 == "")
                            return;

                        Janus.Windows.GridEX.Export.GridEXExporter oExport = new Janus.Windows.GridEX.Export.GridEXExporter();
                        oExport.GridEX = gridEX1;


                        oExport.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows;
                        oExport.IncludeChildTables = true;
                        oExport.IncludeCollapsedRows = true;
                        oExport.IncludeExcelProcessingInstruction = true;
                        oExport.IncludeFormatStyle = true;
                        oExport.IncludeHeaders = true;

                        System.IO.FileStream LayoutStream = new System.IO.FileStream(file3, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                        oExport.Export(LayoutStream);
                        LayoutStream.Close();
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

