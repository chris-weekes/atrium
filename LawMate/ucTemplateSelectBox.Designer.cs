namespace LawMate
{
    partial class ucTemplateSelectBox
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
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.SuspendLayout();
            // 
            // editBox1
            // 
            this.editBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis;
            this.editBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBox1.Location = new System.Drawing.Point(0, 0);
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.Size = new System.Drawing.Size(390, 21);
            this.editBox1.TabIndex = 1;
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.editBox1.ButtonClick += new System.EventHandler(this.editBox1_ButtonClick);
            // 
            // ucTemplateSelectBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.editBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ucTemplateSelectBox";
            this.Size = new System.Drawing.Size(390, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
    }
}

