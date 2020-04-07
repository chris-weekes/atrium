 namespace LawMate.Admin
{
    partial class fNewAC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNewAC));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ucActivityCode1 = new LawMate.Admin.ucActivityCode();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlContainer = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlNewActivity = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlNewActivityContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNewActivity)).BeginInit();
            this.pnlNewActivity.SuspendLayout();
            this.pnlNewActivityContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(813, 319);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(98, 22);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(709, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 22);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucActivityCode1
            // 
            this.ucActivityCode1.AtMng = null;
            this.ucActivityCode1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucActivityCode1.Location = new System.Drawing.Point(9, 9);
            this.ucActivityCode1.Name = "ucActivityCode1";
            this.ucActivityCode1.Size = new System.Drawing.Size(906, 304);
            this.ucActivityCode1.TabIndex = 2;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlContainer.Id = new System.Guid("ecdc8f9f-f1ee-442f-8a17-3a1076842672");
            this.pnlContainer.StaticGroup = true;
            this.pnlNewActivity.Id = new System.Guid("2be0080a-082b-4e79-bba8-1c5ca089cc6e");
            this.pnlContainer.Panels.Add(this.pnlNewActivity);
            this.uiPanelManager1.Panels.Add(this.pnlContainer);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ecdc8f9f-f1ee-442f-8a17-3a1076842672"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(920, 353), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("2be0080a-082b-4e79-bba8-1c5ca089cc6e"), new System.Guid("ecdc8f9f-f1ee-442f-8a17-3a1076842672"), 415, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ecdc8f9f-f1ee-442f-8a17-3a1076842672"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("2be0080a-082b-4e79-bba8-1c5ca089cc6e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c98449ce-6099-4e20-b8d3-71a91baeb87b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Location = new System.Drawing.Point(3, 3);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(920, 353);
            this.pnlContainer.TabIndex = 4;
            // 
            // pnlNewActivity
            // 
            this.pnlNewActivity.InnerContainer = this.pnlNewActivityContainer;
            this.pnlNewActivity.Location = new System.Drawing.Point(0, 0);
            this.pnlNewActivity.Name = "pnlNewActivity";
            this.pnlNewActivity.Size = new System.Drawing.Size(920, 353);
            this.pnlNewActivity.TabIndex = 4;
            // 
            // pnlNewActivityContainer
            // 
            this.pnlNewActivityContainer.Controls.Add(this.btnCancel);
            this.pnlNewActivityContainer.Controls.Add(this.ucActivityCode1);
            this.pnlNewActivityContainer.Controls.Add(this.btnOK);
            this.pnlNewActivityContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlNewActivityContainer.Name = "pnlNewActivityContainer";
            this.pnlNewActivityContainer.Size = new System.Drawing.Size(920, 353);
            this.pnlNewActivityContainer.TabIndex = 0;
            // 
            // fNewAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(926, 359);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNewAC";
            this.Text = "Add New Step Template";
            this.Load += new System.EventHandler(this.fNewAC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlNewActivity)).EndInit();
            this.pnlNewActivity.ResumeLayout(false);
            this.pnlNewActivityContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private ucActivityCode ucActivityCode1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlNewActivity;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlNewActivityContainer;
    }
}
