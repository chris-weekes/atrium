namespace LawMate.Admin
{
    partial class ucWorkflowHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWorkflowHeader));
            System.Windows.Forms.Label label1;
            this.ebSeriesName = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ebStep = new Janus.Windows.GridEX.EditControls.EditBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.SystemColors.WindowText;
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.SystemColors.WindowText;
            label1.Name = "label1";
            // 
            // ebSeriesName
            // 
            resources.ApplyResources(this.ebSeriesName, "ebSeriesName");
            this.ebSeriesName.Name = "ebSeriesName";
            this.ebSeriesName.ReadOnly = true;
            this.ebSeriesName.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            // 
            // ebStep
            // 
            resources.ApplyResources(this.ebStep, "ebStep");
            this.ebStep.Name = "ebStep";
            this.ebStep.ReadOnly = true;
            this.ebStep.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            // 
            // ucWorkflowHeader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ebStep);
            this.Controls.Add(label1);
            this.Controls.Add(this.ebSeriesName);
            this.Controls.Add(label2);
            this.Name = "ucWorkflowHeader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.EditControls.EditBox ebSeriesName;
        private Janus.Windows.GridEX.EditControls.EditBox ebStep;
    }
}
