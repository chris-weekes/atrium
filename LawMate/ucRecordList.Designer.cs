 namespace LawMate
{
    partial class ucRecordList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecordList));
            Janus.Windows.GridEX.GridEXLayout documentGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference documentGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference documentGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column2.HeaderImage");
            Janus.Windows.Common.Layouts.JanusLayoutReference documentGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.HeaderImage");
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.documentGridEX = new Janus.Windows.GridEX.GridEX();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docDB = new lmDatasets.docDB();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDB)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // documentGridEX
            // 
            resources.ApplyResources(this.documentGridEX, "documentGridEX");
            this.documentGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.documentGridEX.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            this.documentGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.documentGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.documentGridEX.DataSource = this.documentBindingSource;
            documentGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("documentGridEX_DesignTimeLayout_Reference_0.Instance")));
            documentGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("documentGridEX_DesignTimeLayout_Reference_1.Instance")));
            documentGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("documentGridEX_DesignTimeLayout_Reference_2.Instance")));
            documentGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            documentGridEX_DesignTimeLayout_Reference_0,
            documentGridEX_DesignTimeLayout_Reference_1,
            documentGridEX_DesignTimeLayout_Reference_2});
            resources.ApplyResources(documentGridEX_DesignTimeLayout, "documentGridEX_DesignTimeLayout");
            this.documentGridEX.DesignTimeLayout = documentGridEX_DesignTimeLayout;
            this.documentGridEX.DynamicFiltering = true;
            this.documentGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.documentGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.documentGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.documentGridEX.GroupByBoxVisible = false;
            this.documentGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.documentGridEX.GroupRowFormatStyle.FontName = "arial";
            this.documentGridEX.GroupRowVisualStyle = Janus.Windows.GridEX.GroupRowVisualStyle.Outlook2003;
            this.documentGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.documentGridEX.ImageList = this.imageList1;
            this.documentGridEX.Name = "documentGridEX";
            this.documentGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.documentGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.documentGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.documentGridEX.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.documentGridEX_RowDoubleClick);
            this.documentGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.documentGridEX_FormattingRow);
            this.documentGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.documentGridEX_LoadingRow);
            this.documentGridEX.SortKeysChanged += new System.EventHandler(this.documentGridEX_SortKeysChanged);
            this.documentGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.documentGridEX_ColumnButtonClick);
            this.documentGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.documentGridEX_CurrentCellChanging);
            this.documentGridEX.SelectionChanged += new System.EventHandler(this.documentGridEX_SelectionChanged);
            this.documentGridEX.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.documentGridEX_LinkClicked);
            this.documentGridEX.EnabledChanged += new System.EventHandler(this.documentGridEX_EnabledChanged);
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataMember = "Document";
            this.documentBindingSource.DataSource = this.docDB;
            // 
            // docDB
            // 
            this.docDB.DataSetName = "docDB";
            this.docDB.EnforceConstraints = false;
            this.docDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "paper.gif");
            this.imageList1.Images.SetKeyName(1, "checkbox.gif");
            this.imageList1.Images.SetKeyName(2, "pencil.png");
            this.imageList1.Images.SetKeyName(3, "opinion.png");
            this.imageList1.Images.SetKeyName(4, "DraftDocument.jpg");
            // 
            // ucRecordList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.documentGridEX);
            this.Name = "ucRecordList";
            ((System.ComponentModel.ISupportInitialize)(this.documentGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private lmDatasets.docDB docDB;
        private Janus.Windows.GridEX.GridEX documentGridEX;
        private System.Windows.Forms.ImageList imageList1;
    }
}
