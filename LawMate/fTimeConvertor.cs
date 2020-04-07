using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fTimeConvertor : Form
    {
        public int totalminutes;

        public fTimeConvertor()
        {
            InitializeComponent();
        }

        public fTimeConvertor(decimal minutes)
        {
            InitializeComponent();

            TimeSpan ts = new TimeSpan(0, decimal.ToInt32(minutes*60), 0);
            UpdateTotal(ts);  
        }

        private void UpdateTotal(TimeSpan ts)
        {
            ebHours.Value = ts.Hours;
            ebMinutes.Value = ts.Minutes;
            lblTotalMinutes.Text = ts.TotalMinutes.ToString();
        }   

        private void ebHours_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = new TimeSpan((int)ebHours.Value, (int)ebMinutes.Value, 0);
                lblTotalMinutes.Text = ts.TotalMinutes.ToString();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = new TimeSpan((int)ebHours.Value, (int)ebMinutes.Value, 0);
                totalminutes = (int)ts.TotalMinutes;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fTimeConvertor_Shown(object sender, EventArgs e)
        {
            try
            {
                ebHours.SelectAll();
                ebHours.Focus();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}