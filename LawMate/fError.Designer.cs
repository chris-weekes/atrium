namespace LawMate
{
    partial class fError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fError));
            this.lblImg = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiButton3 = new Janus.Windows.EditControls.UIButton();
            this.SuspendLayout();
            // 
            // lblImg
            // 
            this.lblImg.Image = global::LawMate.Properties.Resources.tripup1;
            this.lblImg.Location = new System.Drawing.Point(12, 9);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(46, 45);
            this.lblImg.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(64, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(353, 14);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "We\'re sorry, but an error has occurred. Please see the message below:";
            // 
            // editBox1
            // 
            this.editBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBox1.Location = new System.Drawing.Point(67, 37);
            this.editBox1.Multiline = true;
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.editBox1.Size = new System.Drawing.Size(449, 210);
            this.editBox1.TabIndex = 3;
            this.editBox1.Text = "[Error Text]";
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiButton1
            // 
            this.uiButton1.Image = global::LawMate.Properties.Resources.prtscr;
            this.uiButton1.Location = new System.Drawing.Point(67, 265);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(106, 23);
            this.uiButton1.TabIndex = 4;
            this.uiButton1.Text = "Print Screen";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(456, 265);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(60, 23);
            this.uiButton2.TabIndex = 5;
            this.uiButton2.Text = "OK";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.Image = global::LawMate.Properties.Resources.copy;
            this.uiButton3.Location = new System.Drawing.Point(187, 265);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(159, 23);
            this.uiButton3.TabIndex = 6;
            this.uiButton3.Text = "Copy Error Message Text";
            this.uiButton3.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // fError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 312);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.editBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblImg);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fError";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atrium Error";
            this.Activated += new System.EventHandler(this.fError_Activated);
            this.Deactivate += new System.EventHandler(this.fError_Deactivate);
            this.Shown += new System.EventHandler(this.fError_Shown);
            this.Enter += new System.EventHandler(this.fError_Enter);
            this.Leave += new System.EventHandler(this.fError_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.Label lblTitle;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton3;
    }
}