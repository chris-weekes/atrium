using System.Data; 
namespace LawMate
{
    partial class ucSSTDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSSTDetail));
            System.Windows.Forms.Label applicationDateLabel;
            System.Windows.Forms.Label onsetDateLabel;
            System.Windows.Forms.Label deemedDisabilityDateLabel;
            System.Windows.Forms.Label paymentDateLabel;
            System.Windows.Forms.Label terminationDateLabel;
            System.Windows.Forms.Label mQPDateLabel;
            System.Windows.Forms.Label benefitStartDateLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label Received365Datelabel;
            Janus.Windows.GridEX.GridEXLayout FileFlagGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference FileFlagGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.ButtonImage");
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.gbFlagCode = new Janus.Windows.EditControls.UIGroupBox();
            this.FileFlagGridEX = new Janus.Windows.GridEX.GridEX();
            this.FileFlagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AddFileFlagButton = new Janus.Windows.EditControls.UIButton();
            this.FlagCodeMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.gbIS = new Janus.Windows.EditControls.UIGroupBox();
            this.Received365DatecalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sSTCaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.isIncapacitatedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.isDeceasedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.disabledUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.mQPAgreedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.mQPDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.maxRetroactivityUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.paymentDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.deemedDisabilityDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.onsetDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.applicationDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.gbEI = new Janus.Windows.EditControls.UIGroupBox();
            this.voluntaryUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.benefitStartDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.terminationDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sSTDecisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sST = new lmDatasets.SST();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
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
            applicationDateLabel = new System.Windows.Forms.Label();
            onsetDateLabel = new System.Windows.Forms.Label();
            deemedDisabilityDateLabel = new System.Windows.Forms.Label();
            paymentDateLabel = new System.Windows.Forms.Label();
            terminationDateLabel = new System.Windows.Forms.Label();
            mQPDateLabel = new System.Windows.Forms.Label();
            benefitStartDateLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            Received365Datelabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbFlagCode)).BeginInit();
            this.gbFlagCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileFlagGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileFlagBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbIS)).BeginInit();
            this.gbIS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSTCaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbEI)).BeginInit();
            this.gbEI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSTDecisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.sSTCaseBindingSource;
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
            // applicationDateLabel
            // 
            resources.ApplyResources(applicationDateLabel, "applicationDateLabel");
            applicationDateLabel.Name = "applicationDateLabel";
            this.helpProvider1.SetShowHelp(applicationDateLabel, ((bool)(resources.GetObject("applicationDateLabel.ShowHelp"))));
            // 
            // onsetDateLabel
            // 
            resources.ApplyResources(onsetDateLabel, "onsetDateLabel");
            onsetDateLabel.Name = "onsetDateLabel";
            this.helpProvider1.SetShowHelp(onsetDateLabel, ((bool)(resources.GetObject("onsetDateLabel.ShowHelp"))));
            // 
            // deemedDisabilityDateLabel
            // 
            resources.ApplyResources(deemedDisabilityDateLabel, "deemedDisabilityDateLabel");
            deemedDisabilityDateLabel.Name = "deemedDisabilityDateLabel";
            this.helpProvider1.SetShowHelp(deemedDisabilityDateLabel, ((bool)(resources.GetObject("deemedDisabilityDateLabel.ShowHelp"))));
            // 
            // paymentDateLabel
            // 
            resources.ApplyResources(paymentDateLabel, "paymentDateLabel");
            paymentDateLabel.Name = "paymentDateLabel";
            this.helpProvider1.SetShowHelp(paymentDateLabel, ((bool)(resources.GetObject("paymentDateLabel.ShowHelp"))));
            // 
            // terminationDateLabel
            // 
            resources.ApplyResources(terminationDateLabel, "terminationDateLabel");
            terminationDateLabel.Name = "terminationDateLabel";
            this.helpProvider1.SetShowHelp(terminationDateLabel, ((bool)(resources.GetObject("terminationDateLabel.ShowHelp"))));
            // 
            // mQPDateLabel
            // 
            resources.ApplyResources(mQPDateLabel, "mQPDateLabel");
            mQPDateLabel.Name = "mQPDateLabel";
            this.helpProvider1.SetShowHelp(mQPDateLabel, ((bool)(resources.GetObject("mQPDateLabel.ShowHelp"))));
            // 
            // benefitStartDateLabel
            // 
            resources.ApplyResources(benefitStartDateLabel, "benefitStartDateLabel");
            benefitStartDateLabel.BackColor = System.Drawing.Color.Transparent;
            benefitStartDateLabel.Name = "benefitStartDateLabel";
            this.helpProvider1.SetShowHelp(benefitStartDateLabel, ((bool)(resources.GetObject("benefitStartDateLabel.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // Received365Datelabel
            // 
            resources.ApplyResources(Received365Datelabel, "Received365Datelabel");
            Received365Datelabel.Name = "Received365Datelabel";
            this.helpProvider1.SetShowHelp(Received365Datelabel, ((bool)(resources.GetObject("Received365Datelabel.ShowHelp"))));
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
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(725, 425), true);
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
            this.pnlAllContainer.Controls.Add(this.gbFlagCode);
            this.pnlAllContainer.Controls.Add(this.gbIS);
            this.pnlAllContainer.Controls.Add(this.gbEI);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // gbFlagCode
            // 
            this.gbFlagCode.BackColor = System.Drawing.Color.Transparent;
            this.gbFlagCode.Controls.Add(this.FileFlagGridEX);
            this.gbFlagCode.Controls.Add(this.AddFileFlagButton);
            this.gbFlagCode.Controls.Add(this.FlagCodeMultiDropDown);
            this.gbFlagCode.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbFlagCode, "gbFlagCode");
            this.gbFlagCode.Name = "gbFlagCode";
            this.helpProvider1.SetShowHelp(this.gbFlagCode, ((bool)(resources.GetObject("gbFlagCode.ShowHelp"))));
            this.gbFlagCode.UseThemes = false;
            // 
            // FileFlagGridEX
            // 
            this.FileFlagGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileFlagGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.FileFlagGridEX.DataSource = this.FileFlagBindingSource;
            FileFlagGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("FileFlagGridEX_DesignTimeLayout_Reference_0.Instance")));
            FileFlagGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            FileFlagGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(FileFlagGridEX_DesignTimeLayout, "FileFlagGridEX_DesignTimeLayout");
            this.FileFlagGridEX.DesignTimeLayout = FileFlagGridEX_DesignTimeLayout;
            this.FileFlagGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.FileFlagGridEX, "FileFlagGridEX");
            this.FileFlagGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.FileFlagGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.FileFlagGridEX.GroupByBoxVisible = false;
            this.FileFlagGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.FileFlagGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.FileFlagGridEX.Indent = 20;
            this.FileFlagGridEX.Name = "FileFlagGridEX";
            this.FileFlagGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.FileFlagGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.helpProvider1.SetShowHelp(this.FileFlagGridEX, ((bool)(resources.GetObject("FileFlagGridEX.ShowHelp"))));
            this.FileFlagGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.FileFlagGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.FileFlagGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.FileFlagGridEX_ColumnButtonClick);
            // 
            // FileFlagBindingSource
            // 
            this.FileFlagBindingSource.DataMember = "FileFlag";
            this.FileFlagBindingSource.DataSource = typeof(lmDatasets.atriumDB);
            // 
            // AddFileFlagButton
            // 
            this.AddFileFlagButton.Image = global::LawMate.Properties.Resources.issue;
            resources.ApplyResources(this.AddFileFlagButton, "AddFileFlagButton");
            this.AddFileFlagButton.Name = "AddFileFlagButton";
            this.helpProvider1.SetShowHelp(this.AddFileFlagButton, ((bool)(resources.GetObject("AddFileFlagButton.ShowHelp"))));
            this.AddFileFlagButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.AddFileFlagButton.Click += new System.EventHandler(this.AddFileFlagButton_Click);
            // 
            // FlagCodeMultiDropDown
            // 
            this.FlagCodeMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.FlagCodeMultiDropDown.Column1 = "FlagCode";
            resources.ApplyResources(this.FlagCodeMultiDropDown, "FlagCodeMultiDropDown");
            this.FlagCodeMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.FlagCodeMultiDropDown.DataSource = null;
            this.FlagCodeMultiDropDown.DDColumn1Visible = false;
            this.FlagCodeMultiDropDown.DropDownColumn1Width = 100;
            this.FlagCodeMultiDropDown.DropDownColumn2Width = 300;
            this.FlagCodeMultiDropDown.Name = "FlagCodeMultiDropDown";
            this.FlagCodeMultiDropDown.ReadOnly = false;
            this.FlagCodeMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.FlagCodeMultiDropDown.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.FlagCodeMultiDropDown, ((bool)(resources.GetObject("FlagCodeMultiDropDown.ShowHelp"))));
            this.FlagCodeMultiDropDown.ValueMember = "FlagCode";
            this.FlagCodeMultiDropDown.ASelectedValueChanged += new System.EventHandler(this.FlagCodeMulti_SelectedValueChanged);
            // 
            // gbIS
            // 
            this.gbIS.BackColor = System.Drawing.Color.Transparent;
            this.gbIS.Controls.Add(Received365Datelabel);
            this.gbIS.Controls.Add(this.Received365DatecalendarCombo);
            this.gbIS.Controls.Add(label1);
            this.gbIS.Controls.Add(this.calendarCombo1);
            this.gbIS.Controls.Add(this.isIncapacitatedUICheckBox);
            this.gbIS.Controls.Add(this.isDeceasedUICheckBox);
            this.gbIS.Controls.Add(this.disabledUICheckBox);
            this.gbIS.Controls.Add(this.mQPAgreedUICheckBox);
            this.gbIS.Controls.Add(mQPDateLabel);
            this.gbIS.Controls.Add(this.mQPDateCalendarCombo);
            this.gbIS.Controls.Add(this.maxRetroactivityUICheckBox);
            this.gbIS.Controls.Add(paymentDateLabel);
            this.gbIS.Controls.Add(this.paymentDateCalendarCombo);
            this.gbIS.Controls.Add(deemedDisabilityDateLabel);
            this.gbIS.Controls.Add(this.deemedDisabilityDateCalendarCombo);
            this.gbIS.Controls.Add(onsetDateLabel);
            this.gbIS.Controls.Add(this.onsetDateCalendarCombo);
            this.gbIS.Controls.Add(applicationDateLabel);
            this.gbIS.Controls.Add(this.applicationDateCalendarCombo);
            this.gbIS.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbIS, "gbIS");
            this.gbIS.Name = "gbIS";
            this.helpProvider1.SetShowHelp(this.gbIS, ((bool)(resources.GetObject("gbIS.ShowHelp"))));
            this.gbIS.UseThemes = false;
            // 
            // Received365DatecalendarCombo
            // 
            this.Received365DatecalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.Received365DatecalendarCombo, "Received365DatecalendarCombo");
            this.Received365DatecalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "Received365Date", true));
            // 
            // 
            // 
            this.Received365DatecalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.Received365DatecalendarCombo.Name = "Received365DatecalendarCombo";
            this.Received365DatecalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.Received365DatecalendarCombo, ((bool)(resources.GetObject("Received365DatecalendarCombo.ShowHelp"))));
            this.Received365DatecalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // sSTCaseBindingSource
            // 
            this.sSTCaseBindingSource.DataMember = "SSTCase";
            this.sSTCaseBindingSource.DataSource = typeof(lmDatasets.SST);
            this.sSTCaseBindingSource.CurrentChanged += new System.EventHandler(this.sSTCaseBindingSource_CurrentChanged);
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "BenefitStartDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo1, ((bool)(resources.GetObject("calendarCombo1.ShowHelp"))));
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // isIncapacitatedUICheckBox
            // 
            this.isIncapacitatedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isIncapacitatedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "IsIncapacitated", true));
            resources.ApplyResources(this.isIncapacitatedUICheckBox, "isIncapacitatedUICheckBox");
            this.isIncapacitatedUICheckBox.Name = "isIncapacitatedUICheckBox";
            this.helpProvider1.SetShowHelp(this.isIncapacitatedUICheckBox, ((bool)(resources.GetObject("isIncapacitatedUICheckBox.ShowHelp"))));
            this.isIncapacitatedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // isDeceasedUICheckBox
            // 
            this.isDeceasedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.isDeceasedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "IsDeceased", true));
            resources.ApplyResources(this.isDeceasedUICheckBox, "isDeceasedUICheckBox");
            this.isDeceasedUICheckBox.Name = "isDeceasedUICheckBox";
            this.helpProvider1.SetShowHelp(this.isDeceasedUICheckBox, ((bool)(resources.GetObject("isDeceasedUICheckBox.ShowHelp"))));
            this.isDeceasedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // disabledUICheckBox
            // 
            this.disabledUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.disabledUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "Disabled", true));
            resources.ApplyResources(this.disabledUICheckBox, "disabledUICheckBox");
            this.disabledUICheckBox.Name = "disabledUICheckBox";
            this.helpProvider1.SetShowHelp(this.disabledUICheckBox, ((bool)(resources.GetObject("disabledUICheckBox.ShowHelp"))));
            this.disabledUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // mQPAgreedUICheckBox
            // 
            this.mQPAgreedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mQPAgreedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "MQPAgreed", true));
            resources.ApplyResources(this.mQPAgreedUICheckBox, "mQPAgreedUICheckBox");
            this.mQPAgreedUICheckBox.Name = "mQPAgreedUICheckBox";
            this.helpProvider1.SetShowHelp(this.mQPAgreedUICheckBox, ((bool)(resources.GetObject("mQPAgreedUICheckBox.ShowHelp"))));
            this.mQPAgreedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // mQPDateCalendarCombo
            // 
            this.mQPDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.mQPDateCalendarCombo, "mQPDateCalendarCombo");
            this.mQPDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "MQPDate", true));
            // 
            // 
            // 
            this.mQPDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.mQPDateCalendarCombo.Name = "mQPDateCalendarCombo";
            this.mQPDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.mQPDateCalendarCombo, ((bool)(resources.GetObject("mQPDateCalendarCombo.ShowHelp"))));
            this.mQPDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // maxRetroactivityUICheckBox
            // 
            this.maxRetroactivityUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.maxRetroactivityUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "MaxRetroactivity", true));
            resources.ApplyResources(this.maxRetroactivityUICheckBox, "maxRetroactivityUICheckBox");
            this.maxRetroactivityUICheckBox.Name = "maxRetroactivityUICheckBox";
            this.helpProvider1.SetShowHelp(this.maxRetroactivityUICheckBox, ((bool)(resources.GetObject("maxRetroactivityUICheckBox.ShowHelp"))));
            this.maxRetroactivityUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // paymentDateCalendarCombo
            // 
            this.paymentDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.paymentDateCalendarCombo, "paymentDateCalendarCombo");
            this.paymentDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "PaymentDate", true));
            // 
            // 
            // 
            this.paymentDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.paymentDateCalendarCombo.Name = "paymentDateCalendarCombo";
            this.paymentDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.paymentDateCalendarCombo, ((bool)(resources.GetObject("paymentDateCalendarCombo.ShowHelp"))));
            this.paymentDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // deemedDisabilityDateCalendarCombo
            // 
            this.deemedDisabilityDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.deemedDisabilityDateCalendarCombo, "deemedDisabilityDateCalendarCombo");
            this.deemedDisabilityDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "DeemedDisabilityDate", true));
            // 
            // 
            // 
            this.deemedDisabilityDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.deemedDisabilityDateCalendarCombo.Name = "deemedDisabilityDateCalendarCombo";
            this.deemedDisabilityDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.deemedDisabilityDateCalendarCombo, ((bool)(resources.GetObject("deemedDisabilityDateCalendarCombo.ShowHelp"))));
            this.deemedDisabilityDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // onsetDateCalendarCombo
            // 
            this.onsetDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.onsetDateCalendarCombo, "onsetDateCalendarCombo");
            this.onsetDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "OnsetDate", true));
            // 
            // 
            // 
            this.onsetDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.onsetDateCalendarCombo.Name = "onsetDateCalendarCombo";
            this.onsetDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.onsetDateCalendarCombo, ((bool)(resources.GetObject("onsetDateCalendarCombo.ShowHelp"))));
            this.onsetDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // applicationDateCalendarCombo
            // 
            this.applicationDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.applicationDateCalendarCombo, "applicationDateCalendarCombo");
            this.applicationDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "ApplicationDate", true));
            // 
            // 
            // 
            this.applicationDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.applicationDateCalendarCombo.Name = "applicationDateCalendarCombo";
            this.applicationDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.applicationDateCalendarCombo, ((bool)(resources.GetObject("applicationDateCalendarCombo.ShowHelp"))));
            this.applicationDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // gbEI
            // 
            this.gbEI.BackColor = System.Drawing.Color.Transparent;
            this.gbEI.Controls.Add(benefitStartDateLabel);
            this.gbEI.Controls.Add(this.voluntaryUICheckBox);
            this.gbEI.Controls.Add(this.benefitStartDateCalendarCombo);
            this.gbEI.Controls.Add(terminationDateLabel);
            this.gbEI.Controls.Add(this.terminationDateCalendarCombo);
            this.gbEI.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.gbEI, "gbEI");
            this.gbEI.Name = "gbEI";
            this.helpProvider1.SetShowHelp(this.gbEI, ((bool)(resources.GetObject("gbEI.ShowHelp"))));
            this.gbEI.UseThemes = false;
            // 
            // voluntaryUICheckBox
            // 
            this.voluntaryUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.voluntaryUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "Voluntary", true));
            resources.ApplyResources(this.voluntaryUICheckBox, "voluntaryUICheckBox");
            this.voluntaryUICheckBox.Name = "voluntaryUICheckBox";
            this.helpProvider1.SetShowHelp(this.voluntaryUICheckBox, ((bool)(resources.GetObject("voluntaryUICheckBox.ShowHelp"))));
            this.voluntaryUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // benefitStartDateCalendarCombo
            // 
            this.benefitStartDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.benefitStartDateCalendarCombo, "benefitStartDateCalendarCombo");
            this.benefitStartDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "BenefitStartDate", true));
            // 
            // 
            // 
            this.benefitStartDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.benefitStartDateCalendarCombo.Name = "benefitStartDateCalendarCombo";
            this.benefitStartDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.benefitStartDateCalendarCombo, ((bool)(resources.GetObject("benefitStartDateCalendarCombo.ShowHelp"))));
            this.benefitStartDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // terminationDateCalendarCombo
            // 
            this.terminationDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.terminationDateCalendarCombo, "terminationDateCalendarCombo");
            this.terminationDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.sSTCaseBindingSource, "TerminationDate", true));
            // 
            // 
            // 
            this.terminationDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.terminationDateCalendarCombo.Name = "terminationDateCalendarCombo";
            this.terminationDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.terminationDateCalendarCombo, ((bool)(resources.GetObject("terminationDateCalendarCombo.ShowHelp"))));
            this.terminationDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // sSTDecisionBindingSource
            // 
            this.sSTDecisionBindingSource.DataMember = "SSTCase_SSTDecision";
            this.sSTDecisionBindingSource.DataSource = this.sSTCaseBindingSource;
            // 
            // sST
            // 
            this.sST.DataSetName = "SST";
            this.sST.EnforceConstraints = false;
            this.sST.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
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
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
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
            // ucSSTDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucSSTDetail";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbFlagCode)).EndInit();
            this.gbFlagCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileFlagGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileFlagBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbIS)).EndInit();
            this.gbIS.ResumeLayout(false);
            this.gbIS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSTCaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbEI)).EndInit();
            this.gbEI.ResumeLayout(false);
            this.gbEI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sSTDecisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
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
        private lmDatasets.SST sST;
        private System.Windows.Forms.BindingSource sSTCaseBindingSource;
        private Janus.Windows.EditControls.UIGroupBox gbIS;
        private Janus.Windows.EditControls.UIGroupBox gbEI;
        private Janus.Windows.CalendarCombo.CalendarCombo benefitStartDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox isIncapacitatedUICheckBox;
        private Janus.Windows.EditControls.UICheckBox isDeceasedUICheckBox;
        private Janus.Windows.EditControls.UICheckBox disabledUICheckBox;
        private Janus.Windows.EditControls.UICheckBox mQPAgreedUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo mQPDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox maxRetroactivityUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo paymentDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo deemedDisabilityDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo onsetDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo applicationDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox voluntaryUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo terminationDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private Janus.Windows.CalendarCombo.CalendarCombo Received365DatecalendarCombo;
        private System.Windows.Forms.BindingSource sSTDecisionBindingSource;
        private Janus.Windows.GridEX.GridEX FileFlagGridEX;
        private System.Windows.Forms.BindingSource FileFlagBindingSource;
        private UserControls.ucMultiDropDown FlagCodeMultiDropDown;
        private Janus.Windows.EditControls.UIButton AddFileFlagButton;
        private Janus.Windows.EditControls.UIGroupBox gbFlagCode;
    }
}
