 namespace LawMate
{
    partial class ucDateRange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDateRange));
            this.calDocDate2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.calDocDate1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblInvalidDate = new System.Windows.Forms.Label();
            this.cbDateRangeOptions = new Janus.Windows.EditControls.UIComboBox();
            this.SuspendLayout();
            // 
            // calDocDate2
            // 
            resources.ApplyResources(this.calDocDate2, "calDocDate2");
            this.calDocDate2.DayIncrement = 0;
            // 
            // 
            // 
            this.calDocDate2.DropDownCalendar.FirstMonth = new System.DateTime(2006, 12, 1, 0, 0, 0, 0);
            this.calDocDate2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calDocDate2.IsNullDate = true;
            this.calDocDate2.MonthIncrement = 0;
            this.calDocDate2.Name = "calDocDate2";
            this.calDocDate2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calDocDate2.YearIncrement = 0;
            this.calDocDate2.ValueChanged += new System.EventHandler(this.calDocDate1_ValueChanged);
            this.calDocDate2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calDocDate1_KeyDown);
            // 
            // lblToDate
            // 
            resources.ApplyResources(this.lblToDate, "lblToDate");
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblToDate.Name = "lblToDate";
            // 
            // lblFromDate
            // 
            resources.ApplyResources(this.lblFromDate, "lblFromDate");
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFromDate.Name = "lblFromDate";
            // 
            // calDocDate1
            // 
            resources.ApplyResources(this.calDocDate1, "calDocDate1");
            this.calDocDate1.DayIncrement = 0;
            // 
            // 
            // 
            this.calDocDate1.DropDownCalendar.FirstMonth = new System.DateTime(2006, 12, 1, 0, 0, 0, 0);
            this.calDocDate1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calDocDate1.IsNullDate = true;
            this.calDocDate1.MonthIncrement = 0;
            this.calDocDate1.Name = "calDocDate1";
            this.calDocDate1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calDocDate1.YearIncrement = 0;
            this.calDocDate1.ValueChanged += new System.EventHandler(this.calDocDate1_ValueChanged);
            this.calDocDate1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calDocDate1_KeyDown);
            // 
            // lblInvalidDate
            // 
            resources.ApplyResources(this.lblInvalidDate, "lblInvalidDate");
            this.lblInvalidDate.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidDate.Name = "lblInvalidDate";
            // 
            // cbDateRangeOptions
            // 
            this.cbDateRangeOptions.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            resources.ApplyResources(this.cbDateRangeOptions, "cbDateRangeOptions");
            this.cbDateRangeOptions.Name = "cbDateRangeOptions";
            this.cbDateRangeOptions.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.cbDateRangeOptions.SelectedIndexChanged += new System.EventHandler(this.cbDocDateOptions_SelectedIndexChanged);
            // 
            // ucDateRange
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cbDateRangeOptions);
            this.Controls.Add(this.lblInvalidDate);
            this.Controls.Add(this.calDocDate2);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.calDocDate1);
            this.Name = "ucDateRange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.CalendarCombo.CalendarCombo calDocDate2;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private Janus.Windows.CalendarCombo.CalendarCombo calDocDate1;
        private System.Windows.Forms.Label lblInvalidDate;
        private Janus.Windows.EditControls.UIComboBox cbDateRangeOptions;
    }
}
