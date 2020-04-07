using System.Data; 
namespace LawMate
{
    partial class ucSSTCase
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
                SSTM.DB.SSTCase.ColumnChanged -= new DataColumnChangeEventHandler(dt_ColumnChanged);
                SSTM.DB.SSTCaseMatter.ColumnChanged -= new DataColumnChangeEventHandler(dt_ColumnChanged);

                SSTM.DB.SSTCaseMatter.RowDeleted -= new DataRowChangeEventHandler(dt_RowDeleted);

                SSTM.GetSSTCase().OnUpdate -= new atLogic.UpdateEventHandler(ucSSTCase_OnUpdate);
                SSTM.GetSSTCaseMatter().OnUpdate -= new atLogic.UpdateEventHandler(ucSSTCase_OnUpdate);
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSSTCase));
            System.Windows.Forms.Label LevelLabel;
            System.Windows.Forms.Label ProgramLabel;
            System.Windows.Forms.Label OutcomeLabel;
            System.Windows.Forms.Label DecisionDateLabel;
            System.Windows.Forms.Label DecisionSentDateLabel;
            System.Windows.Forms.Label CaseStatusLabel;
            System.Windows.Forms.Label DateAppealReceivedLabel;
            System.Windows.Forms.Label CaseStatusUpdatedLabel;
            System.Windows.Forms.Label LeaveToAppealReceivedLabel;
            System.Windows.Forms.Label LeaveToAppealDecisionDateLabel;
            System.Windows.Forms.Label LeaveToAppealDecisionLabel;
            System.Windows.Forms.Label AppealWithdrawnDateLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label PossibleCrisisFileLabel;
            System.Windows.Forms.Label OverrideDateLabel;
            System.Windows.Forms.Label OverrideUserLabel;
            System.Windows.Forms.Label TelSecurityCodeLabel;
            Janus.Windows.GridEX.GridEXLayout HearingGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.HearingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sST = new lmDatasets.SST();
            this.BenefitLabel = new System.Windows.Forms.Label();
            this.ignoreReasonLabel = new System.Windows.Forms.Label();
            this.FileCompleteDateLabel = new System.Windows.Forms.Label();
            this.ReconsiderationDecisionDateLabel = new System.Windows.Forms.Label();
            this.ReconsiderationIdLabel = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.CrisisTypeMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.SSTCaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CharterUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.MultipleAppealssUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.AppealCompleteGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.calCBAppealDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblAppealDate = new System.Windows.Forms.Label();
            this.FileCompleteDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.FileCompleteUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.LateFilingGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.OverrideUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.OverrideDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.LateOverrideUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.MoreThan365DaysUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.AppealFiledLateUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.LateAcceptedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ignoreReasonucMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.SSTAppealGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.ckbADReturnToGD = new Janus.Windows.EditControls.UICheckBox();
            this.BenefitMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.LTANotRequiredUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ReconsiderationIdEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.DateAppealReceivedCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.LevelMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.ProgramMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.ReconsiderationDecisionDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ApplicationLeaveToAppealGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.LeaveToAppealDecisionMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.LeaveToAppealDecisionDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.LeaveToAppealReceivedCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.HearingGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.TelSecurityCodeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.HearingGridEX = new Janus.Windows.GridEX.GridEX();
            this.CaseStatusMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.CaseStatusUpdatedCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.SSTDecisionGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.AppealWithdrawnDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.DecisionSentDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.OutcomeMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.DecisionDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.IssuesGroupBox = new Janus.Windows.EditControls.UIGroupBox();
            this.ucSSTCaseMatterIssues = new LawMate.ucSSTCaseMatter();
            this.gbNoIssues = new Janus.Windows.EditControls.UIGroupBox();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomUIRebar = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditMode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditMode = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            LevelLabel = new System.Windows.Forms.Label();
            ProgramLabel = new System.Windows.Forms.Label();
            OutcomeLabel = new System.Windows.Forms.Label();
            DecisionDateLabel = new System.Windows.Forms.Label();
            DecisionSentDateLabel = new System.Windows.Forms.Label();
            CaseStatusLabel = new System.Windows.Forms.Label();
            DateAppealReceivedLabel = new System.Windows.Forms.Label();
            CaseStatusUpdatedLabel = new System.Windows.Forms.Label();
            LeaveToAppealReceivedLabel = new System.Windows.Forms.Label();
            LeaveToAppealDecisionDateLabel = new System.Windows.Forms.Label();
            LeaveToAppealDecisionLabel = new System.Windows.Forms.Label();
            AppealWithdrawnDateLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            PossibleCrisisFileLabel = new System.Windows.Forms.Label();
            OverrideDateLabel = new System.Windows.Forms.Label();
            OverrideUserLabel = new System.Windows.Forms.Label();
            TelSecurityCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HearingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSTCaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppealCompleteGroupBox)).BeginInit();
            this.AppealCompleteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LateFilingGroupBox)).BeginInit();
            this.LateFilingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSTAppealGroupBox)).BeginInit();
            this.SSTAppealGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationLeaveToAppealGroupBox)).BeginInit();
            this.ApplicationLeaveToAppealGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HearingGroupBox)).BeginInit();
            this.HearingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HearingGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSTDecisionGroupBox)).BeginInit();
            this.SSTDecisionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IssuesGroupBox)).BeginInit();
            this.IssuesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbNoIssues)).BeginInit();
            this.gbNoIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomUIRebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.SSTCaseBindingSource;
            // 
            // imageListBase
            // 
            this.imageListBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBase.ImageStream")));
            this.imageListBase.Images.SetKeyName(0, "");
            this.imageListBase.Images.SetKeyName(1, "");
            this.imageListBase.Images.SetKeyName(2, "");
            this.imageListBase.Images.SetKeyName(3, "");
            this.imageListBase.Images.SetKeyName(4, "");
            this.imageListBase.Images.SetKeyName(5, "");
            this.imageListBase.Images.SetKeyName(6, "");
            this.imageListBase.Images.SetKeyName(7, "");
            this.imageListBase.Images.SetKeyName(8, "");
            this.imageListBase.Images.SetKeyName(9, "");
            this.imageListBase.Images.SetKeyName(10, "");
            this.imageListBase.Images.SetKeyName(11, "");
            this.imageListBase.Images.SetKeyName(12, "");
            this.imageListBase.Images.SetKeyName(13, "");
            this.imageListBase.Images.SetKeyName(14, "");
            this.imageListBase.Images.SetKeyName(15, "");
            this.imageListBase.Images.SetKeyName(16, "");
            this.imageListBase.Images.SetKeyName(17, "");
            this.imageListBase.Images.SetKeyName(18, "DRedit.gif");
            this.imageListBase.Images.SetKeyName(19, "audit.gif");
            // 
            // LevelLabel
            // 
            resources.ApplyResources(LevelLabel, "LevelLabel");
            LevelLabel.Name = "LevelLabel";
            this.helpProvider1.SetShowHelp(LevelLabel, ((bool)(resources.GetObject("LevelLabel.ShowHelp"))));
            // 
            // ProgramLabel
            // 
            resources.ApplyResources(ProgramLabel, "ProgramLabel");
            ProgramLabel.Name = "ProgramLabel";
            this.helpProvider1.SetShowHelp(ProgramLabel, ((bool)(resources.GetObject("ProgramLabel.ShowHelp"))));
            // 
            // OutcomeLabel
            // 
            resources.ApplyResources(OutcomeLabel, "OutcomeLabel");
            OutcomeLabel.Name = "OutcomeLabel";
            this.helpProvider1.SetShowHelp(OutcomeLabel, ((bool)(resources.GetObject("OutcomeLabel.ShowHelp"))));
            // 
            // DecisionDateLabel
            // 
            resources.ApplyResources(DecisionDateLabel, "DecisionDateLabel");
            DecisionDateLabel.Name = "DecisionDateLabel";
            this.helpProvider1.SetShowHelp(DecisionDateLabel, ((bool)(resources.GetObject("DecisionDateLabel.ShowHelp"))));
            // 
            // DecisionSentDateLabel
            // 
            resources.ApplyResources(DecisionSentDateLabel, "DecisionSentDateLabel");
            DecisionSentDateLabel.Name = "DecisionSentDateLabel";
            this.helpProvider1.SetShowHelp(DecisionSentDateLabel, ((bool)(resources.GetObject("DecisionSentDateLabel.ShowHelp"))));
            // 
            // CaseStatusLabel
            // 
            resources.ApplyResources(CaseStatusLabel, "CaseStatusLabel");
            CaseStatusLabel.BackColor = System.Drawing.Color.Transparent;
            CaseStatusLabel.Name = "CaseStatusLabel";
            this.helpProvider1.SetShowHelp(CaseStatusLabel, ((bool)(resources.GetObject("CaseStatusLabel.ShowHelp"))));
            // 
            // DateAppealReceivedLabel
            // 
            resources.ApplyResources(DateAppealReceivedLabel, "DateAppealReceivedLabel");
            DateAppealReceivedLabel.Name = "DateAppealReceivedLabel";
            this.helpProvider1.SetShowHelp(DateAppealReceivedLabel, ((bool)(resources.GetObject("DateAppealReceivedLabel.ShowHelp"))));
            // 
            // CaseStatusUpdatedLabel
            // 
            resources.ApplyResources(CaseStatusUpdatedLabel, "CaseStatusUpdatedLabel");
            CaseStatusUpdatedLabel.BackColor = System.Drawing.Color.Transparent;
            CaseStatusUpdatedLabel.Name = "CaseStatusUpdatedLabel";
            this.helpProvider1.SetShowHelp(CaseStatusUpdatedLabel, ((bool)(resources.GetObject("CaseStatusUpdatedLabel.ShowHelp"))));
            // 
            // LeaveToAppealReceivedLabel
            // 
            resources.ApplyResources(LeaveToAppealReceivedLabel, "LeaveToAppealReceivedLabel");
            LeaveToAppealReceivedLabel.Name = "LeaveToAppealReceivedLabel";
            this.helpProvider1.SetShowHelp(LeaveToAppealReceivedLabel, ((bool)(resources.GetObject("LeaveToAppealReceivedLabel.ShowHelp"))));
            // 
            // LeaveToAppealDecisionDateLabel
            // 
            resources.ApplyResources(LeaveToAppealDecisionDateLabel, "LeaveToAppealDecisionDateLabel");
            LeaveToAppealDecisionDateLabel.Name = "LeaveToAppealDecisionDateLabel";
            this.helpProvider1.SetShowHelp(LeaveToAppealDecisionDateLabel, ((bool)(resources.GetObject("LeaveToAppealDecisionDateLabel.ShowHelp"))));
            // 
            // LeaveToAppealDecisionLabel
            // 
            resources.ApplyResources(LeaveToAppealDecisionLabel, "LeaveToAppealDecisionLabel");
            LeaveToAppealDecisionLabel.Name = "LeaveToAppealDecisionLabel";
            this.helpProvider1.SetShowHelp(LeaveToAppealDecisionLabel, ((bool)(resources.GetObject("LeaveToAppealDecisionLabel.ShowHelp"))));
            // 
            // AppealWithdrawnDateLabel
            // 
            resources.ApplyResources(AppealWithdrawnDateLabel, "AppealWithdrawnDateLabel");
            AppealWithdrawnDateLabel.Name = "AppealWithdrawnDateLabel";
            this.helpProvider1.SetShowHelp(AppealWithdrawnDateLabel, ((bool)(resources.GetObject("AppealWithdrawnDateLabel.ShowHelp"))));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            this.helpProvider1.SetShowHelp(label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // PossibleCrisisFileLabel
            // 
            resources.ApplyResources(PossibleCrisisFileLabel, "PossibleCrisisFileLabel");
            PossibleCrisisFileLabel.BackColor = System.Drawing.Color.Transparent;
            PossibleCrisisFileLabel.Name = "PossibleCrisisFileLabel";
            this.helpProvider1.SetShowHelp(PossibleCrisisFileLabel, ((bool)(resources.GetObject("PossibleCrisisFileLabel.ShowHelp"))));
            // 
            // OverrideDateLabel
            // 
            resources.ApplyResources(OverrideDateLabel, "OverrideDateLabel");
            OverrideDateLabel.Name = "OverrideDateLabel";
            this.helpProvider1.SetShowHelp(OverrideDateLabel, ((bool)(resources.GetObject("OverrideDateLabel.ShowHelp"))));
            // 
            // OverrideUserLabel
            // 
            resources.ApplyResources(OverrideUserLabel, "OverrideUserLabel");
            OverrideUserLabel.Name = "OverrideUserLabel";
            this.helpProvider1.SetShowHelp(OverrideUserLabel, ((bool)(resources.GetObject("OverrideUserLabel.ShowHelp"))));
            // 
            // TelSecurityCodeLabel
            // 
            resources.ApplyResources(TelSecurityCodeLabel, "TelSecurityCodeLabel");
            TelSecurityCodeLabel.Name = "TelSecurityCodeLabel";
            this.helpProvider1.SetShowHelp(TelSecurityCodeLabel, ((bool)(resources.GetObject("TelSecurityCodeLabel.ShowHelp"))));
            // 
            // HearingBindingSource
            // 
            this.HearingBindingSource.DataMember = "Hearing";
            this.HearingBindingSource.DataSource = this.sST;
            // 
            // sST
            // 
            this.sST.DataSetName = "SST";
            this.sST.EnforceConstraints = false;
            this.sST.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // BenefitLabel
            // 
            resources.ApplyResources(this.BenefitLabel, "BenefitLabel");
            this.BenefitLabel.Name = "BenefitLabel";
            this.helpProvider1.SetShowHelp(this.BenefitLabel, ((bool)(resources.GetObject("BenefitLabel.ShowHelp"))));
            // 
            // ignoreReasonLabel
            // 
            resources.ApplyResources(this.ignoreReasonLabel, "ignoreReasonLabel");
            this.ignoreReasonLabel.Name = "ignoreReasonLabel";
            this.helpProvider1.SetShowHelp(this.ignoreReasonLabel, ((bool)(resources.GetObject("ignoreReasonLabel.ShowHelp"))));
            // 
            // FileCompleteDateLabel
            // 
            resources.ApplyResources(this.FileCompleteDateLabel, "FileCompleteDateLabel");
            this.FileCompleteDateLabel.Name = "FileCompleteDateLabel";
            this.helpProvider1.SetShowHelp(this.FileCompleteDateLabel, ((bool)(resources.GetObject("FileCompleteDateLabel.ShowHelp"))));
            // 
            // ReconsiderationDecisionDateLabel
            // 
            resources.ApplyResources(this.ReconsiderationDecisionDateLabel, "ReconsiderationDecisionDateLabel");
            this.ReconsiderationDecisionDateLabel.Name = "ReconsiderationDecisionDateLabel";
            this.helpProvider1.SetShowHelp(this.ReconsiderationDecisionDateLabel, ((bool)(resources.GetObject("ReconsiderationDecisionDateLabel.ShowHelp"))));
            // 
            // ReconsiderationIdLabel
            // 
            resources.ApplyResources(this.ReconsiderationIdLabel, "ReconsiderationIdLabel");
            this.ReconsiderationIdLabel.Name = "ReconsiderationIdLabel";
            this.helpProvider1.SetShowHelp(this.ReconsiderationIdLabel, ((bool)(resources.GetObject("ReconsiderationIdLabel.ShowHelp"))));
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(739, 750), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(PossibleCrisisFileLabel);
            this.pnlAllContainer.Controls.Add(this.CrisisTypeMultiDropDown);
            this.pnlAllContainer.Controls.Add(this.CharterUICheckBox);
            this.pnlAllContainer.Controls.Add(this.MultipleAppealssUICheckBox);
            this.pnlAllContainer.Controls.Add(this.AppealCompleteGroupBox);
            this.pnlAllContainer.Controls.Add(this.LateFilingGroupBox);
            this.pnlAllContainer.Controls.Add(this.SSTAppealGroupBox);
            this.pnlAllContainer.Controls.Add(this.ApplicationLeaveToAppealGroupBox);
            this.pnlAllContainer.Controls.Add(this.HearingGroupBox);
            this.pnlAllContainer.Controls.Add(this.CaseStatusMultiDropDown);
            this.pnlAllContainer.Controls.Add(CaseStatusLabel);
            this.pnlAllContainer.Controls.Add(this.CaseStatusUpdatedCalendarCombo);
            this.pnlAllContainer.Controls.Add(CaseStatusUpdatedLabel);
            this.pnlAllContainer.Controls.Add(this.SSTDecisionGroupBox);
            this.pnlAllContainer.Controls.Add(this.IssuesGroupBox);
            this.pnlAllContainer.Controls.Add(this.gbNoIssues);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // CrisisTypeMultiDropDown
            // 
            this.CrisisTypeMultiDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.CrisisTypeMultiDropDown.Column1 = "CrisisId";
            resources.ApplyResources(this.CrisisTypeMultiDropDown, "CrisisTypeMultiDropDown");
            this.CrisisTypeMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.CrisisTypeMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "CrisisId", true));
            this.CrisisTypeMultiDropDown.DataSource = null;
            this.CrisisTypeMultiDropDown.DDColumn1Visible = false;
            this.CrisisTypeMultiDropDown.DropDownColumn1Width = 100;
            this.CrisisTypeMultiDropDown.DropDownColumn2Width = 300;
            this.CrisisTypeMultiDropDown.Name = "CrisisTypeMultiDropDown";
            this.CrisisTypeMultiDropDown.ReadOnly = false;
            this.CrisisTypeMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.CrisisTypeMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.CrisisTypeMultiDropDown, ((bool)(resources.GetObject("CrisisTypeMultiDropDown.ShowHelp"))));
            this.CrisisTypeMultiDropDown.ValueMember = "CrisisId";
            // 
            // SSTCaseBindingSource
            // 
            this.SSTCaseBindingSource.DataMember = "SSTCase";
            this.SSTCaseBindingSource.DataSource = typeof(lmDatasets.SST);
            this.SSTCaseBindingSource.CurrentChanged += new System.EventHandler(this.SSTCaseBindingSource_CurrentChanged);
            // 
            // CharterUICheckBox
            // 
            this.CharterUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CharterUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CharterUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "IsCharter", true));
            resources.ApplyResources(this.CharterUICheckBox, "CharterUICheckBox");
            this.CharterUICheckBox.Name = "CharterUICheckBox";
            this.helpProvider1.SetShowHelp(this.CharterUICheckBox, ((bool)(resources.GetObject("CharterUICheckBox.ShowHelp"))));
            this.CharterUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // MultipleAppealssUICheckBox
            // 
            this.MultipleAppealssUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.MultipleAppealssUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MultipleAppealssUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "HasMultipleApps", true));
            resources.ApplyResources(this.MultipleAppealssUICheckBox, "MultipleAppealssUICheckBox");
            this.MultipleAppealssUICheckBox.Name = "MultipleAppealssUICheckBox";
            this.helpProvider1.SetShowHelp(this.MultipleAppealssUICheckBox, ((bool)(resources.GetObject("MultipleAppealssUICheckBox.ShowHelp"))));
            this.MultipleAppealssUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // AppealCompleteGroupBox
            // 
            this.AppealCompleteGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.AppealCompleteGroupBox.Controls.Add(this.calCBAppealDate);
            this.AppealCompleteGroupBox.Controls.Add(this.lblAppealDate);
            this.AppealCompleteGroupBox.Controls.Add(this.FileCompleteDateCalendarCombo);
            this.AppealCompleteGroupBox.Controls.Add(this.FileCompleteDateLabel);
            this.AppealCompleteGroupBox.Controls.Add(this.FileCompleteUICheckBox);
            this.AppealCompleteGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.AppealCompleteGroupBox, "AppealCompleteGroupBox");
            this.AppealCompleteGroupBox.Name = "AppealCompleteGroupBox";
            this.helpProvider1.SetShowHelp(this.AppealCompleteGroupBox, ((bool)(resources.GetObject("AppealCompleteGroupBox.ShowHelp"))));
            this.AppealCompleteGroupBox.UseThemes = false;
            // 
            // calCBAppealDate
            // 
            resources.ApplyResources(this.calCBAppealDate, "calCBAppealDate");
            this.calCBAppealDate.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "AppealDate", true));
            // 
            // 
            // 
            this.calCBAppealDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calCBAppealDate.Name = "calCBAppealDate";
            this.calCBAppealDate.Nullable = true;
            this.helpProvider1.SetShowHelp(this.calCBAppealDate, ((bool)(resources.GetObject("calCBAppealDate.ShowHelp"))));
            this.calCBAppealDate.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.calCBAppealDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // lblAppealDate
            // 
            resources.ApplyResources(this.lblAppealDate, "lblAppealDate");
            this.lblAppealDate.Name = "lblAppealDate";
            this.helpProvider1.SetShowHelp(this.lblAppealDate, ((bool)(resources.GetObject("lblAppealDate.ShowHelp"))));
            // 
            // FileCompleteDateCalendarCombo
            // 
            resources.ApplyResources(this.FileCompleteDateCalendarCombo, "FileCompleteDateCalendarCombo");
            this.FileCompleteDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "FileCompleteDate", true));
            // 
            // 
            // 
            this.FileCompleteDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.FileCompleteDateCalendarCombo.Name = "FileCompleteDateCalendarCombo";
            this.FileCompleteDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.FileCompleteDateCalendarCombo, ((bool)(resources.GetObject("FileCompleteDateCalendarCombo.ShowHelp"))));
            this.FileCompleteDateCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.FileCompleteDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // FileCompleteUICheckBox
            // 
            this.FileCompleteUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FileCompleteUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "FileComplete", true));
            resources.ApplyResources(this.FileCompleteUICheckBox, "FileCompleteUICheckBox");
            this.FileCompleteUICheckBox.Name = "FileCompleteUICheckBox";
            this.helpProvider1.SetShowHelp(this.FileCompleteUICheckBox, ((bool)(resources.GetObject("FileCompleteUICheckBox.ShowHelp"))));
            this.FileCompleteUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.FileCompleteUICheckBox.CheckedChanged += new System.EventHandler(this.FileCompleteUICheckBox_CheckedChanged);
            // 
            // LateFilingGroupBox
            // 
            this.LateFilingGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.LateFilingGroupBox.Controls.Add(this.OverrideUserEditBox);
            this.LateFilingGroupBox.Controls.Add(OverrideUserLabel);
            this.LateFilingGroupBox.Controls.Add(this.OverrideDateCalendarCombo);
            this.LateFilingGroupBox.Controls.Add(OverrideDateLabel);
            this.LateFilingGroupBox.Controls.Add(this.LateOverrideUICheckBox);
            this.LateFilingGroupBox.Controls.Add(this.MoreThan365DaysUICheckBox);
            this.LateFilingGroupBox.Controls.Add(this.AppealFiledLateUICheckBox);
            this.LateFilingGroupBox.Controls.Add(this.LateAcceptedUICheckBox);
            this.LateFilingGroupBox.Controls.Add(this.ignoreReasonucMultiDropDown);
            this.LateFilingGroupBox.Controls.Add(this.ignoreReasonLabel);
            this.LateFilingGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.LateFilingGroupBox, "LateFilingGroupBox");
            this.LateFilingGroupBox.Name = "LateFilingGroupBox";
            this.helpProvider1.SetShowHelp(this.LateFilingGroupBox, ((bool)(resources.GetObject("LateFilingGroupBox.ShowHelp"))));
            this.LateFilingGroupBox.UseThemes = false;
            // 
            // OverrideUserEditBox
            // 
            this.OverrideUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SSTCaseBindingSource, "LateOverrideUser", true));
            resources.ApplyResources(this.OverrideUserEditBox, "OverrideUserEditBox");
            this.OverrideUserEditBox.Name = "OverrideUserEditBox";
            this.helpProvider1.SetShowHelp(this.OverrideUserEditBox, ((bool)(resources.GetObject("OverrideUserEditBox.ShowHelp"))));
            this.OverrideUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // OverrideDateCalendarCombo
            // 
            resources.ApplyResources(this.OverrideDateCalendarCombo, "OverrideDateCalendarCombo");
            this.OverrideDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "LateOverrideDate", true));
            // 
            // 
            // 
            this.OverrideDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.OverrideDateCalendarCombo.Name = "OverrideDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.OverrideDateCalendarCombo, ((bool)(resources.GetObject("OverrideDateCalendarCombo.ShowHelp"))));
            this.OverrideDateCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.OverrideDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // LateOverrideUICheckBox
            // 
            this.LateOverrideUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LateOverrideUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "LateOverride", true));
            resources.ApplyResources(this.LateOverrideUICheckBox, "LateOverrideUICheckBox");
            this.LateOverrideUICheckBox.Name = "LateOverrideUICheckBox";
            this.helpProvider1.SetShowHelp(this.LateOverrideUICheckBox, ((bool)(resources.GetObject("LateOverrideUICheckBox.ShowHelp"))));
            this.LateOverrideUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.LateOverrideUICheckBox.CheckedChanged += new System.EventHandler(this.LateOverrideUICheckBox_CheckedChanged);
            // 
            // MoreThan365DaysUICheckBox
            // 
            this.MoreThan365DaysUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MoreThan365DaysUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "IsLate365", true));
            resources.ApplyResources(this.MoreThan365DaysUICheckBox, "MoreThan365DaysUICheckBox");
            this.MoreThan365DaysUICheckBox.Name = "MoreThan365DaysUICheckBox";
            this.helpProvider1.SetShowHelp(this.MoreThan365DaysUICheckBox, ((bool)(resources.GetObject("MoreThan365DaysUICheckBox.ShowHelp"))));
            this.MoreThan365DaysUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // AppealFiledLateUICheckBox
            // 
            this.AppealFiledLateUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AppealFiledLateUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "IsLate", true));
            resources.ApplyResources(this.AppealFiledLateUICheckBox, "AppealFiledLateUICheckBox");
            this.AppealFiledLateUICheckBox.Name = "AppealFiledLateUICheckBox";
            this.helpProvider1.SetShowHelp(this.AppealFiledLateUICheckBox, ((bool)(resources.GetObject("AppealFiledLateUICheckBox.ShowHelp"))));
            this.AppealFiledLateUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.AppealFiledLateUICheckBox.CheckedChanged += new System.EventHandler(this.AppealFiledLateUICheckBox_CheckedChanged);
            // 
            // LateAcceptedUICheckBox
            // 
            this.LateAcceptedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LateAcceptedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "IgnoreLate", true));
            resources.ApplyResources(this.LateAcceptedUICheckBox, "LateAcceptedUICheckBox");
            this.LateAcceptedUICheckBox.Name = "LateAcceptedUICheckBox";
            this.helpProvider1.SetShowHelp(this.LateAcceptedUICheckBox, ((bool)(resources.GetObject("LateAcceptedUICheckBox.ShowHelp"))));
            this.LateAcceptedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // ignoreReasonucMultiDropDown
            // 
            this.ignoreReasonucMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.ignoreReasonucMultiDropDown.Column1 = "";
            resources.ApplyResources(this.ignoreReasonucMultiDropDown, "ignoreReasonucMultiDropDown");
            this.ignoreReasonucMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ignoreReasonucMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "IgnoreReasonId", true));
            this.ignoreReasonucMultiDropDown.DataSource = null;
            this.ignoreReasonucMultiDropDown.DDColumn1Visible = false;
            this.ignoreReasonucMultiDropDown.DropDownColumn1Width = 8;
            this.ignoreReasonucMultiDropDown.DropDownColumn2Width = 300;
            this.ignoreReasonucMultiDropDown.Name = "ignoreReasonucMultiDropDown";
            this.ignoreReasonucMultiDropDown.ReadOnly = false;
            this.ignoreReasonucMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.ignoreReasonucMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ignoreReasonucMultiDropDown, ((bool)(resources.GetObject("ignoreReasonucMultiDropDown.ShowHelp"))));
            this.ignoreReasonucMultiDropDown.ValueMember = "LateIgnoreReasonId";
            // 
            // SSTAppealGroupBox
            // 
            this.SSTAppealGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.SSTAppealGroupBox.Controls.Add(this.ckbADReturnToGD);
            this.SSTAppealGroupBox.Controls.Add(this.BenefitMultiDropDown);
            this.SSTAppealGroupBox.Controls.Add(this.BenefitLabel);
            this.SSTAppealGroupBox.Controls.Add(this.LTANotRequiredUICheckBox);
            this.SSTAppealGroupBox.Controls.Add(this.ReconsiderationIdLabel);
            this.SSTAppealGroupBox.Controls.Add(this.ReconsiderationIdEditBox);
            this.SSTAppealGroupBox.Controls.Add(DateAppealReceivedLabel);
            this.SSTAppealGroupBox.Controls.Add(this.DateAppealReceivedCalendarCombo);
            this.SSTAppealGroupBox.Controls.Add(LevelLabel);
            this.SSTAppealGroupBox.Controls.Add(this.LevelMultiDropDown);
            this.SSTAppealGroupBox.Controls.Add(ProgramLabel);
            this.SSTAppealGroupBox.Controls.Add(this.ProgramMultiDropDown);
            this.SSTAppealGroupBox.Controls.Add(this.ReconsiderationDecisionDateLabel);
            this.SSTAppealGroupBox.Controls.Add(this.ReconsiderationDecisionDateCalendarCombo);
            this.SSTAppealGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.SSTAppealGroupBox, "SSTAppealGroupBox");
            this.SSTAppealGroupBox.Name = "SSTAppealGroupBox";
            this.helpProvider1.SetShowHelp(this.SSTAppealGroupBox, ((bool)(resources.GetObject("SSTAppealGroupBox.ShowHelp"))));
            this.SSTAppealGroupBox.UseThemes = false;
            // 
            // ckbADReturnToGD
            // 
            this.ckbADReturnToGD.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbADReturnToGD.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "ADReturnToGD", true));
            resources.ApplyResources(this.ckbADReturnToGD, "ckbADReturnToGD");
            this.ckbADReturnToGD.Name = "ckbADReturnToGD";
            this.helpProvider1.SetShowHelp(this.ckbADReturnToGD, ((bool)(resources.GetObject("ckbADReturnToGD.ShowHelp"))));
            // 
            // BenefitMultiDropDown
            // 
            this.BenefitMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.BenefitMultiDropDown.Column1 = "AccountTypeId";
            resources.ApplyResources(this.BenefitMultiDropDown, "BenefitMultiDropDown");
            this.BenefitMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.BenefitMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "AccountId", true));
            this.BenefitMultiDropDown.DataSource = null;
            this.BenefitMultiDropDown.DDColumn1Visible = false;
            this.BenefitMultiDropDown.DropDownColumn1Width = 8;
            this.BenefitMultiDropDown.DropDownColumn2Width = 300;
            this.BenefitMultiDropDown.Name = "BenefitMultiDropDown";
            this.BenefitMultiDropDown.ReadOnly = false;
            this.BenefitMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.BenefitMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.BenefitMultiDropDown, ((bool)(resources.GetObject("BenefitMultiDropDown.ShowHelp"))));
            this.BenefitMultiDropDown.ValueMember = "AccountTypeId";
            // 
            // LTANotRequiredUICheckBox
            // 
            this.LTANotRequiredUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LTANotRequiredUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "LeaveToAppealNotRequired", true));
            resources.ApplyResources(this.LTANotRequiredUICheckBox, "LTANotRequiredUICheckBox");
            this.LTANotRequiredUICheckBox.Name = "LTANotRequiredUICheckBox";
            this.helpProvider1.SetShowHelp(this.LTANotRequiredUICheckBox, ((bool)(resources.GetObject("LTANotRequiredUICheckBox.ShowHelp"))));
            this.LTANotRequiredUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // ReconsiderationIdEditBox
            // 
            this.ReconsiderationIdEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SSTCaseBindingSource, "ReconsiderationID", true));
            resources.ApplyResources(this.ReconsiderationIdEditBox, "ReconsiderationIdEditBox");
            this.ReconsiderationIdEditBox.Name = "ReconsiderationIdEditBox";
            this.helpProvider1.SetShowHelp(this.ReconsiderationIdEditBox, ((bool)(resources.GetObject("ReconsiderationIdEditBox.ShowHelp"))));
            this.ReconsiderationIdEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // DateAppealReceivedCalendarCombo
            // 
            resources.ApplyResources(this.DateAppealReceivedCalendarCombo, "DateAppealReceivedCalendarCombo");
            this.DateAppealReceivedCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "ReceivedDate", true));
            // 
            // 
            // 
            this.DateAppealReceivedCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.DateAppealReceivedCalendarCombo.Name = "DateAppealReceivedCalendarCombo";
            this.helpProvider1.SetShowHelp(this.DateAppealReceivedCalendarCombo, ((bool)(resources.GetObject("DateAppealReceivedCalendarCombo.ShowHelp"))));
            this.DateAppealReceivedCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.DateAppealReceivedCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // LevelMultiDropDown
            // 
            this.LevelMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.LevelMultiDropDown.Column1 = "AppealLevelId";
            resources.ApplyResources(this.LevelMultiDropDown, "LevelMultiDropDown");
            this.LevelMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.LevelMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "AppealLevelID", true));
            this.LevelMultiDropDown.DataSource = null;
            this.LevelMultiDropDown.DDColumn1Visible = false;
            this.LevelMultiDropDown.DropDownColumn1Width = 8;
            this.LevelMultiDropDown.DropDownColumn2Width = 260;
            this.LevelMultiDropDown.Name = "LevelMultiDropDown";
            this.LevelMultiDropDown.ReadOnly = false;
            this.LevelMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.LevelMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.LevelMultiDropDown, ((bool)(resources.GetObject("LevelMultiDropDown.ShowHelp"))));
            this.LevelMultiDropDown.ValueMember = "AppealLevelId";
            // 
            // ProgramMultiDropDown
            // 
            this.ProgramMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.ProgramMultiDropDown.Column1 = "ProgramID";
            resources.ApplyResources(this.ProgramMultiDropDown, "ProgramMultiDropDown");
            this.ProgramMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ProgramMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "ProgramId", true));
            this.ProgramMultiDropDown.DataSource = null;
            this.ProgramMultiDropDown.DDColumn1Visible = false;
            this.ProgramMultiDropDown.DropDownColumn1Width = 8;
            this.ProgramMultiDropDown.DropDownColumn2Width = 260;
            this.ProgramMultiDropDown.Name = "ProgramMultiDropDown";
            this.ProgramMultiDropDown.ReadOnly = false;
            this.ProgramMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.ProgramMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ProgramMultiDropDown, ((bool)(resources.GetObject("ProgramMultiDropDown.ShowHelp"))));
            this.ProgramMultiDropDown.ValueMember = "ProgramID";
            // 
            // ReconsiderationDecisionDateCalendarCombo
            // 
            resources.ApplyResources(this.ReconsiderationDecisionDateCalendarCombo, "ReconsiderationDecisionDateCalendarCombo");
            this.ReconsiderationDecisionDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "OrigDecisionDate", true));
            // 
            // 
            // 
            this.ReconsiderationDecisionDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.ReconsiderationDecisionDateCalendarCombo.Name = "ReconsiderationDecisionDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.ReconsiderationDecisionDateCalendarCombo, ((bool)(resources.GetObject("ReconsiderationDecisionDateCalendarCombo.ShowHelp"))));
            this.ReconsiderationDecisionDateCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.ReconsiderationDecisionDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // ApplicationLeaveToAppealGroupBox
            // 
            this.ApplicationLeaveToAppealGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.ApplicationLeaveToAppealGroupBox.Controls.Add(LeaveToAppealDecisionLabel);
            this.ApplicationLeaveToAppealGroupBox.Controls.Add(LeaveToAppealDecisionDateLabel);
            this.ApplicationLeaveToAppealGroupBox.Controls.Add(this.LeaveToAppealDecisionMultiDropDown);
            this.ApplicationLeaveToAppealGroupBox.Controls.Add(this.LeaveToAppealDecisionDateCalendarCombo);
            this.ApplicationLeaveToAppealGroupBox.Controls.Add(LeaveToAppealReceivedLabel);
            this.ApplicationLeaveToAppealGroupBox.Controls.Add(this.LeaveToAppealReceivedCalendarCombo);
            this.ApplicationLeaveToAppealGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.ApplicationLeaveToAppealGroupBox, "ApplicationLeaveToAppealGroupBox");
            this.ApplicationLeaveToAppealGroupBox.Name = "ApplicationLeaveToAppealGroupBox";
            this.helpProvider1.SetShowHelp(this.ApplicationLeaveToAppealGroupBox, ((bool)(resources.GetObject("ApplicationLeaveToAppealGroupBox.ShowHelp"))));
            this.ApplicationLeaveToAppealGroupBox.UseThemes = false;
            // 
            // LeaveToAppealDecisionMultiDropDown
            // 
            this.LeaveToAppealDecisionMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.LeaveToAppealDecisionMultiDropDown.Column1 = "LeaveDecId";
            resources.ApplyResources(this.LeaveToAppealDecisionMultiDropDown, "LeaveToAppealDecisionMultiDropDown");
            this.LeaveToAppealDecisionMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.LeaveToAppealDecisionMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "LeaveToAppealDecisionId", true));
            this.LeaveToAppealDecisionMultiDropDown.DataSource = null;
            this.LeaveToAppealDecisionMultiDropDown.DDColumn1Visible = false;
            this.LeaveToAppealDecisionMultiDropDown.DropDownColumn1Width = 8;
            this.LeaveToAppealDecisionMultiDropDown.DropDownColumn2Width = 250;
            this.LeaveToAppealDecisionMultiDropDown.Name = "LeaveToAppealDecisionMultiDropDown";
            this.LeaveToAppealDecisionMultiDropDown.ReadOnly = false;
            this.LeaveToAppealDecisionMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.LeaveToAppealDecisionMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.LeaveToAppealDecisionMultiDropDown, ((bool)(resources.GetObject("LeaveToAppealDecisionMultiDropDown.ShowHelp"))));
            this.LeaveToAppealDecisionMultiDropDown.ValueMember = "LeaveDecId";
            // 
            // LeaveToAppealDecisionDateCalendarCombo
            // 
            resources.ApplyResources(this.LeaveToAppealDecisionDateCalendarCombo, "LeaveToAppealDecisionDateCalendarCombo");
            this.LeaveToAppealDecisionDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "LeaveToAppealDate", true));
            // 
            // 
            // 
            this.LeaveToAppealDecisionDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.LeaveToAppealDecisionDateCalendarCombo.Name = "LeaveToAppealDecisionDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.LeaveToAppealDecisionDateCalendarCombo, ((bool)(resources.GetObject("LeaveToAppealDecisionDateCalendarCombo.ShowHelp"))));
            this.LeaveToAppealDecisionDateCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.LeaveToAppealDecisionDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // LeaveToAppealReceivedCalendarCombo
            // 
            resources.ApplyResources(this.LeaveToAppealReceivedCalendarCombo, "LeaveToAppealReceivedCalendarCombo");
            this.LeaveToAppealReceivedCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "LeaveToAppealRecDate", true));
            // 
            // 
            // 
            this.LeaveToAppealReceivedCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.LeaveToAppealReceivedCalendarCombo.Name = "LeaveToAppealReceivedCalendarCombo";
            this.helpProvider1.SetShowHelp(this.LeaveToAppealReceivedCalendarCombo, ((bool)(resources.GetObject("LeaveToAppealReceivedCalendarCombo.ShowHelp"))));
            this.LeaveToAppealReceivedCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.LeaveToAppealReceivedCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // HearingGroupBox
            // 
            this.HearingGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.HearingGroupBox.Controls.Add(this.TelSecurityCodeEditBox);
            this.HearingGroupBox.Controls.Add(TelSecurityCodeLabel);
            this.HearingGroupBox.Controls.Add(this.HearingGridEX);
            this.HearingGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.HearingGroupBox, "HearingGroupBox");
            this.HearingGroupBox.Name = "HearingGroupBox";
            this.helpProvider1.SetShowHelp(this.HearingGroupBox, ((bool)(resources.GetObject("HearingGroupBox.ShowHelp"))));
            this.HearingGroupBox.UseThemes = false;
            // 
            // TelSecurityCodeEditBox
            // 
            this.TelSecurityCodeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HearingBindingSource, "SecurityPIN", true));
            resources.ApplyResources(this.TelSecurityCodeEditBox, "TelSecurityCodeEditBox");
            this.TelSecurityCodeEditBox.Name = "TelSecurityCodeEditBox";
            this.helpProvider1.SetShowHelp(this.TelSecurityCodeEditBox, ((bool)(resources.GetObject("TelSecurityCodeEditBox.ShowHelp"))));
            this.TelSecurityCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // HearingGridEX
            // 
            this.HearingGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.HearingGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.HearingGridEX.DataSource = this.HearingBindingSource;
            resources.ApplyResources(HearingGridEX_DesignTimeLayout, "HearingGridEX_DesignTimeLayout");
            this.HearingGridEX.DesignTimeLayout = HearingGridEX_DesignTimeLayout;
            resources.ApplyResources(this.HearingGridEX, "HearingGridEX");
            this.HearingGridEX.GridLines = Janus.Windows.GridEX.GridLines.RowOutline;
            this.HearingGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.HearingGridEX.GroupByBoxVisible = false;
            this.HearingGridEX.Name = "HearingGridEX";
            this.HearingGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.helpProvider1.SetShowHelp(this.HearingGridEX, ((bool)(resources.GetObject("HearingGridEX.ShowHelp"))));
            this.HearingGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.HearingGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.HearingGridEX_LoadingRow);
            // 
            // CaseStatusMultiDropDown
            // 
            this.CaseStatusMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.CaseStatusMultiDropDown.Column1 = "CaseStatusId";
            resources.ApplyResources(this.CaseStatusMultiDropDown, "CaseStatusMultiDropDown");
            this.CaseStatusMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.CaseStatusMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "CaseStatus", true));
            this.CaseStatusMultiDropDown.DataSource = null;
            this.CaseStatusMultiDropDown.DDColumn1Visible = false;
            this.CaseStatusMultiDropDown.DropDownColumn1Width = 8;
            this.CaseStatusMultiDropDown.DropDownColumn2Width = 300;
            this.CaseStatusMultiDropDown.Name = "CaseStatusMultiDropDown";
            this.CaseStatusMultiDropDown.ReadOnly = false;
            this.CaseStatusMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.CaseStatusMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.CaseStatusMultiDropDown, ((bool)(resources.GetObject("CaseStatusMultiDropDown.ShowHelp"))));
            this.CaseStatusMultiDropDown.ValueMember = "CaseStatusId";
            // 
            // CaseStatusUpdatedCalendarCombo
            // 
            this.CaseStatusUpdatedCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.CaseStatusUpdatedCalendarCombo, "CaseStatusUpdatedCalendarCombo");
            this.CaseStatusUpdatedCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "CaseStatusDate", true));
            // 
            // 
            // 
            this.CaseStatusUpdatedCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.CaseStatusUpdatedCalendarCombo.Name = "CaseStatusUpdatedCalendarCombo";
            this.CaseStatusUpdatedCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.CaseStatusUpdatedCalendarCombo, ((bool)(resources.GetObject("CaseStatusUpdatedCalendarCombo.ShowHelp"))));
            this.CaseStatusUpdatedCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.CaseStatusUpdatedCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // SSTDecisionGroupBox
            // 
            this.SSTDecisionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.SSTDecisionGroupBox.Controls.Add(this.AppealWithdrawnDateCalendarCombo);
            this.SSTDecisionGroupBox.Controls.Add(AppealWithdrawnDateLabel);
            this.SSTDecisionGroupBox.Controls.Add(OutcomeLabel);
            this.SSTDecisionGroupBox.Controls.Add(this.DecisionSentDateCalendarCombo);
            this.SSTDecisionGroupBox.Controls.Add(this.OutcomeMultiDropDown);
            this.SSTDecisionGroupBox.Controls.Add(DecisionSentDateLabel);
            this.SSTDecisionGroupBox.Controls.Add(this.DecisionDateCalendarCombo);
            this.SSTDecisionGroupBox.Controls.Add(DecisionDateLabel);
            this.SSTDecisionGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.SSTDecisionGroupBox, "SSTDecisionGroupBox");
            this.SSTDecisionGroupBox.Name = "SSTDecisionGroupBox";
            this.helpProvider1.SetShowHelp(this.SSTDecisionGroupBox, ((bool)(resources.GetObject("SSTDecisionGroupBox.ShowHelp"))));
            this.SSTDecisionGroupBox.UseThemes = false;
            // 
            // AppealWithdrawnDateCalendarCombo
            // 
            resources.ApplyResources(this.AppealWithdrawnDateCalendarCombo, "AppealWithdrawnDateCalendarCombo");
            this.AppealWithdrawnDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "WithdrawalDate", true));
            // 
            // 
            // 
            this.AppealWithdrawnDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.AppealWithdrawnDateCalendarCombo.Name = "AppealWithdrawnDateCalendarCombo";
            this.AppealWithdrawnDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.AppealWithdrawnDateCalendarCombo, ((bool)(resources.GetObject("AppealWithdrawnDateCalendarCombo.ShowHelp"))));
            this.AppealWithdrawnDateCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.AppealWithdrawnDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // DecisionSentDateCalendarCombo
            // 
            resources.ApplyResources(this.DecisionSentDateCalendarCombo, "DecisionSentDateCalendarCombo");
            this.DecisionSentDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "DecisionSentDate", true));
            // 
            // 
            // 
            this.DecisionSentDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.DecisionSentDateCalendarCombo.Name = "DecisionSentDateCalendarCombo";
            this.DecisionSentDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.DecisionSentDateCalendarCombo, ((bool)(resources.GetObject("DecisionSentDateCalendarCombo.ShowHelp"))));
            this.DecisionSentDateCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.DecisionSentDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // OutcomeMultiDropDown
            // 
            this.OutcomeMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.OutcomeMultiDropDown.Column1 = "OutcomeId";
            resources.ApplyResources(this.OutcomeMultiDropDown, "OutcomeMultiDropDown");
            this.OutcomeMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.OutcomeMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SSTCaseBindingSource, "OutcomeId", true));
            this.OutcomeMultiDropDown.DataSource = null;
            this.OutcomeMultiDropDown.DDColumn1Visible = false;
            this.OutcomeMultiDropDown.DropDownColumn1Width = 8;
            this.OutcomeMultiDropDown.DropDownColumn2Width = 300;
            this.OutcomeMultiDropDown.Name = "OutcomeMultiDropDown";
            this.OutcomeMultiDropDown.ReadOnly = false;
            this.OutcomeMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.OutcomeMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.OutcomeMultiDropDown, ((bool)(resources.GetObject("OutcomeMultiDropDown.ShowHelp"))));
            this.OutcomeMultiDropDown.ValueMember = "OutcomeId";
            // 
            // DecisionDateCalendarCombo
            // 
            resources.ApplyResources(this.DecisionDateCalendarCombo, "DecisionDateCalendarCombo");
            this.DecisionDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.SSTCaseBindingSource, "DecisionDate", true));
            // 
            // 
            // 
            this.DecisionDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.DecisionDateCalendarCombo.Name = "DecisionDateCalendarCombo";
            this.DecisionDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.DecisionDateCalendarCombo, ((bool)(resources.GetObject("DecisionDateCalendarCombo.ShowHelp"))));
            this.DecisionDateCalendarCombo.Value = new System.DateTime(2015, 2, 10, 0, 0, 0, 0);
            this.DecisionDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // IssuesGroupBox
            // 
            this.IssuesGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.IssuesGroupBox.Controls.Add(this.ucSSTCaseMatterIssues);
            this.IssuesGroupBox.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.IssuesGroupBox, "IssuesGroupBox");
            this.IssuesGroupBox.Name = "IssuesGroupBox";
            this.helpProvider1.SetShowHelp(this.IssuesGroupBox, ((bool)(resources.GetObject("IssuesGroupBox.ShowHelp"))));
            this.IssuesGroupBox.UseThemes = false;
            // 
            // ucSSTCaseMatterIssues
            // 
            this.ucSSTCaseMatterIssues.BackColor = System.Drawing.Color.Transparent;
            this.ucSSTCaseMatterIssues.FM = null;
            resources.ApplyResources(this.ucSSTCaseMatterIssues, "ucSSTCaseMatterIssues");
            this.ucSSTCaseMatterIssues.IsSettingOutcome = false;
            this.ucSSTCaseMatterIssues.Name = "ucSSTCaseMatterIssues";
            this.ucSSTCaseMatterIssues.PromptIssueMode = false;
            this.ucSSTCaseMatterIssues.PromptNoIssueMode = false;
            this.ucSSTCaseMatterIssues.ReqColor = System.Drawing.Color.White;
            this.helpProvider1.SetShowHelp(this.ucSSTCaseMatterIssues, ((bool)(resources.GetObject("ucSSTCaseMatterIssues.ShowHelp"))));
            // 
            // gbNoIssues
            // 
            this.gbNoIssues.BackColor = System.Drawing.Color.Transparent;
            this.gbNoIssues.Controls.Add(label7);
            this.gbNoIssues.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbNoIssues, "gbNoIssues");
            this.gbNoIssues.Name = "gbNoIssues";
            this.helpProvider1.SetShowHelp(this.gbNoIssues, ((bool)(resources.GetObject("gbNoIssues.ShowHelp"))));
            this.gbNoIssues.UseThemes = false;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomUIRebar;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave,
            this.tsDelete,
            this.tsScreenTitle,
            this.tsEditMode,
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("3ae62034-b0f2-4a63-9270-34f4760e5a18");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomUIRebar
            // 
            this.BottomUIRebar.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomUIRebar, "BottomUIRebar");
            this.BottomUIRebar.Name = "BottomUIRebar";
            this.helpProvider1.SetShowHelp(this.BottomUIRebar, ((bool)(resources.GetObject("BottomUIRebar.ShowHelp"))));
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
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
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditMode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave2,
            this.tsDelete2,
            this.Separator2,
            this.tsAudit1});
            this.uiCommandBar2.FullRow = true;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // tsEditMode1
            // 
            resources.ApplyResources(this.tsEditMode1, "tsEditMode1");
            this.tsEditMode1.Name = "tsEditMode1";
            // 
            // tsScreenTitle1
            // 
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
            // 
            // tsSave
            // 
            this.tsSave.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsSave, "tsSave");
            this.tsSave.Name = "tsSave";
            // 
            // tsDelete
            // 
            this.tsDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsDelete, "tsDelete");
            this.tsDelete.Name = "tsDelete";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            // 
            // tsEditMode
            // 
            this.tsEditMode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditMode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditMode, "tsEditMode");
            this.tsEditMode.Name = "tsEditMode";
            // 
            // tsAudit
            // 
            this.tsAudit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete1});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
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
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.DataSource = this.HearingBindingSource;
            // 
            // ucSSTCase
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucSSTCase";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HearingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSTCaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppealCompleteGroupBox)).EndInit();
            this.AppealCompleteGroupBox.ResumeLayout(false);
            this.AppealCompleteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LateFilingGroupBox)).EndInit();
            this.LateFilingGroupBox.ResumeLayout(false);
            this.LateFilingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSTAppealGroupBox)).EndInit();
            this.SSTAppealGroupBox.ResumeLayout(false);
            this.SSTAppealGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationLeaveToAppealGroupBox)).EndInit();
            this.ApplicationLeaveToAppealGroupBox.ResumeLayout(false);
            this.ApplicationLeaveToAppealGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HearingGroupBox)).EndInit();
            this.HearingGroupBox.ResumeLayout(false);
            this.HearingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HearingGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSTDecisionGroupBox)).EndInit();
            this.SSTDecisionGroupBox.ResumeLayout(false);
            this.SSTDecisionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IssuesGroupBox)).EndInit();
            this.IssuesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbNoIssues)).EndInit();
            this.gbNoIssues.ResumeLayout(false);
            this.gbNoIssues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomUIRebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomUIRebar;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.EditControls.UIGroupBox SSTAppealGroupBox;
        private lmDatasets.SST sST;
        private System.Windows.Forms.BindingSource SSTCaseBindingSource;
        private Janus.Windows.EditControls.UIGroupBox SSTDecisionGroupBox;
        private Janus.Windows.CalendarCombo.CalendarCombo DecisionSentDateCalendarCombo;
        private UserControls.ucMultiDropDown OutcomeMultiDropDown;
        private Janus.Windows.CalendarCombo.CalendarCombo DecisionDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo DateAppealReceivedCalendarCombo;
        private UserControls.ucMultiDropDown LevelMultiDropDown;
        private UserControls.ucMultiDropDown ProgramMultiDropDown;
        private Janus.Windows.CalendarCombo.CalendarCombo ReconsiderationDecisionDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox AppealFiledLateUICheckBox;
        private Janus.Windows.EditControls.UICheckBox LateAcceptedUICheckBox;
        private UserControls.ucMultiDropDown ignoreReasonucMultiDropDown;
        private Janus.Windows.EditControls.UIGroupBox IssuesGroupBox;
        private Janus.Windows.GridEX.GridEX HearingGridEX;
        private System.Windows.Forms.BindingSource HearingBindingSource;
        private Janus.Windows.EditControls.UIGroupBox HearingGroupBox;
        private UserControls.ucMultiDropDown CaseStatusMultiDropDown;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private Janus.Windows.CalendarCombo.CalendarCombo CaseStatusUpdatedCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox ReconsiderationIdEditBox;
        private Janus.Windows.EditControls.UIGroupBox ApplicationLeaveToAppealGroupBox;
        private UserControls.ucMultiDropDown LeaveToAppealDecisionMultiDropDown;
        private Janus.Windows.CalendarCombo.CalendarCombo LeaveToAppealDecisionDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo LeaveToAppealReceivedCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo AppealWithdrawnDateCalendarCombo;
        private System.Windows.Forms.Label ReconsiderationDecisionDateLabel;
        private System.Windows.Forms.Label ReconsiderationIdLabel;
        private Janus.Windows.EditControls.UIGroupBox LateFilingGroupBox;
        private Janus.Windows.EditControls.UIGroupBox AppealCompleteGroupBox;
        private Janus.Windows.CalendarCombo.CalendarCombo FileCompleteDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox FileCompleteUICheckBox;
        private Janus.Windows.EditControls.UICheckBox LTANotRequiredUICheckBox;
        private UserControls.ucMultiDropDown BenefitMultiDropDown;
        private System.Windows.Forms.Label FileCompleteDateLabel;
        private System.Windows.Forms.Label ignoreReasonLabel;
        private Janus.Windows.EditControls.UIGroupBox gbNoIssues;
        private Janus.Windows.EditControls.UICheckBox CharterUICheckBox;
        private Janus.Windows.EditControls.UICheckBox MultipleAppealssUICheckBox;
        private Janus.Windows.EditControls.UICheckBox MoreThan365DaysUICheckBox;
        private System.Windows.Forms.Label BenefitLabel;
        private ucSSTCaseMatter ucSSTCaseMatterIssues;
        private UserControls.ucMultiDropDown CrisisTypeMultiDropDown;
        private Janus.Windows.EditControls.UICheckBox LateOverrideUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo OverrideDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox OverrideUserEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo calCBAppealDate;
        private System.Windows.Forms.Label lblAppealDate;
        private Janus.Windows.GridEX.EditControls.EditBox TelSecurityCodeEditBox;
        private Janus.Windows.EditControls.UICheckBox ckbADReturnToGD;
    }
}
