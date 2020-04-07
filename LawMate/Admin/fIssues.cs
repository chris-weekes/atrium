using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate.Admin
{
    public partial class fIssues : fBase
    {
        atriumBE.FileManager myFM;
        //atriumBE.FileManager selectedFileFM;

        private appDB.IssueRow selectedIssue;
        private appDB.IssueRow parentIssue;

        //TreeNode src;
        TreeNode NodeDragSource;
        //fBrowse fbr;
        fBrowseIssues fbrIssues;

        public fIssues()
        {
            InitializeComponent();
        }

        public fIssues(Form f)
            : base(f)
        {
            InitializeComponent();
            myFM = AtMng.GetFile();
            ucFileSelectBox1.AtMng = AtMng;
            ucOfficeSelectBox1.AtMng = AtMng;

            issueBindingSource1.DataSource = AtMng.DB;
            issueBindingSource1.DataMember = AtMng.DB.Issue.TableName;

            UIHelper.MultiColumnComboInit("vProvision", mccLegProvision, myFM);
            UIHelper.MultiColumnComboInit("vProvision", mccRegProvision, myFM);

            //myFM.DB.Issue.ColumnChanged += new DataColumnChangeEventHandler(Issue_ColumnChanged);
            //myFM.GetIssue().OnUpdate += new atLogic.UpdateEventHandler(fIssues_OnUpdate);
            LoadRoot();
        }

        //void fIssues_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        //{
        //    if (e.SavedOK)
        //        treeView1.Enabled = true;
        //}

        //void Issue_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        //{
        //    treeView1.Enabled = false;
        //}

        private void LoadRoot()
        {
            //load root
            treeView1.Nodes.Clear();
            AtMng.GetIssue().Load();
            appDB.IssueRow rootIssue = AtMng.DB.Issue.FindByIssueId(0);

            TreeNode nd = new TreeNode();
            nd.Text = rootIssue.IssueNameEng;
            nd.Tag = rootIssue;
            nd.Name = rootIssue.IssueId.ToString();
            nd.ImageIndex = 0;
            nd.SelectedImageIndex = 0;
            treeView1.SelectedNode = nd;

            treeView1.Nodes.Add(nd);
            //treeView1.Sort();

            LoadLevel(nd, 0);
            //treeView1.ExpandAll();
            setBindingSourcePosition(rootIssue.IssueId);
        }

        private void LoadLevel(TreeNode pnd, int parentIssueId)
        {
            //myFM.GetIssue().LoadByParentIssueId(parentIssueId);

            appDB.IssueRow[] issueRows = (appDB.IssueRow[])AtMng.DB.Issue.Select("ParentIssueId=" + parentIssueId.ToString());
            foreach (appDB.IssueRow isr in issueRows)
            {
                TreeNode nd = new TreeNode();

                nd.Text = isr.IssueNameEng;
                nd.Tag = isr;
                nd.Name = isr.IssueId.ToString();

                checkNodeForFileId(nd, isr);

                pnd.Nodes.Add(nd);
                LoadLevel(nd, isr.IssueId);
            }
        }

        private void checkNodeForFileId(TreeNode trnd, appDB.IssueRow issue)
        {
            if (issue.IsFileIdNull())
            {
                trnd.ImageKey = "folder.gif";
                trnd.SelectedImageKey = "folder.gif";
            }
        }

        private void InEditModeMessage()
        {
        //    MessageBox.Show("You have edited the RTF Contents. Please save your changes before navigating off the selected issue.");
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (inEditMode)
                {
                    InEditModeMessage();
                    return;
                }
                switch (treeView1.HitTest(e.Location).Location)
                {
                    case TreeViewHitTestLocations.Label:
                    case TreeViewHitTestLocations.Image:
                    case TreeViewHitTestLocations.PlusMinus:
                        e.Node.TreeView.SelectedNode = e.Node;
                        selectedIssue = (appDB.IssueRow)e.Node.Tag;
                        setBindingSourcePosition(selectedIssue.IssueId);        
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private appDB.IssueRow CurrentRow()
        {
            return (appDB.IssueRow)((DataRowView)issueBindingSource1.Current).Row;
        }

        bool isSettingValues = false;
        private void SetRTFValues(bool BlankOutField)
        {
            isSettingValues = true;
            if (!BlankOutField)
            {
                if (!CurrentRow().IsAnalysisTextEngNull())
                {
                    OrigAnalysisEng = CurrentRow().AnalysisTextEng;
                    try
                    { AnalysisTextERtb.Rtf = CurrentRow().AnalysisTextEng; }
                    catch (Exception x)
                    {
                        AnalysisTextERtb.Text = CurrentRow().AnalysisTextEng;
                    }
                }
                else
                {
                    AnalysisTextERtb.Rtf = String.Empty;
                    AnalysisTextERtb.Text = "";
                    OrigAnalysisEng = "";
                }
                if (!CurrentRow().IsAnalysisTextFreNull())
                {
                    OrigAnalysisFre = CurrentRow().AnalysisTextFre;
                    try
                    { AnalysisTextFRtb.Rtf = CurrentRow().AnalysisTextFre; }
                    catch (Exception x)
                    {
                        AnalysisTextFRtb.Text = CurrentRow().AnalysisTextFre;
                    }
                }
                else
                {
                    AnalysisTextFRtb.Rtf= String.Empty;
                    AnalysisTextFRtb.Text = "";
                    OrigAnalysisFre = "";
                }
            }
            else
            {
                AnalysisTextERtb.Rtf = String.Empty;
                AnalysisTextERtb.Text = "";
                OrigAnalysisEng = "";
                AnalysisTextFRtb.Rtf = String.Empty;
                AnalysisTextFRtb.Text = "";
                OrigAnalysisFre = "";
            }
            isSettingValues = false;
        }

        private void setBindingSourcePosition(int issueId)
        {
            if (inEditMode)
            {
                InEditModeMessage();
                return;
            }
            //if (!treeView1.Enabled)
            //    return;
            issueBindingSource1.Position = issueBindingSource1.Find("IssueId", issueId);
            

            //treeView1.Enabled = true;

            if (CurrentRow().IssueId != 0)
            {
                ucFileSelectBox1.Enabled = true;
                linkLabel2.Enabled = true;
                parentIssue = AtMng.DB.Issue.FindByIssueId(CurrentRow().ParentIssueId);
                ebParentIssueName.Text = parentIssue.IssueNameEng;
                ebParentIssueDescription.Text = parentIssue.IssueDescEng;
                SetRTFValues(false);
            }
            else
            {
                ucFileSelectBox1.Enabled = false;
                linkLabel2.Enabled = false;
                ebParentIssueName.Text = "";
                ebParentIssueDescription.Text = "";
                SetRTFValues(true);
            }
           
            if (!CurrentRow().IsFileIdNull())
                uiButton1.Enabled = true;
            else
                uiButton1.Enabled = false;

            TreeNode[] newnode = treeView1.Nodes.Find(issueId.ToString(), true);
            if (newnode.Length==1 && newnode[0].Nodes.Count == 0)
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            if (newnode.Length == 1)
                checkNodeForFileId(newnode[0], CurrentRow());

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (inEditMode)
                {
                    InEditModeMessage();
                    return;
                }
                selectedIssue = (appDB.IssueRow)e.Node.Tag;
                setBindingSourcePosition(selectedIssue.IssueId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        DragDropEffects ddEffect;
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                if (inEditMode)
                {
                    InEditModeMessage();
                    return;
                }

                NodeDragSource = (TreeNode)e.Item;
                appDB.IssueRow ir = (appDB.IssueRow)NodeDragSource.Tag;

                setCurrentNode(ir.IssueId.ToString());
                setBindingSourcePosition(ir.IssueId);

                ddEffect = this.DoDragDrop(NodeDragSource.Text, DragDropEffects.Move);
                if (ddEffect == DragDropEffects.Move)
                {
                    // src.Remove();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        TreeNode OldNode = null;
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point p = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode aNode = treeView1.HitTest(p).Node;
            if (aNode != null)
            {
                // If the node is an issue, change the color of the background to simulate selection
                // Be sure to return the previous node to its original color by copying from a blank node

                if (aNode.FullPath.StartsWith(NodeDragSource.FullPath))
                    e.Effect = DragDropEffects.None;
                else
                    e.Effect = DragDropEffects.Move;
                
                aNode.ForeColor = Color.LightGray;
                aNode.NodeFont = new Font(treeView1.Font, FontStyle.Underline);

                if ((OldNode != null) && (OldNode != aNode))
                {
                    OldNode.ForeColor = Color.Black;
                    OldNode.NodeFont = new Font(treeView1.Font, FontStyle.Regular);
                }
                OldNode = aNode;
            }

        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            Point p = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode nd = treeView1.HitTest(p).Node;
            if (nd != null)
                e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
             try
            {
                Point p = treeView1.PointToClient(new Point(e.X, e.Y));
                TreeNode nd = treeView1.HitTest(p).Node;
                if (nd != null)
                {

                    nd.ForeColor = Color.Black;
                    nd.NodeFont = new Font(treeView1.Font, FontStyle.Regular);

                    appDB.IssueRow target = (appDB.IssueRow)nd.Tag;
                    TreeNode[] childNodes = NodeDragSource.Nodes.Find(nd.Name, true);

                    appDB.IssueRow irSource = (appDB.IssueRow)NodeDragSource.Tag;

                    if (childNodes.Length > 0)
                        MessageBox.Show("You cannot move an issue to a child of itself.", "Invalid Move Operation", MessageBoxButtons.OK);
                    else if (NodeDragSource != nd && irSource.ParentIssueId != target.IssueId)
                    {
                        
                        irSource.ParentIssueId = target.IssueId;
                        issueBindingSource1.EndEdit();
                        Save();
                        LoadRoot();
                        setBindingSourcePosition(irSource.IssueId);
                        setCurrentNode(irSource.IssueId.ToString());
                    }
                        
                    

                    /*atriumDB.EFileRow file=(atriumDB.EFileRow)src.Tag;
                    
                    //do Update with file manager for file
                    FileManager thisfm = myFM.AtMng.GetFile(file.FileId, false);
                    thisfm.EFile.Move(thisfm.CurrentFile, target, true);
                    thisfm.EFile.Update();
                    thisfm.AtMng.AppMan.Commit();

                    //reload update file record
                    file=myFM.EFile.Load(file.FileId, false);
                    src.Tag = file;

                    src.Remove();
                    nd.Nodes.Add(src);
                    tvFiles.SelectedNode = src;
                     */
                }
            }
            catch (Exception x)
            {
               
                UIHelper.HandleUIException(x);
            }
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (CurrentRow().IssueId != 0)
        //    {
        //        if (fbr == null)
        //            fbr = new fBrowse(Atmng, 0,false,false,false);

        //        fbr.ShowDialog(this);
        //        if (fbr.SelectedFile != null)
        //        {
        //            lmDatasets.appDB.IssueRow ir = CurrentRow();
        //            ir.FileId = fbr.SelectedFile.FileId;
        //            if (ir.IssueNameEng == "[New Issue]")
        //            {
        //                ir.IssueNameEng = fbr.SelectedFile.NameE;
        //                ir.IssueNameFre = fbr.SelectedFile.NameF;
        //            }

        //            setBindingSourcePosition(CurrentRow().IssueId);
        //        }
                
        //    }
        //    else
        //    {
        //        MessageBox.Show("You cannot link a file to the root issue.", "Invalid Action", MessageBoxButtons.OK);
        //    }
        //}

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdImport":
                          openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                    openFileDialog1.FileName = "";
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        fBrowse fb = new fBrowse(AtMng,0,false,false,false,true);
                        if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int fid = fb.SelectedFile.FileId;

                            AtMng.GetIssue().Import(openFileDialog1.FileName, 0, 0, fid);
                        }
                    }
                        break;
                    case "cmdExport":
                                saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FileName = "issue" + DateTime.Today.ToString("yyyyMMdd") + ".xml";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AtMng.GetIssue().Export(saveFileDialog1.FileName);
                }
                        break;
                    case "cmdCancel":
                        Cancel();

                        break;
                    case "cmdNew":
                        New();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                    case "cmdToggle" :
                        if (cmdToggle.Checked!= Janus.Windows.UI.InheritableBoolean.True )
                            treeView1.ExpandAll();
                        else
                            treeView1.CollapseAll();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    this.issueBindingSource1.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetIssue());
                    bp.Update();

                    lmDatasets.appDB.IssueRow ir =( lmDatasets.appDB.IssueRow) treeView1.SelectedNode.PrevNode.Tag;
                    treeView1.SelectedNode.Remove();
                    setBindingSourcePosition(ir.IssueId);
                    setCurrentNode(ir.IssueId.ToString());

                    //treeView1.Enabled = true;
                    //LoadRoot();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private void SaveRtfValues()
        {
            if (OrigAnalysisEng!=AnalysisTextERtb.Rtf)
                CurrentRow().AnalysisTextEng = AnalysisTextERtb.Rtf;
            if (OrigAnalysisFre!= AnalysisTextFRtb.Rtf)
                CurrentRow().AnalysisTextFre = AnalysisTextFRtb.Rtf;
        }

        private void Save()
        {
            if (AtMng.DB.Issue.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.DB);
            }
            else
            {
                try
                {
                    string nodeKey = CurrentRow().IssueId.ToString();
                    SaveRtfValues();
                    this.issueBindingSource1.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetIssue());
                    bp.Update();

                    //LoadRoot();
                    
                    setCurrentNode(nodeKey);
                    inEditMode = false;
                    lblRtfEdited.Visible = false;
                    SetRTFValues(false);
                    //TreeNode[] tn=treeView1.Nodes.Find(CurrentRow().ParentIssueId.ToString(), true);
                    //TreeNode nd = treeView1.SelectedNode;
                    //nd.Remove();
                    //tn[0].Nodes.Add(nd);
                }
                catch (Exception x)
                {
                   
                    throw x;
                }
            }
        }
        private void Cancel()
        {
            UIHelper.Cancel(issueBindingSource1);
            SetRTFValues(false);
            inEditMode = false;
            lblRtfEdited.Visible = false;
            setCurrentNode(CurrentRow().IssueId.ToString());
            //treeView1.Enabled = true;
            LoadRoot();
        }
        private void New()
        {
            lmDatasets.appDB.IssueRow ir = (lmDatasets.appDB.IssueRow)AtMng.GetIssue().Add(CurrentRow());
            //LoadRoot();
            TreeNode nd = new TreeNode();

            nd.Text = ir.IssueNameEng;
            nd.Tag = ir;
            nd.Name = ir.IssueId.ToString();

            checkNodeForFileId(nd, ir);

            treeView1.SelectedNode.Nodes.Add(nd);

            setCurrentNode(ir.IssueId.ToString());
        }
        private void setCurrentNode(string nodeKey)
        {
            TreeNode[] newnode = treeView1.Nodes.Find(nodeKey, true);
            if (newnode.Length == 1)
                treeView1.SelectedNode = newnode[0];
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                selectedIssue.SetFileIdNull();
                setBindingSourcePosition(selectedIssue.IssueId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (fbrIssues == null)
                    fbrIssues = new fBrowseIssues(AtMng,true,0);

                fbrIssues.FindIssue(CurrentRow().ParentIssueId);

                string currentPath = treeView1.SelectedNode.FullPath;

                fbrIssues.ShowDialog(this);
                if (fbrIssues.SelectedIssue != null && fbrIssues.SelectedIssue.IssueId!= CurrentRow().IssueId)
                {
                    TreeNode[] tn = treeView1.Nodes.Find(fbrIssues.SelectedIssue.IssueId.ToString(), true);
                    if (tn[0].FullPath.StartsWith(currentPath))
                        throw new LMException("You cannot move an issue to a child of itself.");

                    CurrentRow().ParentIssueId = fbrIssues.SelectedIssue.IssueId;
                    setBindingSourcePosition(CurrentRow().IssueId);

                    TreeNode nd = treeView1.SelectedNode;
                    nd.Remove();
                    tn[0].Nodes.Add(nd);
                    treeView1.SelectedNode = nd;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void issueNameEngTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
               if (treeView1.SelectedNode != null)
                    treeView1.SelectedNode.Text = issueNameEngEditBox.Text;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void btnClearTextE_Click(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                switch (btn.Name)
                {
                    case "btnClearTextE":
                        UIHelper.RtbClearFormat(AnalysisTextERtb);
                        break;
                    case "btnClearTextF":
                        UIHelper.RtbClearFormat(AnalysisTextFRtb);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnTextEBold_Click(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.EditControls.UIButton btn = (Janus.Windows.EditControls.UIButton)sender;
                switch (btn.Name)
                {
                    case "btnTextEBold":
                        UIHelper.RtbFormat(AnalysisTextERtb, FontStyle.Bold);
                        break;
                    case "btnTextEItalics":
                        UIHelper.RtbFormat(AnalysisTextERtb, FontStyle.Italic);
                        break;
                    case "btnTextEUnderline":
                        UIHelper.RtbFormat(AnalysisTextERtb, FontStyle.Underline);
                        break;
                    case "btnTextFBold":
                        UIHelper.RtbFormat(AnalysisTextFRtb, FontStyle.Bold);
                        break;
                    case "btnTextFItalics":
                        UIHelper.RtbFormat(AnalysisTextFRtb, FontStyle.Italic);
                        break;
                    case "btnTextFUnderline":
                        UIHelper.RtbFormat(AnalysisTextFRtb, FontStyle.Underline);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool inEditMode = false;
        string OrigAnalysisEng = "";
        string OrigAnalysisFre = "";
        private void AnalysisTextERtb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isSettingValues)
                {
                    if (AnalysisTextERtb.Rtf != OrigAnalysisEng | AnalysisTextFRtb.Rtf != OrigAnalysisFre)
                    {
                        inEditMode = true;
                        lblRtfEdited.Visible = true;
                    }
                }
                    
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AnalysisTextERtb_Validated(object sender, EventArgs e)
        {
             try
            {
                if (!isSettingValues)
                {
                    if ((AnalysisTextERtb.Rtf != OrigAnalysisEng && OrigAnalysisEng != "" && AnalysisTextERtb.Text != "") | (AnalysisTextFRtb.Rtf != OrigAnalysisFre && OrigAnalysisFre != "" && AnalysisTextFRtb.Text != ""))
                    {
                        inEditMode = true;
                        lblRtfEdited.Visible = true;
                    }
                }
                    
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (inEditMode)
                {
                    InEditModeMessage();
                    e.Cancel = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

