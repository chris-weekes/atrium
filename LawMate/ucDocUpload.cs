using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LawMate
{
    [DefaultBindingProperty("FileName")]
    public partial class ucDocUpload : UserControl, UserControls.IRequiredCtl
    {

        private atriumBE.DocManager myDM;


        private Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();

        public atriumBE.DocManager DocMng
        {
            get { return myDM; }
            set { myDM = value; }
        }

        private lmDatasets.docDB.DocumentRow myDoc;

        public lmDatasets.docDB.DocumentRow Document
        {
            get { return myDoc; }
            set
            {
                myDoc = value;
                if (myDoc.Name != null || myDoc.Name != "")
                    editBox1.Text = myDoc.Name;
            }
        }

        private object fileName;

        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public object FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;

                if (myDM == null)
                    return;

                if (fileName == null || fileName == "")
                {
                    editBox1.Text = "";
                }
                else
                {
                    editBox1.Text = fileName.ToString();

                    try
                    {
                        DocMng.GetDocument().LoadFile(Document, fileName.ToString());

                        Document.icon = UIHelper.GetFileIcon(fileName.ToString());
                    }
                    catch (Exception x)
                    {
                        FileName = "";
                        UIHelper.HandleUIException(x);
                    }

                }
                OnTextChanged(new EventArgs());

            }
        }
        public ucDocUpload()
        {
            InitializeComponent();


        }

        private bool readOnly;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                editBox1.ButtonEnabled = !value;
                if (readOnly)
                    editBox1.BackColor = SystemColors.Control;
                else
                    editBox1.BackColor = SystemColors.Window;
            }
        }

        [Category("Layout")]
        public Color ReqColor
        {
            get
            {
                return editBox1.BackColor;
            }
            set
            {
                editBox1.BackColor = value;
            }
        }

        public bool IsPopulated
        {
            get { return this.Text != ""; }
        }

        [Category("Data")]
        public override string Text
        {
            get
            {
                return editBox1.Text;
            }
        }

        private void editBox1_ButtonClick(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (fWait fw = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    FileName = openFileDialog1.FileName;
                }
            }

        }




        public void RequiredAction()
        {
            
        }
    }
}
