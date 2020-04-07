namespace LawMate
{
    partial class ucIssueSelectBox
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
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucIssueSelectBox));
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            Janus.Windows.GridEX.GridEXLayout mccLegProvision_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout mccRegulationProvision_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.issueAnalysisRTB = new System.Windows.Forms.RichTextBox();
            this.mccLegProvision = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.rtbLegAna = new System.Windows.Forms.RichTextBox();
            this.rtbRegAna = new System.Windows.Forms.RichTextBox();
            this.rtbRegText = new System.Windows.Forms.RichTextBox();
            this.mccRegulationProvision = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.rtbLegText = new System.Windows.Forms.RichTextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mccLegProvision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mccRegulationProvision)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            // 
            // editBox1
            // 
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis;
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.editBox1.ButtonClick += new System.EventHandler(this.editBox1_ButtonClick);
            // 
            // issueAnalysisRTB
            // 
            resources.ApplyResources(this.issueAnalysisRTB, "issueAnalysisRTB");
            this.issueAnalysisRTB.BackColor = System.Drawing.SystemColors.Window;
            this.issueAnalysisRTB.HideSelection = false;
            this.issueAnalysisRTB.Name = "issueAnalysisRTB";
            this.issueAnalysisRTB.ReadOnly = true;
            // 
            // mccLegProvision
            // 
            resources.ApplyResources(this.mccLegProvision, "mccLegProvision");
            resources.ApplyResources(mccLegProvision_DesignTimeLayout, "mccLegProvision_DesignTimeLayout");
            this.mccLegProvision.DesignTimeLayout = mccLegProvision_DesignTimeLayout;
            this.mccLegProvision.DisplayMember = "ProvisionNameEng";
            this.mccLegProvision.Name = "mccLegProvision";
            this.mccLegProvision.ReadOnly = true;
            this.mccLegProvision.SelectedIndex = -1;
            this.mccLegProvision.SelectedItem = null;
            this.mccLegProvision.ValueMember = "ProvisionId";
            this.mccLegProvision.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // rtbLegAna
            // 
            resources.ApplyResources(this.rtbLegAna, "rtbLegAna");
            this.rtbLegAna.BackColor = System.Drawing.SystemColors.Window;
            this.rtbLegAna.HideSelection = false;
            this.rtbLegAna.Name = "rtbLegAna";
            this.rtbLegAna.ReadOnly = true;
            // 
            // rtbRegAna
            // 
            resources.ApplyResources(this.rtbRegAna, "rtbRegAna");
            this.rtbRegAna.BackColor = System.Drawing.SystemColors.Window;
            this.rtbRegAna.HideSelection = false;
            this.rtbRegAna.Name = "rtbRegAna";
            this.rtbRegAna.ReadOnly = true;
            // 
            // rtbRegText
            // 
            resources.ApplyResources(this.rtbRegText, "rtbRegText");
            this.rtbRegText.BackColor = System.Drawing.SystemColors.Window;
            this.rtbRegText.HideSelection = false;
            this.rtbRegText.Name = "rtbRegText";
            this.rtbRegText.ReadOnly = true;
            // 
            // mccRegulationProvision
            // 
            resources.ApplyResources(this.mccRegulationProvision, "mccRegulationProvision");
            resources.ApplyResources(mccRegulationProvision_DesignTimeLayout, "mccRegulationProvision_DesignTimeLayout");
            this.mccRegulationProvision.DesignTimeLayout = mccRegulationProvision_DesignTimeLayout;
            this.mccRegulationProvision.DisplayMember = "ProvisionNameEng";
            this.mccRegulationProvision.Name = "mccRegulationProvision";
            this.mccRegulationProvision.ReadOnly = true;
            this.mccRegulationProvision.SelectedIndex = -1;
            this.mccRegulationProvision.SelectedItem = null;
            this.mccRegulationProvision.ValueMember = "ProvisionId";
            this.mccRegulationProvision.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // rtbLegText
            // 
            resources.ApplyResources(this.rtbLegText, "rtbLegText");
            this.rtbLegText.BackColor = System.Drawing.SystemColors.Window;
            this.rtbLegText.HideSelection = false;
            this.rtbLegText.Name = "rtbLegText";
            this.rtbLegText.ReadOnly = true;
            // 
            // ucIssueSelectBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(label7);
            this.Controls.Add(this.rtbRegAna);
            this.Controls.Add(this.rtbRegText);
            this.Controls.Add(this.rtbLegAna);
            this.Controls.Add(label4);
            this.Controls.Add(this.rtbLegText);
            this.Controls.Add(this.issueAnalysisRTB);
            this.Controls.Add(this.mccLegProvision);
            this.Controls.Add(label3);
            this.Controls.Add(label1);
            this.Controls.Add(this.mccRegulationProvision);
            this.Controls.Add(label2);
            this.Controls.Add(this.editBox1);
            this.Controls.Add(label5);
            this.Controls.Add(label6);
            this.Name = "ucIssueSelectBox";
            ((System.ComponentModel.ISupportInitialize)(this.mccLegProvision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mccRegulationProvision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private System.Windows.Forms.RichTextBox issueAnalysisRTB;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo mccLegProvision;
        private System.Windows.Forms.RichTextBox rtbLegAna;
        private System.Windows.Forms.RichTextBox rtbRegAna;
        private System.Windows.Forms.RichTextBox rtbRegText;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo mccRegulationProvision;
        private System.Windows.Forms.RichTextBox rtbLegText;
    }
}
