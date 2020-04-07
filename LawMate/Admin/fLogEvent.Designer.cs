 namespace LawMate.Admin
{
    partial class fLogEvent
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
            System.Windows.Forms.Label eventIdLabel;
            System.Windows.Forms.Label eventTypeLabel;
            System.Windows.Forms.Label windowsUserLabel;
            System.Windows.Forms.Label lMUserLabel;
            System.Windows.Forms.Label workAsLabel;
            System.Windows.Forms.Label exTypeLabel;
            System.Windows.Forms.Label exSourceLabel;
            System.Windows.Forms.Label exMessageLabel;
            System.Windows.Forms.Label exStackLabel;
            System.Windows.Forms.Label eventTimeLabel1;
            Janus.Windows.GridEX.GridEXLayout eventLogGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogEvent));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlDetails = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDetailsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.eventTimeCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.eventIdTextBox = new System.Windows.Forms.TextBox();
            this.eventTypeTextBox = new System.Windows.Forms.TextBox();
            this.windowsUserTextBox = new System.Windows.Forms.TextBox();
            this.lMUserTextBox = new System.Windows.Forms.TextBox();
            this.workAsTextBox = new System.Windows.Forms.TextBox();
            this.exTypeTextBox = new System.Windows.Forms.TextBox();
            this.exSourceTextBox = new System.Windows.Forms.TextBox();
            this.exMessageTextBox = new System.Windows.Forms.TextBox();
            this.exStackTextBox = new System.Windows.Forms.TextBox();
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.eventLogGridEX = new Janus.Windows.GridEX.GridEX();
            eventIdLabel = new System.Windows.Forms.Label();
            eventTypeLabel = new System.Windows.Forms.Label();
            windowsUserLabel = new System.Windows.Forms.Label();
            lMUserLabel = new System.Windows.Forms.Label();
            workAsLabel = new System.Windows.Forms.Label();
            exTypeLabel = new System.Windows.Forms.Label();
            exSourceLabel = new System.Windows.Forms.Label();
            exMessageLabel = new System.Windows.Forms.Label();
            exStackLabel = new System.Windows.Forms.Label();
            eventTimeLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetails)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlDetailsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogGridEX)).BeginInit();
            this.SuspendLayout();
            // 
            // eventIdLabel
            // 
            eventIdLabel.AutoSize = true;
            eventIdLabel.BackColor = System.Drawing.Color.Transparent;
            eventIdLabel.Location = new System.Drawing.Point(15, 17);
            eventIdLabel.Name = "eventIdLabel";
            eventIdLabel.Size = new System.Drawing.Size(52, 13);
            eventIdLabel.TabIndex = 0;
            eventIdLabel.Text = "Event Id:";
            // 
            // eventTypeLabel
            // 
            eventTypeLabel.AutoSize = true;
            eventTypeLabel.BackColor = System.Drawing.Color.Transparent;
            eventTypeLabel.Location = new System.Drawing.Point(15, 71);
            eventTypeLabel.Name = "eventTypeLabel";
            eventTypeLabel.Size = new System.Drawing.Size(66, 13);
            eventTypeLabel.TabIndex = 4;
            eventTypeLabel.Text = "Event Type:";
            // 
            // windowsUserLabel
            // 
            windowsUserLabel.AutoSize = true;
            windowsUserLabel.BackColor = System.Drawing.Color.Transparent;
            windowsUserLabel.Location = new System.Drawing.Point(362, 17);
            windowsUserLabel.Name = "windowsUserLabel";
            windowsUserLabel.Size = new System.Drawing.Size(79, 13);
            windowsUserLabel.TabIndex = 6;
            windowsUserLabel.Text = "Windows User:";
            // 
            // lMUserLabel
            // 
            lMUserLabel.AutoSize = true;
            lMUserLabel.BackColor = System.Drawing.Color.Transparent;
            lMUserLabel.Location = new System.Drawing.Point(362, 45);
            lMUserLabel.Name = "lMUserLabel";
            lMUserLabel.Size = new System.Drawing.Size(79, 13);
            lMUserLabel.TabIndex = 8;
            lMUserLabel.Text = "LawMate User:";
            // 
            // workAsLabel
            // 
            workAsLabel.AutoSize = true;
            workAsLabel.BackColor = System.Drawing.Color.Transparent;
            workAsLabel.Location = new System.Drawing.Point(362, 72);
            workAsLabel.Name = "workAsLabel";
            workAsLabel.Size = new System.Drawing.Size(51, 13);
            workAsLabel.TabIndex = 10;
            workAsLabel.Text = "Work As:";
            // 
            // exTypeLabel
            // 
            exTypeLabel.AutoSize = true;
            exTypeLabel.BackColor = System.Drawing.Color.Transparent;
            exTypeLabel.Location = new System.Drawing.Point(15, 121);
            exTypeLabel.Name = "exTypeLabel";
            exTypeLabel.Size = new System.Drawing.Size(50, 13);
            exTypeLabel.TabIndex = 12;
            exTypeLabel.Text = "Ex Type:";
            // 
            // exSourceLabel
            // 
            exSourceLabel.AutoSize = true;
            exSourceLabel.BackColor = System.Drawing.Color.Transparent;
            exSourceLabel.Location = new System.Drawing.Point(15, 148);
            exSourceLabel.Name = "exSourceLabel";
            exSourceLabel.Size = new System.Drawing.Size(59, 13);
            exSourceLabel.TabIndex = 14;
            exSourceLabel.Text = "Ex Source:";
            // 
            // exMessageLabel
            // 
            exMessageLabel.AutoSize = true;
            exMessageLabel.BackColor = System.Drawing.Color.Transparent;
            exMessageLabel.Location = new System.Drawing.Point(362, 121);
            exMessageLabel.Name = "exMessageLabel";
            exMessageLabel.Size = new System.Drawing.Size(68, 13);
            exMessageLabel.TabIndex = 16;
            exMessageLabel.Text = "Ex Message:";
            // 
            // exStackLabel
            // 
            exStackLabel.AutoSize = true;
            exStackLabel.BackColor = System.Drawing.Color.Transparent;
            exStackLabel.Location = new System.Drawing.Point(15, 175);
            exStackLabel.Name = "exStackLabel";
            exStackLabel.Size = new System.Drawing.Size(52, 13);
            exStackLabel.TabIndex = 18;
            exStackLabel.Text = "Ex Stack:";
            // 
            // eventTimeLabel1
            // 
            eventTimeLabel1.AutoSize = true;
            eventTimeLabel1.BackColor = System.Drawing.Color.Transparent;
            eventTimeLabel1.Location = new System.Drawing.Point(15, 45);
            eventTimeLabel1.Name = "eventTimeLabel1";
            eventTimeLabel1.Size = new System.Drawing.Size(64, 13);
            eventTimeLabel1.TabIndex = 20;
            eventTimeLabel1.Text = "Event Time:";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlDetails.Id = new System.Guid("268d5672-7361-48b7-b959-fd0a9d5a9158");
            this.uiPanelManager1.Panels.Add(this.pnlDetails);
            this.pnlGrid.Id = new System.Guid("5eeeccd8-59a2-47b4-84be-5b8d897db3d9");
            this.uiPanelManager1.Panels.Add(this.pnlGrid);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5eeeccd8-59a2-47b4-84be-5b8d897db3d9"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(971, 318), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("268d5672-7361-48b7-b959-fd0a9d5a9158"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(971, 351), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5eeeccd8-59a2-47b4-84be-5b8d897db3d9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("268d5672-7361-48b7-b959-fd0a9d5a9158"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlDetails
            // 
            this.pnlDetails.InnerContainer = this.pnlDetailsContainer;
            this.pnlDetails.Location = new System.Drawing.Point(3, 321);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(971, 351);
            this.pnlDetails.TabIndex = 4;
            this.pnlDetails.Text = "Details";
            // 
            // pnlDetailsContainer
            // 
            this.pnlDetailsContainer.AutoScroll = true;
            this.pnlDetailsContainer.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.pnlDetailsContainer.Controls.Add(eventTimeLabel1);
            this.pnlDetailsContainer.Controls.Add(this.eventTimeCalendarCombo);
            this.pnlDetailsContainer.Controls.Add(eventIdLabel);
            this.pnlDetailsContainer.Controls.Add(this.eventIdTextBox);
            this.pnlDetailsContainer.Controls.Add(eventTypeLabel);
            this.pnlDetailsContainer.Controls.Add(this.eventTypeTextBox);
            this.pnlDetailsContainer.Controls.Add(windowsUserLabel);
            this.pnlDetailsContainer.Controls.Add(this.windowsUserTextBox);
            this.pnlDetailsContainer.Controls.Add(lMUserLabel);
            this.pnlDetailsContainer.Controls.Add(this.lMUserTextBox);
            this.pnlDetailsContainer.Controls.Add(workAsLabel);
            this.pnlDetailsContainer.Controls.Add(this.workAsTextBox);
            this.pnlDetailsContainer.Controls.Add(exTypeLabel);
            this.pnlDetailsContainer.Controls.Add(this.exTypeTextBox);
            this.pnlDetailsContainer.Controls.Add(exSourceLabel);
            this.pnlDetailsContainer.Controls.Add(this.exSourceTextBox);
            this.pnlDetailsContainer.Controls.Add(exMessageLabel);
            this.pnlDetailsContainer.Controls.Add(this.exMessageTextBox);
            this.pnlDetailsContainer.Controls.Add(exStackLabel);
            this.pnlDetailsContainer.Controls.Add(this.exStackTextBox);
            this.pnlDetailsContainer.Location = new System.Drawing.Point(1, 27);
            this.pnlDetailsContainer.Name = "pnlDetailsContainer";
            this.pnlDetailsContainer.Size = new System.Drawing.Size(969, 323);
            this.pnlDetailsContainer.TabIndex = 0;
            // 
            // eventTimeCalendarCombo
            // 
            this.eventTimeCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd hh:mm:ss";
            this.eventTimeCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.eventLogBindingSource, "EventTime", true));
            this.eventTimeCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.eventTimeCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.eventTimeCalendarCombo.Location = new System.Drawing.Point(98, 41);
            this.eventTimeCalendarCombo.Name = "eventTimeCalendarCombo";
            this.eventTimeCalendarCombo.ReadOnly = true;
            this.eventTimeCalendarCombo.Size = new System.Drawing.Size(200, 21);
            this.eventTimeCalendarCombo.TabIndex = 21;
            this.eventTimeCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.DataMember = "EventLog";
            this.eventLogBindingSource.DataSource = this.appDB;
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eventIdTextBox
            // 
            this.eventIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "EventId", true));
            this.eventIdTextBox.Location = new System.Drawing.Point(98, 14);
            this.eventIdTextBox.Name = "eventIdTextBox";
            this.eventIdTextBox.ReadOnly = true;
            this.eventIdTextBox.Size = new System.Drawing.Size(200, 21);
            this.eventIdTextBox.TabIndex = 1;
            // 
            // eventTypeTextBox
            // 
            this.eventTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "EventType", true));
            this.eventTypeTextBox.Location = new System.Drawing.Point(98, 68);
            this.eventTypeTextBox.Name = "eventTypeTextBox";
            this.eventTypeTextBox.ReadOnly = true;
            this.eventTypeTextBox.Size = new System.Drawing.Size(200, 21);
            this.eventTypeTextBox.TabIndex = 5;
            // 
            // windowsUserTextBox
            // 
            this.windowsUserTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "WindowsUser", true));
            this.windowsUserTextBox.Location = new System.Drawing.Point(447, 14);
            this.windowsUserTextBox.Name = "windowsUserTextBox";
            this.windowsUserTextBox.ReadOnly = true;
            this.windowsUserTextBox.Size = new System.Drawing.Size(471, 21);
            this.windowsUserTextBox.TabIndex = 7;
            // 
            // lMUserTextBox
            // 
            this.lMUserTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "LMUser", true));
            this.lMUserTextBox.Location = new System.Drawing.Point(447, 42);
            this.lMUserTextBox.Name = "lMUserTextBox";
            this.lMUserTextBox.ReadOnly = true;
            this.lMUserTextBox.Size = new System.Drawing.Size(471, 21);
            this.lMUserTextBox.TabIndex = 9;
            // 
            // workAsTextBox
            // 
            this.workAsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "WorkAs", true));
            this.workAsTextBox.Location = new System.Drawing.Point(447, 69);
            this.workAsTextBox.Name = "workAsTextBox";
            this.workAsTextBox.ReadOnly = true;
            this.workAsTextBox.Size = new System.Drawing.Size(471, 21);
            this.workAsTextBox.TabIndex = 11;
            // 
            // exTypeTextBox
            // 
            this.exTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "ExType", true));
            this.exTypeTextBox.Location = new System.Drawing.Point(98, 118);
            this.exTypeTextBox.Name = "exTypeTextBox";
            this.exTypeTextBox.ReadOnly = true;
            this.exTypeTextBox.Size = new System.Drawing.Size(200, 21);
            this.exTypeTextBox.TabIndex = 13;
            // 
            // exSourceTextBox
            // 
            this.exSourceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "ExSource", true));
            this.exSourceTextBox.Location = new System.Drawing.Point(98, 145);
            this.exSourceTextBox.Name = "exSourceTextBox";
            this.exSourceTextBox.ReadOnly = true;
            this.exSourceTextBox.Size = new System.Drawing.Size(200, 21);
            this.exSourceTextBox.TabIndex = 15;
            // 
            // exMessageTextBox
            // 
            this.exMessageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "ExMessage", true));
            this.exMessageTextBox.Location = new System.Drawing.Point(447, 118);
            this.exMessageTextBox.Multiline = true;
            this.exMessageTextBox.Name = "exMessageTextBox";
            this.exMessageTextBox.ReadOnly = true;
            this.exMessageTextBox.Size = new System.Drawing.Size(471, 48);
            this.exMessageTextBox.TabIndex = 17;
            // 
            // exStackTextBox
            // 
            this.exStackTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventLogBindingSource, "ExStack", true));
            this.exStackTextBox.Location = new System.Drawing.Point(98, 172);
            this.exStackTextBox.Multiline = true;
            this.exStackTextBox.Name = "exStackTextBox";
            this.exStackTextBox.ReadOnly = true;
            this.exStackTextBox.Size = new System.Drawing.Size(820, 135);
            this.exStackTextBox.TabIndex = 19;
            // 
            // pnlGrid
            // 
            this.pnlGrid.InnerContainer = this.pnlGridContainer;
            this.pnlGrid.Location = new System.Drawing.Point(3, 3);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(971, 318);
            this.pnlGrid.TabIndex = 4;
            this.pnlGrid.Text = "Event Log";
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.eventLogGridEX);
            this.pnlGridContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Size = new System.Drawing.Size(969, 294);
            this.pnlGridContainer.TabIndex = 0;
            // 
            // eventLogGridEX
            // 
            this.eventLogGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.eventLogGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.eventLogGridEX.DataSource = this.eventLogBindingSource;
            eventLogGridEX_DesignTimeLayout.LayoutString = resources.GetString("eventLogGridEX_DesignTimeLayout.LayoutString");
            this.eventLogGridEX.DesignTimeLayout = eventLogGridEX_DesignTimeLayout;
            this.eventLogGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventLogGridEX.DynamicFiltering = true;
            this.eventLogGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.eventLogGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.eventLogGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.eventLogGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.eventLogGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.eventLogGridEX.Location = new System.Drawing.Point(0, 0);
            this.eventLogGridEX.Name = "eventLogGridEX";
            this.eventLogGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.eventLogGridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.eventLogGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.eventLogGridEX.Size = new System.Drawing.Size(969, 294);
            this.eventLogGridEX.TabIndex = 0;
            this.eventLogGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // fLogEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(977, 675);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlDetails);
            this.Name = "fLogEvent";
            this.Text = "Event Log";
            this.Load += new System.EventHandler(this.fLogEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetails)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetailsContainer.ResumeLayout(false);
            this.pnlDetailsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLogGridEX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        private Janus.Windows.GridEX.GridEX eventLogGridEX;
        private System.Windows.Forms.BindingSource eventLogBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.UI.Dock.UIPanel pnlDetails;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDetailsContainer;
        private Janus.Windows.CalendarCombo.CalendarCombo eventTimeCalendarCombo;
        private System.Windows.Forms.TextBox eventIdTextBox;
        private System.Windows.Forms.TextBox eventTypeTextBox;
        private System.Windows.Forms.TextBox windowsUserTextBox;
        private System.Windows.Forms.TextBox lMUserTextBox;
        private System.Windows.Forms.TextBox workAsTextBox;
        private System.Windows.Forms.TextBox exTypeTextBox;
        private System.Windows.Forms.TextBox exSourceTextBox;
        private System.Windows.Forms.TextBox exMessageTextBox;
        private System.Windows.Forms.TextBox exStackTextBox;
    }
}
