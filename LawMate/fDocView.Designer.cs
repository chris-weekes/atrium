namespace LawMate
{
    partial class fDocView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDocView));
            this.ucDocView1 = new LawMate.UserControls.ucDocView();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlBottom = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBottomContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.pnlDoc = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).BeginInit();
            this.pnlDoc.SuspendLayout();
            this.pnlDocContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucDocView1
            // 
            this.ucDocView1.ActionToolbarView = LawMate.UserControls.DocCommandBar.Enable;
            this.ucDocView1.AllowActionToolbar = true;
            this.ucDocView1.AllowMetadata = true;
            this.ucDocView1.AllowMetadataUpdate = false;
            this.ucDocView1.DocDisplayType = LawMate.UserControls.DocViewDisplayType.MailHeader;
            this.ucDocView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDocView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDocView1.ForceTextControl = false;
            this.ucDocView1.Location = new System.Drawing.Point(0, 0);
            this.ucDocView1.Name = "ucDocView1";
            this.ucDocView1.NoDocDisplayed = false;
            this.ucDocView1.ShowAttachmentPanel = true;
            this.ucDocView1.ShowMetadata = true;
            this.ucDocView1.ShowVersion = false;
            this.ucDocView1.Size = new System.Drawing.Size(942, 410);
            this.ucDocView1.TabIndex = 0;
            this.ucDocView1.TempFile = null;
            this.ucDocView1.TempFld = null;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.PanelPadding.Bottom = 0;
            this.uiPanelManager1.PanelPadding.Left = 0;
            this.uiPanelManager1.PanelPadding.Right = 0;
            this.uiPanelManager1.PanelPadding.Top = 0;
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlBottom.Id = new System.Guid("2e83f4b0-a77a-46bf-a93a-f4d622427e76");
            this.uiPanelManager1.Panels.Add(this.pnlBottom);
            this.pnlDoc.Id = new System.Guid("7a49c21b-1536-48c2-b500-13e5c2517a24");
            this.uiPanelManager1.Panels.Add(this.pnlDoc);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("7a49c21b-1536-48c2-b500-13e5c2517a24"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(942, 410), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("2e83f4b0-a77a-46bf-a93a-f4d622427e76"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(871, 65), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("2e83f4b0-a77a-46bf-a93a-f4d622427e76"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7a49c21b-1536-48c2-b500-13e5c2517a24"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.Closed = true;
            this.pnlBottom.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlBottom.InnerContainer = this.pnlBottomContainer;
            this.pnlBottom.Location = new System.Drawing.Point(0, 345);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(871, 65);
            this.pnlBottom.TabIndex = 4;
            this.pnlBottom.Text = "bottom";
            // 
            // pnlBottomContainer
            // 
            this.pnlBottomContainer.Controls.Add(this.uiButton1);
            this.pnlBottomContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlBottomContainer.Name = "pnlBottomContainer";
            this.pnlBottomContainer.Size = new System.Drawing.Size(871, 65);
            this.pnlBottomContainer.TabIndex = 0;
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton1.Location = new System.Drawing.Point(786, 34);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(75, 23);
            this.uiButton1.TabIndex = 0;
            this.uiButton1.Text = "Close";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton1.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlDoc
            // 
            this.pnlDoc.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlDoc.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlDoc.InnerContainer = this.pnlDocContainer;
            this.pnlDoc.Location = new System.Drawing.Point(0, 0);
            this.pnlDoc.Name = "pnlDoc";
            this.pnlDoc.Size = new System.Drawing.Size(942, 410);
            this.pnlDoc.TabIndex = 4;
            this.pnlDoc.Text = "Panel 0";
            // 
            // pnlDocContainer
            // 
            this.pnlDocContainer.Controls.Add(this.ucDocView1);
            this.pnlDocContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlDocContainer.Name = "pnlDocContainer";
            this.pnlDocContainer.Size = new System.Drawing.Size(942, 410);
            this.pnlDocContainer.TabIndex = 0;
            // 
            // fDocView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(942, 410);
            this.Controls.Add(this.pnlDoc);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fDocView";
            this.Text = "Document Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fDoc_FormClosing);
            this.Shown += new System.EventHandler(this.fDoc_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).EndInit();
            this.pnlDoc.ResumeLayout(false);
            this.pnlDocContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucDocView ucDocView1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlDoc;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBottom;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBottomContainer;
        private Janus.Windows.EditControls.UIButton uiButton1;
    }
}