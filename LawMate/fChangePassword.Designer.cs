 namespace LawMate
{
    partial class fChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChangePassword));
            this.tbOldPass = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tbNewPass = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tbConfirmPass = new Janus.Windows.GridEX.EditControls.EditBox();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbOldPass
            // 
            resources.ApplyResources(this.tbOldPass, "tbOldPass");
            this.tbOldPass.Name = "tbOldPass";
            this.tbOldPass.PasswordChar = '*';
            this.tbOldPass.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // tbNewPass
            // 
            resources.ApplyResources(this.tbNewPass, "tbNewPass");
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.PasswordChar = '*';
            this.tbNewPass.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // tbConfirmPass
            // 
            resources.ApplyResources(this.tbConfirmPass, "tbConfirmPass");
            this.tbConfirmPass.Name = "tbConfirmPass";
            this.tbConfirmPass.PasswordChar = '*';
            this.tbConfirmPass.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lblOldPass
            // 
            resources.ApplyResources(this.lblOldPass, "lblOldPass");
            this.lblOldPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldPass.Name = "lblOldPass";
            // 
            // lblNewPass
            // 
            resources.ApplyResources(this.lblNewPass, "lblNewPass");
            this.lblNewPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNewPass.Name = "lblNewPass";
            // 
            // lblConfirmPass
            // 
            resources.ApplyResources(this.lblConfirmPass, "lblConfirmPass");
            this.lblConfirmPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConfirmPass.Name = "lblConfirmPass";
            // 
            // lblText
            // 
            resources.ApplyResources(this.lblText, "lblText");
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Image = global::LawMate.Properties.Resources.passwordchange;
            this.lblText.Name = "lblText";
            // 
            // uiButton1
            // 
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.HighlightActiveButton = false;
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            // fChangePassword
            // 
            this.AcceptButton = this.uiButton1;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.tbConfirmPass);
            this.Controls.Add(this.tbNewPass);
            this.Controls.Add(this.tbOldPass);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.lblOldPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "fChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.EditControls.EditBox tbOldPass;
        private Janus.Windows.GridEX.EditControls.EditBox tbNewPass;
        private Janus.Windows.GridEX.EditControls.EditBox tbConfirmPass;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}