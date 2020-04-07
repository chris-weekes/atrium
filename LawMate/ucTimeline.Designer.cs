namespace LawMate
{
    partial class ucTimeline
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label startDateLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTimeline));
            System.Windows.Forms.Label endDateLabel;
            System.Windows.Forms.Label subjectLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label lblReminder;
            Janus.Windows.TimeLine.TimeLineLayout timeLine1_DesignTimeLayout = new Janus.Windows.TimeLine.TimeLineLayout();
            this.timelineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeLine1 = new Janus.Windows.TimeLine.TimeLine();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.startDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.endDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.subjectEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnAddAttendee = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdAddAttendee = new Janus.Windows.UI.CommandBars.UICommand("cmdAddAttendee");
            this.cmdAddResource = new Janus.Windows.UI.CommandBars.UICommand("cmdAddResource");
            this.cmdRemoveAttendee = new Janus.Windows.UI.CommandBars.UICommand("cmdRemoveAttendee");
            this.uiContextMenu2 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdRemoveAttendee1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRemoveAttendee");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdAddAttendee1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddAttendee");
            this.cmdAddResource1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddResource");
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calendarCombo2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblConflict = new System.Windows.Forms.Label();
            this.lblTZ = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkTentative = new Janus.Windows.EditControls.UICheckBox();
            this.chkShowAsBusy = new Janus.Windows.EditControls.UICheckBox();
            this.chkVacation = new Janus.Windows.EditControls.UICheckBox();
            this.btnAddAttendees = new Janus.Windows.EditControls.UIButton();
            this.RecurrenceUIButton = new Janus.Windows.EditControls.UIButton();
            this.ReminderDropDown = new LawMate.UserControls.ucMultiDropDown();
            startDateLabel = new System.Windows.Forms.Label();
            endDateLabel = new System.Windows.Forms.Label();
            subjectLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lblReminder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timelineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // startDateLabel
            // 
            resources.ApplyResources(startDateLabel, "startDateLabel");
            startDateLabel.Name = "startDateLabel";
            // 
            // endDateLabel
            // 
            resources.ApplyResources(endDateLabel, "endDateLabel");
            endDateLabel.Name = "endDateLabel";
            // 
            // subjectLabel
            // 
            resources.ApplyResources(subjectLabel, "subjectLabel");
            subjectLabel.Name = "subjectLabel";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // lblReminder
            // 
            resources.ApplyResources(lblReminder, "lblReminder");
            lblReminder.Name = "lblReminder";
            // 
            // timelineBindingSource
            // 
            this.timelineBindingSource.DataMember = "TimeLine";
            this.timelineBindingSource.DataSource = typeof(lmDatasets.atriumDB);
            // 
            // timeLine1
            // 
            this.timeLine1.AllowEdit = false;
            this.timeLine1.AllowExpandRowHeader = false;
            this.timeLine1.AllowItemDrag = Janus.Windows.TimeLine.AllowItemDrag.None;
            resources.ApplyResources(this.timeLine1, "timeLine1");
            this.timeLine1.BottomTier.Count = 30;
            this.timeLine1.BottomTier.CustomFormat = "h:mm tt";
            this.timeLine1.BottomTier.Font = new System.Drawing.Font("Calibri", 8F);
            this.timeLine1.BottomTier.Interval = ((Janus.Windows.TimeLine.TimeLineInterval)(resources.GetObject("timeLine1.BottomTier.Interval")));
            this.timeLine1.DataSource = this.timelineBindingSource;
            timeLine1_DesignTimeLayout.DataSource = this.timelineBindingSource;
            resources.ApplyResources(timeLine1_DesignTimeLayout, "timeLine1_DesignTimeLayout");
            this.timeLine1.DesignTimeLayout = timeLine1_DesignTimeLayout;
            // 
            // 
            // 
            this.timeLine1.DropDownCalendar.Name = "";
            this.timeLine1.EndTimeMember = "EndDateLocal";
            this.timeLine1.FirstDate = new System.DateTime(2012, 12, 11, 16, 47, 52, 0);
            this.timeLine1.GridLines = Janus.Windows.TimeLine.GridLines.Vertical;
            this.timeLine1.GridLineStyle = Janus.Windows.TimeLine.GridLineStyle.Solid;
            this.timeLine1.ImageList = this.imageList1;
            this.timeLine1.IntervalSize = 86;
            this.timeLine1.ItemsDurationBarHeight = 16;
            this.timeLine1.ItemSizeMode = Janus.Windows.TimeLine.ItemSizeMode.DurationBased;
            this.timeLine1.ItemsLineStyle = Janus.Windows.TimeLine.ItemsLineStyle.SmallDots;
            this.timeLine1.ItemToolTip = Janus.Windows.TimeLine.ItemToolTip.UseToolTipMember;
            this.timeLine1.MiddleTier.CustomFormat = "dddd \', \' MMMM dd \', \'yyyy";
            this.timeLine1.MiddleTier.Font = new System.Drawing.Font("Calibri", 8F);
            this.timeLine1.MiddleTier.Interval = ((Janus.Windows.TimeLine.TimeLineInterval)(resources.GetObject("timeLine1.MiddleTier.Interval")));
            this.timeLine1.Name = "timeLine1";
            this.timeLine1.OfficeScrollBarStyle = Janus.Windows.TimeLine.OfficeScrollBarStyle.Light;
            this.timeLine1.RowHeaderWidth = 180;
            this.timeLine1.RowHeight = 30;
            this.timeLine1.ShowLastGroupAsRowHeader = true;
            this.timeLine1.StartTimeMember = "StartDateLocal";
            this.timeLine1.TimescaleTiers = Janus.Windows.TimeLine.TimescaleTiers.ThreeTiers;
            this.timeLine1.TooltipFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLine1.TopTier.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.timeLine1.VisualStyle = Janus.Windows.TimeLine.VisualStyle.Office2010;
            this.timeLine1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timeLine1_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "RecipientUnknown.png");
            this.imageList1.Images.SetKeyName(1, "metatype.png");
            this.imageList1.Images.SetKeyName(2, "greenLight.gif");
            this.imageList1.Images.SetKeyName(3, "redLight.gif");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // startDateCalendarCombo
            // 
            resources.ApplyResources(this.startDateCalendarCombo, "startDateCalendarCombo");
            this.startDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.appointmentBindingSource, "StartDateLocal", true));
            // 
            // 
            // 
            this.startDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startDateCalendarCombo.Name = "startDateCalendarCombo";
            this.startDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startDateCalendarCombo.ValueChanged += new System.EventHandler(this.calendarCombo1_ValueChanged);
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataMember = "Appointment";
            this.appointmentBindingSource.DataSource = this.atriumDB;
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // endDateCalendarCombo
            // 
            resources.ApplyResources(this.endDateCalendarCombo, "endDateCalendarCombo");
            this.endDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.appointmentBindingSource, "EndDateLocal", true));
            // 
            // 
            // 
            this.endDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.Name = "endDateCalendarCombo";
            this.endDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.ValueChanged += new System.EventHandler(this.calendarCombo1_ValueChanged);
            // 
            // subjectEditBox
            // 
            resources.ApplyResources(this.subjectEditBox, "subjectEditBox");
            this.subjectEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appointmentBindingSource, "Subject", true));
            this.subjectEditBox.Name = "subjectEditBox";
            this.subjectEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // btnAddAttendee
            // 
            resources.ApplyResources(this.btnAddAttendee, "btnAddAttendee");
            this.btnAddAttendee.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.btnAddAttendee.DropDownContextMenu = this.uiContextMenu1;
            this.btnAddAttendee.Name = "btnAddAttendee";
            this.btnAddAttendee.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAddAttendee1,
            this.cmdAddResource1});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdAddAttendee,
            this.cmdAddResource,
            this.cmdRemoveAttendee});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu2,
            this.uiContextMenu1});
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("44836e61-f77e-4188-a7cf-3acd61b2d402");
            this.uiCommandManager1.ImageList = this.imageList1;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            // 
            // cmdAddAttendee
            // 
            this.cmdAddAttendee.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdAddAttendee, "cmdAddAttendee");
            this.cmdAddAttendee.Name = "cmdAddAttendee";
            // 
            // cmdAddResource
            // 
            this.cmdAddResource.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdAddResource, "cmdAddResource");
            this.cmdAddResource.Name = "cmdAddResource";
            // 
            // cmdRemoveAttendee
            // 
            this.cmdRemoveAttendee.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdRemoveAttendee, "cmdRemoveAttendee");
            this.cmdRemoveAttendee.Name = "cmdRemoveAttendee";
            // 
            // uiContextMenu2
            // 
            this.uiContextMenu2.CommandManager = this.uiCommandManager1;
            this.uiContextMenu2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdRemoveAttendee1});
            resources.ApplyResources(this.uiContextMenu2, "uiContextMenu2");
            // 
            // cmdRemoveAttendee1
            // 
            resources.ApplyResources(this.cmdRemoveAttendee1, "cmdRemoveAttendee1");
            this.cmdRemoveAttendee1.Name = "cmdRemoveAttendee1";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // cmdAddAttendee1
            // 
            resources.ApplyResources(this.cmdAddAttendee1, "cmdAddAttendee1");
            this.cmdAddAttendee1.Name = "cmdAddAttendee1";
            // 
            // cmdAddResource1
            // 
            resources.ApplyResources(this.cmdAddResource1, "cmdAddResource1");
            this.cmdAddResource1.Name = "cmdAddResource1";
            // 
            // calendarCombo1
            // 
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.appointmentBindingSource, "StartDateLocal", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.calendarCombo1.MinuteIncrement = 15;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ShowDropDown = false;
            this.calendarCombo1.ShowUpDown = true;
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.ValueChanged += new System.EventHandler(this.calendarCombo1_ValueChanged);
            // 
            // calendarCombo2
            // 
            resources.ApplyResources(this.calendarCombo2, "calendarCombo2");
            this.calendarCombo2.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.appointmentBindingSource, "EndDateLocal", true));
            // 
            // 
            // 
            this.calendarCombo2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.calendarCombo2.MinuteIncrement = 15;
            this.calendarCombo2.Name = "calendarCombo2";
            this.calendarCombo2.ShowDropDown = false;
            this.calendarCombo2.ShowUpDown = true;
            this.calendarCombo2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.ValueChanged += new System.EventHandler(this.calendarCombo1_ValueChanged);
            // 
            // lblConflict
            // 
            resources.ApplyResources(this.lblConflict, "lblConflict");
            this.lblConflict.Name = "lblConflict";
            // 
            // lblTZ
            // 
            resources.ApplyResources(this.lblTZ, "lblTZ");
            this.lblTZ.BackColor = System.Drawing.Color.Transparent;
            this.lblTZ.Name = "lblTZ";
            // 
            // uiGroupBox1
            // 
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.Controls.Add(label1);
            this.uiGroupBox1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox1.Image = global::LawMate.Properties.Resources.timezone;
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.UseThemes = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.appointmentBindingSource;
            // 
            // chkTentative
            // 
            this.chkTentative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTentative.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.appointmentBindingSource, "Tentative", true));
            resources.ApplyResources(this.chkTentative, "chkTentative");
            this.chkTentative.Name = "chkTentative";
            this.chkTentative.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.chkTentative.CheckedChanged += new System.EventHandler(this.chkTentative_CheckedChanged);
            // 
            // chkShowAsBusy
            // 
            this.chkShowAsBusy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowAsBusy.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.appointmentBindingSource, "ShowAsBusy", true));
            resources.ApplyResources(this.chkShowAsBusy, "chkShowAsBusy");
            this.chkShowAsBusy.Name = "chkShowAsBusy";
            this.chkShowAsBusy.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // chkVacation
            // 
            this.chkVacation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVacation.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.appointmentBindingSource, "Vacation", true));
            resources.ApplyResources(this.chkVacation, "chkVacation");
            this.chkVacation.Name = "chkVacation";
            this.chkVacation.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.chkVacation.CheckedChanged += new System.EventHandler(this.chkVacation_CheckedChanged);
            // 
            // btnAddAttendees
            // 
            resources.ApplyResources(this.btnAddAttendees, "btnAddAttendees");
            this.btnAddAttendees.Name = "btnAddAttendees";
            this.btnAddAttendees.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnAddAttendees.Click += new System.EventHandler(this.btnAddAttendees_Click);
            // 
            // RecurrenceUIButton
            // 
            resources.ApplyResources(this.RecurrenceUIButton, "RecurrenceUIButton");
            this.RecurrenceUIButton.Name = "RecurrenceUIButton";
            this.RecurrenceUIButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.RecurrenceUIButton.Click += new System.EventHandler(this.RecurrenceUIButton_Click);
            // 
            // ReminderDropDown
            // 
            this.ReminderDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ReminderDropDown.Column1 = "Interval";
            resources.ApplyResources(this.ReminderDropDown, "ReminderDropDown");
            this.ReminderDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ReminderDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.appointmentBindingSource, "Interval", true));
            this.ReminderDropDown.DataSource = null;
            this.ReminderDropDown.DDColumn1Visible = false;
            this.ReminderDropDown.DropDownColumn1Width = 100;
            this.ReminderDropDown.DropDownColumn2Width = 300;
            this.ReminderDropDown.Name = "ReminderDropDown";
            this.ReminderDropDown.ReadOnly = false;
            this.ReminderDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.ReminderDropDown.SelectedValue = null;
            this.ReminderDropDown.ValueMember = "Interval";
            // 
            // ucTimeline
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ReminderDropDown);
            this.Controls.Add(lblReminder);
            this.Controls.Add(this.RecurrenceUIButton);
            this.Controls.Add(this.btnAddAttendees);
            this.Controls.Add(this.chkVacation);
            this.Controls.Add(this.chkShowAsBusy);
            this.Controls.Add(this.chkTentative);
            this.Controls.Add(label2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.lblTZ);
            this.Controls.Add(this.lblConflict);
            this.Controls.Add(this.calendarCombo2);
            this.Controls.Add(this.calendarCombo1);
            this.Controls.Add(this.btnAddAttendee);
            this.Controls.Add(subjectLabel);
            this.Controls.Add(this.subjectEditBox);
            this.Controls.Add(endDateLabel);
            this.Controls.Add(this.endDateCalendarCombo);
            this.Controls.Add(startDateLabel);
            this.Controls.Add(this.startDateCalendarCombo);
            this.Controls.Add(this.timeLine1);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucTimeline";
            ((System.ComponentModel.ISupportInitialize)(this.timelineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.TimeLine.TimeLine timeLine1;
        private lmDatasets.atriumDB atriumDB;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo startDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo endDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox subjectEditBox;
        private Janus.Windows.EditControls.UIButton btnAddAttendee;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddAttendee;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddResource;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddAttendee1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddResource1;
        private System.Windows.Forms.BindingSource timelineBindingSource;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo2;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private System.Windows.Forms.Label lblConflict;
        private Janus.Windows.UI.CommandBars.UICommand cmdRemoveAttendee;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu2;
        private Janus.Windows.UI.CommandBars.UICommand cmdRemoveAttendee1;
        private System.Windows.Forms.Label lblTZ;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Janus.Windows.EditControls.UICheckBox chkTentative;
        private Janus.Windows.EditControls.UICheckBox chkVacation;
        private Janus.Windows.EditControls.UICheckBox chkShowAsBusy;
        private Janus.Windows.EditControls.UIButton btnAddAttendees;
        private Janus.Windows.EditControls.UIButton RecurrenceUIButton;
        private UserControls.ucMultiDropDown ReminderDropDown;
    }
}
