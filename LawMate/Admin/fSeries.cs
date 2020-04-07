using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using System.Runtime.InteropServices;



namespace LawMate.Admin
{

    public partial class fSeries : fBase
    {
        Workflow.Diagram diagram;
        System.Collections.Stack SeriesStack = new System.Collections.Stack();
        bool BackButtonSelected = false;
        bool FormInitialize = true;
        bool IsDeletingStep = false;
        bool IsDeletingSeries = false;
        DataTable dtUsableAliases;
        DataTable dtUsableAliasesRelFields;

        fBrowse fbr;
        lmDatasets.ActivityConfig.ActivityFieldDataTable AFClipboard;

        fWait fwait = new fWait();

        public fSeries()
        {
            InitializeComponent();
        }

        public fSeries(Form f)
            : base(f)
        {
            InitializeComponent();

            UIHelper.BindComboBox(stepTypeComboBox, Enum2DataTable(typeof(atriumBE.StepType)), "id", "text");

            atriumBE.FileManager FM = AtMng.GetFile();
            ucMultiDropDown1.SetDataBinding(FM.Codes("vSeriesType"), "");
            UIHelper.ComboBoxInit(FM.Codes("vSeriesType"), seriesGridEX.DropDowns["ddSeriesType"], FM);
            UIHelper.ComboBoxInit(AtMng.acMng.DB.SeriesPackage, mccSeriesPackage, FM);
            UIHelper.ComboBoxInit(AtMng.acMng.DB.SeriesStatus, mccSeriesStatus, FM);
            UIHelper.ComboBoxInit("vCaseStatus", caseStatusucMultiDropDown, FM);

            PopulateDDBlockFilter();
            FM.Dispose();

            AtMng.GetCodeTableBE("SeriesType").Load();


            seriesBindingSource.DataSource = AtMng.acMng.DB;
            seriesBindingSource.DataMember = "Series";
            if (CurrentSeries() != null)
                SeriesStack.Push(CurrentSeries().SeriesId);

            InitDiagram();

            FormInitialize = false;

            aCDependencyGridEX.DropDowns["ddACSeries"].SetDataBinding(AtMng.acMng.DB, "ACSeries");
            aCDependencyGridEX.DropDowns["ddACBF"].SetDataBinding(AtMng.acMng.DB, "ACBF");
            aCDependencyGridEX.DropDowns["ddLinkType"].SetDataBinding(Enum2DataTable(typeof(atriumBE.ConnectorType)).DefaultView, "");
            aCBFGridEX.DropDowns["ddRoleCode"].SetDataBinding(FM.Codes("RoleCode"), "");
            aCFileTypeGridEX.DropDowns["ddFileType"].SetDataBinding(FM.Codes("FileType"), "");
            aCFileTypeGridEX.DropDowns["ddMetaType"].SetDataBinding(FM.Codes("FileMetaType"), "");

            //Create Dataview for ConvertRevert List Fields and set as DataSource of dropdowns
            DataView dvConvertRevertList = new DataView(AtMng.acMng.DB.ACSeries, "StepType=0 and SeriesId<>0 and obsolete=false", "StepCode", DataViewRowState.CurrentRows);
            aCConvertGridEX.DropDowns["ddAcSeries"].SetDataBinding(dvConvertRevertList, "");
            aCConvertGridEX1.DropDowns["ddAcSeries"].SetDataBinding(dvConvertRevertList, "");

            //Create Dataview for Preset List Related Fields and set as DataSource
            DataView dvACS = new DataView(AtMng.acMng.DB.ACSeries, "Count(Child(ACSeries_ActivityField).ActivityFieldID)>0", "", DataViewRowState.CurrentRows);
            //mccACS.DataSource = dvACS;
            mccPresetRelFields.DataSource = dvACS;
            gridexRecordsUsed.DropDowns["ddStepCodeList"].SetDataBinding(dvACS, "");

            //Create datatable of accessible Table objects
            DataTable dtTables = AtMng.GetGeneralRec("Select * from vddTable where AllowInRelatedFields=1");
            gridexRecordsUsed.DropDowns["ddTable"].SetDataBinding(dtTables.DefaultView, "");

            //create datatable of lookup values for relfields
            //  DataTable dtLookups = AtMng.GetGeneralRec("Select * from vddLookup");
            gridexRelatedFields.DropDowns["ddLookup"].SetDataBinding(AtMng.DB.ddLookup.DefaultView, "");

            //activityFieldGridEX.DropDowns["ddTable"].SetDataBinding(dtTables.DefaultView, "");
            //relatedInfoNewRecordsGridEx.DropDowns["ddTable"].SetDataBinding(dtTables.DefaultView, "");
            //relatedInfoBillingGridEx.DropDowns["ddTable"].SetDataBinding(dtTables.DefaultView, "");
            //relatedInfoDocumentGridEx.DropDowns["ddTable"].SetDataBinding(dtTables.DefaultView, "");
            //relatedInfoFieldsGridEx.DropDowns["ddTable"].SetDataBinding(dtTables.DefaultView, "");

            //create datatable to use for object alias selection
            dtUsableAliases = new DataTable();
            dtUsableAliases.Columns.Add("ObjectAlias", System.Type.GetType("System.String"));
            dtUsableAliases.PrimaryKey = new DataColumn[] { dtUsableAliases.Columns[0] };
            dtUsableAliasesRelFields = new DataTable();
            dtUsableAliasesRelFields.Columns.Add("ObjectAlias", System.Type.GetType("System.String"));
            dtUsableAliasesRelFields.PrimaryKey = new DataColumn[] { dtUsableAliasesRelFields.Columns[0] };

            ucWorkflowLegend1.InitLegend(FM);
            ucWorkflowHeader1.Init(AtMng);

            DataView dvAC = new DataView(AtMng.acMng.DB.ActivityCode, "obsolete=false", "ActivityCode", DataViewRowState.CurrentRows);
            multiColumnCombo1.SetDataBinding(dvAC, "");
            BuildControlTypeDD();
            BuildActivityCodeList(cmdNewSeriesActivity, "NewSeries");
            BuildActivityCodeList(cmdWFActivity2, "NextStep");
            //BuildRelatedFieldsList();
            BuildBFOnlyMailConnectorsActivityList();
            UIHelper.AcSeriesIconBuild(cbAcSeriesIcon);


            //seriesGridEX.MoveFirst();

            wFValidationBindingSource.DataSource = AtMng.acMng.DB.WFValidation;
            addSpecialObjectCommands();
            uiCommandManager1.SetContextMenu(gridexRelatedFields, uiContextMenu3);
            uiCommandManager1.SetContextMenu(gridexRecordsUsed, uiContextMenu4);

        }

        private void BuildControlTypeDD()
        {

            Janus.Windows.GridEX.GridEXDropDown ctrlDD = gridexRelatedFields.DropDowns["ddCtlType"];
            ctrlDD.SetDataBinding(AtMng.acMng.DB.ACControlType, "");
            ctrlDD.RootTable.Columns["ACControlTypeDescEng"].Width = 200;
            ctrlDD.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(ctrlDD_FormattingRow);

        }

        void ctrlDD_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                System.Resources.ResourceManager rm = Properties.Resources.ResourceManager;
                e.Row.Cells["ACControlTypeDescEng"].Image = (Image)rm.GetObject(e.Row.Cells["ImgResource"].Value.ToString());

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void PopulateDDBlockFilter()
        {
            valueListUpDown1.ValueList.Add(100, "All Related Data (No Filter)", 0);
            valueListUpDown1.ValueList.Add(-10, "Initiate Block", 2);
            valueListUpDown1.ValueList.Add(0, "Related Fields Block 1", 2);
            valueListUpDown1.ValueList.Add(1, "Related Fields Block 2", 2);
            valueListUpDown1.ValueList.Add(2, "Related Fields Block 3", 2);
            valueListUpDown1.ValueList.Add(3, "Related Fields Block 4", 2);
            valueListUpDown1.ValueList.Add(4, "Related Fields Block 5", 2);
            valueListUpDown1.ValueList.Add(10, "Document Block", 1);
            valueListUpDown1.ValueList.Add(11, "Timekeeping Block", 2);
            valueListUpDown1.ValueList.Add(12, "Scheduling Block", 2);


        }

        private DataTable Enum2DataTable(System.Type e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", System.Type.GetType("System.Int32"));
            dt.Columns.Add("text", System.Type.GetType("System.String"));


            foreach (string name in Enum.GetNames(e))
            {
                dt.Rows.Add((int)Enum.Parse(e, name), name);
            }

            return dt;
        }
        private void aCDependencyBindingSource_PositionChanged(object sender, EventArgs e)
        {
            ACBFBind();
        }

        private void AddStep()
        {
            pnlACSeries.Activate();
            ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
            acsr.Start = true;
            aCSeriesBindingSource.MoveLast();

            multiColumnCombo1.Enabled = true;
        }

        public void MoreInfoSeries(int SeriesId)
        {
            seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", SeriesId);
        }

        public void MoreInfoACSeries(int ACSeriesId)
        {
            aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("ACSeriesId", ACSeriesId);
            ACSeriesSelect(ACSeriesId.ToString());
        }

        public void MoreInfoRelField(int arfId)
        {
            pnlRelRecsFields.Activate();
            ActivityConfig.ActivityFieldRow afr = AtMng.acMng.DB.ActivityField.FindByActivityFieldID(arfId);
            if (afr.TaskType.ToUpper() == "F")
            {
                activityFieldBindingSource.Position = activityFieldBindingSource.Find("ActivityFieldID", arfId);
                bool found = gridexRelatedFields.Find(gridexRelatedFields.RootTable.Columns["ActivityFieldID"], Janus.Windows.GridEX.ConditionOperator.Equal, afr.ActivityFieldID, -1, 1);
                gridexRelatedFields.Focus();
            }
            else
            {
                gridexRecordsUsed.Focus();
                Janus.Windows.GridEX.GridEXFilterCondition gef = new Janus.Windows.GridEX.GridEXFilterCondition(gridexRecordsUsed.RootTable.Columns["ActivityFieldID"], Janus.Windows.GridEX.ConditionOperator.Equal, afr.ActivityFieldID);
                gridexRecordsUsed.Find(gef, -1, 1);
            }


        }

        private void AddNewBFMailConnector(lmDatasets.ActivityConfig.ACSeriesRow acsr)
        {
            ShowPanel(pnlPropertyGrid);
            lmDatasets.ActivityConfig.ACDependencyRow acd;
            lmDatasets.ActivityConfig.ACSeriesRow currentStep = CurrentACS();
            acd = (lmDatasets.ActivityConfig.ACDependencyRow)AtMng.acMng.GetACDependency().Add(currentStep);
            //need to create IF for whether BFOnly or ReplyReplyAllForward connector
            //currently defaulting it to BFOnly
            acd.LinkType = (int)atriumBE.ConnectorType.BFOnly;
            acd.NextStepId = acsr.ACSeriesId;
            InitDiagram();
            //diagram.AddConnector(acd);

        }

        private void AddNewStart(lmDatasets.ActivityConfig.ACSeriesRow acsr, atriumBE.StepType stepType)
        {
            //acsr.StepType = (int)stepType;
            //if (stepType == atriumBE.StepType.Activity)
            //    acsr.ActivityCodeID = acr.ActivityCodeID;
            //if (stepType == atriumBE.StepType.Decision)
            //    acsr.ActivityCodeID = -1;
            //else if (stepType == atriumBE.StepType.NonRecorded)
            //    acsr.ActivityCodeID = -2;

            //aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("ACSeriesId", acsr.ACSeriesId);


            //diagram.SelectStep(diagram.mySteps["a" + acsr.ACSeriesId.ToString()]);

            //propertyGrid1.SelectedObject = diagram.mySteps["a" + acsr.ACSeriesId.ToString()];
            //diagram.Draw(CurrentSeries());

        }

