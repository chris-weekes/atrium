using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;

namespace LawMate
{
    public partial class fACWizard : Form, IRelatedFieldsHost
    {
        bool IsRestored = false;
        bool IsErrorOnSave = false;
        public bool Reload = false;
        public bool NoPromptForSave = false;
        public Dictionary<string, object> ctx;

        ACEngine.Step myInitialStep = ACEngine.Step.NoStep;

        bool CodeChangeInitiatedByUserClick = false;
        bool SkipDocument = false;
        private appDB.EFileSearchRow fscDest;
        private appDB.EFileSearchRow ascDest;
        private fBrowse fileBrowser;

        RelatedFields myRF;

        DateTime acDate = DateTime.Today;
        fTriangle HelpTriangle = null;

        //private bool myInitialFMKeepAlive = false;

        Dictionary<ACEngine.Step, Janus.Windows.UI.Dock.UIPanel> StepPanels = new Dictionary<ACEngine.Step, Janus.Windows.UI.Dock.UIPanel>();
        System.Collections.SortedList SecondaryIssues = new System.Collections.SortedList();
        lmDatasets.appDB.IssueRow PrimaryIssue;

        LinkedList<ACEngine.Step> Seq = new LinkedList<ACEngine.Step>();
        List<ACEngine.Step> completedSteps = new List<ACEngine.Step>();
        ACEngine.Step myCurrentStep;
        ACEngine.Step myPreviousStep;



        NextStep MySelectedStep;

        int restrictAcId = 0;


        int prevAc = 0;
        ConnectorType mailAction = 0;

        FileManager fmCurrent;
        FileManager fmOriginal;
        public ACEngine MyACE;
        public ActivityBP ABP;

        public ActivityConfig.ACSeriesRow AcSeries;
        public atriumDB.ProcessRow Process;

        public bool AdHoc;
        private DateTime startTime;
        private bool skipping = false;

