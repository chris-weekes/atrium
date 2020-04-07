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
    public partial class ucSRP : ucBase
    {
        atriumBE.OfficeManager myOfficeMan;

        public ucSRP()
        {
            InitializeComponent();
        }

        public void bindSRPData(atriumDB.SRPDataTable a)
        {
            label2.Visible = false;
            myOfficeMan = FM.AtMng.GetOffice(FM.CurrentFile.LeadOfficeId);
            officeIDucOfficeSelectBox.AtMng = FM.AtMng;

            sRPBindingSource.DataSource = a.DataSet;
            sRPBindingSource.DataMember = a.TableName;

            a.ColumnChanged+= new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetSRP().OnUpdate += new atLogic.UpdateEventHandler(ucSRP_OnUpdate);

            //ApplySecurity(CurrentRow());

            if (!myOfficeMan.CurrentOffice.UploadsDisb)
                tsImport.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            if (!myOfficeMan.CurrentOffice.UsesBilling)
            {
                tsSubmitSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsGenSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            if (FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                cmdRollbackSRP.Visible = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmdRollbackSRP.Visible = Janus.Windows.UI.InheritableBoolean.False;

            if (a.Count == 0) // no SRPs
                NoData();

            FileTreeView.BuildMenu(FM, tsActions, "SRP");


        }

        public override bool controlHasBorder()
        {
            return false;
        }

        private void toggleLoad(bool hide)
        {
            label1.Visible = !hide;
            officeIDucOfficeSelectBox.Visible = !hide;
            uiTab3.Visible = !hide;
            uiTab1.Visible = !hide;
            uiTab2.Visible = !hide;
            label2.Visible = hide;
        }

        private void NoData()
        {
            cmdNew.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            tsSubmitSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            tsGenSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            cmdSave.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        void ucSRP_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.SRPInfo;
        }

        public override void ReloadUserControlData()
        {
            sRPBindingSource.SuspendBinding();
            toggleLoad(true);
            sRPGridEX.DataSource = null;
            sRPGridEX.Refetch();
            Application.DoEvents();
            FM.GetSRP().PreRefresh();
            FM.GetSRP().LoadByFileId(FM.CurrentFile.FileId);
            toggleLoad(false);
            sRPBindingSource.ResumeBinding();
            sRPGridEX.DataSource = sRPBindingSource;
            sRPGridEX.MoveFirst();
        }


        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(sRPBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar2.Enabled = !makeReadOnly;
            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }


        public override void Save()  //SRP
        {
            if (FM.DB.SRP.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(myOfficeMan.DB);
            }
            else
            {
                try
                {
                    this.sRPBindingSource.EndEdit();

                    //atLogic.BusinessProcess bp = FM.GetBP();
                    //bp.AddForUpdate(FM.GetSRP());
                    //bp.Update();
                    FM.SaveAll();
                }
                catch (Exception x)
                {

                    UIHelper.HandleUIException(x);
                }
            }
        }


        private atriumDB.SRPRow CurrentRow()
        {
            if (sRPBindingSource.Current == null)
                return null;
            else
                return (atriumDB.SRPRow)((DataRowView)sRPBindingSource.Current).Row;
        }

        public override void Delete()  //SRP
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    this.sRPBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetSRP());
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
            sRPBindingSource.EndEdit();
        }
        public override void ApplyBR(bool DataNotDirty) //SRP
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

            
            //if (DataNotDirty)
            //    tsEditmode.Visible = Janus.Windows.UI.InheritableBoolean.False;                
            //else
            //    tsEditmode.Visible = Janus.Windows.UI.InheritableBoolean.True;

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }

        public override void ApplySecurity(DataRow srpRow) //SRP
        {
            if (srpRow == null)
                return;

            atriumDB.SRPRow srpr = (atriumDB.SRPRow)srpRow;

            UIHelper.EnableCommandBarCommand(cmdNew, FM.GetSRP().CanAdd(FM.CurrentFile.FileId));
            UIHelper.EnableCommandBarCommand(cmdDelete, false);
            cmdRollbackSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            //Online agent
            if (myOfficeMan.CurrentOffice.UsesBilling)
            {
                
                if (srpr.IsCountOfTaxationNull() || srpr.CountOfTaxation == 0)
                {
                    tsGoToSRPDetail.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsGoToBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    tsGoToSRPDetail.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    tsGoToBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }

                tsExportDisb.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsExportFees.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                sRPDateCalendarCombo.ReadOnly = true;
                sRPDateCalendarCombo.BackColor = SystemColors.Control;
                sRPSubmittedDateCalendarCombo.ReadOnly = true;
                sRPSubmittedDateCalendarCombo.BackColor = SystemColors.Control;
                sRPReceivedDateCalendarCombo.ReadOnly = true;
                sRPReceivedDateCalendarCombo.BackColor = SystemColors.Control;
                taxationBeganCalendarCombo.ReadOnly = true;
                taxationBeganCalendarCombo.BackColor = SystemColors.Control;
                cmdSave.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                //Taxation is completed
                if (!srpr.IsTaxationCompletedNull())
                {
                    sRPDateCalendarCombo.BackColor = SystemColors.Control;
                    taxationCompletedCalendarCombo.ReadOnly = true;
                    taxationCompletedCalendarCombo.BackColor = SystemColors.Control;
                    tsGenSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsSubmitSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsImport.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    //SRP is submitted
                    if (!srpr.IsSRPSubmittedDateNull())
                    {
                        tsImport.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        tsExportDisb.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                        tsGenSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        tsSubmitSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                        if (srpr.IsTaxationCompletedNull() && FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                            cmdRollbackSRP.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                        //who is looking at the data?

                        //CLAS
                        if ( (FM.AtMng.WorkingAsOfficer.OfficeId == FM.CurrentFile.OwnerOfficeId || FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes))
                        {
                            sRPReceivedDateCalendarCombo.ReadOnly = false;
                            sRPReceivedDateCalendarCombo.BackColor = SystemColors.Window;
                            if (!srpr.IsTaxationBeganNull())
                            {
                                taxationCompletedCalendarCombo.ReadOnly = false;
                                taxationCompletedCalendarCombo.BackColor = SystemColors.Window;
                            }
                            cmdSave.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        }
                        else
                        {
                            taxationCompletedCalendarCombo.ReadOnly = true;
                            taxationCompletedCalendarCombo.BackColor = SystemColors.Control;
                            sRPReceivedDateCalendarCombo.ReadOnly = true;
                            sRPReceivedDateCalendarCombo.BackColor = SystemColors.Control;
                        }
                    }
                    else
                    {
                        //SRP is not committed

                        tsImport.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        tsExportDisb.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                        sRPReceivedDateCalendarCombo.ReadOnly = true;
                        sRPReceivedDateCalendarCombo.BackColor = SystemColors.Control;
                        taxationCompletedCalendarCombo.ReadOnly = true;
                        taxationCompletedCalendarCombo.BackColor = SystemColors.Control;
                        if (FM.AtMng.WorkingAsOfficer.OfficeId == FM.CurrentFile.LeadOfficeId || FM.AtMng.WorkingAsOfficer.OfficeId == FM.CurrentFile.OwnerOfficeId)
                            tsGenSRP.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        else
                            tsGenSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        //Can't commit yet
                        if (srpr.SRPDate < DateTime.Today && FM.AtMng.WorkingAsOfficer.OfficeId == FM.CurrentFile.LeadOfficeId)
                            tsSubmitSRP.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        else
                            tsSubmitSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    }
                }
            }
            
            //Non-online agent (ad-hoc or foreign)
            else 
            {
                sRPSubmittedDateLabel.Visible = false;
                sRPSubmittedDateCalendarCombo.Visible = false;
                tsGoToBillingReview.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsExportDisb.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsExportFees.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsExternalData.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsGenSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsSubmitSRP.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                UIHelper.EnableCommandBarCommand(cmdDelete, srpr.RowState != DataRowState.Added);
                UIHelper.EnableCommandBarCommand(cmdNew, srpr.RowState != DataRowState.Added);
                UIHelper.EnableCommandBarCommand(tsGoToSRPDetail, srpr.RowState != DataRowState.Added);
                cmdSave.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                sRPDateCalendarCombo.ReadOnly = false;
                sRPDateCalendarCombo.BackColor = SystemColors.Window;
                sRPReceivedDateCalendarCombo.ReadOnly = false;
                sRPReceivedDateCalendarCombo.BackColor = SystemColors.Window;
                taxationBeganCalendarCombo.ReadOnly = false;
                taxationBeganCalendarCombo.BackColor = SystemColors.Window;
                taxationCompletedCalendarCombo.ReadOnly = false;
                taxationCompletedCalendarCombo.BackColor = SystemColors.Window;

                if (FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No)
                {
                    sRPReceivedDateCalendarCombo.ReadOnly = true;
                    sRPReceivedDateCalendarCombo.BackColor = SystemColors.Control;
                    sRPDateCalendarCombo.ReadOnly = true;
                    sRPDateCalendarCombo.BackColor = SystemColors.Control;
                    taxationBeganCalendarCombo.ReadOnly = true;
                    taxationBeganCalendarCombo.BackColor = SystemColors.Control;
                    taxationCompletedCalendarCombo.ReadOnly = true;
                    taxationCompletedCalendarCombo.BackColor = SystemColors.Control;
                    cmdNew.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
            }
        }

        public override void Cancel()
        {
            UIHelper.Cancel(sRPBindingSource);
            ApplyBR(true);
        }

        private int UploadFile()
        {
            try
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string f = this.openFileDialog1.FileName;

                    docDB.DocumentRow newDoc = (docDB.DocumentRow)FM.GetDocMng().GetDocument().Add(FM.CurrentFile, f);

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetDocMng().GetDocContent());
                    bp.AddForUpdate(FM.GetDocMng().GetDocument());

                    bp.Update();

                    return newDoc.DocId;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception x)
            {
                
                throw x;
            }

        }

        void Export(string type)
        {
            try
            {
                saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog1.FileName =FM.CurrentFile.LeadOfficeCode + "_" + CurrentRow().SRPDate.ToString("yyyyMMdd")+"_"+type + ".csv";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   
                    FM.GetSRP().Export(type, CurrentRow().SRPID, saveFileDialog1.FileName);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
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
                    case "tsImportBulk":
                        int docId=UploadFile();
                        if(docId!=0)
                            FM.AtMng.GetBatch().SubmitJob("ImportDisb", CurrentRow().FileID.ToString() + "," + CurrentRow().SRPID.ToString() + "," + docId.ToString() + ",Bulk");
                        break;
                    case "tsImportAll":
                        int docId1 = UploadFile();
                        if (docId1 != 0)
                            FM.AtMng.GetBatch().SubmitJob("ImportDisb", CurrentRow().FileID.ToString() + "," + CurrentRow().SRPID.ToString() + "," + docId1.ToString() + ",All");
                        break;
                    case "tsExportFees":
                        Export("Fees");
                        break;
                    case "tsExportDisb":
                        Export("Disb");
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                    case "cmdNew":
                        atriumDB.SRPRow newSrp = (atriumDB.SRPRow)FM.GetSRP().Add(FM.CurrentFile);
                        sRPBindingSource.Position = sRPBindingSource.Find("SRPID", newSrp.SRPID);
                        ApplySecurity(newSrp);
                        break;
                    case "tsGenSRP":
                        //TODO why is this load office manager here?!
                        if (MessageBox.Show("You are about to generate your SRP. This operation might take a few seconds.\n\nAre you sure you want to perform this operation?", "Generate SRP", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Application.UseWaitCursor = true;
                            Application.DoEvents();
                            FM.GetSRP().LoadOfficeManager(CurrentRow().SRPID);
                            FM.GetSRP().GenSrp(CurrentRow().SRPID);
                            FileForm().ReloadFileData();
                            Application.UseWaitCursor = false;
                            MessageBox.Show("Your SRP was successfully generated.");
                        }
                        //MessageBox.Show(LawMate.Properties.Resources.UIGenerateSRP, LawMate.Properties.Resources.UIGenerateSRPCaption);
                        break;
                    case "tsSubmitSRP":
                        if (MessageBox.Show("-------------------------\n------SUBMIT SRP------\n-------------------------\n\nYou are about to submit your SRP. This operation might take a few seconds.\n\nAre you sure you want to submit your SRP?", "Submit SRP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Application.UseWaitCursor = true;
                            Application.DoEvents();
                            FM.GetSRP().LoadOfficeManager(CurrentRow().SRPID);
                            FM.GetSRP().GenSrp(CurrentRow().SRPID);
                            FM.GetSRP().SubmitSrp(CurrentRow().SRPID);
                            FileForm().ReloadFileData();
                            MessageBox.Show("Your SRP was successfully submitted.");
                            Application.UseWaitCursor = false;
                        }
                        break;
                    case "cmdRollbackSRP":
                        if (MessageBox.Show("This will undo the submitting of this SRP.\n\nAre you sure you want to perform this operation?", "Undo Submit of SRP", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Application.UseWaitCursor = true;
                            Application.DoEvents();
                            FM.GetSRP().RollbackSRP(CurrentRow());
                            FileForm().ReloadFileData();
                            MessageBox.Show("The selected SRP was successfully rolled back.");
                            Application.UseWaitCursor = false;
                        }
                        
                        MessageBox.Show("The selected SRP was rolled back.");
                        break;
                    case "tsGoToSRPDetail":
                        FileForm().MoreInfo("srpdetail", CurrentRow().SRPID);
                        break;
                    case "tsGoToBillingReview":
                        FileForm().MoreInfo("billingreview", CurrentRow().SRPID);
                        break;
                }
                FileForm().HandleACSMenu(e, CurrentRow());

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        public override void MoreInfo(string linkTable, int linkId)
        {
            sRPBindingSource.Position = sRPBindingSource.Find("SRPID", linkId);
        }

        private void sRPBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                atriumDB.SRPRow dr = CurrentRow();

                if (dr == null || dr.IsNull("SRPID"))
                {
                    NoData();
                    return;
                }

                ApplySecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void sRPGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try 
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    if (tsGoToSRPDetail.Enabled == Janus.Windows.UI.InheritableBoolean.True)
                        FileForm().MoreInfo("srpdetail", CurrentRow().SRPID);
                    else
                        MessageBox.Show("Cannot View SRP Detail for selected SRP");
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            try
            {
                if (sRPGridEX.HitTest() != Janus.Windows.GridEX.GridArea.Cell)
                    uiContextMenu1.Close();


                if (myOfficeMan.CurrentOffice.UsesBilling)
                    tsGoToBillingReview.Visible = Janus.Windows.UI.InheritableBoolean.True;
                else
                    tsGoToBillingReview.Visible = Janus.Windows.UI.InheritableBoolean.False;
                
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucSRP_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

