using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class fConfigSync : LawMate.Admin.fBase
    {
        public fConfigSync()
        {
            InitializeComponent();
        }

        public fConfigSync(Form f)
            : base(f)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FileName = "acConfig" + DateTime.Today.ToString("yyyyMMdd") + ".xml";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AtMng.acMng.ExportConfig(saveFileDialog1.FileName);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Performing this operation will update the workflow configuration data for this database:\n\n      "+AtMng.AppMan.ServerInfo.serverName+"\n\nThis operation cannot be undone. Are you sure you want to continue?", "Apply Workflow Configuration Data Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        AtMng.acMng.ImportConfig(openFileDialog1.FileName);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FileName = "codes" + DateTime.Today.ToString("yyyyMMdd") + ".xml";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AtMng.ExportCodes(saveFileDialog1.FileName);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Performing this operation will update the codes data for this database:\n\n      " + AtMng.AppMan.ServerInfo.serverName + "\n\nThis operation cannot be undone. Are you sure you want to continue?", "Apply Code Data Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        AtMng.ImportCodes(openFileDialog1.FileName);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FileName = "dd" + DateTime.Today.ToString("yyyyMMdd") + ".xml";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AtMng.ExportDD(saveFileDialog1.FileName);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Performing this operation will update the data dictionary for this database:\n\n      " + AtMng.AppMan.ServerInfo.serverName + "\n\nThis operation cannot be undone. Are you sure you want to continue?", "Apply Data Dictionary Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        AtMng.ImportDD(openFileDialog1.FileName);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnTestCompare_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Performing this operation will update the [selected] configuration data for this database:\n\n      " + AtMng.AppMan.ServerInfo.serverName + "\n\nThis operation cannot be undone. Are you sure you want to continue?", "Apply [SELECTED] Configuration Data Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        RunCompare(openFileDialog1.FileName);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void RunCompare(string filename)
        {
            fConfigCompare fCompare = new fConfigCompare();
            fCompare.Init(filename, DataConfigType.WorkflowActivityCongif, AtMng);
            if (fCompare.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("test finished. dialog returns ok");
            }
        }
    }
}