        public ACEngine.Step CurrentStep
        {
            get { return myCurrentStep; }
            set
            {
                bool OK2Advance = true;
                chkSkipDoc.Visible = false;
                //ACEngine.Step ok2FinishFrom = ACEngine.Step.Document;
                switch (CurrentStep)  //Validate moving off curent step
                {
                    case ACEngine.Step.Prompt:
                        ProcessPrompt();
                        break;
                    case ACEngine.Step.PickIssue:
                        string missingIssueText = Properties.Resources.MustSelectDefaultText + "\n";
                        //JLL 2018-04-23
                        //if (PrimaryIssue == null || SecondaryIssues.Count == 0)
                        if (SecondaryIssues.Count == 0)
                        {
                            //JLL 2018-04-23
                            //if (PrimaryIssue == null)
                            //    missingIssueText += "\n" + Properties.Resources.MustSelectPrimaryIssue;
                            if (SecondaryIssues.Count == 0)
                                missingIssueText += "\n" + Properties.Resources.MustSelectXRef;

                            OK2Advance = false;
                            MessageBox.Show(this, missingIssueText);
                        }
                        else
                        {
                            //jll 2018-04-23
                            //added temporarily to bypass primary being mandatory
                            FileXRefBE fxBE = fmCurrent.GetFileXRef();
                            foreach (appDB.IssueRow ir in SecondaryIssues.Values)
                            {
                                atriumDB.FileXRefRow fxr = (atriumDB.FileXRefRow)fxBE.Add(fmCurrent.CurrentFile);

                                fxr.LinkType = 1;
                                fxr.OtherFileId = ir.FileId;
                                fxr.Rollup = false;
                                fxr.FullFileNumber = fmCurrent.EFile.Load(ir.FileId, false).FullFileNumber;

                            }


                            //JLL 2018-04-23
                            //fmCurrent = Atmng.GetFile(PrimaryIssue.FileId);
                        }
                        break;
                    case ACEngine.Step.CreateFile:
                        //if (nameETextBox.Text == "")
                        //{
                        //    //lblFileNameBlankError.Visible = true;
                        //    OK2Advance = false;
                        //}
                        //if (fileNumberTextBox.Text == "")
                        //{
                        //    //lblFileNumberBlankError.Visible = true;
                        //    OK2Advance = false;
                        //}
                        acDate = openedDateCalendarCombo.Value;
                        break;

                    case ACEngine.Step.PickActivity:
                        if (!ABP.AcSeriesOKToAdd.Contains(AcSeries) || tbJCode.Text == "")
                        {
                            lblNoCodeSelectedMessage.Visible = true;
                            OK2Advance = false;
                        }
                        else
                        {
                            lblNoCodeSelectedMessage.Visible = false;
                        }
                        acDate = calDate.Value;
                        break;

                    case ACEngine.Step.Billing:
                        if (fmCurrent.DB.ActivityTime.HasErrors)
                        {
                            OK2Advance = false;
                        }
                        break;
                    case ACEngine.Step.RelatedFields0:
                    case ACEngine.Step.RelatedFields1:
                    case ACEngine.Step.RelatedFields2:
                    case ACEngine.Step.RelatedFields3:
                    case ACEngine.Step.RelatedFields4:
                    case ACEngine.Step.RelatedFields5:
                    case ACEngine.Step.RelatedFields6:
                    case ACEngine.Step.RelatedFields7:
                    case ACEngine.Step.RelatedFields8:
                    case ACEngine.Step.RelatedFields9:
                        if (myRF != null && myRF.required.Count != 0 & CurrentStep < value)
                            OK2Advance = false;
                        //else if (HasErrors() & !skipping)
                        //    OK2Advance = false;
                        if (MyACE.IsRepeating)
                        {
                            if (CurrentStep < value && MyACE.RepeatCurrent < MyACE.RepeatMax)
                            {
                                MyACE.RepeatCurrent++;
                                value = CurrentStep;
                            }
                            else if (CurrentStep > value && MyACE.RepeatCurrent > 0)
                            {
                                MyACE.RepeatCurrent--;
                                value = CurrentStep;
                            }
                            else
                            {
                                MyACE.IsRepeating = false;
                                MyACE.RepeatCurrent = 0;
                                MyACE.RepeatMax = 0;
                            }
                        }
                        break;

                    case ACEngine.Step.Document:
                        if(value!= ACEngine.Step.ACInfo &
                            MyACE.myAcSeries.ShowSkipDoc
                            & !SkipDocument
                            & CurrentMailDoc().DocContentRow.Size < Atmng.GetSetting( AppIntSetting.BlankDocSkipSize) 
                            & !ucDoc1.isDirty 
                            & CurrentMailDoc().GetAttachmentRowsByDocument_Attachment().Length==0 
                            & CurrentMailDoc().RowState== DataRowState.Added)
                        {
                            //nag user
                            if (MessageBox.Show(this, "The document you are creating appears blank. Do you wish to skip the blank document?\n\nIf you click Yes, the document will not be saved.\n\nIf you click No, the empty document will remain stored on this activity.\n\nPlease avoid leaving empty documents on file. If you do not plan on adding content to this document, skip it.", "Skip Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //set skipdocument based on response
                                SkipDocument = true;
                            }
                        }
                        if (SkipDocument)
                        {
                            OK2Advance = true;
                            ucDoc1.Clear();
                            MyACE.FM.GetDocMng().DB.RejectChanges();
                            //MyACE.relTables.Remove("Document0");
                            if (MyACE.relTables.ContainsKey("Document0"))
                                MyACE.relTables["Document0"].RowFilter = "false";
                            MyACE.NewActivity.SetDocIdNull();
                            Seq.Remove(ACEngine.Step.Document);
                        }
                        else
                        {
                            if (ucDoc1.EditMode == UserControls.ucDoc.EditModeEnum.Compose && ucDoc1.DocRecord.isLawmail && ucDoc1.ToPersonIsNullOnCompose)
                                OK2Advance = false;
                            else
                                ucDoc1.EndEdit();
                        }
                        break;
                    case ACEngine.Step.Timeline:
                        OK2Advance = true;
                        break;
                }

                skipping = false;

                if (OK2Advance)
                {
                    PreviousStep = CurrentStep;

                    //hide current step
                    StepPanels[CurrentStep].Closed = true;

                    myCurrentStep = value;

                    if (CurrentStep == ACEngine.Step.ACInfo & ABP == null)
                        ABP = fmCurrent.InitActivityProcess();

                    buttonBack.Enabled = true;
                    buttonNext.Enabled = true;
                    if (CurrentStep == ACEngine.Step.PickIssue | Back() == ACEngine.Step.ACInfo | Back() == ACEngine.Step.PickIssue | Back() == ACEngine.Step.NoStep | Back() == myCurrentStep)
                    {
                        if (MyACE != null && MyACE.IsRepeating && MyACE.RepeatCurrent > 0)
                            buttonBack.Enabled = true;
                        else
                            buttonBack.Enabled = false;
                    }
                    if (CurrentStep >= ACEngine.Step.Document)
                    {
                        if (MyACE.FM.CurrentFile.RowState != DataRowState.Added)
                            btnSuspendActivity.Enabled = true;

                        timAutosave.Enabled = true;
                    }

                    try
                    {

                        switch (CurrentStep) //Apply logic for new current step
                        {
                            case ACEngine.Step.Confirm:

                                editBox2.Text = ACDescriptionFull(AcSeries);
                                ucContactSelectBox1.FM = fmCurrent;
                                editBox1.Text = AcSeries.StepCode;
                                string ConfirmStepHelp = AcSeries["Confirm" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                                SetHelpPanel(ConfirmStepHelp.Length > 0, ConfirmStepHelp);

                                buttonLast.Enabled = false;
                                ebACComment.Focus();
                                //btnFinish.Text = "&Finish";

                                break;
                            case ACEngine.Step.Timeline:
                                //hook up data source
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    MyACE.DoStep(CurrentStep, true);
                                    //ucTimeline1
                                    ucTimeline1.Init(fmCurrent, DateTime.Today, DateTime.Today.AddMonths(3));
                                    ucTimeline1.Datasource = MyACE.relTables["Appointment0"];
                                    completedSteps.Add(CurrentStep);
                                }
                                break;
                            case ACEngine.Step.PickActivity:
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    LoadNextSteps(tvNextSteps);
                                    LoadAvailableProcesses(ExplorerBarAvailableProcesses, false);
                                    LoadEnabledProcesses(tvEnabledProcesses, false);

                                    if (Atmng.GetSetting(AppBoolSetting.ShowAllSteps))
                                    {
                                        LoadNextSteps(ExplorerBarAllActivities);
                                        LoadEnabledProcesses(ExplorerBarAllActivities, true);
                                        LoadAvailableProcesses(ExplorerBarAllActivities, true);
                                        uiTab1.SelectedTab = uiTabPage4;
                                        ExplorerBarAllActivities.ExpandAll();
                                        ExplorerBarAllActivities.TreeViewNodeSorter = new fACWizard.NodeSorter();
                                    }
                                    completedSteps.Add(CurrentStep);
                                    tbJCode.Focus();
                                }

                                break;

                            case ACEngine.Step.PickIssue:
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    ucBrowseIssues1.LoadRoot(fmCurrent.AtMng, 0);
                                    DoRelIssue(AcSeries);
                                    completedSteps.Add(CurrentStep);
                                }

                                break;

                            case ACEngine.Step.ACInfo:
                                //get a activity process object
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    DoAcInfo();
                                }

                                string ACInfoStepHelp = AcSeries["ACInfo" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                                SetHelpPanel(ACInfoStepHelp.Length > 0, ACInfoStepHelp);
                                CurrentStep = Next();

                                break;
                            case ACEngine.Step.RelatedFields0:

                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {

                                    //MyACE.DoStep(CurrentStep);

                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 0);
                                break;
                            case ACEngine.Step.RelatedFields1:

                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 1);
                                break;
                            case ACEngine.Step.RelatedFields2:

                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 2);
                                break;
                            case ACEngine.Step.RelatedFields3:

                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 3);
                                break;
                            case ACEngine.Step.RelatedFields4:
                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 4);
                                break;
                            case ACEngine.Step.RelatedFields5:
                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 5);
                                break;
                            case ACEngine.Step.RelatedFields6:
                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 6);
                                break;
                            case ACEngine.Step.RelatedFields7:
                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 7);
                                break;
                            case ACEngine.Step.RelatedFields8:
                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 8);
                                break;
                            case ACEngine.Step.RelatedFields9:
                                MyACE.DoStep(CurrentStep, !completedSteps.Contains(CurrentStep));
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //MyACE.DoStep(CurrentStep);
                                    completedSteps.Add(CurrentStep);
                                }
                                DoRelFields(AcSeries, 9);
                                break;
                            case ACEngine.Step.BFs:
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    fmCurrent.GetActivity().CalculateBF(MyACE.NewActivity, false, false);
                                    completedSteps.Add(CurrentStep);

                                    Janus.Windows.GridEX.GridEXFilterCondition filc = new Janus.Windows.GridEX.GridEXFilterCondition();
                                    Janus.Windows.GridEX.GridEXFormatCondition fc = new Janus.Windows.GridEX.GridEXFormatCondition();
                                    filc.Column = activityBFGridEX.RootTable.Columns["BFDate"];
                                    filc.Value1 = DateTime.Today;
                                    filc.ConditionOperator = Janus.Windows.GridEX.ConditionOperator.LessThan;
                                    fc.FilterCondition = filc;
                                    fc.FormatStyle.BackColor = Color.Yellow;
                                    fc.FormatStyle.ForeColor = Color.Red;
                                    fc.FormatStyle.FontItalic = Janus.Windows.GridEX.TriState.True;
                                    activityBFGridEX.RootTable.FormatConditions.Add(fc);

                                    UIHelper.DoNewBFMenu(MyACE.FM, uiContextMenu2);
                                }
                                string BFStepHelp = AcSeries["BF" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                                SetHelpPanel(BFStepHelp.Length > 0, BFStepHelp);
                                break;
                            case ACEngine.Step.Disbursements:
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    UIHelper.ComboBoxInit("DisbursementType", disbursementGridEX.DropDowns["ddDisbType"], fmCurrent);
                                    completedSteps.Add(CurrentStep);
                                }
                                break;

                            case ACEngine.Step.Billing:

                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    MyACE.DoStep(CurrentStep, true);
                                    RecordHoursFromTimer();
                                    completedSteps.Add(CurrentStep);
                                }
                                string BillingStepHelp = AcSeries["Billing" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                                SetHelpPanel(BillingStepHelp.Length > 0, BillingStepHelp);

                                break;
                            case ACEngine.Step.Prompt:
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //ABP.SetRelDefaults(-1);
                                    completedSteps.Add(CurrentStep);
                                }

                                DoRelFields(AcSeries, -1);
                                break;
                            case ACEngine.Step.Document:

                                if (myRF != null)
                                    myRF.Dispose();

                                if (MyACE.myAcSeries.ShowSkipDoc)
                                {
                                    if (!checkboxJumpToFile.Visible)
                                        chkSkipDoc.Left = btnSuspendActivity.Left - chkSkipDoc.Width - 2;

                                    chkSkipDoc.Visible = true;
                                }
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    //these two lines are so the textcontrol will work properly
                                    StepPanels[CurrentStep].Closed = false;
                                    StepPanels[CurrentStep].Activate();

                                    try
                                    {
                                        if (myRevType == ACEngine.RevType.Document | myRevType == ACEngine.RevType.Convert)
                                        {
                                            if (RevId == 0)
                                                MyACE.DocumentDefaults(false);
                                            else
                                                MyACE.DocumentDefaults(true);
                                        }
                                        else
                                        {
                                            MyACE.DocumentDefaults(false);
                                        }
                                    }
                                    catch(atLogic.AtriumException x)
                                    {
                                        UIHelper.HandleUIException(x);
                                    }

                                    //add attachment if provided
                                    if (AttDocId != 0)
                                    {
                                        docDB.AttachmentRow atr = (docDB.AttachmentRow)fmCurrent.GetDocMng().GetAttachment().Add(CurrentMailDoc());
                                        atr.AttachmentId = AttDocId;

                                    }

                                    //if (mailAction == ConnectorType.Reply || mailAction == ConnectorType.ReplyAll || mailAction == ConnectorType.Forward)
                                    //    ucDoc1.AddReplyHeader( fmCurrent.GetDocMng().DB.Document.FindByDocId(ABP.PrevComAcRow.DocId));
                                    completedSteps.Add(CurrentStep);


                                    string DocStepHelp = AcSeries["Document" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                                    SetHelpPanel(DocStepHelp.Length > 0, DocStepHelp);

                                    if (myRevType == ACEngine.RevType.Convert)
                                        ucDoc1.EditMode = UserControls.ucDoc.EditModeEnum.Read;

                                    ucDoc1.Init(fmCurrent.GetDocMng());
                                    ucDoc1.Datasource = MyACE.relTables["Document0"];
                                    //ucDoc1.Datasource = new DataView(fmCurrent.GetDocMng().DB.Document, "Docid=" +ABP.relTables["Document0"]. dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                                    ucDoc1.Preview();
                                    //ucDoc1.PreviewAsync();
                                }
                                if (IsRestored)
                                {
                                    string DocStepHelp = AcSeries["Document" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                                    SetHelpPanel(DocStepHelp.Length > 0, DocStepHelp);

                                    ucDoc1.Init(fmCurrent.GetDocMng());
                                    ucDoc1.Datasource = MyACE.relTables["Document0"];
                                    //ucDoc1.Datasource = new DataView(fmCurrent.GetDocMng().DB.Document, "Docid=" +ABP.relTables["Document0"]. dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                                    ucDoc1.Preview();
                                    //ucDoc1.PreviewAsync();

                                }
                                ucDoc1.Focus1();
                                break;

                            case ACEngine.Step.CreateFile:
                                if (!completedSteps.Contains(CurrentStep))
                                {
                                    DoCreateFile();
                                    completedSteps.Add(CurrentStep);
                                    CurrentStep = Next();
                                    //return;
                                }
                                else
                                {
                                    //why are you still here?
                                    CurrentStep = Next();
                                }
                                break;
                            default:
                                break;

                        }

                        if (myRF == null)
                            EnableButtons(0);
                        else
                            EnableButtons(myRF.required.Count);

                        timFocus.Start();

                        if (Seq.Count > 1 && CurrentStep == Seq.Last.Value)
                        {
                            buttonLast.Enabled = false;
                            buttonFinish.Enabled = true;
                            this.AcceptButton = buttonFinish;
                            buttonNext.Enabled = false;

                        }

                        if (!IsDisposed && !Disposing)
                        {
                            //show new current step
                            StepPanels[CurrentStep].Closed = false;
                            StepPanels[CurrentStep].Activate();
                            if (CurrentStep == ACEngine.Step.Document)
                                ucDoc1.Focus1();
                            if (CurrentStep == ACEngine.Step.PickActivity)
                                tbJCode.Focus();

                            //update header title
                            pnlAll.Text = StepPanels[CurrentStep].Text;
                        }
                    }
                    catch (Exception x)
                    {
                        buttonNext.Enabled = false;
                        buttonLast.Enabled = false;
                        buttonFinish.Enabled = false;
                        throw;
                    }
                }
            }
        }

        private void RecordHoursFromTimer()
        {
            TimeSpan ts = RoundUpToMinutes();
            if (MyACE.relTables.ContainsKey("ActivityTime0"))
            {
                atriumDB.ActivityTimeRow atr = (atriumDB.ActivityTimeRow)MyACE.relTables["ActivityTime0"][0].Row;
                if (atr.IsHoursNull() || atr.Hours == 0)
                {
                    decimal hours = (decimal)(ts.TotalMinutes / 60);
                    atr.Hours = RoundUpToHours(hours);
                }

            }
        }

        public void EnableButtons(int required)
        {
            buttonLast.Enabled = false;
            buttonFinish.Enabled = false;
            // if ((int)CurrentStep <= (int)ACEngine.Step.RelatedFields9 && (int)CurrentStep >= (int)ACEngine.Step.RelatedFields0)
            if (CurrentStep != ACEngine.Step.Confirm)
                buttonNext.Enabled = (required == 0);

            if (Seq.Count > 1 && CurrentStep >= ACEngine.Step.Document && required == 0)
            {
                if (CurrentStep != ACEngine.Step.Confirm)
                    buttonLast.Enabled = true;
                buttonFinish.Enabled = true;
            }
            if (MyACE != null && !MyACE.HasDoc && Seq.Count > 1 && Next() >= ACEngine.Step.Document && required == 0)
            {
                buttonLast.Enabled = true;
                buttonFinish.Enabled = true;
            }
            if (CurrentStep == ACEngine.Step.Document && ucDoc1.DocRecord != null && ucDoc1.DocRecord.RowState != DataRowState.Detached && ucDoc1.EditMode == UserControls.ucDoc.EditModeEnum.Compose && ucDoc1.DocRecord.isLawmail && ucDoc1.ToPersonIsNullOnCompose)
            {
                buttonNext.Enabled = false;
                buttonLast.Enabled = false;
                buttonFinish.Enabled = false;
            }
            if (MyACE != null && MyACE.IsRepeating && MyACE.RepeatCurrent < MyACE.RepeatMax)
            {
                buttonLast.Enabled = false;
                buttonFinish.Enabled = false;
            }

        }

        private docDB.DocumentRow CurrentMailDoc()
        {
            return (docDB.DocumentRow)MyACE.relTables["Document0"][0].Row;
        }

        public bool OpenFile
        {
            get
            {
                if (checkboxJumpToFile.Visible)
                    return checkboxJumpToFile.Checked;
                else
                    return false;

            }
            set
            {
                checkboxJumpToFile.Checked = value;
            }
        }

        public int FileId
        {
            get
            {
                return fmCurrent.CurrentFile.FileId;
            }
        }

        private void ProcessPrompt()
        {
            foreach (ActivityConfig.ActivityFieldRow arf in fmCurrent.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + AcSeries.ACSeriesId.ToString() + " and TaskType = 'P' and step=-1", "seq"))
            {
                CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[MyACE.relTables[arf.ObjectAlias]];
                DataRow dr = (DataRow)((DataRowView)myCurrencyManager.Current).Row;
                MyACE.relTables[arf.ObjectAlias] = new DataView(dr.Table, dr.Table.PrimaryKey[0].ToString() + "=" + dr[dr.Table.PrimaryKey[0].ToString()].ToString(), "", DataViewRowState.CurrentRows);
            }
            Seq.Remove(ACEngine.Step.Prompt);
        }

        void fmCurrent_OnWarning(object sender, atLogic.WarningEventArgs e)
        {
            if (e.Level == atLogic.WarningLevel.Interrupt)
            {
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show(e.Message, e.Source, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void DoCreateFile()
        {

            //DoCreateFile fails for the New Request for Legal Advice Process
            //ABP doesn't load a process...file is new, doesn't have existing process, acseriesid is not start, etc.
            //get process feeding off ActivityBFRow??
            FileManager fmParent = fmCurrent;

            if (!AcSeries.SeriesRow.IsContainerFileIdNull())
            {
                fmParent = Atmng.GetFile(AcSeries.SeriesRow.ContainerFileId);
            }
            fmCurrent = Atmng.CreateFile(fmParent);
            fmCurrent.SourceFile = fmOriginal;
            //fmCurrent.KeepAlive = true;
            fmCurrent.OnWarning += new atLogic.WarningEventHandler(fmCurrent_OnWarning);

            ABP = fmCurrent.InitActivityProcess();
            //MyACE.OnPrompt += new PromptEventHandler(ABP_OnPrompt);

            if (prevAc != 0)
            {
                atriumDB.ActivityRow ar = fmCurrent.GetActivity().Load(prevAc);
                //get all acs on process
                fmCurrent.GetActivity().LoadByProcessId(ar.ProcessId);
                atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])fmCurrent.DB.Activity.Select("ProcessId=" + ar.ProcessId.ToString());

                if (ar.FileId != fmCurrent.CurrentFile.FileId)
                    fmCurrent.GetActivity().Move(ars, fmCurrent.CurrentFile.FileId, true);
                Process = ar.ProcessRow;

            }
            if (PreviousStep == ACEngine.Step.PickIssue)
            {
                //Create File Cross References??
                // We need to move current activity (select issue & due date) onto fmCurrent
                // Or do we do that as part of the "Moving the entire thread" bit?
                // When do we then?

                FileXRefBE fxBE = fmCurrent.GetFileXRef();
                foreach (appDB.IssueRow ir in SecondaryIssues.Values)
                {
                    atriumDB.FileXRefRow fxr = (atriumDB.FileXRefRow)fxBE.Add(fmCurrent.CurrentFile);

                    fxr.LinkType = 1;
                    fxr.OtherFileId = ir.FileId;
                    fxr.Rollup = false;
                    fxr.FullFileNumber = fmCurrent.EFile.Load(ir.FileId, false).FullFileNumber;

                }

                ShowIssuesOnCreateFile(true);
                fmParent.Dispose();


            }


            UIHelper.ComboBoxInit("Status", statusCodeComboBox, fmCurrent);
            UIHelper.ComboBoxInit("FileType", fileTypeComboBox, fmCurrent);


            eFileBindingSource.DataSource = fmCurrent.DB;
            eFileBindingSource.DataMember = "EFile";

            //            FileId = fmCurrent.CurrentFile.FileId;
            checkboxJumpToFile.Visible = true;

        }
        private void LoadNextSteps(TreeView tv)
        {
            ABP = fmCurrent.InitActivityProcess();
            //MyACE.OnPrompt += new PromptEventHandler(ABP_OnPrompt);

            Dictionary<int, atriumBE.CurrentFlow> activeProcesses = ABP.Workflow.NextSteps();

            int restrictProcessId = 0;
            if (restrictAcId != 0)
                restrictProcessId = fmCurrent.DB.Activity.FindByActivityId(restrictAcId).ProcessId;
            //add process to list
            foreach (CurrentFlow ap in activeProcesses.Values)
            {
                if (ap.NextSteps.Count > 0 & (restrictAcId == 0 | ap.Process.ProcessId == restrictProcessId))
                {
                    TreeNode nProcess = tv.Nodes.Add(ap.Process.Name);

                    nProcess.Tag = ap.Process;
                    nProcess.Expand();
                    SetImage(nProcess, StepType.Start);

                    LoadNextSteps(ap, nProcess);
                }
            }


            //tvNextSteps.ExpandAll();
        }


        public class NodeSorter : System.Collections.IComparer
        {
            // Compare the length of the strings, or the strings 
            // themselves, if they are the same length. 
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                // Compare the length of the strings, returning the difference. 
                if (tx.Tag != null && ty.Tag != null && tx.Tag.GetType() == typeof(NextStep) && ty.Tag.GetType() == typeof(NextStep))
                {
                    NextStep nsx = (NextStep)tx.Tag;
                    NextStep nsy = (NextStep)ty.Tag;

                    return string.Compare(nsx.acs.StepCode, nsy.acs.StepCode);
                }
                if (tx.Name == "ALL")
                    return string.Compare("ZZZZZZZZ", ty.Text);
                if (ty.Name == "ALL")
                    return string.Compare(tx.Text, "ZZZZZZZZ");

                // If they are the same length, call Compare. 
                return string.Compare(tx.Text, ty.Text);
            }
        }

        private void LoadNextSteps(CurrentFlow ap, TreeNode tn)
        {
            foreach (NextStep ns1 in ap.NextSteps.Values)
            {
                bool ok = true;
                NextStep ns = ABP.Workflow.SillyQuestion(ns1);

                StepType st = (StepType)ns.acs.StepType;

                if (st == StepType.Activity)
                {
                    if (myRevType == ACEngine.RevType.Convert)
                    {
                        if (!Converts.Contains(ns.acs.ACSeriesId))
                            ok = false;
                    }
                }

                //    lmDatasets.atriumDB.ProcessRow p = FindProcess(tn);
                if (ok)
                {
                    string linkText = ns.LinkText;
                    if (ns.acs.ACSeriesId != ns1.acs.ACSeriesId)
                        linkText = ns1.LinkText;

                    string text = linkText + Atmng.acMng.GetACSeries().GetNodeText(ns.acs, st, false);
                    TreeNode nStep = tn.Nodes.Add(text);
                    nStep.Tag = ns;
                    nStep.Expand();

                    if (st == StepType.Activity)
                    {
                        if (myRevType == ACEngine.RevType.Convert)
                        {
                            if (!Converts.Contains(ns.acs.ACSeriesId))
                                ns.Enabled = false;
                        }

                        nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular | FontStyle.Underline);
                        nStep.ForeColor = Color.Blue;
                        if (ns.Enabled)
                            ABP.AcSeriesOKToAdd.Add(ns.acs);
                        //removed as users find it confusing
                        //       if (Atmng.acMng.GetACSeries().hasAnAutoStep(ns.acs)) // Has an Auto Step after this step
                        //           DrawAutoStepNode(ns, nStep);                      
                    }
                    //else if (st == StepType.Subseries)  TreeView set to Bold by default for workaround re: treenode truncating text
                    //    nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Bold);
                    else if (st == StepType.NonRecorded)
                    {
                        nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular);
                        nStep.Collapse();
                    }
                    else if (st == StepType.Decision)
                    {
                        nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular);
                        nStep.Collapse();
                    }
                    else if (st == StepType.Subseries)
                    {
                        nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular);
                    }

                    if (!ns.Enabled)
                        nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular | FontStyle.Strikeout);


                    SetImage(nStep, st);

                    if (ns.Children != null)
                        LoadNextSteps(ns.Children, nStep);

                }
            }
        }

        private void DrawAutoStepNode(NextStep ns, TreeNode nStep)
        {
            ActivityConfig.ACSeriesRow acsAuto = Atmng.acMng.GetACSeries().GetAutoStep(ns.acs);
            string tAuto = Atmng.acMng.GetACSeries().GetNodeText(acsAuto, (StepType)acsAuto.StepType, false);
            TreeNode nAuto = nStep.Nodes.Add(tAuto);
            nAuto.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular | FontStyle.Strikeout);
            //ns.Enabled = false;
            nAuto.ForeColor = Color.Blue;
            nAuto.ImageIndex = 20;
            nAuto.SelectedImageIndex = nAuto.ImageIndex;
        }



        private TreeNode CreateSeriesTreeNode(CurrentFlow currFlow, TreeView tvProc)
        {
            return CreateTreeNode(currFlow.Series["SeriesDesc" + fmCurrent.AtMng.AppMan.Language].ToString() + " (" + currFlow.Series["SeriesCode"] + ")", tvProc);
        }

        private TreeNode CreateTreeNode(string text, TreeView tvProc)
        {
            TreeNode ndProc = tvProc.Nodes.Add(text);
            SetImage(ndProc, StepType.Start);
            return ndProc;
        }
        private void LoadEnabledProcesses(TreeView tv, bool hideProc)
        {
            Dictionary<int, CurrentFlow> enabledProcesses = ABP.Workflow.EnabledProcesses();

            //JLL 2013-06-19: sort nodes alphabetically
            System.Collections.Generic.SortedDictionary<int, CurrentFlow> sortedEnabledProcesses = null;
            if (enabledProcesses != null)
            {
                sortedEnabledProcesses = new SortedDictionary<int, CurrentFlow>(enabledProcesses);
            }

            TreeNode ndProc = null;
            if (hideProc)
            {
                ndProc = CreateTreeNode("All Steps", tv);
                ndProc.Name = "ALL";

            }
            //foreach (CurrentFlow availSeries in enabledProcesses.Values)
            foreach (CurrentFlow availSeries in sortedEnabledProcesses.Values)
            {
                if (!hideProc)
                { ndProc = CreateSeriesTreeNode(availSeries, tv); }
                LoadNextSteps(availSeries, ndProc);
            }

            if (!hideProc)
            {
                uiTabEnabledProcesses.Text += " (" + enabledProcesses.Count + ")";
                if (enabledProcesses.Count == 0)
                    uiTabEnabledProcesses.Enabled = false;
            }
        }

        private void LoadAvailableProcesses(TreeView tv, bool hideProc)
        {
            Dictionary<int, CurrentFlow> availProcesses = ABP.Workflow.AvailableProcesses();

            //JLL 2013-06-19: sort nodes alphabetically
            System.Collections.Generic.SortedDictionary<int, CurrentFlow> sortedAvailProcesses = null;
            if (availProcesses != null)
            {
                sortedAvailProcesses = new SortedDictionary<int, CurrentFlow>(availProcesses);
            }

            TreeNode ndProc = null;
            if (hideProc)
            {
                TreeNode[] tns = tv.Nodes.Find("ALL", true);
                if (tns.Length == 1)
                    ndProc = tns[0];
                else
                    ndProc = CreateTreeNode("Enabled Steps", tv);

            }
            //foreach (CurrentFlow availSeries in availProcesses.Values)
            foreach (CurrentFlow availSeries in availProcesses.Values)
            {
                if (!hideProc)
                { ndProc = CreateSeriesTreeNode(availSeries, tv); }
                LoadNextSteps(availSeries, ndProc);
            }
            if (!hideProc)
            {
                uiTabAlwaysAvailable.Text += " (" + availProcesses.Count + ")";
                if (availProcesses.Count == 0)
                    uiTabAlwaysAvailable.Enabled = false;
            }
        }

        //private void LoadProcNested(CurrentFlow availSeries, TreeNode ndProc)
        //{
        //    foreach (NextStep ns in availSeries.NextSteps.Values)
        //    {
        //        string text = ns.LinkText + Atmng.acMng.GetACSeries().GetNodeText(ns.acs, (StepType)ns.acs.StepType, false);
        //        TreeNode nStep = ndProc.Nodes.Add(text);
        //        nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular);
        //        nStep.Tag = ns;
        //        SetImage(nStep, (StepType)ns.acs.StepType);
        //        if ((StepType)ns.acs.StepType == StepType.Activity)
        //        {
        //            nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular | FontStyle.Underline);
        //            nStep.ForeColor = Color.Blue;
        //            AcSeriesOKToAdd.Add(ns.acs);

        //            if (Atmng.acMng.GetACSeries().hasAnAutoStep(ns.acs)) // Has an Auto Step after this step
        //                DrawAutoStepNode(ns, nStep);

        //        }
        //        if (!ns.Enabled)
        //            nStep.NodeFont = new Font(tvNextSteps.Font, FontStyle.Regular | FontStyle.Strikeout);

        //        if (ns.Children != null)
        //            LoadProcNested(ns.Children, nStep);
        //    }
        //}

        private void ShowIssuesOnCreateFile(bool val)
        {
            lblPrimaryIssueConfirm.Visible = val;
            lblSecondaryIssueConfirm.Visible = val;
            tbPrimaryIssueConfirm.Visible = val;
            listBoxSecondaryIssueConfirm.Visible = val;
            if (val)
            {
                tbPrimaryIssueConfirm.Text = (string)PrimaryIssue[UIHelper.Translate(fmCurrent, "IssueNameEng")];
                listBoxSecondaryIssueConfirm.ValueMember = "IssueId";
                listBoxSecondaryIssueConfirm.DisplayMember = UIHelper.Translate(fmCurrent, "IssueNameEng");
                listBoxSecondaryIssueConfirm.DataSource = SecondaryIssues.Values;
            }
        }


        public ACEngine.Step PreviousStep
        {
            get { return myPreviousStep; }
            set { myPreviousStep = value; }
        }


        protected atriumBE.atriumManager Atmng
        {
            get
            {
                return (UIHelper.AtMng);
            }
        }

        public fACWizard(FileManager fm)
        {
            try
            {
                InitializeComponent();

                Seq.AddFirst(ACEngine.Step.PickActivity);
                // let init2 hanlde this Seq.AddLast(Step.ACInfo);

                fmCurrent = fm;
                fmOriginal = fm;

                //myInitialFMKeepAlive = fmCurrent.KeepAlive;
                //fmCurrent.KeepAlive = true;

                Init();

                myInitialStep = ACEngine.Step.PickActivity;
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }
        }

        //restore draft ac
        public fACWizard(FileManager fm, ACEState aces)
        {
            try
            {
                InitializeComponent();

                IsRestored = true;


                fmCurrent = fm;
                fmOriginal = fm;
                //myInitialFMKeepAlive = fmCurrent.KeepAlive;
                //fmCurrent.KeepAlive = true;

                ABP = fmCurrent.InitActivityProcess();
                MyACE = new ACEngine(fm, aces);
                ABP.CurrentACE = MyACE;

                //check to see if this activity or step in process has been done already
                //how?

                Init();

                //reset start time to take into account previous elapsed time
                startTime = DateTime.Now.Subtract(new TimeSpan(0, 0, aces.elapsedTimeSeconds));

                if (aces.ParentFileId != 0)
                    checkboxJumpToFile.Visible = true;

                AcSeries = MyACE.myAcSeries;

                completedSteps.AddRange(aces.completedSteps);
                foreach (ACEngine.Step st in aces.Seq)
                {
                    Seq.AddLast(st);
                }
                myPreviousStep = aces.myPreviousStep;
                myCurrentStep = aces.myPreviousStep;

                if (completedSteps.Contains(ACEngine.Step.Document))
                {
                    string DocStepHelp = AcSeries["Document" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                    SetHelpPanel(DocStepHelp.Length > 0, DocStepHelp);

                    ucDoc1.Init(fmCurrent.GetDocMng());
                    ucDoc1.Datasource = MyACE.relTables["Document0"];
                    //ucDoc1.Datasource = new DataView(fmCurrent.GetDocMng().DB.Document, "Docid=" +ABP.relTables["Document0"]. dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                    ucDoc1.Preview();
                    //ucDoc1.PreviewAsync();


                }

                CurrentStep = aces.myCurrentStep;

                if (Back() == ACEngine.Step.ACInfo)
                    buttonBack.Enabled = false;

                btnSuspendActivity.Enabled = true;

                mailAction = MyACE.MailAction;
                this.Text = MyACE.FM.CurrentFile.Name + " (" + MyACE.FM.CurrentFile.FullFileNumber + ") - " + Atmng.acMng.GetACSeries().GetNodeText(AcSeries, StepType.Activity, false);

                UIHelper.ComboBoxInit("vOFFICERLIST", officerIdComboBox, fmCurrent, "OfficerId", "FullName");

                DataView dv = new DataView(fmCurrent.DB.Activity, "ActivityId=" + MyACE.NewActivity.ActivityId.ToString(), "", DataViewRowState.CurrentRows);
                activityBindingSource.DataSource = dv;

            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }

        }

        /// <summary>
        /// Constructor used when passing in an ActivityID; only that activity's process will display in next steps, and Available Processes will be hidden
        /// </summary>
        /// <param name="fm">The FileManager of the file that relates to the ActivityID</param>
        /// <param name="activityId">The ActivityID of the activity that is used for context when calculating next steps</param>
        public fACWizard(FileManager fm, int activityId)
        {
            try
            {
                //for next steps
                InitializeComponent();

                restrictAcId = activityId;

                Seq.AddFirst(ACEngine.Step.PickActivity);
                // let init2 hanlde this Seq.AddLast(Step.ACInfo);

                fmCurrent = fm;
                fmOriginal = fm;

                //myInitialFMKeepAlive = fmCurrent.KeepAlive;
                //fmCurrent.KeepAlive = true;

                Init();
                lnkAllActivities.Visible = false;
                uiTabAlwaysAvailable.TabVisible = false;
                uiTabEnabledProcesses.TabVisible = false;

                myInitialStep = ACEngine.Step.PickActivity;
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }

        }
        public fACWizard(FileManager fm, ACEngine.Step initialStep, int ACSeriesId, int activityId, bool UserSelectedToSkipDoc)
        {
            try
            {
                SkipDocument = UserSelectedToSkipDoc;
                prevAc = activityId;
                Init2(fm, initialStep, ACSeriesId);
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }


        }
        public fACWizard(FileManager fm, ACEngine.Step initialStep, int ACSeriesId, int activityId, ConnectorType action)
        {
            try
            {
                mailAction = action;
                prevAc = activityId;
                Init2(fm, initialStep, ACSeriesId);
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }


        }
        private int RevId;
        DataRow contextRow;
        private int AttDocId;
        private List<int> Converts = new List<int>();
        public fACWizard(FileManager fm, ACEngine.Step initialStep, int ACSeriesId, int docId, string op)
        {
            try
            {
                myRevType = ACEngine.RevType.Document;
                switch (op)
                {
                    case "CONVERT":
                        RevId = docId;
                        myRevType = ACEngine.RevType.Convert;
                        lmDatasets.ActivityConfig.ACConvertRow[] accs = fm.AtMng.acMng.DB.ACSeries.FindByACSeriesId(ACSeriesId).GetACConvertRowsByACSeries_ACConvert();
                        foreach (lmDatasets.ActivityConfig.ACConvertRow acc in accs)
                        {
                            Converts.Add(acc.AllowableACSeriesId);
                        }
                        break;
                    case "REVISE":
                        RevId = docId;
                        break;
                    case "SENDATT":
                        AttDocId = docId;
                        break;
                }
                Init2(fm, initialStep, ACSeriesId);
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }
        }

        ACEngine.RevType myRevType = ACEngine.RevType.Nothing;
        /// <summary>
        /// THis method is only used for revising appointments
        /// </summary>
        /// <param name="fm"></param>
        /// <param name="ACSeriesId"></param>
        /// <param name="apptId"></param>
        public fACWizard(FileManager fm, int ACSeriesId, int apptId)
        {
            InitRevision(fm, ACSeriesId, ACEngine.RevType.Appointment, apptId);
        }

        public fACWizard(FileManager fm, int ACSeriesId, ACEngine.RevType revType, int ctxId, DataRow _contextRow)
        {
            contextRow = _contextRow;
            InitRevision(fm, ACSeriesId, revType, ctxId);
        }

        private void InitRevision(FileManager fm, int ACSeriesId, ACEngine.RevType revType, int ctxId)
        {
            try
            {
                RevId = ctxId;
                myRevType = revType;

                Init2(fm, ACEngine.Step.ACInfo, ACSeriesId);
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }
        }

        public fACWizard(FileManager fm, ACEngine.Step initialStep, int ACSeriesId, bool UserSelectedToSkipDoc)
        {
            try
            {
                SkipDocument = UserSelectedToSkipDoc;
                Init2(fm, initialStep, ACSeriesId);
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }
        }


        public fACWizard(FileManager fm, ACEngine.Step initialStep, int ACSeriesId)
        {
            try
            {
                Init2(fm, initialStep, ACSeriesId);
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }
        }

        public fACWizard(FileManager fm, ACEngine.Step initialStep, int ACSeriesId, string ContactEmail)
        {
            try
            {
                Init2(fm, initialStep, ACSeriesId);
                ucDoc1.AddRecip(ContactEmail);
            }
            catch (Exception x)
            {
                fm.KillACEngine();
                throw x;
            }

        }
        private void Init2(FileManager fm, ACEngine.Step initialStep, int ACSeriesId)
        {
            InitializeComponent();
            fmCurrent = fm;
            fmOriginal = fm;
            //myInitialFMKeepAlive = fmCurrent.KeepAlive;
            //fmCurrent.KeepAlive = true;

            Init();

            AcSeries = Atmng.acMng.DB.ACSeries.FindByACSeriesId(ACSeriesId);

            Init3(initialStep);

            myInitialStep = initialStep;

        }
        private void Init3(ACEngine.Step initialStep)
        {



            switch (initialStep)
            {
                case ACEngine.Step.Timeline:
                    if (prevAc != 0)
                    {
                        atriumDB.ActivityRow ar = fmCurrent.GetActivity().Load(prevAc);
                        if (ar != null)
                            Process = ar.ProcessRow;
                    }

                    ABP = fmCurrent.InitActivityProcess();
                    DoAcInfo();
                    break;
                case ACEngine.Step.PickIssue:
                    Seq.AddLast(initialStep);
                    //JLL 2018-04-23
                    //Seq.AddLast(ACEngine.Step.CreateFile);
                    Seq.AddLast(ACEngine.Step.ACInfo);
                    break;
                case ACEngine.Step.CreateFile:
                    Seq.AddLast(initialStep);
                    Seq.AddLast(ACEngine.Step.ACInfo);
                    break;
                case ACEngine.Step.ACInfo:
                    Seq.AddLast(initialStep);
                    if (prevAc != 0)
                    {
                        atriumDB.ActivityRow ar = fmCurrent.GetActivity().Load(prevAc);
                        Process = ar.ProcessRow;
                    }
                    break;
                case ACEngine.Step.Document:
                    Seq.AddLast(initialStep);
                    //CJW:  added on 2010/5/3
                    if (prevAc != 0)
                    {
                        atriumDB.ActivityRow ar = fmCurrent.GetActivity().Load(prevAc);
                        if (ar != null)
                            Process = ar.ProcessRow;
                    }
                    //cjw end add
                    ABP = fmCurrent.InitActivityProcess();
                    DoAcInfo();
                    break;
                case ACEngine.Step.PickActivity:
                    Seq.AddFirst(ACEngine.Step.PickActivity);
                    //lnkAllActivities.Visible = false;
                    //uiTabAlwaysAvailable.TabVisible = false;
                    //uiTabEnabledProcesses.TabVisible = false;
                    break;
                default:
                    throw new LMException(LawMate.Properties.Resources.UIInvalidInitialStep);

            }

        }
        public fACWizard()
        {
            InitializeComponent();


        }

        private void LoadLabels()
        {
            label6.Text = String.Format(LawMate.Properties.Resources.AppExpectsTheseRelatedFields, Atmng.AppMan.AppName);
            label36.Text = String.Format(LawMate.Properties.Resources.AppExpectsAppointment, Atmng.AppMan.AppName);
        }

        private void Init()
        {
            calDate.Value = DateTime.Today;

            uiTabPage4.TabVisible = Atmng.GetSetting(AppBoolSetting.ShowAllSteps);

            timFMHeartbeat.Start();
            ucDoc1.OpenDocDialog = ((fMain)Application.OpenForms["fMain"]).OpenDocDialog;
            ucDoc1.RecipientChanged += new UserControls.RecipientChangedEventHandler(ucDoc1_RecipientChanged);
            //ucDocPreview1.Init( fmCurrent.GetDocMng());
            startTime = DateTime.Now;
            LoadLabels();
            //associate tabs with step enum
            StepPanels.Add(ACEngine.Step.NoStep, pnlIssue);
            StepPanels.Add(ACEngine.Step.PickIssue, pnlIssue);
            StepPanels.Add(ACEngine.Step.CreateFile, pnlFile);
            StepPanels.Add(ACEngine.Step.ACInfo, pnlActivityConfirm);
            StepPanels.Add(ACEngine.Step.BFs, pnlBF);
            StepPanels.Add(ACEngine.Step.Billing, pnlBilling);
            StepPanels.Add(ACEngine.Step.Disbursements, pnlDisbursements);
            StepPanels.Add(ACEngine.Step.Document, pnlDocument);
            StepPanels.Add(ACEngine.Step.PickActivity, pnlActivity);
            StepPanels.Add(ACEngine.Step.RelatedFields0, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields1, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields2, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields3, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields4, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields5, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields6, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields7, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields8, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.RelatedFields9, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.Prompt, pnlRelatedFields);
            StepPanels.Add(ACEngine.Step.Confirm, pnlConfirm);
            StepPanels.Add(ACEngine.Step.Timeline, pnlTimeline);

            //eFileBindingSource.DataSource = fmCurrent.DB;
            //eFileBindingSource.DataMember = "EFile";

            foreach (Janus.Windows.UI.Dock.UIPanel pnl in StepPanels.Values)
            {
                pnl.Closed = true;
            }

            //StepPanels[CurrentStep].Closed = false;
            //StepPanels[CurrentStep].Activate();

            activityTimeGridEX.DropDowns["ddOfficer"].SetDataBinding(fmCurrent.Codes("OfficerList"), "");

            UIHelper.ComboBoxInit("vofficelist", activityTimeGridEX.DropDowns["ddOffice"], fmCurrent);

            //activityBFGridEX.DropDowns["ddBFType"].SetDataBinding(Atmng.CodeDB, "BFType");
            //activityBFGridEX.DropDowns["ddBFDesc"].SetDataBinding(Atmng.acMng.DB, "ACBF");
            UIHelper.ComboBoxInit(Atmng.CodeDB.BFType.TableName, activityBFGridEX.DropDowns["ddBFType"], fmCurrent);
            UIHelper.ComboBoxInit(Atmng.acMng.DB.ACBF.TableName, activityBFGridEX.DropDowns["ddBFDesc"], fmCurrent);
            UIHelper.ComboBoxInit("vRoleucontacttype", activityBFGridEX.DropDowns["ddRoleCode"], fmCurrent);
            activityBFGridEX.DropDowns["ddBFOfficer"].SetDataBinding(fmCurrent.Codes("OfficerList"), "");
            activityBFGridEX.DropDowns["ddOffice"].SetDataBinding(fmCurrent.Codes("vofficelist"), "");
            //activityBFGridEX.DropDowns["ddRoleCode"].SetDataBinding(fmCurrent.Codes("RoleCode"), "");



        }

        void ucDoc1_RecipientChanged(object sender, UserControls.RecipientChangedEventArgs e)
        {
            MyACE.NewActivity.SendType = ucDoc1.sendType;
            EnableButtons(0);
        }


        public ACEngine.Step Next()
        {
            if (AcSeries == null)
            {
                return ACEngine.Step.NoStep;
            }
            if (CurrentStep == ACEngine.Step.PickActivity)
            {
                Init3((ACEngine.Step)AcSeries.InitialStep);

            }
            //JLL 2018-04-23
            //if (CurrentStep == ACEngine.Step.PickIssue)
            //    return ACEngine.Step.ACInfo;

            LinkedListNode<ACEngine.Step> c = Seq.Find(CurrentStep);
            if (c.Next == null)
                return ACEngine.Step.Confirm;
            else
                return c.Next.Value;

        }

        public ACEngine.Step Back()
        {

            LinkedListNode<ACEngine.Step> c = Seq.Find(CurrentStep);
            if (c.Previous == null)
                return CurrentStep;
            return c.Previous.Value;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentStep = Next();

            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentStep = Back();
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MyACE != null)
                {
                    string file = Atmng.SaveFileName(fmCurrent.CurrentFile.FileId, MyACE.NewActivity.ActivityId);
                    if (System.IO.File.Exists(file))
                    {
                        if (IsRestored && MessageBox.Show(LawMate.Properties.Resources.DoYouWantToDeleteTheSaveFile, LawMate.Properties.Resources.DeleteSaveFile, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Atmng.DeleteSuspendedAc(file);
                        }
                        else if (IsErrorOnSave && MessageBox.Show(LawMate.Properties.Resources.KeepSaveFileOrDoYouWantToDeleteIt, LawMate.Properties.Resources.DeleteSaveFile, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Atmng.DeleteSuspendedAc(file);

                        }

                    }
                }
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        //private void lnkAllActivities_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        if (ExplorerBarAllActivities.Nodes.Count == 0)
        //        {

        //            //foreach (lmDatasets.ActivityConfig.SeriesRow sr in Atmng.acMng.DB.Series)
        //            foreach (lmDatasets.atriumDB.ProcessRow pr in fmCurrent.DB.Process)
        //            {
        //                TreeNode ndS = ExplorerBarAllActivities.Nodes.Add(pr.Name);
        //                SetImage(ndS, StepType.Start);

        //                lmDatasets.ActivityConfig.SeriesRow sr = Atmng.acMng.DB.Series.FindBySeriesId(pr.SeriesId);
        //                foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in sr.GetACSeriesRows())
        //                {
        //                    if ((StepType)acsr.StepType == StepType.Activity)
        //                    {
        //                        TreeNode nStep = ndS.Nodes.Add(Atmng.acMng.GetACSeries().GetNodeText(acsr, (StepType)acsr.StepType, false));
        //                        nStep.Tag = acsr;
        //                        SetImage(nStep, (StepType)acsr.StepType);
        //                    }
        //                }
        //            }
        //            ExplorerBarAllActivities.ExpandAll();
        //        }

        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }


        //}

        //private void lnkNextStepsProcesses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        private void ClearCodeSelection(TreeView tv, bool ClearCodeField)
        {
            if (ClearCodeField)
                tbJCode.Text = "";
            ebACDescription.Text = "";
            AcSeries = null;
            prevAc = 0;
            tv.SelectedNode = null;
            this.MySelectedStep = null;
            btnHelpTriangle.Visible = false;
            DoSkipDocumentCheck(null);

        }

        private void DoSkipDocumentCheck(NextStep ns)
        {
            bool reset = false;
            if (ns == null)
                reset = true;
            else if (!ns.acs.ShowSkipDoc)
                reset = true;

            uiCheckBox1.Visible = !reset;
            if (reset)
            {
                btnHelpTriangle.Left = tbJCode.Right + 1;
                uiCheckBox1.Checked = false;
            }
            else
                btnHelpTriangle.Left = uiCheckBox1.Right + 1;
        }
        private bool FindByCode(TreeNodeCollection tns, string userTyped, TreeView tv)
        {
            buttonLast.Enabled = false;
            buttonFinish.Enabled = false;

            string typed = userTyped.ToUpper();
            if (typed.Length == 0)
            {
                ClearCodeSelection(tv, true);
                return false;
            }

            if (!CodeFieldBackspaceKeyPressed)
            {
                foreach (TreeNode tn in tns)
                {
                    if (tn.Tag != null && tn.Tag.GetType() == typeof(NextStep))
                    {
                        NextStep ns = (NextStep)tn.Tag;
                        DoSkipDocumentCheck(ns);
                        if ((StepType)ns.acs.StepType == StepType.Activity && ns.Enabled)
                        {
                            string code = ns.acs.StepCode;

                            if (code.StartsWith(typed) && typed.Length > 0)
                            {
                                if (tv.SelectedNode == tn)
                                    tv.SelectedNode = null;

                                tv.SelectedNode = tn;
                                tn.EnsureVisible();
                                tbJCode.SelectionStart = typed.Length;
                                tbJCode.SelectionLength = code.Length - typed.Length;

                                this.AcSeries = ns.acs;
                                MySelectedStep = ns;
                                //check for rel fields
                                CheckForQuickFinish(ns);

                                if (ns.prevAc != null)
                                    this.prevAc = ns.prevAc.ActivityId;

                                PickACS(tn);
                                return true;
                            }
                        }
                    }
                    if (FindByCode(tn.Nodes, typed, tv))
                        return true;
                }
                //ClearCodeSelection(tv, true);
            }
            ClearCodeSelection(tv, false);


            return false;
        }
        private void tbCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool matchFound = false;
                if (!CodeChangeInitiatedByUserClick)
                {
                    if (ExplorerBarAllActivities.Nodes.Count > 0)
                    {
                        matchFound = FindByCode(ExplorerBarAllActivities.Nodes, tbJCode.Text, ExplorerBarAllActivities);
                        if (matchFound) //Typed code match found in Next Steps
                        {
                            uiTab1.SelectedTab = uiTabPage4;
                            return;
                        }
                    }
                    else
                    {
                        matchFound = FindByCode(tvNextSteps.Nodes, tbJCode.Text, tvNextSteps);
                        if (matchFound) //Typed code match found in Next Steps
                        {
                            uiTab1.SelectedTab = uiTabNextSteps;
                            return;
                        }
                        else
                            matchFound = FindByCode(tvEnabledProcesses.Nodes, tbJCode.Text, tvEnabledProcesses);

                        //TFS#54801 JLL: Order changed to verify match on Enabled Process before Always Available

                        if (matchFound) //Typed code match found in Enabled Processes
                        {
                            //uiTab1.SelectedTab = uiTabAlwaysAvailable;
                            uiTab1.SelectedTab = uiTabEnabledProcesses;
                            return;
                        }
                        else
                            matchFound = FindByCode(ExplorerBarAvailableProcesses.Nodes, tbJCode.Text, ExplorerBarAvailableProcesses);
                        //matchFound = FindByCode(tvEnabledProcesses.Nodes, tbJCode.Text, tvEnabledProcesses);
                        if (matchFound) //Typed code match found in Always Available
                        {
                            uiTab1.SelectedTab = uiTabAlwaysAvailable;
                            return;
                        }
                    }

                    //if we get here, otherwise no match found
                }

            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
            finally { CodeFieldBackspaceKeyPressed = false; }
        }

        private void PickACS(TreeNode tn)
        {
            if ((StepType)AcSeries.StepType == StepType.Activity)
            {
                ebACDescription.Text = (string)AcSeries[UIHelper.Translate(fmCurrent, "ActivityNameEng")];
                //lblDescription.Text = (string)AcSeries[UIHelper.Translate(fmCurrent, "ActivityNameEng")];

                //for next steps

                //need to recurse to find process

                if (tn.Parent != null)
                    this.Process = FindProcess(tn.Parent);

                this.AdHoc = false;


                //for new process


                //for ad hoc

            }


            if (!AcSeries.IsNull(UIHelper.Translate(fmCurrent, "HelpE")))
            {
                //lblHelpClick.Visible = true;
                btnHelpTriangle.Visible = true;
            }
            else
            {
                //lblHelpClick.Visible = false;
                btnHelpTriangle.Visible = false;
            }

        }

        public void SetHelpPanel(bool showpanel, string helptext)
        {
            if (showpanel)
            {
                pnlHelpText.Closed = false;
                lblHelpText.Text = helptext;
            }
            else
            {
                pnlHelpText.Closed = true;
                lblHelpText.Text = "";
            }
        }

        private void AddPrimaryIssue(appDB.IssueRow ir, bool IssueSetInRelatedFields)
        {
            if (SecondaryIssues.ContainsKey(ir.IssueId))
            {
                MessageBox.Show(LawMate.Properties.Resources.UIIssueAlreadySecondary);
            }
            else
            {
                ebPrimaryIssue.Text = ir[UIHelper.Translate(fmCurrent, "IssueNameEng")].ToString();
                ebPrimaryIssue.Tag = ir;
                if (IssueSetInRelatedFields)
                {
                    uibtnAddPrimary.Enabled = false;
                    uibtnRemovePrimary.Enabled = false;
                }
                else
                {
                    uibtnAddPrimary.Enabled = false;
                    uibtnRemovePrimary.Enabled = true;
                }
                PrimaryIssue = ir;
            }
            //lblNoPrimaryIssue.Visible = false;
        }

        private void AddSecondaryIssue(appDB.IssueRow ir)
        {
            if (ebPrimaryIssue.Tag != null && ir.IssueId == ((lmDatasets.appDB.IssueRow)ebPrimaryIssue.Tag).IssueId)
            {
                MessageBox.Show(LawMate.Properties.Resources.UIIssueAlreadyPrimary);
            }
            else
            {
                SecondaryIssues.Add(ir.IssueId, ir);
                RefreshSecondaryIssues();
                uibtnRemoveSecondary.Enabled = true;
            }
        }

        private void DoRelIssue(ActivityConfig.ACSeriesRow acSeries)
        {
            foreach (ActivityConfig.ActivityFieldRow arf in fmCurrent.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + acSeries.ACSeriesId.ToString() + " and TaskType='I'"))
            {
                lmDatasets.appDB.IssueRow ir = Atmng.DB.Issue.FindByIssueId(Convert.ToInt32(arf.DefaultValue));

                if (arf.ObjectName.ToUpper() == "ISSUEPRIMARY")
                    AddPrimaryIssue(ir, true);
                else if (arf.ObjectName.ToUpper() == "ISSUESECONDARY")
                    AddSecondaryIssue(ir);
            }


        }
        //Control firstCtl = null;
        //UserControls.IRequiredCtl requiresAction = null;


        //public void DoRelFields(ActivityConfig.ACSeriesRow acSeries, int step)
        //{

        //    firstCtl = null;
        //    const int LBLWIDTH = 250;

        //    //try
        //    //{
        //    flowLayoutPanel1.Controls.Clear();
        //    required.Clear();
        //    int vis = 0;

        //    //hook up error providers for each related table
        //    foreach (DataView dv in MyACE.relTables.Values)
        //    {
        //        ErrorProvider ep = new ErrorProvider();
        //        ep.ContainerControl = this;
        //        ep.DataSource = dv;

        //        //this.Controls.Add(ep);
        //    }

        //    //help panel text
        //    if (step >= 0)
        //    {
        //        string RelStepHelp = acSeries["Rel" + step.ToString() + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
        //        SetHelpPanel(RelStepHelp.Length > 0, RelStepHelp);
        //    }
        //    else if (step == -1)
        //    {
        //        string PromptStepHelp = acSeries["Prompt" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
        //        SetHelpPanel(PromptStepHelp.Length > 0, PromptStepHelp);
        //    }

        //    if (!MyACE.skipBlock)
        //    {
        //        //create controls
        //        Janus.Windows.GridEX.GridEX gr = null;
        //        string gridObject = "";
        //        Janus.Windows.GridEX.GridEXColumn gc;
        //        foreach (ActivityConfig.ActivityFieldRow arf in fmCurrent.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + acSeries.ACSeriesId.ToString() + " and TaskType in ('F','P') and step=" + step.ToString(), "seq"))
        //        {
        //            Control ctl = null;
        //            bool customBinding = false;
        //            string prop = "Text";

        //            if (gridObject != arf.ObjectAlias)
        //            {
        //                gridObject = "";
        //                gr = null;
        //            }
        //            int maxLen = 0;

        //            if (MyACE.relTables[arf.ObjectAlias].Count > 0)
        //            {
        //                if (MyACE.relTables[arf.ObjectAlias].Table.Columns.Contains(arf.DBFieldName))
        //                    maxLen = MyACE.relTables[arf.ObjectAlias].Table.Columns[arf.DBFieldName].MaxLength;
        //                if (maxLen == -1)
        //                    maxLen = 0;

        //                if (arf.Visible || MyACE.relTables[arf.ObjectAlias][0].Row.GetColumnError(arf.DBFieldName) != "")
        //                {
        //                    ActivityConfig.ACControlTypeRow ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType(arf.FieldType);

        //                    vis++;
        //                    switch (arf.FieldType)
        //                    {

        //                        case "AG":
        //                            ucSSTAppealGround ucsstag = new ucSSTAppealGround();
        //                            ucsstag.FM = fmCurrent;
        //                            ctl = (Control)ucsstag;
        //                            customBinding = ctlTypeRow.IsCustomBinding;
        //                            break;
        //                        case "CM":
        //                            ucSSTCaseMatter ucsstcm = new ucSSTCaseMatter();
        //                            if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "PROMPT")
        //                            {
        //                                ucsstcm.PromptIssueMode = true;
        //                            }
        //                            if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "SETOUTCOME")
        //                            {
        //                                ucsstcm.IsSettingOutcome = true;
        //                            }
        //                            if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "PROMPTNOISSUE")
        //                            {
        //                                ucsstcm.PromptNoIssueMode = true;
        //                            }
        //                            ucsstcm.DataSource = MyACE.relTables[arf.ObjectAlias];
        //                            ucsstcm.FM = fmCurrent;
        //                            // fmCurrent.GetSSTMng();
        //                            //ucsstcm.Width = 800;
        //                            ctl = (Control)ucsstcm;
        //                            customBinding = ctlTypeRow.IsCustomBinding;
        //                            break;
        //                        case "?F": //browse for file
        //                            ucFileSelectBox ucfsb = new ucFileSelectBox();
        //                            ucfsb.AtMng = fmCurrent.AtMng;

        //                            ucfsb.Width = ctlTypeRow.Width;
        //                            ucfsb.Enabled = !arf.ReadOnly;
        //                            ctl = (Control)ucfsb;
        //                            prop = ctlTypeRow.BindingProp;
        //                            break;
        //                        case "?O": // browse for office
        //                            ucOfficeSelectBox ucosb = new ucOfficeSelectBox();
        //                            ucosb.AtMng = fmCurrent.AtMng;

        //                            ucosb.Width = ctlTypeRow.Width;
        //                            ucosb.Enabled = !arf.ReadOnly;
        //                            ctl = (Control)ucosb;
        //                            prop = ctlTypeRow.BindingProp;
        //                            break;
        //                        case "?I": // browse for issue
        //                            ucIssueSelectBoxRF uciss = new ucIssueSelectBoxRF();
        //                            uciss.FM = fmCurrent;

        //                            uciss.Width = ctlTypeRow.Width;
        //                            uciss.Enabled = !arf.ReadOnly;
        //                            ctl = (Control)uciss;
        //                            prop = ctlTypeRow.BindingProp;
        //                            break;

        //                        case "?C":  //browse for contact
        //                            ucContactSelectBox uccsb = new ucContactSelectBox();
        //                            uccsb.FM = fmCurrent;
        //                            uccsb.WLQuery = WorkloadQuery.NotApplicable;
        //                            uccsb.Width = ctlTypeRow.Width;
        //                            uccsb.Enabled = !arf.ReadOnly;
        //                            ctl = (Control)uccsb;
        //                            prop = ctlTypeRow.BindingProp;
        //                            break;
        //                        case "?W":  //browse for contact - showWorkload
        //                            ucContactSelectBox uccsbw = new ucContactSelectBox();
        //                            uccsbw.FM = fmCurrent;
        //                            uccsbw.Width = ctlTypeRow.Width;
        //                            uccsbw.WLQuery = (WorkloadQuery)Enum.Parse(typeof(WorkloadQuery), arf.SpecialParameter);
        //                            uccsbw.Enabled = !arf.ReadOnly;
        //                            ctl = (Control)uccsbw;
        //                            prop = ctlTypeRow.BindingProp;
        //                            break;
        //                        case "?":
        //                            ucDocUpload ucdu = new ucDocUpload();
        //                            ucdu.DocMng = MyACE.FM.GetDocMng();
        //                            ucdu.Document = (docDB.DocumentRow)MyACE.relTables[arf.ObjectAlias][0].Row;

        //                            ucdu.Width = ctlTypeRow.Width;
        //                            ucdu.Enabled = !arf.ReadOnly;
        //                            ctl = (Control)ucdu;
        //                            prop = "";
        //                            customBinding = ctlTypeRow.IsCustomBinding;
        //                            break;
        //                        case "?D": //browse for doc
        //                            //?
        //                            docDB.DocumentRow newDoc = (docDB.DocumentRow)MyACE.relTables[arf.ObjectAlias][0].Row;
        //                            //newDoc.FileId = FM.CurrentFile.FileId;
        //                            string f = "";
        //                            openFileDialog1.FileName = "";
        //                            if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel)
        //                            {
        //                                if (MessageBox.Show(LawMate.Properties.Resources.ActivityExpectsExternalDocumentToBeUploaded, LawMate.Properties.Resources.NoDocumentSelected, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                                {
        //                                    if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel)
        //                                    {
        //                                        MessageBox.Show(LawMate.Properties.Resources.NewActivityWizardCancelled);

        //                                        buttonCancel.PerformClick();
        //                                    }
        //                                    else
        //                                        f = this.openFileDialog1.FileName;
        //                                }
        //                                else
        //                                {
        //                                    MessageBox.Show(LawMate.Properties.Resources.NewActivityWizardCancelled);
        //                                    buttonCancel.PerformClick();
        //                                }
        //                            }
        //                            else
        //                                f = this.openFileDialog1.FileName;

        //                            if (f != "")
        //                            {
        //                                //try
        //                                //{
        //                                MyACE.FM.GetDocMng().GetDocument().LoadFile(newDoc, f);

        //                                newDoc.icon = UIHelper.GetFileIcon(f);
        //                                //}
        //                                //catch (Exception x)
        //                                //{
        //                                //    UIHelper.HandleUIException(x);
        //                                //    buttonCancel.PerformClick();
        //                                //}
        //                            }
        //                            else
        //                            {
        //                                if (ABP != null && ABP.CurrentACE != null)
        //                                {
        //                                    ABP.CurrentACE.Cancel();
        //                                    ABP.CurrentACE = null;
        //                                }
        //                                return;
        //                            }
        //                            Janus.Windows.GridEX.EditControls.EditBox xrb = new Janus.Windows.GridEX.EditControls.EditBox();
        //                            //TextBox xrb = new TextBox();
        //                            ctl = (Control)xrb;
        //                            //xrb.Text = f;
        //                            xrb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                            xrb.ReadOnly = true;
        //                            xrb.Enabled = false;
        //                            xrb.Width = ctlTypeRow.Width;
        //                            prop = ctlTypeRow.BindingProp;

        //                            break;
        //                        case "CV":

        //                            gr = new Janus.Windows.GridEX.GridEX();

        //                            gridObject = arf.ObjectAlias;

        //                            gr.Width = ctlTypeRow.Width;
        //                            gr.BackColor = Color.FromArgb(219, 235, 255);
        //                            gr.View = Janus.Windows.GridEX.View.CardView;
        //                            gr.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
        //                            gr.AllowCardSizing = false;
        //                            gr.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
        //                            gr.CardViewGridlines = Janus.Windows.GridEX.CardViewGridlines.FieldsOnly;
        //                            gr.CardInnerSpacing = 5;
        //                            gr.AutoEdit = true;
        //                            gr.EnsureVisible();
        //                            gr.CardSpacing = 6;
        //                            gr.CardWidth = 290;
        //                            gr.ExpandableCards = false;

        //                            //if we set tab to navigate columns, the tab key can never tab out of the control.
        //                            //use arrows within grid to navigate, tab to exit control.
        //                            gr.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
        //                            gr.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
        //                            gr.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
        //                            gr.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(gr_CellUpdated);
        //                            //handle height setting in VisibleChanged so we can count total columns.
        //                            gr.VisibleChanged += new EventHandler(gr_VisibleChanged);

        //                            gr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                            gr.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;

        //                            gr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
        //                            gr.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;


        //                            ctl = (Control)gr;
        //                            ctl.Name = arf.ObjectAlias + arf.FieldName;

        //                            flowLayoutPanel1.Controls.Add(ctl);
        //                            flowLayoutPanel1.SetFlowBreak(ctl, true);

        //                            gr.DataSource = MyACE.relTables[arf.ObjectAlias];

        //                            Janus.Windows.GridEX.GridEXTable gt2 = new Janus.Windows.GridEX.GridEXTable();
        //                            gr.RootTable = gt2;
        //                            gr.CardCaptionPrefix = (string)arf[UIHelper.Translate(fmCurrent, "LabelEng")];// LawMate.Properties.Resources.MultipleSelectEdit;
        //                            gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
        //                            gr.RootTable.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;

        //                            string[] columns2 = arf.DBFieldName.Split(',');

        //                            foreach (string s in columns2)
        //                            {
        //                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "hide")
        //                                {
        //                                    //don't add arf as grid column
        //                                }
        //                                else
        //                                {
        //                                    gc = new Janus.Windows.GridEX.GridEXColumn(s, Janus.Windows.GridEX.ColumnType.Text);
        //                                    gc.Caption = gr.RootTable.Caption;
        //                                    gr.RootTable.Columns.Add(gc);
        //                                    gc.Selectable = !arf.ReadOnly;
        //                                }
        //                            }


        //                            break;
        //                        case "M":
        //                            //multi-row so use grid
        //                            gr = new Janus.Windows.GridEX.GridEX();
        //                            gridObject = arf.ObjectAlias;
        //                            gr.Height = 150;
        //                            //gr.Left = 250;
        //                            gr.Width = ctlTypeRow.Width;

        //                            gr.GroupByBoxVisible = false;
        //                            gr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                            gr.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
        //                            gr.GridLines = Janus.Windows.GridEX.GridLines.None;
        //                            gr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
        //                            gr.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
        //                            gr.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
        //                            gr.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
        //                            gr.AutoEdit = true;
        //                            gr.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
        //                            gr.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
        //                            gr.VisibleChanged += new EventHandler(gr_VisibleChanged);
        //                            ctl = (Control)gr;
        //                            ctl.Name = arf.ObjectAlias + arf.FieldName;

        //                            flowLayoutPanel1.Controls.Add(ctl);
        //                            flowLayoutPanel1.SetFlowBreak(ctl, true);

        //                            gr.DataSource = MyACE.relTables[arf.ObjectAlias];

        //                            Janus.Windows.GridEX.GridEXTable gt = new Janus.Windows.GridEX.GridEXTable();
        //                            gr.RootTable = gt;
        //                            if (!arf.IsLabelEngNull())
        //                            {
        //                                gr.RootTable.Caption = (string)arf[UIHelper.Translate(fmCurrent, "LabelEng")];// LawMate.Properties.Resources.MultipleSelectEdit;
        //                                gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;

        //                                //gr.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
        //                                //gr.RootTable.HeaderLines = 3;

        //                                gr.RootTable.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
        //                            }
        //                            else
        //                            {
        //                                gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.False;
        //                            }
        //                            string[] columns = arf.DBFieldName.Split(',');

        //                            foreach (string s in columns)
        //                            {
        //                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "hide")
        //                                {
        //                                    //don't add arf as grid column
        //                                }
        //                                else
        //                                {
        //                                    gc = new Janus.Windows.GridEX.GridEXColumn(s, Janus.Windows.GridEX.ColumnType.Text);
        //                                    //gc.AutoSize();
        //                                    gc.Caption = gr.RootTable.Caption;
        //                                    Graphics grfx2 = CreateGraphics();
        //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 15;
        //                                    if (gc.Width < 80)
        //                                        gc.Width = 80;

        //                                    gr.RootTable.Columns.Add(gc);
        //                                    gc.Selectable = !arf.ReadOnly;
        //                                }
        //                            }
        //                            break;

        //                        case "A":    //Calendar Combo
        //                            if (gr == null)
        //                            {
        //                                Janus.Windows.CalendarCombo.CalendarCombo jcb = new Janus.Windows.CalendarCombo.CalendarCombo();
        //                                ctl = (Control)jcb;
        //                                prop = ctlTypeRow.BindingProp;
        //                                jcb.Width = ctlTypeRow.Width;
        //                                jcb.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
        //                                jcb.CustomFormat = "yyyy'/'MM'/'dd";
        //                                jcb.Text = "";
        //                                jcb.ReadOnly = arf.ReadOnly;
        //                                jcb.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
        //                                if (arf.ReadOnly)
        //                                {
        //                                    jcb.BackColor = SystemColors.Control;
        //                                    jcb.ForeColor = SystemColors.ControlDark;
        //                                }
        //                                if (arf.Required)
        //                                {
        //                                    jcb.ShowNullButton = false;
        //                                    jcb.Nullable = false;
        //                                }
        //                                else
        //                                {
        //                                    jcb.ShowNullButton = true;
        //                                    jcb.Nullable = true;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                gc.EditType = Janus.Windows.GridEX.EditType.CalendarCombo;
        //                                if (arf.Required)
        //                                    gc.CalendarNoneButtonVisible = Janus.Windows.GridEX.TriState.False;
        //                                else
        //                                    gc.CalendarNoneButtonVisible = Janus.Windows.GridEX.TriState.True;

        //                                gc.FormatString = "yyyy'/'MM'/'dd";
        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
        //                                if (gc.Width < 100)
        //                                    gc.Width = 100;
        //                                //gc.AutoSize();
        //                                gr.RootTable.Columns.Add(gc);
        //                                gc.Selectable = !arf.ReadOnly;
        //                            }
        //                            break;
        //                        //case "AR":    //Calendar Combo - Read Only
        //                        //    Janus.Windows.CalendarCombo.CalendarCombo jcbro = new Janus.Windows.CalendarCombo.CalendarCombo();
        //                        //    ctl = (Control)jcbro;
        //                        //    prop = "BindableValue";
        //                        //    jcbro.Enabled = false;
        //                        //    jcbro.Width = 100;
        //                        //    jc
        //                        //    jcbro.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
        //                        //    jcbro.CustomFormat = "yyyy'/'MM'/'dd";
        //                        //    break;
        //                        //case "Q":   //prompt drop down
        //                        //    ComboBox cbq = new ComboBox();
        //                        //    ctl = (Control)cbq;
        //                        //    prop = "SelectedValue";
        //                        //    cbq.DropDownStyle = ComboBoxStyle.DropDownList;
        //                        //    cbq.Width = 400;
        //                        //    cbq.Enabled = !arf.ReadOnly;
        //                        //    //need to set list LawMate.Properties

        //                        //    cbq.ValueMember = "id";
        //                        //    cbq.DisplayMember = "prompt";
        //                        //    cbq.DataSource = MyACE.Prompts[arf.LookUp];
        //                        //    break;
        //                        case "C":   //Enabled Dropdown
        //                            Janus.Windows.EditControls.UIComboBox cb = new Janus.Windows.EditControls.UIComboBox();
        //                            //ComboBox cb = new ComboBox();
        //                            ctl = (Control)cb;
        //                            prop = ctlTypeRow.BindingProp;
        //                            cb.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList; //.DropDownStyle = ComboBoxStyle.DropDownList;
        //                            cb.Width = ctlTypeRow.Width;
        //                            cb.Enabled = !arf.ReadOnly;
        //                            cb.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
        //                            //need to set list LawMate.Properties
        //                            DataTable dt = MyACE.FM.Codes(arf.LookUp);
        //                            cb.ValueMember = dt.PrimaryKey[0].ColumnName;// dt.Columns[0].ColumnName;
        //                            cb.DisplayMember = dt.Columns[UIHelper.Translate(fmCurrent, dt.Columns[1].ColumnName)].ColumnName;
        //                            cb.DataSource = new DataView(dt);
        //                            break;

        //                        case "T":   //Multiline Textbox
        //                            //  TextBox tb = new TextBox();
        //                            Janus.Windows.GridEX.EditControls.EditBox tb = new Janus.Windows.GridEX.EditControls.EditBox();
        //                            ctl = (Control)tb;
        //                            tb.Multiline = true;
        //                            tb.AcceptsReturn = true;
        //                            tb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                            tb.ScrollBars = ScrollBars.Vertical;
        //                            tb.Height = 65;
        //                            tb.Width = ctlTypeRow.Width;
        //                            tb.ReadOnly = arf.ReadOnly;
        //                            if (arf.ReadOnly)
        //                            {
        //                                tb.BackColor = SystemColors.ControlLight;
        //                                tb.ForeColor = SystemColors.ControlDark;
        //                            }
        //                            tb.MaxLength = maxLen;

        //                            prop = ctlTypeRow.BindingProp;
        //                            break;
        //                        case "MC":
        //                            if (gr == null)
        //                            {
        //                                UserControls.ucMultiDropDown mdd = new UserControls.ucMultiDropDown();
        //                                mdd.Width = ctlTypeRow.Width;
        //                                ctl = (Control)mdd;
        //                                mdd.BackColor = System.Drawing.Color.Transparent;
        //                                prop = ctlTypeRow.BindingProp;

        //                                DataTable dt2 = MyACE.FM.Codes(arf.LookUp);
        //                                string luv = arf.LookUp.ToUpper();

        //                                if (luv == "VLAWYERLIST" || luv == "LAWYERLIST" || luv == "OFFICERLIST" || luv == "VOFFICERLIST" || luv == "VOFFICERGDLIST" || luv == "VMEMBERLIST")
        //                                {
        //                                    mdd.Middle = 353;
        //                                    mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
        //                                    mdd.DisplayMember = dt2.Columns["fullname"].ColumnName;
        //                                    mdd.Column1 = dt2.Columns["fullname"].ColumnName;
        //                                    mdd.DropDownColumn1Width = 200;
        //                                    mdd.DropDownColumn2Width = 200;
        //                                    mdd.Column2 = dt2.Columns[UIHelper.Translate(fmCurrent, dt2.Columns[2].ColumnName)].ColumnName;
        //                                }
        //                                else
        //                                {
        //                                    mdd.Middle = 353;
        //                                    mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
        //                                    mdd.DisplayMember = dt2.Columns[UIHelper.Translate(fmCurrent, dt2.Columns[1].ColumnName)].ColumnName;
        //                                    mdd.Column1 = dt2.Columns[0].ColumnName;
        //                                    if (dt2.Columns[0].DataType == typeof(Int32))
        //                                    {
        //                                        mdd.DDColumn1Visible = false;
        //                                        mdd.DropDownColumn2Width = mdd.Width;
        //                                    }
        //                                    mdd.Column2 = dt2.Columns[UIHelper.Translate(fmCurrent, dt2.Columns[1].ColumnName)].ColumnName;
        //                                }
        //                                mdd.Enabled = !arf.ReadOnly;
        //                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter=="filter")
        //                                {
        //                                    DataView dv = new DataView(dt2, arf.DefaultValue + "=" + MyACE.relTables[arf.DefaultObjectName][0][arf.DefaultFieldName].ToString(), "", DataViewRowState.CurrentRows);
        //                                    mdd.SetDataBinding(dv, "");
        //                                }
        //                                else
        //                                {
        //                                    mdd.SetDataBinding(dt2, "");

        //                                }
        //                                if (!arf.Required)
        //                                    mdd.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
        //                            }
        //                            else
        //                            {

        //                                DataTable dt3 = MyACE.FM.Codes(arf.LookUp);
        //                                Janus.Windows.GridEX.GridEXDropDown grdDD = gr.DropDowns.Add("dd" + arf.LookUp);

        //                                grdDD.ValueMember = dt3.PrimaryKey[0].ColumnName;
        //                                grdDD.DisplayMember = dt3.Columns[UIHelper.Translate(fmCurrent, dt3.Columns[1].ColumnName)].ColumnName;
        //                                grdDD.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
        //                                grdDD.Columns.Add(grdDD.DisplayMember, Janus.Windows.GridEX.ColumnType.Text);

        //                                gr.DropDowns["dd" + arf.LookUp].SetDataBinding(dt3, "");
        //                                // gr.DropDowns.Add(grdDD);

        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                gc.EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;

        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
        //                                if (gc.Width < 100)
        //                                    gc.Width = 100;
        //                                //gc.AutoSize();

        //                                gr.RootTable.Columns.Add(gc);
        //                                gc.DropDown = gr.DropDowns["dd" + arf.LookUp];
        //                                gc.Selectable = !arf.ReadOnly;
        //                            }
        //                            break;
        //                        case "AD":
        //                            UserControls.ucAddress ucadd = new UserControls.ucAddress();
        //                            ctl = (Control)ucadd;
        //                            ucadd.ColumnTwoLeftPositionOffset = LBLWIDTH - 85;
        //                            ucadd.Width = ctlTypeRow.Width;
        //                            ucadd.DataSource = MyACE.relTables[arf.ObjectAlias];
        //                            ucadd.Enabled = !arf.ReadOnly;
        //                            ucadd.FM = fmCurrent;
        //                            customBinding = ctlTypeRow.IsCustomBinding;
        //                            break;
        //                        //case "SN":
        //                        //    Janus.Windows.GridEX.EditControls.MaskedEditBox meb = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
        //                        //    prop = "Text";
        //                        //    meb.IncludeLiterals = false;
        //                        //    meb.Width = 400;
        //                        //    meb.Mask = "### ### ###";
        //                        //    meb.PromptChar = ' ';
        //                        //    meb.Text = "";
        //                        //    meb.ReadOnly = arf.ReadOnly;
        //                        //    ctl = (Control)meb;
        //                        //    break;
        //                        case "B": //Currency Field
        //                            if (gr == null)
        //                            {
        //                                Janus.Windows.GridEX.EditControls.NumericEditBox neb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
        //                                ctl = (Control)neb;
        //                                neb.Width = ctlTypeRow.Width;
        //                                neb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
        //                                neb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
        //                                neb.ReadOnly = arf.ReadOnly;
        //                                neb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                                if (arf.ReadOnly)
        //                                {
        //                                    neb.BackColor = SystemColors.ControlLight;
        //                                    neb.ForeColor = SystemColors.ControlDark;
        //                                }
        //                                prop = ctlTypeRow.BindingProp;
        //                            }
        //                            else
        //                            {
        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
        //                                gc.FormatString = "c";
        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                gc.InputMask = "Currency";
        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
        //                                if (gc.Width < 100)
        //                                    gc.Width = 100;
        //                                //gc.AutoSize();
        //                                gr.RootTable.Columns.Add(gc);

        //                                gc.Selectable = !arf.ReadOnly;
        //                            }

        //                            break;
        //                        case "IM":
        //                            if (gr == null)
        //                            {
        //                            }
        //                            else
        //                            {
        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.BoundImage);

        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                gc.CellStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center;


        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
        //                                if (gc.Width < 100)
        //                                    gc.Width = 100;
        //                                //gc.AutoSize();
        //                                gr.RootTable.Columns.Add(gc);
        //                                gc.Selectable = !arf.ReadOnly;
        //                            }
        //                            break;
        //                        case "N": //number Field
        //                            if (gr == null)
        //                            {
        //                                Janus.Windows.GridEX.EditControls.NumericEditBox neb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
        //                                ctl = (Control)neb;
        //                                neb.Width = ctlTypeRow.Width;
        //                                neb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
        //                                neb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
        //                                neb.ReadOnly = arf.ReadOnly;
        //                                neb.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
        //                                neb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                                if (arf.ReadOnly)
        //                                {
        //                                    neb.BackColor = SystemColors.ControlLight;
        //                                    neb.ForeColor = SystemColors.ControlDark;
        //                                }
        //                                prop = ctlTypeRow.BindingProp;
        //                            }
        //                            else
        //                            {
        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);

        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                //gc.InputMask = "Percent";

        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
        //                                if (gc.Width < 100)
        //                                    gc.Width = 100;
        //                                //gc.AutoSize();
        //                                gr.RootTable.Columns.Add(gc);
        //                                gc.Selectable = !arf.ReadOnly;
        //                            }
        //                            break;
        //                        case "P": //Percent Field
        //                            if (gr == null)
        //                            {
        //                                Janus.Windows.GridEX.EditControls.NumericEditBox peb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
        //                                ctl = (Control)peb;
        //                                peb.Width = ctlTypeRow.Width;
        //                                peb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent;
        //                                peb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
        //                                peb.FormatString = "##0.000 %";
        //                                peb.ReadOnly = arf.ReadOnly;
        //                                peb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                                if (arf.ReadOnly)
        //                                {
        //                                    peb.BackColor = SystemColors.ControlLight;
        //                                    peb.ForeColor = SystemColors.ControlDark;
        //                                }
        //                                prop = ctlTypeRow.BindingProp;
        //                            }
        //                            else
        //                            {
        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
        //                                gc.FormatString = "#0.000 %";
        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                //gc.InputMask = "Percent";

        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
        //                                if (gc.Width < 100)
        //                                    gc.Width = 100;
        //                                //gc.AutoSize();
        //                                gr.RootTable.Columns.Add(gc);
        //                                gc.Selectable = !arf.ReadOnly;
        //                            }
        //                            break;
        //                        //case "R": //Read-only Textbox
        //                        //    TextBox rb = new TextBox();
        //                        //    ctl = (Control)rb;
        //                        //    rb.ReadOnly = true;
        //                        //    rb.Width = 400;
        //                        //    prop = "Text";
        //                        //    break;

        //                        //case "Y": //Disabled Checkbox
        //                        //    CheckBox yb = new CheckBox();
        //                        //    ctl = (Control)yb;
        //                        //    yb.Enabled = false;
        //                        //    prop = "Checked";
        //                        //    break;

        //                        case "XW":
        //                        case "X": // Checkbox
        //                            if (gr == null)
        //                            {
        //                                Janus.Windows.EditControls.UICheckBox xb = new Janus.Windows.EditControls.UICheckBox();
        //                                //CheckBox xb = new CheckBox();
        //                                ctl = (Control)xb;
        //                                prop = ctlTypeRow.BindingProp;
        //                                if (!arf.IsLookUpNull())
        //                                {
        //                                    prop = "BindableValue";
        //                                    xb.ThreeState = false;
        //                                    xb.UncheckedValue = System.DBNull.Value;
        //                                    // value will be the first value in the lookup list
        //                                    xb.CheckedValue = arf.SpecialParameter;
        //                                }
        //                                xb.Enabled = !arf.ReadOnly;
        //                                xb.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
        //                            }
        //                            else
        //                            {

        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.CheckBox);
        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
        //                                if (gc.Width < 100)
        //                                    gc.Width = 100;
        //                                //gc.AutoSize();
        //                                gr.RootTable.Columns.Add(gc);
        //                                gc.Selectable = !arf.ReadOnly;
        //                            }
        //                            break;
        //                        case "LB":
        //                            Label lb1 = new Label();
        //                            lb1.BackColor = System.Drawing.Color.Transparent;
        //                            lb1.AutoEllipsis = true;
        //                            lb1.Width = ctlTypeRow.Width;
        //                            lb1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
        //                            lb1.MinimumSize = lb1.Size;
        //                            lb1.MaximumSize = new System.Drawing.Size(lb1.Width, 20 * lb1.Height);
        //                            lb1.AutoSize = true;
        //                            lb1.Text = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                            if (!arf.IsSpecialParameterNull())
        //                            {
        //                                var cvt = new FontConverter();
        //                                //        string s = cvt.ConvertToString(this.Font);
        //                                Font fnt = cvt.ConvertFromInvariantString(arf.SpecialParameter) as Font;

        //                                lb1.Font = fnt;
        //                                lb1.Height = lb1.PreferredHeight;
        //                            }
        //                            customBinding = ctlTypeRow.IsCustomBinding;

        //                            ctl = (Control)lb1;
        //                            break;
        //                        case "TB":
        //                        case "ST":
        //                        case "MT":
        //                        default:   //text box
        //                            ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType(arf.FieldType);
        //                            if (ctlTypeRow == null)
        //                                ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType("TB");
        //                            if (gr == null)
        //                            {
        //                                Janus.Windows.GridEX.EditControls.MaskedEditBox txt = new Janus.Windows.GridEX.EditControls.MaskedEditBox();

        //                                txt.Width = ctlTypeRow.Width;
        //                                txt.ReadOnly = arf.ReadOnly;
        //                                txt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
        //                                if (arf.ReadOnly)
        //                                {
        //                                    txt.ForeColor = SystemColors.ControlDark;
        //                                    txt.BackColor = SystemColors.ControlLight;
        //                                }
        //                                if (!arf.IsMaskNull() && arf.Mask.Length > 0)
        //                                {
        //                                    txt.CharacterCasing = CharacterCasing.Upper;
        //                                    txt.IncludeLiterals = false;
        //                                    if (arf.Mask == "PHONE")
        //                                    {
        //                                        if (MyACE.relTables.ContainsKey("Address0"))
        //                                        {
        //                                            arf.Mask = fmCurrent.GetAddress().PhoneMask((atriumDB.AddressRow)MyACE.relTables["Address0"][0].Row);
        //                                        }
        //                                        else
        //                                        {
        //                                            arf.Mask = "";
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        txt.Mask = arf.Mask;
        //                                    }
        //                                }
        //                                txt.MaxLength = maxLen;
        //                                ctl = (Control)txt;
        //                                prop = ctlTypeRow.BindingProp;
        //                            }
        //                            else
        //                            {
        //                                gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
        //                                gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                gr.RootTable.Columns.Add(gc);
        //                                gc.MaxLength = maxLen;
        //                                Graphics grfx2 = CreateGraphics();
        //                                gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 15;
        //                                if (gc.Width < 80)
        //                                    gc.Width = 80;
        //                                //gc.Width = 100;
        //                                gc.Selectable = !arf.ReadOnly;
        //                                if (arf.ReadOnly && gr.View == Janus.Windows.GridEX.View.CardView)
        //                                {
        //                                    gc.CellStyle.BackColor = SystemColors.ControlLight;
        //                                    gc.CellStyle.ForeColor = SystemColors.ControlDark;
        //                                }

        //                            }
        //                            break;
        //                    } //end switch (arf.FieldType)
        //                    if (gr != null)
        //                    {
        //                        if (arf.Required && !arf.ReadOnly)
        //                        {
        //                            if (arf.TaskType != "P")
        //                            {
        //                                Janus.Windows.GridEX.GridEXFormatCondition fc = new Janus.Windows.GridEX.GridEXFormatCondition(gr.RootTable.Columns[arf.DBFieldName], Janus.Windows.GridEX.ConditionOperator.IsNull, null);
        //                                fc.FormatStyle.BackColor = Color.Pink;
        //                                //    string[] scols = arf.FieldName.Split(',');
        //                                fc.TargetColumn = gr.RootTable.Columns[arf.DBFieldName];
        //                                gr.RootTable.FormatConditions.Add(fc);
        //                                gr.RootTable.Columns[arf.DBFieldName].Caption += "*";

        //                                gr.CellEdited += new Janus.Windows.GridEX.ColumnActionEventHandler(gr_CellEdited);

        //                                foreach (DataRowView dr in MyACE.relTables[arf.ObjectAlias])
        //                                {
        //                                    if (dr.Row.IsNull(arf.DBFieldName))
        //                                    {
        //                                        required.Add(dr.Row[dr.Row.Table.PrimaryKey[0]].ToString() + "_" + arf.DBFieldName);
        //                                    }
        //                                }
        //                            }
        //                        }


        //                    }
        //                    else if (gr == null)
        //                    {
        //                        Label lb = new Label();
        //                        if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "NOLABEL")
        //                        {
        //                            lb.Visible = false;
        //                            lb.Width = 0;
        //                            ctl.Width = ctl.Width + LBLWIDTH + 6;
        //                            if (arf.FieldType == "MC")
        //                            {
        //                                UserControls.ucMultiDropDown mdd = (UserControls.ucMultiDropDown)ctl;
        //                                mdd.Middle = ctl.Width + 3;
        //                                if (!mdd.DDColumn1Visible)
        //                                    mdd.DropDownColumn2Width = ctl.Width;
        //                            }
        //                        }
        //                        else if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "2LINE")
        //                        {
        //                            lb.Width = LBLWIDTH + 350;
        //                            lb.AutoEllipsis = true;
        //                            lb.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
        //                            ctl.Width = ctl.Width + LBLWIDTH + 6;
        //                            if (arf.FieldType == "MC")
        //                            {
        //                                UserControls.ucMultiDropDown mdd = (UserControls.ucMultiDropDown)ctl;
        //                                mdd.Middle = ctl.Width + 3;
        //                                if (!mdd.DDColumn1Visible)
        //                                    mdd.DropDownColumn2Width = ctl.Width;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (arf.FieldType == "XW")
        //                            {
        //                                lb.Width = LBLWIDTH + 350 - 14;
        //                                lb.MinimumSize = lb.Size;
        //                                lb.MaximumSize =new System.Drawing.Size( lb.Width,lb.Height*8);
        //                                lb.AutoSize = true;
        //                            }
        //                            else
        //                                lb.Width = LBLWIDTH;
        //                            lb.AutoEllipsis = true;
        //                            lb.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

        //                        }
        //                        lb.Name = "lbl" + arf.ObjectAlias + arf.FieldName;

        //                        if (!arf.IsSpecialParameterNull() && arf.SpecialParameter != "NOLABEL" && arf.SpecialParameter != "2LINE" && arf.SpecialParameter.ToLower() != "hide")
        //                        {
        //                            var cvt = new FontConverter();
        //                            //        string s = cvt.ConvertToString(this.Font);
        //                            if (cvt.IsValid(arf.SpecialParameter))
        //                            {
        //                                Font fnt = cvt.ConvertFromInvariantString(arf.SpecialParameter) as Font;

        //                                lb.Font = fnt;
        //                                lb.Height = lb.PreferredHeight;
        //                            }
        //                        }
        //                        if (arf.FieldType != "AD" && arf.FieldType != "CM" && arf.FieldType != "?I" && arf.FieldType != "LB")
        //                        {
        //                            if (arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() != "")
        //                            {
        //                                flowLayoutPanel1.Controls.Add(lb);
        //                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "2LINE")
        //                                {
        //                                    flowLayoutPanel1.SetFlowBreak(lb, true);
        //                                }
        //                            }

        //                        }

        //                        if (!customBinding)
        //                            ctl.DataBindings.Add(prop, MyACE.relTables[arf.ObjectAlias], arf.DBFieldName);

        //                        if (arf.Required & !arf.ReadOnly && arf.FieldType != "LB")
        //                        {
        //                            if (arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() == "")
        //                                lb.Text = "";
        //                            else
        //                                lb.Text = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() + "*:";
        //                            if (MyACE.relTables[arf.ObjectAlias][0][arf.DBFieldName].ToString() == "" || customBinding)
        //                            {

        //                                UserControls.IRequiredCtl ireq = ctl as UserControls.IRequiredCtl;
        //                                if (ireq == null)
        //                                {
        //                                    if (ctl.Text == "")
        //                                    {
        //                                        ctl.BackColor = Color.Pink;
        //                                        required.Add(ctl);

        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (!ireq.IsPopulated)
        //                                    {
        //                                        if (requiresAction == null)
        //                                            requiresAction = ireq;


        //                                        ireq.ReqColor = Color.Pink;
        //                                        required.Add(ctl);


        //                                    }
        //                                }

        //                            }

        //                            ctl.Validated += new EventHandler(ctl_Validated);
        //                            ctl.TextChanged += new EventHandler(ctl_TextChanged);

        //                        }
        //                        else
        //                            lb.Text = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() + ":";

        //                        ctl.Name = arf.ObjectAlias + arf.FieldName;
        //                        //if (arf.Visible)
        //                        //{
        //                        flowLayoutPanel1.Controls.Add(ctl);

        //                        if (arf.FieldType != "LB")
        //                        {
        //                            Label helpLbl = new Label();
        //                            helpLbl.Width = 24;
        //                            helpLbl.Margin = new Padding(0);
        //                            janusSuperTip1.ClearToolTipArea();

        //                            if (!arf.IsNull(UIHelper.Translate(fmCurrent, "HelpE")))
        //                            {
        //                                helpLbl.Image = LawMate.Properties.Resources.help;
        //                                Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();
        //                                //      jstSettings.HeaderText = "Help About " + arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
        //                                jstSettings.Text = arf[UIHelper.Translate(fmCurrent, "HelpE")].ToString();
        //                                //      jstSettings.HeaderImage = LawMate.Properties.Resources.help;
        //                                janusSuperTip1.SetSuperTip(helpLbl, jstSettings);
        //                                //flowLayoutPanel1.Controls.Add(helpLbl);

        //                            }
        //                            flowLayoutPanel1.Controls.Add(helpLbl);
        //                            flowLayoutPanel1.SetFlowBreak(helpLbl, true);
        //                        }
        //                        else
        //                        {
        //                            flowLayoutPanel1.SetFlowBreak(ctl, true);
        //                        }
        //                        if (arf.Visible & !arf.ReadOnly && firstCtl == null)
        //                            firstCtl = ctl;

        //                        //can't proceed because error in hidden field
        //                        if (arf.ReadOnly & !arf.Visible)
        //                        {
        //                            buttonNext.Enabled = false;
        //                            Label stopLbl = new Label();
        //                            stopLbl.AutoSize = true;
        //                            stopLbl.Text = LawMate.Properties.Resources.ThereIsAnErrorInAReadOnlyHiddenRelatedField;
        //                            flowLayoutPanel1.Controls.Add(stopLbl);
        //                            flowLayoutPanel1.SetFlowBreak(stopLbl, true);
        //                        }
        //                        //}

        //                    }
        //                }
        //            }
        //        }


        //        if (required.Count > 0)
        //            buttonNext.Enabled = false;
        //    }
        //    //skip step
        //    if (vis == 0)
        //    {
        //        skipping = true;
        //        if (buttonBack.Focused)
        //        {
        //            this.InvokeOnClick(buttonBack, new EventArgs());
        //            //                        CurrentStep = Back();
        //        }
        //        else
        //        {
        //            this.InvokeOnClick(buttonNext, new EventArgs());
        //            // CurrentStep = Next();
        //        }
        //    }
        //    else
        //    {
        //        //if (requiresAction != null)
        //        //    requiresAction.RequiredAction();

        //        if (firstCtl != null)
        //            firstCtl.Focus();
        //    }

        //    //}
        //    //catch (Exception x)
        //    //{
        //    //    UIHelper.HandleUIException(x);
        //    //}


        //    //Application.OpenForms[0].Activate();
        //    //this.Activate();
        //}



        //void gr_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        //{
        //    //handling of endedit for grid cardview when a change is made to a cell
        //    //in order to force calculations to update right away
        //    try
        //    {
        //        e.Column.GridEX.UpdateData();
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }

        //}

        //void gr_VisibleChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
        //        if (g.RootTable != null)
        //        {
        //            int columnCount = g.RootTable.Columns.Count;
        //            if (g.View == Janus.Windows.GridEX.View.CardView)
        //            { // CARD VIEW
        //                g.Height = columnCount * 25 + 58;

        //            }
        //            else
        //            {
        //                //TABLE VIEW

        //                //CALCULATE HEIGHT
        //                g.Height = g.GetDataRows().Length * 19 + 42 + 32;

        //                //CALCULATE WIDTH
        //                int width = 20;
        //                foreach (Janus.Windows.GridEX.GridEXColumn gec in g.RootTable.Columns)
        //                {
        //                    if (gec.DropDown != null)
        //                    {

        //                        gec.DropDown.Columns[0].AutoSize();
        //                        if (gec.DropDown.Columns[0].Width > 500)
        //                            gec.Width = 500;
        //                        else
        //                            gec.Width = gec.DropDown.Columns[0].Width;

        //                    }
        //                    else
        //                    {
        //                        gec.AutoSize();

        //                    }
        //                    width += gec.Width;
        //                }
        //                g.Width = width;
        //            }

        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        //void gr_CellEdited(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        //{
        //    try
        //    {
        //        Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
        //        DataRowView dvr = (DataRowView)g.CurrentRow.DataRow;
        //        DataRow dr = dvr.Row;
        //        string skey = dr[dr.Table.PrimaryKey[0]].ToString() + "_" + e.Column.Key;

        //        if (g.CurrentRow.Cells[e.Column].Text != "")
        //        {

        //            if (required.Contains(skey))
        //                required.Remove(skey);
        //        }
        //        else
        //        {

        //            if (!required.Contains(skey))
        //                required.Add(skey);
        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        System.Diagnostics.Debug.WriteLine(e.ToString());
        //    }
        //    EnableButtons(); ;
        //}


        //void ValidateControl(object sender, EventArgs e)
        //{
        //    Control ctl = (Control)sender;
        //    UserControls.IRequiredCtl ireq = ctl as UserControls.IRequiredCtl;
        //    bool ok = false;
        //    if (ireq == null)
        //    {
        //        if (ctl.Text != "")
        //        {
        //            ctl.BackColor = Color.White;
        //            ok = true;
        //        }
        //        else
        //        {
        //            ctl.BackColor = Color.Pink;
        //            ok = false;
        //        }

        //    }
        //    else
        //    {
        //        if (ireq.IsPopulated)
        //        {
        //            ireq.ReqColor = Color.White;
        //            ok = true;
        //        }
        //        else
        //        {
        //            ireq.ReqColor = Color.Pink;
        //            ok = false;
        //        }

        //    }
        //    if (ok)
        //    {
        //        if (required.Contains(ctl))
        //            required.Remove(ctl);

        //    }
        //    else
        //    {
        //        if (!required.Contains(ctl))
        //            required.Add(ctl);
        //    }
        //    EnableButtons();

        //}

        //void ctl_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ValidateControl(sender, e);
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        //void ctl_Validated(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ValidateControl(sender, e);
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        private bool DoBFStepIfReq()
        {
            //TFS#51627 CJW 2013-08-30 added the test to see if the BF panel is loaded
            if (!completedSteps.Contains(ACEngine.Step.BFs))
            {
                //always caluclate if we haven't displayed the BF panel
                fmCurrent.GetActivity().CalculateBF(MyACE.NewActivity, false, false);
                completedSteps.Add(ACEngine.Step.BFs);

                //only display if it is in the panel sequence
                if (Seq.Contains(ACEngine.Step.BFs))
                {
                    Janus.Windows.GridEX.GridEXFilterCondition filc = new Janus.Windows.GridEX.GridEXFilterCondition();
                    Janus.Windows.GridEX.GridEXFormatCondition fc = new Janus.Windows.GridEX.GridEXFormatCondition();
                    filc.Column = activityBFGridEX.RootTable.Columns["BFDate"];
                    filc.Value1 = DateTime.Today;
                    filc.ConditionOperator = Janus.Windows.GridEX.ConditionOperator.LessThan;
                    fc.FilterCondition = filc;
                    fc.FormatStyle.BackColor = Color.Yellow;
                    fc.FormatStyle.ForeColor = Color.Red;
                    fc.FormatStyle.FontItalic = Janus.Windows.GridEX.TriState.True;
                    activityBFGridEX.RootTable.FormatConditions.Add(fc);

                    foreach (atriumDB.ActivityBFRow abr in MyACE.NewActivity.GetActivityBFRows())
                    {
                        if (abr.BFDate < DateTime.Today)
                        {
                            CurrentStep = ACEngine.Step.BFs;
                            return true;
                        }
                    }
                }
            }
            return false;

        }

        private bool HasErrors()
        {
            if (fmCurrent.DB.HasErrors)
            {

                return true;
            }
            else if (fmCurrent.GetSSTMng().DB.HasErrors)
            {
                return true;
            }
            else if (fmCurrent.GetDocMng().DB.HasErrors)
            {
                return true;
            }
            else if (fmCurrent.GetAdvisoryMng().DB.HasErrors)
            {
                return true;
            }
            else if (fmCurrent.LeadOfficeMng.DB.HasErrors)
            {
                return true;
            }
            return false;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!Seq.Contains(ACEngine.Step.Confirm))
                DoAcInfo();

            CurrentStep = ACEngine.Step.Confirm;
            //   Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
            using (fWait fw = new fWait(LawMate.Properties.Resources.waitLoading))
            {


                if (myRF != null && myRF.required.Count > 0)
                    return;
                if (DoBFStepIfReq())
                    return;

                if (CurrentStep == ACEngine.Step.Document && ucDoc1.EditMode == UserControls.ucDoc.EditModeEnum.Compose && ucDoc1.DocRecord.isLawmail && ucDoc1.ToPersonIsNullOnCompose)
                    return;

                bool hasError = false;
                foreach (atLogic.BEManager be in fmCurrent.MyMngrs.Values)
                {
                    if (be.MyDS.HasErrors)
                    {
                        hasError = true;
                        UIHelper.TableHasErrorsOnSaveMessBox(be.MyDS);
                        break;
                    }
                }
                //if (fmCurrent.DB.HasErrors)
                //{

                //    UIHelper.TableHasErrorsOnSaveMessBox(fmCurrent.DB);
                //}
                //else if (fmCurrent.GetSSTMng().DB.HasErrors)
                //{
                //    UIHelper.TableHasErrorsOnSaveMessBox(fmCurrent.GetSSTMng().DB);
                //}
                //else if (fmCurrent.GetDocMng().DB.HasErrors)
                //{
                //    UIHelper.TableHasErrorsOnSaveMessBox(fmCurrent.GetDocMng().DB);
                //}
                //else if (fmCurrent.GetAdvisoryMng().DB.HasErrors)
                //{
                //    UIHelper.TableHasErrorsOnSaveMessBox(fmCurrent.GetAdvisoryMng().DB);
                //}
                //else if (fmCurrent.LeadOfficeMng.DB.HasErrors)
                //{
                //    UIHelper.TableHasErrorsOnSaveMessBox(fmCurrent.LeadOfficeMng.DB);
                //}

                if (!hasError)
                {
                    try
                    {
                        if (!completedSteps.Contains(ACEngine.Step.Billing))
                        {
                            MyACE.DoStep(ACEngine.Step.Billing, true);
                            RecordHoursFromTimer();

                            completedSteps.Add(ACEngine.Step.Billing);
                        }

                        // string currentMsg = null;
                        //if (!MyACE.NewActivity.IsDocIdNull() && CurrentMailDoc().DocContentRow.Ext != ".rtf")
                        //{
                        //    string tmpExt = CurrentMailDoc().DocContentRow.Ext;
                        //    ucDoc1.SaveAs(".rtf");
                        //    currentMsg = CurrentMailDoc().DocContentRow.ContentsAsText;
                        //    ucDoc1.SaveAs(tmpExt);
                        //}
                        //workaround for large rtf files from templates
                        if (!MyACE.NewActivity.IsDocIdNull() && !CurrentMailDoc().IsTemplateIdNull() && CurrentMailDoc().DocContentRow.Ext.ToLower() == ".rtf")
                        {
                            ucDoc1.EndEdit();

                            //currentMsg = CurrentMailDoc().DocContentRow.ContentsAsText;
                            if (fmCurrent.GetDocMng().GetDocument().SendByMail(CurrentMailDoc())[0] && CurrentMailDoc().DocContentRow.ContentsAsText.Length > 5000000)
                            {
                                if (MessageBox.Show(String.Format(LawMate.Properties.Resources.ThisMessageIsTooLargeToSendByEmailI, CurrentMailDoc().DocContentRow.ContentsAsText.Length, Atmng.AppMan.AppName), LawMate.Properties.Resources.SizeWarning, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                    return;
                            }
                            ucDoc1.SaveAs(Atmng.GetSetting(AppStringSetting.EmailSaveFormat));
                        }
                        else if (!MyACE.NewActivity.IsDocIdNull() && !CurrentMailDoc().IsSaveAsExtNull())
                        {
                            ucDoc1.SaveAs(CurrentMailDoc().SaveAsExt);
                        }

                        btnSuspendActivity.Enabled = false;
                        timAutosave.Enabled = false;

                        string saveFile = Suspend();

                        bool encrypt = false;
                        int mailImportance = 0;
                        if (!MyACE.NewActivity.IsDocIdNull())
                        {
                            encrypt = CurrentMailDoc().EncryptionRequired;
                            if(!CurrentMailDoc().IsMailImportanceNull())
                                mailImportance = CurrentMailDoc().MailImportance;
                        }
                        //fill ctx if present with user input
                        if (ctx != null)
                        {
                            foreach (ActivityConfig.ActivityFieldRow afr in MyACE.myAcSeries.GetActivityFieldRows())
                            {
                                if (afr.TaskType == "F" & afr.Visible & !afr.ReadOnly & afr.IsDefaultObjectNameNull() & (afr.IsDefaultValueNull() || !afr.DefaultValue.StartsWith("[")))
                                {
                                    ctx[afr.ObjectAlias + afr.FieldName] = MyACE.relTables[afr.ObjectAlias][0][afr.FieldName];
                                }
                            }
                        }
                        MyACE.Save(true, false);

                        try
                        {

                            if (chkFileShortcut.Checked)
                            {

                                FileManager fmDest = Atmng.GetFile(fscDest.FileId);
                                atriumDB.FileXRefRow fxr = (atriumDB.FileXRefRow)fmDest.GetFileXRef().Add(fmDest.CurrentFile);
                                fxr.LinkType = (int)FXLinkType.Shortcut;
                                fxr.OtherFileId = fmCurrent.CurrentFile.FileId;
                                if (fxr.HasErrors)
                                {
                                    string msg = fxr.GetColumnError("OtherFileId");
                                    fxr.RejectChanges();
                                    throw new LMException(msg);
                                }

                                fxr.Name = txtFileSCName.Text;
                                fxr.FullFileNumber = "";
                                fxr.Rollup = false;


                                atLogic.BusinessProcess bpx = fmCurrent.GetBP();
                                bpx.AddForUpdate(Atmng.GetFile(fscDest.FileId).GetFileXRef());
                                bpx.AddForUpdate(Atmng.GetFile(fscDest.FileId).EFile);
                                bpx.Update();
                            }

                            if (chkActivityShortcut.Checked)
                            {
                                FileManager fmDesta = Atmng.GetFile(ascDest.FileId);

                                atriumDB.ActivityXRefRow axr = (atriumDB.ActivityXRefRow)fmDesta.GetActivityXRef().Add(fmDesta.CurrentFile);
                                axr.ActivityId = MyACE.NewActivity.ActivityId;
                                axr.LinkType = 1;
                                axr.Name = txtActivitySCName.Text;

                                atLogic.BusinessProcess bpax = fmCurrent.GetBP();
                                bpax.AddForUpdate(Atmng.GetFile(ascDest.FileId).GetActivityXRef());
                                bpax.AddForUpdate(Atmng.GetFile(ascDest.FileId).EFile);
                                bpax.Update();
                            }

                        }
                        catch (Exception xrefX)
                        {

                            MessageBox.Show(String.Format(LawMate.Properties.Resources.ActivityWasSavedButFailedToCreateShortcuts, Atmng.AppMan.AppName), Atmng.AppMan.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            UIHelper.HandleUIException(xrefX);
                        }

                        if (myRevType != ACEngine.RevType.Convert)
                        {
                            bool FailedToSend = false;
                            try
                            {
                                MyACE.NewActivity.BFPriority = (short)mailImportance;
                                MyACE.NewActivity.AcceptChanges();
                                fmCurrent.GetDocMng().GetDocument().Send(MyACE.NewActivity, encrypt);
                            }
                            catch (Exception xm)
                            {
                                FailedToSend = true;

                                MessageBox.Show(LawMate.Properties.Resources.TheActivityWasSavedButTheMessageFailedToSendViaEMail, Atmng.AppMan.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                UIHelper.HandleUIException(xm);
                            }

                            if (FailedToSend)
                            {
                                try
                                {
                                    MyACE.NewActivity.FailedToSend = true;
                                    atLogic.BusinessProcess bpfs = fmCurrent.GetBP();
                                    bpfs.AddForUpdate(fmCurrent.GetActivity());
                                    bpfs.Update();

                                }
                                catch (Exception xFailedToSendSave)
                                {

                                    MessageBox.Show(String.Format(LawMate.Properties.Resources.AttemptedToStoreInformationIndicatingCommunicationFailedButHasFailedToDoSo, Atmng.AppMan.AppName), Atmng.AppMan.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    UIHelper.HandleUIException(xFailedToSendSave);
                                }
                                finally
                                {
                                    FailedToSend = false;
                                }
                            }
                        }

                        try
                        {
                            //do auto steps
                            ABP.AutoNextStep(MyACE.NewActivity);

                        }
                        catch (Exception autoX)
                        {

                            MessageBox.Show(String.Format(LawMate.Properties.Resources.ActivitySavedButFailedToCreateAutomaticActivities, MyACE.NewActivity.StepCode, Atmng.AppMan.AppName), Atmng.AppMan.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            UIHelper.HandleUIException(autoX);

                        }

                        //TOC is calculated when file loads - it is not saved anymore
                        //try
                        //{
                        //    //update the filestructxml in a new transaction
                        //    atLogic.BusinessProcess bpff = fmCurrent.GetBP();
                        //    bpff.AddForUpdate(fmCurrent.EFile);
                        //    bpff.Update();
                        //    fmCurrent.GetDocMng().DB.AcceptChanges();
                        //}
                        //catch (Exception fsx)
                        //{
                        //    MessageBox.Show(String.Format(LawMate.Properties.Resources.ActivityWasSavedButFailedToUpdateToC, Atmng.AppMan.AppName), Atmng.AppMan.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    UIHelper.HandleUIException(fsx);

                        //}
                        fmCurrent.GetDocMng().DB.AcceptChanges();

                        if (this.Modal)
                            DialogResult = DialogResult.OK;

                        fFile fl = null;
                        fMain fmain = (fMain)Application.OpenForms["fMain"];
                        foreach (Form f in Application.OpenForms) //changed on 2010/6/14 to fix autochain issue
                        {
                            if (f.GetType() == typeof(fFile) && ((fFile)f).FileId == fmCurrent.CurrentFile.FileId)
                            {
                                fl = (fFile)f;
                                fl.MoreInfo("activity", MyACE.NewActivity.ActivityId);
                            }
                        }

                        if (OpenFile)
                        {

                            fl = fmain.OpenFile(this.FileId);
                            //                        myInitialFMKeepAlive = true;
                        }


                        //success!!!!!
                        //delete lm_save file
                        if (System.IO.File.Exists(saveFile))
                            System.IO.File.Delete(saveFile);


                        this.Close();

                        if (AcSeries.AutoChain)
                        {
                            if (fl == null)
                            {

                                fACWizard fNS = new fACWizard(fmCurrent);
                                fmCurrent = null;
                                fmOriginal = null;
                                fNS.Show();
                            }
                            else
                            {
                                fmCurrent = null;
                                fmOriginal = null;
                                fl.LaunchWizard();

                            }
                        }

                    }
                    catch (atLogic.ConcurrencyException cx)
                    {
                        IsErrorOnSave = true;
                        //  fmCurrent.AtMng.AppMan.Rollback();
                        MessageBox.Show("Another user has modified this file while you were attempting to perform this step.\n\nUnfortunately, " + Atmng.AppMan.AppName + " is unable to save your changes at this time. Once you click OK, " + Atmng.AppMan.AppName + " will display another error message, and, when clicking OK, the New Activity Wizard will close and the data on the file will be reloaded.\n\n" + Atmng.AppMan.AppName + " will also automatically create a suspended activity for your entry, purely for the purposes of recovering your document, if need be.\n\nYou will not be able to resume this suspended activity.", "File modified by another user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UIHelper.HandleUIException(cx);
                        Reload = true;

                        LogDetails();
                        Close();

                    }
                    catch (atLogic.UpdateFailedException ux)
                    {
                        IsErrorOnSave = true;
                        //  fmCurrent.AtMng.AppMan.Rollback();
                        UIHelper.HandleUIException(ux);
                        Reload = true;

                        LogDetails();
                        Close();

                    }
                    catch (Exception x)
                    {
                        IsErrorOnSave = true;
                        // fmCurrent.AtMng.AppMan.Rollback();
                        UIHelper.HandleUIException(x);

                        LogDetails();
                    }
                }
                //  Application.UseWaitCursor = false; Cursor = Cursors.Default;
            }
        }

        private void LogDetails()
        {
            try
            {
                string msg = "FileId: {0}, FFN: {1}, StepCode: {2}";
                Atmng.LogMessage(String.Format(msg, fmCurrent.CurrentFileId, fmCurrent.CurrentFile.FullFileNumber, MyACE.myAcSeries.StepCode));
            }
            catch (Exception x)
            {
                //ignore
            }
        }

        private void RefreshSecondaryIssues()
        {
            listBoxSecondary.DataSource = null;
            listBoxSecondary.DataSource = SecondaryIssues.Values;
            listBoxSecondary.ValueMember = "IssueId";
            listBoxSecondary.DisplayMember = UIHelper.Translate(fmCurrent, "IssueNameEng");
        }

        private void btnAddPrimary_Click(object sender, EventArgs e)
        {

            try
            {
                if (ucBrowseIssues1.SelectedIssue != null && ((lmDatasets.appDB.IssueRow)ucBrowseIssues1.SelectedIssue).IssueId != 0 && !((lmDatasets.appDB.IssueRow)ucBrowseIssues1.SelectedIssue).IsFileIdNull())
                {
                    lmDatasets.appDB.IssueRow ir = ucBrowseIssues1.SelectedIssue;
                    AddPrimaryIssue(ir, false);
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void btnRemovePrimary_Click(object sender, EventArgs e)
        {
            try
            {
                ebPrimaryIssue.Text = "";
                ebPrimaryIssue.Tag = null;
                uibtnAddPrimary.Enabled = true;
                uibtnRemovePrimary.Enabled = false;
                PrimaryIssue = null;

            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void btnAddSecondary_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucBrowseIssues1.SelectedIssue != null && !SecondaryIssues.ContainsKey(((lmDatasets.appDB.IssueRow)ucBrowseIssues1.SelectedIssue).IssueId) && ((lmDatasets.appDB.IssueRow)ucBrowseIssues1.SelectedIssue).IssueId != 0 && !((lmDatasets.appDB.IssueRow)ucBrowseIssues1.SelectedIssue).IsFileIdNull())
                {
                    lmDatasets.appDB.IssueRow ir = ucBrowseIssues1.SelectedIssue;
                    AddSecondaryIssue(ir);
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void btnRemoveSecondary_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxSecondary.SelectedValue != null)
                    SecondaryIssues.Remove(listBoxSecondary.SelectedValue);
                else
                    SecondaryIssues.RemoveAt(SecondaryIssues.Count - 1);

                listBoxSecondary.DataSource = null;
                if (SecondaryIssues.Count == 0)
                    uibtnRemoveSecondary.Enabled = false;


                RefreshSecondaryIssues();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);

            }
        }

        //jll: 2014-04-29 added to allow ucActivityNew to set date.
        public void setAcDate(DateTime activityDate, NextStep ns)
        {
            acDate = activityDate;
            MySelectedStep = ns;
        }

        //jll: 2015-02-26 added to show default AC time on activitytime tab when applicable
        private void determineDefaultTime()
        {
            if (MyACE.myActivityCode.IsDefaultHoursNull())
            {
                lblDefaultHours.Visible = false;
                lblDefaultHoursValue.Visible = false;
            }
            else
            {
                lblDefaultHours.Visible = true;
                lblDefaultHoursValue.Visible = true;
                lblDefaultHoursValue.Text = Math.Round(MyACE.myActivityCode.DefaultHours, 1).ToString();
            }

        }
        private void DoAcInfo()
        {
            atriumDB.ActivityRow ar = null;
            if (prevAc != 0)
            {
                ar = fmCurrent.DB.Activity.FindByActivityId(prevAc);
                if (ar == null)
                    ar = fmCurrent.GetActivity().Load(prevAc);
            }
            try
            {
                if (MySelectedStep == null)
                    MyACE = ABP.Add(acDate, AcSeries, Process, AdHoc, ar, mailAction, null, RevId, myRevType, null, contextRow);
                else
                {
                    if (MySelectedStep.FlowQ == null)
                        MyACE = ABP.Add(acDate, AcSeries, Process, AdHoc, ar, mailAction, null, RevId, myRevType, null, contextRow);
                    else
                        MyACE = ABP.Add(acDate, AcSeries, Process, AdHoc, ar, mailAction, MySelectedStep.FlowQ, RevId, myRevType, null, contextRow);
                }

                //check for backdated communication activities
                if (AcSeries.ActivityCodeRow.Communication && MyACE.NewActivity.ActivityDate < DateTime.Today)
                {
                    MyACE.NewActivity.ActivityDate = DateTime.Today;
                    MessageBox.Show("You cannot back-date a communication activity.  It has been set to today's date.");
                }

                MyACE.UseBilling();
                determineDefaultTime();

                //newAc.ActivityDate = calDate.Value;
                mailAction = MyACE.MailAction;

                if (checkboxJumpToFile.Visible)
                    this.Text = Atmng.acMng.GetACSeries().GetNodeText(AcSeries, StepType.Activity, false);
                else
                    this.Text = MyACE.FM.CurrentFile.Name + " (" + MyACE.FM.CurrentFile.FullFileNumber + ") - " + Atmng.acMng.GetACSeries().GetNodeText(AcSeries, StepType.Activity, false);

                UIHelper.ComboBoxInit("vOFFICERLIST", officerIdComboBox, fmCurrent, "OfficerId", "FullName");

                if (MyACE.HasPrompt)
                    Seq.AddLast(ACEngine.Step.Prompt);

                if (MyACE.HasRel0)
                    Seq.AddLast(ACEngine.Step.RelatedFields0);
                if (MyACE.HasRel1)
                    Seq.AddLast(ACEngine.Step.RelatedFields1);
                if (MyACE.HasRel2)
                    Seq.AddLast(ACEngine.Step.RelatedFields2);
                if (MyACE.HasRel3)
                    Seq.AddLast(ACEngine.Step.RelatedFields3);
                if (MyACE.HasRel4)
                    Seq.AddLast(ACEngine.Step.RelatedFields4);
                if (MyACE.HasRel5)
                    Seq.AddLast(ACEngine.Step.RelatedFields5);
                if (MyACE.HasRel6)
                    Seq.AddLast(ACEngine.Step.RelatedFields6);
                if (MyACE.HasRel7)
                    Seq.AddLast(ACEngine.Step.RelatedFields7);
                if (MyACE.HasRel8)
                    Seq.AddLast(ACEngine.Step.RelatedFields8);
                if (MyACE.HasRel9)
                    Seq.AddLast(ACEngine.Step.RelatedFields9);


                if (MyACE.HasTimeline)
                    Seq.AddLast(ACEngine.Step.Timeline);

                if (MyACE.HasDoc & !Seq.Contains(ACEngine.Step.Document) && !SkipDocument)
                    Seq.AddLast(ACEngine.Step.Document);
                if (SkipDocument)
                {
                    MyACE.FM.GetDocMng().DB.RejectChanges();
                    //   MyACE.relTables.Remove("Document0");
                    if (MyACE.relTables.ContainsKey("Document0"))
                        MyACE.relTables["Document0"].RowFilter = "false";

                    MyACE.NewActivity.SetDocIdNull();
                }
                if (MyACE.HasBilling && fmCurrent.CurrentFile.FileMetaTypeRow.isBillable)
                {
                    Seq.AddLast(ACEngine.Step.Billing);
                }
                if (MyACE.HasBFs)
                    Seq.AddLast(ACEngine.Step.BFs);
                if (MyACE.HasDisbursement && fmCurrent.CurrentFile.FileMetaTypeRow.isBillable)
                    Seq.AddLast(ACEngine.Step.Disbursements);

                //this must be the final step
                Seq.AddLast(ACEngine.Step.Confirm);

                DataView dv = new DataView(fmCurrent.DB.Activity, "ActivityId=" + MyACE.NewActivity.ActivityId.ToString(), "", DataViewRowState.CurrentRows);
                activityBindingSource.DataSource = dv;
                completedSteps.Add(CurrentStep);

                //            FileId = fmCurrent.CurrentFile.FileId;
            }
            catch (Exception x)
            {
                //UIHelper.HandleUIException(x);
                NoPromptForSave = true;
                Close();
                throw x;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = RoundUpToMinutes();

            // need to steal a minute before rounding hours
            decimal hours = (decimal)(ts.TotalMinutes / 60);

            tbWizardTimer.Text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + " (" + RoundUpToHours(hours) + ")";
        }

        private decimal RoundUpToHours(decimal hours)
        {
            if (hours % 6 == 0) //JLL: don't set it to .2 at 6 minutes. do it at 7 :)
                return hours;
            else
                return Math.Ceiling(hours * (decimal)Math.Pow(10, 1)) / (decimal)Math.Pow(10, 1);

        }


        private TimeSpan RoundUpToMinutes()
        {
            TimeSpan ts = DateTime.Now.Subtract(startTime);
            if (ts.Seconds > 0)
            {
                ts = ts.Add(new TimeSpan(0, 1, -ts.Seconds));
            }
            return ts;
        }

        private void fACWizard_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            try
            {
                ViewTriangle();
                e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void lblHelpClick_Click(object sender, EventArgs e)
        {
            try
            {
                ViewTriangle();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void ViewTriangle()
        {
            lmDatasets.ActivityConfig.ACSeriesRow acsr = AcSeries;
            if (acsr == null & btnHelpTriangle.Tag != null)
                acsr = (lmDatasets.ActivityConfig.ACSeriesRow)btnHelpTriangle.Tag;

            if (acsr != null && !acsr.IsHelpENull())
            {
                if (HelpTriangle == null || HelpTriangle.IsDisposed)
                    HelpTriangle = new fTriangle(acsr, Atmng);



                HelpTriangle.Show();

                HelpTriangle.Navigate(acsr);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void activityTimeGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(activityTimeGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tvNextSteps_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((System.Windows.Forms.TreeView)sender == tvNextSteps)
            {
                if (e.Node == tvNextSteps.SelectedNode)
                {
                    tvNextSteps.SelectedNode = null;
                    tvNextSteps.SelectedNode = e.Node;
                }
            }
            else if ((System.Windows.Forms.TreeView)sender == ExplorerBarAvailableProcesses)
            {
                if (e.Node == ExplorerBarAvailableProcesses.SelectedNode)
                {
                    ExplorerBarAvailableProcesses.SelectedNode = null;
                    ExplorerBarAvailableProcesses.SelectedNode = e.Node;
                }

            }
        }

        private atriumDB.ProcessRow FindProcess(TreeNode tn)
        {
            if (tn.Tag != null && tn.Tag.GetType() == typeof(atriumDB.ProcessRow))
                return (atriumDB.ProcessRow)tn.Tag;
            else if (tn.Parent != null)
                return FindProcess(tn.Parent);
            else
                return null;
        }

        private void SetImage(TreeNode nStep, StepType st)
        {
            switch (st)
            {
                case StepType.Activity:
                    nStep.ImageIndex = 15;
                    break;
                case StepType.NonRecorded:
                    nStep.ImageIndex = 17;
                    break;
                case StepType.Decision:
                    nStep.ImageIndex = 16;
                    break;
                case StepType.Branch:
                    nStep.ImageIndex = 2;
                    break;
                case StepType.Merge:
                    nStep.ImageIndex = 0;
                    break;
                case StepType.Subseries:
                    nStep.ImageIndex = 18;
                    break;
                case StepType.Start:
                    nStep.ImageIndex = 19;
                    break;
            }
            nStep.SelectedImageIndex = nStep.ImageIndex;
        }

        private void cmdBrowseFSC_Click(object sender, EventArgs e)
        {
            try
            {
                HandleNewShortcutToFile(fileBrowser);
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void cmdBrowseASC_Click(object sender, EventArgs e)
        {
            try
            {
                HandleNewShortcutToActivity(fileBrowser);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void chkFileShortcut_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                HandleNewShortcutToFile(fileBrowser);
            }
            catch (Exception x)
            {
                fscDest = null;
                chkFileShortcut.Checked = false;
                UIHelper.HandleUIException(x);
            }
        }

        private void chkActivityShortcut_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                HandleNewShortcutToActivity(fileBrowser);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void HandleNewShortcutToActivity(fBrowse fileBrowser)
        {
            cmdBrowseASC.Enabled = false;
            if (chkActivityShortcut.Checked)
            {
                if (fileBrowser == null)
                    fileBrowser = new fBrowse(Atmng, 0, false, false, false, true);

                fileBrowser.FindFile(Atmng.WorkingAsOfficer.ShortcutsId);
                if (fileBrowser.ShowDialog() == DialogResult.OK && fileBrowser.SelectedFile != null)
                {
                    ascDest = fileBrowser.SelectedFile;
                    lblASCDest.Text = ascDest.Name;

                    if (String.Format(LawMate.Properties.Resources.UIStepCodeOnFile, MyACE.NewActivity.StepCode, fmCurrent.CurrentFile.Name).Length > txtActivitySCName.MaxLength)
                        txtActivitySCName.Text = String.Format(LawMate.Properties.Resources.UIStepCodeOnFile, MyACE.NewActivity.StepCode, fmCurrent.CurrentFile.Name).Substring(0, txtActivitySCName.MaxLength);
                    else
                        txtActivitySCName.Text = String.Format(LawMate.Properties.Resources.UIStepCodeOnFile, MyACE.NewActivity.StepCode, fmCurrent.CurrentFile.Name);
                }
                else if (ascDest == null)
                {
                    chkActivityShortcut.Checked = false;
                }
            }
            else
            {
                ascDest = null;
            }
            gbActivityShortcut.Visible = chkActivityShortcut.Checked;
            cmdBrowseASC.Enabled = true;
        }

        private void HandleNewShortcutToFile(fBrowse fileBrowser)
        {
            cmdBrowseFSC.Enabled = false;
            if (chkFileShortcut.Checked)
            {
                if (fileBrowser == null)
                    fileBrowser = new fBrowse(Atmng, 0, false, false, false, true);

                fileBrowser.FindFile(Atmng.WorkingAsOfficer.ShortcutsId);
                if (fileBrowser.ShowDialog() == DialogResult.OK && fileBrowser.SelectedFile != null)
                {
                    fscDest = fileBrowser.SelectedFile;
                    FileManager fmdest = Atmng.GetFile(fscDest.FileId);
                    //fmdest.GetFileXRef().LoadByFileId(fscDest.FileId);

                    if (fmdest.DB.FileXRef.Select("Fileid=" + fscDest.FileId.ToString() + " and OTherFileid=" + fmCurrent.CurrentFile.FileId.ToString()).Length > 0)
                    {
                        throw new LMException(LawMate.Properties.Resources.CannotCreateDuplicateXrefShortcutOrChildFile);
                    }

                    lblFSCDest.Text = fscDest.Name;
                    if (fmCurrent.CurrentFile.Name.Length > txtFileSCName.MaxLength)
                        txtFileSCName.Text = fmCurrent.CurrentFile.Name.Substring(0, txtFileSCName.MaxLength);
                    else
                        txtFileSCName.Text = fmCurrent.CurrentFile.Name;
                }
                else if (fscDest == null)
                {
                    chkFileShortcut.Checked = false;
                }
            }
            else
            {
                fscDest = null;
            }
            gbFileShortcut.Visible = chkFileShortcut.Checked;
            cmdBrowseFSC.Enabled = true;
        }

        private void fACWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Reload && !NoPromptForSave)
            {
                if (MyACE != null && (MyACE.NewActivity.RowState == DataRowState.Added | MyACE.NewActivity.RowState == DataRowState.Modified))
                {
                    DialogResult dr = MessageBox.Show(LawMate.Properties.Resources.WizardYouHaveMadeChangesDoYouWantToSave, Atmng.AppMan.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else if (dr == DialogResult.No)
                    {
                        //just close
                        //do we want to delete the suspend file?

                    }
                }
            }
            try
            {
                ucDoc1.Clear();
                //fmCurrent.KeepAlive = myInitialFMKeepAlive;
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    //this runs after save so it doesn't matter that it runs all the time
                    //undo all data changes since start
                    if (MyACE != null)
                        MyACE.Cancel();

                }
                if (ABP != null)
                    ABP.CurrentACE = null;

                ABP = null;
                //fmCurrent = null; setting this to  null breaks autochaining
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void pnlTabs_SelectedPanelChanged(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            try
            {
                if (e.Panel == pnlActivity)
                    tbJCode.Focus();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnNewActivityTime_Click(object sender, EventArgs e)
        {
            try
            {
                //2017-08-11 JLL IUTIR - 9113: step validation should make it such that we never reach this code where file is not billable.
                // consider it an added check

                if (fmCurrent.CurrentFile.FileMetaTypeRow.isBillable)
                {
                    atriumDB.ActivityTimeRow actm = (atriumDB.ActivityTimeRow)fmCurrent.GetActivityTime().Add(MyACE.NewActivity);
                    actm.OfficerId = fmCurrent.AtMng.WorkingAsOfficer.OfficerId;
                    activityTimeBindingSource.Position = activityTimeBindingSource.Find("ActivityTimeId", actm.ActivityTimeId);
                }
                else
                {
                    MessageBox.Show("This file does not allow the entry of timeslips.", "Timeslip not allowed", MessageBoxButtons.OK);
                    btnAddNewTime.Enabled = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnNewBF_Click(object sender, EventArgs e)
        {
            try
            {
                //manually entered BF
                atriumDB.ActivityBFRow acbf = (atriumDB.ActivityBFRow)fmCurrent.GetActivityBF().Add(MyACE.NewActivity);
                acbf.BFType = 2;
                acbf.BFOfficerID = fmCurrent.AtMng.WorkingAsOfficer.OfficerId;
                activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", acbf.ActivityBFId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (activityBFBindingSource.Current == null)
                    return;
                atriumDB.ActivityBFRow acbf = (atriumDB.ActivityBFRow)((DataRowView)activityBFBindingSource.Current).Row;
                if (!acbf.IsBFTypeNull())
                {
                    switch (acbf.BFType)
                    {
                        //case 1: //office
                        //    activityBFGridEX.RootTable.Columns["ForOfficeId"].Selectable = false;
                        //    activityBFGridEX.RootTable.Columns["BFOfficerCode"].Selectable = false;
                        //    activityBFGridEX.RootTable.Columns["RoleCode"].Selectable = false;
                        //    break;
                        case 2: //direct
                            //activityBFGridEX.RootTable.Columns["ForOfficeId"].Selectable = false;
                            activityBFGridEX.RootTable.Columns["BFOfficerCode"].Selectable = true;
                            activityBFGridEX.RootTable.Columns["RoleCode"].Selectable = false;
                            break;
                        case 7: //roles
                            //activityBFGridEX.RootTable.Columns["ForOfficeId"].Selectable = false;
                            activityBFGridEX.RootTable.Columns["BFOfficerCode"].Selectable = false;
                            activityBFGridEX.RootTable.Columns["RoleCode"].Selectable = false;
                            break;

                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void activityBFGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            try
            {
                atriumDB.ActivityBFRow acbf = (atriumDB.ActivityBFRow)((DataRowView)e.Row.DataRow).Row;
                if (acbf.ACBFId != -1)
                {
                    MessageBox.Show(LawMate.Properties.Resources.CannotDeleteSystemGeneratedBFs, LawMate.Properties.Resources.DeletingSystemGeneratedBFNotAllowed, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else
                {
                    if (!UIHelper.ConfirmDelete())
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                activityBFGridEX.UpdateData();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnSaveAsDraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsFileSizeExceeded(true))
                {
                    if (MessageBox.Show(LawMate.Properties.Resources.ThisWillSuspendYourActivityAreYouSure, LawMate.Properties.Resources.SuspendActivity, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Suspend();
                        MyACE.Cancel();
                        MyACE = null;
                        this.Close();
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private bool IsFileSizeExceeded(bool showMessage)
        {
            if (MyACE.relTables.ContainsKey("Document0") && MyACE.relTables["Document0"].Count>0)
            {
                int docSize = fmCurrent.GetDocMng().GetDocument().TotalSize(CurrentMailDoc());
                if (docSize > 50000000)
                {
                    if (showMessage)
                    {
                        string message = String.Format(LawMate.Properties.Resources.UISuspendedFileSizeExceeded, UIHelper.GetSizeReadable(docSize), UIHelper.GetSizeReadable(50000000));
                        MessageBox.Show(message, LawMate.Properties.Resources.UISuspendedFileSizeExceededCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return true;
                }

            }
            return false;
        }

        private string Suspend()
        {
            //use endedit to force the data into the datasets
            this.activityBindingSource.EndEdit();
            this.activityBFBindingSource.EndEdit();
            this.activityTimeBindingSource.EndEdit();
            this.disbursementBindingSource.EndEdit();
            ucDoc1.EndEdit();
            foreach (DataView dv in MyACE.relTables.Values)
            {
                if (dv.Count > 0)
                    dv[0].EndEdit();
            }

            //check document sizes
            if (IsFileSizeExceeded(false))
                return "";

            if (MyACE.FM.CurrentFile.RowState == DataRowState.Added)
                return "";

            ACEState aces = MyACE.Suspend();
            TimeSpan ts = DateTime.Now.Subtract(startTime);
            aces.elapsedTimeSeconds = (int)ts.TotalSeconds;

            aces.myCurrentStep = myCurrentStep;
            aces.myPreviousStep = myPreviousStep;
            aces.completedSteps = completedSteps.ToArray();

            foreach (ACEngine.Step st in Seq)
            {
                aces.Seq.Add(st);
            }

            return Atmng.SaveACState(aces);
        }

        private void timAutosave_Tick(object sender, EventArgs e)
        {
            try
            {
                Suspend();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Seq.Contains(ACEngine.Step.Confirm))
                    DoAcInfo();

                if (DoBFStepIfReq())
                    return;

                CurrentStep = ACEngine.Step.Confirm;

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void txtFileSCName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkFileShortcut.Checked && txtFileSCName.Text.Length == 0)
                {
                    txtFileSCName.Text = LawMate.Properties.Resources.PleaseProvideAShortcutName;
                    MessageBox.Show(LawMate.Properties.Resources.YouMustProvideANameForYourShortcut, LawMate.Properties.Resources.ShortcutName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFileSCName.SelectAll();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityTimeGridEX_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                activityTimeGridEX.CurrentRow.EndEdit();
                atriumDB.ActivityTimeRow atr = (atriumDB.ActivityTimeRow)((DataRowView)activityTimeBindingSource.Current).Row;
                if (atr.IsHoursNull())
                    atr.Hours = 0;

                if (atr.HasErrors)
                {
                    buttonBack.Enabled = false;
                    buttonNext.Enabled = false;
                }
                else
                {
                    buttonBack.Enabled = true;
                    buttonNext.Enabled = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void timFMHeartbeat_Tick(object sender, EventArgs e)
        {
            try
            {
                if (fmCurrent != null && !fmCurrent.IsVirtualFM && fmCurrent.CurrentFile != null)
                {
                    atriumBE.FileManager fm = Atmng.GetFile(fmCurrent.CurrentFile.FileId);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void activityTimeGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record || e.Row.RowType == Janus.Windows.GridEX.RowType.TotalRow)
                {
                    //if (e.Row.Cells["Hours"].Value != null && e.Row.Cells["Hours"].Value.ToString().Length > 0)
                    //    e.Row.Cells["Hours"].Text = UIHelper.FormatMinutes(decimal.ToInt32((decimal)e.Row.Cells["Hours"].Value));
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityTimeGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (activityTimeBindingSource.Current == null)
                    return;

                if (e.Column.Key == "Hours")
                {
                    atriumDB.ActivityTimeRow actr = (atriumDB.ActivityTimeRow)((DataRowView)activityTimeBindingSource.Current).Row;

                    fTimeConvertor ftc = new fTimeConvertor(actr.Hours); //TODO: check app setting to determine if * 60 or not
                    ftc.ShowDialog(this);
                    if (ftc.DialogResult == DialogResult.OK)
                    {
                        actr.Hours = (decimal)ftc.totalminutes / (decimal)60; //added: divided by 60 to convert to decimal

                        //TODO: check app setting to decided whether or not to divide by 60

                        activityTimeGridEX.Refetch();
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private string ACDescriptionFull(ActivityConfig.ACSeriesRow acsr)
        {
            if (!acsr.IsDescEngNull())
            {
                //JLL 2013-06-21: split up the check to verify that translated value is also not null; raised error when DescFre value was null but not DescEng
                if (!AcSeries.IsNull(UIHelper.Translate(fmCurrent, "DescEng")))
                    return (string)AcSeries[UIHelper.Translate(fmCurrent, "ActivityNameEng")] + " " + (string)AcSeries[UIHelper.Translate(fmCurrent, "DescEng")];
                else
                    return (string)AcSeries[UIHelper.Translate(fmCurrent, "ActivityNameEng")];
            }
            else
                return (string)AcSeries[UIHelper.Translate(fmCurrent, "ActivityNameEng")];
        }

        private void tvNextSteps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                buttonFinish.Enabled = false;
                buttonLast.Enabled = false;
                CodeChangeInitiatedByUserClick = true;
                if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(NextStep))
                {
                    NextStep ns = (NextStep)e.Node.Tag;
                    if (ns.Enabled & ns.acs.StepType == (int)StepType.Activity)
                    {
                        this.MySelectedStep = ns;
                        this.AcSeries = ns.acs;

                        //check for rel fields
                        CheckForQuickFinish(ns);

                        DoSkipDocumentCheck(ns);
                        if (ns.prevAc != null)
                            this.prevAc = ns.prevAc.ActivityId;
                        else
                            prevAc = 0;

                        tbJCode.Text = AcSeries.StepCode;
                        ebACDescription.Text = ACDescriptionFull(AcSeries);

                    }
                    else
                    {
                        tbJCode.Text = "";
                        ebACDescription.Text = "";
                        AcSeries = null;
                        prevAc = 0;
                        //e.Node.TreeView.SelectedNode = null;
                        this.MySelectedStep = null;
                        DoSkipDocumentCheck(null);
                        //return;
                    }
                    if (!ns.acs.IsNull(UIHelper.Translate(fmCurrent, "HelpE")))
                    {
                        btnHelpTriangle.Tag = ns.acs;
                        btnHelpTriangle.Visible = true;
                    }
                    else
                        btnHelpTriangle.Visible = false;

                }

                else
                {
                    tbJCode.Text = "";
                    ebACDescription.Text = "";
                    AcSeries = null;
                    prevAc = 0;
                    //e.Node.TreeView.SelectedNode = null;
                    this.MySelectedStep = null;
                    DoSkipDocumentCheck(null);
                    btnHelpTriangle.Visible = false;
                    //return;
                }


                lblNoCodeSelectedMessage.Visible = false;


            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
            finally
            {
                CodeChangeInitiatedByUserClick = false;
            }

        }

        private void CheckForQuickFinish(NextStep ns)
        {
            if (ns == null)
                return;

            ACEngine test = new ACEngine(fmCurrent);
            test.TestForSteps(ns.acs.ACSeriesId);
            if (!test.HasAnyRel & (!test.HasDoc | SkipDocument))
            {
                buttonLast.Enabled = true;
                buttonFinish.Enabled = true;
            }
        }


        private void expandCollapseTVNodes(Janus.Windows.EditControls.UIButton btn, TreeView tv)
        {
            if (btn.Text == LawMate.Properties.Resources.ExpandAll)
            {
                tv.ExpandAll();
                btn.Text = LawMate.Properties.Resources.CollapseAll;
                btn.Image = LawMate.Properties.Resources.CollapseAllSteps2;
            }
            else
            {
                tv.CollapseAll();
                btn.Text = LawMate.Properties.Resources.ExpandAll;
                btn.Image = LawMate.Properties.Resources.ExpandAllSteps2;
            }
            tv.Focus();
            if (tv.SelectedNode != null)
                tv.SelectedNode.EnsureVisible();
        }



        private void btnExpandCollapseNextSteps_Click(object sender, EventArgs e)
        {
            try
            {
                expandCollapseTVNodes(btnExpandCollapseNextSteps, tvNextSteps);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                expandCollapseTVNodes(btnExpandCollapseAvailProcesses, ExplorerBarAvailableProcesses);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fACWizard_Load(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(fACWizard))
                {
                    fACWizard fw = (fACWizard)f;

                    if (fw.fmCurrent != null && fw.FileId == FileId && fw != this)
                    {
                        Close();
                        throw new LMException(LawMate.Properties.Resources.CantHaveMoreThanOneNAWOpenOnTheSameFile);
                    }
                }
            }
            if (this.Modal)
                this.MinimizeBox = false;

            if (myInitialStep != ACEngine.Step.NoStep)
                CurrentStep = myInitialStep;
        }


        private void timFocus_Tick(object sender, EventArgs e)
        {
            timFocus.Stop();

            try
            {
                switch (this.CurrentStep)
                {
                    case ACEngine.Step.PickActivity:
                        tbJCode.Focus();
                        break;
                    case ACEngine.Step.Document:
                        ucDoc1.Focus1();
                        break;
                    case ACEngine.Step.RelatedFields0:
                    case ACEngine.Step.RelatedFields1:
                    case ACEngine.Step.RelatedFields2:
                    case ACEngine.Step.RelatedFields3:
                    case ACEngine.Step.RelatedFields4:
                    case ACEngine.Step.RelatedFields5:
                    case ACEngine.Step.RelatedFields6:
                    case ACEngine.Step.RelatedFields7:
                    case ACEngine.Step.RelatedFields8:
                    case ACEngine.Step.RelatedFields9:
                        if (myRF != null && myRF.requiresAction != null)
                        {
                            myRF.requiresAction.RequiredAction();
                            myRF.requiresAction = null;
                        }
                        if (myRF != null && myRF.firstCtl != null)
                        {
                            //flowLayoutPanel1.Controls[3].Focus();
                            //flowLayoutPanel1.Controls[1].Focus();
                            myRF.firstCtl.Focus();
                            this.Activate();
                        }
                        break;

                }
            }
            catch (Exception x)
            { }
        }


        private void btnExpandCollapseEnabledProcesses_Click(object sender, EventArgs e)
        {
            try
            {
                expandCollapseTVNodes(btnExpandCollapseEnabledProcesses, tvEnabledProcesses);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ebACComment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.TextBoxTextCounter(ebACComment, acCommentCounter, 255);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool CodeFieldBackspaceKeyPressed = false;
        private void tbJCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    CurrentStep = Next();
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

        private void btnAddNewDisb_Click(object sender, EventArgs e)
        {

            try
            {
                if (fmCurrent.CurrentFile.FileMetaTypeRow.isBillable)
                {
                    atriumDB.DisbursementRow disbRow = (atriumDB.DisbursementRow)fmCurrent.GetDisbursement().Add(MyACE.NewActivity);
                    disbursementBindingSource.Position = disbursementBindingSource.Find("DisbId", disbRow.DisbId);
                }
                else
                {
                    MessageBox.Show("This file does not allow the entry of disbursements.", "Disbursement not allowed", MessageBoxButtons.OK);
                    btnAddNewDisb.Enabled = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void disbursementGridEX_DeletingRecords(object sender, CancelEventArgs e)
        {
            try
            {
                if (!UIHelper.ConfirmDelete())
                {
                    e.Cancel = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.Cells["BFOfficerCode"].Text == "")
                    e.Row.Cells["BFPerson"].Value = e.Row.Cells["RoleCode"].Text;
                else
                    e.Row.Cells["BFPerson"].Value = e.Row.Cells["BFOfficerCode"].Text;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }


        }

        FlowLayoutPanel IRelatedFieldsHost.flowLayoutPanel1
        {
            get { return flowLayoutPanel1; }
        }



        Janus.Windows.Common.JanusSuperTip IRelatedFieldsHost.janusSuperTip1
        {
            get { return janusSuperTip1; }
        }


        public void DoRelFields(ActivityConfig.ACSeriesRow acSeries, int step)
        {
            if (myRF == null)
                myRF = new RelatedFields(MyACE, this, false, true);

            myRF.BeginLayout();
            myRF.DoRelFields(acSeries, step);
            myRF.FinishLayout();

        }



        public void SkipStep()
        {
            skipping = true;
            if (buttonBack.Focused)
            {
                this.InvokeOnClick(buttonBack, new EventArgs());
                //                        CurrentStep = Back();
            }
            else
            {
                this.InvokeOnClick(buttonNext, new EventArgs());
                // CurrentStep = Next();
            }
        }
        private void fACWizard_Shown(object sender, EventArgs e)
        {
            try
            {
                if (myInitialStep != ACEngine.Step.NoStep && CurrentStep != ACEngine.Step.Prompt)
                    CurrentStep = myInitialStep;

                if (myInitialStep == ACEngine.Step.PickActivity)
                    lblNoCodeSelectedMessage.Visible = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                SkipDocument = ((Janus.Windows.EditControls.UICheckBox)sender).Checked;

                if (SkipDocument)
                    CheckForQuickFinish(MySelectedStep);
                else
                {
                    buttonFinish.Enabled = false;
                    buttonLast.Enabled = false;
                }

                

                //2017-08-23 JLL: why do we disable Next when skip is set false?!?! 
                //if user clicks Skips, then unclicks, they can't move forward in the NAW

                //if (myCurrentStep == ACEngine.Step.Document)
                    //buttonNext.Enabled = SkipDocument;    
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fACWizard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8 && CurrentStep == ACEngine.Step.Document)
            {
                ucDoc1.FocusToOffice();
            }
            else if (e.KeyCode == Keys.F9 && CurrentStep == ACEngine.Step.Document)
            {
                ucDoc1.PasteToOffice();
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                if (e.Command.Key == "tsNewDirectBF" || e.Command.Key.StartsWith("tsNewRoleBF"))
                {
                    NewBF(e.Command);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void NewBF(Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            atriumDB.ActivityBFRow acbf = (atriumDB.ActivityBFRow)fmCurrent.GetActivityBF().Add(MyACE.NewActivity);
            activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", acbf.ActivityBFId);

            if (cmd.Tag.GetType() == typeof(string)) //Role Code stored in command tag
            {
                acbf.SetBFOfficerIDNull();
                acbf.BFType = 7;
                acbf.RoleCode = (string)cmd.Tag;
            }
            
            ActivityConfig.ACBFRow acbfr = MyACE.FM.AtMng.acMng.DB.ACBF.FindByACBFId(ActivityBFBE.USERBFID);
            acbf.BFDescriptionEng = acbfr.BFDescriptionEng;
            acbf.BFDescriptionFre = acbfr.BFDescriptionFre;
        }
    }
}

