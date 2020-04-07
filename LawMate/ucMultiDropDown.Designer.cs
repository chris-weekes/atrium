 namespace LawMate.UserControls
{
    partial class ucMultiDropDown
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
                ASelectedValueChanged = null;

                this.cboMulti.ValueChanged -= new System.EventHandler(this.cboMulti_ValueChanged);
                if(myFilterDT!=null)
                    myFilterDT.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(dt_ColumnChanged);
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
            Janus.Windows.GridEX.GridEXLayout cboMulti_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMultiDropDown));
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboMulti = new Janus.Windows.GridEX.EditControls.MultiColumnCombo();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboMulti)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTitle.Location = new System.Drawing.Point(98, 3);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "value";
            // 
            // cboMulti
            // 
            this.cboMulti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboMulti.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
            cboMulti_DesignTimeLayout.LayoutString = resources.GetString("cboMulti_DesignTimeLayout.LayoutString");
            this.cboMulti.DesignTimeLayout = cboMulti_DesignTimeLayout;
            this.cboMulti.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.cboMulti.Location = new System.Drawing.Point(0, 0);
            this.cboMulti.Margin = new System.Windows.Forms.Padding(0);
            this.cboMulti.Name = "cboMulti";
            this.cboMulti.SelectedIndex = -1;
            this.cboMulti.SelectedItem = null;
            this.cboMulti.SelectInDataSource = true;
            this.cboMulti.Size = new System.Drawing.Size(92, 21);
            this.cboMulti.TabIndex = 2;
            this.cboMulti.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.cboMulti.ValueChanged += new System.EventHandler(this.cboMulti_ValueChanged);
            // 
            // ucMultiDropDown
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cboMulti);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ucMultiDropDown";
            this.Size = new System.Drawing.Size(347, 24);
            ((System.ComponentModel.ISupportInitialize)(this.cboMulti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Janus.Windows.GridEX.EditControls.MultiColumnCombo cboMulti;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
