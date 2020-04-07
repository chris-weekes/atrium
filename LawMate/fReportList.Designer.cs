 namespace LawMate
{
    partial class fReportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReportList));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListfBase
            // 
            this.imageListfBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListfBase.ImageStream")));
            this.imageListfBase.Images.SetKeyName(0, "");
            this.imageListfBase.Images.SetKeyName(1, "");
            this.imageListfBase.Images.SetKeyName(2, "");
            this.imageListfBase.Images.SetKeyName(3, "");
            this.imageListfBase.Images.SetKeyName(4, "");
            this.imageListfBase.Images.SetKeyName(5, "");
            this.imageListfBase.Images.SetKeyName(6, "");
            this.imageListfBase.Images.SetKeyName(7, "");
            this.imageListfBase.Images.SetKeyName(8, "");
            this.imageListfBase.Images.SetKeyName(9, "");
            this.imageListfBase.Images.SetKeyName(10, "");
            this.imageListfBase.Images.SetKeyName(11, "");
            this.imageListfBase.Images.SetKeyName(12, "");
            this.imageListfBase.Images.SetKeyName(13, "");
            this.imageListfBase.Images.SetKeyName(14, "");
            this.imageListfBase.Images.SetKeyName(15, "");
            this.imageListfBase.Images.SetKeyName(16, "");
            this.imageListfBase.Images.SetKeyName(17, "");
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.HotTracking = true;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            ((System.Windows.Forms.TreeNode)(resources.GetObject("treeView1.Nodes")))});
            this.helpProvider1.SetShowHelp(this.treeView1, ((bool)(resources.GetObject("treeView1.ShowHelp"))));
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bs.gif");
            this.imageList1.Images.SetKeyName(1, "bo.gif");
            this.imageList1.Images.SetKeyName(2, "form.gif");
            // 
            // fReportList
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.treeView1);
            this.Name = "fReportList";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
    }
}
