using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fArchive : fBase
    {
        public fArchive()
        {
            InitializeComponent();
        }

        public fArchive(Form f)
            : base(f)
        {
            InitializeComponent();
           

        }

        private void gridEX1_EditModeChanged(object sender, EventArgs e)
        {
            if (gridEX1.EditTextBox != null)
            {
                gridEX1.EditTextBox.ReadOnly = true;
            }
        }

     

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdImport":
                        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string file = openFileDialog1.FileName;
                            atriumBE.FileManager fm = AtMng.GetFile();
                            fm.GetArchiveBatch().ManageArchiveData(file, false);
                        }
                        break;
                    case "cmdCreate":
                        break;
                    case "cmdPackingList":
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

