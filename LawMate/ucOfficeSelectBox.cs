using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    [DefaultBindingProperty("OfficeId")]
     public partial class ucOfficeSelectBox : UserControl, UserControls.IRequiredCtl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool isChanged = false;

        private atriumBE.atriumManager myAtmng;

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

        private object officeId;

        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public object OfficeId
        {
            get { return officeId; }
            set
            {

                //if (officeId == null & value.ToString() == "")
                //    return;
                officeId = value;

                if (officeId!=null && value.GetType() != typeof(int))
                    editBox1.Text = "";
                else
                {



                    if (AtMng == null)
                        return;
                    atriumBE.OfficeManager offmng = AtMng.GetOffice((int)officeId);

                    //ugly workaround for officename/officenamefre
                    if(AtMng.AppMan.Language.ToUpper()=="FRE")
                        editBox1.Text = offmng.CurrentOffice.OfficeNameFre + " (" + offmng.CurrentOffice.OfficeCode + ")";
                    else
                        editBox1.Text = offmng.CurrentOffice.OfficeName + " (" + offmng.CurrentOffice.OfficeCode + ")";

                }
                if (PropertyChanged != null && isChanged)
                {
                    PropertyChangedEventArgs pce = new PropertyChangedEventArgs("OfficeId");
                    PropertyChanged(this, pce);
                }
                OnTextChanged(new EventArgs());
                isChanged = false;
            }
        }

        public ucOfficeSelectBox()
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
            fBrowseOffices f = new fBrowseOffices(AtMng);
            f.ShowDialog();

            if (f.OfficeId != 0)
            {
                isChanged = true;
                OfficeId = f.OfficeId;
            }
            f.Close();
        }


        public void RequiredAction()
        {
           
        }
    }
}
