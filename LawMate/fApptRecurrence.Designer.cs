namespace LawMate
{
    partial class fApptRecurrence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fApptRecurrence));
            this.SaturdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ApptRecurrenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.EndByLabel = new System.Windows.Forms.Label();
            this.RemoveRecurrenceUIButton = new Janus.Windows.EditControls.UIButton();
            this.CancelButton = new Janus.Windows.EditControls.UIButton();
            this.OKButton = new Janus.Windows.EditControls.UIButton();
            this.DaysPanel = new System.Windows.Forms.Panel();
            this.FridayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ThursdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.WednesdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.TuesdayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.MondayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.SundayUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.DaysLabel = new System.Windows.Forms.Label();
            this.EndsPanel = new System.Windows.Forms.Panel();
            this.EndDateRangeCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.EndsLabel = new System.Windows.Forms.Label();
            this.EveryUIComboBox = new Janus.Windows.EditControls.UIComboBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.RecurrenceUIMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            this.EveryLabel = new System.Windows.Forms.Label();
            this.RecurrenceLabel = new System.Windows.Forms.Label();
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBase = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ApptRecurrenceBindingSource)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.DaysPanel.SuspendLayout();
            this.EndsPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaturdayUICheckBox
            // 
            resources.ApplyResources(this.SaturdayUICheckBox, "SaturdayUICheckBox");
            this.SaturdayUICheckBox.Name = "SaturdayUICheckBox";
            this.SaturdayUICheckBox.Tag = "6";
            this.SaturdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.SaturdayUICheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // ApptRecurrenceBindingSource
            // 
            this.ApptRecurrenceBindingSource.DataMember = "ApptRecurrence";
            this.ApptRecurrenceBindingSource.DataSource = typeof(lmDatasets.atriumDB);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomPanel.Controls.Add(this.EndByLabel);
            this.BottomPanel.Controls.Add(this.RemoveRecurrenceUIButton);
            this.BottomPanel.Controls.Add(this.CancelButton);
            this.BottomPanel.Controls.Add(this.OKButton);
            resources.ApplyResources(this.BottomPanel, "BottomPanel");
            this.BottomPanel.Name = "BottomPanel";
            // 
            // EndByLabel
            // 
            resources.ApplyResources(this.EndByLabel, "EndByLabel");
            this.EndByLabel.Name = "EndByLabel";
            // 
            // RemoveRecurrenceUIButton
            // 
            resources.ApplyResources(this.RemoveRecurrenceUIButton, "RemoveRecurrenceUIButton");
            this.RemoveRecurrenceUIButton.Name = "RemoveRecurrenceUIButton";
            this.RemoveRecurrenceUIButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.RemoveRecurrenceUIButton.Click += new System.EventHandler(this.RemoveRecurrenceUIButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.Name = "OKButton";
            this.OKButton.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DaysPanel
            // 
            this.DaysPanel.BackColor = System.Drawing.Color.Transparent;
            this.DaysPanel.Controls.Add(this.SaturdayUICheckBox);
            this.DaysPanel.Controls.Add(this.FridayUICheckBox);
            this.DaysPanel.Controls.Add(this.ThursdayUICheckBox);
            this.DaysPanel.Controls.Add(this.WednesdayUICheckBox);
            this.DaysPanel.Controls.Add(this.TuesdayUICheckBox);
            this.DaysPanel.Controls.Add(this.MondayUICheckBox);
            this.DaysPanel.Controls.Add(this.SundayUICheckBox);
            this.DaysPanel.Controls.Add(this.DaysLabel);
            resources.ApplyResources(this.DaysPanel, "DaysPanel");
            this.DaysPanel.Name = "DaysPanel";
            // 
            // FridayUICheckBox
            // 
            resources.ApplyResources(this.FridayUICheckBox, "FridayUICheckBox");
            this.FridayUICheckBox.Name = "FridayUICheckBox";
            this.FridayUICheckBox.Tag = "5";
            this.FridayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.FridayUICheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // ThursdayUICheckBox
            // 
            resources.ApplyResources(this.ThursdayUICheckBox, "ThursdayUICheckBox");
            this.ThursdayUICheckBox.Name = "ThursdayUICheckBox";
            this.ThursdayUICheckBox.Tag = "4";
            this.ThursdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.ThursdayUICheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // WednesdayUICheckBox
            // 
            resources.ApplyResources(this.WednesdayUICheckBox, "WednesdayUICheckBox");
            this.WednesdayUICheckBox.Name = "WednesdayUICheckBox";
            this.WednesdayUICheckBox.Tag = "3";
            this.WednesdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.WednesdayUICheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // TuesdayUICheckBox
            // 
            resources.ApplyResources(this.TuesdayUICheckBox, "TuesdayUICheckBox");
            this.TuesdayUICheckBox.Name = "TuesdayUICheckBox";
            this.TuesdayUICheckBox.Tag = "2";
            this.TuesdayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.TuesdayUICheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // MondayUICheckBox
            // 
            resources.ApplyResources(this.MondayUICheckBox, "MondayUICheckBox");
            this.MondayUICheckBox.Name = "MondayUICheckBox";
            this.MondayUICheckBox.Tag = "1";
            this.MondayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.MondayUICheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // SundayUICheckBox
            // 
            resources.ApplyResources(this.SundayUICheckBox, "SundayUICheckBox");
            this.SundayUICheckBox.Name = "SundayUICheckBox";
            this.SundayUICheckBox.Tag = "0";
            this.SundayUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.SundayUICheckBox.CheckedChanged += new System.EventHandler(this.DayCheckBox_CheckedChanged);
            // 
            // DaysLabel
            // 
            resources.ApplyResources(this.DaysLabel, "DaysLabel");
            this.DaysLabel.Name = "DaysLabel";
            // 
            // EndsPanel
            // 
            this.EndsPanel.BackColor = System.Drawing.Color.Transparent;
            this.EndsPanel.Controls.Add(this.EndDateRangeCalendarCombo);
            this.EndsPanel.Controls.Add(this.EndsLabel);
            resources.ApplyResources(this.EndsPanel, "EndsPanel");
            this.EndsPanel.Name = "EndsPanel";
            // 
            // EndDateRangeCalendarCombo
            // 
            this.EndDateRangeCalendarCombo.BorderStyle = Janus.Windows.CalendarCombo.BorderStyle.Flat;
            resources.ApplyResources(this.EndDateRangeCalendarCombo, "EndDateRangeCalendarCombo");
            // 
            // 
            // 
            this.EndDateRangeCalendarCombo.DropDownCalendar.Font = ((System.Drawing.Font)(resources.GetObject("EndDateRangeCalendarCombo.DropDownCalendar.Font")));
            this.EndDateRangeCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.EndDateRangeCalendarCombo.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.EndDateRangeCalendarCombo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.EndDateRangeCalendarCombo.Name = "EndDateRangeCalendarCombo";
            this.EndDateRangeCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.EndDateRangeCalendarCombo.ValueChanged += new System.EventHandler(this.EndDateRangeCalendarCombo_ValueChanged);
            // 
            // EndsLabel
            // 
            resources.ApplyResources(this.EndsLabel, "EndsLabel");
            this.EndsLabel.Name = "EndsLabel";
            // 
            // EveryUIComboBox
            // 
            resources.ApplyResources(this.EveryUIComboBox, "EveryUIComboBox");
            this.EveryUIComboBox.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.EveryUIComboBox.Name = "EveryUIComboBox";
            this.EveryUIComboBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.EveryUIComboBox.SelectedIndexChanged += new System.EventHandler(this.EveryUIComboBox_SelectedIndexChanged);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopPanel.Controls.Add(this.RecurrenceUIMultiDropDown);
            this.TopPanel.Controls.Add(this.EveryUIComboBox);
            this.TopPanel.Controls.Add(this.EveryLabel);
            this.TopPanel.Controls.Add(this.RecurrenceLabel);
            resources.ApplyResources(this.TopPanel, "TopPanel");
            this.TopPanel.Name = "TopPanel";
            // 
            // RecurrenceUIMultiDropDown
            // 
            this.RecurrenceUIMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.RecurrenceUIMultiDropDown.Column1 = "ApptRecurrenceTypeID";
            resources.ApplyResources(this.RecurrenceUIMultiDropDown, "RecurrenceUIMultiDropDown");
            this.RecurrenceUIMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.RecurrenceUIMultiDropDown.DataSource = null;
            this.RecurrenceUIMultiDropDown.DDColumn1Visible = false;
            this.RecurrenceUIMultiDropDown.DropDownColumn1Width = 100;
            this.RecurrenceUIMultiDropDown.DropDownColumn2Width = 300;
            this.RecurrenceUIMultiDropDown.Name = "RecurrenceUIMultiDropDown";
            this.RecurrenceUIMultiDropDown.ReadOnly = false;
            this.RecurrenceUIMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.RecurrenceUIMultiDropDown.SelectedValue = null;
            this.RecurrenceUIMultiDropDown.ValueMember = "ApptRecurrenceTypeID";
            this.RecurrenceUIMultiDropDown.ASelectedValueChanged += new System.EventHandler(this.RecurrenceUIMultiDropDown_ASelectedValueChanged);
            // 
            // EveryLabel
            // 
            resources.ApplyResources(this.EveryLabel, "EveryLabel");
            this.EveryLabel.Name = "EveryLabel";
            // 
            // RecurrenceLabel
            // 
            resources.ApplyResources(this.RecurrenceLabel, "RecurrenceLabel");
            this.RecurrenceLabel.Name = "RecurrenceLabel";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTop.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Controls.Add(this.BottomPanel);
            this.pnlTopContainer.Controls.Add(this.TopPanel);
            this.pnlTopContainer.Controls.Add(this.DaysPanel);
            this.pnlTopContainer.Controls.Add(this.EndsPanel);
            resources.ApplyResources(this.pnlTopContainer, "pnlTopContainer");
            this.pnlTopContainer.Name = "pnlTopContainer";
            // 
            // pnlBase
            // 
            resources.ApplyResources(this.pnlBase, "pnlBase");
            this.pnlBase.Name = "pnlBase";
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
            this.pnlTop.Id = new System.Guid("6795a7e0-2c85-4c2f-bcfd-3860d09b20e8");
            this.uiPanelManager1.Panels.Add(this.pnlTop);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("6795a7e0-2c85-4c2f-bcfd-3860d09b20e8"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(517, 673), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("6795a7e0-2c85-4c2f-bcfd-3860d09b20e8"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // fApptRecurrence
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fApptRecurrence";
            ((System.ComponentModel.ISupportInitialize)(this.ApptRecurrenceBindingSource)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.DaysPanel.ResumeLayout(false);
            this.DaysPanel.PerformLayout();
            this.EndsPanel.ResumeLayout(false);
            this.EndsPanel.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTopContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UICheckBox SaturdayUICheckBox;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label EndByLabel;
        private Janus.Windows.EditControls.UIButton RemoveRecurrenceUIButton;
        private Janus.Windows.EditControls.UIButton CancelButton;
        private Janus.Windows.EditControls.UIButton OKButton;
        private System.Windows.Forms.Panel DaysPanel;
        private Janus.Windows.EditControls.UICheckBox FridayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox ThursdayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox WednesdayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox TuesdayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox MondayUICheckBox;
        private Janus.Windows.EditControls.UICheckBox SundayUICheckBox;
        private System.Windows.Forms.Label DaysLabel;
        private System.Windows.Forms.Panel EndsPanel;
        private Janus.Windows.CalendarCombo.CalendarCombo EndDateRangeCalendarCombo;
        public System.Windows.Forms.BindingSource ApptRecurrenceBindingSource;
        private System.Windows.Forms.Label EndsLabel;
        private Janus.Windows.EditControls.UIComboBox EveryUIComboBox;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label EveryLabel;
        private System.Windows.Forms.Label RecurrenceLabel;
        private UserControls.ucMultiDropDown RecurrenceUIMultiDropDown;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlBase;





    }
}