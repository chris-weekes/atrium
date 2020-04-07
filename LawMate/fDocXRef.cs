using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fDocXRef : Form
    {
        public bool Cancel = false;
        public fDocXRef()
        {
            InitializeComponent();
        }

        public void SetDefaultName(string defaultName)
        {
            editBox1.Text = defaultName;
            editBox1.SelectAll();
        }
        public string textBoxValue()
        {
            return editBox1.Text;
        }

        private void ValidateName()
        {
            if (editBox1.Text.Length > 0)
            {
                Hide();
            }
            else
                MessageBox.Show(Properties.Resources.NameCannotBeBlank);
        }

        private void uiButton1_Click(object sender, EventArgs e)
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

        private void uiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Cancel = true;
                Hide();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}