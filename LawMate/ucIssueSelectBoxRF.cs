using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using lmDatasets;

namespace LawMate
{

    [DefaultBindingProperty("IssueId")]
    public partial class ucIssueSelectBoxRF : UserControl, UserControls.IRequiredCtl
    {

        public ucIssueSelectBoxRF()
        {
            InitializeComponent();
        }

        public event IssueChangedEventHandler IssueChangedEvent;
        public delegate void IssueChangedEventHandler(object sender, EventArgs e);

        private atriumBE.FileManager myFM;
        public atriumBE.FileManager FM
        {
            get { return myFM; }
            set { myFM = value; }
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

        private object issueId;
        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public object IssueId
        {
            get { return issueId; }
            set
            {
                issueId = value;

                if (issueId != null && value.GetType() != typeof(int))
                {
                    editBox1.Text = "";
                }
                else
                {
                    if (FM == null)
                        return;

                    appDB.IssueRow issrow;

                    appDB.IssueRow[] irs = (appDB.IssueRow[])FM.AtMng.DB.Issue.Select("IssueId=" + issueId);
                    if (irs.Length == 1)
                        issrow = irs[0];
                    else //why isn't issue loaded?!
                        issrow = FM.AtMng.DB.Issue.FindByIssueId((int)issueId);

                    if (FM.AtMng.AppMan.Language == "ENG")
                        editBox1.Text = issrow.IssueNameEng;
                    else
                        editBox1.Text = issrow.IssueNameFre;

                }

                OnTextChanged(new EventArgs());
            }
        }

        [Category("Data")]
        public override string Text
        {
            get { return editBox1.Text; }
        }

        public bool IsPopulated
        {
            get { return this.Text != ""; }
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

        private void editBox1_ButtonClick(object sender, EventArgs e)
        {
            OpenBrowseIssueDialog();
        }

        public void OpenBrowseIssueDialog()
        {
            //need to get program id from account if it is present!
            int prgId = 0;
            if (FM.GetSSTMng().DB.SSTCase.Rows.Count > 0)
                prgId = FM.GetSSTMng().GetSSTCase().EffectiveProgram(FM.GetSSTMng().DB.SSTCase[0]);
            fBrowseIssues f = new fBrowseIssues(FM.AtMng, false, prgId);

            f.ShowDialog();

            if (f.SelectedIssue != null)
            {
                IssueId = f.SelectedIssue.IssueId;
                if (IssueChangedEvent != null)
                    this.IssueChangedEvent((object)editBox1, new EventArgs());
            }

            f.Close();
        }



        public void RequiredAction()
        {
            
        }
    }
}