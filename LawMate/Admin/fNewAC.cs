using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fNewAC : fBase
    {
        private atriumBE.atriumManager myAtmng;

        public atriumBE.atriumManager MyAtmng
        {
            get { return myAtmng; }
            set
            {
                myAtmng = value;

                NewAC = (lmDatasets.ActivityConfig.ActivityCodeRow)MyAtmng.acMng.GetActivityCode().Add(null);
                ucActivityCode1.AtMng = MyAtmng;
                ucActivityCode1.DataSource = new DataView(MyAtmng.acMng.DB.ActivityCode, "ActivityCodeID=" + NewAC.ActivityCodeID.ToString(), "", DataViewRowState.CurrentRows);
            }
        }

        public lmDatasets.ActivityConfig.ActivityCodeRow NewAC;

        public fNewAC()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewAC.RejectChanges();
            NewAC = null;
            this.Hide();
        }

        private void fNewAC_Load(object sender, EventArgs e)
        {
        }


    }
}

