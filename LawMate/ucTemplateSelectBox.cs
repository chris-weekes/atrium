using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LawMate
{
    [DefaultBindingProperty("LetterName")]
    public partial class ucTemplateSelectBox : UserControl, UserControls.IRequiredCtl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool isChanged = false;

        private atriumBE.atriumManager myAtmng;
        public atriumBE.FileManager fm;
        public string list;

        public atriumBE.atriumManager AtMng
        {
            get { return myAtmng; }
            set { myAtmng = value; }
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

        private object letterName;

        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public object LetterName
        {
            get { return letterName; }
            set
            {

                //if (officeId == null & value.ToString() == "")
                //    return;
                letterName = value;

                if (letterName != null && value.GetType() != typeof(string))
                    editBox1.Text = "";
                else if (letterName == null)
                    editBox1.Text = "";
                else
                {



                    if (AtMng == null)
                        return;

                    editBox1.Text = letterName.ToString();

                    //lmDatasets.appDB.TemplateDataTable dtOff = AtMng.DB.Template;
                    //lmDatasets.appDB.TemplateRow dr =(lmDatasets.appDB.TemplateRow)dtOff.Select("LetterName='" + letterName+"'")[0];

                    ////ugly workaround for officename/officenamefre
                    //if (AtMng.AppMan.Language.ToUpper() == "FRE")
                    //    editBox1.Text = dr.LetterDescEng;
                    //else
                    //    editBox1.Text = dr.LetterDescFre;
                }
                if (PropertyChanged != null && isChanged)
                {
                    PropertyChangedEventArgs pce = new PropertyChangedEventArgs("LetterName");
                    PropertyChanged(this, pce);
                }
                OnTextChanged(new EventArgs());
                isChanged = false;
            }
        }

        public ucTemplateSelectBox()
        {
            InitializeComponent();
        }

        public bool IsPopulated
        {
            get
            {
                return this.Text != "";
            }
        }
        [Category("Layout")]
        public Color ReqColor
        {
            set
            {
                editBox1.BackColor = value;

            }
            get
            {
                return editBox1.BackColor;
            }
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
            fBrowseTemplates f = new fBrowseTemplates(AtMng);
            f.CurrentFM = fm;
            f.TemplateList = list;

            if (f.ShowDialog() == DialogResult.Cancel)
            {
                fm.GetDocMng().GetDocument().AutoSubject = true;
                isChanged = true;
                LetterName = null;
            }
            else
            {
                if (f.SelectedTemplate != null)
                {
                    fm.GetDocMng().GetDocument().AutoSubject = true;
                    isChanged = true;
                    LetterName = f.SelectedTemplate.LetterName;
                }
            }
            f.Close();
            fm.GetDocMng().GetDocument().AutoSubject = false;
        }


        public void RequiredAction()
        {

        }
    }
}

