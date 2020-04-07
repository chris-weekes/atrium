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
    public partial class fBrowseTemplates : Form
    {
        private appDB.TemplateRow selectedTemplate;
        private string selectedLetterName;
        private atriumManager Atmng;
        private atriumBE.FileManager myFM;
        atriumBE.DocManager myDM;

        public atriumBE.FileManager CurrentFM;
        private string templateList;

        bool dontRender = false;

        public string TemplateList
        {
            get { return templateList; }
            set
            {
                templateList = value;
                DataTable dt = myFM.Codes(templateList);
                appDB.TemplateDataTable dtt = new appDB.TemplateDataTable();
                //(appDB.TemplateDataTable)Atmng.DB.Template.Select().CopyToDataTable();
                foreach (appDB.TemplateRow dtr in Atmng.DB.Template)
                {
                    if (dt.Select("Lettername='" + dtr.LetterName + "'").Length > 0)
                    {
                        dtt.LoadDataRow(dtr.ItemArray, true);
                    }
                }

                dontRender = true;
                templateBindingSource.DataSource = dtt;
                dontRender = false;
                // templateGridEX.MoveFirst();
            }
        }

        public appDB.TemplateRow SelectedTemplate
        {
            get { return selectedTemplate; }
        }

        public string LetterName
        {
            get { return selectedLetterName; }
        }


        public fBrowseTemplates()
        {
            InitializeComponent();
        }




        public fBrowseTemplates(atriumManager atmng)
        {
            try
            {
                InitializeComponent();
                Atmng = atmng;
                myFM = Atmng.GetTemplate().FM;
                myFM.GetDocMng();

                myDM = myFM.GetDocMng();
                this.ucDocView1.Init(myDM);



                dontRender = true;
                //     Atmng.GetTemplate().Load();
                templateBindingSource.DataSource = new DataView(Atmng.DB.Template, "DocType not in ('AFS','ALH') and Obsolete=false", "LetterName", DataViewRowState.CurrentRows);
                //lblCurrentFile.Text = "";
                //UIHelper.TranslateGridEx(templateGridEX);
                dontRender = false;
                //templateGridEX.MoveFirst();

                //ucDocView1.Init();

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (templateGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
                    selectedTemplate = CurrentRow();
                this.Close();
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
                selectedLetterName = null;
                selectedTemplate = null;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        docDB.DocumentRow CurrentDocRow;
        private void templateBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {


                CurrentDocRow = Atmng.GetTemplate().GetTemplateDoc(CurrentRow());

                if (dontRender)
                    return;
                if (CurrentDocRow == null)
                {
                    ucDocView1.Clear();
                }
                else if (CurrentFM == null)
                {
                    if (!CurrentRow().IsNull("LetterName"))
                    {
                        this.ucDocView1.Init(myDM);

                        if (ucDocView1.DocRecord == null || ucDocView1.DocRecord != null && ucDocView1.DocRecord.DocId != CurrentDocRow.DocId)
                        {
                            ucDocView1.Datasource = new DataView(CurrentDocRow.Table, "Docid=" + CurrentDocRow.DocId.ToString(), "", DataViewRowState.CurrentRows);
                            ucDocView1.Preview();
                        }

                    }
                }
                else
                {
                    if (!CurrentRow().IsNull("LetterName"))
                    {
                        // FileManager fmTemp = Atmng.GetFile();
                        DocManager dmTemp = CurrentFM.GetDocMng();
                        docDB.DocumentRow ddr = (docDB.DocumentRow)CurrentFM.CurrentActivityProcess.CurrentACE.relTables["Document0"][0].Row;// (docDB.DocumentRow)dmTemp.GetDocument().Add(CurrentFM.CurrentFile);
                        if (CurrentRow().LetterName.EndsWith("-F"))
                            ddr.LanguageCode = "F";
                        else
                            ddr.LanguageCode = "E";
                        dmTemp.GetDocument().AutoSubject = true;
                        ddr.templateCode = CurrentRow().LetterName;
                        if (!CurrentRow().IsDocTypeNull())
                            ddr.efType = CurrentRow().DocType;
                        CurrentFM.CurrentActivityProcess.CurrentACE.DocumentDefaults(true);
                        dmTemp.GetDocument().AutoSubject = false;
                        //docDB.DocContentRow dcr = (docDB.DocContentRow)dmTemp.GetDocContent().Add(ddr);
                        //Atmng.GetTemplate().GenLetter(ddr, CurrentFM, CurrentRow().LetterName, CurrentFM.CurrentActivityProcess.CurrentACE.relTables);

                        this.ucDocView1.Init(dmTemp);

                        if (ucDocView1.DocRecord == null || ucDocView1.DocRecord != null && ucDocView1.DocRecord.DocId != CurrentDocRow.DocId)
                        {
                            ucDocView1.Datasource = new DataView(ddr.Table, "Docid=" + ddr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                            ucDocView1.Preview();
                        }

                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void officeGridEX_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private appDB.TemplateRow CurrentRow()
        {
            if (templateBindingSource.Current != null)
                return (appDB.TemplateRow)((DataRowView)templateBindingSource.Current).Row;
            else
                return null;
        }

        private void fBrowseTemplate_load(object sender, EventArgs e)
        {
            try
            {
                templateBindingSource.CurrentChanged += new EventHandler(templateBindingSource_CurrentChanged);
                dontRender = true;
                templateBindingSource.ResetBindings(false);
                dontRender = false;
                templateGridEX.MoveFirst();

                atriumBE.FileManager FMCodes = Atmng.GetFile();

                ebSearch.Focus();
            }
            catch (Exception x)
            { }
            
        }

        private void templateGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                appDB.TemplateRow template = (appDB.TemplateRow)((DataRowView)e.Row.DataRow).Row;
                string baseTemplateCode = template.LetterName;
                if (template.LetterName.IndexOf("-") != -1)
                    baseTemplateCode = template.LetterName.Substring(0, template.LetterName.IndexOf("-"));

                System.Text.StringBuilder tmp = new System.Text.StringBuilder();
                DataTable dtUsed = Atmng.GetTemplate().InitddtUsedInSteps();

                bool isUsed = false;
                Atmng.GetTemplate().WhereUsed(isUsed, baseTemplateCode, dtUsed, template);
                foreach (DataRow dr in dtUsed.Rows)
                {
                    tmp.AppendFormat("{0}, ", dr["StepCode"]);
                }


                template.AssociatedActivities = tmp.ToString();
                if (!template.IsAssociatedActivitiesNull() && template.AssociatedActivities.EndsWith(", "))
                {
                    template.AssociatedActivities = template.AssociatedActivities.Remove(template.AssociatedActivities.Length - 2, 2);
                }
                
                template.AcceptChanges();
            }
            catch (Exception x)
            { }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ebSearch.Text = ebSearch.Text.Trim();
                
                templateBindingSource.Filter = "obsolete=false and Letterdesc" + Atmng.AppMan.Language + " like '%" + ebSearch.Text + "%'";
                templateBindingSource.MoveFirst();
                
                templateGridEX.Focus();
            }
            catch (Exception x)
            { }

        }


        private void fBrowseTemplates_Shown(object sender, EventArgs e)
        {
            try
            {
                ebSearch.Focus();
            }
            catch (Exception x)
            { }
            
        }

        private void ebSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    bSearch.PerformClick();
            }
            catch (Exception x)
            { }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ebSearch.Text = "";

                templateBindingSource.Filter = "obsolete=false";
                templateBindingSource.MoveFirst();

                templateGridEX.Focus();
            }
            catch (Exception x)
            { }
        }
    }
}
