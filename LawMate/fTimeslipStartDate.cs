using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fTimeslipStartDate : Form
    {
        DateTime InitialStartTime;
        public DateTime SelectedStartDate
        {
            get { return calStartDate.Value; }
        }
        public fTimeslipStartDate()
        {
            InitializeComponent();
        }

        public fTimeslipStartDate(string message, DateTime startTime)
        {
            InitializeComponent();
            tbMessage.Text = message;
            calStartDate.Value = startTime;
            InitialStartTime = startTime;
            calStartDate.MinDate = startTime;
            calStartDate.MaxDate = DateTime.Today;
            calendarCombo1.Value = InitialStartTime;
            calendarCombo2.Value = DateTime.Today;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (calStartDate.Value < InitialStartTime)
                {
                    //error
                    // cannot select date less than inital date
                    return;
                }
                if (calStartDate.Value > DateTime.Today)
                {
                    //error
                    // cannot select date in the future
                    return;
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}