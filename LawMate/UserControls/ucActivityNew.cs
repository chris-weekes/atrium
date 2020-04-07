using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

namespace LawMate.UserControls
{
    public partial class ucActivityNew : UserControl
    {
        FileManager fm;
        ActivityBP ABP;
        fFile ffns;
        fACWizard facwr;

        Dictionary<NextStep, int> AcSeriesOKToAdd = new Dictionary<NextStep, int>();

        public ucActivityNew()
        {
            InitializeComponent();
        }

        public void Init(FileManager FM, fFile ffile)
        {
            fm = FM;
            ffns = ffile;
            AcSeriesOKToAdd.Clear();
            ABP = fm.InitActivityProcess();
            try
            {
                Dictionary<int, atriumBE.CurrentFlow> activeProcesses = ABP.Workflow.NextSteps();
                foreach (CurrentFlow ap in activeProcesses.Values)
                {
                    if (ap.NextSteps.Count > 0)
                    {
                        LoadNextSteps(ap);
                    }
                }
                LoadEnabledProcesses();
                LoadAvailableProcesses();
            }
            catch (Exception x)
            {
                throw new LMException(Properties.Resources.QuickACNoNextSteps, x);
            }

        }


        public void Cancel()
        {
            calActivityDate.Value = DateTime.Today;
            ebStepCode.Text = "";
            DoSkipCheck(null);
        }

        private void DoSkipCheck(NextStep ns)
        {
            bool reset = false;
            if (ns == null)
                reset = true;
            else if (!ns.acs.ShowSkipDoc)
                reset = true;

            uiCheckBox1.Visible = !reset;
            if (reset)
            {
                uiCheckBox1.Checked = false;
                btnGo.Left = ebStepCode.Right + 1;
                ebACDesc.Left = btnGo.Right + 1;
                //ebACDesc.Width = ebACDesc.Width + uiCheckBox1.Width;
            }
            else
            {
                btnGo.Left = uiCheckBox1.Right + 1;
                ebACDesc.Left = btnGo.Right + 1;
                //ebACDesc.Width = ebACDesc.Width - uiCheckBox1.Width;
            }
            ebACDesc.Width = ebNSType.Left - ebACDesc.Left - 1;


        }

        public void ReadOnly(bool isReadOnly)
        {
            calActivityDate.ReadOnly = isReadOnly;
            ebStepCode.ReadOnly = isReadOnly;
            btnGo.Visible = !isReadOnly;
        }

        private void LoadNextSteps(CurrentFlow ap)
        {
            foreach (NextStep ns1 in ap.NextSteps.Values)
            {
                NextStep ns = ABP.Workflow.SillyQuestion(ns1, fm);
                StepType st = (StepType)ns.acs.StepType;

                if (st == StepType.Activity && ns.Enabled)
                    AcSeriesOKToAdd.Add(ns, 0);

                if (ns.Children != null)
                    LoadNextSteps(ns.Children);
            }
        }

        private void LoadAvailableProcesses()
        {
            Dictionary<int, CurrentFlow> availProcesses = ABP.Workflow.AvailableProcesses();
            System.Collections.Generic.SortedDictionary<int, CurrentFlow> sortedAvailProcesses = null;
            if (availProcesses != null)
                sortedAvailProcesses = new SortedDictionary<int, CurrentFlow>(availProcesses);
            foreach (CurrentFlow availSeries in availProcesses.Values)
            {
                LoadProcNested(availSeries, 2);
            }
        }

        private void LoadEnabledProcesses()
        {
            Dictionary<int, CurrentFlow> enabledProcesses = ABP.Workflow.EnabledProcesses();
            System.Collections.Generic.SortedDictionary<int, CurrentFlow> sortedEnabledProcesses = null;
            if (enabledProcesses != null)
                sortedEnabledProcesses = new SortedDictionary<int, CurrentFlow>(enabledProcesses);

            //foreach (CurrentFlow availSeries in enabledProcesses.Values)
            foreach (CurrentFlow availSeries in sortedEnabledProcesses.Values)
            {
                LoadProcNested(availSeries, 1);
            }
        }

