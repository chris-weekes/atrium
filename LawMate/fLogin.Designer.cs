 namespace LawMate
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.editBox2 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btnLogin = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.EnglishRadio = new System.Windows.Forms.RadioButton();
            this.FrenchRadio = new System.Windows.Forms.RadioButton();
            this.gbUser = new Janus.Windows.EditControls.UIGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.gbLanguage = new Janus.Windows.EditControls.UIGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.fwPassword = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gbUser)).BeginInit();
            this.gbUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbLanguage)).BeginInit();
            this.gbLanguage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // editBox1
            // 
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.MaxLength = 25;
            this.editBox1.Name = "editBox1";
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // editBox2
            // 
            resources.ApplyResources(this.editBox2, "editBox2");
            this.editBox2.ButtonFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBox2.MaxLength = 25;
            this.editBox2.Name = "editBox2";
            this.editBox2.PasswordChar = '*';
            this.editBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.editBox2.TextChanged += new System.EventHandler(this.editBox2_TextChanged);
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnLogin.HighlightActiveButton = false;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatBorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancel.HighlightActiveButton = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EnglishRadio
            // 
            resources.ApplyResources(this.EnglishRadio, "EnglishRadio");
            this.EnglishRadio.Checked = true;
            this.EnglishRadio.Name = "EnglishRadio";
            this.EnglishRadio.TabStop = true;
            this.EnglishRadio.UseVisualStyleBackColor = true;
            // 
            // FrenchRadio
            // 
            resources.ApplyResources(this.FrenchRadio, "FrenchRadio");
            this.FrenchRadio.Name = "FrenchRadio";
            this.FrenchRadio.UseVisualStyleBackColor = true;
            // 
            // gbUser
            // 
            resources.ApplyResources(this.gbUser, "gbUser");
            this.gbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.gbUser.BorderColor = System.Drawing.SystemColors.Control;
            this.gbUser.Controls.Add(this.label1);
            this.gbUser.Controls.Add(this.editBox1);
            this.gbUser.Controls.Add(this.label7);
            this.gbUser.Controls.Add(this.editBox2);
            this.gbUser.Controls.Add(this.label8);
            this.gbUser.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbUser.Name = "gbUser";
            this.gbUser.UseThemes = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Image = global::LawMate.Properties.Resources.PC32x32;
            this.label1.Name = "label1";
            // 
            // cboServer
            // 
            resources.ApplyResources(this.cboServer, "cboServer");
            this.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Name = "cboServer";
            this.cboServer.SelectedValueChanged += new System.EventHandler(this.cboServer_SelectedValueChanged);
            // 
            // gbLanguage
            // 
            resources.ApplyResources(this.gbLanguage, "gbLanguage");
            this.gbLanguage.BackColor = System.Drawing.Color.Transparent;
            this.gbLanguage.BorderColor = System.Drawing.SystemColors.Control;
            this.gbLanguage.Controls.Add(this.label3);
            this.gbLanguage.Controls.Add(this.EnglishRadio);
            this.gbLanguage.Controls.Add(this.FrenchRadio);
            this.gbLanguage.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.gbLanguage.Name = "gbLanguage";
            this.gbLanguage.UseThemes = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Image = global::LawMate.Properties.Resources.language32x32_2_;
            this.label3.Name = "label3";
            // 
            // uiGroupBox1
            // 
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.BorderColor = System.Drawing.SystemColors.Control;
            this.uiGroupBox1.Controls.Add(this.fwPassword);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.cboServer);
            this.uiGroupBox1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.UseThemes = false;
            // 
            // fwPassword
            // 
            resources.ApplyResources(this.fwPassword, "fwPassword");
            this.fwPassword.ButtonFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwPassword.MaxLength = 25;
            this.fwPassword.Name = "fwPassword";
            this.fwPassword.PasswordChar = '*';
            this.fwPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Image = global::LawMate.Properties.Resources.db32x32;
            this.label2.Name = "label2";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.gbLanguage);
            this.Controls.Add(this.gbUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.Shown += new System.EventHandler(this.fLogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gbUser)).EndInit();
            this.gbUser.ResumeLayout(false);
            this.gbUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbLanguage)).EndInit();
            this.gbLanguage.ResumeLayout(false);
            this.gbLanguage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.EditControls.UIButton btnLogin;
        public Janus.Windows.GridEX.EditControls.EditBox editBox1;
        public Janus.Windows.GridEX.EditControls.EditBox editBox2;
        public Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIGroupBox gbUser;
        private Janus.Windows.EditControls.UIGroupBox gbLanguage;
        public System.Windows.Forms.RadioButton EnglishRadio;
        public System.Windows.Forms.RadioButton FrenchRadio;
        public System.Windows.Forms.ComboBox cboServer;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public Janus.Windows.GridEX.EditControls.EditBox fwPassword;
        private System.Windows.Forms.Label label4;
    }
}