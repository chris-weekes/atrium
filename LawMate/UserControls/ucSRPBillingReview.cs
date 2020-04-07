using System;
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
    public partial class ucSRPBillingReview : ucBase
    {
        atriumBE.FileManager fmBillingReview;
        atriumBE.OfficeManager OfficeMngLeadOffice;
        List<int> loadedIRPs = new List<int>();
        List<int> loadedSRPs = new List<int>();
        bool userInitiatedNav = false;
        bool firstBind = true;
        public ucSRPBillingReview()
        {
            InitializeComponent();
            
        }

        public void BindData(atriumDB.IRPDataTable a)
        {

            OfficeMngLeadOffice = FM.AtMng.GetOffice(FM.CurrentFile.LeadOfficeId);
            fileIDucFileSelectBox.AtMng = FM.AtMng;
            officeIDucOfficeSelectBox.AtMng = FM.AtMng;
            officerIDucContactSelectBox.FM = FM;
            
            officeDB_IRPDataTableBindingSource.DataSource = a.DataSet;
            officeDB_IRPDataTableBindingSource.DataMember = a.TableName;

            a.ColumnChanged+= new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetIRP().OnUpdate += new atLogic.UpdateEventHandler(ucIRP_OnUpdate);

            UIHelper.ComboBoxInit("vofficerlist", activityGridEX.DropDowns["ddOfficer"], FM);
            UIHelper.ComboBoxInit("vofficerlist", activityTimeGridEX.DropDowns["ddOfficer"], FM);
            UIHelper.ComboBoxInit("DisbursementType", disbursementGridEX.DropDowns["ddDisbursementType"], FM);
            UIHelper.ComboBoxInit("vofficelist", disbursementGridEX.DropDowns["ddOffice"], FM);
            UIHelper.ComboBoxInit("taxrate", disbursementGridEX.DropDowns["ddTaxRate"], FM);

            UIHelper.ComboBoxInit("vofficerlist", taxingGridEX.DropDowns["ddOfficer"], FM);
            UIHelper.ComboBoxInit("vofficelist", taxingGridEX.DropDowns["ddOffice"], FM);
            UIHelper.ComboBoxInit("reasoncode", taxingGridEX.DropDowns["ddReason"], FM);
            
            officeDB_IRPDataTableBindingSource.CurrentChanged+=officeDB_IRPDataTableBindingSource_CurrentChanged;
            firstBind = false;
        }

        void ucIRP_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }
        
        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                switch (e.Column.ColumnName.ToLower())
                {
                    case "hours":
                        bool ischanged = fmBillingReview.IsFieldChanged(e.Column, e.Row);
                        if (ischanged & ! fmBillingReview.GetActivityTime().fixingHours)
                            ApplyBR(false);
                        break;
                    case "includeonsrp":
                        break;
                    default:
                        ApplyBR(false);
                        break;
                }   
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

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

            if (DataNotDirty)
            {
                tsGoToSRP.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsGoToSRPDetail.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsNext1.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsPrevious1.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                tsGoToSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsGoToSRPDetail.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsNext1.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsPrevious1.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }

        public void MoreInfo(string linkTable, int srpId, int IrpId)
        {
            userInitiatedNav = true;
            MoreInfo(linkTable, srpId);
            officeDB_IRPDataTableBindingSource.Position = officeDB_IRPDataTableBindingSource.Find("IrpId", IrpId);
            userInitiatedNav = false;
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            if(linkTable.ToUpper()=="BILLINGREVIEW") // link from ToC; linkid=SRPID
                FilterIRPsForSelectedSRP(linkId);
        }

        int currentSRPId;
        atriumDB.SRPRow currentSRPRow;
        bool SrpIsFinal;
        bool SrpIsSubmitted;
        bool SrpTaxationBegan;
        
        private void FilterIRPsForSelectedSRP(int srpId)
        {
            atriumDB.SRPRow[] srprs = (atriumDB.SRPRow[])FM.DB.SRP.Select("SRPID=" + srpId);

            currentSRPRow = srprs[0];
            currentSRPId = currentSRPRow.SRPID;


            if (currentSRPRow == null)
                throw new Exception("No SRP Row could be found");

            SrpIsFinal = (!currentSRPRow.IsTaxationCompletedNull());
            SrpIsSubmitted = !currentSRPRow.IsSRPSubmittedDateNull() && currentSRPRow.IsTaxationBeganNull();
            SrpTaxationBegan = !currentSRPRow.IsTaxationBeganNull() && currentSRPRow.IsTaxationCompletedNull();

            officeDB_IRPDataTableBindingSource.Filter = "SRPID=" + currentSRPId;

            //do i want this here? FIND out
            LoadBillingReviewData();
        }


        public override void ReloadUserControlData()
        {
            //loadedSRPs.Clear();
            if (FM.DB.SRP.Count == 0) 
            {
                //assume data is not loaded yet
                FM.GetSRP().LoadByFileId(FM.CurrentFile.FileId);
                FM.GetIRP().LoadBySRPId(currentSRPId);
            //    FM.GetCLASMng().GetTaxing().LoadBySRPID(currentSRPId);
            }
            MoreInfo("BILLINGREVIEW", currentSRPId, billingReviewIrpId);
         
        }

        private void applyIncludeOnSRPFilter(atriumDB.IRPRow irpDR)
        {
            //clear filterl reapply after IncludeOnSRP data is set
            activityBindingSource.Filter = "";

         
            fmBillingReview.GetActivityTime().IncludeOnSRP( irpDR, true,!irpDR.SRPRow.IsSRPSubmittedDateNull());

            fmBillingReview.GetDisbursement().IncludeOnSRP(irpDR, true, !irpDR.SRPRow.IsSRPSubmittedDateNull());

            activityBindingSource.Filter = "Max(Child(ActivityActivityTime).IncludeOnSRP)=True or Max(Child(ActivityDisbursement).IncludeOnSRP)=True ";
        }


        int billingReviewIrpId;
        private void LoadBillingReviewData()
        {
            if(FM.DB.IRP.Select("SRPID=" + currentSRPId.ToString()).Length==0)
            {
                FM.GetIRP().LoadBySRPId(currentSRPId);
            }
            atriumDB.IRPRow irpDR = CurrentRowIRP();
            if (irpDR == null)
                return;
                //throw new Exception("No IRPS; not loaded. Investigate");

            if (billingReviewIrpId != irpDR.IRPId)
            {
                //navigating IRP; load file
                if (fmBillingReview != null)
                {
                    //cleanup old one
                    fmBillingReview.DB.ActivityTime.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                    fmBillingReview.DB.Disbursement.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                    fmBillingReview.GetActivityTime().OnUpdate -= new atLogic.UpdateEventHandler(ucIRP_OnUpdate);
                    fmBillingReview.GetDisbursement().OnUpdate -= new atLogic.UpdateEventHandler(ucIRP_OnUpdate);
                }
                try
                { fmBillingReview = FM.AtMng.GetFile(irpDR.FileID); }
                catch (Exception xfd)
                {
                    //no file access?
                    UIHelper.HandleUIException(xfd);
                    MessageBox.Show("It appears as though you do not have access to the file you are attempting to view. Please contact CLAS to reestablish access, if required.");
                    //just get out of here I guess.  Leave a nasty mess on Billing Review. obviously not the right fix, but for now
                    tsGoToSRPDetail.InvokeOnClick();
                }


                fmBillingReview.InitActivityProcess();
                
                fmBillingReview.DB.ActivityTime.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
                fmBillingReview.DB.Disbursement.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);

                fmBillingReview.GetActivityTime().OnUpdate += new atLogic.UpdateEventHandler(ucIRP_OnUpdate);
                fmBillingReview.GetDisbursement().OnUpdate += new atLogic.UpdateEventHandler(ucIRP_OnUpdate);

                pnlIRP.Text = fmBillingReview.CurrentFile.NameE + " ("+ fmBillingReview.CurrentFile.FullFileNumber +")";

                activityBindingSource.DataSource =new DataView( fmBillingReview.DB.Activity ,"","", DataViewRowState.CurrentRows);
                activityBindingSource.DataMember = "";// fmBillingReview.DB.Activity.TableName;

                //clear filterl reapply after IncludeOnSRP data is set
                applyIncludeOnSRPFilter(irpDR);
                
                billingReviewIrpId = irpDR.IRPId;

                if(!irpDR.SRPRow.IsTaxationCompletedNull())
                    taxingBindingSource.Filter = "IRPID=" + irpDR.IRPId.ToString();
                else
                     taxingBindingSource.Filter = "IRPID=" + irpDR.IRPId.ToString() + " or IRPID is null";
                
                //else if (!irpDR.IsNull("DateTaxed"))
                //    taxingBindingSource.Filter = "IRPID=" + irpDR.IRPId.ToString() + " or IRPID is null";
                //else
                //    taxingBindingSource.Filter = "IRPID is null";

                taxingBindingSource.DataMember = fmBillingReview.GetCLASMng().DB.Taxing.TableName;
                taxingBindingSource.DataSource = fmBillingReview.GetCLASMng().DB;

                taxingGridEX.RootTable.Caption = "Taxing Recommendations (" + taxingBindingSource.Count + ")";

                ToggleTaxRecRecords(taxingBindingSource.Count>0);
            }
        }

        private void SaveBillingReview()
        {
            if (FM.DB.IRP.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else if (fmBillingReview.DB.Activity.HasErrors || fmBillingReview.DB.Disbursement.HasErrors || fmBillingReview.DB.ActivityTime.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(fmBillingReview.DB);
            }
            else if (fmBillingReview.GetCLASMng().DB.Taxing.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(fmBillingReview.GetCLASMng().DB);
            }
            else
            {
                try
                {
                    disbursementGridEX.UpdateData();
                    activityTimeGridEX.UpdateData();
                    this.activityBindingSource.EndEdit();
                    this.officeDB_IRPDataTableBindingSource.EndEdit();
                    activityTimeBindingSource.EndEdit();
                    disbursementBindingSource.EndEdit();
                    taxingBindingSource.EndEdit();
                    
                    FM.SaveAll();
                    fmBillingReview.SaveAll();
                                        
                    ApplyBR(true);
                    if (inOwnerTaxationMode)
                        ApplySecurityIRP(CurrentRowIRP());
                    //atLogic.BusinessProcess bp = FM.GetBP();
                    //bp.AddForUpdate(FM.GetActivity());
                    //bp.AddForUpdate(FM.GetIRP());
                    //bp.AddForUpdate(FM.GetSRP());
                    //bp.Update();
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
            }

        }

        private atriumDB.IRPRow CurrentRowIRP()
        {
            if(officeDB_IRPDataTableBindingSource.Current!=null)
                return (atriumDB.IRPRow)((DataRowView)officeDB_IRPDataTableBindingSource.Current).Row;

            return null;
        }
        private atriumDB.ActivityRow CurrentRowActivity()
        {
            if (activityBindingSource.Current != null)
                return (atriumDB.ActivityRow)((DataRowView)activityBindingSource.Current).Row;
                
            return null;
        }

        private atriumDB.ActivityTimeRow CurrentRowActivityTime()
        {
            if (activityTimeBindingSource.Current != null)
                return (atriumDB.ActivityTimeRow)((DataRowView)activityTimeBindingSource.Current).Row;

            return null;
        }

        private atriumDB.DisbursementRow CurrentRowDisbursement()
        {
            if (disbursementBindingSource.Current != null)
                return (atriumDB.DisbursementRow)((DataRowView)disbursementBindingSource.Current).Row;

            return null;
        }

        private CLAS.TaxingRow CurrentRowTaxing()
        {
            if(taxingBindingSource.Current!=null)
                return (CLAS.TaxingRow)((DataRowView)taxingBindingSource.Current).Row;

            return null;
        }
       
        public override void EndEdit()
        {
            officeDB_IRPDataTableBindingSource.EndEdit();
            activityTimeBindingSource.EndEdit();
            disbursementBindingSource.EndEdit();
            activityBindingSource.EndEdit();
        }

        private void setMessage(bool visible, string messageTxt, Image resource)
        {
            //uiCommandBar4.Visible = visible;
            gbMessage.Visible = visible;
            gbMessage.Image = resource;
            tsMessage.Text = messageTxt;
            label3.Text = messageTxt;
        }

        private void allowActivityTimeEdit(bool allowEdit)
        {
            if (allowEdit)
            {
                activityTimeGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                activityTimeGridEX.RootTable.Columns["Hours"].Selectable = true;
                activityTimeGridEX.RootTable.Columns["Hours"].CellStyle.ForeColor = Color.Blue;
                activityTimeGridEX.RootTable.Columns["Hours"].CellStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            }
            else
            {
                activityTimeGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                activityTimeGridEX.RootTable.Columns["Hours"].Selectable = false;
                activityTimeGridEX.RootTable.Columns["Hours"].CellStyle.BackColor = Color.White;
                activityTimeGridEX.RootTable.Columns["Hours"].CellStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            }
        }

        private void allowDisbGridEdit(bool allowEdit)
        {
            Color fc1;

            if (allowEdit)
            {
                fc1 = Color.Blue;
                disbursementGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                disbursementGridEX.RootTable.Columns["DisbTaxExempt"].CellStyle.FontBold = Janus.Windows.GridEX.TriState.True;
                disbursementGridEX.RootTable.Columns["DisbTaxable"].CellStyle.FontBold = Janus.Windows.GridEX.TriState.True;

                //2017-08-10 JLL: editable grid does not yet account for TaxRate. Workaround is for user to change it in Activity screen Disbursement tab
            }
            else
            {
                fc1 = SystemColors.ControlText;
                disbursementGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                disbursementGridEX.RootTable.Columns["DisbTaxExempt"].CellStyle.FontBold = Janus.Windows.GridEX.TriState.False;
                disbursementGridEX.RootTable.Columns["DisbTaxable"].CellStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            }

            disbursementGridEX.RootTable.Columns["DisbTaxExempt"].Selectable = allowEdit;
            disbursementGridEX.RootTable.Columns["DisbTaxable"].Selectable = allowEdit;
            disbursementGridEX.RootTable.Columns["TaxRateId"].Selectable = allowEdit;
            disbursementGridEX.RootTable.Columns["DisbTaxExempt"].CellStyle.ForeColor = fc1;
            disbursementGridEX.RootTable.Columns["DisbTaxable"].CellStyle.ForeColor = fc1;
            disbursementGridEX.RootTable.Columns["TaxRateId"].CellStyle.ForeColor = fc1;
        }

        private void ToggleTaxRecRecords(bool show)
        {
            if (show)
            {
                taxingGridEX.Visible = true;
                int pnlHeight1 = 302;
                //pnlHeight1= UIHelper.AdjustHeightInt(this, pnlHeight1); //no need to adjust height, control height unaffected by dpi swap
                pnlIRP.Height = pnlHeight1;
            }
            else
            {
                int pnlHeight2 = 194;
                //pnlHeight2 = UIHelper.AdjustHeightInt(this, pnlHeight2); //no need to adjust height, control height unaffected by dpi swap
                taxingGridEX.Visible = false;
                pnlIRP.Height = pnlHeight2;
            }
        }

        bool inOwnerTaxationMode = false;
        private void ApplySecurityIRP(DataRow irpRow) //IRP
        {

            //this first block pretty much just locks everything up
            //as we determine state, funtionality is enabled/made available.
            atriumDB.IRPRow irpr = (atriumDB.IRPRow)irpRow;
            pnlIRP.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            cmdSaveAndNext.Visible = Janus.Windows.UI.InheritableBoolean.False;
            cmdSaveAndPrevious.Visible = Janus.Windows.UI.InheritableBoolean.False;
            inOwnerTaxationMode = false;
            dateTaxedBillingReview.ReadOnly = true;
            dateTaxedBillingReview.BackColor = SystemColors.Control;
            officerIDucContactSelectBox.ReadOnly = true;
            officerIDucContactSelectBox.BackColor = SystemColors.Control;
            btnClearOfficer.Visible = false;
            btnClearOfficer.Enabled = false;
            btnRollbackTaxation.Visible = false;
            btnRollbackTaxation.Enabled = false;
            feesTaxedNumericEditBox.ReadOnly = true;
            feesTaxedNumericEditBox.BackColor = SystemColors.Control;
            disbursementTaxedNumericEditBox.ReadOnly = true;
            disbursementTaxedNumericEditBox.BackColor = SystemColors.Control;
            disbursementTaxExemptTaxedNumericEditBox.ReadOnly = true;
            disbursementTaxExemptTaxedNumericEditBox.BackColor = SystemColors.Control;
            //taxingGridEX.RootTable.Columns["Closed"].SelectableCells = Janus.Windows.GridEX.SelectableCells.None;
            allowActivityTimeEdit(false);
            allowDisbGridEdit(false);
            tsSaveBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            taxingGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            taxingGridEX.RootTable.Columns["Selector"].Visible = false;
            taxingGridEX.RootTable.Columns["Comment"].AutoSize();
            if (taxingGridEX.RootTable.Columns["Comment"].Width < 320)
                taxingGridEX.RootTable.Columns["Comment"].Width = 320;
            cmdAddTaxRec.Visible = Janus.Windows.UI.InheritableBoolean.False;
            btnApplyTaxRecs.Visible = false;
            activityGridEX.RowFormatStyle.ForeColor = SystemColors.ControlText;
            activityTimeGridEX.RowFormatStyle.ForeColor = SystemColors.ControlText;
            disbursementGridEX.RowFormatStyle.ForeColor = SystemColors.ControlText;
            disbursementTaxedTaxNumericEditBox.ReadOnly = true;
            disbursementTaxedTaxNumericEditBox.BackColor = SystemColors.Control;
            disbursementTaxedTaxNumericEditBox.HasImage = false;

            //  ----------------------------------------------------------------------------------------   
            //  SRP IS NOT COMMITTED
            //  ----------------------------------------------------------------------------------------
            if (irpr.SRPRow.IsSRPSubmittedDateNull())
            {
                if (fmBillingReview.AllowedForOwnerOrSysAdmin()) // Owner/SysAdmin block
                {
                    //CLAS is viewing SRP before it is submitted
                    //Should all be ReadOnly
                    taxingGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                    cmdAddTaxRec.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    allowActivityTimeEdit(false);
                    allowDisbGridEdit(false);
                    setMessage(true, LawMate.Properties.Resources.UISRPNotCommittedCantModify, Properties.Resources.warning_16x16);
                        
                }
                else if (CurrentRowIRP().OfficeID == fmBillingReview.AtMng.WorkingAsOfficer.OfficeId)//Agent block
                {
                    //Agent is viewing SRP before it is submitted
                    //Allow edit by Agent
                    allowActivityTimeEdit(true);
                    allowDisbGridEdit(true);
                    tsSaveBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    setMessage(false, "", Properties.Resources.warning_16x16);
                }
                else
                {
                    //Someone other than CLAS or Agent is viewing SRP before it is submitted (Client?)
                    // should all be readonly
                    allowActivityTimeEdit(false);
                    allowDisbGridEdit(false);
                    activityGridEX.RowFormatStyle.ForeColor = Color.DarkGray;
                    activityTimeGridEX.RowFormatStyle.ForeColor = Color.DarkGray;
                    disbursementGridEX.RowFormatStyle.ForeColor = Color.DarkGray;

                    dateTaxedBillingReview.ReadOnly = true;
                    dateTaxedBillingReview.BackColor = SystemColors.Control;
                    officerIDucContactSelectBox.ReadOnly = true;
                    officerIDucContactSelectBox.BackColor = SystemColors.Control;
                    feesTaxedNumericEditBox.ReadOnly = true;
                    feesTaxedNumericEditBox.BackColor = SystemColors.Control;
                    disbursementTaxedNumericEditBox.ReadOnly = true;
                    disbursementTaxedNumericEditBox.BackColor = SystemColors.Control;
                    disbursementTaxExemptTaxedNumericEditBox.ReadOnly = true;
                    disbursementTaxExemptTaxedNumericEditBox.BackColor = SystemColors.Control;
                }
            }

            //  ----------------------------------------------------------------------------------------   
            //  SRP IS COMMITTED
            //  ----------------------------------------------------------------------------------------
            else
            {
                if (!irpr.SRPRow.IsTaxationCompletedNull())
                {
                    //Lock it up, all around, for everyone

                    activityGridEX.RowFormatStyle.ForeColor = Color.DarkGray;
                    activityTimeGridEX.RowFormatStyle.ForeColor = Color.DarkGray;
                    disbursementGridEX.RowFormatStyle.ForeColor = Color.DarkGray;

                    dateTaxedBillingReview.ReadOnly = true;
                    dateTaxedBillingReview.BackColor = SystemColors.Control;
                    officerIDucContactSelectBox.ReadOnly = true;
                    officerIDucContactSelectBox.BackColor = SystemColors.Control;
                    feesTaxedNumericEditBox.ReadOnly = true;
                    feesTaxedNumericEditBox.BackColor = SystemColors.Control;
                    disbursementTaxedNumericEditBox.ReadOnly = true;
                    disbursementTaxedNumericEditBox.BackColor = SystemColors.Control;
                    disbursementTaxExemptTaxedNumericEditBox.ReadOnly = true;
                    disbursementTaxExemptTaxedNumericEditBox.BackColor = SystemColors.Control;
                    
                    ToggleTaxRecRecords(taxingBindingSource.Count > 0);
                    setMessage(true, LawMate.Properties.Resources.UITaxationCompletedReadOnly, Properties.Resources.warning_16x16);
                }
                
                else if (FM.AllowedForOwnerOrSysAdmin())
                {
                    // Owner/SysAdmin viewing page
                    //apply these whether or not taxation has started
                    
                    setMessage(false, "", Properties.Resources.warning_16x16);
                    tsSaveBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdAddTaxRec.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    taxingGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                    
                    //taxation has begun
                    
                    if (!irpr.SRPRow.IsTaxationBeganNull())
                    {

                        cmdSaveAndNext.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        cmdSaveAndPrevious.Visible = Janus.Windows.UI.InheritableBoolean.True;

                        //not yet taxed
                        if (irpr.IsNull(irpr.Table.Columns["OfficerID"], DataRowVersion.Original) || irpr.IsNull(irpr.Table.Columns["DateTaxed"], DataRowVersion.Original))
                        {
                            SetTaxationModeDefaults(irpr);
                            btnApplyTaxRecs.Visible = taxingGridEX.GetRows().Length > 0;
                            taxingGridEX.RootTable.Columns["Selector"].Visible = btnApplyTaxRecs.Visible;
                            if (btnApplyTaxRecs.Visible)
                                taxingGridEX.CheckAllRecords();

                            //Partial TaxRate Implementation
                            //2017 -08-10 JLL: handling of overide for manual tax calculation

                            //find if office has defaulttaxrate value
                            bool OfficeUsesMultipleTaxRates = !OfficeMngLeadOffice.CurrentOffice.IsTaxRateNull();
                            if (OfficeUsesMultipleTaxRates)
                            {
                                disbursementTaxedTaxNumericEditBox.ReadOnly = false;
                                disbursementTaxedTaxNumericEditBox.BackColor = SystemColors.Window;
                                disbursementTaxedTaxNumericEditBox.HasImage = true;
                            }
                            inOwnerTaxationMode = true;
                        }
                        else
                        {
                            //already taxed

                            string vMessage = "This IRP has been taxed already; the taxed values are not defaults, they are the values set by the Taxing Officer";
                            if (fmBillingReview.GetSRP().isAllIRPsTaxed(irpr.SRPRow))
                                vMessage = "All IRPs have been taxed but taxation is not yet completed on the SRP.";

                            setMessage(true, vMessage, Properties.Resources.warning_16x16);
                            pnlIRP.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
                            dateTaxedBillingReview.ReadOnly = false;
                            dateTaxedBillingReview.BackColor = SystemColors.Window;
                            officerIDucContactSelectBox.ReadOnly = false;
                            officerIDucContactSelectBox.BackColor = SystemColors.Window;
                            btnClearOfficer.Visible = true;
                            btnClearOfficer.Enabled = true;
                            feesTaxedNumericEditBox.ReadOnly = false;
                            feesTaxedNumericEditBox.BackColor = SystemColors.Window;
                            disbursementTaxedNumericEditBox.ReadOnly = false;
                            disbursementTaxedNumericEditBox.BackColor = SystemColors.Window;
                            disbursementTaxExemptTaxedNumericEditBox.ReadOnly = false;
                            disbursementTaxExemptTaxedNumericEditBox.BackColor = SystemColors.Window;
                            
                            //override on taxing allows user to rollback taxation
                            bool canOverride = FM.AtMng.SecurityManager.CanOverride(irpr.FileID, atSecurity.SecurityManager.Features.Taxing) == atSecurity.SecurityManager.ExPermissions.Yes;
                            btnRollbackTaxation.Visible = canOverride;
                            btnRollbackTaxation.Enabled = canOverride;

                        }

                    }
                    else if (irpr.SRPRow.IsTaxationCompletedNull())
                    {
                        btnBeginTaxation.Visible = true;
                        setMessage(true, "This SRP has been submitted.  Taxation has not yet begun.  Once you begin taxation, defaults will be applied on all IRPs", Properties.Resources.warning_16x16);
                    }
                }
                else
                    setMessage(false, LawMate.Properties.Resources.UISRPIsCommitted, Properties.Resources.warning_16x16);
            }
        }

        private void SetTaxationModeDefaults(atriumDB.IRPRow irpr)
        {
            setMessage(true, LawMate.Properties.Resources.UITaxationMode, Properties.Resources.warning_16x16);
            dateTaxedBillingReview.ReadOnly = false;
            dateTaxedBillingReview.BackColor = SystemColors.Window;
            officerIDucContactSelectBox.ReadOnly = false;
            officerIDucContactSelectBox.BackColor = SystemColors.Window;
            btnClearOfficer.Visible = true;
            btnClearOfficer.Enabled = true;
            feesTaxedNumericEditBox.ReadOnly = false;
            feesTaxedNumericEditBox.BackColor = SystemColors.Window;
            disbursementTaxedNumericEditBox.ReadOnly = false;
            disbursementTaxedNumericEditBox.BackColor = SystemColors.Window;
            disbursementTaxExemptTaxedNumericEditBox.ReadOnly = false;
            disbursementTaxExemptTaxedNumericEditBox.BackColor = SystemColors.Window;

            if (!irpr.IsFeesClaimedNull())
                irpr.FeesTaxed = irpr.FeesClaimed;
            //else
            //    irpr.FeesTaxed = 0;
            if (!irpr.IsFeesClaimedTaxNull())
                irpr.FeesTaxedTax = irpr.FeesClaimedTax;
            //else
            //    irpr.FeesTaxedTax = 0;

            if (!irpr.IsDisbursementClaimedNull())
                irpr.DisbursementTaxed = irpr.DisbursementClaimed;
            //else
            //    irpr.DisbursementTaxed = 0;

            if (!irpr.IsDisbursementClaimedTaxNull())
                irpr.DisbursementTaxedTax = irpr.DisbursementClaimedTax;
            //else
            //    irpr.DisbursementTaxedTax = 0;

            if (!irpr.IsDisbursementTaxExemptClaimedNull())
                irpr.DisbursementTaxExemptTaxed = irpr.DisbursementTaxExemptClaimed;
            //else
            //    irpr.DisbursementTaxExemptTaxed = 0;

            irpr.OfficerID = FM.AtMng.WorkingAsOfficer.OfficerId;
            irpr.DateTaxed = DateTime.Today;
            tsSaveBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        }

        public void ApplyActivitySecurity(DataRow dr)
        {
            atriumDB.ActivityRow cbr = (atriumDB.ActivityRow)dr;
            UIHelper.EnableControls(activityBindingSource, FM.GetActivity().CanEdit(cbr));
        }
        
        public void ApplyTaxingSecurity(DataRow dr)
        {
            if (dr != null)
            {
                CLAS.TaxingRow cbr = (CLAS.TaxingRow)dr;
                UIHelper.EnableControls(taxingBindingSource, FM.GetCLASMng().GetTaxing().CanEdit(cbr));
            }
        }

        public override void Cancel()
        {
            UIHelper.Cancel(officeDB_IRPDataTableBindingSource);
            UIHelper.Cancel(activityBindingSource);
            UIHelper.Cancel(activityTimeBindingSource, fmBillingReview.DB.ActivityTime);
            UIHelper.Cancel(disbursementBindingSource, fmBillingReview.DB.Disbursement);
            UIHelper.Cancel(taxingBindingSource, fmBillingReview.GetCLASMng().DB.Taxing);
            ApplyBR(true);
            if (inOwnerTaxationMode)
            {
                setMessage(true, "Cancel selected. Defaults values have been removed.  You will need to manually enter amounts for this IRP, or move off and return to this IRP to reapply defaults.", Properties.Resources.warning_16x16);
                ToggleTaxRecRecords(taxingBindingSource.Count > 0);
                btnApplyTaxRecs.Visible = taxingGridEX.GetRows().Length > 0;
                taxingGridEX.RootTable.Columns["Selector"].Visible = btnApplyTaxRecs.Visible;
                if (btnApplyTaxRecs.Visible)
                    taxingGridEX.CheckAllRecords();
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars["cbMergeToolbar"];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                switch (e.Command.Key)
                {
                    case "cmdAddTaxRec":
                        CLAS.TaxingRow taxingRow = (CLAS.TaxingRow)fmBillingReview.GetCLASMng().GetTaxing().Add(fmBillingReview.CurrentFile);
                        taxingRow.OfficeCode = CurrentRowIRP().OfficeCode;
                        taxingRow.OfficeID = CurrentRowIRP().OfficeID;

                        if (inOwnerTaxationMode) //set defaults
                        {
                            btnApplyTaxRecs.Visible = taxingGridEX.GetRows().Length > 0;
                            taxingGridEX.RootTable.Columns["Selector"].Visible = btnApplyTaxRecs.Visible;
                            if (btnApplyTaxRecs.Visible)
                                taxingGridEX.CheckAllRecords();
                        }

                        ToggleTaxRecRecords(taxingBindingSource.Count > 0);


                        break;
                    case "cmdGoToActivity":
                        FileForm().MainForm.OpenFile(CurrentRowIRP().FileID);
                        break;
                    case "cmdGoToTaxation":
                        fFile f1 = FileForm().MainForm.OpenFile(CurrentRowIRP().FileID);
                        f1.MoreInfo("irp", CurrentRowIRP().IRPId);
                        break;
                    case "cmdGoToTaxingRec":
                        fFile f2 = FileForm().MainForm.OpenFile(CurrentRowIRP().FileID);
                        f2.MoreInfo("taxing", 0);
                        break;
                    case "tsGoToSRP":
                        FileForm().MoreInfo("srp", currentSRPRow.SRPID);
                        break;
                    case "tsGoToSRPDetail":
                        ucBase ctl = FileForm().MoreInfo("srpdetail");
                        ucSRPDetail srpDetailCtl = (ucSRPDetail)ctl;
                        srpDetailCtl.MoreInfo("srpdetail", CurrentRowIRP().SRPID);
                        srpDetailCtl.MoreInfo("srpdetailirp", CurrentRowIRP().IRPId);
                        break;
                    case "tsSaveBillingReview":
                        SaveBillingReview();
                        break;
                    case "cmdSaveAndNext":
                        SaveBillingReview();
                        move(1);
                        break;
                    case "cmdSaveAndPrevious":
                        SaveBillingReview();
                        move(-1);
                        break;
                    case "tsNext":
                        move(1);
                        break;
                    case "tsPrevious":
                        move(-1);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

            finally { Application.UseWaitCursor = false; Cursor = Cursors.Default; }
        }


        /// <summary>
        /// move forward or backwards by one step in irp bindingsource
        /// </summary>
        /// <param name="position">enter 1 to move forward, -1 to move backwards</param>
        private void move(int position)
        {
            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
            userInitiatedNav = true;
            using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
            {
                if (position == 1)
                {
                    if (officeDB_IRPDataTableBindingSource.Position != officeDB_IRPDataTableBindingSource.Count - 1)
                        officeDB_IRPDataTableBindingSource.MoveNext();
                    else
                        officeDB_IRPDataTableBindingSource.MoveFirst();
                }
                else if (position == -1)
                {
                    if (officeDB_IRPDataTableBindingSource.Position != 0)
                        officeDB_IRPDataTableBindingSource.MovePrevious();
                    else
                        officeDB_IRPDataTableBindingSource.MoveLast();
                }
                else
                    throw new Exception("Invalid parameter passed to ucBillingReview/move function; only valid values are 1 or -1");
            }
            userInitiatedNav = false;
            Application.UseWaitCursor = false; Cursor = Cursors.Default;
        }

        //public override void MoreInfo(string linkTable, int linkId)
        //{
        //    officeDB_IRPDataTableBindingSource.Position = officeDB_IRPDataTableBindingSource.Find("IRPID", linkId);
        //}


        private void activityGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                int acId = CurrentRowActivity().ActivityId;

                fFile f = (fFile)this.ParentForm;
                fFile nf = f.MainForm.OpenFile(fmBillingReview.CurrentFileId);

                ucBase ctl = nf.MoreInfo("activity");
                ucActivity acCtl = (ucActivity)ctl;
                    
                if (e.Column.GridEX.Name == activityTimeGridEX.Name)
                    acCtl.MoreInfoTime("activity", acId, CurrentRowActivityTime());
                else if(e.Column.GridEX.Name==disbursementGridEX.Name)
                    acCtl.MoreInfoDisb("activity", acId, CurrentRowDisbursement());
                else
                    acCtl.MoreInfo("activity", acId);

                //will this fix our includeonsrp data for us?
                applyIncludeOnSRPFilter(CurrentRowIRP());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        int lastBoundIRPId = 0;
        private void officeDB_IRPDataTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //this fires twice on save?
            try
            {
                if (userInitiatedNav)
                    LoadBillingReviewData();

                atriumDB.IRPRow dr = CurrentRowIRP();

                if (dr == null)   //.IsNull("IRPId"))
                    return;

                
                if(lastBoundIRPId!=dr.IRPId)
                    ApplySecurityIRP(dr);
                
                lastBoundIRPId = dr.IRPId;
                
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            atriumDB.ActivityRow dr = CurrentRowActivity();
            ApplyActivitySecurity(dr);
        }

        private void taxingBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CLAS.TaxingRow dr = CurrentRowTaxing();
            ApplyTaxingSecurity(dr);
        }

        private void activityGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row != null && e.Row.DataRow != null && e.Row.RowType == Janus.Windows.GridEX.RowType.Record && e.Row.Table == e.Row.GridEX.RootTable)
                {
                    atriumDB.ActivityRow acrow = (atriumDB.ActivityRow)((DataRowView)e.Row.DataRow).Row;
                    float sumAT1 = 0;
                    float sumHours = 0;
                    float sumDis1 = 0;
                    float sumDis2 = 0;

                    e.Row.BeginEdit();

                    if (fmBillingReview.DB.ActivityTime.Compute("Sum(FeesClaimed)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId) != DBNull.Value)
                    {
                        sumAT1 = float.Parse(fmBillingReview.DB.ActivityTime.Compute("Sum(FeesClaimed)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId).ToString());
                        e.Row.Cells["SumFees"].Value = sumAT1;
                    }

                    if (fmBillingReview.DB.ActivityTime.Compute("Sum(Hours)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId) != DBNull.Value)
                    {
                        sumHours = float.Parse(fmBillingReview.DB.ActivityTime.Compute("Sum(Hours)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId).ToString());
                        e.Row.Cells["Hours"].Value = sumHours;
                    }
                    
                    if (fmBillingReview.DB.Disbursement.Compute("Sum(DisbTaxExempt)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId) != DBNull.Value)
                        sumDis1 = float.Parse(fmBillingReview.DB.Disbursement.Compute("Sum(DisbTaxExempt)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId).ToString());
                    if (fmBillingReview.DB.Disbursement.Compute("Sum(DisbTaxable)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId) != DBNull.Value)
                        sumDis2 = float.Parse(fmBillingReview.DB.Disbursement.Compute("Sum(DisbTaxable)", "IncludeOnSRP=True and ActivityId=" + acrow.ActivityId).ToString());

                    if (sumDis1 > 0 || sumDis2 > 0)
                    {
                        float sum = sumDis1 + sumDis2;
                        e.Row.Cells["SumDisbursements"].Value = sum;
                    }

                    e.Row.EndEdit();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try 
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    activityTimeGridEX.Focus();
                    activityTimeGridEX.CurrentColumn = activityTimeGridEX.RootTable.Columns["Hours"];
                    activityTimeGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try 
            {
                if (e.Row.Cells["DefaultHours"].Text.Length > 0)
                {
                    decimal defValue = (decimal)e.Row.Cells["DefaultHours"].Value;
                    if (defValue > 0)
                        e.Row.Cells["default"].Value = Math.Round(defValue,1).ToString();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnBeginTaxation_Click(object sender, EventArgs e)
        {
            try
            {
                SetTaxationModeDefaults(CurrentRowIRP());
                btnBeginTaxation.Visible = false;
                MessageBox.Show(Properties.Resources.UITaxationMode);
                CurrentRowIRP().SRPRow.TaxationBegan = DateTime.Today;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnApplyTaxRecs_Click(object sender, EventArgs e)
        {
            try 
            {
                if (taxingGridEX.GetCheckedRows().Length < 1)
                {
                    MessageBox.Show("No taxing recommendations are selected to link to this IRP.  Please select one or more taxing recommendations in order to link them to the IRP.", "No taxing recommendations are selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
 
                closeTaxRecs();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void closeTaxRecs()
        {
            foreach(Janus.Windows.GridEX.GridEXRow grow in taxingGridEX.GetCheckedRows())
            {
                if (grow != null && grow.DataRow != null)
                {
                    CLAS.TaxingRow taxingRow = (CLAS.TaxingRow)((DataRowView)grow.DataRow).Row;
                    if (!taxingRow.Closed)
                        fmBillingReview.GetCLASMng().GetTaxing().closeTaxRec(taxingRow, CurrentRowIRP());
                }
            }
            checkForUnclosed();
        }

        private void activityTimeGridEX_RecordUpdated(object sender, EventArgs e)
        {
            try
            {
                //forces activityGridEx to recalculate hours/disbursements totals
                activityGridEX.Refetch();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnNewTaxing_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void taxingGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row == null || e.Row.DataRow == null)
                    return;

                CLAS.TaxingRow taxingRow = (CLAS.TaxingRow)((DataRowView)e.Row.DataRow).Row;
                if (!taxingRow.IsIRPIdNull() && taxingRow.IRPId == CurrentRowIRP().IRPId)
                    e.Row.Cells["LinkedToIRP"].Value = true;

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void checkForUnclosed()
        {
            bool hideBtn = true;

            foreach (Janus.Windows.GridEX.GridEXRow grow in taxingGridEX.GetRows())
            {
                if (grow != null && grow.DataRow != null)
                {
                    CLAS.TaxingRow taxingRow = (CLAS.TaxingRow)((DataRowView)grow.DataRow).Row;
                    if (!taxingRow.Closed)
                    {
                        hideBtn = false;
                        break;
                    }
                }
            }
            btnApplyTaxRecs.Visible = !hideBtn;
            taxingGridEX.RootTable.Columns["Selector"].Visible = !hideBtn;
            taxingGridEX.Refresh();
        }

        private void taxingGridEX_RecordUpdated(object sender, EventArgs e)
        {
            try
            {
                checkForUnclosed();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void taxingGridEX_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try 
            {
                if (e.Column.Key == "Closed" && e.Column.GridEX.CurrentRow != null && e.Column.GridEX.CurrentRow.DataRow!=null)
                {
                    CLAS.TaxingRow taxingRow = (CLAS.TaxingRow)((DataRowView)e.Column.GridEX.CurrentRow.DataRow).Row;
                    if (taxingRow.IsIRPIdNull())
                        taxingRow.IRPId = CurrentRowIRP().IRPId;
                }
            
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnClearOfficer_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentRowIRP().SetOfficerIDNull();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnRollbackTaxation_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("This will rollback taxation for this IRP.  Taxing officer, date taxed, fees and disbursements taxed amounts will be reset and any linked taxing recommendations will be unclosed.\n\nAre you sure you want to continue?", "Rollback taxation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    fmBillingReview.GetIRP().RollbackTaxation(CurrentRowIRP());
                    CLAS.TaxingRow[] linkedTaxRecs = (CLAS.TaxingRow[])fmBillingReview.GetCLASMng().DB.Taxing.Select("IRPID=" + CurrentRowIRP().IRPId);

                    foreach (CLAS.TaxingRow taxrec in linkedTaxRecs)
                    {
                        taxrec.Closed = false;
                        taxrec.SetIRPIdNull();
                    }
                    SaveBillingReview();
                    ReloadUserControlData();
                    ApplySecurityIRP(CurrentRowIRP());
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

