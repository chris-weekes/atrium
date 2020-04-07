using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using LawMate.UserControls;

// TFS#59851: UserControl created to accomodate adding multiple issues

namespace LawMate
{
    public partial class ucSSTCaseMatter : UserControl, IRequiredCtl
    {

        atriumBE.SSTManager SSTM;
        atriumBE.FileManager myFM;
        int confirmedByMemberId = 0;

        public ucSSTCaseMatter()
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

                    atLogic.WhereClause wcAll = new atLogic.WhereClause();
                    DataTable dtOutcomeAll = FM.Codes("vOutcome", wcAll, true);

                    UIHelper.ComboBoxInit("Program", sSTCaseMatterGridEX.DropDowns["ddProgram"], myFM);
                    UIHelper.ComboBoxInit(dtOutcomeAll, sSTCaseMatterGridEX.DropDowns["ddOutcome"], myFM);
                    UIHelper.ComboBoxInit("vissue", sSTCaseMatterGridEX.DropDowns["ddIssue"], myFM);
                    UIHelper.ComboBoxInit("vmemberlist", sSTCaseMatterGridEX.DropDowns["ddMemberList"], myFM);
                   
                    ucIssueSelectBoxRF1.FM = myFM;
                    SSTM = myFM.GetSSTMng();
                    atLogic.WhereClause wc = new atLogic.WhereClause();
                    if (!SSTM.DB.SSTCase[0].IsDecisionTypeNull())
                        wc.Add("DecisionType", "=", SSTM.DB.SSTCase[0].DecisionType);
                    DataTable dtOutcome = FM.Codes("vOutcome", wc, true);
                    UIHelper.ComboBoxInit(dtOutcome, outcomeIducMultiDropDown, myFM);

                    if (PromptIssueMode || IsSettingOutcome || PromptNoIssueMode)
                    {
                        atriumDB.FileContactRow FCR = myFM.GetFileContact().GetByRole("FTM");
                        if (FCR != null)
                        {
                            // only SST members can accept issues
                            if (FCR.ContactId != FM.AtMng.WorkingAsOfficer.ContactId)
                                throw new Exception("Only the assigned Tribunal Member may confirm the issues.");

                            confirmedByMemberId = myFM.GetFileContact().GetByRole("FTM").ContactId; // get SST Member Id
                        }
                    }

                    SetYesNoButtons();

                    if (!PromptIssueMode && !PromptNoIssueMode)
                        panelIssueList.Location = new Point(0, 0);

