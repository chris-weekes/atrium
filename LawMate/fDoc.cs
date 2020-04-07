using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;

 namespace LawMate
{
    public partial class fDoc : Form
    {

        bool metaDataPrompt = false;
        public bool MetaDataPrompt
        {
            get { return metaDataPrompt; }
            set { metaDataPrompt = value; }
        }

        public fDoc()
        {
            InitializeComponent();
        }

        public fDoc(DocManager dm, lmDatasets.docDB.DocumentRow dr)
        {
            
            InitializeComponent();
            if (dr == null)
            {
                Close();
                return;
            }
            this.Text = String.Format(Properties.Resources.AppDocViewer, dm.AtMng.AppMan.AppName);

            ucDoc1.Init(dm);
            ucDoc1.AllowActionToolbar = false;
            //ucDoc1.AllowUserCompose = false;
            //ucDoc1.ReadOnly(true);
            ucDoc1.Datasource = new DataView(dr.Table, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);

        }

        private void fDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDoc1.Clear();
            //ucDoc1.ClearBindings(this);
        }

        private void fDoc_Shown(object sender, EventArgs e)
        {
            ucDoc1.Preview();
            if (metaDataPrompt)
                ucDoc1.MetadataConfirmForFDoc();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}