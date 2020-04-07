 namespace LawMate
{
    partial class fTimeConvertor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTimeConvertor));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnltimecalc = new Janus.Windows.UI.Dock.UIPanel();
            this.pnltimecalcContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ebMinutes = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.ebHours = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.lblTotalMinutes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltimecalc)).BeginInit();
            this.pnltimecalc.SuspendLayout();
            this.pnltimecalcContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontSize = 10F;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnltimecalc.Id = new System.Guid("83e874a3-be0a-418b-a45f-fdfec201323a");
            this.uiPanelManager1.Panels.Add(this.pnltimecalc);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("83e874a3-be0a-418b-a45f-fdfec201323a"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(224, 168), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("83e874a3-be0a-418b-a45f-fdfec201323a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnltimecalc
            // 
            this.pnltimecalc.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            resources.ApplyResources(this.pnltimecalc, "pnltimecalc");
            this.pnltimecalc.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnltimecalc.InnerContainer = this.pnltimecalcContainer;
            this.pnltimecalc.Name = "pnltimecalc";
            // 
            // pnltimecalcContainer
            // 
            this.pnltimecalcContainer.Controls.Add(this.ebMinutes);
            this.pnltimecalcContainer.Controls.Add(this.ebHours);
            this.pnltimecalcContainer.Controls.Add(this.uiButton1);
            this.pnltimecalcContainer.Controls.Add(this.btnOK);
            this.pnltimecalcContainer.Controls.Add(this.lblTotalMinutes);
            this.pnltimecalcContainer.Controls.Add(this.label3);
            this.pnltimecalcContainer.Controls.Add(this.label2);
            this.pnltimecalcContainer.Controls.Add(this.label1);
            resources.ApplyResources(this.pnltimecalcContainer, "pnltimecalcContainer");
            this.pnltimecalcContainer.Name = "pnltimecalcContainer";
            // 
            // ebMinutes
            // 
            this.ebMinutes.AllowParentheses = Janus.Windows.GridEX.TriState.False;
            this.ebMinutes.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.ebMinutes.DecimalDigits = 0;
            resources.ApplyResources(this.ebMinutes, "ebMinutes");
            this.ebMinutes.MaxLength = 3;
            this.ebMinutes.Name = "ebMinutes";
            this.ebMinutes.Value = 0;
            this.ebMinutes.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this.ebMinutes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebMinutes.TextChanged += new System.EventHandler(this.ebHours_TextChanged);
            // 
            // ebHours
            // 
            this.ebHours.AllowParentheses = Janus.Windows.GridEX.TriState.False;
            this.ebHours.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.ebHours.DecimalDigits = 0;
            resources.ApplyResources(this.ebHours, "ebHours");
            this.ebHours.MaxLength = 2;
            this.ebHours.Name = "ebHours";
            this.ebHours.Value = 0;
            this.ebHours.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            this.ebHours.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebHours.TextChanged += new System.EventHandler(this.ebHours_TextChanged);
            // 
            // uiButton1
            // 
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblTotalMinutes
            // 
            this.lblTotalMinutes.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTotalMinutes, "lblTotalMinutes");
            this.lblTotalMinutes.Name = "lblTotalMinutes";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // fTimeConvertor
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.uiButton1;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnltimecalc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "fTimeConvertor";
            this.ShowIcon = false;
            this.Shown += new System.EventHandler(this.fTimeConvertor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnltimecalc)).EndInit();
            this.pnltimecalc.ResumeLayout(false);
            this.pnltimecalcContainer.ResumeLayout(false);
            this.pnltimecalcContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnltimecalc;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnltimecalcContainer;
        private System.Windows.Forms.Label lblTotalMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ebHours;
        private Janus.Windows.GridEX.EditControls.NumericEditBox ebMinutes;
    }
}