using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LawMate
{
    public partial class fError : Form
    {
        public fError()
        {
            InitializeComponent();
        }

        public fError(Exception x)
        {
            InitializeComponent();
            editBox1.Text = x.Message;
        }

        public fError(string s)
        {
            InitializeComponent();
            editBox1.Text = s;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Size s = Screen.PrimaryScreen.Bounds.Size;
                Bitmap bmp = new Bitmap(s.Width, s.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(0, 0, 0, 0, s);
                Clipboard.SetImage(bmp);
            }
            catch(Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(editBox1.Text);
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
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fError_Shown(object sender, EventArgs e)
        {

        }

        private void fError_Activated(object sender, EventArgs e)
        {

        }

        private void fError_Deactivate(object sender, EventArgs e)
        {

        }

        private void fError_Enter(object sender, EventArgs e)
        {

        }

        private void fError_Leave(object sender, EventArgs e)
        {

        }
    }
}
