 namespace LawMate
{
    partial class fTimeslipStartDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTimeslipStartDate));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.calendarCombo2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.tbMessage = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calStartDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontSize = 10F;
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("9ad267ed-d0c6-4ad7-8b66-f15242d3c176");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("9ad267ed-d0c6-4ad7-8b66-f15242d3c176"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(409, 206), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("9ad267ed-d0c6-4ad7-8b66-f15242d3c176"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlAll.Image = ((System.Drawing.Image)(resources.GetObject("pnlAll.Image")));
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Location = new System.Drawing.Point(3, 3);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(409, 206);
            this.pnlAll.TabIndex = 4;
            this.pnlAll.Text = "Timeslip Start Date";
            // 
            // pnlAllContainer
            // 
            this.pnlAllContainer.Controls.Add(this.label3);
            this.pnlAllContainer.Controls.Add(this.calendarCombo2);
            this.pnlAllContainer.Controls.Add(this.label2);
            this.pnlAllContainer.Controls.Add(this.calendarCombo1);
            this.pnlAllContainer.Controls.Add(this.tbMessage);
            this.pnlAllContainer.Controls.Add(this.label1);
            this.pnlAllContainer.Controls.Add(this.calStartDate);
            this.pnlAllContainer.Controls.Add(this.btnCancel);
            this.pnlAllContainer.Controls.Add(this.btnOK);
            this.pnlAllContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.pnlAllContainer.Size = new System.Drawing.Size(407, 182);
            this.pnlAllContainer.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(220, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Maximum:";
            // 
            // calendarCombo2
            // 
            this.calendarCombo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.calendarCombo2.BackColor = System.Drawing.SystemColors.Control;
            this.calendarCombo2.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.calendarCombo2.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.calendarCombo2.DayIncrement = 0;
            // 
            // 
            // 
            this.calendarCombo2.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo2.Location = new System.Drawing.Point(298, 107);
            this.calendarCombo2.MonthIncrement = 0;
            this.calendarCombo2.Name = "calendarCombo2";
            this.calendarCombo2.ReadOnly = true;
            this.calendarCombo2.Size = new System.Drawing.Size(101, 21);
            this.calendarCombo2.TabIndex = 8;
            this.calendarCombo2.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo2.YearIncrement = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Minimum:";
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            this.calendarCombo1.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.calendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.calendarCombo1.DayIncrement = 0;
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calendarCombo1.Location = new System.Drawing.Point(87, 107);
            this.calendarCombo1.MonthIncrement = 0;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.calendarCombo1.Size = new System.Drawing.Size(100, 21);
            this.calendarCombo1.TabIndex = 6;
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.YearIncrement = 0;
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.Image = ((System.Drawing.Image)(resources.GetObject("tbMessage.Image")));
            this.tbMessage.Location = new System.Drawing.Point(8, 3);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(391, 98);
            this.tbMessage.TabIndex = 5;
            this.tbMessage.Text = "Testing";
            this.tbMessage.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.tbMessage.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Date:";
            // 
            // calStartDate
            // 
            this.calStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calStartDate.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.calStartDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            this.calStartDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calStartDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calStartDate.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free;
            this.calStartDate.Location = new System.Drawing.Point(87, 151);
            this.calStartDate.MonthIncrement = 0;
            this.calStartDate.Name = "calStartDate";
            this.calStartDate.Size = new System.Drawing.Size(100, 21);
            this.calStartDate.TabIndex = 3;
            this.calStartDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calStartDate.YearIncrement = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(324, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(243, 151);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fTimeslipStartDate
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(415, 212);
            this.Controls.Add(this.pnlAll);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 250);
            this.Name = "fTimeslipStartDate";
            this.ShowIcon = false;
            this.Text = "New Timeslips";
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.CalendarCombo.CalendarCombo calStartDate;
        private Janus.Windows.GridEX.EditControls.EditBox tbMessage;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo2;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
    }
}