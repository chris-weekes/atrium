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
    public partial class fDocView : Form
    {

        public fDocView()
        {
            InitializeComponent();
        }

        public fDocView(DocManager dm, lmDatasets.docDB.DocumentRow dr)
        {
            InitializeComponent();
            if (dr == null)
            {
                Close();
                return;
            }
            this.Text = String.Format(Properties.Resources.AppDocViewer, dm.AtMng.AppMan.AppName);

            ucDocView1.Init(dm);
            ucDocView1.ActionToolbarView = UserControls.DocCommandBar.Hide;
            ucDocView1.Datasource = new DataView(dr.Table, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
        }

        private void fDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDocView1.Clear();
        }

        private void fDoc_Shown(object sender, EventArgs e)
        {
            ucDocView1.Preview();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