        private void LoadProcNested(CurrentFlow availSeries, int EnabledOrAlwaysAvail)
        {
            foreach (NextStep ns in availSeries.NextSteps.Values)
            {
                if ((StepType)ns.acs.StepType == StepType.Activity)
                {
                    if (!AcSeriesOKToAdd.ContainsKey(ns))
                        AcSeriesOKToAdd.Add(ns, EnabledOrAlwaysAvail);
                }
                if (ns.Children != null)
                    LoadProcNested(ns.Children, EnabledOrAlwaysAvail);
            }
        }



        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //launch Wizard passing ACSeries, ABP?
                NextStep ns = null;
                if (ebStepCode.Tag != null)
                    ns = (NextStep)ebStepCode.Tag;
                if (ns != null)
                {
                    ACEngine test = new ACEngine(fm);
                    test.TestForSteps(ns.acs.ACSeriesId);
                    if (!test.HasAnyRel & (!test.HasDoc |uiCheckBox1.Checked))
                    {
                        atriumBE.ActivityBP abp= fm.InitActivityProcess();
                        if(test.HasDoc)
                            abp.SkipDoc = uiCheckBox1.Checked;
                        abp.CreateAC(ns.acs.ACSeriesId, calActivityDate.Value, null, 0, 0, ACEngine.RevType.Nothing);
                        abp.SkipDoc = false;
                        calActivityDate.Value = DateTime.Today;
                        ebStepCode.Text = "";
                        ebNSType.Text = "";
                        Init(fm, ffns);
                        ffns.MoreInfo("activity", abp.LastActivityId.Value);
                        ffns.fileToc.LoadTOC();
                    }
                    else
                    {
                        bool docIsSkipped = false;
                        if (uiCheckBox1.Checked)
                            docIsSkipped = true;

                        ebStepCode.Text = "";
                        ebNSType.Text = "";

                        ffns.ReadOnly = true;
                        if (ns.prevAc != null)
                            facwr = new fACWizard(fm, (ACEngine.Step)ns.acs.InitialStep, ns.acs.ACSeriesId, ns.prevAc.ActivityId, docIsSkipped);
                        else
                            facwr = new fACWizard(fm, (ACEngine.Step)ns.acs.InitialStep, ns.acs.ACSeriesId, docIsSkipped);
                        facwr.setAcDate(calActivityDate.Value, ns);
                        facwr.Show();
                        calActivityDate.Value = DateTime.Today;
                        DoSkipCheck(null);
                        ffns.HookupWizClose(facwr);
                        ffns.fileToc.LoadTOC();
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.QuickACSelectAValidCode);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ebStepCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    btnGo.PerformClick();

                }
                if (e.KeyChar == (char)Keys.Back)
                {
                    CodeFieldBackspaceKeyPressed = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool CodeFieldBackspaceKeyPressed = false;
        private void ebStepCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FindByCode(CodeFieldBackspaceKeyPressed, ebStepCode, ebStepCode.Text);
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
            finally { CodeFieldBackspaceKeyPressed = false; }
        }

        public bool FindByCode(bool CodeFieldBackspaceKeyPressed, Janus.Windows.GridEX.EditControls.EditBox codeBox, string userTyped)
        {
            string typed = userTyped.ToUpper();
            if (typed.Length == 0)
            {
                codeBox.Text = "";
                codeBox.ImageKey = "act.png";
                ebACDesc.Text = "";
                ebNSType.Text = "";
                ebNSType.ImageIndex = 0;
                btnGo.Enabled = false;
                codeBox.Tag = null;
                DoSkipCheck(null);
                return false;
            }

            if (!CodeFieldBackspaceKeyPressed)
            {
                foreach (NextStep ns in AcSeriesOKToAdd.Keys)
                {

                    if ((atriumBE.StepType)ns.acs.StepType == atriumBE.StepType.Activity && ns.Enabled)
                    {
                        string code = ns.acs.StepCode;
                        if (code.StartsWith(typed) && typed.Length > 0)
                       {
                            codeBox.ImageKey = "newrecord.gif";
                            codeBox.Text = code;
                            codeBox.Tag = ns;
                            string desc = "(" + ns.acs.StepCode + ") " + ns.acs["ActivityName" + fm.AtMng.AppMan.Language].ToString();
                            if (!ns.acs.IsDescEngNull() && !ns.acs.IsDescFreNull())
                                desc += " " + ns.acs["Desc" + fm.AtMng.AppMan.Language].ToString();
                            ebACDesc.Text = desc;
                            string nstype = "";
                            if (AcSeriesOKToAdd[ns] == 0)
                                nstype = Properties.Resources.QuickACNextStep;
                            else if (AcSeriesOKToAdd[ns] == 1)
                                nstype = Properties.Resources.QuickACEnabled;
                            else if (AcSeriesOKToAdd[ns] == 2)
                                nstype = Properties.Resources.QuickACAlwaysAvail;

                            ebNSType.Text = nstype;
                            ebNSType.ImageIndex = AcSeriesOKToAdd[ns];
                            btnGo.Enabled = true;
                            DoSkipCheck(ns);
                            codeBox.SelectionStart = typed.Length;
                            codeBox.SelectionLength = code.Length - typed.Length;
                            codeBox.Focus();
                            return true;
                        }
                    }
                }
            }
            codeBox.ImageKey = "accessdenied.png";
            codeBox.Tag = null;
            ebNSType.Text = "";
            ebACDesc.Text = "";
            btnGo.Enabled = false;
            ebNSType.ImageIndex = 0;
            DoSkipCheck(null);
            return false;
        }

        public void ClearCode()
        {
            ebStepCode.Text = "";
        }

        public void FocusToCode()
        {
            ebStepCode.Focus();
        }

    }
}
