namespace LawMate.UserControls
{
    partial class ucApptRecurrence
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
            this.ApptRecurrenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ApptRecurrenceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.RecurrenceLabel = new System.Windows.Forms.Label();
            this.EveryLabel = new System.Windows.Forms.Label();
            this.EndsLabel = new System.Windows.Forms.Label();
            this.EndsPanel = new System.Windows.Forms.Panel();
            this.calBFListRange = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.EveryUIComboBox = new Janus.Windows.EditControls.UIComboBox();
            this.RecurrenceUIComboBox = new Janus.Windows.EditControls.UIComboBox();
            this.DaysPanel = new System.Windows.Forms.Panel();
            this.SaturdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.FridayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ThursdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.WednesdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.TuesdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.MondayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.SundayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.DaysLabel = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.EndByLabel = new System.Windows.Forms.Label();
            this.RemoveRecurrenceUIButton = new Janus.Windows.EditControls.UIButton();
            this.CancelButton = new Janus.Windows.EditControls.UIButton();
            this.OKButton = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.ApptRecurrenceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApptRecurrenceErrorProvider)).BeginInit();
            this.EndsPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.DaysPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApptRecurrenceBindingSource
            // 
            this.ApptRecurrenceBindingSource.DataMember = "ApptRecurrence";
            this.ApptRecurrenceBindingSource.DataSource = typeof(lmDatasets.atriumDB);
            // 
            // ApptRecurrenceErrorProvider
            // 
            this.ApptRecurrenceErrorProvider.ContainerControl = this;
            this.ApptRecurrenceErrorProvider.DataSource = this.ApptRecurrenceBindingSource;
            // 
            // RecurrenceLabel
            // 
            this.RecurrenceLabel.AutoSize = true;
            this.RecurrenceLabel.Location = new System.Drawing.Point(3, 14);
            this.RecurrenceLabel.Name = "RecurrenceLabel";
            this.RecurrenceLabel.Size = new System.Drawing.Size(66, 13);
            this.RecurrenceLabel.TabIndex = 0;
            this.RecurrenceLabel.Text = "Recurrence:";
            this.RecurrenceLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // EveryLabel
            // 
            this.EveryLabel.AutoSize = true;
            this.EveryLabel.Location = new System.Drawing.Point(3, 67);
            this.EveryLabel.Name = "EveryLabel";
            this.EveryLabel.Size = new System.Drawing.Size(37, 13);
            this.EveryLabel.TabIndex = 1;
            this.EveryLabel.Text = "Every:";
            // 
            // EndsLabel
            // 
            this.EndsLabel.AutoSize = true;
            this.EndsLabel.Location = new System.Drawing.Point(3, 16);
            this.EndsLabel.Name = "EndsLabel";
            this.EndsLabel.Size = new System.Drawing.Size(34, 13);
            this.EndsLabel.TabIndex = 2;
            this.EndsLabel.Text = "Ends:";
            // 
            // EndsPanel
            // 
            this.EndsPanel.Controls.Add(this.calBFListRange);
            this.EndsPanel.Controls.Add(this.EndsLabel);
            this.EndsPanel.Location = new System.Drawing.Point(0, 172);
            this.EndsPanel.Name = "EndsPanel";
            this.EndsPanel.Size = new System.Drawing.Size(512, 46);
            this.EndsPanel.TabIndex = 3;
            // 
            // calBFListRange
            // 
            this.calBFListRange.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            this.calBFListRange.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.calBFListRange.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.ApptRecurrenceBindingSource, "EndRangeDate", true));
            this.calBFListRange.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calBFListRange.DropDownCalendar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.calBFListRange.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calBFListRange.Location = new System.Drawing.Point(103, 12);
            this.calBFListRange.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.calBFListRange.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.calBFListRange.Name = "calBFListRange";
            this.calBFListRange.Size = new System.Drawing.Size(98, 20);
            this.calBFListRange.TabIndex = 7;
            this.calBFListRange.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.EveryUIComboBox);
            this.TopPanel.Controls.Add(this.RecurrenceUIComboBox);
            this.TopPanel.Controls.Add(this.EveryLabel);
            this.TopPanel.Controls.Add(this.RecurrenceLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(512, 100);
            this.TopPanel.TabIndex = 4;
            // 
            // EveryUIComboBox
            // 
            this.EveryUIComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EveryUIComboBox.AutoSize = false;
            this.EveryUIComboBox.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.EveryUIComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ApptRecurrenceBindingSource, "OccursEvery", true));
            this.EveryUIComboBox.Location = new System.Drawing.Point(103, 62);
            this.EveryUIComboBox.Name = "EveryUIComboBox";
            this.EveryUIComboBox.Size = new System.Drawing.Size(129, 21);
            this.EveryUIComboBox.TabIndex = 5;
            this.EveryUIComboBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // RecurrenceUIComboBox
            // 
            this.RecurrenceUIComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RecurrenceUIComboBox.AutoSize = false;
            this.RecurrenceUIComboBox.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.RecurrenceUIComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ApptRecurrenceBindingSource, "ApptRecurrenceTypeId", true));
            this.RecurrenceUIComboBox.Location = new System.Drawing.Point(103, 14);
            this.RecurrenceUIComboBox.Name = "RecurrenceUIComboBox";
            this.RecurrenceUIComboBox.Size = new System.Drawing.Size(129, 21);
            this.RecurrenceUIComboBox.TabIndex = 4;
            this.RecurrenceUIComboBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // DaysPanel
            // 
            this.DaysPanel.Controls.Add(this.SaturdayUICheckBox);
            this.DaysPanel.Controls.Add(this.FridayUICheckBox);
            this.DaysPanel.Controls.Add(this.ThursdayUICheckBox);
            this.DaysPanel.Controls.Add(this.WednesdayUICheckBox);
            this.DaysPanel.Controls.Add(this.TuesdayUICheckBox);
            this.DaysPanel.Controls.Add(this.MondayUICheckBox);
            this.DaysPanel.Controls.Add(this.SundayUICheckBox);
            this.DaysPanel.Controls.Add(this.DaysLabel);
            this.DaysPanel.Location = new System.Drawing.Point(0, 97);
            this.DaysPanel.Name = "DaysPanel";
            this.DaysPanel.Size = new System.Drawing.Size(512, 79);
            this.DaysPanel.TabIndex = 5;
            // 
            // SaturdayUICheckBox
            // 
            this.SaturdayUICheckBox.Location = new System.Drawing.Point(275, 39);
            this.SaturdayUICheckBox.Name = "SaturdayUICheckBox";
            this.SaturdayUICheckBox.Size = new System.Drawing.Size(80, 19);
            this.SaturdayUICheckBox.TabIndex = 9;
            this.SaturdayUICheckBox.Text = "Saturday";
            this.SaturdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // FridayUICheckBox
            // 
            this.FridayUICheckBox.Location = new System.Drawing.Point(189, 39);
            this.FridayUICheckBox.Name = "FridayUICheckBox";
            this.FridayUICheckBox.Size = new System.Drawing.Size(80, 19);
            this.FridayUICheckBox.TabIndex = 8;
            this.FridayUICheckBox.Text = "Friday";
            this.FridayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // ThursdayUICheckBox
            // 
            this.ThursdayUICheckBox.Location = new System.Drawing.Point(103, 39);
            this.ThursdayUICheckBox.Name = "ThursdayUICheckBox";
            this.ThursdayUICheckBox.Size = new System.Drawing.Size(80, 19);
            this.ThursdayUICheckBox.TabIndex = 7;
            this.ThursdayUICheckBox.Text = "Thursday";
            this.ThursdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // WednesdayUICheckBox
            // 
            this.WednesdayUICheckBox.Location = new System.Drawing.Point(361, 14);
            this.WednesdayUICheckBox.Name = "WednesdayUICheckBox";
            this.WednesdayUICheckBox.Size = new System.Drawing.Size(80, 19);
            this.WednesdayUICheckBox.TabIndex = 6;
            this.WednesdayUICheckBox.Text = "Wednesday";
            this.WednesdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // TuesdayUICheckBox
            // 
            this.TuesdayUICheckBox.Location = new System.Drawing.Point(275, 14);
            this.TuesdayUICheckBox.Name = "TuesdayUICheckBox";
            this.TuesdayUICheckBox.Size = new System.Drawing.Size(80, 19);
            this.TuesdayUICheckBox.TabIndex = 5;
            this.TuesdayUICheckBox.Text = "Tuesday";
            this.TuesdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // MondayUICheckBox
            // 
            this.MondayUICheckBox.Location = new System.Drawing.Point(189, 14);
            this.MondayUICheckBox.Name = "MondayUICheckBox";
            this.MondayUICheckBox.Size = new System.Drawing.Size(80, 19);
            this.MondayUICheckBox.TabIndex = 4;
            this.MondayUICheckBox.Text = "Monday";
            this.MondayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // SundayUICheckBox
            // 
            this.SundayUICheckBox.Location = new System.Drawing.Point(103, 14);
            this.SundayUICheckBox.Name = "SundayUICheckBox";
            this.SundayUICheckBox.Size = new System.Drawing.Size(80, 19);
            this.SundayUICheckBox.TabIndex = 3;
            this.SundayUICheckBox.Text = "Sunday";
            this.SundayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // DaysLabel
            // 
            this.DaysLabel.AutoSize = true;
            this.DaysLabel.Location = new System.Drawing.Point(3, 18);
            this.DaysLabel.Name = "DaysLabel";
            this.DaysLabel.Size = new System.Drawing.Size(34, 13);
            this.DaysLabel.TabIndex = 2;
            this.DaysLabel.Text = "Days:";
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.EndByLabel);
            this.BottomPanel.Controls.Add(this.RemoveRecurrenceUIButton);
            this.BottomPanel.Controls.Add(this.CancelButton);
            this.BottomPanel.Controls.Add(this.OKButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 220);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(512, 128);
            this.BottomPanel.TabIndex = 6;
            // 
            // EndByLabel
            // 
            this.EndByLabel.AutoSize = true;
            this.EndByLabel.Location = new System.Drawing.Point(3, 36);
            this.EndByLabel.Name = "EndByLabel";
            this.EndByLabel.Size = new System.Drawing.Size(257, 13);
            this.EndByLabel.TabIndex = 4;
            this.EndByLabel.Text = "Occurs every (ApptRecurrenceValue) until (EndDate)";
            // 
            // RemoveRecurrenceUIButton
            // 
            this.RemoveRecurrenceUIButton.Location = new System.Drawing.Point(248, 91);
            this.RemoveRecurrenceUIButton.Name = "RemoveRecurrenceUIButton";
            this.RemoveRecurrenceUIButton.Size = new System.Drawing.Size(142, 23);
            this.RemoveRecurrenceUIButton.TabIndex = 3;
            this.RemoveRecurrenceUIButton.Text = "Remove Recurrence";
            this.RemoveRecurrenceUIButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(152, 91);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(80, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(55, 91);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(80, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // ucApptRecurrence
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.DaysPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.EndsPanel);
            this.Name = "ucApptRecurrence";
            this.Size = new System.Drawing.Size(512, 348);
            ((System.ComponentModel.ISupportInitialize)(this.ApptRecurrenceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApptRecurrenceErrorProvider)).EndInit();
            this.EndsPanel.ResumeLayout(false);
            this.EndsPanel.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.DaysPanel.ResumeLayout(false);
            this.DaysPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource ApptRecurrenceBindingSource;
        private System.Windows.Forms.ErrorProvider ApptRecurrenceErrorProvider;
        private System.Windows.Forms.Label EndsLabel;
        private System.Windows.Forms.Label EveryLabel;
        private System.Windows.Forms.Label RecurrenceLabel;
        private System.Windows.Forms.Panel EndsPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel DaysPanel;
        private System.Windows.Forms.Label EndByLabel;
        private Janus.Windows.EditControls.UIButton RemoveRecurrenceUIButton;
        private Janus.Windows.EditControls.UIButton CancelButton;
        private Janus.Windows.EditControls.UIButton OKButton;
        private System.Windows.Forms.Label DaysLabel;
        private Janus.Windows.EditControls.UICheckBox SaturdayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox FridayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox ThursdayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox WednesdayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox TuesdayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox MondayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox SundayUICheckBox;
        private Janus.Windows.EditControls.UIComboBox RecurrenceUIComboBox;
        private Janus.Windows.EditControls.UIComboBox EveryUIComboBox;
        private Janus.Windows.CalendarCombo.CalendarCombo calBFListRange;

    }
}
