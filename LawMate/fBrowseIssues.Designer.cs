 namespace LawMate
{
    partial class fBrowseIssues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBrowseIssues));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlList = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlListContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucBrowseIssues1 = new LawMate.UserControls.ucBrowseIssues();
            this.pnlButtons = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlButtonsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.buttonCancel = new Janus.Windows.EditControls.UIButton();
            this.buttonOK = new Janus.Windows.EditControls.UIButton();
            this.pnlBottom = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBottomContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucIssueSelectBox1 = new LawMate.ucIssueSelectBox();
            this.issueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.lblBrowseIssues = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlList)).BeginInit();
            this.pnlList.SuspendLayout();
            this.pnlListContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.pnlButtonsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.issueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlList.Id = new System.Guid("109c80a0-a236-4ea5-b8d9-7f9c39478a6d");
            this.uiPanelManager1.Panels.Add(this.pnlList);
            this.pnlButtons.Id = new System.Guid("ba007189-29eb-426b-bde9-a63dd28527cc");
            this.uiPanelManager1.Panels.Add(this.pnlButtons);
            this.pnlBottom.Id = new System.Guid("180c1357-8988-4c3a-a774-8c47d8f508e6");
            this.uiPanelManager1.Panels.Add(this.pnlBottom);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("109c80a0-a236-4ea5-b8d9-7f9c39478a6d"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(294, 466), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ba007189-29eb-426b-bde9-a63dd28527cc"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(590, 46), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("180c1357-8988-4c3a-a774-8c47d8f508e6"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(590, 420), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("180c1357-8988-4c3a-a774-8c47d8f508e6"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("109c80a0-a236-4ea5-b8d9-7f9c39478a6d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ba007189-29eb-426b-bde9-a63dd28527cc"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlList
            // 
            resources.ApplyResources(this.pnlList, "pnlList");
            this.pnlList.InnerContainer = this.pnlListContainer;
            this.pnlList.Name = "pnlList";
            // 
            // pnlListContainer
            // 
            this.pnlListContainer.Controls.Add(this.ucBrowseIssues1);
            resources.ApplyResources(this.pnlListContainer, "pnlListContainer");
            this.pnlListContainer.Name = "pnlListContainer";
            // 
            // ucBrowseIssues1
            // 
            resources.ApplyResources(this.ucBrowseIssues1, "ucBrowseIssues1");
            this.ucBrowseIssues1.Name = "ucBrowseIssues1";
            this.ucBrowseIssues1.IssueSelected += new LawMate.UserControls.BrowseIssueEventHandler(this.ucBrowseIssues1_IssueSelected);
            this.ucBrowseIssues1.IssueNavigated += new LawMate.UserControls.IssueSelectionChangeEventHandler(this.ucBrowseIssues1_IssueNavigated);
            // 
            // pnlButtons
            // 
            this.pnlButtons.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlButtons.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlButtons.InnerContainer = this.pnlButtonsContainer;
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.Name = "pnlButtons";
            // 
            // pnlButtonsContainer
            // 
            this.pnlButtonsContainer.Controls.Add(this.buttonCancel);
            this.pnlButtonsContainer.Controls.Add(this.buttonOK);
            resources.ApplyResources(this.pnlButtonsContainer, "pnlButtonsContainer");
            this.pnlButtonsContainer.Name = "pnlButtonsContainer";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.buttonOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBottom.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlBottom.InnerContainer = this.pnlBottomContainer;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // pnlBottomContainer
            // 
            resources.ApplyResources(this.pnlBottomContainer, "pnlBottomContainer");
            this.pnlBottomContainer.Controls.Add(this.ucIssueSelectBox1);
            this.pnlBottomContainer.Name = "pnlBottomContainer";
            // 
            // ucIssueSelectBox1
            // 
            this.ucIssueSelectBox1.AtMng = null;
            resources.ApplyResources(this.ucIssueSelectBox1, "ucIssueSelectBox1");
            this.ucIssueSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucIssueSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("IssueId", this.issueBindingSource, "IssueId", true));
            this.ucIssueSelectBox1.IssueId = null;
            this.ucIssueSelectBox1.Name = "ucIssueSelectBox1";
            this.ucIssueSelectBox1.ReadOnly = true;
            this.ucIssueSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            // 
            // issueBindingSource
            // 
            this.issueBindingSource.DataMember = "Issue";
            this.issueBindingSource.DataSource = this.appDB;
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblBrowseIssues
            // 
            this.lblBrowseIssues.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblBrowseIssues, "lblBrowseIssues");
            this.lblBrowseIssues.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblBrowseIssues.Image = global::LawMate.Properties.Resources.scaleBig;
            this.lblBrowseIssues.Name = "lblBrowseIssues";
            // 
            // fBrowseIssues
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fBrowseIssues";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlList)).EndInit();
            this.pnlList.ResumeLayout(false);
            this.pnlListContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtonsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.issueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucBrowseIssues ucBrowseIssues1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlBottom;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBottomContainer;
        private System.Windows.Forms.Label lblBrowseIssues;
        private Janus.Windows.UI.Dock.UIPanel pnlList;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlListContainer;
        private System.Windows.Forms.BindingSource issueBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.EditControls.UIButton buttonOK;
        private Janus.Windows.EditControls.UIButton buttonCancel;
        private ucIssueSelectBox ucIssueSelectBox1;
        private Janus.Windows.UI.Dock.UIPanel pnlButtons;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlButtonsContainer;
    }
}