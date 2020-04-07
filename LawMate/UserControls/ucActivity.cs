using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;
using System.IO;

 namespace LawMate
{
    public partial class ucActivity : ucBase
    {
        ActivityBP abp;
        List<int> MoveList = new List<int>();
        public string Instance;
        //string okOFF = "";

        public ucActivity()
        {
            InitializeComponent();
            Instance = DateTime.Now.Ticks.ToString();
            ucDocView1.ReturnFocusTo = activityGridEX;
        }

        Stream gridLayoutStreamList = new  MemoryStream();
        //Stream gridLayoutStreamThread = new MemoryStream();
        //Stream gridLayoutStreamThreadReverse = new MemoryStream();
        //Stream gridLayoutStreamBF = new MemoryStream();
        //Stream gridLayoutStreamTK = new MemoryStream();
        //Stream gridLayoutStreamProcessGroup = new MemoryStream();
        const string LayoutVersionNumberActivity = "4_1_38";
        const string LayoutVersionNumberBF = "4_1_38";
        const string LayoutVersionNumberTK = "4_1_38";
        const string LayoutVersionNumberDisb = "4_1_38";

        public void ucActLoad()
        {
            try
            {
                //2017-08-11 JLL IUTIR - 9113:  new IsBillable flag
                if (!FM.AtMng.WorkingAsOfficer.UsesBilling || !FM.CurrentFile.FileMetaTypeRow.isBillable)
                {
                    tabTK.TabVisible = false;
                    tabDisb.TabVisible = false;
                }
                
                activityGridEX.SaveLayoutFile(gridLayoutStreamList);
                lmWinHelper.LoadGridLayout(activityGridEX, "ucActivityGridExList", LayoutVersionNumberActivity);
                lmWinHelper.LoadGridLayout(activityBFGridEX, "ucActivityBFGridEx", LayoutVersionNumberBF);
                lmWinHelper.LoadGridLayout(activityTimeGridEX, "ucActivityTimeGridEx", LayoutVersionNumberTK);
                lmWinHelper.LoadGridLayout(disbursementGridEX, "ucActivityDisbGridEx", LayoutVersionNumberDisb);
                GridChange("List", "ucActivityGridExList", "tsViewList");
                HookUpGridExDropDowns();

                editBox1.DataBindings.Add("Text", activityBFBindingSource, UIHelper.Translate(FM, "BFDescriptionEng"));

                BindActivityData(FM.DB.Activity);

                CheckPrefs();
                activityGridEX.Refetch();
                activityGridEX.Focus();
                activityGridEX.MoveFirst();
                activityBFGridEX.Refresh();
                activityTimeGridEX.Refresh();
                disbursementGridEX.Refresh();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void CheckPrefs()
        {
            cmdExpandGrid.IsChecked = FM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.cmdUcActivityExpandGrid, false);
            ExpandDataGrid(cmdExpandGrid.IsChecked);
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        private void HookUpGridExDropDowns()
        {
            ucContactSelectBox1.FM = FM;
            ucContactSelectBox2.FM = FM;
            ucTimeslipOfficerId.FM = FM;
            ucBFOfficerId.FM = FM;
            ucTimeslipOfficeId.AtMng = FM.AtMng;

            priorityJComboBox.ImageList = UIHelper.browseImgList();
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityNormal, 0, 36));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityHigh, 1, 34));
            priorityJComboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(LawMate.Properties.Resources.PriorityUrgent, 2, 35));

            Janus.Windows.GridEX.GridEXColumn gec = activityGridEX.RootTable.Columns["SendType"];
            if(gec!=null)
            {
                gec.HasValueList = true;
                gec.ValueList.Clear();
                gec.ValueList.Add("A", "", Properties.Resources.atriumtrans16);
                gec.ValueList.Add("O", "", Properties.Resources.outlook2016);
                gec.ValueList.Add("B", "", Properties.Resources.email2);
            }
            UIHelper.ComboBoxInit(FM.AtMng.acMng.DB.ACBF, activityBFGridEX.DropDowns["ddBFDesc"], FM);
            
            UIHelper.ComboBoxInit("DisbursementType", disbursementGridEX.DropDowns["ddDescEng"], FM);
            UIHelper.ComboBoxInit("DisbursementType", disbTypeucMultiDropDown, FM);
            
            UIHelper.ComboBoxInit("vofficerlist", activityGridEX.DropDowns["ddOfficer"], FM);
            UIHelper.ComboBoxInit("vofficerlist", activityBFGridEX.DropDowns["ddOfficer"], FM);
            UIHelper.ComboBoxInit("vofficelist", activityBFGridEX.DropDowns["ddOfficeList"], FM);
            UIHelper.ComboBoxInit("vRoleucontacttype", activityBFGridEX.DropDowns["ddRoleCode"], FM);
            UIHelper.ComboBoxInit("vofficerlist", activityTimeGridEX.DropDowns["ddOfficer"], FM);
            UIHelper.ComboBoxInit("vofficelist", activityTimeGridEX.DropDowns["ddOffice"], FM);
            UIHelper.ComboBoxInit("vofficelist", activityGridEX.DropDowns["ddOffice"], FM);
            UIHelper.ComboBoxInit("TaxRate", mccTaxRateId, FM);
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.DisplayNameActivity;
        }
        public atriumDB.ActivityRow CurrentRow()
        {
            if (activityBindingSource.Current == null)
                return null;
            else
                return (atriumDB.ActivityRow)((DataRowView)activityBindingSource.Current).Row;
        }
        public atriumDB.ActivityBFRow CurrentRowActivityBF()
        {
            if (activityBFBindingSource.Current == null)
                return null;
            else
                return (atriumDB.ActivityBFRow)((DataRowView)activityBFBindingSource.Current).Row;
        }
        public atriumDB.ActivityTimeRow CurrentRowActivityTime()
        {
            if (activityTimeBindingSource.Current == null)
                return null;
            else
                return (atriumDB.ActivityTimeRow)((DataRowView)activityTimeBindingSource.Current).Row;
        }
        public atriumDB.DisbursementRow CurrentRowDisbursement()
        {
            if (disbursementBindingSource.Current == null)
                return null;
            else
                return (atriumDB.DisbursementRow)((DataRowView)disbursementBindingSource.Current).Row;
        }

        public void BindActivityData(lmDatasets.atriumDB.ActivityDataTable a)
        {
            //ucDoc1.OpenDocDialog = ((fMain)Application.OpenForms["fMain"]).OpenDocDialog;
            //ucDocView1.OpenDocDialog = ((fMain)Application.OpenForms["fMain"]).OpenDocDialog;

            //activityBFGridEX.DropDowns["ddBFDesc"].SetDataBinding(FM.AtMng.acMng.DB, "ACBF");
            //UIHelper.ComboBoxInit(FM.AtMng.acMng.DB.ACBF, activityBFGridEX.DropDowns["ddBFDesc"], FM);
            //disbursementGridEX.DropDowns["ddDescEng"].SetDataBinding(FM.Codes("DisbursementType"), "");

            //UIHelper.ComboBoxInit("vofficerlist", activityGridEX.DropDowns["ddOfficer"], FM);
            //UIHelper.ComboBoxInit("vofficerlist", activityBFGridEX.DropDowns["ddOfficer"], FM);
            //UIHelper.ComboBoxInit("vofficelist", activityBFGridEX.DropDowns["ddOfficeList"], FM);
            //UIHelper.ComboBoxInit("RoleCode", activityBFGridEX.DropDowns["ddRoleCode"], FM);
            //UIHelper.ComboBoxInit("vofficerlist", activityTimeGridEX.DropDowns["ddOfficer"], FM);

            // all data gets loaded in init; below
            abp = FM.InitActivityProcess();

            //ucDoc1.Init(FM.GetDocMng());
            ucDocView1.Init(FM.GetDocMng());

            //now loaded in docmanager constructor
            //FM.GetDocMng().GetDocument().LoadByFileId(FM.CurrentFile.FileId);


            DataView dv = new DataView(a, "", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);
            activityBindingSource.DataSource = dv;
            activityBindingSource.DataMember = "";




            DataView dvMoveList = new DataView(a, "", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);
            bindingSourceMoveList.DataSource = dvMoveList;
            bindingSourceMoveList.DataMember = "";
            BuildGridFilter(grdMoveActivity, MoveList);
            pnlMoveFloat.Closed = true;


            //hide other people's mail bfs
            //activityBFBindingSource.Filter = "not (isMail=1 and BFOfficerid<>" + FM.AtMng.WorkingAsOfficer.OfficerId.ToString() + ")";

            //hide other timekeeping entries
            
            //CLAS rules are:
            // -Owner: can read all; can edit their own office's, if still in "edit" window, e.g. period not closed, your own? whatever... right?
            // -Non-owner: can read their own office's, and edit their own office's, if still in "edit" window, e.g. period not closed, whatever... right?
            
            
            if (FM.AtMng.SecurityManager.CanOverride(FM.CurrentFile.FileId, atSecurity.SecurityManager.Features.ActivityTime) == atSecurity.SecurityManager.ExPermissions.No)
            {
                //check owner first, handle rest in "else"
                if (FM.CurrentFile.OwnerOfficeId == FM.AtMng.WorkingAsOfficer.OfficeId)
                {
                    //no filter
                }
                else
                {
                    activityTimeBindingSource.Filter = "officeid=" + FM.AtMng.WorkingAsOfficer.OfficeId.ToString();
                }

                //if (FM.AtMng.SecurityManager.CanRead(FM.CurrentFile.FileId, atSecurity.SecurityManager.Features.ActivityTime) == atSecurity.SecurityManager.LevelPermissions.MyOffice)
                //okOFF = FM.AtMng.OfficerLoggedOn.OfficerId.ToString();

                //OfficeManager myOfficeMng = FM.AtMng.GetOffice(FM.AtMng.OfficeLoggedOn.OfficeId);


                //foreach (lmDatasets.officeDB.OfficerDelegateRow odr in myOfficeMng.GetOfficerDelegate().DelegatesForOfficer(FM.AtMng.OfficerLoggedOn.OfficerId))
                //{
                //    okOFF += "," + odr.OfficerId.ToString();
                //}

                //activityTimeBindingSource.Filter = "officerid in (" + okOFF + ")";
            }


            //check activity add perm



            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.DB.ActivityBF.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.DB.ActivityTime.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.DB.Disbursement.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetDocMng().DB.Document.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetDocMng().DB.DocContent.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetDocMng().DB.Recipient.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);

            FM.GetActivity().OnUpdate += new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
            FM.GetActivityBF().OnUpdate += new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
            FM.GetActivityTime().OnUpdate += new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
            FM.GetDisbursement().OnUpdate += new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
            FM.GetDocMng().GetDocument().OnUpdate += new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
            FM.GetDocMng().GetDocContent().OnUpdate += new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
            FM.GetDocMng().GetRecipient().OnUpdate += new atLogic.UpdateEventHandler(ucActivity_OnUpdate);

            //activityGridEX.MoveFirst();
            NoData(activityBindingSource.Count == 0);
            if (CurrentRow() != null)
                DisplayDoc(CurrentRow());

        }

        private void NoData(bool hasNoData)
        {
            Janus.Windows.UI.InheritableBoolean jBool = Janus.Windows.UI.InheritableBoolean.True;
            if (hasNoData)
            {
                jBool = Janus.Windows.UI.InheritableBoolean.False;
                ucDocView1.NoAssociatedDocument("");
            }
            tsSave.Enabled = jBool;
            tsDelete.Enabled = jBool;
            cmdEditFields.Enabled = jBool;
            tsAudit.Enabled = jBool;
            tabBF.Enabled = !hasNoData;
            tabTK.Enabled = !hasNoData;
            tabDisb.Enabled = !hasNoData;
            tabActivity.Enabled = !hasNoData;
            tabDocument.Enabled = !hasNoData;
        }

        void ucActivity_OnUpdate(object sender, atLogic.UpdateEventArgs e)
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
                    case "receivedlocal":
                    case "sentlocal":
                    case "icon":
                    case "failedtosend":
                    case "includeonsrp":
                    //case "bfofficerid":
                    //case "completedbyid":
                    //case "officerid":
                        break;
                    case "to":
                    case "from":
                    case "efsubject":
                    case "hasattachment":
                        //if  syncing ignore
                        if (!FM.GetDocMng().GetRecipient().IsSyncing)
                            ApplyBR(false);
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

        public override void EndEdit()
        {
            activityBindingSource.EndEdit();
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(activityBindingSource, !makeReadOnly);
            UIHelper.EnableControls(activityBFBindingSource, !makeReadOnly);
            UIHelper.EnableControls(activityTimeBindingSource, !makeReadOnly);
            UIHelper.EnableControls(disbursementBindingSource, !makeReadOnly);
            
            btnNewDisb.Enabled = !makeReadOnly;
            btnNewBF.Enabled = !makeReadOnly;
            btnNewTimeslip.Enabled = !makeReadOnly;

            uiCommandBar1.Enabled = !makeReadOnly;
            ucDocView1.ReadOnly(makeReadOnly);

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
                ApplyBFSecurity(CurrentRowActivityBF());
                ApplyTimeSecurity(CurrentRowActivityTime());
                ApplyDisbursementSecurity(CurrentRowDisbursement());
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
                f.LoadFSIcon(FM.CurrentFile.StatusCode);
            }


            if (DataNotDirty)
            {
                //TODO              cmdNewWizard.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsActions.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdExpandGrid.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdFieldChooser.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsFilter.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdGroupBy.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsView.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdMoveT.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsRefresh.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsMoreInfo.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdAssociateDoc.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                activityBFGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                activityTimeGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                disbursementGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                InEditMode = false;
                ApplySecurity(CurrentRow()); //this call goes last when enabling controls
                ApplyBFSecurity(CurrentRowActivityBF());
                ApplyTimeSecurity(CurrentRowActivityTime());
                ApplyDisbursementSecurity(CurrentRowDisbursement());
            }
            else
            {
                ApplySecurity(CurrentRow()); //this call goes first when disabling controls
                ApplyBFSecurity(CurrentRowActivityBF());
                ApplyTimeSecurity(CurrentRowActivityTime());
                ApplyDisbursementSecurity(CurrentRowDisbursement());
                //TODO              cmdNewWizard.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsActions.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdExpandGrid.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdFieldChooser.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsFilter.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdGroupBy.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsView.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdMoveT.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsRefresh.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsMoreInfo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdAssociateDoc.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                activityBFGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                activityTimeGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                disbursementGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                
                //pnlTab.Focus(); //commented out on feb 22 2011 as it is possibly causing focus issues when the wizard is active in citrix

                InEditMode = true;
            }
            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);

        }

        public override void ApplySecurity(DataRow dr)
        {
            if (dr == null)
                return;

            atriumDB.ActivityRow ar = (atriumDB.ActivityRow)dr;
            if (FileForm() != null && FileForm().ReadOnly)
            {
                //ucDoc1.ReadOnly(true);
                ucDocView1.ReadOnly(true);
            }
            if (FileForm() != null && !FileForm().ReadOnly)
            {

                UIHelper.EnableControls(activityBindingSource, FM.GetActivity().CanEdit(ar));

                UIHelper.EnableCommandBarCommand(tsDelete, FM.GetActivity().CanDelete(ar, FM.CurrentFileId));
                UIHelper.EnableCommandBarCommand(cmdMoveT, FM.GetActivity().CanMove(ar));

                //JLL: 2011-11-17 Check can add to enable/disable add timeslip button
                //can it be moved higher up in screen?  
                //its really checking canadd activity in file at the moment.  
                //moving it up means we don't check it for every activity.
                btnNewTimeslip.Enabled = FM.GetActivityTime().CanAdd(ar);
                btnNewBF.Enabled = FM.GetActivityBF().CanAdd(ar);
                btnNewDisb.Enabled = FM.GetDisbursement().CanAdd(ar);

                if (!CurrentRow().IsCommunicationNull() && CurrentRow().Communication)
                {
                    tsReply.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    tsReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    tsForward.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdMoveEntireConversationToList.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    tsReply.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    //cannot move entire conversation (even if CheckMove returns true) if currentrow is not comm.
                    //commenting out the below line will make the move entire conversation do nothing when selecting if not activity.communication=true
                    cmdMoveEntireConversationToList.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }

                ////for disbursements

                //atriumDB.DisbursementRow[] disbR = ar.GetDisbursementRows();
                //disbursementGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;

                //if (disbR.Length > 0 && !FM.GetDisbursement().CanEdit(disbR[0]))
                //    disbursementGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            }
            if (MoveList.Count > 0)
                tsMove.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            if (ar.FileId != FM.CurrentFileId && ar.IsXrefIdNull()) //activity loaded from a xrefd file
            {
                tabBF.Enabled = false;
                tabTK.Enabled = false;
                tabDisb.Enabled = false;

                tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsConvertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsRevertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdMoveT.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                tsReply.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsReplyAll.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            }
            else
            {
                tabBF.Enabled = ar.IsXrefIdNull();
                tabTK.Enabled = ar.IsXrefIdNull();
                tabDisb.Enabled = ar.IsXrefIdNull();

                if (ar.IsXrefIdNull())
                {
                    tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    if (tsConvertTo.Commands.Count > 0)
                        tsConvertTo.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    else
                        tsConvertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                    
                    if (tsRevertTo.Commands.Count > 0) 
                        tsRevertTo.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    else
                        tsRevertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsConvertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsRevertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                }
            }


        }
        public void ApplyBFSecurity(DataRow dr)
        {
            if (FileForm() != null && !FileForm().ReadOnly && dr != null)
            {
                bFDateCalendarCombo.Enabled = true;
                bfCommentEditBox.Enabled = true;
                priorityJComboBox.Enabled = true;

                atriumDB.ActivityBFRow ar = (atriumDB.ActivityBFRow)dr;
                
                
                ucBFOfficerId.Visible = ar.IsRoleCodeNull();
                ebBFPerson.Visible = !ar.IsRoleCodeNull();
                
                if (dr.RowState == DataRowState.Added)
                {
                    UIHelper.EnableControls(activityBFBindingSource, true);
                    //activityBFGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                }
                else
                {
                    UIHelper.EnableControls(activityBFBindingSource, FM.GetActivityBF().CanEditBF(ar));

                    //JLL if you can't add activity, you can't add BFs
                    btnNewBF.Visible = FM.GetActivity().CanAdd(FM.CurrentFile);

                    if (FM.GetActivityBF().CanEditBF(ar))
                    {
                        activityBFGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                        activityBFGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Image;
                    }
                    else
                    { 
                        activityBFGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                        activityBFGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                    }
                }
            }
            else
            {
                btnNewBF.Visible = FM.GetActivity().CanAdd(FM.CurrentFile);
                bFDateCalendarCombo.Enabled = false;
                bfCommentEditBox.Enabled = false;
                ebBFPerson.Text = "";
                priorityJComboBox.Enabled = false;
            }
               
        }
        public void ApplyTimeSecurity(DataRow dr)
        {
            if (FileForm() != null && !FileForm().ReadOnly && dr != null && dr.RowState != DataRowState.Added)
            {
                atriumDB.ActivityTimeRow ar = (atriumDB.ActivityTimeRow)dr;
                bool canEdit = FM.GetActivityTime().CanEdit(ar);
                bool canDelete = FM.GetActivityTime().CanDelete(ar);

                UIHelper.EnableControls(activityTimeBindingSource, canEdit);

                if (canDelete)
                {
                    activityTimeGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                    activityTimeGridEX.RootTable.Columns["Delete"].Selectable = true;
                }
                else
                {
                    activityTimeGridEX.RootTable.Columns["Delete"].Selectable = false;
                    activityTimeGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                }
            }
            else if (dr != null && dr.RowState == DataRowState.Added)
            {
                //you could add it, so why could you not edit it.
                atriumDB.ActivityTimeRow ar = (atriumDB.ActivityTimeRow)dr;

                //activityTimeGridEX.RootTable.Columns["Hours"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Image;
                //activityTimeGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                calActivityTimeDate.Enabled = true;
                mccTimeslipOfficerId.Enabled = true;
                ebActivityTimeComment.Enabled = true;

            }
            else
            {
                btnNewTimeslip.Visible = FM.GetActivity().CanAdd(FM.CurrentFile);
            }

            finalUICheckBox.Enabled = false;

        }

        public void ApplyDisbursementSecurity(DataRow dr)
        {
            if (FileForm() != null && !FileForm().ReadOnly && dr != null)
            {
                toggleDisbDisplay(true);
                atriumDB.DisbursementRow ar = (atriumDB.DisbursementRow)dr;
                bool canEdit = FM.GetDisbursement().CanEdit(ar);

                UIHelper.EnableControls(disbursementBindingSource, canEdit);
                
                mccTaxRateId.ReadOnly = !canEdit;

                bool canDelete = false;
                if(ar.RowState!= DataRowState.Added)
                {
                    canDelete = FM.GetDisbursement().CanDelete(ar);
                }
                
                if (canDelete)
                {
                    disbursementGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                    disbursementGridEX.RootTable.Columns["Delete"].Selectable = true;
                }
                else
                {
                    disbursementGridEX.RootTable.Columns["Delete"].Selectable = false;
                    disbursementGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                }
            }
            else
            {
                btnNewDisb.Visible = FM.GetDisbursement().CanAdd(CurrentRow());
                toggleDisbDisplay(false);
            }

            finalUICheckBox1.Enabled = false;
        }

        private void toggleDisbDisplay(bool show)
        {
            disbDateLabel.Visible = show;
            disbDateCalendarCombo.Visible = show;
            disbTaxableLabel.Visible = show;
            disbTaxableNumericEditBox.Visible = show;
            disbTaxLabel.Visible = show;
            disbTaxNumericEditBox.Visible = show;
            disbTaxExemptLabel.Visible = show;
            disbTaxExemptNumericEditBox.Visible = show;
            disbTypeLabel.Visible = show;
            disbTypeucMultiDropDown.Visible = show;
            commentLabel.Visible = show;
            commentEditBox.Visible = show;
            disbCommentCounter.Visible = show;
            sRPDateLabel1.Visible = show;
            sRPDateCalendarCombo1.Visible = show;
            finalUICheckBox1.Visible = show;
            
            //doesnt show it here, other logic will detemrine if it should be displayed
            if(!show)
                mccTaxRateId.Visible = show;
        }

        public override void Delete()
        {
            try
            {
                atriumDB.ActivityRow ar = CurrentRow();
                string msg1 = "";
                if (ar.IsXrefIdNull())
                {
                    msg1 = LawMate.Properties.Resources.DeleteActivity;
                }
                else
                {
                    msg1 = LawMate.Properties.Resources.DeleteActivityXref;
                }

                if (MessageBox.Show(msg1, FM.AtMng.AppMan.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ar.Delete();
                    if (ar.HasErrors)
                    {
                        ar.RejectChanges();
                        string msg = ar.RowError;
                        ar.RowError = "";
                        throw new LMException(msg);

                        //UIHelper.TableHasErrorsOnSaveMessBox();
                    }
                    else
                    {
                      
                        FM.SaveAll();

                        this.FileForm().fileToc.LoadTOC();


                        //reload docs
                        FileForm().ReloadDocs();
                    }
                }

            }
            catch (Exception x)
            {
                Cancel();
                UIHelper.HandleUIException(x);

            }
        }
        public override void Save()
        {

            if (FM.DB.HasErrors)
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            else
            {
                try
                {
                    activityBFGridEX.UpdateData();
                    //activityTimeGridEX.UpdateData();
                    //disbursementGridEX.UpdateData();
                    ucDocView1.EndEdit();
                    this.activityBindingSource.EndEdit();
                    this.activityBFBindingSource.EndEdit();
                    this.activityTimeBindingSource.EndEdit();
                    this.disbursementBindingSource.EndEdit();

                    FM.SaveAll();

                    if (CurrentRow() != null)
                        DisplayDoc(CurrentRow());
                }
                catch (Exception x)
                {
                    
                    UIHelper.HandleUIException(x);
                }
            }
        }
        //private void ucDocPreview1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    activityGridEX.Focus();
        //}

        public void MoreInfoTime(string linkTable, int acId, atriumDB.ActivityTimeRow acTimeRow)
        {    
            MoreInfo(linkTable, acId);
            tabTK.Selected = true;
            if (acTimeRow != null)
                activityTimeBindingSource.Position= activityTimeBindingSource.Find("ActivityTimeId", acTimeRow.ActivityTimeId);
        }

        public void MoreInfoDisb(string linkTable, int acId, atriumDB.DisbursementRow disbRow)
        {
            MoreInfo(linkTable, acId);
            tabDisb.Selected = true;
            if (disbRow != null)
                disbursementBindingSource.Position = disbursementBindingSource.Find("DisbId", disbRow.DisbId);
        }

        public void MoreInfoBF(string linkTable, int acId, atriumDB.ActivityBFRow bfRow)
        {
            MoreInfo(linkTable, acId);
            tabBF.Selected = true;
            if (bfRow!= null)
                activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", bfRow.ActivityBFId);
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            activityBindingSource.Position = activityBindingSource.Find("ActivityId", linkId);
        }

        fTriangle HelpTriangle;
        private void ViewTriangle(ActivityConfig.ACSeriesRow acsr)
        {
            if (acsr != null && !acsr.IsNull(UIHelper.Translate(FM, "HelpE")))
            {
                if (HelpTriangle == null || HelpTriangle.IsDisposed)
                    HelpTriangle = new fTriangle(acsr, FM.AtMng);
                else
                    HelpTriangle.Navigate(acsr);

                HelpTriangle.Show();
            }
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        private void ExpandDataGrid(bool Expand)
        {
            if (Expand)
            {
                pnlACTabs.Closed = true;
                pnlToolstrip.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
            }
            else
            {
                pnlACTabs.Closed = false;
                pnlToolstrip.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
            }
            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityExpandGrid, Expand);
        }

        private void RemoveActivityFromMoveList(int activityId)
        {
            if (MoveList.Contains(activityId))
                MoveList.Remove(activityId);
            BuildGridFilter(grdMoveActivity, MoveList);

            if (MoveList.Count == 0)
            {
                tsMove.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                pnlMoveFloat.Closed = true;
                pnlMoveFloat.DockState = Janus.Windows.UI.Dock.PanelDockState.Docked;
            }
        }

        private void MoveActivityToMoveList(int activityId, bool moveEntireConversation)
        {
            pnlMoveFloat.DockState = Janus.Windows.UI.Dock.PanelDockState.Floating;
            pnlMoveFloat.Closed = false;
            tsMove.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            if (moveEntireConversation)
            {
                string convBase = "";
                atriumDB.ActivityRow[] act = (atriumDB.ActivityRow[])FM.DB.Activity.Select("ActivityId=" + activityId, "");
                if (act.Length > 0)
                    convBase = act[0].ConvIndexBase;
                else
                    return;

                foreach (atriumDB.ActivityRow ar in FM.DB.Activity.Rows)
                {
                    if (ar.ConvIndexBase == convBase && ar.Communication && FM.GetActivity().CanMove(ar))
                    {
                        if (!MoveList.Contains(ar.ActivityId))
                            MoveList.Add(ar.ActivityId);
                    }
                }
            }
            else
            {

                if (!MoveList.Contains(activityId))
                    MoveList.Add(activityId);
            }
            BuildGridFilter(grdMoveActivity, MoveList);
        }

        Janus.Windows.GridEX.GridEXFilterCondition filt;
        private void BuildGridFilter(Janus.Windows.GridEX.GridEX grd, List<int> list)
        {
            filt = new Janus.Windows.GridEX.GridEXFilterCondition(grd.RootTable.Columns["ActivityId"], Janus.Windows.GridEX.ConditionOperator.In, list);
            grd.RootTable.ApplyFilter(filt);
        }

        private void ResetGridLayout(Stream strm)
        {
            if (strm != null)
            {
                strm.Position = 0;
                BindActivityData(FM.DB.Activity);
                activityGridEX.LoadLayoutFile(strm);
                HookUpGridExDropDowns();
                activityGridEX.Refetch();
                tsFilter.IsChecked = false;
                cmdGroupBy.IsChecked = false;
            }
        }
        
        private void AssociateDocument()
        {
            if (!CurrentRow().IsDocIdNull())
            {
                MessageBox.Show(Properties.Resources.ActivityAlreadyDocAssociated);
                return;
            }
            DialogResult dr = this.openFileDialog1.ShowDialog(this.ParentForm);
            try
            {

                if (dr != DialogResult.Cancel)
                {
                    string filename = this.openFileDialog1.FileName;

                    docDB.DocumentRow newDoc = (docDB.DocumentRow)FM.GetDocMng().GetDocument().Add(FM.CurrentFile, filename);
                    string tmp = filename.Substring(filename.LastIndexOf("\\") + 1);
                    newDoc.efSubject = tmp.Remove(tmp.LastIndexOf("."));

                    newDoc.icon = UIHelper.GetFileIcon(filename);
                    newDoc.efType = "OTH";
                    newDoc.CommMode = "N/A";

                    newDoc.IsDraft = true;
                    CurrentRow().DocId = newDoc.DocId;
                    fDoc fMeta = new fDoc(FM.GetDocMng(), newDoc);
                    fMeta.MetaDataPrompt = true;
                    fMeta.Show(this.ParentForm);
                }
            }
            catch (Exception x)
            {
                Cancel();
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
            {
                try
                {
                    //Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars[0];
                    //if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    //    bar.Commands[e.Command.Key].Expand();

                    Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars[1];
                    if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    {
                        fProgress.Close();
                        bar.Commands[e.Command.Key].Expand();
                    }

                    switch (e.Command.Key)
                    {
                        case "cmdAssociateDoc":
                            AssociateDocument();
                            break;
                        case "cmdRelatedRecord":
                            FileForm().MoreInfo(CurrentRow().LinkTable, CurrentRow().LinkID);
                            break;
                        case "cmdMoreInfoBF":
                            FileForm().MoreInfo("activitybf", CurrentRowActivityBF().ActivityBFId);
                            break;
                        case "cmdDocMoreInfo":
                            FileForm().MoreInfo("document", CurrentRow().DocId);
                            break;
                        case "cmdResetGrid":
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            ResetGridLayout(CurrentLayoutStream());
                            break;
                        case "cmdMoveEntireConversationToList":
                            MoveActivityToMoveList(CurrentRow().ActivityId, true);
                            break;
                        case "cmdMoveToList":
                            MoveActivityToMoveList(CurrentRow().ActivityId, false);
                            break;
                        case "cmdHelp":
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            if (CurrentRow() == null)
                                return;
                            ActivityConfig.ACSeriesRow AcSeries = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(CurrentRow().ACSeriesId);
                            ViewTriangle(AcSeries);
                            break;
                        case "tsMoreInfo":
                            //if (CurrentRow() == null)
                            //    return;
                            //if (!CurrentRow().IsLinkTableNull())
                            //{
                            //   FileForm().MoreInfo(CurrentRow().LinkTable, CurrentRow().LinkID);
                            //}
                            break;
                        case "tsRefresh":
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            DoReload();
                            break;
                        case "cmdGroupBy":
                            if (e.Command.IsChecked)
                            {
                                activityGridEX.GroupByBoxVisible = true;
                            }
                            else
                            {
                                activityGridEX.RootTable.Groups.Clear();
                                activityGridEX.GroupByBoxVisible = false;
                            }
                            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityGroupBy, e.Command.IsChecked);
                            break;
                        case "cmdEditFields":
                            //pnlAcEditFields.Closed = !e.Command.IsChecked;
                            //FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityShowEditFields, e.Command.IsChecked);
                            break;
                        case "cmdFieldChooser":
                            activityGridEX.ShowFieldChooser(this.ParentForm, LawMate.Properties.Resources.FieldSelector);
                            FileForm().Focus();
                            break;
                        case "tsMove":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            if (!MoveList.Contains(CurrentRow().ActivityId))
                                MoveList.Add(CurrentRow().ActivityId);
                            DoMove();
                            break;
                        case "tsReply":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            lmWinHelper.ReplyForward(FM, CurrentRow().ActivityId, ConnectorType.Reply);
                            break;
                        case "tsReplyAll":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            lmWinHelper.ReplyForward(FM, CurrentRow().ActivityId, ConnectorType.ReplyAll);
                            break;
                        case "tsForward":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            lmWinHelper.ReplyForward(FM, CurrentRow().ActivityId, ConnectorType.Forward);
                            break;
                        case "tsSave":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            Save();
                            break;
                        case "tsDelete":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            Delete();
                            break;
                        case "cmdExpandGrid":
                            ExpandDataGrid(e.Command.IsChecked);
                            break;
                        case "tsViewList":
                            GridChange("List", "ucActivityGridExList", e.Command.Key);
                            break;
                        case "tsViewListBF":
                            GridChange("ListBF", "ucActivityGridExBF", e.Command.Key);
                            break;
                        case "tsViewThreadCom":
                            GridChange("Threaded", "ucActivityGridExThreaded", e.Command.Key);
                            break;
                        case "tsViewThreadComReverse":
                            GridChange("ThreadedReverse", "ucActivityGridExThreadedReverse", e.Command.Key);
                            break;
                        case "tsViewThreadProcess":
                            GridChange("Process", "ucActivityGridExProcess", e.Command.Key);
                            break;
                        //case "tsViewListDisb":
                        //GridChange("ListDisb", , "ucActivityGridExDisb");
                        // break;
                        case "tsViewListTK":
                            //GridChange("ListTK", gridLayoutStreamTK, "ucActivityGridExTK", e.Command.Key);
                            break;
                        case "tsFilter":
                            if (e.Command.IsChecked)
                                activityGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                            else
                                activityGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityFilter, e.Command.IsChecked);
                            break;
                        case "cmdCompleteBF":
                            if (CurrentRow() == null)
                                return;
                            CurrentRowActivityBF().Completed = !CurrentRowActivityBF().Completed;
                            CurrentRowActivityBF().ManuallyCompleted = CurrentRowActivityBF().Completed;
                            break;
                        case "tsAudit":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            fData fAudit = new fData(CurrentRow());
                            fAudit.Show();
                            break;
                        case "tsNextSteps":
                            if (CurrentRow() == null)
                                return;
                            Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                            try
                            {

                                this.FileForm().ReadOnly = true;
                                fACWizard fACW = new fACWizard(FM, CurrentRow().ActivityId);
                                fACW.Text += " - " + this.Text;
                                this.FileForm().HookupWizClose(fACW);
                                this.FileForm().fileToc.LoadTOC();
                                fACW.Show();
                            }
                            catch (Exception x)
                            {
                                this.FileForm().ReadOnly = false;
                                UIHelper.HandleUIException(x);
                            }
                            //fACWizard faNS = new fACWizard(FM, CurrentRow().ActivityId);
                            //faNS.Show();
                            break;
                    }
                    if (CurrentRow() == null)
                        return;

                    if (e.Command.Key == "tsNewDirectBF" || e.Command.Key.StartsWith("tsNewRoleBF"))
                    {
                        NewBF(e.Command);
                    }

                    if (e.Command.Key.StartsWith("tsConvertAC"))
                    {
                        DoConvert(e.Command);
                    }
                    if (e.Command.Key.StartsWith("tsRevertAC"))
                    {
                        DoRevert(e.Command);
                    }
                    //if (e.Command.Key.StartsWith("tsACMenu"))
                    //{
                    //    ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)e.Command.Tag;
                    //    if (acsr.InitialStep == (int)ACEngine.Step.CreateFile)
                    //    {
                    //        fACWizard fACWDyn = new fACWizard(FM, (ACEngine.Step)acsr.InitialStep, acsr.ACSeriesId);
                    //        fACWDyn.ShowDialog(this.FileForm().MainForm);
                    //        fACWDyn.Close();
                    //    }
                    //    else// if (e.ACSeries.InitialStep == (int)ACEngine.Step.Document)
                    //    {
                    //        FileForm().LaunchNewDocMailMemo((ACEngine.Step)acsr.InitialStep,acsr.ACSeriesId);

                    //    }

                    //}

                }
                catch (Exception x)
                {
                    UIHelper.HandleUIException(x);
                }
                finally { Application.UseWaitCursor = false; Cursor = Cursors.Default; }
            }
            


        }

        private Stream CurrentLayoutStream()
        {
            Stream returnValue=null;
            switch (activityGridEX.CurrentLayout.Key)
            {
                case "List":
                    returnValue = gridLayoutStreamList;
                    break;
                //case "ListBF":
                //    returnValue = gridLayoutStreamBF;
                //    break;
                //case "ListTK":
                //    returnValue = gridLayoutStreamTK;
                //    break;
                //case "Process":
                //    returnValue = gridLayoutStreamProcessGroup;
                //    break;
                //case "Threaded":
                //    returnValue = gridLayoutStreamThread;
                //    break;
                //case "ThreadedReverse":
                //    returnValue = gridLayoutStreamThreadReverse;
                //    break;
            }
            return returnValue;

        }

        private string CurrentLayoutKey()
        {
            string returnValue = "";
            switch (activityGridEX.CurrentLayout.Key)
            {
                case "List":
                    returnValue = "ucActivityGridExList";
                    break;
                case "ListBF":
                    returnValue = "ucActivityGridExBF";
                    break;
                case "ListTK":
                    returnValue = "ucActivityGridExTK";
                    break;
                case "Process":
                    returnValue = "ucActivityGridExProcess";
                    break;
                case "Threaded":
                    returnValue = "ucActivityGridExThreaded";
                    break;
                case "ThreadedReverse":
                    returnValue = "ucActivityGridExThreadedReverse";
                    break;
            }
            return returnValue;
 
        }

        private void GridChange(string layout, string gxlFileName, string commandKey)
        {
            activityGridEX.HideFieldChooser();
            if (activityGridEX.CurrentLayout.Key == "List")
                lmWinHelper.SaveGridLayout(activityGridEX, "ucActivityGridExList", FM.AtMng, LayoutVersionNumberActivity);

            activityGridEX.CurrentLayout = activityGridEX.Layouts[layout];
            lmWinHelper.LoadGridLayout(activityGridEX, gxlFileName, LayoutVersionNumberActivity);
            activityGridEX.SetDataBinding(activityBindingSource, "");
            UIHelper.ComboBoxInit("vofficerlist", activityGridEX.DropDowns["ddOfficer"], FM);

            if (layout == "ListBF")
                activityGridEX.DropDowns["ddRoleCode"].SetDataBinding(FM.Codes("vRoleucontacttype"), "");
            if (layout == "Process")
            {
                DataView processDV = new DataView(FM.DB.Process, "", "", DataViewRowState.CurrentRows);
                activityGridEX.DropDowns["ddProcess"].SetDataBinding(processDV, "");
            }

            if (layout != "ThreadedReverse")
                activityGridEX.ExpandRecords();

            activityGridEX.MoveFirst();            
            CheckViewListSelection(commandKey);
        }

        private void GridChange(string layout, Stream strm, string gxlFileName, string commandKey)
        {
            activityGridEX.HideFieldChooser();

            lmWinHelper.SaveGridLayout(activityGridEX, CurrentLayoutKey(), FM.AtMng, LayoutVersionNumberActivity);

            activityGridEX.CurrentLayout = activityGridEX.Layouts[layout];
            if(strm.Length==0)
            {
                activityGridEX.SaveLayoutFile(strm);
            }
            lmWinHelper.LoadGridLayout(activityGridEX, gxlFileName, LayoutVersionNumberActivity);
            activityGridEX.SetDataBinding(activityBindingSource, "");
            UIHelper.ComboBoxInit("vofficerlist", activityGridEX.DropDowns["ddOfficer"], FM);

            if(layout=="ListBF")
                activityGridEX.DropDowns["ddRoleCode"].SetDataBinding(FM.Codes("vRoleucontacttype"), "");
            if(layout=="Process")
            {
                DataView processDV = new DataView(FM.DB.Process, "", "", DataViewRowState.CurrentRows);
                activityGridEX.DropDowns["ddProcess"].SetDataBinding(processDV, "");
            }

            if(layout!="ThreadedReverse")
                activityGridEX.ExpandRecords();
            activityGridEX.MoveFirst();
            CheckViewListSelection(commandKey);
        }

        public override void Cancel()
        {
            UIHelper.Cancel(activityBindingSource,FM.DB.Activity);
            UIHelper.Cancel(activityBFBindingSource, FM.DB.ActivityBF);
            UIHelper.Cancel(activityTimeBindingSource, FM.DB.ActivityTime);
            UIHelper.Cancel(disbursementBindingSource, FM.DB.Disbursement);
            ucDocView1.Cancel();
            ApplyBR(true);
        }

        void fACW_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (FileForm() != null)
                    FileForm().ReadOnly = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void CheckViewListSelection(string commandKey)
        {
            tsViewList.IsChecked = false;
            tsViewListBF.IsChecked = false;
            tsViewThreadCom.IsChecked = false;
            tsViewThreadProcess.IsChecked = false;
            tsViewListDisb.IsChecked = false;
            tsViewListTK.IsChecked = false;
            tsViewThreadComReverse.IsChecked = false;

            uiCommandManager1.Commands[commandKey].IsChecked = true;
            //e.Command.IsChecked = true;
            tsFilter.IsChecked = false;
            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityFilter, false);
            cmdGroupBy.IsChecked = false;
            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityGroupBy, false);
            activityGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
            activityGridEX.GroupByBoxVisible = false;
        }

        private void activityGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(activityGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void MoveTab(string operation)
        {
            //UIHelper.MoveTab(pnlACTabs, operation);
        }



        private void activityGridEX_SelectionChanged(object sender, EventArgs e)
        {

            if (activityGridEX.CurrentRow != null)
            {
                string clickedRowTable = activityGridEX.CurrentRow.Table.Key;
                Janus.Windows.UI.Tab.UITabPage tab = null;

                switch (clickedRowTable)
                {
                    //case "Activity":
                    //    pnl = pnlActivity;
                    //    break;
                    case "Activity_ActivityBF":
                        tab = tabBF;
                        if (activityGridEX.CurrentRow.DataRow != null && ((DataRowView)activityGridEX.CurrentRow.DataRow).Row.GetType() == typeof(atriumDB.ActivityBFRow))
                        {
                            atriumDB.ActivityBFRow abr = (atriumDB.ActivityBFRow)((DataRowView)activityGridEX.CurrentRow.DataRow).Row;
                            activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", abr.ActivityBFId);
                        }


                        break;
                    case "ActivityDisbursement":
                        tab = tabDisb;
                        break;
                    case "ActivityActivityTime":
                        tab = tabTK;
                        break;
                }

                if (tab != null)
                    ucACTabs.SelectedTab = tab;
            }
        }


        private void activityGridEX_SortKeysChanged(object sender, EventArgs e)
        {
            try
            {
                if (activityGridEX.RootTable.SortKeys[0].SortOrder == Janus.Windows.GridEX.SortOrder.Ascending)
                {
                    activityGridEX.RootTable.SortKeys.Add("DateTime", Janus.Windows.GridEX.SortOrder.Ascending);
                    activityGridEX.RootTable.SortKeys.Add("ActivityId", Janus.Windows.GridEX.SortOrder.Ascending);
                }
                else
                {
                    activityGridEX.RootTable.SortKeys.Add("DateTime", Janus.Windows.GridEX.SortOrder.Descending);
                    activityGridEX.RootTable.SortKeys.Add("ActivityId", Janus.Windows.GridEX.SortOrder.Descending);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        fBrowse fileBrowser;
        private void DoMove()
        {
            //use movelist

            //get abf row
            //atriumDB.ActivityBFRow abr=CurrentRow();
            if (fileBrowser == null)
                fileBrowser = new fBrowse(FM.AtMng, 0, false, false, false, true);
            fileBrowser.FindFile(FM.CurrentFileId);

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                //DialogResult result;
                //bool splitThread = false;
                //if (activityGridEX.SelectedItems.Count == 1)
                //{
                //    atriumDB.ActivityRow ar = CurrentRow();
                //    atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])FM.DB.Activity.Select("Processid=" + ar.ProcessId.ToString(), "ConvIndexBase,ConversationIndex");
                //    if (ar.ProcessRow == null)
                //    {
                //        //this means we are moving a acxref
                //        splitThread = true;
                //    }
                //    else if (ars.Length > 1 & ars[0].ActivityId != ar.ActivityId)
                //    {
                //        result = MessageBox.Show(LawMate.Properties.Resources.UISplitThread, LawMate.Properties.Resources.UISplitThreadCaption, MessageBoxButtons.YesNoCancel);

                //        if (result == DialogResult.Cancel)
                //            return;
                //        splitThread = result == DialogResult.Yes;
                //    }
                //}

                FileManager fmTo = FM.AtMng.GetFile(fileBrowser.SelectedFile.FileId);
                fmTo.InitActivityProcess();

                string criteria = "";
                foreach (int acid in MoveList)
                {
                    fmTo.GetActivity().Load(acid);
                    if (criteria == "")
                        criteria = acid.ToString();
                    else
                        criteria += ", " + acid.ToString();
                }
                atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])fmTo.DB.Activity.Select("ActivityID in (" + criteria + ")");
                fmTo.GetActivity().Move(ars, fmTo.CurrentFileId);
                ////get fm for target file
                //if (abr.IsXrefIdNull())
                //{
                //    atriumDB.ActivityRow arr = fmTo.GetActivity().Load(abr.ActivityId);
                //    //fmTo.GetActivity().Move(arr, fmTo.CurrentFile.FileId);
                //}
                //else
                //{
                //    atriumDB.ActivityRow arr = fmTo.GetActivity().LoadByXrefId(abr.XrefId);
                //    //fmTo.GetActivity().Move(arr, fmTo.CurrentFile.FileId);
                //}
                //save
                try
                {
                    fmTo.SaveAll(); 
                    fMain fmain = (fMain)Application.OpenForms["fMain"];
                    fmain.OpenFile(fmTo.CurrentFile.FileId);

                    MoveListClear();
                }
                catch (Exception x)
                {
                  
                    UIHelper.HandleUIException(x);
                }
                //}
                //reload
                //DoReload();

            }
        }

        private void DoReload()
        {
            activityGridEX.MoveFirst();
            activityGridEX.ExpandRecords();
            if (CurrentRow() != null)
                DisplayDoc(CurrentRow());
        }

        public override void ReloadUserControlData()
        {
            DoReload();
        }

        private void bFDateCalendarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            UIHelper.TodaysDateShortcutKey(sender, e);
        }


        private void btnNewDisb_Click(object sender, EventArgs e)
        {
            try
            {
                //manually entered disbursements
                if (!FM.GetDisbursement().CanAdd(CurrentRow()))
                    MessageBox.Show(LawMate.Properties.Resources.UICantAddDisb, LawMate.Properties.Resources.UIOpNotAllowed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //2017-08-10 JLL if we don't suspend the binding, afteradd causes bindingsource_currentchanged to execute to early
                    //resuming binding below causes currentchanged to fire perfectly
                    disbursementBindingSource.SuspendBinding();
                    atriumDB.DisbursementRow disbrow = (atriumDB.DisbursementRow)FM.GetDisbursement().Add(CurrentRow());
                    disbursementBindingSource.ResumeBinding();
                    disbursementBindingSource.Position = disbursementBindingSource.Find("DisbId", disbrow.DisbId);
                    disbDateCalendarCombo.Focus();
                    

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            BFRowChanging = true;
            tabBF.Text = String.Format(LawMate.Properties.Resources.ActivityBFTab, activityBFBindingSource.Count.ToString());
            if (CurrentRowActivityBF() == null)
            {
                bFDateCalendarCombo.Enabled = false;
                bfCommentEditBox.Enabled = false;
                ebBFPerson.Text = "";
                priorityJComboBox.Enabled = false;
                ebBFPerson.ReadOnly= true;
                ucBFOfficerId.Enabled = false;
                return;
            }
            else
            {
                bFDateCalendarCombo.Enabled = true;
                bfCommentEditBox.Enabled = true;
                priorityJComboBox.Enabled = true;
                ucBFOfficerId.Enabled = true;
            }

            atriumDB.ActivityBFRow bfr = CurrentRowActivityBF();

            ApplyBFSecurity(bfr);
            //if (bfr.Completed)
            //{ }
            //if (bfr.BFType == 2)
            //    activityBFGridEX.RootTable.Columns["BFOfficerCode"].Selectable = true;
            //else
            //    activityBFGridEX.RootTable.Columns["BFOfficerCode"].Selectable = false;

            //if (bfr.ForOfficeId == FM.CurrentFile.LeadOfficeId)
            //    UIHelper.BindComboBox(bFOfficerIDComboBox, dtLeadOfficers);
            //else if (bfr.ForOfficeId == FM.CurrentFile.OwnerOfficeId)
            //    UIHelper.BindComboBox(bFOfficerIDComboBox, dtOwnerOfficers);
            //else
            //    throw new Exception("Need to load officer list - forOfficeId on BF is not owner or lead");
            // TODO:
            // check to see if officer list already loaded in dictionary
            // if loaded, bind to list
            // if not, load, bind to list, and add to dictionary


        }
        bool firstDoc = true;

            

        private void activityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (activityBindingSource.Current == null)
                    return;

                NoData(activityBindingSource.Count == 0);
                atriumDB.ActivityRow ar = CurrentRow();

                if (CurrentRow().IsNull("ActivityID"))
                    return;

                //check permissions
                //for activity
                ApplySecurity(ar);

                //Check for FailedToSend
                pnlFailedToSend.Closed = true;
                if (CurrentRow().IsNull("FailedToSend"))
                    pnlFailedToSend.Closed = true;
                else
                {
                    if (CurrentRow().OfficerId == FM.AtMng.WorkingAsOfficer.OfficerId)
                        pnlFailedToSend.Closed = !(CurrentRow().FailedToSend);
                }

                //load doc
                DisplayDoc(ar);
                // bind Officer Code DropDowns to correct list

                if (ar.GetActivityBFRows().Length > 0)
                    cmdMoreInfoBF.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmdMoreInfoBF.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                if (!ar.IsLinkTableNull() && !ar.IsLinkIDNull())
                    cmdRelatedRecord.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmdRelatedRecord.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                if (!cmdDocMoreInfo.IsEnabled && !cmdMoreInfoBF.IsEnabled && !cmdRelatedRecord.IsEnabled)
                    tsMoreInfo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                else
                    tsMoreInfo.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                ApplyBFSecurity(CurrentRowActivityBF());
                ApplyTimeSecurity(CurrentRowActivityTime());
                ApplyDisbursementSecurity(CurrentRowDisbursement());
                
                UIHelper.DoNewBFMenu(FM, uiContextMenu3);
                
                //if (ar.OfficeId == FM.CurrentFile.LeadOfficeId)
                //    UIHelper.BindComboBox(officerIdComboBox, dtLeadOfficers);
                //else if (ar.OfficeId == FM.CurrentFile.OwnerOfficeId)
                //    UIHelper.BindComboBox(officerIdComboBox, dtOwnerOfficers);
                //else
                //    throw new Exception("Need to load officer list - OfficeId on activity is not owner or lead");
                // TODO:
                // check to see if officer list already loaded in dictionary
                // if loaded, bind to list
                // if not, load, bind to list, and add to dictionary
            }
            //catch (NullReferenceException nx)
            //{
            //    System.Diagnostics.Debug.Assert(false, nx.Message);
            //}
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void DisplayDoc(atriumDB.ActivityRow ar)
        {
            if (!ar.IsDocIdNull())
            {
                tabDocument.Enabled = true;
                cmdAssociateDoc.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                docDB.DocumentRow dr;
                docDB.DocumentRow[] drs = (docDB.DocumentRow[])FM.GetDocMng().DB.Document.Select("DocId=" + ar.DocId.ToString());
                if (drs.Length == 0)
                {
                    dr = FM.GetDocMng().GetDocument().Load(ar.DocId);
                }
                else
                    dr = drs[0];

                if (dr == null)
                {
                    //ucDoc1.Datasource = new DataView(dr.Table, "Docid=0", "", DataViewRowState.CurrentRows);
                    //ucDoc1.NoAssociatedDocument(LawMate.Properties.Resources.YouCantViewThisDocumentBecauseOfSecurity);
                    ucDocView1.Datasource = new DataView(dr.Table, "Docid=0", "", DataViewRowState.CurrentRows);
                    ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.YouCantViewThisDocumentBecauseOfSecurity);
                    cmdDocMoreInfo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    //ucDoc1.Datasource = new DataView(dr.Table, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                    if (ucDocView1.DocRecord == null || dr.DocId != ucDocView1.DocRecord.DocId || dr.IsDraft || dr.ext.ToLower()!=".pdf")
                    {
                        

                        ucDocView1.Datasource = new DataView(dr.Table, "Docid=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);
                        if (firstDoc)
                        {
                            firstDoc = false;
                            //ucDoc1.Preview();
                            ucDocView1.Preview();
                        }
                        else
                        {
                            //ucDoc1.PreviewAsync();
                            ucDocView1.PreviewAsync();
                        }
                    }
                    cmdDocMoreInfo.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
            }
            else
            {
                //ucDoc1.Datasource = new DataView(FM.GetDocMng().DB.Document, "Docid=0", "", DataViewRowState.CurrentRows);
                //ucDoc1.NoAssociatedDocument(LawMate.Properties.Resources.ThereIsNoDocument);
                ucDocView1.Datasource = new DataView(FM.GetDocMng().DB.Document, "Docid=0", "", DataViewRowState.CurrentRows);
                ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.ThereIsNoDocument);
                cmdDocMoreInfo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdAssociateDoc.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tabDocument.Enabled = false;
                if (ucACTabs.SelectedTab == tabDocument)
                    ucACTabs.SelectedTab = tabActivity;
            }
        }


        //TODO: hate that this loads data; gotta find a better way!!!!
        private void activityTimeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            tabTK.Text = String.Format(LawMate.Properties.Resources.ActivityTimeTab, activityTimeBindingSource.Count.ToString());
            atriumDB.ActivityTimeRow bfr = CurrentRowActivityTime();
            if (bfr!=null && !bfr.IsOfficeIdNull())
            {
                mccTimeslipOfficerId.Visible = (bfr != null && !(bfr.OfficeId != FM.AtMng.WorkingAsOfficer.OfficeId));
                ucTimeslipOfficerId.Visible = (bfr != null && (bfr.OfficeId != FM.AtMng.WorkingAsOfficer.OfficeId));

                if (bfr != null && bfr.OfficeId == FM.AtMng.WorkingAsOfficer.OfficeId)
                {
                    DataView dv = new DataView(FM.AtMng.GetOffice(bfr.OfficeId).DB.Officer);
                    UIHelper.ComboBoxInit(dv, mccTimeslipOfficerId, FM);
                }
            }
            calActivityTimeDate.Enabled = (bfr != null);
            mccTimeslipOfficerId.Enabled = (bfr != null);
            ucTimeslipOfficerId.Enabled = (bfr != null);
            ucTimeslipOfficeId.Enabled = (bfr != null);
            hoursNumericEditBox.Enabled = (bfr != null);
            postedUICheckBox.Enabled = (bfr != null);
            ebActivityTimeComment.Enabled = (bfr != null);
            if (bfr != null)
                ApplyTimeSecurity(bfr);
        }

        private void disbursementBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            tabDisb.Text = String.Format(LawMate.Properties.Resources.ActivityDisbTab, disbursementBindingSource.Count.ToString());
            atriumDB.DisbursementRow bfr = CurrentRowDisbursement();
            if (bfr == null)
                return;

            ApplyDisbursementSecurity(bfr);

            //UI: resize tax edit control to line up clean when no taxrate displayed
            bool hasTaxRate = !bfr.IsTaxRateIdNull();
            mccTaxRateId.Visible = hasTaxRate;
            disbTaxNumericEditBox.SendToBack();
            if (hasTaxRate)
                disbTaxNumericEditBox.Width = 153;
            else
                disbTaxNumericEditBox.Width = 96;

            
        }

        private void DoConvert(Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)cmd.Tag;
            atriumDB.ActivityRow ar = CurrentRow();

            FileManager fmTo = FM;
            atriumDB.ActivityRow art = ar;
            if (!acsr.SeriesRow.IsContainerFileIdNull())
            {
                fmTo = FM.AtMng.GetFile(acsr.SeriesRow.ContainerFileId);
                fmTo.InitActivityProcess();
                art = fmTo.GetActivity().Load(ar.ActivityId);
                atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])fmTo.DB.Activity.Select("ActivityId=" + art.ActivityId.ToString());
                fmTo.GetActivity().Move(ars, acsr.SeriesRow.ContainerFileId);
                //if (fmTo.CurrentFile.FileId != acsr.SeriesRow.ContainerFileId)
                //{
                //    FM.DB.Activity.RemoveActivityRow(ar);
                //    FM.DB.Activity.AcceptChanges();
                //    FM.DB.ActivityTime.AcceptChanges();
                //    FM.DB.ActivityBF.AcceptChanges();
                //    FM.DB.Disbursement.AcceptChanges();
                //}
            }

            //load activity
            fmTo.InitActivityProcess();

            //do convert
            fmTo.GetActivity().ConvertAC(art, acsr);

            //save
            try
            {
                fmTo.SaveAll();              


                if (acsr.AutoChain)
                    FileForm().LaunchWizard();

                //Janus.Windows.UI.CommandBars.UICommand cmdNS = DoBuildNextStepMenu(tsNextSteps1);
                //if (cmdNS != null)
                //    DoNextStep(cmdNS);
            }
            catch (Exception x)
            {
               
                fmTo.DB.RejectChanges();
                UIHelper.HandleUIException(x);
            }
            finally
            {
            }

        }

        private void DoRevert(Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            //load activity
            FM.InitActivityProcess();


            atriumDB.ActivityRow ar = CurrentRow();



            //do convert/revert
            FM.GetActivity().ConvertAC(ar, (ActivityConfig.ACSeriesRow)cmd.Tag,true);

            //save
            try
            {
                FM.SaveAll();              

            }
            catch (Exception x)
            {
             
                FM.DB.RejectChanges();
                UIHelper.HandleUIException(x);
            }
            finally
            {
            }

        }

        //private void DoNextStep(Janus.Windows.UI.CommandBars.UICommand cmd)
        //{
        //    atriumDB.ActivityRow ar = CurrentRow();
        //    NextStep ns = (NextStep)cmd.Tag;

        //    ActivityConfig.ACSeriesRow acsr = ns.acs;

        //    FileManager newFM;

        //    if (!acsr.SeriesRow.IsContainerFileIdNull())
        //    {
        //        int fileId = acsr.SeriesRow.ContainerFileId;
        //        newFM = FM.AtMng.GetFile(fileId, false);
        //    }
        //    else
        //        newFM = FM;


        //    fACWizard facw = new fACWizard(newFM, (ACEngine.Step)acsr.InitialStep, acsr.ACSeriesId, ar.ActivityId);
        //    facw.ShowDialog(this);
        //    if (facw.OpenFile)
        //        FileForm().MainForm.OpenFile(facw.FileId);

        //    facw.Close();

        //}

        //private Janus.Windows.UI.CommandBars.UICommand DoBuildNextStepMenu(Janus.Windows.UI.CommandBars.UICommand cmd)
        //{

        //    //load activity
        //    FM.InitActivityProcess(true);

        //    //do convert
        //    atriumDB.ActivityRow ar = CurrentRow();

        //    //clear current items
        //    cmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //    cmd.Commands.Clear();

        //    //add list of next steps
        //    Dictionary<int, CurrentFlow> aps = FM.InitActivityProcess(true).Workflow.NextSteps(ar);
        //    if (aps.Count > 0)
        //    {
        //        atriumBE.CurrentFlow ap = aps[ar.ProcessId];
        //        foreach (NextStep ns in ap.NextSteps.Values)
        //        {

        //            //add new items
        //            Janus.Windows.UI.CommandBars.UICommand newCmd = new Janus.Windows.UI.CommandBars.UICommand();
        //            newCmd.Key = "tsDoNextStep" + ns.acs.ACSeriesId.ToString();

        //            newCmd.Text =FM.AtMng.acMng.GetACSeries().GetNodeText(ns.acs, (StepType)ns.acs.StepType, false);
        //            newCmd.Tag = ns;
        //            cmd.Commands.Add(newCmd);
        //        }
        //    }
        //    if (cmd.Commands.Count > 0)
        //        cmd.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        //    if (cmd.Commands.Count == 1)
        //        return cmd.Commands[0];
        //    else
        //        return null;
        //}

        private void DoBuildConvertMenu(Janus.Windows.UI.CommandBars.UICommand cmd)
        {

            atriumDB.ActivityRow acr = CurrentRow();
            ActivityConfig.ACSeriesRow acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acr.ACSeriesId);
            UIHelper.DoConvertMenu(FM.CurrentFileId, cmd, acsr, true);
        }
        private void DoBuildRevertMenu(Janus.Windows.UI.CommandBars.UICommand cmd)
        {

            atriumDB.ActivityRow acr = CurrentRow();
            ActivityConfig.ACSeriesRow acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acr.ACSeriesId);
            UIHelper.DoRevertMenu(FM.AtMng, cmd, acsr);
        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            try
            {
                //JLL 2015-10-02 added canAdd check; if you can't add, hide context menu (quickest way to implement fullreadonly)
                if (activityGridEX.HitTest() == Janus.Windows.GridEX.GridArea.Cell && !FileForm().ReadOnly && FM.GetActivity().CanAdd(FM.CurrentFile))
                {
                    atriumDB.ActivityRow ar = CurrentRow();

                    tsConvertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsConvertTo.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    if (FM.GetActivity().CanEdit(ar))
                    {
                        DoBuildConvertMenu(tsConvertTo);
                        if (tsConvertTo.Commands.Count > 0)
                            tsConvertTo.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                        DoBuildRevertMenu(tsRevertTo);
                        if (tsRevertTo.Commands.Count > 0)
                            tsRevertTo.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                        //DoBuildNextStepMenu(tsNextSteps);

                    }

                    ActivityConfig.ACSeriesRow AcSeries = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(CurrentRow().ACSeriesId);
                    if (AcSeries != null && !AcSeries.IsNull(UIHelper.Translate(FM, "HelpE")))
                        cmdHelp.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    else
                        cmdHelp.Enabled = Janus.Windows.UI.InheritableBoolean.False;


                    //2017-09-20 ... should be moved to editmode toggle, but there is a todo reference and commented out block enabling/disabling wizard command ... dont know why
                    if (InEditMode)
                        tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    else
                        tsNextSteps.Enabled = Janus.Windows.UI.InheritableBoolean.True;


                }
                else
                {
                    uiContextMenu1.Close();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void activityBFGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            try
            {
                atriumDB.ActivityBFRow acbf = (atriumDB.ActivityBFRow)((DataRowView)e.Row.DataRow).Row;
                if (!FM.GetActivityBF().CanDelete(acbf))
                {
                    MessageBox.Show(LawMate.Properties.Resources.YouDoNotHaveSufficientAccessToDeleteThisRecord, LawMate.Properties.Resources.DeletingBFs, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    if (!UIHelper.ConfirmDelete())
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        try
                        {
                            acbf.Delete();

                            FM.SaveAll();
                        }
                        catch (Exception x1)
                        {
                            FM.DB.ActivityBF.RejectChanges();
                            throw x1;
                        }

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
            try
            {
                if (activityBFGridEX.CurrentRow != null)
                {
                    if (CurrentRowActivityBF().IsBFOfficerIDNull())
                        ebBFPerson.Text = activityBFGridEX.CurrentRow.Cells["RoleCode"].Text;
                    else
                        ebBFPerson.Text = activityBFGridEX.CurrentRow.Cells["BFOfficerCode"].Text;
                }
                else
                    ebBFPerson.Text = "";
                //Janus.Windows.GridEX.GridEX grd = (Janus.Windows.GridEX.GridEX)sender;
                //if (grd.CurrentRow != null)
                //{
                //    if (grd.CurrentRow.RowType == Janus.Windows.GridEX.RowType.FilterRow)
                //        activityBFGridEX.RootTable.Columns["BFOfficerCode"].Selectable = true;
                //    else if (grd.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record && CurrentRowActivityBF().BFType != 2)
                //        activityBFGridEX.RootTable.Columns["BFOfficerCode"].Selectable = false;
                //}
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
                atriumDB.ActivityBFRow acbf = CurrentRowActivityBF();
                if (acbf == null || activityBFGridEX.HitTest() != Janus.Windows.GridEX.GridArea.Cell || !FM.GetActivityBF().CanEditBF(acbf))
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
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityCommentTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.EditControls.EditBox tbText = (Janus.Windows.GridEX.EditControls.EditBox)sender;
                switch (tbText.Name)
                {
                    case "activityCommentEditBox":
                        UIHelper.TextBoxTextCounter(tbText, acCommentCounter, 255);
                        break;
                    case "bfCommentEditBox":
                        UIHelper.TextBoxTextCounter(tbText,  bfCommentCounter , 255);
                        break;
                    case "ebActivityTimeComment":
                        UIHelper.TextBoxTextCounter(tbText, ACTimeCommentCounter, 255);
                        break;
                    case "commentEditBox":
                        UIHelper.TextBoxTextCounter(tbText, disbCommentCounter, 255);
                        break;

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }




            UIHelper.TextBoxTextCounter(activityCommentEditBox, acCommentCounter, 255);
        }

        private void uiCommandBar1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                if (e.Command.Commands.Count > 0)
                    e.Command.Expand();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucDoc1_DocAction(object sender, UserControls.DocActionEventArgs e)
        {
            lmWinHelper.DocAction(FM.AtMng.GetFile(e.DocRecord.FileId), e);

        }

        private void activityGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.DataRow != null && ((DataRowView)e.Row.DataRow).Row.GetType() == typeof(atriumDB.ActivityRow))
                {
                    atriumDB.ActivityRow ar = (atriumDB.ActivityRow)((DataRowView)e.Row.DataRow).Row;

                    //don't display time if activity date is not activity entry date
                    DateTime tm = (DateTime)e.Row.Cells["DateTime"].Value;
                    TimeSpan ts = new TimeSpan(0, 0, 0);
                    TimeSpan ts11 = new TimeSpan(23, 59, 59);
                    if (tm.TimeOfDay == ts || tm.TimeOfDay == ts11) // don't display time
                        e.Row.Cells["DateTime"].Text = UIHelper.FormatDateYYYYMMDD(tm);


                    //e.Row.Cells["ActivityEntryDate"].
                    //e.Row.Cells["ActivityEntryDate"]  

                    //loaded activity xrefs
                    if (ar.FileId != FM.CurrentFile.FileId)
                    {
                        Janus.Windows.GridEX.GridEXFormatStyle fmt = new Janus.Windows.GridEX.GridEXFormatStyle();
                        fmt.BackColor = Color.LightYellow;
                        e.Row.RowStyle = fmt;
                    }

                    if (!ar.IsNull("FailedToSend") && ar.FailedToSend)
                    {   //if you are hitting this breakpoint; verify that this works ok
                        //idea is that we'll show the FailedToSend column if there is at least one row where failedtosend=true;

                        //there is at least one FailedToSend record, automatically show column
                        activityGridEX.RootTable.Columns["FailedToSend"].Visible = true;
                    }

                }
                else if (e.Row.DataRow != null && ((DataRowView)e.Row.DataRow).Row.GetType() == typeof(atriumDB.ActivityBFRow))
                {
                    atriumDB.ActivityBFRow abr = (atriumDB.ActivityBFRow)((DataRowView)e.Row.DataRow).Row;
                    if (FM.GetActivityBF().IsDirect(abr) && !abr.isRead)
                    {
                        Janus.Windows.GridEX.GridEXFormatStyle fmt = new Janus.Windows.GridEX.GridEXFormatStyle();
                        fmt.FontBold = Janus.Windows.GridEX.TriState.True;
                        e.Row.RowStyle = fmt;
                    }
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.DataRow == null)
                    return;

                if (((DataRowView)e.Row.DataRow).Row.GetType() == typeof(atriumDB.ActivityRow))
                {
                    atriumDB.ActivityRow ar = (atriumDB.ActivityRow)((DataRowView)e.Row.DataRow).Row;
                    DateTime entryDtLocal= ar.ActivityEntryDate.ToLocalTime();
                    if (ar.ActivityDate.Date == entryDtLocal.Date)
                    { //activity date is day entered
                        e.Row.Cells["DateTime"].Value = entryDtLocal;
                        e.Row.Cells["EntryType"].Value = "none";
                    }

                    else if (ar.ActivityDate.Date > entryDtLocal.Date) //activity dated in the future
                    {
                        DateTime date = new DateTime(ar.ActivityDate.Year, ar.ActivityDate.Month, ar.ActivityDate.Day, 0, 0, 0);
                        e.Row.Cells["DateTime"].Value = date;
                        e.Row.Cells["EntryType"].Value = "future";
                    }
                    else if (ar.ActivityDate.Date < entryDtLocal.Date) //back-dated activity
                    {
                        DateTime date = new DateTime(ar.ActivityDate.Year, ar.ActivityDate.Month, ar.ActivityDate.Day, 23, 59, 59);
                        e.Row.Cells["DateTime"].Value = date;
                        e.Row.Cells["EntryType"].Value = "back";
                    }
                }
                else if (((DataRowView)e.Row.DataRow).Row.GetType() == typeof(atriumDB.ActivityBFRow))
                {
                     if (e.Row.Cells["BFOfficerID"].Text == "")
                        e.Row.Cells["BFPerson"].Value = e.Row.Cells["RoleCode"].Text;
                    else
                        e.Row.Cells["BFPerson"].Value = e.Row.Cells["BFOfficerID"].Text;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.DataRow == null)
                    return;

                lmDatasets.atriumDB.ActivityBFRow abr = (lmDatasets.atriumDB.ActivityBFRow)((DataRowView)e.Row.DataRow).Row;
                
                if (FM.GetActivityBF().IsDirect(abr) && !abr.isRead)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle fmt = new Janus.Windows.GridEX.GridEXFormatStyle();
                    fmt.FontBold = Janus.Windows.GridEX.TriState.True;
                    e.Row.RowStyle = fmt;
                }

                if (abr.IsisMailNull())
                    return;

                if ((bool)e.Row.Cells["isMail"].Value != true)
                {
                    if (e.Row.Cells["DateTime"].Value != null)
                    {
                        DateTime tm = (DateTime)e.Row.Cells["DateTime"].Value;
                        TimeSpan ts = new TimeSpan(0, 0, 0);
                        if (tm.TimeOfDay == ts)
                            e.Row.Cells["DateTime"].Text = UIHelper.FormatDateYYYYMMDD(tm);
                    }
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
                if (e.Row.DataRow == null)
                    return;

                lmDatasets.atriumDB.ActivityBFRow abr = (lmDatasets.atriumDB.ActivityBFRow)((DataRowView)e.Row.DataRow).Row;
                if (abr.IsisMailNull())
                    return;

                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record && e.Row.Cells["BFDate"].Value != null)
                {
                    if ((bool)e.Row.Cells["isMail"].Value == true)
                    {
                        int Hours = ((DateTime)e.Row.Cells["entryDate"].Value).Hour;
                        int Minutes = ((DateTime)e.Row.Cells["entryDate"].Value).Minute;
                        TimeSpan ts = new TimeSpan(Hours, Minutes, 0);
                        DateTime fv = ((DateTime)e.Row.Cells["BFDate"].Value).Date;
                        fv += ts;
                        e.Row.Cells["DateTime"].Value = fv;
                    }
                    else
                    {
                        //if(((DataRowView)e.Row.DataRow).Row.RowState != DataRowState.Added)
                        if (e.Row.Cells["BFDate"].Value.ToString().Length > 0)
                            e.Row.Cells["DateTime"].Value = e.Row.Cells["BFDate"].Value;
                    }

                    
                    if (e.Row.Cells["BFOfficerCode"].Text == "")
                        e.Row.Cells["BFPerson"].Value = e.Row.Cells["RoleCode"].Text;
                    else
                        e.Row.Cells["BFPerson"].Value = e.Row.Cells["BFOfficerCode"].Text;
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
                //if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record || e.Row.RowType == Janus.Windows.GridEX.RowType.TotalRow)
                //{
                //    if (e.Row.Cells["Hours"].Value != null && e.Row.Cells["Hours"].Value.ToString().Length > 0)
                //        e.Row.Cells["Hours"].Text = UIHelper.FormatMinutes(decimal.ToInt32((decimal)e.Row.Cells["Hours"].Value));
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void TimeConvertorShow()
        {
            fTimeConvertor ftc = new fTimeConvertor(CurrentRowActivityTime().Hours);
            ftc.ShowDialog();
            if (ftc.DialogResult == DialogResult.OK)
            {
                //JLL 2014-10-16 change to hours instead of minutes
                //CurrentRowActivityTime().Hours = ftc.totalminutes;
                CurrentRowActivityTime().Hours = (decimal)ftc.totalminutes / (decimal)60;
                //activityTimeBindingSource.EndEdit();
                activityTimeGridEX.Refetch();
            }
        }

        private void activityTimeGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                //if (e.Column.Key == "Hours")
                //{
                //    TimeConvertorShow();
                //}
                if (e.Column.Key == "Delete")
                {
                    activityTimeGridEX.Delete();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        bool BFRowChanging = false;
        private void bFDateCalendarCombo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (activityBFGridEX.CurrentRow != null && BFRowChanging == false)
                {
                    //bFDateCalendarCombo.EndEdit();
                    //activityBFBindingSource.EndEdit();
                    //activityBFGridEX.CurrentRow.Format();
                }
                if (BFRowChanging)
                    BFRowChanging = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityTimeGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            atriumDB.ActivityTimeRow acts = (atriumDB.ActivityTimeRow)((DataRowView)e.Row.DataRow).Row;
            if (!FM.GetActivityTime().CanDelete(acts))
            {
                MessageBox.Show(LawMate.Properties.Resources.YouDoNotHaveSufficientAccessToDeleteThisRecord, LawMate.Properties.Resources.DeleteTimeslip, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                bool canOverride = FM.AtMng.SecurityManager.CanOverride(acts.FileId, atSecurity.SecurityManager.Features.ActivityTime) == atSecurity.SecurityManager.ExPermissions.Yes;
                bool canDeleteAll = FM.AtMng.SecurityManager.CanDelete(acts.FileId, atSecurity.SecurityManager.Features.ActivityTime) == atSecurity.SecurityManager.LevelPermissions.All;

                string sOverrideMessage = Properties.Resources.DeleteOverrideBillingMessage;

                if (canOverride | canDeleteAll)
                {
                    if (!UIHelper.ConfirmDelete(sOverrideMessage))
                    {
                        e.Cancel = true;
                    }
                }
                else if (!UIHelper.ConfirmDelete())
                {
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        acts.Delete();
                        FM.SaveAll();
                    }
                    catch (Exception x1)
                    {
                        FM.DB.ActivityTime.RejectChanges();
                        throw x1;
                    }
                }
            }
        }

        private void lnkResend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (InEditMode)
                {
                    MessageBox.Show(Properties.Resources.ActivityCannotResendWhileEditMode, Properties.Resources.EditMode, MessageBoxButtons.OK);
                }
                else
                {
                    FM.GetDocMng().GetDocument().Resend(CurrentRow());
                    Save();
                    pnlFailedToSend.Closed = !(CurrentRow().FailedToSend);
                }
            }
            catch (Exception x)
            {
                CurrentRow().RejectChanges();
              

                UIHelper.HandleUIException(new LMException(Properties.Resources.ActivityResendAttemptFailed, x));
            }
        }

        private void activityBFGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "Delete")
                {
                    activityBFGridEX.Delete();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
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

        private void activityTimeGridEX_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                activityTimeGridEX.UpdateData();
                if (CurrentRowActivityTime().IsHoursNull())
                    CurrentRowActivityTime().Hours = 0;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityGridEX_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                if(CurrentLayoutKey()=="ucActivityGridExList")
                    lmWinHelper.UpdateLayout(activityGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnRemoveFromMoveList_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                int activityId = CurrentRow().ActivityId;
                RemoveActivityFromMoveList(activityId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnMoveList_Click(object sender, EventArgs e)
        {
            try
            {
                //Move All Activities in MoveList List<int>
                DoMove();


            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void grdMoveActivity_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //    MessageBox.Show("selection changed event fired");

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnClearMoveList_Click(object sender, EventArgs e)
        {
            try
            {
                MoveListClear();

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void MoveListClear()
        {
            MoveList.Clear();
            BuildGridFilter(grdMoveActivity, MoveList);
            pnlMoveFloat.Closed = true;
            pnlMoveFloat.DockState = Janus.Windows.UI.Dock.PanelDockState.Docked;
            tsMove.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        }

        private void grdMoveActivity_Click(object sender, EventArgs e)
        {
            if (grdMoveActivity.HitTest() == Janus.Windows.GridEX.GridArea.Cell && grdMoveActivity.CurrentRow != null)
            {
                int acid = (int)grdMoveActivity.CurrentRow.Cells["ActivityId"].Value;
                activityBindingSource.Position = activityBindingSource.Find("ActivityId", acid);
            }

        }

        private void ucDoc1_DocLoaded(object sender, UserControls.DocLoadedEventArgs e)
        {
            ApplySecurity(CurrentRow());
        }

        public override void SaveLayout()
        {
            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityFilter, false);
            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcActivityGroupBy, false);
            if(CurrentLayoutKey()== "ucActivityGridExList")
                lmWinHelper.SaveGridLayout(activityGridEX, CurrentLayoutKey(), FM.AtMng, LayoutVersionNumberActivity);
            lmWinHelper.SaveGridLayout(activityBFGridEX, "ucActivityBFGridEx", FM.AtMng, LayoutVersionNumberBF);
            lmWinHelper.SaveGridLayout(activityTimeGridEX, "ucActivityTimeGridEx", FM.AtMng, LayoutVersionNumberTK);
            lmWinHelper.SaveGridLayout(disbursementGridEX, "ucActivityDisbGridEx", FM.AtMng, LayoutVersionNumberDisb);
        }

        private void NewBF(Janus.Windows.UI.CommandBars.UICommand cmd)
        {
            atriumDB.ActivityBFRow abfr = (atriumDB.ActivityBFRow)FM.GetActivityBF().Add(CurrentRow());
            activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", abfr.ActivityBFId);
            if (cmd.Tag.GetType() == typeof(string)) //Role Code stored in command tag
            {
                abfr.SetBFOfficerIDNull();
                abfr.BFType = 7;
                abfr.RoleCode = (string)cmd.Tag;
                ucBFOfficerId.Visible = false;
                ebBFPerson.Visible = true;
                ebBFPerson.Text = activityBFGridEX.CurrentRow.Cells["RoleCode"].Text;
            }
            else
            {
                //in fact, all defaults have been set in AfterAdd
                //just toggle fields;
                ucBFOfficerId.Visible = true;
                ebBFPerson.Visible = false;
            }

            //activityBFBindingSource.Position = activityBFBindingSource.Find("ActivityBFId", abfr.ActivityBFId);
            
            //jll 2014-10-23
            //lookup -1 acbf record so we can display actual description.
            //without this, bfdesc is null until record is saved.
            ActivityConfig.ACBFRow acbfr = FM.AtMng.acMng.DB.ACBF.FindByACBFId(ActivityBFBE.USERBFID);
            abfr.BFDescriptionEng = acbfr.BFDescriptionEng;
            abfr.BFDescriptionFre = acbfr.BFDescriptionFre;

            
        }

        private void activityTimeGridEX_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(activityTimeGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(activityBFGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityBFGridEX_ColumnVisibleChanged(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                activityBFGridEX.Refresh();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void activityGridEX_ColumnVisibleChanged(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if(e.Column.Key=="EntryType")
                {
                    if (e.Column.Visible)
                        e.Column.Caption = "";
                    else
                        e.Column.Caption = "Entry Type";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }

        private void btnDeleteXrefs_Click(object sender, EventArgs e)
        {
            try
            {
                DoDeleteXrefs();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void DoDeleteXrefs()
        {
            string criteria = "";
            foreach (int acid in MoveList)
            {
                    
                if (criteria == "")
                    criteria = acid.ToString();
                else
                    criteria += ", " + acid.ToString();
            }
            atriumDB.ActivityXRefRow[] ars = (atriumDB.ActivityXRefRow[])FM.DB.Activity.Select("ActivityID in (" + criteria + ")");
            
            FM.GetActivity().DeleteActivityXrefs(ars);
            /*    
            
              try
            {
                atLogic.BusinessProcess bp = FM.GetBP();
                FM.GetActivity().Update(bp);
                bp.Update();
                FM.AtMng.AppMan.Commit();
                MoveListClear();
            }
            catch (Exception x)
            {
                FM.AtMng.AppMan.Rollback();
                UIHelper.HandleUIException(x);
            }
            */
        }

        private void btnNewTimeslip_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(FM.AtMng.GetOffice(FM.AtMng.WorkingAsOfficer.OfficeId).DB.Officer);
                UIHelper.ComboBoxInit(dv, mccTimeslipOfficerId, FM);
                atriumDB.ActivityTimeRow actm = (atriumDB.ActivityTimeRow)FM.GetActivityTime().Add(CurrentRow());
                activityTimeBindingSource.Position = activityTimeBindingSource.Find("ActivityTimeId", actm.ActivityTimeId);
                actm.OfficerId = FM.AtMng.WorkingAsOfficer.OfficerId;
                ucTimeslipOfficerId.Visible = false;
                mccTimeslipOfficerId.Visible = true;
       
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
                //NewBF();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void hoursNumericEditBox_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                TimeConvertorShow();
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
                if (!CurrentRow().IsDocIdNull())
                {
                    ucACTabs.SelectedTab = tabDocument;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void disbursementGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "Delete")
                {
                    disbursementGridEX.Delete();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void disbursementGridEX_DeletingRecord(object sender, Janus.Windows.GridEX.RowActionCancelEventArgs e)
        {
            try
            {
                atriumDB.DisbursementRow disbRow = (atriumDB.DisbursementRow)((DataRowView)e.Row.DataRow).Row;
                if (!FM.GetDisbursement().CanDelete(disbRow))
                {
                    MessageBox.Show(LawMate.Properties.Resources.YouDoNotHaveSufficientAccessToDeleteThisRecord, "Delete Disbursement" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    bool canOverride = FM.AtMng.SecurityManager.CanOverride(disbRow.FileID, atSecurity.SecurityManager.Features.Disbursement) == atSecurity.SecurityManager.ExPermissions.Yes;
                    string sOverrideMessage = Properties.Resources.DeleteOverrideBillingMessage;

                    if (canOverride)
                    {
                        if(!UIHelper.ConfirmDelete(sOverrideMessage))
                        {
                            e.Cancel = true;
                        }
                    }
                    else if (!UIHelper.ConfirmDelete())
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        try
                        {
                            disbRow.Delete();

                            FM.SaveAll();
                        }
                        catch (Exception x1)
                        {
                            FM.DB.Disbursement.RejectChanges();
                            throw x1;
                        }

                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void disbursementGridEX_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(disbursementGridEX);
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
                
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void ucACTabs_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            try
            {
                if(e.Page.Name=="tabDisb")
                    ApplyDisbursementSecurity(CurrentRowDisbursement());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }
    }
}
