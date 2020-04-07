namespace LawMate
{
    partial class ucSSTCaseMatter
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
            System.Windows.Forms.Label descriptionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSSTCaseMatter));
            System.Windows.Forms.Label lblOutcome;
            System.Windows.Forms.Label issueIdLabel;
            System.Windows.Forms.Label lblAcceptIssue;
            Janus.Windows.GridEX.GridEXLayout sSTCaseMatterGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference sSTCaseMatterGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference sSTCaseMatterGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ButtonImage");
            this.DescCounter = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.descriptionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sSTCaseMatterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sSTCaseMatterGridEX = new Janus.Windows.GridEX.GridEX();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddIssue = new Janus.Windows.EditControls.UIButton();
            this.pnlAcceptIssue = new System.Windows.Forms.Panel();
            this.uiButtonUndo = new Janus.Windows.EditControls.UIButton();
            this.uirdbtnNo = new Janus.Windows.EditControls.UIRadioButton();
            this.uirdbtnYes = new Janus.Windows.EditControls.UIRadioButton();
            this.lblYesMessage = new System.Windows.Forms.Label();
            this.lblNoMessage = new System.Windows.Forms.Label();
            this.panelIssueList = new System.Windows.Forms.Panel();
            this.ucIssueSelectBoxRF1 = new LawMate.ucIssueSelectBoxRF();
            this.outcomeIducMultiDropDown = new LawMate.UserControls.ucMultiDropDown();
            descriptionLabel = new System.Windows.Forms.Label();
            lblOutcome = new System.Windows.Forms.Label();
            issueIdLabel = new System.Windows.Forms.Label();
            lblAcceptIssue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sSTCaseMatterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSTCaseMatterGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.pnlAcceptIssue.SuspendLayout();
            this.panelIssueList.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            resources.ApplyResources(descriptionLabel, "descriptionLabel");
            descriptionLabel.Name = "descriptionLabel";
            // 
            // lblOutcome
            // 
            resources.ApplyResources(lblOutcome, "lblOutcome");
            lblOutcome.Name = "lblOutcome";
            // 
            // issueIdLabel
            // 
            resources.ApplyResources(issueIdLabel, "issueIdLabel");
            issueIdLabel.Name = "issueIdLabel";
            // 
            // lblAcceptIssue
            // 
            resources.ApplyResources(lblAcceptIssue, "lblAcceptIssue");
            lblAcceptIssue.Name = "lblAcceptIssue";
            // 
            // DescCounter
            // 
            this.DescCounter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DescCounter.DecimalDigits = 0;
            this.DescCounter.ForeColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.DescCounter, "DescCounter");
            this.DescCounter.MaxLength = 3;
            this.DescCounter.Name = "DescCounter";
            this.DescCounter.ReadOnly = true;
            this.DescCounter.TabStop = false;
            this.DescCounter.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.DescCounter.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DescCounter.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // descriptionEditBox
            // 
            this.descriptionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sSTCaseMatterBindingSource, "Description", true));
            resources.ApplyResources(this.descriptionEditBox, "descriptionEditBox");
            this.descriptionEditBox.Multiline = true;
            this.descriptionEditBox.Name = "descriptionEditBox";
            this.descriptionEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.descriptionEditBox.TextChanged += new System.EventHandler(this.descriptionEditBox_TextChanged);
            // 
            // sSTCaseMatterBindingSource
            // 
            this.sSTCaseMatterBindingSource.DataMember = "SSTCaseMatter";
            this.sSTCaseMatterBindingSource.DataSource = typeof(lmDatasets.SST);
            // 
            // sSTCaseMatterGridEX
            // 
            this.sSTCaseMatterGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sSTCaseMatterGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            this.sSTCaseMatterGridEX.DataSource = this.sSTCaseMatterBindingSource;
            sSTCaseMatterGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("sSTCaseMatterGridEX_DesignTimeLayout_Reference_0.Instance")));
            sSTCaseMatterGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("sSTCaseMatterGridEX_DesignTimeLayout_Reference_1.Instance")));
            sSTCaseMatterGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            sSTCaseMatterGridEX_DesignTimeLayout_Reference_0,
            sSTCaseMatterGridEX_DesignTimeLayout_Reference_1});
            resources.ApplyResources(sSTCaseMatterGridEX_DesignTimeLayout, "sSTCaseMatterGridEX_DesignTimeLayout");
            this.sSTCaseMatterGridEX.DesignTimeLayout = sSTCaseMatterGridEX_DesignTimeLayout;
            this.sSTCaseMatterGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.sSTCaseMatterGridEX, "sSTCaseMatterGridEX");
            this.sSTCaseMatterGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.sSTCaseMatterGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.sSTCaseMatterGridEX.GroupByBoxVisible = false;
            this.sSTCaseMatterGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.sSTCaseMatterGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.sSTCaseMatterGridEX.Indent = 20;
            this.sSTCaseMatterGridEX.Name = "sSTCaseMatterGridEX";
            this.sSTCaseMatterGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.sSTCaseMatterGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.sSTCaseMatterGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.sSTCaseMatterGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.sSTCaseMatterGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.sSTCaseMatterGridEX_ColumnButtonClick);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.sSTCaseMatterBindingSource;
            // 
            // btnAddIssue
            // 
            this.btnAddIssue.Image = global::LawMate.Properties.Resources.issue;
            resources.ApplyResources(this.btnAddIssue, "btnAddIssue");
            this.btnAddIssue.Name = "btnAddIssue";
            this.btnAddIssue.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnAddIssue.Click += new System.EventHandler(this.btnAddIssue_Click);
            // 
            // pnlAcceptIssue
            // 
            this.pnlAcceptIssue.Controls.Add(this.uiButtonUndo);
            this.pnlAcceptIssue.Controls.Add(this.uirdbtnNo);
            this.pnlAcceptIssue.Controls.Add(this.uirdbtnYes);
            this.pnlAcceptIssue.Controls.Add(lblAcceptIssue);
            this.pnlAcceptIssue.Controls.Add(this.lblYesMessage);
            this.pnlAcceptIssue.Controls.Add(this.lblNoMessage);
            resources.ApplyResources(this.pnlAcceptIssue, "pnlAcceptIssue");
            this.pnlAcceptIssue.Name = "pnlAcceptIssue";
            // 
            // uiButtonUndo
            // 
            this.uiButtonUndo.Image = global::LawMate.Properties.Resources.cancel1;
            resources.ApplyResources(this.uiButtonUndo, "uiButtonUndo");
            this.uiButtonUndo.Name = "uiButtonUndo";
            this.uiButtonUndo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButtonUndo.Click += new System.EventHandler(this.uiButtonUndo_Click);
            // 
            // uirdbtnNo
            // 
            this.uirdbtnNo.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            resources.ApplyResources(this.uirdbtnNo, "uirdbtnNo");
            this.uirdbtnNo.Name = "uirdbtnNo";
            this.uirdbtnNo.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // uirdbtnYes
            // 
            this.uirdbtnYes.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            resources.ApplyResources(this.uirdbtnYes, "uirdbtnYes");
            this.uirdbtnYes.Name = "uirdbtnYes";
            this.uirdbtnYes.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lblYesMessage
            // 
            resources.ApplyResources(this.lblYesMessage, "lblYesMessage");
            this.lblYesMessage.Name = "lblYesMessage";
            // 
            // lblNoMessage
            // 
            resources.ApplyResources(this.lblNoMessage, "lblNoMessage");
            this.lblNoMessage.Name = "lblNoMessage";
            // 
            // panelIssueList
            // 
            this.panelIssueList.Controls.Add(this.btnAddIssue);
            this.panelIssueList.Controls.Add(issueIdLabel);
            this.panelIssueList.Controls.Add(lblOutcome);
            this.panelIssueList.Controls.Add(this.ucIssueSelectBoxRF1);
            this.panelIssueList.Controls.Add(this.sSTCaseMatterGridEX);
            this.panelIssueList.Controls.Add(this.outcomeIducMultiDropDown);
            this.panelIssueList.Controls.Add(this.descriptionEditBox);
            this.panelIssueList.Controls.Add(this.DescCounter);
            this.panelIssueList.Controls.Add(descriptionLabel);
            resources.ApplyResources(this.panelIssueList, "panelIssueList");
            this.panelIssueList.Name = "panelIssueList";
            // 
            // ucIssueSelectBoxRF1
            // 
            resources.ApplyResources(this.ucIssueSelectBoxRF1, "ucIssueSelectBoxRF1");
            this.ucIssueSelectBoxRF1.BackColor = System.Drawing.Color.Transparent;
            this.ucIssueSelectBoxRF1.DataBindings.Add(new System.Windows.Forms.Binding("IssueId", this.sSTCaseMatterBindingSource, "IssueId", true));
            this.ucIssueSelectBoxRF1.FM = null;
            this.ucIssueSelectBoxRF1.IssueId = null;
            this.ucIssueSelectBoxRF1.Name = "ucIssueSelectBoxRF1";
            this.ucIssueSelectBoxRF1.ReadOnly = false;
            this.ucIssueSelectBoxRF1.ReqColor = System.Drawing.Color.White;
            this.ucIssueSelectBoxRF1.IssueChangedEvent += new LawMate.ucIssueSelectBoxRF.IssueChangedEventHandler(this.ucIssueSelectBoxRF1_IssueChangedEvent);
            // 
            // outcomeIducMultiDropDown
            // 
            this.outcomeIducMultiDropDown.BackColor = System.Drawing.Color.Transparent;
            this.outcomeIducMultiDropDown.Column1 = "OutcomeId";
            resources.ApplyResources(this.outcomeIducMultiDropDown, "outcomeIducMultiDropDown");
            this.outcomeIducMultiDropDown.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.outcomeIducMultiDropDown.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sSTCaseMatterBindingSource, "OutcomeId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outcomeIducMultiDropDown.DataSource = null;
            this.outcomeIducMultiDropDown.DDColumn1Visible = false;
            this.outcomeIducMultiDropDown.DropDownColumn1Width = 100;
            this.outcomeIducMultiDropDown.DropDownColumn2Width = 300;
            this.outcomeIducMultiDropDown.Name = "outcomeIducMultiDropDown";
            this.outcomeIducMultiDropDown.ReadOnly = false;
            this.outcomeIducMultiDropDown.ReqColor = System.Drawing.SystemColors.Window;
            this.outcomeIducMultiDropDown.SelectedValue = null;
            this.outcomeIducMultiDropDown.ValueMember = "OutcomeId";
            this.outcomeIducMultiDropDown.Validated += new System.EventHandler(this.outcomeIducMultiDropDown_Validated);
            // 
            // ucSSTCaseMatter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelIssueList);
            this.Controls.Add(this.pnlAcceptIssue);
            this.Name = "ucSSTCaseMatter";
            ((System.ComponentModel.ISupportInitialize)(this.sSTCaseMatterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSTCaseMatterGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.pnlAcceptIssue.ResumeLayout(false);
            this.pnlAcceptIssue.PerformLayout();
            this.panelIssueList.ResumeLayout(false);
            this.panelIssueList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucIssueSelectBoxRF ucIssueSelectBoxRF1;
        private UserControls.ucMultiDropDown outcomeIducMultiDropDown;
        private Janus.Windows.GridEX.EditControls.NumericEditBox DescCounter;
        private Janus.Windows.GridEX.EditControls.EditBox descriptionEditBox;
        private Janus.Windows.GridEX.GridEX sSTCaseMatterGridEX;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private Janus.Windows.EditControls.UIButton btnAddIssue;
        private System.Windows.Forms.Panel pnlAcceptIssue;
        private Janus.Windows.EditControls.UIRadioButton uirdbtnYes;
        private Janus.Windows.EditControls.UIRadioButton uirdbtnNo;
        private System.Windows.Forms.Label lblYesMessage;
        private System.Windows.Forms.Label lblNoMessage;
        public System.Windows.Forms.BindingSource sSTCaseMatterBindingSource;
        private Janus.Windows.EditControls.UIButton uiButtonUndo;
        private System.Windows.Forms.Panel panelIssueList;
    }
}
