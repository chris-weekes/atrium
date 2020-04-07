 namespace LawMate
{
    partial class fDoc
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
                ucDoc1.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDoc));
            this.ucDoc1 = new LawMate.UserControls.ucDoc();
            this.btnOK = new System.Windows.Forms.Button();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlOk = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlOkContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlDoc = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDocContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOk)).BeginInit();
            this.pnlOk.SuspendLayout();
            this.pnlOkContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).BeginInit();
            this.pnlDoc.SuspendLayout();
            this.pnlDocContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucDoc1
            // 
            this.ucDoc1.AllowActionToolbar = false;
            this.ucDoc1.AllowRecipientSubjectEditWhenNotMail = true;
            this.ucDoc1.AllowUserCompose = true;
            resources.ApplyResources(this.ucDoc1, "ucDoc1");
            this.ucDoc1.EditMode = LawMate.UserControls.ucDoc.EditModeEnum.Read;
            this.ucDoc1.ForceTextControl = false;
            this.ucDoc1.IsManageTemplates = false;
            this.ucDoc1.Name = "ucDoc1";
            this.ucDoc1.NoDocDisplayed = false;
            this.ucDoc1.ShowAttachmentPanel = false;
            this.ucDoc1.ShowComposeToolbar = false;
            this.ucDoc1.ShowFromAndDate = true;
            this.ucDoc1.ShowRecipients = true;
            this.ucDoc1.ShowSubject = true;
            this.ucDoc1.ShowTabs = true;
            this.ucDoc1.TempFile = null;
            this.ucDoc1.TempFld = null;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlOk.Id = new System.Guid("ff4efb97-5ace-4094-8407-f4cec02cf8dc");
            this.uiPanelManager1.Panels.Add(this.pnlOk);
            this.pnlDoc.Id = new System.Guid("2966538a-26a4-4bac-8a4e-20c6ec7c68ed");
            this.uiPanelManager1.Panels.Add(this.pnlDoc);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ff4efb97-5ace-4094-8407-f4cec02cf8dc"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(758, 28), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("2966538a-26a4-4bac-8a4e-20c6ec7c68ed"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(758, 471), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ff4efb97-5ace-4094-8407-f4cec02cf8dc"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("2966538a-26a4-4bac-8a4e-20c6ec7c68ed"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlOk
            // 
            this.pnlOk.InnerContainer = this.pnlOkContainer;
            resources.ApplyResources(this.pnlOk, "pnlOk");
            this.pnlOk.Name = "pnlOk";
            // 
            // pnlOkContainer
            // 
            this.pnlOkContainer.Controls.Add(this.btnOK);
            resources.ApplyResources(this.pnlOkContainer, "pnlOkContainer");
            this.pnlOkContainer.Name = "pnlOkContainer";
            // 
            // pnlDoc
            // 
            this.pnlDoc.InnerContainer = this.pnlDocContainer;
            resources.ApplyResources(this.pnlDoc, "pnlDoc");
            this.pnlDoc.Name = "pnlDoc";
            // 
            // pnlDocContainer
            // 
            this.pnlDocContainer.Controls.Add(this.ucDoc1);
            resources.ApplyResources(this.pnlDocContainer, "pnlDocContainer");
            this.pnlDocContainer.Name = "pnlDocContainer";
            // 
            // fDoc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlDoc);
            this.Controls.Add(this.pnlOk);
            this.Name = "fDoc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fDoc_FormClosing);
            this.Shown += new System.EventHandler(this.fDoc_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOk)).EndInit();
            this.pnlOk.ResumeLayout(false);
            this.pnlOkContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDoc)).EndInit();
            this.pnlDoc.ResumeLayout(false);
            this.pnlDocContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucDoc ucDoc1;
        private System.Windows.Forms.Button btnOK;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlDoc;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDocContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlOk;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlOkContainer;
    }
}