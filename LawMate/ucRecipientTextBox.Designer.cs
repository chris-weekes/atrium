 namespace LawMate
{
    partial class ucRecipientTextBox
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
                this.flowLayoutPanelRecipient.Click -= new System.EventHandler(this.flowLayoutPanelRecipient_Click);
                this.flowLayoutPanelRecipient.ControlAdded -= new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelRecipient_ControlAdded);

                this.tbNewRecipient.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.tbNewRecipient_KeyPress);
                this.tbNewRecipient.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.tbNewRecipient_MouseUp);
                this.tbNewRecipient.Leave -= new System.EventHandler(this.tbNewRecipient_Leave);

                this.tsAdd.Click -= new System.EventHandler(this.tsAdd_Click);

                this.tsAddToAddressBook.Click -= new System.EventHandler(this.tsAddToAddressBook_Click);

                dm = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecipientTextBox));
            this.flowLayoutPanelRecipient = new System.Windows.Forms.FlowLayoutPanel();
            this.tbNewRecipient = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ctxMenuRecip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectedPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddToAddressBook = new System.Windows.Forms.ToolStripMenuItem();
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            this.flowLayoutPanelRecipient.SuspendLayout();
            this.ctxMenuRecip.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelRecipient
            // 
            resources.ApplyResources(this.flowLayoutPanelRecipient, "flowLayoutPanelRecipient");
            this.flowLayoutPanelRecipient.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelRecipient.Controls.Add(this.tbNewRecipient);
            this.flowLayoutPanelRecipient.Name = "flowLayoutPanelRecipient";
            this.flowLayoutPanelRecipient.Click += new System.EventHandler(this.flowLayoutPanelRecipient_Click);
            this.flowLayoutPanelRecipient.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelRecipient_ControlAdded);
            this.flowLayoutPanelRecipient.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelRecipient_ControlRemoved);
            // 
            // tbNewRecipient
            // 
            this.tbNewRecipient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbNewRecipient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbNewRecipient.BackColor = System.Drawing.SystemColors.Control;
            this.tbNewRecipient.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            resources.ApplyResources(this.tbNewRecipient, "tbNewRecipient");
            this.tbNewRecipient.Name = "tbNewRecipient";
            this.tbNewRecipient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewRecipient_KeyPress);
            this.tbNewRecipient.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbNewRecipient_MouseUp);
            this.tbNewRecipient.Validated += new System.EventHandler(this.tbNewRecipient_Leave);
            // 
            // ctxMenuRecip
            // 
            this.ctxMenuRecip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedPersonToolStripMenuItem,
            this.tsAdd,
            this.tsAddToAddressBook});
            this.ctxMenuRecip.Name = "ctxMenuRecip";
            resources.ApplyResources(this.ctxMenuRecip, "ctxMenuRecip");
            this.ctxMenuRecip.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuRecip_Opening);
            // 
            // selectedPersonToolStripMenuItem
            // 
            this.selectedPersonToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.selectedPersonToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.selectedPersonToolStripMenuItem, "selectedPersonToolStripMenuItem");
            this.selectedPersonToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectedPersonToolStripMenuItem.Name = "selectedPersonToolStripMenuItem";
            // 
            // tsAdd
            // 
            this.tsAdd.Image = global::LawMate.Properties.Resources.user;
            this.tsAdd.Name = "tsAdd";
            resources.ApplyResources(this.tsAdd, "tsAdd");
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsAddToAddressBook
            // 
            this.tsAddToAddressBook.Image = global::LawMate.Properties.Resources.user;
            this.tsAddToAddressBook.Name = "tsAddToAddressBook";
            resources.ApplyResources(this.tsAddToAddressBook, "tsAddToAddressBook");
            this.tsAddToAddressBook.Click += new System.EventHandler(this.tsAddToAddressBook_Click);
            // 
            // janusSuperTip1
            // 
            this.janusSuperTip1.AutoPopDelay = 2000;
            this.janusSuperTip1.ImageList = null;
            this.janusSuperTip1.InitialDelay = 500;
            // 
            // ucRecipientTextBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanelRecipient);
            this.Name = "ucRecipientTextBox";
            this.flowLayoutPanelRecipient.ResumeLayout(false);
            this.flowLayoutPanelRecipient.PerformLayout();
            this.ctxMenuRecip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRecipient;
        private System.Windows.Forms.ContextMenuStrip ctxMenuRecip;
        private System.Windows.Forms.ToolStripMenuItem tsAdd;
        private System.Windows.Forms.ToolStripMenuItem tsAddToAddressBook;
        private Janus.Windows.GridEX.EditControls.EditBox tbNewRecipient;
        private System.Windows.Forms.ToolStripMenuItem selectedPersonToolStripMenuItem;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
    }
}
