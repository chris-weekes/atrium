namespace LawMate.UserControls
{
    partial class ucActivityNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucActivityNew));
            this.calActivityDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ebStepCode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGo = new Janus.Windows.EditControls.UIButton();
            this.ebNSType = new Janus.Windows.GridEX.EditControls.EditBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ebACDesc = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.SuspendLayout();
            // 
            // calActivityDate
            // 
            resources.ApplyResources(this.calActivityDate, "calActivityDate");
            this.calActivityDate.DayIncrement = 0;
            // 
            // 
            // 
            this.calActivityDate.DropDownCalendar.FirstMonth = new System.DateTime(2006, 12, 1, 0, 0, 0, 0);
            this.calActivityDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2010;
            this.calActivityDate.MonthIncrement = 0;
            this.calActivityDate.Name = "calActivityDate";
            this.calActivityDate.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.VS2010;
            this.calActivityDate.YearIncrement = 0;
            // 
            // ebStepCode
            // 
            this.ebStepCode.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Near;
            this.ebStepCode.ImageKey = "act.png";
            this.ebStepCode.ImageList = this.imageList1;
            resources.ApplyResources(this.ebStepCode, "ebStepCode");
            this.ebStepCode.Name = "ebStepCode";
            this.ebStepCode.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            this.ebStepCode.TextChanged += new System.EventHandler(this.ebStepCode_TextChanged);
            this.ebStepCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ebStepCode_KeyPress);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "checkmark.png");
            this.imageList1.Images.SetKeyName(1, "accepted.png");
            this.imageList1.Images.SetKeyName(2, "accessDenied.png");
            this.imageList1.Images.SetKeyName(3, "act.png");
            this.imageList1.Images.SetKeyName(4, "newrecord.gif");
            // 
            // btnGo
            // 
            resources.ApplyResources(this.btnGo, "btnGo");
            this.btnGo.Name = "btnGo";
            this.btnGo.ShowFocusRectangle = false;
            this.btnGo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnGo.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // ebNSType
            // 
            resources.ApplyResources(this.ebNSType, "ebNSType");
            this.ebNSType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ebNSType.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Near;
            this.ebNSType.ImageList = this.imageList2;
            this.ebNSType.Name = "ebNSType";
            this.ebNSType.ReadOnly = true;
            this.ebNSType.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "NextSteps.png");
            this.imageList2.Images.SetKeyName(1, "enabledprocess.png");
            this.imageList2.Images.SetKeyName(2, "alwaysAvailable.png");
            // 
            // ebACDesc
            // 
            resources.ApplyResources(this.ebACDesc, "ebACDesc");
            this.ebACDesc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ebACDesc.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Near;
            this.ebACDesc.Name = "ebACDesc";
            this.ebACDesc.ReadOnly = true;
            this.ebACDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.uiCheckBox1.Image = global::LawMate.Properties.Resources.skipdocument;
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // ucActivityNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ebNSType);
            this.Controls.Add(this.ebStepCode);
            this.Controls.Add(this.calActivityDate);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.ebACDesc);
            this.Controls.Add(this.uiCheckBox1);
            resources.ApplyResources(this, "$this");
            this.Name = "ucActivityNew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.CalendarCombo.CalendarCombo calActivityDate;
        private Janus.Windows.GridEX.EditControls.EditBox ebStepCode;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.EditControls.UIButton btnGo;
        private Janus.Windows.GridEX.EditControls.EditBox ebNSType;
        private System.Windows.Forms.ImageList imageList2;
        private Janus.Windows.GridEX.EditControls.EditBox ebACDesc;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
    }
}
