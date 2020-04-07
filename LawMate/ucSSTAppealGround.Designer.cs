namespace LawMate
{
    partial class ucSSTAppealGround
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSSTAppealGround));
            Janus.Windows.GridEX.GridEXLayout SSTAppealGroundGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.panelAppealGround = new System.Windows.Forms.Panel();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.labelIdentifyGrounds = new System.Windows.Forms.Label();
            this.btnConfirmAppealGround = new Janus.Windows.EditControls.UIButton();
            this.SSTAppealGroundGridEX = new Janus.Windows.GridEX.GridEX();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.SSTAppealGroundBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelAppealGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSTAppealGroundGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSTAppealGroundBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAppealGround
            // 
            this.panelAppealGround.Controls.Add(this.labelDepartment);
            this.panelAppealGround.Controls.Add(this.labelIdentifyGrounds);
            this.panelAppealGround.Controls.Add(this.btnConfirmAppealGround);
            this.panelAppealGround.Controls.Add(this.SSTAppealGroundGridEX);
            resources.ApplyResources(this.panelAppealGround, "panelAppealGround");
            this.panelAppealGround.Name = "panelAppealGround";
            // 
            // labelDepartment
            // 
            resources.ApplyResources(this.labelDepartment, "labelDepartment");
            this.labelDepartment.Name = "labelDepartment";
            // 
            // labelIdentifyGrounds
            // 
            resources.ApplyResources(this.labelIdentifyGrounds, "labelIdentifyGrounds");
            this.labelIdentifyGrounds.Name = "labelIdentifyGrounds";
            // 
            // btnConfirmAppealGround
            // 
            resources.ApplyResources(this.btnConfirmAppealGround, "btnConfirmAppealGround");
            this.btnConfirmAppealGround.Image = global::LawMate.Properties.Resources.gavel2;
            this.btnConfirmAppealGround.Name = "btnConfirmAppealGround";
            this.btnConfirmAppealGround.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnConfirmAppealGround.Click += new System.EventHandler(this.btnConfirmAppealGround_Click);
            // 
            // SSTAppealGroundGridEX
            // 
            this.SSTAppealGroundGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SSTAppealGroundGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
            resources.ApplyResources(SSTAppealGroundGridEX_DesignTimeLayout, "SSTAppealGroundGridEX_DesignTimeLayout");
            this.SSTAppealGroundGridEX.DesignTimeLayout = SSTAppealGroundGridEX_DesignTimeLayout;
            this.SSTAppealGroundGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.SSTAppealGroundGridEX, "SSTAppealGroundGridEX");
            this.SSTAppealGroundGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.SSTAppealGroundGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.SSTAppealGroundGridEX.GroupByBoxVisible = false;
            this.SSTAppealGroundGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.SSTAppealGroundGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.SSTAppealGroundGridEX.Indent = 20;
            this.SSTAppealGroundGridEX.Name = "SSTAppealGroundGridEX";
            this.SSTAppealGroundGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.SSTAppealGroundGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.SSTAppealGroundGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.SSTAppealGroundGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.SSTAppealGroundGridEX.RowCheckStateChanging += new Janus.Windows.GridEX.RowCheckStateChangingEventHandler(this.SSTAppealGroundGridEX_RowCheckStateChanging);
            this.SSTAppealGroundGridEX.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.SSTAppealGroundGridEX_RowCheckStateChanged);
            this.SSTAppealGroundGridEX.EditingCell += new Janus.Windows.GridEX.EditingCellEventHandler(this.SSTAppealGroundGridEX_EditingCell);
            this.SSTAppealGroundGridEX.UpdatingCell += new Janus.Windows.GridEX.UpdatingCellEventHandler(this.SSTAppealGroundGridEX_UpdatingCell);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.SSTAppealGroundBindingSource;
            // 
            // SSTAppealGroundBindingSource
            // 
            this.SSTAppealGroundBindingSource.DataMember = "AppealGround";
            this.SSTAppealGroundBindingSource.DataSource = typeof(lmDatasets.CodesDB);
            // 
            // ucSSTAppealGround
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelAppealGround);
            this.Name = "ucSSTAppealGround";
            this.panelAppealGround.ResumeLayout(false);
            this.panelAppealGround.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSTAppealGroundGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSTAppealGroundBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource SSTAppealGroundBindingSource;
        private System.Windows.Forms.Panel panelAppealGround;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private Janus.Windows.GridEX.GridEX SSTAppealGroundGridEX;
        private Janus.Windows.EditControls.UIButton btnConfirmAppealGround;
        private System.Windows.Forms.Label labelIdentifyGrounds;
        private System.Windows.Forms.Label labelDepartment;
    }
}
