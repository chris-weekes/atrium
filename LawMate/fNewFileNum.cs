using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;

 namespace LawMate
{

    public partial class fNewFileNum : Form
    {
        public fNewFileNum()
        {
            InitializeComponent();
        }



        public void SetDefaultNumber(string defaultNumber)
        {
            tbName.Text = defaultNumber;
        }
        public string NewNumber()
        {
            return tbName.Text;
        }

 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateName();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

   
        private void ValidateName()
        {
            if (tbName.Text.Length > 0)
            {
                Hide();
            }
            else
                MessageBox.Show(Properties.Resources.NameCannotBeBlank);
        }
    }
}