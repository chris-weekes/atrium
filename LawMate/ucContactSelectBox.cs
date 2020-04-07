using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
     public enum WorkloadQuery
     {
         NotApplicable = 0,
         TribunalMemberWorkload = 1,
         SSTCaseOfficerWorkload = 2,
         SSTSeniorOfficerWorkload = 3,
         ParticipantSearch=4
     }

    [DefaultBindingProperty("ContactId")]
    public partial class ucContactSelectBox : UserControl, UserControls.IRequiredCtl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private atriumBE.FileManager myFM;

        public atriumBE.FileManager FM
        {
            get { return myFM; }
            set { myFM = value; }
        }

        
        private WorkloadQuery myWLQuery = WorkloadQuery.NotApplicable;

        public WorkloadQuery WLQuery
        {
            get { return myWLQuery; }
            set 
            {
               myWLQuery = value;
               if (myWLQuery == WorkloadQuery.NotApplicable)
                   editBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis;
               else
                   editBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image;
            }
        }


        private object contactId;
        bool isChanged = false;
        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public object ContactId
        {
            get { return contactId; }
            set 
            {
                if ( contactId!=null && value!=null && contactId.ToString() == value.ToString() && editBox1.Text!="")
                    return;
                contactId = value;
                if (contactId==null || contactId.GetType() != typeof(int))
                    editBox1.Text = "";
                else
                {
                    if (FM == null)
                        return;
                    //search officers first
                    DataRow[] drs= FM.Codes("vOfficerList").Select("OfficerID=" + contactId.ToString());
                    if (drs.Length == 1)
                    {
                        if (drs[0]["officercode"] != null && drs[0]["officercode"].ToString()!="")
                            editBox1.Text = drs[0]["fullname"].ToString() + " (" + drs[0]["officercode"].ToString() + ")";
                        else
                            editBox1.Text = drs[0]["fullname"].ToString();
                    }
                    else
                    {
                        lmDatasets.atriumDB.ContactRow cr = myFM.DB.Contact.FindByContactId((int)contactId);
                        if (cr == null)
                            cr = myFM.GetPerson().Load((int)contactId);
                        editBox1.Text = cr.DisplayName;
                    }
                }
                if (PropertyChanged != null && isChanged)
                {
                    PropertyChangedEventArgs pce = new PropertyChangedEventArgs("ContactId");
                    PropertyChanged(this, pce);
                }
                OnTextChanged(new EventArgs());
                isChanged = false;
            }
        }

        public ucContactSelectBox()
        {
            InitializeComponent();
        }

        public ucContactSelectBox(WorkloadQuery wlQuery)
        {
            InitializeComponent();
            WLQuery = wlQuery;
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

        [Category("Data")]
        public bool ReadOnly
        {
            set
            {
                editBox1.ButtonEnabled = !value;
                if (editBox1.ButtonEnabled)
                    editBox1.BackColor = SystemColors.Window;
                else
                    editBox1.BackColor = SystemColors.Control;
            }
            get
            {
                return !editBox1.ButtonEnabled;
            }
        }


        private void editBox1_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (myWLQuery== WorkloadQuery.NotApplicable)
                {
                    fContactSelect f = new fContactSelect(FM, null, true);
                    f.ShowDialog();

                    if (f.ContactId != 0)
                    {
                        isChanged = true;
                        ContactId = f.ContactId;
                    }
                    f.Close();
                }
                else
                {
                    fWorkloadView fWL = new fWorkloadView(WLQuery, true, FM,ContactId);
                    fWL.ShowDialog();

                    if (fWL.SelectedContactId != 0)
                    {
                        isChanged = true;
                        ContactId = fWL.SelectedContactId;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void editBox1_Validated(object sender, EventArgs e)
        {
            //ContactId = myFM.OfficeMng.GetOfficer().LoadByOfficerCode(editBox1.Text).OfficerId;
        }




        public void RequiredAction()
        {
            editBox1_ButtonClick(editBox1, new EventArgs());
        }
    }
}
