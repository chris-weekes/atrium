using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate
{
    public partial class fBrowseIssues : Form
    {
        private appDB.IssueRow selectedIssue;
        atriumManager Atmng;
        atriumBE.FileManager myFM;
        

        bool AllowContainerSelection = false;

        public appDB.IssueRow SelectedIssue
        {
            get { return selectedIssue; }
        }
        public fBrowseIssues()
        {
            InitializeComponent();
        }
        public fBrowseIssues(atriumManager atmng, bool allowContainerSelection,int programid)
        {
            InitializeComponent();
            ucBrowseIssues1.LoadRoot(atmng, programid);
            Atmng = atmng;
            AllowContainerSelection = allowContainerSelection;
            issueBindingSource.DataMember = Atmng.DB.Issue.TableName;
            issueBindingSource.DataSource = Atmng.DB;
            ucIssueSelectBox1.AtMng = Atmng;
            myFM = Atmng.GetFile();
        }

        public void FindIssue(int issueId)
        {
            appDB.IssueRow ir = Atmng.DB.Issue.FindByIssueId(issueId);
            ucBrowseIssues1.FindIssue(ir);
        }

        private void ucBrowseIssues1_IssueSelected(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (!ucBrowseIssues1.SelectedIssue.IsFileIdNull())
                {
                    selectedIssue = ucBrowseIssues1.SelectedIssue;
                    this.Hide();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucBrowseIssues1.SelectedIssue == null || ucBrowseIssues1.SelectedIssue.IssueId == 0)
                {
                    MessageBox.Show("Please select an issue.");
                    return;
                }

                selectedIssue = ucBrowseIssues1.SelectedIssue;
                this.Hide();
                DialogResult = DialogResult.OK;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucBrowseIssues1_IssueNavigated(object sender, TreeViewEventArgs e)
        {
            try
            {
                issueBindingSource.Position = issueBindingSource.Find("IssueId", ucBrowseIssues1.SelectedIssue.IssueId);
                if (AllowContainerSelection)
                    buttonOK.Enabled = true;
                else
                    buttonOK.Enabled = !ucBrowseIssues1.SelectedIssue.IsFileIdNull();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        
    }
}