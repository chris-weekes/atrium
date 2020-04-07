using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fBase : Form
    {
        fMain mainAdminForm;

        public fMain MainAdminForm
        {
            get
            {
                return mainAdminForm;
            }
        }

        public fBase()
        {
            InitializeComponent();
        }

        public fBase(Form f)
        {
            InitializeComponent();
            this.MdiParent = f;

            mainAdminForm = (fMain)f;
        }

        protected atriumBE.atriumManager AtMng
        {
            get
            {
                return ((fMain)this.ParentForm).AtMng;
            }
        }

        private void fBase_Load(object sender, EventArgs e)
        {
            
        }
    }
}