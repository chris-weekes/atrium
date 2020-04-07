using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

namespace LawMate.UserControls
{
    public partial class ucApptRecurrence : UserControl, IRequiredCtl
    {

        atriumBE.FileManager myFM;

        public ucApptRecurrence()
        {
            InitializeComponent();
        }

        public atriumBE.FileManager FM
        {
            get
            {
                return myFM;
            }
            set
            {
                myFM = value;
                if (myFM != null)
                {
                    UIHelper.ComboBoxInit("vApptRecurrenceType", RecurrenceUIComboBox, myFM);
                }
            }
        }

        private Color mReqColor;
        public Color ReqColor
        {
            get
            {
                return mReqColor;
            }
            set
            {
                mReqColor = value;
            }
        }

        public bool IsPopulated
        {
            get
            {
                return true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        public void RequiredAction()
        {
            
        }
    }
}
