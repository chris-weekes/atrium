using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

namespace LawMate.UserControls
{
    public partial class ucActivityBF : LawMate.ucBase
    {
        public ucActivityBF()
        {
            InitializeComponent();
        }

        public void ucActLoad()
        {
            try
            {
                //HookUpGridExDropDowns();
                //editBox1.DataBindings.Add("Text", activityBFBindingSource, UIHelper.Translate(FM, "BFDescriptionEng"));
                //BindActivityData(FM.DB.Activity);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void BindActivityBFData(lmDatasets.atriumDB.ActivityBFDataTable dtBF)
        {
            UIHelper.ComboBoxInit(FM.AtMng.acMng.DB.ACBF, activityBFGridEX.DropDowns["ddACBFId"], FM);
            UIHelper.ComboBoxInit("vRoleucontacttype", activityBFGridEX.DropDowns["ddRoleCode"], FM);
            UIHelper.ComboBoxInit(FM.AtMng.acMng.DB.ACSeries, activityBFGridEX.DropDowns["ddAcSeries"], FM);
            UIHelper.ComboBoxInit("vOfficerList", activityBFGridEX.DropDowns["ddOfficer"], FM);
            ucBFOfficerId.FM = FM;
            ucContactSelectBox1.FM = FM;
            priorityJComboBox.ImageList = UIHelper.browseImgList();
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityNormal, 0, 36));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityHigh, 1, 34));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityUrgent, 2, 35));

            editBox1.DataBindings.Add("Text", activityBFBindingSource, UIHelper.Translate(FM, "BFDescriptionEng"));

            DataView dv = new DataView(dtBF, "", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);

            activityBFBindingSource.DataSource = dv;
            activityBFBindingSource.DataMember = "";

            //activityBFBindingSource.Filter = "not (isMail=1 and BFOfficerid<>" + FM.AtMng.WorkingAsOfficer.OfficerId.ToString() + ")";

            dtBF.ColumnChanged += new DataColumnChangeEventHandler(dtBF_ColumnChanged);
            FM.GetActivityBF().OnUpdate += new atLogic.UpdateEventHandler(ucActivityBF_OnUpdate);

            if (dtBF.Rows.Count == 0)
                UIHelper.EnableControls(activityBFBindingSource, false);
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        public override void ReloadUserControlData()
        {
            activityBFGridEX.MoveFirst();
        }

        void ucActivityBF_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dtBF_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                {
                    ApplyBR(false);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override string ucDisplayName()
        {
            return Properties.Resources.ActivityBFBFs ;
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        bool InEditMode = false;
        public override void ApplyBR(bool DataNotDirty)
        {
            fFile f = FileForm();
            if (f != null)
            {
                f.IsDirty = !DataNotDirty;

                if (f.ReadOnly)
                    return;

                f.fileToc.Enabled = DataNotDirty;
                f.EditModeTitle(!DataNotDirty);
            }

            InEditMode = !DataNotDirty;
            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(activityBFBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && !FileForm().ReadOnly && dr != null)
            {
                atriumDB.ActivityBFRow ar = (atriumDB.ActivityBFRow)dr;
                if (dr.RowState == DataRowState.Added)
                {
                    ucBFOfficerId.Visible = true;
                    ebBFPerson.Visible = false;
                    UIHelper.EnableControls(activityBFBindingSource, true);
                }
                else
                {
                    ucBFOfficerId.Visible = false;
                    ebBFPerson.Visible = true;
                    UIHelper.EnableControls(activityBFBindingSource, FM.GetActivityBF().CanEditBF(ar));
                }

                if (ar.Completed)
                {
                    cmdCompleteBF.Image = LawMate.Properties.Resources.checkboxFalse;
                    cmdCompleteBF.Text = LawMate.Properties.Resources.UncompleteBF;
                    cmdCompleteBF.ToolTipText = LawMate.Properties.Resources.UncompleteBF;
                }
                else
                {
                    cmdCompleteBF.Image = LawMate.Properties.Resources.checkbox;
                    cmdCompleteBF.Text = LawMate.Properties.Resources.CompleteBF;
                    cmdCompleteBF.ToolTipText = LawMate.Properties.Resources.CompleteBF;
                }

                if (FM.GetActivityBF().CanEditBF(ar))
                    cmdCompleteBF.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmdCompleteBF.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            }

            if(dr==null)
                UIHelper.EnableControls(activityBFBindingSource, false);
        }

        public override void Cancel()
        {
            UIHelper.Cancel(activityBFBindingSource);
            ApplyBR(true);
        }

        private atriumDB.ActivityBFRow CurrentRow()
        {
            if (activityBFBindingSource.Current == null)
                return null;
            else
                return (atriumDB.ActivityBFRow)((DataRowView)activityBFBindingSource.Current).Row;
        }




        private void activityBFGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                lmWinHelper.FormatGridRowBFIsUnread(FM, e.Row);
                lmWinHelper.FormatGridRowBFDate(FM, e.Row);
            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine(x.Message);
            }
        }

        private void activityBFGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                lmWinHelper.FormatGridRowBFOfficer(e.Row);
                lmWinHelper.FormatGridRowBFDateLoading(e.Row);

                atriumDB.ActivityBFRow abfr = (atriumDB.ActivityBFRow)((DataRowView)e.Row.DataRow).Row;
                e.Row.Cells["StepCode"].Value = abfr.ActivityRow.StepCode;

            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine(x.Message);
            }
        }

        private void activityBFBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                //apply security
                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            int row = activityBFBindingSource.Find("ActivityBFId", linkId);
            if (row == -1)
            {
                //2017-08-15 JLL: Added in extra check.  without this, user would not realize more info didn't work when filter was "on"
                if (cmdHideCompletedBFs.IsChecked)
                    cmdHideCompletedBFs.InvokeOnClick();

                row = activityBFBindingSource.Find("ActivityBFId", linkId);
                if (row == -1)
                    MessageBox.Show(Properties.Resources.ActivityBFMoreInfoNotFound);
                else
                    activityBFBindingSource.Position = row;
            }
            else
                activityBFBindingSource.Position = row;
        }

        private void activityBFGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (activityBFGridEX.CurrentRow != null)
                {
                    if (CurrentRow().IsBFOfficerIDNull())
                        ebBFPerson.Text = activityBFGridEX.CurrentRow.Cells["RoleCode"].Text;
                    else
                        ebBFPerson.Text = activityBFGridEX.CurrentRow.Cells["BFOfficerId"].Text;
                }
                else
                    ebBFPerson.Text = "";
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "StepCode")
                {
                    //FileForm().MoreInfo("activity", CurrentRow().ActivityId);
                    
                    //2017-08-11 JLL: More info did not work properly
                    //was just selecting AC without selecting correct BF, or even displaying BF tab
                    //fixed now with new MoreInfo methods on ucActivity
                    ucBase ctl = FileForm().MoreInfo("activity");
                    ucActivity acCtl = (ucActivity)ctl;
                    acCtl.MoreInfoBF("activity", CurrentRow().ActivityId, CurrentRow());

                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private Janus.Windows.GridEX.GridEXRow _currentRow;

        private Janus.Windows.GridEX.GridEXRow ToolTipRow
        {
            get
            {
                return _currentRow;
            }
            set
            {
                if (_currentRow != value)
                {
                    if (_currentRow == null)
                    {
                        this.janusSuperTip1.SetSuperTip(activityBFGridEX, null);
                    }
                    _currentRow = value;
                    if (_currentRow != null)
                    {
                        atriumDB.ActivityBFRow abfr = (atriumDB.ActivityBFRow)((DataRowView)_currentRow.DataRow).Row;
                        atriumDB.ActivityRow ar = FM.DB.Activity.FindByActivityId(abfr.ActivityId);
                        Janus.Windows.Common.SuperTipSettings sts = new Janus.Windows.Common.SuperTipSettings();
                        sts.ToolTipStyle = Janus.Windows.Common.ToolTipStyle.Office2010;
                        sts.HeaderText = Properties.Resources.ActivityBFStepCode + ar.StepCode;
                        sts.HeaderImage = Properties.Resources.act;
                        string ttBody = ar.ActivityDate.ToString("yyyy/MM/dd") + Environment.NewLine;
                        ttBody += ar[FM.AtMng.Translate("ActivityNameEng")].ToString();
                        if(!ar.IsOfficeCodeNull() && !ar.IsOfficerCodeNull())
                            ttBody += Environment.NewLine + ar.OfficeCode + " - " + ar.OfficerCode;
                        sts.Text = ttBody;

                        this.janusSuperTip1.Show(sts, this.activityBFGridEX);
                    }
                    else
                        this.janusSuperTip1.HideActiveToolTip();
                }
            }
        }


        private void activityBFGridEX_FetchCellToolTipText(object sender, Janus.Windows.GridEX.FetchCellToolTipTextEventArgs e)
        {
            try
            {
                //if (e.Row != null && e.Row.DataRow != null)
                //{
                //    ToolTipRow = e.Row;
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.GridArea hitTest = activityBFGridEX.HitTest(e.X, e.Y);
                int rowPos = activityBFGridEX.RowPositionFromPoint();
                Janus.Windows.GridEX.GridEXRow ger = activityBFGridEX.GetRow(rowPos);
                Janus.Windows.GridEX.GridEXColumn gec = activityBFGridEX.ColumnFromPoint(e.X, e.Y);
                if (ger != null && ger.RowType == Janus.Windows.GridEX.RowType.Record && gec != null && gec.Key == "StepCode" && showTooltip)
                    ToolTipRow = ger;
                else
                    ToolTipRow = null;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_MouseLeave(object sender, EventArgs e)
        {
            ToolTipRow = null;
        }

        bool showTooltip = true;
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdToggleTooltip":
                        showTooltip = !showTooltip;
                        break;
                    case "cmdCompleteBF":
                        CurrentRow().Completed = !CurrentRow().Completed;
                        CurrentRow().ManuallyCompleted = CurrentRow().Completed;
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdHideCompletedBFs":
                        //JLL: 2017-01-19 - commented out line below, it got missed when commenting out the previous reference above to the binding source filter
                        //string basefilter = "not (isMail=1 and BFOfficerid<>" + FM.AtMng.WorkingAsOfficer.OfficerId.ToString() + ")";
                        if (cmdHideCompletedBFs.IsChecked)
                            activityBFBindingSource.Filter = "completed=0";
                        else
                            activityBFBindingSource.Filter = "";
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void Save()
        {
            if (FM.DB.ActivityBF.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.activityBFBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();

                    bp.AddForUpdate(FM.GetActivityBF());
                    bp.AddForUpdate(FM.EFile);

                    bp.Update();

                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }

        private void activityBFGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                { e.Cancel = true; }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucActivityBF_Load(object sender, EventArgs e)
        {
            try
            {
                activityBFGridEX.MoveFirst();
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
                if (!FileForm().ReadOnly)
                {
                    atriumDB.ActivityBFRow acbf = CurrentRow();
                    if (acbf == null || (activityBFGridEX.HitTest() != Janus.Windows.GridEX.GridArea.Cell && activityBFGridEX.HitTest() != Janus.Windows.GridEX.GridArea.PreviewRow) || InEditMode)
                    {
                        uiContextMenu2.Close();
                        return;
                    }

                
                    if (acbf.Completed)
                    {
                        cmdCompleteBF.Image = LawMate.Properties.Resources.checkboxFalse;
                        cmdCompleteBF.Text = LawMate.Properties.Resources.UncompleteBF;
                    }
                    else
                    {
                        cmdCompleteBF.Image = LawMate.Properties.Resources.checkbox;
                        cmdCompleteBF.Text = LawMate.Properties.Resources.CompleteBF;
                    }
                }
                else
                {
                    uiContextMenu2.Close();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
