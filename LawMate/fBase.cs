using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate

{
    public partial class fBase : Form
    {
        bool isSingleInstance = false;

        bool makeMdiChild = true;
        fMain mainForm;

        public bool MakeMdiChild
        {
            get { return makeMdiChild; }
            set
            {
                makeMdiChild = value;
                //if (mainForm != null)
                //{
                //    if (makeMdiChild)
                //        this.MdiParent = mainForm;
                //    else
                //        this.MdiParent = null;
                //}
            }
        }

        public fBase()
        {
            InitializeComponent();
        }

        public fBase(Form f)
        {
            InitializeComponent();
           

            mainForm =(fMain)f;
        }

        protected atriumBE.atriumManager AtMng
        {
            get
            {
                return MainForm.AtMng;
            }
        }

        public fMain MainForm
        {
            get
            {
                return mainForm;
            }
        }

        public bool IsSingleInstance
        {
            get
            {
                return isSingleInstance;
            }
            set
            {
                isSingleInstance=value;
            }
        }

        public virtual string Id
        {
            get { return this.Name; }
            set { }
        }

        private void fBase_Shown(object sender, EventArgs e)
        {
            if (IsMdiChild && MainForm.MdiChildren.Length==1)
            {
                WindowState = FormWindowState.Normal;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void fBase_Load(object sender, EventArgs e)
        {
            if (mainForm != null)
            {
                if (makeMdiChild)
                    this.MdiParent = mainForm;
                else
                    this.MdiParent = null;
            }
        }
    }
}