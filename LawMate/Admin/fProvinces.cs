using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fProvinces : fBase
    {
        public fProvinces()
        {
            InitializeComponent();
        }
        public fProvinces(Form f) : base(f)
        {
            InitializeComponent();
        }

        private void fProvinces_Load(object sender, EventArgs e)
        {
            provinceBindingSource.DataSource = AtMng.DB;
            AtMng.GetProvince().Load();
        }

    }
}