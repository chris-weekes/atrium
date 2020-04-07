using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

namespace LawMate
{
     [DefaultBindingProperty("IssueId")]
    public partial class ucIssueSelectBox : UserControl, UserControls.IRequiredCtl
    {
        private atriumBE.atriumManager myAtmng;

        public atriumBE.atriumManager AtMng
        {
            get { return myAtmng; }
            set { myAtmng = value; }
        }

        bool LookupsLoaded = false;

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

                this.DataBindings["IssueId"].WriteValue();
                
                if (issueId != null && value.GetType() != typeof(int))
                {
                    editBox1.Text = "";
                    mccLegProvision.Value = null;
                    mccRegulationProvision.Value = null;
                    issueAnalysisRTB.Clear();
                    rtbLegAna.Clear();
                    rtbLegText.Clear();
                    rtbRegAna.Clear();
                    rtbRegText.Clear();
                }
                else
                {
                    if (AtMng == null)
                        return;
                    if (!LookupsLoaded)
                    {
                        atriumBE.FileManager myFM = AtMng.GetFile();
                        UIHelper.MultiColumnComboInit("vProvision", mccLegProvision, myFM);
                        UIHelper.MultiColumnComboInit("vProvision", mccRegulationProvision, myFM);
                        LookupsLoaded = true;
                    }
                    appDB.IssueRow issrow;

                    appDB.IssueRow[] irs = (appDB.IssueRow[])AtMng.DB.Issue.Select("IssueId=" + issueId);
                    if (irs.Length == 1)
                        issrow = irs[0];
                    else //why isn't issue loaded?!
                        issrow = AtMng.DB.Issue.FindByIssueId((int)issueId);

                    //ugly workaround for lang
                    bool isEng = AtMng.AppMan.Language.ToUpper() == "ENG";
                    if (isEng)
                    {
                        editBox1.Text = issrow.IssueNameEng;
                        if (!issrow.IsAnalysisTextEngNull())
                            issueAnalysisRTB.Rtf = issrow.AnalysisTextEng;
                        else
                            issueAnalysisRTB.Clear();
                    }
                    else
                    {
                        editBox1.Text = issrow.IssueNameFre;
                        if (!issrow.IsAnalysisTextFreNull())
                            issueAnalysisRTB.Rtf = issrow.AnalysisTextFre;
                        else
                            issueAnalysisRTB.Clear();
                    }

                    OnTextChanged(new EventArgs());

                    string aText = "";
                    string pText = "";

                    if (!issrow.IsLegProvisionIdNull())
                    {
                        mccLegProvision.Value = issrow.LegProvisionId;
                        appDB.ProvisionRow[] legprovr = (appDB.ProvisionRow[])AtMng.DB.Provision.Select("ProvisionId=" + issrow.LegProvisionId);
                        if (legprovr.Length == 1)
                        {
                            appDB.ProvisionRow provrow = legprovr[0];
                            if (!provrow.IsAnalysisTextEngNull())
                            {
                                aText = provrow.AnalysisTextEng;
                                if (!isEng)
                                    aText = provrow.AnalysisTextFre;

                                try
                                { rtbLegAna.Rtf = aText; }
                                catch (Exception x)
                                { rtbLegAna.Text = aText; }
                            }
                            if (!provrow.IsProvisionTextEngNull())
                            {
                                pText = provrow.ProvisionTextEng;
                                if (!isEng)
                                    pText = provrow.ProvisionTextFre;
                                try
                                { rtbLegText.Rtf = pText; }
                                catch (Exception x)
                                { rtbLegText.Text = pText; }
                            }
                        }
                    }
                    else
                    {
                        mccLegProvision.Value = null;
                        rtbLegText.Clear();
                        rtbLegAna.Clear();
                    }

                    if (!issrow.IsRegProvisionIdNull())
                    {
                        mccRegulationProvision.Value = issrow.RegProvisionId;
                        appDB.ProvisionRow[] regprovr = (appDB.ProvisionRow[])AtMng.DB.Provision.Select("ProvisionId=" + issrow.RegProvisionId);
                        if (regprovr.Length == 1)
                        {
                            appDB.ProvisionRow provrow = regprovr[0];
                            if (!provrow.IsAnalysisTextEngNull())
                            {
                                aText = provrow.AnalysisTextEng;
                                if (!isEng)
                                    aText = provrow.AnalysisTextFre;

                                try
                                { rtbRegAna.Rtf = aText; }
                                catch (Exception x)
                                { rtbRegAna.Text = aText; }
                            }

                            if (!provrow.IsProvisionTextEngNull())
                            {
                                pText = provrow.ProvisionTextEng;
                                if (!isEng)
                                    pText = provrow.ProvisionTextFre;

                                try
                                { rtbRegText.Rtf = pText; }
                                catch (Exception x)
                                { rtbRegText.Text = pText; }
                            }
                        }
                    }
                    else
                    {
                        mccRegulationProvision.Value = null;
                        rtbRegText.Clear();
                        rtbRegAna.Clear();
                    }
                }
            }
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

        public ucIssueSelectBox()
        {
            InitializeComponent();
        }

        private void editBox1_ButtonClick(object sender, EventArgs e)
        {
            fBrowseIssues f = new fBrowseIssues(AtMng, false,0);
            f.ShowDialog();

            if (f.SelectedIssue != null)
                IssueId = f.SelectedIssue.IssueId;

            f.Close();


        }


        public void RequiredAction()
        {
            
        }
    }
}
