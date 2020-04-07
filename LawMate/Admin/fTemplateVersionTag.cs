using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class fTemplateVersionTag : Form
    {

        public DateTime ExportDate;
        public string TagVersion;
        public bool ClearFlag;
        DataTable dtTemplateList;

        public fTemplateVersionTag()
        {
            InitializeComponent();
        }

        public fTemplateVersionTag(lmDatasets.appDB.TemplateRow[] tarr)
        {
            InitializeComponent();
            calendarCombo1.Value = DateTime.Now;
            dtTemplateList = new DataTable("dtTemplateList");
            dtTemplateList.Columns.Add("LetterName", typeof(string));
            dtTemplateList.Columns.Add("LetterDescEng", typeof(string));
            pnlImport.Closed = true;
            pnlVersionTag.Closed = false;

            foreach(lmDatasets.appDB.TemplateRow tr in tarr)
            {
                dtTemplateList.Rows.Add(tr.LetterName, tr.LetterDescEng);
            }
            BindData(gridEX1);
        }

        public fTemplateVersionTag(lmDatasets.appDB.TemplateDataTable tdt)
        {
            InitializeComponent();
            dtTemplateList = new DataTable("dtTemplateList");
            dtTemplateList.Columns.Add("LetterName", typeof(string));
            dtTemplateList.Columns.Add("LetterDescEng", typeof(string));
            editBox2.Text = tdt[0].Tag; //just get first row ... all rows should have same tag anyway.
            pnlImport.Closed = false;
            pnlVersionTag.Closed = true;

            foreach (lmDatasets.appDB.TemplateRow tr in tdt)
            {
                dtTemplateList.Rows.Add(tr.LetterName, tr.LetterDescEng);
            }
            BindData(gridEX2);
        }

        private void BindData(Janus.Windows.GridEX.GridEX grd)
        {
            grd.DataSource = dtTemplateList;
            grd.DataMember = "";
            UIHelper.SetDataTableAsGridDataSource(grd, dtTemplateList);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ExportDate = calendarCombo1.Value;
                TagVersion = editBox1.Text;
                ClearFlag = uiCheckBox1.Checked;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                TagVersion = "";
                ClearFlag = false;
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fTemplateVersionTag_Load(object sender, EventArgs e)
        {
            try
            {
                editBox1.Focus();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            try
            {
                TagVersion = editBox2.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}
