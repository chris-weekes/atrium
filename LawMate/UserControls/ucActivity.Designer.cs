using System.Data;
 namespace LawMate
{
    partial class ucActivity
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                FM.DB.Activity.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetActivity().OnUpdate -= new atLogic.UpdateEventHandler(ucActivity_OnUpdate);

                FM.DB.ActivityBF.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.DB.ActivityTime.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.DB.Disbursement.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetDocMng().DB.Document.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetDocMng().DB.DocContent.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetDocMng().DB.Recipient.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);

                FM.GetActivityBF().OnUpdate -= new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
                FM.GetActivityTime().OnUpdate -= new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
                FM.GetDisbursement().OnUpdate -= new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
                FM.GetDocMng().GetDocument().OnUpdate -= new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
                FM.GetDocMng().GetDocContent().OnUpdate -= new atLogic.UpdateEventHandler(ucActivity_OnUpdate);
                FM.GetDocMng().GetRecipient().OnUpdate -= new atLogic.UpdateEventHandler(ucActivity_OnUpdate);

                this.activityBindingSource.CurrentChanged -= new System.EventHandler(this.activityBindingSource_CurrentChanged);
                this.activityGridEX.SelectionChanged -= new System.EventHandler(this.activityGridEX_SelectionChanged);
                this.activityGridEX.EnabledChanged -= new System.EventHandler(this.activityGridEX_EnabledChanged);
                this.activityBFBindingSource.CurrentChanged -= new System.EventHandler(this.activityBFBindingSource_CurrentChanged);
                this.activityTimeBindingSource.CurrentChanged -= new System.EventHandler(this.activityTimeBindingSource_CurrentChanged);
                this.disbursementBindingSource.CurrentChanged -= new System.EventHandler(this.disbursementBindingSource_CurrentChanged);
                this.uiCommandManager1.CommandClick -= new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);

                ucDocView1.Dispose();

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucActivity));
            System.Windows.Forms.Label activityCommentLabel;
            lmDatasets.atriumDB atriumDB;
            lmDatasets.CodesDB codesDB1;
            System.Windows.Forms.Label bFDateLabel;
            System.Windows.Forms.Label bFCommentLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label feesClaimedLabel;
            System.Windows.Forms.Label feesClaimedTaxLabel;
            System.Windows.Forms.Label hoursLabel;
            System.Windows.Forms.Label sRPDateLabel;
            System.Windows.Forms.Label priorityLabel;
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_0_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_0_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_0_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_0_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_0_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ValueList.Item1.Image");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_1_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_1_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_1_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_1_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item2.Image");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_2 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_2_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_2_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_2_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_2_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_2_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ValueList.Item2.Image");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_3 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_3_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_3_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item2.Image");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_4 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_5 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_5_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_5_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item2.Image");
            Janus.Windows.GridEX.GridEXLayout activityGridEX_Layout_6 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_6_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_6_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_6_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityGridEX_Layout_6_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ValueList.Item2.Image");
            Janus.Windows.GridEX.GridEXLayout grdMoveActivity_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference grdMoveActivity_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column13.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference grdMoveActivity_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column13.ValueList.Item0.Image");
            Janus.Windows.GridEX.GridEXLayout activityBFGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityBFGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column13.ButtonImage");
            Janus.Windows.GridEX.GridEXLayout activityTimeGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference activityTimeGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference activityTimeGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column10.ButtonImage");
            Janus.Windows.GridEX.GridEXLayout disbursementGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference disbursementGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference disbursementGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column7.ButtonImage");
            this.activityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.disbDateLabel = new System.Windows.Forms.Label();
            this.disbTypeLabel = new System.Windows.Forms.Label();
            this.disbTaxableLabel = new System.Windows.Forms.Label();
            this.disbTaxLabel = new System.Windows.Forms.Label();
            this.disbTaxExemptLabel = new System.Windows.Forms.Label();
            this.sRPDateLabel1 = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.activityBFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlToolstrip = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlToolstripContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.activityGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlFailedToSend = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlFailedToSendContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkResend = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMoveFloat = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlMoveFloatContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnClearMoveList = new Janus.Windows.EditControls.UIButton();
            this.btnRemoveFromMoveList = new Janus.Windows.EditControls.UIButton();
            this.btnMoveList = new Janus.Windows.EditControls.UIButton();
            this.grdMoveActivity = new Janus.Windows.GridEX.GridEX();
            this.bindingSourceMoveList = new System.Windows.Forms.BindingSource(this.components);
            this.pnlACTabs = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlACTabsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucACTabs = new Janus.Windows.UI.Tab.UITab();
            this.tabActivity = new Janus.Windows.UI.Tab.UITabPage();
            this.acCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.editBox5 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.activityCommentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.calendarCombo4 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.editBox3 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.calendarCombo2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.editBox2 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.calendarCombo3 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ucContactSelectBox2 = new LawMate.ucContactSelectBox();
            this.editBox4 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tabDocument = new Janus.Windows.UI.Tab.UITabPage();
            this.ucDocView1 = new LawMate.UserControls.ucDocView();
            this.tabBF = new Janus.Windows.UI.Tab.UITabPage();
            this.bfCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.priorityJComboBox = new Janus.Windows.EditControls.UIComboBox();
            this.btnNewBF = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu3 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.tsNextSteps1 = new Janus.Windows.UI.CommandBars.UICommand("tsNextSteps");
            this.tsConvertTo1 = new Janus.Windows.UI.CommandBars.UICommand("tsConvertTo");
            this.tsRevertTo1 = new Janus.Windows.UI.CommandBars.UICommand("tsRevertTo");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAssociateDoc1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAssociateDoc");
            this.Separator12 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsReply1 = new Janus.Windows.UI.CommandBars.UICommand("tsReply");
            this.tsReplyAll1 = new Janus.Windows.UI.CommandBars.UICommand("tsReplyAll");
            this.tsForward1 = new Janus.Windows.UI.CommandBars.UICommand("tsForward");
            this.cmdMoveT2 = new Janus.Windows.UI.CommandBars.UICommand("cmdMoveT");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator11 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdHelp1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.tsActions2 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsActions1 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.Separator9 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsMoreInfo1 = new Janus.Windows.UI.CommandBars.UICommand("tsMoreInfo");
            this.Separator15 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdGridOptions1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGridOptions");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsView1 = new Janus.Windows.UI.CommandBars.UICommand("tsView");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsView = new Janus.Windows.UI.CommandBars.UICommand("tsView");
            this.tsViewList1 = new Janus.Windows.UI.CommandBars.UICommand("tsViewList");
            this.tsViewListBF1 = new Janus.Windows.UI.CommandBars.UICommand("tsViewListBF");
            this.Separator13 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsViewThreadCom1 = new Janus.Windows.UI.CommandBars.UICommand("tsViewThreadCom");
            this.tsViewThreadComReverse1 = new Janus.Windows.UI.CommandBars.UICommand("tsViewThreadComReverse");
            this.Separator14 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsViewThreadProcess1 = new Janus.Windows.UI.CommandBars.UICommand("tsViewThreadProcess");
            this.tsViewList = new Janus.Windows.UI.CommandBars.UICommand("tsViewList");
            this.tsViewThreadCom = new Janus.Windows.UI.CommandBars.UICommand("tsViewThreadCom");
            this.tsViewThreadComReverse = new Janus.Windows.UI.CommandBars.UICommand("tsViewThreadComReverse");
            this.tsViewThreadProcess = new Janus.Windows.UI.CommandBars.UICommand("tsViewThreadProcess");
            this.tsFilter = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsViewListBF = new Janus.Windows.UI.CommandBars.UICommand("tsViewListBF");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsViewListDisb = new Janus.Windows.UI.CommandBars.UICommand("tsViewListDisb");
            this.tsViewListTK = new Janus.Windows.UI.CommandBars.UICommand("tsViewListTK");
            this.tsMove = new Janus.Windows.UI.CommandBars.UICommand("tsMove");
            this.tsRefresh = new Janus.Windows.UI.CommandBars.UICommand("tsRefresh");
            this.tsReply = new Janus.Windows.UI.CommandBars.UICommand("tsReply");
            this.tsReplyAll = new Janus.Windows.UI.CommandBars.UICommand("tsReplyAll");
            this.tsForward = new Janus.Windows.UI.CommandBars.UICommand("tsForward");
            this.tsConvertTo = new Janus.Windows.UI.CommandBars.UICommand("tsConvertTo");
            this.tsRevertTo = new Janus.Windows.UI.CommandBars.UICommand("tsRevertTo");
            this.tsNextSteps = new Janus.Windows.UI.CommandBars.UICommand("tsNextSteps");
            this.cmdCompleteBF = new Janus.Windows.UI.CommandBars.UICommand("cmdCompleteBF");
            this.tsMoreInfo = new Janus.Windows.UI.CommandBars.UICommand("tsMoreInfo");
            this.cmdRelatedRecord1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRelatedRecord");
            this.cmdDocMoreInfo3 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocMoreInfo");
            this.cmdMoreInfoBF1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMoreInfoBF");
            this.cmdReadOnly = new Janus.Windows.UI.CommandBars.UICommand("cmdReadOnly");
            this.tsActions = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.cmdAssociateDoc2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAssociateDoc");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsReply2 = new Janus.Windows.UI.CommandBars.UICommand("tsReply");
            this.tsReplyAll2 = new Janus.Windows.UI.CommandBars.UICommand("tsReplyAll");
            this.tsForward2 = new Janus.Windows.UI.CommandBars.UICommand("tsForward");
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdMoveT1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMoveT");
            this.cmdGroupBy = new Janus.Windows.UI.CommandBars.UICommand("cmdGroupBy");
            this.cmdFieldChooser = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.cmdExpandGrid = new Janus.Windows.UI.CommandBars.UICommand("cmdExpandGrid");
            this.cmdHelp = new Janus.Windows.UI.CommandBars.UICommand("cmdHelp");
            this.cmdEditFields = new Janus.Windows.UI.CommandBars.UICommand("cmdEditFields");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdDocMoreInfo1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDocMoreInfo");
            this.cmdResetGrid1 = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGrid");
            this.cmdExpandGrid2 = new Janus.Windows.UI.CommandBars.UICommand("cmdExpandGrid");
            this.tsFilter2 = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.cmdGroupBy2 = new Janus.Windows.UI.CommandBars.UICommand("cmdGroupBy");
            this.cmdFieldChooser2 = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsView2 = new Janus.Windows.UI.CommandBars.UICommand("tsView");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete3 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdMoveT = new Janus.Windows.UI.CommandBars.UICommand("cmdMoveT");
            this.tsMove1 = new Janus.Windows.UI.CommandBars.UICommand("tsMove");
            this.cmdMoveToList1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMoveToList");
            this.cmdMoveEntireConversationToList1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMoveEntireConversationToList");
            this.cmdMoveToList = new Janus.Windows.UI.CommandBars.UICommand("cmdMoveToList");
            this.cmdMoveEntireConversationToList = new Janus.Windows.UI.CommandBars.UICommand("cmdMoveEntireConversationToList");
            this.cmdResetGrid = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGrid");
            this.cmdDocMoreInfo = new Janus.Windows.UI.CommandBars.UICommand("cmdDocMoreInfo");
            this.cmdGridOptions = new Janus.Windows.UI.CommandBars.UICommand("cmdGridOptions");
            this.cmdResetGrid3 = new Janus.Windows.UI.CommandBars.UICommand("cmdResetGrid");
            this.cmdExpandGrid3 = new Janus.Windows.UI.CommandBars.UICommand("cmdExpandGrid");
            this.tsFilter3 = new Janus.Windows.UI.CommandBars.UICommand("tsFilter");
            this.cmdGroupBy3 = new Janus.Windows.UI.CommandBars.UICommand("cmdGroupBy");
            this.cmdFieldChooser3 = new Janus.Windows.UI.CommandBars.UICommand("cmdFieldChooser");
            this.cmdMoreInfoBF = new Janus.Windows.UI.CommandBars.UICommand("cmdMoreInfoBF");
            this.cmdRelatedRecord = new Janus.Windows.UI.CommandBars.UICommand("cmdRelatedRecord");
            this.cmdAssociateDoc = new Janus.Windows.UI.CommandBars.UICommand("cmdAssociateDoc");
            this.uiContextMenu2 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdCompleteBF1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCompleteBF");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.activityBFGridEX = new Janus.Windows.GridEX.GridEX();
            this.ucContactSelectBox1 = new LawMate.ucContactSelectBox();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.bFDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.bfCommentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ucBFOfficerId = new LawMate.ucContactSelectBox();
            this.ebBFPerson = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tabTK = new Janus.Windows.UI.Tab.UITabPage();
            this.ACTimeCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.finalUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.activityTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.postedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.sRPDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.hoursNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ucTimeslipOfficeId = new LawMate.ucOfficeSelectBox();
            this.calActivityTimeDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ebActivityTimeComment = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnNewTimeslip = new Janus.Windows.EditControls.UIButton();
            this.activityTimeGridEX = new Janus.Windows.GridEX.GridEX();
            this.mccTimeslipOfficerId = new LawMate.UserControls.ucMultiDropDown();
            this.ucTimeslipOfficerId = new LawMate.ucContactSelectBox();
            this.tabDisb = new Janus.Windows.UI.Tab.UITabPage();
            this.mccTaxRateId = new LawMate.UserControls.ucMultiDropDown();
            this.disbursementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.disbCommentCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.commentEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.finalUICheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.sRPDateCalendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.disbTaxExemptNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbTaxableNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbTypeucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.disbDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnNewDisb = new Janus.Windows.EditControls.UIButton();
            this.disbursementGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlCommunication = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlCommunicationContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBFs = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBFsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBilling = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBillingContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlDisbursement = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDisbursementContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlTopLeft = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopLeftContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlTopRight = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopRightContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.activityBFBindingSourceForGrid = new System.Windows.Forms.BindingSource(this.components);
            activityCommentLabel = new System.Windows.Forms.Label();
            atriumDB = new lmDatasets.atriumDB();
            codesDB1 = new lmDatasets.CodesDB();
            bFDateLabel = new System.Windows.Forms.Label();
            bFCommentLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            feesClaimedLabel = new System.Windows.Forms.Label();
            feesClaimedTaxLabel = new System.Windows.Forms.Label();
            hoursLabel = new System.Windows.Forms.Label();
            sRPDateLabel = new System.Windows.Forms.Label();
            priorityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(codesDB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolstrip)).BeginInit();
            this.pnlToolstrip.SuspendLayout();
            this.pnlToolstripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFailedToSend)).BeginInit();
            this.pnlFailedToSend.SuspendLayout();
            this.pnlFailedToSendContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMoveFloat)).BeginInit();
            this.pnlMoveFloat.SuspendLayout();
            this.pnlMoveFloatContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMoveActivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMoveList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlACTabs)).BeginInit();
            this.pnlACTabs.SuspendLayout();
            this.pnlACTabsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucACTabs)).BeginInit();
            this.ucACTabs.SuspendLayout();
            this.tabActivity.SuspendLayout();
            this.tabDocument.SuspendLayout();
            this.tabBF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).BeginInit();
            this.tabTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeGridEX)).BeginInit();
            this.tabDisb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommunication)).BeginInit();
            this.pnlCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBFs)).BeginInit();
            this.pnlBFs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBilling)).BeginInit();
            this.pnlBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDisbursement)).BeginInit();
            this.pnlDisbursement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopLeft)).BeginInit();
            this.pnlTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopRight)).BeginInit();
            this.pnlTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSourceForGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.activityBindingSource;
            // 
            // helpProvider1
            // 
            resources.ApplyResources(this.helpProvider1, "helpProvider1");
            // 
            // imageListBase
            // 
            this.imageListBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBase.ImageStream")));
            this.imageListBase.Images.SetKeyName(0, "find.gif");
            this.imageListBase.Images.SetKeyName(1, "cancel.gif");
            this.imageListBase.Images.SetKeyName(2, "delete.gif");
            this.imageListBase.Images.SetKeyName(3, "filter.gif");
            this.imageListBase.Images.SetKeyName(4, "shortcut.gif");
            this.imageListBase.Images.SetKeyName(5, "bo.gif");
            this.imageListBase.Images.SetKeyName(6, "browse.gif");
            this.imageListBase.Images.SetKeyName(7, "bs.gif");
            this.imageListBase.Images.SetKeyName(8, "cal.gif");
            this.imageListBase.Images.SetKeyName(9, "drafts.gif");
            this.imageListBase.Images.SetKeyName(10, "help.gif");
            this.imageListBase.Images.SetKeyName(11, "information.gif");
            this.imageListBase.Images.SetKeyName(12, "lang.gif");
            this.imageListBase.Images.SetKeyName(13, "moveFolder.gif");
            this.imageListBase.Images.SetKeyName(14, "msgS.gif");
            this.imageListBase.Images.SetKeyName(15, "newDoc.gif");
            this.imageListBase.Images.SetKeyName(16, "save.gif");
            this.imageListBase.Images.SetKeyName(17, "search.gif");
            this.imageListBase.Images.SetKeyName(18, "audit.gif");
            this.imageListBase.Images.SetKeyName(19, "DRedit.gif");
            this.imageListBase.Images.SetKeyName(20, "mail2.gif");
            this.imageListBase.Images.SetKeyName(21, "forward.gif");
            this.imageListBase.Images.SetKeyName(22, "reply.gif");
            this.imageListBase.Images.SetKeyName(23, "replyAll.gif");
            this.imageListBase.Images.SetKeyName(24, "views.gif");
            this.imageListBase.Images.SetKeyName(25, "sentItems.gif");
            this.imageListBase.Images.SetKeyName(26, "priorityNormal.gif");
            this.imageListBase.Images.SetKeyName(27, "priorityHigh.gif");
            this.imageListBase.Images.SetKeyName(28, "priorityUrgent.gif");
            this.imageListBase.Images.SetKeyName(29, "bf1.gif");
            this.imageListBase.Images.SetKeyName(30, "bf2.gif");
            this.imageListBase.Images.SetKeyName(31, "bf3.gif");
            this.imageListBase.Images.SetKeyName(32, "bf4.gif");
            this.imageListBase.Images.SetKeyName(33, "bf5.gif");
            this.imageListBase.Images.SetKeyName(34, "MarkasRead.gif");
            this.imageListBase.Images.SetKeyName(35, "checkbox.gif");
            this.imageListBase.Images.SetKeyName(36, "OfficeBF.gif");
            this.imageListBase.Images.SetKeyName(37, "DirectBF.gif");
            this.imageListBase.Images.SetKeyName(38, "RolesBF.gif");
            this.imageListBase.Images.SetKeyName(39, "groupBy.gif");
            this.imageListBase.Images.SetKeyName(40, "checkboxFalse.gif");
            this.imageListBase.Images.SetKeyName(41, "newBF.gif");
            this.imageListBase.Images.SetKeyName(42, "screen.gif");
            this.imageListBase.Images.SetKeyName(43, "new.gif");
            this.imageListBase.Images.SetKeyName(44, "fieldChooser.gif");
            this.imageListBase.Images.SetKeyName(45, "pnlExpand.gif");
            this.imageListBase.Images.SetKeyName(46, "panel.gif");
            this.imageListBase.Images.SetKeyName(47, "RecipientOfficer2.gif");
            // 
            // activityCommentLabel
            // 
            resources.ApplyResources(activityCommentLabel, "activityCommentLabel");
            activityCommentLabel.BackColor = System.Drawing.Color.Transparent;
            activityCommentLabel.Name = "activityCommentLabel";
            this.helpProvider1.SetShowHelp(activityCommentLabel, ((bool)(resources.GetObject("activityCommentLabel.ShowHelp"))));
            // 
            // atriumDB
            // 
            atriumDB.DataSetName = "atriumDB";
            atriumDB.EnforceConstraints = false;
            atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // codesDB1
            // 
            codesDB1.DataSetName = "CodesDB";
            codesDB1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bFDateLabel
            // 
            resources.ApplyResources(bFDateLabel, "bFDateLabel");
            bFDateLabel.BackColor = System.Drawing.Color.Transparent;
            bFDateLabel.Name = "bFDateLabel";
            this.helpProvider1.SetShowHelp(bFDateLabel, ((bool)(resources.GetObject("bFDateLabel.ShowHelp"))));
            // 
            // bFCommentLabel
            // 
            resources.ApplyResources(bFCommentLabel, "bFCommentLabel");
            bFCommentLabel.BackColor = System.Drawing.Color.Transparent;
            bFCommentLabel.Name = "bFCommentLabel";
            this.helpProvider1.SetShowHelp(bFCommentLabel, ((bool)(resources.GetObject("bFCommentLabel.ShowHelp"))));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            this.helpProvider1.SetShowHelp(label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            this.helpProvider1.SetShowHelp(label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            this.helpProvider1.SetShowHelp(label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            this.helpProvider1.SetShowHelp(label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            this.helpProvider1.SetShowHelp(label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            this.helpProvider1.SetShowHelp(label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Name = "label9";
            this.helpProvider1.SetShowHelp(label9, ((bool)(resources.GetObject("label9.ShowHelp"))));
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            this.helpProvider1.SetShowHelp(label10, ((bool)(resources.GetObject("label10.ShowHelp"))));
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Name = "label11";
            this.helpProvider1.SetShowHelp(label11, ((bool)(resources.GetObject("label11.ShowHelp"))));
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.Name = "label12";
            this.helpProvider1.SetShowHelp(label12, ((bool)(resources.GetObject("label12.ShowHelp"))));
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.BackColor = System.Drawing.Color.Transparent;
            label13.Name = "label13";
            this.helpProvider1.SetShowHelp(label13, ((bool)(resources.GetObject("label13.ShowHelp"))));
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.BackColor = System.Drawing.Color.Transparent;
            label14.Name = "label14";
            this.helpProvider1.SetShowHelp(label14, ((bool)(resources.GetObject("label14.ShowHelp"))));
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.BackColor = System.Drawing.Color.Transparent;
            label15.Name = "label15";
            this.helpProvider1.SetShowHelp(label15, ((bool)(resources.GetObject("label15.ShowHelp"))));
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.BackColor = System.Drawing.Color.Transparent;
            label16.Name = "label16";
            this.helpProvider1.SetShowHelp(label16, ((bool)(resources.GetObject("label16.ShowHelp"))));
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.BackColor = System.Drawing.Color.Transparent;
            label17.Name = "label17";
            this.helpProvider1.SetShowHelp(label17, ((bool)(resources.GetObject("label17.ShowHelp"))));
            // 
            // feesClaimedLabel
            // 
            resources.ApplyResources(feesClaimedLabel, "feesClaimedLabel");
            feesClaimedLabel.BackColor = System.Drawing.Color.Transparent;
            feesClaimedLabel.Name = "feesClaimedLabel";
            this.helpProvider1.SetShowHelp(feesClaimedLabel, ((bool)(resources.GetObject("feesClaimedLabel.ShowHelp"))));
            // 
            // feesClaimedTaxLabel
            // 
            resources.ApplyResources(feesClaimedTaxLabel, "feesClaimedTaxLabel");
            feesClaimedTaxLabel.BackColor = System.Drawing.Color.Transparent;
            feesClaimedTaxLabel.Name = "feesClaimedTaxLabel";
            this.helpProvider1.SetShowHelp(feesClaimedTaxLabel, ((bool)(resources.GetObject("feesClaimedTaxLabel.ShowHelp"))));
            // 
            // hoursLabel
            // 
            resources.ApplyResources(hoursLabel, "hoursLabel");
            hoursLabel.BackColor = System.Drawing.Color.Transparent;
            hoursLabel.Name = "hoursLabel";
            this.helpProvider1.SetShowHelp(hoursLabel, ((bool)(resources.GetObject("hoursLabel.ShowHelp"))));
            // 
            // sRPDateLabel
            // 
            resources.ApplyResources(sRPDateLabel, "sRPDateLabel");
            sRPDateLabel.BackColor = System.Drawing.Color.Transparent;
            sRPDateLabel.Name = "sRPDateLabel";
            this.helpProvider1.SetShowHelp(sRPDateLabel, ((bool)(resources.GetObject("sRPDateLabel.ShowHelp"))));
            // 
            // priorityLabel
            // 
            resources.ApplyResources(priorityLabel, "priorityLabel");
            priorityLabel.BackColor = System.Drawing.Color.Transparent;
            priorityLabel.Name = "priorityLabel";
            this.helpProvider1.SetShowHelp(priorityLabel, ((bool)(resources.GetObject("priorityLabel.ShowHelp"))));
            // 
            // activityBindingSource
            // 
            this.activityBindingSource.DataMember = "Activity";
            this.activityBindingSource.DataSource = atriumDB;
            this.activityBindingSource.CurrentChanged += new System.EventHandler(this.activityBindingSource_CurrentChanged);
            // 
            // disbDateLabel
            // 
            resources.ApplyResources(this.disbDateLabel, "disbDateLabel");
            this.disbDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.disbDateLabel.Name = "disbDateLabel";
            this.helpProvider1.SetShowHelp(this.disbDateLabel, ((bool)(resources.GetObject("disbDateLabel.ShowHelp"))));
            // 
            // disbTypeLabel
            // 
            resources.ApplyResources(this.disbTypeLabel, "disbTypeLabel");
            this.disbTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.disbTypeLabel.Name = "disbTypeLabel";
            this.helpProvider1.SetShowHelp(this.disbTypeLabel, ((bool)(resources.GetObject("disbTypeLabel.ShowHelp"))));
            // 
            // disbTaxableLabel
            // 
            resources.ApplyResources(this.disbTaxableLabel, "disbTaxableLabel");
            this.disbTaxableLabel.BackColor = System.Drawing.Color.Transparent;
            this.disbTaxableLabel.Name = "disbTaxableLabel";
            this.helpProvider1.SetShowHelp(this.disbTaxableLabel, ((bool)(resources.GetObject("disbTaxableLabel.ShowHelp"))));
            // 
            // disbTaxLabel
            // 
            resources.ApplyResources(this.disbTaxLabel, "disbTaxLabel");
            this.disbTaxLabel.BackColor = System.Drawing.Color.Transparent;
            this.disbTaxLabel.Name = "disbTaxLabel";
            this.helpProvider1.SetShowHelp(this.disbTaxLabel, ((bool)(resources.GetObject("disbTaxLabel.ShowHelp"))));
            // 
            // disbTaxExemptLabel
            // 
            resources.ApplyResources(this.disbTaxExemptLabel, "disbTaxExemptLabel");
            this.disbTaxExemptLabel.BackColor = System.Drawing.Color.Transparent;
            this.disbTaxExemptLabel.Name = "disbTaxExemptLabel";
            this.helpProvider1.SetShowHelp(this.disbTaxExemptLabel, ((bool)(resources.GetObject("disbTaxExemptLabel.ShowHelp"))));
            // 
            // sRPDateLabel1
            // 
            resources.ApplyResources(this.sRPDateLabel1, "sRPDateLabel1");
            this.sRPDateLabel1.BackColor = System.Drawing.Color.Transparent;
            this.sRPDateLabel1.Name = "sRPDateLabel1";
            this.helpProvider1.SetShowHelp(this.sRPDateLabel1, ((bool)(resources.GetObject("sRPDateLabel1.ShowHelp"))));
            // 
            // commentLabel
            // 
            resources.ApplyResources(this.commentLabel, "commentLabel");
            this.commentLabel.BackColor = System.Drawing.Color.Transparent;
            this.commentLabel.Name = "commentLabel";
            this.helpProvider1.SetShowHelp(this.commentLabel, ((bool)(resources.GetObject("commentLabel.ShowHelp"))));
            // 
            // activityBFBindingSource
            // 
            this.activityBFBindingSource.DataMember = "Activity_ActivityBF";
            this.activityBFBindingSource.DataSource = this.activityBindingSource;
            this.activityBFBindingSource.CurrentChanged += new System.EventHandler(this.activityBFBindingSource_CurrentChanged);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.BackColorResizeBar = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.uiPanelManager1.BackColorSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackColor = System.Drawing.Color.GhostWhite;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackColorGradient = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BlendGradient = 0.2F;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontName = "verdana";
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.DisabledFormatStyle.ForeColor = System.Drawing.Color.LightSlateGray;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8.75F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SlateBlue;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.HotFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiPanelManager1.DockingStyleMode = Janus.Windows.UI.Dock.DockingStyleMode.Standard;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 5;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlToolstrip.Id = new System.Guid("0c6ab740-1a8e-4798-8231-f919d4101dee");
            this.uiPanelManager1.Panels.Add(this.pnlToolstrip);
            this.pnlFailedToSend.Id = new System.Guid("8d4ac3f3-2251-4328-bd58-24711e70b550");
            this.uiPanelManager1.Panels.Add(this.pnlFailedToSend);
            this.pnlMoveFloat.Id = new System.Guid("ecc88a04-fa0c-40b0-b794-f68fe02ce760");
            this.uiPanelManager1.Panels.Add(this.pnlMoveFloat);
            this.pnlACTabs.Id = new System.Guid("76e86e30-3c09-4a32-99ac-44d585e214fe");
            this.uiPanelManager1.Panels.Add(this.pnlACTabs);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("0c6ab740-1a8e-4798-8231-f919d4101dee"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(778, 236), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("8d4ac3f3-2251-4328-bd58-24711e70b550"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(765, 99), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ecc88a04-fa0c-40b0-b794-f68fe02ce760"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(566, 280), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("76e86e30-3c09-4a32-99ac-44d585e214fe"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(778, 346), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("dfda71cf-ab3f-47c3-aca6-c56befdc2f01"), new System.Drawing.Point(110, 145), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e3f110de-6163-4ce2-9f98-11895e93a274"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ddb7cd2a-0f8f-4b59-b734-c0cd75555fac"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7915bdab-733d-4860-8369-72faa5ba24de"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0b04cb99-a0ca-4630-9bf2-db3ddf5440fb"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c3c29af3-af5c-4f04-a1c5-f26e3699372b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8daabda9-ee30-44d5-a4cc-ba4716c3635a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("06e5b083-a7a3-4541-ad66-c662e7b965c1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c94e8660-e166-42fe-b72b-97e571a2f1ba"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5806d003-3b87-4bd4-961b-7b17aab24880"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("35fc1573-e232-4099-9b80-de82c08950da"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("260c536c-3fef-4225-b426-11504e5d812b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0aaf8904-c08f-412b-aa62-143b08598489"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("14f8dc11-dd3d-492f-93f4-0c070d957e49"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f7d185a0-5328-40f3-9162-a6739b1f6e03"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0c6ab740-1a8e-4798-8231-f919d4101dee"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ec498fc5-65dd-4b09-a5cf-6dd87a61ac74"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f0f3b26e-51e7-4cb3-aaea-a5f7cdc7f5f6"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8d4ac3f3-2251-4328-bd58-24711e70b550"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ecc88a04-fa0c-40b0-b794-f68fe02ce760"), new System.Drawing.Point(20, 320), new System.Drawing.Size(524, 230), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e8c4edb6-18bb-4b43-ae7f-ade9ed3af61b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("76e86e30-3c09-4a32-99ac-44d585e214fe"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlToolstrip
            // 
            this.pnlToolstrip.AllowPanelDrop = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolstrip.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolstrip.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolstrip.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlToolstrip.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlToolstrip.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlToolstrip.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlToolstrip.InnerContainer = this.pnlToolstripContainer;
            resources.ApplyResources(this.pnlToolstrip, "pnlToolstrip");
            this.pnlToolstrip.Name = "pnlToolstrip";
            this.helpProvider1.SetShowHelp(this.pnlToolstrip, ((bool)(resources.GetObject("pnlToolstrip.ShowHelp"))));
            // 
            // pnlToolstripContainer
            // 
            this.pnlToolstripContainer.Controls.Add(this.activityGridEX);
            resources.ApplyResources(this.pnlToolstripContainer, "pnlToolstripContainer");
            this.pnlToolstripContainer.Name = "pnlToolstripContainer";
            this.helpProvider1.SetShowHelp(this.pnlToolstripContainer, ((bool)(resources.GetObject("pnlToolstripContainer.ShowHelp"))));
            // 
            // activityGridEX
            // 
            this.activityGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.activityGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.uiCommandManager1.SetContextMenu(this.activityGridEX, this.uiContextMenu1);
            this.activityGridEX.DataSource = this.activityBindingSource;
            resources.ApplyResources(this.activityGridEX, "activityGridEX");
            this.activityGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.activityGridEX.FlatBorderColor = System.Drawing.Color.Empty;
            this.activityGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.activityGridEX.GridLineColor = System.Drawing.SystemColors.ControlLight;
            this.activityGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityGridEX.GroupByBoxFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.activityGridEX.GroupByBoxFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(168)))));
            this.activityGridEX.GroupByBoxVisible = false;
            this.activityGridEX.GroupIndent = 24;
            this.activityGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.activityGridEX.ImageList = this.imageListBase;
            activityGridEX_Layout_0.DataSource = this.activityBindingSource;
            activityGridEX_Layout_0.IsCurrentLayout = true;
            activityGridEX_Layout_0.Key = "List";
            activityGridEX_Layout_0_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_0_Reference_0.Instance")));
            activityGridEX_Layout_0_Reference_1.Instance = ((object)(resources.GetObject("activityGridEX_Layout_0_Reference_1.Instance")));
            activityGridEX_Layout_0_Reference_2.Instance = ((object)(resources.GetObject("activityGridEX_Layout_0_Reference_2.Instance")));
            activityGridEX_Layout_0_Reference_3.Instance = ((object)(resources.GetObject("activityGridEX_Layout_0_Reference_3.Instance")));
            activityGridEX_Layout_0_Reference_4.Instance = ((object)(resources.GetObject("activityGridEX_Layout_0_Reference_4.Instance")));
            activityGridEX_Layout_0.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_0_Reference_0,
            activityGridEX_Layout_0_Reference_1,
            activityGridEX_Layout_0_Reference_2,
            activityGridEX_Layout_0_Reference_3,
            activityGridEX_Layout_0_Reference_4});
            resources.ApplyResources(activityGridEX_Layout_0, "activityGridEX_Layout_0");
            activityGridEX_Layout_1.Key = "Threaded";
            activityGridEX_Layout_1_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_1_Reference_0.Instance")));
            activityGridEX_Layout_1_Reference_1.Instance = ((object)(resources.GetObject("activityGridEX_Layout_1_Reference_1.Instance")));
            activityGridEX_Layout_1_Reference_2.Instance = ((object)(resources.GetObject("activityGridEX_Layout_1_Reference_2.Instance")));
            activityGridEX_Layout_1_Reference_3.Instance = ((object)(resources.GetObject("activityGridEX_Layout_1_Reference_3.Instance")));
            activityGridEX_Layout_1.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_1_Reference_0,
            activityGridEX_Layout_1_Reference_1,
            activityGridEX_Layout_1_Reference_2,
            activityGridEX_Layout_1_Reference_3});
            resources.ApplyResources(activityGridEX_Layout_1, "activityGridEX_Layout_1");
            activityGridEX_Layout_2.Description = "By Process";
            activityGridEX_Layout_2.Key = "Process";
            activityGridEX_Layout_2_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_2_Reference_0.Instance")));
            activityGridEX_Layout_2_Reference_1.Instance = ((object)(resources.GetObject("activityGridEX_Layout_2_Reference_1.Instance")));
            activityGridEX_Layout_2_Reference_2.Instance = ((object)(resources.GetObject("activityGridEX_Layout_2_Reference_2.Instance")));
            activityGridEX_Layout_2_Reference_3.Instance = ((object)(resources.GetObject("activityGridEX_Layout_2_Reference_3.Instance")));
            activityGridEX_Layout_2_Reference_4.Instance = ((object)(resources.GetObject("activityGridEX_Layout_2_Reference_4.Instance")));
            activityGridEX_Layout_2.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_2_Reference_0,
            activityGridEX_Layout_2_Reference_1,
            activityGridEX_Layout_2_Reference_2,
            activityGridEX_Layout_2_Reference_3,
            activityGridEX_Layout_2_Reference_4});
            resources.ApplyResources(activityGridEX_Layout_2, "activityGridEX_Layout_2");
            activityGridEX_Layout_3.Key = "ListBF";
            activityGridEX_Layout_3_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_3_Reference_0.Instance")));
            activityGridEX_Layout_3_Reference_1.Instance = ((object)(resources.GetObject("activityGridEX_Layout_3_Reference_1.Instance")));
            activityGridEX_Layout_3.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_3_Reference_0,
            activityGridEX_Layout_3_Reference_1});
            resources.ApplyResources(activityGridEX_Layout_3, "activityGridEX_Layout_3");
            activityGridEX_Layout_4.Key = "ListDisb";
            resources.ApplyResources(activityGridEX_Layout_4, "activityGridEX_Layout_4");
            activityGridEX_Layout_5.Key = "ListTK";
            activityGridEX_Layout_5_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_5_Reference_0.Instance")));
            activityGridEX_Layout_5_Reference_1.Instance = ((object)(resources.GetObject("activityGridEX_Layout_5_Reference_1.Instance")));
            activityGridEX_Layout_5.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_5_Reference_0,
            activityGridEX_Layout_5_Reference_1});
            resources.ApplyResources(activityGridEX_Layout_5, "activityGridEX_Layout_5");
            activityGridEX_Layout_6.Key = "ThreadedReverse";
            activityGridEX_Layout_6_Reference_0.Instance = ((object)(resources.GetObject("activityGridEX_Layout_6_Reference_0.Instance")));
            activityGridEX_Layout_6_Reference_1.Instance = ((object)(resources.GetObject("activityGridEX_Layout_6_Reference_1.Instance")));
            activityGridEX_Layout_6_Reference_2.Instance = ((object)(resources.GetObject("activityGridEX_Layout_6_Reference_2.Instance")));
            activityGridEX_Layout_6_Reference_3.Instance = ((object)(resources.GetObject("activityGridEX_Layout_6_Reference_3.Instance")));
            activityGridEX_Layout_6.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityGridEX_Layout_6_Reference_0,
            activityGridEX_Layout_6_Reference_1,
            activityGridEX_Layout_6_Reference_2,
            activityGridEX_Layout_6_Reference_3});
            resources.ApplyResources(activityGridEX_Layout_6, "activityGridEX_Layout_6");
            this.activityGridEX.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            activityGridEX_Layout_0,
            activityGridEX_Layout_1,
            activityGridEX_Layout_2,
            activityGridEX_Layout_3,
            activityGridEX_Layout_4,
            activityGridEX_Layout_5,
            activityGridEX_Layout_6});
            this.activityGridEX.Name = "activityGridEX";
            this.activityGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.activityGridEX.ScrollBarWidth = 18;
            this.activityGridEX.SettingsKey = "ucActivityActivity3";
            this.helpProvider1.SetShowHelp(this.activityGridEX, ((bool)(resources.GetObject("activityGridEX.ShowHelp"))));
            this.activityGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.activityGridEX.UseCompatibleTextRendering = false;
            this.activityGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityGridEX.ColumnVisibleChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityGridEX_ColumnVisibleChanged);
            this.activityGridEX.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.activityGridEX_RowDoubleClick);
            this.activityGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityGridEX_FormattingRow);
            this.activityGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityGridEX_LoadingRow);
            this.activityGridEX.SortKeysChanged += new System.EventHandler(this.activityGridEX_SortKeysChanged);
            this.activityGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.activityGridEX_CurrentCellChanging);
            this.activityGridEX.SelectionChanged += new System.EventHandler(this.activityGridEX_SelectionChanged);
            this.activityGridEX.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.activityGridEX_CurrentLayoutChanging);
            this.activityGridEX.EnabledChanged += new System.EventHandler(this.activityGridEX_EnabledChanged);
            // 
            // pnlFailedToSend
            // 
            this.pnlFailedToSend.AllowPanelDrop = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlFailedToSend.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlFailedToSend.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlFailedToSend.CaptionFormatStyle.FontSize = 8F;
            this.pnlFailedToSend.CaptionFormatStyle.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.pnlFailedToSend, "pnlFailedToSend");
            this.pnlFailedToSend.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlFailedToSend.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.UseFormatStyle;
            this.pnlFailedToSend.InnerContainer = this.pnlFailedToSendContainer;
            this.pnlFailedToSend.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.Window;
            this.pnlFailedToSend.Name = "pnlFailedToSend";
            this.helpProvider1.SetShowHelp(this.pnlFailedToSend, ((bool)(resources.GetObject("pnlFailedToSend.ShowHelp"))));
            // 
            // pnlFailedToSendContainer
            // 
            this.pnlFailedToSendContainer.Controls.Add(this.label2);
            this.pnlFailedToSendContainer.Controls.Add(this.lnkResend);
            this.pnlFailedToSendContainer.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlFailedToSendContainer, "pnlFailedToSendContainer");
            this.pnlFailedToSendContainer.Name = "pnlFailedToSendContainer";
            this.helpProvider1.SetShowHelp(this.pnlFailedToSendContainer, ((bool)(resources.GetObject("pnlFailedToSendContainer.ShowHelp"))));
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = global::LawMate.Properties.Resources.outlook2010_48x48;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // lnkResend
            // 
            resources.ApplyResources(this.lnkResend, "lnkResend");
            this.lnkResend.BackColor = System.Drawing.Color.Transparent;
            this.lnkResend.Image = global::LawMate.Properties.Resources.msgS;
            this.lnkResend.Name = "lnkResend";
            this.helpProvider1.SetShowHelp(this.lnkResend, ((bool)(resources.GetObject("lnkResend.ShowHelp"))));
            this.lnkResend.TabStop = true;
            this.lnkResend.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResend_LinkClicked);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // pnlMoveFloat
            // 
            this.pnlMoveFloat.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.pnlMoveFloat.AllowPanelDrag = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlMoveFloat.AllowPanelDrop = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlMoveFloat.CaptionDisplayMode = Janus.Windows.UI.Dock.PanelCaptionDisplayMode.Text;
            this.pnlMoveFloat.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.pnlMoveFloat.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlMoveFloat.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlMoveFloat.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.pnlMoveFloat, "pnlMoveFloat");
            this.pnlMoveFloat.FloatingLocation = new System.Drawing.Point(20, 320);
            this.pnlMoveFloat.FloatingSize = new System.Drawing.Size(524, 230);
            this.pnlMoveFloat.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.UseFormatStyle;
            this.pnlMoveFloat.InnerContainer = this.pnlMoveFloatContainer;
            this.pnlMoveFloat.Name = "pnlMoveFloat";
            this.helpProvider1.SetShowHelp(this.pnlMoveFloat, ((bool)(resources.GetObject("pnlMoveFloat.ShowHelp"))));
            // 
            // pnlMoveFloatContainer
            // 
            this.pnlMoveFloatContainer.Controls.Add(this.btnClearMoveList);
            this.pnlMoveFloatContainer.Controls.Add(this.btnRemoveFromMoveList);
            this.pnlMoveFloatContainer.Controls.Add(this.btnMoveList);
            this.pnlMoveFloatContainer.Controls.Add(this.grdMoveActivity);
            resources.ApplyResources(this.pnlMoveFloatContainer, "pnlMoveFloatContainer");
            this.pnlMoveFloatContainer.Name = "pnlMoveFloatContainer";
            this.helpProvider1.SetShowHelp(this.pnlMoveFloatContainer, ((bool)(resources.GetObject("pnlMoveFloatContainer.ShowHelp"))));
            // 
            // btnClearMoveList
            // 
            this.btnClearMoveList.Image = global::LawMate.Properties.Resources.cancel1;
            this.btnClearMoveList.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnClearMoveList, "btnClearMoveList");
            this.btnClearMoveList.Name = "btnClearMoveList";
            this.btnClearMoveList.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnClearMoveList, ((bool)(resources.GetObject("btnClearMoveList.ShowHelp"))));
            this.btnClearMoveList.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.btnClearMoveList.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnClearMoveList.Click += new System.EventHandler(this.btnClearMoveList_Click);
            // 
            // btnRemoveFromMoveList
            // 
            this.btnRemoveFromMoveList.Image = global::LawMate.Properties.Resources.delete1;
            this.btnRemoveFromMoveList.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnRemoveFromMoveList, "btnRemoveFromMoveList");
            this.btnRemoveFromMoveList.Name = "btnRemoveFromMoveList";
            this.btnRemoveFromMoveList.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnRemoveFromMoveList, ((bool)(resources.GetObject("btnRemoveFromMoveList.ShowHelp"))));
            this.btnRemoveFromMoveList.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.btnRemoveFromMoveList.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnRemoveFromMoveList.Click += new System.EventHandler(this.btnRemoveFromMoveList_Click);
            // 
            // btnMoveList
            // 
            this.btnMoveList.Image = global::LawMate.Properties.Resources.moveFolder;
            this.btnMoveList.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnMoveList, "btnMoveList");
            this.btnMoveList.Name = "btnMoveList";
            this.btnMoveList.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnMoveList, ((bool)(resources.GetObject("btnMoveList.ShowHelp"))));
            this.btnMoveList.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.btnMoveList.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnMoveList.Click += new System.EventHandler(this.btnMoveList_Click);
            // 
            // grdMoveActivity
            // 
            this.grdMoveActivity.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            resources.ApplyResources(this.grdMoveActivity, "grdMoveActivity");
            this.grdMoveActivity.DataSource = this.bindingSourceMoveList;
            grdMoveActivity_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdMoveActivity_DesignTimeLayout_Reference_0.Instance")));
            grdMoveActivity_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("grdMoveActivity_DesignTimeLayout_Reference_1.Instance")));
            grdMoveActivity_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdMoveActivity_DesignTimeLayout_Reference_0,
            grdMoveActivity_DesignTimeLayout_Reference_1});
            resources.ApplyResources(grdMoveActivity_DesignTimeLayout, "grdMoveActivity_DesignTimeLayout");
            this.grdMoveActivity.DesignTimeLayout = grdMoveActivity_DesignTimeLayout;
            this.grdMoveActivity.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.grdMoveActivity.GroupByBoxVisible = false;
            this.grdMoveActivity.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdMoveActivity.GroupRowFormatStyle.FontName = "arial";
            this.grdMoveActivity.GroupRowFormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.grdMoveActivity.Name = "grdMoveActivity";
            this.helpProvider1.SetShowHelp(this.grdMoveActivity, ((bool)(resources.GetObject("grdMoveActivity.ShowHelp"))));
            this.grdMoveActivity.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.grdMoveActivity.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdMoveActivity.SelectionChanged += new System.EventHandler(this.grdMoveActivity_SelectionChanged);
            this.grdMoveActivity.Click += new System.EventHandler(this.grdMoveActivity_Click);
            // 
            // pnlACTabs
            // 
            this.pnlACTabs.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlACTabs.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlACTabs.InnerContainer = this.pnlACTabsContainer;
            resources.ApplyResources(this.pnlACTabs, "pnlACTabs");
            this.pnlACTabs.Name = "pnlACTabs";
            this.helpProvider1.SetShowHelp(this.pnlACTabs, ((bool)(resources.GetObject("pnlACTabs.ShowHelp"))));
            // 
            // pnlACTabsContainer
            // 
            this.pnlACTabsContainer.Controls.Add(this.ucACTabs);
            resources.ApplyResources(this.pnlACTabsContainer, "pnlACTabsContainer");
            this.pnlACTabsContainer.Name = "pnlACTabsContainer";
            this.helpProvider1.SetShowHelp(this.pnlACTabsContainer, ((bool)(resources.GetObject("pnlACTabsContainer.ShowHelp"))));
            // 
            // ucACTabs
            // 
            this.ucACTabs.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ucACTabs, "ucACTabs");
            this.ucACTabs.Name = "ucACTabs";
            this.ucACTabs.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.ucACTabs, ((bool)(resources.GetObject("ucACTabs.ShowHelp"))));
            this.ucACTabs.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabActivity,
            this.tabDocument,
            this.tabBF,
            this.tabTK,
            this.tabDisb});
            this.ucACTabs.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.ucACTabs.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.ucACTabs.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.ucACTabs.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.ucACTabs.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ucACTabs.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            this.ucACTabs.SelectedTabChanged += new Janus.Windows.UI.Tab.TabEventHandler(this.ucACTabs_SelectedTabChanged);
            // 
            // tabActivity
            // 
            resources.ApplyResources(this.tabActivity, "tabActivity");
            this.tabActivity.Controls.Add(this.acCommentCounter);
            this.tabActivity.Controls.Add(this.editBox5);
            this.tabActivity.Controls.Add(this.activityCommentEditBox);
            this.tabActivity.Controls.Add(this.calendarCombo4);
            this.tabActivity.Controls.Add(this.editBox3);
            this.tabActivity.Controls.Add(this.calendarCombo2);
            this.tabActivity.Controls.Add(this.editBox2);
            this.tabActivity.Controls.Add(this.calendarCombo3);
            this.tabActivity.Controls.Add(this.ucContactSelectBox2);
            this.tabActivity.Controls.Add(this.editBox4);
            this.tabActivity.Controls.Add(label13);
            this.tabActivity.Controls.Add(label9);
            this.tabActivity.Controls.Add(label14);
            this.tabActivity.Controls.Add(activityCommentLabel);
            this.tabActivity.Controls.Add(label12);
            this.tabActivity.Controls.Add(label8);
            this.tabActivity.Controls.Add(label11);
            this.tabActivity.Controls.Add(label7);
            this.tabActivity.Controls.Add(label10);
            this.tabActivity.Name = "tabActivity";
            this.helpProvider1.SetShowHelp(this.tabActivity, ((bool)(resources.GetObject("tabActivity.ShowHelp"))));
            this.tabActivity.TabStop = true;
            // 
            // acCommentCounter
            // 
            this.acCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.acCommentCounter.DecimalDigits = 0;
            this.acCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.acCommentCounter, "acCommentCounter");
            this.acCommentCounter.MaxLength = 3;
            this.acCommentCounter.Name = "acCommentCounter";
            this.acCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.acCommentCounter, ((bool)(resources.GetObject("acCommentCounter.ShowHelp"))));
            this.acCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.acCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.acCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox5
            // 
            this.editBox5.BackColor = System.Drawing.SystemColors.Control;
            this.editBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "updateUser", true));
            resources.ApplyResources(this.editBox5, "editBox5");
            this.editBox5.Name = "editBox5";
            this.editBox5.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox5, ((bool)(resources.GetObject("editBox5.ShowHelp"))));
            this.editBox5.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // activityCommentEditBox
            // 
            this.activityCommentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "ActivityComment", true));
            resources.ApplyResources(this.activityCommentEditBox, "activityCommentEditBox");
            this.activityCommentEditBox.MaxLength = 255;
            this.activityCommentEditBox.Multiline = true;
            this.activityCommentEditBox.Name = "activityCommentEditBox";
            this.activityCommentEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.activityCommentEditBox, ((bool)(resources.GetObject("activityCommentEditBox.ShowHelp"))));
            this.activityCommentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityCommentEditBox.TextChanged += new System.EventHandler(this.activityCommentTextBox_TextChanged);
            // 
            // calendarCombo4
            // 
            this.calendarCombo4.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo4, "calendarCombo4");
            this.calendarCombo4.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBindingSource, "updateDate", true));
            // 
            // 
            // 
            this.calendarCombo4.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.calendarCombo4.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calendarCombo4.DropDownCalendar.Font")));
            this.calendarCombo4.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo4.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo4.Name = "calendarCombo4";
            this.calendarCombo4.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo4, ((bool)(resources.GetObject("calendarCombo4.ShowHelp"))));
            this.calendarCombo4.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // editBox3
            // 
            this.editBox3.BackColor = System.Drawing.SystemColors.Control;
            this.editBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "ActivityNameEng", true));
            resources.ApplyResources(this.editBox3, "editBox3");
            this.editBox3.Multiline = true;
            this.editBox3.Name = "editBox3";
            this.editBox3.ReadOnly = true;
            this.editBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.editBox3, ((bool)(resources.GetObject("editBox3.ShowHelp"))));
            this.editBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // calendarCombo2
            // 
            this.calendarCombo2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo2, "calendarCombo2");
            this.calendarCombo2.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBindingSource, "ActivityDate", true));
            this.calendarCombo2.DayIncrement = 0;
            // 
            // 
            // 
            this.calendarCombo2.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.calendarCombo2.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calendarCombo2.DropDownCalendar.Font")));
            this.calendarCombo2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.HourIncrement = 0;
            this.calendarCombo2.MonthIncrement = 0;
            this.calendarCombo2.Name = "calendarCombo2";
            this.calendarCombo2.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo2, ((bool)(resources.GetObject("calendarCombo2.ShowHelp"))));
            this.calendarCombo2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.YearIncrement = 0;
            // 
            // editBox2
            // 
            this.editBox2.BackColor = System.Drawing.SystemColors.Control;
            this.editBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "entryUser", true));
            resources.ApplyResources(this.editBox2, "editBox2");
            this.editBox2.Name = "editBox2";
            this.editBox2.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox2, ((bool)(resources.GetObject("editBox2.ShowHelp"))));
            this.editBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // calendarCombo3
            // 
            this.calendarCombo3.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo3, "calendarCombo3");
            this.calendarCombo3.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBindingSource, "entryDate", true));
            // 
            // 
            // 
            this.calendarCombo3.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.calendarCombo3.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calendarCombo3.DropDownCalendar.Font")));
            this.calendarCombo3.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo3.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo3.Name = "calendarCombo3";
            this.calendarCombo3.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo3, ((bool)(resources.GetObject("calendarCombo3.ShowHelp"))));
            this.calendarCombo3.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // ucContactSelectBox2
            // 
            this.ucContactSelectBox2.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucContactSelectBox2.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox2.CausesValidation = false;
            this.ucContactSelectBox2.ContactId = null;
            this.ucContactSelectBox2.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.activityBindingSource, "OfficerId", true));
            this.ucContactSelectBox2.FM = null;
            resources.ApplyResources(this.ucContactSelectBox2, "ucContactSelectBox2");
            this.ucContactSelectBox2.Name = "ucContactSelectBox2";
            this.ucContactSelectBox2.ReadOnly = true;
            this.ucContactSelectBox2.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucContactSelectBox2, ((bool)(resources.GetObject("ucContactSelectBox2.ShowHelp"))));
            this.ucContactSelectBox2.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // editBox4
            // 
            this.editBox4.BackColor = System.Drawing.SystemColors.Control;
            this.editBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBindingSource, "StepCode", true));
            resources.ApplyResources(this.editBox4, "editBox4");
            this.editBox4.Name = "editBox4";
            this.editBox4.ReadOnly = true;
            this.editBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.editBox4, ((bool)(resources.GetObject("editBox4.ShowHelp"))));
            this.editBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // tabDocument
            // 
            resources.ApplyResources(this.tabDocument, "tabDocument");
            this.tabDocument.Controls.Add(this.ucDocView1);
            this.tabDocument.Name = "tabDocument";
            this.helpProvider1.SetShowHelp(this.tabDocument, ((bool)(resources.GetObject("tabDocument.ShowHelp"))));
            this.tabDocument.TabStop = true;
            // 
            // ucDocView1
            // 
            this.ucDocView1.ActionToolbarView = LawMate.UserControls.DocCommandBar.Enable;
            this.ucDocView1.AllowActionToolbar = true;
            this.ucDocView1.AllowMetadata = true;
            this.ucDocView1.AllowMetadataUpdate = true;
            this.ucDocView1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocView1.DocDisplayType = LawMate.UserControls.DocViewDisplayType.MailHeader;
            resources.ApplyResources(this.ucDocView1, "ucDocView1");
            this.ucDocView1.ForceTextControl = true;
            this.ucDocView1.Name = "ucDocView1";
            this.ucDocView1.NoDocDisplayed = false;
            this.ucDocView1.ShowAttachmentPanel = true;
            this.helpProvider1.SetShowHelp(this.ucDocView1, ((bool)(resources.GetObject("ucDocView1.ShowHelp"))));
            this.ucDocView1.ShowMetadata = true;
            this.ucDocView1.ShowVersion = false;
            this.ucDocView1.TempFile = null;
            this.ucDocView1.TempFld = null;
            this.ucDocView1.DocLoaded += new LawMate.UserControls.DocLoadedEventHandler(this.ucDoc1_DocLoaded);
            this.ucDocView1.DocAction += new LawMate.UserControls.DocActionEventHandler(this.ucDoc1_DocAction);
            // 
            // tabBF
            // 
            resources.ApplyResources(this.tabBF, "tabBF");
            this.tabBF.Controls.Add(this.bfCommentCounter);
            this.tabBF.Controls.Add(this.priorityJComboBox);
            this.tabBF.Controls.Add(priorityLabel);
            this.tabBF.Controls.Add(this.btnNewBF);
            this.tabBF.Controls.Add(label3);
            this.tabBF.Controls.Add(this.ucContactSelectBox1);
            this.tabBF.Controls.Add(this.calendarCombo1);
            this.tabBF.Controls.Add(this.activityBFGridEX);
            this.tabBF.Controls.Add(label4);
            this.tabBF.Controls.Add(this.editBox1);
            this.tabBF.Controls.Add(label6);
            this.tabBF.Controls.Add(this.bFDateCalendarCombo);
            this.tabBF.Controls.Add(bFDateLabel);
            this.tabBF.Controls.Add(label5);
            this.tabBF.Controls.Add(bFCommentLabel);
            this.tabBF.Controls.Add(this.bfCommentEditBox);
            this.tabBF.Controls.Add(this.ucBFOfficerId);
            this.tabBF.Controls.Add(this.ebBFPerson);
            this.tabBF.Name = "tabBF";
            this.helpProvider1.SetShowHelp(this.tabBF, ((bool)(resources.GetObject("tabBF.ShowHelp"))));
            this.tabBF.TabStop = true;
            // 
            // bfCommentCounter
            // 
            this.bfCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bfCommentCounter.DecimalDigits = 0;
            this.bfCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.bfCommentCounter, "bfCommentCounter");
            this.bfCommentCounter.MaxLength = 3;
            this.bfCommentCounter.Name = "bfCommentCounter";
            this.bfCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.bfCommentCounter, ((bool)(resources.GetObject("bfCommentCounter.ShowHelp"))));
            this.bfCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.bfCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bfCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // priorityJComboBox
            // 
            resources.ApplyResources(this.priorityJComboBox, "priorityJComboBox");
            this.priorityJComboBox.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.priorityJComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.activityBFBindingSource, "Priority", true));
            this.priorityJComboBox.Name = "priorityJComboBox";
            this.helpProvider1.SetShowHelp(this.priorityJComboBox, ((bool)(resources.GetObject("priorityJComboBox.ShowHelp"))));
            this.priorityJComboBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // btnNewBF
            // 
            this.btnNewBF.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.btnNewBF.DropDownContextMenu = this.uiContextMenu3;
            this.btnNewBF.Image = global::LawMate.Properties.Resources.BFListCalendar;
            this.btnNewBF.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnNewBF, "btnNewBF");
            this.btnNewBF.Name = "btnNewBF";
            this.helpProvider1.SetShowHelp(this.btnNewBF, ((bool)(resources.GetObject("btnNewBF.ShowHelp"))));
            this.btnNewBF.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiContextMenu3
            // 
            this.uiContextMenu3.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.uiContextMenu3, "uiContextMenu3");
            this.uiContextMenu3.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu3.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiContextMenu3.Popup += new System.EventHandler(this.uiContextMenu3_Popup);
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar1});
            this.uiCommandManager1.CommandBarsFormatStyle.FontName = "tahoma";
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete,
            this.tsSave,
            this.tsView,
            this.tsViewList,
            this.tsViewThreadCom,
            this.tsViewThreadComReverse,
            this.tsViewThreadProcess,
            this.tsFilter,
            this.tsScreenTitle,
            this.tsAudit,
            this.tsViewListBF,
            this.tsEditmode,
            this.tsViewListDisb,
            this.tsViewListTK,
            this.tsMove,
            this.tsRefresh,
            this.tsReply,
            this.tsReplyAll,
            this.tsForward,
            this.tsConvertTo,
            this.tsRevertTo,
            this.tsNextSteps,
            this.cmdCompleteBF,
            this.tsMoreInfo,
            this.cmdReadOnly,
            this.tsActions,
            this.cmdGroupBy,
            this.cmdFieldChooser,
            this.cmdExpandGrid,
            this.cmdHelp,
            this.cmdEditFields,
            this.cmdFile,
            this.cmdView,
            this.cmdEdit,
            this.cmdMoveT,
            this.cmdMoveToList,
            this.cmdMoveEntireConversationToList,
            this.cmdResetGrid,
            this.cmdDocMoreInfo,
            this.cmdGridOptions,
            this.cmdMoreInfoBF,
            this.cmdRelatedRecord,
            this.cmdAssociateDoc});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1,
            this.uiContextMenu2,
            this.uiContextMenu3});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("e84fd5d2-99ef-4b3d-be32-c13755915580");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.KeepMergeSettings = false;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShortcutBehavior = Janus.Windows.UI.CommandBars.ShortcutBehavior.OnToolbarCommands;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsNextSteps1,
            this.tsConvertTo1,
            this.tsRevertTo1,
            this.Separator8,
            this.cmdAssociateDoc1,
            this.Separator12,
            this.tsReply1,
            this.tsReplyAll1,
            this.tsForward1,
            this.cmdMoveT2,
            this.Separator7,
            this.tsDelete2,
            this.Separator11,
            this.cmdHelp1});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiContextMenu1.Popup += new System.EventHandler(this.uiContextMenu1_Popup);
            // 
            // tsNextSteps1
            // 
            resources.ApplyResources(this.tsNextSteps1, "tsNextSteps1");
            this.tsNextSteps1.Name = "tsNextSteps1";
            // 
            // tsConvertTo1
            // 
            resources.ApplyResources(this.tsConvertTo1, "tsConvertTo1");
            this.tsConvertTo1.Name = "tsConvertTo1";
            // 
            // tsRevertTo1
            // 
            resources.ApplyResources(this.tsRevertTo1, "tsRevertTo1");
            this.tsRevertTo1.Name = "tsRevertTo1";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator8, "Separator8");
            this.Separator8.Name = "Separator8";
            // 
            // cmdAssociateDoc1
            // 
            resources.ApplyResources(this.cmdAssociateDoc1, "cmdAssociateDoc1");
            this.cmdAssociateDoc1.Name = "cmdAssociateDoc1";
            // 
            // Separator12
            // 
            this.Separator12.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator12, "Separator12");
            this.Separator12.Name = "Separator12";
            // 
            // tsReply1
            // 
            resources.ApplyResources(this.tsReply1, "tsReply1");
            this.tsReply1.Name = "tsReply1";
            // 
            // tsReplyAll1
            // 
            resources.ApplyResources(this.tsReplyAll1, "tsReplyAll1");
            this.tsReplyAll1.Name = "tsReplyAll1";
            // 
            // tsForward1
            // 
            resources.ApplyResources(this.tsForward1, "tsForward1");
            this.tsForward1.Name = "tsForward1";
            // 
            // cmdMoveT2
            // 
            resources.ApplyResources(this.cmdMoveT2, "cmdMoveT2");
            this.cmdMoveT2.Name = "cmdMoveT2";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // Separator11
            // 
            this.Separator11.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator11, "Separator11");
            this.Separator11.Name = "Separator11";
            // 
            // cmdHelp1
            // 
            resources.ApplyResources(this.cmdHelp1, "cmdHelp1");
            this.cmdHelp1.Name = "cmdHelp1";
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1,
            this.cmdView1,
            this.tsActions2});
            this.uiCommandBar2.FullRow = true;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            resources.ApplyResources(this.cmdEdit1, "cmdEdit1");
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // cmdView1
            // 
            resources.ApplyResources(this.cmdView1, "cmdView1");
            this.cmdView1.Name = "cmdView1";
            // 
            // tsActions2
            // 
            resources.ApplyResources(this.tsActions2, "tsActions2");
            this.tsActions2.Name = "tsActions2";
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator3,
            this.tsActions1,
            this.Separator9,
            this.tsSave1,
            this.tsDelete1,
            this.Separator5,
            this.tsMoreInfo1,
            this.Separator15,
            this.cmdGridOptions1,
            this.Separator6,
            this.tsView1,
            this.Separator4,
            this.tsAudit1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.MergeRowOrder = 2;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            this.uiCommandBar1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandBar1_CommandClick);
            // 
            // tsEditmode1
            // 
            resources.ApplyResources(this.tsEditmode1, "tsEditmode1");
            this.tsEditmode1.Name = "tsEditmode1";
            // 
            // tsScreenTitle1
            // 
            this.tsScreenTitle1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // tsActions1
            // 
            this.tsActions1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsActions1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.tsActions1, "tsActions1");
            this.tsActions1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.tsActions1.Name = "tsActions1";
            // 
            // Separator9
            // 
            this.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator9, "Separator9");
            this.Separator9.Name = "Separator9";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // tsMoreInfo1
            // 
            resources.ApplyResources(this.tsMoreInfo1, "tsMoreInfo1");
            this.tsMoreInfo1.Name = "tsMoreInfo1";
            // 
            // Separator15
            // 
            this.Separator15.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator15, "Separator15");
            this.Separator15.Name = "Separator15";
            // 
            // cmdGridOptions1
            // 
            resources.ApplyResources(this.cmdGridOptions1, "cmdGridOptions1");
            this.cmdGridOptions1.Name = "cmdGridOptions1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // tsView1
            // 
            this.tsView1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.tsView1, "tsView1");
            this.tsView1.Name = "tsView1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
            // 
            // tsDelete
            // 
            resources.ApplyResources(this.tsDelete, "tsDelete");
            this.tsDelete.Name = "tsDelete";
            // 
            // tsSave
            // 
            resources.ApplyResources(this.tsSave, "tsSave");
            this.tsSave.Name = "tsSave";
            // 
            // tsView
            // 
            this.tsView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsViewList1,
            this.tsViewListBF1,
            this.Separator13,
            this.tsViewThreadCom1,
            this.tsViewThreadComReverse1,
            this.Separator14,
            this.tsViewThreadProcess1});
            this.tsView.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsView, "tsView");
            this.tsView.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.tsView.Name = "tsView";
            // 
            // tsViewList1
            // 
            resources.ApplyResources(this.tsViewList1, "tsViewList1");
            this.tsViewList1.Name = "tsViewList1";
            // 
            // tsViewListBF1
            // 
            resources.ApplyResources(this.tsViewListBF1, "tsViewListBF1");
            this.tsViewListBF1.Name = "tsViewListBF1";
            // 
            // Separator13
            // 
            this.Separator13.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator13, "Separator13");
            this.Separator13.Name = "Separator13";
            // 
            // tsViewThreadCom1
            // 
            resources.ApplyResources(this.tsViewThreadCom1, "tsViewThreadCom1");
            this.tsViewThreadCom1.Name = "tsViewThreadCom1";
            // 
            // tsViewThreadComReverse1
            // 
            resources.ApplyResources(this.tsViewThreadComReverse1, "tsViewThreadComReverse1");
            this.tsViewThreadComReverse1.Name = "tsViewThreadComReverse1";
            // 
            // Separator14
            // 
            this.Separator14.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator14, "Separator14");
            this.Separator14.Name = "Separator14";
            // 
            // tsViewThreadProcess1
            // 
            resources.ApplyResources(this.tsViewThreadProcess1, "tsViewThreadProcess1");
            this.tsViewThreadProcess1.Name = "tsViewThreadProcess1";
            // 
            // tsViewList
            // 
            this.tsViewList.Checked = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.tsViewList, "tsViewList");
            this.tsViewList.Name = "tsViewList";
            // 
            // tsViewThreadCom
            // 
            resources.ApplyResources(this.tsViewThreadCom, "tsViewThreadCom");
            this.tsViewThreadCom.Name = "tsViewThreadCom";
            // 
            // tsViewThreadComReverse
            // 
            resources.ApplyResources(this.tsViewThreadComReverse, "tsViewThreadComReverse");
            this.tsViewThreadComReverse.Name = "tsViewThreadComReverse";
            // 
            // tsViewThreadProcess
            // 
            resources.ApplyResources(this.tsViewThreadProcess, "tsViewThreadProcess");
            this.tsViewThreadProcess.Name = "tsViewThreadProcess";
            // 
            // tsFilter
            // 
            this.tsFilter.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.tsFilter.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.tsFilter, "tsFilter");
            this.tsFilter.Name = "tsFilter";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // tsViewListBF
            // 
            resources.ApplyResources(this.tsViewListBF, "tsViewListBF");
            this.tsViewListBF.Name = "tsViewListBF";
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // tsViewListDisb
            // 
            resources.ApplyResources(this.tsViewListDisb, "tsViewListDisb");
            this.tsViewListDisb.Name = "tsViewListDisb";
            // 
            // tsViewListTK
            // 
            resources.ApplyResources(this.tsViewListTK, "tsViewListTK");
            this.tsViewListTK.Name = "tsViewListTK";
            // 
            // tsMove
            // 
            this.tsMove.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsMove, "tsMove");
            this.tsMove.Name = "tsMove";
            // 
            // tsRefresh
            // 
            resources.ApplyResources(this.tsRefresh, "tsRefresh");
            this.tsRefresh.Name = "tsRefresh";
            // 
            // tsReply
            // 
            resources.ApplyResources(this.tsReply, "tsReply");
            this.tsReply.Name = "tsReply";
            // 
            // tsReplyAll
            // 
            resources.ApplyResources(this.tsReplyAll, "tsReplyAll");
            this.tsReplyAll.Name = "tsReplyAll";
            // 
            // tsForward
            // 
            resources.ApplyResources(this.tsForward, "tsForward");
            this.tsForward.Name = "tsForward";
            // 
            // tsConvertTo
            // 
            resources.ApplyResources(this.tsConvertTo, "tsConvertTo");
            this.tsConvertTo.Name = "tsConvertTo";
            // 
            // tsRevertTo
            // 
            resources.ApplyResources(this.tsRevertTo, "tsRevertTo");
            this.tsRevertTo.Name = "tsRevertTo";
            // 
            // tsNextSteps
            // 
            resources.ApplyResources(this.tsNextSteps, "tsNextSteps");
            this.tsNextSteps.Name = "tsNextSteps";
            // 
            // cmdCompleteBF
            // 
            resources.ApplyResources(this.cmdCompleteBF, "cmdCompleteBF");
            this.cmdCompleteBF.Name = "cmdCompleteBF";
            // 
            // tsMoreInfo
            // 
            this.tsMoreInfo.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdRelatedRecord1,
            this.cmdDocMoreInfo3,
            this.cmdMoreInfoBF1});
            this.tsMoreInfo.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.tsMoreInfo, "tsMoreInfo");
            this.tsMoreInfo.Name = "tsMoreInfo";
            // 
            // cmdRelatedRecord1
            // 
            resources.ApplyResources(this.cmdRelatedRecord1, "cmdRelatedRecord1");
            this.cmdRelatedRecord1.Name = "cmdRelatedRecord1";
            // 
            // cmdDocMoreInfo3
            // 
            resources.ApplyResources(this.cmdDocMoreInfo3, "cmdDocMoreInfo3");
            this.cmdDocMoreInfo3.Name = "cmdDocMoreInfo3";
            // 
            // cmdMoreInfoBF1
            // 
            resources.ApplyResources(this.cmdMoreInfoBF1, "cmdMoreInfoBF1");
            this.cmdMoreInfoBF1.Name = "cmdMoreInfoBF1";
            // 
            // cmdReadOnly
            // 
            this.cmdReadOnly.Alignment = Janus.Windows.UI.CommandBars.CommandAlignment.Far;
            this.cmdReadOnly.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdReadOnly.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.cmdReadOnly.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdReadOnly, "cmdReadOnly");
            this.cmdReadOnly.Name = "cmdReadOnly";
            this.cmdReadOnly.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.cmdReadOnly.StateStyles.FormatStyle.FontName = "tahoma";
            this.cmdReadOnly.StateStyles.FormatStyle.FontSize = 9F;
            // 
            // tsActions
            // 
            this.tsActions.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAssociateDoc2,
            this.Separator2,
            this.tsReply2,
            this.tsReplyAll2,
            this.tsForward2,
            this.Separator10,
            this.cmdMoveT1});
            resources.ApplyResources(this.tsActions, "tsActions");
            this.tsActions.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.tsActions.Name = "tsActions";
            // 
            // cmdAssociateDoc2
            // 
            resources.ApplyResources(this.cmdAssociateDoc2, "cmdAssociateDoc2");
            this.cmdAssociateDoc2.Name = "cmdAssociateDoc2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsReply2
            // 
            resources.ApplyResources(this.tsReply2, "tsReply2");
            this.tsReply2.Name = "tsReply2";
            // 
            // tsReplyAll2
            // 
            resources.ApplyResources(this.tsReplyAll2, "tsReplyAll2");
            this.tsReplyAll2.Name = "tsReplyAll2";
            // 
            // tsForward2
            // 
            resources.ApplyResources(this.tsForward2, "tsForward2");
            this.tsForward2.Name = "tsForward2";
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator10, "Separator10");
            this.Separator10.Name = "Separator10";
            // 
            // cmdMoveT1
            // 
            resources.ApplyResources(this.cmdMoveT1, "cmdMoveT1");
            this.cmdMoveT1.Name = "cmdMoveT1";
            // 
            // cmdGroupBy
            // 
            this.cmdGroupBy.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdGroupBy, "cmdGroupBy");
            this.cmdGroupBy.Name = "cmdGroupBy";
            // 
            // cmdFieldChooser
            // 
            resources.ApplyResources(this.cmdFieldChooser, "cmdFieldChooser");
            this.cmdFieldChooser.Name = "cmdFieldChooser";
            // 
            // cmdExpandGrid
            // 
            this.cmdExpandGrid.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdExpandGrid.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdExpandGrid, "cmdExpandGrid");
            this.cmdExpandGrid.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdExpandGrid.Name = "cmdExpandGrid";
            // 
            // cmdHelp
            // 
            resources.ApplyResources(this.cmdHelp, "cmdHelp");
            this.cmdHelp.Name = "cmdHelp";
            // 
            // cmdEditFields
            // 
            this.cmdEditFields.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdEditFields, "cmdEditFields");
            this.cmdEditFields.Name = "cmdEditFields";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdDocMoreInfo1,
            this.cmdResetGrid1,
            this.cmdExpandGrid2,
            this.tsFilter2,
            this.cmdGroupBy2,
            this.cmdFieldChooser2,
            this.Separator1,
            this.tsView2});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView.Name = "cmdView";
            // 
            // cmdDocMoreInfo1
            // 
            resources.ApplyResources(this.cmdDocMoreInfo1, "cmdDocMoreInfo1");
            this.cmdDocMoreInfo1.Name = "cmdDocMoreInfo1";
            // 
            // cmdResetGrid1
            // 
            resources.ApplyResources(this.cmdResetGrid1, "cmdResetGrid1");
            this.cmdResetGrid1.Name = "cmdResetGrid1";
            // 
            // cmdExpandGrid2
            // 
            resources.ApplyResources(this.cmdExpandGrid2, "cmdExpandGrid2");
            this.cmdExpandGrid2.Name = "cmdExpandGrid2";
            // 
            // tsFilter2
            // 
            resources.ApplyResources(this.tsFilter2, "tsFilter2");
            this.tsFilter2.Name = "tsFilter2";
            // 
            // cmdGroupBy2
            // 
            resources.ApplyResources(this.cmdGroupBy2, "cmdGroupBy2");
            this.cmdGroupBy2.Name = "cmdGroupBy2";
            // 
            // cmdFieldChooser2
            // 
            resources.ApplyResources(this.cmdFieldChooser2, "cmdFieldChooser2");
            this.cmdFieldChooser2.Name = "cmdFieldChooser2";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // tsView2
            // 
            resources.ApplyResources(this.tsView2, "tsView2");
            this.tsView2.Name = "tsView2";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete3});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete3
            // 
            resources.ApplyResources(this.tsDelete3, "tsDelete3");
            this.tsDelete3.Name = "tsDelete3";
            // 
            // cmdMoveT
            // 
            this.cmdMoveT.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsMove1,
            this.cmdMoveToList1,
            this.cmdMoveEntireConversationToList1});
            resources.ApplyResources(this.cmdMoveT, "cmdMoveT");
            this.cmdMoveT.Name = "cmdMoveT";
            // 
            // tsMove1
            // 
            resources.ApplyResources(this.tsMove1, "tsMove1");
            this.tsMove1.Name = "tsMove1";
            // 
            // cmdMoveToList1
            // 
            resources.ApplyResources(this.cmdMoveToList1, "cmdMoveToList1");
            this.cmdMoveToList1.Name = "cmdMoveToList1";
            // 
            // cmdMoveEntireConversationToList1
            // 
            resources.ApplyResources(this.cmdMoveEntireConversationToList1, "cmdMoveEntireConversationToList1");
            this.cmdMoveEntireConversationToList1.Name = "cmdMoveEntireConversationToList1";
            // 
            // cmdMoveToList
            // 
            resources.ApplyResources(this.cmdMoveToList, "cmdMoveToList");
            this.cmdMoveToList.Name = "cmdMoveToList";
            // 
            // cmdMoveEntireConversationToList
            // 
            resources.ApplyResources(this.cmdMoveEntireConversationToList, "cmdMoveEntireConversationToList");
            this.cmdMoveEntireConversationToList.Name = "cmdMoveEntireConversationToList";
            // 
            // cmdResetGrid
            // 
            resources.ApplyResources(this.cmdResetGrid, "cmdResetGrid");
            this.cmdResetGrid.Name = "cmdResetGrid";
            // 
            // cmdDocMoreInfo
            // 
            resources.ApplyResources(this.cmdDocMoreInfo, "cmdDocMoreInfo");
            this.cmdDocMoreInfo.Name = "cmdDocMoreInfo";
            // 
            // cmdGridOptions
            // 
            this.cmdGridOptions.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdResetGrid3,
            this.cmdExpandGrid3,
            this.tsFilter3,
            this.cmdGroupBy3,
            this.cmdFieldChooser3});
            this.cmdGridOptions.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdGridOptions, "cmdGridOptions");
            this.cmdGridOptions.Name = "cmdGridOptions";
            // 
            // cmdResetGrid3
            // 
            resources.ApplyResources(this.cmdResetGrid3, "cmdResetGrid3");
            this.cmdResetGrid3.Name = "cmdResetGrid3";
            // 
            // cmdExpandGrid3
            // 
            resources.ApplyResources(this.cmdExpandGrid3, "cmdExpandGrid3");
            this.cmdExpandGrid3.Name = "cmdExpandGrid3";
            // 
            // tsFilter3
            // 
            resources.ApplyResources(this.tsFilter3, "tsFilter3");
            this.tsFilter3.Name = "tsFilter3";
            // 
            // cmdGroupBy3
            // 
            resources.ApplyResources(this.cmdGroupBy3, "cmdGroupBy3");
            this.cmdGroupBy3.Name = "cmdGroupBy3";
            // 
            // cmdFieldChooser3
            // 
            resources.ApplyResources(this.cmdFieldChooser3, "cmdFieldChooser3");
            this.cmdFieldChooser3.Name = "cmdFieldChooser3";
            // 
            // cmdMoreInfoBF
            // 
            resources.ApplyResources(this.cmdMoreInfoBF, "cmdMoreInfoBF");
            this.cmdMoreInfoBF.Name = "cmdMoreInfoBF";
            // 
            // cmdRelatedRecord
            // 
            resources.ApplyResources(this.cmdRelatedRecord, "cmdRelatedRecord");
            this.cmdRelatedRecord.Name = "cmdRelatedRecord";
            // 
            // cmdAssociateDoc
            // 
            resources.ApplyResources(this.cmdAssociateDoc, "cmdAssociateDoc");
            this.cmdAssociateDoc.Name = "cmdAssociateDoc";
            // 
            // uiContextMenu2
            // 
            this.uiContextMenu2.CommandManager = this.uiCommandManager1;
            this.uiContextMenu2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdCompleteBF1});
            resources.ApplyResources(this.uiContextMenu2, "uiContextMenu2");
            this.uiContextMenu2.Popup += new System.EventHandler(this.uiContextMenu2_Popup);
            // 
            // cmdCompleteBF1
            // 
            resources.ApplyResources(this.cmdCompleteBF1, "cmdCompleteBF1");
            this.cmdCompleteBF1.Name = "cmdCompleteBF1";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            this.helpProvider1.SetShowHelp(this.LeftRebar1, ((bool)(resources.GetObject("LeftRebar1.ShowHelp"))));
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            this.helpProvider1.SetShowHelp(this.RightRebar1, ((bool)(resources.GetObject("RightRebar1.ShowHelp"))));
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // activityBFGridEX
            // 
            this.activityBFGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.activityBFGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityBFGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.activityBFGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.activityBFGridEX.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.uiCommandManager1.SetContextMenu(this.activityBFGridEX, this.uiContextMenu2);
            this.activityBFGridEX.DataSource = this.activityBFBindingSource;
            activityBFGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("activityBFGridEX_DesignTimeLayout_Reference_0.Instance")));
            activityBFGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityBFGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(activityBFGridEX_DesignTimeLayout, "activityBFGridEX_DesignTimeLayout");
            this.activityBFGridEX.DesignTimeLayout = activityBFGridEX_DesignTimeLayout;
            this.activityBFGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.activityBFGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.activityBFGridEX, "activityBFGridEX");
            this.activityBFGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.activityBFGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityBFGridEX.GroupByBoxVisible = false;
            this.activityBFGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.activityBFGridEX.ImageList = this.imageListBase;
            this.activityBFGridEX.Name = "activityBFGridEX";
            this.activityBFGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.activityBFGridEX.SettingsKey = "ucActivityBF";
            this.helpProvider1.SetShowHelp(this.activityBFGridEX, ((bool)(resources.GetObject("activityBFGridEX.ShowHelp"))));
            this.activityBFGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.activityBFGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityBFGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.activityBFGridEX.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.activityBFGridEX_DeletingRecord);
            this.activityBFGridEX.ColumnVisibleChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityBFGridEX_ColumnVisibleChanged);
            this.activityBFGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityBFGridEX_FormattingRow);
            this.activityBFGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityBFGridEX_LoadingRow);
            this.activityBFGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityBFGridEX_ColumnButtonClick);
            this.activityBFGridEX.SelectionChanged += new System.EventHandler(this.activityBFGridEX_SelectionChanged);
            this.activityBFGridEX.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.activityBFGridEX_CurrentLayoutChanging);
            // 
            // ucContactSelectBox1
            // 
            this.ucContactSelectBox1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucContactSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucContactSelectBox1.ContactId = null;
            this.ucContactSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.activityBFBindingSource, "CompletedByID", true));
            this.ucContactSelectBox1.FM = null;
            resources.ApplyResources(this.ucContactSelectBox1, "ucContactSelectBox1");
            this.ucContactSelectBox1.Name = "ucContactSelectBox1";
            this.ucContactSelectBox1.ReadOnly = true;
            this.ucContactSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucContactSelectBox1, ((bool)(resources.GetObject("ucContactSelectBox1.ShowHelp"))));
            this.ucContactSelectBox1.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBFBindingSource, "CompletedDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.calendarCombo1.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calendarCombo1.DropDownCalendar.Font")));
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo1, ((bool)(resources.GetObject("calendarCombo1.ShowHelp"))));
            this.calendarCombo1.Value = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.Multiline = true;
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.editBox1, ((bool)(resources.GetObject("editBox1.ShowHelp"))));
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // bFDateCalendarCombo
            // 
            resources.ApplyResources(this.bFDateCalendarCombo, "bFDateCalendarCombo");
            this.bFDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityBFBindingSource, "BFDate", true));
            this.bFDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.bFDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.bFDateCalendarCombo.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("bFDateCalendarCombo.DropDownCalendar.Font")));
            this.bFDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bFDateCalendarCombo.MonthIncrement = 0;
            this.bFDateCalendarCombo.Name = "bFDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.bFDateCalendarCombo, ((bool)(resources.GetObject("bFDateCalendarCombo.ShowHelp"))));
            this.bFDateCalendarCombo.Value = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.bFDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.bFDateCalendarCombo.YearIncrement = 0;
            this.bFDateCalendarCombo.ValueChanged += new System.EventHandler(this.bFDateCalendarCombo_ValueChanged);
            // 
            // bfCommentEditBox
            // 
            this.bfCommentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityBFBindingSource, "BFComment", true));
            resources.ApplyResources(this.bfCommentEditBox, "bfCommentEditBox");
            this.bfCommentEditBox.Multiline = true;
            this.bfCommentEditBox.Name = "bfCommentEditBox";
            this.bfCommentEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.bfCommentEditBox, ((bool)(resources.GetObject("bfCommentEditBox.ShowHelp"))));
            this.bfCommentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.bfCommentEditBox.TextChanged += new System.EventHandler(this.activityCommentTextBox_TextChanged);
            // 
            // ucBFOfficerId
            // 
            this.ucBFOfficerId.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucBFOfficerId.BackColor = System.Drawing.Color.Transparent;
            this.ucBFOfficerId.ContactId = null;
            this.ucBFOfficerId.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.activityBFBindingSource, "BFOfficerID", true));
            this.ucBFOfficerId.FM = null;
            resources.ApplyResources(this.ucBFOfficerId, "ucBFOfficerId");
            this.ucBFOfficerId.Name = "ucBFOfficerId";
            this.ucBFOfficerId.ReadOnly = false;
            this.ucBFOfficerId.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucBFOfficerId, ((bool)(resources.GetObject("ucBFOfficerId.ShowHelp"))));
            this.ucBFOfficerId.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // ebBFPerson
            // 
            this.ebBFPerson.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ebBFPerson, "ebBFPerson");
            this.ebBFPerson.Name = "ebBFPerson";
            this.ebBFPerson.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.ebBFPerson, ((bool)(resources.GetObject("ebBFPerson.ShowHelp"))));
            this.ebBFPerson.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // tabTK
            // 
            resources.ApplyResources(this.tabTK, "tabTK");
            this.tabTK.Controls.Add(this.ACTimeCommentCounter);
            this.tabTK.Controls.Add(this.finalUICheckBox);
            this.tabTK.Controls.Add(this.postedUICheckBox);
            this.tabTK.Controls.Add(sRPDateLabel);
            this.tabTK.Controls.Add(this.sRPDateCalendarCombo);
            this.tabTK.Controls.Add(hoursLabel);
            this.tabTK.Controls.Add(this.hoursNumericEditBox);
            this.tabTK.Controls.Add(feesClaimedTaxLabel);
            this.tabTK.Controls.Add(this.feesClaimedTaxNumericEditBox);
            this.tabTK.Controls.Add(feesClaimedLabel);
            this.tabTK.Controls.Add(this.feesClaimedNumericEditBox);
            this.tabTK.Controls.Add(this.ucTimeslipOfficeId);
            this.tabTK.Controls.Add(label15);
            this.tabTK.Controls.Add(this.calActivityTimeDate);
            this.tabTK.Controls.Add(label16);
            this.tabTK.Controls.Add(label17);
            this.tabTK.Controls.Add(this.ebActivityTimeComment);
            this.tabTK.Controls.Add(this.btnNewTimeslip);
            this.tabTK.Controls.Add(this.activityTimeGridEX);
            this.tabTK.Controls.Add(this.mccTimeslipOfficerId);
            this.tabTK.Controls.Add(this.ucTimeslipOfficerId);
            this.tabTK.Name = "tabTK";
            this.helpProvider1.SetShowHelp(this.tabTK, ((bool)(resources.GetObject("tabTK.ShowHelp"))));
            this.tabTK.TabStop = true;
            // 
            // ACTimeCommentCounter
            // 
            this.ACTimeCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ACTimeCommentCounter.DecimalDigits = 0;
            this.ACTimeCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.ACTimeCommentCounter, "ACTimeCommentCounter");
            this.ACTimeCommentCounter.MaxLength = 3;
            this.ACTimeCommentCounter.Name = "ACTimeCommentCounter";
            this.ACTimeCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.ACTimeCommentCounter, ((bool)(resources.GetObject("ACTimeCommentCounter.ShowHelp"))));
            this.ACTimeCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ACTimeCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ACTimeCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // finalUICheckBox
            // 
            this.finalUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.finalUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.finalUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityTimeBindingSource, "Final", true));
            resources.ApplyResources(this.finalUICheckBox, "finalUICheckBox");
            this.finalUICheckBox.Name = "finalUICheckBox";
            this.helpProvider1.SetShowHelp(this.finalUICheckBox, ((bool)(resources.GetObject("finalUICheckBox.ShowHelp"))));
            this.finalUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // activityTimeBindingSource
            // 
            this.activityTimeBindingSource.DataMember = "ActivityActivityTime";
            this.activityTimeBindingSource.DataSource = this.activityBindingSource;
            this.activityTimeBindingSource.CurrentChanged += new System.EventHandler(this.activityTimeBindingSource_CurrentChanged);
            // 
            // postedUICheckBox
            // 
            this.postedUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.postedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.postedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityTimeBindingSource, "Posted", true));
            resources.ApplyResources(this.postedUICheckBox, "postedUICheckBox");
            this.postedUICheckBox.Name = "postedUICheckBox";
            this.helpProvider1.SetShowHelp(this.postedUICheckBox, ((bool)(resources.GetObject("postedUICheckBox.ShowHelp"))));
            this.postedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // sRPDateCalendarCombo
            // 
            this.sRPDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.sRPDateCalendarCombo, "sRPDateCalendarCombo");
            this.sRPDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityTimeBindingSource, "SRPDate", true));
            // 
            // 
            // 
            this.sRPDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.sRPDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPDateCalendarCombo.Name = "sRPDateCalendarCombo";
            this.sRPDateCalendarCombo.Nullable = true;
            this.sRPDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sRPDateCalendarCombo, ((bool)(resources.GetObject("sRPDateCalendarCombo.ShowHelp"))));
            this.sRPDateCalendarCombo.Value = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.sRPDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // hoursNumericEditBox
            // 
            this.hoursNumericEditBox.ButtonImage = ((System.Drawing.Image)(resources.GetObject("hoursNumericEditBox.ButtonImage")));
            this.hoursNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.activityTimeBindingSource, "Hours", true));
            this.hoursNumericEditBox.DecimalDigits = 1;
            resources.ApplyResources(this.hoursNumericEditBox, "hoursNumericEditBox");
            this.hoursNumericEditBox.Name = "hoursNumericEditBox";
            this.helpProvider1.SetShowHelp(this.hoursNumericEditBox, ((bool)(resources.GetObject("hoursNumericEditBox.ShowHelp"))));
            this.hoursNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.hoursNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.hoursNumericEditBox.ButtonClick += new System.EventHandler(this.hoursNumericEditBox_ButtonClick);
            // 
            // feesClaimedTaxNumericEditBox
            // 
            this.feesClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.activityTimeBindingSource, "FeesClaimedTax", true));
            this.feesClaimedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesClaimedTaxNumericEditBox, "feesClaimedTaxNumericEditBox");
            this.feesClaimedTaxNumericEditBox.Name = "feesClaimedTaxNumericEditBox";
            this.feesClaimedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesClaimedTaxNumericEditBox, ((bool)(resources.GetObject("feesClaimedTaxNumericEditBox.ShowHelp"))));
            this.feesClaimedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesClaimedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesClaimedNumericEditBox
            // 
            this.feesClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.activityTimeBindingSource, "FeesClaimed", true));
            this.feesClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesClaimedNumericEditBox, "feesClaimedNumericEditBox");
            this.feesClaimedNumericEditBox.Name = "feesClaimedNumericEditBox";
            this.feesClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesClaimedNumericEditBox, ((bool)(resources.GetObject("feesClaimedNumericEditBox.ShowHelp"))));
            this.feesClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucTimeslipOfficeId
            // 
            this.ucTimeslipOfficeId.AtMng = null;
            this.ucTimeslipOfficeId.BackColor = System.Drawing.Color.Transparent;
            this.ucTimeslipOfficeId.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.activityTimeBindingSource, "OfficeId", true));
            resources.ApplyResources(this.ucTimeslipOfficeId, "ucTimeslipOfficeId");
            this.ucTimeslipOfficeId.Name = "ucTimeslipOfficeId";
            this.ucTimeslipOfficeId.OfficeId = null;
            this.ucTimeslipOfficeId.ReadOnly = true;
            this.ucTimeslipOfficeId.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucTimeslipOfficeId, ((bool)(resources.GetObject("ucTimeslipOfficeId.ShowHelp"))));
            // 
            // calActivityTimeDate
            // 
            resources.ApplyResources(this.calActivityTimeDate, "calActivityTimeDate");
            this.calActivityTimeDate.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.activityTimeBindingSource, "StartTime", true));
            this.calActivityTimeDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calActivityTimeDate.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.calActivityTimeDate.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("calActivityTimeDate.DropDownCalendar.Font")));
            this.calActivityTimeDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calActivityTimeDate.MonthIncrement = 0;
            this.calActivityTimeDate.Name = "calActivityTimeDate";
            this.helpProvider1.SetShowHelp(this.calActivityTimeDate, ((bool)(resources.GetObject("calActivityTimeDate.ShowHelp"))));
            this.calActivityTimeDate.Value = new System.DateTime(2014, 12, 1, 0, 0, 0, 0);
            this.calActivityTimeDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calActivityTimeDate.YearIncrement = 0;
            // 
            // ebActivityTimeComment
            // 
            this.ebActivityTimeComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.activityTimeBindingSource, "Comment", true));
            resources.ApplyResources(this.ebActivityTimeComment, "ebActivityTimeComment");
            this.ebActivityTimeComment.Multiline = true;
            this.ebActivityTimeComment.Name = "ebActivityTimeComment";
            this.ebActivityTimeComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.ebActivityTimeComment, ((bool)(resources.GetObject("ebActivityTimeComment.ShowHelp"))));
            this.ebActivityTimeComment.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebActivityTimeComment.TextChanged += new System.EventHandler(this.activityCommentTextBox_TextChanged);
            // 
            // btnNewTimeslip
            // 
            this.btnNewTimeslip.Image = global::LawMate.Properties.Resources.clock1;
            this.btnNewTimeslip.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnNewTimeslip, "btnNewTimeslip");
            this.btnNewTimeslip.Name = "btnNewTimeslip";
            this.helpProvider1.SetShowHelp(this.btnNewTimeslip, ((bool)(resources.GetObject("btnNewTimeslip.ShowHelp"))));
            this.btnNewTimeslip.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnNewTimeslip.Click += new System.EventHandler(this.btnNewTimeslip_Click);
            // 
            // activityTimeGridEX
            // 
            this.activityTimeGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.activityTimeGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.activityTimeGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.activityTimeGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.activityTimeGridEX.DataSource = this.activityTimeBindingSource;
            activityTimeGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("activityTimeGridEX_DesignTimeLayout_Reference_0.Instance")));
            activityTimeGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("activityTimeGridEX_DesignTimeLayout_Reference_1.Instance")));
            activityTimeGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            activityTimeGridEX_DesignTimeLayout_Reference_0,
            activityTimeGridEX_DesignTimeLayout_Reference_1});
            resources.ApplyResources(activityTimeGridEX_DesignTimeLayout, "activityTimeGridEX_DesignTimeLayout");
            this.activityTimeGridEX.DesignTimeLayout = activityTimeGridEX_DesignTimeLayout;
            this.activityTimeGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.activityTimeGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.activityTimeGridEX, "activityTimeGridEX");
            this.activityTimeGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.activityTimeGridEX.GroupByBoxVisible = false;
            this.activityTimeGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.activityTimeGridEX.Name = "activityTimeGridEX";
            this.activityTimeGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow;
            this.activityTimeGridEX.SettingsKey = "ucActivityBilling";
            this.helpProvider1.SetShowHelp(this.activityTimeGridEX, ((bool)(resources.GetObject("activityTimeGridEX.ShowHelp"))));
            this.activityTimeGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.activityTimeGridEX.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.activityTimeGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.activityTimeGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.activityTimeGridEX.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.activityTimeGridEX_DeletingRecord);
            this.activityTimeGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.activityTimeGridEX_FormattingRow);
            this.activityTimeGridEX.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityTimeGridEX_CellUpdated);
            this.activityTimeGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.activityTimeGridEX_ColumnButtonClick);
            this.activityTimeGridEX.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.activityTimeGridEX_CurrentLayoutChanging);
            // 
            // mccTimeslipOfficerId
            // 
            this.mccTimeslipOfficerId.BackColor = System.Drawing.Color.Transparent;
            this.mccTimeslipOfficerId.Column1 = "officercode";
            resources.ApplyResources(this.mccTimeslipOfficerId, "mccTimeslipOfficerId");
            this.mccTimeslipOfficerId.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccTimeslipOfficerId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.activityTimeBindingSource, "OfficerId", true));
            this.mccTimeslipOfficerId.DataSource = null;
            this.mccTimeslipOfficerId.DDColumn1Visible = true;
            this.mccTimeslipOfficerId.DropDownColumn1Width = 100;
            this.mccTimeslipOfficerId.DropDownColumn2Width = 300;
            this.mccTimeslipOfficerId.Name = "mccTimeslipOfficerId";
            this.mccTimeslipOfficerId.ReadOnly = false;
            this.mccTimeslipOfficerId.ReqColor = System.Drawing.SystemColors.Window;
            this.mccTimeslipOfficerId.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccTimeslipOfficerId, ((bool)(resources.GetObject("mccTimeslipOfficerId.ShowHelp"))));
            this.mccTimeslipOfficerId.ValueMember = "officerid";
            // 
            // ucTimeslipOfficerId
            // 
            this.ucTimeslipOfficerId.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucTimeslipOfficerId.BackColor = System.Drawing.Color.Transparent;
            this.ucTimeslipOfficerId.ContactId = null;
            this.ucTimeslipOfficerId.DataBindings.Add(new System.Windows.Forms.Binding("ContactId", this.activityTimeBindingSource, "OfficerId", true));
            this.ucTimeslipOfficerId.FM = null;
            resources.ApplyResources(this.ucTimeslipOfficerId, "ucTimeslipOfficerId");
            this.ucTimeslipOfficerId.Name = "ucTimeslipOfficerId";
            this.ucTimeslipOfficerId.ReadOnly = true;
            this.ucTimeslipOfficerId.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucTimeslipOfficerId, ((bool)(resources.GetObject("ucTimeslipOfficerId.ShowHelp"))));
            this.ucTimeslipOfficerId.WLQuery = LawMate.WorkloadQuery.NotApplicable;
            // 
            // tabDisb
            // 
            resources.ApplyResources(this.tabDisb, "tabDisb");
            this.tabDisb.Controls.Add(this.mccTaxRateId);
            this.tabDisb.Controls.Add(this.disbCommentCounter);
            this.tabDisb.Controls.Add(this.commentEditBox);
            this.tabDisb.Controls.Add(this.finalUICheckBox1);
            this.tabDisb.Controls.Add(this.sRPDateCalendarCombo1);
            this.tabDisb.Controls.Add(this.disbTaxExemptNumericEditBox);
            this.tabDisb.Controls.Add(this.disbTaxNumericEditBox);
            this.tabDisb.Controls.Add(this.disbTaxableLabel);
            this.tabDisb.Controls.Add(this.disbTaxableNumericEditBox);
            this.tabDisb.Controls.Add(this.disbTypeucMultiDropDown);
            this.tabDisb.Controls.Add(this.disbDateLabel);
            this.tabDisb.Controls.Add(this.disbDateCalendarCombo);
            this.tabDisb.Controls.Add(this.btnNewDisb);
            this.tabDisb.Controls.Add(this.disbursementGridEX);
            this.tabDisb.Controls.Add(this.commentLabel);
            this.tabDisb.Controls.Add(this.disbTaxExemptLabel);
            this.tabDisb.Controls.Add(this.disbTypeLabel);
            this.tabDisb.Controls.Add(this.sRPDateLabel1);
            this.tabDisb.Controls.Add(this.disbTaxLabel);
            this.tabDisb.Name = "tabDisb";
            this.helpProvider1.SetShowHelp(this.tabDisb, ((bool)(resources.GetObject("tabDisb.ShowHelp"))));
            this.tabDisb.TabStop = true;
            // 
            // mccTaxRateId
            // 
            this.mccTaxRateId.BackColor = System.Drawing.Color.Transparent;
            this.mccTaxRateId.Column1 = "TaxRateId";
            resources.ApplyResources(this.mccTaxRateId, "mccTaxRateId");
            this.mccTaxRateId.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.mccTaxRateId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.disbursementBindingSource, "TaxRateId", true));
            this.mccTaxRateId.DataSource = null;
            this.mccTaxRateId.DDColumn1Visible = false;
            this.mccTaxRateId.DropDownColumn1Width = 100;
            this.mccTaxRateId.DropDownColumn2Width = 150;
            this.mccTaxRateId.Name = "mccTaxRateId";
            this.mccTaxRateId.ReadOnly = true;
            this.mccTaxRateId.ReqColor = System.Drawing.SystemColors.Control;
            this.mccTaxRateId.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccTaxRateId, ((bool)(resources.GetObject("mccTaxRateId.ShowHelp"))));
            this.mccTaxRateId.ValueMember = "TaxRateId";
            // 
            // disbursementBindingSource
            // 
            this.disbursementBindingSource.DataMember = "ActivityDisbursement";
            this.disbursementBindingSource.DataSource = this.activityBindingSource;
            this.disbursementBindingSource.CurrentChanged += new System.EventHandler(this.disbursementBindingSource_CurrentChanged);
            // 
            // disbCommentCounter
            // 
            this.disbCommentCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.disbCommentCounter.DecimalDigits = 0;
            this.disbCommentCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.disbCommentCounter, "disbCommentCounter");
            this.disbCommentCounter.MaxLength = 3;
            this.disbCommentCounter.Name = "disbCommentCounter";
            this.disbCommentCounter.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbCommentCounter, ((bool)(resources.GetObject("disbCommentCounter.ShowHelp"))));
            this.disbCommentCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.disbCommentCounter.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.disbCommentCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // commentEditBox
            // 
            this.commentEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.disbursementBindingSource, "Comment", true));
            resources.ApplyResources(this.commentEditBox, "commentEditBox");
            this.commentEditBox.Multiline = true;
            this.commentEditBox.Name = "commentEditBox";
            this.commentEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.commentEditBox, ((bool)(resources.GetObject("commentEditBox.ShowHelp"))));
            this.commentEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.commentEditBox.TextChanged += new System.EventHandler(this.activityCommentTextBox_TextChanged);
            // 
            // finalUICheckBox1
            // 
            this.finalUICheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.finalUICheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.finalUICheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.disbursementBindingSource, "Final", true));
            resources.ApplyResources(this.finalUICheckBox1, "finalUICheckBox1");
            this.finalUICheckBox1.Name = "finalUICheckBox1";
            this.helpProvider1.SetShowHelp(this.finalUICheckBox1, ((bool)(resources.GetObject("finalUICheckBox1.ShowHelp"))));
            // 
            // sRPDateCalendarCombo1
            // 
            this.sRPDateCalendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.sRPDateCalendarCombo1, "sRPDateCalendarCombo1");
            this.sRPDateCalendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.disbursementBindingSource, "SRPDate", true));
            // 
            // 
            // 
            this.sRPDateCalendarCombo1.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.sRPDateCalendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.sRPDateCalendarCombo1.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.sRPDateCalendarCombo1.Name = "sRPDateCalendarCombo1";
            this.sRPDateCalendarCombo1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sRPDateCalendarCombo1, ((bool)(resources.GetObject("sRPDateCalendarCombo1.ShowHelp"))));
            this.sRPDateCalendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // disbTaxExemptNumericEditBox
            // 
            this.disbTaxExemptNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.disbursementBindingSource, "DisbTaxExempt", true));
            this.disbTaxExemptNumericEditBox.DecimalDigits = 2;
            this.disbTaxExemptNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbTaxExemptNumericEditBox, "disbTaxExemptNumericEditBox");
            this.disbTaxExemptNumericEditBox.Name = "disbTaxExemptNumericEditBox";
            this.helpProvider1.SetShowHelp(this.disbTaxExemptNumericEditBox, ((bool)(resources.GetObject("disbTaxExemptNumericEditBox.ShowHelp"))));
            this.disbTaxExemptNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbTaxExemptNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbTaxNumericEditBox
            // 
            this.disbTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.disbursementBindingSource, "DisbTax", true));
            this.disbTaxNumericEditBox.DecimalDigits = 2;
            this.disbTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbTaxNumericEditBox, "disbTaxNumericEditBox");
            this.disbTaxNumericEditBox.Name = "disbTaxNumericEditBox";
            this.disbTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbTaxNumericEditBox, ((bool)(resources.GetObject("disbTaxNumericEditBox.ShowHelp"))));
            this.disbTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbTaxableNumericEditBox
            // 
            this.disbTaxableNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.disbursementBindingSource, "DisbTaxable", true));
            this.disbTaxableNumericEditBox.DecimalDigits = 2;
            this.disbTaxableNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbTaxableNumericEditBox, "disbTaxableNumericEditBox");
            this.disbTaxableNumericEditBox.Name = "disbTaxableNumericEditBox";
            this.helpProvider1.SetShowHelp(this.disbTaxableNumericEditBox, ((bool)(resources.GetObject("disbTaxableNumericEditBox.ShowHelp"))));
            this.disbTaxableNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbTaxableNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbTypeucMultiDropDown
            // 
            this.disbTypeucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.disbTypeucMultiDropDown.Column1 = "DisbursementType";
            resources.ApplyResources(this.disbTypeucMultiDropDown, "disbTypeucMultiDropDown");
            this.disbTypeucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.disbTypeucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.disbursementBindingSource, "DisbType", true));
            this.disbTypeucMultiDropDown.DataSource = null;
            this.disbTypeucMultiDropDown.DDColumn1Visible = true;
            this.disbTypeucMultiDropDown.DropDownColumn1Width = 80;
            this.disbTypeucMultiDropDown.DropDownColumn2Width = 340;
            this.disbTypeucMultiDropDown.Name = "disbTypeucMultiDropDown";
            this.disbTypeucMultiDropDown.ReadOnly = false;
            this.disbTypeucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.disbTypeucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.disbTypeucMultiDropDown, ((bool)(resources.GetObject("disbTypeucMultiDropDown.ShowHelp"))));
            this.disbTypeucMultiDropDown.ValueMember = "DisbursementType";
            // 
            // disbDateCalendarCombo
            // 
            resources.ApplyResources(this.disbDateCalendarCombo, "disbDateCalendarCombo");
            this.disbDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.disbursementBindingSource, "DisbDate", true));
            this.disbDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.disbDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2016, 12, 1, 0, 0, 0, 0);
            this.disbDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.disbDateCalendarCombo.MonthIncrement = 0;
            this.disbDateCalendarCombo.Name = "disbDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.disbDateCalendarCombo, ((bool)(resources.GetObject("disbDateCalendarCombo.ShowHelp"))));
            this.disbDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.disbDateCalendarCombo.YearIncrement = 0;
            // 
            // btnNewDisb
            // 
            this.btnNewDisb.Image = global::LawMate.Properties.Resources.disb;
            this.btnNewDisb.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            resources.ApplyResources(this.btnNewDisb, "btnNewDisb");
            this.btnNewDisb.Name = "btnNewDisb";
            this.helpProvider1.SetShowHelp(this.btnNewDisb, ((bool)(resources.GetObject("btnNewDisb.ShowHelp"))));
            this.btnNewDisb.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnNewDisb.Click += new System.EventHandler(this.btnNewDisb_Click);
            // 
            // disbursementGridEX
            // 
            this.disbursementGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.disbursementGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.disbursementGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.disbursementGridEX.DataSource = this.disbursementBindingSource;
            disbursementGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("disbursementGridEX_DesignTimeLayout_Reference_0.Instance")));
            disbursementGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("disbursementGridEX_DesignTimeLayout_Reference_1.Instance")));
            disbursementGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            disbursementGridEX_DesignTimeLayout_Reference_0,
            disbursementGridEX_DesignTimeLayout_Reference_1});
            resources.ApplyResources(disbursementGridEX_DesignTimeLayout, "disbursementGridEX_DesignTimeLayout");
            this.disbursementGridEX.DesignTimeLayout = disbursementGridEX_DesignTimeLayout;
            this.disbursementGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.disbursementGridEX, "disbursementGridEX");
            this.disbursementGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.disbursementGridEX.GroupByBoxVisible = false;
            this.disbursementGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.disbursementGridEX.Name = "disbursementGridEX";
            this.disbursementGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.disbursementGridEX.SettingsKey = "ucActivityDisbursements";
            this.helpProvider1.SetShowHelp(this.disbursementGridEX, ((bool)(resources.GetObject("disbursementGridEX.ShowHelp"))));
            this.disbursementGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.disbursementGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.disbursementGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.disbursementGridEX.DeletingRecord += new Janus.Windows.GridEX.RowActionCancelEventHandler(this.disbursementGridEX_DeletingRecord);
            this.disbursementGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.disbursementGridEX_ColumnButtonClick);
            this.disbursementGridEX.CurrentLayoutChanging += new System.ComponentModel.CancelEventHandler(this.disbursementGridEX_CurrentLayoutChanging);
            // 
            // pnlCommunication
            // 
            this.pnlCommunication.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlCommunication.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlCommunication, "pnlCommunication");
            this.pnlCommunication.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlCommunication.InnerContainer = this.pnlCommunicationContainer;
            this.pnlCommunication.Name = "pnlCommunication";
            this.helpProvider1.SetShowHelp(this.pnlCommunication, ((bool)(resources.GetObject("pnlCommunication.ShowHelp"))));
            // 
            // pnlCommunicationContainer
            // 
            resources.ApplyResources(this.pnlCommunicationContainer, "pnlCommunicationContainer");
            this.pnlCommunicationContainer.Name = "pnlCommunicationContainer";
            this.helpProvider1.SetShowHelp(this.pnlCommunicationContainer, ((bool)(resources.GetObject("pnlCommunicationContainer.ShowHelp"))));
            // 
            // pnlBFs
            // 
            this.pnlBFs.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlBFs, "pnlBFs");
            this.pnlBFs.InnerContainer = this.pnlBFsContainer;
            this.pnlBFs.Name = "pnlBFs";
            this.helpProvider1.SetShowHelp(this.pnlBFs, ((bool)(resources.GetObject("pnlBFs.ShowHelp"))));
            // 
            // pnlBFsContainer
            // 
            resources.ApplyResources(this.pnlBFsContainer, "pnlBFsContainer");
            this.pnlBFsContainer.Name = "pnlBFsContainer";
            this.helpProvider1.SetShowHelp(this.pnlBFsContainer, ((bool)(resources.GetObject("pnlBFsContainer.ShowHelp"))));
            // 
            // pnlBilling
            // 
            this.pnlBilling.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlBilling, "pnlBilling");
            this.pnlBilling.InnerContainer = this.pnlBillingContainer;
            this.pnlBilling.Name = "pnlBilling";
            this.helpProvider1.SetShowHelp(this.pnlBilling, ((bool)(resources.GetObject("pnlBilling.ShowHelp"))));
            // 
            // pnlBillingContainer
            // 
            resources.ApplyResources(this.pnlBillingContainer, "pnlBillingContainer");
            this.pnlBillingContainer.Name = "pnlBillingContainer";
            this.helpProvider1.SetShowHelp(this.pnlBillingContainer, ((bool)(resources.GetObject("pnlBillingContainer.ShowHelp"))));
            // 
            // pnlDisbursement
            // 
            this.pnlDisbursement.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDisbursement.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlDisbursement, "pnlDisbursement");
            this.pnlDisbursement.InnerContainer = this.pnlDisbursementContainer;
            this.pnlDisbursement.Name = "pnlDisbursement";
            this.helpProvider1.SetShowHelp(this.pnlDisbursement, ((bool)(resources.GetObject("pnlDisbursement.ShowHelp"))));
            // 
            // pnlDisbursementContainer
            // 
            resources.ApplyResources(this.pnlDisbursementContainer, "pnlDisbursementContainer");
            this.pnlDisbursementContainer.Name = "pnlDisbursementContainer";
            this.helpProvider1.SetShowHelp(this.pnlDisbursementContainer, ((bool)(resources.GetObject("pnlDisbursementContainer.ShowHelp"))));
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTopLeft.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTopLeft.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlTopLeft.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlTopLeft.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTopLeft.InnerContainer = this.pnlTopLeftContainer;
            resources.ApplyResources(this.pnlTopLeft, "pnlTopLeft");
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.helpProvider1.SetShowHelp(this.pnlTopLeft, ((bool)(resources.GetObject("pnlTopLeft.ShowHelp"))));
            // 
            // pnlTopLeftContainer
            // 
            resources.ApplyResources(this.pnlTopLeftContainer, "pnlTopLeftContainer");
            this.pnlTopLeftContainer.Name = "pnlTopLeftContainer";
            this.helpProvider1.SetShowHelp(this.pnlTopLeftContainer, ((bool)(resources.GetObject("pnlTopLeftContainer.ShowHelp"))));
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTopRight.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTopRight.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTopRight.InnerContainer = this.pnlTopRightContainer;
            resources.ApplyResources(this.pnlTopRight, "pnlTopRight");
            this.pnlTopRight.Name = "pnlTopRight";
            this.helpProvider1.SetShowHelp(this.pnlTopRight, ((bool)(resources.GetObject("pnlTopRight.ShowHelp"))));
            // 
            // pnlTopRightContainer
            // 
            resources.ApplyResources(this.pnlTopRightContainer, "pnlTopRightContainer");
            this.pnlTopRightContainer.Name = "pnlTopRightContainer";
            this.helpProvider1.SetShowHelp(this.pnlTopRightContainer, ((bool)(resources.GetObject("pnlTopRightContainer.ShowHelp"))));
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.activityBFBindingSource;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.DataSource = this.activityTimeBindingSource;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            this.errorProvider4.DataSource = this.disbursementBindingSource;
            // 
            // activityBFBindingSourceForGrid
            // 
            this.activityBFBindingSourceForGrid.DataSource = this.activityBFBindingSource;
            // 
            // ucActivity
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlACTabs);
            this.Controls.Add(this.pnlMoveFloat);
            this.Controls.Add(this.pnlFailedToSend);
            this.Controls.Add(this.pnlToolstrip);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucActivity";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(codesDB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlToolstrip)).EndInit();
            this.pnlToolstrip.ResumeLayout(false);
            this.pnlToolstripContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.activityGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFailedToSend)).EndInit();
            this.pnlFailedToSend.ResumeLayout(false);
            this.pnlFailedToSendContainer.ResumeLayout(false);
            this.pnlFailedToSendContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMoveFloat)).EndInit();
            this.pnlMoveFloat.ResumeLayout(false);
            this.pnlMoveFloatContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMoveActivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMoveList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlACTabs)).EndInit();
            this.pnlACTabs.ResumeLayout(false);
            this.pnlACTabsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucACTabs)).EndInit();
            this.ucACTabs.ResumeLayout(false);
            this.tabActivity.ResumeLayout(false);
            this.tabActivity.PerformLayout();
            this.tabDocument.ResumeLayout(false);
            this.tabBF.ResumeLayout(false);
            this.tabBF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.activityBFGridEX)).EndInit();
            this.tabTK.ResumeLayout(false);
            this.tabTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityTimeGridEX)).EndInit();
            this.tabDisb.ResumeLayout(false);
            this.tabDisb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommunication)).EndInit();
            this.pnlCommunication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBFs)).EndInit();
            this.pnlBFs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBilling)).EndInit();
            this.pnlBilling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDisbursement)).EndInit();
            this.pnlDisbursement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopLeft)).EndInit();
            this.pnlTopLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopRight)).EndInit();
            this.pnlTopRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activityBFBindingSourceForGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource activityBindingSource;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.GridEX.GridEX activityGridEX;
        private Janus.Windows.UI.Dock.UIPanel pnlBFs;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBFsContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBilling;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBillingContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlCommunication;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlCommunicationContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlDisbursement;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDisbursementContainer;
        private Janus.Windows.GridEX.GridEX activityBFGridEX;
        private System.Windows.Forms.BindingSource activityBFBindingSource;
        private Janus.Windows.GridEX.GridEX activityTimeGridEX;
        private System.Windows.Forms.BindingSource activityTimeBindingSource;
        private Janus.Windows.GridEX.GridEX disbursementGridEX;
        private System.Windows.Forms.BindingSource disbursementBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Janus.Windows.UI.Dock.UIPanel pnlTopLeft;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopLeftContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlTopRight;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopRightContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlToolstrip;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlToolstripContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsView;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsViewList;
        private Janus.Windows.UI.CommandBars.UICommand tsViewList1;
        private Janus.Windows.UI.CommandBars.UICommand tsViewThreadCom1;
        private Janus.Windows.UI.CommandBars.UICommand tsViewThreadProcess1;
        private Janus.Windows.UI.CommandBars.UICommand tsViewThreadCom;
        private Janus.Windows.UI.CommandBars.UICommand tsViewThreadProcess;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand tsView1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsViewListBF;
        private Janus.Windows.UI.CommandBars.UICommand tsViewListBF1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand tsViewListDisb;
        private Janus.Windows.UI.CommandBars.UICommand tsViewListTK;
        private Janus.Windows.UI.CommandBars.UICommand tsMove;
        private Janus.Windows.UI.CommandBars.UICommand tsRefresh;
        private Janus.Windows.UI.CommandBars.UICommand tsReply;
        private Janus.Windows.UI.CommandBars.UICommand tsReplyAll;
        private Janus.Windows.UI.CommandBars.UICommand tsForward;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand tsConvertTo;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand tsConvertTo1;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand tsRevertTo;
        private Janus.Windows.UI.CommandBars.UICommand tsNextSteps;
        private Janus.Windows.UI.CommandBars.UICommand tsNextSteps1;
        private Janus.Windows.UI.CommandBars.UICommand tsRevertTo1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCompleteBF;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCompleteBF1;
        private Janus.Windows.UI.CommandBars.UICommand tsMoreInfo;
        
        private Janus.Windows.UI.CommandBars.UICommand cmdReadOnly;
        private Janus.Windows.UI.CommandBars.UICommand tsActions;
        private Janus.Windows.UI.CommandBars.UICommand tsReply2;
        private Janus.Windows.UI.CommandBars.UICommand tsReplyAll2;
        private Janus.Windows.UI.CommandBars.UICommand tsForward2;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroupBy;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser;
        private Janus.Windows.UI.CommandBars.UICommand cmdExpandGrid;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp;
        private Janus.Windows.UI.CommandBars.UICommand Separator11;
        private Janus.Windows.UI.CommandBars.UICommand cmdHelp1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEditFields;
        private Janus.Windows.CalendarCombo.CalendarCombo bFDateCalendarCombo;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdExpandGrid2;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter2;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroupBy2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser2;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsView2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand tsActions2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete3;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand Separator9;
        private Janus.Windows.UI.CommandBars.UICommand tsActions1;
        private Janus.Windows.UI.Dock.UIPanel pnlFailedToSend;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlFailedToSendContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkResend;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.UI.CommandBars.UICommand tsReply1;
        private Janus.Windows.UI.CommandBars.UICommand tsReplyAll1;
        private Janus.Windows.UI.CommandBars.UICommand tsForward1;
        private Janus.Windows.UI.Dock.UIPanel pnlMoveFloat;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlMoveFloatContainer;
        private Janus.Windows.EditControls.UIButton btnMoveList;
        private Janus.Windows.GridEX.GridEX grdMoveActivity;
        private Janus.Windows.EditControls.UIButton btnRemoveFromMoveList;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoveT1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoveT;
        private Janus.Windows.UI.CommandBars.UICommand tsMove1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoveToList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoveToList;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoveEntireConversationToList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoveEntireConversationToList;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoveT2;
        private System.Windows.Forms.BindingSource bindingSourceMoveList;
        private Janus.Windows.EditControls.UIButton btnClearMoveList;
        private Janus.Windows.UI.CommandBars.UICommand tsViewThreadComReverse1;
        private Janus.Windows.UI.CommandBars.UICommand tsViewThreadComReverse;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGrid;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGrid1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocMoreInfo1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocMoreInfo;
        private Janus.Windows.UI.CommandBars.UICommand Separator15;
        private Janus.Windows.GridEX.EditControls.EditBox activityCommentEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox bfCommentEditBox;
        private UserControls.ucDocView ucDocView1;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private ucContactSelectBox ucContactSelectBox1;
        private ucContactSelectBox ucBFOfficerId;
        private Janus.Windows.GridEX.EditControls.EditBox ebBFPerson;
        private Janus.Windows.EditControls.UIButton btnNewDisb;
        private ucContactSelectBox ucContactSelectBox2;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo2;
        private Janus.Windows.GridEX.EditControls.EditBox editBox3;
        private Janus.Windows.GridEX.EditControls.EditBox editBox4;
        private Janus.Windows.GridEX.EditControls.EditBox editBox5;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo4;
        private Janus.Windows.GridEX.EditControls.EditBox editBox2;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo3;
        private Janus.Windows.UI.Dock.UIPanel pnlACTabs;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlACTabsContainer;
        private Janus.Windows.UI.Tab.UITab ucACTabs;
        private Janus.Windows.UI.Tab.UITabPage tabActivity;
        private Janus.Windows.UI.Tab.UITabPage tabDocument;
        private Janus.Windows.UI.Tab.UITabPage tabBF;
        private Janus.Windows.UI.Tab.UITabPage tabTK;
        private Janus.Windows.UI.Tab.UITabPage tabDisb;
        private Janus.Windows.EditControls.UIButton btnNewTimeslip;
        private Janus.Windows.EditControls.UIButton btnNewBF;
        private Janus.Windows.GridEX.EditControls.NumericEditBox hoursNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedNumericEditBox;
        private ucOfficeSelectBox ucTimeslipOfficeId;
        private Janus.Windows.CalendarCombo.CalendarCombo calActivityTimeDate;
        private Janus.Windows.GridEX.EditControls.EditBox ebActivityTimeComment;
        private Janus.Windows.EditControls.UICheckBox postedUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo sRPDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox finalUICheckBox;
        private UserControls.ucMultiDropDown mccTimeslipOfficerId;
        private Janus.Windows.EditControls.UIComboBox priorityJComboBox;
        private System.Windows.Forms.BindingSource activityBFBindingSourceForGrid;
        private Janus.Windows.UI.CommandBars.UICommand tsMoreInfo1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridOptions1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRelatedRecord1;
        private Janus.Windows.UI.CommandBars.UICommand cmdDocMoreInfo3;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoreInfoBF1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGridOptions;
        private Janus.Windows.UI.CommandBars.UICommand cmdResetGrid3;
        private Janus.Windows.UI.CommandBars.UICommand cmdExpandGrid3;
        private Janus.Windows.UI.CommandBars.UICommand tsFilter3;
        private Janus.Windows.UI.CommandBars.UICommand cmdGroupBy3;
        private Janus.Windows.UI.CommandBars.UICommand cmdFieldChooser3;
        private Janus.Windows.UI.CommandBars.UICommand cmdMoreInfoBF;
        private Janus.Windows.UI.CommandBars.UICommand cmdRelatedRecord;
        private ucContactSelectBox ucTimeslipOfficerId;
        private Janus.Windows.CalendarCombo.CalendarCombo disbDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox commentEditBox;
        private Janus.Windows.EditControls.UICheckBox finalUICheckBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo sRPDateCalendarCombo1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbTaxExemptNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbTaxableNumericEditBox;
        private UserControls.ucMultiDropDown disbTypeucMultiDropDown;
        private System.Windows.Forms.Label disbDateLabel;
        private System.Windows.Forms.Label disbTypeLabel;
        private System.Windows.Forms.Label disbTaxableLabel;
        private System.Windows.Forms.Label disbTaxLabel;
        private System.Windows.Forms.Label disbTaxExemptLabel;
        private System.Windows.Forms.Label sRPDateLabel1;
        private System.Windows.Forms.Label commentLabel;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu3;
        private Janus.Windows.UI.CommandBars.UICommand cmdAssociateDoc2;
        private Janus.Windows.UI.CommandBars.UICommand cmdAssociateDoc;
        private Janus.Windows.UI.CommandBars.UICommand cmdAssociateDoc1;
        private Janus.Windows.UI.CommandBars.UICommand Separator12;
        private Janus.Windows.GridEX.EditControls.NumericEditBox acCommentCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox bfCommentCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ACTimeCommentCounter;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbCommentCounter;
        private UserControls.ucMultiDropDown mccTaxRateId;
        private Janus.Windows.UI.CommandBars.UICommand Separator13;
        private Janus.Windows.UI.CommandBars.UICommand Separator14;
    }
}
