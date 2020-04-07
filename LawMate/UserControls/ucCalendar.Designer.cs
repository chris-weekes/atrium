 namespace LawMate
{
     partial class ucCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCalendar));
            Janus.Windows.Schedule.ScheduleLayout schedule1_DesignTimeLayout = new Janus.Windows.Schedule.ScheduleLayout();
            Janus.Windows.GridEX.GridEXLayout attendeeGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.AppointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.atriumDB = new lmDatasets.atriumDB();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanelGroup1 = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlLeft = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLeftContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlLeftNav = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLeftNavContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.calendar1 = new Janus.Windows.Schedule.Calendar();
            this.schedule1 = new Janus.Windows.Schedule.Schedule();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.vacationUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.tentativeUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.lblTZ = new System.Windows.Forms.Label();
            this.attendeeGridEX = new Janus.Windows.GridEX.GridEX();
            this.attendeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.endDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.startDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.subjectEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.calMonthDisplay = new System.Windows.Forms.Label();
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.attendeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditMode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdRefreshCal1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRefreshCal");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdArrange1 = new Janus.Windows.UI.CommandBars.UICommand("cmdArrange");
            this.cmdGoTo1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoTo");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdJumpToFile2 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToFile");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdHearing2 = new Janus.Windows.UI.CommandBars.UICommand("cmdHearing");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditMode = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdHearing1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHearing");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.cmdOneDay = new Janus.Windows.UI.CommandBars.UICommand("cmdOneDay");
            this.cmdWorkWeek = new Janus.Windows.UI.CommandBars.UICommand("cmdWorkWeek");
            this.cmdWeek = new Janus.Windows.UI.CommandBars.UICommand("cmdWeek");
            this.cmdMonth = new Janus.Windows.UI.CommandBars.UICommand("cmdMonth");
            this.cmdGoToToday = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToToday");
            this.cmdGoToNextSevenDays = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToNextSevenDays");
            this.cmdArrange = new Janus.Windows.UI.CommandBars.UICommand("cmdArrange");
            this.cmdOneDay1 = new Janus.Windows.UI.CommandBars.UICommand("cmdOneDay");
            this.cmdWorkWeek1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWorkWeek");
            this.cmdWeek1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWeek");
            this.cmdMonth1 = new Janus.Windows.UI.CommandBars.UICommand("cmdMonth");
            this.cmdGoTo = new Janus.Windows.UI.CommandBars.UICommand("cmdGoTo");
            this.cmdGoToToday1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToToday");
            this.cmdGoToNextSevenDays1 = new Janus.Windows.UI.CommandBars.UICommand("cmdGoToNextSevenDays");
            this.cmdJumpToFile = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToFile");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdJumpToFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToFile");
            this.cmdRefreshCal = new Janus.Windows.UI.CommandBars.UICommand("cmdRefreshCal");
            this.cmdHearing = new Janus.Windows.UI.CommandBars.UICommand("cmdHearing");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGroup1)).BeginInit();
            this.uiPanelGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftNav)).BeginInit();
            this.pnlLeftNav.SuspendLayout();
            this.pnlLeftNavContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedule1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendeeGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendeeBindingSource1)).BeginInit();
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
            this.errorProvider1.DataSource = this.AppointmentBindingSource;
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
            // AppointmentBindingSource
            // 
            this.AppointmentBindingSource.DataMember = "Appointment";
            this.AppointmentBindingSource.DataSource = typeof(lmDatasets.atriumDB);
            this.AppointmentBindingSource.CurrentChanged += new System.EventHandler(this.AppointmentBindingSource_CurrentChanged);
            // 
            // subjectLabel
            // 
            resources.ApplyResources(this.subjectLabel, "subjectLabel");
            this.subjectLabel.BackColor = System.Drawing.Color.Transparent;
            this.subjectLabel.Name = "subjectLabel";
            this.helpProvider1.SetShowHelp(this.subjectLabel, ((bool)(resources.GetObject("subjectLabel.ShowHelp"))));
            // 
            // startDateLabel
            // 
            resources.ApplyResources(this.startDateLabel, "startDateLabel");
            this.startDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.startDateLabel.Name = "startDateLabel";
            this.helpProvider1.SetShowHelp(this.startDateLabel, ((bool)(resources.GetObject("startDateLabel.ShowHelp"))));
            // 
            // endDateLabel
            // 
            resources.ApplyResources(this.endDateLabel, "endDateLabel");
            this.endDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.endDateLabel.Name = "endDateLabel";
            this.helpProvider1.SetShowHelp(this.endDateLabel, ((bool)(resources.GetObject("endDateLabel.ShowHelp"))));
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelGroup1.Id = new System.Guid("b4e87733-5fdc-434e-aa11-660e3711de0b");
            this.pnlLeft.Id = new System.Guid("f8fa8fa6-8d44-45e4-9fc8-baac2a4859aa");
            this.uiPanelGroup1.Panels.Add(this.pnlLeft);
            this.pnlLeftNav.Id = new System.Guid("67e362bc-eda4-47a3-b125-bcd44e52f6c8");
            this.uiPanelGroup1.Panels.Add(this.pnlLeftNav);
            this.uiPanelManager1.Panels.Add(this.uiPanelGroup1);
            this.uiPanel0.Id = new System.Guid("9be751dc-63a7-44f6-a24b-d7a32c14ad7a");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b4e87733-5fdc-434e-aa11-660e3711de0b"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, false, new System.Drawing.Size(313, 426), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("f8fa8fa6-8d44-45e4-9fc8-baac2a4859aa"), new System.Guid("b4e87733-5fdc-434e-aa11-660e3711de0b"), 143, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("67e362bc-eda4-47a3-b125-bcd44e52f6c8"), new System.Guid("b4e87733-5fdc-434e-aa11-660e3711de0b"), 426, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(565, 396), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("9be751dc-63a7-44f6-a24b-d7a32c14ad7a"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(565, 30), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("67e362bc-eda4-47a3-b125-bcd44e52f6c8"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("60761fca-45ea-4f67-86e3-e202aefcb5d1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f8fa8fa6-8d44-45e4-9fc8-baac2a4859aa"), new System.Drawing.Point(322, 338), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("9be751dc-63a7-44f6-a24b-d7a32c14ad7a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanelGroup1
            // 
            resources.ApplyResources(this.uiPanelGroup1, "uiPanelGroup1");
            this.uiPanelGroup1.Name = "uiPanelGroup1";
            this.helpProvider1.SetShowHelp(this.uiPanelGroup1, ((bool)(resources.GetObject("uiPanelGroup1.ShowHelp"))));
            // 
            // pnlLeft
            // 
            this.pnlLeft.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.FloatingLocation = new System.Drawing.Point(322, 338);
            this.pnlLeft.InnerContainer = this.pnlLeftContainer;
            this.pnlLeft.Name = "pnlLeft";
            this.helpProvider1.SetShowHelp(this.pnlLeft, ((bool)(resources.GetObject("pnlLeft.ShowHelp"))));
            // 
            // pnlLeftContainer
            // 
            resources.ApplyResources(this.pnlLeftContainer, "pnlLeftContainer");
            this.pnlLeftContainer.Name = "pnlLeftContainer";
            this.helpProvider1.SetShowHelp(this.pnlLeftContainer, ((bool)(resources.GetObject("pnlLeftContainer.ShowHelp"))));
            // 
            // pnlLeftNav
            // 
            this.pnlLeftNav.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlLeftNav.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlLeftNav.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.pnlLeftNav.CaptionFormatStyle.FontSize = 7F;
            resources.ApplyResources(this.pnlLeftNav, "pnlLeftNav");
            this.pnlLeftNav.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlLeftNav.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlLeftNav.InnerContainer = this.pnlLeftNavContainer;
            this.pnlLeftNav.Name = "pnlLeftNav";
            this.helpProvider1.SetShowHelp(this.pnlLeftNav, ((bool)(resources.GetObject("pnlLeftNav.ShowHelp"))));
            // 
            // pnlLeftNavContainer
            // 
            resources.ApplyResources(this.pnlLeftNavContainer, "pnlLeftNavContainer");
            this.pnlLeftNavContainer.Controls.Add(this.calendar1);
            this.pnlLeftNavContainer.Controls.Add(this.vacationUICheckBox);
            this.pnlLeftNavContainer.Controls.Add(this.tentativeUICheckBox);
            this.pnlLeftNavContainer.Controls.Add(this.lblTZ);
            this.pnlLeftNavContainer.Controls.Add(this.attendeeGridEX);
            this.pnlLeftNavContainer.Controls.Add(this.endDateLabel);
            this.pnlLeftNavContainer.Controls.Add(this.endDateCalendarCombo);
            this.pnlLeftNavContainer.Controls.Add(this.startDateLabel);
            this.pnlLeftNavContainer.Controls.Add(this.startDateCalendarCombo);
            this.pnlLeftNavContainer.Controls.Add(this.subjectEditBox);
            this.pnlLeftNavContainer.Controls.Add(this.subjectLabel);
            this.pnlLeftNavContainer.Name = "pnlLeftNavContainer";
            this.helpProvider1.SetShowHelp(this.pnlLeftNavContainer, ((bool)(resources.GetObject("pnlLeftNavContainer.ShowHelp"))));
            // 
            // calendar1
            // 
            this.calendar1.FirstMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            resources.ApplyResources(this.calendar1, "calendar1");
            this.calendar1.Name = "calendar1";
            this.calendar1.Schedule = this.schedule1;
            this.calendar1.SelectionStyle = Janus.Windows.Schedule.CalendarSelectionStyle.Schedule;
            this.helpProvider1.SetShowHelp(this.calendar1, ((bool)(resources.GetObject("calendar1.ShowHelp"))));
            this.calendar1.VisualStyle = Janus.Windows.Schedule.VisualStyle.Office2010;
            this.calendar1.CurrentDateChanged += new System.EventHandler(this.Calendar_CurrentDateChanged);
            // 
            // schedule1
            // 
            this.schedule1.AcceptsTab = false;
            this.schedule1.AllowAppointmentDrag = Janus.Windows.Schedule.AllowAppointmentDrag.None;
            this.schedule1.AllowDelete = false;
            this.schedule1.AllowEdit = false;
            this.schedule1.BorderStyle = Janus.Windows.Schedule.BorderStyle.None;
            this.schedule1.CustomDateFormat = "yyyy\'/\'MM\'/\'dd";
            this.schedule1.DataSource = this.AppointmentBindingSource;
            resources.ApplyResources(this.schedule1, "schedule1");
            this.schedule1.DayEndHour = 20;
            this.schedule1.DayStartHour = 7;
            this.schedule1.DescriptionMember = "Description";
            schedule1_DesignTimeLayout.DataSource = this.AppointmentBindingSource;
            resources.ApplyResources(schedule1_DesignTimeLayout, "schedule1_DesignTimeLayout");
            this.schedule1.DesignTimeLayout = schedule1_DesignTimeLayout;
            this.schedule1.EndTimeMember = "EndDateLocal";
            this.schedule1.FirstVisibleTime = System.TimeSpan.Parse("00:00:00");
            this.schedule1.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.schedule1.HideSelection = Janus.Windows.Schedule.HideSelection.HighlightInactive;
            this.schedule1.HighlightCurrentTime = Janus.Windows.Schedule.TriState.True;
            this.schedule1.ImageList = this.imageList1;
            this.schedule1.Name = "schedule1";
            this.schedule1.OfficeScrollBarStyle = Janus.Windows.Schedule.OfficeScrollBarStyle.Light;
            this.helpProvider1.SetShowHelp(this.schedule1, ((bool)(resources.GetObject("schedule1.ShowHelp"))));
            this.schedule1.ShowWeekHeaders = Janus.Windows.Schedule.TriState.False;
            this.schedule1.StartTimeMember = "StartDateLocal";
            this.schedule1.TextMember = "Subject";
            this.schedule1.TimeNavigatorFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.schedule1.TimeNavigatorFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(223)))));
            this.schedule1.VerticalScrollPosition = 52;
            this.schedule1.View = Janus.Windows.Schedule.ScheduleView.MonthView;
            this.schedule1.VisualStyle = Janus.Windows.Schedule.VisualStyle.Office2010;
            this.schedule1.AppointmentRead += new Janus.Windows.Schedule.AppointmentEventHandler(this.schedule1_AppointmentRead);
            this.schedule1.AppointmentDoubleClick += new Janus.Windows.Schedule.AppointmentEventHandler(this.schedule1_AppointmentDoubleClick);
            this.schedule1.SelectedAppointmentsChanged += new System.EventHandler(this.schedule1_SelectedAppointmentsChanged);
            this.schedule1.Scroll += new System.EventHandler(this.schedule1_Scroll);
            this.schedule1.DatesChanged += new System.EventHandler(this.Schedule_DateChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "yellowLight.gif");
            this.imageList1.Images.SetKeyName(1, "greenLight.gif");
            this.imageList1.Images.SetKeyName(2, "redLight.gif");
            this.imageList1.Images.SetKeyName(3, "recurrence.png");
            // 
            // vacationUICheckBox
            // 
            this.vacationUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.vacationUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.AppointmentBindingSource, "Vacation", true));
            resources.ApplyResources(this.vacationUICheckBox, "vacationUICheckBox");
            this.vacationUICheckBox.Name = "vacationUICheckBox";
            this.helpProvider1.SetShowHelp(this.vacationUICheckBox, ((bool)(resources.GetObject("vacationUICheckBox.ShowHelp"))));
            this.vacationUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // tentativeUICheckBox
            // 
            this.tentativeUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.tentativeUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.AppointmentBindingSource, "Tentative", true));
            resources.ApplyResources(this.tentativeUICheckBox, "tentativeUICheckBox");
            this.tentativeUICheckBox.Name = "tentativeUICheckBox";
            this.helpProvider1.SetShowHelp(this.tentativeUICheckBox, ((bool)(resources.GetObject("tentativeUICheckBox.ShowHelp"))));
            this.tentativeUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // lblTZ
            // 
            resources.ApplyResources(this.lblTZ, "lblTZ");
            this.lblTZ.BackColor = System.Drawing.Color.Transparent;
            this.lblTZ.Name = "lblTZ";
            this.helpProvider1.SetShowHelp(this.lblTZ, ((bool)(resources.GetObject("lblTZ.ShowHelp"))));
            // 
            // attendeeGridEX
            // 
            resources.ApplyResources(this.attendeeGridEX, "attendeeGridEX");
            this.attendeeGridEX.DataSource = this.attendeeBindingSource;
            resources.ApplyResources(attendeeGridEX_DesignTimeLayout, "attendeeGridEX_DesignTimeLayout");
            this.attendeeGridEX.DesignTimeLayout = attendeeGridEX_DesignTimeLayout;
            this.attendeeGridEX.GridLines = Janus.Windows.GridEX.GridLines.RowOutline;
            this.attendeeGridEX.GroupByBoxVisible = false;
            this.attendeeGridEX.Name = "attendeeGridEX";
            this.attendeeGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.helpProvider1.SetShowHelp(this.attendeeGridEX, ((bool)(resources.GetObject("attendeeGridEX.ShowHelp"))));
            this.attendeeGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.attendeeGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.attendeeGridEX_LoadingRow);
            // 
            // attendeeBindingSource
            // 
            this.attendeeBindingSource.DataMember = "Appointment_Attendee";
            this.attendeeBindingSource.DataSource = this.AppointmentBindingSource;
            // 
            // endDateCalendarCombo
            // 
            resources.ApplyResources(this.endDateCalendarCombo, "endDateCalendarCombo");
            this.endDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.AppointmentBindingSource, "EndDateLocal", true));
            // 
            // 
            // 
            this.endDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.Name = "endDateCalendarCombo";
            this.endDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.endDateCalendarCombo, ((bool)(resources.GetObject("endDateCalendarCombo.ShowHelp"))));
            this.endDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // startDateCalendarCombo
            // 
            resources.ApplyResources(this.startDateCalendarCombo, "startDateCalendarCombo");
            this.startDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.AppointmentBindingSource, "StartDateLocal", true));
            // 
            // 
            // 
            this.startDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startDateCalendarCombo.Name = "startDateCalendarCombo";
            this.startDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.startDateCalendarCombo, ((bool)(resources.GetObject("startDateCalendarCombo.ShowHelp"))));
            this.startDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // subjectEditBox
            // 
            this.subjectEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.AppointmentBindingSource, "Subject", true));
            resources.ApplyResources(this.subjectEditBox, "subjectEditBox");
            this.subjectEditBox.Multiline = true;
            this.subjectEditBox.Name = "subjectEditBox";
            this.subjectEditBox.ReadOnly = true;
            this.subjectEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.subjectEditBox, ((bool)(resources.GetObject("subjectEditBox.ShowHelp"))));
            this.subjectEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiPanel0
            // 
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            resources.ApplyResources(this.uiPanel0, "uiPanel0");
            this.uiPanel0.Name = "uiPanel0";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.calMonthDisplay);
            resources.ApplyResources(this.uiPanel0Container, "uiPanel0Container");
            this.uiPanel0Container.Name = "uiPanel0Container";
            // 
            // calMonthDisplay
            // 
            this.calMonthDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.calMonthDisplay, "calMonthDisplay");
            this.calMonthDisplay.Name = "calMonthDisplay";
            // 
            // pnlAll
            // 
            this.pnlAll.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlAll.BorderPanel = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlAll.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.schedule1);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // attendeeBindingSource1
            // 
            this.attendeeBindingSource1.DataMember = "Attendee";
            this.attendeeBindingSource1.DataSource = this.atriumDB;
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
            this.tsDelete,
            this.tsScreenTitle,
            this.tsEditMode,
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit,
            this.cmdOneDay,
            this.cmdWorkWeek,
            this.cmdWeek,
            this.cmdMonth,
            this.cmdGoToToday,
            this.cmdGoToNextSevenDays,
            this.cmdArrange,
            this.cmdGoTo,
            this.cmdJumpToFile,
            this.cmdView,
            this.cmdRefreshCal,
            this.cmdHearing});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = global::LawMate.Properties.Resources.UICannotEditAppointment;
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
            this.cmdEdit1,
            this.cmdView1});
            this.uiCommandBar1.FullRow = true;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            resources.ApplyResources(this.cmdEdit1, "cmdEdit1");
            this.cmdEdit1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // cmdView1
            // 
            resources.ApplyResources(this.cmdView1, "cmdView1");
            this.cmdView1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView1.Name = "cmdView1";
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
            this.tsDelete2,
            this.cmdRefreshCal1,
            this.Separator3,
            this.cmdArrange1,
            this.cmdGoTo1,
            this.Separator6,
            this.cmdJumpToFile2,
            this.Separator2,
            this.cmdHearing2,
            this.Separator5,
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
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // cmdRefreshCal1
            // 
            resources.ApplyResources(this.cmdRefreshCal1, "cmdRefreshCal1");
            this.cmdRefreshCal1.Name = "cmdRefreshCal1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdArrange1
            // 
            this.cmdArrange1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdArrange1, "cmdArrange1");
            this.cmdArrange1.Name = "cmdArrange1";
            // 
            // cmdGoTo1
            // 
            this.cmdGoTo1.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdGoTo1, "cmdGoTo1");
            this.cmdGoTo1.Name = "cmdGoTo1";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdJumpToFile2
            // 
            resources.ApplyResources(this.cmdJumpToFile2, "cmdJumpToFile2");
            this.cmdJumpToFile2.Name = "cmdJumpToFile2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdHearing2
            // 
            this.cmdHearing2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.cmdHearing2, "cmdHearing2");
            this.cmdHearing2.Name = "cmdHearing2";
            this.cmdHearing2.Visible = Janus.Windows.UI.InheritableBoolean.True;
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
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
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdHearing1,
            this.Separator4,
            this.tsDelete1});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdHearing1
            // 
            resources.ApplyResources(this.cmdHearing1, "cmdHearing1");
            this.cmdHearing1.Name = "cmdHearing1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
            // 
            // cmdOneDay
            // 
            resources.ApplyResources(this.cmdOneDay, "cmdOneDay");
            this.cmdOneDay.Name = "cmdOneDay";
            // 
            // cmdWorkWeek
            // 
            resources.ApplyResources(this.cmdWorkWeek, "cmdWorkWeek");
            this.cmdWorkWeek.Name = "cmdWorkWeek";
            // 
            // cmdWeek
            // 
            resources.ApplyResources(this.cmdWeek, "cmdWeek");
            this.cmdWeek.Name = "cmdWeek";
            // 
            // cmdMonth
            // 
            resources.ApplyResources(this.cmdMonth, "cmdMonth");
            this.cmdMonth.Name = "cmdMonth";
            // 
            // cmdGoToToday
            // 
            resources.ApplyResources(this.cmdGoToToday, "cmdGoToToday");
            this.cmdGoToToday.Name = "cmdGoToToday";
            // 
            // cmdGoToNextSevenDays
            // 
            resources.ApplyResources(this.cmdGoToNextSevenDays, "cmdGoToNextSevenDays");
            this.cmdGoToNextSevenDays.Name = "cmdGoToNextSevenDays";
            // 
            // cmdArrange
            // 
            this.cmdArrange.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdOneDay1,
            this.cmdWorkWeek1,
            this.cmdWeek1,
            this.cmdMonth1});
            this.cmdArrange.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdArrange.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdArrange, "cmdArrange");
            this.cmdArrange.Name = "cmdArrange";
            // 
            // cmdOneDay1
            // 
            resources.ApplyResources(this.cmdOneDay1, "cmdOneDay1");
            this.cmdOneDay1.Name = "cmdOneDay1";
            // 
            // cmdWorkWeek1
            // 
            resources.ApplyResources(this.cmdWorkWeek1, "cmdWorkWeek1");
            this.cmdWorkWeek1.Name = "cmdWorkWeek1";
            // 
            // cmdWeek1
            // 
            resources.ApplyResources(this.cmdWeek1, "cmdWeek1");
            this.cmdWeek1.Name = "cmdWeek1";
            // 
            // cmdMonth1
            // 
            resources.ApplyResources(this.cmdMonth1, "cmdMonth1");
            this.cmdMonth1.Name = "cmdMonth1";
            // 
            // cmdGoTo
            // 
            this.cmdGoTo.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdGoToToday1,
            this.cmdGoToNextSevenDays1});
            this.cmdGoTo.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdGoTo.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.cmdGoTo, "cmdGoTo");
            this.cmdGoTo.Name = "cmdGoTo";
            // 
            // cmdGoToToday1
            // 
            resources.ApplyResources(this.cmdGoToToday1, "cmdGoToToday1");
            this.cmdGoToToday1.Name = "cmdGoToToday1";
            // 
            // cmdGoToNextSevenDays1
            // 
            resources.ApplyResources(this.cmdGoToNextSevenDays1, "cmdGoToNextSevenDays1");
            this.cmdGoToNextSevenDays1.Name = "cmdGoToNextSevenDays1";
            // 
            // cmdJumpToFile
            // 
            this.cmdJumpToFile.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdJumpToFile, "cmdJumpToFile");
            this.cmdJumpToFile.Name = "cmdJumpToFile";
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdJumpToFile1});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.Name = "cmdView";
            // 
            // cmdJumpToFile1
            // 
            resources.ApplyResources(this.cmdJumpToFile1, "cmdJumpToFile1");
            this.cmdJumpToFile1.Name = "cmdJumpToFile1";
            // 
            // cmdRefreshCal
            // 
            this.cmdRefreshCal.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdRefreshCal, "cmdRefreshCal");
            this.cmdRefreshCal.Name = "cmdRefreshCal";
            // 
            // cmdHearing
            // 
            this.cmdHearing.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdHearing.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            this.cmdHearing.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.cmdHearing, "cmdHearing");
            this.cmdHearing.Name = "cmdHearing";
            this.cmdHearing.Visible = Janus.Windows.UI.InheritableBoolean.False;
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
            // ucCalendar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.uiPanelGroup1);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucCalendar";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGroup1)).EndInit();
            this.uiPanelGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeftNav)).EndInit();
            this.pnlLeftNav.ResumeLayout(false);
            this.pnlLeftNavContainer.ResumeLayout(false);
            this.pnlLeftNavContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedule1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendeeGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attendeeBindingSource1)).EndInit();
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
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private lmDatasets.atriumDB atriumDB;
        private System.Windows.Forms.BindingSource AppointmentBindingSource;
        private Janus.Windows.Schedule.Schedule schedule1;
        private Janus.Windows.UI.Dock.UIPanel pnlLeftNav;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLeftNavContainer;
        private Janus.Windows.UI.CommandBars.UICommand cmdOneDay;
        private Janus.Windows.UI.CommandBars.UICommand cmdWorkWeek;
        private Janus.Windows.UI.CommandBars.UICommand cmdWeek;
        private Janus.Windows.UI.CommandBars.UICommand cmdMonth;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToToday;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToNextSevenDays;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private System.Windows.Forms.BindingSource attendeeBindingSource;
        private Janus.Windows.GridEX.EditControls.EditBox subjectEditBox;
        private Janus.Windows.UI.CommandBars.UICommand cmdArrange1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoTo1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdArrange;
        private Janus.Windows.UI.CommandBars.UICommand cmdOneDay1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWorkWeek1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWeek1;
        private Janus.Windows.UI.CommandBars.UICommand cmdMonth1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoTo;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToToday1;
        private Janus.Windows.UI.CommandBars.UICommand cmdGoToNextSevenDays1;
        private Janus.Windows.UI.Dock.UIPanel pnlLeft;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLeftContainer;
        private Janus.Windows.CalendarCombo.CalendarCombo endDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo startDateCalendarCombo;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private Janus.Windows.GridEX.GridEX attendeeGridEX;
        private System.Windows.Forms.BindingSource attendeeBindingSource1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToFile2;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefreshCal1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefreshCal;
        private System.Windows.Forms.Label lblTZ;
        private Janus.Windows.EditControls.UICheckBox tentativeUICheckBox;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHearing2;
        private Janus.Windows.UI.CommandBars.UICommand cmdHearing1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHearing;
        private Janus.Windows.EditControls.UICheckBox vacationUICheckBox;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanelGroup1;
        private Janus.Windows.Schedule.Calendar calendar1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private System.Windows.Forms.Label calMonthDisplay;
    }
}
