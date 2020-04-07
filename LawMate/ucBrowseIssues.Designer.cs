 namespace LawMate.UserControls
{
    partial class ucBrowseIssues
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBrowseIssues));
            this.tvIssues = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvIssues
            // 
            this.tvIssues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tvIssues, "tvIssues");
            this.tvIssues.HotTracking = true;
            this.tvIssues.ImageList = this.imageList1;
            this.tvIssues.Name = "tvIssues";
            this.tvIssues.ShowLines = false;
            this.tvIssues.ShowNodeToolTips = true;
            this.tvIssues.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvIssues_AfterSelect);
            this.tvIssues.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvIssues_NodeMouseClick);
            this.tvIssues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvIssues_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bs.gif");
            this.imageList1.Images.SetKeyName(1, "bo.gif");
            this.imageList1.Images.SetKeyName(2, "form.gif");
            this.imageList1.Images.SetKeyName(3, "issue.png");
            this.imageList1.Images.SetKeyName(4, "activity1.gif");
            this.imageList1.Images.SetKeyName(5, "folder.gif");
            // 
            // ucBrowseIssues
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tvIssues);
            resources.ApplyResources(this, "$this");
            this.Name = "ucBrowseIssues";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvIssues;
        private System.Windows.Forms.ImageList imageList1;
    }
}
