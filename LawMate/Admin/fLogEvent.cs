using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fLogEvent : fBase
    {
        public fLogEvent()
        {
            InitializeComponent();

        }

        public fLogEvent(Form f)
            : base(f)
        {
            InitializeComponent();

            AtMng.GetEventLog().Load();
            eventLogBindingSource.DataSource = AtMng.DB.EventLog;
        }

        private void fLogEvent_Load(object sender, EventArgs e)
        {
            eventLogGridEX.MoveFirst();
        }
    }
}

