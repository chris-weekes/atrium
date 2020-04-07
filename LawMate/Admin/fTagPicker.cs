using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fTagPicker : Form
    {

        atriumBE.atriumManager atmng;
        LawMate.UserControls.ucDoc myucDoc1;
        public fTagPicker()
        {
            InitializeComponent();
        }

        public fTagPicker(atriumBE.atriumManager Atmng,string firstStepCode,LawMate.UserControls.ucDoc ucDoc1)
        {
            
            InitializeComponent();

            myucDoc1 = ucDoc1;

            atmng = Atmng;

            ddTableBindingSource.DataSource = atmng.GetGeneralRec("select * from vTemplateTags order by objectalias,tablename");
            ddTableBindingSource.Filter="StepCode is null or StepCode='"+ firstStepCode +"'";
            ddFieldBindingSource.DataSource = atmng.DB;

            this.DialogResult = DialogResult.Cancel;
        }

     


        private string currentTable;
        private void ddTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            int TableId =(int) CurrentRow()["TableId"];
            ddFieldBindingSource.Filter = "TableId="+TableId;
            ddFieldBindingSource.Sort = "FieldName";
            currentTable = CurrentRow()["ObjectAlias"].ToString();
        }

        private string currentField;
        private void ddFieldBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            currentField = CurrentRowField().FieldName;
        }

       
        private DataRow CurrentRow()
        {
            return (DataRow)((DataRowView)ddTableBindingSource.Current).Row;
        }

        
        private lmDatasets.appDB.ddFieldRow CurrentRowField()
        {
            return (lmDatasets.appDB.ddFieldRow)((DataRowView)ddFieldBindingSource.Current).Row;
        }

        private void ddFieldGridEX_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if(currentTable.ToUpper()=="EFILE")
                currentTable="File";

            string myTagToInsert = "["+cboTagType.Text+":" + currentTable + "/" + currentField+"]";
            if(cboTagType.Text=="repeat")
                myTagToInsert = "[" + cboTagType.Text + ":" + currentTable + "]";

            myucDoc1.WriteContentToDoc(myTagToInsert);

            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myTagToInsert = "[" + cboEndTag.Text + "]";
            myucDoc1.WriteContentToDoc(myTagToInsert);
        }

      
    }
}

