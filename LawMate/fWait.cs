using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fWait : Form
    {
        public fWait()
        {
            InitializeComponent();
            this.Text = UIHelper.AtMng.AppMan.AppName;
        }
        public fWait(string txt)
        {
            InitializeComponent();
            this.Text = UIHelper.AtMng.AppMan.AppName;
            lblTxt.Text = txt;
            this.Show();
            this.Refresh();
        }
        public void setMessageText(string txt)
        {
            lblTxt.Text = txt;
            this.Show();
            this.Refresh();
        }

        public void resetForm()
        {
            lblTxt.Text = "";
            this.Hide();
            this.Refresh();
        }
        public void InitiateForm(string txt)
        {
            this.Show();
            setMessageText(txt);
        }
    }
}