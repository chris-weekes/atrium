namespace LawMate.Admin
{
    partial class fConfigSync
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAcConfig = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAcConfigContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnTestCompare = new Janus.Windows.EditControls.UIButton();
            this.uiButton5 = new Janus.Windows.EditControls.UIButton();
            this.uiButton6 = new Janus.Windows.EditControls.UIButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            this.uiButton4 = new Janus.Windows.EditControls.UIButton();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAcConfig)).BeginInit();
            this.pnlAcConfig.SuspendLayout();
            this.pnlAcConfigContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAcConfig.Id = new System.Guid("7d9e31f0-0c7b-4ae8-a0d7-9d259fa057f3");
            this.uiPanelManager1.Panels.Add(this.pnlAcConfig);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7d9e31f0-0c7b-4ae8-a0d7-9d259fa057f3"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(824, 503), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7d9e31f0-0c7b-4ae8-a0d7-9d259fa057f3"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAcConfig
            // 
            this.pnlAcConfig.InnerContainer = this.pnlAcConfigContainer;
            this.pnlAcConfig.Location = new System.Drawing.Point(3, 3);
            this.pnlAcConfig.Name = "pnlAcConfig";
            this.pnlAcConfig.Size = new System.Drawing.Size(824, 503);
            this.pnlAcConfig.TabIndex = 4;
            this.pnlAcConfig.Text = "Workflow Configuration Synchronization";
            // 
            // pnlAcConfigContainer
            // 
            this.pnlAcConfigContainer.Controls.Add(this.btnTestCompare);
            this.pnlAcConfigContainer.Controls.Add(this.uiButton5);
            this.pnlAcConfigContainer.Controls.Add(this.uiButton6);
            this.pnlAcConfigContainer.Controls.Add(this.uiButton3);
            this.pnlAcConfigContainer.Controls.Add(this.uiButton4);
            this.pnlAcConfigContainer.Controls.Add(this.uiButton1);
            this.pnlAcConfigContainer.Controls.Add(this.uiButton2);
            this.pnlAcConfigContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlAcConfigContainer.Name = "pnlAcConfigContainer";
            this.pnlAcConfigContainer.Size = new System.Drawing.Size(822, 501);
            this.pnlAcConfigContainer.TabIndex = 0;
            // 
            // btnTestCompare
            // 
            this.btnTestCompare.HighlightActiveButton = false;
            this.btnTestCompare.Image = global::LawMate.Properties.Resources.download;
            this.btnTestCompare.Location = new System.Drawing.Point(432, 237);
            this.btnTestCompare.Name = "btnTestCompare";
            this.btnTestCompare.ShowFocusRectangle = false;
            this.btnTestCompare.Size = new System.Drawing.Size(335, 39);
            this.btnTestCompare.TabIndex = 8;
            this.btnTestCompare.Text = "Testing: Config Data Compare";
            this.btnTestCompare.Visible = false;
            this.btnTestCompare.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnTestCompare.Click += new System.EventHandler(this.btnTestCompare_Click);
            // 
            // uiButton5
            // 
            this.uiButton5.HighlightActiveButton = false;
            this.uiButton5.Image = global::LawMate.Properties.Resources.Upload_16x16;
            this.uiButton5.Location = new System.Drawing.Point(21, 142);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.ShowFocusRectangle = false;
            this.uiButton5.Size = new System.Drawing.Size(335, 39);
            this.uiButton5.TabIndex = 6;
            this.uiButton5.Text = "Export data dictionary XML Data";
            this.uiButton5.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton5.Click += new System.EventHandler(this.uiButton5_Click);
            // 
            // uiButton6
            // 
            this.uiButton6.HighlightActiveButton = false;
            this.uiButton6.Image = global::LawMate.Properties.Resources.download;
            this.uiButton6.Location = new System.Drawing.Point(432, 142);
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.ShowFocusRectangle = false;
            this.uiButton6.Size = new System.Drawing.Size(335, 39);
            this.uiButton6.TabIndex = 7;
            this.uiButton6.Text = "Import data dictionary XML Data";
            this.uiButton6.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton6.Click += new System.EventHandler(this.uiButton6_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.HighlightActiveButton = false;
            this.uiButton3.Image = global::LawMate.Properties.Resources.Upload_16x16;
            this.uiButton3.Location = new System.Drawing.Point(21, 81);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.ShowFocusRectangle = false;
            this.uiButton3.Size = new System.Drawing.Size(335, 39);
            this.uiButton3.TabIndex = 4;
            this.uiButton3.Text = "Export Other Config XML Data";
            this.uiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // uiButton4
            // 
            this.uiButton4.HighlightActiveButton = false;
            this.uiButton4.Image = global::LawMate.Properties.Resources.download;
            this.uiButton4.Location = new System.Drawing.Point(432, 81);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.ShowFocusRectangle = false;
            this.uiButton4.Size = new System.Drawing.Size(335, 39);
            this.uiButton4.TabIndex = 5;
            this.uiButton4.Text = "Import Other Config XML Data";
            this.uiButton4.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.HighlightActiveButton = false;
            this.uiButton1.Image = global::LawMate.Properties.Resources.Upload_16x16;
            this.uiButton1.Location = new System.Drawing.Point(21, 21);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.ShowFocusRectangle = false;
            this.uiButton1.Size = new System.Drawing.Size(335, 39);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "Export Workflow Configuration XML Data";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.HighlightActiveButton = false;
            this.uiButton2.Image = global::LawMate.Properties.Resources.download;
            this.uiButton2.Location = new System.Drawing.Point(432, 21);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.ShowFocusRectangle = false;
            this.uiButton2.Size = new System.Drawing.Size(335, 39);
            this.uiButton2.TabIndex = 3;
            this.uiButton2.Text = "Import Workflow Configuration XML Data";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fConfigSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(830, 509);
            this.Controls.Add(this.pnlAcConfig);
            this.Name = "fConfigSync";
            this.Text = "Configuration Synchronization";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAcConfig)).EndInit();
            this.pnlAcConfig.ResumeLayout(false);
            this.pnlAcConfigContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAcConfig;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAcConfigContainer;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton5;
        private Janus.Windows.EditControls.UIButton uiButton6;
        private Janus.Windows.EditControls.UIButton uiButton3;
        private Janus.Windows.EditControls.UIButton uiButton4;
        private Janus.Windows.EditControls.UIButton btnTestCompare;
    }
}
