 namespace LawMate
{
    partial class fSecurity
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
            System.Windows.Forms.Label userNameLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSecurity));
            System.Windows.Forms.Label passwordLabel;
            Janus.Windows.GridEX.GridEXLayout secMembershipGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.secUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.securityDB = new lmDatasets.SecurityDB();
            this.secMembershipGridEX = new Janus.Windows.GridEX.GridEX();
            this.secMembershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.uiRadioButton2 = new Janus.Windows.EditControls.UIRadioButton();
            this.uiRadioButton1 = new Janus.Windows.EditControls.UIRadioButton();
            this.lockedOutUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.activeUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.btnDeleteOfficerAccount = new Janus.Windows.EditControls.UIButton();
            this.passwordEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.userNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            userNameLabel1 = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.secUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secMembershipGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secMembershipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userNameLabel1
            // 
            resources.ApplyResources(userNameLabel1, "userNameLabel1");
            userNameLabel1.Name = "userNameLabel1";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(passwordLabel, "passwordLabel");
            passwordLabel.Name = "passwordLabel";
            // 
            // secUserBindingSource
            // 
            this.secUserBindingSource.DataMember = "secUser";
            this.secUserBindingSource.DataSource = this.securityDB;
            // 
            // securityDB
            // 
            this.securityDB.DataSetName = "SecurityDB";
            this.securityDB.EnforceConstraints = false;
            this.securityDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // secMembershipGridEX
            // 
            this.secMembershipGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            resources.ApplyResources(this.secMembershipGridEX, "secMembershipGridEX");
            this.secMembershipGridEX.DataSource = this.secMembershipBindingSource;
            resources.ApplyResources(secMembershipGridEX_DesignTimeLayout, "secMembershipGridEX_DesignTimeLayout");
            this.secMembershipGridEX.DesignTimeLayout = secMembershipGridEX_DesignTimeLayout;
            this.secMembershipGridEX.GroupByBoxVisible = false;
            this.secMembershipGridEX.Name = "secMembershipGridEX";
            this.secMembershipGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.secMembershipGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // secMembershipBindingSource
            // 
            this.secMembershipBindingSource.DataMember = "FK_secMembership_secUser";
            this.secMembershipBindingSource.DataSource = this.secUserBindingSource;
            // 
            // uiGroupBox1
            // 
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.BorderColor = System.Drawing.SystemColors.Control;
            this.uiGroupBox1.Controls.Add(this.uiRadioButton2);
            this.uiGroupBox1.Controls.Add(this.uiRadioButton1);
            this.uiGroupBox1.Controls.Add(this.lockedOutUICheckBox);
            this.uiGroupBox1.Controls.Add(this.activeUICheckBox);
            this.uiGroupBox1.Controls.Add(passwordLabel);
            this.uiGroupBox1.Controls.Add(this.btnDeleteOfficerAccount);
            this.uiGroupBox1.Controls.Add(this.passwordEditBox);
            this.uiGroupBox1.Controls.Add(userNameLabel1);
            this.uiGroupBox1.Controls.Add(this.userNameEditBox);
            this.uiGroupBox1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox1.Image = global::LawMate.Properties.Resources.passwordchange;
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.UseThemes = false;
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.CheckedValue = 1;
            this.uiRadioButton2.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.secUserBindingSource, "AuthType", true));
            resources.ApplyResources(this.uiRadioButton2, "uiRadioButton2");
            this.uiRadioButton2.Name = "uiRadioButton2";
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.CheckedValue = 0;
            this.uiRadioButton1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.secUserBindingSource, "AuthType", true));
            resources.ApplyResources(this.uiRadioButton1, "uiRadioButton1");
            this.uiRadioButton1.Name = "uiRadioButton1";
            // 
            // lockedOutUICheckBox
            // 
            this.lockedOutUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lockedOutUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.secUserBindingSource, "LockedOut", true));
            resources.ApplyResources(this.lockedOutUICheckBox, "lockedOutUICheckBox");
            this.lockedOutUICheckBox.Name = "lockedOutUICheckBox";
            this.lockedOutUICheckBox.ShowFocusRectangle = false;
            this.lockedOutUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // activeUICheckBox
            // 
            this.activeUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.activeUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.secUserBindingSource, "Active", true));
            resources.ApplyResources(this.activeUICheckBox, "activeUICheckBox");
            this.activeUICheckBox.Name = "activeUICheckBox";
            this.activeUICheckBox.ShowFocusRectangle = false;
            this.activeUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // btnDeleteOfficerAccount
            // 
            this.btnDeleteOfficerAccount.Image = global::LawMate.Properties.Resources.delete1;
            resources.ApplyResources(this.btnDeleteOfficerAccount, "btnDeleteOfficerAccount");
            this.btnDeleteOfficerAccount.Name = "btnDeleteOfficerAccount";
            this.btnDeleteOfficerAccount.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnDeleteOfficerAccount.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // passwordEditBox
            // 
            resources.ApplyResources(this.passwordEditBox, "passwordEditBox");
            this.passwordEditBox.Name = "passwordEditBox";
            this.passwordEditBox.PasswordChar = '*';
            this.passwordEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // userNameEditBox
            // 
            this.userNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.secUserBindingSource, "UserName", true));
            resources.ApplyResources(this.userNameEditBox, "userNameEditBox");
            this.userNameEditBox.Name = "userNameEditBox";
            this.userNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiButton1
            // 
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // uiButton2
            // 
            resources.ApplyResources(this.uiButton2, "uiButton2");
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // uiButton3
            // 
            resources.ApplyResources(this.uiButton3, "uiButton3");
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton3.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fSecurity
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.secMembershipGridEX);
            this.Name = "fSecurity";
            this.Load += new System.EventHandler(this.fSecurity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.secUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secMembershipGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secMembershipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX secMembershipGridEX;
        private lmDatasets.SecurityDB securityDB;
        private System.Windows.Forms.BindingSource secUserBindingSource;
        private System.Windows.Forms.BindingSource secMembershipBindingSource;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnDeleteOfficerAccount;
        private Janus.Windows.EditControls.UICheckBox lockedOutUICheckBox;
        private Janus.Windows.EditControls.UICheckBox activeUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox passwordEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox userNameEditBox;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton3;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButton2;
        private Janus.Windows.EditControls.UIRadioButton uiRadioButton1;
    }
}