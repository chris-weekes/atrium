using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
     public partial class fReportAdmin : LawMate.fBase
    {
        public fReportAdmin()
        {
            InitializeComponent();
        }
    
     public fReportAdmin(Form f) :base(f)
        {
            InitializeComponent();

            webBrowser1.Url  =new Uri( AtMng.AppMan.ServerInfo.reportAdminUrl );
        }
}
}

