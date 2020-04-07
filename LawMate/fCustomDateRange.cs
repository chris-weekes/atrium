using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fCustomDateRange : Form
    {
        public fCustomDateRange()
        {
            InitializeComponent();
            ucDateRange1.SetToCustomDateRange();
        }

        public Nullable<DateTime> BeginDate
        {
            get
            {
                return ucDateRange1.BeginDate;
            }
        }
        public Nullable<DateTime> EndDate
        {
            get
            {
                if(ucDateRange1.EndDate!=null)
                    return ucDateRange1.EndDate;
                else
                {
                    TimeSpan ts = new TimeSpan(23, 59, 59);
                    Nullable<DateTime> dt = ((DateTime)ucDateRange1.BeginDate).Add(ts);
                    return dt;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!DateIsValidated())
            {
                MessageBox.Show(Properties.Resources.RangeIsNotValid);
                DialogResult = DialogResult.Cancel;
            }
            else
                DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool DateIsValidated()
        {
            if (ucDateRange1.EndDateVisible && ucDateRange1.BeginDate != null && ucDateRange1.EndDate != null && ucDateRange1.BeginDate < ucDateRange1.EndDate)
                return true;
            if (!ucDateRange1.EndDateVisible && ucDateRange1.BeginDate != null)
                return true;

            return false;
        }

    }
}