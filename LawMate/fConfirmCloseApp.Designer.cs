 namespace LawMate
{
    partial class fConfirmCloseApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fConfirmCloseApp));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlClose = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlCloseContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClose)).BeginInit();
            this.pnlClose.SuspendLayout();
            this.pnlCloseContainer.SuspendLayout();
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
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlClose.Id = new System.Guid("e792dca4-c655-4ced-a6ff-0f0332a44f03");
            this.uiPanelManager1.Panels.Add(this.pnlClose);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("e792dca4-c655-4ced-a6ff-0f0332a44f03"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(397, 157), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e792dca4-c655-4ced-a6ff-0f0332a44f03"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlClose
            // 
            this.pnlClose.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlClose.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlClose.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlClose.InnerContainer = this.pnlCloseContainer;
            resources.ApplyResources(this.pnlClose, "pnlClose");
            this.pnlClose.Name = "pnlClose";
            // 
            // pnlCloseContainer
            // 
            this.pnlCloseContainer.Controls.Add(this.label1);
            this.pnlCloseContainer.Controls.Add(this.label2);
            this.pnlCloseContainer.Controls.Add(this.uiButton2);
            this.pnlCloseContainer.Controls.Add(this.uiButton1);
            this.pnlCloseContainer.Controls.Add(this.uiCheckBox1);
            resources.ApplyResources(this.pnlCloseContainer, "pnlCloseContainer");
            this.pnlCloseContainer.Name = "pnlCloseContainer";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = global::LawMate.Properties.Resources.disconnect;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // uiButton2
            // 
            resources.ApplyResources(this.uiButton2, "uiButton2");
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton1
            // 
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.ShowFocusRectangle = false;
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCheckBox1.CheckedChanged += new System.EventHandler(this.uiCheckBox1_CheckedChanged);
            // 
            // fConfirmCloseApp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.pnlClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fConfirmCloseApp";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.fConfirmCloseApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClose)).EndInit();
            this.pnlClose.ResumeLayout(false);
            this.pnlCloseContainer.ResumeLayout(false);
            this.pnlCloseContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlClose;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlCloseContainer;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox label1;
    }
}