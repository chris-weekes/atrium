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

    public partial class fMove : Form
    {
        public bool Cancel = false;
        public FXLinkType moveOp;
        public fMove()
        {
            InitializeComponent();
        }
        public fMove(lmDatasets.atriumDB.FileMetaTypeRow meta)
        {
            InitializeComponent();
            Init(meta);
            
        }

        public fMove(lmDatasets.atriumDB.FileMetaTypeRow meta, bool AddToMyShortcuts)
        {
            InitializeComponent();
            if (AddToMyShortcuts)
            {
                btnXref.Enabled = false;
                btnMove.Enabled = false;
                if (!meta.AllowShortcuts)
                    btnSC.Enabled = false;
            }
            else
            {
                Init(meta);
            }
        }
        public void SetDefaultName(string defaultName)
        {
            tbName.Text = defaultName;
        }
        public string textBoxValue()
        {
            return tbName.Text;
        }

        private void Init(lmDatasets.atriumDB.FileMetaTypeRow meta)
        {
            if (!meta.AllowXref)
                btnXref.Enabled = false;

            if (!meta.AllowShortcuts)
                btnSC.Enabled = false;

            if (!(meta.AllowSubFiles))
                btnMove.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateName(FXLinkType.ParentChild);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateName(FXLinkType.Shortcut);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnXref_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateName(FXLinkType.XRef);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void ValidateName(FXLinkType lnkType)
        {
            if (tbName.Text.Length > 0)
            {
                moveOp = lnkType;
                Hide();
            }
            else
                MessageBox.Show(Properties.Resources.NameCannotBeBlank);
        }
    }
}