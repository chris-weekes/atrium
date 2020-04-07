 namespace LawMate
{
    partial class fNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNotify));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlLawMail = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlLawMailContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMailCountMessage = new System.Windows.Forms.Label();
            this.timerFade = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLawMail)).BeginInit();
            this.pnlLawMail.SuspendLayout();
            this.pnlLawMailContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 8000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.MouseEnter += new System.EventHandler(this.pnlLawMail_MouseEnter);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.BackColorSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontSize = 8F;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontName = "calibri";
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontSize = 9.25F;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.PanelClosedChanged += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.uiPanelManager1_PanelClosedChanged);
            this.pnlLawMail.Id = new System.Guid("44b22538-593f-4254-958b-08ec279d7346");
            this.uiPanelManager1.Panels.Add(this.pnlLawMail);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("44b22538-593f-4254-958b-08ec279d7346"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(273, 113), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("44b22538-593f-4254-958b-08ec279d7346"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlLawMail
            // 
            this.pnlLawMail.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.pnlLawMail.InnerContainer = this.pnlLawMailContainer;
            resources.ApplyResources(this.pnlLawMail, "pnlLawMail");
            this.pnlLawMail.Name = "pnlLawMail";
            this.pnlLawMail.MouseEnter += new System.EventHandler(this.pnlLawMail_MouseEnter);
            this.pnlLawMail.MouseLeave += new System.EventHandler(this.pnlLawMail_MouseLeave);
            // 
            // pnlLawMailContainer
            // 
            this.pnlLawMailContainer.Controls.Add(this.label1);
            this.pnlLawMailContainer.Controls.Add(this.lblMailCountMessage);
            this.pnlLawMailContainer.Controls.Add(this.linkLabel1);
            resources.ApplyResources(this.pnlLawMailContainer, "pnlLawMailContainer");
            this.pnlLawMailContainer.Name = "pnlLawMailContainer";
            this.pnlLawMailContainer.MouseEnter += new System.EventHandler(this.pnlLawMail_MouseEnter);
            this.pnlLawMailContainer.MouseLeave += new System.EventHandler(this.pnlLawMail_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = global::LawMate.Properties.Resources.newLawMail;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.MouseEnter += new System.EventHandler(this.pnlLawMail_MouseEnter);
            // 
            // lblMailCountMessage
            // 
            resources.ApplyResources(this.lblMailCountMessage, "lblMailCountMessage");
            this.lblMailCountMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMailCountMessage.Name = "lblMailCountMessage";
            this.lblMailCountMessage.MouseEnter += new System.EventHandler(this.pnlLawMail_MouseEnter);
            // 
            // timerFade
            // 
            this.timerFade.Interval = 60;
            this.timerFade.Tick += new System.EventHandler(this.timerFade_Tick);
            // 
            // fNotify
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.pnlLawMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNotify";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.MouseEnter += new System.EventHandler(this.pnlLawMail_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.pnlLawMail_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLawMail)).EndInit();
            this.pnlLawMail.ResumeLayout(false);
            this.pnlLawMailContainer.ResumeLayout(false);
            this.pnlLawMailContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlLawMail;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlLawMailContainer;
        private System.Windows.Forms.Timer timerFade;
        private System.Windows.Forms.Label lblMailCountMessage;
        private System.Windows.Forms.Label label1;

    }
}