        private void AddNewNextStep(atriumBE.StepType st, Workflow.Step step)
        {
            //pnlACSeries.Activate();

            ShowPanel(pnlPropertyGrid);
            lmDatasets.ActivityConfig.ACDependencyRow acd;
            lmDatasets.ActivityConfig.ACSeriesRow currentStep = CurrentACS();

            if (step == null)
            {
                lmDatasets.ActivityConfig.ACSeriesRow newStep = (lmDatasets.ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
                aCSeriesBindingSource.MoveLast();
                newStep.StepType = (int)st;

                acd = (lmDatasets.ActivityConfig.ACDependencyRow)AtMng.acMng.GetACDependency().Add(currentStep);
                acd.NextStepId = newStep.ACSeriesId;
                multiColumnCombo1.Enabled = true;

                diagram.AddStep(newStep);
                diagram.AddConnector(acd);

                diagram.SelectStep(diagram.mySteps["a" + newStep.ACSeriesId.ToString()]);

                propertyGrid1.SelectedObject = diagram.mySteps["a" + newStep.ACSeriesId.ToString()];
            }
            else
            {
                acd = (lmDatasets.ActivityConfig.ACDependencyRow)AtMng.acMng.GetACDependency().Add(currentStep);
                acd.NextStepId = step.myACS.ACSeriesId;
                multiColumnCombo1.Enabled = true;

                diagram.AddConnector(acd);

                diagram.SelectStep(step);

                propertyGrid1.SelectedObject = step;

            }

            diagram.Draw(CurrentSeries());
        }

        private void AddNewNextStepSeries(atriumBE.StepType st, lmDatasets.ActivityConfig.SeriesRow sr)
        {

            //Next step is a subprocess

            ShowPanel(pnlPropertyGrid);
            lmDatasets.ActivityConfig.ACDependencyRow acd;
            lmDatasets.ActivityConfig.ACSeriesRow currentStep = CurrentACS();


            lmDatasets.ActivityConfig.ACSeriesRow newStep = (lmDatasets.ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
            aCSeriesBindingSource.MoveLast();

            newStep.StepType = (int)st;
            newStep.SubseriesId = sr.SeriesId;

            acd = (lmDatasets.ActivityConfig.ACDependencyRow)AtMng.acMng.GetACDependency().Add(currentStep);
            acd.NextStepId = newStep.ACSeriesId;

            multiColumnCombo1.Enabled = true;

            diagram.AddStep(newStep);
            diagram.AddConnector(acd);

            diagram.SelectStep(diagram.mySteps["a" + newStep.ACSeriesId.ToString()]);

            propertyGrid1.SelectedObject = diagram.mySteps["a" + newStep.ACSeriesId.ToString()];

            diagram.Draw(CurrentSeries());
        }

        private void ShowPanel(Janus.Windows.UI.Dock.UIPanel pnl)
        {
            if (pnl == pnlActivities)
            {
                pnlActivities.Closed = false;
                pnlSeriesDetails.Closed = true;
                pnlPropertyGrid.Closed = true;
            }
            if (pnl == pnlSeriesDetails)
            {
                pnlActivities.Closed = true;
                pnlSeriesDetails.Closed = false;
                pnlPropertyGrid.Closed = true;
            }
            if (pnl == pnlPropertyGrid)
            {
                pnlActivities.Closed = true;
                pnlSeriesDetails.Closed = true;
                pnlPropertyGrid.Closed = false;
            }
        }

        private void ToggleSeriesProperties_ActivitiesList()
        {
            if (cmdProcProp.Checked == Janus.Windows.UI.InheritableBoolean.True)
            {
                pnlActivities.Closed = true;
                pnlSeriesDetails.Closed = false;
                pnlPropertyGrid.Closed = true;
            }
            else
            {
                pnlSeriesDetails.Closed = true;
                pnlActivities.Closed = false;
                pnlPropertyGrid.Closed = false;
            }
        }

        private void ShowPropertyGrid()
        {
            cmdProcProp.Checked = Janus.Windows.UI.InheritableBoolean.False;

        }

        private void DoSeriesFieldsBackcolor(bool isNewSeries)
        {
            Color bg = SystemColors.Window;
            if (isNewSeries)
                bg = Color.Pink;

            seriesCodeEditBox.BackColor = bg;
            mccSeriesStatus.BackColor = bg;
            //statusUIComboBox.BackColor = bg;
            ucMultiDropDown1.ReqColor = bg;
            seriesDescEngEditBox.BackColor = bg;
            seriesDescFreEditBox.BackColor = bg;
            nameFormatEEditBox.BackColor = bg;
            nameFormatFEditBox.BackColor = bg;
        }

        private void NewSeries(lmDatasets.ActivityConfig.ActivityCodeRow acr, atriumBE.StepType stepType)
        {
            //pnlACSeries.Activate();

            lmDatasets.ActivityConfig.SeriesRow sr = AtMng.acMng.DB.Series.NewSeriesRow();
            AtMng.acMng.DB.Series.AddSeriesRow(sr);
            seriesBindingSource.Position = seriesBindingSource.Find("seriesId", sr.SeriesId);

            ShowPanel(pnlSeriesDetails);

            seriesCodeEditBox.Focus();

            //highlight mandatory fields
            DoSeriesFieldsBackcolor(true);

            lmDatasets.ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());

            acsr.StepType = (int)stepType;
            if (stepType == atriumBE.StepType.Activity)
                acsr.ActivityCodeID = acr.ActivityCodeID;
            else if (stepType == atriumBE.StepType.Decision)
                acsr.ActivityCodeID = -1;
            else if (stepType == atriumBE.StepType.NonRecorded)
                acsr.ActivityCodeID = -2;

            aCSeriesBindingSource.MoveLast();

            diagram.Draw(CurrentSeries());

            propertyGrid1.SelectedObject = diagram.SelectedStep;

            //multiColumnCombo1.Enabled = true;
        }

        private bool Save()
        {
            try
            {
                if (AtMng.acMng.DB.HasErrors)
                {
                    MessageBox.Show("Cannot save while there are errors in the data.");
                    return false;
                }
                else
                {
                    if (IsDeletingStep)
                    {
                        DoSave();
                        IsDeletingStep = false;
                        return true;
                    }
                    else
                    {
                        if (MessageBox.Show("All edits (to all records) will be saved.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            DoSave();
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);

                return false;
            }
        }

        private void DoSave()
        {
            //activityFieldGridEX.CurrentRow.EndEdit();

            //activityFieldGridEX.UpdateData();
            //relatedInfoBillingGridEx.UpdateData();
            //relatedInfoDocumentGridEx.UpdateData();
            //relatedInfoFieldsGridEx.UpdateData();
            //relatedInfoNewRecordsGridEx.UpdateData();

            gridexRecordsUsed.UpdateData();
            gridexRelatedFields.UpdateData();



            aCFileTypeGridEX.UpdateData();

            seriesBindingSource.EndEdit();
            activityCodeBindingSource.EndEdit();
            aCSeriesBindingSource.EndEdit();
            activityFieldBindingSource.EndEdit();
            aCDependencyBindingSource.EndEdit();
            aCBFBindingSource.EndEdit();
            aCConvertBindingSource.EndEdit();
            aCFileTypeBindingSource.EndEdit();

            atLogic.BusinessProcess bp = AtMng.GetBP();

            bp.AddForUpdate(AtMng.acMng.GetSeries());
            bp.AddForUpdate(AtMng.acMng.GetActivityCode());
            bp.AddForUpdate(AtMng.acMng.GetACSeries());
            bp.AddForUpdate(AtMng.acMng.GetActivityField());
            bp.AddForUpdate(AtMng.acMng.GetACDependency());
            bp.AddForUpdate(AtMng.acMng.GetACBF());
            bp.AddForUpdate(AtMng.acMng.GetACConvert());
            bp.AddForUpdate(AtMng.acMng.GetACFileType());
            bp.Update();

            ValidateForContainerFile(!CurrentSeries().IsContainerFileIdNull());
            DoSeriesFieldsBackcolor(false);
        }

        private void Cancel()
        {

            try
            {
                if (MessageBox.Show("All edits (to all records) will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    diagram = null;

                    UIHelper.Cancel(aCBFBindingSource);
                    UIHelper.Cancel(activityCodeBindingSource);
                    UIHelper.Cancel(aCDisbBindingSource);
                    UIHelper.Cancel(aCDependencyBindingSource);
                    UIHelper.Cancel(activityFieldBindingSource);
                    UIHelper.Cancel(aCConvertBindingSource);
                    UIHelper.Cancel(aCSeriesBindingSource);
                    UIHelper.Cancel(seriesBindingSource);

                    UIHelper.Cancel(AtMng.acMng.DB);
                    ValidateForContainerFile(!CurrentSeries().IsContainerFileIdNull());
                    DoSeriesFieldsBackcolor(false);
                    InitDiagram();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void BuildUsedRecsMenu(bool isQuestion)
        {
            //select cmd always enabled
            //others depends on step type being question or activity
            Janus.Windows.UI.InheritableBoolean enable;
            if (isQuestion)
                enable = Janus.Windows.UI.InheritableBoolean.False;
            else
                enable = Janus.Windows.UI.InheritableBoolean.True;

            cmdNewGetRecord.Enabled = enable;
            cmdNewRecord.Enabled = enable;
            cmdLoadRecords.Enabled = enable;
            cmdSpecialObject.Enabled = enable;
            cmdIssueContainer.Enabled = enable;
            cmdQueriedRecord.Enabled = enable;
        }

        private void aCSeriesBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (aCSeriesBindingSource.Current == null)
            {
                DataView dv = new DataView(AtMng.acMng.DB.ActivityCode, "ActivityCodeId is null", "", DataViewRowState.CurrentRows);
                activityCodeBindingSource.DataMember = null;
                activityCodeBindingSource.DataSource = dv;
                // ucWorkflowHeader1.SetNull();
            }
            else
            {
                lmDatasets.ActivityConfig.ACSeriesRow asr = (lmDatasets.ActivityConfig.ACSeriesRow)((DataRowView)aCSeriesBindingSource.Current).Row;
                DataView dv = null;
                try
                {
                    if (!asr.IsNull("ActivityCodeID"))
                    {
                        dv = new DataView(AtMng.acMng.DB.ActivityCode, "ActivityCodeId=" + asr.ActivityCodeID.ToString(), "", DataViewRowState.CurrentRows);
                        activityCodeBindingSource.DataMember = null;
                        activityCodeBindingSource.DataSource = dv;
                        //   ucWorkflowHeader1.SetNull();
                    }
                    ACBFBind();
                }
                catch (Exception x)
                {
                }

            }

            multiColumnCombo1.Enabled = false;

            //select step in 
            //diagram and scroll
            //into 
            //view
            //
            if (CurrentACS() != null & diagram != null)
            {
                if (diagram.mySteps.Count > 0 && diagram.mySteps.ContainsKey(diagram.GetStepKey(CurrentACS())))
                {
                    BuildExistingStepMenu();
                    Workflow.Step s = diagram.mySteps[diagram.GetStepKey(CurrentACS())];
                    diagram.SelectStep(s);
                    ucWorkflowHeader1.SetStep(CurrentACS());
                    propertyGrid1.SelectedObject = s;
                    BuildUsedRecsMenu(false);
                    if (s.GetType() != typeof(Workflow.Activity))
                    {
                        if (s.GetType() == typeof(Workflow.Decision))
                        {
                            BuildUsedRecsMenu(true);
                            pnlRelRecsFields.Enabled = true;
                            pnlRelFieldGrid.Closed = true;
                        }
                        else
                            pnlRelRecsFields.Enabled = false;

                        pnlConvertRevert.Enabled = false;
                        if (pnlDetails.SelectedPanel == pnlRelRecsFields || pnlDetails.SelectedPanel == pnlConvertRevert)
                            pnlDetails.SelectedPanel = pnlDrawingSurface;

                        pnlAcDoc.Enabled = false;
                    }
                    else
                    {
                        pnlRelRecsFields.Enabled = true;
                        pnlConvertRevert.Enabled = true;
                        pnlRelFieldGrid.Closed = false;
                        pnlAcDoc.Enabled = true;
                    }
                }
                else if (CurrentACS().Obsolete && cmdHideObsolete.IsChecked && CurrentACS().ACSeriesId != diagram.SelectedStep.myACS.ACSeriesId && diagram.SelectedStep != null)
                {
                    //binding source set to step that is obsolete, and not drawn on drawing surface
                    //without this condition, there is a mismatch between binding source current, and diagram selected step.
                    aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("ACSeriesId", diagram.SelectedStep.myACS.ACSeriesId);
                    return;
                }

            }




            //reapply blockfilter
            if (chkResetToDisplayAllRelFlds.Checked)
                valueListUpDown1.Value = 100; // ddBlockFilter.SelectedValue = 100;
            else
                ApplyBlockFilter();

            //        //check to see if it is visible first
            //        if(panel1.Width+panel1.HorizontalScroll.Value<s.Right.X)
            //        {
            //            int x = s.Right.X - panel1.Width;
            //            if (x < 0)
            //                x = 0;
            //            panel1.HorizontalScroll.Value = x;
            //        }

            //        if (panel1.HorizontalScroll.Value > s.Left.X)
            //            panel1.HorizontalScroll.Value = s.Left.X;

            //        diagram.drawingSurface.ResetTransform();
            //        diagram.drawingSurface.TranslateTransform(-panel1.HorizontalScroll.Value,- panel1.VerticalScroll.Value);
            //        //diagram.Refresh();
            //        panel1.Refresh();
            //        //if (s.Right.X - pnlDrawSurfaceContainer.HorizontalScroll.Value > pnlDrawSurfaceContainer.Width)
            //        //{
            //        //    int x = s.Right.X - pnlDrawSurfaceContainer.Width;
            //        //    if (x < 0)
            //        //        x = 0;
            //        //    pnlDrawSurfaceContainer.HorizontalScroll.Value = x;
            //        //}
            //        //if (s.Left.X < pnlDrawSurfaceContainer.HorizontalScroll.Value)
            //        //    pnlDrawSurfaceContainer.HorizontalScroll.Value = s.Left.X;

            //        //int y = s.Bottom.Y - pnlDrawSurfaceContainer.Height;
            //        //if (y < 0)
            //        //    y = 0;
            //        //pnlDrawSurfaceContainer.VerticalScroll.Value = y;
            //    }
            //}
        }

        private void NoSeriesData(bool NoData)
        {
            if (NoData)
            {
                cmdCloneSeries.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdProcProp.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdSave.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdCancel.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdDeleteSeries.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdRedraw.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //cmdPrint.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //cmdPreview.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                pnlDetails.Enabled = false;
            }
            else
            {
                cmdCloneSeries.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdProcProp.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdSave.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdCancel.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdDeleteSeries.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdRedraw.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                //cmdPrint.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                //cmdPreview.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                pnlDetails.Enabled = true;
            }
        }

        private void ValidateForContainerFile(bool ContainerFileIdNotNull)
        {
            if (ContainerFileIdNotNull)
            {
                //    oncePerFileUICheckBox.Visible = false;
                //    singleInstancePerFileUICheckBox.Visible = false;
                lnkContainerFileId.Enabled = true;
                atriumBE.FileManager fileMngr = AtMng.GetFile(CurrentSeries().ContainerFileId);

                containerFileIdNumber.Text = fileMngr.CurrentFile.FullFileNumber;
                containerFileidName.Text = fileMngr.CurrentFile.Name;
            }
            else
            {

                if (createsFileUICheckBox.Checked)
                {
                    lnkContainerFileId.Enabled = true;
                    //      oncePerFileUICheckBox.Visible = false;
                    //      singleInstancePerFileUICheckBox.Visible = false;
                }
                else
                {
                    lnkContainerFileId.Enabled = false;
                    //     oncePerFileUICheckBox.Visible = true;
                    //     singleInstancePerFileUICheckBox.Visible = true;
                }

                containerFileIdNumber.Text = "";
                containerFileidName.Text = "";

            }
        }

        private void createsFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Janus.Windows.EditControls.UICheckBox chk = (Janus.Windows.EditControls.UICheckBox)sender;
            if (!chk.Checked)
            {
                if (!CurrentSeries().IsContainerFileIdNull())
                {
                    if (MessageBox.Show("By unchecking the \"Creates File\" checkbox, the value for Container File will be removed automatically.  Are you sure you want to continue?", "Creates File Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        CurrentSeries().SetContainerFileIdNull();
                    }
                    else
                        chk.Checked = true;
                }
                else
                    chk.Checked = false;
            }
            ValidateForContainerFile(!CurrentSeries().IsContainerFileIdNull());
        }

        private void lnkContainerFileId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (fbr == null)
                fbr = new fBrowse(AtMng, 0, false, false, false, true);

            fbr.ShowDialog(this);
            if (fbr.SelectedFile != null)
            {
                CurrentSeries().ContainerFileId = fbr.SelectedFile.FileId;
                seriesBindingSource.ResetCurrentItem();
            }


            ValidateForContainerFile(!CurrentSeries().IsContainerFileIdNull());
        }

        private void seriesBindingSource_PositionChanged(object sender, EventArgs e)
        {
            NoSeriesData(CurrentSeries() == null);
            ValidateForContainerFile(!CurrentSeries().IsContainerFileIdNull());

            if (!FormInitialize)
            {
                if (IsDeletingSeries)
                {
                    SeriesStack.Clear();
                    if (CurrentSeries() != null)
                        SeriesStack.Push(CurrentSeries().SeriesId);
                    else
                        diagram = null;
                    cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    InitDiagram();

                    SeriesStack.Push(CurrentSeries().SeriesId);

                    if (BackButtonSelected) //pop stack
                    {
                        BackButtonSelected = false;
                        if (SeriesStack.Count == 1)
                            cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    }
                    else // add to stack
                    {
                        if (SeriesStack.Count > 1)
                            cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    }
                    ucWorkflowHeader1.SetWorkflow(CurrentSeries());
                }

            }

        }

        DataView dvParentProcesses;
        private void InitDiagram()
        {
            if (diagram == null)
            {
                diagram = new Workflow.Diagram(panel1.CreateGraphics());
            }


            pnlDrawWorkflowContainer.AutoScrollPosition = new Point(0, 0);

            diagram.Reset();
            diagram.DrawMailConnectors = !(cmdHideMail.Checked == Janus.Windows.UI.InheritableBoolean.True);
            diagram.HideObsolete = (cmdHideObsolete.Checked == Janus.Windows.UI.InheritableBoolean.True);
            diagram.DrawBFOnlyConnectors = (cmdShowBfOnly.Checked == Janus.Windows.UI.InheritableBoolean.True);
            diagram.DrawEnableDisableLinkConnectors = (cmdShowEnaDisLinkConnectors.Checked == Janus.Windows.UI.InheritableBoolean.True);

            if (CurrentACS() != null)
            {
                diagram.Draw(CurrentSeries());
                if (diagram.SelectedConnector != null)
                    propertyGrid1.SelectedObject = diagram.SelectedConnector;
                else
                {
                    //if currentacs is not selected step, fix it
                    if (CurrentACS().ACSeriesId != diagram.SelectedStep.myACS.ACSeriesId)
                    {
                        aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("ACSeriesId", diagram.SelectedStep.myACS.ACSeriesId);
                        //return;
                    }
                    else
                        propertyGrid1.SelectedObject = diagram.SelectedStep;
                }
            }
            else
                propertyGrid1.SelectedObject = null;

            pnlDrawingSurface.Activate();
            ShowPanel(pnlPropertyGrid);

            BuildStepMenu();
            resetValidation();

            dvParentProcesses = new DataView(AtMng.acMng.DB.ACSeries, "SubseriesId=" + CurrentSeries().SeriesId, "SeriesDescEng", DataViewRowState.CurrentRows);
            parentProcessGridEx.DataSource = dvParentProcesses;
        }

        public void resetValidation()
        {
            AtMng.acMng.GeWFValidator().Clear();

            cmdErrors.Text = "Errors";
            cmdWarning.Text = "Warnings";
            cmdMessage.Text = "Messages";
            pnlValidationGrid.Closed = true;

        }

        private void ACBFBind()
        {
            if (aCDependencyBindingSource.Current != null)
            {
                lmDatasets.ActivityConfig.ACDependencyRow acdr = (lmDatasets.ActivityConfig.ACDependencyRow)((DataRowView)aCDependencyBindingSource.Current).Row;
                DataView dvd = null;
                if (acdr.IsACBFIdNull())
                {
                    dvd = new DataView(AtMng.acMng.DB.ACBF, "ACBFID is null", "", DataViewRowState.CurrentRows);
                }
                else
                {
                    dvd = new DataView(AtMng.acMng.DB.ACBF, "ACBFID=" + acdr.ACBFId.ToString(), "", DataViewRowState.CurrentRows);
                }
                aCBFBindingSource.DataSource = dvd;
            }

        }
        private void pnlACContainer_Click(object sender, EventArgs e)
        {

        }

        private void btnNewSeries_Click(object sender, EventArgs e)
        {
            lmDatasets.ActivityConfig.SeriesRow sr = AtMng.acMng.DB.Series.NewSeriesRow();
            AtMng.acMng.DB.Series.AddSeriesRow(sr);
            aCSeriesBindingSource.MoveLast();
        }

        private void btnNewACS_Click(object sender, EventArgs e)
        {

        }

        private lmDatasets.ActivityConfig.SeriesRow CurrentSeries()
        {
            if (seriesBindingSource.Current != null)
                return (lmDatasets.ActivityConfig.SeriesRow)((DataRowView)seriesBindingSource.Current).Row;
            else
                return null;
        }

        private lmDatasets.ActivityConfig.ACSeriesRow CurrentACS()
        {
            if (aCSeriesBindingSource.Current != null)
                return (lmDatasets.ActivityConfig.ACSeriesRow)((DataRowView)aCSeriesBindingSource.Current).Row;
            else
                return null;
        }
        private void uiPanelManager1_GroupSelectedPanelChanging(object sender, Janus.Windows.UI.Dock.GroupSelectedPanelChangingEventArgs e)
        {
            //if (!Save())
            //{
            //    e.Cancel = true;

            //}
            if (e.SelectedPanel.Name == "pnlDrawingSurface") //Add other subpanels??
            {
                if (diagram != null)
                    diagram.Refresh();
                ShowPanel(pnlPropertyGrid);
                cmdRedraw.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
            else if (e.SelectedPanel.Name == "pnlFld" || e.SelectedPanel.Name == "pnlNextSteps" || e.SelectedPanel.Name == "pnlACSeries")
            {
                ShowPanel(pnlActivities);
                cmdRedraw.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else if (e.SelectedPanel.Name == "pnlAcDoc")
            {
                //jll: ugly; need a handle to workflow path.
                string sroot = AtMng.AppMan.ServerInfo.helpUrl.Replace("deskbook", "");
                string address = sroot + "workflow/step.aspx?acseriesid=" + CurrentACS().ACSeriesId.ToString();
                ucWB1.webBrowser1.Navigate(address);
                tbAddress.Text = address;
            }


        }

        //private void activityFieldGridEX_DropDown(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        //{
        //    try
        //    {
        //        if (activityFieldBindingSource.Current == null)
        //            return;

        //        //get current arf
        //        //lmDatasets.ActivityConfig.ActivityFieldRow arf = (lmDatasets.ActivityConfig.ActivityFieldRow)((DataRowView)activityFieldBindingSource.Current).Row;

        //        string col = "";
        //        if (e.Column.Key == "FieldName")
        //            col = "ObjectName";
        //        else if (e.Column.Key == "DefaultFieldName")
        //            col = "DefaultObjectName";
        //        if (col == "")
        //            return;

        //        //activityFieldGridEX.UpdateData();
        //        //if (!arf.IsNull(col))
        //        //{
        //        //    DataTable dtTables = Atmng.GetGeneralRec("Select * from vddField where tableName='" + arf[col].ToString() + "'");

        //        //    e.Column.DropDown.SetDataBinding(dtTables.DefaultView, "");
        //        //}

        //        string obj = e.Column.GridEX.CurrentRow.Cells[col].Text;
        //        DataTable dtTables = AtMng.GetGeneralRec("Select * from vddField where tableName='" + obj + "'");

        //        e.Column.DropDown.SetDataBinding(dtTables.DefaultView, "");

        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            if (diagram != null & !suspendPaint)
            {
                diagram.Refresh();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Workflow.Step s = diagram.HitStep(e.Location);

                if (s != null)
                {

                    //don't highlight/select steps that belong to a different series and are drawn as a result of a connector;
                    if (s.myACS.SeriesId != diagram.mySeries.SeriesId)
                        return;

                    diagram.SelectStep(s);
                    aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("AcseriesId", s.myACS.ACSeriesId);

                    if (e.Button == MouseButtons.Right)
                    {
                        uiContextMenu1.Show(panel1, e.Location);
                    }
                    //else if (s.GetType() == typeof(Workflow.SubProcess))
                    //    seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", s.myACS.SeriesId);

                    if (s.myACS.RowState != DataRowState.Detached)
                        propertyGrid1.SelectedObject = s;
                }
                else
                {
                    Workflow.Connector c = diagram.HitConnector(e.Location);
                    if (c != null)
                    {
                        lmDatasets.ActivityConfig.ACSeriesRow acs = c.myACD.ACSeriesRowByNextSteps;
                        aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("AcseriesId", acs.ACSeriesId);
                        aCDependencyBindingSource.Position = aCDependencyBindingSource.Find("ACDependencyId", c.myACD.ACDependencyId);

                        diagram.SelectConnector(c);

                        if (e.Button == MouseButtons.Right)
                        {
                            uiContextMenu2.Show(panel1, e.Location);
                        }

                        if (c.myACD.RowState != DataRowState.Detached)
                            propertyGrid1.SelectedObject = c;
                    }

                    Workflow.Start st = diagram.HitStart(e.Location);
                    if (st != null && e.Button == MouseButtons.Right)
                    {
                        uiContextMenu7.Show(panel1, e.Location);
                    }
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Workflow.Step s = diagram.HitStep(e.Location);
                if (s != null)
                {
                    if (s.GetType() == typeof(Workflow.SubProcess))
                        seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", s.myACS.SubseriesId);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }


        private void ValidateWorkflow()
        {
            if (diagram == null)
                return;

            atriumBE.WFValidator wfv = AtMng.acMng.GeWFValidator();
            wfv.ValidateWF(CurrentSeries());


            //Look for warnings

            //Look for info messages
            cmdErrors.Text = "Errors (" + wfv.ErrorCount.ToString() + ")";
            cmdWarning.Text = "Warnings (" + wfv.WarningCount.ToString() + ")";
            cmdMessage.Text = "Messages (" + wfv.MessageCount.ToString() + ")";

            pnlValidationGrid.Closed = false;
        }
        /// <summary>
        /// Method called to add new used records.
        /// </summary>
        /// <param name="TaskType">Value for TaskType for new record</param>
        /// <param name="skipSetFocus">When set to true, focus is not hijacked by control; which causes issue when called from new SpecialObject method</param>
        /// <returns></returns>
        private ActivityConfig.ActivityFieldRow AddNewUsedRecord(string TaskType, bool skipSetFocus)
        {
            short Block = (short)(int)valueListUpDown1.Value; //ddBlockFilter.SelectedValue;
            ActivityConfig.ActivityFieldRow afr = (ActivityConfig.ActivityFieldRow)AtMng.acMng.GetActivityField().Add(CurrentACS());
            afr.TaskType = TaskType;
            if (Block == 100)
                afr.Step = -10;
            else
                afr.Step = Block;

            if (afr.TaskType == "N" || afr.TaskType == "G" || afr.TaskType == "O" || afr.TaskType == "T" || afr.TaskType == "FL")
                afr.FieldName = "N/A";

            //activityFieldBindingSource.EndEdit();
            activityFieldBindingSource.Position = activityFieldBindingSource.Find("ActivityFieldID", afr.ActivityFieldID);

            //bool recordFound = gridexRecordsUsed.Find(gridexRecordsUsed.RootTable.Columns["ActivityFieldID"], Janus.Windows.GridEX.ConditionOperator.Equal, afr.ActivityFieldID,0,1);
            if (!skipSetFocus)
            {
                if (afr.TaskType == "T")
                    gridexRecordsUsed.CurrentColumn = gridexRecordsUsed.RootTable.Columns["DefaultValue"];
                else
                    gridexRecordsUsed.CurrentColumn = gridexRecordsUsed.RootTable.Columns["ObjectName"];
                gridexRecordsUsed.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                gridexRecordsUsed.Focus();
            }
            return afr;
        }

        private void AddAFRowToClipboard(List<ActivityConfig.ActivityFieldRow> afr)
        {
            if (AFClipboard == null)
            {
                AFClipboard = new ActivityConfig.ActivityFieldDataTable();
                btnRelFieldsClipboard.Enabled = true;
                gridexAFClipboard.DataSource = AFClipboard;
            }
            if (AFClipboard.Rows.Count == 0)
                btnRelFieldsClipboard.Enabled = true;

            foreach (ActivityConfig.ActivityFieldRow row in afr)
            {
                ActivityConfig.ActivityFieldRow afrn = AFClipboard.NewActivityFieldRow();
                afrn.ItemArray = row.ItemArray;
                afrn.DefaultSystemValue = CurrentACS().StepCode;
                try
                {
                    AFClipboard.AddActivityFieldRow(afrn);
                }
                catch (Exception x)
                {
                    throw new Exception("There was an error attempting to copy a row to the clipboard.  One of the rows you are trying to add might already be present in the list\n\n" + x.Message);
                }
            }

            updateClipboardCount();

        }

        private void updateClipboardCount()
        {
            btnRelFieldsClipboard.Text = "Clipboard (" + AFClipboard.Rows.Count + ")";
        }

        //JLL: 2013-09 Related Fields Layout Change
        private List<ActivityConfig.ActivityFieldRow> getSelectedACFieldRowFromGridex(Janus.Windows.GridEX.GridEX grd)
        {
            List<ActivityConfig.ActivityFieldRow> lstArf = new List<ActivityConfig.ActivityFieldRow>();
            foreach (Janus.Windows.GridEX.GridEXSelectedItem gsi in grd.SelectedItems)
            {
                ActivityConfig.ActivityFieldRow afr;
                if (gsi.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    afr = (ActivityConfig.ActivityFieldRow)((DataRowView)gsi.GetRow().DataRow).Row;
                    if (afr != null)
                        lstArf.Add(afr);
                }
            }
            return lstArf;

        }


        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdLegend":
                        pnlLegend.Closed = !cmdLegend.IsChecked;
                        break;
                    case "cmdRelFieldToClipboard":
                        List<ActivityConfig.ActivityFieldRow> afr = getSelectedACFieldRowFromGridex(gridexRelatedFields);
                        AddAFRowToClipboard(afr);
                        break;
                    case "cmdUsedRecordToClipboard":
                        List<ActivityConfig.ActivityFieldRow> afr2 = getSelectedACFieldRowFromGridex(gridexRecordsUsed);
                        AddAFRowToClipboard(afr2);
                        break;
                    case "cmdQueryOrNew":
                        AddNewUsedRecord("C", false);
                        break;
                    case "cmdSelectOrNew":
                        AddNewUsedRecord("SN", false);
                        break;
                    case "cmdMostRecent":
                        AddNewUsedRecord("M", false);
                        break;
                    case "cmdNewRecord":
                        AddNewUsedRecord("N", false);
                        break;
                    case "cmdNewGetRecord":
                        AddNewUsedRecord("G", false);
                        break;
                    case "cmdDeleteRec":
                        AddNewUsedRecord("D", false);
                        break;
                    case "cmdQueriedRecord":
                        AddNewUsedRecord("Q", false);
                        break;
                    case "cmdRepeatForBlock":
                        AddNewUsedRecord("R", false);
                        break;
                    case "cmdCondBlock":
                        AddNewUsedRecord("Z", false);
                        break;
                    case "cmdAtLeastOne":
                        AddNewUsedRecord("U", false);
                        break;
                    case "cmdSelectRecords":
                        AddNewUsedRecord("S", false);
                        break;
                    case "cmdNewIncludeUsedRecord":
                        AddNewUsedRecord("T", false);
                        break;
                    case "cmdLoadRecords":
                        AddNewUsedRecord("L", false);
                        break;
                    case "cmdSortBy":
                        AddNewUsedRecord("SB", false);
                        break;
                    case "cmdSwitchFM":
                        AddNewUsedRecord("FL", false);
                        break;
                    case "cmdValidateWorkflow":
                        ValidateWorkflow();
                        break;
                    case "cmdShowBfOnly":
                    case "cmdHideObsolete":
                    case "cmdHideMail":
                    case "cmdShowEnaDisLinkConnectors":
                        InitDiagram();

                        break;
                    case "cmdConnectorBFOnly":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.BFOnly;
                        InitDiagram();
                        break;
                    case "cmdAuto":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Auto;
                        InitDiagram();
                        break;
                    case "cmdConnectorDisable":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Disable;
                        InitDiagram();
                        break;
                    case "cmdConnectorTransfer":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Transfer;
                        InitDiagram();
                        break;

                    case "cmdConnectorEnable":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Enable;
                        InitDiagram();
                        break;
                    case "cmdConnectorNextStep":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.NextStep;
                        InitDiagram();
                        break;
                    case "cmdAnswer":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Answer;
                        InitDiagram();
                        break;
                    case "cmdConnectorForward":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Forward;
                        break;
                    case "cmdConnectorReply":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Reply;
                        break;
                    case "cmdConnectorObsolete":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.Obsolete;
                        InitDiagram();
                        break;
                    case "cmdConnectorReplyAll":
                        diagram.SelectedConnector.myACD.LinkType = (int)atriumBE.ConnectorType.ReplyAll;
                        break;
                    case "cmdDeleteSeries":
                        try
                        {
                            fwait.resetForm();
                            fwait.setMessageText("Verifying if OK to Delete, please wait.");
                            fwait.Show();
                            fwait.Refresh();
                            bool CantDelete = false;
                            string CantDeleteMessage = "Workflow " + CurrentSeries().SeriesCode + " (" + CurrentSeries().SeriesDescEng + ") cannot be deleted.  The following activities have been used in " + AtMng.AppMan.AppName + ":\n\n";
                            foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in AtMng.acMng.DB.ACSeries.Select("seriesid=" + CurrentSeries().SeriesId, "stepcode"))
                            {
                                if (acsr.StepType == (int)atriumBE.StepType.Activity)
                                {
                                    DataTable dt = AtMng.GetGeneralRec("select count(activityid) from vactivity where acseriesid=" + acsr.ACSeriesId.ToString());
                                    if (Int32.Parse(dt.Rows[0][0].ToString()) > 0)
                                    {
                                        CantDelete = true;
                                        string desc, stimes;
                                        if (acsr.IsDescEngNull())
                                            desc = " (" + acsr.ActivityCodeRow.ActivityNameEng + ") ";
                                        else
                                            desc = " (" + acsr.ActivityCodeRow.ActivityNameEng + ": " + acsr.DescEng + ") ";
                                        if (Int32.Parse(dt.Rows[0][0].ToString()) == 1)
                                            stimes = " time";
                                        else
                                            stimes = " times";
                                        CantDeleteMessage += acsr.StepCode + desc + "used " + dt.Rows[0][0].ToString() + stimes + ".\n";
                                    }
                                }
                            }
                            fwait.Hide();

                            if (CantDelete)
                            {
                                CantDeleteMessage += "\nMake the Workflow Obsolete to hide it from " + AtMng.AppMan.AppName + ".";
                                MessageBox.Show(CantDeleteMessage, "Workflow Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (MessageBox.Show("You are about to delete an entire series.\n\n  As a result of this delete, a save operation will occur,  saving all other edits (to all records).  Are you sure you want to proceed?", "Delete Entire Series", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                fwait.resetForm();
                                fwait.setMessageText("Deleting entire series, please wait.");
                                fwait.Show();
                                fwait.Refresh();



                                IsDeletingSeries = true;
                                CurrentSeries().Delete();
                                IsDeletingSeries = false;


                                atLogic.BusinessProcess bp = AtMng.GetBP();

                                bp.AddForUpdate(AtMng.acMng.GetActivityField());
                                bp.AddForUpdate(AtMng.acMng.GetACDependency());
                                bp.AddForUpdate(AtMng.acMng.GetACBF());
                                bp.AddForUpdate(AtMng.acMng.GetACConvert());
                                bp.AddForUpdate(AtMng.acMng.GetACSeries());
                                bp.AddForUpdate(AtMng.acMng.GetSeries());
                                bp.Update();

                                InitDiagram();

                                fwait.Hide();
                            }
                        }
                        catch (Exception x)
                        {
                            fwait.Hide();
                            fwait.resetForm();
                            UIHelper.HandleUIException(x);
                        }
                        break;
                    case "cmdAcSeriesObsolete":
                        lmDatasets.ActivityConfig.ACSeriesRow acsrObs = diagram.SelectedStep.myACS;
                        acsrObs.Obsolete = true;
                        InitDiagram();
                        break;
                    case "cmdDeleteStep":
                        DeleteStep();
                        break;
                    case "cmdDeleteCon":
                        //if (diagram.SelectedConnector.myACD.ACSeriesRowByPreviousSteps.GetACDependencyRowsByPreviousSteps().Length == 1 & diagram.SelectedConnector.myACD.ACSeriesRowByPreviousSteps.s)
                        //    MessageBox.Show("You can't delete the last connector");
                        //else
                        //{
                        try
                        {
                            if (MessageBox.Show("WARNING!\n\nYou are about to delete a Connector that might be in use in PROD. This operation cannot be undone. You must ensure this connector has never been used in PROD before proceeding with this delete! If the Connector is in use in PROD, make the connector obsolete instead of attempting to delete it.\n\nAre you sure you want to delete this connector?", "BF Connector Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                            {
                                lmDatasets.ActivityConfig.ACDependencyRow acdr1 = diagram.SelectedConnector.myACD;
                                diagram.Reset();
                                diagram.ClearSelectedObject();
                                diagram = null;

                                Save();

                                if (diagram != null)
                                {
                                    diagram.Reset();
                                    diagram.ClearSelectedObject();
                                    diagram = null;
                                }
                                propertyGrid1.SelectedObject = null;


                                acdr1.Delete();

                                atLogic.BusinessProcess bp = AtMng.GetBP();

                                bp.AddForUpdate(AtMng.acMng.GetACDependency());
                                bp.Update();

                                InitDiagram();
                            }
                        }
                        catch (Exception x)
                        {

                            UIHelper.HandleUIException(x);
                        }
                        //}
                        break;
                    //case "cmdPrint":
                    //    printDialog1.ShowDialog(this);
                    //    break;

                    //case "cmdPreview":
                    //    printPreviewDialog1.Show(this);
                    //    break;
                    case "cmdSaveAsImg":
                        saveFileDialog1.Filter = "BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
                        string vFname = this.CurrentSeries().SeriesDescEng.Replace("/", "-");
                        saveFileDialog1.FileName = vFname + ".bmp";
                        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string saveas = saveFileDialog1.FileName;
                            diagram.SaveAsImg(saveas);
                        }
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdCancel":
                        Cancel();
                        break;
                    case "cmdProcProp":
                        ShowPanel(pnlSeriesDetails);
                        break;
                    case "cmdBack":
                        SeriesStack.Pop(); // remove current series;
                        int SeriesId = (int)SeriesStack.Pop(); //return previous series
                        BackButtonSelected = true;
                        seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", SeriesId);
                        break;
                    case "cmdRedraw":
                        diagram.Refresh();
                        break;
                    case "cmdCloneSeries":
                        if (MessageBox.Show("This will create a clone of the currently selected workflow.  Are you sure you want to proceed?", "Clone Workflow", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            AtMng.acMng.GetSeries().Clone(CurrentSeries());
                        break;
                    case "cmdDecisionNewSeries": //New Series starts on Decision
                        NewSeries(null, atriumBE.StepType.Decision);
                        break;
                    case "cmdNonRecordedNewSeries": //New Series starts on non-recorded activity
                        NewSeries(null, atriumBE.StepType.NonRecorded);
                        break;
                    case "cmdReloadContainer":
                        BuildActivityCodeList(cmdNewSeriesActivity, "NewSeries");
                        BuildActivityCodeList(cmdWFActivity2, "NextStep");
                        BuildStepMenu();
                        BuildBFOnlyMailConnectorsActivityList();
                        break;

                }

                if (e.Command.Key.StartsWith("cmdNewSO")) //add new special object
                {
                    AddNewSpecialObjectRow(e.Command.Text);
                }

                if (e.Command.Key.StartsWith("ActivityCodeNewSeries"))         //New Series OR New Next Step
                {
                    NewSeries((lmDatasets.ActivityConfig.ActivityCodeRow)e.Command.Tag, atriumBE.StepType.Activity);
                }
                else if (e.Command.Key.StartsWith("NewActivityCodeNextStep"))
                {
                    fNewAC fnac = new fNewAC();
                    fnac.MyAtmng = this.AtMng;

                    fnac.ShowDialog(this);
                    if (fnac.NewAC != null)
                    {
                        //create new acseries record
                        lmDatasets.ActivityConfig.ACSeriesRow newAcsr = (lmDatasets.ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
                        newAcsr.ActivityCodeID = fnac.NewAC.ActivityCodeID;

                        diagram.AddStep(newAcsr);

                        AddNewNextStep(atriumBE.StepType.Activity, diagram.mySteps[diagram.GetStepKey(newAcsr)]);
                    }
                    fnac.Close();
                }
                else if (e.Command.Key.StartsWith("ActivityCodeNextStep"))
                {
                    //create new acseries record
                    lmDatasets.ActivityConfig.ACSeriesRow newAcsr = (lmDatasets.ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
                    newAcsr.ActivityCodeID = ((lmDatasets.ActivityConfig.ActivityCodeRow)e.Command.Tag).ActivityCodeID;

                    diagram.AddStep(newAcsr);

                    AddNewNextStep(atriumBE.StepType.Activity, diagram.mySteps[diagram.GetStepKey(newAcsr)]);

                }
                else if (e.Command.Key.StartsWith("ActivityCodeNewStart"))
                {
                    //create new acseries record
                    lmDatasets.ActivityConfig.ACSeriesRow newAcsr = (lmDatasets.ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
                    newAcsr.ActivityCodeID = ((lmDatasets.ActivityConfig.ActivityCodeRow)e.Command.Tag).ActivityCodeID;
                    newAcsr.StepType = (int)atriumBE.StepType.Activity;
                    diagram.AddStep(newAcsr);
                    aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("ACSeriesId", newAcsr.ACSeriesId);
                    diagram.Draw(CurrentSeries());
                    //AddNewStart(newAcsr, atriumBE.StepType.Activity);

                }
                else if (e.Command.Key.StartsWith("cmdNewStartWFDecision"))
                {
                    lmDatasets.ActivityConfig.ACSeriesRow newAcsr = (lmDatasets.ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
                    newAcsr.ActivityCodeID = -1;
                    newAcsr.StepType = (int)atriumBE.StepType.Decision;
                    diagram.AddStep(newAcsr);
                    aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("ACSeriesId", newAcsr.ACSeriesId);
                    diagram.Draw(CurrentSeries());
                }
                else if (e.Command.Key.StartsWith("cmdNewStartWFNoActivity"))
                {
                    lmDatasets.ActivityConfig.ACSeriesRow newAcsr = (lmDatasets.ActivityConfig.ACSeriesRow)AtMng.acMng.GetACSeries().Add(CurrentSeries());
                    newAcsr.ActivityCodeID = -2;
                    newAcsr.StepType = (int)atriumBE.StepType.NonRecorded;
                    diagram.AddStep(newAcsr);
                    aCSeriesBindingSource.Position = aCSeriesBindingSource.Find("ACSeriesId", newAcsr.ACSeriesId);
                    diagram.Draw(CurrentSeries());
                }
                else if (e.Command.Key.StartsWith("cmdNewRelFld"))
                {
                    //string objectalias  = (string)e.Command.Tag;
                    //string table = e.Command.Key.Substring("cmdNewRelFld".Length);
                    string objectalias = e.Command.Key.Substring("cmdNewRelFld".Length);
                    string table = (string)e.Command.Tag; 

                    fSelectRelatedFields fSel = new fSelectRelatedFields(AtMng, table, objectalias);
                    DialogResult dr = fSel.ShowDialog(this);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        int lastAfrID = 0;
                        foreach (Janus.Windows.GridEX.GridEXRow gr in fSel.checkedRows)
                        {
                            appDB.ddFieldRow ddf = (appDB.ddFieldRow)((DataRowView)gr.DataRow).Row;
                            lastAfrID = UIHelper.AddDDFieldAsActivityFieldRow(ddf, CurrentACS(), objectalias, table, (short)(int)valueListUpDown1.Value);
                        }

                        if (gridexRelatedFields.Find(gridexRelatedFields.RootTable.Columns["ActivityFieldID"], Janus.Windows.GridEX.ConditionOperator.Equal, lastAfrID, 0, 1) && lastAfrID != 0)
                        {
                            gridexRecordsUsed.CurrentColumn = gridexRecordsUsed.RootTable.Columns["FieldName"];
                            gridexRecordsUsed.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                            gridexRecordsUsed.Focus();
                        }
                    }

                }

                //else if (e.Command.Key.StartsWith("cmdNewRelFld"))
                //{
                //    if (e.Command.Key != "cmdNewRelFld")
                //    {
                //        UIHelper.AddDDFieldsAsActivityFieldRows((string)e.Command.Tag, AtMng.acMng.GetActivityField().InstanceMax(CurrentACS(), (string)e.Command.Tag), CurrentACS(), AtMng);
                //        //RefetchRelInfoGrids();
                //    }

                //}
                else if (e.Command.Key.StartsWith("BFMailActivity"))
                {
                    AddNewBFMailConnector((lmDatasets.ActivityConfig.ACSeriesRow)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdWFNoActivity"))
                {
                    if (e.Command.Key.EndsWith("FORM"))
                    {
                     
                            AddNewNextStep(atriumBE.StepType.Form, (Workflow.Step)e.Command.Tag);
                    }
                    else if (e.Command.Key.EndsWith("RULE"))
                    {
                            AddNewNextStep(atriumBE.StepType.Rule, (Workflow.Step)e.Command.Tag);
                    }
                    else if (e.Command.Key.EndsWith("ACTION"))
                    {
                            AddNewNextStep(atriumBE.StepType.Action, (Workflow.Step)e.Command.Tag);
                    }
                    else
                    {
                            AddNewNextStep(atriumBE.StepType.NonRecorded, (Workflow.Step)e.Command.Tag);
                    }
                }
                else if (e.Command.Key.StartsWith("cmdWFDecision"))
                {
                    AddNewNextStep(atriumBE.StepType.Decision, (Workflow.Step)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdWFWait"))
                {
                    AddNewNextStep(atriumBE.StepType.Merge, (Workflow.Step)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdWFBranch"))
                {
                    AddNewNextStep(atriumBE.StepType.Branch, (Workflow.Step)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdWFActivity"))
                {

                    AddNewNextStep(atriumBE.StepType.Activity, (Workflow.Step)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdWFSubProcess"))
                {
                    AddNewNextStep(atriumBE.StepType.Subseries, (Workflow.Step)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdMoveStep"))
                {
                    AddNewNextStep(atriumBE.StepType.Move, (Workflow.Step)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdConvert"))
                {
                    AddNewNextStep(atriumBE.StepType.Convert, (Workflow.Step)e.Command.Tag);
                }
                else if (e.Command.Key.StartsWith("cmdSendToSubProcess"))
                {
                    AddNewNextStepSeries(atriumBE.StepType.Subseries, (lmDatasets.ActivityConfig.SeriesRow)e.Command.Tag);

                }

            }
            catch (Exception x)
            {
                fwait.Hide();
                fwait.resetForm();
                UIHelper.HandleUIException(x);
            }
        }

        private void DeleteStep()
        {
            try
            {
                //if (diagram.SelectedStep.GetType() == typeof(Workflow.SubProcess))
                //{
                //    MessageBox.Show("Select the connector and delete it.");
                //}
                if (diagram.SelectedStep.myACS.GetACDependencyRowsByNextSteps().Length > 0)
                {
                    MessageBox.Show("You can't delete a node step");
                }
                else if (MessageBox.Show("You are about to delete your selection.  As a result of a delete, a save operation will occur,  saving all other edits (to all records).  Are you sure you want to proceed?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    fwait.resetForm();
                    fwait.setMessageText("Deleting step, please wait.");
                    fwait.Show();
                    fwait.Refresh();


                    lmDatasets.ActivityConfig.ACSeriesRow acsr1 = diagram.SelectedStep.myACS;

                    diagram.Reset();
                    diagram.ClearSelectedObject();
                    diagram = null;


                    IsDeletingStep = true;
                    Save();
                    IsDeletingStep = false;


                    bool acSeriesDeleteFailed = false;
                    try
                    {
                        if (diagram != null)
                        {
                            diagram.Reset();
                            diagram.ClearSelectedObject();
                            diagram = null;
                        }
                        propertyGrid1.SelectedObject = null;
                        acsr1.Delete();
                    }
                    catch (Exception x2)
                    {
                        acSeriesDeleteFailed = true;

                        InitDiagram();
                        fwait.Hide();
                        fwait.resetForm();
                        MessageBox.Show("Deleting the Workflow Step has failed.  Make the Step Obsolete.\n\n" + x2.Message);
                    }
                    if (!acSeriesDeleteFailed)
                    {

                        atLogic.BusinessProcess bp = AtMng.GetBP();

                        bp.AddForUpdate(AtMng.acMng.GetACSeries());
                        bp.AddForUpdate(AtMng.acMng.GetActivityField());
                        bp.AddForUpdate(AtMng.acMng.GetACBF());
                        bp.AddForUpdate(AtMng.acMng.GetACDependency());
                        bp.AddForUpdate(AtMng.acMng.GetACConvert());

                        bp.Update();

                        InitDiagram();

                        fwait.Hide();
                        fwait.resetForm();
                    }
                }
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }


        private void uiPanelManager1_PanelActivated(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {

        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                diagram.drawingSurface.ResetTransform();
                diagram.drawingSurface.TranslateTransform(-panel1.HorizontalScroll.Value, -panel1.VerticalScroll.Value);
                diagram.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Janus.Windows.GridEX.EditControls.MultiColumnCombo mcc = mccACS;
                Janus.Windows.GridEX.EditControls.MultiColumnCombo mcc = mccPresetRelFields;

                if (mcc.Value == null)
                {
                    MessageBox.Show("Please select a valid activity from which related fields can be copied before clicking Add or Replace");
                    return;
                }
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                if (btn.Name == "uiButton6") // replace fields
                    AtMng.acMng.GetACSeries().ReplaceRelFields(CurrentACS(), AtMng.acMng.DB.ACSeries.FindByACSeriesId((int)mcc.Value), true);
                else if (btn.Name == "uiButton7")
                    AtMng.acMng.GetACSeries().ReplaceRelFields(CurrentACS(), AtMng.acMng.DB.ACSeries.FindByACSeriesId((int)mcc.Value), false);

                mcc.SelectedIndex = -1;
                //gridexRecordsUsed.UpdateData();
                //gridexRelatedFields.UpdateData();
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void btnNewRelField_Click(object sender, EventArgs e)
        {
            try
            {
                //uiContextMenu3.Show((Control)sender, btnNewRelField.Location.X, btnNewRelField.Location.Y);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Workflow.Diagram d = new Workflow.Diagram(e.Graphics);
                d.Draw(CurrentSeries());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true;

        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

            diagram.Refresh();

        }


        private void BuildRelatedFieldsList()
        {

            //Janus.Windows.UI.CommandBars.UICommand uc = null;
            //foreach (lmDatasets.appDB.ddTableRow ddtr in AtMng.DB.ddTable.Select("AllowInRelatedFields=1", "TableName"))
            //{
            //    uc = new Janus.Windows.UI.CommandBars.UICommand("cmdNewRelFld" + ddtr.TableName);
            //    uc.Text = ddtr.TableName;
            //    uc.Tag = ddtr.TableName;
            //    if (!ddtr.IsDescriptionEngNull())
            //        uc.ToolTipText = ddtr.DescriptionEng;
            //    uiCommandManager1.ContextMenus["ContextMenuAllRelatedInfo"].Commands.Add(uc);
            //}
            //uiCommandManager1.ContextMenus["ContextMenuAllRelatedInfo"].ShowToolTips = Janus.Windows.UI.InheritableBoolean.True;
        }

        private void BuildActivityCodeList(Janus.Windows.UI.CommandBars.UICommand cmd, string key)
        {

            int i;
            for (i = 0; i <= cmd.Commands.Count - 1; i++)
            {
                cmd.Commands[i].Commands.Clear();
            }
            cmd.Commands.Clear();

            Janus.Windows.UI.CommandBars.UICommand ucm = null;
            Janus.Windows.UI.CommandBars.UICommand uc = null;

            foreach (lmDatasets.ActivityConfig.ACMajorRow acmr in AtMng.acMng.DB.ACMajor.Select("", "ActivityCodeMajor"))
            {
                ucm = new Janus.Windows.UI.CommandBars.UICommand("ACMAjor" + key + acmr.ActivityCodeMajor);
                ucm.Text = acmr.ACMajorDescEng; //acmr.ActivityCodeMajor + " - " + 
                cmd.Commands.Add(ucm);
                foreach (lmDatasets.ActivityConfig.ActivityCodeRow acr in AtMng.acMng.DB.ActivityCode.Select("ACMajorCode='" + acmr.ActivityCodeMajor + "'", "ActivityCode"))
                {

                    uc = new Janus.Windows.UI.CommandBars.UICommand("ActivityCode" + key + acr.ActivityCodeID.ToString());
                    uc.Text = acr.ActivityCode + " - " + acr.ActivityNameEng;
                    uc.Image = cmdWFActivity.Image;
                    uc.Tag = acr;
                    ucm.Commands.Add(uc);
                }
            }
        }

        private void BuildBFOnlyMailConnectorsActivityList()
        {
            Janus.Windows.UI.CommandBars.UICommand cmdConnectorSeriesType = null;
            Janus.Windows.UI.CommandBars.UICommand cmdConnectorSeries = null;
            Janus.Windows.UI.CommandBars.UICommand cmdConnectorActivity = null;

            int i, y;
            for (i = 0; i <= cmdGoToBFOnly.Commands.Count - 1; i++)
            {
                for (y = 0; y <= cmdGoToBFOnly.Commands[i].Commands.Count - 1; y++)
                {
                    cmdGoToBFOnly.Commands[i].Commands[y].Commands.Clear();
                }
                cmdGoToBFOnly.Commands[i].Commands.Clear();
            }
            cmdGoToBFOnly.Commands.Clear();

            foreach (lmDatasets.CodesDB.SeriesTypeRow str in AtMng.CodeDB.SeriesType.Select("", "SeriesTypeCode"))
            {
                ActivityConfig.SeriesRow[] srs = (ActivityConfig.SeriesRow[])AtMng.acMng.DB.Series.Select("SeriesTypeCode='" + str.SeriesTypeCode + "' and Status<>'OBS'", "SeriesCode");
                if (srs.Length > 0)
                {
                    cmdConnectorSeriesType = new Janus.Windows.UI.CommandBars.UICommand("BFMailSeriesTypeContainer" + str.SeriesTypeCode);
                    cmdConnectorSeriesType.Text = str.SeriesTypeDescriptionEng;
                    cmdGoToBFOnly.Commands.Add(cmdConnectorSeriesType);

                    foreach (lmDatasets.ActivityConfig.SeriesRow sr in srs)
                    {
                        ActivityConfig.ACSeriesRow[] acsrs = (ActivityConfig.ACSeriesRow[])AtMng.acMng.DB.ACSeries.Select("SeriesId=" + sr.SeriesId + " and StepType=" + (int)atriumBE.StepType.Activity + " and Obsolete=false", "StepCode");
                        if (acsrs.Length > 0)
                        {
                            cmdConnectorSeries = new Janus.Windows.UI.CommandBars.UICommand(cmdConnectorSeriesType.Key + sr.SeriesId.ToString());
                            cmdConnectorSeries.Text = sr.SeriesCode + " - " + sr.SeriesDescEng;
                            cmdConnectorSeriesType.Commands.Add(cmdConnectorSeries);

                            foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in acsrs)
                            {
                                cmdConnectorActivity = new Janus.Windows.UI.CommandBars.UICommand("BFMailActivity" + acsr.ACSeriesId);
                                cmdConnectorActivity.Text = AtMng.acMng.GetACSeries().GetNodeText(acsr, atriumBE.StepType.Activity, false);
                                cmdConnectorActivity.Tag = acsr;
                                cmdConnectorActivity.Image = Properties.Resources.Calendar;
                                cmdConnectorSeries.Commands.Add(cmdConnectorActivity);
                            }
                        }
                    }
                }
            }
        }

        private void BuildExistingStepMenu()
        {
            Janus.Windows.UI.CommandBars.UICommand uc = null;
            cmdPickFromExistingStep.Commands.Clear();
            cmdPickFromExistingStep2.Enabled = Janus.Windows.UI.InheritableBoolean.True;

            foreach (Workflow.Step s in diagram.mySteps.Values)
            {
                if (s.myACS.ACSeriesId != CurrentACS().ACSeriesId) //dont add reference to itself
                {
                    uc = null;

                    if (s.GetType() == typeof(Workflow.Activity))
                    {
                        uc = new Janus.Windows.UI.CommandBars.UICommand(cmdWFActivity.Key + s.myACS.ACSeriesId.ToString());
                        uc.Text = AtMng.acMng.GetACSeries().GetNodeText(s.myACS, (atriumBE.StepType)s.myACS.StepType, false);
                        uc.Image = Properties.Resources.act;
                    }
                    else if (s.GetType() == typeof(Workflow.NonRecorded))
                    {
                        uc = new Janus.Windows.UI.CommandBars.UICommand(cmdWFNoActivity.Key + s.myACS.ACSeriesId.ToString());
                        uc.Text = AtMng.acMng.GetACSeries().GetNodeText(s.myACS, (atriumBE.StepType)s.myACS.StepType, false) + " (" + s.myACS.StepCode + ")";
                        uc.Image = cmdWFNoActivity.Image;
                    }
                    else if (s.GetType() == typeof(Workflow.Decision))
                    {
                        uc = new Janus.Windows.UI.CommandBars.UICommand(cmdWFDecision.Key + s.myACS.ACSeriesId.ToString());
                        uc.Text = AtMng.acMng.GetACSeries().GetNodeText(s.myACS, (atriumBE.StepType)s.myACS.StepType, false) + " (" + s.myACS.StepCode + ")";
                        uc.Image = cmdWFDecision.Image;
                    }
                    else if (s.GetType() == typeof(Workflow.Wait))
                    {
                        uc = new Janus.Windows.UI.CommandBars.UICommand(cmdWFWait.Key + s.myACS.ACSeriesId.ToString());
                        uc.Text = AtMng.acMng.GetACSeries().GetNodeText(s.myACS, (atriumBE.StepType)s.myACS.StepType, false);
                        uc.Image = cmdWFWait.Image;
                    }
                    else if (s.GetType() == typeof(Workflow.Branch))
                    {
                        uc = new Janus.Windows.UI.CommandBars.UICommand(cmdWFBranch.Key + s.myACS.ACSeriesId.ToString());
                        uc.Text = AtMng.acMng.GetACSeries().GetNodeText(s.myACS, (atriumBE.StepType)s.myACS.StepType, false);
                        uc.Image = cmdWFBranch.Image;
                    }
                    else if (s.GetType() == typeof(Workflow.SubProcess))
                    {
                        uc = new Janus.Windows.UI.CommandBars.UICommand(cmdWFSubProcess.Key + s.myACS.ACSeriesId.ToString());
                        uc.Text = AtMng.acMng.GetACSeries().GetNodeText(s.myACS, (atriumBE.StepType)s.myACS.StepType, false) + " (" + s.myACS.StepCode + ")";
                        uc.Image = cmdWFSubProcess.Image;
                    }

                    if (uc != null)
                    {
                        uc.Tag = s;
                        cmdPickFromExistingStep2.Commands.Add(uc);
                    }
                }
            }
            if (cmdPickFromExistingStep2.Commands.Count == 0)
                cmdPickFromExistingStep2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        private void BuildStepMenu()
        {
            Janus.Windows.UI.CommandBars.UICommand ucm = null;
            Janus.Windows.UI.CommandBars.UICommand uc = null;

            int i;
            for (i = 0; i <= cmdSendToSubProcess.Commands.Count - 1; i++)
            {
                cmdSendToSubProcess.Commands[i].Commands.Clear();
            }

            cmdSendToSubProcess.Commands.Clear();


            foreach (lmDatasets.CodesDB.SeriesTypeRow srt in AtMng.CodeDB.SeriesType.Select("", "SeriesTypeCode"))
            {
                ActivityConfig.SeriesRow[] srs = (ActivityConfig.SeriesRow[])AtMng.acMng.DB.Series.Select("SeriesTypeCode='" + srt.SeriesTypeCode + "' and Status<>'OBS'", "SeriesCode");
                if (srs.Length > 0)
                {
                    ucm = new Janus.Windows.UI.CommandBars.UICommand("WorkflowCode" + srt.SeriesTypeCode);
                    ucm.Text = srt.SeriesTypeDescriptionEng;
                    cmdSendToSubProcess.Commands.Add(ucm);

                    foreach (lmDatasets.ActivityConfig.SeriesRow sr in srs)
                    {
                        uc = new Janus.Windows.UI.CommandBars.UICommand(cmdSendToSubProcess.Key + sr.SeriesId.ToString());
                        uc.Text = sr.SeriesCode + " - " + sr.SeriesDescEng;
                        uc.Image = cmdSendToSubProcess.Image;
                        uc.Tag = sr;
                        ucm.Commands.Add(uc);
                    }
                }
            }


        }

        bool suspendPaint = false;
        private void pnlDrawSurfaceContainer_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (e.Type == ScrollEventType.ThumbTrack)
                    suspendPaint = false;

                if (e.Type == ScrollEventType.ThumbPosition)
                {
                    suspendPaint = false;
                    diagram.Refresh();
                }
                //if (e.Type == ScrollEventType.LargeDecrement || e.Type== ScrollEventType.LargeIncrement)
                //{
                //    diagram.Refresh();
                //    suspendPaint = false;
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void parentProcessGridEx_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                string seriesid = parentProcessGridEx.CurrentRow.Cells[e.Column].Text;
                seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", Convert.ToInt32(seriesid));
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void aCDependencyGridEX_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "ACBFId")
                {
                    e.Column.GridEX.UpdateData();
                    aCDependencyBindingSource.EndEdit();
                    ACBFBind();
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnAddNewConvert_Click(object sender, EventArgs e)
        {
            try
            {
                lmDatasets.ActivityConfig.ACConvertRow newConvert = (lmDatasets.ActivityConfig.ACConvertRow)AtMng.acMng.GetACConvert().Add(CurrentACS());
                newConvert.ACSeriesId = CurrentACS().ACSeriesId;
                newConvert.SetAllowableACSeriesIdNull();
                aCConvertBindingSource.Position = aCConvertBindingSource.Find("Id", newConvert.Id);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void btnAddNewRevert_Click(object sender, EventArgs e)
        {
            try
            {
                lmDatasets.ActivityConfig.ACConvertRow newRevert = (lmDatasets.ActivityConfig.ACConvertRow)AtMng.acMng.GetACConvert().Add(CurrentACS());
                newRevert.AllowableACSeriesId = CurrentACS().ACSeriesId;
                newRevert.SetACSeriesIdNull();
                acRevertBindingSource.Position = acRevertBindingSource.Find("Id", newRevert.Id);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        //private void btnRelInfoNewRecord_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ActivityConfig.ActivityFieldRow afr = (ActivityConfig.ActivityFieldRow)AtMng.acMng.GetActivityField().Add(CurrentACS());
        //        afr.Step = -10;
        //        afr.TaskType = "N";
        //        activityFieldBindingSource.Position = activityFieldBindingSource.Find("ActivityFieldID", afr.ActivityFieldID);
        //        relatedInfoNewRecordsGridEx.Refetch();
        //        relatedInfoNewRecordsGridEx.MoveToNewRecord();
        //    }
        //    catch (Exception x)
        //    {

        //        UIHelper.HandleUIException(x);
        //    }
        //}

        //private void RefetchRelInfoGrids()
        //{
        //    //  relatedInfoNewRecordsGridEx.Refetch();
        //    // relatedInfoBillingGridEx.Refetch();
        //    //relatedInfoDocumentGridEx.Refetch();
        //    // relatedInfoFieldsGridEx.Refetch();
        //}

        //private void activityFieldGridEX_CellEdited(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        //{
        //    e.Column.GridEX.UpdateData();
        //    RefetchRelInfoGrids();
        //}

        private void aCConvertGridEX_DeletingRecords(object sender, CancelEventArgs e)
        {
            try
            {
                if (UIHelper.ConfirmDelete() == false)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityFieldBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }


        //private void activityFieldGridEX_SelectionChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ActivityConfig.ActivityFieldRow afr = null;
        //        Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;

        //        if (g.CurrentRow != null && g.CurrentRow.DataRow != null)
        //            afr = (ActivityConfig.ActivityFieldRow)((DataRowView)g.CurrentRow.DataRow).Row;


        //        if (afr == null)
        //            return;
        //        else
        //        {
        //            if (!afr.IsFieldTypeNull() && afr.FieldType.ToUpper() == "?W") // officer workload control
        //            {
        //                if (g == relatedInfoFieldsGridEx || g == activityFieldGridEX)
        //                {
        //                    g.RootTable.Columns["SpecialParameter"].EditType = Janus.Windows.GridEX.EditType.MultiColumnDropDown;
        //                    DataTable dt = new DataTable();
        //                    dt.Columns.Add("WLQName", typeof(string));

        //                    foreach (string eName in Enum.GetNames(typeof(WorkloadQuery)))
        //                    {
        //                        dt.Rows.Add(eName);
        //                    }
        //                    dt.AcceptChanges();
        //                    g.DropDowns["ddParameter"].ValueMember = dt.Columns[0].ColumnName;
        //                    g.DropDowns["ddParameter"].DisplayMember = dt.Columns[0].ColumnName;
        //                    g.DropDowns["ddParameter"].Columns[0].DataMember = dt.Columns[0].ColumnName;
        //                    g.DropDowns["ddParameter"].SetDataBinding(dt, "");
        //                }
        //            }
        //            else
        //            {
        //                if (g == relatedInfoFieldsGridEx || g == activityFieldGridEX)
        //                    g.RootTable.Columns["SpecialParameter"].EditType = Janus.Windows.GridEX.EditType.TextBox;
        //            }
        //            if (afr.IsLookUpNull())
        //            {
        //                g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.TextBox;
        //                g.DropDowns["ddDefault"].SetDataBinding(null, "");
        //            }
        //            if (!afr.IsLookUpNull())
        //            {
        //                g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;

        //                DataTable dt = AtMng.GetFile().Codes(afr.LookUp);
        //                g.DropDowns["ddDefault"].ValueMember = dt.Columns[0].ColumnName;
        //                g.DropDowns["ddDefault"].DisplayMember = dt.Columns[0].ColumnName;
        //                g.DropDowns["ddDefault"].Columns[0].DataMember = dt.Columns[0].ColumnName;
        //                g.DropDowns["ddDefault"].Columns[1].DataMember = dt.Columns[1].ColumnName;
        //                g.DropDowns["ddDefault"].SetDataBinding(dt, "");

        //            }
        //            if (!afr.IsFieldTypeNull() && afr.FieldType.ToUpper() == "X")
        //            {
        //                g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;

        //                DataTable dt = AtMng.CodeDB.BooleanValues;
        //                g.DropDowns["ddDefault"].ValueMember = dt.Columns[0].ColumnName;
        //                g.DropDowns["ddDefault"].DisplayMember = dt.Columns[0].ColumnName;
        //                g.DropDowns["ddDefault"].Columns[0].DataMember = dt.Columns[0].ColumnName;
        //                g.DropDowns["ddDefault"].Columns[1].DataMember = dt.Columns[1].ColumnName;
        //                g.DropDowns["ddDefault"].SetDataBinding(dt, "");
        //            }

        //            if (!afr.IsNull("TaskType") && afr.TaskType.ToUpper() == "I")
        //                g.RootTable.Columns["DefaultValue"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Ellipsis;
        //            else
        //                g.RootTable.Columns["DefaultValue"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}


        //fBrowseIssues fbi;
        //private void activityFieldGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        //{
        //    try
        //    {
        //        ActivityConfig.ActivityFieldRow afr = null;
        //        Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;

        //        if (g.CurrentRow != null && g.CurrentRow.DataRow != null)
        //            afr = (ActivityConfig.ActivityFieldRow)((DataRowView)g.CurrentRow.DataRow).Row;


        //        if (afr == null)
        //            return;

        //        if (e.Column.Key == "DefaultValue" && afr.TaskType.ToUpper() == "I")
        //        {
        //            if (fbi == null)
        //                fbi = new fBrowseIssues(AtMng, false);
        //            if (!afr.IsDefaultValueNull())
        //                fbi.FindIssue(Convert.ToInt32(afr.DefaultValue));

        //            if (fbi.ShowDialog() == DialogResult.OK)
        //            {
        //                afr.DefaultValue = fbi.SelectedIssue.IssueId.ToString();
        //                if (!fbi.SelectedIssue.IsNull("IssueNameEng"))
        //                    afr.LabelEng = fbi.SelectedIssue.IssueNameEng;

        //                if (!fbi.SelectedIssue.IsFileIdNull())
        //                    afr.LabelFre = AtMng.GetFile(fbi.SelectedIssue.FileId).CurrentFile.FullFileNumber; //fbi.SelectedIssue.EFileRow.FullFileNumber;
        //                else
        //                    afr.SetDefaultFieldNameNull();
        //            }
        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}


        private void btnFetchDefaults_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ActivityConfig.ActivityFieldRow afr in CurrentACS().GetActivityFieldRows())
                {
                    appDB.ddFieldRow[] ddf = (appDB.ddFieldRow[])AtMng.DB.ddField.Select("AllowInRelatedFields=1 and fieldname='" + afr.FieldName + "' and tablename='" + afr.ObjectName + "'", "");
                    if (ddf.Length > 0 && !ddf[0].IsDefaultSystemValueNull())
                        afr.DefaultSystemValue = ddf[0].DefaultSystemValue;
                }
                //RefetchRelInfoGrids();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiContextMenu2_Popup(object sender, EventArgs e)
        {
            try
            {
                if (diagram.SelectedConnector.myACD.LinkType == (int)atriumBE.ConnectorType.Obsolete)
                    cmdConnectorObsolete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                else
                    cmdConnectorObsolete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiContextMenu1_CommandPopup(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                if (e.Command.Key == "cmdWorkflowStepDeleteOptions")
                {
                    Application.UseWaitCursor = true;
                    if (diagram.SelectedStep.myACS.StepType == (int)atriumBE.StepType.Activity)
                    {
                        DataTable dt = AtMng.GetGeneralRec("select count(activityid) from vactivity where acseriesid=" + diagram.SelectedStep.myACS.ACSeriesId.ToString());
                        if (Int32.Parse(dt.Rows[0][0].ToString()) > 0)
                            cmdDeleteStep.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        else if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
                            cmdDeleteStep.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                        cmdAcSeriesUseCount.Text = "Use Count: " + dt.Rows[0][0].ToString();
                        cmdAcSeriesUseCount.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    }
                    else
                    {
                        cmdAcSeriesUseCount.Visible = Janus.Windows.UI.InheritableBoolean.False;
                        cmdDeleteStep.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    }

                    if (diagram.SelectedStep.myACS.Obsolete)
                        cmdAcSeriesObsolete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    else
                        cmdAcSeriesObsolete.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                    Application.UseWaitCursor = false;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                lmDatasets.ActivityConfig.ACFileTypeRow newACF = (lmDatasets.ActivityConfig.ACFileTypeRow)AtMng.acMng.GetACFileType().Add(CurrentACS());
                aCFileTypeBindingSource.Position = aCFileTypeBindingSource.Find("Id", newACF.Id);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void aCFileTypeGridEX_DeletingRecords(object sender, CancelEventArgs e)
        {
            try
            {
                if (UIHelper.ConfirmDelete() == false)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void chkAllowFiletype_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllowFiletype.Checked)
                    aCFileTypeGridEX.RootTable.Caption = "Allowed";
                else
                    aCFileTypeGridEX.RootTable.Caption = "Disallowed";
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        Janus.Windows.GridEX.GridEXFilterCondition errorCondition;
        Janus.Windows.GridEX.GridEXFilterCondition warningCondition;
        Janus.Windows.GridEX.GridEXFilterCondition messageCondition;

        private void UpdateValidationGridFilterCondition()
        {
            bool viewErrors = cmdErrors.IsChecked;
            bool viewWarnings = cmdWarning.IsChecked;
            bool viewMessages = cmdMessage.IsChecked;
            bool noValidationRecords = false;

            if (!viewErrors & !viewWarnings & !viewMessages)
            {
                noValidationRecords = true;
                Janus.Windows.GridEX.GridEXFilterCondition filterHideAll = new Janus.Windows.GridEX.GridEXFilterCondition();
                Janus.Windows.GridEX.GridEXFilterCondition grdNoRecordsCondition = new Janus.Windows.GridEX.GridEXFilterCondition(grdErrors.RootTable.Columns["ValidationType"], Janus.Windows.GridEX.ConditionOperator.Equal, 10);
                filterHideAll.AddCondition(grdNoRecordsCondition.Clone());
                grdErrors.RemoveFilters();
                grdErrors.RootTable.ApplyFilter(filterHideAll);
            }

            if (!noValidationRecords)
            {
                if (errorCondition == null)
                    errorCondition = new Janus.Windows.GridEX.GridEXFilterCondition(grdErrors.RootTable.Columns["ValidationType"], Janus.Windows.GridEX.ConditionOperator.Equal, atriumBE.WFValidator.ValidationType.Error);

                if (warningCondition == null)
                    warningCondition = new Janus.Windows.GridEX.GridEXFilterCondition(grdErrors.RootTable.Columns["ValidationType"], Janus.Windows.GridEX.ConditionOperator.Equal, atriumBE.WFValidator.ValidationType.Warning);

                if (messageCondition == null)
                    messageCondition = new Janus.Windows.GridEX.GridEXFilterCondition(grdErrors.RootTable.Columns["ValidationType"], Janus.Windows.GridEX.ConditionOperator.Equal, atriumBE.WFValidator.ValidationType.Message);

                Janus.Windows.GridEX.GridEXFilterCondition filterToApply = new Janus.Windows.GridEX.GridEXFilterCondition();
                if (viewErrors)
                    filterToApply.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, errorCondition.Clone());
                if (viewWarnings)
                    filterToApply.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, warningCondition.Clone());
                if (viewMessages)
                    filterToApply.AddCondition(Janus.Windows.GridEX.LogicalOperator.Or, messageCondition.Clone());

                grdErrors.RemoveFilters();
                grdErrors.RootTable.ApplyFilter(filterToApply);
            }
        }

        private void uiCommandManager2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdErrors":
                    case "cmdWarning":
                    case "cmdMessage":
                        UpdateValidationGridFilterCondition();
                        break;
                    case "cmdClose":
                        pnlValidationGrid.Closed = true;
                        break;
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void grdErrors_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                    ACSeriesSelect(e.Row.Cells["AcSeriesId"].Value.ToString());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void ACSeriesSelect(string ACSeriesId)
        {
            diagram.SelectStep(diagram.mySteps["a" + ACSeriesId]);
            propertyGrid1.SelectedObject = diagram.mySteps["a" + ACSeriesId];
        }

        //private void activityFieldGridEX_DeletingRecords(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("Are you sure you want to delete the selected Related Field records?", "Delete Selected Related Fields", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            //do nothing, delete rows
        //        }
        //        else
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        UIHelper.HandleUIException(x);
        //    }
        //}

        //private void activityFieldGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (MessageBox.Show("Are you sure you want to delete the selected Related Field records?", "Delete Selected Related Fields", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
        //    //    {
        //    //        //do nothing, delete rows
        //    //    }
        //    //    else
        //    //    {
        //    //        e.Cancel = true;
        //    //    }
        //    //}
        //    //catch (Exception x)
        //    //{
        //    //    UIHelper.HandleUIException(x);
        //    //}
        //}

        private void fSeries_Load(object sender, EventArgs e)
        {
            try
            {
                seriesGridEX.MoveFirst();
                valueListUpDown1.Value = 100;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnNewConvert_Click(object sender, EventArgs e)
        {
            try
            {
                lmDatasets.ActivityConfig.ACConvertRow newConvert = (lmDatasets.ActivityConfig.ACConvertRow)AtMng.acMng.GetACConvert().Add(CurrentACS());
                newConvert.ACSeriesId = CurrentACS().ACSeriesId;
                newConvert.SetAllowableACSeriesIdNull();
                aCConvertBindingSource.Position = aCConvertBindingSource.Find("Id", newConvert.Id);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnNewRevert_Click(object sender, EventArgs e)
        {
            try
            {
                lmDatasets.ActivityConfig.ACConvertRow newRevert = (lmDatasets.ActivityConfig.ACConvertRow)AtMng.acMng.GetACConvert().Add(CurrentACS());
                newRevert.AllowableACSeriesId = CurrentACS().ACSeriesId;
                newRevert.SetACSeriesIdNull();
                acRevertBindingSource.Position = acRevertBindingSource.Find("Id", newRevert.Id);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //JLL Workflow Admin Enhancements
        //2013-09-05
        //Need to see the Step Type in the grid
        private void parentProcessGridEx_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    lmDatasets.ActivityConfig.ACSeriesRow acsr = (lmDatasets.ActivityConfig.ACSeriesRow)((DataRowView)e.Row.DataRow).Row;
                    lmDatasets.ActivityConfig.ACDependencyRow[] acd = acsr.GetACDependencyRowsByPreviousSteps();

                    //Only handling first connector found
                    //problem is there is only one acseries row (subprocess step) back up to the parent process, even if there are multiple acdependency records to it
                    //look to add mutiple value column for Connector Type in the future to display all connectors
                    if (acd.Length > 0)
                    {
                        e.Row.Cells["StepType"].Value = acd[0].LinkType;
                    }

                    //this code will never run until fix to handle multi value column
                    else if (acd.Length > 1)
                    {
                        foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acd)
                        {
                            e.Row.Cells["StepType"].Value = acd[0].LinkType;
                        }
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //JLL: 2013-09 Related Fields Layout Change
        private void ApplyBlockFilter()
        {
            if (valueListUpDown1.Value == null)
                valueListUpDown1.Value = 100;

            //Used Records Filter
            Janus.Windows.GridEX.ConditionOperator op1 = new Janus.Windows.GridEX.ConditionOperator();
            if ((int)valueListUpDown1.Value == 100)
            {
                op1 = Janus.Windows.GridEX.ConditionOperator.LessThan;
                uiButton4.Enabled = true;
                uiButton4.ToolTipText = "The Block for the added Used Record will default to the Initiate Block";
            }
            else if ((int)valueListUpDown1.Value >= 10) // Doc, TK or Scheduling block
            {
                op1 = Janus.Windows.GridEX.ConditionOperator.Equal;
                uiButton4.Enabled = false;
                uiButton4.ToolTipText = "";
            }
            else
            {
                op1 = Janus.Windows.GridEX.ConditionOperator.Equal;
                uiButton4.Enabled = true;
                uiButton4.ToolTipText = "New Used Record will be added to " + valueListUpDown1.ValueList[valueListUpDown1.Value].Text;
            }

            gridexRecordsUsed.RootTable.RemoveFilter();
            Janus.Windows.GridEX.GridEXFilterCondition grdUsedMainFilterCond = new Janus.Windows.GridEX.GridEXFilterCondition();

            Janus.Windows.GridEX.GridEXFilterCondition uTaskTypeFilter = gridexRecordsUsed.RootTable.StoredFilters[0].FilterCondition.Clone();
            Janus.Windows.GridEX.GridEXFilterCondition uStepFilter = new Janus.Windows.GridEX.GridEXFilterCondition(gridexRecordsUsed.RootTable.Columns["Step"], op1, valueListUpDown1.Value);

            grdUsedMainFilterCond.AddCondition(uTaskTypeFilter);
            grdUsedMainFilterCond.AddCondition(Janus.Windows.GridEX.LogicalOperator.And, uStepFilter);
            gridexRecordsUsed.RootTable.FilterCondition = grdUsedMainFilterCond;

            //Related Fields Filter
            Janus.Windows.GridEX.ConditionOperator op2 = new Janus.Windows.GridEX.ConditionOperator();
            int filterValue;
            if ((int)valueListUpDown1.Value == 100)
            {
                op2 = Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo;
                filterValue = 0;
                uiButton5.Enabled = true;
                uiButton5.ToolTipText = "The Block for the added Related Fields will default to Related Fields Block 1";
            }
            else if ((int)valueListUpDown1.Value == -10)
            {
                op2 = Janus.Windows.GridEX.ConditionOperator.Equal;
                filterValue = 999; //filter out everything
                uiButton5.Enabled = false;
                uiButton5.ToolTipText = "";
            }
            else
            {
                op2 = Janus.Windows.GridEX.ConditionOperator.Equal;
                filterValue = (int)valueListUpDown1.Value;
                uiButton5.Enabled = true;
                uiButton5.ToolTipText = "Related Fields will be added to " + valueListUpDown1.ValueList[valueListUpDown1.Value].Text;
            }

            gridexRelatedFields.RootTable.RemoveFilter();
            Janus.Windows.GridEX.GridEXFilterCondition grdRelFldsMainFilterCond = new Janus.Windows.GridEX.GridEXFilterCondition();

            Janus.Windows.GridEX.GridEXFilterCondition rTaskTypeFilter = gridexRelatedFields.RootTable.StoredFilters[0].FilterCondition.Clone();
            Janus.Windows.GridEX.GridEXFilterCondition rStepFilter = new Janus.Windows.GridEX.GridEXFilterCondition(gridexRelatedFields.RootTable.Columns["Step"], op2, filterValue);

            grdRelFldsMainFilterCond.AddCondition(rTaskTypeFilter);
            grdRelFldsMainFilterCond.AddCondition(Janus.Windows.GridEX.LogicalOperator.And, rStepFilter);
            gridexRelatedFields.RootTable.FilterCondition = grdRelFldsMainFilterCond;
            gridexRelatedFields.RootTable.ApplyFilter(grdRelFldsMainFilterCond);

            BuildAvailRelObjMenu();
        }


        //JLL: 2013-09 Related Fields Layout Change
        private ActivityConfig.ActivityFieldRow getACFieldRowFromGridex(Janus.Windows.GridEX.GridEX grd)
        {
            if (grd.CurrentRow != null && grd.CurrentRow.DataRow != null)
                return (ActivityConfig.ActivityFieldRow)((DataRowView)grd.CurrentRow.DataRow).Row;
            else
                return null;
        }

        private ActivityConfig.ActivityFieldRow getACFieldRowFromGridex(Janus.Windows.GridEX.GridEXRow row)
        {
            if (row != null && row.DataRow != null)
                return (ActivityConfig.ActivityFieldRow)((DataRowView)row.DataRow).Row;
            else
                return null;
        }

        //JLL: 2013-09 Related Fields Layout Change
        private void gridexRecordsUsed_DropDown(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "DefaultObjectName")
                    HandleDropdown(e, dtUsableAliases, false);

                if (e.Column.Key == "FieldName")
                    HandleDropdown(e, "ObjectName");

                if (e.Column.Key == "DefaultFieldName")
                    HandleDropdown(e, "DefaultObjectName");
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //JLL: 2013-09 Related Fields Layout Change
        private void gridexRelatedFields_DropDown(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "ObjectAlias")
                    HandleDropdown(e, dtUsableAliasesRelFields, true);

                if (e.Column.Key == "DefaultObjectName")
                    HandleDropdown(e, dtUsableAliasesRelFields, true);

                if (e.Column.Key == "FieldName")
                    HandleDropdown(e, "ObjectName");

                if (e.Column.Key == "DefaultFieldName")
                    HandleDropdown(e, "DefaultObjectName");
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //JLL: 2013-09 Related Fields Layout Change
        /// <summary>
        /// To Display List of FieldNames for selected row, for ObjectName or DefaultObjectName
        /// </summary>
        /// <param name="e">The Janus.Windows.GridEX.ColumnActionEventArgs Event Argument passed to the initial grid DropDown handler</param>
        /// <param name="FromTable">Possible values are: "ObjectName" or "DefaultObjectName". The table from which to lookup fields to display.</param>
        private void HandleDropdown(Janus.Windows.GridEX.ColumnActionEventArgs e, string FromTable)
        {
            switch (FromTable)
            {
                case "ObjectName":
                    string tType = (string)e.Column.GridEX.CurrentRow.Cells["TaskType"].Value;
                    if (tType == "G" || tType == "N" || tType == "O" || tType == "FL")
                        e.Column.DropDown.SetDataBinding("", "");
                    else
                    {
                        string obj = e.Column.GridEX.CurrentRow.Cells[FromTable].Text;
                        DataTable dtTable1 = AtMng.GetGeneralRec("Select * from vddField where AllowInRelatedFields=1 and tableName='" + obj + "'");
                        e.Column.DropDown.SetDataBinding(dtTable1.DefaultView, "");
                    }
                    break;
                case "DefaultObjectName":
                    //find activityfield row that defines the objectalias
                    string alias = e.Column.GridEX.CurrentRow.Cells[FromTable].Text;
                    if (alias == "")
                        e.Column.DropDown.SetDataBinding(null, "");
                    else
                    {
                        string whereclause = "ACSeriesId=" + CurrentACS().ACSeriesId + " and TaskType<>'F' and ObjectAlias='" + alias + "'";
                        ActivityConfig.ActivityFieldRow[] afrs = (ActivityConfig.ActivityFieldRow[])AtMng.acMng.DB.ActivityField.Select(whereclause);
                        if (afrs.Length == 0)
                            throw new Exception("Used Record that defines Object Alias could not be found");

                        string obj2 = afrs[0].ObjectName;
                        DataTable dtTable2 = AtMng.GetGeneralRec("Select * from vddField where AllowInRelatedFields=1 and tableName='" + obj2 + "'");
                        e.Column.DropDown.SetDataBinding(dtTable2.DefaultView, "");
                    }
                    break;

            }

        }

        //JLL: 2013-09 Related Fields Layout Change
        /// <summary>
        /// To Handle Accessibility to Object Aliases based on their order
        /// </summary>
        /// <param name="e">The Janus.Windows.GridEX.ColumnActionEventArgs Event Argument passed to the initial grid DropDown handler</param>
        /// <param name="dt">The dtUsableAliasesRelFields or dtUsableAliases datatable, based on which grid is used</param>
        /// <param name="ForRelatedFields">Whether to apply the list based on UsedRecords (accounts for step/sequence) or RelatedFields (step)</param>
        private void HandleDropdown(Janus.Windows.GridEX.ColumnActionEventArgs e, DataTable dt, bool ForRelatedFields)
        {
            dt.Clear();

            if (e.Column.GridEX.CurrentRow.RowType != Janus.Windows.GridEX.RowType.Record)
                return;

            lmDatasets.ActivityConfig.ActivityFieldRow arf = getACFieldRowFromGridex(e.Column.GridEX);

            if (arf == null)
                return;

            short arfStep = arf.Step;
            short arfSeq = arf.Seq;

            //get activity field rows for current acseries row, of appropriate task type, where accessible based on step/sequence order
            string whereclause;
            if (ForRelatedFields)
                whereclause = "ACSeriesId=" + CurrentACS().ACSeriesId + " and (TaskType='Z1' or TaskType='FL' or TaskType='G' or TaskType='N' or TaskType='Q' or TaskType='S' or TaskType='L' or TaskType='O' or TaskType='R' or TaskType='U' or TaskType='C'  or TaskType='SN'  or TaskType='Z'  or TaskType='M') and Step<=" + arfStep;
            else
                whereclause = "ACSeriesId=" + CurrentACS().ACSeriesId + " and (TaskType='Z1' or TaskType='FL' or TaskType='G' or TaskType='N' or TaskType='Q' or TaskType='S' or TaskType='L' or TaskType='O' or TaskType='R' or TaskType='U' or TaskType='C' or TaskType='SN'  or TaskType='Z'  or TaskType='M') and (Step<" + arfStep + " or (Step=" + arfStep + " and Seq<" + arfSeq + "))";

            //loop through explicitly defined objects
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in AtMng.acMng.DB.ActivityField.Select(whereclause, "Step,Seq"))
            {
                if (!dt.Rows.Contains(afr.ObjectAlias))
                    dt.Rows.Add(afr.ObjectAlias);
            }
            //loop through included (T tasktype) objects
            LoadObjectsFromInclude(0, false, dt); // pass 0 for selectedblock since it is not used when second parameter is false




            e.Column.DropDown.SetDataBinding(dt.DefaultView, "");
        }

        //JLL: 2013-09 Related Fields Layout Change
        private void gridexRecordsUsed_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ActivityConfig.ActivityFieldRow afr = null;
                Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
                afr = getACFieldRowFromGridex(g);

                if (afr == null)
                    return;

                // officer workload control
                if (!afr.IsFieldTypeNull() && afr.FieldType.ToUpper() == "?W")
                {
                    g.RootTable.Columns["SpecialParameter"].EditType = Janus.Windows.GridEX.EditType.MultiColumnDropDown;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("WLQName", typeof(string));

                    foreach (string eName in Enum.GetNames(typeof(WorkloadQuery)))
                    {
                        dt.Rows.Add(eName);
                    }
                    dt.AcceptChanges();
                    g.DropDowns["ddParameter"].ValueMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddParameter"].DisplayMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddParameter"].Columns[0].DataMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddParameter"].SetDataBinding(dt, "");
                }
                else
                    g.RootTable.Columns["SpecialParameter"].EditType = Janus.Windows.GridEX.EditType.TextBox;

                if (afr.IsLookUpNull())
                {
                    g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.TextBox;
                    g.DropDowns["ddDefault"].SetDataBinding(null, "");
                }

                if (!afr.IsLookUpNull())
                {
                    g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;

                    DataTable dt = AtMng.GetFile().Codes(afr.LookUp);
                    g.DropDowns["ddDefault"].ValueMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddDefault"].DisplayMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddDefault"].Columns[0].DataMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddDefault"].Columns[1].DataMember = dt.Columns[1].ColumnName;
                    g.DropDowns["ddDefault"].SetDataBinding(dt, "");

                }
                if (!afr.IsFieldTypeNull() && afr.FieldType.ToUpper() == "X")
                {
                    g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;

                    DataTable dt = AtMng.CodeDB.BooleanValues;
                    g.DropDowns["ddDefault"].ValueMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddDefault"].DisplayMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddDefault"].Columns[0].DataMember = dt.Columns[0].ColumnName;
                    g.DropDowns["ddDefault"].Columns[1].DataMember = dt.Columns[1].ColumnName;
                    g.DropDowns["ddDefault"].SetDataBinding(dt, "");
                }


            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        //JLL: 2013-09 Related Fields Layout Change
        private void addSpecialObjectCommands()
        {
            Janus.Windows.UI.CommandBars.UICommand ucm = null;
            List<string> aSO = new List<string>();
            aSO.Add("GDAppellant");
            aSO.Add("SSTManager");
            aSO.Add("SourceFile");
            aSO.Add("PreviousProcess");
            aSO.Add("PreviousActivity");
            aSO.Add("PreviousDocument");
            aSO.Add("FirstActivity");
            aSO.Add("FirstDocument");

            foreach (string itm in aSO)
            {
                ucm = new Janus.Windows.UI.CommandBars.UICommand("cmdNewSO" + itm);
                ucm.Text = itm;
                ucm.Image = Properties.Resources.lightbulb;
                cmdSpecialObject.Commands.Add(ucm);
            }

            //add issues commands
            Janus.Windows.UI.CommandBars.UICommand issPri = new Janus.Windows.UI.CommandBars.UICommand("cmdNewSOIssuePrimary");
            issPri.Text = "IssuePrimary";
            issPri.Image = Properties.Resources.issue;
            cmdIssueContainer.Commands.Add(issPri);

            Janus.Windows.UI.CommandBars.UICommand issSec = new Janus.Windows.UI.CommandBars.UICommand("cmdNewSOIssueSecondary");
            issSec.Text = "IssueSecondary";
            issSec.Image = Properties.Resources.issue;
            cmdIssueContainer.Commands.Add(issSec);
        }

        //JLL: 2013-09 Related Fields Layout Change
        private void AddNewSpecialObjectRow(string SOName)
        {
            ActivityConfig.ActivityFieldRow afr;
            bool isIssue = false;
            if (SOName == "IssuePrimary" || SOName == "IssueSecondary")
            {
                afr = AddNewUsedRecord("I", true);
                isIssue = true;
            }
            else
                afr = AddNewUsedRecord("O", true);

            switch (SOName)
            {
                case "PreviousProcess":
                    afr.ObjectName = "Process";
                    afr.ObjectAlias = SOName;
                    break;
                case "GDAppellant":
                    afr.ObjectName = "Contact";
                    afr.ObjectAlias = SOName;
                    break;
                case "SSTManager":
                    afr.ObjectName = "Officer";
                    afr.ObjectAlias = SOName;
                    break;
                case "SourceFile":
                    afr.ObjectName = "EFile";
                    afr.ObjectAlias = SOName;
                    break;
                case "PreviousActivity":
                case "FirstActivity":
                    afr.ObjectName = "Activity";
                    afr.ObjectAlias = SOName;
                    break;
                case "PreviousDocument":
                case "FirstDocument":
                    afr.ObjectName = "Document";
                    afr.ObjectAlias = SOName;
                    break;
                default: //primary or secondary issue
                    afr.ObjectName = SOName;
                    afr.FieldName = "IssueId";
                    break;
            }
            if (!isIssue)
                afr.DefaultValue = SOName;
        }


        //JLL: 2013-09 Related Fields Layout Change
        private void gridexRecordsUsed_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                ActivityConfig.ActivityFieldRow afr = null;
                Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
                afr = getACFieldRowFromGridex(g);

                if (afr == null)
                    return;

                g.RootTable.Columns["FieldName"].EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;
                string tType = afr.TaskType;

                if (tType == "T")
                {
                    g.RootTable.Columns["ObjectName"].Selectable = false;
                    g.RootTable.Columns["ObjectAlias"].Selectable = false;
                    g.RootTable.Columns["SpecialParameter"].Selectable = false;
                    g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;
                }
                else
                {
                    g.RootTable.Columns["ObjectName"].Selectable = true;
                    g.RootTable.Columns["ObjectAlias"].Selectable = true;
                    g.RootTable.Columns["SpecialParameter"].Selectable = true;
                    g.RootTable.Columns["DefaultValue"].EditType = Janus.Windows.GridEX.EditType.TextBox;
                }

                if (tType == "G" || tType == "N" || tType == "O" || tType == "I" || tType == "T" || tType == "FL")
                    g.RootTable.Columns["FieldName"].Selectable = false;
                else
                    g.RootTable.Columns["FieldName"].Selectable = true;

                if (tType == "G" || tType == "O" || tType == "I" || tType == "T")
                    g.RootTable.Columns["DefaultObjectName"].Selectable = false;
                else
                    g.RootTable.Columns["DefaultObjectName"].Selectable = true;

                if (tType == "G" || tType == "N" || tType == "O" || tType == "I" || tType == "T")
                    g.RootTable.Columns["DefaultFieldName"].Selectable = false;
                else
                    g.RootTable.Columns["DefaultFieldName"].Selectable = true;

                if (tType == "G" || tType == "N")
                    g.RootTable.Columns["DefaultValue"].Selectable = false;
                else
                    g.RootTable.Columns["DefaultValue"].Selectable = true;

                if (tType == "I")
                    g.RootTable.Columns["DefaultValue"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Ellipsis;
                else
                    g.RootTable.Columns["DefaultValue"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //JLL: 2013-09 Related Fields Layout Change
        private void gridexRecordsUsed_DeletingRecords(object sender, CancelEventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
                string rec;
                if (g == gridexRecordsUsed)
                    rec = "Used Record";
                else
                    rec = "Related Field";

                if (MessageBox.Show("Are you sure you want to delete the selected " + rec + "?", "Delete Selected " + rec, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    //do nothing, delete rows
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //JLL: 2013-09 Related Fields Layout Change
        fBrowseIssues relIssue;
        private void gridexRecordsUsed_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                ActivityConfig.ActivityFieldRow afr = null;
                Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
                afr = getACFieldRowFromGridex(g);

                if (afr == null)
                    return;

                if (e.Column.Key == "DefaultValue" && afr.TaskType.ToUpper() == "I")
                {
                    if (relIssue == null)
                        relIssue = new fBrowseIssues(AtMng, false, 0);
                    if (!afr.IsDefaultValueNull())
                        relIssue.FindIssue(Convert.ToInt32(afr.DefaultValue));

                    if (relIssue.ShowDialog() == DialogResult.OK)
                    {
                        afr.DefaultValue = relIssue.SelectedIssue.IssueId.ToString();
                        gridexRecordsUsed.UpdateData();
                    }
                }
                if (e.Column.Key == "DefaultValue" && afr.TaskType.ToUpper() == "T")
                {
                    //jump to referenced acseriesid
                    if (afr.IsDefaultValueNull())
                        return;

                    ActivityConfig.ACSeriesRow acsr = AtMng.acMng.DB.ACSeries.FindByACSeriesId(Convert.ToInt32(afr.DefaultValue));
                    MainAdminForm.MoreInfoACSeries(acsr.SeriesId, acsr.ACSeriesId);

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        //populate Related Fields based on Available Objects
        private void uiContextMenu6_Popup(object sender, EventArgs e)
        {
            BuildAvailRelObjMenu();

        }

        //Make available the objects from the Included Step
        private void LoadObjectsFromInclude(int selectedBlock, bool addToRelFieldContextMenu, DataTable dt)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow[] tAfr = (lmDatasets.ActivityConfig.ActivityFieldRow[])AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + CurrentACS().ACSeriesId + " and TaskType='T'", "");
            if (tAfr.Length > 0)
            {
                foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in tAfr)
                {
                    //for every T task type record, determine what to add
                    lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + afr.DefaultValue + " and (TaskType='Z1' or TaskType='FL' or TaskType='G' or TaskType='N' or TaskType='Q' or TaskType='S' or TaskType='L' or TaskType='O' or TaskType='R' or TaskType='U' or TaskType='C' or TaskType='SN'  or TaskType='Z' or TaskType='M')", "");
                    foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr2 in afrs)
                    {
                        if (addToRelFieldContextMenu) // add command to relfield dropdown context menu
                            AddRelObjCommand(afr2, selectedBlock, true);
                        else // add object to objectalias datatable in relatedfields grid
                        {
                            if (!dt.Rows.Contains(afr2.ObjectAlias))
                                dt.Rows.Add(afr2.ObjectAlias);
                        }
                    }
                }
            }
        }

        private void AddRelObjCommand(ActivityConfig.ActivityFieldRow afr, int selectedBlock, bool isFromInclude)
        {
            Janus.Windows.UI.CommandBars.UICommand uc;

            if (!afr.IsNull("ObjectName")) //when cancelling update, and objectname is null for new added row, currentchanged fires, which calls this method. w/o null objectname check, exception is thrown
            {
                bool AllowAddObject = true;

                bool notDocTbl = (afr.ObjectName.ToUpper() != "DOCUMENT" && afr.ObjectName.ToUpper() != "DOCCONTENT" && afr.ObjectName.ToUpper() != "RECIPIENT");
                bool notTKTbl = (afr.ObjectName.ToUpper() != "ACTIVITYTIME");
                bool notSchTbl = (afr.ObjectName.ToUpper() != "APPOINTMENT" && afr.ObjectName.ToUpper() != "ATTENDEE");

                //only allow DOCUMENT objects in Document Block
                if (selectedBlock == 10 && notDocTbl)
                    AllowAddObject = false;

                //only allow ACTIVITYTIME objects in Timekeeping Block
                if (selectedBlock == 11 && notTKTbl)
                    AllowAddObject = false;

                if (selectedBlock == 12 && notSchTbl)
                    AllowAddObject = false;

                if (AllowAddObject)
                {
                    uc = new Janus.Windows.UI.CommandBars.UICommand("cmdNewRelFld" + afr.ObjectAlias);
                    uc.Text = afr.ObjectAlias + " (" + afr.ObjectName + ") ...";
                    if (isFromInclude)
                        uc.Image = Properties.Resources.SelectAll;
                    else
                        uc.Image = Properties.Resources.metadata;
                    uc.Tag = afr.ObjectName;


                    //JLL since basecommand is based on objectname, multiple objects based on same base object will always find first command since basecommand is based on tablename
                    //if (uiCommandManager1.ContextMenus["ContextMenuAllRelatedInfo"].Commands.Contains(uc.BaseCommand))
                    //    uiContextMenu6.Commands.Add(uc.BaseCommand);
                    //else
                    //    uiContextMenu6.Commands.Add(uc);

                    if (!uiCommandManager1.ContextMenus["ContextMenuAllRelatedInfo"].Commands.Contains("cmdNewRelFld" + afr.ObjectAlias))
                        uiContextMenu6.Commands.Add(uc);
                        
                }
            }
        }

        private void BuildAvailRelObjMenu()
        {
            try
            {
                uiContextMenu6.Commands.Clear();
                int selectedBlock = (int)valueListUpDown1.Value;


                LoadObjectsFromInclude(selectedBlock, true, null); //pass null datatable since not used when 2nd parameter is true;

                //get activity field rows for current acseries row, of appropriate task type, where accessible based on step/sequence order
                string whereclause;
                whereclause = "ACSeriesId=" + CurrentACS().ACSeriesId + " and (TaskType='Z1' or TaskType='FL' or TaskType='G' or TaskType='N' or TaskType='Q' or TaskType='S' or TaskType='L' or TaskType='O' or TaskType='R' or TaskType='U' or TaskType='C' or TaskType='SN'  or TaskType='Z' or TaskType='M') and (Step<=" + selectedBlock + ")";

                foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in AtMng.acMng.DB.ActivityField.Select(whereclause, "Step,Seq"))
                {
                    AddRelObjCommand(afr, selectedBlock, false);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fSeries_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.L && pnlDetails.SelectedPanel == pnlRelRecsFields)
                {
                    valueListUpDown1.Focus();
                }

                if (e.Control && e.KeyCode == Keys.PageDown && pnlDetails.SelectedPanel == pnlRelRecsFields)
                {
                    if (!valueListUpDown1.Focused)
                        valueListUpDown1.Focus();

                    //navigate BlockFilter down
                    if (valueListUpDown1.SelectedIndex + 1 < valueListUpDown1.ValueList.Count)
                        valueListUpDown1.SelectedIndex += 1;

                }
                if (e.Control && e.KeyCode == Keys.PageUp && pnlDetails.SelectedPanel == pnlRelRecsFields)
                {
                    if (!valueListUpDown1.Focused)
                        valueListUpDown1.Focus();
                    //why does this cause crash/exception that break on all exceptions can't handle
                    if (valueListUpDown1.SelectedIndex > 0)
                        valueListUpDown1.SelectedIndex -= 1;

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void fSeries_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fSeries_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void valueListUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyBlockFilter();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void uiContextMenu3_Popup(object sender, EventArgs e)
        {
            try
            {
                ActivityConfig.ActivityFieldRow afr = getACFieldRowFromGridex(gridexRelatedFields);

                if (afr == null || gridexRelatedFields.HitTest() != Janus.Windows.GridEX.GridArea.Cell)
                {
                    uiContextMenu3.Close();
                    return;
                }
            }
            catch (Exception x)
            {
                uiContextMenu3.Close();
                UIHelper.HandleUIException(x);
            }

        }

        private void uiContextMenu4_Popup(object sender, EventArgs e)
        {
            try
            {
                ActivityConfig.ActivityFieldRow afr = getACFieldRowFromGridex(gridexRecordsUsed);

                if (afr == null || gridexRecordsUsed.HitTest() != Janus.Windows.GridEX.GridArea.Cell)
                {
                    uiContextMenu4.Close();
                    return;
                }
            }
            catch (Exception x)
            {
                uiContextMenu4.Close();
                UIHelper.HandleUIException(x);
            }
        }

        private void btnRelFieldsClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                pblClipboard.Closed = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnClearClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to clear the clipboard of all records?", "Clear Clipboard", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    AFClipboard.Clear();
                    AFClipboard.AcceptChanges();
                    pblClipboard.Closed = true;
                    btnRelFieldsClipboard.Enabled = false;
                    updateClipboardCount();
                    MainAdminForm.Activate();
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityFieldGridEX_DeletingRecords(object sender, CancelEventArgs e)
        {
            try
            {
                if (UIHelper.ConfirmDelete() == false)
                    e.Cancel = true;

                updateClipboardCount();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void btnPasteClipboardRecords_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (Janus.Windows.GridEX.GridEXRow gsi in gridexAFClipboard.GetCheckedRows())
                {

                    //get activityfield row from grid

                    ActivityConfig.ActivityFieldRow oafr = (ActivityConfig.ActivityFieldRow)(((DataRowView)gsi.DataRow).Row);

                    //create new activityfield row for each selected item
                    //update acseries id to currentacs.acseriesid
                    ActivityConfig.ActivityFieldRow afr = (ActivityConfig.ActivityFieldRow)AtMng.acMng.GetActivityField().Add(CurrentACS());
                    int newId = afr.ActivityFieldID;
                    int newAcSeriesid = CurrentACS().ACSeriesId;
                    if (!oafr.IsDefaultFieldNameNull())
                        afr.DefaultFieldName = oafr.DefaultFieldName;
                    if (!oafr.IsDefaultObjectNameNull())
                        afr.DefaultObjectName = oafr.DefaultObjectName;
                    if (!oafr.IsDefaultValueNull())
                        afr.DefaultValue = oafr.DefaultValue;
                    if (!oafr.IsNull("FieldName"))
                        afr.FieldName = oafr.FieldName;
                    if (!oafr.IsFieldTypeNull())
                        afr.FieldType = oafr.FieldType;
                    //afr.Format = oafr.Format;
                    if (!oafr.IsHelpENull())
                        afr.HelpE = oafr.HelpE;
                    if (!oafr.IsHelpFNull())
                        afr.HelpF = oafr.HelpF;
                    if (!oafr.IsLabelEngNull())
                        afr.LabelEng = oafr.LabelEng;
                    if (!oafr.IsLabelFreNull())
                        afr.LabelFre = oafr.LabelFre;
                    if (!oafr.IsLookUpNull())
                        afr.LookUp = oafr.LookUp;
                    if (!oafr.IsMaskNull())
                        afr.Mask = oafr.Mask;
                    if (!oafr.IsObjectAliasNull())
                        afr.ObjectAlias = oafr.ObjectAlias;
                    if (!oafr.IsNull("ObjectName"))
                        afr.ObjectName = oafr.ObjectName;

                    afr.Required = oafr.Required;

                    if (!oafr.IsSeqNull())
                        afr.Seq = oafr.Seq;
                    if (!oafr.IsSpecialParameterNull())
                        afr.SpecialParameter = oafr.SpecialParameter;
                    if (!oafr.IsStepNull())
                        afr.Step = oafr.Step;
                    if (!oafr.IsTaskNameNull())
                        afr.TaskName = oafr.TaskName;
                    if (!oafr.IsNull("TaskType"))
                        afr.TaskType = oafr.TaskType;

                    afr.Visible = oafr.Visible;



                    //afr.ItemArray = oafr.ItemArray;
                    //afr.ActivityFieldID = newId;
                    //afr.ACSeriesId = newAcSeriesid;
                    i++;

                }
                string plrl = "";

                if (i == 0)
                    MessageBox.Show("No rows are checked in the grid.  No Activity Field Rows were pasted", "No Records Pasted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (i > 1)
                        plrl = "s";
                    MessageBox.Show(i + " Activity Field Row" + plrl + " successfully pasted.");
                }




            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridexRecordsUsed_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                ActivityConfig.ActivityFieldRow afr = getACFieldRowFromGridex(e.Row);
                if (afr != null)
                {
                    if (afr.RowState == DataRowState.Added)
                        e.Row.Cells["State"].Value = 1;
                    else if (afr.RowState == DataRowState.Modified)
                        e.Row.Cells["State"].Value = 2;
                    else
                        e.Row.Cells["State"].Value = 0;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void seriesGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (e.Row.RowType != Janus.Windows.GridEX.RowType.Record)
                    return;

                ShowPanel(pnlSeriesDetails);

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                MainAdminForm.DoSetWFCoords(e.Location);
                //panel1.Focus();
                Workflow.Step s = diagram.HitStep(e.Location);


                Workflow.Connector c = diagram.HitConnector(e.Location);
                if (c != null)
                {
                    if (c.myACD.ACBFRow != null && !c.myACD.ACBFRow.IsRoleCodeNull())
                    {
                        string roleDesc = UIHelper.GetRoleCodeTypeAndDescription(c.myACD.ACBFRow.RoleCode, false);
                        toolTip1.SetToolTip(panel1, roleDesc);
                    }
                    else
                        toolTip1.Hide(panel1);
                }
                else
                    toolTip1.Hide(panel1);


            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }


        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                System.Windows.Forms.ScrollableControl sc = (System.Windows.Forms.ScrollableControl)sender;
                switch (e.KeyValue)
                {
                    case (int)Keys.Down:

                        break;
                    case (int)Keys.Up:

                        break;
                    case (int)Keys.Right:

                        break;
                    case (int)Keys.Left:

                        break;
                }

            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void gridExRoleLegend_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                string sColor = e.Row.Cells["Color"].Text.ToString();
                Color cColor = Color.FromArgb(Convert.ToInt32(sColor));
                Janus.Windows.GridEX.GridEXFormatStyle gfs = new Janus.Windows.GridEX.GridEXFormatStyle();
                gfs.BackColor = cColor;
                e.Row.RowStyle = gfs;
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void uiContextMenu8_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {

        }

        private void pnlNextStepsContainer_Click(object sender, EventArgs e)
        {

        }
    }
}

