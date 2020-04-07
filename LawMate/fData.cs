using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fData : Form
    {
        public fData(atriumBE.FileManager fm)
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = fm.CurrentFile;
        }

        public fData(DataRow dr)
        {
            InitializeComponent();

            propertyGrid1.SelectedObject =dr;
        }
    }
}