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
    public partial class ucSRPDetail : ucBase
    {
        atriumBE.OfficeManager myOfficeMan;
        List<int> loadedSRPs = new List<int>();

        public ucSRPDetail()
        {
            InitializeComponent();
        }


        public void bindIRPData(atriumDB.IRPDataTable a)
        {
            myOfficeMan = FM.AtMng.GetOffice(FM.CurrentFile.LeadOfficeId);
            officeIDucOfficeSelectBox.AtMng = FM.AtMng;
            fileIDucFileSelectBox.AtMng = FM.AtMng;

            UIHelper.ComboBoxInit("vCLASList", mccTaxingOfficer, FM);

            iRPBindingSource.DataSource = a.DataSet;
            iRPBindingSource.DataMember = a.TableName;

            a.ColumnChanged+= new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetIRP().OnUpdate += new atLogic.UpdateEventHandler(ucIRP_OnUpdate);

            btnValidateSIN.Visible = false; // we can show it on Add()

            if (a.Count == 0)
                NoData();

        }

        private void NoData()
        {
            if (!myOfficeMan.CurrentOffice.UsesBilling)
            {
                uiTab1.Enabled = false;
                uiTab2.Enabled = false;
                uiTab3.Enabled = false;
                tsNewIRP.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
 
        }

        void ucIRP_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }
        

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if(FM.IsFieldChanged(e.Column, e.Row))
                    ApplyBR(false);
                  
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


        private void NewIRP()
        {
            //pass srp as parent row?!
            atriumDB.IRPRow irpr = (atriumDB.IRPRow)FM.GetIRP().Add(srpRow);
            iRPBindingSource.Position = iRPBindingSource.Find("IRPId", irpr.IRPId);
            btnValidateSIN.Visible = true;
            btnValidateSIN.Enabled = true;
            ApplySecurityIRP(irpr);
            sINMaskedEditBox.Focus();
        }

        private void SaveIRP()
        {
            if (FM.DB.IRP.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(myOfficeMan.DB);
            }
            else
            {
                try
                {
                    this.iRPBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetSRP());
                    bp.AddForUpdate(FM.GetIRP());
                    bp.Update();
                    FM.GetSRP().LoadByFileId(FM.CurrentFileId);
                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
            }
        }

        private atriumDB.IRPRow CurrentRowIRP()
        {
            if (iRPBindingSource.Current == null)
                return null;
            else
                return (atriumDB.IRPRow)((DataRowView)iRPBindingSource.Current).Row;
        }
      
        private void DeleteIRP()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowIRP().Delete();
                    this.iRPBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetIRP());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();

                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public override void EndEdit()
        {
            iRPBindingSource.EndEdit();
        }

        private void ApplySecurityIRP(DataRow irpRow) //IRP
        {

            atriumDB.IRPRow irpr = (atriumDB.IRPRow)irpRow;

            if (irpr == null)
                return;

            uiTab1.Enabled = true;
            uiTab2.Enabled = true;
            uiTab3.Enabled = true;

            bool OnlineIRP = myOfficeMan.CurrentOffice.UsesBilling;

            UIHelper.EnableCommandBarCommand(tsDeleteIRP, FM.GetIRP().CanDelete(irpr, FM.CurrentFile.FileId));
            UIHelper.EnableCommandBarCommand(tsNewIRP, !OnlineIRP);

            if (myOfficeMan.CurrentOffice.UsesBilling) //SRP detail all readonly; nothing can be done on this page; use billing review
            {
                dateTaxedCalendarCombo.ReadOnly = true;
                dateTaxedCalendarCombo.BackColor = SystemColors.Control;
                mccTaxingOfficer.ReadOnly = true;
                tsSaveIRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else //foreign IRP || Non Online IRP
            {
                if (irpRow.RowState == DataRowState.Added)
                {
                    if(irpRow.IsNull("FileId"))
                        btnValidateSIN.Visible = true;
                    sINMaskedEditBox.ReadOnly = false;
                    sINMaskedEditBox.BackColor = SystemColors.Window;
                }
                else
                {
                    btnValidateSIN.Visible = false;
                    sINMaskedEditBox.ReadOnly = true;
                    sINMaskedEditBox.BackColor = SystemColors.Control;
                }

                if (!irpr.SRPRow.IsTaxationCompletedNull())
                {
                    tsNewIRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    dateTaxedCalendarCombo.ReadOnly = true;
                    dateTaxedCalendarCombo.BackColor = SystemColors.Control;
                    mccTaxingOfficer.ReadOnly = true;
                    tsSaveIRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    feesClaimedNumericEditBox.ReadOnly = true;
                    feesClaimedNumericEditBox.BackColor = SystemColors.Control;
                    disbursementClaimedNumericEditBox.ReadOnly = true;
                    disbursementClaimedNumericEditBox.BackColor = SystemColors.Control;
                    disbursementTaxExemptClaimedNumericEditBox.ReadOnly = true;
                    disbursementTaxExemptClaimedNumericEditBox.BackColor = SystemColors.Control;
                    iRPGridEX.Height = 220;
                    gbMessage.Visible = false;
                }
                else
                {
                    iRPGridEX.Height = 220;
                    gbMessage.Visible = false;

                    if (!irpr.SRPRow.IsTaxationBeganNull())
                    {
                        if (irpr.IsDateTaxedNull() && irpr.IsOfficerIDNull())
                        {
                            iRPGridEX.Height = 167;
                            label10.Text = Properties.Resources.UITaxationMode;
                            gbMessage.Visible = true;

                            //taxation mode
                            //let's default some values
                            
                            if (!irpr.IsFeesClaimedNull())
                                irpr.FeesTaxed = irpr.FeesClaimed;
                            
                            if (!irpr.IsFeesClaimedTaxNull())
                                irpr.FeesTaxedTax = irpr.FeesClaimedTax;

                            if (!irpr.IsDisbursementClaimedNull())
                                irpr.DisbursementTaxed = irpr.DisbursementClaimed;

                            if (!irpr.IsDisbursementClaimedTaxNull())
                                irpr.DisbursementTaxedTax = irpr.DisbursementClaimedTax;

                            if (!irpr.IsDisbursementTaxExemptClaimedNull())
                                irpr.DisbursementTaxExemptTaxed = irpr.DisbursementTaxExemptClaimed;

                            irpr.OfficerID = FM.AtMng.WorkingAsOfficer.OfficerId;
                            irpr.DateTaxed = DateTime.Today;
                        }
                    }
                    
                    tsNewIRP.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    dateTaxedCalendarCombo.ReadOnly = false;
                    dateTaxedCalendarCombo.BackColor = SystemColors.Window;
                    mccTaxingOfficer.ReadOnly = false;
                    tsSaveIRP.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    feesClaimedNumericEditBox.ReadOnly = false;
                    feesClaimedNumericEditBox.BackColor = SystemColors.Window;
                    disbursementClaimedNumericEditBox.ReadOnly = false;
                    disbursementClaimedNumericEditBox.BackColor = SystemColors.Window;
                    disbursementTaxExemptClaimedNumericEditBox.ReadOnly = false;
                    disbursementTaxExemptClaimedNumericEditBox.BackColor = SystemColors.Window;

                    feesTaxedNumericEditBox.ReadOnly = false;
                    feesTaxedNumericEditBox.BackColor = SystemColors.Window;
                    disbursementTaxedNumericEditBox.ReadOnly = false;
                    disbursementTaxedNumericEditBox.BackColor = SystemColors.Window;
                    disbursementTaxedTaxNumericEditBox.ReadOnly = false;
                    disbursementTaxedTaxNumericEditBox.BackColor = SystemColors.Window;
                    disbursementTaxExemptTaxedNumericEditBox.ReadOnly = false;
                    disbursementTaxExemptTaxedNumericEditBox.BackColor = SystemColors.Window;
                }
            }
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
            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }

        public override void Cancel()
        {
            UIHelper.Cancel(iRPBindingSource);
            ApplyBR(true);
            if (FM.DB.IRP.Count == 0)
                NoData();
            iRPGridEX.Height = 220;
            gbMessage.Visible = false;
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
                    case "tsSaveIRP":
                        SaveIRP();
                        break;
                    case "tsDeleteIRP":
                        DeleteIRP();
                        break;
                    case "tsNewIRP":
                        NewIRP();
                        break;
                    case "tsGoToBillingReview":
                        if (myOfficeMan.CurrentOffice.UsesBilling)
                        {
                            ucBase ctl = FileForm().MoreInfo("billingreview");
                            ucSRPBillingReview brCtl = (ucSRPBillingReview)ctl;
                            brCtl.MoreInfo("billingreview", CurrentRowIRP().SRPID, CurrentRowIRP().IRPId);
                        }
                        break;
                    case "tsGoToSRP":
                        FileForm().MoreInfo("srp", CurrentRowIRP().SRPID);
                        break;
                    case "cmdJumpToActivity":
                        fFile nFile = FileForm().MainForm.OpenFile(CurrentRowIRP().FileID);
                        nFile.MoreInfo("activity");
                        break;
                    case "cmdJumpToTaxation":
                        fFile nFile1 = FileForm().MainForm.OpenFile(CurrentRowIRP().FileID);
                        nFile1.MoreInfo("irp", CurrentRowIRP().IRPId);
                        break;
                }
                if (e.Command.Key.StartsWith("cmdTaxRec"))
                {
                    CLAS.TaxingRow tr = (CLAS.TaxingRow)e.Command.Tag;
                    fFile nFile = FileForm().MainForm.OpenFile(tr.FileID);
                    nFile.MoreInfo("taxing", tr.TaxingID);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void ReloadUserControlData()
        {
            loadedSRPs.Clear();
            FM.GetSRP().LoadByFileId(FM.CurrentFileId);


            FM.GetIRP().LoadBySRPId(srpId);
        //    FM.GetCLASMng().GetTaxing().LoadBySRPID(srpId);
            loadedSRPs.Add(srpId);
            iRPGridEX.MoveFirst();
        }
        private void toggleLoad(bool hide)
        {
            //label26.Visible = !hide;
            gbMessage.Visible = !hide;
            //calendarCombo1.Visible = !hide;
            officeIDLabel.Visible = !hide;
            officeIDucOfficeSelectBox.Visible = !hide;
            uiTab1.Visible = !hide;
            uiTab2.Visible = !hide;
            uiTab3.Visible = !hide;
            label9.Visible = hide;
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        atriumDB.SRPRow srpRow;
        int srpId;
        public override void MoreInfo(string linkTable, int linkId)
        {
            
            if (linkTable.ToUpper() == "SRPDETAIL")
            {
                srpId = linkId;
                if (!loadedSRPs.Contains(linkId))
                {
                    iRPBindingSource.SuspendBinding();
                    toggleLoad(true);
                    iRPGridEX.DataSource = null;
                    iRPGridEX.Refetch();
                    Application.DoEvents();
                    FM.GetIRP().LoadBySRPId(linkId);
                //    FM.GetCLASMng().GetTaxing().LoadBySRPID(linkId);
                    loadedSRPs.Add(linkId);
                    FM.GetSRP().Load(linkId);
                    toggleLoad(false);
                    iRPBindingSource.ResumeBinding();
                    iRPGridEX.DataSource = iRPBindingSource;
                }

                srpRow = ((atriumDB.SRPRow[])FM.DB.SRP.Select("SRPID=" + linkId))[0];
                iRPBindingSource.Filter = "SRPID=" + linkId;

                if (iRPBindingSource.Count == 0 && FM.GetIRP().CanAdd(srpRow, FM.CurrentFile.FileId))
                    NewIRP();
            }
            else if (linkTable.ToUpper() == "SRPDETAILIRP")
            {
                iRPBindingSource.Position = iRPBindingSource.Find("IRPID", linkId);
            }
        }

        private void TaxRecDropDown(int irpId)
        {
            uiContextMenu2.Commands.Clear();

            if (!CurrentRowIRP().IsFileIDNull())
            {
                //CLAS.TaxingRow[] trs = (CLAS.TaxingRow[])FM.GetCLASMng().DB.Taxing.Select("IRPId=" + irpId, "TaxingDate");
                CLAS.TaxingRow[] trs = (CLAS.TaxingRow[])FM.GetCLASMng().DB.Taxing.Select("fileid=" + CurrentRowIRP().FileID.ToString(), "TaxingDate");
                foreach (CLAS.TaxingRow tr in trs)
                {
                    uiButton2.Enabled = true;
                    Janus.Windows.UI.CommandBars.UICommand newCmd;
                    string key = "cmdTaxRec" + tr.TaxingID;
                    if (uiContextMenu2.CommandManager.Commands.Contains(key))
                        newCmd = uiContextMenu2.CommandManager.Commands[key];
                    else
                    {
                        newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                        newCmd.Key = key;
                    }

                    string cmdText = "Date: " + tr.TaxingDate.ToString("yyyy/MM/dd");

                    if (!tr.IsTaxDownDisbNull() && tr.TaxDownDisb > 0)
                        cmdText += "; Amount: " + tr.TaxDownDisb.ToString("C");

                    if (!tr.IsTaxDownHoursNull() && tr.TaxDownHours > 0)
                        cmdText += "; Fees (Time): " + tr.TaxDownHours.ToString();

                    newCmd.Text = cmdText;
                    newCmd.Tag = tr;
                    newCmd.ShowInCustomizeDialog = false;
                    uiContextMenu2.Commands.Add(newCmd);
                }
            }

            if (uiContextMenu2.Commands.Count == 0)
                uiButton2.Enabled = false;
 
        }

        private void iRPBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                atriumDB.IRPRow dr = CurrentRowIRP();

                if (dr == null || dr.IsNull("IRPId"))
                {
                    NoData();
                    return;
                }

                TaxRecDropDown(dr.IRPId);
                ApplySecurityIRP(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnValidateSIN_Click(object sender, EventArgs e)
        {
            try
            {
                
                string typedSIN = sINMaskedEditBox.Text.Replace(" ", "");

                if (typedSIN.Length != 9)
                {
                    MessageBox.Show("SIN must be 9 digits. You must provide an exact match for SIN");
                    sINMaskedEditBox.Focus();
                    return;
                }

                lmDatasets.appDB.EFileSearchDataTable efsdt = FM.AtMng.FileSearchBySIN(typedSIN);
                if(efsdt.Count>0)
                {
                    lmDatasets.appDB.EFileSearchRow efr = efsdt[0];
                    CurrentRowIRP().FileID = efr.FileId;
                    CurrentRowIRP().EndEdit();
                    btnValidateSIN.Visible = false;
                }
                
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void iRPGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    if (myOfficeMan.CurrentOffice.UsesBilling)
                    {
                        ucBase ctl = FileForm().MoreInfo("billingreview");
                        ucSRPBillingReview brCtl = (ucSRPBillingReview)ctl;
                        brCtl.MoreInfo("billingreview", CurrentRowIRP().SRPID, CurrentRowIRP().IRPId);
                    }
                }
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
                if (iRPGridEX.HitTest() != Janus.Windows.GridEX.GridArea.Cell)
                    uiContextMenu3.Close();

                if (myOfficeMan.CurrentOffice.UsesBilling)
                    tsGoToBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    tsGoToBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void iRPGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
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


        private void btnBeginTaxation_Click(object sender, EventArgs e)
        {
            try
            {
                SaveIRP();
                iRPGridEX.MoveNext();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }

        private void ucSRPDetail_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurityIRP(CurrentRowIRP());   
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