                    SetOutcomeEnabled();
                }
            }
        }

        private void SetYesNoButtons()
        {
            if (PromptNoIssueMode)
            {
                if (!CheckIssuePresent())
                {
                    pnlAcceptIssue.Enabled = false;
                    if (undoClicked)
                        btnAddIssue.Visible = true;
                }
            }
        }

        public object DataSource
        {
            set
            {
                // only pass in dataview or datatable
                sSTCaseMatterBindingSource.DataSource = value;
                sSTCaseMatterBindingSource.DataMember = "";
            }
        }

        // property used when SST member is asked to accept the issues, but there are no initial issues
        private bool promptNoIssueMode = false;
        public bool PromptNoIssueMode
        {
            get
            {
                return promptNoIssueMode;
            }
            set
            {
                promptNoIssueMode = value;
                this.pnlAcceptIssue.Visible = promptNoIssueMode;
                this.pnlAcceptIssue.Enabled = false;
                this.sSTCaseMatterGridEX.RootTable.FormatConditions["FormatConditionIssueIdNull"].Enabled = promptNoIssueMode;

                EditableScreen(promptNoIssueMode);
                if (promptNoIssueMode)
                {
                    sSTCaseMatterGridEX.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
                    panelIssueList.Location = new Point(0, 68);
                    btnAddIssue.Visible = false;
                }
                else
                {
                    sSTCaseMatterGridEX.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.False;
                }
            }
        }

        // property used when SST member is asked to accept the issues
        private bool promptIssueMode = false;
        public bool PromptIssueMode
        {
            get
            {
                return promptIssueMode;
            }
            set 
            {
                promptIssueMode = value;
                this.pnlAcceptIssue.Visible = promptIssueMode;
                this.sSTCaseMatterGridEX.RootTable.FormatConditions["FormatConditionIssueIdNull"].Enabled = promptIssueMode;
                if (promptIssueMode)
                {
                    EditableScreen(false);
                    sSTCaseMatterGridEX.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
                    panelIssueList.Location = new Point(0, 68);
                }
                else
                {
                    sSTCaseMatterGridEX.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.False;
                }
            }
        }

        // property used when SST member is asked to set the outcome of the issues
        private bool isSettingOutcome = false;
        public bool IsSettingOutcome
        {
            get
            {
                return isSettingOutcome;
            }
            set
            {
                isSettingOutcome = value;
                this.sSTCaseMatterGridEX.RootTable.FormatConditions["FormatConditionOutcomeIdNull"].Enabled = isSettingOutcome;
                if (isSettingOutcome)
                {
                    this.sSTCaseMatterGridEX.RootTable.Columns["Delete"].Visible = false;
                    this.btnAddIssue.Visible = false;
                }
            }
        }

        private void sSTCaseMatterGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key.ToUpper() == "DELETE") // verify which column button was clicked
                {
                    if (CurrentRow() == null) { return; }

                    if (SSTM.GetSSTCaseMatter().CanDelete(CurrentRow()))
                    {
                        if (SSTM.DB.SSTCaseMatter.Select("","", DataViewRowState.CurrentRows).Length > 1)
                        {
                            if (UIHelper.ConfirmDelete(Properties.Resources.UIConfirmDeleteIssue, Properties.Resources.UIConfirmDeleteIssueCaption))
                            {
                                CurrentRow().Delete();
                                sSTCaseMatterBindingSource.EndEdit();
                                if (PromptIssueMode || PromptNoIssueMode)
                                    OnValidated(new EventArgs());
                            }
                        }
                        else
                        {
                            // inform user to modify last existing issue rather than deleting it.
                            UIHelper.ConfirmCannotDeleteLastIssue();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucIssueSelectBoxRF1_IssueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                if (ucIssueSelectBoxRF1.IssueId.ToString() != string.Empty)
                {
                    btnAddIssue.Enabled = true;
                    btnAddIssue.Visible = true;
                    sSTCaseMatterBindingSource.EndEdit();
                    OnValidated(new EventArgs());
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void descriptionEditBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.TextBoxTextCounter(descriptionEditBox, DescCounter, 1000);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {
            try
            {
                SST.SSTCaseRow sstR = SSTM.DB.SSTCase[0];
                if (SSTM.GetSSTCaseMatter().CanAdd(sstR))
                {

                    lmDatasets.SST.SSTCaseMatterRow SSTMNewRow = (lmDatasets.SST.SSTCaseMatterRow)SSTM.GetSSTCaseMatter().Add(sstR);
                    atriumDB.FileContactRow FCR = myFM.GetFileContact().GetByRole("FTM");
                    if (promptIssueMode || promptNoIssueMode || (FCR != null && FM.AtMng.WorkingAsOfficer.ContactId == FCR.ContactId))
                    {
                        SSTMNewRow.ConfirmedByMemberId = FM.AtMng.WorkingAsOfficer.ContactId;
                    }

                    sSTCaseMatterBindingSource.Position = sSTCaseMatterBindingSource.Find("SSTCaseMatterId", SSTMNewRow.SSTCaseMatterId);
                    this.ucIssueSelectBoxRF1.OpenBrowseIssueDialog();
                    OnValidated(new EventArgs());
                }
                SetYesNoButtons();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
            
        // event fired when yes/no radio buttons selected
        private void CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                EditableScreen(uirdbtnNo.Checked);

                foreach (SST.SSTCaseMatterRow row in FM.GetSSTMng().DB.SSTCaseMatter)
                {
                    if(CheckRowAttached(row))
                        row.ConfirmedByMemberId = confirmedByMemberId;
                }

                uirdbtnNo.Visible = uirdbtnNo.Checked;
                uirdbtnYes.Visible = uirdbtnYes.Checked;
                lblNoMessage.Visible = uirdbtnNo.Checked;
                lblYesMessage.Visible = uirdbtnYes.Checked;

                uiButtonUndo.Visible = uirdbtnNo.Visible || uirdbtnYes.Visible;

                OnValidated(new EventArgs());
            }
            catch (Exception ex)
            {
                UIHelper.HandleUIException(ex);
            }
        }

        bool undoClicked = false;
        private void uiButtonUndo_Click(object sender, EventArgs e)
        {
            try
            {
                undoClicked = true;
                //TFS #61951 AC: 2013-12-12 - allow user to revert back to original state
                uirdbtnNo.Checked = false;
                uirdbtnYes.Checked = false;
                uirdbtnNo.Visible = true;
                uirdbtnYes.Visible = true;
                uiButtonUndo.Visible = false;
                UIHelper.Cancel(sSTCaseMatterBindingSource, SSTM.DB.SSTCaseMatter);
                SSTM.DB.SSTCaseMatter.AcceptChanges();
                SetYesNoButtons();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally
            {
                undoClicked = false;
            }
        }

        private void outcomeIducMultiDropDown_Validated(object sender, EventArgs e)
        {
            try
            {
                OnValidated(new EventArgs());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public Color ReqColor
        {
            get
            {
                return ucIssueSelectBoxRF1.ReqColor;
            }
            set
            {
                if (IsSettingOutcome)
                {
                    this.outcomeIducMultiDropDown.ReqColor = value;
                }
                else
                {
                    this.ucIssueSelectBoxRF1.ReqColor  = value;
                }
            }
        }

        public bool IsPopulated
        {
            get 
            {
                sSTCaseMatterBindingSource.EndEdit();

                if (PromptIssueMode)
                {
                    if (this.uirdbtnYes.Checked)
                    {
                        return true;
                    }
                    else if (this.uirdbtnNo.Checked)
                    {
                        return CheckIssuePresent();
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (PromptNoIssueMode)
                {
                    if (CheckIssuePresent())
                    {
                        pnlAcceptIssue.Enabled = true;
                        if (this.uirdbtnYes.Checked || this.uirdbtnNo.Checked)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        pnlAcceptIssue.Enabled = false;
                        return false;
                    }
                }
                else if (IsSettingOutcome)
                {
                    foreach (SST.SSTCaseMatterRow row in FM.GetSSTMng().DB.SSTCaseMatter)
                    {
                        if (CheckRowAttached(row) && row.IsOutcomeIdNull())
                            return false;
                    }
                    return true;
                }
                else
                {
                    return CheckIssuePresent();
                }
            }
        }

        // private methods

        private bool CheckIssuePresent()
        {
            if (FM.GetSSTMng().DB.SSTCaseMatter.Count <= 0)
                return false;

            // check if every row has an Issue Id
            foreach (SST.SSTCaseMatterRow row in FM.GetSSTMng().DB.SSTCaseMatter)
            {
                if (CheckRowAttached(row))
                {
                    if (row.IsIssueIdNull())
                        return false;
                }
            }
            return true;
        }

        private bool CheckRowAttached(SST.SSTCaseMatterRow row)
        {
            if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached)
                    return true;
            return false;
        }

        private void EditableScreen(bool editable)
        {
            // display/hide certain controls and columns depending on yes/no decision of SST member
            btnAddIssue.Visible = editable;
            sSTCaseMatterGridEX.RootTable.Columns["Delete"].Visible = editable;
            UIHelper.EnableControls(sSTCaseMatterBindingSource, editable);
            outcomeIducMultiDropDown.Enabled = false; //in this context, outcome always disabled
        }

        private SST.SSTCaseMatterRow CurrentRow()
        {
            // gets current SSTCaseMatterRow
            if (sSTCaseMatterBindingSource.Current == null)
                return null;
            else
                return (SST.SSTCaseMatterRow)((DataRowView)sSTCaseMatterBindingSource.Current).Row;
        }

        // purpose: to override enabling of outcome drop down that is set by ReadOnly and ApplySecurity
        private void SetOutcomeEnabled()
        {
            if (!IsSettingOutcome)
            {

                if (this.outcomeIducMultiDropDown.Enabled)
                {
                    // check if outcome has been set, but needs to be revised
                    //foreach (SST.SSTCaseMatterRow row in FM.GetSSTMng().DB.SSTCaseMatter)
                    //{
                        if (CurrentRow() !=null && CurrentRow().IsOutcomeIdNull())
                        {
                            outcomeIducMultiDropDown.Enabled = false;
                            //break;
                        }
                    //}
                }
            }
        }

        // public methods

        public void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(sSTCaseMatterBindingSource, !makeReadOnly);
            this.btnAddIssue.Enabled = !makeReadOnly;
            this.sSTCaseMatterGridEX.Enabled = !makeReadOnly;

            SetOutcomeEnabled();
        }

        public void ApplySecurity(DataRow dr)
        {
            if (SSTM != null)
            {
                SST.SSTCaseRow cbr = (SST.SSTCaseRow)dr;
                UIHelper.EnableControls(sSTCaseMatterBindingSource, SSTM.GetSSTCase().CanEdit(cbr));
                SetOutcomeEnabled();
            }
        }




        public void RequiredAction()
        {
            
        }
    }
}