using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fExportDocs : fBase
    {
        public fExportDocs()
        {
            InitializeComponent();
        }

        public fExportDocs(Form f)
            : base(f)
        {
            InitializeComponent();
            ebSQL.Text=@"select f.FullFileNumber,f.NameE,f.FileId,d.DocId,d.DocRefId,d.CurrentVersion,d.efSubject
from EFile f
inner join Document d
on d.FileId=f.FileId  
inner join SSTCase sc
on f.FileId=sc.FileId
where d.efType='GDEC'
and f.FullFileNumber not like 'SA-SAGB%'
and sc.DecisionSentDate is not null
and sc.AppealLevelID=1
and sc.ProgramId=3";

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
                        if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string path = this.folderBrowserDialog1.SelectedPath;
                            DataSet ds = (DataSet)bindingSource1.DataSource;
                            atriumBE.DocManager dm = this.AtMng.GetFile().GetDocMng();
                           
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                int docrefid = (int)dr["DocRefId"];
                                int docid = (int)dr["DocId"];
                                string version = (string)dr["CurrentVersion"];

                                lmDatasets.docDB.DocumentRow docr = dm.GetDocument().Load(docid);

                                docr.efSubject = dr["FullFileNumber"].ToString() +  " " + docr.efSubject;
                                dm.GetDocContent().Load(docrefid, version);
                                
                                dm.GetDocument().Export(docr, false,path);
                                dm.DB.DocContent.Clear();
                                dm.DB.DocContent.AcceptChanges();
                            }
                           
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

